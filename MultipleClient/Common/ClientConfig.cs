using LenovoMultipleCleint.Bean;
using System;
using System.Diagnostics;
using System.IO;
using winformUI.Common;

namespace Appconfig
{
    /// <summary>
    ///  Get and Set Config Information,eg: clientid, jobversion...
    /// </summary>
    public class ClientConfig
    {
        public static T GetPool<T>(string filePath) where T : class
        {
            return XmlSerializeHelper.DESerializer<T>(filePath);
        }

        //写入文件
        public static bool ReadToFile(string filePath, string strxml)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.Write(strxml);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            return true;
        }


        public static string GetServerUrl()
        {
            try
            {
                if (File.Exists(CommonConstStr.MultipleClientConfig))
                {
                    ConfigBean config = GetPool<ConfigBean>(CommonConstStr.MultipleClientConfig);
                    return config.serverUrl;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return string.Empty;
        }

        public static string GetClientStatus()
        {
            try
            {
                if (File.Exists(CommonConstStr.MultipleClientConfig))
                {
                    ConfigBean config = GetPool<ConfigBean>(CommonConstStr.MultipleClientConfig);
                    return config.clientStatus;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return string.Empty;
        }

        public static void SetClientStatus(string v)
        {
            ConfigBean config = GetPool<ConfigBean>(CommonConstStr.MultipleClientConfig);
            config.clientStatus = v;
            string strxml = XmlSerializeHelper.XmlSerialize<ConfigBean>(config);
            ReadToFile(CommonConstStr.TaskPoolFile, strxml);
        }

        public static void SetClientVersion(string resourceVersion)
        {
            ConfigBean config = GetPool<ConfigBean>(CommonConstStr.MultipleClientConfig);
            config.version = resourceVersion;
            string strxml = XmlSerializeHelper.XmlSerialize<ConfigBean>(config);
            ReadToFile(CommonConstStr.TaskPoolFile, strxml);
        }

        public static string GetClientName()
        {
            try
            {
                if (File.Exists(CommonConstStr.MultipleClientConfig))
                {
                    ConfigBean config = GetPool<ConfigBean>(CommonConstStr.MultipleClientConfig);
                    return config.clientName;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return string.Empty;
        }

        public static string GetClientVersion()
        {
            try
            {
                if (File.Exists(CommonConstStr.MultipleClientConfig))
                {
                    ConfigBean config = GetPool<ConfigBean>(CommonConstStr.MultipleClientConfig);
                    return config.version;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return string.Empty;
        }

        public static string GetClientId()
        {
            try
            {
                if (File.Exists(CommonConstStr.MultipleClientConfig))
                {
                    ConfigBean config = GetPool<ConfigBean>(CommonConstStr.MultipleClientConfig);
                    return config.clientId;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return string.Empty;
        }

    }

}
