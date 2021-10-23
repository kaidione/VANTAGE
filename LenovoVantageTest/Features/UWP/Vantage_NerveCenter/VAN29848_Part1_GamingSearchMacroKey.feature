Feature: VAN29848_Part1_GamingSearchMacroKey
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29848
	Author: Yang Liu
	Test steps: 1-9

Background: 
	Given Machine is Gaming
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Macrokey" is "true"

@GamingSearch
Scenario: VAN29848_TestStep01_Check the Search icon
	Then Check The Search Icon
	Given Open Vantage to the home page

@GamingSearchMacroKey
Scenario: VAN29848_TestStep02_Check the search result Macro Key
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Macro key"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Macro Key' Category Is 'Macro Key'

@GamingSearchMacroKey
Scenario: VAN29848_TestStep03_Check the search result Macro Key
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Macro"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Macro Key' Category Is 'Macro Key'

@GamingSearchMacroKey
Scenario: VAN29848_TestStep04_Check the search result Macro Key
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Macrokey"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Macro Key' Category Is 'Macro Key'

@GamingSearchMacroKey
Scenario: VAN29848_TestStep05_Check the search result Macro Key
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "key"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Macro Key' Category Is 'Macro Key'

@GamingSearchMacroKey
Scenario: VAN29848_TestStep06_Check the search result Macro Key
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "keyboard"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Macro Key' Category Is 'Macro Key'

@GamingSearchMacroKey
Scenario: VAN29848_TestStep07_Check the search result Macro Key
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "keystroke"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Macro Key' Category Is 'Macro Key'

@GamingSearchMacroKey
Scenario: VAN29848_TestStep08_Check Macro key should be opened
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "keystroke"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Macro Key' Category Is 'Macro Key'
	Given Click The Searched Result
	Then Macro Key Should Be Opened
