@ITSToolbarCase
Feature: VAN20456_IntelligentCoolingITS4Toolbar
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-20456
	Author ：Xiaoxiong Li

@ITS4toolbar_20456
Scenario:VAN20456_TestStep01_launch toolbar check button displays same as Vantage
	Given Go to Power Page
	Given jump to power smart settings section
	Given launch toolbar
	Then Take Screen Shot 01UI in 20456 under ITSScreenShotResult

@ITS4toolbar_20456
Scenario:VAN20456_TestStep02_Check the ITS button loop
	Given launch toolbar
	Then Take Screen Shot 0201UI in 20456 under ITSScreenShotResult
	Given switch ITS Mode 
	Then Take Screen Shot 0202UI in 20456 under ITSScreenShotResult
	Given switch ITS Mode 
	Then Take Screen Shot 0203UI in 20456 under ITSScreenShotResult
	Given switch ITS Mode 
	Then Take Screen Shot 0204UI in 20456 under ITSScreenShotResult
	Given switch ITS Mode 

@ITS4toolbar_20456
Scenario:VAN20456_TestStep03_select Intelligent Cooling The button display Intelligent Cooling statue
	Given launch toolbar	
	Given change ITS mode to ICM via Toolbar
	Then ITS ICM is selected in Toolbar

@ITS4toolbar_20456
Scenario:VAN20456_TestStep04_select Intelligent Cooling The icon display is clear
	Given launch toolbar	
	Given change ITS mode to ICM via Toolbar
	Then Take Screen Shot 04UI in 20456 under ITSScreenShotResult

@ITS4toolbar_20456
Scenario:VAN20456_TestStep05_select Intelligent Cooling check button tip location
	Given launch toolbar
	Given switch ITS Mode 	
	Given change ITS mode to ICM via Toolbar
	Then Take screen shot 05UI in 20456 under ITSScreenShotResult after 0 seconds

@ITS4toolbar_20456
Scenario:VAN20456_TestStep06_select Intelligent Cooling check button tip location
	Given launch toolbar	
	Given switch ITS Mode 	
	Given change ITS mode to ICM via Toolbar
	Then Take screen shot 06UI in 20456 under ITSScreenShotResult after 0 seconds

@ITS4toolbar_20456
Scenario:VAN20456_TestStep07_select Intelligent Cooling check vantageITS mode
	Given launch toolbar	
	Given change ITS mode to ICM via Toolbar
	Given Go to Power Page
	Then Vantage Intelligent Cooling Mode On

@ITS4toolbar_20456
Scenario:VAN20456_TestStep08_select Extreme Performance check toolbar ITS mode
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given launch toolbar	
	Then Take Screen Shot 08UI in 20456 under ITSScreenShotResult

@ITS4toolbar_20456
Scenario:VAN20456_TestStep09_select Extreme Performance check toolbar button mode
	Given launch toolbar	
	Given change ITS mode to EPM via Toolbar
	Then Take Screen Shot 09UI in 20456 under ITSScreenShotResult

@ITS4toolbar_20456
Scenario:VAN20456_TestStep10_select Extreme Performance check icon
	Given launch toolbar	
	Given change ITS mode to EPM via Toolbar
	Then Take Screen Shot 10UI in 20456 under ITSScreenShotResult

@ITS4toolbar_20456
Scenario:VAN20456_TestStep11_select Extreme Performance check tip text
	Given launch toolbar	
	Given switch ITS Mode 	
	Given change ITS mode to EPM via Toolbar
	Then Take screen shot 11UI in 20456 under ITSScreenShotResult after 0 seconds

@ITS4toolbar_20456
Scenario:VAN20456_TestStep12_select Extreme Performance check vantage ITS mode
	Given launch toolbar	
	Given change ITS mode to EPM via Toolbar
	Given Go to Power Page
	Then Extreme Performance is on

@ITS4toolbar_20456
Scenario:VAN20456_TestStep13_select Battery saving in vantage check toolbar button mode
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to BSM via Vantage
	Given launch toolbar	
	Then ITS BSM is selected in Toolbar
	Then Take Screen Shot 13UI in 20456 under ITSScreenShotResult

@ITS4toolbar_20456
Scenario:VAN20456_TestStep14_select Battery saving on toolbar check toolbar button 
	Given launch toolbar	
	Given change ITS mode to BSM via Toolbar
	Then Take Screen Shot 14UI in 20456 under ITSScreenShotResult

@ITS4toolbar_20456
Scenario:VAN20456_TestStep15_select Battery saving on toolbar check icon display is clear
	Given launch toolbar	
	Given change ITS mode to BSM via Toolbar
	Then Take Screen Shot 15UI in 20456 under ITSScreenShotResult

@ITS4toolbar_20456
Scenario:VAN20456_TestStep16_select Battery saving on toolbar check tip text
	Given launch toolbar	
	Given switch ITS Mode 	
	Given change ITS mode to BSM via Toolbar
	Then Take screen shot 16UI in 20456 under ITSScreenShotResult after 0 seconds

@ITS4toolbar_20456
Scenario:VAN20456_TestStep17_select Battery saving on toolbar check ITS vantage mode
	Given launch toolbar	
	Given change ITS mode to BSM via Toolbar
	Given Go to Power Page
	Then  Battery saving is on

@ITS4toolbar_20456
Scenario:VAN20456_TestStep18_select  Intelligent Cooling in vantage check ITS toolbar mode 
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given launch toolbar	
	Then Take Screen Shot 18UI in 20456 under ITSScreenShotResult

@ITS4toolbar_20456
Scenario:VAN20456_TestStep19_StopITSService launch toolbar check feature will be hide
	Given launch toolbar	
	Given change ITS mode to BSM via Toolbar
	Given Stop ITS service
	Given Close toolbar
	Given launch toolbar	
	Given ITS on toolbar hide
	Then Take Screen Shot 19UI in 20456 under ITSScreenShotResult

@ITS4toolbar_20456
Scenario:VAN20456_TestStep20_restartITSService launch toolbar check toolbar feature display normal
	Given start ITSService
	Given launch toolbar	
	Given ITS on toolbar display normal
	Then Take Screen Shot 20UI in 20456 under ITSScreenShotResult

@ITS4toolbar_20456
Scenario:VAN20456_TestStep26_select BatterySaving uninstallplugin check vantage and toolbar its fuction
	Given launch toolbar	
	Given change ITS mode to BSM via Toolbar
	Given moveplugin
	Then vantage ITS mode hide
	Given launch toolbar
	Then Take Screen Shot 26UI in 20456 under ITSScreenShotResult
	Given recoverplugin

@ITS4toolbar_20456
Scenario:VAN20456_TestStep27_updateplugin check ITS mode feature display follow the user settings
	Given launch toolbar	
	Given change ITS mode to BSM via Toolbar
	Given updateplugin
	Then ITS BSM is selected in Toolbar
	Then Take Screen Shot 27UI in 20456 under ITSScreenShotResult

@ITS4toolbar_20456
Scenario:VAN20456_TestStep29_select Intelligent cooling check eventlog
	Given launch toolbar
	Given delete eventlog
	Given change ITS mode to ICM via Toolbar
	Given wait 5 seconds
	Then Check "Intelligent_Cooling" Eventlog for "ITS4"

@ITS4toolbar_20456
Scenario:VAN20456_TestStep30_select Extreme Performance check eventlog
	Given launch toolbar
	Given delete eventlog
	Given change ITS mode to EPM via Toolbar
	Given wait 5 seconds
	Then Check "Extreme_Performance" Eventlog for "ITS4"

@ITS4toolbar_20456
Scenario:VAN20456_TestStep31_select BatterySaving check eventlog
	Given delete eventlog
	Given launch toolbar
	Given change ITS mode to BSM via Toolbar
	Given wait 5 seconds
	Then Check "Battery_Saving" Eventlog for "ITS4"

@ITS4toolbar_20456
Scenario:VAN20456_TestStep32_check ITS4 heartbeat eventlog
	Given delete eventlog
	Given wait 5 seconds
	Given start heartbeat
	Then Read "ITS4" Heartbeat Eventlog

@ITS4toolbar_20456
Scenario:VAN20456_TestStep33_change DPI check Button icon display clear reasonable layout not beyond the border
	Given change resolution 1920 to 1080
	Given Change DPI to 100
	Given launch toolbar
	Then Take Screen Shot 3301UI in 20456 under ITSScreenShotResult
	Given Change DPI to 125
	Given launch toolbar
	Then Take Screen Shot 3302UI in 20456 under ITSScreenShotResult
	Given Change DPI to 150
	Given launch toolbar
	Then Take Screen Shot 3303UI in 20456 under ITSScreenShotResult
	Given Change DPI to 175
	Given launch toolbar
	Then Take Screen Shot 3304UI in 20456 under ITSScreenShotResult
	Given Change DPI to 100

@ITS4toolbar_20456
Scenario: VAN20456_TestStep34_change resolution check Button icon display clear reasonable layout not beyond the border
	Given change resolution 1920 to 1080
	Given launch toolbar
	Then Take Screen Shot 3401UI in 20456 under ITSScreenShotResult
	Given change resolution 1600 to 1900
	Given launch toolbar
	Then Take Screen Shot 3402UI in 20456 under ITSScreenShotResult
	Given change resolution 1280 to 1024
	Given launch toolbar
	Then Take Screen Shot 3403UI in 20456 under ITSScreenShotResult
	Given change resolution 1280 to 720
	Given launch toolbar
	Then Take Screen Shot 3404UI in 20456 under ITSScreenShotResult
	Given change resolution 2560 to 1080