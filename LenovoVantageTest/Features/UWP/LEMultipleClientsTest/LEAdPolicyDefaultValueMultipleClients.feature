Feature: LEAdPolicyDefaultValueMultipleClients
	Settings for LE Multiple Client AdPolicy Default Values Testing

#http://10.119.153.207/tw/index.html
@LEAdPolicyDefaultValuesMultipleClientsSpecFlow
Scenario: Run Settings Local Run System19
	Given Run Clients '10.119.153.207' And Run Version 'RunAsTW EnterpriseBrand=Commercial' Run Cat 'cat=MicrophoneSettings_PolicyValues'

#http://10.119.153.143/tw/index.html
@LEAdPolicyDefaultValuesMultipleClientsSpecFlow
Scenario: Run Settings Local Run QiTianM435
	Given Run Clients '10.119.153.143' And Run Version 'RunAsTW EnterpriseBrand=Commercial' Run Cat 'cat=MicrophoneSettings_NoSupport_PolicyValues'