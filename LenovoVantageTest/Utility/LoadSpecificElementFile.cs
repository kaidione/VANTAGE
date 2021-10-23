namespace LenovoVantageTest.Utility
{
    using LenovoVantageTest.Pages.HardwareSettingsPages;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using System;
    using System.IO;
    using System.Reflection;

    public static class LoadSpecificElementFile
    {
        public static string productBrand;

        public static JObject elementData;

        public static string fileName;

        public static string applicationId;

        public static bool DebugFlag = false;
        public static bool RunAsTw = false;

        public static string GetWorkingDict()
        {
            // Get current working directory.
            string workingDirectory = Assembly.GetExecutingAssembly().Location;
            // Get the project folder.
            string projectDiectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            return projectDiectory;
        }


        public static string ProductBrand
        {
            get
            {
                foreach (string name in TestContext.Parameters.Names)
                {
                    if (name.Contains("RunAsTW"))
                    {
                        RunAsTw = true;
                        productBrand = "Commercial";
                        VantageConstContent.VantageTypePlan = VantageConstContent.VantageType.LE;
                    }
                }
                if (TestContext.Parameters.Exists("EnterpriseBrand"))
                {
                    productBrand = TestContext.Parameters["EnterpriseBrand"];
                    VantageConstContent.VantageTypePlan = VantageConstContent.VantageType.LE;
                }
                else if (TestContext.Parameters.Exists("CommonBrand"))
                {
                    productBrand = TestContext.Parameters["CommonBrand"];
                    VantageConstContent.VantageTypePlan = VantageConstContent.VantageType.Common;
                }
                else if (TestContext.Parameters.Exists("VantageUWPType"))
                {
                    productBrand = TestContext.Parameters["VantageUWPType"];
                    VantageConstContent.VantageTypePlan = VantageConstContent.VantageType.MicroFrontends;
                }
                else if (TestContext.Parameters.Exists("NewShellOldPlugin"))
                {
                    productBrand = TestContext.Parameters["NewShellOldPlugin"];
                    VantageConstContent.VantageTypePlan = VantageConstContent.VantageType.NewShellOldPlugin;
                }
                else if (TestContext.Parameters.Exists("NewShellNewPlugin"))
                {
                    productBrand = TestContext.Parameters["NewShellNewPlugin"];
                    VantageConstContent.VantageTypePlan = VantageConstContent.VantageType.NewShellNewPlugin;
                }
                else if (TestContext.Parameters.Exists("OldShellNewPlugin"))
                {
                    productBrand = TestContext.Parameters["OldShellNewPlugin"];
                    VantageConstContent.VantageTypePlan = VantageConstContent.VantageType.OldShellNewPlugin;
                }
                else if (TestContext.Parameters.Exists("OldShellOldPlugin"))
                {
                    productBrand = TestContext.Parameters["OldShellOldPlugin"];
                    VantageConstContent.VantageTypePlan = VantageConstContent.VantageType.OldShellOldPlugin;
                }
                else if (TestContext.Parameters.Exists("TestSelf"))
                {
                    productBrand = TestContext.Parameters["TestSelf"];
                    VantageConstContent.VantageTypePlan = VantageConstContent.VantageType.TestSelf;
                }
                //Set the Default Value
                if (!Common.GetRunningProcess("devenv") && !string.IsNullOrEmpty(productBrand))
                {
                    DebugFlag = true;
                }
                if (string.IsNullOrEmpty(productBrand))
                {
                    productBrand = "Common";
                }
                if (Common.GetRunningProcess("devenv"))
                {
                    DebugFlag = false;
                }

                return productBrand;
            }
        }

        public static JObject LoadSpecificElement()
        {
            switch (ProductBrand)
            {
                case "Commercial":
                    fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CommercialVantageElements.json");
                    elementData = JObject.Parse(File.ReadAllText(fileName));
                    if (!File.Exists(VantageConstContent.LeMaskFile))
                    {
                        File.Create(VantageConstContent.LeMaskFile);
                    }
                    VantageConstContent.VantageTypePlan = VantageConstContent.VantageType.LE;
                    break;
                case "Common":
                    fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VantageAutomationIDs.json");
                    elementData = JObject.Parse(File.ReadAllText(fileName));
                    if (File.Exists(VantageConstContent.LeMaskFile))
                    {
                        File.Delete(VantageConstContent.LeMaskFile);
                    }
                    VantageConstContent.VantageTypePlan = VantageConstContent.VantageType.Common;
                    break;
                case "MicroFrontendsVantage":
                    fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VantageAutomationIDs.json");
                    elementData = JObject.Parse(File.ReadAllText(fileName));
                    if (File.Exists(VantageConstContent.LeMaskFile))
                    {
                        File.Delete(VantageConstContent.LeMaskFile);
                    }
                    VantageConstContent.VantageTypePlan = VantageConstContent.VantageType.MicroFrontends;
                    break;
                case "OldShellOldPlugin":
                case "OldShellNewPlugin":
                    fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VantageAutomationIDs.json");
                    elementData = JObject.Parse(File.ReadAllText(fileName));
                    if (File.Exists(VantageConstContent.LeMaskFile))
                    {
                        File.Delete(VantageConstContent.LeMaskFile);
                    }
                    VantageConstContent.VantageTypePlan = VantageConstContent.VantageType.OldShellOldPlugin;
                    break;
                default:
                    fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VantageAutomationIDs.json");
                    elementData = JObject.Parse(File.ReadAllText(fileName));
                    if (File.Exists(VantageConstContent.LeMaskFile))
                    {
                        File.Delete(VantageConstContent.LeMaskFile);
                    }
                    VantageConstContent.VantageTypePlan = VantageConstContent.VantageType.Common;
                    break;
            }
            return elementData;
        }

        public static string ApplicationId
        {
            get
            {
                switch (ProductBrand)
                {
                    case "Commercial":
                        fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CommercialVantageElements.json");
                        applicationId = elementData.SelectToken("ApplicationId").Value<string>();
                        break;
                    case "MicroFrontendsVantage":
                        fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VantageAutomationIDs.json");
                        applicationId = elementData.SelectToken("ApplicationId").Value<string>();
                        break;
                    default:
                        fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "VantageAutomationIDs.json");
                        applicationId = elementData.SelectToken("ApplicationId").Value<string>();
                        break;
                }

                return applicationId;
            }
        }
    }
}
