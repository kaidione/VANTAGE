
using System.Xml.Serialization;

namespace LenovoMultipleCleint.Bean
{
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute("ConfigBean")]
    public class ConfigBean
    {
        public string clientStatus { get; set; }

        public string serverUrl { get; set; }

        public string version { get; set; }

        public string clientName { get; set; }

        public string clientId { get; set; }

    }
}
