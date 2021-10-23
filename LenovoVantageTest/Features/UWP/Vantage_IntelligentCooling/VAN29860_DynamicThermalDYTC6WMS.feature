Feature: VAN29860_DynamicThermalDYTC6WMS
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29860
	Author: Huajie

@DYTC6MWSSearch
Scenario: VAN29860_TestStep66_Enter Dynamic thermal control solution and check result
	When The user connect or disconnect WiFi on lenovo	
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Dynamic thermal control solution"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@DYTC6MWSSearch
Scenario: VAN29860_TestStep67_Click the result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Dynamic thermal control solution"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then The Intelligent Cooling feature will show for Thinkpad DYTC Six CS20 CS21

@DYTC6MWSSearch
Scenario: VAN29860_TestStep68_Enter Intelligent cooling and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Intelligent cooling"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@DYTC6MWSSearch
Scenario: VAN29860_TestStep69_Click the result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Intelligent cooling"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then The Intelligent Cooling feature will show for Thinkpad DYTC Six CS20 CS21

#These will be used in the future
#@DYTC6MWSSearch
#Scenario: VAN29860_TestStep109_stop ITS service and check search result is null
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
#@DYTC6MWSSearch
#Scenario: VAN29860_TestStep110_restart ITS service and check search result
#	Given Start ITS Service
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Intelligent cooling"
#	Given Click The Search Button
#	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
#
#@DYTC6MWSSearch
#Scenario: VAN29860_TestStep111_delete plugin and check search result is null
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
#@DYTC6MWSSearch
#Scenario: VAN29860_TestStep112_recover plugin and check search result
#	Given recover thinkpad plugin
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Intelligent cooling"
#	Given Click The Search Button
#	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
