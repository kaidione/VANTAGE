Feature: VAN10729_Part2_LWSInSecurityAdvisorofVantage
	Test Case：https://jira.tc.lenovo.com/browse/VAN-10729
	Author ：fengya2

@LWSInSAOfVAN
Scenario:VAN10729_TestStep27_old plugin and check LWS
	When  Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin"
	Given Copy "79" Plugin to Install
	When Start the IMC service in the task manager
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When LWS Text Status is disabled
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Close Vantage
	When Launch Vantage
	Given Go to Wifisecurity
	When LWS Text Status is enabled
	When Click expand in LWS Page
	Then Take Screen Shot 27UI in 10729 under LWScreenShotResult

@LWSInSAOfVAN
Scenario:VAN10729_TestStep28_new plugin and check LWS
	When  Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin"
	Given Copy "68" Plugin to Install
	When Start the IMC service in the task manager
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When LWS Text Status is disabled
	When Set the WiFi Security Toggle 'On' Within Subpage
	When LWS Text Status is enabled
	When Click expand in LWS Page
	Then Take Screen Shot 28UI in 10729 under LWScreenShotResult

@LWSInSAOfVAN
Scenario:VAN10729_TestStep35_Given S3 for a while
	Given Clear Notification Center History
	Given Turn on Location for Vantagee
	When The user connect or disconnect WiFi on lenovo
	When Enter sleep
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When LWS Text Status is disabled
	When Check Wifi reenable Toast Pop up
	Then Click re-enable Toast
	When LWS Text Status is enabled
	Then Take Screen Shot 35UI in 10729 under LWScreenShotResult

@LWSInSAOfVAN
Scenario:VAN10729_TestStep36_Given S4 for a while
	Given Turn on Location for Vantagee
	When The user connect or disconnect WiFi on lenovo
	When Enter hibernate
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When LWS Text Status is disabled
	When Check Wifi reenable Toast Pop up
	Then Click re-enable Toast
	When LWS Text Status is enabled
	Then Take Screen Shot 36UI in 10729 under LWScreenShotResult

@LWSInSAOfVAN
Scenario:VAN10729_TestStep42_disable location and CN check Threat locator
	Given Set Windows First Language "zh-CN"
	Given Close Vantage
	Given Launch Vantage
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'Off' Within Subpage
	Given Close Vantage
	Given Launch Vantage
	Given Go to Wifisecurity
	Then There is no Threat locator in Wifi Page
	Then Take Screen Shot 42UI in 10729 under LWScreenShotResult

@LWSInSAOfVAN
Scenario:VAN10729_TestStep43_enable location and CN check Threat locator
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Close Vantage
	Given Launch Vantage
	Given Go to Wifisecurity
	Then There is no Threat locator in Wifi Page
	Then Take Screen Shot 43UI in 10729 under LWScreenShotResult
	Given Set Windows First Language "en-US"

@LWSInSAOfVAN
Scenario:VAN10729_TestStep44_enable LWS and check toggle
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When Set the WiFi Security Toggle 'On' Within Subpage
	When LWS Text Status is enabled

@LWSInSAOfVAN
Scenario:VAN10729_TestStep45_disable LWS and check toggle
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When LWS Text Status is disabled

@LWSInSAOfVAN
Scenario:VAN10729_TestStep46_disable toggle and re-enable it
	Given Clear Notification Center History
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When Check Wifi reenable Toast Pop up
	Then Click re-enable Toast
	Given Go to Wifisecurity
	When LWS Text Status is enabled

@LWSInSAOfVAN @lwssmoke10729
Scenario:VAN10729_TestStep47_disable toggle close vantage and re-enable it
	Given Clear Notification Center History
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Turn off Location Service in Settings Page
	Given Close Vantage
	Then Click re-enable Toast
	Then Waiting 10 seconds
	Then There is location dialog in LWS Page

@LWSInSAOfVAN
Scenario:VAN10729_TestStep48_set size to 1200,1080
	Given Turn on Location for Vantagee
	Given Go to Wifisecurity
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 1200   | 1080    |           |            |
	Then Take Screen Shot 4801UI in 10729 under LWScreenShotResult
	When Click expand button in LWS Page
	Then Take Screen Shot 4802UI in 10729 under LWScreenShotResult

@LWSInSAOfVAN
Scenario:VAN10729_TestStep49_set size to 992,1000
	Given Go to Wifisecurity
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 992   | 1000    |           |            |
	Then Take Screen Shot 49UI in 10729 under LWScreenShotResult
	When Click expand in LWS Page
	Then Take Screen Shot 4902UI in 10729 under LWScreenShotResult

@LWSInSAOfVAN
Scenario:VAN10729_TestStep50_set size to 768,1080
	Given Go to Wifisecurity
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 768   | 1000    |           |            |
	Then Take Screen Shot 50UI in 10729 under LWScreenShotResult
	When Click expand button in LWS Page
	Then Take Screen Shot 5002UI in 10729 under LWScreenShotResult

@LWSInSAOfVAN
Scenario:VAN10729_TestStep51_set size to 576,1080
	Given Go to Wifisecurity
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 576   | 1000    |           |            |
	Then Take Screen Shot 50UI in 10729 under LWScreenShotResult
	When Click expand in LWS Page
	Then Take Screen Shot 5102UI in 10729 under LWScreenShotResult

@LWSInSAOfVAN
Scenario:VAN10729_TestStep52_go to advanced security and wifi is disabled
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'Off' Within Subpage
	Given Go to Advanced Security
	Then Wifi Security is disabled in Advance Security
	Given Scroll the screen
	Then Take Screen Shot 52UI in 10729 under LWScreenShotResult

@LWSInSAOfVAN
Scenario:VAN10729_TestStep53_go to advanced security and click LWS
	Given Go to Advanced Security
	When Click wifi link in SA in LWS Page
	When LWS Text Status is disabled

@LWSInSAOfVAN
Scenario:VAN10729_TestStep54_go to advanced security and check UI of LWS
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Go to Advanced Security
	Then Wifi Security is enabled in Advance Security
	Given Scroll the screen
	Then Take Screen Shot 5401UI in 10729 under LWScreenShotResult
	Given Go to Wifisecurity
	Then Take Screen Shot 5402UI in 10729 under LWScreenShotResult