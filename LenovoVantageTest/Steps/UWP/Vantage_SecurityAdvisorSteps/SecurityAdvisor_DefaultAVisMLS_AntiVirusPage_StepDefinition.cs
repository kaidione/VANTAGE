namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using OpenQA.Selenium.Appium.Windows;
    using System.Threading;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class SecurityAdvisor_DefaultAVisMLS_AntiVirusPage_StepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver;

        private InformationalWebDriver desktopSession;

        private BaseTestClass baseTestClass = new BaseTestClass();

        private DashBoardPage dashBoardPage;
        private AntiVirusPage antiVirusPage;

        public SecurityAdvisor_DefaultAVisMLS_AntiVirusPage_StepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Then(@"Verify there is your threat protection report")]
        public void ThenVerifyThereIsYourThreatProtectionReport()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.yourThreatProtectionReport.Enabled);

        }

        [Then(@"Verify Files scanned is displayed correctly")]
        public void ThenVerifyFilesScannedIsDisplayedCorrectly()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.filesScanned.Enabled);
        }

        [Then(@"Verify Viruses Eliminated is displayed correctly")]
        public void ThenVerifyVirusesEliminatedIsDisplayedCorrectly()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.virusesEliminated.Enabled);
        }

        [Then(@"Verify Bad connections blocked is displayed correctly")]
        public void ThenVerifyBadConnectionsBlockedIsDisplayedCorrectly()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.badConnectionsBlocked.Enabled);
        }

        [Then(@"Verify Files Safely Shredded is displayed correctly")]
        public void ThenVerifyFilesSafelyShreddedIsDisplayedCorrectly()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.filesSafelyShredded.Enabled);
        }

        [Then(@"Verify Launch McAfee button is exist")]
        public void ThenVerifyLaunchMcAfeeButtonIsExist()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.launchMcaFeeButton.Enabled);
        }

        [Then(@"Verify Launch McAfee button is clickable")]
        public void ThenVerifyLaunchMcAfeeButtonIsClickable()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.launchMcaFeeButton.Enabled);
        }


        [Then(@"Verify Launch McAfee button is unclickable")]
        public void ThenVerifyLaunchMcAfeeButtonIsUnclickable()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsFalse(antiVirusPage.launchMcaFeeButton.Enabled);
        }


        [Then(@"Verify the McAfee Registration status is ENABLED")]
        public void ThenVerifyTheMcAfeeRegistrationStatusIsENABLED()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.mcAfeeRegistrationENABLED.Enabled);
        }

        [Then(@"Verify the McAfee Registration status is DISABLED")]
        public void ThenVerifyTheMcAfeeRegistrationStatusIsDISABLED()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.mcAfeeRegistrationDISABLED.Enabled);
        }

        [Then(@"Verify the Virus Scan status is ENABLED")]
        public void ThenVerifyTheVirusScanStatusIsENABLED()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.virusScanStatusENABLED.Enabled);
        }

        [Then(@"Verify the Virus Scan status is DISABLED")]
        public void ThenVerifyTheVirusScanStatusIsDISABLED()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.virusScanStatusDISABLED.Enabled);
        }

        [Then(@"Verify the Personal Firewall status is ENABLED")]
        public void ThenVerifyThePersonalFirewallStatusIsENABLED()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.personalFirewallENABLED.Enabled);
        }

        [Then(@"Verify the McAfee Anti-Spam status is ENABLED")]
        public void ThenVerifyTheMcAfeeAnti_SpamStatusIsENABLED()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.mcAfeeAntiSpamENABLED.Enabled);
        }

        [Then(@"Verify the McAfee QuickClean status is ENABLED")]
        public void ThenVerifyTheMcAfeeQuickCleanStatusIsENABLED()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.mcAfeeQuickCleanENABLED.Enabled);
        }

        [Then(@"Verify the McAfee Vulnerability Scanner is ENABLED")]
        public void ThenVerifyTheMcAfeeVulnerabilityScannerIsENABLED()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.mcAfeeVulnerabilityScannerENABLED.Enabled);
        }

        [Then(@"Verify the Personal Firewall status is DISABLED")]
        public void ThenVerifyThePersonalFirewallStatusIsDISABLED()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.personalFirewallDISABLED.Enabled);
        }


        [Then(@"Verify the McAfee Anti-Spam status is DISABLED")]
        public void ThenVerifyTheMcAfeeAnti_SpamStatusIsDISABLED()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.mcAfeeAntiSpamDISABLED.Enabled);
        }

        [Then(@"Click Subscribe Now")]
        public void ThenClickSubscribeNow()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.subscribeNowLink.Click();

        }

        [When(@"Click Subscribe Now")]
        public void WhenClickSubscribeNow()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.subscribeNowLink.Click();
        }

        [Then(@"Verify it will open McAfee Payment page")]
        public void ThenVerifyItWillOpenMcAfeePaymentPage()
        {
            desktopSession = baseTestClass.DesktopSession();
            Thread.Sleep(30000);
            //Assert.IsTrue(desktopSession.Session.FindElementByAccessibilityId("m_titleTextBlock").Displayed);
            string url = desktopSession.Session.FindElementByAccessibilityId("addressEditBox").Text;
            Assert.AreEqual(WebSiteUrl.antiVirusSubScribeUrl, url);
            //Assert.AreEqual(WebSiteUrl.antiVirusSubScribeUrl_ZH, url);
        }

        [Then(@"Verify Subscribe Now Link is unclickable")]
        public void ThenVerifySubscribeNowLinkIsUnclickable()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Thread.Sleep(5000);
            Assert.AreEqual("text", antiVirusPage.subscribeNowText.GetAttribute("LocalizedControlType"));
        }

        [Then(@"Verify the Your Threat Protection Report is hide")]
        public void ThenVerifyTheYourThreatProtectionReportIsHide()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyTheYourThreatProtectionReportIsNoExist();
        }

        [Then(@"Verify the title of Why Lenovo recommends McAfee to protect all your devices is displayed correctly")]
        public void ThenVerifyTheTitleOfWhyLenovoRecommendsMcAfeeToProtectAllYourDevicesIsDisplayedCorrectly()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.protectAllYourDevicesSectionTitle_1_LSMcAfee.Enabled);
            Assert.IsTrue(antiVirusPage.protectAllYourDevicesSectionTitle_2_LSMcAfee.Enabled);
            Assert.IsTrue(antiVirusPage.protectYourDeviceText.Enabled);
        }

        [Then(@"Verify the title of Why Lenovo recommends McAfee to protect all your devices is displayed correctly with Avira")]
        public void ThenVerifyTheTitleOfWhyLenovoRecommendsMcAfeeToProtectAllYourDevicesIsDisplayedCorrectlyWithAvira()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.protectAllYourDevicesSectionTitle_1.Enabled);
            Assert.IsTrue(antiVirusPage.protectAllYourDevicesSectionTitle_2.Enabled);
            Assert.IsTrue(antiVirusPage.protectYourDeviceText.Enabled);
        }

        [Then(@"Verify the title of Award-Winning Antivirus is displayed correctly")]
        public void ThenVerifyTheTitleOfAward_WinningAntivirusIsDisplayedCorrectly()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.awardWinningAntivirusTitle_LSMcAfee.Enabled);
        }

        [Then(@"Verify the title of Award-Winning Antivirus is displayed correctly with Avira")]
        public void ThenVerifyTheTitleOfAward_WinningAntivirusIsDisplayedCorrectlyWithAvira()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.awardWinningantivirus.Enabled);
        }

        [Then(@"Verify the text description of Award-Winning Antivirus is displayed correctly")]
        public void ThenVerifyTheTextDescriptionOfAward_WinningAntivirusIsDisplayedCorrectly()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.awardWinningAntivirusText_LSMcAfee.Enabled);
        }

        [Then(@"Verify the title of Home network protection is displayed correctly")]
        public void ThenVerifyTheTitleOfHomeNetworkProtectionIsDisplayedCorrectly()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.homeNetworkProtectionTitle_LSMcAfee.Enabled);
        }

        [Then(@"Verify the text description of Home network protection is displayed correctly")]
        public void ThenVerifyTheTextDescriptionOfHomeNetworkProtectionIsDisplayedCorrectly()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.homeNetworkProtectionText_LSMcAfee.Enabled);
        }

        [Then(@"Verify the title of Online privacy is displayed correctly")]
        public void ThenVerifyTheTitleOfOnlinePrivacyIsDisplayedCorrectly()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.onlinePrivacyTitle_LSMcAfee.Enabled);
        }

        [Then(@"Verify the text description of Online privacy is displayed correctly")]
        public void ThenVerifyTheTextDescriptionOfOnlinePrivacyIsDisplayedCorrectly()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.onlinePrivacyText_LSMcAfee.Enabled);
        }

        [Then(@"Verify the title of Multi-device protection is displayed correctly")]
        public void ThenVerifyTheTitleOfMulti_DeviceProtectionIsDisplayedCorrectly()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.multiDeviceProtectionTitle_LSMcAfee.Enabled);
        }

        [Then(@"Verify the text description of Multi-device protection is displayed correctly")]
        public void ThenVerifyTheTextDescriptionOfMulti_DeviceProtectionIsDisplayedCorrectly()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.multiDeviceProtectionText_LSMcAfee.Enabled);
        }

        [Then(@"Verify the title of Password manager is displayed correctly")]
        public void ThenVerifyTheTitleOfPasswordManagerIsDisplayedCorrectly()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.passwordManagerTitle_LSMcAfee.Enabled);
        }

        [Then(@"Verify the text description of Password manager is displayed correctly")]
        public void ThenVerifyTheTextDescriptionOfPasswordManagerIsDisplayedCorrectly()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.passwordManagerText_LSMcAfee.Enabled);
        }

        [Then(@"Verify the title of expert technical support  is displayed correctly")]
        public void ThenVerifyTheTitleOfExpertTechnicalSupportIsDisplayedCorrectly()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.expertTechnicalSupportTitle_LSMcAfee.Enabled);
        }

        [Then(@"Verify the text description of expert technical support  is displayed correctly")]
        public void ThenVerifyTheTextDescriptionOfExpertTechnicalSupportIsDisplayedCorrectly()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.expertTechnicalSupportText_LSMcAfee.Enabled);
        }

        [When(@"Click the Privacy Policy link")]
        public void WhenClickTheVerifyPrivacyPolicyLink()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.ScrollScreen();
            antiVirusPage.privacyPolicyLink.Click();
        }

        [Then(@"Click the Privacy Policy link")]
        public void ThenClickThePrivacyPolicyLink()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.ScrollScreen();
            antiVirusPage.privacyPolicyLink.Click();
        }

        [Given(@"Click the Terms of Service link")]
        public void GivenClickTheTermsOfServiceLink()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.ScrollScreen();
            antiVirusPage.termsOfServiceLink.Click();
        }

        [Then(@"Verify it will open MacAfee Privacy Policy page")]
        public void ThenVerifyItWillOpenMacAfeePrivacyPolicyPage()
        {
            desktopSession = baseTestClass.DesktopSession();
            Thread.Sleep(10000);
            string url = desktopSession.Session.FindElementByAccessibilityId("addressEditBox").Text;
            Assert.AreEqual(WebSiteUrl.macAfeePrivacyPolicyUrl, url);
        }

        [Then(@"Verify Privacy Policy link is unclickable")]
        public void ThenVerifyPrivacyPolicyLinkIsUnclickable()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.AreEqual("text", antiVirusPage.privacyPolicyLink.GetAttribute("LocalizedControlType"));
        }


        [Then(@"Verify it will open MacAfee terms of Service page")]
        public void ThenVerifyItWillOpenMacAfeeTermsOfServicePage()
        {
            desktopSession = baseTestClass.DesktopSession();
            Thread.Sleep(15000);
            string url = desktopSession.Session.FindElementByAccessibilityId("addressEditBox").Text;
            Assert.AreEqual(WebSiteUrl.macAfeeTermsOfServiceUrl, url);
        }

        [Then(@"Verify Terms of Service link is unclickable")]
        public void ThenVerifyTermsOfServiceLinkIsUnclickable()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.AreEqual("text", antiVirusPage.termsOfServiceLink.GetAttribute("LocalizedControlType"));
        }

        [Then(@"Enjoy a better offer here is correct")]
        public void ThenEnjoyABetterOfferHereIsCorrect()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.enjoyHeaderTitle.Enabled);
        }

        [Then(@"Expand button is here and the text is correct")]
        public void ThenExpandButtonIsHereAndTheTextIsCorrect()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.AreEqual(antiVirusPage.expandString, antiVirusPage.expandMcaFeeButton.GetAttribute("Name").Trim());
            //Assert.IsTrue(antiVirusPage.expandMcaFeeButton.Enabled);
        }

        [Then(@"Collasp button is here and the test is correct")]
        public void ThenCollaspButtonIsHereAndTheTestIsCorrect()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.AreEqual(antiVirusPage.collapseString, antiVirusPage.collapseMcaFeeButton.GetAttribute("Name").Trim());
        }

        [Then(@"Click Expand button")]
        public void ThenClickExpandButton()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.expandMcaFeeButton.Click();
        }

        [Then(@"Get Mcafee button is here and the text is correct")]
        public void ThenGetMcafeeButtonIsHereAndTheTextIsCorrect()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.getMcafeeButton.Enabled);
        }

        [Then(@"Click Get Mcafee button")]
        public void ThenClickGetMcafeeButton()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.getMcafeeButton.Click();
        }

        [Then(@"open mcafee buy page and the url is correct")]
        public void ThenOpenMcafeeBuyPageAndTheUrlIsCorrect()
        {
            desktopSession = baseTestClass.DesktopSession();
            Thread.Sleep(15000);
            string url = desktopSession.Session.FindElementByAccessibilityId("addressEditBox").Text;
            Assert.AreEqual(WebSiteUrl.antiVirusSubScribeUrl, url);
        }

        [Then(@"Verify the tile of McAfee LiveSafe Protection")]
        public void ThenVerifyTheTileOfMcAfeeLiveSafeProtection()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.mcafeeLiveProtection.Enabled);
        }

        [Then(@"Verify the subscription of You are currently protected by")]
        public void ThenVerifyTheSubscriptionOfYouAreCurrentlyProtectedBy()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.youAreProtectedBy.Enabled);
        }

        [Then(@"Verify the subscription of Shield your new Lenovo PC with tested")]
        public void ThenVerifyTheSubscriptionOfShieldYourNewLenovoPCWithTested()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.sheildYourPC.Enabled);
        }

        [Then(@"Verify the title of Rock-solid performance")]
        public void ThenVerifyTheTitleOfRock_SolidPerformance()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.rockSolidPerformance.Enabled);
        }

        [Then(@"Verify the subscription of Consistent")]
        public void ThenVerifyTheSubscriptionOfConsistent()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.consistentPrecise.Enabled);
        }

        [Then(@"Verify the title of Blazing-fast speed")]
        public void ThenVerifyTheTitleOfBlazing_FastSpeed()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.blazingFastSpeed.Enabled);
        }

        [Then(@"Verify the subscription of Optimized antivirus that")]
        public void ThenVerifyTheSubscriptionOfOptimizedAntivirusThat()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.optimizedAntivirus.Enabled);
        }

        [Then(@"there is SA widget in anti-virus page")]
        public void ThenThereIsSAWidgetInAnti_VirusPage()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.securityAdvisorWidget.Enabled);
        }

        [Then(@"there is content box in anti-virus page")]
        public void ThenThereIsContentBoxInAnti_VirusPage()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.contentbox.Enabled);
        }

        [Then(@"Click content box")]
        public void ThenClickContentBox()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.contentbox.Click();
        }

        [Then(@"make sure content box open mcefee top tip")]
        public void ThenMakeSureContentBoxOpenMcefeeTopTip()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.mcAfeeTopTips.Enabled);
        }

        [Then(@"Click Collapse button")]
        public void ThenClickCollapseButton()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.collapseMcaFeeButton.Click();
        }

        [Then(@"Get Mcafee button is not here")]
        public void ThenGetMcafeeButtonIsNotHere()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyElementIsNotExist("sa-av-btn-getMcafee", "AutomationId");
        }

        [Then(@"Verify it will open MacAfee Privacy Policy page-has other av")]
        public void ThenVerifyItWillOpenMacAfeePrivacyPolicyPage_HasOtherAv()
        {
            desktopSession = baseTestClass.DesktopSession();
            WindowsElement url = desktopSession.Session.FindElementByAccessibilityId("addressEditBox");
            Assert.AreEqual(WebSiteUrl.macAfeePrivacyPolicyUrl, url.Text);
        }

    }
}
