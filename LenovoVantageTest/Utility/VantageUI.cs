
using LenovoVantageTest.LogHelper;
using LenovoVantageTest.Utility;
using LenovoVantageTest.Utility.UIAImplementation;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management.Automation;
using System.ServiceProcess;
using TaskScheduler;
using comAutomation = interop.UIAutomationCore;

namespace LenovoVantageTest
{
    public class VantageUI : VantageBase
    {
        static VantageUI _instance;
        public WindowsDriver<WindowsElement> session;
        private static VantageUI vantageUI = new VantageUI();
        public static VantageUI instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new VantageUI();
                }
                return _instance;
            }
        }
        protected static PowerShell powerShell = PowerShell.Create();
        //MockMcafeeStatus mock = new MockMcafeeStatus();

        public void RestartVantageService()
        {
            string serviceName = Constants.LenovoVantageService_NAME;
            ServiceController service = new ServiceController(serviceName);
            service.WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 10));
            //service.Stop();  
            try
            {
                Common.KillProcess(Constants.LenovoVantageService_NAME, true);
            }
            catch
            {
                System.Threading.Thread.Sleep(5000);
                Common.KillProcess(Constants.LenovoVantageService_NAME, true);
            }
            service.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 15));
            service.Start();
            System.Threading.Thread.Sleep(1000);
        }


        public bool installVantageService(string path)
        {
            string VantageServiceKey = @"HKLM\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\VantageSRV_is1";
            string regKey = VantageServiceKey + "\\DisplayName";
            if (RegistryHelp.IsRegistryKeyExist(regKey))
            {
                uninstallVantageService();
            }
            if (!path.Contains(".exe"))
            {
                string[] files = Directory.GetFiles(path, "*.exe");
                if (files.Length > 0) path = files[0];
            }
            if (!path.Contains(":"))
            {
                path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
            }

            if (!File.Exists(path))
            {
                Logger.Instance.WriteLog("NO Installation package " + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path), LogType.Error);
                return false;
            }
            Common.StartProcess(path, " /silent /norestart");
            Sleep(2000);
            return true;
        }

        public void uninstallVantageService()
        {

            Common.KillProcess(Constants.LenovoVantageService_NAME, true);
            string regKey = @"HKLM\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\VantageSRV_is1\QuietUninstallString";
            string uninstall = (string)RegistryHelp.GetRegistryKeyValue(regKey); //e.g. "C:\Program Files (x86)\Lenovo\VantageService\3.3.214.0\Uninstall.exe" /SILENT
            if (Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Lenovo\VantageService")))
            {
                Common.RunCmdWithShell(uninstall);
                System.Threading.Thread.Sleep(5000);
                Common.DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Lenovo\VantageService"));
            }

            Common.DeleteDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Lenovo\Vantage"));

        }

        public static void StartProcess(string _cmd)
        {
            Common.StartProcess(_cmd);
        }
        //Marcus:有一些调用，比如ms-settings:appsfeatures 这类URI必须用这种方式，否则会throw "No Process is associated"错误
        public static void StartProcessWithoutWaitingExit(string fileName)
        {
            Common.StartProcessWithoutWaitingExit(fileName);
        }

        public void StartProtocol(string protocolStr)
        {
            Common.StartProtocol(protocolStr, "");
        }

        public void SetSegment(string seg)
        {
            ElementExistUsingXPathInDBWithinSeconds("Navbar.LID", 30);
            VantageMouseFocusElementtUsingAutomationId("navbarDropdown");
            ClickElementUsingXPathInDB("Navbar.LID");
            ClickElementUsingXPathInDB("Navbar.Preference");
            if (ElementIsCollapseUsingXpathInDB("PreferencePage.UserProfileExpand", 5))
            {
                ClickElementUsingXPathInDB("PreferencePage.UserProfileExpand");
            }

            if (seg == "Consumer")
            {
                ClickElementUsingXPathInDB("PreferencePage.Settings_personaluse");
            }
            else if (seg == "Commercial")
            {
                ClickElementUsingXPathInDB("PreferencePage.settings_professionaluse");
            }
            else if (seg == "SMB")
            {
                ClickElementUsingXPathInDB("PreferencePage.Settings_businessuse");
            }
            string newXpath = string.Format("/Window[@Name='{0}']{1}", Constants.VantageTitle, "//Button[@AutomationId='settings-profile-save-button']");
            if (ElementIsEnabledUsingCustomXPath(newXpath) == 0)
            {
                return;
            }
            ClickElementUsingXPathInDB("PreferencePage.SaveBtn");
        }


        public string ClickCameraAndMicrosoftPhoneAccess()
        {
            string result = ClickElementUsingXPathInDB("MainEntry.popup_letCameraAccess_Yes");
            if (result.Equals("true"))
            {
                return ClickElementUsingXPathInDB("MainEntry.popup_letMicrophoneAccess_Yes");
            }
            else
            {
                result = ClickElementUsingXPathInDB("MainEntry.popup_letMicrophoneAccess_Yes");
                if (result.Equals("true"))
                {
                    return ClickElementUsingXPathInDB("MainEntry.popup_letCameraAccess_Yes");
                }
            }
            return ScreenShotAndDisplayUsingHtmlLink();
        }

        public void ScreenShot2(string _s)
        {
            List<comAutomation.IUIAutomationElement> x = UIAHelper.SearchForElementsAndDoSth("/Window[@Name='Lenovo Vantage']//Group[@AutomationId='tutorial_personalUse']");
            Bitmap bm = CaptureScreen.ScreenShotWithSpecificArea(x[0].CurrentBoundingRectangle.left, x[0].CurrentBoundingRectangle.top, (x[0].CurrentBoundingRectangle.right - x[0].CurrentBoundingRectangle.left), (x[0].CurrentBoundingRectangle.bottom - x[0].CurrentBoundingRectangle.top));

            bm.Save(@"d:\aa.bmp");
            Color color = bm.GetPixel(60, 50);
            System.Drawing.Color hsl = System.Drawing.Color.FromArgb(color.ToArgb());
            byte R = color.R;
            byte G = color.G;
            byte B = color.B;
            string str = string.Format("R={0} G={1}B={2}, H={3} S={4} L={5}", R, G, B, hsl.GetHue(), hsl.GetSaturation(), hsl.GetBrightness());

        }
        #region Common steps
        //https://www.winhelponline.com/blog/windows-10-ms-settings-pages-using-ms-settings-shortcuts/
        //不少case要求reset Vantage，而不是reinstall Vantage. 这里只reset，不涉及tutorial page
        public bool ResetVantageThroughSettings()
        {
            CloseVantageProcess();
            KillProcess("ApplicationFrameHost");
            StartProtocol("ms-settings:appsfeatures");
            //找到并输入lenovo
            if (!ElementExistUsingCustomXPathInSecondsWithSpecificProcessName("(/Window[@ProcessId='{0}']//Edit[@AutomationId='SystemSettings_StorageSense_AppSizesListFilter_DisplayStringValue'])[1]", 10, "ApplicationFrameHost"))
            {
                return false;
            }
            if (!ElementSetValueUsingCustomXPathWithSpecificProcessName("Lenovo Vantage", "(/Window[@ProcessId='{0}']//Edit[@AutomationId='SystemSettings_StorageSense_AppSizesListFilter_DisplayStringValue'])[1]", "ApplicationFrameHost"))
            {
                return false;
            }
            //找到并点击Vantage
            if (!ElementExistUsingCustomXPathInSecondsWithSpecificProcessName("(/Window[@ProcessId='{0}']//ListItem[@IsOffscreen=0 and contains(@Name,'Lenovo Vantage') ])[1]", 30, "ApplicationFrameHost"))
            {
                return false;
            }
            ClickElementUsingCustomXPathWithSpecificProcessName("(/Window[@ProcessId='{0}']//ListItem[@IsOffscreen=0 and contains(@Name,'Lenovo Vantage') ])[1]", 5, "ApplicationFrameHost");
            //找到并点击Vantage下的Advanced Options，这个没有AutomationId
            if (!ElementExistUsingCustomXPathInSecondsWithSpecificProcessName("(/Window[@ProcessId='{0}']//ListItem[@IsOffscreen=0 and contains(@Name,'Lenovo Vantage') ])[1]/Text[contains(@AutomationId,'E046963F.LenovoCompanion') and @Name='Lenovo Vantage']/following-sibling::HyperLink", 5, "ApplicationFrameHost"))
            {
                return false;
            }
            ClickElementUsingCustomXPathWithSpecificProcessName("(/Window[@ProcessId='{0}']//ListItem[@IsOffscreen=0 and contains(@Name,'Lenovo Vantage') ])[1]/Text[contains(@AutomationId,'E046963F.LenovoCompanion') and @Name='Lenovo Vantage']/following-sibling::HyperLink", 5, "ApplicationFrameHost");
            //进入Reset Appdata page后，找到reset button并点击
            if (!ElementExistUsingCustomXPathInSecondsWithSpecificProcessName("/Window[@ProcessId='{0}']//Button[@AutomationId='SystemSettings_StorageSense_AppSizesAdvanced_AppReset_Button']", 5, "ApplicationFrameHost"))
            {
                return false;
            }
            ClickElementUsingCustomXPathWithSpecificProcessName("/Window[@ProcessId='{0}']//Button[@AutomationId='SystemSettings_StorageSense_AppSizesAdvanced_AppReset_Button']", 5, "ApplicationFrameHost");

            //确认reset
            if (!ElementExistUsingCustomXPathInSecondsWithSpecificProcessName("/Window[@ProcessId='{0}']//Button[@AutomationId='SystemSettings_StorageSense_AppSizesAdvanced_AppReset_ConfirmButton']", 5, "ApplicationFrameHost"))
            {
                return false;
            }
            ClickElementUsingCustomXPathWithSpecificProcessName("/Window[@ProcessId='{0}']//Button[@AutomationId='SystemSettings_StorageSense_AppSizesAdvanced_AppReset_ConfirmButton']", 5, "ApplicationFrameHost");
            //虽然有个勾代表reset完成，但是这个是text ,name="App reset completed." ，没有AutomationId，
            int count = 0;
            WindowsDriver<WindowsElement> appSession = vantageUI.GetControlPanelSession(true);
            WindowsElement resetVantageCompleted = vantageUI.FindElementByTimes(appSession, "XPath", "//*[@Name='App reset completed.']", 30, 20);
            while (resetVantageCompleted == null && count < 10)
            {
                count++;
            }
            System.Threading.Thread.Sleep(5000);
            KillProcess("ApplicationFrameHost");
            return true;

        }

        public bool ResetEnterpriseVantageThroughSettings()
        {
            CloseVantageProcess();
            KillProcess("ApplicationFrameHost");
            StartProtocol("ms-settings:appsfeatures");
            //找到并输入Commercial Vantage
            if (!ElementExistUsingCustomXPathInSecondsWithSpecificProcessName("(/Window[@ProcessId='{0}']//Edit[@AutomationId='SystemSettings_StorageSense_AppSizesListFilter_DisplayStringValue'])[1]", 10, "ApplicationFrameHost"))
            {
                return false;
            }
            if (!ElementSetValueUsingCustomXPathWithSpecificProcessName("Commercial Vantage", "(/Window[@ProcessId='{0}']//Edit[@AutomationId='SystemSettings_StorageSense_AppSizesListFilter_DisplayStringValue'])[1]", "ApplicationFrameHost"))
            {
                return false;
            }
            //找到并点击Commercial Vantage
            if (!ElementExistUsingCustomXPathInSecondsWithSpecificProcessName("(/Window[@ProcessId='{0}']//ListItem[@IsOffscreen=0 and contains(@Name,'Commercial Vantage') ])[1]", 5, "ApplicationFrameHost"))
            {
                return false;
            }
            ClickElementUsingCustomXPathWithSpecificProcessName("(/Window[@ProcessId='{0}']//ListItem[@IsOffscreen=0 and contains(@Name,'Commercial Vantage') ])[1]", 5, "ApplicationFrameHost");
            //找到并点击Vantage下的Advanced Options，这个没有AutomationId
            if (!ElementExistUsingCustomXPathInSecondsWithSpecificProcessName("(/Window[@ProcessId='{0}']//ListItem[@IsOffscreen=0 and contains(@Name,'Commercial Vantage') ])[1]/Text[contains(@AutomationId,'E046963F.LenovoSettings') and @Name='Commercial Vantage']/following-sibling::HyperLink", 5, "ApplicationFrameHost"))
            {
                return false;
            }
            ClickElementUsingCustomXPathWithSpecificProcessName("(/Window[@ProcessId='{0}']//ListItem[@IsOffscreen=0 and contains(@Name,'Commercial Vantage') ])[1]/Text[contains(@AutomationId,'E046963F.LenovoSettings') and @Name='Commercial Vantage']/following-sibling::HyperLink", 5, "ApplicationFrameHost");
            //进入Reset Appdata page后，找到reset button并点击
            if (!ElementExistUsingCustomXPathInSecondsWithSpecificProcessName("/Window[@ProcessId='{0}']//Button[@AutomationId='SystemSettings_StorageSense_AppSizesAdvanced_AppReset_Button']", 5, "ApplicationFrameHost"))
            {
                return false;
            }
            ClickElementUsingCustomXPathWithSpecificProcessName("/Window[@ProcessId='{0}']//Button[@AutomationId='SystemSettings_StorageSense_AppSizesAdvanced_AppReset_Button']", 5, "ApplicationFrameHost");

            //确认reset
            if (!ElementExistUsingCustomXPathInSecondsWithSpecificProcessName("/Window[@ProcessId='{0}']//Button[@AutomationId='SystemSettings_StorageSense_AppSizesAdvanced_AppReset_ConfirmButton']", 5, "ApplicationFrameHost"))
            {
                return false;
            }
            ClickElementUsingCustomXPathWithSpecificProcessName("/Window[@ProcessId='{0}']//Button[@AutomationId='SystemSettings_StorageSense_AppSizesAdvanced_AppReset_ConfirmButton']", 5, "ApplicationFrameHost");
            //虽然有个勾代表reset完成，但是这个是text ,name="App reset completed." ，没有AutomationId，
            System.Threading.Thread.Sleep(5000);
            KillProcess("ApplicationFrameHost");
            return true;

        }
        public void AssureVantageIsInstalledAndVersionIsRightWithoutGoingThroughTutorial(string _expectedVantageShellVersion, string _server2Test, string _packagePath, string _requiredSegmentAutomationId)
        {
            if (!IsVantageInstalled())
            {
                installVantage(_packagePath);
            }
            if (!GetVantageShellVersion().Equals(_expectedVantageShellVersion))
            {
                Console.WriteLine("Current Vantage Version(" + GetVantageShellVersion() + ") is not expected Version(" + _expectedVantageShellVersion + ")! Need to uninstall current Vantage then install the right version...");
                CloseVantageProcess();
                uninstallVantage();
                uninstallVantageService();
                installVantage(_packagePath);
            }

        }

        public bool AssureVantageIsInstalledAndVersionIsRightAndGoThroughTutorial(string _expectedVantageShellVersion, string _server2Test, string _packagePath, string _requiredSegmentAutomationId)
        {
            if (!IsVantageInstalled())
            {
                installVantage(_packagePath);
            }
            if (!GetVantageShellVersion().Equals(_expectedVantageShellVersion))
            {
                Console.WriteLine("Current Vantage Version(" + GetVantageShellVersion() + ") is not expected Version(" + _expectedVantageShellVersion + ")! Need to uninstall current Vantage then install the right version...");
                CloseVantageProcess();
                uninstallVantage();
                uninstallVantageService();
                installVantage(_packagePath);
            }


            return GoThroughTutorial(_server2Test, _requiredSegmentAutomationId);
        }

        public bool AssureVantageIsInstalledAndVersionIsRightAndWebServerIsRight(string _expectedVantageShellVersion, string _server2Test, string _packagePath)
        {
            if (!IsVantageInstalled())
            {
                installVantage(_packagePath);
            }

            if (!GetVantageShellVersion().Equals(_expectedVantageShellVersion))
            {
                Console.WriteLine("Current Vantage Version(" + GetVantageShellVersion() + ") is not expected Version(" + _expectedVantageShellVersion + ")! Need to uninstall current Vantage then install the right version...");
                CloseVantageProcess();
                uninstallVantage();
                installVantage(_packagePath);
            }

            return modifyConfigJsonFile(_server2Test);//确保server指向正确
        }
        /*Author: Marcus
         * Desc:
        //1. 根据目前的一个critical issue，导致QA与Dev的agrument。Vantage安装后不要先打开再连接到指定server，而是直接copy或生成特定config.json到AppData\Local\Packages\E046963F.LenovoCompanion_k1h2ywk1493x8\LocalState
        //因为直接打开刚安装的Vantage会连上Production server=>导致部分内容被cache=>转到测试server会出现bug，但这个bug不是有效的bug，因为用户不会有转换server的问题。
        //2. 不少情况下需要go through tutorial，tutorial在那时不是测试重点，有case专门测tutorial.
        //调用前一定不要launch Vantage
        */
        public bool GoThroughTutorial(string _serverToTest = "qa-2", string _requiredSegementName = "")
        {
            _requiredSegementName = _requiredSegementName == null ? "" : _requiredSegementName;
            if (!IsVantageInstalled())
            {
                Logger.Instance.WriteLog("GoThroughTutorial() , Vantage installation failed ??");
                return false;
            }
            string localStateFullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Local", "Packages", Constants.tangramUapFullName, "LocalState");
            modifyConfigJsonFile(_serverToTest);//确保server指向正确
            LaunchVantageWithProtocol();
            System.Threading.Thread.Sleep(4000);
            //没有Vantage service时会安装service 或者 service需要更新，这个要1分钟时间
            DateTime last = DateTime.Now;
            int timeoutMinutes = 5;
            while (ElementExistUsingCustomXPath(string.Format("/Window[@Name='{0}']//Pane[@Name='{1}']", Constants.VantageTitle, Constants.InstallerContainer_PartialName_InInstallingVantage)) && last.AddMinutes(timeoutMinutes) > DateTime.Now)
            {
                System.Threading.Thread.Sleep(2000);
            }
            if (last.AddMinutes(timeoutMinutes) < DateTime.Now)
            {
                PrintScreen("Timeout2InstallVantageService");
                Logger.Instance.WriteLog($"Timeout to install Vantage service , {timeoutMinutes} minutes consumed. Screen is shot", LogType.Error);
                return false;
            }
            //确定Vantage service是最新了，才会到下一步
            string dashboardID = VantageAutomationIDCollector.Instance.GetVantageAutomationIDs().GetValue("Dashboard")["DashboardButton"].ToString();
            string nextbuttonID = VantageAutomationIDCollector.Instance.GetVantageAutomationIDs().GetValue("Tutorial")["Tutorial_Next_Button"].ToString();
            string doneID = VantageAutomationIDCollector.Instance.GetVantageAutomationIDs().GetValue("Tutorial")["Tutorial_Done_Button"].ToString();
            string ratingBoxID = VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.RatingBox.clostbtn").ToString();
            //一般机器上可以看到Dashboard，但Gaming上是没有这个Button的，只有device 或 support button
            string supportID = VantageAutomationIDCollector.Instance.GetVantageAutomationIDs().GetValue("Support")["SupportMenuTitle"].ToString();
            int whichButtonIsAvailable = VantageElementAnyExistUsingCustomXPath_WhichOneMeetsCondition(new string[] { nextbuttonID, doneID, dashboardID, supportID, ratingBoxID }, 30);
            if (whichButtonIsAvailable == 2 || whichButtonIsAvailable == 3) //whichButtonIsAvailable==2 means find dashboardID, whichButtonIsAvailable ==3 means find supportID
            {
                //Tutorial已经完成过了.
                Logger.Instance.WriteLog($"GoThroughTutorial(), whichButtonIsAvailable=={whichButtonIsAvailable}, whichButtonIsAvailable==0 means find dashboardID, whichButtonIsAvailable ==2 means find supportID, means Tutorial is done.");
                return true;
            }
            if (whichButtonIsAvailable == 1) //done button is found , previous action clicked the next and not the done
            {
                SelectSegement(_requiredSegementName);
                ClickDoneAndMicrophoneAndCamera();
                Logger.Instance.WriteLog("GoThroughTutorial() , Previous has clicked Next button ? ??");
                return true;
            }
            if (whichButtonIsAvailable == 4)
            {
                VantageMouseClickElementtUsingAutomationId(ratingBoxID);
                Logger.Instance.WriteLog("GoThroughTutorial() , Dismissing rating box");
                return true;
            }
            if (VantageElementExistUsingAutomationId(nextbuttonID))
            {
                Logger.Instance.WriteLog("GoThroughTutorial() ,Next button is seen");
                string[] automationIds_TutorialOrDashboard = new string[] { VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.Tutorial.Tutorial_Next_Button").ToString(), VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.Dashboard.DashboardButton").ToString() };

                //再走Tutorial
                if (VantageElementAnyExistUsingCustomXPath_WhichOneMeetsCondition(automationIds_TutorialOrDashboard, 15) == 0)
                {
                    Console.WriteLine($"GoThroughTutorial(),Go through Tutorial, required segment is {_requiredSegementName}");

                    ClickElementUsingCustomXPath($"/Window[@Name = 'Lenovo Vantage']//*[@AutomationId='{nextbuttonID}']");
                    SelectSegement(_requiredSegementName);
                    ClickDoneAndMicrophoneAndCamera();

                }

            }
            return true;
        }
        void SelectSegement(string _requiredSegementName)
        {
            string segmentAutomationId = "";
            if (_requiredSegementName.ToLower().Contains("personal") || _requiredSegementName.ToLower().Contains("consumer"))
            {
                segmentAutomationId = "segment-choose-personal-use";
            }
            else if (_requiredSegementName.ToLower().Contains("business") || _requiredSegementName.ToLower().Contains("smb"))
            {
                segmentAutomationId = "segment-choose-business-use";
            }
            else if (_requiredSegementName.ToLower().Contains("professional") || _requiredSegementName.ToLower().Contains("commercial"))
            {
                segmentAutomationId = "segment-choose-custom-use";
            }
            if (!segmentAutomationId.Equals(""))
            {
                ClickElementUsingCustomXPath(string.Format("/Window[@Name='Lenovo Vantage']//*[@AutomationId='{0}']", segmentAutomationId));
            }
        }
        void ClickDoneAndMicrophoneAndCamera()
        {
            if (ElementExistUsingCustomXPath("/Window[@Name = 'Lenovo Vantage']//*[@AutomationId='tutorial_done_btn']"))
            {
                ClickElementUsingCustomXPath("/Window[@Name = 'Lenovo Vantage']//*[@AutomationId='tutorial_done_btn']");
                if (ElementExistUsingCustomXPath("/Window[@Name = 'Lenovo Vantage']//*[@AutomationId='Button1']", 10)) //Camera
                {
                    ClickElementUsingCustomXPath("/Window[@Name = 'Lenovo Vantage']//*[@AutomationId='Button1']");
                }
                if (ElementExistUsingCustomXPath("/Window[@Name = 'Lenovo Vantage']//*[@AutomationId='Button1']", 10)) //Microphone
                {
                    ClickElementUsingCustomXPath("/Window[@Name = 'Lenovo Vantage']//*[@AutomationId='Button1']");
                }
            }
        }
        #endregion

        public string GetEdgeUrl()
        {
            if (Process.GetProcessesByName("MicrosoftEdge").Length > 0)
                return UIAHelper.ElementGetValueUsingCustomXPathWithProcessName("/Window[@ProcessId='{0}']//Edit[@AutomationId='addressEditBox']", "ApplicationFrameHost", 15);
            else if (Process.GetProcessesByName("msedge").Length > 0)
                return UIAHelper.ElementGetValueUsingCustomXPathWithProcessName("/Window[@ProcessId='{0}']//Edit[@AutomationId='view_1022']", "msedge", 15);
            return null;
        }

        public void GoThroughMicPhoneAndCamera()
        {
            if (ElementExistUsingCustomXPath("/Window[@Name = 'Lenovo Vantage']//*[@AutomationId='Button1']", 30))
            {
                ClickElementUsingCustomXPath("/Window[@Name = 'Lenovo Vantage']//*[@AutomationId='Button1']");
                Console.WriteLine("Click enable MicPhone/Camera button.");
            }
            if (ElementExistUsingCustomXPath("/Window[@Name = 'Lenovo Vantage']//*[@AutomationId='Button1']", 10))
            {
                ClickElementUsingCustomXPath("/Window[@Name = 'Lenovo Vantage']//*[@AutomationId='Button1']");
                Console.WriteLine("Click enable MicPhone/Camera button.");
            }
        }

        public static bool RunSchedule(string taskfolder, string containsTxt)
        {

            TaskSchedulerClass scheduler = new TaskSchedulerClass();
            scheduler.Connect("", "", "", "");
            try
            {
                ITaskFolder folder = scheduler.GetFolder(taskfolder);
                var taskList = folder.GetTasks(0);
                foreach (IRegisteredTask task in taskList)
                {
                    string xml = task.Xml;
                    if (xml.Contains(containsTxt))
                    {
                        task.Run(null);
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public void DismissPopUpmessage(InformationalWebDriver driver)
        {
            driver.Session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5000);
            string xpathClose = "//Button[contains(@Name,'7601BE32-D46C-4CCD-85BB-EC869A0B24A8')]";
            try
            {
                WindowsElement close = driver.Session.FindElementByXPath(xpathClose);
                close.Click();
                Console.WriteLine("Closed 'You are now visiting the QA2 version of Lenovo Vantage' Tips.");
            }
            catch (OpenQA.Selenium.WebDriverException)
            {

            }
        }

    }
}
