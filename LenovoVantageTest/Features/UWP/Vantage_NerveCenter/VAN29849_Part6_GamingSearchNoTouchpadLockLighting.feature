Feature: VAN29849_Part6_GamingSearchNoTouchpadLockLighting
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29849
	Author: Yang Liu
	Test steps: 51-66

Background: 
	Given Machine is Gaming

@GamingSearchNoTP
Scenario: VAN29849_TestStep51_Check the search result no Touchpad Lock
	Given The Machine Type is DT or NB 'DT'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Touchpad"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Touchpad Lock' Category Is 'null'

@GamingSearchNoTP
Scenario: VAN29849_TestStep52_Check the search result no Touchpad Lock
	Given The Machine Type is DT or NB 'DT'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Lock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Touchpad Lock' Category Is 'null'

@GamingSearchNoTP
Scenario: VAN29849_TestStep53_Check the search result no Touchpad Lock
	Given The Machine Type is DT or NB 'DT'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "touch"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Touchpad Lock' Category Is 'null'

@GamingSearchNoTP
Scenario: VAN29849_TestStep54_Check the search result no Touchpad Lock
	Given The Machine Type is DT or NB 'DT'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "mistaken input"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Touchpad Lock' Category Is 'null'

@GamingSearchNoTP
Scenario: VAN29849_TestStep55_Check the search result no Touchpad Lock
	Given The Machine Type is DT or NB 'DT'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "input"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Touchpad Lock' Category Is 'null'

@GamingSearchNoTP
Scenario: VAN29849_TestStep56_Check the search result no Touchpad Lock
	Given The Machine Type is DT or NB 'DT'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "TP"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Touchpad Lock' Category Is 'null'

@GamingSearchNoLighting
Scenario: VAN29849_TestStep57_Check the search result no Lighting
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Lighting" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Light"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Lighting' Category Is 'null'

@GamingSearchNoLighting
Scenario: VAN29849_TestStep58_Check the search result no Lighting
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Lighting" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Lighting"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Lighting' Category Is 'null'

@GamingSearchNoLighting
Scenario: VAN29849_TestStep59_Check the search result no Lighting
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Lighting" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Led"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Lighting' Category Is 'null'

@GamingSearchNoLighting
Scenario: VAN29849_TestStep60_Check the search result no Lighting
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Lighting" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Led light"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Lighting' Category Is 'null'
