Feature: VAN23892_Part2_X60ThermalModeACToDCModeAutoOn
Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-23892
	Author： Xu Wei
	Automated Test Step：Quiet 25-48

Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)
	Given The Machine is X Series 'X60'
	Given The Machine support Specific function 'ThermalModeNew'
	When kill dota2 and wait 1 second 
	When kill Wow and wait 1 second

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep25_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup 

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep26_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep27_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep28_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep29_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
    Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep30_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
    Given DC Condition(Connect the Adapter)
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep31_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep32_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep33_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep34_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep35_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep36_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given DC Condition(Connect the Adapter)
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep37_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup 

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep38_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep39_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep40_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep41_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep42_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep43_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep44_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep45_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep46_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep47_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep48_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given DC Condition(Connect the Adapter)
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode