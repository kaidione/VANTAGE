using AventStack.ExtentReports.Gherkin.Model;
using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_ConnectedHomeSecurity
{
    [Binding]
    public class VAN8572_Removeslides2And3FromCHSOnboardingTutorialSteps
    {
        private InformationalWebDriver _webDriver;
        private CHSWebEnvPage _CHSWebEnvPage;
        private CHSMarketingPage _CHSMarketingPage;
        private CHSAdminPage _CHSAdminPage;

        public VAN8572_Removeslides2And3FromCHSOnboardingTutorialSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"The Tutorial Will Pop up And Show Slide(.*)")]
        public void ThenTheTutorialWillPopUpAndShowSlide(string p0)
        {
            _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
            switch (p0.ToLower())
            {
                case "1":
                    Assert.IsNotNull(_CHSMarketingPage.CHSOobeNext, "The Slide1 next btn not found");
                    break;
                case "2":
                    Assert.IsNotNull(_CHSMarketingPage.CHSOobeNotNow, "The CHSOobeNotNow btn not found");
                    Assert.IsNotNull(_CHSMarketingPage.CHSOobeAllow, "The CHSOobeAllow btn not found");
                    break;
                case "3":
                    Assert.IsNotNull(_CHSMarketingPage.CHSoobeDone, "The CHSoobeDone btn not found");
                    break;
                case "bluebar":
                    Assert.IsNotNull(_CHSMarketingPage.CHSBlueBarYes, "The CHSBlueBarYes btn not found");
                    Assert.IsNotNull(_CHSMarketingPage.CHSBlueBarNo, "The CHSBlueBarNo btn not found");
                    break;
            }
        }

        [Then(@"Tutorial Will Not Pop up Anymore")]
        public void ThenTutorialWillNotPopUpAnymore()
        {
            _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
            Assert.IsNull(_CHSMarketingPage.CHSOobeNext, "The Slide1 next btn should not found");
        }

        [Then(@"Start trial Then ""(.*)"" Button Is Clickable")]
        public void ThenButtonIsClickable(string p0)
        {
            _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
            Assert.IsNotNull(_CHSMarketingPage.CHSStartTrival, "The StartTrival btn not found");
            _CHSMarketingPage.CHSStartTrival.Click();
            Assert.IsNotNull(_CHSMarketingPage.CHSOobeNotNow, "The location NotNow btn not found");
        }

        [When(@"Click CHS ""(.*)"" Button")]
        public void WhenClickCHSButton(string p0)
        {
            _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
            switch (p0.ToLower())
            {
                case "next":
                    Assert.IsNotNull(_CHSMarketingPage.CHSOobeNext, "The Slide1 next btn not found");
                    _CHSMarketingPage.CHSOobeNext.Click();
                    break;
                case "notnow":
                    Assert.IsNotNull(_CHSMarketingPage.CHSOobeNotNow, "The CHSOobeNotNow btn not found");
                    _CHSMarketingPage.CHSOobeNotNow.Click();
                    break;
                case "done":
                    Assert.IsNotNull(_CHSMarketingPage.CHSoobeDone, "The CHSoobeDone btn not found");
                    _CHSMarketingPage.CHSoobeDone.Click();
                    break;
                case "allow":
                    Assert.IsNotNull(_CHSMarketingPage.CHSOobeAllow, "The CHSOobeAllow btn not found");
                    _CHSMarketingPage.CHSOobeAllow.Click();
                    break;
                case "yes":
                    Assert.IsNotNull(_CHSMarketingPage.CHSBlueBarYes, "The CHSBlueBarYes btn not found");
                    _CHSMarketingPage.CHSBlueBarYes.Click();
                    break;
                case "no":
                    Assert.IsNotNull(_CHSMarketingPage.CHSBlueBarNo, "The CHSBlueBarNo btn not found");
                    _CHSMarketingPage.CHSBlueBarNo.Click();
                    break;
                case "join":
                    Assert.IsNotNull(_CHSMarketingPage.CHSJoin, "The CHSJoin btn not found");
                    _CHSMarketingPage.CHSJoin.Click();
                    break;
                case "buynow":
                    _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
                    Assert.IsNotNull(_CHSAdminPage.CHSBuyNow, "The CHSBuyNow btn not found");
                    _CHSAdminPage.CHSBuyNow.Click();
                    break;
                case "extendnow":
                    _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
                    Assert.IsNotNull(_CHSAdminPage.CHSExtendbtn, "The CHSExtend btn not found");
                    _CHSAdminPage.CHSExtendbtn.Click();
                    break;
                case "cancel":
                    Assert.IsNotNull(_CHSMarketingPage.CHSInputCancel, "The CHSInputCancel btn not found");
                    _CHSMarketingPage.CHSInputCancel.Click();
                    break;
                case "security":
                    Assert.IsNotNull(_CHSMarketingPage.CHSSecurity, "The CHSSecurity btn not found");
                    _CHSMarketingPage.CHSSecurity.Click();
                    break;
                case "start trial cancel":
                    Assert.IsNotNull(_CHSMarketingPage.CancelButton, "Cancel button not found");
                    _CHSMarketingPage.CancelButton.Click();
                    break;
                case "go now":
                    Assert.IsNotNull(_CHSMarketingPage.GoNowButton, "Go now button not found");
                    _CHSMarketingPage.GoNowButton.Click();
                    break;
                case "disconnect":
                    _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
                    Assert.IsNotNull(_CHSAdminPage.CHSDisconnectBtn, "Disconnect button not found");
                    _CHSAdminPage.CHSDisconnectBtn.Click();
                    break;
                case "disconnectno":
                    _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
                    Assert.IsNotNull(_CHSAdminPage.CHSDisconnectCancelBtn, "DisconnectClose button not found");
                    _CHSAdminPage.CHSDisconnectCancelBtn.Click();
                    break;
                case "disconnect x":
                    _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
                    Assert.IsNotNull(_CHSAdminPage.CHSDisconnectPromotCloseBtn, "DisconnectClose button not found");
                    _CHSAdminPage.CHSDisconnectPromotCloseBtn.Click();
                    break;
                case "go to dashboard":
                    Assert.IsNotNull(_CHSMarketingPage.GoToDashboardButton, "Go to dashboard not found");
                    _CHSMarketingPage.GoToDashboardButton.Click();
                    break;
                case "disconnectpromptbtn":
                    _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
                    Assert.IsNotNull(_CHSAdminPage.CHSDisconnectPromptBtn, "Disconnect button not found");
                    _CHSAdminPage.CHSDisconnectPromptBtn.Click();
                    break;
                case "offlinedialogcancel":
                    _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
                    Assert.IsNotNull(_CHSAdminPage.CHSOfflineDialog, "The CHSOfflineDialog not found");
                    _CHSAdminPage.CHSOfflineDialog.Click();
                    break;
                case "shenable":
                    _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
                    Assert.IsNotNull(_CHSAdminPage.CHSEnableLocation, "The CHSEnableLocation bth not found");
                    _CHSAdminPage.CHSEnableLocation.Click();
                    break;
            }
        }

        [Then(@"Setting Page Will Be Closed Return to CHS Marketing Page")]
        [Then(@"The Slide Will Be Closed And Return to CHS Marketing Page")]
        public void ThenTheSlideWillBeClosedAndReturnToCHSMarketingPage()
        {
            _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
            Assert.IsNotNull(_CHSMarketingPage.CHSStartTrival, "The StartTrival bth not found");
            Assert.IsNotNull(_CHSMarketingPage.CHSJoin, "The Join bth not found");
            Assert.IsNotNull(_CHSMarketingPage.CHSEnableLocation, "The EnableLocation bth not found");
        }

        [Given(@"Click OOBE Without blue bar")]
        public void GivenClickOOBEWithoutBlueBar()
        {
            var vantageSession = VantageCommonHelper.LaunchSystemUwp(VantageConstContent.VantageUwpAppid);
            VantageCommonHelper.OObeNetVantage30(vantageSession, false);
            _webDriver = new InformationalWebDriver(vantageSession, vantageSession);
        }


    }


}
