using Newtonsoft.Json.Linq;
namespace LenovoVantageTest.Utility
{
    public class XPath4Vantage3
    {
        public string Language { get; set; }
        public string IdentityName { get; set; }
        public string XPath { get; set; }
        public JObject OptionalLocators { get; set; }
        public string Page { get; set; }
        public string Description { get; set; }
    }
}
