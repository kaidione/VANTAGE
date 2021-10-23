using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.IO;
using System.Threading;
using System.Windows.Automation;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;

namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public class VantageHardwareSettingsConservationModeSteps : SettingsBase
    {
        private HSPowerSettingsPage _hsPowerSettingsPage;
        private HSAudioSettingsPage _audioSettingsPage;
        private HSToolbarPage _toolBarPage;
        private InformationalWebDriver _webDriver;
        private const string _projectName = "HardwareSettings";
        private const string _isSupportConservation = "Yoga C940-15IRH,Yoga S740-14IIL, IDEAPAD, Yoga S730-13IWL, ThinkBook Plus, Yoga Slim 9 14 ITL 05 , 300w Gen 3 ,Yoga Slim 7 14ARE05";
        private const string _isSupportRapidCharge = "Yoga 920-131KB,Yoga S740-14IIL";//, IDEAPAD
        private string _conservationType = string.Empty;
        private int waitTime = 120;
        private ToggleState _conservationStatus = ToggleState.Indeterminate;
        private string ChargeInvokerpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Tools\\ChargeInvoker\\ChargeInvoker.exe ");

        public VantageHardwareSettingsConservationModeSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Thinkpad machine")]
        public void GivenThinkpadMachine()
        {
            string machineType = VantageCommonHelper.GetCurrentMachineType();
            if (!machineType.ToLower().Contains("thinkpad"))
            {
                throw new Exception("Not is thinkpad machine");
            }
        }

        [Given(@"Machine not support the conservation mode")]
        public void GivenMachineNotSupportTheConservationMode()
        {
            var currentMachineSku = VantageCommonHelper.GetMachineSku();
            string machineType = VantageCommonHelper.GetCurrentMachineType();
            if (machineType.ToLower().Contains("thinkbook"))
            {
                currentMachineSku = "idea";
            }
            if (!currentMachineSku.ToLower().Contains("idea"))
            {
                throw new Exception("The computer is not idea.");
            }
            if (_isSupportConservation.ToLower().Contains(machineType.ToLower()))
            {
                throw new Exception("The computer support conservation mode.");
            }
        }

        [Given(@"Machine support the conservation mode")]
        public void GivenMachineSupportTheConservationMode()
        {
            string machineType = VantageCommonHelper.GetCurrentMachineType();
            if (!_isSupportConservation.ToLower().Contains(machineType.ToLower()))
            {
                Assert.Fail("Does't support conservation mode.");
            }
        }

        [Given(@"Machine support the rapid charge mode")]
        public void GivenMachineSupportTheRapidChargeMode()
        {
            string machineType = VantageCommonHelper.GetCurrentMachineType();
            if (_isSupportRapidCharge.ToLower().Contains(machineType.ToLower()))
            {
                Assert.Fail("Does't support rapid mode.");
            }
        }

        [When(@"Enter power page")]
        public void WhenEnterPowerPage()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            bool result = _hsPowerSettingsPage.GotoPowerPage();
            Assert.NotNull(result, "Not go to PowerPage");
        }

        [When(@"Turn on conservation mode")]
        public void WhenTurnOnConservationMode()
        {
            bool isInsert = VantageCommonHelper.JudgeInsertStatusIsOn();
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsPowerSettingsPage.ConservationModeCheckbox);
            bool result = VantageCommonHelper.SwitchToggleStatus(_hsPowerSettingsPage.ConservationModeCheckbox, ToggleState.On);
            Assert.IsTrue(result);
        }

        [When(@"Turn off conservation mode")]
        public void WhenTurnOffConservationMode()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsPowerSettingsPage.ConservationModeCheckbox);
            bool result = VantageCommonHelper.SwitchToggleStatus(_hsPowerSettingsPage.ConservationModeCheckbox, ToggleState.Off);
            Assert.IsTrue(result);
        }

        [When(@"Turn on rapid charge toggle")]
        public void WhenTurnOnRapidChargeToggle()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsPowerSettingsPage.RapidChargeModeCheckbox);
            bool result = VantageCommonHelper.SwitchToggleStatus(_hsPowerSettingsPage.RapidChargeModeCheckbox, ToggleState.On);
            Assert.IsTrue(result);
        }

        [When(@"Get conservation mode toggle status")]
        public void WhenGetConservationModeToggleStatus()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsPowerSettingsPage.ConservationModeCheckbox);
            _conservationStatus = VantageCommonHelper.GetToggleStatus(_hsPowerSettingsPage.ConservationModeCheckbox);
        }

        [Then(@"The feature is not supported")]
        public void ThenTheFeatureIsNotSupported()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNull(_hsPowerSettingsPage.ConservationModeTitle, "The ConservationModeTitle is find");
            Assert.IsNull(_hsPowerSettingsPage.ConservationModeCheckbox, "The ConservationModeCheckbox is find");
        }

        [Then(@"Feature is shows")]
        public void ThenFeatureIsShows()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsPowerSettingsPage.ConservationModeTitle, "The ConservationModeTitle is not find");
            Assert.IsNotNull(_hsPowerSettingsPage.ConservationModeCheckbox, "The ConservationModeCheckbox is not find");
        }

        [Then(@"The toggle default status is off")]
        public void ThenTheToggleDefaultStatusIsOff()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsPowerSettingsPage.ConservationModeCheckbox), ToggleState.Off, "The Conservation mode default state is not off");
        }

        [Then(@"There is a leaf beside vantage toolbar")]
        public void ThenThereIsALeafBesideVantageToolbar()
        {
            bool conservationIcon = VantageCommonHelper.ClickWithPosition(_projectName, "ConservationIcon", "ConservationIcon");
            Assert.IsTrue(conservationIcon);
        }

        [Then(@"The leaf beside vantage toolbar will disappear")]
        public void ThenTheLeafBesideVantageToolbarWillDisappear()
        {
            bool conservationIcon = VantageCommonHelper.ClickWithPosition(_projectName, "ConservationIcon", "ConservationIcon1");
            Assert.IsFalse(conservationIcon);
        }

        [Then(@"The conservation mode toggle is off and the icon beside vantage toolbar is lightning")]
        public void ThenTheConservationModeToggleIsOffAndTheIconBesideVantageToolbarIsLightning()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsPowerSettingsPage.ConservationModeCheckbox), ToggleState.Off);
        }

        [Then(@"The conservation mode toggle is on and the icon beside vantage toolbar is leaf")]
        public void ThenTheConservationModeToggleIsOnAndTheIconBesideVantageToolbarIsLeaf()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsPowerSettingsPage.ConservationModeCheckbox), ToggleState.On);
        }

        [Then(@"The toggle status should not change")]
        public void ThenTheToggleStatusShouldNotChange()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsPowerSettingsPage.ConservationModeCheckbox);
            Assert.AreEqual(_conservationStatus, VantageCommonHelper.GetToggleStatus(_hsPowerSettingsPage.ConservationModeCheckbox));
        }

        [When(@"Minimize vantage conservation mode")]
        public void WhenMinimizeVantageConservationMode()
        {
            _audioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            _audioSettingsPage.VantageMinizeElement.Click();
            Thread.Sleep(3000);
            _webDriver.Session.Manage()?.Window?.Maximize();
            Thread.Sleep(3000);
        }

        [When(@"Switch vantage conservation mode")]
        public void WhenSwitchVantageConservationMode()
        {
            DashBoardPage dashBoardPage = new DashBoardPage(_webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.securityTab.Click();
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        }

        [When(@"Relaungh vantage conservation mode")]
        public void WhenRelaunghVantageConservationMode()
        {
            Common.KillProcess(VantageConstContent.VantageProcessName, true);
            var factory = new BaseTestClass();
            var appInstance = factory.LaunchWinApplication(VantageConstContent.VantageUwpAppid);
            _webDriver = appInstance;
            VantageCommonHelper.CloseAlertWindow(_webDriver.Session);
        }

        [When(@"Resize vantage conservation mode")]
        public void WhenResizeVantageConservationMode()
        {
            _webDriver.Session.Manage().Window.Size = new System.Drawing.Size(500, 500);
        }

        [Given(@"Battery Level is below (.*)%")]
        public void GivenBatteryLevelIsBelow(int p0)
        {
            VantageCommonHelper.LessThanPowerValueByAppium(p0 - 2);
        }

        [Then(@"Battery will be charged and the final battery percentage is (.*)% or (.*)%""\.")]
        public void ThenBatteryWillBeChargedAndTheFinalBatteryPercentageIsOr_(int p0, int p1)
        {
            int beginPercent = VantageCommonHelper.GetCurrentBatteryPercent();
            int currentPercent = _hsPowerSettingsPage.GetTimerOutBatteryPercent(waitTime);
            Assert.Less(beginPercent, currentPercent, "The Battery is not charge !");
            if (_conservationType == "55-60%")
            {
                VantageCommonHelper.MoreThanPowerValueByAppium(p0);
                currentPercent = _hsPowerSettingsPage.GetTimerOutBatteryPercent(waitTime);
                Assert.AreEqual(currentPercent, p0, "The Buttery is charge ! Then the battery level is more than 60%");
            }
            else if (_conservationType == "75-80%")
            {
                VantageCommonHelper.MoreThanPowerValueByAppium(p1);
                currentPercent = _hsPowerSettingsPage.GetTimerOutBatteryPercent(waitTime);
                Assert.AreEqual(currentPercent, p1, "The Buttery is charge ! Then the battery level is more than 80%");
            }
            HSPowerSettingsPage.FindElementByIdAndMouseMove(Convert.ToInt32(ToolBarAutoEnum.ToolBar).ToString());
        }

        [Given(@"Battery level is in (.*)% or (.*)%")]
        public void GivenBatteryLevelIsInOr(string p0, string p1)
        {
            int currentPercent = VantageCommonHelper.GetCurrentBatteryPercent();
            int headLevel = 55;
            int endLevel = 60;
            if (_conservationType == "75-80%")
            {
                headLevel = 75;
                endLevel = 80;
            }
            if (currentPercent <= headLevel)
            {
                VantageCommonHelper.MoreThanPowerValueByAppium(headLevel + 1);
            }
            else if (currentPercent >= endLevel)
            {
                VantageCommonHelper.LessThanPowerValueByAppium(endLevel - 3);
            }
        }

        [Then(@"Battery level will keep in (.*)% or (.*)%")]
        public void ThenBatteryLevelWillKeepInOr(string p0, string p1)
        {
            Thread.Sleep(5000);
            int beginPercent = VantageCommonHelper.GetCurrentBatteryPercent();
            int currentPercent = _hsPowerSettingsPage.GetTimerOutBatteryPercent(waitTime);
            if (beginPercent != currentPercent)
            {
                _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
                Assert.NotNull(_hsPowerSettingsPage.ConservationModeCheckbox);
                bool result = VantageCommonHelper.SwitchToggleStatus(_hsPowerSettingsPage.ConservationModeCheckbox, ToggleState.Off);
                Assert.IsTrue(result);
                throw new Exception("The Battery is charge ! beginPercent is" + Convert.ToString(beginPercent) + "currentPercent is" + Convert.ToString(currentPercent));
            }
            HSPowerSettingsPage.FindElementByIdAndMouseMove(Convert.ToInt32(ToolBarAutoEnum.ToolBar).ToString());
        }

        [Given(@"Battery level is upon (.*)%")]
        public void GivenBatteryLevelIsUpon(int p0)
        {
            VantageCommonHelper.MoreThanPowerValueByAppium(p0);
        }

        [Given(@"Battery in ConversionMode is upon than (.*)% or (.*)%")]
        public void GivenBatteryInConversionModeIsUponThanOr(int p0, int p1)
        {
            if (_conservationType == "55-60%")
            {
                VantageCommonHelper.MoreThanPowerValueByAppium(p0);
            }
            else if (_conservationType == "75-80%")
            {
                VantageCommonHelper.MoreThanPowerValueByAppium(p1);
            }
        }

        [Then(@"Battery level will not change and battery status is ""(.*)""")]
        public void ThenBatteryLevelWillNotChangeAndBatteryStatusIs(string p0)
        {
            int beginPercent = VantageCommonHelper.GetCurrentBatteryPercent();
            int currentPercent = _hsPowerSettingsPage.GetTimerOutBatteryPercent(waitTime);
            if (!(beginPercent == currentPercent || currentPercent == 80))
            {
                Assert.Fail("The Battery is charging ! The Battery level should be " + beginPercent + "But now is " + currentPercent);
            }
            HSPowerSettingsPage.FindElementByIdAndMouseMove(Convert.ToInt32(ToolBarAutoEnum.ToolBar).ToString());
        }

        [Given(@"Conservation mode is on")]
        public void GivenConservationModeIsOn()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsPowerSettingsPage.ConservationModeCheckbox);
            bool result = VantageCommonHelper.SwitchToggleStatus(_hsPowerSettingsPage.ConservationModeCheckbox, ToggleState.On);
            Assert.IsTrue(result);
        }

        [Then(@"The battery will continue to charge")]
        public void ThenTheBatteryWillContinueToCharge()
        {
            int beginPercent = VantageCommonHelper.GetCurrentBatteryPercent();
            int currentPercent = _hsPowerSettingsPage.GetTimerOutBatteryPercent(waitTime);
            Assert.Less(beginPercent, currentPercent, "The Battery is not charge !");
            HSPowerSettingsPage.FindElementByIdAndMouseMove(Convert.ToInt32(ToolBarAutoEnum.ToolBar).ToString());
        }

        [Then(@"Recover conservation mode toggle")]
        public void ThenTurnOffConservationMode()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsPowerSettingsPage.ConservationModeCheckbox);
            bool result = VantageCommonHelper.SwitchToggleStatus(_hsPowerSettingsPage.ConservationModeCheckbox, ToggleState.Off);
            Assert.IsTrue(result);
        }

        [Then(@"Turn off rapid charge toggle")]
        public void ThenTurnOffRapidChargeToggle()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsPowerSettingsPage.ConservationModeCheckbox);
            bool result = VantageCommonHelper.SwitchToggleStatus(_hsPowerSettingsPage.RapidChargeModeCheckbox, ToggleState.Off);
            Assert.IsTrue(result);
        }

        [Given(@"Get ConservationMode Type")]
        public void GivenGetConservationModeType()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _conservationType = _hsPowerSettingsPage.GetConservationValue();
            Assert.IsNotNull(_conservationType, "Get ConservationValue failed");
        }

        [Then(@"Check charging threshold description")]
        public void ThenCheckChargingThresholdDescription()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            string beginText = GetAutomationIdFromPredefinedJsonFile("$.PowerPage.ConservationModeBeginDescription");
            string endText = GetAutomationIdFromPredefinedJsonFile("$.PowerPage.ConservationModeEndDescription");
            string description = beginText + _conservationType + endText;
            Assert.AreEqual(description, _hsPowerSettingsPage.ConservationModeCaptionId.Text, "The description is not true");
        }

        [Given(@"Battery in ConversionMode is below than (.*)% or (.*)%")]
        public void GivenBatteryInConversionModeIsBelowThanOr(int p0, int p1)
        {
            if (_conservationType == "55-60%")
            {
                VantageCommonHelper.LessThanPowerValueByAppium(p0 - 2);
            }
            else if (_conservationType == "75-80%")
            {
                VantageCommonHelper.LessThanPowerValueByAppium(p1 - 2);
            }
        }

        [Given(@"Use ""(.*)"" and Button ""(.*)"" make BatteryLevel ""(.*)"" than ""(.*)""")]
        public void GivenUseAndButtonMakeBatteryLevelThan(string acdcIp, int btnIp, string actionType, int targetLevel)
        {
            if (actionType == "more")
            {
                VantageCommonHelper.MoreThanPowerValueByPLC(targetLevel + 1);
            }
            else if (actionType == "less")
            {
                VantageCommonHelper.LessThanPowerValueByPLC(targetLevel - 1);
            }
            else if (actionType == "same")
            {
                int currentPercent = VantageCommonHelper.GetCurrentBatteryPercent();
                if (currentPercent > targetLevel)
                {
                    VantageCommonHelper.LessThanPowerValueByPLC(targetLevel);
                }
                else if (currentPercent < targetLevel)
                {
                    VantageCommonHelper.MoreThanPowerValueByPLC(targetLevel);
                }
            }
        }

        [Then(@"Conservation mode toggle display hide")]
        public void ThenConservationModeToggleDisplayHide()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNull(_hsPowerSettingsPage.ConservationModeCheckbox, "The ConservationModeCheckbox is find");
        }

        [Then(@"There only show the title description note of Conservation mode feature")]
        public void ThenThereOnlyShowTheTitleDescriptionNoteOfConservationModeFeature()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsPowerSettingsPage.ConservationModeTitle, "The ConservationModeTitle is not find");
            Assert.IsNotNull(_hsPowerSettingsPage.ConservationModeCaptionId, "The ConservationModeTitle is not find");
            Assert.IsNotNull(_hsPowerSettingsPage.ConservationModeNoteId, "The ConservationModeNoteId is not find");
        }

        [Then(@"The description displays text")]
        public void ThenTheDescriptionDisplaysText()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.AreEqual(_hsPowerSettingsPage.ConservationModeCaptionText, _hsPowerSettingsPage.ConservationModeCaptionId.Text, "The description is not true");
        }

        [Then(@"The Note description displays text")]
        public void ThenTheNoteDescriptionDisplaysText()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.AreEqual(_hsPowerSettingsPage.ConservationModeNoteCaptionText, _hsPowerSettingsPage.ConservationModeNoteId.Text, "The Note description is not true");
        }

        [Given(@"Using ChargeInvoker.exe to Reset EC ""(.*)"" states")]
        public void GivenUsingExeToBootStates(string type)
        {
            //normal->均为关，quick->rapid charge开，conservation mode关 (storage->conservation mode开，rapid charge关)此种default值目前没有， 默认为ALL
            //All -> normal      Conservation -> quick   Rapid -> storage
            string states = "normal";
            if (type != "All")
            {
                states = type == "Conservation" ? "quick" : "storage";
            }
            //通过Cmd 调用ChargeInvoker.exe 传入参数
            RunCmd(ChargeInvokerpath + states);
            SettingMicrophoneToggleSteps sleep = new SettingMicrophoneToggleSteps(_webDriver);
            sleep.WhenEnterHibernate();
        }

        [Then(@"The ""(.*)"" toggle is ""(.*)""")]
        public void ThenTheToggleIs(string type, string toggleStates)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            WindowsElement toggle = type == "Conservation" ? _hsPowerSettingsPage.ConservationModeCheckbox : _hsPowerSettingsPage.RapidChargeModeCheckbox;
            Assert.NotNull(toggle, "The " + type + "Toggle is not find");
            if (toggleStates == "on")
            {
                Assert.AreEqual(ToggleState.On, VantageCommonHelper.GetToggleStatus(toggle), "The " + type + "Toggle is not on");
            }
            else
            {
                Assert.AreEqual(ToggleState.Off, VantageCommonHelper.GetToggleStatus(toggle), "The " + type + "Toggle is not off");
            }
        }

        [Then(@"The feature is in Battery settings section")]
        public void ThenTheFeatureIsInBatterySettingsSection()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            int batterysetting = _hsPowerSettingsPage.JumpToBatterySettings != null ? _hsPowerSettingsPage.JumpToBatterySettings.Location.Y : 0;
            int conservationmodetitle = _hsPowerSettingsPage.ConservationModeTitle != null ? _hsPowerSettingsPage.ConservationModeTitle.Location.Y : 0;
            if (batterysetting != 0 && conservationmodetitle != 0 && conservationmodetitle > batterysetting)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.Fail("WhenCheckHPDStaticImageExist Fail: HPD image location is wrong");
        }
    }
}
