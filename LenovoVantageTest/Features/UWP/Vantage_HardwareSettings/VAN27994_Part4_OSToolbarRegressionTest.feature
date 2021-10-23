Feature: VAN27994_Part4_OSToolbarRegressionTest
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-27994
	Author： Yangyu
	Conmments: TestStep150-200

Background:
	Given Turn on or off the narrator 'on'
	Given Toolbar has been pin to Taskbar  

@NOSKeyboardBacklightToolbarThinkpad
Scenario: VAN27994_TestStep155_The keyboard backlight button display Low status	
	Given Launch Toolbar On NewOS
	When Select low of keyboard backlight on toolbar
	Then The Keyboard backlight button display low status from toolbar

@NOSKeyboardBacklightToolbarThinkpad
Scenario: VAN27994_TestStep156_The text display is Keyboard backlight low
	Given Launch Toolbar On NewOS
	When Select off of keyboard backlight on toolbar
	When Select low of keyboard backlight on toolbar
	Given Take Screen Shot 156_textDisplayKeyboardBacklightLow in 27994 under ToolbarScreenShotResult

@NOSKeyboardBacklightToolbarThinkpad
Scenario: VAN27994_TestStep157_The keyboard backlight button display Low status on vantage
	Given Launch Toolbar On NewOS
	When Select low of keyboard backlight on toolbar
	Given Close toolbar
	Given Go to input page
	Then The Keyboard backlight button display low status on vantage input page

@NOSKeyboardBacklightToolbarThinkpad
Scenario: VAN27994_TestStep158_The keyboard backlight button display High status on toolbar after select status on vantage
	Given Launch Toolbar On NewOS
	When Select low of keyboard backlight on toolbar
	Given Close toolbar
	Given Go to input page
	When Select high of keyboard backlight on vantage input page	
	Given Launch Toolbar On NewOS
	Then The Keyboard backlight button display high status from toolbar

@NOSKeyboardBacklightToolbarThinkpad
Scenario: VAN27994_TestStep159_The keyboard backlight button display High status on toolbar
	Given Launch Toolbar On NewOS
	When Select high of keyboard backlight on toolbar
	Then The Keyboard backlight button display high status from toolbar

@NOSKeyboardBacklightToolbarThinkpad
Scenario: VAN27994_TestStep160_The text display is Keyboard backlight high on toolbar
	Given Launch Toolbar On NewOS
	When Select off of keyboard backlight on toolbar
	When Select high of keyboard backlight on toolbar
	Given Take screen shot 160_textDisplayKeyboardBacklightHigh in 27994 under ToolbarScreenShotResult after 0 seconds

@NOSKeyboardBacklightToolbarThinkpad
Scenario: VAN27994_TestStep161_The keyboard backlight button display High status on toolbar
	Given Launch Toolbar On NewOS
	When Select high of keyboard backlight on toolbar
	Given Close toolbar
	Given Launch Toolbar On NewOS
	Then The Keyboard backlight button display high status from toolbar

@NOSKeyboardBacklightToolbarThinkpad
Scenario: VAN27994_TestStep162_The keyboard backlight button display High status on vantage
	Given Launch Toolbar On NewOS
	When Select high of keyboard backlight on toolbar
	Given Close toolbar
	Given Go to input page
	Then The Keyboard backlight button display high status on vantage input page

@NOSKeyboardBacklightToolbarThinkpad
Scenario: VAN27994_TestStep163_The keyboard backlight button display Off status on toolbar
	Given Launch Toolbar On NewOS
	When Select high of keyboard backlight on toolbar
	Given Close toolbar
	Given Go to input page
	When Select off of keyboard backlight on vantage input page	
	Given Launch Toolbar On NewOS
	Then The Keyboard backlight button display off status from toolbar

@NOSKeyboardBacklightToolbarThinkpad
Scenario: VAN27994_TestStep164_The keyboard backlight button display off status on toolbar
	Given Launch Toolbar On NewOS
	When Select off of keyboard backlight on toolbar
	Then The Keyboard backlight button display off status from toolbar

@NOSKeyboardBacklightToolbarThinkpad
Scenario: VAN27994_TestStep165_The text display is Keyboard backlight off on toolbar
	Given Launch Toolbar On NewOS
	When Select high of keyboard backlight on toolbar
	When Select off of keyboard backlight on toolbar
	Given Take screen shot 165_tipDisplayKeyboardBacklightOff in 27994 under ToolbarScreenShotResult after 0 seconds

@NOSKeyboardBacklightToolbarThinkpad
Scenario: VAN27994_TestStep166_The keyboard backlight button display off status on toolbar
	Given Launch Toolbar On NewOS
	When Select off of keyboard backlight on toolbar
	Given Close toolbar
	Given Launch Toolbar On NewOS
	Then The Keyboard backlight button display off status from toolbar

@NOSKeyboardBacklightToolbarThinkpad
Scenario: VAN27994_TestStep167_The keyboard backlight button display off status on vantage input page
	Given Launch Toolbar On NewOS
	When Select off of keyboard backlight on toolbar
	Given Close toolbar
	Given Go to input page
	Then The Keyboard backlight button display off status on vantage input page

@NOSKeyboardBacklightToolbarThinkpad
Scenario: VAN27994_TestStep168_The keyboard backlight button display low status on toolbar after select low status on vantage
	Given Launch Toolbar On NewOS
	When Select off of keyboard backlight on toolbar
	Given Close toolbar
	Given Go to input page
	When Select low of keyboard backlight on vantage input page
	Given Launch Toolbar On NewOS
	Then The Keyboard backlight button display low status from toolbar

@NOSToolbarPrivacyGuard
Scenario: VAN27994_TestStep169_The Privacy guard button displays same as with Vantage
	Given Launch Toolbar On NewOS
	Then The Privacy guard button displays same as with Vantage

@NOSToolbarPrivacyGuard
Scenario: VAN27994_TestStep170_The hover tips display is Privacy guard
	Given Launch Toolbar On NewOS
	Given Turn off privacy guard from toolbar
	Given Click batterydetails button on toolbar
	When Hover the mouse on the button Privacy guard
	Then Take Screen Shot 170_01textDisplayPrivacyGuard_Off in 27994 under ToolbarScreenShotResult
	Given Turn on privacy guard from toolbar
	Given Click batterydetails button on toolbar
	When Hover the mouse on the button Privacy guard
	Then Take Screen Shot 170_02textDisplayPrivacyGuard_On in 27994 under ToolbarScreenShotResult
	
@NOSToolbarPrivacyGuard
Scenario: VAN27994_TestStep171_The Privacy guard button displays on status from toolbar
	Given Launch Toolbar On NewOS
	Given Turn on privacy guard from toolbar
	Then The Privacy guard button displays on status from toolbar

@NOSToolbarPrivacyGuard
Scenario: VAN27994_TestStep172_Check Privacy guard UI and tips
	Given Launch Toolbar On NewOS
	Given Turn off privacy guard from toolbar
	Given Turn on privacy guard from toolbar
	Then The Privacy guard button displays on status from toolbar
	Then Take screen shot 172_textDisplayPrivacyGuardOn in 27994 under HSScreenShotResult after 0 seconds

@NOSToolbarPrivacyGuard
Scenario: VAN27994_TestStep173_Check Privacy guard toggle is off
	Given Launch Toolbar On NewOS
	Given Turn off privacy guard from toolbar
	Then The Privacy guard button displays off status from toolbar

@NOSToolbarPrivacyGuard
Scenario: VAN27994_TestStep174_Check Privacy guard UI and tips
	Given Launch Toolbar On NewOS
	Given Turn on privacy guard from toolbar
	Given Turn off privacy guard from toolbar
	Then The Privacy guard button displays off status from toolbar
	Then Take screen shot 174_textDisplayPrivacyGuardOff in 27994 under HSScreenShotResult after 0 seconds

@NOSToolbarPrivacyGuard
Scenario: VAN27994_TestStep175_Check Privacy guard status on
	Given Launch Toolbar On NewOS
	Given Turn on privacy guard from toolbar
	Then The Privacy guard button displays on status from toolbar
	Given Close Toolbar Background
	When Go to display page
	Given Click DisplayLink
	Then Check Privacy Guard toggle is 'on'

@NOSToolbarPrivacyGuard
Scenario: VAN27994_TestStep176_Check Privacy guard status off
	Given Launch Toolbar On NewOS
	Given Turn off privacy guard from toolbar
	Then The Privacy guard button displays off status from toolbar
	Given Close Toolbar Background
	When Go to display page
	Given Click DisplayLink
	Then Check Privacy Guard toggle is 'off'

@NOSToolbarPrivacyGuard
Scenario: VAN27994_TestStep177_Check Privacy guard status on
	Given Close Toolbar Background
	When Go to display page
	Given Click DisplayLink
	Then Turn on Privacy Guard
	Then Check Privacy Guard toggle is 'on'
	Given Launch Toolbar On NewOS
	Then The Privacy guard button displays on status from toolbar

@NOSToolbarPrivacyGuard
Scenario: VAN27994_TestStep178_Check Privacy guard status off
	Given Close Toolbar Background
	When Go to display page
	Given Click DisplayLink
	Then Turn off Privacy Guard
	Then Check Privacy Guard toggle is 'off'
	Given Launch Toolbar On NewOS
	Then The Privacy guard button displays off status from toolbar

@NOSBatteryChargeToolbarThinkpad
Scenario: VAN27994_TestStep179_Check the Battery charge threshold button displays same as with Vantage
	Given Launch Toolbar On NewOS
	When check the Battery charge threshold display
	Given Close Toolbar Background
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Then The Battery charge threshold button displays same as with Vantage

@NOSBatteryChargeToolbarThinkpad
Scenario: VAN27994_TestStep180_Check The hover tips display is "Battery charge threshold"
	Given Launch Toolbar On NewOS
	When Turn on the Battery charge threshold
	When Turn off the Battery charge threshold
	Given Click batterydetails button on toolbar
	When Hover the mouse on the Battery charge threshold button
	Then Take Screen Shot 180checktipBatterychargethresholdOFF in 27994 under ToolbarScreenShotResult
	Given Launch Toolbar On NewOS
	When Turn on the Battery charge threshold
	Given Click batterydetails button on toolbar
	When Hover the mouse on the Battery charge threshold button
	Then Take Screen Shot 180checktipBatterychargethresholdOn in 27994 under ToolbarScreenShotResult

@NOSBatteryChargeToolbarThinkpad
Scenario: VAN27994_TestStep181_Check the Battery charge threshold button display on statue from toolbar
	Given Launch Toolbar On NewOS
	When Turn on the Battery charge threshold
	Then The Battery charge threshold button display on statue

@NOSBatteryChargeToolbarThinkpad
Scenario: VAN27994_TestStep182_Check The text display is "Battery charge threshold"
	Given Launch Toolbar On NewOS
	When Turn on the Battery charge threshold
	Then Take screen shot 182checktipBatterychargethresholdOn in 27994 under ToolbarScreenShotResult after 0 seconds

@NOSBatteryChargeToolbarThinkpad
Scenario: VAN27994_TestStep183_Check the Battery charge threshold toggle display on statue from vantage
	Given Launch Toolbar On NewOS
	When Turn on the Battery charge threshold
	When check the Battery charge threshold display
	Given Close Toolbar Background
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Then The Battery charge threshold button displays same as with Vantage

@NOSBatteryChargeToolbarThinkpad
Scenario: VAN27994_TestStep184_Check the Battery charge threshold button display on status from toolbar
	Given Close Toolbar Background
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	When turn on Battery charge threshold from power page on Lenovo Vantage
	Given Launch Toolbar On NewOS
	Then The Battery charge threshold button display on statue

@NOSBatteryChargeToolbarThinkpad
Scenario: VAN27994_TestStep187_Check the Battery charge threshold button display off statue from toolbar
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn off the Battery charge threshold
	Then The Battery charge threshold button display off statue

@NOSBatteryChargeToolbarThinkpad
Scenario: VAN27994_TestStep188_Check The text display is Battery charge threshold off
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Battery charge threshold
	When Turn off the Battery charge threshold
	Then Take screen shot 188checktipBatterychargethresholdoff in 27994 under ToolbarScreenShotResult after 0 seconds

@NOSBatteryChargeToolbarThinkpad
Scenario: VAN27994_TestStep189_Check the Battery charge threshold toggle display off statue from vantage
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn off the Battery charge threshold
	When check the Battery charge threshold display
	Given Close Toolbar Background
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Then The Battery charge threshold button displays same as with Vantage

@NOSBatteryChargeToolbarThinkpad
Scenario: VAN27994_TestStep190_Check the Battery charge threshold button display off statue from toolbar
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Battery charge threshold
	Given Close Toolbar Background
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	When turn off Battery charge threshold from power page on Lenovo Vantage
	Given Launch Toolbar On NewOS
	Then The Battery charge threshold button display off statue

@NOSBatteryChargeToolbarThinkpad
Scenario: VAN27994_TestStep193_Check the Battery charge threshold button display on statue from toolbar
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background 
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	When turn on Battery charge threshold from power page on Lenovo Vantage
	Given Launch Toolbar On NewOS
	Then The Battery charge threshold button display on statue

@NOSBatteryChargeToolbarThinkpad
Scenario: VAN27994_TestStep194_Check the Battery charge threshold button display off statue from toolbar
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	When turn off Battery charge threshold from power page on Lenovo Vantage
	Given Launch Toolbar On NewOS
	Then The Battery charge threshold button display off statue

@OSToolbarNoBattery
Scenario: VAN27994_TestStep195_Check Battery charge threshold button with bad battery display disabled statue from toolbar
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Then The Battery charge threshold button display on and grey out status

@NOSAirplaneToolbaTthinkpad
Scenario: VAN27994_TestStep197_Check the Airplane power mode button displays same as with Vantage
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When check the Airplane power mode display
	Given Open the My Device Settings and into Power page
	Given Jump to Power settings
	Then The Airplane power mode button displays same as with Vantage

@NOSAirplaneToolbaTthinkpad
Scenario: VAN27994_TestStep198_Check The hover tips display is "Airplane power mode"
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Click batterydetails button on toolbar
	When Hover the mouse on the Airplane power mode button
	Then Take Screen Shot 198AirplanepowermodeOff in 27994 under ToolbarScreenShotResult

@NOSAirplaneToolbaTthinkpad
Scenario: VAN27994_TestStep199_Check the Airplane power mode button display on statue from toolbar
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Airplane power mode
	Then The Airplane power mode button display on statue

@NOSAirplaneToolbaTthinkpad
Scenario: VAN27994_TestStep200_Check The text display is "Airplane power mode on"
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn off the Airplane power mode
	When Turn on the Airplane power mode
	Then Take screen shot 200checktipAirplanepowermodeOn in 27994 under ToolbarScreenShotResult after 0 seconds

