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







namespace Proteomics_Data_Processor
{
    public partial class Proteomics_Data_Processor : Form
    {
        BackgroundWorker pd_backgroundWorker = new BackgroundWorker();
        string AppName = "Proteomics_Data_Processor";

        public DateTime StartTime { get; private set; }

        public Proteomics_Data_Processor()
        {
            InitializeComponent();
            workerip.Text = GetIPAddress();
            //hostip.Text = "http://10.37.240.41/files/api/";
            hostip.Text = "http://192.168.102.188/files/api/";

            //hostip.Text = "http://127.0.0.1:8000/files/api/";

            system_username.Text = "search_worker";
            system_pwd.Text = "rtklab77";
            pd_temp_folder.Text = "c:\\pd_temp";
        workername.Text = "worker_" + Gethostname();
            pd_workder_number.Text = "1";

            pd_backgroundWorker.DoWork += pd_backgroundWorker_DoWork;
            pd_backgroundWorker.ProgressChanged += pd_backgroundWorker_ProgressChanged;
            pd_backgroundWorker.RunWorkerCompleted += pd_backgroundWorker_RunWorkerCompleted;  //Tell the user how the process went
            pd_backgroundWorker.WorkerReportsProgress = true;
            pd_backgroundWorker.WorkerSupportsCancellation = true; //Allow for the process to be cancelled

            if (File.Exists("Default.xml"))
            {
                loadingsettings("Default.xml");


                if (pd_thread_autostart.Checked) { 

                  save_settings();

                if (!pd_backgroundWorker.IsBusy)
                {
                    pd_backgroundWorker.RunWorkerAsync();
                    output.AppendText(Environment.NewLine + DateTime.Now + " Started PD Worker ");



                }
                }
            }
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
                output.AppendText(Environment.NewLine + DateTime.Now + " get ip address run with error"+ex.Message);
                return "1.1.1.1";
            }
        }

        private string Gethostname()
        {
            StringBuilder sb = new StringBuilder();
            String strHostName = string.Empty;
            strHostName = Dns.GetHostName();
            return strHostName.ToString();
        }

        private void pd_backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                worker_ping(); //Notify worker is online
                               //check if there is pending work and download
                List<int> rawfilelist;
                int queuepk;
                string analysis_name;
                bool keep_result;
                (queuepk, analysis_name, keep_result, rawfilelist) = get_jobs();
                if (queuepk != 0)
                {
                    pd_backgroundWorker.ReportProgress(10, $" running Protein Discoverer queue {queuepk}");
                    report_start(queuepk);
                    runbat(analysis_name, rawfilelist);
                    readresult(queuepk, analysis_name, keep_result);
                    pd_backgroundWorker.ReportProgress(99, $" finished running Protein Discoverer queue {queuepk}");

                }




                if (pd_backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    pd_backgroundWorker.ReportProgress(0);
                    return;
                }
                Thread.Sleep(30000);

            }

        }

        private void pd_backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            DateTime now = DateTime.Now;
            pd_last_check.Text = now.ToString();
            workerstatus.Text = e.UserState as String;
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
                workerstatus.Text = e.UserState as String;
                output.AppendText(Environment.NewLine + DateTime.Now + e.UserState);
            }

        }

        private void pd_backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                output.AppendText(Environment.NewLine + DateTime.Now + " PD Process was cancelled");
            }
            else if (e.Error != null)
            {
                output.AppendText(Environment.NewLine + DateTime.Now + " There was an error running the PD process. The thread aborted");
            }
            else
            {
                output.AppendText(Environment.NewLine + DateTime.Now + " PD Process was completed");
            }
        }
        private void Start_Click(object sender, EventArgs e)
        {
            save_settings();

            if (!pd_backgroundWorker.IsBusy)
            {
                pd_backgroundWorker.RunWorkerAsync();
                output.AppendText(Environment.NewLine + DateTime.Now + " Started PD Worker ");



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

            pd_lblElapsed.Text = text;


        }



        private void stop_Click(object sender, EventArgs e)
        {
            //stop the thread.
            //Check if background worker is doing anything and send a cancellation if it is
            if (pd_backgroundWorker.IsBusy)
            {
                pd_backgroundWorker.CancelAsync();
            }
            output.AppendText(Environment.NewLine + DateTime.Now + " Worker stopped");
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void worker_ping()
        {
            DateTime now = DateTime.Now;
            var client = new RestClient(Properties.Settings.Default.hostip);

            client.Authenticator = new HttpBasicAuthenticator(Properties.Settings.Default.system_user, Properties.Settings.Default.system_pwd);

            var request = new RestRequest("/pdworker/" + Properties.Settings.Default.pd_workernumber + "/", Method.PUT);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "multipart/form-data");
            request.Parameters.Clear();
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { pk = Properties.Settings.Default.pd_workernumber, worker_name = Properties.Settings.Default.workername, worker_ip = Properties.Settings.Default.workerip, last_update = now.ToLocalTime() });

            var response = client.Execute(request);
            if (response.ContentType == null)
            {
                pd_backgroundWorker.ReportProgress(0, "No Response from Server");
                var context = SynchronizationContext.Current;
                pd_backgroundWorker.ReportProgress(0, "Idle");


            }
            else

            {
                pd_backgroundWorker.ReportProgress(0, "Idle");


            }
        }


        private void readresult(int queuepk,string analysis_name,bool keep_result)
        {
            string resultfile = Properties.Settings.Default.pd_temp_folder + "\\result.txt";

            string export_file = Properties.Settings.Default.pd_temp_folder + "\\export_file.csv";




            //update queue info
            DateTime now = DateTime.Now;
            var client = new RestClient(Properties.Settings.Default.hostip);

            client.Authenticator = new HttpBasicAuthenticator(Properties.Settings.Default.system_user, Properties.Settings.Default.system_pwd);

            var request = new RestRequest("/pdqueue/" + queuepk + "/", Method.PUT);
            client.Timeout = 30 * 60 * 1000;// 1000 ms = 1s, 30 min = 30*60*1000

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "multipart/form-data");
            request.Parameters.Clear();

            request.AddParameter("run_status", true);

            request.AddParameter("finished_time", now.ToString("yyyy-MM-dd hh:mm:ss"));
            if (keep_result)
            {
                request.AddFile("result_file", Properties.Settings.Default.pd_temp_folder + "\\" + analysis_name + ".pdResult");
            }
            if (File.Exists(resultfile))
            {
                List<string> lines = File.ReadLines(resultfile).ToList();

                request.AddParameter("peptide_id", lines[1]);
                request.AddParameter("protein_id", lines[0]);
            }

            if (File.Exists(export_file))
            {
                request.AddFile("export_file", Properties.Settings.Default.pd_temp_folder + "\\export_file");

            }


            var response = client.Execute(request);

            //update result info












        }


        public int CountLinesLINQ(string filepath)
        => File.ReadLines(filepath).Count();

        private void report_start(int queuepk)
        {
            DateTime now = DateTime.Now;
            var client = new RestClient(Properties.Settings.Default.hostip);

            client.Authenticator = new HttpBasicAuthenticator(Properties.Settings.Default.system_user, Properties.Settings.Default.system_pwd);

            var request = new RestRequest("/pdqueue/" + queuepk + "/", Method.PUT);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "multipart/form-data");
            //request.Parameters.Clear();
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("start_time", now.ToString("yyyy-MM-dd hh:mm:ss"));

            var response = client.Execute(request);


        }


        private (int, string,bool, List<int>) get_jobs() //download all the pending queue query
        {

            var client = new RestClient(Properties.Settings.Default.hostip);

            client.Authenticator = new HttpBasicAuthenticator(Properties.Settings.Default.system_user, Properties.Settings.Default.system_pwd);

            var request = new RestRequest("/pdqueue/", Method.GET);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "application/json");

            var response = client.Execute(request);


            queueresponse nextjob = JsonConvert.DeserializeObject<queueresponse>(response.Content);
            if (nextjob != null)
            {

                return nextjob.get_firstjob(Properties.Settings.Default.hostip, Properties.Settings.Default.pd_temp_folder);
            }
            else
            {
                return (0,null,false, null);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openfolderDialog1 = new FolderBrowserDialog();


            if (openfolderDialog1.ShowDialog() == DialogResult.OK)
            {
                tempfolder.Text = openfolderDialog1.SelectedPath;
            }
        }

        private void save_settings() // save all the UI setting to application settings
        {
            Properties.Settings.Default.hostip = hostip.Text;
            Properties.Settings.Default.pd_workernumber = pd_workder_number.Text;
            Properties.Settings.Default.workername = workername.Text;
            Properties.Settings.Default.workerip = workerip.Text;
            Properties.Settings.Default.pd_temp_folder = pd_temp_folder.Text;
            Properties.Settings.Default.system_user = system_username.Text;
            Properties.Settings.Default.system_pwd  = system_pwd.Text;
            Properties.Settings.Default.pd_batch_file = pd_batch_file.Text;


        }

        private bool runbat(string analysis_name, List <int> rawfile)
          {
            string strCmdText;
            //PD command example:  DiscovererDaemon.exe  -c custom - a custom "E:\PD_temp\1689.raw" - a custom "E:\PD_temp\1699.raw" - r "E:\PD_temp\result.msf" - b - e custom ANY "E:\PD_temp\1.pdProcessingWF"; "E:\PD_temp\1.pdConsensusWF"
            strCmdText = "-c custom";
            foreach (int number in rawfile) //adding raw files
            {
                strCmdText += " -a custom " + Properties.Settings.Default.pd_temp_folder+"\\" + number + ".raw";
            }
            //adding result file name
            strCmdText += " -r "+ Properties.Settings.Default.pd_temp_folder + "\\" + analysis_name + ".msf -b"; 

            // adding process and pdConsensusWF 

            strCmdText += " -e custom ANY " + Properties.Settings.Default.pd_temp_folder + "\\1.pdProcessingWF;" + Properties.Settings.Default.pd_temp_folder + "\\1.pdConsensusWF";
            
            var path = Properties.Settings.Default.pd_temp_folder+"\\strCmdText.txt";

            File.WriteAllText(path, strCmdText);

            System.Diagnostics.Process.Start("DiscovererDaemon.exe", strCmdText).WaitForExit();
            return true;

        }

        private void find_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Browse Raw Files",

                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "raw",
                Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*",
                RestoreDirectory = true,

            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                exe_location.Text = openFileDialog1.FileName;
            }
        }

        private void pd_temp_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openfolderDialog1 = new FolderBrowserDialog();


            if (openfolderDialog1.ShowDialog() == DialogResult.OK)
            {
                pd_temp_folder.Text = openfolderDialog1.SelectedPath;
            }
        }

        private void pd_batch_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Browse bat Files",

                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "bat",
                Filter = "Bat files (*.bat)|*.bat|All files (*.*)|*.*",
                RestoreDirectory = true,

            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pd_batch_file.Text = openFileDialog1.FileName;
            }
        }

        private void loadingSettingsFromToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Browse xml Files",

                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "xml",
                Filter = "Uploader Configure files (*.xml)|*.xml|All files (*.*)|*.*",
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
    }

    public class queueresponse
    {


        [JsonProperty("count")]
        public int count { get; set; }
        [JsonProperty("next")]

        public string next { get; set; }
        [JsonProperty("previous")]

        public string previous { get; set; }
        [JsonProperty("results")]
        public List<results> results { get; set; }

        public (int,string,bool, List<int>) get_firstjob(string hostip, string folderlocation) // check if there is a pending run
                                                                      // download configuration and raw files
        {





            var client = new RestClient(hostip);

            client.Authenticator = new HttpBasicAuthenticator(Properties.Settings.Default.system_user, Properties.Settings.Default.system_pwd);




            if (this.results.Count == 0)
            { return (0,null,false,null); }

            else
            {
                clean_fold();

                WebClient webClient = new WebClient();

            // download processing_method and consensus_method

            webClient.DownloadFile(this.results.First().processing_method, folderlocation + "\\1.pdProcessingWF");

            webClient.DownloadFile(this.results.First().consensus_method, folderlocation + "\\1.pdConsensusWF"); /*down all the raw files file*/

                List<int> rawlist = this.results.First().rawfile;
                foreach (int number in rawlist)
                {
                    var request = new RestRequest(number + "/", Method.GET);

                    request.AddHeader("cache-control", "no-cache");
                    request.AddHeader("Accept", "application/json");
                    //request.AddHeader("Content-Type", "multipart/form-data");
                    request.Parameters.Clear();

                    var response = client.Execute(request);


                    rawfilerecord rawurl = JsonConvert.DeserializeObject<rawfilerecord>(response.Content);


                    webClient.DownloadFile(rawurl.get_url(), folderlocation + "\\" + number + ".raw");

                }
                string run_name;
                if (this.results.First().analysis_name !="")
                {
                    run_name = this.results.First().analysis_name;
                    run_name = run_name.Replace(" ", "_");

                }
                else
                {
                    run_name = "result";

                }
                return (this.results.First().pk, run_name, this.results.First().keep_result,rawlist);

            }
        }


        public void clean_fold()
        {

            // delelte all the results files to save space
            System.IO.DirectoryInfo di = new DirectoryInfo(Properties.Settings.Default.pd_temp_folder);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }


        }





    }





    public class results
    {
        public int pk { get; set; }
        public bool run_status { get; set; }

        public string analysis_name { get; set; }
        public bool keep_result { get; set; }

        public string processing_method { get; set; }
        public string consensus_method { get; set; }

        //public int rawfile { get; set; }
        public List<int> rawfile { get; set; }

    }








    public class rawfilerecord
    {
        public int pk { get; set; }
        public string rawfile { get; set; }

        public string get_url()
        {
            return this.rawfile;

        }


    }

}

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





