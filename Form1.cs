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
        BackgroundWorker mq_backgroundWorker = new BackgroundWorker();

        string AppName = "Proteomics_Data_Processor";

        public DateTime StartTime { get; private set; }

        public Proteomics_Data_Processor()
        {
            InitializeComponent();
            workerip.Text = GetIPAddress();
            hostip.Text = "http://192.168.102.188/files/api/";
            system_username.Text = "search_worker";
            system_pwd.Text = "gmUSxbPugSCm#wRm^PVc$8v5JYRyqdJWNeYzyyVf9YohZU*CAbowLc3PG%xw";
            workername.Text = "worker_" + Gethostname();


            //PD           
            pd_temp_folder.Text = "c:\\pd_temp";
            pd_workder_number.Text = "1";
            pd_backgroundWorker.DoWork += pd_backgroundWorker_DoWork;
            pd_backgroundWorker.ProgressChanged += pd_backgroundWorker_ProgressChanged;
            pd_backgroundWorker.RunWorkerCompleted += pd_backgroundWorker_RunWorkerCompleted;  //Tell the user how the process went
            pd_backgroundWorker.WorkerReportsProgress = true;
            pd_backgroundWorker.WorkerSupportsCancellation = true; //Allow for the process to be cancelled




            //Maxquant           
            mq_temp_folder.Text = "c:\\mq_temp";
            mq_workernumber.Text = "1";
            mq_backgroundWorker.DoWork += mq_backgroundWorker_DoWork;
            mq_backgroundWorker.ProgressChanged += mq_backgroundWorker_ProgressChanged;
            mq_backgroundWorker.RunWorkerCompleted += mq_backgroundWorker_RunWorkerCompleted;  //Tell the user how the process went
            mq_backgroundWorker.WorkerReportsProgress = true;
            mq_backgroundWorker.WorkerSupportsCancellation = true; //Allow for the process to be cancelled





            // Automatically load setting if Default.xml exist in the same folder, and start the process if it is checked
            if (File.Exists("Default.xml"))
            {
                loadingsettings("Default.xml");


                if (pd_thread_autostart.Checked)
                {

                    SaveSettings();

                    if (!pd_backgroundWorker.IsBusy)
                    {
                        pd_backgroundWorker.RunWorkerAsync();
                        output.AppendText(Environment.NewLine + DateTime.Now + " Started PD Worker ");



                    }
                }

                if (mq_autostart.Checked)
                {

                    SaveSettings();

                    if (!mq_backgroundWorker.IsBusy)
                    {
                        mq_backgroundWorker.RunWorkerAsync();
                        output.AppendText(Environment.NewLine + DateTime.Now + " Started MaxQuant Worker ");



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


            Properties.Settings.Default.pd_workernumber = pd_workder_number.Text;
            Properties.Settings.Default.pd_temp_folder = pd_temp_folder.Text;


            Properties.Settings.Default.mq_workernumber = mq_workernumber.Text;
            Properties.Settings.Default.mq_temp_folder = mq_temp_folder.Text;
            Properties.Settings.Default.mq_exe_location = mq_exe_location.Text;





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



        //PD related methods


        private void pd_backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                PDWorkerPing(); //Notify worker is online
                                //check if there is pending work and download

                List<int> rawfilelist;
                int queuepk;
                string analysis_name;
                bool keep_result;
                (queuepk, analysis_name, keep_result, rawfilelist) = GetJobsPD();


                if (queuepk != 0)
                {
                    pd_backgroundWorker.ReportProgress(10, $" running Protein Discoverer queue {queuepk}");
                    ReportStartPD(queuepk);
                    PdprocessStart(analysis_name, rawfilelist);
                    ReadResultPD(queuepk, analysis_name, keep_result);
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
            mq_workerstatus.Text = e.UserState as String;
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
                mq_workerstatus.Text = e.UserState as String;
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
            SaveSettings();

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



        private void PDWorkerPing()
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
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                pd_backgroundWorker.ReportProgress(0, "Idle");



            }
            else

            {
                pd_backgroundWorker.ReportProgress(0, "No Response from Server");
                //var context = SynchronizationContext.Current;
                pd_backgroundWorker.ReportProgress(0, "Idle");

            }
        }


        private void ReadResultPD(int queuepk, string analysis_name, bool keep_result)
        {
            string resultfile = Properties.Settings.Default.pd_temp_folder + "\\result.txt";

            string export_file = Properties.Settings.Default.pd_temp_folder + "\\export_file.csv";




            //update queue info
            DateTime now = DateTime.Now;
            var client = new RestClient(Properties.Settings.Default.hostip);

            client.Authenticator = new HttpBasicAuthenticator(Properties.Settings.Default.system_user, Properties.Settings.Default.system_pwd);

            var request = new RestRequest("/pdqueue/" + queuepk + "/", Method.PATCH);
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


        private void ReportStartPD(int queuepk)
        {
            DateTime now = DateTime.Now;
            var client = new RestClient(Properties.Settings.Default.hostip);

            client.Authenticator = new HttpBasicAuthenticator(Properties.Settings.Default.system_user, Properties.Settings.Default.system_pwd);

            var request = new RestRequest("/pdqueue/" + queuepk + "/", Method.PATCH);
            request.AddObject(new
            {
                start_time = now.ToString("yyyy-MM-dd hh:mm:ss"),

            });

            var response = client.Execute(request);


        }


        private (int, string, bool, List<int>) GetJobsPD() //download all the pending queue query
        {

            var client = new RestClient(Properties.Settings.Default.hostip);

            client.Authenticator = new HttpBasicAuthenticator(Properties.Settings.Default.system_user, Properties.Settings.Default.system_pwd);

            var request = new RestRequest("/pdqueue/", Method.GET);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "application/json");

            var response = client.Execute(request);


            PDQueueResponse nextjob = JsonConvert.DeserializeObject<PDQueueResponse>(response.Content);
            if (nextjob != null)
            {

                return nextjob.GetCurrentJob(Properties.Settings.Default.hostip, Properties.Settings.Default.pd_temp_folder);
            }
            else
            {
                return (0, null, false, null);
            }
        }





        private bool PdprocessStart(string analysis_name, List<int> rawfile)
        {
            string strCmdText;
            //PD command example:  DiscovererDaemon.exe  -c custom - a custom "E:\PD_temp\1689.raw" - a custom "E:\PD_temp\1699.raw" - r "E:\PD_temp\result.msf" - b - e custom ANY "E:\PD_temp\1.pdProcessingWF"; "E:\PD_temp\1.pdConsensusWF"
            strCmdText = "-c custom";
            foreach (int number in rawfile) //adding raw files
            {
                strCmdText += " -a custom " + Properties.Settings.Default.pd_temp_folder + "\\" + number + ".raw";
            }
            //adding result file name
            strCmdText += " -r " + Properties.Settings.Default.pd_temp_folder + "\\" + analysis_name + ".msf -b";

            // adding process and pdConsensusWF 

            strCmdText += " -e custom ANY " + Properties.Settings.Default.pd_temp_folder + "\\1.pdProcessingWF;" + Properties.Settings.Default.pd_temp_folder + "\\1.pdConsensusWF";

            var path = Properties.Settings.Default.pd_temp_folder + "\\strCmdText.txt";

            File.WriteAllText(path, strCmdText);

            System.Diagnostics.Process.Start("DiscovererDaemon.exe", strCmdText).WaitForExit();
            return true;

        }



        private void pd_temp_button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openfolderDialog1 = new FolderBrowserDialog();


            if (openfolderDialog1.ShowDialog() == DialogResult.OK)
            {
                pd_temp_folder.Text = openfolderDialog1.SelectedPath;
            }
        }








        //Maxquant related methods




        private void find_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                Title = "Browse MaxquantCmd.exe Files",

                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "exe",
                Filter = "exe files (*.exe)|*.exe|All files (*.*)|*.*",
                RestoreDirectory = true,

            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                mq_exe_location.Text = openFileDialog1.FileName;
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openfolderDialog1 = new FolderBrowserDialog();


            if (openfolderDialog1.ShowDialog() == DialogResult.OK)
            {
                mq_temp_folder.Text = openfolderDialog1.SelectedPath;
            }


        }


        // Display the new elapsed time.
        private void mq_tmrClock_Tick(object sender, EventArgs e)
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

            mq_lblElapsed.Text = text;


        }




        private void mq_start_Click_1(object sender, EventArgs e)
        {
            SaveSettings();

            if (!mq_backgroundWorker.IsBusy)
            {
                mq_backgroundWorker.RunWorkerAsync();
                output.AppendText(Environment.NewLine + DateTime.Now + " Started MaxQuant Worker ");
            }
        }

        private void mq_stop_Click_1(object sender, EventArgs e)
        {
            //stop the thread.
            //Check if background worker is doing anything and send a cancellation if it is
            if (mq_backgroundWorker.IsBusy)
            {
                mq_backgroundWorker.CancelAsync();
            }
            output.AppendText(Environment.NewLine + DateTime.Now + " Maxquant Worker stopped");
        }



















        private void mq_backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (true)
            {
                MqWorkerPing(); //Notify worker is online
                                //check if there is pending work and download

                int queuepk = MqGetJobs();



                if (queuepk != 0)
                {

                    mq_backgroundWorker.ReportProgress(10, $" running maxquant queue {queuepk}");
                    MqReportStart(queuepk);
                    MqprocessStart();
                    MqReadResult(queuepk);
                    mq_backgroundWorker.ReportProgress(99, $" finished running maxquant queue {queuepk}");




                }




                if (pd_backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    mq_backgroundWorker.ReportProgress(0);
                    return;
                }
                Thread.Sleep(30000);

            }

        }





        private void mq_backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            DateTime now = DateTime.Now;
            mq_lastupdate.Text = now.ToString();
            mq_workerstatus.Text = e.UserState as String;
            if (e.UserState as String == "No Response from Server")
            {
                output.AppendText(Environment.NewLine + DateTime.Now + " No Response from Server.");

            }
            if (e.ProgressPercentage == 10)
            {
                
                mq_tmrClock.Enabled = !mq_tmrClock.Enabled;
                output.AppendText(Environment.NewLine + DateTime.Now + " A new analysis started, " + e.UserState as String);
                StartTime = DateTime.Now;

            }

            if (e.ProgressPercentage == 99)
            {
                mq_tmrClock.Enabled = !mq_tmrClock.Enabled;
                mq_workerstatus.Text = e.UserState as String;
                output.AppendText(Environment.NewLine + DateTime.Now + e.UserState);
            }

        }

        private void mq_backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                output.AppendText(Environment.NewLine + DateTime.Now + " Maxquant Process was cancelled");
            }
            else if (e.Error != null)
            {
                output.AppendText(Environment.NewLine + DateTime.Now + " There was an error running the Maxquant process. The thread aborted");
            }
            else
            {
                output.AppendText(Environment.NewLine + DateTime.Now + " Maxquant Process was completed");
            }
        }






        private void MqWorkerPing()
        {
            DateTime now = DateTime.Now;
            var client = new RestClient(Properties.Settings.Default.hostip);

            client.Authenticator = new HttpBasicAuthenticator(Properties.Settings.Default.system_user, Properties.Settings.Default.system_pwd);

            var request = new RestRequest("/maxquantworker/" + Properties.Settings.Default.mq_workernumber + "/", Method.PUT);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "multipart/form-data");
            request.Parameters.Clear();
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new { pk = Properties.Settings.Default.mq_workernumber, worker_name = Properties.Settings.Default.workername, worker_ip = Properties.Settings.Default.workerip, last_update = now.ToLocalTime() });

            var response = client.Execute(request);
            if (response.ResponseStatus == ResponseStatus.Completed)
            {
                mq_backgroundWorker.ReportProgress(0, "Idle");



            }
            else

            {
                mq_backgroundWorker.ReportProgress(0, "No Response from Server");
                mq_backgroundWorker.ReportProgress(0, "Idle");

            }



        }


        private int MqGetJobs() //download all the pending queue query
        {
            var client = new RestClient(Properties.Settings.Default.hostip);

            client.Authenticator = new HttpBasicAuthenticator(Properties.Settings.Default.system_user, Properties.Settings.Default.system_pwd);


            var request = new RestRequest("/maxquantqueue/", Method.GET);

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "application/json");

            var response = client.Execute(request);


            MaxquantQueueResponse nextjob = JsonConvert.DeserializeObject<MaxquantQueueResponse>(response.Content);
            if (nextjob != null)
            {
                return nextjob.GetCurrentJob(Properties.Settings.Default.hostip, Properties.Settings.Default.mq_temp_folder);
            }
            else
            {
                return 0;
            }
        }



        private void MqReportStart(int queuepk)
        {
            DateTime now = DateTime.Now;
            var client = new RestClient(Properties.Settings.Default.hostip);

            client.Authenticator = new HttpBasicAuthenticator(Properties.Settings.Default.system_user, Properties.Settings.Default.system_pwd);

            var request = new RestRequest("/maxquantqueue/" + queuepk + "/", Method.PATCH);
            request.AddObject(new
            {
                start_time = now.ToString("yyyy-MM-dd hh:mm:ss"),

            });

            var response = client.Execute(request);


        }




        private bool MqprocessStart()
        {


            /*Maxquant command example:  --
           set MAXQUANTDIR = C:\MaxQuant\MaxQuant 2.0.3.0\MaxQuant.exe
           set THREADS = 18"
           set DATADIR = C:\Maxquant_temp
           set PREFIXRAW =
           set PARAMFILE = mqpar.xml
           "C:\MaxQuant\MaxQuant 2.0.3.0\bin\MaxQuantCmd.exe" "C:\Maxquant_temp\mqpar.xml"
            */

            string strCmdText1 = "set MAXQUANTDIR = " + Properties.Settings.Default.mq_exe_location;
            string strCmdText2 = " set THREADS = 18";
            string strCmdText3 = " set DATADIR = " + Properties.Settings.Default.mq_temp_folder;
            string strCmdText4 = " set PREFIXRAW =";
            string strCmdText5 = " set PARAMFILE = mqpar.xml ";
            string strCmdText6 = Path.GetDirectoryName(Properties.Settings.Default.mq_exe_location) + "\\bin\\MaxQuantCmd.exe ";
            string strCmdText7 = Properties.Settings.Default.mq_temp_folder + "\\mqpar.xml";


            ProcessStartInfo newstartInfo = new ProcessStartInfo();
            newstartInfo.FileName = "cmd";
            newstartInfo.Verb = "runas";
            newstartInfo.RedirectStandardInput = true;
            newstartInfo.UseShellExecute = false; //The Process object must have the UseShellExecute property set to false in order to redirect IO streams.

            Process newProcess = new Process();

            newProcess.StartInfo = newstartInfo;
            newProcess.Start();
            StreamWriter write = newProcess.StandardInput; //Using the Streamwriter to write to the elevated command prompt.
            write.WriteLine(strCmdText1); // command executes in elevated command prompt
            write.WriteLine(strCmdText2); // command executes in elevated command prompt
            write.WriteLine(strCmdText3); // command executes in elevated command prompt
            write.WriteLine(strCmdText4); // command executes in elevated command prompt
            write.WriteLine(strCmdText5); // command executes in elevated command prompt
            write.WriteLine('\u0022'+strCmdText6+ '\u0022'+ " "+ '\u0022' + strCmdText7+ '\u0022'); // command executes in elevated command prompt
            write.WriteLine("exit()"); //exit

            newProcess.WaitForExit();


            return true;

        }

        private void MqReadResult(int queuepk)
        {

            DirectoryInfo freshdir = new DirectoryInfo(Properties.Settings.Default.mq_temp_folder + "\\combined\\txt\\");


            //update queue info
            DateTime now = DateTime.Now;
            var client = new RestClient(Properties.Settings.Default.hostip);

            client.Authenticator = new HttpBasicAuthenticator(Properties.Settings.Default.system_user, Properties.Settings.Default.system_pwd);

            var request = new RestRequest("/maxquantqueue/" + queuepk + "/", Method.PUT);
            client.Timeout = 30 * 60 * 1000;// 1000 ms = 1s, 30 min = 30*60*1000

            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "multipart/form-data");
            request.Parameters.Clear();

            request.AddParameter("run_status", true);
            request.AddParameter("protein_id", CountLinesLINQ(freshdir.FullName + @"\proteinGroups.txt"));
            request.AddParameter("peptide_id", CountLinesLINQ(freshdir.FullName + @"\peptides.txt"));
            request.AddParameter("finished_time", now.ToString("yyyy-MM-dd hh:mm:ss"));
            request.AddFile("peptide_file", freshdir.FullName + @"\peptides.txt");
            request.AddFile("protein_file", freshdir.FullName + @"\proteinGroups.txt");
            request.AddFile("evidence_file", freshdir.FullName + @"\evidence.txt");
            string zipPath = @"C:\maxquant_temp\combined\others.zip";
            ZipFile.CreateFromDirectory(freshdir.FullName, zipPath);
            request.AddFile("other_file", zipPath);
            var response = client.Execute(request);






        }



  



               }





           }













           //other classes





           //PD related Classes

           /// <summary>
           /// PDQueueResponse used for modeling the data structure of the PD queue from the server.
           /// </summary>
           /// <param name="param1">Some Parameter.</param>
           /// <returns>What this method returns.</returns>
           /// 
           public class PDQueueResponse
           {


               [JsonProperty("count")]
               public int count { get; set; }
               [JsonProperty("next")]

               public string next { get; set; }
               [JsonProperty("previous")]

               public string previous { get; set; }
               [JsonProperty("results")]
               public List<PdQueue> PdQueue { get; set; }

               public (int, string, bool, List<int>) GetCurrentJob(string hostip, string folderlocation) // check if there is a pending run
                                                                                                         // download configuration and raw files
               {





                   var client = new RestClient(hostip);

                   client.Authenticator = new HttpBasicAuthenticator(Proteomics_Data_Processor.Properties.Settings.Default.system_user, Proteomics_Data_Processor.Properties.Settings.Default.system_pwd);




                   if (this.PdQueue.Count == 0)
                   { return (0, null, false, null); }

                   else
                   {
                       Proteomics_Data_Processor.Proteomics_Data_Processor.CleanFolder(Proteomics_Data_Processor.Properties.Settings.Default.pd_temp_folder);



                       WebClient webClient = new WebClient();

                       // download processing_method and consensus_method

                       webClient.DownloadFile(this.PdQueue.First().processing_method, folderlocation + "\\1.pdProcessingWF");

                       webClient.DownloadFile(this.PdQueue.First().consensus_method, folderlocation + "\\1.pdConsensusWF");


                       // down all the raw files file 

                       List<int> rawlist = this.PdQueue.First().rawfile;
                       foreach (int number in rawlist)
                       {
                           var request = new RestRequest(number + "/", Method.GET);

                           request.AddHeader("cache-control", "no-cache");
                           request.AddHeader("Accept", "application/json");
                           request.Parameters.Clear();

                           var response = client.Execute(request);


                           RawfileRecord rawurl = JsonConvert.DeserializeObject<RawfileRecord>(response.Content);


                           webClient.DownloadFile(rawurl.get_url(), folderlocation + "\\" + number + ".raw");

                       }
                       string run_name;
                       if (this.PdQueue.First().analysis_name != "" && this.PdQueue.First() is not null)
                       {
                           run_name = this.PdQueue.First().analysis_name;
                           run_name = run_name.Replace(" ", "_");

                       }
                       else
                       {
                           run_name = "result";

                       }
                       return (this.PdQueue.First().pk, run_name, this.PdQueue.First().keep_result, rawlist);

                   }
               }








           }

           public class PdQueue
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









           //MaxQuant related Classes




           public class MaxquantQueueResponse
           {


               [JsonProperty("count")]
               public int count { get; set; }
               [JsonProperty("next")]

               public string next { get; set; }
               [JsonProperty("previous")]

               public string previous { get; set; }
               [JsonProperty("results")]
               public List<MaxquantQueue> MaxquantQueue { get; set; }

               public int GetCurrentJob(string hostip, string folderlocation) // check if there is a pending run
                                                                              // download xml and raw files
               {



                   var client = new RestClient(hostip);

                   client.Authenticator = new HttpBasicAuthenticator(Proteomics_Data_Processor.Properties.Settings.Default.system_user, Proteomics_Data_Processor.Properties.Settings.Default.system_pwd);

                   if (this.MaxquantQueue.Count == 0)
                   { return 0; }

                   else
                   {


                       Proteomics_Data_Processor.Proteomics_Data_Processor.CleanFolder(folderlocation);

                    /*down the mqpar.xml file*/
                    WebClient webClient = new WebClient();

                    webClient.DownloadFile(this.MaxquantQueue.First().setting_xml, folderlocation + "\\mqpar.xml");

                    /*down all the raw files file*/

                    List<int> rawlist = this.MaxquantQueue.First().rawfile;
                    foreach (int number in rawlist)
                    {
                        var request = new RestRequest(number + "/", Method.GET);

                        request.AddHeader("cache-control", "no-cache");
                        request.AddHeader("Accept", "application/json");
                        //request.AddHeader("Content-Type", "multipart/form-data");
                        request.Parameters.Clear();

                        var response = client.Execute(request);


                        RawfileRecord rawurl = JsonConvert.DeserializeObject<RawfileRecord>(response.Content);


                        webClient.DownloadFile(rawurl.get_url(), folderlocation +"\\"+ number + ".raw");

                    }


                    return this.MaxquantQueue.First().pk;

                }
    }








}





public class MaxquantQueue
{
    public int pk { get; set; }
    public bool run_status { get; set; }
    public string setting_xml { get; set; }

    public List<int> rawfile { get; set; }

}





//General purpose Classes


public class RawfileRecord
{
    public int pk { get; set; }
    public string rawfile { get; set; }

    public string get_url()
    {
        return this.rawfile;

    }


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





