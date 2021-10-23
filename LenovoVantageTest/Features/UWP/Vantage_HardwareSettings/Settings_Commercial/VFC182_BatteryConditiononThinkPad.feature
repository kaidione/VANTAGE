@CheckBatteryConditionLE
Feature: VFC182_BatteryConditiononThinkPad 
	Test Case： https://jira.tc.lenovo.com/browse/VFC-182
	Author: DaQi Fang

Background:
	Given Backup Vantage Power Settings INI File

@CheckBatteryConditionLE
Scenario: VFC182_TestStep01_When Battery Is In Good Condition Check Icon Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Good'
	Given Go to My Device Settings page
	Then Check Display 'Green' Icon
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionLE
Scenario: VFC182_TestStep02_When Battery Is In Good Condition Check Tip Text Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Good'
	Given Go to My Device Settings page
	Then Check 'Good Condition' Tip Text Display
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionLE
Scenario: VFC182_TestStep03_When Battery Is In Fair Condition Check Icon Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Fair'
	Given Go to My Device Settings page
	Then Check Display 'Yellow' Icon
	Given Delete Vantage Power Settings INI File
	
@CheckBatteryConditionLE
Scenario: VFC182_TestStep04_When Battery Is In Fair Condition Check Tip Text Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Fair'
	Given Go to My Device Settings page
	Then Check 'Fair Condition' Tip Text Display
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionLE
Scenario: VFC182_TestStep05_When Battery Is In Poor Condition Check Icon Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Poor'
	Given Go to My Device Settings page
	Then Check Display 'Red' Icon
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionLE
Scenario: VFC182_TestStep06_When Battery Is In Poor Condition Check Tip Text Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Poor'
	Given Go to My Device Settings page
	Then Check 'Poor Condition' Tip Text Display
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionLE
Scenario: VFC182_TestStep11_When Battery Is In Missing Driver Condition Check Icon Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Missing Driver'
	Given Go to My Device Settings page
	Then Check Display 'Red' Icon
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionLE
Scenario: VFC182_TestStep12_When Battery Is In Missing Driver Condition Check Tip Text Display
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Missing Driver'
	Given Go to My Device Settings page
	Then Check 'Missing Driver' Tip Text Display
	Given Delete Vantage Power Settings INI File
	
@CheckBatteryConditionLE
Scenario: VFC182_TestStep13_When Battery Is In Missing Driver Condition Check Button Can Not Click
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Missing Driver'
	Given Go to My Device Settings page
	Then Check Battery Detail Button Can Not Click
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionLE
Scenario: VFC182_TestStep21_When Battery Is In Permanent Error Condition
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Permanent error'
	Given Go to My Device Settings page
	Then Check Display 'Red' Icon
	Then Check 'Permanent Error' Tip Text Display
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionLE
Scenario: VFC182_TestStep22_When Battery Is In High Temperature Condition
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'High temperature'
	Given Go to My Device Settings page
	Then Check Display 'Yellow' Icon
	Then Check 'High Temperature' Tip Text Display
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionLE
Scenario: VFC182_TestStep23_When Battery Is In Trickle Charge Condition
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Trickle charge'
	Given Go to My Device Settings page
	Then Check Display 'Yellow' Icon
	Then Check 'Trickle Charge' Tip Text Display
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionLE
Scenario: VFC182_TestStep24_When Battery Is In Over Heated Condition
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'Over heated'
	Given Go to My Device Settings page
	Then Check Display 'Yellow' Icon
	Then Check 'Over Heated' Tip Text Display
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionLE
Scenario: VFC182_TestStep25_When Battery Is In HW Authentication Error Condition
	Given Delete Vantage Power Settings INI File
	Given Change ThinkPad Machine Battery Condition To 'HW authentication error'
	Given Go to My Device Settings page
	Then Check Display 'Yellow' Icon
	Then Check 'HW Authentication Error' Tip Text Display
	Given Delete Vantage Power Settings INI File

@CheckBatteryConditionLE
Scenario: VFC182_TestStep26 check icon
	Given Go to Power Page
	Then The "AcDcIcon" is show
	Then Take Screen Shot VFC182_TestStep126ACDCICON in VFC182 under SettingscreenShotResult

@CheckBatteryConditionLE
Scenario: VFC182_TestStep27 check tip
	Given Go to Power Page
	Then The "AcDcIconTip" is show
	Then Clear Battery Condition Alert