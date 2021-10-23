Feature: VAN14081_NewPluginLWSCompatibilityTest
	Test Case：https://jira.tc.lenovo.com/browse/VAN-14081
	Author：yangyu

@NewPluginLWSCompatibilityTest
Scenario: VAN14081_TestStep01_NewPluginOldShellNewWeb check UI
	When  Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	Given Delete LWS Registry
	Given Copy "79" Plugin to Install
	When Start the IMC service in the task manager
	Given Install Old Shell
	When Delete VantageXML
	Given Close Vantage
	Given Launch Vantage
	Given Go to Wifisecurity
	Then LWS Text Status is disabled

@NewPluginLWSCompatibilityTest
Scenario: VAN14081_TestStep02_check toast
	Given Clear Notification Center History
	Given Go to Wifisecurity
	Given Turn on Location for Vantagee
	When Set the WiFi Security Toggle 'On' Within Subpage
	When The user connect or disconnect WiFi on lenovo
	When Check Wifi green Toast Pop up
	Then Click ok Toast
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Yellow_1
	When Check Wifi yellow Toast Pop up
	Then Click change connection Toast
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1
	When Check Wifi red Toast Pop up
	Then Click Critical ignore button

@NewPluginLWSCompatibilityTest
Scenario: VAN14081_TestStep03_check location dialog UI
	When The user connect or disconnect WiFi on lenovo
	Given Go to Wifisecurity
	Given Turn on Location for Vantagee
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Turn off Location Service in Settings Page
	Then There is location dialog in LWS Page
	Then Take Screen Shot locationDialog in 1408102UI under LWScreenShotResult
	When Click location dialog close button in LWS Page
	Then LWS Text Status is disabled

@NewPluginLWSCompatibilityTest
Scenario: VAN14081_TestStep04_click agree and turn on location 
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	Then There is location dialog in LWS Page
	When Click location dialog agree button in LWS Page
	Then  Check Location Settings Page
	Given Turn on Location for Vantagee
	Then LWS Text Status is enabled

@NewPluginLWSCompatibilityTest
Scenario: VAN14081_TestStep05_click agree and do anything
	Given Turn off Location Service in Settings Page
	Given Go to Wifisecurity
	Then There is location dialog in LWS Page
	When Click location dialog agree button in LWS Page
	Then Check Location Settings Page
	Then LWS Text Status is disabled

@NewPluginLWSCompatibilityTest
Scenario: VAN14081_TestStep06_connect 8 wifi
	Given Turn on Location for Vantagee
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Click expand button in LWS Page
	Then There is no show more button in Wifi Page
	When Connect 4 Wifi
	When Connect other 4 Wifi
	Given Go to Wifisecurity
	When Click expand button in LWS Page
	Then There is show more button in LWS Page
	Then Take Screen Shot 1408105UI in 14081 under LWScreenShotResult

@NewPluginLWSCompatibilityTest
Scenario: VAN14081_TestStep07_connect 9 wifi
	When Connect one more Wifi
	Given Go to Wifisecurity
	When Click expand button in LWS Page
	When Click show more button in LWS Page
	Then Scroll Screen to Visit Button
	Then Take Screen Shot 140810601UI in 14081 under LWScreenShotResult
	When Click show less button in LWS Page
	Then Take Screen Shot 140810602UI in 14081 under LWScreenShotResult

@NewPluginLWSCompatibilityTest
Scenario:VAN14081_TestStep08_disable toggle and re-enable it
	Given Clear Notification Center History
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When Check Wifi reenable Toast Pop up
	Then Click re-enable Toast
	Given Go to Wifisecurity
	Then LWS Text Status is enabled

@NewPluginLWSCompatibilityTest
Scenario:VAN14081_TestStep09_disable toggle close vantage and re-enable it
	Given Clear Notification Center History
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Turn off Location Service in Settings Page
	Given Close Vantage
	Then Click re-enable Toast
	Then Waiting 10 seconds
	Then There is location dialog in LWS Page

@NewPluginLWSCompatibilityTest
Scenario: VAN14081_TestStep10_NewPluginNewShellOldWeb check UI
	When  Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	Given Delete LWS Registry
	Given Copy "79" Plugin to Install
	When Start the IMC service in the task manager
	Given Install New Shell
	When Delete VantageXML
	Given Close Vantage
	Given Waiting 10 seconds
	Given Launch Vantage
	Given Go to Wifisecurity
	Then LWS Text Status is disabled

@NewPluginLWSCompatibilityTest
Scenario: VAN14081_TestStep11_check toast
	Given Clear Notification Center History
	Given Go to Wifisecurity
	Given Turn on Location for Vantagee
	When Set the WiFi Security Toggle 'On' Within Subpage
	When The user connect or disconnect WiFi on lenovo
	When Check Wifi green Toast Pop up
	Then Click ok Toast
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Yellow_1
	When Check Wifi yellow Toast Pop up
	Then Click change connection Toast
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1
	When Check Wifi red Toast Pop up
	Then Click Critical ignore button

@NewPluginLWSCompatibilityTest
Scenario: VAN14081_TestStep12_check location dialog UI
	When The user connect or disconnect WiFi on lenovo
	Given Go to Wifisecurity
	Given Turn on Location for Vantagee
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Turn off Location Service in Settings Page
	Then There is location dialog in LWS Page
	Then Take Screen Shot locationDialog in 1408102UI under LWScreenShotResult
	When Click location dialog close button in LWS Page
	Then LWS Text Status is disabled

@NewPluginLWSCompatibilityTest
Scenario: VAN14081_TestStep13_click agree and turn on location 
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	Then There is location dialog in LWS Page
	When Click location dialog agree button in LWS Page
	Then  Check Location Settings Page
	Given Turn on Location for Vantagee
	Then LWS Text Status is enabled

@NewPluginLWSCompatibilityTest
Scenario: VAN14081_TestStep14_click agree and do anything
	Given Turn off Location Service in Settings Page
	Given Go to Wifisecurity
	Then There is location dialog in LWS Page
	When Click location dialog agree button in LWS Page
	Then Check Location Settings Page
	Then LWS Text Status is disabled

@NewPluginLWSCompatibilityTest
Scenario: VAN14081_TestStep15_connect 8 wifi
	Given Turn on Location for Vantagee
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Click expand button in LWS Page
	Then There is no show more button in Wifi Page
	When Connect 4 Wifi
	When Connect other 4 Wifi
	Given Go to Wifisecurity
	When Click expand button in LWS Page
	Then There is show more button in LWS Page
	Then Take Screen Shot 1408105UI in 14081 under LWScreenShotResult

@NewPluginLWSCompatibilityTest
Scenario: VAN14081_TestStep16_connect 9 wifi
	When Connect one more Wifi
	Given Go to Wifisecurity
	When Click expand button in LWS Page
	When Click show more button in LWS Page
	Then Scroll Screen to Visit Button
	Then Take Screen Shot 140810601UI in 14081 under LWScreenShotResult
	When Click show less button in LWS Page
	Then Take Screen Shot 140810602UI in 14081 under LWScreenShotResult

@NewPluginLWSCompatibilityTest
Scenario:VAN14081_TestStep17_disable toggle and re-enable it
	Given Clear Notification Center History
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When Check Wifi reenable Toast Pop up
	Then Click re-enable Toast
	Given Go to Wifisecurity
	Then LWS Text Status is enabled

@NewPluginLWSCompatibilityTest
Scenario:VAN14081_TestStep18_disable toggle close vantage and re-enable it
	Given Clear Notification Center History
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Turn off Location Service in Settings Page
	Given Close Vantage
	Then Click re-enable Toast
	Then Waiting 10 seconds
	Then There is location dialog in LWS Page