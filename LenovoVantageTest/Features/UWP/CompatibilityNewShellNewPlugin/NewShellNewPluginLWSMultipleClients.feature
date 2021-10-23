Feature:NewShellNewPluginLWSMultipleClients
	LWS Bamboo Agent 1 To Multiple Client

# http://10.119.168.247/index.html
@NSNPGamingLWSMultipleClientsSpecFlow
Scenario: Run NewShellNewPlugin LWS Local Run 1 Client GamingLWS
	Given Run Clients '10.119.154.153' And Run Version 'NewShellNewPlugin=NewShellNewPlugin' Run Cat 'cat=LWStoggleandtileinthehomepageforgamingtheme'

