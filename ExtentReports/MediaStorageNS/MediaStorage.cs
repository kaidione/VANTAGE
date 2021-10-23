
using AventStack.ExtentReports.Model;

namespace AventStack.ExtentReports.MediaStorageNS
{
    public interface MediaStorage
    {
        void Init(string host);
        void StoreMedia(Media m);
    }
}
