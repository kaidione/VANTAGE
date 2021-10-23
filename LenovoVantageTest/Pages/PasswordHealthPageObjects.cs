namespace LenovoVantageTest.Pages
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;

    public class PasswordHealthPage : BasePage
    {
        private WindowsDriver<WindowsElement> session;
        private WebDriverWait wait;
        private Actions action;

        public PasswordHealthPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
        }

        public string expect_BackLinkContent = "< BACK";

        public string expect_poweredByDashlane = "Powered By Dashlane";
        public string expect_privacyPolicyText = "Privacy Policy";
        public string TermsofServiceText = "Terms of Service";

        /// <summary>
        /// No internet connection pane, it occurs on no internet on PasswordHealthPage
        /// </summary>
        public WindowsElement noInternetConnectionPane_PasswordHealthPage => base.GetElement(session, "Name", "No internet connection detected");

        /// <summary>
        /// offline Icone show on antiVirus Page
        /// </summary>
        public WindowsElement offlineIcon_PasswordHealthPage => base.GetElement(session, "AutomationId", "sa-pm-modal-offline-icon");

        /// <summary>
        /// The Back Link
        /// </summary>
        public WindowsElement backLink_PasswordHealthPage => base.GetElement(session, "AutomationId", "sa-pm-btn-back");

        /// <summary>
        /// The learn More Link
        /// </summary>
        public WindowsElement learnMoreLink => base.GetElement(session, "AutomationId", "sa-pm-lnk-learnmore");

        /// <summary>
        /// Get Dashlane button
        /// </summary>
        public WindowsElement getDashLaneButton => base.GetElement(session, "AutomationId", "sa-pm-btn-getdashlane");

        /// <summary>
        /// Dashlane not installed status
        /// </summary>
        public WindowsElement dashLaneNotInstalledStatus => base.GetElement(session, "Name", "NOT INSTALLED");

        /// <summary>
        /// Dashlane intalling status
        /// </summary>
        public WindowsElement dashLaneInstallingStatus => base.GetElement(session, "Name", "INSTALLING");

        public WindowsElement passwordHealthInstalling => base.GetElement(session, "Name", "Password Health INSTALLING");

        public WindowsElement dashLaneIsInstalling => base.GetElement(session, "Name", "DASHLANE PASSWORD MANAGER INSTALLING");

        /// <summary>
        /// SA widget Password Health Status
        /// </summary>
        public WindowsElement saPasswordHealthStatus => base.GetElement(session, "AutomationId", "password-health-sa-widget-lnk-pm");

        /// <summary>
        /// No Connection Pane
        /// </summary>
        public WindowsElement noConnectionPane => base.GetElement(session, "Name", "No internet connection detected");

        /// <summary>
        /// Off Line Image
        /// </summary>
        public WindowsElement offLineImage => base.GetElement(session, "Name", "offline-icon");

        /// <summary>
        /// Security Tab
        /// </summary>
        public WindowsElement securityTab => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-toggle-security");

        /// <summary>
        /// Internet Protection Link
        /// </summary>
        public WindowsElement internetProtectionLink => base.GetElement(session, "Name", "Internet Protection");

        public WindowsElement passwordHealthHeaderTitle => base.GetElement(session, "AutomationId", "security-password-header-title");

        public WindowsElement dashlaneText => base.GetElement(session, "Name", "Dashlane");

        public WindowsElement antiVirusDisabled_widget => base.GetElement(session, "Name", "Anti-Virus DISABLED");

        public WindowsElement passwordHealthDisabled_widget => base.GetElement(session, "Name", "Password Health NOT INSTALLED");

        public WindowsElement wIFISecurityDisabled_widget => base.GetElement(session, "Name", "WiFi Security DISABLED");

        public WindowsElement vPNSecurityDisabled_widget => base.GetElement(session, "Name", "VPN Security NOT INSTALLED");

        public WindowsElement fingerprintNotEnabled_widget => base.GetElement(session, "Name", "Fingerprint NOT ENROLLED");

        public WindowsElement uacDisabled_widget => base.GetElement(session, "Name", "User Account Control DISENABLED");

        public WindowsElement antiVirusEnabled_widget => base.GetElement(session, "Name", "Anti-Virus ENABLED");

        public WindowsElement passwordHealthEnabled_widget => base.GetElement(session, "Name", "Password Health INSTALLED");

        public WindowsElement wIFISecurityEnabled_widget => base.GetElement(session, "Name", "WiFi Security ENABLED");

        public WindowsElement vPNSecurityEnabled_widget => base.GetElement(session, "Name", "VPN Security INSTALLED");

        public WindowsElement fingerprintEnabled_widget => base.GetElement(session, "Name", "Fingerprint ENROLLED");

        public WindowsElement uacEnabled_widget => base.GetElement(session, "Name", "User Account Control ENABLED");

        public WindowsElement antiVirusLink => base.GetElement(session, "AutomationId", "password-health-sa-widget-lnk-av");

        public WindowsElement pAsswordHealthLink => base.GetElement(session, "AutomationId", "password-health-sa-widget-lnk-pm");

        public WindowsElement wifisecurityLink => base.GetElement(session, "AutomationId", "password-health-sa-widget-lnk-ws");

        public WindowsElement vpnsecurityLink => base.GetElement(session, "AutomationId", "password-health-sa-widget-lnk-vpn");

        public WindowsElement fingerprintLink => base.GetElement(session, "AutomationId", "password-health-sa-widget-lnk-wh");

        public WindowsElement uacLink => base.GetElement(session, "AutomationId", "password-health-sa-widget-lnk-uac");

        public WindowsElement saWidgetTitle => base.GetElement(session, "Name", "Security Advisor");

        public WindowsElement saWidgetSubTitle => base.GetElement(session, "Name", "Check if your device is secured.");

        /// <summary>
        /// The content of Password Health page with Dashlane installed 
        /// </summary>
        public WindowsElement subcrptionheader_Installed => base.GetElement(session, "Name", "A safer digital life is waiting: Add passwords, enable Dark Web Monitoring and autofill personal and payment info.");

        public WindowsElement dashlaneInstalledstatus => base.GetElement(session, "Name", "DASHLANE PASSWORD MANAGER INSTALLED");

        public WindowsElement smallheader_Installed => base.GetElement(session, "Name", "about making the most of Dashlane");

        public WindowsElement learnmoreArticle => base.GetElement(session, "AutomationId", "article-title");

        public WindowsElement articleCloseButton => base.GetElement(session, "AutomationId", "article-close-button");

        public WindowsElement pmMiddleContentHeader_Installed => base.GetElement(session, "Name", "Getting started with Dashlane?");

        public WindowsElement pmMiddleContentDescription_Installed => base.GetElement(session, "Name", "Use Dashlane to stay safe online while saving time and frustration. For detailed instructions on how to get started,");

        public WindowsElement pmBottomContentHeader_Installed => base.GetElement(session, "Name", "Dashlane allows you to");

        public WindowsElement pmBottomContentItem1_Installed => base.GetElement(session, "Name", "Log in instantly every where for seamless Browsing-Sync across devices so you're never without access to important accounts");

        public WindowsElement pmBottomContentItem2_Installed => base.GetElement(session, "Name", "Monitor the dark web for your personal information");

        public WindowsElement pmBottomContentItem3_Installed => base.GetElement(session, "Name", "Stay safe on unsecured WiFi networks with built in VPN");

        public WindowsElement pmBottomContentItem4_Installed => base.GetElement(session, "Name", "Share passwords securely without revealing them");

        public WindowsElement checkOutTheGuideLink => base.GetElement(session, "Name", "check out this guide.");


        /// <summary>
        /// The content of Password Health page with Dashlane not installed 
        /// </summary>
        public WindowsElement subcrptionheader_NotInstalled => base.GetElement(session, "Name", "The safest, easiest way to save strong, complex passwords and log in instantly on every site.");

        public WindowsElement dashlaneNotInstalledstatus => base.GetElement(session, "Name", "DASHLANE PASSWORD MANAGER NOT INSTALLED");

        public WindowsElement smallheader1_NotInstalled => base.GetElement(session, "Name", "Start protecting your online accounts the simple way.");

        public WindowsElement pmMiddleContentHeader_NotInstalled => base.GetElement(session, "Name", "Dashlane: Never forget another password");

        public WindowsElement pmMiddleContentDescription_NotInstalled => base.GetElement(session, "Name", "Dashlane is a password manager and digital protection app that works with your browser. It automatically saves passwords and personal data, remembers it all for you, and stores everything securely. Dashlane also analyzes your account security and provides easy ways to improve your password health.");

        public WindowsElement pmBottomContentHeader_NotInstalled => base.GetElement(session, "Name", "Dashlane helps you");

        public WindowsElement pmBottomContentItem1_NotInstalled => base.GetElement(session, "Name", "Remember unlimited usernames and passwords.");

        public WindowsElement pmBottomContentItem2_NotInstalled => base.GetElement(session, "Name", "Log in instantly everywhere for seamless browsing");

        public WindowsElement pmBottomContentItem3_NotInstalled => base.GetElement(session, "Name", "Sync across devices so you're never without access to important accounts");

        public WindowsElement pmBottomContentItem4_NotInstalled => base.GetElement(session, "Name", "Improve your online protection with easy, actionable advice");

        public WindowsElement smallheader2_NotInstalled => base.GetElement(session, "Name", "Lenovo users enjoy an exclusive 50% off Dashlane Premium.");

        public WindowsElement smallheader3_NotInstalled => base.GetElement(session, "Name", "Offer available to new Dashlane users only.");

        /// <summary>
        /// Powered By Dashlane and the bottom links 
        /// </summary>
        public WindowsElement poweredByDashlane => base.GetElement(session, "Name", "Powered By Dashlane");

        public WindowsElement and_text => base.GetElement(session, "Name", "and");

        public WindowsElement privacyPolicyLink => base.GetElement(session, "Name", "Privacy Policy");

        public WindowsElement TermsofServiceLink => base.GetElement(session, "Name", "Terms of Service");



        public string avLink_aid = "password-health-sa-widget-lnk-av";

        public string pmLink_aid = "password-health-sa-widget-lnk-pm";

        public string wsLink_aid = "password-health-sa-widget-lnk-ws";

        public string vpnLink_aid = "password-health-sa-widget-lnk-vpn";

        public string fgLink_aid = "password-health-sa-widget-lnk-wh";

        public string uacLink_aid = "password-health-sa-widget-lnk-uac";


        public string antivirusDisabled_saWidget = "Anti-VirusDISABLED";

        public string passwordHealthNotInstalled_saWidget = "Password HealthNOT INSTALLED";

        public string passwordHealthInstalling_saWidget = "Password HealthINSTALLING";

        public string wifiSecurityDisabled_saWidget = "WiFi SecurityDISABLED";

        public string vpnNotInstalled_saWidget = "VPN SecurityNOT INSTALLED";

        public string fingerprintNotEnrolled_saWidget = "FingerprintNOT ENROLLED";

        public string uacDisabled_saWidget = "User Account Control DISABLED";

        public string antivirusEnabled_saWidget = "Anti-VirusENABLED";

        public string passwordHealthInstalled_saWidget = "Password HealthINSTALLED";

        public string wifiSecurityEnabled_saWidget = "WiFi SecurityENABLED";

        public string vpnInstalled_saWidget = "VPN SecurityINSTALLED";

        public string fingerprintEnrolled_saWidget = "FingerprintENROLLED";

        public string uacEnabled_saWidget = "User Account Control ENABLED";


        public string passwordHealth_HeaderTitle = "Password health";

        public string dashlane_SubTitle = "Dashlane";


        public string securityAdvisor_saWidget = "Security Advisor";

        public string checkifyourdeviceissecured = "Check if your device is secured.";

        public InternetProtectionPage GoToInternetProtectionPage()
        {
            action = new Actions(session);
            action.MoveToElement(securityTab).Perform();
            internetProtectionLink.Click();
            return new InternetProtectionPage(session);
        }

        public override void VerifyContentAreEqual(string expected, WindowsElement windowsElement)
        {
            Assert.AreEqual(expected, windowsElement.Text);
        }

        public void VerifyElementIsNotExist(string autoid, string way)
        {
            Assert.IsFalse(IsPresent(autoid, way));
        }

        public void VerifyElementIsExist(string autoid, string way)
        {
            Assert.IsTrue(IsPresent(autoid, way));
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

        private bool IsPresent(string locator, string way)
        {
            try
            {
                switch (way)
                {
                    case "AutomationId":
                        session.FindElementByAccessibilityId(locator);
                        break;

                }
                return true;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }

        public bool elementIsNoPresent(string locator, string way)
        {
            try
            {
                switch (way)
                {
                    case "AutomationId":
                        session.FindElementByAccessibilityId(locator);
                        break;
                    case "Name":
                        session.FindElementByName(locator);
                        break;

                }
                return true;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }
    }
}
