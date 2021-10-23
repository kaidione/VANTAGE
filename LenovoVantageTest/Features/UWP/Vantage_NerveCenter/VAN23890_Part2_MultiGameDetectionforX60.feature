Feature: VAN23890_Part2_MultiGameDetectionforX60
Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-23890
	Author： Xu Wei
	Automated Test Step：Three Games White+Common+White 17-32

Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)
	Given The Machine is X Series 'X60'
	Given The Machine support Specific function 'ThermalModeNew'
	When kill dota2 and wait 1 second
	When kill Wow and wait 1 second
	When kill LeagueClient and wait 1 second

@MultiGameDetection
Scenario: VAN23890_TestStep17_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Legend
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup 

@MultiGameDetection
Scenario: VAN23890_TestStep18_Check Auto Adjust Checkbox Status
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Legend
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@MultiGameDetection
Scenario: VAN23890_TestStep19_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Legend
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@MultiGameDetection
Scenario: VAN23890_TestStep20_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When Launch the specifie game Legend
	Then The Gaming mode value is 3 And the Method is GetIntelligentSubMode

@MultiGameDetection
Scenario: VAN23890_TestStep21_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill dota2 and wait 1 second
	When Launch the specifie game Legend
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup 

@MultiGameDetection
Scenario: VAN23890_TestStep22_Check Auto Adjust Checkbox Status
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill dota2 and wait 1 second
	When Launch the specifie game Legend
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@MultiGameDetection
Scenario: VAN23890_TestStep23_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill dota2 and wait 1 second
	When Launch the specifie game Legend
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@MultiGameDetection
Scenario: VAN23890_TestStep24_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill dota2 and wait 1 second
	When Launch the specifie game Legend
	Then The Gaming mode value is 1 And the Method is GetIntelligentSubMode

@MultiGameDetection
Scenario: VAN23890_TestStep25_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill dota2 and wait 1 second
	When Launch the specifie game Legend
	When kill Wow and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup 

@MultiGameDetection
Scenario: VAN23890_TestStep26_Check Auto Adjust Checkbox Status
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill dota2 and wait 1 second
	When Launch the specifie game Legend
	When kill Wow and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@MultiGameDetection
Scenario: VAN23890_TestStep27_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill dota2 and wait 1 second
	When Launch the specifie game Legend
	When kill Wow and wait 1 second
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@MultiGameDetection
Scenario: VAN23890_TestStep28_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill dota2 and wait 1 second
	When Launch the specifie game Legend
	When kill Wow and wait 1 second
	Then The Gaming mode value is 2 And the Method is GetIntelligentSubMode

@MultiGameDetection
Scenario: VAN23890_TestStep29_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill dota2 and wait 1 second
	When Launch the specifie game Legend
	When kill Wow and wait 1 second
	When kill LeagueClient and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup 

@MultiGameDetection
Scenario: VAN23890_TestStep30_Check Auto Adjust Checkbox Status
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Check the Auto adjust checkbox status
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill dota2 and wait 1 second
	When Launch the specifie game Legend
	When kill Wow and wait 1 second
	When kill LeagueClient and wait 1 second
	When Check Thermal mode in the Thermal Mode Setting popup
	Then Auto adjust checkbox status should not be changed

@MultiGameDetection
Scenario: VAN23890_TestStep31_Check Thermal Mode In Homepage
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill dota2 and wait 1 second
	When Launch the specifie game Legend
	When kill Wow and wait 1 second
	When kill LeagueClient and wait 1 second
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@MultiGameDetection
Scenario: VAN23890_TestStep32_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto adjust checkbox is On
	When Launch the specifie game Dota2
	When Launch the specifie game GameWorldOfWarcraft
	When kill dota2 and wait 1 second
	When Launch the specifie game Legend
	When kill Wow and wait 1 second
	When kill LeagueClient and wait 1 second
	Then The Gaming mode value is 0 And the Method is GetIntelligentSubMode