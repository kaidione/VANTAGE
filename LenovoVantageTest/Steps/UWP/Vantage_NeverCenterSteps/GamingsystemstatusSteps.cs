using AventStack.ExtentReports.Gherkin.Model;
using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Collections;
using System.Diagnostics;
using System.Management;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingsystemstatusSteps
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;
        private string cpuMaxClockSpeed, cpuName, gpuName;
        private string ramName, memoryAvaliable;
        private string diskName, diskSize, diskFreeSize, diskFreeSize1, strSSD = "", strHDD = "";
        private Int64 memoryCapacity2 = 0, memoryAvaliable2 = 0, diskSize2 = 0, diskFreeSize2 = 0, diskUsageSize2 = 0, gpuAdapterRam = 0;
        public BasicReport basicReport;

        public GamingsystemstatusSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Get cpu name and capacity")]
        public void GetCPUInfo()
        {
            string CPUName = DesktopPowerManagementHelper.RunCmd("wmic cpu get Name", true);
            string CPUMaxClockSpeed = DesktopPowerManagementHelper.RunCmd("wmic cpu get MaxclockSpeed", true);
            string[] CPUNameappInfo = CPUName.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string[] CPUMaxClockSpeedappInfo = CPUMaxClockSpeed.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < CPUNameappInfo.Length; i++)
            {
                if (CPUNameappInfo[i].Trim() == "Name")
                {
                    cpuName = CPUNameappInfo[i + 1].Replace("\r", "");
                    break;
                }
            }
            for (int i = 0; i < CPUMaxClockSpeedappInfo.Length; i++)
            {
                if (CPUMaxClockSpeedappInfo[i].Trim() == "MaxClockSpeed")
                {
                    cpuMaxClockSpeed = CPUMaxClockSpeedappInfo[i + 1];
                    break;
                }
            }
        }

        [Given(@"Get RAM Info")]
        public void GetRAMInfo()
        {
            string pattern = @"([^\.^\d]*)";
            Regex rx = new Regex(pattern);
            string MemoryName = DesktopPowerManagementHelper.RunCmd("wmic MEMORYCHIP get Manufacturer", true);
            string MemoryCapacity = DesktopPowerManagementHelper.RunCmd("wmic MEMORYCHIP get Capacity", true);
            string[] MemoryNameappInfo = MemoryName.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string[] MemoryCapacityappInfo = MemoryCapacity.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string MemoryCapacity2 = DesktopPowerManagementHelper.RunCmd("systeminfo", true);
            string[] MemoryCapacityappInfo2 = MemoryCapacity2.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < MemoryNameappInfo.Length; i++)
            {
                if (MemoryNameappInfo[i].Trim() == "Manufacturer")
                {
                    ramName = MemoryNameappInfo[i + 1];
                    break;
                }
            }
            for (int i = 0; i < MemoryCapacityappInfo.Length; i++)
            {
                if (MemoryCapacityappInfo[i].Trim() == "Capacity")
                {
                    for (int j = i + 1; j < MemoryCapacityappInfo.Length; j++)
                    {
                        string tempStr = MemoryCapacityappInfo[j].Replace("\r", "");
                        tempStr = tempStr.Replace(" ", "");
                        bool state = rx.IsMatch(tempStr);
                        if ((state) && (tempStr != ""))
                        {
                            Int64 tem = Convert.ToInt64(tempStr);
                            memoryCapacity2 = memoryCapacity2 + tem;
                            state = false;
                        }
                        else break;
                    }
                    break;
                }
            }
            memoryCapacity2 = memoryCapacity2 / 1073741824;
            for (int i = 0; i < MemoryCapacityappInfo2.Length; i++)
            {
                if (MemoryCapacityappInfo2[i].Trim() == "Available Physical Memory")
                {
                    memoryAvaliable = MemoryCapacityappInfo2[i + 1];
                }
            }
            memoryAvaliable = Regex.Replace(memoryAvaliable, @"[^\d]*", "");
            memoryAvaliable2 = Convert.ToInt64(memoryAvaliable) / 1000;
        }

        [Given(@"Get SSD Info")]
        public void GetDiskInfo()
        {
            const string pattern = "^[0-9]*$";
            Regex rx = new Regex(pattern);
            string DiskName = DesktopPowerManagementHelper.RunCmd("wmic DISKDRIVE get Caption", true);
            string DiskSize = DesktopPowerManagementHelper.RunCmd("wmic DISKDRIVE get Size", true);
            string DiskFreeSize = DesktopPowerManagementHelper.RunCmd("wmic logicaldisk get FreeSpace", true);
            string[] DiskNameappInfo = DiskName.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string[] DiskSizeappInfo = DiskSize.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string[] DiskFreeSizeappInfo = DiskFreeSize.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < DiskNameappInfo.Length; i++)
            {
                if (DiskNameappInfo[i].Trim() == "Caption")
                {
                    diskName = DiskNameappInfo[i + 1];
                    break;
                }
            }
            for (int i = 0; i < DiskSizeappInfo.Length; i++)
            {
                if (DiskSizeappInfo[i].Trim() == "Size")
                {
                    diskSize = DiskSizeappInfo[i + 1];

                    break;
                }
            }
            diskSize2 = Convert.ToInt64(diskSize.Trim()) / 1073741824;
            for (int i = 0; i < DiskFreeSizeappInfo.Length; i++)
            {
                if (DiskFreeSizeappInfo[i].Trim() == "FreeSpace")
                {
                    diskFreeSize = DiskFreeSizeappInfo[i + 1];
                    diskFreeSize1 = DiskFreeSizeappInfo[i + 2];
                    break;
                }
            }
            diskFreeSize2 = Convert.ToInt64(diskFreeSize) + Convert.ToInt64(diskFreeSize1);
            diskFreeSize2 /= 1073741824;
            diskUsageSize2 = diskSize2 - diskFreeSize2;
            strSSD = "SSD名字：" + diskName + "SSD容量:" + diskSize2 + "\r\nSSD已用空间:" + diskUsageSize2;
        }

        [Given(@"Get HDD Info")]
        public void GetHDDInfo()
        {
            string HDDDiskName = DesktopPowerManagementHelper.RunCmd("wmic DISKDRIVE get Caption", true);
            string HDDDiskSize = DesktopPowerManagementHelper.RunCmd("wmic DISKDRIVE get Size", true);
            string HDDDiskFreeSize = DesktopPowerManagementHelper.RunCmd("wmic logicaldisk get FreeSpace", true);
            ArrayList NameList = new ArrayList();
            ArrayList SizeList = new ArrayList();
            string[] HDDDiskNameappInfo = HDDDiskName.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string[] HDDDiskSizeappInfo = HDDDiskSize.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string[] HDDDiskFreeSizeappInfo = HDDDiskFreeSize.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < HDDDiskNameappInfo.Length; i++)
            {
                if (HDDDiskNameappInfo[i].Trim() == "Caption")
                {
                    for (int k = i + 1; k < HDDDiskNameappInfo.Length; k++)
                    {
                        NameList.Add(HDDDiskNameappInfo[k]);
                        if (HDDDiskNameappInfo[k + 1] == "\r")
                        {
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < HDDDiskSizeappInfo.Length; i++)
            {
                if (HDDDiskSizeappInfo[i].Trim() == "Size")
                {
                    for (int k = i + 1; k < HDDDiskNameappInfo.Length; k++)
                    {
                        try
                        {
                            HDDDiskSizeappInfo[k].Remove(HDDDiskSizeappInfo[k].Length - 2, 2);
                            SizeList.Add(Convert.ToInt64(HDDDiskSizeappInfo[k].Trim()) / 1073741824);
                        }
                        catch { }

                        if (HDDDiskSizeappInfo[k + 1] == "\r")
                        {
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < NameList.Count; i++)
            {

                strHDD = "DIsk名字：" + NameList[i] + "DISK容量:" + SizeList[i];
            }
        }

        [Then(@"write Info")]
        public void WriteInfo2()
        {
            string str = strHDD + strSSD;
            Hooks.WriteInfoReport(str);
        }

        [When(@"the user clicking the info on system status")]
        public void ClickInfoBtn()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu, "GamingDeviceMenu is null");
            int timeout = 0;
            while (_nerveCenterPages.SystemStatusInfoLink == null)
            {
                timeout++;
                Thread.Sleep(TimeSpan.FromSeconds(1));
                if (timeout > 5)
                    break;
            }
            Assert.IsNotNull(_nerveCenterPages.SystemStatusInfoLink, "SystemStatusInfoLink is null");
            _nerveCenterPages.SystemStatusInfoLink.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        [Then(@"it will be switch hardware interface")]
        public void HardwareInterface()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu, "The GamingDeviceMenu not found");
            Assert.IsNotNull(_nerveCenterPages.myDeviceheadertitle, "The myDeviceheadertitle not found");
            Assert.IsNotNull(_nerveCenterPages.MyDevice, "The MyDevice not found");
            Assert.IsNotNull(_nerveCenterPages.MyDeviceSerialNumber, "The MyDeviceSerialNumber not found");
            Assert.IsNotNull(_nerveCenterPages.MyDeviceProductNumber, "The MyDeviceProductNumber not found");
            Assert.IsNotNull(_nerveCenterPages.MyDeviceBiosVersion, "The MyDeviceBiosVersion not found");
            Assert.IsNotNull(_nerveCenterPages.MyDeviceMaintenanceNeeded, "The MyDeviceMaintenanceNeeded not found");
        }

        [Then(@"cpu will have the same module as the task manager")]
        public void CompareCPUInfo()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SystemStatusCPUInfo);
            string VanCpuText = _nerveCenterPages.SystemStatusCPUInfo.GetAttribute("Name");
            Assert.IsNotNull(cpuName, "Get CpuName is null");
            cpuName = cpuName.Remove(cpuName.Length - 1, 1);
            if (VanCpuText.Contains(cpuName))
            {
                Assert.IsTrue(true, "Cpu name not true");
            }
            string[] VanCPUText = VanCpuText.Split('/');
            float VanCPUmaxclockspeed = Convert.ToSingle(VanCPUText[1].Remove(VanCPUText[1].Length - 3, 3));
            float cpumaxclockspeed2 = Convert.ToSingle(cpuMaxClockSpeed) / 1000;
            if ((cpumaxclockspeed2 - 1 < VanCPUmaxclockspeed) || (VanCPUmaxclockspeed < cpumaxclockspeed2 + 1))
            {
                Assert.IsTrue(true, "Cpu maxclockspeed not true");
            }
        }

        [Given(@"Get GPU name and capacity")]
        public void GetGpuInfo()
        {
            ManagementObjectSearcher objvide = new ManagementObjectSearcher("select * from Win32_VideoController");
            foreach (ManagementObject obj in objvide.Get())
            {
                gpuName = (string)obj["Name"];
                gpuAdapterRam = Convert.ToInt64(obj["AdapterRAM"]);
                gpuAdapterRam = gpuAdapterRam / 1073741824;
            }
        }

        [Then(@"GPU will have the same module as the task manager")]
        public void GPUSameTask()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SystemStatusGPUInfo);
            string VanGPUText = _nerveCenterPages.SystemStatusGPUInfo.GetAttribute("Name");
            string[] VanGPUText2 = VanGPUText.Split('/');
            float VanGPUcap = Convert.ToSingle(VanGPUText2[1].Remove(VanGPUText2[1].Length - 2, 2));//remove
            if (VanGPUText2[0].Contains(gpuName))
            {
                Assert.IsTrue(true, "Gpu name not true");
            }
            if ((gpuAdapterRam - 1 <= VanGPUcap) || (VanGPUcap <= gpuAdapterRam + 1))
            {
                Assert.IsTrue(true, "Gpu capacity not true");
            }
        }

        [Then(@"RAM will have the same module as the task manager")]
        public void RAMSameTask()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SystemStatusRAMInfo);
            string VanRAMText = _nerveCenterPages.SystemStatusRAMInfo.GetAttribute("Name");
            Console.WriteLine("Info:" + VanRAMText);
            string[] VanRAMText2 = VanRAMText.Split('/');
            string VanRAMText3 = Regex.Replace(VanRAMText2[0], @"[^\d.\d]", ""); //VanRAMText2[0].Split(' ');
            string VanRAMText4 = Regex.Replace(VanRAMText2[1], @"[^\d.\d]", "");
            float VanRAMcap = Convert.ToSingle(VanRAMText4);    //Convert.ToSingle(VanRAMText2[1].Remove(VanRAMText2[1].Length - 2, 2));//remove
            float VanRAMusage = Convert.ToSingle(VanRAMText3);
            float taskRamusage = memoryCapacity2 - memoryAvaliable2;
            if ((taskRamusage - 1 <= VanRAMusage) || (VanRAMusage <= taskRamusage + 1))
            {
                Assert.IsTrue(true, "RAM usage not true");
            }
            if ((memoryCapacity2 - 1 <= VanRAMcap) || (VanRAMcap <= memoryCapacity2 + 1))
            {
                Assert.IsTrue(true, "RAM capacity not true");
            }
        }

        [Given(@"open task manager")]
        public void AwakeTaskManager()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(@"C:\WINDOWS\system32\taskmgr.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start(startInfo);
            var systemVersion = Common.GetSystemVersion().ToString();
            var windowsSearch = VantageCommonHelper.FindElementByIdIsEnabled(VantageConstContent.TypeHereToSearch);
            VantageCommonHelper.SetMouseClick("105", "367");
            Thread.Sleep(1000);
        }

        [Given(@"click task manager")]
        public void ClickTaskManager()
        {
            VantageCommonHelper.SetMouseClick("105", "435");
            Thread.Sleep(1000);
        }

        [When(@"the user click system tools")]
        public void ClickSysTools()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu, "GamingDeviceMenu is null");
            Assert.IsNotNull(_nerveCenterPages.GamingSystemTools, "GamingSystemTools is null");
            Assert.IsNotNull(_nerveCenterPages.SystemToolsSystemUpdate, "SystemToolsSystemUpdate is null");
            _nerveCenterPages.SystemToolsSystemUpdate.Click();
        }

        [Given(@"the user click homepage btn")]
        public void ClickHomePageBtn()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu);
            Assert.IsNotNull(_nerveCenterPages.YLogo);
            _nerveCenterPages.YLogo.Click();
        }

        [When(@"the user click MaxSize btn")]
        public void ClickMaxBten()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.YLogo);
            Assert.IsNotNull(_nerveCenterPages.VantageMaximize);
            _nerveCenterPages.VantageMaximize.Click();
        }
    }
}
