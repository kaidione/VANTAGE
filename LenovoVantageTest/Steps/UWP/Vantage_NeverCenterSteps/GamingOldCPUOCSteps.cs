using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingOldOverClocking
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;
        private string _driverName = "netfilterDriver";
        private string status = "Off";
        public GamingOldOverClocking(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"CPU OC Off should be shown in the CPU OverClocking area")]
        public void ThenCPUOCOffShouldBeShownInTheCPUOverClockingArea()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenu, "CPUOverClockingMenu is null");
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingOffName, "CPUOverClockingOffName is null");
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingOffTitleName, "CPUOverClockingOffTitleName is null");
        }

        [When(@"Click CPU OverClocking area")]
        public void WhenClickCPUOverClockingArea()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenu);
            _nerveCenterPages.CPUOverClockingMenu.Click();
        }

        [Then(@"CPU OverClocking Dropdown Menu should be shown")]
        public void ThenCPUOverClockingDropdownMenuShouldBeShown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenuOn);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenuOnName);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenuWhenGaming);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenuWhenGamingName);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenuOff);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenuOffName);
        }

        [Then(@"CPU OverClocking Three Items Are Displayed In Dropdown Menu")]
        public void ThenCPUOverClockingThreeItemsAreDisplayedInDropdownMenu()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenuOn);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenuOnName);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenuWhenGaming);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenuWhenGamingName);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenuOff);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenuOffName);
        }

        [Then(@"CPU OverClocking Dropdown Menu Is Closed")]
        public void ThenCPUOverClockingDropdownMenuIsClosed()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.CPUOverClockingMenuOn);
            Assert.IsNull(_nerveCenterPages.CPUOverClockingMenuOnName);
            Assert.IsNull(_nerveCenterPages.CPUOverClockingMenuWhenGaming);
            Assert.IsNull(_nerveCenterPages.CPUOverClockingMenuWhenGamingName);
            Assert.IsNull(_nerveCenterPages.CPUOverClockingMenuOff);
            Assert.IsNull(_nerveCenterPages.CPUOverClockingMenuOffName);
            Assert.IsNotNull(_nerveCenterPages.GamingSystemStatus);
            Assert.IsNotNull(_nerveCenterPages.SystemStatusInfoLink);
        }

        [When(@"Click the OC On item in the CPU OverClocking dropdown menu")]
        public void WhenClickTheOCOnItemInTheCPUOverClockingDropdownMenu()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenuOn);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenuOnName);
            _nerveCenterPages.CPUOverClockingMenuOn.Click();
        }

        [Then(@"CPU OC On should be shown in the CPU OverClocking area")]
        public void ThenCPUOCOnShouldBeShownInTheCPUOverClockingArea()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenu);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingOnName);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingOnTitleName);
        }

        [When(@"Click the When Gaming item in the CPU OverClocking dropdown menu")]
        public void WhenClickTheWhenGamingItemInTheCPUOverClockingDropdownMenu()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenuWhenGaming);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenuWhenGamingName);
            _nerveCenterPages.CPUOverClockingMenuWhenGaming.Click();
        }

        [Then(@"CPU OC When Gaming should be shown in the CPU OverClocking area")]
        public void ThenCPUOCWhenGamingShouldBeShownInTheCPUOverClockingArea()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenu);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingWhenGamingName);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingWhenGamingTitleName);
        }

        [When(@"Click the Off item in the CPU OverClocking dropdown menu")]
        public void WhenClickTheOffItemInTheCPUOverClockingDropdownMenu()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenuOff);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenuOffName);
            _nerveCenterPages.CPUOverClockingMenuOff.Click();
        }

        [Given(@"Record the Overclocking Status")]
        public void Record_OldCPUOCStatus()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if ((_nerveCenterPages.CPUOverClockingOffTitleName) != null)
            {
                Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenu);
                Assert.IsNotNull(_nerveCenterPages.CPUOverClockingOffName);
                Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu);
                Assert.IsNotNull(_nerveCenterPages.SystemStatusInfoLink);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingWhenGamingName);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingWhenGamingTitleName);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingOnName);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingOnTitleName);
                status = "Off";
            }
            else if ((_nerveCenterPages.CPUOverClockingWhenGamingTitleName) != null)
            {
                Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenu);
                Assert.IsNotNull(_nerveCenterPages.CPUOverClockingWhenGamingName);
                Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu);
                Assert.IsNotNull(_nerveCenterPages.SystemStatusInfoLink);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingOffName);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingOffTitleName);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingOnName);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingOnTitleName);
                status = "When Gaming";
            }
            else
            {
                Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenu);
                Assert.IsNotNull(_nerveCenterPages.CPUOverClockingOnName);
                Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu);
                Assert.IsNotNull(_nerveCenterPages.SystemStatusInfoLink);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingOffName);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingOffTitleName);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingWhenGamingName);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingWhenGamingTitleName);
                status = "On";
            }
        }

        [Then(@"Overclocking Status shoule be consistent with the last change")]
        public void CompareOverclockingStatus()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (status == "On")
            {
                Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenu);
                Assert.IsNotNull(_nerveCenterPages.CPUOverClockingOnName);
                Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu);
                Assert.IsNotNull(_nerveCenterPages.SystemStatusInfoLink);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingOffName);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingOffTitleName);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingWhenGamingName);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingWhenGamingTitleName);
                status = "On";
            }
            else if (status == "Off")
            {
                Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenu);
                Assert.IsNotNull(_nerveCenterPages.CPUOverClockingOffName);
                Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu);
                Assert.IsNotNull(_nerveCenterPages.SystemStatusInfoLink);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingWhenGamingName);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingWhenGamingTitleName);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingOnName);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingOnTitleName);
                status = "Off";
            }

            else if (status == "When Gaming")
            {
                Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenu);
                Assert.IsNotNull(_nerveCenterPages.CPUOverClockingWhenGamingName);
                Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu);
                Assert.IsNotNull(_nerveCenterPages.SystemStatusInfoLink);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingOffName);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingOffTitleName);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingOnName);
                Assert.IsNull(_nerveCenterPages.CPUOverClockingOnTitleName);
                status = "When Gaming";
            }
        }
    }
}
