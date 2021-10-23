Feature: VAN3053_VFC1676_Part2_HS_QuickSettingsRegressionfunction
	Test Case： https://jira.tc.lenovo.com/browse/VAN-3053
	JIRA task:  https://jira.tc.lenovo.com/browse/HAIDIAN-2448
	Author： Pengjie Chen

Background: 
	Then support Microphone function
	Then support Camera function

@QuickSettingsOS
Scenario: VAN3053_Part2_TestStep30_Check The state of Camera microphone button should keep the value that user set before
	Given Set 'Microphone' function status is on or off 'on'
	Given Set 'Camera' function status is on or off 'off'
	Given Go to My Device Settings page
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Given Launch Vantage from Toolbar Via 'Go to Lenovo Vantage' Link
	Given Launch toolbar
	Given Close toolbar
	Then Check 'Microphone' function status is right 'on'
	Then Check 'Camera' function status is right 'off'

@QuickSettingsOS
Scenario: VAN3053_Part2_TestStep31_Check The state of Camera microphone button should keep the value that user set before
	Given Set 'Microphone' function status is on or off 'off'
	Given Set 'Camera' function status is on or off 'off'
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Given Launch Vantage from Toolbar Via 'Battery details' Link
	Given Launch toolbar
	Given Close toolbar
	Given into Dashboard page
	Then Check 'Microphone' function status is right 'off'
	Then Check 'Camera' function status is right 'off'

@QuickSettingsOS
Scenario: VAN3053_Part2_TestStep32_Check The state of Camera microphone button should keep the value that user set before
	Given Set 'Microphone' function status is on or off 'off'
	Given Set 'Camera' function status is on or off 'on'
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Given Launch Vantage from Toolbar Via 'All Settings' Link
	Given Launch toolbar
	Given Close toolbar
	Given into Dashboard page
	Then Check 'Microphone' function status is right 'off'
	Then Check 'Camera' function status is right 'on'

@QuickSettingsOS
Scenario: VAN3053_Part2_TestStep33_Check The state of Camera display is same as on toolbar and Display & Camera page
	Given Set 'Camera' function status is on or off 'on'
	Given Turn on or off the narrator 'on'
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Then Check 'Camera' function status is right within toolbar 'off'
	Given Launch toolbar
	Given Close toolbar
	Given Go to display page
	Then The Camera privacy mode is "off"
	Given Turn on or off the narrator 'off'

@QuickSettingsOS
Scenario: VAN3053_Part2_TestStep34_Check The state of Camera display is same as on toolbar and Display & Camera page
	Given Set 'Camera' function status is on or off 'off'
	Given Turn on or off the narrator 'on'
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Then Check 'Camera' function status is right within toolbar 'on'
	Given Launch toolbar
	Given Close toolbar
	Given Go to display page
	Then The Camera privacy mode is "on"
	Given Turn on or off the narrator 'off'

@QuickSettingsOS @QuickSettingsOSLe
Scenario: VAN3053_Part2_TestStep36_Check microphone permission 1 off and microphone tips display
	Given turn off the Allow access to the microphone toggle on this device
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'shown'
	Given turn on the Allow access to the microphone toggle on this device

@QuickSettingsOS @QuickSettingsOSLe
Scenario: VAN3053_Part2_TestStep37_Check microphone permission 1 on and microphone tips not display
	Given turn off the Allow access to the microphone toggle on this device
	When Click microphone access tips
	Then Jump microphone system access page
	Given turn on the Allow access to the microphone toggle on this device
	When enable microphone total access
	When enable microphone access
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check 'Microphone' Function status is correct 'enable' and tips shown or hidden 'hidden'

@QuickSettingsOS @QuickSettingsOSLe
Scenario: VAN3053_Part2_TestStep38_Check microphone permission 2 off and microphone tips display
	Given turn on the Allow access to the microphone toggle on this device
	When disable microphone total access
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'shown'

@QuickSettingsOS @QuickSettingsOSLe
Scenario: VAN3053_Part2_TestStep39_Check microphone permission 2 on and microphone tips not display
	When Click microphone access tips
	Then Jump microphone system access page
	Given turn on the Allow access to the microphone toggle on this device
	When enable microphone total access
	When enable microphone access
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check 'Microphone' Function status is correct 'enable' and tips shown or hidden 'hidden'

@QuickSettingsOS @QuickSettingsOSDebug @QuickSettingsOSLe
Scenario: VAN3053_Part2_TestStep40_Check microphone permission 3 off and microphone tips display
	Given turn on the Allow access to the microphone toggle on this device
	When enable microphone total access
	When disable microphone access
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'shown'

@QuickSettingsOS @QuickSettingsOSDebug @QuickSettingsOSLe
Scenario: VAN3053_Part2_TestStep41_Check microphone permission 3 on and microphone tips not display
	Given turn on the Allow access to the microphone toggle on this device
	When enable microphone total access
	When disable microphone access
	Given Go to My Device Settings page
	Given into Dashboard page
	When Click microphone access tips
	Then Jump microphone system access page
	Given turn on the Allow access to the microphone toggle on this device
	When enable microphone total access
	When enable microphone access
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check 'Microphone' Function status is correct 'enable' and tips shown or hidden 'hidden'

@QuickSettingsOS @QuickSettingsOSLe
Scenario: VAN3053_Part2_TestStep44_Check the Microphone button on Quick Setting display as gray un-clickable state
	When disable microphone total access
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'shown'
	Then The 'Microphone' button is clickable or unclickable 'unclickable'

@QuickSettingsOS @QuickSettingsOSLe
Scenario: VAN3053_Part2_TestStep45_Check the Microphone clickable
	When disable microphone total access
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'shown'
	Then The 'Microphone' button is clickable or unclickable 'unclickable'
	When enable microphone total access
	When enable microphone access
	Then The 'Microphone' button is clickable or unclickable 'clickable'

@QuickSettingsOS @QuickSettingsOSDebug @QuickSettingsOSLe
Scenario: VAN3053_Part2_TestStep46_Check microphone permission 3 and 4 off and microphone tips display
	Given turn on the Allow access to the microphone toggle on this device
	When enable microphone total access
	Given turn off the Allow desktop apps to access your microphone
	When disable microphone access
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'shown'

@QuickSettingsOS @QuickSettingsOSDebug @QuickSettingsOSLe
Scenario: VAN3053_Part2_TestStep47_Check microphone permission 3 and 4 on and microphone tips not display
	Given turn on the Allow access to the microphone toggle on this device
	When enable microphone total access
	Given turn off the Allow desktop apps to access your microphone
	When disable microphone access
	Given Go to My Device Settings page
	Given into Dashboard page
	When Click microphone access tips
	Then Jump microphone system access page
	Given turn on the Allow access to the microphone toggle on this device
	When enable microphone total access
	Given turn on the Allow desktop apps to access your microphone
	When enable microphone access
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check 'Microphone' Function status is correct 'enable' and tips shown or hidden 'hidden'

@QuickSettingsOSLess
Scenario: VAN3053_Part2_TestStep48_Check First launch vantage and Microphone Button should be grayout and there is no tip and link.
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Launch vantage without OOBE
	Given The select 'yes' button on 'location' permission toast pop up
	Given Click OOBE Without blue bar
	Given The microphone permission toast pop up
	Then Take Screen Shot VAN3053_Part1_TestStep48 in 3053 under HSScreenShotResult
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'hidden'
	Given The select 'yes' button on 'microphone' permission toast pop up

@QuickSettingsOSLess
Scenario: VAN3053_Part2_TestStep49_Check First launch vantage and Microphone Button should be grayout and there is tip and link
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Launch vantage without OOBE
	Given The select 'yes' button on 'location' permission toast pop up
	Given Click OOBE Without blue bar
	Given The microphone permission toast pop up
	Given The select 'no' button on 'microphone' permission toast pop up
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'shown'

@QuickSettingsOSLess
Scenario: VAN3053_Part2_TestStep50_Check First launch vantage and Microphone Button should be grayout and there is tip and link
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Launch vantage without OOBE
	Given The select 'yes' button on 'location' permission toast pop up
	Given Click OOBE Without blue bar
	Given The microphone permission toast pop up
	Given The select 'yes' button on 'microphone' permission toast pop up
	Then Check 'Microphone' Function status is correct 'enable' and tips shown or hidden 'hidden'

@QuickSettingsOS
Scenario: VAN3053_Part2_TestStep51_Check microphone permission 2 off and Microphone Button unclickable
	When disable microphone total access
	Given Go to My Device Settings page
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Given Launch Vantage from Toolbar Via 'Go to Lenovo Vantage' Link
	Then The 'Microphone' button is clickable or unclickable 'unclickable'

@QuickSettingsOS
Scenario: VAN3053_Part2_TestStep52_Check microphone permission 2 on and Microphone status display same as with Toolbar and Audio. 
	When enable microphone total access
	When enable microphone access
	Given Set 'Microphone' function status is on or off 'on'
	Given Go to My Device Settings page
	Given Turn on or off the narrator 'on'
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Then Check 'Microphone' function status is right within toolbar 'on'
	Given Launch Vantage from Toolbar Via 'Go to Lenovo Vantage' Link
	Then Check 'Microphone' function status is right 'on'
	Given Turn on or off the narrator 'off'
	Given Launch toolbar
	Given Close toolbar
	Given go to Audio page
	Then Check 'Microphone' function status is right within Audio page 'on'
	 
@QuickSettingsOS
Scenario: VAN3053_Part2_TestStep53_Check microphone permission 2 off and Microphone Button unclickable
	When disable microphone total access
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Given Launch Vantage from Toolbar Via 'Battery details' Link
	Given Launch toolbar
	Given Close toolbar
	Given into Dashboard page
	Then The 'Microphone' button is clickable or unclickable 'unclickable'
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'shown'

@QuickSettingsOS
Scenario: VAN3053_Part2_TestStep54_Check microphone permission 2 on and Microphone status display same as with Toolbar and Audio
	When enable microphone total access
	When enable microphone access
	Given Set 'Microphone' function status is on or off 'off'
	Given Turn on or off the narrator 'on'
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Then Check 'Microphone' function status is right within toolbar 'off'
	Given Launch Vantage from Toolbar Via 'Battery details' Link
	Given Launch toolbar
	Given Close toolbar
	Given into Dashboard page
	Then Check 'Microphone' function status is right 'off'
	Given Turn on or off the narrator 'off'
	Given go to Audio page
	Then Check 'Microphone' function status is right within Audio page 'off'

@QuickSettingsOSLess @QuickSettingsOSDebug
Scenario: VAN3053_Part2_TestStep57_Check microphone permission 2 on and Microphone status display same as with Toolbar and Audio
	When enable microphone total access
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Given Launch Vantage from Toolbar Via 'All Settings OOBE' Link
	Given Launch toolbar
	Given Close toolbar
	Given Launch vantage without OOBE
	Given The select 'yes' button on 'location' permission toast pop up
	Given Click OOBE Without blue bar
	Given The microphone permission toast pop up
	Given The select 'no' button on 'microphone' permission toast pop up
	Given click back button
	Then The 'Microphone' button is clickable or unclickable 'unclickable'
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'shown'

@QuickSettingsOSLess @QuickSettingsOSDebug
Scenario: VAN3053_Part2_TestStep58_Check microphone permission 2 on and Microphone status display same as with Toolbar and Audio
	When enable microphone total access
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Given Launch Vantage from Toolbar Via 'All Settings OOBE' Link
	Given Launch toolbar
	Given Close toolbar
	Given Launch vantage without OOBE
	Given The select 'yes' button on 'location' permission toast pop up
	Given Click OOBE Without blue bar
	Given The microphone permission toast pop up
	Given The select 'yes' button on 'microphone' permission toast pop up
	Given into Dashboard page
	Then The 'Microphone' button is clickable or unclickable 'clickable'
	Then Check 'Microphone' Function status is correct 'enable' and tips shown or hidden 'hidden'

@QuickSettingsOS
Scenario: VAN3053_Part2_TestStep67_Check Resize the window and check UI 
    When Go to More Settings section
	Then Take Screen Shot VAN3053_Part1_TestStep67_01 in 3053 under HSScreenShotResult
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 1400  | 1050   |           |            |
	When Go to More Settings section
	Then Take Screen Shot VAN3053_Part1_TestStep67_02 in 3053 under HSScreenShotResult
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 500   | 500    |           |            |
	When Go to More Settings section
	Then Take Screen Shot VAN3053_Part1_TestStep67_03 in 3053 under HSScreenShotResult

@QuickSettingsOSResolution @QuickSettingsOSDebug
Scenario: VAN3053_Part2_TestStep68_Check change resolution and check UI
	Given change resolution 3840 to 2160
	When close lenovo vantage
	When Launch Vantage
	Given Waiting 10 seconds
	Then Take Screen Shot VAN3053_Part1_TestStep68_01 in 3053 under HSScreenShotResult
	Given change resolution 2560 to 1440
	When close lenovo vantage
	When Launch Vantage
	Given Waiting 10 seconds
	Then Take Screen Shot VAN3053_Part1_TestStep68_02 in 3053 under HSScreenShotResult
	Given change resolution 1366 to 768
	When close lenovo vantage
	When Launch Vantage
	Given Waiting 10 seconds
	Then Take Screen Shot VAN3053_Part1_TestStep68_03 in 3053 under HSScreenShotResult
	Given change resolution 1920 to 1080
	When close lenovo vantage
	When Launch Vantage
	Given Waiting 10 seconds
	Then Take Screen Shot VAN3053_Part1_TestStep68_04 in 3053 under HSScreenShotResult

@QuickSettingsOSGreat
Scenario: VAN3053_Part2_TestStep81_Check Microphone permission toast does not pop up
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Launch Vantage
	Given The microphone permission toast pop up
	When Waiting 20 seconds
	Given The select 'yes' button on 'hidden' permission toast pop up
	Given The select 'no' button on 'hidden' permission toast pop up
	Then Take Screen Shot VAN3053_Part1_TestStep81 in 3053 under HSScreenShotResult

@QuickSettingsOSGreat
Scenario: VAN3053_Part2_TestStep82_Check Camera permission toast does not pop up
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Launch Vantage
	Given The microphone permission toast pop up
	Given Go to display page
	When Waiting 20 seconds
	Given The select 'yes' button on 'hidden' permission toast pop up
	Given The select 'no' button on 'hidden' permission toast pop up
	Then Take Screen Shot VAN3053_Part1_TestStep82 in 3053 under HSScreenShotResult
