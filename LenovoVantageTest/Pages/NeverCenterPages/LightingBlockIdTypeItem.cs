using Newtonsoft.Json;
using System.Collections.Generic;

namespace LenovoVantageTest.Pages
{

    public class TypeItem
    {
        [JsonProperty("off")]
        public ulong off { get; set; }

        [JsonProperty("static")]
        public ulong effectstatic { get; set; }

        [JsonProperty("fast")]
        public ulong fast { get; set; }

        [JsonProperty("fastblink")]
        public ulong fastblink { get; set; }

        [JsonProperty("flicker")]
        public ulong flicker { get; set; }

        [JsonProperty("slow")]
        public ulong slow { get; set; }

        [JsonProperty("slowblink")]
        public ulong slowblink { get; set; }

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

        [JsonProperty("always")]
        public ulong always { get; set; }

        [JsonProperty("alwayson")]
        public ulong alwayson { get; set; }

        [JsonProperty("bounce")]
        public ulong bounce { get; set; }

        [JsonProperty("meteor")]
        public ulong meteor { get; set; }

        [JsonProperty("meteorrainbow")]
        public ulong meteorrainbow { get; set; }

        [JsonProperty("meteorcycle")]
        public ulong meteorcycle { get; set; }

        [JsonProperty("meteorrainbowcycle")]
        public ulong meteorrainbowcycle { get; set; }
        public object GetValue(string propertyName)
        {
            if (propertyName.Contains(" "))
            {
                propertyName = propertyName.Split(' ')[0];
            }
            if (propertyName.ToLower() == "static")
            {
                propertyName = "effectStatic";
            }
            return this.GetType().GetProperty(propertyName.ToLower()).GetValue(this, null);
        }
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
