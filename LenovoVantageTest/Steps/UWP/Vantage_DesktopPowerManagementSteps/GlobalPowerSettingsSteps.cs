using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using TangramTest.Utility;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_DesktopPowerManagementSteps
{
    [Binding]
    public sealed class GlobalPowerSettingsSteps
    {
        private WindowsDriver<WindowsElement> _session;
        private DesktopPowerManagementPages _desktopPowerManagementPages;

        public GlobalPowerSettingsSteps(InformationalWebDriver appDriver)
        {
            this._session = appDriver.Session;
        }

        [When(@"Go to Global power settings Section for DPM")]
        public void WhenGoToGlobalPowerSettingsSectionForDPM()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerSettingsTitle, "Power Settings Title not found");
            _desktopPowerManagementPages.DPMPowerSettingsTitle.Click();
            SendKeys.SendWait("{PGDN}");
        }

        [Then(@"The Global power settings section is below Power plan section")]
        public void ThenTheGlobalPowerSettingsSectionIsBelowPowerPlanSection()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerPlanTitle, "Power Plan Title not found");
            Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerSettingsTitle, "Global Power Settings Title not found");
            if (_desktopPowerManagementPages.DPMPowerSettingsTitle.Location.Y < _desktopPowerManagementPages.DPMPowerPlanUsageLabel.Location.Y || _desktopPowerManagementPages.DPMPowerSettingsDescription.Location.Y < _desktopPowerManagementPages.DPMPowerPlanUsageLabel.Location.Y ||
                _desktopPowerManagementPages.DPMPowerButtonDropdown.Location.Y < _desktopPowerManagementPages.DPMPowerPlanUsageLabel.Location.Y || _desktopPowerManagementPages.DPMRequiredSignInDropdown.Location.Y < _desktopPowerManagementPages.DPMPowerPlanUsageLabel.Location.Y ||
                _desktopPowerManagementPages.DPMRequiredSignInNote.Location.Y < _desktopPowerManagementPages.DPMPowerPlanUsageLabel.Location.Y)
            {
                Assert.Fail("The Global Power Settings Section Is not Below Power Plan Section");
            }
        }

        [Then(@"The Global power settings description is consistent with defined document")]
        public void ThenTheGlobalPowerSettingsDescriptionIsConsistentWithDefinedDocument(string text)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.AreEqual(text, _desktopPowerManagementPages.DPMPowerSettingsDescription.Text, "Global power settings description is incorrect");
        }

        [Then(@"The POWER BUTTON and REQUIRED SIGN IN options are displaying normally")]
        public void ThenThePOWERBUTTONAndREQUIREDSIGNINOptionsAreDisplayingNormally()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerButtonDropdown, "The Power Button Dropdown not found");
            Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerButtonLabel, "The Power Button text not found");
            Assert.IsNotNull(_desktopPowerManagementPages.DPMRequiredSignInDropdown, "The Required Sign In Dropdown not found");
            Assert.IsNotNull(_desktopPowerManagementPages.DPMRequiredSignInLabel, "The Required Sign In text not found");
            Assert.IsNotNull(_desktopPowerManagementPages.DPMRequiredSignInNote, "The Required Sign In Note not found");
        }

        [Then(@"The POWER BUTTON option is consistent with Windows Settings")]
        public void ThenThePOWERBUTTONOptionIsConsistentWithWindowsSettings()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            string option = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerButton);
            ThenThePowerButtonOptionConsistentWithDPMPageOptionInWindowsSettings(option);
        }

        [When(@"The User Click POWER BUTTON menu list")]
        public void WhenTheUserClickPOWERBUTTONMenuList()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerButtonDropdown, "The Power Button Dropdown not found");
            _desktopPowerManagementPages.DPMPowerButtonDropdown.Click();
        }

        [Then(@"The POWER BUTTON valid options should be showing")]
        public void ThenThePOWERBUTTONValidOptionsShouldBeShowing()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.NotZero(_desktopPowerManagementPages.DPMPowerButtonDropdownList.Count, "The power button options is zero");
            bool flag = false;
            foreach (var option in DesktopPowerManagementHelper.DPMPowerButtonOptionsDefault)
            {
                flag = false;
                foreach (var item in _desktopPowerManagementPages.DPMPowerButtonDropdownList)
                {
                    if (_desktopPowerManagementPages.GetDPMDropDownMenuItemElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerButton, item) == option)
                    {
                        flag = true;
                        break;
                    }
                }
                Assert.IsTrue(flag, "The power button option （default）" + option + "Not found");
            }
        }
        [When(@"User select one power button option in drop down menu '(.*)'")]
        public void WhenUserSelectOnePowerButtonOptionInDropDownMenu(string option)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.NotZero(_desktopPowerManagementPages.DPMPowerButtonDropdownList.Count, "The power button options is zero");
            foreach (var item in _desktopPowerManagementPages.DPMPowerButtonDropdownList)
            {
                if (_desktopPowerManagementPages.GetDPMDropDownMenuItemElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerButton, item) == option)
                {
                    item.Click();
                    Thread.Sleep(1000);
                    break;
                }
            }
        }

        [Then(@"The power button option only showing the chosed power button option just now '(.*)'")]
        public void ThenThePowerButtonOptionOnlyShowingTheChosedPowerButtonOptionJustNow(string option)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerButtonDropdown, "The Power Button Dropdown not found");
            Assert.Zero(_desktopPowerManagementPages.DPMPowerButtonDropdownList.Count, "The power button options is not zero");
            string curoption = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerButton);
            Assert.AreEqual(option, curoption, "The chosed power button option not show");
        }

        [Then(@"The power button option consistent with DPM page option in windows settings '(.*)'")]
        public void ThenThePowerButtonOptionConsistentWithDPMPageOptionInWindowsSettings(string option)
        {
            switch (option)
            {
                case "Do nothing":
                    Assert.AreEqual(DesktopPowerManagementHelper.PowerButtonOptions.DoNothing, DesktopPowerManagementHelper.GetCurrentPowerButtonSignInOptionsViaContract(true), "The power button option not consistent with DPM page option in windows settings");
                    Assert.AreEqual(DesktopPowerManagementHelper.PowerButtonOptions.DoNothing, DesktopPowerManagementHelper.GetCurrentPowerButtonSignInOptionsViaWindowsAPI(DesktopPowerManagementHelper.PowerSettingsType.PowerButtonAC), "The power button option not consistent with DPM page option in windows settings");
                    break;
                case "Sleep":
                    Assert.AreEqual(DesktopPowerManagementHelper.PowerButtonOptions.Sleep, DesktopPowerManagementHelper.GetCurrentPowerButtonSignInOptionsViaContract(true), "The power button option not consistent with DPM page option in windows settings");
                    Assert.AreEqual(DesktopPowerManagementHelper.PowerButtonOptions.Sleep, DesktopPowerManagementHelper.GetCurrentPowerButtonSignInOptionsViaWindowsAPI(DesktopPowerManagementHelper.PowerSettingsType.PowerButtonAC), "The power button option not consistent with DPM page option in windows settings");
                    break;
                case "Hibernate":
                    Assert.AreEqual(DesktopPowerManagementHelper.PowerButtonOptions.Hibernate, DesktopPowerManagementHelper.GetCurrentPowerButtonSignInOptionsViaContract(true), "The power button option not consistent with DPM page option in windows settings");
                    Assert.AreEqual(DesktopPowerManagementHelper.PowerButtonOptions.Hibernate, DesktopPowerManagementHelper.GetCurrentPowerButtonSignInOptionsViaWindowsAPI(DesktopPowerManagementHelper.PowerSettingsType.PowerButtonAC), "The power button option not consistent with DPM page option in windows settings");
                    break;
                case "Shut down":
                    Assert.AreEqual(DesktopPowerManagementHelper.PowerButtonOptions.ShutDown, DesktopPowerManagementHelper.GetCurrentPowerButtonSignInOptionsViaContract(true), "The power button option not consistent with DPM page option in windows settings");
                    Assert.AreEqual(DesktopPowerManagementHelper.PowerButtonOptions.ShutDown, DesktopPowerManagementHelper.GetCurrentPowerButtonSignInOptionsViaWindowsAPI(DesktopPowerManagementHelper.PowerSettingsType.PowerButtonAC), "The power button option not consistent with DPM page option in windows settings");
                    break;
                case "Turn off the display":
                    Assert.AreEqual(DesktopPowerManagementHelper.PowerButtonOptions.TurnOffTheDisplay, DesktopPowerManagementHelper.GetCurrentPowerButtonSignInOptionsViaContract(true), "The power button option not consistent with DPM page option in windows settings");
                    Assert.AreEqual(DesktopPowerManagementHelper.PowerButtonOptions.TurnOffTheDisplay, DesktopPowerManagementHelper.GetCurrentPowerButtonSignInOptionsViaWindowsAPI(DesktopPowerManagementHelper.PowerSettingsType.PowerButtonAC), "The power button option not consistent with DPM page option in windows settings");
                    break;
                default:
                    Assert.Fail("ThenThePowerButtonOptionConsistentWithDPMPageOptionInWindowsSettings not run");
                    break;
            }
        }

        [Given(@"User select one power button option in windows settings '(.*)'")]
        public void GivenUserSelectOnePowerButtonOptionInWindowsSettings(string option)
        {
            bool flag = false;
            switch (option)
            {
                case "Do nothing":
                    flag = DesktopPowerManagementHelper.ManualPowerButtonsOptionsControl(DesktopPowerManagementHelper.PowerButtonOptions.DoNothing, DesktopPowerManagementHelper.PowerSettingsType.PowerButtonAC);
                    break;
                case "Sleep":
                    flag = DesktopPowerManagementHelper.ManualPowerButtonsOptionsControl(DesktopPowerManagementHelper.PowerButtonOptions.Sleep, DesktopPowerManagementHelper.PowerSettingsType.PowerButtonAC);
                    break;
                case "Hibernate":
                    flag = DesktopPowerManagementHelper.ManualPowerButtonsOptionsControl(DesktopPowerManagementHelper.PowerButtonOptions.Hibernate, DesktopPowerManagementHelper.PowerSettingsType.PowerButtonAC);
                    break;
                case "Shut down":
                    flag = DesktopPowerManagementHelper.ManualPowerButtonsOptionsControl(DesktopPowerManagementHelper.PowerButtonOptions.ShutDown, DesktopPowerManagementHelper.PowerSettingsType.PowerButtonAC);
                    break;
                case "Turn off the display":
                    flag = DesktopPowerManagementHelper.ManualPowerButtonsOptionsControl(DesktopPowerManagementHelper.PowerButtonOptions.TurnOffTheDisplay, DesktopPowerManagementHelper.PowerSettingsType.PowerButtonAC);
                    break;
                default:
                    Assert.Fail("GivenUserSelectOnePowerButtonOptionInWindowsSettings not run");
                    break;
            }
            Assert.IsTrue(flag, "The user select power button option fail");
        }

        [Given(@"Get Session for Global Power Settings")]
        public void GivenGetSessionForGlobalPowerSettings()
        {
            _session = DesktopPowerManagementHelper.Session;
        }

        [Given(@"The Machine is not pwd")]
        public void GivenTheMachineIsNotPasswords()
        {
            bool flag = DesktopPowerManagementHelper.ManualRemoveUserPassword(null);
            Assert.IsTrue(flag, "Manual Remove User Password fail");
        }

        [Given(@"Set a pwd for the machine '(.*)'")]
        public void GivenSetAPasswordsForTheMachine(string pwd)
        {
            bool flag = DesktopPowerManagementHelper.ManualAddedUserPassword(null, pwd);
            Assert.IsTrue(flag, "Manual Added User Password fail");
        }


        [Then(@"The REQUIRED SIGN IN not show in windows settings")]
        public void ThenTheREQUIREDSIGNINNotShowInWindowsSettings()
        {
            Process.Start("ms-settings:signinoptions");
            Thread.Sleep(3000);
            UIAutomationControl automationControl = new UIAutomationControl();
            AutomationElement element = automationControl.FindElementInRootElement(AutomationElement.RootElement, "SystemSettings_Users_DelayLock_ComboBox", null, 15);
            Assert.IsNull(element, "The REQUIRED SIGN IN still show in windows settings ");
        }

        [Then(@"The REQUIRED SIGN IN show in windows settings")]
        public void ThenTheREQUIREDSIGNINShowInWindowsSettings()
        {
            Process.Start("ms-settings:signinoptions");
            Thread.Sleep(3000);
            UIAutomationControl automationControl = new UIAutomationControl();
            AutomationElement element = automationControl.FindElementInRootElement(AutomationElement.RootElement, "SystemSettings_Users_DelayLock_ComboBox", null, 15);
            Assert.IsNotNull(element, "The REQUIRED SIGN IN not show in windows settings ");
        }

        [Then(@"The REQUIRED SIGN IN option consistent with DPM page option in windows settings '(.*)'")]
        public void ThenTheREQUIREDSIGNINOptionConsistentWithDPMPageOptionInWindowsSettings(string option)
        {
            switch (option)
            {
                case "Never":
                    Assert.AreEqual(DesktopPowerManagementHelper.RequiredSignInOption.Never, DesktopPowerManagementHelper.GetCurrentPowerButtonSignInOptionsViaContract(false), "The REQUIRED SIGN IN option not consistent with DPM page option in windows settings");
                    Assert.AreEqual(DesktopPowerManagementHelper.RequiredSignInOption.Never, DesktopPowerManagementHelper.GetCurrentPowerButtonSignInOptionsViaWindowsAPI(DesktopPowerManagementHelper.PowerSettingsType.SignInAC, false), "The REQUIRED SIGN IN option not consistent with DPM page option in windows settings,API");
                    break;
                case "When PC wakes up from sleep":
                    Assert.AreEqual(DesktopPowerManagementHelper.RequiredSignInOption.WakesUpFromSleep, DesktopPowerManagementHelper.GetCurrentPowerButtonSignInOptionsViaContract(false), "The REQUIRED SIGN IN option not consistent with DPM page option in windows settings");
                    Assert.AreEqual(DesktopPowerManagementHelper.RequiredSignInOption.WakesUpFromSleep, DesktopPowerManagementHelper.GetCurrentPowerButtonSignInOptionsViaWindowsAPI(DesktopPowerManagementHelper.PowerSettingsType.SignInAC, false), "The REQUIRED SIGN IN option not consistent with DPM page option in windows settings,API");
                    break;
                default:
                    Assert.Fail("ThenTheREQUIREDSIGNINOptionConsistentWithDPMPageOptionInWindowsSettings not run");
                    break;
            }
        }

        [Then(@"The REQUIRED SIGN IN drop down menu option is consistent with Windows Settings")]
        public void ThenTheREQUIREDSIGNINDropDownMenuOptionIsConsistentWithWindowsSettings()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            string option = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.RequiredSignIn);
            ThenTheREQUIREDSIGNINOptionConsistentWithDPMPageOptionInWindowsSettings(option);
        }

        [Then(@"The REQUIRED SIGN IN description is consistent with defined document")]
        public void ThenTheREQUIREDSIGNINDescriptionIsConsistentWithDefinedDocument(string text)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.AreEqual(text, _desktopPowerManagementPages.DPMRequiredSignInNote.Text, "Required Sign In Note description is incorrect");
        }

        [When(@"The User Click REQUIRED SIGN IN menu list")]
        public void WhenTheUserClickREQUIREDSIGNINMenuList()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.IsNotNull(_desktopPowerManagementPages.DPMRequiredSignInDropdown, "The Required Sign In Dropdown not found");
            _desktopPowerManagementPages.DPMRequiredSignInDropdown.Click();
        }

        [Then(@"The REQUIRED SIGN IN valid options should be showing")]
        public void ThenTheREQUIREDSIGNINValidOptionsShouldBeShowing()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.NotZero(_desktopPowerManagementPages.DPMRequiredSignInDropdownList.Count, "The Required Sign In options is zero");
            bool flag = false;
            foreach (var option in DesktopPowerManagementHelper.DPMRequiredSignInOptionsDefault)
            {
                flag = false;
                foreach (var item in _desktopPowerManagementPages.DPMRequiredSignInDropdownList)
                {
                    if (_desktopPowerManagementPages.GetDPMDropDownMenuItemElementAttributesValue(DesktopPowerManagementPages.DropDownElements.RequiredSignIn, item) == option)
                    {
                        flag = true;
                        break;
                    }
                }
                Assert.IsTrue(flag, "The Required Sign In option （default）" + option + "Not found");
            }
        }

        [When(@"User select one REQUIRED SIGN IN option in drop down menu '(.*)'")]
        public void WhenUserSelectOneREQUIREDSIGNINOptionInDropDownMenu(string option)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.NotZero(_desktopPowerManagementPages.DPMRequiredSignInDropdownList.Count, "The Required Sign In options is zero");
            foreach (var item in _desktopPowerManagementPages.DPMRequiredSignInDropdownList)
            {
                if (_desktopPowerManagementPages.GetDPMDropDownMenuItemElementAttributesValue(DesktopPowerManagementPages.DropDownElements.RequiredSignIn, item) == option)
                {
                    item.Click();
                    Thread.Sleep(1000);
                    break;
                }
            }
        }

        [Then(@"The REQUIRED SIGN IN option only showing the chosed REQUIRED SIGN IN option just now '(.*)'")]
        public void ThenTheREQUIREDSIGNINOptionOnlyShowingTheChosedREQUIREDSIGNINOptionJustNow(string option)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.IsNotNull(_desktopPowerManagementPages.DPMRequiredSignInDropdown, "The Required Sign In not found");
            Assert.Zero(_desktopPowerManagementPages.DPMRequiredSignInDropdownList.Count, "The Required Sign In options is not zero");
            string curoption = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.RequiredSignIn);
            Assert.AreEqual(option, curoption, "The chosed Required Sign In option not show");
        }

        [Given(@"User select one REQUIRED SIGN IN option in windows settings '(.*)'")]
        public void GivenUserSelectOneREQUIREDSIGNINOptionInWindowsSettings(string option)
        {
            bool flag = false;
            switch (option)
            {
                case "Never":
                    flag = DesktopPowerManagementHelper.SetRequiredSignInOption(DesktopPowerManagementHelper.RequiredSignInOption.Never);
                    break;
                case "When PC wakes up from sleep":
                    flag = DesktopPowerManagementHelper.SetRequiredSignInOption(DesktopPowerManagementHelper.RequiredSignInOption.WakesUpFromSleep);
                    break;
                default:
                    Assert.Fail("The GivenUserSelectOneREQUIREDSIGNINOptionInWindowsSettings not run");
                    break;
            }
            Assert.IsTrue(flag, "The GivenUserSelectOneREQUIREDSIGNINOptionInWindowsSettings fail," + option);
        }

    }
}
