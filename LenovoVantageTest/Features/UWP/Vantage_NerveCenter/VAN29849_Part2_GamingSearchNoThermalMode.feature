Feature: VAN29849_Part2_GamingSearchNoThermalMode
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29849
	Author: Yang Liu
	Test Steps: 07-21 

Background: 
	Given Machine is Gaming
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.ThermalMode" is "null"

@GamingSearchNoThermalMode
Scenario: VAN29849_TestStep07_Check the search result no Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Thermalmode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'null'

@GamingSearchNoThermalMode
Scenario: VAN29849_TestStep08_Check the search result no Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Thermal mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'null'

@GamingSearchNoThermalMode
Scenario: VAN29849_TestStep09_Check the search result no Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "performance"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'null'

@GamingSearchNoThermalMode
Scenario: VAN29849_TestStep10_Check the search result no Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Balance"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'null'

@GamingSearchNoThermalMode
Scenario: VAN29849_TestStep11_Check the search result no Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "quite"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'null'

@GamingSearchNoThermalMode
Scenario: VAN29849_TestStep12_Check the search result no Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'null'

@GamingSearchNoThermalMode
Scenario: VAN29849_TestStep13_Check the search result no Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Fn"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'null'

@GamingSearchNoThermalMode
Scenario: VAN29849_TestStep14_Check the search result no Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Q"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'null'

@GamingSearchNoThermalMode
Scenario: VAN29849_TestStep15_Check the search result no Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "device profile"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'null'

@GamingSearchNoThermalMode
Scenario: VAN29849_TestStep16_Check the search result no Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "profile"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'null'

@GamingSearchNoThermalMode
Scenario: VAN29849_TestStep17_Check the search result no Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "fan speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'null'

@GamingSearchNoThermalMode
Scenario: VAN29849_TestStep18_Check the search result no Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'null'

@GamingSearchNoThermalMode
Scenario: VAN29849_TestStep19_Check the search result no Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "cooling control"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'null'

@GamingSearchNoThermalMode
Scenario: VAN29849_TestStep20_Check the search result no Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "temperature"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'null'

@GamingSearchNoThermalMode
Scenario: VAN29849_TestStep21_Check the search result no Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "silent"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'null'
