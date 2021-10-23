using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class PowerSettingsAdPolicySteps
    {
        private readonly InformationalWebDriver _AppDriver;
        private HSPowerSettingsPage _HSPowerSettingsPage;

        public PowerSettingsAdPolicySteps(InformationalWebDriver appDriver)
        {
            _AppDriver = appDriver;
        }

        #region BeforeScenario
        [BeforeScenario("PowerSettings_AdPolicy")]
        [BeforeScenario("PowerSettings_NoSupport_AdPolicy")]
        public static void BeforeScenarion()
        {
            DeleteAdPolicyKey(Constants.vantage_adpolicy_power_power_settings);
        }
        #endregion

        #region AfterScenario
        [AfterScenario("PowerSettings_AdPolicy")]
        [AfterScenario("PowerSettings_NoSupport_AdPolicy")]
        public void AfterScenario()
        {
            UpdateAdPolicyForAllFeaturesOnSection("not configured");
        }
        #endregion

        public static void DeleteAdPolicyKey(string keyToDelete)
        {
            AdPolicyRegistryHelper.DeleteKey(keyToDelete);
        }

        [StepDefinition(@"Power Settings AdPolicy is set to (enabled|disabled|not configured)")]
        public void UpdateAdPolicyForSection(string status)
        {
            if (status == "not configured")
            {
                DeleteAdPolicyKey(Constants.vantage_adpolicy_power_power_settings);
            }
            else
            {
                bool booleanValue = status == "enabled" ? true : false;
                AdPolicyRegistryHelper.SetAdPolicy(Constants.vantage_adpolicy_power_power_settings, booleanValue);
            }
        }

        [Then(@"Power Settings and Jump to Settings should be (visible|not visible)")]
        public void ThenStandbySettingsSectionVisible(string visibility)
        {
            _HSPowerSettingsPage = new HSPowerSettingsPage(_AppDriver.Session);

            bool shouldBeVisible = visibility == "visible" ? true : false;

            if (shouldBeVisible)
            {
                Assert.IsNotNull(_HSPowerSettingsPage.PowerPagePowerSectionTitle, "Power Settings section should be visibile");
                Assert.IsNotNull(_HSPowerSettingsPage.JumpToPowerSettings, "Power Settings jump to settings link should be visibile");
            }
            else
            {
                List<Task> allTasks = new List<Task>()
                {
                    Task.Run(() => Assert.IsNull(_HSPowerSettingsPage.PowerPagePowerSectionTitle, "Power Settings section should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSPowerSettingsPage.JumpToPowerSettings, "Power Settings jump to settings link should be not visibile")),
                };

                Task.WaitAll(allTasks.ToArray());
            }
        }

        [StepDefinition(@"AdPolicy for all features on PowerSettings page are set to (enabled|disabled|not configured)")]
        public void UpdateAdPolicyForAllFeaturesOnSection(string status)
        {
            List<string> allPolicyKeys = GetPolicyKeysForAllFeaturesOnSection();
            if (status == "not configured")
            {
                foreach (string policyKey in allPolicyKeys)
                {
                    DeleteAdPolicyKey(policyKey);
                }
            }
            else
            {
                bool booleanValue = status == "enabled" ? true : false;
                foreach (string policyKey in allPolicyKeys)
                {
                    AdPolicyRegistryHelper.SetAdPolicy(policyKey, booleanValue);
                }
            }
        }

        public List<string> GetPolicyKeysForAllFeaturesOnSection()
        {
            List<string> policyKeys = new List<string>()
            {
                @"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.power.standby-settings",
                @"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.power.battery-settings",
                @"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.power.energy-star",
                @"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.power.power-settings",
                @"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.power.power-smart-settings",
                @"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.power.dpm-power-settings"
            };

            return policyKeys;
        }

    }
}
