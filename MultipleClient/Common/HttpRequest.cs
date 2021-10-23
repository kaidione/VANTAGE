using LenovoVantageTest.LogHelper;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace Http.Util
{
    /// <summary>
    /// Http请求封装类，封装常用的Get，Post请求方法
    /// </summary>
    public class HttpRequest
    {
        /// <summary>
        /// 向指定 URL 发送POST方法的请求
        /// </summary>
        /// <param name="url">发送请求的 URL</param>
        /// <param name="jsonData">请求参数，请求参数应该是Json格式字符串的形式。</param>
        /// <returns>所代表远程资源的响应结果</returns>
        public static string SendPost(string sendUrl, string jsonData)
        {
            string result = string.Empty;
            string url = "http://10.119.39.24:8099/" + sendUrl;

            try
            {
                Debug.WriteLine(jsonData);
                CookieContainer cookie = new CookieContainer();
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.Headers.Add("x-requested-with", "XMLHttpRequest");
                request.ServicePoint.Expect100Continue = false;
                request.ContentType = "application/json";
                request.Accept = "*/*";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1;SV1)";
                request.ContentLength = Encoding.UTF8.GetByteCount(jsonData);
                request.CookieContainer = cookie;
                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(jsonData);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                response.Cookies = cookie.GetCookies(response.ResponseUri);
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        result = reader.ReadToEnd();
                        reader.Close();
                    }
                    responseStream.Close();
                }
                response.Close();
                response = null;
                request = null;
            }
            catch (Exception ex)
            {
                string message = string.Format("The url {0} send {1} error", url, jsonData);
                string sendMsg = jsonData + "Send request failed：" + ex.Message + "\r\n" + message;
                File.AppendAllText("log.txt", sendMsg);
                Logger.Instance.WriteLog(sendMsg, LogType.Failure);
                return result;
            }

            string succefullMsg = jsonData + " Send request Succefull";
            Logger.Instance.WriteLog(succefullMsg, LogType.Success);

            return result;
        }

        /// <summary>
        /// 上传媒体文件
        /// </summary>
        /// <param name="url">上传媒体文件的微信公众平台接口地址</param>
        /// <param name="file">要上传的媒体文件对象</param>
        /// <returns>返回上传的响应结果，详情参看微信公众平台开发者接口文档</returns>
        public static string UploadPost(string url, string file)
        {
            string result = string.Empty;
            try
            {
                WebClient client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                byte[] responseArray = client.UploadFile(url, "POST", file);
                result = System.Text.Encoding.Default.GetString(responseArray, 0, responseArray.Length);
                Console.WriteLine("上传result:" + result);
            }
            catch (Exception ex)
            {
                result = "Error:" + ex.Message;
                string message = string.Format("The url {0} send {1} error", url, file);
            }
            finally
            {
                Console.WriteLine("上传MediaId:" + result);
            }
            return result;
        }

        public static bool DownloadFile(string url, string outFileName)
        {
            bool result = false;
            FileStream fs = null;
            try
            {
                string urlNameString = url;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlNameString);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                request.Accept = "*/*";
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1;SV1)";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                FileInfo fi = new FileInfo(outFileName);
                var di = fi.Directory;
                if (!di.Exists)
                {
                    di.Create();
                }
                if (!File.Exists(outFileName))
                {
                    File.Create(outFileName).Close();
                }

                fs = new FileStream(outFileName, FileMode.Open);
                int bufferSize = 2048;
                byte[] data = new byte[bufferSize];
                int length = 0;
                while ((length = responseStream.Read(data, 0, bufferSize)) > 0)
                {
                    fs.Write(data, 0, length);
                }
                fs.Close();
                responseStream.Close();
                response.Close();
                fs = null;
                responseStream = null;
                response = null;

                result = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("下载媒体文件时出现异常：" + ex.Message);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
            return result;
        }
    }
}

