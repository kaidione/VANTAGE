using LenovoVantageTest.Commands;
using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using Microsoft.Win32;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.ServiceModel.Channels;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Helper.VantageCommonHelper;
using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;

namespace LenovoVantageTest.Steps.UWP.Vantage_IntelligentCoolingSteps
{
    [Binding]
    public class VAN19138DYTC6TestStepDefinition
    {
        private WindowsDriver<WindowsElement> _session;
        private InformationalWebDriver _webDriver;
        private IntelligentCoolingPages _intelligentcoolingPages;
        private bool needClick;
        public CmdCommands cmdCommands;
        private WindowsDriver<WindowsElement> _desktopSession = null;
        IntelligentCoolingBaseHelper _baseHelper = new IntelligentCoolingBaseHelper();
        private string dytc6heartbeat = "{\"name\":\"Features.HardwareSettings.SmartSettings.IntelligentCooling.DYTC.Version\",\"value\":\"DYTC60\"},{\"name\":\"Features.HardwareSettings.SmartSettings.IntelligentCooling.DYTC.EnableAutoMode\",\"value\":\"NotSupport\"},{\"name\":\"Features.HardwareSettings.SmartSettings.IntelligentCooling.DYTC.IsMobileWorkStation\",\"value\":\"Yes\"},{\"name\":\"Features.HardwareSettings.SmartSettings.IntelligentCooling.DYTC.CurrentSetting\",\"value\":\"Ultra_performance_mode\"}";
        private string dytc5heartbeat = "{\"name\":\"Features.HardwareSettings.SmartSettings.IntelligentCooling.DYTC.Version\",\"value\":\"DYTC50\"},{\"name\":\"Features.HardwareSettings.SmartSettings.IntelligentCooling.DYTC.EnableAutoMode\",\"value\":\"NotSupport\"},{\"name\":\"Features.HardwareSettings.SmartSettings.IntelligentCooling.DYTC.IsMobileWorkStation\",\"value\":\"No\"},{\"name\":\"Features.HardwareSettings.SmartSettings.IntelligentCooling.DYTC.CurrentSetting\",\"value\":\"Quiet_mode\"}";
        private string dytc6mcheartbeat = "{\"name\":\"Features.HardwareSettings.SmartSettings.IntelligentCooling.DYTC.Version\",\"value\":\"DYTC60\"},{\"name\":\"Features.HardwareSettings.SmartSettings.IntelligentCooling.DYTC.EnableAutoMode\",\"value\":\"NotSupport\"},{\"name\":\"Features.HardwareSettings.SmartSettings.IntelligentCooling.DYTC.IsMobileWorkStation\",\"value\":\"No\"},{\"name\":\"Features.HardwareSettings.SmartSettings.IntelligentCooling.DYTC.CurrentSetting\",\"value\":\"Balanced_mode\"}";
        public string _eventLogFile = @"C:\Windows\System32\winevt\Logs\Lenovo-Sif-Companion%4Operational.evtx";
        static private string _itsRegeditPath = "SYSTEM\\CurrentControlSet\\Services\\LITSSVC\\IC\\AMT";
        private bool _amt = true;
        public VAN19138DYTC6TestStepDefinition(InformationalWebDriver appDriver)
        {
            this._session = appDriver.Session;
        }

        [Given(@"Click System Battery")]
        public void GivenClickSystemBattery()
        {
            var userPromotedNotificationArea = FindElementByIdIsEnabled("1504");
            if (userPromotedNotificationArea != null)
            {
                var position = userPromotedNotificationArea.Current.BoundingRectangle;
                string x = ((int)position.Left + (int)position.Width / 6).ToString();
                string y = ((int)position.Top + (int)position.Height / 2).ToString();
                SetMouseClick(x, y);
                Thread.Sleep(2000);
            }
        }

        [Given(@"Set AC Mode Power Slider is (.*) mode for Thinkpad DYTC Six")]
        public void GivenSetACModePowerSlidermodeforThinkpadDYTCSix(string PowerMode)
        {
            switch (PowerMode.ToLower())
            {
                case "best performance":
                    SendKeys.SendWait("{DOWN}");
                    SendKeys.SendWait("{DOWN}");
                    SendKeys.SendWait("{UP}");
                    SendKeys.SendWait("{UP}");
                    break;

                case "better performance":
                    SendKeys.SendWait("{DOWN}");
                    SendKeys.SendWait("{DOWN}");
                    SendKeys.SendWait("{UP}");
                    break;

                case "better battery":
                    SendKeys.SendWait("{UP}");
                    SendKeys.SendWait("{DOWN}");
                    SendKeys.SendWait("{DOWN}");
                    break;

                default:
                    throw new ValidationException("Please input name besides power mode(plugged in).");
            }
        }

        [Given(@"fast switch (.*) times windows power slider on AC mode")]
        public void GivenFastSwitchTimesWindowsPowerSlider(int times)
        {
            for (int i = 0; i < times; i++)
            {
                GivenSetACModePowerSlidermodeforThinkpadDYTCSix("best performance");
                GivenSetACModePowerSlidermodeforThinkpadDYTCSix("better performance");
                GivenSetACModePowerSlidermodeforThinkpadDYTCSix("better battery");
            }
        }

        [Given(@"Set DC Mode Power Slider is (.*) mode for Thinkpad DYTC Six")]
        public void GivenSetDCModePowerSlider(string PowerMode)
        {
            switch (PowerMode.ToLower())
            {
                case "best performance":
                    SendKeys.SendWait("{DOWN}");
                    SendKeys.SendWait("{DOWN}");
                    SendKeys.SendWait("{DOWN}");
                    SendKeys.SendWait("{UP}");
                    SendKeys.SendWait("{UP}");
                    SendKeys.SendWait("{UP}");
                    break;

                case "better performance":
                    SendKeys.SendWait("{DOWN}");
                    SendKeys.SendWait("{DOWN}");
                    SendKeys.SendWait("{DOWN}");
                    SendKeys.SendWait("{UP}");
                    SendKeys.SendWait("{UP}");
                    break;

                case "better battery":
                    SendKeys.SendWait("{DOWN}");
                    SendKeys.SendWait("{DOWN}");
                    SendKeys.SendWait("{DOWN}");
                    SendKeys.SendWait("{UP}");
                    break;

                case "battery saver":
                    SendKeys.SendWait("{DOWN}");
                    SendKeys.SendWait("{DOWN}");
                    SendKeys.SendWait("{DOWN}");
                    break;

                default:
                    throw new ValidationException("Please input name besides power mode(plugged in).");
            }
        }

        [When(@"click IntelligentCooling link in tool bar")]
        public void WhenClickIntellCoolingLinkInToolBar()
        {
            Thread.Sleep(1000);
            VantageCommonHelper.FindElementByIdAndMouseClick("1087");
            Thread.Sleep(1000);
        }

        [Given(@"Uninstall the lenovo vatage")]
        [Scope(Tag = "DYTC6MWS")]
        public void GivenUninstallTheLenovoVatage()
        {
            VantageCommonHelper.UninstallVantage();
        }

        [StepDefinition(@"hover toolbar")]
        public void WhenHovertoolbar()
        {
            RegistryKey softwareRegedit = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            if (Convert.ToInt32(softwareRegedit.GetValue("CurrentBuildNumber")) < 22000)
            {
                Thread.Sleep(1000);
                AutomationElement toolbar = FindElementByIdIsEnabled("2000");
                if (toolbar != null)
                {
                    var position = toolbar.Current.BoundingRectangle;
                    string x = ((int)position.Left + (int)position.Width / 2).ToString();
                    string y = ((int)position.Top + (int)position.Height / 2).ToString();
                    SetMouseClick(x, y, true);
                    Thread.Sleep(1000);
                }
            }
            else
            {
                _intelligentcoolingPages = new IntelligentCoolingPages(_session);
                _desktopSession = _intelligentcoolingPages.GetControlPanelSession(true);
                var closeToolbar = _intelligentcoolingPages.FindElementByTimes(_desktopSession, "AutomationId", Convert.ToInt32(ToolBarAutoEnum.ToolBarCloseBtn).ToString(), 1, 2);
                if (closeToolbar == null)
                {
                    WindowsElement toolbarElement = _intelligentcoolingPages.FindElementByTimes(_desktopSession, "Name", "Lenovo Vantage Toolbar", 10);
                    toolbarElement?.Click();
                    Thread.Sleep(3000);
                }
            }
        }

        [Then(@"check toolbar DYTC status (.*)")]
        public void ThenCheckToolbarDYTCStatus(string batterystatus)
        {
            AutomationElement toolbar = FindElementByIdIsEnabled("1051");
            Assert.AreEqual(batterystatus, toolbar.Current.Name);
        }

        [Then(@"check metric data")]
        public void ThenCheckMetricData()
        {
            Thread.Sleep(3000);
            using (var reader = new EventLogReader(_eventLogFile, PathType.FilePath))
            {
                bool dytc6 = false;
                EventRecord record;
                while ((record = reader.ReadEvent()) != null)
                {
                    using (record)
                    {
                        if (record.FormatDescription().Contains("GoToPowerSmartSettingsByThinkIntelligentCooling"))
                        {
                            dytc6 = true;
                            break;
                        }
                    }
                }
                Assert.IsTrue(dytc6, "未找到相应的log数据");
            }
        }

        [Given(@"delete eventlog")]
        public void DeleteVantageEventLog()
        {
            CmdCommands.DeleteVantageEventLog();
        }

        [Then(@"read DYTC6 heartbeat eventlog")]
        public void ThenReadITSHeartbeatEventlog()
        {
            Process[] app = Process.GetProcessesByName("HeartbeatMetrics");
            while (app.Length > 0)
            {
                app = Process.GetProcessesByName("HeartbeatMetrics");
                if (app.Length == 0)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(10000);
                }
            }
            _baseHelper.CheckEventLogInfo(dytc6heartbeat);
        }

        [Then(@"read MCDYTC6 heartbeat eventlog")]
        public void ThenReadMCITS6HeartbeatEventlog()
        {
            Process[] app = Process.GetProcessesByName("HeartbeatMetrics");
            while (app.Length > 0)
            {
                app = Process.GetProcessesByName("HeartbeatMetrics");
                if (app.Length == 0)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(10000);
                }
            }
            _baseHelper.CheckEventLogInfo(dytc6mcheartbeat);
        }

        [Then(@"read DYTC5 heartbeat eventlog")]
        public void ThenReadITS5HeartbeatEventlog()
        {
            Process[] app = Process.GetProcessesByName("HeartbeatMetrics");
            while (app.Length > 0)
            {
                app = Process.GetProcessesByName("HeartbeatMetrics");
                if (app.Length == 0)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(10000);
                }
            }
            _baseHelper.CheckEventLogInfo(dytc5heartbeat);
        }

        [StepDefinition(@"turn on narrator")]
        public void GivenTurnOnNarrator()
        {
            RegistryHelp.CreateRegistry(NarratorRegistry);
        }

        [StepDefinition(@"turn off narrator")]
        public void TurnOffNarrator()
        {
            string NarratorRegistry = "hkcu\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Accessibility\\ATConfig\\narrator";

            if (RegistryHelp.IsRegistrySubKeyExist(NarratorRegistry))
            {
                RegistryHelp.DeleteRegistrySubKey(NarratorRegistry);
            }

        }

        [When(@"User make the machine from AC to DC for ITS")]
        public void WhenUserMakeTheMachineFromACToDCDuringTheRestProcess()
        {
            if (JudgeInsertStatusIsOn())
            {
                AdapterNotInsert();
            }
        }

        [When(@"User make the machine from DC to AC for ITS")]
        public void WhenUserMakeTheMachineFromDCToAC()
        {
            if (!JudgeInsertStatusIsOn())
            {
                AdapterNotInsert();
            }
        }

        [Given(@"enable AMT")]
        public void GivenEnableAMT()
        {
            IntelligentCoolingPages.EnableAMT("CurrentSetting", _itsRegeditPath);
        }

        [Given(@"disable AMT")]
        public void DisEnableAMT()
        {
            IntelligentCoolingPages.DisableAMT("CurrentSetting", _itsRegeditPath);
        }

        [Then(@"ITS not exist in toolbar")]
        public void ThenITSNotExistInToolbar()
        {
            AutomationElement toolbar = FindElementByIdIsEnabled("1051");
            Assert.IsNull(toolbar);
        }

        [Given(@"check AMT (.*)")]
        public void GivenCheckAMTAA(string checkamt)
        {
            _amt = false;
            string regeditPath = "SYSTEM\\CurrentControlSet\\Services\\LITSSVC\\IC";
            RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
            RegistryKey cv = hklm.OpenSubKey(regeditPath);
            string[] subKey = cv.GetSubKeyNames();
            switch (checkamt)
            {
                case "supportAmt":
                    foreach (string sk in subKey)
                    {
                        if (sk == "AMT")
                        {
                            _amt = true;
                            break;
                        }
                    }
                    if (_amt == false)
                    {
                        throw new ValidationException("This case requires a machine with amt.");
                    }
                    break;

                case "notsupportAmt":
                    foreach (string sk in subKey)
                    {
                        if (sk == "AMT")
                        {
                            _amt = false;
                            break;
                        }
                    }
                    if (_amt == true)
                    {
                        throw new ValidationException("This case doesn't require a machine with amt.");
                    }
                    break;
            }

        }

    }
}
