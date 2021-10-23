Feature: VAN10164_VantageHardwareSettingsCS20KeyboardMapQuickRegression
	Test Case： https://jira.tc.lenovo.com/browse/VAN-10164
	Author： DaQi Fang

@KeyboardCS20IdeaPad
Scenario: VAN10164_TestStep01_Unsupported machine is not supported the feature
	Given Unsupported machines
	Given Go to input page
	Then It should not show the feature

@KeyboardCS16Mechins
Scenario: VAN10164_TestStep02_ThinkPad with CS16 map it should show CS16 keyboard map
	Given Go to input page
	When Check the Hidden Keyboard function
	Then Take Screen Shot VAN10164_Step02CS16KeyBoard in 10164 under SettingsScreenShotResult

@KeyboardCS20Mechins
Scenario: VAN10164_TestStep03_ThinkPad with CS20 map it should show CS20 keyboard map
	Given Go to input page
	When Check the Hidden Keyboard function
	Then Take Screen Shot VAN10164_Step03CS20KeyBoard in 10164 under SettingsScreenShotResult

@KeyboardCS20Mechins
Scenario: VAN10164_TestStep04_ThinkPad with CS20 minimize/refresh pages/reopen Vantage the keyboard map UI should not change
	Given Go to input page
	When Check the Hidden Keyboard function
	When Minimize vantage conservation mode
	Then Take Screen Shot VAN10164_Step04CS20MinsizeKeyBoard in 10164 under SettingsScreenShotResult
	When Switch vantage conservation mode
	Given Go to input page
	When Check the Hidden Keyboard function
	Then Take Screen Shot VAN10164_Step04CS20RefreshKeyBoard in 10164 under SettingsScreenShotResult
	When Relaungh vantage conservation mode
	Given Go to input page
	When Check the Hidden Keyboard function
	Then Take Screen Shot VAN10164_Step04CS20ReopenKeyBoard in 10164 under SettingsScreenShotResult

@KeyboardCS20Mechins
Scenario: VAN10164_TestStep05_ThinkPad with resize Vantage the keyboard map UI should not change
	Given Go to input page
	When Check the Hidden Keyboard function
	When Resize vantage conservation mode
	Then Take Screen Shot VAN10164_Step05CS20ResizeKeyBoard in 10164 under SettingsScreenShotResult

@KeyboardCS20LanguageKeyBoard
Scenario: VAN10164_TestStep09_ThinkPad with English the keyboard is English keyboard
	Given Set Windows First Language "en-US"
	When Relaungh vantage conservation mode
	Given Go to input page
	When Check the Hidden Keyboard function
	Then Take Screen Shot VAN10164_Step09CS20EnglishKeyBoard in 10164 under SettingsScreenShotResult

@KeyboardCS20LanguageKeyBoard
Scenario: VAN10164_TestStep10_ThinkPad with French the keyboard is French  keyboard
	Given Set Windows First Language "fr-FR"
	When Relaungh vantage conservation mode
	Given Go to input page
	When Check the Hidden Keyboard function
	Then Take Screen Shot VAN10164_Step10CS20French KeyBoard in 10164 under SettingsScreenShotResult

@KeyboardCS20LanguageKeyBoard
Scenario: VAN10164_TestStep11_ThinkPad with FrenchCanada the keyboard is French  keyboard
	Given Set Windows First Language "fr-CA"
	When Relaungh vantage conservation mode
	Given Go to input page
	When Check the Hidden Keyboard function
	Then Take Screen Shot VAN10164_Step11CS20FrenchCanada KeyBoard in 10164 under SettingsScreenShotResult

@KeyboardCS20LanguageKeyBoard
Scenario: VAN10164_TestStep12_ThinkPad with Germen the keyboard is French  keyboard
	Given Set Windows First Language "de-DE"
	When Relaungh vantage conservation mode
	Given Go to input page
	When Check the Hidden Keyboard function
	Then Take Screen Shot VAN10164_Step11CS20Germen KeyBoard in 10164 under SettingsScreenShotResult

@KeyboardCS20LanguageKeyBoard
Scenario: VAN10164_TestStep13_ThinkPad with Italiano the keyboard is French  keyboard
	Given Set Windows First Language "it-IT"
	When Relaungh vantage conservation mode
	Given Go to input page
	When Check the Hidden Keyboard function
	Then Take Screen Shot VAN10164_Step11CS20Italiano KeyBoard in 10164 under SettingsScreenShotResult

@KeyboardCS20LanguageKeyBoard
Scenario: VAN10164_TestStep14_ThinkPad with Spanish-Spain the keyboard is French  keyboard
	Given Set Windows First Language "es-ES"
	When Relaungh vantage conservation mode
	Given Go to input page
	When Check the Hidden Keyboard function
	Then Take Screen Shot VAN10164_Step11CS20Spanish-Spain KeyBoard in 10164 under SettingsScreenShotResult

@KeyboardCS20LanguageKeyBoard
Scenario: VAN10164_TestStep15_ThinkPad with Other the keyboard is French  keyboard
	Given Set Windows First Language "zh-CN"
	When Relaungh vantage conservation mode
	Given Go to input page
	When Check the Hidden Keyboard function
	Then Take Screen Shot VAN10164_Step11CS20Other KeyBoard in 10164 under SettingsScreenShotResult

@KeyboardCS20LanguageKeyBoard
Scenario: VAN10164_TestStep16_Reset language
	Given Set Windows First Language "en-US"
	
@KeyboardCS20Mechins
Scenario: VAN10164_TestStep17_ThinkPad check the hidden function tips under the keyboard map
	Given Go to input page
	When Check the FnFour
	