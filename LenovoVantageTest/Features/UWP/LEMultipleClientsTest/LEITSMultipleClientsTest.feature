Feature: LEITSMultipleClients
	ITS Bamboo Agent 1 To LE Multiple Client

# http://10.119.149.105/le/index.html
@LEITSMultipleClientsSpecFlow
Scenario: Run ITS Local Run 1 LE Client DYTC4CQL
	Given Run Clients '10.119.149.105' And Run Version 'EnterpriseBrand=Commercial' Run Cat 'cat=ThinkDytc4CQL'

# http://10.119.154.73/le/index.html
@LEITSMultipleClientsSpecFlow
Scenario: Run ITS Local Run 2 LE Client DYTC4TIO
	Given Run Clients '10.119.154.73' And Run Version 'EnterpriseBrand=Commercial' Run Cat 'cat=DYTC4TIO'

# http://10.119.159.53/le/index.html
@LEITSMultipleClientsSpecFlow
Scenario: Run ITS Local Run 3 LE Client DYTC6AMT
	Given Run Clients '10.119.159.53' And Run Version 'EnterpriseBrand=Commercial' Run Cat 'cat=DYTC6AMTUI'

# http://10.119.181.181/le/index.html
@LEITSMultipleClientsSpecFlow
Scenario: Run ITS Local Run 4 LE Client DYTC3CQL
	Given Run Clients '10.119.181.181' And Run Version 'EnterpriseBrand=Commercial' Run Cat 'cat=DYTC3CQL'

# http://10.119.171.228/le/index.html
@LEITSMultipleClientsSpecFlow
Scenario: Run ITS Local Run 5 Client DYTC3TIO
	Given Run Clients '10.119.171.228' And Run Version 'EnterpriseBrand=Commercial' Run Cat 'cat=DYTC3TIO || cat=CheckLEDoNotSupportCameraPrivacy'

# http://10.119.145.190/le/index.html
#@ITSMultipleClientsSpecFlow
#Scenario: Run ITS Local Run 8 Client Agent-11
#	Given Run Clients '10.119.145.190' And Run Version 'EnterpriseBrand=Commercial' Run Cat 'cat=DYTC5ActiveStateUI || cat=BatteryGaugeResetOneBatteryNeedRunonBJ19 || cat=BatteryGaugeResetOneBatteryNeedRunonBJ19ACTDC'

# http://10.119.154.173/common/index.html
@LEITSMultipleClientsSpecFlow
Scenario: Run ITS Local Run 11 Client ITS agent-41
	Given Run Clients '10.119.154.173' And Run Version 'EnterpriseBrand=Commercial' Run Cat 'cat=IntelligentCooling_18037 || cat=IntelligentCooling_18037_offline || cat=ThinkDytc6CS2021S3S4_18037 || cat=CheckBatteryConditionOnThinkPad135WLE'

