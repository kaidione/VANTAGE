Feature: VFC2224_LWSUiForLE
	Test Case：https://jira.tc.lenovo.com/browse/VFC-2224
	Author ：Yangyu

@LeLWS
Scenario: VFC2224_TestStep01_Check system update power medi
	Given Uninstall the lenovo vatage
	When  Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	Given Delete LWS Registry
	When Start the IMC service in the task manager
	Given Install Vantage
	When Click lwstab in LWS Page
	When LWS Text Status is disabled
	Then There is LWSIntroduction in LWS Page
	Then Take Screen Shot 01UI in 2224 under LWScreenShotResult

@LeLWS
Scenario: VFC2224_TestStep02_Check system update power medi
	When Click lwstab in LWS Page
	Then There is no Threat locator in Wifi Page

@LeLWS
Scenario: VFC2224_TestStep03_Check system update power medi
	When The user connect or disconnect WiFi off lenovo
	When Click lwstab in LWS Page
	Then There is no Threat locator in Wifi Page
	When The user connect or disconnect WiFi on SmartStorage_5G

@LeLWS
Scenario:VFC2224_TestStep04_check Enable Wifi Security button
	When The user connect or disconnect WiFi on SmartStorage_5G
	When Click lwstab in LWS Page
	Then There is no Enable wifi security Btn in Wifi Page

@CaseNeedTestBlueBarLE
Scenario:VFC2224_TestStep05_check blue bar
	Given Uninstall the lenovo vatage
	When  Stop the IMC service in the task manager
	Given Delete LWS "Plugin Data"
	Given Delete LWS Registry
	When  Start the IMC service in the task manager
	Given Install Vantage
	When Click lwstab in LWS Page
	When Set the WiFi Security Toggle 'On' Within Subpage
	Then The Tutorial Will Pop up And Show SlideBlueBar

@CaseNeedTestBlueBarLE
Scenario:VFC2224_TestStep06_click blue bar yes button
	Given Uninstall the lenovo vatage
	When  Stop the IMC service in the task manager
	Given Delete LWS "Plugin Data"
	Given Delete LWS Registry
	When  Start the IMC service in the task manager
	Given Install Vantage
	When Click lwstab in LWS Page
	When Set the WiFi Security Toggle 'On' Within Subpage
	Then The Tutorial Will Pop up And Show SlideBlueBar
	When Click CHS "Yes" Button
	When LWS Text Status is enabled

@LeLWS
Scenario:VFC2224_TestStep07_network history will show up
	When Click lwstab in LWS Page
	Given Turn on Location for Vantagee
	When Set the WiFi Security Toggle 'On' Within Subpage
	Then There is network history title in LWS Page

@LeLWS
Scenario:VFC2224_TestStep08_click collapse button
	When Click lwstab in LWS Page
	Then There is expandstatus in LWS Page
	Then Take Screen Shot 08UI in 2224 under LWScreenShotResult
	When Click collapse in LWS Page

@LeLWS
Scenario:VFC2224_TestStep09_history list set expand as default
	When Click lwstab in LWS Page
	Then There is expandstatus in LWS Page
	Then Take Screen Shot 09UI in 2224 under LWScreenShotResult

@LeLWS
Scenario:VFC2224_TestStep10_click location dialog second time
	When Click lwstab in LWS Page
	Given Turn off Location Service in Settings Page
	Then There is location dialog in LWS Page
	Then Take Screen Shot 10UI01 in 2224 under LWScreenShotResult 
	When Click location dialog close button in LWS Page
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Click location dialog close button in LWS Page
	Then Take Screen Shot 10UI02 in 2224 under LWScreenShotResult 
	When LWS Text Status is disabled

@LeLWS
Scenario:VFC2224_TestStep11_trun location permission click location dialog
	Given Turn on Location for Vantagee
	When Click lwstab in LWS Page
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Turn off Location Permission for Vantage
	Then There is location dialog in LWS Page
	When Click location dialog close button in LWS Page
	When LWS Text Status is disabled

@CaseNeedTestBlueBarLE
Scenario:VFC2224_TestStep12_click blue bar no button
	Given Uninstall the lenovo vatage
	When  Stop the IMC service in the task manager
	Given Delete LWS "Plugin Data"
	Given Delete LWS Registry
	When  Start the IMC service in the task manager
	Given Install Vantage
	When Click lwstab in LWS Page
	When Set the WiFi Security Toggle 'On' Within Subpage
	Then The Tutorial Will Pop up And Show SlideBlueBar
	When Click CHS "no" Button
	When LWS Text Status is disabled

@LeLWS
Scenario:VFC2224_TestStep13_disable location permission and enable it
	When Click lwstab in LWS Page
	When Set the WiFi Security Toggle 'On' Within Subpage
	Then There is location dialog in LWS Page
	When Click location dialog agree button in LWS Page
	Then  Check Location Settings Page
	Given Turn on Location for Vantagee
	When Set the WiFi Security Toggle 'On' Within Subpage
	When LWS Text Status is enabled

@LeLWS
Scenario:VFC2224_TestStep14_disable location service and enable it
	Given Turn off Location Service in Settings Page
	When Click lwstab in LWS Page
	Then There is location dialog in LWS Page
	When Click location dialog agree button in LWS Page
	Then  Check Location Settings Page
	Given Turn on Location for Vantagee
	When Set the WiFi Security Toggle 'On' Within Subpage
	When LWS Text Status is enabled

@LeLWS
Scenario:VFC2224_TestStep15_disable location service and do nothing
	Given Turn off Location Service in Settings Page
	When Click lwstab in LWS Page
	Then There is location dialog in LWS Page
	When Click location dialog agree button in LWS Page
	Then Check Location Settings Page
	When LWS Text Status is disabled

@LeLWS
Scenario:VFC2224_TestStep16_disable location and check LWS status
	Given Turn on Location for Vantagee
	When Click lwstab in LWS Page
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When LWS Text Status is disabled

@LeLWS
Scenario:VFC2224_TestStep17_enable LWS and check history list
	Given Turn on Location for Vantagee
	When Click lwstab in LWS Page
	When Set the WiFi Security Toggle 'On' Within Subpage
	When LWS Text Status is enabled
	When Click expand in LWS Page
	Then Take Screen Shot 17UI in 2224 under LWScreenShotResult

@LeLWS
Scenario:VFC2224_TestStep18_less than 4 networks
	When Click lwstab in LWS Page
	Then There is no show more button in Wifi Page

@LeLWS
Scenario:VFC2224_TestStep19_connect 8 networks
	When Click lwstab in LWS Page
	Then There is no show more button in Wifi Page
	When Connect 4 Wifi
	When Connect other 4 Wifi
	When Click expand in LWS Page
	Then There is show more button in LWS Page
	Then Kill chrome.exe Process
	Then Kill msedge.exe Process
	Then Take Screen Shot 19UI in 2224 under LWScreenShotResult

@LeLWS
Scenario:VFC2224_TestStep20_click show more button
	When Click lwstab in LWS Page
	When Click expand in LWS Page
	When Click show more button in LWS Page
	Then There is show less button in LWS Page
	Then Take Screen Shot 20UI in 2224 under LWScreenShotResult

@LeLWS
Scenario:VFC2224_TestStep21_Check connect 9 networks
	When Connect one more Wifi
	When Click lwstab in LWS Page
	When Click expand in LWS Page
	When Click show more button in LWS Page
	Then Take Screen Shot 21UI in 2224 under LWScreenShotResult

@LeLWS
Scenario:VFC2224_TestStep22_Check show more and check networks
	When Click lwstab in LWS Page
	When Click expand in LWS Page
	When Click show more button in LWS Page
	Then Take Screen Shot 22UI in 2224 under LWScreenShotResult

@LeLWS
Scenario:VFC2224_TestStep23_click show less and check networks
	When Click lwstab in LWS Page
	When Click expand in LWS Page
	When Click show more button in LWS Page
	When Click show less button in LWS Page
	Then Take Screen Shot 23UI in 2224 under LWScreenShotResult

@LeLWS
Scenario:VFC2224_TestStep24_connect same network
	When Click lwstab in LWS Page
	When The user connect or disconnect WiFi on SmartStorage_5G
	Then Waiting 5 seconds
	When Click expand in LWS Page
	Then Take Screen Shot 24UI in 2224 under LWScreenShotResult

@LeLWS
Scenario:VFC2224_TestStep25_connect three different networks
	When Connect other 4 Wifi
	Then Click Critical ignore button
	When Click lwstab in LWS Page
	When Click expand in LWS Page
	Then Waiting 1 seconds
	Then Take Screen Shot 25UI in 2224 under LWScreenShotResult

@LeLWS
Scenario:VFC2224_TestStep26_old plugin and check LWS
	When  Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin"
	Given Copy "79" Plugin to Install
	When Start the IMC service in the task manager
	Given Close Vantage
	Given Launch Vantage
	When Click lwstab in LWS Page
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Click expand in LWS Page
	Then Take Screen Shot 26UI in 2224 under LWScreenShotResult

@LeLWS
Scenario:VFC2224_TestStep27_new plugin and check LWS
	When  Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin"
	Given Copy "68" Plugin to Install
	When Start the IMC service in the task manager
	Given Close Vantage
	Given Launch Vantage
	When Click lwstab in LWS Page
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Click expand in LWS Page
	Then Take Screen Shot 27UI in 2224 under LWScreenShotResult

@LeLWS
Scenario:VFC2224_TestStep31_disable location and CN check Threat locator
	Given Set Windows First Language "zh-CN"
	When Click lwstab in LWS Page
	When Set the WiFi Security Toggle 'Off' Within Subpage
	Given Close Vantage
	Given Launch Vantage
	When Click lwstab in LWS Page
	Then There is no Threat locator in Wifi Page
	Then Take Screen Shot 31UI in 224 under LWScreenShotResult

@LeLWS
Scenario:VFC2224_TestStep32_enable location and CN check Threat locator
	When Click lwstab in LWS Page
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Close Vantage
	Given Launch Vantage
	When Click lwstab in LWS Page
	Then There is no Threat locator in Wifi Page
	Then Take Screen Shot 32UI in 224 under LWScreenShotResult
	Given Set Windows First Language "en-US"

@LeLWS
Scenario:VFC2224_TestStep33_enable location and check toggle
	Given Set Windows First Language "en-US"
	When Click lwstab in LWS Page
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When Set the WiFi Security Toggle 'On' Within Subpage
	When LWS Text Status is enabled

@LeLWS
Scenario:VFC2224_TestStep34_disable location and check toggle
	When Click lwstab in LWS Page
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When LWS Text Status is disabled

@LeLWS
Scenario:VFC2224_TestStep35_set size to 1200,1080
	Given Turn on Location for Vantagee
	When Click lwstab in LWS Page
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 1200   | 1080    |           |            |
	Then Take Screen Shot 3501UI in 2224 under LWScreenShotResult
	When Click expand in LWS Page
	Then Take Screen Shot 3502UI in 2224 under LWScreenShotResult

@LeLWS
Scenario:VFC2224_TestStep36_set size to 992,1000
	When Click lwstab in LWS Page
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 992   | 1000    |           |            |
	Then Take Screen Shot 36UI in 2224 under LWScreenShotResult
	When Click expand in LWS Page
	Then Take Screen Shot 3602UI in 2224 under LWScreenShotResult

@LeLWS
Scenario:VFC2224_TestStep37_set size to 768,1080
	When Click lwstab in LWS Page
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 768   | 1000    |           |            |
	Then Take Screen Shot 37UI in 2224 under LWScreenShotResult
	When Click expand in LWS Page
	Then Take Screen Shot 3702UI in 2224 under LWScreenShotResult

@LeLWS
Scenario:VFC2224_TestStep38_set size to 576,1080
	When Click lwstab in LWS Page
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 576   | 1000    |           |            |
	Then Take Screen Shot 38UI in 2224 under LWScreenShotResult
	When Click expand in LWS Page
	Then Take Screen Shot 3802UI in 2224 under LWScreenShotResult

@LeLWS
Scenario:VFC2224_TestStep39_Given idle for Five Minutes
	When Click lwstab in LWS Page
	When Waiting 300 seconds	
	When LWS Text Status is enabled
	Then There is LWSIntroduction in LWS Page
	Then Take Screen Shot 3901UI in 2224 under LWScreenShotResult
	When Click show more button in LWS Page
	Then Take Screen Shot 3902UI in 2224 under LWScreenShotResult
	When Click collapse in LWS Page
	Then Take Screen Shot 3903UI in 2224 under LWScreenShotResult	
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When LWS Text Status is disabled
	Then Take Screen Shot 3904UI in 2224 under LWScreenShotResult

@LeLWS
Scenario:VFC2224_TestStep40_check after S3 LWS normally
	When Click lwstab in LWS Page
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Click lwstab in LWS Page
	When Enter sleep	
	When LWS Text Status is enabled
	Then There is LWSIntroduction in LWS Page
	Then Take Screen Shot 4001UI in 2224 under LWScreenShotResult
	When Click show more button in LWS Page
	Then Take Screen Shot 4002UI in 2224 under LWScreenShotResult
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When LWS Text Status is disabled
	Then Take Screen Shot 4003UI in 2224 under LWScreenShotResult

@LeLWS
Scenario:VFC2224_TestStep41_check after S4 LWS normally
	When Click lwstab in LWS Page
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Click lwstab in LWS Page
	When Enter hibernate
	When LWS Text Status is enabled
	Then There is LWSIntroduction in LWS Page
	Then Take Screen Shot 4101UI in 2224 under LWScreenShotResult
	When Click show more button in LWS Page
	Then Take Screen Shot 4102UI in 2224 under LWScreenShotResult
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When LWS Text Status is disabled
	Then Take Screen Shot 4103UI in 2224 under LWScreenShotResult

