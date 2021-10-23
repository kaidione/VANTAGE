Feature: MicroLWSMultipleClients
	LWS Bamboo Agent 1 To Multiple Client

# http://10.119.154.153/micro/index.html
@MiroGamingLWSMultipleClientsSpecFlow
Scenario: Run LWS Local Run 1 Client GamingLWS
	Given Run Clients '10.119.154.153' And Run Version 'VantageUWPType=MicroFrontendsVantage' Run Cat 'cat=LWStoggleandtileinthehomepageforgamingtheme'