Feature: VAN14018_VFC1860_KeyboardTopRowForIdeaPadQuickRegression
	Test Case： https://jira.tc.lenovo.com/browse/VAN-14018
	Author：Daqi Fang

@CheckKeyboardTopRowForIdeaPad @SmokeCheckKeyboardTopRowForIdeaPad
Scenario: VAN14018_TestStep01_Check The UI of Keyboard top-row function Title
	Given Go to input page
	Then Check Display Keyboard top-row function Title
	Then Check Title Display '$.InputPage.KeyboardTopRowFunctionTitleText'

@CheckKeyboardTopRowForIdeaPad
Scenario: VAN14018_TestStep02_Check The UI of Keyboard top-row function Description
	Given Go to input page
	Then Check Display Keyboard top-row function Description
	Then Check Description Display '$.InputPage.KeyboardTopRowFunctionDescriptionText'

@CheckKeyboardTopRowForIdeaPad
Scenario: VAN14018_TestStep03_Two Buttons Under The Description
	Given Go to input page
	Then Check Two Buttons Under The Description

@CheckKeyboardTopRowForIdeaPad
Scenario: VAN14018_TestStep04_Click 'Special function' Button Display Tip
	Given Go to input page
	Given Select 'Special function' Button
	Then Check Tip Text Display '$.InputPage.KeyboardTopRowFunctionTip1Text'

@CheckKeyboardTopRowForIdeaPad
Scenario: VAN14018_TestStep05_Click 'F1-F12 function' Button Display Tip
	Given Go to input page
	Given Select 'F1-F12 function' Button
	Then Check Tip Text Display '$.InputPage.KeyboardTopRowFunctionTip2Text'

@CheckKeyboardTopRowForIdeaPad
Scenario: VAN14018_TestStep06_Click 'Special function' Button The Button Is Highlighted
	Given Go to input page
	Given Select 'Special function' Button
	Then Check Button 'Special function' Is Highlighted

@CheckKeyboardTopRowForIdeaPad
Scenario: VAN14018_TestStep07_Click 'F1-F12 function' Button The Button Is Highlighted
	Given Go to input page
	Given Select 'F1-F12 function' Button
	Then Check Button 'F1-F12 function' Is Highlighted

@CheckKeyboardTopRowForIdeaPad
Scenario: VAN14018_TestStep08_Reopen Vantage The UI Should Not Change
	Given Go to input page
	Given Select 'Special function' Button
	Then Check Button 'Special function' Is Highlighted
	Given close lenovo vantage
	Given ReLaunch Lenovo Vantage
	Given Go to input page
	Then Check Button 'Special function' Is Highlighted
	Then Keyboard top-row function UI Elements Not Change

@CheckKeyboardTopRowForIdeaPad
Scenario: VAN14018_TestStep09_Resize Vantage The UI Should Not Change
	Given Go to input page
	Given Select 'Special function' Button
	Then Check Button 'Special function' Is Highlighted
	When Click Vantage Maxmize Button
	Then Check Button 'Special function' Is Highlighted
	Then Keyboard top-row function UI Elements Not Change

@CheckKeyboardTopRowForIdeaPad
Scenario: VAN14018_TestStep10_Change System DPI and Resolution The UI Should Not Change
	Given Go to input page
	Given Select 'Special function' Button
	Then Check Button 'Special function' Is Highlighted
	Given Change DPI to 150
	Given change resolution 1024 to 768
	Then Check Button 'Special function' Is Highlighted
	Then Keyboard top-row function UI Elements Not Change
	Given change resolution 2560 to 1600
	Given Change DPI to 200