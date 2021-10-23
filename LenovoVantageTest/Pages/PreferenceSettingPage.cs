using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace LenovoVantageTest.Pages
{
    public class PreferenceSettingPage : BasePage
    {
        private WindowsDriver<WindowsElement> session;
        private Actions action;

        public PreferenceSettingPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
        }
        /// <summary>
        /// device metric toggle
        /// </summary>
        public WindowsElement deviceMetricToggle => base.GetElement(session, "AutomationId", "settingsDeviceStatisticsToggle_checkbox");

        /// <summary>
        /// device metric title 
        /// </summary>
        public WindowsElement deviceMetricTitle => base.GetElement(session, "AutomationId", "settings-deviceStatisticsToggle");
        public WindowsElement myDevicesettingsheadertitle => base.GetElement(session, "AutomationId", "myDevice-settings-header-title");
        public WindowsElement AppFeaturesToggle => base.GetElement(session, "AutomationId", "settingsAppFeaturesToggle_toggleMain");
        public WindowsElement MarketingToggle => base.GetElement(session, "AutomationId", "settingsMarketingToggle_toggleMain");
        public WindowsElement ActionTriggeredToggle => base.GetElement(session, "AutomationId", "settingsActionTriggeredToggle_toggleMain");
        public WindowsElement UsageStatisticsToggle => base.GetElement(session, "AutomationId", "settingsUsageStatisticsToggle_toggleMain");
        public WindowsElement Settingbackbtn => FindElementByTimes(session, "AutomationId", "setting-page-btn-back");
        public WindowsElement CommonBackbtn => FindElementByTimes(session, "XPath", "//*[@Name='< BACK']");
        public WindowsElement SettingsMessageCollapseLink => base.GetElement(session, "AutomationId", "settings-message-collapse-link");
        public WindowsElement SettingsOtherCollapseLink => base.GetElement(session, "AutomationId", "settings-other-collapse-link");
        public WindowsElement SettingsUserProfileCollapseLink => base.GetElement(session, "AutomationId", "settings-user-profile-collapse-link");


        /// <summary>
        /// User Profile Expand
        /// </summary>
        public WindowsElement userProfileExpand => base.GetElement(session, "AutomationId", "settings-user-profile-collapse-link");

        /// <summary>
        /// The Business use bar
        /// </summary>
        public WindowsElement personalUseBar => base.GetElement(session, "AutomationId", "settings-segment-choose-personal-use");

        /// <summary>
        /// The Business use bar
        /// </summary>
        public WindowsElement businessUseBar => base.GetElement(session, "AutomationId", "settings-segment-choose-business-use");

        // public WindowsElement businessUseBarName => base.GetElement(session, "XPath", "Business Use");

        public string findBusinessUseXPath = "//*[@AutomationId='settings-segment-choose-business-use']";
        public WindowsElement businessUseBarName => base.GetElement(session, "XPath", "findBusinessUseXPath");


        /// <summary>
        /// The Save button
        /// </summary>
        //public WindowsElement saveButton => base.GetElement(session, "Name", "Save");
        public WindowsElement saveButton => base.GetElement(session, "AutomationId", "settings-profile-save-button");


        public bool IsPresent(string locator)
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

        public override void ScrollScreen()
        {
            touchScreen = new RemoteTouchScreen(session);
            touchScreen.Scroll(0, -500);
        }

        public void ClickOnSMBButton()
        {
            action = new Actions(session);
            action.MoveToElement(businessUseBarName).Perform();
            action.ContextClick();
        }
    }
}
