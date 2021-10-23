namespace LenovoVantageTest.Pages
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;

    public class DasheboardPage_NarrowWindow : BasePage
    {
        private WindowsDriver<WindowsElement> session;
        private WebDriverWait wait;
        private RemoteTouchScreen touchScreen;
        private Actions action;
        private TouchActions touchActions;

        public DasheboardPage_NarrowWindow dashBoardPage_NarrowWindow;

        public const string hanmbergeMenu = "Dashboard";

        public DasheboardPage_NarrowWindow(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
        }

        /// <summary>
        /// Max Window Button
        /// </summary>
        public WindowsElement maxWindowButton => base.GetElement(session, "AutomationId", "Maximize");

        /// <summary>
        /// hamburger Button
        /// </summary>
        public WindowsElement hamburgerButton => base.GetElement(session, "AutomationId", "menu-main-btn-navbar-toggler");

        /// <summary>
        /// Dashboard Device menu
        /// </summary>
        public WindowsElement dashboardMenu => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dashboard");

        /// <summary>
        /// Device menu
        /// </summary>
        public WindowsElement deviceMenu => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-toggle-device");

        /// <summary>
        /// My Device
        /// </summary>
        public WindowsElement deviceMenu_MyDevice => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-device-0");

        /// <summary>
        /// My Device Settings
        /// </summary>
        public WindowsElement deviceMenu_MyDeviceSettings => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-device-1");

        /// <summary>
        /// System Update
        /// </summary>
        public WindowsElement deviceMenu_SystemUpdate => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-device-2");

        /// <summary>
        /// Security Menu
        /// </summary>
        public WindowsElement securityMenu => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-toggle-security");

        /// <summary>
        /// My Security
        /// </summary>
        public WindowsElement securityMenu_MySecurity => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-security-0");

        /// <summary>
        /// Anti-virus 
        /// </summary>
        public WindowsElement securityMenu_AntiVirus => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-security-1");

        /// <summary>
        /// Anti-virus 
        /// </summary>
        public WindowsElement securityMenu_PasswordHealth => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-security-2");

        /// <summary>
        /// WiFi Security
        /// </summary>
        public WindowsElement securityMenu_WiFiSecurity => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-security-3");

        /// <summary>
        /// VPN Security
        /// </summary>
        public WindowsElement securityMenu_VPNSecurity => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-security-4");

        /// <summary>
        /// Support menu
        /// </summary>
        public WindowsElement supportMenu => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-support-0");

        /// <summary>
        /// Support menu
        /// </summary>
        public WindowsElement hardwareScanMenu => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-hardware-scan");


        /// <summary>
        /// menu L
        /// </summary>
        public WindowsElement navL => base.GetElement(session, "AutomationId", "navbarDropdown");
        /// <summary>
        /// User menu
        /// </summary>
        public WindowsElement userMenuText => base.GetElement(session, "AutomationId", "menu-main-text-hello-user");

        /// <summary>
        /// Lenovo Migration Assistant
        /// </summary>
        public WindowsElement userMenu_LenovoMigrationAssistant => base.GetElement(session, "AutomationId", "menu-main-lnk-open-lma");

        /// <summary>
        /// Preference Settings
        /// </summary>
        public WindowsElement userMenu_PreferenceSettings => base.GetElement(session, "AutomationId", "menu-main-lnk-open-preference");

        /// <summary>
        /// Given Feedback
        /// </summary>
        public WindowsElement userMenu_GivenFeedback => base.GetElement(session, "AutomationId", "menu-main-lnk-open-feedback");

        /// <summary>
        /// Unlock Exclusive
        /// </summary>
        public WindowsElement userMenu_UnlockExclusive => base.GetElement(session, "AutomationId", "menu-main-lnk-open-lenovoid-unlock");

        /// <summary>
        /// User menu list 4 SpeedBall 
        /// </summary>
        public WindowsElement SpeedBall => base.GetElement(session, "Name", "SpeedBall");

        /// <summary>
        /// PageTitle 
        /// </summary>
        public WindowsElement PageTitle => base.GetElement(session, "Name", "Vantage");

        /// <summary>
        /// Scroll the screen
        /// </summary>
        public override void ScrollScreen()
        {
            touchScreen = new RemoteTouchScreen(session);
            touchScreen.Scroll(0, -1000);
        }

        public void ScrollScreenByMouse()
        {
            action = new Actions(session);
            //action.MoveToElement(1672, 952).Perform();
            //const int offset = 1500;
            WindowsElement appNameTitle = session.FindElementByXPath("//*[contains(@x,'1672',@y,'952' )]");
            // Assert.IsNotNull(appNameTitle);
            // Point originalPosition = session.Manage().Window.Position;
            // Assert.IsNotNull(originalPosition);

            // Send mouse down, move, and up actions combination to perform a drag and drop 

            // action on the app title bar. These actions reposition Calculator window.

            //session.Mouse.MouseMove(appNameTitle.Coordinates);

            //session.Mouse.MouseDown(null); // Pass null as this command omit the given parameter

            //session.Mouse.MouseMove(appNameTitle.Coordinates, offset, offset);

            //session.Mouse.MouseUp(null); // Pass null as this command omit the given parameter

            // Thread.Sleep(TimeSpan.FromSeconds(1));
            // touchScreen.Down(0, -500);ScrollScreenByMouse
            // touchScreen = new RemoteTouchScreen(session);
            // touchScreen.Scroll(0, -1500);
        }

        public void ScrollScreenInNarrowWindow()
        {
            //WindowsElement ListMeue = session.FindElementByXPath("//*[contains(@x,'1672',@y,'952' )]");
            action = new Actions(session);
            //session.Mouse.MouseDown(0,-500);
            action.MoveToElement(deviceMenu).Perform();
            touchScreen = new RemoteTouchScreen(session);
            touchScreen.Scroll(500, -200);

            //touchActions = new TouchActions(session);
            //touchActions.Scroll(0, -200);
            // action.MoveByOffset(1716, 1509);
            // Thread.Sleep(2000);
        }

        public override void VerifyContentAreEqual(string expected, WindowsElement windowsElement)
        {
            Assert.AreEqual(expected, windowsElement.Text);
        }

        public override void VerifyHamburgerMenuNoExist()
        {
            Assert.IsFalse(IsPresent(hanmbergeMenu));
        }

        private bool IsPresent(string locator)
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
    }
}

