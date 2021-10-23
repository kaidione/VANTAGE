using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public sealed class SmartBattery2Steps
    {

        private InformationalWebDriver _webDriver;
        private HSPowerSettingsPage _hSPowerSettingsPage;

        public SmartBattery2Steps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"Not show SmartBattery")]
        public void GivenNotSupportSmartBattery()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNull(_hSPowerSettingsPage.BatteryHealthIcon, "The BatteryHealthIcon is find");
            Assert.IsNull(_hSPowerSettingsPage.BatteryHealthTitle, "The BatteryHealthIcon is find");
            Assert.IsNull(_hSPowerSettingsPage.BatteryHealthDescription, "The BatteryHealthDescription is find");
            Assert.IsNull(_hSPowerSettingsPage.BatteryCapacityTitle, "The BatteryCapacityTitle is find");
            Assert.IsNull(_hSPowerSettingsPage.BatteryCapacityCircle, "The BatteryCapacityCircle is find");
            Assert.IsNull(_hSPowerSettingsPage.BatteryCapacityQuestionMark, "The BatteryCapacityQuestionMark is find");
            Assert.IsNull(_hSPowerSettingsPage.BatteryCapacityTipLine1, "The BatteryCapacityTipLine1 is find");
            Assert.IsNull(_hSPowerSettingsPage.BatteryCapacityTipLine2, "The BatteryCapacityTipLine2 is find");
            Assert.IsNull(_hSPowerSettingsPage.BatteryTemperatureTitle, "The BatteryTemperatureTitle is find");
            Assert.IsNull(_hSPowerSettingsPage.BatteryTemperatureIndicatorImage, "The BatteryTemperatureIndicatorImage is find");
            Assert.IsNull(_hSPowerSettingsPage.BatteryTemperatureIndicatorText, "The BatteryTemperatureIndicatorText is find");
            Assert.IsNull(_hSPowerSettingsPage.BatteryTemperatureDescription, "The BatteryTemperatureDescription is find");
        }

        [Then(@"Check SmartBattery Two mode")]
        public void ThenCheckSmartBatteryTwoMode()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryCapacityTitle, "The BatteryCapacityTitle is not find");
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryTemperatureTitle, "The BatteryTemperatureTitle is not find");
        }

        [Then(@"Check Battery Capacity mode")]
        public void ThenCheckBatteryCapacityMode()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryCapacityTitle, "The BatteryCapacityTitle is not find");
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryCapacityCircle, "The BatteryCapacityCircle is not  find");
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryCapacityQuestionMark, "The BatteryCapacityQuestionMark is not  find");
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryCapacityTipLine1, "The BatteryCapacityTipLine1 is not  find");
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryCapacityTipLine2, "The BatteryCapacityTipLine2 is not  find");
        }

        [Then(@"Check Battery Temperature mode")]
        public void ThenCheckBatteryTemperatureMode()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryTemperatureTitle, "The BatteryTemperatureTitle is not  find");
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryTemperatureIndicatorImage, "The BatteryTemperatureIndicatorImage is not  find");
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryTemperatureIndicatorText, "The BatteryTemperatureIndicatorText is not  find");
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryTemperatureDescription, "The BatteryTemperatureDescription is not  find");
        }

        [Then(@"The batterycolor and batterytempture image is existed")]
        public void ThenTheImageIsExisted()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryTemperatureIndicatorImage, "The BatteryTemperatureIndicatorImage is not  find");
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryCapacityCircle, "The BatteryCapacityCircle is not  find");
        }

        [Given(@"""(.*)"" the Battery Settings Table")]
        public void GivenTheBatterySettingsTable(string status)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            if (status.ToLower() == "open")
            {
                WindowsElement CloseBtn = _hSPowerSettingsPage.BatterySettingsCloseTable;
                Assert.IsNotNull(CloseBtn, "The BatterySettingsCloseTable is not find");
                CloseBtn.Click();
            }
            else if (status.ToLower() == "close")
            {
                WindowsElement openBtn = _hSPowerSettingsPage.BatterySettingsOpenTable;
                Assert.IsNotNull(openBtn, "The BatterySettingsOpenTable is not find");
                openBtn.Click();
            }
        }

    }
}