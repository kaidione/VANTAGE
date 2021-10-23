using Microsoft.InternationalSettings.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;

namespace LenovoVantageTest.Utility
{
    /*Author : Marcus
        *Desc: 语言的名字是多种多样的，比如2字符en，3字符enu，4字符en-US，而且具体语言缩写我们也常不知道，比如zh-hans,pt-br。为了快速表达需要的语言，可以统一用enum。方便快捷。
        *
        */
    public enum VantageSupportedLanguageAbbreviation { ar, cs, da, de, el, en, es, fi, fr, he, hr, hu, it, ja, ko, nb, nl, pl, pt, pt_br, ro, ru, sk, sl, sr_latn, sv, tr, uk, zh_hans, zh_hant, zh_hk }
    public class Language
    {
        static Language language;
        public static Language instance
        {
            get
            {
                if (language == null)
                {
                    language = new Language();
                }
                return language;
            }
        }
        private readonly Dictionary<string, string> nlsTableInSettings = new Dictionary<string, string>();

        public Language()
        {
            //var versions = TestAgent.GetInstance().machineInfo.OperatingSystemVerion.Split('.');
            //var version = int.Parse(versions[2]);


            //if (Environment.OSVersion.Version.Build >= 17134 || version >= 17134)
            //{
            //    Logger.PrintColorText("OS is WIN10 RS4 or higher.", ConsoleColor.Cyan);

            //    //Win 10 RS4. build 17134 is RS4 RTM
            //    //InitLanguageItems_RS4();

            //}
            //else
            //{
            //    Logger.PrintColorText("OS is not WIN10 RS4 or higher.", ConsoleColor.Cyan);
            //}
            InitLanguageItems();
        }

        // <summary>
        //     设置App和Website语言：指定语言是语言列表中的第一个语言
        //     对WIN10 UWP，只需重启UWP，无需重启系统即可生效
        // </summary>
        // https://docs.microsoft.com/en-us/powershell/module/international/Set-WinUserLanguageList?view=win10-ps
        // <param name="language">语言代码，如zh-CN, en-US</param>
        public void SetALanguageAsFirstOneInLanguageList(string language)
        {
            var cmds = new List<string>
            {
                //在获取已有语言列表的表头中插入指定语言，并应用
                "$OldList = Get-WinUserLanguageList",
                $"$OldList.Insert(0,\"{language}\")",
                "Set-WinUserLanguageList -LanguageList $OldList -Force"
            };
            Common.RunPowershellCmdlet(cmds);
            Console.WriteLine($"Set preferred Language as {language}");
        }
        /*Author : Marcus
        *Desc: 
        *
        */
        public void SetALanguageAsFirstOneInLanguageList(VantageSupportedLanguageAbbreviation _language)
        {

            SetALanguageAsFirstOneInLanguageList(GetLanguageTagForPowerShellBy2LettersAbbrevation(_language));
        }
        // <summary>
        //     设置App和Website语言：指定语言是语言列表中的唯一语言(需要先安装语言包)
        //     对WIN10 UWP，只需重启UWP，无需重启系统即可生效
        // </summary>
        // https://docs.microsoft.com/en-us/powershell/module/international/Set-WinUserLanguageList?view=win10-ps
        // <param name="language">语言代码，如zh-CN, en-US</param>
        public void SetALanguageAsTheOnlyLanguage(string language)
        {
            var cmds = new List<string>
            {
                //创建一个新的仅包含指定语言的列表并应用
                $"$UserLanguageList = New-WinUserLanguageList -Language {language}",
                "Set-WinUserLanguageList -LanguageList $UserLanguageList -Force"
            };
            Common.RunPowershellCmdlet(cmds);
        }

        // <summary>
        //     设置Windows系统语言，如桌面，文件系统等,需要重启系统生效
        // </summary>
        // <param name="language">语言代码，如zh-CN, en-US</param>
        public void SetSystemLanguage(string language)
        {
            var cmds = new List<string>
            {
                //设置系统语言
                $"Set-WinUILanguageOverride -Language \"{language}\""
            };
            Common.RunPowershellCmdlet(cmds);
        }

        private void InitLanguageItems()
        {
            nlsTableInSettings.Add("ar-SA", "Language entry - Arabic (Saudi Arabia)"); //Arabic
            nlsTableInSettings.Add("cs-CZ", "Language entry - Czech"); //Czech
            nlsTableInSettings.Add("da-DK", "Language entry - Danish"); //Danish
            nlsTableInSettings.Add("de-DE", "Language entry - German (Germany)"); //German
            nlsTableInSettings.Add("el-GR", "Language entry - Greek"); //Greek
            nlsTableInSettings.Add("en-US", "Language entry - English (United States)"); //English                                             
            nlsTableInSettings.Add("es-ES", "Language entry - Spanish (Spain)"); //Spanish
            nlsTableInSettings.Add("fi-FI", "Language entry - Finnish"); //Finnish
            nlsTableInSettings.Add("fr-FR", "Language entry - French (France)"); //French
            nlsTableInSettings.Add("he-IL", "Language entry - Hebrew"); //Hebrew
            nlsTableInSettings.Add("hr-HR", "Language entry - Croatian (Croatia)"); //Croatian
            nlsTableInSettings.Add("hu-HU", "Language entry - Hungarian"); //Hungarian
            nlsTableInSettings.Add("it-IT", "Language entry - Italian (Italy)"); //Italian
            nlsTableInSettings.Add("ja-JP", "Language entry - Japanese"); //Japanese
            nlsTableInSettings.Add("ko-KR", "Language entry - Korean"); //Korean
            nlsTableInSettings.Add("nb-NO", "Language entry - Norwegian (Bokmål)"); //Norwegian
            nlsTableInSettings.Add("nl-NL", "Language entry - Dutch (Netherlands)"); //Dutch
            nlsTableInSettings.Add("pl-PL", "Language entry - Polish"); //Polish
            nlsTableInSettings.Add("pt-BR", "Language entry - Portuguese (Brazil)"); //Brazilian Portuguese
            nlsTableInSettings.Add("pt-PT", "Language entry - Portuguese (Portugal)"); //Portuguese
            nlsTableInSettings.Add("ro-RO", "Language entry - Romanian (Romania)"); //Romanian
            nlsTableInSettings.Add("ru-RU", "Language entry - Russian"); //Russian
            nlsTableInSettings.Add("sk-SK", "Language entry - Slovak"); //Slovakian
            nlsTableInSettings.Add("sl-SI", "Language entry - Slovenian"); //Slovenian
            nlsTableInSettings.Add("sr-latn-RS", "Language entry - Serbian (Latin, Serbia)"); //Serbian (Latin)
            nlsTableInSettings.Add("sv-SE", "Language entry - Swedish (Sweden)"); //Swedish
            nlsTableInSettings.Add("tr-TR", "Language entry - Turkish"); //Turkish
            nlsTableInSettings.Add("uk-UA", "Language entry - Ukrainian"); //Ukrainian
            nlsTableInSettings.Add("zh-CN", "Language entry - Chinese (Simplified, China)"); //Chinese (Simplified)
            nlsTableInSettings.Add("zh-TW", "Language entry - Chinese (Traditional, Taiwan)"); //Chinese (Traditional)
            nlsTableInSettings.Add("th-TH", "Language entry - Thai"); //Thai
            nlsTableInSettings.Add("id-ID", "Language entry - Indonesian"); //Indonesian
            nlsTableInSettings.Add("vi-VN", "Language entry - Vietnamese"); //Vietnamese
        }

        private void InitLanguageItems_RS4()
        {
            nlsTableInSettings.Add("ar-SA", "Language entry - Arabic (Saudi Arabia) - Language pack installed"); //Arabic
            nlsTableInSettings.Add("cs-CZ", "Language entry - Czech - Language pack installed"); //Czech
            nlsTableInSettings.Add("da-DK", "Language entry - Danish - Language pack installed"); //Danish
            nlsTableInSettings.Add("de-DE", "Language entry - German (Germany) - Language pack installed"); //German
            nlsTableInSettings.Add("el-GR", "Language entry - Greek - Language pack installed"); //Greek
            nlsTableInSettings.Add("en-US", "Language entry - English (United States) - Windows display language"); //English                                             
            nlsTableInSettings.Add("es-ES", "Language entry - Spanish (Spain) - Language pack installed"); //Spanish
            nlsTableInSettings.Add("fi-FI", "Language entry - Finnish - Language pack installed"); //Finnish
            nlsTableInSettings.Add("fr-FR", "Language entry - French (France) - Language pack installed"); //French
            nlsTableInSettings.Add("he-IL", "Language entry - Hebrew - Language pack installed"); //Hebrew
            nlsTableInSettings.Add("hr-HR", "Language entry - Croatian (Croatia) - Language pack installed"); //Croatian
            nlsTableInSettings.Add("hu-HU", "Language entry - Hungarian - Language pack installed"); //Hungarian
            nlsTableInSettings.Add("it-IT", "Language entry - Italian (Italy) - Language pack installed"); //Italian
            nlsTableInSettings.Add("ja-JP", "Language entry - Japanese - Language pack installed"); //Japanese
            nlsTableInSettings.Add("ko-KR", "Language entry - Korean - Language pack installed"); //Korean
            nlsTableInSettings.Add("nb-NO", "Language entry - Norwegian (Bokmål) - Language pack installed"); //Norwegian
            nlsTableInSettings.Add("nl-NL", "Language entry - Dutch (Netherlands) - Language pack installed"); //Dutch
            nlsTableInSettings.Add("pl-PL", "Language entry - Polish - Language pack installed"); //Polish
            nlsTableInSettings.Add("pt-BR", "Language entry - Portuguese (Brazil) - Language pack installed"); //Brazilian Portuguese
            nlsTableInSettings.Add("pt-PT", "Language entry - Portuguese (Portugal) - Language pack installed"); //Portuguese
            nlsTableInSettings.Add("ro-RO", "Language entry - Romanian (Romania) - Language pack installed"); //Romanian
            nlsTableInSettings.Add("ru-RU", "Language entry - Russian - Language pack installed"); //Russian
            nlsTableInSettings.Add("sk-SK", "Language entry - Slovak - Language pack installed"); //Slovakian
            nlsTableInSettings.Add("sl-SI", "Language entry - Slovenian - Language pack installed"); //Slovenian
            nlsTableInSettings.Add("sr-latn-RS", "Language entry - Serbian (Latin, Serbia) - Language pack installed"); //Serbian (Latin)
            nlsTableInSettings.Add("sv-SE", "Language entry - Swedish (Sweden) - Language pack installed"); //Swedish
            nlsTableInSettings.Add("tr-TR", "Language entry - Turkish - Language pack installed"); //Turkish
            nlsTableInSettings.Add("uk-UA", "Language entry - Ukrainian - Language pack installed"); //Ukrainian
            nlsTableInSettings.Add("zh-CN", "Language entry - Chinese (Simplified, China) - Language pack installed"); //Chinese (Simplified)
            nlsTableInSettings.Add("zh-TW", "Language entry - Chinese (Traditional, Taiwan) - Language pack installed"); //Chinese (Traditional)
            nlsTableInSettings.Add("th-TH", "Language entry - Thai - Language pack installed"); //Thai
            nlsTableInSettings.Add("id-ID", "Language entry - Indonesian - Language pack installed"); //Indonesian
            nlsTableInSettings.Add("vi-VN", "Language entry - Vietnamese - Language pack installed"); //Vietnamese
        }

        public VantageSupportedLanguageAbbreviation GetVantageSupportedLanguageAbbrievationEnumByString(string _language)
        {
            switch (_language)
            {
                case "ar":
                    return VantageSupportedLanguageAbbreviation.ar;
                case "cs":
                    return VantageSupportedLanguageAbbreviation.cs;
                case "da":
                    return VantageSupportedLanguageAbbreviation.da;
                case "de":
                    return VantageSupportedLanguageAbbreviation.de;
                case "el":
                    return VantageSupportedLanguageAbbreviation.el;
                case "en":
                    return VantageSupportedLanguageAbbreviation.en;
                case "es":
                    return VantageSupportedLanguageAbbreviation.es;
                case "fi":
                    return VantageSupportedLanguageAbbreviation.fi;
                case "fr":
                    return VantageSupportedLanguageAbbreviation.fr;
                case "he":
                    return VantageSupportedLanguageAbbreviation.he;
                case "hr":
                    return VantageSupportedLanguageAbbreviation.hr;
                case "hu":
                    return VantageSupportedLanguageAbbreviation.hu;
                case "it":
                    return VantageSupportedLanguageAbbreviation.it;
                case "ja":
                    return VantageSupportedLanguageAbbreviation.ja;
                case "ko":
                    return VantageSupportedLanguageAbbreviation.ko;
                case "nb":
                    return VantageSupportedLanguageAbbreviation.nb;
                case "nl":
                    return VantageSupportedLanguageAbbreviation.nl;
                case "pl":
                    return VantageSupportedLanguageAbbreviation.pl;
                case "pt":
                    return VantageSupportedLanguageAbbreviation.pt;
                case "pt-br":
                    return VantageSupportedLanguageAbbreviation.pt_br;
                case "ro":
                    return VantageSupportedLanguageAbbreviation.ro;
                case "ru":
                    return VantageSupportedLanguageAbbreviation.ru;
                case "sk":
                    return VantageSupportedLanguageAbbreviation.sk;
                case "sl":
                    return VantageSupportedLanguageAbbreviation.sl;
                case "sr-latn":
                    return VantageSupportedLanguageAbbreviation.sr_latn;
                case "sv":
                    return VantageSupportedLanguageAbbreviation.sv;
                case "tr":
                    return VantageSupportedLanguageAbbreviation.tr;
                case "uk":
                    return VantageSupportedLanguageAbbreviation.uk;
                case "zh-hans":
                    return VantageSupportedLanguageAbbreviation.zh_hans;
                case "zh-hant":
                    return VantageSupportedLanguageAbbreviation.zh_hant;
                default:
                    throw new Exception("GetVantageSupportedLanguageAbbrievationEnumByString,()Invalid language name"); ;
            }
        }
        /*Author : Marcus
        *Desc: Powershell里的language Name是4letter的，为了对比已安装的语言，那就需要把表达式的2letter语言转换到4letter
        *
        */
        public string GetLanguageTagForPowerShellBy2LettersAbbrevation(VantageSupportedLanguageAbbreviation _language)
        {
            string languageName = "en-US";
            switch (_language)
            {
                case VantageSupportedLanguageAbbreviation.ar:
                    languageName = "ar-SA";
                    break;
                case VantageSupportedLanguageAbbreviation.cs:
                    languageName = "cs";
                    break;
                case VantageSupportedLanguageAbbreviation.da:
                    languageName = "da";
                    break;
                case VantageSupportedLanguageAbbreviation.de:
                    languageName = "de-DE";
                    break;
                case VantageSupportedLanguageAbbreviation.el:
                    languageName = "el";
                    break;
                case VantageSupportedLanguageAbbreviation.en:
                    languageName = "en-US";
                    break;
                case VantageSupportedLanguageAbbreviation.es:
                    languageName = "es-ES";
                    break;
                case VantageSupportedLanguageAbbreviation.fi:
                    languageName = "fi";
                    break;
                case VantageSupportedLanguageAbbreviation.fr:
                    languageName = "fr-FR";
                    break;
                case VantageSupportedLanguageAbbreviation.he:
                    languageName = "he";
                    break;
                case VantageSupportedLanguageAbbreviation.hr:
                    languageName = "hr-HR";
                    break;
                case VantageSupportedLanguageAbbreviation.hu:
                    languageName = "hu";
                    break;
                case VantageSupportedLanguageAbbreviation.it:
                    languageName = "it-IT";
                    break;
                case VantageSupportedLanguageAbbreviation.ja:
                    languageName = "ja";
                    break;
                case VantageSupportedLanguageAbbreviation.ko:
                    languageName = "ko";
                    break;
                case VantageSupportedLanguageAbbreviation.nb:
                    languageName = "nb";
                    break;
                case VantageSupportedLanguageAbbreviation.nl:
                    languageName = "nl-NL";
                    break;
                case VantageSupportedLanguageAbbreviation.pl:
                    languageName = "pl";
                    break;
                case VantageSupportedLanguageAbbreviation.pt:
                    languageName = "pt-PT";
                    break;
                case VantageSupportedLanguageAbbreviation.pt_br:
                    languageName = "pt-BR";
                    break;
                case VantageSupportedLanguageAbbreviation.ro:
                    languageName = "ro-RO";
                    break;
                case VantageSupportedLanguageAbbreviation.ru:
                    languageName = "ru";
                    break;
                case VantageSupportedLanguageAbbreviation.sk:
                    languageName = "sk";
                    break;
                case VantageSupportedLanguageAbbreviation.sl:
                    languageName = "sl";
                    break;
                case VantageSupportedLanguageAbbreviation.sr_latn:
                    languageName = "sr-Latn-RS";
                    break;
                case VantageSupportedLanguageAbbreviation.sv:
                    languageName = "sv-SE";
                    break;
                case VantageSupportedLanguageAbbreviation.tr:
                    languageName = "tr";
                    break;
                case VantageSupportedLanguageAbbreviation.uk:
                    languageName = "uk";
                    break;
                case VantageSupportedLanguageAbbreviation.zh_hans:
                    languageName = "zh-Hans-CN";
                    break;
                case VantageSupportedLanguageAbbreviation.zh_hant:
                    languageName = "zh-Hans-TW";
                    break;
                default:
                    throw new Exception("Get4LettersLanguageNameBy2LettersAbbrevation,()Invalid language name");
            }
            return languageName;
        }
        /*Author : Marcus
         *Desc: Powershell里的语言是4letter的，为了知道本机安装了哪些语言，就要把它们转换为容易理解的2letter enum.
         *
         */
        public VantageSupportedLanguageAbbreviation Get2LettersLanguageNameByPowerShellLanguageTag(string _language)
        {
            VantageSupportedLanguageAbbreviation languageName = VantageSupportedLanguageAbbreviation.en;
            switch (_language)
            {
                case "ar-SA":
                    languageName = VantageSupportedLanguageAbbreviation.ar;
                    break;
                case "cs":
                    languageName = VantageSupportedLanguageAbbreviation.cs;
                    break;
                case "da":
                    languageName = VantageSupportedLanguageAbbreviation.da;
                    break;
                case "de-DE":
                    languageName = VantageSupportedLanguageAbbreviation.de;
                    break;
                case "el":
                    languageName = VantageSupportedLanguageAbbreviation.el;
                    break;
                case "en-US":
                    languageName = VantageSupportedLanguageAbbreviation.en;
                    break;
                case "es-ES":
                    languageName = VantageSupportedLanguageAbbreviation.es;
                    break;
                case "fi":
                    languageName = VantageSupportedLanguageAbbreviation.fi;
                    break;
                case "fr-FR":
                    languageName = VantageSupportedLanguageAbbreviation.fr;
                    break;
                case "he":
                    languageName = VantageSupportedLanguageAbbreviation.he;
                    break;
                case "hr-HR":
                    languageName = VantageSupportedLanguageAbbreviation.hr;
                    break;
                case "hu":
                    languageName = VantageSupportedLanguageAbbreviation.hu;
                    break;
                case "it-IT":
                    languageName = VantageSupportedLanguageAbbreviation.it;
                    break;
                case "ja":
                    languageName = VantageSupportedLanguageAbbreviation.ja;
                    break;
                case "ko":
                    languageName = VantageSupportedLanguageAbbreviation.ko;
                    break;
                case "nb":
                    languageName = VantageSupportedLanguageAbbreviation.nb;
                    break;
                case "nl-NL":
                    languageName = VantageSupportedLanguageAbbreviation.nl;
                    break;
                case "pl":
                    languageName = VantageSupportedLanguageAbbreviation.pl;
                    break;
                case "pt-PT":
                    languageName = VantageSupportedLanguageAbbreviation.pt;
                    break;
                case "pt-BR":
                    languageName = VantageSupportedLanguageAbbreviation.pt_br;
                    break;
                case "ro-RO":
                    languageName = VantageSupportedLanguageAbbreviation.ro;
                    break;
                case "ru":
                    languageName = VantageSupportedLanguageAbbreviation.ru;
                    break;
                case "sk":
                    languageName = VantageSupportedLanguageAbbreviation.sk;
                    break;
                case "sl":
                    languageName = VantageSupportedLanguageAbbreviation.sl;
                    break;
                case "sr-Latn-RS":
                    languageName = VantageSupportedLanguageAbbreviation.sr_latn;
                    break;
                case "sv-SE":
                    languageName = VantageSupportedLanguageAbbreviation.sv;
                    break;
                case "tr":
                    languageName = VantageSupportedLanguageAbbreviation.tr;
                    break;
                case "uk":
                    languageName = VantageSupportedLanguageAbbreviation.uk;
                    break;
                case "zh-Hans-CN":
                    languageName = VantageSupportedLanguageAbbreviation.zh_hans;
                    break;
                case "zh-Hant-TW":
                    languageName = VantageSupportedLanguageAbbreviation.zh_hant;
                    break;
                case "zh-Hant-HK":
                    languageName = VantageSupportedLanguageAbbreviation.zh_hk;
                    break;
                default:
                    throw new Exception("Get2LettersLanguageNameBy4LettersAbbrevation() , Invalid language name");
            }
            return languageName;
        }

        /*Author : Marcus
        *Desc: 获取语言设置里的第一个prefered language
        *
        */
        public VantageSupportedLanguageAbbreviation GetPrefered1stLanguage_2letters()
        {

            return GetPreferedLanguageList_2letters()[0];
        }


        /*Author : Marcus
        *Desc: 获取所有已安装的语言List
        *
        */
        public List<VantageSupportedLanguageAbbreviation> GetPreferedLanguageList_2letters()
        {
            List<VantageSupportedLanguageAbbreviation> lanlist = new List<VantageSupportedLanguageAbbreviation>();
            using (PowerShell powerShell = PowerShell.Create())
            {
                powerShell.Commands.AddScript("Get-WinUserLanguageList");
                Collection<PSObject> PSOutput = powerShell.Invoke();
                foreach (PSObject languageList in PSOutput)
                {
                    List<WinUserLanguage> wulLanguageList = (List<WinUserLanguage>)languageList.BaseObject;
                    foreach (WinUserLanguage preferredLanguage in wulLanguageList)
                    {
                        lanlist.Add(Get2LettersLanguageNameByPowerShellLanguageTag(preferredLanguage.LanguageTag));
                    }

                }
            }
            return lanlist;
        }
    }


}