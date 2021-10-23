Feature: VAN29849_Part1_GamingSearchNoMacroKey
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29849
	Author: Yang Liu
	Test steps: 1-6

Background: 
	Given Machine is Gaming
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Macrokey" is "null"

@GamingSearchNoMacroKey
Scenario: VAN29849_TestStep01_Check the search result no Macro Key
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Macro key"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Macro Key' Category Is 'null'

@GamingSearchNoMacroKey
Scenario: VAN29849_TestStep02_Check the search result no Macro Key
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Macro"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Macro Key' Category Is 'null'

@GamingSearchNoMacroKey
Scenario: VAN29849_TestStep03_Check the search result no Macro Key
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Macrokey"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Macro Key' Category Is 'null'

@GamingSearchNoMacroKey
Scenario: VAN29849_TestStep04_Check the search result no Macro Key
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "key"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Macro Key' Category Is 'null'

@GamingSearchNoMacroKey
Scenario: VAN29849_TestStep05_Check the search result no Macro Key
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "keyboard"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Macro Key' Category Is 'null'

@GamingSearchNoMacroKey
Scenario: VAN29849_TestStep06_Check the search result no Macro Key
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "keystroke"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Macro Key' Category Is 'null'

