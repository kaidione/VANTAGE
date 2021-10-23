Feature: VAN29847_Part3_GamingSearchNoDriver_OldCPUOC
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29847
	Author: Xu Wei
	Test Steps: 21-30

Background:
	Given Machine is Gaming
	Given The Machine is X Series 'X30'
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.CPUOverClock" is "true"

@GamingSearchNoDriverOldCPUOC
Scenario:VAN29847_TestStep21_Check the search result for CPU
    When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Device'

@GamingSearchNoDriverOldCPUOC
Scenario:VAN29847_TestStep22_Check the Opened Page
    When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchNoDriverOldCPUOC
Scenario:VAN29847_TestStep23_Check the Opened Page search result for CPU
	When Uninstall XTU Driver
	When Install Gaming driver
	When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Device'

@GamingSearchNoDriverOldCPUOC
Scenario:VAN29847_TestStep24_Check the Opened Page
	When Uninstall XTU Driver
	When Install Gaming driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchNoDriverOldCPUOC
Scenario:VAN29847_TestStep25_Check the Opened Page search result for CPU
	When Uninstall XTU Driver
	When Install Gaming driver
	When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Device'

@GamingSearchNoDriverOldCPUOC
Scenario:VAN29847_TestStep26_Check the Opened Page
	When Uninstall XTU Driver
	When Install Gaming driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchNoDriverOldCPUOC
Scenario:VAN29847_TestStep27_Check the Opened Page search result for CPU
	When Install Gaming driver
	When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Device'

@GamingSearchNoDriverOldCPUOC
Scenario:VAN29847_TestStep28_Check the Opened Page
	When Install Gaming driver
	When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchNoDriverOldCPUOC
Scenario:VAN29847_TestStep29_Check the Opened Page search result for CPU
	When Install Gaming driver
	When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Device'

@GamingSearchNoDriverOldCPUOC
Scenario:VAN29847_TestStep30_Check the Opened Page
	When Install Gaming driver
	When Uninstall XTU Driver
	When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage