Feature: VAN4318_Part2_GamingOldThermalMode
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-4318
	Author： Wei Xu
Background:
	Given Machine is Gaming
	Given DC Condition(Connect the Adapter)

@GamingOldThermalModeDC
Scenario: VAN4318_TestStep19_Performance Mode Should Be Found In Thermal Mode Menu
	When Click the Thermal mode area
	When Select the Performance mode in the menu
	Then Thermal mode menu should be closed
	Then Performance mode should be shown

@GamingOldThermalModeDC
Scenario: VAN4318_TestStep20_Performance Mode Should Be Found In Thermal Mode Menu
	When Click the Thermal mode area
	When Select the Performance mode in the menu
	Then Thermal mode menu should be closed
	Then Performance mode should be shown
	Then The mode value is 3

@GamingOldThermalModeDC
Scenario: VAN4318_TestStep21_Balance Mode Should Be Found In Thermal Mode Menu
	When Click the Thermal mode area
	When Select the Balance mode in the menu
	Then Thermal mode menu should be closed
	Then Balance mode should be shown

@GamingOldThermalModeDC
Scenario: VAN4318_TestStep22_Balance Mode Should Be Found In Thermal Mode Menu
	When Click the Thermal mode area
	When Select the Balance mode in the menu
	Then Thermal mode menu should be closed
	Then Balance mode should be shown
	Then The mode value is 2

@GamingOldThermalModeDC
Scenario: VAN4318_TestStep23_Quiet Mode Should Be Found In Thermal Mode Menu
	When Click the Thermal mode area
	When Select the Quiet mode in the menu
	Then Thermal mode menu should be closed
	Then Quiet mode should be shown

@GamingOldThermalModeDC
Scenario: VAN4318_TestStep24_Quiet Mode Should Be Found In Thermal Mode Menu
	When Click the Thermal mode area
	When Select the Quiet mode in the menu
	Then Thermal mode menu should be closed
	Then Quiet mode should be shown
	Then The mode value is 1

