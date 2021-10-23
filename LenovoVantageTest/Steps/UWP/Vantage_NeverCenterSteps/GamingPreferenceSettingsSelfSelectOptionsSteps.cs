using LenovoVantageTest.Commands;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingPreferenceSettingsSelfSelectOptionsSteps
    {

        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;

        public GamingPreferenceSettingsSelfSelectOptionsSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"How will you be using your device and Please tell us about your interests should be found")]
        public void ThenHowWillYouBeUsingYourDeviceAndPleaseTellUsAboutYourInterestsShouldBeFound()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            string status = _nerveCenterPages.PreferenceSettingsUserProfileCollapse.GetAttribute("Name").ToLower();
            if (status.Contains("expand"))
            {
                _nerveCenterPages.PreferenceSettingsUserProfileCollapse.Click();
            }
            Assert.IsNotNull(_nerveCenterPages.InterestTitle);
            Assert.IsNotNull(_nerveCenterPages.GamesCheckbox);
            Assert.IsNotNull(_nerveCenterPages.NewsCheckbox);
            Assert.IsNotNull(_nerveCenterPages.EntertainmentCheckbox);
            Assert.IsNotNull(_nerveCenterPages.TechnologyChckebox);
            Assert.IsNotNull(_nerveCenterPages.SportsCheckbox);
            Assert.IsNotNull(_nerveCenterPages.ArtsCheckbox);
            Assert.IsNotNull(_nerveCenterPages.RegionalNewsChckebox);
            Assert.IsNotNull(_nerveCenterPages.PoliticsCheckbox);
            Assert.IsNotNull(_nerveCenterPages.MusicCheckbox);
            Assert.IsNotNull(_nerveCenterPages.ScienceChckebox);
            Assert.IsNotNull(_nerveCenterPages.InterestSaveBtn);
            Assert.IsNull(_nerveCenterPages.HowWillYouBeUsingYourDeviceItem);
        }

        [When(@"Disconnect Internet")]
        public void WhenDisconnectInternet()
        {
            CmdCommands.DisableWiFi();
        }

        [When(@"Connect Internet")]
        public void WhenConnectInternet()
        {
            CmdCommands.EnableWiFi();
        }
        [AfterFeature("EnableInternet")]
        public static void EnableInternet()
        {
            CmdCommands.EnableWiFi();
        }
    }
}
