Feature: VAN18058_HSToolbarRegression
	Test Case： https://jira.tc.lenovo.com/browse/VAN-18058
	Author： caopp2
	Author： HaiYe Li  
	 

@HSToolbar
Scenario: VAN18058_TestStep01_Check toolbar on taskbar automatically turn on or turn off
	Given Go to Power Page
	Given Go To Lenovo Vantage ToolBar Panel
	Given turn on toolbar btn
	Then Toolbar will automatically pin on the taskbar
	Given turn off toolbar btn
	Then Toolbar will automatically uppin on the taskbar

@HSToolbar
Scenario: VAN18058_TestStep02_Check the toolbar position 
	Given Go to Power Page  
	Given Go To Lenovo Vantage ToolBar Panel
	Then  the position of Lenovo Vantage toolbar to the top area of Power page

@HSToolbar
Scenario: VAN18058_TestStep03_Check the description context
	Given Go to Power Page
	Given Go To Lenovo Vantage ToolBar Panel
	Then  Check Toolbar Description Context

@HSToolbar
Scenario: VAN18058_TestStep04_Check the UI Image
	Given Go to Power Page
	Given Go To Lenovo Vantage ToolBar Panel
	Then  UI Image should be below the description context
	Then  Take Screen Shot VAN18058_TestStep04_CheckToolbarUIImage in 18058 under HSScreenShotResult

@HSToolbar
Scenario: VAN18058_TestStep05_Check the description tips
	Given Go to Power Page
	Given Go To Lenovo Vantage ToolBar Panel
	Then  Check Toolbar Description Tips

@HSToolbar
Scenario: VAN18058_TestStep06_Check the Toolbar status after switch page
	Given Go to Power Page
	Given Go To Lenovo Vantage ToolBar Panel
	Given Turn On Toolbar from Vantage
	When  Switch page
	Then  Back to system,Toolbar status had no change after turn it On
	Then  Take Screen Shot VAN18058_TestStep06_CheckToolbarPageAfterTurnOnToolBar in 18058 under HSScreenShotResult	

@HSToolbar
Scenario: VAN18058_TestStep07_Check the Toolbar status after sleep system
	Given Go to Power Page
	Given Go To Lenovo Vantage ToolBar Panel
	Given Turn On Toolbar from Vantage
	When  Enter sleep
	Then  Back to system,Toolbar status had no change after turn it On
	Then  Take Screen Shot VAN18058_TestStep07_CheckToolbarPageAfterTurnOnToolBar in 18058 under HSScreenShotResult	

@HSToolbar
Scenario: VAN18058_TestStep08_Check the Toolbar status after hibernate system
	Given Go to Power Page
	Given Go To Lenovo Vantage ToolBar Panel
	Given Turn Off Toolbar from Vantage
	When  Enter hibernate
	Then  Back to system,Toolbar status had no change after turn it Off
	Then  Take Screen Shot VAN18058_TestStep08_CheckToolbarPageAfterTurnOffToolBar in 18058 under HSScreenShotResult	

@HSToolbar
Scenario: VAN18058_TestStep10_Check  toolbar on taskbar automatically turn on 
	Given Go to Power Page
	Given Go To Lenovo Vantage ToolBar Panel
	Given turn on toolbar btn
	Then Toolbar will automatically pin on the taskbar

@HSToolbar
Scenario: VAN18058_TestStep11_Check toolbar on taskbar automatically turn off 
	Given Go to Power Page
	Given Go To Lenovo Vantage ToolBar Panel
	Given turn off toolbar btn
	Then Toolbar will automatically unpin on the taskbar

@HSToolbar
Scenario: VAN18058_TestStep12_Check the Toolbar status after Pin on taskbar
	Given Go to Power Page
	Given Go To Lenovo Vantage ToolBar Panel
	When  pin toolbar on Taskbar settings
	Then  the toolbar pin to taskbar
	Then  the toolbar toggle is turn On in 30s

@HSToolbar
Scenario: VAN18058_TestStep13_Check the Toolbar status after UnPin on taskbar
	Given Go to Power Page
	Given Go To Lenovo Vantage ToolBar Panel
	When  unpin toolbar on Taskbar settings
	Then  the taskbar doesn't display the toolbar
	Then  the toolbar toggle is turn Off in 30s

@HSToolbar
Scenario: VAN18058_TestStep14_Check  Disconnect the internet turn off/on toolbar
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given Go To Lenovo Vantage ToolBar Panel
	Given turn on toolbar btn
	Then Toolbar will automatically pin on the taskbar
	Given turn off toolbar btn
	Then Toolbar will automatically uppin on the taskbar
	When The user connect or disconnect WiFi on lenovo


#@HSToolbar
Scenario: VAN18058_TestStep15_Check the metric data after turn on toolbar
	Given Set Metric on
	And Launch Http Traffic Capturer
	And Start Capture
	Given Launch Vantage
	Given Go to Power Page
	Given Go To Lenovo Vantage ToolBar Panel
	Given Turn Off Toolbar from Vantage
	Given clear data
	Given Turn On Toolbar from Vantage
	Then  the metric data is as expected with Test VAN18058 and Name ToolBarValueOn and Timeout 20

#@HSToolbar
Scenario: VAN18058_TestStep16_Check the metric data after turn off toolbar
	Given Go to Power Page
	Given Go To Lenovo Vantage ToolBar Panel
	Given Turn On Toolbar from Vantage
	Given clear data
	Given Turn Off Toolbar from Vantage
	Then  the metric data is as expected with Test VAN18058 and Name ToolBarValueOff and Timeout 20
	Given Stop Capture

@HSToolbar
Scenario: VAN18058_TestStep17_Check turn on toolbar uninstall Vantage Taskbar Icon 
	Given Go to Power Page
	Given Go To Lenovo Vantage ToolBar Panel
	Given turn on toolbar btn
	Then Toolbar will automatically pin on the taskbar
	Given Uninstall the lenovo vatage
	Then Click Toolbar
	Then Click AllSettingsBtn Show Page

@HSToolbarThinkPad @SmokeHSToolbarThinkPad
Scenario: VAN18058_TestStep18_Check ThinkCenter AIO  no Lenovo Vantage toolbar feature on Power page and taskbar
	Given Go to Devices Settings UI
	Given Check Power Page
	Then  Check Toolbar on the taskbar