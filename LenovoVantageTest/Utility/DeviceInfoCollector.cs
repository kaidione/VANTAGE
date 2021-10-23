using Microsoft.VisualBasic.Devices;
using System;
using System.Diagnostics;
using System.Management;
using System.Threading;

namespace LenovoVantageTest.Utility
{
    public class DeviceInfoCollector
    {


        public string GetProcessorName()
        {
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                foreach (PropertyData pd in mo.Properties)
                {
                    if (pd.Name == "Name")
                    {
                        return mo[pd.Name].ToString();
                    }
                }
            }
            return "";
        }

        public string GetMemoryInfo()
        {
            ComputerInfo ci = new ComputerInfo();
            return ToGB(ci.TotalPhysicalMemory, 1024.0).Replace("GB", "");
        }

        public string GetDiskSize()
        {
            ManagementClass mc = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                foreach (PropertyData pd in mo.Properties)
                {
                    if (pd.Name.ToLower() == "size")
                    {
                        return ConvertBytes(mo[pd.Name].ToString(), 3).ToString();
                    }
                }
            }
            return "";
        }

        public string ToGB(double size, double mod)
        {
            String[] units = new String[] { "B", "KB", "MB", "GB", "TB", "PB" };
            int i = 0;
            while (size >= mod)
            {
                size /= mod;
                i++;
            }
            return Math.Round(size, 1) + units[i];
        }
        public decimal ConvertBytes(string b, int iteration)
        {
            long iter = 1;
            for (int i = 0; i < iteration; i++)
                iter *= 1024;
            return Math.Round((Convert.ToDecimal(b)) / Convert.ToDecimal(iter), 2, MidpointRounding.AwayFromZero);
        }

        public bool DiskSizeFreeSpaceSmallThan100()
        {
            ManagementClass mc = new ManagementClass("Win32_LogicalDisk");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                foreach (PropertyData pd in mo.Properties)
                {
                    if (pd.Name.ToLower() == "freespace")
                    {
                        if (ConvertBytes(mo[pd.Name].ToString(), 3) > 0)
                            return true;
                    }
                }
            }
            return false;
        }

        public bool MemoryAvailableLessThan100()
        {
            string total = GetMemoryInfo().Replace("GB", "");
            string free = ToGB(MemoryAvailable(), 1024.0);
            double rate = 0;
            if (free.Contains("MB"))
            {

                free = free.Replace("MB", "");
                rate = float.Parse(free) / float.Parse(total) / 1024;
            }
            else
            {
                free = free.Replace("GB", "");
                rate = float.Parse(free) / float.Parse(total) / 1024;
            }
            if (rate * 100 < 100)
            {
                return true;
            }
            return false;
        }

        public static long MemoryAvailable()
        {
            long availablebytes = 0;
            ManagementClass mos = new ManagementClass("Win32_OperatingSystem");
            foreach (ManagementObject mo in mos.GetInstances())
            {
                if (mo["FreePhysicalMemory"] != null)
                {
                    availablebytes = 1024 * long.Parse(mo["FreePhysicalMemory"].ToString());
                }
            }
            return availablebytes;
        }

        public static double CPUUsage()
        {
            double CPUUsage;
            PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            cpuCounter.NextValue();
            Thread.Sleep(1000);
            CPUUsage = cpuCounter.NextValue();
            return Math.Round(CPUUsage, 2);
        }

        public static double MemoryUsage()
        {
            double capacity = 0, available = 0;

            //Get Memory capacity
            ManagementClass cimobject1 = new ManagementClass("Win32_PhysicalMemory");
            ManagementObjectCollection moc1 = cimobject1.GetInstances();
            foreach (ManagementObject mo1 in moc1)
            {
                capacity += ((Math.Round(Int64.Parse(mo1.Properties["Capacity"].Value.ToString()) / 1024 / 1024 / 1024.0, 1)));
            }
            moc1.Dispose();
            cimobject1.Dispose();

            //Get memory available
            ManagementClass cimobject2 = new ManagementClass("Win32_PerfFormattedData_PerfOS_Memory");
            ManagementObjectCollection moc2 = cimobject2.GetInstances();
            foreach (ManagementObject mo2 in moc2)
            {
                available += ((Math.Round(Int64.Parse(mo2.Properties["AvailableMBytes"].Value.ToString()) / 1024.0, 1)));

            }
            moc2.Dispose();
            cimobject2.Dispose();

            double MemoryUsage = Math.Round((capacity - available) / capacity * 100, 2);
            return MemoryUsage;
        }

        /// <summary>
        /// 获得电脑SN号
        /// </summary>
        public static string GetPcsnString()
        {
            var pcsn = "";
            try
            {
                var search = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
                var mobos = search.Get();
                foreach (var temp in mobos)
                {
                    object serial = temp["SerialNumber"]; // ProcessorID if you use Win32_CPU
                    pcsn = serial.ToString();
                    Console.WriteLine(pcsn);

                    if
                    (
                        !string.IsNullOrEmpty(pcsn)
                        && pcsn != "To be filled by O.E.M" //没有找到
                        && !pcsn.Contains("O.E.M")
                        && !pcsn.Contains("OEM")
                        && !pcsn.Contains("Default")
                    )
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Default");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error to Get SN");
                //Debug.WriteLine(e);
                // 无法处理
            }

            return pcsn;
        }
    }
}
