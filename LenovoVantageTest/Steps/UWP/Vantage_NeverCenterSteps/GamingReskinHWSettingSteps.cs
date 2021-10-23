using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingReskinHWSettingSteps
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;
        public GamingReskinHWSettingSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [When(@"Click the Power icon")]
        public void WhenClickThePowerIcon()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SystemToolsPower, "the system tools power icon not found");
            _nerveCenterPages.SystemToolsPower.Click();
            VantageCommonHelper.MoveDown();
            Thread.Sleep(2000);
        }

        [When(@"Check Open Power page")]
        public void WhenCheckOpenPowerPage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.MyDeviceSettingTitle);
            Assert.IsNotNull(_nerveCenterPages.PowerLevel2Tiltle);
            Assert.IsNotNull(_nerveCenterPages.PowerJumptToSettingsTitle);
            Thread.Sleep(2000);
        }

        [When(@"Click Audio Label")]
        public void WhenClickAudioLabel()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.AudioLabelTitle);
            _nerveCenterPages.AudioLabelTitle.Click();
            Thread.Sleep(2000);
        }

        [When(@"Check Open Audio page")]
        public void WhenCheckOpenAudioPage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.AudioLevel2Tiltle);
            Assert.IsNotNull(_nerveCenterPages.AudioJumptToSettingsTitle);
        }

        [When(@"Click Display&Camera Label")]
        public void WhenClickDisplayCameraLabel()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.MediaLabelTitle);
            _nerveCenterPages.MediaLabelTitle.Click();
            Thread.Sleep(2000);
        }

        [When(@"Check Open Display&Camera page")]
        public void WhenCheckOpenDisplayCameraPage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.MediaLevel2Tiltle);
            Assert.IsNotNull(_nerveCenterPages.MediaJumptToSettingsTitle);
        }

        [When(@"Click Input Label")]
        public void WhenClickInputLabel()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.InputLabelTitle);
            _nerveCenterPages.InputLabelTitle.Click();
            Thread.Sleep(2000);
        }

        [When(@"Check Open Input page")]
        public void WhenCheckOpenInputPage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.InputLevel2Tiltle);
            Assert.IsNotNull(_nerveCenterPages.InputDescription);
        }

        [When(@"Click HelpContent First Question")]
        public void WhenClickHelpContentFirstQuestion()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.QA1Content);
            _nerveCenterPages.QA1Content.Click();
            Thread.Sleep(2000);
        }

        [When(@"Click HelpContent Second Question")]
        public void WhenClickHelpContentSecondQuestion()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.QA2Content);
            _nerveCenterPages.QA2Content.Click();
            Thread.Sleep(2000);
        }

        [When(@"Click HelpContent Third Question")]
        public void WhenClickHelpContentThirdQuestion()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.QA3Content);
            _nerveCenterPages.QA3Content.Click();
            Thread.Sleep(2000);
        }

        [When(@"Click HelpContent Fourth Question")]
        public void WhenClickHelpContentFourthQuestion()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.QA4Content);
            _nerveCenterPages.QA4Content.Click();
            Thread.Sleep(2000);
        }

        [When(@"Click HelpContent Fifth Question")]
        public void WhenClickHelpContentFifthQuestion()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.QA5Content);
            _nerveCenterPages.QA5Content.Click();
            Thread.Sleep(2000);
        }

        [When(@"Click Back link")]
        public void WhenClickBackLink()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.PowerBackLink);
            _nerveCenterPages.PowerBackLink.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Back to Homepage")]
        public void ThenBackToHomepage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingLegionEdge);
            Assert.IsNotNull(_nerveCenterPages.GamingSystemStatus);
            Thread.Sleep(2000);
        }

        [When(@"Click Y logo")]
        public void WhenClickYLogo()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.YLogo);
            _nerveCenterPages.YLogo.Click();
            Thread.Sleep(2000);
        }

        [When(@"Click the Media icon")]
        public void WhenClickTheMediaIcon()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SystemToolsMedia);
            _nerveCenterPages.SystemToolsMedia.Click();
            Thread.Sleep(2000);
        }

        [When(@"PageDown")]
        public void WhenPageDown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            SendKeys.SendWait("{PgDn}");
        }

        [When(@"Click Power Label")]
        public void WhenClickPowerLabel()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.PowerLabelTitle);
            _nerveCenterPages.PowerLabelTitle.Click();
            Thread.Sleep(2000);
        }

        [Then(@"Back to Power Page")]
        public void ThenBackToPowerPage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.MyDeviceSettingTitle);
            Assert.IsNotNull(_nerveCenterPages.PowerLevel2Tiltle);
            Assert.IsNotNull(_nerveCenterPages.PowerJumptToSettingsTitle);
            Thread.Sleep(2000);
        }
    }
}
