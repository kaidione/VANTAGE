Feature: VAN30137_Part2_GamingSearchThermalMode3.0
	Test Case： https://jira.tc.lenovo.com/browse/VAN-30137
	Author: Yang Liu
	Test Steps: 17-33 

Background: 
	Given Machine is Gaming
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.ThermalMode" is "3.0"

@GamingSearchThermalMode3
Scenario: VAN30137_TestSte17_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Thermalmode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Thermal Mode'

@GamingSearchThermalMode3
Scenario: VAN30137_TestStep18_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Thermal mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Thermal Mode'

@GamingSearchThermalMode3
Scenario: VAN30137_TestStep19_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "performance"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Thermal Mode'

@GamingSearchThermalMode3
Scenario: VAN30137_TestStep20_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Balance"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Thermal Mode'

@GamingSearchThermalMode3
Scenario: VAN30137_TestStep21_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "quite"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Thermal Mode'

@GamingSearchThermalMode3
Scenario: VAN30137_TestStep22_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Thermal Mode'

@GamingSearchThermalMode3
Scenario: VAN30137_TestStep23_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Fn"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Thermal Mode'

@GamingSearchThermalMode3
Scenario: VAN30137_TestStep24_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Q"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Thermal Mode'

@GamingSearchThermalMode3
Scenario: VAN30137_TestStep25_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "device profile"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Thermal Mode'

@GamingSearchThermalMode3
Scenario: VAN30137_TestStep26_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "profile"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Thermal Mode'

@GamingSearchThermalMode3
Scenario: VAN30137_TestStep27_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "fan speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Thermal Mode'

@GamingSearchThermalMode3
Scenario: VAN30137_TestStep28_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Thermal Mode'

@GamingSearchThermalMode3
Scenario: VAN30137_TestStep29_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "cooling control"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Thermal Mode'

@GamingSearchThermalMode3
Scenario: VAN30137_TestStep30_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "temperature"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Thermal Mode'

@GamingSearchThermalMode3
Scenario: VAN30137_TestStep31_Check the search result Thermal Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "silent"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Thermal Mode'

@GamingSearchThermalMode3
Scenario: VAN30137_TestStep32_Check Thermal mode settings popup should be opened in the homepage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Thermal mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Thermal Mode'
	Given Click The Searched Result
	Then The Thermal Mode Setting popup is shown or hidden 'shown'

@GamingSearchThermalMode3
Scenario: VAN30137_TestStep33_Check Thermal mode settings popup
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Thermal mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Thermal Mode' Category Is 'Thermal Mode'
	Given Click The Searched Result
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Given Click X button in Thermal Mode Setting popup
	When Click the Minimize
	When ReLaunch Vantage
	Then The Thermal Mode Setting popup is shown or hidden 'hidden'