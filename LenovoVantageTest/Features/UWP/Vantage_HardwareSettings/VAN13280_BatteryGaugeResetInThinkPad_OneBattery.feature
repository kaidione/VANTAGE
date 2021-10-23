Feature: VAN13280_BatteryGaugeResetInThinkPad_OneBattery
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-13280
	Author: Jinxin Li
	Update: Jingting Jia

@BatteryGaugeResetOneBatteryNeedRunonBJ19 @BatteryGaugeResetOneBatteryLE
Scenario: VAN13280_TestStep01_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When Check the Battery Settings section
	Then There will be a Battery Gauge reset feature in this section and under Battery Charge threshold 

@BatteryGaugeResetOneBatteryNeedRunonBJ19
Scenario: VAN13280_TestStep02_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	When Slide Screen and go to Button Section
	When Check the UI of Battery gauge reset feature
	Then There will be a feature "Battery gauge reset" and "This feature enables your computer to estimate the full charge capacity more accurately." should follow the UISPEC
	Then Take Screen Shot 02BatteryGaugeResetOneBatteryCheckICON in 13280 under HSScreenShotResult

@BatteryGaugeResetOneBatteryNeedRunonBJ19 @BatteryGaugeResetOneBatteryLE
Scenario: VAN13280_TestStep03_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	When The machine with one battery
	Then There will be only one battery reset panel

@BatteryGaugeResetOneBatteryNeedRunonBJ19 @BatteryGaugeResetOneBatteryLE
Scenario: VAN13280_TestStep05_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When Check the UI of Battery reset panel
	Then There will be a Battery Barcode number and a RESET button

@BatteryGaugeResetOneBatteryNeedRunonBJ19 @BatteryGaugeResetOneBatteryLE
Scenario: VAN13280_TestStep06_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When Check the UI of Battery reset panel
	When If there is has a "ReconditionError" value in "SOFTWARE\WOW6432Node\Lenovo\PWRMGRV\ConfKeys\Data" where XX is the Battery Barcode
	Then The Last Reset item will be displayed in the Battery Gauge Reset panel

@BatteryGaugeResetOneBatteryNeedRunonBJ19 @BatteryGaugeResetOneBatteryLE
Scenario: VAN13280_TestStep07_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When Check the UI of Battery reset panel
	When Click the "RESET" Button
	Then There will popup a battery reset confirmation dialog (About the reset step) and should follow the UISPEC

@BatteryGaugeResetOneBatteryNeedRunonBJ19 @BatteryGaugeResetOneBatteryLE
Scenario: VAN13280_TestStep08_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When Click the "RESET" Button
	When Click the "CANCEL" Button
	Then The Battery Gauge Rest process will not be performed and return to the Power Page
	When Click the "RESET" Button
	When Click the "close" Button
	Then The Battery Gauge Rest process will not be performed and return to the Power Page

@BatteryGaugeResetOneBatteryNeedRunonBJ19 @BatteryGaugeResetOneBatteryLE
Scenario: VAN13280_TestStep09_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When Click the "RESET" Button
	When Click the "Continue" Button
	Then The Battery Gauge Rest process will be performed
	When wait 1 seconds
	Given Type in "{PGDN}"
	When wait 3 seconds
	When Click the "Stop" Button
	When Click the "Yes" Button

@BatteryGaugeResetOneBatteryNeedRunonBJ19 @BatteryGaugeResetOneBatteryLE
Scenario: VAN13280_TestStep10_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	When Slide Screen and go to Button Section
	Given Reset the Battery Gauge status to reset
	When Click the "RESET" Button
	When Click the "Continue" Button
	When wait 5 seconds
	Then The "RESET" Button which we Clicked will change to "STOP" button with red background color
	Then Take Screen Shot 10BatteryGaugeResetOneBatteryRedStop in 13280 under HSScreenShotResult
	When Click the "Stop" Button
	When Click the "Yes" Button

@BatteryGaugeResetOneBatteryNeedRunonBJ19 @BatteryGaugeResetOneBatteryLE
Scenario: VAN13280_TestStep12_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	When Slide Screen and go to Button Section
	Given Reset the Battery Gauge status to reset
	When Click the "RESET" Button
	When Click the "Continue" Button
	Then The Battery Reset Panel which we click will display a Barcode, Progress, Remaining and Start time item, all the value should be correct during the progress
	When Click the "Stop" Button
	When Click the "Yes" Button

@BatteryGaugeResetOneBatteryNeedRunonBJ19
Scenario: VAN13280_TestStep20_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When Battery Charging threshold is off
	When Click the "RESET" Button
	When Click the "Continue" Button
	When Click the "Stop" Button
	Then The title and tips should follow the UISPEC
	When Click the "Yes" Button

@BatteryGaugeResetOneBatteryNeedRunonBJ19 @BatteryGaugeResetOneBatteryLE
Scenario: VAN13280_TestStep21_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When Battery Charging threshold is off
	When Click the "RESET" Button
	When Click the "Continue" Button
	When Click the "Stop" Button
	When There will pup-up a confirmation dialog
	Then There is a YES and a CANCEL button in the windows
	When Click the "Yes" Button
	
@BatteryGaugeResetOneBatteryNeedRunonBJ19 @BatteryGaugeResetOneBatteryLE
Scenario: VAN13280_TestStep22_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When Battery Charging threshold is off
	When Slide Screen and go to Button Section
	When Click the "RESET" Button
	When Click the "Continue" Button
	When Click the "Stop" Button
	When Click the "CANCEL" Button
	Then The windows will be closed and the Reset process will still on going
	When Click the "Stop" Button
	When Click the "Yes" Button
	Given Click Jump to Battery Settings
	When Battery Charging threshold is off
	When Slide Screen and go to Button Section
	When Click the "RESET" Button
	When Click the "Continue" Button
	When Click the "Stop" Button
	When Click the "close" Button
	Then The windows will be closed and the Reset process will still on going
	When Slide Screen and go to Button Section
	When wait 3 seconds
	When Click the "Stop" Button
	When Click the "Yes" Button

@BatteryGaugeResetOneBatteryNeedRunonBJ19 @BatteryGaugeResetOneBatteryLE
Scenario: VAN13280_TestStep23_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When Battery Charging threshold is off
	When Click the "RESET" Button
	When Click the "Continue" Button
	When Click the "Stop" Button
	When Click the "Yes" Button
	Then The Reset process will be stopped

@BatteryGaugeResetOneBatteryNeedRunonBJ19 @BatteryGaugeResetOneBatteryLE
Scenario: VAN13280_TestStep24_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When Battery Charging threshold is off
	When Click the "RESET" Button
	When Click the "Continue" Button
	When Click the "Stop" Button
	When Click the "Yes" Button
	Then STOP button will change to "RESET" button and can be clicked
	
@BatteryGaugeResetOneBatteryNeedRunonBJ19 @BatteryGaugeResetOneBatteryLE
Scenario: VAN13280_TestStep26_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When Battery Charging threshold is off
	When Click the "RESET" Button
	When Click the "Continue" Button
	When Click the "Stop" Button
	When Click the "Yes" Button
	Then The Battery Reset panel will display the Last reset item instead of Progress, remaining and start time
	
@BatteryGaugeResetOneBatteryNeedRunonBJ19 @BatteryGaugeResetOneBatteryLE
Scenario: VAN13280_TestStep27_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When Battery Charging threshold is off
	When Click the "RESET" Button
	When Click the "Continue" Button
	When Click the "Stop" Button
	When Click the "Yes" Button
	Then The log is "2/26/2014 6:05:01 AM Failed: Cancelled by user"
	Then Take Screen Shot 27CancelTime in 13280 under HSScreenShotResult

@BatteryGaugeResetOneBatteryNeedRunonBJ19 @BatteryGaugeResetOneBatteryLE
Scenario: VAN13280_TestStep28_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When If Battery Charging threshold is on
	Given Click Jump to Battery Settings
	When Click the "RESET" Button
	When Click the "Continue" Button
	When wait 5 seconds
	Then all buttons in Battery Charge Threshold function (Battery Charge Threshold feature will be disabled) will be grey out
	Given Click Jump to Battery Settings
	Then Take Screen Shot 28BCTGreyUI in 13280 under HSScreenShotResult
	When Slide Screen and go to Button Section
	When Click the "Stop" Button
	When Click the "Yes" Button

@BatteryGaugeResetOneBatteryNeedRunonBJ19 @BatteryGaugeResetOneBatteryLE
Scenario: VAN13280_TestStep29_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When If Battery Charging threshold is on
	When Slide Screen and go to Button Section
	When Click the "RESET" Button
	When Click the "Continue" Button
	When wait 30 seconds
	When Click the "Stop" Button
	When Click the "Yes" Button
	When Get the BCT Stop value
	When wait 2 seconds
	When Click the "SEE BATTERY DETAILS" Button
	Then Battery Charging threshold will take effect immediately

@BatteryGaugeResetOneBatteryNeedRunonBJ19 @BatteryGaugeResetOneBatteryLE
Scenario: VAN13280_TestStep30_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When If Battery Charging threshold is on
	When Click the "RESET" Button
	When Click the "Continue" Button
	Then The tips in Battery Panel section will change to "Note: The battery gauge reset is in progress. Please keep the ac power adapter connected."
	When Click the "Stop" Button
	When Click the "Yes" Button

@BatteryGaugeResetOneBatteryNeedRunonBJ19 @BatteryGaugeResetOneBatteryLE
Scenario: VAN13280_TestStep31_Battery Gauge Reset In ThinkPad One Battery
	Given The ThinkPad machine with Lenovo Power Manager driver
	Given The driver is in good condition and the machine is in AC state
	Given Click Jump to Battery Settings
	Given Reset the Battery Gauge status to reset
	When If Battery Charging threshold is on
	When Slide Screen and go to Button Section
	When Click the "RESET" Button
	When Click the "Continue" Button
	Then The tips in Battery Panel section will change to "Note: The battery gauge reset is in progress. Please keep the ac power adapter connected."
	When Click the "Stop" Button
	When Click the "Yes" Button
	Then The tip in Battery Panel section will change back to Battery Charging threshold

@BatteryGaugeResetOneBatteryNeedRunonBJ19 @BatteryGaugeResetOneBatteryLE
Scenario: VAN13280_TestStep47_Battery Gauge Reset In ThinkPad One Battery
	Given The driver is in Error state
	Given Go to Power Page
	Then There should no Battery Gauge Reset feature in the Battery Settings section
	Given Restar Powermgrexe

@BatteryGaugeResetOneBatteryIdeaPad @SmokeBatteryGaugeResetOneBatteryIdeaPad
Scenario: VAN13280_TestStep48_Battery Gauge Reset In ThinkPad One Battery
	#Given get machine type is idea or yoga
	Given Go to Power Page
	Then There should no Battery Gauge Reset feature in the Battery Settings section