Feature: VAN23883_Part4_X60GPUOCOff
Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-23883
	Author： Xu Wei
	Automated Test Step：GPU OC Off AC mode 31-40

Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)
	Given The Machine is X Series 'X60'
	Given The Machine support Specific function 'ThermalModeNew'

@X60NBGPUOCOff
Scenario: VAN23883_TestStep31_Check GPU OC Status
	When Check the OC values in the tools
    Then The OC value is 0 And the Method is GetBIOSOCMode

@X60NBGPUOCOff
Scenario: VAN23883_TestStep32_Check GPU OC Status In Performance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
    Then The OC value is 0 And the Method is GetBIOSOCMode
	Then The OC On label should not be shown in Performance Mode

@X60NBGPUOCOff
Scenario: VAN23883_TestStep33_Check Hover Tip In Performance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Then The OC value is 0 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Performacnce Mode' in the Legion Edge
	Then Take Screen Shot 33 in 23883 under GamingScreenShotResult

@X60NBGPUOCOff
Scenario: VAN23883_TestStep34_Check Overclocking value in Performance mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Then The OC value is 0 And the Method is GetBIOSOCMode
	Then It will display not OC values

@X60NBGPUOCOff
Scenario: VAN23883_TestStep35_Check GPU OC Status In Balance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
    Then The OC value is 0 And the Method is GetBIOSOCMode
	Then The OC On label should not be shown in Balance Mode

@X60NBGPUOCOff
Scenario: VAN23883_TestStep36_Check Hover Tip In Balance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Then The OC value is 0 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Balance Mode' in the Legion Edge
	Then Take Screen Shot 36 in 23883 under GamingScreenShotResult

@X60NBGPUOCOff
Scenario: VAN23883_TestStep37_Check Overclocking value in Balance mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Then The OC value is 0 And the Method is GetBIOSOCMode
	Then It will display not OC values

@X60NBGPUOCOff
Scenario: VAN23883_TestStep38_Check GPU OC Status In Quiet Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
    Then The OC value is 0 And the Method is GetBIOSOCMode
	Then The OC On label should not be shown in Quiet Mode

@X60NBGPUOCOff
Scenario: VAN23883_TestStep39_Check Hover Tip In Quiet Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Then The OC value is 0 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Quiet Mode' in the Legion Edge
	Then Take Screen Shot 39 in 23883 under GamingScreenShotResult

@X60NBGPUOCOff
Scenario: VAN23883_TestStep40_Check Overclocking value in Quiet mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Then The OC value is 0 And the Method is GetBIOSOCMode
	Then It will display not OC values