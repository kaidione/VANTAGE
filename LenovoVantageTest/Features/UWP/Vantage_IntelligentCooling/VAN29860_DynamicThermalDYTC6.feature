Feature: VAN29860_DynamicThermalDYTC6
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29860
	Author: Huajie

@DYTC6NOAMTSearch
Scenario: VAN29860_TestStep62_Enter Dynamic thermal control solution and check result
	When The user connect or disconnect WiFi on lenovo	
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Dynamic thermal control solution"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@DYTC6NOAMTSearch
Scenario: VAN29860_TestStep63_Click the result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Dynamic thermal control solution"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for DYTC6NOAMT

@DYTC6NOAMTSearch
Scenario: VAN29860_TestStep64_Enter Intelligent cooling and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Intelligent cooling"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@DYTC6NOAMTSearch
Scenario: VAN29860_TestStep65_Click the result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Intelligent cooling"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for DYTC6NOAMT

#These will be used in the future
#@DYTC6NOAMTSearch
#Scenario: VAN29860_TestStep101_stop ITS service and check search result is null
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
#@DYTC6NOAMTSearch
#Scenario: VAN29860_TestStep102_restart ITS service and check search result
#	Given Start ITS Service
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Intelligent cooling"
#	Given Click The Search Button
#	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
#
#@DYTC6NOAMTSearch
#Scenario: VAN29860_TestStep103_delete plugin and check search result is null
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
#@DYTC6NOAMTSearch
#Scenario: VAN29860_TestStep104_recover plugin and check search result
#	Given recover thinkpad plugin
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Intelligent cooling"
#	Given Click The Search Button
#	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'