Feature: VAN10210_Part5_ToolbarRegressionTest
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-10210
	Author： Jinglong Zhao
	Update： Pengjie Chen
	Conmments: TestStep161-200

Background:
	Given Turn on or off the narrator 'on'

@KeyboardBacklightToolbarThinkpad
Scenario: VAN10210_TestStep168_The keyboard backlight button display Low status
	Given Pin toolbar to taskbar
	When launch toolbar
	When Select low of keyboard backlight on toolbar
	Then The Keyboard backlight button display low status from toolbar
	Given Close toolbar

@KeyboardBacklightToolbarThinkpad
Scenario: VAN10210_TestStep169_The text display is Keyboard backlight low
	Given Pin toolbar to taskbar
	When launch toolbar
	When Select off of keyboard backlight on toolbar
	When Select low of keyboard backlight on toolbar
	Given Take Screen Shot AC169_textDisplayKeyboardBacklightLow in 10210 under ToolbarScreenShotResult
	Given Close toolbar

@KeyboardBacklightToolbarThinkpad
Scenario: VAN10210_TestStep170_The keyboard backlight button display Low status on vantage
	Given Pin toolbar to taskbar
	When launch toolbar
	When Select low of keyboard backlight on toolbar
	Given Go to input page
	Then The Keyboard backlight button display low status on vantage input page

@KeyboardBacklightToolbarThinkpad
Scenario: VAN10210_TestStep171_The keyboard backlight button display High status on toolbar after select status on vantage
	Given Pin toolbar to taskbar
	When launch toolbar
	When Select low of keyboard backlight on toolbar
	Given Close toolbar
	Given Go to input page
	When Select high of keyboard backlight on vantage input page	
	When launch toolbar
	Then The Keyboard backlight button display high status from toolbar

@KeyboardBacklightToolbarThinkpad
Scenario: VAN10210_TestStep172_The keyboard backlight button display High status on toolbar
	Given Pin toolbar to taskbar
	When launch toolbar
	When Select high of keyboard backlight on toolbar
	Then The Keyboard backlight button display high status from toolbar
	Given Close toolbar

@KeyboardBacklightToolbarThinkpad
Scenario: VAN10210_TestStep173_The text display is Keyboard backlight high on toolbar
	Given Pin toolbar to taskbar
	When launch toolbar
	When Select off of keyboard backlight on toolbar
	When Select high of keyboard backlight on toolbar
	Given Take screen shot AC173_textDisplayKeyboardBacklightHigh in 10210 under ToolbarScreenShotResult after 0 seconds
	Given Close toolbar

@KeyboardBacklightToolbarThinkpad
Scenario: VAN10210_TestStep174_The keyboard backlight button display High status on toolbar
	Given Pin toolbar to taskbar
	When launch toolbar
	When Select high of keyboard backlight on toolbar
	Given Close toolbar
	When launch toolbar
	Then The Keyboard backlight button display high status from toolbar
	Given Close toolbar

@KeyboardBacklightToolbarThinkpad
Scenario: VAN10210_TestStep175_The keyboard backlight button display High status on vantage
	Given Pin toolbar to taskbar
	When launch toolbar
	When Select high of keyboard backlight on toolbar
	Given Close toolbar
	Given Go to input page
	Then The Keyboard backlight button display high status on vantage input page

@KeyboardBacklightToolbarThinkpad
Scenario: VAN10210_TestStep176_The keyboard backlight button display Off status on toolbar
	Given Pin toolbar to taskbar
	When launch toolbar
	When Select high of keyboard backlight on toolbar
	Given Go to input page
	When Select off of keyboard backlight on vantage input page	
	When launch toolbar
	Then The Keyboard backlight button display off status from toolbar

@KeyboardBacklightToolbarThinkpad
Scenario: VAN10210_TestStep177_The keyboard backlight button display off status on toolbar
	Given Pin toolbar to taskbar
	When launch toolbar
	When Select off of keyboard backlight on toolbar
	Then The Keyboard backlight button display off status from toolbar
	Given Close toolbar

@KeyboardBacklightToolbarThinkpad
Scenario: VAN10210_TestStep178_The text display is Keyboard backlight off on toolbar
	Given Pin toolbar to taskbar
	When launch toolbar
	When Select high of keyboard backlight on toolbar
	When Select off of keyboard backlight on toolbar
	Given Take screen shot AC177_textDisplayKeyboardBacklightOff in 10210 under ToolbarScreenShotResult after 0 seconds
	Given Close toolbar

@KeyboardBacklightToolbarThinkpad
Scenario: VAN10210_TestStep179_The keyboard backlight button display off status on toolbar
	Given Pin toolbar to taskbar
	When launch toolbar
	When Select off of keyboard backlight on toolbar
	Given Close toolbar
	When launch toolbar
	Then The Keyboard backlight button display off status from toolbar
	Given Close toolbar

@KeyboardBacklightToolbarThinkpad
Scenario: VAN10210_TestStep180_The keyboard backlight button display off status on vantage input page
	Given Pin toolbar to taskbar
	When launch toolbar
	When Select off of keyboard backlight on toolbar
	Given Close toolbar
	Given Go to input page
	Then The Keyboard backlight button display off status on vantage input page

@KeyboardBacklightToolbarThinkpad
Scenario: VAN10210_TestStep181_The keyboard backlight button display low status on toolbar after select low status on vantage
	Given Pin toolbar to taskbar
	When launch toolbar
	When Select off of keyboard backlight on toolbar
	Given Close toolbar
	Given Go to input page
	When Select low of keyboard backlight on vantage input page
	When launch toolbar
	Then The Keyboard backlight button display low status from toolbar
	Given Close toolbar

#@KeyboardBacklightToolbarThinkpad
#Scenario: VAN10210_TestStep182_The keyboard backlight button display status on toolbar same as with vantage
#	Given Pin toolbar to taskbar
#	When launch toolbar
#	Then The keyboard backlight button displays same as with Vantage

@ToolbarPrivacyGuard
Scenario: VAN10210_TestStep183_The Privacy guard button displays same as with Vantage
	Given Pin toolbar to taskbar
	When launch toolbar
	Then The Privacy guard button displays same as with Vantage

@ToolbarPrivacyGuard
Scenario: VAN10210_TestStep184_The hover tips display is Privacy guard
	Given Pin toolbar to taskbar
	When launch toolbar
	Given Turn off privacy guard from toolbar
	Given Close toolbar
	When launch toolbar
	When Hover the mouse on the button Privacy guard
	Then Take Screen Shot AC184_01textDisplayPrivacyGuard in 10210 under ToolbarScreenShotResult
	Given Close toolbar
	When launch toolbar
	Given Turn on privacy guard from toolbar
	Given Close toolbar
	When launch toolbar
	When Hover the mouse on the button Privacy guard
	Then Take Screen Shot AC184_02textDisplayPrivacyGuard in 10210 under ToolbarScreenShotResult
	
@ToolbarPrivacyGuard
Scenario: VAN10210_TestStep185_The Privacy guard button displays on status from toolbar
	Given Pin toolbar to taskbar
	When launch toolbar
	Given Turn on privacy guard from toolbar
	Then The Privacy guard button displays on status from toolbar
	Given Close toolbar

@ToolbarPrivacyGuard
Scenario: VAN10210_TestStep186_Check Privacy guard UI and tips
	Given Pin toolbar to taskbar
	When launch toolbar
	Given Turn on privacy guard from toolbar
	Then The Privacy guard button displays on status from toolbar
	Then Take screen shot VAN10210_TestStep186 in 10210 under HSScreenShotResult after 0 seconds
	Given Close toolbar

@ToolbarPrivacyGuard
Scenario: VAN10210_TestStep187_Check Privacy guard toggle is off
	Given Pin toolbar to taskbar
	When launch toolbar
	Given Turn off privacy guard from toolbar
	Then The Privacy guard button displays off status from toolbar
	Given Close toolbar

@ToolbarPrivacyGuard
Scenario: VAN10210_TestStep188_Check Privacy guard UI and tips
	Given Pin toolbar to taskbar
	When launch toolbar
	Given Turn off privacy guard from toolbar
	Then The Privacy guard button displays off status from toolbar
	Then Take screen shot VAN10210_TestStep188 in 10210 under HSScreenShotResult after 0 seconds
	Given Close toolbar

@ToolbarPrivacyGuard
Scenario: VAN10210_TestStep189_Check Privacy guard status on
	Given Pin toolbar to taskbar
	When launch toolbar
	Given Turn on privacy guard from toolbar
	Then The Privacy guard button displays on status from toolbar
	When Go to display page
	Given Click DisplayLink
	Then Check Privacy Guard toggle is 'on'

@ToolbarPrivacyGuard
Scenario: VAN10210_TestStep190_Check Privacy guard status off
	Given Pin toolbar to taskbar
	When launch toolbar
	Given Turn off privacy guard from toolbar
	Then The Privacy guard button displays off status from toolbar
	When Go to display page
	Given Click DisplayLink
	Then Check Privacy Guard toggle is 'off'

@ToolbarPrivacyGuard
Scenario: VAN10210_TestStep191_Check Privacy guard status on
	Given Pin toolbar to taskbar
	When Go to display page
	Given Click DisplayLink
	Then Turn on Privacy Guard
	Then Check Privacy Guard toggle is 'on'
	When launch toolbar
	Then The Privacy guard button displays on status from toolbar
	Given Close toolbar

@ToolbarPrivacyGuard
Scenario: VAN10210_TestStep192_Check Privacy guard status off
	Given Pin toolbar to taskbar
	When Go to display page
	Given Click DisplayLink
	Then Turn off Privacy Guard
	Then Check Privacy Guard toggle is 'off'
	When launch toolbar
	Then The Privacy guard button displays off status from toolbar
	Given Close toolbar

@BatteryChargeToolbarThinkpad
Scenario: VAN10210_TestStep193_Check the Battery charge threshold button displays same as with Vantage
	Given Pin toolbar to taskbar
	When Launch toolbar
	When check the Battery charge threshold display
	When Close toolbar
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Then The Battery charge threshold button displays same as with Vantage

@BatteryChargeToolbarThinkpad
Scenario: VAN10210_TestStep194_Check The hover tips display is "Battery charge threshold"
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Battery charge threshold
	When Turn off the Battery charge threshold
	When Close toolbar
	When Launch toolbar
	When Hover the mouse on the Battery charge threshold button
	Then Take Screen Shot TestStep194off in 10210 under ToolbarScreenShotResult
	When Launch toolbar
	When Turn on the Battery charge threshold
	When Close toolbar
	When Launch toolbar
	When Hover the mouse on the Battery charge threshold button
	Then Take Screen Shot TestStep194on in 10210 under ToolbarScreenShotResult
	When Close toolbar

@BatteryChargeToolbarThinkpad
Scenario: VAN10210_TestStep195_Check the Battery charge threshold button display on statue from toolbar
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Battery charge threshold
	Then The Battery charge threshold button display on statue
	When Close toolbar

@BatteryChargeToolbarThinkpad
Scenario: VAN10210_TestStep196_Check The text display is "Battery charge threshold"
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Battery charge threshold
	Then Take screen shot TestStep196 in 10210 under ToolbarScreenShotResult after 0 seconds
	When Close toolbar

@BatteryChargeToolbarThinkpad
Scenario: VAN10210_TestStep197_Check the Battery charge threshold toggle display on statue from vantage
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Battery charge threshold
	When check the Battery charge threshold display
	When Close toolbar
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Then The Battery charge threshold button displays same as with Vantage

@BatteryChargeToolbarThinkpad
Scenario: VAN10210_TestStep198_Check the Battery charge threshold button display on status from toolbar
	Given Pin toolbar to taskbar
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	When turn on Battery charge threshold from power page on Lenovo Vantage
	When Launch toolbar
	Then The Battery charge threshold button display on statue
	When Close toolbar

#@DevToolbar
#Scenario: VAN10210_TestStep199_Check the Battery charge threshold button display on and gray out status from toolbar
#	Given Pin toolbar to taskbar
#	Given Open the My Device Settings and into Power page
#	Given Jump to Battery settings
#	Given stop battery gauge reset
#	When Launch toolbar
#	When Turn on the Battery charge threshold
#	When check the Battery charge threshold display
#	When Close toolbar
#	Given Open the My Device Settings and into Power page
#	Given Jump to Battery settings
#	Given enable battery gauge reset
#	When Launch toolbar
#	Then The Battery charge threshold button display on and grey out status
#	When Close toolbar