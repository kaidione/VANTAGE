namespace LenovoVantageTest.Pages
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;

    public class AntiVirusPage : BasePage
    {
        private WindowsDriver<WindowsElement> session;
        private WebDriverWait wait;
        private Actions action;

        public string expect_AntiVirusPageName = "Anti-virus";

        public WindowsElement securityAdvisorWidget => base.GetElement(session, "Name", "Security Advisor");

        public WindowsElement contentbox => base.GetElement(session, "AutomationId", "sa-av-modal-article_link");

        public WindowsElement mcAfeeTopTips => base.GetElement(session, "AutomationId", "article-title");

        /// <summary>
        /// No internet connection pane, it occurs on no internet
        /// </summary>
        public WindowsElement noInternetConnectionPane => base.GetElement(session, "Name", "No internet connection detected");

        /// <summary>
        /// offline Icone show on antiVirus Page
        /// </summary>
        public WindowsElement offlineIcon_antiVirusPage => base.GetElement(session, "AutomationId", "sa-av-modal-offline-icon");
        public string offlineIcon_antiVirusPage_autoid = "offlineIcon_antiVirusPage";

        /// <summary>
        /// Anti-Virus Page Title
        /// </summary>
        public WindowsElement antiVirusPageTitle => base.GetElement(session, "AutomationId", "security-antivirus-header-title");

        /// <summary>
        /// The Back Link
        /// </summary>
        /// <param name="session"></param>
        public WindowsElement backLink_AntiVirusPage => base.GetElement(session, "AutomationId", "sa-av-btn-back");

        /// <summary>
        /// No Connection Pane
        /// </summary>
        public WindowsElement noConnectionPane => base.GetElement(session, "Name", "No internet connection detected");

        /// <summary>
        /// Off Line Image
        /// </summary>
        public WindowsElement offLineImage => base.GetElement(session, "Name", "offline-icon");

        /// <summary>
        /// Buy now Button
        /// </summary>
        public WindowsElement buyNowButtonWithOutBackground => base.GetElement(session, "Name", "Buy Now");

        /// <summary>
        /// Password Health Link
        /// </summary>
        public WindowsElement passwordHealthLink => base.GetElement(session, "Name", "Password Health");

        /// <summary>
        /// Security Tab
        /// </summary>
        public WindowsElement securityTab => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-toggle-security");

        /// <summary>
        /// Your Threat Protection Report Section
        /// </summary>
        public WindowsElement yourThreatProtectionReport => base.GetElement(session, "Name", "Your Threat Protection Report");

        /// <summary>
        /// Files scanned
        /// </summary>
        public WindowsElement filesScanned => base.GetElement(session, "Name", "Files scanned");

        /// <summary>
        /// Viruses Eliminated
        /// </summary>
        public WindowsElement virusesEliminated => base.GetElement(session, "Name", "Viruses Eliminated");

        /// <summary>
        /// Bad connections blocked
        /// </summary>
        public WindowsElement badConnectionsBlocked => base.GetElement(session, "Name", "Bad connections blocked");

        /// <summary>
        /// Files Safely Shredded
        /// </summary>
        public WindowsElement filesSafelyShredded => base.GetElement(session, "Name", "Files Safely Shredded");

        /// <summary>
        /// McAfee Registration status is ENABLED on Antivirus page
        /// </summary>
        public WindowsElement mcAfeeRegistrationENABLED => base.GetElement(session, "Name", "McAfee Registration ENABLED");

        /// <summary>
        /// McAfee Registration status is DISABLED on Anti-virus page
        /// </summary>
        public WindowsElement mcAfeeRegistrationDISABLED => base.GetElement(session, "Name", "McAfee Registration DISABLED");

        /// <summary>
        /// Virus Scan Status is ENABLED on Antivirus page
        /// </summary>
        public WindowsElement virusScanStatusENABLED => base.GetElement(session, "Name", "Virus Scan ENABLED");

        /// <summary>
        /// Virus Scan Status is DISABLED on Antivirus page
        /// </summary>
        public WindowsElement virusScanStatusDISABLED => base.GetElement(session, "Name", "Virus Scan DISABLED");

        /// <summary>
        /// Personal Firewall status is ENABLED on Antivirus page
        /// </summary>
        public WindowsElement personalFirewallENABLED => base.GetElement(session, "Name", "Personal Firewall ENABLED");

        /// <summary>
        /// Personal Firewall status is DISABLED on Antivirus page
        /// </summary>
        public WindowsElement personalFirewallDISABLED => base.GetElement(session, "Name", "Personal Firewall DISABLED");

        /// <summary>
        /// McAfee Anti-Spam status is ENABLED on Antivirus page
        /// </summary>
        public WindowsElement mcAfeeAntiSpamENABLED => base.GetElement(session, "Name", "McAfee Anti-Spam ENABLED");

        /// <summary>
        /// McAfee Anti-Spam status is DISABLED on Antivirus page
        /// </summary>
        public WindowsElement mcAfeeAntiSpamDISABLED => base.GetElement(session, "Name", "McAfee Anti-Spam DISABLED");

        /// <summary>
        /// McAfee QuickClean status is ENABLED on Antivirus page, , McAfee Vulnerability Scanner ENABLED
        /// </summary>
        public WindowsElement mcAfeeQuickCleanENABLED => base.GetElement(session, "Name", "McAfee QuickClean ENABLED");

        /// <summary>
        /// McAfee QuickClean status is DISABLED on Antivirus page
        /// </summary>
        public WindowsElement mcAfeeQuickCleanDISABLED => base.GetElement(session, "Name", "McAfee QuickClean DISABLED");

        /// <summary>
        /// McAfee Vulnerability Scanner is ENABLED on Antivirus page
        /// </summary>
        public WindowsElement mcAfeeVulnerabilityScannerENABLED => base.GetElement(session, "Name", "McAfee Vulnerability Scanner ENABLED");


        /// <summary>
        /// McAfee Vulnerability Scanner status is DISABLED on Antivirus page
        /// </summary>
        public WindowsElement mcAfeeVulnerabilityScannerDISABLED => base.GetElement(session, "Name", "McAfee Vulnerability Scanner DISABLED");

        /// <summary>
        /// Launch McaFee Button
        /// </summary>
        public WindowsElement launchMcaFeeButton => base.GetElement(session, "AutomationId", "sa-av-button-launch-mcafee");

        /// <summary>
        /// Subscribe Now Link
        /// </summary>
        public WindowsElement subscribeNowLink => base.GetElement(session, "AutomationId", "sa-av-link-subscribe");

        /// <summary>
        /// Subscribe Now Text
        /// </summary>
        public WindowsElement subscribeNowText => base.GetElement(session, "Name", "Subscribe Now");

        public WindowsElement passwordHealthInstalling => base.GetElement(session, "Name", "Password Health INSTALLING");

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

        public WindowsElement antivirusLink => base.GetElement(session, "AutomationId", "anti-virus-sa-widget-lnk-av");

        public WindowsElement pAsswordHealthLink => base.GetElement(session, "AutomationId", "anti-virus-sa-widget-lnk-pm");

        public WindowsElement wifisecurityLink => base.GetElement(session, "AutomationId", "anti-virus-sa-widget-lnk-ws");

        public WindowsElement vpnsecurityLink => base.GetElement(session, "AutomationId", "anti-virus-sa-widget-lnk-vpn");

        public WindowsElement fingerprintLink => base.GetElement(session, "AutomationId", "anti-virus-sa-widget-lnk-wh");

        public WindowsElement uacLink => base.GetElement(session, "AutomationId", "anti-virus-sa-widget-lnk-uac");

        public WindowsElement saWidgetTitle => base.GetElement(session, "Name", "Security Advisor");

        public WindowsElement saWidgetSubTitle => base.GetElement(session, "Name", "Check if your device is secured.");

        public WindowsElement antiVirusDisabled => base.GetElement(session, "Name", "Virus protection DISABLED");

        public WindowsElement fireWallDisabled => base.GetElement(session, "Name", "Home network protection DISABLED");

        public WindowsElement antiVirusEnabled => base.GetElement(session, "Name", "Virus protection ENABLED");

        public WindowsElement fireWallEnabled => base.GetElement(session, "Name", "Home network protection ENABLED");

        public WindowsElement windowsDefenderText => base.GetElement(session, "Name", "//[@AutomationId='tutorial_done_btn']");

        public WindowsElement launchMcafeeLink => base.GetElement(session, "AutomationId", "sa-av-button-launch-mcafee");

        public WindowsElement subscribeLink => base.GetElement(session, "AutomationId", "sa-av-link-subscribe");

        public string WindowsHello_widget = "Windows Hello";

        public string avLink_aid = "anti-virus-sa-widget-lnk-av";

        public string pmLink_aid = "anti-virus-sa-widget-lnk-pm";

        public string wsLink_aid = "anti-virus-sa-widget-lnk-ws";

        public string vpnLink_aid = "anti-virus-sa-widget-lnk-vpn";

        public string fgLink_aid = "anti-virus-sa-widget-lnk-wh";

        public string uacLink_aid = "anti-virus-sa-widget-lnk-uac";

        public string AS_YourThreatProtectionReport = "Your Threat Protection Report";

        /// <summary>
        /// Third Part Anti-Virus component
        /// </summary>
        public WindowsElement enjoyHeaderTitle => base.GetElement(session, "AutomationId", "othersBetterOffer-collapse-card-title");

        /// <summary>
        /// Third Part Anti-Virus Enable status
        /// </summary>
        public WindowsElement virusEnableStatus => base.GetElement(session, "Name", "Virus Scan ENABLED");

        /// <summary>
        /// Expand Mcafee Section
        /// </summary>
        public WindowsElement expandMcaFeeButton => base.GetElement(session, "AutomationId", "othersBetterOffer-collapse-link");

        /// <summary>
        /// Expand Mcafee Section
        /// </summary>
        public WindowsElement collapseMcaFeeButton => base.GetElement(session, "AutomationId", "othersBetterOffer-collapse-link");

        /// <summary>
        /// Get Mcafee Button
        /// </summary>
        public WindowsElement getMcafeeButton => base.GetElement(session, "AutomationId", "sa-av-btn-getMcafee");

        /// <summary>
        /// McAFee Live Safe Protection Text
        /// </summary>
        public WindowsElement mcafeeLiveSafeProtection => base.GetElement(session, "Name", "McAfee LiveSafe Protection");

        /// <summary>
        /// SA widget Anti-Virus Status
        /// </summary>
        public WindowsElement saAntiVirusStatus => base.GetElement(session, "Name", "Anti-Virus PARTIALLY PROTECTED");

        /// <summary>
        /// To protect Your Device Text part 1: Why (for LS McAfee)
        /// </summary>
        public WindowsElement protectAllYourDevicesSectionTitle_1_LSMcAfee => base.GetElement(session, "Name", "Why");
        public string expected_protectAllYourDevicesSectionTitle_1_String_LSMcAfee = "Why";

        /// <summary>
        /// (for installed LS McAfee) To protect Your Device Text part 2 : Lenovo recommends McAfee Award-Winning Antivirus 
        /// </summary>
        public WindowsElement protectAllYourDevicesSectionTitle_2_LSMcAfee => base.GetElement(session, "Name", "Lenovo recommends McAfee");
        public string expected_protectAllYourDevicesSectionTitle_2_String_LSMcAfee = "Lenovo recommends McAfee";

        /// <summary>
        /// To protect Your Device Text
        /// </summary>
        public WindowsElement protectYourDeviceText => base.GetElement(session, "Name", "to protect all your devices");
        public string protectYourDeviceText_String = "to protect all your devices";

        /// <summary>
        ///(for installed LS McAfee) To protect Your Device Text part 1: Why Lenovo recommends
        /// </summary>
        public WindowsElement protectAllYourDevicesSectionTitle_1 => base.GetElement(session, "Name", "Why Lenovo recommends");
        public string protectAllYourDevicesSectionTitle_1_String = "Why Lenovo recommends";

        /// <summary>
        /// (for Not installed LS McAfee) To protect Your Device Text part 2 : McAfee 
        /// </summary>
        public WindowsElement protectAllYourDevicesSectionTitle_2 => base.GetElement(session, "Name", "McAfee");
        public string protectAllYourDevicesSectionTitle_2_String = "McAfee";

        /// <summary>
        /// (for installed LS McAfee) Award-Winning Antivirus title
        /// </summary>
        public WindowsElement awardWinningAntivirusTitle_LSMcAfee => base.GetElement(session, "Name", "Award-Winning Antivirus");

        public WindowsElement awardWinningantivirus => base.GetElement(session, "Name", "Award-winning antivirus");
        public string awardWinningantivirus_String = "Award-winning antivirus";

        /// <summary>
        /// (for installed LS McAfee) Award-Winning Antivirus text description
        /// </summary>
        public WindowsElement awardWinningAntivirusText_LSMcAfee => base.GetElement(session, "Name", "Prevent viruses, malware and ransomware from infecting your PC");
        public string awardWinningAntivirus_String = "Prevent viruses, malware and ransomware from infecting your PC";

        /// <summary>
        /// (for installed LS McAfee) Home network protection title
        /// </summary>
        public WindowsElement homeNetworkProtectionTitle_LSMcAfee => base.GetElement(session, "Name", "Home network protection");
        public string homeNetworkProtectionTitle_String = "Home network protection";


        /// <summary>
        /// (for installed LS McAfee) Home network protection text description
        /// </summary>
        public WindowsElement homeNetworkProtectionText_LSMcAfee => base.GetElement(session, "Name", "Secure your firewall and block hackers from accessing your home network");
        public string homeNetworkProtection_String = "Secure your firewall and block hackers from accessing your home network";


        /// <summary>
        /// (for installed LS McAfee) Online privacy title
        /// </summary>
        public WindowsElement onlinePrivacyTitle_LSMcAfee => base.GetElement(session, "Name", "Online privacy");
        public string onlinePrivacyTitle_String = "Online privacy";


        /// <summary>
        /// (for installed LS McAfee) Online privacy text description
        /// </summary>
        public WindowsElement onlinePrivacyText_LSMcAfee => base.GetElement(session, "Name", "Connect with bank-grade encryption to help secure all your online activities, even on public Wi-Fi or open networks");
        public string onlinePrivacyText_String = "Connect with bank-grade encryption to help secure all your online activities, even on public Wi-Fi or open networks";

        /// <summary>
        /// (for installed LS McAfee) Multi-device protection title
        /// </summary>
        public WindowsElement multiDeviceProtectionTitle_LSMcAfee => base.GetElement(session, "Name", "Multi-device protection");
        public string multiDeviceProtectionTitle_String = "Multi-device protection";


        /// <summary>
        /// (for installed LS McAfee) Multi-device protection text description
        /// </summary>
        public WindowsElement multiDeviceProtectionText_LSMcAfee => base.GetElement(session, "Name", "Protect every device you own – PCs, phones and tablets – perfect for families");
        public string multiDeviceProtection_String = "Protect every device you own – PCs, phones and tablets – perfect for families";

        /// <summary>
        /// (for installed LS McAfee) Password manager title
        /// </summary>
        public WindowsElement passwordManagerTitle_LSMcAfee => base.GetElement(session, "Name", "Password manager");
        public string passwordManagerTitle_String = "Password manager";


        /// <summary>
        /// (for installed LS McAfee) Password manager text description
        /// </summary>
        public WindowsElement passwordManagerText_LSMcAfee => base.GetElement(session, "Name", "Security store and manage all your online passwords in a single location");
        public string passwordManagerText_String = "Security store and manage all your online passwords in a single location";

        /// <summary>
        /// (for installed LS McAfee) Free, 24/7 expert technical support title
        /// </summary>
        public WindowsElement expertTechnicalSupportTitle_LSMcAfee => base.GetElement(session, "Name", "Free, 24/7 expert technical support");
        public string expertTechnicalSupportTitle_String = "Free, 24/7 expert technical support";

        /// <summary>
        /// (for installed LS McAfee) Free, 24/7 expert technical support description
        /// </summary>
        public WindowsElement expertTechnicalSupportText_LSMcAfee => base.GetElement(session, "Name", "Get around-the-clock assistance and peace of mind from our dedicated security team");
        public string expertTechnicalSupport_String = "Get around-the-clock assistance and peace of mind from our dedicated security team";

        /// <summary>
        /// Privacy Policy link
        /// </summary>
        public WindowsElement privacyPolicyLink => base.GetElement(session, "Name", "Privacy Policy");
        public string privacyPolicyLink_String = "Privacy Policy";

        /// <summary>
        /// Terms of Service link
        /// </summary>
        public WindowsElement termsOfServiceLink => base.GetElement(session, "Name", "Terms of Service");
        public string termsOfServiceLink_String = "Terms of Service";

        /// <summary>
        /// Anti-virus Expand content 
        /// </summary>
        public WindowsElement whyLenovorecommends => base.GetElement(session, "Name", "Why Lenovo recommends");

        public WindowsElement mcAfeeText => base.GetElement(session, "Name", "McAfee");

        public WindowsElement mcafeeLiveProtection => base.GetElement(session, "Name", "McAfee LiveSafe Protection");
        public string mcafeeLiveProtection_String = "McAfee LiveSafe Protection";

        public WindowsElement youAreProtectedBy => base.GetElement(session, "Name", "You are currently protected by Avira Antivirus. However, you could be better protected with McAfee LiveSafe");
        public string youAreProtectedBy_String = "You are currently protected by Avira Antivirus. However, you could be better protected with McAfee LiveSafe";

        public WindowsElement sheildYourPC => base.GetElement(session, "Name", "Shield your new Lenovo PC with tested, proven protection against online threats");
        public string sheildYourPC_String = "Shield your new Lenovo PC with tested, proven protection against online threats";

        public WindowsElement rockSolidPerformance => base.GetElement(session, "Name", "Rock-solid performance");
        public string rockSolidPerformance_String = "Rock-solid performance";

        public WindowsElement consistentPrecise => base.GetElement(session, "Name", "Consistent, precise, and reliable antivirus you can count on to help keep you safe");
        public string consistentPrecise_String = "Consistent, precise, and reliable antivirus you can count on to help keep you safe";

        public WindowsElement blazingFastSpeed => base.GetElement(session, "Name", "Blazing-fast speed");
        public string blazingFastSpeed_String = "Blazing-fast speed";

        public WindowsElement optimizedAntivirus => base.GetElement(session, "Name", "Optimized antivirus that won’t slow down or interrupt your Lenovo Vantage experience");
        public string optimizedAntivirus_String = "Optimized antivirus that won’t slow down or interrupt your Lenovo Vantage experience";

        public string getMcafeeButtonId = "sa-av-btn-getMcafee";


        public string antivirusDisabled_saWidget = "Anti-VirusDISABLED";

        public string antivirusPartiallyProtect_saWidget = "Anti-VirusPARTIALLY PROTECTED";

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


        public string antivirus_HeaderTitle = "Anti-virus";

        public string windowsDenfenderText = "Windows Defender Basic Protection";


        public string securityAdvisor_saWidget = "Security Advisor";

        public string checkifyourdeviceissecured = "Check if your device is secured.";


        public string expandString = "Enjoy a better offer here!expand";

        public string collapseString = "Enjoy a better offer here!collapse";

        public AntiVirusPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
        }

        public PasswordHealthPage GoToPasswordHealthPage()
        {
            action = new Actions(session);
            action.MoveToElement(securityTab).Perform();
            passwordHealthLink.Click();
            return new PasswordHealthPage(session);
        }

        public override void ScrollScreen()
        {
            touchScreen = new RemoteTouchScreen(session);
            touchScreen.Scroll(0, -100);
        }

        public override void VerifyContentAreEqual(string expected, WindowsElement windowsElement)
        {
            Assert.AreEqual(expected, windowsElement.Text);
        }

        public override void VerifyWindowsHelloIsNotExist()
        {
            Assert.IsFalse(IsPresent(WindowsHello_widget));
        }

        public void VerifyElementIsNotExist(string autoid, string way)
        {
            Assert.IsFalse(IsPresent(autoid, way));
        }

        public void VerifyElementIsExist(string autoid, string way)
        {
            Assert.IsTrue(IsPresent(autoid, way));
        }

        public override void VerifyTheYourThreatProtectionReportIsNoExist()
        {
            Assert.IsFalse(IsPresent(AS_YourThreatProtectionReport));
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
