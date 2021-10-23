namespace LenovoVantageTest.Pages
{
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;

    public class WindowsSettingsPage : BasePage
    {
        private WindowsDriver<WindowsElement> session;
        private WebDriverWait wait;
        private Actions action;

        public WindowsSettingsPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
        }

        public WindowsElement signinoptions => base.GetElement(session, "Name", "Sign-in options");

        public WindowsElement uacsub => base.GetElement(session, "Name", "Choose when to be notified about changes to your computer");

        public WindowsElement closeSettingsButton => base.GetElement(session, "Name", "Close Settings");
    }
}
