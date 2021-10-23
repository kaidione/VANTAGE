using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class SettingsSealedBatteryWarrantySteps : SettingsBase
    {
        private static InformationalWebDriver _webDriver;
        private HSPowerSettingsPage _hSPowerSettingsPage;
        private static string VantageServiceName = "LenovoVantageService";
        private static string IMCServiceName = "ImControllerService";
        static private string fileSmbRegedit = @"SOFTWARE\WOW6432Node\Lenovo\VantageService";
        public static string RegistrySB00 = @"HKCU\SOFTWARE\Lenovo\ImController\PluginData\IdeaNotebookPlugin\SmartBatteryV2";
        private IntelligentCoolingPages _intelligentcoolingPages;
        WindowsDriver<WindowsElement> desktopSession;

        public SettingsSealedBatteryWarrantySteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [BeforeFeature("TestSealedWarrnty")]
        public static void BeforeTestSealed()
        {
            GivenModifyingTheServiceFileSmbValue("Add");
            GivenModifyingIdeaNotbookPluginToTestingVersion("ForTesting");
            Common.RestartService(IMCServiceName);
            Common.RestartService(VantageServiceName);
        }

        [AfterFeature("TestSealedWarrnty")]
        public static void AfterTestSealed()
        {
            GivenModifyingTheServiceFileSmbValue("Delete");
            GivenModifyingIdeaNotbookPluginToTestingVersion("Staging");
            GivenDeleteLenovoVantageSMBInfoJsonFileAndDeleteRegeditSmartBatteryV2();
            Common.RestartService(IMCServiceName);
            Common.RestartService(VantageServiceName);
        }

        [Given(@"Modifying the Service fileSmb Value (Add|Delete)")]
        public static void GivenModifyingTheServiceFileSmbValue(string modify)
        {
            if (modify.Equals("Add"))
            {
                string regeditValue = IntelligentCoolingBaseHelper.GetLocalMachineRegeditValue("fileSmb", fileSmbRegedit);
                if (string.IsNullOrEmpty(regeditValue))
                {
                    IntelligentCoolingBaseHelper.CreateLocalMachineSubKey("fileSmb", fileSmbRegedit, "true");
                }
            }
            else
            {
                string regeditValue = IntelligentCoolingBaseHelper.GetLocalMachineRegeditValue("fileSmb", fileSmbRegedit);
                if (!string.IsNullOrEmpty(regeditValue))
                {
                    RegistryHelp.DeleteRegistrySubKey(@"hklm\SOFTWARE\WOW6432Node\Lenovo\VantageService");
                }
            }
        }

        [Given(@"Modifying IdeaNotbookPlugin to (ForTesting|Staging) Version")]
        public static void GivenModifyingIdeaNotbookPluginToTestingVersion(string targetPlugin)
        {
            string sourcePluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\TestData\IdeaNotBookPlugin");
            string sourcePlugin;
            if (targetPlugin.Equals("ForTesting"))
            {
                sourcePlugin = Path.Combine(sourcePluginPath, @"ForTesting");
            }
            else
            {
                sourcePlugin = Path.Combine(sourcePluginPath, @"Staging");
            }
            SmartStandbyTestSteps ss = new SmartStandbyTestSteps(_webDriver);
            ss.CopyFolder(sourcePlugin, @"C:\ProgramData\Lenovo\ImController\Plugins");
        }

        [Given(@"Delete lenovo vantage SMBInfo json file And Delete regedit SmartBatteryV2")]
        public static void GivenDeleteLenovoVantageSMBInfoJsonFileAndDeleteRegeditSmartBatteryV2()
        {
            if (RegistryHelp.IsRegistrySubKeyExist(RegistrySB00))
            {
                RegistryHelp.DeleteRegistrySubKey(RegistrySB00);
            }
            string fileName = @"C:\ProgramData\Lenovo\Vantage\SMBInfo.json";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        [StepDefinition(@"Restart Vantage Service")]
        public void WhenRestartVantageService()
        {
            Common.RestartService(VantageServiceName);
        }

        [When(@"Modify the SMBinfor file with (.*) and (.*)")]
        public void WhenModifyTheSMBinforFileWithSMBInfoAnd(string SMBinfor, string SoH)
        {
            //Copy target Config
            string fileName = SMBinfor + ".json";
            string SmbInfo;
            string packeageName = string.Format("Packages\\{0}\\LocalState\\config.json", VantageConstContent.GetVantageUwpAppName() + "_k1h2ywk1493x8");
            string context = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), packeageName));
            if (context.ToLower().Contains("\"env\": \"qa2\","))
            {
                SmbInfo = @"Data\TestData\SMBInfoqa2";
            }
            else
            {
                SmbInfo = @"Data\TestData\SMBInfoprod";
            }
            string sourceSMBPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SmbInfo, fileName);
            string dest = Path.Combine(@"C:\ProgramData\Lenovo\Vantage", "SMBInfo.json");
            File.Copy(sourceSMBPath, dest, true);
            if (SoH == "SB00")
            {
                if (RegistryHelp.IsRegistrySubKeyExist(RegistrySB00))
                {
                    RegistryHelp.DeleteRegistrySubKey(RegistrySB00);
                }
            }
            else
            {
                //Set target SoH Value
                string regFileName = SoH + ".reg";
                string regPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SmbInfo, regFileName);
                regPath = @"""" + regPath + @"""";
                Process.Start("regedit", string.Format(" /s {0}", regPath));
            }
        }


        [Then(@"The Sealed Warranty feature will be (Displayed|Hidden)")]
        public void ThenTheSealedWarrantyFeatureWillBe(string status)
        {
            if (status == "Displayed")
            {
                _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
                Assert.NotNull(_hSPowerSettingsPage.SealedBatteryWarrantyTitle);
            }
            else
            {
                _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
                Assert.Null(_hSPowerSettingsPage.SealedBatteryWarrantyTitle);
            }
        }

        [Then(@"The Battery Warranty value and Tip should follow the SPEC")]
        public void ThenTheBatteryWarrantyValueAndTipShouldFollowTheSPEC(Table table)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string SealedBatteryWarranty = table.Rows[i][1];
                _hSPowerSettingsPage.SealedBatteryWarrantyName = SealedBatteryWarranty;
                Assert.IsNotNull(_hSPowerSettingsPage.SealedBatteryWarrantyElement, SealedBatteryWarranty + " is null");
                Assert.AreEqual(table.Rows[i][1], _hSPowerSettingsPage.SealedBatteryWarrantyElement.Text, SealedBatteryWarranty + " desc incorect.");
            }
        }

        [Then(@"The EXPLORE MORE Button Displayed and under the Value Tip")]
        public void ThenTheEXPLOREMOREButtonDisplayedAndUnderTheValueTip()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsTrue(_hSPowerSettingsPage.ExploreMoreButton.Location.Y > _hSPowerSettingsPage.BatteryWarrantyTip.Location.Y, "ExploreMoreButton location is not under the BatteryWarrantyTip Element");
            Assert.IsTrue(_hSPowerSettingsPage.BatteryWarrantyTip.Location.Y > _hSPowerSettingsPage.BatteryWarrantyTitle.Location.Y, "BatteryWarrantyTip location is not under BatteryWarrantyValue Element");

        }

        [Then(@"GetResponse from BatteryWarranty Restful API with '(.*)' and '(.*)' and '(.*)' Type (.*)")]
        public void ThenGetResponseFromBatteryWarrantyRestfulAPIWithAndAndSMBInfo1SB60(string snCode, string mtmCode, int sohValue, string status)
        {
            string targetURL = @"https://uatpcsupport.lenovo.com/api/v4/upsell/catalog/getSBTY?sn=" + snCode + @"&mtm=" + mtmCode + @"&soh=" + sohValue;
            string requestResult = GetInfo(targetURL);
            JObject obj = Newtonsoft.Json.Linq.JObject.Parse(requestResult);
            string freSpaceNumq = obj["data"]["sbty"]["status"].ToString();
            string end = obj["data"]["sbty"]["end"].ToString();
            string remainingMonths = obj["data"]["sbty"]["remainingMonths"].ToString();
            switch (status)
            {
                case "SMBInfo1SB60":
                    Assert.AreEqual(freSpaceNumq, "", "xml data-sbty-status is not null");
                    break;
                case "SMBInfo3SB00":
                    //check API data sbty start value and end value
                    Startimeendtime(obj);
                    //endtime value < system datetime
                    Assert.IsTrue(CompanyDate(end) < 0, "endtime should be < datatime but " + end + ">=" + DateTime.Now.ToString("yyyy-MM-dd"));
                    break;
                case "SMBInfo4SB90":
                    //check API data sbty start value and end value
                    Startimeendtime(obj);
                    //endtime value < system datetime
                    Assert.IsTrue(CompanyDate(end) > 0, "endtime should be > datatime but " + end + "<" + DateTime.Now.ToString("yyyy-MM-dd"));
                    break;
                case "SMBInfoiframe1SB60":
                    //check sbty start value and end value
                    Startimeendtime(obj);
                    break;
                case "SMBInfo2SB90":
                    //check sbty remianingMonths value from API returns
                    RemainingMonthValue(obj, remainingMonths, _hSPowerSettingsPage.WarrantyDetails.Text, "sealedbatteryWarrantyRemainingMonth");
                    //check warranty dutation value is more than or equal to sbty duration value
                    int warrantyduration = (int)obj["data"]["warranty"]["duration"];
                    int sbtyduration = (int)obj["data"]["sbty"]["duration"];
                    Assert.IsTrue(warrantyduration > sbtyduration, "result warrantyduration < sbtyduration shoule be warrantyduration >= sbtyduration");
                    //check sbty end value from API returns
                    string endvalue = end.Substring(5, 2) + "/" + end.Substring(8, 2) + "/" + end.Substring(0, 4);
                    Assert.AreEqual(endvalue, _hSPowerSettingsPage.WarrantyEndDate.Text, "API end value is different");
                    break;
                case "SMBInfoNull":
                    Assert.AreEqual(freSpaceNumq, "", "xml data-sbty-status is not null");
                    Assert.AreEqual(obj["data"]["sbty"]["upgrade"].ToString(), "[]", "xml data-sbty-status is not null");
                    break;
                case "BatteryWarrantySettingsUI":
                    //warrantyMonths SPEC UI
                    RemainingMonthValue(obj, obj["data"]["sbty"]["duration"].ToString(), _hSPowerSettingsPage.BatteryWarrantyDurationMonthValue.Text, "batteryWarrantyMonths");
                    //warrantyremainingMonths SPEC UI
                    if (snCode == "PF2E1ZCH")
                    {
                        RemainingMonthValue(obj, remainingMonths, _hSPowerSettingsPage.BatteryWarrantyTimeRemainingValue.Text, "batteryWarrantyRemainingMonth");
                    }
                    else
                    {
                        RemainingMonthValue(obj, remainingMonths, _hSPowerSettingsPage.BatteryWarrantyTimeRemainingValue.Text, "sealedbatteryWarrantyRemainingMonth");
                    }
                    //starttime endtime SPEC UI
                    string start = obj["data"]["sbty"]["start"].ToString();
                    string startvalue = start.Substring(5, 2) + "/" + start.Substring(8, 2) + "/" + start.Substring(0, 4);
                    Assert.AreEqual(startvalue, _hSPowerSettingsPage.BatteryWarrantyStartDateValue.Text, "API start value is different");
                    string endvalues = end.Substring(5, 2) + "/" + end.Substring(8, 2) + "/" + end.Substring(0, 4);
                    Assert.AreEqual(endvalues, _hSPowerSettingsPage.BatteryWarrantyEndDateValue.Text, "API start value is different");
                    if (freSpaceNumq == "active")
                    {
                        Assert.AreEqual(freSpaceNumq.Replace("active", "(active)"), _hSPowerSettingsPage.BatteryWarrantyDurationStatus.Text, "API duration status value is different");
                    }
                    else
                    {
                        Assert.AreEqual(freSpaceNumq.Replace("OOW", "(expired)"), _hSPowerSettingsPage.BatteryWarrantyDurationStatus.Text, "API duration status value is different");
                    }
                    break;
            }
        }
        public void RemainingMonthValue(JObject obj, string remainingMonths, string WarrantyDetails, string p0)
        {
            if (WarrantyDetails.ToString().IndexOf(" ") == 1)
            {
                string WarrantyDetailstext = WarrantyDetails.ToString().Substring(0, 1);
                switch (p0)
                {
                    case "sealedbatteryWarrantyRemainingMonth":
                        Assert.AreEqual(remainingMonths, WarrantyDetailstext, "xml data-sbty-remainingMonths is different");
                        Assert.AreEqual(WarrantyDetails.Substring(2), "months remaining", "xml data-sbty-remainingMonths is different");
                        break;
                    case "batteryWarrantyRemainingMonth":
                        Assert.AreEqual(remainingMonths, WarrantyDetailstext, "xml data-sbty-remainingMonths is different");
                        Assert.AreEqual(WarrantyDetails.Substring(2), "month remaining", "xml data-sbty-remainingMonths is different");
                        break;
                    case "batteryWarrantyMonths":
                        Assert.AreEqual(remainingMonths, WarrantyDetailstext, "xml data-sbty-duration is different");
                        Assert.AreEqual(WarrantyDetails.Substring(2), "months", "xml data-sbty-duration is different");
                        break;
                }
            }
            else
            {
                string WarrantyDetailstext = WarrantyDetails.ToString().Substring(0, 2);
                switch (p0)
                {
                    case "sealedbatteryWarrantyRemainingMonth":
                        Assert.AreEqual(remainingMonths, WarrantyDetailstext, "xml data-sbty-remainingMonths is different");
                        Assert.AreEqual(WarrantyDetails.Substring(3), "months remaining", "xml data-sbty-remainingMonths is different");
                        break;
                    case "batteryWarrantyRemainingMonth":
                        Assert.AreEqual(remainingMonths, WarrantyDetailstext, "xml data-sbty-remainingMonths is different");
                        Assert.AreEqual(WarrantyDetails.Substring(3), "month remaining", "xml data-sbty-remainingMonths is different");
                        break;
                    case "batteryWarrantyMonths":
                        Assert.AreEqual(remainingMonths, WarrantyDetailstext, "xml data-sbty-duration is different");
                        Assert.AreEqual(WarrantyDetails.Substring(3), "months", "xml data-sbty-duration is different");
                        break;
                }
            }
        }
        public void Startimeendtime(JObject obj)
        {
            string start = obj["data"]["sbty"]["start"].ToString();
            string startvalue = start.Substring(5, 2) + "/" + start.Substring(8, 2) + "/" + start.Substring(0, 4) + " ";
            string end = obj["data"]["sbty"]["end"].ToString();
            string endvalue = " " + end.Substring(5, 2) + "/" + end.Substring(8, 2) + "/" + end.Substring(0, 4);
            List<string> WarrantyDateInfo = WarrantyDateInfodate();
            Assert.AreEqual(startvalue, WarrantyDateInfo[0], "API start value is different");
            Assert.AreEqual(endvalue, WarrantyDateInfo[1], "API end value is different");
        }

        /// <summary>
        /// 将WarrantyDateInfo日期放到集合里
        /// </summary>
        public List<string> WarrantyDateInfodate()

        {
            List<string> WarrantyDateInfo = new List<string>();
            string[] sArray = _hSPowerSettingsPage.WarrantyDateInfo.Text.Split('-');
            foreach (string i in sArray)
            {
                WarrantyDateInfo.Add(i.ToString());
            }
            return WarrantyDateInfo;
        }

        /// <summary>
        /// 比较两个日期大小
        /// </summary>
        /// <param name="endtime">End日期</param>
        public int CompanyDate(string endtime)
        {
            //获取系统时间给定格式
            string datetime = DateTime.Now.ToString("yyyy-MM-dd");
            //将日期字符串转换为日期对象
            DateTime t1 = Convert.ToDateTime(endtime);
            DateTime t2 = Convert.ToDateTime(datetime);
            //通过DateTIme.Compare()进行比较（）
            int compNum = DateTime.Compare(t1, t2);
            return compNum;
        }

        /// <summary>  
        /// 获取url的返回值  
        /// </summary>  
        /// <param name="url"> </param>  
        public string GetInfo(string url)
        {
            string strBuff = "";
            Uri httpURL = new Uri(url);
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(httpURL);
            HttpWebResponse httpResp = (HttpWebResponse)httpReq.GetResponse();
            Stream respStream = httpResp.GetResponseStream();
            StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
            strBuff = respStreamReader.ReadToEnd();
            return strBuff;
        }

        [When(@"Click The Question Mark")]
        public void WhenClickTheQuestionMark()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.QuestionMarklink, "The QuestionMarklink not found");
            _hSPowerSettingsPage.QuestionMarklink.Click();
        }

        [When(@"Click The EXPLORE MORE Button")]
        public void WhenClickTheEXPLOREMOREButton()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.ExploreMoreButton, "The ExploreMoreButton not found");
            _hSPowerSettingsPage.ExploreMoreButton.Click();
        }

        [Then(@"It Will Show Iframe (.*)")]
        public void ThenItWillShowIframeWithOnlyDeviceWarrantyAndAddon(string status)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            //判断 contitune
            if (_hSPowerSettingsPage.Continue != null)
            {
                _hSPowerSettingsPage.Continue.Click();
            }
            switch (status)
            {
                case "Upgrade Support & Service":
                    Assert.IsNotNull(_hSPowerSettingsPage.UpgradeSupportService, "The UpgradeSupportService not found");
                    break;
                case "Lenovo Premium Service":
                    Assert.IsNotNull(_hSPowerSettingsPage.LenovoPremiumService, "The LenovoPremiumService not found");
                    break;
                case "Sealed Battery (SB)":
                    Assert.IsNotNull(_hSPowerSettingsPage.SealedBatterySB, "The SealedBatterySB not found");
                    break;
                case "Sealed Battery Warranty":
                    Assert.IsNotNull(_hSPowerSettingsPage.SealedBatteryWarranty, "The SealedBatteryWarranty not found");
                    break;
                case "Lenovo Warranty":
                    Assert.IsNotNull(_hSPowerSettingsPage.LenovoWarranty, "The SealedBatteryWarranty not found");
                    break;
                case "Sealed Battery":
                    Assert.IsNotNull(_hSPowerSettingsPage.SealedBattery, "The SealedBatteryWarranty not found");
                    break;

            }
        }

        [Then(@"The UI should be displayed within (.*) seconds when (.*) launch")]
        public void ThenTheUIShouldBeDisplayedWithinSecondsWhenSecondLaunch(int p0, string type)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Assert.NotNull(_hSPowerSettingsPage.SealedBatteryWarrantyTitle, "The SealedBatteryWarrantyTitle not found");
            Assert.NotNull(_hSPowerSettingsPage.BatteryWarrantyTitle, "The BatteryWarrantyTitle not found");
            Assert.NotNull(_hSPowerSettingsPage.ExploreMoreButton, "The BatteryWarrantyTip not found");
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            double spendTime = ts.TotalSeconds;
            Assert.LessOrEqual(spendTime, p0, "The UI should show completely in " + p0 + " seconds when " + type + " launch");
        }

        [Then(@"Click More Button")]
        public void ThenClickMoreButton()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hSPowerSettingsPage.BatteryWarrantyMore, "The BatteryWarrantyMore not found");
            _hSPowerSettingsPage.BatteryWarrantyMore.Click();
        }

        [Then(@"No More Button Show Less Button")]
        public void ThenNoMoreButtonShowLessButton()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNull(_hSPowerSettingsPage.BatteryWarrantyMore, "The BatteryWarrantyMore not found");
            Assert.NotNull(_hSPowerSettingsPage.BatteryWarrantyLess, "The BatteryWarrantyLess not found");
        }

        [Then(@"Click Less Button")]
        public void ThenClickLessButton()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hSPowerSettingsPage.BatteryWarrantyLess, "The BatteryWarrantyLess not found");
            _hSPowerSettingsPage.BatteryWarrantyLess.Click();
        }

        [Then(@"No Less Button Show More Button")]
        public void ThenNoLessButtonShowMoreButton()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hSPowerSettingsPage.BatteryWarrantyMore, "The BatteryWarrantyMore not found");
            Assert.IsNull(_hSPowerSettingsPage.BatteryWarrantyLess, "The BatteryWarrantyLess not found");
        }

        [Then(@"Click Warranty and Protection")]
        public void ThenClickWarrantyAndProtection()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hSPowerSettingsPage.WarrantyAndProtection, "The BatteryWarrantyMore not found");
            _hSPowerSettingsPage.WarrantyAndProtection.Click();
        }

        [Then(@"Click Contact Us")]
        public void ThenClickContactUs()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hSPowerSettingsPage.SealedBatteryWarrantyNote, "The SealedBatteryWarrantyNote not found");
            Assert.AreEqual("Contact Us", _hSPowerSettingsPage.SealedBatteryWarrantyNote.GetAttribute("Name").ToString(), "SealedBatteryWarrantyNote desc incorect.");
            _hSPowerSettingsPage.SealedBatteryWarrantyNote.Click();
        }

        [Then(@"The Power Warranty feature will be (Displayed|Hidden)")]
        public void ThenThePowerWarrantyFeatureWillBe(string status)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            if (status == "Displayed")
            {
                Assert.NotNull(_hSPowerSettingsPage.PowerBatteryWarrantyTitle);
            }
            else
            {
                Assert.IsNull(_hSPowerSettingsPage.PowerBatteryWarrantyTitle);
            }
        }

        [Then(@"Click '(.*)' It Will Launch A Website")]
        public void ThenClickItWillLaunchAWebsite(string p0)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            desktopSession = _intelligentcoolingPages.GetControlPanelSession(true);
            if (p0 == "Contact Us")
            {
                WindowsElement ContactUs = _intelligentcoolingPages.FindElementByTimes(desktopSession, "Name", "Contact Us", 60);
                Assert.IsNotNull(ContactUs, "Element 'ContactUs' Is Not Found");
            }
            else
            {
                WindowsElement ServicesSolutions = _intelligentcoolingPages.FindElementByTimes(desktopSession, "Name", "SERVICES & SOLUTIONS", 60);
                Assert.IsNotNull(ServicesSolutions, "Element 'ServicesSolutions' Is Not Found");
            }
        }

        [Then(@"The Battery Warranty Settings value and Tip should follow the SPEC")]
        public void ThenTheBatteryWarrantySettingsValueAndTipShouldFollowTheSPEC(Table table)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                _hSPowerSettingsPage.BatteryWarrantySettings = table.Rows[i][1];
                Assert.IsNotNull(_hSPowerSettingsPage.BatteryWarrantySettingsElement, table.Rows[i][2] + " is null");
                Assert.AreEqual(table.Rows[i][2], _hSPowerSettingsPage.BatteryWarrantySettingsElement.Text, table.Rows[i][2] + " desc incorect.");
            }
        }

        [When(@"Click Battery Warranty Question Mark")]
        public void WhenClickBatteryWarrantyQuestionMark()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryWarrantyQuestinonMark, "BatteryWarrantyQuestinonMark is null");
            _hSPowerSettingsPage.BatteryWarrantyQuestinonMark.Click();
        }

        [When(@"Click Battert Settings '(.*)' Button")]
        public void WhenClickBattertSettingsButton(string p0)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.BatterySettingsWarrantyEXPLOREMOREButton, "BatterySettingsWarrantyEXPLOREMOREButton is null");
            _hSPowerSettingsPage.BatterySettingsWarrantyEXPLOREMOREButton.Click();
        }

        [Then(@"The Battery Warranty UI should be displayed within (.*) seconds when (.*) launch")]
        public void ThenTheBatteryWarrantyUIShouldBeDisplayedWithinSecondsWhenFirstLaunch(int p0, string type)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Assert.NotNull(_hSPowerSettingsPage.PowerBatteryWarrantyTitle, "The PowerBatteryWarrantyTitle not found");
            Assert.NotNull(_hSPowerSettingsPage.PowerBatteryWarrantyCaption, "The PowerBatteryWarrantyCaption not found");
            Assert.NotNull(_hSPowerSettingsPage.BatteryWarrantyMore, "The BatteryWarrantyMore not found");
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            double spendTime = ts.TotalSeconds;
            Assert.LessOrEqual(spendTime, p0, "The UI should show completely in " + p0 + " seconds when " + type + " launch");
        }

        [Given(@"Change system language to (.*)")]
        public void GivenChangeSystemLanguageToChina(string p0)
        {
            Language lan = new Language();
            lan.SetALanguageAsFirstOneInLanguageList(p0);
        }

        [Then(@"BatteryWarrantyBendfitText4 And Warranty and Protection shoule be hidden")]
        public void ThenBatteryWarrantyBendfitTex4tAndWarrantyAndProtectionShouleBeHidden()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNull(_hSPowerSettingsPage.BatteryWarrantyDurationStatus, "The BatteryWarrantyDurationStatus not found");
        }

    }
}
