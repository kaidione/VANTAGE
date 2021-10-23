@ITSToolbarCase
Feature:  VAN28163_Part2_IntelligentCoolingITS5ToolbarNewOS
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-28163
	Author： Huajie

Background: 
	When Current Machine OS is "more" than "21354"

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep16_select Battery saving on toolbar and check icon display is clear
	Given Launch Toolbar On NewOS
	Given change ITS mode to BSM via Toolbar
	Then ITS BSM is selected in Toolbar
	Then Take Screen Shot 16UI in 28163 under ITSScreenShotResult
	When Close toolbar

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep17_select Battery saving on toolbar check tip text
	Given launch toolbar	
	Given Launch Toolbar On NewOS
	Given change ITS mode to BSM via Toolbar
	Then ITS BSM is selected in Toolbar
	Then Take screen shot 17UI in 28163 under ITSScreenShotResult after 0 seconds
	When Close toolbar

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep18_select Battery saving on toolbar check ITS vantage mode
	Given Launch Toolbar On NewOS
	Given switch ITS Mode 	
	Given change ITS mode to BSM via Toolbar
	Given Go to Power Page
	Then  Battery saving is on
	When Close toolbar

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep19_select Intelligent Cooling in vantage check ITS toolbar mode 
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Launch Toolbar On NewOS
	Then ITS ICM is selected in Toolbar
	When Close toolbar

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep20_Stop ITS Service launch toolbar and check feature will be hide
	Given Launch Toolbar On NewOS
	Given change ITS mode to BSM via Toolbar
	Given Stop ITS service
	When Close toolbar	
	Given Launch Toolbar On NewOS
	When Close toolbar
	Then ITS on toolbar hide

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep21_restart ITS Service launch toolbar check toolbar feature display normal
	Given start ITSService
	Given Launch Toolbar On NewOS
	Then ITS ICM is selected in Toolbar
	When Close toolbar

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep27_delete notebookplugin and check ITS mode show normally
	Given moveplugin
	Given Launch Toolbar On NewOS
	Then ITS ICM is selected in Toolbar
	When Close toolbar
	Given recoverplugin

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep30_select Intelligent cooling check eventlog
	Given recoverplugin
	Given delete eventlog
	Given Launch Toolbar On NewOS
	Given switch ITS Mode
	Given change ITS mode to ICM via Toolbar
	Given Waiting 10 seconds
	Then Check "Intelligent_Cooling" Eventlog for "ITS5"
	When Close toolbar

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep31_select Extreme Performance check eventlog
	Given delete eventlog
	Given Launch Toolbar On NewOS
	Given switch ITS Mode
	Given change ITS mode to EPM via Toolbar
	Given Waiting 10 seconds
	Then Check "Performance" Eventlog for "ITS5"
	When Close toolbar

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep32_select BatterySaving check eventlog
	Given delete eventlog
	Given Launch Toolbar On NewOS
	Given switch ITS Mode
	Given change ITS mode to BSM via Toolbar
	Given Waiting 10 seconds
	Then Check "Battery_Saving" Eventlog for "ITS5"
	When Close toolbar

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep33_check ITS5 heartbeat
	Given delete eventlog
	Given Modify Date "Add" "2" Days
	Given Adjust The System Time To 1 Days Later
	When wait 60 seconds
	Then Read "ITS5" Heartbeat Eventlog
	Given Adjust The System Time To -1 Days Later
	When Close toolbar

@ITS5ToolbarNewOS
Scenario:VAN28163_TestStep35_change DPI check Button icon display clear reasonable layout not beyond the border
	Given Change DPI to 100
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 3501UI in 28163 under ITSScreenShotResult
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 3502UI in 28163 under ITSScreenShotResult
	Given Change DPI to 150
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 3503UI in 28163 under ITSScreenShotResult
	Given Change DPI to 175
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 3504UI in 28163 under ITSScreenShotResult
	Given Change DPI to recommend
	When Close toolbar

@ITS5ToolbarNewOS
Scenario: VAN28163_TestStep36_change resolution check Button icon display clear reasonable layout not beyond the border
	Given change resolution 1920 to 1080
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 3601UI in 28163 under ITSScreenShotResult
	Given change resolution 1600 to 1900
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 3602UI in 28163 under ITSScreenShotResult
	Given change resolution 1280 to 1024
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 3603UI in 28163 under ITSScreenShotResult
	Given change resolution 1280 to 720
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 3604UI in 28163 under ITSScreenShotResult
	Given change resolution 2880 to 1800
	When Close toolbar

@ITS5ToolbarNewOS
Scenario: VAN28163_TestStep38_check toolbar tips of Intelligent cooling mode
	Given Launch Toolbar On NewOS
	Given change ITS mode to ICM via Toolbar
	When Close toolbar
	Given Launch Toolbar On NewOS
	Given hover ITS icon in toolbar
	Then Take Screen Shot 3801 in 28163 under ITSScreenShotResult
	When Close toolbar

@ITS5ToolbarNewOS
Scenario: VAN28163_TestStep39_check toolbar tips of Extreme performance mode
	Given Launch Toolbar On NewOS
	Given change ITS mode to EPM via Toolbar
	When Close toolbar
	Given Launch Toolbar On NewOS
	Given hover ITS icon in toolbar
	Then Take Screen Shot 3901 in 28163 under ITSScreenShotResult
	When Close toolbar

@ITS5ToolbarNewOS
Scenario: VAN28163_TestStep40_check toolbar tips of Battery saving mode
	Given Launch Toolbar On NewOS
	Given change ITS mode to BSM via Toolbar
	When Close toolbar
	Given Launch Toolbar On NewOS
	Given hover ITS icon in toolbar
	Then Take Screen Shot 4001 in 28163 under ITSScreenShotResult
	When Close toolbar