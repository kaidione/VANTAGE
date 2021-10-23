using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest
{
    [Binding]
    public class GamingRapidChargeSteps
    {

        private NerveCenterPages _nerveCenterPages;
        private GamingThermalModePages _gamingThermalModePages;
        private InformationalWebDriver _webDriver;

        public GamingRapidChargeSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"Rapid Charge is displayed (.*)")]
        public void ThenRapidChargeIsDisplayed(string rapidCharge)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SystemToolsPower, "SystemToolsPower is null");
            _nerveCenterPages.SystemToolsPower.Click();
            Thread.Sleep(500);
            if (rapidCharge.Trim().Equals("exist"))
            {
                Assert.IsNotNull(_nerveCenterPages.PowerRapidChargeCheckbox, "PowerRapidChargeCheckbox is null");
                Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu, "GamingDeviceMenu is null");
                _nerveCenterPages.GamingDeviceMenu.Click();
                Thread.Sleep(500);
                Assert.IsTrue(_nerveCenterPages.QuickSettingsRapidChargeToggleOff != null || _nerveCenterPages.QuickSettingsRapidChargeToggleOn != null, "Is null");
            }
            else if (rapidCharge.Trim().Equals("no"))
            {
                Assert.IsNull(_nerveCenterPages.PowerRapidChargeCheckbox, "PowerRapidChargeCheckbox is null");
                Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu, "GamingDeviceMenu is null");
                _nerveCenterPages.GamingDeviceMenu.Click();
                Thread.Sleep(500);
                Assert.IsTrue(_nerveCenterPages.QuickSettingsRapidChargeToggleOff == null || _nerveCenterPages.QuickSettingsRapidChargeToggleOn == null, "Is not null");
            }
        }

        [When(@"Switch Rapid Charge toggle status to (.*)")]
        public void WhenSwitchRapidChargeToggleStatusToHomepage(string p0)
        {
            {
                _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
                bool turnOffFlag = false;
                switch (p0.ToLower())
                {
                    case "off":
                        turnOffFlag = _gamingThermalModePages.SetRapidChargeSwitch(ToggleState.Off);
                        break;
                    case "on":
                        turnOffFlag = _gamingThermalModePages.SetRapidChargeSwitch(ToggleState.On);
                        break;
                }
                Assert.IsTrue(turnOffFlag, "Current status is not " + p0);
            }
        }

        [Then(@"Rapid Charge Toggle status(.*)")]
        public void ThenRapidChargeToggleStatus(string p0)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (p0.ToLower())
            {
                case "on":
                    Assert.IsNotNull(_nerveCenterPages.QuickSettingsRapidChargeToggleOn);
                    break;
                case "off":
                    Assert.IsNotNull(_nerveCenterPages.QuickSettingsRapidChargeToggleOff);
                    break;
            }
        }

        [When(@"Enter to other subpage")]
        public void WhenEnterToOtherSubpage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeAutoCloseIcon);
            int timeOut = 0;
            do
            {
                _nerveCenterPages.LegionEdgeAutoCloseIcon.Click();
                Thread.Sleep(500);
                timeOut += 1;
            } while (_nerveCenterPages.AutoCloseTitle == null && timeOut < 10);
            Assert.IsNotNull(_nerveCenterPages.AutoCloseTitle, "Failed to click auto close gear icon.");
        }

        [When(@"Return to homepage")]
        public void WhenReturnToHomepage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.YLogo);
            _nerveCenterPages.YLogo.Click();
            Thread.Sleep(1000);
        }

        [When(@"Click power icon in the system tools")]
        public void WhenClickPowerIconInTheSystemTools()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SystemToolsPower);
            _nerveCenterPages.SystemToolsPower.Click();
            Thread.Sleep(500);
        }

        [Then(@"The Device settings power page is opened")]
        public void ThenTheDeviceSettingsPowerPageIsOpened()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.PowerTitle);
        }

        [When(@"Click the Rapid Charge toggle in the Power page")]
        public void WhenClickTheRapidChargeToggleInThePowerPage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.PowerRapidChargeCheckbox);
            _nerveCenterPages.PowerRapidChargeCheckbox.Click();
        }

        [Then(@"Power page rapid charge toggle status(.*)")]
        public void ThenPowerPageRapidChargeToggleStatus(string powerToggleStatus)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (powerToggleStatus.Trim().Equals("on"))
            {
                Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_nerveCenterPages.PowerRapidChargeCheckbox).ToString().ToLower(), "on");
            }
            else
            {
                Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_nerveCenterPages.PowerRapidChargeCheckbox).ToString().ToLower(), "off");
            }
        }
    }
}
