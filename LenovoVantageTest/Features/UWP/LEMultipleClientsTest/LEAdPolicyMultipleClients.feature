Feature: LEAdPolicyMultipleClients
	Settings Bamboo Agent 1 To LE Multiple Client

# http://10.119.129.207/tw/index.html
@LEAdPolicyMultipleClientsSpecFlow
Scenario: Run Settings Local Run 300W
	Given Run Clients '10.119.129.207' And Run Version 'RunAsTW EnterpriseBrand=Commercial' Run Cat 'cat=AudioSmartSettings_notSupport_AdPolicy || cat=Display_AdPolicy || cat=DisplayCamera_AdPolicy || cat=StandBySettings_NoSupport_AdPolicy || cat=BatterySettings_AdPolicy || cat=PowerSmartSettings_AdPolicy || cat=PowerSettings_AdPolicy'

#http://10.119.153.207/tw/index.html
@LEAdPolicyMultipleClientsSpecFlow
Scenario: Run Settings Local Run System19
	Given Run Clients '10.119.153.207' And Run Version 'RunAsTW EnterpriseBrand=Commercial' Run Cat 'cat=StandBySettings_AdPolicy || cat=IntelligentKeyboard_AdPolicy || cat=Camera_AdPolicy || cat=MicrophoneSettings_AdPolicy || cat=BatterySettings_AdPolicy || cat=PowerSmartSettings_AdPolicy || cat=PowerSettings_AdPolicy'

#http://10.119.129.48/tw/index.html
@LEAdPolicyMultipleClientsSpecFlow
Scenario: Run Settings Local Run ThinkcenterM910z
	Given Run Clients '10.119.172.53' And Run Version 'RunAsTW EnterpriseBrand=Commercial' Run Cat 'cat=IntelligentKeyboard_NoSupport_AdPolicy || cat=BatterySettings_NoSupport_AdPolicy || cat=PowerSmartSettings_NoSupport_AdPolicy || cat=PowerSettings_NoSupport_AdPolicy'
