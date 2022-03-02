
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Proteomics_Data_Processor));
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.mq_workerstatus = new System.Windows.Forms.TextBox();
            this.mq_lastupdate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mq_workernumber = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.mq_exe_location = new System.Windows.Forms.TextBox();
            this.mq_temp_select = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tmrClock = new System.Windows.Forms.Timer(this.components);
            this.mq_lblElapsed = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mq_temp_folder = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.mainsettings = new System.Windows.Forms.TabPage();
            this.start_with_windows = new System.Windows.Forms.CheckBox();
            this.workerip = new System.Windows.Forms.TextBox();
            this.workername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.hostip = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.system_pwd = new System.Windows.Forms.TextBox();
            this.system_username = new System.Windows.Forms.TextBox();
            this.pd = new System.Windows.Forms.TabPage();
            this.pd_thread_autostart = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.pd_temp_folder = new System.Windows.Forms.TextBox();
            this.pd_lblElapsed = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.pd_temp_button = new System.Windows.Forms.Button();
            this.pd_workder_number = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pd_last_check = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.maxquant = new System.Windows.Forms.TabPage();
            this.mq_start = new System.Windows.Forms.Button();
            this.mq_stop = new System.Windows.Forms.Button();
            this.mq_autostart = new System.Windows.Forms.CheckBox();
            this.mq_exe_select = new System.Windows.Forms.Button();
            this.msfragger = new System.Windows.Forms.TabPage();
            this.custom = new System.Windows.Forms.TabPage();
            this.pd_batch_file = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.pd_batch_button = new System.Windows.Forms.Button();
            this.remote = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadingSettingsFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSettingsToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mq_tmrClock = new System.Windows.Forms.Timer(this.components);
            this.tabControl.SuspendLayout();
            this.mainsettings.SuspendLayout();
            this.pd.SuspendLayout();
            this.maxquant.SuspendLayout();
            this.custom.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 393);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Last Queue Check:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 317);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Timer:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Worker status:";
            // 
            // mq_workerstatus
            // 
            this.mq_workerstatus.Location = new System.Drawing.Point(94, 255);
            this.mq_workerstatus.Name = "mq_workerstatus";
            this.mq_workerstatus.Size = new System.Drawing.Size(275, 23);
            this.mq_workerstatus.TabIndex = 15;
            // 
            // mq_lastupdate
            // 
            this.mq_lastupdate.Location = new System.Drawing.Point(120, 390);
            this.mq_lastupdate.Name = "mq_lastupdate";
            this.mq_lastupdate.Size = new System.Drawing.Size(262, 23);
            this.mq_lastupdate.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 15);
            this.label9.TabIndex = 2;
            this.label9.Text = "Worker #:";
            // 
            // mq_workernumber
            // 
            this.mq_workernumber.FormattingEnabled = true;
            this.mq_workernumber.Items.AddRange(new object[] {
            "1",
            "2"});
            this.mq_workernumber.Location = new System.Drawing.Point(73, 24);
            this.mq_workernumber.Name = "mq_workernumber";
            this.mq_workernumber.Size = new System.Drawing.Size(121, 23);
            this.mq_workernumber.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(15, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 15);
            this.label10.TabIndex = 3;
            this.label10.Text = "Temp save folder";
            // 
            // mq_exe_location
            // 
            this.mq_exe_location.Location = new System.Drawing.Point(16, 192);
            this.mq_exe_location.Name = "mq_exe_location";
            this.mq_exe_location.Size = new System.Drawing.Size(353, 23);
            this.mq_exe_location.TabIndex = 14;
            // 
            // mq_temp_select
            // 
            this.mq_temp_select.Location = new System.Drawing.Point(120, 76);
            this.mq_temp_select.Name = "mq_temp_select";
            this.mq_temp_select.Size = new System.Drawing.Size(75, 33);
            this.mq_temp_select.TabIndex = 20;
            this.mq_temp_select.Text = "Broswer";
            this.mq_temp_select.UseVisualStyleBackColor = true;
            this.mq_temp_select.Click += new System.EventHandler(this.button1_Click);
            // 
            // tmrClock
            // 
            this.tmrClock.Tick += new System.EventHandler(this.tmrClock_Tick);
            // 
            // mq_tmrClock
            // 
            this.mq_tmrClock.Tick += new System.EventHandler(this.mq_tmrClock_Tick);

            // 
            // mq_lblElapsed
            // 
            this.mq_lblElapsed.Location = new System.Drawing.Point(73, 314);
            this.mq_lblElapsed.Name = "mq_lblElapsed";
            this.mq_lblElapsed.ReadOnly = true;
            this.mq_lblElapsed.Size = new System.Drawing.Size(287, 23);
            this.mq_lblElapsed.TabIndex = 16;
            // 
            // output
            // 
            this.output.BackColor = System.Drawing.SystemColors.Info;
            this.output.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.output.Location = new System.Drawing.Point(395, 55);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(390, 696);
            this.output.TabIndex = 10;
            this.output.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Maxquant.exe location";
            // 
            // mq_temp_folder
            // 
            this.mq_temp_folder.Location = new System.Drawing.Point(16, 115);
            this.mq_temp_folder.Name = "mq_temp_folder";
            this.mq_temp_folder.Size = new System.Drawing.Size(353, 23);
            this.mq_temp_folder.TabIndex = 11;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.mainsettings);
            this.tabControl.Controls.Add(this.pd);
            this.tabControl.Controls.Add(this.maxquant);
            this.tabControl.Controls.Add(this.msfragger);
            this.tabControl.Controls.Add(this.custom);
            this.tabControl.Controls.Add(this.remote);
            this.tabControl.Location = new System.Drawing.Point(0, 41);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(393, 710);
            this.tabControl.TabIndex = 25;
            // 
            // mainsettings
            // 
            this.mainsettings.Controls.Add(this.start_with_windows);
            this.mainsettings.Controls.Add(this.workerip);
            this.mainsettings.Controls.Add(this.workername);
            this.mainsettings.Controls.Add(this.label2);
            this.mainsettings.Controls.Add(this.label3);
            this.mainsettings.Controls.Add(this.label1);
            this.mainsettings.Controls.Add(this.hostip);
            this.mainsettings.Controls.Add(this.label12);
            this.mainsettings.Controls.Add(this.label11);
            this.mainsettings.Controls.Add(this.system_pwd);
            this.mainsettings.Controls.Add(this.system_username);
            this.mainsettings.Location = new System.Drawing.Point(4, 24);
            this.mainsettings.Name = "mainsettings";
            this.mainsettings.Padding = new System.Windows.Forms.Padding(3);
            this.mainsettings.Size = new System.Drawing.Size(385, 682);
            this.mainsettings.TabIndex = 0;
            this.mainsettings.Text = "Main Settings";
            this.mainsettings.UseVisualStyleBackColor = true;
            // 
            // start_with_windows
            // 
            this.start_with_windows.AutoSize = true;
            this.start_with_windows.Location = new System.Drawing.Point(19, 442);
            this.start_with_windows.Name = "start_with_windows";
            this.start_with_windows.Size = new System.Drawing.Size(177, 19);
            this.start_with_windows.TabIndex = 26;
            this.start_with_windows.Text = "Start app with Windows start";
            this.start_with_windows.UseVisualStyleBackColor = true;
            this.start_with_windows.CheckedChanged += new System.EventHandler(this.start_with_windows_CheckedChanged);
            // 
            // workerip
            // 
            this.workerip.Location = new System.Drawing.Point(87, 325);
            this.workerip.Name = "workerip";
            this.workerip.Size = new System.Drawing.Size(269, 23);
            this.workerip.TabIndex = 17;
            // 
            // workername
            // 
            this.workername.Location = new System.Drawing.Point(90, 284);
            this.workername.Name = "workername";
            this.workername.Size = new System.Drawing.Size(266, 23);
            this.workername.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Woker Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 328);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Worker IP:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Server IP/Hostname:";
            // 
            // hostip
            // 
            this.hostip.Location = new System.Drawing.Point(124, 109);
            this.hostip.Name = "hostip";
            this.hostip.Size = new System.Drawing.Size(232, 23);
            this.hostip.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 212);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 15);
            this.label12.TabIndex = 1;
            this.label12.Text = "Password";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 15);
            this.label11.TabIndex = 1;
            this.label11.Text = "System username";
            // 
            // system_pwd
            // 
            this.system_pwd.Location = new System.Drawing.Point(114, 209);
            this.system_pwd.Name = "system_pwd";
            this.system_pwd.Size = new System.Drawing.Size(100, 23);
            this.system_pwd.TabIndex = 0;
            this.system_pwd.UseSystemPasswordChar = true;
            // 
            // system_username
            // 
            this.system_username.Location = new System.Drawing.Point(114, 165);
            this.system_username.Name = "system_username";
            this.system_username.Size = new System.Drawing.Size(100, 23);
            this.system_username.TabIndex = 0;
            // 
            // pd
            // 
            this.pd.Controls.Add(this.pd_thread_autostart);
            this.pd.Controls.Add(this.label17);
            this.pd.Controls.Add(this.button5);
            this.pd.Controls.Add(this.pd_temp_folder);
            this.pd.Controls.Add(this.pd_lblElapsed);
            this.pd.Controls.Add(this.textBox3);
            this.pd.Controls.Add(this.label15);
            this.pd.Controls.Add(this.pd_temp_button);
            this.pd.Controls.Add(this.pd_workder_number);
            this.pd.Controls.Add(this.label5);
            this.pd.Controls.Add(this.label14);
            this.pd.Controls.Add(this.button2);
            this.pd.Controls.Add(this.pd_last_check);
            this.pd.Controls.Add(this.label13);
            this.pd.Location = new System.Drawing.Point(4, 24);
            this.pd.Name = "pd";
            this.pd.Padding = new System.Windows.Forms.Padding(3);
            this.pd.Size = new System.Drawing.Size(385, 682);
            this.pd.TabIndex = 3;
            this.pd.Text = "PD";
            this.pd.UseVisualStyleBackColor = true;
            // 
            // pd_thread_autostart
            // 
            this.pd_thread_autostart.AutoSize = true;
            this.pd_thread_autostart.Location = new System.Drawing.Point(19, 420);
            this.pd_thread_autostart.Name = "pd_thread_autostart";
            this.pd_thread_autostart.Size = new System.Drawing.Size(290, 19);
            this.pd_thread_autostart.TabIndex = 25;
            this.pd_thread_autostart.Text = "Start process when app starts (save this to Default)";
            this.pd_thread_autostart.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(19, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(58, 15);
            this.label17.TabIndex = 2;
            this.label17.Text = "Worker #:";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(36, 540);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(92, 30);
            this.button5.TabIndex = 8;
            this.button5.Text = "Start";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Start_Click);
            // 
            // pd_temp_folder
            // 
            this.pd_temp_folder.Location = new System.Drawing.Point(19, 101);
            this.pd_temp_folder.Name = "pd_temp_folder";
            this.pd_temp_folder.Size = new System.Drawing.Size(353, 23);
            this.pd_temp_folder.TabIndex = 14;
            // 
            // pd_lblElapsed
            // 
            this.pd_lblElapsed.Location = new System.Drawing.Point(67, 229);
            this.pd_lblElapsed.Name = "pd_lblElapsed";
            this.pd_lblElapsed.ReadOnly = true;
            this.pd_lblElapsed.Size = new System.Drawing.Size(287, 23);
            this.pd_lblElapsed.TabIndex = 16;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(97, 163);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(275, 23);
            this.textBox3.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 166);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 15);
            this.label15.TabIndex = 7;
            this.label15.Text = "Worker status:";
            // 
            // pd_temp_button
            // 
            this.pd_temp_button.Location = new System.Drawing.Point(124, 62);
            this.pd_temp_button.Name = "pd_temp_button";
            this.pd_temp_button.Size = new System.Drawing.Size(75, 33);
            this.pd_temp_button.TabIndex = 20;
            this.pd_temp_button.Text = "Broswer";
            this.pd_temp_button.UseVisualStyleBackColor = true;
            this.pd_temp_button.Click += new System.EventHandler(this.pd_temp_button_Click);
            // 
            // pd_workder_number
            // 
            this.pd_workder_number.FormattingEnabled = true;
            this.pd_workder_number.Items.AddRange(new object[] {
            "1",
            "2"});
            this.pd_workder_number.Location = new System.Drawing.Point(83, 19);
            this.pd_workder_number.Name = "pd_workder_number";
            this.pd_workder_number.Size = new System.Drawing.Size(121, 23);
            this.pd_workder_number.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Last Queue Check:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(19, 75);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 15);
            this.label14.TabIndex = 3;
            this.label14.Text = "Temp save folder";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(226, 535);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 35);
            this.button2.TabIndex = 8;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.stop_Click);
            // 
            // pd_last_check
            // 
            this.pd_last_check.Location = new System.Drawing.Point(117, 297);
            this.pd_last_check.Name = "pd_last_check";
            this.pd_last_check.Size = new System.Drawing.Size(262, 23);
            this.pd_last_check.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 232);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 15);
            this.label13.TabIndex = 6;
            this.label13.Text = "Timer:";
            // 
            // maxquant
            // 
            this.maxquant.Controls.Add(this.mq_start);
            this.maxquant.Controls.Add(this.mq_stop);
            this.maxquant.Controls.Add(this.mq_autostart);
            this.maxquant.Controls.Add(this.mq_lblElapsed);
            this.maxquant.Controls.Add(this.mq_exe_select);
            this.maxquant.Controls.Add(this.mq_temp_select);
            this.maxquant.Controls.Add(this.mq_lastupdate);
            this.maxquant.Controls.Add(this.mq_workernumber);
            this.maxquant.Controls.Add(this.mq_workerstatus);
            this.maxquant.Controls.Add(this.mq_exe_location);
            this.maxquant.Controls.Add(this.label9);
            this.maxquant.Controls.Add(this.mq_temp_folder);
            this.maxquant.Controls.Add(this.label4);
            this.maxquant.Controls.Add(this.label8);
            this.maxquant.Controls.Add(this.label10);
            this.maxquant.Controls.Add(this.label7);
            this.maxquant.Controls.Add(this.label6);
            this.maxquant.Location = new System.Drawing.Point(4, 24);
            this.maxquant.Name = "maxquant";
            this.maxquant.Padding = new System.Windows.Forms.Padding(3);
            this.maxquant.Size = new System.Drawing.Size(385, 682);
            this.maxquant.TabIndex = 1;
            this.maxquant.Text = "Maxquant";
            this.maxquant.UseVisualStyleBackColor = true;
            // 
            // mq_start
            // 
            this.mq_start.Location = new System.Drawing.Point(34, 531);
            this.mq_start.Name = "mq_start";
            this.mq_start.Size = new System.Drawing.Size(92, 30);
            this.mq_start.TabIndex = 26;
            this.mq_start.Text = "Start";
            this.mq_start.UseVisualStyleBackColor = true;
            this.mq_start.Click += new System.EventHandler(this.mq_start_Click_1);
            // 
            // mq_stop
            // 
            this.mq_stop.Location = new System.Drawing.Point(224, 526);
            this.mq_stop.Name = "mq_stop";
            this.mq_stop.Size = new System.Drawing.Size(115, 35);
            this.mq_stop.TabIndex = 27;
            this.mq_stop.Text = "Stop";
            this.mq_stop.UseVisualStyleBackColor = true;
            this.mq_stop.Click += new System.EventHandler(this.mq_stop_Click_1);
            // 
            // mq_autostart
            // 
            this.mq_autostart.AutoSize = true;
            this.mq_autostart.Location = new System.Drawing.Point(17, 459);
            this.mq_autostart.Name = "mq_autostart";
            this.mq_autostart.Size = new System.Drawing.Size(164, 19);
            this.mq_autostart.TabIndex = 25;
            this.mq_autostart.Text = "Auto start when app starts";
            this.mq_autostart.UseVisualStyleBackColor = true;
            // 
            // mq_exe_select
            // 
            this.mq_exe_select.Location = new System.Drawing.Point(151, 155);
            this.mq_exe_select.Margin = new System.Windows.Forms.Padding(2);
            this.mq_exe_select.Name = "mq_exe_select";
            this.mq_exe_select.Size = new System.Drawing.Size(50, 32);
            this.mq_exe_select.TabIndex = 21;
            this.mq_exe_select.Text = "File";
            this.mq_exe_select.UseVisualStyleBackColor = true;
            this.mq_exe_select.Click += new System.EventHandler(this.find_file_Click);
            // 
            // msfragger
            // 
            this.msfragger.Location = new System.Drawing.Point(4, 24);
            this.msfragger.Name = "msfragger";
            this.msfragger.Padding = new System.Windows.Forms.Padding(3);
            this.msfragger.Size = new System.Drawing.Size(385, 682);
            this.msfragger.TabIndex = 2;
            this.msfragger.Text = "Msfragger";
            this.msfragger.UseVisualStyleBackColor = true;
            // 
            // custom
            // 
            this.custom.Controls.Add(this.pd_batch_file);
            this.custom.Controls.Add(this.label16);
            this.custom.Controls.Add(this.pd_batch_button);
            this.custom.Location = new System.Drawing.Point(4, 24);
            this.custom.Name = "custom";
            this.custom.Padding = new System.Windows.Forms.Padding(3);
            this.custom.Size = new System.Drawing.Size(385, 682);
            this.custom.TabIndex = 4;
            this.custom.Text = "Custom";
            this.custom.UseVisualStyleBackColor = true;
            // 
            // pd_batch_file
            // 
            this.pd_batch_file.Location = new System.Drawing.Point(17, 348);
            this.pd_batch_file.Name = "pd_batch_file";
            this.pd_batch_file.Size = new System.Drawing.Size(353, 23);
            this.pd_batch_file.TabIndex = 23;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 320);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 15);
            this.label16.TabIndex = 22;
            this.label16.Text = "Batch File";
            // 
            // pd_batch_button
            // 
            this.pd_batch_button.Location = new System.Drawing.Point(94, 311);
            this.pd_batch_button.Margin = new System.Windows.Forms.Padding(2);
            this.pd_batch_button.Name = "pd_batch_button";
            this.pd_batch_button.Size = new System.Drawing.Size(50, 32);
            this.pd_batch_button.TabIndex = 24;
            this.pd_batch_button.Text = "File";
            this.pd_batch_button.UseVisualStyleBackColor = true;
            // 
            // remote
            // 
            this.remote.Location = new System.Drawing.Point(4, 24);
            this.remote.Name = "remote";
            this.remote.Padding = new System.Windows.Forms.Padding(3);
            this.remote.Size = new System.Drawing.Size(385, 682);
            this.remote.TabIndex = 5;
            this.remote.Text = "Remote";
            this.remote.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1304, 24);
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
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // Proteomics_Data_Processor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 782);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.output);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Proteomics_Data_Processor";
            this.Text = "Proteomics_Data_Processor V 0.1";
            this.tabControl.ResumeLayout(false);
            this.mainsettings.ResumeLayout(false);
            this.mainsettings.PerformLayout();
            this.pd.ResumeLayout(false);
            this.pd.PerformLayout();
            this.maxquant.ResumeLayout(false);
            this.maxquant.PerformLayout();
            this.custom.ResumeLayout(false);
            this.custom.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox mq_workerstatus;
        private System.Windows.Forms.TextBox mq_lastupdate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox mq_workernumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox mq_exe_location;
        private System.Windows.Forms.Button mq_temp_select;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Timer tmrClock;
        private System.Windows.Forms.TextBox mq_lblElapsed;
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox mq_temp_folder;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage mainsettings;
        private System.Windows.Forms.TabPage maxquant;
        private System.Windows.Forms.TabPage msfragger;
        private System.Windows.Forms.TabPage pd;
        private System.Windows.Forms.TabPage custom;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadingSettingsFromToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSettingsToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabPage remote;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox system_pwd;
        private System.Windows.Forms.TextBox system_username;
        private System.Windows.Forms.CheckBox mq_autostart;
        private System.Windows.Forms.TextBox workerip;
        private System.Windows.Forms.TextBox workername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox hostip;
        private System.Windows.Forms.Button mq_exe_select;
        private System.Windows.Forms.CheckBox pd_thread_autostart;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox pd_temp_folder;
        private System.Windows.Forms.TextBox pd_lblElapsed;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button pd_temp_button;
        private System.Windows.Forms.ComboBox pd_workder_number;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox pd_last_check;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox pd_batch_file;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button pd_batch_button;
        private System.Windows.Forms.CheckBox start_with_windows;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button mq_start;
        private System.Windows.Forms.Button mq_stop;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer mq_tmrClock;
    }
}

