@ITSToolbarCase
Feature: VAN20458_IntelligentCoolingITS5Toolbar
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-20458
	Author ：Xiaoxiong Li

Background: 
    Given The Machine support Intelligent Cooling for ideapad ITS Five
	Given Read Intelligent cooling run mark for all test case

@ITS5toolbar_20458
Scenario:VAN20458_TestStep02_launch toolbar check button displays same as Vantage
	Given Go to Power Page
	Given jump to power smart settings section
	Given launch toolbar
	Then Take Screen Shot 02UI in 20458 under ITSScreenShotResult

@ITS5toolbar_20458
Scenario:VAN20458_TestStep03_Check the ITS button loop
	Given launch toolbar
	Then Take Screen Shot 0301UI in 20458 under ITSScreenShotResult
	Given switch ITS Mode 
	Then Take Screen Shot 0302UI in 20458 under ITSScreenShotResult
	Given switch ITS Mode 
	Then Take Screen Shot 0303UI in 20458 under ITSScreenShotResult
	Given switch ITS Mode 
	Then Take Screen Shot 0304UI in 20458 under ITSScreenShotResult
	Given switch ITS Mode 

@ITS5toolbar_20458
Scenario:VAN20458_TestStep04_select Intelligent Cooling The button display Intelligent Cooling statue
	Given launch toolbar	
	Given change ITS mode to ICM via Toolbar
	Then Take Screen Shot 04UI in 20458 under ITSScreenShotResult
	Then ITS ICM is selected in Toolbar

@ITS5toolbar_20458
Scenario:VAN20458_TestStep05_select Intelligent Cooling The icon display is clear
	Given launch toolbar	
	Given change ITS mode to ICM via Toolbar
	Then Take Screen Shot 05UI in 20458 under ITSScreenShotResult

@ITS5toolbar_20458
Scenario:VAN20458_TestStep06_select Intelligent Cooling check button tip location
	Given launch toolbar
	Given switch ITS Mode 	
	Given change ITS mode to ICM via Toolbar
	Then Take screen shot 06UI in 20458 under ITSScreenShotResult after 0 seconds

@ITS5toolbar_20458
Scenario:VAN20458_TestStep07_select Intelligent Cooling check button tip location
	Given launch toolbar	
	Given switch ITS Mode 	
	Given change ITS mode to ICM via Toolbar
	Then Take screen shot 07UI in 20458 under ITSScreenShotResult after 0 seconds

@ITS5toolbar_20458
Scenario:VAN20458_TestStep08_select Intelligent Cooling check vantageITS mode
	Given launch toolbar	
	Given change ITS mode to ICM via Toolbar
	Given Go to Power Page
	Then Vantage Intelligent Cooling Mode On

@ITS5toolbar_20458
Scenario:VAN20458_TestStep09_select Extreme Performance check toolbar ITS mode
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given launch toolbar	
	Then Take Screen Shot 09UI in 20458 under ITSScreenShotResult

@ITS5toolbar_20458
Scenario:VAN20458_TestStep10_select Extreme Performance check toolbar button mode
	Given launch toolbar	
	Given change ITS mode to EPM via Toolbar
	Then ITS EPM is selected in Toolbar
	Then Take Screen Shot 10UI in 20458 under ITSScreenShotResult

@ITS5toolbar_20458
Scenario:VAN20458_TestStep11_select Extreme Performance check icon
	Given launch toolbar	
	Given change ITS mode to EPM via Toolbar
	Then Take Screen Shot 11UI in 20458 under ITSScreenShotResult

@ITS5toolbar_20458
Scenario:VAN20458_TestStep12_select Extreme Performance check tip text
	Given launch toolbar	
	Given switch ITS Mode 	
	Given change ITS mode to EPM via Toolbar
	Then Take screen shot 12UI in 20458 under ITSScreenShotResult after 0 seconds

@ITS5toolbar_20458
Scenario:VAN20458_TestStep13_select Extreme Performance check vantage ITS mode
	Given launch toolbar	
	Given change ITS mode to EPM via Toolbar
	Given Go to Power Page
	Then Extreme Performance is on

@ITS5toolbar_20458
Scenario:VAN20458_TestStep14_select Battery saving in vantage check toolbar button mode
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to BSM via Vantage
	Given launch toolbar	
	Then ITS BSM is selected in Toolbar
	Then Take Screen Shot 14UI in 20458 under ITSScreenShotResult

@ITS5toolbar_20458
Scenario:VAN20458_TestStep15_select Battery saving on toolbar check toolbar button 
	Given launch toolbar	
	Given change ITS mode to BSM via Toolbar
	Then Take Screen Shot 15UI in 20458 under ITSScreenShotResult

@ITS5toolbar_20458
Scenario:VAN20458_TestStep16_select Battery saving on toolbar check icon display is clear
	Given launch toolbar	
	Given change ITS mode to BSM via Toolbar
	Then Take Screen Shot 16UI in 20458 under ITSScreenShotResult

@ITS5toolbar_20458
Scenario:VAN20458_TestStep17_select Battery saving on toolbar check tip text
	Given launch toolbar	
	Given switch ITS Mode 	
	Given change ITS mode to BSM via Toolbar
	Then Take screen shot 17UI in 20458 under ITSScreenShotResult after 0 seconds

@ITS5toolbar_20458
Scenario:VAN20458_TestStep18_select Battery saving on toolbar check ITS vantage mode
	Given launch toolbar	
	Given change ITS mode to BSM via Toolbar
	Given Go to Power Page
	Then  Battery saving is on

@ITS5toolbar_20458
Scenario:VAN20458_TestStep19_select Intelligent Cooling in vantage check ITS toolbar mode 
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	When change ITS mode to ICM via Vantage
	Given launch toolbar	
	Then Take Screen Shot 19UI in 20458 under ITSScreenShotResult

@ITS5toolbar_20458
Scenario:VAN20458_TestStep20_StopITSService launch toolbar check feature will be hide
	Given launch toolbar	
	Given change ITS mode to BSM via Toolbar
	Given Stop ITS service
	Given launch toolbar	
	Given launch toolbar	
	Given ITS on toolbar hide
	Then Take Screen Shot 20UI in 20458 under ITSScreenShotResult

@ITS5toolbar_20458
Scenario:VAN20458_TestStep21_restartITSService launch toolbar check toolbar feature display normal
	Given start ITSService
	Given launch toolbar	
	Then Take Screen Shot 21UI in 20458 under ITSScreenShotResult

@ITS5toolbar_20458
Scenario:VAN20458_TestStep27_select BatterySaving uninstallplugin check vantage and toolbar its fuction
	Given launch toolbar	
	Given change ITS mode to BSM via Toolbar
	Given moveplugin
	Then vantage ITS mode hide
	Given launch toolbar
	Then Toolbar ITS mode show
	Given recoverplugin

@ITS5toolbar_20458
Scenario:VAN20458_TestStep28_updateplugin check ITS mode feature display follow the user settings
	Given recoverplugin
	Given launch toolbar	
	Given updateplugin
	Given Restart IMC Service
	Then Toolbar ITS mode show
	Then Take Screen Shot 28UI in 20458 under ITSScreenShotResult

@ITS5toolbar_20458
Scenario:VAN20458_TestStep30_select Intelligent cooling check eventlog
	Given launch toolbar
	Given switch ITS Mode	
	Given recoverplugin
	Given delete eventlog
	Given change ITS mode to ICM via Toolbar
	Given Waiting 10 seconds
	Then Check "Intelligent_Cooling" Eventlog for "ITS5"
	When Close toolbar

@ITS5toolbar_20458
Scenario:VAN20458_TestStep31_select Extreme Performance check eventlog
	Given launch toolbar
	Given switch ITS Mode
	Given delete eventlog
	Given change ITS mode to EPM via Toolbar
	Given Waiting 10 seconds
	Then Check "Performance" Eventlog for "ITS5"
	When Close toolbar

@ITS5toolbar_20458
Scenario:VAN20458_TestStep32_select BatterySaving  check eventlog
	Given launch toolbar
	Given switch ITS Mode
	Given delete eventlog
	Given change ITS mode to BSM via Toolbar
	Given Waiting 10 seconds
	Then Check "Battery_Saving" Eventlog for "ITS5"
	When Close toolbar

@ITS5toolbar_20458
Scenario:VAN20458_TestStep33_check ITS3 heartbeat
	Given delete eventlog
	Given start heartbeat
	Then Read "ITS5" Heartbeat Eventlog

@ITS5toolbar_20458
Scenario:VAN20458_TestStep35_change DPI check Button icon display clear reasonable layout not beyond the border
	Given Change DPI to 100
	Given launch toolbar
	Then Take Screen Shot 3501UI in 20458 under ITSScreenShotResult
	Given Change DPI to 125
	Given launch toolbar
	Then Take Screen Shot 3502UI in 20458 under ITSScreenShotResult
	Given Change DPI to 150
	Given launch toolbar
	Then Take Screen Shot 3503UI in 20458 under ITSScreenShotResult
	Given Change DPI to 175
	Given launch toolbar
	Then Take Screen Shot 3504UI in 20458 under ITSScreenShotResult
	Given Change DPI to recommend

@ITS5toolbar_20458
Scenario: VAN20458_TestStep36__change resolution check Button icon display clear reasonable layout not beyond the border
	Given change resolution 1920 to 1080
	Given launch toolbar
	Then Take Screen Shot 3601UI in 20458 under ITSScreenShotResult
	Given change resolution 1600 to 1900
	Given launch toolbar
	Then Take Screen Shot 3602UI in 20458 under ITSScreenShotResult
	Given change resolution 1280 to 1024
	Given launch toolbar
	Then Take Screen Shot 3603UI in 20458 under ITSScreenShotResult
	Given change resolution 1280 to 720
	Given launch toolbar
	Then Take Screen Shot 3604UI in 20458 under ITSScreenShotResult
	Given change resolution 2880 to 1800



