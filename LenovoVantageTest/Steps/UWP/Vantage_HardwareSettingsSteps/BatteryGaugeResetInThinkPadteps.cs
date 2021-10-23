using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class BatteryGaugeResetInThinkPadSteps : SettingsBase
    {

        private HSPowerSettingsPage _hSPowerSettingsPage;
        private InformationalWebDriver _webDriver;
        private bool _reconditionErrorFlag = false;
        private string _reconditionErrorNum = string.Empty;
        private int _startValue;
        private DateTime currentTime;

        public BatteryGaugeResetInThinkPadSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [AfterFeature("BatteryGaugeResetOneBatteryNeedRunonBJ19ACTDC")]
        public static void AfterFeature()
        {
            if (!VantageCommonHelper.JudgeInsertStatusIsOn())
            {
                VantageCommonHelper.AdapterNotInsert();
            }
        }

        [Given(@"The ThinkPad machine with Lenovo Power Manager driver")]
        public void GivenTheThinkPadMachineWithLenovoPowerManagerDriver()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsTrue(_hSPowerSettingsPage.FindProcessByName(_hSPowerSettingsPage.PowerMgrProcessName));
        }

        [Given(@"The driver is in good condition and the machine is in AC state")]
        public void GivenTheDriverIsInGoodConditionAndTheMachineIsInACState()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _hSPowerSettingsPage.GoToMyDevicesSettings();
            Assert.IsTrue(VantageCommonHelper.JudgeInsertStatusIsOn(), "Judge Insert Status Is Off");
            Assert.IsNull(_hSPowerSettingsPage.BatteryMissingDriverCondition, "Battery MissingDriver Condition is error");
        }

        [Given(@"Go to Power Page")]
        [When(@"Go to Power Page")]
        public void GivenGoToPowerPage()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _hSPowerSettingsPage.GoToMyDevicesSettings();
        }

        [Given(@"Go to Productivity Creator settings Page")]
        public void GivenGoToProductivityCreatorsettingspage()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _hSPowerSettingsPage.GotoProductivityCreatorsetting();
        }

        [Given(@"Click Jump to Battery Settings")]
        public void GivenLaunchVantageAndGoToPowerPage()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.JumpToBatterySettings);
            _hSPowerSettingsPage.JumpToBatterySettings();
        }

        [When(@"Check the Battery Settings section")]
        public void WhenCheckTheBatterySettingsSection()
        {
            Console.WriteLine("Do Check the Battery Settings section");
        }

        [When(@"Check the UI of Battery gauge reset feature")]
        public void WhenCheckTheUIOfBatteryGaugeResetFeature()
        {
            Console.WriteLine("Do Check the UI of Battery gauge reset feature");
        }

        [When(@"The machine with one battery")]
        public void WhenTheMachineWithOneBattery()
        {
            Assert.AreEqual(1, VantageCommonHelper.JudgeBatteryNums());
        }

        [When(@"Check the UI of Battery reset panel")]
        public void WhenCheckTheUIOfBatteryResetPanel()
        {
            Console.WriteLine("Do Check the UI of Battery reset panel");
        }

        [When(@"If there is has a ""(.*)"" value in ""(.*)"" where XX is the Battery Barcode")]
        public void WhenIfThereIsHasAValueInWhereXXIsTheBatteryBarcode(string regeditName, string regeditPath)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            string guidKey = _hSPowerSettingsPage.HSBatteryGuageResetBarcodeValue.Text;
            regeditPath += "\\" + guidKey;
            string regeditValue = IntelligentCoolingBaseHelper.GetLocalMachineRegeditValue(regeditName, regeditPath);
            if (!string.IsNullOrEmpty(regeditValue))
            {
                _reconditionErrorFlag = true;
                _reconditionErrorNum = regeditValue;
            }
        }

        [When(@"Click the ""(.*)"" Button")]
        public void WhenClickTheButton(string p0)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            switch (p0.ToLower())
            {
                case "reset":
                    Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetBtn);
                    _hSPowerSettingsPage.HSBatteryGuageResetBtn.Click();
                    WindowsElement ContinueBtn = _hSPowerSettingsPage.HSBatteryGuageResetPopupContinueBtn;
                    if (ContinueBtn == null)
                    {
                        _hSPowerSettingsPage.HSBatteryGuageResetBtn.Click();
                    }
                    break;
                case "cancel":
                    Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetPopupCancelBtn);
                    _hSPowerSettingsPage.HSBatteryGuageResetPopupCancelBtn.Click();
                    break;
                case "close":
                    Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetPopupCloseBtn);
                    _hSPowerSettingsPage.HSBatteryGuageResetPopupCloseBtn.Click();
                    break;
                case "yes":
                    Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetStopPopYesBtn);
                    _hSPowerSettingsPage.HSBatteryGuageResetStopPopYesBtn.Click();
                    currentTime = DateTime.Now;
                    break;
                case "stop":
                    Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetStopBtn);
                    _hSPowerSettingsPage.HSBatteryGuageResetStopBtn.Click();
                    break;
                case "continue":
                    Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetPopupContinueBtn);
                    _hSPowerSettingsPage.HSBatteryGuageResetPopupContinueBtn.Click();
                    break;
                case "see battery details":
                    Assert.IsNotNull(_hSPowerSettingsPage.HSBattrtyDetailsButton);
                    ScrollScreenToWindowsElement(_webDriver.Session, _hSPowerSettingsPage.HSBattrtyDetailsButton, 30, 15);
                    _hSPowerSettingsPage.HSBattrtyDetailsButton.Click();
                    break;
            }
        }

        [Given(@"Reset the Battery Gauge status to reset")]
        public void GivenResetTheBatteryGaugeStatus()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _hSPowerSettingsPage.BatteryGaugeWhenShowStopBtn();
        }

        [Then(@"There will be a Battery Gauge reset feature in this section and under Battery Charge threshold")]
        public void ThenThereWillBeABatteryGaugeResetFeatureInThisSectionAndUnderBatteryChargeThreshold()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryThresholdTitle);
            int batteryThresholdTitleLocation = _hSPowerSettingsPage.HSBatteryThresholdTitle.Location.Y;
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetTitle);
            int batteryGuageResetLocation = _hSPowerSettingsPage.HSBatteryGuageResetTitle.Location.Y;
            Assert.Less(batteryThresholdTitleLocation, batteryGuageResetLocation);
        }

        [Then(@"There will be a feature icon/title/description and should follow the UISPEC")]
        public void ThenThereWillBeAFeatureIconTitleDescriptionAndShouldFollowTheUISPEC()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetTitle);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetCaption);
        }

        [Then(@"There will be a feature ""(.*)"" and ""(.*)"" should follow the UISPEC")]
        public void ThenThereWillBeAFeatureAndShouldFollowTheUISPEC(string p0, string p1)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetTitle);
            Assert.AreEqual(p0, _hSPowerSettingsPage.HSBatteryGuageResetTitle.Text);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetCaption);
            Assert.AreEqual(p1, _hSPowerSettingsPage.HSBatteryGuageResetCaption.Text);
        }

        [Then(@"There will be only one battery reset panel")]
        public void ThenThereWillBeOnlyOneBatteryResetPanel()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetOneBatteryTitle);
            Assert.AreEqual("Battery", _hSPowerSettingsPage.HSBatteryGuageResetOneBatteryTitle.Text);
        }

        [Then(@"There will be a Battery Barcode number and a RESET button")]
        public void ThenThereWillBeABatteryBarcodeNumberAndAButton()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetBarcodeTitle);
            Assert.AreEqual("Barcode", _hSPowerSettingsPage.HSBatteryGuageResetBarcodeTitle.Text);
            string regeditValue = IntelligentCoolingBaseHelper.GetLocalMachineRegeditValue("Barcode Number", @"SOFTWARE\WOW6432Node\Lenovo\PWRMGRV\ConfKeys\Data\Battery1");
            Assert.AreEqual(regeditValue, _hSPowerSettingsPage.HSBatteryGuageResetBarcodeValue.Text);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetBtn);
            Assert.AreEqual("Reset", _hSPowerSettingsPage.HSBatteryGuageResetBtn.Text);
        }

        private string GetRecoditionStr(string num)
        {
            string recoditionStr = string.Empty;
            switch (num)
            {
                case "0":
                    recoditionStr = "Complete: Reset successfully";
                    break;
                case "1":
                    recoditionStr = "Faild: System shut down";
                    break;
                case "4":
                    recoditionStr = "Failed: Battery was replaced.";
                    break;
                case "6":
                    recoditionStr = "Failed: Cancelled by user";
                    break;
                case "5":
                    recoditionStr = "Failed: AC power adapter was detached.";
                    break;
                case "7":
                    recoditionStr = "Failed: Unexpected error occurred.";
                    break;
            }
            return recoditionStr;
        }

        [Then(@"The Last Reset item will be displayed in the Battery Gauge Reset panel")]
        public void ThenTheLastResetItemWillBeDisplayedInTheBatteryGaugeResetPanel()
        {
            //UISPEC check
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            if (_reconditionErrorFlag)
            {
                Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetlastResetTimeValue);
                Assert.AreEqual("Last reset", _hSPowerSettingsPage.HSBatteryGuageResetlastReset.Text);
                Assert.IsTrue(_hSPowerSettingsPage.HSBatteryGuageResetlastResetTimeValue.Text.Contains(GetRecoditionStr(_reconditionErrorNum)));
            }
            else
            {
                Assert.IsNull(_hSPowerSettingsPage.HSBatteryGuageResetlastResetTimeValue);
            }
        }

        [Then(@"There will popup a battery reset confirmation dialog \(About the reset step\) and should follow the UISPEC")]
        public void ThenThereWillPopupABatteryResetConfirmationDialogAboutTheResetStepAndShouldFollowTheUISPEC()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetPopupTitle);//"Battery gauge reset"
            Assert.AreEqual("Battery gauge reset", _hSPowerSettingsPage.HSBatteryGuageResetPopupTitle.Text);
            Assert.IsTrue(_hSPowerSettingsPage.HSBatteryGuageResetPopup_TitleDescription_1.Enabled);
            Assert.IsTrue(_hSPowerSettingsPage.HSBatteryGuageResetPopup_TitleDescription_2.Enabled);
            Assert.IsTrue(_hSPowerSettingsPage.HSBatteryGuageResetPopup_Note.Enabled);
            Assert.IsTrue(_hSPowerSettingsPage.HSBatteryGuageResetPopup_Note_Description1.Enabled);
            Assert.IsTrue(_hSPowerSettingsPage.HSBatteryGuageResetPopup_Note_Description2.Enabled);
            Assert.IsTrue(_hSPowerSettingsPage.HSBatteryGuageResetPopup_Note_Description3.Enabled);
            Assert.AreEqual("Cancel", _hSPowerSettingsPage.HSBatteryGuageResetPopupCancelBtn.GetAttribute("Name"));
            Assert.AreEqual("Continue", _hSPowerSettingsPage.HSBatteryGuageResetPopupContinueBtn.GetAttribute("Name"));
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetPopupCloseBtn);
        }

        [Then(@"The Battery Gauge Rest process will not be performed and return to the Power Page")]
        public void ThenTheBatteryGaugeRestProcessWillNotBePerformedAndReturnToThePowerPage()
        {

            Thread.Sleep(TimeSpan.FromSeconds(2));
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNull(_hSPowerSettingsPage.HSBatteryGuageResetPopupTitle);
            Assert.IsNull(_hSPowerSettingsPage.HSBatteryGuageResetPerformedProgress);
            Assert.IsNull(_hSPowerSettingsPage.HSBatteryGuageResetPerformedRemaining);
            Assert.IsNull(_hSPowerSettingsPage.HSBatteryGuageResetPerformedStartTime);
        }

        [Then(@"The Battery Gauge Rest process will be performed")]
        public void ThenTheBatteryGaugeRestProcessWillBePerformed()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetPerformedProgress);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetPerformedRemaining);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetPerformedStartTime);
        }

        [Then(@"The ""(.*)"" Button which we Clicked will change to ""(.*)"" button with red background color")]
        public void ThenTheButtonWhichWeClickedWillChangeToButtonWithRedBackgroundColor(string p0, string p1)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetStopBtn);
            Assert.AreEqual("Stop", _hSPowerSettingsPage.HSBatteryGuageResetStopBtn.Text);
        }

        [Then(@"If the machine with two batteries, the ""(.*)"" button which we didn't selected will be changed to grey-out and cannot be clicked")]
        public void ThenIfTheMachineWithTwoBatteriesTheButtonWhichWeDidnTSelectedWillBeChangedToGrey_OutAndCannotBeClicked(string p0)
        {
            Assert.AreEqual(2, VantageCommonHelper.JudgeBatteryNums());
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsFalse(_hSPowerSettingsPage.HSBatteryGuageResetSecondaryResetBtn.Enabled);
        }

        [Then(@"If the machine with two batteries, the ""(.*)"" button which we didn't selected will be resuem from grey-out and can be clicked")]
        public void ThenIfTheMachineWithTwoBatteriesTheButtonWhichWeDidnTSelectedWillBeResuemFromGrey_OutAndCanBeClicked(string p0)
        {
            Assert.AreEqual(2, VantageCommonHelper.JudgeBatteryNums());
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsTrue(_hSPowerSettingsPage.HSBatteryGuageResetSecondaryResetBtn.Enabled);
        }

        [Then(@"The Battery Reset Panel which we click will display a Barcode, Progress, Remaining and Start time item, all the value should be correct during the progress")]
        public void ThenTheBatteryResetPanelWhichWeClickWillDisplayABarcodeProgressRemainingAndStartTimeItemAllTheValueShouldBeCorrectDuringTheProgress()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetPerformedProgress);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetPerformedRemaining);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetPerformedStartTime);
        }

        [When(@"The Battery percentage is lower than (.*)%")]
        public void WhenTheBatteryPercentageIsLowerThan(int p0)
        {
            VantageCommonHelper.LessThanPowerValueByAppium(p0);
        }

        [When(@"Battery Charging threshold is off")]
        public void WhenBatteryChargingThresholdIsOff()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsTrue(_hSPowerSettingsPage.TurnOffBatteryChargeThreshold(), "Turn Off Battery Charge Threshold");
        }

        [Then(@"The tip will show ""(.*)""")]
        public void ThenTheTipWillShow(string p0)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryGaugeProgressStep1TextEle);
        }

        [Then(@"first, and then the Battery will be charging to (.*)%, The tip under 3.2.0.01 is ""(.*)""")]
        public void ThenFirstAndThenTheBatteryWillBeChargingToTheTipUnder_Is(int p0, string p1)
        {
            VantageCommonHelper.MoreThanPowerValue(p0);
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryGaugeProgressStep1TextEle);
        }

        [When(@"If the Battery percentage is lower than (.*)% when we click the Reset button")]
        public void WhenIfTheBatteryPercentageIsLowerThanWhenWeClickTheResetButton(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"After (.*) of (.*), the progress will display: ""(.*)"", and the battery will be discharging to (.*)% or lower than (.*)%")]
        public void ThenAfterOfTheProgressWillDisplayAndTheBatteryWillBeDischargingToOrLowerThan(int p0, int p1, string p2, int p3, int p4)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The tip will show ""(.*)""\tWhen Click the ""(.*)"" Button")]
        public void ThenTheTipWillShowWhenClickTheButton(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"After (.*) of (.*), the progress will display: ""(.*)"", and the Battery will be charging to  (.*)% or (.*)% or higher than (.*)% \(if the Battery Charging threshold is turned on before battery gauge reset, the Battery will be charging to (.*)% or (.*)%\)")]
        public void ThenAfterOfTheProgressWillDisplayAndTheBatteryWillBeChargingToOrOrHigherThanIfTheBatteryChargingThresholdIsTurnedOnBeforeBatteryGaugeResetTheBatteryWillBeChargingToOr(int p0, int p1, string p2, int p3, int p4, int p5, int p6, int p7)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"The machine with two battery")]
        public void WhenTheMachineWithTwoBattery()
        {
            Assert.AreEqual(2, VantageCommonHelper.JudgeBatteryNums());
        }

        [Then(@"There will be two battery reset panel")]
        public void ThenThereWillBeTwoBatteryResetPanel()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _hSPowerSettingsPage.ScrollScreenToWindowsElement(_webDriver.Session, _hSPowerSettingsPage.BatteryGaugeSecondaryBatteryPanelTitle);
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryGaugePrimaryBatteryPanelTitle);
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryGaugeSecondaryBatteryPanelTitle);
        }

        [Then(@"Verify string '(.*)' '(.*)'")]
        //isNull = Display, means the text need display
        //isNull = NotDisplay, means the text should be hidden
        public void ThenVerifyStringDisplays(string targetText, string isNull)
        {
            string targetElement = VantageAutomationIDCollector.Instance.GetVantageAutomationID(targetText.Trim()).ToString();
            WindowsElement targetElementNote = FindElementByTimes(_webDriver.Session, "Name", targetElement.Trim());
            if (isNull.Trim().Equals("Display"))
            {
                Assert.IsNotNull(targetElementNote, "Error: The " + targetElement + " not find in UI");
            }
            else
            {
                Assert.IsNull(targetElementNote, "Error: The " + targetElement + "diaplayed in UI");
            }
        }


        [Then(@"There will be two battery reset panel and a tip ""(.*)""")]
        public void ThenThereWillBeTwoBatteryResetPanelAndATip(string p0)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryGaugePrimaryBatteryPanelTitle);
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryGaugeSecondaryBatteryPanelTitle);
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryGaugeOnlyOneNote);
        }

        [When(@"Slide Screen and go to Button Section")]
        public void WhenSlideScreenAndGoToButtonSection()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hSPowerSettingsPage.HSBatteryGuageResetBtn, "The Button Section not found");
            ScrollScreenToWindowsElement(_webDriver.Session, _hSPowerSettingsPage.HSBatteryGuageResetBtn, -31, 20);
        }


        [Then(@"and the battery will be discharging to (.*)% or lower than (.*)%")]
        public void ThenAndTheBatteryWillBeDischargingToOrLowerThan(int p0, int p1)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"There will pup-up a confirmation dialog")]
        public void WhenThereWillPup_UpAConfirmationDialog()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetPopupWindow);
        }

        [Then(@"The title and tips should follow the UISPEC")]
        public void ThenTheTitleAndTipsShouldFollowTheUISPEC()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.AreEqual("Battery gauge reset", _hSPowerSettingsPage.HSBatteryGuageResetPopupTitle.GetAttribute("Name"));
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetPopupCloseBtn);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetStopPopupDescription);

        }

        [Then(@"There is a YES and a CANCEL button in the windows")]
        public void ThenThereIsAYESAndACANCELButtonInTheWindows()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.AreEqual("Yes", _hSPowerSettingsPage.HSBatteryGuageResetStopPopYesBtn.GetAttribute("Name"));
            Assert.AreEqual("Cancel", _hSPowerSettingsPage.HSBatteryGuageResetPopupCancelBtn.GetAttribute("Name"));
        }

        [Then(@"The windows will be closed and the Reset process will still on going")]
        public void ThenTheWindowsWillBeClosedAndTheResetProcessWillStillOnGoing()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetPerformedProgress);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetPerformedRemaining);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetPerformedStartTime);
        }

        [Then(@"The Reset process will be stopped")]
        public void ThenTheResetProcessWillBeStopped()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetlastResetTimeValue);
        }

        [Then(@"STOP button will change to ""(.*)"" button and can be clicked")]
        public void ThenSTOPButtonWillChangeToButtonAndCanBeClicked(string p0)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetBtn);
            Assert.AreEqual("Reset", _hSPowerSettingsPage.HSBatteryGuageResetBtn.GetAttribute("Name"));
        }

        [Then(@"The Battery Reset panel will display the Last reset item instead of Progress, remaining and start time")]
        public void ThenTheBatteryResetPanelWillDisplayTheLastResetItemInsteadOfProgressRemainingAndStartTime()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetlastReset);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetlastResetTimeValue);

            Assert.IsNull(_hSPowerSettingsPage.HSBatteryGuageResetPerformedProgress);
            Assert.IsNull(_hSPowerSettingsPage.HSBatteryGuageResetPerformedRemaining);
            Assert.IsNull(_hSPowerSettingsPage.HSBatteryGuageResetPerformedStartTime);
        }

        [Then(@"The log is ""(.*)""")]
        public void ThenTheLogIs(string p0)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            DateTime time = currentTime;
            string timeValue = _hSPowerSettingsPage.GetElementTextName(_hSPowerSettingsPage.HSBatteryGuageResetlastResetTimeValue);
            //8/17/2020 3:44:25 PM Failed: Cancelled by user.
            int startTime = timeValue.IndexOfAny("Failed".ToCharArray());
            string cancelText = timeValue.Substring(startTime, timeValue.Length - startTime);
            string cancelTime = timeValue.Substring(0, startTime);
            Assert.AreEqual(cancelText, "Failed: Cancelled by user.");
            if (cancelTime.Contains("PM") || cancelTime.Contains("AM"))
            {
                startTime = timeValue.IndexOfAny("PM".ToCharArray());
                if (cancelTime.Contains("AM"))
                {
                    startTime = timeValue.IndexOfAny("AM".ToCharArray());
                }
                cancelTime = timeValue.Substring(0, startTime);
                string[] getCancelTime = cancelTime.Split(' ');
                Assert.AreEqual(getCancelTime[0], time.Month + "/" + time.Day.ToString() + "/" + time.Year);
                //string[] getTime = getCancelTime[1].Split(':');
                //string[] systime = time.ToString("hh:mm:ss").Split(':'); //12 
                //if(Convert.ToInt32(getTime[0]) < 10)
                //{
                //    getTime[0] = "0" + getTime[0];
                //}
                //Assert.AreEqual(getTime[0], systime[0]);
                //Assert.AreEqual(getTime[1], systime[1]);
                //Assert.AreEqual(getTime[2], systime[2]);
            }
        }

        [When(@"If Battery Charging threshold is on")]
        public void WhenIfBatteryChargingThresholdIsOn()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsTrue(_hSPowerSettingsPage.TurnOnBatteryChargeThreshold(), "Turn On Battery Charge Threshold");
        }

        [Then(@"all buttons in Battery Charge Threshold function \(Battery Charge Threshold feature will be disabled\) will be grey out")]
        public void ThenAllButtonsInBatteryChargeThresholdFunctionBatteryChargeThresholdFeatureWillBeDisabledWillBeGreyOut()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsFalse(_hSPowerSettingsPage.HSThredholdCheckBoxEle.Enabled);
            Assert.IsFalse(_hSPowerSettingsPage.PrimaryBatteryThresholdCheckbox.Enabled);
        }

        [When(@"Checking the Battery Gauge reset is in Stpe (.*)")]
        public void WhenCheckingTheBatteryGaugeResetIsInStpe(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The Battery percentage is about (.*)%")]
        public void ThenTheBatteryPercentageIsAbout(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"Battery Gauge reset is ongoing")]
        public void GivenBatteryGaugeResetIsOngoing()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Get the BCT Stop value")]
        public void WhenGetTheBCTStopValue()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            string startValuestr = _hSPowerSettingsPage.HSBatteryThresoldOneBatteryStartValue.GetAttribute("Name");
            _startValue = Convert.ToInt32(startValuestr.Split('%')[0]);
        }

        [Then(@"Battery Charging threshold will take effect immediately")]
        public void ThenBatteryChargingThresholdWillTakeEffectImmediately()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            int currentPercent = VantageCommonHelper.GetCurrentBatteryPercent();
            if (_startValue < currentPercent)
            {
                Assert.IsNotNull(_hSPowerSettingsPage.HSBattrtyState, "The system is in Charging and startValue is " + _startValue + " and currentPercent is " + currentPercent);
            }
            else
            {
                Assert.IsNull(_hSPowerSettingsPage.HSBattrtyState, "The system is No Activity and startValue is " + _startValue + " and currentPercent is " + currentPercent);
            }
        }

        [Then(@"The tips in Battery Panel section will change to ""(.*)""")]
        public void ThenTheTipsInBatteryPanelSectionWillChangeTo(string p0)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetBatteryNote);
        }

        [When(@"Stop the reset process")]
        public void WhenStopTheResetProcess()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The tip in Battery Panel section will change back to Battery Charging threshold")]
        public void ThenTheTipInBatteryPanelSectionWillChangeBackToBatteryChargingThreshold()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryThresoldBatteryNote);
        }

        [When(@"User make the machine from AC to DC")]
        public void WhenUserMakeTheMachineFromACToDCDuringTheRestProcess()
        {
            if (VantageCommonHelper.JudgeInsertStatusIsOn())
            {
                VantageCommonHelper.AdapterNotInsert();
            }
            Assert.IsTrue(!VantageCommonHelper.JudgeInsertStatusIsOn(), "Failed from AC to DC");
        }

        [When(@"User make the machine from DC to AC")]
        public static void WhenUserMakeTheMachineFromDCToAC()
        {
            if (!VantageCommonHelper.JudgeInsertStatusIsOn())
            {
                VantageCommonHelper.AdapterNotInsert();
            }
            Assert.IsTrue(VantageCommonHelper.JudgeInsertStatusIsOn(), "Failed from DC to AC");
        }

        [Then(@"The reset process will be stopped and the tips should be displayed, RESET button should be in grey-out state immediately")]
        public void ThenTheResetProcessWillBeStoppedAndTheTipsShouldBeDisplayedRESETButtonShouldBeInGrey_OutStateImmediately()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetlastReset);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetlastResetTimeValue);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetNotInACNote);
            Assert.IsFalse(_hSPowerSettingsPage.HSBatteryGuageResetBtn.Enabled);

        }

        [Then(@"The Last reset log should be ""(.*)""")]
        public void ThenTheLastResetLogShouldBe(string logText)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            string resetText = _hSPowerSettingsPage.HSBatteryGuageResetlastResetTimeValue.GetAttribute("Name");
            Assert.IsTrue(resetText.Contains(logText));
        }

        [When(@"Battery Gauge reset process is finished")]
        public void WhenBatteryGaugeResetProcessIsFinished()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The STOP button will be change to RESET and can be clikced")]
        public void ThenTheSTOPButtonWillBeChangeToRESETAndCanBeClikced()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"All settings in Battery Charging threshold will resume from grey-out style")]
        public void ThenAllSettingsInBatteryChargingThresholdWillResumeFromGrey_OutStyle()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The last result log should be ""(.*)""")]
        public void ThenTheLastResultLogShouldBe(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"There will display the  Barcode, Last reset and Full charge capacity items and the ""(.*)"" is ""(.*)"" \(value in: ""(.*)"" where XX is the Battery Barcode\)")]
        public void ThenThereWillDisplayTheBarcodeLastResetAndFullChargeCapacityItemsAndTheIsValueInWhereXXIsTheBatteryBarcode(string p0, string p1, string p2)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Make the machine AC to DC")]
        public void WhenMakeTheMachineACToDC()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"There will be NoAdapter Tip")]
        public void ThenThereWillBeATipsImmediately()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.HSBatteryGuageResetNotInACNote);
        }

        [Then(@"The ""(.*)"" button is in grey-out state and cannot be click immediately")]
        public void ThenTheButtonIsInGrey_OutStateAndCannotBeClickImmediately(string p0)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsFalse(_hSPowerSettingsPage.HSBatteryGuageResetBtn.Enabled);
            Assert.AreEqual("Reset", _hSPowerSettingsPage.HSBatteryGuageResetBtn.GetAttribute("Name"));

        }

        [Given(@"The driver is in good condition and the machine is in DC state")]
        public void GivenTheDriverIsInGoodConditionAndTheMachineIsInDCState()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"There will be a tips ""(.*)""")]
        public void ThenThereWillBeATips(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Make the machine from DC to AC")]
        public void WhenMakeTheMachineFromDCToAC()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The Battery Gauge Reset ""(.*)"" button will be in normal\(Blue\) style and can be clicked immediately")]
        public void ThenTheBatteryGaugeResetButtonWillBeInNormalBlueStyleAndCanBeClickedImmediately(string p0)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsTrue(_hSPowerSettingsPage.HSBatteryGuageResetBtn.Enabled);
            Assert.AreEqual("Reset", _hSPowerSettingsPage.HSBatteryGuageResetBtn.GetAttribute("Name"));

        }

        [Then(@"The battery gauge reset adapter tips should be hidden immediately")]
        public void ThenTheBatteryGaugeResetAdapterTipsShouldBeHiddenImmediately()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNull(_hSPowerSettingsPage.HSBatteryGuageResetNotInACNote);

        }

        [Given(@"The driver is in Error state")]
        public void GivenTheDriverIsInErrorState()
        {
            Common.KillProcess("PowerMgr", true);
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        [Given(@"Restar Powermgrexe")]
        public void GivenRestarPowermgrexe()
        {
            BatteryConditionOnThinkPadFunction.RestartPowerMgrProcess();
        }

        [Given(@"the IdeaPad")]
        public void GivenTheIdeaPad()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Check the UI of Vantage Power page")]
        public void WhenCheckTheUIOfVantagePowerPage()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"There should no Battery Gauge Reset feature in the Battery Settings section")]
        public void ThenThereShouldNoBatteryGaugeResetFeatureInTheBatterySettingsSection()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNull(_hSPowerSettingsPage.HSBatteryGuageResetTitle, "The machine we mark is Idea, but there is has a Battery Gauge Reset Feature");
        }

        [Given(@"The Battery Gauge Reset is on going")]
        public void GivenTheBatteryGaugeResetIsOnGoing()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"The ThinkPad machine with one Battery")]
        public void GivenTheThinkPadMachineWithOneBattery()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"The Reset process is in Step (.*)")]
        public void WhenTheResetProcessIsInStep(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The battery status in Details page is Discharging \(with ac\) but shouldn't display the ""(.*)""")]
        public void ThenTheBatteryStatusInDetailsPageIsDischargingWithAcButShouldnTDisplayThe(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"After the Automation Testing finish")]
        public void GivenAfterTheAutomationTestingFinish()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"check the screenshot")]
        public void WhenCheckTheScreenshot()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The screenshot result should follow each step result\.")]
        public void ThenTheScreenshotResultShouldFollowEachStepResult_()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"The ThinkPad machine with two Batteries")]
        public void GivenTheThinkPadMachineWithTwoBatteries()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The battery \(which is under reset process\) status in Details page is Discharging \(with ac\) and shouldn't display the ""(.*)"" item And the other battery is in No Activity status")]
        public void ThenTheBatteryWhichIsUnderResetProcessStatusInDetailsPageIsDischargingWithAcAndShouldnTDisplayTheItemAndTheOtherBatteryIsInNoActivityStatus(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
