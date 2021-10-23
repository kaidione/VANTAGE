using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingRemoveGiveFeedbackSteps
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;

        public GamingRemoveGiveFeedbackSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"Give Feedback Container is not shown")]
        public void ThenGiveFeedbackContainerIsNotShown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.GiveFeedbackTitle);
            Assert.IsNull(_nerveCenterPages.GiveFeedbackDescription);
            Assert.IsNull(_nerveCenterPages.GiveFeedbackButton);
        }

        [When(@"Click the Support in the navigation bar")]
        public void WhenClickTheSupportInTheNavigationBar()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SupportButton, "The SupportButton not found");
            _nerveCenterPages.SupportButton.Click();
        }

        [Then(@"Give Feedback Container is shown")]
        public void ThenGiveFeedbackContainerIsShown()
        {
            Assert.IsNotNull(_nerveCenterPages.GiveFeedbackTitle);
            Assert.IsNotNull(_nerveCenterPages.GiveFeedbackDescription);
            Assert.IsNotNull(_nerveCenterPages.GiveFeedbackButton);
        }

        [When(@"Click the Lenovo ID Icon in the navigation bar")]
        public void WhenClickTheLenovoIDIconInTheNavigationBar()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LIDIcon);
            _nerveCenterPages.LIDIcon.Click();
        }

        [Then(@"Give Feedback link is shown")]
        public void ThenGiveFeedbackLinkIsShown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GiveFeedbackLink);
        }

        [When(@"Click the Minimize")]
        public void WhenClickTheMinimize()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.VantageMinimize);
            _nerveCenterPages.VantageMinimize.Click();
            _webDriver.Session.Manage().Window.Maximize();
        }

        [When(@"Click the Auto Close Gear Icon")]
        public void WhenClickTheAutoCloseGearIcon()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            var legionEdgeAutoCloseIconEle = _nerveCenterPages.LegionEdgeAutoCloseIcon;
            Assert.IsNotNull(legionEdgeAutoCloseIconEle);
            legionEdgeAutoCloseIconEle.Click();
        }

        [When(@"Click the Device link in the navigation bar")]
        public void WhenClickTheDeviceLinkInTheNavigationBar()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu);
            _nerveCenterPages.GamingDeviceMenu.Click();
        }

        [When(@"Close Vantage")]
        public void WhenCloseVantage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            WindowsElement closeVantage = _nerveCenterPages.VantageClose;
            Assert.IsNotNull(closeVantage, "VantageClose Element is not null");
            closeVantage.Click();
        }

    }
}
