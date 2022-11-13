
namespace Proteomics_Data_Processor
{
    partial class Proteomics_Data_Processor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.output = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadingSettingsFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSettingsToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label26 = new System.Windows.Forms.Label();
            this.version_number = new System.Windows.Forms.Label();
            this.custom = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.pd = new System.Windows.Forms.TabPage();
            this.process_temp_folder = new System.Windows.Forms.TextBox();
            this.temp_button = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.mainsettings = new System.Windows.Forms.TabPage();
            this.process_thread_autostart = new System.Windows.Forms.CheckBox();
            this.Manual_start = new System.Windows.Forms.Button();
            this.lblElapsed = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.last_check = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Manual_stop = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.process_app_selector = new System.Windows.Forms.ComboBox();
            this.Check_server = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.workder_number = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.workerip = new System.Windows.Forms.TextBox();
            this.workername = new System.Windows.Forms.TextBox();
            this.hostip = new System.Windows.Forms.TextBox();
            this.system_username = new System.Windows.Forms.TextBox();
            this.start_with_windows = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.system_pwd = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.custom.SuspendLayout();
            this.pd.SuspendLayout();
            this.mainsettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workder_number)).BeginInit();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrClock
            // 
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // output
            // 
            this.output.BackColor = System.Drawing.SystemColors.Info;
            this.output.Location = new System.Drawing.Point(395, 55);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(390, 696);
            this.output.TabIndex = 10;
            this.output.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 26;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadingSettingsFromToolStripMenuItem,
            this.saveSettingsToToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadingSettingsFromToolStripMenuItem
            // 
            this.loadingSettingsFromToolStripMenuItem.Name = "loadingSettingsFromToolStripMenuItem";
            this.loadingSettingsFromToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.loadingSettingsFromToolStripMenuItem.Text = "Loading settings  from";
            this.loadingSettingsFromToolStripMenuItem.Click += new System.EventHandler(this.loadingSettingsFromToolStripMenuItem_Click);
            // 
            // saveSettingsToToolStripMenuItem
            // 
            this.saveSettingsToToolStripMenuItem.Name = "saveSettingsToToolStripMenuItem";
            this.saveSettingsToToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.saveSettingsToToolStripMenuItem.Text = "Save settings to";
            this.saveSettingsToToolStripMenuItem.Click += new System.EventHandler(this.saveSettingsToToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(395, 758);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(138, 15);
            this.label26.TabIndex = 27;
            this.label26.Text = "Current Version Number:";
            // 
            // version_number
            // 
            this.version_number.AutoSize = true;
            this.version_number.Location = new System.Drawing.Point(551, 758);
            this.version_number.Name = "version_number";
            this.version_number.Size = new System.Drawing.Size(0, 15);
            this.version_number.TabIndex = 27;
            // 
            // custom
            // 
            this.custom.Controls.Add(this.richTextBox1);
            this.custom.Controls.Add(this.button3);
            this.custom.Location = new System.Drawing.Point(4, 24);
            this.custom.Name = "custom";
            this.custom.Padding = new System.Windows.Forms.Padding(3);
            this.custom.Size = new System.Drawing.Size(385, 682);
            this.custom.TabIndex = 4;
            this.custom.Text = "Processing Script";
            this.custom.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 223);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(376, 357);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(47, 636);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // pd
            // 
            this.pd.Controls.Add(this.process_temp_folder);
            this.pd.Controls.Add(this.temp_button);
            this.pd.Controls.Add(this.label14);
            this.pd.Location = new System.Drawing.Point(4, 24);
            this.pd.Name = "pd";
            this.pd.Padding = new System.Windows.Forms.Padding(3);
            this.pd.Size = new System.Drawing.Size(385, 682);
            this.pd.TabIndex = 3;
            this.pd.Text = "Input_output";
            this.pd.UseVisualStyleBackColor = true;
            // 
            // process_temp_folder
            // 
            this.process_temp_folder.Location = new System.Drawing.Point(8, 81);
            this.process_temp_folder.Name = "process_temp_folder";
            this.process_temp_folder.Size = new System.Drawing.Size(353, 23);
            this.process_temp_folder.TabIndex = 14;
            // 
            // temp_button
            // 
            this.temp_button.Location = new System.Drawing.Point(135, 27);
            this.temp_button.Name = "temp_button";
            this.temp_button.Size = new System.Drawing.Size(75, 33);
            this.temp_button.TabIndex = 20;
            this.temp_button.Text = "Broswer";
            this.temp_button.UseVisualStyleBackColor = true;
            this.temp_button.Click += new System.EventHandler(this.temp_button_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 36);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 15);
            this.label14.TabIndex = 3;
            this.label14.Text = "Temp save folder";
            // 
            // mainsettings
            // 
            this.mainsettings.Controls.Add(this.process_thread_autostart);
            this.mainsettings.Controls.Add(this.Manual_start);
            this.mainsettings.Controls.Add(this.lblElapsed);
            this.mainsettings.Controls.Add(this.textBox3);
            this.mainsettings.Controls.Add(this.last_check);
            this.mainsettings.Controls.Add(this.label15);
            this.mainsettings.Controls.Add(this.label5);
            this.mainsettings.Controls.Add(this.Manual_stop);
            this.mainsettings.Controls.Add(this.label13);
            this.mainsettings.Controls.Add(this.process_app_selector);
            this.mainsettings.Controls.Add(this.Check_server);
            this.mainsettings.Controls.Add(this.label28);
            this.mainsettings.Controls.Add(this.workder_number);
            this.mainsettings.Controls.Add(this.label17);
            this.mainsettings.Controls.Add(this.workerip);
            this.mainsettings.Controls.Add(this.workername);
            this.mainsettings.Controls.Add(this.hostip);
            this.mainsettings.Controls.Add(this.system_username);
            this.mainsettings.Controls.Add(this.start_with_windows);
            this.mainsettings.Controls.Add(this.label2);
            this.mainsettings.Controls.Add(this.label3);
            this.mainsettings.Controls.Add(this.label1);
            this.mainsettings.Controls.Add(this.label12);
            this.mainsettings.Controls.Add(this.label11);
            this.mainsettings.Controls.Add(this.system_pwd);
            this.mainsettings.Location = new System.Drawing.Point(4, 24);
            this.mainsettings.Name = "mainsettings";
            this.mainsettings.Padding = new System.Windows.Forms.Padding(3);
            this.mainsettings.Size = new System.Drawing.Size(385, 682);
            this.mainsettings.TabIndex = 0;
            this.mainsettings.Text = "Main Settings";
            this.mainsettings.UseVisualStyleBackColor = true;
            // 
            // process_thread_autostart
            // 
            this.process_thread_autostart.AutoSize = true;
            this.process_thread_autostart.Location = new System.Drawing.Point(3, 574);
            this.process_thread_autostart.Name = "process_thread_autostart";
            this.process_thread_autostart.Size = new System.Drawing.Size(290, 19);
            this.process_thread_autostart.TabIndex = 42;
            this.process_thread_autostart.Text = "Start process when app starts (save this to Default)";
            this.process_thread_autostart.UseVisualStyleBackColor = true;
            // 
            // Manual_start
            // 
            this.Manual_start.Location = new System.Drawing.Point(17, 626);
            this.Manual_start.Name = "Manual_start";
            this.Manual_start.Size = new System.Drawing.Size(92, 30);
            this.Manual_start.TabIndex = 37;
            this.Manual_start.Text = "Start";
            this.Manual_start.UseVisualStyleBackColor = true;
            // 
            // lblElapsed
            // 
            this.lblElapsed.Location = new System.Drawing.Point(92, 447);
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.ReadOnly = true;
            this.lblElapsed.Size = new System.Drawing.Size(276, 23);
            this.lblElapsed.TabIndex = 40;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(91, 411);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(277, 23);
            this.textBox3.TabIndex = 39;
            // 
            // last_check
            // 
            this.last_check.Enabled = false;
            this.last_check.Location = new System.Drawing.Point(92, 499);
            this.last_check.Name = "last_check";
            this.last_check.ReadOnly = true;
            this.last_check.Size = new System.Drawing.Size(275, 23);
            this.last_check.TabIndex = 41;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 414);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 15);
            this.label15.TabIndex = 36;
            this.label15.Text = "Worker status:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 499);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 34;
            this.label5.Text = "Last Check:";
            // 
            // Manual_stop
            // 
            this.Manual_stop.Location = new System.Drawing.Point(188, 624);
            this.Manual_stop.Name = "Manual_stop";
            this.Manual_stop.Size = new System.Drawing.Size(115, 35);
            this.Manual_stop.TabIndex = 38;
            this.Manual_stop.Text = "Stop";
            this.Manual_stop.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 455);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 15);
            this.label13.TabIndex = 35;
            this.label13.Text = "Timer:";
            // 
            // process_app_selector
            // 
            this.process_app_selector.FormattingEnabled = true;
            this.process_app_selector.Location = new System.Drawing.Point(90, 271);
            this.process_app_selector.Name = "process_app_selector";
            this.process_app_selector.Size = new System.Drawing.Size(277, 23);
            this.process_app_selector.TabIndex = 33;
            // 
            // Check_server
            // 
            this.Check_server.Location = new System.Drawing.Point(146, 232);
            this.Check_server.Name = "Check_server";
            this.Check_server.Size = new System.Drawing.Size(195, 33);
            this.Check_server.TabIndex = 32;
            this.Check_server.Text = "Pull list from Server";
            this.Check_server.UseVisualStyleBackColor = true;
            this.Check_server.Click += new System.EventHandler(this.Check_server_Click_1);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(3, 241);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(115, 15);
            this.label28.TabIndex = 31;
            this.label28.Text = "Choose Process App";
            // 
            // workder_number
            // 
            this.workder_number.Location = new System.Drawing.Point(155, 195);
            this.workder_number.Name = "workder_number";
            this.workder_number.Size = new System.Drawing.Size(100, 23);
            this.workder_number.TabIndex = 30;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 203);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 15);
            this.label17.TabIndex = 29;
            this.label17.Text = "Worker #:";
            // 
            // workerip
            // 
            this.workerip.Location = new System.Drawing.Point(90, 360);
            this.workerip.Name = "workerip";
            this.workerip.Size = new System.Drawing.Size(277, 23);
            this.workerip.TabIndex = 17;
            // 
            // workername
            // 
            this.workername.Location = new System.Drawing.Point(91, 325);
            this.workername.Name = "workername";
            this.workername.Size = new System.Drawing.Size(277, 23);
            this.workername.TabIndex = 16;
            // 
            // hostip
            // 
            this.hostip.Location = new System.Drawing.Point(124, 65);
            this.hostip.Name = "hostip";
            this.hostip.Size = new System.Drawing.Size(243, 23);
            this.hostip.TabIndex = 13;
            // 
            // system_username
            // 
            this.system_username.Location = new System.Drawing.Point(92, 111);
            this.system_username.Name = "system_username";
            this.system_username.Size = new System.Drawing.Size(275, 23);
            this.system_username.TabIndex = 0;
            // 
            // start_with_windows
            // 
            this.start_with_windows.AutoSize = true;
            this.start_with_windows.Location = new System.Drawing.Point(3, 549);
            this.start_with_windows.Name = "start_with_windows";
            this.start_with_windows.Size = new System.Drawing.Size(177, 19);
            this.start_with_windows.TabIndex = 26;
            this.start_with_windows.Text = "Start app with Windows start";
            this.start_with_windows.UseVisualStyleBackColor = true;
            this.start_with_windows.CheckedChanged += new System.EventHandler(this.start_with_windows_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Woker Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 368);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Worker IP:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Server IP/Hostname:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 161);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 15);
            this.label12.TabIndex = 1;
            this.label12.Text = "Password";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 15);
            this.label11.TabIndex = 1;
            this.label11.Text = "username";
            // 
            // system_pwd
            // 
            this.system_pwd.Location = new System.Drawing.Point(92, 158);
            this.system_pwd.Name = "system_pwd";
            this.system_pwd.Size = new System.Drawing.Size(275, 23);
            this.system_pwd.TabIndex = 0;
            this.system_pwd.UseSystemPasswordChar = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.mainsettings);
            this.tabControl.Controls.Add(this.pd);
            this.tabControl.Controls.Add(this.custom);
            this.tabControl.Location = new System.Drawing.Point(0, 41);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(393, 710);
            this.tabControl.TabIndex = 25;
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // Proteomics_Data_Processor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 782);
            this.Controls.Add(this.version_number);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.output);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Proteomics_Data_Processor";
            this.Text = "Proteomics_Data_Processor V1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.custom.ResumeLayout(false);
            this.pd.ResumeLayout(false);
            this.pd.PerformLayout();
            this.mainsettings.ResumeLayout(false);
            this.mainsettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workder_number)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadingSettingsFromToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSettingsToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label version_number;
        private System.Windows.Forms.TabPage custom;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage pd;
        private System.Windows.Forms.TextBox process_temp_folder;
        private System.Windows.Forms.Button temp_button;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage mainsettings;
        private System.Windows.Forms.TextBox workerip;
        private System.Windows.Forms.TextBox workername;
        private System.Windows.Forms.TextBox hostip;
        private System.Windows.Forms.TextBox system_username;
        private System.Windows.Forms.CheckBox start_with_windows;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox system_pwd;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.CheckBox process_thread_autostart;
        private System.Windows.Forms.Button Manual_start;
        private System.Windows.Forms.TextBox lblElapsed;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox last_check;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Manual_stop;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox process_app_selector;
        private System.Windows.Forms.Button Check_server;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.NumericUpDown workder_number;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
    }
}

