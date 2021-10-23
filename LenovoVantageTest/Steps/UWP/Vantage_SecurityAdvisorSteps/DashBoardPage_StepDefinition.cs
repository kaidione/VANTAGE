namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Commands;
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Pages.HardwareSettingsPages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Management;
    using System.Threading;
    using TechTalk.SpecFlow;


    [Binding]
    public sealed class DashBoardPage_StepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        public CmdCommands cmdCommands;

        //private readonly InformationalWebDriver webDriver;
        private Utility.InformationalWebDriver webDriver;

        private DashBoardPage dashBoardPage;
        private SupportPage supportPage;
        private SystemUpdatePage systemUpdatePage;
        private WindowsSettingsPage windowsSettingsPage;

        private InformationalWebDriver desktopSession;
        private BaseTestClass baseTestClass = new BaseTestClass();

        public DashBoardPage_StepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Given(@"Disable Ethernet")]
        public void GivenDisableEthernet()
        {
            CmdCommands.DisableEthernet();
        }

        [Given(@"Enable Ethernet")]
        public void GivenEnableEthernet()
        {
            CmdCommands.EnableEthernet();
        }

        [Given(@"Disable WiFi")]
        public void GivenDisableWiFi()
        {
            CmdCommands.DisableWiFi();
        }

        [When(@"Disable WiFi")]
        public void WhenDisableWiFi()
        {
            CmdCommands.DisableWiFi();
        }

        [Given(@"Enable WiFi")]
        public void GivenEnableWiFi()
        {
            CmdCommands.EnableWiFi();
        }

        [When(@"disable local wifi")]
        public void WhenDisableLocalWifi()
        {
            CmdCommands.DisableWiFi();
        }

        [Given(@"disable local wifi")]
        public void GivenDisableLocalWifi()
        {
            CmdCommands.DisableWiFi();
        }

        [Given(@"Enable local wifi")]
        public void GivenEnsableLocalWifi()
        {
            CmdCommands.EnableWiFi();
        }

        [Then(@"Enable local wifi")]
        public void ThenEnableLocalWifi()
        {
            CmdCommands.EnableWiFi();
        }

        [Then(@"Enable wifi")]
        public void ThenEnableWifi()
        {
            CmdCommands.EnableWiFi();
        }

        [Given(@"Disable Adapter")]
        public void GivenDisableAdapter()
        {
            CmdCommands.DisableAdapter();
        }

        [Given(@"Enable Adapter")]
        public void GivenEnableAdapter()
        {
            CmdCommands.EnableAdapter();
        }

        [Given(@"Dashboard page is opened")]
        public void GivenDashboardPageIsOpened()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            Assert.IsTrue(dashBoardPage.navlnkdashboard.Displayed);
        }

        [Given(@"Go to dashboad page")]
        public void GivenGoToDashboadPage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            Thread.Sleep(10000);
        }


        [Given(@"Go to security page")]
        public void GivenGoToSecurityPage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.securityTab.Click();
        }

        [Given(@"Go to My security page")]
        public void GivenGoToMySecurityPage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.mySecurityLink.Click();
        }

        [When(@"Go to My security page")]
        public void WhenGoToMySecurityPage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.mySecurityLink.Click();
        }

        [Given(@"Go To Anti Virus Page")]
        public void GivenGoToAntiVirusPage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.antiVriusLink.Click();
        }

        [When(@"Go To Anti Virus Page")]
        public void WhenGoToAntiVirusPage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.antiVriusLink.Click();
        }

        [Given(@"Go To Password Health Page")]
        public void GivenGoToPasswordHealthPage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.passwordHealthLink.Click();
        }

        [Given(@"Logout Vantage")]
        public void GivenLogoutVantage()
        {
            Common.KillProcess(VantageConstContent.VantageProcessName, true);
        }

        [Then(@"Verify Welcome Header Not Show On Homepage")]
        public void ThenVerifyWelcomeHeaderNotShowOnHomepage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            Assert.IsFalse(dashBoardPage.IsAutoIDPresent("dashboard-header-title"));
        }

        [Then(@"Verify Hero banner show on homepage")]
        public void ThenVerifyHeroBannerShowOnHomepage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            Assert.IsTrue(dashBoardPage.heroBanner.Displayed);
        }

        [Then(@"Verify contentBoxB and contentBoxC show on homepage")]
        public void ThenVerifyContentBosBAndContentBosCShowOnHomepage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            Assert.IsTrue(dashBoardPage.contentBoxB.Displayed);
            Assert.IsTrue(dashBoardPage.contentBoxC.Displayed);
        }

        [Then(@"Verify contentBoxD show on homepage")]
        public void ThenVerifyContentBoxDShowOnHomepage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            //dashBoardPage.ScrollScreen();
            Assert.IsTrue(dashBoardPage.contentBoxD.Enabled);
        }

        [Then(@"Verify contentBoxE and contentBoxF banner show on homepage")]
        public void ThenVerifyContentBoxEAndContentBoxFBannerShowOnHomepage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            //dashBoardPage.ScrollScreen();
            Assert.IsTrue(dashBoardPage.contentBoxE.Enabled);
            Assert.IsTrue(dashBoardPage.contentBoxF.Enabled);
        }

        [Then(@"Verify positionB show (.*)")]
        public void ThenVerifyPositionBShow(string defaultText)
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            string pBText = dashBoardPage.contentBoxB.GetAttribute("Name");
            Assert.AreEqual(defaultText, pBText);
        }

        [Then(@"Verify positionA show (.*)")]
        public void ThenVerifyPositionAShow(string defaultText)
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            string pAText = dashBoardPage.positionA.GetAttribute("Name");
            Assert.AreEqual(defaultText, pAText);
        }

        [Then(@"Verify positionC show (.*)")]
        public void ThenVerifyPositionCShow(string defaultText)
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            string pCText = dashBoardPage.contentBoxC.GetAttribute("Name");
            Assert.AreEqual(defaultText, pCText);
        }

        [Then(@"Verify positionD show (.*)")]
        public void ThenVerifyPositionDShow(string defaultText)
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            string pDText = dashBoardPage.contentBoxD.GetAttribute("Name");
            Assert.AreEqual(defaultText, pDText);
        }

        [Then(@"Verify positionE show (.*)")]
        public void ThenVerifyPositionEShow(string defaultText)
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            string pEText = dashBoardPage.contentBoxE.GetAttribute("Name");
            Assert.AreEqual(defaultText, pEText);
        }

        [Then(@"Verify positionF show (.*)")]
        public void ThenVerifyPositionFShow(string defaultText)
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            string pFText = dashBoardPage.contentBoxF.GetAttribute("Name");
            Assert.AreEqual(defaultText, pFText);
        }

        [Then(@"Verify disconnect notice exist")]
        public void ThenVerifyDisconnectNoticeExist()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            Assert.AreEqual("No internet connection detected", dashBoardPage.disconnectNotice.Text);
        }

        [Given(@"Click memory Link")]
        public void GivenClickMemoryLink()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.memoryStatus.Click();
            Thread.Sleep(3000);
        }

        [Then(@"Verify memory link to the Setting About page")]
        public void ThenVerifyMemoryLinkToTheSettingAboutPage()
        {

            desktopSession = baseTestClass.DesktopSession();
            WindowsElement contentLabel_OnMemorySetting = desktopSession.Session.FindElementByAccessibilityId("SystemSettings_PCSystem_ShieldProviderCollection_ContentLabel");
            Assert.IsTrue(contentLabel_OnMemorySetting.Displayed);
        }

        [Then(@"Click Disk Status Link")]
        public void ThenClickDiskStatusLink()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.diskStatus.Click();
            Thread.Sleep(3000);
        }

        [Then(@"Verify Disk Status link to the Setting Storage page")]
        public void ThenVerifyDiskStatusLinkToTheSettingStoragePage()
        {
            desktopSession = baseTestClass.DesktopSession();
            WindowsElement contentLabel_OnDiskSpaceSetting = desktopSession.Session.FindElementByAccessibilityId("SystemSettings_StorageSense_SmartStoragePoliciesLink_HyperlinkButton");
            Assert.IsTrue(contentLabel_OnDiskSpaceSetting.Displayed);
        }

        [Then(@"Click Warrantly Link")]
        public void ThenClickWarrantlyLink()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.warrantyStatus.Click();
        }

        [Then(@"Verify Disk Status link to the Support page")]
        public void ThenVerifyDiskStatusLinkToTheSupportPage()
        {
            supportPage = new SupportPage(webDriver.Session);
            supportPage.VerifyContentAreEqual("Give Feedback", supportPage.givefeedbacktitle);
        }

        [Then(@"click System Update Link")]
        public void ThenClickSystemUpdateLink()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.systemUpdateStatus.Click();
        }

        [Then(@"Verify Disk Status link to the System Update page")]
        public void ThenVerifyDiskStatusLinkToTheSystemUpdatePage()
        {
            systemUpdatePage = new SystemUpdatePage(webDriver.Session);
            Thread.Sleep(2000);
            Assert.True(systemUpdatePage.auto_updates_title.Displayed);
        }


        [Given(@"Click on Hero banner")]
        public void GivenClickOnHeroBanner()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.heroBanner.Click();
        }

        [Given(@"Click on contentBoxB")]
        public void GivenClickOnContentBoxB()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            Thread.Sleep(10000);
            dashBoardPage.contentBoxB.Click();
            //Thread.Sleep(10000);
        }

        [Given(@"Click on contentBoxC")]
        public void GivenClickOnContentBoxC()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            Thread.Sleep(8000);
            dashBoardPage.contentBoxC.Click();
            //Thread.Sleep(8000);
        }

        [Given(@"Click on contentBoxD")]
        public void GivenClickOnContentBoxD()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            //dashBoardPage.ScrollScreen();
            Thread.Sleep(8000);
            dashBoardPage.contentBoxD.Click();
            //Thread.Sleep(10000);
        }

        [Given(@"Click on contentBoxE")]
        public void GivenClickOnContentBoxE()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            Thread.Sleep(10000);
            //dashBoardPage.ScrollScreen();
            dashBoardPage.contentBoxE.Click();
            //Thread.Sleep(20000);
        }

        [Given(@"Click on contentBoxF")]
        public void GivenClickOnContentBoxF()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            //dashBoardPage.ScrollScreen();
            Thread.Sleep(10000);
            dashBoardPage.contentBoxF.Click();
            //Thread.Sleep(10000);
        }

        [Then(@"CLose The Article")]
        public void ThenCLoseTheArticle()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);

            string articleCloseButtonLocator = "article-close-button";

            if (IsElementPresent(articleCloseButtonLocator))
            {
                WindowsElement articleCloseButton = webDriver.Session.FindElementByAccessibilityId(articleCloseButtonLocator);
                articleCloseButton.Click();
            }

        }

        [Then(@"Verify the internal link will load a article")]
        public void ThenVerifyTheInternalLinkWillLoadAArticle()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            Assert.IsTrue(dashBoardPage.articleTitle.Displayed);
        }

        [Then(@"Verify there are no “no such key” error show")]
        public void ThenVerifyThereAreNoNoSuchKeyErrorShow()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.VerifyErrorIsNoExist();
        }

        [Then(@"Verify positionB not show (.*)")]
        public void ThenVerifyPositionBNotShow(string defaultText)
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            string pBText = dashBoardPage.contentBoxB.GetAttribute("Name");
            Assert.AreNotEqual(defaultText, pBText);
        }


        [Then(@"Verify positionA not show (.*)")]
        public void ThenVerifyPositionANotShow(string defaultText)
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            string pAText = dashBoardPage.positionA.GetAttribute("Name");
            Assert.AreNotEqual(defaultText, pAText);
        }
        [Then(@"Verify positionC not show (.*)")]
        public void ThenVerifyPositionCNotShow(string defaultText)
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            string pCText = dashBoardPage.contentBoxC.GetAttribute("Name");
            Assert.AreNotEqual(defaultText, pCText);
        }

        [Then(@"Verify positionD not show (.*)")]
        public void ThenVerifyPositionDNotShow(string defaultText)
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            string pDText = dashBoardPage.contentBoxD.GetAttribute("Name");
            Assert.AreNotEqual(defaultText, pDText);
        }

        [Then(@"Verify positionE not show (.*)")]
        public void ThenVerifyPositionENotShow(string defaultText)
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            string pEText = dashBoardPage.contentBoxE.GetAttribute("Name");
            Assert.AreNotEqual(defaultText, pEText);
        }

        [Then(@"Verify positionF not show (.*)")]
        public void ThenVerifyPositionFNotShow(string defaultText)
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            string pFText = dashBoardPage.contentBoxF.GetAttribute("Name");
            Assert.AreNotEqual(defaultText, pFText);
        }

        [Then(@"Verify the External link will open Chrome Edge browser and load the target link premier Support Url")]
        public void ThenVerifyTheExternalLinkWillOpenChromeEdgeBrowserAndLoadTheTargetLinkPremierSupportUrl()
        {
            desktopSession = baseTestClass.DesktopSession();
            Thread.Sleep(60000);
            string actualUrl = desktopSession.Session.FindElementByAccessibilityId("view_1020").GetAttribute("LegacyIAccessible.Value");
            Assert.AreEqual(WebSiteUrl.premierSupportUrl_Chrome, actualUrl);
        }

        [Then(@"Verify the External link will open Chrome Edge browser and load the target link lenovo Accessories Url")]
        public void ThenVerifyTheExternalLinkWillOpenChromeEdgeBrowserAndLoadTheTargetLinkLenovoAccessoriesUrl()
        {
            desktopSession = baseTestClass.DesktopSession();
            string actualUrl = desktopSession.Session.FindElementByAccessibilityId("view_1020").Text;
            Assert.AreEqual(WebSiteUrl.lenovoAccessoriesUrl_Chrome, actualUrl);
        }

        [Then(@"Close the Browser for Edge")]
        public void ThenCloseTheBrowserForEdge()
        {
            Process[] processes = Process.GetProcessesByName("MicrosoftEdge");

            foreach (Process process in processes)
            {
                process.Kill();
                process.WaitForExit();
                process.Dispose();
            }
        }

        [Given(@"click preference setting in the drop down menu")]
        public void GivenClickPreferenceSettingInTheDropDownMenu()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.userBar);
            dashBoardPage.preferenceSettingsLink.Click();
        }

        [Then(@"Click BACK lINK")]
        public void ThenClickBACKLINK()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Verfiy the Extenal link will open default web browser and load the target link privacy Url")]
        public void ThenVerfiyTheExtenalLinkWillOpenDefaultWebBrowserAndLoadTheTargetLinkPrivacyUrl()
        {
            desktopSession = baseTestClass.DesktopSession();
            Thread.Sleep(3000);
            string actualUrl = desktopSession.Session.FindElementByAccessibilityId("addressEditBox").Text;
            //WindowsElement url = desktopSession.Session.FindElementByAccessibilityId("addressEditBox");
            Assert.AreEqual(WebSiteUrl.privacyUrl_ContentB, actualUrl);
        }

        [Then(@"Verfiy the Extenal link will open default web browser and load the target link Dashlane Url")]
        public void ThenVerfiyTheExtenalLinkWillOpenDefaultWebBrowserAndLoadTheTargetLinkDashlaneUrl()
        {
            desktopSession = baseTestClass.DesktopSession();
            string actualUrl = desktopSession.Session.FindElementByAccessibilityId("addressEditBox").Text;
            //WindowsElement url = desktopSession.Session.FindElementByAccessibilityId("addressEditBox");
            Assert.AreEqual(WebSiteUrl.dashlaneUrl_ContentD, actualUrl);
        }


        [Then(@"Verfiy the Extenal link will open default web browser and load the target link premier Support Url")]
        public void ThenVerfiyTheExtenalLinkWillOpenDefaultWebBrowserAndLoadTheTargetLinkPremierSupportUrl()
        {
            desktopSession = baseTestClass.DesktopSession();
            Thread.Sleep(3000);
            string actualUrl = desktopSession.Session.FindElementByAccessibilityId("addressEditBox").Text;
            //WindowsElement url = desktopSession.Session.FindElementByAccessibilityId("addressEditBox");
            Assert.AreEqual(WebSiteUrl.premierSupportUrl_ContentE, actualUrl);
        }

        [Then(@"Verfiy the Extenal link will open default web browser and load the target link lenovo Accessories Url")]
        public void ThenVerfiyTheExtenalLinkWillOpenDefaultWebBrowserAndLoadTheTargetLinkLenovoAccessoriesUrl()
        {
            desktopSession = baseTestClass.DesktopSession();
            string actualUrl = desktopSession.Session.FindElementByAccessibilityId("addressEditBox").Text;
            Assert.AreEqual(WebSiteUrl.lenovoAccessoriesUrl_ContentF, actualUrl);
        }

        [Given(@"Minimize the window")]
        public void GivenMinimizeTheWindow()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            //webDriver.Session.Manage().Window.Minimize();
            int newWidth = 10;
            int newHight = 10;
            webDriver.Session.Manage().Window.Size = new Size(newWidth, newHight);
        }


        [Given(@"Reopen the window")]
        [StepDefinition(@"Maximize Vatnage")]
        public void GivenReopenTheWindow()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            webDriver.Session.Manage().Window.Maximize();
        }

        [Then(@"Check there is no energy star logo shows in dashboard page")]
        public void ThenCheckThereIsNoEnergyStarLogoShowsInDashboardPage()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            //dashBoardPage.ScrollScreen();
            dashBoardPage.VerifyArmLogoNotExist();
        }

        [When(@"Click on the first Hero banner slide")]
        public void WhenClickOnTheFirstHeroBannerSlide()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.heroBanner_Slide_1.Click();
        }

        [Then(@"CLick on the first Hero banner")]
        public void ThenCLickOnTheFirstHeroBanner()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.heroBanner_1.Click();
            Thread.Sleep(5000);
        }

        [Then(@"Then Verfiy the Extenal link will open default web browser and load the target link macFee Url")]
        public void ThenThenVerfiyTheExtenalLinkWillOpenDefaultWebBrowserAndLoadTheTargetLinkMacFeeUrl()
        {
            desktopSession = baseTestClass.DesktopSession();
            string actualUrl = desktopSession.Session.FindElementByAccessibilityId("addressEditBox").Text;
            Assert.AreEqual(WebSiteUrl.macFeeUrl_Dashboard_ContentA_Slie1, actualUrl);
        }

        [Then(@"the dashboard works normal")]
        public void ThenTheDashboardWorksNormal()
        {
            ThenVerifyHeroBannerShowOnHomepage();
            ThenVerifyContentBosBAndContentBosCShowOnHomepage();
            ThenVerifyContentBoxDShowOnHomepage();
            ThenVerifyContentBoxEAndContentBoxFBannerShowOnHomepage();
        }

        [Then(@"Check the task manager and make sure CPU and Memory won not take up more than (.*)%")]
        public void ThenCheckTheTaskManagerAndMakeSureCPUAndMemoryWonNotTakeUpMoreThan(int p0)
        {
            Thread.Sleep(5000);
            double CPUUsage;

            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuCounter.NextValue();
            Thread.Sleep(1000);
            CPUUsage = cpuCounter.NextValue();
            Console.WriteLine(CPUUsage);
            Assert.IsTrue(CPUUsage < 80 && CPUUsage > 0);

            double capacity = 0, available = 0;

            //Get Memory capacity
            ManagementClass cimobject1 = new ManagementClass("Win32_PhysicalMemory");
            ManagementObjectCollection moc1 = cimobject1.GetInstances();
            foreach (ManagementObject mo1 in moc1)
            {
                capacity += ((Math.Round(Int64.Parse(mo1.Properties["Capacity"].Value.ToString()) / 1024 / 1024 / 1024.0, 1)));
            }
            moc1.Dispose();
            cimobject1.Dispose();

            //Get memory available
            ManagementClass cimobject2 = new ManagementClass("Win32_PerfFormattedData_PerfOS_Memory");
            ManagementObjectCollection moc2 = cimobject2.GetInstances();
            foreach (ManagementObject mo2 in moc2)
            {
                available += ((Math.Round(Int64.Parse(mo2.Properties["AvailableMBytes"].Value.ToString()) / 1024.0, 1)));

            }
            moc2.Dispose();
            cimobject2.Dispose();

            double MemoryUsage = Math.Round((capacity - available) / capacity * 100, 0);
            Console.WriteLine(MemoryUsage);
            Assert.IsTrue(MemoryUsage < 80 && MemoryUsage > 0);
        }

        [Then(@"Make sure the CPU and Memory usage will not continue to grow for a long time when (.*)")]
        public void ThenMakeSureTheCPUAndMemoryUsageWillNotContinueToGrowForALongTimeWhenDoTest(string test)
        {
            ScenarioContext.Current.Pending();
        }

        private bool IsElementPresent(string locator)
        {
            try
            {
                webDriver.Session.FindElementByAccessibilityId(locator);
                return true;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }

        [When(@"Hover/Click on the Security button on the common header")]
        public void WhenHoverClickOnTheSecurityButtonOnTheCommonHeader()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
        }


        [Then(@"Hover/Click on the Security button on the common header")]
        public void ThenHoverClickOnTheSecurityButtonOnTheCommonHeader()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
        }

        [Then(@"Verify the SA drop-down list contains My security Anti-Virus Password Health WiFi Security and VPN Security")]
        public void ThenVerifyTheSADrop_DownListContainsMySecurityAnti_VirusPasswordHealthWiFiSecurityAndVPNSecurity()
        {
            Assert.IsTrue(dashBoardPage.mySecurityLink.Enabled);
            Assert.IsTrue(dashBoardPage.antiVriusLink.Enabled);
            Assert.IsTrue(dashBoardPage.passwordHealthLink.Enabled);
            Assert.IsTrue(dashBoardPage.wifiSecurityLink.Enabled);
            Assert.IsTrue(dashBoardPage.vpnSecurityLink.Enabled);
        }
    }
}
