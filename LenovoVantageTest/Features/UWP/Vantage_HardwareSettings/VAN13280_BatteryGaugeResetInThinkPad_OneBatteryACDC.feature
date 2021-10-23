@BatteryGaugeResetOneBatteryNeedRunonBJ19ACTDC
Feature: VAN13280_BatteryGaugeResetInThinkPad_OneBatteryACDC
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-13280
	Author: Jinxin Li
	Update: Jingting Jia

@BatteryGaugeResetOneBatteryNeedRunonBJ19ACTDC
Scenario: VAN13280_TestStep13_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given AC Condition(Connect the Adapter)
	When wait 60 seconds
	Given The driver is in good condition and the machine is in AC state
	#Given Record the process by video
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When The Battery percentage is lower than 97%
	When Battery Charging threshold is off
	When Slide Screen and go to Button Section
	When Click the "RESET" Button
	When Click the "Continue" Button
	Then The tip will show "Step 1, out of 3 steps in total: Calibrating to full charge"
	#When Checking the Battery Gauge reset is in Stpe 2
	#Then The Battery percentage is about 100%
	#Then first, and then the Battery will be charging to 100%, The tip under 3.2.0.01 is "Step 1, out of 3 steps in total: Calibrating to full charge"

@BatteryGaugeResetOneBatteryNeedRunonBJ19ACTDC
Scenario: VAN13280_TestStep32_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given AC Condition(Connect the Adapter)
	When wait 60 seconds
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When Battery Charging threshold is off
	When Click the "RESET" Button
	When Click the "Continue" Button
	When User make the machine from AC to DC
	When wait 60 seconds
	Then The reset process will be stopped and the tips should be displayed, RESET button should be in grey-out state immediately
	
@BatteryGaugeResetOneBatteryNeedRunonBJ19ACTDC
Scenario: VAN13280_TestStep33_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given AC Condition(Connect the Adapter)
	When wait 60 seconds
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When Battery Charging threshold is off
	When Click the "RESET" Button
	When Click the "Continue" Button
	When User make the machine from AC to DC
	When wait 60 seconds
	Then The Last reset log should be "Failed: AC power adapter was detached."

@BatteryGaugeResetOneBatteryNeedRunonBJ19ACTDC
Scenario: VAN13280_TestStep42_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given AC Condition(Connect the Adapter)
	When wait 60 seconds
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When User make the machine from AC to DC
	When wait 60 seconds
	Then There will be NoAdapter Tip

@BatteryGaugeResetOneBatteryNeedRunonBJ19ACTDC
Scenario: VAN13280_TestStep43_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given AC Condition(Connect the Adapter)
	When wait 60 seconds
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When User make the machine from AC to DC
	When wait 60 seconds
	Then The "RESET" button is in grey-out state and cannot be click immediately
	
@BatteryGaugeResetOneBatteryNeedRunonBJ19ACTDC
Scenario: VAN13280_TestStep44_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given AC Condition(Connect the Adapter)
	When wait 60 seconds
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When User make the machine from AC to DC
	When wait 60 seconds
	When ReLaunch Vantage
	Given Go to Power Page
	When Check the UI of Battery gauge reset feature
	Then There will be NoAdapter Tip
		
@BatteryGaugeResetOneBatteryNeedRunonBJ19ACTDC
Scenario: VAN13280_TestStep45_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	When User make the machine from AC to DC
	When wait 60 seconds
	When ReLaunch Vantage
	Given Go to Power Page
	Given Click Jump to Battery Settings
	When Slide Screen and go to Button Section
	Given AC Condition(Connect the Adapter)
	When wait 60 seconds
	Then The Battery Gauge Reset "RESET" button will be in normal(Blue) style and can be clicked immediately
	Then Take Screen Shot 45ResetBlueButton in 13280 under HSScreenShotResult

@BatteryGaugeResetOneBatteryNeedRunonBJ19ACTDC
Scenario: VAN13280_TestStep46_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	When User make the machine from AC to DC
	When wait 60 seconds
	When ReLaunch Vantage
	Given Go to Power Page
	Given Click Jump to Battery Settings
	Given AC Condition(Connect the Adapter)
	When wait 60 seconds
	Then The battery gauge reset adapter tips should be hidden immediately