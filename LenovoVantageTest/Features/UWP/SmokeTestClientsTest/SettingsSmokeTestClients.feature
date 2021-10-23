Feature: SettingsSmokeTestClients
	Settings Bamboo Agent Smoke To Multiple Client

# http://10.119.129.36/common/index.html
@SmokeSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 1 Client17
	Given Run Clients '10.119.129.36' And Run Version 'CommonBrand=Common' Run Cat 'cat=SmokeCheckBatteryinformation||cat=SmokeAirplaneModelIcon||cat=SmokeHSKeyBoardBacklight || cat=SmokeDolbySettings || cat=SmokeCheckHiddenKeyboardFunctions || cat=SmokeMicrophoneToggle || cat=SmokeCheckEasyResume || cat=SmokeSmokeMicrophoneToggle || cat=SmokeMicrophoneOptimizationMode || cat=SmokeCheckEasyResume'

# http://10.119.144.31/common/index.html
@SmokeSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 2 Client agent18
	Given Run Clients '10.119.144.31' And Run Version 'CommonBrand=Common' Run Cat 'cat=SmokeQuickSettingsOS || cat=SmokeMicrophoneSliderBar || cat=SmokeMicrophoneAEC || cat=SmokeIdeaBacklight || cat=SmokeConservationModeSupportSomeIdea'

# http://10.119.153.207/common/index.html
@SmokeSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 3 Client19
	Given Run Clients '10.119.153.207' And Run Version 'CommonBrand=Common' Run Cat 'cat=SmokeConservationModeNotSupportTinkPad || cat=SmokeSmartStandby || cat=SmokeThinkSupportVoip || cat=SmokeCheckRemoveECM || cat=SmokeThinkePadSupportSwap || cat=SmokelarkKeyBoard || cat=SmokeCheckKeyboardTopRowForIdeaPad || cat=SmokeThinkePadSupportSwap || cat=SmokeMicrophoneToggle ||cat=SmokeSmokeMicrophoneToggle || cat=SmokeMicrophoneOptimizationMode || cat=SmokeCheckHiddenKeyboardFunctions'

# http://10.119.168.121/common/index.html
@SmokeSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 4 Client21
	Given Run Clients '10.119.168.121' And Run Version 'CommonBrand=Common' Run Cat 'cat=SmokeAPS || cat=SmokeIntelligentScreenOnly'

# http://10.119.133.165/common/index.html
@SmokeSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 5 ClientECM
	Given Run Clients '10.119.133.165' And Run Version 'CommonBrand=Common' Run Cat 'cat=SmokeIntelligentScreenNoPage || cat=SmokeHSToolbarThinkPad || cat=SmokeDaytimeAndECM || cat=SmokeNoInputAccessories'

# http://10.119.153.152/common/index.html
@SmokeSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 7 Client keyboardbacklight3ptionson
	Given Run Clients '10.119.153.152' And Run Version 'CommonBrand=Common' Run Cat 'cat=Smokekeyboardbacklight3OptionsonIdeapad || cat= SmokeNoBatteryCharge || cat=SmokeNoSmartStandby'

# http://10.119.189.212/common/index.html
@SmokeSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 8 Client24
	Given Run Clients '10.119.189.212' And Run Version 'CommonBrand=Common' Run Cat 'cat=cat=SmokeCheckPrivacyGaurd'
	
# http://10.119.159.97/common/index.html
@SmokeSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 9 Client06
	Given Run Clients '10.119.159.97' And Run Version 'CommonBrand=Common' Run Cat 'cat=SmokeBatteryGaugeResetTwoBattery || cat=SmokeIntelligentScreenNoPage || cat=NoBatteryCharge || cat=SmokeNoSmartStandby'

# http://10.119.146.168/common/index.html
@SmokeSettingsMultipleClientsSpecFlow
Scenario: Run Settings Local Run 10 Client07
	Given Run Clients '10.119.146.168' And Run Version 'CommonBrand=Common' Run Cat 'cat=SmokeBatteryGaugeResetOneBatteryIdeaPad || cat=SmokeIntelDaytimeAndECM || cat=SmokeNoSmartMotionAlarm || cat=SmokeHSCameraBlur || cat=SmokeCheckCameraAnddisplayShow '