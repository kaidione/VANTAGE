using BambooMultipleServer;
using LenovoVantageTest.Utility;
using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ACDCServerConsole
{
    class Program
    {
        // Server
        internal static ConcurrentQueue<string> TestQueueCommand;

        static void Main(string[] args)
        {
            /*
            RunClient(args[0]);
            Thread.Sleep(1000);
            return;*/
            TestQueueCommand = new ConcurrentQueue<string>();
            Thread receiveCommandThread = new Thread(ReceiveCommndFromTestClients);
            receiveCommandThread.Start();
            Thread runCmd = new Thread(RunCommand);
            runCmd.Start();
            Console.ReadLine();

        }

        private static void ReceiveCommndFromTestClients()
        {
            Socket sSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            int port = 19999;
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
                sSocket.Listen(40);
                string dateTime = DateTime.Now.ToString("F");
                Console.WriteLine(dateTime + " ACDC Server Begin listen，Please wait");
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

        private static void RunClient(string automationId)
        {
            BaseSessionTestClass baseTestClass = new BaseSessionTestClass();
            var desktopSession = baseTestClass.DesktopSession();
            var windowsElement = Common.FindElementsByTime(desktopSession, "AutomationId", automationId);
            if (windowsElement != null)
            {
                windowsElement.Click();
            }

        }

        private static void RunCommand()
        {
            string newRecStr;
            string backupTime;
            while (true)
            {
                string dateTime = DateTime.Now.ToString("F");

                if (TestQueueCommand.Count > 0)
                {
                    bool tryGetReceiveCommand = TestQueueCommand.TryDequeue(out newRecStr);
                    if (!tryGetReceiveCommand) continue;
                    string[] receiceStr = newRecStr.Split(',');
                    if (receiceStr.Length > 1)
                    {
                        backupTime = receiceStr[0];
                        Console.WriteLine("Receive Cmd Time: " + backupTime);
                        dateTime = DateTime.Now.ToString("F");
                        string runStr = receiceStr[1];
                        string acdcpath = Path.Combine(Environment.CurrentDirectory, @"AcDcClient\ACDCServerConsole.exe");
                        Process pro = Process.Start(acdcpath, runStr);
                        pro.WaitForExit();

                        int Result = pro.ExitCode;//程序B退出回传值 #32770
                        if (Result == 1)//接收到程序B退出代码"1"
                        {

                        }
                    }
                }
                Thread.Sleep(5000);
            }
        }


    }
}
