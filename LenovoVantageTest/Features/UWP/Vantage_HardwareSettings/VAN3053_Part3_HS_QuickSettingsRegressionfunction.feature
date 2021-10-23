Feature: VAN3053_VFC1676_Part3_HS_QuickSettingsRegressionfunction
	Test Case： https://jira.tc.lenovo.com/browse/VAN-3053
	JIRA task:  https://jira.tc.lenovo.com/browse/HAIDIAN-2384
	Author：Jinxin Li

Background: 
	Given Turn on or off the narrator 'off'

@QuickSettingsOS
Scenario: VAN3053_Part3_TestStep55_Check Restet access
	When disable microphone total access
	Given Install the Lenovo Vantage Without Launch Vantage
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Given Launch Vantage from Toolbar Via 'All Settings OOBE' Link
	Given Launch toolbar
	Given Close toolbar
	Given click OOBE
	Given Maxmize Vantage
	When into Dashboard page
	Then Judge microphone button cannot click

@QuickSettingsOS
Scenario: VAN3053_Part3_TestStep56_Check Restet access
	Given Turn on or off the narrator 'on'
	When enable microphone total access
	When enable microphone access
	Given Go to audio section
	When Jump to microphone
	Given Launch toolbar
	When Get microphone status from toolbar
	Given Launch Vantage from Toolbar Click 'All Settings' Link
	Given Launch toolbar
	Given Close toolbar
	Given Go to audio section
	When Jump to microphone
	Then The microphone button displays same as with Vantage

@QuickSettingsOS
Scenario: VAN3053_Part3_TestStep59_Check
	When enable microphone total access
	When enable microphone access
	Given Turn on or off the narrator 'on'
	Given Go to audio section
	When Jump to microphone
	When Set microphone 'on' in Audio page
	Given Launch toolbar
	When Turn off microphone from toolbar
	When into Dashboard page
	Then The Microphone button on dashboard display 'off' status

@QuickSettingsOS
Scenario: VAN3053_Part3_TestStep60_Check
	Given Turn on or off the narrator 'on'
	Given Launch toolbar
	When Turn off microphone from toolbar
	Given Go to audio section
	When Jump to microphone
	When Set microphone 'on' in Audio page
	When into Dashboard page
	Then The Microphone button on dashboard display 'on' status

@QuickSettingsOS
Scenario: VAN3053_Part3_TestStep61_Check
	When enable microphone total access
	When enable microphone access
	When into Dashboard page
	Given Set 'Microphone' function status is on or off 'on'
	Given Turn on or off the narrator 'on'
	Given Launch toolbar
	When Get microphone 'on' state from toolbar
	Given Go to audio section
	When Jump to microphone
	When Get microphone 'on' in Audio page
	When into Dashboard page
	Then The Microphone button on dashboard display 'on' status

@QuickSettingsOS
Scenario: VAN3053_Part3_TestStep62_Check
	When enable microphone total access
	When enable microphone access
	When into Dashboard page
	Given Set 'Microphone' function status is on or off 'off'
	Given Turn on or off the narrator 'on'
	Given Launch toolbar
	When Get microphone 'off' state from toolbar
	Given Go to audio section
	When Jump to microphone
	When Get microphone 'off' in Audio page
	When into Dashboard page
	Then The Microphone button on dashboard display 'off' status

@QuickSettingsOS @QuickSettingsOSLe
Scenario: VAN3053_Part3_TestStep64_Check
	When into Dashboard page
	Then The Text Display 'MORE SETTINGS' on Dashboard

@QuickSettingsOS @QuickSettingsOSLe
Scenario: VAN3053_Part4_TestStep65_Jump to the My Device Settings page
	Given Go to My Device Settings page
	Given into Dashboard page
	When Click My Device Settings Link on dashboard
	Then jump to the My Device Settings page

@QuickSettingsOS @QuickSettingsOSLe
Scenario: VAN3053_Part3_TestStep66_Jump to the My Device Settings page
	Given Go to My Device Settings page
	Given into Dashboard page
	When Double click My Device Settings Link on dashboard
	Then jump to the My Device Settings page

@QuickSettingsOS @QuickSettingsOSLe
Scenario: VAN3053_Part3_TestStep69_Hover the icon and button
	Given disable microphone total access
	Given disable camera total access
	Given Close Vantage
	Given Launch Vantage
	Given Go to audio section
	When Jump to microphone
	Then Take Screen Shot VAN3053_Part4_TestStep87_01 in 3053 under HSScreenShotResult
	Given Go to DisplayCamera page
	Given Go to Camera Blur Panel
	Then Take Screen Shot VAN3053_Part4_TestStep87_02 in 3053 under HSScreenShotResult

@QuickSettingsOSInGamingMachine
Scenario: VAN3053_Part3_TestStep75_Hover the icon and button
	Given Machine is Gaming
	Then The Machine not display the Quick Settings Widget