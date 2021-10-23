Feature: VAN23890_Part1_MultiGameDetectionforX60
Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-23890
	Author： Xu Wei
	Automated Test Step：Two Games White+Common 1-16

Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)
	Given The Machine is X Series 'X60'
	Given The Machine support Specific function 'ThermalModeNew'
	When kill dota2 and wait 1 second
	When kill Wow and wait 1 second

@MultiGameDetection
Scenario: VAN23890_TestStep01_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup 

@MultiGameDetection
Scenario: VAN23890_TestStep02_Check Auto Adjust Checkbox Status
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@MultiGameDetection
Scenario: VAN23890_TestStep03_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When Launch Vantage
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@MultiGameDetection
Scenario: VAN23890_TestStep04_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 3 And the Method is GetIntelligentSubMode

@MultiGameDetection
Scenario: VAN23890_TestStep05_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill dota2 and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup 

@MultiGameDetection
Scenario: VAN23890_TestStep06_Check Auto Adjust Checkbox Status
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill dota2 and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@MultiGameDetection
Scenario: VAN23890_TestStep07_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill dota2 and wait 1 second
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@MultiGameDetection
Scenario: VAN23890_TestStep08_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill dota2 and wait 15 second
	Then The Gaming mode value is 1 And the Method is GetIntelligentSubMode

@MultiGameDetection
Scenario: VAN23890_TestStep09_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup 

@MultiGameDetection
Scenario: VAN23890_TestStep10_Check Auto Adjust Checkbox Status
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@MultiGameDetection
Scenario: VAN23890_TestStep11_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@MultiGameDetection
Scenario: VAN23890_TestStep12_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 1 second
	Then The Gaming mode value is 3 And the Method is GetIntelligentSubMode

@MultiGameDetection
Scenario: VAN23890_TestStep13_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill dota2 and wait 1 second
	When kill Wow and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup 

@MultiGameDetection
Scenario: VAN23890_TestStep14_Check Auto Adjust Checkbox Status
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill dota2 and wait 1 second
	When kill Wow and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@MultiGameDetection
Scenario: VAN23890_TestStep15_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill dota2 and wait 1 second
	When kill Wow and wait 1 second
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@MultiGameDetection
Scenario: VAN23890_TestStep16_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill dota2 and wait 1 second
	When kill Wow and wait 1 second
	Then The Gaming mode value is 0 And the Method is GetIntelligentSubMode
