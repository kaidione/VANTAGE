Feature: VAN17168_IntelligentCoolingITS4DPTF
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17168
	Developer: Huajie

@ITS4DPTF
Scenario: VAN17168_TestStep01_0 check priority
	When change machine to NB mode
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	Given Waiting 2 seconds
	When close lenovo vantage
	When open ie and keep 30s
	Then current mode is AQM
	When open DNF and keep 30s
	Then current mode is APM
	When change machine to PAD mode
	Then current mode is PAD
	When change machine to TENT mode
	Then current mode is TENT

@ITS4DPTF
Scenario: VAN17168_TestStep01_1 check priority
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	Then current mode is EPM
	When change ITS mode to BSM via Vantage
	Then current mode is BSM
	When kill iexplore and wait 60 second 
	When kill Client and wait 60 second 
	When change machine to NB mode

@ITS4DPTF
Scenario: VAN17168_TestStep02 run ie and check AQM enabled
	When change machine to NB mode
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	Given Waiting 2 seconds
	When close lenovo vantage
	When open ie and keep 30s
	Then current mode is AQM

@ITS4DPTF
Scenario: VAN17168_TestStep03 kill ie and check AQM disabled
	When kill iexplore and wait 80 second 
	Then current mode is STD

@ITS4DPTF
Scenario: VAN17168_TestStep04_01 run gamelist and check APM enabled
	When open DNF and keep 30s
	Then current mode is APM

@ITS4DPTF
Scenario: VAN17168_TestStep04_02 kill gamelist and check APM disabled
	When kill Client and wait 60 second 
	Then current mode is STD

@ITS4DPTF
Scenario: VAN17168_TestStep05_01 open farmgamelist and check APM enabled
	When close lenovo vantage
	When open farmgame and keep 30s
	Then current mode is APM

@ITS4DPTF
Scenario: VAN17168_TestStep05_02 kill farmgamelist and check APM disabled
	When kill farmheroessaga and wait 60 second 
	Then current mode is STD

@ITS4DPTF
Scenario: VAN17168_TestStep06 check EPM enabled
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	Then current mode is EPM

@ITS4DPTF
Scenario: VAN17168_TestStep07 check BSM enabled
	Given Go to Power Page
	When change ITS mode to BSM via Vantage
	Then current mode is BSM

@ITS4DPTF
Scenario: VAN17168_TestStep08 check MTH disabled
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	Then current mode is STD

@ITS4DPTF
Scenario: VAN17168_TestStep09 check Stand enabled
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	When change machine to Stand mode
	Then current mode is TENT

@ITS4DPTF
Scenario: VAN17168_TestStep10 check TENT enabled
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	When change machine to TENT mode
	Then current mode is TENT

@ITS4DPTF
Scenario: VAN17168_TestStep11 check PAD enabled
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	When change machine to PAD mode
	Then current mode is PAD
	When change machine to NB mode