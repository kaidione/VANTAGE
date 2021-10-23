using AventStack.ExtentReports.Gherkin.Model;
using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Threading;
using System.Windows.Automation;
using TangramTest.Utility;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_ConnectedHomeSecurity
{
    [Binding]
    public class VAN19299_NotifyUserThatLocationServicesAreDisabledSteps
    {
        private InformationalWebDriver _webDriver;
        private CHSWebEnvPage _CHSWebEnvPage;
        private CHSMarketingPage _CHSMarketingPage;
        private CHSAdminPage _CHSAdminPage;

        public VAN19299_NotifyUserThatLocationServicesAreDisabledSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"User has Joined or Started a CHS ""(.*)""Group")]
        public void GivenUserHasJoinedOrStartedAChsGroup(string p0)
        {
            _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
            _CHSMarketingPage.GoToCHS();
            _CHSMarketingPage.OObeCHS();
            _CHSMarketingPage.JoinCHSGroup(p0);
        }

        [Given(@"Location for Vantage has been Enabled")]
        public void GivenLocationForVantageHasBeenEnabled()
        {
            CHSWebEnvPage.SetLocationServiceAndPermisson("On", "On");
        }

        [When(@"Check CHS Subpage")]
        public void WhenCheckCHSSubpage()
        {
            _CHSWebEnvPage = new CHSWebEnvPage(_webDriver.Session);
            _CHSWebEnvPage.GoToCHS();
        }

        [Then(@"User Can See Admin/Secondary Console Normally")]
        public void ThenUserCanSeeAdminSecondaryConsoleNormally()
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            Assert.IsNotNull(_CHSAdminPage.CHSFamilyMember, "The FamilyMember text not found");
            Assert.IsNotNull(_CHSAdminPage.PasswordProtection, "The passwordProtection text not found");
        }

        [Given(@"Keep CHS Subpage Open")]
        public void GivenGivenKeepCHSSubpageOpen()
        {
            _CHSWebEnvPage = new CHSWebEnvPage(_webDriver.Session);
            _CHSWebEnvPage.GoToCHS();
        }

        [Given(@"Turn off Location Permission for Vantage")]
        public void GivenTurnOffLocationPermissionForVantage()
        {
            CHSWebEnvPage.SetLocationServiceAndPermisson("On", "Off");
        }

        [Then(@"Disable Location Banner Show up and User Can't See Admin/Secondary Console")]
        public void ThenDisableLocationBannerShowUpAndUserCanTSeeAdminSecondaryConsole()
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            Assert.IsNotNull(_CHSAdminPage.CHSGoToSetting, "The CHSGoToSetting bth not found");
            Assert.IsNotNull(_CHSAdminPage.CHSEnableLocation, "The Enablelocation bth not found");
            CHSWebEnvPage.SetLocationServiceAndPermisson("On", "On");
        }

        [Given(@"Turn off Location Service in Settings Page")]
        public void GivenTurnOffLocationServiceInSettingsPage()
        {
            SettingsBase.SetLocationService("Off");
        }

        [Given(@"Disable Location Banner Show up")]
        public void GivenDisableLocationBannerShowUp()
        {
            SettingsBase.SetLocationService("Off");
            _CHSWebEnvPage = new CHSWebEnvPage(_webDriver.Session);
            _CHSWebEnvPage.GoToCHS();
        }

        [Given(@"Turn on Location for Vantagee")]
        public void GivenTurnOnLocationForVantagee()
        {
            CHSWebEnvPage.SetLocationServiceAndPermisson("On", "On");
        }

        [Then(@"Disable Location Banner Disappear Automatically")]
        public void ThenDisableLocationBannerDisappearAutomatically()
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            Assert.IsNotNull(_CHSAdminPage.CHSFamilyMember, "The FamilyMember text not found");
            Assert.IsNotNull(_CHSAdminPage.PasswordProtection, "The passwordProtection text not found");
        }

        [Given(@"Click Button Go to Location Settings")]
        public void GivenClickButtonGoToLocationSettings()
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            Assert.IsNotNull(_CHSAdminPage.CHSGoToSetting, "The CHSGoToSetting bth not found");
            _CHSAdminPage.CHSGoToSetting.Click();
        }

        [Given(@"Close Settings Page Without Action")]
        public void GivenCloseSettingsPageWithoutAction()
        {
            SettingsBase.KillProcess("SystemSettings");
            Thread.Sleep(1000);
        }

        [Then(@"Disable Location Banner Still Exist")]
        public void ThenDisableLocationexist()
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            Assert.IsNotNull(_CHSAdminPage.CHSGoToSetting, "The CHSGoToSetting bth not found");
            Assert.IsNotNull(_CHSAdminPage.CHSEnableLocation, "The Enablelocation bth not found");
        }

        [Given(@"Click ""(.*)"" and Just Turn on Location Service\(Don't turn on vantage location permission\),Close Settings Page")]
        public void GivenClickAndJustTurnOnLocationServiceDonTTurnOnVantageLocationPermissionCloseSettingsPage(string p0)
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            Assert.IsNotNull(_CHSAdminPage.CHSGoToSetting, "The CHSGoToSetting bth not found");
            _CHSAdminPage.CHSGoToSetting?.Click();
            CHSWebEnvPage.SetLocationSerAndPerInSetting("On", "Off");
        }

        [Given(@"Click ""(.*)"" and Turn on Location Service&Vantage Location Permission")]
        public void GivenClickAndTurnOnLocationServiceVantageLocationPermission(string p0)
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            _CHSAdminPage.GoToCHS();
            if (p0 == "go to location settings")
            {
                Assert.IsNotNull(_CHSAdminPage.CHSGoToSetting, "The CHSGoToSetting bth not found");
                _CHSAdminPage.CHSGoToSetting.Click();
            }
            else
            {
                Assert.IsNotNull(_CHSAdminPage.CHSEnableLocation, "The CHSEnableLocation bth not found");
                _CHSAdminPage.CHSEnableLocation?.Click();
            }
            CHSWebEnvPage.SetLocationSerAndPerInSetting("On", "On");
        }

        [Then(@"The Disabled Location Banner Will Disappear and We Can See Admin/Secondary User Console Normally")]
        public void ThenTheDisabledLocationBannerWillDisappearAndWeCanSeeAdminSecondaryUserConsoleNormally()
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            Assert.IsNotNull(_CHSAdminPage.CHSFamilyMember, "The FamilyMember text not found");
            Assert.IsNotNull(_CHSAdminPage.PasswordProtection, "The passwordProtection text not found");
        }

        [Given(@"Switch Pages and Return to CHS Subpage")]
        public void GivenSwitchPagesAndReturnToCHsSubpage()
        {
            _CHSWebEnvPage = new CHSWebEnvPage(_webDriver.Session);
            Assert.IsNotNull(_CHSWebEnvPage.CHSSecurity, "The CHSSecurity tab not found");
            _CHSWebEnvPage.CHSSecurity.Click();
            _CHSWebEnvPage.GoToCHS();
        }

        [Given(@"Remove Account from Web Console")]
        public void GivenRemoveAccountFromWebConsole()
        {
            CHSWebEnvPage.RemoveDevice("Trial1");
        }

        [Then(@"It Will Directly Go to CHS Marketing Page")]
        public void ThenItWillDirectlyGoToCHSMarketingPage()
        {
            _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
            Assert.IsNotNull(_CHSMarketingPage.PasswordProtection, "The passwordProtection text not found");
            Assert.IsNotNull(_CHSMarketingPage.CHSStartTrival, "The StartTrival btn not found");
            Assert.IsNotNull(_CHSMarketingPage.CHSJoin, "The Join bth not found");
        }

        [Given(@"Open LWS Subpage and Click ""(.*)""")]
        public void GivenOpenLWSSubpageAndClick(string p0)
        {
            _CHSWebEnvPage = new CHSWebEnvPage(_webDriver.Session);
            Assert.IsNotNull(_CHSWebEnvPage.CHSSecurity, "The CHSSecurity tab not found");
            _CHSWebEnvPage.CHSSecurity.Click();
            _CHSWebEnvPage.CHSSecurity.Click();
            Assert.IsNotNull(_CHSWebEnvPage.HSWIFISecurity, "The HSWIFISecurity btn not found");
            _CHSWebEnvPage.HSWIFISecurity.Click();
            Assert.IsNotNull(_CHSWebEnvPage.VisitButton, "The VisitButton btn not found");
            _CHSWebEnvPage.VisitButton.Click();
        }

        [Given(@"Change Component From Web Consle")]
        public void GivenChangeComponentFromWebConsle()
        {
            CHSWebEnvPage.RemoveFamilyFromCHSWeb();
            Thread.Sleep(4000);
        }

        [Then(@"The Numbers In the Group Will Display ""(.*)""")]
        public void ThenTheNumbersInTheGroupWillChangeAccordingly(string p0)
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            if (p0 == "1")
            {
                Assert.IsNull(_CHSAdminPage.CHSComponentNumber, "The family number equal 2");
            }
            else { Assert.IsNotNull(_CHSAdminPage.CHSComponentNumber, "The family number not equal 2"); }
        }

        [Given(@"Add ""(.*)"" Family Number")]
        public void GivenAddFamilyNumber(string p0)
        {
            switch (p0.ToLower())
            {
                case "trial":
                    CHSWebEnvPage.AddFamilyNumber();
                    break;
                case "trial2":
                    CHSWebEnvPage.AddFamilyNumber(false, true);
                    break;
            }
        }

        [Then(@"""(.*)"" location Status and Disabled Location Banner Status are Consistent")]
        public void ThenLocationStatusAndDisabledLocationBannerStatusAreConsistent(string p0)
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            _CHSAdminPage.GoToCHS();
            Assert.IsNotNull(_CHSAdminPage.CHSGoToSetting, "The CHSGoToSetting bth not found");
            Assert.IsNotNull(_CHSAdminPage.CHSEnableLocation, "The Enablelocation bth not found");
        }

        [When(@"Click ""(.*)"" in SH")]
        public void WhenClickInSH(string p0)
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            Assert.IsNotNull(_CHSAdminPage.CHSEnableLocation, "The Enablelocation bth not found");
            _CHSAdminPage.CHSEnableLocation.Click();
        }

        [Then(@"It Will Directly Open Settings Page")]
        public void ThenItWillDirectlyOpenSettingsPage()
        {
            UIAutomationControl control = new UIAutomationControl();
            Assert.IsNotNull(control.FindElementsByClasssNameAndAutomationIDCollection(AutomationElement.RootElement, VantageConstContent.VantageLocationPermission, "ToggleSwitch"));
        }

        [Then(@"Disable Location Banner Won't Show up")]
        public void ThenThenDisableLocationBannerWonTShowUp()
        {
            _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
            Assert.IsNotNull(_CHSMarketingPage.CHSStartTrival, "The StartTrival bth not found");
            Assert.IsNotNull(_CHSMarketingPage.CHSJoin, "The Join bth not found");
            Assert.IsNotNull(_CHSMarketingPage.CHSEnableLocation, "The EnableLocation bth not found");
        }

        [Given(@"Change DPI And Resolution ""(.*)""x""(.*)"" (.*)%")]
        public void GivenChangeDPI(int p0, int p1, string p2)
        {
            IntelligentCoolingBaseHelper.ChangeResolution(p0, p1);
            VantageCommonHelper.ChangeDPI(p2);
            Thread.Sleep(3000);
        }

        [Given(@"Slide The Page To ""(.*)""")]
        public void GivenSlideThePageToTheBottom(int p0)
        {
            _CHSWebEnvPage = new CHSWebEnvPage(_webDriver.Session);
            _CHSWebEnvPage.ScrollScreen(p0);
        }

        [Given(@"""(.*)"" ""(.*)"" Places Number")]
        public void GivenPlacesNumber(string p0, string p1)
        {
            if (p0.ToLower() == "add")
            {
                switch (p1.ToLower())
                {
                    case "trial":
                        CHSWebEnvPage.AddPlacesNumber();
                        break;
                    case "trial2":
                        CHSWebEnvPage.AddPlacesNumber(false, true);
                        break;
                }
            }
            else
            {
                switch (p1.ToLower())
                {
                    case "trial":
                        CHSWebEnvPage.RemovePlacesNumber();
                        break;
                    case "trial2":
                        CHSWebEnvPage.RemovePlacesNumber(false, true);
                        break;
                }
            }
        }

        [Given(@"""(.*)"" ""(.*)"" NetWork Number")]
        public void GivenNetWorkNumber(string p0, string p1)
        {
            if (p0.ToLower() == "add")
            {
                switch (p1.ToLower())
                {
                    case "trial":
                        CHSWebEnvPage.AddWifiNetworkNumber();
                        break;
                    case "trial2":
                        CHSWebEnvPage.AddWifiNetworkNumber(false, true);
                        break;
                }
            }
            else
            {
                switch (p1.ToLower())
                {
                    case "trial":
                        CHSWebEnvPage.RemoveWifiNetworkNumber();
                        break;
                    case "trial2":
                        CHSWebEnvPage.RemoveWifiNetworkNumber(false, true);
                        break;
                }
            }

        }
        [Given(@"""(.*)"" ""(.*)"" Home Devices")]
        public void GivenHomeDevices(string p0, string p1)
        {
            _CHSWebEnvPage = new CHSWebEnvPage(_webDriver.Session);
            if (p0.ToLower() == "add")
            {
                switch (p1.ToLower())
                {
                    case "trial":
                        _CHSWebEnvPage.AddHomeDeviceNumber(1);
                        break;
                    case "trial2":
                        _CHSWebEnvPage.AddHomeDeviceNumber(1, false, true);
                        break;
                }
            }
        }

        [Then(@"There is No ""(.*)"" Button")]
        public void ThenThereISNoButton(string p0)
        {
            switch (p0.ToLower())
            {
                case "disconnect":
                    _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
                    Assert.IsNull(_CHSAdminPage.CHSDisconnectBtn, "The DisconnectBtn should not found");
                    break;
                case "buynow":
                    _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
                    Assert.IsNull(_CHSAdminPage.CHSBuyNow, "The CHSBuyNow btn should not found");
                    break;
                case "outtrialtext":
                    _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
                    Assert.IsNull(_CHSAdminPage.CHSOutTrialText, "The CHSOutTrialText should not found");
                    break;
                case "over30daytext":
                    _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
                    Assert.IsNull(_CHSAdminPage.CHSOver30DaysDescri, "The CHSOver30DaysDescri should not found");
                    break;
            }

        }

    }
}
