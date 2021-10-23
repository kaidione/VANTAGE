using AventStack.ExtentReports.Gherkin.Model;
using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_ConnectedHomeSecurity
{
    [Binding]
    public class RequireuserstoregisterforLenovoID_StepsDefinition
    {
        private InformationalWebDriver _webDriver;
        private CHSWebEnvPage _CHSWebEnvPage;
        private CHSMarketingPage _CHSMarketingPage;
        private WIFISecurityPage _wifiSecurityPage;
        private string _oldPluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Data\LWS\plugin\");
        private string _pluginPath = @"C:\ProgramData\Lenovo\ImController\Plugins\";
        public static string UserPath = Environment.GetEnvironmentVariable("USERPROFILE");
        private static string _wifiPluginDataDb = UserPath + @"\AppData\Local\Lenovo\ImController\PluginData\GenericMessagingPlugin\db";
        private static string _wifiPluginData = UserPath + @"\AppData\Local\Lenovo\ImController\PluginData\LenovoWiFiSecurityPlugin";
        private string _vantageVer = UserPath + @"\AppData\Local\Packages\E046963F.LenovoCompanion_k1h2ywk1493x8\LocalState\config.json";
        private string _vantageVerBeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Data\Vantage\config.json");
        private string _vantageLWSRegistry = "hkcu\\SOFTWARE\\Lenovo\\ImController\\PluginData\\LenovoWiFiSecurityPlugin";

        public RequireuserstoregisterforLenovoID_StepsDefinition(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [StepDefinition(@"User Has Signed in LID ""(.*)"" The Prompt")]
        public void GivenUserHasAlreadySignedInLID(string p0)
        {
            _CHSWebEnvPage = new CHSWebEnvPage(_webDriver.Session);
            _CHSWebEnvPage.LogInVantage("Trial1", p0);
        }

        [Then(@"There Will No New Prompt Popping up")]
        public void ThenThereWillNoNewPromptPoppingUp()
        {
            _wifiSecurityPage = new WIFISecurityPage(_webDriver.Session);
            Assert.IsNull(_wifiSecurityPage.SigninPrompt, "The Signin btn should not found");
        }

        [Given(@"Change WifiSecurity StartTime To ""(.*)""")]
        public void GivenChangeWifiSecurityStartTimeTo(int p0)
        {
            WIFISecurityPage.ChangeWifiStartTime(p0);
        }

        [Given(@"Log out LID")]
        public void GivenLogOutLID()
        {
            _CHSWebEnvPage = new CHSWebEnvPage(_webDriver.Session);
            Assert.IsNotNull(_CHSWebEnvPage.VantageUserBtn, "The VantageUserBtn not found");
            _CHSWebEnvPage.VantageUserBtn.Click();
            Assert.IsNotNull(_CHSWebEnvPage.LogOutVantageBtn, "The LogOutVantageBtn not found");
            _CHSWebEnvPage.LogOutVantageBtn.Click();
        }

        [Then(@"The Prompt Will Popping up")]
        public void ThenThePromptWillPoppingUp()
        {
            Thread.Sleep(4000);
            _wifiSecurityPage = new WIFISecurityPage(_webDriver.Session);
            Assert.IsNotNull(_wifiSecurityPage.SigninPrompt, "The Signin btn not found");
        }

        [Then(@"The Prompt Will Popping up And Prompt Can not Skipped")]
        public void ThenThePromptWillPoppingUpAndPromptCanNotSkipped()
        {
            _wifiSecurityPage = new WIFISecurityPage(_webDriver.Session);
            Assert.IsNotNull(_wifiSecurityPage.SigninPrompt, "The Signin btn not found");
            _wifiSecurityPage.SigninPrompt.Click();
            _wifiSecurityPage.VantageLogCloseBtn.Click();
            Assert.IsNotNull(_wifiSecurityPage.SigninPrompt, "The Signin btn not found");
        }

        [When(@"Set the WiFi Security Toggle '(.*)' Within Subpage")]
        public void WhenSetTheWiFiSecurityToggleWithinSubpage(string p0)
        {
            _wifiSecurityPage = new WIFISecurityPage(_webDriver.Session);
            Assert.IsNotNull(_wifiSecurityPage.WiFiSecurityToggle, "The wifi toggle not found");
            ToggleState _toggleStatus = VantageCommonHelper.GetToggleStatus(_wifiSecurityPage.WiFiSecurityToggle);
            if (p0 == "On")
            {
                if (_toggleStatus.Equals(ToggleState.Off))
                {
                    _wifiSecurityPage.WiFiSecurityToggle.Click();
                }
            }
            else if (p0 == "Off")
            {
                if (_toggleStatus.Equals(ToggleState.On))
                {
                    _wifiSecurityPage.WiFiSecurityToggle.Click();
                }
            }
            else
            {
                Assert.Fail("Wifi toggle has no such status");
            }
        }

        [Given(@"Copy ""(.*)"" Plugin to Install")]
        public void GivenCopyPluginToInstall(string p0)
        {
            Common.CopyDirectory(Path.Combine(_oldPluginPath, p0), _pluginPath);
        }

        [StepDefinition(@"Set Vantage Service as Plan Config")]
        public void GivenSetVantageVersionVeta()
        {
            VantageCommonHelper.ReplaceFile();
        }

        [Given(@"Delete LWS ""(.*)""")]
        public void GivenDeleteLWS(string p0)
        {
            if (p0 == "Plugin Data")
            {
                IMCHelper.Singleton.DeleteFolder(_wifiPluginData);
                IMCHelper.Singleton.DeleteFolder(_wifiPluginDataDb);
            }
            else { IMCHelper.Singleton.DeleteFolder(_pluginPath + "LenovoWiFiSecurityPlugin"); }
        }

        [Given(@"Delete LWS Registry")]
        public void GivenDeleteLWSRegistry()
        {
            RegistryHelp.DeleteRegistrySubKey(_vantageLWSRegistry);
        }

        [Then(@"The Prompt Can Be Closed")]
        public void ThenThePromptCanBeClosed()
        {
            _wifiSecurityPage = new WIFISecurityPage(_webDriver.Session);
            Assert.IsNotNull(_wifiSecurityPage.SigninPrompt, "The Signin btn not found");
            _wifiSecurityPage.SigninPrompt.Click();
            _wifiSecurityPage.VantageLogCloseBtn.Click();
            Assert.IsNull(_wifiSecurityPage.SigninPrompt, "The Signin btn should not found");
        }

        [Given(@"Click ""(.*)"" On Log LID Prompt")]
        public void GivenClickOnLogLIDPrompt(string p0)
        {
            _wifiSecurityPage = new WIFISecurityPage(_webDriver.Session);
            switch (p0.ToLower())
            {
                case "close":
                    Assert.IsNotNull(_wifiSecurityPage.CommonDialogClose, "The CommonDialogClose btn not found");
                    _wifiSecurityPage.CommonDialogClose.Click();
                    break;
                case "ignore":
                    Assert.IsNotNull(_wifiSecurityPage.CommonDialogIgnore, "The CommonDialogIgnore btn not found");
                    _wifiSecurityPage.CommonDialogIgnore.Click();
                    break;
                case "signin":
                    Assert.IsNotNull(_wifiSecurityPage.SigninPrompt, "The Signin btn not found");
                    _wifiSecurityPage.SigninPrompt.Click();
                    break;
                default:
                    throw new Exception("out of range");
            }
        }

        [Given(@"Set Vantage Location ""(.*)"" In Setting")]
        public void GivenSetVantageLocationInSetting(string p0)
        {
            CHSWebEnvPage.SetLocationSerAndPerInSetting("On", p0);
        }

        [Given(@"Set Windows First Language ""(.*)""")]
        public void GivenSetWindowsLanguage(string p0)
        {
            Language aadf = new Language();
            aadf.SetALanguageAsFirstOneInLanguageList(p0);
        }

        [Given(@"Set Windows Region ""(.*)""")]
        public void GivenSetWindowsRegion(int p0)
        {
            Geo.SetCountryOrRegion(p0);
        }

        [Then(@"There Will be ""(.*)"" CHS Tab")]
        public void ThenThereWillBeCHSTab(string p0)
        {
            _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
            if (p0.ToLower() == "no")
            {
                Assert.IsNull(_CHSMarketingPage.DropDownCHS, "The CHS tab found");
            }
            else { Assert.IsNotNull(_CHSMarketingPage.DropDownCHS, "The CHS tab not found"); }
        }

        [Then(@"Check LWS ""(.*)"" Status")]
        public void ThenCheckLWSStatus(string p0)
        {
            _CHSWebEnvPage = new CHSWebEnvPage(_webDriver.Session);
            switch (p0.ToLower())
            {
                case "not us":
                    Assert.IsNull(_CHSWebEnvPage.VisitButton, "The Visit btn should not found");
                    break;
                default:
                    throw new Exception("out of range");
            }
        }

    }
}
