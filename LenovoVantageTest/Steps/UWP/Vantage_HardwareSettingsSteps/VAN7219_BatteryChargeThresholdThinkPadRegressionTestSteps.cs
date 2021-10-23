using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
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
    public class VAN107219_BatteryChargeThresholdThinkPadRegressionTestSteps : BasePage
    {
        private InformationalWebDriver _webDriver;
        private HSPowerSettingsPage _hsPowerSettingsPage;
        private bool dualBattery;
        private bool oneBattery = true;
        private VantageBase vantageBase = new VantageBase();
        private ToggleState BeforeHibernateResult;
        private ToggleState BeforeSleepResult;
        private int _needKeepValue = 0;
        public VAN107219_BatteryChargeThresholdThinkPadRegressionTestSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        public bool GetBatteryPercentNoChange(int batteryValue)
        {
            int tempPercent = VantageCommonHelper.GetCurrentBatteryPercent();
            int currentPercent = VantageCommonHelper.GetCurrentBatteryPercent();
            DateTime starttime = DateTime.Now;
            int interval = 0;
            while (interval <= 5)
            {
                Thread.Sleep(TimeSpan.FromMinutes(1));
                currentPercent = VantageCommonHelper.GetCurrentBatteryPercent();
                interval = (DateTime.Now - starttime).Minutes;
            }
            return (tempPercent == currentPercent && currentPercent == batteryValue);
        }

        [Given(@"Install Vantage")]
        public void GivenInstallVantage()
        {
            VantageCommonHelper.InstallVantage(true);
            var vantageSession = VantageCommonHelper.LaunchSystemUwp(VantageConstContent.VantageUwpAppid);
            VantageCommonHelper.OObeNetVantage30(vantageSession, true);
            _webDriver = new InformationalWebDriver(vantageSession, vantageSession);
        }

        [Given(@"Install Vantage No Launch")]
        public void GivenInstallVantageNoLaunch()
        {
            VantageCommonHelper.InstallVantage(true);
        }

        [Given(@"Launch Vantage with OOBE")]
        public void GivenLaunchVantageWithOOBE()
        {
            VantageCommonHelper.OObeNetVantage30(_webDriver.Session, true);
        }

        [Given(@"Click Device settings,enter Power page")]
        public void GivenClickDeviceSettingsEnterPowerPage()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            bool result = _hsPowerSettingsPage.JumpToBatterySettings();
            Assert.IsTrue(result);
        }

        [Given(@"Machine support dual batteries")]
        public void GivenMachineSupportDualBatteries()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            if (2 != _hsPowerSettingsPage.SupportDualBatteries())
            {
                Assert.Warn("Machine Not dual batteries");
                dualBattery = true;
            }
        }

        [Given(@"Machine support one battery")]
        public void GivenMachineSupportOneBattery()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            if (1 != _hsPowerSettingsPage.SupportDualBatteries())
            {
                Assert.Warn("Machine Not one battery");
                oneBattery = false;
            }
        }

        [When(@"Go to Battery Charge threshold section")]
        public void WhenGoToBatteryChargeThresholdSection()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _hsPowerSettingsPage.GotoPowerPage();
        }

        [When(@"Click the question mark beside Battery charge threshold")]
        public void WhenClickTheQuestionMarkBesideBatteryChargeThreshold()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            bool result = _hsPowerSettingsPage.ClickQuestionMark();
            Assert.IsTrue(result);
        }

        [Then(@"The context of the question mark '(.*)'")]
        public void ThenTheContextOfTheQuestionMark(string multilineText)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.AreEqual(VantageAutomationIDCollector.Instance.GetVantageAutomationID(multilineText).ToString(), _hsPowerSettingsPage.GetQuestionMarkToolTip());
        }

        [When(@"Turn on Battery Charge threshold")]
        public void WhenTurnOnBatteryChargeThreshold()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            bool result = _hsPowerSettingsPage.TurnOnBatteryChargeThreshold();
            Assert.IsTrue(result);
        }

        [When(@"Turn On Battery Charge Threshold And Check Message")]
        public void WhenTurnOnBatteryChargeThresholdAndCheckMessage()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            if (_hsPowerSettingsPage.GetCheckBoxStatus(_hsPowerSettingsPage.HSThredholdCheckBoxEle) == ToggleState.Off)
            {
                _hsPowerSettingsPage.HSThredholdCheckBoxEle.Click();
            }
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdAlertBox, "Element 'Battery Charge Threshold Pop-Up Windows' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdAlertBoxTitle, "Element 'Battery Charge Threshold Pop-Up Windows Title' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdAlertBoxLine1, "Element 'Battery Charge Threshold Pop-Up Windows Paragraph1' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdAlertBoxLine2, "Element 'Battery Charge Threshold Pop-Up Windows Paragraph2' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdAlertBoxLine3, "Element 'Battery Charge Threshold Pop-Up Windows Paragraph3' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdAlertBoxLine4, "Element 'Battery Charge Threshold Pop-Up Windows Paragraph4' Is Not Found");
            Thread.Sleep(TimeSpan.FromSeconds(3));
            _hsPowerSettingsPage.HSThredholdEnableBtnEle.Click();
        }

        [When(@"Click Battery Charge Threshold Button")]
        public void WhenClickBatteryChargeThresholdButton()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            if (_hsPowerSettingsPage.GetCheckBoxStatus(_hsPowerSettingsPage.HSThredholdCheckBoxEle) == ToggleState.Off)
            {
                _hsPowerSettingsPage.HSThredholdCheckBoxEle.Click();
            }
        }

        [When(@"Click Battery Charge Threshold Alert Enable Button")]
        public void WhenClickBatteryChargeThresholdAlertEnableButton()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsPowerSettingsPage.HSThredholdEnableBtnEle, "Element 'HSThredholdEnableBtnEle' Is Not Found");
            _hsPowerSettingsPage.HSThredholdEnableBtnEle.Click();
        }

        [When(@"Click Battery Charge Threshold Alert Here LinK")]
        public void WhenClickBatteryChargeThresholdAlertHereLinK()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdAlertBoxHere, "Element 'BatteryChargeThresholdAlertBoxHere' Is Not Found");
            _hsPowerSettingsPage.BatteryChargeThresholdAlertBoxHere.Click();
        }

        [Then(@"Check Click Battery Charge Threshold Alert Here LinK Jump To Web Page")]
        public void ThenCheckClickBatteryChargeThresholdAlertHereLinKJumpToWebPage()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdJumpPageBack, "Element 'BatteryChargeThresholdJumpPageBack' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdJumpPageTtile1, "Element 'BatteryChargeThresholdJumpPageTtile1' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdJumpPageTtile2, "Element 'BatteryChargeThresholdJumpPageTtile2' Is Not Found");
            Assert.IsTrue(_hsPowerSettingsPage.ShowTextbox(_hsPowerSettingsPage.BatteryChargeThresholdJumpPageTtile1).Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.BatteryChargeThresholdJumpPageTtile1Text").ToString()));
            Assert.IsTrue(_hsPowerSettingsPage.ShowTextbox(_hsPowerSettingsPage.BatteryChargeThresholdJumpPageTtile2).Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.BatteryChargeThresholdJumpPageTtile2Text").ToString()));
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdJumpPageLine1, "Element 'BatteryChargeThresholdJumpPageParagraph1' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdJumpPageLine2, "Element 'BatteryChargeThresholdJumpPageParagraph2' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdJumpPageLine3, "Element 'BatteryChargeThresholdJumpPageParagraph3' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdJumpPageLine4, "Element 'BatteryChargeThresholdJumpPageParagraph4' Is Not Found");
        }

        [When(@"Click Battery Charge Threshold Back LinK")]
        public void WheClickBatteryChargeThresholdBackLinK()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdJumpPageBack, "Element 'BatteryChargeThresholdJumpPageBack' Is Not Found");
            _hsPowerSettingsPage.BatteryChargeThresholdJumpPageBack.Click();
        }

        [Then(@"Check Click Back LinK Go Back Battery Charge Threshold Alert Page")]
        public void ThenCheckClickBackLinKGoBackBatteryChargeThresholdAlertPage()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdAlertBox, "Element 'Battery Charge Threshold Pop-Up Windows' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdAlertBoxTitle, "Element 'Battery Charge Threshold Pop-Up Windows Title' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdAlertBoxLine1, "Element 'Battery Charge Threshold Pop-Up Windows Paragraph1' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdAlertBoxLine2, "Element 'Battery Charge Threshold Pop-Up Windows Paragraph2' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdAlertBoxLine3, "Element 'Battery Charge Threshold Pop-Up Windows Paragraph3' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdAlertBoxLine4, "Element 'Battery Charge Threshold Pop-Up Windows Paragraph4' Is Not Found");
        }

        [When(@"Turn off Battery Charge threshold")]
        public void WhenTurnOffBatteryChargeThreshold()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            bool result = _hsPowerSettingsPage.TurnOffBatteryChargeThreshold();
            Assert.IsTrue(result);
        }

        [When(@"Set the primary battery or the second battery value higher the Stop charging value")]
        public void WhenSetThePrimaryBatteryOrTheSecondBatteryValueHigherTheStopChargingValue()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            WindowsElement primaryBatteryStartDropDownEle = _hsPowerSettingsPage.HSThreholdPrimaryBatteryStartDropDownEle;
            Assert.IsNotNull(primaryBatteryStartDropDownEle);
            int currentBatteryValue = VantageCommonHelper.GetCurrentBatteryPercent();
            Assert.That(currentBatteryValue > 30);
            currentBatteryValue = currentBatteryValue / 10 * 10;
            int startValue = currentBatteryValue - 5;

            WindowsElement primaryBatteryStopDropDownEle = _hsPowerSettingsPage.HSThreholdPrimaryBatteryStopDropDownEle;
            primaryBatteryStopDropDownEle.Click();
            var stopAutomationId90ValueXpath = string.Format("//*[@AutomationId='threshold-primary-battery-stopAtChargeOption-{0}']", currentBatteryValue);
            var stopAutomationId90Ele = _hsPowerSettingsPage.FindElementByXpath(stopAutomationId90ValueXpath);
            Assert.IsNotNull(stopAutomationId90Ele);
            stopAutomationId90Ele.Click();

            primaryBatteryStartDropDownEle.Click();
            var startAutomationId85ValueXpath = string.Format("//*[@AutomationId='threshold-primary-battery-startAtChargeOption-{0}']", startValue);
            var startAutomationId85ValueEle = _hsPowerSettingsPage.FindElementByXpath(startAutomationId85ValueXpath);
            Assert.IsNotNull(startAutomationId85ValueEle);
            startAutomationId85ValueEle.Click();

        }


        [When(@"Set Start charging value:(.*)%,Stop charging:(.*)%")]
        public void WhenSetStartChargingValueStopCharging(int p0, int p1)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            WindowsElement primaryBatteryStartDropDownEle = _hsPowerSettingsPage.HSThreholdPrimaryBatteryStartDropDownEle;
            Assert.IsNotNull(primaryBatteryStartDropDownEle);
            primaryBatteryStartDropDownEle.Click();
            var startAutomationIdValueXpath = string.Format("//*[@AutomationId='threshold-primary-battery-startAtChargeOption-{0}']", 40);
            var startEle = _hsPowerSettingsPage.FindElementByXpath(startAutomationIdValueXpath);
            Assert.IsNotNull(startEle);
            startEle.Click();

            WindowsElement primaryBatteryStopDropDownEle = _hsPowerSettingsPage.HSThreholdPrimaryBatteryStopDropDownEle;
            Assert.IsNotNull(primaryBatteryStopDropDownEle);
            primaryBatteryStopDropDownEle.Click();
            var stopAutomationIdValueXpath = string.Format("//*[@AutomationId='threshold-primary-battery-stopAtChargeOption-{0}']", p1);
            var stopEle = _hsPowerSettingsPage.FindElementByXpath(stopAutomationIdValueXpath);
            Assert.IsNotNull(stopEle);
            stopEle.Click();

            primaryBatteryStartDropDownEle.Click();
            startAutomationIdValueXpath = string.Format("//*[@AutomationId='threshold-primary-battery-startAtChargeOption-{0}']", p0);
            startEle = _hsPowerSettingsPage.FindElementByXpath(startAutomationIdValueXpath);
            Assert.IsNotNull(startEle);
            startEle.Click();
        }

        [When(@"Set Second Battery charging value:(.*)%,Stop charging:(.*)%")]
        public void WhenSetSecondBatteryChargingValueStopCharging(int p0, int p1)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            WindowsElement primaryBatteryStartDropDownEle = _hsPowerSettingsPage.ThresholdSecondaryBatteryStartDropdown;
            Assert.IsNotNull(primaryBatteryStartDropDownEle);

            WindowsElement primaryBatteryStopDropDownEle = _hsPowerSettingsPage.ThresholdSecondaryBatteryStopDropdown;
            Assert.IsNotNull(primaryBatteryStopDropDownEle);
            primaryBatteryStopDropDownEle.Click();
            var stopAutomationIdValueXpath = string.Format("//*[@AutomationId='threshold-secondary-battery-stopAtChargeOption-{0}']", p1);
            var stopEle = _hsPowerSettingsPage.FindElementByXpath(stopAutomationIdValueXpath);
            Assert.IsNotNull(stopEle);
            stopEle.Click();

            primaryBatteryStartDropDownEle.Click();
            var startAutomationIdValueXpath = string.Format("//*[@AutomationId='threshold-secondary-battery-startAtChargeOption-{0}']", p0);
            var startEle = _hsPowerSettingsPage.FindElementByXpath(startAutomationIdValueXpath);
            Assert.IsNotNull(startEle);
            startEle.Click();
        }

        [When(@"""(.*)"" the ""(.*)"" check box")]
        public void WhenTheCheckBox(string p0, string p1)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            WindowsElement checkBox = null;
            if (p1 == "primary")
            {
                checkBox = _hsPowerSettingsPage.PrimaryBatteryThresholdCheckbox;
            }
            else if (p1 == "second")
            {
                checkBox = _hsPowerSettingsPage.SecondBatteryThresholdCheckbox;
            }
            if (p0.ToLower() == "checked")
            {
                bool result = VantageCommonHelper.SwitchToggleStatus(checkBox, ToggleState.On);
                Assert.IsTrue(result, "Checked the toggle false");
            }
            else if (p0.ToLower() == "unchecked")
            {
                bool result = VantageCommonHelper.SwitchToggleStatus(checkBox, ToggleState.Off);
                Assert.IsTrue(result, "UnChecked the toggle false");
            }
        }

        [Then(@"The Battery Settings section displays a header-'(.*)' with a  toggle button to trigger on/off this feature\.")]
        public void ThenTheBatterySettingsSectionDisplaysAHeader_WithAToggleButtonToTriggerOnOffThisFeature_(string p0)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            string title = _hsPowerSettingsPage.GetBatteryHoldTitle();
            Assert.AreEqual(title, VantageAutomationIDCollector.Instance.GetVantageAutomationID(p0).ToString());
            Assert.IsTrue(_hsPowerSettingsPage.GetBatteryHoldToggle());
        }

        [Then(@"There should no Battery Charge Threshold Section")]
        public void ThenThereShouldNoBatteryChargeThresholdSection()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNull(_hsPowerSettingsPage.HSBatteryThresholdTitle, "HSBatteryThresholdTitle is not null");
        }

        [Then(@"The default state should be disabled; The default status should retrieve from the JS Bridge\.")]
        public void ThenTheDefaultStateShouldBeDisabledTheDefaultStatusShouldRetrieveFromTheJSBridge_()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            ToggleState getState = _hsPowerSettingsPage.GetBatteryHoldToggleState();
            Assert.AreEqual(ToggleState.Off, getState);
        }

        [Then(@"Show two standalone settings for the primary battery and secondary one")]
        public void ThenShowTwoStandaloneSettingsForThePrimaryBatteryAndSecondaryOne()
        {
            if (dualBattery)
            {
                return;
            }
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            WindowsElement secondaryBatteryStartDropDownEle = _hsPowerSettingsPage.HSThreholdSecondaryBatteryStartDropDownEle;
            WindowsElement secondaryBatteryStopDropDownEle = _hsPowerSettingsPage.HSThreholdSecondaryBatteryStopDropDownEle;
            WindowsElement primaryBatteryStartDropDownEle = _hsPowerSettingsPage.HSThreholdPrimaryBatteryStartDropDownEle;
            WindowsElement primaryBatteryStopDropDownEle = _hsPowerSettingsPage.HSThreholdPrimaryBatteryStartDropDownEle;
            Assert.IsNotNull(secondaryBatteryStartDropDownEle);
            Assert.IsNotNull(secondaryBatteryStopDropDownEle);
            Assert.IsNotNull(primaryBatteryStartDropDownEle);
            Assert.IsNotNull(primaryBatteryStopDropDownEle);

        }

        [Then(@"The primary battery Start charging when bellow:(.*)%-(.*)%,Stop charging at:(.*)%-(.*)%")]
        public void ThenThePrimaryBatteryStartChargingWhenBellowStopChargingAt(string p0, string p1, string p2, string p3)
        {
            if (dualBattery)
            {
                return;
            }
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            WindowsElement secondaryBatteryStartDropDownEle = _hsPowerSettingsPage.HSThreholdPrimaryBatteryStartDropDownEle;
            Assert.IsNotNull(secondaryBatteryStartDropDownEle);
            secondaryBatteryStartDropDownEle.Click();
            WindowsElement hsPrimaryStartFirstValueEle = _hsPowerSettingsPage.HSPrimaryStartFirstValueEle;
            WindowsElement hsPrimaryStartLastValueEle = _hsPowerSettingsPage.HSPrimaryStartLastValueEle;
            Assert.IsNotNull(hsPrimaryStartFirstValueEle);
            Assert.IsNotNull(hsPrimaryStartLastValueEle);

            WindowsElement secondaryBatteryStopDropDownEle = _hsPowerSettingsPage.HSThreholdPrimaryBatteryStopDropDownEle;
            Assert.IsNotNull(secondaryBatteryStopDropDownEle);
            secondaryBatteryStopDropDownEle.Click();
            Assert.IsNotNull(_hsPowerSettingsPage.HSPrimaryStopFirstValueEle);
            Assert.IsNotNull(_hsPowerSettingsPage.HSPrimaryStopLastValueEle);

        }

        [Then(@"The second battery Start charging when bellow:(.*)%-(.*)%,Stop charging at:(.*)%-(.*)%")]
        public void ThenTheSecondBatteryStartChargingWhenBellowStopChargingAt(string p0, string p1, string p2, string p3)
        {
            if (dualBattery)
            {
                return;
            }

            WindowsElement primaryBatteryStartDropDownEle = _hsPowerSettingsPage.HSThreholdSecondaryBatteryStartDropDownEle;
            Assert.IsNotNull(primaryBatteryStartDropDownEle);
            primaryBatteryStartDropDownEle.Click();
            Assert.IsNotNull(_hsPowerSettingsPage.HSSecondaryStartFirstValueEle);
            Assert.IsNotNull(_hsPowerSettingsPage.HSSecondaryStartLastValueEle);

            WindowsElement primaryBatteryStopDropDownEle = _hsPowerSettingsPage.HSThreholdSecondaryBatteryStopDropDownEle;
            Assert.IsNotNull(primaryBatteryStopDropDownEle);
            primaryBatteryStopDropDownEle.Click();
            Assert.IsNotNull(_hsPowerSettingsPage.HSSecondaryStopFirstValueEle);
            Assert.IsNotNull(_hsPowerSettingsPage.HSSecondaryStopLastValueEle);


        }


        [Then(@"The red text note '(.*)' appera")]
        public void ThenTheRedTextNoteAppera(string p0)
        {
            if (dualBattery)
            {
                return;
            }
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _hsPowerSettingsPage.ScrollScreenToWindowsElement(_webDriver.Session, _hsPowerSettingsPage.BatteryThresholdNote);
            Console.WriteLine(_hsPowerSettingsPage.BatteryThresholdNote.Text);
            Assert.AreEqual(VantageAutomationIDCollector.Instance.GetVantageAutomationID(p0).ToString(), _hsPowerSettingsPage.BatteryThresholdNote.Text);
        }

        [Then(@"Start charging when bellow:(.*)%(.*)%")]
        public void ThenStartChargingWhenBellow(int p0, int p1)
        {
            if (!oneBattery)
            {
                return;
            }
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            WindowsElement secondaryBatteryStartDropDownEle = _hsPowerSettingsPage.HSThreholdPrimaryBatteryStartDropDownEle;
            Assert.IsNotNull(secondaryBatteryStartDropDownEle);
            secondaryBatteryStartDropDownEle.Click();
            WindowsElement hsPrimaryStartFirstValueEle = _hsPowerSettingsPage.HSPrimaryStartFirstValueEle;
            WindowsElement hsPrimaryStartLastValueEle = _hsPowerSettingsPage.HSPrimaryStartLastValueEle;
            Assert.IsNotNull(hsPrimaryStartFirstValueEle);
            Assert.IsNotNull(hsPrimaryStartLastValueEle);
        }

        [Then(@"Stop charging at:(.*)%(.*)%")]
        public void ThenStopChargingAt(int p0, int p1)
        {
            if (!oneBattery)
            {
                return;
            }
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            WindowsElement secondaryBatteryStopDropDownEle = _hsPowerSettingsPage.HSThreholdPrimaryBatteryStopDropDownEle;
            Assert.IsNotNull(secondaryBatteryStopDropDownEle);
            secondaryBatteryStopDropDownEle.Click();
            Assert.IsNotNull(_hsPowerSettingsPage.HSPrimaryStopFirstValueEle);
            Assert.IsNotNull(_hsPowerSettingsPage.HSPrimaryStopLastValueEle);
        }

        [Then(@"The Start charging value (.*)% and more than (.*)% is grey-out")]
        public void ThenTheStartChargingValueAndMoreThanIsGrey_Out(int p0, int p1)
        {
            VantageCommonHelper.MoreThanBatteryValue(p1);
        }

        [Then(@"The Stop charging value (.*)% lower than (.*)% is grey-out")]
        public void ThenTheStopChargingValueLowerThanIsGrey_Out(int p0, int p1)
        {
            VantageCommonHelper.LowerThanBatteryValue(p1);
        }

        [When(@"Check the Primary checkbox")]
        public void WhenCheckTheCheckbox()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            var PrimaryBatteryThresholdCheckboxEle = _hsPowerSettingsPage.PrimaryBatteryThresholdCheckbox;
            Assert.IsNotNull(PrimaryBatteryThresholdCheckboxEle);
            if (VantageCommonHelper.GetToggleStatus(PrimaryBatteryThresholdCheckboxEle) == ToggleState.Off)
            {
                PrimaryBatteryThresholdCheckboxEle.Click();
            }
        }
        [Given(@"UnCheck the Primary checkbox")]
        public void GivenUnCheckTheCheckbox()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            var PrimaryBatteryThresholdCheckboxEle = _hsPowerSettingsPage.PrimaryBatteryThresholdCheckbox;
            if (ToggleState.On == _hsPowerSettingsPage.GetCheckBoxStatus(PrimaryBatteryThresholdCheckboxEle))
            {
                Assert.IsNotNull(PrimaryBatteryThresholdCheckboxEle);
                PrimaryBatteryThresholdCheckboxEle.Click();
            }
        }
        [Given(@"Check the Primary checkbox")]
        public void GivenCheckThePrimaryCheckbox()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            var PrimaryBatteryThresholdCheckboxEle = _hsPowerSettingsPage.PrimaryBatteryThresholdCheckbox;
            if (ToggleState.Off == _hsPowerSettingsPage.GetCheckBoxStatus(PrimaryBatteryThresholdCheckboxEle))
            {
                Assert.IsNotNull(PrimaryBatteryThresholdCheckboxEle);
                PrimaryBatteryThresholdCheckboxEle.Click();
            }
        }

        [Then(@"The Start charging value automatically become (.*)% and greyout")]
        public void ThenTheStartChargingValueAutomaticallyBecomeAndGreyout(int p0)
        {
            if (!oneBattery)
            {
                return;
            }
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            WindowsElement primaryBatteryStartDropDownEle = _hsPowerSettingsPage.HSThreholdPrimaryBatteryStartDropDownEle;
            Assert.IsNotNull(primaryBatteryStartDropDownEle);
            var attribute = primaryBatteryStartDropDownEle.GetAttribute("Name");
            Assert.IsTrue(attribute.Contains("75%"));
            Assert.IsFalse(primaryBatteryStartDropDownEle.Enabled);
        }

        [When(@"Show one standalone settings for the primary battery")]
        public void WhenShowOneStandaloneSettingsForThePrimaryBattery()
        {
            if (!oneBattery)
            {
                return;
            }
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            WindowsElement secondaryBatteryStartDropDownEle = _hsPowerSettingsPage.HSThreholdSecondaryBatteryStartDropDownEle;
            WindowsElement secondaryBatteryStopDropDownEle = _hsPowerSettingsPage.HSThreholdSecondaryBatteryStopDropDownEle;
            WindowsElement primaryBatteryStartDropDownEle = _hsPowerSettingsPage.HSThreholdPrimaryBatteryStartDropDownEle;
            WindowsElement primaryBatteryStopDropDownEle = _hsPowerSettingsPage.HSThreholdPrimaryBatteryStartDropDownEle;
            Assert.IsNull(secondaryBatteryStartDropDownEle);
            Assert.IsNull(secondaryBatteryStopDropDownEle);
            Assert.IsNotNull(primaryBatteryStartDropDownEle);
            Assert.IsNotNull(primaryBatteryStopDropDownEle);
        }

        [When(@"Hibernate system")]
        public void WhenHibernateSystem()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            BeforeHibernateResult = _hsPowerSettingsPage.GetBatteryHoldToggleState();
            vantageBase.EnterS4();
        }

        [When(@"Sleep system")]
        public void WhenSleepSystem()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            BeforeSleepResult = _hsPowerSettingsPage.GetBatteryHoldToggleState();
            vantageBase.EnterS3();
        }


        [Then(@"The toggle state of Battery Charge Threshold function should not be changed")]
        public void ThenTheToggleStateOfBatteryChargeThresholdFunctionShouldNotBeChanged()
        {
            ToggleState AfterHibernateOrSleepResult = _hsPowerSettingsPage.GetBatteryHoldToggleState();
            Assert.IsTrue(BeforeHibernateResult == AfterHibernateOrSleepResult || BeforeSleepResult == AfterHibernateOrSleepResult);
        }

        [Given(@"Support Battery Charge Threshold")]
        public void GivenSupportBatteryChargeThreshold()
        {

        }

        [Given(@"Thinkpad machines")]
        public void GivenThinkpadMachines()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsTrue(_hsPowerSettingsPage.IsThinkPad());
        }

        [Given(@"IdeaPad machines")]
        public void GivenIdeaPadMachines()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsTrue(_hsPowerSettingsPage.IsIdeaPad());
        }

        [Then(@"Bellow the Battery health icon the text '(.*)' will appear immediately")]
        public void ThenBellowTheBatteryHealthIconTheTextNoteNoteWillAppearImmediately(string p0)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            WindowsElement noteEle = _hsPowerSettingsPage.BatteryGaugethresholdNoteEle;
            Assert.IsNotNull(noteEle);
            Debug.WriteLine(noteEle.Text);
            Assert.AreEqual(VantageAutomationIDCollector.Instance.GetVantageAutomationID(p0).ToString(), noteEle.Text);
        }

        [Then(@"Bellow the Battery health icon the text note will disappear immediately")]
        public void ThenBellowTheBatteryHealthIconTheTextNoteWillDisappearImmediately()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNull(_hsPowerSettingsPage.BatteryGaugethresholdNoteEle);
        }


        [Then(@"The Start charging threshold (.*) percentage points bellow the Stop charging threshold")]
        public void ThenTheStartChargingThresholdPercentagePointsBellowTheStopChargingThreshold(int p0)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            //Get Start Percentage
            WindowsElement primaryBatteryStartDropDownEle = _hsPowerSettingsPage.HSThreholdPrimaryBatteryStartDropDownEle;
            Assert.IsNotNull(primaryBatteryStartDropDownEle);
            var startAttribute = primaryBatteryStartDropDownEle.GetAttribute("AriaProperties");
            var sartValueSring = startAttribute.Contains("%") ? startAttribute : primaryBatteryStartDropDownEle.GetAttribute("Name");
            int startPerIdex = sartValueSring.IndexOf('%');
            string startPoint = sartValueSring.Substring(startPerIdex - 2, 2);
            Assert.IsNotNull(startPoint);
            int startValue = Convert.ToInt32(startPoint);
            //Get Stop Percentage
            WindowsElement primaryBatteryStopDropDownEle = _hsPowerSettingsPage.HSThreholdPrimaryBatteryStopDropDownEle;
            Assert.IsNotNull(primaryBatteryStopDropDownEle);
            var stopAttribute = primaryBatteryStopDropDownEle.GetAttribute("AriaProperties");
            var stopValueSring = stopAttribute.Contains("%") ? stopAttribute : primaryBatteryStopDropDownEle.GetAttribute("Name");
            int stopPerIdex = stopValueSring.IndexOf('%');
            string stopPoint = stopValueSring.Contains("100%") ? "100" : stopValueSring.Substring(stopPerIdex - 2, 2);
            Assert.IsNotNull(stopPoint);
            int stopValue = Convert.ToInt32(stopPoint);
            Assert.AreEqual(startValue + p0, stopValue);
        }

        [Given(@"Set ThinkPad Machine Battery Level Is Below (.*)%")]
        public void GivenchangeThinkPadmachinetoACcondition(int batteryLifePercent)
        {
            VantageCommonHelper.LessThanPowerValue(batteryLifePercent);
            _needKeepValue = VantageCommonHelper.GetCurrentBatteryPercent();
        }

        [Given(@"Set ThinkPad Machine Battery Level Is More Than (.*)%")]
        public void GivenSetThinkPadMachineBatteryLevelIsMoreThan(int batteryLifePercent)
        {
            VantageCommonHelper.MoreThanPowerValue(batteryLifePercent + 1);
            _needKeepValue = VantageCommonHelper.GetCurrentBatteryPercent();
        }

        [Then(@"The Machine Will Charge Until (.*)%")]
        public void ThenTheMachineWillChargeUntil(int batteryLifePercent)
        {
            VantageCommonHelper.MoreThanPowerValue(batteryLifePercent);
            Assert.IsTrue(VantageCommonHelper.GetCurrentBatteryPercent() == batteryLifePercent, "Battery Life Percent is Not 80%");
        }

        [When(@"The user set the Start charging when bellow:(.*)%,Stop charging at:(.*)%,set the system power to (.*)%")]
        public void WhenTheUserSetTheStartChargingWhenBellowStopChargingAtSetTheSystemPowerTo(int p0, int p1, int p2)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"the user plug in the power supply")]
        public void WhenTheUserPlugInThePowerSupply()
        {
            Assert.IsTrue(VantageCommonHelper.JudgeInsertStatusIsOn(), "ACLineStatus is Offline");
        }

        [Then(@"the battery value of the machine will not reduce and battery value keep Origin Value")]
        public void ThenTheBatteryValueOfTheMachineWillNotReduceOriginValue()
        {
            Assert.IsTrue(GetBatteryPercentNoChange(_needKeepValue), "The Battery Value Of The Machine Is Changed, not keep " + _needKeepValue);
        }


        [Then(@"the machine battery will show not charge status")]
        public void ThenTheMachineBatteryWillShowNotChargeStatus()
        {
            Assert.IsTrue(VantageCommonHelper.GetCurrentBatteryFlagIsNoCharging(), "Machine Is Charging");
        }

        [Then(@"Check Battery Charge Threshold Elements")]
        public void ThenCheckBatteryChargeThresholdElements()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdTitle, "Element 'BatteryChargeThresholdTitle' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdCaption, "Element 'BatteryChargeThresholdCaption' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.HSThredholdCheckBoxEle, "Element 'HSThredholdCheckBoxEle' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.HSBatteryThresholdRightIcon, "Element 'HSBatteryThresholdRightIcon' Is Not Found");
        }

        [When(@"Turn On And Check Battery Charge Threshold PopUp Display On Non Support Battery Temporary Mode system")]
        public void WhenCheckNotSupportBatteryTemporaryModeBatteryChargeThresholdAlertMessage()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            if (_hsPowerSettingsPage.GetCheckBoxStatus(_hsPowerSettingsPage.HSThredholdCheckBoxEle) == ToggleState.Off)
            {
                _hsPowerSettingsPage.HSThredholdCheckBoxEle.Click();
            }
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdAlertBox, "Element 'Battery Charge Threshold Pop-Up Windows' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdAlertBoxTitle, "Element 'Battery Charge Threshold Pop-Up Windows Title' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdAlertBoxLine1, "Element 'Battery Charge Threshold Pop-Up Windows Paragraph1' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdAlertBoxLine2, "Element 'Battery Charge Threshold Pop-Up Windows Paragraph2' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdAlertBoxLine3, "Element 'Battery Charge Threshold Pop-Up Windows Paragraph3' Is Not Null");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdAlertBoxLine4, "Element 'Battery Charge Threshold Pop-Up Windows Paragraph4' Is Not Null");
            Thread.Sleep(TimeSpan.FromSeconds(3));
            _hsPowerSettingsPage.HSThredholdEnableBtnEle.Click();
        }

        [Then(@"Check Start charging value:(.*),Stop charging:(.*)")]
        public void ThenCheckStartChargingValueStopCharging(string startValue, string stopValue)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdStartValue, "Element 'BatteryChargeThresholdStartValue' Is Not Found");
            Assert.IsNotNull(_hsPowerSettingsPage.BatteryChargeThresholdStopValue, "Element 'BatteryChargeThresholdStopValue' Is Not Found");
            Assert.IsTrue(_hsPowerSettingsPage.ShowTextbox(_hsPowerSettingsPage.BatteryChargeThresholdStartValue).Equals(startValue));
            Assert.IsTrue(_hsPowerSettingsPage.ShowTextbox(_hsPowerSettingsPage.BatteryChargeThresholdStopValue).Equals(stopValue));
        }

        [When(@"Set the primary battery level ""(.*)""")]
        public void WhenSetThePrimaryBatteryLevel(int p0)
        {
            int nowBatteryLevel = VantageCommonHelper.GetTowBatteryComputerBatteryLevel(0);
            if (nowBatteryLevel > p0)
            {
                VantageCommonHelper.LessThanPowerValue(p0, "two", 0);
            }
            else if (nowBatteryLevel < p0)
            {
                VantageCommonHelper.MoreThanPowerValue(p0, "two", 0);
                if (VantageCommonHelper.JudgeInsertStatusIsOn())
                {
                    VantageCommonHelper.AdapterNotInsert();
                }
                if (!VantageCommonHelper.JudgeInsertStatusIsOn())
                {
                    VantageCommonHelper.AdapterNotInsert();
                }
                Assert.IsTrue(VantageCommonHelper.JudgeInsertStatusIsOn(), "Judge Insert Status Is Off");
            }
        }

        [When(@"Set the second battery level ""(.*)""")]
        public void WhenSetTheSecondBatteryLevel(int p0)
        {
            int nowBatteryLevel = VantageCommonHelper.GetTowBatteryComputerBatteryLevel(1);
            if (nowBatteryLevel > p0)
            {
                VantageCommonHelper.LessThanPowerValueByPLC(p0, "two");
            }
            else if (nowBatteryLevel < p0)
            {
                VantageCommonHelper.MoreThanPowerValueByPLC(p0, "two");
                if (VantageCommonHelper.JudgeInsertStatusIsOn())
                {
                    VantageCommonHelper.AdapterNotInsert();
                }
                if (!VantageCommonHelper.JudgeInsertStatusIsOn())
                {
                    VantageCommonHelper.AdapterNotInsert();
                }
                Assert.IsTrue(VantageCommonHelper.JudgeInsertStatusIsOn(), "Judge Insert Status Is Off");
            }
        }

        [When(@"Click Battery level button")]
        public void WhenClickBatteryLevelButton()
        {
            WindowsDriver<WindowsElement> deskSession = GetControlPanelSession(true);
            Thread.Sleep(3000);
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            if (_hsPowerSettingsPage.TaskBarBatteryLevelButtonPluggedin == null)
            {
                if (_hsPowerSettingsPage.TaskBarBatteryLevelButtonFullCharge == null)
                {
                    Assert.NotNull(_hsPowerSettingsPage.TaskBarBatteryLevelButtonNoPluggedin, "Can't click battery level button!!!");
                    _hsPowerSettingsPage.TaskBarBatteryLevelButtonNoPluggedin.Click();
                }
                else
                {
                    _hsPowerSettingsPage.TaskBarBatteryLevelButtonFullCharge.Click();
                }
            }
            else
            {
                _hsPowerSettingsPage.TaskBarBatteryLevelButtonPluggedin.Click();
            }
        }

        [When(@"Wait ""(.*)"" battery level to ""(.*)""")]
        public void ThenWaitBatteryLevelTo(string p0, int p1)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _hsPowerSettingsPage.HSWaitTwoBatteryLevel(p0, p1);
        }

        [Then(@"The ""(.*)"" battery start will change to ""(.*)""")]
        public void ThenTheBatteryStartWillChangeTo(string p0, string p1)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            WindowsElement button = _hsPowerSettingsPage.BatteryChargeThresholdSelectedStartChargePrimary;
            if (p0 == "second")
            {
                button = _hsPowerSettingsPage.BatteryChargeThresholdSelectedStartChargeSecond;
            }
            string level = button.Text;
            Assert.AreEqual(level, p1 + "%", "The battery level is not true");
        }

        [Then(@"The Primary Battery level is ""(.*)"", Second Battery level is ""(.*)""")]
        public void ThenThePrimaryBatteryLevelIsSecondBatteryLevelIs(int p0, int p1)
        {
            int primaryBatteryLevel = VantageCommonHelper.GetTowBatteryComputerBatteryLevel(0);
            int secondBatteryLevel = VantageCommonHelper.GetTowBatteryComputerBatteryLevel(1);
            Assert.AreEqual(p0, primaryBatteryLevel, "The primary value is not" + Convert.ToString(p0));
            Assert.AreEqual(p1, secondBatteryLevel, "The primary value is not" + Convert.ToString(p1));
        }

    }
}
