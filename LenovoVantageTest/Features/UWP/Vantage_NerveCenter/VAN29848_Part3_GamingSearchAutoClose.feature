Feature: VAN29848_Part3_GamingSearchAutoClose
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29848
	Author: Yang Liu

Background: 
	Given Machine is Gaming
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.AutoClose" is "true"

@GamingSearchAutoClose
Scenario: VAN29848_TestStep22_Check the search result Auto Close
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Auto close"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Auto Close' Category Is 'Auto Close'

@GamingSearchAutoClose
Scenario: VAN29848_TestStep23_Check the search result Auto Close
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Autoclose"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Auto Close' Category Is 'Auto Close'

@GamingSearchAutoClose
Scenario: VAN29848_TestStep24_Check the search result Auto Close
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "performance"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Auto Close' Category Is 'Auto Close'

@GamingSearchAutoClose
Scenario: VAN29848_TestStep25_Check the search result Auto Close
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "close"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Auto Close' Category Is 'Auto Close'

@GamingSearchAutoClose
Scenario: VAN29848_TestStep26_Check the search result Auto Close
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Unused apps"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Auto Close' Category Is 'Auto Close'

@GamingSearchAutoClose
Scenario: VAN29848_TestStep27_Check the search result Auto Close
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Auto recover"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Auto Close' Category Is 'Auto Close'

@GamingSearchAutoClose
Scenario: VAN29848_TestStep28_Check the search result Auto Close
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Auto Close' Category Is 'Auto Close'

@GamingSearchAutoClose
Scenario: VAN29848_TestStep29_Check the search result Auto Close
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "free up"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Auto Close' Category Is 'Auto Close'

@GamingSearchAutoClose
Scenario: VAN29848_TestStep30_Check the search result Auto Close
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "release"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Auto Close' Category Is 'Auto Close'

@GamingSearchAutoClose
Scenario: VAN29848_TestStep31_Check the search result Auto Close
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Auto close"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Auto Close' Category Is 'Auto Close'
	Given Click The Searched Result
	Then The auto close will be shown within subpage