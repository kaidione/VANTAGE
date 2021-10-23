using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;
using static SmartSenseHsaRpcClient.HumanPresenceDetection;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class HardwareSettingsHPDTestSteps : SettingsBase
    {
        private HSHPDPage hsHPDPage;
        private InformationalWebDriver webDriver;
        private ToggleState ZTLoginCheckbox = ToggleState.Indeterminate;
        private ToggleState ZTLockCheckbox = ToggleState.Indeterminate;
        private ToggleState OverrideCheckbox = ToggleState.Indeterminate;
        private ToggleState FastButtonValue = ToggleState.Indeterminate;
        private ToggleState MediumButtonValue = ToggleState.Indeterminate;
        private ToggleState SlowButtonValue = ToggleState.Indeterminate;
        private string ZTLoginSlider = null;
        private string ZTLockSlider = null;
        private string _packeageconfigfile = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Packages\E046963F.LenovoCompanion_k1h2ywk1493x8\LocalState\config.json";
        private string _configjsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Data\Vantage\config.json");

        public HardwareSettingsHPDTestSteps(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
            hsHPDPage = new HSHPDPage(webDriver.Session);
        }

        [Given(@"Check HPD Reset Button Whether it exists")]
        public void GivenCheckHPDResetButtonWhetherItExists()
        {
            hsHPDPage = new HSHPDPage(webDriver.Session);
            hsHPDPage.GoToSmartAssistPage();
            Assert.IsNotNull(hsHPDPage.HPDResetButton);
        }

        [Given(@"Check ZT Login ADV ADSA switch button is off")]
        public void GivenCheckZTLoginADVADSASwitchButtonIsOff()
        {
            try
            {
                hsHPDPage.IntelligentSecurity?.Click();
                if (hsHPDPage.HPDZeroTouchLoginADVSettings != null)
                {
                    if (hsHPDPage.HPDZeroTouchLoginADVSettings.GetAttribute("Name") == "ADVANCED SETTINGS")
                    {
                        hsHPDPage.HPDZeroTouchLoginADVSettings.Click();
                    }
                    if (hsHPDPage.HPDZeroTouchLoginADSACheckBox != null)
                    {
                        int checkBoxState = Convert.ToInt32(hsHPDPage.HPDZeroTouchLoginADSACheckBox.GetAttribute("Toggle.ToggleState"));
                        if (checkBoxState != 0)
                        {
                            hsHPDPage.HPDZeroTouchLoginADSACheckBox.Click();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("GivenCheckZTLoginADVADSASwitchButtonIsOff Fail Message:" + ex.Message + "");
            }
        }

        [Given(@"Check ZT Login switch button is off")]
        public void GivenCheckZTLoginSwitchButtonIsOff()
        {
            try
            {
                if (HPDZeroTouchLoginCheckBox() != null)
                {
                    int checkBoxState = Convert.ToInt32(HPDZeroTouchLoginCheckBox().GetAttribute("Toggle.ToggleState"));
                    if (checkBoxState != 0)
                    {
                        HPDZeroTouchLoginCheckBox().Click();
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("GivenCheckZTLoginSwitchButtonIsOff Fail Message:" + ex.Message + "");
            }
        }

        [When(@"Click HPD Reset Button")]
        public void WhenClickHPDResetButton()
        {
            hsHPDPage.HPDResetButton?.Click();
        }

        [Then(@"Check ZT Login switch button and ADSA switch button is on")]
        public void ThenCheckZTLoginSwitchButtonAndADSASwitchButtonIsOn()
        {
            VantageCommonHelper.MoveUp(1);
            Assert.AreEqual(ToggleState.On, hsHPDPage.GetCheckBoxStatus(HPDZeroTouchLoginCheckBox()));
            Assert.AreEqual(ToggleState.On, hsHPDPage.GetCheckBoxStatus(hsHPDPage.HPDZeroTouchLoginADSACheckBox));
        }

        [Given(@"Check ZT Login switch button is on")]
        public void GivenCheckZTLoginSwitchButtonIsOn()
        {
            WindowsElement tempCheckBox = HPDZeroTouchLoginCheckBox();
            try
            {
                if (tempCheckBox != null)
                {
                    ToggleState checkBoxState = VantageCommonHelper.GetToggleStatus(tempCheckBox);
                    if (checkBoxState != ToggleState.On)
                    {
                        tempCheckBox.Click();
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("GivenCheckZTLoginSwitchButtonIsOn Fail Message:" + ex.Message + "");
            }
        }

        [Given(@"Click ZT Login ADV ADSA slider bar to ""(.*)""")]
        public void GivenClickZTLoginADVADSASliderBarTo(string sliderBarValue)
        {
            WindowsElement tempSlider = HPDZeroTouchLoginADSASldierBar();
            int width = tempSlider.Size.Width / 2;
            int x = 0;
            if (sliderBarValue == "Near")
            {
                x = -width;
            }
            else
            {
                x = width;
            }
            Assert.NotNull(tempSlider, "The slider is not find");
            bool result = VantageCommonHelper.DragSlider(hsHPDPage.session, tempSlider, x);
            Assert.IsTrue(result, "Drag the slider false");
        }

        [Then(@"Check ZT Login ADV ADSA slider bar Is it consistent with the driving state")]
        public void ThenCheckZTLoginADVADSASliderBarIsItConsistentWithTheDrivingState()
        {
            try
            {
                if (hsHPDPage.HPDZeroTouchLoginADSACheckBox != null)
                {
                    int checkBoxState = Convert.ToInt32(hsHPDPage.HPDZeroTouchLoginADSACheckBox.GetAttribute("Toggle.ToggleState"));
                    if (checkBoxState != 0)
                    {
                        hsHPDPage.HPDZeroTouchLoginADSACheckBox.Click();
                    }
                }

                if (hsHPDPage.ApproachDistance != null)
                {
                    string value = "";
                    string ariaProperties = "";
                    switch (hsHPDPage.ApproachDistance)
                    {
                        case ApproachDistanceType.Near:
                            value = "Near";
                            ariaProperties = "1";
                            break;
                        case ApproachDistanceType.Middle:
                            value = "Middle";
                            ariaProperties = "2";
                            break;
                        case ApproachDistanceType.Far:
                            value = "Far";
                            ariaProperties = "3";
                            break;
                    }
                    Assert.NotNull(HPDZeroTouchLoginADSASldierBar(), "The zero login slider is null, please check the above steps.");
                    string sliderBarValue = HPDZeroTouchLoginADSASldierBar().GetAttribute("Value.Value");
                    string sliderBarAriaProperties = VantageCommonHelper.GetAttributeValue(HPDZeroTouchLoginADSASldierBar(), "AriaProperties");
                    if (sliderBarValue == value || sliderBarAriaProperties == ariaProperties)
                    {
                        Assert.IsTrue(true);
                    }
                    else
                    {
                        Assert.Fail("CheckZTLoginADVADSASliderBarIsItConsistentWithTheDrivingState Fail:HPD Reset fail,Drive Current state: " + value + "(" + ariaProperties + ")" + " ,UI Current state:" + sliderBarValue + "(" + sliderBarAriaProperties + ")");
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("ThenCheckZTLoginADVADSASliderBarIsItConsistentWithTheDrivingState Fail Message:" + ex.Message + "");
            }
        }

        [Given(@"Check Zero Touch Lock switch button is on")]
        public void GivenCheckZeroTouchLockSwitchButtonIsOn()
        {
            try
            {
                if (hsHPDPage.HPDZeroTouchLockCheckbox != null)
                {
                    int checkBoxState = Convert.ToInt32(hsHPDPage.HPDZeroTouchLockCheckbox.GetAttribute("Toggle.ToggleState"));
                    if (checkBoxState != 1)
                    {
                        hsHPDPage.HPDZeroTouchLockCheckbox.Click();
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("GivenCheckZeroTouchLockSwitchButtonIsOn Fail Message:" + ex.Message + "");
            }
        }

        [Given(@"Click Zero Touch Lock ADV Settings Link")]
        public void GivenClickZeroTouchLockADVSettingsLink()
        {
            RemoteTouchScreen touchScreen = new RemoteTouchScreen(webDriver.Session);
            if (hsHPDPage.HPDZeroTouchLockADVSettings != null)
            {
                if (hsHPDPage.HPDZeroTouchLockADVSettings.GetAttribute("Name") == "ADVANCED SETTINGS")
                {
                    hsHPDPage.HPDZeroTouchLockADVSettings.Click();
                    touchScreen.Scroll(0, -30);
                    Thread.Sleep(1000);
                }
                else
                {
                    touchScreen.Scroll(0, -30);
                    Thread.Sleep(1000);
                }
                return;
            }
            Assert.Fail("GivenClickZeroTouchLockADVSettingsLink Fail:HPD Zero Touch Lock ADV Settings Link does not exist.");
            return;
        }

        [Given(@"Click Auto Screen Lock Timer ""(.*)""")]
        public void GivenClickAutoScreenLockTimer(string autoScreenLockTimer)
        {
            try
            {
                int radioState;
                switch (autoScreenLockTimer)
                {
                    case "Fast":
                        Assert.NotNull(hsHPDPage.HPDAutoScreenLockTimerFast);
                        radioState = Convert.ToInt32(hsHPDPage.HPDAutoScreenLockTimerFast.GetAttribute("Toggle.ToggleState"));
                        if (radioState != 1)
                        {
                            hsHPDPage.HPDAutoScreenLockTimerFast.Click();
                        }
                        break;
                    case "Slow":
                        Assert.NotNull(hsHPDPage.HPDAutoScreenLockTimerSlow);
                        radioState = Convert.ToInt32(hsHPDPage.HPDAutoScreenLockTimerSlow.GetAttribute("Toggle.ToggleState"));
                        if (radioState != 1)
                        {
                            hsHPDPage.HPDAutoScreenLockTimerSlow.Click();
                        }
                        break;
                    case "Medium":
                        Assert.NotNull(hsHPDPage.HPDAutoScreenLockTimerMedium);
                        radioState = Convert.ToInt32(hsHPDPage.HPDAutoScreenLockTimerMedium.GetAttribute("Toggle.ToggleState"));
                        if (radioState != 1)
                        {
                            hsHPDPage.HPDAutoScreenLockTimerMedium.Click();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("GivenClickAutoScreenLockTimer Fail Message:" + ex.Message + "");
            }
        }

        [Given(@"Click Zero Touch Lock Facial Recogoition Checkbox")]
        public void GivenClickZeroTouchLockFacialRecogoitionCheckbox()
        {
            Assert.NotNull(hsHPDPage.HPDZeroTouchLockFacialRecogoitionCheckbox);
            int checkBoxState = Convert.ToInt32(hsHPDPage.HPDZeroTouchLockFacialRecogoitionCheckbox.GetAttribute("Toggle.ToggleState"));
            if (checkBoxState != 1)
            {
                hsHPDPage.HPDZeroTouchLockFacialRecogoitionCheckbox.Click();
                VantageCommonHelper.MoveDown(1);
            }
        }

        [Then(@"Check Zero Touch Lock Facial Recogoition Checkbox is not select and Auto Screen Lock UI SldierBar Is it consistent with the driving state")]
        public void ThenCheckZeroTouchLockFacialRecogoitionCheckboxIsNotSelectAndAutoScreenLockUISldierBarIsItConsistentWithTheDrivingState()
        {
            Assert.AreEqual(ToggleState.On, hsHPDPage.GetCheckBoxStatus(hsHPDPage.HPDAutoScreenLockTimerMedium));
            Assert.AreEqual(ToggleState.Off, hsHPDPage.GetCheckBoxStatus(hsHPDPage.HPDZeroTouchLockFacialRecogoitionCheckbox));
            if (hsHPDPage.IsSupportZeroTouchLockADSASwitchButton)
            {
                Assert.AreEqual(ToggleState.On, hsHPDPage.GetCheckBoxStatus(hsHPDPage.HPDZeroTouchLockADSACheckBox));
                if (hsHPDPage.PresenceLeaveDistanceAutoAdjustHasValue == false)
                {
                    Assert.Fail("ThenCheckZeroTouchLockFacialRecogoitionCheckboxIsNotSelectAndAutoScreenLockUISldierBarIsItConsistentWithTheDrivingState fail: Reset ->  Zero Touch Lock ADSA Switch Button off");
                }
                int checkBoxState = Convert.ToInt32(hsHPDPage.HPDZeroTouchLockADSACheckBox.GetAttribute("Toggle.ToggleState"));
                if (checkBoxState != 0)
                {
                    hsHPDPage.HPDZeroTouchLockADSACheckBox.Click();
                }
            }
            if (hsHPDPage.IsSupportZeroTouchLockADSASliderBar)
            {
                if (hsHPDPage.PresenceLeaveDistance != null)
                {
                    string value = "";
                    string ariaProperties = "";
                    switch (hsHPDPage.PresenceLeaveDistance)
                    {
                        case PresenceLeaveDistanceType.Near:
                            value = "Near";
                            ariaProperties = "1";
                            break;
                        case PresenceLeaveDistanceType.Middle:
                            value = "Middle";
                            ariaProperties = "2";
                            break;
                        case PresenceLeaveDistanceType.Far:
                            value = "Far";
                            ariaProperties = "3";
                            break;
                    }
                    Assert.NotNull(HPDZeroTouchLockADSASldierBar());
                    string sliderBarValue = HPDZeroTouchLockADSASldierBar().GetAttribute("Value.Value");
                    string sliderBarAriaProperties = VantageCommonHelper.GetAttributeValue(HPDZeroTouchLockADSASldierBar(), "AriaProperties");
                    if (sliderBarValue == value || sliderBarAriaProperties == ariaProperties)
                    {
                        Assert.IsTrue(true);
                    }
                    else
                    {
                        Assert.Fail("Check HPDZeroTouchLockADSASldierBar Fail:HPD Reset fail,Drive Current state: " + value + "(" + ariaProperties + ")" + " ,UI Current state:" + sliderBarValue + "(" + sliderBarAriaProperties + ")");
                    }
                }
            }
        }

        [StepDefinition(@"Click Zero Touch Lock ADSA switch button is ""(.*)""")]
        public void GivenClickZeroTouchLockADSASwitchButtonIs(string state)
        {
            try
            {
                int stateValue = (state == "on") ? 1 : 0;
                if (hsHPDPage.IsSupportZeroTouchLockADSASwitchButton)
                {
                    if (hsHPDPage.HPDZeroTouchLockADSACheckBox != null)
                    {
                        int checkBoxState = Convert.ToInt32(hsHPDPage.HPDZeroTouchLockADSACheckBox.GetAttribute("Toggle.ToggleState"));
                        if (checkBoxState != stateValue)
                        {
                            hsHPDPage.HPDZeroTouchLockADSACheckBox.Click();
                            VantageCommonHelper.MoveDown(1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("GivenClickZeroTouchLockADSASwitchButtonIs Fail Message:" + ex.Message + "");
            }
        }

        [Given(@"ClicK Zero Touch Lock ADSA SldierBar to ""(.*)""")]
        public void GivenClicKZeroTouchLockADSASldierBarTo(string sliderBarValue)
        {
            if (hsHPDPage.IsSupportZeroTouchLockADSASliderBar)
            {
                WindowsElement tempSlider = HPDZeroTouchLockADSASldierBar();
                int width = tempSlider.Size.Width / 2;
                int x = 0;
                switch (sliderBarValue)
                {
                    case "Near":
                        x = -width;
                        break;
                    case "Middle":
                        x = 0;
                        break;
                    case "Far":
                        x = width;
                        break;
                }
                Assert.NotNull(tempSlider, "The slider bar is not find");
                bool result = VantageCommonHelper.DragSlider(hsHPDPage.session, tempSlider, x);
                Assert.IsTrue(result, "Drag sliderbar false");
            }
        }

        [StepDefinition(@"Go to Smart Assist page")]
        public void GivenGoToSmartAssistPage()
        {
            hsHPDPage = new HSHPDPage(webDriver.Session);
            hsHPDPage.GoToSmartAssistPage();
        }

        [When(@"Click HPD Zero Touch Login ADV Settings Link ""(.*)""")]
        public void WhenClickHPDZeroTouchLoginADVSettingsLink(string linkText)
        {
            RemoteTouchScreen touchScreen = new RemoteTouchScreen(webDriver.Session);
            try
            {
                if (hsHPDPage.HPDZeroTouchLoginADVSettings != null)
                {
                    if (hsHPDPage.HPDZeroTouchLoginADVSettings.GetAttribute("Name") == linkText)
                    {
                        hsHPDPage.HPDZeroTouchLoginADVSettings.Click();
                        touchScreen.Scroll(0, -30);
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        touchScreen.Scroll(0, -30);
                        Thread.Sleep(1000);
                    }
                    Assert.IsTrue(true);
                    return;
                }
                Assert.Fail("WhenClickHPDZeroTouchLoginADVSettingsLink Fail:HPD Zero Touch Login ADV Settings Link does not exist.");
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail("WhenClickHPDZeroTouchLoginADVSettingsLink Fail Message:" + ex.Message + "");
            }
        }

        [Then(@"Check ZT Login ADV Settings ADSA is gray out")]
        public void ThenCheckZTLoginADVSettingsADSAIsGrayOut()
        {
            if (hsHPDPage.HPDZeroTouchLoginADSACheckBox.Enabled)
            {
                Assert.Fail("ThenCheckZTLoginADVSettingsADSAIsGrayOut Fail:HPD Zero Touch Login ADV Settings ADSA Not Gray Out.");
                return;
            }
        }

        [Then(@"Check Zero Touch Login ADV Settings ADSA section is show")]
        public void ThenCheckZeroTouchLoginADVSettingsADSASectionIsShow()
        {
            if (hsHPDPage.HPDZeroTouchLoginADSACheckBox == null)
            {
                Assert.Fail("ThenCheckZeroTouchLoginADVSettingsADSASectionIsShow Fail:HPD Zero Touch Login ADSA CheckBox Not Show");
                return;
            }
        }

        [Then(@"Check Zero Touch Login ADV Settings link text is ""(.*)""")]
        public void ThenCheckZeroTouchLoginADVSettingsLinkTextIs(string linkText)
        {
            if (hsHPDPage.HPDZeroTouchLoginADVSettings.GetAttribute("Name") != linkText)
            {
                Assert.Fail("ThenCheckZeroTouchLoginADVSettingsLinkTextIs Fail:HPD Zero Touch Login ADV Settings Link Text Not " + linkText + "");
                return;
            }
        }

        [Then(@"Check Zero Touch Login ADV Settings ADSA section is fold")]
        public void ThenCheckZeroTouchLoginADVSettingsADSASectionIsFold()
        {
            if (hsHPDPage.HPDZeroTouchLoginADSACheckBox != null)
            {
                Assert.Fail("ThenCheckZeroTouchLoginADVSettingsADSASectionIsFold Fail:HPD Zero Touch Login ADSA CheckBox Not Fold");
                return;
            }
        }

        //[StepDefinition(@"Go to My Device Settings pages")]
        //public void WhenGoToMyDeviceSettingsPages()
        //{
        //    var hsPowerSettingsPage = new HSPowerSettingsPage(webDriver.Session);
        //    hsPowerSettingsPage.GoToMyDevicesSettings();
        //    Thread.Sleep(TimeSpan.FromSeconds(3));
        //    if (hsHPDPage.MyDeviceSettingsLink != null)
        //    {
        //        hsHPDPage.MyDeviceSettingsLink.Click();
        //        return;
        //    }
        //    Assert.Fail("WhenGoToMyDeviceSettingsPage Fail:MyDeviceSettingsLink does not exist.");
        //    return;
        //}

        [When(@"Check Zero Touch Login ADV Settings ADSA Title is ""(.*)""")]
        public void WhenCheckZeroTouchLoginADVSettingsADSATitleIs(string titleText)
        {
            try
            {
                Thread.Sleep(1000);
                if (hsHPDPage.HPDZeroTouchLoginADVSettingsTitle != null)
                {
                    if (hsHPDPage.HPDZeroTouchLoginADVSettingsTitle.GetAttribute("Name") != titleText)
                    {
                        Assert.Fail("WhenCheckZeroTouchLoginADVSettingsADSATitleIs" + titleText + " Fail:Zero Touch Login ADV Settings ADSA Current Title: " + hsHPDPage.HPDZeroTouchLoginADVSettingsTitle.GetAttribute("Name") + "");
                    }
                }
                else
                {
                    Assert.Fail("WhenCheckZeroTouchLoginADVSettingsADSATitleIs" + titleText + " Fail:Zero Touch Login ADV Settings ADSA Title does not exist.");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("WhenCheckZeroTouchLoginADVSettingsADSATitleIs Fail Message:" + ex.Message + "");
            }
        }

        [Then(@"Check Zero Touch Login ADV Settings ADSA On  Description is ""(.*)""")]
        public void ThenCheckZeroTouchLoginADVSettingsADSAOnDescriptionIs(string onDescriptionText)
        {
            if (hsHPDPage.HPDZeroTouchLoginADSACheckBox != null)
            {
                int checkBoxState = Convert.ToInt32(hsHPDPage.HPDZeroTouchLoginADSACheckBox.GetAttribute("Toggle.ToggleState"));
                if (checkBoxState != 1)
                {
                    hsHPDPage.HPDZeroTouchLoginADSACheckBox.Click();
                }
                Thread.Sleep(1000);
                if (hsHPDPage.HPDZeroTouchLoginADVSettingsOnDescription.GetAttribute("Name") != onDescriptionText)
                {
                    Assert.Fail("ThenCheckZeroTouchLoginADVSettingsADSAOnDescriptionIs " + onDescriptionText + " Fail:Zero Touch Login ADV Settings ADSA Current Description:" + hsHPDPage.HPDZeroTouchLoginADVSettingsOnDescription.GetAttribute("Name") + "");
                }
            }
            else
            {
                Assert.Fail("WhenCheckZeroTouchLoginADVSettingsADSAToggleButtonWhetherItExists Fail:Zero Touch Login ADV Settings ADSA ToggleButton does not exist.");
            }
        }

        [Then(@"Check Zero Touch Login ADV Settings \(new sensor\) ADSA Off Description is ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void ThenCheckZeroTouchLoginADVSettingsNewSensorADSAOffDescriptionIsAndAndAndAnd(string description, string mode1, string mode2, string mode3, string mode4)
        {
            CheckZeroTouchLoginADVSettingsDescription(true, description, mode1, mode2, mode3, mode4);
        }

        [Then(@"Check Zero Touch Login ADV Settings \(old sensor\) ADSA Off Description is ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void ThenCheckZeroTouchLoginADVSettingsOldSensorADSAOffDescriptionIsAndAndAndAnd(string description, string mode1, string mode2, string mode3, string mode4)
        {
            CheckZeroTouchLoginADVSettingsDescription(false, description, mode1, mode2, mode3, mode4);
        }

        public void CheckZeroTouchLoginADVSettingsDescription(bool isNewSensor, string description, string mode1, string mode2, string mode3, string mode4)
        {
            try
            {
                if (hsHPDPage.HPDZeroTouchLoginADSACheckBox != null)
                {
                    int checkBoxState = Convert.ToInt32(hsHPDPage.HPDZeroTouchLoginADSACheckBox.GetAttribute("Toggle.ToggleState"));
                    if (checkBoxState != 0)
                    {
                        hsHPDPage.HPDZeroTouchLoginADSACheckBox?.Click();
                    }
                    Thread.Sleep(1000);
                    if (hsHPDPage.HPDSensorType != null)
                    {
                        if ((hsHPDPage.HPDSensorType == SensorType.VL53L1 && !isNewSensor) || (hsHPDPage.HPDSensorType == SensorType.VL53L5 && isNewSensor))
                        {
                            if (hsHPDPage.HPDZeroTouchLoginADVSettingsOffDescription?.GetAttribute("Name") != description)
                            {
                                Assert.Fail("CheckZeroTouchLoginADVSettingsDescription Fail:" + ((isNewSensor) ? "NewSensor" : "OldSensor") + ";CurrentDisplay:(" + hsHPDPage.HPDZeroTouchLoginADVSettingsOffDescription.GetAttribute("Name") + ");ComparisonParameters:(" + description + ")");
                            }
                            if (hsHPDPage.HPDZeroTouchLoginADVSettingsReadMoreMode1?.GetAttribute("Name") != mode1)
                            {
                                Assert.Fail("CheckZeroTouchLoginADVSettingsDescription Fail:" + ((isNewSensor) ? "NewSensor" : "OldSensor") + ";CurrentDisplay:(" + hsHPDPage.HPDZeroTouchLoginADVSettingsReadMoreMode1.GetAttribute("Name") + ");ComparisonParameters:(" + mode1 + ")");
                            }
                            if (hsHPDPage.HPDZeroTouchLoginADVSettingsReadMoreMode2?.GetAttribute("Name") != mode2)
                            {
                                Assert.Fail("CheckZeroTouchLoginADVSettingsDescription Fail:" + ((isNewSensor) ? "NewSensor" : "OldSensor") + ";CurrentDisplay:(" + hsHPDPage.HPDZeroTouchLoginADVSettingsReadMoreMode2.GetAttribute("Name") + ");ComparisonParameters:(" + mode2 + ")");
                            }
                            if (hsHPDPage.HPDZeroTouchLoginADVSettingsReadMoreMode3?.GetAttribute("Name") != mode3)
                            {
                                Assert.Fail("CheckZeroTouchLoginADVSettingsDescription Fail:" + ((isNewSensor) ? "NewSensor" : "OldSensor") + ";CurrentDisplay:(" + hsHPDPage.HPDZeroTouchLoginADVSettingsReadMoreMode3.GetAttribute("Name") + ");ComparisonParameters:(" + mode3 + ")");
                            }
                            if (hsHPDPage.HPDZeroTouchLoginADVSettingsReadMoreMode4?.GetAttribute("Name") != mode4)
                            {
                                Assert.Fail("CheckZeroTouchLoginADVSettingsDescription Fail:" + ((isNewSensor) ? "NewSensor" : "OldSensor") + ";CurrentDisplay:(" + hsHPDPage.HPDZeroTouchLoginADVSettingsReadMoreMode4.GetAttribute("Name") + ");ComparisonParameters:(" + mode4 + ")");
                            }
                        }
                    }
                }
                else
                {
                    Assert.Fail("CheckZeroTouchLoginADVSettingsDescription Fail:Zero Touch Login ADV Settings ADSA ToggleButton does not exist.");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("CheckZeroTouchLoginADVSettingsDescription Fail Message:" + ex.Message + "");
            }
        }

        [Then(@"Check The Zero Touch Login ADV Settings ADSA Windows Hello Text ""(.*)"" and ""(.*)""")]
        public void ThenCheckTheZeroTouchLoginADVSettingsADSAWindowsHelloTextAnd(string noteText, string linkText)
        {
            if (hsHPDPage.FaceIdRegisteredHasValue == true)
            {
                if (hsHPDPage.HPDZeroTouchLoginADSACheckBox != null)
                {
                    int checkBoxState = Convert.ToInt32(hsHPDPage.HPDZeroTouchLoginADSACheckBox.GetAttribute("Toggle.ToggleState"));
                    if (checkBoxState != 1)
                    {
                        hsHPDPage.HPDZeroTouchLoginADSACheckBox.Click();
                    }
                    if (hsHPDPage.HPDZeroTouchLoginADSAWindowsHelloNote?.GetAttribute("Name") != noteText)
                    {
                        Assert.Fail("ThenCheckTheZeroTouchLoginADVSettingsADSAWindowsHelloText " + noteText + " Fail:Current UI display:" + hsHPDPage.HPDZeroTouchLoginADSAWindowsHelloNote?.GetAttribute("Name") + "");
                    }
                    if (hsHPDPage.HPDZeroTouchLoginADSAWindowsHelloLink?.GetAttribute("Name") != linkText)
                    {
                        Assert.Fail("ThenCheckTheZeroTouchLoginADVSettingsADSAWindowsHelloText " + linkText + " Fail:Current UI display:" + hsHPDPage.HPDZeroTouchLoginADSAWindowsHelloLink?.GetAttribute("Name") + "");
                    }
                }
                else
                {
                    Assert.Fail("ThenCheckTheZeroTouchLoginADVSettingsADSAWindowsHelloText " + noteText + " And " + linkText + " Fail:Zero Touch Login ADV Settings ADSA ToggleButton does not exist.");
                }
            }
        }

        [Then(@"Click the link Go to Windows Hello Settings")]
        public void ThenClickTheLinkGoToWindowsHelloSettings()
        {
            try
            {
                if (!(bool)hsHPDPage.FaceIdRegisteredHasValue)
                {
                    if (hsHPDPage.HPDZeroTouchLoginADSACheckBox != null)
                    {
                        int checkBoxState = Convert.ToInt32(hsHPDPage.HPDZeroTouchLoginADSACheckBox.GetAttribute("Toggle.ToggleState"));
                        if (checkBoxState != 1)
                        {
                            hsHPDPage.HPDZeroTouchLoginADSACheckBox?.Click();
                            VantageCommonHelper.MoveDown(3);
                        }
                        hsHPDPage.HPDZeroTouchLoginADSAWindowsHelloLink?.Click();
                        Thread.Sleep(3000);
                    }
                    else
                    {
                        Assert.Fail("ThenClickTheLinkGoToWindowsHelloSettings Fail:Zero Touch Login ADV Settings ADSA ToggleButton does not exist.");
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("ThenClickTheLinkGoToWindowsHelloSettings Fail Message:" + ex.Message + "");
            }
        }

        [When(@"Check Zero Touch Lock section icon and header text ""(.*)"" and toggle")]
        public void WhenCheckZeroTouchLockSectionIconAndHeaderTextAndToggle(string headerText)
        {
            VantageCommonHelper.MoveDown(1);
            Thread.Sleep(1000);
            if (hsHPDPage.HPDZeroTouchLockTitle?.GetAttribute("Name") != headerText)
            {
                Assert.Fail("WhenCheckZeroTouchLockSectionIconAndHeaderTextAndToggle Fail:The current title (" + hsHPDPage.HPDZeroTouchLockTitle?.GetAttribute("Name") + ") is not (" + headerText + ")");
            }
            if (hsHPDPage.HPDZeroTouchLockCheckbox == null)
            {
                Assert.Fail("WhenCheckZeroTouchLockSectionIconAndHeaderTextAndToggle Fail:HPD Zero Touch Lock Toggle Button  does not exist.");
            }
        }

        [Then(@"Check Zero Touch Lock section description Text ""(.*)""")]
        public void ThenCheckZeroTouchLockSectionDescriptionText(string descriptionText)
        {
            if (hsHPDPage.HPDZeroTouchLockDescription?.GetAttribute("Name") != descriptionText)
            {
                Assert.Fail("ThenCheckZeroTouchLockSectionDescriptionText Fail:HPD Zero Touch Lock The current description :(" + hsHPDPage.HPDZeroTouchLockDescription?.GetAttribute("Name") + ") is not (" + descriptionText + ")");
            }
        }

        [When(@"Check Zero Touch Lock switch button is off")]
        public void WhenCheckZeroTouchLockSwitchButtonIsOff()
        {
            try
            {
                if (hsHPDPage.HPDZeroTouchLockCheckbox != null)
                {
                    int checkBoxState = Convert.ToInt32(hsHPDPage.HPDZeroTouchLockCheckbox.GetAttribute("Toggle.ToggleState"));
                    if (checkBoxState != 0)
                    {
                        hsHPDPage.HPDZeroTouchLockCheckbox.Click();
                    }
                }
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Assert.Fail("GivenCheckZeroTouchLockSwitchButtonIsOn Fail Message:" + ex.Message + "");
            }
        }

        [Then(@"Check Zero Touch Lock section The whole feature will grey out")]
        public void ThenCheckZeroTouchLockSectionTheWholeFeatureWillGreyOut()
        {
            hsHPDPage = new HSHPDPage(webDriver.Session);
            if (hsHPDPage.HPDZeroTouchLockFacialRecogoitionCheckbox.Enabled)
            {
                Assert.Fail("ThenCheckZeroTouchLockSectionTheWholeFeatureWillGreyOut Fail:HPD Zero Touch Lock Facial Recogoition Checkbox Not Gray Out.");
            }
            if (hsHPDPage.HPDAutoScreenLockTimerFast.Enabled)
            {
                Assert.Fail("ThenCheckZeroTouchLockSectionTheWholeFeatureWillGreyOut Fail:HPD AutoScreen Lock Timer Fast Not Gray Out.");
            }
            if (hsHPDPage.HPDAutoScreenLockTimerMedium.Enabled)
            {
                Assert.Fail("ThenCheckZeroTouchLockSectionTheWholeFeatureWillGreyOut Fail:HPD AutoScreen Lock Timer Medium Not Gray Out.");
            }
            if (hsHPDPage.HPDAutoScreenLockTimerSlow.Enabled)
            {
                Assert.Fail("ThenCheckZeroTouchLockSectionTheWholeFeatureWillGreyOut Fail:HPD AutoScreen Lock Timer Slow Not Gray Out.");
            }
            if (hsHPDPage.IsSupportZeroTouchLockADSASwitchButton)
            {
                if (hsHPDPage.HPDZeroTouchLockADSACheckBox.Enabled)
                {
                    Assert.Fail("ThenCheckZeroTouchLockSectionTheWholeFeatureWillGreyOut Fail:HPD Zero Touch Lock ADSA Toggle Button Not Gray Out.");
                }
            }
            if (hsHPDPage.IsSupportZeroTouchLockADSASliderBar)
            {
                if (HPDZeroTouchLockADSASldierBar().Enabled)
                {
                    Assert.Fail("ThenCheckZeroTouchLockSectionTheWholeFeatureWillGreyOut Fail:HPD Zero Touch Lock ADSA SldierBar Not Gray Out.");
                }
            }
        }

        [Then(@"Check Show include FACIAL RECOGNITION AUTO SCREEN LOCK TIMER and AUTO DISTANCE SENSITIVITY ADJUSTING")]
        public void ThenCheckShowIncludeFACIALRECOGNITIONAUTOSCREENLOCKTIMERAndAUTODISTANCESENSITIVITYADJUSTING()
        {
            if (hsHPDPage.HPDZeroTouchLockFaicalRecognitionTitle == null)
            {
                Assert.Fail("ThenCheckShowIncludeFACIALRECOGNITIONAUTOSCREENLOCKTIMERAndAUTODISTANCESENSITIVITYADJUSTING Fail:HPD Zero Touch Lock Faical Recognition Title Not Show");
            }
            if (hsHPDPage.HPDZeroTouchLockFacialRecogoitionCheckbox == null)
            {
                Assert.Fail("ThenCheckShowIncludeFACIALRECOGNITIONAUTOSCREENLOCKTIMERAndAUTODISTANCESENSITIVITYADJUSTING Fail:HPD Zero Touch Lock Facial Recogoition Checkbox Not Show");
            }
            if (hsHPDPage.HPDZeroTouchLockTimerTitle == null)
            {
                Assert.Fail("ThenCheckShowIncludeFACIALRECOGNITIONAUTOSCREENLOCKTIMERAndAUTODISTANCESENSITIVITYADJUSTING Fail:HPD Zero Touch Lock Timer Title Not Show");
            }
            if (hsHPDPage.HPDAutoScreenLockTimerFast == null)
            {
                Assert.Fail("ThenCheckShowIncludeFACIALRECOGNITIONAUTOSCREENLOCKTIMERAndAUTODISTANCESENSITIVITYADJUSTING Fail:HPD Auto Screen Lock Timer Fast Not Show");
            }
            if (hsHPDPage.HPDAutoScreenLockTimerMedium == null)
            {
                Assert.Fail("ThenCheckShowIncludeFACIALRECOGNITIONAUTOSCREENLOCKTIMERAndAUTODISTANCESENSITIVITYADJUSTING Fail:HPD Auto Screen Lock Timer Medium Not Show");
            }
            if (hsHPDPage.HPDAutoScreenLockTimerSlow == null)
            {
                Assert.Fail("ThenCheckShowIncludeFACIALRECOGNITIONAUTOSCREENLOCKTIMERAndAUTODISTANCESENSITIVITYADJUSTING Fail:HPD Auto Screen Lock Timer Slow Not Show");
            }
            if (hsHPDPage.IsSupportZeroTouchLockADSASwitchButton)
            {
                if (hsHPDPage.HPDZeroTouchLockADSACheckBox == null)
                {
                    Assert.Fail("ThenCheckShowIncludeFACIALRECOGNITIONAUTOSCREENLOCKTIMERAndAUTODISTANCESENSITIVITYADJUSTING Fail:HPD Zero Touch Lock ADSA SwitchButton Not Show");
                }
            }
        }

        [Then(@"Check Zero Touch Lock ADV Settings Link Text is ""(.*)""")]
        public void ThenCheckZeroTouchLockADVSettingsLinkTextIs(string linkText)
        {
            if (hsHPDPage.HPDZeroTouchLockADVSettings.GetAttribute("Name") != linkText)
            {
                Assert.Fail("ThenCheckZeroTouchLockADVSettingsLinkTextIs " + linkText + " Fail: Current Link Text is " + hsHPDPage.HPDZeroTouchLockADVSettings.GetAttribute("Name") + "");
            }
        }

        [When(@"Click HPD Zero Touch Lock ADV Settings Link ""(.*)""")]
        public void WhenClickHPDZeroTouchLockADVSettingsLink(string linkText)
        {
            if (hsHPDPage.HPDZeroTouchLockADVSettings != null)
            {
                if (hsHPDPage.HPDZeroTouchLockADVSettings.GetAttribute("Name") == linkText)
                {
                    hsHPDPage.HPDZeroTouchLockADVSettings.Click();
                }
                Assert.IsTrue(true);
                return;
            }
            Assert.Fail("WhenClickHPDZeroTouchLockADVSettingsLink Fail:HPD Zero Touch Lock ADV Settings Link does not exist.");
            return;
        }

        [Then(@"Check Zero Touch Lock ADV Settings ADSA section is show")]
        public void ThenCheckZeroTouchLockADVSettingsADSASectionIsShow()
        {
            if (hsHPDPage.HPDZeroTouchLockFaicalRecognitionTitle == null)
            {
                Assert.Fail("ThenCheckZeroTouchLockADVSettingsADSASectionIsShow Fail:HPD Zero Touch Lock Faical Recognition Title Not Show");
                return;
            }
        }

        [Then(@"Check Zero Touch Lock ADV Settings ADSA section is fold")]
        public void ThenCheckZeroTouchLockADVSettingsADSASectionIsFold()
        {
            if (hsHPDPage.HPDZeroTouchLockFaicalRecognitionTitle != null)
            {
                Assert.Fail("ThenCheckZeroTouchLockADVSettingsADSASectionIsFold Fail:HPD Zero Touch Lock Faical Recognition Title Not Fold");
                return;
            }
        }

        [Then(@"Check the UI header text ""(.*)"" and  description text ""(.*)"" and checkbox text is ""(.*)""")]
        public void ThenCheckTheUIHeaderTextAndDescriptionTextAndCheckboxTextIs(string headerText, string descriptionText, string checkBoxText)
        {
            if (hsHPDPage.HPDZeroTouchLockFaicalRecognitionTitle.GetAttribute("Name") != headerText)
            {
                Assert.Fail("ThenCheckTheUIHeaderTextAndDescriptionTextAndCheckbox Fail:HPD Zero Touch Lock Faical Recognition Title Current UI Text:(" + hsHPDPage.HPDZeroTouchLockFaicalRecognitionTitle.GetAttribute("Name") + ") Not Text:(" + headerText + ")");
            }
            if (hsHPDPage.HPDZeroTouchLockFaicalRecognitionDesc.GetAttribute("Name") != descriptionText)
            {
                Assert.Fail("ThenCheckTheUIHeaderTextAndDescriptionTextAndCheckbox Fail:HPD Zero Touch Lock Faical Recognition Desc Current UI Text:(" + hsHPDPage.HPDZeroTouchLockFaicalRecognitionDesc.GetAttribute("Name") + ") Not Text:(" + descriptionText + ")");
            }
            string checkBoxName = hsHPDPage.HPDZeroTouchLockFacialRecogoitionCheckbox?.GetAttribute("Name");
            if (checkBoxName != checkBoxText)
            {
                Assert.Fail("ThenCheckTheUIHeaderTextAndDescriptionTextAndCheckbox Fail:HPD Zero Touch Lock Facial Recogoition Checkbox Name :(" + checkBoxName + ") Not Checkbox Text:(" + checkBoxText + ")");
            }
        }

        [Given(@"Go to System Camera Settings page")]
        public void GivenGoToSystemCameraSettingsPage()
        {
            Process.Start("ms-settings:privacy-webcam");
        }

        [StepDefinition(@"Check System Settings page Vantage camera permission is ""(.*)""")]
        public void GivenCheckSystemSettingsPageVantageCameraPermissionIs(string value)
        {
            ToggleState state = (value.ToLower() == "on") ? ToggleState.On : ToggleState.Off;
            AutomationElement lenovoCompanionToggleSwitch = null;
            TogglePattern companionToggleSwitch = null;
            int a = 0;
            int b = 0;
            try
            {
                bool operationCompleted = false;
                while (!operationCompleted)
                {
                    if (hsHPDPage.IsProcessExists("SystemSettings.exe"))
                    {
                        Thread.Sleep(3000);
                        VantageCommonHelper.MoveDown();
                        while (lenovoCompanionToggleSwitch == null)
                        {
                            b++;
                            PropertyCondition toggleSwitchEnabled = new PropertyCondition(AutomationElement.IsEnabledProperty, true);
                            PropertyCondition propertyCondition = new PropertyCondition(AutomationElement.AutomationIdProperty, hsHPDPage.LenovoCompanionToggleSwitch);
                            AndCondition toggleSwitch = new AndCondition(propertyCondition, toggleSwitchEnabled);
                            lenovoCompanionToggleSwitch = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, toggleSwitch);
                            if (lenovoCompanionToggleSwitch != null || b > 10)
                            {
                                break;
                            }
                            Thread.Sleep(1000);
                        }
                        companionToggleSwitch = lenovoCompanionToggleSwitch.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                        if (companionToggleSwitch.Current.ToggleState != state && companionToggleSwitch.Current.ToggleState != ToggleState.Indeterminate)
                        {
                            companionToggleSwitch.Toggle();
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            if (companionToggleSwitch.Current.ToggleState == state)
                            {
                                operationCompleted = true;
                                hsHPDPage.ExitProcess("SystemSettings.exe");
                                break;
                            }
                        }
                    }
                    else
                    {
                        a++;
                        if (a > 10)
                        {
                            break;
                        }
                        Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("GivenCheckSystemSettingsPageVantageCameraPermissionIs Fail Message:" + ex.Message + "");
            }
        }

        [When(@"Click Display&Camera Page Camera Privacy Mode switch button is ""(.*)""")]
        public void WhenClickDisplayCameraPageCameraPrivacyModeSwitchButtonIs(string value)
        {
            int state = (value == "on") ? 1 : 0;
            Thread.Sleep(3000);
            hsHPDPage.DisplayAndCameraLink?.Click();
            Thread.Sleep(3000);
            hsHPDPage.CameraLink?.Click();
            if (hsHPDPage.CameraPrivacyToggle != null)
            {
                int checkBoxState = Convert.ToInt32(hsHPDPage.CameraPrivacyToggle?.GetAttribute("Toggle.ToggleState"));
                if (checkBoxState != state)
                {
                    hsHPDPage.CameraPrivacyToggle.Click();
                }
            }
        }

        [Then(@"Check The checkbox of HPD is grey out and can not be changed")]
        public void ThenCheckTheCheckboxOfHPDIsGreyOutAndCanNotBeChanged()
        {
            VantageCommonHelper.MoveDown(1);
            if (hsHPDPage.HPDZeroTouchLockFacialRecogoitionCheckbox.Enabled)
            {
                Assert.Fail("ThenCheckTheCheckboxOfHPDIsGreyOutAndCanNotBeChanged Fail:HPD Zero Touch Lock Facial Recogoition Checkbox Not Gray Out.");
            }
        }

        [When(@"Click HPD Zero Touch Lock Tip Access note text is ""(.*)"" and link text is ""(.*)""")]
        public void WhenClickHPDZeroTouchLockTipAccessNoteTextIsAndLinkTextIs(string noteText, string linkText)
        {
            if (hsHPDPage.HPDZeroTouchLockFacialRecognitionPermissionNote?.GetAttribute("Name").Trim() != noteText)
            {
                Assert.Fail("WhenClickHPDZeroTouchLockTipAccessNoteTextIsAndLinkTextIs Fail:HPD Zero Touch Lock Facial Recognition Permission Note Current UI Text:(" + hsHPDPage.HPDZeroTouchLockFacialRecognitionPermissionNote?.GetAttribute("Name").Trim() + ") Not Text:(" + noteText + ")");
            }
            if (hsHPDPage.HPDZeroTouchLockFacialRecognitionAccessUrl?.GetAttribute("Name").Trim() != linkText)
            {
                Assert.Fail("WhenClickHPDZeroTouchLockTipAccessNoteTextIsAndLinkTextIs Fail:HPD Zero Touch Lock Facial Recognition Access Url Current UI Text:(" + hsHPDPage.HPDZeroTouchLockFacialRecognitionAccessUrl?.GetAttribute("Name").Trim() + ") Not Text:(" + linkText + ")");
            }
        }

        [When(@"Click HPD Zero Touch Lock Tip Privacy note text is ""(.*)"" and link text is ""(.*)""")]
        public void WhenClickHPDZeroTouchLockTipPrivacyNoteTextIsAndLinkTextIs(string noteText, string linkText)
        {
            if (hsHPDPage.HPDZeroTouchLockFacialRecognitionPrivacyNote?.GetAttribute("Name").Trim() != noteText.Trim())
            {
                Assert.Fail("WhenClickHPDZeroTouchLockTipPrivacyNoteTextIsAndLinkTextIs Fail:HPD Zero Touch Lock Facial Recognition Privacy Note Current UI Text:(" + hsHPDPage.HPDZeroTouchLockFacialRecognitionPrivacyNote?.GetAttribute("Name") + ") Not Text:(" + noteText + ")");
            }
            if (hsHPDPage.HPDZeroTouchLockFacialRecognitionPrivacyUrl?.GetAttribute("Name").Trim() != linkText)
            {
                Assert.Fail("WhenClickHPDZeroTouchLockTipPrivacyNoteTextIsAndLinkTextIs Fail:HPD Zero Touch Lock Facial Recognition Access Url Current UI Text:(" + hsHPDPage.HPDZeroTouchLockFacialRecognitionPrivacyUrl?.GetAttribute("Name").Trim() + ") Not Text:(" + linkText + ")");
            }
        }

        [When(@"Click Auto Screen Lock Timer question mark icon")]
        public void WhenClickAutoScreenLockTimerQuestionMarkIcon()
        {
            hsHPDPage.HPDZeroTouchLockAutoScreenLockTimerRightIcon?.Click();
        }

        [Then(@"Check HPD Auto Screen Lock Timer question mark text is ""(.*)""")]
        public void ThenCheckHPDAutoScreenLockTimerQuestionMarkTextIs(string toolTipText)
        {
            if (hsHPDPage.HPDZeroTouchLockAutoScreenLockTimerToolTip?.GetAttribute("Name") != toolTipText)
            {
                Assert.Fail("ThenCheckHPDAutoScreenLockTimerQuestionMarkTextIs Fail:HPD Zero Touch Lock Auto Screen Lock Timer ToolTip Current UI Text:(" + hsHPDPage.HPDZeroTouchLockAutoScreenLockTimerToolTip?.GetAttribute("Name") + ") Not Text:(" + toolTipText + ")");
            }
        }

        [Then(@"Check The ADSA switch button on context of the description should be ""(.*)""")]
        public void ThenCheckTheADSASwitchButtonOnContextOfTheDescriptionShouldBe(string descriptionText)
        {
            if (hsHPDPage.IsSupportZeroTouchLockADSASwitchButton)
            {
                if (hsHPDPage.HPDZeroTouchLockDistanceAdjustStatusOn?.GetAttribute("Name") != descriptionText)
                {
                    Assert.Fail("ThenCheckTheADSAContextOfTheDescriptionShouldBe Fail:HPD Zero Touch Lock Distance Adjust Status On Current UI Text:(" + hsHPDPage.HPDZeroTouchLockDistanceAdjustStatusOn?.GetAttribute("Name") + ") Not Text:(" + descriptionText + ")");
                }
            }
        }

        [Then(@"Check The ADSA switch button off context of the description should be ""(.*)"" and ""(.*)"" and ""(.*)"" and ""(.*)""")]
        public void ThenCheckTheADSASwitchButtonOffContextOfTheDescriptionShouldBeAndAndAnd(string descriptionText, string mode1, string mode2, string mode3)
        {
            if (hsHPDPage.IsSupportZeroTouchLockADSASwitchButton)
            {
                if (hsHPDPage.HPDZeroTouchLockDistanceAdjustStatusOff?.GetAttribute("Name") != descriptionText)
                {
                    Assert.Fail("ThenCheckTheADSASwitchButtonOffContextOfTheDescriptionShouldBeAndAndAnd Fail:HPD Zero Touch Lock Distance Adjust Status Off Current UI Text:(" + hsHPDPage.HPDZeroTouchLockDistanceAdjustStatusOff?.GetAttribute("Name") + ") Not Text:(" + descriptionText + ")");
                }
                if (hsHPDPage.HPDZeroTouchLockDistanceAdjustReadMoreMode1?.GetAttribute("Name") != mode1)
                {
                    Assert.Fail("ThenCheckTheADSASwitchButtonOffContextOfTheDescriptionShouldBeAndAndAnd Fail:HPD Zero Touch Lock Distance Adjust Read More Mode1 Current UI Text:(" + hsHPDPage.HPDZeroTouchLockDistanceAdjustReadMoreMode1?.GetAttribute("Name") + ") Not Text:(" + mode1 + ")");
                }
                if (hsHPDPage.HPDZeroTouchLockDistanceAdjustReadMoreMode2?.GetAttribute("Name") != mode2)
                {
                    Assert.Fail("ThenCheckTheADSASwitchButtonOffContextOfTheDescriptionShouldBeAndAndAnd Fail:HPD Zero Touch Lock Distance Adjust Read More Mode2 Current UI Text:(" + hsHPDPage.HPDZeroTouchLockDistanceAdjustReadMoreMode2?.GetAttribute("Name") + ") Not Text:(" + mode2 + ")");
                }
                if (hsHPDPage.HPDZeroTouchLockDistanceAdjustReadMoreMode3?.GetAttribute("Name") != mode3)
                {
                    Assert.Fail("ThenCheckTheADSASwitchButtonOffContextOfTheDescriptionShouldBeAndAndAnd Fail:HPD Zero Touch Lock Distance Adjust Read More Mode3 Current UI Text:(" + hsHPDPage.HPDZeroTouchLockDistanceAdjustReadMoreMode3?.GetAttribute("Name") + ") Not Text:(" + mode3 + ")");
                }
            }
        }

        [Given(@"Click HPD Zero Touch Login question mark icon")]
        public void GivenClickHPDZeroTouchLoginQuestionMarkIcon()
        {
            hsHPDPage.HPDZeroTouchLoginRightIcon?.Click();
        }

        [Then(@"Check HPD Zero Touch Login question mark text is ""(.*)""")]
        public void ThenCheckHPDZeroTouchLoginQuestionMarkTextIs(string toolTipText)
        {
            if (hsHPDPage.HPDZeroTouchLoginToolTip?.GetAttribute("Name") != toolTipText)
            {
                Assert.Fail("ThenCheckHPDZeroTouchLoginQuestionMarkTextIs Fail:HPD Zero Touch Login ToolTip Current UI Text:(" + hsHPDPage.HPDZeroTouchLoginToolTip?.GetAttribute("Name") + ") Not Text:(" + toolTipText + ")");
            }
        }

        [When(@"Click Go to Camera Access link")]
        public void WhenClickGoToCameraAccessLink()
        {
            VantageCommonHelper.MoveDown();
            hsHPDPage.HPDZeroTouchLockFacialRecognitionAccessUrl?.Click();
            Thread.Sleep(3000);
        }

        [StepDefinition(@"Check System Settings page Vantage Camera Global Toggle Switch is ""(.*)""")]
        public void GivenCheckSystemSettingsPageVantageCameraGlobalToggleSwitchIs(string value)
        {
            ToggleState state = (value.ToLower() == "on") ? ToggleState.On : ToggleState.Off;
            AutomationElement lenovoCompanionToggleSwitch = null;
            TogglePattern companionToggleSwitch = null;
            int a = 0;
            int b = 0;
            try
            {
                bool operationCompleted = false;
                while (!operationCompleted)
                {
                    if (hsHPDPage.IsProcessExists("SystemSettings.exe"))
                    {
                        Thread.Sleep(3000);
                        while (lenovoCompanionToggleSwitch == null)
                        {
                            b++;
                            PropertyCondition toggleSwitchEnabled = new PropertyCondition(AutomationElement.IsEnabledProperty, true);
                            PropertyCondition propertyCondition = new PropertyCondition(AutomationElement.AutomationIdProperty, hsHPDPage.SystemSettingsCameraGlobalToggleSwitch);
                            AndCondition toggleSwitch = new AndCondition(propertyCondition, toggleSwitchEnabled);
                            lenovoCompanionToggleSwitch = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, toggleSwitch);
                            if (lenovoCompanionToggleSwitch != null || b > 10)
                            {
                                break;
                            }
                            Thread.Sleep(1000);
                        }
                        companionToggleSwitch = lenovoCompanionToggleSwitch.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                        if (companionToggleSwitch.Current.ToggleState != state && companionToggleSwitch.Current.ToggleState != ToggleState.Indeterminate)
                        {
                            companionToggleSwitch.Toggle();
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            if (companionToggleSwitch.Current.ToggleState == state)
                            {
                                operationCompleted = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        a++;
                        if (a > 10)
                        {
                            break;
                        }
                        Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("GivenCheckSystemSettingsPageVantageCameraGlobalToggleSwitchIs Fail Message:" + ex.Message + "");
            }
        }

        [When(@"Check Zero Touch Login section icon and header text ""(.*)"" and toggle")]
        public void WhenCheckZeroTouchLoginSectionIconAndHeaderTextAndToggle(string headerText)
        {
            Thread.Sleep(1000);
            if (hsHPDPage.HPDZeroTouchLoginTitle?.GetAttribute("Name") != headerText)
            {
                Assert.Fail("WhenCheckZeroTouchLoginSectionIconAndHeaderTextAndToggle Fail:The current title (" + hsHPDPage.HPDZeroTouchLoginTitle?.GetAttribute("Name") + ") is not (" + headerText + ")");
            }
            if (HPDZeroTouchLoginCheckBox() == null)
            {
                Assert.Fail("WhenCheckZeroTouchLoginSectionIconAndHeaderTextAndToggle Fail:HPD Zero Touch Login Toggle Button  does not exist.");
            }
        }

        [Then(@"Check Zero Touch Login section description Text ""(.*)""")]
        public void ThenCheckZeroTouchLoginSectionDescriptionText(string descriptionText)
        {
            if (hsHPDPage.HPDZeroTouchLoginCaption?.GetAttribute("Name") != descriptionText)
            {
                Assert.Fail("ThenCheckZeroTouchLoginSectionDescriptionText Fail:HPD Zero Touch Login The current description :(" + hsHPDPage.HPDZeroTouchLoginCaption?.GetAttribute("Name") + ") is not (" + descriptionText + ")");
            }
        }

        [When(@"Check HPD head Does the image exist")]
        public void WhenCheckHPDHeadDoesTheImageExist()
        {
            if (hsHPDPage.HPDImage != null)
            {
                if (hsHPDPage.HPDImage.Size.Width > 0 && hsHPDPage.HPDImage.Size.Height > 0)
                {
                    Assert.IsTrue(true);
                    return;
                }
            }
            Assert.Fail("WhenCheckHPDHeadDoesTheImageExist Fail:HPD Image does not exist");
            return;
        }

        [Then(@"The image is under on the reset button")]
        public void ThenTheImageIsUnderOnTheResetButton()
        {
            int imageT = hsHPDPage.HPDImage != null ? hsHPDPage.HPDImage.Location.Y : 0;
            int ResetT = hsHPDPage.HPDResetButton != null ? hsHPDPage.HPDResetButton.Location.Y : 0;
            if (imageT != 0 && ResetT != 0 && imageT > ResetT)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.Fail("WhenCheckHPDStaticImageExist Fail: HPD image location is wrong");
        }

        [Then(@"Check HPD head Text above image is ""(.*)"" and ""(.*)""")]
        public void ThenCheckHPDHeadTextAboveImageIsAnd(string wordTitle, string wordDescription)
        {
            if (hsHPDPage.HPDWordTitle?.GetAttribute("Name") != wordTitle)
            {
                Assert.Fail("ThenCheckHPDHeadTextAboveImageIsAnd Fail:HPD current Word Title :(" + hsHPDPage.HPDWordTitle?.GetAttribute("Name") + ") is not (" + wordTitle + ")");
            }
            if (hsHPDPage.HPDWordDescription?.GetAttribute("Name") != wordDescription)
            {
                Assert.Fail("ThenCheckHPDHeadTextAboveImageIsAnd Fail:HPD current Word Description :(" + hsHPDPage.HPDWordDescription?.GetAttribute("Name") + ") is not (" + wordDescription + ")");
            }
        }

        [Then(@"There is ""(.*)"" link")]
        public void ThenThereIsLink(string helloLink)
        {
            Assert.IsNotNull(hsHPDPage.HPDZeroTouchLoginADSAWindosHelloLeLink, "The hello link is not find");
            Assert.AreEqual(hsHPDPage.HPDZeroTouchLoginADSAWindosHelloLeLink.GetAttribute("Name"), helloLink, "The Ui text is not true");
        }

        [Given(@"Close ZT Login switch button")]
        public void GivenCloseZTLoginSwitchButton()
        {
            WindowsElement tempCheckBox = HPDZeroTouchLoginCheckBox();
            Assert.IsNotNull(tempCheckBox, "The checkbox is not find");
            bool result = VantageCommonHelper.SwitchToggleStatus(tempCheckBox, ToggleState.Off);
            Assert.IsTrue(result, "Turn Off the checkbox false");
        }

        [Given(@"""(.*)"" the Override checkbox")]
        public void GivenTheOverrideCheckbox(string p0)
        {
            if (p0 == "Checked")
            {
                bool result = VantageCommonHelper.SwitchToggleStatus(hsHPDPage.AutoScreenTimeoutCheckbox, ToggleState.On);
                Assert.IsTrue(result, "Turn On the AutoScreenTimeoutCheckbox false");
            }
            else
            {
                bool result = VantageCommonHelper.SwitchToggleStatus(hsHPDPage.AutoScreenTimeoutCheckbox, ToggleState.Off);
                Assert.IsTrue(result, "Turn Off the AutoScreenTimeoutCheckbox false");
            }
        }


        [Given(@"Close Zero Touch Lock button")]
        public void GivenCloseZeroTouchLockButton()
        {
            Assert.IsNotNull(hsHPDPage.HPDZeroTouchLockCheckbox, "The HPDZeroTouchLockCheckbox is not find");
            bool result = VantageCommonHelper.SwitchToggleStatus(hsHPDPage.HPDZeroTouchLockCheckbox, ToggleState.Off);
            Assert.IsTrue(result, "Turn Off the HPDZeroTouchLockCheckbox false");
        }

        [When(@"Get all value of ZT")]
        public void WhenGetAllValueOfZT()
        {
            ZTLoginCheckbox = VantageCommonHelper.GetToggleStatus(HPDZeroTouchLoginCheckBox());
            ZTLockCheckbox = VantageCommonHelper.GetToggleStatus(hsHPDPage.HPDZeroTouchLockCheckbox);
            OverrideCheckbox = VantageCommonHelper.GetToggleStatus(hsHPDPage.AutoScreenTimeoutCheckbox);
            FastButtonValue = VantageCommonHelper.GetToggleStatus(hsHPDPage.HPDAutoScreenLockTimerFast);
            MediumButtonValue = VantageCommonHelper.GetToggleStatus(hsHPDPage.HPDAutoScreenLockTimerMedium);
            SlowButtonValue = VantageCommonHelper.GetToggleStatus(hsHPDPage.HPDAutoScreenLockTimerSlow);
            ZTLoginSlider = HPDZeroTouchLoginADSASldierBar().GetAttribute("Value.Value");
            ZTLockSlider = HPDZeroTouchLockADSASldierBar().GetAttribute("Value.Value");
        }

        [When(@"Check all value of ZT")]
        public void WhenCheckAllValueOfZT()
        {
            Assert.IsNotNull(HPDZeroTouchLoginCheckBox(), "The HPDZeroTouchLoginLeCheckBox is not find");
            Assert.AreEqual(ZTLoginCheckbox, VantageCommonHelper.GetToggleStatus(HPDZeroTouchLoginCheckBox()), "The HPDZeroTouchLoginLeCheckBox is not true when reinstall vantageLe");
            Assert.IsNotNull(hsHPDPage.HPDZeroTouchLockCheckbox, "The HPDZeroTouchLockCheckbox is not find");
            Assert.AreEqual(ZTLockCheckbox, VantageCommonHelper.GetToggleStatus(hsHPDPage.HPDZeroTouchLockCheckbox), "The HPDZeroTouchLockCheckbox is not true when reinstall vantageLe");
            Assert.IsNotNull(hsHPDPage.AutoScreenTimeoutCheckbox, "The AutoScreenTimeoutCheckbox is not find");
            Assert.AreEqual(OverrideCheckbox, VantageCommonHelper.GetToggleStatus(hsHPDPage.AutoScreenTimeoutCheckbox), "The AutoScreenTimeoutCheckbox is not true when reinstall vantageLe");
            Assert.IsNotNull(hsHPDPage.HPDAutoScreenLockTimerFast, "The HPDAutoScreenLockTimerFast is not find");
            Assert.AreEqual(FastButtonValue, VantageCommonHelper.GetToggleStatus(hsHPDPage.HPDAutoScreenLockTimerFast), "The HPDAutoScreenLockTimerFast is not true when reinstall vantageLe");
            Assert.IsNotNull(hsHPDPage.HPDAutoScreenLockTimerMedium, "The HPDAutoScreenLockTimerMedium is not find");
            Assert.AreEqual(MediumButtonValue, VantageCommonHelper.GetToggleStatus(hsHPDPage.HPDAutoScreenLockTimerMedium), "The HPDAutoScreenLockTimerMedium is not true when reinstall vantageLe");
            Assert.IsNotNull(hsHPDPage.HPDAutoScreenLockTimerSlow, "The HPDAutoScreenLockTimerSlow is not find");
            Assert.AreEqual(SlowButtonValue, VantageCommonHelper.GetToggleStatus(hsHPDPage.HPDAutoScreenLockTimerSlow), "The HPDAutoScreenLockTimerSlow is not true when reinstall vantageLe");
            Assert.IsNotNull(HPDZeroTouchLoginADSASldierBar(), "The HPDZeroTouchLoginADSA SldierBar is not find");
            Assert.AreEqual(ZTLoginSlider, HPDZeroTouchLoginADSASldierBar().GetAttribute("Value.Value"), "The HPDZeroTouchLoginADSA SldierBar is not true when reinstall vantageLe");
            Assert.IsNotNull(HPDZeroTouchLockADSASldierBar(), "The HPDZeroTouchLockADSASldierBar is not find");
            Assert.AreEqual(ZTLockSlider, HPDZeroTouchLockADSASldierBar().GetAttribute("Value.Value"), "The HPDZeroTouchLockADSASldierBar is not true when reinstall vantageLe");
        }

        [Given(@"Scoll to HPD ""(.*)""")]
        public void GivenScollTo(string p0)
        {
            if (p0 == "ZTLock")
            {
                ScrollScreenToWindowsElement(webDriver.Session, hsHPDPage.HPDAutoScreenLockTimerFast, -40);
            }
            if (p0 == "ZTLockcheckbox")
            {
                ScrollScreenToWindowsElement(webDriver.Session, hsHPDPage.HPDZeroTouchLockCheckbox, 40);
            }
            if (p0 == "ResectButton")
            {
                ScrollScreenToWindowsElement(webDriver.Session, hsHPDPage.HPDResetButton, -40);
            }
        }

        [Then(@"Check Zero Touch Lock text")]
        public void ThenCheckZeroTouchLockText()
        {
            Assert.IsNotNull(hsHPDPage.ThinkPadSensitivityTitle, "The ThinkPadSensitivityTitle is not find");
            Assert.AreEqual("SENSITIVITY ADJUSTING", hsHPDPage.ThinkPadSensitivityTitle.GetAttribute("Name"), "The ThinkPadSensitivityTitle text is not true");
            Assert.IsNotNull(hsHPDPage.MinLegendThinkpadSensitivity, "The MinLegendThinkpadSensitivity is not find");
            Assert.AreEqual("Near", hsHPDPage.MinLegendThinkpadSensitivity.GetAttribute("Name"), "The MinLegendThinkpadSensitivity text is not true");
            Assert.IsNotNull(hsHPDPage.MidLegendThinkpadSensitivity, "The MidLegendThinkpadSensitivity is not find");
            Assert.AreEqual("Middle", hsHPDPage.MidLegendThinkpadSensitivity.GetAttribute("Name"), "The MidLegendThinkpadSensitivity text is not true");
            Assert.IsNotNull(hsHPDPage.MaxLegendThinkpadSensitivity, "The MaxLegendThinkpadSensitivity is not find");
            Assert.AreEqual("Far", hsHPDPage.MaxLegendThinkpadSensitivity.GetAttribute("Name"), "The MaxLegendThinkpadSensitivity text is not true");
            Assert.IsNotNull(hsHPDPage.SensitivityAdjustingSliderBarNote, "The SensitivityAdjustingSliderBarNote is not find");
            Assert.AreEqual(GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.SensitivityAdjustingSliderBarNoteText"), hsHPDPage.SensitivityAdjustingSliderBarNote.GetAttribute("Name"), "The SensitivityAdjustingSliderBarNote text is not true");
        }

        [Then(@"Get ZTLock slider Value")]
        public void ThenGetZTLockSliderValue()
        {
            Assert.IsNotNull(HPDZeroTouchLockADSASldierBar(), "The HPDZeroTouchLockADSASldierBar is not find");
            ZTLockSlider = HPDZeroTouchLockADSASldierBar().GetAttribute("Value.Value");
        }

        [Then(@"The ZTLock slider Value not change")]
        public void ThenTheZTLockSliderValueNotChange()
        {
            Assert.IsNotNull(HPDZeroTouchLockADSASldierBar(), "The HPDZeroTouchLockADSASldierBar is not find");
            Assert.AreEqual(ZTLockSlider, HPDZeroTouchLockADSASldierBar().GetAttribute("Value.Value"), "The HPDZeroTouchLockADSASldierBar is not true when reinstall vantageLe");
        }

        [Then(@"The ZTLock slider Value is default")]
        public void ThenTheZTLockSliderValueIsDefault()
        {
            Assert.IsNotNull(HPDZeroTouchLockADSASldierBar(), "The HPDZeroTouchLockADSASldierBar is not find");
            Assert.AreEqual("Middle", HPDZeroTouchLockADSASldierBar().GetAttribute("Value.Value"), "The HPDZeroTouchLockADSASldierBar is not true when reinstall vantageLe");
        }

        [Then(@"Smart Assist page not show")]
        public void ThenSmartAssistPageNotShow()
        {
            SettingsBase setBase = new SettingsBase(webDriver.Session);
            setBase.MySettingsMenuDropClickFunction();
            Assert.IsNull(setBase.SmartAssistPageLinkDown, "The smartassistlink is find");
            Assert.IsNull(setBase.SmartAssistPageLinkLeft, "The smartassistlink is find");
        }

        [Given(@"Check computer not have hello face")]
        public void GivenCheckComputerNotHaveHelloFace()
        {
            HSHPDPage.CheckNoHelloFace();
        }

        public WindowsElement HPDZeroTouchLoginADSASldierBar()
        {
            WindowsElement tempSlider;
            if (VantageCommonHelper.IsThinkPad())
            {
                tempSlider = hsHPDPage.HPDZeroTouchLoginADSASldierBarThink;
            }
            else
            {
                tempSlider = hsHPDPage.HPDZeroTouchLoginADSASldierBar;
            }
            return tempSlider;
        }

        public WindowsElement HPDZeroTouchLockADSASldierBar()
        {
            WindowsElement tempSlider;
            if (VantageCommonHelper.IsThinkPad())
            {
                tempSlider = hsHPDPage.HPDZeroTouchLockADSASldierBarThink;
            }
            else
            {
                tempSlider = hsHPDPage.HPDZeroTouchLockADSASldierBar;
            }
            return tempSlider;
        }

        public WindowsElement HPDZeroTouchLoginCheckBox()
        {
            WindowsElement tempSlider;
            if (VantageCommonHelper.IsThinkPad())
            {
                tempSlider = hsHPDPage.HPDZeroTouchLoginCheckBoxThink;
            }
            else
            {
                tempSlider = hsHPDPage.HPDZeroTouchLoginCheckBox;
            }
            return tempSlider;
        }
    }
}
