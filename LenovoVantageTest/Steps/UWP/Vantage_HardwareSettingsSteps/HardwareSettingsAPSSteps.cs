using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class HardwareSettingsAPSSteps : SettingsBase
    {
        private InformationalWebDriver _webDriver;
        private HSSmartAssistPage _hSSmartAssist;
        private WindowsDriver<WindowsElement> _appsession;

        public HardwareSettingsAPSSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"The machine support or not support APS '(.*)'")]
        public void GivenTheMachineSupportOrNotSupportAPS(string support)
        {
            bool isSupport = support == "support" ? true : false;
            if (VantageCommonHelper.GetCurrentMachineType().ToLower().Contains("thinkpad p40 yoga"))
            {
                string apsfile1 = @"C:\Windows\System32\drivers\ApsX64.sys";
                string apsfile2 = @"C:\Program Files\ThinkPad\TpShocks\TpShLP.dll";
                if (!File.Exists(apsfile1) && !File.Exists(apsfile2))
                {
                    Assert.Warn("The APS not Install");
                }
                Assert.IsTrue(isSupport, "The machine does not support APS");
            }
            else
            {
                Assert.IsFalse(isSupport, "The machine support APS");
            }
        }

        [Given(@"The '(.*)' function is enable or disable '(.*)'")]
        public void GivenTheFunctionIsEnableOrDisable(string func, string status)
        {
            _hSSmartAssist = new HSSmartAssistPage(_webDriver.Session);
            WindowsElement element = _hSSmartAssist.GetAPSToggleWindowsElement(func.ToLower());
            switch (status)
            {
                case "enable":
                    Assert.NotNull(element, "The " + element + " toggle not found");
                    SetCheckBoxStatus(element, ToggleState.On, _webDriver.Session);
                    Assert.AreEqual(ToggleState.On, GetCheckBoxStatus(element), "Turn on toggle fail." + func + status);
                    break;
                case "disable":
                    Assert.NotNull(element, "The " + element + " toggle not found");
                    SetCheckBoxStatus(element, ToggleState.Off, _webDriver.Session);
                    Assert.AreEqual(ToggleState.Off, GetCheckBoxStatus(element), "Turn off toggle fail." + func + status);
                    break;
                default:
                    Assert.Fail("GivenTheFunctionIsEnableOrDisable() no run,info:" + func + status);
                    break;
            }
        }

        [Then(@"The '(.*)' function is enable or disable '(.*)'")]
        public void ThenTheFunctionIsEnableOrDisable(string func, string status)
        {
            _hSSmartAssist = new HSSmartAssistPage(_webDriver.Session);
            WindowsElement element = _hSSmartAssist.GetAPSToggleWindowsElement(func.ToLower());
            switch (status)
            {
                case "enable":
                    Assert.NotNull(element, "The " + element + " toggle not found");
                    Assert.AreEqual(ToggleState.On, GetCheckBoxStatus(element), "The toggle status incorrect." + func + status);
                    break;
                case "disable":
                    Assert.NotNull(element, "The " + element + " not found");
                    Assert.AreEqual(ToggleState.Off, GetCheckBoxStatus(element), "The toggle status incorrect." + func + status);
                    break;
                default:
                    Assert.Fail("ThenTheFunctionIsEnableOrDisable() no run,info:" + func + status);
                    break;
            }
        }


        [Given(@"Go to APS section via jump link")]
        public void GivenGoToAPSSectionViaJumpLink()
        {
            if (!VantageCommonHelper.JudgeMachineNewOS())
            {
                _hSSmartAssist = new HSSmartAssistPage(_webDriver.Session);
                Assert.NotNull(_hSSmartAssist.APSJumpLink, "The APSJumpLink not found");
                _hSSmartAssist.APSJumpLink.Click();
            }
        }

        [Given(@"The APS Advance Settings change to show or hide '(.*)'")]
        public void GivenTheAPSAdvanceSettingsChangeToShowOrHide(string status)
        {
            _hSSmartAssist = new HSSmartAssistPage(_webDriver.Session);
            Assert.NotNull(_hSSmartAssist.APSAdvanceSettingsLinkXpath, "The APSAdvanceSettingsLinkXpath not found.");
            if (!_hSSmartAssist.APSAdvanceSettingsLinkXpath.GetAttribute("AutomationId").ToLower().Contains(status.ToLower()))
            {
                _hSSmartAssist.APSAdvanceSettingsLinkXpath.Click();
            }
            ScrollScreenToWindowsElement(_webDriver.Session, null, -100, 1);
            Assert.AreEqual(true, _hSSmartAssist.APSAdvanceSettingsLinkXpath.GetAttribute("AutomationId").ToLower().Contains(status.ToLower()), "GivenTheAPSAdvanceSettingsShowOrHide() fail,info:" + _hSSmartAssist.APSAdvanceSettingsLinkXpath.GetAttribute("AutomationId") + " " + status);
        }

        [Then(@"The APS features should be greyed out and the ADVANCED SETTINGS link should disappear")]
        public void ThenTheAPSFeaturesShouldBeGreyedOutAndTheADVANCEDSETTINGSLinkShouldDisappear()
        {
            _hSSmartAssist = new HSSmartAssistPage(_webDriver.Session);
            Assert.IsTrue(_hSSmartAssist.APSToggle.Enabled, "The APSToggle grey");
            Assert.AreEqual(ToggleState.Off, GetCheckBoxStatus(_hSSmartAssist.APSToggle), "The APSToggle toggle status incorrect.");
            Assert.IsFalse(_hSSmartAssist.ActiveProtectionSlider.Enabled, "The ActiveProtectionSlider not grey");
            Assert.IsFalse(_hSSmartAssist.ActiveProtectionCheckBox.Enabled, "The ActiveProtectionCheckBox not grey");
            //Assert.IsFalse(_hSSmartAssist.ManualActiveProtectionSuspensionTitle.Enabled, "The ManualActiveProtectionSuspensionTitle not grey");
            Assert.IsFalse(_hSSmartAssist.ManualActiveProtectionSuspensionToggle.Enabled, "The ManualActiveProtectionSuspensionToggle not grey");
            Assert.IsFalse(_hSSmartAssist.ManualActiveProtectionSuspensionBtn.Enabled, "The ManualActiveProtectionSuspensionBtn not grey");
            Assert.IsFalse(_hSSmartAssist.ManualSnoozeTimeDropDown.Enabled, "The ManualSnoozeTimeDropDown not grey");
            Assert.Null(_hSSmartAssist.APSAdvanceSettingsLinkXpath, "The APSAdvanceSettingsLinkXpath still show.");
        }


        [Then(@"The pen input drop down menu will not be displayed")]
        public void ThenThePenInputDropDownMenuWillNotBeDisplayed()
        {
            _hSSmartAssist = new HSSmartAssistPage(_webDriver.Session);
            Assert.Null(_hSSmartAssist.APSPenIntervalsDropDown, "The APSPenIntervalsDropDown still show");
        }

        [Then(@"The pen input drop down menu value is correct '(.*)'")]
        public void ThenThePenInputDropDownMenuValueIsCorrect(string value)
        {
            _hSSmartAssist = new HSSmartAssistPage(_webDriver.Session);
            Assert.NotNull(_hSSmartAssist.APSPenIntervalsDropDown, "The APSPenIntervalsDropDown not found");
            if (VantageConstContent.VantageTypePlan == VantageConstContent.VantageType.LE)
            {
                string[] splitValue = Regex.Split(_hSSmartAssist.APSPenIntervalsDropDown.GetAttribute("Name"), "input", RegexOptions.IgnoreCase);
                string uiValue = splitValue[1].Trim();
                Assert.AreEqual(value, uiValue, "The select suspend time drop down menu value fail");
            }
            else
            {
                Assert.AreEqual(value, _hSSmartAssist.APSPenIntervalsDropDown.GetAttribute("Name").Split('-')[1], "The pen input drop down menu value incorrect.");
            }
        }

        [Given(@"View Control Panel via '(.*)' type")]
        public void GivenViewControlPanelViaType(string status)
        {
            _hSSmartAssist = new HSSmartAssistPage(_webDriver.Session);
            _appsession = _hSSmartAssist.GetControlPanelSession();
            WindowsElement typeElement = FindElementByTimes(_appsession, "XPath", @"//*[@AutomationId='ActionButton']");
            Assert.NotNull(typeElement, "The Control Panel type not found.");
            if (typeElement.GetAttribute("Name").ToLower().Contains(status))
            {
                return;
            }
            typeElement.Click();
            Thread.Sleep(1000);
            WindowsElement optionElement = null;
            //File.AppendAllText("D:\\1.xml", _appsession.PageSource);
            switch (status.ToLower())
            {
                case "category":
                    optionElement = FindElementByTimes(_appsession, "XPath", "//*[@AutomationId='50']");
                    break;
                case "large":
                    optionElement = FindElementByTimes(_appsession, "XPath", "//*[@AutomationId='51']");
                    break;
                case "small":
                    optionElement = FindElementByTimes(_appsession, "XPath", "//*[@AutomationId='52']");
                    break;
                default:
                    Assert.Fail("GivenViewControlPanelViaType() parameter incorrect.");
                    break;
            }
            Assert.NotNull(optionElement, "The Control Panel type option not found.");
            optionElement.Click();
            typeElement = FindElementByTimes(_appsession, "XPath", "//*[@AutomationId='ActionButton']");
            Assert.NotNull(typeElement, "The Control Panel type not found.");
            Assert.IsTrue(typeElement.GetAttribute("Name").ToLower().Contains(status), "GivenViewControlPanelViaType() fail." + typeElement.GetAttribute("Name"));
        }

        [Then(@"The APS can '(.*)' in Control panal and the name is '(.*)'")]
        public void ThenTheAPSCanInControlPanalAndTheNameIs(string status, string apsName)
        {
            bool isShow = status.ToLower() == "show" ? true : false;
            Assert.NotNull(_appsession, "The Control Panel Session is null");
            bool isExistAPS = !isShow;
            foreach (WindowsElement element in _appsession.FindElementsByXPath(@"//*[@AutomationId='name']"))
            {
                if (element.GetAttribute("Name") == apsName)
                {
                    isExistAPS = true;
                    break;
                }
                isExistAPS = false;
            }
            if (isShow)
            {
                Assert.IsTrue(isExistAPS, "The APS ICON not found within Control Panel");
            }
            else
            {
                Assert.IsFalse(isExistAPS, "The APS ICON still show within Control Panel");
            }
        }


        [Given(@"Launch APS App")]
        public void GivenLaunchAPSApp()
        {
            Common.KillProcess("rundll32", true);
            DesktopPowerManagementHelper.RunCmd("TpShCPL.cpl");
            IntPtr intPtr = UnManagedAPI.FindWindow("#32770", "Lenovo Active Protection System Properties");
            UnManagedAPI.ShowWindow(intPtr, UnManagedAPI.SW_SHOWNORMAL);
            UnManagedAPI.SetWindowPos(intPtr, UnManagedAPI.HWND_TOPMOST, 0, 0, 0, 0, UnManagedAPI.SWP_NOSIZE);
        }

        [Then(@"The APS Real-time status is correct '(.*)'")]
        public void ThenTheAPSReal_TimeStatusIsCorrect(string status)
        {
            _appsession = _hSSmartAssist.GetControlPanelSession(true);
            WindowsElement element = FindElementByTimes(_appsession, "AutomationId", "1015", 10);
            Assert.AreEqual(status, element.GetAttribute("Name"), "The APS Real-time status incorrect");
        }


        [Then(@"The APS will display suspend time and value is correct '(.*)'")]
        public void ThenTheAPSWillDisplaySuspendTimeAndValueIsCorrect(string value)
        {
            value = value.ToLower() == "default" ? "30 seconds" : value;
            _hSSmartAssist = new HSSmartAssistPage(_webDriver.Session);
            Assert.NotNull(_hSSmartAssist.ManualSnoozeTimeDropDown, "The ManualSnoozeTimeDropDown not found");
            if (VantageConstContent.VantageTypePlan == VantageConstContent.VantageType.LE)
            {
                string[] splitValue = Regex.Split(_hSSmartAssist.ManualSnoozeTimeDropDown.GetAttribute("Name"), "for", RegexOptions.IgnoreCase);
                string uiValue = splitValue[1].Trim();
                Assert.AreEqual(value, uiValue, "The select suspend time drop down menu value fail");
            }
            else
            {
                Assert.AreEqual(value, _hSSmartAssist.ManualSnoozeTimeDropDown.GetAttribute("Name").Split('-')[1], "The select suspend time drop down menu value fail");
            }
        }

        [When(@"Select APS suspend time '(.*)'")]
        public void WhenSelectAPSSuspendTime(string value)
        {
            _hSSmartAssist = new HSSmartAssistPage(_webDriver.Session);
            Assert.NotNull(_hSSmartAssist.ManualSnoozeTimeDropDown, "The ManualSnoozeTimeDropDown not found");
            _hSSmartAssist.ManualSnoozeTimeDropDown.Click();
            WindowsElement element = FindElementByTimes(_webDriver.Session, "AutomationId", value);
            Assert.NotNull(element, "The ManualSnoozeTimeDropDown Item not found," + value);
            RemoteTouchScreen touchScreen = new RemoteTouchScreen(_webDriver.Session);
            touchScreen.Scroll(0, -30);
            element.Click();
            if (VantageConstContent.VantageTypePlan == VantageConstContent.VantageType.LE)
            {
                string[] splitValue = Regex.Split(_hSSmartAssist.ManualSnoozeTimeDropDown.GetAttribute("Name"), "for", RegexOptions.IgnoreCase);
                string uiValue = splitValue[1].Trim();
                Assert.AreEqual(value, uiValue, "The select suspend time drop down menu value fail");
            }
            else
            {
                Assert.AreEqual(value, _hSSmartAssist.ManualSnoozeTimeDropDown.GetAttribute("Name").Split('-')[1], "The select suspend time drop down menu value fail");
            }
        }

        [When(@"Click APS suspend button")]
        public void WhenClickAPSSuspendButton()
        {
            _hSSmartAssist = new HSSmartAssistPage(_webDriver.Session);
            Assert.NotNull(_hSSmartAssist.ManualActiveProtectionSuspensionBtn, "The ManualActiveProtectionSuspensionBtn not found");
            _hSSmartAssist.ManualActiveProtectionSuspensionBtn.Click();
        }

        [Then(@"The APS Manual Suspension function will be hidden or shown '(.*)'")]
        public void ThenTheAPSManualSuspensionFunctionWillBeHiddenOrShown(string status)
        {
            _hSSmartAssist = new HSSmartAssistPage(_webDriver.Session);
            switch (status.ToLower())
            {
                case "hidden":
                    Assert.Null(_hSSmartAssist.ManualActiveProtectionSuspensionBtn, "The ManualActiveProtectionSuspensionBtn still shown");
                    Assert.Null(_hSSmartAssist.ManualSnoozeTimeDropDown, "The ManualSnoozeTimeDropDown is found");
                    break;
                case "shown":
                    Assert.NotNull(_hSSmartAssist.ManualActiveProtectionSuspensionBtn, "The ManualActiveProtectionSuspensionBtn not found");
                    Assert.NotNull(_hSSmartAssist.ManualSnoozeTimeDropDown, "The ManualSnoozeTimeDropDown not found");
                    break;
                default:
                    Assert.Fail("The ThenTheAPSManualSuspensionFunctionWillBeHiddenOrShown() no run");
                    break;
            }
        }

    }
}
