using LenovoVantageTest.Commands;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System.Threading;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public sealed class MyDevicePage_StepDefinition : BasePage
    {

        private Utility.InformationalWebDriver webDriver;
        private MyDevicePage myDevicePage;
        private DashBoardPage dashBoardPage;
        private SystemUpdatePage systemUpdatePage;
        private SupportPage supportPage;
        private InformationalWebDriver desktopSession;
        private BaseTestClass baseTestClass = new BaseTestClass();

        [When(@"enable local wifi")]
        public void WhenEnableLocalWifi()
        {
            CmdCommands.EnableEthernet();
            Thread.Sleep(3000);
        }


        public static readonly string checkWarrantyStatusUrl = "https://newsupport.lenovo.com.cn/";

        public MyDevicePage_StepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Given(@"Go to MyDevice page")]
        public void GivenGoToMyDevicePage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.deviceTab.Click();

        }

        [Then(@"Verify the offline icon is not exist")]
        public void ThenVerifyTheOfflineIconIsNotExist()
        {
            myDevicePage = new MyDevicePage(webDriver.Session);

            Assert.IsFalse(myDevicePage.automationIdNotPresent(myDevicePage.offlineIconAutomationId));
        }

        [Then(@"Verify the offline icon is exist")]
        public void ThenVerifyTheOfflineIconIsExist()
        {
            myDevicePage = new MyDevicePage(webDriver.Session);
            Assert.IsTrue(myDevicePage.contextBoxOfflineIcon.Displayed);
        }

        [Then(@"Verify MyDevice page offline icon is exist")]
        public void ThenVerifyMyDevicePageOfflineIconIsExist()
        {
            myDevicePage = new MyDevicePage(webDriver.Session);
            Assert.IsTrue(myDevicePage.contextBoxOfflineIcon.Displayed);
        }


        [Then(@"Verify Click the context lead to the right url")]
        public void ThenVerifyClickTheContextLeadToTheRightUrl()
        {
            myDevicePage = new MyDevicePage(webDriver.Session);
            myDevicePage.containerCardOnline.Click();
            desktopSession = baseTestClass.DesktopSession();
            Thread.Sleep(10000);
            string actualUrl = desktopSession.Session.FindElementByAccessibilityId("addressEditBox").Text;
            Assert.AreEqual(WebSiteUrl.myDevice_CheckYourWarrantyStatus_Url, actualUrl);
        }

        [Then(@"Verify the learn more process in My device status works normal")]
        public void ThenVerifyTheLearnMoreProcessInMyDeviceStatusWorksNormal()
        {
            myDevicePage = new MyDevicePage(webDriver.Session);
            myDevicePage.processorMore.Click();
            Thread.Sleep(3000);
            desktopSession = baseTestClass.DesktopSession();
            WindowsElement contentLabel_OnMemorySetting = desktopSession.Session.FindElementByAccessibilityId("SystemSettings_PCSystem_ShieldProviderCollection_ContentLabel");
            Assert.IsTrue(contentLabel_OnMemorySetting.Displayed);
        }

        [When(@"Click System Update's learn more link My device status")]
        public void WhenClickSystemUpdateSLearnMoreLinkMyDeviceStatus()
        {
            myDevicePage = new MyDevicePage(webDriver.Session);
            myDevicePage.suMore.Click();
            Thread.Sleep(2000);
        }

        [Then(@"System Update Link works normal")]
        public void ThenSystemUpdateLinkWorksNormal()
        {
            systemUpdatePage = new SystemUpdatePage(webDriver.Session);
            Thread.Sleep(2000);
            Assert.True(systemUpdatePage.auto_updates_title.Displayed);
        }

        [Then(@"Verify the Helpful Content works normal")]
        public void ThenVerifyTheHelpfulContentWorksNormal()
        {
            myDevicePage = new MyDevicePage(webDriver.Session);
            myDevicePage.qa1fifth.Click();
            Thread.Sleep(2000);
            supportPage = new SupportPage(webDriver.Session);
            Assert.True(supportPage.qaFirstDetailsTitle.Displayed);
        }

        [Then(@"My device Page works normal")]
        public void ThenMyDevicePageWorksNormal()
        {
            WhenClickSystemUpdateSLearnMoreLinkMyDeviceStatus();
            ThenSystemUpdateLinkWorksNormal();
            GivenGoToMyDevicePage();
            ThenVerifyTheHelpfulContentWorksNormal();
        }

    }



}
