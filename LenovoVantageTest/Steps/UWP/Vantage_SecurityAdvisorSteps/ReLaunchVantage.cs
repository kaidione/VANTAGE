using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public sealed class ReLaunchVantage : BasePage
    {

        private Utility.InformationalWebDriver webDriver;

        private DashBoardPage dashBoardPage;

        private SecurityPage securityPage;

        private AntiVirusPage antiVirusPage;

        private PasswordHealthPage passwordHealthPage;

        private WIFISecurityPage wIFISecurityPage;

        private VPNPage vpnPage;

        private InformationalWebDriver desktopSession;

        private BaseTestClass baseTestClass = new BaseTestClass();

        public ReLaunchVantage(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [StepDefinition(@"Launch Vantage")]
        [StepDefinition(@"ReLaunch Vantage")]
        [StepDefinition(@"ReLaunch Lenovo Vantage")]
        public void GivenReLaunchVantage()
        {
            VantageUI.instance.LaunchVantageWithProtocol();
            VantageCommonHelper.FlushGifContainer(webDriver.Session);
            VantageCommonHelper.CloseAlertWindow(webDriver.Session);
        }

        [Given(@"Loading Vantage '(.*)' times for '(.*)' Machine")]
        public void GivenLoadingVantageTimesForMachine(int trytimes, string type)
        {
            do
            {
                bool skip = false;
                try
                {
                    switch (type.ToLower())
                    {
                        case "common":
                            WindowsElement dashboardlink = FindElementByTimes(webDriver.Session, "XPath", "//*[@AutomationId='menu-main-nav-lnk-dashboard']", 20, 2);
                            if (dashboardlink != null)
                            {
                                skip = true;
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Loading Vantage fail. info:" + type);
                }
                if (skip)
                {
                    Console.WriteLine("Loading Vantage Sucessful.");
                    break;
                }
                Console.WriteLine("Loading Vantage " + trytimes + " times");
                Thread.Sleep(3000);
                trytimes--;
            } while (trytimes > 0);

        }

        [Given(@"Go to security page in new instance")]
        public void GivenGoToSecurityPageInNewInstance()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.securityTab.Click();
        }

        [Then(@"Verify Hero banner show on homepage in Ollifne mode")]
        public void ThenVerifyHeroBannerShowOnHomepageInOllifneMode()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            Assert.IsTrue(dashBoardPage.heroBanner.Displayed);
        }

        [Then(@"Verify contentBosB and contentBosC show on homepage in Ollifne mode")]
        public void ThenVerifyContentBosBAndContentBosCShowOnHomepageInOllifneMode()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            Assert.IsTrue(dashBoardPage.contentBoxB.Displayed);
            Assert.IsTrue(dashBoardPage.contentBoxC.Displayed);
        }

        [Then(@"Verify contentBosD show on homepage in Ollifne mode")]
        public void ThenVerifyContentBosDShowOnHomepageInOllifneMode()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.ScrollScreen();
            Assert.IsTrue(dashBoardPage.contentBoxD.Displayed);
        }

        [Then(@"Verify contentBosE and contentBosF banner show on homepage in Ollifne mode")]
        public void ThenVerifyContentBosEAndContentBosFBannerShowOnHomepageInOllifneMode()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.ScrollScreen();
            Assert.IsTrue(dashBoardPage.contentBoxE.Displayed);
            Assert.IsTrue(dashBoardPage.contentBoxF.Displayed);
        }

        [When(@"Click Expand button in new instance")]
        public void WhenClickExpandButtonInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.expandMcaFeeButton.Click();
        }

        [When(@"Scroll the screen in new instance")]
        public void WhenScrollTheScreenInNewInstance()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.ScrollScreen();
        }

        [Then(@"Verify the tile of McAfee LiveSafe Protection in new instance")]
        public void ThenVerifyTheTileOfMcAfeeLiveSafeProtectionInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual("McAfee LiveSafe Protection", antiVirusPage.mcafeeLiveProtection);
        }

        [Then(@"Verify the subscription of You are currently protected by in new instance")]
        public void ThenVerifyTheSubscriptionOfYouAreCurrentlyProtectedByInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual("You are currently protected by 360 杀毒. However, you could be better protected with McAfee LiveSafe ", antiVirusPage.youAreProtectedBy);
        }

        [Then(@"Verify the subscription of Shield your new Lenovo PC with tested in new instance")]
        public void ThenVerifyTheSubscriptionOfShieldYourNewLenovoPCWithTestedInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual("Shield your new Lenovo PC with tested, proven protection against online threats", antiVirusPage.sheildYourPC);
        }

        [Then(@"Verify the title of Rock-solid performance in new instance")]
        public void ThenVerifyTheTitleOfRock_SolidPerformanceInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual("Rock-solid performance", antiVirusPage.rockSolidPerformance);
        }

        [Then(@"Verify the subscription of Consistent in new instance")]
        public void ThenVerifyTheSubscriptionOfConsistentInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual("Consistent, precise, and reliable antivirus you can count on to help keep you safe", antiVirusPage.consistentPrecise);
        }

        [Then(@"Verify the title of Blazing-fast speed in new instance")]
        public void ThenVerifyTheTitleOfBlazing_FastSpeedInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual("Blazing-fast speed", antiVirusPage.blazingFastSpeed);
        }

        [Then(@"Verify the subscription of Optimized antivirus that in new instance")]
        public void ThenVerifyTheSubscriptionOfOptimizedAntivirusThatInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual("Optimized antivirus that won’t slow down or interrupt your Lenovo Vantage experience", antiVirusPage.optimizedAntivirus);
        }

        [Then(@"Verify the title of Why Lenovo recommends McAfee to protect all your devices is displayed correctly in new instance")]
        public void ThenVerifyTheTitleOfWhyLenovoRecommendsMcAfeeToProtectAllYourDevicesIsDisplayedCorrectlyInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual("Why Lenovo recommends ", antiVirusPage.whyLenovorecommends);
            antiVirusPage.VerifyContentAreEqual("McAfee", antiVirusPage.mcAfeeText);
            antiVirusPage.VerifyContentAreEqual(" to protect all your devices", antiVirusPage.protectYourDeviceText);
        }

        [Then(@"Verify the title of Award-Winning Antivirus is displayed correctly in new instance")]
        public void ThenVerifyTheTitleOfAward_WinningAntivirusIsDisplayedCorrectlyInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual("Award-winning antivirus", antiVirusPage.awardWinningantivirus);
        }

        [Then(@"Verify Privacy Policy link is unclickable in new instance")]
        public void ThenVerifyPrivacyPolicyLinkIsUnclickableInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsFalse(antiVirusPage.privacyPolicyLink.Enabled);
        }

        [Then(@"Verify Terms of Service link is unclickable in new instance")]
        public void ThenVerifyTermsOfServiceLinkIsUnclickableInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsFalse(antiVirusPage.termsOfServiceLink.Enabled);
        }

        [Then(@"Show offline banner in new instance")]
        public void ThenShowOfflineBannerInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.noInternetConnectionPane.Enabled);
        }

        [Then(@"Show Offline icon in new instance")]
        public void ThenShowOfflineIconInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.offlineIcon_antiVirusPage.Enabled);
        }

        [Then(@"there is SA widget in anti-virus page in new instance")]
        public void ThenThereIsSAWidgetInAnti_VirusPageInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.securityAdvisorWidget.Enabled);
        }

        [Then(@"there is content box in anti-virus page in new instance")]
        public void ThenThereIsContentBoxInAnti_VirusPageInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.contentbox.Enabled);
        }

        [Then(@"Verify the Anti Viurs in SA widget is PARTIALLY PROTECTED in new instance")]
        public void ThenVerifyTheAntiViursInSAWidgetIsPARTIALLYPROTECTEDInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.saAntiVirusStatus.Enabled);
        }

        [When(@"Go To Anti Virus Page in new instance")]
        public void WhenGoToAntiVirusPageInNewInstance()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.antiVriusLink.Click();
        }

        [Then(@"Click Expand button in new instance")]
        public void ThenClickExpandButtonInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.expandMcaFeeButton.Click();
        }

        [Then(@"Click Get Mcafee button in new instance")]
        public void ThenClickGetMcafeeButtonInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.getMcafeeButton.Click();
        }

        [Then(@"open mcafee buy page and the url is correct in new instance")]
        public void ThenOpenMcafeeBuyPageAndTheUrlIsCorrectInNewInstance()
        {
            desktopSession = baseTestClass.DesktopSession();
            WindowsElement url = desktopSession.Session.FindElementByAccessibilityId("addressEditBox");
            Assert.AreEqual(WebSiteUrl.antiVirusSubScribeUrl, url.Text);
        }

        [When(@"Click the Privacy Policy link in new instance")]
        public void WhenClickTheVerifyPrivacyPolicyLinkInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.ScrollScreen();
            antiVirusPage.privacyPolicyLink.Click();
        }

        [Then(@"Verify it will open MacAfee Privacy Policy page in new instance")]
        public void ThenVerifyItWillOpenMacAfeePrivacyPolicyPageInNewInstance()
        {
            desktopSession = baseTestClass.DesktopSession();
            WindowsElement url = desktopSession.Session.FindElementByAccessibilityId("addressEditBox");
            Assert.AreEqual(WebSiteUrl.macAfeePrivacyPolicyUrl, url.Text);
        }

        [Given(@"Click the Terms of Service link in new instance")]
        public void GivenClickTheTermsOfServiceLinkInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.ScrollScreen();
            antiVirusPage.termsOfServiceLink.Click();
        }

        [Then(@"Verify it will open MacAfee terms of Service page in new instance")]
        public void ThenVerifyItWillOpenMacAfeeTermsOfServicePageInNewInstance()
        {
            desktopSession = baseTestClass.DesktopSession();
            WindowsElement url = desktopSession.Session.FindElementByAccessibilityId("addressEditBox");
            Assert.AreEqual(WebSiteUrl.macAfeeTermsOfServiceUrl, url.Text);
        }

        [Given(@"Go To Password Health Page in new instance")]
        public void GivenGoToPasswordHealthPageInNewInstance()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.passwordHealthLink.Click();
        }

        [Then(@"The dashlane status bar is not installed in new instance")]
        public void ThenTheDashlaneStatusBarIsNotInstalledInNewInstance()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.VerifyContentAreEqual("DASHLANE PASSWORD MANAGER NOT INSTALLED", passwordHealthPage.dashlaneNotInstalledstatus);
        }

        [Then(@"Password Health Is Not Installed\(PM\) in new instance")]
        public void ThenPasswordHealthIsNotInstalledPMInNewInstance()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.VerifyContentAreEqual("Password Health NOT INSTALLED", passwordHealthPage.passwordHealthDisabled_widget);
        }

        [Then(@"SURFEASY VPN is not installed in new instance")]
        public void ThenSURFEASYVPNIsNotInstalledInNewInstance()
        {
            vpnPage = new VPNPage(webDriver.Session);
            vpnPage.VerifyContentAreEqual("SURFEASY VPN NOT INSTALLED", vpnPage.surfEasyVPNStatusNotInstall);
        }

        [Then(@"VPN Security Is Not Installed\(VPN\) in new instance")]
        public void ThenVPNSecurityIsNotInstalledVPNInNewInstance()
        {
            vpnPage = new VPNPage(webDriver.Session);
            vpnPage.VerifyContentAreEqual("VPN Security NOT INSTALLED", vpnPage.vPNSecurityDisabled_widget);
        }

        [Given(@"Go to VPN Page in new instance")]
        public void GivenGoToVPNPageInNewInstance()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.vpnSecurityLink.Click();
        }

        [When(@"Hover/Click on the Security button on the common header in new instance")]
        public void WhenHoverClickOnTheSecurityButtonOnTheCommonHeaderInNewInstance()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
        }

        [Then(@"Security drop down list is no wifi security in new instance")]
        public void ThenSecurityDropDownListIsNoWifiSecurityInNewInstance()
        {
            Assert.IsFalse(dashBoardPage.wifiSecurityLink.Enabled);
        }

        [Then(@"The Basic Security SubTab Has Anti-Virus and FireWall text in new instance")]
        public void ThenTheBasicSecuritySubTabHasAnti_VirusAndFireWallTextInNewInstance()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.ScrollScreen();
            securityPage.VerifyContentAreEqual("Anti-Virus", securityPage.antiVirusText);
            securityPage.VerifyContentAreEqual("Firewall", securityPage.firewallText);
        }

        [Then(@"Click “ADVANCED SECURITY” Tab in new instance")]
        public void ThenClickADVANCEDSECURITYTabInNewInstance()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.advancedSecurityTab.Click();
        }

        [Then(@"Verify the WiFi Security Text is not here in new instance")]
        public void ThenVerifyTheWiFiSecurityTextIsNotHereInNewInstance()
        {
            Assert.IsFalse(securityPage.wifisecurityText.Enabled);
        }

        [Given(@"Click Security and Anti-Virus Link in new instance")]
        public void GivenClickSecurityAndAnti_VirusLinkInNewInstance()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.antiVriusLink.Click();
        }

        [Then(@"There is no wifi security on Anti-virus SA widget in new instance")]
        public void ThenThereIsNoWifiSecurityOnAnti_VirusSAWidgetInNewInstance()
        {
            Assert.IsFalse(antiVirusPage.wifisecurityLink.Enabled);
        }

        [Then(@"Click Password Health link on AV page in new instance")]
        public void ThenClickPasswordHealthLinkOnAVPageInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.pAsswordHealthLink.Click();
        }

        [Then(@"There is no wifi security on Password Health SA widget in new instance")]
        public void ThenThereIsNoWifiSecurityOnPasswordHealthSAWidgetInNewInstance()
        {
            Assert.IsFalse(passwordHealthPage.wifisecurityLink.Enabled);
        }

        [Then(@"Click VPN link on Password Health page in new instance")]
        public void ThenClickVPNLinkOnPasswordHealthPageInNewInstance()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.vpnsecurityLink.Click();
        }

        [Then(@"There is no wifi security on VPN SA widget in new instance")]
        public void ThenThereIsNoWifiSecurityOnVPNSAWidgetInNewInstance()
        {
            Assert.IsFalse(vpnPage.wIFISecurityLink.Enabled);
        }

        [Then(@"Verify the SA drop-down list contains My security Anti-Virus Password Health WiFi Security and VPN Security in new instance")]
        public void ThenVerifyTheSADrop_DownListContainsMySecurityAnti_VirusPasswordHealthWiFiSecurityAndVPNSecurityInNewInstance()
        {
            Assert.IsTrue(dashBoardPage.mySecurityLink.Enabled);
            Assert.IsTrue(dashBoardPage.antiVriusLink.Enabled);
            Assert.IsTrue(dashBoardPage.passwordHealthLink.Enabled);
            Assert.IsTrue(dashBoardPage.wifiSecurityLink.Enabled);
            Assert.IsTrue(dashBoardPage.vpnSecurityLink.Enabled);
        }

        [Then(@"Verify the WiFi Security Text is displayed correctly in new instance")]
        public void ThenVerifyTheWiFiSecurityTextIsDisplayedCorrectlyInNewInstance()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyContentAreEqual("WiFi Security", securityPage.wiFiSecurityText);
        }

        [Then(@"There has Wifi Security link\(AV\) in new instance")]
        public void ThenThereHasWifiSecurityLinkAVInNewInstance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyElementIsExist(antiVirusPage.wsLink_aid, "AutomationId");
        }

        [Then(@"There has Wifi Security link\(PM\) in new instance")]
        public void ThenThereHasWifiSecurityLinkPMInNewInstance()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.VerifyElementIsExist(passwordHealthPage.wsLink_aid, "AutomationId");
        }

        [Then(@"There has Wifi Security link\(VPN\) in new instance")]
        public void ThenThereHasWifiSecurityLinkVPNInNewInstance()
        {
            vpnPage = new VPNPage(webDriver.Session);
            vpnPage.VerifyElementIsExist(vpnPage.wsLink_aid, "AutomationId");
        }

        [Then(@"There has Wifi Security link\(WS\) in new instance")]
        public void ThenThereHasWifiSecurityLinkWSInNewInstance()
        {
            wIFISecurityPage = new WIFISecurityPage(webDriver.Session);
            wIFISecurityPage.VerifyElementIsExist(wIFISecurityPage.wsLink_aid, "AutomationId");
        }

        [Then(@"Click Wifi Security link on VPN page in new instance")]
        public void ThenClickWifiSecurityLinkOnVPNPageInNewInstance()
        {
            vpnPage = new VPNPage(webDriver.Session);
            vpnPage.wIFISecurityLink.Click();
        }

        [Then(@"Verify this is no SA widget on Dashboard in new instance")]
        public void ThenVerifyThisIsNoSAWidgetOnDashboardInNewInstance()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.VerifySAWidgetNotExist();
        }
    }
}
