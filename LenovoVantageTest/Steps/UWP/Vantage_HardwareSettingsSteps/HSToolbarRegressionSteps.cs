using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Automation;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class HSToolbarRegressionSteps
    {
        private HSToolbarPage _toolbarPage;
        private SettingsBase _settingsBase;
        private InformationalWebDriver _webDriver;
        private IntelligentCoolingPages _intelligentCoolingPages;
        private HSPowerSettingsPage _hSPowerSettingsPage;
        public HSToolbarRegressionSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }



        [Given(@"Go To Lenovo Vantage ToolBar Panel")]
        public void GivenGoToToolbar()
        {
            _settingsBase = new SettingsBase(_webDriver.Session);
            Assert.IsNotNull(_settingsBase.JumptoToolbarEle);
            _settingsBase.JumptoToolbarEle.Click();
        }

        [Given(@"Turn (.*) Toolbar Toggle from Vantage")]
        [Given(@"Turn (.*) Toolbar from Vantage")]
        public void GivenTurnOnToolbar(string status)
        {
            _toolbarPage = new HSToolbarPage(_webDriver.Session);
            if (status == "On")
            {
                bool result = _toolbarPage.TurnElementState(_toolbarPage.ToolbarToggle, ToggleState.On);
                Assert.IsTrue(result, "GivenTurnOnToobbar: Turn On Toolbar");
            }
            else if (status == "Off")
            {
                bool result = _toolbarPage.TurnElementState(_toolbarPage.ToolbarToggle, ToggleState.Off);
                Assert.IsTrue(result, "GivenTurnOnToobbar: Turn Off Toolbar");
            }
            else
            {
                Assert.Fail("Toolbar toggle has no such status ");
            }
        }

        [Then(@"Check Toolbar Description Context")]
        public void ThenCheckToolbarDescriptionContext()
        {
            _toolbarPage = new HSToolbarPage(_webDriver.Session);
            Assert.IsNotNull(_toolbarPage.JumpToToolbar);
            _toolbarPage.JumpToToolbar.Click();
            Assert.IsNotNull(_toolbarPage.ToolbardescriptionContext);
            Assert.IsNotNull(_toolbarPage.ToolbardescriptionContexts);
        }

        [Then(@"UI Image should be below the description context")]
        public void ThenUIImageShouldBeBelowTheDescriptionContext()
        {
            _toolbarPage = new HSToolbarPage(_webDriver.Session);
            Assert.IsNotNull(_toolbarPage.ToolbardescriptionContext);
            int descY = _toolbarPage.ToolbardescriptionContext.Location.Y;
            Assert.IsNotNull(_toolbarPage.ToolbarAreaImage);
            int imgY = _toolbarPage.ToolbarAreaImage.Location.Y;
            Assert.IsTrue(descY < imgY);
        }

        [Then(@"Check Toolbar Description Tips")]
        public void ThenCheckToolbarDescriptionTips()
        {
            _toolbarPage = new HSToolbarPage(_webDriver.Session);
            Assert.IsNotNull(_toolbarPage.ToolbardescriptionTips);
            Assert.IsNotNull(_toolbarPage.ToolbardescriptionTipss);
        }

        [Then(@"Back to system,Toolbar status had no change after turn it (.*)")]
        public void ThenToolbarPageUIInfoHadNoChangesToggle_OnStatusShouldNotBeChanged(string togglestatus)
        {
            _toolbarPage = new HSToolbarPage(_webDriver.Session);
            Assert.IsNotNull(_toolbarPage.ToolbardescriptionTips, "tips not found");
            Assert.IsNotNull(_toolbarPage.ToolbardescriptionTipss, "tipss not found");
            Assert.IsNotNull(_toolbarPage.ToolbardescriptionContext, "context not found");
            Assert.IsNotNull(_toolbarPage.ToolbardescriptionContexts, "contexts not found");
            Assert.IsNotNull(_toolbarPage.ToolbarAreaImage, "AreaImage not fount");
            int imgY = _toolbarPage.ToolbarAreaImage.Location.Y;
            int tipsY = _toolbarPage.ToolbardescriptionTips.Location.Y;
            Assert.IsTrue(tipsY > imgY);
            if (togglestatus == "Off")
            {
                Assert.IsFalse(_toolbarPage.ToolbarToggle.Selected, "toolbar toggle not selected");
            }
            else if (togglestatus == "On")
            {
                Assert.IsTrue(_toolbarPage.ToolbarToggle.Selected);
            }
            else
            {
                Assert.Fail("Toolbar toggle has no such status");
            }
        }

        [When(@"Switch page")]
        public void WhenSwitchPage()
        {
            _settingsBase = new SettingsBase(_webDriver.Session);
            Assert.IsNotNull(_settingsBase.MySettingsAudio);
            _settingsBase.MySettingsAudio.Click();
            Thread.Sleep(3000);
            Assert.IsNotNull(_settingsBase.MySettingsPower);
            _settingsBase.MySettingsPower.Click();
            Thread.Sleep(3000);
            Assert.IsNotNull(_settingsBase.JumptoToolbarEle);
            _settingsBase.JumptoToolbarEle.Click();
        }

        [When(@"System Sleep")]
        public void WhenSleep()
        {
            _settingsBase = new SettingsBase(_webDriver.Session);
            Assert.IsNotNull(_settingsBase.MySettingsAudio);
            _settingsBase.MySettingsAudio.Click();
            Thread.Sleep(3000);
            Assert.IsNotNull(_settingsBase.MySettingsPower);
            _settingsBase.MySettingsPower.Click();
            Thread.Sleep(3000);
            Assert.IsNotNull(_settingsBase.JumptoToolbarEle);
            _settingsBase.JumptoToolbarEle.Click();
        }

        [When(@"System Hibernate")]
        public void WhenHibernate()
        {
            _settingsBase = new SettingsBase(_webDriver.Session);
            Assert.IsNotNull(_settingsBase.MySettingsAudio);
            _settingsBase.MySettingsAudio.Click();
            Thread.Sleep(3000);
            Assert.IsNotNull(_settingsBase.MySettingsPower);
            _settingsBase.MySettingsPower.Click();
            Thread.Sleep(3000);
            Assert.IsNotNull(_settingsBase.JumptoToolbarEle);
            _settingsBase.JumptoToolbarEle.Click();
        }

        [Then(@"After turn off,Toolbar page UI info had no changes,toggle_on status should not be changed")]
        public void ThenCheckToolbarUIAfterTurnOffToolbar()
        {
            _toolbarPage = new HSToolbarPage(_webDriver.Session);
            Assert.IsNotNull(_toolbarPage.ToolbardescriptionTips);
            Assert.IsNotNull(_toolbarPage.ToolbardescriptionTipss);
            Assert.IsNotNull(_toolbarPage.ToolbardescriptionContext);
            Assert.IsNotNull(_toolbarPage.ToolbardescriptionContexts);
            Assert.IsFalse(_toolbarPage.ToolbarToggle.Selected);
        }

        [Then(@"The Toolbar togle is ""(.*)""")]
        public void ThenTheToolbarTogleIs(string p0)
        {
            _toolbarPage = new HSToolbarPage(_webDriver.Session);
            if (p0 == "On")
            {
                Assert.IsTrue(_toolbarPage.ToolbarToggle.Selected, "Toolbar is not on");
            }
            else if (p0 == "Off")
            {
                Assert.IsFalse(_toolbarPage.ToolbarToggle.Selected, "Toolbar is not off");
            }
            else
            {
                Assert.Fail("Toolbar toggle has no such status");
            }
        }

        [Then(@"the toolbar toggle is turn (.*) in 30s")]
        public void ThenCheckToolBarStatus(string status)
        {
            _toolbarPage = new HSToolbarPage(_webDriver.Session);
            if (status == "On")
            {
                Thread.Sleep(30000);
                Assert.IsTrue(_toolbarPage.ToolbarToggle.Selected);
            }
            else if (status == "Off")
            {
                Thread.Sleep(30000);
                Assert.IsFalse(_toolbarPage.ToolbarToggle.Selected);
            }
            else
            {
                Assert.Fail("Toolbar toggle has no such status");
            }
        }

        [Given(@"turn (.*) toolbar btn")]
        public void GivenClickDevicesSettings(ToggleState state)
        {
            _toolbarPage = new HSToolbarPage(_webDriver.Session);
            bool toolbar = _toolbarPage.SetCheckBoxStatus(_toolbarPage.ToolbarDevicesBtn, state);
            Assert.IsTrue(toolbar);

        }

        [Then(@"Toolbar will automatically (.*) on the taskbar")]
        public void ThenToolbarWillAutomaticallyPinOnTheTaskbar(string state)
        {
            AutomationElement toolbar = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.ToolBar).ToString(), 2);

            if (state.ToLower().Equals("pin"))
            {
                Assert.IsNotNull(toolbar, "Toolbar will automatically pin on the taskbar");
            }
            else if (state.ToLower().Equals("unpin"))
            {
                Assert.IsNull(toolbar, "Toolbar will automatically uppin on the taskbar");
            }
        }
        [Then(@"Click Toolbar")]
        public void ThenClickToolbar()
        {
            VantageCommonHelper.FindElementByIdAndMouseClick("2000");
        }

        [Then(@"Click AllSettingsBtn Show Page")]
        public void ThenClickAllSettingsBtnShowPage()
        {
            VantageCommonHelper.FindElementByIdAndMouseClick("1008");
        }
        [Then(@"Turn on BatView")]
        public void ThenTurnonBatView()
        {
            Assert.IsTrue(File.Exists(VantageConstContent.BatView), "BatView.exe is not exist.");
            CommandBase.RunCmd(VantageConstContent.BatView);
        }
        [Given(@"Check Power Page")]
        public void GivenCheckPowerPage()
        {
            _settingsBase = new SettingsBase(_webDriver.Session);
            Assert.IsNull(_settingsBase.JumptoToolbarEle);
        }
        [Given(@"Go to Devices Settings UI")]
        public void GivenGoToDevicesSettingsUI()
        {
            _settingsBase = new SettingsBase(_webDriver.Session);
            _settingsBase.GoToDevicesSettings();
        }
        [Then(@"Check Toolbar on the taskbar")]
        public void ThenCheckToolbarOnTheTaskbar()
        {
            _settingsBase = new SettingsBase(_webDriver.Session);
            AutomationElement toolbar = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.ToolBar).ToString(), 2);
            Assert.IsNull(toolbar);
        }

        [Then(@"the position of Lenovo Vantage toolbar to the top area of Power page")]
        public void ThenThePositionOfLenovoVantageToolbarToTheTopAreaOfPowerPage()
        {
            _toolbarPage = new HSToolbarPage(_webDriver.Session);
            Assert.IsNotNull(_toolbarPage.LenovoVantageToobartitle, "The LenovoVantageToobartitle is null");
            Assert.AreEqual(_toolbarPage.LenovoVantageToobartitle.Text, _toolbarPage.LenovoVantageToobartitletext);
        }

        [Then(@"Check the Order Of Power Page with '(.*)' feature")]
        public void ThenTheOrderOfTheSupportedSectionsInPowerPageButWhetherPage(string status)
        {
            _intelligentCoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _toolbarPage = new HSToolbarPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.PowerPagePowerSectionTitle, "The PowerPagePowerSectionTitle is null");
            Assert.IsNotNull(_toolbarPage.LenovoVantageToobartitle, "The LenovoVantageToobartitle is null");
            Assert.IsNotNull(_hSPowerSettingsPage.EnergyStarTitleElement, "The EnergyStarTitleElement is null");
            Point PowerPagePowerSectionTitle = VantageCommonHelper.GetWindowsElementPoint(_hSPowerSettingsPage.PowerPagePowerSectionTitle);
            Point LenovoVantageToobartitle = VantageCommonHelper.GetWindowsElementPoint(_toolbarPage.LenovoVantageToobartitle);
            Point EnergyStarTitle = VantageCommonHelper.GetWindowsElementPoint(_hSPowerSettingsPage.EnergyStarTitleElement);
            Point batterySettingsTitle;
            Point PowerSmartSettingsTitle;
            Point StandBySettingsTitle;
            bool result = false;
            switch (status)
            {
                case "Standby settings":
                    Assert.IsNotNull(_intelligentCoolingPages.batterySettings_Title, "The batterySettings_Title is null");
                    Assert.IsNotNull(_intelligentCoolingPages.PowerSmartSettingsTitle, "The PowerSmartSettingsTitle is null");
                    Assert.IsNotNull(_hSPowerSettingsPage.StandBySettingsTitle, "The StandBySettingsTitle is null");
                    batterySettingsTitle = VantageCommonHelper.GetWindowsElementPoint(_intelligentCoolingPages.batterySettings_Title);
                    PowerSmartSettingsTitle = VantageCommonHelper.GetWindowsElementPoint(_intelligentCoolingPages.PowerSmartSettingsTitle);
                    StandBySettingsTitle = VantageCommonHelper.GetWindowsElementPoint(_hSPowerSettingsPage.StandBySettingsTitle);
                    result = batterySettingsTitle.Y < PowerSmartSettingsTitle.Y && PowerSmartSettingsTitle.Y < StandBySettingsTitle.Y && StandBySettingsTitle.Y < PowerPagePowerSectionTitle.Y && PowerPagePowerSectionTitle.Y < LenovoVantageToobartitle.Y && LenovoVantageToobartitle.Y < EnergyStarTitle.Y;
                    break;
                case "Non Battery settings":
                    Assert.IsNotNull(_intelligentCoolingPages.PowerSmartSettingsTitle, "The PowerSmartSettingsTitle is null");
                    Assert.IsNotNull(_hSPowerSettingsPage.StandBySettingsTitle, "The StandBySettingsTitle is null");
                    PowerSmartSettingsTitle = VantageCommonHelper.GetWindowsElementPoint(_intelligentCoolingPages.PowerSmartSettingsTitle);
                    StandBySettingsTitle = VantageCommonHelper.GetWindowsElementPoint(_hSPowerSettingsPage.StandBySettingsTitle);
                    result = PowerSmartSettingsTitle.Y < StandBySettingsTitle.Y && StandBySettingsTitle.Y < PowerPagePowerSectionTitle.Y && PowerPagePowerSectionTitle.Y < LenovoVantageToobartitle.Y && LenovoVantageToobartitle.Y < EnergyStarTitle.Y;
                    break;
                case "Non Power Smart settings":
                    Assert.IsNotNull(_intelligentCoolingPages.batterySettings_Title, "The batterySettings_Title is null");
                    batterySettingsTitle = VantageCommonHelper.GetWindowsElementPoint(_intelligentCoolingPages.batterySettings_Title);
                    result = batterySettingsTitle.Y < PowerPagePowerSectionTitle.Y && PowerPagePowerSectionTitle.Y < LenovoVantageToobartitle.Y && LenovoVantageToobartitle.Y < EnergyStarTitle.Y;
                    break;
                case "Battery settings":
                    Assert.IsNotNull(_intelligentCoolingPages.batterySettings_Title, "The batterySettings_Title is null");
                    Assert.IsNotNull(_intelligentCoolingPages.PowerSmartSettingsTitle, "The PowerSmartSettingsTitle is null");
                    batterySettingsTitle = VantageCommonHelper.GetWindowsElementPoint(_intelligentCoolingPages.batterySettings_Title);
                    PowerSmartSettingsTitle = VantageCommonHelper.GetWindowsElementPoint(_intelligentCoolingPages.PowerSmartSettingsTitle);
                    result = batterySettingsTitle.Y < PowerSmartSettingsTitle.Y && PowerSmartSettingsTitle.Y < PowerPagePowerSectionTitle.Y && PowerPagePowerSectionTitle.Y < LenovoVantageToobartitle.Y && LenovoVantageToobartitle.Y < EnergyStarTitle.Y;
                    break;
            }
            Assert.IsTrue(result, "the order of not all the supported features in Power page");
        }

        [Then(@"The Order Of Jump To link with '(.*)' feature")]
        public void ThenTheOrderOfTheSupportedSectionsLinkInJumpToSettingsButWhetherPage(string status)
        {
            _intelligentCoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _settingsBase = new SettingsBase(_webDriver.Session);
            Assert.IsNotNull(_settingsBase.JumptoBatterySettingsEle, "The JumptoBatterySettingsEle is null");
            Assert.IsNotNull(_intelligentCoolingPages.HSJumpToSmartSettings, "The HSJumpToSmartSettings is null");
            Assert.IsNotNull(_hSPowerSettingsPage.JumpToPowerSettings, "The JumpToPowerSettings is null");
            Assert.IsNotNull(_settingsBase.JumptoToolbarEle, "The JumptoToolbarEle is null");
            Point JumptoBatterySettings = VantageCommonHelper.GetWindowsElementPoint(_settingsBase.JumptoBatterySettingsEle);
            Point JumpToSmartSettings = VantageCommonHelper.GetWindowsElementPoint(_intelligentCoolingPages.HSJumpToSmartSettings);
            Point JumpToPowerSettings = VantageCommonHelper.GetWindowsElementPoint(_hSPowerSettingsPage.JumpToPowerSettings);
            Point JumptoLenovoVantageToolbar = VantageCommonHelper.GetWindowsElementPoint(_settingsBase.JumptoToolbarEle);
            bool result = false;
            switch (status)
            {
                case "Battery Settings":
                    result = JumptoBatterySettings.X < JumpToSmartSettings.X && JumpToSmartSettings.X < JumpToPowerSettings.X && JumpToPowerSettings.X < JumptoLenovoVantageToolbar.X;
                    break;
                case "Standby settings":
                    Assert.IsNotNull(_hSPowerSettingsPage.SmartStandbyJumpLink, "The SmartStandbyJumpLink is null");
                    Point SmartStandbyJumpLink = VantageCommonHelper.GetWindowsElementPoint(_hSPowerSettingsPage.SmartStandbyJumpLink);
                    result = JumptoBatterySettings.X < JumpToSmartSettings.X && JumpToSmartSettings.X < SmartStandbyJumpLink.X && SmartStandbyJumpLink.X < JumpToPowerSettings.X && JumpToPowerSettings.X < JumptoLenovoVantageToolbar.X;
                    break;
            }
            Assert.IsTrue(result, "the order of not the supported sections link in Jump to settings");

        }
    }
}
