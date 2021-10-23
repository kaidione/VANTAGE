Feature: VAN15185_VFC179_HSKeyboardBacklight
	Test Case: https://lnvusjira.lenovonet.lenovo.local/browse/VAN-15185
	Author:caopp2
	Author:chenpj5

#@HSKeyBoardBacklight
Scenario: VAN15185_TestStep01_Check Keyboard backlight metrics
	Given Set Metric on
	And   Launch Http Traffic Capturer
	And   Start Capture
	Given Thinkpad machines
	Given Go to input page
	Given support keyboard backlight section 
	Given clear data
	When  Click Low option of KBD Backlight 
	Then  Take Screen Shot VAN15185_TestStep01_KBDLowMode in 15185 under HSScreenShotResult 
	Then  the metric data is as expected with Test VAN15185 and Name KBDLowOn and Timeout 20
	When  wait 5 seconds
	Given clear data
	When  Click High option of KBD Backlight 
	Then  Take Screen Shot VAN15185_TestStep01_KBDHighMode in 15185 under HSScreenShotResult
	Then  the metric data is as expected with Test VAN15185 and Name KBDHighOn and Timeout 20 
	When  wait 5 seconds
	Given clear data
	When  Click Off option of KBD Backlight 
	Then  Take Screen Shot VAN15185_TestStep01_KBDOffMode in 15185 under HSScreenShotResult 
	Then  the metric data is as expected with Test VAN15185 and Name KBDOffOn and Timeout 20
	Given Stop Capture

@HSKeyBoardBacklight @HSKeyBoardBacklightLe
Scenario: VAN15185_TestStep02_Check Keyboard backlight Option Value after sleep or hibernate mode
	Given Thinkpad machines
	Given Go to input page
	Given support keyboard backlight section 
	When  Click Low option of KBD Backlight 
	Then  Take Screen Shot VAN15185_TestStep02_KBDLowModeBefore in 15185 under HSScreenShotResult 
	When  Enter sleep
	Then  check KBD option change
	Then  Take Screen Shot VAN15185_TestStep02_KBDLowModeAfter in 15185 under HSScreenShotResult 
	When  Click High option of KBD Backlight 
	Then  Take Screen Shot VAN15185_TestStep02_KBDHighModeBefore in 15185 under HSScreenShotResult
	When  Enter hibernate
	Then  Take Screen Shot VAN15185_TestStep02_KBDHighModeAfter in 15185 under HSScreenShotResult
	Then  check KBD option change 
	When  Click Off option of KBD Backlight 
	Then  Take Screen Shot VAN15185_TestStep02_KBDOffModeBefore in 15185 under HSScreenShotResult 
	When  Enter sleep
	Then  check KBD option change
	Then  Take Screen Shot VAN15185_TestStep02_KBDOffModeAfter in 15185 under HSScreenShotResult 


@HSKeyBoardBacklight @HSKBD @HSKeyBoardBacklightLe @SmokeHSKeyBoardBacklight
Scenario: VAN15185_TestStep04_Check Keyboard backlight Choose the "Low" option and the brightness of keyboard backlight should change to low
	Given Thinkpad machines
	Given Go to input page
	Given support keyboard backlight section 
	When Click Low option of KBD Backlight 
	Then Take Screen Shot VAN15185_TestStep02_KBDLowMode in 15185 under HSScreenShotResult

@HSKeyBoardBacklight @HSKBD @HSKeyBoardBacklightLe @SmokeHSKeyBoardBacklight
Scenario: VAN15185_TestStep06_Check Keyboard backlight Choose the "High" option and the brightness of keyboard backlight should change to high
	Given Thinkpad machines
	Given Go to input page
	Given support keyboard backlight section 
	When Click High option of KBD Backlight 
	Then Take Screen Shot VAN15185_TestStep06_KBDHighMode in 15185 under HSScreenShotResult 

@HSKeyBoardBacklight @HSKBD @HSKeyBoardBacklightLe @SmokeHSKeyBoardBacklight
Scenario: VAN15185_TestStep08_Check Keyboard backlight Choose the "Off" option and the brightness of keyboard backlight should change to off
	Given Thinkpad machines
	Given Go to input page
	Given support keyboard backlight section 
	When Click Off option of KBD Backlight 
	Then Take Screen Shot VAN15185_TestStep08_KBDOffMode in 15185 under HSScreenShotResult 

@HSKeyBoardBacklight @HSKBD @HSKeyBoardBacklightLe
Scenario: VAN15185_TestStep10_Check Keyboard backlight Choose the "Low" option and idle state for several seconds/minutes and The option of Keyboard backlight in Vantage is still "Low"
	Given Thinkpad machines
	Given Go to input page
	Given support keyboard backlight section
	When Click Low option of KBD Backlight
	Then Take Screen Shot VAN15185_TestStep10_KBDLowModeBefore in 15185 under HSScreenShotResult 
	When wait 120 seconds
	Given Go to My Device Settings page
	Given Go to input page
	Given support keyboard backlight section
	Then Take Screen Shot VAN15185_TestStep10_KBDLowModeAfter in 15185 under HSScreenShotResult 
