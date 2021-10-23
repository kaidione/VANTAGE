namespace Http.Util
{
    public class HttpRequestConst
    {
        public static string GetUpgradeResourcesUrl = "/client/getUpgradeResources";
        public enum ResponseCode
        {
            success = 0,
            failed = 1,
            Crash = 2
        }
    }
}
