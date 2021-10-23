namespace LenovoVantageTest.Steps.UWP
{
    using DeviceInformation.Contracts.SystemInfomation.MachineInformation;
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using OpenQA.Selenium.Appium.Windows;
    using System.Threading;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class SystemUpdatePageStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        //private readonly InformationalWebDriver webDriver;

        private Utility.InformationalWebDriver webDriver;

        private InformationalWebDriver desktopSession;

        public MachineInformation machineInfo;

        public DashBoardPage dashBoardPage;
        public Common common;
        public SystemUpdatePage systemUpdatePage;

        private BaseTestClass baseTestClass = new BaseTestClass();


        public SystemUpdatePageStepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Given(@"Click System Update Item")]
        public void GivenClickSystemUpdateItem()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnDeviceListItem(dashBoardPage.deviceTab);
            dashBoardPage.systemUpdateLink.Click();
        }

        [When(@"Click Check For Updates Button")]
        public void WhenClickCheckForUpdatesButton()
        {
            systemUpdatePage = new SystemUpdatePage(webDriver.Session);
            systemUpdatePage.SelectCheckForSystemUpdateButton();
            Assert.IsTrue(systemUpdatePage.progressbar.Enabled);
        }

        [Then(@"Verify Available Updates and Install All Updates button enable")]
        public void ThenVerifyAvailableUpdatesAndInstallAllUpdatesButtonEnable()
        {
            systemUpdatePage = new SystemUpdatePage(webDriver.Session);
            Assert.IsTrue(systemUpdatePage.availableUpdatesText.Enabled);
            Assert.IsTrue(systemUpdatePage.installAllUpdateButton.Enabled);
        }
        [Then(@"Click back on System Update page")]
        public void ThenClickBackOnSystemUpdatePage()
        {
            systemUpdatePage = new SystemUpdatePage(webDriver.Session);
            systemUpdatePage.backBtn.Click();

        }
        [Then(@"Click the windows setting button")]
        public void ThenClickTheWindowsSettingButton()
        {
            systemUpdatePage = new SystemUpdatePage(webDriver.Session);
            systemUpdatePage.windowsSetting.Click();
        }


        [Then(@"Verify the windows setting work well")]
        public void ThenVerifyTheWindowsSettingWorkWell()
        {
            desktopSession = baseTestClass.DesktopSession();
            WindowsElement windowsUpdate = desktopSession.Session.FindElementByAccessibilityId("SystemSettings_MusUpdate_UpdateStatus_DescriptionTextBlock");
            Assert.IsTrue(windowsUpdate.Displayed);
        }


        [Then(@"Verify Click the up content lead to the right article")]
        public void ThenVerifyClickTheUpContentLeadToTheRightArticle()
        {

            systemUpdatePage = new SystemUpdatePage(webDriver.Session);

            systemUpdatePage.sideArticle.Click();

            string sn = machineInfo.SerialNumber;
            desktopSession = baseTestClass.DesktopSession();
            Thread.Sleep(5000);
            // Assert.AreEqual(WebSiteUrl.lenovoSupportWebsite+sn, actualUrl);
            string myWebsite = WebSiteUrl.lenovoSupportWebsite + sn;
            string actualUrl = desktopSession.Session.FindElementByAccessibilityId("addressEditBox").Text;
            Assert.AreEqual(myWebsite, actualUrl);
        }

        [Then(@"Verify Click the down content lead to the right article")]
        public void ThenVerifyClickTheDownContentLeadToTheRightArticle()
        {
            systemUpdatePage = new SystemUpdatePage(webDriver.Session);
            systemUpdatePage.sideArticle.Click();
            desktopSession = baseTestClass.DesktopSession();
            Thread.Sleep(5000);
            string actualUrl = desktopSession.Session.FindElementByAccessibilityId("addressEditBox").Text;
            Assert.AreEqual(WebSiteUrl.getLatestDrivers, actualUrl);
        }
        [Then(@"Verify SystemUpdate page exists offline icon")]
        public void ThenVerifySystemUpdatePageExistsOfflineIcon()
        {
            systemUpdatePage = new SystemUpdatePage(webDriver.Session);
            Assert.IsTrue(systemUpdatePage.offlineIcon.Displayed);

        }

        [Then(@"Click the up content lead")]
        public void ThenClickTheUpContentLead()
        {
            systemUpdatePage = new SystemUpdatePage(webDriver.Session);
            systemUpdatePage.sideArticle.Click();
            //webDriver.Session.Quit();
        }

        [Then(@"Verify opened correct url for content lead")]
        public void ThenVerifyOpenedCorrectUrlForContentLead()
        {
            desktopSession = baseTestClass.DesktopSession();
            //string sn = machineInfo.SerialNumber;
            // Assert.AreEqual(WebSiteUrl.lenovoSupportWebsite+sn, actualUrl);
            //string myWebsite = WebSiteUrl.lenovoSupportWebsite + sn;
            string actualUrl = desktopSession.Session.FindElementByAccessibilityId("addressEditBox").Text;
            //Assert.AreEqual(myWebsite, actualUrl);
            Assert.AreEqual(WebSiteUrl.lenovoSupportWebsite, actualUrl);



        }



        [When(@"Do the test_System Update Check")]
        public void WhenDoTheTest_SystemUpdateCheck()
        {
            ScenarioContext.Current.Pending();
        }
        [When(@"Do the test_Update Install")]
        public void WhenDoTheTest_UpdateInstall()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
