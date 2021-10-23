using Newtonsoft.Json.Linq;
using System;
using System.IO;
namespace LenovoVantageTest.Utility.Readers
{
    class TestRequirementHelper
    {
        static TestRequirementHelper instance;
        TestRequirementHelper() { }
        public static TestRequirementHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestRequirementHelper();
                }
                return instance;
            }
        }
        public JObject GetTestRequirement()
        {
            string environment = "";
            using (FileStream fileStream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestCycleRequirement.json"), FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fileStream))
            {
                environment = sr.ReadToEnd();
            }
            JObject joEnvironmentRequirement = JObject.Parse(environment);
            return joEnvironmentRequirement;
        }
    }
}
