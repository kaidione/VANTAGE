using Newtonsoft.Json;

namespace winformUI.Serialize.Bean
{

    public class DownloadData
    {
        public string resourceVersion;
        internal string resource;

        /// <summary>
        /// 
        /// </summary>
        public string downloadPath { get; set; }
    }

    public class GetUpgradeResourcesResp
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }

        [JsonProperty(PropertyName = "data")]
        public DownloadData data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
    }

}
