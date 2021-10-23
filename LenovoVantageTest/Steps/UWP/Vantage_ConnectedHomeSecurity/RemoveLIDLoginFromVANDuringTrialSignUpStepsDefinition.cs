using AventStack.ExtentReports.Gherkin.Model;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Helper.VantageCommonHelper;

namespace LenovoVantageTest.Steps.UWP.Vantage_ConnectedHomeSecurity
{
    [Binding]
    public class RemoveLIDLoginFromVANDuringTrialSignUp
    {
        private InformationalWebDriver _webDriver;
        private CHSMarketingPage _CHSMarketingPage;
        private CHSWebEnvPage _CHSWebEnvPage;
        private string _settingsLocationToggleID = "SystemSettings_CapabilityAccess_Location_UserGlobal_ToggleSwitch";

        public RemoveLIDLoginFromVANDuringTrialSignUp(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"Check the part of Start Trial")]
        public void ThenCheckpartofStartTrial()
        {
            _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
            Assert.IsNotNull(_CHSMarketingPage.StatTrialDescriptionTitle, "start trial text not correct");
            Assert.IsNotNull(_CHSMarketingPage.StatTrialDescriptionText, "start trial text not correct");
            Assert.IsNotNull(_CHSMarketingPage.CHSStartTrival, "The StartTrival btn not found");
        }

        [When(@"Click Start Trial")]
        public void WhenClickStartTrial()
        {
            _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
            Assert.IsNotNull(_CHSMarketingPage.CHSStartTrival, "The StartTrival btn not found");
            _CHSMarketingPage.CHSStartTrival.Click();
        }

        [Then(@"Check Location Dialog (.*)")]
        public void ThenCheckLocationDialog(string p0)
        {
            _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
            switch (p0)
            {
                case "exist":
                    Assert.IsNotNull(_CHSMarketingPage.StartTrialAllow, "location dialog not found");
                    Assert.IsNotNull(_CHSMarketingPage.StartTrialNotAllow, "location dialog not found");
                    break;
                case "not exist":
                    Assert.IsNull(_CHSMarketingPage.StartTrialAllow, "location dialog still exist");
                    Assert.IsNull(_CHSMarketingPage.StartTrialNotAllow, "location dialog still exist");
                    break;
            }
        }

        [Then(@"Click Allow Button")]
        public void ThenClickAllowButton()
        {
            _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
            Assert.IsNotNull(_CHSMarketingPage.StartTrialAllow, "location dialog not found");
            _CHSMarketingPage.StartTrialAllow.Click();
        }

        [Then(@"Check Location Settings Page")]
        public void ThenCheckLocationSettingsPage()
        {
            var settingsLocation = FindElementByIdIsEnabled(_settingsLocationToggleID);
            Assert.IsNotNull(settingsLocation, "location settings toggle not found");
        }

        [Then(@"Check Start Trial Prompt Box")]
        public void ThenCheckStartTrialPromptBox()
        {
            _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
            Assert.IsNotNull(_CHSMarketingPage.GoNowButton, "prompt box doesn't exist");
        }

        [Given(@"Sign in LID  and not Join CHS Account")]
        public void GivenSignInLIDAndNotJoinCHSAccount()
        {
            _CHSWebEnvPage = new CHSWebEnvPage(_webDriver.Session);
            var account = CHSWebEnvPage.GetAccount("Trial1");
            CHSWebEnvPage.LoginLenovoWeb((account[0]), account[1]);
        }

        [Then(@"Kill (.*) Process")]
        public void ThenKillAllChromeProcess(string processName)
        {
            CommandBase.RunCmd("taskkill /f /t /im " + processName);
        }

        [Then(@"Blue Bar Not Pop up Anymore")]
        public void ThenBueBarNotPopUpAnymore()
        {
            _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
            Assert.IsNull(_CHSMarketingPage.CHSBlueBarYes, "The CHSBlueBarYes btn still exist");
            Assert.IsNull(_CHSMarketingPage.CHSBlueBarNo, "The CHSBlueBarNo btn still exist");
        }

        [Given(@"Remove ""(.*)"" Faimily Number From ""(.*)""Account")]
        public void GivenRemoveFaimilyNumberFromAccount(string p0, string p1)
        {
            CHSWebEnvPage.RemoveFamilyNumber(p0, p1);
        }
    }

}
