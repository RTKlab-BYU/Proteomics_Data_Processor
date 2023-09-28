using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Win32;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Proteomics_Data_Processor
{
    public partial class Proteomics_Data_Processor : Form
    {
        BackgroundWorker process_backgroundWorker = new BackgroundWorker();

        string AppName = "Proteomics_Data_Processor";

        public DateTime StartTime { get; private set; }

        public Proteomics_Data_Processor()
        {
            InitializeComponent();
            workerip.Text = GetIPAddress();
            hostip.Text = "http://127.0.0.1:8000/files/api/";
            system_username.Text = "search_worker";
            system_pwd.Text = "searchadmin";
            workername.Text = "worker_" + Gethostname();
            version_number.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();

            process_temp_folder.Text = "c:\\temp";
            workder_number.Text = "1";
            process_backgroundWorker.DoWork += process_backgroundWorker_DoWork;
            process_backgroundWorker.ProgressChanged += process_backgroundWorker_ProgressChanged;
            process_backgroundWorker.RunWorkerCompleted += process_backgroundWorker_RunWorkerCompleted;  //Tell the user how the process went
            process_backgroundWorker.WorkerReportsProgress = true;
            process_backgroundWorker.WorkerSupportsCancellation = true; //Allow for the process to be cancelled



            // Automatically load setting if Default.xml exist in the same folder, and start the process if it is checked.
            if (File.Exists("Default.xml"))
            {
                loadingsettings("Default.xml");

                if (process_thread_autostart.Checked)
                {

                    SaveSettings();

                    if (!process_backgroundWorker.IsBusy)
                    {
                        process_backgroundWorker.RunWorkerAsync();
                        output.AppendText(Environment.NewLine + DateTime.Now + " Started Process Worker ");



                    }
                }

            }
        }


        //General purpose methods



        /// <summary>
        /// Method <c>loadingSettingsFromToolStripMenuItem_Click</c> loads settings from a saved xml file using loadingsettings method.
        /// </summary>

        private void loadingSettingsFromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Browse xml Files",
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "xml",
                Filter = "Processor Configure files (*.xml)|*.xml|All files (*.*)|*.*",
                RestoreDirectory = true,
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loadingsettings(openFileDialog1.FileName);
            }
        }

        /// <summary>
        /// Method <c>loadingsettings</c> populates UI element from a saved xml file.
        ///   </summary>

        private void loadingsettings(string filename)
        {

            SettingsProvider.setfilename(filename);
            TabControl.TabPageCollection pages = tabControl.TabPages;
            foreach (TabPage page in pages)
            {
                foreach (Control control in page.Controls)
                {
                    if (control is TextBox)
                    {
                        if (control.Name != "system_pwd")
                        {
                            control.Text = SettingsProvider.GetValue(page.Name, control.Name, null);
                            ((TextBox)control).Text = SettingsProvider.GetValue(page.Name, control.Name, null);
                        }
                    }
                    else if (control is RichTextBox)
                    {
                        ((RichTextBox)control).Text = SettingsProvider.GetValue(page.Name, control.Name, null);
                    }
                    else if (control is CheckBox)
                    {
                        ((CheckBox)control).Checked = Convert.ToBoolean(SettingsProvider.GetValue(page.Name, control.Name, null));
                    }
                    else if (control is ComboBox)
                    {
                        ((ComboBox)control).Text = SettingsProvider.GetValue(page.Name, control.Name, null);
                    }
                    else if (control is NumericUpDown)
                    {
                        ((NumericUpDown)control).Text = SettingsProvider.GetValue(page.Name, control.Name, null);
                    }
                }

            }
        }

        /// <summary>
        /// Method <c>saveSettingsToToolStripMenuItem_Click</c> saves all the UI setting to application settings.
        /// </summary>
        ///
        private void saveSettingsToToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Uploader Configure File|*.xml";
            saveFileDialog1.Title = "Save a Configure File";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SettingsProvider.setfilename(saveFileDialog1.FileName);
                TabControl.TabPageCollection pages = tabControl.TabPages;
                foreach (TabPage page in pages)
                {
                    foreach (Control control in page.Controls)
                    {
                        if (control is TextBox)
                        {
                            if (control.Name != "system_pwd")
                                SettingsProvider.SetValue(page.Name, control.Name, control.Text);
                        }
                        else if (control is CheckBox)
                        {
                            SettingsProvider.SetValue(page.Name, control.Name, ((CheckBox)control).Checked.ToString());

                        }
                        else if (control is RichTextBox)
                        {
                            SettingsProvider.SetValue(page.Name, control.Name, control.Text);
                        }
                        else if (control is ComboBox)
                        {
                            SettingsProvider.SetValue(page.Name, control.Name, ((ComboBox)control).Text);
                        }
                        else if (control is NumericUpDown)
                        {
                            SettingsProvider.SetValue(page.Name, control.Name, ((NumericUpDown)control).Text);
                        }

                    }

                }
            }
        }
        /// <summary>
        /// Method <c>SaveSettings</c> saves UI settings to application setting (session) and then these can be accessed by different threads.
        /// </summary>
        private void SaveSettings() // 
        {
            Properties.Settings.Default.hostip = hostip.Text;
            Properties.Settings.Default.workerip = workerip.Text;
            Properties.Settings.Default.system_user = system_username.Text;
            Properties.Settings.Default.system_pwd = system_pwd.Text;
            Properties.Settings.Default.workername = workername.Text;
            Properties.Settings.Default.process_setting = process_app_selector.Text;

            Properties.Settings.Default.workernumber = workder_number.Text;
            Properties.Settings.Default.temp_folder = process_temp_folder.Text;
            Properties.Settings.Default.script = script.Text;
            Properties.Settings.Default.para_process = parallel_processing.Checked;
        }






        /// <summary>
        /// Method <c>start_with_windows_CheckedChanged</c> allows for app to be automated started as windows boots.
        /// </summary>
        private void start_with_windows_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (start_with_windows.Checked)
                rk.SetValue(AppName, Application.ExecutablePath);
            else
                rk.DeleteValue(AppName, false);
        }


        /// <summary>
        /// Method <c>GetIPAddress</c> gets ip address for the worker to be reported to the server.
        /// </summary>
        /// <returns>ip4 address or 1.1.1.1 if failed</returns>
        private string GetIPAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
                return "1.1.1.1";
            }
            catch (Exception ex)
            {
                output.AppendText(Environment.NewLine + DateTime.Now + " get ip address run with error" + ex.Message);
                return "1.1.1.1";
            }
        }

        /// <summary>
        /// Method <c>CleanFolder</c> deletes all files and folders in the folder.
        /// </summary>
        public static void CleanFolder(string foldername)
        {
            // delelte all the files to save space
            DirectoryInfo di = new DirectoryInfo(foldername); foreach (FileInfo file in di.GetFiles())
                try
                {
                    file.Delete();

                }
                catch (Exception ex)
                {
                    Thread _message_thread = new Thread(() => MessageBox.Show(Environment.NewLine + DateTime.Now + "Unable to delete file" + ex.Message));
                    if (!_message_thread.IsAlive)
                        _message_thread.Start();
                }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                try
                {
                    dir.Delete(true);
                }
                catch (Exception ex)
                {
                    Thread _message_thread = new Thread(() => MessageBox.Show(Environment.NewLine + DateTime.Now + "Unable to delete folder" + ex.Message));
                    if (!_message_thread.IsAlive)
                        _message_thread.Start();
                }
            }

        }





        /// <summary>
        /// Method <c>Gethostname</c> gets computer hostname for reporting to server.
        /// </summary>
        /// <returns>hostname as string</returns>
        private string Gethostname()
        {
            StringBuilder sb = new StringBuilder();
            String strHostName = string.Empty;
            strHostName = Dns.GetHostName();
            return strHostName.ToString();
        }





        /// <summary>
        /// Method <c>process_backgroundWorker_DoWork</c> main background worker for obtain task, and process them.
        /// </summary>

        private void process_backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            List<string> rawfilelist;
            int queuepk;
            string intput_1, intput_2, intput_3, outpu_file;
            bool keep_result;

            while (true)
            {
                if (ProcessWorkerPing())
                {
                    (queuepk, rawfilelist, intput_1, intput_2, intput_3, outpu_file, keep_result) = GetJobs();


                    if (queuepk != 0)
                    {
                        process_backgroundWorker.ReportProgress(10, $" running Process queue {queuepk}");
                        ReportStart(queuepk);
                        processStart(rawfilelist, intput_1, intput_2, intput_3, outpu_file);
                        UploadResult(queuepk, outpu_file, keep_result);
                        process_backgroundWorker.ReportProgress(99, $" finished running Process queue {queuepk}");

                    }



                    if (process_backgroundWorker.CancellationPending)
                    {
                        e.Cancel = true;
                        process_backgroundWorker.ReportProgress(0);
                        return;
                    }


                };



                Thread.Sleep(30000);

            }

        }


        /// <summary>
        /// Method <c>process_backgroundWorker_ProgressChanged</c> process progress changed and report to UI.
        /// </summary>
        private void process_backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            DateTime now = DateTime.Now;
            last_check.Text = now.ToString();
            if (e.UserState as String == "No Response from Server")
            {
                output.AppendText(Environment.NewLine + DateTime.Now + " No Response from Server.");

            }
            if (e.ProgressPercentage == 10)
            {

                tmrClock.Enabled = !tmrClock.Enabled;
                output.AppendText(Environment.NewLine + DateTime.Now + " A new analysis started, " + e.UserState as String);
                StartTime = DateTime.Now;

            }

            if (e.ProgressPercentage == 99)
            {
                tmrClock.Enabled = !tmrClock.Enabled;
                output.AppendText(Environment.NewLine + DateTime.Now + e.UserState);
            }

        }
        /// <summary>
        /// Method <c>process_backgroundWorker_RunWorkerCompleted</c> process finished and report to UI.
        /// </summary>
        private void process_backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                output.AppendText(Environment.NewLine + DateTime.Now + " Processing was cancelled");
            }
            else if (e.Error != null)
            {
                output.AppendText(Environment.NewLine + DateTime.Now + " There was an error running the process. The thread aborted");
            }
            else
            {
                output.AppendText(Environment.NewLine + DateTime.Now + " Process was completed");
            }
        }



        /// <summary>
        /// Method <c>tmrClock_Tick</c> Display the new elapsed time after a task starts before it finishes.
        /// </summary>
        private void tmrClock_Tick(object sender, EventArgs e)
        {

            TimeSpan elapsed = DateTime.Now - StartTime;

            // Start with the days if greater than 0.
            string text = "";
            if (elapsed.Days > 0)
                text += elapsed.Days.ToString() + ".";

            // Convert milliseconds into tenths of seconds.
            int tenths = elapsed.Milliseconds / 100;

            // Compose the rest of the elapsed time.
            text +=
                elapsed.Hours.ToString("00") + ":" +
                elapsed.Minutes.ToString("00") + ":" +
                elapsed.Seconds.ToString("00") + "." +
                tenths.ToString("0");

            lblElapsed.Text = text;


        }





        /// <summary>
        /// Method <c>ProcessWorkerPing</c> updates worker status to the server.
        /// </summary>
        /// <returns>Boolean</returns>
        ///
        private Boolean ProcessWorkerPing()
        {
            //check if selected proper process
            int app_index;
            try
            {
                app_index = int.Parse(Properties.Settings.Default.process_setting.Split('_')[0]);

            }
            catch (Exception e)
            {
                MessageBox.Show($"Please select valid processor name. Exception: {e.Message}");

                return false;

            }

            DateTime now = DateTime.Now;
            var client = new RestClient(Properties.Settings.Default.hostip);
            // check if worker number exist

            client.Authenticator = new HttpBasicAuthenticator(Properties.Settings.Default.system_user, Properties.Settings.Default.system_pwd);
            var request = new RestRequest("/WorkerStatus/" + Properties.Settings.Default.workernumber + "/", Method.Get);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "application/json");
            var response = client.Execute(request);

            if (response.Content is null)
            {
                process_backgroundWorker.ReportProgress(0, "No Response from Server");
                return false;
            }
            else
            {
                if (response.Content.Contains("Not found"))
                {
                    request = new RestRequest("/WorkerStatus/", Method.Post);
                    request.AddHeader("cache-control", "no-cache");
                    request.AddHeader("Accept", "application/json");
                    response = client.Execute(request);
                    MessageBox.Show(response.Content);
                }
                else
                {
                    request = new RestRequest("/WorkerStatus/" + Properties.Settings.Default.workernumber + "/", Method.Patch);
                    request.AddHeader("cache-control", "no-cache");
                    request.AddHeader("Accept", "application/json");
                    request.AddParameter("worker_name", Properties.Settings.Default.workername);
                    request.AddParameter("worker_ip", Properties.Settings.Default.workerip);
                    request.AddParameter("last_update", now.ToLocalTime());
                    request.AddParameter("processing_app", app_index);
                    response = client.Execute(request);

                }


                if (response.ResponseStatus == ResponseStatus.Completed)
                {
                    process_backgroundWorker.ReportProgress(0, "Idle");
                    return true;



                }
                else

                {
                    process_backgroundWorker.ReportProgress(0, "No Response from Server");
                    process_backgroundWorker.ReportProgress(0, "Idle");
                    return false;

                }

            }
        }

        /// <summary>
        /// Method <c>UploadResult</c> Upload output files to the server .
        /// </summary>
        /// <param name="queuepk">the analysis queue pk.</param>
        /// <param name="analysis_name">analysis name (not used).</param>
        /// <param name="keep_result">Whether keep the full result (not used)</param>

        private void UploadResult(int queuepk, string analysis_name, bool keep_result)
        {
            string output_file_1 = "", output_file_2 = "", output_file_3 = "", output_file_4 = "", output_file_5 = "", output_file_6 = "";
            if (output_1.Text != "")
            { output_file_1 = process_temp_folder.Text + $"\\{output_1.Text}"; }
            if (output_2.Text != "")
            { output_file_2 = process_temp_folder.Text + $"\\{output_2.Text}"; }
            if (output_3.Text != "")
            { output_file_3 = process_temp_folder.Text + $"\\{output_3.Text}"; }
            if (output_4.Text != "")
            { output_file_4 = process_temp_folder.Text + $"\\{output_4.Text}"; }
            if (output_5.Text != "")
            { output_file_5 = process_temp_folder.Text + $"\\{output_5.Text}"; }
            if (output_6.Text != "")
            { output_file_6 = process_temp_folder.Text + $"\\{output_6.Text}"; }

            //update queue info
            DateTime now = DateTime.Now;
            var client = new RestClient(Properties.Settings.Default.hostip);
            client.Authenticator = new HttpBasicAuthenticator(Properties.Settings.Default.system_user, Properties.Settings.Default.system_pwd);
            var request = new RestRequest("/DataAnalysisQueue/" + queuepk + "/", Method.Patch);
            // client.Timeout = 30 * 60 * 1000;// 1000 ms = 1s, 30 min = 30*60*1000

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "application/json");
            //request.Parameters.Clear();

            request.AddParameter("run_status", true);

            request.AddParameter("finish_time", now.ToString("yyyy-MM-dd hh:mm:ss"));

            if (output_file_1 != "" && File.Exists(output_file_1))
            {
                request.AddFile("output_file_1", output_file_1);

            }
            if (output_file_2 != "" && File.Exists(output_file_2))
            {
                request.AddFile("output_file_2", output_file_2);
            }

            if (output_file_3 != "" && File.Exists(output_file_3))
            {
                request.AddFile("output_file_3", output_file_3);

            }
            if (output_file_4 != "" && File.Exists(output_file_4))
            {
                request.AddFile("output_file_4", output_file_4);

            }
            if (output_file_5 != "" && File.Exists(output_file_5))
            {
                request.AddFile("output_file_5", output_file_5);

            }
            if (output_file_6 != "" && File.Exists(output_file_6))
            {
                request.AddFile("output_file_6", output_file_6);
            }

            var response = client.Execute(request);

        }

        /// <summary>
        /// Method <c>ReportStart</c>reports the starting of a task.
        /// </summary>
        /// <param name="queuepk">the analysis queue pk.</param>

        private void ReportStart(int queuepk)
        {
            DateTime now = DateTime.Now;
            var client = new RestClient(Properties.Settings.Default.hostip);

            client.Authenticator = new HttpBasicAuthenticator(Properties.Settings.Default.system_user, Properties.Settings.Default.system_pwd);


            var request = new RestRequest("/DataAnalysisQueue/" + queuepk + "/", Method.Patch);
            request.AddObject(new
            {
                start_time = now.ToString("yyyy-MM-dd hh:mm:ss"),

            });

            var response = client.Execute(request);


        }

        /// <summary>
        /// Methon <c>GetJobs</c> get first task to process with all the information needed
        /// </summary>
        /// <returns>queuepk, rawfilelist, intput_1, intput_2, intput_3, outpu_file, keep_result.
        /// or 0,null,null,null,null,null,false </returns>
        /// 
        private (int, List<string>, string, string, string, string, bool) GetJobs()
        {

            int app_index = int.Parse(Properties.Settings.Default.process_setting.Split('_')[0]);
            var client = new RestClient(Properties.Settings.Default.hostip);

            client.Authenticator = new HttpBasicAuthenticator(Properties.Settings.Default.system_user, Properties.Settings.Default.system_pwd);

            var request = new RestRequest($"/DataAnalysisQueue/?processappid={app_index}", Method.Get);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "application/json");

            var response = client.Execute(request);


            QueueResponse nextjob = JsonConvert.DeserializeObject<QueueResponse>(response.Content);
            if (nextjob != null)
            {

                return nextjob.GetCurrentJob(Properties.Settings.Default.hostip, Properties.Settings.Default.temp_folder, Properties.Settings.Default.para_process);
            }
            else
            {
                return (0, null, null, null, null, null, false);
            }
        }




        /// <summary>
        /// Method <c>processStart</c> use the input files, raw files and script to start the analysis process.
        /// </summary>
        /// <param name="rawfile">list of raw file names.</param>
        /// <param name="input_1">input_1/configure file 1.</param>
        /// <param name="input_2">input_2/configure file 2.</param>
        /// <param name="input_3">input_3/configure file 3.</param>
        /// <param name="output_File">output_File/configure output_File.</param>
        /// <returns>bool</returns>
        ///
        private bool processStart(List<string> rawfile, string input_1, string input_2, string input_3, string output_File)
        {


            /*            string default_string = @"DiscovererDaemon.exe  -c custom 
                                                - a custom E:\PD_temp\1689.raw - a custom E:\PD_temp\1699.raw 
                                                - r E:\PD_temp\result.msf - b 
                                                - e custom ANY E:\PD_temp\1.pdProcessingWF; E:\PD_temp\1.pdConsensusWF";

                        string template_string = @"DiscovererDaemon.exe  -c custom 
                                                &&loop&& - a custom &&raw_file_name&& &&loop&&
                                                - r &&output&&.msf - b 
                                                - e custom ANY &&input_1&&; &&input_2&&";*/


            string template_string = Properties.Settings.Default.script;



            string output = @"";
            if (input_1 != null)
                output = template_string.Replace("&&input_1&&", input_1);
            if (input_2 != null)
                output = output.Replace("&&input_2&&", input_2);
            if (input_3 != null)
                output = output.Replace("&&input_3&&", input_3);
            if (input_3 != null)
                output = output.Replace("&&input_3&&", input_3);
            if (output_File != null)
                output = output.Replace("&&output&&", output_File);
            // check if &&loop&& exist in output, if not, add it
            string strCmdText;
            if (output.Contains("&&loop&&"))
            {
                List<string> stringList = output.Split("&&loop&&").ToList();
                string loop_string = stringList[1];
                string new_lopp = "";
                foreach (string filename in rawfile)
                {
                    new_lopp += loop_string.Replace("&&raw_file_name&&", filename);

                }


                strCmdText = stringList[0] + new_lopp + stringList[2];
            }
            else
            {
                strCmdText = output;
            }
                      


            //e.g., PD command example:  DiscovererDaemon.exe  -c custom - a custom "E:\PD_temp\1689.raw" - a custom "E:\PD_temp\1699.raw" - r "E:\PD_temp\result.msf" - b - e custom ANY "E:\PD_temp\1.pdProcessingWF"; "E:\PD_temp\1.pdConsensusWF"

            //check if there is any file in the folder ends with txt and contain "Cmd" in it's name, if so,add its content to the strCmdText without newline and space
            string[] fileEntries = Directory.GetFiles(Properties.Settings.Default.temp_folder);
            foreach (string fileName in fileEntries)
            {
                if ((fileName.Contains("Cmd") && fileName.Contains(".txt")) | (fileName.Contains("input_file_1.txt")))
                {
                    string cmd = File.ReadAllText(fileName).Replace(Environment.NewLine, "");
                    strCmdText += cmd;
                }
            }
            // remove extra line and space in strCmdText

            string pattern = @"[\s\r\n]+"; // Matches one or more whitespace characters or newline characters
            strCmdText = Regex.Replace(strCmdText, pattern, " ");


            var path = Properties.Settings.Default.temp_folder + "\\strCmdText.txt";
            File.WriteAllText(path, strCmdText);

            Process.Start("cmd.exe", strCmdText).WaitForExit();
            return true;

        }


        /// <summary>
        /// Method <c>temp_button_Click</c> uses to set the temp folder .
        /// </summary>

        private void temp_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openfolderDialog1 = new FolderBrowserDialog();


            if (openfolderDialog1.ShowDialog() == DialogResult.OK)
            {
                process_temp_folder.Text = openfolderDialog1.SelectedPath;
            }
        }


        /// <summary>
        /// Method <c>Check_server_Click_1</c> obtains the list of process apps from the server.
        /// </summary>
        private void Check_server_Click_1(object sender, EventArgs e)
        {
            try
            {
                var client = new RestClient(hostip.Text);
                client.Authenticator = new HttpBasicAuthenticator(system_username.Text, system_pwd.Text);
                var request = new RestRequest("/ProcessingApp/", Method.Get);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Accept", "application/json");
                var response = client.Execute(request);


                ProcessAppResponseDictionary all_process_response = JsonConvert.DeserializeObject<ProcessAppResponseDictionary>(response.Content);
                process_app_selector.Items.Clear();

                foreach (ProcessApp app in all_process_response.ProcessApp)
                {
                    process_app_selector.Items.Add($"{app.pk}_{app.appname}");
                }
                if (process_app_selector.Items.Count != 0)
                    process_app_selector.SelectedIndex = 0;
            }
            catch (Exception err)
            {
                MessageBox.Show("Can not obtain server address, check server condition or put in manully. " + err.Message);

            }
        }

        /// <summary>
        /// Method <c>Manual_start_Click</c>start the worker.
        /// </summary>
        private void Manual_start_Click(object sender, EventArgs e)
        {
            SaveSettings();


            if (!Directory.Exists(process_temp_folder.Text))
                Directory.CreateDirectory(process_temp_folder.Text);

            if (!process_backgroundWorker.IsBusy)
            {
                process_backgroundWorker.RunWorkerAsync();
                output.AppendText(Environment.NewLine + DateTime.Now + " Started Process Worker ");
            }
        }
        /// <summary>
        /// Method <c>Manual_stop_Click</c>stops the worker, also used to debug with the server.
        /// </summary>
        private void Manual_stop_Click(object sender, EventArgs e)
        {
            UploadResult(3, "test", false); // used for debug

            //stop the thread.
            //Check if background worker is doing anything and send a cancellation if it is
            if (process_backgroundWorker.IsBusy)
            {
                process_backgroundWorker.CancelAsync();
            }
            output.AppendText(Environment.NewLine + DateTime.Now + " Worker stopped");
        }

        /// <summary>
        /// Method <c>helpToolStripMenuItem1_Click</c> open github page for manual.
        /// </summary>
        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/xiaofengxie128/Proteomics_Data_Processor");
        }
    }
}













//Supporting classes


/// <summary>
/// QueueResponse used for modeling the data structure of the process queue from the server.
/// </summary>
public class QueueResponse
{
    [JsonProperty("count")]
    public int count { get; set; }
    [JsonProperty("next")]
    public string next { get; set; }
    [JsonProperty("previous")]
    public string previous { get; set; }
    [JsonProperty("results")]
    public List<ProcessQueue> ProcessQueue { get; set; }


    /// <summary>
    /// Methon <c>GetCurrentJob</c> get first task to process with all the information needed
    /// </summary>
    /// <param name="hostip">server IP.</param>
    /// <param name="folderlocation">temp folder location for saving files</param>
    ///     <param name="para_processing">if para processing is on</param>
    /// <returns>queuepk, rawfilelist, intput_1, intput_2, intput_3, outpu_file, keep_result.
    /// or 0,null,null,null,null,null,false </returns>
    /// 
    public (int, List<string>, string, string, string, string, bool) GetCurrentJob(string hostip, string folderlocation, bool para_processing) // check if there is a pending run
                                                                                                                                               // download inputs files and raw ms files
    {


        var client = new RestClient(hostip);

        client.Authenticator = new HttpBasicAuthenticator(Proteomics_Data_Processor.Properties.Settings.Default.system_user, Proteomics_Data_Processor.Properties.Settings.Default.system_pwd);




        if (this.ProcessQueue.Count == 0)
            return (0, null, null, null, null, null, false);

        else
        {
            Proteomics_Data_Processor.Proteomics_Data_Processor.CleanFolder(Proteomics_Data_Processor.Properties.Settings.Default.temp_folder);


            ProcessQueue NextTask = null; ;
            this.ProcessQueue.Reverse();
            foreach (ProcessQueue item in this.ProcessQueue)
            {
                if (para_processing)
                {
                    if (string.IsNullOrEmpty(item.start_time))
                    {
                        NextTask = item;
                        break;


                    }

                }
                else
                {
                    NextTask = item;
                    break;
                }



            }
            if (NextTask is null)
            {

                return (0, null, null, null, null, null, false);

            }


            WebClient webClient = new WebClient();

            // download input files
            String input_1 = Path.GetFileName(NextTask.input_file_1);
            String input_2 = Path.GetFileName(NextTask.input_file_2);
            String input_3 = Path.GetFileName(NextTask.input_file_3);

            if (input_1 != null)
            {
                input_1 = folderlocation + "\\" + input_1;
                webClient.DownloadFile(NextTask.input_file_1, input_1);


            }
            if (input_2 != null)
            {
                input_2 = folderlocation + "\\" + input_2;
                webClient.DownloadFile(NextTask.input_file_2, input_2);
            }

            if (input_3 != null)
            {
                input_3 = folderlocation + "\\" + input_3;

                webClient.DownloadFile(NextTask.input_file_3, input_3);

            }

            // down all the raw files file 
            List<string> raw_fullpath = new List<string> { };

            List<int> rawlist = this.ProcessQueue.Last().rawfile;
            foreach (int number in rawlist)
            {
                var request = new RestRequest("/SampleRecord/" + number + "/", Method.Get);

                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Accept", "application/json");
                // request.Parameters.Clear();

                var response = client.Execute(request);


                SampleRecord rawurl = JsonConvert.DeserializeObject<SampleRecord>(response.Content);

                request = new RestRequest("/FileStorage/" + rawurl.newest_raw + "/", Method.Get);

                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Accept", "application/json");
                // request.Parameters.Clear();

                response = client.Execute(request);

                FileStorage file_storatge = JsonConvert.DeserializeObject<FileStorage>(response.Content);
                string download_link = file_storatge.file_location;
                string file_location = folderlocation + "\\" + number + Path.GetExtension(download_link);

                webClient.DownloadFile(download_link, folderlocation + "\\" + number + Path.GetExtension(download_link));
                // check if download_link contains .d and .zip, if so, unzip it and delete the zip file with number.d folder
                if (download_link.Contains(".d") && download_link.Contains(".zip"))
                {
                    ZipFile.ExtractToDirectory(folderlocation + "\\" + number + Path.GetExtension(download_link), folderlocation + "\\" + number + ".d");
                    File.Delete(folderlocation + "\\" + number + Path.GetExtension(download_link));
                    file_location = folderlocation + "\\" + number + ".d";
                }
                raw_fullpath.Add(file_location);

            }
            string run_name;
            if (this.ProcessQueue.Last().processing_name != "" && this.ProcessQueue.Last() is not null)
            {
                run_name = this.ProcessQueue.Last().processing_name;
                run_name = run_name.Replace(" ", "_");

            }
            else
            {
                run_name = "result";

            }
            return (this.ProcessQueue.Last().pk, raw_fullpath, input_1, input_2, input_3, folderlocation + "\\" + run_name, this.ProcessQueue.Last().keep_full_output);

        }
    }




}

public class ProcessQueue
{
    public int pk { get; set; }
    public bool run_status { get; set; }

    public string processing_name { get; set; }
    public string start_time { get; set; }
    public bool keep_full_output { get; set; }

    public string input_file_1 { get; set; }
    public string input_file_2 { get; set; }
    public string input_file_3 { get; set; }


    //public int rawfile { get; set; }
    [JsonProperty("sample_records")]
    public List<int> rawfile { get; set; }

}











/// <summary>
/// Class <c>SampleRecord</c> for unpack data from server SampleRecord object.
/// </summary>
public class SampleRecord
{
    public int pk { get; set; }
    public int newest_raw { get; set; }

    /*    public string get_url()
        {
            return this.newest_raw.file_location;

        }*/


}

/// <summary>
/// Class <c>FileStorage</c> for unpack data from server FileStorage object.
/// </summary>
public class FileStorage
{
    public string file_location;
    public string file_type;

}



/// <summary>
/// Class <c>ProcessAppResponseDictionary</c> for unpack data from server ProcessAppResponseDictionary object.
/// </summary>
public class ProcessAppResponseDictionary
{
    [JsonProperty("count")]
    public int count { get; set; }
    [JsonProperty("next")]

    public string next { get; set; }
    [JsonProperty("previous")]

    public string previous { get; set; }
    [JsonProperty("results")]
    public List<ProcessApp> ProcessApp { get; set; }
}


/// <summary>
/// Class <c>ProcessApp</c> for unpack data from server ProcessApp object.
/// </summary>
public class ProcessApp
{
    [JsonProperty("pk")]
    public int pk { get; set; }
    [JsonProperty("name")]

    public string appname { get; set; }
}










/// <summary>
/// Class <c>SettingsProvider</c> uses for saving setting to xml file .
/// from https://stackoverflow.com/questions/36820196/visual-c-sharp-storing-and-reading-custom-options-to-and-from-a-custom-xml-in-ap
/// </summary>
public static class SettingsProvider
{
    private static string settingsFileName;

    private static XDocument settings;

    static SettingsProvider()
    {
        try
        {
            settings = XDocument.Load(settingsFileName);
        }
        catch
        {
            settings = XDocument.Parse("<Settings/>");
        }
    }

    public static string GetValue(string section, string key, string defaultValue)
    {
        XElement settingElement = GetSettingElement(section, key);

        return settingElement == null ? defaultValue : settingElement.Value;
    }


    public static void SetValue(string section, string key, string value)
    {
        XElement settingElement = GetSettingElement(section, key, true);

        settingElement.Value = value;
        settings.Save(settingsFileName);
    }
    public static void setfilename(string value)
    {

        settingsFileName = value;
        try
        {
            settings = XDocument.Load(settingsFileName);
        }
        catch
        {
            settings = XDocument.Parse("<Settings/>");
        }
    }
    private static XElement GetSettingElement(string section, string key, bool createIfNotExist = false)
    {
        XElement sectionElement =
            settings
                .Root
                .Elements(section)
                .FirstOrDefault();

        if (sectionElement == null)
        {
            if (createIfNotExist)
            {
                sectionElement = new XElement(section);
                settings.Root.Add(sectionElement);
            }
            else
            {
                return null;
            }
        }

        XElement settingElement =
            sectionElement
                .Elements(key)
                .FirstOrDefault();

        if (settingElement == null)
        {
            if (createIfNotExist)
            {
                settingElement = new XElement(key);
                sectionElement.Add(settingElement);
            }
        }

        return settingElement;
    }

    public static void RemoveSetting(string section, string key)
    {
        XElement settingElement = GetSettingElement(section, key);

        if (settingElement == null)
        {
            return;
        }

        XElement sectionElement = settingElement.Parent;

        settingElement.Remove();

        if (sectionElement.IsEmpty)
        {
            sectionElement.Remove();
        }

        settings.Save(settingsFileName);
    }
}





