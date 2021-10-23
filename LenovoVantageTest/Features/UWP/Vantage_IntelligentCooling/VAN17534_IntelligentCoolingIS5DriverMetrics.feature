Feature: VAN17534_IntelligentCoolingIS5DriverMetrics
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17534
	Author: Xiaoxiong Li

@ITS5DriverFunction
Scenario: VAN17534_TestStep01_check regedit value 
	Then check regedit value about ITS

@ITS5DriverFunction
Scenario: VAN17534_TestStep03_check ITSMode
	Given Go to Power Page
	When change ITS mode to BSM via Vantage
	Then ITSlast mode is ISTD
	Then ITSCurrent mode is BSM
	Then check switch type is manual

@ITS5DriverFunction
Scenario: VAN17534_TestStep04_check ITSMode
	Given Go to Power Page
	When change ITS mode to BSM via Vantage
	When change ITS mode to EPM via Vantage
	Then ITSlast mode is BSM
	Then ITSCurrent mode is EPM
	Then check switch type is manual

@ITS5DriverFunction
Scenario: VAN17534_TestStep05_check ITSMode
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	Then ITSlast mode is EPM
	Then ITSCurrent mode is STD
	Then check switch type is manual

@ITS5DriverFunction
Scenario: VAN17534_TestStep06_check ITSMode
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	When open ie and keep 30s
	Then ITSlast mode is ISTD
	Then ITSCurrent mode is AQM
	Then check switch type is auto

@ITS5DriverFunction
Scenario: VAN17534_TestStep07_check ITSMode
	When kill ie and wait 60 second 
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	When open ie and keep 30s
	When kill ie and wait 60 second 
	Then ITSlast mode is AQM
	Then ITSCurrent mode is ISTD
	Then check switch type is auto

@ITS5DriverFunction
Scenario: VAN17534_TestStep09_check ITSMode
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	Given run photoshop
	Given Waiting 30 seconds
	Then ITSlast mode is ISTD
	Then ITSCurrent mode is APM
	Then check switch type is auto

@ITS5DriverFunction
Scenario: VAN17534_TestStep10_check ITSMode
	When kill photoshop and wait 0 second
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	Given run photoshop
	Given Waiting 30 seconds
	When kill photoshop and wait 0 second
	Then ITSlast mode is APM
	Then ITSCurrent mode is ISTD
	Then check switch type is auto

@ITS5DriverFunction
Scenario: VAN17534_TestStep12_check ITSMode
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	Given run csgo
	Given Waiting 60 seconds
	Then ITSlast mode is ISTD
	Then ITSCurrent mode is IEPM
	Then check switch type is auto

@ITS5DriverFunction
Scenario: VAN17534_TestStep13_check ITSMode
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	Given run csgo
	Given Waiting 60 seconds
	When kill csgo and wait 0 second
	Then ITSlast mode is ISTD
	Then ITSCurrent mode is IEPM
	Then check switch type is auto

@ITS5DriverFunctionDC
Scenario: VAN17534_TestStep15_check ITSMode
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	Then ITSlast mode is ISTD
	Then ITSCurrent mode is IBSM 
	Then check switch type is auto

@ITS5DriverFunctionDC
Scenario: VAN17534_TestStep17_check ITSMode
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	Then ITSlast mode is ISTD
	Then ITSCurrent mode is IBSM 
	Then check switch type is auto

@ITS5DriverFunction
Scenario: VAN17534_TestStep18_check ITSMode
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	When change ITS mode to ICM via Vantage
	When change machine to TENT mode
	Then check last mode is STD
	Then check current mode is TENT
	Then check switch type is auto

@ITS5DriverFunction
Scenario: VAN17534_TestStep19_check ITSMode
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	When change ITS mode to ICM via Vantage
	When change machine to TENT mode
	When change machine to PAD mode
	Then check last mode is TENT
	Then check current mode is PAD
	Then check switch type is AUTO

@ITS5DriverFunction
Scenario: VAN17534_TestStep20_check ITSMode
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	When change ITS mode to ICM via Vantage
	When change machine to TENT mode
	When change machine to PAD mode
	Given launch toolbar
	Given change ITS mode to EPM via Toolbar
	Then check last mode is PAD
	Then check current mode is EPM
	Then check switch type is manual

@ITS5DriverFunction
Scenario: VAN17534_TestStep21_check ITSMode
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	When change ITS mode to ICM via Vantage
	When change machine to TENT mode
	When change machine to PAD mode
	Given launch toolbar
	Given change ITS mode to EPM via Toolbar
	When change machine to NB mode
	Then check current mode is EPM











	





	

