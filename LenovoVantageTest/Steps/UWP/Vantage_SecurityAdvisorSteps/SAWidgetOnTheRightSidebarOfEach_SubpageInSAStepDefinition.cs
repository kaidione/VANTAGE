namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using OpenQA.Selenium.Appium.Windows;
    using System.Threading;
    using TechTalk.SpecFlow;


    [Binding]
    public sealed class SAWidgetOnTheRightSidebarOfEach_SubpageInSAStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver;

        private SecurityPage securityPage;
        private DashBoardPage dashBoardPage;
        private AntiVirusPage antiVirusPage;
        private PasswordHealthPage passwordHealthPage;
        private WIFISecurityPage wifiSecurityPage;
        private VPNPage vpnSecurityPage;
        private WindowsSettingsPage windowsSettingsPage;

        private InformationalWebDriver desktopSession;
        private BaseTestClass baseTestClass = new BaseTestClass();


        public SAWidgetOnTheRightSidebarOfEach_SubpageInSAStepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Given(@"Click Security and Password Health Link")]
        public void GivenClickSecurityAndPasswordHealthLink()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.passwordHealthLink.Click();
        }

        [Then(@"Click Password Health link on AV page")]
        public void ThenClickPasswordHealthLinkOnAVPage()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.pAsswordHealthLink.Click();
        }

        [Then(@"Click Wifi Security link on PM page")]
        public void ThenClickWifiSecurityLinkOnPMPage()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.wifisecurityLink.Click();
        }

        [Then(@"Click VPN Security link on AV page")]
        public void ThenClickVPNSecurityLinkOnAVPage()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.vpnsecurityLink.Click();
        }

        [Then(@"Click VPN Security link on WS page")]
        public void ThenClickVPNSecurityLinkOnWSPage()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            wifiSecurityPage.vPNSecurityLink.Click();
        }

        [Then(@"Click Fingerprint link on VPN page")]
        public void ThenClickFingerprintLinkOnVPNPage()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            vpnSecurityPage.fingerprintLink.Click();
        }

        [Then(@"Click UAC link on VPN page")]
        public void ThenClickUACLinkOnVPNPage()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            vpnSecurityPage.uacLink.Click();
        }

        [Then(@"Click Anti-virus link on VPN page")]
        public void ThenClickAnti_VirusLinkOnVPNPage()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            vpnSecurityPage.antivirusLink.Click();
        }

        [Then(@"Click Password Health link on VPN page")]
        public void ThenClickPasswordHealthLinkOnVPNPage()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            vpnSecurityPage.pAsswordHealthLink.Click();
        }

        [Then(@"Click Wifi Security link on VPN page")]
        public void ThenClickWifiSecurityLinkOnVPNPage()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            vpnSecurityPage.wIFISecurityLink.Click();
        }


        [Then(@"Anti-Virus Is Disabled\(AV\)")]
        public void ThenAnti_VirusIsDisabledAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.AreEqual(antiVirusPage.antivirusDisabled_saWidget, antiVirusPage.antivirusLink.GetAttribute("Name").Trim());
            //antiVirusPage.VerifyContentAreEqual("Anti-Virus DISABLED", antiVirusPage.antiVirusDisabled_widget);
        }

        [Then(@"Password Health Is Not Installed\(AV\)")]
        public void ThenPasswordHealthIsNotInstalledAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.AreEqual(antiVirusPage.passwordHealthNotInstalled_saWidget, antiVirusPage.pAsswordHealthLink.GetAttribute("Name").Trim());
            //antiVirusPage.VerifyContentAreEqual("Password Health NOT INSTALLED", antiVirusPage.passwordHealthDisabled_widget);
        }


        [Then(@"WiFi Security Is Disabled\(AV\)")]
        public void ThenWiFiSecurityIsDisabledAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.AreEqual(antiVirusPage.wifiSecurityDisabled_saWidget, antiVirusPage.wifisecurityLink.GetAttribute("Name").Trim());
            //antiVirusPage.VerifyContentAreEqual("WiFi Security DISABLED", antiVirusPage.wIFISecurityDisabled_widget);
        }

        [Then(@"VPN Security Is Not Installed\(AV\)")]
        public void ThenVPNSecurityIsNotInstalledAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.AreEqual(antiVirusPage.vpnNotInstalled_saWidget, antiVirusPage.vpnsecurityLink.GetAttribute("Name").Trim());
            //antiVirusPage.VerifyContentAreEqual("VPN SecurityNOT INSTALLED", antiVirusPage.vPNSecurityDisabled_widget);
        }

        [Then(@"Anti-Virus Is Disabled\(PM\)")]
        public void ThenAnti_VirusIsDisabledPM()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual(passwordHealthPage.antivirusDisabled_saWidget, passwordHealthPage.antiVirusLink.GetAttribute("Name").Trim());
        }

        [Then(@"Password Health Is Not Installed\(PM\)")]
        public void ThenPasswordHealthIsNotInstalledPM()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual(passwordHealthPage.passwordHealthNotInstalled_saWidget, passwordHealthPage.pAsswordHealthLink.GetAttribute("Name").Trim());
        }


        [Then(@"WiFi Security Is Disabled\(PM\)")]
        public void ThenWiFiSecurityIsDisabledPM()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual(passwordHealthPage.wifiSecurityDisabled_saWidget, passwordHealthPage.wifisecurityLink.GetAttribute("Name").Trim());
        }

        [Then(@"VPN Security Is Not Installed\(PM\)")]
        public void ThenVPNSecurityIsNotInstalledPM()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual(passwordHealthPage.vpnNotInstalled_saWidget, passwordHealthPage.vpnsecurityLink.GetAttribute("Name").Trim());
        }

        [Then(@"Anti-Virus Is Disabled\(WS\)")]
        public void ThenAnti_VirusIsDisabledWS()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            Assert.AreEqual(wifiSecurityPage.antivirusDisabled_saWidget, wifiSecurityPage.antiVirusLink.GetAttribute("Name").Trim());
        }

        [Then(@"Password Health Is Not Installed\(WS\)")]
        public void ThenPasswordHealthIsNotInstalledWS()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            Assert.AreEqual(wifiSecurityPage.passwordHealthNotInstalled_saWidget, wifiSecurityPage.passwordHealthLink.GetAttribute("Name").Trim());
        }


        [Then(@"WiFi Security Is Disabled\(WS\)")]
        public void ThenWiFiSecurityIsDisabledWS()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            Assert.AreEqual(wifiSecurityPage.wifiSecurityDisabled_saWidget, wifiSecurityPage.wIFISecurityLink.GetAttribute("Name").Trim());
        }

        [Then(@"VPN Security Is Not Installed\(WS\)")]
        public void ThenVPNSecurityIsNotInstalledWS()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            Assert.AreEqual(wifiSecurityPage.vpnNotInstalled_saWidget, wifiSecurityPage.vPNSecurityLink.GetAttribute("Name").Trim());
        }

        [Then(@"Anti-Virus Is Disabled\(VPN\)")]
        public void ThenAnti_VirusIsDisabledVPN()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnSecurityPage.antivirusDisabled_saWidget, vpnSecurityPage.antivirusLink.GetAttribute("Name").Trim());
        }

        [Then(@"Password Health Is Not Installed\(VPN\)")]
        public void ThenPasswordHealthIsNotInstalledVPN()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnSecurityPage.passwordHealthNotInstalled_saWidget, vpnSecurityPage.pAsswordHealthLink.GetAttribute("Name").Trim());
        }


        [Then(@"WiFi Security Is Disabled\(VPN\)")]
        public void ThenWiFiSecurityIsDisabledVPN()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnSecurityPage.wifiSecurityDisabled_saWidget, vpnSecurityPage.wIFISecurityLink.GetAttribute("Name").Trim());
        }

        [Then(@"VPN Security Is Not Installed\(VPN\)")]
        public void ThenVPNSecurityIsNotInstalledVPN()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnSecurityPage.vpnNotInstalled_saWidget, vpnSecurityPage.vpnsecurityLink.GetAttribute("Name").Trim());
        }
        [Given(@"Click Security and WIFI Security Link")]
        public void GivenClickSecurityAndWIFISecurityLink()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.wifiSecurityLink.Click();
        }

        [Given(@"Click AntiVirus link on PM page")]
        public void GivenClickAntiVirusLinkOnPMPage()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.antiVirusLink.Click();
        }

        [Given(@"Click Password Health link on AV page")]
        public void GivenClickPasswordHealthLinkOnAVPage()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.passwordHealthLink.Click();
        }

        [Given(@"Click WIFI Security link on VPN page")]
        public void GivenClickWIFISecurityLinkOnVPNPage()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            vpnSecurityPage.wIFISecurityLink.Click();
        }

        [Given(@"Click VPN Security link on WS page")]
        public void GivenClickVPNSecurityLinkOnWSPage()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            wifiSecurityPage.vPNSecurityLink.Click();
        }


        [Then(@"The Page Has Antivirus Page Header Title")]
        public void ThenThePageHasAntivirusPageHeaderTitle()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual(antiVirusPage.antivirus_HeaderTitle, antiVirusPage.antiVirusPageTitle);
        }

        //[Then(@"The Page Has Windows Defender Basic Protection Text")]
        //public void ThenThePageHasWindowsDefenderBasicProtectionText()
        //{
        //    securityPage = new SecurityPage(webDriver.Session);
        //    securityPage.VerifyContentAreEqual("Windows Defender Basic Protection", securityPage.WindowsDefenderBasicProtectionText);
        //}

        [Then(@"Antivirus Page header title is on the page")]
        public void ThenAntivirusPageHeaderTitleIsOnThePage()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual(antiVirusPage.antivirus_HeaderTitle, antiVirusPage.antiVirusPageTitle);
        }

        [Then(@"Windows Defender Basic Protection text is on the page")]
        public void ThenWindowsDefenderBasicProtectionTextIsOnThePage()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyContentAreEqual(antiVirusPage.windowsDenfenderText, securityPage.windowsDefenderBasicProtectionText);
        }

        [Then(@"Password Header Title is on the page")]
        public void ThenPasswordHeaderTitleIsOnThePage()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.VerifyContentAreEqual(passwordHealthPage.passwordHealth_HeaderTitle, passwordHealthPage.passwordHealthHeaderTitle);
        }

        [Then(@"Dashlane text is on the page")]
        public void ThenDashlaneTextIsOnThePage()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.VerifyContentAreEqual(passwordHealthPage.dashlane_SubTitle, passwordHealthPage.dashlaneText);
        }

        [Then(@"WIFI Security Header Title is on the page")]
        public void ThenWIFISecurityHeaderTitleIsOnThePage()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            wifiSecurityPage.VerifyContentAreEqual(wifiSecurityPage.wifiSecurity_HeaderTitle, wifiSecurityPage.wiFiSecurityHeaderTitle);
        }

        [Then(@"Lenovo WiFi Security text is on the page")]
        public void ThenLenovoWiFiSecurityTextIsOnThePage()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            wifiSecurityPage.VerifyContentAreEqual(wifiSecurityPage.wifiSecurity_SubTitle, wifiSecurityPage.lenovoWiFiSecurityText);
        }

        [Then(@"VPN Security Header Title is on the page")]
        public void ThenVPNSecurityHeaderTitleIsOnThePage()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            vpnSecurityPage.VerifyContentAreEqual(vpnSecurityPage.vpnSecurity_HeaderTitle, vpnSecurityPage.vPNSecurityHeaderTitle);
        }

        [Then(@"SurEasy VPN text is on the page")]
        public void ThenSurEasyVPNTextIsOnThePage()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            vpnSecurityPage.VerifyContentAreEqual(vpnSecurityPage.vpnSecurity_SubTitle, vpnSecurityPage.surfEasyVPNText);
        }

        [Then(@"How to use SurfEasy VPN text is on the page")]
        public void ThenHowToUseSurfEasyVPNTextIsOnThePage()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            vpnSecurityPage.VerifyContentAreEqual(vpnSecurityPage.howtouseVPN, vpnSecurityPage.howtouseSurfEasyVPN);
        }

        //[Given(@"Click Security and Anti-Virus Link")]
        //public void GivenClickSecurityAndAnti_VirusLink()
        //{
        //    dashBoardPage = new DashBoardPage(webDriver.Session);
        //    dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
        //    dashBoardPage.antiVriusLink.Click();
        //}

        //[Given(@"Click Password Health link on AV page")]
        //public void GivenClickPasswordHealthLinkOnAVPage()
        //{
        //    antiVirusPage = new AntiVirusPage(webDriver.Session);
        //    antiVirusPage.passwordHealthLink.Click();
        //}

        [Then(@"Password health Header Title is on the page")]
        public void ThenPasswordHealthHeaderTitleIsOnThePage()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.VerifyContentAreEqual(passwordHealthPage.passwordHealth_HeaderTitle, passwordHealthPage.passwordHealthHeaderTitle);
        }

        //[Then(@"Dashlane text is on the page")]
        //public void ThenDashlaneTextIsOnThePage()
        //{
        //    passwordHealthPage = new PasswordHealthPage(webDriver.Session);
        //    passwordHealthPage.VerifyContentAreEqual("Dashlane", passwordHealthPage.DashlaneText);
        //}

        [Then(@"There is no Windows Hello\(AV\)")]
        public void ThenThereIsNoWindowsHelloAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyWindowsHelloIsNotExist();
        }

        [Then(@"There is no Windows Hello\(PM\)")]
        public void ThenThereIsNoWindowsHelloPM()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyWindowsHelloIsNotExist();
        }

        [Then(@"There is no Windows Hello\(WS\)")]
        public void ThenThereIsNoWindowsHelloWS()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyWindowsHelloIsNotExist();
        }

        [Then(@"There is no Windows Hello\(VPN\)")]
        public void ThenThereIsNoWindowsHelloVPN()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyWindowsHelloIsNotExist();
        }

        [Then(@"Anti-Virus Is Enabled")]
        public void ThenAnti_VirusIsEnabled()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual("Anti-Virus ENABLED", antiVirusPage.antiVirusEnabled_widget);
        }

        [Then(@"Password Health Is Installed")]
        public void ThenPasswordHealthIsInstalled()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual("Password Health INSTALLED", antiVirusPage.passwordHealthEnabled_widget);
        }

        [Then(@"WiFi Security Is Enabled")]
        public void ThenWiFiSecurityIsEnabled()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual("WiFi Security ENABLED", antiVirusPage.wIFISecurityEnabled_widget);
        }

        [Then(@"VPN Security Is Installed")]
        public void ThenVPNSecurityIsInstalled()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual("VPN Security INSTALLED", antiVirusPage.vPNSecurityEnabled_widget);
        }

        [Then(@"The title is Security Advisor\(AV\)")]
        public void ThenTheTitleIsSecurityAdvisorAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual(antiVirusPage.securityAdvisor_saWidget, antiVirusPage.saWidgetTitle);
        }

        [Then(@"The subtitle is Check if your device is secured\(AV\)")]
        public void ThenTheSubtitleIsCheckIfYourDeviceIsSecuredAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual(antiVirusPage.checkifyourdeviceissecured, antiVirusPage.saWidgetSubTitle);
        }

        [Then(@"There has Anti-virus Link\(AV\)")]
        public void ThenThereHasAnti_VirusLinkAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyElementIsExist(antiVirusPage.avLink_aid, "AutomationId");
        }

        [Then(@"There has Password Health link\(AV\)")]
        public void ThenThereHasPasswordHealthLinkAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyElementIsExist(antiVirusPage.pmLink_aid, "AutomationId");
        }

        [Then(@"There has Wifi Security link\(AV\)")]
        public void ThenThereHasWifiSecurityLinkAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyElementIsExist(antiVirusPage.wsLink_aid, "AutomationId");
        }

        [Then(@"There has VPN link\(AV\)")]
        public void ThenThereHasVPNLinkAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyElementIsExist(antiVirusPage.vpnLink_aid, "AutomationId");
        }

        [Then(@"There has fingerprint link\(AV\)")]
        public void ThenThereHasFingerprintLinkAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyElementIsExist(antiVirusPage.fgLink_aid, "AutomationId");
        }

        [Then(@"There has UAC link\(AV\)")]
        public void ThenThereHasUACLinkAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyElementIsExist(antiVirusPage.uacLink_aid, "AutomationId");
        }

        [Then(@"The title is Security Advisor\(PM\)")]
        public void ThenTheTitleIsSecurityAdvisorPM()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.VerifyContentAreEqual(passwordHealthPage.securityAdvisor_saWidget, passwordHealthPage.saWidgetTitle);
        }

        [Then(@"The subtitle is Check if your device is secured\(PM\)")]
        public void ThenTheSubtitleIsCheckIfYourDeviceIsSecuredPM()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.VerifyContentAreEqual(passwordHealthPage.checkifyourdeviceissecured, passwordHealthPage.saWidgetSubTitle);
        }

        [Then(@"There has Anti-virus Link\(PM\)")]
        public void ThenThereHasAnti_VirusLinkPM()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.VerifyElementIsExist(passwordHealthPage.avLink_aid, "AutomationId");
        }

        [Then(@"There has Password Health link\(PM\)")]
        public void ThenThereHasPasswordHealthLinkPM()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.VerifyElementIsExist(passwordHealthPage.pmLink_aid, "AutomationId");
        }

        [Then(@"There has Wifi Security link\(PM\)")]
        public void ThenThereHasWifiSecurityLinkPM()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.VerifyElementIsExist(passwordHealthPage.wsLink_aid, "AutomationId");
        }

        [Then(@"There has VPN link\(PM\)")]
        public void ThenThereHasVPNLinkPM()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.VerifyElementIsExist(passwordHealthPage.vpnLink_aid, "AutomationId");
        }

        [Then(@"There has fingerprint link\(PM\)")]
        public void ThenThereHasFingerprintLinkPM()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.VerifyElementIsExist(passwordHealthPage.fgLink_aid, "AutomationId");
        }

        [Then(@"There has UAC link\(PM\)")]
        public void ThenThereHasUACLinkPM()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.VerifyElementIsExist(passwordHealthPage.uacLink_aid, "AutomationId");
        }

        [Then(@"The title is Security Advisor\(WS\)")]
        public void ThenTheTitleIsSecurityAdvisorWS()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            wifiSecurityPage.VerifyContentAreEqual(wifiSecurityPage.securityAdvisor_saWidget, wifiSecurityPage.saWidgetTitle);
        }

        [Then(@"The subtitle is Check if your device is secured\(WS\)")]
        public void ThenTheSubtitleIsCheckIfYourDeviceIsSecuredWS()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            wifiSecurityPage.VerifyContentAreEqual(wifiSecurityPage.checkifyourdeviceissecured, wifiSecurityPage.saWidgetSubTitle);
        }

        [Then(@"There has Anti-virus Link\(WS\)")]
        public void ThenThereHasAnti_VirusLinkWS()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            wifiSecurityPage.VerifyElementIsExist(wifiSecurityPage.avLink_aid, "AutomationId");
        }

        [Then(@"There has Password Health link\(WS\)")]
        public void ThenThereHasPasswordHealthLinkWS()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            wifiSecurityPage.VerifyElementIsExist(wifiSecurityPage.pmLink_aid, "AutomationId");
        }

        [Then(@"There has Wifi Security link\(WS\)")]
        public void ThenThereHasWifiSecurityLinkWS()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            wifiSecurityPage.VerifyElementIsExist(wifiSecurityPage.wsLink_aid, "AutomationId");
        }

        [Then(@"There has VPN link\(WS\)")]
        public void ThenThereHasVPNLinkWS()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            wifiSecurityPage.VerifyElementIsExist(wifiSecurityPage.vpnLink_aid, "AutomationId");
        }

        [Then(@"There has fingerprint link\(WS\)")]
        public void ThenThereHasFingerprintLinkWS()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            wifiSecurityPage.VerifyElementIsExist(wifiSecurityPage.fgLink_aid, "AutomationId");
        }

        [Then(@"There has UAC link\(WS\)")]
        public void ThenThereHasUACLinkWS()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            wifiSecurityPage.VerifyElementIsExist(wifiSecurityPage.uacLink_aid, "AutomationId");
        }

        [Then(@"The title is Security Advisor\(VPN\)")]
        public void ThenTheTitleIsSecurityAdvisorVPN()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            vpnSecurityPage.VerifyContentAreEqual(vpnSecurityPage.securityAdvisor_saWidget, vpnSecurityPage.saWidgetTitle);
        }

        [Then(@"The subtitle is Check if your device is secured\(VPN\)")]
        public void ThenTheSubtitleIsCheckIfYourDeviceIsSecuredVPN()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            vpnSecurityPage.VerifyContentAreEqual(vpnSecurityPage.checkifyourdeviceissecured, vpnSecurityPage.saWidgetSubTitle);
        }

        [Then(@"There has Anti-virus Link\(VPN\)")]
        public void ThenThereHasAnti_VirusLinkVPN()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            vpnSecurityPage.VerifyElementIsExist(vpnSecurityPage.avLink_aid, "AutomationId");
        }

        [Then(@"There has Password Health link\(VPN\)")]
        public void ThenThereHasPasswordHealthLinkVPN()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            vpnSecurityPage.VerifyElementIsExist(vpnSecurityPage.pmLink_aid, "AutomationId");
        }

        [Then(@"There has Wifi Security link\(VPN\)")]
        public void ThenThereHasWifiSecurityLinkVPN()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            vpnSecurityPage.VerifyElementIsExist(vpnSecurityPage.wsLink_aid, "AutomationId");
        }

        [Then(@"There has VPN link\(VPN\)")]
        public void ThenThereHasVPNLinkVPN()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            vpnSecurityPage.VerifyElementIsExist(vpnSecurityPage.vpnLink_aid, "AutomationId");
        }

        [Then(@"There has fingerprint link\(VPN\)")]
        public void ThenThereHasFingerprintLinkVPN()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            vpnSecurityPage.VerifyElementIsExist(vpnSecurityPage.fgLink_aid, "AutomationId");
        }

        [Then(@"There has UAC link\(VPN\)")]
        public void ThenThereHasUACLinkVPN()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            vpnSecurityPage.VerifyElementIsExist(vpnSecurityPage.uacLink_aid, "AutomationId");
        }

        [Then(@"Open Sign-in options page")]
        public void ThenOpenSign_InOptionsPage()
        {
            desktopSession = baseTestClass.DesktopSession();
            Thread.Sleep(5000);
            WindowsElement signinoptions = desktopSession.Session.FindElementByName("Sign-in options");
            Assert.IsTrue(signinoptions.Displayed);
            //windowsSettingsPage = new WindowsSettingsPage(webDriver.Session);
            //windowsSettingsPage.VerifyContentAreEqual("Sign-in options", windowsSettingsPage.signinoptions);
        }

        [Then(@"Open User Account Control settings")]
        public void ThenOpenUserAccountControlSettings()
        {
            baseTestClass.proccessIsExsitInTaskManager("dllhost");
            //desktopSession = baseTestClass.DesktopSession();
            //WindowsElement uacsub = desktopSession.Session.FindElementByName("Choose when to be notified about changes to your computer");
            //Assert.IsTrue(uacsub.Displayed);
            //windowsSettingsPage = new WindowsSettingsPage(webDriver.Session);
            //windowsSettingsPage.VerifyContentAreEqual("Choose when to be notified about changes to your computer", windowsSettingsPage.uacsub);
        }

        [Then(@"Close the Control Panel page")]
        public void ThenCloseTheControlPanelPage()
        {
            Thread.Sleep(5000);
            baseTestClass.KillProccess("dllhost");
        }

        [Then(@"Fingerprint is NOT ENROLLED\(AV\)")]
        public void ThenFingerprintIsNOTENROLLEDAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.AreEqual(antiVirusPage.fingerprintNotEnrolled_saWidget, antiVirusPage.fingerprintLink.GetAttribute("Name").Trim());
        }

        [Then(@"UAC is Disabled\(AV\)")]
        public void ThenUACIsDisabledAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.AreEqual(antiVirusPage.uacDisabled_saWidget, antiVirusPage.uacLink.GetAttribute("Name").Trim());
        }

        [Then(@"Fingerprint is NOT ENROLLED\(PM\)")]
        public void ThenFingerprintIsNOTENROLLEDPM()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual(passwordHealthPage.fingerprintNotEnrolled_saWidget, passwordHealthPage.fingerprintLink.GetAttribute("Name").Trim());
        }

        [Then(@"UAC is Disabled\(PM\)")]
        public void ThenUACIsDisabledPM()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual(passwordHealthPage.uacDisabled_saWidget, passwordHealthPage.uacLink.GetAttribute("Name").Trim());
        }

        [Then(@"Fingerprint is NOT ENROLLED\(WS\)")]
        public void ThenFingerprintIsNOTENROLLEDWS()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            Assert.AreEqual(wifiSecurityPage.fingerprintNotEnrolled_saWidget, wifiSecurityPage.fingerprintLink.GetAttribute("Name").Trim());
        }

        [Then(@"UAC is Disabled\(WS\)")]
        public void ThenUACIsDisabledWS()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            Assert.AreEqual(wifiSecurityPage.uacDisabled_saWidget, wifiSecurityPage.uacLink.GetAttribute("Name").Trim());
        }

        [Then(@"Fingerprint is NOT ENROLLED\(VPN\)")]
        public void ThenFingerprintIsNOTENROLLEDVPN()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnSecurityPage.fingerprintNotEnrolled_saWidget, vpnSecurityPage.fingerprintLink.GetAttribute("Name").Trim());
        }

        [Then(@"UAC is Disabled\(VPN\)")]
        public void ThenUACIsDisabledVPN()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnSecurityPage.uacDisabled_saWidget, vpnSecurityPage.uacLink.GetAttribute("Name").Trim());
        }

        [Then(@"Anti-Virus Is Enabled\(AV\)")]
        public void ThenAnti_VirusIsEnabledAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.AreEqual(antiVirusPage.antivirusEnabled_saWidget, antiVirusPage.antivirusLink.GetAttribute("Name").Trim());
        }

        [Then(@"Password Health Is Installed\(AV\)")]
        public void ThenPasswordHealthIsInstalledAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.AreEqual(antiVirusPage.passwordHealthInstalled_saWidget, antiVirusPage.pAsswordHealthLink.GetAttribute("Name").Trim());
        }

        [Then(@"WiFi Security Is Enabled\(AV\)")]
        public void ThenWiFiSecurityIsEnabledAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.AreEqual(antiVirusPage.wifiSecurityEnabled_saWidget, antiVirusPage.wifisecurityLink.GetAttribute("Name").Trim());
        }

        [Then(@"VPN Security Is Installed\(AV\)")]
        public void ThenVPNSecurityIsInstalledAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.AreEqual(antiVirusPage.vpnInstalled_saWidget, antiVirusPage.vpnsecurityLink.GetAttribute("Name").Trim());
        }

        [Then(@"Fingerprint is Enrolled\(AV\)")]
        public void ThenFingerprintIsEnrolledAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.AreEqual(antiVirusPage.fingerprintEnrolled_saWidget, antiVirusPage.fingerprintLink.GetAttribute("Name").Trim());
        }

        [Then(@"UAC is Enabled\(AV\)")]
        public void ThenUACIsEnabledAV()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.AreEqual(antiVirusPage.uacEnabled_saWidget, antiVirusPage.uacLink.GetAttribute("Name").Trim());
        }

        [Then(@"Anti-Virus Is Enabled\(PM\)")]
        public void ThenAnti_VirusIsEnabledPM()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual(passwordHealthPage.antivirusEnabled_saWidget, passwordHealthPage.antiVirusLink.GetAttribute("Name").Trim());
        }

        [Then(@"Password Health Is Installed\(PM\)")]
        public void ThenPasswordHealthIsInstalledPM()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual(passwordHealthPage.passwordHealthInstalled_saWidget, passwordHealthPage.pAsswordHealthLink.GetAttribute("Name").Trim());
        }

        [Then(@"WiFi Security Is Enabled\(PM\)")]
        public void ThenWiFiSecurityIsEnabledPM()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual(passwordHealthPage.wifiSecurityEnabled_saWidget, passwordHealthPage.wifisecurityLink.GetAttribute("Name").Trim());
        }

        [Then(@"VPN Security Is Installed\(PM\)")]
        public void ThenVPNSecurityIsInstalledPM()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual(passwordHealthPage.vpnInstalled_saWidget, passwordHealthPage.vpnsecurityLink.GetAttribute("Name").Trim());
        }

        [Then(@"Fingerprint is Enrolled\(PM\)")]
        public void ThenFingerprintIsEnrolledPM()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual(passwordHealthPage.fingerprintEnrolled_saWidget, passwordHealthPage.fingerprintLink.GetAttribute("Name").Trim());
        }

        [Then(@"UAC is Enabled\(PM\)")]
        public void ThenUACIsEnabledPM()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual(passwordHealthPage.uacEnabled_saWidget, passwordHealthPage.uacLink.GetAttribute("Name").Trim());
        }

        [Then(@"Anti-Virus Is Enabled\(WS\)")]
        public void ThenAnti_VirusIsEnabledWS()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            Assert.AreEqual(wifiSecurityPage.antivirusEnabled_saWidget, wifiSecurityPage.antiVirusLink.GetAttribute("Name").Trim());
        }

        [Then(@"Password Health Is Installed\(WS\)")]
        public void ThenPasswordHealthIsInstalledWS()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            Assert.AreEqual(wifiSecurityPage.passwordHealthInstalled_saWidget, wifiSecurityPage.passwordHealthLink.GetAttribute("Name").Trim());
        }

        [Then(@"WiFi Security Is Enabled\(WS\)")]
        public void ThenWiFiSecurityIsEnabledWS()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            Assert.AreEqual(wifiSecurityPage.wifiSecurityEnabled_saWidget, wifiSecurityPage.wIFISecurityLink.GetAttribute("Name").Trim());
        }

        [Then(@"VPN Security Is Installed\(WS\)")]
        public void ThenVPNSecurityIsInstalledWS()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            Assert.AreEqual(wifiSecurityPage.vpnInstalled_saWidget, wifiSecurityPage.vPNSecurityLink.GetAttribute("Name").Trim());
        }

        [Then(@"Fingerprint is Enrolled\(WS\)")]
        public void ThenFingerprintIsEnrolledWS()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            Assert.AreEqual(wifiSecurityPage.fingerprintEnrolled_saWidget, wifiSecurityPage.fingerprintLink.GetAttribute("Name").Trim());
        }

        [Then(@"UAC is Enabled\(WS\)")]
        public void ThenUACIsEnabledWS()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            Assert.AreEqual(wifiSecurityPage.uacEnabled_saWidget, wifiSecurityPage.uacLink.GetAttribute("Name").Trim());
        }

        [Then(@"Anti-Virus Is Enabled\(VPN\)")]
        public void ThenAnti_VirusIsEnabledVPN()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnSecurityPage.antivirusEnabled_saWidget, vpnSecurityPage.antivirusLink.GetAttribute("Name").Trim());
        }

        [Then(@"Password Health Is Installed\(VPN\)")]
        public void ThenPasswordHealthIsInstalledVPN()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnSecurityPage.passwordHealthInstalled_saWidget, vpnSecurityPage.pAsswordHealthLink.GetAttribute("Name").Trim());
        }

        [Then(@"WiFi Security Is Enabled\(VPN\)")]
        public void ThenWiFiSecurityIsEnabledVPN()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnSecurityPage.wifiSecurityEnabled_saWidget, vpnSecurityPage.wIFISecurityLink.GetAttribute("Name").Trim());
        }

        [Then(@"VPN Security Is Installed\(VPN\)")]
        public void ThenVPNSecurityIsInstalledVPN()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnSecurityPage.vpnInstalled_saWidget, vpnSecurityPage.vpnsecurityLink.GetAttribute("Name").Trim());
        }

        [Then(@"Fingerprint is Enrolled\(VPN\)")]
        public void ThenFingerprintIsEnrolledVPN()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnSecurityPage.fingerprintEnrolled_saWidget, vpnSecurityPage.fingerprintLink.GetAttribute("Name").Trim());
        }

        [Then(@"UAC is Enabled\(VPN\)")]
        public void ThenUACIsEnabledVPN()
        {
            vpnSecurityPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnSecurityPage.uacEnabled_saWidget, vpnSecurityPage.uacLink.GetAttribute("Name").Trim());
        }
    }
}
