Feature: VAN29860_IntelligentCoolingIdeapadITS5Search
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29860
	Author: Huajie

@ITS5Search
Scenario: VAN29860_TestStep36_Enter Power smart settings and check result
	When The user connect or disconnect WiFi on lenovo
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Power smart settings"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS5Search
Scenario: VAN29860_TestStep37_Click the result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Power smart settings"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS5

@ITS5Search
Scenario: VAN29860_TestStep38_Enter Performance mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "performance mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS5Search
Scenario: VAN29860_TestStep39_Click the result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "performance mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS5

@ITS5Search
Scenario: VAN29860_TestStep40_Enter Cool & quiet and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Cool & quiet mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS5Search
Scenario: VAN29860_TestStep41_Click the result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Cool & quiet mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS5

@ITS5Search
Scenario: VAN29860_TestStep42_Enter Extreme performance mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Extreme performance mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS5Search
Scenario: VAN29860_TestStep43_Click the result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Extreme performance mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS5

@ITS5Search
Scenario: VAN29860_TestStep44_Enter Intelligent mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Intelligent mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS5Search
Scenario: VAN29860_TestStep45_Click the result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Intelligent mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS5

@ITS5Search
Scenario: VAN29860_TestStep46_Enter Battery Saving mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Battery Saving mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS5Search
Scenario: VAN29860_TestStep47_Click the result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Battery Saving mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS5

@ITS5Search
Scenario: VAN29860_TestStep48_Enter Balanced mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Balanced mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS5Search
Scenario: VAN29860_TestStep49_Click the result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Balanced mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS5

#These will be used in the future
#@ITS5Search
#Scenario: VAN29860_TestStep69_stop ITS service and check search result is null
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
#@ITS5Search
#Scenario: VAN29860_TestStep70_restart ITS service and check search result
#	Given Start ITS Service
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Power smart settings"
#	Given Click The Search Button
#	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
#
#@ITS5Search
#Scenario: VAN29860_TestStep71_delete plugin and check search result is null
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
#@ITS5Search
#Scenario: VAN29860_TestStep72_recover plugin and check search result
#	Given recoverplugin
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Power smart settings"
#	Given Click The Search Button
#	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
