Feature: NewShellNewPluginITSNewOSMultipleClients
	ITS Bamboo Agent 1 To Multiple Client

# http://10.119.186.215/micro/index.html
@ITSNewOsNSOWMultiple
Scenario: Run Micro ITS Local Run 1 Client DYTC4CQL
	Given Run Clients '10.119.186.215' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=ThinkDytc4CQL || cat=DYTC4CQLSearch'

# http://10.119.154.73/micro/index.html
@ITSNewOsNSOWMultiple
Scenario: Run Micro ITS Local Run 2 Client DYTC4TIO
	Given Run Clients '10.119.154.73' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=DYTC4TIO'

# http://10.119.179.88/micro/index.html
@ITSNewOsNSOWMultiple
Scenario: Run Micro ITS Local Run 2 Client ITS3
	Given Run Clients '10.119.179.88' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=ITS3ToolbarNewOS || cat=ITS3UI || cat=ITS3UIS3S4 || cat=ITS3UI_DisconnectNetwork ||cat=ITS3Search'

# http://10.119.137.124/micro/index.html
@ITSNewOsNSOWMultiple
Scenario: Run Micro ITS Local Run 3 Client ITS2
	Given Run Clients '10.119.137.124' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=ITS2UI || cat=ITS2Search'

# http://10.119.159.53/micro/index.html
@ITSNewOsNSOWMultiple
Scenario: Run Micro ITS Local Run 4 Client DYTC6AMT
	Given Run Clients '10.119.159.53' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=DYTC6AMTUI'
## ||cat=DYTC6AMTActiveModeAndLink||cat=DYTC6AMTActiveModeAndLink_DC

# http://10.119.181.181/micro/index.html
@ITSNewOsNSOWMultiple
Scenario: Run Micro ITS Local Run 5 Client DYTC3CQL
	Given Run Clients '10.119.181.181' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=DYTC3CQL || cat=DYTC3CQLSearch'

# http://10.119.171.228/micro/index.html
@ITSNewOsNSOWMultiple
Scenario: Run Micro ITS Local Run 6 Client DYTC3TIO
	Given Run Clients '10.119.171.228' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=DYTC3TIO || cat=CheckDoNotSupportCameraPrivacy'
#
## http://10.119.138.63/micro/index.html
#@ITSNewOsNSOWMultiple
#Scenario: Run ITS Local Run 7 Client ITS45
#	Given Run Clients '10.119.138.63' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=ITS5DriverToolbarMetrics || cat=ideaITS5Function_17172 || cat=ITS5Search'

# http://10.119.145.190/micro/index.html
@ITSNewOsNSOWMultiple
Scenario: Run ITS Local Run 8 Client Agent-11 DYTC5
	Given Run Clients '10.119.145.190' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=DYTC5UI||cat=DYTC5toolbar'
	###cat=DYTC5ActiveStateUI||

# http://10.119.146.20/micro/index.html
@ITSNewOsNSOWMultiple
Scenario: Run ITS Local Run 9 Client ITS5GPUOC
	Given Run Clients '10.119.146.20' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=ideaITS5Function_17172S3S4 || cat=ITS5UI_17173 || cat=ITS5ToolbarNewOS || cat=ITS5Search'

# http://10.119.170.185/micro/index.html
@ITSNewOsNSOWMultiple
Scenario: Run ITS Local Run 10 Client ITS4SMB
	Given Run Clients '10.119.170.185' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=ITS4SMBUI || cat=SMBMicrophoneForteMediaAudio || cat=CreatorHDR || cat=SettingsSMBSearch || cat=ITSSMBSearch'

# http://10.119.154.173/common/index.html
@ITSNewOsNSOWMultiple
Scenario: Run ITS Local Run 11 Client ITS agent-41
	Given Run Clients '10.119.154.173' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=IntelligentCooling_18037 || cat=IntelligentCooling_18037_offline || cat=ThinkDytc6CS2021S3S4_18037 || cat=CheckBatteryConditionOnThinkPad135W || cat= DYTC6MWSSearch'
	### || cat=DYTC6MWSActiveStateUI 

# http://10.119.162.231/common/index.html
@ITSNewOsNSOWMultiple
Scenario: Run ITS Local Run 11 Client ITS agent-46 DYTC6NOAMT
	Given Run Clients '10.119.162.231' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=DYTC6NOAMTUI||cat=DYTC6NOAMTSearch'
	### ||cat=DYTC6NoAMTActiveModeAndLink||cat=DYTC6NoAMTActiveModeAndLink_DC

# http://10.119.164.69/common/index.html
#@ITSNewOsNSOWMultiple
#Scenario: Run ITS Local Run 10 Client ITS4
#	Given Run Clients '10.119.164.69' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=ITS4DPTF || cat=ITS4UI || cat=ITS4DriverMetrics || cat=ITS4UIS3S4 || cat=ITS4ToolbarUpdateTips || cat=ITS4DriverToolbarMetrics || cat=ITS4toolbar_20456 || cat = ITS4Search'

# http://10.119.135.12/common/index.html
@ITSNewOsNSOWMultiple
Scenario: Run ITS Local Run 10 Client DYTC4 NOCQL
	Given Run Clients '10.119.135.12' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat= DYTC4NOCQLUI'
