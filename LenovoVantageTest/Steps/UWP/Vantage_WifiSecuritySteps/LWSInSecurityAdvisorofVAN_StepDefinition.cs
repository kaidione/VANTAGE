using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Pages.WifiSecurityPages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;
using Windows.UI.Notifications;

namespace LenovoVantageTest.Steps.UWP.Vantage_WifiSecuritySteps
{

    [Binding]
    public sealed class WIFISecurityPage_StepDefinition : SettingsBase
    {
        private InformationalWebDriver webDriver;
        private LenovoWifiSecurityPage _lenovoWifiSecurityPage;
        public IntelligentCoolingBaseHelper IntelligentCoolingBaseHelper;
        public CHSWebEnvPage CHSWebEnvPage;
        public string WifiContent = "How does it work? It works by detecting and analyzing, in real-time, potential security threats from unsafe wireless networks and compares them against a database of known network and security vulnerabilities. This can protect users from risks of connecting to unsafe wireless networks by distinguishing between legitimate and risky, possibly malicious, networks.";

        public WIFISecurityPage_StepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [StepDefinition(@"LWS Text Status is (.*)")]
        public void WhenLWSStatusIs(string p0)
        {
            _lenovoWifiSecurityPage = new LenovoWifiSecurityPage(webDriver.Session);
            var WSStatusText = _lenovoWifiSecurityPage.WSStatusText.GetAttribute("Name");
            var WSWifiToggleStatus = _lenovoWifiSecurityPage.WifiToggle.GetAttribute("Name");
            switch (p0.ToLower())
            {
                case "enabled":
                    Assert.AreEqual("ENABLED", WSStatusText, "Wifi Status is not enabled");
                    Assert.AreEqual("WIFI SECURITY ENABLED", WSWifiToggleStatus, "Wifi Status is not enabled");
                    break;
                case "disabled":
                    Assert.AreEqual("DISABLED", WSStatusText, "Wifi Status is not disabled");
                    Assert.AreEqual("WIFI SECURITY DISABLED", WSWifiToggleStatus, "Wifi Status is not disabled");
                    break;
                default:
                    throw new Exception(string.Format("There's no {0} such status", p0));
            }
        }

        [Then(@"There is no (.*) in Wifi Page")]
        public void ThenThereIsNoThreatLocatorInLWSPage(string p0)
        {
            _lenovoWifiSecurityPage = new LenovoWifiSecurityPage(webDriver.Session);
            switch (p0)
            {
                case "Threat locator":
                    Assert.IsNull(_lenovoWifiSecurityPage.WifiCheckThreatBtn, "Threat locator still exist");
                    break;
                case "Enable wifi security Btn":
                    Assert.IsNull(_lenovoWifiSecurityPage.WifiEnableWifiSecurityBtn, "Enable WS button still exist");
                    break;
                case "show more button":
                    Assert.IsNull(_lenovoWifiSecurityPage.ShowMoreBtn, "Show more button still exist");
                    break;
                default:
                    throw new Exception(string.Format("There's no {0} such status", p0));
            }
        }

        [Then(@"There is (.*) in LWS Page")]
        public void ThenThereIsNetworkHistoryTitleInLWSPage(string p0)
        {
            _lenovoWifiSecurityPage = new LenovoWifiSecurityPage(webDriver.Session);
            switch (p0)
            {
                case "network history title":
                    Assert.IsNotNull(_lenovoWifiSecurityPage.WifiNetworkHistoryTitle, "Wifi network history title not found");
                    break;
                case "expand link":
                    Assert.IsNotNull(_lenovoWifiSecurityPage.WifiExpandBtn, "There's no expand button");
                    break;
                case "location dialog":
                    Assert.IsNotNull(_lenovoWifiSecurityPage.LocationDialogAgreeBtn, "Location dialog has not pop up");
                    Assert.IsNotNull(_lenovoWifiSecurityPage.LocationDialogCloseBtn, "Location dialog has not pop up");
                    Assert.IsNotNull(_lenovoWifiSecurityPage.LocationDialogCancelnBtn, "Location dialog has not pop up");
                    break;
                case "show more button":
                    Assert.IsNotNull(_lenovoWifiSecurityPage.ShowMoreBtn, "Show more button not exist");
                    break;
                case "show less button":
                    Assert.IsNotNull(_lenovoWifiSecurityPage.ShowLessBtn, "Show less button not exist");
                    break;
                case "expandstatus":
                    Assert.IsTrue(_lenovoWifiSecurityPage.WifiExpandBtn.GetAttribute("AriaProperties").Contains("expanded=true"), "link not expand");
                    break;
                case "LWSIntroduction":
                    Assert.IsTrue(_lenovoWifiSecurityPage.WifiIntroduction.GetAttribute("Name").Equals(WifiContent), "LWSIntroduction not exist"); ;
                    break;
                default:
                    throw new Exception(string.Format("There's no {0} such status", p0));
            }
        }

        [When(@"Click (.*) in LWS Page")]
        public void WhenClickExpandButtonInLWSPage(string p0)
        {
            _lenovoWifiSecurityPage = new LenovoWifiSecurityPage(webDriver.Session);
            switch (p0)
            {
                case "expand button":
                    Assert.IsNotNull(_lenovoWifiSecurityPage.WifiExpandBtn, "There's no expand button");
                    _lenovoWifiSecurityPage.WifiExpandBtn.Click();
                    break;
                case "location dialog close button":
                    Assert.IsNotNull(_lenovoWifiSecurityPage.LocationDialogCloseBtn, "Location dialog has not pop up");
                    _lenovoWifiSecurityPage.LocationDialogCloseBtn.Click();
                    break;
                case "location dialog agree button":
                    Assert.IsNotNull(_lenovoWifiSecurityPage.LocationDialogAgreeBtn, "Location dialog has not pop up");
                    _lenovoWifiSecurityPage.LocationDialogAgreeBtn.Click();
                    break;
                case "show more button":
                    Assert.IsNotNull(_lenovoWifiSecurityPage.ShowMoreBtn, "There's no show more button");
                    _lenovoWifiSecurityPage.ShowMoreBtn.Click();
                    break;
                case "show less button":
                    Assert.IsNotNull(_lenovoWifiSecurityPage.ShowLessBtn, "There's no show less button");
                    _lenovoWifiSecurityPage.ShowLessBtn.Click();
                    break;
                case "wifi link in SA":
                    Assert.IsNotNull(_lenovoWifiSecurityPage.WifiLinkInAS, "Wifi security link not in AS");
                    _lenovoWifiSecurityPage.WifiLinkInAS.Click();
                    break;
                case "lwstab":
                    Assert.IsNotNull(_lenovoWifiSecurityPage.WifiTab, "There's LWS Tab");
                    _lenovoWifiSecurityPage.WifiTab.Click();
                    break;
                case "expand":
                    Assert.IsNotNull(_lenovoWifiSecurityPage.WifiExpandBtn, "There's no expand button");
                    bool expand = _lenovoWifiSecurityPage.WifiExpandBtn.GetAttribute("AriaProperties").Contains("expanded=true");
                    if (!expand)
                    {
                        _lenovoWifiSecurityPage.WifiExpandBtn.Click();
                    }
                    break;
                case "collapse":
                    Assert.IsNotNull(_lenovoWifiSecurityPage.WifiExpandBtn, "There's no expand button");
                    expand = _lenovoWifiSecurityPage.WifiExpandBtn.GetAttribute("AriaProperties").Contains("expanded=true");
                    if (expand)
                    {
                        _lenovoWifiSecurityPage.WifiExpandBtn.Click();
                    }
                    break;
                case "gamingdevice":
                    Assert.IsNotNull(_lenovoWifiSecurityPage.GamingDevice, "There's no GamingDevice button");
                    _lenovoWifiSecurityPage.GamingDevice.Click();
                    break;
                case "seticon":
                    Assert.IsNotNull(_lenovoWifiSecurityPage.GamingSetIcon, "There's no GamingSetIcon button");
                    _lenovoWifiSecurityPage.GamingSetIcon.Click();
                    break;
                case "homepagetoggleoff":
                    Assert.IsNotNull(_lenovoWifiSecurityPage.GamingWiFiSecurityToggleOff, "There's no homepage toggle off button");
                    _lenovoWifiSecurityPage.GamingWiFiSecurityToggleOff.Click();
                    break;
                default:
                    throw new Exception(string.Format("There's no {0} such status", p0));
            }
        }

        [When(@"Connect (.*) Wifi")]
        public void WhenConnectWifi(string p0)
        {
            IntelligentCoolingBaseHelper = new IntelligentCoolingBaseHelper();
            switch (p0)
            {
                case "4":
                    IntelligentCoolingBaseHelper.ConnectWiFi("SmartStorage_5G");
                    Thread.Sleep(15000);
                    IntelligentCoolingBaseHelper.ConnectWiFi("lenovo-guest");
                    Thread.Sleep(15000);
                    IntelligentCoolingBaseHelper.ConnectWiFi("lenovo-internet");
                    Thread.Sleep(15000);
                    IntelligentCoolingBaseHelper.ConnectWiFi("autolea");
                    Thread.Sleep(15000);
                    break;
                case "other 4":
                    IntelligentCoolingBaseHelper.ConnectWiFi("AutoTest");
                    Thread.Sleep(15000);
                    IntelligentCoolingBaseHelper.ConnectWiFi("__Do_Not_Trust_Network_Yellow_1");
                    Thread.Sleep(15000);
                    IntelligentCoolingBaseHelper.ConnectWiFi("__Do_Not_Trust_Network_Red_1");
                    Thread.Sleep(15000);
                    IntelligentCoolingBaseHelper.ConnectWiFi("Do_Not_Trust_Yellow_Network_1");
                    Thread.Sleep(15000);
                    break;
                case "one more":
                    IntelligentCoolingBaseHelper.ConnectWiFi("Do_Not_Trust_Yellow_Network_0");
                    Thread.Sleep(15000);
                    break;
                default:
                    throw new Exception(string.Format("There's no {0} such status", p0));
            }
        }

        [Then(@"Scroll Screen to Visit Button")]
        public void ThenScrollScreenToVisitButton()
        {
            CHSWebEnvPage = new CHSWebEnvPage(webDriver.Session);
            ScrollScreenToWindowsElement(webDriver.Session, CHSWebEnvPage.VisitButton);
        }

        [Then(@"Click Critical (.*) button")]
        public void ThenClickCriticalButton(string p0)
        {
            _lenovoWifiSecurityPage = new LenovoWifiSecurityPage(webDriver.Session);
            switch (p0)
            {
                case "ignore":
                    _lenovoWifiSecurityPage.ClickCriticalButton("Ignore");
                    break;
                case "change connection":
                    _lenovoWifiSecurityPage.ClickCriticalButton("Change connection");
                    break;
                case "moreinfo":
                    _lenovoWifiSecurityPage.ClickCriticalButton("moreinfo");
                    break;
                default:
                    throw new Exception(string.Format("There's no {0} such status", p0));
            }
        }

        [StepDefinition(@"Click (.*) Toast")]
        public void ThenClickToast(string p0)
        {
            FindAndClickNotificationCenter(20);
            switch (p0)
            {
                case "re-enable":
                    ClickToastMessageBtn(ClickButton.Reenable_Btn);
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    FindAndClickNotificationCenter(20);
                    break;
                case "yellow ignore":
                    ClickToastMessageBtn(ClickButton.Ignore_Btn);
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    FindAndClickNotificationCenter(20);
                    break;
                case "no thanks":
                    ClickToastMessageBtn(ClickButton.NoThanks_Btn);
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    FindAndClickNotificationCenter(20);
                    break;
                case "ok":
                    ClickToastMessageBtn(ClickButton.OK_Btn);
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    FindAndClickNotificationCenter(20);
                    break;
                case "change connection":
                    ClickToastMessageBtn(ClickButton.Change_Btn);
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    break;
                case "close":
                    ClickToastMessageBtn(ClickButton.Close_Btn);
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    FindAndClickNotificationCenter(20);
                    break;
                case "content":
                    _lenovoWifiSecurityPage = new LenovoWifiSecurityPage(webDriver.Session);
                    _lenovoWifiSecurityPage.ClickContentButton();
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                    FindAndClickNotificationCenter(20);
                    break;
                default:
                    throw new Exception(string.Format("There's no {0} such status", p0));
            }
        }

        [Given(@"Clear Notification Center History")]
        public void GivenClearNotificationCenterHistory()
        {
            _lenovoWifiSecurityPage = new LenovoWifiSecurityPage(webDriver.Session);
            ToastNotificationManager.History.Clear(LoadSpecificElementFile.ApplicationId);
        }

        [Then(@"Wifi Security is (.*) in Advance Security")]
        public void ThenWifiSecurityIsInAdvanceSecurity(string p0)
        {
            _lenovoWifiSecurityPage = new LenovoWifiSecurityPage(webDriver.Session);
            var WSStatusInAS = _lenovoWifiSecurityPage.WifiStatusInAdvanceSecurity.GetAttribute("Name");
            switch (p0.ToLower())
            {
                case "enabled":
                    Assert.AreEqual("ENABLED", WSStatusInAS, "Wifi Status is not enabled");
                    break;
                case "disabled":
                    Assert.AreEqual("DISABLED", WSStatusInAS, "Wifi Status is not disabled");
                    break;
            }
        }

        [Given(@"Go to Advanced Security")]
        public void GivenGoToAdvancedSecurity()
        {
            _lenovoWifiSecurityPage = new LenovoWifiSecurityPage(webDriver.Session);
            Process.Start("lenovo-vantage3:security");
            Assert.IsNotNull(_lenovoWifiSecurityPage.AdvancedSecurity, "can't find advanced security");
            _lenovoWifiSecurityPage.AdvancedSecurity.Click();
        }

        [Then(@"The HomeWifiToggle is ""(.*)""")]
        public void ThenTheIs(string p0)
        {
            _lenovoWifiSecurityPage = new LenovoWifiSecurityPage(webDriver.Session);
            if (p0.ToLower() == "on")
            {
                Assert.IsNotNull(_lenovoWifiSecurityPage.GamingWiFiSecurityToggleOn, "Wifitoggle is not on");
            }
            else
            {
                Assert.IsNotNull(_lenovoWifiSecurityPage.GamingWiFiSecurityToggleOff, "Wifitoggle is not off");
            }
        }

        [When(@"Set the WiFi Security Toggle '(.*)' Within Homepage")]
        public void WhenSetTheWiFiSecurityToggleWithinHomepage(string p0)
        {
            _lenovoWifiSecurityPage = new LenovoWifiSecurityPage(webDriver.Session);
            bool status = false;
            if (p0.ToLower() == "on")
            {
                status = _lenovoWifiSecurityPage.SetButtonBoxStatus("ON", LenovoWifiSecurityPage.HomepageToggleGaming, webDriver.Session);
            }
            else if (p0.ToLower() == "off")
            {
                status = _lenovoWifiSecurityPage.SetButtonBoxStatus("OFF", LenovoWifiSecurityPage.HomepageToggleGaming, webDriver.Session);
            }
            else
            {
                Assert.Fail("Wifi toggle has no such status");
            }
            Assert.IsTrue(status, "The status is not set success");
        }

        [Given(@"Click Windows NotificationCenter")]
        public void GivenClickWindowsNotificationCenter()
        {
            FindAndClickNotificationCenter(20);
        }

        [Given(@"Install (.*) Shell")]
        public void GivenInstallOldShell(string p0)
        {
            if (p0 == "Old")
            {
                VantageCommonHelper.InstallVantage(true, true, false);
            }
            else
            {
                VantageCommonHelper.InstallVantage(true, false, true);
            }
            var vantageSession = VantageCommonHelper.LaunchSystemUwp(VantageConstContent.VantageUwpAppid);
            VantageCommonHelper.OObeNetVantage30(vantageSession, true);
            webDriver = new InformationalWebDriver(vantageSession, vantageSession);
        }

        [When(@"Delete VantageXML")]
        public void WhenDeleteVantageXML()
        {
            string path = string.Format(@"Packages\{0}\LocalState\VantageConfig.xml", VantageConstContent.GetVantageUwpAppName() + "_k1h2ywk1493x8");
            string VantageXML = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), path);
            try
            {
                if (File.Exists(VantageXML))
                {
                    File.Delete(VantageXML);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}