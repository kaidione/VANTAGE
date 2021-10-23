Feature: VAN17423_IntelligentCoolingITS4ToolbarMetrics
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17423
	Developer: Yang Liu

@ITS4DriverToolbarMetrics
Scenario: VAN17423_TestStep02_there should no data send to event viewer by toolbar
	Given delete eventlog
	When change machine to NB mode
	When unpin toolbar on Taskbar settings
	Given Go to Power Page
	When change ITS mode to BSM via Vantage
	When change ITS mode to EPM via Vantage
	When wait 45 seconds
	Then Check Event Log Content Is Empty

@ITS4DriverToolbarMetrics
Scenario: VAN17423_TestStep03_change from EP to BS via Vantage UI
	When pin toolbar on Taskbar settings
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	When wait 45 seconds
	Given delete eventlog
	When change ITS mode to BSM via Vantage
	When get unix time now
	When wait 45 seconds
	Then check eventlog switch type is FNQ 
	Then check eventlog last mode is EP 
	Then check eventlog current mode is BS 
	Then check eventlog time is ok

@ITS4DriverToolbarMetrics
Scenario: VAN17423_TestStep04_change from BS to EP via Vantage UI
	Given delete eventlog
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	When get unix time now
	When wait 45 seconds
	Then check eventlog switch type is FNQ 
	Then check eventlog last mode is BS 
	Then check eventlog current mode is EP 
	Then check eventlog time is ok

@ITS4DriverToolbarMetrics
Scenario: VAN17423_TestStep05_change from EP to ISTD via Vantage UI
	Given delete eventlog
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	When get unix time now
	When wait 45 seconds
	Then check eventlog switch type is FNQ 
	Then check eventlog last mode is EP 
	Then check eventlog current mode is ISTD 
	Then check eventlog time is ok

@ITS4DriverToolbarMetrics
Scenario: VAN17423_TestStep06_run ie and change to AQM
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	When close lenovo vantage
	Given delete eventlog
	When open ie and keep 30s
	When get unix time now
	When wait 45 seconds
	Then check eventlog switch type is AUTO 
	Then check eventlog last mode is ISTD 
	Then check eventlog current mode is IAQ
	Then check eventlog time is ok for APMAQM

@ITS4DriverToolbarMetrics
Scenario: VAN17423_TestStep07_close ie and change to ISTD
	Given delete eventlog
	When kill iexplore and wait 30 second 
	When get unix time now
	When wait 45 seconds
	Then check eventlog switch type is AUTO 
	Then check eventlog last mode is IAQ 
	Then check eventlog current mode is ISTD 
	Then check eventlog time is ok for APMAQM

@ITS4DriverToolbarMetrics
Scenario: VAN17423_TestStep08_run dnf and change to IAP
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	When close lenovo vantage
	Given delete eventlog
	When open DNF and keep 30s
	When get unix time now
	When wait 45 seconds
	Then check eventlog switch type is AUTO 
	Then check eventlog last mode is ISTD 
	Then check eventlog current mode is IAP 
	Then check eventlog time is ok for APMAQM

@ITS4DriverToolbarMetrics
Scenario: VAN17423_TestStep09_kill dnf and change to ITSD
	Given delete eventlog
	When kill Client and wait 30 second 
	When get unix time now
	When wait 45 seconds
	Then check eventlog switch type is AUTO 
	Then check eventlog last mode is IAP 
	Then check eventlog current mode is ISTD 
	Then check eventlog time is ok for APMAQM

@ITS4DriverToolbarMetrics
Scenario: VAN17423_TestStep10_run farm and change to IAP
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	When close lenovo vantage
	Given delete eventlog
	When open farmgame and keep 30s
	When get unix time now
	When wait 45 seconds
	Then check eventlog switch type is AUTO 
	Then check eventlog last mode is ISTD 
	Then check eventlog current mode is IAP 
	Then check eventlog time is ok for APMAQM

@ITS4DriverToolbarMetrics
Scenario: VAN17423_TestStep11_kill farm and change to ITSD
	Given delete eventlog
	When kill farmheroessaga and wait 30 second 
	When get unix time now
	When wait 45 seconds
	Then check eventlog switch type is AUTO 
	Then check eventlog last mode is IAP 
	Then check eventlog current mode is ISTD 
	Then check eventlog time is ok for APMAQM 

@ITS4DriverToolbarMetrics
Scenario: VAN17423_TestStep12_change machine to tent mode
	Given delete eventlog
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	When change machine to TENT mode
	When get unix time now
	When wait 45 seconds
	Then check eventlog switch type is AUTO 
	Then check eventlog last mode is ISTD 
	Then check eventlog current mode is IMYHS
	Then check eventlog time is ok

@ITS4DriverToolbarMetrics
Scenario: VAN17423_TestStep13_change machine to pad mode
	Given delete eventlog
	When change machine to PAD mode
	When get unix time now
	When wait 45 seconds
	Then check eventlog switch type is AUTO 
	Then check eventlog last mode is IMYHS 
	Then check eventlog current mode is IMYHP 
	Then check eventlog time is ok

@ITS4DriverToolbarMetrics
Scenario: VAN17423_TestStep14_keep pad and change to BS mode
	Given delete eventlog
	When launch toolbar
	Given change ITS mode to BSM via Toolbar
	When get unix time now
	When wait 45 seconds
	Then check eventlog switch type is TRAY 
	Then check eventlog last mode is IMYHP 
	Then check eventlog current mode is BS 
	Then check eventlog time is ok

@ITS4DriverToolbarMetrics
Scenario: VAN17423_TestStep15_change machine to NB mode and no eventlog 
	When change machine to NB mode
	When wait 45 seconds
	Then check eventlog switch type is TRAY 
	Then check eventlog last mode is IMYHP 
	Then check eventlog current mode is BS 
