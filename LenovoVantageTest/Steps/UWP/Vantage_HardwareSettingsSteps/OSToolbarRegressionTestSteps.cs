using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System;
using System.Windows.Automation;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public sealed class OSToolbarRegressionTestSteps : SettingsBase
    {
        private IntelligentCoolingPages _intelligentcoolingPages;
        private HSPowerSettingsPage _hSPowerSettingsPage;
        private InformationalWebDriver _webDriver;
        private HSToolbarPage _hsToolbarPage;
        WindowsDriver<WindowsElement> desktopSession;


        public OSToolbarRegressionTestSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
            _hsToolbarPage = new HSToolbarPage(_webDriver.Session);
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            desktopSession = _intelligentcoolingPages.GetControlPanelSession(true);
        }

        [Given(@"Toolbar has been pin to Taskbar")]
        public void GivenToolbarHasBeenPinToTaskbar()
        {
            WindowsElement NewOSToolbar = _intelligentcoolingPages.FindElementByTimes(desktopSession, "Name", "Lenovo Vantage Toolbar", 2);
            if (NewOSToolbar == null)
            {
                if (!NerveCenterHelper.GetMachineIsGaming())
                {
                    _hSPowerSettingsPage.GoToMyDevicesSettings();
                    _hsToolbarPage.SetCheckBoxStatus(_hsToolbarPage.ToolbarDevicesBtn, ToggleState.On);
                }
                else
                {
                    var _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                    Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu, "don't found DeviceMenu");
                    _nerveCenterPages.GamingDeviceMenu.Click();
                    Assert.IsNotNull(_nerveCenterPages.SystemToolsPower, "Powerbutton doesn't display");
                    _nerveCenterPages.SystemToolsPower.Click();
                    _hsToolbarPage.SetCheckBoxStatus(_hsToolbarPage.ToolbarDevicesBtn, ToggleState.On);
                }
            }
        }

        [Then(@"the Toolbar icon should on the right side of")]
        public void ThenTheToolbarIconShouldOnTheRightSideOf()
        {
            //toolbar
            WindowsElement NewOSToolbar = _intelligentcoolingPages.FindElementByTimes(desktopSession, "Name", "Lenovo Vantage Toolbar", 2);
            var position = (NewOSToolbar as WindowsElement).Location;
            var rect = (NewOSToolbar as WindowsElement).Rect;
            int toolbarx = (position.X + rect.Width / 2);
            int toolbary = (position.Y + rect.Height / 2);
            //NotificationChevron ^
            AutomationElement NotificationChevron = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.ShowHiddenIcon).ToString(), 2);
            var positions = NotificationChevron.Current.BoundingRectangle;
            int NotificationChevronx = ((int)positions.Left + (int)positions.Width / 2);
            int NotificationChevrony = ((int)positions.Bottom - (int)positions.Height / 2);
            Assert.IsTrue(toolbarx > NotificationChevronx && Math.Abs(toolbary - NotificationChevrony) < 3, "the Toolbar icon not should on the right side of");
        }

        [Then(@"Hover toolbar on NewOS")]
        public void ThenHoverToolbarOnNewOS()
        {
            WindowsElement NewOSToolbar = _intelligentcoolingPages.FindElementByTimes(desktopSession, "Name", "Lenovo Vantage Toolbar", 2);
            Assert.IsNotNull(NewOSToolbar, "NewOSToolbar is null");
            HoverOnElement(desktopSession, NewOSToolbar);
        }

        [When(@"right click toolbar icon on NewOS")]
        public void WhenRightClickToolbarIconOnNewOS()
        {
            WindowsElement NewOSToolbar = _intelligentcoolingPages.FindElementByTimes(desktopSession, "Name", "Lenovo Vantage Toolbar", 2);
            Assert.IsNotNull(NewOSToolbar, "NewOSToolbar is null");
            Actions action = new Actions(desktopSession);
            action.ContextClick(NewOSToolbar).Build().Perform();
        }

        [Then(@"It only show unpin from taskbar")]
        public void ThenItOnlyShowUnpinFromTaskbar()
        {
            var UnpinFromTaskbar = FindElementByTimes(desktopSession, "AutomationId", Convert.ToInt32(ToolBarAutoEnum.UnpinFromTaskbar).ToString());
            Assert.IsNotNull(UnpinFromTaskbar, "UnpinFromTaskbar is null");
            Assert.AreEqual(_hsToolbarPage.Unpinfromtaskbar, UnpinFromTaskbar.Text);
        }

        [Then(@"the toolbar pin to taskbar on NewOS")]
        public void ThenTheToolbarPinToTaskbarOnNewOS()
        {
            WindowsElement NewOSToolbar = _intelligentcoolingPages.FindElementByTimes(desktopSession, "Name", "Lenovo Vantage Toolbar", 2);
            Assert.IsNotNull(NewOSToolbar, "NewOSToolbar is null");
        }

        [Then(@"Toolbar will unpin from taskbar")]
        public void ThenToolbarWillUnpinFromTaskbar()
        {
            WindowsElement NewOSToolbar = _intelligentcoolingPages.FindElementByTimes(desktopSession, "Name", "Lenovo Vantage Toolbar", 2);
            Assert.IsNull(NewOSToolbar, "NewOSToolbar is not null");
        }

        [Then(@"It will (.*) the available warranty options page")]
        public void ThenItWillShowTheAvailableWarrantyOptionsPage(string type)
        {
            switch (type)
            {
                case "show":
                    WindowsElement ViewWarrantyOption = _intelligentcoolingPages.FindElementByTimes(desktopSession, "Name", "Serial Number", 2);
                    Assert.IsNotNull(ViewWarrantyOption, "Element 'available warranty options' Is Not Found");
                    break;
                case "hide":
                    WindowsElement ViewWarrantyOptions = _intelligentcoolingPages.FindElementByTimes(desktopSession, "Name", "Search By Serial Number", 2);
                    Assert.IsNotNull(ViewWarrantyOptions, "Element 'available warranty options' Is Not Found");
                    break;
            }
        }

        [Given(@"Right click taskbar")]
        public void GivenRightClickTaskbar()
        {
            var NotificationChevron = FindElementByTimes(desktopSession, "AutomationId", Convert.ToInt32(ToolBarAutoEnum.ShowHiddenIcon).ToString());
            Actions action = new Actions(desktopSession);
            action.ContextClick(NotificationChevron).Build().Perform();
        }

        [When(@"Click Toolbars")]
        public void WhenClickToolbars()
        {
            WindowsElement Toolbars = _intelligentcoolingPages.FindElementByTimes(desktopSession, "Name", "Toolbars", 5);
            Assert.IsNotNull(Toolbars, "Element 'Toolbars' Is Not Found");
            HoverOnElement(desktopSession, Toolbars);
        }
    }
}
