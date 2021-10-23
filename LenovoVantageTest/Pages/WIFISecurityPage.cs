namespace LenovoVantageTest.Pages
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;
    using System;
    using System.Xml;

    public class WIFISecurityPage : BasePage
    {
        private WindowsDriver<WindowsElement> session;

        public static string WifiSecurityUserData = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Lenovo\ImController\PluginData\LenovoWiFiSecurityPlugin\UserData.xml";

        public string expectWiFiSecurityHeaderTitle = "WiFi security";

        /// <summary>
        /// No internet connection pane, it occurs on no internet on WiFi security  page
        /// </summary>
        public WindowsElement noInternetConnectionPane_WiFiPage => base.GetElement(session, "Name", "No internet connection detected");

        /// <summary>
        /// offline Icone show on WiFi security Page
        /// </summary>
        public WindowsElement offlineIcon_WiFiPage => base.GetElement(session, "AutomationId", "sa-ws-modal-offline-icon");

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

        public WindowsElement antiVirusLink => base.GetElement(session, "AutomationId", "wifi-security-sa-widget-lnk-av");

        public WindowsElement passwordHealthLink => base.GetElement(session, "AutomationId", "wifi-security-sa-widget-lnk-pm");

        public WindowsElement wIFISecurityLink => base.GetElement(session, "AutomationId", "wifi-security-sa-widget-lnk-ws");

        public WindowsElement vPNSecurityLink => base.GetElement(session, "AutomationId", "wifi-security-sa-widget-lnk-vpn");

        public WindowsElement fingerprintLink => base.GetElement(session, "AutomationId", "wifi-security-sa-widget-lnk-wh");

        public WindowsElement uacLink => base.GetElement(session, "AutomationId", "wifi-security-sa-widget-lnk-uac");

        public WindowsElement saWidgetTitle => base.GetElement(session, "Name", "Security Advisor");

        public WindowsElement saWidgetSubTitle => base.GetElement(session, "Name", "Check if your device is secured.");


        //public WindowsElement wiFiSecurityHeaderTitle => base.GetElement(session, "XPath", "//Text[@AutomationId='security-wifi-header-title']");

        public WindowsElement wiFiSecurityHeaderTitle => base.GetElement(session, "AutomationId", "security-wifi-header-title");

        public WindowsElement wiFiSecurityText => base.GetElement(session, "XPath", "//Text[@Name='WiFi Security']");

        public WindowsElement CommonDialogClose => base.FindElementByTimes(session, "AutomationId", "btn-common-dialog-close", 10, 1);

        public WindowsElement CommonDialogIgnore => base.FindElementByTimes(session, "AutomationId", "btn-common-dialog-ignore", 10, 1);

        public WindowsElement lenovoWiFiSecurityText => base.GetElement(session, "XPath", "//Text[@Name='Lenovo WiFi Security']");

        public WindowsElement VantageLogCloseBtn => base.FindElementByTimes(session, "AutomationId", "btnClose", 1, 1);

        public WindowsElement SigninPrompt => base.FindElementByTimes(session, "AutomationId", "btn-common-dialog-sign in", 10, 1);

        public WindowsElement WiFiSecurityToggle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.WifiSecurity.WiFiSecurityToggle"));

        public WindowsElement connectedHomeSecurityText => base.GetElement(session, "XPath", "//Text[@Name='Connected Home Security']");

        /// <summary>
        /// Back Link on WiFi Security page
        /// </summary>
        public WindowsElement backLink_wiFiSecurityPage => base.GetElement(session, "AutomationId", "sa-ws-btn-back");


        public string avLink_aid = "wifi-security-sa-widget-lnk-av";

        public string pmLink_aid = "wifi-security-sa-widget-lnk-pm";

        public string wsLink_aid = "wifi-security-sa-widget-lnk-ws";

        public string vpnLink_aid = "wifi-security-sa-widget-lnk-vpn";

        public string fgLink_aid = "wifi-security-sa-widget-lnk-wh";

        public string uacLink_aid = "wifi-security-sa-widget-lnk-uac";


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


        public string wifiSecurity_HeaderTitle = "WiFi security";

        public string wifiSecurity_SubTitle = "Lenovo WiFi Security";


        public string securityAdvisor_saWidget = "Security Advisor";

        public string checkifyourdeviceissecured = "Check if your device is secured.";

        public WIFISecurityPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
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

        public static void ChangeWifiStartTime(int time)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(WifiSecurityUserData);
            XmlNodeList nodeList = xmlDoc.SelectNodes("/UserData/WifiSecurityStart");
            foreach (var node in nodeList)
            {
                var nodeChild = node as XmlNode;
                DateTime updatetime = Convert.ToDateTime(nodeChild.FirstChild.Value).AddDays(time);
                string updateTime = updatetime.ToString("yyyy-MM-ddTHH:mm:ss");
                nodeChild.FirstChild.Value = updateTime;
                xmlDoc.Save(WifiSecurityUserData);
            }
        }
    }
}
