namespace LenovoVantageTest.Pages
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;

    public class VPNPage : BasePage
    {
        private WindowsDriver<WindowsElement> session;
        private WebDriverWait wait;
        private Actions action;

        public VPNPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
        }

        public string expectVPNPageName = "VPN security";

        /// <summary>
        /// No internet connection pane, it occurs on no internet on VPN page
        /// </summary>
        public WindowsElement noInternetConnectionPane_VPNPage => base.GetElement(session, "Name", "No internet connection detected");

        /// <summary>
        /// offline Icone show on VPN Page
        /// </summary>
        public WindowsElement offlineIcon_VPNPage => base.GetElement(session, "AutomationId", "sa-vpn-modal-offline-icon");

        /// <summary>
        /// VPN Security Page Title
        /// </summary>
        public WindowsElement vpnSecurityTitle => base.GetElement(session, "AutomationId", "security-internet-header-title");

        /// <summary>
        /// Back Link on VPN Page
        /// </summary>
        public WindowsElement backLink => base.GetElement(session, "Name", "BACK");

        /// <summary>
        /// Back Link on VPN Page
        /// </summary>
        public WindowsElement backLinkOnVPNPage => base.GetElement(session, "AutomationId", "sa-vpn-btn-back");

        /// <summary>
        /// Surf Easy VPN label
        /// </summary>
        public WindowsElement surfEasyVPNLabel => base.GetElement(session, "Name", "SURFEASY VPN NOT INSTALLED");

        /// <summary>
        /// surfEasyVPN Status Not Install
        /// </summary>
        public WindowsElement surfEasyVPNStatusNotInstall => base.GetElement(session, "Name", "SURFEASY VPN NOT INSTALLED");

        /// <summary>
        /// surfEasyVPN Status Install
        /// </summary>
        public WindowsElement surfEasyVPNStatusInstall => base.GetElement(session, "Name", "SURFEASY VPN INSTALLED");

        /// <summary>
        /// surfEasyVPN Status Installing
        /// </summary>
        public WindowsElement surfEasyVPNStatusInstalling => base.GetElement(session, "Name", "SURFEASY VPN INSTALLING");

        /// <summary>
        /// surfEasyVPN Status Installing
        /// </summary>
        public WindowsElement surfEasyVPNStatusNotInstalling => base.GetElement(session, "Name", "INSTALLING");

        public WindowsElement Installing_ele => base.GetElement(session, "Name", "INSTALLING");

        /// <summary>
        /// surfEasyVPN Status Installing
        /// </summary>
        public WindowsElement refreshIcon => base.GetElement(session, "Name", "Refresh");

        /// <summary>
        /// Get Surf Easy Button
        /// </summary>
        public WindowsElement getSurfEasyButton => base.GetElement(session, "AutomationId", "sa-vpn-btn-getsurfeasy");

        /// <summary>
        /// Open Surf Easy Button
        /// </summary>
        public WindowsElement openSurfEasyButton => base.GetElement(session, "AutomationId", "sa-vpn-btn-opensurfeasy");

        /// <summary>
        /// SA widget
        /// </summary>
        public WindowsElement securityAdvisorWidget => base.GetElement(session, "Name", "Security Advisor");

        public WindowsElement vPNSecurityHeaderTitle => base.GetElement(session, "AutomationId", "security-internet-header-title");

        public WindowsElement howtouseSurfEasyVPN => base.GetElement(session, "XPath", "//Text[@Name='How to use SurfEasy VPN']");

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

        public WindowsElement antivirusLink => base.GetElement(session, "AutomationId", "vpn-security-sa-widget-lnk-av");

        public WindowsElement pAsswordHealthLink => base.GetElement(session, "AutomationId", "vpn-security-sa-widget-lnk-pm");

        public WindowsElement wIFISecurityLink => base.GetElement(session, "AutomationId", "vpn-security-sa-widget-lnk-ws");

        public WindowsElement vpnsecurityLink => base.GetElement(session, "AutomationId", "vpn-security-sa-widget-lnk-vpn");

        public WindowsElement fingerprintLink => base.GetElement(session, "AutomationId", "vpn-security-sa-widget-lnk-wh");

        public WindowsElement uacLink => base.GetElement(session, "AutomationId", "vpn-security-sa-widget-lnk-uac");

        public WindowsElement saWidgetTitle => base.GetElement(session, "Name", "Security Advisor");

        public WindowsElement saWidgetSubTitle => base.GetElement(session, "Name", "Check if your device is secured.");


        public string avLink_aid = "vpn-security-sa-widget-lnk-av";

        public string pmLink_aid = "vpn-security-sa-widget-lnk-pm";

        public string wsLink_aid = "vpn-security-sa-widget-lnk-ws";

        public string vpnLink_aid = "vpn-security-sa-widget-lnk-vpn";

        public string fgLink_aid = "vpn-security-sa-widget-lnk-wh";

        public string uacLink_aid = "vpn-security-sa-widget-lnk-uac";

        /// <summary>
        /// Powered By Surfeasy and the bottom links 
        /// </summary>
        public WindowsElement poweredBySurfeasy => base.GetElement(session, "Name", "Powered By SurfEasy");

        public WindowsElement and_text => base.GetElement(session, "Name", "and");

        public WindowsElement privacyPolicyLink => base.GetElement(session, "Name", "Privacy Policy");

        public WindowsElement TermsofServiceLink => base.GetElement(session, "Name", "Terms of Service");

        /// <summary>
        /// VPN page subscription and small header
        /// </summary>
        public WindowsElement vpnpagesubscription => base.GetElement(session, "Name", "SurfEasy VPN encrypts the information you send and receive so you can safely and privately use your PC, Mac®, smartphone or tablet on any Internet connection without worry.");

        public WindowsElement vpnpagesmallheader => base.GetElement(session, "Name", "Help keep your online activity secure and private with SurfEasy VPN.");

        public WindowsElement surfEasyVPNText => base.GetElement(session, "Name", "SurfEasy VPN");

        /// <summary>
        /// VPN page content---SurfEasy is not installed
        /// </summary>
        public WindowsElement vpnMiddleContentHeader_NotInstalled => base.GetElement(session, "Name", "Why use a Virtual Private Network (VPN)?");

        public WindowsElement vpnMiddleContentDescription_NotInstalled => base.GetElement(session, "Name", "Using Wi-Fi hotspots, like those at coffee shops or airports, could expose your sensitive information to cybercriminals. SurfEasy VPN is a no-log VPN that encrypts your personal information and doesn’t track or store your online activity or location.");

        public WindowsElement vpnBottomContentHeader_NotInstalled => base.GetElement(session, "Name", "Start using SurfEasy Today");

        public WindowsElement vpnBottomContentItem1_NotInstalled => base.GetElement(session, "Name", "Help ensure the data you send and receive is secure and private with bank-grade encryption.");

        public WindowsElement vpnBottomContentItem2_NotInstalled => base.GetElement(session, "Name", "Help prevent companies from tracking your online activities or location.");

        public WindowsElement vpnBottomContentItem3_NotInstalled => base.GetElement(session, "Name", "Free and premium offerings provide multiple options to fit your needs and budget.");

        /// <summary>
        /// VPN page content---SurfEasy is installed
        /// </summary>
        public WindowsElement vpnMiddleContentHeader_Installed => base.GetElement(session, "Name", "How to use SurfEasy VPN");

        public WindowsElement vpnMiddleContentDescription_Installed => base.GetElement(session, "Name", "Protect your privacy and turn on SurfEasy VPN when accessing a public Wi-Fi hotspot. With a Lenovo Starter VPN Plan, you can complete Reward activities to earn more data protection bandwidth. Upgrade to protect up to 5 smartphones, tablets and computers with unlimited bandwidth.");

        public WindowsElement vpnBottomContentHeader_Installed => base.GetElement(session, "Name", "Turn on SurfEasy VPN:");

        //public WindowsElement vpnBottomContentItem1_Installed => base.GetElement(session, "Name", "Click on the "Open SurfEasy" button above to launch SurfEasy VPN.");

        public WindowsElement vpnBottomContentItem2_Installed => base.GetElement(session, "Name", "2. Turn on the VPN and wait a brief moment for confirmation of a secure connection.");

        public WindowsElement vpnBottomContentItem3_Installed => base.GetElement(session, "Name", "3. Change your region or location if desired, and enjoy secure, private networking.");


        public WindowsElement passwordHealthInstalling => base.GetElement(session, "Name", "Password Health INSTALLING");

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


        public string vpnSecurity_HeaderTitle = "VPN security";

        public string vpnSecurity_SubTitle = "SurfEasy VPN";

        public string howtouseVPN = "How to use SurfEasy VPN";


        public string securityAdvisor_saWidget = "Security Advisor";

        public string checkifyourdeviceissecured = "Check if your device is secured.";


        public string getsurfeasy = "Get SurfEasy";

        public string opensureasy = "Open SurfEasy";

        public string surfeasynotinstalled = "SURFEASY VPN NOT INSTALLED";

        public string surfeasyinstalled = "SURFEASY VPN INSTALLED";

        public string Installing_String = "INSTALLING";

        public string surfEasyVPNStatusInstalling_String = "SURFEASY VPN INSTALLING";

        public string vpnInstallingString_SAWidget = "VPN SecurityINSTALLING";

        public string poweredbysurfEasy = "Powered By SurfEasy";

        public string vpnpagesubscriptionString = "SurfEasy VPN encrypts the information you send and receive so you can safely and privately use your PC, Mac®, smartphone or tablet on any Internet connection without worry.";

        public string vpnpagesmallheaderString = "Help keep your online activity secure and private with SurfEasy VPN.";

        public string vpnMiddleContentHeaderString_NotInstalled = "Why use a Virtual Private Network (VPN)?";

        public string vpnMiddleContentDescriptionString_NotInstalled = "Using Wi-Fi hotspots, like those at coffee shops or airports, could expose your sensitive information to cybercriminals. SurfEasy VPN is a no-log VPN that encrypts your personal information and doesn’t track or store your online activity or location.";

        public string vpnBottomContentHeaderString_NotInstalled = "Start using SurfEasy Today";

        public string vpnBottomContentItem1String_NotInstalled = "Help ensure the data you send and receive is secure and private with bank-grade encryption.";

        public string vpnBottomContentItem2String_NotInstalled = "Help prevent companies from tracking your online activities or location.";

        public string vpnBottomContentItem3String_NotInstalled = "Free and premium offerings provide multiple options to fit your needs and budget.";

        public string vpnMiddleContentDescriptionString_Installed = "Protect your privacy and turn on SurfEasy VPN when accessing a public Wi-Fi hotspot. With a Lenovo Starter VPN Plan, you can complete Reward activities to earn more data protection bandwidth. Upgrade to protect up to 5 smartphones, tablets and computers with unlimited bandwidth.";

        public string vpnBottomContentHeaderString_Installed = "Turn on SurfEasy VPN:";

        public string vpnBottomContentItem2String_Installed = "2. Turn on the VPN and wait a brief moment for confirmation of a secure connection.";

        public string vpnBottomContentItem3String_Installed = "3. Change your region or location if desired, and enjoy secure, private networking.";


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
