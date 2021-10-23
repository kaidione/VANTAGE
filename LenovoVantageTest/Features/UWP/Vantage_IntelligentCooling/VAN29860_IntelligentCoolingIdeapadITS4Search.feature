Feature: VAN29860_IntelligentCoolingIdeapadITS4Search
	Test Case: https://jira.tc.lenovo.com/browse/VAN-29860
	Developer: wenyang

@ITS4Search
Scenario: VAN29860_TestStep22_Enter Power smart settings and check result
	When The user connect or disconnect WiFi on lenovo
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Power smart settings"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS4Search
Scenario: VAN29860_TestStep23_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Power smart settings"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling 'show' for 'ITS4'

@ITS4Search
Scenario: VAN29860_TestStep24_Enter performance mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "performance mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS4Search
Scenario: VAN29860_TestStep25_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "performance mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling 'show' for 'ITS4'

@ITS4Search
Scenario: VAN29860_TestStep26_Enter Cool & quiet mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Cool & quiet mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS4Search
Scenario: VAN29860_TestStep27_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Cool & quiet mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling 'show' for 'ITS4'

@ITS4Search
Scenario: VAN29860_TestStep28_Enter Extreme performance mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Extreme performance mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS4Search
Scenario: VAN29860_TestStep29_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Extreme performance mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling 'show' for 'ITS4'

@ITS4Search
Scenario: VAN29860_TestStep30_Enter Intelligent mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Intelligent mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS4Search
Scenario: VAN29860_TestStep31_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Intelligent mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling 'show' for 'ITS4'

@ITS4Search
Scenario: VAN29860_TestStep32_Enter Battery Saving mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Battery Saving mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS4Search
Scenario: VAN29860_TestStep33_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Battery Saving mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling 'show' for 'ITS4'

@ITS4Search
Scenario: VAN29860_TestStep34_Enter Balanced mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Balanced mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS4Search
Scenario: VAN29860_TestStep35_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Balanced mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling 'show' for 'ITS4'

#These will be usede in the future
#@ITS4Search
#Scenario: VAN29860_TestStep51_stop ITS service and check search result is null
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Power smart settings"
#	Given Click The Search Button
#	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
#	Given Stop ITS service
#	Given Go to Power Page
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Power smart settings"
#	Given Click The Search Button
#	Then The Search Result Is Null
#	Given Start ITS Service
#	
#@ITS4Search
#Scenario: VAN29860_TestStep52_restart ITS service and check search result
#	Given Start ITS Service
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Power smart settings"
#	Given Click The Search Button
#	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
#
#@ITS4Search
#Scenario: VAN29860_TestStep53_delete plugin and check search result is null
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Power smart settings"
#	Given Click The Search Button
#	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
#	Given moveplugin
#	Given Go to Power Page
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Power smart settings"
#	Given Click The Search Button
#	Then The Search Result Is Null
#	Given recoverplugin
#	
#@ITS4Search
#Scenario: VAN29860_TestStep54_recover plugin and check search result
#	Given recoverplugin
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Power smart settings"
#	Given Click The Search Button
#	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'