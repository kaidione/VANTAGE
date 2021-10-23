using LenovoVantageTest.Pages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using TangramTest.Utility;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingReskinWiFiSecuritySubpageSteps
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;

        public GamingReskinWiFiSecuritySubpageSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"WiFi Security subpage is opened")]
        public void ThenWiFiSecuritySubpageIsOpened()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.WiFiSecurityTitle);
        }

        [Then(@"The Security Advisor widget no display")]
        public void ThenTheSecurityAdvisorWidgetNoDisplay()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.WiFiSecurityAdvisor);
        }

        [Then(@"The WiFi Security toggle status within subpage '(.*)'")]
        public void ThenTheWiFiSecurityToggleStatusWithinSubpage(string _status)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            IntelligentCoolingBaseHelper helper = new IntelligentCoolingBaseHelper();
            string toggle = helper.GetAttributesByPageSource(null, "ToggleState", _webDriver.Session, "//*[@AutomationId='sa-ws-switch-input']");
            switch (_status.ToLower())
            {
                case "on":
                    Assert.IsTrue(toggle == "On", "The wifi toggle isn't on");
                    break;
                case "off":
                    Assert.IsTrue(toggle == "Off", "The wifi toggle isn't off");
                    break;
                default:
                    Assert.Fail("The ThenTheWiFiSecurityToggleStatusWithinSubpage not run");
                    break;
            }
        }

        [When(@"The user click WiFi Security back button")]
        public void WhenTheUserClickWiFiSecurityBackButton()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.WiFiSecurityBackButton);
            _nerveCenterPages.WiFiSecurityBackButton.Click();
        }

        [When(@"Click the WiFi Security '(.*)' toggle within subpage")]
        public void WhenClickTheWiFiSecurityToggle(string ToggleStatus)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            _nerveCenterPages.WiFiSecurityToggle.Click();
        }

        [When(@"Set the WiFi Security '(.*)' toggle within homepage")]
        public void WhenClickTheWiFiSecurityToggleWithinHomepage(string wifiToggleStatus)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.QuickSettingsWiFiSecurityToggleMode);
            string toggleText = _nerveCenterPages.ShowTextbox(_nerveCenterPages.QuickSettingsWiFiSecurityToggleMode).ToLower().Trim();
            if (!toggleText.Contains(wifiToggleStatus.ToLower()))
            {
                _nerveCenterPages.QuickSettingsWiFiSecurityToggleMode.Click();
            }
        }

        [Given(@"Disable or Enable Vantage Location Permission '(.*)'")]
        public void GivenDisableOrEnableVantageLocationPermission(string action)
        {
            Process.Start("ms-settings:privacy-location");
            Thread.Sleep(3000);
            UIAutomationControl control = new UIAutomationControl();
            var toggle = control.FindElementsByClasssNameAndAutomationIDCollection(AutomationElement.RootElement, "E046963F.LenovoCompanion_k1h2ywk1493x8_ToggleSwitch", "ToggleSwitch");
            switch (action)
            {
                case "Disable":
                    control.SetOrCheckToggleStatusByAutomationElement(toggle[0], true, ToggleState.Off);
                    Assert.IsTrue(control.SetOrCheckToggleStatusByAutomationElement(toggle[0], false, ToggleState.Off), "Disable Vantage Location Permission failed");
                    break;
                case "Enable":
                    control.SetOrCheckToggleStatusByAutomationElement(toggle[0], true, ToggleState.On);
                    Assert.IsTrue(control.SetOrCheckToggleStatusByAutomationElement(toggle[0], false, ToggleState.On), "Enable Vantage Location Permission failed");
                    break;
                default:
                    Assert.Fail("The GivenDisableOrEnableVantageLocationPermission not run");
                    break;
            }
            Common.KillProcess("SystemSettings", true);

        }

        [Then(@"The Location Dialog Display")]
        public void ThenTheLocationDialogDisplay()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.WiFiSecurityLocationDialog);
            Assert.IsNotNull(_nerveCenterPages.WiFiSecurityLocationDialogTitle);
            Assert.IsNotNull(_nerveCenterPages.WiFiSecurityLocationDialogCloseButton);
            Assert.IsNotNull(_nerveCenterPages.WiFiSecurityLocationDialogAgreeButton);
            Assert.IsNotNull(_nerveCenterPages.WiFiSecurityLocationDialogCancelButton);
        }

    }

}

