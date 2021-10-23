@CheckHPDCheckbox
Feature: VFC1143_HPDCheckboxQuickRegressionTest
	Test Case： https://jira.tc.lenovo.com/browse/VFC-1143
	Author：HaiYe Li

@CheckHPDCheckbox
Scenario: VFC1143_TestStep01_Check Show a Checkbox "Override Windows screen timeout settings"
	Given Go to Smart Assist page
	Given Scroll To Zero Touch Lock Section
	Then Show Checkbox Override Windows Screen Timeout Settings

@CheckHPDCheckbox
Scenario: VFC1143_TestStep02_Uninstall LE and Install LE Check The Checkbox Default State Is Checked
	Given Uninstall the lenovo vatage
	When Wait 1 minutes
	Given Install Vantage
	Given Go to Smart Assist page
	Given Scroll To Zero Touch Lock Section
	Then Zero Touch Lock Section Checkbox is 'Checked'

@CheckHPDCheckbox
Scenario: VFC1143_TestStep03_Click The link "Windows screen time-out settings"
	Given Go to Smart Assist page
	Given Scroll To Zero Touch Lock Section
	Given Turn 'On' The Toggle of Zero Touch Lock
	Given Click Windows Screen time-out Settings Link
	Then Check Windows Settings Power and Sleep Page Is Open
	Then Take Screen Shot VFC1143_Step03 in 1143 under SettingsScreenShotResult

@CheckHPDCheckbox
Scenario: VFC1143_TestStep04_Turn off The Toggle of Zero Touch Lock Checkbox and The Context Should be Grayed Out
	Given Go to Smart Assist page
	Given Scroll To Zero Touch Lock Section
	Given Turn 'On' The Toggle of Zero Touch Lock
	Given 'On' Zero Touch Lock Section Checkbox
	Given Turn 'Off' The Toggle of Zero Touch Lock
	Then The Checkbox And The Context Should be Grayed Out
	Given Turn 'On' The Toggle of Zero Touch Lock
	Given 'Off' Zero Touch Lock Section Checkbox
	Given Turn 'Off' The Toggle of Zero Touch Lock
	Then The Checkbox And The Context Should be Grayed Out
	Given Turn 'On' The Toggle of Zero Touch Lock
	Given 'On' Zero Touch Lock Section Checkbox

@CheckHPDCheckbox
Scenario: VFC1143_TestStep05_Check The Note Bellow The Checkbox "Override Windows screen timeout settings"
	Given Select DisplayAC to 3 minutes
    Given Select DisplayDC to 3 minutes
	Given change ThinkPad machine to DC condition
	Given Go to Smart Assist page
	Given Scroll To Zero Touch Lock Section
	Then This Tip Show The Description '$.SmartAssist.SmartAssistScreenTimeoutDescNoNever'
	Given change ThinkPad machine to AC condition

@CheckHPDCheckbox
Scenario: VFC1143_TestStep06_Check The Note Bellow The Checkbox "Override Windows screen timeout settings"
	Given Select DisplayAC to 0 minutes
    Given Select DisplayDC to 0 minutes
	Given change ThinkPad machine to DC condition
	Given Go to Smart Assist page
	Given Scroll To Zero Touch Lock Section
	Then This Tip Show The Description '$.SmartAssist.SmartAssistScreenTimeoutDescNever'
	Given change ThinkPad machine to AC condition

@CheckHPDCheckbox
Scenario: VFC1143_TestStep07_Check The Note Bellow The Checkbox "Override Windows screen timeout settings"
	Given Select DisplayAC to 0 minutes
    Given Select DisplayDC to 0 minutes
	Given change ThinkPad machine to AC condition
	Given Go to Smart Assist page
	Given Scroll To Zero Touch Lock Section
	Then This Tip Show The Description '$.SmartAssist.SmartAssistScreenTimeoutDescNever'

@CheckHPDCheckbox
Scenario: VFC1143_TestStep09_Check The Note Bellow The Checkbox "Override Windows screen timeout settings" 
	Given Select DisplayAC to 0 minutes
    Given Select DisplayDC to 1 minutes
	Given change ThinkPad machine to AC condition
	Given Scroll To Zero Touch Lock Section
	Given Go to Smart Assist page
	Then This Tip Show The Description '$.SmartAssist.SmartAssistScreenTimeoutDescNeverOnPlugged'

@CheckHPDCheckbox
Scenario: VFC1143_TestStep11_Check The Note Bellow The Checkbox "Override Windows screen timeout settings"
	Given Select DisplayAC to 1 minutes
    Given Select DisplayDC to 0 minutes
	Given Go to Smart Assist page
	Given Scroll To Zero Touch Lock Section
	Given change ThinkPad machine to AC condition
	Then This Tip Show The Description '$.SmartAssist.SmartAssistScreenTimeoutDescNoNever'
