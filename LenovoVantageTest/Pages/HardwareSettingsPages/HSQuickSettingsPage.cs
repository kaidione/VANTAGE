namespace LenovoVantageTest.Pages
{
    using LenovoVantageTest.Helper;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Windows.Automation;
    using System.Windows.Forms;

    public class HSQuickSettingsPage : SettingsBase
    {
        private WebDriverWait wait;
        private Actions action;
        private string amCapPath = @"C:\Program Files (x86)\Noël Danjou\AMCap\amcap.exe";
        private string amCapTempPath = @"c:\amcaptemp.txt";
        public const string saWidget = "Security Advisor";

        public HSQuickSettingsPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
        }

        public string findSecurityListItemXPath = "//*[@AutomationId='menu-main-nav-lnk-dropdown-toggle-security']/parent::*/*";

        public string findDeviceListItemXPath = "//*[@AutomationId='menu-main-nav-lnk-dropdown-toggle-device']/parent::*/*";

        public string findUserListItemXPath = "//*[@AutomationId='navbarDropdown']/parent::*/*";

        /// <summary>
        /// Dashboard Link
        /// </summary>
        public WindowsElement dashboardLink => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dashboard");

        public WindowsElement QuickSettingsMicrophoneXpath => FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'qs-microphone-switch-')]");
        public WindowsElement QuickSettingsCameraXpath => FindElementByTimes(session, "XPath", "//*[contains(@AutomationId,'qs-camera-switch-')]");
        public WindowsElement QuickSettingsCameraAccessTipDesc => FindElementByTimes(session, "XPath", "//*[@Name=\"Lenovo Vantage doesn\'t have access to the camera.\"]");
        public WindowsElement QuickSettingsMicrophoneAccessTipDesc => FindElementByTimes(session, "XPath", "//*[@Name=\"Lenovo Vantage doesn\'t have access to the microphone.\"]");
        public WindowsElement QuickSettingsMicrophoneAccessTipDescLe => FindElementByTimes(session, "XPath", "//*[@Name=\"Lenovo Vantage doesn\'t have access to Microphone.\"]");

        /// <summary>
        /// Disable Microphone
        /// </summary>
        public WindowsElement disableMicrophone => base.GetElement(session, "AutomationId", "qs-microphone-switch-disable-state");

        /// <summary>
        /// Microphone Function
        /// </summary>
        public WindowsElement microphoneFunction => base.GetElement(session, "AutomationId", "qs-switch-microphone");

        /// <summary>
        /// Microphone Off Button
        /// </summary>
        public WindowsElement microphoneOffButton => base.GetElement(session, "AutomationId", "qs-microphone-switch-off-state", 6);

        /// <summary>
        /// Microphone Button Off
        /// </summary>
        public WindowsElement microphoneButtonOff => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='qs-microphone-switch-off-state']");

        /// <summary>
        /// Microphone On Button
        /// </summary>
        public WindowsElement microphoneOnButton => base.GetElement(session, "AutomationId", "qs-microphone-switch-on-state", 6);

        /// <summary>
        /// Microphone Button On
        /// </summary>
        public WindowsElement microphoneButtonOn => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='qs-microphone-switch-on-state']");

        /// <summary>
        /// Microphone Access Tip
        /// </summary>
        public WindowsElement microphoneAccessTip => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Dashboard.microphoneAccessTip"));

        /// <summary>
        /// Microphone Camera Access Tip
        /// </summary>
        public WindowsElement microphoneCameraAccessTip => base.GetElement(session, "AutomationId", "qs-microphone-camera-access-ink");

        /// <summary>
        /// Camera Function
        /// </summary>
        public WindowsElement cameraFunction => base.GetElement(session, "AutomationId", "qs-switch-camera");

        /// <summary>
        /// Disable Camera
        /// </summary>
        public WindowsElement disableCamera => base.GetElement(session, "AutomationId", "qs-camera-switch-disable-state");

        /// <summary>
        /// Camera Access Tip
        /// </summary>
        public WindowsElement cameraAccessTip => base.GetElement(session, "AutomationId", "qs-camera-access-link");

        /// <summary>
        /// Camera Off Button
        /// </summary>
        public WindowsElement cameraOffButton => base.GetElement(session, "AutomationId", "qs-camera-switch-off-state", 6);

        /// <summary>
        /// Camera Button Off
        /// </summary>
        public WindowsElement cameraButtonOff => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='qs-camera-switch-off-state']");

        /// <summary>
        /// Camera On Button
        /// </summary>
        public WindowsElement cameraOnButton => base.GetElement(session, "AutomationId", "qs-camera-switch-on-state", 6);

        /// <summary>
        /// Update Button
        /// </summary>
        public WindowsElement updateButton => base.GetElement(session, "AutomationId", "qs-system-update-switch-on-state");

        /// <summary>
        /// Security Toggle
        /// </summary>
        public WindowsElement securityToggle => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-toggle-security");

        /// <summary>
        /// Security Toggle
        /// </summary>
        public WindowsElement userBar => base.GetElement(session, "AutomationId", "navbarDropdown");

        /// <summary>
        /// Close button
        /// </summary>
        public WindowsElement closeButton => base.GetElement(session, "AutomationId", "Close");


        /// <summary>
        /// My Security Link
        /// </summary>
        //public WindowsElement preferenceSettingsLink => base.GetElement(session, "Name", "Preference Settings");
        public WindowsElement preferenceSettingsLink => base.GetElement(session, "AutomationId", "menu-main-lnk-open-preference");

        /// <summary>
        /// Security Tab
        /// </summary>
        public WindowsElement securityTab => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-toggle-security");

        /// <summary>
        /// Input Tab
        /// </summary>
        public WindowsElement displayTab => base.GetElement(session, "AutomationId", "myDevice-settings-header-menu-display-camera");
        /// <summary>
        /// My Device Settings Link on dashboard
        /// </summary>
        public WindowsElement myDeviceSettingsLinkOnDashboard => base.GetElement(session, "AutomationId", "qs-lnk-my-device-settings");

        /// <summary>
        /// My Device Settings Link on dashboard
        /// </summary>
        public WindowsElement myDeviceSettingsLinkElementOnDashboard => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='qs-lnk-my-device-settings']");

        /// <summary>
        /// My Device Settings Header Title
        /// </summary>
        public WindowsElement myDeviceSettingsHeaderTitle => base.GetElement(session, "AutomationId", "myDevice-settings-header-title");

        /// <summary>
        /// My Security Link
        /// </summary>
        public WindowsElement mySecurityLink => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-security-0");
        //public WindowsElement mySecurityLink => base.GetElement(session, "Name", "My security");

        /// <summary>
        /// Anti-Vrius Link
        /// </summary>
        public WindowsElement antiVriusLink => base.GetElement(session, "Name", "Anti-virus");

        /// <summary>
        /// Password health Link
        /// </summary>
        public WindowsElement passwordHealthLink => base.GetElement(session, "Name", "Password health");

        /// <summary>
        /// WiFi Security Link
        /// </summary>
        public WindowsElement wifiSecurityLink => base.GetElement(session, "Name", "WiFi security");

        /// <summary>
        /// Internet Protection Link
        /// </summary>
        public WindowsElement internetProtection => base.GetElement(session, "Name", "Internet Protection");

        /// <summary>
        /// System Update Link
        /// </summary>
        public WindowsElement systemUpdateLink => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-device-2");

        /// <summary>
        /// Device Tab
        /// </summary>
        public WindowsElement deviceTab => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Navbar.device"));
        /// <summary>
        /// My Device Settings Link
        /// </summary>
        public WindowsElement myDeviceSettingsLink => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-device-1");
        public WindowsElement myDeviceLink => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-device-0");
        public WindowsElement FullChargeCapacity => GetElement(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.FullChargeCapacity"));
        /// <summary>
        /// See Battery Details Link
        /// </summary>
        public WindowsElement seeBatteryDetailsLink => base.GetElement(session, "AutomationId", "myDevice-settings-battery-details-btn");

        /// <summary>
        /// See Battery Details Question Mark Link
        /// </summary>
        public WindowsElement seeBatteryDetailsQuestionMarkLink => base.GetElement(session, "AutomationId", "fullChargeCapacity_tooltip_icon");
        public WindowsElement ManufactureDate => GetElement(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.ManufactureDate"));

        /// <summary>
        /// Question Mark Message
        /// </summary>
        public WindowsElement questionMarkMessage => GetElement(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.QuestionMarkMessage"));
        public WindowsElement QuestionMarkMessageHere => FindElementByTimes(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.QuestionMarkMessageHere"));
        public WindowsElement QuestionMarkMessageInformation => FindElementByTimes(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.QuestionMarkMessageInformation"));

        /// <summary>
        /// Question Mark Click Here Message line 1
        /// </summary>
        public WindowsElement questionMarkMessageLine1 => base.GetElement(session, "Name", "To increase battery lifespan, your battery automatically adjusts charge voltage and capacity in response to your personal usage pattern.");

        /// <summary>
        /// Question Mark Click Here Message line 2
        /// </summary>
        public WindowsElement questionMarkMessageLine2 => base.GetElement(session, "Name", "- If you use less than 65% of your battery’s capacity for a week or longer, then the battery may temporarily reduce charge voltage and capacity. The reduction in capacity is minor and not noticeable for your usage pattern.");

        /// <summary>
        /// Question Mark Click Here Message line 3
        /// </summary>
        public WindowsElement questionMarkMessageLine3 => base.GetElement(session, "Name", "- Full capacity is restored when you discharge your battery below 20% and then fully charge the battery.");

        /// <summary>
        /// Question Mark Click Here Message line 4
        /// </summary>
        public WindowsElement questionMarkMessageLine4 => base.GetElement(session, "Name", "- Additionally, if you use less than 10% of your battery’s capacity for 2 weeks or longer, the battery may temporarily reduce charge voltage and capacity further, until such time as 50% of reduced battery capacity is used.");
        public WindowsElement HighDensityBattery => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.HighDensityBattery"));
        public WindowsElement HighDensityBatteryworks => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.HighDensityBatteryworks"));

        /// <summary>
        /// Battery Details Question Mark Click Here Link
        /// </summary>
        public WindowsElement BatteryDetailsQuestionMarkClickHere => base.GetElement(session, "Name", "here");

        /// <summary>
        /// Vantage Maxmize Button
        /// </summary>
        public WindowsElement VantageMaxmizeButton => base.GetElement(session, "AutomationId", "Maximize");

        /// <summary>
        /// NoBatteryText
        /// </summary>
        public WindowsElement NoBatteryText => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.NoBatteryText"));

        /// <summary>
        /// Vantage Usage Statistics
        /// </summary>
        public WindowsElement VantageUsageStatistics => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PreferencePage.VantageUsageStatistics"));

        /// <summary>
        /// No Connection Pane
        /// </summary>
        public WindowsElement noConnectionPane => base.GetElement(session, "Name", "No internet connection detected");

        /// <summary>
        /// Give FeedBack button, this button has been disable now.
        /// </summary>
        public WindowsElement giveFeedBackButton => base.GetElement(session, "Name", "Give feedback");

        /// <summary>
        /// Check For System Update Button, this button replace give feedback now.
        /// </summary>
        public WindowsElement checkForSystemUpdateButton => base.GetElement(session, "Name", "Check for system updates");

        /// <summary>
        /// VPN Security Link
        /// </summary>
        public WindowsElement vpnSecurityLink => base.GetElement(session, "Name", "VPN security");

        public WindowsElement SUWidgetTitle => base.GetElement(session, "AutomationId", "widget-system-update-title");

        /// <summary>
        /// Security Advisor Widget 
        /// </summary>
        public IReadOnlyCollection<WindowsElement> dashBoard => session.FindElementsByAccessibilityId("main-wrapper");

        /// <summary>
        /// Security DropDown List
        /// </summary>
        public IReadOnlyCollection<WindowsElement> securityDropDownList => session.FindElementsByName("menu-main-nav-lnk-dropdown-toggle-security");

        /// <summary>
        /// Vantage Pane
        /// </summary>
        public IReadOnlyCollection<WindowsElement> vantagePane => session.FindElementsByName("Lenovo Vantage");

        //HSDispalyCameraPage
        public WindowsElement HSDispalyCameraPage_Title => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.displayAndCameraLink"));
        public WindowsElement cameraPrivacyMode_Toggle => GetElement(session, "AutomationId", "camera-privacy-mode_checkbox");
        public WindowsElement ECMTitle => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.ECMTitle"));
        public WindowsElement ECMTextId => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.ECMTextId"));
        public WindowsElement ECMHere => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.ECMHere"));
        public WindowsElement ECMWinButton => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.ECMWinButton"));
        public WindowsElement ECMWinClose => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.ECMWinClose"));
        public WindowsElement ECMColor => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.ECMColor"));
        public WindowsElement ScheduleECM => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.ScheduleECM"));
        public WindowsElement ScheduleECMlabel => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.ScheduleECMlabel"));
        public WindowsElement DisplayLink => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.DisplayLink"));
        public WindowsElement CameraLink => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraLink"));
        public WindowsElement PrivacyGuardTitleId => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.PrivacyGuardTitleId"));
        public WindowsElement PrivacyGuardDescriptionId => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.PrivacyGuardDescriptionId"));
        public WindowsElement PrivacyGuardDescriptionNameforLe => FindElementByTimes(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.PrivacyGuardDescriptionNameforLe"));
        public WindowsElement PrivacyGuardNoteNameforLe => FindElementByTimes(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.PrivacyGuardNoteNameforLe"));
        public WindowsElement PrivacyGuardNoteId => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.PrivacyGuardNoteId"));
        public WindowsElement PrivacyGuardCBId => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.PrivacyGuardCBId"));
        public WindowsElement PrivacyGuardToggle => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.PrivacyGuardToggle"));
        public WindowsElement PrivacyGuardCheckbox => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.PrivacyGuardCheckbox"));
        public WindowsElement CameraPrivacyQuestionMark => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraPrivacyQuestionMark"));
        public WindowsElement CameraPrivacyQuestionMarkToolTip => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraPrivacyQuestionMarkToolTip"));
        public WindowsElement CameraPrivacyToggle => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.privacyToggle"));
        public WindowsElement CameraResetBtn => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraResetBtn"));
        public WindowsElement CameraBrightnessSlider => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraBrightnessSlider"));
        public WindowsElement CameraContrastSlider => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraContrastSlider"));
        public WindowsElement CameraPreview => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraPreview"));
        public WindowsElement CameraAutoExposureSlider => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraAutoExposureSlider"));
        public WindowsElement CameraAutoExposureBtn => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraAutoExposureBtn"));
        public WindowsElement CameraPrivacyModeCaption => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraPrivacyModeCaption"));
        public WindowsElement CameraBrightness => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraBrightness"));
        public WindowsElement CameraContrast => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraContrast"));
        public WindowsElement CameraAutoExposure => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraAutoExposure"));
        public WindowsElement CameraPrivacyModeTitle => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraPrivacyModeTitle"));
        public WindowsElement DeviceSettingsCameraAccessUrl => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.DeviceSettingsCameraAccessUrl"));
        public WindowsElement CameraIsInUseName => FindElementByTimes(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraIsInUseName"));
        public WindowsElement CameraPrivacyModeToolTipRightIcon => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraPrivacyModeToolTipRightIcon"));
        public WindowsElement CameraPrivacyModeToolTip => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.CameraPrivacyModeToolTip"));
        public WindowsElement RemoveECMTitle => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.ECMTitle"));
        public WindowsElement RemoveECMTextId => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.ECMTextId"));

        //Quick Settings Camera Button
        public WindowsElement CameraAccessTip => GetElement(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.Dashboard.CameraAccessTip"));
        public WindowsElement QuickSettingsCameraToggle => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Dashboard.QuickSettingsCameraToggle"));
        public WindowsElement QuickSettingsMicrphoneToggle => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Dashboard.QuickSettingsMicrphoneToggle"));
        public WindowsElement QuickSettingsMicrphoneTitle => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Dashboard.QuickSettingsMicTitle"));
        public WindowsElement QuickSettingsMicrphoneIcon => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Dashboard.QuickSettingsMicIcon"));
        public WindowsElement QuickSettingsCameraTitle => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Dashboard.QuickSettingsCameraTitle"));
        public WindowsElement QuickSettingsCameraIcon => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Dashboard.QuickSettingsCameraIcon"));

        public PasswordHealthPage GoToPasswordHealthPage()
        {
            action = new Actions(session);
            HoverOnSAListItem(securityToggle);
            passwordHealthLink.Click();
            return new PasswordHealthPage(session);
        }

        public PasswordHealthPage GoToPasswordHealthPageWithToggle()
        {
            action = new Actions(session);
            action.MoveToElement(securityToggle).Perform();
            passwordHealthLink.Click();
            return new PasswordHealthPage(session);
        }

        public AntiVirusPage GoToAntiVirusPage()
        {
            action = new Actions(session);
            action.MoveToElement(securityTab).Perform();
            antiVriusLink.Click();
            return new AntiVirusPage(session);
        }

        public void HoverOnSAListItem(WindowsElement element)
        {
            action = new Actions(session);
            int timeout = 8000;

            int popUpItemCount = session.FindElementsByXPath(findSecurityListItemXPath).Count;
            int elapsed = 0;

            while ((popUpItemCount == 1) && (elapsed < timeout))
            {
                elapsed += 1000;
                action.MoveToElement(element).Perform();
                popUpItemCount = session.FindElementsByXPath(findSecurityListItemXPath).Count;
            }
        }

        public void HoverOnUserListItem(WindowsElement element)
        {
            action = new Actions(session);
            int timeout = 8000;

            int popUpItemCount = session.FindElementsByXPath(findUserListItemXPath).Count;
            int elapsed = 0;

            while ((popUpItemCount == 1) && (elapsed < timeout))
            {
                elapsed += 1000;
                action.MoveToElement(element).Perform();
                popUpItemCount = session.FindElementsByXPath(findUserListItemXPath).Count;
            }
        }

        public void HoverOnDeviceListItem(WindowsElement element)
        {
            action = new Actions(session);
            int timeout = 8000;

            int popUpItemCount = session.FindElementsByXPath(findDeviceListItemXPath).Count;
            int elapsed = 0;

            while ((popUpItemCount == 1) && (elapsed < timeout))
            {
                elapsed += 1000;
                action.MoveToElement(element).Perform();
                popUpItemCount = session.FindElementsByXPath(findDeviceListItemXPath).Count;
            }
        }

        private bool IsSAPresent(string locator)
        {
            try
            {
                session.FindElementByName(locator);
                return true;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }

        public string GetValueFromAMCap(string AutoId, string tp)
        {
            var startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = @"C:\Program Files(x86)\Noël Danjou\AMCap";
            startInfo.FileName = amCapPath;
            Process.Start(startInfo);
            Thread.Sleep(2000);
            AutomationElement targetElement = VantageCommonHelper.FindElementByIdIsEnabled("CommandButton_1", 2);
            if (targetElement != null)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick("CommandButton_1");
            }
            SendKeys.SendWait("+%o");
            Thread.Sleep(2000);
            SendKeys.SendWait("v");
            Thread.Sleep(2000);
            SendKeys.SendWait("p");
            Thread.Sleep(2000);
            if (tp == "auto")
            {
                SendKeys.SendWait("{RIGHT}");
            }
            VantageCommonHelper.FindElementByIdAndMouseClick(AutoId);
            SendKeys.SendWait("+{LEFT}");
            SendKeys.SendWait("+{LEFT}");
            SendKeys.SendWait("+{LEFT}");
            SendKeys.SendWait("^c");
            CommandBase.RunCmd("taskkill /f /t /im amcap.exe");
            if (System.IO.File.Exists(@"c:\amcaptemp.txt"))
            {
                FileInfo tempFiles = new FileInfo(amCapTempPath);
                tempFiles.Delete();
            }
            FileStream fs = new FileStream(amCapTempPath, FileMode.Create, FileAccess.Write);
            fs.Close();
            Process tempFileProvess = new Process();
            tempFileProvess.StartInfo.FileName = amCapTempPath;
            tempFileProvess.StartInfo.CreateNoWindow = true;
            tempFileProvess.Start();
            VantageCommonHelper.FindElementByIdAndMouseClick("15");
            SendKeys.SendWait("^v");
            SendKeys.SendWait("^s");
            CommandBase.RunCmd("taskkill /f /t /im notepad.exe");
            StreamReader sr = new StreamReader(amCapTempPath, Encoding.Default);
            string stt = sr.ReadLine();
            sr.Close();
            FileInfo tempFiless = new FileInfo(amCapTempPath);
            tempFiless.Delete();
            return stt;
        }
    }
}
