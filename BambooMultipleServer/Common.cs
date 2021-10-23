using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;

namespace BambooMultipleServer
{
    public static class Common
    {
        public static void CopyDirectory_CalcCount(string srcPath, string destPath, ref int fileCount)
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
                Logger.Instance.WriteLog(string.Format("Exception:\r\n" + e.ToString()), LogType.Warning);
            }
        }

        public static void CopyDirectory(string srcPath, string destPath)
        {
            if (!Directory.Exists(srcPath))
            {
                return;
            }
            int fileCount = 0;
            CopyDirectory_CalcCount(srcPath, destPath, ref fileCount);
            Logger.Instance.WriteLog(string.Format("{0} files are copied", fileCount));
        }

        public static void RunCmd(string cmdStr)
        {
            try
            {
                var processInfo = new ProcessStartInfo("cmd.exe", "/S /C " + cmdStr)
                {
                    CreateNoWindow = true,
                    UseShellExecute = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Verb = "runas"
                };
                Process process = new Process
                {
                    StartInfo = processInfo
                };
                process.Start();
                Thread.Sleep(5000);
                process.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static void DeleteFolder(string dir)
        {
            foreach (string d in Directory.GetFileSystemEntries(dir))
            {
                if (File.Exists(d))
                {
                    try
                    {
                        FileInfo fi = new FileInfo(d);
                        if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                            fi.Attributes = FileAttributes.Normal;
                        File.Delete(d);
                    }
                    catch
                    {

                    }
                }
                else
                {
                    try
                    {
                        DirectoryInfo d1 = new DirectoryInfo(d);
                        if (d1.GetFiles().Length != 0)
                        {
                            DeleteFolder(d1.FullName);
                        }
                        Directory.Delete(d);
                    }
                    catch
                    {

                    }
                }
            }
            Console.WriteLine("Delete Succeed!Time：" + DateTime.Now.ToString());
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
                Logger.Instance.WriteLog("kill process error: " + ex.Message, LogType.Warning);
                return false;
            }
        }

        public static bool GetProcessStatus(string processName)
        {
            try
            {
                Process[] ps0 = Process.GetProcessesByName(processName);
                if (ps0.Length > 0)
                {
                    //Logger.Instance.WriteLog(string.Format("Last Plan is running."), LogType.Information);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("kill process error: " + ex.Message, LogType.Warning);
                return false;
            }
        }

        public static bool StartProcess(string runFilePath)
        {
            Process process = new Process();//创建进程对象    
            ProcessStartInfo startInfo = new ProcessStartInfo(runFilePath); // 括号里是(程序名,参数)
            process.StartInfo = startInfo;
            process.Start();
            return true;
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
        public static extern void keybd_event(Keys bVk, Keys bScan, int dwFlags, int dwExtraInfo);

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

        public static void DeleteServenLogs(string logDateDirectory, int subDay)
        {
            if (!Directory.Exists(logDateDirectory))
            {
                return;
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(logDateDirectory);
            DirectoryInfo[] allDirectory = directoryInfo.GetDirectories();
            DateTime nowDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));

            foreach (DirectoryInfo dir in allDirectory)
            {
                string dateDirInfo = dir.Name.Split('_')[1];
                DateTime dt = DateTime.ParseExact(dateDirInfo, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                dt = Convert.ToDateTime(dt.ToString("yyyy-MM-dd"));
                TimeSpan sp = nowDate.Subtract(dt);
                if (sp.TotalDays >= subDay)
                {
                    Directory.Delete(dir.FullName, true);
                }
            }
        }

    }
}
