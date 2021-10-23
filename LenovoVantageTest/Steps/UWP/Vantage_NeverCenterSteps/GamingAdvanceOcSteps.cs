
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using TechTalk.SpecFlow;


namespace LenovoVantageTest.Features.UWP.Vantage_NerveCenter
{
    [Binding]
    public class GamingAdvanceOcSteps
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;

        public GamingAdvanceOcSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"Advanced OC button and enable oc checkbox should be shown in the Advanced OC settings dialog")]
        public void ShownInOCSettingDialog()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.ThermalSettingAdvanced);
            Assert.IsNotNull(_nerveCenterPages.ThermalSettingAdvancedName);
            Assert.IsNotNull(_nerveCenterPages.EnableOcCheckboxUnchecked);
            _nerveCenterPages.ThermalModeSettingPopupClose.Click();
        }

        [Then(@"Advanced OC button and enable oc checkbox should not be shown in the Advanced OC settings dialog")]
        public void NoShownInOCSettingDialog()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.ThermalSettingAdvanced);
            Assert.IsNull(_nerveCenterPages.ThermalSettingAdvancedName);
            Assert.IsNull(_nerveCenterPages.EnableOcCheckboxUnchecked);
            Assert.IsNull(_nerveCenterPages.EnableOcCheckboxUncheckedName);
        }

        [Given(@"Advanced link button shown")]
        public void AdvancedBtn_Shown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.ThermalSettingAdvanced);
            Assert.IsNotNull(_nerveCenterPages.ThermalSettingAdvancedName);
            Assert.IsNotNull(_nerveCenterPages.ThermalModeSetting);
            Assert.IsNotNull(_nerveCenterPages.ThermalModeSettingPopupClose);
            Assert.IsNotNull(_nerveCenterPages.ThermalModeSettingPopupCloseName);
        }

        [Given(@"click the Advance OC btn in the Thermal mode settings page")]
        public void AdvancedBtn_Click()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.ThermalSettingAdvanced);
            Assert.IsNotNull(_nerveCenterPages.ThermalSettingAdvancedName);
            _nerveCenterPages.ThermalSettingAdvanced.Click();
        }

        [Then(@"Thermal mode settings page should be closed and the Warning dialog should be shown")]
        public void PageCloseAndWarning()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.ThermalModeSetting);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedWarningPage);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedWarningCancel);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedWarningCancelName);
            _nerveCenterPages.ThermalAdvancedWarningCancel.Click();
        }

        [When(@"check other area")]
        public void checkOtherArea()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.warningdialogwarningtext);
            _nerveCenterPages.warningdialogwarningtext.Click();
        }

        [Then(@"Warning dialog should not be closed")]
        public void WarningDialogNoClosed()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedWarningPage);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedWarningCancel);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedWarningCancelName);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedwarningproceedBtn);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedwarningproceedBtnName);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedDwarningcloseBtn);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedwarningcloseBtnName);
        }

        [Then(@"Proceed-btn cancel-link-btn X-btn and warning sentence should be shown")]
        public void showIn_WarningDialog()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedWarningPage);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedWarningCancel);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedWarningCancelName);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedwarningproceedBtn);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedwarningproceedBtnName);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedDwarningcloseBtn);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedwarningcloseBtnName);
            Assert.IsNotNull(_nerveCenterPages.warningdialogwarningtext);
            Assert.IsNotNull(_nerveCenterPages.WarningDialogwarningdescription);
        }

        [Given(@"Warning dialog is displaying")]
        public void showWarningDialog()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedWarningPage);
            Assert.IsNotNull(_nerveCenterPages.WarningDialogwarningdescription);
        }

        [Given(@"click the X_Btn link in the Warning dialog")]
        public void clickCloseBtn_WarningDialog()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedDwarningcloseBtn);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedwarningcloseBtnName);
            _nerveCenterPages.ThermalAdvancedDwarningcloseBtn.Click();
        }

        [Then(@"Warning dialog should be closed and homepage should be shown")]
        public void WarningDialogClose_goHomePage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.ThermalAdvancedWarningPage);
            Assert.IsNull(_nerveCenterPages.ThermalAdvancedWarningPage);
            Assert.IsNull(_nerveCenterPages.ThermalAdvancedWarningCancel);
            Assert.IsNull(_nerveCenterPages.ThermalAdvancedWarningCancelName);
            Assert.IsNull(_nerveCenterPages.ThermalAdvancedwarningproceedBtn);
            Assert.IsNull(_nerveCenterPages.ThermalAdvancedwarningproceedBtnName);
            Assert.IsNull(_nerveCenterPages.ThermalAdvancedDwarningcloseBtn);
            Assert.IsNull(_nerveCenterPages.ThermalAdvancedwarningcloseBtnName);
            Assert.IsNotNull(_nerveCenterPages.menuDevice);
            Assert.IsNotNull(_nerveCenterPages.GamingsystemstatusInfo);
        }

        [Given(@"click the cancel_Btn link in the Warning dialog")]
        public void clickCancelBtn_WarningDialog()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedWarningCancel);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedWarningCancelName);
            _nerveCenterPages.ThermalAdvancedWarningCancel.Click();
        }

        [Given(@"click the proceed_Btn link in the Warning dialog")]
        public void clickProceedBtn_WarningDialog()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedWarningCancel);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedWarningCancelName);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedwarningproceedBtn);
            Assert.IsNotNull(_nerveCenterPages.ThermalAdvancedwarningproceedBtnName);
            _nerveCenterPages.ThermalAdvancedwarningproceedBtn.Click();
        }

        [Then(@"Warning dialog should be closed and Advance OC page should be shown")]
        public void WarningDialogClose_goAdvanceOCpage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.ThermalAdvancedWarningPage);
            Assert.IsNull(_nerveCenterPages.ThermalAdvancedWarningCancel);
            Assert.IsNull(_nerveCenterPages.ThermalAdvancedWarningCancelName);
            Assert.IsNull(_nerveCenterPages.ThermalAdvancedwarningproceedBtn);
            Assert.IsNull(_nerveCenterPages.ThermalAdvancedwarningproceedBtnName);
            Assert.IsNull(_nerveCenterPages.ThermalAdvancedDwarningcloseBtn);
            Assert.IsNotNull(_nerveCenterPages.OverclockAdvancedSettingsClosebutton);
            Assert.IsNotNull(_nerveCenterPages.OverclockAdvancedSettingsClosebuttonName);
            Assert.IsNotNull(_nerveCenterPages.OverclockAdvancedsettingssettodefaultbutton);
            Assert.IsNotNull(_nerveCenterPages.OverclockAdvancedsettingssettodefaultbuttonName);
        }
    }
}
