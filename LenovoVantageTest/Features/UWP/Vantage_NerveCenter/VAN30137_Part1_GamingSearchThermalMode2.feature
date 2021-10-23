Feature: VAN30137_Part1_GamingSearchThermalMode2.0
	Test Case： https://jira.tc.lenovo.com/browse/VAN-30137
	Author: Yang Liu
	Test Steps: 1-16 

Background: 
	Given Machine is Gaming
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.ThermalMode" is "2.0"

@GamingSearchThermalMode2
Scenario: VAN30137_TestStep01_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Thermalmode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Device'

@GamingSearchThermalMode2
Scenario: VAN30137_TestStep02_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Thermal mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Device'

@GamingSearchThermalMode2
Scenario: VAN30137_TestStep03_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "performance"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Device'

@GamingSearchThermalMode2
Scenario: VAN30137_TestStep04_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Balance"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Device'

@GamingSearchThermalMode2
Scenario: VAN30137_TestStep05_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "quite"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Device'

@GamingSearchThermalMode2
Scenario: VAN30137_TestStep06_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Device'

@GamingSearchThermalMode2
Scenario: VAN30137_TestStep07_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Fn"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Device'

@GamingSearchThermalMode2
Scenario: VAN30137_TestStep08_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Q"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Device'

@GamingSearchThermalMode2
Scenario: VAN30137_TestStep09_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "device profile"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Device'

@GamingSearchThermalMode2
Scenario: VAN30137_TestStep10_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "profile"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Device'

@GamingSearchThermalMode2
Scenario: VAN30137_TestStep11_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "fan speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Device'

@GamingSearchThermalMode2
Scenario: VAN30137_TestStep12_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Device'

@GamingSearchThermalMode2
Scenario: VAN30137_TestStep13_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "cooling control"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Device'

@GamingSearchThermalMode2
Scenario: VAN30137_TestStep14_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "temperature"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Device'

@GamingSearchThermalMode2
Scenario: VAN30137_TestStep15_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "silent"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Device'

@GamingSearchThermalMode2
Scenario: VAN30137_TestStep16_Check Thermal mode settings popup should be opened in the homepage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Thermal mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage