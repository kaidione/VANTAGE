using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    class GamingXriteEntranceSteps
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;

        public GamingXriteEntranceSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"X-rite App is installed or uninstalled '(.*)'")]
        public void GivenXriteAppIsInstalledOrUninstalled(string status)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (status.ToLower())
            {
                case "installed":
                    if (File.Exists("C:\\XRiteColorAssistantSetup.exe"))
                    {
                        VantageCommonHelper.RunCmd("C:\\XRiteColorAssistantSetup.exe /silent");
                    }
                    Thread.Sleep(20000);
                    break;
                case "uninstalled":
                    Common.KillProcess("XRiteColorAssistant", true);
                    if (File.Exists("C:\\Program Files (x86)\\X-Rite Color Assistant\\unins000.exe"))
                    {
                        VantageCommonHelper.RunCmd("C:\\PROGRA~2\\\"X-Rite Color Assistant\"\\unins000.exe /silent");
                    }
                    Thread.Sleep(5000);
                    Assert.IsFalse(RegistryHelp.IsRegistryKeyExist(@"HKCU\\Software\\X-Rite, Inc\\X-Rite Color Assistant"));
                    break;
                default:
                    Assert.Fail("GivenXriteAppIsInstalledOrUninstalled no run");
                    break;
            }
        }

        [Then(@"X-rite icon should be '(.*)' in the system tools section")]
        public void ThenX_RiteIocnShouldBeInTheSystemToolsSection(string p0)
        {
            {
                _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                switch (p0.ToLower())
                {
                    case "shown":
                        Assert.IsNotNull(_nerveCenterPages.SystemToolsXrites, "The xrites null");
                        Assert.IsNotNull(_nerveCenterPages.SystemToolsXritesName, "The xritesName null");
                        break;
                    case "hidden":
                        Assert.IsNull(_nerveCenterPages.SystemToolsXrites, "The xrites not null");
                        Assert.IsNull(_nerveCenterPages.SystemToolsXritesName, "The xritesName not null");
                        break;
                }
            }
        }

        [When(@"Click the X-rite icon")]
        public void WhenClickTheX_RiteIcon()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SystemToolsXrites, "The xrites null");
            _nerveCenterPages.SystemToolsXrites.Click();
            Thread.Sleep(3000);
        }

        [Then(@"X-rite app should be opened")]
        public void ThenX_RiteAppShouldBeOpened()
        {
            Common.GetRunningProcess("XRiteColorAssistant");
        }

        [When(@"Click '(.*)' Button In X-rite Install Window")]
        public void WhenClickCloseButtonInX_RiteInstallWindow(String p0)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (p0)
            {
                case "Close":
                    Assert.IsNotNull(_nerveCenterPages.XritePopWindowCloseButton, "X-ritePopWindowwCloseButton null");
                    _nerveCenterPages.XritePopWindowCloseButton.Click();
                    break;
                case "Cancel":
                    Assert.IsNotNull(_nerveCenterPages.XritePopWindowCancelButton, "X-ritePopWindowwCancelButton null");
                    _nerveCenterPages.XritePopWindowCancelButton.Click();
                    break;
                case "Install":
                    Assert.IsNotNull(_nerveCenterPages.XritePopWindowInstallButton, "X-ritePopWindowwInstallButton null");
                    _nerveCenterPages.XritePopWindowInstallButton.Click();
                    break;
            }
        }

        [Then(@"X-rite Install Window Should Be '(.*)'")]
        public void ThenX_RiteInstallWindowShouldBe(string p1)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (p1.ToLower())
            {
                case "shown":
                    Assert.IsNotNull(_nerveCenterPages.XritePopWindow, "X-rite popup cannot be found");
                    Assert.IsNotNull(_nerveCenterPages.XritePopWindowInstallButton, "X-ritePopWindowInstallButton null");
                    Assert.IsNotNull(_nerveCenterPages.XritePopWindowCancelButton, "X-ritePopWindowwCancelButton null");
                    Assert.IsNotNull(_nerveCenterPages.XritePopWindowCloseButton, "X-ritePopWindowwCloseButton null");
                    Assert.IsNotNull(_nerveCenterPages.XritePopWindowdialogTitleEle, "X-rite popup title cannot be found");
                    Assert.IsNotNull(_nerveCenterPages.XritePopWindowdialogDescEle, "X-rite popup description cannot be found");
                    break;
                case "hidden":
                    Assert.IsNull(_nerveCenterPages.XritePopWindow, "X-rite popup can be found");
                    Assert.IsNull(_nerveCenterPages.XritePopWindowInstallButton, "X-ritePopWindowInstallButton null");
                    Assert.IsNull(_nerveCenterPages.XritePopWindowCancelButton, "X-ritePopWindowwCancelButton null");
                    Assert.IsNull(_nerveCenterPages.XritePopWindowCloseButton, "X-ritePopWindowwCloseButton null");
                    Assert.IsNull(_nerveCenterPages.XritePopWindowdialogTitleEle, "X-rite popup title can be found");
                    Assert.IsNull(_nerveCenterPages.XritePopWindowdialogDescEle, "X-rite popup description can be found");
                    Assert.IsNotNull(_nerveCenterPages.GamingLegionEdge, "Legion edge section cannot be found");
                    Assert.IsNotNull(_nerveCenterPages.LegionEdgeTitle, "Legion edge section title cannot be found");
                    Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostIcon, "Network Boost Icon cannot be found");
                    Assert.IsNotNull(_nerveCenterPages.LegionEdgeAutoCloseIcon, "Auto Close Icon cannot be found");
                    break;
            }
        }

        [Then(@"X-rite Install Web page Should Be '(.*)'")]
        public void ThenX_RiteInstallWebPageShouldBe(string p2)
        {
            {
                _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                switch (p2.ToLower())
                {
                    case "shown":
                        WindowsDriver<WindowsElement> _appsion = _nerveCenterPages.GetControlPanelSession(true);
                        WindowsElement XriteElement = _nerveCenterPages.FindElementByTimes(_appsion, "Name", _nerveCenterPages.XriteWebName);
                        Assert.IsNotNull(XriteElement, "Xrite Element is null");
                        break;
                    case "hidden":
                        Assert.IsFalse(Common.GetRunningProcess("msedge"), "The Edge is Running");
                        break;
                }
            }
        }
    }
}
