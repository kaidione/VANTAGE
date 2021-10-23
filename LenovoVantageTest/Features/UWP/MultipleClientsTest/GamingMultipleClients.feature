Feature: GamingMultipleClients
	Gaming Bamboo Agent 1 To Multiple Client

# http://10.119.139.170/common/index.html
@GamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 1 Client Y760
	Given Run Clients '10.119.139.170' And Run Version 'CommonBrand=Common' Run Cat 'cat=X60NBGPUOCOff ||cat=MultiGameDetection ||cat=ThermalModeACModeX60AutoOff ||cat=X60NBGPUOCOffACToDC ||cat=X60NBGPUOCOffDCToAC ||cat=ThermalModeACModeX60'

# http://10.119.134.117/common/index.html
@GamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 2 Client Y560
	Given Run Clients '10.119.134.117' And Run Version 'CommonBrand=Common' Run Cat 'cat=X60NBGPUOCOn||cat=X60NBGPUOCOnACToDC||cat=X60NBGPUOCOnDCToAC ||cat=ThermalModeDCToACModeX60AutoOn ||cat=ThermalModeDCModeX60AutoOff ||cat=ThermalModeACToDCModeX60AutoOn'

# http://10.119.171.47/common/index.html
@GamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 3 Client Agent-48
	Given Run Clients '10.119.171.47' And Run Version 'CommonBrand=Common' Run Cat 'cat=GamingNetworkBoostAutoCloseToast'

# http://10.119.172.196/common/index.html
@GamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 4 Client Agent-172.196
	Given Run Clients '10.119.172.196' And Run Version 'CommonBrand=Common' Run Cat 'cat=GamingGPUOCVRAM ||cat=DPMSearchUnSupport || cat=GamingSearchNetworkBoost || cat=GamingSearchAutoClose || cat=GamingSearchThermalMode3 || cat=GamingSearchNoDriverVRAMOC'

# http://10.119.164.190/common/index.html
@GamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 5 Client Agent-164.190
	Given Run Clients '10.119.164.190' And Run Version 'CommonBrand=Common' Run Cat 'cat=IntellegentSubMode || cat=PowerPlanPQPlans || cat=GamingEnableNahimic || cat=GamingEnableX-rite'
	
# http://10.119.175.34/common/index.html
@GamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 6 Client Agent-175.34
	Given Run Clients '10.119.175.34' And Run Version 'CommonBrand=Common' Run Cat 'cat=PowerPlanBalanceMode || cat=HWInfoAMD'
	
# http://10.119.169.187/common/index.html
@GamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 7 Client Agent-169.187
	Given Run Clients '10.119.169.187' And Run Version 'CommonBrand=Common' Run Cat 'cat=PowerPlanBQPlans  || cat= GamingTagDetection || cat=OverDriveSupported || cat=Thermalmode4.0Supported || cat=LightingNBSupported ||cat=GamingSearchTP ||cat=GamingSearch ||cat=GamingSearchMacroKey ||cat=GamingSearchHybridMode ||cat=GamingSearchOverDrive'
	
# http://10.119.188.123/common/index.html
@GamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 8 Client Agent-188.123
	Given Run Clients '10.119.188.123' And Run Version 'CommonBrand=Common' Run Cat 'cat=PowerPlanPBPlans || cat=HWInfoAMDOCOFF'

# http://10.119.177.64/common/index.html
@GamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 9 Client Agent-177.64
	Given Run Clients '10.119.177.64' And Run Version 'CommonBrand=Common' Run Cat 'cat=PowerPlanPerformanceMode || cat=GamingReskinWiFiSecuritySubpageNoWifi || cat=GamingPreferenceSettingsSelfSelectOptionsNoWifi '
	
# http://10.119.138.239/common/index.html
@GamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 10 Client Agent-138.239
	Given Run Clients '10.119.138.239' And Run Version 'CommonBrand=Common' Run Cat 'cat=PowerPlanManualThreePlans || cat=HWInfoAMDOCON || cat=PowerPlanModifyPlanSettings'
	
# http://10.119.148.194/common/index.html
@GamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 11 Client Agent-148.194
	Given Run Clients '10.119.148.194' And Run Version 'CommonBrand=Common' Run Cat 'cat=PowerPlanNoPlan || cat=PowerPlanModifyPlanCreateSamePlan'
		
# http://10.119.175.240/common/index.html
@GamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 12 Client Agent-175.240
	Given Run Clients '10.119.175.240' And Run Version 'CommonBrand=Common' Run Cat 'cat=PowerPlanQuietPlan'

# http://10.119.144.100/common/index.html
@GamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 13 Client Agent-144.100
	Given Run Clients '10.119.144.100' And Run Version 'CommonBrand=Common' Run Cat 'cat=GamingReskinWiFiSecuritySubpage || cat=GamingCapacity_C730 || cat=GamingOLdCPUOC || cat=GamingDriverLackNetfilterDriver || cat=GamingDriverLackXTUDriverS4 || cat=GamingDriverLackNetfilterDriverS3 || cat=GamingDriverLackNetfilterDriverS4 || cat=GamingDriverLackLightingDriverS4  || cat=GamingOLdCPUOCNoWifi  || cat=CPUOCSupported  || cat=ThermalmodeUnSupported || cat=LightingTowerSupportedLEDDriver|| cat=GamingMemoryOCtestNoWifi || cat=GamingSearchLighting || cat=GamingSearchRAMOC || cat=GamingSearchOldCPUOC || cat=GamingSearchNoDriverNB || cat=GamingSearchNoDriverLighting || cat=GamingSearchNoDriverOldCPUOC || cat=GamingSearchNoDriverRAMOC || cat=GamingSearchNoThermalMode'

# http://10.119.133.97/common/index.html
@GamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 14 Client Agent-133.97
	Given Run Clients '10.119.133.97' And Run Version 'CommonBrand=Common' Run Cat 'cat=X60NBCPUGPUOCOn || cat=X60NBCPUGPUOCOnACToDC || cat=X60NBCPUGPUOCOnDCToAC || cat=HWInfoIntelCPUGPUOCOn || cat=ThermalModeDCModeX60 || cat=ThermalModeACToDCModeX60AutoOff || cat=GamingThermalModeX60New || cat= ThermalModeACModeX60AutoOn ||cat=GamingSearchX60GPUOC || cat=GamingSearchVRAMOC || cat=GamingSearchNoDriverX60GPUOC' 

# http://10.119.146.59/common/index.html
@GamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 15 Client Agent-146.59
	Given Run Clients '10.119.146.59' And Run Version 'CommonBrand=Common' Run Cat 'cat=X60NBCPUOCOn || cat=X60NBCPUOCOnACToDC || cat=X60NBCPUOCOnDCToAC|| cat=HWInfoIntelCPUOCOn || cat= ThermalModeDCModeX60AutoOn || cat=ThermalModeDCToACModeX60AutoOff'

# http://10.119.165.49/common/index.html
@GamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 16 Client Agent-165.49
	Given Run Clients '10.119.165.49' And Run Version 'CommonBrand=Common' Run Cat 'cat=GamingMemoryOCOfftest || cat=GamingMacroKey15InchKeyboardLayout || cat=GamingOldThermalModeAC || cat=GamingOldThermalModeDC || cat= AutoClose || cat=RAMOCSupportedDriverinstalled'