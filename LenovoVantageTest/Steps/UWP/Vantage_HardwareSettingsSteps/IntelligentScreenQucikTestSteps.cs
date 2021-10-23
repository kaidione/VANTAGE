using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Windows.Automation;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Pages.Helper.DesktopPowerManagementHelper;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class IntelligentScreenQucikTestSteps : SettingsBase
    {
        private HSSmartAssistPage _hSSmartAssistPage;
        private InformationalWebDriver _webDriver;
        private HSQuickSettingsPage _hSQuickSettingsPage;

        public IntelligentScreenQucikTestSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
            _hSSmartAssistPage = new HSSmartAssistPage(_webDriver.Session);
        }

        [AfterFeature("IntelligentScreenLe")]
        [AfterFeature("CheckHPDCheckbox")]
        [AfterFeature("IntelligentScreenOnly")]
        [AfterFeature("CheckHPDCheckboxDC")]
        public static void AfterFeatureScreen()
        {
            PowerSettingsOptionsControl(PowerSettingsOptions.DisplayDC, 0);
            PowerSettingsOptionsControl(PowerSettingsOptions.DisplayAC, 0);
        }

        [Given(@"Click Intelligent Screen Link")]
        public void GivenClickIntelligentScreenLink()
        {
            _hSSmartAssistPage.IntelligentScreenlink.Click();
        }

        [Given(@"Select DisplayDC to (.*) minutes")]
        public void GivenSelectDisplayDCToMinutes(int setTime)
        {
            PowerSettingsOptionsControl(PowerSettingsOptions.DisplayDC, setTime);
        }

        [Given(@"Select DisplayAC to (.*) minutes")]
        public void GivenSelectDisplayACToMinutes(int setTime)
        {
            PowerSettingsOptionsControl(PowerSettingsOptions.DisplayAC, setTime);
        }


        [When(@"Turn (.*) the Auto Screen Off toggle")]
        public void WhenTurnTheAutoScreenOffToggle(string toggleStatus)
        {
            ToggleState tarToggle = _hSSmartAssistPage.GetCheckBoxStatus(_hSSmartAssistPage.AutoScreenOffToggle);
            if (toggleStatus.ToLower().Equals("off"))
            {
                if (tarToggle == ToggleState.On)
                {
                    ClickVantageElements(_hSSmartAssistPage.AutoScreenOffToggle);
                }
            }
            else
            {
                if (tarToggle == ToggleState.Off)
                {
                    ClickVantageElements(_hSSmartAssistPage.AutoScreenOffToggle);
                }
            }
        }

        [Then(@"The AutoScreenOff Toggle is (.*)")]
        public void ThenTheAutoScreenOffToggleState(string state)
        {
            ToggleState tarToggle = _hSSmartAssistPage.GetCheckBoxStatus(_hSSmartAssistPage.AutoScreenOffToggle);
            switch (state.ToLower())
            {
                case "enabled":
                    Assert.IsTrue(_hSSmartAssistPage.AutoScreenOffToggle.Enabled);
                    break;
                case "disabled":
                    Assert.IsFalse(_hSSmartAssistPage.AutoScreenOffToggle.Enabled);
                    break;
                case "on":
                    Assert.AreEqual(ToggleState.On, tarToggle);
                    break;
                case "off":
                    Assert.AreEqual(ToggleState.Off, tarToggle);
                    break;
                default:
                    break;
            }
        }

        [Then(@"There is no AutoScreenNever tip")]
        public void ThenThereIsNoAutoScreenNeverTip()
        {
            Assert.IsNull(_hSSmartAssistPage.AutoScreenOffNeverTip);
        }

        [Then(@"There has a AutoScreenNever tip")]
        public void ThenThereHasAAutoScreenNeverTip()
        {
            Assert.IsNotNull(_hSSmartAssistPage.AutoScreenOffNeverTipHD);
        }

        [Then(@"There Is No Intelligent Screen Function")]
        public void ThenThereIsNoIntelligentScreenFunction()
        {
            Assert.IsNull(_hSSmartAssistPage.DisplayintelligentScreen);
        }

        [Then(@"Display a collapse button on the right")]
        public void ThenDisplayACollapseButtonOnTheRight()
        {
            Assert.IsNotNull(_hSSmartAssistPage.DisplayCollapse);
        }

        [Then(@"Display Auto screen off and Keep my display")]
        public void ThenDisplayAutoScreenOffAndKeepMyDisplay()
        {
            Assert.IsNotNull(_hSSmartAssistPage.DisplayintelligentScreen, "Intelligent screen' Is Not Found");
            Assert.IsTrue(_hSSmartAssistPage.ShowTextbox(_hSSmartAssistPage.DisplayintelligentScreen).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.SmartAssist.DisplayintelligentScreentext").ToString()));
            Assert.IsNotNull(_hSSmartAssistPage.DisplayAutSscreenOff, "Auto screen off' Is Not Found");
            Assert.IsTrue(_hSSmartAssistPage.ShowTextbox(_hSSmartAssistPage.DisplayAutSscreenOff).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.SmartAssist.DisplayAutSscreenOfftext").ToString()));
            Assert.IsNotNull(_hSSmartAssistPage.DisplayKeepMyDisplay, "Keep my Display' Is Not Found");
            Assert.IsTrue(_hSSmartAssistPage.ShowTextbox(_hSSmartAssistPage.DisplayKeepMyDisplay).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.SmartAssist.DisplayKeepMyDisplaytext").ToString()));
        }
        [Then(@"Shows the context description as Interlligent")]
        public void ThenShowsTheContextDescriptionAsFollowing()
        {
            Assert.IsNotNull(_hSSmartAssistPage.DisplayContextDescription, "DisplayContextDescription is null");
            Assert.IsTrue(_hSSmartAssistPage.ShowTextbox(_hSSmartAssistPage.DisplayContextDescription).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.SmartAssist.DisplayContextDescriptiontext").ToString()));
        }

        [Given(@"Turn (.*) AutoScreenOff btn")]
        public void GivenTurnOffAutoScreenOffBtn(ToggleState state)
        {
            _hSSmartAssistPage = new HSSmartAssistPage(_webDriver.Session);
            ScrollScreenToWindowsElement(_webDriver.Session, _hSSmartAssistPage.DisplayCheckbox);
            bool toolbar = _hSSmartAssistPage.SetCheckBoxStatus(_hSSmartAssistPage.DisplayCheckbox, state);
            Assert.IsTrue(toolbar);
        }

        [Then(@"Shows the context description as Autoscreenoff")]
        public void ThenShowsTheContextDescriptionAsAutoscreenoff()
        {
            Assert.IsNotNull(_hSSmartAssistPage.DisplayAutoScreenOfCaption);
            Assert.IsTrue(_hSSmartAssistPage.ShowTextbox(_hSSmartAssistPage.DisplayAutoScreenOfCaption).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.SmartAssist.DisplayAutoScreenOfCaptiontext").ToString()));

        }

        [Then(@"(.*) the context description as Autoscreenoff red context")]
        public void ThenShowsTheContextDescriptionAsAutoscreenoffredcontext(string state)
        {
            if (state.ToLower().Equals("Shows"))
            {
                Assert.IsNotNull(_hSSmartAssistPage.DisplayContextDescriptionred, "DisplayContextDescriptionred is null");
            }
            else if (state.ToLower().Equals("Noshows"))
            {
                Assert.IsNull(_hSSmartAssistPage.DisplayContextDescriptionred, "DisplayContextDescriptionred is value");
            }
        }
        [Then(@"Check keep my display (.*)")]
        public void ThenCheckKeepMyDisplayDisplaySlider(string type)
        {
            switch (type)
            {
                case "Caption":
                    Assert.IsNotNull(_hSSmartAssistPage.DisplayKeepMyDisplayCaption, "KeepMyDisplayCaption is null");
                    Assert.IsTrue(_hSSmartAssistPage.ShowTextbox(_hSSmartAssistPage.DisplayKeepMyDisplayCaption).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.SmartAssist.DisplayKeepMyDisplayCaptiontext").ToString()));
                    break;
                case "Slidertitle":
                    Assert.IsNotNull(_hSSmartAssistPage.DisplaySlidertitle, "DisplaySlidertitle is null");
                    Assert.IsTrue(_hSSmartAssistPage.ShowTextbox(_hSSmartAssistPage.DisplaySlidertitle).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.SmartAssist.DisplaySlidertitletext").ToString()));
                    break;
                case "DisplaySlider":
                    Assert.IsNotNull(_hSSmartAssistPage.DisplaySlider, "DisplaySlider is null");
                    break;
                case "MinMinutes":
                    Assert.IsNotNull(_hSSmartAssistPage.MinMinutes, "MinMinutes is null");
                    Assert.IsTrue(_hSSmartAssistPage.ShowTextbox(_hSSmartAssistPage.MinMinutes).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.SmartAssist.MinMinutestext").ToString()));
                    break;
                case "MaxMinutes":
                    Assert.IsNotNull(_hSSmartAssistPage.MaxMinutes, "MaxMinutes is null");
                    Assert.IsTrue(_hSSmartAssistPage.ShowTextbox(_hSSmartAssistPage.MaxMinutes).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.SmartAssist.MaxMinutestext").ToString()));
                    break;
            }
        }
        [Given(@"Turn (.*) Keepmydisplay btn")]
        public void GivenTurnOnKeepmydisplayBtn(ToggleState state)
        {
            _hSSmartAssistPage = new HSSmartAssistPage(_webDriver.Session);
            ScrollScreenToWindowsElement(_webDriver.Session, _hSSmartAssistPage.Keepmydisplaybtn);
            bool toolbar = _hSSmartAssistPage.SetCheckBoxStatus(_hSSmartAssistPage.Keepmydisplaybtn, state);
            Assert.IsTrue(toolbar);
        }
    }
}

