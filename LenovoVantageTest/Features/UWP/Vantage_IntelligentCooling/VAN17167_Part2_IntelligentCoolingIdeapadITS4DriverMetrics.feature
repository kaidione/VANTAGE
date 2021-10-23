Feature: VAN17167_Part2_IntelligentCoolingIdeapadITS4DriverMetrics
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17167
	Developer: Huajie

@ITS4DriverMetrics
Scenario: VAN17167_TestStep13_Change machine state to TENT
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	When change ITS mode to ISTD via Vantage
	When change machine to TENT mode
	Then check last mode is ISTD
	Then check current mode is TENT
	Then check switch type is AUTO

@ITS4DriverMetrics
Scenario: VAN17167_TestStep14_Change machine state from TENT to PAD
	When change machine to PAD mode
	Then check last mode is TENT
	Then check current mode is PAD
	Then check switch type is AUTO

@ITS4DriverMetrics
Scenario: VAN17167_TestStep15_Change ITS mode to EPM
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	Then check last mode is PAD
	Then check current mode is EPM
	Then check switch type is FNQ

@ITS4DriverMetrics
Scenario: VAN17167_TestStep16_Change machine state from PAD to normal
	When change machine to NB mode
	Then check last mode is PAD
	Then check current mode is EPM
	Then check switch type is FNQ

@ITS4DriverMetrics
Scenario: VAN17167_TestStep21_Restart ITS service and check ITS mode
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	When change ITS mode to ISTD via Vantage
	When restart ITSservice
	Then check last mode is EPM
	Then check current mode is ISTD
	Then check switch type is FNQ

@ITS4DriverMetrics
Scenario: VAN17167_TestStep22_Change ITS mode from ICM to BSM
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	When open toolbar
	When click ITSicon
	Then check last mode is ISTD
	Then check current mode is BSM
	Then check switch type is FNQ