Feature: VAN23883_Part5_X60GPUOCOffACToDC
Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-23883
	Author： Xu Wei
	Automated Test Step：GPU OC Off AC to DC 41-50

Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)
	Given The Machine is X Series 'X60'
	Given The Machine support Specific function 'ThermalModeNew'

@X60NBGPUOCOffACToDC
Scenario: VAN23883_TestStep41_Check GPU OC Status
	Given DC Condition(Connect the Adapter)
	When Check the OC values in the tools
    Then The OC value is 0 And the Method is GetBIOSOCMode

@X60NBGPUOCOffACToDC
Scenario: VAN23883_TestStep42_Check GPU OC Status In Performance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
    Then The OC value is 0 And the Method is GetBIOSOCMode
	Then The OC On label should not be shown in Performance Mode

@X60NBGPUOCOffACToDC
Scenario: VAN23883_TestStep43_Check Hover Tip In Performance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
	Then The OC value is 0 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Balance Mode' in the Legion Edge
	Then Take Screen Shot 43 in 23883 under GamingScreenShotResult

@X60NBGPUOCOffACToDC
Scenario: VAN23883_TestStep44_Check Overclocking value in Performance mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
	Then The OC value is 0 And the Method is GetBIOSOCMode
	Then It will display not OC values

@X60NBGPUOCOffACToDC
Scenario: VAN23883_TestStep45_Check GPU OC Status In Balance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
    Then The OC value is 0 And the Method is GetBIOSOCMode
	Then The OC On label should not be shown in Balance Mode

@X60NBGPUOCOffACToDC
Scenario: VAN23883_TestStep46_Check Hover Tip In Balance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
	Then The OC value is 0 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Balance Mode' in the Legion Edge
	Then Take Screen Shot 46 in 23883 under GamingScreenShotResult

@X60NBGPUOCOffACToDC
Scenario: VAN23883_TestStep47_Check Overclocking value in Balance mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
	Then The OC value is 0 And the Method is GetBIOSOCMode
	Then It will display not OC values

@X60NBGPUOCOffACToDC
Scenario: VAN23883_TestStep48_Check GPU OC Status In Quiet Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
    Then The OC value is 0 And the Method is GetBIOSOCMode
	Then The OC On label should not be shown in Quiet Mode

@X60NBGPUOCOffACToDC
Scenario: VAN23883_TestStep49_Check Hover Tip In Quiet Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
	Then The OC value is 0 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Quiet Mode' in the Legion Edge
	Then Take Screen Shot 49 in 23883 under GamingScreenShotResult

@X60NBGPUOCOffACToDC
Scenario: VAN23883_TestStep50_Check Overclocking value in Quiet mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
	Then The OC value is 0 And the Method is GetBIOSOCMode
	Then It will display not OC values