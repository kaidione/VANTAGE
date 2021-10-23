namespace LenovoVantageTest.Pages
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;
    using System.Collections.Generic;

    public class SecurityPage : BasePage
    {
        private WindowsDriver<WindowsElement> session;
        private WebDriverWait wait;
        private RemoteTouchScreen touchScreen;
        public const string vPNSecurity = "Virtual Private Network (VPN) Security";
        public const string uAC = "User Account Control (UAC)";
        public const string windowsActivation = "Windows Activation";
        public const string wiFiSecurity = "WiFi Security";
        public const string fingerPrint = "Fingerprint Reader";

        public const string gOTOPASSWORDHEALTHButtonName = "GO TO PASSWORD HEALTH";
        public const string goToWifiSecurityButtonName = "GO TO WIFI SECURITY";
        public const string gOToVPNButtonName = "GO TO VPN SECURITY";

        public const string noInternetConnectionPaneName = "No internet connection detected";

        public string expect_IntermediateSecurityLevel = "INTERMEDIATE";
        public string expect_IntermediateProtectionTitle = "Intermediate protection";
        public string expect_intermediateProtectionDescription = "Good job! You are only one step away from reaching the advanced protection level. Try encrypting your data and monitoring your network security breaches to reach the next level.";


        public string expect_antiVirusText = "Anti-Virus";
        public string expect_firewallText = "Firewall";
        public string expect_antiVirusTextDescription = "Use an Anti-virus software to prevent, detect and remove malware for your devices.";

        public string expect_fireWallTextDescription = "Firewall establishes a barrier between a trusted internal network and untrusted external network, which monitors and controls incoming and outgoing network traffic based on predetermined security rules.";

        public SecurityPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
        }

        public string noPPath = "//Text[@Name='No protection']";

        public string enabled = "//Text[@Name='ENABLED']";

        public string disabled = "//Text[@Name='DISABLED']";

        public WindowsElement noProtectionDescription => base.GetElement(session, "XPath", "//Text[@Name='Your device has no security protection, so we enable Windows Defender for you as a minimum protection. To protect your device from incoming threats, try installing anti-virus software.']");

        public WindowsElement basicText => base.GetElement(session, "XPath", "//Text[@Name='BASIC']");

        public WindowsElement basicProtection => session.FindElementByXPath("//Text[@Name='Basic protection']");

        public WindowsElement basicProtectionDescription => session.FindElementByXPath("//Text[@Name='Your device has only basic security protection enabled. For better protection, try enabling UAC notifications and using a password manager.']");

        /// <summary>
        /// Security Level title
        /// </summary>
        public WindowsElement intermediateSecurityLevel => base.GetElement(session, "Name", "INTERMEDIATE");

        /// <summary>
        /// Intermediate Protection text title
        /// </summary>
        public WindowsElement intermediateProtectionTitle => base.GetElement(session, "Name", "Intermediate protection");

        /// <summary>
        /// Intermediate Protection text description
        /// </summary>
        public WindowsElement intermediateProtectionDescription => base.GetElement(session, "Name", "Good job! You are only one step away from reaching the advanced protection level. Try encrypting your data and monitoring your network security breaches to reach the next level.");

        /// <summary>
        /// Security Level title
        /// </summary>
        public WindowsElement advancedSecurityLevel => base.GetElement(session, "Name", "ADVANCED");

        /// <summary>
        /// Advanced Protection text title
        /// </summary>
        public WindowsElement advancedProtection => base.GetElement(session, "Name", "Advanced protection");

        /// <summary>
        /// Advanced Protection text description
        /// </summary>
        public WindowsElement advancedProtectionDescription => base.GetElement(session, "Name", "Congratulations! Your device has basic, intermediate and advanced security protection enabled, great job!");

        public WindowsElement antiVirusHeaderTitle => session.FindElementByXPath("/Window[@Name='Lenovo Vantage']//Text[@AutomationId='security-antivirus-header-title']");

        public WindowsElement windowsDefenderBasicProtectionText => session.FindElementByXPath("/Window[@Name='Lenovo Vantage']//Text[@Name='Windows Defender Basic Protection']");

        /// <summary>
        /// Security Title
        /// </summary>
        public WindowsElement securityTitle => base.GetElement(session, "AutomationId", "security-header-title");

        /// <summary>
        /// The Back link
        /// </summary>
        public WindowsElement backLink => base.GetElement(session, "AutomationId", "sa-ov-btn-back");

        /// <summary>
        /// The security 101 button
        /// </summary>
        public WindowsElement securityoneooneButton => base.GetElement(session, "Name", "SECURITY ADVISOR 101");

        /// <summary>
        /// Basic Security Tab
        /// </summary>
        public WindowsElement basicSecurityTab => base.GetElement(session, "Name", "BASIC SECURITY");

        /// <summary>
        /// Advance Security Tab
        /// </summary>
        public WindowsElement advancedSecurityTab => base.GetElement(session, "Name", "ADVANCED SECURITY");

        /// <summary>
        /// go to Wifi Security Button
        /// </summary>
        public WindowsElement goToWifiSecurityButton => base.GetElement(session, "AutomationId", "sa-ov-link-wifiSecurity");
        public WindowsElement WifiSecurityCheckbox => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.WifiSecurity.WiFiSecurityToggle"));
        /// <summary>
        /// Anti-Virus Text
        /// </summary>
        /// <param name="expected"></param>
        public WindowsElement antivirusText => session.FindElementByName("Anti-Virus");

        /// <summary>
        /// Anti-Virus ENABLED
        /// </summary>
        public WindowsElement antiVirusEnabled => base.GetElement(session, "AutomationId", "anti-virus-sa-widget-lnk-av");

        /// <summary>
        /// Firewall ENABLED
        /// </summary>
        public WindowsElement fireWallEnabled => base.GetElement(session, "Name", "Personal Firewall ENABLED");

        /// <summary>
        /// ENABLED status on security 
        /// </summary>
        public WindowsElement enabledStatus => base.GetElement(session, "Name", "ENABLED");

        /// <summary>
        /// DISABLED status on security 
        /// </summary>
        public WindowsElement disabledStatus => base.GetElement(session, "Name", "DISABLED");

        /// <summary>
        /// Anti Virus ENABLED Status : will update to use AutomationId onece it ready
        /// </summary>
        public WindowsElement antiVirusENABLEDdStatus => base.GetElement(session, "Name", "ENABLED");

        /// <summary>
        /// Anti Virus Disabled Status: will update to use AutomationId onece it ready
        /// </summary>
        public WindowsElement AntiVirusDisabledStatus => base.GetElement(session, "Name", "DISABLED");

        /// <summary>
        /// FireWall ENABLED Status: will update to use AutomationId onece it ready
        /// </summary>
        public WindowsElement fireWallENABLEDStatus => base.GetElement(session, "Name", "ENABLED");

        /// <summary>
        /// FireWall Disabled Status: will update to use AutomationId onece it ready
        /// </summary>
        public WindowsElement fireWallDisabledStatus => base.GetElement(session, "Name", "DISABLED");

        /// <summary>
        /// Windows Activation ENABLED Status: will update to use AutomationId onece it ready
        /// </summary>
        public WindowsElement windowsActivationENABLEDStatus => base.GetElement(session, "Name", "ENABLED");

        /// <summary>
        /// Windows Activation Disabled Status: will update to use AutomationId onece it ready
        /// </summary>
        public WindowsElement windowsActivationDisabledStatus => base.GetElement(session, "Name", "DISABLED");

        /// <summary>
        /// WiFi Security Enabled Status: will update to use AutomationId onece it ready
        /// </summary>
        public WindowsElement wiFiSecurityEnabledStatus => base.GetElement(session, "Name", "ENABLED");

        /// <summary>
        /// VPN INSTALLED Status: will update to use AutomationId onece it ready
        /// </summary>
        public WindowsElement vPNINSTALLEDStatus => base.GetElement(session, "Name", "INSTALLED");

        /// <summary>
        /// UAC DISABLED status on security:will update to use AutomationId onece it ready
        /// </summary>
        public WindowsElement uACdisabledStatus => base.GetElement(session, "Name", "DISABLED");

        /// <summary>
        /// WiFi security DISABLED status on security:will update to use AutomationId onece it ready
        /// </summary>
        public WindowsElement wiFiSecurityStatus => base.GetElement(session, "Name", "DISABLED");

        /// <summary>
        /// INSTALLED status on security 
        /// </summary>
        public WindowsElement installedStatus => base.GetElement(session, "Name", "INSTALLED");

        /// <summary>
        /// ENROLLED status on security 
        /// </summary>
        public WindowsElement enrolledStatus => base.GetElement(session, "Name", "ENROLLED");

        /// <summary>
        /// Go To anti-virus text description
        /// </summary>
        public WindowsElement antiVirusTextDescription => base.GetElement(session, "Name", "Use an Anti-virus software to prevent, detect and remove malware for your devices.");

        /// <summary>
        /// Go To FireWall text description
        /// </summary>
        public WindowsElement fireWallTextDescription => base.GetElement(session, "Name", "Firewall establishes a barrier between a trusted internal network and untrusted external network, which monitors and controls incoming and outgoing network traffic based on predetermined security rules.");

        /// <summary>
        /// Go To Windows Activation text
        /// </summary>
        public WindowsElement windowsActivationText => base.GetElement(session, "Name", "Windows Activation");


        /// <summary>
        /// Go To Windows Activation text description
        /// </summary>
        public WindowsElement windowsActivationTextDescription => base.GetElement(session, "Name", "Use a genuine copy of Windows can put you at lower risk for security threats.");

        /// <summary>
        /// Go To anti-virus button
        /// </summary>
        public WindowsElement goToAntiVirusButton => base.GetElement(session, "AutomationId", "sa-ov-link-antivirus");

        /// <summary>
        /// Go To Firewall button 
        /// </summary>
        public WindowsElement goToFireWallButton => base.GetElement(session, "AutomationId", "sa-ov-link-firewall");

        /// <summary>
        /// Visit Windows Activation Button 
        /// </summary>
        public WindowsElement visitWindowsActivationButton => base.GetElement(session, "AutomationId", "sa-ov-btn-windowsActive");

        /// <summary>
        /// Go To VPN button 
        /// </summary>
        public WindowsElement goToVPNButton => base.GetElement(session, "AutomationId", "sa-ov-link-vpn");

        /// <summary>
        /// FireWall Link
        /// </summary>
        public WindowsElement firewallLink => session.FindElementByName("Firewall Loading");

        /// <summary>
        /// Password Manager Link
        /// </summary>
        public WindowsElement passwordmanagerLink => base.GetElement(session, "Name", "Password Manager Loading");

        /// <summary>
        /// WiFi Security
        /// </summary>
        /// <param name="expected"></param>
        public WindowsElement wifisecurityText => base.GetElement(session, "Name", "WiFi Security");

        /// <summary>
        /// WiFi security Link
        /// </summary>
        public WindowsElement wifisecurityLink => base.GetElement(session, "Name", "WiFi Security Loading");

        /// <summary>
        /// Intermediate Security Tab
        /// </summary>
        public WindowsElement intermediateSecurityTab => base.GetElement(session, "Name", "INTERMEDIATE SECURITY");

        /// <summary>
        /// Password Health Element
        /// </summary>
        public WindowsElement passwordHealthText => base.GetElement(session, "Name", "Password Health");

        /// <summary>
        /// Password Health text description
        /// </summary>
        public WindowsElement passwordHealthTextDescription => base.GetElement(session, "Name", "Use a more secure and easy way to manage your passwords, payments and personal information. And even create strong, complex passwords and login instantly on every site.");

        /// <summary>
        /// Password Health Installed status
        /// </summary>
        public WindowsElement passwordHealthInstalledText => base.GetElement(session, "Name", "INSTALLED");

        /// <summary>
        /// Password Health Not Installed status
        /// </summary>
        public WindowsElement passwordHealthNotInstalledText => base.GetElement(session, "Name", "NOT INSTALLED");

        /// <summary>
        /// Password Health Installing status
        /// </summary>
        public WindowsElement passwordHealthInstallingText => base.GetElement(session, "Name", "INSTALLING");

        /// <summary>
        /// VPN Not Installed status
        /// </summary>
        public WindowsElement vpnNotInstalledText => base.GetElement(session, "Name", "NOT INSTALLED");

        /// <summary>
        /// Go to Password health button
        /// </summary>
        public WindowsElement goToPasswordHealthButton => base.GetElement(session, "AutomationId", "sa-ov-link-passwordManager");

        /// <summary>
        /// I have my own password health checkbox
        /// </summary>
        //public WindowsElement myOwnPasswordCheckBox => base.GetElement(session, "Name", "I have my own password health");
        public WindowsElement myOwnPasswordCheckBox => base.GetElement(session, "AutomationId", "customCheck-sa-ov-link-passwordManager");

        /// <summary>
        /// Finger Print Reader text
        /// </summary>
        public WindowsElement fingerPrintReaderText => base.GetElement(session, "Name", "Fingerprint Reader");

        /// <summary>
        /// Finger Print Reader text description
        /// </summary>
        public WindowsElement fingerPrintReaderTextDescription => base.GetElement(session, "Name", "A fast and secure way to sign in to Windows, make payments and connect to apps and services.");

        /// <summary>
        /// User Account Control text
        /// </summary>
        public WindowsElement userAccountControlText => base.GetElement(session, "Name", "User Account Control (UAC)");

        /// <summary>
        /// User Account Control text description
        /// </summary>
        public WindowsElement userAccountControlTextDescription => base.GetElement(session, "Name", "Move the slider to select how much you want User Account Control to protect you from potentially harmful changes.");


        /// <summary>
        /// Visit User Account Control button
        /// </summary>
        public WindowsElement visitUserAccountControlButton => base.GetElement(session, "AutomationId", "sa-ov-btn-uac");

        /// <summary>
        /// Finger Print Reader status
        /// </summary>
        public WindowsElement fingerPrintReaderNotEnrolledText => base.GetElement(session, "Name", "NOT ENROLLED");

        /// <summary>
        /// Visit Finger Print Reader Button
        /// </summary>
        public WindowsElement visitFingerPrintReaderButton => base.GetElement(session, "Name", "Visit Fingerprint reader");

        /// <summary>
        /// No internet connection pane, it occurs on no internet on my security page
        /// </summary>
        public WindowsElement noInternetConnectionPane => base.GetElement(session, "Name", "No internet connection detected");

        /// <summary>
        /// No internet Icon, it occurs on no internet on my security page
        /// </summary>
        public WindowsElement offlineIcon => base.GetElement(session, "AutomationId", "sa-ov-modal-offline-icon");

        /// <summary>
        /// Basic Security_Anti-Virus_Text
        /// </summary>
        /// <param name="expected"></param>
        public WindowsElement antiVirusText => session.FindElementByXPath("//Text[@Name='Anti-Virus']");

        /// <summary>
        /// Basic Security_Firewall_Text
        /// </summary>
        /// <param name="expected"></param>
        public WindowsElement firewallText => session.FindElementByXPath("//Text[@Name='Firewall']");

        /// <summary>
        /// I have my own password health text
        /// </summary>
        public WindowsElement iHaveMyOwnPasswordHealth => base.GetElement(session, "Name", "I have my own password health");

        /// <summary>
        /// I have my own status
        /// </summary>
        public WindowsElement iHaveMyOwnStatus => base.GetElement(session, "Name", "I have my own");

        /// <summary>
        /// I have my own password health text
        /// </summary>
        public WindowsElement iHaveMyOwnPasswordHealthText => base.GetElement(session, "Name", "I have my own password health");

        /// <summary>
        /// I have my own password health check box
        /// </summary>
        public WindowsElement iHaveMyOwnPasswordHealthCheckBox => base.GetElement(session, "AutomationId", "customCheck-sa-ov-link-passwordManager");

        /// <summary>
        /// WiFi Security Text under Advance Security Page
        /// </summary>
        public WindowsElement wiFiSecurityText => base.GetElement(session, "Name", "WiFi Security");

        /// <summary>
        /// WiFi Security Text Description under Advance Security Page
        /// </summary>
        public WindowsElement wiFiSecurityTextDescription => base.GetElement(session, "Name", "An advanced software service that helps your device differentiate safe wireless networks from potentially malicious ones.");

        /// <summary>
        /// check box of I have my own wifi security
        /// </summary>
        public WindowsElement iHaveMyOwnWifiSecurityCheckBox => base.GetElement(session, "AutomationId", "customCheck-sa-ov-link-wifiSecurity");

        /// <summary>
        /// VPN Security Text under Advance Security Page
        /// </summary>
        public WindowsElement vPNSecurityText => base.GetElement(session, "Name", "Virtual Private Network (VPN) Security");

        /// <summary>
        /// VPN Security Text Description under Advance Security Page
        /// </summary>
        public WindowsElement vPNSecurityTextDescription => base.GetElement(session, "Name", "A Virtual Private Network (VPN) uses encryption to keep your online activity secure and private, and helps prevent hackers from stealing your personal information over Wi-Fi.");

        /// <summary>
        /// check box of I have my own VPN 
        /// </summary>
        public WindowsElement iHaveMyOwnVPNCheckBox => base.GetElement(session, "AutomationId", "customCheck-sa-ov-link-vpn");

        /// <summary>
        /// Anti-Virus is ENABLED under Basic Security Page
        /// </summary>
        public WindowsElement antiVirusENABLED => base.GetElement(session, "Name", "ENABLED");

        /// <summary>
        /// Firewall is ENABLED under Basic Security Page
        /// </summary>
        public WindowsElement firewallENABLED => base.GetElement(session, "Name", "ENABLED");

        /// <summary>
        /// Firewall is DISABLED under Basic Security Page
        /// </summary>
        public WindowsElement firewallDISABLED => base.GetElement(session, "Name", "DISABLED");


        /// <summary>
        /// Anti-virus is DISABLED under Basic Security Page
        /// </summary>
        public WindowsElement antiVirusDISABLED => base.GetElement(session, "Name", "DISABLED");

        public string wifiSecurityText = "WiFi Security";
        /// <summary>
        /// Scroll the screen
        /// </summary>
        public override void ScrollScreen()
        {
            touchScreen = new RemoteTouchScreen(session);
            touchScreen.Scroll(0, -500);
        }

        /// <summary>
        /// Get element list with specific locator
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public override List<WindowsElement> GetWindowsElementList(string xpath)
        {
            List<WindowsElement> elelist = new List<WindowsElement>(session.FindElementsByXPath(xpath));
            return elelist;
        }

        /// <summary>
        /// Assert element string equal expected
        /// </summary>
        /// <param name="expected"></param>
        /// <param name="windowsElement"></param>
        public override void VerifyContentAreEqual(string expected, WindowsElement windowsElement)
        {
            Assert.AreEqual(expected, windowsElement.Text);
        }

        public override void VerifyVPNSecurityNotExist()
        {
            Assert.IsFalse(IsPresent(vPNSecurity));
        }

        public override void VerifyFingerPrintNotExist()
        {
            Assert.IsFalse(IsPresent(fingerPrint));
        }

        public override void VerifyUACNotExist()
        {
            Assert.IsFalse(IsPresent(uAC));
        }

        public override void VerifyWindowsActivationNotExist()
        {
            Assert.IsFalse(IsPresent(windowsActivation));
        }

        public override void VerifyTheWiFiSecurityIsNoExist()
        {
            Assert.IsFalse(IsPresent(wiFiSecurity));
        }

        public override void VerifynoInternetConnectionPaneNotExist()
        {
            Assert.IsFalse(IsPresent(noInternetConnectionPaneName));
        }

        public override void VerifyGOTOPASSWORDHEALTHButtonNotExist()
        {
            Assert.IsFalse(IsPresent(gOTOPASSWORDHEALTHButtonName)); ;
        }

        public override void VerifyGoToWifiSecurityButtonNotExist()
        {
            Assert.IsFalse(IsPresent(goToWifiSecurityButtonName));
        }

        public override void VerifGoToVPNButtonNotExist()
        {
            Assert.IsFalse(IsPresent(gOToVPNButtonName));
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

        public bool IsPresent(string locator, string way)
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

