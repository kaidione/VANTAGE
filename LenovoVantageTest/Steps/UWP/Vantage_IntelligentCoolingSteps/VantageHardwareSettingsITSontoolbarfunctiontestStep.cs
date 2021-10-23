using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Automation;
using TechTalk.SpecFlow;
using Windows.UI.Xaml.Data;
using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;
using static LenovoVantageTest.Steps.UWP.IntelligentCooling.IntelligentCoolingBaseHelper;

namespace LenovoVantageTest.Steps.UWP.Vantage_IntelligentCoolingSteps
{
    [Binding]
    public class VantageHardwareSettingsITSontoolbarfunctiontestStep
    {
        private InformationalWebDriver _webDriver;
        private IntelligentCoolingPages _intelligentcoolingPages;
        IntelligentCoolingBaseHelper _baseHelper = new IntelligentCoolingBaseHelper();
        private string _itsPluginPath = @"C:\ProgramData\Lenovo\ImController\Plugins\IdeaNotebookPlugin";
        private string _newitsPluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\ITS files\IdeaNotebookPlugin");
        private string _newupdateitsPluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\ITS files\IdeaNotebookPlugin_");
        private string _x86HeartBeatPath = @"C:\ProgramData\Lenovo\ImController\Plugins\LenovoBatteryGaugePackage\x86\HeartbeatMetrics";
        private string _x64HeartBeatPath = @"C:\ProgramData\Lenovo\ImController\Plugins\LenovoBatteryGaugePackage\x64\HeartbeatMetrics";
        static private string _itsMMCRegeditPathCN = "SYSTEM\\CurrentControlSet\\Services\\LITSSVC\\LNBITS\\IC\\MMC";
        private string _destPath = @"C:\IdeaNotebookPlugin";
        private bool _isSupport = false;
        private string _tips = string.Empty;
        public string _eventLogFile = @"C:\Windows\System32\winevt\Logs\Lenovo-Sif-Companion%4Operational.evtx";
        private List<string> _eventLogxml = new List<string>();   //Xml 全部信息
        private WindowsDriver<WindowsElement> _desktopSession = null;
        public VantageHardwareSettingsITSontoolbarfunctiontestStep(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [When(@"Current Machine OS is ""(.*)"" than ""(.*)""")]
        public void WhenCurrentMachineOSIsThan(string p0, int p1)
        {
            switch (p0.ToLower())
            {
                case "more":
                    Assert.IsTrue(VantageCommonHelper.CurrentMachineThanVersion(p1), "Current Machine is less than " + p1);
                    break;
                case "less":
                    Assert.IsTrue(VantageCommonHelper.CurrentMachineThanVersion(p1, true), "Current Machine is less than " + p1);
                    break;
            }
        }

        [Then(@"Toolbar will show ""(.*)"" Text")]
        public void ThenToolbarWillShowText(string p0)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            _desktopSession = _intelligentcoolingPages.GetControlPanelSession(true);
            WindowsElement toolbarElement = _intelligentcoolingPages.FindElementByTimes(_desktopSession, "Name", p0, 10);
            Assert.IsNotNull(toolbarElement, p0 + " Text not show");
        }
        private static int _initDpiWidth = 0;
        private static int _initDpiHeight = 0;

        [BeforeFeature("ITSToolbarCase")]
        public static void BeforeFeatureToolbarOnNewOS()
        {
            RegistryHelp.CreateRegistry(NarratorRegistry);
            using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
            {
                _initDpiWidth = Convert.ToInt32(graphics.DpiX);
                _initDpiHeight = Convert.ToInt32(graphics.DpiY);
            }
        }

        [AfterFeature("ITSToolbarCase")]
        public static void AfterFeatureToolbarOnNewOS()
        {
            string NarratorRegistry = "hkcu\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Accessibility\\ATConfig\\narrator";
            if (RegistryHelp.IsRegistrySubKeyExist(NarratorRegistry))
            {
                RegistryHelp.DeleteRegistrySubKey(NarratorRegistry);
            }
            string info = ChangeResolution(_initDpiWidth, _initDpiHeight);
        }

        [Given(@"Launch Winappdriver")]
        public void GivenLaunchWinappdriver()
        {
            BaseTestClass.StartWinAppDriver();
        }

        [Given(@"Launch Toolbar On NewOS")]
        public void GivenLaunchToolbarOnNewOS()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            _desktopSession = _intelligentcoolingPages.GetControlPanelSession(true);
            var closeToolbar = _intelligentcoolingPages.FindElementByTimes(_desktopSession, "AutomationId", Convert.ToInt32(ToolBarAutoEnum.ToolBarCloseBtn).ToString(), 1, 2);
            if (closeToolbar == null)
            {
                WindowsElement toolbarElement = _intelligentcoolingPages.FindElementByTimes(_desktopSession, "Name", "Lenovo Vantage Toolbar", 10);
                toolbarElement?.Click();
                Thread.Sleep(3000);
            }
        }

        [Then(@"Hover Toolbar on NewOS")]
        public void ThenHoverToolbaronNewOS()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            _desktopSession = _intelligentcoolingPages.GetControlPanelSession(true);
            WindowsElement toolbarElement = _intelligentcoolingPages.FindElementByTimes(_desktopSession, "Name", "Lenovo Vantage Toolbar", 10);
            if (toolbarElement != null)
            {
                var position = toolbarElement.Rect;
                string x = ((int)position.Left + (int)position.Width / 2).ToString();
                string y = ((int)position.Top + (int)position.Height / 2).ToString();
                VantageCommonHelper.SetMouseClick(x, y, true);
                Thread.Sleep(1000);
            }
        }

        [Then(@"It will not show DYTC features On NewOS")]
        public void ThenItWillNotShowDYTCFeaturesOnNewOS()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            _desktopSession = _intelligentcoolingPages.GetControlPanelSession(true);
            WindowsElement IntellingCollingLinkId = _intelligentcoolingPages.FindElementByTimes(_desktopSession, "AutomationId", "1087", 2, 2);
            Assert.IsNull(IntellingCollingLinkId, "IntellingCollingLinkId is null");
            WindowsElement QUiteModeLineId = _intelligentcoolingPages.FindElementByTimes(_desktopSession, "AutomationId", "1051", 2, 2);
            Assert.IsNull(QUiteModeLineId, "QUiteModeLineId is null");
        }


        [Given(@"Hover ITS icon in toolbar ON NewOS")]
        public void GivenHoverITSIconInToolbarONNewOS()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            _desktopSession = _intelligentcoolingPages.GetControlPanelSession(true);
            WindowsElement toolbarElement = _intelligentcoolingPages.FindElementByTimes(_desktopSession, "AutomationId", "1070", 10);
            var position = toolbarElement.Rect;
            string x = (position.Left + position.Width / 2).ToString();
            string y = (position.Top + position.Height / 2).ToString();
            VantageCommonHelper.SetMouseClick(x, y, true);
            Thread.Sleep(200);
        }

        [Given(@"jump to power smart settings section")]
        public void GivenJumpToPowerSmartSettingsSection()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            _intelligentcoolingPages.HSJumpToSmartSettings?.Click();
        }

        [Given(@"switch ITS Mode")]
        public void GivenSwitchITSMode()
        {
            VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(VantageConstContent.ToolBarAutoEnum.ITSMode).ToString());
        }

        [Then(@"Intelligent Cooling is on")]
        public void ThenIntelligentCoolingIsOn()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var togglestate = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingToggle);
            Assert.AreEqual(ToggleState.On, togglestate);
        }

        [Then(@"Vantage Intelligent Cooling Mode On")]
        public void ThenVantageIntelligentCoolingModeOn()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var togglestate = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingCoolQuietMode);
            Assert.AreEqual(ToggleState.On, togglestate);
        }

        [Then(@"Turn On Mode Elemenet Hide")]
        public void ThenTurnOnModeElemenetHide()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var performanceMode = _intelligentcoolingPages.IntelligentCoolingExtremePerformanceMode;
            var coolMode = _intelligentcoolingPages.IntelligentCoolingCoolQuietMode;
            var performanceTitle = VantageCommonHelper.FindElementByXPathAndEnabled(_webDriver.Session, IntelligentCoolingPages.IntelligentCoolingPerformanceTitle, 5);
            var coolTitle = VantageCommonHelper.FindElementByXPathAndEnabled(_webDriver.Session, IntelligentCoolingPages.IntelligentCoolingCoolQuietTitle, 5);
            Assert.IsTrue(performanceMode == null && coolMode == null && performanceTitle == null && coolTitle == null);
        }


        [Then(@"Intelligent Cooling is off")]
        public void ThenIntelligentCoolingIsOff()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var togglestate = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingToggle);
            Assert.AreEqual(ToggleState.Off, togglestate);
        }

        [Then(@"Extreme Performance is on")]
        public void ThenExtremePerformanceIsOn()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var intelligentcooling = _intelligentcoolingPages.IntelligentCoolingExtremePerformanceMode.GetAttribute("Toggle.ToggleState");
            Assert.AreEqual(intelligentcooling, "1");
        }

        [Then(@"Battery saving is on")]
        public void ThenBatterySavingIsOn()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var BatterySaving = _intelligentcoolingPages.IntelligentCoolingBatterySavingMode.GetAttribute("Toggle.ToggleState");
            Assert.AreEqual("1", BatterySaving);
        }

        [Then(@"Intelligent Cooling mode is on")]
        public void ThenIntelligentCoolingModeIsOn()
        {
            var ITSMode = _baseHelper.GetIntelligentCoolingMetricDataInfo().Split('-')[0];
            Assert.IsTrue(ITSMode != "BSM" && ITSMode != "EPM");
        }

        [Given(@"Stop ITS service")]
        public void GivenStopITSService()
        {
            _baseHelper.IntelligentCoolinggIMCServiceControl(1);
        }

        [Given(@"start ITSService")]
        public void GivenStartITSService()
        {
            _baseHelper.IntelligentCoolinggIMCServiceControl(0);
        }

        [When(@"Restart Explorer")]
        public void WhenRestartExplorer()
        {
            List<string> cmds = new List<string>
            {
                $"Stop-Process -ProcessName 'explorer'"
            };
            Commands.CmdCommands.RunPowershellCmdlet(cmds);
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        [Given(@"moveplugin")]
        public void GivenMoveplugin()
        {
            _baseHelper.IntelligentCoolinggIMCServiceControl(3);
            if (Directory.Exists(_destPath))
            {
                // PermissionManager.ModifyFileControll(_destPath);
                Directory.Delete(_destPath, true);
            }
            if (Directory.Exists(_itsPluginPath))
            {
                //PermissionManager.ModifyFileControll(_itsPluginPath);
                Directory.Move(_itsPluginPath, _destPath);
            }
            _baseHelper.IntelligentCoolinggIMCServiceControl(2);
        }

        [Then(@"vantage ITS mode hide")]
        public void ThenVantageITSModeHide()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            Assert.IsNull(_intelligentcoolingPages.HSJumpToSmartSettings);
        }

        [Then(@"Toolbar ITS mode (.*)")]
        public void ThenToolbarITSMode(string p0)
        {
            AutomationElement ITSModeElement = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(VantageConstContent.ToolBarAutoEnum.ITSMode).ToString(), 10);
            switch (p0.ToLower())
            {
                case "show":
                    Assert.IsNotNull(ITSModeElement);
                    break;
                case "hide":
                    Assert.IsNull(ITSModeElement);
                    break;
            }
        }

        [Given(@"recoverplugin")]
        public void GivenRecoverplugin()
        {
            _baseHelper.IntelligentCoolinggIMCServiceControl(3);
            if (!Directory.Exists(_itsPluginPath))
            {
                if (Directory.Exists(@"C:\IdeaNotebookPlugin"))
                {
                    Directory.Move(@"C:\IdeaNotebookPlugin", _itsPluginPath);
                }
                else
                {
                    Directory.CreateDirectory(_itsPluginPath);
                    SmartStandbyTestSteps sst = new SmartStandbyTestSteps(_webDriver);
                    sst.CopyFolder(_newitsPluginPath, _itsPluginPath);
                }
            }
            _baseHelper.IntelligentCoolinggIMCServiceControl(2);
        }

        [Given(@"updateplugin")]
        public void GivenUpdateplugin()
        {
            _baseHelper.IntelligentCoolinggIMCServiceControl(3);
            Directory.CreateDirectory(_newupdateitsPluginPath);
            SmartStandbyTestSteps sst = new SmartStandbyTestSteps(_webDriver);
            sst.CopyFolder(_newitsPluginPath, _newupdateitsPluginPath);
            _baseHelper.IntelligentCoolinggIMCServiceControl(2);
        }

        [Given(@"moveplugintoData")]
        public void GivenMoveplugintoData()
        {
            _baseHelper.IntelligentCoolinggIMCServiceControl(3);
            //string pluginpath = @"C:\ProgramData\Lenovo\ImController\Plugins";
            if (Directory.Exists(_newitsPluginPath))
            {
                Directory.Move(_itsPluginPath, _newitsPluginPath);
            }
            _baseHelper.IntelligentCoolinggIMCServiceControl(2);
        }

        [Then(@"ITS (.*) is selected in Toolbar")]
        public void ThenITSIsSelectedInToolbar(string ITSmode)
        {
            var ITSstatus = SettingsBase.GetITSStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.ITSMode).ToString());
            Assert.AreEqual(ITSstatus, ITSmode, "ITS mode is wrong!");
        }

        public string GetAMSValue()
        {
            string toggleValue = RegistryHelp.GetValueFromRegedit("AutomaticModeSetting", _itsMMCRegeditPathCN);
            return toggleValue;
        }
        public string GetCSValue()
        {
            string toggleValue = RegistryHelp.GetValueFromRegedit("CurrentSetting", _itsMMCRegeditPathCN);
            return toggleValue;
        }

        [Then(@"vantage ITS mode is on")]
        public void ThenVantageITSModeIsOn()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var togglestate = _intelligentcoolingPages.IntelligentCoolingToggle.GetAttribute("Toggle.ToggleState");
            Assert.AreEqual(togglestate, "1");
        }

        [Given(@"turn off Intelligent Cooling")]
        public void GivenTurnOffIntelligentCooling()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var togglestate = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingToggle);
            if (togglestate == ToggleState.On)
            {
                _intelligentcoolingPages.IntelligentCoolingToggle?.Click();
            }
        }

        [Given(@"turn on Intelligent Cooling")]
        public void GivenTurnOnIntelligentCooling()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var togglestate = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingToggle);
            if (togglestate == ToggleState.Off)
            {
                _intelligentcoolingPages.IntelligentCoolingToggle?.Click();
            }
        }

        [Then(@"Performance is on in vantage")]
        public void ThenPerformanceIsOnInVantage()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var togglestate = _intelligentcoolingPages.IntelligentCoolingExtremePerformanceMode.GetAttribute("Toggle.ToggleState");
            Assert.AreEqual(togglestate, "1");
        }

        [Given(@"click Cool & quiet")]
        public void GivenClickCoolQuiet()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            _intelligentcoolingPages.IntelligentCoolingIntelligentCoolingMode?.Click();
        }

        [Then(@"Cool & quiet is on in vantage")]
        public void ThenCoolQuietIsOnInVantage()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var togglestate = _intelligentcoolingPages.IntelligentCoolingIntelligentCoolingMode.GetAttribute("Toggle.ToggleState");
            Assert.AreEqual(togglestate, "1");
        }

        [Then(@"ITS on toolbar hide")]
        [Given(@"ITS on toolbar hide")]
        public void GivenITSOnToolbarHide()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            Assert.IsNull(_intelligentcoolingPages.ToolBarITSMode);
        }

        [Given(@"ITS on toolbar display normal")]
        public void GivenITSOnToolbarDisplayNormal()
        {
            Thread.Sleep(3000);
            var ITSMode = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(VantageConstContent.ToolBarAutoEnum.ITSMode).ToString());
            Assert.IsNotNull(ITSMode);
        }

        [Then(@"Check ""(.*)"" Eventlog for ""(.*)""")]
        public void ThenCheckEventlogFor(string p0, string p1)
        {
            string ITSVersion = p1.Substring(p1.Length - 1, 1);
            string checkStr = string.Format("Features.Toolbar.QuickSettings.IntelligentCooling{0}0ForIdeapad", ITSVersion);
            bool result = false;

            List<string> eventRecordContext = new List<string>();
            using (var reader = new EventLogReader(_eventLogFile, PathType.FilePath))
            {
                EventRecord record;
                while ((record = reader.ReadEvent()) != null)
                {
                    using (record)
                    {
                        if (record.FormatDescription().Contains("LenovoBatteryGaugePackage"))
                        {
                            eventRecordContext.Add(record.FormatDescription());
                        }
                    }
                }
                int index = 0;

                foreach (string eventLog in eventRecordContext)
                {
                    if (index == eventRecordContext.Count - 1)
                    {
                        string str = eventLog;
                        string ItemName = GetXMLValue(str, "/event/variables/var/value", "", 0);
                        string ItemParent = GetXMLValue(str, "/event/variables/var/value", "", 1);
                        string ItemValue = GetXMLValue(str, "/event/variables/var/value", "", 2);
                        if (ItemName.Contains(checkStr))
                        {
                            Assert.IsTrue(ItemParent.Contains("Features.Toolbar.QuickSettings"));
                            Assert.IsTrue(ItemValue.ToLower().Contains(p0.ToLower()));
                            result = true;
                            break;
                        }
                    }

                    index++;
                }
                if (!result)
                {
                    Assert.Fail(string.Format("Check Eventlog Failed, the {0} is not record", p0));

                }
            }
        }

        [Then(@"Read ""(.*)"" Heartbeat ""(.*)"" Eventlog")]
        public void ThenReadHeartbeatEventlog(string p0, string p1)
        {
            bool checkNotFlag = false;
            if (p1.ToLower().Contains("not"))
            {
                checkNotFlag = true;
            }

            bool result = false;
            List<string> eventRecordContext = new List<string>();
            using (var reader = new EventLogReader(_eventLogFile, PathType.FilePath))
            {
                EventRecord record;
                while ((record = reader.ReadEvent()) != null)
                {
                    using (record)
                    {
                        if (record.FormatDescription().Contains("LenovoBatteryGaugePackage"))
                        {
                            eventRecordContext.Add(record.FormatDescription());
                        }
                    }
                }
                int index = 0;
                foreach (string eventLog in eventRecordContext)
                {
                    if (index == eventRecordContext.Count - 1)
                    {
                        string str = eventLog;
                        var ItemName = GetXMLValue(str, "/event/variables/var/value", "", 0);
                        string checkStr = string.Format("\"name\":\"Features.HardwareSettings.Power.ITS.Version\",\"value\":\"{0}\"", p0);
                        string currentModeValue = GetCSValue();
                        string currentMode = string.Empty;
                        if (currentModeValue == "0")
                        {
                            currentMode = "ITS_Auto";
                        }
                        else if (currentModeValue == "1")
                        {
                            currentMode = "MMC_Cool";
                        }
                        else if (currentModeValue == "3")
                        {
                            currentMode = "MMC_Performance";
                        }
                        string modeStr = string.Format("\"name\":\"Features.HardwareSettings.Power.ITS.CurrentMode\",\"value\":\"{0}\"", currentMode);
                        if (checkNotFlag)
                        {
                            Assert.IsTrue(!str.Contains("IntelligentCooling.DYTC"));
                            return;
                        }
                        else
                        {
                            Assert.IsTrue(str.Contains(checkStr));
                            Assert.IsTrue(str.Contains(modeStr));
                        }
                        if (p0 == "ITS5")
                        {
                            string autoStr_on = string.Format("'name':'Features.HardwareSettings.Power.ITS.ITSAutoTransition','value':'On'");
                            string autoStr_off = string.Format("'name':'Features.HardwareSettings.Power.ITS.ITSAutoTransition','value':'Off'");
                            Assert.IsTrue(str.Contains(autoStr_on) || str.Contains(autoStr_off));
                        }
                        result = true;
                    }
                    index++;
                }
                if (!result)
                {
                    Assert.Warn(string.Format("Check Eventlog Failed, the {0} is not record", p0));
                }

            }
        }


        [Then(@"Read ""(.*)"" Heartbeat Eventlog")]
        public void ThenReadHeartbeatEventlog(string p0)
        {
            bool result = false;
            List<string> eventRecordContext = new List<string>();
            using (var reader = new EventLogReader(_eventLogFile, PathType.FilePath))
            {
                EventRecord record;
                while ((record = reader.ReadEvent()) != null)
                {
                    using (record)
                    {
                        if (record.FormatDescription().Contains("LenovoBatteryGaugePackage"))
                        {
                            eventRecordContext.Add(record.FormatDescription());
                        }
                    }
                }
                int index = 0;
                foreach (string eventLog in eventRecordContext)
                {
                    if (index == eventRecordContext.Count - 1)
                    {
                        string str = eventLog;
                        var ItemName = GetXMLValue(str, "/event/variables/var/value", "", 0);
                        string checkStr = string.Format("\"name\":\"Features.HardwareSettings.Power.ITS.Version\",\"value\":\"{0}\"", p0);
                        string currentModeValue = GetCSValue();
                        string currentMode = string.Empty;
                        if (currentModeValue == "0")
                        {
                            currentMode = "ITS_Auto";
                        }
                        else if (currentModeValue == "1")
                        {
                            currentMode = "MMC_Cool";
                        }
                        else if (currentModeValue == "3")
                        {
                            currentMode = "MMC_Performance";
                        }
                        //"name":"Features.HardwareSettings.Power.ITS.Version","value":"ITS3";
                        //{ "name":"Features.HardwareSettings.Power.ITS.CurrentMode","value":"ITS_Auto"}]};

                        string modeStr = string.Format("\"name\":\"Features.HardwareSettings.Power.ITS.CurrentMode\",\"value\":\"{0}\"", currentMode);
                        Assert.IsTrue(str.Contains(checkStr));
                        Assert.IsTrue(str.Contains(modeStr));
                        if (p0 == "ITS5")
                        {
                            string autoStr_on = string.Format("\"name\":\"Features.HardwareSettings.Power.ITS.ITSAutoTransition\",\"value\":\"On\"");
                            string autoStr_off = string.Format("\"name\":\"Features.HardwareSettings.Power.ITS.ITSAutoTransition\",\"value\":\"Off\"");
                            Assert.IsTrue(str.Contains(autoStr_on) || str.Contains(autoStr_off));
                        }
                        result = true;
                    }
                    index++;
                }
                if (!result)
                {
                    Assert.Fail(string.Format("Check Eventlog Failed, the {0} is not record", p0));

                }
            }
        }

        [Given(@"Modify Date ""(.*)"" ""(.*)"" Days")]
        public void GivenModifyDateDays(string p0, int p1)
        {
            Console.WriteLine(DateTime.Now.ToString());
            VantageCommonHelper.SYSTEMTIME st = new VantageCommonHelper.SYSTEMTIME();
            VantageCommonHelper.GetSystemTime(ref st);
            switch (p0.ToLower())
            {
                case "add":
                    st.wHour = (ushort)(st.wHour + 1 % 24);
                    st.wDay = (ushort)(st.wDay + 1);
                    if (VantageCommonHelper.SetSystemTime(ref st) == 0)
                    {
                        Console.WriteLine(DateTime.Now.ToString());
                    }
                    break;
                case "minus":
                    st.wHour = (ushort)(st.wHour - 1 % 24);
                    st.wDay = (ushort)(st.wDay - 1);
                    if (VantageCommonHelper.SetSystemTime(ref st) == 0)
                    {
                        Console.WriteLine(DateTime.Now.ToString());
                    }
                    break;
            }
        }

        [Given(@"start heartbeat")]
        public void GivenStartHeartbeat()
        {
            Process.Start(@"C:\ProgramData\Lenovo\ImController\Plugins\LenovoBatteryGaugePackage\x86\HeartbeatMetrics.exe");
            Process[] app = Process.GetProcessesByName("HeartbeatMetrics");
            while (app.Length > 0)
            {
                app = Process.GetProcessesByName("HeartbeatMetrics");
                if (app.Length == 0) { break; }
                else { Thread.Sleep(5000); }

            }
        }


    }
}
