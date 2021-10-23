Feature: VAN30136_Part1_GamingSearchOverClocking_RAM&OldCPUOC
	Test Case： https://jira.tc.lenovo.com/browse/VAN-30136
	Author: Yang Liu
	Test steps:1-16

Background: 
	Given Machine is Gaming
	Given driver is installed

@GamingSearchRAMOC
Scenario: VAN30136_TestStep01_Check the search result RAM Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "RAM"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'Device'

@GamingSearchRAMOC
Scenario: VAN30136_TestStep02_Check the search result RAM Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "over clock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'Device'

@GamingSearchRAMOC
Scenario: VAN30136_TestStep03_Check the search result RAM Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "overclock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'Device'

@GamingSearchRAMOC
Scenario: VAN30136_TestStep04_Check the search result RAM Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'Device'

@GamingSearchRAMOC
Scenario: VAN30136_TestStep05_Check the search result RAM Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "maximum speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'Device'

@GamingSearchRAMOC
Scenario: VAN30136_TestStep06_Check the search result RAM Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "memory"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'Device'

@GamingSearchRAMOC
Scenario: VAN30136_TestStep07_Check the search result RAM Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "overclocking"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'Device'

@GamingSearchRAMOC
Scenario: VAN30136_TestStep08_Check the search result RAM Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "RAM Overclock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchOldCPUOC
Scenario: VAN30136_TestStep9_Check the search result CPU Overclock
	Given The Machine is X Series 'X30'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Device'

@GamingSearchOldCPUOC
Scenario: VAN30136_TestStep10_Check the search result CPU Overclock
	Given The Machine is X Series 'X30'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "over clock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Device'

@GamingSearchOldCPUOC
Scenario: VAN30136_TestStep11_Check the search result CPU Overclock
	Given The Machine is X Series 'X30'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "overclock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Device'

@GamingSearchOldCPUOC
Scenario: VAN30136_TestStep12_Check the search result CPU Overclock
	Given The Machine is X Series 'X30'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Device'

@GamingSearchOldCPUOC
Scenario: VAN30136_TestStep13_Check the search result CPU Overclock
	Given The Machine is X Series 'X30'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "maximum speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Device'

@GamingSearchOldCPUOC
Scenario: VAN30136_TestStep14_Check the search result CPU Overclock
	Given The Machine is X Series 'X30'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "processor"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Device'

@GamingSearchOldCPUOC
Scenario: VAN30136_TestStep15_Check the search result CPU Overclock
	Given The Machine is X Series 'X30'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "overclocking"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Device'

@GamingSearchOldCPUOC
Scenario: VAN30136_TestStep16_Check the search result CPU Overclock
	Given The Machine is X Series 'X30'
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU Overclock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage