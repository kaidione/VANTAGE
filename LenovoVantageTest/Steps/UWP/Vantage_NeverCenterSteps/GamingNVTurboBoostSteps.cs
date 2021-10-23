using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingNVTurboBoostSteps : VantageBase
    {
        private InformationalWebDriver _webDriver;
        private string _vendorId = string.Empty;
        private string _deviceId = string.Empty;
        private string _tgpValue = string.Empty;
        private string _temperatureValue = string.Empty;

        public GamingNVTurboBoostSteps(InformationalWebDriver appDriver)
        {
            this._webDriver = appDriver;
        }

        [Given(@"Get The Graphics Card ""(.*)"" Id Is ""(.*)""")]
        public void GivenGetTheGraphicsCardIdIIs(string p0, string p1)
        {
            string deviceId = string.Empty;
            string vendorId = string.Empty;
            string graphicsResult = string.Empty;
            GetGraphicsCardHardwareIds(p0, out vendorId, out deviceId, out graphicsResult);
            Assert.IsTrue(graphicsResult != string.Empty, "The hardware Ids information is empty.");
            if (p0 == "Vendor")
            {
                _vendorId = Convert.ToInt32(vendorId, 16).ToString();
                Assert.IsTrue(p1 == _vendorId, p0 + " Id is " + p1 + ", but " + vendorId + " in actual.");
            }
            else if (p0 == "Device")
            {
                _deviceId = Convert.ToInt32(deviceId, 16).ToString();
                Assert.IsTrue(p1 == _deviceId, p0 + " Id is " + p1 + ", but " + deviceId + " in actual.");
            }
            else
            {
                Assert.Fail("Please input Vendor or Device.");
            }
        }

        [Given(@"Get Bios Value From NV Turbo Boost Bios Tool")]
        public void GivenGetBiosValueFromNVTurboBoostBiosTool()
        {
            string biosResult = DesktopPowerManagementHelper.RunCmd("powershell.exe -command \"" + VantageConstContent.NVTurboBoostPath + "\"");
            string[] resultLine = biosResult.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string[] resultColumn;
            List<string> deviceIdList = new List<string>();
            List<string> vendorIdList = new List<string>();
            List<string> idList = new List<string>();
            List<string> thermalModeList = new List<string>();
            List<string> valueList = new List<string>();

            for (int i = 0; i < resultLine.Length; i++)
            {
                resultColumn = resultLine[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (resultLine[i].Contains(_vendorId) || resultLine[i].Contains(_deviceId))
                {
                    vendorIdList.Add(resultColumn[0]);
                    deviceIdList.Add(resultColumn[1]);
                    idList.Add(resultColumn[2]);
                    thermalModeList.Add(resultColumn[3]);
                    valueList.Add(resultColumn[4]);
                }
            }
        }

        [Then(@"""(.*)"" Value Should Be ""(.*)"" In ""(.*)""")]
        public void GivenValueShouldBeIn(string p0, string p1, string p2)
        {
            string biosResult = DesktopPowerManagementHelper.RunCmd("powershell.exe -command \"" + VantageConstContent.NVTurboBoostPath + "\"");
            string[] resultLine = biosResult.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string[] resultColumn;
            string value = string.Empty;

            for (int i = 0; i < resultLine.Length; i++)
            {
                resultColumn = resultLine[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //result column: 0-vendor id, 1-device id, 2-id, 3-thermal mode, 4-value
                if (resultColumn.Length > 1 && _vendorId == resultColumn[0].Trim() && VantageConstContent.IdMap[p0] == resultColumn[2].Trim() && VantageConstContent.ThermalModeMap[p2] == resultColumn[3].Trim())
                {
                    value = resultColumn[4].Trim();
                }
                else if (resultColumn.Length > 1 && _deviceId == resultColumn[1].Trim() && VantageConstContent.IdMap[p0] == resultColumn[2].Trim() && VantageConstContent.ThermalModeMap[p2] == resultColumn[3].Trim())
                {
                    value = resultColumn[4].Trim();
                }
            }
            if (p0 == "TGP")
            {
                _tgpValue = value;
                Assert.IsTrue(p1 == _tgpValue, p0 + " value should be " + p1 + " in " + p2 + ", but " + _tgpValue + " in actual.");
            }
            else if (p0 == "Temperature")
            {
                _temperatureValue = value;
                Assert.IsTrue(p1 == _temperatureValue, p0 + " value should be " + p1 + " in " + p2 + ", but " + _temperatureValue + " in actual.");
            }
            else
            {
                Assert.Fail("Please input TGP or Temperature to verify.");
            }
        }

        [Then(@"""(.*)"" Value Should Not Be Changed")]
        public void ThenValueShouldNotBeChanged(string p0)
        {
            string biosResult = DesktopPowerManagementHelper.RunCmd("powershell.exe -command \"" + VantageConstContent.GPUThermalSettingTestPath + " get\"");
            string[] resultLine = biosResult.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string tgpValue = string.Empty;
            string temperatureValue = string.Empty;

            for (int i = 0; i < resultLine.Length; i++)
            {
                //get current TGP target value
                if (resultLine[i].Contains("=") && resultLine[i].Contains(p0) && p0 == "TGP")
                {
                    tgpValue = resultLine[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                }
                //get current Temperature target value
                if (resultLine[i].Contains("=") && resultLine[i].Contains(p0) && p0 == "Temperature")
                {
                    temperatureValue = resultLine[i].Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries)[1].Trim();
                }
            }
            if (p0 == "TGP")
            {
                Assert.IsTrue(tgpValue == _tgpValue, p0 + " value should be " + _tgpValue + ", but " + tgpValue + " in actual.");
            }
            else if (p0 == "Temperature")
            {
                Assert.IsTrue(temperatureValue == _temperatureValue, p0 + " value should be " + _temperatureValue + ", but " + temperatureValue + " in actual.");
            }
            else
            {
                Assert.Fail("Please input TGP or Temperature.");
            }
        }

    }
}
