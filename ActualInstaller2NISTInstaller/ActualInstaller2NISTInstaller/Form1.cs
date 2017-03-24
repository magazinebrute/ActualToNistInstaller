using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using System.IO;

namespace ActualInstaller2NISTInstaller
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_browse_aip_Click(object sender, EventArgs e)
        {
            openFileDialog_Actual.DefaultExt = "aip";
            DialogResult dr = openFileDialog_Actual.ShowDialog();
            if (dr == DialogResult.OK)
            {
                textBox1_aip_script.Text = openFileDialog_Actual.FileName.ToString();
                if (textBox_nsi_file.Text.Length > 0) button_create.Enabled = true;
            }
        }

        private void button_create_Click(object sender, EventArgs e)
        {
            button_create.Enabled = true;
            if (textBox_nsi_file.TextLength == 0 || textBox1_aip_script.TextLength == 0)
            {
                button_create.Enabled = false;
                MessageBox.Show("Make sure you have an actual installer script selected and an output file NIST file name with no extension entered.");
            }
            else { process(); }
        }

        private void textBox_nsi_file_TextChanged(object sender, EventArgs e)
        {
            if (textBox_nsi_file.TextLength > 0) button_create.Enabled = true;
        }

        /// <summary>
        /// convert aip to nsi
        /// </summary>
        private void process()
        {
            try
            {
                //load aip/ini file
                string _file = textBox1_aip_script.Text.ToString();
                var parser = new FileIniDataParser();
                IniData i = parser.ReadFile(_file);


                string GUID = i["Setup"]["GUID"];
                string appname = i["Setup"]["AppName"];
                string appversion = i["Setup"]["AppVersion"];
                string appdescription = i["Setup"]["AppDescription"];
                string companyname = i["Setup"]["CompanyName"];
                string website = i["Setup"]["WebSite"];
                string supportlink = i["Setup"]["SupportLink"];
                string admin = i["Setup"]["Admin"];
                string setupfilename = i["Setup"]["SetupFileName"];
                string setupfile = i["Setup"]["SetupFile"];
                string internet = i["Setup"]["Internet"];
                string sourcedir = i["Setup"]["SourceDir"];
                //string sourcedir = @"C:\TEMP\BIN";
                string launchfilename = i["Setup"]["LaunchFileName"];
                string launchfilechecked = i["Setup"]["LaunchFileChecked"];
                string promptuninstall = i["Setup"]["PromptUninstall"];
                string shortcuts = i["Shortcuts"]["0"];
                string mainexecutable = i["Setup"]["MainExecutable"];

                //GET LIST OF EXCLUDED FILES

                IniParser.Model.KeyData[] kd = i["FileOptions"].ToArray(); //EXCLUDED FILES
                var myexcludedfiles = new List<string>();
                foreach (IniParser.Model.KeyData item in kd) {
                    if (item.Value.EndsWith("D") || item.Value.Contains(".vshost."))
                    {
                        myexcludedfiles.Add(item.Value.Replace("?D", ""));
                    }
                }

                //get a structure of all files and subdirs
                MyFiles myfiles = new MyFiles();
                List<MyFiles> myworkfiles = new List<MyFiles>();
                myworkfiles = myfiles.GetDirData(@sourcedir);
                
                //remove undesirables
                myworkfiles.RemoveAll(a => a.filename.Contains(".vshost."));
                myworkfiles.RemoveAll(a => a.filename.Contains(".aip"));

                for (int z = 0; z < myworkfiles.Count; z++)
                {
                    string fullpath = Path.Combine(myworkfiles[z].directoryname, myworkfiles[z].filename);
                    if (myexcludedfiles.Any(str => str.Equals(fullpath, StringComparison.OrdinalIgnoreCase))) myworkfiles.RemoveAll(a => a.directoryname == myworkfiles[z].directoryname && a.filename == myworkfiles[z].filename);
                    //remove visual studio files
                    

                }

                                
                //now build nsi script
                string o = "";
                if (admin == "1") o = "RequestExecutionLevel admin" + Environment.NewLine;
                o = o + "!include FileFunc.nsh" + Environment.NewLine;
                o = o + "!insertmacro GetParameters" + Environment.NewLine;
                o = o + "!insertmacro GetOptions" + Environment.NewLine;
                o = o + "!include LogicLib.nsh" + Environment.NewLine + Environment.NewLine;
                o = o + "!define VERSION \"@VERSION\"".Replace("@VERSION",appversion) + Environment.NewLine;
                o = o + "Name \"@APPNAME v. ${VERSION}\"".Replace("@APPNAME", appname) + Environment.NewLine;
                o = o + "OutFile \"@APPNAME.exe\"".Replace("@APPNAME", appname.Replace(" ","_")) + Environment.NewLine;
                if (string.IsNullOrEmpty(textBox_optional_program_folder.Text))
                {
                    o = o + "InstallDir \"$PROGRAMFILES\\@APPNAME\"".Replace("@APPNAME",appname) + Environment.NewLine + Environment.NewLine;
                } else
                {
                    o = o + "InstallDir \"$PROGRAMFILES\\@OPTFOLDER\\@APPNAME\"".Replace("@APPNAME", appname).Replace("@OPTFOLDER",textBox_optional_program_folder.Text) + Environment.NewLine + Environment.NewLine;
                }

                if (checkBoxLicenseSection.Checked)
                {
                    o = o + "LicenseData license.txt" + Environment.NewLine;
                    o = o + "Page license" + Environment.NewLine;
                }
                o = o + "Page components" + Environment.NewLine;
                o = o + "Page directory" + Environment.NewLine;
                o = o + "Page instfiles" + Environment.NewLine;
                if (checkBoxuninstall_section.Checked)
                {
                    o = o + "UninstPage uninstConfirm" + Environment.NewLine;
                    o = o + "UninstPage instfiles" + Environment.NewLine;
                }
                
                //start section main
                o += Environment.NewLine;
                o += "Section Main" + Environment.NewLine;
                o += Environment.NewLine;
                o += "SetShellVarContext all" + Environment.NewLine;
                //o += "SectionIn RO" + Environment.NewLine;
                
                foreach (var item in myworkfiles)
                {
                    if (myfiles.currdir == "")
                    {
                        myfiles.currdir = item.directoryname;
                        if (item.directoryname == sourcedir)
                        {
                            o += "SetOutPath \"$INSTDIR\"" + Environment.NewLine;
                        }
                        else
                        {
                            //we have a new segment
                            string temp = Path.Combine(item.directoryname, item.filename);
                            o += "SetOutPath \"$INSTDIR\\" + new DirectoryInfo(Path.GetDirectoryName(temp)).Name + "\"" +Environment.NewLine;

                        }
                        
                    }
                    else
                    {
                        if (myfiles.currdir != item.directoryname)
                        {
                            //we have a new segment
                            string temp = Path.Combine(item.directoryname, item.filename);
                            o += "SetOutPath \"$INSTDIR\\" + new DirectoryInfo(Path.GetDirectoryName(temp)).Name + "\"" + Environment.NewLine;
                            myfiles.currdir = item.directoryname;
                        }
                    }
                    o += "File /nonfatal " + Path.Combine(item.directoryname, item.filename) + Environment.NewLine;
                }
                
                if (checkBoxuninstall_section.Checked && promptuninstall == "1")
                {
                    o += Environment.NewLine;
                    o += "WriteUninstaller \"$INSTDIR\"\\uninstall.exe\"" + Environment.NewLine;

                }

                //add code for writing registry in the future
                o += "SectionEnd" + Environment.NewLine;
                o += Environment.NewLine;

                //add start menu
                o += "Section StartMenu" + Environment.NewLine;
                o += "SetShellVarContext all" + Environment.NewLine;
                if (string.IsNullOrEmpty(textBox_optional_program_folder.Text))
                {
                    o += "SetOutPath \"$SMPROGRAMS\\@APPNAME\"".Replace("@APPNAME", appname) + Environment.NewLine;
                }
                else
                {
                    o += "SetOutPath \"$SMPROGRAMS\\@OPTFOLDER\\@APPNAME\"".Replace("@APPNAME", appname).Replace("@OPTFOLDER", textBox_optional_program_folder.Text) + Environment.NewLine;
                }
                o += "SetOutPath \"$INSTDIR\"" + Environment.NewLine;

                if (string.IsNullOrEmpty(textBox_optional_program_folder.Text))
                {
                    o += "CreateShortCut \"$SMPROGRAMS\\@APPNAME.lnk\" \"$INSTDIR\\@ME".Replace("@APPNAME", appname).Replace("@ME", mainexecutable.Replace("<InstallDir>\\", "")) + "\"" + Environment.NewLine;
                    
                }
                else
                {
                    o += "CreateShortCut \"$SMPROGRAMS\\@OPTFOLDER\\@APPNAME.lnk\" \"$INSTDIR\\@ME".Replace("@APPNAME", appname).Replace("@OPTFOLDER", textBox_optional_program_folder.Text).Replace("@ME",mainexecutable.Replace("<InstallDir>\\","")) + "\"" + Environment.NewLine;
                }
                o += "SectionEnd" + Environment.NewLine;
                

                //CreateShortCut "$SMPROGRAMS\CBM\Kiosk\CBM Kiosk.lnk" "$INSTDIR\CBMKiosk.exe"
                //<CommonDesktop>*?AgencyServer*?<InstallDir>\ie.bat*?AgencyServer AccessPoint*?*?<InstallDir>*?<InstallDir>\AgencyServer.exe*?0*?Normal

                //now write script
                string writepath = Path.Combine(sourcedir, textBox_nsi_file.Text + ".nsi");
                if (File.Exists(@writepath)) File.Delete(@writepath);
                File.AppendAllText(@writepath, o);
                MessageBox.Show(@writepath + " Created.");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }
    public class MyFiles
    {
        public string currdir { get; set; }
        public string directoryname {get;set;}
        public string filename {get;set;}
        public MyFiles() { currdir = ""; }
        public List<MyFiles> GetDirData(string filepath)
        {
            string oripath = filepath;
            List<MyFiles> myfiles = new List<MyFiles>();
            string[] mydirs = Directory.GetDirectories(filepath);

            //load up root files
            string[] _files = Directory.GetFiles(@filepath);
            foreach (var item in _files)
	        {
		        myfiles.Add( new MyFiles { directoryname= filepath, filename=Path.GetFileName(item)});
	        }

            //now process subdirs
            foreach (var dir in mydirs)
	        {
                
                _files = Directory.GetFiles(dir);
                foreach (var item in _files)
                {
                    myfiles.Add( new MyFiles { directoryname= dir, filename=Path.GetFileName(item)});    
                }
	        }

            return myfiles;

        }
    }
}
