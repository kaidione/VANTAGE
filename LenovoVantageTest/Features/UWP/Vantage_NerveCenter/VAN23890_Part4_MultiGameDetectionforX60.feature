Feature: VAN23890_Part4_MultiGameDetectionforX60
Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-23890
	Author： Xu Wei
	Automated Test Step：Three Games Common+White+Common 49-64

Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)
	Given The Machine is X Series 'X60'
	Given The Machine support Specific function 'ThermalModeNew'
	When kill dota2 and wait 1 second
	When kill Wow and wait 1 second
	When kill Diablo III and wait 1 second

@MultiGameDetection
Scenario: VAN23890_TestStep49_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When Launch the specifie game Diablo
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup 

@MultiGameDetection
Scenario: VAN23890_TestStep50_Check Auto Adjust Checkbox Status
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When Launch the specifie game Diablo
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@MultiGameDetection
Scenario: VAN23890_TestStep51_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When Launch the specifie game Diablo
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@MultiGameDetection
Scenario: VAN23890_TestStep52_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When Launch the specifie game Diablo
	Then The Gaming mode value is 1 And the Method is GetIntelligentSubMode

@MultiGameDetection
Scenario: VAN23890_TestStep53_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill Wow and wait 1 second
	When Launch the specifie game Diablo
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup 

@MultiGameDetection
Scenario: VAN23890_TestStep54_Check Auto Adjust Checkbox Status
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill Wow and wait 1 second
	When Launch the specifie game Diablo
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@MultiGameDetection
Scenario: VAN23890_TestStep55_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill Wow and wait 1 second
	When Launch the specifie game Diablo
	When Launch Vantage
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@MultiGameDetection
Scenario: VAN23890_TestStep56_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill Wow and wait 1 second
	When Launch the specifie game Diablo
	Then The Gaming mode value is 3 And the Method is GetIntelligentSubMode

@MultiGameDetection
Scenario: VAN23890_TestStep57_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill Wow and wait 1 second
	When Launch the specifie game Diablo
	When kill dota2 and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup 

@MultiGameDetection
Scenario: VAN23890_TestStep58_Check Auto Adjust Checkbox Status
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill Wow and wait 1 second
	When Launch the specifie game Diablo
	When kill dota2 and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@MultiGameDetection
Scenario: VAN23890_TestStep59_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill Wow and wait 1 second
	When Launch the specifie game Diablo
	When kill dota2 and wait 1 second
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@MultiGameDetection
Scenario: VAN23890_TestStep60_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill Wow and wait 1 second
	When Launch the specifie game Diablo
	When kill dota2 and wait 10 second
	Then The Gaming mode value is 1 And the Method is GetIntelligentSubMode

@MultiGameDetection
Scenario: VAN23890_TestStep61_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill Wow and wait 1 second
	When Launch the specifie game Diablo
	When kill dota2 and wait 1 second
	When kill Diablo_x64 and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup 

@MultiGameDetection
Scenario: VAN23890_TestStep62_Check Auto Adjust Checkbox Status
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill Wow and wait 1 second
	When Launch the specifie game Diablo
	When kill dota2 and wait 1 second
	When kill Diablo III and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@MultiGameDetection
Scenario: VAN23890_TestStep63_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill Wow and wait 1 second
	When Launch the specifie game Diablo
	When kill dota2 and wait 1 second
	When kill Diablo III and wait 1 second
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@MultiGameDetection
Scenario: VAN23890_TestStep64_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill Wow and wait 1 second
	When Launch the specifie game Diablo
	When kill dota2 and wait 1 second
	When kill Diablo III and wait 1 second
	Then The Gaming mode value is 0 And the Method is GetIntelligentSubMode
