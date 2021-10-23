Feature: VAN18068_RemoveECMQuickRegressionTest
	Test Case： https://jira.tc.lenovo.com/browse/VAN-18068
	Author：Daqi Fang

@CheckRemoveECM
Scenario: VAN18068_TestStep1_Remove ECM feature title will changed to "Eye care mode"
	Given Machine support Remove ECM feature
	Given Go to display page
	Then Check title display with json path '$.MyDeviceSettings.DisplayAndCamera.ECMTitleText'

@CheckRemoveECM
Scenario: VAN18068_TestStep2_Remove ECM feature check text
	Given Machine support Remove ECM feature
	Given Go to display page
	Then Check text display with json path '$.MyDeviceSettings.DisplayAndCamera.ECMText'

@CheckRemoveECM @SmokeCheckRemoveECM
Scenario: VAN18068_TestStep3_User click "here" link
	Given Machine support Remove ECM feature
	Given Go to display page
	When User click 'here' link
	Then The Night Light windows will be popped up

@CheckNoRemoveECM
Scenario: VAN18068_TestStep4_Not support remove ECM faeture Check UI
	Given Machine not support Remove ECM feature
	Given Go to display page
	Then Check the New UI with the latest UISPEC