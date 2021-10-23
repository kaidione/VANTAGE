Feature: VAN16517_ KeyboardBacklightOnIdeaPad
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-16517
	Author： Marcus

@autokeyboardbacklightonIdeapad
Scenario: VAN16517_Step_1_Check_title_option_icon_and_description_of_auto_keyboard_backlight_Step47_SequenceIsAutoLowHighOff
	Given Copy dependacy file to debug path
	Given Go to input page
	When check the title, option, icon and description of UI
	Then title, option,icon and description should be correct
	When turn on narrator
	And Launch toolbar
	And Switch the KBBL value to 'Keyboard backlight auto.'
	And click backlight on toolbar
	Then next backlight option on toolbar is 'Keyboard backlight low.'
	When click backlight on toolbar
	Then next backlight option on toolbar is 'Keyboard backlight high.'
	When click backlight on toolbar
	Then next backlight option on toolbar is 'Keyboard backlight off.'
	When click backlight on toolbar
	Then next backlight option on toolbar is 'Keyboard backlight auto.'
	When turn off narrator

@autokeyboardbacklightonIdeapad
Scenario: VAN16517_Step_3_user_select_auto_and_UI_should_be_auto_mode
	Given Go to input page
	When click auto mode and check the UI
	Then verify backlight option 'Auto' toggled
    Then click More to take the screenshot as below
	Then Take Screen Shot AutomodeSelectedStatusCheck in 16517 under HSScreenShotResult

@autokeyboardbacklightonIdeapad @Marcus @SmokeautokeyboardbacklightonIdeapad
Scenario: VAN16517_Step4_Step12_Step13_Step14_setbacklight_auto_low_high_off
	Given Go to input page
    Then click More to take the screenshot as below
	When click backlight option 'Auto'
	Then verify backlight option 'Auto' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is Auto
	And Take Screen Shot Step4 in VAN16517 under HardwareSettings
	When click backlight option 'Low'
	Then verify backlight option 'Low' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is Low
	And Take Screen Shot Step12 in VAN16517 under HardwareSettings
	When click backlight option 'High'
	Then verify backlight option 'High' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is High
	And Take Screen Shot Step13 in VAN16517 under HardwareSettings
	When click backlight option 'Off'
	Then verify backlight option 'Off' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is Off
	And Take Screen Shot Step14 in VAN16517 under HardwareSettings

@autokeyboardbacklightonIdeapad
Scenario: VAN16517_Step12_setbacklight_auto_low_high_off
	When Only Print 'Please check TestStep04'

@autokeyboardbacklightonIdeapad
Scenario: VAN16517_Step13_setbacklight_auto_low_high_off
	When Only Print 'Please check TestStep04'

@autokeyboardbacklightonIdeapad
Scenario: VAN16517_Step14_setbacklight_auto_low_high_off
	When Only Print 'Please check TestStep04'

@autokeyboardbacklightonIdeapad
Scenario: VAN16517_Step_18_user_select_auto_low_high_off_and_then_switch_the_page_the_setting_should_be_keep
	Given Go to input page
	When click auto mode and go to audio page and go to input page
	Then verify backlight option 'Auto' toggled
	When click low mode and go to audio page and go to input page
	Then verify backlight option 'Low' toggled
	When click high mode and go to audio page and go to input page
	Then verify backlight option 'High' toggled
	When click off mode and go to audio page and go to input page
	Then verify backlight option 'Off' toggled

@Marcus @autokeyboardbacklightonIdeapad
Scenario: VAN16517_Step29_UISyncWithHotkeyChange
	Given Set the KBBL value in EM driver to off
	When Set the KBBL value in EM driver to auto
	#And Launch vantage and go through tutorial with default segment
	And Go to input page
	Then verify backlight option 'Auto' toggled
	#And close lenovo vantage
	When Set the KBBL value in EM driver to low
	#And Launch vantage and go through tutorial with default segment
	And Go to input page
	Then verify backlight option 'Low' toggled
	#And close lenovo vantage
	When Set the KBBL value in EM driver to high
	#And Launch vantage and go through tutorial with default segment
	And Go to input page
	Then verify backlight option 'High' toggled
	#And close lenovo vantage
	When Set the KBBL value in EM driver to off
	#And Launch vantage and go through tutorial with default segment
	And Go to input page
	Then verify backlight option 'Off' toggled
	And close lenovo vantage
	
@Marcus @autokeyboardbacklightonIdeapad
Scenario: VAN16517_Step30_UISyncWithToolChange
	Given turn on narrator
	When Launch toolbar
	When Switch the KBBL value to 'Keyboard backlight auto.'
	#And Launch vantage and go through tutorial with default segment
	And Go to input page
	Then verify backlight option 'Auto' toggled
	#And close lenovo vantage
	When Launch toolbar
	When Switch the KBBL value to 'Keyboard backlight low.'
	#And Launch vantage and go through tutorial with default segment
	And Go to input page
	Then verify backlight option 'Low' toggled
	#And close lenovo vantage
	When Launch toolbar
	When Switch the KBBL value to 'Keyboard backlight high.'
	#And Launch vantage and go through tutorial with default segment
	And Go to input page
	Then verify backlight option 'High' toggled
	#And close lenovo vantage
	When Launch toolbar
	When Switch the KBBL value to 'Keyboard backlight off.'
	#And Launch vantage and go through tutorial with default segment
	And Go to input page
	Then verify backlight option 'Off' toggled
	#And close lenovo vantage
	Given turn on narrator

@Marcus @autokeyboardbacklightonIdeapad
Scenario: VAN16517_Step31_ToolbarThenGUIThenHotkey_lastOptionInEffect
	Given turn on narrator
	And Launch toolbar
	And Switch the KBBL value to 'Keyboard backlight auto.'
	#And Launch vantage and go through tutorial with default segment
	And Go to input page
	And click backlight option 'High'
	And Waiting 2 seconds
	When Set the KBBL value in EM driver to low
	And Go to Support page
	And Go to input page
	Then verify backlight option 'Low' toggled

@Marcus @autokeyboardbacklightonIdeapad
Scenario: VAN16517_Step32_GUIThenHotkeyThenToolbar_lastOptionInEffect
	Given turn on narrator
	#And Launch vantage and go through tutorial with default segment
	And Go to input page
	And click backlight option 'Low'
	And Waiting 2 seconds
	And Set the KBBL value in EM driver to High
	And Go to Support page
	And Go to input page
	And Launch toolbar
	When Switch the KBBL value to 'Keyboard backlight auto.'
	And Go to Support page
	And Go to input page
	Then verify backlight option 'Auto' toggled

@Marcus @autokeyboardbacklightonIdeapad
Scenario: VAN16517_Step33_HotkeyThenToolbarThenGUI_lastOptionInEffect
	Given turn on narrator
	And Set the KBBL value in EM driver to Off
	#And Launch vantage and go through tutorial with default segment
	And Go to input page
	And Launch toolbar
	When Switch the KBBL value to 'Keyboard backlight auto.'
	And Go to Support page
	And Go to input page
	And click backlight option 'High'
	And Go to Support page
	And Go to input page	
	Then verify backlight option 'High' toggled

@Marcus @autokeyboardbacklightonIdeapad
Scenario: VAN16517_Step36_MinimizeVantageThenHotKey
	Given Go to input page
	And click backlight option 'Off'
	Given Minimize Vantage
	And wait 301 seconds
	And Set the KBBL value in EM driver to High
	And Maximize Vatnage
	And Go to input page
	Then verify backlight option 'High' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is High

@Marcus @autokeyboardbacklightonIdeapad
Scenario: VAN16517_Step37_MinimizeVantageThenToolbar
	Given Go to input page
	And click backlight option 'Off'
	And Minimize Vantage
	And wait 301 seconds
	And turn on narrator
	And Launch toolbar
	When Switch the KBBL value to 'Keyboard backlight low.'
	And Maximize Vatnage
	And Go to input page
	Then verify backlight option 'Low' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is Low
	And turn off narrator

@Marcus @RequireNoVantage @autokeyboardbacklightonIdeapad
Scenario: VAN16517_Step41_Step42_VantageFromToolbar_GUIConformToSpec
	Given Launch Vantage from Toolbar
	And Waiting 5 seconds
	And Go to input page
	Then verify string 'Keyboard backlight' displays on Vantage by using json path '$.device.deviceSettings.inputAccessories.backlight.title' to retrieve from resource file
	And verify string 'Activate the keyboard backlight to facilitate typing in a dark' displays on Vantage by using json path '$.device.deviceSettings.inputAccessories.backlight.description.auto' to retrieve from resource file
	And verify string 'auto' displays on Vantage by using json path '$.device.deviceSettings.inputAccessories.backlight.level.auto' to retrieve from resource file
	And verify string 'low' displays on Vantage by using json path '$.device.deviceSettings.inputAccessories.backlight.level.low' to retrieve from resource file
	And verify string 'high' displays on Vantage by using json path '$.device.deviceSettings.inputAccessories.backlight.level.high' to retrieve from resource file
	And verify string 'off' displays on Vantage by using json path '$.device.deviceSettings.inputAccessories.backlight.level.off' to retrieve from resource file
	And click backlight option 'High'
	And verify backlight option 'High' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is High
	Then click More to take the screenshot as below
	And Take Screen Shot Step42_43 in VAN16517 under HardwareSettings

@autokeyboardbacklightonIdeapad
Scenario: VAN16517_Step42_VantageFromToolbar_GUIConformToSpec
	When Only Print 'Please check TestStep41'

	#Below scenario's steps refer to VAN15463 Step4,Step7,Step10
@Marcus @IdeaBacklight
Scenario:  VAN16517_Step45_Step46_On2LevelBacklight_OnlyToggleShowsUp
	Given Go to input page
	Then the toggle for backlight shows up
	And On 2 level backlight machine, We do NOT see 'Auto,Low,High,Off' toggles
	Given Turn on the toggle of keyboard backlight feature
	When Get the KBBL value in EM driver
	Then The KBBL value in EM driver is ON
	When Set the KBBL value in EM driver to OFF
	When Get the KBBL value in EM driver
	Then The KBBL value in EM driver is OFF

@Marcus @IdeaBacklight
Scenario:  VAN16517_Step46_On2LevelBacklight_OnlyToggleShowsUp
	When Only Print 'Please check TestStep45'

@Marcus @autokeyboardbacklightonIdeapad
	Scenario: VAN16517_Step48_UninstallVantage_EMDriverRecoverAuto
	Given Go to input page
	And click backlight option 'High'
	And close lenovo vantage
	And Uninstall the lenovo vatage
	And Waiting 301 seconds
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is Auto
	And Install Vantage
	Given Go to input page
	And verify backlight option 'Auto' toggled

@autokeyboardbacklightonIdeapad @Marcus
Scenario: VAN16517_Step52_01_Metrics
	Given Go to input page
	And Launch Http Traffic Capturer
	And Start Capture 
	When click backlight option 'Auto'
	Then the metric data is as expected with Test VAN16517 and Name Auto and Timeout 20
	When click backlight option 'Low'
	Then the metric data is as expected with Test VAN16517 and Name Low and Timeout 20
	When click backlight option 'High'
	Then the metric data is as expected with Test VAN16517 and Name High and Timeout 20
	When click backlight option 'Off'
	Then the metric data is as expected with Test VAN16517 and Name Off and Timeout 20
	Given Stop Capture

@autokeyboardbacklightonIdeapad
Scenario: VAN16517_Step53_Step54_Step55_PerformanceWithBacklight
	Given Stop Capture
	Given Uninstall the lenovo vatage
	And Install Vantage
	#And Launch vantage and go through tutorial with default segment
	When Go to input page
	Then verify strings 'all strings related to backlight ' displays in '3' seconds on Vantage by using json path '$.device.deviceSettings.inputAccessories.backlight.title,$.device.deviceSettings.inputAccessories.backlight.description.auto,$.device.deviceSettings.inputAccessories.backlight.level.low,$.device.deviceSettings.inputAccessories.backlight.level.high,$.device.deviceSettings.inputAccessories.backlight.level.off' to retrieve from resource file
	When click backlight option 'Low'
	And Get the KBBL value in EM driver without delay
	And The KBBL value in EM driver is Low
	And end time evaluation
	Then above steps are DONE in '2000' millinseconds
	Then click More to take the screenshot as below
	And Take Screen Shot Step53 in VAN16517 under HardwareSettings
	#And close lenovo vantage
	#And Launch vantage and go through tutorial with default segment
	When Go to input page
	Then verify strings 'all strings related to backlight' displays in '2' seconds on Vantage by using json path '$.device.deviceSettings.inputAccessories.backlight.title,$.device.deviceSettings.inputAccessories.backlight.description.auto,$.device.deviceSettings.inputAccessories.backlight.level.low,$.device.deviceSettings.inputAccessories.backlight.level.high,$.device.deviceSettings.inputAccessories.backlight.level.off' to retrieve from resource file
	Then click More to take the screenshot as below
	And Take Screen Shot Step54 in VAN16517 under HardwareSettings

@autokeyboardbacklightonIdeapad
Scenario: VAN16517_Step54_PerformanceWithBacklight
	When Only Print 'Please check TestStep53'

@autokeyboardbacklightonIdeapad
Scenario: VAN16517_Step55_PerformanceWithBacklight
	When Only Print 'Please check TestStep53'

@Marcus @autokeyboardbacklightonIdeapad
Scenario: VAN16517_Step57_MinimizeVantageThenGUI
	Given Go to input page
	And click backlight option 'Off'
	And Minimize Vantage
	And wait 301 seconds
	And Maximize Vatnage
	And Go to input page
	When click backlight option 'High'
	Then verify backlight option 'High' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is High

@Marcus @NotSupportIdeaBacklight
Scenario: VAN16517_Step60_NOUnexpectedOptions_4Idea
	Given Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	#And Go to MyDeviceSetting page with different locator
	And Go to input page
	Then There should not show the Keyboard backlight feature
	And On No backlight machine, We do NOT see 'Auto,Low,High,Off' toggles