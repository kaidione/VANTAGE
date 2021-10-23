Feature: VAN29848_Part4_GamingSearchHybridMode&OverDrive
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29848
	Author: Yang Liu
	Test steps: 32-42

Background: 
	Given Machine is Gaming

@GamingSearchHybridMode
Scenario: VAN29848_TestStep32_Check the search result Hybrid Mode
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.HybridMode" is "true"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Hybrid Mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Hybrid Mode' Category Is 'Device'

@GamingSearchHybridMode
Scenario: VAN29848_TestStep33_Check the search result Hybrid Mode
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.HybridMode" is "true"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Hybrid"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Hybrid Mode' Category Is 'Device'

@GamingSearchHybridMode
Scenario: VAN29848_TestStep34_Check the search result Hybrid Mode
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.HybridMode" is "true"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Advanced GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Hybrid Mode' Category Is 'Device'

@GamingSearchHybridMode
Scenario: VAN29848_TestStep35_Check the search result Hybrid Mode
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.HybridMode" is "true"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Hybrid Mode' Category Is 'Device'

@GamingSearchHybridMode
Scenario: VAN29848_TestStep36_Check the search result Hybrid Mode
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.HybridMode" is "true"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Hybrid Mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Hybrid Mode' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchOverDrive
Scenario: VAN29848_TestStep37_Check the search result Over Drive
	Then Over drive capability value is 1
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Over Drive"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Over Drive' Category Is 'Device'

@GamingSearchOverDrive
Scenario: VAN29848_TestStep38_Check the search result Over Drive
	Then Over drive capability value is 1
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "screen"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Over Drive' Category Is 'Device'

@GamingSearchOverDrive
Scenario: VAN29848_TestStep39_Check the search result Over Drive
	Then Over drive capability value is 1
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "drive"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Over Drive' Category Is 'Device'

@GamingSearchOverDrive
Scenario: VAN29848_TestStep40_Check the search result Over Drive
	Then Over drive capability value is 1
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "fast"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Over Drive' Category Is 'Device'

@GamingSearchOverDrive
Scenario: VAN29848_TestStep41_Check the search result Over Drive
	Then Over drive capability value is 1
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "panel"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Over Drive' Category Is 'Device'

@GamingSearchOverDrive
Scenario: VAN29848_TestStep42_Check the search result Over Drive
	Then Over drive capability value is 1
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Over Drive"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Over Drive' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage