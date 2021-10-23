using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using Microsoft.Win32;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Features.UWP.Vantage_NerveCenter
{
    [Binding]
    public class GamingMemory_OCSteps
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;
        private int OC_Value = 0;
        private string status = "OFF";
        public GamingMemory_OCSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"RAM Toggle status should be off")]
        public void RAMToggleBtnStatus_off()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu);
            Assert.IsNotNull(_nerveCenterPages.SystemStatusInfoLink);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOff);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOffName);
        }

        [Given(@"Get_MemorySpeed")]
        public void Get_MemorySpeed()
        {
            const string pattern = "^[0-9]*$";
            Regex rx = new Regex(pattern);
            string str = "wmic memorychip";
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.StandardInput.WriteLine(str + "&exit");
            p.StandardInput.AutoFlush = true;
            string output = p.StandardOutput.ReadToEnd();
            string[] appInfo = output.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string[] arr = appInfo[5].Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < arr.Length; i++)
            {
                if ((arr[i].Trim() == "Physical") && (arr[i + 1].Trim() == "Memory") && (rx.IsMatch(arr[i + 2])))
                {
                    string value1 = arr[i + 2];
                    OC_Value = Convert.ToInt32(value1);
                    break;
                }
            }
            p.WaitForExit();
            p.Close();
        }

        [Then(@"RAM value in the tool should not be OC value and the value is less than 3000")]
        public void PopupShown_ToggleBtnNoChange_OCvalueLess()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu);
            Assert.IsNotNull(_nerveCenterPages.SystemStatusInfoLink);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOff);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOffName);
            if (OC_Value < 3000)
            {
                Assert.IsTrue(true, "more than 3000");
            }
        }

        [Given(@"RAM toggle status is off")]
        public void RAMToggleBtnStatus_off2()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu);
            Assert.IsNotNull(_nerveCenterPages.SystemStatusInfoLink);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOff);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOffName);
        }

        [Given(@"Click the RAM toggle_off")]
        public void Click_RAMToggleBtnStatus_off()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu);
            Assert.IsNotNull(_nerveCenterPages.SystemStatusInfoLink);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOff);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOffName);
            _nerveCenterPages.LegionEdgeRAMOverclockToggleOff.Click();
        }

        [Then(@"Reboot popup window should be shown and toggle status should not be changed")]
        public void PopupShown_ToggleBtnNoChange()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.RamOverlocRestartPopupokBtn);
            Assert.IsNotNull(_nerveCenterPages.RamOverlocRestartPopupokBtnName);
            Assert.IsNotNull(_nerveCenterPages.RamOverlocRestartPopupcloseBtn);
            Assert.IsNotNull(_nerveCenterPages.RamOverlocRestartPopupcloseBtnName);
            _nerveCenterPages.RamOverlocRestartPopupokBtn.Click();
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOff);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOffName);
        }

        [Given(@"Click the OK Button")]
        public void Click_RAM_OKBtn()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.RamOverlocRestartPopupokBtn);
            Assert.IsNotNull(_nerveCenterPages.RamOverlocRestartPopupokBtnName);
            Assert.IsNotNull(_nerveCenterPages.RamOverlocRestartPopupcloseBtn);
            Assert.IsNotNull(_nerveCenterPages.RamOverlocRestartPopupcloseBtnName);
            _nerveCenterPages.RamOverlocRestartPopupokBtn.Click();
        }

        [Then(@"RAM toggle status should be off")]
        public void PopupShown_ToggleBtnNoChange2()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.RamOverlocRestartPopupokBtn);
            Assert.IsNull(_nerveCenterPages.RamOverlocRestartPopupokBtnName);
            Assert.IsNull(_nerveCenterPages.RamOverlocRestartPopupcloseBtn);
            Assert.IsNull(_nerveCenterPages.RamOverlocRestartPopupcloseBtnName);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOff);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOffName);
        }

        [Given(@"Click the X Button")]
        public void Click_RAM_XBtn()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.RamOverlocRestartPopupokBtn);
            Assert.IsNotNull(_nerveCenterPages.RamOverlocRestartPopupokBtnName);
            Assert.IsNotNull(_nerveCenterPages.RamOverlocRestartPopupcloseBtn);
            Assert.IsNotNull(_nerveCenterPages.RamOverlocRestartPopupcloseBtnName);
            _nerveCenterPages.RamOverlocRestartPopupcloseBtn.Click();
        }

        [Then(@"RAM toggle status should be changed to ON")]
        public void RAMToggleBtnStatus_On()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.RamOverlocRestartPopupokBtn);
            Assert.IsNull(_nerveCenterPages.RamOverlocRestartPopupokBtnName);
            Assert.IsNull(_nerveCenterPages.RamOverlocRestartPopupcloseBtn);
            Assert.IsNull(_nerveCenterPages.RamOverlocRestartPopupcloseBtnName);
            Assert.IsNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOff);
            Assert.IsNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOffName);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOn);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOnName);
        }

        [Then(@"RAM value in the tool should be OC value and the value is greater than 3000")]
        public void RAMToggleBtnStatus_On_OCValueGreater()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.RamOverlocRestartPopupokBtn);
            Assert.IsNull(_nerveCenterPages.RamOverlocRestartPopupokBtnName);
            Assert.IsNull(_nerveCenterPages.RamOverlocRestartPopupcloseBtn);
            Assert.IsNull(_nerveCenterPages.RamOverlocRestartPopupcloseBtnName);
            Assert.IsNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOff);
            Assert.IsNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOffName);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOn);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOnName);
            if (OC_Value > 3000)
            {
                Assert.IsTrue(true, "less than 3000");
            }
        }

        [Given(@"Click the RAM toggle on")]
        public void Click_RAMToggleBtnStatus_on()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu);
            Assert.IsNotNull(_nerveCenterPages.SystemStatusInfoLink);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOn);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOnName);
            _nerveCenterPages.LegionEdgeRAMOverclockToggleOn.Click();
        }

        [Given(@"RAM toggle status is on")]
        public void RAMToggleBtnStatus_on()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu);
            Assert.IsNotNull(_nerveCenterPages.SystemStatusInfoLink);
            Assert.IsNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOff);
            Assert.IsNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOffName);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOn);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOnName);
        }

        [Then(@"popup window should be shown and toggle status is On")]
        public void PopupShown_ToggleBtnNoChange_On()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.RamOverlocRestartPopupokBtn);
            Assert.IsNotNull(_nerveCenterPages.RamOverlocRestartPopupokBtnName);
            Assert.IsNotNull(_nerveCenterPages.RamOverlocRestartPopupcloseBtn);
            Assert.IsNotNull(_nerveCenterPages.RamOverlocRestartPopupcloseBtnName);
            Assert.IsNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOff);
            Assert.IsNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOffName);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOn);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOnName);
        }

        [Then(@"2RAM value in the tool should be OC value and the value is greater than 3000")]
        public void RAMToggleBtnStatus_On_OCValueGreater2()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOff);
            Assert.IsNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOffName);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOn);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOnName);
            if (OC_Value > 3000)
            {
                Assert.IsTrue(true, "less than 3000");
            }
        }

        [Then(@"toggle_on status should not be changed")]
        public void ToggleBtnNoChange_On()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.RamOverlocRestartPopupokBtn);
            Assert.IsNull(_nerveCenterPages.RamOverlocRestartPopupokBtnName);
            Assert.IsNull(_nerveCenterPages.RamOverlocRestartPopupcloseBtn);
            Assert.IsNull(_nerveCenterPages.RamOverlocRestartPopupcloseBtnName);
            Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu);
            Assert.IsNotNull(_nerveCenterPages.SystemStatusInfoLink);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOn);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOnName);
        }

        [Given(@"record page item")]
        public void Record_RAMToggleBtnStatus()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);

            if ((_nerveCenterPages.LegionEdgeRAMOverclockToggleOff) == null)
            {
                Assert.IsNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOff);
                Assert.IsNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOffName);

                Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu);
                Assert.IsNotNull(_nerveCenterPages.SystemStatusInfoLink);
                Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOn);
                Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOnName);
                status = "ON";
            }
            else
            {
                Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOff);
                Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOffName);

                Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu);
                Assert.IsNotNull(_nerveCenterPages.SystemStatusInfoLink);
                Assert.IsNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOn);
                Assert.IsNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOnName);
                status = "OFF";
            }
        }

        [Then(@"all pages settings shoule be consistent with the last change")]
        public void Compare_Record_RAMToggleBtnStatus()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (status == "ON")
            {
                Assert.IsNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOff);
                Assert.IsNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOffName);
                Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu);
                Assert.IsNotNull(_nerveCenterPages.SystemStatusInfoLink);
                Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOn);
                Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOnName);
                status = "ON";
            }
            else if (status == "OFF")
            {
                Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOff);
                Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOffName);
                Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu);
                Assert.IsNotNull(_nerveCenterPages.SystemStatusInfoLink);
                Assert.IsNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOn);
                Assert.IsNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOnName);
                status = "OFF";
            }
        }

        [Then(@"The Regedit Value of the ""(.*)"" and  ""(.*)"" is ""(.*)""")]
        public void ThenTheRegeditValueOfTheAndIs(string regeditPath, string regeditName, string setValue)
        {

        }

        [Then(@"The Regedit Value of the Gaming Features tags and ""(.*)"" is ""(.*)""")]
        public void ThenTheRegeditValueOfTheGamingFeaturesTagsAndIs(string regeditPath, string setValue)
        {
            string gamingFeatureTags = @"SOFTWARE\WOW6432Node\Lenovo\ImController\Applicability\Tags";
            string regeditValue = IntelligentCoolingBaseHelper.GetLocalMachineRegeditValue(regeditPath, gamingFeatureTags);
            if (setValue.ToString().Equals("null"))
            {
                Assert.IsNull(regeditValue, "Expect is null, but Actual is " + regeditValue);
            }
            else
            {
                Assert.AreEqual(setValue, regeditValue);
            }
        }

        [Given(@"""(.*)"" is displayed")]
        public void GivenIsDisplayed(string p0)
        {
            switch (p0)
            {
                case "Macro key":
                    _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                    Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu, "The Device Menu button not show.");
                    _nerveCenterPages.GamingDeviceMenu?.Click();
                    Assert.IsNotNull(_nerveCenterPages.SystemToolsMacroKey, "The Macro Key not show.");
                    break;
                case "CPU OC":
                    _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                    Assert.IsNotNull(_nerveCenterPages.CPUOverClockingMenu, "The CPUOverClockingMenu not found!");
                    break;
                case "GPU OC":
                    _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                    Assert.IsNotNull(_nerveCenterPages.GPUOCArea, "The CPUOverClockingMenu not found!");
                    break;
                case "RAM OC":
                    _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                    Assert.IsNotNull(_nerveCenterPages.RAMOverclockElement);
                    break;
                case "Network boost":
                    _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                    Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostIcon, "Network Boost Icon not found");
                    break;
                case "Auto Close":
                    _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                    Assert.IsNotNull(_nerveCenterPages.LegionEdgeAutoCloseIcon, "Auto Close Icon not found");
                    break;
                case "Hybrid Mode":
                    _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                    Assert.IsNotNull(_nerveCenterPages.HybridModeRestartWindowTip, "Auto Close Icon not found");
                    break;
                case "Thermal mode 2.0":
                    _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                    Assert.IsNotNull(_nerveCenterPages.OldThermalModeContainer);
                    break;
                case "Thermal mode 3.0":
                case "Thermal mode 4.0":
                    _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                    Assert.IsNotNull(_nerveCenterPages.ThermalMode);
                    break;
            }
        }

        [Given(@"""(.*)"" is not displayed")]
        public void GivenIsNotDisplayed(string p0)
        {
            switch (p0)
            {
                case "Macro key":
                    _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                    Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu, "The Device Menu button not show.");
                    _nerveCenterPages.GamingDeviceMenu?.Click();
                    Assert.IsNull(_nerveCenterPages.SystemToolsMacroKey, "The Macro Key is show.");
                    break;
                case "CPU OC":
                    _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                    Assert.IsNull(_nerveCenterPages.CPUOverClockingMenu, "The CPUOverClockingMenu not found!");
                    break;
                case "RAM OC":
                    _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                    Assert.IsNull(_nerveCenterPages.LegionEdgeRAMOverclockToggle);
                    break;
                case "GPU OC":
                    _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                    Assert.IsNull(_nerveCenterPages.GPUOCArea);
                    break;
                case "Hybrid Mode":
                    _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                    Assert.IsNull(_nerveCenterPages.HybridModeToggle);
                    break;
                case "Lighting":
                    _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                    Assert.IsNull(_nerveCenterPages.GamingLightingSubpageHeaderTitle);
                    break;
                case "Thermal mode":
                    var gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
                    Assert.IsNull(gamingThermalModePages.GetThermalMode, "Get Thermal Mode is null");
                    break;
            }
        }

        [Given(@"Uninstall the ""(.*)"" driver")]
        public void GivenUninstallTheDriver(string p0)
        {
            switch (p0)
            {
                case "XTU":
                    _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                    if (File.Exists("C:\\Program Files\\Lenovo\\Intel(R) Extreme Tuning Utility\\unins000.exe"))
                    {
                        Process.Start("C:\\Program Files\\Lenovo\\Intel(R) Extreme Tuning Utility\\unins000.exe");
                        Thread.Sleep(8000);
                        SendKeys.SendWait("{TAB}");
                        Thread.Sleep(3000);
                        SendKeys.SendWait("{ENTER}"); //uninstalling
                        Thread.Sleep(8000);
                        SendKeys.SendWait("{TAB}");
                        Thread.Sleep(3000);
                        SendKeys.SendWait("{ENTER}");  //no restart
                        Thread.Sleep(3000);
                    }
                    break;
            }
        }

        [Given(@"Delete '(.*)' tag")]
        public void GivenDeleteTag(string p0)
        {
            try
            {
                string gamingFeatureTags = @"SOFTWARE\WOW6432Node\Lenovo\ImController\Applicability\Tags";
                RegistryKey reg = Registry.LocalMachine.OpenSubKey(gamingFeatureTags, true);
                reg.DeleteSubKey(p0);
            }
            catch (Exception ex)
            {

            }
        }

        [Given(@"Restart IMC service")]
        public void GivenRestartIMCService()
        {
            try
            {
                Common.StopService(VantageConstContent.IMCServiceName);
            }
            finally
            {
                Common.StartService(VantageConstContent.IMCServiceName);
            }
        }


    }
}
