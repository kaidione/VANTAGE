namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Commands;
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using System.Threading;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class SecurityPage_StepDefination
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver;

        private DashBoardPage dashBoardPage;
        private SecurityPage securityPage;
        private AntiVirusPage antiVirusPage;
        private PasswordHealthPage passwordHealthPage;
        private InternetProtectionPage internetProtectionPage;
        private VPNPage vpnPage;
        private WIFISecurityPage wifiSecurityPage;

        private InformationalWebDriver desktopSession;

        private BaseTestClass baseTestClass = new BaseTestClass();

        public SecurityPage_StepDefination(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }


        [Given(@"Go to Intermediate Security Section")]
        public void GivenGoToIntermediateSecuritySection()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.intermediateSecurityTab.Click();
        }

        [Then(@"Click “INTERMEDIATE SECURITY” Tab")]
        public void ThenClickINTERMEDIATESECURITYTab()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.intermediateSecurityTab.Click();
        }

        [When(@"Click the Intermediate Security button")]
        public void WhenClickTheIntermediateSecurityButton()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.intermediateSecurityTab.Click();
        }

        [Then(@"Click “ADVANCED SECURITY” Tab")]
        public void ThenClickADVANCEDSECURITYTab()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.advancedSecurityTab.Click();
        }

        [When(@"Click “GO TO ANTI-VIRUS” button")]
        public void WhenClickGOTOANTI_VIRUSButton()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.goToAntiVirusButton.Click();
        }

        [When(@"Click Firewall button under Basic Security Tab")]
        public void WhenClickFirewallButtonUnderBasicSecurityTab()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.goToFireWallButton.Click();
        }

        [When(@"Click GO TO FIREWALL button")]
        public void WhenClickGOTOFIREWALLButton()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.goToFireWallButton.Click();
        }

        [When(@"Click Visit Windows Activation Button")]
        public void WhenClickVisitWindowsActivationButton()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.visitWindowsActivationButton.Click();
        }

        [Then(@"Click Visit Windows Activation Button")]
        public void ThenClickVisitWindowsActivationButton()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.visitWindowsActivationButton.Click();
        }

        [Then(@"The Anti Virus text description is displayed correctly")]
        public void ThenTheAntiVirusTextDescriptionIsDisplayedCorrectly()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.antiVirusTextDescription.Enabled);
        }

        [Then(@"The FireWall text description is displayed correctly")]
        public void ThenTheFireWallTextDescriptionIsDisplayedCorrectly()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.fireWallTextDescription.Enabled);
        }

        [Then(@"The Windows Activation text is displayed correctly")]
        public void ThenTheWindowsActivationTextIsDisplayedCorrectly()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.windowsActivationText.Enabled);
        }

        [Then(@"The Windows Activation text description is displayed correctly")]
        public void ThenTheWindowsActivationTextDescriptionIsDisplayedCorrectly()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.windowsActivationTextDescription.Enabled);
        }

        [Then(@"Verify the Windows Activation is Hidden")]
        public void ThenVerifyTheWindowsActivationIsHidden()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyWindowsActivationNotExist();
        }

        [Then(@"Verify Anti-Virus ENABLED")]
        public void ThenVerifyAnti_VirusENABLED()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.antiVirusEnabled.Enabled);
        }

        [Then(@"Verify Firewall ENABLED")]
        public void ThenVerifyFirewallENABLED()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.fireWallEnabled.Enabled);
        }

        [Then(@"Verify Enabled Status exist")]
        public void ThenVerifyEnabledStatusExist()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.enabledStatus.Enabled);
        }

        [Then(@"Verify Anti-Virus ENABLED Status exist")]
        public void ThenVerifyAnti_VirusENABLEDStatusExist()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.antiVirusENABLEDdStatus.Enabled);
        }

        [Then(@"Verify UAC Disabled Status exist")]
        public void ThenVerifyUACDisabledStatusExist()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.uACdisabledStatus.Enabled);
        }

        [Then(@"Verify WiFi security Disabled Status exist")]
        public void ThenVerifyWiFiSecurityDisabledStatusExist()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.wiFiSecurityStatus.Enabled);
        }

        [Then(@"Verify Anti-Virus DISABLED")]
        public void ThenVerifyAnti_VirusDISABLED()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.AntiVirusDisabledStatus.Enabled);
        }

        [Then(@"Verify Windows Activation ENABLED Status exist")]
        public void ThenVerifyWindowsActivationENABLEDStatusExist()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.windowsActivationENABLEDStatus.Enabled);
        }

        [Then(@"Verify Windows Activation DISABLED")]
        public void ThenVerifyWindowsActivationDISABLED()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.windowsActivationDisabledStatus.Enabled);
        }

        [Then(@"Verify Firewall ENABLED Status exist")]
        public void ThenVerifyFirewallENABLEDStatusExist()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.fireWallENABLEDStatus.Enabled);
        }

        [Then(@"Verify Firewall DISABLED")]
        public void ThenVerifyFirewallDISABLED()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.fireWallDisabledStatus.Enabled);
        }


        [Then(@"Verify Installed status exist")]
        public void ThenVerifyInstalledStatusExist()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.installedStatus.Enabled);
        }

        [Then(@"Verify ENROLLED statues exist")]
        public void ThenVerifyENROLLEDStatuesExist()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.enrolledStatus.Enabled);
        }

        [Then(@"Verify the password health NOT INSTALLED status exist")]
        public void ThenVerifyThePasswordHealthNOTINSTALLEDStatusExist()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.passwordHealthNotInstalledText.Enabled);
        }

        [Then(@"Verify the vpn NOT INSTALLED status exist")]
        public void ThenVerifyTheVpnNOTINSTALLEDStatusExist()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.vpnNotInstalledText.Enabled);
        }

        [Given(@"Click Password Health Check Box")]
        public void GivenClickPasswordHealthCheckBox()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.myOwnPasswordCheckBox.Click();
        }

        [Given(@"Uncheck Password Health Check Box")]
        public void GivenUncheckPasswordHealthCheckBox()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.myOwnPasswordCheckBox.Click();
        }

        [When(@"Click Go To Anti-Virus link under Basic Security Tab")]
        public void WhenClickGoToAnti_VirusLinkUnderBasicSecurityTab()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.goToAntiVirusButton.Click();
        }

        [Then(@"Click “GO TO ANTI-VIRUS” button")]
        public void ThenClickGOTOANTI_VIRUSButton()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.goToAntiVirusButton.Click();
        }

        [Then(@"Verify it opens “Anti-Virus” page")]
        public void ThenVerifyItOpensAnti_VirusPage()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.antiVirusPageTitle.Enabled);
        }

        [Then(@"The page title is Anti-Virus and there is Back link")]
        public void ThenThePageTitleIsAnti_VirusAndThereIsBackLink()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.antiVirusPageTitle.Displayed);
            Assert.IsTrue(antiVirusPage.backLink_AntiVirusPage.Enabled);
            antiVirusPage.backLink_AntiVirusPage.Click();
        }

        [Then(@"Click “BACK” link")]
        public void ThenClickBACKLink()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.backLink.Click();
        }

        [Given(@"Disable WIFI connection")]
        public void GivenDisableWIFIConnection()
        {
            CmdCommands.DisableEthernet();
            //CmdCommands.DisableWiFi();
        }

        [Then(@"No internet connect pane exist")]
        public void ThenNoInternetConnectPaneExist()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.noInternetConnectionPane.Enabled);
        }

        [Then(@"No icon occur exist")]
        public void ThenNoIconOccurExist()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.noInternetConnectionPane.Enabled);
        }

        [Then(@"securityoneoone button is disable")]
        public void ThenSecurityoneooneButtonIsDisable()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsFalse(securityPage.securityoneooneButton.Enabled);
        }

        [Then(@"No connect pane occurs on Dashboard and Give Feedback button is disable")]
        public void ThenNoConnectPaneOccursOnDashboardAndGiveFeedbackButtonIsDisable()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            Assert.IsTrue(dashBoardPage.noConnectionPane.Enabled);
            Assert.IsFalse(dashBoardPage.giveFeedBackButton.Enabled);
            dashBoardPage.GoToAntiVirusPage();
        }

        [Then(@"Show offline banner")]
        public void ThenShowOfflineBanner()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.noInternetConnectionPane.Enabled);
        }

        [Then(@"Show Offline icon")]
        public void ThenShowOfflineIcon()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.offlineIcon.Enabled);
        }

        [Then(@"The noInternetConnection Pane is Not exist")]
        public void ThenTheNoInternetConnectionPaneIsNotExist()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifySAWidgetNotExist();
        }


        [Then(@"The Offline icon is disappear")]
        public void ThenTheOfflineIconIsDisappear()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsFalse(securityPage.offlineIcon.Enabled);
        }

        [Then(@"Go to Anti-Virus Page")]
        public void ThenGoToAnti_VirusPage()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.noConnectionPane.Enabled);
            Assert.IsTrue(antiVirusPage.offLineImage.Enabled);
            Assert.IsFalse(antiVirusPage.buyNowButtonWithOutBackground.Enabled);
            antiVirusPage.GoToPasswordHealthPage();
        }

        [Given(@"Go to antivirus page")]
        public void GivenGoToAntivirusPage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.antiVriusLink.Click();
        }

        [Given(@"Go to dadslane page")]
        public void GivenGoToDadslanePage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.passwordHealthLink.Click();

        }

        [Given(@"Go to Password Health Page")]
        public void GivenGoToPasswordHealthPage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.passwordHealthLink.Click();
        }

        [When(@"Go to Password Health Page")]
        public void WhenGoToPasswordHealthPage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.passwordHealthLink.Click();
        }

        [When(@"Go to antivirus page")]
        public void WhenGoToAntivirusPage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.antiVriusLink.Click();
        }

        [Then(@"Go to Password Health Page")]
        public void ThenGoToPasswordHealthPage()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.IsTrue(passwordHealthPage.noConnectionPane.Enabled);
            Assert.IsTrue(passwordHealthPage.offLineImage.Enabled);
            Assert.IsFalse(passwordHealthPage.getDashLaneButton.Enabled);
            passwordHealthPage.GoToInternetProtectionPage();
        }

        [Given(@"Go to VPN Page")]
        public void GivenGoToVPNPage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.vpnSecurityLink.Click();
        }

        [When(@"Go to VPN Page")]
        public void WhenGoToVPNPage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.vpnSecurityLink.Click();
        }

        [Then(@"Get Dashlane button is disable")]
        public void ThenGetDashlaneButtonIsDisable()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.IsFalse(passwordHealthPage.getDashLaneButton.Enabled);

        }

        [Given(@"Go to WiFi Security Page")]
        [When(@"Go to WiFi Security Page")]
        public void GivenGoToWiFiSecurityPage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.wifiSecurityLink.Click();
        }

        [Given(@"Scroll the screen")]
        public void GivenScrollTheScreen()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.ScrollScreen();
        }


        [When(@"Scroll the screen")]
        public void WhenScrollTheScreen()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.ScrollScreen();
        }

        [Then(@"Scroll the screen")]
        public void ThenScrollTheScreen()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.ScrollScreen();
        }

        [Then(@"Click “GO TO FIREWALL” button")]
        public void ThenClickGOTOFIREWALLButton()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.goToFireWallButton.Click();
        }

        [Then(@"The Password Health Text is displayed correctly")]
        public void ThenThePasswordHealthTextIsDisplayedCorrectly()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.passwordHealthText.Enabled);
        }

        [Then(@"The Password Health Text Description is displayed correctly")]
        public void ThenThePasswordHealthTextDescriptionIsDisplayedCorrectly()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.passwordHealthTextDescription.Enabled);
        }

        [Then(@"The check box of I have my own password health is displayed correctly")]
        public void ThenTheCheckBoxOfIHaveMyOwnPasswordHealthIsDisplayedCorrectly()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.iHaveMyOwnPasswordHealthCheckBox.Enabled);
        }

        [Then(@"Verify “GO TO PASSWORD HEALTH” button is disappeared")]
        public void ThenVerifyGOTOPASSWORDHEALTHButtonIsDisappeared()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyGOTOPASSWORDHEALTHButtonNotExist();
        }

        [Then(@"Verify the I have my own status is exist")]
        public void ThenVerifyTheIHaveMyOwnStatusIsExist()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.iHaveMyOwnStatus.Enabled);
        }

        [Then(@"The text of I have my own password health is displayed correctly")]
        public void ThenTheTextOfIHaveMyOwnPasswordHealthIsDisplayedCorrectly()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyContentAreEqual("I have my own password health", securityPage.iHaveMyOwnPasswordHealthText);
        }

        [Then(@"Click “GO TO PASSWORD HEALTH” button")]
        public void ThenClickGOTOPASSWORDHEALTHButton()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.goToPasswordHealthButton.Click();
        }

        [Then(@"The Fingerprint Reader Text is displayed correctly")]
        public void ThenTheFingerprintReaderTextIsDisplayedCorrectly()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyContentAreEqual("Fingerprint Reader", securityPage.fingerPrintReaderText);
        }

        [Then(@"The Fingerprint Reader Text Description is displayed correctly")]
        public void ThenTheFingerprintReaderTextDescriptionIsDisplayedCorrectly()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyContentAreEqual("A fast and secure way to sign in to Windows, make payments and connect to apps and services.", securityPage.fingerPrintReaderTextDescription);
        }

        [Then(@"Verify the FingerPrint hide")]
        public void ThenVerifyTheFingerPrintHide()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyFingerPrintNotExist();
        }

        [Then(@"Verify Hide Info for VPN for China Region")]
        public void ThenVerifyHideInfoForVPNForChinaRegion()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyVPNSecurityNotExist();
        }

        [Then(@"Click “VISIT FINGERPRINT READER” button")]
        public void ThenClickVISITFINGERPRINTREADERButton()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.visitFingerPrintReaderButton.Click();
        }

        [Then(@"The User Account Control Text is displayed correctly")]
        public void ThenTheUserAccountControlTextIsDisplayedCorrectly()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyContentAreEqual("User Account Control (UAC)", securityPage.userAccountControlText);
        }

        [Then(@"The User Account Control Text Description is displayed correctly")]
        public void ThenTheUserAccountControlTextDescriptionIsDisplayedCorrectly()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyContentAreEqual("Move the slider to select how much you want User Account Control to protect you from potentially harmful changes.", securityPage.userAccountControlTextDescription);
        }

        [Then(@"Verify the UAC is Hidden")]
        public void ThenVerifyTheUACIsHidden()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyUACNotExist();
        }

        [Then(@"Click Visit User Account Control button")]
        public void ThenClickVisitUserAccountControlButton()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.visitUserAccountControlButton.Click();
        }

        [Then(@"Verify the WiFi Security Text is displayed correctly")]
        public void ThenVerifyTheWiFiSecurityTextIsDisplayedCorrectly()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.wiFiSecurityText.Enabled);
        }

        [Then(@"Verify the WiFi Security Text Description is displayed correctly")]
        public void ThenVerifyTheWiFiSecurityTextDescriptionIsDisplayedCorrectly()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.wiFiSecurityTextDescription.Enabled);
        }

        [Then(@"Verify Check box of I have my own wifi security is displayed correctly")]
        public void ThenVerifyCheckBoxOfIHaveMyOwnWifiSecurityIsDisplayedCorrectly()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.iHaveMyOwnWifiSecurityCheckBox.Enabled);
        }

        [Then(@"Verify go to wifi security button exist")]
        public void ThenVerifyGoToWifiSecurityButtonExist()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.goToWifiSecurityButton.Enabled);
        }

        [When(@"Click the Check box of I have my own wifi security")]
        public void WhenClickTheCheckBoxOfIHaveMyOwnWifiSecurity()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.iHaveMyOwnWifiSecurityCheckBox.Click();
        }

        [Then(@"Verify the go to wifi security button is hidden")]
        public void ThenVerifyTheGoToWifiSecurityButtonIsHidden()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyGoToWifiSecurityButtonNotExist();
        }

        [Then(@"Verify the I HAVE MY OWN statues is exist")]
        public void ThenVerifyTheIHAVEMYOWNStatuesIsExist()
        {
            //securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.iHaveMyOwnStatus.Enabled);
        }

        [Given(@"UnCheck the Check box of I have my own wifi security")]
        public void GivenUnCheckTheCheckBoxOfIHaveMyOwnWifiSecurity()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.iHaveMyOwnWifiSecurityCheckBox.Click();
        }

        [Then(@"Verify WiFi Security Enabled Status is exist")]
        public void ThenVerifyWiFiSecurityEnabledStatusIsExist()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.wiFiSecurityEnabledStatus.Enabled);
        }

        [Then(@"Click “GO TO WIFI SECURITY” button")]
        public void ThenClickGOTOWIFISECURITYButton()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.goToWifiSecurityButton.Click();
        }

        [Then(@"Verify VPN Security Text is displayed correctly")]
        public void ThenVerifyVPNSecurityTextIsDisplayedCorrectly()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.vPNSecurityText.Enabled);
        }

        [Then(@"Verify VPN Security Text Description is displayed correctly")]
        public void ThenVerifyVPNSecurityTextDescriptionIsDisplayedCorrectly()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.vPNSecurityTextDescription.Enabled);
        }

        [Then(@"Verify the Check Box of I have my own VPN is displayed correctly")]
        public void ThenVerifyTheCheckBoxOfIHaveMyOwnVPNIsDisplayedCorrectly()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.iHaveMyOwnVPNCheckBox.Enabled);
        }

        [When(@"Click the Check Box of I have my own VPN")]
        public void WhenClickTheCheckBoxOfIHaveMyOwnVPN()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.iHaveMyOwnVPNCheckBox.Click();
        }

        [Given(@"Uncheck the Check Box of I have my own VPN")]
        public void GivenUncheckTheCheckBoxOfIHaveMyOwnVPN()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.iHaveMyOwnVPNCheckBox.Click();
        }

        [Then(@"Verify the “GO TO VPN SECURITY” button is hidden")]
        public void ThenVerifyTheGOTOVPNSECURITYButtonIsHidden()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifGoToVPNButtonNotExist();
        }

        [Then(@"Vrify VPN Installed Status is exist")]
        public void ThenVrifyVPNInstalledStatusIsExist()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.vPNINSTALLEDStatus.Enabled);
        }

        [Then(@"Click “GO TO VPN SECURITY” button")]
        public void ThenClickGOTOVPNSECURITYButton()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.goToVPNButton.Click();
        }

        [Then(@"Verify it opens “VPN security” page")]
        public void ThenVerifyItOpensVPNSecurityPage()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.IsTrue(vpnPage.vpnSecurityTitle.Displayed);
        }

        [Then(@"Go to Internet Protection Page")]
        public void ThenGoToInternetProtectionPage()
        {
            internetProtectionPage = new InternetProtectionPage(webDriver.Session);
            Assert.IsTrue(internetProtectionPage.noConnectionPane.Enabled);
            Assert.IsTrue(internetProtectionPage.offLineImage.Enabled);
            Assert.IsFalse(internetProtectionPage.getSurfEasyButton.Enabled);
            CmdCommands.EnableWiFi();
        }

        [Then(@"Verify the WiFi Security is Hidden")]
        public void ThenVerifyTheWiFiSecurityIsHidden()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyTheWiFiSecurityIsNoExist();
        }

        [Then(@"Verify Anti-Virus is ENABLED")]
        public void ThenVerifyAnti_VirusIsENABLED()
        {
            securityPage = new SecurityPage(webDriver.Session);
            //securityPage.ScrollScreen();
            Assert.IsTrue(securityPage.antiVirusENABLED.Enabled);
        }

        [Then(@"Verify Firewall is ENABLED")]
        public void ThenVerifyFirewallIsENABLED()
        {
            securityPage = new SecurityPage(webDriver.Session);
            //securityPage.ScrollScreen();
            Assert.IsTrue(securityPage.firewallENABLED.Enabled);
        }

        [Then(@"Verify Firewall is DISABLED")]
        public void ThenVerifyFirewallIsDISABLED()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.ScrollScreen();
            Thread.Sleep(5000);
            Assert.IsTrue(securityPage.firewallDISABLED.Enabled);
        }

        [Then(@"Verify Anti-Virus is DISABLED")]
        public void ThenVerifyAnti_VirusIsDISABLED()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.ScrollScreen();
            Assert.IsTrue(securityPage.antiVirusDISABLED.Enabled);
        }


    }
}

