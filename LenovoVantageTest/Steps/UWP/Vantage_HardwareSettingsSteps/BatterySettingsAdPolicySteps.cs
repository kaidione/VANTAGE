using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class BatterySettingsAdPolicySteps
    {
        private readonly InformationalWebDriver _AppDriver;
        private HSPowerSettingsPage _HSPowerSettingsPage;
        private SettingsBase _SettingsBase;

        public BatterySettingsAdPolicySteps(InformationalWebDriver appDriver)
        {
            _AppDriver = appDriver;
        }

        #region BeforeScenario
        [BeforeScenario("BatterySettings_AdPolicy")]
        [BeforeScenario("BatterySettings_NoSupport_AdPolicy")]
        public static void BeforeScenario()
        {
            DeleteAdPolicyKey(Constants.vantage_adpolicy_power_battery_settings);
        }
        #endregion

        #region AfterScenario
        [AfterScenario("BatterySettings_AdPolicy")]
        [AfterScenario("BatterySettings_NoSupport_AdPolicy")]
        public void AfterScenario()
        {
            UpdateAdPolicyForAllFeaturesOnSection("not configured");
        }
        #endregion

        public static void DeleteAdPolicyKey(string keyToDelete)
        {
            AdPolicyRegistryHelper.DeleteKey(keyToDelete);
        }

        public bool IsThinkPadDevice()
        {
            return VantageCommonHelper.IsThinkPad();
        }

        [StepDefinition(@"Battery Settings AdPolicy is set to (enabled|disabled|not configured)")]
        public void UpdateAdPolicyForSection(string status)
        {
            if (status == "not configured")
            {
                DeleteAdPolicyKey(Constants.vantage_adpolicy_power_battery_settings);
            }
            else
            {
                bool booleanValue = status == "enabled" ? true : false;
                AdPolicyRegistryHelper.SetAdPolicy(Constants.vantage_adpolicy_power_battery_settings, booleanValue);
            }
        }

        [Then(@"Battery Settings and Jump to Settings should be (visible|not visible)")]
        public void ThenBatterySettingsSectionVisible(string visibility)
        {
            _HSPowerSettingsPage = new HSPowerSettingsPage(_AppDriver.Session);

            bool shouldBeVisible = visibility == "visible" ? true : false;

            if (shouldBeVisible)
            {
                Assert.IsNotNull(_HSPowerSettingsPage.JumpToBatterySettings, "Battery settings jump to settings link should be visibile");
                Assert.IsNotNull(_HSPowerSettingsPage.BatterySettingsSectionTitle, "Battery settings section title should be visibile");
                if (IsThinkPadDevice())
                {
                    Assert.IsNotNull(_HSPowerSettingsPage.BatteryChargeThresholdTitle, "Battery Charge Threshold title should be visibile");
                    Assert.IsNotNull(_HSPowerSettingsPage.BatteryChargeThresholdCaption, "Battery Charge Threshold caption should be visibile");
                    Assert.IsNotNull(_HSPowerSettingsPage.HSBatteryGuageResetTitle, "Battery Gauge title should be visibile");
                    Assert.IsNotNull(_HSPowerSettingsPage.HSBatteryGuageResetCaption, "Battery Gauge title should be visibile");
                }
                else
                {
                    Assert.IsNotNull(_HSPowerSettingsPage.RapidChargeTitle, "Rapid Charge title should be visibile");
                    Assert.IsNotNull(_HSPowerSettingsPage.RapidChargeCaptionId, "Rapid Charge caption should be visibile");
                    Assert.IsNotNull(_HSPowerSettingsPage.RapidChargeCheckbox, "Rapid Charge checkbox should be visibile");
                    Assert.IsNotNull(_HSPowerSettingsPage.ConservationModeTitle, "Conservation Mode title should be visibile");
                    Assert.IsNotNull(_HSPowerSettingsPage.ConservationModeCaptionId, "Conservation Mode caption should be visibile");
                    Assert.IsNotNull(_HSPowerSettingsPage.ConservationModeCheckboxId, "Conservation Mode checkbox should be visibile");
                }
            }
            else
            {
                List<Task> allTasks = new List<Task>() {
                    Task.Run(() => Assert.IsNull(_HSPowerSettingsPage.JumpToBatterySettings, "Battery settings jump to settings link should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSPowerSettingsPage.BatterySettingsSectionTitle, "Battery settings section title should be not visibile"))
                };

                List<Task> specificModelTasks = GetTasksForSpecificModel();
                allTasks.AddRange(specificModelTasks);

                Task.WaitAll(allTasks.ToArray());
            }
        }

        [StepDefinition(@"AdPolicy for all features on BatterySettings page are set to (enabled|disabled|not configured)")]
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

        [StepDefinition(@"Click Power Section Link on Menu")]
        public bool GoToPowerPageIfAvailable()
        {
            _SettingsBase = new SettingsBase(_AppDriver.Session);
            try
            {
                _SettingsBase.MySettingsMenuDropClickFunction();
                if (_SettingsBase.MySettingsPowerMenuEle == null)
                {
                    _SettingsBase.MySettingsMenuDropClickFunction();
                }
                else
                {
                    _SettingsBase.MySettingsPowerMenuEle.Click();
                    _SettingsBase.MySettingsMenuDropClickFunction();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Power page was not present because AD Policy for all features are enabled");
                return true;
            }
        }

        [StepDefinition(@"Go to Device Section to check Power Tab")]
        public bool GoToDeviceSection()
        {
            _SettingsBase = new SettingsBase(_AppDriver.Session);
            _SettingsBase.MySettingsMenuDropClickFunction();
            if (_SettingsBase.MySettingsPowerMenuEle == null)
            {
                _SettingsBase.AudioSettingsPage.Click();
            }
            else
            {
                _SettingsBase.MySettingsPowerMenuEle.Click();
            }
            return true;
        }

        [Then(@"Power (Link|Tab) element should be (visible|not visible)")]
        public void CheckTabVisibility(string element, string visibility)
        {
            _SettingsBase = new SettingsBase(_AppDriver.Session);
            bool shouldBeVisible = visibility == "visible" ? true : false;
            WindowsElement elementToCheck = element == "Tab" ? _SettingsBase.MySettingsPower : _SettingsBase.MySettingsPowerMenuEle;
            if (shouldBeVisible)
            {
                Assert.IsNotNull(elementToCheck);
            }
            else
            {
                Assert.IsNull(elementToCheck);
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

        public List<Task> GetTasksForSpecificModel()
        {
            List<Task> specificModelTasks = new List<Task>();

            if (IsThinkPadDevice())
            {
                specificModelTasks = new List<Task>(){
                    Task.Run(() => Assert.IsNull(_HSPowerSettingsPage.BatteryChargeThresholdTitle, "Battery Charge Threshold title should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSPowerSettingsPage.BatteryChargeThresholdCaption, "Battery Charge Threshold title should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSPowerSettingsPage.HSBatteryGuageResetTitle, "Battery Gauge title should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSPowerSettingsPage.HSBatteryGuageResetCaption, "Battery Gauge title should be not visibile")),
                };
            }
            else
            {
                specificModelTasks = new List<Task>(){
                    Task.Run(() => Assert.IsNull(_HSPowerSettingsPage.RapidChargeTitle, "Rapid Charge title should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSPowerSettingsPage.RapidChargeCaptionId, "Rapid Charge caption should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSPowerSettingsPage.RapidChargeCheckbox, "Rapid Charge checkbox should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSPowerSettingsPage.ConservationModeTitle, "Conservation Mode title should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSPowerSettingsPage.ConservationModeCaptionId, "Conservation Mode caption should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSPowerSettingsPage.ConservationModeCheckboxId, "Conservation Mode checkbox should be not visibile"))
                };
            }

            return specificModelTasks;
        }
    }
}
