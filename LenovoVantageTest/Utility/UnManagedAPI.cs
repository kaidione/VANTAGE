using LenovoVantageTest.Helper;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace LenovoVantageTest.Utility
{
    class UnManagedAPI
    {
        public enum KeyMessage { WM_KEYDOWN = 0x0100, WM_KEYUP = 0x0101 }
        public enum KeyCodes { VK_RETURN = 0x0D }
        public const int CONNECT_UPDATE_PROFILE = 0x1;
        public const int CONNECT_TEMPORARY = 0x00000004;
        [DllImport("mpr.dll")]
        public static extern int WNetAddConnection2(NETRESOURCE netResource, string password, string username, uint flags);
        [DllImport("mpr.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern int WNetGetConnection([MarshalAs(UnmanagedType.LPTStr)] string lpLocalName, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpRemoteName, ref int lpnLength);
        [DllImport("mpr.dll")]
        public static extern int WNetCancelConnection2(string lpName, int dwFlags, bool fForce);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Wow64DisableWow64FsRedirection(ref IntPtr ptr);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Wow64RevertWow64FsRedirection(IntPtr ptr);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool Wow64EnableWow64FsRedirection(bool val);

        const int QueryLimitedInformation = 0x1000;
        const int ERROR_INSUFFICIENT_BUFFER = 0x7a;
        const int ERROR_SUCCESS = 0x0;

        [DllImport("kernel32.dll")]
        internal static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        static extern bool CloseHandle(IntPtr hHandle);

        [DllImport("kernel32.dll")]
        internal static extern Int32 GetApplicationUserModelId(
            IntPtr hProcess,
            ref UInt32 AppModelIDLength,
            [MarshalAs(UnmanagedType.LPWStr)] StringBuilder sbAppUserModelID);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        // When you don't want the ProcessId, use this overload and pass IntPtr.Zero for the second parameter
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        public static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        // Msg 常用值 https://www.cnblogs.com/adinet/p/6031105.html
        public const int WM_CLOSE = 0x10;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr GetFocus();
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool BringWindowToTop(IntPtr hWnd);
        [DllImport("kernel32.dll")]
        public static extern uint GetCurrentThreadId();
        //To get APP name for a WinJS APP.
        //https://stackoverflow.com/questions/35274796/how-to-find-windows-universal-app-windows-from-c-sharp
        //https://stackoverflow.com/questions/17023808/how-to-get-the-name-of-a-running-html-windows-8-app-not-wwhost
        public static String CatchWinJSAPPName(Process process)
        {
            String sResult = "";
            if (process.ProcessName.ToLower().Contains("wwahost")
            && ((Environment.OSVersion.Version.Major == 6) && (Environment.OSVersion.Version.Minor > 1)))
            {
                IntPtr ptrProcess = OpenProcess(QueryLimitedInformation, false, process.Id);
                if (IntPtr.Zero != ptrProcess)
                {
                    uint cchLen = 130; // Currently APPLICATION_USER_MODEL_ID_MAX_LENGTH = 130
                    StringBuilder sbName = new StringBuilder((int)cchLen);
                    Int32 lResult = GetApplicationUserModelId(ptrProcess, ref cchLen, sbName);
                    if (ERROR_SUCCESS == lResult)
                    {
                        sResult = sbName.ToString();
                    }
                    else if (ERROR_INSUFFICIENT_BUFFER == lResult)
                    {
                        sbName = new StringBuilder((int)cchLen);
                        if (ERROR_SUCCESS == GetApplicationUserModelId(ptrProcess, ref cchLen, sbName))
                        {
                            sResult = sbName.ToString();
                        }
                    }
                    CloseHandle(ptrProcess);
                }
            }
            return sResult;
        }
        public static bool SendKeyMessageToFocusedWindow(IntPtr _windowHandle, KeyCodes _keyCodes)
        {
            // 获取创建前台窗口的线程
            uint dwThread = GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero);
            uint appThread = GetCurrentThreadId();
            // 将前台窗口线程贴附到当前线程（也就是程序A中的调用线程）
            if (!AttachThreadInput(dwThread, appThread, true))
            {
                //将前台窗口贴附到程序A的调用线程的消息队列中，前台窗口与程序A共享键盘输入消息
                // 获取前台焦点窗口句柄
                return false;
            }
            BringWindowToTop(_windowHandle);
            // 发送消息
            if (!PostMessage(_windowHandle, (uint)KeyMessage.WM_KEYDOWN, (IntPtr)_keyCodes, IntPtr.Zero))
            {
                return false;
            }
            // 解除贴附
            if (!AttachThreadInput(dwThread, appThread, false))
            {
                return false;
            }
            return true;
        }

        public const int SW_SHOWNORMAL = 1;
        public const int SW_SHOWMINIMIZED = 2;
        public const int SW_SHOWMAXIMIZED = 3;
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        public static bool MaxmizeWindow(int _processId)
        {
            Process process = Process.GetProcessById(_processId);
            if (process == null)
            {
                return false;
            }
            ShowWindow(process.MainWindowHandle, SW_SHOWMAXIMIZED);
            return true;
        }
        public static bool MaxmizeWindow(string _processName)
        {
            Process[] processes = Process.GetProcessesByName(_processName);
            if (processes.Length == 0)
            {
                return false;
            }
            foreach (Process process in processes)
            {
                ShowWindow(process.MainWindowHandle, SW_SHOWMAXIMIZED);
            }
            return true;
        }
        //biometric
        [DllImport("Winbio.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint WinBioEnumBiometricUnits(uint Factor, ref IntPtr UnitSchemaArray,
          ref int UnitCount);

        // http://msdn.microsoft.com/en-us/library/dd401626(VS.85).aspx
        [DllImport("Winbio.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint WinBioFree(IntPtr Address);
        //Show a messagebox with timeout
        [DllImport("user32.dll")]
        public static extern int MessageBoxTimeoutA(IntPtr hwnd, string message, string caption, int wtype, int wlange, int dwtimeout);


        // https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-setwindowpos
        // hWndInsertAfter 参数可选值:
        public const int HWND_TOP = 0; //{在前面}
        public const int HWND_BOTTOM = 1;  //{在后面}
        public const int HWND_TOPMOST = -1;  //{在前面, 位于任何顶部窗口的前面}
        public const int HWND_NOTOPMOST = -2; //{在前面, 位于其他顶部窗口的后面}

        //Flags 参数可选值:
        public const uint SWP_NOSIZE = 0x0001; //{忽略 cx、cy, 保持大小}
        public const uint SWP_NOMOVE = 0x0002; //{忽略 X、Y, 不改变位置}
        public const uint SWP_NOZORDER = 0x0004; //{忽略 hWndInsertAfter, 保持 Z 顺序}
        public const uint SWP_NOREDRAW = 0x0008; //{不重绘}
        public const uint SWP_NOACTIVATE = 0x00010; //{不激活}
        public const uint SWP_FRAMECHANGED = 0x0020; //{强制发送 WM_NCCALCSIZE 消息, 一般只是在改变大小时才发送此消息}
        public const uint SWP_SHOWWINDOW = 0x0040; //{显示窗口}
        public const uint SWP_HIDEWINDOW = 0x0080; //{隐藏窗口}
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, int hWndlnsertAfter, int X, int Y, int cx, int cy, uint Flags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public static void SetWindowsActivatedViaClick(IntPtr intPtr, int px = 100, int py = 15)
        {
            UnManagedAPI.RECT rect = new UnManagedAPI.RECT();
            UnManagedAPI.GetWindowRect(intPtr, ref rect);
            VantageCommonHelper.SetMouseClick(Convert.ToString(rect.Left + px), Convert.ToString(rect.Top + py));
        }
    }
}
