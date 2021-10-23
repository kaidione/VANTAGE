using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;

namespace LenovoVantageTest.Pages.HardwareSettingsPages
{
    class HSDispalyCameraPage : SettingsBase
    {
        private WindowsDriver<WindowsElement> session;
        public WindowsElement VantageMinizeElement => GetElement(session, "XPath", VantageMinizeId);
        public WindowsElement privacyGaugeToggle => GetElement(session, "AutomationId", "privacy-guard_checkbox");
        public WindowsElement CameraTitle => GetElement(session, "AutomationId", "device-settings-camera-collapse-card-title");
        public WindowsElement CameraBlurCheckBox => GetElement(session, "AutomationId", "device-settings-camera-blur_checkbox");
        public WindowsElement blurModeRadio => GetElement(session, "AutomationId", "radio1");
        public WindowsElement comicModeRadio => GetElement(session, "AutomationId", "radio2");
        public WindowsElement sketchModeRadio => GetElement(session, "AutomationId", "radio3");
        public WindowsElement cameraBlurBg => GetElement(session, "AutomationId", "camera-background-blur-blur-mode");
        public WindowsElement cameraComicBg => GetElement(session, "AutomationId", "camera-background-blur-comic-mode");
        public WindowsElement cameraSketchBg => GetElement(session, "AutomationId", "camera-background-blur-sketch-mode");
        public WindowsElement CameraLink => GetElement(session, "AutomationId", "jumptoSetting-camera");
        public WindowsElement CameraPrivacyTitle => GetElement(session, "AutomationId", "camera-privacy-mode-title");
        public WindowsElement CameraBlurTitle => GetElement(session, "AutomationId", "device-settings-camera-blur-title");
        public WindowsElement CameraBlurCaption => GetElement(session, "AutomationId", "device-settings-camera-blur-caption");
        public WindowsElement DisplayLink => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.DisplayLink"), 10);
        public WindowsElement DisplayTitle => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.DisplayCardTitle"), 10);
        public WindowsElement DisplayColorTemperatureTitle => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.ECMTitle"), 10);
        public WindowsElement DisplayColorTemperatureCaption => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.RemoveECMDescription"), 10);
        public WindowsElement DisplayColorTemperatureHereLink => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.ECMHere"), 10);
        //OLED Power Settings
        public WindowsElement OLEDPowerSettingsTitleID => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsTitleID"));
        public WindowsElement OLEDPowerSettingsDescription1ID => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsDescription1ID"));
        public WindowsElement OLEDPowerSettingsDescription2ID => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsDescription2ID"));
        public WindowsElement OLEDPowerSettingsTASKBARDIMMER => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsTASKBARDIMMER"));
        public WindowsElement OLEDPowerSettingsBACKGROUNDDIMMER => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsBACKGROUNDDIMMER"));
        public WindowsElement OLEDPowerSettingsDISPLAYDIMMER => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsDISPLAYDIMMER"));
        public WindowsElement OLEDPowerSettingsTASKBARDIMMERMenuList => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsTASKBARDIMMERMenuList"));
        public WindowsElement OLEDPowerSettingsBACKGROUNDDIMMERMenuList => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsBACKGROUNDDIMMERMenuList"));
        public WindowsElement OLEDPowerSettingsDISPLAYDIMMERMenuList => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsDISPLAYDIMMERMenuList"));
        public WindowsElement OLEDPowerSettingsMenuList1 => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsMenuList1"));
        public WindowsElement OLEDPowerSettingsMenuList2 => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsMenuList2"));
        public WindowsElement OLEDPowerSettingsMenuList3 => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsMenuList3"));
        public WindowsElement OLEDPowerSettingsMenuList4 => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsMenuList4"));
        public WindowsElement OLEDPowerSettingsMenuList5 => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsMenuList5"));
        public WindowsElement OLEDPowerSettingsMenuList6 => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsMenuList6"));
        public WindowsElement OLEDPowerSettingsMenuList7 => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsMenuList7"));
        public WindowsElement OLEDPowerSettingsMenuList8 => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsMenuList8"));
        public WindowsElement OLEDPowerSettingsMenuList9 => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsMenuList9"));
        public WindowsElement OLEDPowerSettingsMenuList10 => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsMenuList10"));
        public WindowsElement OLEDPowerSettingsMenuList11 => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsMenuList11"));
        public WindowsElement DayTimeColorTempSlider => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.DayTimeColorTempSlider"));
        public WindowsElement ColorTempEyeCareModeSlider => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.ColorTempEyeCareModeSlider"));
        public WindowsElement ColorTempEyeCareModeCheckBox => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.ColorTempEyeCareModeCheckBox"));
        public WindowsElement CbEyeCareScheduleCheckBox => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CbEyeCareScheduleCheckBox"));
        public WindowsElement DayTimeColorTempResetBtn => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.DayTimeColorTempResetBtn"));
        public WindowsElement ColorTempEyeCareModeResetBtn => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.ColorTempEyeCareModeResetBtn"));
        public WindowsElement DayTimeColorTempQuickMark => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.DayTimeColorTempQuickMark"));
        public WindowsElement DayTimeColorTempNote => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.DayTimeColorTempNote"));
        public List<WindowsElement> CbEyeCareScheduleCheckBoxNames => base.FindElementsByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CbEyeCareScheduleCheckBoxNames"));
        public WindowsElement DayTimeColordisplaySettingsLocationTitle => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.DayTimeColordisplaySettingsLocationTitle"));
        public WindowsElement DayTimeColordisplaySettingsLocationLink => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.DayTimeColordisplaySettingsLocationLink"));
        public WindowsElement ColorTempEyeCareModeTooltipRightIcon => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.ColorTempEyeCareModeTooltipRightIcon"));

        //LE Camera and Camera Privacy
        public WindowsElement CameraPrivacyModeToolTipRightIcon => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraPrivacyModeToolTipRightIcon"));
        public WindowsElement CameraPrivacyModeToolTip => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraPrivacyModeToolTip"));
        public WindowsElement CameraPrivacyModeTitle => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraPrivacyModeTitle"), 10);
        public WindowsElement CameraPrivacyModeCaption => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraPrivacyModeCaption"), 10);
        public WindowsElement CameraResetButton => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraResetBtn"), 10);
        public WindowsElement CameraPrivacyToggle => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.privacyToggle"), 10);
        public WindowsElement CameraPreview => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraPreview"), 10);
        public WindowsElement CameraPrivacyQuestionMark => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraPrivacyQuestionMark"), 10);
        public WindowsElement CameraBrightnessTitle => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraBrightness"), 10);
        public WindowsElement CameraBrightnessSlider => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraBrightnessSlider"), 10);
        public WindowsElement CameraContrastTitle => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraContrast"), 10);
        public WindowsElement CameraContrastSlider => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraContrastSlider"), 10);
        public WindowsElement CameraAutoExposureTitle => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraAutoExposure"), 10);
        public WindowsElement CameraAutoExposureSlider => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraAutoExposureSlider"), 10);
        public WindowsElement CameraAutoExposureBtn => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraAutoExposureBtn"), 10);
        public WindowsElement DayTimeColorTempToolTip => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.DayTimeColorTempToolTip"), 10);
        public HSDispalyCameraPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
            base.session = session;
        }

    }
}
