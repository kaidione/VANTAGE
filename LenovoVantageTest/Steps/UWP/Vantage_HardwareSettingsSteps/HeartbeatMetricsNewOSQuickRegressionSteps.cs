using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using Microsoft.Win32;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;
using Windows.UI.Xaml.Data;
using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;
using static LenovoVantageTest.Steps.UWP.IntelligentCooling.IntelligentCoolingBaseHelper;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public sealed class HeartbeatMetricsNewOSQuickRegression
    {

        private InformationalWebDriver _webDriver;
        private string SettingsHeartBeatDataTime = "SOFTWARE\\Lenovo\\BatteryGauge";
        public string _eventLogFile = @"C:\Windows\System32\winevt\Logs\Lenovo-Sif-Companion%4Operational.evtx";
        private float _beforeMemory = 0;
        private float _beforeCpu = 0;
        List<string> HeartBeatValue = new List<string>();

        public HeartbeatMetricsNewOSQuickRegression(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        public class HeartBeatValueJson
        {
            public virtual String value { get; set; }
            public virtual String name { get; set; }
        }

        [Given(@"Change CurrentUser Regedit ""(.*)"" Value  '(.*)' to ""(.*)""")]
        public void GivenChangeCurrentUserRegeditValueToType(string pth, string vname, int value)
        {
            SetCurrentUserRegeditValue(vname, pth, value);
        }

        [Given(@"Toolbar has ""(.*)"" the HeartBeat data")]
        public void GivenToolbarHasTheHeartBeatData(string p0)
        {
            string heartTime = GetCurrentUserRegeditValue("LastHeartbeatTimeEx", SettingsHeartBeatDataTime);
            int heartTimes = Convert.ToInt32(heartTime);
            int nowUnixTime = (int)(DateTime.Now.Date - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1))).TotalSeconds;
            int tomUnixTime = (int)(DateTime.Now.Date.AddDays(1) - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1))).TotalSeconds;
            if (heartTimes > nowUnixTime && heartTimes < tomUnixTime)
            {
                bool result = false;
                List<string> eventRecordContext = new List<string>();
                using (var reader = new EventLogReader(_eventLogFile, PathType.FilePath))
                {
                    EventRecord record;
                    string toolbarPluginlevel = HSToolbarPage.GetPluginLevel("LenovoBatteryGaugePackage", "x64");
                    while ((record = reader.ReadEvent()) != null)
                    {
                        using (record)
                        {
                            if (record.FormatDescription().Contains("LenovoBatteryGaugePackage") && record.FormatDescription().Contains(toolbarPluginlevel))
                            {
                                eventRecordContext.Add(record.FormatDescription());
                            }
                        }
                    }
                    if (p0 == "no sent")
                    {
                        Assert.AreEqual(0, eventRecordContext.Count, "The toolbar has sent heartbeat value");
                    }
                    int index = 0;
                    foreach (string eventLog in eventRecordContext)
                    {
                        string str = eventLog;
                        string checkStr = string.Format("\"name\":\"Features.HardwareSettings.Power.LenovoBatteryGauge.EnableToggleButton\",\"value\":\"{0}\"", "On");
                        if (str.Contains(checkStr))
                        {
                            index++;
                            result = true;
                        }
                    }
                    if (p0 == "sent")
                    {
                        Assert.AreEqual(1, index, "The Heart Beat index hope is 1, but now is " + index.ToString());//改description
                    }
                    if (!result)
                    {
                        Assert.Fail(string.Format("Check Eventlog Failed"));
                    }
                }
            }
        }

        [StepDefinition(@"Addin is ""(.*)""")]
        public void GivenAddinIs(string p0)
        {
            string proccname = "Lenovo.Vantage.AddinHost.x86";
            string heartbeatcommandlines = "DeviceSettingsHeartbeatAddin";
            IEnumerable<string> commandLines = null;
            bool isRunning = false;
            try
            {
                Process[] allProcesses = Process.GetProcesses();
                foreach (Process procs in allProcesses)
                {
                    if (procs.ProcessName.Contains(proccname))
                    {
                        commandLines = Common.GetCommandLines(procs.ProcessName + ".exe");

                        foreach (string cmdLine in commandLines)
                        {
                            if (cmdLine.Contains(heartbeatcommandlines))
                            {
                                isRunning = true;
                                break;
                            }
                        }
                    }
                }
                if (p0 == "running")
                {
                    Assert.IsTrue(isRunning, "Addin not in running");
                }
                else if (p0 == "norunning")
                {
                    Assert.IsFalse(isRunning, "Addin is running");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Get heartbeatcommandlines faile");
            }
        }

        [Then(@"Addin will not send again")]
        public void ThenAddinWillNotSendAgain()
        {
            bool result = false;
            using (var reader = new EventLogReader(_eventLogFile, PathType.FilePath))
            {
                EventRecord record;
                string addinlevel = HSToolbarPage.GetAddinLevel();
                while ((record = reader.ReadEvent()) != null)
                {
                    using (record)
                    {
                        if (record.FormatDescription().Contains("LenovoBatteryGaugePackage") && record.FormatDescription().Contains(addinlevel))
                        {
                            result = false;
                        }
                    }
                }
            }
            Assert.IsFalse(result, "The addin is send again");
        }

        [Given(@"The region is ""(.*)"" Addin")]
        public void GivenTheRegionIsAddin(string p0)
        {
            string nowRegion = HSToolbarPage.GetMachineCurrentLocation();
            if (p0.ToLower() == "support")
            {
                Assert.IsTrue(nowRegion != "United States", "The region is not support");
            }
            if (p0.ToLower() == "nosupport")
            {
                Assert.IsTrue(nowRegion == "United States", "The region is support");
            }
        }

        [Then(@"Addin has sent the HeartBeat data")]
        public void ThenAddinHasSentTheHeartBeatData()
        {
            bool result = false;
            List<string> eventRecordContext = new List<string>();
            using (var reader = new EventLogReader(_eventLogFile, PathType.FilePath))
            {
                EventRecord record;
                string addinlevel = HSToolbarPage.GetAddinLevel();
                while ((record = reader.ReadEvent()) != null)
                {
                    using (record)
                    {
                        if (record.FormatDescription().Contains("LenovoBatteryGaugePackage") && record.FormatDescription().Contains(addinlevel))
                        {
                            eventRecordContext.Add(record.FormatDescription());
                        }
                    }
                }
                int index = 0;
                foreach (string eventLog in eventRecordContext)
                {
                    string str = eventLog;
                    string checkStr = string.Format("\"name\":\"HeartBeatAddin\",\"value\":\"{0}\"", "Enable");
                    if (str.Contains(checkStr))
                    {
                        index++;
                        result = true;
                    }
                }
                Assert.AreEqual(1, index, "The addin Beat index hope is 1, but now is " + index.ToString());//change description
                if (!result)
                {
                    Assert.Fail(string.Format("Check Eventlog Failed"));
                }
            }
        }

        [When(@"Get Memory and Cpu value")]
        public void WhenGetMemoryAndCpuValue()
        {
            var tup = HSToolbarPage.GetHeartBeatCpuAndMemory();
            _beforeMemory = tup.Item1;
            _beforeCpu = tup.Item2;
        }

        [Then(@"Check Cpu and Memory Value")]
        public void ThenCheckCpuAndMemoryValue()
        {
            var tup = HSToolbarPage.GetHeartBeatCpuAndMemory();
            float nowMemory = tup.Item1;
            float nowCpu = tup.Item2;
            if ((nowMemory - _beforeMemory) > 100)
            {
                Assert.Fail("The memory is growing 100M");
            }
            if ((nowCpu - _beforeCpu) > 1)
            {
                Assert.Fail("The cpu is growing 100M");
            }
        }

        [Then(@"Wait and Check Cpu Memory Value")]
        public void ThenWaitAndCheckCpuMemoryValue()
        {
            List<string> eventRecordContext = new List<string>();
            using (var reader = new EventLogReader(_eventLogFile, PathType.FilePath))
            {
                for (int i = 0; i < 120; i++)
                {
                    EventRecord record;
                    string addinlevel = HSToolbarPage.GetAddinLevel();
                    while ((record = reader.ReadEvent()) != null)
                    {
                        using (record)
                        {
                            if (record.FormatDescription().Contains("LenovoBatteryGaugePackage") && record.FormatDescription().Contains(addinlevel))
                            {
                                eventRecordContext.Add(record.FormatDescription());
                            }
                        }
                    }
                    if (eventRecordContext.Count > 0)
                    {
                        break;
                    }
                    Thread.Sleep(1000);
                }
                ThenCheckCpuAndMemoryValue();
            }
        }

        [Given(@"Delect the HeartBeat Regedit Value")]
        public void GivenDelectTheRelatedHPDRegeditValue()
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Lenovo\\BatteryGauge", true);
                reg.DeleteValue("LastHeartbeatTimeEx"); ;
                reg.Close();
            }
            catch (Exception)
            {
                Debug.WriteLine("LastHeartbeatTimeEx is not find");
            }
        }

        [Then(@"Get HeartBeat metric data Value")]
        public void ThenGetHeartBeatMetricDataValue()
        {
            bool result = false;
            List<string> eventRecordContext = new List<string>();
            using (var reader = new EventLogReader(_eventLogFile, PathType.FilePath))
            {
                EventRecord record;
                string addinlevel = HSToolbarPage.GetAddinLevel();
                while ((record = reader.ReadEvent()) != null)
                {
                    using (record)
                    {
                        if (record.FormatDescription().Contains("LenovoBatteryGaugePackage") && record.FormatDescription().Contains(addinlevel))
                        {
                            eventRecordContext.Add(record.FormatDescription());
                        }
                    }
                }
                int index = 0;
                foreach (string eventLog in eventRecordContext)
                {
                    string str = eventLog;
                    string pattern = @"{""name"":""(.*?)"",""value"":""(.*?)""(}?)";
                    foreach (Match match in Regex.Matches(str, pattern))
                    {
                        var items = JsonConvert.DeserializeObject<HeartBeatValueJson>(match.Value);
                        string pluginName = items.name;
                        string pluginValue = items.value;
                        if (pluginName == null || pluginValue == null)
                        {
                            Assert.Fail("The metric data is null");
                        }
                    }
                }
            }
        }

        [Then(@"Check HeartBeatValue format")]
        public void ThenCheckHeartBeatValueFormat()
        {
            bool result = false;
            List<string> eventRecordContext = new List<string>();
            using (var reader = new EventLogReader(_eventLogFile, PathType.FilePath))
            {
                EventRecord record;
                string addinlevel = HSToolbarPage.GetAddinLevel();
                while ((record = reader.ReadEvent()) != null)
                {
                    using (record)
                    {
                        if (record.FormatDescription().Contains("LenovoBatteryGaugePackage") && record.FormatDescription().Contains(addinlevel))
                        {
                            eventRecordContext.Add(record.FormatDescription());
                        }
                    }
                }
                int index = 0;
                foreach (string eventLog in eventRecordContext)
                {
                    string str = eventLog;
                    string pattern = @"{""name"":""(.*?)"",""value"":""(.*?)""(}?)";
                    foreach (Match match in Regex.Matches(str, pattern))
                    {
                        HeartBeatValue.Add(match.Value);
                    }
                }
                if (HeartBeatValue.Count < 2)
                {
                    Assert.Fail("The HeartBeatValue format is not ture");
                }
            }
        }

        [Then(@"HeartBeat data shouldn't show TrackPointSettings TouchpadSettings And AdvancedPointingSettings Mode")]
        public void ThenHeartBeatDataShouldnTShowTrackPointSettingsTouchpadSettingsAndAdvancedPointingSettingsMode()
        {
            List<string> eventRecordContext = new List<string>();
            using (var reader = new EventLogReader(_eventLogFile, PathType.FilePath))
            {
                EventRecord record;
                string addinlevel = HSToolbarPage.GetAddinLevel();
                while ((record = reader.ReadEvent()) != null)
                {
                    using (record)
                    {
                        if (record.FormatDescription().Contains("LenovoBatteryGaugePackage") && record.FormatDescription().Contains(addinlevel))
                        {
                            eventRecordContext.Add(record.FormatDescription());
                        }
                    }
                }
                foreach (string eventLog in eventRecordContext)
                {
                    string str = eventLog;
                    string checkEnabeToggleButton = string.Format("\"name\":\"Features.HardwareSettings.Input.TrackPointSettings.EnabeToggleButton");
                    string checkSpeedSliderBar = string.Format("\"name\":\"Features.HardwareSettings.Input.TrackPointSettings.SpeedSliderBar");
                    string checkLargeButton = string.Format("\"name\":\"Features.HardwareSettings.Input.TrackPointSettings.LargeButton");
                    string checkMiddleButton = string.Format("\"name\":\"Features.HardwareSettings.Input.TrackPointSettings.MiddleButton");
                    string checkMiddleButtonFunction = string.Format("\"name\":\"Features.HardwareSettings.Input.TrackPointSettings.MiddleButtonFunction");
                    string checkEnableToggleButton = string.Format("\"name\":\"Features.HardwareSettings.Input.TouchpadSettings.EnableToggleButton");
                    string checkSpeedSliderBars = string.Format("\"name\":\"Features.HardwareSettings.Input.TouchpadSettings.SpeedSliderBar");
                    string checkLargeButtons = string.Format("\"name\":\"Features.HardwareSettings.Input.TouchpadSettings.LargeButton");
                    string checkTopButton = string.Format("\"name\":\"Features.HardwareSettings.Input.TouchpadSettings.TopButton");
                    string checkEnableBottomButtonCheckBox = string.Format("\"name\":\"Features.HardwareSettings.Input.TouchpadSettings.EnableBottomButtonCheckBox");
                    string checkClassicMode = string.Format("\"name\":\"Features.HardwareSettings.Input.AdvancedPointingSettings.ClassicMode");
                    string checkReverseLeftRightZoneToggleButton = string.Format("\"name\":\"Features.HardwareSettings.Input.AdvancedPointingSettings.ReverseLeftRightZoneToggleButton");
                    bool result = str.Contains(checkEnabeToggleButton) || str.Contains(checkSpeedSliderBar) || str.Contains(checkLargeButton) || str.Contains(checkMiddleButton) || str.Contains(checkMiddleButtonFunction) || str.Contains(checkEnableToggleButton) ||
                                  str.Contains(checkSpeedSliderBars) || str.Contains(checkLargeButtons) || str.Contains(checkTopButton) || str.Contains(checkEnableBottomButtonCheckBox) || str.Contains(checkClassicMode) || str.Contains(checkReverseLeftRightZoneToggleButton);
                    if (result)
                    {
                        string logstr = "Heart Beat Value: ";
                        string pattern = @"{""name"":""(.*?)"",""value"":""(.*?)""(}?)";
                        foreach (Match match in Regex.Matches(str, pattern))
                        {
                            logstr = logstr + match.Value + "\n";
                        }
                        Assert.IsTrue(false, logstr);
                    }
                }
                Assert.IsTrue(true, "HeartBeat data shouldn't show TrackPointSettings TouchpadSettings And AdvancedPointingSettings Mode");//change description
            }
        }
        [Then(@"Windows Region Is Current Version")]
        public void ThenWindowsRegionIsCurrentVersion()
        {
            if (VantageTypePlan == VantageType.MicroFrontends)
            {
                Geo.SetCountryOrRegion(242);
            }
            else
            {
                Geo.SetCountryOrRegion(244);
            }
        }

    }
}
