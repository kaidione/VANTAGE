using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class VFC_1996_StandbyAdPolicySteps
    {
        private readonly InformationalWebDriver _AppDriver;
        private HSPowerSettingsPage _hSPowerSettingsPage;

        public VFC_1996_StandbyAdPolicySteps(InformationalWebDriver appDriver)
        {
            _AppDriver = appDriver;
        }

        [Given(@"Standby adpolicy is (enabled|disabled)")]
        [When(@"Standby adpolicy is (enabled|disabled)")]
        public void GivenSetStandbyAdpolicyToDisabled(string status)
        {
            bool stateValue = status.ToLower().Equals("enabled") ? true : false;
            AdPolicyRegistryHelper.SetStandbyAdPolicy(isEnabled: stateValue);
        }

        [Given(@"Standby adpolicy is not configured")]
        public void AdPolicyIsNotConfigured()
        {
            AdPolicyRegistryHelper.DeleteKey(Constants.vantage_adpolicy_power_standby_settings);
        }

        [Then(@"Check the standby registry value is (ON|OFF)")]
        public void CheckStandbyRegistryValue(ToggleState state)
        {
            int stateValue = state == ToggleState.On ? 1 : 0;
            var registryValue = RegistryHelp.GetRegistryKeyValue(Constants.vantage_registry_standby);
            Assert.AreEqual(registryValue, stateValue, "The check for standby registry value failed");
        }


        [Given(@"Turn (ON|OFF) Smart standby toggle")]
        [When(@"Turn (ON|OFF) Smart standby toggle")]
        public void WhenTurnOnPowerStandby(ToggleState state)
        {
            _hSPowerSettingsPage = new Pages.HSPowerSettingsPage(_AppDriver.Session);
            _hSPowerSettingsPage.SetCheckBoxStatus(_hSPowerSettingsPage.SmartStandbyTToggle, state);
        }

        [Then(@"the Smart standby toggle should be (ON|OFF)")]
        [When(@"the Smart standby toggle should be (ON|OFF)")]
        public void CheckSmartStandbyToggle(ToggleState state)
        {
            HSPowerSettingsPage _hsPowerSettingsPage = new HSPowerSettingsPage(_AppDriver.Session);
            ToggleState toggleStatus = _hsPowerSettingsPage.GetCheckBoxStatus(_hsPowerSettingsPage.SmartStandbyTToggle);
            Assert.AreEqual(state, toggleStatus, "The smart standby toggle value check failed");
        }

        [Then(@"the Automatic Mode should be selected")]
        [When(@"the Automatic Mode should be selected")]
        public void AutomaticModeIsSelected()
        {
            HSPowerSettingsPage _hsPowerSettingsPage = new HSPowerSettingsPage(_AppDriver.Session);
            ToggleState autoModeStatus = _hsPowerSettingsPage.GetCheckBoxStatus(_hsPowerSettingsPage.SmartStandbyTAutoOption);
            Assert.AreEqual(ToggleState.On, autoModeStatus, "Standby Automatic Mode is not selected");
        }

        [Then(@"the standby section should not be visible")]
        public void StandbyNotVisible()
        {
            var hsPowerSettingsPage = new HSPowerSettingsPage(_AppDriver.Session);
            List<Task> allTasks = new List<Task>()
            {
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStandbyTFeatureDescription, "Smart Standby descrition should not be present")),
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStandbyTFeatureTitle, "Smart Standby title should not be present")),
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStandbyTQuestionMark, "Smart Standby question mark should not be present")),
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStandbyJumpLink, "Smart Standby jump to settings should not be present")),
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStandbyTToggle, "Smart Standby toggle should not be present")),
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStandbyTAutoOption, "Smart Standby auto option should not be present")),
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStandbyTAutoScheduleTip, "Smart Standby auto should not be present")),
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStandbyTManualOption, "Smart Standby manual option should not be present")),
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStandbyTManualScheduleTitle, "Smart Standby schedule title should not be present")),
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStandbyTManualScheduleDays, "Smart Standby schedule days should not be present")),
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStandbyTManualScheduleTime, "Smart Standby schedule time should not be present")),
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStandbyTManualScheduleChangeLink, "Smart Standby schedule link should not be present")),
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStandbyTManualScheduleCollapseLink, "Smart Standby schedule collapse link should not be present")),
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStandbyTManualScheduleGraphLink, "Smart Standby manual schedule graph link should not be present")),
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStadbyStartHoursTitle, "Smart Standby start hour should not be present")),
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStadbyStartMinutesTitle, "Smart Standby start minutes should not be present")),
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStadbyStartAMPMTitle, "Smart Standby AM/PM should not be present")),
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStadbyEndHoursTitle, "Smart Standby end hours should not be present")),
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStadbyEndMinutesTitle, "Smart Standby end minutes should not be present")),
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStadbyEndAMPMTitle, "Smart Standby end AM/PM should not be present")),
                Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStandbyTComputerScheduleTitle, "Smart Standby computer schedule title should not be present")),
            };

            Task.WaitAll(allTasks.ToArray());
        }


        [Then(@"the standby section should be visible")]
        [When(@"the standby section should be visible")]
        public void StandbyBeVisible()
        {
            var hsPowerSettingsPage = new HSPowerSettingsPage(_AppDriver.Session);
            Assert.IsNotNull(hsPowerSettingsPage.SmartStandbyTFeatureDescription, "Smart Standby descrition should be present");
            Assert.IsNotNull(hsPowerSettingsPage.SmartStandbyTQuestionMark, "Smart Standby question mark should be present");
            Assert.IsNotNull(hsPowerSettingsPage.SmartStandbyTFeatureTitle, "Smart Standby title should be present");
            Assert.IsNotNull(hsPowerSettingsPage.SmartStandbyJumpLink, "Smart Standby jump to settings should be present");
            Assert.IsNotNull(hsPowerSettingsPage.SmartStandbyTToggle, "Smart Standby toggle should be present");
            Assert.IsNotNull(hsPowerSettingsPage.SmartStandbyTManualOption, "Smart Standby manual option should be present");
            Assert.IsNotNull(hsPowerSettingsPage.SmartStandbyTAutoOption, "Smart Standby auto option should be present");
            Assert.IsNotNull(hsPowerSettingsPage.SmartStandbyTManualScheduleGraphLink, "Smart Standby schedule graph link option should be present");
            Assert.IsNotNull(hsPowerSettingsPage.SmartStandbyTComputerScheduleTitle, "Smart Standby computer schedule title option should be present");

            var standbyToggle = hsPowerSettingsPage.GetCheckBoxStatus(hsPowerSettingsPage.SmartStandbyTToggle);
            var manualToggleOn = hsPowerSettingsPage.GetCheckBoxStatus(hsPowerSettingsPage.SmartStandbyTManualOption);
            var automaticToggleOn = hsPowerSettingsPage.GetCheckBoxStatus(hsPowerSettingsPage.SmartStandbyTAutoOption);
            if (manualToggleOn == ToggleState.On && standbyToggle == ToggleState.On)
            {
                Assert.IsNotNull(hsPowerSettingsPage.SmartStandbyTManualScheduleTitle, "Smart Standby schedule title should be present");
                Assert.IsNotNull(hsPowerSettingsPage.SmartStandbyTManualScheduleDays, "Smart Standby schedule days should be present");
                Assert.IsNotNull(hsPowerSettingsPage.SmartStandbyTManualScheduleTime, "Smart Standby schedule time should be present");
                Assert.IsNotNull(hsPowerSettingsPage.SmartStandbyTManualScheduleChangeLink, "Smart Standby schedule link should be present");

                Assert.IsNull(hsPowerSettingsPage.SmartStandbyTAutoScheduleTip, "Smart Standby auto should be present");
            }
            else
            {
                Task.WaitAll(new Task[]{
                    Task.Run(() =>
                    {
                        if(standbyToggle == ToggleState.On)
                            Assert.IsNotNull(hsPowerSettingsPage.SmartStandbyTAutoScheduleTip, "Smart Standby auto should be present");
                    }),

                    Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStandbyTManualScheduleTitle, "Smart Standby schedule title should not be present")),
                    Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStandbyTManualScheduleDays, "Smart Standby schedule days should not be present")),
                    Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStandbyTManualScheduleTime, "Smart Standby schedule time should not be present")),
                    Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStandbyTManualScheduleChangeLink, "Smart Standby schedule link should not be present")),
                    Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStadbyStartHoursTitle, "Smart Standby start hour should not be present")),
                    Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStadbyStartMinutesTitle, "Smart Standby start minutes should not be present")),
                    Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStadbyStartAMPMTitle, "Smart Standby AM/PM should not be present")),
                    Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStadbyEndHoursTitle, "Smart Standby end hours should not be present")),
                    Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStadbyEndMinutesTitle, "Smart Standby end minutes should not be present")),
                    Task.Run(() => Assert.IsNull(hsPowerSettingsPage.SmartStadbyEndAMPMTitle, "Smart Standby end AM/PM should not be present")),
                });
            }
        }

        [BeforeFeature("VFC1996_Standby")]
        public static void BeforeFeature()
        {
            AdPolicyRegistryHelper.DeleteKey(Constants.vantage_adpolicy_power_standby_settings);
        }

        [AfterScenario("VFC1996_Standby")]
        public void BeforeScenario()
        {
            AdPolicyIsNotConfigured();
        }
    }
}
