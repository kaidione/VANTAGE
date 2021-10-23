Feature: VAN29849_Part4_GamingSearchNoAutoClose
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29849
	Author: Yang Liu
	Test steps: 34-41

@GamingSearchNoAutoClose
Scenario: VAN29849_TestStep34_Check the search result no Auto Close
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Auto close"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Auto Close' Category Is 'null'

@GamingSearchNoAutoClose
Scenario: VAN29849_TestStep35_Check the search result no Auto Close
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Autoclose"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Auto Close' Category Is 'null'

@GamingSearchNoAutoClose
Scenario: VAN29849_TestStep36_Check the search result no Auto Close
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "performance"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Auto Close' Category Is 'null'

@GamingSearchNoAutoClose
Scenario: VAN29849_TestStep37_Check the search result no Auto Close
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "close"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Auto Close' Category Is 'null'

@GamingSearchNoAutoClose
Scenario: VAN29849_TestStep38_Check the search result no Auto Close
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Unused apps"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Auto Close' Category Is 'null'

@GamingSearchNoAutoClose
Scenario: VAN29849_TestStep39_Check the search result no Auto Close
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Auto Close' Category Is 'null'

@GamingSearchNoAutoClose
Scenario: VAN29849_TestStep40_Check the search result no Auto Close
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "free up"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Auto Close' Category Is 'null'

@GamingSearchNoAutoClose
Scenario: VAN29849_TestStep41_Check the search result no Auto Close
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Auto recover"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Auto Close' Category Is 'null'
