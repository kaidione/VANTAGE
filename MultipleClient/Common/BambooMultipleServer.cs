using Http.Util;
using LenovoMultipleCleint.Bean;
using LenovoVantageTest.LogHelper;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using winformUI.Common;

namespace LenovoMultipleCleint.Common
{
    public class BambooMultipleServer
    {
        internal static ConcurrentQueue<string> TestQueueCommand;
        internal static string microReportFolder = @"C:\LenovoVantageTest\nginx\www\micro";
        internal static string leRepoRtFolder = @"C:\LenovoVantageTest\nginx\www\le";
        internal static string commonReportFolder = @"C:\LenovoVantageTest\nginx\www\common";
        internal static string TWReportFolder = @"C:\LenovoVantageTest\nginx\www\tw";
        internal static string ReportFolder = @"C:\LenovoVantageTest\nginx\html";

        // Common 目录适配其他项目
        static bool isCommonAutomation = false;

        public static void StartBambooMultipleServer()
        {
            TestQueueCommand = new ConcurrentQueue<string>();
            Thread receiveCommandThread = new Thread(ReceiveCommndFromTestClients);
            receiveCommandThread.IsBackground = true;

            Thread runCommandThread = new Thread(RunCommand);
            runCommandThread.IsBackground = true;

            receiveCommandThread.Start();
            runCommandThread.Start();
        }

        private static void ReceiveCommndFromTestClients()
        {
            Socket sSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            int port = 18888;
            try
            {
                string ipAddress = CommonConstStr.CurrentMachneIp;
                Console.WriteLine(ipAddress);
                IPAddress ip = IPAddress.Parse(ipAddress);
                IPEndPoint ipe = new IPEndPoint(ip, port);
                sSocket.Bind(ipe);
                sSocket.Listen(4);
                string dateTime = DateTime.Now.ToString("F");
                string newRecStr = string.Empty;
                string needBackupFile = string.Empty;
                byte[] recByte = new byte[4096];
                while (true)
                {
                    Socket serverSocket = sSocket.Accept();
                    dateTime = DateTime.Now.ToString("F");
                    Console.WriteLine(dateTime + " Have Connected ");
                    int bytes = serverSocket.Receive(recByte, recByte.Length, 0);
                    newRecStr = Encoding.ASCII.GetString(recByte, 0, bytes);
                    TestQueueCommand.Enqueue(newRecStr);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                sSocket.Close();
                MessageBox.Show(ex.Message);
            }
        }

        public static void ParseBambooResultSendToResult()
        {
            CommonConstStr.LenovoOneToMoreFlag = false;
            //时间最新目录
            DirectoryInfo bambooDirecInfo = new DirectoryInfo(CommonConstStr.bambooBuildDir);
            DateTime lastestTime = DateTime.MinValue;
            DirectoryInfo runDirectoryInfo = null;
            foreach (DirectoryInfo info in bambooDirecInfo.GetDirectories())
            {
                if (info.Name == "repositoryData" || info.Name == "_git-repositories-cache")
                {
                    continue;
                }
                if (DateTime.Compare(info.CreationTime, lastestTime) > 0)
                {
                    lastestTime = info.CreationTime;
                    runDirectoryInfo = info;
                }
            }

            string testResult = Path.Combine(runDirectoryInfo.FullName, "TestResult.xml");

            if (File.Exists(testResult))
            {
                try
                {
                    string[] allLines = File.ReadAllLines(testResult);
                    string testRun = allLines[1];
                    string[] testResultInfo = testRun.Split(' ');
                    StringBuilder sb = new StringBuilder();
                    sb.Append("bamboo.tc.lenovo.com/project/viewProject.action?projectKey=VAH$");
                    for (int i = 0; i < testResultInfo.Length; i++)
                    {
                        string line = testResultInfo[i];
                        if (line.Contains("total"))
                        {
                            sb.Append(line.Replace("=", ":") + ",");
                            sb.Append(testResultInfo[i + 1].Trim().Replace("=", ":") + ",");
                            sb.Append(testResultInfo[i + 2].Trim().Replace("=", ":") + ",$");
                        }
                        else if (line.Contains("start-time="))
                        {
                            line = line.Trim().Replace("start-time=", "");
                            string beginTime = line.Replace("\"", "") + " " + testResultInfo[i + 1].Trim().Replace("Z", "").Replace("\"", "");
                            DateTime dt;
                            DateTime.TryParse(beginTime, out dt);
                            if (dt != null)
                            {
                                sb.Append("Start time: " + dt.AddHours(8).ToString() + "$");
                            }
                        }
                        else if (line.Contains("end-time="))
                        {
                            line = line.Trim().Replace("end-time=", "");
                            string endTime = line.Replace("\"", "") + " " + testResultInfo[i + 1].Trim().Replace("Z", "").Replace("\"", "");
                            DateTime dt;
                            DateTime.TryParse(endTime, out dt);
                            if (dt != null)
                            {
                                sb.Append("End time: " + dt.AddHours(8).ToString() + "$");
                            }
                        }
                        else if (line.Contains("duration="))
                        {
                            line = line.Replace("duration=", "Duration: ").Replace(">", "");
                            sb.Append(line);
                            break;
                        }
                    }

                    string startStr = "<command-line><![CDATA[";
                    string endStr = "]]></command-line>";
                    string testCommand = allLines[2];
                    testCommand = testCommand.Replace(startStr, "");
                    testCommand = testCommand.Replace(endStr, "");

                    PushReportRequ pushReport = new PushReportRequ();
                    pushReport.clientIP = CommonConstStr.CurrentMachneIp;
                    pushReport.reportaddress = sb.ToString().Replace("\"", "").Replace("\'", "");

                    string responseStr = HttpRequest.SendPost(CommonConstStr.PushTestReport, JsonUtil.ToJSONStr(pushReport));
                    string output;
                    if (!string.IsNullOrEmpty(responseStr) && responseStr.Contains("20000"))
                    {
                        output = "Bamboo Upload Test Report Succefull \r\n" + responseStr;
                    }
                    else
                    {
                        output = "Bamboo Upload Test Report Failed \r\n" + responseStr;
                    }
                    Logger.Instance.WriteLog(output, LogType.Success);
                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteLog(ex.StackTrace, LogType.Failure);
                }
            }
        }

        public static void RunCases(object cmdStr)
        {
            try
            {
                while (true)
                {
                    if (!CommonFunction.IsRunning("nunit3-console"))
                    {
                        break;
                    }
                    Thread.Sleep(5000);
                }

                CommonConstStr.LenovoOneToMoreFlag = true;

                string newRecStr = cmdStr.ToString();
                string beginTime = string.Empty;
                string endTime = string.Empty;

                string reportLog = string.Empty;
                beginTime = DateTime.Now.ToString("G");
                string backupReportFolder = string.Empty;
                string reportFolder = string.Empty;
                string[] receiceStr = newRecStr.Split(',');
                if (receiceStr.Length > 1)
                {
                    string runStr = receiceStr[1];
                    if (File.Exists(CommonConstStr.tempFile))
                    {
                        File.Delete(CommonConstStr.tempFile);
                    }

                    CommonFunction.RunCmd(runStr, CommonConstStr.tempFile);

                    endTime = DateTime.Now.ToString("G");

                    File.WriteAllText(CommonConstStr.CommandFile, newRecStr.ToString());

                    if (!string.IsNullOrEmpty(runStr))
                    {
                        if (runStr.Contains("Commercial"))
                        {
                            reportFolder = leRepoRtFolder;
                        }
                        else if (runStr.Contains("CommonBrand"))
                        {
                            reportFolder = commonReportFolder;
                        }
                        else if (runStr.Contains("MicroFrontendsVantage"))
                        {
                            reportFolder = microReportFolder;
                        }
                        else
                        {
                            reportFolder = CommonConstStr.CommonAutomationFolder;
                            isCommonAutomation = true;
                        }
                    }

                    CommonFunction.DeleteServenLogs(reportFolder, 7);
                    File.AppendAllText(CommonConstStr.tempFile, beginTime + " Begin Run \r\n");
                    beginTime = "Start time: " + beginTime;
                    endTime = "End time: " + endTime;

                    // 进入 reportFolder 生成备份文件
                    reportFolder = Path.Combine(reportFolder, "1");
                    reportLog = Path.Combine(reportFolder, CommonConstStr.tempFile);

                    string reportStr = string.Empty;

                    if (isCommonAutomation)
                    {
                        reportStr = "http:\\" + CommonConstStr.CurrentMachneIp + "\\LenovoAutomation\\1";
                    }
                    else
                    {
                        string replaceStr = "C:\\LenovoVantageTest\\nginx\\www\\";
                        int subLen = reportFolder.Length - replaceStr.Length + 1;
                        reportStr = reportFolder.Substring(replaceStr.Length - 1, subLen);
                        reportStr = "http:\\" + CommonConstStr.CurrentMachneIp + reportStr;
                        // 移动Log 文件需要的文件路径
                        reportFolder.Replace(replaceStr, CommonConstStr.CurrentMachneIp);
                    }

                    PushReportRequ pushReport = new PushReportRequ();
                    pushReport.clientIP = CommonConstStr.CurrentMachneIp;

                    // 拼接 结果
                    StringBuilder sb = new StringBuilder();
                    string[] allLines = File.ReadAllLines(CommonConstStr.tempFile);
                    for (int i = 0; i < allLines.Length; i++)
                    {
                        string line = allLines[i];
                        if (line.Contains("Test Count:"))
                        {
                            sb.Append(line.Trim() + "$");
                        }
                        else if (line.Contains("Start time:"))
                        {
                            sb.Append(beginTime + "$");
                        }
                        else if (line.Contains("End time:"))
                        {
                            sb.Append(endTime + "$");
                        }
                        else if (line.Contains("Duration:"))
                        {
                            sb.Append(allLines[i].Trim());
                            break;
                        }
                    }



                    pushReport.reportaddress = reportStr + "$" + sb.ToString();

                    string responseStr = HttpRequest.SendPost(CommonConstStr.PushTestReport, JsonUtil.ToJSONStr(pushReport));
                    string output;
                    if (!string.IsNullOrEmpty(responseStr) && responseStr.Contains("20000"))
                    {
                        output = "Upload Test Report Succefull \r\n" + responseStr;
                    }
                    else
                    {
                        output = "Upload Test Report Failed \r\n" + responseStr;
                    }

                    beginTime = DateTime.Now.ToString("G");
                    File.AppendAllText(CommonConstStr.tempFile, beginTime + output + " End Test.\r\n");

                    try
                    {
                        if (!string.IsNullOrEmpty(reportLog) && File.Exists(CommonConstStr.tempFile))
                        {
                            File.Move(CommonConstStr.tempFile, reportLog);
                        }
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private static void RunCommand()
        {
            string newRecStr = string.Empty;
            string dateTime = string.Empty;
            string reportLog = string.Empty;
            while (true)
            {
                if (CommonFunction.IsRunning("nunit3-console"))
                {
                    while (true)
                    {
                        if (!CommonFunction.IsRunning("nunit3-console"))
                        {
                            break;
                        }
                        Thread.Sleep(3000);
                    }
                }

                try
                {
                    if (TestQueueCommand.Count > 0)
                    {
                        bool tryGetReceiveCommand = TestQueueCommand.TryDequeue(out newRecStr);
                        if (!tryGetReceiveCommand) continue;
                        RunCases(newRecStr);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    File.AppendAllText(CommonConstStr.tempFile, ex.Message + " End Test.\r\n");
                }
                Thread.Sleep(5000);
            }
        }

    }
}
