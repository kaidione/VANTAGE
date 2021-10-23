using System.Configuration;

namespace Appconfig
{
    public class ClientConfig
    {

        static Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public ClientConfig()
        {

        }

        public static void SetServerUrl(string value)
        {
            cfa.AppSettings.Settings["serverUrl"].Value = value.ToString();
            cfa.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static string GetServerUrl()
        {
            string licenseCode = cfa.AppSettings.Settings["serverUrl"].Value;
            return licenseCode;
        }

        public static string GetClientName()
        {
            string licenseCode = cfa.AppSettings.Settings["clientName"].Value;
            return licenseCode;
        }

        public static void SetClientName(string value)
        {
            cfa.AppSettings.Settings["clientName"].Value = value.ToString();
            cfa.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static int GetClientVersion()
        {
            string licenseCode = cfa.AppSettings.Settings["clientVersion"].Value;
            return int.Parse(licenseCode);
        }

        public static void SetClientVersion(string value)
        {
            cfa.AppSettings.Settings["clientVersion"].Value = value.ToString();
            cfa.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static string GetUpgradeSavePath()
        {
            string path = cfa.AppSettings.Settings["upgradeSavePath"].Value;
            return path;
        }

        public static string GetUpgradePath()
        {
            string path = cfa.AppSettings.Settings["upgradePath"].Value;
            return path;
        }

        public static string RunUpgradePath()
        {
            string path = cfa.AppSettings.Settings["runUpgradePath"].Value;
            return path;
        }
    }

}
