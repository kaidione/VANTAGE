Feature: VAN29847_Part7_GamingSearchNoDriver_X50GPUOC
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29847
	Author: Xu Wei
	Test Steps: 61-70

Background:
	Given Machine is Gaming 
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.GPUOverClock" is "true"
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.ThermalMode" is "3.0"

@GamingSearchNoDriverX50GPUOC
Scenario:VAN29847_TestStep61_Check the search result for GPU
	Given 'GPU' Driver don't exist
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Thermal Mode'

@GamingSearchNoDriverX50GPUOC
Scenario:VAN29847_TestStep62_Check the Opened Page
	Given 'GPU' Driver don't exist
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Thermal Mode'
	Given Click The Searched Result
	Then The Thermal Mode Setting popup is shown or hidden 'shown'

@GamingSearchNoDriverX50GPUOC
Scenario:VAN29847_TestStep63_Check the Opened Page search result for GPU
	Given 'GPU' Driver don't exist
	When Install 'CPU' Driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Thermal Mode'

@GamingSearchNoDriverX50GPUOC
Scenario:VAN29847_TestStep64_Check the Opened Page
	Given 'GPU' Driver don't exist
	When Install 'CPU' Driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Thermal Mode'
	Given Click The Searched Result
	Then The Thermal Mode Setting popup is shown or hidden 'shown'

@GamingSearchNoDriverX50GPUOC
Scenario:VAN29847_TestStep65_Check the Opened Page search result for GPU
	Given 'GPU' Driver don't exist
	When Install 'CPU' Driver
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Thermal Mode'

@GamingSearchNoDriverX50GPUOC
Scenario:VAN29847_TestStep66_Check the Opened Page
	Given 'GPU' Driver don't exist
	When Install 'CPU' Driver
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Thermal Mode'
	Given Click The Searched Result
	Then The Thermal Mode Setting popup is shown or hidden 'shown'

@GamingSearchNoDriverX50GPUOC
Scenario:VAN29847_TestStep67_Check the Opened Page search result for GPU
	When Install 'CPU' Driver
	Given 'GPU' Driver don't exist
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Thermal Mode'

@GamingSearchNoDriverX50GPUOC
Scenario:VAN29847_TestStep68_Check the Opened Page
	When Install 'CPU' Driver
	When Uninstall XTU Driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Thermal Mode'
	Given Click The Searched Result
	Then The Thermal Mode Setting popup is shown or hidden 'shown'

@GamingSearchNoDriverX50GPUOC
Scenario:VAN29847_TestStep69_Check the Opened Page search result for GPU
	When Install 'CPU' Driver
	Given 'GPU' Driver don't exist
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Thermal Mode'

@GamingSearchNoDriverX50GPUOC
Scenario:VAN29847_TestStep70_Check the Opened Page
	When Install 'CPU' Driver
	Given 'GPU' Driver don't exist
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Thermal Mode'
	Given Click The Searched Result
	Then The Thermal Mode Setting popup is shown or hidden 'shown'