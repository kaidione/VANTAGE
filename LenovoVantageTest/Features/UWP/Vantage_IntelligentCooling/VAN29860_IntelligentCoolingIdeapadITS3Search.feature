Feature: VAN29860_IntelligentCoolingIdeapadITS3Search
	Test Case: https://jira.tc.lenovo.com/browse/VAN-29860
	Developer: wenyang

@ITS3Search
Scenario: VAN29860_TestStep08_Enter Power smart settings and check result
	When The user connect or disconnect WiFi on lenovo
	Given Go to Power Page
	Given Turn off Intellgentcooling toggle
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Power smart settings"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS3Search
Scenario: VAN29860_TestStep09_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Power smart settings"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling 'show' for 'ITS3'

@ITS3Search
Scenario: VAN29860_TestStep10_Enter performance mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "performance mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS3Search
Scenario: VAN29860_TestStep11_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "performance mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling 'show' for 'ITS3'

@ITS3Search
Scenario: VAN29860_TestStep12_Enter Cool & quiet mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Cool & quiet mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS3Search
Scenario: VAN29860_TestStep13_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Cool & quiet mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling 'show' for 'ITS3'

@ITS3Search
Scenario: VAN29860_TestStep14_Enter Extreme performance mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Extreme performance mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS3Search
Scenario: VAN29860_TestStep15_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Extreme performance mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling 'show' for 'ITS3'

@ITS3Search
Scenario: VAN29860_TestStep16_Enter Intelligent mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Intelligent mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS3Search
Scenario: VAN29860_TestStep17_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Intelligent mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling 'show' for 'ITS3'

@ITS3Search
Scenario: VAN29860_TestStep18_Enter Battery Saving mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Battery Saving mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS3Search
Scenario: VAN29860_TestStep19_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Battery Saving mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling 'show' for 'ITS3'

@ITS3Search
Scenario: VAN29860_TestStep20_Enter Balanced mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Balanced mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'

@ITS3Search
Scenario: VAN29860_TestStep21_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Balanced mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
	Given Click The Searched Result
	Then Check Intelligent Cooling 'show' for 'ITS3'


#These will be used in the future
#@ITS3Search
#Scenario: VAN29860_TestStep33_stop ITS service and check search result is null
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
#@ITS3Search
#Scenario: VAN29860_TestStep34_restart ITS service and check search result
#	Given Start ITS Service
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Power smart settings"
#	Given Click The Search Button
#	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
#
#@ITS3Search
#Scenario: VAN29860_TestStep35_delete plugin and check search result is null
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
#@ITS3Search
#Scenario: VAN29860_TestStep36_recover plugin and check search result
#	Given recoverplugin
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Power smart settings"
#	Given Click The Search Button
#	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'