Feature: VAN21386_GamingNetworkBoostAutoCloseToast
	Test Case： https://jira.tc.lenovo.com/browse/VAN-21386
	Author： Yang Liu

Background:
	Given Machine is Gaming 
	When Stop the IMC service in the task manager
	When Start the IMC service in the task manager
	Given Restart Windows Time Service

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep01_No Gaming promotion and effect toast message should be shown
	Given Clean Messaging History File
	Given Clean toast history
	Given Clean Auto Close And Network Boost Registry Key Under Toast
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep02_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Auto Close And Network Boost Registry Key Under Toast
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Stop the specified app GameWorldOfWarcraft

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep03_Network boost toast message should not be shown
	Given Clean toast history
	Given Clean Auto Close And Network Boost Registry Key Under Toast
	Given Uninstall The Network Boost Driver
	Given Network Boost Driver Is Not Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep04_Network boost toast message should not be shown
	Given Clean toast history
	Given Clean Auto Close And Network Boost Registry Key Under Toast
	Given Network Boost Driver Is Installed
	When ReLaunch Lenovo Vantage For Toast Message
	When Turn on network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	Given Uninstall The Network Boost Driver
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep05_Network boost promotion toast message should be shown and others should not be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	Given Close Vantage
	Given Launch Vantage
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Promotion Toast Message Should Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep06_Network boost promotion toast message should be consistent with UI spec definition
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Promotion Toast Message Should Be Shown
	Then Take Screen Shot TestStep06 in 21386 under GamingScreenShotResult

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep07_Network boost promotion toast message should be disappeared from desktop and shown in the notification center
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When No Any Operation For About 5S
	When Check The Toast Message
	Then Network Boost Promotion Toast Message Should Be Shown
	Then Take Screen Shot TestStep07 in 21386 under GamingScreenShotResult

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep08_Network boost promotion toast message should be disappeared from desktop and shown in the notification center
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Click The Move this notification to action center Button New notification
	When Check The Toast Message
	Then Network Boost Promotion Toast Message Should Be Shown
	Then Take Screen Shot TestStep08 in 21386 under GamingScreenShotResult

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep09_Network boost promotion toast message should be disappeared and should not be shown in the notification center
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Ignore Button ''
	When No Any Operation For About 5S
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep10_Auto Close promotion toast message should be shown and Auto Close effect toast message should not be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Ignore Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Promotion Toast Message Should Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep11_Auto Close promotion toast message should be consistent with UI spec definition
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Ignore Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Promotion Toast Message Should Be Shown
	Then Take Screen Shot TestStep11 in 21386 under GamingScreenShotResult
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep12_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Ignore Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Ignore Button ''
	Given Adjust The System Time To 2 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep13_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Ignore Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Ignore Button ''
	Given Adjust The System Time To 4 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep14_Network boost promotion toast message should be shown for the second time
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Ignore Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Ignore Button ''
	Given Adjust The System Time To 6 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Promotion Toast Message Should Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep15_Auto Close promotion toast message should be shown for the second time
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	Given Network Boost Promotion Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Auto Close Promotion Toast Message Was Shown For The 1 Time And Click The Ignore Button
	Given Adjust The System Time To 8 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Promotion Toast Message Should Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep16_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	Given Network Boost Promotion Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Auto Close Promotion Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Adjust The System Time To 10 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep17_Network boost promotion toast message should be shown for the third time
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	Given Network Boost Promotion Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Auto Close Promotion Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Adjust The System Time To 14 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Promotion Toast Message Should Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep18_Auto Close Promotion toast message should be shown for the third time
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	Given Network Boost Promotion Toast Message Was Shown For The 3 Time And Click The Ignore Button
	Given Auto Close Promotion Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Adjust The System Time To 15 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Promotion Toast Message Should Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep19_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	Given Network Boost Promotion Toast Message Was Shown For The 3 Time And Click The Ignore Button
	Given Auto Close Promotion Toast Message Was Shown For The 3 Time And Click The Ignore Button
	Given Adjust The System Time To 18 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep20_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	Given Network Boost Promotion Toast Message Was Shown For The 3 Time And Click The Ignore Button
	Given Auto Close Promotion Toast Message Was Shown For The 3 Time And Click The Ignore Button
	Given Adjust The System Time To 21 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep21_Network boost page should be open and toggle status should not be changed
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn more Button ''
	When No Any Operation For About 5S
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Then jump to network boost subpage
	Then The toggle display off status in network boost subpage

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep22_Auto Close page should be open and toggle status should not be changed
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Ignore Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn more Button ''
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Then The auto close will be shown within subpage
	Then The auto close toggle status is on or off within subpage off
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep23_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn more Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn more Button ''
	Given Adjust The System Time To 6 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep24_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn more Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn more Button ''
	Given Adjust The System Time To 7 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep25_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn more Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn more Button ''
	Given Adjust The System Time To 13 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep26_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn more Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn more Button ''
	Given Adjust The System Time To 14 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep27_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn more Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn more Button ''
	Given Adjust The System Time To 20 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep28_Network boost page should not be opened and toggle status should be changed to ON, network boost promotion toast message should be disappeared
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Turn on Button ''
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	When Click network boost gear icon
	When Click back button
	Then jump to homepage
	Then Network boost toggle status is on

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep29_Auto Close page should not be opened and toggle status should be changed to ON, auto Close promotion toast message should be disappeared
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Ignore Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Turn on Button ''
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	When Click network boost gear icon
	When Click back button
	Then The auto close will be shown within legion home page
	Then The auto close toggle status is on or off within home page ON
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep30_Network boost effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Turn on Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Turn on Button ''
	Given Adjust The System Time To 6 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep31_Auto close effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Turn on Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Turn on Button ''
	Given Adjust The System Time To 6 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep32_Network boost effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Turn on Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Turn on Button ''
	Given Adjust The System Time To 13 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep33_Auto close effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Turn on Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Turn on Button ''
	Given Adjust The System Time To 13 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep34_Network boost effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Turn on Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Turn on Button ''
	Given Adjust The System Time To 20 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep35_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Auto Close And Network Boost Registry Key Under Toast
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep36_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Auto Close And Network Boost Registry Key Under Toast
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	When Stop the specified app GameWorldOfWarcraft

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep37_Network boost effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	When Check The Toast Message

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep38_Network boost effect toast message should be consistent with UI spec definition
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Be Shown
	Then Take Screen Shot TestStep38 in 21386 under GamingScreenShotResult
	When Check The Toast Message

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep39_Network boost effect toast message should be disappeared from desktop and shown in the notification center
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When No Any Operation For About 5S
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Be Shown
	Then Take Screen Shot TestStep39 in 21386 under GamingScreenShotResult
	When Check The Toast Message

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep40_Network boost effect toast message should be disappeared from desktop and shown in the notification center
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Click The Move this notification to action center Button New notification
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Be Shown
	Then Take Screen Shot TestStep40 in 21386 under GamingScreenShotResult

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep41_Auto close effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Click The Move this notification to action center Button New notification
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep42_Auto close effect toast message should be consistent with UI spec definition
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Click The Move this notification to action center Button New notification
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Be Shown
	Then Take Screen Shot TestStep42 in 21386 under GamingScreenShotResult
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep43_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Click The Move this notification to action center Button New notification
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Click The Move this notification to action center Button New notification
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 2 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep44_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Click The Move this notification to action center Button New notification
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Click The Move this notification to action center Button New notification
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 4 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep45_Network boost effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Click The Move this notification to action center Button New notification
	When Check The Toast Message
	Given Clean toast history
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Click The Move this notification to action center Button New notification
	When Check The Toast Message
	Given Clean toast history
	Given Adjust The System Time To 6 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep46_Auto close effect toast message should be shown
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	Given Network Boost Effect Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Auto Close Effect Toast Message Was Shown For The 1 Time And Click The Ignore Button
	Given Adjust The System Time To 8 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep47_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	Given Network Boost Effect Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Auto Close Effect Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Adjust The System Time To 10 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep48_Network boost effect toast message should be shown
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	Given Network Boost Effect Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Auto Close Effect Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Adjust The System Time To 14 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep49_Auto close effect toast message should be shown
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	Given Network Boost Effect Toast Message Was Shown For The 3 Time And Click The Ignore Button
	Given Auto Close Effect Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Adjust The System Time To 15 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep50_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	Given Network Boost Effect Toast Message Was Shown For The 3 Time And Click The Ignore Button
	Given Auto Close Effect Toast Message Was Shown For The 3 Time And Click The Ignore Button
	Given Adjust The System Time To 18 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep51_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	Given Network Boost Effect Toast Message Was Shown For The 3 Time And Click The Ignore Button
	Given Auto Close Effect Toast Message Was Shown For The 3 Time And Click The Ignore Button
	Given Adjust The System Time To 21 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep52_Network boost page should be open and toggle status should not be changed
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Click The Learn More Button New notification
	Then jump to network boost subpage
	Then The toggle display on status in network boost subpage
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	When Check The Toast Message

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep53_Auto Close page should be open and toggle status should not be changed
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Click The Move this notification to action center Button New notification
	When Check The Toast Message
	Given Clean toast history
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn More Button ''
	Then Auto Close Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Then The auto close will be shown within subpage
	Then The auto close toggle status is on or off within subpage on
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep54_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn More Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn More Button ''
	Given Adjust The System Time To 6 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep55_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn More Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn More Button ''
	Given Adjust The System Time To 7 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep56_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn More Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn More Button ''
	Given Adjust The System Time To 13 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep57_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn More Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn More Button ''
	Given Adjust The System Time To 14 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep58_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn More Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Learn More Button ''
	Given Adjust The System Time To 21 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep59_Network boost page should not be open and toggle status should not be changed
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Click The Close Button New notification 
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Then Network boost toggle status is on

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep60_Auto Close page should not be open and toggle status should not be changed
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Close Button ''
	Then Auto Close Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Then The auto close toggle status is on or off within home page on
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep61_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 6 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep62_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 7 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep63_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 13 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep64_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 14 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep65_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 20 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep66_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Auto Close And Network Boost Registry Key Under Toast
	When Turn on network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep67_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Auto Close And Network Boost Registry Key Under Toast
	When Turn on network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	When Stop the specified app GameWorldOfWarcraft

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep68_Auto Close promotion toast message should be shown and others should not be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Promotion Toast Message Should Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	When Check The Toast Message

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep69_Network boost effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Ignore Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep70_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Ignore Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Click The Move this notification to action center Button New notification
	When Check The Toast Message
	Given Adjust The System Time To 2 Days Later
	Given Clean toast history
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep71_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Ignore Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Click The Move this notification to action center Button New notification
	When Check The Toast Message
	Given Adjust The System Time To 4 Days Later
	Given Clean toast history
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep72_Auto Close promotion toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Ignore Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Click The Move this notification to action center Button New notification
	When Check The Toast Message
	Given Adjust The System Time To 6 Days Later
	Given Clean toast history
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Promotion Toast Message Should Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep73_Network boost effect toast message should be shown
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	Given Auto Close Promotion Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Network Boost Effect Toast Message Was Shown For The 1 Time And Click The Ignore Button
	Given Adjust The System Time To 8 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep74_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	Given Auto Close Promotion Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Network Boost Effect Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Adjust The System Time To 10 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep75_Auto Close promotion toast message should be shown
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	Given Auto Close Promotion Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Network Boost Effect Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Adjust The System Time To 14 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Promotion Toast Message Should Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep76_Network Boost effect toast message should be shown for the second time
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	Given Auto Close Promotion Toast Message Was Shown For The 3 Time And Click The Ignore Button
	Given Network Boost Effect Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Adjust The System Time To 15 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep77_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	Given Auto Close Promotion Toast Message Was Shown For The 3 Time And Click The Ignore Button
	Given Network Boost Effect Toast Message Was Shown For The 3 Time And Click The Ignore Button
	Given Adjust The System Time To 18 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep78_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	Given Auto Close Promotion Toast Message Was Shown For The 3 Time And Click The Ignore Button
	Given Network Boost Effect Toast Message Was Shown For The 3 Time And Click The Ignore Button
	Given Adjust The System Time To 21 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep79_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Auto Close And Network Boost Registry Key Under Toast
	When Turn off network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep80_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Auto Close And Network Boost Registry Key Under Toast
	When Turn off network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	When Stop the specified app GameWorldOfWarcraft

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep81_Network boost promotion toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Promotion Toast Message Should Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	When Check The Toast Message

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep82_Auto Close effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Ignore Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep83_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Ignore Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Click The Move this notification to action center Button New notification
	When Check The Toast Message
	Given Adjust The System Time To 2 Days Later
	Given Clean toast history
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep84_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Ignore Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Click The Move this notification to action center Button New notification
	When Check The Toast Message
	Given Adjust The System Time To 4 Days Later
	Given Clean toast history
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep85_Network boost promotion toast message should be shown
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Ignore Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Click The Move this notification to action center Button New notification
	When Check The Toast Message
	Given Adjust The System Time To 6 Days Later
	Given Clean toast history
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Promotion Toast Message Should Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep86_Auto Close effect toast message should be shown
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	Given Network Boost Promotion Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Auto Close Effect Toast Message Was Shown For The 1 Time And Click The Ignore Button
	Given Adjust The System Time To 8 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep87_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	Given Network Boost Promotion Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Auto Close Effect Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Adjust The System Time To 10 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep88_Network boost promotion toast message should be shown
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	Given Network Boost Promotion Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Auto Close Effect Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Adjust The System Time To 14 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Promotion Toast Message Should Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep89_Auto Close effect toast message should be shown
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	Given Network Boost Promotion Toast Message Was Shown For The 3 Time And Click The Ignore Button
	Given Auto Close Effect Toast Message Was Shown For The 2 Time And Click The Ignore Button
	Given Adjust The System Time To 15 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep90_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	Given Network Boost Promotion Toast Message Was Shown For The 3 Time And Click The Ignore Button
	Given Auto Close Effect Toast Message Was Shown For The 3 Time And Click The Ignore Button
	Given Adjust The System Time To 18 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep91_No Gaming promotion and effect toast message should be shown
	Given Clean toast history
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	Given Network Boost Promotion Toast Message Was Shown For The 3 Time And Click The Ignore Button
	Given Auto Close Effect Toast Message Was Shown For The 3 Time And Click The Ignore Button
	Given Adjust The System Time To 21 Days Later
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Not Be Shown
	Then Network Boost Promotion Toast Message Should Not Be Shown
	Then Auto Close Promotion Toast Message Should Not Be Shown
	Then Auto Close Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep96_Network boost promotion toast message should be disappeared from notification center
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When No Any Operation For About 5S
	When Check The Toast Message
	When Click The Ignore Button ''
	When No Any Operation For About 5S
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep97_Network boost page should be opened and network boost promotion toast message should be disappeared from notification center
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When No Any Operation For About 5S
	When Check The Toast Message
	When Click The Learn more Button ''
	When No Any Operation For About 5S
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Then jump to network boost subpage

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep98_Network boost toggle status should be On
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn off network boost
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When No Any Operation For About 5S
	When Check The Toast Message
	When Click The Turn on Button ''
	When No Any Operation For About 5S
	Then Network Boost Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	When Click network boost gear icon
	When Click back button
	Then Network boost toggle status is on

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep99_Auto Close promotion toast message should be disappeared from notification center
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When No Any Operation For About 5S
	When Check The Toast Message
	When Click The Ignore Button ''
	When No Any Operation For About 5S
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep100_Auto Close page should be opened and auto Close promotion toast message should be disappeared from notification center
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When No Any Operation For About 5S
	When Check The Toast Message
	When Click The Learn more Button ''
	When No Any Operation For About 5S
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	Then The auto close will be shown within subpage

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep101_Auto Close toggle status should be On
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When No Any Operation For About 5S
	When Check The Toast Message
	Then Auto Close Promotion Toast Message Should Be Shown
	When Click The Turn on Button ''
	When No Any Operation For About 5S
	Then Auto Close Promotion Toast Message Should Not Be Shown
	When Check The Toast Message
	When Click network boost gear icon
	When Click back button
	Then The auto close toggle status is on or off within home page on

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep102_Network boost effect toast message should be disappeared from notification center
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When No Any Operation For About 5S
	When Check The Toast Message
	When Click The Close Button ''
	When No Any Operation For About 5S
	Then Network Boost Effect Toast Message Should Not Be Shown
	When Check The Toast Message

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep103_Network boost page should be opened and network boost effect toast message should be disappeared from notification center
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When No Any Operation For About 5S
	When Check The Toast Message
	Then Network Boost Effect Toast Message Should Be Shown
	When Click The Learn more Button ''
	When No Any Operation For About 5S
	Then Network Boost Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Then jump to network boost subpage

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep104_Auto Close effect toast message should be disappeared from notification center
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When No Any Operation For About 5S
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Be Shown
	When Click The Close Button ''
	When No Any Operation For About 5S
	Then Auto Close Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Given Set System Time Automatically To Sync

@GamingNetworkBoostAutoCloseToast
Scenario: VAN21386_TestStep105_Auto Close page should be opened and Auto Close effect toast message should be disappeared from notification center
	Given Clean toast history
	Given Clean Registry Key Toast
	Given Network Boost Driver Is Installed
	When Turn on network boost
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When Check The Toast Message
	When Click The Close Button ''
	Given Adjust The System Time To 1 Days Later
	When Check The Toast Message
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the specified app GameWorldOfWarcraft
	When No Any Operation For About 5S
	When Check The Toast Message
	Then Auto Close Effect Toast Message Should Be Shown
	When Click The Learn More Button ''
	When No Any Operation For About 5S
	Then Auto Close Effect Toast Message Should Not Be Shown
	When Check The Toast Message
	Then The auto close will be shown within subpage
	Given Set System Time Automatically To Sync
