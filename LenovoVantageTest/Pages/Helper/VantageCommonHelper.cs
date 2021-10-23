using LenovoVantageTest.Commands;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Utility;
using Microsoft.Win32;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;
using System.Xml.Serialization;
using TangramTest.Utility;
using Windows.UI.Notifications;
using static LenovoVantageTest.Pages.Helper.ProgrammableLogicControllersHelper;

namespace LenovoVantageTest.Helper
{
    public class VantageCommonHelper
    {
        private static string _showGauge = @"C:\ProgramData\Lenovo\ImController\Plugins\LenovoBatteryGaugePackage\x64\ShowBatteryGauge";
        private static string _hideGauge = @"C:\ProgramData\Lenovo\ImController\Plugins\LenovoBatteryGaugePackage\x64\HideBatteryGauge";
        public static string DischargeStatusPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Tools\\DischargeStatus.exe");
        private static string _appiumPath = @"C:\Program Files (x86)\Appium";
        private static string _androidHome = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\android-sdk-windows");
        private static string _tools = _androidHome + @"\tools";
        private static string _platTools = _androidHome + @"\platform-tools";
        private static string _sourceADBFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\bj_appium\adb.js");
        private static string _sourceAndroidFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\bj_appium\android.js");
        private static string _dectAndroidFile = @"C:\Program Files (x86)\Appium\node_modules\appium\lib\devices\android\android.js";
        private static string _dectADBFile = @"C:\Program Files (x86)\Appium\node_modules\appium\node_modules\appium-adb\lib\adb.js";
        public static string _vantagePath = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Packages\E046963F.LenovoCompanion_k1h2ywk1493x8";
        public static string _leconfigjsonpath = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Packages\E046963F.LenovoSettingsforEnterprise_k1h2ywk1493x8\LocalState\config.json";
        private static string _leconfigjsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\Tools\LEconfig\config.json");

        public static WindowsDriver<WindowsElement> LaunchSystemUwp(string appId)
        {
            var factory = new BaseTestClass();
            if (appId.Contains("E046963F.Lenovo") == false)
            {
                return factory.LaunchApplication(appId);
            }
            var appInstance = factory.LaunchWinApplication(LoadSpecificElementFile.ApplicationId);
            return appInstance.Session;
        }

        public static bool CurrentMachineThanVersion(int version, bool isLessthan = false)
        {
            RegistryKey softwareRegedit = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            if (isLessthan)
            {
                if (Convert.ToInt32(softwareRegedit.GetValue("CurrentBuildNumber")) <= version)
                {
                    return true;
                }
            }
            else
            {
                if (Convert.ToInt32(softwareRegedit.GetValue("CurrentBuildNumber")) >= version)
                {
                    return true;
                }
            }

            return false;
        }

        public static void OObeNetVantage30(WindowsDriver<WindowsElement> vantageSession, bool needClick, bool isCloseAlertWindow = true)
        {
            bool isLeVersion = false;
            bool is20H1 = false;
            bool isLowVersion = false;
            int lowVersion = 18363;
            long lowVersions = 10018363418;
            WindowsElement windowsElement;
            if (!VantageConstContent.NotLEMask)
            {
                isLeVersion = true;
            }
            RegistryKey softwareRegedit = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            if (Convert.ToInt32(softwareRegedit.GetValue("CurrentBuildNumber")) <= lowVersion)
            {
                var ver = DesktopPowerManagementHelper.RunCmd("ver", false, true);
                string verSion = ver.Substring(ver.LastIndexOf(" ") + 1, ver.IndexOf("]") - ver.LastIndexOf(" ") - 1).Replace(".", "");
                if (lowVersions >= Convert.ToInt64(verSion))
                {
                    isLowVersion = true;
                }
            }

            bool getMachineIsGaming = NerveCenterHelper.GetMachineIsGaming();

            if (softwareRegedit.GetValue("CurrentBuildNumber").ToString().Equals("19041"))
            {
                is20H1 = true;
            }
            if (!isLeVersion)
            {
                if (vantageSession == null)
                {
                    return;
                }

                windowsElement = FindElementByXPath(vantageSession, VantageConstContent.InstallProgress, 1);
                while (windowsElement != null)
                {
                    windowsElement = FindElementByXPath(vantageSession, VantageConstContent.InstallProgress, 1);
                    Thread.Sleep(500);
                }

                windowsElement = FindElementByXPath(vantageSession, VantageConstContent.OoBeNextButton, 120);
                if (windowsElement != null)
                {
                    windowsElement.Click();
                    int times = 50;
                    windowsElement = FindElementByXPath(vantageSession, VantageConstContent.OoBeNextButton, 1);
                    while (windowsElement != null && times > 0)
                    {
                        windowsElement = FindElementByXPath(vantageSession, VantageConstContent.OoBeNextButton, 1);
                        windowsElement?.Click();
                        Thread.Sleep(500);
                        times--;
                    }
                }

                int trytime = 3;
                do
                {
                    //ObBeSegmentChoose
                    windowsElement = FindElementByXPath(vantageSession, VantageConstContent.ObBeSegmentChoose, 5);
                    windowsElement?.Click();
                    windowsElement = FindElementByXPath(vantageSession, VantageConstContent.OoBeDoneButton, 30);
                    if (windowsElement != null && windowsElement.Enabled)
                    {
                        break;
                    }
                    trytime--;
                } while (trytime >= 0);

                if (!getMachineIsGaming)
                {
                    windowsElement = FindElementByXPath(vantageSession, VantageConstContent.OoBeCheckBox, 5);
                    string toggleState = windowsElement?.GetAttribute("Toggle.ToggleState");
                    if (toggleState == "0")
                    {
                        windowsElement?.Click();
                    }
                }

                Thread.Sleep(TimeSpan.FromSeconds(1));
                windowsElement = FindElementByXPath(vantageSession, VantageConstContent.OoBeDoneButton, 30);
                if (windowsElement != null)
                {
                    windowsElement.Click();
                    windowsElement = FindElementByXPath(vantageSession, VantageConstContent.OoBeDoneButton, 1);
                    windowsElement?.Click();
                }
            }

            if (isLeVersion)
            {
                if (vantageSession == null)
                {
                    return;
                }
                if (needClick)
                {
                    if (isLowVersion)
                    {
                        BasePage bc = new BasePage();
                        windowsElement = bc.FindElementByTimes(vantageSession, "AutomationId", "Button1");
                        if (windowsElement != null)
                        {
                            windowsElement.Click();
                        }
                    }
                }
                windowsElement = FindElementByXPath(vantageSession, VantageConstContent.LeOobeLicenceCheckBox, 120);
                if (windowsElement != null)
                {
                    windowsElement.Click();
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    windowsElement = FindElementByXPath(vantageSession, VantageConstContent.LeOobeLicenceCheckBox, 1);
                    string toggleState = windowsElement?.GetAttribute("Toggle.ToggleState");
                    LogHelper.Logger.Instance.WriteLog("LE OOBE Checkbox Status Info:" + toggleState);
                    if (toggleState == "0")
                    {
                        windowsElement?.Click();
                    }
                }
                windowsElement = FindElementByXPath(vantageSession, VantageConstContent.LeOobePrivacyChexbox, 30);
                if (windowsElement != null)
                {
                    windowsElement.Click();
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    windowsElement = FindElementByXPath(vantageSession, VantageConstContent.LeOobePrivacyChexbox, 1);
                    string toggleState = windowsElement?.GetAttribute("Toggle.ToggleState");
                    LogHelper.Logger.Instance.WriteLog("LE OOBE Checkbox Status Info:" + toggleState);
                    if (toggleState == "0")
                    {
                        windowsElement?.Click();
                    }
                }
                windowsElement = FindElementByXPath(vantageSession, VantageConstContent.LeOobeLetGoButton, 30);
                if (windowsElement != null)
                {
                    windowsElement.Click();
                }
                Thread.Sleep(TimeSpan.FromSeconds(3));
                windowsElement = FindElementByXPath(vantageSession, VantageConstContent.LeOobeLetGoButton, 3);
                if (windowsElement != null)
                {
                    windowsElement.Click();
                }
            }

            if (!getMachineIsGaming)
            {
                if (is20H1)
                {
                    return;
                }
                if (needClick)
                {

                    windowsElement = FindElementByXPath(vantageSession, "//Button[@AutomationId='Button1']", 15);
                    if (windowsElement != null)
                    {
                        windowsElement.Click();
                    }
                    windowsElement = FindElementByXPath(vantageSession, "//Button[@AutomationId='Button1']", 15);
                    if (windowsElement != null)
                    {
                        windowsElement.Click();
                    }

                    windowsElement = FindElementByXPath(vantageSession, "//*[@AutomationId='menu-main-nav-lnk-dropdown-toggle-device']", 15);
                    if (windowsElement != null)
                    {
                        windowsElement.Click();
                    }
                    windowsElement = FindElementByXPath(vantageSession, "//*[contains(@AutomationId,'menu-main-nav-lnk-dropdown-menu-device-device-settings-')]", 15);
                    if (windowsElement != null)
                    {
                        windowsElement.Click();
                    }
                    windowsElement = FindElementByXPath(vantageSession, "//*[@AutomationId='myDevice-settings-header-menu-display-camera']", 15);
                    if (windowsElement != null)
                    {
                        windowsElement.Click();
                    }
                    windowsElement = FindElementByXPath(vantageSession, "//*[@AutomationId='Button1']", 15);
                    if (windowsElement != null)
                    {
                        windowsElement.Click();
                    }
                    windowsElement = FindElementByXPath(vantageSession, "//*[@AutomationId='menu-main-nav-lnk-dashboard']", 15);
                    if (windowsElement != null)
                    {
                        windowsElement.Click();
                    }
                }
            }
            if (isCloseAlertWindow)
            {
                try
                {
                    CloseAlertWindow(vantageSession);
                    vantageSession.Manage().Window.Maximize();
                }
                catch (WebDriverException ex)
                {
                    Debug.WriteLine(ex.StackTrace);
                }
            }
        }

        private static void BuildEnvForAppium()
        {
            if (Environment.GetEnvironmentVariable("ANDROID_HOME", EnvironmentVariableTarget.Machine) == null)
            {
                Environment.SetEnvironmentVariable("ANDROID_HOME", _androidHome, EnvironmentVariableTarget.Machine);
            }
            string systemPathValue = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine);
            if (!systemPathValue.Contains("android-sdk-windows"))
            {
                Environment.SetEnvironmentVariable("Path", systemPathValue + ";" + _tools + ";" + _platTools, EnvironmentVariableTarget.Machine);
            }
            string adbText = File.ReadAllText(_dectADBFile);
            if (!adbText.Contains("prototype.shell_grep"))
            {
                File.Copy(_sourceADBFile, _dectADBFile, true);
                File.Copy(_sourceAndroidFile, _dectAndroidFile, true);
            }
        }

        public static void ConnectToPowerForBatteryIsLow(int powervalue = 15, int powervalueEnd = 30)
        {
            if (GetCurrentBatteryPercent() > powervalue)
            {
                return;
            }
            if (JudgeInsertStatusIsOn() == false)
            {
                AdapterNotInsert();
            }
            if (JudgeInsertStatusIsOn())
            {
                int trytimes = 10;
                do
                {
                    Thread.Sleep(TimeSpan.FromMinutes(3));
                    if (GetCurrentBatteryPercent() > powervalueEnd || JudgeInsertStatusIsOn() == false)
                    {
                        break;
                    }
                    trytimes--;
                } while (trytimes > 0);
            }
        }
        public static T DESerializer<T>(string filePath) where T : class
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                    return null;
                }

                string strXML = File.ReadAllText(filePath);
                if (string.IsNullOrEmpty(strXML))
                {
                    return null;
                }
                using (StringReader sr = new StringReader(strXML))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return serializer.Deserialize(sr) as T;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static bool SendCommandToACDCServer(string acdcServer, string bindId)
        {
            bool currentInsertStatus = JudgeInsertStatusIsOn();
            try
            {
                int port = 19999;
                IPAddress ip = IPAddress.Parse(acdcServer);
                var clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(ip, port);
                clientSocket.Connect(endPoint);
                string timeMark = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string runCase = string.Format(timeMark + ", " + bindId);
                Console.WriteLine("Begin Send Message: " + runCase);
                byte[] message = Encoding.ASCII.GetBytes(runCase);
                clientSocket.Send(message);
                Console.WriteLine("Send Message is :" + Encoding.ASCII.GetString(message));
                clientSocket.Close();
                int index = 10;
                while (JudgeInsertStatusIsOn() == currentInsertStatus)
                {
                    Thread.Sleep(3000);
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
            return JudgeInsertStatusIsOn() == currentInsertStatus;
        }

        public static bool AdapterNotInsert()
        {
            try
            {
                ACDCMachineListBean ACDCBean = new ACDCMachineListBean();
                string ACDCServerConfig = "ACDC.xml";
                string ACDCServerfolder = Path.Combine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ACDCServerConfig));
                IPAddress[] addressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
                string address = string.Empty;
                foreach (IPAddress adr in addressList)
                {
                    if (!adr.ToString().Contains("192.168"))
                    {

                        IPAddress addr = new IPAddress(adr.Address);
                        address = addr.ToString();
                        break;
                    }
                }

                ACDCMachineListBean acdc = DESerializer<ACDCMachineListBean>(ACDCServerfolder);
                MachineListItem acdcConfig = acdc?.MachineList.Find(machine => machine.MachineIp == address);
                if (acdcConfig != null)
                {
                    string acdcServer = acdcConfig.ACDCServerIp;
                    string acdcBtnId = acdcConfig.BtnId;
                    // 发送 点击按钮操作请求
                    return SendCommandToACDCServer(acdcServer, acdcBtnId);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            return false;

        }

        private static void ControlPowerToggle(RemoteWebDriver driver, bool ScreenshotNeed = false, string imageName = "ITS", string pathName = "ITS", string component = "ITS")
        {
            string top = "com.huawei.smarthome:id/smarthome_devices_1_listitem_top";
            ReadOnlyCollection<IWebElement> topElements = null;
            BasePage basePage = new BasePage();
            int index = 0;
            while (topElements == null)
            {
                topElements = driver.FindElementsById(top);
                foreach (IWebElement topElement in topElements)
                {
                    var layout = topElement.FindElement(By.Id("com.huawei.smarthome:id/smarthome_devices_1_listitem_name_layout"));
                    var textView = layout.FindElement(By.Id("com.huawei.smarthome:id/smarthome_devices_1_listitem_name"));
                    var text = textView.GetAttribute("text");
                    var toggle = topElement.FindElement(By.Id("com.huawei.smarthome:id/smarthome_devices_1_listitem_ligth_status"));
                    if (toggle != null)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(5));
                        toggle.Click();
                        if (ScreenshotNeed == true)
                        {
                            Thread.Sleep(TimeSpan.FromSeconds(2));
                            basePage.AddScreenshotIntoReport(imageName, pathName, component);
                        }
                        Thread.Sleep(TimeSpan.FromSeconds(5));
                        return;
                    }
                }
                if (index == 10)
                {
                    throw new ValidationException("Xpath: " + top + ", not found.");
                }
                index++;
            }
        }

        //Change By Fangdq this function will del when all PLC in use
        public static void LessThanPowerValueByPLC(int value, string oneOrtow = "one")
        {
            int currentPercent = 0;
            if (oneOrtow.ToLower() == "two")
            {
                currentPercent = GetTowBatteryComputerBatteryLevel(1);
            }
            else
            {
                currentPercent = GetCurrentBatteryPercent();
            }
            int oldBatteryValue = currentPercent;
            if (currentPercent > value)
            {
                if (JudgeInsertStatusIsOn())
                {
                    AdapterNotInsert();
                }
                int index = 4;
                while (currentPercent > value)
                {
                    Thread.Sleep(TimeSpan.FromMinutes(1));
                    if (oneOrtow.ToLower() == "two")
                    {
                        currentPercent = GetTowBatteryComputerBatteryLevel(1);
                    }
                    else
                    {
                        currentPercent = GetCurrentBatteryPercent();
                    }
                    if (currentPercent >= oldBatteryValue)
                    {
                        if (index < 0)
                        {
                            break;
                        }
                        index--;
                    }
                }
                if (!JudgeInsertStatusIsOn())
                {
                    AdapterNotInsert();
                }
            }
        }

        //Change By Fangdq this function will del when all PLC in use
        public static void MoreThanPowerValueByPLC(int value, string oneOrtow = "one")
        {
            int currentPercent = 0;
            if (oneOrtow.ToLower() == "two")
            {
                currentPercent = GetTowBatteryComputerBatteryLevel(1);
            }
            else
            {
                currentPercent = GetCurrentBatteryPercent();
            }
            int batteryOldValue = currentPercent;
            if (currentPercent < value)
            {
                if (!JudgeInsertStatusIsOn())
                {
                    AdapterNotInsert();
                }
                int index = 4;
                while (currentPercent < value)
                {
                    Thread.Sleep(TimeSpan.FromMinutes(1));
                    if (oneOrtow.ToLower() == "two")
                    {
                        currentPercent = GetTowBatteryComputerBatteryLevel(1);
                    }
                    else
                    {
                        currentPercent = GetCurrentBatteryPercent();
                    }
                    if (batteryOldValue >= currentPercent)
                    {
                        if (index < 0)
                        {
                            break;
                        }
                        index--;
                    }
                    if (currentPercent >= value)
                    {
                        break;
                    }
                }
            }
        }

        //Not Insert
        public static void LessThanPowerValueByAppium(int value)
        {
            int currentPercent = GetCurrentBatteryPercent();
            int oldBatteryValue = currentPercent;
            if (currentPercent > value)
            {
                if (JudgeInsertStatusIsOn())
                {
                    AdapterNotInsert();
                }
                int index = 4;
                while (currentPercent > value)
                {
                    Thread.Sleep(TimeSpan.FromMinutes(1));
                    currentPercent = GetCurrentBatteryPercent();
                    if (currentPercent >= oldBatteryValue)
                    {
                        if (index < 0)
                        {
                            break;
                        }
                        index--;
                    }
                }
                Thread.Sleep(5000);
                if (!JudgeInsertStatusIsOn())
                {
                    AdapterNotInsert();
                }
            }
        }
        // Insert
        public static void MoreThanPowerValueByAppium(int value)
        {
            int currentPercent = GetCurrentBatteryPercent();
            int batteryOldValue = currentPercent;
            if (currentPercent < value)
            {
                if (!JudgeInsertStatusIsOn())
                {
                    AdapterNotInsert();
                }
                int index = 4;
                while (currentPercent < value)
                {
                    Thread.Sleep(TimeSpan.FromMinutes(1));
                    currentPercent = GetCurrentBatteryPercent();
                    if (batteryOldValue >= currentPercent)
                    {
                        if (index < 0)
                        {
                            break;
                        }
                        index--;
                    }
                    if (currentPercent >= value)
                    {
                        break;
                    }
                }
            }
        }

        public static void LessThanPowerValue(int value, string onOrtwo = "one", int batteryIndex = 0)
        {
            int currentPercent = 0;
            var batteryChange = 0;
            if (onOrtwo == "two")
            {
                currentPercent = GetTowBatteryComputerBatteryLevel(batteryIndex);
            }
            else
            {
                currentPercent = GetCurrentBatteryPercent();
            }
            if (currentPercent > value)
            {
                RunCmd(DischargeStatusPath + " start 1 ");
                int index = 60;
                do
                {
                    if (onOrtwo == "two")
                    {
                        batteryChange = GetTowBatteryComputerBatteryLevel(batteryIndex);
                    }
                    else
                    {
                        batteryChange = GetCurrentBatteryPercent();
                    }
                    Thread.Sleep(TimeSpan.FromMinutes(1));
                    if (batteryChange >= currentPercent)
                    {
                        if (index < 0)
                        {
                            break;
                        }
                        index--;
                        RunCmd(DischargeStatusPath + " start 1 ");
                        RunCmd(DischargeStatusPath + " start 1 ");
                    }
                    currentPercent = batteryChange;
                } while (currentPercent > value);
                RunCmd(DischargeStatusPath + " stop 1 ");
                RunCmd(DischargeStatusPath + " stop 1 ");
            }
        }

        public struct SYSTEMTIME
        {
            public ushort wYear, wMonth, wDayOfWeek, wDay, wHour, wMinute, wSecond, wMilliseconds;
        }

        [DllImport("kernel32.dll")]
        public extern static void GetSystemTime(ref SYSTEMTIME lpSystemTime);

        /// <param name="lpSystemTime">[in] Pointer to a SYSTEMTIME structure that
        /// contains the current system date and time.</param>
        [DllImport("kernel32.dll")]
        public extern static uint SetSystemTime(ref SYSTEMTIME lpSystemTime);

        public static void MoreThanPowerValue(int value, string onOrtwo = "one", int batteryIndex = 0)
        {
            int currentPercent = 0;
            int oldValue = 0;
            if (onOrtwo == "two")
            {
                currentPercent = GetTowBatteryComputerBatteryLevel(batteryIndex);
            }
            else
            {
                currentPercent = GetCurrentBatteryPercent();
            }
            if (currentPercent < value)
            {
                RunCmd(DischargeStatusPath + " stop 1 ");
                RunCmd(DischargeStatusPath + " stop 1 ");
                int index = 40;
                do
                {
                    oldValue = currentPercent;
                    Thread.Sleep(TimeSpan.FromMinutes(2));
                    if (onOrtwo == "two")
                    {
                        currentPercent = GetTowBatteryComputerBatteryLevel(batteryIndex);
                    }
                    else
                    {
                        currentPercent = GetCurrentBatteryPercent();
                    }
                    if (value <= currentPercent)
                    {
                        break;
                    }
                    else if (oldValue > currentPercent)
                    {
                        if (index < 0)
                        {
                            break;
                        }
                        index--;
                        RunCmd(DischargeStatusPath + " stop 1 ");
                        RunCmd(DischargeStatusPath + " stop 1 ");
                    }
                } while (currentPercent < value);
            }
        }

        public static void TowBatteryLessThanPowerValue(WindowsDriver<WindowsElement> vantageSession, int value, int batteryIndex)
        {
            BasePage bc = new BasePage();
            HSPowerSettingsPage _hsPowerSettingsPage = new HSPowerSettingsPage(vantageSession);
            bool resalut = _hsPowerSettingsPage.JumpToBatterySettings();
            if (!resalut)
            {
                throw new Exception("TowBatteryLessThanPowerValue Go to power page false");
            }
            int currentPercent = GetTowBatteryComputerBatteryLevel(batteryIndex);
            int oldBatteryValue = currentPercent;
            if (currentPercent > value)
            {
                if (batteryIndex == 0)
                {
                    WindowsElement resetBtn1 = bc.FindElementByTimes(vantageSession, "AutomationId", SettingsBase.GetAutomationIdFromPredefinedJsonFile("$.PowerPage.HSBatteryGuageStopBtn"));
                    Assert.IsNotNull(resetBtn1, "The resetBtn1 is not find");
                    resetBtn1.Click();
                    WindowsElement continueBtn1 = bc.FindElementByTimes(vantageSession, "AutomationId", SettingsBase.GetAutomationIdFromPredefinedJsonFile("$.PowerPage.HSBatteryGuageResetPopupContinueBtn"));
                    Assert.IsNotNull(continueBtn1, "The continueBtn1 is not find");
                    continueBtn1.Click();
                    WindowsElement resetBtn2 = bc.FindElementByTimes(vantageSession, "AutomationId", SettingsBase.GetAutomationIdFromPredefinedJsonFile("$.PowerPage.HSBatteryGuageResetSecondaryResetBtn"));
                    Assert.IsFalse(resetBtn2.Enabled, "The resetBtn2 can be click  the resetBtn1 not open!");
                    while (currentPercent > value)
                    {
                        Thread.Sleep(10000);
                        currentPercent = GetTowBatteryComputerBatteryLevel(batteryIndex);
                        if (currentPercent != oldBatteryValue)
                        {
                            Debug.WriteLine("The old value is " + oldBatteryValue + " new value is " + currentPercent);
                            oldBatteryValue = currentPercent;
                        }
                    }
                    WindowsElement stopBtn1 = bc.FindElementByTimes(vantageSession, "AutomationId", SettingsBase.GetAutomationIdFromPredefinedJsonFile("$.PowerPage.HSBatteryGuageStopBtn"));
                    Assert.IsNotNull(stopBtn1, "The stopBtn1 is not find");
                    stopBtn1.Click();
                    WindowsElement yesBtn1 = bc.FindElementByTimes(vantageSession, "AutomationId", SettingsBase.GetAutomationIdFromPredefinedJsonFile("$.PowerPage.HSBatteryGuageResetStopPopYesBtn"));
                    Assert.IsNotNull(yesBtn1, "The yesBtn1 is not find");
                    yesBtn1.Click();
                    Assert.IsTrue(resetBtn2.Enabled, "The resetBtn2 can not be click  the resetBtn1 is open!");
                }
                else if (batteryIndex == 1)
                {
                    LessThanPowerValue(value, "two", 1);
                }
            }
        }

        public static void TowBatteryMoreThanPowerValue(WindowsDriver<WindowsElement> vantageSession, int value, int batteryIndex)
        {
            BasePage bc = new BasePage();
            HSPowerSettingsPage _hsPowerSettingsPage = new HSPowerSettingsPage(vantageSession);
            bool resalut = _hsPowerSettingsPage.JumpToBatterySettings();
            if (!resalut)
            {
                throw new Exception("TowBatteryLessThanPowerValue Go to power page false");
            }
            int currentPercent = GetTowBatteryComputerBatteryLevel(batteryIndex);
            int oldBatteryValue = currentPercent;
            if (currentPercent < value)
            {
                if (batteryIndex == 0)
                {
                    MoreThanPowerValue(value, "two", 0);
                }
                else if (batteryIndex == 1)
                {
                    WindowsElement resetBtn2 = bc.FindElementByTimes(vantageSession, "AutomationId", SettingsBase.GetAutomationIdFromPredefinedJsonFile("$.PowerPage.HSBatteryGuageResetSecondaryResetBtn"));
                    Assert.IsNotNull(resetBtn2, "The resetBtn2 is not find");
                    resetBtn2.Click();
                    WindowsElement continueBtn1 = bc.FindElementByTimes(vantageSession, "AutomationId", SettingsBase.GetAutomationIdFromPredefinedJsonFile("$.PowerPage.HSBatteryGuageResetPopupContinueBtn"));
                    Assert.IsNotNull(continueBtn1, "The continueBtn1 is not find");
                    continueBtn1.Click();
                    WindowsElement resetBtn1 = bc.FindElementByTimes(vantageSession, "AutomationId", SettingsBase.GetAutomationIdFromPredefinedJsonFile("$.PowerPage.HSBatteryGuageStopBtn"));
                    Assert.IsFalse(resetBtn1.Enabled, "The resetBtn1 can be click  the resetBtn1 not open!");
                    while (currentPercent < value)
                    {
                        Thread.Sleep(10000);
                        currentPercent = GetTowBatteryComputerBatteryLevel(batteryIndex);
                        if (currentPercent != oldBatteryValue)
                        {
                            Debug.WriteLine("The old value is " + oldBatteryValue + " new value is " + currentPercent);
                            oldBatteryValue = currentPercent;
                        }
                    }
                    WindowsElement stopBtn2 = bc.FindElementByTimes(vantageSession, "AutomationId", SettingsBase.GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.PowerPage.HSBatteryGuageResetSecondaryResetBtn"));
                    Assert.IsNotNull(stopBtn2, "The stopBtn2 is not find");
                    stopBtn2.Click();
                    WindowsElement yesBtn1 = bc.FindElementByTimes(vantageSession, "AutomationId", SettingsBase.GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.PowerPage.HSBatteryGuageResetStopPopYesBtn"));
                    Assert.IsNotNull(yesBtn1, "The yesBtn1 is not find");
                    yesBtn1.Click();
                    Assert.IsTrue(resetBtn1.Enabled, "The resetBtn1 can not be click  the resetBtn2 is open!");
                }
            }
        }

        public static WindowsElement FindElementByXPath(WindowsDriver<WindowsElement> windowsDriver, string xpath, double timeOut = 15, bool notExists = false, double implicitWaitTime = 80)
        {
            windowsDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitTime);
            WindowsElement windowsElement = null;
            while (timeOut > 0)
            {
                try
                {
                    windowsElement = windowsDriver.FindElementByXPath(xpath);
                    if (notExists && windowsElement == null)
                    {
                        break;
                    }
                    if (windowsElement != null && !notExists)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message + ": " + xpath);
                }
                timeOut--;
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            return windowsElement;
        }

        public static bool GetTheNoticeToast(int historyCount = 0, string checkToastTitle = "", string isShown = "")
        {

            var notifs = ToastNotificationManager.History.GetHistory(VantageConstContent.VantageUwpAppid);
            bool flag = false;
            int nowCount = 0;
            int index = 20 * 10;
            if (isShown == "Not Be Shown")
            {
                index = 10;
            }
            Console.WriteLine("Wait for the Wifi's toast Popup!");
            while (index > 0)
            {
                nowCount = ToastNotificationManager.History.GetHistory(VantageConstContent.VantageUwpAppid).Count;
                notifs = ToastNotificationManager.History.GetHistory(VantageConstContent.VantageUwpAppid);

                if (nowCount > historyCount || index < 0)
                {
                    if (!string.IsNullOrEmpty(checkToastTitle) && notifs.Count > 0)
                    {
                        if (notifs[0].Content.InnerText.Contains(checkToastTitle))
                        {
                            flag = true;
                            break;
                        }
                    }
                    else if (nowCount > historyCount)
                    {
                        flag = true;
                        break;
                    }

                }

                Thread.Sleep(100);
                index--;
            }

            if (flag && notifs.Count > 0)
            {
                return flag;
            }

            return false;
        }

        public static bool CheckToastPopUp(string toastType, string isShown)
        {
            toastType = VantageConstContent.UISpecKeyMap[toastType.Replace(" ", "")];
            return GetTheNoticeToast(0, toastType, isShown);
        }

        public static bool DriverPackageExists(string deviceDesc)
        {
            RegistryKey rk = Registry.LocalMachine;
            RegistryKey tmp = rk.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4d36e97d-e325-11ce-bfc1-08002be10318}", false);
            string[] subkeys = tmp.GetSubKeyNames();
            string result = string.Empty;
            foreach (string subkey in subkeys)
            {
                if (subkey == "Properties")
                    continue;
                tmp = rk.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4d36e97d-e325-11ce-bfc1-08002be10318}\" + subkey, false);
                result = tmp?.GetValue("DriverDesc").ToString();
                if (result == deviceDesc)
                    return result == deviceDesc;
            }
            return result == deviceDesc;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEM_POWER_STATUS
        {
            public byte ACLineStatus;
            public byte BatteryFlag;
            public byte BatteryLifePercent;
            public byte Reserved1;
            public int BatteryLifeTime;
            public int BatteryFullLifeTime;
        }
        [DllImport("kernel32.dll")]
        public static extern bool GetSystemPowerStatus(out SYSTEM_POWER_STATUS sps);
        public static int GetCurrentBatteryPercent()
        {
            SYSTEM_POWER_STATUS SysPower = new SYSTEM_POWER_STATUS();
            GetSystemPowerStatus(out SysPower);
            int currentPercent = Convert.ToInt32(Convert.ToString(SysPower.BatteryLifePercent));
            return currentPercent;
        }

        public static bool GetCurrentBatteryFlagIsNoCharging()
        {
            SYSTEM_POWER_STATUS SysPower = new SYSTEM_POWER_STATUS();
            GetSystemPowerStatus(out SysPower);
            int currentBatteryFlag = Convert.ToInt32(Convert.ToString(SysPower.BatteryFlag));
            return (currentBatteryFlag != 8);
        }

        public static bool JudgeInsertStatusIsOn()
        {
            SYSTEM_POWER_STATUS sysPowerStatus = new SYSTEM_POWER_STATUS();
            GetSystemPowerStatus(out sysPowerStatus);
            return (sysPowerStatus.ACLineStatus == 1);
        }
        public static void RunCmd(string cmdStr)
        {
            var processInfo = new ProcessStartInfo("cmd.exe", "/S /C " + cmdStr)
            {
                CreateNoWindow = true,
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process.Start(processInfo);
        }
        //Power 

        public static int JudgeBatteryNums()
        {
            string wmiSQL = "SELECT * FROM Win32_Battery";
            ManagementObjectCollection printers = new ManagementObjectSearcher(wmiSQL).Get();
            string judgeStr = "Availability";
            int batteryCount = 0;
            foreach (ManagementObject printer in printers)
            {
                PropertyDataCollection.PropertyDataEnumerator pde = printer.Properties.GetEnumerator();
                while (pde.MoveNext())
                {
                    if (pde.Current.Name.Contains(judgeStr))
                    {
                        batteryCount++;
                    }
                    Debug.WriteLine(pde.Current.Name + " : " + pde.Current.Value);
                }
            }
            return batteryCount;
        }

        public static int GetTowBatteryComputerBatteryLevel(int batteryIndex)
        {
            //传入参数为0或者1 0为primarybattery 1为secondbattery
            string wmiSQL = "SELECT * FROM Win32_Battery";
            ManagementObjectCollection printers = new ManagementObjectSearcher(wmiSQL).Get();
            string judgeStr = "EstimatedChargeRemaining";
            List<int> batteryLevels = new List<int>();
            foreach (ManagementObject printer in printers)
            {
                PropertyDataCollection.PropertyDataEnumerator pde = printer.Properties.GetEnumerator();
                while (pde.MoveNext())
                {
                    if (pde.Current.Name.Contains(judgeStr))
                    {
                        int batteryLevel = Convert.ToInt32(pde.Current.Value);
                        batteryLevels.Add(batteryLevel);
                    }
                    Debug.WriteLine(pde.Current.Name + " : " + pde.Current.Value);
                }
            }
            return batteryLevels[batteryIndex];
        }

        public enum MachineType
        {
            Unknow = -1,
            Idea = 0,
            Think = 1,
            Yoga = 2,
            GamingNB = 3,
            GamingDT = 4,
        }

        public static MachineType Gettype()
        {
            string _machinetype = string.Empty;
            string path = "\\\\.\\root\\cimv2";
            string sqlquery = "select * from Win32_ComputerSystem";
            string value = "SystemFamily";
            ManagementObjectCollection queryCollection1;
            ConnectionOptions co = new ConnectionOptions();
            MachineType pc = MachineType.Unknow;
            try
            {
                ManagementScope ms = new ManagementScope(path, co);
                ObjectQuery oq = new ObjectQuery(sqlquery);
                ManagementObjectSearcher query1 = new ManagementObjectSearcher(ms, oq);
                queryCollection1 = query1.Get();
                foreach (ManagementObject mo in queryCollection1)
                {
                    if (!string.IsNullOrEmpty(mo[value].ToString()))
                    {
                        _machinetype = mo[value].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (_machinetype.ToLower().Contains("think"))
            {
                pc = MachineType.Think;
                return pc;

            }
            else if (_machinetype.ToLower().Contains("idea"))
            {
                pc = MachineType.Idea;
                return pc;

            }
            else if (_machinetype.ToLower().Contains("yoga"))
            {
                pc = MachineType.Idea;
                return pc;
            }
            return pc;
        }

        public static string GetMachineSku()
        {
            string machinetype = string.Empty;
            string path = "\\\\.\\root\\cimv2";
            string sqlquery = "select * from Win32_ComputerSystem";
            string value = "SystemSKUNumber";
            ManagementObjectCollection queryCollection1;
            ConnectionOptions co = new ConnectionOptions();
            try
            {
                ManagementScope ms = new ManagementScope(path, co);
                ObjectQuery oq = new ObjectQuery(sqlquery);
                ManagementObjectSearcher query1 = new ManagementObjectSearcher(ms, oq);
                queryCollection1 = query1.Get();
                foreach (ManagementObject mo in queryCollection1)
                {
                    if (!string.IsNullOrEmpty(mo[value].ToString()))
                    {
                        machinetype = mo[value].ToString();
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception("GetMachineType Exception:" + ee.ToString());
            }

            return machinetype;
        }

        public static string GetCurrentMachineType()
        {
            string machinetype = string.Empty;
            string path = "\\\\.\\root\\cimv2";
            string sqlquery = "select * from Win32_ComputerSystem";
            string value = "SystemFamily";
            ManagementObjectCollection queryCollection1;
            ConnectionOptions co = new ConnectionOptions();
            try
            {
                ManagementScope ms = new ManagementScope(path, co);
                ObjectQuery oq = new ObjectQuery(sqlquery);
                ManagementObjectSearcher query1 = new ManagementObjectSearcher(ms, oq);
                queryCollection1 = query1.Get();
                foreach (ManagementObject mo in queryCollection1)
                {
                    if (!string.IsNullOrEmpty(mo[value].ToString()))
                    {
                        machinetype = mo[value].ToString();
                    }
                }
            }
            catch (Exception ee)
            {
                throw new Exception("GetMachineType Exception:" + ee.ToString());
            }

            return machinetype.Trim();
        }

        public static bool IsThinkPad()
        {
            return Gettype() == MachineType.Think;
        }

        public static bool IsIdeaPad()
        {
            return Gettype() == MachineType.Idea;
        }

        public string GetWMIValue(string path, string sqlquery, string value)
        {
            ManagementObjectCollection queryCollection1;
            ConnectionOptions co = new ConnectionOptions();
            try
            {
                ManagementScope ms = new ManagementScope(path, co);
                ObjectQuery oq = new ObjectQuery(sqlquery);
                ManagementObjectSearcher query1 = new ManagementObjectSearcher(ms, oq);
                queryCollection1 = query1.Get();
                foreach (ManagementObject mo in queryCollection1)
                {
                    if (!string.IsNullOrEmpty(mo[value].ToString()))
                    {
                        return mo[value].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            return null;

        }

        private static string VantageInstallPathAppxBundle(string fileType = "bundle")
        {
            string fileName = string.Empty;
            string path = VantageConstContent.VantageInstallPs1Path;
            string[] fileNames = Directory.GetFiles(path);
            foreach (string filename in fileNames)
            {
                if (!Directory.Exists(filename) && File.Exists(filename))
                {
                    if (Path.GetExtension(filename).Contains(fileType))
                    {
                        fileName = filename;
                        break;
                    }
                }
            }
            return fileName;
        }

        public static string ScreenShot(string fileNameBase, string subDiectory = "ScreenShots")
        {
            string workingDirectory = Assembly.GetExecutingAssembly().Location;
            string projectDiectory = Directory.GetParent(workingDirectory).FullName;
            var artifactDirectory = Path.Combine(projectDiectory, subDiectory);

            if (!Directory.Exists(artifactDirectory))
            {
                Directory.CreateDirectory(artifactDirectory);
            }
            var screenShotfilepath = artifactDirectory + "\\" + fileNameBase + "_" + DateTime.Now.ToString(Constants.DATETIMEFORMATFORPATH) + ".jpg";
            CaptureScreen.PrintScreen(screenShotfilepath);
            return screenShotfilepath;
        }

        public static string ScreenShot(string fileName, string dirName, string component)
        {
            // Get current working directory.
            string workingDirectory = Assembly.GetExecutingAssembly().Location;

            // Get the project folder.
            string projectDiectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            string screenShotPath = Path.Combine(projectDiectory, component, dirName);
            if (!Directory.Exists(screenShotPath))
            {
                Directory.CreateDirectory(screenShotPath);
            }
            var screenShotfilepath = screenShotPath + "\\" + fileName + ".jpg";
            CaptureScreen.PrintScreen(screenShotfilepath);
            return screenShotfilepath;
        }

        public static void DeleteFile(string fileName = "wincmd.txt")
        {
            string path = Path.Combine(Application.StartupPath, fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public static void ChangeDPI(string value)
        {
            DeleteFile();
            Common.KillProcess(VantageConstContent.ProcessSystemSettings, true);
            Common.StartProcess(VantageConstContent.ProcessDesktopDisplay);
            AutomationElement mainWindow = null;
            Thread.Sleep(6000);
            do
            {
                mainWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "ApplicationFrameWindow"));
            } while (mainWindow == null);


            UIAutomationControl ua = new UIAutomationControl();
            List<AutomationElement> settinglist = ua.FindAllElementsInRootElementPlus(mainWindow, "SystemSettings_Display_Scaling_ItemSizeOverride_ComboBox");
            if (settinglist.Count > 0)
            {
                AutomationElement combox = settinglist[0];
                ExpandCollapsePattern comboxSelect = GetSelectionPattern(combox);
                comboxSelect.Expand();
                AutomationElementCollection selectionList = combox.FindAll(TreeScope.Children, Condition.TrueCondition);
                List<int> dpiValues = new List<int>();
                foreach (AutomationElement e in selectionList)
                {
                    if (!(e.Current.Name.Contains("Close") || e.Current.Name.Contains("Recommended")))
                    {
                        dpiValues.Add(Convert.ToInt32(e.Current.Name.Replace("%", "").Trim()));
                    }
                }
                if (value.ToLower() == "max")
                {
                    value = Convert.ToString(dpiValues[dpiValues.Count - 1]);
                }
                foreach (AutomationElement e in selectionList)
                {
                    if (e.Current.Name.Contains(value))
                    {
                        GetSelectionItemPattern(e).Select();
                    }
                }

            }
            Common.KillProcess(VantageConstContent.ProcessSystemSettings, true);
        }

        public static ExpandCollapsePattern GetSelectionPattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(ExpandCollapsePattern.Pattern, out currentPattern))
            {
                throw new Exception("Failed to get expand collapse pattern.");
            }
            return currentPattern as ExpandCollapsePattern;
        }

        public static SelectionItemPattern GetSelectionItemPattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(SelectionItemPattern.Pattern, out currentPattern))
            {
                throw new Exception("Failed to get selection item pattern.");
            }
            return currentPattern as SelectionItemPattern;
        }

        public static string GetDPIScaling()
        {
            RegistryKey hkml = Registry.CurrentUser;
            RegistryKey windowMetricsKey = hkml.OpenSubKey(@"Control Panel\Desktop\WindowMetrics");
            int current = (int)windowMetricsKey.GetValue("AppliedDPI") * 100;
            int currentDPI = current / 96;
            return currentDPI.ToString() + "%";
        }


        public static void ScreenShot(string fileName, string dirName, string component, int srcX, int srcY, int width, int height)
        {
            // Get current working directory.
            string workingDirectory = Assembly.GetExecutingAssembly().Location;

            // Get the project folder.
            string projectDiectory = Directory.GetParent(workingDirectory).FullName;//Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            string screenShotPath = Path.Combine(projectDiectory, "Report", component, dirName);
            if (!Directory.Exists(screenShotPath))
            {
                Directory.CreateDirectory(screenShotPath);
            }
            var screenShotfilepath = screenShotPath + "\\" + fileName + ".jpg";
            CaptureScreen.PrintScreenX(srcX, srcY, width, height, screenShotfilepath);
        }

        public static void UninstallVantage()
        {
            UwpAppInfo comp = UwpAppManagement.SearchUwpAppByName(VantageConstContent.GetVantageUwpAppName());
            if (comp != null)
            {
                UwpAppManagement.UninstallUwpApp(comp.PackageFullName);
            }
        }

        public static bool DeteleLenovoVantageService(bool deleteVantageService = false)
        {
            try
            {
                if (deleteVantageService == true)
                {
                    CommandBase.RunCmd("sc delete LenovoVantageService");
                    string vantageServiceDirectory = @"C:\Program Files (x86)\Lenovo\VantageService";
                    if (Directory.Exists(vantageServiceDirectory))
                    {
                        string[] LenovoVantageServiceFiles = Directory.GetFiles(vantageServiceDirectory, "Uninstall.exe", SearchOption.AllDirectories);
                        foreach (var lvsfile in LenovoVantageServiceFiles)
                        {
                            Common.RunCmdWithShell("\"" + lvsfile + "\" /SILENT");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }

        private static bool InstallVantageTryTimes(string installAppxBundlePath, string installPs1Path)
        {
            UwpAppInfo vantageInstalled = UwpAppManagement.SearchUwpAppByName(VantageConstContent.GetVantageUwpAppName());
            if (vantageInstalled == null && !string.IsNullOrEmpty(installPs1Path))
            {
                UwpAppManagement.InstallUwpApp(installPs1Path);
            }
            else if (string.IsNullOrEmpty(installPs1Path) && !string.IsNullOrEmpty(installAppxBundlePath))
            {
                UwpAppManagement.InstallUwpAppByBundleBtn(installAppxBundlePath);
            }
            int index = 60;
            while (vantageInstalled == null && index > 0)
            {
                vantageInstalled = UwpAppManagement.SearchUwpAppByName(VantageConstContent.GetVantageUwpAppName());
                Thread.Sleep(TimeSpan.FromSeconds(3));
                index--;
            }
            return vantageInstalled != null;
        }

        public static void InstallVantage(bool deleteVantageService = false, bool oldShellNewWeb = false, bool newShellOldWeb = false)
        {
            string installAppxBundlePath = null;
            string installPs1Path = null;
            if (oldShellNewWeb == true)
            {
                VantageConstContent.VantageTypePlan = VantageConstContent.VantageType.OldShellNewPlugin;
            }
            else if (newShellOldWeb == true)
            {
                VantageConstContent.VantageTypePlan = VantageConstContent.VantageType.NewShellOldPlugin;
            }
            installAppxBundlePath = VantageInstallPathAppxBundle();
            installPs1Path = VantageInstallPathAppxBundle("ps1");
            Common.KillProcess(VantageConstContent.VantageProcessName, true);
            Common.KillProcess(Constants.LenovoVantageService_NAME, true);
            Thread.Sleep(1000);
            UwpAppInfo commonVantage = UwpAppManagement.SearchUwpAppByName(VantageConstContent.VantageCommonAppIdName);
            UwpAppInfo leVantage = UwpAppManagement.SearchUwpAppByName(VantageConstContent.VantageLEUwpAPPIdName);
            if (commonVantage != null)
            {
                UwpAppManagement.UninstallUwpApp(commonVantage.PackageFullName);
            }
            if (leVantage != null)
            {
                UwpAppManagement.UninstallUwpApp(leVantage.PackageFullName);
            }

            DeteleLenovoVantageService(deleteVantageService);

            Thread.Sleep(3000);

            if (Directory.Exists(_vantagePath))
            {
                try
                {
                    Common.StopService(VantageConstContent.IMCServiceName);
                    var cmds = new List<string>{
                        string.Format("Remove-Item \"{0}\" -Recurse -Force ", _vantagePath)
                    };
                    Common.RunPowershellCmdlet(cmds);
                }
                finally
                {
                    Common.StartService(VantageConstContent.IMCServiceName);
                }
            }

            bool installFlag = InstallVantageTryTimes(installAppxBundlePath, installPs1Path);
            int tryTimes = 3;
            while (!installFlag)
            {
                Common.MakeDataLink();
                installFlag = InstallVantageTryTimes(installAppxBundlePath, installPs1Path);
                tryTimes--;
                if (tryTimes < 0)
                {
                    break;
                }
            }

            ReplaceFile();
            // Agent 25 Ip
            IPAddress[] addressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
            foreach (IPAddress adr in addressList)
            {
                if (adr.ToString().Contains("10.119.181.161"))
                {
                    if (File.Exists(_leconfigjsonpath))
                    {
                        File.Copy(_leconfigjsonFile, _leconfigjsonpath, true);
                        break;
                    }
                }
            }
            // Set Log Enable 
            RegistryHelp.SetVantageLogState();

            Thread.Sleep(TimeSpan.FromSeconds(3));
            Common.StartService(VantageConstContent.IMCServiceName);
        }

        public static void CloseVantage(WindowsDriver<WindowsElement> session)
        {
            var xpath = "//*[@AutomationId='Close']";
            try
            {
                var vantageCloseBth = VantageCommonHelper.FindElementByXPath(session, xpath);
                if (vantageCloseBth != null)
                {
                    vantageCloseBth.Click();
                }
                else
                {
                    session = LaunchSystemUwp(VantageConstContent.VantageUwpAppid);
                    session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                    vantageCloseBth = VantageCommonHelper.FindElementByXPath(session, xpath);
                    vantageCloseBth?.Click();
                    session.CloseApp();
                    session.Quit();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public static AutomationElement SetLocationServiceInSettings(string status, string test = "Location")
        {
            string automationid_one = string.Format("SystemSettings_CapabilityAccess_{0}_UserGlobal_ToggleSwitch", test);
            string automationid_two = string.Format("SystemSettings_Privacy_{0}EnabledUser_ToggleSwitch", test);
            AutomationElement systemLocation_two = null;
            AutomationElement systemLocation_one = null;
            var settingsWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Settings"));
            if (settingsWindow == null)
            {
                int count = 20;
                for (; count > 0; count--)
                {
                    settingsWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Settings"));
                    Thread.Sleep(500);
                }

            }
            if (settingsWindow != null)
            {
                systemLocation_one = settingsWindow.FindFirst(TreeScope.Descendants, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, automationid_one), new PropertyCondition(AutomationElement.IsEnabledProperty, true)));
                if (systemLocation_one == null)
                {
                    systemLocation_two = settingsWindow.FindFirst(TreeScope.Descendants, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, automationid_two), new PropertyCondition(AutomationElement.IsEnabledProperty, true)));
                }
                int index = 50;
                while (systemLocation_one == null && systemLocation_two == null)
                {
                    systemLocation_one = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, automationid_one), new PropertyCondition(AutomationElement.IsEnabledProperty, true)));
                    if (systemLocation_one == null)
                    {
                        systemLocation_two = settingsWindow.FindFirst(TreeScope.Descendants, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, automationid_two), new PropertyCondition(AutomationElement.IsEnabledProperty, true)));
                    }
                    index--;
                    if (systemLocation_one != null || systemLocation_two != null || index < 0)
                    {
                        break;
                    }
                    Thread.Sleep(500);
                }
            }
            AutomationElement lenovoVantageToggleSwitch = systemLocation_one == null ? systemLocation_two : systemLocation_one;
            if (lenovoVantageToggleSwitch != null)
            {
                var targetToggle = lenovoVantageToggleSwitch.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                if (targetToggle != null)
                {
                    if (!targetToggle.Current.ToggleState.ToString().Equals(status, StringComparison.CurrentCultureIgnoreCase))
                    {
                        Thread.Sleep(2000);
                        targetToggle.Toggle();
                        Thread.Sleep(2000);
                    }
                    string automationId = systemLocation_one == null ? automationid_two : automationid_one;
                    return lenovoVantageToggleSwitch;
                }
            }
            return null;
        }

        public static bool CloseSettingsWindow()
        {
            //System.Windows.Automation.Automation.TransactionTimeout = 120000;
            var settingsWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Settings"));
            AutomationElement automationElement = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, new AndCondition(new PropertyCondition(AutomationElement.NameProperty, "Close Settings"), new PropertyCondition(AutomationElement.AutomationIdProperty, "Close")));
            //var btn = automationElement?.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.AutomationIdProperty, "Close"));
            if (automationElement != null)
            {
                var closeBtn = automationElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                closeBtn.Invoke();
                //Logger.PrintColorText("CloseEage Have Closed " + "CloseSettingsWindow", ConsoleColor.Blue);

            }
            return true;
        }

        public static AutomationElement SetVantageLocationToggleSwitchStatus(string status)
        {
            string autoid_one = Vantage27FullNameToggleSwitch;
            string autoid_two = GetPackageFullNameToggleSwitch;
            Debug.WriteLine(autoid_one);
            Debug.WriteLine(autoid_two);
            var settingsWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Settings"));
            AutomationElement lenovoVantageToggleSwitch_Two = null;
            AutomationElement lenovoVantageToggleSwitch_One = null;
            lenovoVantageToggleSwitch_Two = settingsWindow.FindFirst(TreeScope.Descendants, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, autoid_two), new PropertyCondition(AutomationElement.IsEnabledProperty, true)));
            if (lenovoVantageToggleSwitch_Two == null)
            {
                lenovoVantageToggleSwitch_One = settingsWindow.FindFirst(TreeScope.Descendants, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, autoid_one), new PropertyCondition(AutomationElement.IsEnabledProperty, true)));
            }
            string automationId = string.Empty;
            int index = 50;
            while (lenovoVantageToggleSwitch_One == null && lenovoVantageToggleSwitch_Two == null)
            {
                lenovoVantageToggleSwitch_Two = settingsWindow.FindFirst(TreeScope.Descendants, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, autoid_two), new PropertyCondition(AutomationElement.IsEnabledProperty, true)));
                if (lenovoVantageToggleSwitch_Two == null)
                {
                    lenovoVantageToggleSwitch_One = settingsWindow.FindFirst(TreeScope.Descendants, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, autoid_one), new PropertyCondition(AutomationElement.IsEnabledProperty, true)));
                }

                index--;
                if (lenovoVantageToggleSwitch_One != null || lenovoVantageToggleSwitch_Two != null || index < 0)
                {
                    break;
                }
                Thread.Sleep(500);
            }
            AutomationElement lenovoVantageToggleSwitch = lenovoVantageToggleSwitch_One == null ? lenovoVantageToggleSwitch_Two : lenovoVantageToggleSwitch_One;
            if (lenovoVantageToggleSwitch != null)
            {
                var targetToggle = lenovoVantageToggleSwitch.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                if (targetToggle != null)
                {
                    if (!targetToggle.Current.ToggleState.ToString().Equals(status, StringComparison.CurrentCultureIgnoreCase))
                    {
                        Thread.Sleep(4000);
                        targetToggle.Toggle();
                        Thread.Sleep(4000);
                    }
                    //CloseSettingsWindow();
                    Common.KillProcess("SystemSettings", true);
                    automationId = lenovoVantageToggleSwitch_One == null ? GetPackageFullNameToggleSwitch : Vantage27FullNameToggleSwitch;
                    return lenovoVantageToggleSwitch;
                }
            }
            return null;// "Set Vantage Location ToggleSwitch Status " + automationId;
        }

        public static string Vantage27FullNameToggleSwitch
        {
            get
            {// E046963F.LenovoCompanion_10.1910.27.0_x64__k1h2ywk1493x8_ToggleSwitch
                string fullname = getPackageFullName(VantageUwpName) + "_ToggleSwitch";
                return fullname.Trim();
            }
        }
        public static string GetPackageFullNameToggleSwitch
        {
            //E046963F.LenovoCompanionBeta E046963F.LenovoCompanion
            get
            {
                string fullname = getPackageFamilyName(VantageUwpName) + "_ToggleSwitch";
                return fullname.Trim();
            }
        }
        public static string VantageUwpName
        {
            get
            {
                return VantageConstContent.GetVantageUwpAppName();
            }
        }

        public static void MovePage(string direction, int number)
        {
            for (int i = 0; i < number; i++)
            {
                Thread.Sleep(500);
                SendKeys.SendWait(direction);
            }
        }

        public static void MoveUp(int number = 3)
        {
            MovePage("{PgUp}", number);
        }

        public static void MoveDown(int number = 3)
        {
            MovePage("{PgDn}", number);
        }

        public static bool GetSupportedMode(string number, string supportMode)
        {
            bool supportedMode = false;
            if (!File.Exists(VantageConstContent.DriverExeFilePath))
            {
                throw new Exception("Tool: " + VantageConstContent.DriverExeFilePath + ", not found.");
            }
            Process process = new Process();
            process.StartInfo.FileName = VantageConstContent.DriverExeFilePath;
            process.StartInfo.WorkingDirectory = VantageConstContent.WorkPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.Start();
            process.StandardInput.WriteLine(number);
            process.StandardInput.WriteLine("{enter}");
            process.StandardInput.WriteLine("q");

            StreamReader reader = process.StandardOutput;
            while (!reader.EndOfStream)
            {
                string output = reader.ReadLine();
                if (output.Contains(supportMode))
                {
                    supportedMode = true;
                }
            }
            process.Close();
            return supportedMode;
        }

        public static string getPackageFullName(string appName)
        {
            String resultOutput = string.Empty;
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.Arguments = string.Format("/C powershell Get-AppxPackage -Name \"{0}\"", appName);
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            proc.WaitForExit();
            resultOutput = proc.StandardOutput.ReadToEnd();
            string[] appInfo = resultOutput.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            string value = string.Empty;
            for (int i = 0; i < appInfo.Length; i++)
            {
                if (appInfo[i].Trim() == "PackageFullName")
                {
                    value = appInfo[i + 1];
                }
            }

            return value;
        }
        public static string getPackageFamilyName(string appName)
        {
            String resultOutput = string.Empty;
            Process proc = new Process();
            proc.StartInfo.FileName = "cmd.exe";
            proc.StartInfo.Arguments = string.Format("/C powershell Get-AppxPackage -Name \"{0}\"", appName);
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.Start();
            proc.WaitForExit();
            resultOutput = proc.StandardOutput.ReadToEnd();
            string[] appInfo = resultOutput.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

            string value = string.Empty;
            for (int i = 0; i < appInfo.Length; i++)
            {
                if (appInfo[i].Trim() == "PackageFamilyName")
                {
                    value = appInfo[i + 1];
                }
            }

            return value;
        }

        public static void LowerThanBatteryValue(int value)
        {
            int currentPercent = GetCurrentBatteryPercent();
            int initBatteryValue = currentPercent;
            int tryTimes = 5;
            if (currentPercent > value)
            {
                CmdCommands.ReduceBatteryValue();
                do
                {
                    Thread.Sleep(TimeSpan.FromMinutes(1));
                    currentPercent = GetCurrentBatteryPercent();
                    if (initBatteryValue == currentPercent)
                    {
                        CmdCommands.ReduceBatteryValue();
                    }
                    tryTimes--;
                    if (tryTimes < 0)
                    {
                        break;
                    }
                } while (currentPercent > value);
                CmdCommands.IncreaseBatteryValue();
            }
        }

        public static void MoreThanBatteryValue(int value)
        {
            int currentPercent = GetCurrentBatteryPercent();
            int initBatteryValue = currentPercent;
            int tryTimes = 5;
            if (currentPercent < value)
            {
                CmdCommands.IncreaseBatteryValue();
                do
                {
                    Thread.Sleep(TimeSpan.FromSeconds(30));
                    currentPercent = GetCurrentBatteryPercent();
                    if (initBatteryValue == currentPercent)
                    {
                        CmdCommands.ReduceBatteryValue();
                    }
                    tryTimes--;
                    if (tryTimes < 0)
                    {
                        break;
                    }
                } while (currentPercent < value);
            }
        }

        /// <summary>
        /// Please take care of the "Conservation mode" and "Battery Charge Threshold" feature
        /// When we use this function, please turn off both of them
        /// </summary>
        public static bool SetBatteryPercent(int value, bool isLess = false)
        {
            int currentPercent = GetCurrentBatteryPercent();
            ProgrammableLogicControllersHelper plc = new ProgrammableLogicControllersHelper();
            if (isLess)
            {
                if (currentPercent > value)
                {
                    int tryAcToDc = 0;
                    do
                    {
                        if (JudgeInsertStatusIsOn())
                        {
                            plc.StartPLCViaOptionPanel(PLCStatus.Start);  //change DC
                            tryAcToDc++;
                        }
                        if (!JudgeInsertStatusIsOn() || tryAcToDc > 6)
                        {
                            break;
                        }
                    } while (true);

                    if (!JudgeInsertStatusIsOn())
                    {
                        int tryWaitMinutes = 150;
                        do
                        {
                            Thread.Sleep(TimeSpan.FromMinutes(1));
                            currentPercent = GetCurrentBatteryPercent();
                            tryWaitMinutes--;
                            if (currentPercent < value)
                            {
                                return true;
                            }
                            if (tryWaitMinutes < 0)
                            {
                                break;
                            }
                        } while (true);
                    }
                    return false;
                }
                else
                {
                    return true;
                }

            }
            else
            {
                if (currentPercent < value)
                {
                    int tryDcToAc = 0;
                    do   // set AC
                    {
                        if (!JudgeInsertStatusIsOn())
                        {
                            plc.StartPLCViaOptionPanel(PLCStatus.Stop);   //change AC
                            tryDcToAc++;
                        }
                        if (JudgeInsertStatusIsOn() || tryDcToAc > 6)
                        {
                            break;
                        }
                    } while (true);

                    if (JudgeInsertStatusIsOn())
                    {
                        int tryWaitMinutes = 150;
                        do
                        {
                            Thread.Sleep(TimeSpan.FromMinutes(1));
                            currentPercent = GetCurrentBatteryPercent();
                            tryWaitMinutes--;
                            if (currentPercent > value)
                            {
                                return true;
                            }
                            if (tryWaitMinutes < 0)
                            {
                                break;
                            }
                        } while (true);
                    }
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary> 0:Start Service | 1:Stop Service | default: Start Service </summary>
        /// <param name="obj"></param>
        public static void ServiceControl(string serviceName, int obj = 2)
        {
            switch (obj)
            {
                case 0:
                    Common.StartService(serviceName);
                    break;
                case 1:
                    Common.StopService(serviceName);
                    break;
                default:
                    Common.StartService(serviceName);
                    break;
            }
        }

        public static void ReplaceFile()
        {
            try
            {
                string xmlFilePath = string.Empty;
                if (Directory.Exists(VantageConstContent.VantageInstallPs1Path))
                {
                    xmlFilePath = VantageConstContent.VantageInstallPs1Server;
                }
                if (File.Exists(xmlFilePath))
                {
                    string context = File.ReadAllText(xmlFilePath);
                    string packeageName = string.Format("Packages\\{0}\\LocalState\\config.json", VantageConstContent.GetVantageUwpAppName() + "_k1h2ywk1493x8");
                    string companionLogPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), packeageName);
                    if (File.Exists(companionLogPath))
                    {
                        File.Delete(companionLogPath);
                    }
                    File.AppendAllText(companionLogPath, context);
                    LogHelper.Logger.Instance.WriteLog(File.ReadAllText(companionLogPath));
                    // note: new shell need change below
                    if (!context.ToLower().Contains("\"env\": \"beta\",") && VantageConstContent.VantageInstallPs1Path.Contains("bj_latest"))
                    {
                        ReplaceFileVantageconfig();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ReplaceFile() Error,info:" + ex.Message);
            }
        }

        public static void ReplaceFileVantageconfig()
        {
            string xmlFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, VantageConstContent.GetVantageFileName());
            if (File.Exists(xmlFilePath))
            {
                string context = File.ReadAllText(xmlFilePath);
                string packeageName = string.Format("Packages\\{0}\\LocalState\\VantageConfig.xml", VantageConstContent.GetVantageUwpAppName() + "_k1h2ywk1493x8");
                string VantageConfigPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), packeageName);
                if (File.Exists(VantageConfigPath))
                {
                    File.Delete(VantageConfigPath);
                }
                File.AppendAllText(VantageConfigPath, context);
                try
                {
                    File.SetAttributes(VantageConfigPath, FileAttributes.ReadOnly);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void TaskFindTogglerRunButton(ManualResetEvent resetEvent)
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            Task task = new Task(async () =>
            {
                while (true)
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    resetEvent.WaitOne();
                    AutomationElement element = FindElementByIdIsEnabled("togglerRun", 1);
                    InvokePattern elementInvoke = null;
                    try
                    {
                        if (element != null)
                        {
                            elementInvoke = element.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                            elementInvoke.Invoke();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Task: " + ex.Message);
                    }
                    await Task.Delay(500);
                }

            }, token);

            task.Start();
        }
        public static WindowsElement FindElementByXPathAndEnabled(WindowsDriver<WindowsElement> windowsDriver, string xpath, double timeOut = 15)
        {
            WindowsElement windowsElement = null;

            while (timeOut > 0)
            {
                try
                {

                    if (windowsDriver.PageSource != null)
                    {
                        windowsElement = windowsDriver.FindElementByXPath(xpath);
                    }
                    if (windowsElement != null && windowsElement.Enabled)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message + ": " + xpath);
                    if (ex.Message.Contains("Currently selected window has been closed") || ex.Message.Contains("No active session with ID"))
                    {
                        windowsDriver = GetSessionInstance();
                    }
                }
                timeOut--;
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            return windowsElement;
        }

        public static WindowsDriver<WindowsElement> GetSessionInstance()
        {
            WindowsDriver<WindowsElement> session = LaunchSystemUwp(VantageConstContent.VantageUwpAppid);
            //TaskFindRetryButton(resetEvent);
            return session;
        }

        public static AutomationElement FindElementByIdIsEnabled(string automationId, int timeout = 50, bool isEnabled = true)
        {
            AutomationElement targetElement = null;
            int index = timeout;
            try
            {
                targetElement = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, automationId), new PropertyCondition(AutomationElement.IsEnabledProperty, isEnabled)));

                while (targetElement == null)
                {
                    targetElement = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, automationId), new PropertyCondition(AutomationElement.IsEnabledProperty, isEnabled)));
                    Thread.Sleep(500);
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

        public static AutomationElement FindElement(string appName, string automationId = null, string name = null, int timeout = 6)
        {
            AutomationElement targetElement = null;
            try
            {

                if (string.IsNullOrEmpty(automationId) && string.IsNullOrEmpty(name))
                {
                    return targetElement;
                }
                timeout *= 10;
                do
                {
                    AutomationElement targetProcess;
                    if (string.IsNullOrEmpty(appName))
                        targetProcess = AutomationElement.RootElement;
                    else
                        targetProcess = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, appName));
                    if (targetProcess != null)
                    {
                        if (!string.IsNullOrEmpty(automationId) && string.IsNullOrEmpty(name))
                        {
                            targetElement = targetProcess.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.AutomationIdProperty, automationId));
                            if (targetElement != null)
                            {
                                break;
                            }
                        }
                        if (string.IsNullOrEmpty(automationId) && !string.IsNullOrEmpty(name))
                        {
                            targetElement = targetProcess.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.NameProperty, name), new PropertyCondition(AutomationElement.IsEnabledProperty, true)));
                            if (targetElement != null)
                            {
                                break;
                            }
                        }
                        if (!string.IsNullOrEmpty(automationId) && !string.IsNullOrEmpty(name))
                        {
                            targetElement = targetProcess.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, automationId), new PropertyCondition(AutomationElement.NameProperty, name), new PropertyCondition(AutomationElement.IsEnabledProperty, true)));
                            if (targetElement != null)
                            {
                                break;
                            }
                        }
                    }
                    System.Threading.Thread.Sleep(500);
                    timeout--;
                }
                while (timeout > 0);
            }
            catch (Exception ex)
            {
                throw new Exception("FindElement() exception: " + ex.Message);
            }

            return targetElement;
        }

        public static ToggleState GetToggleStatus(WindowsElement windowsElement)
        {
            ToggleState toggleState = ToggleState.Indeterminate;
            if (windowsElement != null)
            {
                if (windowsElement.GetAttribute("Toggle.ToggleState") == "1")
                {
                    toggleState = ToggleState.On;
                }
                else if (windowsElement.GetAttribute("Toggle.ToggleState") == "0")
                {
                    toggleState = ToggleState.Off;
                }
            }
            return toggleState;
        }
        public static bool SwitchToggleStatus(WindowsElement checkBox, ToggleState toggleState, bool verify = true)
        {
            if (GetToggleStatus(checkBox) != toggleState)
            {
                checkBox.Click();
            }
            if (verify)
            {
                if (GetToggleStatus(checkBox) == toggleState)
                {
                    return true;
                }
                return false;
            }
            return true;
        }

        public static bool ClickWithPosition(string projectName, string imageName, string caseName, int timeout = 5, bool toolbar = false)
        {
            bool imageExists = false;
            for (int i = 0; i < timeout; i++)
            {
                imageExists = IsFindImageFromCurrentScreen(projectName, imageName, caseName, toolbar);
                if (imageExists)
                {
                    break;
                }
                Thread.Sleep(1000);
            }
            return imageExists;
        }
        public static bool IsFindImageFromCurrentScreen(string projectName, string inputImage, string caseName, bool toolbar = true)
        {
            int timeout = 0;
            bool checkImage = false;
            var imageContrast = @"C:\Fitnesse\ImageContrast\";
            if (!Directory.Exists(imageContrast))
            {
                throw new Exception("PATH: " + imageContrast + ",not found.");
            }
            var imagePath = imageContrast + projectName;
            string imageFile = Path.Combine(imagePath, inputImage);
            FileInfo fi = new FileInfo(imageFile);
            string file = fi.Name;
            if (file.Split('.').Length == 1)
            {
                imageFile = imageFile + ".png";
            }
            if (!File.Exists(imageFile))
            {
                throw new Exception("The image not exists.");
            }
            Process[] ps = Process.GetProcessesByName("GetPosiTion");
            if (ps.Length > 0)
            {
                foreach (Process process in ps)
                {
                    process.Kill();
                }
            }
            string cmd = string.Format("C:\\Fitnesse\\GetPosiTion.exe {0} \"{1}\"", imageFile, caseName);
            OpenCmdRunCommand(cmd);

            if (toolbar)
            {
                FindElementByIdAndMouseClick("2000");
            }
            while (timeout < 60)
            {
                Thread.Sleep(5 * 1000);
                ps = Process.GetProcessesByName("GetPosiTion");
                if (ps.Length == 0)
                {
                    break;
                }
                timeout++;
            }
            var f = File.ReadAllText(@"C:\Fitnesse\Position.log");
            if (f.Contains(caseName))
            {
                if (!f.Contains("empty"))
                {
                    checkImage = true;
                }
            }
            else
            {
                throw new Exception("The case don't match. CaseName: " + caseName);
            }
            return checkImage;

        }
        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        public static extern void keybd_event(System.Windows.Forms.Keys bVk, System.Windows.Forms.Keys bScan, int dwFlags, int dwExtraInfo);

        public static void OpenCmdRunCommand(string setStr = "ms-settings:privacy-location")
        {
            try
            {
                keybd_event(System.Windows.Forms.Keys.LWin, 0, 0, 0);
                keybd_event(System.Windows.Forms.Keys.R, 0, 0, 0);
                keybd_event(System.Windows.Forms.Keys.LWin, 0, 2, 0);
                keybd_event(System.Windows.Forms.Keys.R, 0, 2, 0);
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
        [DllImport("user32.dll")]
        static extern void mouse_event(MouseEventFlag flags, int dx, int dy, uint data, UIntPtr extraInfo);

        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
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
        public const int MOUSEEVENTF_MOVE = 0x0001;  // 移动鼠标
        public const int MOUSEEVENTF_LEFTDOWN = 0x0002;// 模拟鼠标左键按下
        public const int MOUSEEVENTF_LEFTUP = 0x0004; //模拟鼠标左键抬起
        public const int MOUSEEVENTF_RIGHTDOWN = 0x0008; //模拟鼠标右键按下
        public const int MOUSEEVENTF_RIGHTUP = 0x0010;// 模拟鼠标右键抬起
        public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020; //模拟鼠标中键按下
        public const int MOUSEEVENTF_MIDDLEUP = 0x0040; //模拟鼠标中键抬起
        public const int MOUSEEVENTF_WHEEL = 0x800;//滚轮滚动
        public const int MOUSEEVENTF_ABSOLUTE = 0x8000; //标示是否采用绝对坐标

        [DllImport("user32.dll")] public static extern bool SetCursorPos(int X, int Y);
        public static void DoubleClick(WindowsElement windowsElement)
        {
            var position3 = windowsElement.Location;
            var size = windowsElement.Size;
            string x = (position3.X + size.Width / 2).ToString();
            string y = (position3.Y + size.Height / 2).ToString();
            SetMouseClick(x, y, true);
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTDOWN, Convert.ToInt32(x), Convert.ToInt32(y), 0, 0);
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTUP, Convert.ToInt32(x), Convert.ToInt32(y), 0, 0);
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTDOWN, Convert.ToInt32(x), Convert.ToInt32(y), 0, 0);
            mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_LEFTUP, Convert.ToInt32(x), Convert.ToInt32(y), 0, 0);
            Thread.Sleep(1000);
        }

        public static void MouseClickElemnt<T>(T e)
        {
            string x = string.Empty;
            string y = string.Empty;
            if (e is WindowsElement)
            {
                var position = (e as WindowsElement).Location;
                var rect = (e as WindowsElement).Rect;
                x = (position.X + rect.Width / 2).ToString();
                y = (position.Y - rect.Height / 2).ToString();
            }
            else if (e is AutomationElement)
            {
                var position = (e as AutomationElement).Current.BoundingRectangle;
                x = ((int)position.Left + (int)position.Width / 2).ToString();
                y = ((int)position.Bottom - (int)position.Height / 2).ToString();
            }
            SetMouseClick(x, y);
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
            mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute, position_x * 65535 / Screen.PrimaryScreen.Bounds.Width, position_y * 65535 / Screen.PrimaryScreen.Bounds.Height, 0, new UIntPtr(0));
            SetCursorPos(position_x, position_y);

            Thread.Sleep(500);
            if (!isMove)
            {
                Thread.Sleep(500);
                mouse_event(MouseEventFlag.LeftDown, position_x * 65535 / Screen.PrimaryScreen.Bounds.Width, position_y * 65535 / Screen.PrimaryScreen.Bounds.Height, 0, new UIntPtr(0));
                mouse_event(MouseEventFlag.LeftUp, position_x * 65535 / Screen.PrimaryScreen.Bounds.Width, position_y * 65535 / Screen.PrimaryScreen.Bounds.Height, 0, new UIntPtr(0));
                Thread.Sleep(500);
            }
            Console.WriteLine("x=" + x + " , y= " + y);
            Debug.WriteLine("x=" + x + " , y= " + y);
        }
        public static void OpenToolBar()
        {
            try
            {
                Process.Start(_showGauge);
            }
            catch
            {
                throw new Exception(_showGauge + ": Error.");
            }
        }
        public static void UnpinToolBar()
        {
            try
            {
                Process.Start(_hideGauge);
            }
            catch
            {
                throw new Exception(_hideGauge + ": Error.");
            }
        }
        public static AutomationElement FindElementByIdAndMouseClick(string automationId, int findTimes = 2, bool isLeftClick = true, string type = null)
        {
            AutomationElement automationElement = FindElementByIdIsEnabled(automationId, findTimes);
            if (automationElement != null)
            {
                var position = automationElement.Current.BoundingRectangle;
                string x = ((int)position.Left + (int)position.Width / 2).ToString();
                string y = ((int)position.Bottom - (int)position.Height / 2).ToString();
                if (isLeftClick)
                {
                    SetMouseClick(x, y, false);
                }
                else
                {
                    MouseRightClick(x, y, false);
                }
            }
            return automationElement;
        }

        public static void ClickBelowTheElement(string automationId, int findTimes = 2, int num = 30)
        {
            AutomationElement automationElement = FindElementByIdIsEnabled(automationId, findTimes);
            if (automationElement != null)
            {
                var position = automationElement.Current.BoundingRectangle;
                string x = ((int)position.Left + (int)position.Width / 2).ToString();
                string y = ((int)position.Bottom - (int)position.Height / 2 + num).ToString();
                SetMouseClick(x, y, false);
            }
        }

        public static void ClickSystemControl(AutomationElement automationElement)
        {
            var position = automationElement.Current.BoundingRectangle;
            string x = ((int)position.Left + (int)position.Width / 2).ToString();
            string y = ((int)position.Bottom - (int)position.Height / 2).ToString();
            SetMouseClick(x, y, false);
        }

        internal static void MouseRightClick(string x, string y, bool isMove = false)
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
                mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_RIGHTDOWN, position_x, position_y, 0, 0);
                mouse_event(MOUSEEVENTF_ABSOLUTE | MOUSEEVENTF_RIGHTUP, position_x, position_y, 0, 0);
                Thread.Sleep(500);
            }
            Console.WriteLine("x=" + x + " , y= " + y);
        }
        public static bool PerformanceSwitchToggle(WindowsElement checkbox)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    checkbox.Click();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string GetAttributeValue(WindowsElement windowsElement, string attribute)
        {
            string value = string.Empty;
            if (windowsElement != null)
            {
                value = windowsElement.GetAttribute(attribute);
                if (attribute == "AriaProperties")
                {
                    value = value.Split(';')[5].Split('=')[1];
                }
            }
            return value;
        }
        public static bool DragSlider(WindowsDriver<WindowsElement> session, WindowsElement sliderBar, int offsetX)
        {
            try
            {
                Actions moveSlider = new Actions(session);
                IAction action = moveSlider.DragAndDropToOffset(sliderBar, offsetX, 0).Build();
                action.Perform();
            }
            catch
            {
                return false;
            }
            return true;
        }
        public static void DoMouseMove(int x, int y)
        {
            int dx = (int)((double)x / Screen.PrimaryScreen.Bounds.Width * 65535); //屏幕分辨率映射到0~65535(0xffff,即16位)之间
            int dy = (int)((double)y / Screen.PrimaryScreen.Bounds.Height * 0xffff); //转换为double类型运算，否则值为0、1
            mouse_event(MouseEventFlag.Move | MouseEventFlag.Absolute, dx, dy, 0, new UIntPtr(0)); //move to x,y
        }

        public static System.Windows.Point GetWindowsElementPoint(WindowsElement element)
        {
            System.Windows.Point point = new System.Windows.Point();
            point.X = element.Location.X + element.Rect.Width / 2;
            point.Y = element.Location.Y + element.Rect.Height / 2;
            return point;
        }

        private static AutomationElement FindElementById(string automationId, int timeout = 20)
        {
            AutomationElement targetElement = null;
            int index = timeout;
            try
            {
                targetElement = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.AutomationIdProperty, automationId));

                while (targetElement == null)
                {
                    targetElement = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.AutomationIdProperty, automationId));
                    Thread.Sleep(500);
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

        private static void moveToObjectByXY(AutomationElement element)
        {
            object _Objectpos = element.GetCurrentPropertyValue(AutomationProperty.LookupById(30001));
            string _str = _Objectpos.ToString();
            String[] _objpos = _str.Split(new char[] { ',' });
            int _x = int.Parse(_objpos[0]) + int.Parse(_objpos[2]) / 2;
            int _y = int.Parse(_objpos[1]) + int.Parse(_objpos[3]) / 2;
            VantageCommonHelper.DoMouseMove(_x, _y);
            Thread.Sleep(1000);
            Console.WriteLine("Move to object[" + _x + ", " + _y + "]", ConsoleColor.Gray);
        }

        public static void HoverElement(string automationId)
        {
            AutomationElement notification = FindElementById(automationId);
            moveToObjectByXY(notification);
        }

        public static void HoverOnElement(WindowsElement element, bool isMove = true)
        {
            var position = element.Location;
            var size = element.Size;
            string x = (position.X + size.Width / 2).ToString();
            string y = (position.Y + size.Height / 2).ToString();
            SetMouseClick(x, y, isMove);
        }

        public static void HoverOnVantage(WindowsDriver<WindowsElement> session, WindowsElement element)
        {
            session.Mouse.MouseMove(element.Coordinates);
        }

        public static string GetValueFromRegedit(string names, string regeditPath)
        {
            string value = null;
            RegistryKey cv = OpenKey(regeditPath);
            if (cv != null)
            {
                try
                {
                    value = cv.GetValue(names, null).ToString();
                }
                catch
                {
                    value = null;
                }
            }
            return value;

        }

        public static RegistryKey OpenKey(string regeditPath)
        {
            try
            {
                RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
                RegistryKey cv = hklm.OpenSubKey(regeditPath, true);
                return cv;
            }
            catch
            {
                throw new Exception("Failed: get value from regedit.");
            }
        }

        public static WindowsDriver<WindowsElement> LaunchDolbyUwp(bool isAccess = false)
        {
            var dolby = isAccess ? "*DolbyAccess*" : "*Dolby*";
            UwpAppInfo comp = UwpAppManagement.SearchUwpAppByName(dolby);
            string appid = string.Empty;
            if (comp != null)
            {
                appid = comp.PackageFamilyName.Trim() + "!App";
                return LaunchSystemUwp(appid);
            }
            return null;
        }

        public static string GetElementName(WindowsElement windowsElement)
        {

            if (null == windowsElement)
            {
                return string.Empty;
            }
            return windowsElement.GetAttribute("Name");

        }

        public static void BackupLog(string expectedLocalPathName)
        {
            string expectedSehllLocalPath = Path.Combine(VantageConstContent.VantageErrorLogs, "Shell", expectedLocalPathName);
            FileManager.CopyDirectoryRecursive(VantageConstContent.VantageShellLocalLogsFolderPath, expectedSehllLocalPath);
            FileManager.EmptyAFolder(VantageConstContent.VantageShellLocalLogsFolderPath);

            string expectedLenovoLocalPath = Path.Combine(VantageConstContent.VantageErrorLogs, "Lenovo", expectedLocalPathName);
            FileManager.CopyDirectoryRecursive(VantageConstContent.VantageLenovoLocalLogsFolderPath, expectedLenovoLocalPath);
            FileManager.EmptyAFolder(VantageConstContent.VantageLenovoLocalLogsFolderPath);

            string expectedServiceLocalPath = Path.Combine(VantageConstContent.VantageErrorLogs, "Service", expectedLocalPathName);
            FileManager.CopyDirectoryRecursive(VantageConstContent.VantageServiceLocalLogsFolderPath, expectedServiceLocalPath);
            FileManager.EmptyAFolder(VantageConstContent.VantageServiceLocalLogsFolderPath);
        }


        public static void FlushGifContainer(WindowsDriver<WindowsElement> session)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var windowsElement = FindElementByXPath(session, VantageConstContent.VantageGifContainer, 1);
            while (windowsElement != null)
            {
                windowsElement = FindElementByXPath(session, VantageConstContent.VantageGifContainer, 1);
                Thread.Sleep(500);
                if (stopwatch.Elapsed.TotalMinutes > 10)
                {
                    throw new Exception("Lanunch Vantage Time Out , more than 10 minnutes");
                }
            }
        }

        public static void CloseAlertWindow(WindowsDriver<WindowsElement> session)
        {
            if (VantageConstContent.VantageTypePlan == VantageConstContent.VantageType.NewShellNewPlugin || VantageConstContent.VantageTypePlan == VantageConstContent.VantageType.NewShellOldPlugin || VantageConstContent.VantageTypePlan == VantageConstContent.VantageType.LE)
            {
                return;
            }

            string alertAutomationIdXapth = "//*[contains(@AutomationId, 'snackbar-close-btn')]";

            BasePage basePage = new BasePage();
            WindowsElement alertWindowCloseButton = FindElementByXPath(session, alertAutomationIdXapth);
            alertWindowCloseButton?.Click();

            if (VantageConstContent.VantageTypePlan == VantageConstContent.VantageType.MicroFrontends && Constants.CurrentComponentType != Constants.ComponentType.Gaming)
            {

                WindowsElement DeviceMenuLink = basePage.FindElementByTimes(session, "AutomationId", basePage.GetAutomationIdFromPredefinedJsonFile("$.Navbar.device"));
                DeviceMenuLink?.Click();
                WindowsElement subSettingsLink = basePage.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'menu-main-nav-lnk-dropdown-menu-device-device-settings-')]", 10);
                subSettingsLink?.Click();
                WindowsElement alertWindowSettingsCloseButton = FindElementByXPath(session, alertAutomationIdXapth);


                if (alertWindowSettingsCloseButton != null)
                {
                    alertWindowSettingsCloseButton.Click();
                }
                else
                {
                    if (alertWindowCloseButton != null)
                    {
                        LogHelper.Logger.Instance.WriteLog("We point to Micro Version, but the version is wrong, The ip is " + Constants.CurrentAgentMachineIp);
                        // Copy Log To Data File
                        string expectedLocalPath = "C:\\" + Constants.CurrentAgentMachineIp;
                        FileManager.CopyDirectoryRecursive(VantageConstContent.VantageShellLocalLogsFolderPath, expectedLocalPath);
                    }
                }
                WindowsElement DashBoardPage = basePage.FindElementByTimes(session, "AutomationId", basePage.GetAutomationIdFromPredefinedJsonFile("$.Dashboard.DashboardButton"));
                DashBoardPage?.Click();
            }
        }

        ///需要引入IWshRuntimeLibrary，搜索Windows Script Host Object Model
        /// <summary>
        /// 创建快捷方式
        /// </summary>
        /// <param name="directory">快捷方式所处的文件夹</param>
        /// <param name="shortcutName">快捷方式名称</param>
        /// <param name="targetPath">目标路径</param>
        /// <param name="description">描述</param>
        /// <param name="iconLocation">图标路径，格式为"可执行文件或DLL路径, 图标编号"， 例如System.Environment.SystemDirectory + "\\" + "shell32.dll, 165"</param>
        /// <remarks></remarks>
        public static void CreateShortcut(string directory, string shortcutName, string targetPath, string description = null, string iconLocation = null)
        {
            if (!System.IO.Directory.Exists(directory))
            {
                System.IO.Directory.CreateDirectory(directory);
            }
            string shortcutPath = Path.Combine(directory, string.Format("{0}.lnk", shortcutName));
            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutPath);//创建快捷方式对象
            shortcut.TargetPath = targetPath;//指定目标路径
            shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);//设置起始位置
            shortcut.WindowStyle = 1;//设置运行方式，默认为常规窗口
            shortcut.Description = description;//设置备注
            shortcut.IconLocation = string.IsNullOrWhiteSpace(iconLocation) ? targetPath : iconLocation;//设置图标路径
            shortcut.Save();//保存快捷方式
        }

        public static bool JudgeMachineNewOS()
        {
            int newOsVersion = 22000;
            bool flag = false;
            RegistryKey softwareRegedit = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            if (Convert.ToInt32(softwareRegedit.GetValue("CurrentBuildNumber")) >= newOsVersion)
            {
                var ver = DesktopPowerManagementHelper.RunCmd("ver", false, true);
                string verSion = ver.Substring(ver.LastIndexOf(" ") + 1, ver.IndexOf("]") - ver.LastIndexOf(" ") - 1);
                string[] allVersion = verSion.Split('.');
                string b = allVersion[3];
                if (Convert.ToInt32(b[0]) >= 5)
                {
                    flag = true;
                }
            }
            return flag;
        }

    }
}
