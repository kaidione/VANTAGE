Feature: VAN10352_Part2_LWSToastMessagingTest
	Test Case：https://jira.tc.lenovo.com/browse/VAN-9695
	Author ：yangyu

@LWSToastMessagingTest
Scenario: VAN10352_TestStep15_Check click "More options" status
	Given Restart IMC Service
	Given Close Vantage
	Given ReLaunch Vantage
	Given Turn on Location for Vantagee
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage	
	When The user connect or disconnect WiFi on lenovo
	Then Waiting 10 seconds
	When The user connect or disconnect WiFi off lenovo
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1
	Then Check Wifi red Toast Pop up
	Then Click Critical moreinfo button
	Then Take Screen Shot 01UI in 10352 under LWScreenShotResult
	Then Click Critical ignore button

@LWSToastMessagingTest
Scenario: VAN10352_TestStep16_Check click red toast "ingnore" wait 10minutes
	When The user connect or disconnect WiFi on lenovo
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager
	Given Close Vantage
	Given ReLaunch Vantage
	Given Clear Notification Center History
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1
	Then Check Wifi red Toast Pop up
	Then Click Critical ignore button
	When Wait 11 minutes
	Then Check Current Network Is "__Do_Not_Trust_Network_Red_1"
	Then Check Wifi "red" Toast Pop up "1"
	Then Click Critical ignore button
    
@LWSToastMessagingTest
Scenario: VAN10352_TestStep17_Check connect red network twice within 10 minutes	
	Given Clear Notification Center History
	When The user connect or disconnect WiFi off __Do_Not_Trust_Network_Red_1
	When The user connect or disconnect WiFi on lenovo
	Given Close Vantage
	Given ReLaunch Vantage
	Then Waiting 10 seconds
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1
	Then Check Wifi red Toast Pop up
	Then Click Critical ignore button
	When The user connect or disconnect WiFi off __Do_Not_Trust_Network_Red_1
	When Wait 1 minutes
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1
	Then Check Wifi red Toast Pop up
	Then Click Critical ignore button
	
@LWSToastMessagingTest
Scenario: VAN10352_TestStep18_Check connect red network after 10 minutes
	Given Clear Notification Center History
	When The user connect or disconnect WiFi off __Do_Not_Trust_Network_Red_1
	When The user connect or disconnect WiFi on lenovo
	Given Close Vantage
	Given ReLaunch Vantage
	Then Waiting 10 seconds
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1
	Then Check Wifi red Toast Pop up
	Then Click Critical ignore button
	When The user connect or disconnect WiFi off __Do_Not_Trust_Network_Red_1
	When Wait 11 minutes
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1
	Then Check Wifi red Toast Pop up 
	Then Click Critical ignore button
	Then Check Wifi "red" Toast Pop up "0"

@LWSToastMessagingTest
Scenario: VAN10352_TestStep19_Check change network from green to red
	When The user connect or disconnect WiFi on lenovo
	Given Clear Notification Center History
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager
	Given Close Vantage
	Given ReLaunch Vantage
	Given Go to Wifisecurity
	When The user connect or disconnect WiFi on lenovo
	Then Check Wifi green Toast Pop up
	When The user connect or disconnect WiFi off lenovo
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1
	Then Check Wifi red Toast Pop up
	Then Click Critical ignore button
	Then Check Wifi green Toast Pop up
	
@LWSToastMessagingTest
Scenario: VAN10352_TestStep20_Check change network from red to green
	When The user connect or disconnect WiFi off __Do_Not_Trust_Network_Red_1
	When The user connect or disconnect WiFi on lenovo
	Given Clear Notification Center History
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager
	Given Close Vantage
	Given ReLaunch Vantage
	Given Go to Wifisecurity
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1
	Then Check Wifi red Toast Pop up
	When The user connect or disconnect WiFi off __Do_Not_Trust_Network_Red_1
	When The user connect or disconnect WiFi on lenovo
	Then Check Wifi green Toast Pop up
	Then Check Wifi red Toast Pop up
	Then Click Critical ignore button
	Then Check Wifi green Toast Pop up

@LWSToastMessagingTest
Scenario: VAN10352_TestStep22_change network red to green then change network green to red within 10min
	When The user connect or disconnect WiFi on lenovo
	Given Clear Notification Center History
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager
	Given Close Vantage
	Given ReLaunch Vantage
	Given Go to Wifisecurity
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1
	Then Check Wifi red Toast Pop up
	When The user connect or disconnect WiFi off __Do_Not_Trust_Network_Red_1
	When The user connect or disconnect WiFi on lenovo
	Then Check Wifi green Toast Pop up
	Then Check Wifi red Toast Pop up
	Then Click Critical ignore button
	Then Check Wifi green Toast Pop up
	
@LWSToastMessagingTest
Scenario: VAN10352_TestStep23_change network red to green then change network green to red after 10min
	When The user connect or disconnect WiFi on lenovo
	Given Clear Notification Center History
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager
	Given Close Vantage
	Given ReLaunch Vantage
	Given Go to Wifisecurity
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1
	Then Check Wifi red Toast Pop up
	Then Click Critical ignore button
	When The user connect or disconnect WiFi off __Do_Not_Trust_Network_Red_1
	When The user connect or disconnect WiFi on lenovo
	Then Check Wifi green Toast Pop up
	When Wait 11 minutes
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1	
	Then Check Wifi red Toast Pop up

@LWSToastMessagingTest
Scenario: VAN10352_TestStep24_check reenable toast
	When The user connect or disconnect WiFi off __Do_Not_Trust_Network_Red_1
	When The user connect or disconnect WiFi on lenovo
	Given Close Vantage
	Given ReLaunch Vantage
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'Off' Within Subpage	
	Then Check Wifi reenable Toast Pop up	

@LWSToastMessagingTest
Scenario: VAN10352_TestStep25_check dissable location permission and reenable toast pop up
	Given Clear Notification Center History
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage	
	When The user connect or disconnect WiFi on lenovo	
	Given Close Vantage
	Given Turn off Location Permission for Vantage
	Then Check Wifi reenable Toast Pop up

@LWSToastMessagingTest
Scenario: VAN10352_TestStep26_check click reenable toast
	Given Clear Notification Center History
	Given Turn on Location for Vantagee
	Given Go to Wifisecurity	
	When Set the WiFi Security Toggle 'On' Within Subpage	
	When Set the WiFi Security Toggle 'Off' Within Subpage
	Then Check Wifi reenable Toast Pop up
	Then Click re-enable Toast	
	Then Waiting 10 seconds
	Then The WiFi Security toggle status within subpage 'On'

@LWSToastMessagingTest
Scenario: VAN10352_TestStep27_check click reenable toast in locaiton permission off status
	Given Clear Notification Center History
	Given Slide The Page To "-100"
	Given Go to Wifisecurity	
	When Set the WiFi Security Toggle 'On' Within Subpage	
	Given Turn off Location Service in Settings Page
	Then Check Wifi reenable Toast Pop up
	Then Click re-enable Toast	
	Then There is location dialog in LWS Page

@LWSToastMessagingTest
Scenario: VAN10352_TestStep28_check click reenable toast in locaiton service off status
	Given Clear Notification Center History
	Given Slide The Page To "-100"
	Given Turn on Location for Vantagee
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage	
	Given Close Vantage
	Given Turn off Location Permission for Vantage
	Then Check Wifi reenable Toast Pop up
	Then Click re-enable Toast	
	Then There is location dialog in LWS Page

@LWSToastMessagingTest
Scenario: VAN10352_TestStep29_check cilck reenable toast "no thanks"
	Given Clear Notification Center History
	Given Turn on Location for Vantagee
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage	
	When Set the WiFi Security Toggle 'Off' Within Subpage
	Then Check Wifi reenable Toast Pop up
	Then Click no thanks Toast	
	Then Check Wifi "reenable" Toast Pop up "0"

@LWSToastMessagingTest
Scenario: VAN10352_TestStep30_check click reenable toast "x"
	Given Clear Notification Center History
	Given Slide The Page To "-100"
	Given Turn on Location for Vantagee
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage	
	When Set the WiFi Security Toggle 'Off' Within Subpage
	Then Check Wifi reenable Toast Pop up
	Then Click close Toast	
	Then Check Wifi "reenable" Toast Pop up "0"

@LWSToastMessagingTest
Scenario: VAN10352_TestStep31_check click green toast link
	When The user connect or disconnect WiFi on lenovo
	Given Clear Notification Center History
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager
	Given Close Vantage
	Given ReLaunch Vantage
	Given Slide The Page To "-100"
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage	
	Then Check Wifi green Toast Pop up
	Then Click ok Toast	
	Then Take Screen Shot 31UI in 10352 under LWScreenShotResult

@LWSToastMessagingTest
Scenario: VAN10352_TestStep32_check reenable toast pop up after connect wifi 20s turn off
	Given Clear Notification Center History
	Given Slide The Page To "-100"
	Given Turn on Location for Vantagee
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When The user connect or disconnect WiFi on lenovo
	Then Waiting 20 seconds
	Given Turn off Location Service in Settings Page
	Then Check Wifi reenable Toast Pop up

@LWSToastMessagingTest
Scenario: VAN10352_TestStep33_01_Check click yellow toast "close"
	Given Turn on Location for Vantagee
	Given Clear Notification Center History
	When The user connect or disconnect WiFi off lenovo
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager
	Given Close Vantage
	Given ReLaunch Vantage
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Yellow_1
	Then Waiting 8 seconds
	Then Check Wifi yellow Toast Pop up
	Then Click close Toast	
	Then Check Wifi "yellow" Toast Pop up "0"

@LWSToastMessagingTest
Scenario: VAN10352_TestStep33_02_Check click yellow toast "change connection"
	Given Turn on Location for Vantagee
	Given Clear Notification Center History
	Given Slide The Page To "-100"
	When The user connect or disconnect WiFi on lenovo
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager
	Given Close Vantage
	Given ReLaunch Vantage
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Yellow_1
	Then Waiting 8 seconds
	Then Check Wifi yellow Toast Pop up
	Then Click change connection Toast	
	Then Check The Part of "internetaccess"
	Then Check Wifi "yellow" Toast Pop up "0"

@LWSToastMessagingTest
Scenario: VAN10352_TestStep33_03_Check click yellow toast "ingnore"
	Given Turn on Location for Vantagee
	Given Clear Notification Center History
	When The user connect or disconnect WiFi on lenovo
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager
	Given Close Vantage
	Given ReLaunch Vantage
	Given Go to Wifisecurity
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Yellow_1
	Then Check Wifi yellow Toast Pop up
	Then Waiting 8 seconds
	Then Click yellow ignore Toast
	Then Check Wifi "yellow" Toast Pop up "0"