using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_IntelligentCoolingSteps
{
    [Binding]
    public class AutoITSFullTestCaseLegacyCQLDYTC3Steps
    {
        private bool _isApsException = false;
        private InformationalWebDriver _webDriver;
        private string _exceptionMsg = string.Empty;
        private IntelligentCoolingPages _intelligentcoolingPages;
        static private string _modeRegeditPath = "SYSTEM\\CurrentControlSet\\Services\\LITSSVC\\IC\\PSC";
        static private string _itsRegeditPath = "SYSTEM\\CurrentControlSet\\Services\\LITSSVC\\IC\\AMT";
        string its4SMBIntelligentPerformanceTitle = "Intelligent performance";
        string dytc4NocqlDes = "Intelligent Cooling enables you to adjust the system performance and thermal temperature. In \"Performance\" mode, it optimizes the system performance. While it helps to keep the system cooler or quieter in \"Cool & quiet\" mode.";
        string dytc4CqlDes = "When on, this feature dynamically adjusts thermal settings to your needs. It adjusts settings to keep the device cool and quiet while being held or idle. While the device is on a stable surface, it optimizes the performance. When off, you can manually set the thermal priority.";
        string dytc3TIODes = "Intelligent Cooling automatically balances thermal performance to adjust to your needs. The Intelligent Cooling feature adjusts performance settings to provide a cooler surface for your comfort, when the notebook is being held. When the device is on a desktop surface, this feature optimizes performance.";
        string dytc5Desc_Spec = "Intelligent Cooling adjusts fan speed, maximum performance, and manages your battery life. This feature has 3 modes (Quiet mode, Balanced mode, and Performance mode) and is now accessible by the Windows performance power slider.";
        string dytc5quietModeDesc_Spec = "Quiet mode: Slider is far left. The fan speed and performance are lowered for a cooler, quieter computer and best battery life.";
        string dytc5balancedModeDesc_Spec = "Balanced mode: Slider is in the center. Fan speed and performance are dynamically balanced for the best experience.";
        string dytc5performanceModeDesc_Spec = "Performance mode: Slider is far right. Fan speed and permissible surface temperature are higher for maximum performance.";
        string quietModeDesc_Spec = "Quiet mode: The slider is on the left. Fan speed and performance are lowered for a cooler, quieter computer and best battery life.";
        string balancedModeDesc_Spec = "Balanced mode: The slider is in the center or center right. Fan speed and performance are dynamically balanced for the best experience.";
        string performanceModeDesc_Spec = "Performance mode: The slider is far right. Fan speed and permissible surface temperature are higher for maximum performance.";
        string dytc6Desc_Spec01 = "Intelligent Cooling adjusts fan speed, maximum performance, and manages your battery life.";
        string dytc6Desc_Spec02 = "The feature has modes listed below and now is adjusted by Windows performance power slider. You can access it by clicking the battery icon in the Windows system tray.";
        string dytc6Desc_Spec03 = "Some of the modes can automatically adjust across a wider range of performance based on your activity. To disable automatic mode, press Fn+ T.";
        string dytc6QuietModeDesc_Spec = "Auto Battery mode: The slider is on the left. The mode is dynamically switched to Quiet mode or Battery mode for the best DC mode experience.";
        string dytc6BalancedModeDesc_Spec = "Auto Performance mode: The slider is in the center or center right. The mode is dynamically switched to Quiet mode, Balanced mode or Performance mode for the best AC mode experience.";
        string dytc6PerformanceModeDesc_Spec = "Performance mode: The slider is far right. Fan speed and permissible surface temperature are higher for maximum performance.";
        string dytc6MWSLEquitemode = "Quiet mode: The slider is on the left. Fan speed and performance are lowered for a cooler, quieter computer and best battery life.";
        string dytc6MWSLEbalancedmode = "Balanced mode: The slider is in the center or center right. Fan speed and performance are dynamically balanced for the best experience.";
        string dytc6MWSLEperformancemode = "Performance mode: The slider is far right. Fan speed and permissible surface temperature are higher for maximum performance.";
        string dytc6MWSCommonquitemode = "Quiet mode(only for on battery mode): The slider is on the far left. Both fan speed and performance are low for a cooler, quieter computer and the best battery life.";
        string dytc6MWSCommonbalancedmode = "Balanced mode: The slider is on the left or center left. Fan speed and performance are dynamically balanced for the best experience.";
        string dytc6MWSCommonperformancemode = "Performance mode: The slider is on the center or center right. Both fan speed and surface temperature are high.";
        string dytc6MWSCommonultraperformancemode = "Ultra-performance mode: The slider is far right, providing ultra-high performance with bigger noise and higher surface temperature.";


        private IntelligentCoolingBaseHelper _baseHelper = new IntelligentCoolingBaseHelper();
        public AutoITSFullTestCaseLegacyCQLDYTC3Steps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"IntelligentColling Toggle Exists")]
        public void ThenIntelligentCollingToggleExistsDYTCTHREECQL()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var toggleElement = _intelligentcoolingPages.IntelligentCoolingToggle;
            Assert.IsNotNull(toggleElement);
        }

        [Then(@"IntelligentColling Toggle Not Exists")]
        public void ThenIntelligentCollingToggleNotExistsDYTCTHREECQL()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var toggleElement = _intelligentcoolingPages.IntelligentCoolingToggle;
            Assert.IsNull(toggleElement);
        }

        [Given(@"Turn on Intellgentcooling toggle")]
        public void GivenTurnontoggleDYTCTHREECQL()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var toggleState = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingToggle);
            if (toggleState == ToggleState.Off)
            {
                _intelligentcoolingPages.IntelligentCoolingToggle?.Click();
            }
        }

        [Given(@"Turn off Intellgentcooling toggle")]
        public void GivenTurnofftoggleDYTCTHREECQL()
        {
            TurnOffToggle();
        }

        [Then(@"Turn Off Toggle State Normal")]
        public void ThenTurnOffToggleStateNormalDYTCTHREECQL()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var toggleState = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingToggle);
            Assert.AreEqual(ToggleState.Off, toggleState);
        }

        [Then(@"Turn On Toggle State")]
        public void ThenTurnOnToggleStateDYTCTHREECQL()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var toggleState = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingToggle);
            Assert.AreEqual(ToggleState.On, toggleState);
        }

        [Given(@"Switch performance mode")]
        public void GivenSwitchperformancemodeDYTCTHREECQL()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var performanceMode = _intelligentcoolingPages.IntelligentCoolingPerformanceMode;
            if (performanceMode != null)
            {
                performanceMode.Click();
            }
        }

        [Then(@"Switch Performance Mode Normal")]
        public void ThenSwitchPerformanceModeNormalDYTCTHREECQL()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var performanceState = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingPerformanceMode);
            Assert.AreEqual(ToggleState.On, performanceState);
        }

        [Given(@"Switch coolquiet mode")]
        public void GivenSwitchcoolquietmodeDYTCTHREECQL()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var quietModeElement = _intelligentcoolingPages.IntelligentCoolingCoolQuietMode;
            if (quietModeElement != null)
            {
                quietModeElement.Click();
            }
        }

        [Then(@"Switch CoolQuiet Mode Normal")]
        public void ThenSwitchCoolQuietModeNormalDYTCTHREECQL()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var quietModeState = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingCoolQuietMode);
            Assert.AreEqual(ToggleState.On, quietModeState);
        }

        [Given(@"Switch toggle off DYTC THREE CQL")]
        public void GivenSwitchtoggleoffDYTCTHREECQL()
        {
            TurnOffToggle();
        }

        [Given(@"SetWindowSize")]
        public void GivenSetWindowSize()
        {
            _webDriver.Session.Manage().Window.Size = new System.Drawing.Size(928, 1090);
        }

        [Given(@"SetWindowSize to (.*) (.*)")]
        public void GivenSetWindowSizeto(int width, int height)
        {
            _webDriver.Session.Manage().Window.Size = new System.Drawing.Size(width, height);
        }

        [Then(@"Fast Switch IntelligentCooling Mode")]
        public void ThenFastSwitchIntelligentCoolingModeDYTCTHREECQL()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            bool performanceTag = false;
            bool quietTag = false;
            var performanceMode = _intelligentcoolingPages.IntelligentCoolingPerformanceMode;
            var quietMode = _intelligentcoolingPages.IntelligentCoolingCoolQuietMode;
            if (quietMode != null && performanceMode != null)
            {
                for (int i = 0; i < 30; i++)
                {
                    _intelligentcoolingPages.IntelligentCoolingPerformanceMode.Click();
                    _intelligentcoolingPages.IntelligentCoolingCoolQuietMode.Click();

                }
                performanceMode.Click();
                var performanceState = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingPerformanceMode);
                if (performanceState == ToggleState.On)
                {
                    performanceTag = true;
                }
                quietMode.Click();
                var quietState = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingCoolQuietMode);
                if (quietState == ToggleState.On)
                {
                    quietTag = true;
                }
                Assert.IsTrue(performanceTag && quietTag);
            }
        }

        [Then(@"Fast Switch ITS Mode")]
        public void ThenFastSwitchITS4ModeITSSMB()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var intelligentCoolingMode = _intelligentcoolingPages.IntelligentCoolingMode;
            var extremePerformanceMode = _intelligentcoolingPages.ExtremePerformanceMode;
            var batterySavingMode = _intelligentcoolingPages.BatterySavingMode;
            if (intelligentCoolingMode != null && extremePerformanceMode != null && batterySavingMode != null)
            {
                for (int i = 0; i < 30; i++)
                {
                    _intelligentcoolingPages.IntelligentCoolingMode.Click();
                    _intelligentcoolingPages.ExtremePerformanceMode.Click();
                    _intelligentcoolingPages.BatterySavingMode.Click();
                }
            }
        }

        [Then(@"Fast Switch IntelligentCooling toggle")]
        public void ThenFastSwitchIntelligentCoolingToggle()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            bool IntelligentCoolingToggletag = false;
            var IntelligentCoolingToggle = _intelligentcoolingPages.IntelligentCoolingToggle;
            if (IntelligentCoolingToggle != null)
            {
                for (int i = 0; i < 30; i++)
                {
                    _intelligentcoolingPages.IntelligentCoolingToggle.Click();
                }
            }
            var IntelligentCoolingToggleStat = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingToggle);
            if (IntelligentCoolingToggleStat == ToggleState.On)
            {
                _intelligentcoolingPages.IntelligentCoolingToggle.Click();
            }
            IntelligentCoolingToggleStat = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingToggle);
            Assert.AreEqual(ToggleState.Off, IntelligentCoolingToggleStat);
        }

        [Given(@"jump to power smart settings")]
        public void GivenJumpToPowerSmartSettings()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            _intelligentcoolingPages.HSJumpToSmartSettings?.Click();
        }


        private void TurnOnToggle()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var toggleState = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingToggle);
            if (toggleState == ToggleState.Off)
            {
                _intelligentcoolingPages.IntelligentCoolingToggle?.Click();
            }
        }

        [Then(@"DYTC6AMT (.*) registry is correct with (.*) and (.*)")]
        public void ThenDYTC6AMTRegistryIsCorrectWithAnd(string status, string ACDC, string batterymode)
        {
            var modeStatus = RegistryHelp.GetValueFromRegedit("CurrentSetting", _modeRegeditPath);
            var amtStatus = RegistryHelp.GetValueFromRegedit("CurrentSetting", _itsRegeditPath);
            if (status.ToLower() == "enabled")
            {
                Assert.AreEqual(amtStatus, "2");
            }
            else if (status.ToLower() == "disabled")
            {
                Assert.AreEqual(amtStatus, "1");
            }
            if (ACDC.ToLower() == "ac")
            {
                if (batterymode.ToLower() == "better battery") { Assert.AreEqual(modeStatus, "3"); }
                if (batterymode.ToLower() == "better performance") { Assert.AreEqual(modeStatus, "5"); }
                if (batterymode.ToLower() == "best performance") { Assert.AreEqual(modeStatus, "7"); }
            }
            else if (ACDC.ToLower() == "dc")
            {
                if (batterymode.ToLower() == "battery saver") { Assert.AreEqual(modeStatus, "2"); }
                if (batterymode.ToLower() == "better battery") { Assert.AreEqual(modeStatus, "4"); }
                if (batterymode.ToLower() == "better performance") { Assert.AreEqual(modeStatus, "6"); }
                if (batterymode.ToLower() == "best performance") { Assert.AreEqual(modeStatus, "8"); }
            }
        }

        private void TurnOffToggle()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var toggleState = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingToggle);
            if (toggleState == ToggleState.On)
            {
                _intelligentcoolingPages.IntelligentCoolingToggle?.Click();
            }
        }

        [Then(@"Check Intelligent Cooling (.*) for (.*)")]
        public void ThenCheckIntelligentCoolingIsShowFor(string status, string machineType)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);

            WindowsElement jumpLink = null;
            WindowsElement powerSmartSettings = null;   //section title
            WindowsElement intelligentTitle = null;    //Intelligent Cooling sub title
            WindowsElement intelligentDescription = null;   //Description paragraph
            WindowsElement coolMode = null;
            WindowsElement performanceMode = null;
            WindowsElement toggle = null;
            WindowsElement collapseBtn = null;

            jumpLink = _intelligentcoolingPages.HSJumpToSmartSettings;
            powerSmartSettings = _intelligentcoolingPages.PowerSmartSettingsTitle;
            intelligentTitle = _intelligentcoolingPages.IntelligentCoolingTitle;
            intelligentDescription = _intelligentcoolingPages.IntelligentCoolingDescription;
            collapseBtn = _intelligentcoolingPages.IntelligentCoolingCollapseExpand;

            List<WindowsElement> list = new List<WindowsElement>();

            WindowsElement[] listEl = new WindowsElement[] { jumpLink, powerSmartSettings, intelligentTitle, intelligentDescription, collapseBtn };
            list.AddRange(listEl);

            switch (machineType)
            {

                case "DYTC4NOCQL":
                    toggle = _intelligentcoolingPages.IntelligentCoolingToggle;
                    performanceMode = _intelligentcoolingPages.IntelligentCoolingPerformanceMode;
                    coolMode = _intelligentcoolingPages.IntelligentCoolingCoolQuietMode;
                    list.Add(performanceMode);
                    list.Add(coolMode);

                    if (status.ToLower() == "show")
                    {
                        Assert.IsNull(toggle);
                        Assert.IsFalse(list.Exists(ele => ele == null));
                    }
                    else if (status.ToLower() == "hide")
                    {
                        Assert.IsNull(toggle);
                        Assert.IsFalse(list.Exists(ele => ele != null));
                    }
                    break;

                case "DYTC4CQL":
                    toggle = _intelligentcoolingPages.IntelligentCoolingToggle;
                    performanceMode = _intelligentcoolingPages.IntelligentCoolingPerformanceMode;
                    coolMode = _intelligentcoolingPages.IntelligentCoolingCoolQuietMode;
                    list.Add(toggle);
                    list.Add(performanceMode);
                    list.Add(coolMode);

                    if (status.ToLower() == "show")
                    {
                        Assert.IsFalse(list.Exists(ele => ele == null));
                    }
                    else if (status.ToLower() == "hide")
                    {
                        Assert.IsFalse(list.Exists(ele => ele != null));
                    }
                    break;

                case "DYTC4TIO":
                    toggle = _intelligentcoolingPages.IntelligentCoolingToggle;
                    performanceMode = _intelligentcoolingPages.IntelligentCoolingPerformanceMode;
                    coolMode = _intelligentcoolingPages.IntelligentCoolingCoolQuietMode;
                    list.Add(toggle);
                    list.Add(performanceMode);
                    list.Add(coolMode);

                    if (status.ToLower() == "show")
                    {
                        Assert.IsFalse(list.Exists(ele => ele == null));
                    }
                    else if (status.ToLower() == "hide")
                    {
                        Assert.IsFalse(list.Exists(ele => ele != null));
                    }
                    break;

                case "DYTC3TIO":
                    toggle = _intelligentcoolingPages.IntelligentCoolingToggle;
                    list.Add(toggle);

                    if (status.ToLower() == "show")
                    {
                        Assert.IsFalse(list.Exists(ele => ele == null));
                    }
                    else if (status.ToLower() == "hide")
                    {
                        Assert.IsFalse(list.Exists(ele => ele != null));
                    }
                    break;

                case "DYTC3CQL":
                    toggle = _intelligentcoolingPages.IntelligentCoolingToggle;
                    performanceMode = _intelligentcoolingPages.IntelligentCoolingPerformanceMode;
                    coolMode = _intelligentcoolingPages.IntelligentCoolingCoolQuietMode;
                    var installAPSHint = _intelligentcoolingPages.IntelligentCoolingDYTC3CQLAPSHint;
                    var optimizeDesc = _intelligentcoolingPages.IntelligentCoolingDYTC3CQLOptimizeDesc;
                    list.Add(toggle);
                    list.Add(performanceMode);
                    list.Add(coolMode);
                    list.Add(optimizeDesc);

                    if (status.ToLower() == "show")
                    {
                        Assert.IsNull(installAPSHint);
                        Assert.IsFalse(list.Exists(ele => ele == null));
                    }
                    else if (status.ToLower() == "hide")
                    {
                        Assert.IsNull(installAPSHint);
                        Assert.IsFalse(list.Exists(ele => ele != null));
                    }
                    break;

                case "DYTC3CQLNOAPS":
                    toggle = _intelligentcoolingPages.IntelligentCoolingToggle;
                    performanceMode = _intelligentcoolingPages.IntelligentCoolingPerformanceMode;
                    coolMode = _intelligentcoolingPages.IntelligentCoolingCoolQuietMode;
                    list.Add(toggle);
                    list.Add(performanceMode);
                    list.Add(coolMode);

                    if (status.ToLower() == "show")
                    {
                        Assert.IsFalse(list.Exists(ele => ele == null));
                    }
                    else if (status.ToLower() == "hide")
                    {
                        Assert.IsFalse(list.Exists(ele => ele != null));
                    }
                    break;

                case "DYTC5":
                    intelligentTitle = _intelligentcoolingPages.IntelligentCoolingDYTC5Title;
                    intelligentDescription = _intelligentcoolingPages.IntelligentCoolingDYTC5Desc;
                    var Readmorelink = _intelligentcoolingPages.ReadMore;
                    var moreinfolink = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20MoreLink;
                    list[2] = intelligentTitle;
                    list[3] = intelligentDescription;
                    list.Add(Readmorelink);
                    list.Add(moreinfolink);

                    if (status.ToLower() == "show")
                    {
                        Assert.IsFalse(list.Exists(ele => ele == null));
                    }
                    else if (status.ToLower() == "hide")
                    {
                        Assert.IsFalse(list.Exists(ele => ele != null));
                    }
                    break;

                case "DYTC5Popup":
                    var popclose = _intelligentcoolingPages.popupwindowclosebutton;
                    var popXicon = _intelligentcoolingPages.xicon;
                    var poptitle = _intelligentcoolingPages.popupwindowtitle;
                    var popDesc01 = _intelligentcoolingPages.IntelligentCoolingDYTC5PopupDesc01;
                    var popDesc02 = _intelligentcoolingPages.IntelligentCoolingDYTC5PopupDesc02;
                    var popIcon01 = _intelligentcoolingPages.IntelligentCoolingDYTC5PopupIcon01;
                    var popIcon02 = _intelligentcoolingPages.IntelligentCoolingDYTC5PopupIcon02;
                    var popImg01 = _intelligentcoolingPages.IntelligentCoolingDYTC5PopupImg01;
                    var popImg02 = _intelligentcoolingPages.IntelligentCoolingDYTC5PopupImg02;

                    List<WindowsElement> PopupEle = new List<WindowsElement>();
                    WindowsElement[] Elelist = new WindowsElement[] { popXicon, poptitle, popDesc01, popDesc02, popIcon01, popIcon02, popImg01, popImg02 };
                    PopupEle.AddRange(Elelist);
                    if (VantageConstContent.NotLEMask)
                    {
                        PopupEle.Add(popclose);
                    }
                    if (status.ToLower() == "show")
                    {
                        Assert.IsFalse(PopupEle.Exists(ele => ele == null));
                    }
                    else if (status.ToLower() == "hide")
                    {
                        Assert.IsFalse(PopupEle.Exists(ele => ele != null));
                    }
                    break;

                case "DYTC6AMT":
                    intelligentTitle = _intelligentcoolingPages.IntelligentCoolingTitleThink;
                    var intelligentDescription1 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc01;
                    var intelligentDescription2 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc02;
                    var intelligentDescription3 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc03;
                    var intelligentDescription3_1 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc03_1;
                    moreinfolink = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20MoreLink;
                    var toolbarimg = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Images;
                    list[2] = intelligentTitle;
                    list[3] = intelligentDescription1;
                    list.Add(intelligentDescription2);
                    list.Add(moreinfolink);
                    list.Add(toolbarimg);
                    bool dytc6AmtDesExist = false;
                    if (intelligentDescription3 != null || intelligentDescription3_1 != null)
                    {
                        dytc6AmtDesExist = true;
                    }
                    if (status.ToLower() == "show")
                    {
                        Assert.IsFalse(list.Exists(ele => ele == null));
                        Assert.IsTrue(dytc6AmtDesExist);
                    }
                    else if (status.ToLower() == "hide")
                    {
                        Assert.IsFalse(list.Exists(ele => ele != null));
                        Assert.IsFalse(dytc6AmtDesExist);
                    }
                    break;

                case "DYTC6NOAMT":
                    intelligentTitle = _intelligentcoolingPages.IntelligentCoolingTitleThink;
                    intelligentDescription1 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc01;
                    intelligentDescription2 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc02;
                    moreinfolink = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20MoreLink;
                    toolbarimg = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Images;
                    list[2] = intelligentTitle;
                    list[3] = intelligentDescription1;
                    list.Add(intelligentDescription2);
                    list.Add(moreinfolink);
                    list.Add(toolbarimg);

                    if (status.ToLower() == "show")
                    {
                        Assert.IsFalse(list.Exists(ele => ele == null));
                    }
                    else if (status.ToLower() == "hide")
                    {
                        Assert.IsFalse(list.Exists(ele => ele != null));
                    }
                    break;

                case "Perf&CQ":
                    performanceMode = _intelligentcoolingPages.IntelligentCoolingPerformanceMode;
                    coolMode = _intelligentcoolingPages.IntelligentCoolingCoolQuietMode;
                    if (status.ToLower() == "hide")
                    {
                        Assert.IsNull(performanceMode);
                        Assert.IsNull(coolMode);
                    }
                    if (status.ToLower() == "show")
                    {
                        Assert.IsNotNull(performanceMode);
                        Assert.IsNotNull(coolMode);
                    }
                    break;

                case "ITS5":
                case "ITS4":
                    var extremePerformanceicon = _intelligentcoolingPages.IntelligentCoolingExtremePerformanceMode;
                    var intelligentCoolingicon = _intelligentcoolingPages.IntelligentCoolingIntelligentCoolingMode;
                    var batterySavingicon = _intelligentcoolingPages.IntelligentCoolingBatterySavingMode;
                    list.Add(extremePerformanceicon);
                    list.Add(intelligentCoolingicon);
                    list.Add(batterySavingicon);

                    if (status.ToLower() == "hide")
                    {
                        Assert.IsFalse(list.Exists(ele => ele != null));
                    }
                    if (status.ToLower() == "show")
                    {
                        Assert.IsFalse(list.Exists(ele => ele == null));
                    }
                    break;

                case "ITS4SMB":
                    var creatorsettingstitle = _intelligentcoolingPages.CreatorSettingsTitle;
                    var intelligentperformancetitle = _intelligentcoolingPages.IntelligentPerformanceTitle;
                    //var collapse = _intelligentcoolingPages.CollapseTitle;
                    var intelligentdescription = _intelligentcoolingPages.intelligentDescription;
                    var extremeperformanceicon = _intelligentcoolingPages.IntelligentCoolingExtremePerformanceMode;
                    var intelligentcoolingicon = _intelligentcoolingPages.IntelligentCoolingIntelligentCoolingMode;
                    var batterysavingicon = _intelligentcoolingPages.IntelligentCoolingBatterySavingMode;

                    if (status.ToLower() == "show")
                    {
                        Assert.IsNotNull(creatorsettingstitle, "creatorsettings title is hide");
                        //Assert.IsNotNull(collapse, "collapse title is hide");
                        Assert.IsNotNull(intelligentperformancetitle, "intelligentperformance title is hide");
                        Assert.IsNotNull(intelligentdescription, "intelligent description is hide");
                        Assert.IsNotNull(extremeperformanceicon, "extremeperformance icon is hide");
                        Assert.IsNotNull(intelligentcoolingicon, "intelligentcooling icon is hide");
                        Assert.IsNotNull(batterysavingicon, "batterysaving icon is hide");
                    }

                    if (status.ToLower() == "hide")
                    {
                        Assert.IsNull(intelligentperformancetitle, "intelligentperformance title is show");
                        Assert.IsNull(intelligentdescription, "intelligent description is show");
                        Assert.IsNull(extremeperformanceicon, "extremeperformance icon is show");
                        Assert.IsNull(intelligentcoolingicon, "intelligentcooling icon is show");
                        Assert.IsNull(batterysavingicon, "batterysaving icon is show");
                    }

                    break;

                case "ITS2":
                case "ITS3":
                    toggle = _intelligentcoolingPages.IntelligentCoolingToggle;
                    extremePerformanceicon = _intelligentcoolingPages.IntelligentCoolingExtremePerformanceMode;
                    intelligentCoolingicon = _intelligentcoolingPages.IntelligentCoolingIntelligentCoolingMode;
                    list.Add(toggle);
                    list.Add(extremePerformanceicon);
                    list.Add(intelligentCoolingicon);
                    if (status.ToLower() == "hide")
                    {
                        Assert.IsFalse(list.Exists(ele => ele != null));
                    }
                    if (status.ToLower() == "show")
                    {
                        Assert.IsFalse(list.Exists(ele => ele == null));
                    }
                    break;
            }
        }

        [Then(@"Check Intelligent Performance Title")]
        public void ThenCheckIntelligentPerformanceTitle()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            WindowsElement intelligentperformancetitle = _intelligentcoolingPages.IntelligentPerformanceTitle;
            string IntelligentPerformanceTitle = intelligentperformancetitle.GetAttribute("Name");
            Assert.AreEqual(IntelligentPerformanceTitle, its4SMBIntelligentPerformanceTitle, "ITS title is wrong");
        }

        [Then(@"Check Intelligent CoolingDesc Text for (.*)")]
        public void ThenCheckIntelligentCoolingDescTextFor(string p)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            WindowsElement intelligentDescription = _intelligentcoolingPages.IntelligentCoolingDescription;

            switch (p)
            {
                case "DYTC4NOCQL":
                    var realDes = intelligentDescription.GetAttribute("Name");
                    Assert.AreEqual(realDes, dytc4NocqlDes);
                    break;

                case "DYTC4CQL":
                    realDes = intelligentDescription.GetAttribute("Name");
                    Assert.AreEqual(realDes, dytc4CqlDes);
                    break;

                case "DYTC3TIO":
                    realDes = intelligentDescription.GetAttribute("Name");
                    Assert.AreEqual(realDes, dytc3TIODes);
                    break;

                case "DYTC3CQL":
                    break;

                case "DYTC5":
                    intelligentDescription = _intelligentcoolingPages.IntelligentCoolingDYTC5Desc;
                    var quietModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC5QuietDesc;
                    var balancedModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC5BalancedDesc;
                    var performanceModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC5PerformanceDesc;
                    realDes = intelligentDescription.GetAttribute("Name");
                    var quietModeRealDesc = quietModeDes.GetAttribute("Name");
                    var balancedModeRealDesc = balancedModeDes.GetAttribute("Name");
                    var performanceModeRealDesc = performanceModeDes.GetAttribute("Name");

                    if (!VantageConstContent.NotLEMask)
                    {
                        dytc5Desc_Spec = "Intelligent Cooling adjusts fan speed, maximum performance, and manages your battery life. This feature has 3 modes (Quiet mode, Balanced mode and Performance mode) and is now accessible by the Windows performance power slider";
                    }

                    Assert.AreEqual(dytc5Desc_Spec, realDes);
                    Assert.AreEqual(dytc5quietModeDesc_Spec, quietModeRealDesc);
                    Assert.AreEqual(dytc5balancedModeDesc_Spec, balancedModeRealDesc);
                    Assert.AreEqual(dytc5performanceModeDesc_Spec, performanceModeRealDesc);
                    break;

                case "DYTC6AMT_enabled_More":
                    var intelligentDescription1 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc01;
                    var intelligentDescription2 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc02;
                    var intelligentDescription3 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc03_1;

                    quietModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6QuietModeDes;
                    balancedModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6BalancedModeDes;
                    performanceModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6PerformanceModeDes;

                    var realDes1 = intelligentDescription1.GetAttribute("Name");
                    var realDes2 = intelligentDescription2.GetAttribute("Name");
                    var realDes3 = intelligentDescription3.GetAttribute("Name");
                    quietModeRealDesc = quietModeDes.GetAttribute("Name");
                    balancedModeRealDesc = balancedModeDes.GetAttribute("Name");
                    performanceModeRealDesc = performanceModeDes.GetAttribute("Name");

                    Assert.AreEqual(dytc6Desc_Spec01, realDes1);
                    Assert.AreEqual(dytc6Desc_Spec02, realDes2);
                    Assert.AreEqual(dytc6Desc_Spec03, realDes3);
                    Assert.AreEqual(dytc6QuietModeDesc_Spec, quietModeRealDesc);
                    Assert.AreEqual(dytc6BalancedModeDesc_Spec, balancedModeRealDesc);
                    Assert.AreEqual(dytc6PerformanceModeDesc_Spec, performanceModeRealDesc);
                    break;

                case "DYTC6AMT_disabled_More":
                    intelligentDescription1 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc01;
                    intelligentDescription2 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc02;
                    intelligentDescription3 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc03;

                    quietModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6QuietModeDes;
                    balancedModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6BalancedModeDes;
                    performanceModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6PerformanceModeDes;
                    realDes1 = intelligentDescription1.GetAttribute("Name");
                    realDes2 = intelligentDescription2.GetAttribute("Name");
                    realDes3 = intelligentDescription3.GetAttribute("Name");

                    quietModeRealDesc = quietModeDes.GetAttribute("Name");
                    balancedModeRealDesc = balancedModeDes.GetAttribute("Name");
                    performanceModeRealDesc = performanceModeDes.GetAttribute("Name");

                    dytc6Desc_Spec03 = "Some of the modes can automatically adjust across a wider range of performance based on your activity. To enable automatic mode, press Fn+ T.";

                    Assert.AreEqual(dytc6Desc_Spec01, realDes1);
                    Assert.AreEqual(dytc6Desc_Spec02, realDes2);
                    Assert.AreEqual(dytc6Desc_Spec03, realDes3);
                    Assert.AreEqual(quietModeDesc_Spec, quietModeRealDesc);
                    Assert.AreEqual(balancedModeDesc_Spec, balancedModeRealDesc);
                    Assert.AreEqual(performanceModeDesc_Spec, performanceModeRealDesc);
                    break;

                case "DYTC6AMT_enabled_Less":
                    intelligentDescription1 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc01;
                    intelligentDescription2 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc02;
                    intelligentDescription3 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc03_1;
                    quietModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6QuietModeDes;
                    balancedModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6BalancedModeDes;
                    performanceModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6PerformanceModeDes;
                    var moreButton = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20MoreLink;

                    realDes1 = intelligentDescription1.GetAttribute("Name");
                    realDes2 = intelligentDescription2.GetAttribute("Name");
                    var moreButtonName = moreButton.GetAttribute("Name");
                    realDes3 = intelligentDescription3.GetAttribute("Name");

                    Assert.AreEqual(dytc6Desc_Spec01, realDes1);
                    Assert.AreEqual(dytc6Desc_Spec02, realDes2);
                    Assert.AreEqual(dytc6Desc_Spec03, realDes3);
                    Assert.IsNull(quietModeDes);
                    Assert.IsNull(balancedModeDes);
                    Assert.IsNull(performanceModeDes);
                    Assert.AreEqual(moreButtonName, "MORE");
                    break;

                case "DYTC6AMT_disabled_Less":
                    intelligentDescription1 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc01;
                    intelligentDescription2 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc02;
                    intelligentDescription3 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc03;
                    quietModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6QuietModeDes;
                    balancedModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6BalancedModeDes;
                    performanceModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6PerformanceModeDes;
                    moreButton = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20MoreLink;

                    realDes1 = intelligentDescription1.GetAttribute("Name");
                    realDes2 = intelligentDescription2.GetAttribute("Name");
                    moreButtonName = moreButton.GetAttribute("Name");
                    realDes3 = intelligentDescription3.GetAttribute("Name");

                    dytc6Desc_Spec03 = "Some of the modes can automatically adjust across a wider range of performance based on your activity. To enable automatic mode, press Fn+ T.";

                    Assert.AreEqual(dytc6Desc_Spec01, realDes1);
                    Assert.AreEqual(dytc6Desc_Spec02, realDes2);
                    Assert.AreEqual(dytc6Desc_Spec03, realDes3);
                    Assert.IsNull(quietModeDes);
                    Assert.IsNull(balancedModeDes);
                    Assert.IsNull(performanceModeDes);
                    Assert.AreEqual(moreButtonName, "MORE");
                    break;

                case "DYTC6NOAMT_More":
                    intelligentDescription1 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc01;
                    intelligentDescription2 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc02;
                    quietModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6QuietModeDes;
                    balancedModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6BalancedModeDes;
                    performanceModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6PerformanceModeDes;
                    var lessButton = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20LessLink;

                    realDes1 = intelligentDescription1.GetAttribute("Name");
                    realDes2 = intelligentDescription2.GetAttribute("Name");
                    quietModeRealDesc = quietModeDes.GetAttribute("Name");
                    balancedModeRealDesc = balancedModeDes.GetAttribute("Name");
                    performanceModeRealDesc = performanceModeDes.GetAttribute("Name");
                    var lessButtonName = lessButton.GetAttribute("Name");

                    Assert.AreEqual(dytc6Desc_Spec01, realDes1);
                    Assert.AreEqual(dytc6Desc_Spec02, realDes2);
                    Assert.AreEqual(quietModeDesc_Spec, quietModeRealDesc);
                    Assert.AreEqual(balancedModeDesc_Spec, balancedModeRealDesc);
                    Assert.AreEqual(performanceModeDesc_Spec, performanceModeRealDesc);
                    Assert.AreEqual(lessButtonName, "LESS");
                    break;

                case "DYTC6NOAMT_Less":
                    intelligentDescription1 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc01;
                    intelligentDescription2 = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc02;
                    quietModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6QuietModeDes;
                    balancedModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6BalancedModeDes;
                    performanceModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6PerformanceModeDes;
                    moreButton = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20MoreLink;

                    realDes1 = intelligentDescription1.GetAttribute("Name");
                    realDes2 = intelligentDescription2.GetAttribute("Name");
                    moreButtonName = moreButton.GetAttribute("Name");

                    Assert.AreEqual(dytc6Desc_Spec01, realDes1);
                    Assert.AreEqual(dytc6Desc_Spec02, realDes2);
                    Assert.IsNull(quietModeDes);
                    Assert.IsNull(balancedModeDes);
                    Assert.IsNull(performanceModeDes);
                    Assert.AreEqual(moreButtonName, "MORE");
                    break;

                case "DYTC6MWS":
                    quietModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6MWSQuiteDesc;
                    balancedModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6MWSBalancedDesc;
                    performanceModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6MWSPerformanceDesc;
                    var ultraperformanceModeDes = _intelligentcoolingPages.IntelligentCoolingDYTC6MWSUltraperformanceDesc;

                    quietModeRealDesc = quietModeDes.GetAttribute("Name");
                    balancedModeRealDesc = balancedModeDes.GetAttribute("Name");
                    performanceModeRealDesc = performanceModeDes.GetAttribute("Name");


                    if (!VantageConstContent.NotLEMask)
                    {
                        dytc6MWSLEquitemode = "Quiet mode: The slider is on the left. Fan speed and performance are lowered for a cooler, quieter computer and best battery life.";
                        Assert.AreEqual(dytc6MWSLEquitemode, quietModeRealDesc);
                        Assert.AreEqual(dytc6MWSLEbalancedmode, balancedModeRealDesc);
                        Assert.AreEqual(dytc6MWSLEperformancemode, performanceModeRealDesc);
                    }
                    else if (VantageConstContent.NotLEMask)
                    {
                        var ultraperformanceModeRealDes = ultraperformanceModeDes.GetAttribute("Name");
                        dytc6MWSCommonquitemode = "Quiet mode(only for on battery mode): The slider is on the far left. Both fan speed and performance are low for a cooler, quieter computer and the best battery life.";
                        Assert.AreEqual(dytc6MWSCommonquitemode, quietModeRealDesc);
                        Assert.AreEqual(dytc6MWSCommonbalancedmode, balancedModeRealDesc);
                        Assert.AreEqual(dytc6MWSCommonperformancemode, performanceModeRealDesc);
                        Assert.AreEqual(dytc6MWSCommonultraperformancemode, ultraperformanceModeRealDes);
                    }
                    break;

                case "DYTC4TIO":
                case "ITS2":
                case "ITS3":
                    realDes = intelligentDescription.GetAttribute("Name");
                    var ITS3Des = "When on, this feature dynamically adjusts thermal settings to your needs. It adjusts settings to keep the device cool and quiet while being held or idle. While the device is on a stable surface, it optimizes the performance. When off, you can manually set the thermal priority.";
                    Assert.AreEqual(realDes, ITS3Des);
                    break;

                case "ITS4":
                    realDes = intelligentDescription.GetAttribute("Name");
                    var ITS4Des = "This feature enables you to adjust your fan speed, maximize the system performance, or extend your battery life if needed. It has three modes below. You also can switch the modes using hotkeys (Fn+Q) or from Lenovo Vantage Toolbar.";
                    Assert.AreEqual(realDes, ITS4Des);
                    break;

                case "ITS4ICM":
                    intelligentDescription = _intelligentcoolingPages.IntelligentCoolingSelectModeDesc;
                    realDes = intelligentDescription.GetAttribute("Name");
                    var ITSICMDescription = "This mode enables the best experience with fan speed and system performance balanced. For example, when in gaming, it optimizes the performance. While in the office, it reduces the noise.";
                    Assert.AreEqual(realDes, ITSICMDescription);
                    break;

                case "ITS4EPM":
                    intelligentDescription = _intelligentcoolingPages.IntelligentCoolingSelectModeDesc;
                    realDes = intelligentDescription.GetAttribute("Name");
                    var ITSEPMDescription = "This mode enables the maximum system performance. In this mode, the fast fan speed might cause big noise.";
                    Assert.AreEqual(realDes, ITSEPMDescription);
                    break;

                case "ITS4BSM":
                    intelligentDescription = _intelligentcoolingPages.IntelligentCoolingSelectModeDesc;
                    realDes = intelligentDescription.GetAttribute("Name");
                    var ITSBSMDescription = "This mode enables the maximum battery life by automatically adjusting the brightness, changing the power settings, disabling features on advanced image processing, etc.";
                    Assert.AreEqual(realDes, ITSBSMDescription);
                    break;

                case "ITS5EPM_GPU":
                    _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
                    WindowsElement GpuOcCheckBoxEle = _intelligentcoolingPages.IntelligentCooling5GpuOcCheckBox;
                    WindowsElement GpuOcCheckBoxEle1 = _intelligentcoolingPages.IntelligentCooling5GpuOcCheckBoxDesc1;
                    WindowsElement GpuOcCheckBoxEle2 = _intelligentcoolingPages.IntelligentCooling5GpuOcCheckBoxDesc2;

                    var GpuOcCheckBoxEleDesc = GpuOcCheckBoxEle.GetAttribute("Name");
                    var GpuOcCheckBoxEle1Desc = GpuOcCheckBoxEle1.GetAttribute("Name");
                    var GpuOcCheckBoxEle2Desc = GpuOcCheckBoxEle2.GetAttribute("Name");

                    var GpuOcCheckBoxDesc = "Enable GPU overclocking in Extreme performance mode.";
                    var GpuOcCheckBoxDesc1 = "Select to overclock your GPU memory clock by 140 MHz, a deemed “stable” sweet spot. The gaming performance and frame rate may increase by 10%-30%.";
                    var GpuOcCheckBoxDesc2 = "Note: The improvements in performance and frame rate may vary according to different games/apps and other factors. The power consumption, computer surface temperature, and fan noise might also increase accordingly. Lenovo does not guarantee the stability and performance improvement when overclocking is enabled.";

                    Assert.AreEqual(GpuOcCheckBoxEleDesc, GpuOcCheckBoxDesc, "GPU OC description is wrong!");
                    Assert.AreEqual(GpuOcCheckBoxEle1Desc, GpuOcCheckBoxDesc1, "The first paragraph below GPU OC check box is wrong!");
                    Assert.AreEqual(GpuOcCheckBoxEle2Desc, GpuOcCheckBoxDesc2, "The first paragraph below GPU OC check box is wrong!");
                    break;

            }

        }

    }
}
