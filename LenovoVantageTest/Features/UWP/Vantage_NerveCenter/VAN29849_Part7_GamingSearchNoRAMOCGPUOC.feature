Feature: VAN29849_Part7_GamingSearchNoRAMOCGPUOC
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29849
	Author: Yang Liu
	Test steps: 67-80

Background: 
	Given Machine is Gaming

@GamingSearchNoRAMOC
Scenario: VAN29849_TestStep61_Check the search result no RAM Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.RAMOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "RAM"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'null'

@GamingSearchNoRAMOC
Scenario: VAN29849_TestStep62_Check the search result no RAM Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.RAMOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "over clock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'null'

@GamingSearchNoRAMOC
Scenario: VAN29849_TestStep63_Check the search result no RAM Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.RAMOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "overclock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'null'

@GamingSearchNoRAMOC
Scenario: VAN29849_TestStep64_Check the search result no RAM Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.RAMOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'null'

@GamingSearchNoRAMOC
Scenario: VAN29849_TestStep65_Check the search result no RAM Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.RAMOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "maximum speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'null'

@GamingSearchNoRAMOC
Scenario: VAN29849_TestStep66_Check the search result no RAM Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.RAMOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "memory"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'null'

@GamingSearchNoRAMOC
Scenario: VAN29849_TestStep67_Check the search result no RAM Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.RAMOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "overclocking"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'RAM Overclock' Category Is 'null'

@GamingSearchNoGPUOC
Scenario: VAN29849_TestStep68_Check the search result no GPU Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.GPUOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'null'

@GamingSearchNoGPUOC
Scenario: VAN29849_TestStep69_Check the search result no GPU Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.GPUOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "over clock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'null'

@GamingSearchNoGPUOC
Scenario: VAN29849_TestStep70_Check the search result no GPU Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.GPUOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "overclock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'null'

@GamingSearchNoGPUOC
Scenario: VAN29849_TestStep71_Check the search result no GPU Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.GPUOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'null'

@GamingSearchNoGPUOC
Scenario: VAN29849_TestStep72_Check the search result no GPU Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.GPUOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "maximum speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'null'

@GamingSearchNoGPUOC
Scenario: VAN29849_TestStep73_Check the search result no GPU Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.GPUOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "processor"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'null'

@GamingSearchNoGPUOC
Scenario: VAN29849_TestStep74_Check the search result no GPU Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.GPUOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "overclocking"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'null'
