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
            system_username.Text = "admin";
            system_pwd.Text = "admin";
            workername.Text = "worker_" + Gethostname();
            version_number.Text =  Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string default_script = "";

            process_temp_folder.Text = "c:\\temp";
            workder_number.Text = "1";
            process_backgroundWorker.DoWork += process_backgroundWorker_DoWork;
            process_backgroundWorker.ProgressChanged += process_backgroundWorker_ProgressChanged;
            process_backgroundWorker.RunWorkerCompleted += process_backgroundWorker_RunWorkerCompleted;  //Tell the user how the process went
            process_backgroundWorker.WorkerReportsProgress = true;
            process_backgroundWorker.WorkerSupportsCancellation = true; //Allow for the process to be cancelled



            // Automatically load setting if Default.xml exist in the same folder, and start the process if it is checked
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




        private int CountLinesLINQ(string filepath)
                => File.ReadLines(filepath).Count();


        private void SaveSettings() // save all the UI setting to application settings
        {
            Properties.Settings.Default.hostip = hostip.Text;
            Properties.Settings.Default.workerip = workerip.Text;
            Properties.Settings.Default.system_user = system_username.Text;
            Properties.Settings.Default.system_pwd = system_pwd.Text;
            Properties.Settings.Default.workername = workername.Text;


            Properties.Settings.Default.workernumber = workder_number.Text;
            Properties.Settings.Default.temp_folder = process_temp_folder.Text;






        }


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
                }

            }
        }

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


                    }

                }
            }
        }



        // used for autostart in windows
        private void SetStartup()
        {

            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (start_with_windows.Checked)
                rk.SetValue(AppName, Application.ExecutablePath);
            else
                rk.DeleteValue(AppName, false);

        }



        private void start_with_windows_CheckedChanged(object sender, EventArgs e)
        {
            SetStartup();
        }

        private string GetIPAddress()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                String strHostName = string.Empty;
                strHostName = Dns.GetHostName();
                IPHostEntry ipHostEntry = Dns.GetHostEntry(strHostName);
                IPAddress[] address = ipHostEntry.AddressList;
                sb.Append(address[4].ToString());
                sb.AppendLine();
                return sb.ToString();
            }
            catch (Exception ex)
            {
                output.AppendText(Environment.NewLine + DateTime.Now + " get ip address run with error" + ex.Message);
                return "1.1.1.1";
            }
        }


        public static void CleanFolder(string foldername)
        {

            try
            {
                // delelte all the files to save space
                System.IO.DirectoryInfo di = new DirectoryInfo(foldername);

                foreach (FileInfo file in di.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    dir.Delete(true);
                }

            }
            catch (Exception ex)
            {

                Thread _message_thread = new Thread(() => MessageBox.Show(Environment.NewLine + DateTime.Now + "Unable to delete file" + ex.Message));

                if (!_message_thread.IsAlive)
                    _message_thread.Start();

            }
        }









        private string Gethostname()
        {
            StringBuilder sb = new StringBuilder();
            String strHostName = string.Empty;
            strHostName = Dns.GetHostName();
            return strHostName.ToString();
        }





        private void process_backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                ProcessWorkerPing(); //Notify worker is online
                                //check if there is pending work and download

                List<int> rawfilelist;
                int queuepk;
                string analysis_name;
                bool keep_result;
                (queuepk, analysis_name, keep_result, rawfilelist) = GetJobsPD();


                if (queuepk != 0)
                {
                    process_backgroundWorker.ReportProgress(10, $" running Process queue {queuepk}");
                    ReportStart(queuepk);
                    processStart(analysis_name, rawfilelist);
                    ReadResult(queuepk, analysis_name, keep_result);
                    process_backgroundWorker.ReportProgress(99, $" finished running Process queue {queuepk}");

                }




                if (process_backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    process_backgroundWorker.ReportProgress(0);
                    return;
                }
                Thread.Sleep(30000);

            }

        }

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
                output.AppendText(Environment.NewLine + DateTime.Now + " A new PD analysis started, " + e.UserState as String);
                StartTime = DateTime.Now;

            }

            if (e.ProgressPercentage == 99)
            {
                tmrClock.Enabled = !tmrClock.Enabled;
                output.AppendText(Environment.NewLine + DateTime.Now + e.UserState);
            }

        }

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
        private void Start_Click(object sender, EventArgs e)
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



        // Display the new elapsed time.
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



        private void stop_Click(object sender, EventArgs e)
        {
            //stop the thread.
            //Check if background worker is doing anything and send a cancellation if it is
            if (process_backgroundWorker.IsBusy)
            {
                process_backgroundWorker.CancelAsync();
            }
            output.AppendText(Environment.NewLine + DateTime.Now + " Worker stopped");
        }









        private void ProcessWorkerPing()
        {
            //check if selected proper process
            int app_index;
            try {
               app_index = int.Parse(Properties.Settings.Default.process_setting.Split('_')[0]);

                }
            catch (Exception e)
            {
                MessageBox.Show($"Please select valid processor name. Exception: {e.Message}");
                
                return;

            }

            DateTime now = DateTime.Now;
            var client = new RestClient(Properties.Settings.Default.hostip);
            // check if worker number exist

            client.Authenticator = new HttpBasicAuthenticator(Properties.Settings.Default.system_user, Properties.Settings.Default.system_pwd);
            var request = new RestRequest("/WorkerStatus/" + Properties.Settings.Default.workernumber + "/", Method.Get);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "application/json");
            var response = client.Execute(request);
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



            }
            else

            {
                process_backgroundWorker.ReportProgress(0, "No Response from Server");
                process_backgroundWorker.ReportProgress(0, "Idle");

            }
        }


        private void ReadResult(int queuepk, string analysis_name, bool keep_result)
        {
            string resultfile = Properties.Settings.Default.temp_folder + "\\result.txt";

            string export_file = Properties.Settings.Default.temp_folder + "\\export_file.csv";




            //update queue info
            DateTime now = DateTime.Now;
            var client = new RestClient(Properties.Settings.Default.hostip);

            client.Authenticator = new HttpBasicAuthenticator(Properties.Settings.Default.system_user, Properties.Settings.Default.system_pwd);

            var request = new RestRequest("/pdqueue/" + queuepk + "/", Method.Patch);
           // client.Timeout = 30 * 60 * 1000;// 1000 ms = 1s, 30 min = 30*60*1000

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "multipart/form-data");
            //request.Parameters.Clear();

            request.AddParameter("run_status", true);

            request.AddParameter("finished_time", now.ToString("yyyy-MM-dd hh:mm:ss"));
            if (keep_result)
            {
                request.AddFile("result_file", Properties.Settings.Default.temp_folder + "\\" + analysis_name + ".pdResult");
            }
            if (File.Exists(resultfile))
            {
                List<string> lines = File.ReadLines(resultfile).ToList();

                request.AddParameter("peptide_id", lines[1]);
                request.AddParameter("protein_id", lines[0]);
            }

            if (File.Exists(export_file))
            {
                request.AddFile("export_file", Properties.Settings.Default.temp_folder + "\\export_file");

            }


            var response = client.Execute(request);

            //update result info




        }


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


        private (int, string, bool, List<int>) GetJobsPD() //download all the pending queue query



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

                return nextjob.GetCurrentJob(Properties.Settings.Default.hostip, Properties.Settings.Default.temp_folder);
            }
            else
            {
                return (0, null, false, null);
            }
        }





        private bool processStart(string analysis_name, List<int> rawfile)
        {


            string default_string = @"DiscovererDaemon.exe  -c custom 
                                    - a custom E:\PD_temp\1689.raw - a custom E:\PD_temp\1699.raw 
                                    - r E:\PD_temp\result.msf - b 
                                    - e custom ANY E:\PD_temp\1.pdProcessingWF; E:\PD_temp\1.pdConsensusWF";

            string template_string = @"DiscovererDaemon.exe  -c custom 
                                    &&loop&& - a custom &&raw_file_name&& &&loop&&
                                    - r &&output&& - b 
                                    - e custom ANY &&input_1&&; &&input_2&&";
            string input_1 = "intput1.process";
            string input_2 = "intput2.process";
            string output_File = "1.result";
            string output = template_string.Replace("&&input_1&&", input_1);
            output = output.Replace("&&input_2&&", input_2);
            // output = output.Replace("&&input_3&&", "intput3.process");
            output = output.Replace("&&output&&", output_File);
            List<string> stringList = output.Split("&&loop&&").ToList();
            string loop_string = stringList[1];
            string new_lopp = "";
            List<string> stringList2 = new List<string>() { "1.raw", "2.raw", "3.raw" };
            foreach (string filename in stringList2)
            {
                new_lopp += loop_string.Replace("&&raw_file_name&&", filename);

            }





            MessageBox.Show(stringList[0] + new_lopp + stringList[2]);



















            string strCmdText;
            //PD command example:  DiscovererDaemon.exe  -c custom - a custom "E:\PD_temp\1689.raw" - a custom "E:\PD_temp\1699.raw" - r "E:\PD_temp\result.msf" - b - e custom ANY "E:\PD_temp\1.pdProcessingWF"; "E:\PD_temp\1.pdConsensusWF"
            strCmdText = "-c custom";
            foreach (int number in rawfile) //adding raw files
            {
                strCmdText += " -a custom " + Properties.Settings.Default.temp_folder + "\\" + number + ".raw";
            }
            //adding result file name
            strCmdText += " -r " + Properties.Settings.Default.temp_folder + "\\" + analysis_name + ".msf -b";

            // adding process and pdConsensusWF 

            strCmdText += " -e custom ANY " + Properties.Settings.Default.temp_folder + "\\1.pdProcessingWF;" + Properties.Settings.Default.temp_folder + "\\1.pdConsensusWF";

            var path = Properties.Settings.Default.temp_folder + "\\strCmdText.txt";

            File.WriteAllText(path, strCmdText);

            System.Diagnostics.Process.Start("DiscovererDaemon.exe", strCmdText).WaitForExit();
            return true;

        }



        private void temp_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openfolderDialog1 = new FolderBrowserDialog();


            if (openfolderDialog1.ShowDialog() == DialogResult.OK)
            {
                process_temp_folder.Text = openfolderDialog1.SelectedPath;
            }
        }

        private void Check_server_Click_1(object sender, EventArgs e)
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
    }





           }













           //Supporting classes





           //PD related Classes

           /// <summary>
           /// QueueResponse used for modeling the data structure of the process queue from the server.
           /// </summary>
           /// <param name="param1">Some Parameter.</param>
           /// <returns>What this method returns.</returns>
           /// 
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

               public (int, string, bool, List<int>) GetCurrentJob(string hostip, string folderlocation) // check if there is a pending run
                                                                                                         // download configuration and raw files
               {





                   var client = new RestClient(hostip);

                   client.Authenticator = new HttpBasicAuthenticator(Proteomics_Data_Processor.Properties.Settings.Default.system_user, Proteomics_Data_Processor.Properties.Settings.Default.system_pwd);




                   if (this.ProcessQueue.Count == 0)
                   { return (0, null, false, null); }

                   else
                   {
                       Proteomics_Data_Processor.Proteomics_Data_Processor.CleanFolder(Proteomics_Data_Processor.Properties.Settings.Default.temp_folder);



                       WebClient webClient = new WebClient();

            // download processing_method and consensus_method
            String input_1 = Path.GetFileName(this.ProcessQueue.Last().input_file_1);
            String input_2 = Path.GetFileName(this.ProcessQueue.Last().input_file_2);
            String input_3 = Path.GetFileName(this.ProcessQueue.Last().input_file_3);

            if (input_1 != null)
            webClient.DownloadFile(this.ProcessQueue.Last().input_file_1, folderlocation +"\\"+ input_1);
            if (input_2 != null)

            webClient.DownloadFile(this.ProcessQueue.Last().input_file_2, folderlocation + "\\" + input_2);
            if (input_3 != null)
            webClient.DownloadFile(this.ProcessQueue.Last().input_file_3, folderlocation + "\\" + input_3);

            // down all the raw files file 

            List<int> rawlist = this.ProcessQueue.Last().rawfile;
                       foreach (int number in rawlist)
                       {
                           var request = new RestRequest( "/SampleRecord/" +number + "/" , Method.Get);

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

                           webClient.DownloadFile(download_link, folderlocation + "\\" + number + Path.GetExtension(download_link));

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
                       return (this.ProcessQueue.Last().pk, run_name, this.ProcessQueue.Last().keep_full_output, rawlist);

                   }
               }








           }

           public class ProcessQueue
           {
               public int pk { get; set; }
               public bool run_status { get; set; }

               public string processing_name { get; set; }
               public bool keep_full_output { get; set; }

               public string input_file_1 { get; set; }
               public string input_file_2 { get; set; }
               public string input_file_3 { get; set; }


    //public int rawfile { get; set; }
                [JsonProperty("sample_records")]
                public List<int> rawfile { get; set; }

           }










//General purpose Classes


public class SampleRecord
{
    public int pk { get; set; }
    public int newest_raw { get; set; }

/*    public string get_url()
    {
        return this.newest_raw.file_location;

    }*/


}
public class FileStorage
{
    public string file_location;
    public string file_type;

}


// processapp_response class


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

public class ProcessApp
{
    [JsonProperty("pk")]
    public int pk { get; set; }
    [JsonProperty("name")]

    public string appname { get; set; }
}









//used for saving and loading settings
//https://stackoverflow.com/questions/36820196/visual-c-sharp-storing-and-reading-custom-options-to-and-from-a-custom-xml-in-ap

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





