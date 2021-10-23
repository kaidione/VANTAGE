Feature: VAN4318_Part1_GamingOldThermalMode
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-4318
	Author： Wei Xu

Background:
	Given Machine is Gaming 
	Given AC Condition(Connect the Adapter)

@GamingNotSupprtOldThermalMode
Scenario: VAN4318_TestStep01_Thermal Mode Should Not Be Shown In The Unsupport Machines
	When UnSupport Old Thermal Mode
	Then Thermal Mode should not be shown

@GamingOldThermalModeAC @GamingSmokeThermalMode2
Scenario: VAN4318_TestStep02_Thermal Mode Should Be Shown In The Support Machines
	Then Thermal Mode should be shown

@GamingOldThermalModeAC
Scenario: VAN4318_TestStep03_Default Mode Should Be Balance
	When Click the Thermal mode area
	When Select the Balance mode in the menu
	Then Balance mode should be shown
	Then The mode value is 2

@GamingOldThermalModeAC  @GamingSmokeThermalMode2
Scenario: VAN4318_TestStep04_Three Modes Should Be Found In Thermal Mode Menu
	When Click the Thermal mode area
	Then Three modes should be found
	Then Take Screen Shot TestStep04 in 4318 under GamingScreenShotResult

@GamingOldThermalModeAC
Scenario: VAN4318_TestStep05_Thermal Mode Menu Should Be Closed
	When Click the Thermal mode area
	When Click the other area
	Then Thermal mode menu should be closed

@GamingOldThermalModeAC
Scenario: VAN4318_TestStep06_Performance Mode Should Be Found In Thermal Mode Menu
	When Click the Thermal mode area
	When Select the Performance mode in the menu
	Then Thermal mode menu should be closed
	Then Performance mode should be shown

@GamingOldThermalModeAC
Scenario: VAN4318_TestStep07_Performance Mode Should Be Found In Thermal Mode Menu
	When Click the Thermal mode area
	When Select the Performance mode in the menu
	Then Thermal mode menu should be closed
	Then Performance mode should be shown
	Then The mode value is 3

@GamingOldThermalModeAC
Scenario: VAN4318_TestStep08_Performance Mode Description Should Be Found In Thermal Mode Menu
	When Click the Thermal mode area
	When Select the Performance mode in the menu
	When Click the Thermal mode area
	Then Take Screen Shot TestStep08 in 4318 under GamingScreenShotResult

@GamingOldThermalModeAC
Scenario: VAN4318_TestStep09_Balance Mode Should Be Found In Thermal Mode Menu
	When Click the Thermal mode area
	When Select the Balance mode in the menu
	Then Thermal mode menu should be closed
	Then Balance mode should be shown

@GamingOldThermalModeAC
Scenario: VAN4318_TestStep10_Balance Mode Should Be Found In Thermal Mode Menu
	When Click the Thermal mode area
	When Select the Balance mode in the menu
	Then Thermal mode menu should be closed
	Then Balance mode should be shown
	Then The mode value is 2

@GamingOldThermalModeAC
Scenario: VAN4318_TestStep11_Balance Mode Description Should Be Found In Thermal Mode Menu
	When Click the Thermal mode area
	When Select the Balance mode in the menu
	When Click the Thermal mode area
	Then Take Screen Shot TestStep11 in 4318 under GamingScreenShotResult

@GamingOldThermalMode
	Scenario: VAN4318_TestStep12_Quiet Mode Should Be Found In Thermal Mode Menu
	When Click the Thermal mode area
	When Select the Quiet mode in the menu
	Then Thermal mode menu should be closed
	Then Quiet mode should be shown

@GamingOldThermalModeAC
Scenario: VAN4318_TestStep13_Quiet Mode Should Be Found In Thermal Mode Menu
	When Click the Thermal mode area
	When Select the Quiet mode in the menu
	Then Thermal mode menu should be closed
	Then Quiet mode should be shown
	Then The mode value is 1

@GamingOldThermalModeAC
Scenario: VAN4318_TestStep14_Quiet Mode Description Should Be Found In Thermal Mode Menu
	When Click the Thermal mode area
	When Select the Quiet mode in the menu
	When Click the Thermal mode area
	Then Take Screen Shot TestStep14 in 4318 under GamingScreenShotResult

@GamingOldThermalModeACS3
Scenario: VAN4318_TestStep28_Thermal Mode Should Not Be Changed After S3
	When Click the Thermal mode area
	When Select the Performance mode in the menu
	When Click Home Page Header Legion
	When enter sleep
	Then Performance mode should be shown

@GamingOldThermalModeACS4
Scenario: VAN4318_TestStep29_Thermal Mode Should Not Be Changed After S4
	When Click the Thermal mode area
	When Select the Balance mode in the menu
	When enter hibernate
	When The user connect or disconnect WiFi on lenovo
	Then Balance mode should be shown

