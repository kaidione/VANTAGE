Feature: VAN10210_Part7_ToolbarRegressionTest
	ITest Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-10210
	Author： Jinglong Zhao
	Update： Pengjie Chen
	Conmments: TestStep241-280

Background:
	Given Turn on or off the narrator 'on'

@RapidChargeToolbar
Scenario: VAN10210_TestStep241_Check the Rapid charge button display off statue from toolbar
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Rapid charge
	When Turn on the Conservation mode
	Then The Rapid charge button display off statue
	When Close toolbar

@RapidChargeToolbar
Scenario: VAN10210_TestStep242_Check the Rapid charge button display off statue from toolbar
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn off the Rapid charge
	Then The Rapid charge button display off statue
	When Close toolbar

@RapidChargeToolbar
Scenario: VAN10210_TestStep243_Check The text display is Rapid charge off
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn off the Rapid charge
	Then Take screen shot TestStep241 in 10210 under ToolbarScreenShotResult after 0 seconds 
	When Close toolbar

@RapidChargeToolbar
Scenario: VAN10210_TestStep244_Check the Rapid charge toggle display off statue from vantage
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn off the Rapid charge
	When check the Rapid charge display
	When Close toolbar
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Then The Rapid charge button displays same as with Vantage

@RapidChargeToolbar
Scenario: VAN10210_TestStep245_Check the Rapid charge button display on statue from toolbar
	Given Pin toolbar to taskbar
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	When turn on Rapid charge from power page on Lenovo Vantgae
	When Launch toolbar
	Then The Rapid charge button display on statue
	When Close toolbar

@RapidChargeToolbar
Scenario: VAN10210_TestStep246_Check the Rapid charge button display off statue from toolbar
	Given Pin toolbar to taskbar
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	When turn off Rapid charge from power page on Lenovo Vantgae
	When Launch toolbar
	Then The Rapid charge button display off statue
	When Close toolbar

@RapidChargeToolbar
Scenario: VAN10210_TestStep247_01_Turn on Rapid charge and Uninstall vantage Check Rapid charge button display statue
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Rapid charge	
	When Close toolbar
	Given Uninstall the lenovo vatage
	When wait 120 seconds
	When Launch toolbar
	When wait 5 seconds
	Then The Rapid charge button display off statue
	When Close toolbar

@RapidChargeToolbar
Scenario: VAN10210_TestStep247_02_Install Vantage
	Given Install Vantage

@RapidChargeToolbar
Scenario: VAN10210_TestStep248_01_Turn off Rapid charge and Uninstall vantage Check Rapid charge button display statue
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn off the Rapid charge
	When check the Rapid charge display
	When Close toolbar
	Given Uninstall the lenovo vatage
	When wait 120 seconds
	When Launch toolbar
	When wait 5 seconds
	Then The Rapid charge button display off statue
	When Close toolbar
Scenario: VAN10210_TestStep248_02_Install Vantage
	Given Install Vantage

#@TestIdeaToolbar
#Scenario: VAN10210_TestStep249_Turn on Microphone Press hot key The Toolbar display off status
#	Given Machine support microphone
#	Given Pin toolbar to taskbar
#	Given Turn on microphone access
#	When Launch toolbar
#	When Turn on microphone from toolbar
#	Then The microhone display on status
#	Then Take Screen Shot TestStep249_01 in 10210 under ToolbarScreenShotResult
#	When Close toolbar
#	#When Press F4 Event
#	When Simulate PressKey F4 Event
#	When Launch toolbar
#	Then The microhone display off status
#	Then Take Screen Shot TestStep249_02 in 10210 under ToolbarScreenShotResult
#	When Close toolbar

#@TestIdeaToolbar
#Scenario: VAN10210_TestStep250_Turn off Microphone Press hot key The Toolbar display off status
#	Given Machine support microphone
#	Given Pin toolbar to taskbar
#	Given Turn on microphone access
#	When Launch toolbar
#	When Turn off microphone from toolbar
#	Then The microhone display off status
#	Then Take Screen Shot TestStep250_01 in 10210 under ToolbarScreenShotResult
#	When Close toolbar
#	#When Press F4 Event
#	When Launch toolbar
#	Then The microhone display on status
#	Then Take Screen Shot TestStep250_02 in 10210 under ToolbarScreenShotResult
#	When Close toolbar

#@TestIdeaToolbar
#Scenario: VAN10210_TestStep251_Turn off Keyboard backlight Press Fn+space hot key The button display low
#	Given Pin toolbar to taskbar
#	When Launch toolbar
#	When Turn off the Keyboard backlight
#	Then Take Screen Shot TestStep251_01 in 10210 under ToolbarScreenShotResult
#	When Close toolbar
#	#When Press Fn+space Event
#	When Launch toolbar
#	Then The Keyboard backlight button display low status from toolbar
#	Then Take Screen Shot TestStep251_02 in 10210 under ToolbarScreenShotResult
#	Given Close toolbar

#@TestIdeaToolbar
#Scenario: VAN10210_TestStep252_turn on Camera press hot key the Toolbar display off status
#	Given Pin toolbar to taskbar
#	Given turn on the Allow access to the camera toggle on this device
#	When Launch toolbar
#	When turn on Camera Privacy from Toolbar
#	Then Take Screen Shot TestStep252_01 in 10210 under ToolbarScreenShotResult
#	Given Close toolbar
#	#When Press F8 Event
#	When Launch toolbar
#	Then The camera button display off status from toolbar
#	Then Take Screen Shot TestStep252_02 in 10210 under ToolbarScreenShotResult
#	Given Close toolbar

#@TestIdeaToolbar
#Scenario: VAN10210_TestStep253_turn off Camera press hot key the Toolbar display on status
#	Given Pin toolbar to taskbar
#	Given turn on the Allow access to the camera toggle on this device
#	When Launch toolbar
#	When turn off Camera Privacy from Toolbar
#	Then Take Screen Shot TestStep253_01 in 10210 under ToolbarScreenShotResult
#	Given Close toolbar
#	#When Press F8 Event
#	When Launch toolbar
#	Then The camera button display on status from toolbar
#	Then Take Screen Shot TestStep253_02 in 10210 under ToolbarScreenShotResult
#	Given Close toolbar

#@TestIdeaToolbar
#Scenario: VAN10210_TestStep254_enable the special function press Fn+Esc hot key the Toolbar display F1-F12 function status
#	Given Pin toolbar to taskbar
#	When Launch toolbar
#	When Turn on Special function from toolbar
#	Then Take Screen Shot TestStep254_01 in 10210 under ToolbarScreenShotResult
#	Given Close toolbar
#	#When Press Fn+Esc Event
#	When Launch toolbar
#	Then The Top-row function button display F1-F12 function status on toolbar
#	Then Take Screen Shot TestStep254_02 in 10210 under ToolbarScreenShotResult
#	Given Close toolbar

@ToolbarLink
Scenario: VAN10210_TestStep268_Check View warranty option display
	Given Pin toolbar to taskbar
	When Launch toolbar
	Then The 'View warranty option' display within toolbar and text is correct 'View warranty options'

@ToolbarLink
Scenario: VAN10210_TestStep269_Check click View warranty Jump to http page and display same as with Vantage warranty view option
	Given Pin toolbar to taskbar
	When Launch toolbar
	Given Launch Vantage from Toolbar Via 'View warranty option' Link
	When wait 5 seconds
	Then Take Screen Shot TestStep269 in 10210 under ToolbarScreenShotResult

@ToolbarLink
Scenario: VAN10210_TestStep270_Check Comments & feedback display
	Given Pin toolbar to taskbar
	When Launch toolbar
	Then There is No 'Comments & feedback' Link

@ToolbarLink
Scenario: VAN10210_TestStep271_Check Comments & feedback display
	Given Close Vantage
	Given Pin toolbar to taskbar
	When Launch toolbar
	Given Launch Vantage from Toolbar Via 'Comments & feedback' Link
	Then The Comments feedback Nodisplay

@ToolbarPriorityThinkpad
Scenario: VAN10210_TestStep274_Check the priority and order of thinkpad
	Given Pin toolbar to taskbar
	When Launch toolbar
	Then Toolbar priority and order of the settings button is correct
	Then Take Screen Shot TestStep274 in 10210 under ToolbarScreenShotResult
	When Launch toolbar
	Then Close toolbar

@ToolbarPriorityIdeapad
Scenario: VAN10210_TestStep275_Check the priority and order of ideapad
	Given Pin toolbar to taskbar
	When Launch toolbar
	Then Toolbar priority and order of the settings button is correct
	Then Take Screen Shot TestStep275 in 10210 under ToolbarScreenShotResult

@ToolbarLink
Scenario: VAN10210_TestStep276_Check the device capability and shows the settings matrix accordingly
	Given Pin toolbar to taskbar
	When Launch toolbar
	Then Take Screen Shot TestStep276 in 10210 under ToolbarScreenShotResult

@ToolbarLink
Scenario: VAN10210_TestStep277_Check maximum number of the settings is 10
	Given Pin toolbar to taskbar
	When Launch toolbar
	Then Take Screen Shot TestStep277 in 10210 under ToolbarScreenShotResult

@ToolbarLink
Scenario: VAN10210_TestStep278_Check via Go to Lenovo Vantage link jump to Dashboard page
	Given Go to My Device Settings page
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Given Launch Vantage from Toolbar Via 'Go to Lenovo Vantage' Link
	Then The Current page display correct 'DashBoard'

@ToolbarLink
Scenario: VAN10210_TestStep279_Check via Go to Lenovo Vantage link right menu jump to Dashboard page
	Given Go to My Device Settings page
	Given Pin toolbar to taskbar
	Given Launch Vantage from Toolbar Via 'Go to Lenovo Vantage via right menu' Link
	Then The Current page display correct 'DashBoard'

@ToolbarLink
Scenario: VAN10210_TestStep280_Check via All Settings link jump to Power page
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Given Launch Vantage from Toolbar Via 'All Settings' Link
	Then The Current page display correct 'Power'