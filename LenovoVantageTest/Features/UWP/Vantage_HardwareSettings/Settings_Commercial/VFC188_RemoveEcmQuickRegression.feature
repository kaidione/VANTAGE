Feature: VFC188_RemoveEcmQuickRegression
	Test Case： https://jira.tc.lenovo.com/browse/VFC-188
	Author: DaQi Fang

@CheckRemoveECMLe
Scenario: VFC188_Step01 title is 'Display color temperature'
	Given Go to display page
	Then Check the title is "Display color temperature"

@CheckRemoveECMLe
Scenario: VFC188_Step02 check the description 
	Given Go to display page
	Then Check the description is '$.MyDeviceSettings.DisplayAndCamera.RemoveECMDescription'

@CheckRemoveECMLe
Scenario: VFC188_Step03 There should no "Location permission" windows pupup 
	Given Uninstall the lenovo vatage
	Given Install Vantage 
	Given Go to display page
	Given wait 10 seconds
	Then Take Screen Shot 03RemoveEyeCareModeLe in 188 under HSScreenShotResult

@CheckRemoveECMLe
Scenario: VFC188_TestStep5_User click "here" link
	Given Go to display page
	When User click 'here' link
	Then The Night Light windows will be popped up