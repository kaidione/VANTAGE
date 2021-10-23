Feature: VAN29847_Part5_GamingSearchNoDriver_RAMOC
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29847
	Author: Xu Wei
	Test Steps: 41-50

Background:
	Given Machine is Gaming
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.RAMOverClock" is "true"

@GamingSearchNoDriverRAMOC
Scenario:VAN29847_TestStep41_Check the search result for RAM
    When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Memory"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'Device'

@GamingSearchNoDriverRAMOC
Scenario:VAN29847_TestStep42_Check the Opened Page
    When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Memory"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchNoDriverRAMOC
Scenario:VAN29847_TestStep43_Check the Opened Page search result for RAM
	When Uninstall XTU Driver
	When Install Gaming driver
	When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Memory"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'Device'

@GamingSearchNoDriverRAMOC
Scenario:VAN29847_TestStep44_Check the Opened Page
	When Uninstall XTU Driver
	When Install Gaming driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Memory"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchNoDriverRAMOC
Scenario:VAN29847_TestStep45_Check the Opened Page search result for RAM
	When Uninstall XTU Driver
	When Install Gaming driver
	When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Memory"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'Device'

@GamingSearchNoDriverRAMOC
Scenario:VAN29847_TestStep46_Check the Opened Page
	When Uninstall XTU Driver
	When Install Gaming driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Memory"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchNoDriverRAMOC
Scenario:VAN29847_TestStep47_Check the Opened Page search result for RAM
	When Install Gaming driver
	When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Memory"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'Device'

@GamingSearchNoDriverRAMOC
Scenario:VAN29847_TestStep48_Check the Opened Page
	When Install Gaming driver
	When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Memory"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchNoDriverRAMOC
Scenario:VAN29847_TestStep49_Check the Opened Page search result for RAM
	When Install Gaming driver
	When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Memory"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'Device'

@GamingSearchNoDriverRAMOC
Scenario:VAN29847_TestStep50_Check the Opened Page
	When Install Gaming driver
	When Uninstall XTU Driver
	When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Memory"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage