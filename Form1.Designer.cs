
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
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label26 = new System.Windows.Forms.Label();
            this.version_number = new System.Windows.Forms.Label();
            this.custom = new System.Windows.Forms.TabPage();
            this.script_instructions = new System.Windows.Forms.RichTextBox();
            this.script = new System.Windows.Forms.RichTextBox();
            this.reset_to_default = new System.Windows.Forms.Button();
            this.pd = new System.Windows.Forms.TabPage();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.result_file = new System.Windows.Forms.TextBox();
            this.output_3 = new System.Windows.Forms.TextBox();
            this.output_2 = new System.Windows.Forms.TextBox();
            this.output_1 = new System.Windows.Forms.TextBox();
            this.process_temp_folder = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.temp_button = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
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
            this.menuStrip1.SuspendLayout();
            this.custom.SuspendLayout();
            this.pd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
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
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            this.helpToolStripMenuItem1.Click += new System.EventHandler(this.helpToolStripMenuItem1_Click);
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
            this.custom.Controls.Add(this.script_instructions);
            this.custom.Controls.Add(this.script);
            this.custom.Controls.Add(this.reset_to_default);
            this.custom.Location = new System.Drawing.Point(4, 24);
            this.custom.Name = "custom";
            this.custom.Padding = new System.Windows.Forms.Padding(3);
            this.custom.Size = new System.Drawing.Size(385, 682);
            this.custom.TabIndex = 4;
            this.custom.Text = "Processing Script";
            this.custom.UseVisualStyleBackColor = true;
            // 
            // script_instructions
            // 
            this.script_instructions.BackColor = System.Drawing.SystemColors.Info;
            this.script_instructions.Location = new System.Drawing.Point(3, 18);
            this.script_instructions.Name = "script_instructions";
            this.script_instructions.ReadOnly = true;
            this.script_instructions.Size = new System.Drawing.Size(376, 75);
            this.script_instructions.TabIndex = 1;
            this.script_instructions.Text = "Following command will be executed as a batch file， & can be used to connect mult" +
    "iple commands, must start with /c and limited to 8192 characters. Check help/git" +
    "hub wiki for detailed instructions ";
            // 
            // script
            // 
            this.script.Location = new System.Drawing.Point(3, 116);
            this.script.Name = "script";
            this.script.Size = new System.Drawing.Size(376, 496);
            this.script.TabIndex = 1;
            this.script.Text = "/k DiscovererDaemon.exe -c custom &&loop&& -a custom &&raw_file_name&& &&loop&&  " +
    "-r &&output&&.msf -b  - e custom ANY &&input_1&&;&&input_2&&";
            // 
            // reset_to_default
            // 
            this.reset_to_default.Location = new System.Drawing.Point(88, 629);
            this.reset_to_default.Name = "reset_to_default";
            this.reset_to_default.Size = new System.Drawing.Size(184, 34);
            this.reset_to_default.TabIndex = 0;
            this.reset_to_default.Text = "Reset to default";
            this.reset_to_default.UseVisualStyleBackColor = true;
            // 
            // pd
            // 
            this.pd.Controls.Add(this.numericUpDown4);
            this.pd.Controls.Add(this.numericUpDown2);
            this.pd.Controls.Add(this.label18);
            this.pd.Controls.Add(this.numericUpDown3);
            this.pd.Controls.Add(this.label10);
            this.pd.Controls.Add(this.label16);
            this.pd.Controls.Add(this.numericUpDown1);
            this.pd.Controls.Add(this.label9);
            this.pd.Controls.Add(this.result_file);
            this.pd.Controls.Add(this.output_3);
            this.pd.Controls.Add(this.output_2);
            this.pd.Controls.Add(this.output_1);
            this.pd.Controls.Add(this.process_temp_folder);
            this.pd.Controls.Add(this.label8);
            this.pd.Controls.Add(this.temp_button);
            this.pd.Controls.Add(this.label6);
            this.pd.Controls.Add(this.label7);
            this.pd.Controls.Add(this.label4);
            this.pd.Controls.Add(this.label14);
            this.pd.Location = new System.Drawing.Point(4, 24);
            this.pd.Name = "pd";
            this.pd.Padding = new System.Windows.Forms.Padding(3);
            this.pd.Size = new System.Drawing.Size(385, 682);
            this.pd.TabIndex = 3;
            this.pd.Text = "Input_output";
            this.pd.UseVisualStyleBackColor = true;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(171, 552);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(100, 23);
            this.numericUpDown4.TabIndex = 32;
            this.numericUpDown4.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(172, 470);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(100, 23);
            this.numericUpDown2.TabIndex = 32;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 554);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(141, 15);
            this.label18.TabIndex = 31;
            this.label18.Text = "output_QC_number_4 [n]";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(171, 508);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(100, 23);
            this.numericUpDown3.TabIndex = 32;
            this.numericUpDown3.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 472);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 15);
            this.label10.TabIndex = 31;
            this.label10.Text = "output_QC_number_2 [n]";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 510);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(141, 15);
            this.label16.TabIndex = 31;
            this.label16.Text = "output_QC_number_3 [n]";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(172, 426);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(100, 23);
            this.numericUpDown1.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 428);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(141, 15);
            this.label9.TabIndex = 31;
            this.label9.Text = "output_QC_number_1 [n]";
            // 
            // result_file
            // 
            this.result_file.Location = new System.Drawing.Point(3, 357);
            this.result_file.Name = "result_file";
            this.result_file.Size = new System.Drawing.Size(353, 23);
            this.result_file.TabIndex = 14;
            // 
            // output_3
            // 
            this.output_3.Location = new System.Drawing.Point(8, 291);
            this.output_3.Name = "output_3";
            this.output_3.Size = new System.Drawing.Size(353, 23);
            this.output_3.TabIndex = 14;
            // 
            // output_2
            // 
            this.output_2.Location = new System.Drawing.Point(8, 224);
            this.output_2.Name = "output_2";
            this.output_2.Size = new System.Drawing.Size(353, 23);
            this.output_2.TabIndex = 14;
            // 
            // output_1
            // 
            this.output_1.Location = new System.Drawing.Point(8, 151);
            this.output_1.Name = "output_1";
            this.output_1.Size = new System.Drawing.Size(353, 23);
            this.output_1.TabIndex = 14;
            // 
            // process_temp_folder
            // 
            this.process_temp_folder.Location = new System.Drawing.Point(8, 81);
            this.process_temp_folder.Name = "process_temp_folder";
            this.process_temp_folder.Size = new System.Drawing.Size(353, 23);
            this.process_temp_folder.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 327);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 15);
            this.label8.TabIndex = 3;
            this.label8.Text = "QC parameter result file";
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(179, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Output 3 full path with file name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "Output 2 full path with file name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Output 1 full path with file name";
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
            this.Manual_start.Click += new System.EventHandler(this.Manual_start_Click);
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
            this.Manual_stop.Click += new System.EventHandler(this.Manual_stop_Click);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Proteomics_Data_Processor";
            this.Text = "Proteomics_Data_Processor V1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.custom.ResumeLayout(false);
            this.pd.ResumeLayout(false);
            this.pd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
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
        private System.Windows.Forms.Button reset_to_default;
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
        private System.Windows.Forms.RichTextBox script;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.TextBox output_3;
        private System.Windows.Forms.TextBox output_2;
        private System.Windows.Forms.TextBox output_1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox script_instructions;
        private System.Windows.Forms.TextBox result_file;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label9;
    }
}

