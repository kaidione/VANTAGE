Feature: VAN23890_Part3_MultiGameDetectionforX60
Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-23890
	Author： Xu Wei
	Automated Test Step：Two Games Common+White 33-48

Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)
	Given The Machine is X Series 'X60'
	Given The Machine support Specific function 'ThermalModeNew'
	When kill dota2 and wait 1 second
	When kill Wow and wait 1 second

@MultiGameDetection
Scenario: VAN23890_TestStep33_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup 

@MultiGameDetection
Scenario: VAN23890_TestStep34_Check Auto Adjust Checkbox Status
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@MultiGameDetection
Scenario: VAN23890_TestStep35_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When Launch Vantage
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@MultiGameDetection
Scenario: VAN23890_TestStep36_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	Then The Gaming mode value is 1 And the Method is GetIntelligentSubMode

@MultiGameDetection
Scenario: VAN23890_TestStep37_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill Wow and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup 

@MultiGameDetection
Scenario: VAN23890_TestStep38_Check Auto Adjust Checkbox Status
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill Wow and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@MultiGameDetection
Scenario: VAN23890_TestStep39_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill Wow and wait 1 second
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@MultiGameDetection
Scenario: VAN23890_TestStep40_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill Wow and wait 10 second
	Then The Gaming mode value is 3 And the Method is GetIntelligentSubMode

@MultiGameDetection
Scenario: VAN23890_TestStep41_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup 

@MultiGameDetection
Scenario: VAN23890_TestStep42_Check Auto Adjust Checkbox Status
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@MultiGameDetection
Scenario: VAN23890_TestStep43_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@MultiGameDetection
Scenario: VAN23890_TestStep44_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill dota2 and wait 1 second
	Then The Gaming mode value is 1 And the Method is GetIntelligentSubMode

@MultiGameDetection
Scenario: VAN23890_TestStep45_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill Wow and wait 1 second
	When kill dota2 and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup 

@MultiGameDetection
Scenario: VAN23890_TestStep46_Check Auto Adjust Checkbox Status
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Check the Auto adjust checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill Wow and wait 1 second
	When kill dota2 and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@MultiGameDetection
Scenario: VAN23890_TestStep47_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill Wow and wait 1 second
	When kill dota2 and wait 1 second
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@MultiGameDetection
Scenario: VAN23890_TestStep48_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Dota2
	When kill Wow and wait 1 second
	When kill dota2 and wait 1 second
	Then The Gaming mode value is 0 And the Method is GetIntelligentSubMode
