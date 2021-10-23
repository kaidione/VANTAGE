namespace LenovoVantageTest.Steps.UWP
{
    using System.Threading;
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using OpenQA.Selenium.Appium.Windows;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class VPNPageInSecurityAdvisorOfVantageStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver; 

        private DashBoardPage dashBoardPage;
        private VPNPage vpnPage;
        private WIFISecurityPage wIFISecurityPage;

        private InformationalWebDriver desktopSession;

        private BaseTestClass baseTestClass = new BaseTestClass();

        public VPNPageInSecurityAdvisorOfVantageStepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Given(@"Click Security and VPN Security Link")]
        public void GivenClickSecurityAndVPNSecurityLink()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.vpnSecurityLink.Click();
        }

        [Then(@"Click Security and My Security Link")]
        public void ThenClickSecurityAndMySecurityLink()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.mySecurityLink.Click();
        }


        [Then(@"The Page Title is VPN  and there is a back link")]
        public void ThenThePageTitleIsVPNAndThereIsABackLink()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.vpnSecurity_HeaderTitle, vpnPage.vpnSecurityTitle.GetAttribute("Name").Trim());
        }

        [Then(@"The page will show SurfEasy VPN")]
        public void ThenThePageWillShowSurfEasyVPN()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.vpnSecurity_SubTitle, vpnPage.surfEasyVPNText.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("SurfEasy VPN", vpnPage.surfEasyVPNText);
        }

        [Then(@"there is SA widget")]
        public void ThenThereIsSAWidget()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.IsTrue(vpnPage.securityAdvisorWidget.Enabled);
        }

        [Given(@"Click on Get surfeasy VPN button")]
        public void GivenClickOnGetSurfeasyVPNButton()
        {
            vpnPage = new VPNPage(webDriver.Session);
            vpnPage.getSurfEasyButton.Click();
        }

        [Then(@"It shows INSTALLING")]
        public void ThenItShowsINSTALLING()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.IsTrue(vpnPage.surfEasyVPNStatusNotInstalling.Enabled);
        }

        [Then(@"It will show a refresh icon")]
        public void ThenItWillShowARefreshIcon()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.IsTrue(vpnPage.refreshIcon.Enabled);
        }

        [Then(@"GET SURFEASY button is here and text is correct")]
        public void ThenGETSURFEASYButtonIsHereAndTextIsCorrect()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.getsurfeasy,vpnPage.getSurfEasyButton.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("Get SurfEasy", vpnPage.getSurfEasyButton);
        }

        [Then(@"OPEN SURFEASY button is here and text is correct")]
        public void ThenOPENSURFEASYButtonIsHereAndTextIsCorrect()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.opensureasy, vpnPage.openSurfEasyButton.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("Open SurfEasy", vpnPage.openSurfEasyButton);
        }

        [Then(@"VPN status is not installed")]
        public void ThenVPNStatusIsNotInstalled()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.surfeasynotinstalled, vpnPage.surfEasyVPNStatusNotInstall.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("SURFEASY VPN NOT INSTALLED", vpnPage.surfEasyVPNStatusNotInstall);
        }

        [Then(@"VPN status is installed")]
        public void ThenVPNStatusIsInstalled()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.surfeasyinstalled, vpnPage.surfEasyVPNStatusInstall.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("SURFEASY VPN INSTALLED", vpnPage.surfEasyVPNStatusInstall);
        }

        [Then(@"Powered By SurfEasy is here and text is correct")]
        public void ThenPoweredBySurfEasyIsHereAndTextIsCorrect()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.poweredbysurfEasy, vpnPage.poweredBySurfeasy.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("Powered By SurfEasy", vpnPage.poweredBySurfeasy);
        }

        [Then(@"Click Policy link in VPN page")]
        public void ThenClickPolicyLinkInVPNPage()
        {
            vpnPage = new VPNPage(webDriver.Session);
            vpnPage.privacyPolicyLink.Click();
        }

        [Then(@"Open Policy link corresponding page")]
        public void ThenOpenPolicyLinkCorrespondingPage()
        {
            desktopSession = baseTestClass.DesktopSession();
            Thread.Sleep(15000);
            WindowsElement url = desktopSession.Session.FindElementByAccessibilityId("addressEditBox");
            Assert.AreEqual(WebSiteUrl.vpnpagePrivacyPolicyUrl, url.Text);
        }

        [Then(@"Click Term of Service in VPN page")]
        public void ThenClickTermOfServiceInVPNPage()
        {
            vpnPage = new VPNPage(webDriver.Session);
            vpnPage.TermsofServiceLink.Click();
        }

        [Then(@"Open Term of Service corresponding page")]
        public void ThenOpenTermOfServiceCorrespondingPage()
        {
            desktopSession = baseTestClass.DesktopSession();
            Thread.Sleep(15000);
            WindowsElement url = desktopSession.Session.FindElementByAccessibilityId("addressEditBox");
            Assert.AreEqual(WebSiteUrl.vpnpageTermsOfServiceUrl, url.Text);
        }

        [Then(@"vpn page Subscription is correct")]
        public void ThenVpnPageSubscriptionIsCorrect()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.vpnpagesubscriptionString, vpnPage.vpnpagesubscription.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("SurfEasy VPN encrypts the information you send and receive so you can safely and privately use your PC, Mac®, smartphone or tablet on any Internet connection without worry. ", vpnPage.vpnpagesubscription);
        }

        [Then(@"vpn page Small header is correct")]
        public void ThenVpnPageSmallHeaderIsCorrect()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.vpnpagesmallheaderString, vpnPage.vpnpagesmallheader.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("Help keep your online activity secure and private with SurfEasy VPN. ", vpnPage.vpnpagesmallheader);
        }

        [Then(@"Why use a Virtual Private Net work title is correct")]
        public void ThenWhyUseAVirtualPrivateNetWorkTitleIsCorrect()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.vpnMiddleContentHeaderString_NotInstalled, vpnPage.vpnMiddleContentHeader_NotInstalled.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("Why use a Virtual Private Network (VPN)?", vpnPage.vpnMiddleContentHeader_NotInstalled);
        }

        [Then(@"Using Wi-Fi hotspots subscrition is correct")]
        public void ThenUsingWi_FiHotspotsSubscritionIsCorrect()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.vpnMiddleContentDescriptionString_NotInstalled, vpnPage.vpnMiddleContentDescription_NotInstalled.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("Using Wi-Fi hotspots, like those at coffee shops or airports, could expose your sensitive information to cybercriminals. SurfEasy VPN is a no-log VPN that encrypts your personal information and doesn’t track or store your online activity or location.", vpnPage.vpnMiddleContentDescription_NotInstalled);
        }

        [Then(@"Start using SurfEasy Today is correct")]
        public void ThenStartUsingSurfEasyTodayIsCorrect()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.vpnBottomContentHeaderString_NotInstalled, vpnPage.vpnBottomContentHeader_NotInstalled.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("Start using SurfEasy Today ", vpnPage.vpnBottomContentHeader_NotInstalled);
        }

        [Then(@"vpn page\(not installed\) Bottom Content Item one is correct")]
        public void ThenVpnPageNotInstalledBottomContentItemOneIsCorrect()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.vpnBottomContentItem1String_NotInstalled, vpnPage.vpnBottomContentItem1_NotInstalled.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("Help ensure the data you send and receive is secure and private with bank-grade encryption.", vpnPage.vpnBottomContentItem1_NotInstalled);
        }

        [Then(@"vpn page\(not installed\) Bottom Content Item two is correct")]
        public void ThenVpnPageNotInstalledBottomContentItemTwoIsCorrect()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.vpnBottomContentItem2String_NotInstalled, vpnPage.vpnBottomContentItem2_NotInstalled.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("Help prevent companies from tracking your online activities or location.", vpnPage.vpnBottomContentItem2_NotInstalled);
        }

        [Then(@"vpn page\(not installed\) Bottom Content Item three is correct")]
        public void ThenVpnPageNotInstalledBottomContentItemThreeIsCorrect()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.vpnBottomContentItem3String_NotInstalled, vpnPage.vpnBottomContentItem3_NotInstalled.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("Free and premium offerings provide multiple options to fit your needs and budget.", vpnPage.vpnBottomContentItem3_NotInstalled);
        }

        [Then(@"How to use SurfEasy VPN title is correct")]
        public void ThenHowToUseSurfEasyVPNTitleIsCorrect()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.howtouseVPN, vpnPage.vpnMiddleContentHeader_Installed.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("How to use SurfEasy VPN", vpnPage.vpnMiddleContentHeader_Installed);
        }

        [Then(@"Protect your privacy subscrition is correct")]
        public void ThenProtectYourPrivacySubscritionIsCorrect()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.vpnMiddleContentDescriptionString_Installed, vpnPage.vpnMiddleContentDescription_Installed.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("Protect your privacy and turn on SurfEasy VPN when accessing a public Wi-Fi hotspot. With a Lenovo Starter VPN Plan, you can complete Reward activities to earn more data protection bandwidth. Upgrade to protect up to 5 smartphones, tablets and computers with unlimited bandwidth.", vpnPage.vpnMiddleContentDescription_Installed);
        }

        [Then(@"Turn on SurfEasy VPN is correct")]
        public void ThenTurnOnSurfEasyVPNIsCorrect()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.vpnBottomContentHeaderString_Installed, vpnPage.vpnBottomContentHeader_Installed.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("Turn on SurfEasy VPN:", vpnPage.vpnBottomContentHeader_Installed);
        }

        [Then(@"vpn page\(installed\) Bottom Content Item two is correct")]
        public void ThenVpnPageInstalledBottomContentItemTwoIsCorrect()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.vpnBottomContentItem2String_Installed, vpnPage.vpnBottomContentItem2_Installed.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("2. Turn on the VPN and wait a brief moment for confirmation of a secure connection.", vpnPage.vpnBottomContentItem2_Installed);
        }

        [Then(@"vpn page\(installed\) Bottom Content Item three is correct")]
        public void ThenVpnPageInstalledBottomContentItemThreeIsCorrect()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.vpnBottomContentItem3String_Installed, vpnPage.vpnBottomContentItem3_Installed.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("3. Change your region or location if desired, and enjoy secure, private networking.", vpnPage.vpnBottomContentItem3_Installed);
        }

        [Then(@"Anti-Virus is diabled on VPN SA widget")]
        public void ThenAnti_VirusIsDiabledOnVPNSAWidget()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.antivirusDisabled_saWidget, vpnPage.antivirusLink.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("Anti-Virus DISABLED",vpnPage.antivirusLink);
        }

        [Then(@"Password Health is not installed on VPN SA widget")]
        public void ThenPasswordHealthIsNotInstalledOnVPNSAWidget()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.passwordHealthNotInstalled_saWidget, vpnPage.pAsswordHealthLink.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("Password Health NOT INSTALLED", vpnPage.passwordHealthDisabled_widget);
        }

        [Then(@"WiFi Security is diabled on VPN SA widget")]
        public void ThenWiFiSecurityIsDiabledOnVPNSAWidget()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.wifiSecurityDisabled_saWidget, vpnPage.wIFISecurityLink.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("WiFi Security DISABLED", vpnPage.wIFISecurityDisabled_widget);
        }

        [Then(@"WiFi Security is disabled")]
        public void ThenWiFiSecurityIsDisabled()
        {
            wIFISecurityPage = new WIFISecurityPage(webDriver.Session);
            Assert.AreEqual(wIFISecurityPage.wifiSecurityDisabled_saWidget, wIFISecurityPage.wIFISecurityLink.GetAttribute("Name").Trim());
            //wIFISecurityPage.VerifyContentAreEqual("WiFi Security DISABLED", wIFISecurityPage.wIFISecurityDisabled_widget);
        }

        [Then(@"SURFEASY VPN is installing in VPN page")]
        public void ThenSURFEASYVPNIsInstallingInVPNPage()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.surfEasyVPNStatusInstalling_String, vpnPage.surfEasyVPNStatusInstalling.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("SURFEASY VPN INSTALLING", vpnPage.surfEasyVPNStatusInstalling);
        }

        [Then(@"VPN Security is installing in VPN SA widget")]
        public void ThenVPNSecurityIsInstallingInVPNSAWidget()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.vpnInstallingString_SAWidget, vpnPage.vpnsecurityLink.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("VPN Security INSTALLING", vpnPage.vpnsecurityLink);
        }

        [Then(@"VPN Security is installing in My Security page")]
        public void ThenVPNSecurityIsInstallingInMySecurityPage()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.Installing_String, vpnPage.Installing_ele.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("INSTALLING", vpnPage.surfEasyVPNStatusNotInstalling);
        }

        [Then(@"SURFEASY VPN is not installed in VPN page")]
        public void ThenSURFEASYVPNIsNotInstalledInVPNPage()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.surfeasynotinstalled, vpnPage.surfEasyVPNStatusNotInstall.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("SURFEASY VPN NOT INSTALLED", vpnPage.surfEasyVPNStatusNotInstall);
        }
    }
}
