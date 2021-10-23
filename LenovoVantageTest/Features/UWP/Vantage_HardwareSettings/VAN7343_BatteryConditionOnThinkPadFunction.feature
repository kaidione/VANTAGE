Feature: VAN7343_VFC182_BatteryConditionOnThinkPadFunction
	Test Case： https://jira.tc.lenovo.com/browse/VAN-7343
	Author：Pengjie Chen

Background:
	Given Backup Vantage Power Settings INI File

@CheckBatteryConditionOnThinkPad
Scenario: VAN7343_TestStep01_When Battery Is In Good Condition Check Icon Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Good'
	Given Go to My Device Settings page
	Then Check Display 'Green' Icon
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionOnThinkPad
Scenario: VAN7343_TestStep02_When Battery Is In Good Condition Check Tip Text Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Good'
	Given Go to My Device Settings page
	Then Check 'Good Condition' Tip Text Display
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionOnThinkPad
Scenario: VAN7343_TestStep03_When Battery Is In Fair Condition Check Icon Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Fair'
	Given Go to My Device Settings page
	Then Check Display 'Yellow' Icon
	Given Delete Vantage Power Settings INI File
	
@CheckBatteryConditionOnThinkPad
Scenario: VAN7343_TestStep04_When Battery Is In Fair Condition Check Tip Text Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Fair'
	Given Go to My Device Settings page
	Then Check 'Fair Condition' Tip Text Display
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionOnThinkPad
Scenario: VAN7343_TestStep05_When Battery Is In Poor Condition Check Icon Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Poor'
	Given Go to My Device Settings page
	Then Check Display 'Red' Icon
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionOnThinkPad
Scenario: VAN7343_TestStep06_When Battery Is In Poor Condition Check Tip Text Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Poor'
	Given Go to My Device Settings page
	Then Check 'Poor Condition' Tip Text Display
	Given Delete Vantage Power Settings INI File
	
@CheckBatteryConditionOnThinkPadNoBattery
Scenario: VAN7343_TestStep07_No Battery Detected Check Icon Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Good'
	Given Go to My Device Settings page
	Then Check Display 'Red' Icon
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionOnThinkPadNoBattery
Scenario: VAN7343_TestStep08_No Battery Detected Check Tip Text Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Good'
	Given Go to My Device Settings page
	Then Check No Battery Tip Text Display
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionOnThinkPadNoBattery
Scenario: VAN7343_TestStep09_No Battery Detected Check QuestionMark Icon And Text Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Good'
	Given Go to My Device Settings page
	Then Check QuestionMark Icon And Text Display
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionOnThinkPadNoBattery
Scenario: VAN7343_TestStep10_No Battery Detected The Color of Battery Gauge Outline Should be Red
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Good'
	Given Go to My Device Settings page
	Then Take Screen Shot VAN7343_Step10 in 7343 under SettingsScreenShotResult
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionOnThinkPad
Scenario: VAN7343_TestStep11_When Battery Is In Missing Driver Condition Check Icon Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Missing Driver'
	Given Go to My Device Settings page
	Then Check Display 'Red' Icon
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionOnThinkPad
Scenario: VAN7343_TestStep12_When Battery Is In Missing Driver Condition Check Tip Text Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Missing Driver'
	Given Go to My Device Settings page
	Then Check 'Missing Driver' Tip Text Display
	Given Delete Vantage Power Settings INI File
	
@CheckBatteryConditionOnThinkPad
Scenario: VAN7343_TestStep13_When Battery Is In Missing Driver Condition Check Button Can Not Click
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Missing Driver'
	Given Go to My Device Settings page
	Then Check Battery Detail Button Can Not Click
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionOnThinkPad
Scenario: VAN7343_TestStep21_When Battery Is In Permanent Error Condition
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Permanent error'
	Given Go to My Device Settings page
	Then Check Display 'Red' Icon
	Then Check 'Permanent Error' Tip Text Display
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionOnThinkPad
Scenario: VAN7343_TestStep22_When Battery Is In High Temperature Condition
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'High temperature'
	Given Go to My Device Settings page
	Then Check Display 'Yellow' Icon
	Then Check 'High Temperature' Tip Text Display
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionOnThinkPad
Scenario: VAN7343_TestStep23_When Battery Is In Trickle Charge Condition
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Trickle charge'
	Given Go to My Device Settings page
	Then Check Display 'Yellow' Icon
	Then Check 'Trickle Charge' Tip Text Display
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionOnThinkPad
Scenario: VAN7343_TestStep24_When Battery Is In Over Heated Condition
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Over heated'
	Given Go to My Device Settings page
	Then Check Display 'Yellow' Icon
	Then Check 'Over Heated' Tip Text Display
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionOnThinkPad
Scenario: VAN7343_TestStep25_When Battery Is In HW Authentication Error Condition
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'HW authentication error'
	Given Go to My Device Settings page
	Then Check Display 'Yellow' Icon
	Then Check 'HW Authentication Error' Tip Text Display
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionOnThinkPad
Scenario: VAN7343_TestStep33_ACDC GreenIcon
	Given Go to Power Page
	Then The "AcDcIcon" is show
	Then Take Screen Shot VAN7343_TestStep126ACDCICON in van7343 under SettingscreenShotResult

@CheckBatteryConditionOnThinkPad
Scenario: VAN7343_TestStep34_ACDC GreenIcon Tip
	Given Go to Power Page
	Then The "AcDcIconTip" is show

@CheckBatteryConditionOnThinkPadAcDc
Scenario:  VAN7343_TestStep35 Dc element is hidden
	Given Go to Power Page
	When User make the machine from AC to DC
	Then The AcDcIconTip is hidden

@CheckBatteryConditionOnThinkPadAcDc
Scenario:  VAN7343_TestStep36 AC element is show
	Given Go to Power Page
	Given AC Condition(Connect the Adapter)
	Then The "AcDcIcon" is show
	Given Waiting 30 seconds
	Then The "AcDcIconTip" is show

@CheckBatteryConditionOnThinkPad
Scenario: VAN7343_TestStep37_Restore Vantage Power Settings INI File
	Then Restore Vantage Power Settings INI File

@CheckBatteryConditionOnThinkPad
Scenario: VAN7343_TestStep38_Clear Battery Condition Alert
	Then Clear Battery Condition Alert

@CheckBatteryConditionOnThinkPad45W
Scenario: VAN7343_TestStep40_Clear 45w adapter 
	Given Go to Power Page
	Given "Open" DischargeStatus
	Then The message "$.PowerPage.FullACAdapterSupportTextTitle" in battery component
	When wait 3 seconds
	Then The "45 W" message is show
	Given "Close" DischargeStatus

@CheckBatteryConditionOnThinkPad65W
Scenario: VAN7343_TestStep41_Clear 65w adapter 
	Given Go to Power Page
	Given "Open" DischargeStatus
	Then The message "$.PowerPage.FullACAdapterSupportTextTitle" in battery component
	When wait 3 seconds
	Then The "65 W" message is show
	Given "Close" DischargeStatus

@CheckBatteryConditionOnThinkPad95W
Scenario: VAN7343_TestStep42_Clear 95w adapter 
	Given Go to Power Page
	Given "Open" DischargeStatus
	Then The message "$.PowerPage.FullACAdapterSupportTextTitle" in battery component
	When wait 3 seconds
	Then The "95 W" message is show
	Given "Close" DischargeStatus

@CheckBatteryConditionOnThinkPad135W
Scenario: VAN7343_TestStep43_Clear 135w adapter 
	Given Go to Power Page
	Given "Open" DischargeStatus
	Then The message "$.PowerPage.FullACAdapterSupportTextTitle" in battery component
	When wait 3 seconds
	Then The "135 W" message is show
	Given "Close" DischargeStatus

@CheckBatteryConditionOnThinkPad170W
Scenario: VAN7343_TestStep44_Clear 170w adapter 
	Given Go to Power Page
	Given "Open" DischargeStatus
	Then The message "$.PowerPage.FullACAdapterSupportTextTitle" in battery component
	When wait 3 seconds
	Then The "170 W" message is show
	Given "Close" DischargeStatus

@CheckBatteryConditionOnThinkPad230W
Scenario: VAN7343_TestStep45_Clear 230w adapter 
	Given Go to Power Page
	Given "Open" DischargeStatus
	Then The message "$.PowerPage.FullACAdapterSupportTextTitle" in battery component
	When wait 3 seconds
	Then The "230 W" message is show
	Given "Close" DischargeStatus