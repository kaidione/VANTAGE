namespace LenovoVantageTest.Pages.ConnectedHomeSecurityPages
{
    public class CHSWebXpath
    {
        //Login in Page
        public static string WebLoginInLIDBtn = "//*[@id=\"root\"]/div/div/div[2]/div/div[4]/div[2]/div/div/button";
        public static string WebNext1Btn = "/html/body/div[1]/div[1]/button";
        public static string WebNext2Btn = "/html/body/div[1]/div[3]/form/div[4]/button[2]";
        public static string WebInputPssword = "/html/body/div[1]/div[3]/form/div[1]/input";
        public static string WebInputID = "/html/body/div[1]/div[1]/div[1]/input";

        //Remove Devices
        public static string WebDevicesSetting = "//*[@id=\"root\"]/div/div[2]/div[2]/div[1]/div[1]/div/div[2]/div/div/div/div[2]/div[1]/div/div/div/div[1]/button";
        public static string WebRemoveBtn = "//*[@id=\"menu-list-grow\"]/ul/li[4]";
        public static string WebConfirmRemoveBtn = "/html/body/div[2]/div[3]/div/div[3]/div/button";
        public static string WebSecondnDevices = "//*[@id=\"root\"]/div/div[2]/div[2]/div[1]/div[1]/div/div[2]/div[2]/div/div/div[2]/div[1]/div/div/div/div[1]/button";

        //Remove Family Number
        public static string WebFamilySetting = "//*[@id=\"root\"]/div/div[2]/div[2]/div[1]/div[1]/div/div[2]/div[2]/div/div/div[1]/div/div/div[1]";
        public static string WebFamilySettingBtn = "//*[@id=\"menu-list-grow\"]/ul/li[2]";
        public static string WebRemoveFamilyBtn = "/html/body/div[2]/div[3]/div/div[3]/div/button/span[1]";
        public static string RemoveFamilySecond = "//*[@id=\"root\"]/div/div[2]/div[2]/div[1]/div[1]/div/div[2]/div[3]/div/div/div[1]/div/div/div[1]/button";

        //Add Family Number
        public static string WebNewNumberBtn = "//*[@id=\"root\"]/div/div[2]/div[2]/div[1]/div[1]/div/div[1]/div[2]/button/span[1]/div";
        public static string WebInputName = "//*[@id=\"outlined-name\"]";
        public static string WebSaveBtn = "/html/body/div[2]/div[3]/div/div/form/div[3]/div[2]/button/span[1]/div";

        //Add Places Number
        public static string WebNewPlaceBtn = "//*[@id=\"root\"]/div/div[2]/div[2]/div[1]/div[2]/div/div[1]/div[2]/button/span[1]/div";

        //Remove Places Number
        public static string WebPlaceMoreBtn = "//*[@id=\"root\"]/div/div[2]/div[2]/div[1]/div[2]/div/div[2]/div[2]/div/div/div[1]/div/div/div[1]";
        public static string WebPlaceHomePic = "//*[@id=\"root\"]/div/div[2]/div[2]/div[1]/div[2]/div/div[2]/div[2]/div/div/div[1]/div/div/span/div/img";
        public static string RemovePlaceYesBtn = "/html/body/div[2]/div[3]/div/div[3]/div/button/span[1]";

        //Add wifi network
        public static string AddWifiNetwork = "//*[@id=\"root\"]/div/div[2]/div[2]/div[1]/div[2]/div/div[2]/div/div/div/div[2]/div/div/div/div/span/div/div";
        public static string ChooseNetwork = "/html/body/div[2]/div[3]/div/form/div[1]/div/ul/div";
        public static string AddBtn = "/html/body/div[2]/div[3]/div/form/div[2]/div/button/span[1]/div";
        public static string MaybeLaterBtn = "/html/body/div[2]/div[3]/div/div[2]/div[2]/div[1]/button/span[1]/div";

        //Remove wifi netwok
        public static string NetworkName = "//*[@id=\"root\"]/div/div[2]/div[2]/div[1]/div[2]/div/div[2]/div/div/div/div[2]/div[1]/div[1]/div/div[1]/div/div/div/div[2]";
        public static string NetworkMoreBtn = "//*[@id=\"root\"]/div/div[2]/div[2]/div[1]/div[2]/div/div[2]/div/div/div/div[2]/div[1]/div[1]/div/div[1]/div/div/div/div[1]";
        public static string NetworkRemoveBtn = "//*[@id=\"menu-list-grow\"]/ul/li[3]";
        public static string RemoveNetworkYesBtn = "/html/body/div[2]/div[3]/div/div[3]/div/button/span[1]";

        //Add home devices
        public static string AddHomeDeviceBtn = "/html/body/div[2]/div[3]/div/form/div[2]/div";
        public static string HomeDeviceBtn = "//*[@id=\"root\"]/div/div[2]/div[2]/div[1]/div[2]/div/div[2]/div/div/div/div[2]/div[1]/div[1]/div/div[2]/div/div/span/div/div";
    }
}
