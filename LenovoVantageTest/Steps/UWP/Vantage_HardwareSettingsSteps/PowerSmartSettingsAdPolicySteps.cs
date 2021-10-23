using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class PowerSmartSettingsAdPolicySteps
    {
        private readonly InformationalWebDriver _AppDriver;
        private IntelligentCoolingPages _IntelligentCoolingPage;
        private SettingsBase _SettingsBase;

        public PowerSmartSettingsAdPolicySteps(InformationalWebDriver appDriver)
        {
            _AppDriver = appDriver;
        }

        #region BeforeScenario
        [BeforeScenario("PowerSmartSettings_AdPolicy")]
        [BeforeScenario("PowerSmartSettings_NoSupport_AdPolicy")]
        public static void BeforeScenarion()
        {
            DeleteAdPolicyKey(Constants.vantage_adpolicy_power_power_smart_settings);
        }
        #endregion

        #region AfterScenario
        [AfterScenario("PowerSmartSettings_AdPolicy")]
        [AfterScenario("PowerSmartSettings_NoSupport_AdPolicy")]
        public void AfterScenario()
        {
            UpdateAdPolicyForAllFeaturesOnSection("not configured");
        }
        #endregion

        public static void DeleteAdPolicyKey(string keyToDelete)
        {
            AdPolicyRegistryHelper.DeleteKey(keyToDelete);
        }

        [StepDefinition(@"Power Smart Settings AdPolicy is set to (enabled|disabled|not configured)")]
        public void UpdateAdPolicyForSection(string status)
        {
            if (status == "not configured")
            {
                DeleteAdPolicyKey(Constants.vantage_adpolicy_power_power_smart_settings);
            }
            else
            {
                bool booleanValue = status == "enabled" ? true : false;
                AdPolicyRegistryHelper.SetAdPolicy(Constants.vantage_adpolicy_power_power_smart_settings, booleanValue);
            }
        }

        [Then(@"Power Smart Settings and Jump to Settings should be (visible|not visible)")]
        public void ThenPowerSmartSettingsSectionVisible(string visibility)
        {
            _IntelligentCoolingPage = new IntelligentCoolingPages(_AppDriver.Session);

            bool shouldBeVisible = visibility == "visible" ? true : false;

            if (shouldBeVisible)
            {
                Assert.IsNotNull(_IntelligentCoolingPage.PowerSmartSettingsTitle, "Power Smart Settings section should be visibile");
                Assert.IsNotNull(_IntelligentCoolingPage.HSJumpToSmartSettings, "Power Smart Settings jump to settings should be visibile");
            }
            else
            {
                List<Task> allTasks = new List<Task>()
                {
                    Task.Run(() => Assert.IsNull(_IntelligentCoolingPage.PowerSmartSettingsTitle, "Power Smart Settings section should be not visibile")),
                    Task.Run(() => Assert.IsNull(_IntelligentCoolingPage.HSJumpToSmartSettings, "Power Smart Settings jump to settings should be not visibile")),
                };

                Task.WaitAll(allTasks.ToArray());
            }
        }

        [StepDefinition(@"AdPolicy for all features on PowerSmartSettings page are set to (enabled|disabled|not configured)")]
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
