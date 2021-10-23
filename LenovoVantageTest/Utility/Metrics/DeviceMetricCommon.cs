using HttpAnalyzerHelper;
using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using TaskScheduler;

namespace LenovoVantageTest.Metrics
{

    public class DeviceMetricCommon
    {

        private HttpAnalyzerAgent ha = null;

        public const string systemSettingsfile = @"%localappdata%\Lenovo\ImController\PluginData\LenovoDeviceMetricsPlugin\DeviceMetricsSystemSettings-2.5.xml";
        public const string systemSettingsfileFolder = @"%localappdata%\Lenovo\ImController\PluginData\LenovoDeviceMetricsPlugin\";

        public DeviceMetricCommon(string urlMonitor)
        {
            if (ha == null)
            {
                ha = new HttpAnalyzerAgent(urlMonitor, false);
            }
        }

        public void StartHttpAnalyzer()
        {
            ha.Start();
        }

        public void StopHttpAnalyzer()
        {
            ha.Stop();
        }

        public static bool RunDmSchedule()
        {

            TaskSchedulerClass scheduler = new TaskSchedulerClass();
            scheduler.Connect("", "", "", "");
            try
            {
                ITaskFolder folder = scheduler.GetFolder("\\Lenovo\\ImController\\TimeBasedEvents");
                var taskList = folder.GetTasks(0);
                foreach (IRegisteredTask task in taskList)
                {
                    string xml = task.Xml;
                    if (xml.Contains("plugin=\"LenovoDeviceMetricsPlugin\""))
                    {
                        task.Run(null);
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                //Logger.Log(Logger.LogSeverity.Error, "Fail to RunDmSchedule" + ex.Message);
                return false;
            }
            return true;
        }

        public void WaitForResult(int timeout = 120)
        {
            if (timeout > 180)
                timeout = 35;

            DateTime begin = DateTime.Now;
            int count = 0;
            while ((DateTime.Now - begin).TotalSeconds < timeout)
            {
                count = ha.TrafficListCaptured.Count;
                System.Threading.Thread.Sleep(2000);
                if (count == ha.TrafficListCaptured.Count && count != 0)
                {
                    System.Threading.Thread.Sleep(2000);
                    break;
                }
            }

        }

        public List<IDictionary<string, object>> GetResult()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<IDictionary<string, object>> ListDic = new List<IDictionary<string, object>>();
            try
            {
                foreach (var item in ha.TrafficListCaptured)
                {
                    string prefix = "json=";
                    if (item.StartsWith(prefix))
                    {
                        string jsonStr = item.Substring(prefix.Length);
                        // Logger.Log(Logger.LogSeverity.Information, "jsonStr:"+ jsonStr);
                        dynamic json = js.Deserialize<dynamic>(jsonStr);
                        dynamic e_data = json["events"][0]["e_data"];
                        IDictionary<string, object> dic = e_data as IDictionary<string, object>;
                        ListDic.Add(dic);
                    }

                }
                return ListDic;
            }
            catch (Exception e)
            {
                //Logger.Log(Logger.LogSeverity.Critical,e.Message);
                return null;
            }

        }

        private static string Decompress(string compress)
        {
            string deRes = "";
            try
            {
                byte[] byteArray = Convert.FromBase64String(compress);
                deRes = StringCompressor.Decompress(byteArray);

            }
            catch (Exception ex)
            {
                return deRes;
            }
            return deRes;
        }

    }


}

