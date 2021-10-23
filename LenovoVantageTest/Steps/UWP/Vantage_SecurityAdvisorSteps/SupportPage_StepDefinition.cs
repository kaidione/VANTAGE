namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Commands;
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using System.Diagnostics;
    using System.Threading;
    using TechTalk.SpecFlow;


    [Binding]
    public sealed class SupportPage_StepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        public CmdCommands cmdCommands;

        //private readonly InformationalWebDriver webDriver;
        private Utility.InformationalWebDriver webDriver;

        private SupportPage supportPage;

        private InformationalWebDriver desktopSession;
        private BaseTestClass baseTestClass = new BaseTestClass();


        public SupportPage_StepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;

        }

        [StepDefinition(@"Go to Support page")]
        public void GivenGoToSupportPage()
        {
            supportPage = new SupportPage(webDriver.Session);
            supportPage.supportTab.Click();
        }

        [When(@"Click on User Guide Link")]
        public void WhenClickOnUserGuideLink()
        {
            supportPage = new SupportPage(webDriver.Session);
            supportPage.userGuideLink.Click();
            Thread.Sleep(5000);

        }
        [Then(@"Click BACK link on support page")]
        public void ThenClickBACKLinkOnSupportPage()
        {
            supportPage = new SupportPage(webDriver.Session);
            supportPage.backBtn.Click();
        }

        [Then(@"Verify it will opened Chrome Edge browser and load the target link User Guide")]
        public void ThenVerifyItWillOpenedChromeEdgeBrowserAndLoadTheTargetLinkUserGuide()
        {
            desktopSession = baseTestClass.DesktopSession();
            string actualUrl = desktopSession.Session.FindElementByName("地址和搜索栏").GetAttribute("Value.Value");
            Assert.AreEqual(WebSiteUrl.userGuideUrl_Chrome, actualUrl);
        }

        [When(@"Click on Lenovo Community button  under Need help section")]
        public void WhenClickOnLenovoCommunityButtonUnderNeedHelpSection()
        {
            supportPage = new SupportPage(webDriver.Session);
            supportPage.lenovoCommunityButton.Click();
            Thread.Sleep(10000);
        }


        [Then(@"Verify it will opened Chrome Edge browser and load the target link Lenovo Community")]
        public void ThenVerifyItWillOpenedChromeEdgeBrowserAndLoadTheTargetLinkLenovoCommunity()
        {
            desktopSession = baseTestClass.DesktopSession();
            string actualUrl = desktopSession.Session.FindElementByName("地址和搜索栏").GetAttribute("Value.Value");
            Assert.AreEqual(WebSiteUrl.lenovoCommunityUrl_Chrome, actualUrl);
        }

        [When(@"Click on Contact customer service button  under Need help section")]
        public void WhenClickOnContactCustomerServiceButtonUnderNeedHelpSection()
        {
            supportPage = new SupportPage(webDriver.Session);
            supportPage.contactCustomerServiceButton.Click();
            Thread.Sleep(15000);
        }

        [Then(@"Verify it will opened Chrome Edge browser and load the target link Contact customer service")]
        public void ThenVerifyItWillOpenedChromeEdgeBrowserAndLoadTheTargetLinkContactCustomerService()
        {
            desktopSession = baseTestClass.DesktopSession();
            string actualUrl = desktopSession.Session.FindElementByName("地址和搜索栏").GetAttribute("Value.Value");
            Assert.AreEqual(WebSiteUrl.contactCustomerServiceUrl_Chrome, actualUrl);
        }

        [When(@"Click on Your Virtual assistant button under Need help section")]
        public void WhenClickOnYourVirtualAssistantButtonUnderNeedHelpSection()
        {
            supportPage = new SupportPage(webDriver.Session);
            supportPage.yourVirtualAssistantButton.Click();
            Thread.Sleep(5000);
        }

        [Then(@"Verify it will opened Chrome Edge browser and load the target link Your Vitual assistant")]
        public void ThenVerifyItWillOpenedChromeEdgeBrowserAndLoadTheTargetLinkYourVitualAssistant()
        {
            desktopSession = baseTestClass.DesktopSession();

            string actualUrl = desktopSession.Session.FindElementByName("地址和搜索栏").GetAttribute("Value.Value");
            Assert.AreEqual(WebSiteUrl.lenovoCommunityUrl_Chrome, actualUrl);
        }

        [Given(@"Go to About Lenovo Vantage page")]
        public void GivenGoToAboutLenovoVantagePage()
        {
            supportPage = new SupportPage(webDriver.Session);
            supportPage.aboutLenovoVantagePageButton.Click();
            Thread.Sleep(3000);
        }

        [When(@"Click on Our website link")]
        public void WhenClickOnOurWebsiteLink()
        {
            supportPage = new SupportPage(webDriver.Session);
            supportPage.ourWebsiteLink.Click();
            Thread.Sleep(10000);
        }

        [Then(@"Verify it will opened Chrome Edge browser and load the target link Our website")]
        public void ThenVerifyItWillOpenedChromeEdgeBrowserAndLoadTheTargetLinkOurWebsite()
        {
            desktopSession = baseTestClass.DesktopSession();
            string actualUrl = desktopSession.Session.FindElementByName("地址和搜索栏").GetAttribute("Value.Value");
            Assert.AreEqual(WebSiteUrl.ourWebsiteUrl_Chrome, actualUrl);
        }

        [When(@"When Click on About your device link")]
        public void WhenWhenClickOnAboutYourDeviceLink()
        {
            supportPage = new SupportPage(webDriver.Session);
            supportPage.aboutYourDeviceLink.Click();
            Thread.Sleep(5000);
        }

        [Then(@"Verify it will opened Chrome Edge browser and load the target link About your device")]
        public void ThenVerifyItWillOpenedChromeEdgeBrowserAndLoadTheTargetLinkAboutYourDevice()
        {
            desktopSession = baseTestClass.DesktopSession();
            string actualUrl = desktopSession.Session.FindElementByName("地址和搜索栏").GetAttribute("Value.Value");
            Assert.AreEqual(WebSiteUrl.aboutYourDeviceUrl_Chrome, actualUrl);
        }

        [Given(@"Close Chrome Browser")]
        public void GivenCloseChromeBrowser()
        {
            Process[] processes = Process.GetProcessesByName("chrome");

            foreach (Process process in processes)
            {
                process.Kill();
                process.WaitForExit();
                process.Dispose();
            }
        }
        [Then(@"Verify it is Support Page")]
        public void ThenVerifyItIsSupportPage()
        {
            supportPage = new SupportPage(webDriver.Session);
            Assert.IsTrue(supportPage.backBtn.Displayed);
        }

        [Then(@"Support page works normal")]
        public void ThenSupportPageWorksNormal()
        {
            WhenClickOnUserGuideLink();
            VantageUI vantageUI = new VantageUI();
            bool isExpecturl = vantageUI.GetEdgeUrl().Contains(Constants.userguideurl);
            Assert.IsTrue(isExpecturl);
        }


    }
}
