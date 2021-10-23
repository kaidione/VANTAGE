using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using winformUI.Common;

namespace winformUI.UserControls
{
    public partial class Uc_ViewLog : UserControl
    {
        public List<string> allLogFiles = new List<string>();

        public BackgroundWorker logBackgroundWorker = new BackgroundWorker();

        public Uc_ViewLog()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        public void viewLog_Load(object sender, EventArgs e)
        {
            logBackgroundWorker.DoWork += new DoWorkEventHandler(background_work);
            logBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(log_RunWorkerCompleted);
            logBackgroundWorker.WorkerSupportsCancellation = true;
            logBackgroundWorker.RunWorkerAsync();
        }

        private void log_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            logBackgroundWorker.CancelAsync();
        }

        private void background_work(object sender, DoWorkEventArgs e)
        {
            freshLog();
        }

        public void DeleteServenLogs(int subDay)
        {
            if (!Directory.Exists(CommonConstStr.LogDirectory))
            {
                return;
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(CommonConstStr.LogDirectory);
            DirectoryInfo[] allDirectory = directoryInfo.GetDirectories();
            DateTime nowDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
            foreach (DirectoryInfo dir in allDirectory)
            {
                DateTime dt = DateTime.ParseExact(dir.Name, "yyyy-MM-dd", System.Globalization.CultureInfo.CurrentCulture);
                TimeSpan sp = nowDate.Subtract(dt);
                if (sp.TotalDays > subDay)
                {
                    Directory.Delete(dir.FullName, true);
                }
            }
        }

        public void freshLog()
        {
            if (viewListBox.Items.Count > 0)
            {
                viewListBox.Items.Clear();
            }

            DeleteServenLogs(7);
            if (!Directory.Exists(CommonConstStr.LogDirectory))
            {
                return;
            }
            Director(CommonConstStr.LogFilePath, allLogFiles);
            foreach (string info in allLogFiles)
            {
                viewListBox.Items.Add(info);
                string[] lines = File.ReadAllLines(info);
                for (int i = lines.Length - 1; i >= 0; i--)
                {
                    viewListBox.Items.Add(lines[i]);
                }

                viewListBox.Items.Add("\r\n");
            }

        }

        static void Director(string dir, List<string> allLogFiles)
        {
            DirectoryInfo d = new DirectoryInfo(dir);
            FileSystemInfo[] fsinfos = d.GetFileSystemInfos();
            // sort them by creation time
            Array.Sort<FileSystemInfo>(fsinfos, delegate (FileSystemInfo a, FileSystemInfo b)
            {
                return b.LastWriteTime.CompareTo(a.LastWriteTime);
            });
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                if (fsinfo is DirectoryInfo)
                {
                    Director(fsinfo.FullName, allLogFiles);
                }
                else
                {
                    if (!allLogFiles.Contains(fsinfo.FullName))
                    {
                        allLogFiles.Add(fsinfo.FullName);
                    }
                }
            }
        }

        public void download_btn_Click(object sender, EventArgs e)
        {
            string downloadLogPath = @"C:\OneToMoreDownloadLog";
            if (!Directory.Exists(downloadLogPath))
            {
                Directory.CreateDirectory(downloadLogPath);
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < viewListBox.Items.Count; i++)
            {
                string logStr = viewListBox.Items[i].ToString();
                sb.Append(logStr);
                if (!string.IsNullOrEmpty(logStr))
                {
                    sb.AppendLine();
                }
            }
            downloadLogPath = Path.Combine(downloadLogPath, CommonFunction.GetClientDatetimeStr() + "_log.txt");

            File.WriteAllText(downloadLogPath, sb.ToString());
            MessageBox.Show("下载成功: " + downloadLogPath);
        }

        public void fresh_btn_Click(object sender, EventArgs e)
        {
            freshLog();
        }

        public void close_log_btn_Click(object sender, EventArgs e)
        {
            if (null != this.viewListBox.SelectedItem)
            {
                string str = this.viewListBox.SelectedItem.ToString();
                MessageBox.Show(str);
            }
            else
            {
                MessageBox.Show("请选择要查看的Log信息！");
            }

        }

        private void deleteAllLog_Click(object sender, EventArgs e)
        {
            try
            {
                Directory.Delete(CommonConstStr.LogDirectory, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("清除失败：" + ex.Message);
                return;
            }

            freshLog();

        }
    }
}
