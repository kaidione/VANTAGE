Feature: VAN30136_Part2_GamingSearchOverClocking_X50CPU&GPUOC
	Test Case： https://jira.tc.lenovo.com/browse/VAN-30136
	Author: Yang Liu
	Test steps: 17-32

Background: 
	Given Machine is Gaming
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.ThermalMode" is "3.0"

@GamingSearchX50CPUOC
Scenario: VAN30136_TestStep17_Check the search result CPU Overclock
	When Install Gaming driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Thermal Mode'

@GamingSearchX50CPUOC
Scenario: VAN30136_TestStep18_Check the search result CPU Overclock
	When Install Gaming driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "over clock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Thermal Mode'

@GamingSearchX50CPUOC
Scenario: VAN30136_TestStep19_Check the search result CPU Overclock
	When Install Gaming driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "overclock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Thermal Mode'

@GamingSearchX50CPUOC
Scenario: VAN30136_TestStep20_Check the search result CPU Overclock
	When Install Gaming driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Thermal Mode'

@GamingSearchX50CPUOC
Scenario: VAN30136_TestStep21_Check the search result CPU Overclock
	When Install Gaming driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "maximum speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Thermal Mode'

@GamingSearchX50CPUOC
Scenario: VAN30136_TestStep22_Check the search result CPU Overclock
	When Install Gaming driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "processor"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Thermal Mode'

@GamingSearchX50CPUOC
Scenario: VAN30136_TestStep23_Check the search result CPU Overclock
	When Install Gaming driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "overclocking"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Thermal Mode'

@GamingSearchX50CPUOC
Scenario: VAN30136_TestStep24_Check the search result CPU Overclock
	When Install Gaming driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU Overclock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'Thermal Mode'
	Given Click The Searched Result
	Then The Thermal Mode Setting popup is shown or hidden 'shown'

@GamingSearchX50GPUOC
Scenario: VAN30136_TestStep25_Check the search result GPU Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Thermal Mode'

@GamingSearchX50GPUOC
Scenario: VAN30136_TestStep26_Check the search result GPU Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "over clock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Thermal Mode'

@GamingSearchX50GPUOC
Scenario: VAN30136_TestStep27_Check the search result GPU Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "overclock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Thermal Mode'

@GamingSearchX50GPUOC
Scenario: VAN30136_TestStep28_Check the search result GPU Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Thermal Mode'

@GamingSearchX50GPUOC
Scenario: VAN30136_TestStep29_Check the search result GPU Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "maximum speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Thermal Mode'

@GamingSearchX50GPUOC
Scenario: VAN30136_TestStep30_Check the search result GPU Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "processor"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Thermal Mode'

@GamingSearchX50GPUOC
Scenario: VAN30136_TestStep31_Check the search result GPU Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "overclocking"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Thermal Mode'

@GamingSearchX50GPUOC
Scenario: VAN30136_TestStep32_Check the search result GPU Overclock
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU Overclock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Thermal Mode'
	Given Click The Searched Result
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
