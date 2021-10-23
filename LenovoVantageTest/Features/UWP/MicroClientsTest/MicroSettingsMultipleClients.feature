Feature: MicroSettingsMultipleClients
	Settings Bamboo Agent 1 To Multiple Client

# http://10.119.180.222/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Micro Settings Local Run 1 Client17
	Given Run Clients '10.119.180.222' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat ' cat=BatteryGaugeResetOneBatteryNeedRunonBJ19 || cat=BatteryGaugeResetOneBatteryNeedRunonBJ19ACTDC || cat=DolbySettings||cat=EnergyStarLogo||cat=HSKeyBoardBacklight||cat=ThinkNotSupportVoip || cat=CheckFlipToStartNotDisplayOnThinkpad || cat=CheckThinkPadAlwaysOnUSB || cat=CheckBatteryConditionOnThinkPad || cat=AirplaneModelIcon || cat=KeyboardCS16Mechins || cat=OldHSAMicrophoneAudio || cat=CheckBatteryinformationtextthinkpad || cat=SettingsSearchSwapAccessoriesPage || cat=SettingsSearchUserDefinedKeyAccessoriesPage || cat=SettingsSearchkeyboardfunctionsAccessoriesPage || cat=BatterySettingsTopPositionNoSmartStandbyThink || cat=CheckBatteryConditionOnThinkPadAcDc || cat=ToolbarThinkACDC || cat=TestToolbarAirplanePowerModeIcon || cat=CheckEasyResume || cat=ThinkpadSupportHighSolution || cat=UserDefinedKey || cat=HSToolbar'

# http://10.119.153.207/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Micro Settings Local Run 1 Client19
	Given Run Clients '10.119.183.195' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=SmartStandby || cat=SmartStandbyTask86 || cat=SmartStandbyReinstall || cat=TopRowToolbarOnThinkpad || cat=ThinkSupportVoip  || cat=ToolbarPriorityThinkpad || cat=CheckRemoveECM || cat=CheckBatteryConditionOnThinkPad95W || cat=SettingsSearchPowerPage || cat=SettingsSearchVOIPAccessoriesPage || cat=TestSealedWarrntyThink || cat=ConservationModeNotSupportTinkPad || cat=ThinkePadSupportSwap || cat=MicrophoneKeystrokeRealtek'

# http://10.119.172.152/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Micro Settings Local Run 2 ClientECM
	Given Run Clients '10.119.172.152' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=DaytimeAndECM || cat=HSToolbarThinkPad || cat=DaytimeAndECM-Hibernate || cat=CheckNoRemoveECM'

# http://10.119.168.121/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Micro Settings Local Run 3 Client21
	Given Run Clients '10.119.168.121' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=UserDefinedKeyNotSupport || cat=APS || cat=IntelligentScreenOnly || cat=ThinkAPS ||cat=CheckBatteryConditionOnThinkPad230W || cat=SettingsSearchSmartAssistPage || cat=ThinkpadNotSupportHiddenKeyboard'

# http://10.119.180.134/micro/index.html
@MicroSettingsMultipleClientsSpecFlowToolbar @MicroSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 4 Client 300w Gen 3
	Given Run Clients '10.119.180.134' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=IdeaToolbarRapidChargeACDC || cat= IdeaToolbarConservationModeACDC || cat=ToolbarCPUMemory || cat=LUDPMetricsForCHSACDC || cat=CheckBatteryinformationideaDC || cat=CheckBatteryinformationideaAC || cat=BatteryGaugeResetOneBatteryIdeaPad'

# http://10.119.156.21/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 5 Client Thinkpad X1 Yoga 3rd and OS Less or equal 18362
	Given Run Clients '10.119.156.21' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat!=OSLessDebug && cat=QuickSettingsOSLess || cat=QuickSettingsOSResolution'

# http://10.119.132.209/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 6 Client ThinkBook SMB Elevoc Driver
	Given Run Clients '10.119.132.209' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=SMBMicrophoneElevocAudio'
	
# http://10.119.152.53/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 7 Client ThinkBook SMB Snaptics Driver
	Given Run Clients '10.119.152.53' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=SMBMicrophoneSnapticsAudio '
	
# http://10.119.153.152/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 8 Client keyboardbacklight3ptionson
	Given Run Clients '10.119.153.152' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=keyboardbacklight3OptionsonIdeapad || cat=BatterySettingsTopPositionIdea || cat=TestSealedWarrnty '
	
# http://10.119.153.143/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 9 Client NOCameraMicrophone
	Given Run Clients '10.119.153.143' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=QuickSettingsNoMicrophone || cat=QuickSettingsNoCameraMicrophone || cat=QuickSettingsNoCamera || cat=TestSealedWarrntyDesktop || cat=TestDTToolbar || cat=SettingsSMBSearchNoMicrophoneHDR'

# http://10.119.175.44/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 10 Client NOCameraMicrophone
	Given Run Clients '10.119.175.44' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=SmartBattery2.0'
	
# http://10.119.132.155/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 11 Client Zeus-SIT
	Given Run Clients '10.119.176.160' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=HPDHardwareSettings || cat=BatterySettingsTopPositionThink || cat=SmartBattery2.0NotSupport || cat=MicrophoneKeystroke || cat=CheckHiddenKeyboardFunctions'

# http://10.119.144.210/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 12 Client agent18
	Given Run Clients '10.119.159.250' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=MicrophoneSliderBar || cat=MicrophoneAEC || cat=MicrophoneOptimizationMode ||cat=IdeaPadNotSupportSwap18||cat=HardwareSettingsHPD||cat=IdeaBacklight||cat=ConservationModeCheckButteryCharged || cat=IdeaPadBatteryConditionWithBattery || cat=KeyboardCS20IdeaPad || cat=QuickSettingsOS || cat=QuickSettingsOSGreat ||cat=ConservationModeSupportSomeIdea ||cat=ConservationModeCheckConservationIcon ||cat=ConservationModeCutWindwo || cat=CheckFlipToStartS3S4 || cat=QuickSettingsOnlyMicrophoneUpdate || cat=BatterySettingsTopPositionNoPowerSmartSetingsIdea || cat=ToolbarACDC || cat=ToolbarIdeaACDC '
	
# http://10.119.159.97/common/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 13 Client agent06
	Given Run Clients '10.119.159.97' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=ThinkePadNotSupportSwap06||cat=BatteryGaugeResetTwoBattery || cat=Toolbar || cat=WifiToolbar || cat=MicrophoneToolbar || cat=CameraToolbar || cat=KeyboardBacklightToolbarThinkpad || cat=BatteryChargeToolbarThinkpad || cat=AirplaneToolbaTthinkpad || cat=BatteryChargeThresholdSupportDualBatteries || cat=CheckTwoBatteryinformation || cat=CheckBatteryConditionOnThinkPad170W || cat=BatteryChargeThresholdOneBattery'
	
# http://10.119.177.130/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 14 Client Settings Search Gaming Legion Y740S-15IMH
	Given Run Clients '10.119.177.130' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=SettingsSearchPowerPageGamingself'
	
# http://10.119.163.59/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 15 Client ConservationMode Blacklist
	Given Run Clients '10.119.163.59' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=ConservationModeBlacklist '

# http://10.119.179.146/common/index.html	
#@MicroSettingsMultipleClientsSpecFlow
#Scenario: Run Settings Local Run 16 ClientECMLowOS
#	Given Run Clients '10.119.179.146' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=ECMAndLocationIntel || cat=ECMAndLocationIntelS3S4'

# http://10.119.168.212/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 17 Client07
	Given Run Clients '10.119.133.246' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=NotSupportSmartAlarm||cat=HSCameraBlur || cat=BatteryGaugeResetOneBatteryIdeaPad || cat=CheckIdeaPadNotSupportRapidCharge || cat=SettingsSearchCameraBlurPage || cat=CheckCameraAndCameraPrivacy || cat=SmokeNoSmartMotionAlarm'

# http://10.119.187.97/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 18 Client04
	Given Run Clients '10.119.187.97' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=TopRowToolbarIdea || cat=KeyboardBacklightToolbarIdea || cat=ConservationModeToolbar || cat=RapidChargeToolbar || cat=CheckRapidCharge || cat=CheckKeyboardTopRowForIdeaPad|| cat=CheckRapidChargeHibernate || cat=CheckRapidChargeRemoveAdapterStatus || cat=CheckRapidChargeFullChargeTime|| cat=SealedBatteryToast'

# http://10.119.182.162/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 19 Client Settings search Gaming Legion 5 15ITH6
	Given Run Clients '10.119.182.162' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=SettingsSearchSmartFlipToBootPowerPageGaming || cat=SmartBattery2.0GammingMachine || cat=ToolbarimageforNewWindows || cat=CheckCameraAndCameraPrivacygameming || cat=QuickSettingsOSInGamingMachine || cat=CheckCameraAndCameraPrivacygameming'

# http://10.119.141.87/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 20 Client 500W
	Given Run Clients '10.119.141.87' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=CheckIdeaPadNoDisplayAlwaysOnUSB '

# http://10.119.165.117/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 21 Client S560-16ITS
	Given Run Clients '10.119.165.117' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=SmartBattery2.0Manual '

# http://10.119.140.28/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 22 Client ThinkPad X1 Carbon 6th
	Given Run Clients '10.119.140.28' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=BatterySettingsTopPositionNoBatteryThink || cat= CheckBatteryConditionOnThinkPadNoBattery || cat=MicrophoneToggle || cat=NoIntelligentScreenOnThink || cat=HSAMicrophoneAudio '

# http://10.119.161.197/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 23 Client 52
	Given Run Clients '10.119.161.197' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=CheckOLEDPowerSettings || cat=BatteryChargeThresholdSupportOneBattery || cat=CheckThinkPadNotSupportRapidCharge|| cat=NormalOSHeartBeatNoSupportRegion || cat=SettingsSearchCameraOLEDPage'

# http://10.119.128.214/micro/index.html
@MicroSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 24 Client TwoBatteryCase
	Given Run Clients '10.119.128.214' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=BatteryChargeThresholdTwoBattery'