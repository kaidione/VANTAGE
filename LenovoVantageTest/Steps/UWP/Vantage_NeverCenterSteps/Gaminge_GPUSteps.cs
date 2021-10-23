using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingE_GPUSteps
    {

        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;
        private GamingHybridModeSteps GamingHybridModeSteps;
        private List<string> displayName;
        private List<string> displayVision;
        private List<string> gpu;
        bool containIntel = false;
        public GamingE_GPUSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
            displayName = NerveCenterHelper.GetDisplayAdaptersInfo("Name");
            displayVision = NerveCenterHelper.GetDisplayAdaptersInfo("DriverVersion");
        }

        //step01
        [Given(@"eGPU and dGPU driver version are the same")]
        public void GivenTheFirstNumberIs()
        {
            bool visionstate = false;
            for (int i = 1; i < displayVision.Count; i++)
            {
                if (displayVision[i - 1] == displayVision[i])
                {
                    visionstate = true;
                    break;
                }
            }
            Assert.IsTrue(visionstate, "vision not same");
        }

        [Given(@"Plug in the external graphics card")]
        public void GetExternalGrah()
        {
            foreach (string str in displayName)
            {
                if (str.Contains("Intel"))
                {
                    containIntel = true;
                }
            }//judge intel disppay
            if (containIntel)
            {
                if ((displayName.Count > 2) && (displayVision.Count > 2))
                {
                    Assert.IsTrue(true, "only one display");
                }
            }
            else if ((displayName.Count > 1) && (displayVision.Count > 1))
            {
                Assert.IsFalse(false, "only one display");
            }
        }

        [Given(@"eGPU function Unsupport")]
        public void JudgeEGPUunspport()//判断Thermal_mode_page_isExist是否存在
        {
            var currentMachineType = VantageCommonHelper.GetCurrentMachineType();//获取电脑机型        
            if (!(currentMachineType.Contains("Legion S7 15IMH05") || currentMachineType.Contains("Legion Y9000X 2021")))
            {
                Assert.IsTrue(true);
            }
        }

        [Then(@"Vantage GPU name and values should be consistent with dGPU")]
        public void NoShownInOCSettingDialog()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);

            string gpunname = _nerveCenterPages.SystemStatusGPUInfo.GetAttribute("Name");
            //string gpunname2 = _nerveCenterPages.SystemStatusGPUInfo.Text;
            bool state = gpunname.Contains(displayName[0]);
            if (state)
            {
                Assert.IsTrue(true, "Vantage GPU  name and values not consistent with dGPU");
            }

        }

        //step08
        [Then(@"Hybrid Mode should be worked correctly")]
        public void HybridMosdeStatus()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (_nerveCenterPages.LegionEdgeHybridModeToggleOn != null)
            {
                ThenTheNumberOfGraphicsCardInDeviceManagerIs(2);
            }
            else if (_nerveCenterPages.LegionEdgeHybridModeToggleOff != null)
            {
                ThenTheNumberOfGraphicsCardInDeviceManagerIs(1);
            }
            else Assert.IsFalse(false, "hybrid button not find");

        }
        public void ThenTheNumberOfGraphicsCardInDeviceManagerIs(int number)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            int _number = NerveCenterHelper.GetDisplayAdaptersInfo("Name").Count;
            Assert.AreEqual(number, _number, "The two numbers of Graphics Card are not equal.");
        }

    }
}
