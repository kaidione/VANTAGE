using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GPULlightingSteps
    {

        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;
        private object currentMachineType;

        public GPULlightingSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"The Graphics Card vendor value is (.*) And the Method is (.*)")]
        public void ThenTheGraphicsCardVendorValueIsAndTheMethodIsGetSmartFanMode(int p0, string p1)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Assert.IsTrue(NerveCenterHelper.GetGPUVendorValue(p0, p1), string.Format("Get {0} Value is ", p1) + p0);
        }

        [Then(@"The Lighting Feature value is (.*) And the Method is (.*)")]
        public void ThenTheLightingFeatureValueIsAndTheMethodIsGetBIOSOCMode(string p2, string p3)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            string[] values;
            bool isSupport = false;
            values = p2.Trim().Split(new char[] { ',' });
            foreach (string value in values)
            {
                if (NerveCenterHelper.GetThermalModeValue(Convert.ToInt32(value), p3))
                {
                    isSupport = true;
                    break;
                }
            }
            Assert.IsTrue(isSupport, "The Lighting Feature values " + p2 + " are not supported.");
        }
    }
}