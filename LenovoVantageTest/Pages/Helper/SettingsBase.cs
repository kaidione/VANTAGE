using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;

namespace LenovoVantageTest.Pages
{

    public class SettingsBase : BasePage
    {
        protected WindowsDriver<WindowsElement> session;
        protected static RemoteTouchScreen touchScreen;
        private static string _showGauge = @"C:\ProgramData\Lenovo\ImController\Plugins\LenovoBatteryGaugePackage\x64\ShowBatteryGauge";
        private static string _realtekDriverPath = "C:\\Program Files\\Realtek\\Audio\\HDA\\RAVCpl64.exe";
        private static string itsRegeditPathCN = "SYSTEM\\CurrentControlSet\\Services\\LITSSVC\\LNBITS\\IC";
        InformationalWebDriver webDriver;
        private static Thread threadinfo;
        public static string OptionType;

        public SettingsBase() { }

        public SettingsBase(WindowsDriver<WindowsElement> _session)
        {
            session = _session;
            base.session = _session;
        }

        public enum ClickButton
        {
            OK_Btn,
            Change_Btn,
            Close_Btn,
            Ignore_Btn,
            RedIgnore_Btn,
            NoThanks_Btn,
            Reenable_Btn,
            Lws_Content,
            learnmore_Btn,
            Turnon_Btn
        }

        public string VantageMinizeId = "//*[@AutomationId='Minimize']";
        public string VantageMaxizeId = "//*[@AutomationId='Maximize']";

        public void MySettingsMenuDropClickFunction()
        {
            WindowsElement element = FindElementByApp(session, "AutomationId", "Navbar", "device");
            if (element != null)
            {
                element.Click();
                WindowsElement dropList = FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, 'menu-main-nav-lnk-dropdown-menu-device-device-settings-')]", 15, 5);
                if (dropList == null)
                {
                    WindowsElement dashboadEle = FindElementByTimes(session, "AutomationId", "menu-main-nav-lnk-dashboard", 10);
                    dashboadEle.Click();
                    HoverOnElement(session, element);
                }
            }
        }


        public WindowsElement MySettingsMenuDropDownEle
        {
            get
            {
                WindowsElement element = FindElementByApp(session, "AutomationId", "Navbar", "device");
                if (element != null)
                {
                    element.Click();
                    WindowsElement dropList = FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, 'menu-main-nav-lnk-dropdown-menu-device-device-settings-')]", 15, 5);
                    if (dropList == null)
                    {
                        WindowsElement dashboadEle = FindElementByTimes(session, "AutomationId", "menu-main-nav-lnk-dashboard", 10);
                        dashboadEle.Click();
                        HoverOnElement(session, element);
                    }
                }

                return element;
            }
        }
        //=> FindElementByApp(session, "AutomationId", "Navbar", "device");
        public WindowsElement ProductivityEle => FindElementByTimes(session, "XPath", "//*[@AutomationId='menu-main-nav-lnk-dropdown-toggle-smb']");
        public WindowsElement Creatorsettings => FindElementByTimes(session, "XPath", "//*[@Name='Creator settings']");
        public WindowsElement SecurityMenuDropDownEle => FindElementByApp(session, "AutomationId", "Navbar", "security");
        public WindowsElement MySettingsMenuEle => FindElementByApp(session, "AutomationId", "Navbar", "device_setting_link");
        public WindowsElement MySettingsPowerMenuEle => FindElementByApp(session, "AutomationId", "Navbar", "device_setting_power_link");
        public WindowsElement MySettingsDetailsMenuEle => FindElementByApp(session, "AutomationId", "Navbar", "device_setting_details_link");
        public WindowsElement AudioSettingsPage => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Navbar.device_setting_Audio_link"), 10);
        public WindowsElement DisplayCameraSettingsPageMenuLink => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Navbar.device_setting_camera_link"), 10);
        public WindowsElement InputSettingsPageMenuLink => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Navbar.device_setting_input_link"), 10);
        public WindowsElement MettingManagerPage => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Navbar.productivity"));
        public WindowsElement JumptoBatterySettingsEle => GetElement(session, "AutomationId", "jumptoSetting-battery");
        public WindowsElement JumptoToolbarEle => GetElement(session, "AutomationId", "jumptoSetting-other");
        public WindowsElement MySettingsPower => GetElement(session, "AutomationId", "myDevice-settings-header-menu-power");//-title
        public WindowsElement MySettingsAudio => GetElement(session, "AutomationId", "myDevice-settings-header-menu-audio");
        public WindowsElement MySettingsDisplay => GetElement(session, "AutomationId", "myDevice-settings-header-menu-display-camera");
        public WindowsElement SmartAssist => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Navbar.smartAssist_down"), 10);
        public WindowsElement MinisizeButton => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Navbar.MinimizeWindows"), 10);
        public WindowsElement MySettingsInputTab => base.GetElement(session, "AutomationId", "myDevice-settings-header-menu-input-accessories", 10);
        public WindowsElement SmartAssistPageLinkDown => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Navbar.smartAssist_down"));
        public WindowsElement SmartAssistPageLinkLeft => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Navbar.smartAssist_left"));
        public WindowsElement CHSSecurity => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-toggle-security");
        public WindowsElement DropDownCHS => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-security-home-security-1");
        public WindowsElement HSSecurity => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-toggle-security");
        public WindowsElement HSWIFISecurity => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-security-device-security-2");

        public WindowsElement WebviewElement => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='webview']");

        //Audio
        public WindowsElement AudioLabelTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-settings-header-menu-audio']");
        public WindowsElement AudioLevel2Tiltle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='ds-audio-title']");
        public WindowsElement AudioJumptToSettingsTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='ds-audio-jumptToSettings-title']");

        //Display and Camera
        public WindowsElement MediaLabelTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-settings-header-menu-display-camera']");
        public WindowsElement MediaLevel2Tiltle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='ds-display-camera-title']");
        public WindowsElement MediaLevel2captionTiltle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='ds-display-camera-header-caption']");
        public WindowsElement MediaJumptToSettingsTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='ds-display-camera-jumptToSettings-title']");

        //Smart Assist
        public WindowsElement SmartAssistitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='smart-assist-title']");
        public WindowsElement SmartAssiscaption => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='smart-assist-header-caption']");

        //Input
        public WindowsElement InputLabelTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-settings-header-menu-input-accessories']");
        public WindowsElement InputLevel2Tiltle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-settings-ipaccessories-title']");
        public WindowsElement InputDescription => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-settings-ipaccessories-header-caption']");



        public WindowsElement FindElementByXpath(string xpath)
        {
            if (session != null)
            {
                return GetElement(session, "XPath", xpath);
            }
            return null;
        }


        public WindowsElement GetElement(WindowsDriver<WindowsElement> session, string elementClass, string locator, int timeOut = 60)
        {
            session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
            WindowsElement element = null;
            try
            {
                switch (elementClass)
                {
                    case "XPath":
                        element = session.FindElementByXPath(locator);
                        break;
                    case "Name":
                        element = session.FindElementByName(locator);
                        break;
                    case "AutomationId":
                        element = session.FindElementByAccessibilityId(locator);
                        break;
                    default:
                        break;
                };
                Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return element;
        }

        public ReadOnlyCollection<WindowsElement> GetElements(WindowsDriver<WindowsElement> session, string elementClass, string locator, int timeOut = 80)
        {
            session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
            ReadOnlyCollection<WindowsElement> element = null;
            try
            {
                switch (elementClass)
                {
                    case "XPath":
                        element = session.FindElementsByXPath(locator);
                        break;
                    case "Name":
                        element = session.FindElementsByName(locator);
                        break;
                    default:
                        break;
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return element;
        }

        public virtual void ScrollScreen()
        {
            touchScreen = new RemoteTouchScreen(session);
            touchScreen.Scroll(0, -500);
        }

        public void ScrollScreenToWindowsElement(WindowsDriver<WindowsElement> _session, WindowsElement element = null, int offsetY = -30, int scrolltimes = 10, bool isKeepScrollAgain = false)
        {
            do
            {
                touchScreen = new RemoteTouchScreen(_session);
                if (element != null)
                {
                    if (element.Displayed == true)
                    {
                        break;
                    }
                    touchScreen.Scroll(0, offsetY);
                }
                else
                {
                    touchScreen.Scroll(0, offsetY);
                }
                scrolltimes--;
            } while (scrolltimes > 0);
            if (isKeepScrollAgain)
            {
                touchScreen.Scroll(0, offsetY);
            }
        }

        public bool GetCurrentBetaServer()
        {
            string packeageName = string.Format("Packages\\{0}\\LocalState\\config.json", VantageConstContent.GetVantageUwpAppName() + "_k1h2ywk1493x8");
            string companionLogPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), packeageName);

            if (File.Exists(companionLogPath))
            {
                //{"webURL":"https://vantage-beta.csw.lenovo.com/"}
                string serverText = File.ReadAllText(companionLogPath);
                if (serverText.Contains("beta") || serverText.Contains("qa"))
                {
                    return true;
                }
            }
            return false;
        }

        public string ShowTextbox(WindowsElement windowsElement)
        {
            if (windowsElement == null)
            {
                return string.Empty;
            }
            return windowsElement.GetAttribute("Name");
        }

        public void DragElementTo(object element, string locationValue)
        {
            WindowsElement windowsElement = null;
            // get max value
            Random random = new Random();
            if (element is WindowsElement)
            {
                windowsElement = (WindowsElement)element;
            }
            else if (element is String)
            {
                windowsElement = base.FindElementByTimes(session, "AutomationId", element.ToString());
            }

            if (windowsElement == null)
            {
                return;
            }

            double currentMaxSliderValue = Convert.ToDouble(windowsElement.GetAttribute("RangeValue.Maximum"));
            double currentMinSliderValue = Convert.ToDouble(windowsElement.GetAttribute("RangeValue.Minimum"));
            double currentSliderValue = Convert.ToDouble(windowsElement.GetAttribute("RangeValue.Value"));
            double sliderValue = currentMaxSliderValue - currentMinSliderValue;
            double valuePercent = Math.Round(currentSliderValue / sliderValue, 2);
            double windthPercent = sliderValue / (windowsElement.Rect.Width);
            int currentSliderWidth = int.Parse(Math.Round(windowsElement.Rect.Width * valuePercent, 0).ToString());
            int x = 0;
            int y = 0;
            switch (locationValue.ToLower())
            {
                case "far left":
                    x = windowsElement.Location.X;
                    break;
                case "far right":
                    x = windowsElement.Location.X + windowsElement.Rect.Width - 1;
                    break;
                case "random left":
                    x = windowsElement.Location.X + random.Next(0, currentSliderWidth - 1);
                    break;
                case "random right":
                    x = windowsElement.Location.X + random.Next(currentSliderWidth + 1, currentSliderWidth + 100);
                    break;
                default:
                    break;
            }

            y = windowsElement.Location.Y + windowsElement.Rect.Height / 2 - 2;
            VantageCommonHelper.SetMouseClick(x.ToString(), y.ToString());
            VantageCommonHelper.SetMouseClick(x.ToString(), y.ToString());

        }


        public void HoverOnElement(WindowsDriver<WindowsElement> session, WindowsElement element)
        {
            session.Mouse.MouseMove(element.Coordinates);
        }

        public bool JumpToBatterySettings()
        {
            try
            {
                GoToMyDevicesSettings();
                if (LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent.VantageTypePlan != LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent.VantageType.LE)
                {
                    JumptoBatterySettingsEle.Click();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void GoToMyDevicesSettings()
        {
            bool isBetaServer = GetCurrentBetaServer();
            MySettingsMenuDropClickFunction();
            if (MySettingsPowerMenuEle == null)
            {
                MySettingsMenuDropClickFunction();
            }
            if (GoToMyDevicesSettingsViaEnclosureType(isBetaServer)) //For EnclosureType Machine
            {
                return;
            }
            MySettingsPowerMenuEle.Click();
        }
        public void GoToAudioPage()
        {
            bool isBetaServer = GetCurrentBetaServer();
            MySettingsMenuDropClickFunction();
            if (GoToMyDevicesSettingsViaEnclosureType(isBetaServer)) //For EnclosureType Machine
            {
                return;
            }
            AudioSettingsPage.Click();
        }
        public void GoToMeetingManagerPage()
        {
            bool isBetaServer = GetCurrentBetaServer();
            MySettingsMenuDropClickFunction();
            if (GoToMyDevicesSettingsViaEnclosureType(isBetaServer)) //For EnclosureType Machine
            {
                return;
            }
            MettingManagerPage.Click();
        }

        public void GotoProductivityCreatorsetting()
        {
            ProductivityEle.Click();
            Creatorsettings.Click();
        }

        public void GoToDevicesSettings()
        {
            bool isBetaServer = GetCurrentBetaServer();
            MySettingsMenuDropClickFunction();
            if (GoToMyDevicesSettingsViaEnclosureType(isBetaServer)) //For EnclosureType Machine
            {
                return;
            }
            MySettingsDetailsMenuEle.Click();
        }

        public bool GoToMyDevicesSettingsViaEnclosureType(bool isBetaServer)
        {
            if (DesktopPowerManagementHelper.GetMachineIsSpecificEnclosureType())
            {
                MySettingsDetailsMenuEle.Click();
                return true;
            }
            return false;
        }

        public void GotoMySettingsAudioPage()
        {
            GoToMyDevicesSettings();
            MySettingsAudio.Click();
        }

        public void GotoMySettingsDisplayCameraPage()
        {
            GoToMyDevicesSettings();
            MySettingsDisplay.Click();
        }

        public void GoToSmartAssistPage()
        {
            bool isBetaServer = GetCurrentBetaServer();
            MySettingsMenuDropClickFunction();
            if (isBetaServer)
            {
                SmartAssistPageLinkDown.Click();
            }
            else
            {
                SmartAssistPageLinkLeft.Click();
            }
        }

        public bool GotoInputPage()
        {
            try
            {
                GoToMyDevicesSettings();
                MySettingsInputTab.Click();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public void GoToCHS()
        {
            CHSSecurity.Click();
            CHSSecurity.Click();
            DropDownCHS.Click();
        }

        public void GoToLWS()
        {
            HSSecurity?.Click();
            HSWIFISecurity?.Click();
        }

        public static bool Sleep()
        {
            DateTime wakeUpTime = DateTime.Now, sleepTime = DateTime.Now;
            PowerManagement.Sleep(DateTime.Now.AddSeconds(60), (pm, args) =>
            {
                wakeUpTime = DateTime.Now;
            });
            System.Threading.Thread.Sleep(15000);
            if ((wakeUpTime - sleepTime).TotalSeconds < 2)
            {
                return false;
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));
            SendKeys.SendWait("{Enter}");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            return true;
        }

        public static bool Hibernate()
        {
            DateTime wakeUpTime = DateTime.Now, sleepTime = DateTime.Now;
            PowerManagement.Hibernate(DateTime.Now.AddSeconds(60), (pm, args) =>
            {
                wakeUpTime = DateTime.Now;
            });
            System.Threading.Thread.Sleep(15000);
            if ((wakeUpTime - sleepTime).TotalSeconds < 2)
            {
                return false;
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));
            SendKeys.SendWait("{Enter}");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            return true;
        }

        public static void SystemOption()
        {
            switch (OptionType.ToLower())
            {
                case "sleep":
                    Sleep();
                    break;
                case "hibernate":
                    Hibernate();
                    break;
                default:
                    Console.WriteLine("SystemOption parameter incorrect,Info:" + OptionType);
                    break;
            }
        }

        public static bool SystemOptionDefault()
        {
            threadinfo = new Thread(new ThreadStart(SystemOption));
            threadinfo.Start();
            int times = 0;
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    SendKeys.SendWait("{Enter}");
                    times++;

                    if (times > 5)
                    {
                        ThreadStop(threadinfo);
                        return true;
                    }
                    /*  缺少通过API 获取当前屏幕是否点亮方法
                    if (!ComputerScreenIsLocked())
                    {
                        ThreadStop(threadinfo);
                        return true;
                    }*/
                }
                catch
                {
                    Console.WriteLine("Try Wake up Fail");
                }
                Thread.Sleep(3000);
            }
            ThreadStop(threadinfo);
            return false;
        }

        public static void ThreadStop(Thread thread)
        {
            thread.Abort();
            thread.DisableComObjectEagerCleanup();
        }

        public bool IsThinkPad()
        {
            return VantageCommonHelper.IsThinkPad();
        }

        public bool IsIdeaPad()
        {
            return VantageCommonHelper.IsIdeaPad();
        }

        public string GetAudioDriverName()
        {
            string productName = string.Empty;
            string msg = string.Empty;
            string driverName = string.Empty;
            ManagementObjectCollection itemCollection = new ManagementObjectSearcher("select * from Win32_SoundDevice").Get();
            foreach (ManagementObject MO in itemCollection)
            {
                productName = (String)MO["ProductName"];
                if (productName.ToLower().Contains("realtek"))
                {
                    driverName = "Realtek";
                    if (!File.Exists(_realtekDriverPath))
                    {
                        driverName = "Realtek Console";
                    }
                }
                else if (productName.ToLower().Contains("synaptics") || productName.ToLower().Contains("smartaudio"))
                {
                    driverName = "SmartAudio";
                    break;
                }
            }
            return driverName;
        }

        public void OpenAudioScreenShot(string driverName, WindowsDriver<WindowsElement> session, string screenShotName)
        {
            if (driverName == "Realtek")
            {
                StartProgram("RAVCpl64", _realtekDriverPath);
                ClickWithUIA("Realtek HD Audio Manager", "", "Microphone Array", session, screenShotName);
            }
            else
            {
                StartProgram("RtkUWP", _realtekDriverPath);
                ClickWithUIA("Realtek Audio Console", "", "Microphone Array", session, screenShotName);
            }
        }

        private void ClickWithUIA(string appName, string autoID, string name, WindowsDriver<WindowsElement> session, string screenName)
        {
            var RealtekTabElement = VantageCommonHelper.FindElement(appName, autoID, name, 10);
            if (RealtekTabElement == null && name == "Microphone Array")
            {
                RealtekTabElement = VantageCommonHelper.FindElement(appName, autoID, "麦克风阵列", 10);
            }
            var position = RealtekTabElement.Current.BoundingRectangle;
            string x = ((int)position.Left + (int)position.Width / 2).ToString();
            string y = ((int)position.Bottom - (int)position.Height / 2).ToString();
            VantageCommonHelper.SetMouseClick(x, y);
            AddScreenshotIntoReport(screenName, ".", "Realtek");

            session.Manage().Window.Maximize();
        }

        private void StartProgram(string name, string realtekDriverPath)
        {
            if (name == "RtkUWP")
            {
                OpenRealtekConsole();
            }
            else
            {
                Process.Start(realtekDriverPath);
            }
        }

        private void OpenRealtekConsole()
        {
            var WindowsSearch = VantageCommonHelper.FindElementByIdIsEnabled("4101");
            if (WindowsSearch == null)
            {
                WindowsSearch = VantageCommonHelper.FindElementByIdIsEnabled("4103");
            }
            var position = WindowsSearch.Current.BoundingRectangle;
            string x = ((int)position.Left + (int)position.Width / 2).ToString();
            string y = ((int)position.Bottom - (int)position.Height / 2).ToString();
            VantageCommonHelper.SetMouseClick(x, y);

            SendKeys.SendWait("realtek");
            Thread.Sleep(1000);
            SendKeys.SendWait("{Enter}");
            Thread.Sleep(1000);
        }

        public static void SetLocationService(string state, string commond = "ms-settings:privacy-location", string globalPar = "Location")
        {
            Thread.Sleep(1500);
            Process.Start("ms-settings:privacy-webcam");
            Thread.Sleep(1000);
            Process.Start(commond);
            Thread.Sleep(500);
            Process.Start(commond);
            Thread.Sleep(1500);
            AutomationElement checkBox = SetLocationServiceInSettings(state, globalPar);
            //KillProcess("SystemSettings");
        }

        public static void SetAllowDestopAppToAccess(string state, string commond = "ms-settings:privacy-location", string globalPar = "Location")
        {
            Thread.Sleep(1500);
            Process.Start("ms-settings:privacy-webcam");
            Thread.Sleep(1000);
            Process.Start(commond);
            Thread.Sleep(1500);
            AutomationElement checkBox = SetAccessInSettings(state, globalPar);
            KillProcess("SystemSettings");
        }

        public static void KillProcess(string processName)
        {
            Common.KillProcess(processName, true);
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

        public static AutomationElement SetAccessInSettings(string status, string test = "Location")
        {
            //string automationid_one = string.Format("SystemSettings_CapabilityAccess_{0}_ClassicGlobal_ToggleSwitch", test);
            string automationid_one = string.Format("SystemSettings_CapabilityAccess_{0}_ToggleSwitch", test);
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

        public static void PinToolbar()
        {
            var toolbar = VantageCommonHelper.FindElementByIdIsEnabled("2000");
            if (toolbar == null)
            {
                try
                {
                    Process.Start(_showGauge);
                }
                catch (Exception ex)
                {
                    throw new Exception(_showGauge + " Error: " + ex);
                }
            }
        }

        public static void PinDTToolbar()
        {
            var toolbar = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(VantageConstContent.ToolBarAutoEnum.DTToolBar).ToString());
            if (toolbar == null)
            {
                try
                {
                    Process.Start(_showGauge);
                }
                catch (Exception ex)
                {
                    throw new Exception(_showGauge + " Error: " + ex);
                }
            }
        }

        public static ToggleState GetFeatureStatusFromToolbar(string automationID)
        {
            string status = string.Empty;
            var toolbar = VantageCommonHelper.FindElementByIdIsEnabled(automationID);
            Assert.NotNull(toolbar, "GetFeatureStatusFromToolbar(), the element not found! Info: name >>" + Enum.GetName(typeof(VantageConstContent.ToolBarAutoEnum), int.Parse(automationID)) + " AutoId >>" + automationID);
            string toolbarName = toolbar.Current.Name;
            toolbarName = toolbarName.Split(' ')[toolbarName.Split(' ').Length - 1].Trim('.');
            Console.WriteLine("ToolBar Status Info >>" + toolbarName);
            if (toolbarName == "on")
            {
                return ToggleState.On;
            }
            else if (toolbarName == "off" || toolbarName == "DISABLED")
            {
                return ToggleState.Off;
            }
            return ToggleState.Indeterminate;
        }

        public static string GetManyStatusFromToolbar(string automationID)
        {
            string status = string.Empty;
            var toolbar = VantageCommonHelper.FindElementByIdIsEnabled(automationID);
            Assert.NotNull(toolbar, "GetFeatureStatusFromToolbar(), the element not found! Info: name >>" + Enum.GetName(typeof(VantageConstContent.ToolBarAutoEnum), int.Parse(automationID)) + " AutoId >>" + automationID);
            string toolbarName = toolbar.Current.Name;
            toolbarName = toolbarName.Split(' ')[toolbarName.Split(' ').Length - 1].Trim('.');
            Console.WriteLine("ToolBar Status Info >>" + toolbarName);
            return toolbarName;
        }

        public ToggleState GetCameraStatusFromToolbarUsingLonName()
        {
            string cameraName = GetToolBarButtonName(Convert.ToInt32(ToolBarAutoEnum.Camera).ToString());
            if (cameraName == "Camera privacy mode off.")
            {
                return ToggleState.Off;
            }
            else if (cameraName == "Camera privacy mode on.")
            {
                return ToggleState.On;
            }
            else
            {
                return ToggleState.Indeterminate;
            }
        }

        public static bool GetGreyOutStatusFromToolbar(string automationID)
        {
            string status = string.Empty;
            var toolbar = VantageCommonHelper.FindElementByIdIsEnabled(automationID);
            Assert.NotNull(toolbar);
            string toolbarName = toolbar.Current.Name;
            toolbarName = toolbarName.Split(' ')[toolbarName.Split(' ').Length - 1].Trim('.');
            if (toolbarName == "DISABLED")
            {
                return true;
            }
            return false;
        }

        public static string GetITSStatusFromToolbar(string automationID)
        {
            var toolbar = VantageCommonHelper.FindElementByIdIsEnabled(automationID);
            var ITSstatus = toolbar.Current.Name;
            if (ITSstatus.Contains("Idea ITS"))
            {
                return "Idea ITS";
            }
            else if (ITSstatus.Contains("Battery saving"))
            {
                return "BSM";
            }
            else if (ITSstatus.Contains("Extreme performance"))
            {
                return "EPM";
            }
            else if (ITSstatus.Contains("Performance"))
            {
                return "Perf";
            }
            else if (ITSstatus.Contains("Cool & quiet"))
            {
                return "C&Q";
            }
            else if (IntelligentCoolingBaseHelper.GetLocalMachineRegeditValue("Version", itsRegeditPathCN) == "16384")
            {
                return "Auto";
            }
            else
            {
                return "ICM";
            }

        }

        public static void FindAndClickNotificationCenter(int timeout)
        {
            AutomationElementCollection targetElement = null;
            int index = timeout;
            try
            {
                targetElement = AutomationElement.RootElement.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.ClassNameProperty, "TrayButton"));

                while (targetElement == null)
                {
                    Thread.Sleep(500);
                    targetElement = AutomationElement.RootElement.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.ClassNameProperty, "TrayButton"));
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
            if (targetElement != null)
            {
                foreach (AutomationElement tarElement in targetElement)
                {
                    if (tarElement.Current.Name.Contains("Action Center"))
                    {
                        var targetElementInvoke = tarElement?.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                        targetElementInvoke?.Invoke();
                        return;
                    }
                }
            }
        }

        public static void ClickToastMessageBtn(ClickButton type)
        {
            string cmdCommand = string.Empty;
            switch (type)
            {
                case ClickButton.Close_Btn:
                    cmdCommand = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\ToastBtn\\ToastBtn3.exe");
                    Process.Start(cmdCommand);
                    break;
                case ClickButton.NoThanks_Btn:
                case ClickButton.Ignore_Btn:
                    cmdCommand = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\ToastBtn\\ToastBtn2.exe");
                    Process.Start(cmdCommand);
                    break;
                case ClickButton.OK_Btn:
                case ClickButton.Change_Btn:
                case ClickButton.Reenable_Btn:
                case ClickButton.learnmore_Btn:
                case ClickButton.Turnon_Btn:
                    cmdCommand = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\ToastBtn\\ToastBtn1.exe");
                    //VantageCommonHelper.RunCmd(cmdCommand);
                    Process.Start(cmdCommand);
                    break;
                case ClickButton.Lws_Content:
                    //toastbutton4无法在center里点击，因此改为位置点击
                    int x1 = 1702;
                    string contentx = x1.ToString();
                    int y1 = 91;
                    string contenty = y1.ToString();
                    VantageCommonHelper.SetMouseClick(contentx, contenty);
                    //cmdCommand = Path.Combine(Application.StartupPath, "ToastBtn4.exe");
                    //RunCmd(cmdCommand, true);
                    break;
            }
        }

        public ToggleState GetCheckBoxStatus(WindowsElement windowsElement)
        {
            if (windowsElement != null)
            {
                string initToggleState = windowsElement.GetAttribute("Toggle.ToggleState");
                if (initToggleState != Convert.ToInt32(ToggleState.On).ToString())
                {
                    return ToggleState.Off;
                }
                else
                {
                    return ToggleState.On;
                }
            }

            return ToggleState.Indeterminate;
        }

        public ToggleState GetGamingToggleStatusByName(WindowsElement windowsElement)
        {
            if (windowsElement != null)
            {
                string initToggleState = windowsElement.GetAttribute("Name");
                if (initToggleState.Contains("off"))
                {
                    return ToggleState.Off;
                }
                else
                {
                    return ToggleState.On;
                }
            }
            return ToggleState.Indeterminate;
        }

        public string GetElementTextName(WindowsElement windowsElement)
        {
            if (windowsElement != null)
            {
                return windowsElement.GetAttribute("Name");
            }
            return string.Empty;
        }

        public bool SetCheckBoxStatus(WindowsElement element, ToggleState state, WindowsDriver<WindowsElement> sessionid = null, int waitMilliSec = 500)
        {
            if (element != null)
            {
                if (GetCheckBoxStatus(element) != state)
                {
                    element.Click();
                }
                Thread.Sleep(waitMilliSec);
                if (GetCheckBoxStatus(element) != state && sessionid != null)
                {
                    sessionid.Mouse.Click(element.Coordinates);
                }
                else if (GetCheckBoxStatus(element) != state && sessionid == null)
                {
                    element.Click();
                }
                Thread.Sleep(waitMilliSec);
                if (GetCheckBoxStatus(element) == state)
                {
                    return true;
                }
            }
            return false;
        }

        public bool SetButtonBoxStatus(String Setstatus, String automationId, WindowsDriver<WindowsElement> session, int waitMilliSec = 500)
        {
            WindowsElement button = FindElementByTimes(session, "AutomationId", automationId.Substring(0, automationId.LastIndexOf("_") + 1) + Setstatus.ToLower(), 10, 5);
            if (button == null)
            {
                if (Setstatus.ToLower().Equals("off"))
                {
                    FindElementByTimes(session, "AutomationId", automationId.Substring(0, automationId.LastIndexOf("_") + 1) + "on", 10, 5).Click();
                    Thread.Sleep(waitMilliSec);
                    button = FindElementByTimes(session, "AutomationId", automationId.Substring(0, automationId.LastIndexOf("_") + 1) + Setstatus.ToLower(), 10, 5);
                }
                else if (Setstatus.ToLower().Equals("on"))
                {
                    FindElementByTimes(session, "AutomationId", automationId.Substring(0, automationId.LastIndexOf("_") + 1) + "off", 10, 5).Click();
                    Thread.Sleep(waitMilliSec);
                    button = FindElementByTimes(session, "AutomationId", automationId.Substring(0, automationId.LastIndexOf("_") + 1) + Setstatus.ToLower(), 10, 5);
                }
                if (button != null)
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

        public static bool WindowsParentContainString(WindowsDriver<WindowsElement> session, string xpath, string containName)
        {
            ReadOnlyCollection<WindowsElement> elements = session.FindElementsByXPath(xpath);
            foreach (WindowsElement element in elements)
            {
                string text = VantageCommonHelper.GetAttributeValue(element, "Name");
                if (text != null && text.ToLower().Contains(containName.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool UninstallApps(int timeout = 60, string softwareUninstallPath = "")
        {
            int index = 0;
            NerveCenterHelper.CommonAppInfo appInfo = GetDependAppInfo();
            KillProcess(appInfo.ProcessName);
            if (string.IsNullOrEmpty(softwareUninstallPath))
            {
                softwareUninstallPath = appInfo.UninstallExe;
            }
            if (!File.Exists(softwareUninstallPath))
            {
                return true;
            }
            string cmd = string.Format("\"{0}\" /S", softwareUninstallPath);
            RunCmd(cmd, true);
            Thread.Sleep(TimeSpan.FromSeconds(10));
            while (index < timeout)
            {
                if (!File.Exists(softwareUninstallPath))
                {
                    return true;
                }
                index++;
            }
            return false;
        }

        public static bool InstallApps(int timeout = 60)
        {
            int index = 0;
            NerveCenterHelper.CommonAppInfo appInfo = GetDependAppInfo();
            if (File.Exists(appInfo.UninstallExe))
            {
                if (!UninstallApps())
                {
                    return false;
                }
            }
            RunCmd(appInfo.Package + " /S");
            while (index < timeout)
            {
                if (File.Exists(appInfo.UninstallExe))
                {
                    return true;
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));
                index++;
            }
            return false;
        }

        public static bool StartApp()
        {
            NerveCenterHelper.CommonAppInfo appInfo = GetDependAppInfo();
            Process[] process = Process.GetProcessesByName(appInfo.ProcessName);
            if (process.Length > 0)
            {
                KillProcess(appInfo.ProcessName);
                Thread.Sleep(TimeSpan.FromSeconds(3));
            }
            if (!File.Exists(appInfo.File))
            {
                InstallApps();
            }
            Process.Start(appInfo.File);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            process = Process.GetProcessesByName(appInfo.ProcessName);
            if (process.Length > 0)
            {
                return true;
            }
            return false;
        }

        ///Path.Combine(VantageConstContent.DataPath, @"Data\apps\cloudmusicsetup2.7.1.198242.exe"); @"C:\apps\cloudmusicsetup2.7.1.198242.exe";
        public static NerveCenterHelper.CommonAppInfo GetDependAppInfo(string app = "NetWorkBoostCloudMusicApp")
        {
            NerveCenterHelper.CommonAppInfo appInfo = NerveCenterHelper.GetCommonAppInformation(app, NerveCenterHelper.NerveCenterGamingAppIniFileCopy);
            return appInfo;
        }

        public enum ErrorMessage
        {
            /**
             * The scripts cannot find the element according to the ID we used
             */
            NotFind = 0,
            /**
             * The element cannot be clicked, maybe cause the element is in disabled state, or app crash
             */
            EnableFalse = 1,
            /**
             * Clcik successfully
             */
            ClickSuccessed = 2
        }

        public static ErrorMessage ClickVantageElements(WindowsElement windowsElement)
        {
            if (windowsElement != null)
            {
                try
                {
                    windowsElement.Click();
                    return ErrorMessage.ClickSuccessed;
                }
                catch
                {
                    return ErrorMessage.EnableFalse;
                }
            }
            else
            {
                return ErrorMessage.NotFind;
            }
        }

        public static void CheckUIWithSPEC(WindowsElement windowsElement, string UISPEC)
        {
            if (windowsElement != null)
            {
                string ElementText = VantageCommonHelper.GetAttributeValue(windowsElement, "Name");
                Assert.AreEqual(UISPEC, ElementText, UISPEC + "not found in UI");
            }
            else
            {
                Assert.Fail(UISPEC + " windowsElement is null");
            }
        }

        public static void SelectElement(WindowsElement windowsElement, ToggleState tarToggle)
        {
            if (tarToggle == ToggleState.Indeterminate)
            {
                Assert.Fail("Cannot find the Toggle");
            }
            else if (tarToggle == ToggleState.Off)
            {
                ErrorMessage _errorResult = SettingsBase.ClickVantageElements(windowsElement);
                Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
            }
            else
            {
                Assert.True(true);
            }
        }

        public static void UnSelectElement(WindowsElement windowsElement, ToggleState tarToggle)
        {
            if (tarToggle == ToggleState.Indeterminate)
            {
                Assert.Fail("Cannot find the Toggle");
            }
            else if (tarToggle == ToggleState.On)
            {
                ErrorMessage _errorResult = SettingsBase.ClickVantageElements(windowsElement);
                Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
            }
            else
            {
                Assert.True(true);
            }
        }

        public static string GetDriverVersion(string description)
        {
            string queryString = "SELECT Description, DriverVersion FROM Win32_PnPSignedDriver";
            SelectQuery selectQuery = new SelectQuery(queryString);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(selectQuery);

            foreach (ManagementObject mo in searcher.Get())
            {
                object tempID = mo["Description"];
                if (tempID != null && tempID.ToString().ToUpper().Contains(description.Trim().ToUpper()))
                {
                    return mo["DriverVersion"].ToString();
                }
            }
            return "UnknownVersion";
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool Wow64DisableWow64FsRedirection(ref IntPtr ptr);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool Wow64DisableWow64FsRedirection(IntPtr ptr);

        public static void DeleteDir(string file)
        {
            try
            {
                IntPtr Wow64value = IntPtr.Zero;
                Wow64DisableWow64FsRedirection(ref Wow64value);
                if (Directory.Exists(file))
                {
                    foreach (string dir in Directory.GetDirectories(file))
                    {
                        DeleteDir(dir);
                    }
                    foreach (string f in Directory.GetFiles(file))
                    {
                        FileInfo fi = new FileInfo(f);
                        if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                        {
                            fi.Attributes = FileAttributes.Normal;
                        }
                        File.Delete(f);
                    }
                }
                Wow64DisableWow64FsRedirection(Wow64value);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message.ToString());
            }
        }

        public static void RunCmd(string cmd, bool isEnterFlag = true)
        {
            Console.WriteLine(cmd);
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = "cmd.exe";
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.UseShellExecute = false;

            if (isEnterFlag)
            {//Run as administrator cbh
                processStartInfo.Verb = "Run as";
            }

            processStartInfo.CreateNoWindow = false;
            Process process = new Process
            {
                StartInfo = processStartInfo
            };
            process.Start();
            process.StandardInput.WriteLine(cmd);
            process.StandardInput.WriteLine("{enter}");
            Console.WriteLine("The Path is " + cmd);
            Thread.Sleep(TimeSpan.FromSeconds(5));
            process.Close();

        }

        public static string GetAutomationIdFromPredefinedJsonFile(string _jsonPath)
        {
            return VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPath).ToString();
        }

        public void SetVantageSize(int width, int height)
        {
            session.Manage().Window.Size = new System.Drawing.Size(width, height);
        }

        public string GetToolBarButtonName(string AutomationId)
        {
            WindowsDriver<WindowsElement> deskSession = GetControlPanelSession(true);
            WindowsElement toolBarElement = FindElementByTimes(deskSession, "AutomationId", AutomationId);
            string toolBarButtonName = toolBarElement.GetAttribute("Name");
            return toolBarButtonName;
        }

        #region Computer Screen If Locked

        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern uint WTSGetActiveConsoleSessionId();

        [DllImport("Wtsapi32.dll", CharSet = CharSet.Unicode)]
        public static extern bool WTSQuerySessionInformationW(IntPtr hServer, uint SessionId, WTS_INFO_CLASS WTSInfoClass, ref IntPtr ppBuffer, ref uint pBytesReturned);

        [DllImport("Wtsapi32.dll", CharSet = CharSet.Unicode)]
        public static extern void WTSFreeMemory(IntPtr pMemory);

        public enum WTS_INFO_CLASS
        {
            WTSInitialProgram,
            WTSApplicationName,
            WTSWorkingDirectory,
            WTSOEMId,
            WTSSessionId,
            WTSUserName,
            WTSWinStationName,
            WTSDomainName,
            WTSConnectState,
            WTSClientBuildNumber,
            WTSClientName,
            WTSClientDirectory,
            WTSClientProductId,
            WTSClientHardwareId,
            WTSClientAddress,
            WTSClientDisplay,
            WTSClientProtocolType,
            WTSIdleTime,
            WTSLogonTime,
            WTSIncomingBytes,
            WTSOutgoingBytes,
            WTSIncomingFrames,
            WTSOutgoingFrames,
            WTSClientInfo,
            WTSSessionInfo,
            WTSSessionInfoEx,
            WTSConfigInfo,
            WTSValidationInfo,   // Info Class value used to fetch Validation Information through the WTSQuerySessionInformation
            WTSSessionAddressV4,
            WTSIsRemoteSession
        }

        public enum WTS_CONNECTSTATE_CLASS
        {
            WTSActive,              // User logged on to WinStation
            WTSConnected,           // WinStation connected to client
            WTSConnectQuery,        // In the process of connecting to client
            WTSShadow,              // Shadowing another WinStation
            WTSDisconnected,        // WinStation logged on without client
            WTSIdle,                // Waiting for client to connect
            WTSListen,              // WinStation is listening for connection
            WTSReset,               // WinStation is being reset
            WTSDown,                // WinStation is down due to error
            WTSInit,                // WinStation in initialization
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WTSINFOEXW
        {
            public int Level;
            public WTSINFOEX_LEVEL_W Data;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WTSINFOEX_LEVEL_W
        {
            public WTSINFOEX_LEVEL1_W WTSInfoExLevel1;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct WTSINFOEX_LEVEL1_W
        {
            public int SessionId;
            public WTS_CONNECTSTATE_CLASS SessionState;
            public int SessionFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
            public string WinStationName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
            public string UserName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)]
            public string DomainName;
            public LARGE_INTEGER LogonTime;
            public LARGE_INTEGER ConnectTime;
            public LARGE_INTEGER DisconnectTime;
            public LARGE_INTEGER LastInputTime;
            public LARGE_INTEGER CurrentTime;
            public uint IncomingBytes;
            public uint OutgoingBytes;
            public uint IncomingFrames;
            public uint OutgoingFrames;
            public uint IncomingCompressedBytes;
            public uint OutgoingCompressedBytes;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct LARGE_INTEGER //此结构体在C++中使用的为union结构，在C#中需要使用FieldOffset设置相关的内存起始地址
        {
            [FieldOffset(0)]
            uint LowPart;
            [FieldOffset(4)]
            int HighPart;
            [FieldOffset(0)]
            long QuadPart;
        }

        public static bool ComputerScreenIsLocked()
        {
            uint dwSessionID = WTSGetActiveConsoleSessionId();
            uint dwBytesReturned = 0;
            int dwFlags = 0;
            IntPtr pInfo = IntPtr.Zero;
            WTSQuerySessionInformationW(IntPtr.Zero, dwSessionID, WTS_INFO_CLASS.WTSSessionInfoEx, ref pInfo, ref dwBytesReturned);
            var shit = Marshal.PtrToStructure<WTSINFOEXW>(pInfo);

            if (shit.Level == 1)
            {
                dwFlags = shit.Data.WTSInfoExLevel1.SessionFlags;
            }
            switch (dwFlags)
            {
                case 0:
                    Console.WriteLine("Locked");
                    return true;
                case 1:
                    Console.WriteLine("Not Locked");
                    return false;
                default:
                    Console.WriteLine("Unknowed");
                    return false;
            }
        }
        #endregion
    }
}
