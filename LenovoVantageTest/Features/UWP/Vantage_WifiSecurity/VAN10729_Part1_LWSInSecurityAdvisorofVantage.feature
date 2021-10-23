Feature: VAN10729_Part1_LWSInSecurityAdvisorofVantage
	Test Case：https://jira.tc.lenovo.com/browse/VAN-10729
	Author ：fengya2

@LWSInSAOfVAN @lwssmoke10729
Scenario:VAN10729_TestStep01_first install VAN and check LWS UI
	Given Uninstall the lenovo vatage
	When  Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	Given Delete LWS Registry
	When Start the IMC service in the task manager
	Given Install Vantage
	Given Go to Wifisecurity
	When LWS Text Status is disabled
	Then Take Screen Shot 01UI in 10729 under LWScreenShotResult

@LWSInSAOfVAN
Scenario:VAN10729_TestStep02_There is no Threat locator
	Given Go to Wifisecurity
	Then There is no Threat locator in Wifi Page

@LWSInSAOfVAN
Scenario:VAN10729_TestStep03_offline and check Threat locator
	When The user connect or disconnect WiFi off SmartStorage_5G
	Given Go to Wifisecurity
	Then There is no Threat locator in Wifi Page
	When The user connect or disconnect WiFi on lenovo

@LWSInSAOfVAN
Scenario:VAN10729_TestStep05_check Enable Wifi Security button
	When The user connect or disconnect WiFi on SmartStorage_5G
	Given Go to Wifisecurity
	Then There is no Enable wifi security Btn in Wifi Page

@CaseNeedTestBlueBar
Scenario:VAN10729_TestStep06_check blue bar
	Given Uninstall the lenovo vatage
	When  Stop the IMC service in the task manager
	Given Delete LWS "Plugin Data"
	Given Delete LWS Registry
	When  Start the IMC service in the task manager
	Given Install Vantage
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	Then The Tutorial Will Pop up And Show SlideBlueBar

@CaseNeedTestBlueBar
Scenario:VAN10729_TestStep07_click blue bar yes button
	Given Uninstall the lenovo vatage
	When  Stop the IMC service in the task manager
	Given Delete LWS "Plugin Data"
	Given Delete LWS Registry
	When  Start the IMC service in the task manager
	Given Install Vantage
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	Then The Tutorial Will Pop up And Show SlideBlueBar
	When Click CHS "Yes" Button
	When LWS Text Status is enabled

@LWSInSAOfVAN @lwssmoke10729
Scenario:VAN10729_TestStep08_network history will show up
	Given Go to Wifisecurity
	Given Turn on Location for Vantagee
	When Set the WiFi Security Toggle 'On' Within Subpage
	Then There is network history title in LWS Page

@LWSInSAOfVAN
Scenario:VAN10729_TestStep09_history list set collapse as default
	Given Go to Wifisecurity
	Then There is expand link in LWS Page

@LWSInSAOfVAN
Scenario:VAN10729_TestStep10_click expand button
	Given Go to Wifisecurity
	Then There is expand link in LWS Page
	When Click expand in LWS Page
	Then Take Screen Shot 10UI in 10729 under LWScreenShotResult

@LWSInSAOfVAN @lwssmoke10729
Scenario:VAN10729_TestStep11_disable location service
	Given Go to Wifisecurity
	Given Turn off Location Service in Settings Page
	Then There is location dialog in LWS Page
	Then Take Screen Shot locationDialog in 10729 under LWScreenShotResult
	When Click location dialog close button in LWS Page
	When LWS Text Status is disabled

@LWSInSAOfVAN
Scenario:VAN10729_TestStep12_disable location permission
	Given Turn on Location for Vantagee
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Turn off Location Permission for Vantage
	Then There is location dialog in LWS Page
	When Click location dialog close button in LWS Page
	When LWS Text Status is disabled

@CaseNeedTestBlueBar
Scenario:VAN10729_TestStep13_click blue bar no button
	Given Uninstall the lenovo vatage
	When  Stop the IMC service in the task manager
	Given Delete LWS "Plugin Data"
	Given Delete LWS Registry
	When  Start the IMC service in the task manager
	Given Install Vantage
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	Then The Tutorial Will Pop up And Show SlideBlueBar
	When Click CHS "no" Button
	When LWS Text Status is disabled

@LWSInSAOfVAN
Scenario:VAN10729_TestStep14_disable location permission and enable it
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	Then There is location dialog in LWS Page
	When Click location dialog agree button in LWS Page
	Then  Check Location Settings Page
	Given Turn on Location for Vantagee
	When LWS Text Status is enabled

@LWSInSAOfVAN @lwssmoke10729
Scenario:VAN10729_TestStep15_disable location service and enable it
	Given Turn off Location Service in Settings Page
	Given Go to Wifisecurity
	Then There is location dialog in LWS Page
	When Click location dialog agree button in LWS Page
	Then  Check Location Settings Page
	Given Turn on Location for Vantagee
	When Set the WiFi Security Toggle 'On' Within Subpage
	When LWS Text Status is enabled

@LWSInSAOfVAN
Scenario:VAN10729_TestStep16_disable location service and do nothing
	Given Turn off Location Service in Settings Page
	Given Go to Wifisecurity
	Then There is location dialog in LWS Page
	When Click location dialog agree button in LWS Page
	Then Check Location Settings Page
	When LWS Text Status is disabled

@LWSInSAOfVAN
Scenario:VAN10729_TestStep17_disable location and check LWS status
	Given Turn on Location for Vantagee
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When LWS Text Status is disabled

@LWSInSAOfVAN
Scenario:VAN10729_TestStep18_enable LWS and check history list
	Given Turn on Location for Vantagee
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When LWS Text Status is enabled
	When Click expand in LWS Page
	Then Take Screen Shot 18UI in 10729 under LWScreenShotResult

@LWSInSAOfVAN
Scenario:VAN10729_TestStep19_less than 4 networks
	Given Go to Wifisecurity
	Then There is no show more button in Wifi Page

@LWSInSAOfVAN
Scenario:VAN10729_TestStep20_connect 8 networks
	Given Go to Wifisecurity
	When Click expand in LWS Page
	Then There is no show more button in Wifi Page
	When Connect 4 Wifi
	When Connect other 4 Wifi
	Then Kill chrome.exe Process
	Then There is show more button in LWS Page
	Then Take Screen Shot 20UI in 10729 under LWScreenShotResult

@LWSInSAOfVAN
Scenario:VAN10729_TestStep21_click show more button
	Given Go to Wifisecurity
	When Click expand in LWS Page
	When Click show more button in LWS Page
	Then There is show less button in LWS Page
	Then Scroll Screen to Visit Button
	Then Take Screen Shot 20UI in 10729 under LWScreenShotResult

@LWSInSAOfVAN
Scenario:VAN10729_TestStep22_connect 9 networks
	When Connect one more Wifi
	Given Go to Wifisecurity
	When Click expand in LWS Page
	When Click show more button in LWS Page
	Then Scroll Screen to Visit Button
	Then Take Screen Shot 22UI in 10729 under LWScreenShotResult

@LWSInSAOfVAN
Scenario:VAN10729_TestStep23_click show more and check networks
	Given Go to Wifisecurity
	When Click expand in LWS Page
	When Click show more button in LWS Page
	Then Scroll Screen to Visit Button
	Then Take Screen Shot 23UI in 10729 under LWScreenShotResult

@LWSInSAOfVAN
Scenario:VAN10729_TestStep24_click show less and check networks
	Given Go to Wifisecurity
	When Click expand in LWS Page
	When Click show more button in LWS Page
	When Click show less button in LWS Page
	Then Take Screen Shot 24UI in 10729 under LWScreenShotResult

@LWSInSAOfVAN
Scenario:VAN10729_TestStep25_connect same network
	Given Go to Wifisecurity
	When The user connect or disconnect WiFi on SmartStorage_5G
	Then Waiting 5 seconds
	When Click expand in LWS Page
	Then Take Screen Shot 25UI in 10729 under LWScreenShotResult

@LWSInSAOfVAN
Scenario:VAN10729_TestStep26_connect three different networks
	When Connect other 4 Wifi
	Then Click Critical ignore button
	Given Go to Wifisecurity
	When Click expand in LWS Page
	Then Waiting 1 seconds
	Then Take Screen Shot 26UI in 10729 under LWScreenShotResult