Feature: VAN10210_Part10_ToolbarRegressionTest
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-10210
	Author： Haiye Li
	Conmments: TestStep310-350

Background:
	Given Turn on or off the narrator 'on'

@ToolbarECM
Scenario: VAN10210_TestStep311_There should be a ECM toggle in Toolbar within 3s first launch / 2s other launch
	Given Pin toolbar to taskbar
	Then Launch toolbar do not wait
	Then There should be a ECM toggle in Toolbar within 2s other launch

@ToolbarECM
Scenario: VAN10210_TestStep312_The default value of the toggle in Toolbar is off
	Given Launch toolbar
	Given Turn Off the ECM icon
	Given Turn On the ECM icon
	Given Uninstall the lenovo vatage
	Given Install Vantage
	Then  Launch toolbar
	Then  The ECM icon's value is Off

@ToolbarECM
Scenario: VAN10210_TestStep313_There will be a "Eye care mode off" tip in Toolbar at the bottom of the icon
	Given Launch toolbar
	Given Turn On the ECM icon
	Given Turn Off the ECM icon
	Then  Take screen shot VAN10210_TestStep313_CheckEyeCareModeIcon in 10210 under ToolbarScreenShotResult after 0 seconds

@ToolbarECM
Scenario: VAN10210_TestStep314_There will be a tip "Eye care mode: Off" at the top of the Icon
	Given Launch toolbar
	Given Turn Off the ECM icon
	When  hover on the ECM icon
	Then  Take Screen Shot VAN10210_TestStep313_HoverEyeCareModeIcon in 10210 under ToolbarScreenShotResult

@ToolbarECM
Scenario: VAN10210_TestStep315_The toggle of Color temperature Eye care mode is off and The slider of Daytime color temperature is 6500K
	Given Go to DisplayCamera page
	Given Click DisplayLink
	Given Drug the "Temp_Display" slider bar 100 
	Given Turn "on" Color temperature
	When close lenovo vantage
	Given Launch toolbar
	Given Turn Off the ECM icon
	Given Launch Vantage
	Given Go to DisplayCamera page
	Given Click DisplayLink
	Then The ECM feature toggle button default value should be off
	Then The "DayTimeFeature" slider default "Temp_Display" Regedit "6500" Ui "6500K"

@ToolbarECM
Scenario: VAN10210_TestStep316_The computer's temperature should be 6500K
	Given Go to DisplayCamera page
	Given Click DisplayLink
	Given Drug the "Temp_Display" slider bar 100
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	When close lenovo vantage
	Given Launch toolbar
	Given Turn Off the ECM icon
	Given Launch Vantage
	Given Go to DisplayCamera page
	Given Click DisplayLink
	Then The "DayTimeFeature" slider default "Temp_Display" Regedit "6500" Ui "6500K"

@ToolbarECM
Scenario: VAN10210_TestStep317_The ECM toggle should be on within 2s
	Given Launch toolbar
	Given Turn Off the ECM icon
	Given Turn On the ECM icon
	Then The ECM toggle should be on within 2s

@ToolbarECM
Scenario: VAN10210_TestStep318_The ECM toggle's state should be on within 2s
	Given Launch toolbar
	Given Turn Off the ECM icon
	Given Turn On the ECM icon
	Then  Close toolbar
	Given Launch toolbar
	Then The ECM toggle should be on within 2s

@ToolbarECM
Scenario: VAN10210_TestStep320_There will be a "Eye care mode on" tip in Toolbar at the bottom of the icon
	Given Launch toolbar do not wait
	Given Turn Off the ECM icon
	Given Turn On the ECM icon
	Then  Take screen shot VAN10210_TestStep320_CheckEyeCareModeIcon in 10210 under ToolbarScreenShotResult after 0 seconds

@ToolbarECM
Scenario: VAN10210_TestStep321_There will be a tip "Eye care mode: On at the top of the Icon"
	Given Launch toolbar
	Given Turn On the ECM icon
	When  hover on the ECM icon
	Then  Take Screen Shot VAN10210_TestStep321_HoverEyeCareModeIcon in 10210 under ToolbarScreenShotResult

@ToolbarECM
Scenario: VAN10210_TestStep322_There will be a tip "Eye care mode: On at the top of the Icon"
	Given Launch toolbar
	Given Turn Off the ECM icon
	Given Turn On the ECM icon
	Given Go to DisplayCamera page
	Given Click DisplayLink
	Then The "ECMFeature" slider default "Temp_UserSet" Regedit "4500" Ui "4500K"

@ToolbarECM
Scenario: VAN10210_TestStep323_The toggle of Color temperature Eye care mode is on
	Given Launch toolbar
	Given Turn Off the ECM icon
	Given Turn On the ECM icon
	Given Go to DisplayCamera page
	Given Click DisplayLink
	Given "checked" the Eye care Mode checkbox

@ToolbarECM
Scenario: VAN10210_TestStep324_The ECM icon's value is off
	Given Go to DisplayCamera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given Launch toolbar
	Then The ECM icon's value is Off

@ToolbarECM
Scenario: VAN10210_TestStep325_The ECM icon's value is on
	Given Go to DisplayCamera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Launch toolbar
	Then The ECM icon's value is On

@ToolbarECM
Scenario: VAN10210_TestStep326_The ECM icon is disabled, can not be clicked
	Given Set 'Intel(R) HD Graphics 620' drive state to enable or disable 'disable' via HardwareId 'default'
	Given Launch toolbar
	Then The ECM icon is disabled and can not be clicked
	Given Set 'Intel(R) HD Graphics 620' drive state to enable or disable 'enable' via HardwareId 'default'

@ToolbarECM
Scenario: VAN10210_TestStep327_ It shows: Eye care mode: Intel graphics driver disabled
	Given Set 'Intel(R) HD Graphics 620' drive state to enable or disable 'disable' via HardwareId 'default'
	Given Launch toolbar
	When  hover on the ECM icon
	Then  Take Screen Shot VAN10210_TestStep327_HoverEyeCareModeIcon in 10210 under ToolbarScreenShotResult
	Given Set 'Intel(R) HD Graphics 620' drive state to enable or disable 'enable' via HardwareId 'default'

@NormalOSHeartBeatSupportRegion
Scenario: VAN10210_TestStep334_Check the Heartbeat metrics data 
	When pin toolbar on Taskbar settings
	Given Delect the HeartBeat Regedit Value
	Given delete eventlog
	Given Set Time to "nearnextday"
	When Enter hibernate
	When Wait 2 minutes
	Given Toolbar has "sent" the HeartBeat data
	Then HeartBeat data shouldn't show TrackPointSettings TouchpadSettings And AdvancedPointingSettings Mode

@ToolbarECM
Scenario: VAN10210_Z_Sandbox
	Given turn off narrator
	Given Turn on or off the narrator 'off'
