Feature: VAN23885_Part2_X60ThermalModeDCToACModeAutoOn
Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-23885
	Author： Xu Wei
	Automated Test Step：Quiet 25-48

Background: 
	Given Machine is Gaming
	Given DC Condition(Connect the Adapter)
	Given The Machine is X Series 'X60'
	Given The Machine support Specific function 'ThermalModeNew'
	When kill dota2 and wait 1 second 
	When kill Wow and wait 1 second

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep25_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup 

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep26_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep27_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep28_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep29_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
    Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep30_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
    Given AC Condition(Connect the Adapter)
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep31_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep32_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep33_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep34_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep35_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep36_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given AC Condition(Connect the Adapter)
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep37_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup 

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep38_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep39_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep40_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep41_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep42_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep43_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep44_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep45_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep46_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep47_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeDCToACModeX60AutoOn
Scenario: VAN23885_TestStep48_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given AC Condition(Connect the Adapter)
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode