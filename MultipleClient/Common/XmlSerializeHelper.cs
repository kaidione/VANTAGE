using System;
using System.IO;
using System.Xml.Serialization;

namespace winformUI.Common
{
    public class XmlSerializeHelper
    {
        public static string XmlSerialize<T>(T obj)
        {
            using (StringWriter sw = new StringWriter())
            {
                Type t = obj.GetType();
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(sw, obj);
                sw.Close();
                return sw.ToString();
            }
        }


        public static T DESerializer<T>(string filePath) where T : class
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                    return null;
                }

                string strXML = File.ReadAllText(filePath);
                if (string.IsNullOrEmpty(strXML))
                {
                    return null;
                }
                using (StringReader sr = new StringReader(strXML))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return serializer.Deserialize(sr) as T;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static T DESerializerStr<T>(string strXML) where T : class
        {
            try
            {
                using (StringReader sr = new StringReader(strXML))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return serializer.Deserialize(sr) as T;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static T WriteSerializer<T>(string filePath) where T : class
        {
            try
            {
                string strXML = File.ReadAllText(filePath);
                using (StringReader sr = new StringReader(strXML))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    return serializer.Deserialize(sr) as T;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
