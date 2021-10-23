@CheckHPDCheckboxDC
Feature: VFC1143_HPDCheckboxQuickRegressionTestTwo
	Test Case： https://jira.tc.lenovo.com/browse/VFC-1143
	Author：HaiYe Li

@CheckHPDCheckboxDC
Scenario: VFC1143_TestStep08_Check The Note Bellow The Checkbox "Override Windows screen timeout settings" 
	Given change ThinkPad machine to DC condition
	Given wait 1 seconds
	Given Select DisplayAC to 0 minutes
    Given Select DisplayDC to 1 minutes
	Given Go to Smart Assist page
	Given Scroll To Zero Touch Lock Section
	Then This Tip Show The Description '$.SmartAssist.SmartAssistScreenTimeoutDescNoNever'
	Given change ThinkPad machine to AC condition

@CheckHPDCheckboxDC
Scenario: VFC1143_TestStep10_Check The Note Bellow The Checkbox "Override Windows screen timeout settings"
	Given change ThinkPad machine to DC condition
	Given wait 1 seconds
	Given Select DisplayAC to 1 minutes
    Given Select DisplayDC to 0 minutes
	Given Go to Smart Assist page
	Given Scroll To Zero Touch Lock Section
	Then This Tip Show The Description '$.SmartAssist.SmartAssistScreenTimeoutDescNeverOnBattery'
	Given change ThinkPad machine to AC condition
