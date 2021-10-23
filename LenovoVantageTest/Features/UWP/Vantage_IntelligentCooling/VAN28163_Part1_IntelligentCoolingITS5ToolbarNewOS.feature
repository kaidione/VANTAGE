@ITSToolbarCase
Feature: VAN28163_Part1_IntelligentCoolingITS5ToolbarNewOS
	Test Case：https://jira.tc.lenovo.com/browse/VAN-28163
	Author ：Wenyang

Background: 
	When Current Machine OS is "more" than "21354"

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep02_launch toolbar check button displays same as Vantage
	Given turn on narrator
	Given Go to Power Page
	Given jump to power smart settings section
	Then Take Screen Shot 0201UI in 28163 under ITSScreenShotResult
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 0202UI in 28163 under ITSScreenShotResult

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep03_Check the ITS button loop
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 0301UI in 28163 under ITSScreenShotResult
	Given switch ITS Mode 
	Then Take Screen Shot 0302UI in 28163 under ITSScreenShotResult
	Given switch ITS Mode 
	Then Take Screen Shot 0303UI in 28163 under ITSScreenShotResult
	Given switch ITS Mode 
	Then Take Screen Shot 0304UI in 28163 under ITSScreenShotResult
	Given switch ITS Mode 

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep04_select Intelligent Cooling The button display Intelligent Cooling statue
	Given turn on narrator
	Given Launch Toolbar On NewOS


	Then ITS ICM is selected in Toolbar

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep05_select Intelligent Cooling The icon display is clear
	Given Launch Toolbar On NewOS	
	Given change ITS mode to ICM via Toolbar
	Then Take Screen Shot 05UI in 28163 under ITSScreenShotResult

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep06_select Intelligent Cooling check button tip location
	Given Launch Toolbar On NewOS
	Given change ITS mode to ICM via Toolbar
	Then Take Screen Shot 06UI in 28163 under ITSScreenShotResult after 0 seconds

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep07_select Intelligent Cooling check button tip text
	Given Launch Toolbar On NewOS	
	Given change ITS mode to ICM via Toolbar
	Then Take Screen Shot 07UI in 28163 under ITSScreenShotResult after 0 seconds

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep08_select Intelligent Cooling check vantage mode
	Given Launch Toolbar On NewOS	
	Given change ITS mode to ICM via Toolbar
	Given Go to Power Page
	Given jump to power smart settings section
	Then Vantage Intelligent Cooling Mode On

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep09_select Extreme Performance check toolbar mode
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Launch Toolbar On NewOS
	Then ITS EPM is selected in Toolbar

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep10_select Extreme Performance The button display Extreme Performance statue
	Given Launch Toolbar On NewOS	
	Given change ITS mode to EPM via Toolbar
	Then ITS EPM is selected in Toolbar

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep11_select Extreme Performance check icon
	Given Launch Toolbar On NewOS	
	Given change ITS mode to EPM via Toolbar
	Then Take Screen Shot 11UI in 28163 under ITSScreenShotResult

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep12_select Extreme Performance check tip text
	Given Launch Toolbar On NewOS	
	Given change ITS mode to EPM via Toolbar
	Then Take Screen Shot 12UI in 28163 under ITSScreenShotResult after 0 seconds

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep13_select Extreme Performance check vantage mode
	Given Launch Toolbar On NewOS	
	Given change ITS mode to EPM via Toolbar
	Given Go to Power Page
	Then Extreme Performance is on

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep14_select Battery saving in vantage check toolbar mode
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to BSM via Vantage
	Given Launch Toolbar On NewOS	
	Then ITS BSM is selected in Toolbar

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep15_select Battery saving on toolbar The button display Battery saving statue
	Given Launch Toolbar On NewOS
	Given change ITS mode to BSM via Toolbar
	Then ITS BSM is selected in Toolbar
