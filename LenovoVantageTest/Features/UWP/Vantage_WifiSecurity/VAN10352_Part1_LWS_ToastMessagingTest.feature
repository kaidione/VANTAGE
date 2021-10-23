Feature: VAN10352_Part1_LWS_ToastMessagingTest
	Test Case：https://jira.tc.lenovo.com/browse/VAN-10352
	Author ：fengya2

@LWSToastMessagingTest
Scenario: VAN10352_TestStep01_check green toast UI
	Given Clear Notification Center History
	When  Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager
	Given Turn on Location for Vantagee
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When The user connect or disconnect WiFi on SmartStorage_5G
	Then Check Wifi green Toast Pop up
	Then Click ok Toast

@LWSToastMessagingTest
Scenario: VAN10352_TestStep02_click green Ok button
	When The user connect or disconnect WiFi off SmartStorage_5G
	Given Clear Notification Center History
	When The user connect or disconnect WiFi on lenovo
	When Check Wifi green Toast Pop up
	Then Click ok Toast
	Then Check Wifi no Toast Pop up

@LWSToastMessagingTest
Scenario: VAN10352_TestStep03_click green x button
	When The user connect or disconnect WiFi off lenovo
	Given Clear Notification Center History
	When The user connect or disconnect WiFi on AutoTest
	When Check Wifi green Toast Pop up
	Then Click close Toast
	Then Check Wifi no Toast Pop up

@LWSToastMessagingTest
Scenario: VAN10352_TestStep05_check yellow toast UI
	When The user connect or disconnect WiFi off Autotest
	Given Clear Notification Center History
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Yellow_1
	Then Check Wifi yellow Toast Pop up

@LWSToastMessagingTest
Scenario: VAN10352_TestStep06_connect yellow network and click X
	Given Clear Notification Center History
	When The user connect or disconnect WiFi off __Do_Not_Trust_Network_Yellow_1
	Given wait 5 seconds
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Yellow_1
	When Check Wifi yellow Toast Pop up
	Then Click close Toast
	Then Check Wifi no Toast Pop up

@LWSToastMessagingTest
Scenario: VAN10352_TestStep07_waiting 10min yellow toast will pop up again
	Given Clear Notification Center History
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Yellow_1
	When  Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager
	When Check Wifi yellow Toast Pop up
	Given Clear Notification Center History
	When Wait 10 minutes
	Then Check Wifi yellow Toast Pop up

@LWSToastMessagingTest
Scenario: VAN10352_TestStep08_click yellow change connection button
	Given Clear Notification Center History
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Yellow_1
	When  Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager
	When Check Wifi yellow Toast Pop up
	When Click change connection Toast
	Then Take Screen Shot 08UI in 10352 under LWScreenShotResult

@LWSToastMessagingTest
Scenario: VAN10352_TestStep09_click yellow ignore button
	Given Clear Notification Center History
	When The user connect or disconnect WiFi off __Do_Not_Trust_Network_Yellow_1
	Given wait 5 seconds
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Yellow_1
	When Check Wifi yellow Toast Pop up
	Then Click change connection Toast
	Then Check Wifi no Toast Pop up

@LWSToastMessagingTest
Scenario: VAN10352_TestStep10_connect two yellow network
	Given Clear Notification Center History
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Yellow_1
	When  Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager
	When Check Wifi yellow Toast Pop up
	Then Click yellow ignore Toast
	When The user connect or disconnect WiFi off __Do_Not_Trust_Network_Yellow_1
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Yellow_0
	Then Check Wifi yellow Toast Pop up

@LWSToastMessagingTest
Scenario: VAN10352_TestStep11_connect yellow network twice
	Given Clear Notification Center History
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Yellow_0
	When  Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager
	When Check Wifi yellow Toast Pop up
	When The user connect or disconnect WiFi off __Do_Not_Trust_Network_Yellow_0
	Given Clear Notification Center History
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Yellow_0
	Then Check Wifi yellow Toast Pop up

@LWSToastMessagingTest
Scenario: VAN10352_TestStep12_connect red network
	When The user connect or disconnect WiFi off __Do_Not_Trust_Network_Yellow_0
	Given Clear Notification Center History
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1
	When Check Wifi red Toast Pop up
	Then Take Screen Shot 12UI in 10352 under LWScreenShotResult
	Then Click Critical change connection button

@LWSToastMessagingTest
Scenario: VAN10352_TestStep13_connect red network and click change connection button
	When The user connect or disconnect WiFi off __Do_Not_Trust_Network_Red_1
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1
	When Check Wifi red Toast Pop up
	Then Click Critical change connection button

@LWSToastMessagingTest
Scenario: VAN10352_TestStep14_connect red network and click ignore button
	When The user connect or disconnect WiFi off __Do_Not_Trust_Network_Red_1
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1
	When Check Wifi red Toast Pop up
	Then Click Critical ignore button

@LWSToastMessagingTest
Scenario: VAN10352_TestStep3401_disable location and click content 
	Given Clear Notification Center History
	When The user connect or disconnect WiFi on SmartStorage_5G
	Then Check Wifi green Toast Pop up
	Then Click ok Toast
	Given Turn off Location Service in Settings Page
	When Check Wifi reenable Toast Pop up
	When Click content Toast
	Then There is location dialog in LWS Page

@LWSToastMessagingTest
Scenario: VAN10352_TestStep3402_disable location and click re-enable button
	Given Clear Notification Center History
	Given Turn on Location for Vantagee
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Close Vantage
	Given Turn off Location Service in Settings Page
	When Check Wifi reenable Toast Pop up
	When Click re-enable Toast
	Then There is location dialog in LWS Page

@LWSToastMessagingTest
Scenario: VAN10352_TestStep3403_disable location and click no thanks button
	Given Clear Notification Center History
	Given Turn on Location for Vantagee
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Close Vantage
	Given Turn off Location Service in Settings Page
	When Check Wifi reenable Toast Pop up
	When Click no thanks Toast
	Then Check Wifi no Toast Pop up

@LWSToastMessagingTest
Scenario: VAN10352_TestStep35_disconnect A and connect B then check 
	Given Clear Notification Center History
	Given Turn on Location for Vantagee
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When The user connect or disconnect WiFi on Do_Not_Trust_Yellow_Network_1
	When Check Wifi green Toast Pop up
	Given Clear Notification Center History
	When The user connect or disconnect WiFi on lenovo
	When Check Wifi green Toast Pop up