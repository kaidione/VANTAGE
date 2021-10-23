using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace LenovoVantageTest.Utility
{
    // <summary>
    // Utility for serializing and deserializing objects to and from XML
    // </summary>
    public static class Serializer
    {
        // <summary>
        // Converts XML into an object (that implements DataContract / IXmlSerializable)
        // </summary>
        // <typeparam name="T">Type of object to serialize</typeparam>
        // <param name="xml">XML that represents the object</param>
        // <returns>Instantiated instance</returns>
        public static T Deserialize<T>(string xml)
        {
            return XmlstringSerializer.Deserialize<T>(xml);
        }

        // <summary>
        // Converts an object (that implements DataContract / IXmlSerializable) into XML
        // </summary>
        // <typeparam name="T">Type of object to create</typeparam>
        // <param name="instance">Instance of type T</param>
        // <returns>The serialized XML</returns>
        public static string Serialize<T>(T instance)
        {
            return XmlstringSerializer.Serialize<T>(instance);
        }

        public static string Serialize<T>(T instance, XmlWriterSettings settings, bool ignoreNameSpace = false)
        {
            return XmlstringSerializer.Serialize<T>(instance, settings, ignoreNameSpace);
        }
    }


    // <summary>
    // Wrapper for XMLSerializer
    // </summary>
    internal static class XmlstringSerializer
    {
        // <summary>
        // Converts XML into an object (that implements DataContract / IXmlSerializable)
        // </summary>
        // <typeparam name="T">Type of object to serialize</typeparam>
        // <param name="xml">XML that represents the object</param>
        // <returns>Instantiated instance</returns>
        public static T Deserialize<T>(string xml)
        {
            T obj = default(T);
            var readerSettings = new XmlReaderSettings()
            {
                DtdProcessing = System.Xml.DtdProcessing.Ignore,
                XmlResolver = null,
                CheckCharacters = false,
                IgnoreWhitespace = true,
            };

            using (var StringReader = new StringReader(xml))
            {
                using (var xmlReader = XmlReader.Create(StringReader, readerSettings))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    obj = (T)serializer.Deserialize(xmlReader);
                }
            }

            return obj;
        }


        // <summary>
        // Converts an object (that implements DataContract / IXmlSerializable) into XML
        // </summary>
        // <typeparam name="T">Type of object to create</typeparam>
        // <param name="instance">Instance of type T</param>
        // <returns>The serialized XML</returns>
        internal static string Serialize<T>(T instance)
        {
            string xml = null;
            var xmlWriterSettings = new XmlWriterSettings()
            {
                Indent = true,
                OmitXmlDeclaration = false,
                NewLineHandling = NewLineHandling.Entitize,
                Encoding = new UTF8Encoding(false, false), // Prevent BOM! Very important
                // Encoding = new UnicodeEncoding(false, false), // Prevent BOM! Very important
            };

            using (var StringWriter = new StringWriter())
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                using (var xmlWriter = System.Xml.XmlWriter.Create(StringWriter, xmlWriterSettings))
                {
                    serializer.Serialize(xmlWriter, instance);
                }
                xml = StringWriter.ToString();
            }
            return xml;
        }

        internal static string Serialize<T>(T instance, XmlWriterSettings settings, bool disableNamespace = false)
        {
            string xml = null;

            using (var StringWriter = new UtfStringWriter(settings.Encoding))
            {
                var serializer = new XmlSerializer(typeof(T));
                using (var xmlWriter = XmlWriter.Create(StringWriter, settings))
                {
                    if (disableNamespace)
                    {
                        XmlSerializerNamespaces xmlSerNameSpace = new XmlSerializerNamespaces();
                        xmlSerNameSpace.Add("", "");
                        serializer.Serialize(xmlWriter, instance, xmlSerNameSpace);
                    }
                    else
                    {
                        serializer.Serialize(xmlWriter, instance);
                    }
                }
                xml = StringWriter.ToString();
            }
            return xml;
        }
    }

    public sealed class UtfStringWriter : StringWriter
    {
        Encoding _encoding;
        public override Encoding Encoding { get { return _encoding; } }

        public UtfStringWriter(Encoding encoding)
        {
            _encoding = encoding;
        }
    }


    public sealed class JsonSerializerClass
    {
        public static string Serialize(object objectToSerialize)
        {
            string json = null;

            if (objectToSerialize != null)
            {
                MemoryStream stream = new MemoryStream();
                DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
                settings.UseSimpleDictionaryFormat = true;

                DataContractJsonSerializer serializer = new DataContractJsonSerializer(objectToSerialize.GetType(), settings);

                serializer.WriteObject(stream, objectToSerialize);
                stream.Position = 0;
                StreamReader reader = new StreamReader(stream);
                json = reader.ReadToEnd();

                reader.Dispose();
                stream.Dispose();
            }

            return json;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        public static T XMLDESerializer<T>(string strXML) where T : class
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

        public static T Deserialize<T>(string rawJson)
        {
            T deSerializedObject = default(T);
            if (string.IsNullOrWhiteSpace(rawJson) == false)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(rawJson);
                using (MemoryStream stream = new MemoryStream(bytes))
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                    deSerializedObject = (T)serializer.ReadObject(stream);
                }
            }
            return deSerializedObject;
        }

        public static T JsonDeserialize<T>(string rawJson)
        {
            T deSerializedObject = default(T);
            if (string.IsNullOrWhiteSpace(rawJson) == false)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(rawJson);
                using (MemoryStream stream = new MemoryStream(bytes))
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                    deSerializedObject = (T)serializer.ReadObject(stream);
                }
            }
            return deSerializedObject;
        }


    }

}
