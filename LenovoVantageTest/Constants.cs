using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
namespace LenovoVantageTest
{
    public enum ServerType
    {
        Testing,
        Staging,
        Production
    }

    internal class Constants
    {
        internal static ServerType TargetServer = ServerType.Testing;
        internal static Dictionary<string, string> NLS2TestingMachineNames = new Dictionary<string, string>();
        internal static string uiLanguage = CultureInfo.InstalledUICulture.ThreeLetterWindowsLanguageName.ToLower();
        internal static string appName = "E046963F.LenovoCompanion";
        //internal static string appProcessName = "WWAHost";
        internal static string appID = @"E046963F.LenovoCompanion_k1h2ywk1493x8!App";//need to modify to vantage3.0
        internal static string PackageName4Vantage3 = "E046963F.LenovoCompanion";//depends on Suite setup to fill in howeverr a default value is required
        internal static string VantageTitle = "Lenovo Vantage";
        internal static string VantageLETitle = "Lenovo Commercial Vantage";
        internal static string LUDPServer = "https://chifsr.lenovomm.com/PCJson";
        internal static string StgDXPServer = "https://stg.dxp.lenovo.com/api";
        internal static string CSWServer = "https://vantage.csw.lenovo.com/api";
        internal static string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");
        internal static string reportFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "myreport.log");
        internal static string imcLogPath = @"C:\ProgramData\Lenovo\Modern\Logs";
        internal static string imControllerPath = @"C:\ProgramData\Lenovo\imController";
        internal static string pluginPath = @"C:\ProgramData\Lenovo\ImController\Plugins";
        internal static string VantagePackgePath = "Data\\Vantage\\latest\\Add-AppDevPackage.ps1";
        internal static string iMCProgramData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Lenovo\\ImController");


        internal const string TANGRAM_LOGGER_REGISTRY32 = @"SOFTWARE\WOW6432Node\Lenovo\Modern\Logs\TangramTest";   //for player TangramTest
        internal const string TANGRAM_LOGGER_REGISTRY64 = @"SOFTWARE\Lenovo\Modern\Logs\TangramTest";   //for player TangramTest
        internal const string TANGRAM_DisableAutoupdate_REGISTRY64 = @"SOFTWARE\Policies\Lenovo\ImController\DisableAutoupdate";   //for player TangramTest
        internal const string InstallerContainer_PartialName_InInstallingVantage = "ms-appx-web://e046963f.lenovocompanion/Dependency/installing.html";
        internal const string ImController_LOGGER_REGISTRY32 = @"SOFTWARE\WOW6432Node\Lenovo\Modern\Logs\ImController.Service";   //for enable|disable IMC log
        internal const string ImController_LOGGER_REGISTRY64 = @"SOFTWARE\Lenovo\Modern\Logs\ImController.Service";   //for enable|disable IMC log

        internal const string Plugin_LOGGER_REGISTRY32 = @"SOFTWARE\WOW6432Node\Lenovo\Modern\Logs\ImController.PluginHost";   //for enable|disable Plugin log
        internal const string Plugin_LOGGER_REGISTRY64 = @"SOFTWARE\Lenovo\Modern\Logs\ImController.PluginHost";   //for enable|disable Plugin log


        internal const string TANGRAM_LOGGER_REGISTRY32s = @"HKLM\SOFTWARE\WOW6432Node\Lenovo\Modern\Logs\TangramTest";   //for player TangramTest
        internal const string TANGRAM_LOGGER_REGISTRY64s = @"HKLM\SOFTWARE\Lenovo\Modern\Logs\TangramTest";   //for player TangramTest
        internal const string TANGRAM_DisableAutoupdate_REGISTRY64s = @"HKLM\SOFTWARE\Policies\Lenovo\ImController\DisableAutoupdate";   //for player TangramTest

        internal const string ImController_LOGGER_REGISTRY32s = @"HKLM\SOFTWARE\WOW6432Node\Lenovo\Modern\Logs\ImController.Service";   //for enable|disable IMC log
        internal const string ImController_LOGGER_REGISTRY64s = @"HKLM\SOFTWARE\Lenovo\Modern\Logs\ImController.Service";   //for enable|disable IMC log

        internal const string Plugin_LOGGER_REGISTRY32s = @"HKLM\SOFTWARE\WOW6432Node\Lenovo\Modern\Logs\ImController.PluginHost";   //for enable|disable Plugin log
        internal const string Plugin_LOGGER_REGISTRY64s = @"HKLM\SOFTWARE\Lenovo\Modern\Logs\ImController.PluginHost";   //for enable|disable Plugin log


        internal const string vantage_shell_log = @"HKLM\SOFTWARE\WOW6432Node\Lenovo\VantageService\FileLogger\LenovoVantageShell";
        internal const string Camera_Regitky64 = @"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\webcam\Value";
        internal const string Microphone_Regitky64 = @"HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\CapabilityAccessManager\ConsentStore\microphone\Value";

        internal const string IMCONTROLLER_SERVICE_BASE = @"C:\Windows\Lenovo\ImController\Service";
        internal static string recorderTangramTestSourceExe = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"TangramTest.exe");
        internal static string recorderTangramTestTargetExe = Path.Combine(IMCONTROLLER_SERVICE_BASE, @"TangramTest.exe");
        internal static string recorderIMClientDll = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"lib\Lenovo.Modern.ImController.ImClient.dll");
        internal static string originalIMClientDll = Path.Combine(IMCONTROLLER_SERVICE_BASE, @"Lenovo.Modern.ImController.ImClient.dll");
        internal static string backupIMClientDll = Path.Combine(IMCONTROLLER_SERVICE_BASE, @"Lenovo.Modern.ImController.ImClient - Backup.dll");
        internal static string sqliteSourceDll = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"lib\System.Data.SQLite.dll");
        internal static string sqliteTargetDll = Path.Combine(IMCONTROLLER_SERVICE_BASE, @"System.Data.SQLite.dll");
        internal static string databaseFolderUsedByIMC = Path.Combine(IMCONTROLLER_SERVICE_BASE, @"Data");
        internal static string databaseFileUsedByIMCSource = Path.Combine(IMCONTROLLER_SERVICE_BASE, @"Data\TangramDB.db");
        internal static string databaseFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\TangramDB.db");
        internal static string databaseFileNative = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\TangramDB.db");
        internal static string recordDatabaseFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\TangramDB_record" + DateTime.Now.ToString("_yyyyMMdd_hhmmss") + ".db");
        internal static string templateDatabaseFile = Path.Combine(Environment.CurrentDirectory, @"Data\Template.db");
        internal static string pluginHostProcessName = "Lenovo.Modern.ImController.PluginHost.Device.exe";
        internal const int DURATION_PER_REQUEST_RESPONSE = 1000; //duration between two requests(ms)
        internal static bool runInFitnesse = true;

        internal static readonly string IMCONTROLLER_SERVICE_NAME = "ImControllerService"; //This is the name shown by sc tool and services properties
        internal static readonly string LenovoVantageService_NAME = "LenovoVantageService";
        internal static readonly string LenovoVantagePath = @"C:\ProgramData\Lenovo\Vantage";
        internal static readonly string LenovoVantageServicePath = @"C:\Program Files (x86)\Lenovo\VantageService";

        internal static string sharedFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Lenovo\ImController\shared";
        internal static string machineInformationSource = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Lenovo\ImController\shared\MachineInformation.xml";
        internal static string machineInformationVantage = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Lenovo\Vantage\shared\MachineInformation.xml";
        internal static string appsAndTagsSource = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Lenovo\ImController\shared\AppsAndTags.xml";
        internal static string ImControllerSubscriptionFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Lenovo\ImController\ImControllerSubscription.xml";
        internal static string TempImControllerSubscriptionFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Lenovo\ImController\Temp\ImControllerSubscription.xml";

        internal static readonly string DATETIMEFORMAT = @"yyyy-MM-ddTHH:mm:ss";
        internal static readonly string DATEFORMAT = @"yyyy-MM-dd";
        internal static readonly string TIMEFORMAT = @"HH_mm_ss";
        internal static readonly string DATETIMEFORMATFORPATH = @"yyyyMMdd_HHmmss.sss";
        internal static readonly string TIMESPANFORMAT = @"d\:h\:mm\:ss";

        internal static string testPlanName = "TestPlan_" + DateTime.Now.ToString(DATETIMEFORMATFORPATH);
        internal static readonly string TESTPLAN_CONFIG = AppDomain.CurrentDomain.BaseDirectory + "config.xml";
        internal static readonly int TIMEOUT = 20;  //timeout for config.xml, lenovo-companion:PARAM?featureId=if not set this field, set as this
        internal static readonly int TIMEOUTOFRESPONSE = 120;  //timeout for getting response after sending a request to IMC

        internal static readonly string POWERSHELLEXE = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), @"system32\WindowsPowerShell\v1.0\powershell.exe");

        //Need to get "TranslateNLS - Keys" from Microsoft Azure (https://portal.azure.com/#resource/subscriptions/3dcfce33-74b8-4dc0-a94e-c4bb96cb4981/resourcegroups/Translate/providers/Microsoft.CognitiveServices/accounts/TranslateNLS/keys)
        internal const string azureTranslateKey = "4673c3b73668439f960639bd5c47b8cb";

        internal static string stagingServer = "10.103.208.62";
        internal static string testingServer = "10.103.208.61";
        internal static string laapiServerQA = "https://qa-laapi.csw.lenovo.com";
        internal static string laapiServerPROD = "https://laapi.csw.lenovo.com";

        //tangram protocols
        internal const string companionProtocol = "lenovo-companion:";
        internal const string tangramUapFullName = "E046963F.LenovoCompanion_k1h2ywk1493x8";
        internal const string systemUpdatePolicyRepoFeatureId = "F5D7BFC9-1AA2-43F2-8D63-2131C65C991D";
        internal const string systemUpdatePageFeatureId = "E40B12CE-C5DD-4571-BBC6-7EA5879A8472";
        internal const string batteryPageFeatureId = "B2790BFB-20A1-46B2-90D7-DBC019047321";
        internal const string feedbackPageFeatureId = "9023E851-DE40-42C4-8175-1AE5953DE624";
        internal const string accessoritesPageFeatureId = "08EC2D60-1A14-4B27-AF71-FB62D301D236";
        internal const string hardwareScanPageFeatureId = "CCCD4009-AAE7-4014-8F5D-5AEC2585F503";
        internal const string discussionForumFeatureId = "D65D67BF-8916-4928-9B07-35E3A9A0EDC3";
        internal const string userGuidePageFeatureId = "18E12FC0-EACB-43CB-8231-87D9C09EE0DF";
        internal const string knowledgeBaseFeatureId = "6674459E-60E2-49DE-A791-510247897877";
        internal const string warrantyPageFeatureId = "A191BF9F-60BE-4843-B4BA-441DD0AEB12E";
        internal const string deviceRefreshPageFeatureId = "349B8C6E-6AE4-4FF3-B8A0-25D398E75AAE";
        internal const string giveawaysPageFeatureId = "8A6263C0-490C-4AE6-9456-8BBD81379787";
        internal const string dropboxPageFeatureId = "B4AAD698-B584-430A-AB21-863CCD5F985D";
        internal const string ecouponPageFeatureId = "0E101F47-9A6F-4915-8C5F-E577D3184E5D";
        internal const string storagePageFeatureId = "EFFCB1FF-B59D-4BD8-BBA7-2A1F80B4A62A";
        internal const string memoryPageFeatureId = "E35E8BB4-2C06-410E-886F-37C0A23A2007";
        internal const string appsAndOffers = "5245A8D3-0151-4866-BC79-BC199C5D9FDB";
        internal const string tipsAndTricksFeatureId = "BC690B89-77AA-4CC9-B217-73573202B94E";
        internal const string healthSupoortFeatureId = "9A92FCC6-0018-421C-89E5-ED579FF05EED";
        internal const string securityAdvisor = "19841A14-32B9-4F67-9D3A-605EE6CEF187";
        internal const string securityAdvisor_Antivirus = "35966093-9FA9-4EB4-8CC7-145887B6E6EA";
        internal const string securityAdvisor_VPN = "88024006-BB4F-4CB5-AE9F-C048F5DBD1A1";
        internal const string securityAdvisor_Password = "DE00682F-16F2-4ECA-BBF3-768DA0D9EB33";
        //settings protocol
        internal const string developermodeProtocol = "ms-settings:developers";
        internal const string passwordProtocol = "ms-settings:signinoptions";
        internal const string windowsdefenderProtocol = "windowsdefender:";

        internal const string userguideurl = "https://download.lenovo.com/pccbbs/pubs";
        internal static string gamingTag = @"Software\WOW6432Node\Lenovo\ImController\Applicability\Tags";
        internal const string vantage_service_log = @"HKLM\SOFTWARE\WOW6432Node\Lenovo\VantageService\FileLogger\LenovoVantageService";
        internal const string vantage_InstallHelper_log = @"HKLM\SOFTWARE\WOW6432Node\Lenovo\VantageService\FileLogger\Lenovo.Vantage.InstallerHelper";
        internal const string vantage_LenovoVantageSetup_log = @"HKLM\SOFTWARE\WOW6432Node\Lenovo\VantageService\FileLogger\LenovoVantageSetup";
        internal const string vantage_LenovoVantageServiceUninstall_log = @"HKLM\SOFTWARE\WOW6432Node\Lenovo\VantageService\FileLogger\Lenovo.Vantage.ServiceSetup.Uninstall";
        internal const string vantage_upe_url = @"HKLM\SOFTWARE\WOW6432Node\Lenovo\VantageService\CloudLinks\UpeUrlHost";
        internal const string vantage_adpolicy_camera = @"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.display-and-camera.camera";
        internal const string vantage_adpolicy_display = @"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.display-and-camera.display";
        internal const string vantage_adpolicy_microphone = @"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.audio.microphone-settings";
        internal const string vantage_adpolicy_audio_smart_settings = @"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.audio.audio-smart-settings";
        internal const string vantage_adpolicy_power_standby_settings = @"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.power.standby-settings";
        internal const string vantage_adpolicy_power_power_smart_settings = @"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.power.power-smart-settings";
        internal const string vantage_adpolicy_intelligent_keyboard = @"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.inputAndAccessories.intelligent-keyboard";
        internal const string vantage_adpolicy_power_battery_settings = @"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.power.battery-settings";
        internal const string vantage_adpolicy_power_power_settings = @"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.power.power-settings";
        internal const string vantage_registry_standby = @"HKLM\SOFTWARE\WOW6432Node\Lenovo\SmartStandby\IsEnabled";

        public static ComponentType CurrentComponentType;

        public enum ComponentType
        {
            Settings,
            Gaming,
            ITS,
            DPM,
            CHS,
            LWS
        }

        public static List<string> SettingsAgentIpAddress = new List<string>() {
            "10.119.137.112","10.119.159.97","10.119.153.156",
            "10.119.186.172","10.119.158.83","10.119.128.148",
            "10.119.170.54","10.119.190.192","10.119.146.28",
            "10.119.189.212","10.119.167.202","10.119.174.107",
            "10.119.161.197","10.119.150.157","10.119.153.207",
            "10.119.154.102","10.119.173.22","10.119.189.58"
        };

        public static string CurrentAgentMachineIp;
        internal static string metricToggle = @"HKCU\Software\Lenovo\Metrics\com.lenovo.companion";

        public static void SetCurrentCommentType(string componentName)
        {
            if (componentName.Contains("Vantage_HardwareSettings"))
            {
                CurrentComponentType = ComponentType.Settings;
            }
            else if (componentName.Contains("Vantage_NerveCenter") || componentName.Contains("LWS_Gaming"))
            {
                CurrentComponentType = ComponentType.Gaming;
            }
            else if (componentName.Contains("Vantage_DesktopPowerManagement"))
            {
                CurrentComponentType = ComponentType.DPM;
            }
            else if (componentName.Contains("Vantage_IntelligentCooling"))
            {
                CurrentComponentType = ComponentType.ITS;
            }
            else if (componentName.Contains("Vantage_ConnectedHomeSecurity"))
            {
                CurrentComponentType = ComponentType.CHS;
            }
        }

    }
}
