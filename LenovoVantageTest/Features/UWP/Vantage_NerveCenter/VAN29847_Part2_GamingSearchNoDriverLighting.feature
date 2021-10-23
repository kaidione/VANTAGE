Feature: VAN29847_Part2_GamingSearchNoDriver_Lighting
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29847
	Author: Xu Wei
	Test Steps: 11-20

Background:
	Given Machine is Gaming
	Given The Machine is X Series 'X30'
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Lighting" is "desktop-tower"

@GamingSearchNoDriverLighting
Scenario:VAN29847_TestStep11_Check the search result for Lighting
    When Uninstall Lenovo Gaming LED Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Lighting"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Lighting' Category Is 'Lighting'

@GamingSearchNoDriverLighting
Scenario:VAN29847_TestStep12_Check the Opened Page
    When Uninstall Lenovo Gaming LED Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Lighting"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Lighting' Category Is 'Lighting'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchNoDriverLighting
Scenario:VAN29847_TestStep13_Check the Opened Page search result for Lighting
    When Uninstall Lenovo Gaming LED Driver
	When Install Gaming driver
	When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Lighting"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Lighting' Category Is 'Lighting'

@GamingSearchNoDriverLighting
Scenario:VAN29847_TestStep14_Check the Opened Page
    When Uninstall Lenovo Gaming LED Driver
	Given Close Vantage
	Given Launch Vantage
	When Install Gaming driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Lighting"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Lighting' Category Is 'Lighting'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchNoDriverLighting
Scenario:VAN29847_TestStep15_Check the Opened Page search result for Lighting
    When Uninstall Lenovo Gaming LED Driver
	When Install Gaming driver
	When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Lighting"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Lighting' Category Is 'Lighting'

@GamingSearchNoDriverLighting
Scenario:VAN29847_TestStep16_Check the Opened Page
    When Uninstall Lenovo Gaming LED Driver
	When Install Gaming driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Lighting"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Lighting' Category Is 'Lighting'
	Given Click The Searched Result
	Then The Lighting subpage will show

@GamingSearchNoDriverLighting
Scenario:VAN29847_TestStep17_Check the Opened Page search result for Lighting
	When Install Gaming driver
    When Uninstall Lenovo Gaming LED Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Lighting"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Lighting' Category Is 'Lighting'

@GamingSearchNoDriverLighting
Scenario:VAN29847_TestStep18_Check the Opened Page
	When Install Gaming driver
	Given Close Vantage
	Given Launch Vantage
    When Uninstall Lenovo Gaming LED Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Lighting"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Lighting' Category Is 'Lighting'
	Given Click The Searched Result
	Then The Lighting subpage will show

@GamingSearchNoDriverLighting
Scenario:VAN29847_TestStep19_Check the Opened Page search result for Lighting
	When Install Gaming driver
    When Uninstall Lenovo Gaming LED Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Lighting"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Lighting' Category Is 'Lighting'

@GamingSearchNoDriverLighting
Scenario:VAN29847_TestStep20_Check the Opened Page
	When Install Gaming driver
    When Uninstall Lenovo Gaming LED Driver
	When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Lighting"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Lighting' Category Is 'Lighting'
	Given Click The Searched Result
	Then Check the page go back to homepage