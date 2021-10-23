namespace LenovoVantageTest.Pages
{
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Interactions;

    public class SystemUpdatePage : BasePage
    {
        private WindowsDriver<WindowsElement> session;
        private Actions action;

        public SystemUpdatePage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
        }

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

        /// <summary>
        /// Checking for Updates Context, it appears after click Check for Updates button
        /// </summary>
        public WindowsElement auto_updates_title => base.GetElement(session, "AutomationId", "su_auto_updates_title");
        public WindowsElement backBtn => base.GetElement(session, "AutomationId", "system-update-back-btn");

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
        public WindowsElement systemUpdateTitle => base.GetElement(session, "AutomationId", "system-update-title");
        public WindowsElement windowsSetting => base.GetElement(session, "AutomationId", "su-auto-updates-winSettingLink");
        public WindowsElement sideArticle => base.GetElement(session, "AutomationId", "_side_article");
        public WindowsElement articleLink => base.GetElement(session, "AutomationId", "-article_link");
        public WindowsElement offlineIcon => base.GetElement(session, "AutomationId", "-offline-icon");
        public WindowsElement offlineMessage => base.GetElement(session, "Name", "No internet connection detected");
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
