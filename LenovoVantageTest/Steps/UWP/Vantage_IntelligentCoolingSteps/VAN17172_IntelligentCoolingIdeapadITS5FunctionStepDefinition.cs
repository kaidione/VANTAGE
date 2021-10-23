using AventStack.ExtentReports.Gherkin.Model;
using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;
using static LenovoVantageTest.Steps.UWP.IntelligentCooling.IntelligentCoolingBaseHelper;

namespace LenovoVantageTest.Steps.UWP.Vantage_IntelligentCoolingSteps
{
    [Binding]
    public sealed class IntelligentCoolingIdeapadITS5FunctionStepDefinition
    {
        private InformationalWebDriver _webDriver;
        private IntelligentCoolingPages _intelligentcoolingPages;
        private bool _isSupport = false;
        private string _tips = string.Empty;
        private string _itsRegeditPath = "SYSTEM\\CurrentControlSet\\Services\\LITSSVC\\LNBITS\\IC\\DATACOLLECTION";
        IntelligentCoolingBaseHelper _baseHelper = new IntelligentCoolingBaseHelper();

        public IntelligentCoolingIdeapadITS5FunctionStepDefinition(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
            this._isSupport = IntelligentCoolingResetExecution.isSupport;
        }

        [Then(@"The intelligent cooling mode is (.*) mode for ideapad ITS Five")]
        public void ThenTheIntelligentCoolingModeIsModeForIdeapadITSFive(string mode)
        {
            _isSupport = IntelligentCoolingResetExecution.isSupport;
            _tips = IntelligentCoolingResetExecution.tips;
            switch (mode.ToLower())
            {
                case "icm":
                    Assert.IsTrue(_baseHelper.VerifyCurrentModeIsIntelligentCoolingModeCN(_webDriver.Session), "The current mode is not ICM");
                    break;
                case "epm":
                    Assert.IsTrue(_baseHelper.VerifyCurrentModeIsExtremePerformanceModeCN(_webDriver.Session), "The current mode is not EPM");
                    break;
                case "bsm":
                    Assert.IsTrue(_baseHelper.VerifyCurrentModeIsBatterySavingModeCN(_webDriver.Session), "The current mode is not EPM");
                    break;
                default:
                    Assert.Warn("ThenTheIntelligentCoolingModeIsModeForIdeapadITSFive, not found spec text " + mode);
                    break;
            }
        }

        [Then(@"The ITS feature and Jump link should display on Power page")]
        public void ThenTheITSFeatureAndJumpLinkShouldDisplayOnPowerPage()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            Assert.IsNotNull(_intelligentcoolingPages.HSJumpToSmartSettings);
        }

        [Given(@"turn (.*) Dolby toggle")]
        public void GivenTurnOnDolbytoggle(string status)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var Dolbytogglestat = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.DolbyCheckBox);
            if (status.ToLower() == "on")
            {
                if (Dolbytogglestat == ToggleState.Off)
                {
                    _intelligentcoolingPages.DolbyCheckBox?.Click();
                }
            }
            else
            {
                if (Dolbytogglestat == ToggleState.On)
                {
                    _intelligentcoolingPages.DolbyCheckBox?.Click();
                }
            }
        }

        [Then(@"Dolby toggle is (.*)")]
        public void ThenDolbyToggleIsOff(string status)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var Dolbytogglestat = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.DolbyCheckBox);
            if (status.ToLower() == "off")
            {
                Assert.AreEqual(ToggleState.Off, Dolbytogglestat);
            }
            else
            {
                Assert.AreEqual(ToggleState.On, Dolbytogglestat);
            }
        }

        [Given(@"Turn (.*) auto-transition")]
        public void GivenTurnOffAuto_Transition(String Status)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            Assert.IsNotNull(_intelligentcoolingPages.IntelligentCoolingAutoTransition);
            if (Status.Equals("on"))
            {
                if (VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingAutoTransition) == ToggleState.Off)
                {
                    bool result = VantageCommonHelper.SwitchToggleStatus(_intelligentcoolingPages.IntelligentCoolingAutoTransition, ToggleState.On);
                    Assert.IsTrue(result);
                }
                Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingAutoTransition), ToggleState.On);
            }
            if (Status.Equals("off"))
            {
                if (VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingAutoTransition) == ToggleState.On)
                {
                    bool result = VantageCommonHelper.SwitchToggleStatus(_intelligentcoolingPages.IntelligentCoolingAutoTransition, ToggleState.Off);
                    Assert.IsTrue(result);
                }
                Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingAutoTransition), ToggleState.Off);
            }
        }

        [Then(@"ITS check-box off")]
        public void ThenITSCheck_BoxOff()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var togglestat = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingAutoTransition);
            Assert.AreEqual(ToggleState.Off, togglestat);
        }

        [Then(@"IBSM On")]
        public void ThenIBSMOn()
        {
            int currentPercent = VantageCommonHelper.GetCurrentBatteryPercent();
            if (currentPercent < 30)
            {
                var ITSMode = _baseHelper.GetIntelligentCoolingMetricDataInfo().Split('-')[0];
                Assert.AreEqual("IBSM", ITSMode);
            }
            else
            {
                throw new ValidationException("battery level not less than 30");
            }
        }

        [Then(@"IBSM off")]
        public void ThenIBSMOff()
        {
            int currentPercent = VantageCommonHelper.GetCurrentBatteryPercent();
            if (currentPercent < 30)
            {
                var ITSMode = _baseHelper.GetIntelligentCoolingMetricDataInfo().Split('-')[0];
                Assert.AreNotEqual("IBSM", ITSMode);
            }
            else
            {
                throw new ValidationException("battery level not less than 30");
            }
        }

        [Then(@"Vantage ITS (.*) On")]
        public void ThenVantageOn(string mode)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            ToggleState togglestate = 0;
            if (mode.ToLower() == "epm")
            {
                togglestate = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingPerformanceMode);

            }
            if (mode.ToLower() == "bsm")
            {
                togglestate = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingBatterySavingMode);

            }
            if (mode.ToLower() == "icm" || mode.ToLower() == "istd")
            {
                togglestate = VantageCommonHelper.GetToggleStatus(_intelligentcoolingPages.IntelligentCoolingIntelligentCoolingMode);
            }
            Assert.AreEqual(ToggleState.On, togglestate);
        }

        [Given(@"clear pop up count for ITS5")]
        public void GivenClearPopUpCountForITS5()
        {
            string PopupCountKey = @"hkcu\SOFTWARE\Lenovo\ImController\PluginData\IdeaNotebookPlugin\ITSAutoTransitionToastTimes";
            RegistryHelp.SetRegistryKeyValue(PopupCountKey, "0");
        }

        [Then(@"IEPM is (.*)")]
        public void ThenIEPMIs(string status)
        {
            var ITSMode = _baseHelper.GetIntelligentCoolingMetricDataInfo().Split('-')[0];
            if (status.ToLower() == "on")
            {
                Assert.AreEqual("IEPM", ITSMode);
            }
            else
            {
                Assert.AreNotEqual("IEPM", ITSMode);
            }
        }

        [Then(@"IEPM toast message popped-up")]
        public void ThenIEPMToastMessagePopped_Up()
        {
            string vantageAppId = string.Format("{0}_k1h2ywk1493x8!App", VantageConstContent.GetVantageUwpAppName());
            NotificationMessage notificationMessage = new NotificationMessage();
            notificationMessage.ShowToastMessage(vantageAppId);
        }

        [Then(@"IEPM toast donnot message popped-up")]
        public void ThenIEPMDonnotToastMessagePopped_Up()
        {
            string vantageAppId = string.Format("{0}_k1h2ywk1493x8!App", VantageConstContent.GetVantageUwpAppName());
            NotificationMessage notificationMessage = new NotificationMessage();
            notificationMessage.ShowToastMessage(vantageAppId);
        }

        [Given(@"click learn more")]
        public void GivenClickLearnMore()
        {
            Process.Start("ms-actioncenter:");
            RunCmd(@"C:\toasttools\ToastBtn1.exe", true);
            Thread.Sleep(10000);
            Common.KillProcess("ToastBtn1", true);
        }

        [Given(@"go to Action Center")]
        public void GivenGoToActionCenter()
        {
            Process.Start("ms-actioncenter:");
        }

        [Then(@"Vantage power page be launched")]
        public void ThenVantagePowerPageBeLaunched()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            Assert.IsNotNull(_intelligentcoolingPages.HSJumpToSmartSettings);
        }

        [Then(@"Intelligent Cooling toggle will be shown")]
        public void ThenIntelligentCoolingToggleWillBeShown()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            Assert.IsNotNull(_intelligentcoolingPages.IntelligentCoolingToggle);
        }

        [Then(@"Check default Collapse should be display")]
        public void ThenCheckDefaultCollapseShouldBeDisplay()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            Assert.IsNotNull(_intelligentcoolingPages.IntelligentCoolingCollapseExpand);
            Assert.AreEqual("Expanded", _intelligentcoolingPages.IntelligentCoolingCollapseExpand.GetAttribute("ExpandCollapse.ExpandCollapseState"));
        }

        [Given(@"Vantage BSM On")]
        public void GivenVantageBSMOn()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            _intelligentcoolingPages.IntelligentCoolingBatterySavingMode?.Click();
        }

        [Given(@"Go to Power Smart settings section")]
        public void GivenGoToPowerSmartSettingsSection()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            _intelligentcoolingPages.batterySettings_Title?.Click();
        }

        [Then(@"(.*) is Selected in Vantage IntelligentCooling")]
        public void ThenIsSelectedInVantageIntelligentCooling(string stateName)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            string itsStateElementId = string.Empty;
            _intelligentcoolingPages.IntellgentCoolingStateElement.TryGetValue(stateName, out itsStateElementId);
            WindowsElement itsStateElement = _intelligentcoolingPages.FindElementByTimes(_webDriver.Session, "AutomationId", itsStateElementId);
            Assert.IsTrue(itsStateElement.Selected);
        }

        [Given(@"Select (.*) Mode On in ITS5 toolbar")]
        public void GivenSelectModeOnInITSToolbar(string mode)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            _intelligentcoolingPages.SelectIntelligentCoolingModeOnInToolbar(mode);
        }

        [Given(@"change ITS mode to (.*) via Toolbar")]
        public void GivenChangeITSModeToICMViaToolbar(string mode)
        {
            var ITSstatus = SettingsBase.GetITSStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.ITSMode).ToString());
            var modePos = ITSToolbarLoop[ITSstatus];
            var desPos = ITSToolbarLoop[mode];
            int count = 0;
            if (ITSstatus == "Idea ITS")
            {
                return;
            }
            if (modePos <= desPos)
            {
                count = Math.Abs(desPos - modePos);
            }
            else
            {
                count = 3 - modePos + desPos;
            }
            for (int i = 0; i < count; i++)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(VantageConstContent.ToolBarAutoEnum.ITSMode).ToString());
            }
        }

        public static Dictionary<string, int> ITSToolbarLoop = new Dictionary<string, int>
        {
            {"Auto", 1},
            {"Perf", 2},
            {"C&Q",3},
            {"EPM", 1},
            {"ICM", 2},
            {"BSM", 3}
        };

        [Given(@"hover ITS icon in toolbar")]
        public void GivenHoverITSIconInToolbar()
        {
            Thread.Sleep(1000);
            AutomationElement ITSicon = VantageCommonHelper.FindElementByIdIsEnabled("1070");
            if (ITSicon != null)
            {
                var position = ITSicon.Current.BoundingRectangle;
                string x = ((int)position.Left + (int)position.Width / 2).ToString();
                string y = ((int)position.Top + (int)position.Height / 2).ToString();
                VantageCommonHelper.SetMouseClick(x, y, true);
                Thread.Sleep(1000);
            }
        }

    }
}
