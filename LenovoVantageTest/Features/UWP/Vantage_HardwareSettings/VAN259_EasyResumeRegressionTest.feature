Feature: VAN259_VFC209_EasyResumeRegressionTest
	Test Case： https://jira.tc.lenovo.com/browse/VAN-259
	Author：Jinxin Li

@CheckEasyResume @SmokeCheckEasyResume
Scenario: VAN259_TestStep01_Check Easy Resume UI Elements
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Then Check Easy Resume UI Elements

@CheckEasyResume
Scenario: VAN259_TestStep02_Check Easy Resume Question Mark ToolTip display Text
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Given Click Easy Resume Question Mark
	Then Check Easy Resume Question Mark ToolTip display '$.PowerPage.EasyResumeQuestionMarkToolTipText'

@CheckEasyResume
Scenario: VAN259_TestStep05_Check Easy Resume status
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Given Turn On Easy Resume
	Given Click Dashboard Link
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Then  Easy Resume status is 'On'

@CheckEasyResume
Scenario: VAN259_TestStep06_Check Hibernate system Easy Resume toggle state is 'On'
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Given Turn On Easy Resume
	When Hibernate system and get Easy Resume ToggleState
	Then The Easy Resume toggle state is 'On'
	When Sleep system and get Easy Resume ToggleState
	Then The Easy Resume toggle state is 'On'
	Given Turn Off Easy Resume
	When Hibernate system and get Easy Resume ToggleState
	Then The Easy Resume toggle state is 'Off'
	When Sleep system and get Easy Resume ToggleState
	Then The Easy Resume toggle state is 'Off'