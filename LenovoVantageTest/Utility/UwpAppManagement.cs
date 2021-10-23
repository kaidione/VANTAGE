using LenovoVantageTest.LogHelper;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace LenovoVantageTest.Utility
{
    class UwpAppManagement
    {
        // <summary>
        // Install Win10 UWP app, like Lenovo ID/Companion/Settings
        // </summary>
        // <param name="file_ps1">.ps1 file path</param>
        // <returns>true - success, false - failed</returns>
        public static bool InstallUwpApp(string file_ps1)
        {
            try
            {
                if (!System.IO.File.Exists(file_ps1))
                {
                    Logger.Instance.WriteLog("InstallUwpApp() error, cannot find file specified." + file_ps1, LogType.Error);
                    return false;
                }
                installCert(Path.GetDirectoryName(file_ps1));

                Process proc = new Process();
                proc.StartInfo.FileName = "powershell.exe";
                if (file_ps1.ToLower().EndsWith(".appxbundle"))
                {
                    Common.RunPowershellCmdlet("Add-AppPackage " + file_ps1);
                    return true;
                }
                else
                {
                    proc.StartInfo.Arguments = string.Format(" -ExecutionPolicy Unrestricted  -ExecutionPolicy bypass -noprofile -noninteractive -file \"{0}\"", file_ps1);
                }
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                proc.WaitForExit();
                proc.Close();
                return true;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("Install UWP excepiton:" + ex.Message, LogType.Error);
                return false;
            }
        }

        public static bool InstallUwpAppByBundleBtn(string file_ps1)
        {
            try
            {
                if (!File.Exists(file_ps1))
                {
                    return false;
                }
                Common.RunPowershellCmdlet("Add-AppPackage " + file_ps1);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        private static void installCert(string certDir)
        {
            string[] fileList = Directory.GetFiles(certDir, "*.cer");
            if (fileList.Length == 0)
            {
                Logger.Instance.WriteLog("no cert", LogType.Information);
                return;
            }
            string cert = fileList[0];
            X509Certificate2 certificate = new X509Certificate2(cert);
            X509Store store = new X509Store(StoreName.TrustedPeople, StoreLocation.LocalMachine);

            store.Open(OpenFlags.ReadWrite);
            store.Add(certificate);
            store.Close();
        }

        private static void Proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Logger.Instance.WriteLog(e.Data, LogType.Information);

        }

        // <summary>
        // Uninstall UWP app
        // </summary>
        // <param name="appFullName">App full name</param>
        // <returns>true - success, false - failed</returns>
        public static bool UninstallUwpApp(string appFullName)
        {
            string packageCachePath = @"C:\ProgramData\Packages\E046963F.LenovoCompanion_k1h2ywk1493x8";
            int timeOut = 0;
            try
            {
                Common.RunPowershellCmdlet("Remove-AppxPackage " + appFullName.Trim());
                /*
                Process proc = new Process();
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.Arguments = string.Format("/C powershell Remove-AppxPackage \"{0}\"", appFullName);
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
                proc.WaitForExit();
                proc.Close();
                */
                while (Directory.Exists(packageCachePath) && timeOut < 10)
                {
                    Directory.Delete(packageCachePath, true);
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    timeOut++;
                }

                return true;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("Uninstall UWP excepiton:" + ex.Message, LogType.Error);
                return false;
            }
        }

        // <summary>
        // Search UWP app by app name
        // </summary>
        // <param name="appName">App name</param>
        // <returns>true - success, false - failed</returns>
        public static UwpAppInfo SearchUwpAppByName(string appName)
        {
            UwpAppInfo app = null;
            try
            {
                string resultOutput;
                Process proc = new Process();
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.Arguments = string.Format("/C powershell Get-AppxPackage -Name \"{0}\"", appName);
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardInput = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                proc.WaitForExit();
                resultOutput = proc.StandardOutput.ReadToEnd();
                appName = appName.Replace("*", "");
                if (resultOutput.Contains(appName))
                {
                    app = new UwpAppInfo();
                    string[] appInfo = resultOutput.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    app.Name = GetAppVauleByItemName(appInfo, "Name");
                    app.Arch = GetAppVauleByItemName(appInfo, "Architecture");
                    app.Version = GetAppVauleByItemName(appInfo, "Version");
                    app.PackageFullName = GetAppVauleByItemName(appInfo, "PackageFullName");
                    app.PackageFamilyName = GetAppVauleByItemName(appInfo, "PackageFamilyName");
                    app.InstallLocation = GetAppVauleByItemName(appInfo, "InstallLocation");
                    app.PublisherId = GetAppVauleByItemName(appInfo, "PublisherId");
                }
                proc.Close();
                return app;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("SearchUwpAppByName UWP excepiton:" + ex.Message, LogType.Error);
                return null;
            }
        }
        public static UwpAppInfo SearchDriverByNames(string appName)
        {
            UwpAppInfo app = null;
            try
            {
                string resultOutput;
                Process proc = new Process();
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.Arguments = string.Format("/C powershell Get-AppxPackage -Name \"{0}\"", appName);
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardInput = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();
                proc.WaitForExit();
                resultOutput = proc.StandardOutput.ReadToEnd();
                appName = appName.Replace("*", "");
                if (resultOutput.Contains(appName))
                {
                    app = new UwpAppInfo();
                    string[] appInfo = resultOutput.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    app.Name = GetAppVauleByItemName(appInfo, "Name");
                    app.Arch = GetAppVauleByItemName(appInfo, "Architecture");
                    app.Version = GetAppVauleByItemName(appInfo, "Version");
                    app.PackageFullName = GetAppVauleByItemName(appInfo, "PackageFullName");
                    app.PackageFamilyName = GetAppVauleByItemName(appInfo, "PackageFamilyName");
                    app.InstallLocation = GetAppVauleByItemName(appInfo, "InstallLocation");
                    app.PublisherId = GetAppVauleByItemName(appInfo, "PublisherId");
                }
                proc.Close();
                return app;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("SearchUwpAppByName UWP excepiton:" + ex.Message, LogType.Error);
                return null;
            }
        }
        static string GetAppVauleByItemName(string[] sourceStr, string itemName)
        {
            string value = string.Empty;
            for (int i = 0; i < sourceStr.Length; i++)
            {
                if (sourceStr[i].Trim() == itemName)
                {
                    if (itemName == "InstallLocation")
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendFormat("{0}:{1}", sourceStr[i + 1], sourceStr[i + 2]);
                        value = sb.ToString();
                    }
                    else
                    {
                        value = sourceStr[i + 1];
                    }
                    break;
                }
            }
            return value;
        }
    }

    public class UwpAppInfo
    {
        string name;
        string arch;
        string version;
        string packageFullName;
        string packageFamilyName;
        string installLocation;
        string publisherId;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Arch
        {
            get
            {
                return arch;
            }

            set
            {
                arch = value;
            }
        }

        public string Version
        {
            get
            {
                return version;
            }

            set
            {
                version = value;
            }
        }

        public string PackageFullName
        {
            get
            {
                return packageFullName;
            }

            set
            {
                packageFullName = value;
            }
        }

        public string PackageFamilyName
        {
            get
            {
                return packageFamilyName;
            }

            set
            {
                packageFamilyName = value;
            }
        }

        public string InstallLocation
        {
            get
            {
                return installLocation;
            }

            set
            {
                installLocation = value;
            }
        }

        public string PublisherId
        {
            get
            {
                return publisherId;
            }

            set
            {
                publisherId = value;
            }
        }
    }
}
