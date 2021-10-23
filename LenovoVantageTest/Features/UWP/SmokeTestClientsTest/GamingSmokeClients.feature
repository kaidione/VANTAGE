Feature: GamingSmokeClients
	Gaming Smoke Bamboo Agent 1 To Multiple Client

# http://10.119.172.196/common/index.html
@GamingSmokeClientsSpecFlow
Scenario: Run Gaming Local Run 1 Client Agent-172.196
	Given Run Clients '10.119.172.196' And Run Version 'CommonBrand=Common' Run Cat 'cat=GamingSmokeVRAMOC'

# http://10.119.164.190/common/index.html
@GamingSmokeClientsSpecFlow
Scenario: Run Gaming Local Run 2 Client Agent-164.190
	Given Run Clients '10.119.164.190' And Run Version 'CommonBrand=Common' Run Cat 'cat=GamingSmokeThermalMode4AutoAdjust ||cat=GamingSmokeThermalMode4 || cat=GamingSmokeNahamic || cat=GamingSmokeXrite'
# http://10.119.175.34/common/index.html
@GamingSmokeClientsSpecFlow
Scenario: Run Gaming Local Run 3 Client Agent-175.34
	Given Run Clients '10.119.175.34' And Run Version 'CommonBrand=Common' Run Cat 'cat=GamingSmokeLegionEdgeSection || cat=GamingSmokeLegionUI || cat=GamingSmokeHWInfo'
	
# http://10.119.138.239/common/index.html
@GamingSmokeClientsSpecFlow
Scenario: Run Gaming Local Run 5 Client Agent-138.239
	Given Run Clients '10.119.138.239' And Run Version 'CommonBrand=Common' Run Cat 'cat=GamingSmokePowerpage ||cat=GamingSmokeAudiopage ||cat=GamingSmokeHardwareScan || cat=GamingSmokeRapidCharge ||cat=GamingSmokeTPLock || cat=GamingSmokeNetworkBoost'
			
# http://10.119.144.100/common/index.html
@GamingSmokeClientsSpecFlow
Scenario: Run Gaming Local Run 6 Client Agent-144.100
	Given Run Clients '10.119.144.100' And Run Version 'CommonBrand=Common' Run Cat 'cat=GamingSmokeNoDolby || cat=GamingSmokeNoRapidCharge || cat=GamingSmokeWifiSecurity || cat=GamingSmokeOldCPUOC'

# http://10.119.165.49/common/index.html
@GamingSmokeClientsSpecFlow
Scenario: Run Gaming Local Run 9 Client Agent-165.49
	Given Run Clients '10.119.165.49' And Run Version 'CommonBrand=Common' Run Cat 'cat=GamingSmokeNoLightingSectionNB || cat=GamingSmokeHibridModeOff || cat= GamingSmokeNOOD || cat=GamingSmokeRAMOCOff || cat=GamingSmokeThermalMode2 || cat= GamingSmokeQuickSettingSectionNB || cat=GamingSmokeSystemStatusBar || cat=GamingSmokeMacrokeyMkey'
