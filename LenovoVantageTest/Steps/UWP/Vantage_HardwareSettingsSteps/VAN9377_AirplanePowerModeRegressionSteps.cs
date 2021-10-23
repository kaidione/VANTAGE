using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Windows.Automation;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;

namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public sealed class VantageHardwareSettingsAirPlanePowerModelSteps
    {
        private static HSPowerSettingsPage _hsPowerSettingsPage;
        private static InformationalWebDriver _webDriver;
        private const string _isSupportConservation = "ThinkPad X390 Yoga";
        public VantageHardwareSettingsAirPlanePowerModelSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [AfterFeature("AirplaneModelIcon")]
        public static void AfterFeature()
        {
            VantageUI.instance.LaunchVantageWithProtocol();
            VantageCommonHelper.CloseAlertWindow(_webDriver.Session);
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _hsPowerSettingsPage.GoToMyDevicesSettings();
            WhenTurnOffAirplaneMode();
            string windowsName = VantageConstContent.VantageTypePlan != VantageConstContent.VantageType.LE ? "Lenovo Vantage" : "Commercial Vantage";
            IntPtr intPtr = UnManagedAPI.FindWindow("ApplicationFrameWindow", windowsName);
            UnManagedAPI.SendMessage(intPtr, UnManagedAPI.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }

        [Given(@"The machine support Airplane Power Mode feature")]
        public void GivenTheMachineSupportAirplanePowerModeFeature()
        {
            string machineType = VantageCommonHelper.GetCurrentMachineType();
            if (!_isSupportConservation.ToLower().Contains(machineType.ToLower()))
            {
                throw new Exception("Does't support airplan mode.");
            }
        }

        [Given(@"Go to Devices Settings")]
        public void GivenGoToDevicesSettings()
        {
            bool status = false;
            try
            {
                _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
                _hsPowerSettingsPage.GoToMyDevicesSettings();
            }
            catch (Exception ex)
            {
                Console.WriteLine("GivenGoToDevicesSettings() Try again,Info:" + ex.Message);
                status = true;
            }
            if (status)
            {
                _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
                _hsPowerSettingsPage.GoToMyDevicesSettings();
            }
        }

        [Then(@"Receive response,the Airplane Power Mode can be shown in Power page")]
        public void ThenReceiveResponseTheAirplanePowerModeCanBeShownInPowerPage()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsPowerSettingsPage.AirplaneModeTitleId, "The AirplaneModeTitle is not find");
            Assert.IsNotNull(_hsPowerSettingsPage.AirplaneModeCheckboxId, "The AirplaneModeCheckbox is not find");
        }

        [When(@"Turn on Airplane Mode")]
        public void WhenTurnOnAirplaneMode()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsPowerSettingsPage.AirplaneModeCheckboxId);
            bool result = VantageCommonHelper.SwitchToggleStatus(_hsPowerSettingsPage.AirplaneModeCheckboxId, ToggleState.On);
            Assert.IsTrue(result, "The Airplane model is not on");
        }

        [When(@"Turn off Airplane Mode")]
        public static void WhenTurnOffAirplaneMode()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsPowerSettingsPage.AirplaneModeCheckboxId);
            bool result = VantageCommonHelper.SwitchToggleStatus(_hsPowerSettingsPage.AirplaneModeCheckboxId, ToggleState.Off);
            Assert.IsTrue(result, "The Airplane model is not off");
        }

        [Given(@"Uncheck the checkbox beside Enable auto-detection")]
        public void GivenUncheckTheCheckboxBesideEnableAuto_Detection()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsPowerSettingsPage.AutoAirplaneModeCheckboxId, "The AutoAirplanemodelCheckbox is not find");
            bool result = VantageCommonHelper.SwitchToggleStatus(_hsPowerSettingsPage.AutoAirplaneModeCheckboxId, ToggleState.Off);
            Assert.IsTrue(result, "The Auto Airplane model is not off");
        }

        [When(@"ACDC (.*) Times ""(.*)"" and button is ""(.*)""")]
        public void WhenACDCTimesAndButtonIs(int p0, string p1, int p2)
        {
            MultipleClientsSpecFlowFeatureSteps acdcClass = new MultipleClientsSpecFlowFeatureSteps();
            for (int frequency = p0; frequency > 0; frequency--)
            {
                VantageCommonHelper.AdapterNotInsert();
                VantageCommonHelper.AdapterNotInsert();
                //VantageCommonHelper.AdapterNotInsert();
                AutomationElement IsAirplaneNoticYesBtn = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, Convert.ToInt32(ToolBarAutoEnum.AirplaneNoticYesBtn).ToString()), new PropertyCondition(AutomationElement.IsEnabledProperty, true)));
                if (IsAirplaneNoticYesBtn != null)
                {
                    break;
                }
            }
            if (!VantageCommonHelper.JudgeInsertStatusIsOn())
            {

                VantageCommonHelper.AdapterNotInsert();
            }
        }

        [Then(@"In Power page Enable Airplane Power Mode will not automatically turn on")]
        public void ThenInPowerPageEnableAirplanePowerModeWillNotAutomaticallyTurnOn()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            ToggleState result = VantageCommonHelper.GetToggleStatus(_hsPowerSettingsPage.AirplaneModeCheckboxId);
            Assert.AreEqual(result, ToggleState.Off, "The Airplane model is not off pleasecheckit");
        }

        [Then(@"In Power page Enable Airplane Power Mode will automatically turn on")]
        public void ThenInPowerPageEnableAirplanePowerModeWillAutomaticallyTurnOn()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            ToggleState result = VantageCommonHelper.GetToggleStatus(_hsPowerSettingsPage.AirplaneModeCheckboxId);
            Assert.AreEqual(result, ToggleState.On, "The Airplane model is not on pleasecheckit");
        }

        [Given(@"Select the checkbox beside Enable auto-detection")]
        public void GivenSelectTheCheckboxBesideEnableAuto_Detection()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsPowerSettingsPage.AutoAirplaneModeCheckboxId, "The AutoAirplanemodelCheckbox is not find");
            bool result = VantageCommonHelper.SwitchToggleStatus(_hsPowerSettingsPage.AutoAirplaneModeCheckboxId, ToggleState.On);
            Assert.IsTrue(result, "The Auto Airplane model is not off");
        }

        [Then(@"A prompt message will appear")]
        public void ThenAPromptMessageWillAppear()
        {
            AutomationElement IsAirplaneNoticYesBtn = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, Convert.ToInt32(ToolBarAutoEnum.AirplaneNoticYesBtn).ToString()), new PropertyCondition(AutomationElement.IsEnabledProperty, true)));
            AutomationElement IsAirplaneNoticNoBtn = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, Convert.ToInt32(ToolBarAutoEnum.AirplaneNoticNoBtn).ToString()), new PropertyCondition(AutomationElement.IsEnabledProperty, true)));
            Assert.NotNull(IsAirplaneNoticYesBtn, "The notice is not find");
            Assert.NotNull(IsAirplaneNoticNoBtn, "The notice is not find");
        }

        [Then(@"No prompt message")]
        public void ThenNoPromptMessage()
        {
            AutomationElement IsAirplaneNoticYesBtn = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, Convert.ToInt32(ToolBarAutoEnum.AirplaneNoticYesBtn).ToString()), new PropertyCondition(AutomationElement.IsEnabledProperty, true)));
            AutomationElement IsAirplaneNoticNoBtn = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, Convert.ToInt32(ToolBarAutoEnum.AirplaneNoticNoBtn).ToString()), new PropertyCondition(AutomationElement.IsEnabledProperty, true)));
            Assert.IsNull(IsAirplaneNoticYesBtn, "The notice is  find");
            Assert.IsNull(IsAirplaneNoticNoBtn, "The notice is  find");
        }

        [Then(@"Click the Yesbutton")]
        public void ThenClickTheYesbutton()
        {
            AutomationElement IsAirplaneNoticYesBtn = VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.AirplaneNoticYesBtn).ToString());
        }

        [Then(@"The checkbox should restore to un-checked")]
        public void ThenTheCheckboxShouldRestoreToUn_Checked()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            ToggleState result = VantageCommonHelper.GetToggleStatus(_hsPowerSettingsPage.AutoAirplaneModeCheckboxId);
            Assert.AreEqual(result, ToggleState.On, "The Airplane model is not on pleasecheckit");
        }

        [Then(@"The Airplane Mode is on")]
        public void ThenTheAirplaneModeIsOn()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsPowerSettingsPage.AirplaneModeCheckboxId), ToggleState.On, "The CbEyeCareScheduleCheckBox default state in Ui is not on");
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsPowerSettingsPage.AutoAirplaneModeCheckboxId), ToggleState.On, "The AutoAirplaneModeCheckboxId  is not on pleasecheckit");
        }

        [Then(@"The Airplane Mode is off")]
        public void ThenTheAirplaneModeIsOff()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsPowerSettingsPage.AirplaneModeCheckboxId), ToggleState.Off, "The CbEyeCareScheduleCheckBox status incorreect");
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsPowerSettingsPage.AutoAirplaneModeCheckboxId), ToggleState.Off, "The AutoAirplaneModeCheckboxId  status incorrect");
        }

        [Then(@"The Airplane Mode Status is '(.*)' within Vantage")]
        public void ThenTheAirplaneModeStatusIsWithinVantage(string status)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            switch (status.ToLower())
            {
                case "on":
                    Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsPowerSettingsPage.AirplaneModeCheckboxId), ToggleState.On, "The AirplaneModeCheckboxId status is incorrect," + status);
                    break;
                case "off":
                    Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsPowerSettingsPage.AirplaneModeCheckboxId), ToggleState.Off, "The AirplaneModeCheckboxId status is incorrect," + status);
                    break;
                default:
                    Assert.Fail("The ThenTheAirplaneModeStatusIsWithinVantage() parameter is error,info:" + status);
                    break;
            }
        }

        [Then(@"The Airplane power mode status same as vantage")]
        public void ThenTheAirplanePowerModeStatusSameAsVantage()
        {
            ToggleState state = SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString());
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _hsPowerSettingsPage.GoToMyDevicesSettings();
            Assert.IsNotNull(_hsPowerSettingsPage.JumpToPowerSettings, "The JumpToPowerSettings link not found");
            _hsPowerSettingsPage.JumpToPowerSettings.Click();
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsPowerSettingsPage.AirplaneModeCheckboxId), state, "The Airplane power mode status not same as vantage");
        }

    }
}
