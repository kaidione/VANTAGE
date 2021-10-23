using System.Diagnostics;
using System.Linq;
using System.Management;
namespace LenovoVantageTest.Utility
{
    public static class Process_Extension
    {
        public static string GetCommandLine(this Process _process)
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select CommandLine FROM Win32_Process Where ProcessId=" + _process.Id))
            using (ManagementObjectCollection foundProcess = searcher.Get())
            {
                string commandline = foundProcess.Cast<ManagementBaseObject>().SingleOrDefault()?["CommandLine"]?.ToString();
                return commandline;
            }
        }
    }
}
