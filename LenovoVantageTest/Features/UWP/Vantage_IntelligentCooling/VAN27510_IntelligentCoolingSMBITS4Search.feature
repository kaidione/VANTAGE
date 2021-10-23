Feature: VAN27510_IntelligentCoolingSMBITS4Search
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-27510
	Author： Huajie

@ITSSMBSearch
Scenario: VAN27510_TestStep01_Enter Thermalmode and check result
	When The user connect or disconnect WiFi on lenovo
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Thermalmode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep02_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Thermalmode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB

@ITSSMBSearch
Scenario: VAN27510_TestStep03_Enter Thermal mode and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Thermal mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep04_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Thermal mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB

@ITSSMBSearch
Scenario: VAN27510_TestStep05_Enter Thermal and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Thermal"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep06_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Thermal"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB

@ITSSMBSearch
Scenario: VAN27510_TestStep07_Enter performance and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "performance"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep08_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "performance"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB

@ITSSMBSearch
Scenario: VAN27510_TestStep09_Enter balance and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "balance"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep10_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "balance"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB

@ITSSMBSearch
Scenario: VAN27510_TestStep11_Enter quiet and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "quiet"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep12_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "quiet"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB

@ITSSMBSearch
Scenario: VAN27510_TestStep13_Enter boost and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep14_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "boost"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB

@ITSSMBSearch
Scenario: VAN27510_TestStep15_Enter Fn and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Fn"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep16_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Fn"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB

@ITSSMBSearch
Scenario: VAN27510_TestStep17_Enter Q and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Q"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep18_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Q"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB

@ITSSMBSearch
Scenario: VAN27510_TestStep19_Enter device profile and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "device profile"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep20_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "device profile"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB

@ITSSMBSearch
Scenario: VAN27510_TestStep21_Enter profile and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "profile"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep22_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "profile"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB

@ITSSMBSearch
Scenario: VAN27510_TestStep23_Enter fan speed and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "fan speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep24_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "fan speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB

@ITSSMBSearch
Scenario: VAN27510_TestStep25_Enter speed and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep26_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "speed"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB

@ITSSMBSearch
Scenario: VAN27510_TestStep27_Enter cooling control and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "cooling control"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep28_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "cooling control"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB

@ITSSMBSearch
Scenario: VAN27510_TestStep29_Enter intelligent cooling and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "intelligent cooling"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep30_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "intelligent cooling"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB

@ITSSMBSearch
Scenario: VAN27510_TestStep31_Enter extreme performance and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "extreme performance"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep32_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "extreme performance"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB

@ITSSMBSearch
Scenario: VAN27510_TestStep33_Enter battery saving and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "battery saving"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep34_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "battery saving"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB

@ITSSMBSearch
Scenario: VAN27510_TestStep35_Enter battery and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "battery"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep36_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "battery"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB

@ITSSMBSearch
Scenario: VAN27510_TestStep37_Enter ITS and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "ITS"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep38_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "ITS"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB

@ITSSMBSearch
Scenario: VAN27510_TestStep39_Enter intelligent thermal system and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "intelligent thermal system"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep40_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "intelligent thermal system"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB

@ITSSMBSearch
Scenario: VAN27510_TestStep41_Enter intelligent performance and check result
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "intelligent performance"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Then The Search Result Feature Name Is Not 'Intelligent cooling' Category Is Not 'Power'

@ITSSMBSearch
Scenario: VAN27510_TestStep42_Click search result and jump to Power page
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "intelligent performance"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Intelligent performance' Category Is 'Creator settings'
	Given Click The Searched Result
	Then Check Intelligent Cooling show for ITS4SMB