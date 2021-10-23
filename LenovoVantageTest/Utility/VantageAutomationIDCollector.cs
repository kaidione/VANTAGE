using Newtonsoft.Json.Linq;
using System;
using System.IO;
namespace LenovoVantageTest.Utility
{
    class VantageAutomationIDCollector
    {
        static VantageAutomationIDCollector instance;
        JObject joVantageIDs = null;
        VantageAutomationIDCollector()
        {
            string idCollection = "VantageAutomationIDs.json";
            if (LoadSpecificElementFile.ProductBrand.Equals("Commercial"))
            {
                idCollection = "CommercialVantageElements.json";
            }
            using (FileStream filestream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, idCollection), FileMode.Open, FileAccess.ReadWrite))
            using (StreamReader streamReader = new StreamReader(filestream))
            {
                string content = streamReader.ReadToEnd();
                joVantageIDs = JObject.Parse(content);
            }
        }

        public static VantageAutomationIDCollector Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VantageAutomationIDCollector();
                }
                return instance;
            }
        }
        public JObject GetVantageAutomationIDs()
        {
            return joVantageIDs;
        }
        public JToken GetVantageAutomationID(string _jpath)
        {
            return joVantageIDs.SelectToken(_jpath);
        }
    }
}
