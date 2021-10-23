Feature: VAN8576_Part2_CreateNeWStatusPageOfAllUserInCHSGroup
	Test Case：https://jira.tc.lenovo.com/browse/VAN-8576
	Author ：yangyu

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep11 Check Secondary user first connect status
	When The user connect or disconnect WiFi on lenovo
	Given Remove "Subscription" Account from Web Console
	Given User has Joined or Started a CHS "trialsecond"Group
	Then Check The Part of "Successfully login message"
	Then Take Screen Shot 11UI in 8576 under CHScreenShotResult

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep12 Check the Secondary icons show as UI spec
    When Check CHS Subpage
	Then Waiting 30 seconds
	Then Check CHS Group Family member has 2 number
	Then Check CHS Group Places member has 1 number
	Then Check CHS Group Wifi network has 0 number
	Then Check CHS Group Home devices has 0 number
	Then Take Screen Shot 12UI in 8576 under CHScreenShotResult

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep13 Check the Secondary family number change
    When Check CHS Subpage
	Given Add "Trial2" Family Number 
	Then Waiting 30 seconds
	Then Check CHS Group Family member has 3 number
	Given Remove "Third" Faimily Number From "Trial2"Account	

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep14 Check the Secondary places change
    When Check CHS Subpage
	Given "Add" "Trial2" Places Number
	Then Waiting 30 seconds
	Then Check CHS Group Places member has 2 number
	Given "Remove" "Trial2" Places Number

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep16 Check the Secondary wifi network change
    When Check CHS Subpage
	Given "Add" "Trial2" NetWork Number
	Then Waiting 30 seconds
	Then Check CHS Group Wifi network has 1 number

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep17 Check the Secondary home devices change
    When Check CHS Subpage
	Given "Add" "Trial2" Home Devices
	Then Waiting 30 seconds
	Then Check CHS Group Home devices has 1 number
	Given "Remove" "Trial2" NetWork Number

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep18 Check the Secondary component change
    When Check CHS Subpage
	Given Add "Trial2" Family Number
	Given "Add" "Trial2" Places Number
	Given "Add" "Trial2" NetWork Number
	Given "Add" "Trial2" Home Devices
	Then Waiting 30 seconds
	Then Check CHS Group Offline has 3-2-1-1 number

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep19 Check the Secondary home devices change
	When The user connect or disconnect WiFi off lenovo
	Given Close Vantage
	Given ReLaunch Vantage
	When Check CHS Subpage
	When Click Offline Dialog Close Button 
	Then Check CHS Group Offline has 3-2-1-1 number
	When The user connect or disconnect WiFi on lenovo
    Given Remove "Third" Faimily Number From "Trial2"Account	
	Given "Remove" "Trial2" Places Number
	Given "Remove" "Trial2" NetWork Number

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep20 Check the Secondary 1960*1080 screen
	When The user connect or disconnect WiFi on lenovo
	When Check CHS Subpage
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 1960  | 1080   |           |            |
	Then Take Screen Shot 20UI01 in 8576 under CHScreenShotResult
	Given Slide The Page To "-100"
	Then Take Screen Shot 20UI02 in 8576 under CHScreenShotResult

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep21 Check the Secondary 1000*1000 screen
	When Check CHS Subpage
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 1000  | 1000   |           |            |
	Then Take Screen Shot 21UI01 in 8576 under CHScreenShotResult
	Given Slide The Page To "-100"
	Then Take Screen Shot 21UI02 in 8576 under CHScreenShotResult

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep22 Check the Secondary 500*500 screen
	When Check CHS Subpage
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 500   | 500    |           |            |
	Then Take Screen Shot 22UI01 in 8576 under CHScreenShotResult
	Given Slide The Page To "-100"
	Then Take Screen Shot 22UI02 in 8576 under CHScreenShotResult
	Given Slide The Page To "-100"
	Then Take Screen Shot 22UI03 in 8576 under CHScreenShotResult

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep23 Check the admin 1960*1080 screen
	Given Remove "trialsecond" Account from Web Console
	Given User has Joined or Started a CHS "trialadmin"Group
	Then Check The Part of "Successfully login message"
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 1960  | 1080   |           |            |
	Then Take Screen Shot 23UI01 in 8576 under CHScreenShotResult
	Given Slide The Page To "-100"
	Then Take Screen Shot 23UI02 in 8576 under CHScreenShotResult
	
@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep24 Check the admin 1000*1000 screen
	When Check CHS Subpage
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 1000  | 1000   |           |            |
	Then Take Screen Shot 24UI01 in 8576 under CHScreenShotResult
	Given Slide The Page To "-100"
	Then Take Screen Shot 24UI02 in 8576 under CHScreenShotResult

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep25 Check the admin 500*500 screen
	When Check CHS Subpage
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 500   | 500    |           |            |
	Then Take Screen Shot 25UI01 in 8576 under CHScreenShotResult
	Given Slide The Page To "-100"
	Then Take Screen Shot 25UI02 in 8576 under CHScreenShotResult
	Given Slide The Page To "-100"
	Then Take Screen Shot 25UI03 in 8576 under CHScreenShotResult
	Given Remove Account from Web Console