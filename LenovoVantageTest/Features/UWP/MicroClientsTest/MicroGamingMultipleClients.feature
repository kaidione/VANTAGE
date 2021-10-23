Feature: MicroGamingMultipleClients
	Gaming Bamboo Agent 1 To Multiple Client

# http://10.119.139.170/common/index.html
@MicroGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 1 Client Y760AMD
	Given Run Clients '10.119.139.170' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=X60NBGPUOCOff ||cat=MultiGameDetection ||cat=ThermalModeACModeX60AutoOff ||cat=X60NBGPUOCOffACToDC ||cat=X60NBGPUOCOffDCToAC ||cat=ThermalModeACModeX60|| cat=ThermalModeACToDCModeX60AutoOff'

# http://10.119.171.47/common/index.html
@MicroGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 2 Client Agent-Y750s
	Given Run Clients '10.119.171.47' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=GamingNetworkBoostAutoCloseToast'

# http://10.119.172.196/common/index.html
@MicroGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 3 Client Agent-L360Intel
	Given Run Clients '10.119.172.196' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=GamingGPUOCVRAM ||cat=DPMSearchUnSupport || cat=GamingSearchNetworkBoost || cat=GamingSearchAutoClose || cat=GamingSearchThermalMode3 || cat=SettingsSearchSmartPowerPageGaming'

# http://10.119.164.190/common/index.html
@MicroGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 4 Client Agent-Y760AMDPQ
	Given Run Clients '10.119.164.190' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=IntellegentSubMode || cat=PowerPlanPQPlans || cat=GamingEnableNahimic || cat=GamingEnableX-rite'
	
# http://10.119.175.34/common/index.html
@MicroGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 5 Client Agent-Y560AMDB
	Given Run Clients '10.119.175.34' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=PowerPlanBalanceMode || cat=HWInfoAMD || cat=GamingNetworkBoostInstallVantage'
	
# http://10.119.169.187/common/index.html
@MicroGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 6 Client Agent-Y560AMDBQ
	Given Run Clients '10.119.169.187' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=PowerPlanBQPlans  || cat= GamingTagDetection || cat=OverDriveSupported || cat=Thermalmode4.0Supported || cat=LightingNBSupported ||cat=GamingSearchTP ||cat=GamingSearch ||cat=GamingSearchMacroKey ||cat=GamingSearchHybridMode ||cat=GamingSearchOverDrive '
	
# http://10.119.188.123/common/index.html
@MicroGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 7 Client Agent-Y560AMDPB
	Given Run Clients '10.119.188.123' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=PowerPlanPBPlans || cat=HWInfoAMDOCOFF || cat=LightingeffectDMTipsNB || cat=LightingeffectitemTipsNB'

# http://10.119.177.64/common/index.html
@MicroGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 8 Client Agent-Y560AMDP
	Given Run Clients '10.119.177.64' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=PowerPlanPerformanceMode'
	
# http://10.119.138.239/common/index.html
@MicroGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 9 Client Agent-Y560AMDNewGPUOC
	Given Run Clients '10.119.138.239' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=PowerPlanManualThreePlans || cat=HWInfoAMDOCON || cat=PowerPlanModifyPlanSettings'
	
# http://10.119.148.194/common/index.html
@MicroGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 10 Client Agent-Y760AMD
	Given Run Clients '10.119.148.194' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=PowerPlanNoPlan || cat=PowerPlanModifyPlanCreateSamePlan'
		
# http://10.119.175.240/common/index.html
@MicroGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 11 Client Agent-Y760AMDQ
	Given Run Clients '10.119.175.240' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=PowerPlanQuietPlan || cat=X60NBGPUOCOn||cat=X60NBGPUOCOnACToDC||cat=X60NBGPUOCOnDCToAC ||cat=ThermalModeDCToACModeX60AutoOn ||cat=ThermalModeDCModeX60AutoOff ||cat=ThermalModeACToDCModeX60AutoOn'

# http://10.119.144.100/common/index.html
@MicroGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 12 Client Agent-C730
	Given Run Clients '10.119.144.100' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=GamingReskinWiFiSecuritySubpage || cat=GamingCapacity_C730 || cat=GamingOLdCPUOC || cat=OldDriverLackXTUS4 || cat=OldDriverLackNetfilter || cat=OldDriverLackNetfilterS3 || cat=OldDriverLackNetfilterS4 || cat=OldDriverLackLightingS4  || cat=GamingOLdCPUOCNoWifi  || cat=CPUOCSupported  || cat=ThermalmodeUnSupported || cat=LightingTowerSupportedLEDDriver|| cat=GamingMemoryOCtestNoWifi || cat=GamingSearchLighting || cat=GamingSearchRAMOC || cat=GamingSearchOldCPUOC || cat=GamingSearchNoDriverNB || cat=GamingSearchNoDriverLighting || cat=GamingSearchNoDriverOldCPUOC || cat=GamingSearchNoDriverRAMOC || cat=GamingSearchNoThermalMode'

# http://10.119.133.97/common/index.html
@MicroGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 13 Client Agent-Y560IntelNewCPUGPUOC
	Given Run Clients '10.119.133.97' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=X60NBCPUGPUOCOn || cat=X60NBCPUGPUOCOnACToDC || cat=X60NBCPUGPUOCOnDCToAC || cat=HWInfoIntelCPUGPUOCOn || cat=ThermalModeDCModeX60 || cat=GamingThermalModeX60New ||cat=GamingSearchX60GPUOC || cat=GamingSearchVRAMOC || cat=GamingSearchNoDriverX60GPUOC || cat=GamingSearchNoDriverVRAMOC'

# http://10.119.146.59/common/index.html
@MicroGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 14 Client Agent-Y760IntelNewCPUOC
	Given Run Clients '10.119.146.59' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=X60NBCPUOCOn || cat=X60NBCPUOCOnACToDC || cat=X60NBCPUOCOnDCToAC|| cat=HWInfoIntelCPUOCOn || cat= ThermalModeDCModeX60AutoOn || cat=ThermalModeDCToACModeX60AutoOff || cat= ThermalModeACModeX60AutoOn'

# http://10.119.165.49/common/index.html
@MicroGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 15 Client Agent-Y74015
	Given Run Clients '10.119.165.49' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=GamingMemoryOCOfftest || cat=GamingMacroKey15InchKeyboardLayout || cat=GamingOldThermalModeAC || cat=GamingOldThermalModeDC || cat= AutoClose || cat=RAMOCSupportedDriverinstalled'

# http://10.119.171.85/common/index.html
@MicroGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 16 Client Agent-T750RKL
    Given Run Clients '10.119.171.85' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=GamingGPULightingProfileDefaultNV || cat=GPULightingDriverLackNV || cat=LightingeffectDMTipsRGB || cat=LightingeffectitemTipsRGB || cat=GPULightingBrightness || cat=GPULightingColorSquare || cat=GPULightingEffect || cat=GPULightingSpeed || cat=LightingSwitchEightLights || cat=X50MemoryLightingDefault || cat=X50MemoryLightingBrightness || cat=X50MemoryLightingColorSquare || cat=X50MemoryLightingEffect || cat=X50MemoryLightingSpeed || cat=LightingDTSixLightsRear || cat=DTLightingOldSingleColorEffect || cat=DTLightingOldRGBEffect || cat=DTLightingOldSingleSpeed || cat=DTLightingOldSingleBrightness || cat=NVTurboBoostNotSupported || cat=DTLightingOldSingleColorSquare'

# http://10.119.154.64/common/index.html
@MicroGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 17 Client Agent-T750CML
    Given Run Clients '10.119.154.64' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=LightingDTSixLightsCooling || cat=GamingX50CPUOCOtherItemsT750'

# http://10.119.153.183/common/index.html
@MicroGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 18 Client Agent-T550Intel
    Given Run Clients '10.119.153.183' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=T550IntelLightingRear || cat=HomepageLighting'

# http://10.119.185.6/common/index.html
@MicroGamingMultipleClientsSpecFlow
Scenario: Run Gaming Local Run 19 Client Agent-T770ADL
    Given Run Clients '10.119.185.6' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=DTLightingRGBBrightness || cat=DTLightingNewSingleBrightness || cat=DTLightingNewRGBBrightness || cat=DTLightingRGBColorSquare || cat=DTLightingNewSingleColorSquare || cat=DTLightingNewRGBColorSquare || cat=DTLightingRGBEffect || cat=DTLightingNewSingleColorEffect || cat=DTLightingNewSingleColorEffect || cat=DTLightingRGBNewEffect || cat=DTLightingRGBSpeed || cat=DTLightingNewSingleSpeed || cat=DTLightingNewRGBSpeed || cat=LightingNeweffectDMTipsRGB || cat=LightingNeweffectitemTipsRGB || cat=LightingDTX70SixLightsRear || cat=NVTurboBoost'