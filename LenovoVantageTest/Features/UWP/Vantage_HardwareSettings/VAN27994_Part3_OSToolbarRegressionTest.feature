Feature: VAN27994_Part3_OSToolbarRegressionTest
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-27994
	Author： Haiye Li
	Conmments: TestStep101-150

Background:
	Given Turn on or off the narrator 'on'

@OSTopRowToolbarThinkpad 
Scenario: VAN27994_TestStep101_The button display F1-F12 function status on vantage input page
	Given Toolbar has been pin to Taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is off
	Given turn on Normal method
	Given Launch Toolbar On NewOS
	When Turn on F1-F12 function from toolbar
	Given Close Toolbar Background
	Given Go to display page
	Given Go to input page
	Then The Top-row function button display F1-F12 function status on vantage input page

@OSTopRowToolbarThinkpad 
Scenario: VAN27994_TestStep102_the Top-row button display spection function icon and gray out status
	Given Toolbar has been pin to Taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is off
	Given turn on Normal method
	Given Launch Toolbar On NewOS
	When Turn on F1-F12 function from toolbar
	Given Close Toolbar Background
	Given turn on Fn Sticky Key method
	Given Launch Toolbar On NewOS
	Then The Top-row function button is disabled
	Then Take Screen Shot TestStep102_TopRowButtonDisplaySpectionFunctionIconAndGrayOutStatus in 27994 under ToolbarScreenShotResult

@OSTopRowToolbarThinkpad
Scenario: VAN27994_TestStep103_the Top-row button display spection function icon and gray out status
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is off
	Given turn on Normal method
	Given Launch Toolbar On NewOS
	When Turn on F1-F12 function from toolbar
	Given Close Toolbar Background
	Given turn on Fn Sticky Key method
	Given turn on Normal method
	Given Launch Toolbar On NewOS
	When wait 2 seconds
	Then The Top-row function button display Special function status on toolbar
	Then Take Screen Shot TestStep103_TopRowButtonDisplaySpectionFunctionIconActiveStatus in 27994 under ToolbarScreenShotResult

@OSTopRowToolbarOnThinkpad
Scenario: VAN27994_TestStep104_The button display F1-F12 function statue on toolbar
	Given Toolbar has been pin to Taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is on
	Given turn on Fn Sticky Key method
	Given turn on Normal method
	Given Launch Toolbar On NewOS
	When wait 3 seconds
	Then The Top-row function button display F1-F12 function status on toolbar

@OSTopRowToolbarOnThinkpad
Scenario: VAN27994_TestStep105_The text display is "F1-F12 function enabled" and the text info is displayed in the middle
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is on
	Given turn on Normal method
	Given Launch Toolbar On NewOS
	When Turn on Special function from toolbar
	When Turn on F1-F12 function from toolbar
	Then Take screen shot TestStep105_textDisplayF1_F12FunctionEnabled in 27994 under ToolbarScreenShotResult after 0 seconds

@OSTopRowToolbarOnThinkpad
Scenario: VAN27994_TestStep106_The button display Special function status on toolbar
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is on
	Given turn on Normal method
	When Turn on Special function on vantage input page 
	Given Launch Toolbar On NewOS
	Then The Top-row function button display Special function status on toolbar

@OSTopRowToolbarOnThinkpad
Scenario: VAN27994_TestStep107_The button display F1-F12 function status on vantage input page
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is on
	Given turn on Normal method
	When Turn on Special function on vantage input page 
	Given Launch Toolbar On NewOS
	When Turn on F1-F12 function from toolbar
	Given Close Toolbar Background
	Given Go to display page
	Given Go to input page
	Then The Top-row function button display F1-F12 function status on vantage input page

@OSTopRowToolbarOnThinkpad
Scenario: VAN27994_TestStep108_The button display F1-Fn function gray-out and unclickable stauts
	Given Toolbar has been pin to Taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is on
	Given turn on Normal method
	When Turn on Special function on vantage input page 
	Given turn on Fn Sticky Key method
	Given Launch Toolbar On NewOS
	Then The Top-row function button is disabled
	Then Take Screen Shot VAN27994_TopRowButtonDisplayF1-F12IconAndGrayOutStatus in 27994 under ToolbarScreenShotResult

@OSTopRowToolbarOnThinkpad
Scenario: VAN27994_TestStep109_The button display F1-Fn function gray-out and unclickable stauts
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is on
	Given turn on Normal method
	When Turn on Special function on vantage input page 
	Given turn on Fn Sticky Key method
	Given turn on Normal method
	Given Launch Toolbar On NewOS
	Then The Top-row function button display F1-F12 function status on toolbar
	Then Take Screen Shot AC122_TopRowButtonDisplayF1FnFunctionIconActiveStatus in 27994 under ToolbarScreenShotResult

@OSTopRowToolbarOnThinkpad
Scenario: VAN27994_TestStep110_The button status displayed same as Before
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is on
	Given turn on Normal method
	When Turn on Special function on vantage input page 
	Given Launch Toolbar On NewOS
	When Record Top-row function status get from toolbar
	Given Uninstall the lenovo vatage
	Given Launch Toolbar On NewOS
	Then The Top-row function button status displayed same as Before
	Given Install Vantage

@OSKeyboardBacklightToolbarIdea
Scenario: VAN27994_TestStep111_Check the Keyboard backlight button displays same as with Vantage
	Given Install Vantage
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When check the Keyboard backlight display
	Given Close Toolbar Background
	Given Go to input page
	Then The Keyboard backlight button displays same as with Vantage

@OSKeyboardBacklightToolbarIdea
Scenario: VAN27994_TestStep112_Check The text display is "Keyboard backlight"
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Click batterydetails button on toolbar
	When Hover the mouse on the keyboard backlight button
	Then Take Screen Shot TestStep112_CheckKBDTip in 27994 under ToolbarScreenShotResult

@OSKeyboardBacklightToolbarIdea
Scenario: VAN27994_TestStep113_Check the keyboard backlight button display on statue from toolbar
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Keyboard backlight
	Then The keyboard backlight button display on statue

@OSKeyboardBacklightToolbarIdea
Scenario: VAN27994_TestStep114_Check The text display is "Keyboard backlight on"
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Keyboard backlight
	Then Take screen shot TestStep114_CheckKBDStatusText in 27994 under ToolbarScreenShotResult after 0 seconds

@OSKeyboardBacklightToolbarIdea
Scenario: VAN27994_TestStep115_Check the keyboard backlight toggle display on statue from vantage
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Keyboard backlight
	When check the Keyboard backlight display
	Given Close Toolbar Background
	Given Go to input page
	Then The Keyboard backlight button displays same as with Vantage

@OSKeyboardBacklightToolbarIdea
Scenario: VAN27994_TestStep116_Check the keyboard backlight button display off statue from toolbar
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Keyboard backlight
	Given Close Toolbar Background
	Given Go to input page
	Given turn off Keyboard backlight on input page
	Given Launch Toolbar On NewOS
	Then The keyboard backlight button display off statue

@OSKeyboardBacklightToolbarIdea
Scenario: VAN27994_TestStep117_Check the keyboard backlight button display on statue from toolbar
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn off the Keyboard backlight
	Then The keyboard backlight button display off statue

@OSKeyboardBacklightToolbarIdea
Scenario: VAN27994_TestStep118_Check The text display is Keyboard backlight off
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn off the Keyboard backlight
	Then Take screen shot TestStep118_CheckKBDOffText in 27994 under ToolbarScreenShotResult after 0 seconds

@OSKeyboardBacklightToolbarIdea
Scenario: VAN27994_TestStep119_Check the keyboard backlight toggle display off statue from vantage
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn off the Keyboard backlight
	When check the Keyboard backlight display
	Given Go to input page
	Then The Keyboard backlight button displays same as with Vantage

@OSKeyboardBacklightToolbarIdea
Scenario: VAN27994_TestStep120_Check the keyboard backlight button display on statue from toolbar
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn off the Keyboard backlight
	Given Close Toolbar Background
	Given Go to input page
	Given turn on Keyboard backlight on input page
	Given Launch Toolbar On NewOS
	Then The keyboard backlight button display on statue

@OSKeyboardBacklightToolbarIdea
Scenario: VAN27994_TestStep121_Check the keyboard backlight toggle display on statue from vantage
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Keyboard backlight
	Given Close Toolbar Background
	Given Uninstall the lenovo vatage
	When wait 180 seconds
	Given Launch Toolbar On NewOS
	Then The keyboard backlight button display off statue
	Given Close Toolbar Background
	Given Install Vantage

@OSKeyboardBacklightfourToolbarIdea
Scenario: VAN27994_TestStep122_Check The Keyboard backlight button displays same as with Vantage
	Given Toolbar has been pin to Taskbar
	Then Check The Keyboard backlight button displays same as with Vantage On NewOS

@OSKeyboardBacklightfourToolbarIdea
Scenario: VAN27994_TestStep123_Select Auto mode check The button display Auto status
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Select auto of keyboard backlight on toolbar
	Then The Keyboard backlight button display auto status from toolbar

@OSKeyboardBacklightfourToolbarIdea
Scenario: VAN27994_TestStep124_Check the Keyboard backlight button text info is displayed
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Select low of keyboard backlight on toolbar
	When Select auto of keyboard backlight on toolbar
	Then Take screen shot TestStep124_KeyboardBacklightButton_AutoText in 27994 under ToolbarScreenShotResult after 0 seconds
	Then The Keyboard backlight button display auto status from toolbar

@OSKeyboardBacklightfourToolbarIdea
Scenario: VAN27994_TestStep125_Select Auto mode go to Lenovo Vantage check button display
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Select auto of keyboard backlight on toolbar
	Given Close Toolbar Background
	Given Go to input page
	Then The Keyboard backlight button display auto status on vantage input page

@OSKeyboardBacklightfourToolbarIdea
Scenario: VAN27994_TestStep126_Check The Keyboard backlight button displays
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Select auto of keyboard backlight on toolbar
	Given Close Toolbar Background
	Given Go to input page
	When Select low of keyboard backlight on vantage input page
	Given Launch Toolbar On NewOS
	Then The Keyboard backlight button display low status from toolbar

@OSKeyboardBacklightfourToolbarIdea
Scenario: VAN27994_TestStep129_Check The button display Low status
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Select auto of keyboard backlight on toolbar
	When Select low of keyboard backlight on toolbar
	Then The Keyboard backlight button display low status from toolbar

@OSKeyboardBacklightfourToolbarIdea
Scenario: VAN27994_TestStep130_Check the button text info is displayed
	Given Toolbar has been pin to Taskbar
	When Select auto of keyboard backlight on toolbar
	When Select low of keyboard backlight on toolbar
	Then Take screen shot TestStep130_KeyboardBacklightButton_LowText in 27994 under ToolbarScreenShotResult after 0 seconds
	Then The Keyboard backlight button display low status from toolbar

@OSKeyboardBacklightfourToolbarIdea
Scenario: VAN27994_TestStep131_Select low mode go to Lenovo Vantage check button display
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Select low of keyboard backlight on toolbar
	Given Close Toolbar Background
	Given Go to input page
	Then The Keyboard backlight button display low status on vantage input page

@OSKeyboardBacklightfourToolbarIdea
Scenario: VAN27994_TestStep132_Check The button display high status
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Select low of keyboard backlight on toolbar
	Given Close Toolbar Background
	Given Go to input page
	When Select high of keyboard backlight on vantage input page
	Given Launch Toolbar On NewOS
	Then The Keyboard backlight button display high status from toolbar
	
@OSKeyboardBacklightfourToolbarIdea
Scenario: VAN27994_TestStep135_Check The button display high status
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Select high of keyboard backlight on toolbar
	Then The Keyboard backlight button display high status from toolbar

@OSKeyboardBacklightfourToolbarIdea
Scenario: VAN27994_TestStep136_Check The BacklightHigh_Text
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Select low of keyboard backlight on toolbar
	When Select high of keyboard backlight on toolbar
	Then Take screen shot TestStep136_CheckBacklightHigh_Text in 27994 under ToolbarScreenShotResult after 0 seconds
	Then The Keyboard backlight button display high status from toolbar

@OSKeyboardBacklightfourToolbarIdea
Scenario: VAN27994_TestStep137_Check vantageinput page high status
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Select high of keyboard backlight on toolbar
	Given Close Toolbar Background
	Given Go to input page
	Then The Keyboard backlight button display high status on vantage input page

@OSKeyboardBacklightfourToolbarIdea
Scenario: VAN27994_TestStep138_check inputpage change off then toolbar change off
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Select high of keyboard backlight on toolbar
	Given Close Toolbar Background
	Given Go to input page
	When Select off of keyboard backlight on vantage input page
	Given Launch Toolbar On NewOS
	Then The Keyboard backlight button display off status from toolbar

@OSKeyboardBacklightfourToolbarIdea
Scenario: VAN27994_TestStep141_Check toolbar off status
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Select off of keyboard backlight on toolbar
	Then The Keyboard backlight button display off status from toolbar

@OSKeyboardBacklightfourToolbarIdea
Scenario: VAN27994_TestStep142_Check backlight off text
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Select high of keyboard backlight on toolbar
	When Select off of keyboard backlight on toolbar
	Then Take screen shot TestStep136_CheckBacklightOff_Text in 27994 under ToolbarScreenShotResult after 0 seconds
	Then The Keyboard backlight button display off status from toolbar

@OSKeyboardBacklightfourToolbarIdea
Scenario: VAN27994_TestStep143_check input page off status
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Select off of keyboard backlight on toolbar
	Given Close Toolbar Background
	Given Go to input page
	Then The Keyboard backlight button display off status on vantage input page

@OSKeyboardBacklightfourToolbarIdea
Scenario: VAN27994_TestStep144_check input page select auto then toolbar change auto
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Select off of keyboard backlight on toolbar
	Given Close Toolbar Background
	Given Go to input page
	When Select auto of keyboard backlight on vantage input page
	Given Launch Toolbar On NewOS
	Then The Keyboard backlight button display auto status from toolbar

