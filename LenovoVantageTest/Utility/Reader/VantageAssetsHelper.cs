using Newtonsoft.Json.Linq;
using System;
using System.IO;
namespace LenovoVantageTest.Utility
{
    class VantageAssetsHelper
    {
        static VantageAssetsHelper vantageAssetsHelper;
        JObject joGUIContent;
        static string vantageAssetLocalFoldername = "assets";
        VantageSupportedLanguageAbbreviation usedLanguage;
        string guiContent = "";
        VantageAssetsHelper()
        {

        }
        public static VantageAssetsHelper SingleTon
        {
            get
            {
                JObject joEnvironmentRequirement = TestRequirementHelper.Instance.GetTestRequirement();
                string vantageAssets_SharePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, joEnvironmentRequirement.GetValue("VantageAssetPath").ToString());
                string vantageAssets_LocalPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, vantageAssetLocalFoldername);

                if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, vantageAssetLocalFoldername)))
                {
                    //Copy action放在*.bat里完成，防止C#前面的code断网。
                    throw new Exception("VantageAsset does NOT exist at share folder !! It contains all GUI content. I'll copy it to local");
                }
                if (vantageAssetsHelper == null)
                {
                    vantageAssetsHelper = new VantageAssetsHelper();
                }
                return vantageAssetsHelper;
            }
        }
        public JToken GetSpecificGUIContentByLanguage(string _jpath, VantageSupportedLanguageAbbreviation _lang = VantageSupportedLanguageAbbreviation.en)
        {
            JObject content = JObject.Parse(GetGUIContentByLanguage(_lang));
            return content.SelectToken(_jpath);
        }
        string GetGUIContentByLanguage(VantageSupportedLanguageAbbreviation _lang = VantageSupportedLanguageAbbreviation.en)
        {
            //之前已经保存过来，并且是同一个语言的内容就直接返回好了。
            if (_lang == usedLanguage && !guiContent.Equals(""))
            {
                return guiContent;
            }

            using (FileStream fileStream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "assets\\i18n", retrieveLanguageFileName(_lang) + ".json"), FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fileStream))
            {
                guiContent = sr.ReadToEnd();
            }
            usedLanguage = _lang;
            return guiContent;
        }
        string retrieveLanguageFileName(VantageSupportedLanguageAbbreviation _lang = VantageSupportedLanguageAbbreviation.en)
        {
            string language;
            switch (_lang)
            {
                case VantageSupportedLanguageAbbreviation.ar:
                    return "ar";
                case VantageSupportedLanguageAbbreviation.cs:
                    return "cs";
                case VantageSupportedLanguageAbbreviation.da:
                    return "da";
                case VantageSupportedLanguageAbbreviation.de:
                    return "de";
                case VantageSupportedLanguageAbbreviation.el:
                    return "el";
                case VantageSupportedLanguageAbbreviation.en:
                    return "en";
                case VantageSupportedLanguageAbbreviation.es:
                    return "es";
                case VantageSupportedLanguageAbbreviation.fi:
                    return "fi";
                case VantageSupportedLanguageAbbreviation.fr:
                    return "fr";
                case VantageSupportedLanguageAbbreviation.he:
                    return "he";
                case VantageSupportedLanguageAbbreviation.hr:
                    return "hr";
                case VantageSupportedLanguageAbbreviation.hu:
                    return "hu";
                case VantageSupportedLanguageAbbreviation.it:
                    return "it";
                case VantageSupportedLanguageAbbreviation.ja:
                    return "ja";
                case VantageSupportedLanguageAbbreviation.ko:
                    return "ko";
                case VantageSupportedLanguageAbbreviation.nb:
                    return "nb";
                case VantageSupportedLanguageAbbreviation.nl:
                    return "nl";
                case VantageSupportedLanguageAbbreviation.pl:
                    return "pl";
                case VantageSupportedLanguageAbbreviation.pt:
                    return "pt";
                case VantageSupportedLanguageAbbreviation.pt_br:
                    return "pt-br";
                case VantageSupportedLanguageAbbreviation.ro:
                    return "ro";
                case VantageSupportedLanguageAbbreviation.ru:
                    return "ru";
                case VantageSupportedLanguageAbbreviation.sk:
                    return "sk";
                case VantageSupportedLanguageAbbreviation.sl:
                    return "sl";
                case VantageSupportedLanguageAbbreviation.sr_latn:
                    return "sr-latn";
                case VantageSupportedLanguageAbbreviation.sv:
                    return "sv";
                case VantageSupportedLanguageAbbreviation.tr:
                    return "tr";
                case VantageSupportedLanguageAbbreviation.uk:
                    return "uk";
                case VantageSupportedLanguageAbbreviation.zh_hans:
                    return "zh-hans";
                case VantageSupportedLanguageAbbreviation.zh_hant:
                    return "zh-hant";
                default:
                    throw new Exception("Invalid language name");
            }
        }
    }
}
