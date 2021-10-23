Feature: VAN27994_Part1_OSToolbarRegressionTest
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-27994
	Author： Haiye Li
	Conmments: TestStep01-50

Background:
	Given Turn on or off the narrator 'on'
	
@OSToolBar
Scenario: VAN27994_TestStep01_Check Toolbar icon should on the right side of
	Given Install the Lenovo Vantage
	When select the Enable the Lenovo Vantage toolbar checkbox
	Then the toolbar "should" pin to taskbar in New OS Within "2" Seconds
	Then the Toolbar icon should on the right side of
	When Take Screen Shot TestStep01Toolbar_icon_should_on_the_right in 27994 under ToolbarScreenShotResult
	
@OSToolBar
Scenario: VAN27994_TestStep02_the UI of toolbar icon should follow UI SPEC.
	Given Toolbar has been pin to Taskbar
	Then the toolbar pin to taskbar on NewOS
	When Take Screen Shot TestStep02Toolbar_icon_should_follow_UI_SPEC in 27994 under ToolbarScreenShotResult
	
@OSToolBar
Scenario: VAN27994_TestStep03_It will show toolbar panel
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Then toolbar close button should show
	When Take Screen Shot TestStep03Toolbar_panel_is_open in 27994 under ToolbarScreenShotResult	

@OSToolBar
Scenario: VAN27994_TestStep04_Click the battery icon again Toolbar panel will keep open
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Then toolbar close button should show
	Given Launch Toolbar On NewOS
	Then toolbar close button should show
	When Take Screen Shot TestStep04ClickTwice_Toolbar_panel_is_open in 27994 under ToolbarScreenShotResult		

@OSToolBar
Scenario: VAN27994_TestStep05_Toolbar panel will keep open.
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Then toolbar close button should show
	When Click on the top left of vantage
	Then toolbar close button should show
	When Take Screen Shot TestStep05ClickOther_Toolbar_panel_is_open in 27994 under ToolbarScreenShotResult	

@OSToolBar
Scenario: VAN27994_TestStep06_CheckTheToolbarTitle display
	When pin toolbar on Taskbar settings
	Given Launch Toolbar On NewOS
	Then Take Screen Shot TestStep06CheckToolbarName in 27994 under ToolbarScreenShotResult

@OSToolbarNoBattery
Scenario: VAN27994_TestStep07_Check the machine no battery Toolbar display
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Then Take Screen Shot CheckToolbariconAndBatteryVoltage in 27994 under ToolbarScreenShotResult
	
@OSToolbarThinkACDC
Scenario: VAN27994_TestStep08
	Given Click Device settings,enter Power page
	When Go to Battery Charge threshold section
	When Turn off Battery Charge threshold
	Given DC Condition(Connect the Adapter)
	Given Use "10.119.22.22" and Button "1001" make BatteryLevel "less" than "90"
	Given AC Condition(Connect the Adapter)
	When wait 90 seconds
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Then display the battery detail on the thinkpad ,the Ideapad doesn't display

@OSToolbarIdeaACDC
Scenario: VAN27994_TestStep256
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When the Machine access adapter
	Then display the battery detail on the thinkpad ,the Ideapad doesn't display

@OSToolbarACDC
Scenario: VAN27994_TestStep09
	Given Toolbar has been pin to Taskbar
	Given DC Condition(Connect the Adapter)
	When wait 90 seconds
	Given Launch Toolbar On NewOS
	When the Machine unconnected adapter
	Then display the Remaining Time on the Ideapad and Thinkpad
	When Take Screen Shot AC09Toolbar in 27994 under ToolbarScreenShotResult
	When Launch Vantage
	Given Go to Power Page
	When Take Screen Shot AC09PowerPage in 27994 under ToolbarScreenShotResult
	Given AC Condition(Connect the Adapter)

@OSTestDTToolbar
Scenario: VAN27994_TestStep10_Check the machine is DT Toolbar display
	Given Machine is DT
	Given Pin DT toolbar to taskbar
	When Launch DT toolbar
	Then Take Screen Shot TestStep10 in 27994 under ToolbarScreenShotResult
	Given Close Toolbar Background

@OSIdeaToolbarRapidChargeAC
Scenario: VAN27994_TestStep11_Check Rapid charge icon and show
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Rapid charge
	Given Turn on or off the narrator 'off'
	Given AC Condition(Connect the Adapter)
	Given Launch Toolbar On NewOS
	Then Take Screen Shot TestStep11_Check_Rapid_Charge_Icon in 27994 under HSScreenShotResult

@OSIdeaToolbarRapidChargeACDC
Scenario: VAN27994_TestStep12_Check Rapid charge icon and show
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Rapid charge
	Given Turn on or off the narrator 'off'
	When User make the machine from AC to DC
	Given Launch Toolbar On NewOS
	Then Take Screen Shot TestStep12_CheckNO_Rapid_Charge_Icon in 27994 under HSScreenShotResult

@OSIdeaToolbarRapidChargeAC
Scenario: VAN27994_TestStep13_Check Rapid charge icon and show
	Given Toolbar has been pin to Taskbar
	Given AC Condition(Connect the Adapter)
	Given Launch Toolbar On NewOS
	When Turn off the Rapid charge
	Given Turn on or off the narrator 'off'
	Given Launch Toolbar On NewOS
	Then Take Screen Shot TestStep13 in 27994 under HSScreenShotResult

@OSIdeaToolbarConservationModeAC 
Scenario: VAN27994_TestStep14_Check Conservation mode icon and show
	Given Machine support the conservation mode
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Conservation mode
	Given AC Condition(Connect the Adapter)
	Given Turn on or off the narrator 'off'
	Given Launch Toolbar On NewOS
	Then Take Screen Shot TestStep14_Check_ConservationMode_Icon in 27994 under HSScreenShotResult

@OSIdeaToolbarConservationModeACDC  
Scenario: VAN27994_TestStep15_Check Conservation mode icon and show
	Given Machine support the conservation mode
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Conservation mode
	When User make the machine from AC to DC
	Given Turn on or off the narrator 'off'
	Given Launch Toolbar On NewOS
	Then Take Screen Shot TestStep15_CheckNo_ConservationMode_Icon in 27994 under HSScreenShotResult

@OSIdeaToolbarConservationModeAC
Scenario: VAN27994_TestStep16_Check Conservation mode icon and show
	Given Machine support the conservation mode
	Given AC Condition(Connect the Adapter)
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn off the Conservation mode
	Given Turn on or off the narrator 'off'
	Given Launch Toolbar On NewOS
	Then Take Screen Shot TestStep16_CheckNo_ConservationMode_Icon in 27994 under HSScreenShotResult

@NOSAirplaneToolbaTthinkpad
Scenario: VAN27994_TestStep19_Check the battery gauge doesn't display Airplane power mode icon
	Given plug in charging adapter
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Turn off airplane power mode from toolbar
	Then the battery gauge doesnot display the Airplane Power Mode icon
	Given Waiting 5 seconds
	When Take Screen Shot TestStep19_doesnotDisplayAirplanePowerModeIcon in 27994 under ToolbarScreenShotResult

@OSTestDTToolbar
Scenario: VAN27994_TestStep20_Check this machine is DT the icon display is "L" icon
	Given Machine is DT
	Given Pin DT toolbar to taskbar
	When Launch DT toolbar
	Then Take Screen Shot TestStep20 in 27994 under ToolbarScreenShotResult
	Given Close Toolbar Background

@OSToolBar
Scenario: VAN27994_TestStep21_Check the battery gauge display
	Given Machine is IdeaPad or ThinkPad
	Given Toolbar has been pin to Taskbar
	When Take Screen Shot TestStep21_NBBatteryGaugeDisplay in 27994 under ToolbarScreenShotResult

#@OSWifiToolbar
Scenario: VAN27994_TestStep22_The Wi-fi security button displays same as with Vantage
	Given Machine support WIFISecurity
	Given Turn on permission
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Get wifi secirity status from toolbar
	Given Close Toolbar Background
	Given Go to Wifisecurity
	Then The Wi-fi security button displays same as with Vantage

#@OSWifiToolbar
Scenario: VAN27994_TestStep23_The hover tips display is "WiFi security"
	Given Machine support WIFISecurity
	Given Toolbar has been pin to Taskbar
	Given Turn on permission
	Given Launch Toolbar On NewOS
	When Turn on wifi security from toolbar
	When Turn off wifi security from toolbar
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	When Hover the mouse on the button wifisecurity
	Then Take Screen Shot TestStep36off in 27994 under HSScreenShotResult
	Given Launch Toolbar On NewOS
	When Turn on wifi security from toolbar
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	When Hover the mouse on the button wifisecurity
	Then Take Screen Shot TestStep36on in 27994 under HSScreenShotResult
	Given Close Toolbar Background

#@OSWifiToolbar
Scenario: VAN27994_TestStep24_The Wi-Fi security display on status
	Given Machine support WIFISecurity
	Given Toolbar has been pin to Taskbar
	Given Turn on permission
	Given Launch Toolbar On NewOS
	When Turn on wifi security from toolbar
	Then The wifi security display on status
	Given Close Toolbar Background

#@OSWifiToolbar
Scenario: VAN27994_TestStep25_The text display is "WiFi security on",The text info is displayed in the middle
	Given Machine support WIFISecurity
	Given Toolbar has been pin to Taskbar
	Given Turn on permission
	Given Launch Toolbar On NewOS
	When Turn off wifi security from toolbar
	When Turn on wifi security from toolbar
	Then Take screen shot TestStep25_Checktip_wifisecurityon in 27994 under HSScreenShotResult after 0 seconds 
	Given Close Toolbar Background

#@OSWifiToolbar
Scenario: VAN27994_TestStep26_The Wi-fi security button displays same as with toolbar
	Given Machine support WIFISecurity
	Given Toolbar has been pin to Taskbar
	Given Turn on permission
	Given Launch Toolbar On NewOS
	When wait 10 seconds
	When Turn off wifi security from toolbar
	When Turn on wifi security from toolbar
	Given Close Toolbar Background
	Given Go to Wifisecurity
	Then The Wi-fi security button displays on with Vantage

#@OSWifiToolbar
Scenario: VAN27994_TestStep27_The WIFI Security button display off status
	Given Machine support WIFISecurity
	Given Toolbar has been pin to Taskbar
	Given Turn on permission
	Given Launch Toolbar On NewOS
	When Turn on wifi security from toolbar
	When Turn off wifi security from toolbar
	Then The wifi security display off status

#@OSWifiToolbar
Scenario: VAN27994_TestStep28_The text display is wifi security off
	Given Machine support WIFISecurity
	Given Toolbar has been pin to Taskbar
	Given Turn on permission
	Given Launch Toolbar On NewOS
	When Turn on wifi security from toolbar
	When Turn off wifi security from toolbar
	Then Take screen shot TestStep28 in 27994 under HSScreenShotResult after 0 seconds

#@OSWifiToolbar
Scenario: VAN27994_TestStep29_The Wi-Fi Security button display off status
	Given Machine support WIFISecurity
	Given Toolbar has been pin to Taskbar
	Given Turn on permission
	Given Launch Toolbar On NewOS
	When Turn off wifi security from toolbar
	When Get wifi security status from toolbar
	Given Close Toolbar Background
	Given Go to Wifisecurity
	Then The Wi-fi security button displays same as with Vantage

#@OSWifiToolbar
Scenario: VAN27994_TestStep30_The wifi security button display off status
	Given Machine support WIFISecurity
	Given Toolbar has been pin to Taskbar
	Given Turn on permission
	Given Close Toolbar Background
	Given Go to Wifisecurity
	When Turn on wifi security from vantage
	Given Launch Toolbar On NewOS
	Then The wifi security display on status

#@OSWifiToolbar
Scenario: VAN27994_TestStep31_The wifi security button display on status
	Given Machine support WIFISecurity
	Given Toolbar has been pin to Taskbar
	Given Turn on permission
	Given Close Toolbar Background
	Given Go to Wifisecurity
	When Turn off wifi security from vantage
	Given Launch Toolbar On NewOS
	Then The wifi security display off status

#@OSWifiToolbar
Scenario: VAN27994_TestStep32_The wifi security button display off status
	Given Machine support WIFISecurity
	Given Toolbar has been pin to Taskbar
	Given Turn on permission
	Given Turn off permission
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	Then The wifi security display off status

#@OSWifiToolbar
Scenario: VAN27994_TestStep33_Turn off permission click wifi security jump to wifi security page
	Given Machine support WIFISecurity
	Given Toolbar has been pin to Taskbar
	Given Turn off permission
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	When Click wifi security from toolbar
	When Click close in the security pop-up box
	Given Close Toolbar Background
	Then Click wifi security jump to wifi security page

#@OSWifiToolbar
Scenario: VAN27994_TestStep34_The wifi security display on status
	Given Machine support WIFISecurity
	Given Toolbar has been pin to Taskbar
	Given Turn off permission
	Given Launch Toolbar On NewOS
	When Click wifi security from toolbar
	When wait 5 seconds
	When Click Agreee in the security pop-up box
	Given Turn on permission
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	Then The wifi security display on status

#@OSWifiToolbar
Scenario: VAN27994_TestStep35_Jump to the wifi security page
	Given Machine support WIFISecurity
	Given Toolbar has been pin to Taskbar
	Given Turn on permission
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	When Turn on wifi security from toolbar
	Given Turn off permission
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	When Click wifi security from toolbar
	When Click close in the security pop-up box
	Given Close Toolbar Background
	Then Click wifi security jump to wifi security page

#@OSWifiToolbar
Scenario: VAN27994_TestStep36_The wifi security display on status
	Given Machine support WIFISecurity
	Given Toolbar has been pin to Taskbar
	Given Turn on permission
	Given Launch Toolbar On NewOS
	When Turn on wifi security from toolbar
	Given Turn off permission
	Given Turn on permission
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	Then The wifi security display on status

#@OSWifiToolbar
Scenario: VAN27994_TestStep37_The wifi security display off status
	Given Machine support WIFISecurity
	Given Toolbar has been pin to Taskbar
	Given Turn off permission
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	When Click wifi security from toolbar
	When Click close in the security pop-up box
	Given Launch Toolbar On NewOS
	Then The wifi security display off status

@OSToolBar
Scenario: VAN27994_TestStep38_Check close toolbar by click x button
	When pin toolbar on Taskbar settings
	Given Launch Toolbar On NewOS 
	And Close toolbar
	Then toolbar close button should hide
	Given Toolbar has been pin to Taskbar

#@OSWifiToolbar
Scenario: VAN27994_TestStep39_The wifi security display on status
	Given Machine support WIFISecurity
	Given Toolbar has been pin to Taskbar
	Given Turn on permission
	Given Clean toast history
	Given Close Toolbar Background
	Given Go to Wifisecurity
	When Turn on wifi security from vantage
	When Turn off wifi security from vantage
	Then wait 5 seconds
	When Click the toast and turn on wifi security
	Given Launch Toolbar On NewOS
	Then The wifi security display on status
	Given Close Toolbar Background

#@OSWifiToolbar
Scenario: VAN27994_TestStep40_Jump to store page
	Given Machine support WIFISecurity
	Given Toolbar has been pin to Taskbar
	Given Uninstall the lenovo vatage
	Given Launch Toolbar On NewOS
	When Click wifi security from toolbar
	Then Take Screen Shot TestStep40_JumpToStorePage in 27994 under HSScreenShotResult
	Given Install Vantage

@OSMicrophoneToolbar
Scenario: VAN27994_TestStep41_The microphone button displays same as with Vantage
	Given Machine support microphone
	Given Toolbar has been pin to Taskbar
	Given Turn on microphone access
	Given Launch Toolbar On NewOS
	When Get microphone status from toolbar
	Given Close Toolbar Background
	Given go to Audio section
	When Jump to microphone
	Then The microphone button displays same as with Vantage

@OSMicrophoneToolbar
Scenario: VAN27994_TestStep42_The hover tips display is "Microphone"
	Given Machine support microphone
	Given Toolbar has been pin to Taskbar
	Given Turn on microphone access
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	When Turn on microphone from toolbar
	When Hover the mouse on the button microphone
	Then Take Screen Shot TestStep42_checktip_microphoneon in 27994 under HSScreenShotResult
	When Turn off microphone from toolbar
	When Hover the mouse on the button microphone
	Then Take Screen Shot TestStep42_checktip_microphoneoff in 27994 under HSScreenShotResult

@OSMicrophoneToolbar
Scenario:  VAN27994_TestStep43_The text display is "Microphone on",The text info is displayed in the middle
	Given Machine support microphone
	Given Toolbar has been pin to Taskbar
	Given Turn on microphone access
	Given Launch Toolbar On NewOS
	When Turn off microphone from toolbar
	When Turn on microphone from toolbar
	Then Take screen shot TestStep56_checktip_Microphineon in 27994 under HSScreenShotResult after 0 seconds

@OSMicrophoneToolbar
Scenario:  VAN27994_TestStep44_The microphone button displays same as with Vantage
	Given Machine support microphone
	Given Toolbar has been pin to Taskbar
	Given Turn on microphone access
	Given Launch Toolbar On NewOS
	When Turn on microphone from toolbar
	When Get microphone status from toolbar
	Given Close Toolbar Background
	Given go to Audio section
	Then The microphone button displays same as with Vantage

@OSMicrophoneToolbar
Scenario: VAN27994_TestStep45_The microphone button displays same as with vantage dashboard
	Given Machine support microphone
	Given Toolbar has been pin to Taskbar
	Given Turn on microphone access
	Given Launch Toolbar On NewOS
	When Turn on microphone from toolbar
	When Get microphone status from toolbar
	Given Go to dashboad page
	Then The microphone button displays same as with Vantage dashboard

@OSMicrophoneToolbar
Scenario: VAN27994_TestStep46_The microphone display off status
	Given Machine support microphone
	Given Toolbar has been pin to Taskbar
	Given Turn on microphone access
	Given Launch Toolbar On NewOS
	When Turn off microphone from toolbar
	Then The microhone display off status

@OSMicrophoneToolbar
Scenario: VAN27994_TestStep47_The text display is "Microphone off",The text info is displayed in the middle
	Given Machine support microphone
	Given Toolbar has been pin to Taskbar
	Given Turn on microphone access
	Given Launch Toolbar On NewOS
	When Turn on microphone from toolbar
	When Turn off microphone from toolbar
	Then Take screen shot TestStep47_checktip_Microphoneoff in 27994 under HSScreenShotResult after 0 seconds

@OSMicrophoneToolbar
Scenario: VAN27994_TestStep48_The microphone display off status
	Given Machine support microphone
	Given Toolbar has been pin to Taskbar
	Given Turn on microphone access
	Given Launch Toolbar On NewOS
	When Turn off microphone from toolbar
	When Get microphone status from toolbar
	Given Close Toolbar Background
	Given Go to audio section
	Then The microphone button displays same as with Vantage

@OSMicrophoneToolbar
Scenario: VAN27994_TestStep49_The microphone button displays same as with vantage dashboard
	Given Machine support microphone
	Given Toolbar has been pin to Taskbar
	Given Turn on microphone access
	Given Launch Toolbar On NewOS
	When Turn off microphone from toolbar
	When Get microphone status from toolbar
	Given Go to dashboad page
	Then The microphone button off displays same as with Vantage dashboard

@OSMicrophoneToolbar
Scenario: VAN27994_TestStep50_The microphone display on status
	Given Machine support microphone
	Given Toolbar has been pin to Taskbar
	Given Turn on microphone access
	Given Close Toolbar Background
	Given Go to dashboad page
	Given Turn on microphone from dashboad
	Given Launch Toolbar On NewOS
	Then The microhone display on status
