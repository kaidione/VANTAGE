Feature: VAN23894_Part1_X60ThermalModeACModeAutoOn
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-23894
	Author： Xu Wei
	Automated Test Step：Balance 1-24

Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)
	Given The Machine is X Series 'X60'
	Given The Machine support Specific function 'ThermalModeNew'
	When kill dota2 and wait 1 second 
	When kill Wow and wait 1 second

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep01_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup 

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep02_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep03_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When Launch Vantage
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep04_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep05_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep06_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	Then The Intelligent Sub Mode value is 3 And the Method is GetIntelligentSubMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep07_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second 
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep08_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second 
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep09_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second 
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep10_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second 
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep11_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second 
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep12_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second 
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep13_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup 

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep14_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep15_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep16_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep17_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep18_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	Then The Intelligent Sub Mode value is 1 And the Method is GetIntelligentSubMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep19_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep20_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep21_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep22_Check Smart Fan Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep23_Check Thermal Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep24_Check Intellignet Sub Mode In WMI
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is ON
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode