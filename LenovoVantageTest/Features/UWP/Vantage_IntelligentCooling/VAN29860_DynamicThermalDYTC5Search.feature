Feature: VAN29860_DynamicThermalDYTC5Search
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29860
	Author: Huajie

@DYTC5Search
Scenario: VAN29860_TestStep58_Enter Dynamic thermal control solution and check result
	When The user connect or disconnect WiFi on lenovo	
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Dynamic thermal control solution"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@DYTC5Search
Scenario: VAN29860_TestStep59_Click the result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Dynamic thermal control solution"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for DYTC5

@DYTC5Search
Scenario: VAN29860_TestStep60_Enter Intelligent cooling and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Intelligent cooling"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@DYTC5Search
Scenario: VAN29860_TestStep61_Click the result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Intelligent cooling"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for DYTC5

#These will be used in the future
#@DYTC5Search
#Scenario: VAN29860_TestStep93_stop ITS service and check search result is null
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Intelligent cooling"
#	Given Click The Search Button
#	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
#	Given Stop ITS service
#	Given Go to Power Page
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Intelligent cooling"
#	Given Click The Search Button
#	Then The Search Result Is Null
#	Given Start ITS Service
#	
#@DYTC5Search
#Scenario: VAN29860_TestStep94_restart ITS service and check search result
#	Given Start ITS Service
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Intelligent cooling"
#	Given Click The Search Button
#	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
#
#@DYTC5Search
#Scenario: VAN29860_TestStep95_delete plugin and check search result is null
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Intelligent cooling"
#	Given Click The Search Button
#	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
#	Given move thinkpad plugin
#	Given Go to Power Page
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Intelligent cooling"
#	Given Click The Search Button
#	Then The Search Result Is Null
#	Given recover thinkpad plugin
#	
#@DYTC5Search
#Scenario: VAN29860_TestStep96_recover plugin and check search result
#	Given recover thinkpad plugin
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Intelligent cooling"
#	Given Click The Search Button
#	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'