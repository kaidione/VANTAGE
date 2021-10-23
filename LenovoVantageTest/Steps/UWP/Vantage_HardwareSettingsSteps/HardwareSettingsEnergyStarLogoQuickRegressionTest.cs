using LenovoVantageTest.Pages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class HardwareSettingsEnergyStarLogoQuickRegressionTest
    {

        private HSPowerSettingsPage _hSPowerSettingsPage;
        private InformationalWebDriver _webDriver;
        private bool _regeditEnergyStartLogoValue;

        public HardwareSettingsEnergyStarLogoQuickRegressionTest(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Machine is IdeaPad or ThinkPad")]
        public void GivenMachineIsIdeaPadOrThinkPad()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            bool machineTypeFlag = _hSPowerSettingsPage.IsThinkPad() || _hSPowerSettingsPage.IsIdeaPad();
            Assert.IsTrue(machineTypeFlag);
        }

        [When(@"The value of the ""(.*)"" and  ""(.*)"" in Registry Editor is ""(.*)""")]
        public void WhenTheValueOfTheAndInRegistryEditorIs(string regeditPath, string regeditName, string setValue)
        {
            string regeditValue = IntelligentCoolingBaseHelper.GetLocalMachineRegeditValue(regeditName, regeditPath);
            if (string.IsNullOrEmpty(regeditValue))
            {
                IntelligentCoolingBaseHelper.CreateLocalMachineSubKey(regeditName, regeditPath, setValue, Microsoft.Win32.RegistryValueKind.DWord);
                regeditValue = IntelligentCoolingBaseHelper.GetLocalMachineRegeditValue(regeditName, regeditPath);
            }

            if (!regeditValue.Equals(setValue.ToString()))
            {
                IntelligentCoolingBaseHelper.SetLocalMachineRegeditValue(regeditName, regeditPath, setValue, Microsoft.Win32.RegistryValueKind.DWord);
                regeditValue = IntelligentCoolingBaseHelper.GetLocalMachineRegeditValue(regeditName, regeditPath);
            }

            Assert.AreEqual(regeditValue, setValue.ToString());
            _regeditEnergyStartLogoValue = regeditValue.Equals("1");
        }

        [Then(@"There shows the Energy Star logo at the bottom of Power page")]
        public void ThenThereShowsTheEnergyStarLogoAtTheBottomOfPowerPage()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _hSPowerSettingsPage.GoToMyDevicesSettings();
            _hSPowerSettingsPage.EnergyStarImageElement?.Click();
            if (_regeditEnergyStartLogoValue)
            {
                _hSPowerSettingsPage.AddScreenshotIntoReport("EnergyStar", ".", "HSScreenShotResult");
            }
            else
            {
                Assert.IsNull(_hSPowerSettingsPage.EnergyStarImageElement);
            }
        }

        [Then(@"The UI appearance of Energy Star logo shoul follow the UI SPEC")]
        public void ThenTheUIAppearanceOfEnergyStarLogoShoulFollowTheUISPEC()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.AreEqual("Energy Star", _hSPowerSettingsPage.EnergyStarTitleElement.Text);
            Assert.IsNotNull(_hSPowerSettingsPage.EnergyStarImageElement);
            Assert.AreEqual("An ENERGY STAR certified product", _hSPowerSettingsPage.EnergyStarContentElement.Text);
        }

        [Then(@"There should not shows the Energy Star logo at the bottom of Power page")]
        public void ThenThereShouldNotShowsTheEnergyStarLogoAtTheBottomOfPowerPage()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNull(_hSPowerSettingsPage.EnergyStarImageElement);
        }

        [Given(@"Reset value of the ""(.*)"" and  ""(.*)"" in Registry Editor is ""(.*)""")]
        public void WhenResetValueOfTheAndInRegistryEditorIs(string regeditPath, string regeditName, string setValue)
        {
            string regeditValue = IntelligentCoolingBaseHelper.GetLocalMachineRegeditValue(regeditName, regeditPath);
            if (!regeditValue.Equals(setValue.ToString()))
            {
                IntelligentCoolingBaseHelper.SetLocalMachineRegeditValue(regeditName, regeditPath, setValue);
                regeditValue = IntelligentCoolingBaseHelper.GetLocalMachineRegeditValue(regeditName, regeditPath);
            }
            Assert.AreEqual(regeditValue, setValue.ToString());
        }

    }
}
