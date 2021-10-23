Feature: VAN29860_DynamicThermalDYTC4Search
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29860
	Author: Huajie

@DYTC4CQLSearch
Scenario: VAN29860_TestStep54_Enter Dynamic thermal control solution and check result
	When The user connect or disconnect WiFi on lenovo
	Given Go to Power Page
	Given Turn off Intellgentcooling toggle
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Dynamic thermal control solution"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@DYTC4CQLSearch
Scenario: VAN29860_TestStep55_Click the result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Dynamic thermal control solution"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for DYTC4CQL

@DYTC4CQLSearch
Scenario: VAN29860_TestStep56_Enter Intelligent cooling and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Intelligent cooling"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@DYTC4CQLSearch
Scenario: VAN29860_TestStep57_Click the result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Intelligent cooling"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for DYTC4CQL

#These will be used in the future
#@DYTC4CQLSearch
#Scenario: VAN29860_TestStep85_stop ITS service and check search result is null
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
#@DYTC4CQLSearch
#Scenario: VAN29860_TestStep86_restart ITS service and check search result
#	Given Start ITS Service
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Intelligent cooling"
#	Given Click The Search Button
#	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
#
#@DYTC4CQLSearch
#Scenario: VAN29860_TestStep87_delete plugin and check search result is null
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
#@DYTC4CQLSearch
#Scenario: VAN29860_TestStep88_recover plugin and check search result
#	Given recover thinkpad plugin
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Intelligent cooling"
#	Given Click The Search Button
#	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'