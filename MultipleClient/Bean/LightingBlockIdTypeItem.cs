using System.Windows.Automation;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LenovoVantageTest.Pages
{

    public class TypeItem
    {
        [JsonProperty("off")]
        public ulong off { get; set; }

        [JsonProperty("static")]
        public ulong effectStatic { get; set; }

        [JsonProperty("fast")]
        public ulong fast { get; set; }

        [JsonProperty("slow")]
        public ulong slow { get; set; }

        [JsonProperty("breath")]
        public ulong breath { get; set; }

        [JsonProperty("wave")]
        public ulong wave { get; set; }
        
        [JsonProperty("spectrum")]
        public ulong spectrum { get; set; }
        
        [JsonProperty("cputemperature")]
        public ulong cputemperature { get; set; }

        [JsonProperty("cpuutilization")]
        public ulong cpuutilization { get; set; }

        [JsonProperty("rainbow")]
        public ulong rainbow { get; set; }

        [JsonProperty("random")]
        public ulong random { get; set; }

        [JsonProperty("coolblue")]
        public ulong coolblue { get; set; }

        [JsonProperty("waveright")]
        public ulong waveright { get; set; }

        [JsonProperty("waveleft")]
        public ulong waveleft { get; set; }
    }


    public class LightingBlockIdTypeItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string Familyname { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<int> Blockid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public TypeItem Type { get; set; }
    }

    public class LightingBlockIdTypeRoot
    {
        /// <summary>
        /// 
        /// </summary>
        public List<LightingBlockIdTypeItem> LightingBlockIdType { get; set; }

        public List<int> colorid { get; set; }

    }

}
