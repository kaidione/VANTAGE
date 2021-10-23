using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingX50AdvancedOCSaveChangesSteps
    {

        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;
        private string _oneActiveCoreRatioLevel = string.Empty;
        private string _twoActiveCoreRatioLevel = string.Empty;
        private string _threeActiveCoreRatioLevel = string.Empty;
        private string _fourActiveCoreRatioLevel = string.Empty;
        private string _fiveActiveCoreRatioLevel = string.Empty;
        private string _sixActiveCoreRatioLevel = string.Empty;
        private string _sevenActiveCoreRatioLevel = string.Empty;
        private string _eightActiveCoreRatioLevel = string.Empty;
        private string _oneCoreRatioLevel = string.Empty;
        private string _twoCoreRatioLevel = string.Empty;
        private string _threeCoreRatioLevel = string.Empty;
        private string _fourCoreRatioLevel = string.Empty;
        private string _fiveCoreRatioLevel = string.Empty;
        private string _sixCoreRatioLevel = string.Empty;
        private string _sevenCoreRatioLevel = string.Empty;
        private string _eightCoreRatioLevel = string.Empty;
        private string _nineCoreRatioLevel = string.Empty;
        private string _tenCoreRatioLevel = string.Empty;
        private string _coreVoltageOffsetLevel = string.Empty;
        private string _coreVoltageLevel = string.Empty;
        private string _aVXRatioOffsetLevel = string.Empty;
        private string _cacheRatioLevel = string.Empty;
        private string _cacheVoltageOffsetLevel = string.Empty;
        private string _cacheVoltageLevel = string.Empty;
        private string _coreICCMAXLevel = string.Empty;
        private string _cacheICCMAXLevel = string.Empty;
        private string _currentMachineType;

        public GamingX50AdvancedOCSaveChangesSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"click X button in Advance OC dialog")]
        public void GivenClickXButtonInAdvanceOCDialog()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.OverclockCloseBtn, "X button in Advance OC dialog is null.");
            _nerveCenterPages.OverclockCloseBtn.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        [Given(@"click X button in the save change dialog")]
        public void GivenClickXButtonInTheSaveChangeDialog()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SaveChangeCloseBtn, "X button in the save change dialog is null.");
            _nerveCenterPages.SaveChangeCloseBtn.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        [Given(@"click Don't Save link button in the save change dialog")]
        public void GivenClickDonTSaveLinkButtonInTheSaveChangeDialog()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SaveChangeDialogNotSaveBtn, "Don't Save link is null.");
            _nerveCenterPages.SaveChangeDialogNotSaveBtn.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        [Given(@"click Save button in the save change dialog")]
        public void GivenClickSaveButtonInTheSaveChangeDialog()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SaveChangeDialogSaveBtn, "Save button is null.");
            _nerveCenterPages.SaveChangeDialogSaveBtn.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        [Given(@"all parameters are not changed")]
        public void GivenAllParametersAreNotChanged()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (_currentMachineType == "Y750")
            {
                Assert.IsNotNull(_nerveCenterPages.OneActiveCoreRatioLevelDefault, "1 Active Core Ratio value is null.");
                _oneActiveCoreRatioLevel = _nerveCenterPages.OneActiveCoreRatioLevelDefault.Text;
                Assert.IsNotNull(_nerveCenterPages.TwoActiveCoreRatioLevelDefault, "2 Active Core Ratio value is null.");
                _twoActiveCoreRatioLevel = _nerveCenterPages.TwoActiveCoreRatioLevelDefault.Text;
                Assert.IsNotNull(_nerveCenterPages.ThreeActiveCoreRatioLevelDefault, "3 Active Core Ratio value is null.");
                _threeActiveCoreRatioLevel = _nerveCenterPages.ThreeActiveCoreRatioLevelDefault.Text;
                Assert.IsNotNull(_nerveCenterPages.FourActiveCoreRatioLevelDefault, "4 Active Core Ratio value is null.");
                _fourActiveCoreRatioLevel = _nerveCenterPages.FourActiveCoreRatioLevelDefault.Text;
                Assert.IsNotNull(_nerveCenterPages.FiveActiveCoreRatioLevelDefault, "5 Active Core Ratio value is null.");
                _fiveActiveCoreRatioLevel = _nerveCenterPages.FiveActiveCoreRatioLevelDefault.Text;
                Assert.IsNotNull(_nerveCenterPages.SixActiveCoreRatioLevelDefault, "6 Active Core Ratio value is null.");
                _sixActiveCoreRatioLevel = _nerveCenterPages.SixActiveCoreRatioLevelDefault.Text;
                Assert.IsNotNull(_nerveCenterPages.SevenActiveCoreRatioLevelDefault, "7 Active Core Ratio value is null.");
                _sevenActiveCoreRatioLevel = _nerveCenterPages.SevenActiveCoreRatioLevelDefault.Text;
                Assert.IsNotNull(_nerveCenterPages.EightActiveCoreRatioLevelDefault, "8 Active Core Ratio value is null.");
                _eightActiveCoreRatioLevel = _nerveCenterPages.EightActiveCoreRatioLevelDefault.Text;
            }
            if (_currentMachineType == "T750")
            {
                Assert.IsNotNull(_nerveCenterPages.OneCoreRatioLevelDefault, "1 Core Ratio value is null.");
                _oneCoreRatioLevel = _nerveCenterPages.OneCoreRatioLevelDefault.Text;
                Assert.IsNotNull(_nerveCenterPages.TwoCoreRatioLevelDefault, "2 Core Ratio value is null.");
                _twoCoreRatioLevel = _nerveCenterPages.TwoCoreRatioLevelDefault.Text;
                Assert.IsNotNull(_nerveCenterPages.ThreeCoreRatioLevelDefault, "3 Core Ratio value is null.");
                _threeCoreRatioLevel = _nerveCenterPages.ThreeCoreRatioLevelDefault.Text;
                Assert.IsNotNull(_nerveCenterPages.FourCoreRatioLevelDefault, "4 Core Ratio value is null.");
                _fourCoreRatioLevel = _nerveCenterPages.FourCoreRatioLevelDefault.Text;
                Assert.IsNotNull(_nerveCenterPages.FiveCoreRatioLevelDefault, "5 Core Ratio value is null.");
                _fiveCoreRatioLevel = _nerveCenterPages.FiveCoreRatioLevelDefault.Text;
                Assert.IsNotNull(_nerveCenterPages.SixCoreRatioLevelDefault, "6 Core Ratio value is null.");
                _sixCoreRatioLevel = _nerveCenterPages.SixCoreRatioLevelDefault.Text;
                Assert.IsNotNull(_nerveCenterPages.SevenCoreRatioLevelDefault, "7 Core Ratio value is null.");
                _sevenCoreRatioLevel = _nerveCenterPages.SevenCoreRatioLevelDefault.Text;
                Assert.IsNotNull(_nerveCenterPages.EightCoreRatioLevelDefault, "8 Core Ratio value is null.");
                _eightCoreRatioLevel = _nerveCenterPages.EightCoreRatioLevelDefault.Text;
                Assert.IsNotNull(_nerveCenterPages.NineCoreRatioLevelDefault, "9 Core Ratio value is null.");
                _nineCoreRatioLevel = _nerveCenterPages.NineCoreRatioLevelDefault.Text;
                Assert.IsNotNull(_nerveCenterPages.TenCoreRatioLevelDefault, "10 Core Ratio value is null.");
                _tenCoreRatioLevel = _nerveCenterPages.TenCoreRatioLevelDefault.Text;
                Assert.IsNotNull(_nerveCenterPages.CoreVoltageLevelDefault, "Core Voltage value is null.");
                _coreVoltageLevel = _nerveCenterPages.CoreVoltageLevelDefault.Text;
                Assert.IsNotNull(_nerveCenterPages.CoreICCMAXLevelDefault, "Core ICC MAX value is null.");
                _coreICCMAXLevel = _nerveCenterPages.CoreICCMAXLevelDefault.Text;
                Assert.IsNotNull(_nerveCenterPages.CacheICCMAXLevelDefault, "Cache ICC MAX value is null.");
                _cacheICCMAXLevel = _nerveCenterPages.CacheICCMAXLevelDefault.Text;
                Assert.IsNotNull(_nerveCenterPages.CacheVoltageLevelDefault, "Cache Voltage value is null.");
                _cacheVoltageLevel = _nerveCenterPages.CacheVoltageLevelDefault.Text;
            }
            Assert.IsNotNull(_nerveCenterPages.CoreVoltageOffsetLevelDefault, "Core Voltage Offset value is null.");
            _coreVoltageOffsetLevel = _nerveCenterPages.CoreVoltageOffsetLevelDefault.Text;
            Assert.IsNotNull(_nerveCenterPages.AVXRatioOffsetLevelDefault, "AVX Ratio Offset value is null.");
            _aVXRatioOffsetLevel = _nerveCenterPages.AVXRatioOffsetLevelDefault.Text;
            Assert.IsNotNull(_nerveCenterPages.CacheRatioLevelDefault, "Cache Ratio value is null.");
            _cacheRatioLevel = _nerveCenterPages.CacheRatioLevelDefault.Text;
            Assert.IsNotNull(_nerveCenterPages.CacheVoltageOffsetLevelDefault, "Cache Voltage Offset value is null.");
            _cacheVoltageOffsetLevel = _nerveCenterPages.CacheVoltageOffsetLevelDefault.Text;
        }

        [Given(@"all parameters have been changed")]
        public void GivenAllParametersHaveBeenChanged()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (_currentMachineType == "Y750")
            {
                Assert.IsNotNull(_nerveCenterPages.OneActiveCoreRatioSlider, "1 Active Core Ratio Slider is null.");
                _nerveCenterPages.OneActiveCoreRatioSlider.Click();
            }
            if (_currentMachineType == "T750")
            {
                Assert.IsNotNull(_nerveCenterPages.CoreVoltagePlusIcon, "Core Voltage plus icon is null.");
                _nerveCenterPages.CoreVoltagePlusIcon.Click();
                Assert.IsNotNull(_nerveCenterPages.CoreICCMAXMinusIcon, "Core ICC MAX minus icon is null.");
                _nerveCenterPages.CoreICCMAXMinusIcon.Click();
            }
            Assert.IsNotNull(_nerveCenterPages.CoreVoltageOffsetPlusIcon, "Core Voltage Offset plus icon is null.");
            _nerveCenterPages.CoreVoltageOffsetPlusIcon.Click();
            Assert.IsNotNull(_nerveCenterPages.AVXRatioOffsetSlider, "AVX Ratio Offset Slider is null.");
            _nerveCenterPages.AVXRatioOffsetSlider.Click();
            Assert.IsNotNull(_nerveCenterPages.CacheRatioSlider, "Cache Ratio Slider is null.");
            _nerveCenterPages.CacheRatioSlider.Click();
        }

        [Given(@"click the other areas")]
        public void GivenClickTheOtherAreas()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.VantageTitleBar, "Vantage title bar is null.");
            _nerveCenterPages.VantageTitleBar.Click();
        }

        [Then(@"Save change dialog should not be shown")]
        public void ThenSaveChangeDialogShouldNotBeShown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.SaveChangeDialog, "Save change dialog should not be shown");
        }

        [Then(@"the Advance OC dialog should be closed")]
        public void ThenTheAdvanceOCDialogShouldBeClosed()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.AdvancedOCDialog, "The Advance OC dialog should be closed.");
        }

        [Then(@"the Advance OC dialog should be shown")]
        public void ThenTheAdvanceOCDialogShouldBeShown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.AdvancedOCDialog, "The Advance OC dialog should be shown.");
        }

        [Then(@"all parameters should be consistent with the before that the Advance OC dialog is closed")]
        public void ThenAllParametersShouldBeConsistentWithTheBeforeThatTheAdvanceOCDialogIsClosed()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (_currentMachineType == "Y750")
            {
                Assert.AreEqual(_oneActiveCoreRatioLevel, _nerveCenterPages.OneActiveCoreRatioLevelDefault.Text);
                Assert.AreEqual(_twoActiveCoreRatioLevel, _nerveCenterPages.TwoActiveCoreRatioLevelDefault.Text);
                Assert.AreEqual(_threeActiveCoreRatioLevel, _nerveCenterPages.ThreeActiveCoreRatioLevelDefault.Text);
                Assert.AreEqual(_fourActiveCoreRatioLevel, _nerveCenterPages.FourActiveCoreRatioLevelDefault.Text);
                Assert.AreEqual(_fiveActiveCoreRatioLevel, _nerveCenterPages.FiveActiveCoreRatioLevelDefault.Text);
                Assert.AreEqual(_sixActiveCoreRatioLevel, _nerveCenterPages.SixActiveCoreRatioLevelDefault.Text);
                Assert.AreEqual(_sevenActiveCoreRatioLevel, _nerveCenterPages.SevenActiveCoreRatioLevelDefault.Text);
                Assert.AreEqual(_eightActiveCoreRatioLevel, _nerveCenterPages.EightActiveCoreRatioLevelDefault.Text);
            }
            if (_currentMachineType == "T750")
            {
                Assert.AreEqual(_oneCoreRatioLevel, _nerveCenterPages.OneCoreRatioLevelDefault.Text);
                Assert.AreEqual(_twoCoreRatioLevel, _nerveCenterPages.TwoCoreRatioLevelDefault.Text);
                Assert.AreEqual(_threeCoreRatioLevel, _nerveCenterPages.ThreeCoreRatioLevelDefault.Text);
                Assert.AreEqual(_fourCoreRatioLevel, _nerveCenterPages.FourCoreRatioLevelDefault.Text);
                Assert.AreEqual(_fiveCoreRatioLevel, _nerveCenterPages.FiveCoreRatioLevelDefault.Text);
                Assert.AreEqual(_sixCoreRatioLevel, _nerveCenterPages.SixCoreRatioLevelDefault.Text);
                Assert.AreEqual(_sevenCoreRatioLevel, _nerveCenterPages.SevenCoreRatioLevelDefault.Text);
                Assert.AreEqual(_eightCoreRatioLevel, _nerveCenterPages.EightCoreRatioLevelDefault.Text);
                Assert.AreEqual(_nineCoreRatioLevel, _nerveCenterPages.NineCoreRatioLevelDefault.Text);
                Assert.AreEqual(_tenCoreRatioLevel, _nerveCenterPages.TenCoreRatioLevelDefault.Text);
                Assert.AreEqual(_coreVoltageLevel, _nerveCenterPages.CoreVoltageLevelDefault.Text);
                Assert.AreEqual(_coreICCMAXLevel, _nerveCenterPages.CoreICCMAXLevelDefault.Text);
                Assert.AreEqual(_cacheICCMAXLevel, _nerveCenterPages.CacheICCMAXLevelDefault.Text);
                Assert.AreEqual(_cacheVoltageLevel, _nerveCenterPages.CacheVoltageLevelDefault.Text);
            }
            Assert.AreEqual(_coreVoltageOffsetLevel, _nerveCenterPages.CoreVoltageOffsetLevelDefault.Text);
            Assert.AreEqual(_aVXRatioOffsetLevel, _nerveCenterPages.AVXRatioOffsetLevelDefault.Text);
            Assert.AreEqual(_cacheRatioLevel, _nerveCenterPages.CacheRatioLevelDefault.Text);
            Assert.AreEqual(_cacheVoltageOffsetLevel, _nerveCenterPages.CacheVoltageOffsetLevelDefault.Text);
        }

        [Then(@"Save change dialog should be shown")]
        public void ThenSaveChangeDialogShouldBeShown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SaveChangeDialog, "Save change dialog should be shown.");
            Assert.IsNotNull(_nerveCenterPages.SaveChangeTitle, "Title is null.");
            Assert.IsNotNull(_nerveCenterPages.SaveChangeOCRecovery, "Risk tips is null.");
            Assert.IsNotNull(_nerveCenterPages.SaveChangePressingPowerButton, "The first recover OC values method is null.");
            Assert.IsNotNull(_nerveCenterPages.SaveChangeOCRestoreDefault, "The second recover OC values method is null.");
            Assert.IsNotNull(_nerveCenterPages.SaveChangeDialogSaveBtn, "Save button is null.");
            Assert.IsNotNull(_nerveCenterPages.SaveChangeDialogNotSaveBtn, "Don't Save link button is null");
            Assert.IsNotNull(_nerveCenterPages.SaveChangeCloseBtn, "X button is null");
        }

    }
}
