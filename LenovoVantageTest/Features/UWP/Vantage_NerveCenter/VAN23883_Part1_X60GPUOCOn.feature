Feature: VAN23883_Part1_X60GPUOCOn
Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-23883
	Author： Xu Wei
	Automated Test Step：GPU OC On AC mode 1-10

Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)
	Given The Machine is X Series 'X60'
	Given The Machine support Specific function 'ThermalModeNew'

@X60NBGPUOCOn
Scenario: VAN23883_TestStep01_Check GPU OC Status
	When Check the OC values in the tools
    Then The OC value is 2 And the Method is GetBIOSOCMode

@X60NBGPUOCOn
Scenario: VAN23883_TestStep02_Check GPU OC Status In Performance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
    Then The OC value is 2 And the Method is GetBIOSOCMode
	Then The OC On label should be shown in Performance Mode

@X60NBGPUOCOn
Scenario: VAN23883_TestStep03_Check Hover Tip In Performance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Then The OC value is 2 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Performacnce Mode OC On' in the Legion Edge
	Then Take Screen Shot 03 in 23883 under GamingScreenShotResult
	Then The OC On tips GPU overclocking on should be shown

@X60NBGPUOCOn
Scenario: VAN23883_TestStep04_Check Overclocking value in Performance mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Then The OC value is 2 And the Method is GetBIOSOCMode
	Then It will display yes OC values

@X60NBGPUOCOn
Scenario: VAN23883_TestStep05_Check GPU OC Status In Balance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
    Then The OC value is 2 And the Method is GetBIOSOCMode
	Then The OC On label should be shown in Balance Mode

@X60NBGPUOCOn
Scenario: VAN23883_TestStep06_Check Hover Tip In Balance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Then The OC value is 2 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Balance Mode' in the Legion Edge
	Then Take Screen Shot 06 in 23883 under GamingScreenShotResult
	Then The OC On tips GPU overclocking on should be shown

@X60NBGPUOCOn
Scenario: VAN23883_TestStep07_Check Overclocking value in Balance mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Then The OC value is 2 And the Method is GetBIOSOCMode
	Then It will display yes OC values

@X60NBGPUOCOn
Scenario: VAN23883_TestStep08_Check GPU OC Status In Quiet Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
    Then The OC value is 2 And the Method is GetBIOSOCMode
	Then The OC On label should not be shown in Quiet Mode

@X60NBGPUOCOn
Scenario: VAN23883_TestStep09_Check Hover Tip In Quiet Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Then The OC value is 2 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Quiet Mode' in the Legion Edge
	Then Take Screen Shot 09 in 23883 under GamingScreenShotResult

@X60NBGPUOCOn
Scenario: VAN23883_TestStep10_Check Overclocking value in Quiet mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Then The OC value is 2 And the Method is GetBIOSOCMode
	Then It will display not OC values