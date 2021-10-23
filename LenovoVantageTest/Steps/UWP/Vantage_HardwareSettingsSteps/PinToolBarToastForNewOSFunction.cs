using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using Microsoft.Win32;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public sealed class PinToolBarToastForNewOSFunction : BasePage
    {

        private InformationalWebDriver _webDriver;
        private string toolBarToastTitle = "Pin Vantage Toolbar to Windows taskbar to easily access popular settings.";

        public PinToolBarToastForNewOSFunction(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Del PinToolBar Toast Regedit")]
        public void GivenDelPinToolBarToastRegedit()
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Lenovo\\BatteryGaugeToast", true);
                string[] regKeys = reg.GetValueNames();
                foreach (var regKey in regKeys)
                {
                    if (regKey == "DisplayTimes" || regKey == "LastDisplayTime" || regKey == "NewOsDisplayTimes" || regKey == "SkipOOBEFirstRun")
                    {
                        reg.DeleteValue(regKey, true);
                    }
                }
                reg.Close();
            }
            catch (Exception ErroMessage)
            {
                Debug.WriteLine("Del PintoolBar toast data from the registry Because Of :" + ErroMessage.ToString());
            }
        }

        [Given(@"PinToolBar Toast is ""(.*)"" and ""(.*)"" in ""(.*)""")]
        public void GivenThePinToolBarToastIs(string p0, string p1, string p2)
        {
            int times = 2;
            WindowsElement title = null;
            WindowsElement DismissButton = null;
            HSSmartAssistPage hs = new HSSmartAssistPage(_webDriver.Session);
            WindowsDriver<WindowsElement> _appsion = hs.GetControlPanelSession(true);
            string titleId = p2 == "newos" ? "MessageText" : "TitleText";
            string titleValue = p2 == "newos" ? toolBarToastTitle : "Lenovo Vantage Toolbar";
            while (true)
            {
                if (times == 0)
                {
                    break;
                }
                title = FindElementByTimes(_appsion, "AutomationId", titleId);
                if (title != null)
                {
                    _appsion.Mouse.MouseMove(title.Coordinates);
                    if (title.GetAttribute("Name") == titleValue)
                    {
                        if (p0 == "noshow")
                        {
                            Assert.Fail("The pintoolbar should not show  but now is show!");
                        }
                        if (p1 == "Click")
                        {
                            _appsion.Mouse.MouseMove(title.Coordinates);
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        title = null;
                        DismissButton = FindElementByTimes(_appsion, "AutomationId", "DismissButton", 2, 1);
                        DismissButton.Click();
                    }
                }
                else
                {
                    times--;
                }
            }
            if (p0 == "show")
            {
                Assert.NotNull(title, "The PinToolBar toast is not find");
            }
            else if (p0 == "noshow")
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Lenovo\\BatteryGaugeToast", true);
                string noShowRegValue = reg.GetValue("NewOsDisplayTimes").ToString();
                Assert.AreEqual("4", noShowRegValue, "The PinToolBar toast Not show regedit Value is not 4 please check it");
            }

        }

        [Given(@"Set the time for seven days")]
        public void GivenSetTheTimeForSevenDays()
        {
            DateTime nowTime = DateTime.Now;
            Common.SetSystemDateTime(nowTime.AddDays(8).ToString());
            Thread.Sleep(3000);
        }

        [Given(@"Click PinToolBar Toast button ""(.*)""")]
        public void GivenClickPinToolBarToastButton(string p0)
        {
            HSSmartAssistPage hs = new HSSmartAssistPage(_webDriver.Session);
            WindowsDriver<WindowsElement> _appsion = hs.GetControlPanelSession(true);
            WindowsElement pinToolBarButton = FindElementByTimes(_appsion, "Name", p0);
            if (pinToolBarButton != null)
            {
                pinToolBarButton.Click();
                if (p0 == "Pin to taskbar")
                {
                    Thread.Sleep(5000);
                    IntelligentCoolingPages _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
                    WindowsElement toolbarElement = _intelligentcoolingPages.FindElementByTimes(_appsion, "Name", "Lenovo Vantage Toolbar", 10);
                    Assert.NotNull(toolbarElement, "Already click pin tool bar but Tool bar is not find");
                }
            }
        }

        [Given(@"Close the PinToolBarToast")]
        public void GivenCloseThePinToolBarToast()
        {
            HSSmartAssistPage hs = new HSSmartAssistPage(_webDriver.Session);
            WindowsDriver<WindowsElement> _appsion = hs.GetControlPanelSession(true);
            WindowsElement DismissButton = FindElementByTimes(_appsion, "AutomationId", "DismissButton", 2, 1);
            if (DismissButton != null)
            {
                DismissButton.Click();
            }
        }

        [Then(@"The PinToolBar toggle is ""(.*)""")]
        public void ThenThePinToolBarToggleIs(string p0)
        {
            HSToolbarPage _toolbarPage = new HSToolbarPage(_webDriver.Session);
            if (p0 == "on")
            {
                Assert.AreEqual("1", _toolbarPage.ToolbarDevicesBtn.GetAttribute("Toggle.ToggleState"), "The pin toolbar toggle should be on but now is off");
            }
            else
            {
                Assert.AreEqual("0", _toolbarPage.ToolbarDevicesBtn.GetAttribute("Toggle.ToggleState"), "The pin toolbar toggle should be off but now is on");
            }
        }

        [Given(@"Unselect the Enable the lenovo vantage toolbar on oobe")]
        public void GivenUnselectTheEnableTheLenovoVantageToolbarOnOobe()
        {
            WindowsElement nextBtn = FindElementByTimes(_webDriver.Session, "XPath", VantageConstContent.OoBeNextButton);
            if (nextBtn != null)
            {
                nextBtn.Click();
            }
            HSToolbarPage _toolbarPage = new HSToolbarPage(_webDriver.Session);
            VantageCommonHelper.SwitchToggleStatus(_toolbarPage.vantageToolbarCheckBox, ToggleState.Off);
            WindowsElement choose = FindElementByTimes(_webDriver.Session, "XPath", VantageConstContent.ObBeSegmentChoose);
            WindowsElement done = FindElementByTimes(_webDriver.Session, "XPath", VantageConstContent.OoBeDoneButton);
            choose?.Click();
            done?.Click();
        }

        [Given(@"""(.*)"" pintoolbar toggle in powerpage")]
        public void GivenPintoolbarToggleInPowerpage(string p0)
        {
            HSToolbarPage _toolbarPage = new HSToolbarPage(_webDriver.Session);
            if (p0 == "open")
            {
                _toolbarPage.SetCheckBoxStatus(_toolbarPage.ToolbarDevicesBtn, ToggleState.On);
            }
            else
            {
                _toolbarPage.SetCheckBoxStatus(_toolbarPage.ToolbarDevicesBtn, ToggleState.Off);
            }
        }



        [Then(@"PinToolBar ""(.*)"" should be Close")]
        public void ThenPinToolBarShouldBeClose(string p0)
        {
            HSSmartAssistPage hs = new HSSmartAssistPage(_webDriver.Session);
            WindowsDriver<WindowsElement> _appsion = hs.GetControlPanelSession(true);
            if (p0 == "toast")
            {
                WindowsElement title = FindElementByTimes(_appsion, "AutomationId", "MessageText", 1, 1);
                if (title != null)
                {
                    if (title.GetAttribute("Name") == toolBarToastTitle)
                    {
                        Assert.Fail("The PinToolBarToast doesn't closed");
                    }
                }
            }
            else if (p0 == "popup window")
            {
                HSToolbarPage _toolbarPage = new HSToolbarPage(_appsion);
                Assert.IsNull(_toolbarPage.PopWindowPintoTaskbarTitle, "The PopWindow is  find");
            }
        }


        [Then(@"PinToolBar Pop window show")]
        public void ThenPinToolBarPopWindoShow()
        {
            HSSmartAssistPage hs = new HSSmartAssistPage(_webDriver.Session);
            WindowsDriver<WindowsElement> _appsion = hs.GetControlPanelSession(true);
            HSToolbarPage _toolbarPage = new HSToolbarPage(_appsion);
            Assert.NotNull(_toolbarPage.PopWindowPintoTaskbarTitle, "The PopWindowPintoTaskbarTitle is not find");
            Assert.AreEqual(GetAutomationIdFromPredefinedJsonFile("$.Toolbar.PopWindowPintoTaskbarTitleName"), _toolbarPage.PopWindowPintoTaskbarTitle.Text, "The pop up window Title Text is not true");
            Assert.NotNull(_toolbarPage.PopWindowPintoTaskbarDescription, "The PopWindowPintoTaskbarDescription is not find");
            Assert.AreEqual(GetAutomationIdFromPredefinedJsonFile("$.Toolbar.PopWindowPintoTaskbarDescriptionText"), _toolbarPage.PopWindowPintoTaskbarDescription.Text, "The pop up window DescriptionText is not true");
            Assert.NotNull(_toolbarPage.PopWindowPintoTaskbarImage, "The PopWindowPintoTaskbarImage is not find");
            Assert.NotNull(_toolbarPage.PopWindowPintoTaskbarNote, "The PopWindowPintoTaskbarNote is not find");
            Assert.AreEqual(GetAutomationIdFromPredefinedJsonFile("$.Toolbar.PopWindowPintoTaskbarNoteText"), _toolbarPage.PopWindowPintoTaskbarNote.Text, "The pop up window TaskbarNote is not true");
            Assert.NotNull(_toolbarPage.PopWindowPintoTaskBarButton, "The PopWindowPintoTaskBarButton is not find");
            Assert.NotNull(_toolbarPage.PopWindowPintoTaskbarNotNow, "The PopWindowPintoTaskbarNotNow is not find");
        }

        [Then(@"Click PinToolBar Pop window ""(.*)"" button")]
        public void ThenClickPinToolBarPopWindowButton(String p0)
        {
            HSSmartAssistPage hs = new HSSmartAssistPage(_webDriver.Session);
            WindowsDriver<WindowsElement> _appsion = hs.GetControlPanelSession(true);
            HSToolbarPage _toolbarPage = new HSToolbarPage(_appsion);
            if (p0 == "close")
            {
                _toolbarPage.PopWindowPintoTaskbarClose?.Click();
            }
            else if (p0 == "pintoolbar")
            {
                _toolbarPage.PopWindowPintoTaskBarButton?.Click();
            }
            else if (p0 == "notnow")
            {
                _toolbarPage.PopWindowPintoTaskbarNotNow?.Click();
            }
        }

        [Then(@"The toolbar is pin to taskbar")]
        public void ThenTheToolbarIsPinToTaskbar()
        {
            IntelligentCoolingPages _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            HSSmartAssistPage hs = new HSSmartAssistPage(_webDriver.Session);
            WindowsDriver<WindowsElement> _appsion = hs.GetControlPanelSession(true);
            WindowsElement toolbarElement = _intelligentcoolingPages.FindElementByTimes(_appsion, "Name", "Lenovo Vantage Toolbar", 10);
            Assert.IsNotNull(toolbarElement, "Already click pin tool bar but Tool bar doesn't find");
        }

        [When(@"Hover on PinToolBar Close button")]
        public void WhenHoverOnPinToolBarCloseButton()
        {
            HSSmartAssistPage hs = new HSSmartAssistPage(_webDriver.Session);
            WindowsDriver<WindowsElement> _appsion = hs.GetControlPanelSession(true);
            HSToolbarPage _toolbarPage = new HSToolbarPage(_appsion);
            _toolbarPage.PopWindowPintoTaskbarClose?.Click();
            VantageCommonHelper.HoverOnVantage(_appsion, _toolbarPage.PopWindowPintoTaskbarClose);
            Thread.Sleep(1000);
        }

        [Then(@"Check PinToolBar Toast message")]
        public void ThenCheckPinToolBarToastMessage()
        {
            HSSmartAssistPage hs = new HSSmartAssistPage(_webDriver.Session);
            WindowsDriver<WindowsElement> _appsion = hs.GetControlPanelSession(true);
            WindowsElement title = FindElementByTimes(_appsion, "AutomationId", "MessageText");
            Assert.NotNull(title, "The PinToolBarToast title is not find");
            Assert.AreEqual(toolBarToastTitle, title.GetAttribute("Name"), "The PinToolBarToast title is not ture");
            WindowsElement toastImage = FindElementByTimes(_appsion, "AutomationId", "NonPersonableImage");
            Assert.NotNull(toastImage, "The PinToolBarToast Image is not find");
            WindowsElement pinToolBarLearnMoreButton = FindElementByTimes(_appsion, "Name", "Learn More");
            Assert.NotNull(pinToolBarLearnMoreButton, "The PinToolBarToast pinToolBarLearnMoreButton is not find");
            WindowsElement pinToolBarPinToBarButton = FindElementByTimes(_appsion, "Name", "Pin to taskbar");
            Assert.NotNull(pinToolBarPinToBarButton, "The PinToolBarToast pinToolBarPinToBarButton is not find");
        }
    }
}
