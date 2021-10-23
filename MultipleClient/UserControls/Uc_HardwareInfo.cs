using LenovoMultipleCleint.Common;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using winformUI.Common;

namespace winformUI.UserControls
{
    public partial class Uc_HardwareInfo : UserControl
    {
        public Uc_HardwareInfo()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            Thread thread = new Thread(UpdateCurrentStatus);
            thread.IsBackground = true;
            thread.Start();
        }


        private void UpdateCurrentStatus()
        {
            while (true)
            {
                UpdateText();
                Thread.Sleep(1000);
            }
        }

        bool haveRunning = false;

        private void UpdateText()
        {
            try
            {
                if (!CommonFunction.IsRunning("nunit3-console"))
                {
                    Font font = new Font(new FontFamily("Cambria"), 20, FontStyle.Regular, GraphicsUnit.Pixel);
                    currentStatus.Font = font;
                    currentStatus.ForeColor = Color.Black;
                    currentStatus.Text = "Stop";
                    if (!CommonConstStr.LenovoOneToMoreFlag && haveRunning)
                    {
                        // Bamboo Run Test 
                        haveRunning = false;
                        BambooMultipleServer.ParseBambooResultSendToResult();
                    }
                }
                else
                {
                    haveRunning = true;
                    Font font = new Font(new FontFamily("Cambria"), 20, FontStyle.Bold, GraphicsUnit.Pixel);
                    currentStatus.Font = font;
                    currentStatus.ForeColor = Color.Red;
                    currentStatus.Text = "Running";
                }

            }
            catch (Exception ex)
            {

            }


        }

        public delegate void UpdateTextCallback(string text);

        // 开启进程
        private void startbtn_Click(object sender, EventArgs e)
        {
            CommonFunction.RestartTestServer();
        }

        public delegate void InvokeDelegate();
        private void button2_Click(object sender, EventArgs e)
        {
            // 停止进程
            CommonFunction.KillProcess(CommonConstStr.bambooProcess, true);
            CommonFunction.KillProcess(CommonConstStr.nuint3ConsoleProcess, true);
            CommonFunction.KillProcess(CommonConstStr.winappdriverProcess, true);
            CommonFunction.KillProcess(CommonConstStr.nuint3ConsoleProcess, true);
            CommonFunction.KillProcess(CommonConstStr.bambooProcess, true);
        }

        // re run
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (File.Exists(CommonConstStr.CommandFile))
            {
                string runStr = File.ReadAllText(CommonConstStr.CommandFile);
                Thread thread = new Thread(new ParameterizedThreadStart(BambooMultipleServer.RunCases));
                thread.IsBackground = true;
                thread.Start(runStr);
            }
            else
            {
                MessageBox.Show("No cases have been executed yet!");
            }
        }

        private void clearAndReboot_Click(object sender, EventArgs e)
        {
            CommonFunction.RestartTestServer();
            CommonFunction.RebootMachine();
        }

        private void getStatus_Click(object sender, EventArgs e)
        {
            CommonFunction.GetRunningStatus();
        }

        private void shutdown_btn_Click(object sender, EventArgs e)
        {
            CommonFunction.Shutdown();
        }
    }
}
