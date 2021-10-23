Feature: VAN29847_Part1_GamingSearchNoDriver_Network Boost
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29847
	Author: Xu Wei
	Test Steps: 1-10

Background:
	Given Machine is Gaming
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.NetworkBoost" is "true"

@GamingSearchNoDriverNB
Scenario:VAN29847_TestStep01_Check the search result for Network Boost
	When Uninstall Lenovo Gaming NetFilter Device Driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Network"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'

@GamingSearchNoDriverNB
Scenario:VAN29847_TestStep02_Check the Opened Page
	When Uninstall Lenovo Gaming NetFilter Device Driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Network"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchNoDriverNB
Scenario:VAN29847_TestStep03_Check the Opened Page search result for Network Boost
	When Uninstall Lenovo Gaming NetFilter Device Driver
	When Install Gaming driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Network"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'

@GamingSearchNoDriverNB
Scenario:VAN29847_TestStep04_Check the Opened Page
	When Uninstall Lenovo Gaming NetFilter Device Driver
	Given Close Vantage
	Given Launch Vantage
	When Install Gaming driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Network"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchNoDriverNB
Scenario:VAN29847_TestStep05_Check the Opened Page search result for Network Boost
	When Uninstall Lenovo Gaming NetFilter Device Driver
	When Install Gaming driver
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Network"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'

@GamingSearchNoDriverNB
Scenario:VAN29847_TestStep06_Check the Opened Page
	When Uninstall Lenovo Gaming NetFilter Device Driver
	When Install Gaming driver
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Network"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'
	Given Click The Searched Result
	Then jump to network boost subpage

@GamingSearchNoDriverNB
Scenario:VAN29847_TestStep07_Check the Opened Page search result for Network Boost
	When Install Gaming driver
	When Uninstall Lenovo Gaming NetFilter Device Driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Network"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'

@GamingSearchNoDriverNB
Scenario:VAN29847_TestStep08_Check the Opened Page
	When Install Gaming driver
	Given Close Vantage
	Given Launch Vantage
	When Uninstall Lenovo Gaming NetFilter Device Driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Network"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'
	Given Click The Searched Result
	Then jump to network boost subpage

@GamingSearchNoDriverNB
Scenario:VAN29847_TestStep09_Check the Opened Page search result for Network Boost
	When Install Gaming driver
	When Uninstall Lenovo Gaming NetFilter Device Driver
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Network"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'

@GamingSearchNoDriverNB
Scenario:VAN29847_TestStep10_Check the Opened Page
	When Install Gaming driver
	When Uninstall Lenovo Gaming NetFilter Device Driver
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Network"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Network Boost' Category Is 'Network Boost'
	Given Click The Searched Result
	Then Check the page go back to homepage