using AventStack.ExtentReports.Gherkin.Model;
using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_ConnectedHomeSecurity
{
    [Binding]
    public class VAN8579_CreateBuyNowRenewoptionadminonnewCHSandingpageSteps
    {
        private static IWebDriver _webSession = null;
        private InformationalWebDriver _webDriver;
        private CHSWebEnvPage _CHSWebEnvPage;
        private CHSMarketingPage _CHSMarketingPage;
        private CHSAdminPage _CHSAdminPage;

        public VAN8579_CreateBuyNowRenewoptionadminonnewCHSandingpageSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Initialization Chs Data For ""(.*)""")]
        public void GivenInitializationChsDataFor(string p0)
        {
            if (p0.ToLower() == "in trial")
            {
                var account = CHSWebEnvPage.GetAccount("Trial1");
                _webSession = CHSWebEnvPage.LoginLenovoWeb((account[0]), account[1]);
                Thread.Sleep(5000);
                CHSHelper.ChangeInTrialPeriod(_webSession);
            }
            else if (p0.ToLower() == "out trial")
            {
                var account = CHSWebEnvPage.GetAccount("Trial1");
                _webSession = CHSWebEnvPage.LoginLenovoWeb((account[0]), account[1]);
                Thread.Sleep(5000);
                CHSHelper.ChangeOutTrialPeriod(_webSession);
            }
            else if (p0.ToLower() == "in sub over 30days")
            {
                var account = CHSWebEnvPage.GetAccount("Subscription1");
                _webSession = CHSWebEnvPage.LoginLenovoWeb((account[0]), account[1]);
                Thread.Sleep(5000);
                CHSHelper.ChangeSubscriptionOver30Days(_webSession);
            }
            else if (p0.ToLower() == "in sub less 30days")
            {
                var account = CHSWebEnvPage.GetAccount("Subscription1");
                _webSession = CHSWebEnvPage.LoginLenovoWeb((account[0]), account[1]);
                Thread.Sleep(5000);
                CHSHelper.ChangeSubscriptionLess30Days(_webSession);
            }
            _webSession.Quit();
        }

        [Then(@"Check The Part of ""(.*)""")]
        public void ThenCheckThePartOf(string p0)
        {
            switch (p0.ToLower())
            {
                case "account":
                    _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
                    Assert.IsNull(_CHSAdminPage.CHSBuyNow, "The CHSBuyNow btn should not found");
                    Assert.IsNotNull(_CHSAdminPage.CHSLenovoIDText, "The LenovoIDText not found");
                    break;
                case "over30days":
                    _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
                    Assert.IsNull(_CHSAdminPage.CHSExtendbtn, "The CHSExtend btn should not found");
                    Assert.IsNotNull(_CHSAdminPage.CHSLenovoIDText, "The LenovoIDText not found");
                    Assert.IsNotNull(_CHSAdminPage.CHSNewOver30DaysDescri, "The CHSNewOver30DaysText not found");
                    Assert.IsNotNull(_CHSAdminPage.CHSOver30DaysTitle, "The CHSOver30DaysTitleText not found");
                    break;
                case "outtrial":
                    _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
                    Assert.IsNull(_CHSAdminPage.CHSBuyNow, "The CHSBuyNow btn should not found");
                    Assert.IsNotNull(_CHSAdminPage.CHSNewOutTrialText, "The CHSOutTrialText not found");
                    break;
                case "less30days":
                    _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
                    Assert.IsNull(_CHSAdminPage.CHSExtendbtn, "The CHSExtend btn should not found");
                    Assert.IsNotNull(_CHSAdminPage.CHSLess30DaysRemain, "The RemainDays not true");
                    Assert.IsNotNull(_CHSAdminPage.CHSNewOver30DaysDescri, "The CHSNewOver30DaysText not found");
                    Assert.IsNotNull(_CHSAdminPage.CHSOver30DaysTitle, "The CHSOver30DaysTitleText not found");
                    break;
                case "inputcode":
                    _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
                    Assert.IsNotNull(_CHSMarketingPage.CHSInput, "The CHSinput btn not found");
                    Assert.IsNotNull(_CHSMarketingPage.JoinFamilyConnect, "The JoinFamilyConnect not found");
                    break;
                case "errorinputcode":
                    _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
                    Assert.IsNotNull(_CHSMarketingPage.CHSInput, "The CHSinput btn not found");
                    _CHSMarketingPage.CHSInput.SendKeys("AAAAAABBBBB");
                    Thread.Sleep(1000);
                    Assert.IsNotNull(_CHSMarketingPage.JoinFamilyConnect, "The JoinFamilyConnect not found");
                    _CHSMarketingPage.JoinFamilyConnect.Click();
                    Assert.IsNotNull(_CHSMarketingPage.ErrorInput, "The Error text not found");
                    break;
                case "successfully login message":
                    _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
                    Assert.IsNotNull(_CHSMarketingPage.JoinSuccessfulText, "The JoinSuccessfulText not found");
                    Assert.IsNull(_CHSMarketingPage.CHSInput, "The CHSInput btn not found");
                    break;
                case "seconduser":
                    _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
                    Assert.IsNotNull(_CHSAdminPage.CHSFamilyMember, "The FamilyMember text not found");
                    Assert.IsNotNull(_CHSAdminPage.CHSDisconnectBtn, "The CHSDisconnectBtn not found");
                    break;
                case "disconnectprompt":
                    _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
                    Assert.IsNotNull(_CHSAdminPage.CHSDisconnectCancelBtn, "The CHSDisconnectCancelBtn not found");
                    Assert.IsNotNull(_CHSAdminPage.CHSDisconnectPromotCloseBtn, "The CHSDisconnectPromotCloseBtn not found");
                    Assert.IsNotNull(_CHSAdminPage.CHSDisconnectPromptBtn, "The CHSDisconnectBtn not found");
                    break;
                case "go to dashboard":
                    _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
                    Assert.IsNotNull(_CHSMarketingPage.GoToDashboardButton, "The go to dashboard button not found");
                    break;
                case "internetaccess":
                    IntPtr mainHwnd = IntPtr.Zero;
                    for (int i = 0; i < 10; i++)
                    {
                        mainHwnd = UnManagedAPI.FindWindow(null, "Network Connections");
                        if (mainHwnd != IntPtr.Zero)
                        {
                            break;
                        }
                    }
                    Assert.IsTrue(mainHwnd != IntPtr.Zero);
                    break;

            }
        }
        [Then(@"CHS Webpage Open In Chrome")]
        [Then(@"Purchase Page In Chrome")]
        public void ThenPurchasePageInChrome()
        {
            Process[] processes = Process.GetProcessesByName("chrome");
            Assert.IsTrue(processes.Length > 0);
        }

        [Given(@"Remove ""(.*)"" Account from Web Console")]
        public void GivenRemoveAccountFromWebConsole(string p0)
        {
            switch (p0.ToLower())
            {
                case "subscription":
                    CHSWebEnvPage.RemoveDevice("Subscription1");
                    break;
                case "trialsecond":
                    CHSWebEnvPage.RemoveDevice("Trial2", true);
                    break;
            }
        }

        [Then(@"Will Pop up Offline Message")]
        public void ThenWillPopUpOfflineMessage()
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            Assert.IsNotNull(_CHSAdminPage.CHSOfflineDialog, "The CHSOfflineDialog not found");
        }

        [Given(@"OOBE CHS")]
        public void GivenOOBECHS()
        {
            _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
            _CHSMarketingPage.OObeCHS();
        }


    }
}
