Feature: VAN30136_Part3_GamingSearchOverclocking_X60GPUVRAMOC
	Test Case： https://jira.tc.lenovo.com/browse/VAN-30136
	Author: Yang Liu
	Test steps: 33-48

Background: 
	Given Machine is Gaming
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.ThermalMode" is "4.0"

@GamingSearchX60GPUOC
Scenario: VAN30136_TestStep33_Check the search result GPU Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Device'

@GamingSearchX60GPUOC
Scenario: VAN30136_TestStep34_Check the search result GPU Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "over clock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Device'

@GamingSearchX60GPUOC
Scenario: VAN30136_TestStep35_Check the search result GPU Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "overclock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Device'

@GamingSearchX60GPUOC
Scenario: VAN30136_TestStep36_Check the search result GPU Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Device'

@GamingSearchX60GPUOC
Scenario: VAN30136_TestStep37_Check the search result GPU Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "maximum speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Device'

@GamingSearchX60GPUOC
Scenario: VAN30136_TestStep38_Check the search result GPU Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "processor"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Device'

@GamingSearchX60GPUOC
Scenario: VAN30136_TestStep39_Check the search result GPU Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "overclocking"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Device'

@GamingSearchX60GPUOC
Scenario: VAN30136_TestStep40_Check the search result GPU Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU Overclock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchVRAMOC
Scenario: VAN30136_TestStep41_Check the search result VRAM Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "VRAM"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'Device'

@GamingSearchVRAMOC
Scenario: VAN30136_TestStep42_Check the search result VRAM Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "over clock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'Device'

@GamingSearchVRAMOC
Scenario: VAN30136_TestStep43_Check the search result VRAM Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "overclock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'Device'

@GamingSearchVRAMOC
Scenario: VAN30136_TestStep44_Check the search result VRAM Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'Device'

@GamingSearchVRAMOC
Scenario: VAN30136_TestStep45_Check the search result VRAM Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "maximum speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'Device'

@GamingSearchVRAMOC
Scenario: VAN30136_TestStep46_Check the search result VRAM Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "processor"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'Device'

@GamingSearchVRAMOC
Scenario: VAN30136_TestStep47_Check the search result VRAM Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "overclocking"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'Device'

@GamingSearchVRAMOC
Scenario: VAN30136_TestStep48_Check the search result VRAM Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "VRAM Overclock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage