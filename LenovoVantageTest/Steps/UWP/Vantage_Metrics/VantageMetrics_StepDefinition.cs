using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using LenovoVantageTest.Utility.Metrics;
using Microsoft.Win32;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Xml;
using TaskScheduler;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.VantageMetrics
{
    [Binding]
    class VantageMetrics_StepDefinition
    {
        private readonly InformationalWebDriver webDriver;
        private DasheboardPage_NarrowWindow navMenu;
        private PreferenceSettingPage preferSettingPage;
        private DashBoardPage dashBoardPage;

        public VantageMetrics_StepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Given(@"Set Metric (.*)")]
        public void GivenSetMetric(string status)
        {
            if (status.Equals("on"))
            {
                VantageMetric.SetMetricToggle(VantageMetric.EMetricStatus.on);
            }
            else if (status.Equals("off"))
            {
                VantageMetric.SetMetricToggle(VantageMetric.EMetricStatus.off);
            }

        }
        [Given(@"Set Metrics (.*) By Regedit")]
        public void GivenSetMetricsByRegedit(string status)
        {
            int res = 0;
            if (status.Equals("on"))
            {
                res = 1;
            }
            RegistryHelp.SetRegistryKeyValue(@"HKCU\Software\Lenovo\Metrics\com.lenovo.companion", res);
        }


        [Given(@"Launch Http Traffic Capturer")]
        public void GivenLaunchHttpTrafficCapturer()
        {
            VantageMetric.GetInstance().Launch();
        }

        [Given(@"Start Capture")]
        public void GivenStartCapture()
        {
            VantageMetric.GetInstance().Stop();
            VantageMetric.GetInstance().Start(Constants.LUDPServer);
        }

        [Given(@"Start Capture with URL StgDXP")]
        public void GivenStartCaptureWithURLStgDXP()
        {
            VantageMetric.GetInstance().Stop();
            VantageMetric.GetInstance().Start(Constants.StgDXPServer);
        }

        [Given(@"Start Capture with URL CSWServer")]
        public void GivenStartCaptureWithURLCSWServer()
        {
            VantageMetric.GetInstance().Stop();
            string currentWebServer = Utility.Common.GetCurrentWebServerFromNewConfig();
            if (currentWebServer.Contains("qa") || currentWebServer.Contains("dev"))
            {
                Console.WriteLine($"Stating capture http traffic from {Constants.StgDXPServer}...");
                VantageMetric.GetInstance().Start(Constants.StgDXPServer);
            }
            else
            {
                Console.WriteLine($"Stating capture http traffic from {Constants.CSWServer}...");
                VantageMetric.GetInstance().Start(Constants.CSWServer);
            }
        }

        [Given(@"Start Capture with AutoResponse")]
        public void GivenStartCaptureWithAutoResponse()
        {
            VantageMetric.GetInstance().Stop();
            string url = (string)RegistryHelp.GetRegistryKeyValue(Constants.vantage_upe_url);
            VantageMetric.GetInstance().Start(Constants.LUDPServer, url, url, 403);
        }


        [StepDefinition(@"Stop Capture")]
        public void GivenStopCapture()
        {
            VantageMetric.GetInstance().Stop();
        }

        [StepDefinition(@"clear data with wait time (.*)")]
        public void GivenClearData(int time = 20)
        {
            VantageMetric.GetInstance().Clear(time);
        }

        [StepDefinition(@"clear data")]
        public void GivenClearData()
        {
            VantageMetric.GetInstance().Clear(20);
        }

        [Then(@"the metric data is as expected with Test (.*) and Name (.*) and Timeout (.*)")]
        public void ThenTheMetricDataIsAsExpectedWithTestAndNameAndTimeout(string testID, string Name, int timeout)
        {
            bool result = VantageMetric.GetInstance().MetricIsAsExpected(testID, Name, timeout);
            string toggle = RegistryHelp.GetRegistryKeyValue(Constants.metricToggle).ToString();
            Console.WriteLine("current metric toggle value is {0}", toggle);
            Assert.IsTrue(result, "Verify metric data for " + testID + " with Name " + Name);
        }

        [StepDefinition(@"the metric data is partial match with Test (.*) and Name (.*) and Timeout (.*)")]
        public void ThenTheMetricDataIsPartialMatchWithTestVANAndNameAndTimeout(string testID, string Name, int timeout)
        {
            bool result = VantageMetric.GetInstance().MetricIsAsExpected(testID, Name, timeout, true);
            string toggle = RegistryHelp.GetRegistryKeyValue(Constants.metricToggle).ToString();
            Console.WriteLine("current metric toggle value is {0}", toggle);
            Assert.IsTrue(result, "Verify metric partial match for " + testID + " with Name " + Name);
        }

        [Then(@"the metric is not including the keywords (.*)")]
        public void ThenTheMetricIsNotIncludingTheKeywords(string _keyWord)
        {
            bool result = VantageMetric.GetInstance().MetricIsNotIncludingTheKeywords(_keyWord);
            Assert.IsTrue(result, "Verify the metric is not including the keywords: " + _keyWord);

        }



        [Then(@"the metric data is contains with Test (.*) and Name (.*) and Timeout (.*)")]
        [StepDefinition(@"the metric data matches Test (.*) and Name (.*) in (\d{1,}) seconds")]
        public void ThenTheMetricDataIsContainsWithTestAndNameAndTimeout(string testID, string Name, int timeout)
        {
            bool result = VantageMetric.GetInstance().MetricIsAsExpected(testID, Name, timeout, true);
            Assert.IsTrue(result, "Verify metric data for " + testID + " with Name " + Name);
        }

        [StepDefinition(@"by compare raw keys one by one , the metrics data in DB with Test '(.*)' and Name '(.*)' matches Fiddler caught in '(\d{1,})' seconds")]
        public void compareMetricsUsingRawData(string testID, string Name, int timeout)
        {
            bool result = VantageMetric.GetInstance().MetricIsAsExpected(testID, Name);
            Assert.IsTrue(result, "Verify metric data for " + testID + " with Name " + Name);
        }

        [Then(@"Captured no metrics")]
        public void CaputredNoMetrics()
        {
            int count = VantageMetric.GetInstance().GetMetricCount();
            Assert.AreEqual(0, count, "check if Captured no metric,actual metric count is {0}", count);
        }

        [Then(@"the Hero banner content metric is correct")]
        public void TheHeroBannerContentMetricIsCorrect()
        {
            int count = VantageMetric.GetInstance().GetExpectMetrics("Position", "1").Count;
            string xpath = "//ListItem[contains(@AutomationId,'ngb-slide')]";
            BasePage basePage = new BasePage();
            int expCount = basePage.GetWindowsElementList(webDriver.Session, xpath).Count();
            Assert.AreEqual(expCount, count, "check if Captured no metric,actual metric count is {0}", count);
        }

        [StepDefinition(@"There is no metrics")]
        public void ThenThereIsNoMetrics()
        {
            Assert.IsTrue(VantageMetric.GetInstance().allCapturedTraffic().Count == 0);
        }

        [Then(@"the metric data does not contains with Test (.*) and Name (.*) and Timeout (.*)")]
        public void ThenMetricDataDoesNotContainsWithTestAndNameAndTimeout(string testID, string Name, int timeout)
        {
            bool result = VantageMetric.GetInstance().MetricIsAsExpected(testID, Name, timeout, true);
            Assert.IsFalse(result, "Verify metric does not contains with " + testID + " with Name " + Name);

        }

        [Then(@"Verify The Content Is Delivered From")]
        public void ThenVerifyTheContentIsDeliveredFrom(Table table)
        {
            bool verifyResult = false;
            string url1 = table.Rows[0][0]; //vantage.csw.lenovo.com
            string url2 = table.Rows[0][1]; //dxp.lenovo.com
            string requestMethod = table.Rows[0][2]; //GET
            string containsValue = table.Rows[0][3]; //Page=support
            string timeOut = table.Rows[0][4]; //20

            ICollection<Fiddler.Session> listCapturedTraffic = null;
            try
            {
                listCapturedTraffic = VantageMetric.GetInstance().tryCapturedTraffic(int.Parse(timeOut), url1, url2, containsValue);
                VantageMetric.GetInstance().Stop(); //need to stop Fiddler proxy
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception of VantageMetric.GetInstance().allCapturedTraffic():" + e.ToString());
            }

            Console.WriteLine("listCapturedTraffic.Count = " + listCapturedTraffic.Count + "\r\n");

            if (listCapturedTraffic.Count > 0)
            {
                foreach (var session in listCapturedTraffic)
                {
                    if (session != null && session.RequestMethod.Equals(requestMethod))
                    {
                        //print the full request/response for debugging
                        Console.WriteLine(VantageMetric.GetInstance().getRequest(session));
                        Console.WriteLine(VantageMetric.GetInstance().getResponse(session) + "\r\n");

                        //e.g. GET https://vantage.csw.lenovo.com/api/v1/features?Lang=en&GEO=us&OEM=LENOVO&OS=Windows&Segment=Consumer&Brand=think&Page=support
                        //or GET https://stg.dxp.lenovo.com/api/v1/features?Lang=en&GEO=us&OEM=LENOVO&OS=Windows&Segment=Consumer&Brand=think&Page=support
                        if ((session.fullUrl.Contains(url1) || session.fullUrl.Contains(url2)) && session.fullUrl.Contains(containsValue))
                        {
                            verifyResult = true;
                            break;
                        }
                    }

                }
            }
            Assert.IsTrue(verifyResult, "Verify the " + containsValue + " content is delivered from " + url1 + " or " + url2);
        }

        [StepDefinition(@"NO metric data is sent out to (.*)")]
        public void NoMetricSent2Lenovo(string _domainName)
        {

            Assert.IsTrue(VantageMetric.GetInstance().allCapturedTraffic().Count == 0);
        }

        [StepDefinition(@"(.*) Sending Metrics")]
        public void SetAnonymousMetrics(string _enableOrDisable)
        {
            string regKey = @"HKCU\Software\Lenovo\Metrics\com.lenovo.companion";
            if (_enableOrDisable.ToLower().Contains("enable"))
            {
                RegistryHelp.SetRegistryKeyValuePlus(regKey, 1, RegistryValueKind.String);
            }
            else
            {
                RegistryHelp.SetRegistryKeyValuePlus(regKey, 0, RegistryValueKind.String);
            }
        }

        [Given(@"Make DeviceMetrics DogFooding (.*)")]
        public void MakeDeviceMetricsDogFoodingEnable(String defaultText)
        {
            String dogFoodingKey = @"HKLM\SOFTWARE\WOW6432Node\Lenovo\DeviceMetrics\DogFooding";
            String dmTestKey = @"HKLM\SOFTWARE\WOW6432Node\Lenovo\DeviceMetrics\DMTest";
            String tagKey = @"HKLM\SOFTWARE\WOW6432Node\Lenovo\ImController\Applicability\Tags\DeviceMetricsPlugin.Enablement";
            String tagkeys = @"HKLM\SOFTWARE\WOW6432Node\Lenovo\ImController\Applicability\Tags";
            String DeviceMetricsKey = @"HKLM\SOFTWARE\WOW6432Node\Lenovo\DeviceMetrics";
            if (defaultText.ToLower().Contains("enable"))
            {
                RegistryHelp.SetRegistryKeyValuePlus(dogFoodingKey, 1, RegistryValueKind.DWord);
                RegistryHelp.SetRegistryKeyValuePlus(dmTestKey, 1, RegistryValueKind.DWord);
                RegistryHelp.SetRegistryKeyValuePlus(tagKey, "", RegistryValueKind.String);
                Assert.IsTrue(RegistryHelp.IsRegistrySubKeyExist(tagkeys));
                Assert.IsTrue(RegistryHelp.IsRegistrySubKeyExist(DeviceMetricsKey));
            }
            else
            {
                if (RegistryHelp.IsRegistrySubKeyExist(DeviceMetricsKey))
                    RegistryHelp.DeleteRegistrySubKey(DeviceMetricsKey);
                if (RegistryHelp.IsRegistrySubKeyExist(tagkeys))
                    RegistryHelp.DeleteRegistrySubKey(tagkeys);
                Assert.IsFalse(RegistryHelp.IsRegistrySubKeyExist(tagkeys));
                Assert.IsFalse(RegistryHelp.IsRegistrySubKeyExist(DeviceMetricsKey));
            }
        }

        [Given(@"Clear Event log ""(.*)""")]
        public void GivenClearEventLog(string logName)
        {
            Utility.Common.ClearEventLog(logName);
        }

        [Then(@"Tigger GenericMessgingPlugin Task")]
        public void GivenTiggerGenericMessgingPluginTask()
        {
            string execute = @"C:\Windows\Lenovo\ImController\Service\Lenovo.Modern.ImController.exe";
            string argument = @"/timebasedeventtrigger ";

            #region Get task Name
            TaskSchedulerClass taskScheduler = new TaskSchedulerClass();
            taskScheduler.Connect();
            ITaskFolder taskFolder = taskScheduler.GetFolder(@"\Lenovo\ImController\TimeBasedEvents");
            var taskList = taskFolder.GetTasks(0);
            foreach (IRegisteredTask task in taskList)
            {
                if (task.Xml.Contains("GenericMessagingPlugin"))
                {
                    argument += task.Name;
                }
            }
            #endregion
            var processInfo = new ProcessStartInfo(execute, "/S /C " + argument)
            {
                CreateNoWindow = true,
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process.Start(processInfo);
        }


        [Given(@"Kill the Process command line with ""(.*)""")]
        public void GivenKillTheProcessCommandLineWith(string text)
        {
            Process[] procs = Process.GetProcesses();
            foreach (Process temp in procs)
            {
                if (temp.ProcessName.Contains("ImController"))
                {
                    if (Utility.Common.GetProcessCMDLine(temp).Contains(text))
                    {
                        temp.Kill();
                    }
                }
            }
        }

        [Then(@"Check the Event is corret")]
        public void CheckTheEventIsCorret(Table table)
        {
            string eventID = "104";
            string logSource = "Lenovo-Sif-Companion/Operational";
            string sQuery = "*[System/EventID=" + eventID + "]";  // XPATH Query

            EventLogQuery elQuery = new EventLogQuery(logSource, PathType.LogName, sQuery);
            List<EventRecord> eventList = new List<EventRecord>();
            EventLogReader elReader = new EventLogReader(elQuery);

            for (EventRecord eventInstance = elReader.ReadEvent(); null != eventInstance; eventInstance = elReader.ReadEvent())
            {
                IList<EventProperty> generalInfo = eventInstance.Properties;
                string strGeneralInfo = generalInfo[0].Value.ToString();
                XmlDocument document = new XmlDocument();
                document.LoadXml(strGeneralInfo);
                XmlNode xmlnode = document.SelectSingleNode("//name[text()='" + table.Rows[0][1] + "']");
                if (xmlnode == null)
                {
                    Assert.IsNull(xmlnode, "No Event Found");
                }
                if (xmlnode != null)
                {
                    XmlNode variable = document.SelectSingleNode("//variables");
                    foreach (XmlNode xn in variable.ChildNodes)
                    {
                        switch (xn.ChildNodes.Item(0).InnerText)
                        {
                            case "DeviceId":
                                string adid = CryptoGraphy.HashData(DeviceInfoCollector.GetPcsnString());
                                Assert.AreEqual(xn.ChildNodes.Item(1).InnerText, adid);
                                break;
                            case "ResponseCode":
                                Assert.AreEqual(xn.ChildNodes.Item(1).InnerText, table.Rows[1][1]);
                                break;
                            case "RequestDuration":
                                if (table.Rows[3][1] != null)
                                {
                                    Assert.IsTrue(Int32.Parse(xn.ChildNodes.Item(1).InnerText) < Int32.Parse(table.Rows[3][1]));
                                }
                                break;
                            case "RequestTime":
                                Assert.IsNotNull(xn.ChildNodes.Item(1).InnerText);
                                break;
                            case "TagCount":
                                Assert.AreEqual(xn.ChildNodes.Item(1).InnerText, table.Rows[2][1]);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        [Then(@"The Event log is as expect with productName (.*)")]
        public void ThenTheEventLogIsAsExpect(string prodName, Table table)
        {
            List<XmlDocument> eventlogList = GetEventLog(prodName);
            Assert.IsTrue(eventlogList.Count > 0, "event log count is 0");
            bool result = false;
            foreach (var eventlog in eventlogList)
            {
                XmlNodeList nodeList = eventlog.SelectNodes("/event/variables/var");
                Assert.IsNotNull(nodeList, "event log variables exist");
                int imatch = 0;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string key = table.Rows[i][0];
                    string value = table.Rows[i][1];
                    foreach (XmlNode node in nodeList)
                    {
                        XmlNode n = node.SelectSingleNode("name");
                        Assert.IsNotNull(n);
                        if (n.InnerText == key && value.Equals(node.SelectSingleNode("value").InnerText))
                        {
                            imatch++;
                        }
                    }
                }
                if (table.Rows.Count == imatch)
                {
                    result = true;
                }
            }
            Assert.IsTrue(result);
        }

        private List<XmlDocument> GetEventLog(string prodName)
        {
            string eventID = "104";
            string logSource = "Lenovo-Sif-Companion/Operational";
            string sQuery = "*[System/EventID=" + eventID + "]";  // XPATH Query

            EventLogQuery elQuery = new EventLogQuery(logSource, PathType.LogName, sQuery);
            EventLogReader elReader = new EventLogReader(elQuery);
            List<XmlDocument> eventLogList = new List<XmlDocument>();
            for (EventRecord eventInstance = elReader.ReadEvent(); null != eventInstance; eventInstance = elReader.ReadEvent())
            {
                IList<EventProperty> generalInfo = eventInstance.Properties;
                string strGeneralInfo = generalInfo[0].Value.ToString();
                XmlDocument document = new XmlDocument();
                document.LoadXml(strGeneralInfo);
                XmlNode xmlnode = document.SelectSingleNode("//productName[text()='" + prodName + "']");
                if (xmlnode != null)
                {
                    eventLogList.Add(document);
                }
            }
            return eventLogList;
        }


        [Given(@"Generic Messgin Plugin is (.*)")]
        public void GivenGenericMessginPluginIsExist(string text)
        {
            string GMPFolder = Path.Combine(Constants.pluginPath, "GenericMessagingPlugin");
            if (text == "Exist")
            {
                Assert.IsTrue(Directory.Exists(GMPFolder));
            }
            else
            {
                Assert.IsFalse(!Directory.Exists(GMPFolder));
            }
        }

        [Given(@"Start Capture URL with AutoResponse")]
        public void GivenStartCaptureURLWithAutoResponse(Table table)
        {
            VantageMetric.GetInstance().Stop();
            string url = "";
            if (table.Rows[0][1].ToLower().Contains("https"))
            {
                url = table.Rows[0][1];
            }
            if (table.Rows[0][1].ToLower().Contains("vantage_upe_url"))
            {
                url = (string)RegistryHelp.GetRegistryKeyValue(Constants.vantage_upe_url);
            }

            VantageMetric.GetInstance().Start(Constants.LUDPServer, url, url, Int32.Parse(table.Rows[1][1]));
        }

    }
}
