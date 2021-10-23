using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class DisplayCameraSteps
    {
        private readonly InformationalWebDriver _AppDriver;
        private HSDispalyCameraPage _HSDisplayCameraPage;
        private HSQuickSettingsPage _HSQuickSettingsPage;
        private SettingsBase _SettingsBase;

        public DisplayCameraSteps(InformationalWebDriver appDriver)
        {
            _AppDriver = appDriver;
        }

        #region BeforeScenario & AfterScenario
        [BeforeScenario("Camera_AdPolicy")]
        [AfterScenario("Camera_AdPolicy")]
        public static void CameraBeforeAfterScenario()
        {
            DeleteAdPolicyKey(Constants.vantage_adpolicy_camera);
            Common.enableCameraDriver(true);
        }

        [BeforeScenario("Display_AdPolicy")]
        [AfterScenario("Display_AdPolicy")]
        public static void DisplayBeforeAfterScenario()
        {
            DeleteAdPolicyKey(Constants.vantage_adpolicy_display);
        }

        [BeforeScenario("DisplayCamera_AdPolicy")]
        [AfterScenario("DisplayCamera_AdPolicy")]
        public static void DisplayCameraBeforeAfterScenario()
        {
            DisplayBeforeAfterScenario();
            CameraBeforeAfterScenario();
        }
        #endregion

        public static void DeleteAdPolicyKey(string keyToDelete)
        {
            AdPolicyRegistryHelper.DeleteKey(keyToDelete);
        }

        [StepDefinition(@"(Camera|Display) adpolicy is set to (enabled|disabled|not configured)")]
        public void UpdateAdPolicyForSection(string section, string status)
        {
            string adPolicyKey = section == "Display" ? Constants.vantage_adpolicy_display : Constants.vantage_adpolicy_camera;
            if (status == "not configured")
            {
                DeleteAdPolicyKey(adPolicyKey);
            }
            else
            {
                bool booleanValue = status == "enabled" ? true : false;
                AdPolicyRegistryHelper.SetAdPolicy(adPolicyKey, booleanValue);
            }

            Thread.Sleep(2000);
        }

        [StepDefinition(@"Go to Display & Camera page")]
        public void GoToDisplayPage()
        {
            _HSQuickSettingsPage = new HSQuickSettingsPage(_AppDriver.Session);
            _HSQuickSettingsPage.GotoMySettingsDisplayCameraPage();
        }

        [Then(@"camera section and jump to settings should be (visible|not visible)")]
        public void ThenCameraSectionVisible(string visibility)
        {
            _HSDisplayCameraPage = new HSDispalyCameraPage(_AppDriver.Session);

            bool shouldBeVisible = visibility == "visible" ? true : false;

            if (shouldBeVisible)
            {
                Assert.IsNotNull(_HSDisplayCameraPage.CameraLink, "Camera Jump to Settings link should be visibile");
                Assert.IsNotNull(_HSDisplayCameraPage.CameraTitle, "Camera Section title should be visibile");
                Assert.IsNotNull(_HSDisplayCameraPage.CameraPrivacyModeTitle, "Camera Privacy Mode Title should be visibile");
                Assert.IsNotNull(_HSDisplayCameraPage.CameraPrivacyModeCaption, "Camera Privacy Mode Caption should be visibile");
                Assert.IsNotNull(_HSDisplayCameraPage.CameraResetButton, "Camera Reset Button should be visibile");
                Assert.IsNotNull(_HSDisplayCameraPage.CameraPrivacyToggle, "Camera Privacy Toggle should be visibile");
                Assert.IsNotNull(_HSDisplayCameraPage.CameraPreview, "Camera Preview should be visibile");
                Assert.IsNotNull(_HSDisplayCameraPage.CameraPrivacyQuestionMark, "Camera privacy question mark should be visibile");
                Assert.IsNotNull(_HSDisplayCameraPage.CameraBrightnessTitle, "Camera brightness title should be visibile");
                Assert.IsNotNull(_HSDisplayCameraPage.CameraBrightnessSlider, "Camera brightness slider should be visibile");
                Assert.IsNotNull(_HSDisplayCameraPage.CameraContrastTitle, "Camera contrast title should be visibile");
                Assert.IsNotNull(_HSDisplayCameraPage.CameraContrastSlider, "Camera contrast slider should be visibile");
                Assert.IsNotNull(_HSDisplayCameraPage.CameraAutoExposureTitle, "Camera auto exposure title should be visibile");
                Assert.IsNotNull(_HSDisplayCameraPage.CameraAutoExposureBtn, "Camera auto exposure button should be visibile");
            }
            else
            {
                List<Task> allTasks = new List<Task>()
                {
                    Task.Run(() => Assert.IsNull(_HSDisplayCameraPage.CameraLink, "Camera Jump to Settings link should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSDisplayCameraPage.CameraTitle, "Camera Section title should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSDisplayCameraPage.CameraPrivacyModeTitle, "Camera Privacy Mode Title should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSDisplayCameraPage.CameraPrivacyModeCaption, "Camera Privacy Mode Caption should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSDisplayCameraPage.CameraResetButton, "Camera Reset Button should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSDisplayCameraPage.CameraPrivacyToggle, "Camera Privacy Toggle should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSDisplayCameraPage.CameraPreview, "Camera Preview should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSDisplayCameraPage.CameraPrivacyQuestionMark, "Camera privacy question mark should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSDisplayCameraPage.CameraBrightnessTitle, "Camera brightness title should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSDisplayCameraPage.CameraBrightnessSlider, "Camera brightness slider should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSDisplayCameraPage.CameraContrastTitle, "Camera contrast title should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSDisplayCameraPage.CameraContrastSlider, "Camera contrast slider should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSDisplayCameraPage.CameraAutoExposureTitle, "Camera auto exposure title should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSDisplayCameraPage.CameraAutoExposureBtn, "Camera auto exposure button should be not visibile"))
                };

                Task.WaitAll(allTasks.ToArray());
            }
        }

        [Then(@"display section and jump to settings should be (visible|not visible)")]
        public void ThenDisplaySectionVisible(string visibility)
        {
            _HSDisplayCameraPage = new HSDispalyCameraPage(_AppDriver.Session);

            bool shouldBeVisible = visibility == "visible" ? true : false;
            if (shouldBeVisible)
            {
                Assert.IsNotNull(_HSDisplayCameraPage.DisplayLink, "Display Jump to Settings link should be visibile");
                Assert.IsNotNull(_HSDisplayCameraPage.DisplayTitle, "Display section title should be visibile");
            }
            else
            {
                List<Task> allTasks = new List<Task>()
                {
                    Task.Run(() => Assert.IsNull(_HSDisplayCameraPage.DisplayLink, "Display Jump to Settings link should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSDisplayCameraPage.DisplayTitle, "Display section title should be not visibile"))
                };

                Task.WaitAll(allTasks.ToArray());
            }
        }

        [StepDefinition(@"Click Device dropdown menu")]
        public void ClickDeviceMenu()
        {
            _SettingsBase = new SettingsBase(_AppDriver.Session);
            _SettingsBase.GoToMyDevicesSettings();
            _SettingsBase.MySettingsMenuDropClickFunction();
            if (_SettingsBase.MySettingsMenuDropDownEle == null)
            {
                _SettingsBase.MySettingsMenuDropClickFunction();
            }
        }

        [StepDefinition(@"Go to Device Settings page")]
        public void GoToDeviceSettingsPage()
        {
            _SettingsBase = new SettingsBase(_AppDriver.Session);
            _SettingsBase.GoToMyDevicesSettings();
            _SettingsBase.MySettingsMenuDropClickFunction();
            if (_SettingsBase.MySettingsMenuDropDownEle == null)
            {
                _SettingsBase.MySettingsMenuDropClickFunction();
            }
            _SettingsBase.MySettingsPowerMenuEle.Click();
        }

        [Then(@"the element (Display & Camera tab|Display & Camera link) should be (visible|not visible)")]
        public void CheckTabVisibility(string element, string visibility)
        {
            bool shouldBeVisible = visibility == "visible" ? true : false;
            WindowsElement elementToCheck = element == "Display & Camera tab" ? _SettingsBase.MySettingsDisplay : _SettingsBase.DisplayCameraSettingsPageMenuLink;
            if (shouldBeVisible)
            {
                Assert.IsNotNull(elementToCheck);
            }
            else
            {
                Assert.IsNull(elementToCheck);
            }
        }
    }
}
