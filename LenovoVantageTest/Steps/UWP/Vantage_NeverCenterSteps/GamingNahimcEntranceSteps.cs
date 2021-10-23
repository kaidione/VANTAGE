using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingNahimicEntranceSteps
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;

        public GamingNahimicEntranceSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Nahamic App is installed or uninstalled '(.*)'")]
        public void GivenNahamicAppIsInstalledOrUninstalled(string nahimic)
        {
            if (NerveCenterHelper.GetMachineIsGaming())
            {
                switch (nahimic.ToLower())
                {
                    case "installed":
                        UwpAppManagement.InstallUwpAppByBundleBtn(VantageConstContent.GamingNahimicSetup);
                        Thread.Sleep(5000);
                        break;
                    case "uninstalled":
                        UwpAppInfo info = UwpAppManagement.SearchUwpAppByName("*Nahimic*");
                        if (info != null)
                        {
                            UwpAppManagement.UninstallUwpApp(info.PackageFullName);
                        }
                        Assert.IsFalse(RegistryHelp.IsRegistryKeyExist(@"HKCU\SOFTWARE\Classes\Local Settings\Software\Microsoft\Windows\CurrentVersion\AppContainer\Storage\a-volute.nahimic_w2gh52qy24etm"), "The NahimcApp() uninstall fail!");
                        break;
                    default:
                        Assert.Fail("The GivenLegionNahimcAppInstallOrUninstall() not run! info:" + nahimic);
                        break;
                }
            }
            else
            {
                Assert.Fail("Non-Gaming Machine will not install Legion Nahimc  App" + nahimic);
            }
        }

        [Then(@"Nahimic icon should be '(.*)' in the system tools section")]
        public void ThenNahimicIconShouldBeInTheSystemToolsSection(string p0)
        {
            {
                _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                switch (p0.ToLower())
                {
                    case "shown":
                        Assert.NotNull(_nerveCenterPages.SystemToolsNahimics, "Nahimic icon cannot be found");
                        Assert.NotNull(_nerveCenterPages.SystemToolsNahimicsName, "Nahimic icon name cannot be found");
                        break;
                    case "hidden":
                        Assert.IsNull(_nerveCenterPages.SystemToolsNahimics, "Nahimic icon cannot be found");
                        Assert.IsNull(_nerveCenterPages.SystemToolsNahimicsName, "Nahimic icon name cannot be found");
                        break;
                }
            }
        }

        [When(@"Click the Nahimic icon")]
        public void WhenClickTheNahamicIcon()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SystemToolsNahimics);
            _nerveCenterPages.SystemToolsNahimics.Click();
            Thread.Sleep(3000);
        }

        [Then(@"Nahamic app should be opened")]
        public void ThenNahamicAppShouldBeOpened()
        {
            Common.GetRunningProcess("Nahimic3");
        }

        [Given(@"Close the information box")]
        public void GivenCloseTheInformationBox()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            var session = VantageCommonHelper.LaunchSystemUwp(VantageConstContent.VantageUwpAppid);
            VantageCommonHelper.CloseAlertWindow(session);
        }

        [Then(@"Nahamic Install Window Should Be '(.*)'")]
        public void ThenNahamicInstallWindowShouldBe(string p1)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (p1.ToLower())
            {
                case "shown":
                    Assert.IsNotNull(_nerveCenterPages.NahimicPopWindow, "Nahimic popup cannot be found");
                    Assert.IsNotNull(_nerveCenterPages.NahimicPopWindowInstallButton, "Nahimic install button cannot be found");
                    Assert.IsNotNull(_nerveCenterPages.NahimicPopWindowCancelButton, "Nahimic cancel button cannot be found");
                    Assert.IsNotNull(_nerveCenterPages.NahimicPopWindowCloseButton, "Nahimic close button cannot be found");
                    Assert.IsNotNull(_nerveCenterPages.NahimicPopWindowdialogTitleEle, "Nahimic popup title cannot be found");
                    Assert.IsNotNull(_nerveCenterPages.NahimicPopWindowdialogDescEle, "Nahimic popup description cannot be found");
                    break;
                case "hidden":
                    Assert.IsNull(_nerveCenterPages.NahimicPopWindow, "Nahimic popup can be found");
                    Assert.IsNull(_nerveCenterPages.NahimicPopWindowInstallButton, "Nahimic install button can be found");
                    Assert.IsNull(_nerveCenterPages.NahimicPopWindowCancelButton, "Nahimic cancel button can be found");
                    Assert.IsNull(_nerveCenterPages.NahimicPopWindowCloseButton, "Nahimic close button can be found");
                    Assert.IsNull(_nerveCenterPages.NahimicPopWindowdialogTitleEle, "Nahimic popup title can be found");
                    Assert.IsNull(_nerveCenterPages.NahimicPopWindowdialogDescEle, "Nahimic popup description can be found");
                    Assert.IsNotNull(_nerveCenterPages.GamingLegionEdge, "Legion edge section cannot be found");
                    Assert.IsNotNull(_nerveCenterPages.LegionEdgeTitle, "Legion edge section title cannot be found");
                    Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostIcon, "Network Boost Icon cannot be found");
                    Assert.IsNotNull(_nerveCenterPages.LegionEdgeAutoCloseIcon, "Auto Close Icon cannot be found");
                    break;
            }
        }

        [Then(@"Nahimic Install Web page should Be '(.*)'")]
        public void ThenNahimicInstallWebPageShouldBe(string p2)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (p2.ToLower())
            {
                case "shown":
                    WindowsDriver<WindowsElement> _appsion = _nerveCenterPages.GetControlPanelSession(true);
                    WindowsElement nahimicElement = _nerveCenterPages.FindElementByTimes(_appsion, "AutomationId", "DynamicHeading_productTitle");
                    Assert.IsNotNull(nahimicElement, "Nahimic Element is null");
                    Assert.IsTrue(_nerveCenterPages.ShowTextbox(nahimicElement).Equals(_nerveCenterPages.NahimicWebName));
                    break;
                case "hidden":
                    Assert.IsFalse(Common.GetRunningProcess("msedge"), "The Edge is Running");
                    break;
            }
        }

        [When(@"Click '(.*)' Button In Nahamic Install Window")]
        public void WhenClickButtonInNahamicInstallWindow(string p3)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (p3)
            {
                case "Close":
                    Assert.IsNotNull(_nerveCenterPages.NahimicPopWindowCloseButton);
                    _nerveCenterPages.NahimicPopWindowCloseButton.Click();
                    break;
                case "Cancel":
                    Assert.IsNotNull(_nerveCenterPages.NahimicPopWindowCancelButton);
                    _nerveCenterPages.NahimicPopWindowCancelButton.Click();
                    break;
                case "Install":
                    Assert.IsNotNull(_nerveCenterPages.NahimicPopWindowInstallButton);
                    _nerveCenterPages.NahimicPopWindowInstallButton.Click();
                    break;
            }
        }
    }
}
