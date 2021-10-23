using Newtonsoft.Json.Linq;
using System;
using System.IO;
namespace LenovoVantageTest.Utility
{
    class TestRequirementHelper
    {
        static TestRequirementHelper instance;
        JObject requirement = null;
        string defaultServer = "";
        string defaultSegment = "";
        TestRequirementHelper() { }
        public static TestRequirementHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestRequirementHelper();
                    instance.GetTestRequirement();
                }
                return instance;
            }
        }
        public JObject GetTestRequirement()
        {
            if (requirement == null)
            {
                string environment = "";
                using (FileStream fileStream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestCycleRequirement.json"), FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fileStream))
                {
                    environment = sr.ReadToEnd();
                }
                requirement = JObject.Parse(environment);
            }

            return requirement;
        }

        public string DefaultServer
        {
            get
            {
                if (defaultServer.Equals(""))
                {
                    defaultServer = requirement.GetValue("Server").ToString();
                }

                return defaultServer;

            }
        }

        public string DefaultSegement
        {
            get
            {
                if (defaultSegment.Equals(""))
                {
                    defaultSegment = requirement.GetValue("DefaultSegment").ToString();
                }

                return defaultSegment;
            }
        }
    }
}
