Feature: VAN23892_Part1_X60ThermalModeACToDCModeAutoOn
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-23892
	Author： Xu Wei
	Automated Test Step：Performance 1-24

Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)
	Given The Machine is X Series 'X60'
	Given The Machine support Specific function 'ThermalModeNew'
	When kill dota2 and wait 1 second 
	When kill Wow and wait 1 second

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep01_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup 

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep02_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep03_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep04_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep05_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
    Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep06_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
    Given DC Condition(Connect the Adapter)
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep07_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep08_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep09_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep10_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep11_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep12_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given DC Condition(Connect the Adapter)
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep13_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup 

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep14_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep15_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep16_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep17_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep18_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep19_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep20_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep21_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep22_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep23_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeACToDCModeX60AutoOn
Scenario: VAN23892_TestStep24_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given DC Condition(Connect the Adapter)
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode