Feature: VAN29848_Part5_GamingSearchTouchpadLock&Lighting
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29848
	Author: Yang Liu
	Test steps: 43-54

Background: 
	Given Machine is Gaming

@GamingSearchTP
Scenario: VAN29848_TestStep43_Check the search result Touchpad Lock
	Given The Machine Type is DT or NB 'NB'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Touchpad"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Touchpad Lock' Category Is 'Device'

@GamingSearchTP
Scenario: VAN29848_TestStep44_Check the search result Touchpad Lock
	Given The Machine Type is DT or NB 'NB'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Lock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Touchpad Lock' Category Is 'Device'

@GamingSearchTP
Scenario: VAN29848_TestStep45_Check the search result Touchpad Lock
	Given The Machine Type is DT or NB 'NB'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "touch"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Touchpad Lock' Category Is 'Device'

@GamingSearchTP
Scenario: VAN29848_TestStep46_Check the search result Touchpad Lock
	Given The Machine Type is DT or NB 'NB'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "mistaken input"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Touchpad Lock' Category Is 'Device'

@GamingSearchTP
Scenario: VAN29848_TestStep47_Check the search result Touchpad Lock
	Given The Machine Type is DT or NB 'NB'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "input"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Touchpad Lock' Category Is 'Device'

@GamingSearchTP
Scenario: VAN29848_TestStep48_Check the search result Touchpad Lock
	Given The Machine Type is DT or NB 'NB'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "TP"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Touchpad Lock' Category Is 'Device'

@GamingSearchTP
Scenario: VAN29848_TestStep49_Check the search result Touchpad Lock
	Given The Machine Type is DT or NB 'NB'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Touchpad Lock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Touchpad Lock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchLighting
Scenario: VAN29848_TestStep50_Check the search result Lighting
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Lighting" is "desktop-tower"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Light"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Lighting' Category Is 'Lighting'

@GamingSearchLighting
Scenario: VAN29848_TestStep51_Check the search result Lighting
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Lighting" is "desktop-tower"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Lighting"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Lighting' Category Is 'Lighting'

@GamingSearchLighting
Scenario: VAN29848_TestStep52_Check the search result Lighting
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Lighting" is "desktop-tower"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Led"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Lighting' Category Is 'Lighting'

@GamingSearchLighting
Scenario: VAN29848_TestStep53_Check the search result Lighting
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Lighting" is "desktop-tower"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Led light"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Lighting' Category Is 'Lighting'

@GamingSearchLighting
Scenario: VAN29848_TestStep54_Check the search result Lighting
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Lighting" is "desktop-tower"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Lighting"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Lighting' Category Is 'Lighting'
	Given Click The Searched Result
	Then The Lighting subpage will show