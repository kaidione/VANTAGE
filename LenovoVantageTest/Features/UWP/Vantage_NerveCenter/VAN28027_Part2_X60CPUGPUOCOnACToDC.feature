Feature: VAN28027_Part2_X60CPUGPUOCOnACToDC
Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-28027
	Automated Test Step：CPU/GPU OC On AC to DC 11-20

Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)
	Given The Machine is X Series 'X60'
	Given The Machine support Specific function 'ThermalModeNew'

@X60NBCPUGPUOCOnACToDC
Scenario: VAN28027_TestStep11_Check CPU/GPU OC Status
	Given DC Condition(Connect the Adapter)
	When Check the OC values in the tools
    Then The OC value is 3 And the Method is GetBIOSOCMode

@X60NBCPUGPUOCOnACToDC
Scenario: VAN28027_TestStep12_Check CPU/GPU OC Status In Performance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
    Then The OC value is 3 And the Method is GetBIOSOCMode
	Then The OC On label should not be shown in Performance Mode

@X60NBCPUGPUOCOnACToDC
Scenario: VAN28027_TestStep13_Check Hover Tip In Performance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
	Then The OC value is 3 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Balance Mode' in the Legion Edge
	Then Take Screen Shot 13 in 28027 under GamingScreenShotResult

@X60NBCPUGPUOCOnACToDC
Scenario: VAN28027_TestStep14_Check Overclocking value in Performance mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
	Then The OC value is 3 And the Method is GetBIOSOCMode
	Then It will display not OC values

@X60NBCPUGPUOCOnACToDC
Scenario: VAN28027_TestStep15_Check CPU/GPU OC Status In Balance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
    Then The OC value is 3 And the Method is GetBIOSOCMode
	Then The OC On label should not be shown in Balance Mode

@X60NBCPUGPUOCOnACToDC
Scenario: VAN28027_TestStep16_Check Hover Tip In Balance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
	Then The OC value is 3 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Balance Mode' in the Legion Edge
	Then Take Screen Shot 16 in 28027 under GamingScreenShotResult

@X60NBCPUGPUOCOnACToDC
Scenario: VAN28027_TestStep17_Check Overclocking value in Balance mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
	Then The OC value is 3 And the Method is GetBIOSOCMode
	Then It will display not OC values

@X60NBCPUGPUOCOnACToDC
Scenario: VAN28027_TestStep18_Check CPU/GPU OC Status In Quiet Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
    Then The OC value is 3 And the Method is GetBIOSOCMode
	Then The OC On label should not be shown in Quiet Mode

@X60NBCPUGPUOCOnACToDC
Scenario: VAN28027_TestStep19_Check Hover Tip In Quiet Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
	Then The OC value is 3 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Quiet Mode' in the Legion Edge
	Then Take Screen Shot 19 in 28027 under GamingScreenShotResult

@X60NBCPUGPUOCOnACToDC
Scenario: VAN28027_TestStep20_Check Overclocking value in Quiet mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given DC Condition(Connect the Adapter)
	Then The OC value is 3 And the Method is GetBIOSOCMode
	Then It will display not OC values