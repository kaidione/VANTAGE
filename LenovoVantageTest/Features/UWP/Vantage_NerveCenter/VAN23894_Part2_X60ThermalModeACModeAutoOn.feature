Feature: VAN23894_Part2_X60ThermalModeACModeAutoOn
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-23894
	Author： Xu Wei
	Automated Test Step：Performance 25-48

Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)
	Given The Machine is X Series 'X60'
	Given The Machine support Specific function 'ThermalModeNew'
	When kill dota2 and wait 1 second 
	When kill Wow and wait 1 second

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep25_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup 

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep26_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep27_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When Launch Vantage
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Performance Mode in homepage

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep28_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep29_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	Then The Gaming mode value is 3 And the Method is GetThermalMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep30_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep31_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second 
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep32_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second 
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep33_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second 
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Performance Mode in homepage

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep34_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second 
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep35_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second 
	Then The Gaming mode value is 3 And the Method is GetThermalMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep36_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second 
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep37_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup 

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep38_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep39_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Performance Mode in homepage

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep40_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep41_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 3 And the Method is GetThermalMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep42_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep43_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep44_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep45_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Performance Mode in homepage

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep46_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep47_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Then The Gaming mode value is 3 And the Method is GetThermalMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep48_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode