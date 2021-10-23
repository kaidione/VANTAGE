using System.Collections.Generic;

namespace LenovoVantageTest.Utility
{
    public class MachineListItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string MachineIp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ACDCServerIp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BtnId { get; set; }
    }

    public class ACDCMachineListBean
    {
        /// <summary>
        /// 
        /// </summary>
        public List<MachineListItem> MachineList { get; set; }
    }

}
