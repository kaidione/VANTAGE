using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using winformUI.Common;

namespace SingleStart
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                CommonConstStr.CurrentMachneIp = CommonFunction.GetLocalIPAddress();
                CommonFunction.SetShareUserPasswordexpires();
                Process instance = RunningInstance();
                if (instance == null)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    /**
                     * 当前用户是管理员的时候，直接启动应用程序
                     * 如果不是管理员，则使用启动对象启动程序，以确保使用管理员身份运行
                     */
                    //获得当前登录的Windows用户标示
                    System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
                    System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
                    //判断当前登录用户是否为管理员
                    if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
                    {
                        //如果是管理员，则直接运行
                        Application.Run(winformUI.LenovoMultipleClient.GetInstance());
                    }
                    else
                    {
                        //创建启动对象
                        try
                        {
                            Process p = new Process();
                            p.StartInfo.UseShellExecute = true;
                            p.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
                            p.StartInfo.FileName = Application.ExecutablePath;
                            p.StartInfo.Verb = "runas";
                            p.Start();
                        }
                        catch
                        {
                            return;
                        }
                        //退出
                        Application.Exit();
                    }
                }
                else
                {
                    HandleRunningInstance(instance);
                }
            }
            catch (Exception ex)
            {

            }
        }


        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        private static void HandleRunningInstance(Process instance)
        {
            // 确保窗口没有被最小化或最大化 
            ShowWindowAsync(instance.MainWindowHandle, 4);
            // 设置真实例程为foreground  window  
            SetForegroundWindow(instance.MainWindowHandle);// 放到最前端 
        }

        private static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    // 确保例程从EXE文件运行 
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        return process;
                    }
                }
            }
            return null;
        }
    }
}