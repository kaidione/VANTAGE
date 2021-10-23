Feature: VAN29847_Part8_GamingSearchNoDriver_VRAMOC
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29847
	Author: Xu Wei
	Test Steps: 71-80

Background:
	Given Machine is Gaming

@GamingSearchNoDriverVRAMOC
Scenario:VAN29847_TestStep71_Check the search result for VRAM
	Given 'GPU' Driver don't exist
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "VRAM"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'Device'

@GamingSearchNoDriverVRAMOC
Scenario:VAN29847_TestStep72_Check the Opened Page
	Given 'GPU' Driver don't exist
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "VRAM"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchNoDriverVRAMOC
Scenario:VAN29847_TestStep73_Check the Opened Page search result for VRAM
	Given 'GPU' Driver don't exist
	When Install 'CPU' Driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "VRAM"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'Device'

@GamingSearchNoDriverVRAMOC
Scenario:VAN29847_TestStep74_Check the Opened Page
	Given 'GPU' Driver don't exist
	When Install 'CPU' Driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "VRAM"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchNoDriverVRAMOC
Scenario:VAN29847_TestStep75_Check the Opened Page search result for VRAM
	Given 'GPU' Driver don't exist
	When Install 'CPU' Driver
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "VRAM"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'Device'

@GamingSearchNoDriverVRAMOC
Scenario:VAN29847_TestStep76_Check the Opened Page
	Given 'GPU' Driver don't exist
	When Install 'CPU' Driver
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "VRAM"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchNoDriverVRAMOC
Scenario:VAN29847_TestStep77_Check the Opened Page search result for VRAM
	When Install 'CPU' Driver
	Given 'GPU' Driver don't exist
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "VRAM"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'Device'

@GamingSearchNoDriverVRAMOC
Scenario:VAN29847_TestStep78_Check the Opened Page
	When Install 'CPU' Driver
	When Uninstall XTU Driver
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "VRAM"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage

@GamingSearchNoDriverVRAMOC
Scenario:VAN29847_TestStep79_Check the Opened Page search result for VRAM
	When Install 'CPU' Driver
	Given 'GPU' Driver don't exist
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "VRAM"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'Device'

@GamingSearchNoDriverVRAMOC
Scenario:VAN29847_TestStep80_Check the Opened Page
	When Install 'CPU' Driver
	Given 'GPU' Driver don't exist
	Given ReLaunch Vantage
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "VRAM"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'Device'
	Given Click The Searched Result
	Then Check the page go back to homepage