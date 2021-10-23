Feature: VFC182_BatteryConditiononThinkPadTwo
	Test Case： https://jira.tc.lenovo.com/browse/VFC-182
	Author: DaQi Fang

Background:
	Given Backup Vantage Power Settings INI File
	
@CheckBatteryConditionOnThinkPadNoBatteryLE
Scenario: VFC182_TestStep07_No Battery Detected Check Icon Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Good'
	Given Go to My Device Settings page
	Then Check Display 'Red' Icon
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionOnThinkPadNoBatteryLE
Scenario: VFC182_TestStep08_No Battery Detected Check Tip Text Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Good'
	Given Go to My Device Settings page
	Then Check No Battery Tip Text Display
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionOnThinkPadNoBatteryLE
Scenario: VFC182_TestStep09_No Battery Detected Check QuestionMark Icon And Text Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Good'
	Given Go to My Device Settings page
	Then Check QuestionMark Icon And Text Display
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionOnThinkPadNoBatteryLE
Scenario: VFC182_TestStep10_No Battery Detected The Color of Battery Gauge Outline Should be Red
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Good'
	Given Go to My Device Settings page
	Then Take Screen Shot VFC182_Step10 in 7343 under SettingsScreenShotResult
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionLEACDC
Scenario: VFC182_TestStep28 ACDC hidden
	Given Go to Power Page
	When User make the machine from AC to DC
	Then The AcDcIconTip is hidden

@CheckBatteryConditionLEACDC
Scenario: VFC182_TestStep29 AC DC show
	Given Go to Power Page
	Given AC Condition(Connect the Adapter)
	Then The "AcDcIcon" is show
	Given Waiting 30 seconds
	Then The "AcDcIconTip" is show

@CheckBatteryConditionOnThinkPad45WLE
Scenario: VFC182_TestStep32_Clear 45w adapter 
	Given Go to Power Page
	Given "Open" DischargeStatus
	Then The message "$.PowerPage.FullACAdapterSupportTextTitle" in battery component
	When wait 3 seconds
	Then The "45 W" message is show
	Given "Close" DischargeStatus

@CheckBatteryConditionOnThinkPad65WLE
Scenario: VFC182_TestStep33_Clear 65w adapter 
	Given Go to Power Page
	Given "Open" DischargeStatus
	Then The message "$.PowerPage.FullACAdapterSupportTextTitle" in battery component
	When wait 3 seconds
	Then The "65 W" message is show
	Given "Close" DischargeStatus

@CheckBatteryConditionOnThinkPad95WLE
Scenario: VFC182_TestStep34_Clear 95w adapter 
	Given Go to Power Page
	Given "Open" DischargeStatus
	Then The message "$.PowerPage.FullACAdapterSupportTextTitle" in battery component
	When wait 3 seconds
	Then The "95 W" message is show
	Given "Close" DischargeStatus

@CheckBatteryConditionOnThinkPad135WLE
Scenario: VFC182_TestStep35_Clear 135w adapter 
	Given Go to Power Page
	Given "Open" DischargeStatus
	Then The message "$.PowerPage.FullACAdapterSupportTextTitle" in battery component
	When wait 3 seconds
	Then The "135 W" message is show
	Given "Close" DischargeStatus

@CheckBatteryConditionOnThinkPad170WLE
Scenario: VFC182_TestStep36_Clear 170w adapter 
	Given Go to Power Page
	Given "Open" DischargeStatus
	Then The message "$.PowerPage.FullACAdapterSupportTextTitle" in battery component
	When wait 3 seconds
	Then The "170 W" message is show
	Given "Close" DischargeStatus

@CheckBatteryConditionOnThinkPad230WLE
Scenario: VFC182_TestStep37_Clear 230w adapter 
	Given Go to Power Page
	Given "Open" DischargeStatus
	Then The message "$.PowerPage.FullACAdapterSupportTextTitle" in battery component
	When wait 3 seconds
	Then The "230 W" message is show
	Given "Close" DischargeStatus