using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Automation;

namespace LenovoVantageTest.Pages
{
    public class NerveCenterPages : SettingsBase
    {
        private WindowsDriver<WindowsElement> session;
        private List<string> _proProcess = new List<string> { "Microsoft WWA Host", "Lenovo.Modern.ImController", "Microsoft Visual Studio 2019", "Lenovo.Modern.ImController.PluginHost", "LenovoVantageService", "Host Process for Windows Services", "Java(TM) Platform SE binary", "Java Service Wrapper Standard Edition 3.5.39", "LenovoMultipleClient", "OpenJDK Platform binary", "SecureConnector" };

        public NerveCenterPages(WindowsDriver<WindowsElement> session)
        {
            if (session.SessionId == null)
            {
                string applicationId = "E046963F.LenovoCompanion_k1h2ywk1493x8!App";
                var factory = new BaseTestClass();
                var appInstance = factory.LaunchWinApplication(applicationId);
                session = appInstance.Session;
            }

            this.session = session;
            base.session = session;
        }


        public WindowsElement VantageMinimize => base.FindElementByTimes(session, "XPath", VantageConstContent.VantageMinizeId);
        public WindowsElement VantageMaximize => base.FindElementByTimes(session, "XPath", VantageConstContent.VantageMaxizeId);

        //Logo,Header,Section and HelpImage
        public WindowsElement YLogo => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='vantage_image_Y']");
        public WindowsElement LegionHeaderIMG => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='system_status_header_legion']");
        public WindowsElement LegionRightSectionIMG => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='right_section_legion_edge']");
        public WindowsElement LegionHelpPageIMG => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='help_popup_legion_edge']");
        public WindowsElement IdeapadHeaderIMG => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='system_status_header_ideapad_gaming']");
        public WindowsElement IdeapadRightSectionIMG => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='right_section_ideapad_gaming']");
        public WindowsElement IdeapadHelpPageIMG => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='help_popup_ideapad_gaming']");
        public WindowsElement IdeapadCentreHeaderIMG => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='system_status_header_ideapadcentre']");
        public WindowsElement IdeapadCentreRightSectionIMG => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='right_section_ideacentre_gaming']");
        public WindowsElement IdeapadCentreHelpPageIMG => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='help_popup_ideacentre_gaming']");


        //public WindowsElement YLogoName =>  base.FindElementByTimes(session, "XPath", "//*[@Name='cpu overlock off']");
        public WindowsElement VantageClose => FindElementByTimes(session, "XPath", "//*[@Name='Close Lenovo Vantage']");

        //Menu
        public WindowsElement HomePageHeaderLegion => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='system_status_header_legion']");
        public WindowsElement SecurityLink => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='menu-main-nav-lnk-dropdown-toggle-security']");
        public WindowsElement SupportLink => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='menu-main-nav-lnk-dropdown-toggle-support']");
        public WindowsElement GamingDeviceMenu => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='menu-main-nav-lnk-device']");
        public WindowsElement GamingLDropDown => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='navbarDropdown']");
        public WindowsElement LenovoMigrationAssistant => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='menu-main-lnk-open-lma']");
        public WindowsElement PreferenceSettingLink => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='menu-main-lnk-open-preference']");
        public WindowsElement GiveFeedbackLink => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='menu-main-lnk-open-feedback']");
        public WindowsElement CloseVantageBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='Close']");

        //Preference Settings page
        public WindowsElement PreferenceSettingsPageTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-settings-header-title']");
        public WindowsElement PreferenceSettingsPageBackBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='setting-page-btn-back']");
        public WindowsElement PreferenceSettingsUserProfileCollapse => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='settings-user-profile-panel-expansion-panel-header-customize']");
        public WindowsElement InterestTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='settings-interests-choose-title']");
        public WindowsElement HowWillYouBeUsingYourDeviceItem => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='settings-segment-choose-title']");
        public WindowsElement InterestSaveBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='settings-profile-save-button']");
        public WindowsElement GamesCheckbox => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gamescheckbox']");
        public WindowsElement NewsCheckbox => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='newscheckbox']");
        public WindowsElement EntertainmentCheckbox => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='entertainmentcheckbox']");
        public WindowsElement TechnologyChckebox => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='technologycheckbox']");
        public WindowsElement SportsCheckbox => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='sportscheckbox']");
        public WindowsElement ArtsCheckbox => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='artscheckbox']");
        public WindowsElement RegionalNewsChckebox => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='regionalNewscheckbox']");
        public WindowsElement PoliticsCheckbox => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='politicscheckbox']");
        public WindowsElement MusicCheckbox => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='musiccheckbox']");
        public WindowsElement ScienceChckebox => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='sciencecheckbox']");

        //System Status Section
        public WindowsElement GamingSystemStatus => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_system_status']");
        public WindowsElement SystemStatusInfoLink => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='gaming systemstatus info']", 3);
        public WindowsElement SystemStatusGPUInfo => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='system_status_driver_gpu_tooltip']");
        public WindowsElement SystemStatusCPUInfo => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='system_status_driver_cpu_tooltip']");
        public WindowsElement SystemStatusRAMInfo => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='system_status_driver_ram_tooltip']");
        public WindowsElement SystemStatusDiskInfo => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_system_status_drivers_list']");
        public WindowsElement SystemStatusDisk0Info => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='system_status_hard_disk0']");
        public WindowsElement SystemStatusDisk1Info => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='system_status_hard_disk1']");
        public WindowsElement SystemStatusDiskexpand => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_system_hard disk_icon_expand']");

        //Old CPU Overclocking
        public WindowsElement CPUOverClockingMenu => base.FindElementByTimes(session, "AutomationId", "gaming-drop cpu overlock");
        public WindowsElement CPUOverClockingMenuOn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='cpu overclock on']");
        public WindowsElement CPUOverClockingMenuOnName => base.FindElementByTimes(session, "XPath", "//*[@Name='On']");
        public WindowsElement CPUOverClockingMenuWhenGaming => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='cpu overclock when gaming']");
        public WindowsElement CPUOverClockingMenuWhenGamingName => base.FindElementByTimes(session, "XPath", "//*[@Name='When Gaming']");
        public WindowsElement CPUOverClockingMenuOff => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='cpu overclock off']");
        public WindowsElement CPUOverClockingMenuOffName => base.FindElementByTimes(session, "XPath", "//*[@Name='Off']");
        public WindowsElement CPUOverClockingOnName => base.FindElementByTimes(session, "XPath", "//*[@Name='cpu overlock on']");
        public WindowsElement CPUOverClockingOnTitleName => base.FindElementByTimes(session, "XPath", "//*[@Name='CPU Overclock cpu overlock on']");
        public WindowsElement CPUOverClockingWhenGamingName => base.FindElementByTimes(session, "XPath", "//*[@Name='cpu overlock when gaming']");
        public WindowsElement CPUOverClockingWhenGamingTitleName => base.FindElementByTimes(session, "XPath", "//*[@Name='CPU Overclock cpu overlock when gaming']");
        public WindowsElement CPUOverClockingOffName => base.FindElementByTimes(session, "Name", "cpu overlock off");
        public WindowsElement CPUOverClockingOffTitleName => base.FindElementByTimes(session, "XPath", "//*[@Name='CPU Overclock cpu overlock off']");

        //Nahimic
        public string NahimicPopWindowdialogTitle = "Do you want to install Nahimic?";
        public string NahimicPopWindowdialogDesc = "Nahimic drastically improves your gaming experience by providing for unprecedent immersive 3D audio and engaging features for gamers. Nahimic is a new way of playing.";
        public string NahimicWebName = "Nahimic";

        public WindowsElement NahimicPopWindow => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='nahimic_install_popup']");
        public WindowsElement NahimicPopWindowInstallButton => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='nahimic_install_popup_install_button']");
        public WindowsElement NahimicPopWindowCancelButton => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='nahimic_install_popup_cancel_button']");
        public WindowsElement NahimicPopWindowCloseButton => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='nahimic_close_button']");
        public WindowsElement NahimicPopWindowdialogTitleEle => base.FindElementByTimes(session, "XPath", string.Format("//*[@Name='{0}']", NahimicPopWindowdialogTitle));
        public WindowsElement NahimicPopWindowdialogDescEle => base.FindElementByTimes(session, "XPath", string.Format("//*[@Name='{0}']", NahimicPopWindowdialogDesc));

        //X-Rite
        public string XritePopWindowdialogTitle = "Do you want to install X-Rite Color Assistant?";
        public string XritePopWindowdialogDesc = "This app enables you to choose and apply factory calibrated color profiles.";
        public string XriteWebName = "X-Rite Color Assistant Setup Driver for Windows 10 (32-bit), (64-bit) - Ideapad";

        public WindowsElement XritePopWindow => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='xRite_install_popup']");
        public WindowsElement XritePopWindowInstallButton => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='xRite_install_popup_install_button']");
        public WindowsElement XritePopWindowCancelButton => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='xRite_install_popup_cancel_button']");
        public WindowsElement XritePopWindowCloseButton => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='xRite_close_button']");
        public WindowsElement XritePopWindowdialogTitleEle => base.FindElementByTimes(session, "XPath", string.Format("//*[@Name='{0}']", XritePopWindowdialogTitle));
        public WindowsElement XritePopWindowdialogDescEle => base.FindElementByTimes(session, "XPath", string.Format("//*[@Name='{0}']", XritePopWindowdialogDesc));

        // System Tools Section
        public WindowsElement GamingSystemTools => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_system_tools']");
        public WindowsElement GamingSystemToolsTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='']");  //No autoid
        public WindowsElement SystemToolsSystemUpdate => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_dashboard_systemtools_systemupdates']");
        public WindowsElement SystemToolsPower => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_dashboard_systemtools_power']");
        public WindowsElement SystemToolsMedia => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_dashboard_systemtools_displaycamera']");
        public WindowsElement SystemToolsMacroKey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_dashboard_systemtools_macrokey']");
        public WindowsElement SystemToolsNahimics => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='systemtools_nahimic_icon']");
        public WindowsElement SystemToolsNahimicsName => base.FindElementByTimes(session, "XPath", "//*[@Name='nahimic']");
        public WindowsElement SystemToolsXrites => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='systemtools_x_rite_icon']");
        public WindowsElement SystemToolsXritesName => base.FindElementByTimes(session, "XPath", "//*[@Name='X-Rite Color Assistant']");

        public WindowsElement SystemToolsLegionAccessoryCentral => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='systemtools_legion_accessory_central_icon']");

        // Legion Edge Section
        //public WindowsElement GamingLegionEdge =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_legion_edge']");
        public WindowsElement GamingLegionEdge => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_legion_edge']");
        public WindowsElement LegionEdgeTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='']");  //No autoid
        public WindowsElement LegionEdgeHelpIcon => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_dashboard_help']");
        public WindowsElement LegionEdgeHelpName => base.FindElementByTimes(session, "XPath", "//*[@Name='legion edge help']");
        //public WindowsElement LegionEdgeNetworkBoostIcon => base.FindElementByTimes(session, "//*[@AutomationId='legion_edge_networkboost_gear']");
        public WindowsElement LegionEdgeNetworkBoostIcon => base.FindElementByTimes(session, "AutomationId", "legion_edge_networkboost_gear");
        public WindowsElement LegionEdgeNetworkBoostToggleOff => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming.dashboard.device.legionEdge.networkBoost_toggle_off']");
        //public WindowsElement LegionEdgeNetworkBoostToggleOff => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming.dashboard.device.legionEdge.networkBoost_toggle_off']");
        public WindowsElement LegionEdgeNetworkBoostToggleOn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming.dashboard.device.legionEdge.networkBoost_toggle_on']");
        //public WindowsElement LegionEdgeNetworkBoostToggleOn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming.dashboard.device.legionEdge.networkBoost_toggle_on']");
        public WindowsElement LegionEdgeNetworkBoostToggle => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, 'gaming.dashboard.device.legionEdge.networkBoost_toggle')]");
        public WindowsElement LegionEdgeAutoCloseIcon => base.FindElementByTimes(session, "AutomationId", "legion_edge_autoclose_gear"); //"legion_edge_autoclose_gear"
        public WindowsElement LegionEdgeAutoCloseToggleOn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming.dashboard.device.legionEdge.autoClose_toggle_on']");
        public WindowsElement LegionEdgeAutoCloseToggleOff => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming.dashboard.device.legionEdge.autoClose_toggle_off']");
        public WindowsElement LegionEdgeHybridModeToggleOn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming.dashboard.device.legionEdge.hybridMode_toggle_on']");
        public WindowsElement LegionEdgeHybridModeToggleOff => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming.dashboard.device.legionEdge.hybridMode_toggle_off']");
        public WindowsElement LegionEdgeTouchpadLockToggleOn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming.dashboard.device.legionEdge.touchpadLock_toggle_on']");
        public WindowsElement LegionEdgeTouchpadLockToggleOff => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming.dashboard.device.legionEdge.touchpadLock_toggle_off']");
        public List<WindowsElement> GamingLegionEdgeList => new List<WindowsElement>(session.FindElementsByXPath("//*[@AutomationId='gaming_legion_edge']//ListItem"));
        public WindowsElement LegionEdgeThermalModeOld => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming-drop thermal mode']");
        public WindowsElement LegionEdgeThermalModeNewPerformance => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, 'thermal_mode_performance')]");
        public WindowsElement LegionEdgeThermalModeNewBalance => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_balance']");
        public WindowsElement LegionEdgeThermalModeNewQuiet => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_quiet']");
        public WindowsElement LegionEdgeOverDriveToggleOff => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming.dashboard.device.legionEdge.overDrive_toggle_off']");
        public WindowsElement LegionEdgeOverDriveToggleOn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming.dashboard.device.legionEdge.overDrive_toggle_on']");
        public WindowsElement LegionEdgeRAMOverclockToggleOnName => base.FindElementByTimes(session, "XPath", "//*[@Name='legionedge ramoverlock on']");
        public WindowsElement LegionEdgeRAMOverclockToggleOn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming.dashboard.device.legionEdge.ramOverlock_toggle_on']");
        public WindowsElement LegionEdgeRAMOverclockToggleOff => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming.dashboard.device.legionEdge.ramOverlock_toggle_off']");
        public WindowsElement LegionEdgeRAMOverclockToggleOffName => base.FindElementByTimes(session, "XPath", "//*[@Name='legionedge ramoverlock off']");
        public WindowsElement LegionEdgeRAMOverclockToggle => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, 'gaming.dashboard.device.legionEdge.ramOverlock_toggle')]");
        public WindowsElement LegionEdgeCPUOverclock => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming-drop cpu overlock']");

        // Help page
        public WindowsElement HelpPageWindow => base.FindElementByTimes(session, "Name", "Legion Edge Help window");
        public WindowsElement HelpLegionEdgeImage => base.FindElementByTimes(session, "AutomationId", "help_popup_legion_edge");
        public WindowsElement HelpPageCloseName => base.FindElementByTimes(session, "Name", "close");
        public WindowsElement HelpPageCloseIcon => base.FindElementByTimes(session, "AutomationId", "legion_edge_help_close");
        public WindowsElement HelpPageDialog => base.FindElementByTimes(session, "AutomationId", "help_dialog");
        public WindowsElement HelpPageManagementName => base.FindElementByTimes(session, "Name", "Feature Management Overview");
        public WindowsElement HelpPageCPUGPUOverclockName => base.FindElementByTimes(session, "Name", "CPU/GPU Overclock");
        public WindowsElement HelpPageRAMOverclockName => base.FindElementByTimes(session, "Name", "RAM Overclock");
        public WindowsElement HelpPageNetworkBoostName => base.FindElementByTimes(session, "Name", "Network Boost");
        public WindowsElement HelpPageDolbyName => base.FindElementByTimes(session, "Name", "Dolby");
        public WindowsElement HelpPageHybridModeName => base.FindElementByTimes(session, "Name", "Hybrid Mode");
        public WindowsElement HelpPageRapidChargeName => base.FindElementByTimes(session, "Name", "Rapid Charge");
        public WindowsElement HelpPageTouchpadLockName => base.FindElementByTimes(session, "Name", "Touchpad Lock");
        public WindowsElement HelpPageAutoCloseName => base.FindElementByTimes(session, "Name", "Auto Close");
        public WindowsElement HelpPageThermalModeName => base.FindElementByTimes(session, "Name", "Thermal Mode");
        public WindowsElement HelpPageMacrokeyName => base.FindElementByTimes(session, "Name", "Macro key");
        public WindowsElement HelpPageOverDriveName => base.FindElementByTimes(session, "Name", "Over Drive");

        //Hybrid Mode
        public WindowsElement HybridModeToggle => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'gaming.dashboard.device.legionEdge.hybridMode_toggle')]");
        public WindowsElement HybridModeRestartWindowCloseButton => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='hybrid mode_restart_popup_close_btn']");
        public WindowsElement HybridModeRestartWindowOKButton => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='hybrid mode_restart_popup_ok_btn']");
        public WindowsElement HybridModeRestartWindow => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'hybrid mode_restart_popup')]");// "//*[@AutomationId='hybrid mode_restart_popup']");
        public WindowsElement HybridModeRestartWindowTip => base.FindElementByTimes(session, "XPath", "//*[@Name='Change will be effective after restarting computer.']");

        // Driver Lack
        public WindowsElement LightingDriverLackWindow => base.GetElement(session, "XPath", "//*[@AutomationId='gaming_lighting_driver_popup']");
        public WindowsElement LightingDriverLackWindowTitle => base.GetElement(session, "XPath", "//*[@Name='Driver Install Required']");
        public WindowsElement LightingDriverLackWindowInstallButton => base.GetElement(session, "XPath", "//*[@AutomationId='gaming_lighting_driver_popup_install_btn']");
        public WindowsElement LightingDriverLackWindowCancelButton => base.GetElement(session, "XPath", "//*[@AutomationId='gaming_lightingdriver_popup_cancel_btn']");
        public WindowsElement LightingDriverLackWindowCloseButton => base.GetElement(session, "XPath", "//*[@AutomationId='gaming_lighting_driver_popup_close_btn']");
        public WindowsElement NetFilterDriverLackWindow => base.GetElement(session, "XPath", "//*[@AutomationId='network boost_driver_popup']", 5);
        public WindowsElement NetFilterDriverLackWindowTitle => VantageCommonHelper.FindElementByXPath(session, "//*[@Name='Driver Install Required']", 5);
        public WindowsElement NetFilterDriverLackWindowInstallButton => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='network boost_driver_popup_install_btn']", 5);
        public WindowsElement NetFilterDriverLackWindowCancelButton => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='network boostdriver_popup_cancel_btn']", 5);
        public WindowsElement NetFilterDriverLackWindowCloseButton => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='network boost_driver_popup_close_btn']", 5);
        public WindowsElement CPUOverClockDriverLackWindow => base.GetElement(session, "XPath", "//*[@AutomationId='cpu overlock_driver_popup']");
        public WindowsElement CPUOverClockDriverLackWindowTitle => base.GetElement(session, "XPath", "//*[@Name='Driver Install Required']");
        public WindowsElement CPUOverClockDriverLackWindowInstallButton => base.GetElement(session, "XPath", "//*[@AutomationId='cpu overlock_driver_popup_install_btn']");
        public WindowsElement CPUOverClockDriverLackWindowCancelButton => base.GetElement(session, "XPath", "//*[@AutomationId='cpu overlockdriver_popup_cancel_btn']");
        public WindowsElement CPUOverClockDriverLackWindowCloseButton => base.GetElement(session, "XPath", "//*[@AutomationId='cpu overlock_driver_popup_close_btn']");
        public WindowsElement RAMOverClockDriverLackWindow => base.GetElement(session, "XPath", "//*[@AutomationId='ram overlock_driver_popup']");
        public WindowsElement RAMOverClockDriverLackWindowTitle => base.GetElement(session, "XPath", "//*[@Name='Driver Install Required']");
        public WindowsElement RAMOverClockDriverLackWindowInstallButton => base.GetElement(session, "XPath", "//*[@AutomationId='ram overlock_driver_popup_install_btn']");
        public WindowsElement RAMOverClockDriverLackWindowCancelButton => base.GetElement(session, "XPath", "//*[@AutomationId='ram overlockdriver_popup_cancel_btn']");
        public WindowsElement RAMOverClockDriverLackWindowCloseButton => base.GetElement(session, "XPath", "//*[@AutomationId='ram overlock_driver_popup_close_btn']");
        public WindowsElement XTUDriver => base.GetElement(session, "XPath", "//*[@Name='Intel(R) Extreme Tuning Utility SDK']");

        //System Update Subpage
        public WindowsElement SystemUpdateTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='system-update-title']");
        public WindowsElement SystemUpdateCheckButton => base.GetElement(session, "XPath", "//*[@AutomationId='su_check_updates']");

        // Quick Settings Section
        public WindowsElement GamingQuickSettings => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'gaming_quick_settings')]");
        public WindowsElement QuickSettingsRapidChargeToggleOn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming.dashboard.device.quickSettings.rapidCharge_toggle_on']");
        public WindowsElement QuickSettingsRapidChargeToggleOff => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming.dashboard.device.quickSettings.rapidCharge_toggle_off']");
        public WindowsElement QuickSettingsDolbyIcon => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='quicksettings_dolby_gear']");
        public WindowsElement QuickSettingsDolbyToggleOn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming.dashboard.device.quickSettings.dolby_toggle_on']");
        public WindowsElement QuickSettingsDolbyToggleOff => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming.dashboard.device.quickSettings.dolby_toggle_off']");
        public WindowsElement QuickSettingsThermalModeCombox => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming-drop thermal mode']");
        public WindowsElement QuickSettingsThermalModePerformance => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal mode performance']");
        public WindowsElement QuickSettingsThermalModeBalance => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal mode balance']");
        public WindowsElement QuickSettingsThermalModeQuiet => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal mode quiet']");
        public WindowsElement QuickSettingsWiFiSecurityIcon => base.FindElementByTimes(session, "AutomationId", "quicksettings_wifisecurity", 30, 15);
        public WindowsElement QuickSettingsWiFiSecurityToggleOn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming.dashboard.device.quickSettings.wifiSecurity_toggle_on']");
        public WindowsElement QuickSettingsWiFiSecurityToggleMode => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, 'gaming.dashboard.device.quickSettings.wifiSecurity_toggle_')]");
        public WindowsElement QuickSettingsWiFiSecurityToggleOff => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming.dashboard.device.quickSettings.wifiSecurity_toggle_off']");
        public List<WindowsElement> GamingQuickSettingsList => new List<WindowsElement>(session.FindElementsByXPath("//*[contains(@AutomationId,'gaming_quick_settings')]//ListItem"));
        public List<WindowsElement> GamingQuickSettingsToggleList => new List<WindowsElement>(session.FindElementsByXPath("//*[contains(@AutomationId,'gaming_quick_settings')]//ListItem//Button"));

        //Legion Accessory Central
        public WindowsElement AccessoryIconName => base.FindElementByTimes(session, "XPath", "//*[@Name='legion accessory central']");
        public WindowsElement AccessoryIcon => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='systemtools_legion_accessory_central_icon']");
        public WindowsElement AccessoryInstallPopup => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='legion_accessory_central_install_popup']");
        public WindowsElement AccessoryPopupCloseName => base.FindElementByTimes(session, "XPath", "//*[@Name='close']");
        public WindowsElement AccessoryPopupCloseIcon => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='legion_accessory_close_button']");
        public WindowsElement AccessoryPopupInstallName => base.FindElementByTimes(session, "XPath", "//*[@Name='INSTALL']");
        public WindowsElement AccessoryPopupInstallBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='legion_accessory_central_install_popup_install_button']");
        public WindowsElement AccessoryPopupCancelName => base.FindElementByTimes(session, "XPath", "//*[@Name='CANCEL']");
        public WindowsElement AccessoryPopupCancelBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='legion_accessory_central_install_popup_cancel_button']");
        //public WindowsElement AccessoryWebName =>  base.FindElementByTimes(session, "XPath", "//*[@Name='Legion Accessory Central for Windows 7, 10 (64-bit) - US']");
        public string AccessoryWebName = "Legion Accessory Central for Windows 7, 10 (64-bit) - ";

        //Old Thermal Mode
        public WindowsElement OldThermalModeContainer => base.FindElementByTimes(session, "XPath", "//*[contains(@Name, 'Thermal Mode thermal mode')]");
        public WindowsElement OTMBalanceContainer => base.FindElementByTimes(session, "XPath", "//*[@Name='Thermal Mode thermal mode balance']");
        public WindowsElement OTMPerfomanceContainer => base.FindElementByTimes(session, "XPath", "//*[@Name='Thermal Mode thermal mode performance']");
        public WindowsElement OTMQuietContainer => base.FindElementByTimes(session, "XPath", "//*[@Name='Thermal Mode thermal mode quiet']");
        public WindowsElement OTMBalanceText => base.FindElementByTimes(session, "XPath", "//*[@Name='thermal mode balance']");
        public WindowsElement OTMPerfomanceText => base.FindElementByTimes(session, "XPath", "//*[@Name='thermal mode performance']");
        public WindowsElement OTMQuietText => base.FindElementByTimes(session, "XPath", "//*[@Name='thermal mode quiet']");
        public WindowsElement OTMDropDownMenu => base.FindElementByTimes(session, "AutomationId", "gaming-drop thermal mode");
        public WindowsElement OTMDPBalanceText => base.FindElementByTimes(session, "XPath", "//*[@Name='Balance']");
        public WindowsElement OTMDPPerfomanceText => base.FindElementByTimes(session, "XPath", "//*[@Name='performance']");
        public WindowsElement OTMDPQuietText => base.FindElementByTimes(session, "XPath", "//*[@Name='Quiet']");
        public WindowsElement OTMDPBalanceMode => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal mode balance']");
        public WindowsElement OTMDPPerfomanceMode => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal mode performance']");
        public WindowsElement OTMDPQuietMode => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal mode quiet']");
        public WindowsElement TermalQuietMode => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_quiet']");
        public WindowsElement TermalPerformaceMode => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_performance']");

        //WiFi Security
        public WindowsElement WiFiSecurityTitle => base.FindElementByTimes(session, "XPath", "//*[@Name='Lenovo WiFi Security']", 30, 15);
        //public WindowsElement WiFiSecurityToggle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='sa-ws-switch_toggleMain']");
        public WindowsElement WiFiSecurityToggle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='sa-ws-switch-input']");
        public WindowsElement WiFiSecurityBackButton => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='sa-ws-btn-back']");
        public WindowsElement WiFiSecurityLocationDialog => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='wifi-sec-modal']");
        public WindowsElement WiFiSecurityLocationDialogTitle => base.FindElementByTimes(session, "XPath", "//*[@Name='Enable location services']");
        public WindowsElement WiFiSecurityLocationDialogCloseButton => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='sa-ws-btn-locationClose']");
        public WindowsElement WiFiSecurityLocationDialogAgreeButton => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='sa-ws-btn-locationAgree']");
        public WindowsElement WiFiSecurityLocationDialogCancelButton => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='sa-ws-btn-locationCancel']");
        public WindowsElement WiFiSecurityAdvisor => base.FindElementByTimes(session, "XPath", "//*[@Name='Security Advisor']");

        //Advanced Page
        public WindowsElement GPUOCArea => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_overclock_section']");
        public WindowsElement CPUOCArea => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='cpu_overclock_section']");
        public WindowsElement AdvancedOCTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='overclock_advanced_settings_header']");
        public WindowsElement AdvancedOCContent => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='overclock_advanced_settings_header_description']");
        public WindowsElement GPUOCAreaClockOffset => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_clock_offset_item']");
        public WindowsElement GPUOCAreaOffsetSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_clock_offset_slider']");
        public WindowsElement GPUOCAreaOffsetValueDefault30 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_clock_offsetlevel30']");
        public WindowsElement GPUOCAreaOffsetValue29 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_clock_offsetlevel29']");
        public WindowsElement GPUOCAreaOffsetValue10 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_clock_offsetlevel10']");
        public WindowsElement GPUOCAreaOffsetValue80 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_clock_offsetlevel80']");
        public WindowsElement GPUOCAreaOffsetValue120 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_clock_offsetlevel20']");
        public WindowsElement GPUOCAreaOffsetValueDefault100 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_clock_offsetlevel100']");
        public WindowsElement GPUOCAreaOffsetValue99 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_clock_offsetlevel99']");
        public WindowsElement GPUOCAreaOffsetValue101 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_clock_offsetlevel101']");
        public WindowsElement GPUOCAreaOffsetValueMinium => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_clock_offsetlevel0']");
        public WindowsElement GPUOCAreaOffsetValueminusMinium => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_clock_offsetlevel-200']");
        public WindowsElement GPUOCAreaOffsetValueMaximum300 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_clock_offsetlevel300']");
        public WindowsElement GPUOCAreaOffsetValueMaximum30 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_clock_offsetlevel30']");
        public WindowsElement GPUOCAreaOffsetValueMaximum150 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_clock_offsetlevel150']");
        public WindowsElement GPUOCAreaOffsetValueMaximum200 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_clock_offsetlevel200']");
        public WindowsElement GPUOCAreaOffsetPlus => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_clock_offset_plus_icon_clickable']");

        public WindowsElement GPUOCAreaOffsetMinusUnclickable => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_clock_offset_minus_icon_unclickable']");
        public WindowsElement GPUOCAreaOffsetPlusUnclickable => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_clock_offset_plus_icon_unclickable']");
        public WindowsElement GPUOCAreaOffsetMinus => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu_clock_offset_minus_icon_clickable']");
        public WindowsElement GPUOCAreaVRAMClockOffset => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='vram_clock_offset_item']");
        public WindowsElement GPUOCAreaVRAMOffsetSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='vram_clock_offset_slider']");
        public WindowsElement GPUOCAreaVRAMOffsetValueDefault => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='vram_clock_offsetlevel50']");
        public WindowsElement GPUOCAreaVRAMOffsetValueMinium => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='vram_clock_offsetlevel0']");
        public WindowsElement GPUOCAreaVRAMOffsetValueMaximum => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='vram_clock_offsetlevel100']");
        public WindowsElement GPUOCAreaVRAMOffsetPlus => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='vram_clock_offset_plus_icon_clickable']");
        public WindowsElement GPUOCAreaVRAMOffsetMinus => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='vram_clock_offset_minus_icon_clickable']");

        //CPU Overclock
        public WindowsElement ThermalMode => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, 'thermal_mode_')]");
        public WindowsElement ThermalModeBalance => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_balance']");
        public WindowsElement ThermalModeAdvancedBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='advanced_button']");
        public WindowsElement ThermalModeProceedBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_warning_dialog_proceed_button']");
        public WindowsElement AdvancedOCDialog => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='overclock_advanced_settings_popup']");
        public WindowsElement OverclockSetToDefault => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='overclock_advanced_settings_set_to_default_button']");
        public WindowsElement SaveChangeDialog => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='save_change_dialog']");
        public WindowsElement SaveChangeTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='save_change_dialog_header_text']");
        public WindowsElement VantageTitleBar => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='TitleBar']");
        public WindowsElement SaveChangeOCRecovery => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='save_change_dialog_oc_recovery_description']");
        public WindowsElement SaveChangePressingPowerButton => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='save_change_dialog_oc_recovery_pressing_power_button']");
        public WindowsElement SaveChangeOCRestoreDefault => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='save_change_dialog_oc_recovery_restoring_default_overclocking']");
        public WindowsElement SaveChangeDialogSaveBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='save_change_dialog_save_button']");
        public WindowsElement SaveChangeCloseBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='save_change_dialog_close_button']");
        public WindowsElement OverclockCloseBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='overclock_advanced_settings_close_button']");
        public WindowsElement SaveChangeDialogNotSaveBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='save_change_dialog_do_not_save_button']");
        public WindowsElement SetToDefaultTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='set_to_default_header_text']");
        public WindowsElement SetToDefaultDesc => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='set_to_default_description']");
        public WindowsElement SetToDefaultOkBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='set_to_default_ok_button']");
        public WindowsElement SetToDefaultCloseBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='set_to_default_close_button']");
        public WindowsElement SetToDefaultCancelBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='set_to_default_cancel_button']");
        public WindowsElement OverclockAdvanceSettingCPUTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='cpu_overclock_section_item']");
        public WindowsElement OneActiveCoreRatio => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='1_active_core_ratio_item']");
        public WindowsElement TwoActiveCoreRatio => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='2_active_core_ratio_item']");
        public WindowsElement ThreeActiveCoreRatio => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='3_active_core_ratio_item']");
        public WindowsElement FourActiveCoreRatio => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='4_active_core_ratio_item']");
        public WindowsElement FiveActiveCoreRatio => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='5_active_core_ratio_item']");
        public WindowsElement SixActiveCoreRatio => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='6_active_core_ratio_item']");
        public WindowsElement SevenActiveCoreRatio => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='7_active_core_ratio_item']");
        public WindowsElement EightActiveCoreRatio => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='8_active_core_ratio_item']");
        public WindowsElement OneCoreRatio => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='1_core_ratio_item']");
        public WindowsElement TwoCoreRatio => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='2_core_ratio_item']");
        public WindowsElement ThreeCoreRatio => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='3_core_ratio_item']");
        public WindowsElement FourCoreRatio => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='4_core_ratio_item']");
        public WindowsElement FiveCoreRatio => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='5_core_ratio_item']");
        public WindowsElement SixCoreRatio => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='6_core_ratio_item']");
        public WindowsElement SevenCoreRatio => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='7_core_ratio_item']");
        public WindowsElement EightCoreRatio => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='8_core_ratio_item']");
        public WindowsElement NineCoreRatio => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='9_core_ratio_item']");
        public WindowsElement TenCoreRatio => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='10_core_ratio_item']");
        public WindowsElement CoreVoltageOffset => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='core_voltage_offset_item']");
        public WindowsElement CoreVoltage => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='core_voltage_item']");
        public WindowsElement CoreICCMAX => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='core_iccmax_item']");
        public WindowsElement AvxRatioOffset => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='avx_ratio_offset_item']");
        public WindowsElement CacheRatio => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='cache_ratio_item']");
        public WindowsElement CacheVoltageOffset => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='cache_voltage_offset_item']");
        public WindowsElement CacheICCMAX => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='cache_iccmax_item']");
        public WindowsElement CacheVoltage => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='cache_voltage_item']");
        public WindowsElement OneActiveCoreRatioSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='1_active_core_ratio_slider']");
        public WindowsElement TwoActiveCoreRatioSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='2_active_core_ratio_slider']");
        public WindowsElement ThreeActiveCoreRatioSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='3_active_core_ratio_slider']");
        public WindowsElement FourActiveCoreRatioSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='4_active_core_ratio_slider']");
        public WindowsElement FiveActiveCoreRatioSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='5_active_core_ratio_slider']");
        public WindowsElement SixActiveCoreRatioSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='6_active_core_ratio_slider']");
        public WindowsElement SevenActiveCoreRatioSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='7_active_core_ratio_slider']");
        public WindowsElement EightActiveCoreRatioSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='8_active_core_ratio_slider']");
        public WindowsElement CoreVoltageOffsetSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='core_voltage_offset_slider']");
        public WindowsElement AVXRatioOffsetSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='avx_ratio_offset_slider']");
        public WindowsElement CacheRatioSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='cache_ratio_slider']");
        public WindowsElement CacheVoltageOffsetSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='cache_voltage_offset_slider']");
        public WindowsElement CoreICCMAXSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='core_iccmax_slider']");
        public WindowsElement OneCoreRatioSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='1_core_ratio_slider']");
        public WindowsElement TwoCoreRatioSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='2_core_ratio_slider']");
        public WindowsElement ThreeCoreRatioSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='3_core_ratio_slider']");
        public WindowsElement FourCoreRatioSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='4_core_ratio_slider']");
        public WindowsElement FiveCoreRatioSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='5_core_ratio_slider']");
        public WindowsElement SixCoreRatioSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='6_core_ratio_slider']");
        public WindowsElement SevenCoreRatioSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='7_core_ratio_slider']");
        public WindowsElement EightCoreRatioSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='8_core_ratio_slider']");
        public WindowsElement NineCoreRatioSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='9_core_ratio_slider']");
        public WindowsElement TenCoreRatioSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='10_core_ratio_slider']");
        public WindowsElement OneActiveCoreRatioMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'1_active_core_ratio_minus_icon')]");
        public WindowsElement OneActiveCoreRatioMinusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='1_active_core_ratio_minus_icon_unclickable']");
        public WindowsElement TwoActiveCoreRatioMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'2_active_core_ratio_minus_icon')]");
        public WindowsElement TwoActiveCoreRatioMinusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='2_active_core_ratio_minus_icon_unclickable']");
        public WindowsElement ThreeActiveCoreRatioMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'3_active_core_ratio_minus_icon')]");
        public WindowsElement ThreeActiveCoreRatioMinusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='3_active_core_ratio_minus_icon_unclickable']");
        public WindowsElement FourActiveCoreRatioMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'4_active_core_ratio_minus_icon')]");
        public WindowsElement FourActiveCoreRatioMinusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='4_active_core_ratio_minus_icon_unclickable']");
        public WindowsElement FiveActiveCoreRatioMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'5_active_core_ratio_minus_icon')]");
        public WindowsElement FiveActiveCoreRatioMinusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='5_active_core_ratio_minus_icon_unclickable']");
        public WindowsElement SixActiveCoreRatioMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'6_active_core_ratio_minus_icon')]");
        public WindowsElement SixActiveCoreRatioMinusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='6_active_core_ratio_minus_icon_unclickable']");
        public WindowsElement SevenActiveCoreRatioMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'7_active_core_ratio_minus_icon')]");
        public WindowsElement SevenActiveCoreRatioMinusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='7_active_core_ratio_minus_icon_unclickable']");
        public WindowsElement EightActiveCoreRatioMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'8_active_core_ratio_minus_icon')]");
        public WindowsElement EightActiveCoreRatioMinusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='8_active_core_ratio_minus_icon_unclickable']");
        public WindowsElement OneCoreRatioMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'1_core_ratio_minus_icon')]");
        //public WindowsElement OneCoreRatioMinusIconGrey =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='1_core_ratio_minus_icon_unclickable']");
        public WindowsElement TwoCoreRatioMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'2_core_ratio_minus_icon')]");
        //public WindowsElement TwoCoreRatioMinusIconGrey =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='2_core_ratio_minus_icon_unclickable']");
        public WindowsElement ThreeCoreRatioMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'3_core_ratio_minus_icon')]");
        //public WindowsElement ThreeCoreRatioMinusIconGrey =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='3_core_ratio_minus_icon_unclickable']");
        public WindowsElement FourCoreRatioMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'4_core_ratio_minus_icon')]");
        //public WindowsElement FourCoreRatioMinusIconGrey =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='4_core_ratio_minus_icon_unclickable']");
        public WindowsElement FiveCoreRatioMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'5_core_ratio_minus_icon')]");
        //public WindowsElement FiveCoreRatioMinusIconGrey =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='5_core_ratio_minus_icon_unclickable']");
        public WindowsElement SixCoreRatioMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'6_core_ratio_minus_icon')]");
        //public WindowsElement SixCoreRatioMinusIconGrey =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='6_core_ratio_minus_icon_unclickable']");
        public WindowsElement SevenCoreRatioMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'7_core_ratio_minus_icon')]");
        //public WindowsElement SevenCoreRatioMinusIconGrey =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='7_core_ratio_minus_icon_unclickable']");
        public WindowsElement EightCoreRatioMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'8_core_ratio_minus_icon')]");
        //public WindowsElement EightCoreRatioMinusIconGrey =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='8_core_ratio_minus_icon_unclickable']");
        public WindowsElement NineCoreRatioMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'9_core_ratio_minus_icon')]");
        //public WindowsElement NineCoreRatioMinusIconGrey =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='9_core_ratio_minus_icon_unclickable']");
        public WindowsElement TenCoreRatioMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'10_core_ratio_minus_icon')]");
        //public WindowsElement TenCoreRatioMinusIconGrey =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='10_core_ratio_minus_icon_unclickable']");
        public WindowsElement OneActiveCoreRatioPlusIcon => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='1_active_core_ratio_plus_icon_clickable']");
        public WindowsElement OneActiveCoreRatioPlusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='1_active_core_ratio_plus_icon_unclickable']");
        public WindowsElement TwoActiveCoreRatioPlusIcon => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='2_active_core_ratio_plus_icon_clickable']");
        public WindowsElement TwoActiveCoreRatioPlusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='2_active_core_ratio_plus_icon_unclickable']");
        public WindowsElement ThreeActiveCoreRatioPlusIcon => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='3_active_core_ratio_plus_icon_clickable']");
        public WindowsElement ThreeActiveCoreRatioPlusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='3_active_core_ratio_plus_icon_unclickable']");
        public WindowsElement FourActiveCoreRatioPlusIcon => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='4_active_core_ratio_plus_icon_clickable']");
        public WindowsElement FourActiveCoreRatioPlusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='4_active_core_ratio_plus_icon_unclickable']");
        public WindowsElement FiveActiveCoreRatioPlusIcon => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='5_active_core_ratio_plus_icon_clickable']");
        public WindowsElement FiveActiveCoreRatioPlusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='5_active_core_ratio_plus_icon_unclickable']");
        public WindowsElement SixActiveCoreRatioPlusIcon => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='6_active_core_ratio_plus_icon_clickable']");
        public WindowsElement SixActiveCoreRatioPlusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='6_active_core_ratio_plus_icon_unclickable']");
        public WindowsElement SevenActiveCoreRatioPlusIcon => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='7_active_core_ratio_plus_icon_clickable']");
        public WindowsElement SevenActiveCoreRatioPlusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='7_active_core_ratio_plus_icon_unclickable']");
        public WindowsElement EightActiveCoreRatioPlusIcon => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='8_active_core_ratio_plus_icon_clickable']");
        public WindowsElement EightActiveCoreRatioPlusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='8_active_core_ratio_plus_icon_unclickable']");
        public WindowsElement OneCoreRatioPlusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'1_core_ratio_plus_icon')]");
        //public WindowsElement OneCoreRatioPlusIconGrey =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='1_core_ratio_plus_icon_unclickable']");
        public WindowsElement TwoCoreRatioPlusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'2_core_ratio_plus_icon')]");
        //public WindowsElement TwoCoreRatioPlusIconGrey =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='2_core_ratio_plus_icon_unclickable']");
        public WindowsElement ThreeCoreRatioPlusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'3_core_ratio_plus_icon')]");
        //public WindowsElement ThreeCoreRatioPlusIconGrey =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='3_core_ratio_plus_icon_unclickable']");
        public WindowsElement FourCoreRatioPlusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'4_core_ratio_plus_icon')]");
        //public WindowsElement FourCoreRatioPlusIconGrey =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='4_core_ratio_plus_icon_unclickable']");
        public WindowsElement FiveCoreRatioPlusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'5_core_ratio_plus_icon')]");
        //public WindowsElement FiveCoreRatioPlusIconGrey =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='5_core_ratio_plus_icon_unclickable']");
        public WindowsElement SixCoreRatioPlusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'6_core_ratio_plus_icon')]");
        //public WindowsElement SixCoreRatioPlusIconGrey =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='6_core_ratio_plus_icon_unclickable']");
        public WindowsElement SevenCoreRatioPlusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'7_core_ratio_plus_icon')]");
        //public WindowsElement SevenCoreRatioPlusIconGrey =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='7_core_ratio_plus_icon_unclickable']");
        public WindowsElement EightCoreRatioPlusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'8_core_ratio_plus_icon')]");
        //public WindowsElement EightCoreRatioPlusIconGrey =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='8_core_ratio_plus_icon_unclickable']");
        public WindowsElement NineCoreRatioPlusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'9_core_ratio_plus_icon')]");
        //public WindowsElement NineCoreRatioPlusIconGrey =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='9_core_ratio_plus_icon_unclickable']");
        public WindowsElement TenCoreRatioPlusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'10_core_ratio_plus_icon')]");
        //public WindowsElement TenCoreRatioPlusIconGrey =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='10_core_ratio_plus_icon_unclickable']");
        public WindowsElement OneActiveCoreRatioLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, '1_active_core_ratiolevel')]");
        public WindowsElement TwoActiveCoreRatioLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, '2_active_core_ratiolevel')]");
        public WindowsElement ThreeActiveCoreRatioLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, '3_active_core_ratiolevel')]");
        public WindowsElement FourActiveCoreRatioLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, '4_active_core_ratiolevel')]");
        public WindowsElement FiveActiveCoreRatioLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, '5_active_core_ratiolevel')]");
        public WindowsElement SixActiveCoreRatioLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, '6_active_core_ratiolevel')]");
        public WindowsElement SevenActiveCoreRatioLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, '7_active_core_ratiolevel')]");
        public WindowsElement EightActiveCoreRatioLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, '8_active_core_ratiolevel')]");
        public WindowsElement OneCoreRatioLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, '1_core_ratiolevel')]");
        public WindowsElement TwoCoreRatioLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, '2_core_ratiolevel')]");
        public WindowsElement ThreeCoreRatioLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, '3_core_ratiolevel')]");
        public WindowsElement FourCoreRatioLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, '4_core_ratiolevel')]");
        public WindowsElement FiveCoreRatioLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, '5_core_ratiolevel')]");
        public WindowsElement SixCoreRatioLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, '6_core_ratiolevel')]");
        public WindowsElement SevenCoreRatioLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, '7_core_ratiolevel')]");
        public WindowsElement EightCoreRatioLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, '8_core_ratiolevel')]");
        public WindowsElement NineCoreRatioLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, '9_core_ratiolevel')]");
        public WindowsElement TenCoreRatioLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, '10_core_ratiolevel')]");
        public WindowsElement CoreVoltageLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, 'core_voltagelevel')]");
        public WindowsElement CoreVoltageOffsetLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, 'core_voltage_offsetlevel')]");
        public WindowsElement CacheVoltageLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, 'cache_voltagelevel')]");
        public WindowsElement CacheVoltageOffsetLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, 'cache_voltage_offsetlevel')]");
        public WindowsElement AVXRatioOffsetLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, 'avx_ratio_offsetlevel')]");
        public WindowsElement CacheRatioLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, 'cache_ratiolevel')]");
        public WindowsElement CoreICCMAXLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'core_iccmaxlevel')]");
        public WindowsElement CacheICCMAXLevelDefault => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'cache_iccmaxlevel')]");
        public WindowsElement CoreVoltageSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='core_voltage_slider']");
        public WindowsElement CoreVoltageMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'core_voltage_minus_icon')]");
        public WindowsElement CoreVoltagePlusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'core_voltage_plus_icon')]");
        public WindowsElement CoreICCMAXMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'core_iccmax_minus_icon')]");
        public WindowsElement CoreICCMAXPlusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'core_iccmax_plus_icon')]");
        public WindowsElement CacheICCMAXSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='cache_iccmax_slider']");
        public WindowsElement CacheICCMAXMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'cache_iccmax_minus_icon')]");
        public WindowsElement CacheICCMAXPlusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'cache_iccmax_plus_icon')]");
        public WindowsElement CacheVoltageSlider => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='cache_voltage_slider']");
        public WindowsElement CacheVoltageMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'cache_voltage_minus_icon')]");
        public WindowsElement CacheVoltagePlusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'cache_voltage_plus_icon')]");
        public WindowsElement AVXRatioOffsetSliser => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='avx_ratio_offset_slider']");
        public WindowsElement AVXRatioOffsetMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'avx_ratio_offset_minus_icon')]");
        public WindowsElement AVXRatioOffsetPlusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'avx_ratio_offset_plus_icon')]");
        public WindowsElement CacheRatioMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'cache_ratio_minus_icon')]");
        public WindowsElement CacheRatioPlusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'cache_ratio_plus_icon')]");
        public WindowsElement CacheVoltageOffsetMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'cache_voltage_offset_minus_icon')]");
        public WindowsElement CacheVoltageOffsetPlusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'cache_voltage_offset_plus_icon')]");
        public WindowsElement CoreVoltageOffsetSliser => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='core_voltage_offset_slider']");
        public WindowsElement CoreVoltageOffsetMinusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'core_voltage_offset_minus_icon')]");
        public WindowsElement CoreVoltageOffsetPlusIcon => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'core_voltage_offset_plus_icon')]");
        public WindowsElement CoreVoltageOffsetPlusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='core_voltage_offset_plus_icon_unclickable']");
        public WindowsElement AVXRatioOffsetPlusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='avx_ratio_offset_plus_icon_unclickable']");
        public WindowsElement CacheRatioPlusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='cache_ratio_plus_icon_unclickable']");
        public WindowsElement CacheVoltageOffsetPlusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='cache_voltage_offset_plus_icon_unclickable']");
        public WindowsElement CoreVoltageOffsetMinusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='core_voltage_offset_minus_icon_unclickable']");
        public WindowsElement AVXRatioOffsetMinusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='avx_ratio_offset_minus_icon_unclickable']");
        public WindowsElement CacheRatioMinusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='cache_ratio_minus_icon_unclickable']");
        public WindowsElement CacheVoltageOffsetMinusIconGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='cache_voltage_offset_minus_icon_unclickable']");

        //Lighting
        public WindowsElement GamingLightingImage => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_lighting_desktop_Image']");
        public WindowsElement LightingSelectProfileOff => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='off_radio']");
        public WindowsElement LightingSelectProfileOne => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='first_radio']");
        public WindowsElement LightingSelectProfileTwo => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='second_radio']");
        public WindowsElement LightingSelectProfileThree => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='third_radio']");
        public WindowsElement LightingCustomize => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='lighting_customize']");
        public WindowsElement LightingCustomizeIcon => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_dashboard_lighting_customize_gear']");
        public WindowsElement GamingLightingSubpageHeaderTitle => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='lightingcustomize-header-title']", 5);
        public WindowsElement GamingLightingSubpageProfileOff => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='profile_off_radio']");
        public WindowsElement GamingLightingSubpageProfileOne => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='profile_first_radio']");
        public WindowsElement GamingLightingSubpageProfileTwo => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='profile_second_radio']");
        public WindowsElement GamingLightingSubpageProfileThree => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='profile_third_radio']");
        public WindowsElement GamingLightingSubpageBrightnessSlider => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, 'gaming_lighting_brightness_slider')]");

        //Network boost
        //public WindowsElement NetworkBoostBackLink =>  base.FindElementByTimes(session, "XPath", "//*[@AutomationId='vtr-gaming-networkboost-btn-back']");
        public WindowsElement NetworkBoostBackLink => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='vtr-gaming-networkboost-btn-back']");

        public WindowsElement LegionEdgeNetworkBoostSubpageToggleOff => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='networkboostSwitch_toggle_off']");
        public WindowsElement LegionEdgeNetworkBoostSubpageToggleOn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='networkboostSwitch_toggle_on']");
        public WindowsElement LegionEdgeNetworkBoostSubpageToggleState => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'networkboostSwitch_toggle')]");
        public WindowsElement LegionEdgeNetworkBoostSubpageTitle => base.FindElementByTimes(session, "AutomationId", "networkboost-header-title");
        public WindowsElement LegionEdgeNetworkBoostSubpageBack => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='vtr-gaming-networkboost-btn-back']");
        public WindowsElement LegionEdgeNetworkBoostSubpageAddBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='networkboost_addButton_clickable']");
        public WindowsElement LegionEdgeNetworkBoostSubpageDialog => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='nbTurnOnModal']");
        public WindowsElement LegionEdgeNetworkBoostSubpageDialogCloseBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='nbTurnOnModal_closeButton']");
        public WindowsElement LegionEdgeNetworkBoostSubpageDialogCheckbox => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='networkboost_turnon_dialog_checkbox_Dont_ask_again']");
        public WindowsElement LegionEdgeNetworkBoostSubpageDialogTurnonBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='nbTurnOnModal_turnon_button']");
        public WindowsElement LegionEdgeNetworkBoostSubpageDialogNotNowBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='nbTurnOnModal_notnow']");
        public WindowsElement LegionEdgeNetworkBoostSubpageCloseAddBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='nbAddApps_close_btn']");
        public WindowsElement LegionEdgeNetworkBoostSubpageAddAppsCloseBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='nbAddApps_close_btn']");
        public WindowsElement LegionEdgeNetworkBoostNoAppRunning => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='nbAddApps_norunningapps']");
        public WindowsElement LegionEdgeNetworkBoostAddApp0 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_nb_addapp0']");
        public WindowsElement LegionEdgeNetworkBoostAddApp5 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_nb_addapp5']");
        public WindowsElement NetworkBoostAddAppNoRunningClose => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='nbAddApps_norunningapps_close_btn']");
        public WindowsElement NetworkBoostAddRemove0 => NetworkBoostAppList[2];//base.FindElementByTimes(session, "XPath", "//*[@AutomationId='nb_remove0']");
        public WindowsElement machineFamilyNameText => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='menu-main-text-machineFamilyName']");
        public WindowsElement NetworkBoostPopupWindowDescription => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='network_boost_add_apps_popup_description']");
        public List<WindowsElement> NetworkBoostRunningEdgeList => base.FindElementsByTimes(session, "XPath", "//*[@AutomationId='gaming_networkboost_running_applist']//CheckBox");//base.FindElementsByTimes(session, "XPath", "//*[@AutomationId='gaming_networkboost_running_applist']/child::*/*");
        public List<WindowsElement> NetworkBoostAppList => base.FindElementsByTimes(session, "XPath", "//*[@AutomationId='gaming_networkboost_added_applist']//Button"); //需要移除前两个结果，即为已经添加的App List //base.FindElementsByTimes(session, "XPath", "//*[@AutomationId='gaming_networkboost_added_applist']/child::*/*");
        //public string NetworkBoostPopWindowAddBtn = "gaming_nb_addapp";

        //Auto Close Page
        public WindowsElement AutoCloseTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='autoclose-header-title']");
        public WindowsElement AutoCloseBackLink => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='vtr-gaming-autoclose-btn-back']");
        public WindowsElement AutoCloseToggleOn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='autocloseSwitch_toggle_on']");
        public WindowsElement AutoCloseToggleOff => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='autocloseSwitch_toggle_off']");
        public WindowsElement AutoCloseDescription => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_autoclose_description']");
        public WindowsElement AutoCloseAddBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='addAutoCloseAppBtn']");
        public WindowsElement AutoClosePopupWindow => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='autoclose_turnon_dialog']");
        public WindowsElement AutoClosePopupWindowTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='']");   //预留
        public WindowsElement AutoClosePopupWindowDescription => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='']"); //预留
        public WindowsElement AutoClosePopupWindowCloseBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='autoclose_turnon_dialog_close']");
        public WindowsElement AutoClosePopupWindowCheckbox => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='autoclose_turnon_dialog_checkbox_Dont_ask_again']");
        public WindowsElement AutoClosePopupWindowTurnOnBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='autoclose_turnon_dialog_turnon']");
        public WindowsElement AutoClosePopupWindowNotNowBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='autoclose_turnon_dialog_notnow']");
        public WindowsElement AutoCloseAddappWindows => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_autoclose_addapps']");
        public WindowsElement AutoCloseAddappWindowsCloseBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_autoclose_addapps_close']");
        public List<WindowsElement> AutoCloseAddappList => new List<WindowsElement>(session.FindElementsByXPath("//*[@AutomationId='gaming_autoclose_addapps']//CheckBox"));
        public List<WindowsElement> AutoCloseAddedAppList => new List<WindowsElement>(session.FindElementsByXPath("//*[@AutomationId='gaming_autoclose_added_applist']//Button")); //需要移除前两个结果，即为已经添加的App List
        public WindowsElement SystemToolsHWScan => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_dashboard_systemtools_hardware_scan']");
        public WindowsElement AutoCloseNoRuningAppsWindow => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_autoclose_norunningapps']");
        public WindowsElement AutoCloseNoRuningAppsWindowCloseBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_autoclose_norunningapps_close']");

        //Macro Key Page
        public WindowsElement MacroKeyTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming-macrokey-header-title']");
        public WindowsElement MacroKeyBackLink => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='vtr-gaming-macrokey-btn-back']");
        public WindowsElement MacroKeyNumPadM1 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_numpad-M1']");
        public WindowsElement MacroKeyNumPadM2 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_numpad-M2']");
        public WindowsElement MacroKeyNumPad0 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_numpad-0']");
        public WindowsElement MacroKeyNumPad1 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_numpad-1']");
        public WindowsElement MacroKeyNumPad2 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_numpad-2']");
        public WindowsElement MacroKeyNumPad3 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_numpad-3']");
        public WindowsElement MacroKeyNumPad4 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_numpad-4']");
        public WindowsElement MacroKeyNumPad5 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_numpad-5']");
        public WindowsElement MacroKeyNumPad6 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_numpad-6']");
        public WindowsElement MacroKeyNumPad7 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_numpad-7']");
        public WindowsElement MacroKeyNumPad8 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_numpad-8']");
        public WindowsElement MacroKeyNumPad9 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_numpad-9']");
        public WindowsElement MacroKeyStartRecording => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_macrokey_startrecording']");
        public WindowsElement MacroKeyStopRecording => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_macrokey_stoprecording']");
        public WindowsElement MacroKeyClearRecords => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_clear_records']");
        public WindowsElement MacrokeyClearRecordsDialogClearBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_clear_records_dialog_clear_btn']");
        public WindowsElement MacroKeySettingsDropMenu => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_macrokey_settings_drop_menu']");
        public WindowsElement MacroKeySettingsOn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macro key settings on']");
        public WindowsElement MacroKeySettingsEnabledWhenGaming => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macro key settings enabled when gaming']");
        public WindowsElement MacroKeySettingsOff => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macro key settings off']");
        public WindowsElement CreateAMacroKeyFor => base.FindElementByTimes(session, "XPath", "//*[@Name='CREATE A MACRO KEY FOR']");
        public WindowsElement MacroKeyFor => base.FindElementByTimes(session, "XPath", "//*[@Name='MACRO KEY FOR']");
        public WindowsElement Num => base.FindElementByTimes(session, "XPath", "//*[@Name='NUM']");
        public WindowsElement Number3 => base.FindElementByTimes(session, "XPath", "//*[@Name='3']");
        public WindowsElement M2 => base.FindElementByTimes(session, "XPath", "//*[@Name='M2']");
        public WindowsElement Key0 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_delete_key0']");
        public WindowsElement Key4 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_delete_key4']");
        public WindowsElement Key5 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_delete_key5']");
        public WindowsElement MacroKeySettingsRepeatDrop => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_macro_key_ settings_repeat drop']");
        public WindowsElement MacroKeySettingsRepeat2 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macro_key_settings_repeat2']");
        public WindowsElement MacroKeySettingsRepeat3 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macro_key_settings_repeat3']");
        public WindowsElement MacroKeySettingsDelayDrop => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_macro_key_settings_delay drop']");
        public WindowsElement MacroKeySettingsKeepDelay => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macro_key_settings_keepdelay']");
        public WindowsElement MacroKeySettingsIgnoreDelay => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macro_key_settings_ignoredelay']");
        public WindowsElement MacroKeyClearRecordsDialog => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_clear_records_dialog']");
        public WindowsElement MacroKeyClearRecordsDialogCloseButton => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_clear_records_dialog_close_button']");
        public WindowsElement MacroKeyClearRecordsDialogCancelButton => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_popup_cancel']");
        public WindowsElement MacroKeyStartTypingText => base.FindElementByTimes(session, "XPath", "//*[@Name='START TYPING']");
        public WindowsElement MacroKey20InputsWithin20Seconds => base.FindElementByTimes(session, "XPath", "//*[@Name='20 inputs within 20 seconds can be recorded.']");
        public WindowsElement Macrokey10sTimeoutDialog => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_10s_timeout_dialog']");
        public WindowsElement Macrokey20sTimeoutDialog => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_20s_timeout_dialog']");
        public WindowsElement MacrokeyMaximumInputDialog => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_maximum_input_dialog']");
        public WindowsElement Macrokey10sTimeoutTitle => base.FindElementByTimes(session, "XPath", "//*[@Name='Time Out For Recording.']");
        public WindowsElement Macrokey20sTimeoutTitle => base.FindElementByTimes(session, "XPath", "//*[@Name='Time Out For Recording.']");
        public WindowsElement MacrokeyMaximumInputTitle => base.FindElementByTimes(session, "XPath", "//*[@Name='Maximum Input Reached.']");
        public WindowsElement Macrokey10sTimeoutDialogobBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_10s_timeout_dialogob_btn']");
        public WindowsElement Macrokey20sTimeoutDialogobBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_20s_timeout_dialogob_btn']");
        public WindowsElement MacrokeyMaximumInputDialogobBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_maximum_input_dialogob_btn']");
        public WindowsElement Macrokey10sTimeoutDialogCloseBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_10s_timeout_dialog_close_button']");
        public WindowsElement Macrokey20sTimeoutDialogCloseBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_20s_timeout_dialog_close_button']");
        public WindowsElement MacrokeyMaximumInputDialogCloseBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='macrokey_maximum_input_dialog_close_button']");

        //Search
        public WindowsElement SearchIcon => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='menu-main-nav-lnk-dropdown-toggle-app-search']", 30, 30);
        public WindowsElement SearchInput => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='search-page-search-widget-input']");
        public WindowsElement SearchButton => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='search-page-search-widget-button']");
        public List<WindowsElement> SearchPageResultItemRows => new List<WindowsElement>(base.FindElementsByTimes(session, "XPath", "//*[contains(@AutomationId, 'search-page-result-item-row')]"));
        public WindowsElement WaitText => base.FindElementByTimes(session, "XPath", "//*[@Name='Please wait while we check your device for available settings']", 30, 30);

        // HareWare Scan
        public WindowsElement HwScanTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='hwscan-header-title']");

        //My Device Settings Power subpage
        public WindowsElement PowerTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-settings-power-title']");
        public WindowsElement PowerRapidChargeTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='ds-power-battery-expressCharging-title']");
        public WindowsElement PowerRapidChargeCheckbox => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='ds-power-battery-expressCharging_checkbox']");

        //My Device Settings Audio subpage
        public WindowsElement DoblyCheckbox => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='audio-automatic-dolby_checkbox']");
        public WindowsElement DoblyAudioPageTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='ds-audio-title']");
        public WindowsElement DoblyAudioText => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='audio-automatic-dolby-title']");

        //Gaming Store Section
        public WindowsElement GamingStore => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='lenovo game store']");

        //HardWare Setting
        //Power
        public WindowsElement PowerBackLink => base.FindElementByTimes(session, "XPath", "//*[@Name='< BACK']");

        //My Device Settings Power subpage
        public WindowsElement MyDeviceSettingTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-settings-header-title']");
        public WindowsElement PowerLabelTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-settings-header-menu-power']");
        public WindowsElement PowerLevel2Tiltle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-settings-power-title']");
        public WindowsElement PowerJumptToSettingsTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-settings-power-jumptToSettings-title']");
        //QA section
        public WindowsElement QA1Content => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='device-settings-qa-1']");
        public WindowsElement QA2Content => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='support-detail-qa-2']");
        public WindowsElement QA3Content => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='support-detail-qa-3']");
        public WindowsElement QA4Content => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='support-detail-qa-4']");
        public WindowsElement QA5Content => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='support-detail-qa-5']");

        //Support 
        public WindowsElement SupportNVLink => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='menu-main-nav-lnk-dropdown-toggle-support']");
        public WindowsElement SupportDPLink => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='menu-main-nav-lnk-dropdown-menu-support-0']");
        public WindowsElement SupportTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='support-header-title']");
        //Give Feedback
        public WindowsElement GiveFeedbackTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='support-give-feedback-title']");
        public WindowsElement GiveFeedbackDescription => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='support-give-feedback-description']");
        public WindowsElement GiveFeedbackButton => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dashboard-btn-feedback']");

        //Navigation Bar
        public WindowsElement SupportButton => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='menu-main-nav-lnk-dropdown-toggle-support']");
        public WindowsElement LIDIcon => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='navbarDropdown']");

        //Legion edge
        public WindowsElement menuDevice => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='menu-main-nav-lnk-device']");
        public WindowsElement GamingsystemstatusInfo => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming systemstatus info']");

        //New Thermal Mode
        public WindowsElement ThermalModebalance => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_balance']");
        public WindowsElement ThermalModebalanceName => base.FindElementByTimes(session, "XPath", "//*[@Name='Thermal Mode Balance']");
        public WindowsElement ThermalModeSetting => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_setting_popup']");
        public WindowsElement ThermalSettingAdvanced => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='advanced_button']");
        public WindowsElement ThermalSettingAdvancedName => base.FindElementByTimes(session, "XPath", "//*[@Name='ADVANCED']");
        public WindowsElement EnableOcCheckboxUnchecked => base.FindElementByTimes(session, "XPath", "//*[contains(@AutomationId, 'enable_OC_checkbox')]");
        public WindowsElement EnableOcCheckboxUncheckedName => base.FindElementByTimes(session, "XPath", "//*[@Name='Enable GPU Overclocking in Performance Mode']");
        public WindowsElement ThermalModeSettingPopupClose => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_setting_popup_close']");
        public WindowsElement ThermalModeSettingPopupCloseName => base.FindElementByTimes(session, "XPath", "//*[@Name='close']");
        public WindowsElement ThermalAdvancedWarningPage => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_warning_dialog']");
        public WindowsElement ThermalAdvancedWarningCancel => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_warning_dialog_cancel_button']");
        public WindowsElement ThermalAdvancedWarningCancelName => base.FindElementByTimes(session, "XPath", "//*[@Name='CANCEL']");
        public WindowsElement warningdialogwarningtext => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='warning_dialog_warning_text']");
        public WindowsElement ThermalAdvancedwarningproceedBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_warning_dialog_proceed_button']");
        public WindowsElement ThermalAdvancedwarningproceedBtnName => base.FindElementByTimes(session, "XPath", "//*[@Name='PROCEED']");
        public WindowsElement ThermalAdvancedDwarningcloseBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_warning_dialog_close_button']");
        public WindowsElement ThermalAdvancedwarningcloseBtnName => base.FindElementByTimes(session, "XPath", "//*[@Name='close']");
        public WindowsElement WarningDialogwarningdescription => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='warning_dialog_warning_description']");
        public WindowsElement OverclockAdvancedSettingsClosebutton => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='overclock_advanced_settings_close_button']");
        public WindowsElement OverclockAdvancedSettingsClosebuttonName => base.FindElementByTimes(session, "XPath", "//*[@Name='close']");
        public WindowsElement OverclockAdvancedsettingssettodefaultbutton => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='overclock_advanced_settings_set_to_default_button']");
        public WindowsElement OverclockAdvancedsettingssettodefaultbuttonName => base.FindElementByTimes(session, "XPath", "//*[@Name='set to default']");

        /// <summary>
        /// </summary>
        public static string GamingLegionEdgeListChild = "//*[@AutomationId='gaming_legion_edge']/child::*/*";
        public string NetworkBoostPopWindowRemoveBtn = "nb_remove";

        //public //RAM Overclock legionedge ramoverlock
        //RAM Overclock

        public WindowsElement RAMOverclockElement => base.FindElementByTimes(session, "XPath", "//*[contains(@Name, 'RAM Overclock legionedge ramoverlock')]");
        public WindowsElement RamOverlocRestartPopup => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='ram overloc_restart_popup']");
        public WindowsElement RamOverlocRestartPopupokBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='ram overlock_restart_popup_ok_btn']");
        public WindowsElement RamOverlocRestartPopupokBtnName => base.FindElementByTimes(session, "XPath", "//*[@Name='gaming popup ok']");
        public WindowsElement RamOverlocRestartPopupcloseBtn => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='ram overlock_restart_popup_close_btn']");
        public WindowsElement RamOverlocRestartPopupcloseBtnName => base.FindElementByTimes(session, "XPath", "//*[@Name='close']");
        public object LegionEdgeOverDriveToggleOffName => base.FindElementByTimes(session, "XPath", "//*[@Name='legionedge overDrive off']");
        public object LegionEdgeOverDriveToggleOnName => base.FindElementByTimes(session, "XPath", "//*[@Name='legionedge overDrive on']");

        //Hardware
        public WindowsElement myDeviceheadertitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-header-title']");
        public WindowsElement MyDevice => base.FindElementByTimes(session, "XPath", "//*[@Name='My Device']");
        public WindowsElement MyDeviceSerialNumber => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-sn']");
        public WindowsElement MyDeviceProductNumber => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-productNo']");
        public WindowsElement MyDeviceBiosVersion => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-bios']");
        public WindowsElement MyDeviceMaintenanceNeeded => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='device-overall-status-button']");
        public WindowsElement myDevicesystemdetailsprocessor => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-system-details-processor']");
        public WindowsElement myDevicesystemdetailsmemory => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-system-details-memory']");
        public WindowsElement myDevicesystemdetailsdisk => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-system-details-disk']");
        public WindowsElement myDevicesystemdetailssystemupdate => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-system-details-systemupdate']");
        public WindowsElement myDevicesystemdetailswarranty => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-system-details-warranty']");

        public object SystemToolsNahimic { get; internal set; }

        /// <summary>SystemToolsNahimic
        /// </summary>
        //public static string GamingLegionEdgeListChild = "//*[@AutomationId='gaming_legion_edge']/child::*/*";
        //public string NetworkBoostPopWindowRemoveBtn = "nb_remove";

        public ToggleState NetworkBoostStatusFromSubpage()
        {
            ToggleState toggleStatus = ToggleState.Indeterminate;
            if (LegionEdgeNetworkBoostSubpageToggleOn != null)
            {
                toggleStatus = ToggleState.On;
            }
            else if (LegionEdgeNetworkBoostSubpageToggleOff != null)
            {
                toggleStatus = ToggleState.Off;
            }
            return toggleStatus;
        }

        public bool SwitchNetworkBoostStatusFromSubpage()
        {
            ToggleState toggleStatus = NetworkBoostStatusFromSubpage();
            if (LegionEdgeNetworkBoostSubpageToggleOn != null)
            {
                LegionEdgeNetworkBoostSubpageToggleOn.Click();
            }
            else if (LegionEdgeNetworkBoostSubpageToggleOff != null)
            {
                LegionEdgeNetworkBoostSubpageToggleOff.Click();
            }
            if (toggleStatus != NetworkBoostStatusFromSubpage() && toggleStatus != ToggleState.Indeterminate)
            {
                return true;
            }
            return false;

        }
        public ToggleState NetworkBoostStatus()
        {
            ToggleState toggleStatus = ToggleState.Indeterminate;
            if (LegionEdgeNetworkBoostToggleOn != null)
            {
                toggleStatus = ToggleState.On;
            }
            else if (LegionEdgeNetworkBoostToggleOff != null)
            {
                toggleStatus = ToggleState.Off;
            }
            return toggleStatus;
        }

        public bool SwitchNetworkBoostStatus()
        {
            ToggleState toggleStatus = NetworkBoostStatus();
            if (LegionEdgeNetworkBoostToggleOff != null)
            {
                LegionEdgeNetworkBoostToggleOff.Click();
            }
            else if (LegionEdgeNetworkBoostToggleOn != null)
            {
                LegionEdgeNetworkBoostToggleOn.Click();
            }
            if (toggleStatus != NetworkBoostStatus() && toggleStatus != ToggleState.Indeterminate)
            {
                return true;
            }
            return false;
        }
        public bool SetPopWindowNoRunning(int timeout = 50)
        {
            int index = 0;

            while (index < timeout)
            {
                /**/
                if (LegionEdgeNetworkBoostSubpageCloseAddBtn != null)
                {
                    LegionEdgeNetworkBoostSubpageCloseAddBtn.Click();
                }
                else if (NetworkBoostAddAppNoRunningClose != null)
                {
                    NetworkBoostAddAppNoRunningClose.Click();
                }
                LegionEdgeNetworkBoostSubpageAddBtn.Click();
                if (NetworkBoostAddAppNoRunningClose != null)
                {
                    return true;
                }
                List<string> windowsElement = new List<string>();
                //List<string> NetUsingProcess = NerveCenterHelper.GetApplistHelper(1);

                foreach (WindowsElement appname in NetworkBoostRunningEdgeList)
                {
                    windowsElement.Add(appname.GetAttribute("Name").Substring(4));
                    if (_proProcess.Contains(appname.GetAttribute("Name").Substring(4)))
                    {
                        appname?.Click();
                    }
                }
                /*
                for (int i = 0; i < NetworkBoostRunningEdgeList.Count; i++)
                {
                    string xpath = string.Format("//*[@AutomationId='{0}']", NetworkBoostPopWindowAddBtn + i.ToString());
                    WindowsElement addElement =  base.FindElementByTimes(session, "XPath", xpath);
                    string addName = VantageCommonHelper.GetAttributeValue(addElement, "Name").Substring(4);
                    windowsElement.Add(addName);
                    if (_proProcess.Contains(addName))
                    {
                        addElement.Click();
                    }
                }*/

                Process[] processes = Process.GetProcesses();
                string psDec = string.Empty;
                foreach (Process ps in processes)
                {
                    try
                    {
                        //psDec = ps.MainModule.FileVersionInfo.FileDescription;
                        psDec = GetProcessDescription(ps.ProcessName);
                        if (_proProcess.Contains(psDec))
                        {
                            continue;
                        }
                        if (windowsElement.Contains(psDec))
                        {
                            string killProcess = System.IO.Path.Combine(VantageConstContent.DataPath, "KillProcessDescription");
                            if (File.Exists(killProcess))
                            {
                                File.Delete(killProcess);
                            }
                            File.WriteAllText(killProcess, psDec);
                            ps.Kill();
                        }
                    }
                    catch (Exception ex)
                    {
                        //Assert.Warn(psDec + ": " + ex.ToString());
                    }
                }
                index++;
            }
            return false;
        }

        public bool SetPopWindowIsRunning()
        {
            /*
            LegionEdgeNetworkBoostSubpageAddBtn.Click();
            List<WindowsElement> NetUsingProcess = NetworkBoostRunningEdgeList;
            if (NetUsingProcess.Count > 0)
            {
                return true;
            }
            else
            {
                NetworkBoostAddAppNoRunningClose.Click();
            }
            if (NetworkBoostAddRemove0 != null)
            {
                NetworkBoostAddRemove0.Click();
            }*/
            while (true)
            {
                if (NetworkBoostAppList.Count > 2)
                {
                    NetworkBoostAppList[2]?.Click();
                    Thread.Sleep(500);
                }
                else
                {
                    break;
                }
            }
            LegionEdgeNetworkBoostSubpageAddBtn.Click();
            if (LegionEdgeNetworkBoostAddApp0 != null)
            {
                return true;
            }
            return false;
        }

        public override void ScrollScreen()
        {
            touchScreen = new RemoteTouchScreen(session);
            touchScreen.Scroll(0, -500);
        }
        public List<WindowsElement> GetXpathValue(int count, string automationid)
        {
            List<WindowsElement> NetworkBoostPopWindowAddBtnList = new List<WindowsElement>();

            for (int i = 0; i < count; i++)
            {
                string xpath = string.Format("//*[@AutomationId='{0}']", automationid + i.ToString());
                NetworkBoostPopWindowAddBtnList.Add(base.FindElementByTimes(session, "XPath", xpath));
            }
            return NetworkBoostPopWindowAddBtnList;
        }

        public string GetProcessDescription(string processName)
        {
            string processDec = null;
            try
            {
                string resultOutput;
                Process proc = new Process();
                proc.StartInfo.FileName = "cmd.exe";
                proc.StartInfo.Arguments = string.Format("(/C powershell (get-process {0}).Description", processName);
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardInput = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.CreateNoWindow = false;
                proc.Start();
                //proc.WaitForExit();
                processDec = proc.StandardOutput.ReadLine();
                proc.Close();
                //processDec = resultOutput.Split('\r')[0];
            }
            catch (Exception ex)
            {
                return null;
            }

            return processDec;
        }

        public Dictionary<string, WindowsElement> GetCPUPreCoreOCItemsIcon(bool isMinusIcon, string currentMachineType = "T750")
        {
            Dictionary<string, WindowsElement> cpuoc = new Dictionary<string, WindowsElement>();
            cpuoc.Clear();
            if (currentMachineType == "T750")
            {
                cpuoc.Add("1 Core Ratio", isMinusIcon ? OneCoreRatioMinusIcon : OneCoreRatioPlusIcon);
                cpuoc.Add("2 Core Ratio", isMinusIcon ? TwoCoreRatioMinusIcon : TwoCoreRatioPlusIcon);
                cpuoc.Add("3 Core Ratio", isMinusIcon ? ThreeCoreRatioMinusIcon : ThreeCoreRatioPlusIcon);
                cpuoc.Add("4 Core Ratio", isMinusIcon ? FourCoreRatioMinusIcon : FourCoreRatioPlusIcon);
                cpuoc.Add("5 Core Ratio", isMinusIcon ? FiveCoreRatioMinusIcon : FiveCoreRatioPlusIcon);
                cpuoc.Add("6 Core Ratio", isMinusIcon ? SixCoreRatioMinusIcon : SixCoreRatioPlusIcon);
                cpuoc.Add("7 Core Ratio", isMinusIcon ? SevenCoreRatioMinusIcon : SevenCoreRatioPlusIcon);
                cpuoc.Add("8 Core Ratio", isMinusIcon ? EightCoreRatioMinusIcon : EightCoreRatioPlusIcon);
                cpuoc.Add("9 Core Ratio", isMinusIcon ? NineCoreRatioMinusIcon : NineCoreRatioPlusIcon);
                cpuoc.Add("10 Core Ratio", isMinusIcon ? TenCoreRatioMinusIcon : TenCoreRatioPlusIcon);
                cpuoc.Add("Core Voltage", isMinusIcon ? CoreVoltageMinusIcon : CoreVoltagePlusIcon);
                cpuoc.Add("Cache Voltage", isMinusIcon ? CacheVoltageMinusIcon : CacheVoltagePlusIcon);
                cpuoc.Add("Core ICCMAX", isMinusIcon ? CoreICCMAXMinusIcon : CoreICCMAXPlusIcon);
                cpuoc.Add("Cache ICCMAX", isMinusIcon ? CacheICCMAXMinusIcon : CacheICCMAXPlusIcon);
            }
            else if (currentMachineType == "Y750")
            {
                cpuoc.Add("1 Active Core Ratio", isMinusIcon ? OneActiveCoreRatioMinusIcon : OneActiveCoreRatioPlusIcon);
                cpuoc.Add("2 Active Core Ratio", isMinusIcon ? TwoActiveCoreRatioMinusIcon : TwoActiveCoreRatioPlusIcon);
                cpuoc.Add("3 Active Core Ratio", isMinusIcon ? ThreeActiveCoreRatioMinusIcon : ThreeActiveCoreRatioPlusIcon);
                cpuoc.Add("4 Active Core Ratio", isMinusIcon ? FourActiveCoreRatioMinusIcon : FourActiveCoreRatioPlusIcon);
                cpuoc.Add("5 Active Core Ratio", isMinusIcon ? FiveActiveCoreRatioMinusIcon : FiveActiveCoreRatioPlusIcon);
                cpuoc.Add("6 Active Core Ratio", isMinusIcon ? SixActiveCoreRatioMinusIcon : SixActiveCoreRatioPlusIcon);
                cpuoc.Add("7 Active Core Ratio", isMinusIcon ? SevenActiveCoreRatioMinusIcon : SevenActiveCoreRatioPlusIcon);
                cpuoc.Add("8 Active Core Ratio", isMinusIcon ? EightActiveCoreRatioMinusIcon : EightActiveCoreRatioPlusIcon);
            }
            cpuoc.Add("Core Voltage offset", isMinusIcon ? CoreVoltageOffsetMinusIcon : CoreVoltageOffsetPlusIcon);
            cpuoc.Add("Cache Voltage offset", isMinusIcon ? CacheVoltageOffsetMinusIcon : CacheVoltageOffsetPlusIcon);
            cpuoc.Add("AVX Ratio offset", isMinusIcon ? AVXRatioOffsetMinusIcon : AVXRatioOffsetPlusIcon);
            cpuoc.Add("Cache Ratio", isMinusIcon ? CacheRatioMinusIcon : CacheRatioPlusIcon);
            return cpuoc;
        }

        public Dictionary<string, WindowsElement> GetCPUPreCoreOCSlider(string currentMachineType = "T750")
        {
            Dictionary<string, WindowsElement> cpuslider = new Dictionary<string, WindowsElement>();
            cpuslider.Clear();
            if (currentMachineType == "T750")
            {
                cpuslider.Add("1 Core Ratio", OneCoreRatioSlider);
                cpuslider.Add("2 Core Ratio", TwoCoreRatioSlider);
                cpuslider.Add("3 Core Ratio", ThreeCoreRatioSlider);
                cpuslider.Add("4 Core Ratio", FourCoreRatioSlider);
                cpuslider.Add("5 Core Ratio", FiveCoreRatioSlider);
                cpuslider.Add("6 Core Ratio", SixCoreRatioSlider);
                cpuslider.Add("7 Core Ratio", SevenCoreRatioSlider);
                cpuslider.Add("8 Core Ratio", EightCoreRatioSlider);
                cpuslider.Add("9 Core Ratio", NineCoreRatioSlider);
                cpuslider.Add("10 Core Ratio", TenCoreRatioSlider);
                cpuslider.Add("Core Voltage", CoreVoltageSlider);
                cpuslider.Add("Cache Voltage", CacheVoltageSlider);
                cpuslider.Add("Core ICCMAX", CoreICCMAXSlider);
                cpuslider.Add("Cache ICCMAX", CacheICCMAXSlider);
            }
            else if (currentMachineType == "Y750")
            {
                cpuslider.Add("1 Active Core Ratio", OneActiveCoreRatioSlider);
                cpuslider.Add("2 Active Core Ratio", TwoActiveCoreRatioSlider);
                cpuslider.Add("3 Active Core Ratio", ThreeActiveCoreRatioSlider);
                cpuslider.Add("4 Active Core Ratio", FourActiveCoreRatioSlider);
                cpuslider.Add("5 Active Core Ratio", FiveActiveCoreRatioSlider);
                cpuslider.Add("6 Active Core Ratio", SixActiveCoreRatioSlider);
                cpuslider.Add("7 Active Core Ratio", SevenActiveCoreRatioSlider);
                cpuslider.Add("8 Active Core Ratio", EightActiveCoreRatioSlider);
            }
            cpuslider.Add("Core Voltage offset", CoreVoltageOffsetSlider);
            cpuslider.Add("Cache Voltage offset", CacheVoltageOffsetSlider);
            cpuslider.Add("AVX Ratio offset", AVXRatioOffsetSlider);
            cpuslider.Add("Cache Ratio", CacheRatioSlider);
            return cpuslider;
        }

        public Dictionary<string, Double> GetCPUPreCoreOCSliderBarValue(string currentMachineType = "T750")
        {
            Dictionary<string, Double> cpuSliderBarValues = new Dictionary<string, Double>();
            cpuSliderBarValues.Clear();
            if (currentMachineType == "T750")
            {
                cpuSliderBarValues.Add("1 Core Ratio", double.Parse(OneCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
                cpuSliderBarValues.Add("2 Core Ratio", double.Parse(TwoCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
                cpuSliderBarValues.Add("3 Core Ratio", double.Parse(ThreeCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
                cpuSliderBarValues.Add("4 Core Ratio", double.Parse(FourCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
                cpuSliderBarValues.Add("5 Core Ratio", double.Parse(FiveCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
                cpuSliderBarValues.Add("6 Core Ratio", double.Parse(SixCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
                cpuSliderBarValues.Add("7 Core Ratio", double.Parse(SevenCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
                cpuSliderBarValues.Add("8 Core Ratio", double.Parse(EightCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
                cpuSliderBarValues.Add("9 Core Ratio", double.Parse(NineCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
                cpuSliderBarValues.Add("10 Core Ratio", double.Parse(TenCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
                cpuSliderBarValues.Add("Core Voltage", double.Parse(CoreVoltageLevelDefault.Text.Split(' ')[0].Trim()));
                cpuSliderBarValues.Add("Cache Voltage", double.Parse(CacheVoltageLevelDefault.Text.Split(' ')[0].Trim()));
                cpuSliderBarValues.Add("Core ICCMAX", double.Parse(CoreICCMAXLevelDefault.Text.Split(' ')[0].Trim()));
                cpuSliderBarValues.Add("Cache ICCMAX", double.Parse(CacheICCMAXLevelDefault.Text.Split(' ')[0].Trim()));
            }
            else if (currentMachineType == "Y750")
            {
                cpuSliderBarValues.Add("1 Active Core Ratio", double.Parse(OneActiveCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
                cpuSliderBarValues.Add("2 Active Core Ratio", double.Parse(TwoActiveCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
                cpuSliderBarValues.Add("3 Active Core Ratio", double.Parse(ThreeActiveCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
                cpuSliderBarValues.Add("4 Active Core Ratio", double.Parse(FourActiveCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
                cpuSliderBarValues.Add("5 Active Core Ratio", double.Parse(FiveActiveCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
                cpuSliderBarValues.Add("6 Active Core Ratio", double.Parse(SixActiveCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
                cpuSliderBarValues.Add("7 Active Core Ratio", double.Parse(SevenActiveCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
                cpuSliderBarValues.Add("8 Active Core Ratio", double.Parse(EightActiveCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
            }
            cpuSliderBarValues.Add("Core Voltage offset", double.Parse(CoreVoltageOffsetLevelDefault.Text.Split(' ')[0].Trim()));
            cpuSliderBarValues.Add("Cache Voltage offset", double.Parse(CacheVoltageOffsetLevelDefault.Text.Split(' ')[0].Trim()));
            cpuSliderBarValues.Add("AVX Ratio offset", double.Parse(AVXRatioOffsetLevelDefault.Text.Split(' ')[0].Trim()));
            cpuSliderBarValues.Add("Cache Ratio", double.Parse(CacheRatioLevelDefault.Text.Split(' ')[0].Trim()));
            return cpuSliderBarValues;
        }
    }
}