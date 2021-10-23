Feature: VAN29849_Part5_GamingSearchNoHybridModeOverDrive
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29849
	Author: Yang Liu
	Test steps: 42-50

Background: 
	Given Machine is Gaming

@GamingSearchNoHybridMode
Scenario: VAN29849_TestStep42_Check the search result no Hybrid Mode
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.HybridMode" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Hybrid Mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Hybrid Mode' Category Is 'null'

@GamingSearchNoHybridMode
Scenario: VAN29849_TestStep43_Check the search result no Hybrid Mode
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.HybridMode" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Hybrid"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Hybrid Mode' Category Is 'null'

@GamingSearchNoHybridMode
Scenario: VAN29849_TestStep44_Check the search result no Hybrid Mode
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.HybridMode" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Advanced GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Hybrid Mode' Category Is 'null'

@GamingSearchNoHybridMode
Scenario: VAN29849_TestStep45_Check the search result no Hybrid Mode
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.HybridMode" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Hybrid Mode' Category Is 'null'

@GamingSearchNoOverDrive
Scenario: VAN29849_TestStep46_Check the search result no Over Drive
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.OverDrive" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Over Drive"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Over Drive' Category Is 'null'

@GamingSearchNoOverDrive
Scenario: VAN29849_TestStep47_Check the search result no Over Drive
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.OverDrive" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "screen"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Over Drive' Category Is 'null'

@GamingSearchNoOverDrive
Scenario: VAN29849_TestStep48_Check the search result no Over Drive
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.OverDrive" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "drive"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Over Drive' Category Is 'null'

@GamingSearchNoOverDrive
Scenario: VAN29849_TestStep49_Check the search result no Over Drive
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.OverDrive" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "fast"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Over Drive' Category Is 'null'

@GamingSearchNoOverDrive
Scenario: VAN29849_TestStep50_Check the search result no Over Drive
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.OverDrive" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "panel"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Over Drive' Category Is 'null'
