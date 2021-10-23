Feature: VAN17167_Part1_IntelligentCoolingIdeapadITS4DriverMetrics
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17167
	Developer: Huajie

@ITS4DriverMetrics
Scenario: VAN17167_TestStep02_Check Regedit Value in Registry
	When change machine to NB mode
	Then check regedit value about ITS

@ITS4DriverMetrics
Scenario: VAN17167_TestStep04_Change From EPM to BSM via Vanatge
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	When change ITS mode to BSM via Vantage
	Then check last mode is EPM
	Then check current mode is BSM
	Then check switch type is FNQ

@ITS4DriverMetrics
Scenario: VAN17167_TestStep05_Change to EPM via Vantage
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	Then check last mode is BSM
	Then check current mode is EPM
	Then check switch type is FNQ

@ITS4DriverMetrics
Scenario: VAN17167_TestStep06_Change to ISTD via Vantage
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	Then check last mode is EPM
	Then check current mode is ISTD
	Then check switch type is FNQ

@ITS4DriverMetrics
Scenario: VAN17167_TestStep07_Open an app to enter AQM
	When close lenovo vantage
	When open ie and keep 30s
	Then check last mode is ISTD
	Then check current mode is IAQ
	Then check switch type is AUTO

@ITS4DriverMetrics
Scenario: VAN17167_TestStep08_Close the app and exit AQM
	When kill iexplore and wait 60 second 
	Then check last mode is IAQ
	Then check current mode is ISTD
	Then check switch type is AUTO

@ITS4DriverMetrics
Scenario: VAN17167_TestStep09_Run a game in gamelist and enter APM
	When open DNF and keep 30s
	Then check last mode is ISTD
	Then check current mode is IAP
	Then check switch type is AUTO

@ITS4DriverMetrics
Scenario: VAN17167_TestStep10_Close the game and exit APM
	When kill Client and wait 60 second 
	Then check last mode is IAP
	Then check current mode is ISTD
	Then check switch type is AUTO

@ITS4DriverMetrics
Scenario: VAN17167_TestStep11_Run a game not in gamelist and enter APM
	When close lenovo vantage
	When open farmgame and keep 30s
	Then check last mode is ISTD
	Then check current mode is IAP
	Then check switch type is AUTO

@ITS4DriverMetrics
Scenario: VAN17167_TestStep12_Close the game and exit APM
	When kill farmheroessaga and wait 60 second 
	Then check last mode is IAP
	Then check current mode is ISTD
	Then check switch type is AUTO