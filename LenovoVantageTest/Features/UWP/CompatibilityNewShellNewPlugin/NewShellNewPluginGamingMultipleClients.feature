Feature: NewShellNewPluginGamingMultipleClients
	Gaming Bamboo Agent 1 To Multiple Client
	
# http://10.119.139.170/index.html
@NSNPGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 1 Client Y760
	Given Run Clients '10.119.139.170' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=X60NBGPUOCOff ||cat=MultiGameDetection ||cat=ThermalModeACModeX60AutoOff ||cat=X60NBGPUOCOffACToDC ||cat=X60NBGPUOCOffDCToAC ||cat=ThermalModeACModeX60'

# http://10.119.134.117/index.html
@NSNPGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 2 Client Y560
	Given Run Clients '10.119.134.117' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=X60NBGPUOCOn||cat=X60NBGPUOCOnACToDC||cat=X60NBGPUOCOnDCToAC ||cat=ThermalModeDCToACModeX60AutoOn ||cat=ThermalModeDCModeX60AutoOff ||cat=ThermalModeACToDCModeX60AutoOn'

# http://10.119.171.47/index.html
@NSNPGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 3 Client Agent-48
	Given Run Clients '10.119.171.47' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=GamingNetworkBoostAutoCloseToast'

# http://10.119.172.196/index.html
@NSNPGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 4 Client Agent-172.196
	Given Run Clients '10.119.172.196' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=GamingGPUOCVRAM'

# http://10.119.164.190/index.html
@NSNPGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 5 Client Agent-164.190
	Given Run Clients '10.119.164.190' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=IntellegentSubMode || cat=PowerPlanPQPlans || cat=GamingEnableNahimic || cat=GamingEnableX-rite'
	
# http://10.119.175.34/index.html
@NSNPGamingMultipleClientsSpecFlow @Reboot
Scenario: Run Gaming Local Run 6 Client Agent-175.34
	Given Run Clients '10.119.175.34' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=GamingHybridModeRestartNeed || cat=PowerPlanBalanceMode || cat=HWInfoAMD'
	
# http://10.119.169.187/index.html
@NSNPGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 7 Client Agent-169.187
	Given Run Clients '10.119.169.187' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=PowerPlanBQPlans  || cat= GamingTagDetection || cat=OverDriveSupported || cat=Thermalmode4.0Supported || cat=LightingNBSupported'
	
# http://10.119.188.123/index.html
@NSNPGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 8 Client Agent-188.123
	Given Run Clients '10.119.188.123' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=PowerPlanPBPlans || cat=HWInfoAMDOCOFF'

# http://10.119.177.64/index.html
@NSNPGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 9 Client Agent-177.64
	Given Run Clients '10.119.177.64' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=PowerPlanPerformanceMode || cat=GamingReskinWiFiSecuritySubpageNoWifi || cat=GamingPreferenceSettingsSelfSelectOptionsNoWifi '
	
# http://10.119.138.239/index.html
@NSNPGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 10 Client Agent-138.239
	Given Run Clients '10.119.138.239' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=PowerPlanManualThreePlans || cat=HWInfoAMDOCON || cat=PowerPlanModifyPlanSettings || cat=PowerPlanManualThreePlans || cat=HWInfoAMDOCON || cat=PowerPlanModifyPlanSettings'
	
# http://10.119.148.194/index.html
@NSNPGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 11 Client Agent-148.194
	Given Run Clients '10.119.148.194' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=PowerPlanNoPlan || cat=PowerPlanModifyPlanCreateSamePlan'
		
# http://10.119.175.240/index.html
@NSNPGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 12 Client Agent-175.240
	Given Run Clients '10.119.175.240' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=PowerPlanQuietPlan || cat=GamingRemoveGiveFeedbackS3 || cat=GamingRemoveGiveFeedbackS4'

# http://10.119.144.100/index.html
@NSNPGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 13 Client Agent-144.100
	Given Run Clients '10.119.144.100' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=GamingReskinWiFiSecuritySubpage || cat=GamingCapacity_C730 || cat=GamingOLdCPUOC || cat=GamingDriverLackNetfilterDriver || cat=GamingDriverLackXTUDriverS4 || cat=GamingDriverLackNetfilterDriverS3 || cat=GamingDriverLackNetfilterDriverS4 || cat=GamingDriverLackLightingDriverS4  || cat=GamingOLdCPUOCNoWifi  || cat=CPUOCUnSupported  || cat=ThermalmodeUnSupported || cat=LightingTowerSupportedLEDDriver'

# http://10.119.133.97/index.html
@NSNPGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 14 Client Agent-133.97
	Given Run Clients '10.119.133.97' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=X60NBCPUGPUOCOn || cat=X60NBCPUGPUOCOnACToDC || cat=X60NBCPUGPUOCOnDCToAC || cat=HWInfoIntelCPUGPUOCOn || cat=ThermalModeDCModeX60 || cat=ThermalModeACToDCModeX60AutoOff || cat=GamingThermalModeX60New || cat= ThermalModeACModeX60AutoOn'

# http://10.119.146.59/index.html
@NSNPGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 15 Client Agent-146.59
	Given Run Clients '10.119.146.59' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=X60NBCPUOCOn || cat=X60NBCPUOCOnACToDC || cat=X60NBCPUOCOnDCToAC|| cat=HWInfoIntelCPUOCOn || cat= ThermalModeDCModeX60AutoOn || cat=ThermalModeDCToACModeX60AutoOff'

# http://10.119.168.247/index.html
@NSNPGamingMultipleClientsSpecFlow @Reboot
Scenario: Run Gaming Local Run 16 Client Agent-168.247
	Given Run Clients '10.119.168.247' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=GamingMemoryOCtestRestartNeed || cat=GamingCapacity_Y730 || cat=GamingMemoryOCtestNoWifi'

# http://10.119.165.49/index.html
@NSNPGamingMultipleClientsSpecFlow @Reboot
Scenario: Run Gaming Local Run 17 Client Agent-165.49
	Given Run Clients '10.119.165.49' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=GamingMemoryOCtestRestartNeed || cat=GamingMemoryOCOfftest || cat=GamingMacroKey15InchKeyboardLayout  || cat= AutoClose || cat=GamingMacroKey15InchKeyboardLayoutS3 || cat= GamingMacroKey15InchKeyboardLayoutS4 || cat=AutoCloseS3 || cat=AutoCloseS4 || cat=RAMOCSupportedDriverinstalled || cat=AutoCloseS3S4'
