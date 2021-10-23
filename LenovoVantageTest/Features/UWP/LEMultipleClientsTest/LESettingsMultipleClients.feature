Feature: LESettingsMultipleClients
	Settings Bamboo Agent 1 To LE Multiple Client

# http://10.119.129.36/le/index.html
@LESettingsMultipleClientsSpecFlow
Scenario: Run Settings LE Local Run 1 Client17
	Given Run Clients '10.119.129.36' And Run Version 'EnterpriseBrand=Commercial' Run Cat 'cat=DolbyAudioSetting || cat=ThinkNotSupportVoip || cat=AirplaneModelIconLE ||cat=IntelligentScreenLe || cat=CheckBatteryConditionLE  || cat=HSKeyBoardBacklightLe || cat=OldHSAAudioMicrophone || cat=CheckAlwaysOnUSB  || cat=CheckAutomaticAudioOptimizationForVoIP || cat=CheckLETemporaryModeNosupport || cat=CheckBatteryinformationLE || cat=LEBatteryChargeThresholdOneBattery|| cat=AirplaneModelACtoDC || cat=CheckBatteryConditionOnThinkPadAcDc '

# http://10.119.153.207/le/index.html
@LESettingsMultipleClientsSpecFlow
Scenario: Run Settings LE Local Run 7 Client19
	Given Run Clients '10.119.153.207' And Run Version 'EnterpriseBrand=Commercial' Run Cat 'cat=SmartStandby || cat=SmartStandbyTask86 || cat=SmartStandbyReinstall || cat=ThinkSupportVoip || cat=CheckRemoveECMLe || cat=QuickSettingsLe || cat=OptimizeMyMicrophoneLe || cat=ConservationModeNotSupportTinkPad || cat=AudioSmartSettings_AdPolicy || cat=Audio_AdPolicy || cat=VFC1996_Standby || cat=HardwareSettingsHPDLeNoSmart || cat=CheckBatteryConditionOnThinkPad95WLE || cat=NotIntelligentScreenLe'

# http://10.119.129.48/le/index.html
@LESettingsMultipleClientsSpecFlow
Scenario: Run Settings LE Local Run 2 ClientECM
	Given Run Clients '10.119.133.165' And Run Version 'EnterpriseBrand=Commercial' Run Cat 'cat=DaytimeAndECM || cat=DolbyAudioSettingNoDolbySudio|| cat=DaytimeAndECM-Hibernate'

# http://10.119.168.121/le/index.html
@LESettingsMultipleClientsSpecFlow
Scenario: Run Settings LE Local Run 3 Client21
	Given Run Clients '10.119.168.121' And Run Version 'EnterpriseBrand=Commercial' Run Cat 'cat=UserDefinedKeyNotSupport || cat=APS || cat=ThinkAPS || cat=CheckBatteryConditionOnThinkPad230WLE'

# http://10.119.129.207/le/index.html
@LESettingsMultipleClientsSpecFlow
Scenario: Run Settings LE Local Run 4 Client300W
	Given Run Clients '10.119.180.134' And Run Version 'EnterpriseBrand=Commercial' Run Cat 'cat=CheckKeyboardTopRowForIdeaPad || cat=CheckBatteryinformationideaDC || cat=CheckRapidChargeLE || cat=ConservationModeCheckConservationIcon || cat=ConservationModeCheckButteryCharged || cat=ConservationModeCutRepidAndConservation || cat=ConservationModeCutWindwo ||cat=LEAdPolicyMultipleClientsSpecFlow || cat=BatteryGaugeResetOneBatteryIdeaPad '

# http://10.119.142.228/le/index.html
@LESettingsMultipleClientsSpecFlow
Scenario: Run Settings LE Local Run 5 Zeus-SIT
	Given Run Clients '10.119.142.228' And Run Version 'EnterpriseBrand=Commercial' Run Cat 'cat=HardwareSettingsHPDLe || cat=CheckHPDCheckbox'
	
@LESettingsMultipleClientsSpecFlow
Scenario: Run Settings LE Local Run 6 Gen-9
	Given Run Clients '10.119.128.84' And Run Version 'EnterpriseBrand=Commercial' Run Cat 'cat=newHSAAudioDolbyMicrophone'

# http://10.119.159.97/le/index.html	
@LESettingsMultipleClientsSpecFlow
Scenario: Run Settings LE Local Run 8 Client06
	Given Run Clients '10.119.159.97' And Run Version 'EnterpriseBrand=Commercial' Run Cat 'cat=ThinkePadNotSupportSwap06||cat=BatteryGaugeResetTwoBattery || cat=BatteryChargeThresholdSupportDualBatteries || cat=CheckTwoBatteryinformation || cat=CheckBatteryConditionOnThinkPad170WLE '

# http://10.119.189.212/le/index.html	
@LESettingsMultipleClientsSpecFlow
Scenario: Run Settings LE Local Run 9 Client24
	Given Run Clients '10.119.189.212' And Run Version 'EnterpriseBrand=Commercial' Run Cat 'cat=UserDefinedKey||cat=ThinkePadSupportSwap||cat=MicrophoneToggleLE || cat=CheckLEPrivacyGaurd || cat=CheckEasyResume || cat=CheckHiddenKeyboardFunctionsLE || cat=CheckLECameraAndCameraPrivacy || cat=SuppressKeyboardNoise ||cat=HSAAudioMicrophone || cat=nolarkKeyBoard || cat=MicrophoneSliderBar || cat=CheckBatteryConditionOnThinkPad65WLE '