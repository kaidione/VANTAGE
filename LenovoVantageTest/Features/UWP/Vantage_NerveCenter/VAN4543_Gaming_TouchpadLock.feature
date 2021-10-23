Feature: VAN4543_Gaming_TouchpadLockFeatureTest
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-4543
	Author： Lea Zhang

Background:
	Given Machine is Gaming 

@GamingTouchpadPC @GamingSmokeTPLock
Scenario: VAN4543_TestStep01_Check Touchpad Lock UI in gaming
	Given Go to homepage
	Then Touchpad lock show in homepage
	Then Take Screen Shot 01 in 4543 under GamingScreenShotResult

@GamingTouchpadPC
Scenario: VAN4543_TestStep02_Check Touchpad Lock working fine in gaming
	Given Go to homepage
	When Check default toggle status of the Touchpad Lock
	Then Touchpad Lock Disabled

@GamingTouchpadPC
	Scenario: VAN4543_TestStep03_Connect Mouse Touchpad Will disable when game is running
	Given Connect Mouse
	When Touchpad Lock is Enable
	When Close Vantage
	When Launch the specifie game GameWorldOfWarcraft
	Then Touchpad disabled when game running
	When kill Wow and wait 3 second

@GamingTouchpadPCS3
Scenario: VAN4543_TestStep04_Touchpad enabled Check S3status
	When Touchpad Lock is Enable
	When Close Vantage
	When Enter sleep
	Given Launch Vantage
	Then Touchpad Lock Enabled
	When Close Vantage
	When Launch the specifie game GameWorldOfWarcraft
	Then Touchpad disalbed when game running
	When kill Wow and wait 3 second

@GamingTouchpadPCS4
Scenario: VAN4543_TestStep05_Touchpad enabled Check S4 status
	When Touchpad Lock is Enable
	When Close Vantage
	When Enter hibernate
	Given Launch Vantage
	Then Touchpad Lock Enabled
	When Close Vantage
	When Launch the specifie game GameWorldOfWarcraft
	Then Touchpad disalbed when game running
	When kill Wow and wait 3 second

@GamingTouchpadPC
Scenario: VAN4543_TestStep07_Check toggle will remain disable
	When Touchpad Lock is Enable
	When Disable touchpad Lock
	Then Touchpad Lock Disabled
	When Idle for 1 minute
	Then Touchpad Lock Disabled
	When ReLaunch Vantage
	Then Touchpad Lock Disabled

@GamingTouchpadPC
Scenario: VAN4543_TestStep08_Connect Mouse Touchpad Will enable when game is running
	Given Connect Mouse
	When Disable touchpad Lock
	When Launch the specifie game GameWorldOfWarcraft
	Then Touchpad enabled when game running
	When kill Wow and wait 3 second

@GamingTouchpadPCS3
Scenario: VAN4543_TestStep09_Touchpad disable Check S3 status 
	When Disable touchpad Lock
	When Close Vantage
	When Enter sleep
	Given Launch Vantage
	Then Touchpad Lock Disabled
	When Close Vantage
	When Launch the specifie game GameWorldOfWarcraft
	Then Touchpad enabled when game running
	When kill Wow and wait 3 second

@GamingTouchpadPCS4
Scenario: VAN4543_TestStep10_Touchpad disabled Check S4 status 
	When Disable touchpad Lock
	When Close Vantage
	When Enter hibernate
	Given Launch Vantage
	Then Touchpad Lock Disabled
	When Close Vantage
	When Launch the specifie game GameWorldOfWarcraft
	Then Touchpad enabled when game running
	When kill Wow and wait 3 second

@CheckTouchpadLockInDT
Scenario: VAN4543_TestStep12_CheckDesktop Machine
	Given The Machine Type is DT or NB 'DT'
	Given Launch Vantage
	When There is no touchpad showing 

@GamingTouchpadPC
Scenario: VAN4543_TestStep13_Touchpad show in the last
	Then The LEGION EDGE Section priority is displayed correctly

@GamingTouchpadPC
Scenario: VAN4543_TestStep14_Switch page to check toggle
	Given Go to homepage
	When Disable touchpad Lock
	When Enter to other subpage
	When Go back to homepage
	Then Touchpad Lock Disabled
	When Touchpad Lock is Enable
	When Enter to other subpage
	When Go back to homepage
	Then Touchpad Lock Enabled

@GamingTouchpadPC
Scenario: VAN4543_TestStep15_Check different size
	Given Go to homepage
	Given Resize the window
		| isSession | width | height | classname | windowname |
		| yes       | 500   | 500    |           |            |
	When Touchpad Lock is Enable
	When Disable touchpad Lock
	When Scroll the screen 11 in homepage
	Then Take Screen Shot 1501 in 4543 under GamingScreenShotResult
	Given Resize the window
		| isSession | width | height | classname | windowname |
		| yes       | 768   | 768    |           |            |
	When Touchpad Lock is Enable
	When Disable touchpad Lock
	Then Take Screen Shot 1502 in 4543 under GamingScreenShotResult
	Given Resize the window
		| isSession | width | height | classname | windowname |
		| yes       | 992   | 992    |           |            |
	When Touchpad Lock is Enable
	When Disable touchpad Lock
	Then Take Screen Shot 1503 in 4543 under GamingScreenShotResult
	Given Resize the window
		| isSession | width | height | classname | windowname |
		| yes       | 1200   | 1200    |           |            |
	When Touchpad Lock is Enable
	When Disable touchpad Lock
	Then Take Screen Shot 1504 in 4543 under GamingScreenShotResults


