Feature: VAN4097_VFC192_HiddenKeyboardFunctions
	Test Case： https://jira.tc.lenovo.com/browse/VAN-4097
	Author: Hetty Xuan

@CheckHiddenKeyboardFunctions @CheckHiddenKeyboardFunctionsLE @SmokeCheckHiddenKeyboardFunctions
Scenario: VAN4097_TestStep01_Check hidden keyboard functions title
	Given Go to input page
	Then Check Hidden Keyboard Functions Title Display '$.InputPage.HiddenKeyboardFunctionsTitleText'

@CheckHiddenKeyboardFunctions @CheckHiddenKeyboardFunctionsLE
Scenario: VAN4097_TestStep02_Check hidden keyboard functions text
	Given Go to input page
	Then Check Hidden Keyboard Functions Text Display '$.InputPage.HiddenKeyboardFunctionsText'

@CheckHiddenKeyboardFunctions @CheckHiddenKeyboardFunctionsLE
Scenario: VAN4097_TestStep03_Check keyboard map below the text
	Given Go to input page
	Then Take Screen Shot VAN4097_Step03 in 4097 under SettingsScreenShotResult

@CheckHiddenKeyboardFunctions @CheckHiddenKeyboardFunctionsLE
Scenario: VAN4097_TestStep04_Check transparent icons on keyboard map
	Given Go to input page
	Then Take Screen Shot VAN4097_Step04 in 4097 under SettingsScreenShotResult

@CheckHiddenKeyboardFunctionsITS46 @CheckHiddenKeyboardFunctionsLE
Scenario: VAN4097_TestStep05_Check introduce the hidden Keys functions tips
	Given Go to input page
	Then Check hidden Keys functions tips and exclusive keyboard map

@CheckHiddenKeyboardFunctionsITS46
Scenario: VAN4097_TestStep06_Check exclusive keyboard map
	Given Go to input page
	Then Check hidden Keys functions tips and exclusive keyboard map

@CheckHiddenKeyboardFunctions
Scenario: VAN4097_TestStep08_Check icons and tips under keyboard map
	Given Go to input page
	Then Take Screen Shot VAN4097_Step08 in 4097 under SettingsScreenShotResult

@CheckHiddenKeyboardFunctions @CheckHiddenKeyboardFunctionsLE
Scenario: VAN4097_TestStep11_Check resize Vantage the UI should show normally
	Given Go to input page
	Then Take Screen Shot VAN4097_Step11_01 in 4097 under SettingsScreenShotResult
	When Click Vantage Maxmize Button
	Then Take Screen Shot VAN4097_Step11_02 in 4097 under SettingsScreenShotResult

@CheckHiddenKeyboardFunctions @CheckHiddenKeyboardFunctionsLE
Scenario: VAN4097_TestStep12_Check reopen Vantage the UI should show normally
	Given Go to input page
	Then Take Screen Shot VAN4097_Step12_01 in 4097 under SettingsScreenShotResult
	Given close lenovo vantage
	Given ReLaunch Lenovo Vantage
	Given Go to input page
	Then Take Screen Shot VAN4097_Step12_02 in 4097 under SettingsScreenShotResult

@CheckHiddenKeyboardFunctions
Scenario: VAN4097_TestStep13_Check change system DPI and Resolution the UI should show normally
	Given Go to input page
	Then Take Screen Shot VAN4097_Step12_01 in 4097 under SettingsScreenShotResult
	Given Change DPI to 150
	Given change resolution 1024 to 768
	Then Take Screen Shot VAN4097_Step12_02 in 4097 under SettingsScreenShotResult
	Given change resolution 1920 to 1080
	Given Change DPI to 125

@HiddenKeyboardForIdeapad
Scenario: VAN4097_TestStep19_Check ideapad don't have hidden keyboard function
	Given IdeaPad machines
	Given Go to input page
	Then No hidden keyboard feature
	Then Take Screen Shot VAN4097_Step19 in 4097 under SettingsScreenShotResult

@ThinkpadNotSupportHiddenKeyboard
Scenario: VAN4097_TestStep20_Check thinkpad not support the hidden keyboard don't have hidden keyboard function
	Given Go to input page
	Then No hidden keyboard feature
	Then Take Screen Shot VAN4097_Step20 in 4097 under SettingsScreenShotResult

@ThinkpadNotSupportHighSolution
Scenario: VAN4097_TestStep21_Check thinkpad not support high solution didn't show Fn Tab
	Given Go to input page
	Then Fn Tab is not shown
	Then Take Screen Shot VAN4097_Step21 in 4097 under SettingsScreenShotResult

@ThinkpadSupportHighSolution
Scenario: VAN4097_TestStep22_Check thinkpad support high solution show Fn Tab
	Given Go to input page
	When Scroll to Fn Tab
	Then Fn Tab is shown
	Then Check Fn Tab display '$.InputPage.HiddenKeyboardFnTabText'
	Then Take Screen Shot VAN4097_Step22 in 4097 under SettingsScreenShotResult