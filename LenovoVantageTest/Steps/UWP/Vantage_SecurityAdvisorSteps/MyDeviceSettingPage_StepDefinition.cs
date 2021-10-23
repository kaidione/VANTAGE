using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;


namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public sealed class MyDeviceSettingPage_StepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private DashBoardPage dashBoardPage;
        private readonly InformationalWebDriver webDriver;
        private SupportPage supportPage;
        private MyDeviceSettingObject myDeviceSettingPage;
        private object sender;
        private EventArgs e;


        public MyDeviceSettingPage_StepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Given(@"Go to MyDeviceSetting page")]
        public void GivenGoToMyDeviceSettingPage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.deviceTab);
            dashBoardPage.deviceMenu_MyDeviceSettings.Click();
        }

        [Then(@"Verify Click the context lead to the right article")]
        public void ThenVerifyClickTheContextLeadToTheRightArticle()
        {
            myDeviceSettingPage = new MyDeviceSettingObject(webDriver.Session);
            myDeviceSettingPage.contentTitle.Click();
            Thread.Sleep(10000);
            Assert.IsTrue(myDeviceSettingPage.contentArticleTitle.Enabled);
        }


        [Then(@"Close the battary details page")]
        public void ThenCloseTheBattaryDetailsPage()
        {
            myDeviceSettingPage = new MyDeviceSettingObject(webDriver.Session);
            myDeviceSettingPage.batteryDetailsClose.Click();
        }

        [Given(@"Scroll the MyDeviceSetting page screen")]
        public void GivenScrollTheMyDeviceSettingPageScreen()
        {
            myDeviceSettingPage = new MyDeviceSettingObject(webDriver.Session);
            myDeviceSettingPage.ScrollScreen();
        }



        [Then(@"Verify MyDeviceSetting page offline icon is exist")]
        public void ThenVerifyMyDeviceSettingPageOfflineIconIsExist()
        {
            myDeviceSettingPage = new MyDeviceSettingObject(webDriver.Session);
            Assert.IsTrue(myDeviceSettingPage.contentOfflineIcon.Displayed);
        }

        [Then(@"Verify the battary setting work normal")]
        public void ThenVerifyTheBattarySettingWorkNormal()
        {
            myDeviceSettingPage = new MyDeviceSettingObject(webDriver.Session);
            myDeviceSettingPage.setBattary.Click();
            Assert.IsTrue(myDeviceSettingPage.primaryBattery.Displayed);
        }

        [Then(@"Verify the second Helpful Content works normal")]
        public void ThenVerifyTheSecondHelpfulContentWorksNormal()
        {
            myDeviceSettingPage = new MyDeviceSettingObject(webDriver.Session);
            myDeviceSettingPage.qaSecond.Click();
            Thread.Sleep(2000);
            supportPage = new SupportPage(webDriver.Session);
            Assert.True(supportPage.qaSecondDetailsTitle.Displayed);

        }

        [Given(@"Go to Input&Accessories section under MyDeviceSetting")]
        public void GivenGoToInputAccessoriesSectionUnderMyDeviceSetting()
        {
            myDeviceSettingPage = new MyDeviceSettingObject(webDriver.Session);
            myDeviceSettingPage.input_accessories_Title.Click();
        }

        [Given(@"Press Fn and F(.*)")]
        public void GivenPressFnAndF(int p0)
        {
            myDeviceSettingPage = new MyDeviceSettingObject(webDriver.Session);
            //SendKeys.SendWait("{F12}");
            //SendKeys.Send("{F12}");
            KeyboardEvent.Press_FnAndF12(sender, e);
            Thread.Sleep(5000);
        }




    }



}
