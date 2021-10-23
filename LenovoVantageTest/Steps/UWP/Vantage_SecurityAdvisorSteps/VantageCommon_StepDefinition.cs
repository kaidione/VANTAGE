using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace LenovoVantageTest
{
    [Binding]
    public class VantageCommon_StepDefinition
    {
        private readonly InformationalWebDriver webDriver;
        private static VantageUI vantageUI = new VantageUI();

        public VantageCommon_StepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Given(@"Reset Vantage")]
        public void GivenResetVantage()
        {
            if (VantageConstContent.NotLEMask)
            {
                vantageUI.ResetVantageThroughSettings();
            }
            else
            {
                vantageUI.ResetEnterpriseVantageThroughSettings();
            }
            DesktopPowerManagementHelper.ResetVantage = true;
        }

        [Given(@"launch vantage with protocol")]
        public void GivenLaunchVantageWithProtocol()
        {
            vantageUI.LaunchVantageWithProtocol();
            VantageCommonHelper.FlushGifContainer(webDriver.Session);
        }

        [Given(@"go through tutorial page")]
        public void GivenGoThroughTutorialPage()
        {
            vantageUI.GoThroughTutorial("qa-2", "personal");
        }

        [Given(@"modify web server to (.*)")]
        public void GivenModifyWebServerTo(string server)
        {
            DateTime begin = DateTime.Now;
            while (UwpAppManagement.SearchUwpAppByName(Constants.PackageName4Vantage3) == null && (DateTime.Now - begin).TotalSeconds < 30)
            {
                System.Threading.Thread.Sleep(1000);
            }
            vantageUI.modifyConfigJsonFile(server);
        }

        [StepDefinition(@"Launch vantage and go through tutorial with default segment")]
        public void WhenLaunchVantageAndGoThroughTutorialWithdefaultSegment()
        {
            VantageUI.instance.GoThroughTutorial(TestRequirementHelper.Instance.DefaultServer, TestRequirementHelper.Instance.DefaultSegement);
        }

        [Given(@"uninstall lenovovantageservice")]
        public void GivenUninstallLenovovantageservice()
        {
            vantageUI.uninstallVantageService();
        }

        [Given(@"Uninstall Lenovo Vantage Service")]
        public void GivenUninstallLenovoVantageService()
        {
            VantageCommonHelper.DeteleLenovoVantageService(true);
        }

        [Given(@"uninstall imc")]
        public void GivenUninstallImc()
        {
            vantageUI.uninstallIMC();
        }

        [Given(@"Close Vantage")]
        public void GivenCloseVantage()
        {
            WindowsDriver<WindowsElement> appSession = vantageUI.GetControlPanelSession(true);
            WindowsElement closeVantage = vantageUI.FindElementByTimes(appSession, "XPath", "//*[@Name='Close Lenovo Vantage']", 30, 3);
            if (closeVantage != null)
            {
                closeVantage.Click();
                Thread.Sleep(1000);
            }
            Common.KillProcess(VantageConstContent.VantageProcessName, true);
        }

        [Given(@"Enable vantage log")]
        public void GivenEnableVantageLog()
        {
            RegistryHelp.SetRegistryKeyValuePlus(Constants.vantage_shell_log, "Trace");
        }

        [Given(@"start fiddler")]
        public void GivenStartFiddler()
        {
            Process p = new Process();
            p.StartInfo.FileName = "Fiddler";
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            System.Threading.Thread.Sleep(10 * 1000);

        }

        [Given(@"restart lenovo vantage service")]
        public void GivenRestartLenovoVantageService()
        {
            vantageUI.RestartVantageService();
        }

        [Then(@"check the shell log contains (.*)")]
        public void ThenCheckTheShellLogContains(string needFindtxt)
        {
            string logFile = Common.FileConverter("%appdata%\\Packages\\E046963F.LenovoCompanion_k1h2ywk1493x8\\LocalState\\Logs");
            DirectoryInfo dirinfo = new DirectoryInfo(logFile);
            FileInfo[] sortList = dirinfo.GetFiles("LenovoVantageShell*");
            bool isfind = SearchTxtInFiles(sortList, needFindtxt);
            Assert.IsTrue(isfind, "Then Check The Shell Log Contains");
        }

        private static bool SearchTxtInFiles(FileInfo[] sortList, String text)
        {
            if (sortList.Length == 0)
            {
                return false;
            }
            Array.Sort(sortList, new MyDateSorter());
            int Length = sortList.Length;
            int searchCount = 1;
            if (Length >= 2) searchCount = 2;
            string logfile = string.Empty;
            for (int k = 0; k < searchCount; k++)
            {
                logfile = sortList[k].FullName;
                if (SearchTextInFile(logfile, text))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool SearchTextInFile(string filePath, string text)
        {
            string fileStr = File.ReadAllText(filePath);
            Regex reg = new Regex(text);
            Match m = reg.Match(fileStr);
            while (m.Success)
            {
                return true;
            }
            return false;
        }

        [Then(@"Close fiddler")]
        public void ThenCloseFiddler()
        {
            Common.KillProcess("Fiddler", true);
        }

    }
}
