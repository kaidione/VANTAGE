using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace UpgradeMultipleClient
{
    class Program
    {
        public static bool Do()
        {
            try
            {
                // 1 Stop 
                KillProcessExist();
                Thread.Sleep(1400);
                //2、begin Update
                Update();
                Thread.Sleep(1400);
                //3、Start
                Start();
                Thread.Sleep(1400);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private static void KillProcessExist()
        {
            // 杀掉  进程
            KillProcess("LenovoMultipleClient", true);
            KillProcess("nginx", true);
            KillProcess("nunit3-console", true);
        }

        static void Main(string[] args)
        {
            string type = "restartclient";
            if (args.Length > 0)
            {
                type = args[0];
            }
            switch (type)
            {
                case "update":
                    Do();
                    Thread.Sleep(1000);
                    break;
                case "restartclient":
                    KillProcess("LenovoMultipleClient", true);
                    Thread.Sleep(1000);
                    Start();
                    break;
            }
        }

        private static string LenovoMultipleClientEXE = "LenovoMultipleClient.exe";
        private static string multipleClientFile = Path.Combine(Application.StartupPath, "LenovoMultipleClient.exe");
        private static string downloadMultiplePath = Path.Combine(Application.StartupPath, "LenovoMultipleClientdownloadbk");

        private static void Start()
        {
            Process.Start(multipleClientFile);
        }

        private static void Update()
        {
            // 删除 文件 

            FileSystemInfo fileinfo = new FileInfo(multipleClientFile);
            if (fileinfo.Exists)
            {
                fileinfo.Delete();
            }
            // Rename File
            File.Move(downloadMultiplePath, multipleClientFile);
        }

        public static bool KillProcess(string processName, bool needVerify)
        {
            try
            {
                Process[] ps0 = Process.GetProcessesByName(processName);
                if (ps0.Length == 0)
                {
                    return false;
                }
                foreach (Process p in ps0)
                {
                    p.Kill();
                    p.WaitForExit();
                    Thread.Sleep(1500);
                }
                if (needVerify)
                {
                    Process[] ps1 = Process.GetProcessesByName(processName);
                    if (ps1.Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void StartProcess(string fileName, string param = "")
        {
            Process p = new Process();
            p.StartInfo.FileName = fileName;
            p.StartInfo.Arguments = param;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = false;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.WaitForExit();
        }

    }
}

