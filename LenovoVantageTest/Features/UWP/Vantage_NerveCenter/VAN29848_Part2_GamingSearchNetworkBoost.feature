Feature: VAN29848_Part2_GamingSearchNetworkBoost
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29848
	Author: Yang Liu
	Test steps: 9-21

Background: 
	Given Machine is Gaming
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.NetworkBoost" is "true"

@GamingSearchNetworkBoost
Scenario: VAN29848_TestStep9_Check the search result Network Boost
	Given Machine support Network boost
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Network"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'

@GamingSearchNetworkBoost
Scenario: VAN29848_TestStep10_Check the search result Network Boost
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Network boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'

@GamingSearchNetworkBoost
Scenario: VAN29848_TestStep11_Check the search result Network Boost
	Given Machine support Network boost
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'

@GamingSearchNetworkBoost
Scenario: VAN29848_TestStep12_Check the search result Network Boost
	Given Machine support Network boost
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Network traffic"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'

@GamingSearchNetworkBoost
Scenario: VAN29848_TestStep13_Check the search result Network Boost
	Given Machine support Network boost
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "traffic"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'

@GamingSearchNetworkBoost
Scenario: VAN29848_TestStep14_Check the search result Network Boost
	Given Machine support Network boost
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'

@GamingSearchNetworkBoost
Scenario: VAN29848_TestStep15_Check the search result Network Boost
	Given Machine support Network boost
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Network speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'

@GamingSearchNetworkBoost
Scenario: VAN29848_TestStep16_Check the search result Network Boost
	Given Machine support Network boost
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'

@GamingSearchNetworkBoost
Scenario: VAN29848_TestStep17_Check the search result Network Boost
	Given Machine support Network boost
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "bandwidth"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'

@GamingSearchNetworkBoost
Scenario: VAN29848_TestStep18_Check the search result Network Boost
	Given Machine support Network boost
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "white list"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'

@GamingSearchNetworkBoost
Scenario: VAN29848_TestStep19_Check the search result Network Boost
	Given Machine support Network boost
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "fast"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'

@GamingSearchNetworkBoost
Scenario: VAN29848_TestStep20_Check the search result Network Boost
	Given Machine support Network boost
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "prioritize"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'

@GamingSearchNetworkBoost
Scenario: VAN29848_TestStep21_Check the search result Network Boost
	Given Machine support Network boost
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Network boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'
	Given Click The Searched Result
	Then jump to network boost subpage