using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LenovoVantageTest.Pages
{
    [Serializable]
    public class LightingItem
    {
        public string block { get; set; }

        // [XmlElementAttribute("type", IsNullable = false)]
        public string type { get; set; }

        // [XmlElementAttribute("colorid", IsNullable = false)]
        public string colorid { get; set; }

        // [XmlElementAttribute("brigness", IsNullable = false)]
        public string brightness { get; set; }

        // [XmlElementAttribute("speed", IsNullable = false)]
        public string speed { get; set; }

        public object GetValue(string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                propertyName = propertyName.Replace("lighting", "").ToLower();
            }
            return this.GetType().GetProperty(propertyName).GetValue(this, null);
        }
    }


    public class LightingStyle
    {
        [XmlElementAttribute("item", IsNullable = false)]
        public List<LightingItem> item { get; set; }
    }

    [XmlRootAttribute("ledprofilelist", IsNullable = false)]
    public class LedProfileList
    {
        [XmlElementAttribute("style1", IsNullable = false)]
        public List<LightingItem> style1 { get; set; }

        [XmlElementAttribute("style2", IsNullable = false)]
        public List<LightingItem> style2 { get; set; }

        [XmlElementAttribute("style3", IsNullable = false)]
        public List<LightingItem> style3 { get; set; }
    }

}
