using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using TechTalk.SpecFlow;

namespace LenovoVantageTest
{
    [Binding]
    public class VAN8585_ChangeWifiSecuritypageafterjoiningCHSaccountSteps
    {
        private InformationalWebDriver _webDriver;
        private WindowsDriver<WindowsElement> vantageSession;
        private bool needClick;
        private HSConnectedHomeSecurityPage _hSConnectedHomeSecurityPage;
        private static string _TrialAdminUserJoinCode = "KOJSMK";

        public VAN8585_ChangeWifiSecuritypageafterjoiningCHSaccountSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Go to Wifisecurity")]
        public void GivenInstallVantageAndGoToWifisecurity()
        {
            _hSConnectedHomeSecurityPage = new HSConnectedHomeSecurityPage(_webDriver.Session);
            _hSConnectedHomeSecurityPage.GoToWIFISecurity();
        }

        [Given(@"go to wifisecurity")]
        public void GivenGoToWifisecurity()
        {
            _hSConnectedHomeSecurityPage = new HSConnectedHomeSecurityPage(_webDriver.Session);
            _hSConnectedHomeSecurityPage.GoToWIFISecurity();
        }

        [Then(@"check the detail of the part of the CHS")]
        public void ThenCheckTheDetailOfThePartOfTheCHS()
        {
            _hSConnectedHomeSecurityPage = new HSConnectedHomeSecurityPage(_webDriver.Session);
            Assert.IsNotNull(_hSConnectedHomeSecurityPage.CHSBadge);
            Assert.IsNotNull(_hSConnectedHomeSecurityPage.VisitButton);
        }


        [When(@"click the button Visit")]
        public void WhenClickTheButtonVisit()
        {
            _hSConnectedHomeSecurityPage = new HSConnectedHomeSecurityPage(_webDriver.Session);
            _hSConnectedHomeSecurityPage.VisitButton?.Click();
        }

        [Then(@"go to CHS")]
        public void ThenGoToCHS()
        {
            _hSConnectedHomeSecurityPage = new HSConnectedHomeSecurityPage(_webDriver.Session);
            Assert.IsNotNull(_hSConnectedHomeSecurityPage.CHSTitle);
        }

        [Given(@"connected to CHS account and start trial")]
        public void GivenConnectedToCHSAccountAndStartTrial()
        {
            _hSConnectedHomeSecurityPage = new HSConnectedHomeSecurityPage(_webDriver.Session);
            _hSConnectedHomeSecurityPage.HSCHS?.Click();
            _hSConnectedHomeSecurityPage.JoinDevice(_TrialAdminUserJoinCode);
        }

        [Then(@"red badge will change to green badge protect")]
        public void ThenRedBadgeWillChangeToGreenBadgeProtect()
        {
            _hSConnectedHomeSecurityPage = new HSConnectedHomeSecurityPage(_webDriver.Session);
            _hSConnectedHomeSecurityPage.GoToWIFISecurity();
            Assert.IsNotNull(_hSConnectedHomeSecurityPage.CHSProtected, "The protected badge not found");
        }

        [Given(@"connected to CHS account and trial expired")]
        public void GivenConnectedToCHSAccountAndTrialExpired()
        {
            var account = CHSWebEnvPage.GetAccount("Trial1");
            CHSHelper.Login(account[0], account[1]);
            CHSHelper.ChangeOutTrialPeriod(CHSHelper._webSession);
        }

        [Then(@"it will show as red badge")]
        public void ThenItWillShowAsRedBadge()
        {
            _hSConnectedHomeSecurityPage = new HSConnectedHomeSecurityPage(_webDriver.Session);
            _hSConnectedHomeSecurityPage.GoToWIFISecurity();
            Assert.IsNotNull(_hSConnectedHomeSecurityPage.CHSBadge);
        }

        [Given(@"connected to CHS account and in subscription")]
        public void GivenConnectedToCHSAccountAndInSubscription()
        {
            _hSConnectedHomeSecurityPage = new HSConnectedHomeSecurityPage(_webDriver.Session);
            CHSHelper.Login("jinglongdingyue@163.com", "Jinglong123");
            _hSConnectedHomeSecurityPage.GoToWIFISecurity();
        }

    }
}
