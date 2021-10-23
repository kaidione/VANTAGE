using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Threading;

namespace LenovoVantageTest.Commands
{
    public class CmdCommands : CommandBase
    {
        private const string disableWiFiCommand = "netsh interface set interface Wi-Fi disable";

        private const string enableWiFiCommand = "netsh interface set interface Wi-Fi enable";

        private const string disbaleEthernet = "netsh interface set interface Ethernet disable";

        private const string enableEthernet = "netsh interface set interface Ethernet enable";

        private const string turnOffFireWall = "netsh advfirewall set allprofiles state off";

        private const string turnOnFireWall = "netsh advfirewall set allprofiles state on";

        private const string disableUAC = @"reg.exe ADD HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v ConsentPromptBehaviorAdmin /t REG_DWORD /d 0 /f";

        private const string enableUAC = @"reg.exe ADD HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System /v ConsentPromptBehaviorAdmin /t REG_DWORD /d 1 /f";

        private static string dischargeStatusFilePath = Path.Combine(VantageConstContent.DataPath, "Data\\Tools\\DischargeStatus.exe");

        private const string deleteVantageEventLog = "wevtutil cl Lenovo-Sif-Companion/Operational";

        private static string nginxPath = @"C:\LenovoVantageTest\nginx\nginx.exe";

        private static string nginxWorkPath = @"C:\LenovoVantageTest\nginx";

        public static void DisableWiFi()
        {
            RunCmd(disableWiFiCommand);
            Thread.Sleep(5000);
        }

        public static void EnableWiFi()
        {
            RunCmd(enableWiFiCommand);
            Thread.Sleep(5000);
        }

        public static void DisableEthernet()
        {
            RunCmd(disbaleEthernet);
            Thread.Sleep(5000);
        }

        /// <summary>
        /// Update Enable Ethernet, enable ethernet is slower than disable, check the network status
        /// </summary>
        public static void EnableEthernet()
        {
            while (NetWork.CheckCurrentNetWorkStatus() != true)
            {
                RunCmd(enableEthernet);
            }
            Thread.Sleep(TimeSpan.FromSeconds(60));
        }

        public static void TurnOffFireWall()
        {
            RunCmd(turnOffFireWall);
            Thread.Sleep(5000);
        }

        public static void TurnOnFireWall()
        {
            RunCmd(turnOnFireWall);
            Thread.Sleep(5000);
        }

        public static void DisableUAC()
        {
            RunCmd(disableUAC);
            Thread.Sleep(5000);
        }

        public static void EnableUAC()
        {
            RunCmd(enableUAC);
            Thread.Sleep(5000);
        }

        public static void DisableFirewall()
        {
            List<string> cmds = new List<string>
            {
                //disable all net adapters
                $"Netsh advfirewall set allprofile state off"
            };
            RunPowershellCmdlet(cmds);
            Thread.Sleep(2000);
        }

        public static void DisableAdapter()
        {
            List<string> cmds = new List<string>
            {
                //disable all net adapters
                $"disable-NetAdapter -Name * -Confirm:$False"
            };
            RunPowershellCmdlet(cmds);
            Thread.Sleep(5000);
        }
        public static void EnableAdapter()
        {
            List<string> cmds = new List<string>
            {
                //enable all net adapters
                $"Enable-NetAdapter -Name * -Confirm:$False"
            };
            RunPowershellCmdlet(cmds);
            Thread.Sleep(5000);
        }

        public static void ReduceBatteryValue()
        {
            if (File.Exists(dischargeStatusFilePath))
            {
                RunCmd(dischargeStatusFilePath + " start 1 ");
            }
        }

        public static void IncreaseBatteryValue()
        {
            if (File.Exists(dischargeStatusFilePath))
            {
                RunCmd(dischargeStatusFilePath + " stop 1 ");
            }
        }

        public static void DeleteVantageEventLog()
        {
            RunCmd(deleteVantageEventLog);
            Thread.Sleep(1000);
            List<string> eventRecordContext = new List<string>();
            using (var reader = new EventLogReader(@"C:\Windows\System32\winevt\Logs\Lenovo-Sif-Companion%4Operational.evtx", PathType.FilePath))
            {
                EventRecord record;
                while ((record = reader.ReadEvent()) != null)
                {
                    using (record)
                    {
                        eventRecordContext.Add(record.FormatDescription());
                    }
                }
                if (eventRecordContext.Count != 0)
                {
                    RunCmd(deleteVantageEventLog);
                    Thread.Sleep(1000);
                }
            }
        }

        public static void OpenNginx()
        {
            bool nginxFlag = true;
            if (File.Exists(nginxPath))
            {
                Process[] processList = Process.GetProcesses();
                foreach (Process process in processList)
                {
                    if (process.ProcessName.ToLower() == "nginx")
                    {
                        nginxFlag = false;
                        break;
                    }
                }
                if (nginxFlag)
                {
                    var startInfo = new ProcessStartInfo();
                    startInfo.WorkingDirectory = nginxWorkPath;
                    startInfo.FileName = nginxPath;
                    Process.Start(startInfo);
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
