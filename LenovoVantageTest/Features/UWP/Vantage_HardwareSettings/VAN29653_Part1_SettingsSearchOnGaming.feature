Feature: VAN29653_Part1_SettingsSearchOnGaming
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29653
	Author: Haiye Li

@SettingsSearchPowerPageGamingself
Scenario: VAN29653_TestStep01_Check the search No result Smart standby
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Modern Standby"
	Given Click The Search Button
	Then The Search Result Is Null
	
@SettingsSearchPowerPageGamingself
Scenario: VAN29653_TestStep02_Check the search result Power settings
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Power settings"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Always on USB' Category Is 'Power'
	
@SettingsSearchPowerPageGamingself
Scenario: VAN29653_TestStep03_Check the search result Power settings
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Power settings"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Always on USB' Category Is 'Power'
	Given Click The Searched Result
	Then The Device settings power page is opened
	
@SettingsSearchPowerPageGamingself
Scenario: VAN29653_TestStep04_Check the search result Always on USB
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Always on USB"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Always on USB' Category Is 'Power'
	
@SettingsSearchPowerPageGamingself
Scenario: VAN29653_TestStep05_Check the search result Always on USB
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Always on USB"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Always on USB' Category Is 'Power'
	Given Click The Searched Result
	Then The Device settings power page is opened
	
@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep06_Check the search No result Airplane Power Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Airplane Power Mode"
	Given Click The Search Button
	Then The Search Result Is Null

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep07_Check the search No result Battery settings
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Battery settings"
	Given Click The Search Button
	Then The Search Result Is Null
	
@SettingsSearchPowerPageGamingself
Scenario: VAN29653_TestStep08_Check the search result Energy Star
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Energy Star"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Energy star' Category Is 'Power'

@SettingsSearchPowerPageGamingself
Scenario: VAN29653_TestStep09_Check the search result Energy Star
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Energy Star"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Energy star' Category Is 'Power'
	Given Click The Searched Result
	Then The Device settings power page is opened
	
@SettingsSearchPowerPageGamingself
Scenario: VAN29653_TestStep10_Check the search result Conservation Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Conservation Mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Conservation mode' Category Is 'Power'

@SettingsSearchPowerPageGamingself
Scenario: VAN29653_TestStep11_Check the search result Conservation Mode
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Conservation Mode"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Conservation mode' Category Is 'Power'
	Given Click The Searched Result
	Then The Device settings power page is opened
		
@SettingsSearchPowerPageGamingself
Scenario: VAN29653_TestStep12_Check the search result Rapid charge
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Express charge"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Rapid charge' Category Is 'Power'

@SettingsSearchPowerPageGamingself
Scenario: VAN29653_TestStep13_Check the search result Rapid charge
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Express charge"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Rapid charge' Category Is 'Power'
	Given Click The Searched Result
	Then The Device settings power page is opened

@SettingsSearchPowerPageGamingself
Scenario: VAN29653_TestStep14_Check the search result Rapid charge
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Rapid charge"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Rapid charge' Category Is 'Power'

@SettingsSearchPowerPageGamingself
Scenario: VAN29653_TestStep15_Check the search result Rapid charge
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Rapid charge"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Rapid charge' Category Is 'Power'
	Given Click The Searched Result
	Then The Device settings power page is opened

@SettingsSearchSmartFlipToBootPowerPageGaming
Scenario: VAN29653_TestStep16_Check the search result Smart flip to boot
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Smart Flip to Boot"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Smart flip to boot' Category Is 'Power'

@SettingsSearchSmartFlipToBootPowerPageGaming
Scenario: VAN29653_TestStep17_Check the search result Smart flip to boot
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Smart Flip to Boot"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Smart flip to boot' Category Is 'Power'
	Given Click The Searched Result
	Then The Device settings power page is opened

@SettingsSearchSmartFlipToBootPowerPageGaming
Scenario: VAN29653_TestStep18_Check the search result Smart flip to boot
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Flip to Boot"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Smart flip to boot' Category Is 'Power'

@SettingsSearchSmartFlipToBootPowerPageGaming
Scenario: VAN29653_TestStep19_Check the search result Smart flip to boot
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Flip to Boot"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Smart flip to boot' Category Is 'Power'
	Given Click The Searched Result
	Then The Device settings power page is opened

@SettingsSearchPowerPageGamingself
Scenario: VAN29653_TestStep20_Check the search result Vantage toolbar
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Vantage Toolbar"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Vantage toolbar' Category Is 'Power'

@SettingsSearchPowerPageGamingself
Scenario: VAN29653_TestStep21_Check the search result Vantage toolbar
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Vantage Toolbar"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Vantage toolbar' Category Is 'Power'
	Given Click The Searched Result
	Then The Device settings power page is opened

@SettingsSearchPowerPageGamingself
Scenario: VAN29653_TestStep22_Check the search result Vantage toolbar
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "quick settings"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Vantage toolbar' Category Is 'Power'

@SettingsSearchPowerPageGamingself
Scenario: VAN29653_TestStep23_Check the search result Vantage toolbar
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "quick settings"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Vantage toolbar' Category Is 'Power'
	Given Click The Searched Result
	Then The Device settings power page is opened

@SettingsSearchPowerPageGamingself
Scenario: VAN29653_TestStep24_Check the search result Vantage toolbar
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "quick controls"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Vantage toolbar' Category Is 'Power'

@SettingsSearchPowerPageGamingself
Scenario: VAN29653_TestStep25_Check the search result Vantage toolbar
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "quick controls"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Vantage toolbar' Category Is 'Power'
	Given Click The Searched Result
	Then The Device settings power page is opened

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep26_Check the search result Vantage toolbar
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Dolby Effects"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Dolby audio' Category Is 'Audio'

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep27_Check the search result Dolby audio
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Dolby Effects"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Dolby audio' Category Is 'Audio'
	Given Click The Searched Result
	Then My Device settings-Audio page is opened

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep28_Check the search result Dolby audio
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "optimize audio for VoIP"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Dolby audio' Category Is 'Audio'

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep29_Check the search result Dolby audio
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "optimize audio for VoIP"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Dolby audio' Category Is 'Audio'
	Given Click The Searched Result
	Then My Device settings-Audio page is opened

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep30_Check the search result Dolby audio
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "optimize audio for entertainment"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Dolby audio' Category Is 'Audio'

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep31_Check the search result Dolby audio
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "optimize audio for entertainment"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Dolby audio' Category Is 'Audio'
	Given Click The Searched Result
	Then My Device settings-Audio page is opened

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep32_Check the search result Dolby audio
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Dolby profiles"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Dolby audio' Category Is 'Audio'

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep33_Check the search result Dolby audio
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Dolby profiles"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Dolby audio' Category Is 'Audio'
	Given Click The Searched Result
	Then My Device settings-Audio page is opened

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep34_Check the search result Dolby audio
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Dolby audio"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Dolby audio' Category Is 'Audio'

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep35_Check the search result Dolby audio
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Dolby audio"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Dolby audio' Category Is 'Audio'
	Given Click The Searched Result
	Then My Device settings-Audio page is opened

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep36_Check the search result Microphone settings
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Microphone volume"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Microphone settings' Category Is 'Audio'

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep37_Check the search result Microphone settings
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Microphone volume"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Microphone settings' Category Is 'Audio'
	Given Click The Searched Result
	Then My Device settings-Audio page is opened

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep38_Check the search result Microphone settings
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Acoustic Echo cancellation"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Microphone settings' Category Is 'Audio'

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep39_Check the search result Microphone settings
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Acoustic Echo cancellation"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Microphone settings' Category Is 'Audio'
	Given Click The Searched Result
	Then My Device settings-Audio page is opened

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep40_Check the search result Microphone settings
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "microphone effects"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Microphone settings' Category Is 'Audio'

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep41_Check the search result Microphone settings
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "microphone effects"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Microphone settings' Category Is 'Audio'
	Given Click The Searched Result
	Then My Device settings-Audio page is opened

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep42_Check the search result Microphone settings
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "voice recognition"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Microphone settings' Category Is 'Audio'

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep43_Check the search result Microphone settings
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "voice recognition"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Microphone settings' Category Is 'Audio'
	Given Click The Searched Result
	Then My Device settings-Audio page is opened

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep44_Check the search result Microphone settings
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "only my voice"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Microphone settings' Category Is 'Audio'

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep45_Check the search result Microphone settings
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "only my voice"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Microphone settings' Category Is 'Audio'
	Given Click The Searched Result
	Then My Device settings-Audio page is opened

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep46_Check the search result Microphone settings
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "multiple voice"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Microphone settings' Category Is 'Audio'

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep47_Check the search result Microphone settings
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "multiple voice"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Microphone settings' Category Is 'Audio'
	Given Click The Searched Result
	Then My Device settings-Audio page is opened

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep48_Check the search result Microphone settings
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "microphone"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Microphone settings' Category Is 'Audio'

@SettingsSearchPowerPageGaming
Scenario: VAN29653_TestStep49_Check the search result Microphone settings
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "microphone"
	Given Click The Search Button
	Then The Search Result Feature Name Is 'Microphone settings' Category Is 'Audio'
	Given Click The Searched Result
	Then My Device settings-Audio page is opened

@SettingsSearchPowerPageGamingself
Scenario: VAN29653_TestStep50_Check the search No result Microphone settings
	Given Enter Search Page By Click The Search Icon In The Navigation Bar
	Given Type in "Interactive E-course mode"
	Given Click The Search Button
	Then The Search Result Is Null
