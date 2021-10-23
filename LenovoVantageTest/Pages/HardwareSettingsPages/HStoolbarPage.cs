namespace LenovoVantageTest.Pages
{
    using LenovoVantageTest.Utility;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Automation;
    using System.Xml;

    public class HSToolbarPage : SettingsBase
    {
        private WebDriverWait wait;
        private Actions action;
        private static string addinLevelPath = @"C:\ProgramData\Lenovo\Vantage\Addins\DeviceSettingsHeartbeatAddin\AddinManifest.xml";
        private const int GEO_FRIENDLYNAME = 8;
        private enum GeoClass : int
        {
            Nation = 16,
            Region = 14,
        };

        /// <summary>
        /// Done Button
        /// </summary>
        public WindowsElement doneButton => base.GetElement(session, "AutomationId", "tutorial_done_btn");
        /// <summary>
        /// Vantage Toolbar Checkbox
        /// </summary>
        public WindowsElement vantageToolbarCheckBox => base.GetElement(session, "AutomationId", "welcome-toolbar-input");//welcome-toolbar-label  chkbox-vantage-toolbar
        public WindowsElement vantageToolbarCheckBoxGaming => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.vantageToolbarCheckBoxGaming"));//welcome-toolbar-label  chkbox-vantage-toolbar gaming
        /// <summary>
        /// Next Button
        /// </summary>
        public WindowsElement nextButton => base.GetElement(session, "AutomationId", "tutorial_next_btn");
        public WindowsElement JumpToToolbar => base.GetElement(session, "AutomationId", "jumptoSetting-other");
        public WindowsElement ToolbardescriptionContext => base.GetElement(session, "AutomationId", "ds-power-otherSettings-toolBar-caption");
        public WindowsElement ToolbardescriptionContexts => base.GetElement(session, "Name", "Pin Lenovo Vantage Toolbar to Windows taskbar to easily access the most popular settings, view warranty options, submit feedback, and launch Lenovo Vantage to get customized offerings and updates.");
        public WindowsElement NOSToolbardescriptionTips => base.GetElement(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.NOSToolbardescriptionContexts"));
        public WindowsElement NOSToolbardescriptionContexts => base.GetElement(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.NOSToolbardescriptionTips"));
        public WindowsElement ToolbarWindowsNextIcon => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.ToolbarWindowsNextIcon"));
        public WindowsElement ToolbardescriptionTips => base.GetElement(session, "AutomationId", "device.deviceSettings.power.otherSettings.vantageToolbar.hint");
        public WindowsElement ToolbardescriptionTipss => base.GetElement(session, "Name", "The options on your Vantage Toolbar might vary depending on the computer model. To unpin Vantage Toolbar, right-click the Vantage Toolbar icon and select Unpin from taskbar .");
        public WindowsElement ToolbarAreaImage => base.GetElement(session, "Name", "Pin Lenovo Vantage toolbar to Windows taskbar");
        public WindowsElement ToolbarToggle => base.GetElement(session, "AutomationId", "ds-power-otherSettings-toolBar_checkbox");
        public WindowsElement BacklightSwich => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Toolbar.Backlight"));
        public WindowsElement ToolbarDevicesBtn => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.ToolbarDevicesBtn"));
        public WindowsElement BatteryTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.BatteryPage.BatteryTitle"));
        public WindowsElement BatteryIcon => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.BatteryPage.BatteryIcon"));
        public WindowsElement Percentage => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.BatteryPage.Percentage"));
        public WindowsElement BatteryDetailsBtn => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.BatteryPage.BatteryDetailsBtn"));
        public WindowsElement BatteryDetailsCloseBtn => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.BatteryPage.BatteryDetailsCloseBtn"));
        public WindowsElement BatteryRemainingTime => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.BatteryPage.BatteryRemainingTime"));
        public WindowsElement BatteryRemainingTimeValue => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.BatteryPage.BatteryRemainingTimeValue"));
        public WindowsElement BatteryTimeToFullChargeText => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.BatteryPage.BatteryTimeToFullChargeText"));
        public WindowsElement LenovoVantageToobartitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.BatteryPage.LenovoVantageToobartitle"));
        public string LenovoVantageToobartitletext => GetAutomationIdFromPredefinedJsonFile("$.BatteryPage.LenovoVantageToobartitletext");
        public WindowsElement NewOSToolbar => base.FindElementByTimes(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.NEWOSToolbar"));
        public string Unpinfromtaskbar => GetAutomationIdFromPredefinedJsonFile("$.PowerPage.Unpinfromtaskbar");
        //PinToolbarToastPopUpWindowElements
        public WindowsElement PopWindowPintoTaskbarTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Toolbar.PopWindowPintoTaskbarTitle").ToString(), 1, 1);
        public WindowsElement PopWindowPintoTaskbarDescription => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Toolbar.PopWindowPintoTaskbarDescription").ToString());
        public WindowsElement PopWindowPintoTaskbarImage => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Toolbar.PopWindowPintoTaskbarImage").ToString());
        public WindowsElement PopWindowPintoTaskbarNote => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Toolbar.PopWindowPintoTaskbarNote").ToString());
        public WindowsElement PopWindowPintoTaskBarButton => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Toolbar.PopWindowPintoTaskBarButton").ToString());
        public WindowsElement PopWindowPintoTaskbarNotNow => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Toolbar.PopWindowPintoTaskbarNotNow").ToString());
        public WindowsElement PopWindowPintoTaskbarClose => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Toolbar.PopWindowPintoTaskbarClose").ToString());

        public HSToolbarPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
        }

        [DllImport("kernel32.dll", ExactSpelling = true, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern int GetUserGeoID(GeoClass geoClass);

        [DllImport("kernel32.dll")]
        private static extern int GetUserDefaultLCID();

        [DllImport("kernel32.dll")]
        private static extern int GetGeoInfo(int geoid, int geoType, StringBuilder lpGeoData, int cchData, int langid);

        public override void ScrollScreen()
        {
            touchScreen = new RemoteTouchScreen(session);
            touchScreen.Scroll(0, -100);
        }

        private bool IsPresent(string locator)
        {
            try
            {
                session.FindElementByName(locator);
                return true;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }
        public bool TurnElementState(WindowsElement element, ToggleState toggleState)
        {
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(3));
                if (GetCheckBoxStatus(element) != toggleState)
                {
                    element.Click();
                }
                if (GetCheckBoxStatus(element) == toggleState)
                {
                    element.Click();
                    Thread.Sleep(3000);
                    element.Click();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return false;
        }

        public static string GetPluginLevel(string pluginName, string cmpType)
        {
            string pluginPath = null;
            if (cmpType == "x64")
            {
                pluginPath = @"C:\ProgramData\Lenovo\ImController\Plugins\" + pluginName + "\\x64\\" + pluginName + ".dll";
            }
            else if (cmpType == "x32")
            {
                pluginPath = @"C:\ProgramData\Lenovo\ImController\Plugins\" + pluginName + "\\x32\\" + pluginName + ".dll";
            }
            if (File.Exists(pluginPath))
            {
                return FileVersionInfo.GetVersionInfo(pluginPath).FileVersion;
            }
            else
            {
                return null;
            }
        }

        public static string GetAddinLevel()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(addinLevelPath);
            return xmlDoc.GetElementsByTagName("Addin")[0].Attributes["version"].Value;
        }

        public static string GetMachineCurrentLocation()
        {
            int geoId = GetUserGeoID(GeoClass.Nation); ;
            int lcid = GetUserDefaultLCID();
            StringBuilder locationBuffer = new StringBuilder(100);
            GetGeoInfo(geoId, GEO_FRIENDLYNAME, locationBuffer, locationBuffer.Capacity, lcid);

            return locationBuffer.ToString().Trim();
        }

        public static Tuple<float, float> GetHeartBeatCpuAndMemory()
        {
            string proccname = "Lenovo.Vantage.AddinHost.x86";
            string heartbeatcommandlines = "DeviceSettingsHeartbeatAddin";
            IEnumerable<string> commandLines = null;
            bool isRunning = false;
            try
            {
                Process[] allProcesses = Process.GetProcesses();
                foreach (Process procs in allProcesses)
                {
                    if (procs.ProcessName.Contains(proccname))
                    {
                        commandLines = Common.GetCommandLines(procs.ProcessName + ".exe");

                        foreach (string cmdLine in commandLines)
                        {
                            if (cmdLine.Contains(heartbeatcommandlines))
                            {
                                PerformanceCounter pf1 = new PerformanceCounter("Process", "Working Set - Private", procs.ProcessName);
                                float memory = pf1.NextValue() / 1024 / 1024;
                                PerformanceCounter curtime = new PerformanceCounter("Process", "% Processor Time", procs.ProcessName);
                                float cpu = curtime.NextValue() / Environment.ProcessorCount;
                                Tuple<float, float> tup = new Tuple<float, float>(memory, cpu);
                                return tup;
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Get heartbeatcommandlines faile");
                return null;
            }
        }
    }
}