Feature: VAN8576_Part1_CreateNewStatusPageOfAllUserInCHSGroup
	Test Case：https://jira.tc.lenovo.com/browse/VAN-8576
	Author：fengya2

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep01_connect CHS account for the first time
	When The user connect or disconnect WiFi on lenovo-5G
	Given Turn on Location for Vantagee
	Given User has Joined or Started a CHS "Subscriptionadmin"Group
	Then Waiting 10 seconds
	When Check CHS Subpage
	Then Take Screen Shot 01UI in 8576 under CHScreenShotResult

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep02_check go dashboard button
	When Check CHS Subpage
	Then Check The Part of "go to dashboard"
	Then Take Screen Shot 02UI in 8576 under CHScreenShotResult

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep03_click go dashboard button
	When Check CHS Subpage
	Then Check The Part of "go to dashboard"
	When Click CHS "go to dashboard" Button
	Then Waiting 15 seconds
	Then Take Screen Shot 03UI in 8576 under CHScreenShotResult

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep04_change family number
	When  Check CHS Subpage
	Given Change CHS Component From Web Consle Subscription Account AddFamilyNumber
	Then Waiting 30 seconds
	Then Check CHS Group Family member has 2 number
	Given Change CHS Component From Web Consle Subscription Account RemoveFamilyNumber
	Then Waiting 30 seconds
	Then Check CHS Group Family member has 1 number

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep05_change places number
	Given Change CHS Component From Web Consle Subscription Account RemoveFamilyNumber
	When  Check CHS Subpage
	Given Change CHS Component From Web Consle Subscription Account AddPlacesNumber
	Then Waiting 30 seconds
	Then Check CHS Group Places member has 2 number
	Given Change CHS Component From Web Consle Subscription Account RemovePlacesNumber
	Then Waiting 30 seconds
	Then Check CHS Group Places member has 1 number

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep07_change wifi network number
	Given Change CHS Component From Web Consle Subscription Account RemovePlacesNumber
	When Check CHS Subpage
	Given Change CHS Component From Web Consle Subscription Account AddWifiNetworkNumber
	Then Waiting 30 seconds
	Then Check CHS Group Wifi network has 1 number
	Given Change CHS Component From Web Consle Subscription Account RemoveWifiNetworkNumber
	Then Waiting 30 seconds
	Then Check CHS Group Wifi network has 0 number

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep08_change home devices number
	Given Change CHS Component From Web Consle Subscription Account RemoveWifiNetworkNumber
	When Check CHS Subpage
	Given Change CHS Component From Web Consle Subscription Account AddWifiNetworkNumber
	Given Change CHS Component From Web Consle Subscription Account AddHomeDeviceNumber
	Then Waiting 20 seconds
	Then Check CHS Group Home devices has 3 number
	Given Change CHS Component From Web Consle Subscription Account RemoveWifiNetworkNumber
	Then Waiting 10 seconds
	Then Check CHS Group Home devices has 0 number

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep09_change coponent and reopen CHS 
	Given Change CHS Component From Web Consle Subscription Account RemoveWifiNetworkNumber
	Given Change CHS Component From Web Consle Subscription Account ChangeCHSComponentFromWeb
	When Check CHS Subpage
	Then Waiting 30 seconds
	Then Check CHS Group Offline has 2-2-1-3 number

@CreateNeWStatusPageOfAllUserInCHSGroup
Scenario: VAN8576_TestStep10_change coponent and reopen CHS 
	When The user connect or disconnect WiFi off lenovo-5G
	Given Close Vantage
	Given ReLaunch Vantage
	When Check CHS Subpage
	When Click Offline Dialog Close Button 
	Then Check CHS Group Offline has 2-2-1-3 number
	When The user connect or disconnect WiFi on lenovo-5G
	Given Change CHS Component From Web Consle Subscription Account RemoveFamilyNumber
	Given Change CHS Component From Web Consle Subscription Account RemoveWifiNetworkNumber
	Given Change CHS Component From Web Consle Subscription Account RemovePlacesNumber
	Given Change CHS Component From Web Consle Subscription Account RemoveSubscribtionAccount


