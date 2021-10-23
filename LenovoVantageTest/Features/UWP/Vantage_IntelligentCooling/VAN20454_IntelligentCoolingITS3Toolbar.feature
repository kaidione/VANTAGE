@ITSToolbarCase
Feature: VAN20454_ITS3ToolbarTestcase
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-20454
	Author ：Xiaoxiong Li

@ITS3toolbar_20454
Scenario:VAN20454_TestStep01_select Intelligent Cooling on toolbar check button
	When The user connect or disconnect WiFi on lenovo
	Given launch toolbar	
	Given change ITS mode to Auto via Toolbar
	Then ITS Auto is selected in Toolbar

@ITS3toolbar_20454
Scenario:VAN20454_TestStep02_check icon clear
	Given launch toolbar
	Then Take Screen Shot 02UI in 20454 under ITSScreenShotResult

@ITS3toolbar_20454
Scenario:VAN20454_TestStep03_check Tip Location
	Given launch toolbar
	Given switch ITS Mode 	
	Given change ITS mode to Auto via Toolbar
	Then Take screen shot 03UI in 20454 under ITSScreenShotResult after 0 seconds

@ITS3toolbar_20454
Scenario:VAN20454_TestStep04_check Tip Text
	Given launch toolbar
	Given switch ITS Mode 	
	Given change ITS mode to Auto via Toolbar
	Then Take screen shot 04UI in 20454 under ITSScreenShotResult after 0 seconds

@ITS3toolbar_20454
Scenario:VAN20454_TestStep05_check vantage ITS Mode
	Given Go to Power Page
	Then vantage ITS mode is on 

@ITS3toolbar_20454
Scenario:VAN20454_TestStep06_turnoff Intelligent Cooling check toolbar ITS Mode
	Given Go to Power Page
	Given turn off Intelligent Cooling
	Given launch toolbar	
	Then ITS Perf is selected in Toolbar

@ITS3toolbar_20454
Scenario:VAN20454_TestStep07_select Performance check toolbar ITS mode
	Given launch toolbar	
	Given switch ITS Mode 
	Given change ITS mode to Perf via Toolbar
	Then ITS Perf is selected in Toolbar
	Then Take Screen Shot 07UI in 20454 under ITSScreenShotResult

@ITS3toolbar_20454
Scenario:VAN20454_TestStep08_check icon clear
	Given launch toolbar
	Then Take Screen Shot 08UI in 20454 under ITSScreenShotResult

@ITS3toolbar_20454
Scenario:VAN20454_TestStep09_check Tip Text
	Given launch toolbar
	Given switch ITS Mode
	Given change ITS mode to Perf via Toolbar
	Then Take screen shot 09UI in 20454 under ITSScreenShotResult after 0 seconds

@ITS3toolbar_20454
Scenario:VAN20454_TestStep10_check vantage ITS mode
	Given launch toolbar	
	Given switch ITS Mode 
	Given change ITS mode to Perf via Toolbar
	Given Go to Power Page
	Then Performance is on in vantage

@ITS3toolbar_20454
Scenario:VAN20454_TestStep11_check toolbar ITS mode
	Given Go to Power Page
	Given turn off Intelligent Cooling
	Given click Cool & quiet 
	Given launch toolbar
	Then ITS C&Q is selected in Toolbar
	Then Take Screen Shot 11UI in 20454 under ITSScreenShotResult

@ITS3toolbar_20454
Scenario:VAN20454_TestStep12_check toolbar ITS mode
	Given launch toolbar
	Then ITS C&Q is selected in Toolbar
	Then Take Screen Shot 12UI in 20454 under ITSScreenShotResult

@ITS3toolbar_20454
Scenario:VAN20454_TestStep13_check icon clear
	Given launch toolbar
	Then Take Screen Shot 13UI in 20454 under ITSScreenShotResult

@ITS3toolbar_20454
Scenario:VAN20454_TestStep14_check Tip Text
	Given launch toolbar
	Given change ITS mode to C&Q via Toolbar
	Then ITS C&Q is selected in Toolbar
	Then Take screen shot 14UI in 20454 under ITSScreenShotResult after 0 seconds

@ITS3toolbar_20454
Scenario:VAN20454_TestStep15_check vantage ITS mode
	Given Go to Power Page
	Then  Cool & quiet is on in vantage

@ITS3toolbar_20454
Scenario:VAN20454_TestStep16_turn on Intelligent cooling check toolbar mode
	Given Go to Power Page
	Given turn on Intelligent Cooling
	Given launch toolbar
	Then ITS Auto is selected in Toolbar

@ITS3toolbar_20454
Scenario:VAN20454_TestStep17_select Intelligent cooling check eventlog
	Given launch toolbar
	Given switch ITS Mode
	Given delete eventlog
	Given change ITS mode to Auto via Toolbar
	When wait 5 seconds
	Then Check "Intelligent_Cooling" Eventlog for "ITS3"

@ITS3toolbar_20454
Scenario:VAN20454_TestStep18_select Performance check eventlog
	Given launch toolbar
	Given delete eventlog
	Given change ITS mode to Perf via Toolbar
	When wait 5 seconds
	Then Check "Performance" Eventlog for "ITS3"

@ITS3toolbar_20454
Scenario:VAN20454_TestStep19_select Cool & quiet check eventlog
	Given launch toolbar
	Given change ITS mode to C&Q via Toolbar
	Given switch ITS Mode
	Given delete eventlog
	Given change ITS mode to C&Q via Toolbar
	When wait 5 seconds
	Then Check "Cool_Quiet" Eventlog for "ITS3"

@ITS3toolbar_20454
Scenario:VAN20454_TestStep20_check ITS3 heartbeat eventlog
	Given delete eventlog
	Given start heartbeat
	Then Read "ITS3" Heartbeat Eventlog

@ITS3toolbar_20454
Scenario:VAN20454_TestStep21_change DPI check Button icon display clear reasonable layout not beyond the border
	Given Change DPI to 100
	Given launch toolbar
	Then Take Screen Shot 2101UI in 20454 under ITSScreenShotResult
	Given Change DPI to 125
	Given launch toolbar
	Then Take Screen Shot 2102UI in 20454 under ITSScreenShotResult
	Given Change DPI to 150
	Given launch toolbar
	Then Take Screen Shot 2103UI in 20454 under ITSScreenShotResult
	Given Change DPI to 175
	Given launch toolbar
	Then Take Screen Shot 2104UI in 20454 under ITSScreenShotResult
	Given Change DPI to recommend

@ITS3toolbar_20454
Scenario: VAN20454_TestStep22__change resolution check Button icon display clear reasonable layout not beyond the border
	Given change resolution 1920 to 1080
	Given launch toolbar
	Then Take Screen Shot 2201UI in 20454 under ITSScreenShotResult
	Given change resolution 1600 to 1900
	Given launch toolbar
	Then Take Screen Shot 2202UI in 20454 under ITSScreenShotResult
	Given change resolution 1280 to 1024
	Given launch toolbar
	Then Take Screen Shot 2203UI in 20454 under ITSScreenShotResult
	Given change resolution 1280 to 720
	Given launch toolbar
	Then Take Screen Shot 2204UI in 20454 under ITSScreenShotResult
	Given change resolution 1920 to 1080