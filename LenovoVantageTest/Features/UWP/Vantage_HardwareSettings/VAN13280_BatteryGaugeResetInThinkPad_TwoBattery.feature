Feature: VAN13280_BatteryGaugeResetInThinkPad_TwoBattery
	Test Case: https://lnvusjira.lenovonet.lenovo.local/browse/VAN-13280
	Author: Jinxin Li
	Update: Jingting Jia

@BatteryGaugeResetTwoBattery @SmokeBatteryGaugeResetTwoBattery
Scenario: VAN13280_TestStep04_Battery Gauge Reset In ThinkPad Two Battery
	Given Turn on or off the narrator 'off'
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	When The machine with two battery
	When Slide Screen and go to Button Section
	Then There will be two battery reset panel
	Then Verify string '$.PowerPage.HSBatteryGuageResetOneBattryNote' 'Display'

@BatteryGaugeResetTwoBattery
Scenario: VAN13280_TestStep11_Battery Gauge Reset In ThinkPad Two Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	When Slide Screen and go to Button Section
	Given Reset the Battery Gauge status to reset
	When Click the "RESET" Button
	When Click the "Continue" Button
	Then If the machine with two batteries, the "RESET" button which we didn't selected will be changed to grey-out and cannot be clicked
	Then Take Screen Shot 11TwoBatteryGrey in 13280 under HSScreenShotResult
	When Click the "Stop" Button
	When Click the "Yes" Button

@BatteryGaugeResetTwoBattery
Scenario: VAN13280_TestStep25_Battery Gauge Reset In ThinkPad Two Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	When Slide Screen and go to Button Section
	Given Reset the Battery Gauge status to reset
	When Click the "RESET" Button
	When Click the "Continue" Button
	When Click the "Stop" Button
	When Click the "Yes" Button
	Then If the machine with two batteries, the "RESET" button which we didn't selected will be resuem from grey-out and can be clicked
	Then Take Screen Shot 25TwoBatteryBlue in 13280 under HSScreenShotResult

#@BatteryGaugeResetTwoBattery
Scenario: VAN13280_TestStep50_Battery Gauge Reset In ThinkPad One Battery
	Given The Battery Gauge Reset is on going
	Given The ThinkPad machine with two Batteries
	When The Reset process is in Step 2
	Then The battery (which is under reset process) status in Details page is Discharging (with ac) and shouldn't display the "Remaining time" item And the other battery is in No Activity status

