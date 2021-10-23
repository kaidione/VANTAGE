using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;


namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public sealed class GamingAppSettingsPreferencePageReskinDefinition
    {

        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;

        public GamingAppSettingsPreferencePageReskinDefinition(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [When(@"Hover or Click L drop down menu")]
        public void WhenHoverOrClickLDropDownMenu()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingLDropDown);
            _nerveCenterPages.GamingLDropDown.Click();
        }

        [When(@"Check Preference setting link")]
        public void WhenCheckPreferenceSettingLink()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.PreferenceSettingLink);
        }

        [Then(@"The L drop down menu list is expanded")]
        public void ThenTheLDrop_DownListIsExpanded()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LenovoMigrationAssistant);
            Assert.IsNotNull(_nerveCenterPages.PreferenceSettingLink);
        }

        [Then(@"The Preference settings link is second from the top")]
        public void ThenThePreferenceSettingsLinkIsSecondFromTheTop()
        {
            string gfPosition = VantageCommonHelper.GetAttributeValue(_nerveCenterPages.GiveFeedbackLink, "ClickablePoint");
            string psPosition = VantageCommonHelper.GetAttributeValue(_nerveCenterPages.PreferenceSettingLink, "ClickablePoint");
            string lmaPosition = VantageCommonHelper.GetAttributeValue(_nerveCenterPages.LenovoMigrationAssistant, "ClickablePoint");
            Assert.Less(Convert.ToInt32(lmaPosition.Split(',')[1]), Convert.ToInt32(psPosition.Split(',')[1]));
            Assert.Less(Convert.ToInt32(psPosition.Split(',')[1]), Convert.ToInt32(gfPosition.Split(',')[1]));
        }

        [Given(@"The L drop-down list is expanded")]
        public void GivenTheLDrop_DownListIsExpanded()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingLDropDown);
            _nerveCenterPages.GamingLDropDown.Click();
            Assert.IsNotNull(_nerveCenterPages.LenovoMigrationAssistant);
            Assert.IsNotNull(_nerveCenterPages.PreferenceSettingLink);
        }

        [When(@"Click the Preference settings link")]
        public void WhenClickThePreferenceSettingsLink()
        {
            Assert.IsNotNull(_nerveCenterPages.PreferenceSettingLink);
            _nerveCenterPages.PreferenceSettingLink.Click();
        }

        [Then(@"The Preference settings page is opened")]
        public void ThenThePreferenceSettingsPageIsOpened()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.PreferenceSettingsPageTitle);
            Assert.IsNotNull(_nerveCenterPages.PreferenceSettingsPageBackBtn);
            Thread.Sleep(500);
        }

        [When(@"Click BACK link")]
        public void WhenClickBACKLink()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.PreferenceSettingsPageBackBtn);
            _nerveCenterPages.PreferenceSettingsPageBackBtn.Click();
        }

        [Then(@"Check the page go back to homepage")]
        public void ThenCheckThePageGoBackToHomepage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingSystemStatus);
            Assert.IsNotNull(_nerveCenterPages.GamingSystemTools);
            Assert.IsNotNull(_nerveCenterPages.GamingLegionEdge);
        }

        [When(@"Click Y link")]
        public void WhenClickYLink()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.YLogo);
            _nerveCenterPages.YLogo.Click();
        }

        [When(@"Click Device link")]
        public void WhenClickDeviceLink()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu);
            _nerveCenterPages.GamingDeviceMenu.Click();
            Thread.Sleep(2000);
        }
    }
}
