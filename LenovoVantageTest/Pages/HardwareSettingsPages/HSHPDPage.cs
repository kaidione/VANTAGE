using LenovoVantageTest.Helper;
using OpenQA.Selenium.Appium.Windows;
using SmartSenseHsaRpcClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Automation;
using TangramTest.Utility;
using static SmartSenseHsaRpcClient.HumanPresenceDetection;

namespace LenovoVantageTest.Pages.HardwareSettingsPages
{
    public class HSHPDPage : SettingsBase
    {
        public WindowsDriver<WindowsElement> session;
        public HumanPresenceDetection rpcClient = null;

        public HSHPDPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
            base.session = session;
            GetHPDCapability();
        }

        #region AutomationId
        public WindowsElement DeviceMenuLink => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Navbar.device"));
        public WindowsElement MyDeviceSettingsLink => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Navbar.device_setting_link"));
        public WindowsElement DisplayAndCameraLink => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.displayAndCameraLink"));
        public WindowsElement CameraLink => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraLink"));
        public WindowsElement CameraPrivacyToggle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.privacyToggle"));
        public WindowsElement HPDResetButton => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDResetButton"));
        public WindowsElement HPDZeroTouchLoginCheckBox => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLoginCheckBox"));
        public WindowsElement HPDZeroTouchLoginCheckBoxThink => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLoginCheckBoxThink"));
        public WindowsElement HPDZeroTouchLoginADVSettings => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLoginADVSettings"));
        public WindowsElement HPDZeroTouchLoginADSACheckBox => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLoginADVCheckBox"));
        public WindowsElement IntelligentSecurity => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.IntelligentSecurity"));
        public WindowsElement HPDZeroTouchLoginADSASldierBar => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLoginADSASldierBar"));
        public WindowsElement HPDZeroTouchLoginADSASldierBarThink => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLoginADSASldierBarThink"));

        //Intelligent Security
        public WindowsElement IntelligentSecurityToggle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.IntelligentSecurityToggle"));
        public WindowsElement IntelligentSecurityHpdSensorNote => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.IntelligentSecurityHpdSensorNote"));
        public WindowsElement HumanPresenceSensingTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HumanPresenceSensingTitle"));

        //Intelligent Media Section
        public WindowsElement IntelligentMediaJumpLink => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='jumptoSetting-media']", 5);
        public WindowsElement ZeroTouchVideoPlaybackTitle => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='zero-touch-video-playback.toggle-button-title']", 5);
        public WindowsElement ZeroTouchVideoPlaybackToggle => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='zero-touch-video-playback.toggle-button_checkbox']", 5);
        public WindowsElement ZeroTouchVideoPlaybackToolTips => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='zero-touch-video-playback.toggle-button-tooltip_right_icon']", 5);
        public WindowsElement ZeroTouchVideoPlaybackDesc => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='zero-touch-video-playback.toggle-button-caption']", 5);
        public WindowsElement VideoResolutionUpscalingTitle => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='video-resolution-upscaling.toggle-button-title']", 5);
        public WindowsElement VideoResolutionUpscalingToggle => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='video-resolution-upscaling.toggle-button_checkbox']", 5);
        public WindowsElement VideoResolutionUpscalingQuestionIcon => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='video-resolution-upscaling.toggle-button-tooltip_right_icon']", 5);
        public WindowsElement VideoResolutionUpscalingToolTips => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='video-resolution-upscaling.toggle-button-toolTip']", 5);
        public List<WindowsElement> VideoResolutionUpscalingToolTipsText => new List<WindowsElement>(session.FindElementsByXPath("//*[@AutomationId='video-resolution-upscaling.toggle-button-toolTip']//Text"));
        public WindowsElement VideoResolutionUpscalingDescOne => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='sr-describe-one']", 5);
        public WindowsElement VideoResolutionUpscalingDescTwo => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='sr-describe-two']", 5);
        public WindowsElement VideoResolutionUpscalingImage => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='superResolution-image']", 5);
        public WindowsElement VideoResolutionUpscalingNote => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='superResolution-note-description']", 5);
        public WindowsElement VideoResolutionUpscalingNoteDescOne => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='superResolution-note-description-one']", 5);
        public WindowsElement VideoResolutionUpscalingNoteDescTwo => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='superResolution-note-description-two']", 5);
        public WindowsElement VideoResolutionUpscalingNoteDescThree => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='superResolution-note-description-three']", 5);
        public WindowsElement VideoResolutionUpscalingNoteDescFour => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='superResolution-note-description-four']", 5);

        public WindowsElement HPDZeroTouchLockCheckbox => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockCheckbox"));
        public WindowsElement HPDZeroTouchLockADVSettings => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockADVSettings"));
        public WindowsElement IntelligentSecurityNote => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.IntelligentSecurityNote"));
        public WindowsElement HPDZeroTouchLockFacialRecogoitionCheckbox => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockFacialRecogoitionCheckbox"));
        public WindowsElement HPDAutoScreenLockTimerFast => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDAutoScreenLockTimerFast"));
        public WindowsElement HPDAutoScreenLockTimerMedium => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDAutoScreenLockTimerMedium"));
        public WindowsElement HPDAutoScreenLockTimerSlow => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDAutoScreenLockTimerSlow"));
        public WindowsElement HPDZeroTouchLockADSASldierBar => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockADSASldierBar"));
        public WindowsElement HPDZeroTouchLockADSASldierBarThink => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockADSASldierBarThink"));
        public WindowsElement HPDZeroTouchLockADSACheckBox => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockADSACheckBox"));
        public WindowsElement HPDZeroTouchLoginADVSettingsTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLoginADVSettingsTitle"));
        public WindowsElement HPDZeroTouchLoginADVSettingsOnDescription => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLoginADVSettingsOnDescription"));
        public WindowsElement HPDZeroTouchLoginADVSettingsOffDescription => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLoginADVSettingsOffDescription"));
        public WindowsElement HPDZeroTouchLoginADVSettingsReadMoreMode1 => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLoginADVSettingsReadMoreMode1"));
        public WindowsElement HPDZeroTouchLoginADVSettingsReadMoreMode2 => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLoginADVSettingsReadMoreMode2"));
        public WindowsElement HPDZeroTouchLoginADVSettingsReadMoreMode3 => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLoginADVSettingsReadMoreMode3"));
        public WindowsElement HPDZeroTouchLoginADVSettingsReadMoreMode4 => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLoginADVSettingsReadMoreMode4"));
        public WindowsElement HPDZeroTouchLoginADSAWindowsHelloNote => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLoginADSAWindowsHelloNote"));
        public WindowsElement HPDZeroTouchLoginADSAWindowsHelloLink => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLoginADSAWindowsHelloLink"));
        public WindowsElement HPDZeroTouchLockTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockTitle"));
        public WindowsElement HPDZeroTouchLockDescription => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockDescription"));
        public WindowsElement HPDZeroTouchLockFaicalRecognitionTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockFaicalRecognitionTitle"));
        public WindowsElement HPDZeroTouchLockTimerTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockTimerTitle"));
        public WindowsElement HPDZeroTouchLockFaicalRecognitionDesc => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockFaicalRecognitionDesc"));
        public string SystemSettingsCameraGlobalToggleSwitch = GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.SystemSettingsCameraGlobalToggleSwitch");
        public string LenovoCompanionToggleSwitch => GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.LenovoCompanionToggleSwitch");
        public WindowsElement HPDZeroTouchLockFacialRecognitionPermissionNote => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockFacialRecognitionPermissionNote"));
        public WindowsElement HPDZeroTouchLockFacialRecognitionAccessUrl => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockFacialRecognitionAccessUrl"));
        public WindowsElement HPDZeroTouchLockFacialRecognitionPrivacyNote => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockFacialRecognitionPrivacyNote"));
        public WindowsElement HPDZeroTouchLockFacialRecognitionPrivacyUrl => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockFacialRecognitionPrivacyUrl"));
        public WindowsElement HPDZeroTouchLockAutoScreenLockTimerRightIcon => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockAutoScreenLockTimerRightIcon"));
        public WindowsElement HPDZeroTouchLockAutoScreenLockTimerToolTip => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockAutoScreenLockTimerToolTip"));
        public WindowsElement HPDZeroTouchLoginRightIcon => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLoginRightIcon"));
        public WindowsElement HPDZeroTouchLoginToolTip => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLoginToolTip"));
        public WindowsElement HPDZeroTouchLockDistanceAdjustStatusOn => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockDistanceAdjustStatusOn"));
        public WindowsElement HPDZeroTouchLockDistanceAdjustStatusOff => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockDistanceAdjustStatusOff"));
        public WindowsElement HPDZeroTouchLockDistanceAdjustReadMoreMode1 => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockDistanceAdjustReadMoreMode1"));
        public WindowsElement HPDZeroTouchLockDistanceAdjustReadMoreMode2 => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockDistanceAdjustReadMoreMode2"));
        public WindowsElement HPDZeroTouchLockDistanceAdjustReadMoreMode3 => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLockDistanceAdjustReadMoreMode3"));
        public WindowsElement HPDZeroTouchLoginTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLoginTitle"));
        public WindowsElement HPDZeroTouchLoginCaption => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLoginCaption"));
        public WindowsElement HPDImage => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDImage"));
        public WindowsElement HPDWordTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDWordTitle"));
        public WindowsElement HPDWordDescription => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDWordDescription"));
        public WindowsElement HPDZeroTouchLoginADSAWindosHelloLeLink => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.HPDZeroTouchLoginADSAWindosHelloLeLink"));
        public WindowsElement AutoScreenTimeoutCheckbox => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.AutoScreenTimeoutCheckbox"));
        public WindowsElement ThinkPadSensitivityTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.ThinkPadSensitivityTitle"));
        public WindowsElement MinLegendThinkpadSensitivity => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.MinLegendThinkpadSensitivity"));
        public WindowsElement MidLegendThinkpadSensitivity => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.MidLegendThinkpadSensitivity"));
        public WindowsElement MaxLegendThinkpadSensitivity => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.MaxLegendThinkpadSensitivity"));
        public WindowsElement SensitivityAdjustingSliderBarNote => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.SensitivityAdjustingSliderBarNote"));

        //Video Playback
        public WindowsElement VideoPalybackToggle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.VideoPlayback.VideoPalybackToggle"));
        public WindowsElement VideoPlaybackTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.VideoPlayback.VideoPlaybackTitle"), 1, 1);
        public WindowsElement VideoPlaybackDescription => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.VideoPlayback.VideoPlaybackDescription"));
        public WindowsElement VideoPlaybackSupportList => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.VideoPlayback.VideoPlaybackSupportList"));
        public WindowsElement VideoPlaybackNote => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.VideoPlayback.VideoPlaybackNote"));
        #endregion
        //HPD UI
        public WindowsElement IntelligentSensingTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.IntelligentSensingTitle"));
        public WindowsElement IntelligentSecurityTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.IntelligentSecurityTitle"));
        public WindowsElement GlobalSettingsCaption => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.GlobalSettingsCaption"));
        public WindowsElement GlobalSettingsContextOne => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.GlobalSettingsContextOne"));
        public WindowsElement GlobalSettingsContextTwo => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.GlobalSettingsContextTwo"));
        public WindowsElement GlobalSettingsContextThree => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.GlobalSettingsContextThree"));
        public WindowsElement GlobalSettingsUncheckTip => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.GlobalSettingsUncheckTip"), 1, 1);
        public WindowsElement ClamshellCheckBox => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.ClamshellCheckBox"));
        public WindowsElement SandCheckBox => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.SandCheckBox"));
        public WindowsElement TentCheckBox => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.TentCheckBox"));
        public WindowsElement PadCheckBox => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.PadCheckBox"));
        public WindowsElement IntelligentSecurityCollapseLink => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.IntelligentSecurityCollapseLink"), 1, 1);
        public WindowsElement GlobalSettingsTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.GlobalSettingsTitle"), 1, 1);

        public WindowsElement VantageMinizeElement => FindElementByTimes(session, "XPath", VantageMinizeId);
        public WindowsElement VantageMaxizeElement => FindElementByTimes(session, "XPath", VantageMaxizeId);

        #region IsSupportSubfunction
        public bool Capacity = false;
        public bool IsSupportZeroTouchLoginSwitchButton = false;
        public bool IsSupportZeroTouchLoginADSASliderBar = false;
        public bool IsSupportZeroTouchLoginADSASwitchButton = false;
        public bool IsSupportZeroTouchLockSwitchButton = false;
        public bool IsSupportZeroTouchLockASLT = false;
        public bool IsSupportZeroTouchLockFR = false;
        public bool IsSupportZeroTouchLockADSASliderBar = false;
        public bool IsSupportZeroTouchLockADSASwitchButton = false;
        #endregion

        #region FunctionalStatus
        public int HPDZeroTouchLoginADSASldierBarValue;
        public SensorType? HPDSensorType;
        public bool? ApproachEnabledHasValue;
        public ApproachDistanceType? ApproachDistance;
        public bool? ApproachDistanceAutoAdjustHasValue;
        public bool? PresenceLeaveEnabledHasValue;
        public int PresenceLeaveWaitTime;
        public bool? PresenceLeaveCameraAssistHasValue;
        public PresenceLeaveDistanceType? PresenceLeaveDistance;
        public bool? PresenceLeaveDistanceAutoAdjustHasValue;
        public bool? VideoAutoPauseResumeEnabledHasValue;
        public bool? FaceIdRegisteredHasValue;
        #endregion

        public void GetHPDCapability()
        {
            try
            {
                if (rpcClient == null)
                {
                    rpcClient = new HumanPresenceDetection();
                    rpcClient.StatusUpdated += RpcClient_SettingUpdated;
                }
                if (((int)rpcClient.Capability & 0x2) != 0)
                {
                    IsSupportZeroTouchLoginSwitchButton = true;
                }
                if (((int)rpcClient.Capability & 0x4) != 0)
                {
                    IsSupportZeroTouchLoginSwitchButton = true;
                }
                if (((int)rpcClient.Capability & 0x8) != 0)
                {
                    IsSupportZeroTouchLoginADSASwitchButton = true;
                }
                if (((int)rpcClient.Capability & 0x10) != 0)
                {
                    IsSupportZeroTouchLockSwitchButton = true;
                }
                if (((int)rpcClient.Capability & 0x20) != 0)
                {
                    IsSupportZeroTouchLockASLT = true;
                }
                if (((int)rpcClient.Capability & 0x40) != 0)
                {
                    IsSupportZeroTouchLockFR = true;
                }
                if (((int)rpcClient.Capability & 0x80) != 0)
                {
                    IsSupportZeroTouchLockADSASliderBar = true;
                }
                if (((int)rpcClient.Capability & 0x100) != 0)
                {
                    IsSupportZeroTouchLockADSASwitchButton = true;
                }
                GetAllSetting();
            }
            catch (Exception ex)
            {
                Console.WriteLine("HSHPDPage->GetHPDCapability error:" + ex.Message);
            }
        }

        private void RpcClient_SettingUpdated()
        {
            GetAllSetting();
        }

        private void GetAllSetting()
        {
            try
            {
                var settings = rpcClient.GetAllSetting();
                Capacity = settings.Capacity;
                HPDSensorType = settings.SensorType;
                ApproachEnabledHasValue = settings.ApproachEnabled.HasValue ? (bool?)settings.ApproachEnabled.Value : null;
                ApproachDistance = settings.ApproachDistance;
                ApproachDistanceAutoAdjustHasValue = settings.ApproachDistanceAutoAdjust.HasValue ? (bool?)settings.ApproachDistanceAutoAdjust.Value : null;
                PresenceLeaveEnabledHasValue = settings.PresenceLeaveEnabled.HasValue ? (bool?)settings.PresenceLeaveEnabled.Value : null;
                PresenceLeaveWaitTime = (int)settings.PresenceLeaveWaitTime;
                PresenceLeaveCameraAssistHasValue = settings.PresenceLeaveCameraAssist.HasValue ? (bool?)settings.PresenceLeaveCameraAssist.Value : null;
                PresenceLeaveDistance = settings.PresenceLeaveDistance;
                PresenceLeaveDistanceAutoAdjustHasValue = settings.PresenceLeaveDistanceAutoAdjust.HasValue ? (bool?)settings.PresenceLeaveDistanceAutoAdjust.Value : null;
                VideoAutoPauseResumeEnabledHasValue = settings.VideoAutoPauseResumeEnabled.HasValue ? (bool?)settings.VideoAutoPauseResumeEnabled.Value : null;
                FaceIdRegisteredHasValue = settings.FaceIdRegistered.HasValue ? (bool?)settings.FaceIdRegistered.Value : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("HSHPDPage->GetAllSetting error:" + ex.Message);
            }
        }

        public bool IsProcessExists(string processName)
        {
            processName = processName.ToLower().Replace(".exe", "").Trim();
            Process[] processesArray = Process.GetProcessesByName(processName);
            if (processesArray.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ExitProcess(string processName)
        {
            try
            {
                processName = processName.ToLower().Replace(".exe", "").Trim();
                Process[] processesArray = Process.GetProcessesByName(processName);
                if (processesArray.Count() > 0)
                {
                    processesArray[0].Kill();
                    processesArray[0].WaitForExit();
                    processesArray[0].Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("HSHPDPage->ExitProcess error:" + ex.Message);
            }
        }

        public static void CheckNoHelloFace()
        {
            Process.Start("ms-settings:signinoptions");
            Thread.Sleep(3000);
            UIAutomationControl automationControl = new UIAutomationControl();
            AutomationElementCollection signincollection = automationControl.FindElementsByClass(AutomationElement.RootElement, "ListViewItem");
            foreach (AutomationElement elementPwd in signincollection)
            {
                string temp = elementPwd.GetCurrentPropertyValue(AutomationElement.NameProperty, false).ToString();
                if (temp.Contains("Windows Hello Face Sign in with your camera"))
                {
                    automationControl.SelectComBoxByAutomationElement(elementPwd);
                    automationControl.ExpandOrCollapseByAutomationElement(elementPwd);
                    Thread.Sleep(3000);
                    break;
                }
            }
            Thread.Sleep(2000);
            VantageCommonHelper.FindElementByIdAndMouseClick(GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.RemoveFaceButtion"));
        }

        ~HSHPDPage()
        {
            rpcClient?.Dispose();
            if (rpcClient != null)
            {
                rpcClient.StatusUpdated -= RpcClient_SettingUpdated;
            }
        }
    }
}
