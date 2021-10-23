namespace LenovoVantageTest.Steps.UWP
{
    using System;
    using System.Threading;
    using System.Windows.Forms;
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using OpenQA.Selenium.Interactions;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class BacklightTestStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        public IdeaPluginHelper helper;

        private DashBoardPage dashBoardPage;
        private readonly InformationalWebDriver webDriver;
        private SupportPage supportPage;
        private MyDeviceSettingObject myDeviceSettingPage;
        private object sender;
        private EventArgs e;

        public BacklightTestStepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [When(@"Go to Input and Accessiories")]
        public void WhenGoToInputAndAccessiories()
        {
            myDeviceSettingPage = new MyDeviceSettingObject(webDriver.Session);

            //Actions action = new Actions(webDriver.Session);
            //action.MoveToElement(myDeviceSettingPage.input_accessories_Title_New).Perform();
            //action.Click();

            myDeviceSettingPage.input_accessories_Title_New.Click();
        }

        [When(@"Scroll the screen on my device")]
        public void WhenScrollTheScreenOnMyDevice()
        {
            myDeviceSettingPage.ScrollScreen();
        }

        [When(@"Click Off under keyboard backlight")]
        public void WhenClickOffUnderKeyboardBacklight()
        {
            myDeviceSettingPage.offRedioButton.Click();
        }

        [Then(@"Verify the backlight status is off")]
        public void ThenVerifyTheBacklightStatusIsOff()
        {
            IdeaPluginHelper helper = new IdeaPluginHelper();
            helper.GetBacklightStatus();
            Assert.AreEqual("Off",helper.CoverToTestResult());
        }
    }
}
