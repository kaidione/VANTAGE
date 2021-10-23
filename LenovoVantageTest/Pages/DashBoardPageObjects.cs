namespace LenovoVantageTest.Pages
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Collections.Generic;
    public class DashBoardPage : SettingsBase
    {
        private WindowsDriver<WindowsElement> session;
        private WebDriverWait wait;
        private Actions action;
        public RemoteTouchScreen touchScreen;
        public const string saWidget = "Security Advisor";
        public const string noSuchKey_Error = "no such key";
        public const string armLogoTitle = "Energy Star";

        public DashBoardPage dashBoardPage;


        public DashBoardPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
            base.session = session;
        }

        public WindowsElement deviceMenu_MyDeviceSettings => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-device-1");
        public WindowsElement deviceMenu_SmartAssist => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Navbar.smartAssist"));

        public string findSecurityListItemXPath = "//*[@AutomationId='menu-main-nav-lnk-dropdown-toggle-security']/parent::*/*";

        public string findDeviceListItemXPath = "//*[@AutomationId='menu-main-nav-lnk-dropdown-toggle-device']/parent::*/*";

        public string findUserListItemXPath = "//*[@AutomationId='navbarDropdown']/parent::*/*";

        public string expect_SUWidgetTitle = "System Update";

        public WindowsElement navlnkdashboard => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dashboard");
        public WindowsElement LImage => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Dashboard.LImage"));
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
        public WindowsElement wifiSecurityLink => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-security-3");

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
        public WindowsElement deviceTab => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-toggle-devicedevice");

        /// <summary>
        /// Device Tab with new method
        /// </summary>
        public WindowsElement deviceTabNew => base.GetElementNew(session, "AutomationId", "Navbar", "device");

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

        /// <summary>
        /// Welcome Header
        /// </summary>
        public WindowsElement welcomeHeader => base.GetElement(session, "AutomationId", "dashboard-header-title");

        /// <summary>
        /// Hero Banner 
        /// </summary>
        public WindowsElement heroBanner => base.GetElement(session, "AutomationId", "dashboard-lnk-hero-banner");
        public WindowsElement heroBanner_1 => base.GetElement(session, "AutomationId", "dashboard-lnk-hero-banner-0");
        public WindowsElement heroBanner_Slide_1 => base.GetElement(session, "AutomationId", "ngb-slide-0");

        /// <summary>
        /// 4*3 Banner
        /// </summary>
        public WindowsElement contentBoxB => base.GetElement(session, "AutomationId", "dashboard-lnk-content-b_doc_link");
        public WindowsElement contentBoxBTextBox => base.GetElement(session, "AutomationId", "dashboard-card-b");
        public WindowsElement contentBoxB_Title => base.GetElement(session, "AutomationId", "dashboard-lnk-content-b-title");
        public WindowsElement contentBoxB_Description => base.GetElement(session, "AutomationId", "dashboard-lnk-content-b-caption");
        public WindowsElement articleDialog => base.GetElement(session, "AutomationId", "article-dialog");

        /// <summary>
        /// 4*3 Banner
        /// </summary>
        public WindowsElement contentBoxC => base.GetElement(session, "AutomationId", "dashboard-lnk-content-c_doc_link");
        /// <summary>
        /// 8*3 Banner
        /// </summary>
        public WindowsElement contentBoxD => base.GetElement(session, "AutomationId", "dashboard-lnk-content-d_article");

        /// <summary>
        /// 4*4 Banner
        /// </summary>
        public WindowsElement contentBoxE => base.GetElement(session, "AutomationId", "dashboard-lnk-content-e_card_article");

        /// <summary>
        /// 4*4 Banner 
        /// </summary>
        public WindowsElement contentBoxF => base.GetElement(session, "AutomationId", "dashboard-lnk-content-f_card_article");

        /// <summary>
        /// Article Title
        /// </summary>
        public WindowsElement articleTitle => base.GetElement(session, "AutomationId", "article-title");

        /// <summary>
        /// article close button
        /// </summary>
        public WindowsElement articleCloseButton => base.GetElement(session, "AutomationId", "article-close-button");//

        public WindowsElement positionA => base.GetElement(session, "AutomationId", "dashboard-lnk-hero-banner-0");

        // public WindowsElement positionB => base.GetElement(session, "AutomationId", "dashboard-lnk-content-b_doc_link");
        //public WindowsElement positionC => base.GetElement(session, "AutomationId", "dashboard-lnk-content-c_doc_link");
        //public WindowsElement positionD => base.GetElement(session, "AutomationId", "dashboard-lnk-content-d_article");
        //public WindowsElement positionE => base.GetElement(session, "AutomationId", "dashboard-lnk-content-e_card_article");
        //public WindowsElement positionF => base.GetElement(session, "AutomationId", "dashboard-lnk-content-f_card_article");
        public WindowsElement disconnectNotice => base.GetElement(session, "Name", "No internet connection detected");
        public WindowsElement systemStatusDescription => base.GetElement(session, "AutomationId", "dashboard-ss-description");
        public WindowsElement memoryStatus => base.GetElement(session, "AutomationId", "dashboard-ss-memory");
        public WindowsElement diskStatus => base.GetElement(session, "AutomationId", "dashboard-ss-disk");
        public WindowsElement warrantyStatus => base.GetElement(session, "AutomationId", "dashboard-ss-warranty");
        public WindowsElement systemUpdateStatus => base.GetElement(session, "AutomationId", "dashboard-ss-systemupdate");
        public WindowsElement microphoneSetOff => base.GetElement(session, "AutomationId", "qs-microphone-switch-off-state");
        public WindowsElement microphoneSetOn => base.GetElement(session, "AutomationId", "qs-microphone-switch-on-state");
        public WindowsElement cameraSetOn => base.GetElement(session, "AutomationId", "qs-camera-switch-on-state");
        public bool cameraSetOnIsPresent => IsPresent(session, "qs-camera-switch-on-state");
        public WindowsElement cameraSetOff => base.GetElement(session, "AutomationId", "qs-camera-switch-off-state");
        public bool cameraSetOffIsPresent => IsPresent(session, "qs-camera-switch-off-state");


        /// <summary>
        /// Arm energy star logo
        /// </summary>
        public WindowsElement armEnergyStarLogo => base.GetElement(session, "AutomationId", "dashboard-energyStar-description");

        public string wifiSecurityAutoId = "menu-main-nav-lnk-dropdown-menu-security-3";

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

        public override void VerifySAWidgetNotExist()
        {
            Assert.IsFalse(IsSAPresent(saWidget));
        }


        public override void VerifyErrorIsNoExist()
        {
            Assert.IsFalse(IsSAPresent(noSuchKey_Error));
        }

        public void VerifyElementIsNoExistByName(String name)
        {
            Assert.IsFalse(IsNotPresent(name));
        }


        public void VerifyPositionAIsNotDefault(String name)
        {

        }

        public override void ScrollScreen()
        {
            touchScreen = new RemoteTouchScreen(session);
            touchScreen.Scroll(0, -500);
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

        private bool IsNotPresent(string locator)
        {
            Boolean result = true;
            try
            {
                session.FindElementByName(locator);
                result = false;
            }
            catch (WebDriverException)
            {
                Console.WriteLine("The Element can be found");
            }
            return result;
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

        public bool IsAutoIDPresent(string autoid)
        {
            try
            {
                //base.GetElement(session, "AutomationId", autoid);
                session.FindElementByAccessibilityId(autoid);
                return true;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }

        public bool IsAutoIDNoPresent(string autoid)
        {
            try
            {
                //base.GetElement(session, "AutomationId", autoid);
                session.FindElementByAccessibilityId(autoid);
                return false;
            }
            catch (WebDriverException)
            {
                return true;
            }
        }

        public override void VerifyArmLogoNotExist()
        {
            Assert.IsFalse(IsPresent(armLogoTitle));
        }
    }
}
