using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Windows.Forms;
using TechTalk.SpecFlow;


namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public sealed class VantageHardwareSettingsCS20KeyboardMapQuickRegressionSteps
    {
        private InformationalWebDriver _webDriver;
        private HSInputPage _hSInputPage;
        private SettingsBase _settingBase;
        private HSQuickSettingsPage _hsQuickSettingsPage;
        private HSPowerSettingsPage _hsPowerSettingsPage;

        public VantageHardwareSettingsCS20KeyboardMapQuickRegressionSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Unsupported machines")]
        public void GivenUnsupportedMachines()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            bool machineTypeFlag = _hsPowerSettingsPage.IsIdeaPad();
            Assert.IsTrue(machineTypeFlag, "This computer is suppored");
        }

        [Then(@"It should not show the feature")]
        public void ThenItShouldNotShowTheFeature()
        {
            _hSInputPage = new HSInputPage(_webDriver.Session);
            Assert.IsNull(_hSInputPage.HiddenKeyboardFunctionsTitleId, "The hiddenkeyboardtitleid is find");
        }

        [When(@"Check the Hidden Keyboard function")]
        public void WhenCheckTheHiddenKeyboardFunction()
        {
            _hSInputPage = new HSInputPage(_webDriver.Session);
            _settingBase = new SettingsBase();
            try
            {
                _settingBase.ScrollScreenToWindowsElement(_webDriver.Session, _hSInputPage.Fn4Title);
            }
            catch
            {
                Common.KillProcess(VantageConstContent.VantageProcessName, true);
                var factory = new BaseTestClass();
                var appInstance = factory.LaunchWinApplication(VantageConstContent.VantageUwpAppid);
                _webDriver = appInstance;
                _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
                _hsQuickSettingsPage.GotoInputPage();
                WhenCheckTheHiddenKeyboardFunction();
            }

        }

        [When(@"Check the FnFour")]
        public void WhenCheckTheFnFour()
        {
            _hSInputPage = new HSInputPage(_webDriver.Session);
            _settingBase = new SettingsBase();
            _settingBase.ScrollScreenToWindowsElement(_webDriver.Session, _hSInputPage.Fn4Title, -30, 10, true);
            Assert.IsNotNull(_hSInputPage.HiddenKeyboardFunctionsTitleId, "The hiddenkeyboardtitleid is not find");
            Assert.IsNotNull(_hSInputPage.HiddenKeyboardFunctionsTextId, "The hiddenkeyboardtextid is not find");
        }

    }
}
