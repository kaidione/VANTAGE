namespace LenovoVantageTest.Pages
{
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;

    public class InternetProtectionPage : BasePage
    {
        private WindowsDriver<WindowsElement> session;
        private WebDriverWait wait;
        private Actions action;

        public InternetProtectionPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
        }

        /// <summary>
        /// No Connection Pane
        /// </summary>
        public WindowsElement noConnectionPane => base.GetElement(session, "Name", "No internet connection detected");

        /// <summary>
        /// Off Line Image
        /// </summary>
        public WindowsElement offLineImage => base.GetElement(session, "Name", "offline-icon");

        /// <summary>
        /// Get SurfEasy button
        /// </summary>
        public WindowsElement getSurfEasyButton => base.GetElement(session, "Name", "Get SurfEasy");
    }
}
