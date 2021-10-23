using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public sealed class DayTimeColorTemperature : SettingsBase
    {
        private InformationalWebDriver _webDriver;
        private HSDispalyCameraPage _hSDisplayCameraPage;
        private string _ITSRegistryValueECM = "SOFTWARE\\Lenovo\\ImController\\PluginData\\LenovoVisionProtectionPlugin";

        public DayTimeColorTemperature(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"There will show ""(.*)""")]
        public void ThenThereWillShow(string p0)
        {
            WindowsElement ele = null;
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            switch (p0.ToLower())
            {
                case "colortemperatureineyecaremode":
                    ele = _hSDisplayCameraPage.ColorTempEyeCareModeSlider;
                    break;
                case "colortemperaturereset":
                    ele = _hSDisplayCameraPage.ColorTempEyeCareModeResetBtn;
                    break;
                case "colortemperaturequickmark":
                    ele = _hSDisplayCameraPage.ColorTempEyeCareModeTooltipRightIcon;
                    break;
                case "daytimecolorsliderbar":
                    ele = _hSDisplayCameraPage.DayTimeColorTempSlider;
                    break;
                case "daytimecolorreset":
                    ele = _hSDisplayCameraPage.DayTimeColorTempResetBtn;
                    break;
                case "daytimecolorquickmark":
                    ele = _hSDisplayCameraPage.DayTimeColorTempQuickMark;
                    break;
                case "daytimecolortempnote":
                    ele = _hSDisplayCameraPage.DayTimeColorTempNote;
                    Assert.IsNotNull(ele, "The" + p0 + "element is not find");
                    string exp = GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.DayTimeColorTempNoteText").ToString();
                    Assert.AreEqual(exp, ele.GetAttribute("Name"), "The " + p0 + " Description is ture now is :" + ele.GetAttribute("Name"));
                    break;
                default:
                    break;
            }
            Assert.IsNotNull(ele, "The" + p0 + "element is not find");
        }

        [Then(@"Check The ""(.*)"" description")]
        public void ThenCheckTheDescription(string p0)
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            WindowsElement ele = null;
            if (p0.ToLower() == "daytimecolorquickmark")
            {
                ele = _hSDisplayCameraPage.DayTimeColorTempQuickMark;
                ele.Click();
                if (_hSDisplayCameraPage.DayTimeColorTempToolTip == null)
                {
                    ele.Click();
                }
            }
            string description = GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.DayTimeColorTempToolTipText").ToString();
            Assert.AreEqual(description, ele.GetAttribute("Name"), "The " + p0 + " Description is ture now is :" + ele.GetAttribute("Name"));
        }

        [When(@"Click ECM Schedule CheckBox And Check can be set")]
        public void WhenClickECMScheduleCheckBox()
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            ToggleState BeforeBoxValue = VantageCommonHelper.GetToggleStatus(_hSDisplayCameraPage.CbEyeCareScheduleCheckBox);
            _hSDisplayCameraPage.CbEyeCareScheduleCheckBox.Click();
            ToggleState NexteBoxValue = VantageCommonHelper.GetToggleStatus(_hSDisplayCameraPage.CbEyeCareScheduleCheckBox);
            Assert.AreNotEqual(BeforeBoxValue, NexteBoxValue, "The ECM Schedule CheckBox can't be set");
        }

        [Then(@"The ECM toggle is ""(.*)""")]
        public void ThenTheECMToggleIs(string p0)
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            Assert.NotNull(_hSDisplayCameraPage.ColorTempEyeCareModeCheckBox, "The ColorTempEyeCareModeCheckBox is not find");
            string eyeModelState = IntelligentCoolingBaseHelper.GetCurrentUserRegeditValue("EyeModeState", _ITSRegistryValueECM);
            if (p0 == "on")
            {
                Assert.AreEqual(eyeModelState, "1", "The ColorTempEyeCareModeCheckBox default state in regedit is not ON");
                Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hSDisplayCameraPage.ColorTempEyeCareModeCheckBox), ToggleState.On, "The ColorTempEyeCareModeCheckBox default state in Ui is not ON");
            }
            else
            {
                Assert.AreEqual(eyeModelState, "0", "The ColorTempEyeCareModeCheckBox default state in regedit is not ON");
                Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hSDisplayCameraPage.ColorTempEyeCareModeCheckBox), ToggleState.Off, "The ColorTempEyeCareModeCheckBox default state in Ui is not Off");
            }
        }

        [Then(@"ECM slider will change to can't be set")]
        public void ThenECMSliderWillChangeToCanBeSet()
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            bool ColorTempEyeCareModeSliderIsEnabled = _hSDisplayCameraPage.ColorTempEyeCareModeSlider.Enabled;
            Assert.IsFalse(ColorTempEyeCareModeSliderIsEnabled, "The ColorTempEyeCareModeSlider is can be set  ");
        }

        [Given(@"Click the ECM checkbox more times")]
        public void GivenClickTheECMCheckboxMoreTimes()
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            for (int i = 0; i < 5; i++)
            {
                _hSDisplayCameraPage.CbEyeCareScheduleCheckBox.Click();
                ToggleState BeforeBoxValue = VantageCommonHelper.GetToggleStatus(_hSDisplayCameraPage.CbEyeCareScheduleCheckBox);
                _hSDisplayCameraPage.CbEyeCareScheduleCheckBox.Click();
                ToggleState NexteBoxValue = VantageCommonHelper.GetToggleStatus(_hSDisplayCameraPage.CbEyeCareScheduleCheckBox);
                Assert.AreNotEqual(BeforeBoxValue, NexteBoxValue, "The ECM Schedule CheckBox value is not true");
            }
        }

        [Then(@"ECM Display title and link is ""(.*)""")]
        public void ThenECMDisplayTitleAndLinkIs(string p0)
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            if (p0 == "show")
            {
                Assert.IsNotNull(_hSDisplayCameraPage.DayTimeColordisplaySettingsLocationTitle, "The DayTimeColordisplaySettingsLocationTitle is not find");
                Assert.AreEqual(_hSDisplayCameraPage.DayTimeColordisplaySettingsLocationTitle.Text, "Note, Lenovo Vantage need to access your location information for calculating the sunset and sunrise time of your region.");
                Assert.IsNotNull(_hSDisplayCameraPage.DayTimeColordisplaySettingsLocationLink, "The DayTimeColordisplaySettingsLocationLink is not find");
                Assert.AreEqual(_hSDisplayCameraPage.DayTimeColordisplaySettingsLocationLink.GetAttribute("Name"), "Go to windows privacy settings");
            }
            else
            {
                Assert.IsNull(_hSDisplayCameraPage.DayTimeColordisplaySettingsLocationTitle, "The DayTimeColordisplaySettingsLocationTitle is find");
                Assert.IsNull(_hSDisplayCameraPage.DayTimeColordisplaySettingsLocationLink, "The DayTimeColordisplaySettingsLocationLink is find");
            }
        }

        [Given(@"ECM Low OS Click Micro Pop and OOBE")]
        public void GivenECMLowOSClickMicroPopAndOOBE()
        {
            WindowsElement windowsElement = null;
            windowsElement = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.OoBeNextButton, 120);
            windowsElement.Click();
            windowsElement = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.ObBeSegmentChoose, 5);
            windowsElement?.Click();
            windowsElement = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.OoBeDoneButton, 30);
            windowsElement.Click();
            windowsElement = VantageCommonHelper.FindElementByXPath(_webDriver.Session, "//Button[@AutomationId='Button1']", 15);
            if (windowsElement != null)
            {
                windowsElement.Click();
            }
        }

        [Given(@"The Location PopUp Window is ""(.*)""")]
        public void GivenTheLocationPopUpWindowIs(string p0)
        {
            WindowsElement windowsElement = null;
            windowsElement = FindElementByTimes(_webDriver.Session, "AutomationId", "Popup Window");
            if (p0 == "show")
            {
                Assert.NotNull(windowsElement, "The Location PopUp window is not find");
                Assert.AreEqual(windowsElement.GetAttribute("Name"), "Let Lenovo Vantage access your precise location?", "The Location PopUp window is not find");
            }
            else
            {
                Assert.IsNull(windowsElement, "The Location PopUp window is find");
            }
        }

        [Given(@"The Camera PopUp Window is ""(.*)""")]
        public void GivenTheCameraPopUpWindowIs(string p0)
        {
            WindowsElement windowsElement = null;
            windowsElement = FindElementByTimes(_webDriver.Session, "AutomationId", "Popup Window", 60);
            if (p0 == "show")
            {
                Assert.NotNull(windowsElement, "The Location PopUp window is not find");
                Assert.AreEqual(windowsElement.GetAttribute("Name"), "Let Lenovo Vantage access your camera?", "The Camera PopUp window is not find");
                windowsElement = VantageCommonHelper.FindElementByXPath(_webDriver.Session, "//Button[@AutomationId='Button1']", 15);
                windowsElement.Click();
            }
            else
            {
                Assert.IsNull(windowsElement, "The Location PopUp window is find");
            }
        }

        [Given(@"Click ECM Location PopUp ""(.*)"" button")]
        public void GivenClickECMLocationPopUpButton(string p0)
        {
            WindowsElement windowsElement = null;
            if (p0 == "Yes")
            {
                windowsElement = VantageCommonHelper.FindElementByXPath(_webDriver.Session, "//Button[@AutomationId='Button1']", 15);
            }
            else
            {
                windowsElement = VantageCommonHelper.FindElementByXPath(_webDriver.Session, "//Button[@AutomationId='Button0']", 15);
            }
            if (windowsElement != null)
            {
                windowsElement.Click();
            }
            windowsElement = VantageCommonHelper.FindElementByXPath(_webDriver.Session, "//Button[@AutomationId='Button1']", 30);
            if (windowsElement != null)
            {
                windowsElement.Click();
            }
        }



    }
}
