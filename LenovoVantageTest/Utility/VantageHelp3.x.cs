
using LenovoVantageTest.LogHelper;

namespace LenovoVantageTest.Utility
{
    class VantageHelp3
    {
        public static void uninstallVantage()
        {
            UwpAppInfo comp = UwpAppManagement.SearchUwpAppByName(Constants.appName);
            if (comp == null)
            {
                return;
            }
            else
            {
                UwpAppManagement.UninstallUwpApp(comp.PackageFullName);
            }
        }

        public static bool installVantage(string path)
        {
            bool ret = false;
            UwpAppInfo comp = UwpAppManagement.SearchUwpAppByName(Constants.appName);
            if (comp == null)
            {
                Logger.Instance.WriteLog("Vantage is not installed. install it now...", LogType.Information);
                ret = UwpAppManagement.InstallUwpApp(path);
            }
            else
            {
                Logger.Instance.WriteLog("Vantage has been installed already. Version is " + comp.Version, LogType.Information);
                ret = true;
            }
            return ret;
        }

        public static bool InstallImc(string path)
        {
            string imcVersion = IMCHelper.Singleton.IMCExeVer();
            if (string.IsNullOrEmpty(imcVersion))
            {
                Logger.Instance.WriteLog("imc not installed,and install it");
                return IMCHelper.Singleton.InstallIMC(path);
            }
            else
            {
                Logger.Instance.WriteLog("IMC has been installed already. Version is " + imcVersion);
                return true;
            }
        }
    }
}
