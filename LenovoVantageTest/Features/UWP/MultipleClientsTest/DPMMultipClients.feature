Feature: DPMMultipClients
	Bamboo Agent 1 To Multiple Client

# http://10.119.168.54/common/index.html
@DPMMultipleClientsSpecFlow
Scenario: Run Common DPM Local Run  Client Agent-43
	Given Run Clients '10.119.168.54' And Run Version 'CommonBrand=Common' Run Cat 'cat=DPM && cat!=NotDPM && cat!=GPSDebug || cat=DPMSearch || cat=GamingSearchNoNetworkBoost || cat=GamingSearchNoAutoClose'

# http://10.119.168.54/le/index.html
@LEDPMMultipleClientsSpecFlow
Scenario: Run LE DPM Local Run  Client Agent-43
	Given Run Clients '10.119.168.54' And Run Version 'EnterpriseBrand=Commercial' Run Cat 'cat=DPM && cat!=NotDPM && cat!=GPSDebug'

# http://10.119.168.54/micro/index.html
@MicroDPMMultipleClientsSpecFlow
Scenario: Run Micro DPM Local Run  Client Agent-43
	Given Run Clients '10.119.168.54' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=DPM && cat!=NotDPM && cat!=GPSDebug || cat=DPMSearch || cat=GamingSearchNoNetworkBoost || cat=GamingSearchNoAutoClose'

# http://10.119.168.54/common/index.html
@OSNPDPMMultipleClientsSpecFlow
Scenario: Run OldShellNewPlugin DPM Local Run  Client Agent-43
	Given Run Clients '10.119.168.54' And Run Version 'OldShellNewPlugin=OldShellNewPlugin' Run Cat 'cat=DPM && cat!=NotDPM && cat!=GPSDebug'

# http://10.119.168.54/common/index.html
@NSNPDPMMultipleClientsSpecFlow
Scenario: Run NewShellNewPlugin DPM Local Run  Client Agent-43
	Given Run Clients '10.119.168.54' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=DPM && cat!=NotDPM && cat!=GPSDebug'

# http://10.119.142.134/micro/index.html
@MicroDPMMultipleClientsSpecFlowNewOS
Scenario: Run Micro DPM Local Run  Client 142.134
	Given Run Clients '10.119.142.134' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=DPM && cat!=NotDPM && cat!=GPSDebug || cat=DPMSearch || cat=GamingSearchNoNetworkBoost || cat=GamingSearchNoAutoClose'
