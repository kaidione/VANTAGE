Feature: OldShellNewITSMultipleClients
	ITS Bamboo Agent 1 To Multiple Client

# http://10.119.149.105/index.html
@OSNPITSMultipleClientsSpecFlow
Scenario: Run OldShellNew ITS Local Run 1 Client DYTC4CQL
	Given Run Clients '10.119.149.105' And Run Version 'OldShellNewPlugin=OldShellNewPlugin' Run Cat 'cat=ThinkDytc4CQL || cat=DYTC4CQLSearch'

# http://10.119.154.73/index.html
@OSNPITSMultipleClientsSpecFlow
Scenario: Run OldShellNew ITS Local Run 2 Client DYTC4TIO
	Given Run Clients '10.119.154.73' And Run Version 'OldShellNewPlugin=OldShellNewPlugin' Run Cat 'cat=DYTC4TIO'

# http://10.119.137.124/index.html
@OSNPITSMultipleClientsSpecFlow
Scenario: Run OldShellNew ITS Local Run 3 Client ITS2
	Given Run Clients '10.119.137.124' And Run Version 'OldShellNewPlugin=OldShellNewPlugin' Run Cat 'cat=ITS2UI || cat =ITS2Search'

# http://10.119.159.53/index.html
@OSNPITSMultipleClientsSpecFlow
Scenario: Run OldShellNew ITS Local Run 4 Client DYTC6AMT
	Given Run Clients '10.119.159.53' And Run Version 'OldShellNewPlugin=OldShellNewPlugin' Run Cat 'cat=DYTC6AMTUI ||cat=DYTC6AMTActiveModeAndLink||cat=DYTC6AMTActiveModeAndLink_DC'

# http://10.119.181.181/index.html
@OSNPITSMultipleClientsSpecFlow
Scenario: Run OldShellNew ITS Local Run 5 Client DYTC3CQL
	Given Run Clients '10.119.181.181' And Run Version 'OldShellNewPlugin=OldShellNewPlugin' Run Cat 'cat=DYTC3CQL || cat=DYTC3CQLSearch'

# http://10.119.171.228/index.html
@OSNPITSMultipleClientsSpecFlow
Scenario: Run OldShellNew ITS Local Run 6 Client DYTC3TIO
	Given Run Clients '10.119.171.228' And Run Version 'OldShellNewPlugin=OldShellNewPlugin' Run Cat 'cat=DYTC3TIO || cat=CheckDoNotSupportCameraPrivacy'

# http://10.119.138.63/index.html
#@OSNPITSMultipleClientsSpecFlow
#Scenario: Run OldShellNew ITS Local Run 7 Client ITS45
#	Given Run Clients '10.119.138.63' And Run Version 'OldShellNewPlugin=OldShellNewPlugin' Run Cat 'cat=ITS5DriverToolbarMetrics || cat=ideaITS5Function_17172 || cat=ITS5Search'

# http://10.119.145.190/index.html
@OSNPITSMultipleClientsSpecFlow
Scenario: Run OldShellNew ITS Local Run 8 Client Agent-11
	Given Run Clients '10.119.145.190' And Run Version 'OldShellNewPlugin=OldShellNewPlugin' Run Cat 'cat=DYTC5ActiveStateUI||cat=DYTC5UI||cat=DYTC5toolbar'

# http://10.119.146.20/index.html
@OSNPITSMultipleClientsSpecFlow
Scenario: Run OldShellNew ITS Local Run 9 Client ITS5GPUOC
	Given Run Clients '10.119.146.20' And Run Version 'OldShellNewPlugin=OldShellNewPlugin' Run Cat 'cat=ideaITS5Function_17172S3S4 || cat=ITS5UI_17173 || cat=ITS5toolbar_20458 || cat=ITS5ToolbarUpdateTips || cat=ITS5Search'

# http://10.119.154.173/index.html
@OSNPITSMultipleClientsSpecFlow
Scenario: Run ITS Local Run 11 Client ITS agent-41
	Given Run Clients '10.119.154.173' And Run Version 'OldShellNewPlugin=OldShellNewPlugin' Run Cat 'cat=IntelligentCooling_18037 || cat=DYTC6MWSActiveStateUI || cat=IntelligentCooling_18037_offline || cat=ThinkDytc6CS2021S3S4_18037 || cat=CheckBatteryConditionOnThinkPad135W || cat = DYTC6MWSSearch'

# http://10.119.170.185/index.html
@OSNPITSMultipleClientsSpecFlow
Scenario: Run ITS Local Run 10 Client ITS4SMB
	Given Run Clients '10.119.170.185' And Run Version 'OldShellNewPlugin=OldShellNewPlugin' Run Cat 'cat=ITS4SMBUI || cat=SMBMicrophoneForteMediaAudio || cat=CreatorHDR || cat=SettingsSMBSearch || cat=ITSSMBSearch'

# http://10.119.135.12/common/index.html
@MOSNPITSMultipleClientsSpecFlow
Scenario: Run ITS Local Run 10 Client DYTC4 NOCQL
	Given Run Clients '10.119.135.12' And Run Version 'OldShellNewPlugin=OldShellNewPlugin' Run Cat 'cat= DYTC4NOCQLUI'

# http://10.119.164.69/common/index.html
@OSNPITSMultipleClientsSpecFlow
Scenario: Run ITS Local Run 10 Client ITS4
	Given Run Clients '10.119.164.69' And Run Version 'OldShellNewPlugin=OldShellNewPlugin' Run Cat 'cat=ITS4DPTF || cat=ITS4UI || cat=ITS4DriverMetrics || cat=ITS4UIS3S4 || cat=ITS4ToolbarUpdateTips || cat=ITS4DriverToolbarMetrics || cat=ITS4toolbar_20456 || cat = ITS4Search'
