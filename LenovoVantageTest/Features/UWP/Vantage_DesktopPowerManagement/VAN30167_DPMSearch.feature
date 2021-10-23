Feature: VAN30167_DPMSearch
	Test Case： https://jira.tc.lenovo.com/browse/VAN-30167
	Author: Xuwei

@DPMSearch
Scenario: VAN30167_TestStep01_Check the search result
	Given The Machine support DPM
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Power"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Desktop power plan management' Category Is 'Power'

@DPMSearch
Scenario: VAN30167_TestStep02_Check the search result
	Given The Machine support DPM
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Power management"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Desktop power plan management' Category Is 'Power'

@DPMSearch
Scenario: VAN30167_TestStep03_Check the opened page
	Given The Machine support DPM
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Power"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Desktop power plan management' Category Is 'Power'
	Given Click The Searched Result
	Then The all DPM contents are showing in power settings page

@DPMSearchUnSupport
Scenario: VAN30167_TestStep04_Check the opened page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Power"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Desktop power plan management' Category Is 'null'

@DPMSearchUnSupport
Scenario: VAN30167_TestStep05_Check the opened page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Power management"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Desktop power plan management' Category Is 'null'