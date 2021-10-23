Feature: VAN28026_Part3_X60CPUOCOnDCToAC
Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-28026
	Author： Xu Wei
	Automated Test Step：CPU OC On DC to AC 21-30

Background: 
	Given Machine is Gaming
	Given DC Condition(Connect the Adapter)
	Given The Machine is X Series 'X60'
	Given The Machine support Specific function 'ThermalModeNew'

@X60NBCPUOCOnDCToAC
Scenario: VAN28026_TestStep21_Check CPU OC Status
	Given AC Condition(Connect the Adapter)
	When Check the OC values in the tools
    Then The OC value is 1 And the Method is GetBIOSOCMode

@X60NBCPUOCOnDCToAC
Scenario: VAN28026_TestStep22_Check CPU OC Status In Performance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
    Then The OC value is 1 And the Method is GetBIOSOCMode
	Then The OC On label should be shown in Performance Mode

@X60NBCPUOCOnDCToAC
Scenario: VAN28026_TestStep23_Check Hover Tip In Performance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
	Then The OC value is 1 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Performacnce Mode OC On' in the Legion Edge
	Then Take Screen Shot 23 in 28026 under GamingScreenShotResult
	Then The OC On tips CPU overclocking on should be shown

@X60NBCPUOCOnDCToAC
Scenario: VAN28026_TestStep24_Check Overclocking value in Performance mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
	Then The OC value is 1 And the Method is GetBIOSOCMode
	Then It will display yes OC values

@X60NBCPUOCOnDCToAC
Scenario: VAN28026_TestStep25_Check CPU OC Status In Balance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
    Then The OC value is 1 And the Method is GetBIOSOCMode
	Then The OC On label should be shown in Balance Mode

@X60NBCPUOCOnDCToAC
Scenario: VAN28026_TestStep26_Check Hover Tip In Balance Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
	Then The OC value is 1 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Balance Mode' in the Legion Edge
	Then Take Screen Shot 26 in 28026 under GamingScreenShotResult
	Then The OC On tips CPU overclocking on should be shown

@X60NBCPUOCOnDCToAC
Scenario: VAN28026_TestStep27_Check Overclocking value in Balance mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
	Then The OC value is 1 And the Method is GetBIOSOCMode
	Then It will display yes OC values

@X60NBCPUOCOnDCToAC
Scenario: VAN28026_TestStep28_Check CPU OC Status In Quiet Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
    Then The OC value is 1 And the Method is GetBIOSOCMode
	Then The OC On label should not be shown in Quiet Mode

@X60NBCPUOCOnDCToAC
Scenario: VAN28026_TestStep29_Check Hover Tip In Quiet Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
	Then The OC value is 1 And the Method is GetBIOSOCMode
	Given Launch Vantage
	When Hover the 'Quiet Mode' in the Legion Edge
	Then Take Screen Shot 29 in 28026 under GamingScreenShotResult

@X60NBCPUOCOnDCToAC
Scenario: VAN28026_TestStep30_Check Overclocking value in Quiet mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
	Then The OC value is 1 And the Method is GetBIOSOCMode
	Then It will display not OC values