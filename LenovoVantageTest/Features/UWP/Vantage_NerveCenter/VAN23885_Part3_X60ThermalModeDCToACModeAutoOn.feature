Feature: VAN23885_Part3_X60ThermalModeDCToACModeAutoOn
Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-23885
	Author： Xu Wei
	Automated Test Step：Balance 49-72

Background: 
	Given Machine is Gaming
	Given DC Condition(Connect the Adapter)
	Given The Machine is X Series 'X60'
	Given The Machine support Specific function 'ThermalModeNew'
	When kill dota2 and wait 1 second 
	When kill Wow and wait 1 second

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep49_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup 

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep50_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep51_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep52_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep53_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
    Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep54_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
    Given AC Condition(Connect the Adapter)
	Then The Intelligent Sub Mode value is 3 And the Method is GetIntelligentSubMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep55_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep56_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep57_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep58_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep59_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep60_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given AC Condition(Connect the Adapter)
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep61_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup 

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep62_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep63_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep64_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep65_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep66_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Then The Intelligent Sub Mode value is 1 And the Method is GetIntelligentSubMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep67_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep68_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep69_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep70_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep71_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep72_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given AC Condition(Connect the Adapter)
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode