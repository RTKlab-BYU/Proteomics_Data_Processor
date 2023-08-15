﻿
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Proteomics_Data_Processor));
            folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            tmrClock = new System.Windows.Forms.Timer(components);
            output = new System.Windows.Forms.RichTextBox();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            loadingSettingsFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveSettingsToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            label26 = new System.Windows.Forms.Label();
            version_number = new System.Windows.Forms.Label();
            custom = new System.Windows.Forms.TabPage();
            script_instructions = new System.Windows.Forms.RichTextBox();
            script = new System.Windows.Forms.RichTextBox();
            reset_to_default = new System.Windows.Forms.Button();
            pd = new System.Windows.Forms.TabPage();
            label16 = new System.Windows.Forms.Label();
            output_6 = new System.Windows.Forms.TextBox();
            output_5 = new System.Windows.Forms.TextBox();
            output_4 = new System.Windows.Forms.TextBox();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            output_3 = new System.Windows.Forms.TextBox();
            output_2 = new System.Windows.Forms.TextBox();
            output_1 = new System.Windows.Forms.TextBox();
            process_temp_folder = new System.Windows.Forms.TextBox();
            temp_button = new System.Windows.Forms.Button();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            mainsettings = new System.Windows.Forms.TabPage();
            parallel_processing = new System.Windows.Forms.CheckBox();
            process_thread_autostart = new System.Windows.Forms.CheckBox();
            Manual_start = new System.Windows.Forms.Button();
            lblElapsed = new System.Windows.Forms.TextBox();
            textBox3 = new System.Windows.Forms.TextBox();
            last_check = new System.Windows.Forms.TextBox();
            label15 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            Manual_stop = new System.Windows.Forms.Button();
            label13 = new System.Windows.Forms.Label();
            process_app_selector = new System.Windows.Forms.ComboBox();
            Check_server = new System.Windows.Forms.Button();
            label28 = new System.Windows.Forms.Label();
            workder_number = new System.Windows.Forms.NumericUpDown();
            label17 = new System.Windows.Forms.Label();
            workerip = new System.Windows.Forms.TextBox();
            workername = new System.Windows.Forms.TextBox();
            hostip = new System.Windows.Forms.TextBox();
            system_username = new System.Windows.Forms.TextBox();
            start_with_windows = new System.Windows.Forms.CheckBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            system_pwd = new System.Windows.Forms.TextBox();
            tabControl = new System.Windows.Forms.TabControl();
            menuStrip1.SuspendLayout();
            custom.SuspendLayout();
            pd.SuspendLayout();
            mainsettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)workder_number).BeginInit();
            tabControl.SuspendLayout();
            SuspendLayout();
            // 
            // tmrClock
            // 
            tmrClock.Tick += tmrClock_Tick;
            // 
            // output
            // 
            output.BackColor = System.Drawing.SystemColors.Info;
            output.Location = new System.Drawing.Point(395, 55);
            output.Name = "output";
            output.ReadOnly = true;
            output.Size = new System.Drawing.Size(390, 696);
            output.TabIndex = 10;
            output.Text = "";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, toolsToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(800, 24);
            menuStrip1.TabIndex = 26;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { loadingSettingsFromToolStripMenuItem, saveSettingsToToolStripMenuItem, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // loadingSettingsFromToolStripMenuItem
            // 
            loadingSettingsFromToolStripMenuItem.Name = "loadingSettingsFromToolStripMenuItem";
            loadingSettingsFromToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            loadingSettingsFromToolStripMenuItem.Text = "Loading settings  from";
            loadingSettingsFromToolStripMenuItem.Click += loadingSettingsFromToolStripMenuItem_Click;
            // 
            // saveSettingsToToolStripMenuItem
            // 
            saveSettingsToToolStripMenuItem.Name = "saveSettingsToToolStripMenuItem";
            saveSettingsToToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            saveSettingsToToolStripMenuItem.Text = "Save settings to";
            saveSettingsToToolStripMenuItem.Click += saveSettingsToToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            exitToolStripMenuItem.Text = "Exit";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { helpToolStripMenuItem1 });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            helpToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            helpToolStripMenuItem1.Text = "Help";
            helpToolStripMenuItem1.Click += helpToolStripMenuItem1_Click;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new System.Drawing.Point(395, 758);
            label26.Name = "label26";
            label26.Size = new System.Drawing.Size(138, 15);
            label26.TabIndex = 27;
            label26.Text = "Current Version Number:";
            // 
            // version_number
            // 
            version_number.AutoSize = true;
            version_number.Location = new System.Drawing.Point(551, 758);
            version_number.Name = "version_number";
            version_number.Size = new System.Drawing.Size(0, 15);
            version_number.TabIndex = 27;
            // 
            // custom
            // 
            custom.Controls.Add(script_instructions);
            custom.Controls.Add(script);
            custom.Controls.Add(reset_to_default);
            custom.Location = new System.Drawing.Point(4, 24);
            custom.Name = "custom";
            custom.Padding = new System.Windows.Forms.Padding(3);
            custom.Size = new System.Drawing.Size(385, 682);
            custom.TabIndex = 4;
            custom.Text = "Processing Script";
            custom.UseVisualStyleBackColor = true;
            // 
            // script_instructions
            // 
            script_instructions.BackColor = System.Drawing.SystemColors.Info;
            script_instructions.Location = new System.Drawing.Point(3, 18);
            script_instructions.Name = "script_instructions";
            script_instructions.ReadOnly = true;
            script_instructions.Size = new System.Drawing.Size(376, 75);
            script_instructions.TabIndex = 1;
            script_instructions.Text = "Following command will be executed as a batch file， & can be used to connect multiple commands, must start with /c and limited to 8192 characters. Check help/github wiki for detailed instructions ";
            // 
            // script
            // 
            script.Location = new System.Drawing.Point(3, 116);
            script.Name = "script";
            script.Size = new System.Drawing.Size(376, 496);
            script.TabIndex = 1;
            script.Text = "/k DiscovererDaemon.exe -c custom &&loop&& -a custom &&raw_file_name&& &&loop&&  -r &&output&&.msf -b  - e custom ANY &&input_1&&;&&input_2&&";
            // 
            // reset_to_default
            // 
            reset_to_default.Location = new System.Drawing.Point(88, 629);
            reset_to_default.Name = "reset_to_default";
            reset_to_default.Size = new System.Drawing.Size(184, 34);
            reset_to_default.TabIndex = 0;
            reset_to_default.Text = "Reset to default";
            reset_to_default.UseVisualStyleBackColor = true;
            // 
            // pd
            // 
            pd.Controls.Add(label16);
            pd.Controls.Add(output_6);
            pd.Controls.Add(output_5);
            pd.Controls.Add(output_4);
            pd.Controls.Add(label8);
            pd.Controls.Add(label9);
            pd.Controls.Add(label10);
            pd.Controls.Add(output_3);
            pd.Controls.Add(output_2);
            pd.Controls.Add(output_1);
            pd.Controls.Add(process_temp_folder);
            pd.Controls.Add(temp_button);
            pd.Controls.Add(label6);
            pd.Controls.Add(label7);
            pd.Controls.Add(label4);
            pd.Controls.Add(label14);
            pd.Location = new System.Drawing.Point(4, 24);
            pd.Name = "pd";
            pd.Padding = new System.Windows.Forms.Padding(3);
            pd.Size = new System.Drawing.Size(385, 682);
            pd.TabIndex = 3;
            pd.Text = "Input_output";
            pd.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label16.Location = new System.Drawing.Point(8, 134);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(330, 15);
            label16.TabIndex = 27;
            label16.Text = "Output files to be uploaded(can leave empty if less than 6)";
            // 
            // output_6
            // 
            output_6.Location = new System.Drawing.Point(6, 537);
            output_6.Name = "output_6";
            output_6.Size = new System.Drawing.Size(353, 23);
            output_6.TabIndex = 24;
            // 
            // output_5
            // 
            output_5.Location = new System.Drawing.Point(6, 470);
            output_5.Name = "output_5";
            output_5.Size = new System.Drawing.Size(353, 23);
            output_5.TabIndex = 25;
            // 
            // output_4
            // 
            output_4.Location = new System.Drawing.Point(6, 397);
            output_4.Name = "output_4";
            output_4.Size = new System.Drawing.Size(353, 23);
            output_4.TabIndex = 26;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(6, 507);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(54, 15);
            label8.TabIndex = 21;
            label8.Text = "Output 6";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(6, 440);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(54, 15);
            label9.TabIndex = 22;
            label9.Text = "Output 5";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(6, 368);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(54, 15);
            label10.TabIndex = 23;
            label10.Text = "Output 4";
            // 
            // output_3
            // 
            output_3.Location = new System.Drawing.Point(6, 332);
            output_3.Name = "output_3";
            output_3.Size = new System.Drawing.Size(353, 23);
            output_3.TabIndex = 14;
            // 
            // output_2
            // 
            output_2.Location = new System.Drawing.Point(6, 265);
            output_2.Name = "output_2";
            output_2.Size = new System.Drawing.Size(353, 23);
            output_2.TabIndex = 14;
            // 
            // output_1
            // 
            output_1.Location = new System.Drawing.Point(6, 192);
            output_1.Name = "output_1";
            output_1.Size = new System.Drawing.Size(353, 23);
            output_1.TabIndex = 14;
            // 
            // process_temp_folder
            // 
            process_temp_folder.Location = new System.Drawing.Point(8, 81);
            process_temp_folder.Name = "process_temp_folder";
            process_temp_folder.Size = new System.Drawing.Size(353, 23);
            process_temp_folder.TabIndex = 14;
            // 
            // temp_button
            // 
            temp_button.Location = new System.Drawing.Point(135, 27);
            temp_button.Name = "temp_button";
            temp_button.Size = new System.Drawing.Size(75, 33);
            temp_button.TabIndex = 20;
            temp_button.Text = "Broswer";
            temp_button.UseVisualStyleBackColor = true;
            temp_button.Click += temp_button_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 302);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(54, 15);
            label6.TabIndex = 3;
            label6.Text = "Output 3";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(6, 235);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(54, 15);
            label7.TabIndex = 3;
            label7.Text = "Output 2";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(6, 163);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(279, 15);
            label4.TabIndex = 3;
            label4.Text = "Output 1 full path with file name (relatevie to temp)";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(8, 36);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(96, 15);
            label14.TabIndex = 3;
            label14.Text = "Temp save folder";
            // 
            // mainsettings
            // 
            mainsettings.Controls.Add(parallel_processing);
            mainsettings.Controls.Add(process_thread_autostart);
            mainsettings.Controls.Add(Manual_start);
            mainsettings.Controls.Add(lblElapsed);
            mainsettings.Controls.Add(textBox3);
            mainsettings.Controls.Add(last_check);
            mainsettings.Controls.Add(label15);
            mainsettings.Controls.Add(label5);
            mainsettings.Controls.Add(Manual_stop);
            mainsettings.Controls.Add(label13);
            mainsettings.Controls.Add(process_app_selector);
            mainsettings.Controls.Add(Check_server);
            mainsettings.Controls.Add(label28);
            mainsettings.Controls.Add(workder_number);
            mainsettings.Controls.Add(label17);
            mainsettings.Controls.Add(workerip);
            mainsettings.Controls.Add(workername);
            mainsettings.Controls.Add(hostip);
            mainsettings.Controls.Add(system_username);
            mainsettings.Controls.Add(start_with_windows);
            mainsettings.Controls.Add(label2);
            mainsettings.Controls.Add(label3);
            mainsettings.Controls.Add(label1);
            mainsettings.Controls.Add(label12);
            mainsettings.Controls.Add(label11);
            mainsettings.Controls.Add(system_pwd);
            mainsettings.Location = new System.Drawing.Point(4, 24);
            mainsettings.Name = "mainsettings";
            mainsettings.Padding = new System.Windows.Forms.Padding(3);
            mainsettings.Size = new System.Drawing.Size(385, 682);
            mainsettings.TabIndex = 0;
            mainsettings.Text = "Main Settings";
            mainsettings.UseVisualStyleBackColor = true;
            // 
            // parallel_processing
            // 
            parallel_processing.AutoSize = true;
            parallel_processing.Location = new System.Drawing.Point(6, 587);
            parallel_processing.Name = "parallel_processing";
            parallel_processing.Size = new System.Drawing.Size(290, 19);
            parallel_processing.TabIndex = 43;
            parallel_processing.Text = "Ignore task with start time (for parallel processing)";
            parallel_processing.UseVisualStyleBackColor = true;
            // 
            // process_thread_autostart
            // 
            process_thread_autostart.AutoSize = true;
            process_thread_autostart.Location = new System.Drawing.Point(8, 562);
            process_thread_autostart.Name = "process_thread_autostart";
            process_thread_autostart.Size = new System.Drawing.Size(290, 19);
            process_thread_autostart.TabIndex = 42;
            process_thread_autostart.Text = "Start process when app starts (save this to Default)";
            process_thread_autostart.UseVisualStyleBackColor = true;
            // 
            // Manual_start
            // 
            Manual_start.Location = new System.Drawing.Point(17, 626);
            Manual_start.Name = "Manual_start";
            Manual_start.Size = new System.Drawing.Size(92, 30);
            Manual_start.TabIndex = 37;
            Manual_start.Text = "Start";
            Manual_start.UseVisualStyleBackColor = true;
            Manual_start.Click += Manual_start_Click;
            // 
            // lblElapsed
            // 
            lblElapsed.Location = new System.Drawing.Point(92, 447);
            lblElapsed.Name = "lblElapsed";
            lblElapsed.ReadOnly = true;
            lblElapsed.Size = new System.Drawing.Size(276, 23);
            lblElapsed.TabIndex = 40;
            // 
            // textBox3
            // 
            textBox3.Location = new System.Drawing.Point(91, 411);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new System.Drawing.Size(277, 23);
            textBox3.TabIndex = 39;
            // 
            // last_check
            // 
            last_check.Enabled = false;
            last_check.Location = new System.Drawing.Point(92, 499);
            last_check.Name = "last_check";
            last_check.ReadOnly = true;
            last_check.Size = new System.Drawing.Size(275, 23);
            last_check.TabIndex = 41;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(3, 414);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(82, 15);
            label15.TabIndex = 36;
            label15.Text = "Worker status:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(3, 499);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(67, 15);
            label5.TabIndex = 34;
            label5.Text = "Last Check:";
            // 
            // Manual_stop
            // 
            Manual_stop.Location = new System.Drawing.Point(188, 624);
            Manual_stop.Name = "Manual_stop";
            Manual_stop.Size = new System.Drawing.Size(115, 35);
            Manual_stop.TabIndex = 38;
            Manual_stop.Text = "Stop";
            Manual_stop.UseVisualStyleBackColor = true;
            Manual_stop.Click += Manual_stop_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(3, 455);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(40, 15);
            label13.TabIndex = 35;
            label13.Text = "Timer:";
            // 
            // process_app_selector
            // 
            process_app_selector.FormattingEnabled = true;
            process_app_selector.Location = new System.Drawing.Point(90, 271);
            process_app_selector.Name = "process_app_selector";
            process_app_selector.Size = new System.Drawing.Size(277, 23);
            process_app_selector.TabIndex = 33;
            // 
            // Check_server
            // 
            Check_server.Location = new System.Drawing.Point(146, 232);
            Check_server.Name = "Check_server";
            Check_server.Size = new System.Drawing.Size(195, 33);
            Check_server.TabIndex = 32;
            Check_server.Text = "Pull list from Server";
            Check_server.UseVisualStyleBackColor = true;
            Check_server.Click += Check_server_Click_1;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new System.Drawing.Point(3, 241);
            label28.Name = "label28";
            label28.Size = new System.Drawing.Size(115, 15);
            label28.TabIndex = 31;
            label28.Text = "Choose Process App";
            // 
            // workder_number
            // 
            workder_number.Location = new System.Drawing.Point(155, 195);
            workder_number.Name = "workder_number";
            workder_number.Size = new System.Drawing.Size(100, 23);
            workder_number.TabIndex = 30;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(3, 203);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(58, 15);
            label17.TabIndex = 29;
            label17.Text = "Worker #:";
            // 
            // workerip
            // 
            workerip.Location = new System.Drawing.Point(90, 360);
            workerip.Name = "workerip";
            workerip.Size = new System.Drawing.Size(277, 23);
            workerip.TabIndex = 17;
            // 
            // workername
            // 
            workername.Location = new System.Drawing.Point(91, 325);
            workername.Name = "workername";
            workername.Size = new System.Drawing.Size(277, 23);
            workername.TabIndex = 16;
            // 
            // hostip
            // 
            hostip.Location = new System.Drawing.Point(124, 65);
            hostip.Name = "hostip";
            hostip.Size = new System.Drawing.Size(243, 23);
            hostip.TabIndex = 13;
            // 
            // system_username
            // 
            system_username.Location = new System.Drawing.Point(92, 111);
            system_username.Name = "system_username";
            system_username.Size = new System.Drawing.Size(275, 23);
            system_username.TabIndex = 0;
            // 
            // start_with_windows
            // 
            start_with_windows.AutoSize = true;
            start_with_windows.Location = new System.Drawing.Point(8, 537);
            start_with_windows.Name = "start_with_windows";
            start_with_windows.Size = new System.Drawing.Size(177, 19);
            start_with_windows.TabIndex = 26;
            start_with_windows.Text = "Start app with Windows start";
            start_with_windows.UseVisualStyleBackColor = true;
            start_with_windows.CheckedChanged += start_with_windows_CheckedChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 328);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(79, 15);
            label2.TabIndex = 14;
            label2.Text = "Woker Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 368);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(61, 15);
            label3.TabIndex = 15;
            label3.Text = "Worker IP:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 68);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(115, 15);
            label1.TabIndex = 12;
            label1.Text = "Server IP/Hostname:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(3, 161);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(57, 15);
            label12.TabIndex = 1;
            label12.Text = "Password";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(3, 114);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(59, 15);
            label11.TabIndex = 1;
            label11.Text = "username";
            // 
            // system_pwd
            // 
            system_pwd.Location = new System.Drawing.Point(92, 158);
            system_pwd.Name = "system_pwd";
            system_pwd.Size = new System.Drawing.Size(275, 23);
            system_pwd.TabIndex = 0;
            system_pwd.UseSystemPasswordChar = true;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(mainsettings);
            tabControl.Controls.Add(pd);
            tabControl.Controls.Add(custom);
            tabControl.Location = new System.Drawing.Point(0, 41);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(393, 710);
            tabControl.TabIndex = 25;
            // 
            // Proteomics_Data_Processor
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 782);
            Controls.Add(version_number);
            Controls.Add(label26);
            Controls.Add(tabControl);
            Controls.Add(output);
            Controls.Add(menuStrip1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Proteomics_Data_Processor";
            Text = "Omics Data Processor";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            custom.ResumeLayout(false);
            pd.ResumeLayout(false);
            pd.PerformLayout();
            mainsettings.ResumeLayout(false);
            mainsettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)workder_number).EndInit();
            tabControl.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.TextBox output_6;
        private System.Windows.Forms.TextBox output_5;
        private System.Windows.Forms.TextBox output_4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox parallel_processing;
    }
}

