Feature: VAN27994_Part7_OSToolbarRegressionTest
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-27994
	Author： Haiye Li
	Conmments: TestStep300-350


Background:
	Given Turn on or off the narrator 'on'

@OSToolBar
Scenario: VAN27994_TestStep301_hover on the toolbar icon it will show Lenovo Vantage Toolbar
	Given Toolbar has been pin to Taskbar
	Then  Hover toolbar on NewOS
	When Take Screen Shot TestStep301TheTip_Should_Be_Lenovo_Vantage_Toolbar in 27994 under ToolbarScreenShotResult
	
@OSToolBar
Scenario: VAN27994_TestStep302_right click the toolbar icon It only show unpin from taskbar
	Given Toolbar has been pin to Taskbar
	When right click toolbar icon on NewOS
	Then It only show unpin from taskbar 
	When Take Screen Shot TestStep302RightClick_Toolbar_Icon_has_Only_One_option in 27994 under ToolbarScreenShotResult	

@OSToolBar
Scenario: VAN27994_TestStep303_Click unpin from taskbar Toolbar will unpin from taskbar
	Given Toolbar has been pin to Taskbar
	When Unpin Toolbar By Right_Click Toolbar Icon
	Then Toolbar will unpin from taskbar
	When Take Screen Shot TestStep303Toolbaricon_Should_Unpin in 27994 under ToolbarScreenShotResult	

@OSToolBarViewWarrantyPage
Scenario: VAN27994_TestStep304_Click View warranty options link will show the available warranty options page
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Launch Vantage from Toolbar Via 'View warranty option' Link
	Then wait 2 seconds
	Then It will show the available warranty options page

@OSToolBarViewWarrantyPage
Scenario: VAN27994_TestStep305_Click View warranty options link will show the available warranty options page
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Launch Vantage from Toolbar Via 'View warranty option' Link
	Then wait 2 seconds
	Then It will show the available warranty options page
	Given Close Toolbar Background
	When Take Screen Shot TestStep305_CheckWarrantyPageshow in 27994 under ToolbarScreenShotResult

@OSToolBar
Scenario: VAN27994_TestStep306_Click View warranty options link will show the available warranty options page
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Launch Vantage from Toolbar Via 'View warranty option' Link
	Then wait 2 seconds
	Then It will hide the available warranty options page
	Given Close Toolbar Background
	When Take Screen Shot TestStep306_CheckWarrantyOptionsPageInvalid in 27994 under ToolbarScreenShotResult

@OSToolBarMachineBoughtinChina
Scenario: VAN27994_TestStep307_Check machine that bought in china don't have view option
	Given MTM End With CD
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Then There is No 'View warranty option' Link
	When Take Screen Shot TestStep307_ViewWarrantyOptionslinkhide in 27994 under ToolbarScreenShotResult

@OSToolBarlowPower
Scenario: VAN27994_TestStep308_Battery Level Is Below 8% it shouldn't show the low power toast
	Given Toolbar has been pin to Taskbar
	Given Set ThinkPad Machine Battery Level Is Below 20% 
	When Take Screen Shot TestStep308Toolbaricon_Show_LowPower20% in 27994 under ToolbarScreenShotResult
	Then wait 30 seconds
	When Take Screen Shot TestStep308Toolbaricon_Show_LowPower20%_wait30s in 27994 under ToolbarScreenShotResult
	Given Set ThinkPad Machine Battery Level Is Below 19% 
	When Take Screen Shot TestStep308Toolbaricon_Show_LowPower19% in 27994 under ToolbarScreenShotResult
	Then wait 30 seconds
	When Take Screen Shot TestStep308Toolbaricon_Show_LowPower19%_wait30s in 27994 under ToolbarScreenShotResult
	Given Set ThinkPad Machine Battery Level Is Below 18% 
	When Take Screen Shot TestStep308Toolbaricon_Show_LowPower18% in 27994 under ToolbarScreenShotResult
	Then wait 30 seconds
	When Take Screen Shot TestStep308Toolbaricon_Show_LowPower18%_wait30s in 27994 under ToolbarScreenShotResult
	Given Set ThinkPad Machine Battery Level Is Below 10% 
	When Take Screen Shot TestStep308Toolbaricon_Show_LowPower10% in 27994 under ToolbarScreenShotResult
	Then wait 30 seconds
	When Take Screen Shot TestStep308Toolbaricon_Show_LowPower10%_wait30s in 27994 under ToolbarScreenShotResult
	Given Set ThinkPad Machine Battery Level Is Below 9% 
	When Take Screen Shot TestStep308Toolbaricon_Show_LowPower9% in 27994 under ToolbarScreenShotResult
	Then wait 30 seconds
	When Take Screen Shot TestStep308Toolbaricon_Show_LowPower9%_wait30s in 27994 under ToolbarScreenShotResult

@OSToolBar
Scenario: VAN27994_TestStep309_Unselect the Lenovo Vantage toolbar checkbox Toolbar will unpin from taskbar
	Given Nerver pin toolbar to taskbar
	Given Install the Lenovo Vantage
	Given unselect the Enable the Lenovo Vantage toolbar checkbox
	Then wait 300 seconds
	Then Toolbar will unpin from taskbar
	When Take Screen Shot TestStep309Toolbaricon_Unpin in 27994 under ToolbarScreenShotResult
	Then wait 30 seconds
	When Take Screen Shot TestStep309Toolbaricon_Unpin_Wait30s in 27994 under ToolbarScreenShotResult

@OSToolBar
Scenario: VAN27994_TestStep310
	Given Delect the HeartBeat Regedit Value
	Given delete eventlog
	When Wait 5 minutes
	Given Toolbar has "no sent" the HeartBeat data

@OSToolBarOnly
Scenario: VAN27994_TestStep312
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given delete eventlog
	Given Click the "microphone" button on toolbar and save states
	Then HeartBeat Has Send "microphone" value
	Given delete eventlog
	Given Click the "microphone" button on toolbar and save states
	Then HeartBeat Has Send "microphone" value
	Given delete eventlog
	Given Click the "camera" button on toolbar and save states
	Then HeartBeat Has Send "camera" value
	Given delete eventlog
	Given Click the "camera" button on toolbar and save states
	Then HeartBeat Has Send "camera" value
	Given delete eventlog
	Given Click the "airplane" button on toolbar and save states
	Then HeartBeat Has Send "airplane" value
	Given delete eventlog
	Given Click the "airplane" button on toolbar and save states
	Then HeartBeat Has Send "airplane" value
	Given delete eventlog
	Given Click the "wifi" button on toolbar and save states
	Then HeartBeat Has Send "wifi" value
	Given delete eventlog
	Given Click the "wifi" button on toolbar and save states
	Then HeartBeat Has Send "wifi" value
	Given delete eventlog
	Given Click the "batterychargethreshold" button on toolbar and save states
	Then HeartBeat Has Send "batterychargethreshold" value
	Given delete eventlog
	Given Click the "batterychargethreshold" button on toolbar and save states
	Then HeartBeat Has Send "batterychargethreshold" value
	Given delete eventlog
	Given Click the "backlight" button on toolbar and save states
	Then HeartBeat Has Send "backlight" value
	Given delete eventlog
	Given Click the "backlight" button on toolbar and save states
	Then HeartBeat Has Send "backlight" value
	Given delete eventlog
	Given Click the "backlight" button on toolbar and save states
	Then HeartBeat Has Send "backlight" value

@OSToolBar
Scenario: VAN27994_TestStep313_Right click taskbar Click toolbars It shouldn't show 'Lenovo Vantage Toolbar'
	Given Toolbar has been pin to Taskbar
	Given Right click taskbar
	When  Click Toolbars
	When Take Screen Shot TestStep313_RightClickTaskbar_ClickToolbars_shouldn'tshowLenovoVantageToolbar in 27994 under ToolbarScreenShotResult
	
@OSIdeaToolbarRapidChargeAC
Scenario: VAN27994_TestStep314_Check AC Turn on Rapid charge It shouldn't show adapter icon
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Then wait 2 seconds
	When Turn on the Rapid charge
	Given AC Condition(Connect the Adapter)
	When Take Screen Shot TestStep314AC_TurnOn_RapidCharge_AdapterIcon_hide in 27994 under ToolbarScreenShotResult
	
@OSIdeaToolbarConservationModeAC
Scenario: VAN27994_TestStep315_Check AC Turn on Conservation mode It shouldn't show adapter icon
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Then wait 2 seconds
	When Turn on the Conservation mode
	Given AC Condition(Connect the Adapter)
	When Take Screen Shot TestStep315AC_TurnOn_Conservation_AdapterIcon_hide in 27994 under ToolbarScreenShotResult

@OSToolbarAirplaneModeACDC
Scenario: VAN27994_TestStep316_Check DC Turn on airplane power mode It shouldn't show adapter icon
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Turn on airplane power mode from toolbar 
	Given AC Condition(Connect the Adapter)
	When Take Screen Shot TestStep316AC_TurnOn_AirplanePower_AdapterIcon_hide in 27994 under ToolbarScreenShotResult

@OSToolbarAirplaneModeACDC
Scenario: VAN27994_TestStep317_Check DC Turn on airplane power mode It shouldn't show adapter icon
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Turn on airplane power mode from toolbar
	When User make the machine from AC to DC
	When Take Screen Shot TestStep317DC_TurnOn_AirplanePower_AdapterIcon_hide in 27994 under ToolbarScreenShotResult
	Given AC Condition(Connect the Adapter)

@OSToolbarAirplaneModeACDC
Scenario: VAN27994_TestStep318_Check AC It shouldn't show adapter icon
	Given Toolbar has been pin to Taskbar
	Given AC Condition(Connect the Adapter)
	When Take Screen Shot TestStep318AdapterIcon_hide in 27994 under ToolbarScreenShotResult
	Given Close Toolbar Background

@OSToolBar
Scenario: VAN27994_TestStep319_Change the DPI & Resolution Check the toolbar icon
	Given Toolbar has been pin to Taskbar
	Given Change DPI to 100
	When Take Screen Shot TestStep319ChangeDPI100_Toolbaricon in 27994 under ToolbarScreenShotResult
	Given Change DPI to 150
	When Take Screen Shot TestStep319ChangeDPI150_Toolbaricon in 27994 under ToolbarScreenShotResult
	Given Change DPI to 175
	When Take Screen Shot TestStep319ChangeDPI175_Toolbaricon in 27994 under ToolbarScreenShotResult
	Given Change DPI to 125
	Given change resolution 1680 to 1050
	When Take Screen Shot TestStep319ChangeResolution1680-1050_Toolbaricon in 27994 under ToolbarScreenShotResult
	Given change resolution 1280 to 1024
	When Take Screen Shot TestStep319ChangeResolution1280-1024_Toolbaricon in 27994 under ToolbarScreenShotResult
	Given change resolution 800 to 600
	When Take Screen Shot TestStep319ChangeResolution800-600_Toolbaricon in 27994 under ToolbarScreenShotResult
	Given change resolution 1920 to 1080