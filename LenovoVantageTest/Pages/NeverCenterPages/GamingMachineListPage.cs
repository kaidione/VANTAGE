using System.Collections.Generic;

namespace LenovoVantageTest.Pages
{
    public class GamingMachineListPage
    {
        public static Dictionary<string, string> GamingMachineList = new Dictionary<string, string>()
        {
            {"Y540","Legion Y9000K 2020,Legion Y7000 2019"},
            {"Y750", "Legion Y9000K2020H,Legion Y9000K 2020,Legion 7 15IMH05,Legion 7 15IMHg05"},
            {"Y750S","Lenovo Legion R9000X 2021,Lenovo Legion Y9000X 2021,Lenovo Legion S7 15IMH05,Lenovo Legion S7 15ARH5,Lenovo Legion S7 15IMH5" },
            {"Y740S", "Legion Y740S-15IMH,Legion Y9000X2020R"},
            {"Y550", "Legion 5 15IMH05H,Legion 5P 15IMH05H,Legion 5 15IMH05,Legion 5P 15IMH05,Legion Y7000 2020,Legion Y7000 2020H,Legion Y7000P2020H,Legion Y7000P2020,Legion 5 17,Legion 5 17IMH05S,Legion 5 17IMH05H,Legion 5 17IMH05,Legion 5 15,Legion 5 15IMH05S,Legion 5P 15IMH05S,Legion Y7000 2020S,Legion Y7000P2020S,Legion 5 15,Legion 5 15IMH05H,Legion 5 AMD CPU + N GPU,Legion 5 15ARH05,Legion 5 15ARH05H,Legion R7000 2020,Legion R7000 2020H"},
            {"T550", "T550-B460,Legion T5-28IMB05,Legion T5-28IMB05,Legion T5-28IMB05,Legion T5-28IMB05,T550-B360,Legion T5-28ICB05,Legion T5-28ICB05,ZHENGJIUZHE REN7000-28IMB,ZHENGJIUZHE REN7000K-28IMB"},
            {"L350", "IdeaPad Gaming 3 15IMH05,IdeaPad Creator 5 15IMH05,IdeaPad Gaming 3 15ARH05"},
            {"T550G", "IdeaCentre GeekPro-14IMB,IdeaCentre GeekPro-14AMR,deaCentre G5 14AMR05,IdeaCentre G5 14IMB05"},
            {"T750", "Legion T7 34IMZ05"}
        };

        //key ui NAME, VALUE is the log name and blockId

        public static Dictionary<string, string> GamingLightingTypesList = new Dictionary<string, string>()
        {
            {"Legion Icon Lighting (Front)", "SetSimpleLighting,SetLighting"},
            {"Internal Ambient Lighting", "SetSimpleLighting,SetLighting"},
            {"Legion CPU Fan Lighting", "SetFanLighting,SetLighting" },
            {"Legion Rear Fan Lighting", "SetFanLighting,SetLighting"},
            {"Legion Liquid Cooling Pump Lighting", "SetFanLighting,SetLighting"},
            {"Legion Liquid Cooling Fan Lighting", "SetFanLighting,SetLighting"},
            {"Legion Memory Lighting", "SetFanLighting,SetExtraLighting"},
            {"Legion Front Fan Lighting", "SetFanLighting,SetLighting"},
            {"Legion Top Fan Lighting", "SetFanLighting,SetLighting"},
            {"Legion GPU Iconic Lighting", "SetFanLighting,SetExtraLighting"},
        };

        //1.Select Wave/CPU Temperarture/Metetor_Cycle/Meteor_Rainbow_Cycle effect：
        public static string ChangedListEffect = "Wave/CPU Temperature/Metetor_Cycle/Meteor_Rainbow_Cycle";
        public static List<string> GamingLightingEffectChangedList = new List<string>()
        {
            "4/3",
            "8/4",
            "16/5",
            "32/6",
            "64/7",
            "128/8"
        };
    }
}
