using LenovoVantageTest.Helper;
using LenovoVantageTest.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Threading;

namespace LenovoVantageTest.Pages.Helper
{
    class ProgrammableLogicControllersHelper : SettingsBase
    {
        public static IWebDriver PLCWebDriver = null;
        public static string PLCIniFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\BJ_PLC\\PLC.ini");
        public string PLCProgramOptionPanel = "//*[@id='btn_console']";
        public string PLCProgramOptionPanelTable = "//*[@id='tb_pni']";
        public string PLCProgramRunBtnXpath = "//*[@id='btn_run']";
        public string PLCProgramSettingsBtnXpath = "//*[@id='btn_program']";
        public string PLCProgramDropDownXpath = "//*[@id='rt_sel']";
        public string PLCProgramStatusDropDownXpath = "//*[@id='sel_run']";

        public class PLCInfo
        {
            public string Name { get; set; }
            public string DeviceId { get; set; }
            public PLSOptionsInfo Y00 { get; set; }
            public PLSOptionsInfo Y01 { get; set; }
            public PLSOptionsInfo Y02 { get; set; }
            public PLSOptionsInfo Y03 { get; set; }
            public PLSOptionsInfo Y04 { get; set; }
            public PLSOptionsInfo Y05 { get; set; }
            public PLSOptionsInfo Y06 { get; set; }
            public PLSOptionsInfo Y07 { get; set; }
            public PLSOptionsInfo Y08 { get; set; }
            public PLSOptionsInfo Y09 { get; set; }
            public PLSOptionsInfo Y10 { get; set; }
            public PLSOptionsInfo Y11 { get; set; }
            public PLSOptionsInfo Y12 { get; set; }
            public PLSOptionsInfo Y13 { get; set; }
            public PLSOptionsInfo Y14 { get; set; }
            public PLSOptionsInfo Y15 { get; set; }
        }

        public class PLSOptionsInfo
        {
            public string Name { get; set; }

        }
        public enum PLCStatus
        {
            Start = 0,
            Stop = 1,
            Running = 2,
            Contiune = 3
        }

        public enum PLCOptions
        {
            Z00 = 0,
            Z01 = 1,
            Z02 = 2,
            Z03 = 3,
            Z04 = 4,
            Z05 = 5,
            Z06 = 6,
            Z07 = 7,
            Z08 = 8,
            Z09 = 9,
            Z10 = 10,
            Z11 = 11,
            Z12 = 12,
            Z13 = 13,
            Z14 = 14,
            Z15 = 15,
            Z16 = 16,  //日历定时组，暂时不用
            Z17 = 17  //逻辑控制组，暂时不用
        }

        #region run plc common method

        public void StarPLC(PLCStatus status, int trySelectStstus = 5, int trySetStstus = 5)
        {
            do
            {
                PLCWebDriver = OpenPLCPageFromEdge();
                Thread.Sleep(3000);
                PLCOptions options = (PLCOptions)Enum.Parse(typeof(PLCOptions), GetPLCInfo("Options"));
                if (SetPLCViaProgramSettings(options, status) == false)
                {
                    if (PLCWebDriver != null)
                    {
                        PLCWebDriver.Close();
                    }
                    Common.KillProcess("MicrosoftWebDriver", true);
                    Common.KillProcess("msedge", true);
                    Common.KillProcess("MicrosoftEdge", true);
                    Console.WriteLine("Try StarPLC again..." + trySelectStstus);
                }
                else
                {
                    Console.WriteLine("StarPLC Run Pass!");
                    break;
                }
                trySelectStstus--;
            } while (trySelectStstus > 0);

            do
            {
                IWebElement element = CHSHelper.FindElementByXpathFromWeb(PLCWebDriver, PLCProgramRunBtnXpath);
                element.Click();
                Thread.Sleep(2000);
                IWebElement e = CHSHelper.FindElementByXpathFromWeb(PLCWebDriver, PLCProgramStatusDropDownXpath);
                if (e.Enabled == false)
                {
                    break;
                }
                trySetStstus--;
            } while (trySetStstus > 0);
            Thread.Sleep(5000);
            Common.KillProcess("MicrosoftWebDriver", true);
            Common.KillProcess("msedge", true);
            Common.KillProcess("MicrosoftEdge", true);
        }

        public void StartPLCViaOptionPanel(PLCStatus status, int tryOpenOptionPanel = 5, int trySetStstus = 5)
        {
            do
            {
                PLCWebDriver = OpenPLCPageFromEdge();
                Thread.Sleep(3000);
                PLCOptions options = (PLCOptions)Enum.Parse(typeof(PLCOptions), GetPLCInfo("Options"));
                if (OpenPLCOptionPanel() == false)
                {
                    if (PLCWebDriver != null)
                    {
                        PLCWebDriver.Close();
                    }
                    Common.KillProcess("MicrosoftWebDriver", true);
                    Common.KillProcess("msedge", true);
                    Common.KillProcess("MicrosoftEdge", true);
                    Console.WriteLine("Try StarPLC again..." + tryOpenOptionPanel);
                }
                else
                {
                    if (SetPLCStatus(status, options) == true)
                    {
                        Console.WriteLine("StartPLCViaOptionPanel Run Pass!");
                        break;
                    }
                }
                tryOpenOptionPanel--;
            } while (tryOpenOptionPanel > 0);
            if (PLCWebDriver != null)
            {
                PLCWebDriver.Close();
            }
            Common.KillProcess("MicrosoftWebDriver", true);
            Common.KillProcess("msedge", true);
            Common.KillProcess("MicrosoftEdge", true);
            Thread.Sleep(3000);
        }

        #endregion

        public static IWebDriver OpenPLCPageFromEdge()
        {
            string plcUrl = GetPLCInfo("URL");  // "http://www.zxcun.cn/plc/lmy/index.php?deviceid=004200235234571620303031&rpass=12345678&lpass=";
            //https://developer.microsoft.com/en-us/microsoft-edge/tools/webdriver/
            string webdriverPath = GetPLCInfo("WebDriverPath");
            string webdriverFile = webdriverPath + "\\MicrosoftWebDriver.exe";
            if (!Directory.Exists(webdriverPath))
            {
                Directory.CreateDirectory(webdriverPath);
            }
            if (!File.Exists(webdriverFile))
            {
                string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\BJ_PLC\\" + GetPLCInfo("Version") + "\\MicrosoftWebDriver.exe");
                File.Copy(file, webdriverFile, true);
            }
            IWebDriver webDriver = new EdgeDriver(webdriverPath);
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(plcUrl);
            Thread.Sleep(5000);
            return webDriver;
        }

        #region  StarPLC 

        public bool SetPLCViaProgramSettings(PLCOptions options, PLCStatus status, int trytimes = 10)
        {
            do
            {
                if (PLCWebDriver == null)
                {
                    OpenPLCPageFromEdge();
                }
                Console.WriteLine("Try SetPLCViaProgramSettings >>" + options.ToString() + ":" + status.ToString());
                IWebElement element = CHSHelper.FindElementByXpathFromWeb(PLCWebDriver, PLCProgramSettingsBtnXpath);
                element.Click();
                Thread.Sleep(2000);
                IWebElement elementOptions = CHSHelper.FindElementByXpathFromWeb(PLCWebDriver, PLCProgramStatusDropDownXpath);
                if (elementOptions != null && elementOptions.Enabled == true)
                {
                    if (SelectPLCOptions(options))
                    {
                        Console.WriteLine("SelectPLCOptions Pass >>" + options.ToString());
                        if (SelectPLCStatus(status))
                        {
                            Console.WriteLine("SelectPLCStatus Pass >>" + options.ToString());
                            return true;
                        }
                    }
                }
                trytimes--;
            } while (trytimes > 0);
            return false;
        }

        private bool SelectPLCOptions(PLCOptions options, int trytimes = 5)
        {
            do
            {
                try
                {
                    Console.WriteLine("Try SelectPLCOptions >>" + options.ToString());
                    IWebElement elementOptions = CHSHelper.FindElementByXpathFromWeb(PLCWebDriver, PLCProgramDropDownXpath);
                    SelectElement selectOptions = new SelectElement(elementOptions);
                    selectOptions.SelectByIndex(Convert.ToInt32(options));
                    if (selectOptions.SelectedOption.Text == options.ToString() + "-延时控制" && Convert.ToInt32(options) < 16)
                    {
                        return true;
                    }
                    else if (selectOptions.SelectedOption.Text == options.ToString() + "-日历定时" && Convert.ToInt32(options) == 16)
                    {
                        return true;
                    }
                    else if (selectOptions.SelectedOption.Text == options.ToString() + "-逻辑控制" && Convert.ToInt32(options) == 17)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Try SelectPLCOptions Fail,Info:" + ex.Message);
                }
                trytimes--;
                Thread.Sleep(2000);
            } while (trytimes > 0);
            return false;
        }

        private bool SelectPLCStatus(PLCStatus status, int trytimes = 5)
        {
            do
            {
                try
                {
                    Console.WriteLine("Try SelectPLCStatus >>" + status.ToString());
                    IWebElement elementStatus = CHSHelper.FindElementByXpathFromWeb(PLCWebDriver, PLCProgramStatusDropDownXpath);
                    SelectElement selectStatus = new SelectElement(elementStatus);
                    selectStatus.SelectByIndex(Convert.ToInt32(status));
                    Thread.Sleep(2000);
                    if (selectStatus.SelectedOption.Text == "启动" && Convert.ToInt32(status) == 0)
                    {
                        return true;
                    }
                    else if (selectStatus.SelectedOption.Text == "停止" && Convert.ToInt32(status) == 1)
                    {
                        return true;
                    }
                    else if (selectStatus.SelectedOption.Text == "运行" && Convert.ToInt32(status) == 2)
                    {
                        return true;
                    }
                    else if (selectStatus.SelectedOption.Text == "继续" && Convert.ToInt32(status) == 3)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Try SelectPLCStatus Fail，info:" + ex.Message);
                }
                trytimes--;
                Thread.Sleep(2000);
            } while (trytimes > 0);
            return false;
        }

        #endregion

        #region StartPLCViaOptionPanel

        private bool OpenPLCOptionPanel(int trytimes = 5)
        {
            do
            {
                IWebElement element = CHSHelper.FindElementByXpathFromWeb(PLCWebDriver, PLCProgramOptionPanel);
                if (element != null)
                {
                    element.Click();
                }
                Thread.Sleep(2000);
                IWebElement e = CHSHelper.FindElementByXpathFromWeb(PLCWebDriver, PLCProgramOptionPanelTable);
                if (e != null)
                {
                    Console.WriteLine("OpenPLCOptionPanel Pass!");
                    return true;
                }
                Console.WriteLine("Try OpenPLCOptionPanel " + trytimes);
                Thread.Sleep(3000);
                trytimes--;
            } while (trytimes > 0);
            return false;
        }

        private bool SetPLCStatus(PLCStatus status, PLCOptions options, int trySwitchtimes = 5)
        {
            do
            {
                try
                {
                    IWebElement element = CHSHelper.FindElementByXpathFromWeb(PLCWebDriver, "//*[@id='con_" + Convert.ToInt32(options) + "']");
                    string curstatus = element.GetAttribute("class");
                    int index = Convert.ToInt32(options) + 1;
                    IWebElement toggle = CHSHelper.FindElementByXpathFromWeb(PLCWebDriver, "//*[@id='tb_pni']/tbody/tr[" + index + "]/td[2]/table/tbody/tr/td[2]/input");
                    if (status == PLCStatus.Start && curstatus.Contains("off"))
                    {
                        toggle.Click();
                    }
                    if (status == PLCStatus.Stop && curstatus.Contains("on"))
                    {
                        toggle.Click();
                    }
                    Thread.Sleep(3000);
                    element = CHSHelper.FindElementByXpathFromWeb(PLCWebDriver, "//*[@id='con_" + Convert.ToInt32(options) + "']");
                    curstatus = element.GetAttribute("class");
                    toggle = CHSHelper.FindElementByXpathFromWeb(PLCWebDriver, "//*[@id='tb_pni']/tbody/tr[" + index + "]/td[2]/table/tbody/tr/td[2]/input");
                    if (status == PLCStatus.Start && curstatus.Contains("on"))
                    {
                        Console.WriteLine("SetPLCStatus Pass! info:" + curstatus);
                        return true;
                    }
                    if (status == PLCStatus.Stop && curstatus.Contains("off"))
                    {
                        Console.WriteLine("SetPLCStatus Pass! info:" + curstatus);
                        return true;
                    }
                    Console.WriteLine("Try SetPLCStatus ...!" + trySwitchtimes);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Try SetPLCStatus Fail! " + ex.Message);
                }
                trySwitchtimes--;
            } while (trySwitchtimes > 0);
            return false;
        }

        #endregion

        private static string GetPLCInfo(string key, string file = @"C:\PLC.ini")
        {
            try
            {
                if (!File.Exists(file))
                {
                    File.Copy(PLCIniFile, file, true);
                }
                return NerveCenterHelper.ReadIniValue("PLC", key, file);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
