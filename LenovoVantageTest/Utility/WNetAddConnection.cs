using System.Runtime.InteropServices;
namespace LenovoVantageTest.Utility
{
    public enum ResourceScope
    {
        RESOURCE_CONNECTED = 1,
        RESOURCE_GLOBALNET,
        RESOURCE_REMEMBERED,
        RESOURCE_RECENT,
        RESOURCE_CONTEXT
    };

    public enum ResourceType
    {
        RESOURCETYPE_ANY = 0,
        RESOURCETYPE_DISK = 1,
        RESOURCETYPE_PRINT = 2,
        RESOURCETYPE_RESERVED = 8,
        RESOURCETYPE_UNKNOWN = -1,
    };

    public enum ResourceUsage
    {
        RESOURCEUSAGE_CONNECTABLE = 0x00000001,
        RESOURCEUSAGE_CONTAINER = 0x00000002,
        RESOURCEUSAGE_NOLOCALDEVICE = 0x00000004,
        RESOURCEUSAGE_SIBLING = 0x00000008,
        RESOURCEUSAGE_ATTACHED = 0x00000010,
        RESOURCEUSAGE_ALL = (RESOURCEUSAGE_CONNECTABLE | RESOURCEUSAGE_CONTAINER | RESOURCEUSAGE_ATTACHED),
    };

    public enum ResourceDisplayType
    {
        RESOURCEDISPLAYTYPE_GENERIC,
        RESOURCEDISPLAYTYPE_DOMAIN,
        RESOURCEDISPLAYTYPE_SERVER,
        RESOURCEDISPLAYTYPE_SHARE,
        RESOURCEDISPLAYTYPE_FILE,
        RESOURCEDISPLAYTYPE_GROUP,
        RESOURCEDISPLAYTYPE_NETWORK,
        RESOURCEDISPLAYTYPE_ROOT,
        RESOURCEDISPLAYTYPE_SHAREADMIN,
        RESOURCEDISPLAYTYPE_DIRECTORY,
        RESOURCEDISPLAYTYPE_TREE,
        RESOURCEDISPLAYTYPE_NDSCONTAINER
    };

    [StructLayout(LayoutKind.Sequential)]
    class NETRESOURCE
    {
        public ResourceScope dwScope = 0;
        public ResourceType dwType = 0;
        public ResourceDisplayType dwDisplayType = 0;
        public ResourceUsage dwUsage = 0;
        public string lpLocalName = null;
        public string lpRemoteName = null;
        public string lpComment = null;
        public string lpProvider = null;
    };

}
