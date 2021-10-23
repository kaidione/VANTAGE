Feature: VAN29849_Part8_GamingSearchNoCPUOCVRAMOC
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29849
	Author: Yang Liu
	Test steps: 81-94

Background: 
	Given Machine is Gaming

@GamingSearchNoCPUOC
Scenario: VAN29849_TestStep75_Check the search result no CPU Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.CPUOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "CPU"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'null'

@GamingSearchNoCPUOC
Scenario: VAN29849_TestStep76_Check the search result no CPU Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.CPUOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "over clock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'null'

@GamingSearchNoCPUOC
Scenario: VAN29849_TestStep77_Check the search result no CPU Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.CPUOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "overclock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'null'

@GamingSearchNoCPUOC
Scenario: VAN29849_TestStep78_Check the search result no CPU Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.CPUOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'null'

@GamingSearchNoCPUOC
Scenario: VAN29849_TestStep79_Check the search result no CPU Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.CPUOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "maximum speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'null'

@GamingSearchNoCPUOC
Scenario: VAN29849_TestStep80_Check the search result no CPU Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.CPUOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "processor"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'null'

@GamingSearchNoCPUOC
Scenario: VAN29849_TestStep81_Check the search result no CPU Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.CPUOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "overclocking"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'CPU Overclock' Category Is 'null'

@GamingSearchNoVRAMOC
Scenario: VAN29849_TestStep82_Check the search result no VRAM Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.VRAMOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "VRAM"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'null'

@GamingSearchNoVRAMOC
Scenario: VAN29849_TestStep83_Check the search result no VRAM Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.VRAMOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "over clock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'null'

@GamingSearchNoVRAMOC
Scenario: VAN29849_TestStep84_Check the search result no VRAM Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.VRAMOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "overclock"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'null'

@GamingSearchNoVRAMOC
Scenario: VAN29849_TestStep85_Check the search result no VRAM Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.VRAMOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'null'

@GamingSearchNoVRAMOC
Scenario: VAN29849_TestStep86_Check the search result no VRAM Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.VRAMOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "maximum speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'null'

@GamingSearchNoVRAMOC
Scenario: VAN29849_TestStep87_Check the search result no VRAM Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.VRAMOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "processor"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'null'

@GamingSearchNoVRAMOC
Scenario: VAN29849_TestStep88_Check the search result no VRAM Overclock
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.VRAMOverClock" is "null"
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "overclocking"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'VRAM Overclock' Category Is 'null'
