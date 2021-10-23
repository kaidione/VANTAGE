using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using PlatformInterface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using TangramTest.Utility;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public sealed class VantageHardwareSettingsDaytimeColorAndECMColorAndScheduleECMQuickRegression : SettingsBase
    {
        private InformationalWebDriver _webDriver;
        private string _ITSRegistryValueECM = "SOFTWARE\\Lenovo\\ImController\\PluginData\\LenovoVisionProtectionPlugin";
        private HSDispalyCameraPage _hSDisplayCameraPage;
        private HSQuickSettingsPage _hsQuickSettingsPage;
        private HSPowerSettingsPage _hSPowerSettingsPage;
        private string _tNewRegedit = string.Empty;
        private string _tNewUi = string.Empty;
        private string _tENewRegedit = string.Empty;
        private string _tENewUi = string.Empty;
        private string _tEOldRegedit = string.Empty;
        private string _tEOldUi = string.Empty;
        private string _tNewColorT = string.Empty;
        private int _colorT = 0;
        private string spTime = string.Empty;
        private const string _sunSetTime = "12:00:00 AM";
        private const string _sunRaiseTime = "11:00:00 AM";
        private CUIInterfaceClient cuiInterFaceClient = new CUIInterfaceClient();
        private ADLInterfaceClient adlInterFaceClient = new ADLInterfaceClient();
        private int cpFlag = 0;

        public VantageHardwareSettingsDaytimeColorAndECMColorAndScheduleECMQuickRegression(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"The ""(.*)"" slider default ""(.*)"" Regedit ""(.*)"" Ui ""(.*)""")]
        public void ThenTheSliderDefaultRegeditUi(string ModeType, string RegeditName, string RegeditValue, string UiValue)
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            switch (ModeType)
            {
                case "DayTimeFeature":
                    string tempDisplay = IntelligentCoolingBaseHelper.GetCurrentUserRegeditValue(RegeditName, _ITSRegistryValueECM);
                    Assert.AreEqual(RegeditValue, tempDisplay, "The daytimecolorsliderValue in regedit is not true");
                    string dayTimeColorTempSliderValue = _hSDisplayCameraPage.DayTimeColorTempSlider.GetAttribute("Value.Value");
                    Assert.AreEqual(UiValue, dayTimeColorTempSliderValue, "The daytimecolorsliderValue in UI value is not true");
                    break;
                case "ECMFeature":
                    string tempUserSet = IntelligentCoolingBaseHelper.GetCurrentUserRegeditValue(RegeditName, _ITSRegistryValueECM);
                    Assert.AreEqual(RegeditValue, tempUserSet, "The colorTempEyeCareModeSliderValue in regedit is not true");
                    string colorTempEyeCareModeSliderValue = _hSDisplayCameraPage.ColorTempEyeCareModeSlider.GetAttribute("Value.Value");
                    Assert.AreEqual(UiValue, colorTempEyeCareModeSliderValue, "The colorTempEyeCareModeSliderValue in UI value is not true");
                    break;
            }
        }

        [Then(@"The ECM feature toggle button default value should be off")]
        public void ThenTheECMFeatureToggleButtonDefaultValueShouldBeOff()
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            Assert.NotNull(_hSDisplayCameraPage.ColorTempEyeCareModeCheckBox, "The ColorTempEyeCareModeCheckBox is not find");
            string eyeModelState = IntelligentCoolingBaseHelper.GetCurrentUserRegeditValue("EyeModeState", _ITSRegistryValueECM);
            Assert.AreEqual(eyeModelState, "0", "The ColorTempEyeCareModeCheckBox default state in regedit is not off");
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hSDisplayCameraPage.ColorTempEyeCareModeCheckBox), ToggleState.Off, "The ColorTempEyeCareModeCheckBox default state in Ui is not off");
        }

        [Then(@"Schedule CheckBox should be in unchecked")]
        public void ThenScheduleCheckBoxShouldBeInUnchecked()
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            Assert.NotNull(_hSDisplayCameraPage.CbEyeCareScheduleCheckBox, "The CbEyeCareScheduleCheckBox is not find");
            string myScheduleState = IntelligentCoolingBaseHelper.GetCurrentUserRegeditValue("MyScheduleState", _ITSRegistryValueECM);
            Assert.AreEqual(myScheduleState, "0", "The CbEyeCareScheduleCheckBox default state in regedit is not off");
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hSDisplayCameraPage.CbEyeCareScheduleCheckBox), ToggleState.Off, "The CbEyeCareScheduleCheckBox default state in Ui is not off");
        }

        [Given(@"Turn ""(.*)"" Color temperature")]
        public void GivenTurnColorTemperature(string turnOrOff)
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            switch (turnOrOff)
            {
                case "off":
                    Assert.NotNull(_hSDisplayCameraPage.ColorTempEyeCareModeCheckBox, "The ColorTempEyeCareModeCheckBox is not find");
                    bool result = VantageCommonHelper.SwitchToggleStatus(_hSDisplayCameraPage.ColorTempEyeCareModeCheckBox, ToggleState.Off);
                    Assert.IsTrue(result, "The ColorTempEyeCareModeCheckBox is on not off");
                    break;
                case "on":
                    Assert.NotNull(_hSDisplayCameraPage.ColorTempEyeCareModeCheckBox, "The ColorTempEyeCareModeCheckBox is not find");
                    bool results = VantageCommonHelper.SwitchToggleStatus(_hSDisplayCameraPage.ColorTempEyeCareModeCheckBox, ToggleState.On);
                    Assert.IsTrue(results, "The ColorTempEyeCareModeCheckBox is off not on");
                    break;
            }
        }

        [Given(@"Drug the ""(.*)"" slider bar (.*)")]
        public void GivenDrugTheSliderBar(string sliderName, int offex)
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            switch (sliderName)
            {
                case "Temp_Display":
                    Assert.IsNotNull(_hSDisplayCameraPage.DayTimeColorTempSlider, "The DayTimeColorTempSlider is not find ");
                    ScrollScreenToWindowsElement(_webDriver.Session, _hSDisplayCameraPage.DayTimeColorTempSlider);
                    VantageCommonHelper.DragSlider(_webDriver.Session, _hSDisplayCameraPage.DayTimeColorTempSlider, offex);
                    Thread.Sleep(1000);
                    _tNewRegedit = IntelligentCoolingBaseHelper.GetCurrentUserRegeditValue(sliderName, _ITSRegistryValueECM);
                    _tNewUi = _hSDisplayCameraPage.DayTimeColorTempSlider.GetAttribute("Value.Value");
                    if (!_hSDisplayCameraPage.ColorTempEyeCareModeSlider.Enabled)
                    {
                        if (cpFlag == 1)
                        {
                            cuiInterFaceClient.Initialize();
                            _tNewColorT = Convert.ToString((int)cuiInterFaceClient.GetColorTemperature());
                        }
                        else if (cpFlag == 2)
                        {
                            adlInterFaceClient.Initialize();
                            _tNewColorT = Convert.ToString((int)adlInterFaceClient.GetColorTemperature());
                        }
                        else
                        {
                            _tNewColorT = _hSDisplayCameraPage.DayTimeColorTempSlider.GetAttribute("Value.Value");
                        }
                    }
                    else
                    {
                        _tNewColorT = _hSDisplayCameraPage.ColorTempEyeCareModeSlider.GetAttribute("Value.Value");
                    }
                    if (!_tNewUi.ToLower().Contains(_tNewRegedit.ToLower()))
                    {
                        throw new Exception("The UI and Regedit value is different");
                    }
                    break;
                case "Temp_UserSet":
                    Assert.IsNotNull(_hSDisplayCameraPage.ColorTempEyeCareModeSlider, "The ColorTempEyeCareModeSlider is not find ");
                    _tEOldRegedit = IntelligentCoolingBaseHelper.GetCurrentUserRegeditValue(sliderName, _ITSRegistryValueECM);
                    _tEOldUi = _hSDisplayCameraPage.ColorTempEyeCareModeSlider.GetAttribute("Value.Value");
                    ScrollScreenToWindowsElement(_webDriver.Session, _hSDisplayCameraPage.ColorTempEyeCareModeSlider);
                    VantageCommonHelper.DragSlider(_webDriver.Session, _hSDisplayCameraPage.ColorTempEyeCareModeSlider, offex);
                    Thread.Sleep(1000);
                    _tENewRegedit = IntelligentCoolingBaseHelper.GetCurrentUserRegeditValue(sliderName, _ITSRegistryValueECM);
                    _tENewUi = _hSDisplayCameraPage.ColorTempEyeCareModeSlider.GetAttribute("Value.Value");
                    Assert.AreNotEqual(_tEOldRegedit, _tENewRegedit, "The Color temperature regeditvalue cant be set");
                    Assert.AreNotEqual(_tEOldUi, _tENewUi, "The Color temperature UIvalue cant be set");
                    if (cpFlag == 1)
                    {
                        cuiInterFaceClient.Initialize();
                        _tNewColorT = Convert.ToString((int)cuiInterFaceClient.GetColorTemperature());
                    }
                    else if (cpFlag == 2)
                    {
                        adlInterFaceClient.Initialize();
                        _tNewColorT = Convert.ToString((int)adlInterFaceClient.GetColorTemperature());
                    }
                    else
                    {
                        _tNewColorT = _hSDisplayCameraPage.ColorTempEyeCareModeSlider.GetAttribute("Value.Value");
                    }
                    if (!_tENewUi.ToLower().Contains(_tENewRegedit.ToLower()))
                    {
                        throw new Exception("The UI and Regedit value is different ECM");
                    }
                    break;
            }

        }

        [Then(@"Drug the Temp_UserSet slider bar (.*) but expected failed")]
        public void GivenDrugTheSliderBarButExpectFailed(int offex)
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            Assert.IsNotNull(_hSDisplayCameraPage.ColorTempEyeCareModeSlider, "The ColorTempEyeCareModeSlider is not find ");
            _tEOldRegedit = IntelligentCoolingBaseHelper.GetCurrentUserRegeditValue("Temp_UserSet", _ITSRegistryValueECM);
            _tEOldUi = _hSDisplayCameraPage.ColorTempEyeCareModeSlider.GetAttribute("Value.Value");
            ScrollScreenToWindowsElement(_webDriver.Session, _hSDisplayCameraPage.ColorTempEyeCareModeSlider);
            VantageCommonHelper.DragSlider(_webDriver.Session, _hSDisplayCameraPage.ColorTempEyeCareModeSlider, offex);
            Thread.Sleep(1000);
            _tENewRegedit = IntelligentCoolingBaseHelper.GetCurrentUserRegeditValue("Temp_UserSet", _ITSRegistryValueECM);
            _tENewUi = _hSDisplayCameraPage.ColorTempEyeCareModeSlider.GetAttribute("Value.Value");
            Assert.AreEqual(_tEOldRegedit, _tENewRegedit, "The Color temperature regeditvalue can be set, not grey out");
            Assert.AreEqual(_tEOldUi, _tENewUi, "The Color temperature UIvalue can be set, not grey out");
            if (cpFlag == 1)
            {
                cuiInterFaceClient.Initialize();
                _tNewColorT = Convert.ToString((int)cuiInterFaceClient.GetColorTemperature());
            }
            else if (cpFlag == 2)
            {
                adlInterFaceClient.Initialize();
                _tNewColorT = Convert.ToString((int)adlInterFaceClient.GetColorTemperature());
            }
            else
            {
                _tNewColorT = _hSDisplayCameraPage.DayTimeColorTempSlider.GetAttribute("Value.Value");
            }
            if (!_tENewUi.ToLower().Contains(_tENewRegedit.ToLower()))
            {
                throw new Exception("The UI and Regedit value is different ECM");
            }
        }

        [Then(@"Color temperature in Eye Care Mode can be adjusted")]
        public void ThenColorTemperatureInEyeCareModeCanBeAdjusted()
        {
            Assert.AreNotEqual(_tEOldRegedit, _tENewRegedit, "The Color temperature regeditvalue cant be set");
            Assert.AreNotEqual(_tEOldUi, _tENewUi, "The Color temperature UIvalue cant be set");
        }

        [Then(@"The new value will keep in Tn")]
        public void ThenTheNewValueWillKeepInTn()
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            string tempDisplay = IntelligentCoolingBaseHelper.GetCurrentUserRegeditValue("Temp_Display", _ITSRegistryValueECM);
            Assert.AreEqual(tempDisplay, _tNewRegedit, "The Tn in regedit is not true");
            string dayTimeColorTempSliderValue = _hSDisplayCameraPage.DayTimeColorTempSlider.GetAttribute("Value.Value");
            Assert.AreEqual(dayTimeColorTempSliderValue, _tNewUi, "The Tn in UI value is not true");
        }

        [When(@"Cut page")]
        public void WhenCutPage()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _hSPowerSettingsPage.GoToMyDevicesSettings();
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            _hsQuickSettingsPage.GotoMySettingsDisplayCameraPage();
        }

        [Then(@"The ECM slider bar value will keep on T_en")]
        public void ThenTheECMSliderBarValueWillKeepOnT_En()
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            string tempUserSet = IntelligentCoolingBaseHelper.GetCurrentUserRegeditValue("Temp_UserSet", _ITSRegistryValueECM);
            Assert.AreEqual(tempUserSet, _tENewRegedit, "The T_en in regedit is not true");
            string colorTempEyeCareModeSliderValue = _hSDisplayCameraPage.ColorTempEyeCareModeSlider.GetAttribute("Value.Value");
            Assert.AreEqual(colorTempEyeCareModeSliderValue, _tENewUi, "The T_en in UI value is not true");
        }

        [Then(@"The sliderbar of ECM will be greyout")]
        public void ThenTheSliderbarOfECMWillBeGreyout()
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            bool ColorTempEyeCareModeSliderIsEnabled = _hSDisplayCameraPage.ColorTempEyeCareModeSlider.Enabled;
            Assert.IsFalse(ColorTempEyeCareModeSliderIsEnabled, "The ColorTempEyeCareModeSlider is not enabled ");
        }

        [When(@"Click ""(.*)"" Reset button")]
        public void WhenClickResetButton(string sliderName)
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            switch (sliderName)
            {
                case "Daytimeslider":
                    _hSDisplayCameraPage.DayTimeColorTempResetBtn.Click();
                    break;
                case "ECMslider":
                    _hSDisplayCameraPage.ColorTempEyeCareModeResetBtn.Click();
                    break;
            }
        }

        [Then(@"The color temperature will change to OOBE value")]
        public void ThenTheColorTemperatureWillChangeToOOBEValue()
        {
            Thread.Sleep(10000);
            string tempDisplay = IntelligentCoolingBaseHelper.GetCurrentUserRegeditValue("Temp_Display", _ITSRegistryValueECM);
            Assert.AreEqual("6500", tempDisplay, "The value in regedit is not obbe");
        }

        [Given(@"""(.*)"" the Eye care Mode checkbox")]
        public void GivenTheEyeCareModeCheckbox(string isCheckedValue)
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            switch (isCheckedValue)
            {
                case "unchecked":
                    Assert.NotNull(_hSDisplayCameraPage.CbEyeCareScheduleCheckBox, "The CbEyeCareScheduleCheckBox is not find");
                    bool result = VantageCommonHelper.SwitchToggleStatus(_hSDisplayCameraPage.CbEyeCareScheduleCheckBox, ToggleState.Off);
                    Assert.IsTrue(result, "The ColorTempEyeCareModeCheckBox is off");
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    break;
                case "checked":
                    Assert.NotNull(_hSDisplayCameraPage.CbEyeCareScheduleCheckBox, "The CbEyeCareScheduleCheckBox is not find");
                    bool results = VantageCommonHelper.SwitchToggleStatus(_hSDisplayCameraPage.CbEyeCareScheduleCheckBox, ToggleState.On);
                    Assert.IsTrue(results, "The ColorTempEyeCareModeCheckBox is not on");
                    Thread.Sleep(TimeSpan.FromSeconds(5));
                    break;
            }
        }

        [Given(@"Set Time to ""(.*)""")]
        public void GivenSetTimeTo(string suns)
        {
            int splitFlag = 0;
            string strDateTime = DateTime.Now.ToString();
            DateTime da = new DateTime();
            da = DateTime.Parse(strDateTime);
            int month = da.Month;
            int day = da.Day;
            if (month < 10 && day < 10)
            {
                splitFlag = 9;
            }
            if (month < 10 && day > 10)
            {
                splitFlag = 10;
            }
            if (month > 10 && day > 10)
            {
                splitFlag = 11;
            }
            if (month > 10 && day < 10)
            {
                splitFlag = 10;
            }
            string replaceTime = strDateTime.Substring(splitFlag);
            switch (suns)
            {
                case "sunset":
                    string newSunsetTime = strDateTime.Replace(replaceTime, _sunSetTime);
                    Common.SetSystemDateTime(newSunsetTime);
                    break;
                case "sunrise":
                    string newSunRaiseTime = strDateTime.Replace(replaceTime, _sunRaiseTime);
                    Common.SetSystemDateTime(newSunRaiseTime);
                    break;
                case "nearnextday":
                    string newNearNextDayTime = strDateTime.Replace(replaceTime, "11:59:20 PM");
                    Common.SetSystemDateTime(newNearNextDayTime);
                    break;
                case "sealedbatterytime":
                    string sealedbatterytime = strDateTime.Replace(replaceTime, "18:00:00 PM");
                    Common.SetSystemDateTime(sealedbatterytime);
                    break;
                case "nearsunrise":
                    //sunset to sunrise
                    int minutess = Convert.ToInt32(_hSDisplayCameraPage.CbEyeCareScheduleCheckBox.GetAttribute("Name").Split('(')[1].Split(')')[0].Split('-')[1].Trim().Split(' ')[0].Split(':')[1]) - 2;
                    string hours = _hSDisplayCameraPage.CbEyeCareScheduleCheckBox.GetAttribute("Name").Split('(')[1].Split(')')[0].Split('-')[1].Trim().Split(' ')[0].Split(':')[0];
                    string nearsunsetTime = hours + ':' + Convert.ToString(minutess) + ":00 AM";
                    string nearsunset = strDateTime.Replace(replaceTime, nearsunsetTime);
                    Common.SetSystemDateTime(nearsunset);
                    break;
                case "nearsunset":
                    //sunrise to sunset
                    int minutes = Convert.ToInt32(_hSDisplayCameraPage.CbEyeCareScheduleCheckBox.GetAttribute("Name").Split('(')[1].Split(')')[0].Split('-')[0].Trim().Split(' ')[0].Split(':')[1]) - 1;
                    string hour = _hSDisplayCameraPage.CbEyeCareScheduleCheckBox.GetAttribute("Name").Split('(')[1].Split(')')[0].Split('-')[0].Trim().Split(' ')[0].Split(':')[0];
                    string nearsunriseTime = hour + ':' + Convert.ToString(minutes) + ":00 PM";
                    string nearsunrise = strDateTime.Replace(replaceTime, nearsunriseTime);
                    Common.SetSystemDateTime(nearsunrise);
                    break;
                case "Sync":
                    Thread.Sleep(2000);
                    Common.SetSystemTimeAutomatically(true);
                    break;
            }
            Thread.Sleep(TimeSpan.FromSeconds(30));
        }

        [Then(@"The ECM toggle will change to on")]
        public void ThenTheECMToggleWillChangeToOn()
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            Assert.NotNull(_hSDisplayCameraPage.ColorTempEyeCareModeCheckBox, "The ColorTempEyeCareModeCheckBox is not find");
            string eyeModelState = IntelligentCoolingBaseHelper.GetCurrentUserRegeditValue("EyeModeState", _ITSRegistryValueECM);
            Assert.AreEqual(eyeModelState, "1", "The ColorTempEyeCareModeCheckBox default state in regedit is not ON");
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hSDisplayCameraPage.ColorTempEyeCareModeCheckBox), ToggleState.On, "The ColorTempEyeCareModeCheckBox default state in Ui is not ON");
        }

        [Then(@"ECM slider will change to can be set")]
        public void ThenECMSliderWillChangeToCanBeSet()
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            bool ColorTempEyeCareModeSliderIsEnabled = _hSDisplayCameraPage.ColorTempEyeCareModeSlider.Enabled;
            Assert.IsTrue(ColorTempEyeCareModeSliderIsEnabled, "The ColorTempEyeCareModeSlider is can’t set  ");
        }

        [Then(@"The Check-box of Schedule Eye Care mode is ""(.*)""")]
        public void ThenTheCheck_BoxOfScheduleEyeCareModeIs(string greyOut)
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            bool CbEyeCareScheduleCheckBoxIsEnabled = _hSDisplayCameraPage.CbEyeCareScheduleCheckBox.Enabled;
            switch (greyOut)
            {
                case "greyout":
                    Assert.IsFalse(CbEyeCareScheduleCheckBoxIsEnabled, "The CbEyeCareScheduleCheckBox is not enabled ");
                    break;
                case "nogreyout":
                    Assert.IsTrue(CbEyeCareScheduleCheckBoxIsEnabled, "The CbEyeCareScheduleCheckBox is  enabled ");
                    break;
            }
        }

        [Then(@"Schedule CheckBox should be in checked")]
        public void ThenScheduleCheckBoxShouldBeInChecked()
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            Assert.NotNull(_hSDisplayCameraPage.CbEyeCareScheduleCheckBox, "The CbEyeCareScheduleCheckBox is not find");
            string myScheduleState = IntelligentCoolingBaseHelper.GetCurrentUserRegeditValue("MyScheduleState", _ITSRegistryValueECM);
            Assert.AreEqual(myScheduleState, "1", "The CbEyeCareScheduleCheckBox default state in regedit is not on");
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hSDisplayCameraPage.CbEyeCareScheduleCheckBox), ToggleState.On, "The CbEyeCareScheduleCheckBox default state in Ui is not On");
        }

        [Then(@"Reset Daytime and ECM")]
        public void ThenResetDaytimeAndECM()
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            _hSDisplayCameraPage.DayTimeColorTempResetBtn.Click();
            _hSDisplayCameraPage.ColorTempEyeCareModeResetBtn.Click();
            VantageCommonHelper.SwitchToggleStatus(_hSDisplayCameraPage.CbEyeCareScheduleCheckBox, ToggleState.Off);
            VantageCommonHelper.SwitchToggleStatus(_hSDisplayCameraPage.ColorTempEyeCareModeCheckBox, ToggleState.Off);
        }

        [When(@"Wait (.*) minutes")]
        public void WhenWaitMinutes(int waitTime)
        {
            Thread.Sleep(TimeSpan.FromMinutes(waitTime));
        }

        [Then(@"The computer temperature will change to Tn")]
        public void ThenTheComputerTemperatureWillChangeToTn()
        {
            if (_tNewRegedit != string.Empty)
            {
                Assert.AreEqual(_tNewRegedit + "K", _tNewUi, "The Regedit value is not same with Ui Value");
                Assert.AreEqual(_tNewUi, _tNewColorT + "K", "The Ui Value is not same with colortemperature");
            }
            else
            {
                Assert.AreEqual(_tENewRegedit + "K", _tENewUi, "The Regedit value is not same with Ui Value");
                Assert.AreEqual(_tENewUi, _tNewColorT + "K", "The Ui Value is not same with colortemperature");
            }
        }

        [Given(@"New ""(.*)"" API is supported")]
        public void GivenNewAPIIsSupported(string cpType)
        {
            if (cpType.ToLower() == "intel")
            {
                Assert.AreEqual(0, cuiInterFaceClient.Initialize(), "The computer is not supported intel API");
                cpFlag = 1;
            }
            else if (cpType.ToLower() == "amd")
            {
                Assert.AreEqual(0, adlInterFaceClient.Initialize(), "The computer is not supported intel API");
                cpFlag = 2;
            }
        }

        [Then(@"Computer temperature same with ""(.*)"" slider")]
        public void ThenComputerTemperatureSameWithSlider(string p0)
        {
            string colorTemperature = null;
            if (cpFlag == 1)
            {
                cuiInterFaceClient.Initialize();
                colorTemperature = Convert.ToString((int)cuiInterFaceClient.GetColorTemperature());
            }
            else if (cpFlag == 2)
            {
                adlInterFaceClient.Initialize();
                colorTemperature = Convert.ToString((int)adlInterFaceClient.GetColorTemperature());
            }
            if (p0 == "UserSet")
            {
                string tempUserSet = IntelligentCoolingBaseHelper.GetCurrentUserRegeditValue("Temp_UserSet", _ITSRegistryValueECM);
                string colorTempEyeCareModeSliderValue = _hSDisplayCameraPage.ColorTempEyeCareModeSlider.GetAttribute("Value.Value").Split('K')[0];
                Assert.AreEqual(tempUserSet, colorTempEyeCareModeSliderValue, "The user and reg value is not same");
                Assert.AreEqual(colorTempEyeCareModeSliderValue, colorTemperature, "The value is not same with UserSet slider");
            }
            else if (p0 == "ColorSlider")
            {
                string tempDisplay = IntelligentCoolingBaseHelper.GetCurrentUserRegeditValue("Temp_Display", _ITSRegistryValueECM);
                string dayTimeColorTempSliderValue = _hSDisplayCameraPage.DayTimeColorTempSlider.GetAttribute("Value.Value").Split('K')[0];
                Assert.AreEqual(tempDisplay, dayTimeColorTempSliderValue, "The color and reg value is not same");
                Assert.AreEqual(dayTimeColorTempSliderValue, colorTemperature, "The value is not same with color slider");
            }
        }

        [Given(@"The Temp_Display is not same with Temp_UserSet ""(.*)""")]
        public void GivenTheTemp_DisplayIsNotSameWithTemp_UserSet(string p0)
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            string tempDisplay = IntelligentCoolingBaseHelper.GetCurrentUserRegeditValue("Temp_Display", _ITSRegistryValueECM);
            string dayTimeColorTempSliderValue = _hSDisplayCameraPage.DayTimeColorTempSlider.GetAttribute("Value.Value");
            string tempUserSet = IntelligentCoolingBaseHelper.GetCurrentUserRegeditValue("Temp_UserSet", _ITSRegistryValueECM);
            string colorTempEyeCareModeSliderValue = _hSDisplayCameraPage.ColorTempEyeCareModeSlider.GetAttribute("Value.Value");
            if (dayTimeColorTempSliderValue == colorTempEyeCareModeSliderValue)
            {
                if (tempDisplay == tempUserSet)
                {
                    if (p0 == "Temp_Display")
                    {
                        VantageCommonHelper.DragSlider(_webDriver.Session, _hSDisplayCameraPage.DayTimeColorTempSlider, 100);
                    }
                    else
                    {
                        VantageCommonHelper.DragSlider(_webDriver.Session, _hSDisplayCameraPage.ColorTempEyeCareModeSlider, 100);
                    }
                }
                else
                {
                    throw new Exception("The tempDisplay and tempUserSet value is different");
                }
            }
        }

        [Then(@"The computer temperature default is ""(.*)""")]
        public void ThenTheComputerTemperatureDefaultIs(int p0)
        {
            int colorTemperature = 0;
            if (cpFlag == 1)
            {
                cuiInterFaceClient.Initialize();
                colorTemperature = (int)cuiInterFaceClient.GetColorTemperature();
            }
            else if (cpFlag == 2)
            {
                adlInterFaceClient.Initialize();
                colorTemperature = (int)adlInterFaceClient.GetColorTemperature();
            }
            Assert.AreEqual(p0, colorTemperature, "The color temperature default is not true");
        }

        [Given(@"Get computer temperature value")]
        public void GivenGetComputerTemperatureValue()
        {
            if (cpFlag == 1)
            {
                cuiInterFaceClient.Initialize();
                _colorT = (int)cuiInterFaceClient.GetColorTemperature();
            }
            else if (cpFlag == 2)
            {
                adlInterFaceClient.Initialize();
                _colorT = (int)adlInterFaceClient.GetColorTemperature();
            }
        }

        [Then(@"The computer temperature is not change")]
        public void ThenTheComputerTemperatureIsNotChange()
        {
            int colorTemperature = 0;
            if (cpFlag == 1)
            {
                cuiInterFaceClient.Initialize();
                colorTemperature = (int)cuiInterFaceClient.GetColorTemperature();
            }
            else if (cpFlag == 2)
            {
                adlInterFaceClient.Initialize();
                colorTemperature = (int)adlInterFaceClient.GetColorTemperature();
            }
            Assert.AreEqual(_colorT, colorTemperature, "The computer temperature is change");
        }

        [Then(@"The computer temperature is change")]
        public void ThenTheComputerTemperatureIsChange()
        {
            int colorTemperature = 0;
            if (cpFlag == 1)
            {
                cuiInterFaceClient.Initialize();
                colorTemperature = (int)cuiInterFaceClient.GetColorTemperature();
            }
            else if (cpFlag == 2)
            {
                adlInterFaceClient.Initialize();
                colorTemperature = (int)adlInterFaceClient.GetColorTemperature();
            }
            Assert.AreNotEqual(_colorT, colorTemperature, "The computer temperature is not change");
        }

        [Then(@"The Eye care Mode checkbox is ""(.*)""")]
        public void ThenTheEyeCareModeCheckboxIs(string p0)
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            Assert.NotNull(_hSDisplayCameraPage.CbEyeCareScheduleCheckBox, "The CbEyeCareScheduleCheckBox is not find");
            ToggleState result = VantageCommonHelper.GetToggleStatus(_hSDisplayCameraPage.CbEyeCareScheduleCheckBox);
            if (p0 == "checked")
            {
                Assert.AreEqual(ToggleState.On, result, "The ColorTempEyeCareModeCheckBox is off");
            }
            else if (p0 == "unchecked")
            {
                Assert.AreEqual(ToggleState.Off, result, "The ColorTempEyeCareModeCheckBox is on");
            }
        }

        [Then(@"The ECM ui should be clickable")]
        public void ThenTheECMUiShouldBeClickable()
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            Assert.IsTrue(_hSDisplayCameraPage.DayTimeColorTempResetBtn.Enabled, "The DayTimeColorTempResetBtn can't be clicked");
            Assert.IsTrue(_hSDisplayCameraPage.ColorTempEyeCareModeResetBtn.Enabled, "The ColorTempEyeCareModeResetBtn can't be clicked");
            Assert.IsTrue(_hSDisplayCameraPage.CbEyeCareScheduleCheckBox.Enabled, "The CbEyeCareScheduleCheckBox can't be clicked");
            Assert.IsTrue(_hSDisplayCameraPage.ColorTempEyeCareModeCheckBox.Enabled, "The ColorTempEyeCareModeCheckBox can't be clicked");
            Assert.IsTrue(_hSDisplayCameraPage.DayTimeColorTempSlider.Enabled, "The DayTimeColorTempSlider can't be clicked");
            if (VantageCommonHelper.GetToggleStatus(_hSDisplayCameraPage.ColorTempEyeCareModeCheckBox) == ToggleState.On)
            {
                Assert.IsTrue(_hSDisplayCameraPage.ColorTempEyeCareModeSlider.Enabled, "The ColorTempEyeCareModeSlider can't be clicked");
            }
            else
            {
                Assert.IsFalse(_hSDisplayCameraPage.ColorTempEyeCareModeSlider.Enabled, "The ColorTempEyeCareModeSlider can't be clicked");
            }
        }

        [Then(@"The ECM ui should be Unclickable")]
        public void ThenTheECMUiShouldBeUnClickable()
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            Assert.IsFalse(_hSDisplayCameraPage.DayTimeColorTempResetBtn.Enabled, "The DayTimeColorTempResetBtn can be clicked");
            Assert.IsFalse(_hSDisplayCameraPage.ColorTempEyeCareModeResetBtn.Enabled, "The ColorTempEyeCareModeResetBtn can be clicked");
            Assert.IsFalse(_hSDisplayCameraPage.CbEyeCareScheduleCheckBox.Enabled, "The CbEyeCareScheduleCheckBox can be clicked");
            Assert.IsFalse(_hSDisplayCameraPage.ColorTempEyeCareModeCheckBox.Enabled, "The ColorTempEyeCareModeCheckBox can be clicked");
            Assert.IsFalse(_hSDisplayCameraPage.DayTimeColorTempSlider.Enabled, "The DayTimeColorTempSlider can be clicked");
            if (VantageCommonHelper.GetToggleStatus(_hSDisplayCameraPage.ColorTempEyeCareModeCheckBox) == ToggleState.On)
            {
                Assert.IsFalse(_hSDisplayCameraPage.ColorTempEyeCareModeSlider.Enabled, "The ColorTempEyeCareModeSlider can be clicked");
            }
            else
            {
                Assert.IsTrue(_hSDisplayCameraPage.ColorTempEyeCareModeSlider.Enabled, "The ColorTempEyeCareModeSlider can be clicked");
            }
        }

        [Given(@"Reduction system time")]
        public void GivenReductionSystemTime()
        {
            Thread.Sleep(1500);
            Process.Start("ms-settings:dateandtime");
            Thread.Sleep(2000);
            UIAutomationControl control = new UIAutomationControl();
            AutomationElement toggle = VantageCommonHelper.FindElementByIdIsEnabled(GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.SysDateTimeSyncButton"));
            if (toggle != null)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.SysDateTimeSyncButton"));
                Thread.Sleep(5000);
                AutomationElement markToggle = VantageCommonHelper.FindElementByIdIsEnabled(GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.DisplayAndCamera.SysDateTimeSyncButtonCheckMark"));
                if (markToggle == null)
                {
                    GivenReductionSystemTime();
                }
            }
            else
            {
                KillProcess("SystemSettings");
                GivenReductionSystemTime();
            }
            Thread.Sleep(2000);
            KillProcess("SystemSettings");
        }

        [Then(@"Sunset and Sunrise time ""(.*)""")]
        public void ThenSunsetAndSunriseTime(string p0)
        {
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            List<string> components = new List<string>();
            components.Clear();
            for (int i = 0; i < _hSDisplayCameraPage.CbEyeCareScheduleCheckBoxNames.Count; i++)
            {
                components.Add(_hSDisplayCameraPage.CbEyeCareScheduleCheckBoxNames[i].GetAttribute("Name"));
            }
            if (p0 == "display")
            {
                try
                {
                    spTime = components[1].Split(new string[] { "sunrise" }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                }
                catch
                {
                    throw new Exception("The sunset and sunrise time is not find");
                }
            }
            else
            {
                bool isContains = components[1].Contains("AM");
                Assert.IsFalse(isContains, "The sunset and sunrise time is find");
            }
        }

        [Then(@"The LenovoVisionProtectionPlugin is live")]
        public void ThenTheLenovoVisionProtectionPluginIsLive()
        {
            bool isLive = false;
            Process[] procs = Process.GetProcesses();
            foreach (Process temp in procs)
            {
                if (temp.ProcessName.Contains("ImController"))
                {
                    if (Utility.Common.GetProcessCMDLine(temp).Contains("LenovoVisionProtectionPlugin"))
                    {
                        isLive = true;
                    }
                }
            }
            Assert.IsTrue(isLive, "The LenovoVisionProtectionPlugin is not find");
        }
    }
}
