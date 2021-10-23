namespace LenovoVantageTest.Pages
{
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;


    public class SupportPage : BasePage
    {
        private WindowsDriver<WindowsElement> session;
        private WebDriverWait wait;
        private RemoteTouchScreen touchScreen;
        private Actions action;
        public WindowsElement givefeedbacktitle => base.GetElement(session, "AutomationId", "support-give-feedback-title");
        public WindowsElement backBtn => base.GetElement(session, "AutomationId", "support-page-btn-back");
        public WindowsElement qaFirstDetailsTitle => base.GetElement(session, "AutomationId", "support-detail-article-1-tittle");
        public WindowsElement qaSecondDetailsTitle => base.GetElement(session, "AutomationId", "support-detail-article-2-tittle");
        public WindowsElement qaThirdDetailsTitle => base.GetElement(session, "AutomationId", "support-detail-article-3-tittle");
        public WindowsElement qaForthDetailsTitle => base.GetElement(session, "AutomationId", "support-detail-article-4-tittle");
        public WindowsElement qaFifthDetailsTitle => base.GetElement(session, "AutomationId", "support-detail-article-5-tittle");
        public WindowsElement qaSixthDetailsTitle => base.GetElement(session, "AutomationId", "support-detail-article-6-tittle");

        public WindowsElement DialogGiveFeedBackTitle => FindElementByTimes(session, "AutomationId", "feedback-dialog-basic-title");
        public WindowsElement DialogGiveFeedBackCloseBtn => FindElementByTimes(session, "AutomationId", "feedback-modal-btn-close");
        public WindowsElement DialogSendFeedBackBtn => FindElementByTimes(session, "AutomationId", "modal-btn-sendfeedback");

        public SupportPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
        }

        public string PreferenceSettingsTitle = "//Text[@Name='Preference Settings']";


        /// <summary>
        /// support Tab
        /// </summary>
        public WindowsElement supportTab => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-toggle-support");

        /// <summary>
        /// User Guide Link
        /// </summary>
        public WindowsElement userGuideLink => base.GetElement(session, "AutomationId", "Documentation.UserGuideButton");

        /// <summary>
        /// Lenovo Community button
        /// </summary>
        public WindowsElement lenovoCommunityButton => base.GetElement(session, "AutomationId", "NeedHelp.LenovoCommunityButton");

        /// <summary>
        /// Contact customer service button
        /// </summary>
        public WindowsElement contactCustomerServiceButton => base.GetElement(session, "AutomationId", "NeedHelp.ContactCustomerServiceButton");

        /// <summary>
        /// Your Virtual assistant button
        /// </summary>
        public WindowsElement yourVirtualAssistantButton => base.GetElement(session, "AutomationId", "NeedHelp.YourVirtualAssistantButton");


        /// <summary>
        /// About Lenovo Vantage page button
        /// </summary>
        public WindowsElement aboutLenovoVantagePageButton => base.GetElement(session, "AutomationId", "Quicklinks.AboutLenovoVantageButton");

        /// <summary>
        /// Our website link under About Lenovo Vantage page
        /// </summary>
        public WindowsElement ourWebsiteLink => base.GetElement(session, "AutomationId", "about-modal-web-link");


        /// <summary>
        /// About your device link under About Lenovo Vantage page
        /// </summary>
        public WindowsElement aboutYourDeviceLink => base.GetElement(session, "AutomationId", "about-modal-user-guide-link");

        /// <summary>
        /// Scroll the screen
        /// </summary>
        public override void ScrollScreen()
        {
            touchScreen = new RemoteTouchScreen(session);
            touchScreen.Scroll(0, -500);
        }



    }
}

