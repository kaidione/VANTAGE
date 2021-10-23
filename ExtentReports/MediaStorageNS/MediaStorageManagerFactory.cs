namespace AventStack.ExtentReports.MediaStorageNS
{
    public class MediaStorageManagerFactory
    {
        public MediaStorage GetManager(string manager)
        {
            switch (manager.Trim().ToLower())
            {
                case "http":
                    return new HttpMediaManager();
                case "http-klov":
                    return new HttpMediaManagerKlov();
                default:
                    return null;
            }
        }
    }
}
