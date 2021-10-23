using Fiddler;
using FiddlerCoreAPIWrap;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.Script.Serialization;

namespace LenovoVantageTest.Utility.Metrics
{
    public class MetricFiddler
    {
        private FiddlerAgent fiAgent = null;

        private bool resultFetched = false;
        private List<IDictionary<string, object>> ListDic = new List<IDictionary<string, object>>();


        public void Launch()
        {
            if (fiAgent == null)
            {
                fiAgent = new FiddlerAgent();
            }
        }

        /// <summary>
        /// appName fileter need add code
        /// param url  is null or "",will return all the traffic data
        /// </summary>
        public void Start()
        {
            if (fiAgent == null)
            {
                return;
            }
            fiAgent.StartMonitor();
            fiAgent.AttachEventListeners();
        }

        public void Start(string url, string noDecriptionList = "")
        {
            if (fiAgent == null)
            {
                return;
            }
            fiAgent.StartMonitor();
            if (!string.IsNullOrEmpty(url))
            {
                fiAgent.AttachEventListenersGivenUrl(url, noDecriptionList);
            }
        }
        /// <summary>
        /// strart capture with autoresponse fuction
        /// </summary>
        /// <param name="url">the request url you want to Given autoresponse</param>
        /// <param name="responseCode">as 404,400,403</param>

        public void Start(string url, int responseCode)
        {
            if (fiAgent == null)
            {
                return;
            }
            fiAgent.StartMonitor();
            if (!string.IsNullOrEmpty(url))
            {
                fiAgent.AttachEventListenerForAutoResponse(url, responseCode);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="captureUrl"></param>
        /// <param name="noDecriptionList">split by ; for multi url and will not decryption data for the url</param>
        /// <param name="autoresUrl">the request url you want to give response code</param>
        /// <param name="responseCode"></param>
        public void Start(string captureUrl, string noDecriptionList, string autoresUrl, int responseCode)
        {
            if (fiAgent == null)
            {
                return;
            }
            fiAgent.StartMonitor();
            if (!string.IsNullOrEmpty(captureUrl))
            {
                fiAgent.AttachEventListenersGivenUrl(captureUrl, noDecriptionList);
            }
            if (!string.IsNullOrEmpty(autoresUrl))
            {
                fiAgent.AttachEventListenerForAutoResponse(autoresUrl, responseCode);
            }
        }

        public void Stop()
        {
            Common.CloseWindowsProxy();
            Thread.Sleep(1000);
            if (fiAgent != null)
            {
                fiAgent.Quit();
            }
        }

        public void WaitUntilCaptureFinish(int timeout = 20)
        {
            Thread.Sleep(timeout * 1000);
            return;
        }

        public List<IDictionary<string, object>> GetResult(int timeout = 30)
        {
            ListDic.Clear();
            List<string> results = GetRawResults(timeout);
            int totalCapturedMetrics = results.Count;
            int countCapturedMetric = 0;
            foreach (var session in results)
            {
                countCapturedMetric++;
                string jsonStr = session;

                LenovoVantageTest.LogHelper.Logger.Instance.WriteLog("\r\nCaptured full metric data (Current=" + countCapturedMetric + "/Total=" + totalCapturedMetrics + "): json=" + Common.ConvertJsonString(jsonStr));
                JavaScriptSerializer js = new JavaScriptSerializer();
                dynamic json = js.Deserialize<dynamic>(jsonStr);
                dynamic e_data = null;
                dynamic e_name = "EMPTY";
                try
                {
                    e_data = json["events"][0]["e_data"];
                    e_name = json["events"][0]["e_name"];
                    IDictionary<string, object> dic = e_data as IDictionary<string, object>;
                    dic.Add("e_name", e_name);
                    ListDic.Add(dic);
                }
                catch (Exception e) //Troy: sometimes, there no "e_data" or "e_name" in captured metrics!
                {
                    Console.WriteLine("Exception when getting metric events->e_data|e_name: " + e.ToString());
                }

            }

            return ListDic;
        }
        public List<string> GetRawResults(int timeout = 30)
        {
            LenovoVantageTest.LogHelper.Logger.Instance.WriteLog($"Capture HTTP traffic in {timeout} seconds...");
            List<string> result = new List<string>();
            DateTime now = DateTime.Now;
            while ((DateTime.Now - now).TotalSeconds < timeout)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string aEvent = "";
                string jsonStr;
                if (fiAgent.sessions.Count > 0)
                {
                    Thread.Sleep(5000);
                    // Stop();
                }
                else
                {
                    Thread.Sleep(1000);
                    continue;
                }

                int totalCapturedMetrics = fiAgent.sessions.Count;
                int countCapturedMetric = 0;
                foreach (var session in fiAgent.sessions)
                {
                    countCapturedMetric++;
                    aEvent = session.GetRequestBodyAsString();
                    string prefix = "json=";
                    if (aEvent.Contains(prefix))
                    {
                        jsonStr = aEvent.Substring(prefix.Length);
                    }
                    else
                        jsonStr = aEvent;

                    // LenovoVantageTest.LogHelper.Logger.Instance.WriteLog("\r\nCaptured raw full metric data (Current=" + countCapturedMetric + "/Total=" + totalCapturedMetrics + "): json=" + Common.ConvertJsonString(jsonStr));

                    result.Add(jsonStr);
                }
                break;
            }
            resultFetched = true;
            return result;
        }
        public ICollection<Session> captureTraffic(int timeout = 30, string monitorURL1 = "", string monitorURL2 = "", string expectValue = "")
        {
            Console.WriteLine($"Try to capture HTTP traffic in {timeout} seconds...");
            ListDic.Clear();
            bool found = false;
            DateTime now = DateTime.Now;
            while ((DateTime.Now - now).TotalSeconds < timeout)
            {
                Thread.Sleep(5000);
                if (fiAgent.sessions.Count > 0)
                {
                    ICollection<Session> capturedList = fiAgent.sessions;
                    foreach (var session in capturedList)
                    {
                        if ((session.fullUrl.Contains(monitorURL1) || session.fullUrl.Contains(monitorURL2)) && !session.RequestMethod.Equals("CONNECT") && session.fullUrl.Contains(expectValue))
                        {
                            Console.WriteLine($"Captured expected HTTP represt:{session.RequestMethod} {session.fullUrl}");

                            String requestInfo = "";
                            if (session != null)
                            {
                                requestInfo = fiAgent.ReadRequestFromSession(session);
                                Console.WriteLine($"Captured Request Detail Info :\r\n {requestInfo}");
                            }
                            found = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Unexpected HTTP request is captured:{session.RequestMethod} {session.fullUrl}");
                            Thread.Sleep(1000);
                            continue;
                        }
                    }
                    if (found)
                    {
                        break;
                    }
                    else
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine($"Trying capture expected HTTP traffic in {(DateTime.Now - now).TotalSeconds} seconds...");
                    }
                }
                else
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"fiAgent.sessions.Count={fiAgent.sessions.Count}, trying capture expected HTTP traffic in {(DateTime.Now - now).TotalSeconds} seconds...");
                    continue;
                }

            }
            Stop();
            resultFetched = true;
            return fiAgent.sessions;
        }

        public string GetResultAsString(int timeout = 30)
        {
            string aEvent = "";
            DateTime now = DateTime.Now;
            while ((DateTime.Now - now).TotalSeconds < timeout)
            {
                if (fiAgent.sessions.Count > 0)
                {
                    Thread.Sleep(5000);
                    Stop();
                }
                else
                {
                    Thread.Sleep(1000);
                    continue;
                }
                JavaScriptSerializer js = new JavaScriptSerializer();
                foreach (var item in fiAgent.sessions)
                {
                    aEvent = item.GetRequestBodyAsString() + "\r\n";
                }
                break;
            }
            Stop();
            return aEvent;
        }

        public void Clear()
        {
            if (fiAgent == null)
            {
                return;
            }
            if (fiAgent.sessions.Count > 0)
            {
                fiAgent.sessions.Clear();
            }
        }

        public string getFullRequest(Session session)
        {
            return fiAgent.ReadRequestFromSession(session);
        }

        public string getFullResponse(Session session)
        {
            return fiAgent.ReadResponseFromSession(session);
        }
    }
}
