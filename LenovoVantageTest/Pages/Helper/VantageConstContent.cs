using LenovoVantageTest.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LenovoVantageTest.Pages.HardwareSettingsPages
{
    public class VantageConstContent
    {
        //Vantage Commons Name
        public static string WinAppDriverProcessName = "WinAppDriver";
        public static string VantageLEUwpAPPIdName = "E046963F.LenovoSettingsforEnterprise";
        public static string VantageLELocationPermission = "E046963F.LenovoSettingsforEnterprise_k1h2ywk1493x8_ToggleSwitch";
        public static string VantageLocationPermission = "E046963F.LenovoCompanion_k1h2ywk1493x8_ToggleSwitch";
        public static string VantageCommonAppIdName = "E046963F.LenovoCompanion";
        public static string WindowsSoundRecorderAppId = "Microsoft.WindowsSoundRecorder_8wekyb3d8bbwe!App";
        public static string DolbyPremiumUwpDCHAppId = "DolbyLaboratories.DolbyAudioPremium_rz1tebttyb220!App";
        public static string DolbyPremiumUwp = "DolbyLaboratories.DolbyAudioPremium";
        public static string DolbyAtmosDCHAppId = "DolbyLaboratories.DolbyAtmosSpeakerSystem_rz1tebttyb220!App";
        public static string DolbyAtmosSpeakerUwp = "DolbyLaboratories.DolbyAtmosSpeakerSystem";

        private static string VantageCommonUwpAppFolderName = "E046963F.LenovoCompanion_k1h2ywk1493x8";
        private static string VantageLEUwpAppFolderName = "E046963F.LenovoSettingsforEnterprise_k1h2ywk1493x8";

        public static string CommonVantageFileName = "Data\\Vantage\\CommonVantageConfig.xml";
        public static string MicroVantageFileName = "Data\\Vantage\\MircoVantageConfig.xml";

        //dolbyUwpDCHAppIdSession DolbyLaboratories.DolbyAudioPremium_rz1tebttyb220
        public static string NarratorRegistry = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Accessibility\\ATConfig\\narrator";
        public static string ProcessSystemSettings = "SystemSettings";
        public static string ProcessDesktopDisplay = "desk.cpl";
        public static string FMAPOControlSettings = "4505Fortemedia.FMAPOControl";
        public static string DolbyAccessSettings = "DolbyLaboratories.DolbyAccess";

        // Vantage HS Idea Backlight    
        public static string DevconExeFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Tools\\devcon.exe");
        public static string DriverExeFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Tools\\DriverTool\\Release\\MultimediaDriverTool.exe");

        public static string XtuToolFilePath
        {
            get
            {
                string localXtuCLI = "C:\\Xtu_JSONTool\\XtuCLI.exe";
                if (File.Exists(localXtuCLI))
                {
                    return localXtuCLI;
                }
                else
                {
                    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Tools\\Xtu_JSONTool\\XtuCLI.exe");
                }
            }
        }

        public static string DevCon64FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Tools\\devcon_64.exe");
        public static string SmartStandbyComponentInfFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Fitnesse\TestLib\Data\driver\SmartStandby\SmartStandby_1.x\SmartStandbyComponent.inf");
        public static string WorkPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Tools\\DriverTool\\Release");
        //Tools\BJ_Video\DolbyMusicAndMovie
        public static string DolbyMusicPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Tools\\BJ_Video\\DolbyMusicAndMovie\\music.mp3");
        public static string DolbyMoviePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Tools\\BJ_Video\\DolbyMusicAndMovie\\video.mp4");
        public static string DolbyGamePath = "\"C:\\Program Files\\Battle.net\\Battle.net Launcher.exe\"";

        //GPU Boost
        public static string GPUBoostPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\GpuBoost\\gpu_boost.exe");

        //NV Turbo Boost
        public static string GPUThermalSettingTestPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\NerveCenterDocument\\GetCurrentVauleforNVTurboBoost\\GetCurrentVauleforNVTurboBoost\\GpuThermalSettingTest.exe");
        public static string NVTurboBoostPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\NerveCenterDocument\\NVTurboBoost\\NVturboboostBiosTool.ps1");
        public static string GraphicsCardHardwareIds = "Get-WmiObject -Class Win32_VideoController | Format-list PNPDeviceID";

        private static string _vantageCommonUwpAppid = "E046963F.LenovoCompanion_k1h2ywk1493x8!App";
        private static string _vantageLEUwpAppid = "E046963F.LenovoSettingsforEnterprise_k1h2ywk1493x8!App";
        public static string TypeHereToSearch = "4101";
        public static string FileSearchEditBox = "SearchEditBox";
        public static string FileSearchTextBox = "SearchTextBox";
        public static string FileExplorer = "File Explorer";
        public static string ClassModernSearchBox = "ModernSearchBox";
        public static string ClassRichEditBox = "RichEditBox";
        public static string XtuServiceProcess = "XtuService";
        public static string XtuServicePath = @"C:\Windows\SysWOW64\XtuService.exe";
        public static string BatView = @"C:\Windows\BatView.exe";
        public static string SmartAudioApp = @"C:\Windows\SmartAudio 3.lnk";
        public static string AudioDriverForteMedia = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Tools\\SettingsLeDolbyAccessForteMedia\\ForteMedia\\e8a3b0f315ba42e58c2e44ab395c94cd.appxbundle");
        public static string AudioDriverDolbyAccess = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Tools\\SettingsLeDolbyAccessForteMedia\\DolbyAccess\\DolbyAccess_3.2.169.Msix");
        public static string GamingFeatureDriverSetup
        {
            get
            {
                if (File.Exists("C:\\GamingFeatureDriver\\LenovoVantageGamingFeatureDriverSetup.exe"))
                {
                    return "C:\\GamingFeatureDriver\\LenovoVantageGamingFeatureDriverSetup.exe";
                }
                else
                {
                    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\GamingFeatureDriver\\LenovoVantageGamingFeatureDriverSetup.exe");
                }
            }
        }

        public static string GamingNahimicSetup = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\NerveCenterDocument\\Nahimic3\\2f307e7c3914425aa3d664d276bfc44d.appxbundle");
        public static string GamingXRiteColorAssistantSetup = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\NerveCenterDocument\\XRiteColorAssistantSetup.exe");
        public static string ITSServiceName = "LITSSVC";
        public static string IMCServiceName = "ImControllerService";
        public static string WindowsTimeServiceName = "W32Time";
        public static string XtuServiceName = "XTU3SERVICE";
        public static VantageType VantageTypePlan;
        //write log to specflow report
        public static string ShowTips = string.Empty;
        public static string VantageErrorLogs = "C:\\VantageErrorLogs";

        // Service C:\ProgramData\Lenovo\Vantage\Logs\LenovoVantageService

        public static string VantageShellLocalLogsFolderPath
        {
            get
            {
                return @"C:\Users\" + Environment.UserName + @"\AppData\Local\Packages\" + GetVantageUwpAppFolderName() + @"\LocalState\Logs";
            }
        }

        public static string VantageLenovoLocalLogsFolderPath
        {
            get
            {
                return @"C:\Users\" + Environment.UserName + @"\AppData\Local\Packages\" + GetVantageUwpAppFolderName() + @"\Lenovo";
            }
        }

        public static string VantageServiceLocalLogsFolderPath
        {
            get
            {
                return @"C:\ProgramData\Lenovo\Vantage\Logs";
            }
        }

        public enum VantageType
        {
            LE,
            Common,
            MicroFrontends,
            NewShellOldPlugin,
            NewShellNewPlugin,
            OldShellNewPlugin,
            OldShellOldPlugin,
            TestSelf
        }

        public static string VantageProcessId;

        public static bool NotLEMask
        {
            get
            {
                return VantageTypePlan != VantageType.LE;
            }
        }

        public static string NetworkName = "";
        private static bool _notLEMask
        {
            get
            {
                return NotLEMask;
            }
        }
        public static string LeMaskFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Le.Mask");
        public static string WIFILEMASk = Path.Combine(Environment.CurrentDirectory, @"Le.MASK");

        // this is a property.  When you access it uses the underlying field, but only exposes
        // the contract that will not be affected by the underlying field
        //HardwareSettings XPath
        public static string HSOtherSettings = "//*[@AutomationId='jumptoSetting-other']";
        public static string HSJumpToPowerSettings = "//*[@AutomationId='jumptoSetting-power']";
        public static string HSJumpToDisplaySettings = "//*[@AutomationId='jumptoSetting-display']";//HyperLink
        public static string HSJumpToSmartSettings = "//*[@AutomationId='jumptoSetting-smartSettings']";
        public static string HSJumpToOtherSettings = "//*[@AutomationId='jumptoSetting-other']";
        public static string HSJumpToBatterySettings = "//*[@AutomationId='jumptoSetting-battery']";
        public static string OtherSettingsOff = "//*[@AutomationId='ds-power-otherSettings-toolBar_off_sizeStopProp']";
        public static string OtherSettingsOn = "//*[@AutomationId='ds-power-otherSettings-toolBar_on_sizeStopProp']";
        public static string HS_OtherSettingstoolBarCheckBox = "//*[@AutomationId='ds-power-otherSettings-toolBar_checkbox']";
        public static string HSMenuAudio = "//*[@AutomationId='myDevice-settings-header-menu-audio-title']";
        public static string HSMenuDisplayCamera = "//*[@AutomationId='myDevice-settings-header-menu-display-camera-title']";
        public static string HSMenuInputAccessories = "//*[@AutomationId='myDevice-settings-header-menu-input-accessories']";
        public static string HSMenuSmartAssist = "//*[@AutomationId='menu-main-nav-lnk-dropdown-menu-device-3']";
        public static string HSVoIPHotkeyFunctions = "//*[@AutomationId='inputAccessories-VoipHotkeys-title']";
        public static string HSVoIPNote = "//*[@AutomationId='hasInstalledApps-note']";
        public static string HSVoIPHotkeyTooltip = "//*[@AutomationId='inputAccessories-VoipHotkeys-tooltip_right_icon']";
        public static string HSVoIPTooltipDescription = "//*[@AutomationId='inputAccessories-VoipHotkeys-toolTip']";
        public static string HSMicrosoftTeamsOption = "//*[@AutomationId='divvoip-hotkeys-rectangle-radio1']";
        public static string HSSkypeOption = "//*[@AutomationId='divvoip-hotkeys-rectangle-radio0']";
        public static string HSVoipHotkeysCaption = "//*[@AutomationId='inputAccessories-VoipHotkeys-caption']";
        public static string HSVoipHotkeysDescriptionF10 = "//*[@AutomationId='VoipHotkeys-description-f10']";
        public static string HSVoipHotkeysDescriptionF11 = "//*[@AutomationId='VoipHotkeys-description-f11']";
        public static string HSVoipHotkeysHasInstalledAppsDescription = "//*[@AutomationId='VoipHotkeys-hasInstalledAppsDescription']";
        public static string HSIdeaBacklightCaption = "//*[@AutomationId='inputAccessories-backlight-caption']";
        public static string HSIdeaBacklightTitle = "//*[@AutomationId='inputAccessories-backlight-title']";

        ////*[@id="dashboard-btn-feedback"]
        public static string MyDeviceSettings = "//*[@AutomationId='menu-main-nav-lnk-dropdown-menu-device-1']";
        public static string MenuDevice = "//*[@AutomationId='menu-main-nav-lnk-dropdown-toggle-device']";
        public static string HSOPingToobarToggle = "//*[@AutomationId='ds-power-otherSettings-toolBar_sizeStopProp']";//
                                                                                                                      //"ds-power-otherSettings-toolBar_checkbox"
        public static string SystemUpdate = "//*[@AutomationId='menu-main-nav-lnk-dropdown-menu-device-2']";
        public static string Dashboard = "//HyperLink[@AutomationId='menu-main-nav-lnk-dashboard']";

        public static string HSOCameraSettingsAutoExposureCheckBox = "//*[@AutomationId='cameraSettings-autoExposure_checkbox']";
        public static string HSOBatteryThresHoldCheckBox = "//*[@AutomationId='ds-power-battery-threshold_checkbox']";
        public static string HSHeaderTitleIdXpath = "//*[@AutomationId='ds-power-battery-threshold-title']";

        public static string HSOBatteryThresHoldToggle = "//*[@AutomationId='ds-power-battery-threshold_checkbox']";
        public static string HSOBatteryPopupEnableBtn = "//*[@AutomationId='battery-threshold-popup-enable']";
        public static string HSOBatteryThresPopupEnable = "//*[@AutomationId='battery-threshold-popup-enable']";
        public static string HSOBatteryThresHoldIcon = "//*[@AutomationId='ds-power-battery-threshold-tooltip_right_icon']";//ds-power-battery-threshold-tooltip_right_icon
        public static string HSOBatteryThresHoldToolTip = "//*[@AutomationId='ds-power-battery-threshold-toolTip']";
        public static string HSOBatteryThresHoldToolTipText = "//*[@Name='If your battery is currently charged above the stop-charging threshold, detach the power until the battery discharges to or below the stop-charging threshold. Depending on the battery status (old or new), the exact point at which the charging starts or stops might vary by up to 2 percentage points. If you enable the feature, it is recommended that you perform a Battery Gauge Reset occasionally to ensure an accurate report of the battery health.']";

        public static string HSOAirplanePowerModeGroup = "//*[@AutomationId='ds-power-battery-airplane_sizeStopProp']";
        public static string HSOAirplanePowerModeOff = "//*[@AutomationId='ds-power-battery-airplane_off_sizeStopProp']";
        public static string HSOAirplanePowerModeOn = "//*[@AutomationId='ds-power-battery-airplane_on_sizeStopProp']";
        public static string HSOAirplanePowerModeToggle = "//*[@AutomationId='ds-power-battery-airplane']";

        public static string DeviceSettingsProtocol = @"lenovo-vantage3:device-settings";
        public static string WifiSecurityProtocol = @"lenovo-vantage3:wifi-security";
        public static string MyWifiSecurityPageProtocol = @"lenovo-vantage3:security";
        public static string ConnectedHomeSecurityPageProtocol = @"lenovo-vantage3:home-security";

        //Power
        public static string PowerSEEBATTERYDETAILS = "//*[@AutomationId='myDevice-settings-battery-details-btn']";
        public static string PowerHIDEBATTERYDETAILS = "//*[@AutomationId='myDevice-settings-battery-details-card-close-icon']";
        public static string Powersmartsettings = "//*[@AutomationId='jumptoSetting-smartSettings']";
        public static string Powerbatterytitle = "//*[@AutomationId='jumptoSetting-smartSettings']";

        public static string HSRadioDolbyModeMusic = "//*[@AutomationId='radioDolbyModeMusic']";
        public static string HSRadioDolbyModeMovie = "//*[@AutomationId='radioDolbyModeMovie']";
        public static string HSRadioDolbyModeDynamic = "//*[@AutomationId='radioDolbyModeDynamic']";
        public static string HSRadioDolbyModeGame = "//*[@AutomationId='radioDolbyModeGame']";
        public static string HSRadioDolbyModeVoip = "//*[@AutomationId='radioDolbyModeVoip']";
        public static string Audio = "//*[@Name='Audio']";

        //HS-threshold
        public static string HSThredholdCheckBox = "//*[@AutomationId='ds-power-battery-threshold_sizeStopProp_checkbox']";
        public static string HSThredholdEnableBtn = "//*[@AutomationId='battery-threshold-popup-enable']";
        public static string HSThreholdSecondaryBatteryStartDropDown = "//*[@AutomationId='threshold-secondary-battery-start-dropdown']";
        public static string HSThreholdSecondaryBatteryStopDropDown = "//*[@AutomationId='threshold-secondary-battery-stop-dropdown']";
        public static string HSThreholdPrimaryBatteryStartDropDown = "//*[@AutomationId='threshold-primary-battery-start-dropdown']";
        public static string HSThreholdPrimaryBatteryStopDropDown = "//*[@AutomationId='threshold-primary-battery-stop-dropdown']";
        public static string HSJudgeDualBattery = "//*[@AutomationId='threshold-secondary-battery-title']";
        public static string HSThreholdTitle = "ds-power-battery-threshold-title";

        public static string HSPrimaryStartFirstValue = "//*[@AutomationId='threshold-primary-battery-startAtChargeOption-40']";
        public static string HSPrimaryStartLastValue = "//*[@AutomationId='threshold-primary-battery-startAtChargeOption-95']";
        public static string HSPrimaryStopFirstValue = "//*[@AutomationId='threshold-primary-battery-stopAtChargeOption-45']";
        public static string HSPrimaryStopLastValue = "//*[@AutomationId='threshold-primary-battery-stopAtChargeOption-100']";

        public static string HSSecondaryStartFirstValue = "//*[@AutomationId='threshold-secondary-battery-startAtChargeOption-40']";
        public static string HSSecondaryStartLastValue = "//*[@AutomationId='threshold-secondary-battery-startAtChargeOption-95']";
        public static string HSSecondaryStopFirstValue = "//*[@AutomationId='threshold-secondary-battery-stopAtChargeOption-45']";
        public static string HSSecondaryStopLastValue = "//*[@AutomationId='threshold-secondary-battery-stopAtChargeOption-100']";

        //Power
        //public static string PowerPageHeader = ITSContentXpath.MyDeviceSettingsPowerTitle;
        public static string MenuPowerTitle = "//*[@AutomationId='myDevice-settings-header-menu-power']";
        public static string PowerMinimize = "//*[@AutomationId='Minimize']";
        public static string Powerresize = "//*[@AutomationId='Maximize']";
        public static string Powerlevel = "//*[@AutomationId='batteryPercentage']";
        public static string batteryremainingtime = "//*[@AutomationId='remaining-time-value']";
        public static string systembatteryremainingtime = "//*[@AutomationId='SystemSettings_BatterySaver_LandingPage_EstimatedTimeRemaining_DescriptionTextBlock']";
        public static string batterydetailstitle = "//*[@AutomationId='heading']";
        public static string FulltochargeText = "//*[@AutomationId='myDevice-settings-batteryGauge-time-to-charge-title']";
        //Audio
        public static string MicroPhoneVolume = "//*[@AutomationId='audio-microphone-volume-title']";
        public static string MicroPhoneVolumeSlider = "//*[@AutomationId='audio-microphone-volume-slider']";
        public static string MicroPhoneVolumesilent = "//*[@AutomationId='min-legend-audio-microphone-volume']";
        public static string MicroPhoneVolumelound = "//*[@AutomationId='max-legend-audio-microphone-volume']";
        public static string MicroPhoneAudio = "//*[@AutomationId='myDevice-settings-header-menu-audio']";
        public static string AudioAutomaticDolbyToggleCheckBoxXpath = "//*[@AutomationId='audio-automatic-dolby_checkbox']";
        public static string AutomaticAudioOptimizationXpath = "//*[@AutomationId='audio-voip_checkbox']";
        public static string AutomaticAudioOptimizationMaskXpath = "//*[@AutomationId='audio-voip-tooltip_right_icon']";
        public static string AutomaticAudioDolbyModeVoipXpath = "//*[@AutomationId='radioDolbyModeVoip']";
        //input page
        public static string Inputtittle = "//*[@AutomationId='inputAccessories-hiddenKeyboardFunctions-title']";
        public static string Inputcaption = "//*[@AutomationId='inputAccessories-hiddenKeyboardFunctions-caption']";
        //myDevice-settings-header-menu-audio
        public static string MicroPhonesliderXpath = "//*[@AutomationId='audio-microphone-volume-slider']";
        public static string MicroPhoneTooltip = "//*[@AutomationId='audio-microphone-tooltip_right_icon']";
        public static string MicroPhoneAECTooltip = "//*[@AutomationId='audio-microphone-acousticEcho-tooltip_right_icon']";
        public static string MicroPhoneAECToggleId = "//*[@AutomationId='audio-microphone-acousticEcho_sizeStopProp']";
        public static string MicroPhoneAECCheckBoxId = "//*[@AutomationId='audio-microphone-acousticEcho_checkbox']";
        public static string MicroPhoneAECTitle = "//*[@AutomationId='audio-microphone-acousticEcho-title']";
        public static string MicroPhoneAECIntroduce = "//*[@AutomationId='audio-microphone-acousticEcho-toolTip']";
        //public static string MicroPhoneAECIntroduce = "//*[@AutomationId='audio-microphone-acousticEcho-toolTip']";
        public static string MicroPhoneCheckBoxId = "//*[@AutomationId='audio-microphone_checkbox']";
        public static string MicroPhoneAECToggleIdCheckbox = "//*[@AutomationId='audio-microphone-acousticEcho_checkbox']";

        public static string MicroPhoneTitle = "//*[@AutomationId='audio-microphone-collapse-card-title']";
        public static string MicroPhoneOptimizationTitle = "//*[@AutomationId='audio-microphone-optimize-title']";
        public static string MicroPhoneIntroduce = "//*[@AutomationId='audio-microphone-toolTip']";
        public static string MicroPhoneVoiceRecognition = "//*[@AutomationId='radioMicrophoneVoiceRecognition']";
        public static string MicroPhoneOnlyMyVoice = "//*[@AutomationId='radioMicrophoneOnlyMyVoice']";
        public static string MicroPhoneNormal = "//*[@AutomationId='radioMicrophoneNormal']";
        public static string MicroPhoneMultipleVoices = "//*[@AutomationId='radioMicrophoneMultipleVoices']";

        //CameraPrivacy
        public static string CameraPrivacyTitle = "//*[@AutomationId='camera-privacy-mode-title']";
        public static string DisplayCameraBtn = "//*[@AutomationId='myDevice-settings-header-menu-display-camera']";
        public static string JumpCameraLinkBtn = "//*[@AutomationId='jumptoSetting-camera']";
        public static string CameraPrivacyModeSwitchCheckBox = "//*[@AutomationId='camera-privacy-mode_checkbox']";
        public static string CameraPrivacyModeQuestionMark = "//*[@AutomationId='camera-privacy-mode-tooltip_right_icon']";
        public static string CameraPrivacyModeToolTip = "//*[@AutomationId='ngb-tooltip-2']";
        public static string CameraPrivacyModeToggleCheckBox = "//*[@AutomationId='camera-privacy-mode_checkbox']";
        public static string CameraTitle = "//*[@AutomationId='device-settings-camera-title']";
        public static string CameraResetBtn = "//*[@AutomationId='device-settings-camera-reset-btn']";
        public static string CameraVideo = "//*[@Name='Video']";
        public static string CameraBrightnessSlider = "//*[@AutomationId='cameraSettings-brightness-slider']";
        public static string CameraContrastSlider = "//*[@AutomationId='cameraSettings-contrast-slider']";
        public static string CameraAutoExposureCheckbox = "//*[@AutomationId='cameraSettings-autoExposure_checkbox']";
        public static string CameraQuestionMark = "//*[@AutomationId='device-settings-camera-tooltip_right_icon']";
        public static string CameraResetQuestionMark = "//*[@AutomationId='device-settings-camera_tooltip_right_icon']";
        public static string CameraToolTip = "//*[@AutomationId='ngb-tooltip-3']";
        public static string CameraAutoExposureToggleCheckBox = "//*[@AutomationId='cameraSettings-autoExposure_checkbox']";
        public static string CameraAutoExposureSlider = "//*[@AutomationId='cameraSettings-autoExposure-slider']";
        public static string CameraPrivacyModeTipsBtn = "//*[@AutomationId='camera-privacy-mode-access-url']";
        public static string CameraTipsBtn = "//*[@AutomationId='device-settings-camera-access-url']";
        public static string Jumptocamera = "//*[@AutomationId='myDevice-settings-header-menu-display-camera']";
        public static string JumptoSettingcamera = "//*[@AutomationId='jumptoSetting-camera']";
        public static string CameraBlurCheckBox = "//*[@AutomationId='device-settings-camera-blur_checkbox']";

        public static string TurnCameraprivacyCheckBox = "//*[@AutomationId='camera-privacy-mode_checkbox']";

        public static string Cameraoption1 = "//*[@AutomationId='radio1-title']";
        public static string Cameraoption2 = "//*[@AutomationId='radio2-title']";
        public static string Cameraoption3 = "//*[@AutomationId='radio3-title']";
        //LenovoPrivacy
        public static string LenovoPrivacy = "//*[@AutomationId='menu-main-nav-lnk-privacy']";
        public static string PrivacyGuardToggle = _notLEMask ? "//*[@AutomationId='privacy-guard_checkbox']" : "//*[@AutomationId='privacy-guard_checkbox']";

        //HardwareSettings power
        public static string HS_PowerPage = "//*[@AutomationId='myDevice-settings-header-menu-power']";
        public static string EasyResumeTogglexpath = "//*[@AutomationId='ds-power-easyResume_checkbox']";
        public static string HS_PowerHeaderTitle = "//*[@AutomationId='myDevice-settings-power-header-title']";
        public static string HS_BatterySettingsTitle = "//*[@AutomationId='device-settings-batterySettings-collapse-card-title']";
        public static string HS_RapidChargeTitle = "//*[@AutomationId='ds-power-battery-expressCharging-title']";
        public static string HS_RapidChargeCaption = "//*[@AutomationId='ds-power-battery-expressCharging-caption']";
        public static string HS_RapidChargeCaptionText = "Rapid Charge allows your battery to a full charge much faster than normal mode.";
        public static string HS_RapidChargeCheckBox = "//*[@AutomationId='ds-power-battery-expressCharging_checkbox']";

        public static string HS_ConservationTitle = "//*[@AutomationId='ds-power-battery-conservationMode-title']";
        public static string HS_ConservationCheckBox = "//*[@AutomationId='ds-power-battery-conservationMode_checkbox']";

        public static string HS_alwaysonusbTitle = "//*[@AutomationId='ds-power-alwaysUSB-title']";
        public static string HS_powersettingsdescription = "//*[@AutomationId='ds-power-alwaysUSB-caption']";
        public static string HS_powersettingstoggle = "//*[@AutomationId='ds-power-alwaysUSB']";
        public static string HS_ConservationToggleOn = "//*[@AutomationId='ds-power-battery-conservationMode_on_sizeStopProp']";
        public static string HS_aouCheckBox = "//*[@AutomationId='cb-always-on-usb_checkbox']";

        //HardwareSetitngs OLED
        public static string HS_oledtitle = "//*[@AutomationId='oled-power-settings-title']";
        public static string HS_oledcontextxpath1 = "//*[@AutomationId='oled-power-settings-caption1']";
        public static string HS_oledcontextxpath2 = "//*[@AutomationId='oled-power-settings-caption2']";
        public static string HS_taskbardimmerxpath = "//*[@AutomationId='oled-power-settings-tb-dimmer']";
        public static string HS_backgrounddimmerxpath = "//*[@AutomationId='oled-power-settings-bg-dimmer']";
        public static string HS_displaydimmingxpath = "//*[@AutomationId='oled-power-settings-dp-dimmer']";
        public static string HS_oledTaskbarDimmerDropDown = "//*[@AutomationId='oled-taskbar-dimmer-dropDown']";
        public static string HS_oledBackgroundDimmerDropDown = "//*[@AutomationId='oled-background-dimmer-dropDown']";
        public static string HS_oledDisplayDimmerDropDown = "//*[@AutomationId='oled-display-dimmer-dropDown']";

        public static string HS_FlipBootTitle = "//*[@AutomationId='ds-power-flipToBoot-title']";
        public static string HS_FlipBootCheckBox = "//*[@AutomationId='ds-power-flipToBoot_checkbox']";
        public static string HS_FlipBootQuestionMark = "//*[@AutomationId='ds-power-flipToBoot-tooltip_right_icon']";
        public static string HS_FlipBoottooltip = "//*[@AutomationId='ds-power-flipToBoot-toolTip']";
        public static string HS_FlipBootdescription = "//*[@AutomationId='ds-power-flipToBoot-caption']";
        public static string CHSWindowYesBtn = "//*[@AutomationId='Button1']";
        public static string CHSWindowNoBtn = "//*[@AutomationId='Button0']";

        //Version 3.2+ Xpath.
        public static string MenuDevice_32 = "//*[@AutomationId='menu-main-nav-lnk-dropdown-toggle-device']";
        public static string PowerBatteryDetailBtn = "//*[@AutomationId='myDevice-settings-battery-details-btn']";
        public static string PowerBatteryDetailCloseBtn = "//*[@AutomationId='myDevice-settings-battery-details-card-close-icon']";
        public static string PowerBatteryTip = "//*[@AutomationId='battery-condition-tip-Good']";
        public static string PowerNoBatteryTip = "//*[@AutomationId='battery-condition-tip-NotDetected']";
        //public static string PowerBatteryTip = "//*[@AutomationId='myDevice-settings-battery-condition-tip']";
        public static string PowerBatteryTitle = "//*[@AutomationId='myDevice-settings-batteryGauge-subtitle']";
        public static string PowerBatteryGaugeTip = "//*[@AutomationId='myDevice-settings-batteryGauge-notDetected-title']";
        public static string PowerJumpSmartStandby_32 = "//*[@AutomationId='jumptoSetting-smartStandby']";
        public static string SmartStandbyCheck_32 = "//*[@AutomationId='smartStandby_checkbox']";
        public static string SmartStandbyStartAm_32 = "//*[@AutomationId='start-am-radio']";
        public static string SmartStandbyStartPm_32 = "//*[@AutomationId='start-pm-radio']";
        public static string SmartStandbyStartDrop_32 = "//*[@AutomationId='smartStandby-start-dropDown-btn']";
        public static string SmartStandbyStartDone_32 = "//*[@AutomationId='smartStandby-start-done-icon']";
        public static string SmartStandbyEndDrop_32 = "//*[@AutomationId='smartStandby-end-dropDown-btn']";
        public static string SmartStandbyEndDone_32 = "//*[@AutomationId='smartStandby-end-done-icon']";
        public static string SmartStandbyEndAm_32 = "//*[@AutomationId='end-am-radio']";
        public static string SmartStandbyEndPm_32 = "//*[@AutomationId='end-pm-radio']";
        public static string SmartStandbyStartHoursPrev = "//*[@AutomationId='smartStandby-start-hours-prev-btn']";
        public static string SmartStandbyStartMinutesPrev = "//*[@AutomationId='smartStandby-start-minutes-prev-btn']";
        public static string SmartStandbyStartHoursNext = "//*[@AutomationId='smartStandby-start-hours-next-btn']";
        public static string SmartStandbyStartMinutesNext = "//*[@AutomationId='smartStandby-start-minutes-next-btn']";
        public static string SmartStandbyEndHoursPrev = "//*[@AutomationId='smartStandby-end-hours-prev-btn']";
        public static string SmartStandbyEndMinutesPrev = "//*[@AutomationId='smartStandby-end-minutes-prev-btn']";
        public static string SmartStandbyEndHoursNext = "//*[@AutomationId='smartStandby-end-hours-next-btn']";
        public static string SmartStandbyEndMinutesNext = "//*[@AutomationId='smartStandby-end-minutes-next-btn']";
        public static string SmartStandbyStartCloseBtn = "//*[@AutomationId='smartStandby-start-close-icon']";
        public static string SmartStandbyEndCloseBtn = "//*[@AutomationId='smartStandby-end-close-icon']";
        public static string SmartStandbySchedule = "//*[@AutomationId='smartStandby-shedule']";
        public static string SmartStandbySunday = "//*[@AutomationId='sun']";
        public static string SmartStandbyMonday = "//*[@AutomationId='mon']";
        public static string SmartStandbyTuesday = "//*[@AutomationId='tue']";
        public static string SmartStandbyWednesday = "//*[@AutomationId='wed']";
        public static string SmartStandbyThursday = "//*[@AutomationId='thurs']";
        public static string SmartStandbyFriday = "//*[@AutomationId='fri']";
        public static string SmartStandbySaturday = "//*[@AutomationId='sat']";
        public static string SmartStandbyScheduleDone = "//*[@AutomationId='daysPickerDone']";
        public static string SmartStandbyScheduleClose = "//*[@AutomationId='daysPickerClear']";
        public static string SmartStandbyDropCheck1 = "//*[@AutomationId='dropcheck1']";
        public static string SmartStandbyDropCheck2 = "//*[@AutomationId='dropcheck2']";
        public static string SmartStandbyDropCheck3 = "//*[@AutomationId='dropcheck3']";
        public static string SmartStandbyClickToChange_32 = "//*[@AutomationId='smartstandby-click-to-change']";
        public static string SmartStandbyCOLLAPSE_32 = "//*[@AutomationId='smartstandby-click-to-change-collapse']";
        public static string SmartStandbyStartHourValue = "//*[@AutomationId='smartStandby-start-hours']";
        public static string SmartStandbyEndHourValue = "//*[@AutomationId='smartStandby-end-hours']";
        public static string SmartStandbyStartMinutesValue = "//*[@AutomationId='smartStandby-start-minutes']";
        public static string SmartStandbyEndMinutesValue = "//*[@AutomationId='smartStandby-end-minutes']";
        public static string SmartStandbyStartDropDown = "//*[@AutomationId='smartStandby-start-dropDown-btn']";
        public static string SmartStandbyEndDropDown = "//*[@AutomationId='smartStandby-end-dropDown-btn']";

        //Smart Assist
        public static string SmartAssistPage = "//*[@AutomationId='menu-main-nav-lnk-dropdown-menu-device-3']";
        public static string SmartAssistCheckBox = "//*[@AutomationId='video-resolution-upscaling.toggle-button_checkbox']";
        public static string SmartAssistAutoScreenOffTitle = "//*[@AutomationId='autoScreenOff-title']";
        public static string SmartAssistAutoScreenQuestionMark = "//*[@AutomationId='superResolution-tooltip_right_icon']";
        public static string SmartAssistAutoScreenOffTip = "//*[@AutomationId='autoScreenOff-caption']";
        public static string SmartAssistAutoScreenCheckBox = "//*[@AutomationId='autoScreenOff_checkbox']";
        public static string SmartAssistKeepMyDisplayTitle = "//*[@AutomationId='keepMyDisplay-title']";
        public static string SmartAssistKeepMyDisplayTip = "//*[@AutomationId='keepMyDisplay-caption']";
        public static string SmartAssistKeepMyDisplayCheckBox = "//*[@AutomationId='keepMyDisplay_checkbox']";
        public static string SmartAssistKeepMyDisplaySlider = "//*[@AutomationId='keepMyDisplay-slider']";
        public static string SmartAssistKeepMyDisplaySliderMinValue = "//*[@AutomationId='keepMyDisplay-min-value-title']";
        public static string SmartAssistKeepMyDisplaySliderMaxValue = "//*[@AutomationId='keepMyDisplay-max-value-title']";
        public static string SmartAssistJumpScreen = "//*[@AutomationId='jumptoSetting-screen']";
        public static string SmartAssistCollapse = "//*[@AutomationId='intelligentScreen-collapse-link']";
        public static string SmartAssistKeepMyDisplayTipContext = "Keep my display when I am reading or browsing.";
        public static string SmartAssistKeepMyDisplaySliderTitle = "//*[@AutomationId='smart-assist-display-slider-title']";
        public static string SmartAssistKeepMyDisplaySliderTitleContext = "Minutes before display dims when browsing";
        public static string AutoScreenOffNote = "//*[@AutomationId='smart-assist-auto-screen-off-note']";
        public static string AutoScreenOffNoteContext = "This feature is not available if your Power Plan settings are set to \"never turn off the screen on battery\" in the Windows Settings \"System section\". Please select a value other than \"Never\" to enable this feature.";
        public static string SmartAssisDec = "//*[@AutomationId='smart-assist-intelligent-screen-desc']";
        public static string SmartAssisContext = "Lenovo Intelligent Sensing combines the various sensors on your computer to detect your activities and adjust settings for power management. For example, it will dim your display if it detects you are walking but will not dim it if it detects you reading.";
        public static string AutoScreenOffContext = "Automatically turn off display when face-down or walking.";

        //Video Resolution Upscaling
        public static string SuperResolutionTitle = "//*[@AutomationId='superResolution-title']";
        public static string SuperResolutionToolTips = "//*[@AutomationId='ngb-tooltip-1']";
        public static string SuperResolutionDesc = "//*[@AutomationId='superResolution-caption']";
        public static string SuperResolutionNote = "//*[@AutomationId='superResolution-note-description']";
        public static string SuperResolutionNoteDesc1 = "//*[@AutomationId='superResolution-note-description1']";
        public static string SuperResolutionNoteDesc2 = "//*[@AutomationId='superResolution-note-description2']";
        public static string SuperResolutionNoteDesc3 = "//*[@AutomationId='superResolution-note-description3']";
        public static string SuperResolutionHelpIcon = "//*[@AutomationId='superResolution-tooltip_right_icon']";

        //Display Camera feature
        //HS-ThresHold 

        public static string DisplayDefaultValue = "//*[@AutomationId='color-temp-eyeCareMode-slider']";
        public static string DisplayDaytimeColorDefaultSliderValue = "//Slider[@Value='6500']";
        public static string DisplayDefaultSliderInECMValue = "//Slider[@Value='4500']";
        public static string DisplayDefaultSliderMinimumValue = "//Slider[@Minimum='1200']";
        public static string DisplayDefaultSliderMaximumValue = "//Slider[@Maximum='6500']";
        public static string DisplayEyeCareModeCheckboxElement = "//*[@AutomationId='color-temp-eyeCareMode_checkbox']";
        public static string ScheduleEyeCareModeCheckboxElement = "//*[@AutomationId='cb-eye-care-schedule_checkbox']";
        public static string DaytimeColorTemperatureSliderBar = "//*[@AutomationId='day-time-color-temp-slider']";
        public static string DaytimeColorTemperatureResetBtn = "//*[@AutomationId='day-time-color-temp-reset-btn']";
        public static string ColorTemperatureInECMSliderBar = "//*[@AutomationId='color-temp-eyeCareMode-slider']";
        public static string ColorTemperatureInECMResetBtn = "//*[@AutomationId='color-temp-eyeCareMode-reset-btn']";
        // Remove Ecm Feature
        public static string RemoveECMClickHereLink = "//*[@AutomationId='goto-nightlight-link']";//"//*[@AutomationId='goto_nightlight_link']";
        public static string RemoveECMDaytTimeColorTemoTitle = "//*[@AutomationId='day-time-color-temp-title']";
        //day-time-color-temp-caption
        public static string RemoveECMDaytTimeColorTemoDescription = "//*[@AutomationId='day-time-color-temp-caption']";

        //Operation Vantage XPath
        public static string VantageMinizeId = "//*[@AutomationId='Minimize']";
        public static string VantageMaxizeId = "//*[@AutomationId='Maximize']";
        public static string CloseVantageButton = "//*[@AutomationId='Close']";
        public static string OoBeNextButton = "//*[@AutomationId='tutorial_next_btn']";
        // progressContainer
        public static string InstallProgress = "//*[@AutomationId='progressContainer']";
        public static string VantageGifContainer = "//*[@AutomationId='gifContainer']";

        public static string ObBeSegmentChoose = "//*[@AutomationId='segment-choose-business-use']";
        public static string OoBeCheckBox = "//*[@AutomationId='welcome-privacy_checkbox']";
        public static string OoBeDoneButton = "//*[@AutomationId='tutorial_done_btn']";
        public static string splashGifId = "//*[@AutomationId='splashGif']";

        //LE OOBE
        public static string LeOobeLicenceCheckBox = "//*[@AutomationId='cb-accept-license-agreement_checkbox']";
        public static string LeOobePrivacyChexbox = "//*[@AutomationId='cb-accept-privacy_checkbox']";
        public static string LeOobeLetGoButton = "//*[@AutomationId='license-agreement-lets-go']";

        //Quick Settings
        public static string UpdateBtnXpath = "//*[@AutomationId='qs-system-update-switch-icon']";
        public static string CameraBtnXpath = "//*[@AutomationId='qs-camera-switch-disable-state']";
        public static string MicrophoneBtnXpath = "//*[@AutomationId='qs-microphone-switch-disable-state']";
        public static string MicrophoneOnBtnXpath = "//*[@AutomationId='qs-microphone-switch-on-state']";
        public static string MicrophoneOffBtnXpath = "//*[@AutomationId='qs-microphone-switch-off-state']";
        public static string QuickSettingsMicrophoneXpath = "//*[contains(@AutomationId,'qs-microphone-switch-')]";  //on-state off-state disable-state
        public static string CameraAccessTipsBtnXpath = "//*[@AutomationId='qs-camera-access-link']";
        public static string MicrophoneCameraAccessTipsBtnXpath = "//*[@AutomationId='qs-microphone-camera-access-ink']";
        public static string MicrophoneAccessTipsBtnXpath = "//*[@AutomationId='qs-microphone-access-link']";
        public static string ConfirmWindow = "//*[@AutomationId='Popup Window']";
        public static string OnCameraXpath = "//*[@AutomationId='qs-camera-switch-on-state']";
        public static string OffCameraXpath = "//*[@AutomationId='qs-camera-switch-off-state']";
        public static string QuickSettingsCameraXpath = "//*[contains(@AutomationId,'qs-camera-switch-')]"; //on-state off-state disable-state
        public static string AudioXpath = "//*[@AutomationId='qs-microphone-switch-icon']";
        public static string CameraXpath = "//*[@AutomationId='qs-camera-switch-icon']";
        public static string HeaderTitleXpath = "//*[@AutomationId='-header-title']";
        public static string CompleteXpath = "//*[@AutomationId='su_check_progress']"; //su_check_progress su-progress-complete-text
        public static string DisplayAndCamera = "//*[@AutomationId='myDevice-settings-header-menu-display-camera']";
        public static string AudioTab = "//*[@AutomationId='myDevice-settings-header-menu-audio-title']";
        public static string MyDeviceSettingsHeaderTitle = "//*[@AutomationId='myDevice-settings-header-title']";
        public static string MyDeviceSettingsLink = "//*[@AutomationId='qs-lnk-my-device-settings']";
        public static string CriticalUpdatesOffToggle = "//*[@AutomationId='critical-updates_off_sizeStopProp']";
        public static string CriticalUpdatesOnToggle = "//*[@AutomationId='critical-updates_on_sizeStopProp']";
        public static string RecommendedUpdatesOnToggle = "//*[@AutomationId='recommended-updates_on_sizeStopProp']";
        public static string RecommendedUpdatesOffToggle = "//*[@AutomationId='recommended-updates_off_sizeStopProp']";
        public static string LIcon = "//*[@AutomationId='menu-main-lnk-l-logo']";
        public static string BatteryDetailsCloseIcon = "//*[@AutomationId='myDevice-settings-battery-details-card-close-icon']";
        //Input Page
        public static string InputPageXpath = "//*[@AutomationId='myDevice-settings-header-menu-input-accessories-title']";
        public static string topRowfunctionsdescription = "//*[@AutomationId='inputAccessory.topRowFunctions.subSection.description']";
        public static string topRowfunctionsideapadtitle = "//*[@AutomationId='topRowFunctionsIdeapad-title']";

        //User Defined Key_Own by Jiajt
        public static string UserDefinedKeyTitle = VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.InputPage.UserDefinedKey.UserDefinedKeyTitle").ToString();
        public static string DeviceButton = _notLEMask ? "//*[@AutomationId='menu-main-nav-lnk-dropdown-toggle-device']" : "//*[@AutomationId='menu-main-nav-lnk-dropdown-toggle-device']";
        public static string MyDevicePage = _notLEMask ? "//*[@AutomationId='menu-main-nav-lnk-dropdown-menu-device-1']" : "//*[@AutomationId='menu-main-nav-lnk-dropdown-menu-device-1']";
        public static string InputPage = _notLEMask ? "//*[@AutomationId='myDevice-settings-header-menu-input-accessories']" : "//*[@AutomationId='myDevice-settings-header-menu-input-accessories']";
        public static string DisplayCameraPage = _notLEMask ? "//*[@AutomationId='myDevice-settings-header-menu-display-camera']" : "//*[@AutomationId='myDevice-settings-header-menu-display-camera']";
        public static string UserDefinedFeatureDescription = _notLEMask ? "//*[@AutomationId='ds-ip-userdefined-key-caption']" : "//*[@AutomationId='ds-ip-userdefined-key-caption']";
        public static string UserDefinedKeyDropdownBtn = VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.InputPage.UserDefinedKey.UserDefinedKeyDropDownBtn").ToString();
        public static string PleaseSelectOption = VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.InputPage.UserDefinedKey.PleaseSelectOption").ToString();
        public static string QuickSettingsTitle = _notLEMask ? "//*[@AutomationId='dashboard-quick-settings-title']" : "//*[@AutomationId='dashboard-quick-settings-title']";
        public static string OpenAppFileOption = VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.InputPage.UserDefinedKey.OpenAppFileOption").ToString();
        public static string OpenWebsiteOption = VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.InputPage.UserDefinedKey.OpenWebsiteOption").ToString();
        public static string InvokeKeyOption = VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.InputPage.UserDefinedKey.InvokeKeyOption").ToString();
        public static string EnterTextOption = VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.InputPage.UserDefinedKey.EnterTextOption").ToString();
        public static string UserDefinedKeyApplicationsTitle = _notLEMask ? "//*[@AutomationId='applications-toOpen']" : "//*[@AutomationId='applications-toOpen']";
        public static string UserDefinedKeyApplicationsPlusIcon = VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.InputPage.UserDefinedKey.UserDefinedKeyApplicationsPlusIcon").ToString();
        public static string UserDefinedKeyFilesTitle = _notLEMask ? "//*[@AutomationId='files-toOpen']" : "//*[@AutomationId='files-toOpen']";
        public static string UserDefinedKeyFilesPlusIcon = VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.InputPage.UserDefinedKey.UserDefinedKeyFilesPlusIcon").ToString();
        public static string StandaloneAppList = _notLEMask ? "//*[@Name='Standalone Applications']" : "//*[@Name='Standalone Applications']";
        public static string StoreAppList = _notLEMask ? "//*[@Name='Store Applications']" : "//*[@Name='Store Applications']";
        public static string AddAppCancelButton = _notLEMask ? "//*[@AutomationId='CancelBtn']" : "//*[@AutomationId='CancelBtn']";
        public static string AddAppOKButton = _notLEMask ? "//*[@AutomationId='OKButton']" : "//*[@AutomationId='OKButton']";
        public static string ProgramsApp = _notLEMask ? "//*[@Name='Programs']" : "//*[@Name='Programs']";
        public static string PaintApp = _notLEMask ? "//*[@Name='Paint']" : "//*[@Name='Paint']";
        public static string Edge = _notLEMask ? "//*[@Name='Microsoft Edge']" : "//*[@Name='Microsoft Edge']";
        public static string LongFile = _notLEMask ? "//*[@Name='FileLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLA.txt']" : "//*[@Name='FileLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLA.txt']";
        public static string WebSiteURLText = _notLEMask ? "//*[@Name='WEBSITE URL']" : "//*[@Name='WEBSITE URL']";
        public static string WebsiteHelpTip = _notLEMask ? "//*[@AutomationId='ip-webseiteurl-text']" : "//*[@AutomationId='ip-webseiteurl-text']";
        public static string WebsiteApplyButton = _notLEMask ? "//*[@AutomationId='ip-userdefined-key-applybtn']" : "//*[@AutomationId='ip-userdefined-key-applybtn']";
        public static string InvalidURLTip = _notLEMask ? "//*[@Name='Please input a valid URL.']" : "//*[@Name='Please input a valid URL.']";
        public static string EnterTextNote = VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.InputPage.UserDefinedKey.EnterTextNote").ToString();
        public static string EnterTextBoxTitle = _notLEMask ? "//*[@AutomationId='ip-texttobe-entered']" : "//*[@AutomationId='ip-texttobe-entered']";
        public static string EnterTextHelpTip = _notLEMask ? "//*[@AutomationId='ip-text-entered']" : "//*[@AutomationId='ip-text-entered']";
        public static string EnterTextApplyButton = _notLEMask ? "//*[@AutomationId='ip-userdefined-key-applybtn']" : "//*[@AutomationId='ip-userdefined-key-applybtn']";
        public static string SuccURLTip = _notLEMask ? "//*[@AutomationId='userDefinedKey-successMessage']" : "//*[@AutomationId='userDefinedKey-successMessage']";
        public static string File1 = _notLEMask ? "//*[@Name='File1.txt']" : "//*[@Name='File1.txt']";
        public static string NotepadApp = _notLEMask ? "//*[@Name='Notepad']" : "//*[@Name='Notepad']";
        public static string QuickAssistApp = _notLEMask ? "//*[@Name='Quick Assist']" : "//*[@Name='Quick Assist']";
        public static string SnippingToolApp = _notLEMask ? "//*[@Name='Snipping Tool']" : "//*[@Name='Snipping Tool']";
        public static string StepsRecorderApp = _notLEMask ? "//*[@Name='Steps Recorder']" : "//*[@Name='Steps Recorder']";
        public static string WindowsMediaPlayerApp = _notLEMask ? "//*[@Name='Windows Media Player']" : "//*[@Name='Windows Media Player']";
        public static string DeletePaintApp = _notLEMask ? "//*[@AutomationId='delete-app-Paint']" : "//*[@AutomationId='delete-app-Paint']";
        public static string DeleteFile1 = _notLEMask ? "//*[@AutomationId='delete-file-File1.txt']" : "//*[@AutomationId='delete-file-File1.txt']";
        public static string DeleteButton = _notLEMask ? "//*[@Name='Delete']" : "//*[@Name='Delete']";
        public static string UserDefinedKeyApplicationsADDLink = _notLEMask ? "//*[@AutomationId='add-application']" : "//*[@AutomationId='add-application']";
        public static string UserDefinedKeyFilesADDLink = _notLEMask ? "//*[@AutomationId='add-file']" : "//*[@AutomationId='add-file']";
        public static string FileNameTitle = _notLEMask ? "//*[@AutomationId='1090']" : "//*[@AutomationId='1090']";
        public static string FilePathDropDown = _notLEMask ? "//*[@AutomationId='1148']" : "//*[@AutomationId='1148']";
        public static string FileType = _notLEMask ? "//*[@Name='Files of type:']" : "//*[@Name='Files of type:']";
        public static string FileOpenButton = _notLEMask ? "//Button[@AutomationId='1']" : "//Button[@AutomationId='1']";
        public static string FileCanaelButton = _notLEMask ? "//Button[@AutomationId='2']" : "//Button[@AutomationId='2']";
        public static string InvokeKeySequenceInputForm = _notLEMask ? "//*[@AutomationId='invoke-key-sequence']" : "//*[@AutomationId='invoke-key-sequence']";
        public static string InvokeKeyNote = _notLEMask ? "//*[@AutomationId='invoke-key-sequence-note']" : "//*[@AutomationId='invoke-key-sequence-note']";
        public static string InvokeKeySeuqenceTextTitle = _notLEMask ? "//*[@AutomationId='ip-texttobe-entered-keysequence']" : "//*[@AutomationId='ip-texttobe-entered-keysequence']";
        public static string InvokeKeySequenceApplyButton = _notLEMask ? "//*[@AutomationId='ip-userdefined-key-applybtn']" : "//*[@AutomationId='ip-userdefined-key-applybtn']";
        public static string InputMoreLink = _notLEMask ? "//*[@AutomationId='inputAccessories.controlOptions.more']" : "//*[@AutomationId='inputAccessories.controlOptions.more']";
        public static string DelectKeySequence = _notLEMask ? "//*[@AutomationId='delete-key-sequence']" : "//*[@AutomationId='delete-key-sequence']";

        public static string PleaseSelectOptionUISPEC = "Please select";
        public static string OpenWebsiteOptionUISPEC = "Open website";
        public static string OpenAppFileOptionUISPEC = "Open applications or files";
        public static string InvokeKeyOptionUISPEC = "Invoke key sequence";
        public static string EnterTextOptionUISPEC = "Enter text";
        public static string UserDefinedKeyApplicationsTitleUISPEC = "APPLICATIONS TO OPEN";
        public static string UserDefinedKeyFilesTitleUISPEC = "FILES TO OPEN";
        public static string UserDefinedKeyApplicationsADDLinkUISPEC = VantageConstContent.VantageTypePlan == VantageType.LE ? null : "ADD";
        public static string UserDefinedKeyFilesADDLinkUISPEC = VantageConstContent.VantageTypePlan == VantageType.LE ? null : "ADD";
        public static string PaintAppUISPEC = "Paint";
        public static string File1UISPEC = "File1.txt";
        public static string DeletePaintAppUISPEC = "Delete";
        public static string DeleteFile1UISPEC = "Delete";
        public static string UserDefinedFeatureDescriptionUISPEC = VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.InputPage.UserDefinedKey.UserDefinedFeatureDescriptionUISPEC").ToString();
        public static string FileNameTitleUISPEC = "File name:";
        public static string FileOpenButtonUISPEC = "Open";
        public static string FileCanaelButtonUISPEC = "Cancel";
        public static string InvokeKeyNoteUISPEC = "Note: Fn and all the punctuation are not supported for this function.";
        public static string InvokeKeySeuqenceTextTitleUISPEC = "KEY SEQUENCE";
        public static string DelectKeySequenceUISPEC = "Delete";
        public static string WebsiteHelpTipUISPEC = @"Please start with http:// or https://";
        public static string EnterTextNoteUISPEC = VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.InputPage.UserDefinedKey.EnterTextNoteUISPEC").ToString();
        public static string EnterTextBoxTitleUISPEC = @"TEXT TO BE ENTERED";
        public static string EnterTextHelpTipUISPEC = @"Please type here";
        public static string SuccURLTipUISPEC = @"The settings are applied successfully.";
        public static string NetworkBoostEffectToastUISPEC = "Lenovo VantageNetwork Boost is prioritizing network traffic to provide better gaming experience.";
        public static string AutoCloseEffectToastUISPEC = "Lenovo VantageAuto Close is optimizing your system resources.";
        public static string NetworkBoostPromotionToastUISPEC = "Lenovo VantageNetwork Boost prioritizes network traffic to improve your gaming experience. Turn it on now?";
        public static string AutoClosePromotionToastUISPEC = "Lenovo VantageTurn on Auto Close to optimize your system resources?";

        //The old ID
        public static string ActionUserDefinedKey = "//*[@AutomationId='ip-userdefinedkey-dropdown-btn']";
        public static string PleaseSelect = "//*[@AutomationId='userdefinedkey-0']";
        public static string OpenWebSite = "//*[@AutomationId='userdefinedkey-1']";
        //public static string OpenWebSite = "//*[@AutomationId='userdefinedkey-0']";
        public static string OpenWebSiteSecond = "//*[@AutomationId='userdefinedkey-2']";
        //public static string OpenWebSiteSecond = "//*[@AutomationId='userdefinedkey-1']";
        public static string EnterText = "//*[@AutomationId='userdefinedkey-3']";
        //public static string EnterText = "//*[@AutomationId='userdefinedkey-1']";
        public static string EnterTextSecond = "//*[@AutomationId='userdefinedkey-4']";
        //public static string EnterTextSecond = "//*[@AutomationId='userdefinedkey-2']";
        public static string ApplyButton = "//*[@AutomationId='ip-userdefined-key-applybtn']";
        public static string WebSiteTextField = "//*[@AutomationId='ip-webseiteurl-text']";
        public static string EnterTextField = "//*[@AutomationId='ip-text-entered']";
        //public static string UserDefinedKeyTitle = "//*[@AutomationId='ds-ip-userdefined-key-title']";
        public static string UserDefinedKeyCaption = "//*[@AutomationId='ds-ip-userdefined-key-caption']";
        public static string More = "//*[@AutomationId='inputAccessories.controlOptions.more']";
        public static string KeyboardtoprowfunctionDescription = "//*[@Name='Keyboard top-row function']";
        public static string KeyboardtoprowfunctionTipunderbutton = "//*[@Name='To access special function, press Fn and the keys on the top row.']";
        public static string KeyboardtoprowfunctionSpecialFuction = "//*[@AutomationId='radio1']";
        public static string KeyboardtoprowfunctionF1Fuction = "//*[@AutomationId='radio2']";
        public static string BatteryGoodConditionTip = "//*[@Name='The battery is in good condition.']";
        public static string BatteryFairConditionTip = "//*[@AutomationId='battery-condition-tip-StoreLimitation']";
        public static string BatteryPoorConditionTip = "//*[@AutomationId='battery-condition-tip-StoreLimitation']";
        public static string BatteryPermanentErrorConditionTip = "//*[@Name='The battery capacity has been degraded . Please replace a new one.']";
        public static string BatteryHightEmperatureConditionTip = "//*[@Name='Discharging has been stopped because the battery temperature is too high.']";
        public static string BatteryTrickleChargeConditionTip = "//*[@Name='The battery was completely discharged and needs to be recharged. This might take ten hours or more.']";
        public static string BatteryOverHeatedConditionTip = "//*[@Name='The battery is too hot . Remove it from the computer and cool it to room temperature.']";
        public static string BatteryHwAuthenticationErrorConditionTip = "//*[@Name='The battery installed is not supported by the system and will not charge. Please replace the battery with the correct Lenovo battery for this system.']";
        //HS Keystroke Suppression 
        public static string KeystrokeSuppressionCheckBoxXpath = "//*[@AutomationId='audio-microphone-suppress_checkbox']";
        public static string KeystrokeSuppressionMask = "//*[@AutomationId='audio-microphone-suppress-tooltip_right_icon']";
        public static string KeystrokeTooltipToolTip = "//*[@AutomationId='audio-microphone-suppress-toolTip']";

        //Keyboard Top Row Function
        public static string KeyboardToprowFunctionTitle = "//*[@AutomationId='inputAccessory.topRowFunctions.title']";
        public static string KeyboardToprowFunctionTitleIcon = "";  //temp
        public static string KeyboardToprowFunctionDesc = "//*[@AutomationId='inputAccessory.topRowFunctions.subSection.description']";
        public static string KeyboardToprowFunctionSubDesc = "//*[@AutomationId='inputAccessory.topRowFunctions.subSection.description']";
        public static string KeyboardToprowFunctionAdvanceSettings = "//*[@AutomationId='inputAccessory.topRowFunctions.showAdvSettings']";
        public static string KeyboardToprowFunctionSpecialFunctionRadioButton = "//*[@AutomationId='radio1']";
        public static string KeyboardToprowFunctionSpecialFunctionRadioButtonText = "//*[@AutomationId='myDevice-settings-inputAccessories-top-row-functions-thinkpad-icomoon icomoon-Special-function-label']";
        public static string KeyboardToprowFunctionF11F12FunctionRadioButton = "//*[@AutomationId='radio2']";
        public static string KeyboardToprowFunctionF11F12FunctionRadioButtonText = "//*[@AutomationId='myDevice-settings-inputAccessories-top-row-functions-thinkpad-icomoon icomoon-F1-F12-funciton-labe']";
        public static string KeyboardToprowFunctionReversingPrimaryFunctionTitle = "//*[@AutomationId='inputAccessories-hiddenKeyboardFunctions-title']";
        public static string KeyboardToprowFunctionReversingPrimaryFunctionDesc = "//*[@AutomationId='inputAccessories-hiddenKeyboardFunctions-caption']";
        public static string KeyboardToprowFunctionReversingPrimaryFunctionToggle = "//*[@AutomationId='inputAccessories-hiddenKeyboardFunctions_checkbox']";
        public static string KeyboardToprowFunctionReversingPrimaryFunctionQuestionMark = "//*[@AutomationId='inputAccessories-hiddenKeyboardFunctions-tooltip_right_icon']";
        public static string KeyboardToprowFunctionReversingPrimaryFunctionQuestionMarkDesc = "//*[@AutomationId='inputAccessories-hiddenKeyboardFunctions-toolTip']";
        public static string KeyboardToprowFunctionFnKeyCombinationsTitle = "//*[@AutomationId='inputAccessory.topRowFunctions.subSectionThree.title']";
        public static string KeyboardToprowFunctionFnKeyCombinationsDesc = "//*[@AutomationId='inputAccessory.topRowFunctions.subSectionThree.description']";
        public static string KeyboardToprowFunctionFnKeyCombinationsNormalMethod = "//*[@AutomationId='divnMehod_show']";
        public static string KeyboardToprowFunctionFnKeyCombinationsFnStickyKeyMethod = "//*[@AutomationId='divfnKeyMehod_show']";
        public static string KeyboardToprowFunctionFnKeyCombinationsNote = "//*[@AutomationId='top-row-sticky-note-title']";
        public static string KeyboardToprowFunctionHideAdvanceSettings = "//*[@AutomationId='inputAccessory.topRowFunctions.hideAdvSettings']";
        public static string KeyboardToprowFunctionRebootPopupTitle = "//*[@AutomationId='ds-reboot-popup']";
        public static string KeyboardToprowFunctionRebootPopupCloseBtn = ""; //No Xpath
        public static string KeyboardToprowFunctionRebootPopupDesc = "";  //No Xpath
        public static string KeyboardToprowFunctionRebootPopupRebootBtnEnable = "//*[@AutomationId='reboot-popup-enable']";
        public static string KeyboardToprowFunctionRebootPopupRebootBtnCancel = "//*[@AutomationId='reboot-popup-cancel']";

        //Vantage HS Gaming Macro Key

        public static string gamingDashBoardmacroKeyIcon = "//*[@AutomationId='gaming_dashboard_systemtools_macrokey']";
        public static string gamingMacroKeyItemList = "//List/Button";
        public static string gamingMacroKeyPlanContent = "//Group[@LocalizedControlType='group']/Text";
        public static string gamingMacroKeySubPageComboxButton = "//Button[@AutomationId='gaming_macrokey_settings_drop_menu']";
        public static string gamingMacroKeySubPageComBox_On = "//*[@AutomationId='macro key settings on']";
        public static string gamingMacroKeySubPageComBox_OnlyGaming = "//*[@AutomationId='macro key settings enabled when gaming']";
        public static string gamingMacroKeySubPageComBox_Off = "//*[@AutomationId='macro key settings off']";
        public static string gamingMacroKeyStartRecording = "//Button[@AutomationId='gaming_macrokey_startrecording']";
        public static string gamingMacroKeyStopRecording = "//Button[@AutomationId='gaming_macrokey_stoprecording']";
        public static string gamingMacroKeyClear = "//Button[@AutomationId='macrokey_clear_records']";
        public static string gamingMacroKeyConfirmClear = "//Button[@AutomationId='macrokey_clear_records_dialog_clear_btn']";
        public static string gamingMacroKeyCancelClear = "//Button[@AutomationId='macrokey_popup_cancel']";
        public static string gamingMacroKeyDeleteListPath = "//Button[starts-with(@AutomationId,'macrokey_delete')]";
        public static string gamingMacroKeyRepeatCombox = "//Combox[@AutomationId='gaming_macro_key_ settings_repeat drop']";
        public static string gamingMacroKeyDelayCombox = "//Combox[@AutomationId='gaming_macro_key_settings_delay drop']";

        public static string gamingMacroKeyButtonNumber_0 = "//Button[@AutomationId='macrokey_numpad-0']";
        public static string gamingMacroKeyButtonNumber_1 = "//Button[@AutomationId='macrokey_numpad-1']";
        public static string gamingMacroKeyButtonNumber_2 = "//Button[@AutomationId='macrokey_numpad-2']";
        public static string gamingMacroKeyButtonNumber_3 = "//Button[@AutomationId='macrokey_numpad-3']";
        public static string gamingMacroKeyButtonNumber_4 = "//Button[@AutomationId='macrokey_numpad-4']";
        public static string gamingMacroKeyButtonNumber_5 = "//Button[@AutomationId='macrokey_numpad-5']";
        public static string gamingMacroKeyButtonNumber_6 = "//Button[@AutomationId='macrokey_numpad-6']";
        public static string gamingMacroKeyButtonNumber_7 = "//Button[@AutomationId='macrokey_numpad-7']";
        public static string gamingMacroKeyButtonNumber_8 = "//Button[@AutomationId='macrokey_numpad-8']";
        public static string gamingMacroKeyButtonNumber_9 = "//Button[@AutomationId='macrokey_numpad-9']";

        //Toast Message
        public static string RegistryNetworkBoost = @"HKCU\SOFTWARE\Lenovo\ImController\PluginData\GamingPlugin\Toast\NetworkBst";
        public static string RegistryAutoClose = @"HKCU\SOFTWARE\Lenovo\ImController\PluginData\GamingPlugin\Toast\AutoClose";
        public static string RegistryToast = @"HKCU\SOFTWARE\Lenovo\ImController\PluginData\GamingPlugin\Toast";
        public static string NetworkBoostPromotionShownTimes = @"HKCU\SOFTWARE\Lenovo\ImController\PluginData\GamingPlugin\Toast\NetworkBst\OffAlarmTimes";
        public static string NetworkBoostEffectShownTimes = @"HKCU\SOFTWARE\Lenovo\ImController\PluginData\GamingPlugin\Toast\NetworkBst\FeatureTipsTimes";
        public static string AutoClosePromotionShownTimes = @"HKCU\SOFTWARE\Lenovo\ImController\PluginData\GamingPlugin\Toast\AutoClose\OffAlarmTimes";
        public static string AutoCloseEffectShownTimes = @"HKCU\SOFTWARE\Lenovo\ImController\PluginData\GamingPlugin\Toast\AutoClose\FeatureTipsTimes";
        public static string GamingFeatureDriverDesc = "Lenovo Gaming NetFilter Device";
        public static string ToastBtn = "//*[@AutomationId='VerbButton']";
        public static string DismissBtn = "//*[@AutomationId='DismissButton']";
        public static string MessagingHistoryData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Lenovo\ImController\PluginData\GenericMessagingPlugin\db\MessagingHistory.sqlite";

        //Overclock
        public static string RegistryCentralProcessor = @"HARDWARE\DESCRIPTION\System\CentralProcessor\0";
        public static string ProcessorName = "ProcessorNameString";

        //Gaming tag
        public static string GamingTag = @"HKLM\SOFTWARE\WOW6432Node\Lenovo\ImController\Applicability\Tags";

        //Airplane Power Mode
        public static string AireplanePowerModeCheckBox = "//*[@AutomationId='ds-power-battery-airplane_checkbox']";
        public static string AutodetectionCheckBox = NotLEMask ? "//*[@AutomationId='cb-airplane-mode_checkbox']" : "//*[@AutomationId='cb-airplane-mode']";
        public static string GetBatteryPower = "//*[@AutomationId='myDevice-settings-battery-condition-tip']";
        public static string AutoDecetionNote = "//*[@AutomationId='power.batterySettings.airPlanePower.note']";
        public static string AutoDecetionNoteText = "If Auto detection is checked, your computer will turn on Airplane power mode automatically when it detects an airplane onboard environment and turn off it when you leave.";

        //Power Options
        public static string PowerOptions = @"//*[@Name='Power Options']";
        public static string PowerOptionsCloseBtn = @"//*[@Name='Close']";
        public static string PowerSaveChangesBtn = @"//*[@AutomationId='Link_Accept']";

        // Vantage HS Idea Backlight    
        public static string HSIdeaBacklightCheckBox = "//*[@AutomationId='inputAccessories-backlight_checkbox']";

        //Integrated Camera DeviceID
        //public static string CameraDeviceID = @"USB\VID_13D3&PID_56B2&MI_00";
        public static string CameraDeviceID = @"USB\VID_04F2&PID_B67C&MI_00";

        private static string _vantagePath = string.Empty;
        public static string DataPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).FullName;

        public static string VantageInstallPs1Path
        {
            get
            {
                switch (VantageConstContent.VantageTypePlan)
                {
                    case VantageType.LE:
                        _vantagePath = Path.Combine(DataPath, "Data\\Vantage\\bj_le");
                        break;
                    case VantageType.OldShellOldPlugin:
                    case VantageType.OldShellNewPlugin:
                        _vantagePath = Path.Combine(DataPath, "Data\\Vantage\\bj_store");
                        break;
                    case VantageType.NewShellOldPlugin:
                    case VantageType.NewShellNewPlugin:
                        _vantageServer = Path.Combine(DataPath, "Data\\Vantage\\bj_latest");
                        break;
                    case VantageType.TestSelf:
                        _vantagePath = Path.Combine(DataPath, "Data\\Vantage\\bj_testself");
                        break;
                    default:
                        _vantagePath = Path.Combine(DataPath, "Data\\Vantage\\bj_latest");
                        break;
                }
                return _vantagePath;
            }
        }

        public static string VantageInstallPs1Server
        {
            get
            {
                switch (VantageConstContent.VantageTypePlan)
                {
                    case VantageType.OldShellOldPlugin:
                    case VantageType.OldShellNewPlugin:
                        _vantageServer = Path.Combine(DataPath, "Data\\Vantage\\OldShellConfig.xml");
                        break;
                    case VantageType.NewShellOldPlugin:
                    case VantageType.NewShellNewPlugin:
                        _vantageServer = Path.Combine(DataPath, "Data\\Vantage\\NewShellConfig.xml");
                        break;
                    case VantageType.MicroFrontends:
                        _vantageServer = Path.Combine(DataPath, "Data\\Vantage\\MicroServerConfig.xml");
                        break;
                    case VantageType.LE:
                        _vantageServer = Path.Combine(DataPath, "Data\\Vantage\\LeServerConfig.xml");
                        break;
                    case VantageType.TestSelf:
                        _vantageServer = Path.Combine(DataPath, "Data\\Vantage\\TestSelfConfig.xml");
                        break;
                    default:
                        _vantageServer = Path.Combine(DataPath, "Data\\Vantage\\ServerConfig.xml");
                        break;
                }
                return _vantageServer;
            }
        }

        public static string GetVantageUwpAppName()
        {
            switch (VantageConstContent.VantageTypePlan)
            {
                case VantageType.LE:
                    return VantageLEUwpAPPIdName;
                default:
                    return VantageCommonAppIdName;
            }
        }

        public static string GetVantageFileName()
        {
            switch (VantageConstContent.VantageTypePlan)
            {
                case VantageType.MicroFrontends:
                    return MicroVantageFileName;
                default:
                    return CommonVantageFileName;
            }
        }

        public static string GetVantageUwpAppFolderName()
        {
            switch (VantageConstContent.VantageTypePlan)
            {
                case VantageType.LE:
                    return VantageLEUwpAppFolderName;
                default:
                    return VantageCommonUwpAppFolderName;
            }
        }

        public static string VantageConfigJsonFilePath
        {
            get
            {
                switch (VantageConstContent.VantageTypePlan)
                {
                    case VantageType.LE:
                        return string.Format("Packages\\{0}\\LocalState\\config.json", VantageConstContent.GetVantageUwpAppName() + "_k1h2ywk1493x8");
                    default:
                        return string.Format("Packages\\{0}\\LocalState\\config.json", VantageConstContent.GetVantageUwpAppName() + "_k1h2ywk1493x8");
                }
            }
        }

        public static string VantageProcessName
        {
            get
            {
                if (Common.GetRunningProcess("LenovoVantage"))
                {
                    return "LenovoVantage";
                }
                return "ApplicationFrameHost";
            }
        }

        public static string VantageUwpAppid
        {
            get
            {
                switch (VantageConstContent.VantageTypePlan)
                {
                    case VantageType.LE:
                        return _vantageLEUwpAppid;
                    default:
                        return _vantageCommonUwpAppid;
                }
            }

        }

        private static string _vantageServer = string.Empty;

        //day-time-color-temp-title
        public static List<string> EcmWhiteList = new List<string>() {"M2RKT","M38KT","M29KT","M20KT","M1QKT","M1PKT",
            "M12KT","M1BKT","M1EKT","M1CKT","M1NKT","M1MKT","M38KT","M1RKT","M2DKT","M2DKT","M2EKT","M1QMF"};
        //HardwareSettings FlitBoot

        //HardwareSsettings support machin
        public static string HS_RapidChargeIdeapadBlockList = "Yoga 920-131KB,Yoga S740-14IIL";
        public static string HS_Conservation = "Yoga S740-14IIL, IDEAPAD, Yoga S730-13IWL, ThinkBook Plus";
        public static string HS_FlitBootSupportList = "Yoga S730-13IWL,Yoga S740-14IIL,IdeaPad S540-13IML,IdeaPad S540-13API,Flex 3-11-05";


        public enum ToolBarAutoEnum
        {
            ToolBar = 2000,
            DTToolBar = 2001,
            ToolBarTitle = 1000,
            AllSettingsBtn = 1008,
            ToolBarCloseBtn = 1002,
            BatteryPercentageImage = 1001,
            MicrophoneToggle = 1011,
            MicrophoneIcon = 1026,
            EyeCareModeToggle = 1019,
            EyeCareModeIcon = 1028,
            CameraPrivacyMode = 1015,
            CameraPrivacyModeIcon = 1027,
            IntelligentCoolingLink = 1050,
            IntelligentCoolingMode = 1051,
            BatteryDetailsLink = 1006,
            BatteryDetails = 1052,
            WIFISecurity = 1056,
            Camera = 1057,
            Microphone = 1058,
            KeyboardBacklight = 1060,
            TopRowKey = 1061,
            PrivacyGuard = 1063,
            BatteryChargeThreshold = 1065,
            AirplanePowerMode = 1067,
            ConservationMode = 1068,
            RapidCharge = 1071,
            ITSMode = 1070,
            ECourseIcon = 1072,
            chargeIcon = 2001,
            GoToVantage = 1075,
            AirplaneNoticYesBtn = 1016,
            AirplaneNoticNoBtn = 1017,
            ViewWarrantyOptionLink = 1088,
            ShowHiddenIcon = 1502,
            Overflowarea = 1504,
            CommentsFeedBackLink = 1089,
            EyeCareMode = 1073,
            UnpinFromTaskbar = 32771,
            Nothing = 0
        }

        public static Dictionary<string, string> AutomationIDKeyMap = new Dictionary<string, string>
        {
            {"DeviceButton", DeviceButton},
            {"MyDevicePage", MyDevicePage},
            {"DisplayCameraPage",DisplayCameraPage},
            {"InputPage", InputPage},
            {"QuickSettingsTitle", QuickSettingsTitle},
            {"UserDefinedKeyTitle", UserDefinedKeyTitle},
            {"UserDefinedKeyDropdownBtn", UserDefinedKeyDropdownBtn},
            {"PleaseSelectOption", PleaseSelectOption},
            {"OpenAppFileOption", OpenAppFileOption},
            {"OpenWebsiteOption", OpenWebsiteOption},
            {"InvokeKeyOption", InvokeKeyOption},
            {"EnterTextOption", EnterTextOption},
            {"UserDefinedKeyApplicationsTitle",UserDefinedKeyApplicationsTitle},
            {"UserDefinedKeyApplicationsPlusIcon",UserDefinedKeyApplicationsPlusIcon},
            {"UserDefinedKeyFilesTitle",UserDefinedKeyFilesTitle},
            {"UserDefinedKeyFilesPlusIcon",UserDefinedKeyFilesPlusIcon},
            {"PrivacyGuardToggle",PrivacyGuardToggle},
            {"StandaloneAppList",StandaloneAppList},
            {"StoreAppList",StoreAppList},
            {"AddAppCancelButton",AddAppCancelButton},
            {"AddAppOKButton",AddAppOKButton},
            {"ProgramsApp",ProgramsApp},
            {"PaintApp",PaintApp},
            {"File1",File1},
            {"DeletePaintApp",DeletePaintApp},
            {"DeleteFile1",DeleteFile1},
            {"DeleteButton",DeleteButton},
            {"UserDefinedKeyApplicationsADDLink",UserDefinedKeyApplicationsADDLink},
            {"UserDefinedKeyFilesADDLink",UserDefinedKeyFilesADDLink},
            {"NotepadApp",NotepadApp},
            {"QuickAssistApp",QuickAssistApp},
            {"SnippingToolApp",SnippingToolApp},
            {"StepsRecorderApp",StepsRecorderApp},
            {"WindowsMediaPlayerApp",WindowsMediaPlayerApp},
            {"UserDefinedFeatureDescription",UserDefinedFeatureDescription},
            {"FileNameTitle",FileNameTitle},
            {"FilePathDropDown",FilePathDropDown},
            {"FileType",FileType},
            {"FileOpenButton",FileOpenButton},
            {"FileCanaelButton",FileCanaelButton},
            {"InvokeKeySequenceInputForm",InvokeKeySequenceInputForm},
            {"InvokeKeyNote",InvokeKeyNote},
            {"InvokeKeySeuqenceTextTitle",InvokeKeySeuqenceTextTitle},
            {"InvokeKeySequenceApplyButton",InvokeKeySequenceApplyButton},
            {"InputMoreLink",InputMoreLink},
            {"DelectKeySequence",DelectKeySequence},
            {"Edge",Edge},
            {"LongFile",LongFile},
            {"WebSiteURLText",WebSiteURLText},
            {"WebsiteHelpTip",WebsiteHelpTip},
            {"WebsiteApplyButton",WebsiteApplyButton},
            {"InvalidURLTip",InvalidURLTip},
            {"EnterTextNote",EnterTextNote},
            {"EnterTextBoxTitle",EnterTextBoxTitle},
            {"EnterTextHelpTip",EnterTextHelpTip},
            {"EnterTextApplyButton",EnterTextApplyButton},
            {"SuccURLTip",SuccURLTip}
        };

        public static Dictionary<string, string> UISpecKeyMap = new Dictionary<string, string>
        {
            {"PleaseSelectOption", PleaseSelectOptionUISPEC},
            {"OpenAppFileOption", OpenAppFileOptionUISPEC},
            {"OpenWebsiteOption", OpenWebsiteOptionUISPEC},
            {"InvokeKeyOption", InvokeKeyOptionUISPEC},
            {"EnterTextOption", EnterTextOptionUISPEC},
            {"UserDefinedKeyApplicationsTitle",UserDefinedKeyApplicationsTitleUISPEC},
            {"UserDefinedKeyFilesTitle",UserDefinedKeyFilesTitleUISPEC},
            {"UserDefinedKeyApplicationsADDLink",UserDefinedKeyApplicationsADDLinkUISPEC},
            {"UserDefinedKeyFilesADDLink",UserDefinedKeyFilesADDLinkUISPEC},
            {"PaintApp",PaintAppUISPEC},
            {"File1",File1UISPEC},
            {"DeletePaintApp",DeletePaintAppUISPEC},
            {"DeleteFile1",DeleteFile1UISPEC},
            {"UserDefinedFeatureDescription",UserDefinedFeatureDescriptionUISPEC},
            {"FileNameTitle",FileNameTitleUISPEC},
            {"FileOpenButton",FileOpenButtonUISPEC},
            {"FileCanaelButton",FileCanaelButtonUISPEC},
            {"InvokeKeyNote",InvokeKeyNoteUISPEC},
            {"InvokeKeySeuqenceTextTitle",InvokeKeySeuqenceTextTitleUISPEC},
            {"DelectKeySequence",DelectKeySequenceUISPEC},
            {"WebsiteHelpTip",WebsiteHelpTipUISPEC},
            {"EnterTextNote",EnterTextNoteUISPEC},
            {"EnterTextBoxTitle",EnterTextBoxTitleUISPEC},
            {"EnterTextHelpTip",EnterTextHelpTipUISPEC},
            {"NetworkBoostEffectToast",NetworkBoostEffectToastUISPEC},
            {"AutoCloseEffectToast",AutoCloseEffectToastUISPEC},
            {"NetworkBoostPromotionToast",NetworkBoostPromotionToastUISPEC},
            {"AutoClosePromotionToast",AutoClosePromotionToastUISPEC},
            {"SuccURLTip",SuccURLTipUISPEC}
        };

        public static Dictionary<string, string> DeviceIDKeyMap = new Dictionary<string, string>
        {
            {"IntegratedCameraDeviceID", CameraDeviceID},
        };

        public static Dictionary<string, string> RegistryKeyMap = new Dictionary<string, string>
        {
            {"NetworkBoostPromotionShownTimes", NetworkBoostPromotionShownTimes},
            {"AutoClosePromotionShownTimes", AutoClosePromotionShownTimes},
            {"NetworkBoostEffectShownTimes", NetworkBoostEffectShownTimes},
            {"AutoCloseEffectShownTimes", AutoCloseEffectShownTimes}
        };

        public static Dictionary<string, Keys> KeyboardKeyMap = new Dictionary<string, Keys>
        {
            {"0", Keys.NumPad0},
            {"1", Keys.NumPad1},
            {"2", Keys.NumPad2},
            {"3", Keys.NumPad3},
            {"4", Keys.NumPad4},
            {"5", Keys.NumPad5},
            {"6", Keys.NumPad6},
            {"7", Keys.NumPad7},
            {"8", Keys.NumPad8},
            {"9", Keys.NumPad9},
            {"m1", Keys.F14},
            {"m2", Keys.F15}
        };

        public static Dictionary<string, string> WindowsActionCenterMap = new Dictionary<string, string>
        {
            {"TabletMode", @"//*[@AutomationId='Microsoft.QuickAction.TabletMode']"},
            {"Bluetooth", @"//*[@AutomationId='Microsoft.QuickAction.Bluetooth']"},
            {"AirplaneMode", @"//*[@AutomationId='Microsoft.QuickAction.AirplaneMode']"},
            {"AllSettings", @"//*[@AutomationId='Microsoft.QuickAction.AllSettings']"}
        };

        public static Dictionary<string, string> PowerChangePlanSettingsMap = new Dictionary<string, string>
        {
            {"Change plan settings for the Legion Performance Mode plan", @"//*[@Name='Change plan settings for the Legion Performance Mode plan']"},
            {"Change plan settings for the Legion Balance Mode plan", @"//*[@Name='Change plan settings for the Legion Balance Mode plan']"},
            {"Change plan settings for the Legion Quiet Mode plan", @"//*[@Name='Change plan settings for the Legion Quiet Mode plan']"}
        };

        public static List<string> PowerDisplaySleepMap = new List<string>
        {
            @"//*[@Name='Turn off the display: (On battery)']",
            @"//*[@Name='Put the computer to sleep: (On battery)']",
        };

        public static List<string> PowerDisplaySleepTimeMap = new List<string>
        {
            @"//*[@Name='Never']",
            @"//*[@Name='1 minute']",
            @"//*[@Name='2 minutes']",
            @"//*[@Name='3 minutes']",
            @"//*[@Name='5 minutes']",
            @"//*[@Name='10 minutes']",
            @"//*[@Name='15 minutes']",
            @"//*[@Name='20 minutes']",
            @"//*[@Name='25 minutes']",
            @"//*[@Name='30 minutes']",
            @"//*[@Name='45 minutes']",
            @"//*[@Name='1 hour']",
            @"//*[@Name='2 hours']",
            @"//*[@Name='3 hours']",
            @"//*[@Name='4 hours']",
            @"//*[@Name='5 hours']"
        };

        public static Dictionary<string, string> IdMap = new Dictionary<string, string>
        {
            {"TGP", "1"},
            {"Temperature", "2"}
        };

        public static Dictionary<string, string> ThermalModeMap = new Dictionary<string, string>
        {
            {"Performance", "3"},
            {"Balance", "2"},
            {"Quiet", "1"}
        };
    }
}
