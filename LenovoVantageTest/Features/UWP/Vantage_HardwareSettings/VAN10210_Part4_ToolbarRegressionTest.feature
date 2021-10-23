Feature: VAN10210_Part4_ToolbarRegressionTest
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-10210
	Author： Jinglong Zhao
	Update： Pengjie Chen
	Conmments: TestStep121-160

Background:
	Given Turn on or off the narrator 'on'

@TopRowToolbarOnThinkpad
Scenario: VAN10210_TestStep121_The button display F1-Fn function gray-out and unclickable stauts
	Given Pin toolbar to taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is on
	Given turn on Normal method
	When Turn on Special function on vantage input page 
	Given turn on Fn Sticky Key method
	When Launch toolbar
	Given wait 4 seconds
	Then The Top-row function button is disabled
	Then Take Screen Shot AC121_TopRowButtonDisplayF1FnFunctionIconAndGrayOutStatus in 10210 under ToolbarScreenShotResult

@TopRowToolbarOnThinkpad
Scenario: VAN10210_TestStep122_The button display F1-Fn function gray-out and unclickable stauts
	Given Pin toolbar to taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is on
	Given turn on Normal method
	When Turn on Special function on vantage input page 
	Given turn on Fn Sticky Key method
	Given turn on Normal method
	When Launch toolbar
	Given wait 4 seconds
	Then The Top-row function button display F1-F12 function status on toolbar
	Then Take Screen Shot AC122_TopRowButtonDisplayF1FnFunctionIconAndGrayOutStatus in 10210 under ToolbarScreenShotResult

@TopRowToolbarOnThinkpad
Scenario: VAN10210_TestStep123_01_The button status displayed same as Before
	Given Pin toolbar to taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is on
	Given turn on Normal method
	When Turn on Special function on vantage input page 
	Given launch toolbar
	When Record Top-row function status get from toolbar
	Given Uninstall the lenovo vatage
	When Launch toolbar
	Then The Top-row function button status displayed same as Before

@TopRowToolbarOnThinkpad
Scenario: VAN10210_TestStep123_02_Resandbox
	Given Install Vantage

@KeyboardBacklightToolbarIdea
Scenario: VAN10210_TestStep124_Check the Keyboard backlight button displays same as with Vantage
	Given Pin toolbar to taskbar
	When Launch toolbar
	When check the Keyboard backlight display
	When Close toolbar
	Given Go to input page
	Then The Keyboard backlight button displays same as with Vantage

@KeyboardBacklightToolbarIdea
Scenario: VAN10210_TestStep125_Check The text display is "Keyboard backlight"
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Hover the mouse on the keyboard backlight button
	Then Take Screen Shot TestStep125 in 10210 under ToolbarScreenShotResult
	When Close toolbar

@KeyboardBacklightToolbarIdea
Scenario: VAN10210_TestStep126_Check the keyboard backlight button display on statue from toolbar
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Keyboard backlight
	Then The keyboard backlight button display on statue
	When Close toolbar

@KeyboardBacklightToolbarIdea
Scenario: VAN10210_TestStep127_Check The text display is "Keyboard backlight on"
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Keyboard backlight
	Then Take screen shot TestStep127 in 10210 under ToolbarScreenShotResult after 0 seconds
	When Close toolbar

@KeyboardBacklightToolbarIdea
Scenario: VAN10210_TestStep128_Check the keyboard backlight toggle display on statue from vantage
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Keyboard backlight
	When check the Keyboard backlight display
	When Close toolbar
	Given Go to input page
	Then The Keyboard backlight button displays same as with Vantage

@KeyboardBacklightToolbarIdea
Scenario: VAN10210_TestStep129_Check the keyboard backlight button display off statue from toolbar
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Keyboard backlight
	When Close toolbar
	Given Go to input page
	Given turn off Keyboard backlight on input page
	When Launch toolbar
	Then The keyboard backlight button display off statue
	When Close toolbar

@KeyboardBacklightToolbarIdea
Scenario: VAN10210_TestStep130_Check the keyboard backlight button display on statue from toolbar
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn off the Keyboard backlight
	Then The keyboard backlight button display off statue
	When Close toolbar

@KeyboardBacklightToolbarIdea
Scenario: VAN10210_TestStep131_Check The text display is Keyboard backlight off
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn off the Keyboard backlight
	Then Take screen shot TestStep131 in 10210 under ToolbarScreenShotResult after 0 seconds
	When Close toolbar

@KeyboardBacklightToolbarIdea
Scenario: VAN10210_TestStep132_Check the keyboard backlight toggle display off statue from vantage
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn off the Keyboard backlight
	When check the Keyboard backlight display
	When Close toolbar
	Given Go to input page
	Then The Keyboard backlight button displays same as with Vantage

@KeyboardBacklightToolbarIdea
Scenario: VAN10210_TestStep133_Check the keyboard backlight button display on statue from toolbar
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn off the Keyboard backlight
	When Close toolbar
	Given Go to input page
	Given turn on Keyboard backlight on input page
	When Launch toolbar
	Then The keyboard backlight button display on statue
	When Close toolbar

@KeyboardBacklightToolbarIdea
Scenario: VAN10210_TestStep134_Check the keyboard backlight toggle display on statue from vantage
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Keyboard backlight
	When Close toolbar
	Given Uninstall the lenovo vatage
	When wait 180 seconds
	Given Install Vantage
	When Launch toolbar
	Then The keyboard backlight button display off statue
	When Close toolbar

@KeyboardBacklightfourToolbarIdea
Scenario: VAN10210_TestStep135_Check The Keyboard backlight button displays same as with Vantage
	Given Pin toolbar to taskbar
	#When Launch toolbar
	#When Select high of keyboard backlight on toolbar
	#Then The Keyboard backlight button display high status from toolbar
	#When Close toolbar
	#Given Go to input page
	#Then The Keyboard backlight button display high status on vantage input page
	Then Check The Keyboard backlight button displays same as with Vantage

@KeyboardBacklightfourToolbarIdea
Scenario: VAN10210_TestStep136_Select Auto mode check The button display Auto status
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Select auto of keyboard backlight on toolbar
	Then The Keyboard backlight button display auto status from toolbar
	When Close toolbar

@KeyboardBacklightfourToolbarIdea
Scenario: VAN10210_TestStep137_Check the Keyboard backlight button text info is displayed
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Select auto of keyboard backlight on toolbar
	Then Take screen shot TestStep137 in 10210 under ToolbarScreenShotResult after 0 seconds
	Then The Keyboard backlight button display auto status from toolbar
	When Close toolbar

@KeyboardBacklightfourToolbarIdea
Scenario: VAN10210_TestStep138_Select Auto mode go to Lenovo Vantage check button display
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Select auto of keyboard backlight on toolbar
	When Close toolbar
	Given Go to input page
	Then The Keyboard backlight button display auto status on vantage input page

@KeyboardBacklightfourToolbarIdea
Scenario: VAN10210_TestStep139_Check The Keyboard backlight button displays
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Select auto of keyboard backlight on toolbar
	When Close toolbar
	Given Go to input page
	When Select low of keyboard backlight on vantage input page
	When Launch toolbar
	Then The Keyboard backlight button display low status from toolbar
	When Close toolbar

#@KeyboardBacklightfourToolbarIdeaDebug
#Scenario: VAN10210_TestStep140_Check The Keyboard backlight button display off and gray out status
#	Given Pin toolbar to taskbar
#	When Launch toolbar
#	When Select auto of keyboard backlight on toolbar
#	When Close toolbar
#	Given Turn 'on' Action Center for 'TabletMode'
#	When Launch toolbar
#	Then Take screen shot TestStep140 in 10210 under ToolbarScreenShotResult after 0 seconds
#	When Close toolbar
#	Given Turn 'off' Action Center for 'TabletMode'

#@KeyboardBacklightfourToolbarIdeaS3Debug
#Scenario: VAN10210_TestStep141_Check The Keyboard backlight display Auto status immediately
#	Given Pin toolbar to taskbar
#	When Launch toolbar
#	When Select auto of keyboard backlight on toolbar
#	When enter sleep
#	Then The Keyboard backlight button display auto status from toolbar
#	When Close toolbar

@KeyboardBacklightfourToolbarIdea
Scenario: VAN10210_TestStep142_Check The button display Low status
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Select auto of keyboard backlight on toolbar
	When Select low of keyboard backlight on toolbar
	Then The Keyboard backlight button display low status from toolbar
	When Close toolbar

@KeyboardBacklightfourToolbarIdea
Scenario: VAN10210_TestStep143_Check the button text info is displayed
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Select low of keyboard backlight on toolbar
	Then Take screen shot TestStep143 in 10210 under ToolbarScreenShotResult after 0 seconds
	Then The Keyboard backlight button display low status from toolbar
	When Close toolbar

@KeyboardBacklightfourToolbarIdea
Scenario: VAN10210_TestStep144_Select low mode go to Lenovo Vantage check button display
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Select low of keyboard backlight on toolbar
	When Close toolbar
	Given Go to input page
	Then The Keyboard backlight button display low status on vantage input page

@KeyboardBacklightfourToolbarIdea
Scenario: VAN10210_TestStep145_Check The button display high status
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Select low of keyboard backlight on toolbar
	When Close toolbar
	Given Go to input page
	When Select high of keyboard backlight on vantage input page
	When Launch toolbar
	Then The Keyboard backlight button display high status from toolbar
	When Close toolbar

@KeyboardBacklightfourToolbarIdea
Scenario: VAN10210_TestStep148_Check The button display high status
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Select high of keyboard backlight on toolbar
	Then The Keyboard backlight button display high status from toolbar
	When Close toolbar

@KeyboardBacklightfourToolbarIdea
Scenario: VAN10210_TestStep149_Check The BacklightHigh_Text
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Select low of keyboard backlight on toolbar
	When Select high of keyboard backlight on toolbar
	Then Take screen shot TestStep149_CheckBacklightHigh_Text in 10210 under ToolbarScreenShotResult after 0 seconds
	Then The Keyboard backlight button display high status from toolbar

@KeyboardBacklightfourToolbarIdea
Scenario: VAN10210_TestStep150_Check vantageinput page high status
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Select high of keyboard backlight on toolbar
	Given Go to input page
	Then The Keyboard backlight button display high status on vantage input page

@KeyboardBacklightfourToolbarIdea
Scenario: VAN10210_TestStep151_check inputpage change off then toolbar change off
	Given Pin toolbar to taskbar
	Given launch toolbar
	When Select high of keyboard backlight on toolbar
	Given Go to input page
	When Select off of keyboard backlight on vantage input page
	Given launch toolbar
	Then The Keyboard backlight button display off status from toolbar

@KeyboardBacklightfourToolbarIdea
Scenario: VAN10210_TestStep154_Check toolbar off status
	Given Pin toolbar to taskbar
	Given launch toolbar
	When Select off of keyboard backlight on toolbar
	Then The Keyboard backlight button display off status from toolbar

@KeyboardBacklightfourToolbarIdea
Scenario: VAN10210_TestStep155_Check backlight off text
	Given Pin toolbar to taskbar
	Given launch toolbar
	When Select high of keyboard backlight on toolbar
	When Select off of keyboard backlight on toolbar
	Then Take screen shot TestStep155_CheckBacklightOff_Text in 10210 under ToolbarScreenShotResult after 0 seconds
	Then The Keyboard backlight button display off status from toolbar

@KeyboardBacklightfourToolbarIdea
Scenario: VAN10210_TestStep156_check input page off status
	Given Pin toolbar to taskbar
	Given launch toolbar
	When Select off of keyboard backlight on toolbar
	Given Go to input page
	Then The Keyboard backlight button display off status on vantage input page

@KeyboardBacklightfourToolbarIdea
Scenario: VAN10210_TestStep157_check input page select auto then toolbar change auto
	Given Pin toolbar to taskbar
	Given launch toolbar
	When Select off of keyboard backlight on toolbar
	Given Go to input page
	When Select auto of keyboard backlight on vantage input page
	Given launch toolbar
	Then The Keyboard backlight button display auto status from toolbar