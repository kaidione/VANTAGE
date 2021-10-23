Feature: VAN23883_Part2_X60GPUOCOnACToDC
Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-23883
	Author： Xu Wei
	Automated Test Step：GPU OC On AC to DC 11-20

Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)
	Given The Machine is X Series 'X60'
	Given The Machine support Specific function 'ThermalModeNew'

@X60NBGPUOCOnACToDC
Scenario: VAN23883_TestStep11_Check GPU OC Status
	Given DC Condition(Connect the Adapter)
	When Check the OC values in the tools
    Then The OC value is 2 And the Method is GetBIOSOCMode

@X60NBGPUOCOnACToDC
Scenario: VAN23883_TestStep12_Check GPU OC Status In Performance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
    Then The OC value is 2 And the Method is GetBIOSOCMode
	Then The OC On label should not be shown in Performance Mode

@X60NBGPUOCOnACToDC
Scenario: VAN23883_TestStep13_Check Hover Tip In Performance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
	Then The OC value is 2 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Balance Mode' in the Legion Edge
	Then Take Screen Shot 13 in 23883 under GamingScreenShotResult

@X60NBGPUOCOnACToDC
Scenario: VAN23883_TestStep14_Check Overclocking value in Performance mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
	Then The OC value is 2 And the Method is GetBIOSOCMode
	Then It will display not OC values

@X60NBGPUOCOnACToDC
Scenario: VAN23883_TestStep15_Check GPU OC Status In Balance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
    Then The OC value is 2 And the Method is GetBIOSOCMode
	Then The OC On label should not be shown in Balance Mode

@X60NBGPUOCOnACToDC
Scenario: VAN23883_TestStep16_Check Hover Tip In Balance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
	Then The OC value is 2 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Balance Mode' in the Legion Edge
	Then Take Screen Shot 16 in 23883 under GamingScreenShotResult

@X60NBGPUOCOnACToDC
Scenario: VAN23883_TestStep17_Check Overclocking value in Balance mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
	Then The OC value is 2 And the Method is GetBIOSOCMode
	Then It will display not OC values

@X60NBGPUOCOnACToDC
Scenario: VAN23883_TestStep18_Check GPU OC Status In Quiet Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
    Then The OC value is 2 And the Method is GetBIOSOCMode
	Then The OC On label should not be shown in Quiet Mode

@X60NBGPUOCOnACToDC
Scenario: VAN23883_TestStep19_Check Hover Tip In Quiet Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
	Then The OC value is 2 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Quiet Mode' in the Legion Edge
	Then Take Screen Shot 19 in 23883 under GamingScreenShotResult

@X60NBGPUOCOnACToDC
Scenario: VAN23883_TestStep20_Check Overclocking value in Quiet mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
	Then The OC value is 2 And the Method is GetBIOSOCMode
	Then It will display not OC values