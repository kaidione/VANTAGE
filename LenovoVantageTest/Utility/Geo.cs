using LenovoVantageTest.LogHelper;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

//Author: Should be Garrick
//Desc: https://superuser.com/questions/1354256/how-can-i-programmatically-access-the-region-of-a-windows-computer
//      To change the OS region , modifying directly registry is a way, powershell is another way around.
//Date:2019/5/27
namespace LenovoVantageTest.Utility
{
    public class Geo
    {
        static Dictionary<string, int> geoList = null;

        private static void InitializeGeoList()
        {
            geoList = new Dictionary<string, int>
            {
                { "Antigua and Barbuda", 2 },
                { "Afghanistan", 3 },
                { "Algeria", 4 },
                { "Azerbaijan", 5 },
                { "Albania", 6 },
                { "Armenia", 7 },
                { "Andorra", 8 },
                { "Angola", 9 },
                { "American Samoa", 10 },
                { "Argentina", 11 },
                { "Australia", 12 },
                { "Austria", 14 },
                { "Bahrain", 17 },
                { "Barbados", 18 },
                { "Botswana", 19 },
                { "Bermuda", 20 },
                { "Belgium", 21 },
                { "Bahamas, The", 22 },
                { "Bangladesh", 23 },
                { "Belize", 24 },
                { "Bosnia and Herzegovina", 25 },
                { "Bolivia", 26 },
                { "Myanmar", 27 },
                { "Benin", 28 },
                { "Belarus", 29 },
                { "Solomon Islands", 30 },
                { "Brazil", 32 },
                { "Bhutan", 34 },
                { "Bulgaria", 35 },
                { "Brunei", 37 },
                { "Burundi", 38 },
                { "Canada", 39 },
                { "Cambodia", 40 },
                { "Chad", 41 },
                { "Sri Lanka", 42 },
                { "Congo", 43 },
                { "Congo(DRC)", 44 },
                { "China", 45 },
                { "Chile", 46 },
                { "Cameroon", 49 },
                { "Comoros", 50 },
                { "Colombia", 51 },
                { "Costa Rica", 54 },
                { "Central African Republic", 55 },
                { "Cuba", 56 },
                { "Cabo Verde", 57 },
                { "Cyprus", 59 },
                { "Denmark", 61 },
                { "Djibouti", 62 },
                { "Dominica", 63 },
                { "Dominican Republic", 65 },
                { "Ecuador", 66 },
                { "Egypt", 67 },
                { "Ireland", 68 },
                { "Equatorial Guinea", 69 },
                { "Estonia", 70 },
                { "Eritrea", 71 },
                { "El Salvador", 72 },
                { "Ethiopia", 73 },
                { "Czech Republic", 75 },
                { "Finland", 77 },
                { "Fiji", 78 },
                { "Micronesia", 80 },
                { "Faroe Islands", 81 },
                { "France", 84 },
                { "Gambia", 86 },
                { "Gabon", 87 },
                { "Georgia", 88 },
                { "Ghana", 89 },
                { "Gibraltar", 90 },
                { "Grenada", 91 },
                { "Greenland", 93 },
                { "Germany", 94 },
                { "Greece", 98 },
                { "Guatemala", 99 },
                { "Guinea", 100 },
                { "Guyana", 101 },
                { "Haiti", 103 },
                { "Hong Kong SAR", 104 },
                { "Honduras", 106 },
                { "Croatia", 108 },
                { "Hungary", 109 },
                { "Iceland", 110 },
                { "Indonesia", 111 },
                { "India", 113 },
                { "British Indian Ocean Territory", 114 },
                { "Iran", 116 },
                { "Israel", 117 },
                { "Italy", 118 },
                { "Côte d'Ivoire", 119 },
                { "Iraq", 121 },
                { "Japan", 122 },
                { "Jamaica", 124 },
                { "Jan Mayen", 125 },
                { "Jordan", 126 },
                { "Johnston Atoll", 127 },
                { "Kenya", 129 },
                { "Kyrgyzstan", 130 },
                { "North Korea", 131 },
                { "Kiribati", 133 },
                { "Korea", 134 },
                { "Kuwait", 136 },
                { "Kazakhstan", 137 },
                { "Laos", 138 },
                { "Lebanon", 139 },
                { "Latvia", 140 },
                { "Lithuania", 141 },
                { "Liberia", 142 },
                { "Slovakia", 143 },
                { "Liechtenstein", 145 },
                { "Lesotho", 146 },
                { "Luxembourg", 147 },
                { "Libya", 148 },
                { "Madagascar", 149 },
                { "Macao SAR", 151 },
                { "Moldova", 152 },
                { "Mongolia", 154 },
                { "Malawi", 156 },
                { "Mali", 157 },
                { "Monaco", 158 },
                { "Morocco", 159 },
                { "Mauritius", 160 },
                { "Mauritania", 162 },
                { "Malta", 163 },
                { "Oman", 164 },
                { "Maldives", 165 },
                { "Mexico", 166 },
                { "Malaysia", 167 },
                { "Mozambique", 168 },
                { "Niger", 173 },
                { "Vanuatu", 174 },
                { "Nigeria", 175 },
                { "Netherlands", 176 },
                { "Norway", 177 },
                { "Nepal", 178 },
                { "Nauru", 180 },
                { "Suriname", 181 },
                { "Nicaragua", 182 },
                { "New Zealand", 183 },
                { "Palestinian Authority", 184 },
                { "Paraguay", 185 },
                { "Peru", 187 },
                { "Pakistan", 190 },
                { "Poland", 191 },
                { "Panama", 192 },
                { "Portugal", 193 },
                { "Papua New Guinea", 194 },
                { "Palau", 195 },
                { "Guinea-Bissau", 196 },
                { "Qatar", 197 },
                { "Réunion", 198 },
                { "Marshall Islands", 199 },
                { "Romania", 200 },
                { "Philippines", 201 },
                { "Puerto Rico", 202 },
                { "Russia", 203 },
                { "Rwanda", 204 },
                { "Saudi Arabia", 205 },
                { "Saint Pierre and Miquelon", 206 },
                { "Saint Kitts and Nevis", 207 },
                { "Seychelles", 208 },
                { "South Africa", 209 },
                { "Senegal", 210 },
                { "Slovenia", 212 },
                { "Sierra Leone", 213 },
                { "San Marino", 214 },
                { "Singapore", 215 },
                { "Somalia", 216 },
                { "Spain", 217 },
                { "Saint Lucia", 218 },
                { "Sudan", 219 },
                { "Svalbard", 220 },
                { "Sweden", 221 },
                { "Syria", 222 },
                { "Switzerland", 223 },
                { "United Arab Emirates", 224 },
                { "Trinidad and Tobago", 225 },
                { "Thailand", 227 },
                { "Tajikistan", 228 },
                { "Tonga", 231 },
                { "Togo", 232 },
                { "São Tomé and Príncipe", 233 },
                { "Tunisia", 234 },
                { "Turkey", 235 },
                { "Tuvalu", 236 },
                { "Taiwan", 237 },
                { "Turkmenistan", 238 },
                { "Tanzania", 239 },
                { "Uganda", 240 },
                { "Ukraine", 241 },
                { "United Kingdom", 242 },
                { "United States", 244 },
                { "Burkina Faso", 245 },
                { "Uruguay", 246 },
                { "Uzbekistan", 247 },
                { "Saint Vincent and the Grenadines", 248 },
                { "Venezuela", 249 },
                { "Vietnam", 251 },
                { "U.S. Virgin Islands", 252 },
                { "Vatican City", 253 },
                { "Namibia", 254 },
                { "Wake Island", 258 },
                { "Samoa", 259 },
                { "Swaziland", 260 },
                { "Yemen", 261 },
                { "Zambia", 263 },
                { "Zimbabwe", 264 },
                { "Serbia and Montenegro (Former)", 269 },
                { "Montenegro", 270 },
                { "Serbia", 271 },
                { "Curaçao", 273 },
                { "Anguilla", 300 },
                { "South Sudan", 276 },
                { "Antarctica", 301 },
                { "Aruba", 302 },
                { "Ascension Island", 303 },
                { "Ashmore and Cartier Islands", 304 },
                { "Baker Island", 305 },
                { "Bouvet Island", 306 },
                { "Cayman Islands", 307 },
                { "Channel Islands", 308 },
                { "Christmas Island", 309 },
                { "Clipperton Island", 310 },
                { "Cocos (Keeling) Islands", 311 },
                { "Cook Islands", 312 },
                { "Coral Sea Islands", 313 },
                { "Diego Garcia", 314 },
                { "Falkland Islands", 315 },
                { "French Guiana", 317 },
                { "French Polynesia", 318 },
                { "French Southern Territories", 319 },
                { "Guadeloupe", 321 },
                { "Guam", 322 },
                { "Guantanamo Bay", 323 },
                { "Guernsey", 324 },
                { "Heard Island and McDonald Islands", 325 },
                { "Howland Island", 326 },
                { "Jarvis Island", 327 },
                { "Jersey", 328 },
                { "Kingman Reef", 329 },
                { "Martinique", 330 },
                { "Mayotte", 331 },
                { "Montserrat", 332 },
                { "Netherlands Antilles (Former)", 333 },
                { "New Caledonia", 334 },
                { "Niue", 335 },
                { "Norfolk Island", 336 },
                { "Northern Mariana Islands", 337 },
                { "Palmyra Atoll", 338 },
                { "Pitcairn Islands", 339 },
                { "Rota Island", 340 },
                { "Saipan", 341 },
                { "South Georgia and the South Sandwich Islands", 342 },
                { "St Helena, Ascension and Tristan da Cunha", 343 },
                { "Tinian Island", 346 },
                { "Tokelau", 347 },
                { "Tristan da Cunha", 348 },
                { "Turks and Caicos Islands", 349 },
                { "British Virgin Islands", 351 },
                { "Wallis and Futuna", 352 },
                { "Africa", 742 },
                { "Asia", 2129 },
                { "Europe", 10541 },
                { "Isle of Man", 15126 },
                { "Macedonia, FYRO", 19618 },
                { "Melanesia", 20900 },
                //geoList.Add("Micronesia", 21206); duplicated. MSDN error? https://docs.microsoft.com/zh-cn/windows/desktop/Intl/table-of-geographical-locations
                { "Midway Islands", 21242 },
                { "Northern America", 23581 },
                { "Polynesia", 26286 },
                { "Central America", 27082 },
                { "Oceania", 27114 },
                { "Sint Maarten", 30967 },
                { "South America", 31396 },
                { "Saint Martin", 31706 },
                { "World", 39070 },
                { "Western Africa", 42483 },
                { "Middle Africa", 42484 },
                { "Northern Africa", 42487 },
                { "Central Asia", 47590 },
                { "South-Eastern Asia", 47599 },
                { "Eastern Asia", 47600 },
                { "Eastern Africa", 47603 },
                { "Eastern Europe", 47609 },
                { "Southern Europe", 47610 },
                { "Middle East", 47611 },
                { "Southern Asia", 47614 },
                { "Timor-Leste", 7299303 },
                { "Kosovo", 9914689 },
                { "Americas", 10026358 },
                { "Åland Islands", 10028789 },
                { "Caribbean", 10039880 },
                { "Northern Europe", 10039882 },
                { "Southern Africa", 10039883 },
                { "Western Europe", 10210824 },
                { "Australia and New Zealand", 10210825 },
                { "Saint Barthélemy", 161832015 },
                { "U.S. Minor Outlying Islands", 161832256 },
                { "Latin America and the Caribbean", 161832257 },
                { "Bonaire, Sint Eustatius and Saba", 161832258 }
            };
        }

        public static int GetGeoIdByName(string countryShortName)
        {
            if (geoList == null)
            {
                InitializeGeoList();
            }
            return geoList[countryShortName];
        }

        public static string GetGeoNameById(int geoId)
        {
            if (geoList == null)
            {
                InitializeGeoList();
            }
            foreach (KeyValuePair<string, int> item in geoList)
            {
                if (item.Value.Equals(geoId))
                {
                    return item.Key;
                }
            }
            return null;
        }

        // <summary>
        // 设置系统的国家/区域
        // 对WIN10 UWP，只需重启UWP，无需重启系统即可生效
        // </summary>
        // https://docs.microsoft.com/en-us/powershell/module/international/Set-WinHomeLocation?view=win10-ps
        // https://docs.microsoft.com/zh-cn/windows/desktop/Intl/table-of-geographical-locations
        // <param name="geoId">国家/区域ID</param>
        public static void SetCountryOrRegion(int geoId)
        {
            Common.RunPowershellCmdlet($"Set-WinHomeLocation -GeoId {geoId}");
        }

        // <summary>
        // 设置系统的国家/区域
        // Marucs:Since Vatnage3.? ,对WIN10 UWP，选择Preferred language后(方法1：Settins->Language->把要使用的language从下面的list里move到top.   方法2:Settings->Language->选择Windows Dispaly Language后不用reboot. 方法3:Win10 desktop右下角切换语言)只需重启UWP，无需重启系统Vantage会自动切换语言
        // </summary>
        // https://docs.microsoft.com/en-us/powershell/module/international/Set-WinHomeLocation?view=win10-ps
        // https://docs.microsoft.com/zh-cn/windows/desktop/Intl/table-of-geographical-location
        // <param name="countryShortName">国家简要名称。e.g: China, United States...</param>
        public static void SetCountryOrRegion(string countryShortName)
        {
            int geoId = GetGeoIdByName(countryShortName);
            Common.RunPowershellCmdlet($"Set-WinHomeLocation -GeoId {geoId}");
        }
        public static int GetCurrentGeoId()
        {
            string Regkey_Region = @"HKCU\Control Panel\International\Geo\";

            string GeoIDString = RegistryHelp.GetRegistryKeyValue(Regkey_Region + "Nation").ToString();  //GeoID = "45" , means "China",	"People's Republic of China", refer to https://msdn.microsoft.com/zh-cn/library/dd374073.aspx
            int GeoID = Convert.ToInt32(GeoIDString);  //该int类型可为空,如果不加?的话,那么int类型的默认值为0
            return GeoID;
        }
        // <summary>
        // Gets the country code for the user's PC, using the GetGeoInfo pinvoke method
        // </summary>
        // <returns></returns>
        public static string GetCountryCode()
        {
            string countryCode = String.Empty;

            try
            {
                string Regkey_Region = @"HKCU\Control Panel\International\Geo\";

                string GeoIDString = RegistryHelp.GetRegistryKeyValue(Regkey_Region + "Nation").ToString();  //GeoID = "45" , means "China",	"People's Republic of China", refer to https://msdn.microsoft.com/zh-cn/library/dd374073.aspx
                int? GeoID = Convert.ToInt32(GeoIDString);  //该int类型可为空,如果不加?的话,那么int类型的默认值为0

                if (GeoID != null)
                {
                    // Create a new string with 256 characters to pass into the GetGeoInfo pinvoke method
                    countryCode = new string(' ', 256);
                    int size = GetGeoInfo(GeoID.Value, SYSGEOTYPE.GEO_ISO2, countryCode, 256, 0);

                    // Verify it returns an actual string
                    if (size <= 0)
                    {
                        return null;
                    }

                    // Set the country code string to only be the size of the code
                    countryCode = countryCode.Substring(0, size - 1);
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("Exception thrown trying to get the country code using the pinvoke method" + "\r\n" + ex.Message, LogType.Error);
            }

            return countryCode;
        }

        // <summary>
        // Gets the geography information for this system
        // </summary>
        // <param name="geoId"></param>
        // <param name="geoType"></param>
        // <param name="lpGeoData"></param>
        // <param name="cchData"></param>
        // <param name="language"></param>
        // <returns></returns>
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private extern static int GetGeoInfo(int geoId, SYSGEOTYPE geoType, string lpGeoData, int cchData, int language);

        public enum SYSGEOTYPE
        {
            GEO_NATION = 0x0001,
            GEO_LATITUDE = 0x0002,
            GEO_LONGITUDE = 0x0003,
            GEO_ISO2 = 0x0004,
            GEO_ISO3 = 0x0005,
            GEO_RFC1766 = 0x0006,
            GEO_LCID = 0x0007,
            GEO_FRIENDLYNAME = 0x0008,
            GEO_OFFICIALNAME = 0x0009,
            GEO_TIMEZONES = 0x000A,
            GEO_OFFICIALLANGUAGES = 0x000B
        }
    }
}
