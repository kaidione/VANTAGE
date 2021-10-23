Feature: LWSSmokeClients
	LWS Smoke Bamboo Agent 1 To Multiple Client

# http://10.119.154.153/common/index.html
@LWSSmokeClientsSpecFlow
Scenario: Run LWS Local Run 1 Client GamingLWS
	Given Run Clients '10.119.154.153' And Run Version 'CommonBrand=Common' Run Cat 'cat=lwssmoke9695'
