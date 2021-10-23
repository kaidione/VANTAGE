Feature: VAN24854_DynamicThermalToolbarUpdateTips
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-24854
	Author: Huajie

@ITS3ToolbarUpdateTips
Scenario: VAN24854_TestStep01_check toolbar tips of Intelligent cooling mode
	When The user connect or disconnect WiFi on lenovo
	Given turn on narrator
	Given launch toolbar
	Given change ITS mode to Auto via Toolbar
	When Close toolbar
	When launch toolbar
	Given hover ITS icon in toolbar
	Then Take Screen Shot 0101 in 24854 under ITSScreenShotResult

@ITS3ToolbarUpdateTips
Scenario: VAN24854_TestStep02_check toolbar tips of Performance mode
	Given turn on narrator
	Given launch toolbar
	Given change ITS mode to Perf via Toolbar
	When Close toolbar
	When launch toolbar
	Given hover ITS icon in toolbar
	Then Take Screen Shot 0201 in 24854 under ITSScreenShotResult

@ITS3ToolbarUpdateTips
Scenario: VAN24854_TestStep03_check toolbar tips of Cool&quiet mode
	Given turn on narrator
	Given launch toolbar
	Given change ITS mode to C&Q via Toolbar
	When Close toolbar
	When launch toolbar
	Given hover ITS icon in toolbar
	Then Take Screen Shot 0301 in 24854 under ITSScreenShotResult
	Given turn off narrator

@ITS4ToolbarUpdateTips
Scenario: VAN24854_TestStep04_check toolbar tips of Intelligent cooling mode
	Given turn on narrator
	Given launch toolbar
	Given change ITS mode to ICM via Toolbar
	When Close toolbar
	When launch toolbar
	Given hover ITS icon in toolbar
	Then Take Screen Shot 0401 in 24854 under ITSScreenShotResult

@ITS4ToolbarUpdateTips
Scenario: VAN24854_TestStep05_check toolbar tips of Extreme performance mode
	Given turn on narrator
	Given launch toolbar
	Given change ITS mode to EPM via Toolbar
	When Close toolbar
	When launch toolbar
	Given hover ITS icon in toolbar
	Then Take Screen Shot 0501 in 24854 under ITSScreenShotResult

@ITS4ToolbarUpdateTips
Scenario: VAN24854_TestStep06_check toolbar tips of Battery saving mode
	Given turn on narrator
	Given launch toolbar
	Given change ITS mode to BSM via Toolbar
	When Close toolbar
	When launch toolbar
	Given hover ITS icon in toolbar
	Then Take Screen Shot 0601 in 24854 under ITSScreenShotResult
	Given turn off narrator

@ITS5ToolbarUpdateTips
Scenario: VAN24854_TestStep07_check toolbar tips of Intelligent cooling mode
	Given turn on narrator
	Given launch toolbar
	Given change ITS mode to ICM via Toolbar
	When Close toolbar
	When launch toolbar
	Given hover ITS icon in toolbar
	Then Take Screen Shot 0701 in 24854 under ITSScreenShotResult

@ITS5ToolbarUpdateTips
Scenario: VAN24854_TestStep08_check toolbar tips of Extreme performance mode
	Given turn on narrator
	Given launch toolbar
	Given change ITS mode to EPM via Toolbar
	When Close toolbar
	When launch toolbar
	Given hover ITS icon in toolbar
	Then Take Screen Shot 0801 in 24854 under ITSScreenShotResult

@ITS5ToolbarUpdateTips
Scenario: VAN24854_TestStep09_check toolbar tips of Battery saving mode
	Given turn on narrator
	Given launch toolbar
	Given change ITS mode to BSM via Toolbar
	When Close toolbar
	When launch toolbar
	Given hover ITS icon in toolbar
	Then Take Screen Shot 0901 in 24854 under ITSScreenShotResult
	Given turn off narrator
