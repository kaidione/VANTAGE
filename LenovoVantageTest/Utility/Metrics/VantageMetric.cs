using LenovoVantageTest.Utility.Readers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Windows.Data.Json;

namespace LenovoVantageTest.Utility.Metrics
{
    public sealed class VantageMetric
    {
        public enum EMetricStatus
        {
            on = 1,
            off = 0
        }

        private MetricFiddler metric = new MetricFiddler();
        private static VantageMetric g_instance = null;

        private VantageMetric() { }

        public static VantageMetric GetInstance()
        {
            if (g_instance == null)
            {
                g_instance = new VantageMetric();
            }
            return g_instance;
        }

        public void Launch()
        {
            metric.Launch();
        }

        public void Start()
        {
            metric.Start();
        }

        public void Start(string url)
        {
            metric.Start(url);
            Console.WriteLine($"Start to monitor HTTP traffic with {url}");
        }

        public void Start(string url, int responseCode)
        {
            metric.Start(url, responseCode);
        }

        public void Start(string captureUrl, string noDecryptionList, string autoResUrl, int responseCode)
        {
            metric.Start(captureUrl, noDecryptionList, autoResUrl, responseCode);
        }

        public void Stop()
        {
            metric.Stop();
        }
        public void Clear(int time = 20)
        {
            metric.WaitUntilCaptureFinish(time);  //@Zhoufang, if you want to clear, why still need wait?
            metric.Clear();
        }

        public static void SetMetricToggle(EMetricStatus status)
        {
            string regKey = @"HKCU\Software\Lenovo\Metrics\com.lenovo.companion";
            RegistryHelp.SetRegistryKeyValuePlus(regKey, Convert.ToInt32(status).ToString());
        }

        public bool MetricIsAsExpected(string testID, string Name, int timeout, bool partMatch = false)
        {
            metric.WaitUntilCaptureFinish(timeout);
            //metric.Stop();
            List<IDictionary<string, object>> actualList = metric.GetResult();
            List<IDictionary<string, object>> expectList = GetExpectResultFromJson(testID, Name);

            if (actualList.Count == 0 || expectList.Count == 0) //list.Count =0 means capture nothing!
            {
                LogHelper.Logger.Instance.WriteLog(string.Format("Failed! The expect list count is {0} and the actual list count is {1}", expectList.Count, actualList.Count), LogHelper.LogType.Error);
                return false;
            }

            if (!partMatch && actualList.Count != expectList.Count)
            {
                LogHelper.Logger.Instance.WriteLog(string.Format("Failed! Expect metrics count is {0} != Actual captured metrics count is {1}", expectList.Count, actualList.Count), LogHelper.LogType.Error);
                return false;
            }

            int iMatch = 0;
            for (int k = 0; k < expectList.Count; k++)
            {
                IDictionary<string, object> expectItem = expectList[k];
                int iMatchItem = 0;

                for (int m = 0; m < actualList.Count; m++)
                {
                    LogHelper.Logger.Instance.WriteLog($"\r\n_______begin to compare the actually captured metrics (Current={m + 1}/Total= {actualList.Count}) _______", LogHelper.LogType.Information);

                    IDictionary<string, object> actualItem = actualList[m];
                    string[] expectKeys = expectItem.Keys.ToArray();
                    iMatchItem = 0;
                    foreach (var key in expectKeys)
                    {
                        string keyToCompare = key;
                        string expvalue = expectItem[key].ToString();
                        LogHelper.Logger.Instance.WriteLog($"Comparing key({keyToCompare}) and expected vanlue is {expvalue}");

                        //consider comparing value is a JSON
                        if (Common.IsValidJson(expvalue)) //e.g. expvalue("TaskAction") = {"TaskResult": "Cancelled","TaskCount": "^[0-9]*[1-9][0-9]*$","TaskName": "Scan","TaskParm": "Scan","TaskDuration": "^[0-9]*[1-9][0-9]*$"}
                        {
                            LogHelper.Logger.Instance.WriteLog($"Comparing value({expvalue}) is a JSON");
                            if (actualItem.ContainsKey(key))
                            {
                                string actualString = ConvToString(actualItem[key]);

                                //then the corresponding actual value must be a JSON also
                                if (Common.IsValidJson(actualString))
                                {
                                    LogHelper.Logger.Instance.WriteLog($"The corresponding actual value{actualString} is a JSON also, now we can compare them ...");

                                    int jMatchItem = 0;

                                    JsonObject expectJson = JsonObject.Parse(expvalue);
                                    JsonObject actualJson = JsonObject.Parse(actualString);

                                    foreach (var jObjExpect in expectJson)
                                    {
                                        string jKey = jObjExpect.Key;
                                        string jValueExpect = jObjExpect.Value.GetString();
                                        string jValueActual = actualJson[jKey].GetString();

                                        if (CompareData(Regex.Replace(jValueExpect, @"\s", ""), jValueActual))
                                        {
                                            LogHelper.Logger.Instance.WriteLog($"Compare key({jKey})'s value passed, Actual value({jValueActual}) = Expected value({jValueExpect})");
                                            jMatchItem++;
                                        }
                                        else
                                        {
                                            LogHelper.Logger.Instance.WriteLog($"Compare key({jKey})'s value failed, Actual value({jValueActual}) != Expected value({jValueExpect})", LogHelper.LogType.Error);
                                            break;
                                        }
                                    }

                                    if (jMatchItem == expectJson.Count)
                                    {
                                        iMatchItem++;
                                        LogHelper.Logger.Instance.WriteLog($"actualJson({actualString}) = expectJson({expvalue})");
                                    }
                                    else
                                    {
                                        LogHelper.Logger.Instance.WriteLog($"failed, actualJson({actualString}) != expectJson({expvalue})", LogHelper.LogType.Error);
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            //comparing value is Not a JSON
                            if (actualItem.Keys.Contains(key) && CompareData(Regex.Replace(expvalue, @"\s", ""), ConvToString(actualItem[key])))
                            {
                                iMatchItem++;
                                LogHelper.Logger.Instance.WriteLog($"Actual({ConvToString(actualItem[key])}) matched expected({expvalue}), when comparing the non-Json values of Key({key}), iMatchItem={iMatchItem}", LogHelper.LogType.Information);
                            }
                            else
                            {
                                if (actualItem.Keys.Contains(key))
                                {
                                    LogHelper.Logger.Instance.WriteLog("Not match, when comparing the non-Json values of Key(" + key + "):\r\n expect data=" + expvalue + "\r\n actual data=" + ConvToString(actualItem[key]), LogHelper.LogType.Error);
                                }
                                else
                                {
                                    LogHelper.Logger.Instance.WriteLog("Not match, when comparing the non-Json values of Key(" + key + "):\r\n expect data=" + expvalue + "\r\n but actual metrics does not contain the key - " + key, LogHelper.LogType.Error);
                                }
                                break;
                            }
                        }
                    }

                    if (iMatchItem == expectKeys.Length)
                    {
                        iMatch++;
                        LogHelper.Logger.Instance.WriteLog($"Metrics matched! {iMatchItem} items in actual metrics == expected {expectKeys.Length} keys.  \r\n", LogHelper.LogType.Information);
                        break;
                    }

                    LogHelper.Logger.Instance.WriteLog($"_______end comparing the actually captured metrics(Current={m + 1}/Total= {actualList.Count})_______\r\n", LogHelper.LogType.Information);
                }
            }
            if (iMatch == expectList.Count)
            {
                LogHelper.Logger.Instance.WriteLog(string.Format("Metrics Is As Expected, matched metrics is {0} and expected metrics list count is {1}", iMatch, expectList.Count), LogHelper.LogType.Information);
                return true;
            }
            else
            {
                LogHelper.Logger.Instance.WriteLog(string.Format("Metrics Is Not As Expected! matched metrics is {0} but expected metrics list count is {1}", iMatch, expectList.Count), LogHelper.LogType.Warning);
                return false;
            }
        }

        public bool MetricIsNotIncludingTheKeywords(string keyWord, int timeout = 3)
        {
            metric.WaitUntilCaptureFinish(timeout);
            List<string> actualList = metric.GetRawResults();
            if (actualList.Count == 0) //list.Count =0 means capture nothing!
            {
                LogHelper.Logger.Instance.WriteLog(string.Format("Failed! The actual metrics list count is {1}", actualList.Count), LogHelper.LogType.Error);
                return false;
            }

            for (int m = 0; m < actualList.Count; m++)
            {
                LogHelper.Logger.Instance.WriteLog($"\r\n_______begin to check the actually captured metrics (Current={m + 1}/Total= {actualList.Count}) _______", LogHelper.LogType.Information);
                string actualItem = actualList[m];
                if (actualItem.Contains(keyWord))
                {
                    LogHelper.Logger.Instance.WriteLog($"Failed, Metric({actualItem}) Is Including The Keywords({keyWord})!", LogHelper.LogType.Warning);
                    return false;
                }
                else
                {
                    LogHelper.Logger.Instance.WriteLog($"Metric({actualItem}) Is Not Including The Keywords({keyWord}).", LogHelper.LogType.Information);
                }
            }

            LogHelper.Logger.Instance.WriteLog($"Passed, Metric(Count={actualList.Count}) Is Not Including The Keywords({keyWord}).", LogHelper.LogType.Information);
            return true;
        }



        /*Author:Marcus
         Desc: With passed in json strings , compare them using specfic function .
               Default comparision is to pick up the json key from the actual caught metrics using JsonPath , pick up all keys instead of those under eventData, then compare the value . Expected value could be a regular expression.
         
         NOTE: To easy up and make fast comparision , we must place the event[x].e_name as 1st argument.
         Args:_func_custom_comparer's 1st arg is an actual caught fiddler metrics , 
                                      2nd arg is an expected metrics item defined in DB , 
                                      3rd arg's 1st param tell if all job is done and can return
                                      3rd arg's 2nd param is the real comparision result 
        */
        public bool MetricIsAsExpected(string testID, string Name, Func<int, string, IDictionary<string, object>, Tuple<bool, bool>> _func_custom_comparer = null, int timeout = 30)
        {
            List<string> actualList = metric.GetRawResults(timeout);
            List<IDictionary<string, object>> expectList = GetExpectResultFromJson(testID, Name);
            int matchedMetricsQuantity = 0;
            if (actualList.Count == 0 || expectList.Count == 0) //list.Count =0 means capture nothing!
            {
                LogHelper.Logger.Instance.WriteLog(string.Format("Failed! The expect list count is {0} and the actual list count is {1}", expectList.Count, actualList.Count), LogHelper.LogType.Error);
                return false;
            }
            for (int index_expectedInDB = 0; index_expectedInDB < expectList.Count; index_expectedInDB++)
            {
                IDictionary<string, object> expectItem = expectList[index_expectedInDB];
                //Compare with every caught metrics item
                for (int index_FiddlerReturned = 0; index_FiddlerReturned < actualList.Count; index_FiddlerReturned++)
                {
                    LogHelper.Logger.Instance.WriteLog($"\r\n_______begin to compare the actually captured metrics number-{index_FiddlerReturned + 1} of the total {actualList.Count}_______", LogHelper.LogType.Information);

                    string jsonstring_actualMetrics = actualList[index_FiddlerReturned];
                    LogHelper.Logger.Instance.WriteLog($"caught metrics[{index_FiddlerReturned}] is {jsonstring_actualMetrics}");
                    if (_func_custom_comparer == null)
                    {
                        string[] expectKeys = expectItem.Keys.ToArray();
                        int expectedMatchedKeysQuantity = expectKeys.Length;
                        JObject jo_metrics = JObject.Parse(jsonstring_actualMetrics);
                        foreach (var jsonPathInFiddlerCaughtMetrics in expectKeys)
                        {
                            string regularstring_ExpectedValueInFiddlerCaughtMetrics = expectItem[jsonPathInFiddlerCaughtMetrics].ToString();
                            Regex regularExpression_ExpectedValueInFiddlerCaughtMetrics = new Regex(regularstring_ExpectedValueInFiddlerCaughtMetrics);
                            JToken selectedJSObject = jo_metrics.SelectToken(jsonPathInFiddlerCaughtMetrics);
                            //Marcus : NO need to log every comparision failure since until all Keys match ,we don't know when it is done.
                            if (selectedJSObject != null)
                            {
                                if (regularExpression_ExpectedValueInFiddlerCaughtMetrics.IsMatch(selectedJSObject.ToString()))
                                {
                                    expectedMatchedKeysQuantity--;
                                    LogHelper.Logger.Instance.WriteLog($"Expected Key by using JsonPath {jsonPathInFiddlerCaughtMetrics} match that in Metrics");
                                }
                                else
                                {
                                    break; //Go next caught metrics item
                                }
                            }
                            else
                            {
                                break;//Go next caught metrics item
                            }
                        }
                        if (expectedMatchedKeysQuantity == 0)
                        {
                            matchedMetricsQuantity++;
                        }

                    }
                    else
                    {
                        Tuple<bool, bool> result = _func_custom_comparer(actualList.Count, jsonstring_actualMetrics, expectItem);
                        if (result.Item1)
                        {
                            //All is DON , otherwise , pick up next caught metrics item and compare
                            return result.Item2;
                        }
                    }

                }
            }
            if (matchedMetricsQuantity == expectList.Count)
            {
                return true;
            }
            else if (matchedMetricsQuantity == 0)
            {
                LogHelper.Logger.Instance.WriteLog("NO expected metrics item");
            }
            else
            {
                LogHelper.Logger.Instance.WriteLog($"matched metrics quantity = {matchedMetricsQuantity}, NOT Equal with expected metrics quantity in DB = {expectList.Count}");
            }

            return false;
        }
        public int GetMetricCount()
        {
            return metric.GetResult().Count();
        }

        public List<IDictionary<string, object>> GetExpectMetrics(string key, string value)
        {
            List<IDictionary<string, object>> actualList = metric.GetResult();
            List<IDictionary<string, object>> result = new List<IDictionary<string, object>>();
            for (int m = 0; m < actualList.Count; m++)
            {
                if (actualList[m].Keys.Contains(key) &&
                    actualList[m][key].ToString().Equals(value))
                {
                    result.Add(new Dictionary<string, object> { { key, value } });
                }
            }
            return result;
        }


        public string ActualMetric()
        {
            List<IDictionary<string, object>> list = metric.GetResult();
            string result = "";
            foreach (var dic in list)
            {
                foreach (KeyValuePair<string, object> item in dic)
                {
                    result += item.Key + ":" + item.Value + "\r\n";
                }
            }
            return result;
        }

        private List<IDictionary<string, object>> GetExpectResultFromJson(string testID, string Name)
        {
            List<IDictionary<string, object>> ListDic = new List<IDictionary<string, object>>();
            List<JObject> metricList = MetricsTestingDataReader.Instance.getMetricTestingData(Name, testID);
            if (metricList.Count == 0)
            {
                return ListDic;
            }
            JObject joMetrics = metricList[0];
            JToken jt = joMetrics as JToken;
            string metricarr = VantageUI.GetJsonValue(jt, "MetricData");
            LogHelper.Logger.Instance.WriteLog($"MetricData with CaseID={testID} and Name={Name} from DB is \r\n {metricarr}");
            JArray jarray = JArray.Parse(metricarr);
            for (int i = 0; i < jarray.Count; i++)
            {
                JToken item = jarray.ElementAt(i);
                IDictionary<string, object> dic = item.ToObject<IDictionary<string, object>>();
                ListDic.Add(dic);
            }
            return ListDic;

        }

        private bool CompareData(string exp, string actual)
        {
            Regex regex = new Regex(exp);
            if (regex.IsMatch(actual))
            {
                Console.WriteLine($"CompareData matched, Actual data({actual}) matched Expected regular expression({exp})");
                return true;
            }
            else
            {
                Console.WriteLine($"CompareData mismatched, Actual data({actual}) mismatched Expected regular expression({exp})");
                return false;
            }

        }

        public void TearDown()
        {
            Stop();
        }

        public ICollection<Fiddler.Session> allCapturedTraffic(int timeout = 30)
        {
            return metric.captureTraffic(timeout);
        }

        public ICollection<Fiddler.Session> tryCapturedTraffic(int timeout = 30, string monitorURL1 = "", string monitorURL2 = "", string expectValue = "")
        {
            return metric.captureTraffic(timeout, monitorURL1, monitorURL2, expectValue);
        }

        public string getRequest(Fiddler.Session session)
        {
            return metric.getFullRequest(session);
        }

        public string getResponse(Fiddler.Session session)
        {
            return metric.getFullResponse(session);
        }

        public string ConvToString(object obj)
        {
            if (obj.GetType() == typeof(Dictionary<string, object>))
            {
                Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
                string dictionaryString = "{";
                foreach (KeyValuePair<string, object> keyValues in dictionary)
                {
                    dictionaryString += "\"" + keyValues.Key + "\":\"" + keyValues.Value.ToString() + "\",";
                }
                return dictionaryString.TrimEnd(',', ' ') + "}";
            }
            else
            {
                return Regex.Replace(obj.ToString(), @"\s", "");
            }
        }

    }


    public class TaskAction
    {
        public string TaskResult { get; set; }
        public string TaskCount { get; set; }
        public string TaskName { get; set; }
        public string TaskParm { get; set; }
        public string TaskDuration { get; set; }
    }


}
