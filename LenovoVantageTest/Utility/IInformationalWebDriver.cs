namespace LenovoVantageTest.Utility
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;

    public interface IInformationalWebDriver
    {
        /// <summary>
        /// The WebDriver
        /// </summary>
        IWebDriver WinAppDriver
        {
            get;
        }

        /// <summary>
        /// Windows App Session
        /// </summary>
        WindowsDriver<WindowsElement> Session
        {
            get;
        }
    }
}
