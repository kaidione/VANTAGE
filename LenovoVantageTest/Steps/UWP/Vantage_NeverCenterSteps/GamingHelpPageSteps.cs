using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System.Threading;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingHelpPageSteps
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;

        public GamingHelpPageSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [When(@"Click Help icon")]
        public void WhenClickHelpIcon()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeHelpName, "the LegionEdgeHelpName not found");
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeHelpIcon, "the LegionEdgeHelpIcon not found");
            _nerveCenterPages.LegionEdgeHelpIcon.Click();
            Thread.Sleep(3000);
        }

        [Then(@"Help Page Should Be Opened")]
        public void ThenHelpPageShouldBeOpened()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            //Assert.IsNotNull(_nerveCenterPages.HelpLegionEdgeImage, "the HelpLegionEdgeImage not found");
            Assert.IsNotNull(_nerveCenterPages.HelpPageCloseIcon, "the HelpPageCloseIcon not found");
            Assert.IsNotNull(_nerveCenterPages.HelpPageCloseName, "the HelpPageCloseName not found");
            Assert.IsNotNull(_nerveCenterPages.HelpPageDialog, "the HelpPageDialog not found");
            Assert.IsNotNull(_nerveCenterPages.HelpPageWindow, "the HelpPageWindow not found");
        }

        [Then(@"Gaming Features Introductions Should be Shown")]
        public void ThenGamingFeaturesIntroductionsShouldBeShown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.HelpPageManagementName);
            Assert.IsNotNull(_nerveCenterPages.HelpPageCPUGPUOverclockName);
            Assert.IsNotNull(_nerveCenterPages.HelpPageRAMOverclockName);
            Assert.IsNotNull(_nerveCenterPages.HelpPageNetworkBoostName);
            Assert.IsNotNull(_nerveCenterPages.HelpPageDolbyName);
            Assert.IsNotNull(_nerveCenterPages.HelpPageHybridModeName);
            Assert.IsNotNull(_nerveCenterPages.HelpPageRapidChargeName);
            Assert.IsNotNull(_nerveCenterPages.HelpPageTouchpadLockName);
            Assert.IsNotNull(_nerveCenterPages.HelpPageAutoCloseName);
            Assert.IsNotNull(_nerveCenterPages.HelpPageThermalModeName);
            Assert.IsNotNull(_nerveCenterPages.HelpPageMacrokeyName);
            Assert.IsNotNull(_nerveCenterPages.HelpPageOverDriveName);
        }

        [When(@"Click The Other Area")]
        public void WhenClickTheOtherArea()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            WindowsElement icon = _nerveCenterPages.HelpPageCloseIcon;
            int x = icon.Location.X + icon.Rect.Width / 2 + 50;
            int y = icon.Location.Y + icon.Rect.Height / 2;
            VantageCommonHelper.SetMouseClick(x.ToString(), y.ToString());

            Thread.Sleep(2000);

        }

        [When(@"Click the Close Button")]
        public void WhenClickTheCloseButton()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.HelpPageCloseIcon);
            _nerveCenterPages.HelpPageCloseIcon.Click();
            Thread.Sleep(5000);
        }

        [Then(@"Help Page Should Be Closed And Homepage Should Be Shown")]
        public void ThenHelpPageShouldBeClosedAndHomepageShouldBeShown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.HelpLegionEdgeImage);
            Assert.IsNull(_nerveCenterPages.HelpPageCloseIcon);
            Assert.IsNull(_nerveCenterPages.HelpPageCloseName);
            Assert.IsNull(_nerveCenterPages.HelpPageDialog);
            Assert.IsNull(_nerveCenterPages.HelpPageWindow);
            Assert.IsNotNull(_nerveCenterPages.GamingSystemStatus);
        }

    }

}

