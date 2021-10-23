Feature: VAN17592_IntelligentCoolingITS5ToolbarMetrics
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17592
	Developer: Huajie

@ITS5DriverToolbarMetrics
Scenario: VAN17592_TestStep01_change from ISTD to EP via Vantage UI
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	When wait 45 seconds
	Given delete eventlog
	When change ITS mode to EPM via Vantage
	When get unix time now
	When wait 45 seconds
	Then check eventlog switch type is FNQ 
	Then check eventlog last mode is ISTD 
	Then check eventlog current mode is EP 
	Then check eventlog time is ok

@ITS5DriverToolbarMetrics
Scenario: VAN17592_TestStep02_change from ISTD to BS via Toolbar
	When launch toolbar
	Given change ITS mode to ICM via Toolbar
	When wait 45 seconds
	Given delete eventlog
	Given change ITS mode to BSM via Toolbar
	When get unix time now
	When wait 45 seconds
	Then check eventlog switch type is TRAY 
	Then check eventlog last mode is ISTD 
	Then check eventlog current mode is BS
	Then check eventlog time is ok
	When Close toolbar

@ITS5DriverToolbarMetrics
Scenario: VAN17592_TestStep03_change from ISTD to EP via Vantage UI
	Given delete eventlog
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	When get unix time now
	When wait 45 seconds
	Then check eventlog switch type is FNQ 
	Then check eventlog last mode is BS 
	Then check eventlog current mode is ISTD 
	Then check eventlog time is ok

@ITS5DriverToolbarMetrics
Scenario: VAN17592_TestStep04_run ie and change to AQM
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

@ITS5DriverToolbarMetrics
Scenario: VAN17592_TestStep05_close ie and change to ISTD
	Given delete eventlog
	When kill iexplore and wait 60 second 
	When get unix time now
	When wait 45 seconds
	Then check eventlog switch type is AUTO 
	Then check eventlog last mode is IAQ 
	Then check eventlog current mode is ISTD 
	Then check eventlog time is ok for APMAQM

@ITS5DriverToolbarMetrics
Scenario: VAN17592_TestStep06_run dnf and change to APM
	Given delete eventlog
	When open DNF and keep 30s
	When get unix time now
	When wait 45 seconds
	Then check eventlog switch type is AUTO 
	Then check eventlog last mode is ISTD 
	Then check eventlog current mode is IAP 
	Then check eventlog time is ok for APMAQM

@ITS5DriverToolbarMetrics
Scenario: VAN17592_TestStep07_kill dnf and change to ITSD
	Given delete eventlog
	When kill Client and wait 60 second 
	When get unix time now
	When wait 45 seconds
	Then check eventlog switch type is AUTO 
	Then check eventlog last mode is IAP 
	Then check eventlog current mode is ISTD 
	Then check eventlog time is ok for APMAQM

@ITS5DriverToolbarMetrics
Scenario: VAN17592_TestStep08_run csgo and change to IEPM
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	Given Turn on auto-transition
	Given run csgo
	Given delete eventlog
	When wait 60 seconds
	Then check eventlog switch type is AUTO 
	Then check eventlog last mode is IAP 
	Then check eventlog current mode is iEPM 

@ITS5DriverToolbarMetrics
Scenario: VAN17592_TestStep09_kill csgo and change to ITSD
	Given delete eventlog
	When kill csgo and wait 60 second 
	When wait 45 seconds
	Then check eventlog switch type is AUTO 
	Then check eventlog last mode is iEPM 
	Then check eventlog current mode is ISTD 

@ITS5DriverToolbarMetrics_iBSM
Scenario: VAN17592_TestStep10_change mode to IBSM
	Given DC Condition(Connect the Adapter)
	Given delete eventlog
	Given lever less than 30
	When wait 45 seconds
	Then check eventlog switch type is AUTO 
	Then check eventlog last mode is ISTD 
	Then check eventlog current mode is iBSM 

@ITS5DriverToolbarMetrics_iBSM
Scenario: VAN17592_TestStep12_change from IBSM to ISTD
	Given AC Condition(Connect the Adapter)
	Given delete eventlog
	When wait 45 seconds
	Then check eventlog switch type is AUTO 
	Then check eventlog last mode is iBSM 
	Then check eventlog current mode is ISTD 

@ITS5DriverToolbarMetrics
Scenario: VAN17592_TestStep13_change machine to tent mode
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

@ITS5DriverToolbarMetrics
Scenario: VAN17592_TestStep14_change machine to pad mode
	Given delete eventlog
	When change machine to PAD mode
	When get unix time now
	When wait 45 seconds
	Then check eventlog switch type is AUTO 
	Then check eventlog last mode is IMYHS 
	Then check eventlog current mode is IMYHP 
	Then check eventlog time is ok

@ITS5DriverToolbarMetrics
Scenario: VAN17592_TestStep15_keep pad and change to EP mode
	Given delete eventlog
	When launch toolbar
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	When get unix time now
	When wait 45 seconds
	Then check eventlog switch type is FNQ 
	Then check eventlog last mode is IMYHP 
	Then check eventlog current mode is EP 
	Then check eventlog time is ok

@ITS5DriverToolbarMetrics
Scenario: VAN17592_TestStep16_change machine to NB mode and no eventlog 
	When change machine to NB mode
	When wait 45 seconds
	Then check eventlog switch type is FNQ 
	Then check eventlog last mode is IMYHP 
	Then check eventlog current mode is EP 


