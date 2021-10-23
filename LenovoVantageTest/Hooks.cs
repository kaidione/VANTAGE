using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using TechTalk.SpecFlow;

namespace LenovoVantageTest
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private static InformationalWebDriver webDriver;

        public static string applicationId;
        public IObjectContainer objectContainer;
        public static BasicReport basicReport;

        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        public static string ReportFileName;

        public static string projectDiectory;
        public static string reportPath;
        public static string reportZipPath;
        public static string title;
        public static string contentInfo;
        public static bool runMultipleFlag = false;
        public static List<string> featureResult = new List<string>();

        public Hooks(IObjectContainer newObjectContainer)
        {
            objectContainer = newObjectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            // Netsh advfirewall set allprofile state off
            Commands.CmdCommands.DisableFirewall();
            Commands.CmdCommands.OpenNginx();
            IPAddress addr = new IPAddress(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].Address);
            string ipAddress = addr.ToString();
            title = ipAddress + "_" + DateTime.Now.ToString(Constants.DATETIMEFORMATFORPATH) + "_VantageTest";
            reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Report");
            string workingDirectory = Assembly.GetExecutingAssembly().Location;
            DirectoryInfo directoryInfo = Directory.GetParent(workingDirectory);
            if (directoryInfo != null)
            {
                if (directoryInfo.Parent != null && directoryInfo.Parent.Parent != null)
                {
                    projectDiectory = directoryInfo.Parent.Parent.FullName;
                }
                else
                {
                    projectDiectory = @"C:\LenovoVantageTest";
                    runMultipleFlag = true;
                }
            }
            reportZipPath = Path.Combine(projectDiectory, "Report");
            if (Directory.Exists(reportPath))
            {
                Directory.Delete(reportPath, true);
            }

            Common.CreateDirectory(reportPath);
            Common.CreateDirectory(reportZipPath);

            ReportFileName = title + ".html";

            string reportHtmlPath = Path.Combine(reportPath, ReportFileName);

            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(reportHtmlPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            basicReport = new BasicReport();
            Common.KillProcess("AutomationTestRunner", false);
            AddLogToReport($"[{DateTime.Now}]***************************BeforeTestRun is Doing Begin***************************", Color.Green);
            AddLogToReport($"[{DateTime.Now}]AutomationTestRunner is Already Killed!", Color.Black);
            Constants.CurrentAgentMachineIp = ipAddress;
            Common.MakeDataLink();
            AddLogToReport($"[{DateTime.Now}]MakeDataLink Method is Doing Down!", Color.Black);
            string oobeSettingsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"oobe\info\userchoices.xml");
            if (File.Exists(oobeSettingsFile))
            {
                File.Delete(oobeSettingsFile);//Marcus:In case this file is locked , it could impact all cases with LID & metrics, Let it throw the exception
            }

            LoadSpecificElementFile.LoadSpecificElement();
            UwpAppInfo comp = UwpAppManagement.SearchUwpAppByName(VantageConstContent.GetVantageUwpAppName());

            if (LoadSpecificElementFile.DebugFlag || comp == null)
            {
                VantageCommonHelper.InstallVantage(true);
                var session = VantageCommonHelper.LaunchSystemUwp(VantageConstContent.VantageUwpAppid);
                VantageCommonHelper.OObeNetVantage30(session, true);
            }

            FileManager.EmptyAFolder(Path.Combine(VantageConstContent.VantageErrorLogs));
            FileManager.EmptyAFolder(VantageConstContent.VantageServiceLocalLogsFolderPath);
            FileManager.EmptyAFolder(VantageConstContent.VantageShellLocalLogsFolderPath);
            Common.CloseWindowsProxy();
            AddLogToReport($"[{DateTime.Now}]CloseWindowsProxy Method is Doing Down!", Color.Black);
            initializeAssembly();
            AddLogToReport($"[{DateTime.Now}]initializeAssembly Method is Doing Down!", Color.Black);
            AddLogToReport($"[{DateTime.Now}]***************************BeforeTestRun is Doing Over Begin To Test************************\n", Color.Green);
        }

        static void initializeAssembly()
        {
            string dllpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "IdeaPadNoteBookPluginDll");
            AppDomain.CurrentDomain.AssemblyResolve += delegate (object sender, ResolveEventArgs args)
            {
                string assembleFie = (args.Name.Contains(',')) ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name;
                assembleFie += ".dll";
                string targetPath = Path.Combine(dllpath, assembleFie);
                try
                {
                    return Assembly.LoadFile(targetPath);
                }
                catch (Exception ex)
                {
                    return null;
                }
            };
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext _featureContext)
        {
            //Create dynamic feature name
            LogHelper.Logger.Instance.WriteLog($"*************************** Feature {_featureContext.FeatureInfo.Title} starting ************************");
            AddLogToReport($"[{DateTime.Now}]*************************** Feature {_featureContext.FeatureInfo.Title} starting ***************************", Color.DarkBlue);
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
            Constants.SetCurrentCommentType(FeatureContext.Current.FeatureInfo.FolderPath);
            Console.WriteLine("BeforeFeature");
            KeyboardMouse.ShowDesktop();
            featureResult.Clear();
        }

        [AfterFeature]
        public static void AfterFeature(FeatureContext _featureContext)
        {
            Common.CloseWindowsProxy();
            LogHelper.Logger.Instance.WriteLog($"*************************** Feature {_featureContext.FeatureInfo.Title} ended ************************\r\n\r\n");
            AddLogToReport($"[{DateTime.Now}]*************************** Feature {_featureContext.FeatureInfo.Title} ended ***************************\r\n\r\n", Color.DarkBlue);
            string[] featureResultArray = featureResult.ToArray();

            for (int i = featureResult.Count - 1; i >= 0; i--)
            {
                string result = featureResult[i];
                if (result.Contains("Successful"))
                {
                    //LogHelper.Logger.Instance.WriteLog(result, LogHelper.LogType.Success, _featureContext.FeatureInfo.Title, @"C:\VantageTestResult");
                }
                else if (result.Contains("ScenarioInfo"))
                {
                    //LogHelper.Logger.Instance.WriteLog(result, LogHelper.LogType.Information, _featureContext.FeatureInfo.Title, @"C:\VantageTestResult");
                }
                else
                {
                    //LogHelper.Logger.Instance.WriteLog(result, LogHelper.LogType.Failure, _featureContext.FeatureInfo.Title, @"C:\VantageTestResult");
                }
            }

        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext _scenarioContext)
        {
            UwpAppInfo comp = UwpAppManagement.SearchUwpAppByName(VantageConstContent.GetVantageUwpAppName());
            if (comp == null)
            {
                VantageCommonHelper.InstallVantage(true);
                var session = VantageCommonHelper.LaunchSystemUwp(VantageConstContent.VantageUwpAppid);
                VantageCommonHelper.OObeNetVantage30(session, true);
            }

            Common.StartService(VantageConstContent.IMCServiceName);  //Start IMC Service
            LogHelper.Logger.Instance.WriteLog($"_______________________ Scenario {_scenarioContext.ScenarioInfo.Title} starting _______________________");
            AddLogToReport($"[{DateTime.Now}]_______________________ Scenario {_scenarioContext.ScenarioInfo.Title} starting _______________________\r\n\r", Color.DarkBlue);
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title, "Current Scenario Tags Info:" + string.Join(" @", ScenarioContext.Current.ScenarioInfo.Tags) + "\r\n" + FeatureContext.Current.FeatureInfo.Description);
            basicReport.title = ScenarioContext.Current.ScenarioInfo.Title;
            basicReport.extent = extent;
            basicReport.test = scenario;
            if (featureResult.Count > 0)
            {
                featureResult.Add("*************************************************");
            }

            featureResult.Add(ScenarioContext.Current.ScenarioInfo.Title + " ScenarioInfo");
            var factory = new BaseTestClass();
            var appInstance = factory.LaunchWinApplication(LoadSpecificElementFile.ApplicationId);
            webDriver = appInstance;

            objectContainer.RegisterInstanceAs<Utility.InformationalWebDriver>(appInstance);
            string nextButtonLocator = "tutorial_next_btn";
            string personalUseSegmentLocator = "segment-choose-personal-use";
            string doneButtonLocator = "tutorial_done_btn";

            if (IsElementPresent(doneButtonLocator))
            {
                if (!NerveCenterHelper.GetMachineIsGaming())
                {
                    WindowsElement personalUseSegment = webDriver.Session.FindElementByAccessibilityId(personalUseSegmentLocator);
                    if (personalUseSegment != null)
                    {
                        personalUseSegment.Click();
                    }
                }
                WindowsElement doneButton = webDriver.Session.FindElementByAccessibilityId(doneButtonLocator);
                doneButton.Click();
            }

            if (IsElementPresent(nextButtonLocator))
            {
                WindowsElement nextButton = webDriver.Session.FindElementByAccessibilityId(nextButtonLocator);
                nextButton.Click();
                if (!NerveCenterHelper.GetMachineIsGaming())
                {
                    WindowsElement personalUseSegment = webDriver.Session.FindElementByAccessibilityId(personalUseSegmentLocator);
                    if (personalUseSegment != null)
                    {
                        personalUseSegment?.Click();
                        personalUseSegment?.Click();
                    }
                }
                WindowsElement doneButton = webDriver.Session.FindElementByAccessibilityId(doneButtonLocator);
                doneButton.Click();
            }

            VantageCommonHelper.CloseAlertWindow(webDriver.Session);
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext _scenarioContext)
        {
            LogHelper.Logger.Instance.WriteLog($"_______________________ Scenario {_scenarioContext.ScenarioInfo.Title} ended _______________________ \r\n");
            AddLogToReport($"[{DateTime.Now}]_______________________ Scenario {_scenarioContext.ScenarioInfo.Title} ended _______________________\r\n\r\n", Color.DarkBlue);
            try
            {
                Common.KillProcess("SystemSettings", true);
                Common.KillProcess("MicrosoftEdge", true);
                Common.KillProcess("msedge", true);
                Common.KillProcess(VantageConstContent.VantageProcessName, true);
                Common.KillProcess("Battle.net", true);
                Common.KillProcess("Wow", true);
                Common.KillProcess("XtuCLI", true);
                Common.KillProcess("Narrator", true);
                Common.KillProcess("NarratorQuickStart", true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Common.KillProcess(VantageConstContent.VantageProcessName, true);
            }
        }

        public static void WriteInfoReport(string content)
        {
            contentInfo = content;
        }

        [AfterStep]
        public void AfterStep()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            //Define the parameters in the operation step and add to the step
            string _info = null;
            if (ScenarioStepContext.Current.StepInfo.MultilineText != null)
            {
                _info = ScenarioStepContext.Current.StepInfo.MultilineText;
            }
            if (ScenarioStepContext.Current.StepInfo.Table != null)
            {
                _info = ScenarioStepContext.Current.StepInfo.Table.ToString();
            }
            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text, _info);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text, _info);
                }
                else if (stepType == "Then")
                {
                    if (ScenarioStepContext.Current.StepInfo.Text == "write Info")
                    {
                        scenario.CreateNode<Then>("Write Info log : " + contentInfo);
                    }
                    else if (ScenarioStepContext.Current.StepInfo.Text.Contains("Write log") && ScenarioStepContext.Current.StepInfo.Text.Contains("to report"))
                    {
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text, _info).Log(Status.Warning, "Information:\r\n" + contentInfo);
                    }
                    else if (ScenarioStepContext.Current.StepInfo.Text.Contains("Check SealedBattery Toast") && contentInfo != null)
                    {
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text, _info).Log(Status.Fail, "Information:\r\n" + contentInfo);
                        contentInfo = null;
                    }
                    else
                    {
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text, _info);
                    }
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text, _info);
                }
                featureResult.Add(ScenarioStepContext.Current.StepInfo.Text + " Successful");
                AddLogToReport($"[{ DateTime.Now}]" + stepType + " " + ScenarioStepContext.Current.StepInfo.Text, Color.Green);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text, _info).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text, _info).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text, _info).Fail(ScenarioContext.Current.TestError.Message);
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text, _info).Fail(ScenarioContext.Current.TestError.Message);
                }
                featureResult.Add(ScenarioStepContext.Current.StepInfo.Text + " Failed : " + ScenarioContext.Current.TestError.Message);

                string folderName = ScenarioContext.Current.ScenarioInfo.Title + "_" + DateTime.Now.ToString(Constants.DATETIMEFORMATFORPATH);
                VantageCommonHelper.BackupLog(folderName);
                AddLogToReport($"[{ DateTime.Now}]" + stepType + " " + ScenarioStepContext.Current.StepInfo.Text, Color.Red);
                AddLogToReport($"[{ DateTime.Now}]" + ScenarioContext.Current.TestError.Message, Color.Red);
                basicReport.AddScreenshotToReport(title);
            }
            extent.Flush();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();
            string reportPathZip = Path.Combine(reportZipPath, DateTime.Now.ToString(Constants.DATETIMEFORMATFORPATH) + "_report.zip");
            // write Report to Ngingx HTMLFolder
            string reportFolder = @"C:\LenovoVantageTest\nginx\html";
            string multipleReportFolder = string.Empty;
            // Common 目录适配其他项目
            string CommonAutomationFolder = @"C:\LenovoAutomationTest\nginx\html\common";
            string microReportFolder = @"C:\LenovoVantageTest\nginx\www\micro";
            string leRepoRtFolder = @"C:\LenovoVantageTest\nginx\www\le";
            string commonReportFolder = @"C:\LenovoVantageTest\nginx\www\common";
            string twReportFolder = @"C:\LenovoVantageTest\nginx\www\tw";


            if (LoadSpecificElementFile.RunAsTw)
            {
                reportFolder = twReportFolder;
            }
            else
            {
                switch (VantageConstContent.VantageTypePlan)
                {
                    case VantageConstContent.VantageType.Common:
                        reportFolder = commonReportFolder;
                        break;
                    case VantageConstContent.VantageType.LE:
                        reportFolder = leRepoRtFolder;
                        break;
                    case VantageConstContent.VantageType.MicroFrontends:
                        reportFolder = microReportFolder;
                        break;
                    default:
                        reportFolder = CommonAutomationFolder;
                        break;
                }
            }

            // 进入 reportFolder 生成备份文件
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string updateMultiple = desktopPath + "\\LenovoMultipleClient" + "\\LenovoMultipleClient.exe";

            try
            {
                if (File.Exists(updateMultiple) && !Common.GetRunningProcess("wrapper") && Directory.Exists(reportFolder))
                {
                    DirectoryInfo reportIndex = new DirectoryInfo(reportFolder);
                    FileSystemInfo[] files = reportIndex.GetFileSystemInfos();
                    int max = 0;
                    foreach (FileSystemInfo folder in files)
                    {
                        if (folder is DirectoryInfo)
                        {
                            string folderName = folder.Name;
                            int index = -1;
                            if (int.TryParse(folderName, out index))
                            {
                                if (index > max)
                                {
                                    max = index;
                                }
                            }
                        }
                    }
                    max = max + 1;
                    multipleReportFolder = Path.Combine(reportFolder, max.ToString());
                    Directory.CreateDirectory(multipleReportFolder);

                    for (int i = max; i > 1; i--)
                    {
                        multipleReportFolder = Path.Combine(reportFolder, i.ToString());
                        if (Directory.Exists(multipleReportFolder))
                        {
                            FileManager.EmptyAFolder(multipleReportFolder);
                            string preReportFolder = Path.Combine(reportFolder, (i - 1).ToString());
                            if (Directory.Exists(preReportFolder))
                            {
                                Common.CopyDirectory(preReportFolder, multipleReportFolder);
                            }
                        }
                    }
                    string reportFile = Path.Combine(reportFolder, "index.html");
                    multipleReportFolder = Path.Combine(reportFolder, "1");
                    if (Directory.Exists(multipleReportFolder))
                    {
                        FileManager.EmptyAFolder(multipleReportFolder);
                    }
                    else
                    {
                        Directory.CreateDirectory(multipleReportFolder);
                    }
                    try
                    {
                        if (!string.IsNullOrEmpty(multipleReportFolder) && Directory.Exists(multipleReportFolder))
                        {
                            string multipleReportFile = Path.Combine(multipleReportFolder, "index.html");
                            Common.CopyDirectory(reportPath, multipleReportFolder);
                            string multipleSourceFile = Path.Combine(reportFolder, ReportFileName);
                            if (File.Exists(multipleSourceFile))
                            {
                                if (File.Exists(multipleReportFile))
                                {
                                    File.Delete(multipleReportFile);
                                }
                            }
                            string sourceFile = Path.Combine(multipleReportFolder, ReportFileName);
                            FileInfo fileInfo = new FileInfo(sourceFile);
                            fileInfo.MoveTo(multipleReportFile);
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.Logger.Instance.WriteLog("MultipleReportFile CreateDirectory:" + ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Logger.Instance.WriteLog("UpdateMultiple CreateDirectory:" + ex.StackTrace);
            }


            BasicReport.CreateZip(reportPath, reportPathZip);
            Common.KillProcess("WinAppDriver", true);
            Common.AutomaticShutdown(18, LoadSpecificElementFile.DebugFlag, 30);
        }

        private bool IsElementPresent(string locator)
        {
            try
            {
                webDriver.Session.FindElementByAccessibilityId(locator);
                return true;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }

        public static void AddLogToReport(string log, Color color)
        {
            try
            {
                if (extent != null)
                {
                    string head = null;
                    lock (extent)
                    {
                        if (string.IsNullOrEmpty(log))
                        {
                            extent.AddTestRunnerLogs("<div>&ensp;</div>");
                        }
                        else
                        {
                            if (log.StartsWith("\n")) extent.AddTestRunnerLogs("<div>&ensp;</div>");
                            head = $"<div style=\"color:{ColorTranslator.ToHtml(color)}\">";
                            extent.AddTestRunnerLogs($"{head}<b>{log}</b></div>");
                            if (log.EndsWith("\n")) extent.AddTestRunnerLogs("<div>&ensp;</div>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
