using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;

namespace UpgradeMultipleClient
{

    public class Common
    {
        static void CopyDirectory_CalcCount(string srcPath, string destPath, ref int fileCount)
        {
            try
            {
                if (!Directory.Exists(destPath))
                {
                    Directory.CreateDirectory(destPath);   //目标目录下不存在此文件夹即创建子文件夹
                }
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //获取目录下（不包含子目录）的文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)     //判断是否文件夹
                    {
                        if (!Directory.Exists(destPath + "\\" + i.Name))
                        {
                            Directory.CreateDirectory(destPath + "\\" + i.Name);   //目标目录下不存在此文件夹即创建子文件夹
                        }
                        CopyDirectory_CalcCount(i.FullName, destPath + "\\" + i.Name, ref fileCount);    //递归调用复制子文件夹
                    }
                    else
                    {
                        File.Copy(i.FullName, destPath + "\\" + i.Name, true);      //不是文件夹即复制文件，true表示可以覆盖同名文件
                        fileCount++;
                    }
                }
            }
            catch (Exception e)
            {
            }
        }

        public static void RestartClient()
        {

        }


        public static void RunCmdWithShell(string _cmd)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd";
            process.StartInfo.Arguments = "/c " + _cmd;
            process.Start();
            process.WaitForExit();
        }

        public static string RunCmd(string cmd, bool isEnterFlag = false, bool isAddC = false)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = "cmd.exe";
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.UseShellExecute = false;
            if (isAddC)
            {
                processStartInfo.Arguments = "/c" + cmd;
            }
            if (isEnterFlag)
            {
                processStartInfo.Verb = "Run as";
            }
            processStartInfo.CreateNoWindow = true;
            Process process = new Process
            {
                StartInfo = processStartInfo
            };
            process.Start();
            process.StandardInput.WriteLine(cmd);
            process.StandardInput.WriteLine("exit");
            process.StandardInput.AutoFlush = true;
            string output = process.StandardOutput.ReadToEnd();//get cmd output info
            process.WaitForExit();
            process.Close();
            return output;
        }

        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")] private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")] private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")] private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")] private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")] private static extern bool SetCursorPos(int X, int Y);
        [DllImport("user32.dll", EntryPoint = "GetCursorPos")] public static extern bool GetCursorPos(ref Point lpPoint);
        [DllImport("user32.dll")] public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        [DllImport("user32.dll")] private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        [DllImport("user32.dll")] private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndlnsertAfter, int X, int Y, int cx, int cy, uint Flags);
        [DllImport("user32.dll", EntryPoint = "GetWindowRect")]
        public static extern int GetWindowRect(IntPtr hwnd, ref System.Drawing.Rectangle lpRect);

        public const int MOUSEEVENTF_MOVE = 0x0001;  // 移动鼠标
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;// 模拟鼠标左键按下
        public const int MOUSEEVENTF_LEFTUP = 0x0004; //模拟鼠标左键抬起
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下
        public const int MOUSEEVENTF_RIGHTUP = 0x0010;// 模拟鼠标右键抬起
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040; //模拟鼠标中键抬起
        public const int MOUSEEVENTF_WHEEL = 0x800;//滚轮滚动
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标

        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event(System.Windows.Forms.Keys bVk, System.Windows.Forms.Keys bScan, int dwFlags, int dwExtraInfo);

        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);
        [Flags]
        public enum MouseEventFlag : uint
        {
            Move = 0x0001,
            LeftDown = 0x0002,
            LeftUp = 0x0004,
            RightDown = 0x0008,
            RightUp = 0x0010,
            MiddleDown = 0x0020,
            MiddleUp = 0x0040,
            XDown = 0x0080,
            XUp = 0x0100,
            Wheel = 0x0800,
            VirtualDesk = 0x4000,
            Absolute = 0x8000
        }

        public static void OpenCmdRunCommand(string setStr = "ms-settings:privacy-location")
        {
            try
            {
                keybd_event(Keys.LWin, 0, 0, 0);
                keybd_event(Keys.R, 0, 0, 0);
                keybd_event(Keys.LWin, 0, 2, 0);
                keybd_event(Keys.R, 0, 2, 0);
                Thread.Sleep(1500);
                SendKeys.SendWait(" " + setStr);
                Thread.Sleep(1000);
                string path = Path.Combine(Application.StartupPath, "wincmd.txt");
                string x = string.Empty;
                string y = string.Empty;
                if (!File.Exists(path))
                {
                    var okBtn = FindElementByIdIsEnabled("1");
                    if (okBtn != null)
                    {
                        var position = okBtn.Current.BoundingRectangle;
                        x = ((int)position.Left + (int)position.Width / 2).ToString();
                        y = ((int)position.Bottom - (int)position.Height / 2).ToString();
                    }
                    File.WriteAllText(path, x + "," + y);
                    SetMouseClick(x, y, false);
                }
                else
                {
                    if (File.Exists(path))
                    {
                        x = File.ReadAllText(path).Split(',')[0];
                        y = File.ReadAllText(path).Split(',')[1];
                        SetMouseClick(x, y, false);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void StartProcessWithoutWaitingExitAsAdmin(string fileName)
        {
            Process p = new Process();
            p.StartInfo.FileName = fileName;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = false;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Verb = "runas";
            p.Start();
        }

        public static void SetMouseClick(string x, string y, bool isMove = false)
        {
            int position_x = 0;
            int position_y = 0;

            if (x.Contains("."))
            {
                position_x = Convert.ToInt32(x.Split('.')[0]);
            }
            else
            {
                position_x = Convert.ToInt32(x);
            }

            if (y.Contains("."))
            {
                position_y = Convert.ToInt32(y.Split('.')[0]);
            }
            else
            {
                position_y = Convert.ToInt32(y);
            }


            Thread.Sleep(500);

            mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute, position_x * 65535 / Screen.PrimaryScreen.Bounds.Width, position_y * 65535 / Screen.PrimaryScreen.Bounds.Height, 0, new UIntPtr(0));
            Thread.Sleep(500);
            if (!isMove)
            {
                SetCursorPos(position_x, position_y);
                Thread.Sleep(500);
                mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTDOWN, position_x, position_y, 0, 0);
                mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTUP, position_x, position_y, 0, 0);
                Thread.Sleep(500);

            }
            Console.WriteLine("x=" + x + " , y= " + y);
            Debug.WriteLine("x=" + x + " , y= " + y);
        }

        public static AutomationElement FindElementByIdIsEnabled(string automationId, int timeout = 60)
        {

            AutomationElement targetElement = null;
            int index = timeout;
            try
            {
                targetElement = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, automationId), new PropertyCondition(AutomationElement.IsEnabledProperty, true)));

                while (targetElement == null)
                {
                    targetElement = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, automationId), new PropertyCondition(AutomationElement.IsEnabledProperty, true)));
                    Thread.Sleep(800);
                    if (index < 0)
                    {
                        break;
                    }
                    index--;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return targetElement;
        }

        public static bool GetRunningProcess(string processName)
        {
            try
            {
                Process[] ps0 = Process.GetProcessesByName(processName);
                if (ps0.Length > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
