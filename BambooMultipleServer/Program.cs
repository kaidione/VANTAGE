using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace BambooMultipleServer
{
    class Program
    {
        // Server
        internal static ConcurrentQueue<string> TestQueueCommand;
        internal static string microReportFolder = @"C:\LenovoVantageTest\nginx\www\micro";
        internal static string leRepoRtFolder = @"C:\LenovoVantageTest\nginx\www\le";
        internal static string commonReportFolder = @"C:\LenovoVantageTest\nginx\www\common";
        internal static string TWReportFolder = @"C:\LenovoVantageTest\nginx\www\tw";
        internal static string ReportFolder = @"C:\LenovoVantageTest\nginx\html";

        internal static string microBackupReportFolder = @"C:\LenovoVantageTest\nginx\backupReport\micro_backupReport";
        internal static string leBackupReportFolder = @"C:\LenovoVantageTest\nginx\backupReport\le_backupReport";
        internal static string commonBackupReportFolder = @"C:\LenovoVantageTest\nginx\backupReport\common_backupReport";
        internal static string TWBackupReportFolder = @"C:\LenovoVantageTest\nginx\backupReport\TW_backupReport";
        internal static string BackupReportFolder = @"C:\LenovoVantageTest\nginx\backupReport\backupReport";

        static void Main(string[] args)
        {

            string IP = "10.119.169.121";
            int port = 18888;
            IPAddress ip = IPAddress.Parse(IP);
            var clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(ip, port);
            clientSocket.Connect(endPoint);
            string timeMark = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string runCase = string.Format(timeMark + ", " + "nunit3-console.exe C:\\LenovoVantageTest\\SpecflowTest\\LenovoVantageTest.dll --testparam \"{0}\" --where \"{1}\"", "VantageUWPType=MicroFrontendsVantage", "cat=EnergyStarLogo", IP);
            Console.WriteLine("Begin Send Message: " + runCase);
            byte[] message = Encoding.ASCII.GetBytes(runCase);
            clientSocket.Send(message);
            Console.WriteLine("Send Message is :" + Encoding.ASCII.GetString(message));
            clientSocket.Close();
            Debug.WriteLine("Main");
            /*
                        TestQueueCommand = new ConcurrentQueue<string>();
                        Thread receiveCommandThread = new Thread(ReceiveCommndFromTestClients);
                        Thread runCommandThread = new Thread(RunCommand);
                        Thread autotestUpgrade = new Thread(AutotestUpgrade);
                        receiveCommandThread.Start();
                        runCommandThread.Start();
                        //autotestUpgrade.Start();
                        while (true)
                        {
                            ConsoleKeyInfo q = Console.ReadKey();
                            if (q.KeyChar == 'q')
                            {
                                break;
                            }
                        }

            */
        }


        private static void ReceiveCommndFromTestClients()
        {
            Socket sSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            int port = 18888;
            long address = 0L;
            IPAddress[] addressList = Dns.GetHostByName(Dns.GetHostName()).AddressList;
            foreach (IPAddress adr in addressList)
            {
                if (!adr.ToString().Contains("192.168"))
                {
                    address = adr.Address;
                    break;
                }
            }
            try
            {
                IPAddress addr = new IPAddress(address);
                string ipAddress = addr.ToString();
                Console.WriteLine(ipAddress);
                IPAddress ip = IPAddress.Parse(ipAddress);
                IPEndPoint ipe = new IPEndPoint(ip, port);
                sSocket.Bind(ipe);
                sSocket.Listen(4);
                string dateTime = DateTime.Now.ToString("F");
                Console.WriteLine(dateTime + " Begin listen，Please wait");
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
            }
        }

        private static Object lockObj = new Object();
        private static void AutotestUpgrade()
        {
            lock (lockObj)
            {
                while (true)
                {
                    Thread.Sleep(1 * 60 * 1000);
                }
            }
            // 300 代表 需要更新 服务器
        }

        private static void RunCommand()
        {
            string oldtimeMark = string.Empty;
            string backupTime = string.Empty;
            string oldTime = string.Empty;
            string newRecStr = string.Empty;

            while (true)
            {
                string dateTime = DateTime.Now.ToString("F");
                if (Common.GetProcessStatus("nunit3-console"))
                {
                    Console.WriteLine("Wait Bamboo To Finish");
                    Console.WriteLine(dateTime + " Wait Finish\n");
                    while (true)
                    {
                        if (!Common.GetRunningProcess("nunit3-console"))
                        {
                            break;
                        }
                        Thread.Sleep(5000);
                    }
                    Console.WriteLine();
                    dateTime = DateTime.Now.ToString("F");
                    Console.WriteLine(dateTime + " End Test\n");
                }


                if (TestQueueCommand.Count > 0)
                {
                    dateTime = DateTime.Now.ToString("F");
                    string backupReportFolder = string.Empty;
                    string reportFolder = string.Empty;
                    bool tryGetReceiveCommand = TestQueueCommand.TryDequeue(out newRecStr);
                    if (!tryGetReceiveCommand) continue;
                    string[] receiceStr = newRecStr.Split(',');
                    if (receiceStr.Length > 1)
                    {
                        if (newRecStr.Contains("LenovoVantageTest.dll"))
                        {
                            backupTime = receiceStr[0];
                            Console.WriteLine("Receive Cmd Time: " + backupTime);
                            dateTime = DateTime.Now.ToString("F");
                            string runStr = receiceStr[1];
                            string runAsTw = "RunAsTW";
                            bool isRunTw = false;
                            if (runStr.Contains(runAsTw))
                            {
                                isRunTw = true;
                            }
                            Common.RunCmd(runStr);
                            if (!string.IsNullOrEmpty(runStr))
                            {
                                if (!isRunTw && runStr.Contains("Commercial"))
                                {
                                    backupReportFolder = leBackupReportFolder;
                                    reportFolder = leRepoRtFolder;
                                }
                                else if (!isRunTw && runStr.Contains("CommonBrand"))
                                {
                                    backupReportFolder = commonBackupReportFolder;
                                    reportFolder = commonReportFolder;
                                }
                                else if (!isRunTw && runStr.Contains("MicroFrontendsVantage"))
                                {
                                    backupReportFolder = microBackupReportFolder;
                                    reportFolder = microReportFolder;
                                }
                                else if (isRunTw)
                                {
                                    backupReportFolder = TWBackupReportFolder;
                                    reportFolder = TWReportFolder;
                                }
                                else
                                {
                                    backupReportFolder = BackupReportFolder;
                                    reportFolder = ReportFolder;
                                }
                            }

                            if (!string.IsNullOrEmpty(backupTime) && oldTime != backupTime)
                            {
                                oldTime = backupTime;
                                string moveFolder = Path.Combine(backupReportFolder, "backupReport_" + backupTime);
                                Console.WriteLine("Backup Report: " + moveFolder);
                                if (Directory.GetFiles(reportFolder).Length > 0)
                                {
                                    Common.CopyDirectory(reportFolder, moveFolder);
                                    Common.DeleteServenLogs(backupReportFolder, 7);
                                    Common.DeleteFolder(reportFolder);
                                }
                            }
                            Console.WriteLine("Begin Run " + receiceStr[1]);
                            Console.WriteLine(dateTime + " Wait Finish....");
                            while (true)
                            {
                                if (!Common.GetRunningProcess("nunit3-console"))
                                {
                                    break;
                                }
                                Thread.Sleep(5000);
                            }
                            Console.WriteLine();
                            dateTime = DateTime.Now.ToString("F");
                            Console.WriteLine(dateTime + " End Test.");
                        }
                    }
                }
                Thread.Sleep(5000);
            }
        }

        private enum RunPlanType
        {
            Commercial,
            CommonBrand,
            MicroFrontendsVantages,
            Unknown
        }

        private static RunPlanType GetRunPlanType(string runStr)
        {
            if (runStr.Contains("Commercial"))
            {
                return RunPlanType.Commercial;
            }
            else if (runStr.Contains("CommonBrand"))
            {
                return RunPlanType.CommonBrand;
            }
            else
            {
                return RunPlanType.MicroFrontendsVantages;
            }
        }

        private static void BackupReport(string backupTime)
        {
            string[] microFiles = Directory.GetFiles(microReportFolder);
            if (microFiles.Length > 1)
            {
                string moveFolder = Path.Combine(microBackupReportFolder, "backupReport_" + backupTime);
                Common.CopyDirectory(microReportFolder, moveFolder);
                Common.DeleteFolder(microReportFolder);
            }
            string[] leFiles = Directory.GetFiles(leRepoRtFolder);
            if (leFiles.Length > 1)
            {
                string moveFolder = Path.Combine(leBackupReportFolder, "backupReport_" + backupTime);
                Common.CopyDirectory(leRepoRtFolder, moveFolder);
                Common.DeleteFolder(leRepoRtFolder);
            }
            string[] commonFiles = Directory.GetFiles(commonReportFolder);
            if (commonFiles.Length > 0)
            {
                string moveFolder = Path.Combine(commonBackupReportFolder, "backupReport_" + backupTime);
                Common.CopyDirectory(commonReportFolder, moveFolder);
                Common.DeleteFolder(commonReportFolder);
            }
        }

        public static void SendReportToBamboo(Socket sSocket, string reportPath)
        {
            if (Directory.GetFiles(reportPath).Length > 0)
            {
                if (File.Exists(reportPath))
                {
                    FileInfo EzoneFile = new FileInfo(reportPath);
                    FileStream EzoneStream = EzoneFile.OpenRead();
                    int packetSize = 1000;
                    int packetCount = (int)(EzoneFile.Length / ((long)packetSize));
                    int lastPacketData = (int)(EzoneFile.Length - ((long)packetSize * packetCount));
                    byte[] data = new byte[packetSize];
                    SendVarData(sSocket, Encoding.Unicode.GetBytes(packetSize.ToString()));
                    SendVarData(sSocket, Encoding.Unicode.GetBytes(packetCount.ToString()));
                    for (int i = 0; i < packetCount; i++)
                    {
                        EzoneStream.Read(data, 0, data.Length);
                        SendVarData(sSocket, data);
                    }
                    if (lastPacketData != 0)
                    {
                        data = new byte[lastPacketData];
                        EzoneStream.Read(data, 0, data.Length);
                        SendVarData(sSocket, data);
                    }
                    sSocket.Shutdown(SocketShutdown.Both);
                }
            }
        }

        public static int SendVarData(Socket s, byte[] data)
        {
            int total = 0;
            int size = data.Length;
            int dataleft = size;
            int sent;
            byte[] datasize = new byte[4];
            datasize = BitConverter.GetBytes(size);
            sent = s.Send(datasize);

            while (total < size)
            {
                sent = s.Send(data, total, dataleft, SocketFlags.None);
                total += sent;
                dataleft -= sent;
            }

            return total;
        }

    }
}
