namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using OpenQA.Selenium.Appium.Windows;
    using System.Threading;
    using TechTalk.SpecFlow;

    [Binding]
    public class PasswordHealthPageStepDefinition
    {

        private readonly InformationalWebDriver webDriver;

        private DashBoardPage dashBoardPage;

        private PasswordHealthPage passwordHealthPage;

        private InformationalWebDriver desktopSession;

        private BaseTestClass baseTestClass = new BaseTestClass();

        public PasswordHealthPageStepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Then(@"Show noInternetConnection Pane on Password Health page")]
        public void ThenShowNoInternetConnectionPaneOnPasswordHealthPage()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.IsTrue(passwordHealthPage.noInternetConnectionPane_PasswordHealthPage.Enabled);
        }

        [Then(@"Show Offline icon on Password Health page")]
        public void ThenShowOfflineIconOnPasswordHealthPage()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.IsTrue(passwordHealthPage.offlineIcon_PasswordHealthPage.Enabled);
        }

        [Then(@"The page has BACK button")]
        public void ThenThePageHasBACKButton()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            //passwordHealthPage.VerifyContentAreEqual("< BACK", passwordHealthPage.backLinkContent);
            // Assert.AreEqual("< BACK", passwordHealthPage.backLinkContent.GetAttribute("Name"));
            Assert.AreEqual(passwordHealthPage.expect_BackLinkContent, passwordHealthPage.backLink_PasswordHealthPage.GetAttribute("Name"));
        }

        [Then(@"Privacy Policy text is correct")]
        public void ThenPrivacyPolicyTextIsCorrect()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual(passwordHealthPage.expect_privacyPolicyText, passwordHealthPage.privacyPolicyLink.GetAttribute("Name"));
        }

        [Then(@"Terms of Service text is correct")]
        public void ThenTermsOfServiceTextIsCorrect()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual(passwordHealthPage.TermsofServiceText, passwordHealthPage.TermsofServiceLink.GetAttribute("Name"));
        }


        [Then(@"Go to dashboard page and there has correct su widget tile")]
        public void ThenGoToDashboardPageAndThereHasCorrectSuWidgetTile()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.VerifyContentAreEqual(dashBoardPage.expect_SUWidgetTitle, dashBoardPage.SUWidgetTitle);
        }

        [Then(@"The subcrption header is A safer digital life is waiting")]
        public void ThenTheSubcrptionHeaderIsASaferDigitalLifeIsWaiting()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("A safer digital life is waiting: Add passwords, enable Dark Web Monitoring and autofill personal and payment info.", passwordHealthPage.subcrptionheader_Installed.GetAttribute("Name").Trim());
            //passwordHealthPage.VerifyContentAreEqual("A safer digital life is waiting: Add passwords, enable Dark Web Monitoring and autofill personal and payment info. ", passwordHealthPage.subcrptionheader_Installed);
        }

        [Then(@"The dashlane status bar is installed")]
        public void ThenTheDashlaneStatusBarIsInstalled()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.VerifyContentAreEqual("DASHLANE PASSWORD MANAGER INSTALLED", passwordHealthPage.dashlaneInstalledstatus);
        }

        [Then(@"The small header is Learn more about making the most of Dashlane")]
        public void ThenTheSmallHeaderIsLearnMoreAboutMakingTheMostOfDashlane()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("Learn more", passwordHealthPage.learnMoreLink.GetAttribute("Name").Trim());
            Assert.AreEqual("about making the most of Dashlane", passwordHealthPage.smallheader_Installed.GetAttribute("Name").Trim());
            //passwordHealthPage.VerifyContentAreEqual("Learn more", passwordHealthPage.learnMoreLink);
            //passwordHealthPage.VerifyContentAreEqual(" about making the most of Dashlane", passwordHealthPage.smallheader_Installed);
        }

        [Then(@"Click Learn more link")]
        public void ThenClickLearnMoreLink()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.learnMoreLink.Click();
        }

        [Then(@"Learn more link is correct")]
        public void ThenLearnMoreLinkIsCorrect()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("It’s Easier Than Ever to Create Strong Passwords with Dashlane", passwordHealthPage.learnmoreArticle.GetAttribute("Name").Trim());
            //passwordHealthPage.VerifyContentAreEqual("It’s Easier Than Ever to Create Strong Passwords with Dashlane", passwordHealthPage.learnmoreArticle);
            passwordHealthPage.articleCloseButton.Click();
        }

        [Then(@"The title is Getting started with Dashlane")]
        public void ThenTheTitleIsGettingStartedWithDashlane()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("Getting started with Dashlane?", passwordHealthPage.pmMiddleContentHeader_Installed.GetAttribute("Name").Trim());
            //passwordHealthPage.VerifyContentAreEqual("Getting started with Dashlane?", passwordHealthPage.pmMiddleContentHeader_Installed);
        }

        [Then(@"The body is Use Dashlane to stay safe online while saving time and frustration")]
        public void ThenTheBodyIsUseDashlaneToStaySafeOnlineWhileSavingTimeAndFrustration()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("Use Dashlane to stay safe online while saving time and frustration. For detailed instructions on how to get started,", passwordHealthPage.pmMiddleContentDescription_Installed.GetAttribute("Name").Trim());
            //passwordHealthPage.VerifyContentAreEqual("Use Dashlane to stay safe online while saving time and frustration. For detailed instructions on how to get started, ", passwordHealthPage.pmMiddleContentDescription_Installed);
        }

        [Then(@"Dashlane allows you to is here")]
        public void ThenDashlaneAllowsYouToIsHere()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("Dashlane allows you to", passwordHealthPage.pmBottomContentHeader_Installed.GetAttribute("Name").Trim());
            //passwordHealthPage.VerifyContentAreEqual("Dashlane allows you to", passwordHealthPage.pmBottomContentHeader_Installed);
        }

        [Then(@"Log in instantly every where for seamless Browsing-Sync is here")]
        public void ThenLogInInstantlyEveryWhereForSeamlessBrowsing_SyncIsHere()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("Log in instantly every where for seamless Browsing-Sync across devices so you're never without access to important accounts", passwordHealthPage.pmBottomContentItem1_Installed.GetAttribute("Name").Trim());
            //passwordHealthPage.VerifyContentAreEqual("Log in instantly every where for seamless Browsing-Sync across devices so you're never without access to important accounts", passwordHealthPage.pmBottomContentItem1_Installed);
        }

        [Then(@"Monitor the dark web for your personal information is here")]
        public void ThenMonitorTheDarkWebForYourPersonalInformationIsHere()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("Monitor the dark web for your personal information", passwordHealthPage.pmBottomContentItem2_Installed.GetAttribute("Name").Trim());
            //passwordHealthPage.VerifyContentAreEqual("Monitor the dark web for your personal information", passwordHealthPage.pmBottomContentItem2_Installed);
        }

        [Then(@"Stay safe on unsecured WiFi networks with built in VPN is here")]
        public void ThenStaySafeOnUnsecuredWiFiNetworksWithBuiltInVPNIsHere()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("Stay safe on unsecured WiFi networks with built in VPN", passwordHealthPage.pmBottomContentItem3_Installed.GetAttribute("Name").Trim());
            //passwordHealthPage.VerifyContentAreEqual("Stay safe on unsecured WiFi networks with built in VPN", passwordHealthPage.pmBottomContentItem3_Installed);
        }

        [Then(@"Share passwords securely without revealing them is here")]
        public void ThenSharePasswordsSecurelyWithoutRevealingThemIsHere()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("Share passwords securely without revealing them", passwordHealthPage.pmBottomContentItem4_Installed.GetAttribute("Name").Trim());
            //passwordHealthPage.VerifyContentAreEqual("Share passwords securely without revealing them", passwordHealthPage.pmBottomContentItem4_Installed);
        }

        [Then(@"Check out this guide is here")]
        public void ThenCheckOutThisGuideIsHere()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("check out this guide.", passwordHealthPage.checkOutTheGuideLink.GetAttribute("Name").Trim());
            //passwordHealthPage.VerifyContentAreEqual("check out this guide.", passwordHealthPage.checkOutTheGuideLink);
        }

        [Then(@"Click Check out this guide link")]
        public void ThenClickCheckOutThisGuideLink()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.checkOutTheGuideLink.Click();
        }

        [Then(@"Open check out this guide corresponding page")]
        public void ThenOpenCheckOutThisGuideCorrespondingPage()
        {
            desktopSession = baseTestClass.DesktopSession();
            Thread.Sleep(15000);
            WindowsElement url = desktopSession.Session.FindElementByAccessibilityId("addressEditBox");
            Assert.AreEqual(WebSiteUrl.passwordHealthCheckOutTheGuideUrl, url.Text);
        }

        [Then(@"The subcrption header is The safestxxxx")]
        public void ThenTheSubcrptionHeaderIsTheSafestxxxx()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("The safest, easiest way to save strong, complex passwords and log in instantly on every site.", passwordHealthPage.subcrptionheader_NotInstalled.GetAttribute("Name"));
            //passwordHealthPage.VerifyContentAreEqual("The safest, easiest way to save strong, complex passwords and log in instantly on every site. ", passwordHealthPage.subcrptionheader_NotInstalled);
        }

        [Then(@"The dashlane status bar is not installed")]
        public void ThenTheDashlaneStatusBarIsNotInstalled()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.VerifyContentAreEqual("DASHLANE PASSWORD MANAGER NOT INSTALLED", passwordHealthPage.dashlaneNotInstalledstatus);
        }

        [Then(@"The small header is Start protecting your online accounts the simple way")]
        public void ThenTheSmallHeaderIsStartProtectingYourOnlineAccountsTheSimpleWay()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("Start protecting your online accounts the simple way.", passwordHealthPage.smallheader1_NotInstalled.GetAttribute("Name").Trim());
            //passwordHealthPage.VerifyContentAreEqual("Start protecting your online accounts the simple way.", passwordHealthPage.smallheader1_NotInstalled);
        }

        [Then(@"The title is Dashlane Never forget another password")]
        public void ThenTheTitleIsDashlaneNeverForgetAnotherPassword()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("Dashlane: Never forget another password", passwordHealthPage.pmMiddleContentHeader_NotInstalled.GetAttribute("Name").Trim());
            //passwordHealthPage.VerifyContentAreEqual("Dashlane: Never forget another password", passwordHealthPage.pmMiddleContentHeader_NotInstalled);
        }

        [Then(@"The body is Dashlane is a password manager and digital protection app that works with your browser")]
        public void ThenTheBodyIsDashlaneIsAPasswordManagerAndDigitalProtectionAppThatWorksWithYourBrowser()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("Dashlane is a password manager and digital protection app that works with your browser. It automatically saves passwords and personal data, remembers it all for you, and stores everything securely. Dashlane also analyzes your account security and provides easy ways to improve your password health.", passwordHealthPage.pmMiddleContentDescription_NotInstalled.GetAttribute("Name").Trim());
            //passwordHealthPage.VerifyContentAreEqual("Dashlane is a password manager and digital protection app that works with your browser. It automatically saves passwords and personal data, remembers it all for you, and stores everything securely. Dashlane also analyzes your account security and provides easy ways to improve your password health.", passwordHealthPage.pmMiddleContentDescription_NotInstalled);
        }

        [Then(@"Dashlane helps you is here")]
        public void ThenDashlaneHelpsYouIsHere()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("Dashlane helps you", passwordHealthPage.pmBottomContentHeader_NotInstalled.GetAttribute("Name").Trim());
            //passwordHealthPage.VerifyContentAreEqual("Dashlane helps you ", passwordHealthPage.pmBottomContentHeader_NotInstalled);
        }

        [Then(@"Remember unlimited usernames and passwords is here")]
        public void ThenRememberUnlimitedUsernamesAndPasswordsIsHere()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("Remember unlimited usernames and passwords.", passwordHealthPage.pmBottomContentItem1_NotInstalled.GetAttribute("Name"));
            //passwordHealthPage.VerifyContentAreEqual("Remember unlimited usernames and passwords.", passwordHealthPage.pmBottomContentItem1_NotInstalled);
        }

        [Then(@"Log in instantly everywhere for seamless browsing is here")]
        public void ThenLogInInstantlyEverywhereForSeamlessBrowsingIsHere()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("Log in instantly everywhere for seamless browsing", passwordHealthPage.pmBottomContentItem2_NotInstalled.GetAttribute("Name").Trim());
            //passwordHealthPage.VerifyContentAreEqual("Log in instantly everywhere for seamless browsing", passwordHealthPage.pmBottomContentItem2_NotInstalled);
        }

        [Then(@"Sync across devices so you're never without access to important accounts is here")]
        public void ThenSyncAcrossDevicesSoYouReNeverWithoutAccessToImportantAccountsIsHere()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("Sync across devices so you're never without access to important accounts", passwordHealthPage.pmBottomContentItem3_NotInstalled.GetAttribute("Name").Trim());
            //passwordHealthPage.VerifyContentAreEqual("Sync across devices so you're never without access to important accounts", passwordHealthPage.pmBottomContentItem3_NotInstalled);
        }

        [Then(@"Improve your online protection with easy, actionable advice is here")]
        public void ThenImproveYourOnlineProtectionWithEasyActionableAdviceIsHere()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("Improve your online protection with easy, actionable advice", passwordHealthPage.pmBottomContentItem4_NotInstalled.GetAttribute("Name").Trim());
            //passwordHealthPage.VerifyContentAreEqual("Improve your online protection with easy, actionable advice", passwordHealthPage.pmBottomContentItem4_NotInstalled);
        }

        [Then(@"Powered By Dashlane is correct")]
        public void ThenPoweredByDashlaneIsCorrect()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual(passwordHealthPage.expect_poweredByDashlane, passwordHealthPage.poweredByDashlane.GetAttribute("Name").Trim());
        }

        [Then(@"Click Privacy Policy link")]
        public void ThenClickPrivacyPolicyLink()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.privacyPolicyLink.Click();
        }

        [Then(@"The URL of Privacy Policy is correct")]
        public void ThenTheURLOfPrivacyPolicyIsCorrect()
        {
            desktopSession = baseTestClass.DesktopSession();
            Thread.Sleep(10000);
            string url = desktopSession.Session.FindElementByAccessibilityId("addressEditBox").Text;
            Assert.AreEqual(WebSiteUrl.passwordHealthPrivacyPolicyUrl, url);
        }

        [Then(@"Click Terms of Service link")]
        public void ThenClickTermsOfServiceLink()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.TermsofServiceLink.Click();
        }

        [Then(@"The URL of Terms of Service is correct")]
        public void ThenTheURLOfTermsOfServiceIsCorrect()
        {
            desktopSession = baseTestClass.DesktopSession();
            Thread.Sleep(10000);
            string url = desktopSession.Session.FindElementByAccessibilityId("addressEditBox").Text;
            Assert.AreEqual(WebSiteUrl.passwordHealthTermsOfServiceUrl, url);
        }

        [Then(@"The description text for premium is correct")]
        public void ThenTheDescriptionTextForPremiumIsCorrect()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual("Lenovo users enjoy an exclusive 50% off Dashlane Premium.", passwordHealthPage.smallheader2_NotInstalled.GetAttribute("Name").Trim());
            Assert.AreEqual("Offer available to new Dashlane users only.", passwordHealthPage.smallheader3_NotInstalled.GetAttribute("Name").Trim());
            //passwordHealthPage.VerifyContentAreEqual("Lenovo users enjoy an exclusive 50% off Dashlane Premium.", passwordHealthPage.smallheader2_NotInstalled);
            //passwordHealthPage.VerifyContentAreEqual("Offer available to new Dashlane users only.", passwordHealthPage.smallheader3_NotInstalled);
        }

        [Then(@"Verify Password Health page name is displayed correctly")]
        public void ThenVerifyPasswordHealthPageNameIsDisplayedCorrectly()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.VerifyContentAreEqual(passwordHealthPage.passwordHealth_HeaderTitle, passwordHealthPage.passwordHealthHeaderTitle);
        }

        [Then(@"Verify it opens “Password health” page")]
        public void ThenVerifyItOpensPasswordHealthPage()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.IsTrue(passwordHealthPage.passwordHealthHeaderTitle.Displayed);
            Assert.IsTrue(passwordHealthPage.backLink_PasswordHealthPage.Enabled);

        }

        [Then(@"Click “BACK” link on Password health page")]
        public void ThenClickBACKLinkOnPasswordHealthPage()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.backLink_PasswordHealthPage.Click();
        }

    }
}
