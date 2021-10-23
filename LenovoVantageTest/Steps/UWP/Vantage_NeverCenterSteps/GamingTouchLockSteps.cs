using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public sealed class GamingTouchLockSteps
    {
        private GamingThermalModePages _gamingThermalModePages;
        private InformationalWebDriver _webDriver;

        public GamingTouchLockSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Go to homepage")]
        public void GivenGoToHomepage()
        {
        }

        [When(@"Check default toggle status of the Touchpad Lock")]
        public void WhenCheckDefaultToggleStatusOfTheTouchpadLock()
        {
        }

        [Then(@"Touchpad Lock Disabled")]
        public void ThenTouchpadLockDisabled()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.IsNotNull(_gamingThermalModePages.GetTouchpadStatus);
            Assert.AreEqual(ToggleState.Off, _gamingThermalModePages.GetGamingToggleStatusByName(_gamingThermalModePages.GetTouchpadStatus));
        }

        [Then(@"Touchpad Lock Enabled")]
        public void ThenTouchpadLockEnabled()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.IsNotNull(_gamingThermalModePages.GetTouchpadStatus);
            Assert.AreEqual(ToggleState.On, _gamingThermalModePages.GetGamingToggleStatusByName(_gamingThermalModePages.GetTouchpadStatus));
        }

        [Given(@"Connect Mouse")]
        public void GivenConnectMouse()
        {
        }

        [When(@"Touchpad Lock is Enable")]
        public void WhenTouchpadLockisEnable()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            if (_gamingThermalModePages.GetGamingToggleStatusByName(_gamingThermalModePages.GetTouchpadStatus).Equals(ToggleState.Off))
            {
                _gamingThermalModePages.GetTouchpadStatus.Click();
                Thread.Sleep(3000);
            }
            Assert.AreEqual(ToggleState.On, _gamingThermalModePages.GetGamingToggleStatusByName(_gamingThermalModePages.GetTouchpadStatus));
        }

        [When(@"Disable touchpad Lock")]
        public void WhenDisableTouchpadLock()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            if (_gamingThermalModePages.GetGamingToggleStatusByName(_gamingThermalModePages.GetTouchpadStatus).Equals(ToggleState.On))
            {
                _gamingThermalModePages.GetTouchpadStatus.Click();
                Thread.Sleep(1000);
            }
            Assert.AreEqual(ToggleState.Off, _gamingThermalModePages.GetGamingToggleStatusByName(_gamingThermalModePages.GetTouchpadStatus));
        }


        [When(@"Launch the WorldOfWarcraft game")]
        public void WhenLaunchTheWorldOfWarcraftGame()
        {
            Process.Start("C:\\Program Files (x86)\\World of Warcraft\\_retail_\\Wow.exe");
            Thread.Sleep(10 * 1000);
        }
        [Then(@"Touchpad (.*) when game running")]
        public void ThenTouchpadDisabledWhenGameRunning(string status)
        {
            string TouchpadStatus = NerveCenterHelper.GetTouchpadStatus();
            switch (status)
            {
                case "disabled":
                    Assert.AreEqual("1", TouchpadStatus);
                    break;
                case "enabled":
                    Assert.AreEqual("0", TouchpadStatus);
                    break;
                default:
                    break;
            }
        }

        [Then(@"Kill game")]
        public void ThenKillGame()
        {
            Thread.Sleep(5000);
            Common.KillProcess("Wow", true);
        }

        [Then(@"(.*) show in homepage")]
        public void ThenTouchpadLockShowInHomepage(string feature)
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.IsNotNull(_gamingThermalModePages.GetTouchpadStatus);
        }

        [When(@"Idle for (.*) minute")]
        public void WhenIdleForMinute(int p0)
        {
            Thread.Sleep(p0 * 1000);
        }

        [When(@"Go back to homepage")]
        public void WhenGoBackToHomepage()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.IsNotNull(_gamingThermalModePages.GamingDeviceMenu);
            _gamingThermalModePages.GamingDeviceMenu.Click();

        }

        [When(@"There is no touchpad showing")]
        public void WhenThereIsNoTouchpadShowing()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.IsNull(_gamingThermalModePages.GetTouchpadStatus);
        }

        [When(@"Scroll the screen (.*) in homepage")]
        public void WhenScrollTheScreenInHomepage(int p0)
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            _gamingThermalModePages.ScrollScreen(p0);
        }

    }
}
