using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Utility;
using Microsoft.Win32;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public sealed class ToastMessageForSealedBatteryWarranty : SettingsBase
    {

        private InformationalWebDriver _webDriver;
        private NerveCenterPages _nerverCenterPage;
        private bool isChecked = false;
        private string namePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\ToastTaskSchedulerName.bat");
        List<string> toastTitle = new List<string>() { "Is your PC battery protected?", "Worried about your PC’s future battery failure?", "Worried about PC battery replacement cost?", "Maximize your battery health and protection", "Your PC battery could be at risk!", "Need more mobility from your PC?" };

        public ToastMessageForSealedBatteryWarranty(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Del SealedBattery toast data from the registry")]
        public void GivenDelTatalDataFromTheRegistry()
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Lenovo\\ImController\\PluginData\\IdeaNotebookPlugin\\BatWarranty\\Toast", true);
                string[] regKeys = reg.GetValueNames();
                foreach (var regKey in regKeys)
                {
                    if (regKey == "Id" || regKey == "LastDisplayTime")
                    {
                        reg.DeleteValue(regKey, true);
                    }
                }
                reg.Close();
            }
            catch (Exception ErroMessage)
            {
                Debug.WriteLine("Del SealedBattery toast data from the registry Because Of :" + ErroMessage.ToString());
            }
        }

        [Given(@"Set SealedBattery toast Mock Data")]
        public void GivenSetSealedBatteryToastMockData()
        {
            try
            {
                RegistryKey reg = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Lenovo\\ImController\\PluginData\\IdeaNotebookPlugin\\BatWarranty\\Toast", true);
                reg.SetValue("SOH", "80");
                reg.SetValue("DisableRandom", "1");
                reg.SetValue("MTM", "82BJ0001US");
                reg.SetValue("SN", "PF2FT8MY");
                reg.Close();
            }
            catch (Exception ErroMessage)
            {
                Debug.WriteLine("Set SealedBattery toast Mock Data fail Because Of :" + ErroMessage.ToString());
            }
        }

        [Given(@"Set SealedBattery Toast ""(.*)"" Data ""(.*)""")]
        public void GivenSetSealedBatteryToastData(string p0, string p1)
        {
            try
            {
                RegistryKey reg = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Lenovo\\ImController\\PluginData\\IdeaNotebookPlugin\\BatWarranty\\Toast", true);
                reg.SetValue(p0, p1);
                reg.Close();
            }
            catch (Exception ErroMessage)
            {
                Debug.WriteLine("Set SealedBattery toast Mock Data fail Because Of :" + ErroMessage.ToString());
            }
        }


        [Given(@"Set SealedBattery Toast ""(.*)"" Time and Id")]
        public void GivenSetSealedBatteryToastTimeAndId(int p0)
        {
            try
            {
                long nowTime = DateTime.Now.ToFileTime();
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Lenovo\\ImController\\PluginData\\IdeaNotebookPlugin\\BatWarranty\\Toast", true);
                string[] regKeys = reg.GetValueNames();
                reg.SetValue("Id", p0 - 1);
                reg.SetValue("LastDisplayTime", nowTime);
            }
            catch (Exception ErrorMessage)
            {

                Debug.WriteLine("Set SealedBattery toast Id and LastDisplayTime from the registry Failed Because Of :" + ErrorMessage.ToString());
            }
        }

        //删除文件夹子，注意穿过来的路径格式
        [Given(@"Del ""(.*)"" folder")]
        public void GivenDelFolder(string path)
        {
            try
            {
                if (path.Contains("%"))
                {
                    path = Environment.ExpandEnvironmentVariables(path);
                }
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
            }
            catch (Exception ErroMessage)
            {

                Debug.WriteLine("Delete regedit fail Because Of :" + ErroMessage.ToString());
            }
        }

        [Given(@"Restart SealedBattery toast TaskScheduler")]
        public void GivenRestartSealedBatteryToastTaskScheduler()
        {
            string SchedulerName = null;
            try
            {
                if (File.Exists(namePath))
                {
                    String runName = string.Format("Start-Process -FilePath \"{0}\" -Wait -passthru ", namePath);
                    Common.RunPowershellCmdlet(runName);
                }

            }
            catch (IOException e)
            {
                Debug.WriteLine(e.ToString());
            }
        }

        [Given(@"Wait ""(.*)"" toast")]
        public void GivenWaitToast(string p0)
        {
            int times = 1;
            int winHeight = Screen.PrimaryScreen.WorkingArea.Height / 12 * 11;
            int winWidth = Screen.PrimaryScreen.WorkingArea.Width / 12 * 11;
            WindowsElement title = null;
            WindowsElement messageText = null;
            WindowsElement verbButton = null;
            WindowsElement DismissButton = null;
            WindowsElement toastWindow = null;
            HSSmartAssistPage hs = new HSSmartAssistPage(_webDriver.Session);
            HSPowerSettingsPage hsp = new HSPowerSettingsPage(_webDriver.Session);
            hsp.SetMouseAtScreen(winWidth, winHeight);
            WindowsDriver<WindowsElement> _appsion = hs.GetControlPanelSession(true);
            while (true)
            {
                if (times == 0)
                {
                    break;
                }
                //toastWindow = FindElementByTimes(_appsion, "AutomationId", "NormalToastView");
                title = FindElementByTimes(_appsion, "AutomationId", "TitleText");
                if (title != null)
                {
                    _appsion.Mouse.MouseMove(title.Coordinates);
                    if (toastTitle.Contains(title.GetAttribute("Name")))
                    {
                        messageText = FindElementByTimes(_appsion, "AutomationId", "MessageText", 2, 1);
                        verbButton = FindElementByTimes(_appsion, "AutomationId", "VerbButton", 2, 1);
                        DismissButton = FindElementByTimes(_appsion, "AutomationId", "DismissButton", 2, 1);
                        if (messageText == null || verbButton == null || DismissButton == null)
                        {
                            isChecked = true;
                            break;
                        }
                        if (p0 == "1" || p0 == "6")
                        {
                            WindowsElement image = FindElementByTimes(_appsion, "AutomationId", "NonPersonableImage", 2, 1);
                            if (image == null)
                            {
                                isChecked = true;
                                break;
                            }
                        }
                        switch (p0)
                        {
                            case "1":
                                Assert.AreEqual(title.GetAttribute("Name"), toastTitle[0]);
                                Assert.AreEqual(messageText.GetAttribute("Name"), "Extend your battery warranty coverage with Sealed Battery Warranty");
                                Assert.AreEqual(verbButton.GetAttribute("Name"), "Learn More");
                                break;
                            case "2":
                                Assert.AreEqual(title.GetAttribute("Name"), toastTitle[1]);
                                Assert.AreEqual(messageText.GetAttribute("Name"), "Get efficient battery replacement with Sealed Battery Warranty");
                                Assert.AreEqual(verbButton.GetAttribute("Name"), "Learn More");
                                break;
                            case "3":
                                Assert.AreEqual(title.GetAttribute("Name"), toastTitle[2]);
                                Assert.AreEqual(messageText.GetAttribute("Name"), "Save significantly on battery replacement costs by extending battery warranty");
                                Assert.AreEqual(verbButton.GetAttribute("Name"), "Get Now");
                                break;
                            case "4":
                                Assert.AreEqual(title.GetAttribute("Name"), toastTitle[3]);
                                Assert.AreEqual(messageText.GetAttribute("Name"), "Extend your battery warranty coverage for uninterrupted productivity");
                                Assert.AreEqual(verbButton.GetAttribute("Name"), "Extend Now");
                                break;
                            case "5":
                                Assert.AreEqual(title.GetAttribute("Name"), toastTitle[4]);
                                Assert.AreEqual(messageText.GetAttribute("Name"), "Check your battery health status and warranty for protection");
                                Assert.AreEqual(verbButton.GetAttribute("Name"), "Check Now");
                                break;
                            case "6":
                                Assert.AreEqual(title.GetAttribute("Name"), toastTitle[5]);
                                Assert.AreEqual(messageText.GetAttribute("Name"), "Extend your sealed battery warranty and enjoy peace of mind");
                                Assert.AreEqual(verbButton.GetAttribute("Name"), "Know More");
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                    else
                    {
                        title = null;
                        DismissButton = FindElementByTimes(_appsion, "AutomationId", "DismissButton", 2, 1);
                        DismissButton.Click();
                        hsp.SetMouseAtScreen(winWidth, winHeight);
                    }
                }
                else
                {
                    times--;
                }
            }
            if (title == null)
            {
                isChecked = true;
            }
        }

        [Given(@"Click SealedBattery toast ""(.*)"" Learn More")]
        public void GivenClickSealedBatteryToastLearnMore(string p0)
        {
            HSSmartAssistPage hs = new HSSmartAssistPage(_webDriver.Session);
            WindowsDriver<WindowsElement> _appsion = hs.GetControlPanelSession(true);
            WindowsElement verbButton = null;
            string btnName = null;
            switch (p0)
            {
                case "1":
                    btnName = "Learn More";
                    break;
                case "2":
                    btnName = "Learn More";
                    break;
                case "3":
                    btnName = "Get Now";
                    break;
                case "4":
                    btnName = "Extend Now";
                    break;
                case "5":
                    btnName = "Check Now";
                    break;
                case "6":
                    btnName = "Know More";
                    break;
                default:
                    break;
            }
            verbButton = FindElementByTimes(_appsion, "Name", btnName, 3, 2);
            if (verbButton == null)
            {
                Process.Start("ms-actioncenter:");
                Thread.Sleep(1000);
                verbButton = FindElementByTimes(_appsion, "Name", btnName, 3, 2);
                Assert.NotNull("Can't Find " + btnName + "Button");
            }
            else
            {
                verbButton.Click();
            }
        }

        [Then(@"There is PowerPage")]
        public void ThenThereIsPowerPage()
        {
            _nerverCenterPage = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerverCenterPage.PowerTitle, "Not go to power page");
        }

        [Given(@"Set SealedBattery ""(.*)"" toast time")]
        public void GivenSetSealedBatteryToastTime(string p0)
        {
            DateTime nowTime = DateTime.Now;
            if (p0.ToLower() == "second" || p0.ToLower() == "fifth")
            {
                Common.SetSystemDateTime(nowTime.AddDays(14).ToString());
            }
            else if (p0.ToLower() == "third" || p0.ToLower() == "sixth")
            {
                Common.SetSystemDateTime(nowTime.AddDays(21).ToString());
            }
            else if (p0.ToLower() == "fourth")
            {
                Common.SetSystemDateTime(nowTime.AddDays(7).ToString());
            }
        }

        [Then(@"Check SealedBattery Toast ""(.*)""")]
        public void ThenCheckSealedBatteryToast(string p0)
        {
            if (isChecked)
            {
                WindowsElement titles = null;
                WindowsElement messageTexts = null;
                var files = Directory.GetFiles(@"C:\ProgramData\Lenovo\Modern\Logs", "*.log");
                string logName = null;
                bool flag = false;
                foreach (var item in files)
                {
                    if (item.Contains("Log.Plugins.IdeaNotebookPlugin"))
                    {
                        logName = item;
                    }

                }
                if (logName != null)
                {
                    foreach (string str in File.ReadAllLines(logName, Encoding.Default))
                    {
                        if (str.Contains("Battery warranty toast " + p0 + " popped success"))
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                else
                {
                    Assert.Fail("Cant find IdeaNotebookPlugin log");
                }
                if (flag)
                {
                    Process.Start("ms-actioncenter:");
                    Thread.Sleep(1000);
                    HSSmartAssistPage hs = new HSSmartAssistPage(_webDriver.Session);
                    WindowsDriver<WindowsElement> _appsion = hs.GetControlPanelSession(true);
                    switch (p0)
                    {
                        case "1":
                            titles = FindElementByTimes(_appsion, "Name", toastTitle[0], 2, 1);
                            Assert.NotNull(titles, "The Toast1 in center can't find");
                            messageTexts = FindElementByTimes(_appsion, "Name", "Extend your battery warranty coverage with Sealed Battery Warranty", 2, 1);
                            Assert.NotNull(messageTexts, "The Toast1 in center can't find");
                            break;
                        case "2":
                            titles = FindElementByTimes(_appsion, "Name", toastTitle[1], 2, 1);
                            Assert.NotNull(titles, "The Toast1 in center can't find");
                            messageTexts = FindElementByTimes(_appsion, "Name", "Get efficient battery replacement with Sealed Battery Warranty", 2, 1);
                            Assert.NotNull(messageTexts, "The Toast1 in center can't find");
                            break;
                        case "3":
                            titles = FindElementByTimes(_appsion, "Name", toastTitle[2], 2, 1);
                            Assert.NotNull(titles, "The Toast1 in center can't find");
                            messageTexts = FindElementByTimes(_appsion, "Name", "Save significantly on battery replacement costs by extending battery warranty", 2, 1);
                            Assert.NotNull(messageTexts, "The Toast1 in center can't find");
                            break;
                        case "4":
                            titles = FindElementByTimes(_appsion, "Name", toastTitle[3], 2, 1);
                            Assert.NotNull(titles, "The Toast1 in center can't find");
                            messageTexts = FindElementByTimes(_appsion, "Name", "Extend your battery warranty coverage for uninterrupted productivity", 2, 1);
                            Assert.NotNull(messageTexts, "The Toast1 in center can't find");
                            break;
                        case "5":
                            titles = FindElementByTimes(_appsion, "Name", toastTitle[4], 2, 1);
                            Assert.NotNull(titles, "The Toast1 in center can't find");
                            messageTexts = FindElementByTimes(_appsion, "Name", "Check your battery health status and warranty for protection", 2, 1);
                            Assert.NotNull(messageTexts, "The Toast1 in center can't find");
                            break;
                        case "6":
                            titles = FindElementByTimes(_appsion, "Name", toastTitle[5], 2, 1);
                            Assert.NotNull(titles, "The Toast1 in center can't find");
                            messageTexts = FindElementByTimes(_appsion, "Name", "Extend your sealed battery warranty and enjoy peace of mind", 2, 1);
                            Assert.NotNull(messageTexts, "The Toast1 in center can't find");
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    string info = DesktopPowerManagementHelper.WriteLogToTestReport("Check SealedBatteryToast Log", "sealedbatterytoastlog");
                    Hooks.WriteInfoReport(info);
                    VantageConstContent.ShowTips = string.Empty;
                }
            }
        }

        [Then(@"Click SealedBattery toast close button")]
        public void ThenClickSealedBatteryToastCloseButton()
        {
            HSSmartAssistPage hs = new HSSmartAssistPage(_webDriver.Session);
            WindowsDriver<WindowsElement> _appsion = hs.GetControlPanelSession(true);
            WindowsElement DismissButton = FindElementByTimes(_appsion, "AutomationId", "DismissButton", 2, 1);
            if (DismissButton != null)
            {
                DismissButton.Click();
            }
            else
            {
                Assert.Fail("DismissButton Can't Find");
            }
        }

        [Then(@"SealedBattery Toast ""(.*)"" will be hidden")]
        public void ThenSealedBatteryToastWillBeHidden(string p0)
        {
            HSSmartAssistPage hs = new HSSmartAssistPage(_webDriver.Session);
            WindowsDriver<WindowsElement> _appsion = hs.GetControlPanelSession(true);
            WindowsElement title = FindElementByTimes(_appsion, "AutomationId", "TitleText", 1, 1);
            if (title != null && toastTitle.Contains(title.GetAttribute("Name")))
            {
                Assert.Fail("The toast is not hidden");
            }
            Process.Start("ms-actioncenter:");
            Thread.Sleep(1000);
            WindowsElement titles = null;
            WindowsElement messageTexts = null;
            switch (p0)
            {
                case "1":
                    titles = FindElementByTimes(_appsion, "Name", toastTitle[0], 2, 1);
                    Assert.NotNull(titles, "The Toast1 in center can't find");
                    messageTexts = FindElementByTimes(_appsion, "Name", "Extend your battery warranty coverage with Sealed Battery Warranty", 2, 1);
                    Assert.NotNull(messageTexts, "The Toast1 in center can't find");
                    break;
                case "2":
                    titles = FindElementByTimes(_appsion, "Name", toastTitle[1], 2, 1);
                    Assert.NotNull(titles, "The Toast1 in center can't find");
                    messageTexts = FindElementByTimes(_appsion, "Name", "Get efficient battery replacement with Sealed Battery Warranty", 2, 1);
                    Assert.NotNull(messageTexts, "The Toast1 in center can't find");
                    break;
                case "3":
                    titles = FindElementByTimes(_appsion, "Name", toastTitle[2], 2, 1);
                    Assert.NotNull(titles, "The Toast1 in center can't find");
                    messageTexts = FindElementByTimes(_appsion, "Name", "Save significantly on battery replacement costs by extending battery warranty", 2, 1);
                    Assert.NotNull(messageTexts, "The Toast1 in center can't find");
                    break;
                case "4":
                    titles = FindElementByTimes(_appsion, "Name", toastTitle[3], 2, 1);
                    Assert.NotNull(titles, "The Toast1 in center can't find");
                    messageTexts = FindElementByTimes(_appsion, "Name", "Extend your battery warranty coverage for uninterrupted productivity", 2, 1);
                    Assert.NotNull(messageTexts, "The Toast1 in center can't find");
                    break;
                case "5":
                    titles = FindElementByTimes(_appsion, "Name", toastTitle[4], 2, 1);
                    Assert.NotNull(titles, "The Toast1 in center can't find");
                    messageTexts = FindElementByTimes(_appsion, "Name", "Check your battery health status and warranty for protection", 2, 1);
                    Assert.NotNull(messageTexts, "The Toast1 in center can't find");
                    break;
                case "6":
                    titles = FindElementByTimes(_appsion, "Name", toastTitle[5], 2, 1);
                    Assert.NotNull(titles, "The Toast1 in center can't find");
                    messageTexts = FindElementByTimes(_appsion, "Name", "Extend your sealed battery warranty and enjoy peace of mind", 2, 1);
                    Assert.NotNull(messageTexts, "The Toast1 in center can't find");
                    break;
                default:
                    break;
            }
        }

        [Given(@"Clear Action Center All Value")]
        public void GivenClearActionCenterAllValue()
        {
            Process.Start("ms-actioncenter:");
            Thread.Sleep(1000);
            HSSmartAssistPage hs = new HSSmartAssistPage(_webDriver.Session);
            WindowsDriver<WindowsElement> _appsion = hs.GetControlPanelSession(true);
            WindowsElement clearBtn = FindElementByTimes(_appsion, "AutomationId", "ClearAllButton", 3, 1);
            if (clearBtn != null)
            {
                clearBtn.Click();
            }
            Thread.Sleep(1000);
            VantageCommonHelper.keybd_event(Keys.Escape, 0, 0, 0);
            VantageCommonHelper.keybd_event(Keys.Escape, 0, 2, 0);
        }

        [Then(@"Check SealedBattery toast ""(.*)"" message")]
        public void ThenCheckSealedBatteryToastMessage(string p0)
        {
            var files = Directory.GetFiles(@"C:\ProgramData\Lenovo\Modern\Logs", "*.log");
            string logName = null;
            bool flag = false;
            foreach (var item in files)
            {
                if (item.Contains("Log.Plugins.IdeaNotebookPlugin"))
                {
                    logName = item;
                }

            }
            if (logName != null)
            {
                foreach (string str in File.ReadAllLines(logName, Encoding.Default))
                {
                    if (p0 == "SOH")
                    {
                        if (str.Contains("Will not pop since SOH"))
                        {
                            flag = true;
                            break;
                        }
                    }
                    else if (p0 == "All")
                    {
                        if (str.Contains("Will not pop since all toasts have been popped"))
                        {
                            flag = true;
                            break;
                        }
                    }
                    else if (p0 == "SNNULL")
                    {
                        if (str.Contains("Will not pop since eService API returned illegal response"))
                        {
                            flag = true;
                            break;
                        }
                    }
                    else if (p0 == "Upgrade")
                    {
                        if (str.Contains("API returns null or empty upgrade, will not pop"))
                        {
                            flag = true;
                            break;
                        }
                    }
                    else if (p0 == "Moremonth")
                    {
                        if (str.Contains("Will never call battery warranty web API because serverToday-machineWarrantyStartDate > 540"))
                        {
                            flag = true;
                            break;
                        }

                    }
                }
            }
            Assert.IsTrue(flag, "The message is not Ture, Toast will be pop up");
        }

        [Given(@"SealedBattery Toast ""(.*)"" is null")]
        public void GivenSealedBatteryToastIsNull(string p0)
        {
            string regvalue = null;
            if (p0 == "SN")
            {
                regvalue = "";
            }
            else if (p0 == "upgrade")
            {
                regvalue = "R9125ZZL";
            }
            try
            {
                RegistryKey reg = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Lenovo\\ImController\\PluginData\\IdeaNotebookPlugin\\BatWarranty\\Toast", true);
                reg.SetValue("SOH", "100");
                reg.SetValue("DisableRandom", "1");
                reg.SetValue("MTM", "81X20005US");
                reg.SetValue("SN", regvalue);
                reg.Close();
            }
            catch (Exception ErroMessage)
            {
                Debug.WriteLine("Set SealedBattery toast Mock Data fail Because Of :" + ErroMessage.ToString());
            }
        }

        [Given(@"Set SealedBattery toast Date More than (.*) month")]
        public void GivenSetSealedBatteryToastDateMoreThanMonth(int p0)
        {
            try
            {
                RegistryKey reg = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Lenovo\\ImController\\PluginData\\IdeaNotebookPlugin\\BatWarranty\\Toast", true);
                reg.SetValue("MTM", "81SX000MUS");
                reg.SetValue("SN", "PF1YJAZQ");
                reg.Close();
            }
            catch (Exception ErroMessage)
            {
                Debug.WriteLine("Set SealedBattery toast Mock Data fail Because Of :" + ErroMessage.ToString());
            }
        }

        [Then(@"The SealedBattery toast will not show")]
        public void ThenTheSealedBatteryToastWillNotShow()
        {
            int times = 2;
            WindowsElement title = null;
            HSSmartAssistPage hs = new HSSmartAssistPage(_webDriver.Session);
            WindowsDriver<WindowsElement> _appsion = hs.GetControlPanelSession(true);
            while (true)
            {
                if (times == 0)
                {
                    break;
                }
                //toastWindow = FindElementByTimes(_appsion, "AutomationId", "NormalToastView");
                title = FindElementByTimes(_appsion, "AutomationId", "TitleText");
                if (title != null)
                {
                    _appsion.Mouse.MouseMove(title.Coordinates);
                    if (toastTitle.Contains(title.GetAttribute("Name")))
                    {
                        Assert.Fail("The Toast is find!");
                        break;
                    }
                    else
                    {
                        title = null;
                        WindowsElement DismissButton = FindElementByTimes(_appsion, "AutomationId", "DismissButton", 2, 1);
                        DismissButton.Click();
                    }
                }
                else
                {
                    times--;
                }
            }
        }
    }
}
