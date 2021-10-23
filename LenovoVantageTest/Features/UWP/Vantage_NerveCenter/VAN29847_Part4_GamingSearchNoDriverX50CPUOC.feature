Feature: VAN29847_Part2_GamingSearchNoDriver_X50CPUOC
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29847
	Author: Xu Wei
	Test Steps: 31-40

Background:
	Given Machine is Gaming 
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.CPUOverClock" is "true"
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.ThermalMode" is "3.0"

@GamingSearchNoDriverX50CPUOC
Scenario:VAN29847_TestSte31_Check the search result for CPU
    When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Thermal Mode'

@GamingSearchNoDriverX50CPUOC
Scenario:VAN29847_TestStep32_Check the Opened Page
    When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Thermal Mode'
	Given Click The Searched Result
	Then The Thermal Mode Setting popup is shown or hidden 'shown'

@GamingSearchNoDriverX50CPUOC
Scenario:VAN29847_TestStep33_Check the Opened Page search result for CPU
	When Uninstall XTU Driver
	When Install Gaming driver
	When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Thermal Mode'

@GamingSearchNoDriverX50CPUOC
Scenario:VAN29847_TestStep34_Check the Opened Page
	When Uninstall XTU Driver
	When Install Gaming driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Thermal Mode'
	Given Click The Searched Result
	Then The Thermal Mode Setting popup is shown or hidden 'shown'

@GamingSearchNoDriverX50CPUOC
Scenario:VAN29847_TestStep35_Check the Opened Page search result for CPU
	When Uninstall XTU Driver
	When Install Gaming driver
	When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Thermal Mode'

@GamingSearchNoDriverX50CPUOC
Scenario:VAN29847_TestStep36_Check the Opened Page
	When Uninstall XTU Driver
	When Install Gaming driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Thermal Mode'
	Given Click The Searched Result
	Then The Thermal Mode Setting popup is shown or hidden 'shown'

@GamingSearchNoDriverX50CPUOC
Scenario:VAN29847_TestStep37_Check the Opened Page search result for CPU
	When Install Gaming driver
	When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Thermal Mode'

@GamingSearchNoDriverX50CPUOC
Scenario:VAN29847_TestStep38_Check the Opened Page
	When Install Gaming driver
	When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Thermal Mode'
	Given Click The Searched Result
	Then The Thermal Mode Setting popup is shown or hidden 'shown'

@GamingSearchNoDriverX50CPUOC
Scenario:VAN29847_TestStep39_Check the Opened Page search result for CPU
	When Install Gaming driver
	When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Thermal Mode'

@GamingSearchNoDriverX50CPUOC
Scenario:VAN29847_TestStep40_Check the Opened Page
	When Install Gaming driver
	When Uninstall XTU Driver
	When Enter hibernate
    When Wait '300' seconds until the machine enters the system
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Thermal Mode'
	Given Click The Searched Result
	Then The Thermal Mode Setting popup is shown or hidden 'shown'