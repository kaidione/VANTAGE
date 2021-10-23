Feature: VAN23883_Part6_X60GPUOCOffDCToAC
Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-23883
	Author： Xu Wei
	Automated Test Step：GPU OC Off DC to AC 51-60

Background: 
	Given Machine is Gaming
	Given DC Condition(Connect the Adapter)
	Given The Machine is X Series 'X60'
	Given The Machine support Specific function 'ThermalModeNew'

@X60NBGPUOCOffDCToAC
Scenario: VAN23883_TestStep51_Check GPU OC Status
	Given AC Condition(Connect the Adapter)
	When Check the OC values in the tools
    Then The OC value is 0 And the Method is GetBIOSOCMode

@X60NBGPUOCOffDCToAC
Scenario: VAN23883_TestStep52_Check GPU OC Status In Performance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
    Then The OC value is 0 And the Method is GetBIOSOCMode
	Then The OC On label should not be shown in Performance Mode

@X60NBGPUOCOffDCToAC
Scenario: VAN23883_TestStep53_Check Hover Tip In Performance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
	Then The OC value is 0 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Performacnce Mode' in the Legion Edge
	Then Take Screen Shot 53 in 23883 under GamingScreenShotResult

@X60NBGPUOCOffDCToAC
Scenario: VAN23883_TestStep54_Check Overclocking value in Performance mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
	Then The OC value is 0 And the Method is GetBIOSOCMode
	Then It will display not OC values

@X60NBGPUOCOffDCToAC
Scenario: VAN23883_TestStep55_Check GPU OC Status In Balance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
    Then The OC value is 0 And the Method is GetBIOSOCMode
	Then The OC On label should not be shown in Balance Mode

@X60NBGPUOCOffDCToAC
Scenario: VAN23883_TestStep56_Check Hover Tip In Balance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
	Then The OC value is 0 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Balance Mode' in the Legion Edge
	Then Take Screen Shot 56 in 23883 under GamingScreenShotResult

@X60NBGPUOCOffDCToAC
Scenario: VAN23883_TestStep57_Check Overclocking value in Balance mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
	Then The OC value is 0 And the Method is GetBIOSOCMode
	Then It will display not OC values

@X60NBGPUOCOffDCToAC
Scenario: VAN23883_TestStep58_Check GPU OC Status In Quiet Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
    Then The OC value is 0 And the Method is GetBIOSOCMode
	Then The OC On label should not be shown in Quiet Mode

@X60NBGPUOCOffDCToAC
Scenario: VAN23883_TestStep59_Check Hover Tip In Quiet Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
	Then The OC value is 0 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Quiet Mode' in the Legion Edge
	Then Take Screen Shot 59 in 23883 under GamingScreenShotResult

@X60NBGPUOCOffDCToAC
Scenario: VAN23883_TestStep60_Check Overclocking value in Quiet mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
	Then The OC value is 0 And the Method is GetBIOSOCMode
	Then It will display not OC values