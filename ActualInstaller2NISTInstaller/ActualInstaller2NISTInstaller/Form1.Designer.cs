namespace ActualInstaller2NISTInstaller
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1_aip_script = new System.Windows.Forms.TextBox();
            this.openFileDialog_Actual = new System.Windows.Forms.OpenFileDialog();
            this.button_browse_aip = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_nsi_file = new System.Windows.Forms.TextBox();
            this.button_create = new System.Windows.Forms.Button();
            this.labelstatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxLicenseSection = new System.Windows.Forms.CheckBox();
            this.checkBoxuninstall_section = new System.Windows.Forms.CheckBox();
            this.textBox_optional_program_folder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1_aip_script
            // 
            this.textBox1_aip_script.Location = new System.Drawing.Point(15, 25);
            this.textBox1_aip_script.Name = "textBox1_aip_script";
            this.textBox1_aip_script.Size = new System.Drawing.Size(909, 20);
            this.textBox1_aip_script.TabIndex = 0;
            // 
            // openFileDialog_Actual
            // 
            this.openFileDialog_Actual.DefaultExt = "aip";
            this.openFileDialog_Actual.Filter = "Actual Installer Scripts|*.aip|All files|*.*";
            this.openFileDialog_Actual.ReadOnlyChecked = true;
            this.openFileDialog_Actual.Title = "Open Actual Installer aip Script File:";
            // 
            // button_browse_aip
            // 
            this.button_browse_aip.AutoEllipsis = true;
            this.button_browse_aip.Location = new System.Drawing.Point(930, 25);
            this.button_browse_aip.Name = "button_browse_aip";
            this.button_browse_aip.Size = new System.Drawing.Size(75, 23);
            this.button_browse_aip.TabIndex = 1;
            this.button_browse_aip.Text = "Browse";
            this.button_browse_aip.UseVisualStyleBackColor = true;
            this.button_browse_aip.Click += new System.EventHandler(this.button_browse_aip_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select your Actual Installer .aip script:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(667, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter filename with no extension. The .nsi extension will be applied:  (note: scr" +
    "ipt will be generated in same directory of actuall installer script.)";
            // 
            // textBox_nsi_file
            // 
            this.textBox_nsi_file.Location = new System.Drawing.Point(15, 74);
            this.textBox_nsi_file.Name = "textBox_nsi_file";
            this.textBox_nsi_file.Size = new System.Drawing.Size(180, 20);
            this.textBox_nsi_file.TabIndex = 4;
            this.textBox_nsi_file.TextChanged += new System.EventHandler(this.textBox_nsi_file_TextChanged);
            // 
            // button_create
            // 
            this.button_create.Enabled = false;
            this.button_create.Location = new System.Drawing.Point(12, 118);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(176, 60);
            this.button_create.TabIndex = 5;
            this.button_create.Text = "Create NIST Script";
            this.button_create.UseVisualStyleBackColor = true;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // labelstatus
            // 
            this.labelstatus.AutoSize = true;
            this.labelstatus.Location = new System.Drawing.Point(214, 142);
            this.labelstatus.Name = "labelstatus";
            this.labelstatus.Size = new System.Drawing.Size(0, 13);
            this.labelstatus.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_optional_program_folder);
            this.groupBox1.Controls.Add(this.checkBoxuninstall_section);
            this.groupBox1.Controls.Add(this.checkBoxLicenseSection);
            this.groupBox1.Location = new System.Drawing.Point(23, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(959, 84);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output Options:";
            // 
            // checkBoxLicenseSection
            // 
            this.checkBoxLicenseSection.AutoSize = true;
            this.checkBoxLicenseSection.Checked = true;
            this.checkBoxLicenseSection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLicenseSection.Location = new System.Drawing.Point(6, 19);
            this.checkBoxLicenseSection.Name = "checkBoxLicenseSection";
            this.checkBoxLicenseSection.Size = new System.Drawing.Size(136, 17);
            this.checkBoxLicenseSection.TabIndex = 0;
            this.checkBoxLicenseSection.Text = "Create License Section";
            this.checkBoxLicenseSection.UseVisualStyleBackColor = true;
            // 
            // checkBoxuninstall_section
            // 
            this.checkBoxuninstall_section.AutoSize = true;
            this.checkBoxuninstall_section.Checked = true;
            this.checkBoxuninstall_section.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxuninstall_section.Location = new System.Drawing.Point(6, 42);
            this.checkBoxuninstall_section.Name = "checkBoxuninstall_section";
            this.checkBoxuninstall_section.Size = new System.Drawing.Size(109, 17);
            this.checkBoxuninstall_section.TabIndex = 1;
            this.checkBoxuninstall_section.Text = "Create Uninstaller";
            this.checkBoxuninstall_section.UseVisualStyleBackColor = true;
            // 
            // textBox_optional_program_folder
            // 
            this.textBox_optional_program_folder.Location = new System.Drawing.Point(371, 17);
            this.textBox_optional_program_folder.Name = "textBox_optional_program_folder";
            this.textBox_optional_program_folder.Size = new System.Drawing.Size(156, 20);
            this.textBox_optional_program_folder.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Optional Program Files Folder to Install into:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 306);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelstatus);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.textBox_nsi_file);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_browse_aip);
            this.Controls.Add(this.textBox1_aip_script);
            this.Name = "Form1";
            this.Text = "Actual Installer  ->  NIST Script Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1_aip_script;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Actual;
        private System.Windows.Forms.Button button_browse_aip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_nsi_file;
        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.Label labelstatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxLicenseSection;
        private System.Windows.Forms.CheckBox checkBoxuninstall_section;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_optional_program_folder;
    }
}

