Feature: VAN15463_Part1_HSIdeaBacklight
	Test Case： https://jira.tc.lenovo.com/browse/VAN-15463
	JIRA Task: https://jira.tc.lenovo.com/browse/HAIDIAN-494
	Author： Yang Liu
	Update: Yingying Li
	Update: Jingting Jia

@IdeaBacklight
Scenario: VAN15463_TestStep00_InitEnvironment
	Given Change DPI to 125
	Given turn on narrator
	#Given Copy dependacy file to debug path

@IdeaBacklight
Scenario: VAN15463_TestStep02_Check the Keyboard backlight feature show, state of the toggle follow the BIOS/EC value
	Given Go to input page
	Then There shows the Keyboard backlight feature
	When Get the KBBL value in EM driver
	Then The ONOFF KBBL value in UI match the EM driver value

@IdeaBacklight @SmokeIdeaBacklight
Scenario: VAN15463_TestStep04_Turn on the KBBL Toggle, the EM driver value should be set to on
	Given Go to input page
	Given Turn on the toggle of keyboard backlight feature
	When Get the KBBL value in EM driver
	Then The KBBL value in EM driver is ON
	When wait 3 seconds
	Then Check Keyboard backlight toggle state in Vantage is on

@IdeaBacklight
Scenario: VAN15463_TestStep06_Turn off the KBBL Toggle, the EM driver value should be set to off
	Given Go to input page
	Given Turn on the toggle of keyboard backlight feature
	When Get the KBBL value in EM driver
	Then The KBBL value in EM driver is ON
	Given Turn off the toggle of keyboard backlight feature
	When Get the KBBL value in EM driver
	Then The KBBL value in EM driver is OFF
	Then Check Keyboard backlight toggle state in Vantage is off

@IdeaBacklight
Scenario: VAN15463_TestStep07_Turn on the KBBL form EM and verify the VantageUI
	Given Go to input page
	Given Turn off the toggle of keyboard backlight feature
	When Set the KBBL value in EM driver to ON
	When Get the KBBL value in EM driver
	Then The KBBL value in EM driver is ON
	Given Go to input page
	Then Check Keyboard backlight toggle state in Vantage is on

@IdeaBacklight
Scenario: VAN15463_TestStep10_Turn on the KBBL Toggle, set the EM driver value to off and CheckUI
	Given Go to input page
	Given Turn on the toggle of keyboard backlight feature
	When Set the KBBL value in EM driver to OFF
	When Get the KBBL value in EM driver
	Then The KBBL value in EM driver is OFF
	Given Go to input page
	Then Check Keyboard backlight toggle state in Vantage is off

@IdeaBacklight
Scenario: VAN15463_TestStep11_TestStep12_Turn on the KBBL Toggle, wait 3 minutes, EM will be on/off but UI still keep on
	Given Go to input page
	Given Turn on the toggle of keyboard backlight feature
	When Get the KBBL value in EM driver
	Then The KBBL value in EM driver is ON
	When wait 180 seconds
	When Get the KBBL value in EM driver
	Then The KBBL value in EM driver is ONOFF
	Then Check Keyboard backlight toggle state in Vantage is on

@IdeaBacklight
Scenario: VAN15463_TestStep32_TestStep33_Unisnatll Vantage and KBBL value change off
	Given Go to input page
	Given Turn on the toggle of keyboard backlight feature
	When Get the KBBL value in EM driver
	Then The KBBL value in EM driver is ON
	Given Uninstall the lenovo vatage
	When wait 300 seconds
	When Get the KBBL value in EM driver
	Then The KBBL value in EM driver is OFF
	When Launch toolbar
	When turn on Keyboard backlight from Toolbar
	Given Install Vantage
	Given Go to input page
	Then Check Keyboard backlight toggle state in Vantage is on

@IdeaBacklight
Scenario: VAN15463_TestStep34_User set EM driver value to check the Vantage UI will change the value
	Given Go to input page
	When Set the KBBL value in EM driver to OFF
	When Get the KBBL value in EM driver
	Then The KBBL value in EM driver is OFF
	Given Go to input page
	Then Check Keyboard backlight toggle state in Vantage is off
	When Set the KBBL value in EM driver to ON
	When Get the KBBL value in EM driver
	Then The KBBL value in EM driver is ON
	Given Go to input page
	Then Check Keyboard backlight toggle state in Vantage is on

@IdeaBacklight
Scenario: VAN15463_TestStep36_User set KBBL value from UI toolbar and EM then check the Vantage UI will change the value
	Given Go to input page
	Given Turn on the toggle of keyboard backlight feature
	When Launch toolbar
	When turn off Keyboard backlight from Toolbar
	Given Go to input page
	Then Check Keyboard backlight toggle state in Vantage is off
	When Set the KBBL value in EM driver to ON
	When Get the KBBL value in EM driver
	Then The KBBL value in EM driver is ON
	Given Go to input page
	Then Check Keyboard backlight toggle state in Vantage is on	

@IdeaBacklight
Scenario: VAN15463_TestStep37_User set KBBL value from UI EM and Toolbar then check the Vantage UI will change the value
	Given Go to input page
	Given Turn on the toggle of keyboard backlight feature
	When Set the KBBL value in EM driver to OFF
	When Get the KBBL value in EM driver
	Then The KBBL value in EM driver is OFF
	When Launch toolbar
	When turn on Keyboard backlight from Toolbar
	Given Go to input page
	Then Check Keyboard backlight toggle state in Vantage is on	

@IdeaBacklight
Scenario: VAN15463_TestStep38_Min Vantage and wait 5 minnutes check the Vantage UI will keep the value with EM
	Given Go to input page
	And Minimize Vantage
	When wait 300 seconds
	When Set the KBBL value in EM driver to ON
	When Get the KBBL value in EM driver
	Then The KBBL value in EM driver is ON
	Given Reopen the window
	Then Check Keyboard backlight toggle state in Vantage is on	

@IdeaBacklight
Scenario: VAN15463_TestStep23_Check the Keyboard backlight feature show, state of the toggle is on/off and the description should follow the UI SPEC
	Given Change DPI to 125
	Given Go to input page
	Then There shows the Keyboard backlight feature
	Then state of the toggle is on/off
	Then the description should follow the UI SPEC

@IdeaBacklight
Scenario: VAN15463_TestStep24_Check the keyboard backlight toggle should keep what user set before
	Given Go to input page
	Given Turn on the toggle of keyboard backlight feature
	Given Install Vantage
	Given Go to input page
	When click keyboard backlight caption
	Then The toggle should resume to default value off

@IdeaBacklight
Scenario: VAN15463_TestStep26_Check the keyboard backlight toggle should keep what user set before
	Given Go to input page
	Given Turn off the toggle of keyboard backlight feature
	Given Install Vantage
	Given Go to input page
	When click keyboard backlight caption
	Then The toggle should resume to default value off

@NotSupportIdeaBacklight
Scenario: VAN15463_TestStep28_Check the Keyboard backlight feature not show
	Given Machine is IdeaPad/Yoga/Gaming models and do not support keyboard backlight.
	Given Go to input page
	Then There should not show the Keyboard backlight feature

@IdeaBacklight
Scenario: VAN15463_TestStep35_Check the Keyboard backlight toggle state in Vantage should sync with Toolbar	
	Given Go to input page
	Given Pin toolbar to taskbar
	Given Turn on permission
	When Launch toolbar
	When turn off Keyboard backlight from Toolbar
	Then Close toolbar
	Given Go to input page
	Then Check Keyboard backlight toggle state in Vantage is off
	When Launch toolbar
	When turn on Keyboard backlight from Toolbar
	Then Close toolbar
	Given Go to input page
	Then Check Keyboard backlight toggle state in Vantage is on

@IdeaBacklight
Scenario: VAN15463_TestStep39_Check the Keyboard backlight toggle state in Vantage should sync with Toolbar
	Given Go to input page
	When Minimize vantage
	Given Waiting 300 seconds
	Given Pin toolbar to taskbar
	Given Turn on permission
	When Launch toolbar
	When turn off Keyboard backlight from Toolbar
	When turn on Keyboard backlight from Toolbar
	Then Close toolbar
	Given Reopen the window
	Given Go to input page
	Then Check Keyboard backlight toggle state in Vantage is on

@IdeaBacklight
Scenario: VAN15463_Z_RecoverDefaultDPI
	Given Change DPI to 100

