using System.Management.Automation;

namespace LenovoVantageTest
{
    public static class PowerShellCommands
    {
        public const string disableWiFiCommandPath = @"TestBinaries%\Scripts\DisableWiFi.ps1";

        public const string enableWiFiCommandPath = @"";

        public const string testNetworkBoost_Path = @".\download.bat";

        public static void DisableWiFiCommand()
        {
            RunScript(disableWiFiCommandPath);
        }

        public static void EnableWiFiCommand()
        {
            RunScript("");
        }

        public static void RunScript(string fileName)
        {
            //string str6 = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

            using (RunspaceInvoke invoke = new RunspaceInvoke())
            {
                invoke.Invoke(fileName);
            }
        }

        public static void TestNetworkBoost()
        {
            RunScript(testNetworkBoost_Path);
        }
    }
}
