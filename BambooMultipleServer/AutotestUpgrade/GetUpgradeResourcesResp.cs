using Newtonsoft.Json;

namespace winformUI.Serialize.Bean
{

    public class DownloadData
    {
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
