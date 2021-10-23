@ITSToolbarCase
Feature: VAN28158_ITS4ToolbarTestcaseNextWindows
	Test Case：https://jira.tc.lenovo.com/browse/VAN-28158
	Author ：Yang Liu

Background: 
	When Current Machine OS is "more" than "21354"

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep01_launch toolbar check button displays same as Vantage
	Given turn on narrator
	Given Go to Power Page
	Given jump to power smart settings section
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 01UI in 28158 under ITSScreenShotResult

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep02_Check the ITS button loop
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 0201UI in 28158 under ITSScreenShotResult
	Given switch ITS Mode 
	Then Take Screen Shot 0202UI in 28158 under ITSScreenShotResult
	Given switch ITS Mode 
	Then Take Screen Shot 0203UI in 28158 under ITSScreenShotResult
	Given switch ITS Mode 
	Then Take Screen Shot 0204UI in 28158 under ITSScreenShotResult
	Given switch ITS Mode 

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep03_select Intelligent Cooling The button display Intelligent Cooling statue
	Given turn on narrator
	Given Launch Toolbar On NewOS	
	Given change ITS mode to ICM via Toolbar
	Then ITS ICM is selected in Toolbar

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep04_select Intelligent Cooling The icon display is clear
	Given Launch Toolbar On NewOS	
	Given change ITS mode to ICM via Toolbar
	Then Take screen shot 04UI in 28158 under ITSScreenShotResult after 0 seconds

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep05_select Intelligent Cooling check button tip location
	Given Launch Toolbar On NewOS
	Given switch ITS Mode 	
	Given change ITS mode to ICM via Toolbar
	Then Take screen shot 05UI in 28158 under ITSScreenShotResult after 0 seconds

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep06_select Intelligent Cooling check button tip location
	Given Launch Toolbar On NewOS	
	Given switch ITS Mode 	
	Given change ITS mode to ICM via Toolbar
	Then Take screen shot 06UI in 28158 under ITSScreenShotResult after 0 seconds

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep07_select Intelligent Cooling check vantageITS mode
	Given Launch Toolbar On NewOS	
	Given change ITS mode to ICM via Toolbar
	Given Go to Power Page
	Given Click Dashboard Link
	Given Go to Power Page
	Then Vantage Intelligent Cooling Mode On

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep08_select Extreme Performance check toolbar ITS mode
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Launch Toolbar On NewOS	
	Then ITS EPM is selected in Toolbar

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep09_select Extreme Performance check toolbar button mode
	Given Launch Toolbar On NewOS	
	Given change ITS mode to EPM via Toolbar
	Then ITS EPM is selected in Toolbar

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep10_select Extreme Performance check icon
	Given Launch Toolbar On NewOS	
	Given change ITS mode to EPM via Toolbar
	Then Take screen shot 10UI in 28158 under ITSScreenShotResult after 0 seconds

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep11_select Extreme Performance check tip text
	Given Launch Toolbar On NewOS	
	Given switch ITS Mode 	
	Given change ITS mode to EPM via Toolbar
	Then Take screen shot 11UI in 28158 under ITSScreenShotResult after 0 seconds

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep12_select Extreme Performance check vantage ITS mode
	Given Launch Toolbar On NewOS	
	Given change ITS mode to EPM via Toolbar
	Given Go to Power Page
	Then Extreme Performance is on

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep13_select Battery saving in vantage check toolbar button mode
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to BSM via Vantage
	Given Launch Toolbar On NewOS	
	Then ITS BSM is selected in Toolbar

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep14_select Battery saving on toolbar check toolbar button 
	Given Launch Toolbar On NewOS	
	Given change ITS mode to BSM via Toolbar
	Then ITS BSM is selected in Toolbar

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep15_select Battery saving on toolbar check icon display is clear
	Given Launch Toolbar On NewOS	
	Given change ITS mode to BSM via Toolbar
	Then Take screen shot 15UI in 28158 under ITSScreenShotResult after 0 seconds

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep16_select Battery saving on toolbar check tip text
	Given Launch Toolbar On NewOS	
	Given switch ITS Mode 	
	Given change ITS mode to BSM via Toolbar
	Then Take screen shot 16UI in 28158 under ITSScreenShotResult after 0 seconds

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep17_select Battery saving on toolbar check ITS vantage mode
	Given Launch Toolbar On NewOS	
	Given change ITS mode to BSM via Toolbar
	Given Go to Power Page
	Then  Battery saving is on

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep18_select  Intelligent Cooling in vantage check ITS toolbar mode 
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Launch Toolbar On NewOS	
	Then ITS ICM is selected in Toolbar

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep19_StopITSService launch toolbar check feature will be hide
	Given Launch Toolbar On NewOS	
	Given change ITS mode to BSM via Toolbar
	Given Stop ITS service
	Given Close toolbar
	Given Launch Toolbar On NewOS	
	Given ITS on toolbar hide
	Then Take Screen Shot 19UI in 28158 under ITSScreenShotResult

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep20_restartITSService launch toolbar check toolbar feature display normal
	Given start ITSService
	Given Close toolbar
	Given Launch Toolbar On NewOS	
	Given ITS on toolbar display normal
	Then Take Screen Shot 20UI in 28158 under ITSScreenShotResult

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep26_select BatterySaving uninstallplugin check vantage and toolbar its fuction
	Given Launch Toolbar On NewOS	
	Given change ITS mode to BSM via Toolbar
	Given moveplugin
	Then vantage ITS mode hide
	Given launch toolbar
	Then Take Screen Shot 26UI in 28158 under ITSScreenShotResult
	Given recoverplugin

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep28_select Intelligent cooling check eventlog
	Given delete eventlog
	Given Launch Toolbar On NewOS	
	Given change ITS mode to ICM via Toolbar
	Given wait 5 seconds
	Then Check "Intelligent_Cooling" Eventlog for "ITS4"

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep29_select Extreme Performance check eventlog
	Given delete eventlog
	Given Launch Toolbar On NewOS	
	Given change ITS mode to EPM via Toolbar
	Given wait 5 seconds
	Then Check "Extreme_Performance" Eventlog for "ITS4"

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep30_select BatterySaving check eventlog
	Given delete eventlog
	Given Launch Toolbar On NewOS	
	Given change ITS mode to BSM via Toolbar
	Given wait 5 seconds
	Then Check "Battery_Saving" Eventlog for "ITS4"

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep31_check ITS4 heartbeat eventlog
	Given delete eventlog
	Given Modify Date "Add" "2" Days
	Given Adjust The System Time To 1 Days Later
	When wait 60 seconds
	Then Read "ITS4" Heartbeat Eventlog
	Given Adjust The System Time To -1 Days Later

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep32_change DPI check Button icon display clear reasonable layout not beyond the border
	Given change resolution 1920 to 1080
	Given Change DPI to 100
	Given launch toolbar
	Then Take Screen Shot 3201UI in 28158 under ITSScreenShotResult
	Given Change DPI to 125
	Given launch toolbar
	Then Take Screen Shot 3202UI in 28158 under ITSScreenShotResult
	Given Change DPI to 150
	Given launch toolbar
	Then Take Screen Shot 3203UI in 28158 under ITSScreenShotResult
	Given Change DPI to 175
	Given launch toolbar
	Then Take Screen Shot 3204UI in 28158 under ITSScreenShotResult
	Given Change DPI to 100

@ITS4ToolbarNewOS
Scenario: VAN28158_TestStep33_change resolution check Button icon display clear reasonable layout not beyond the border
	Given change resolution 1920 to 1080
	Given launch toolbar
	Then Take Screen Shot 3301UI in 28158 under ITSScreenShotResult
	Given change resolution 1600 to 1900
	Given launch toolbar
	Then Take Screen Shot 3302UI in 28158 under ITSScreenShotResult
	Given change resolution 1280 to 1024
	Given launch toolbar
	Then Take Screen Shot 3303UI in 28158 under ITSScreenShotResult
	Given change resolution 1280 to 720
	Given launch toolbar
	Then Take Screen Shot 3304UI in 28158 under ITSScreenShotResult
	Given change resolution 2560 to 1080

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep34_Hover ITS Intelligent cooling icon shows a tip
	Given Launch Toolbar On NewOS	
	Given change ITS mode to BSM via Toolbar
	Given switch ITS Mode
	Given hover ITS icon in toolbar
	Then Take screen shot 34UI in 28158 under ITSScreenShotResult after 0 seconds

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep35_Hover ITS Extreme Performance icon shows a tip
	Given Launch Toolbar On NewOS	
	Given change ITS mode to ICM via Toolbar
	Given switch ITS Mode
	Given hover ITS icon in toolbar
	Then Take screen shot 35UI in 28158 under ITSScreenShotResult after 0 seconds

@ITS4ToolbarNewOS
Scenario:VAN28158_TestStep36_Hover ITS Battery saving icon shows a tip
	Given Launch Toolbar On NewOS	
	Given change ITS mode to EPM via Toolbar
	Given switch ITS Mode
	Given hover ITS icon in toolbar
	Then Take screen shot 36UI in 28158 under ITSScreenShotResult after 0 seconds
