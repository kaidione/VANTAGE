Feature: VAN29860_IntelligentCoolingIdeapadITS2Search
	Test Case: https://jira.tc.lenovo.com/browse/VAN-29860
	Developer: wenyang

@ITS2Search
Scenario: VAN29860_TestStep01_Enter Power smart settings and check result
	When The user connect or disconnect WiFi on lenovo	
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Power smart settings"
	Given Click The Search Button
	Then The Search Result Is Null

@ITS2Search
Scenario: VAN29860_TestStep02_Enter performance mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "performance mode"
	Given Click The Search Button
	Then The Search Result Is Null

@ITS2Search
Scenario: VAN29860_TestStep03_Enter Cool & quiet mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Cool & quiet mode"
	Given Click The Search Button
	Then The Search Result Is Null

@ITS2Search
Scenario: VAN29860_TestStep04_Enter Extreme performance mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Extreme performance mode"
	Given Click The Search Button
	Then The Search Result Is Null

@ITS2Search
Scenario: VAN29860_TestStep05_Enter Intelligent mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Intelligent mode"
	Given Click The Search Button
	Then The Search Result Is Null

@ITS2Search
Scenario: VAN29860_TestStep06_Enter Battery Saving mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Battery Saving mode"
	Given Click The Search Button
	Then The Search Result Is Null

@ITS2Search
Scenario: VAN29860_TestStep07_Enter Balanced mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Balanced mode"
	Given Click The Search Button
	Then The Search Result Is Null

#### The below will be used in the future
##@ITS2Search
#Scenario: VAN29860_TestStep15_stop ITS service and check search result is null
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
##@ITS2Search
#Scenario: VAN29860_TestStep16_restart ITS service and check search result
#	Given Start ITS Service
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Power smart settings"
#	Given Click The Search Button
#	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'
#
##@ITS2Search
#Scenario: VAN29860_TestStep17_delete plugin and check search result is null
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
##@ITS2Search
#Scenario: VAN29860_TestStep18_recover plugin and check search result
#	Given recoverplugin
#	Given Enter Search Page By Click The Search Icon In The Navigation Bar
#	Given Type in "Power smart settings"
#	Given Click The Search Button
#	Then The Search Result Feature Name Is 'Intelligent cooling' Category Is 'Power'