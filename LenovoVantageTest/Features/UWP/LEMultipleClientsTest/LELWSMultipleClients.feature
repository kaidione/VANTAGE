Feature: LWSMultipleClients
	LWS Bamboo Agent 1 To Multiple Client

# http://10.119.168.121/le/index.html
@LELWSMultipleClientsSpecFlow
Scenario: Run LWS Local Run 1 Client LeLWS
	Given Run Clients '10.119.168.121' And Run Version 'EnterpriseBrand=Commercial' Run Cat 'cat=CaseNeedTestBlueBarLE'	
