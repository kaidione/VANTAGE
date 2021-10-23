Feature: VAN17995_VFC204_PrivacyGuardQuickRegressionTest
	Test Case： https://jira.tc.lenovo.com/browse/VAN-17995
	Author：Jinxin Li

@CheckPrivacyGaurd @CheckLEPrivacyGaurd @SmokeCheckPrivacyGaurd
Scenario: VAN17995_TestStep01_Check the title is 'Privacy Guard'
	Given Go to display page
	Given Click DisplayLink
	Then Check title display '$.MyDeviceSettings.DisplayAndCamera.PrivacyGuardTitle'

@CheckPrivacyGaurd @CheckLEPrivacyGaurd
Scenario: VAN17995_TestStep02_There is a toggle on the right
	Given Go to display page
	Given Click DisplayLink
	Then Take Screen Shot VAN17995_Step02 in 17995 under SettingsScreenShotResult

@CheckPrivacyGaurd @CheckLEPrivacyGaurd
Scenario: VAN17995_TestStep03_Check description content display
	Given Go to display page
	Given Click DisplayLink
	Then Check description display '$.MyDeviceSettings.DisplayAndCamera.PrivacyGuardDescriptionText'

@CheckPrivacyGaurd @CheckLEPrivacyGaurd
Scenario: VAN17995_TestStep04_Check the note content display
	Given Go to display page
	Given Click DisplayLink
	Then Check note display '$.MyDeviceSettings.DisplayAndCamera.PrivacyGuardNoteText'

@CheckPrivacyGaurd @CheckLEPrivacyGaurd
Scenario: VAN17995_TestStep05_Check checkbox
	Given Go to display page
	Given Click DisplayLink
	Then Check checkbox display '$.MyDeviceSettings.DisplayAndCamera.PrivacyGuardCBText'

@CheckPrivacyGaurd @CheckLEPrivacyGaurd
Scenario: VAN17995_TestStep06_Check the toggle is 'On'
	Given Go to display page
	Given Click DisplayLink
	Then Turn on Privacy Guard

@CheckPrivacyGaurd @CheckLEPrivacyGaurd
Scenario: VAN17995_TestStep07_Check the toggle is 'Off'
	Given Go to display page
	Given Click DisplayLink
	Then Turn off Privacy Guard

@CheckPrivacyGaurd
Scenario: VAN17995_TestStep08_Hibernate and Check the toggle is 'On'
	Given Go to display page
	Given Click DisplayLink
	Then Turn on Privacy Guard
	When Hibernate system and get ToggleState
	Then The toggle state is 'On'
	
@CheckPrivacyGaurd
Scenario: VAN17995_TestStep09_Sleep and Check the toggle is 'On'
	Given Go to display page
	Given Click DisplayLink
	Then Turn on Privacy Guard
	When Sleep system and get ToggleState
	Then The toggle state is 'On'

@CheckPrivacyGaurd @CheckLEPrivacyGaurd
Scenario: VAN17995_TestStep11_Go to other pages and back to Display page toggle is 'on'
	Given Go to display page
	Then Turn on Privacy Guard
	Given Go to input page
	Given Go to display page
	Given Click DisplayLink
	Then Check Privacy Guard toggle is 'on'

@CheckPrivacyGaurd @CheckLEPrivacyGaurd
Scenario: VAN17995_TestStep12_Close Vantage and reopen Vantage toggle is 'on'
	Given Go to display page
	Given Click DisplayLink
	Then Turn on Privacy Guard
	Given close lenovo vantage
	Given ReLaunch Lenovo Vantage
	Given Go to display page
	Given Click DisplayLink
	Then Check Privacy Guard toggle is 'on'

@CheckPrivacyGaurd @CheckLEPrivacyGaurd
Scenario: VAN17995_TestStep13_Check the checkbox is 'Selected'
	Given Go to display page
	Given Click DisplayLink
	Given Send 'Select' Checkbox

@CheckPrivacyGaurd @CheckLEPrivacyGaurd
Scenario: VAN17995_TestStep14_Check the checkbox is 'Not Selected'
	Given Go to display page
	Given Click DisplayLink
	Given Send 'Not Select' Checkbox

@CheckPrivacyGaurd 
Scenario: VAN17995_TestStep15_Hibernate and Check the checkbox is 'Selected'
	Given Go to display page
	Given Click DisplayLink
	Given Send 'Select' Checkbox
	When Hibernate system and get Checkbox ToggleState
	Then The Checkbox toggle state is 'On'

@CheckPrivacyGaurd 
Scenario: VAN17995_TestStep16_Sleep and Check the checkbox is 'Selected'
	Given Go to display page
	Given Click DisplayLink
	Given Send 'Select' Checkbox
	When Sleep system and get Checkbox ToggleState
	Then The Checkbox toggle state is 'On'

@CheckPrivacyGaurd @CheckLEPrivacyGaurd
Scenario: VAN17995_TestStep18_Go to other pages and back to Display page checkbox is 'Selected'
	Given Go to display page
	Given Click DisplayLink
	Given Send 'Select' Checkbox
	Given Go to input page
	Given Go to display page
	Given Click DisplayLink
	Then Check checkbox is 'Selected'

@CheckPrivacyGaurd @CheckLEPrivacyGaurd
Scenario: VAN17995_TestStep19_Close Vantage and reopen Vantage checkbox is 'Selected'
	Given Go to display page
	Given Click DisplayLink
	Given Send 'Select' Checkbox
	Given close lenovo vantage
	Given ReLaunch Lenovo Vantage
	Given Go to display page
	Given Click DisplayLink
	Then Check checkbox is 'Selected'

@CheckPrivacyGaurd @CheckLEPrivacyGaurd
Scenario: VAN17995_TestStep27_Turn off the Privacy Guard,The Privacy Guard display 'off' status
	Given Go to display page
	Given Click DisplayLink
	Then Turn off Privacy Guard

@CheckPrivacyGaurd @CheckLEPrivacyGaurd
Scenario: VAN17995_TestStep28_Turn On or Off Privacy guard by Toolbar,Display page should keep sync in 30s
	Given Pin toolbar to taskbar
	Given Go to display page
	Given Click DisplayLink
	When Launch toolbar
	Then Turn 'On' Privacy guard by Toolbar and Display page sync in 30s
	When Close toolbar