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
    public class StandbySettingsAdPolicySteps
    {
        private readonly InformationalWebDriver _AppDriver;
        private HSPowerSettingsPage _HSPowerSettingsPage;
        private SettingsBase _SettingsBase;

        public StandbySettingsAdPolicySteps(InformationalWebDriver appDriver)
        {
            _AppDriver = appDriver;
        }

        #region BeforeScenario
        [BeforeScenario("StandBySettings_AdPolicy")]
        [BeforeScenario("StandBySettings_NoSupport_AdPolicy")]
        public static void BeforeScenarion()
        {
            DeleteAdPolicyKey(Constants.vantage_adpolicy_power_standby_settings);
        }
        #endregion

        #region AfterScenario
        [AfterScenario("StandBySettings_AdPolicy")]
        [AfterScenario("StandBySettings_NoSupport_AdPolicy")]
        public void AfterScenario()
        {
            UpdateAdPolicyForAllFeaturesOnSection("not configured");
        }
        #endregion

        public static void DeleteAdPolicyKey(string keyToDelete)
        {
            AdPolicyRegistryHelper.DeleteKey(keyToDelete);
        }

        [StepDefinition(@"Standby Settings AdPolicy is set to (enabled|disabled|not configured)")]
        public void UpdateAdPolicyForSection(string status)
        {
            if (status == "not configured")
            {
                DeleteAdPolicyKey(Constants.vantage_adpolicy_power_standby_settings);
            }
            else
            {
                bool booleanValue = status == "enabled" ? true : false;
                AdPolicyRegistryHelper.SetAdPolicy(Constants.vantage_adpolicy_power_standby_settings, booleanValue);
            }
        }

        [Then(@"Standby Settings and Jump to Settings should be (visible|not visible)")]
        public void ThenStandbySettingsSectionVisible(string visibility)
        {
            _HSPowerSettingsPage = new HSPowerSettingsPage(_AppDriver.Session);

            bool shouldBeVisible = visibility == "visible" ? true : false;

            if (shouldBeVisible)
            {
                Assert.IsNotNull(_HSPowerSettingsPage.StandBySettingsTitle, "Standby Settings section should be visibile");
                Assert.IsNotNull(_HSPowerSettingsPage.SmartStandbyTFeatureTitle, "Smart Standby title should be visibile");
                Assert.IsNotNull(_HSPowerSettingsPage.SmartStandbyTFeatureDescription, "Standby Settings description should be visibile");
                Assert.IsNotNull(_HSPowerSettingsPage.SmartStandbyTManualScheduleGraphLink, "Standby Settings modal link should be visibile");
                Assert.IsNotNull(_HSPowerSettingsPage.SmartStandbyJumpLink, "Smart Standby jump to settings link should be visibile");
            }
            else
            {
                List<Task> allTasks = new List<Task>()
                {
                    Task.Run(() => Assert.IsNull(_HSPowerSettingsPage.StandBySettingsTitle, "Standby Settings section should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSPowerSettingsPage.SmartStandbyTFeatureTitle, "Smart Standby title should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSPowerSettingsPage.SmartStandbyTFeatureDescription, "Standby Settings description should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSPowerSettingsPage.SmartStandbyTManualScheduleGraphLink, "Standby Settings modal link should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSPowerSettingsPage.SmartStandbyJumpLink, "Smart Standby jump to settings link should be not visibile")),
                };

                Task.WaitAll(allTasks.ToArray());
            }
        }

        [StepDefinition(@"AdPolicy for all features on StandbySettings page are set to (enabled|disabled|not configured)")]
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

        [StepDefinition(@"Click Power Link on Menu")]
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
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Power page was not present because AD Policy for all features are enabled");
                return true;
            }
        }

        [StepDefinition(@"Open Menu to check power link")]
        public bool CheckLinkOnMenu()
        {
            _SettingsBase = new SettingsBase(_AppDriver.Session);
            _SettingsBase.MySettingsMenuDropClickFunction();
            return true;
        }

        [StepDefinition(@"Go to Device Section to check Tab")]
        public bool GoToDeviceSection()
        {
            _SettingsBase = new SettingsBase(_AppDriver.Session);
            _SettingsBase.MySettingsMenuDropClickFunction();
            if (_SettingsBase.MySettingsPowerMenuEle == null)
            {
                WindowsElement windowsElement = VantageCommonHelper.FindElementByXPath(_AppDriver.Session, "//*[contains(@AutomationId,'menu-main-nav-lnk-dropdown-menu-device-device-settings-')]", 10);
                if (windowsElement != null)
                {
                    windowsElement.Click();
                }
            }
            else
            {
                _SettingsBase.MySettingsPowerMenuEle.Click();
            }
            return true;
        }

        [Then(@"Power (Link|Tab) should be (visible|not visible)")]
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
    }
}
