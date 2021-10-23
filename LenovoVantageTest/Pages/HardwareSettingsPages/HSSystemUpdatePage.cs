namespace LenovoVantageTest.Pages
{
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Interactions;

    public class HSSystemUpdatePage : SettingsBase
    {
        private WindowsDriver<WindowsElement> session;
        private Actions action;

        public HSSystemUpdatePage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
        }

        /// <summary>
        /// Update header title
        /// </summary>
        public WindowsElement updateHeaderTitle => base.GetElement(session, "AutomationId", "system-update-header-title");

        /// <summary>
        /// The Check For Update Button
        /// </summary>
        public WindowsElement checkForUpdateButton => base.GetElement(session, "AutomationId", "su_check_updates");

        /// <summary>
        /// The Cancel Check Link
        /// </summary>
        public WindowsElement cancelCheckLink => base.GetElement(session, "Name", "Cancel check");

        /// <summary>
        /// The Update progress Bar
        /// </summary>
        public WindowsElement progressbar => base.GetElement(session, "AutomationId", "su_check_progress");

        public WindowsElement SystemUpdateInstallNow => FindElementByTimes(session, "AutomationId", "su_update_now");

        /// <summary>
        /// Checking for Updates Context, it appears after click Check for Updates button
        /// </summary>
        public WindowsElement checkingforUpdateText => base.GetElement(session, "Name", "Checking for updates");

        /// <summary>
        /// Completed Percentage
        /// </summary>
        public WindowsElement completedPercentage => base.GetElement(session, "Name", "% complete");

        /// <summary>
        /// Update available text
        /// </summary>
        public WindowsElement availableUpdatesText => base.GetElement(session, "Name", "Available updates");

        /// <summary>
        /// Install available update button
        /// </summary>
        public WindowsElement installAllUpdateButton => base.GetElement(session, "Name", "Install all updates");

        /// <summary>
        /// Critial updates checkbox
        /// </summary>
        public WindowsElement criticalUpdatesCheckBox => base.GetElement(session, "AutomationId", "critical-updates-input");

        /// <summary>
        /// Recommended updates checkbox
        /// </summary>
        public WindowsElement recommendedUpdatesCheckBox => base.GetElement(session, "AutomationId", "recommended-updates-input");

        /// <summary>
        /// Need a method to handle System update button. it is not always enable when navigate to SU page.
        /// </summary>
        public void SelectCheckForSystemUpdateButton()
        {
            action = new Actions(session);

            while (checkForUpdateButton.Enabled == false)
            {
                action.MoveToElement(checkForUpdateButton);
            }
            checkForUpdateButton.Click();
        }
    }
}
