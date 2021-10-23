Feature: VAN29847_Part6_GamingSearchNoDriver_X60GPUOC
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29847
	Author: Xu Wei
	Test Steps: 51-60

Background:
	Given Machine is Gaming 
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.GPUOverClock" is "true"
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.ThermalMode" is "4.0"

@GamingSearchNoDriverX60GPUOC
Scenario:VAN29847_TestStep51_Check the search result for GPU
	Given 'GPU' Driver don't exist
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Device'

@GamingSearchNoDriverX60GPUOC
Scenario:VAN29847_TestStep52_Check the Opened Page
	Given 'GPU' Driver don't exist
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchNoDriverX60GPUOC
Scenario:VAN29847_TestStep53_Check the Opened Page search result for GPU
	Given 'GPU' Driver don't exist
	When Install 'CPU' Driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Device'

@GamingSearchNoDriverX60GPUOC
Scenario:VAN29847_TestStep54_Check the Opened Page
	Given 'GPU' Driver don't exist
	When Install 'CPU' Driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchNoDriverX60GPUOC
Scenario:VAN29847_TestStep55_Check the Opened Page search result for GPU
	Given 'GPU' Driver don't exist
	When Install 'CPU' Driver
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Device'

@GamingSearchNoDriverX60GPUOC
Scenario:VAN29847_TestStep56_Check the Opened Page
	Given 'GPU' Driver don't exist
	When Install 'CPU' Driver
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchNoDriverX60GPUOC
Scenario:VAN29847_TestStep57_Check the Opened Page search result for GPU
	When Install 'CPU' Driver
	Given 'GPU' Driver don't exist
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Device'

@GamingSearchNoDriverX60GPUOC
Scenario:VAN29847_TestStep58_Check the Opened Page
	When Install 'CPU' Driver
	When Uninstall XTU Driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchNoDriverX60GPUOC
Scenario:VAN29847_TestStep59_Check the Opened Page search result for GPU
	When Install 'CPU' Driver
	Given 'GPU' Driver don't exist
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Device'

@GamingSearchNoDriverX60GPUOC
Scenario:VAN29847_TestStep60_Check the Opened Page
	When Install 'CPU' Driver
	Given 'GPU' Driver don't exist
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "GPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'GPU Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage