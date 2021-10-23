using interop.UIAutomationCore;
using LenovoVantageTest.LogHelper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Utility;
using LenovoVantageTest.Utility.UIAImplementation;
using Microsoft.Win32;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace LenovoVantageTest
{
    /// <summary>
    /// This library exposes all ofen-used API for testers ,with which you can implement your own test cases
    /// </summary>
    public class VantageBase : BasePage

    {
        public static bool debug = false;
        List<WindowsElement> lastFoundElements;
        protected static string language = Constants.uiLanguage;
        public List<WindowsElement> getLastFoundElements() { return lastFoundElements; }
        protected const int timeout = 5;
        bool doScreenshot = true;
        public WindowsDriver<WindowsElement> session;
        public static DateTime curTime = DateTime.Parse("1970/01/01 00:00:00");
        #region OS related
        public string GetCurrentCountryName()
        {
            return Geo.GetGeoNameById(Geo.GetCurrentGeoId());
        }
        /// <summary>
        /// with ths you can set country in your pc 
        /// </summary>
        /// <param name="country_name"></param>
        public void SetCountry(string country_name)
        {
            Geo.SetCountryOrRegion(country_name);
        }
        public void SetLauguage(string language)
        {
            Language lan = new Language();
            lan.SetALanguageAsFirstOneInLanguageList(language);

        }
        public void SetALanguageAsFirstOneInLanguageList(string language)
        {
            Language lan = new Language();
            lan.SetALanguageAsFirstOneInLanguageList(language);

        }

        public void DisconnectNetWork()
        {
            //Networking.DisconnectNetwork(Networking.NetworkType.Wireless);
            WlanNet.DisconnectNetwork();
        }


        public void ConnectNetWork()
        {
            //Networking.ConnectNetwork(Networking.NetworkType.Wireless); 
            WlanNet.ConnectNetwork("lenovo");
            System.Threading.Thread.Sleep(1000);
            DateTime dateTime = DateTime.Now;
            while ((DateTime.Now - dateTime).TotalSeconds < 120)
            {
                if (NetWork.checkNetWorkConnected("www.baidu.com"))
                {
                    string BackupDir = Path.Combine(Environment.CurrentDirectory) + @"\Data\TestHistory\";
                    if (Directory.Exists(BackupDir))
                    {
                        break;
                    }
                    Logger.Instance.WriteLog("wait for share folder connect", LogType.Information);
                    System.Threading.Thread.Sleep(2 * 1000);
                }
                System.Threading.Thread.Sleep(1000);
            }

        }
        #region expose some useful tools
        public bool EnterS3()
        {
            DateTime wakeUpTime = DateTime.Now, sleepTime = DateTime.Now;
            PowerManagement.Sleep(DateTime.Now.AddSeconds(90), (pm, args) =>
            {
                wakeUpTime = DateTime.Now;
            });
            System.Threading.Thread.Sleep(15000);
            if ((wakeUpTime - sleepTime).TotalSeconds < 2)
            {
                //Sleeping fails
                return false;
            }
            return true;
        }
        //Takes more time to wakeup than S3
        public bool EnterS4()
        {
            DateTime wakeUpTime = DateTime.Now, sleepTime = DateTime.Now;
            PowerManagement.Hibernate(DateTime.Now.AddMinutes(1), (pm, args) =>
            {
                wakeUpTime = DateTime.Now;
            });
            System.Threading.Thread.Sleep(15000);
            if ((wakeUpTime - sleepTime).TotalSeconds < 2)
            {
                //Sleeping fails
                return false;
            }
            return true;
        }
        public void KillProcess(string _processName)
        {
            if (_processName.Equals(""))
            {
                return;
            }
            foreach (var item in Process.GetProcessesByName(_processName))
            {
                Common.KillProcess(item.Id, true);
            }
        }
        //Marcus:Vantage的一些安装包的证书已经expired，为了装上，就必须修改时间到指定时间。
        public bool AdjustLocalTimeToYYYYMMDDHHMMSS(int _year, int _month, int _day, int _hour = 0, int _min = 0, int _sec = 0)
        {
            curTime = DateTime.Now;

            DateTime settime = new DateTime(_year, _month, _day, _hour, _min, _sec);
            Common.SystemTime sysTime = new Common.SystemTime();
            sysTime.FromDateTime(settime);
            Common.SetLocalTime(ref sysTime);
            return true;

        }
        //Marcus:有的Case可能需要往前后调整一点时间。
        public bool AdjustLocalTimeAheadSeconds(int _sec = 0)
        {
            if (_sec > 0)
            {
                return false;
            }
            curTime = DateTime.Now;

            Common.SystemTime sysTime = new Common.SystemTime();
            sysTime.FromDateTime(curTime.AddSeconds(_sec));
            Common.SetLocalTime(ref sysTime);
            return true;
        }
        public bool AdjustLocalTimeBehindSeconds(int _sec = 0)
        {
            if (_sec < 0)
            {
                return false;
            }
            curTime = DateTime.Now;

            Common.SystemTime sysTime = new Common.SystemTime();
            sysTime.FromDateTime(curTime.AddSeconds(_sec));
            Common.SetLocalTime(ref sysTime);
            return true;
        }
        //Marcus:调整时间任务结束后，可以改回来
        public bool AdjustLocalTimeBack()
        {
            if (curTime.Year != 1970)
            {
                DateTime settime = curTime;
                Common.SystemTime sysTime = new Common.SystemTime();
                sysTime.FromDateTime(settime);
                Common.SetLocalTime(ref sysTime);
                return true;
            }
            return false;

        }
        public string ScreenShot()
        {
            return UIAHelper.ScreenShot();
        }


        #endregion
        #endregion
        #region Test Process an fitsharp related ,DSL 
        public void TerminateProcessWhenInterruptedAndScreenshot(bool _yes)
        {
            if (_yes)
            {
                doScreenshot = true;
            }
            doScreenshot = false;
        }
        /// <summary>
        /// 此function不起任何作用，但閲讀case時會很容易理解
        /// </summary>
        public void Given()
        {

        }

        /// <summary>
        ///  此function不起任何作用，但閲讀case時會很容易理解
        /// </summary>
        public void When()
        {

        }

        /// <summary>
        /// 此function不起任何作用，但閲讀case時會很容易理解
        /// </summary>
        public void Then()
        {

        }
        /// <summary>
        /// 等待指定N秒，不做任何事
        /// </summary>
        public void Sleep(int _timeout_milliseconds)
        {
            System.Threading.Thread.Sleep(_timeout_milliseconds);
        }

        public string ScreenShotAndDisplayUsingHtmlLink()
        {
            string filename = DateTime.Now.ToString(Constants.DATETIMEFORMATFORPATH) + ".jpg";
            string filePath = Path.Combine(Constants.logPath, filename);
            try
            {
                CaptureScreen.PrintThumbScreenShot(filePath);
            }
            catch (System.ComponentModel.Win32Exception win32Exp)
            {
                if (win32Exp.Message.Contains("The handle is invalid"))
                {
                    return "Is the screen locked or are you remotely debugging ? Under this circumstance screenshot is forbidden";
                }
            }
            return string.Format("{0}<img src='Logs/{1}' />", filePath, filename);
        }
        #endregion



        private void GetXpathParam(string xpName, ref string _pageName, ref string _customizedElementName)
        {
            _pageName = "";
            _customizedElementName = "";
            if (xpName != null && !xpName.Equals(""))
            {
                string[] array = xpName.Split('.');
                if (array.Length == 1)
                {
                    _customizedElementName = array[0];
                }
                else if (array.Length == 2)
                {
                    _pageName = array[0];
                    _customizedElementName = array[1];
                }
            }

        }

        public void GetGraphicsCardHardwareIds(string type, out string vendorId, out string deviceId, out string graphicsResult)
        {
            deviceId = string.Empty;
            vendorId = string.Empty;
            graphicsResult = DesktopPowerManagementHelper.RunCmd("powershell.exe -command \"" + VantageConstContent.GraphicsCardHardwareIds + "\"");
            if (graphicsResult == string.Empty)
            {
                return;
            }
            string[] resultLine = graphicsResult.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < resultLine.Length; i++)
            {
                if (resultLine[i].Trim() == "PNPDeviceID" && type == "Vendor")
                {
                    vendorId = resultLine[i + 1].Split(new char[] { '_', '&' }, StringSplitOptions.RemoveEmptyEntries)[1];
                }
                if (resultLine[i].Trim() == "PNPDeviceID" && type == "Device")
                {
                    deviceId = resultLine[i + 1].Split(new char[] { '_', '&' }, StringSplitOptions.RemoveEmptyEntries)[3];
                }
            }
        }

        public void PrintScreen(string _prefix_caseName_stepName = "")
        {
            string screenShotfilepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Logs\\");

            screenShotfilepath = screenShotfilepath + (_prefix_caseName_stepName.Equals("") ? "" : _prefix_caseName_stepName + "_") + DateTime.Now.ToString(Constants.DATETIMEFORMATFORPATH) + ".jpg";
            CaptureScreen.PrintScreen(screenShotfilepath);
        }
        /// <summary>
        /// 改變系統當前地區|國家
        /// </summary>
        /// <param name="_geoID">每個地區|國家都有一個ID,
        /// 常用地區：巴西-32，德國-94,意大利-118,中國-45,美國-244,日本-122，英國-242
        /// </param>
        /// <example>
        /// wiki例子，切換到中國，|Switch Region|45|
        /// </example>
        /// pls refer Geo.cs for more GeoId
        public void SwitchRegion(int _geoID)
        {
            Utility.Geo.SetCountryOrRegion(_geoID);
        }
        #region Vantage related , excluding pure UIA operation
        /// <summary>
        /// 指定Vantage内容來自哪個服務器，默認連qa服務器. 服务器list参考2020/06/01 Monica发的mail
        /// </summary>
        /// <param name="_server">
        /// you can use "" OR "dev" OR "stg" . with "" ,qa server is specified
        /// </param>
        /// <example>
        ///wiki案例， |modifyConfigJsonFile|!-dev-!|
        /// </example>
        public bool modifyConfigJsonFile(string _server = "qa-2")
        {
            string server = "{{\"webURL\":\"https://vantage.csw.lenovo.com/\"}}";

            if (_server != null && !_server.ToLower().Trim().Equals("") && _server.ToLower().Trim().Equals("beta"))
            {
                server = string.Format("{{\"webURL\":\"https://vantage-beta.csw.lenovo.com/\"}}");
            }
            if (_server != null && !_server.ToLower().Trim().Equals("") && _server.ToLower().Trim().Equals("dev"))
            {
                server = string.Format("{{\"webURL\":\"https://vantage.csw-dev.lenovo.com/\"}}");
            }
            if (_server != null && !_server.ToLower().Trim().Equals("") && _server.ToLower().Trim().Equals("dev-2"))
            {
                server = string.Format("{{\"webURL\":\"https://vantage-2.csw-dev.lenovo.com/\"}}");
            }
            if (_server != null && !_server.ToLower().Trim().Equals("") && _server.ToLower().Trim().Equals("pt"))
            {
                server = string.Format("{{\"webURL\":\"https://vantage-pt.csw-stage.lenovo.com/\"}}");
            }
            if (_server != null && !_server.ToLower().Trim().Equals("") && _server.ToLower().Trim().Equals("qa"))
            {
                server = string.Format("{{\"webURL\":\"https://vantage.csw-qa.lenovo.com/\"}}");
            }
            if (_server != null && !_server.ToLower().Trim().Equals("") && !_server.ToLower().Trim().Equals("") && _server.ToLower().Trim().Equals("qa-2"))
            {
                server = string.Format("{{\"webURL\":\"https://vantage-2.csw-qa.lenovo.com/\"}}");
            }
            if (_server != null && !_server.ToLower().Trim().Equals("") && _server.ToLower().Trim().Equals("stage"))
            {
                server = string.Format("{{\"webURL\":\"https://vantage.csw-stage.lenovo.com/\"}}");
            }
            UwpAppInfo app = UwpAppManagement.SearchUwpAppByName(Constants.PackageName4Vantage3);
            if (app == null || app.Name.Equals(""))
            {
                Console.WriteLine("Error: NO Vantage installed , generating config.json failed");
                return false;
            }
            string stateFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Packages\" + UwpAppManagement.SearchUwpAppByName(Constants.PackageName4Vantage3).PackageFamilyName.Trim() + @"\LocalState");
            if (!Directory.Exists(stateFolder))
            {
                Console.WriteLine($"Error: NO folder {stateFolder} , generating config.json failed");
                return false;
            }
            string vantage3ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Packages\" + UwpAppManagement.SearchUwpAppByName(Constants.PackageName4Vantage3).PackageFamilyName.Trim() + @"\LocalState\config.json");

            if (File.Exists(vantage3ConfigPath))
            {
                File.Delete(vantage3ConfigPath);
            }
            File.AppendAllText(vantage3ConfigPath, server);
            Console.WriteLine("Set web server to " + server + " in " + vantage3ConfigPath);
            return true;
        }
        public bool IsConfigJsonSet2(string _server)
        {
            string production = string.Format("{{\"webURL\":\"https://vantage.csw.lenovo.com/\"}}");
            string vantage3ConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Packages\" + UwpAppManagement.SearchUwpAppByName(Constants.PackageName4Vantage3).PackageFamilyName.Trim() + @"\LocalState\config.json");
            if (!File.Exists(vantage3ConfigPath))
            {
                return false;
            }
            using (FileStream fileStream = new FileStream(vantage3ConfigPath, FileMode.Open, FileAccess.Read))
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                string configJson = streamReader.ReadToEnd();
                if (_server == null || _server.Equals(""))
                {
                    if (configJson.Contains(production))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else if (configJson.Contains(_server))
                {
                    return true;
                }
            }
            return false;
        }
        //修改hosts文件
        public bool RefillHostsFile(string _newContent)
        {
            string newserver = _newContent;

            using (FileStream fs = new FileStream(Common.hostsPath, FileMode.Truncate, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("#Marcus: Below are generated from automation");
                sw.WriteLine("#staging server");
                sw.WriteLine("#10.103.208.62 filedownload.lenovo.com");
                sw.WriteLine("#testing server");
                sw.WriteLine("#10.103.208.61 filedownload.lenovo.com");
                if (!_newContent.ToLower().Trim().Equals(""))
                {
                    sw.WriteLine(string.Format("{0} filedownload.lenovo.com", newserver));
                }
                else
                {
                    sw.WriteLine("10.103.208.61 filedownload.lenovo.com");
                }
                sw.Flush();
                System.Threading.Thread.Sleep(1500);
            }
            return true;
        }
        public bool LaunchVantageWithProtocol()
        {
            if (ElementExistUsingCustomXPath(string.Format("/Window[@Name='{0}']", Constants.VantageTitle)))
            {
                Console.WriteLine("Vantage exists already, no need to launch it again.");
                return true;
            }
            Sleep(5000);
            Common.StartProtocol(Constants.companionProtocol, VantageConstContent.VantageProcessName);
            Console.WriteLine($"Launch Vantage With Protocol({Constants.companionProtocol})...");
            Sleep(2000);
            UnManagedAPI.MaxmizeWindow("ApplicationFrameHost");
            Console.WriteLine("Maxmize Vantage Window.");
            return true;

        }

        public void LaunchVantageWithoutMaxVantage()
        {
            if (ElementExistUsingCustomXPath(string.Format("/Window[@Name='{0}']", Constants.VantageTitle)))
            {
                return;
            }
            Common.StartProtocol(Constants.companionProtocol, VantageConstContent.VantageProcessName);
            Sleep(1000);
        }

        public void CloseVantageProcess()
        {
            Common.KillProcess(VantageConstContent.VantageProcessName, true);
            Console.WriteLine($"Close Vantage by killing Process: {VantageConstContent.VantageProcessName}...");

        }

        public bool installVantage(string path)
        {
            bool ret = false;
            UwpAppInfo comp = UwpAppManagement.SearchUwpAppByName(Constants.appName);
            string installPackageFilePath = path.Contains(":") ? path : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            string installPackageFolder = installPackageFilePath.Substring(0, installPackageFilePath.LastIndexOf('\\'));
            if (!File.Exists(installPackageFilePath))
            {
                string fileName = "";
                string[] extension = { ".ps1", ".appxbundle" };
                foreach (var item in Directory.EnumerateFiles(installPackageFolder, "*.*", SearchOption.TopDirectoryOnly).Where(file => extension.Any(ext => ext == Path.GetExtension(file))))
                {
                    fileName = item.Substring(item.LastIndexOf('/') + 1);
                }
                if (fileName.Equals(""))
                {
                    throw new FileNotFoundException();
                }
                installPackageFilePath = fileName;
            }
            if (comp == null)
            {
                Logger.Instance.WriteLog("Vantage is not installed. install it now...");
                ret = UwpAppManagement.InstallUwpApp(installPackageFilePath);
            }
            else
            {
                Logger.Instance.WriteLog("Vantage has been installed already. Version is " + comp.Version);
                ret = true;
            }
            return ret;
        }
        public bool OverInstallVantage(string path)
        {
            bool ret = false;
            UwpAppInfo comp = UwpAppManagement.SearchUwpAppByName(Constants.appName);
            if (comp == null)
            {
                Logger.Instance.WriteLog("OverInstall. Vantage is not installed?? install it now...");

            }
            else
            {
                Logger.Instance.WriteLog("OverInstall. Vantage has an installed one. Version is " + comp.Version);

            }
            return ret = UwpAppManagement.InstallUwpApp(path.Contains(":") ? path : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path));
        }
        public void uninstallVantage()
        {
            UwpAppInfo comp = UwpAppManagement.SearchUwpAppByName(Constants.PackageName4Vantage3);
            if (comp == null)
            {
                return;
            }
            else
            {
                //2020/06/07，Marcus:我发现Legion Y740(gaming机器)上powershell重新安装Vantage时失败。
                //然后发现c:\users\share\AppData\Local\Packages\E046963F.LenovoCompanion_k1h2ywk1493x8\settings\settings.dat 被system进程锁定。
                //无法通过handle.exe工具关闭(invalid handle)。这个问题概率很高，后来我发现重启imc后这个问题得以解决.我想应该是imc的一个bug，但一般用户要重新安装Vantage概率不大，
                //即使要重新安装，也已经reboot过，这时文件已经unlock，不会出现这个问题了。
                if (IMCHelper.Singleton.IMCServiceIsRunning())
                {
                    IMCHelper.Singleton.RestartIMCService();
                }
                CloseVantageProcess();
                UwpAppManagement.UninstallUwpApp(comp.PackageFullName);
                foreach (string item in Directory.EnumerateDirectories("C:\\Program Files\\WindowsApps"))
                {
                    if (item.Contains(Constants.PackageName4Vantage3))
                    {
                        try
                        {
                            Directory.Delete(item, true);
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
            }
        }
        public bool IsVantageInstalled()
        {
            UwpAppInfo comp = UwpAppManagement.SearchUwpAppByName(Constants.PackageName4Vantage3);
            if (comp == null)
            {
                return false;
            }
            return true;
        }
        public string GetVantageShellVersion()
        {
            UwpAppInfo comp = UwpAppManagement.SearchUwpAppByName(Constants.PackageName4Vantage3);
            if (comp == null)
            {
                return "";
            }
            return comp.Version.Trim();
        }
        public bool IsVantageServiceInstalled()
        {
            System.ServiceProcess.ServiceController vantageService = new System.ServiceProcess.ServiceController("LenovoVantageService");
            if (vantageService == null)
            {
                return false;
            }
            return true;
        }
        #endregion

        #region functions about IMC
        public bool InstallIMC(string _packagePath)
        {
            return IMCHelper.Singleton.InstallIMC(_packagePath);
        }
        public void uninstallIMC()
        {
            CloseVantageProcess();
            IMCHelper.Singleton.UninstallIMC();
        }
        #endregion

        #region 使用COM UIA的功能 
        /*Author:Marcus*/
        public int ElementIsEnabledUsingXpathInDB(string _xpName)
        {
            return ElementIsEnabledUsingXpathInDB(_xpName, 5);
        }

        /*Author:Marcus*/
        /// <summary>
        /// 简化版。使用DB里指定的XPath搜索一个GUI element，判断他是否Enable了
        /// </summary>
        /// <param name="_xpName">格式必须是  Page名.Element名</param>
        /// <param name="_timeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns>0=Disabled, 1=Enabled , -1=NO Element found</returns>
        public int ElementIsEnabledUsingXpathInDB(string _xpName, int _timeoutInSeconds = 5)
        {
            string newXpath = GetXpathFromAutomatioID(_xpName);
            return ElementIsEnabledUsingCustomXPath(newXpath, _timeoutInSeconds);
        }

        /*Author:Marcus*/
        public int ElementIsEnabledUsingCustomXPath(string _xpath)
        {
            return UIAHelper.ElementIsEnabledUsingCustomXPath(_xpath, 5);
        }

        /*Author:Marcus*/
        /// <summary>
        /// 简化版。使用DB里指定的XPath搜索一个GUI element，判断他是否Enable了
        /// </summary>
        /// <param name="_xpath">完整的自定义XPath</param>
        /// <param name="_timeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns>0=Disabled, 1=Enabled , -1=NO Element found</returns>
        public int ElementIsEnabledUsingCustomXPath(string _xpath, int _timeoutInSeconds = 5)
        {
            return UIAHelper.ElementIsEnabledUsingCustomXPath(_xpath, _timeoutInSeconds);
        }
        public int ElementIsToggledUsingXpathInDB(string _xpName)
        {
            return ElementIsToggledUsingXpathInDB(_xpName, 5);
        }
        /// <summary>
        /// 简化版。使用DB里指定的XPath搜索一个GUI element，判断他是否Checked了
        /// </summary>
        /// <param name="_xpName">格式必须是  Page名.Element名</param>
        /// <param name="_timeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns>0=Disabled, 1=Enabled , -1=NO Element found</returns>
        public int ElementIsToggledUsingXpathInDB(string _xpName, int _timeoutInSeconds = 5)
        {
            string newXpath = GetXpathFromAutomatioID(_xpName);
            return ElementIsToggleedUsingCustomXPath(newXpath, _timeoutInSeconds);
        }
        public int VantageElementIsToggledUsingAutomationId(string _automationID)
        {
            return UIAHelper.ElementIsToggleedUsingCustomXPath($"/Window[@Name='{Constants.VantageTitle}']//*[@AutomationId='{_automationID}']");
        }
        public int VantageElementIsToggledUsingName(string _name)
        {
            return UIAHelper.ElementIsToggleedUsingCustomXPath($"/Window[@Name='{Constants.VantageTitle}']//*[@Name='{_name}']");
        }

        /*Author:Marcus*/
        public int ElementIsToggledUsingCustomXPath(string _xpath)
        {
            return UIAHelper.ElementIsToggledUsingCustomXPath(_xpath, 5);
        }

        /*Author:Marcus*/
        public int ElementIsToggledUsingCustomXPathWithProcess(string _xpath, string _processName)
        {

            foreach (var item in Process.GetProcessesByName(_processName))
            {
                string xpath = string.Format(_xpath, item.Id);
                return UIAHelper.ElementIsToggledUsingCustomXPath(xpath, 5);
            }
            return -1;
        }
        /*Author:Marcus*/
        /// <summary>
        /// 简化版。使用DB里指定的XPath搜索一个GUI element，判断他是否Checked了
        /// </summary>
        /// <param name="_xpath">完整的自定义XPath</param>
        /// <param name="_timeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns>0=Disabled, 1=Enabled , -1=NO Element found</returns>
        public int ElementIsToggleedUsingCustomXPath(string _xpath, int _timeoutInSeconds = 5)
        {
            return UIAHelper.ElementIsToggledUsingCustomXPath(_xpath, _timeoutInSeconds);
        }

        /*Author:Marcus*/
        public bool ElementExistUsingXPathInDB(string _xpName)
        {
            return ElementExistUsingXPathInDBWithinSeconds(_xpName, 10);
        }
        /// <summary>
        /// 简化版。使用DB里指定的XPath搜索一个GUI element
        /// </summary>
        /// <param name="_xpName">格式必须是 Page名.Element名</param>
        /// <param name="_timeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns>0=Disabled, 1=Enabled , -1=NO Element found</returns>
        public bool ElementExistUsingXPathInDBWithinSeconds(string _xpName, int _timeoutInSeconds = 5)
        {
            string newXpath = GetXpathFromAutomatioID(_xpName);
            bool result = ElementExistUsingCustomXPath(newXpath, _timeoutInSeconds);
            return result;
        }
        //Marcus:有时我们想检查一个GUI在指定时间内不存在。
        public bool ElementNotExistUsingCustomXPathInSecondsWithSpecificProcessName(string _fullXpath, int _sec, string _processName)
        {
            return UIAHelper.ElementNotExistUsingCustomXPathInSecondsWithSpecificProcessName(_fullXpath, _sec, _processName);
        }

        /*Author:Marcus*/
        public bool ElementNotExistUsingCustomXPathInSeconds(string _xpath, int _sec)
        {
            return UIAHelper.ElementNotExistUsingCustomXPathInSeconds(_xpath, _sec);

        }
        /* Author: Marcus
         * Desc: Variant of VantageElementAnyExistUsingAutomationId(). Giving default timeout limit of 10 seconds
         */
        public bool VantageElementAnyExistUsingAutomationId(string[] _AutomationIds)
        {
            return VantageElementAnyExistUsingAutomationId(_AutomationIds, 10);
        }
        /* Author: Marcus
         * Desc: Variant of ElementAnyExistUsingCustomXPath(). It's a convenient way for anyone who only need search any GUI element on Vantage
         */
        public bool VantageElementAnyExistUsingAutomationId(string[] _AutomationIds, int _timeoutInSeconds = 10)
        {
            string[] xpathes = new string[_AutomationIds.Length];
            for (int ctr = 0; ctr < _AutomationIds.Length; ctr++)
            {
                xpathes[ctr] = $"/Window[@Name='{Constants.VantageTitle}']//*[@AutomationId='{_AutomationIds[ctr]}']";
            }
            return UIAHelper.ElementAnyExistUsingCustomXPath(xpathes, _timeoutInSeconds);
        }
        /* Author: Marcus
        * Desc: Variant of ElementAnyExistUsingCustomXPath(). Giving default timeout limit of 10 seconds
        */
        public bool ElementAnyExistUsingCustomXPath(string[] _xpathes)
        {
            return UIAHelper.ElementAnyExistUsingCustomXPath(_xpathes, 10);
        }

        /* Author: Marcus
        * Desc:  Given a few elements which may be mutually exclusive ,Any element is shown , then the job is DONE.
        *       For example .  Tutorial and Dashboard ar emutally exclusive , Either Tutorial page is shown , or Dashboard page is shown . Anyone is shown , it is considered Vantage is ready to use.
        */
        public bool ElementAnyExistUsingCustomXPath(string[] _xpathes, int _timeoutInSeconds = 10)
        {
            return UIAHelper.ElementAnyExistUsingCustomXPath(_xpathes, _timeoutInSeconds);

        }

        /*Author:Marcus*/
        public int VantageElementAnyExistUsingCustomXPath_WhichOneMeetsCondition(string[] _AutomationIds)
        {

            return VantageElementAnyExistUsingCustomXPath_WhichOneMeetsCondition(_AutomationIds, 10);
        }

        /*Author:Marcus*/
        public int VantageElementAnyExistUsingCustomXPath_WhichOneMeetsCondition(string[] _AutomationIds, int _timeoutInSeconds = 10)
        {
            string[] xpathes = new string[_AutomationIds.Length];
            for (int ctr = 0; ctr < _AutomationIds.Length; ctr++)
            {
                xpathes[ctr] = $"/Window[@Name='{Constants.VantageTitle}']//*[@AutomationId='{_AutomationIds[ctr]}']";
            }
            return UIAHelper.ElementAnyExistUsingCustomXPath_WhichOneMeetsCondition(xpathes, _timeoutInSeconds);
        }

        /*Author:Marcus*/
        public int ElementAnyExistUsingCustomXPath_WhichOneMeetsCondition(string[] _xpathes)
        {
            return UIAHelper.ElementAnyExistUsingCustomXPath_WhichOneMeetsCondition(_xpathes, 10);
        }

        /* Author: Marcus
        * Desc:  Given a few elements which may be mutually exclusive ,Any element is shown , then the job is DONE.
        *       For example .  Tutorial and Dashboard ar emutally exclusive , Either Tutorial page is shown , or Dashboard page is shown . Anyone is shown , it is considered Vantage is ready to use.
        *       But , we need to know who is shown ,return the index in XPath array.
        */
        public int ElementAnyExistUsingCustomXPath_WhichOneMeetsCondition(string[] _xpathes, int _timeoutInSeconds = 10)
        {
            return UIAHelper.ElementAnyExistUsingCustomXPath_WhichOneMeetsCondition(_xpathes, _timeoutInSeconds);

        }
        /*Author: Marcus
         *Desc:   Variant of ElementAllExistUsingCustomXPath() , Giving default timeout limit
         */
        public bool ElementAllExistUsingCustomXPath(string[] _xpathes)
        {
            return UIAHelper.ElementAllExistUsingCustomXPath(_xpathes, 10);
        }

        /* Author: Marcus
       * Desc: Given a few elements which may co-exist ,So long as all elements are shown , then the job is DONE.
       *       For example .  on Dashboard page , only when Dashboar | Device | Security | Support are shown ,it is considered Vantage is ready to use.
       */
        public bool ElementAllExistUsingCustomXPath(string[] _xpathes, int _timeoutInSeconds = 10)
        {
            return UIAHelper.ElementAllExistUsingCustomXPath(_xpathes, _timeoutInSeconds);

        }

        /*Author:Marcus*/
        public bool ElementExistUsingCustomXPath(string _xpath)
        {
            return UIAHelper.ElementExistUsingCustomXPath(_xpath, 10);

        }

        /*Author:Marcus*/
        public bool VantageElementExistUsingXPath(string _xpath)
        {
            return UIAHelper.ElementExistUsingCustomXPath(Path.Combine(Constants.VantageTitle, _xpath), 10);

        }

        /*Author:Marcus*/
        public bool VantageElementExistUsingAutomationId(string _autoid)
        {
            return VantageElementExistUsingAutomationId(_autoid, 10);

        }

        /*Author:Marcus*/
        public bool VantageElementExistUsingAutomationId(string _autoid, int _timeoutInSeconds = 10)
        {
            return UIAHelper.ElementExistUsingCustomXPath(string.Format("/Window[@Name='{0}']", Constants.VantageTitle) + string.Format("//*[@AutomationId='{0}']", _autoid), _timeoutInSeconds);

        }

        /*Author:Marcus*/
        public bool VantageElementExistUsingName(string _name)
        {
            return VantageElementExistUsingName(_name, 10);

        }

        /*Author:Marcus*/
        public bool VantageElementExistUsingName(string _name, int _timeoutInSeconds = 10)
        {
            return UIAHelper.ElementExistUsingCustomXPath(string.Format("/Window[@Name='{0}']", Constants.VantageTitle) + string.Format("//*[@Name='{0}']", _name), _timeoutInSeconds);

        }
        /*Author:Marcus
         *Desc: for NLS , the searching name could be very long and contains  double|sing quote chars , using XPath is not a good idea , searching it using direct function is better.
         */
        public bool VantageElementExistUsingLonName(string _name, int _timeoutInSeconds = 10)
        {
            CUIAutomation8 cUIAutomation8 = new CUIAutomation8();
            List<IUIAutomationElement> result = UIAHelper.SearchForElementsAndDoSth(string.Format("/Window[@Name='{0}']", Constants.VantageTitle), x => { return true; }, _timeoutInSeconds);
            if (result.Count == 0)
            {
                return false;
            }
            DateTime past = DateTime.Now;
            while (past.AddSeconds(_timeoutInSeconds) > DateTime.Now)
            {
                foreach (var item in result)
                {
                    if (UIARawTreeTraverser.SearchNameInApp(item, _name).Count > 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /*Author:Marcus
       *Desc: When we click sth , a browser may showes up , the URL in address keeps changing until it is stable. We want to know final address without hard waiting.
       */
        public bool ElementExistUsingAutomationIDAndValueRegularExpressionAlongWithProcessId(string _automationID, string _valueRegularExpression, string _processName, int _timeoutInSeconds)
        {
            Process[] processes = Process.GetProcessesByName(_processName);
            if (processes.Length == 0)
            {
                return false;
            }
            DateTime past = DateTime.Now;
            while (past.AddSeconds(_timeoutInSeconds) > DateTime.Now)
            {
                foreach (var one_process in processes)
                {
                    List<IUIAutomationElement> result = UIAHelper.SearchForElementsAndDoSth(string.Format("/Window[@ProcessId='{0}']", one_process.Id) + string.Format("//*[@AutomationId='{0}']", _automationID), _timeoutInSeconds);
                    if (result.Count > 0)
                    {
                        Regex regex = new Regex(_valueRegularExpression);
                        foreach (IUIAutomationElement item in result)
                        {
                            var pattern = item.GetCurrentPattern((int)ControlPatternIdentifiers.UIA_ValuePatternId);
                            if (pattern == null)
                            {
                                continue;
                            }
                            String actualValue = ((IUIAutomationValuePattern)pattern).CurrentValue.ToString();
                            if (regex.IsMatch(actualValue))
                            {
                                Console.WriteLine($"Actual value({actualValue}) = Expect value({_valueRegularExpression})");
                                return true;
                            }
                            else
                            {
                                Console.WriteLine($"Actual value({actualValue}) != Expect value({_valueRegularExpression})");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Failed to search Elements with automationId({_automationID}) and processName({_processName}) in {_timeoutInSeconds} seconds! Result.Count is {result.Count}");
                    }
                }

            }
            return false;

        }


        /*Author: Marcus*/

        public bool ElementExistUsingCustomXPathInSecondsWithSpecificProcessName(string _fullXpath, int _timeout, String _processName)
        {
            return UIAHelper.ElementExistUsingCustomXPathInSecondsWithSpecificProcessName(_fullXpath, _timeout, _processName);
        }


        /*Author: Marcus*/
        public bool ElementExistUsingCustomXPathWithSpecificProcessName(string _fullXpath, String _processName)
        {
            return UIAHelper.ElementExistUsingCustomXPathInSecondsWithSpecificProcessName(_fullXpath, 10, _processName);

        }


        /*Author: Marcus*/
        /// <summary>
        /// 简化版。使用自定义XPath搜索一个GUI element
        /// </summary>
        /// <param name="_xpath">完整的自定义XPath</param>
        /// <param name="_timeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns>true=找到了 ,false=没找到</returns>
        public bool ElementExistUsingCustomXPath(string _xpath, int _timeoutInSeconds = 10)
        {
            return UIAHelper.SearchForElementsAndDoSth(_xpath, x => { return true; }, _timeoutInSeconds).Count > 0;

        }
        #region click GUI element using UIA


        /*Author: Marcus*/
        public string ClickElementUsingXPathInDB(string _xpName)
        {
            return ClickElementUsingXPathInDB(_xpName, 15);
        }
        /// <summary>
        /// 简化版。使用DB里指定的XPath搜索一个GUI element
        /// </summary>
        /// <param name="_xpName">格式必须是 Page名.Element名 in VantageAutomationIDs.json </param>
        /// <param name="_timeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns>0=Disabled, 1=Enabled , -1=NO Element found</returns>
        public string ClickElementUsingXPathInDB(string _xpName, int _timeoutInSeconds = 10)
        {
            string newXpath = GetXpathFromAutomatioID(_xpName);
            string result = ClickElementUsingCustomXPath(newXpath, _timeoutInSeconds);
            return result;
        }


        /*Author: Marcus*/
        public string ClickElementUsingCustomXPath(string _xpath)
        {
            return ClickElementUsingCustomXPath(_xpath, 5);
        }


        /*Author: Marcus*/
        public string VantageClickElementtUsingAutomationId(string _autoid, int timeout = 90)
        {
            return ClickElementUsingCustomXPath(string.Format("/Window[@Name='{0}']", Constants.VantageTitle) + string.Format("//*[@AutomationId='{0}']", _autoid), timeout);

        }

        /*Author: Marcus*/
        public string VantageClickElementtUsingName(string _name4GUIElement)
        {
            return VantageClickElementtUsingName(_name4GUIElement, 10);

        }


        /*Author: Marcus*/
        public string VantageClickElementtUsingName(string _name4GUIElement, int _timeoutInSeconds = 10)
        {
            return ClickElementUsingCustomXPath(string.Format("/Window[@Name='{0}']", Constants.VantageTitle) + string.Format("//*[@Name='{0}']", _name4GUIElement), _timeoutInSeconds);

        }


        /*Author: Marcus*/
        //Marcus:一些Window本身的是没有AutomationId的，而Name会根据语言变化。比如Win10本身的Settings。
        //为了定位，就要在Xpath中用到ProcessId，而ProcessId则要在C#中根据ProcessName替换。
        public string ClickElementUsingCustomXPathWithSpecificProcessName(string _fullXpath, String _processName)
        {

            return ClickElementUsingCustomXPathWithSpecificProcessName(_fullXpath, 10, _processName);
        }
        public string ClickElementUsingCustomXPathWithSpecificProcessName(string _fullXpath, int _timeoutInSeconds, String _processName)
        {
            if (!_fullXpath.Contains("{0}"))
            {
                Logger.Instance.WriteLog("ClickElementUsingCustomXPathWithSpecificProcessName() , incorrect placeholder", LogType.Error);
                return false.ToString();
            }
            String processId = "";
            foreach (var item in Process.GetProcessesByName(_processName))
            {
                processId = item.Id.ToString();
                break;
            }
            if (processId.Equals(""))
            {
                Logger.Instance.WriteLog("ClickElementUsingCustomXPathWithSpecificProcessName() , NO such process at background running", LogType.Warning);
                return false.ToString();
            }
            string result = ClickElementUsingCustomXPath(string.Format(_fullXpath, processId), _timeoutInSeconds);
            return result;
        }
        /// <summary>
        /// 简化版。使用自定义XPath搜索一个GUI element
        /// </summary>
        /// <param name="_xpath">完整的自定义XPath</param>
        /// <param name="_timeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns>true=找到了 ,false=没找到</returns>
        public string ClickElementUsingCustomXPath(string _xpath, int _timeoutInSeconds = 10)
        {
            bool result = UIAHelper.SearchForElementsAndDoSth(_xpath, UIAActions.click, _timeoutInSeconds).Count > 0;
            if (doScreenshot)
            {
                return ScreenShotAndDisplayUsingHtmlLink();
            }
            return result.ToString();
        }

        public bool ElementIsCollapseUsingXpathInDB(string _xpName, int _timeoutInSeconds = 10)
        {
            string newXpath = GetXpathFromAutomatioID(_xpName);
            return ElementIsCollapseUsingCustomXPath(newXpath, _timeoutInSeconds);
        }

        public bool ElementIsCollapseUsingCustomXPath(string _xpath, int _timeoutInSeconds)
        {
            int state = -1;
            bool result = UIAHelper.SearchForElementsAndDoSth(_xpath,
                (founElement) =>
                {
                    state = Convert.ToInt32(UIAHelper.GetCollapseState(founElement));
                    return true;
                }
            , _timeoutInSeconds).Count > 0;
            return state == 0;
        }

        #endregion
        #region Move mouse to GUI element with information from UIA
        public string MouseFocusElementUsingXPathInDB(string _xpName)
        {
            return MouseFocusElementUsingXPathInDB(_xpName, 15);
        }
        /// <summary>
        /// 简化版。使用DB里指定的XPath搜索一个GUI element
        /// </summary>
        /// <param name="_xpName">格式必须是 Page名.Element名</param>
        /// <param name="_timeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns>0=Disabled, 1=Enabled , -1=NO Element found</returns>
        public string MouseFocusElementUsingXPathInDB(string _xpName, int _timeoutInSeconds = 5)
        {
            string _customizedElementName = "";
            string _pageName = "";
            GetXpathParam(_xpName, ref _pageName, ref _customizedElementName);
            DateTime now = DateTime.Now;
            XPath4Vantage3 xpath = DBOperation4UIAuto.QueryXPath(language, _customizedElementName, _pageName)[0];
            string newXpath = string.Format("/Window[@Name='{0}']{1}", Constants.VantageTitle, xpath.XPath);
            string result = MouseFocusElementUsingCustomXPath(newXpath, _timeoutInSeconds);
            return result;
        }
        public string MouseFocusElementUsingCustomXPath(string _xpath)
        {
            return MouseFocusElementUsingCustomXPath(_xpath, 5);
        }
        public string VantageMouseFocusElementtUsingAutomationId(string _autoid)
        {
            return MouseFocusElementUsingCustomXPath(string.Format("/Window[@Name='{0}']", Constants.VantageTitle) + string.Format("//*[@AutomationId='{0}']", _autoid), 5);

        }

        public string VantageMouseClickElementtUsingAutomationId(string _autoid)
        {
            return SimulateMouseClickGUIElement(string.Format("/Window[@Name='{0}']", Constants.VantageTitle) + string.Format("//*[@AutomationId='{0}']", _autoid), 5).ToString();

        }
        //Marcus:一些Window本身的是没有AutomationId的，而Name会根据语言变化。比如Win10本身的Settings。
        //为了定位，就要在Xpath中用到ProcessId，而ProcessId则要在C#中根据ProcessName替换。
        public string MouseFocusElementUsingCustomXPathWithSpecificProcessName(string _fullXpath, String _processName)
        {

            return MouseFocusElementUsingCustomXPathWithSpecificProcessName(_fullXpath, 10, _processName);
        }
        public string MouseFocusElementUsingCustomXPathWithSpecificProcessName(string _fullXpath, int _timeoutInSeconds, String _processName)
        {
            if (!_fullXpath.Contains("{0}"))
            {
                Logger.Instance.WriteLog("ClickElementUsingCustomXPathWithSpecificProcessName() , incorrect placeholder", LogType.Error);
                return false.ToString();
            }
            String processId = "";
            foreach (var item in Process.GetProcessesByName(_processName))
            {
                processId = item.Id.ToString();
                break;
            }
            if (processId.Equals(""))
            {
                Logger.Instance.WriteLog("ClickElementUsingCustomXPathWithSpecificProcessName() , NO such process at background running", LogType.Warning);
                return false.ToString();
            }
            string result = MouseFocusElementUsingCustomXPath(string.Format(_fullXpath, processId), _timeoutInSeconds);
            return result;
        }
        /// <summary>
        /// 简化版。使用自定义XPath搜索一个GUI element
        /// </summary>
        /// <param name="_xpath">完整的自定义XPath</param>
        /// <param name="_timeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns>true=找到了 ,false=没找到</returns>
        public string MouseFocusElementUsingCustomXPath(string _xpath, int _timeoutInSeconds = 5)
        {
            bool result = UIAHelper.SearchForElementsAndDoSth(_xpath, UIAActions.mouseMove, _timeoutInSeconds).Count > 0;
            if (doScreenshot)
            {
                return ScreenShotAndDisplayUsingHtmlLink();
            }
            return result.ToString();
        }
        #endregion
        #region Retrieve value
        public string ElementGetValueUsingXPathInDB(string _xpName)
        {
            return ElementGetValueUsingXPathInDB(_xpName, 10);
        }
        /// <summary>
        /// 简化版。使用DB里指定的XPath搜索一个GUI element ，读取它的value并返回
        /// </summary>
        /// <param name="_xpName">格式必须是 Page名.Element名</param>
        /// <param name="_timeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns>0=Disabled, 1=Enabled , -1=NO Element found</returns>
        public string ElementGetValueUsingXPathInDB(string _xpName, int _timeoutInSeconds = 10)
        {
            string _customizedElementName = "";
            string _pageName = "";
            GetXpathParam(_xpName, ref _pageName, ref _customizedElementName);
            DateTime now = DateTime.Now;
            XPath4Vantage3 xpath = DBOperation4UIAuto.QueryXPath(language, _customizedElementName, _pageName)[0];
            string newXpath = string.Format("/Window[@Name='{0}']{1}", Constants.VantageTitle, xpath.XPath);
            return ElementGetValueUsingCustomXPath(newXpath, _timeoutInSeconds);
        }
        public string ElementGetValueUsingCustomXPathWithProcessName(string _fullXpath, string _processName)
        {
            return UIAHelper.ElementGetValueUsingCustomXPathWithProcessName(_fullXpath, _processName, 5);
        }
        public string ElementGetValueUsingCustomXPathWithProcessName(string _fullXpath, string _processName, int _timeoutInSeconds)
        {
            return UIAHelper.ElementGetValueUsingCustomXPathWithProcessName(_fullXpath, _processName, _timeoutInSeconds);
        }

        /*Author :Marcus*/
        public string VantageElementGetNameUsingAutomationId(string _autoid)
        {
            return VantageElementGetNameUsingAutomationId(_autoid, 10);

        }

        /*Author :Marcus*/
        public string VantageElementGetNameUsingAutomationId(string _autoid, int _timeoutInSeconds = 10)
        {
            return UIAHelper.ElementGetNameUsingCustomXPath(string.Format("/Window[@Name='{0}']//*[@AutomationId='{1}']", Constants.VantageTitle, _autoid), 10);

        }

        public string ElementGetValueUsingCustomXPath(string _xpath)
        {
            return UIAHelper.ElementGetValueUsingCustomXPath(_xpath, 5);
        }
        /// <summary>
        /// 简化版。使用自定义XPath搜索一个GUI element，读取它的value并返回
        /// </summary>
        /// <param name="_xpath">完整的自定义XPath</param>
        /// <param name="_timeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns>true=找到了 ,false=没找到</returns>
        public string ElementGetValueUsingCustomXPath(string _xpath, int _timeoutInSeconds = 10)
        {
            return UIAHelper.ElementGetValueUsingCustomXPath(_xpath, _timeoutInSeconds);
        }
        public string ElementGetNameUsingCustomXPath(string _xpath)
        {
            return UIAHelper.ElementGetNameUsingCustomXPath(_xpath, 5);
        }
        /// <summary>
        /// 简化版。使用自定义XPath搜索一个GUI element，读取它的value并返回
        /// </summary>
        /// <param name="_xpath">完整的自定义XPath</param>
        /// <param name="_timeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns>true=找到了 ,false=没找到</returns>
        public string ElementGetNameUsingCustomXPath(string _xpath, int _timeoutInSeconds = 10)
        {
            return UIAHelper.ElementGetNameUsingCustomXPath(_xpath, _timeoutInSeconds);
        }
        #endregion
        #region Set value
        public bool ElementSetValueUsingXPathInDB(string _xpName, string value)
        {
            return ElementSetValueUsingXPathInDB(_xpName, value, 5);
        }

        public bool ElementSetValueUsingXPathInDB(string _xpName, string value, int _timeoutInSeconds = 5)
        {
            object[] param = { value };
            string _customizedElementName = "";
            string _pageName = "";
            GetXpathParam(_xpName, ref _pageName, ref _customizedElementName);
            DateTime now = DateTime.Now;
            XPath4Vantage3 xpath = DBOperation4UIAuto.QueryXPath(language, _customizedElementName, _pageName)[0];
            string newXpath = string.Format("/Window[@Name='{0}']{1}", Constants.VantageTitle, xpath.XPath);
            bool result = UIAHelper.SearchForElementsAndDoSth(newXpath, UIAActions.setValue, _timeoutInSeconds, param).Count > 0;
            return result;
        }
        //对于某些需要通过ProcessName去定位Window的情况，如下处理
        public bool ElementSetValueUsingCustomXPathWithSpecificProcessName(string _value, string _fullXpath, string _processName)
        {
            if (!_fullXpath.Contains("{0}"))
            {
                return false;
            }
            String processId = "";
            foreach (var item in Process.GetProcessesByName(_processName))
            {
                processId = item.Id.ToString();
                break;
            }
            if (processId.Equals(""))
            {
                return false;
            }
            return ElementSetValueUsingCustomXPath(string.Format(_fullXpath, processId), _value, 5);
        }
        public bool ElementSetValueUsingCustomXPath(string _Xpath, string value)
        {
            return ElementSetValueUsingCustomXPath(_Xpath, value);
        }
        public bool ElementSetValueUsingCustomXPath(string _Xpath, string value, int _timeoutInSeconds = 5)
        {
            object[] param = { value };
            DateTime now = DateTime.Now;
            bool result = UIAHelper.SearchForElementsAndDoSth(_Xpath, UIAActions.setValue, _timeoutInSeconds, param).Count > 0;
            return result;
        }
        public bool SimulateMouseClickGUIElement(string _xpath)
        {
            return SimulateMouseClickGUIElement(_xpath, 5);
        }
        /*有些GUI可能没有正确暴露接口，导致无法invoke或setValue，这时用鼠标点击可以临时workaround.缺点是任何一个window挡住要操作的GUI，click()就错误了。*/
        public bool SimulateMouseClickGUIElement(string _xpath, int _timeoutInSeconds = 5)
        {

            List<IUIAutomationElement> uIAUtomationElements = UIAHelper.SearchForElementsAndDoSth(_xpath, x => { return true; }, _timeoutInSeconds);
            if (uIAUtomationElements.Count == 0)
            {
                return false;
            }
            float zoomfactor = CaptureScreen.GetScalingFactor();
            tagRECT boundRectangle = uIAUtomationElements[0].CurrentBoundingRectangle;
            int[] centeric = { (int)((boundRectangle.left + boundRectangle.right) * zoomfactor) / 2, (int)((boundRectangle.top + boundRectangle.bottom) * zoomfactor) / 2 };

            if (centeric[0] < 0 || centeric[1] < 0)
            {
                return false;
            }
            if (centeric[0] > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width * zoomfactor) //without zoom factor , 1920*1080 is actually 1536*864
            {
                return false;
            }
            if (centeric[1] > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height * zoomfactor)
            {
                return false;
            }
            KeyboardMouse.DoMouseMove(centeric[0], centeric[1]);
            KeyboardMouse.DoMouseClick(centeric[0], centeric[1]);
            return true;
        }
        public bool SimulateMouseClickGUIElementAndInput(string _xpath, string _input, int _timeoutInSeconds = 5)
        {

            List<IUIAutomationElement> uIAUtomationElements = UIAHelper.SearchForElementsAndDoSth(_xpath, x => { return true; }, _timeoutInSeconds);
            if (uIAUtomationElements.Count == 0)
            {
                return false;
            }
            float zoomfactor = CaptureScreen.GetScalingFactor();
            tagRECT boundRectangle = uIAUtomationElements[0].CurrentBoundingRectangle;
            int[] centeric = { (int)((boundRectangle.left + boundRectangle.right) * zoomfactor) / 2, (int)((boundRectangle.top + boundRectangle.bottom) * zoomfactor) / 2 };

            if (centeric[0] < 0 || centeric[1] < 0)
            {
                return false;
            }
            if (centeric[0] > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width)
            {
                return false;
            }
            if (centeric[1] > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height)
            {
                return false;
            }
            KeyboardMouse.DoMouseMove(centeric[0], centeric[1]);
            KeyboardMouse.DoMouseClick(centeric[0], centeric[1]);
            KeyboardMouse.InputText(_input);
            return true;
        }
        /*有些GUI必须要通过process name找到，但UIA只提供了用ProcessId的方式查找，要转换一次. 可是会出现同名process的情况，每个都要处理*/
        public bool SimulateMouseClickGUIElementAgainstSpecificProcess(string _xpath, string _processName, int _timeoutInSeconds = 5)
        {
            if (!_xpath.Contains("{0}"))
            {
                return false;
            }
            Process[] processes = Process.GetProcessesByName(_processName);
            if (processes.Length == 0)
            {
                return false;
            }
            foreach (Process process in processes)
            {
                SimulateMouseClickGUIElement(string.Format(_xpath, process.Id), _timeoutInSeconds);
            }
            return true;
        }
        public bool SimulateMouseClickGUIElementAndInputAgainstSpecificProcess(string _xpath, string _processName, string _input, int _timeoutInSeconds)
        {
            if (!_xpath.Contains("{0}"))
            {
                return false;
            }
            Process[] processes = Process.GetProcessesByName(_processName);
            if (processes.Length == 0)
            {
                return false;
            }
            foreach (Process process in processes)
            {
                SimulateMouseClickGUIElementAndInput(string.Format(_xpath, process.Id), _input, _timeoutInSeconds);
            }
            return true;
        }
        public bool SimulateMouseClickGUIElement4Vantage(string _xpath, int _timeoutInSeconds = 5)
        {
            return SimulateMouseClickGUIElement(Path.Combine("/Window[@Name='Lenovo Vantage']", _xpath), _timeoutInSeconds);
        }
        public bool SimulateMouseClickGUIElementAndInput4Vantage(string _xpath, string _input, int _timeoutInSeconds)
        {

            return SimulateMouseClickGUIElementAndInput(Path.Combine("/Window[@Name='Lenovo Vantage']", _xpath), _input, _timeoutInSeconds);
        }
        public bool SimulateMouseClickGUIElementUsingAutomationId4Vantage(string _automationId, int _timeoutInSeconds = 5)
        {
            return SimulateMouseClickGUIElement(string.Format("/Window[@Name='Lenovo Vantage']//*[@AutomationId='{0}']", _automationId), _timeoutInSeconds);
        }
        public bool SimulateMouseClickGUIElementAndInputUsingAutomationId4Vantage(string _automationId, string _input, int _timeoutInSeconds = 5)
        {

            return SimulateMouseClickGUIElementAndInput(string.Format("/Window[@Name='Lenovo Vantage']//*[@AutomationId='{0}']", _automationId), _input, _timeoutInSeconds);
        }
        #endregion

        #endregion
        #region enable debugging log
        public void EnableVantageServiceLog()
        {
            RegistryHelp.SetRegistryKeyValuePlus(Constants.vantage_shell_log, "Trace");
            RegistryHelp.SetRegistryKeyValuePlus(Constants.vantage_service_log, "Trace");
            RegistryHelp.SetRegistryKeyValuePlus(Constants.vantage_InstallHelper_log, "Trace");
            RegistryHelp.SetRegistryKeyValuePlus(Constants.vantage_LenovoVantageSetup_log, "Trace");
            RegistryHelp.SetRegistryKeyValuePlus(Constants.vantage_LenovoVantageServiceUninstall_log, "Trace");
        }
        #endregion


        private static string GetXpathFromAutomatioID(string autoIDPath)
        {
            JObject autoIDObj = VantageAutomationIDCollector.Instance.GetVantageAutomationIDs();
            JToken jtoken = autoIDObj as JToken;
            string automationID = GetJsonValue(jtoken, autoIDPath);
            string xpath = string.Format("/Window[@Name='{0}']//*[@AutomationId='{1}']", Constants.VantageTitle, automationID);
            return xpath;
        }

        public static string GetJsonValue(JToken obj, string key)
        {
            if (obj == null)
            {
                return "";
            }
            JToken jsrc = obj;
            try
            {
                var reader = jsrc.CreateReader();
                while (reader.Read())
                {
                    if (reader.Value != null)
                    {
                        Regex reg = new Regex(@"" + key.Replace(".", "\\."));
                        if (reg.IsMatch(reader.Path))
                        {
                            return jsrc.SelectToken(reader.Path).ToString();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return "";
            }
            return "";
        }

        public int IsGamingMachine()
        {
            string name = "System.Profile.Gaming";
            RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            RegistryKey gamingTag = registryKey.OpenSubKey(Constants.gamingTag, false);
            if (gamingTag == null)
            {
                return -1;
            }
            object tag = gamingTag.GetValue(name);
            if (tag != null)
            {
                return 1;
            }

            return 0;
        }

    }
}
