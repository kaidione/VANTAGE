using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingGPUOCVRAMSteps
    {
        private GamingThermalModePages _gamingThermalModePages;
        private InformationalWebDriver _webDriver;
        private double _currentSliderValue = 0.0;
        private WindowsDriver<WindowsElement> _session;

        public GamingGPUOCVRAMSteps(InformationalWebDriver appDriver)
        {
            this._webDriver = appDriver;
            this._session = appDriver.Session;
        }

        [Then(@"CPU Clock Offset and VRAM Clock Offset Items Should be Shown in the Advanced OC Page")]
        public void ThenCPUClockOffsetAndVRAMClockOffsetItemsShouldBeShownInTheAdvancedOCPage()
        {
            _gamingThermalModePages = new GamingThermalModePages(_session);
            Assert.IsNotNull(_gamingThermalModePages.GPUOCClockLabelTextElement, "The GPUOCClockLabelTextElement is null");
            Assert.IsNotNull(_gamingThermalModePages.VRAMOCClockLabelTextElement, "The VRAMOCClockLabelTextElement is null");
        }

        [Then(@"VRAM Clock Offset '(.*)' should be consistent with Spec definition")]
        public void ThenVRAMClockOffsetShouldBeConsistentWithSpecDefinition(string p0)
        {
            _gamingThermalModePages = new GamingThermalModePages(_session);
            Assert.AreEqual(p0, _gamingThermalModePages.ShowTextbox(_gamingThermalModePages.VramClockOffsetlevel200), "The Default is not " + p0);
        }

        [Given(@"Hover the mouse on the '(.*)' In the Vantage")]
        public void GivenHoverTheMouseOnTheInTheVantage(string p0)
        {
            _gamingThermalModePages = new GamingThermalModePages(_session);
            VantageCommonHelper.HoverElement(p0);
        }

        [Then(@"VRAM Clock Offset description tip should be shown the VRAM Clock Offset area")]
        public void ThenVRAMClockOffsetDescriptionTipShouldBeShownTheVRAMClockOffsetArea()
        {
            _gamingThermalModePages = new GamingThermalModePages(_session);
            Assert.IsNotNull(_gamingThermalModePages.VramTips, "Vram Tips is Null");
        }

        [Given(@"Drag '(.*)' on the Slider Bar to The Far '(.*)'")]
        public void GivenDragOnTheSliderBarToTheFar(string p0, string p1)
        {
            _gamingThermalModePages = new GamingThermalModePages(_session);
            _gamingThermalModePages.DragElementTo(p0, p1);
        }

        [Given(@"Drag '(.*)' on the Slider Bar to The '(.*)'")]
        public void GivenDragOnTheSliderBarToThe(string p0, string p1)
        {
            _gamingThermalModePages = new GamingThermalModePages(_session);
            _gamingThermalModePages.DragElementTo(p0, p1);
        }

        [When(@"Get the Slider Bar value")]
        public void WhenGetTheSliderBarValue()
        {
            _gamingThermalModePages = new GamingThermalModePages(_session);
            var sliderElement = _gamingThermalModePages.VramClockOffsetSlider;
            _currentSliderValue = Convert.ToDouble(sliderElement.GetAttribute("RangeValue.Value"));
        }

        [Then(@"Should be greater than before Dragging")]
        public void ThenShouldBeGreaterThanBeforeDragging()
        {
            _gamingThermalModePages = new GamingThermalModePages(_session);
            var sliderElement = _gamingThermalModePages.VramClockOffsetSlider;
            var newSliderValue = Convert.ToDouble(sliderElement.GetAttribute("RangeValue.Value"));
            Assert.Greater(newSliderValue, _currentSliderValue, string.Format("The old value {0} is not greater than new {1}", _currentSliderValue, newSliderValue));
        }

        [Then(@"Should be smaller than before Dragging")]
        public void ThenShouldBeSmallerThanBeforeDragging()
        {
            _gamingThermalModePages = new GamingThermalModePages(_session);
            var sliderElement = _gamingThermalModePages.VramClockOffsetSlider;
            var newSliderValue = Convert.ToDouble(sliderElement.GetAttribute("RangeValue.Value"));
            Assert.Less(newSliderValue, _currentSliderValue, string.Format("The old value {0} is not smaller than new {1}", _currentSliderValue, newSliderValue));
        }

        [Then(@"The '(.*)' Slider value should be the '(.*)' value")]
        public void ThenTheSliderValueShouldBeTheValue(string p0, string size)
        {
            _gamingThermalModePages = new GamingThermalModePages(_session);
            WindowsElement windowsElement = _gamingThermalModePages.FindElementByTimes(_session, "AutomationId", p0);
            Assert.IsNotNull(windowsElement, string.Format("The {0} is null", p0));
            double currentSliderValue = Convert.ToDouble(windowsElement.GetAttribute("RangeValue.Value"));
            Assert.AreEqual(size, currentSliderValue.ToString());
        }

        [Given(@"Click Minus icon to check value")]
        public void GivenClickMinusIconToCheckValue()
        {
            _gamingThermalModePages = new GamingThermalModePages(_session);
            Assert.IsNotNull(_gamingThermalModePages.VramClockOffsetMinusIconClickabler, "The VramClockOffsetMinusIconClickabler is null");
            _gamingThermalModePages.VramClockOffsetMinusIconClickabler.Click();
        }

        [Given(@"Click Plus icon to check value")]
        public void GivenClickPlusIconToCheckValue()
        {
            Assert.IsNotNull(_gamingThermalModePages.VramClockOffsetPlusIconClickabler, "The VramClockOffsetMinusIconClickabler is null");
            _gamingThermalModePages.VramClockOffsetPlusIconClickabler.Click();
        }

        [Then(@"The '(.*)' values in the tool should be '(.*)'")]
        public void ThenTheValuesInTheToolShouldBe(string p0, int p1)
        {
            _gamingThermalModePages = new GamingThermalModePages(_session);
            double gpuValue = double.Parse(_gamingThermalModePages.GetGPUOCValue(5, p0)) / 1000;
            Assert.AreEqual(p1, gpuValue, "The Valuse is not equal");

        }

        [Given(@"Click the X button")]
        public void GivenClickTheXButton()
        {
            _gamingThermalModePages = new GamingThermalModePages(_session);
            Assert.IsNotNull(_gamingThermalModePages.VramClockOffsetCloseWindow, "VramClockOffsetCloseWindow Element is null");
            _gamingThermalModePages.VramClockOffsetCloseWindow.Click();
        }

        [Given(@"Click the Save button")]
        public void GivenClickTheSaveButton()
        {
            _gamingThermalModePages = new GamingThermalModePages(_session);
            Assert.IsNotNull(_gamingThermalModePages.VramClockOffsetSave, "VramClockOffsetSave Element is null");
            _gamingThermalModePages.VramClockOffsetSave.Click();

        }

        [Then(@"Vram Slider Minus and Plus icon should not be grey and clickable")]
        public void ThenVramSliderMinusAndPlusIconShouldNotBeGreyAndClickable()
        {
            _gamingThermalModePages = new GamingThermalModePages(_session);
            Assert.IsNotNull(_gamingThermalModePages.VramClockOffsetMinusIconClickabler, "VramClockOffsetMinusIconClickabler is null ");
            Assert.IsNotNull(_gamingThermalModePages.VramClockOffsetPlusIconClickabler, "VramClockOffsetPlusIconClickabler is null");
        }

        [Given(@"Click '(.*)' on the Slider Bar to The '(.*)' To Set Slider Value '(.*)'")]
        public void GivenClickOnTheSliderBarToTheToSetSliderValue(string p0, int p1, int p2)
        {
            _gamingThermalModePages = new GamingThermalModePages(_session);
            WindowsElement windowsElement = _gamingThermalModePages.FindElementByTimes(_session, "AutomationId", p0);
            Assert.IsNotNull(windowsElement, string.Format("The {0} is null", p0));
            for (int i = 0; i < p1; i++)
            {
                windowsElement.Click();
            }
        }
    }
}
