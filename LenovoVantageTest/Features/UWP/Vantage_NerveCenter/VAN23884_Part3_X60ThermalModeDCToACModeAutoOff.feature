Feature: VAN23884_Part3_X60ThermalModeDCToACModeAutoOff
Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-23884
	Author： Xu Wei
	Automated Test Step：Quiet 49-72

Background: 
	Given Machine is Gaming
	Given DC Condition(Connect the Adapter)
	Given The Machine is X Series 'X60'
	Given The Machine support Specific function 'ThermalModeNew'
	When kill dota2 and wait 1 second 
	When kill Wow and wait 1 second

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep49_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Launch the specifie game Dota2
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup 

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep50_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep51_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Launch the specifie game Dota2
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep52_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Launch the specifie game Dota2
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep53_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Launch the specifie game Dota2
    Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep54_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
    Given AC Condition(Connect the Adapter)
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep55_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep56_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep57_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep58_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep59_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep60_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given AC Condition(Connect the Adapter)
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep61_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup 

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep62_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep63_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep64_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep65_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep66_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep67_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep68_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep69_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep70_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep71_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeDCToACModeX60AutoOff
Scenario: VAN23884_TestStep72_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given AC Condition(Connect the Adapter)
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode