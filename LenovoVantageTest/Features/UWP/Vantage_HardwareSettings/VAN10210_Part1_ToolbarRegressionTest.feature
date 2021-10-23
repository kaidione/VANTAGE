Feature: VAN10210_Part1_ToolbarRegressionTest
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-10210
	Author： Jinglong Zhao
	Update： Pengjie Chen
	Conmments: TestStep01-40  / HaiYe Li (TestStep39)

Background:
	Given Turn on or off the narrator 'on'

@CameraToolbar @MicrophoneToolbar
Scenario: VAN10210_TestStep000_Init CameraMicroPhone Environment
	Given enable camera driver
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Go to My Device Settings page
	When turn off Camera Privacy from Display and Camera page
	When enable the Microphone driver
	Given Turn on microphone access

@Toolbar
Scenario: VAN10210_TestStep001_Check the toolbar pin to taskbar
	Given Install the Lenovo Vantage
	When select the Enable the Lenovo Vantage toolbar checkbox
	Then the toolbar pin to taskbar

@Toolbar
Scenario: VAN10210_TestStep002_Check the taskbar doesn‘t display the toolbar
	Given Install the Lenovo Vantage
	Given Unselect the Enable the lenovo vantage toolbar on oobe
	Then the taskbar doesn't display the toolbar

@Toolbar
Scenario: VAN10210_TestStep003_Check the toolbar pin to taskbar
	Given Install the Lenovo Vantage
	Given unselect the Enable the Lenovo Vantage toolbar checkbox
	Given Open the My Device Settings and into Power page
	Given Jump to Other settings
	When Launch the Lenovo Vantage Toolbar
	Then the toolbar pin to taskbar

@Toolbar
Scenario: VAN10210_TestStep004_Check the taskbar doesn‘t display the toolbar
	Given Install the Lenovo Vantage
	Given unselect the Enable the Lenovo Vantage toolbar checkbox
	Given Open the My Device Settings and into Power page
	Given Jump to Other settings
	When Close the Lenovo Vantage Toolbar
	Then the taskbar doesn't display the toolbar

@Toolbar
Scenario: VAN10210_TestStep005_Check the toolbar pin to taskbar
	Given Install the Lenovo Vantage
	Given unselect the Enable the Lenovo Vantage toolbar checkbox
	Then the taskbar doesn't display the toolbar
	When pin toolbar on Taskbar settings
	Then the toolbar pin to taskbar

@Toolbar
Scenario: VAN10210_TestStep006_Check the toolbar unpin to taskbar
	Given Install the Lenovo Vantage
	Given unselect the Enable the Lenovo Vantage toolbar checkbox
	When unpin toolbar on Taskbar settings
	Then the taskbar doesn't display the toolbar

@Toolbar
Scenario: VAN10210_TestStep007_Check close toolbar by twice click
	When pin toolbar on Taskbar settings
	When Launch toolbar
	Then toolbar close button should show
	When Close toolbar
	Then toolbar close button should hide
	And the toolbar pin to taskbar

@Toolbar
Scenario: VAN10210_TestStep008_Check close toolbar by click another area
	When pin toolbar on Taskbar settings
	When Launch toolbar 
	Then toolbar close button should show
	When Click on the top left of vantage
	Then toolbar close button should hide
	And the toolbar pin to taskbar

@Toolbar
Scenario: VAN10210_TestStep016_CheckTheToolbarTitle display
	When pin toolbar on Taskbar settings
	When Launch toolbar
	#Then The title name according to the machine and vantage display 
	Then Take Screen Shot TestStep016 in 10210 under ToolbarScreenShotResult

@ToolbarNoBattery
Scenario: VAN10210_TestStep017_Check the machine no battery Toolbar display
	Given Pin toolbar to taskbar
	When Launch toolbar
	Then Take Screen Shot TestStep017 in 10210 under ToolbarScreenShotResult
	
@ToolbarThinkACDC
Scenario: VAN10210_TestStep018_01
	Given Click Device settings,enter Power page
	When Go to Battery Charge threshold section
	When Turn off Battery Charge threshold
	Given DC Condition(Connect the Adapter)
	Given Use "10.119.22.22" and Button "1001" make BatteryLevel "less" than "90"
	Given AC Condition(Connect the Adapter)
	When wait 90 seconds
	Given Pin toolbar to taskbar
	When Launch toolbar
	Then display the battery detail on the thinkpad ,the Ideapad doesn't display

@ToolbarIdeaACDC
Scenario: VAN10210_TestStep018_02
	Given Pin toolbar to taskbar
	When Launch toolbar
	When the Machine access adapter
	Then display the battery detail on the thinkpad ,the Ideapad doesn't display

@ToolbarACDC
Scenario: VAN10210_TestStep019
	Given Pin toolbar to taskbar
	Given DC Condition(Connect the Adapter)
	When wait 90 seconds
	When Launch toolbar
	When the Machine unconnected adapter
	Then display the Remaining Time on the Ideapad and Thinkpad
	When Take Screen Shot AC19Toolbar in 10210 under ToolbarScreenShotResult
	When Launch Vantage
	Given Go to Power Page
	When Take Screen Shot AC19PowerPage in 10210 under ToolbarScreenShotResult
	Given AC Condition(Connect the Adapter)

@TestDTToolbar
Scenario: VAN10210_TestStep020_Check the machine is DT Toolbar display
	Given Machine is DT
	Given Pin DT toolbar to taskbar
	When Launch DT toolbar
	Then Take Screen Shot TestStep021 in 10210 under ToolbarScreenShotResult
	When Close toolbar

@Toolbar
Scenario: VAN10210_TestStep027_Check the battery gauge display Airplane power mode icon
	Given plug in charging adapter
	Given Pin toolbar to taskbar
	When Launch toolbar
	Given Turn on airplane power mode from toolbar
	Then the battery gauge display Airplane power mode icon
	Given Waiting 5 seconds
	When Take Screen Shot AC27_displayAirplanePowerModeIcon in 10210 under ToolbarScreenShotResult

@TestToolbarAirplanePowerModeIcon
Scenario: VAN10210_TestStep028_The battery gauge display the Airplane Power Mode icon
	Given plug in charging adapter
	Given Pin toolbar to taskbar
	When Launch toolbar
	Given Turn on airplane power mode from toolbar
	When Close toolbar
	When User make the machine from AC to DC
	Then the battery gauge display Airplane power mode icon
	Then Take Screen Shot TestStep028 in 10210 under ToolbarScreenShotResult
	Given AC Condition(Connect the Adapter)
	When Launch toolbar
	Given Turn off airplane power mode from toolbar
	When Close toolbar

@Toolbar
Scenario: VAN10210_TestStep029_Check the battery gauge doesn't display Airplane power mode icon
	Given plug in charging adapter
	Given Pin toolbar to taskbar
	When Launch toolbar
	Given Turn off airplane power mode from toolbar
	Then the battery gauge display charge but not Airplane power mode icon
	Given Waiting 5 seconds
	When Take Screen Shot AC29_doesnotDisplayAirplanePowerModeIcon in 10210 under ToolbarScreenShotResult

@TestDTToolbar
Scenario: VAN10210_TestStep030_Check this machine is DT the icon display is "L" icon
	Given Machine is DT
	Given Pin DT toolbar to taskbar
	When Launch DT toolbar
	Then Take Screen Shot TestStep030 in 10210 under ToolbarScreenShotResult
	When Close toolbar

@Toolbar
Scenario: VAN10210_TestStep031_Check the battery gauge display
	Given Machine is IdeaPad or ThinkPad
	Given Pin toolbar to taskbar
	Then the toolbar pin to taskbar
	When Take Screen Shot AC31_NBBatteryGaugeDisplay in 10210 under ToolbarScreenShotResult

#@WifiToolbar
Scenario: VAN10210_TestStep035_The Wi-fi security button displays same as with Vantage
	Given Machine support WIFISecurity
	Given Turn on permission
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Get wifi secirity status from toolbar
	When Close toolbar
	Given Go to Wifisecurity
	Then The Wi-fi security button displays same as with Vantage

#@WifiToolbar
Scenario: VAN10210_TestStep036_The hover tips display is "WiFi security"
	Given Machine support WIFISecurity
	Given Pin toolbar to taskbar
	Given Turn on permission
	When Launch toolbar
	When Turn on wifi security from toolbar
	When Turn off wifi security from toolbar
	When Close toolbar
	When Launch toolbar
	When Hover the mouse on the button wifisecurity
	Then Take Screen Shot TestStep36off in 10210 under HSScreenShotResult
	When Launch toolbar
	When Turn on wifi security from toolbar
	When Close toolbar
	When Launch toolbar
	When Hover the mouse on the button wifisecurity
	Then Take Screen Shot TestStep36on in 10210 under HSScreenShotResult
	When Close toolbar

#@WifiToolbar
Scenario: VAN10210_TestStep037_The Wi-Fi security display on status
	Given Machine support WIFISecurity
	Given Pin toolbar to taskbar
	Given Turn on permission
	When Launch toolbar
	When Turn on wifi security from toolbar
	Then The wifi security display on status
	When Close toolbar

#@WifiToolbar
Scenario: VAN10210_TestStep038_The text display is "WiFi security on",The text info is displayed in the middle
	Given Machine support WIFISecurity
	Given Pin toolbar to taskbar
	Given Turn on permission
	When Launch toolbar
	When Turn off wifi security from toolbar
	When Turn on wifi security from toolbar
	Then Take screen shot TestStep38 in 10210 under HSScreenShotResult after 0 seconds 
	When Close toolbar

#@WifiToolbar
Scenario: VAN10210_TestStep039_The Wi-fi security button displays same as with toolbar
	Given Machine support WIFISecurity
	Given Pin toolbar to taskbar
	Given Turn on permission
	Then Click Toolbar
	When wait 10 seconds
	When Turn off wifi security from toolbar
	When Turn on wifi security from toolbar
	When Close toolbar
	Given Go to Wifisecurity
	Then The Wi-fi security button displays on with Vantage

#@WifiToolbar
Scenario: VAN10210_TestStep040_The WIFI Security button display off status
	Given Machine support WIFISecurity
	Given Pin toolbar to taskbar
	Given Turn on permission
	When Launch toolbar
	When Turn on wifi security from toolbar
	When Turn off wifi security from toolbar
	Then The wifi security display off status