using LenovoVantageTest.LogHelper;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace LenovoVantageTest.Utility
{
    public class HttpRequest
    {
        // <summary>
        // For HttpAnalyzerOnly
        // </summary>
        // <param name="Url"></param>
        // <param name="postDataStr"></param>
        public static void HttpPost(string url, string postDataStr)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postDataStr.Length;
                StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
                writer.Write(postDataStr);
                writer.Flush();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            }
            catch
            {
            }
        }
        public static string HttpPostData(string url, string postDataStr)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = postDataStr.Length;
                request.KeepAlive = true;
                request.Timeout = 60000;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

                StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
                writer.Write(postDataStr);
                writer.Flush();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                return retString;
            }
            catch (Exception e)
            {
                Logger.Instance.WriteLog(e.Message, LogType.Error);
            }
            return "";
        }
        public static string HttpPostMultiData(string url, string postDataStr)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "multipart/form-data; boundary=" + "---------------226972594361071386510905";
                request.ContentLength = postDataStr.Length;

                StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
                writer.Write(postDataStr);
                writer.Flush();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();
                return retString;
            }
            catch (Exception e)
            {
                Logger.Instance.WriteLog(e.Message, LogType.Error);
            }
            return "";
        }
        public static HttpWebResponse HttpPost(string url, string contentType, string postDataStr)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = contentType;
                request.ContentLength = postDataStr.Length;
                request.ProtocolVersion = HttpVersion.Version11;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
                writer.Write(postDataStr);
                writer.Flush();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return response;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog(ex.Message, LogType.Error);
            }
            return null;
        }

        // <summary>
        // 异步发送POST请求
        // </summary>
        // <param name="url"></param>
        // <param name="contentType"></param>
        // <param name="postDataStr"></param>
        // <returns></returns>
        public static async Task<string> HttpPostAsync(string url, string contentType, string postDataStr)
        {
            HttpClient client = new HttpClient();
            var content = new StringContent(postDataStr, Encoding.UTF8, contentType);
            var response = await client.PostAsync(url, content);
            return await response.Content.ReadAsStringAsync();
        }

        public static string HttpGet(string url, int? timeout)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                if (timeout.HasValue)
                {
                    request.Timeout = timeout.Value;
                }
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();

                return retString;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog(ex.Message, LogType.Error);
            }

            return null;
        }

        // <summary>
        // 异步发送GET请求
        // </summary>
        // <param name="url"></param>
        // <param name="timeout"></param>
        // <returns></returns>
        public static async Task<string> HttpGetAsync(string url, int? timeout)
        {
            HttpClient client = new HttpClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
            var response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }


        public static string GetHttpResponse(string url, int timeout)
        {
            try
            {
                Uri httpURL = new Uri(url);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(httpURL);
                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";
                request.UserAgent = null;
                request.Timeout = timeout;
                request.ReadWriteTimeout = timeout;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                myResponseStream.ReadTimeout = timeout;
                myResponseStream.WriteTimeout = timeout;
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();

                return retString;
            }
            catch (Exception e)
            {
                Logger.Instance.WriteLog(e.Message, LogType.Error);
            }
            return "";
        }
    }
}
