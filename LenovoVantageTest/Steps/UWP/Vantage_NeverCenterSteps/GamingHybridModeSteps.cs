using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Threading;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingHybridModeSteps
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;

        public GamingHybridModeSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"The hybrid mode toggle status is on or off within homepage '(.*)'")]
        public void ThenTheHybridModeToggleStatusIsOnOrOffWithinHomepage(string status)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (status.ToLower())
            {
                case "on":
                    Assert.IsNotNull(_nerveCenterPages.LegionEdgeHybridModeToggleOn, "The hybrid mode toggle is on not found");
                    break;
                case "off":
                    Assert.IsNotNull(_nerveCenterPages.LegionEdgeHybridModeToggleOff, "The hybrid mode toggle is off not found");
                    break;
                default:
                    Assert.Fail("The ThenTheHybridModeToggleStatusIsOnOrOffWithinHomepage not run");
                    break;
            }
        }

        [Then(@"The number of graphics card in Device Manager is '(.*)'")]
        public void ThenTheNumberOfGraphicsCardInDeviceManagerIs(int number)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            int _number = NerveCenterHelper.GetDisplayAdaptersInfo("Name").Count;
            Assert.AreEqual(number, _number, "The two numbers of Graphics Card are not equal.");
        }

        [When(@"Click the hybrid mode '(.*)' toggle")]
        public void WhenClickTheHybridModeToggle(string status)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (status.ToLower())
            {
                case "on":
                    Assert.IsNotNull(_nerveCenterPages.LegionEdgeHybridModeToggleOn, "The hybrid mode toggle is on not found");
                    _nerveCenterPages.LegionEdgeHybridModeToggleOn.Click();
                    Thread.Sleep(3000);
                    break;
                case "off":
                    Assert.IsNotNull(_nerveCenterPages.LegionEdgeHybridModeToggleOff, "The hybrid mode toggle is off not found");
                    _nerveCenterPages.LegionEdgeHybridModeToggleOff.Click();
                    Thread.Sleep(3000);
                    break;
                default:
                    Assert.Fail("The WhenClickTheHybridModeToggle not run");
                    break;
            }
        }

        [Then(@"The Restart Window Display")]
        public void ThenTheRestartWindowDisplay()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.HybridModeRestartWindow, "The HybridModeRestartWindow not found");
            Assert.IsNotNull(_nerveCenterPages.HybridModeRestartWindowCloseButton, "The HybridModeRestartWindowCloseButton not found");
            Assert.IsNotNull(_nerveCenterPages.HybridModeRestartWindowOKButton, "The HybridModeRestartWindowOKButton not found");
            Assert.IsNotNull(_nerveCenterPages.HybridModeRestartWindowTip, "The HybridModeRestartWindowTip not found");
        }

        [Then(@"The system can display normally")]
        public void ThenTheSystemCanDisplayNormally()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingSystemStatus, "The GamingSystemStatus not found");
            Assert.IsNotNull(_nerveCenterPages.GamingSystemTools, "The GamingSystemTools not found");
            Assert.IsNotNull(_nerveCenterPages.GamingLegionEdge, "The GamingLegionEdge not found");
            Assert.IsNotNull(_nerveCenterPages.GamingQuickSettings, "The GamingQuickSettings not found");
        }

        [When(@"Click the OK button in the Restart Window")]
        public void WhenClickTheOKButtonInTheRestartWindow()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.HybridModeRestartWindowOKButton);
            _nerveCenterPages.HybridModeRestartWindowOKButton.Click();
            Thread.Sleep(3000);
        }

        [When(@"Click the X button in the Restart Window")]
        public void WhenClickTheXButtonInTheRestartWindow()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.HybridModeRestartWindowCloseButton);
            _nerveCenterPages.HybridModeRestartWindowCloseButton.Click();
            Thread.Sleep(3000);
        }

        [Then(@"The Restart Window Will be Closed")]
        public void ThenTheRestartWindowWillBeClosed()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.HybridModeRestartWindow, "The HybridModeRestartWindow still shown");
            Assert.IsNull(_nerveCenterPages.HybridModeRestartWindowCloseButton, "The HybridModeRestartWindowCloseButton still shown");
            Assert.IsNull(_nerveCenterPages.HybridModeRestartWindowOKButton, "The HybridModeRestartWindowOKButton still shown");
            Assert.IsNull(_nerveCenterPages.HybridModeRestartWindowTip, "The HybridModeRestartWindowTip still shown");
        }

    }
}
