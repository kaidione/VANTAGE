Feature: VAN3053_VFC1676_Part1_HS_QuickSettingsRegressionfunction
	Test Case： https://jira.tc.lenovo.com/browse/VAN-3053
	JIRA task:  https://jira.tc.lenovo.com/browse/HAIDIAN-2384
	Author： Pengjie Chen
	
#@MicroFrontendTest
#Scenario: VAN3053_Check Micro Frontend Test Switch Page
#	Given Go to My Device Settings page
#	Given into Dashboard page
#	Then Switch '10' times Settings To Dashboard

@QuickSettingsOS @QuickSettingsOSLe
Scenario: VAN3053_Part1_TestStep01_Check title name display is Quick settings
	Given Go to My Device Settings page
	Given into Dashboard page
	Then The Quick Settings title name show 'Quick settings'
	Then Take Screen Shot VAN3053_Part1_TestStep01 in 3053 under HSScreenShotResult

@QuickSettingsOnlyMicrophoneUpdate
Scenario: VAN3053_Part1_TestStep03_Check Quick settings UI Only Support Microphone Update function
	Given Set 'Integrated Camera' drive state to enable or disable 'disable' via HardwareId 'default'
	When close lenovo vantage
	When Launch Vantage
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Take Screen Shot VAN3053_Part1_TestStep03 in 3053 under HSScreenShotResult
	Given Set 'Integrated Camera' drive state to enable or disable 'enable' via HardwareId 'default'

@QuickSettingsOS
Scenario: VAN3053_Part1_TestStep04_Support Microphone, Camera and Update function
	Given Go to My Device Settings page
	Given into Dashboard page
	Then support Microphone function
	Then support Camera function
	Then "support" Update function

@QuickSettingsOS
Scenario: VAN3053_Part1_TestStep05_Check the Update button display on Quick Settings Widget
	Given Go to My Device Settings page
	Given into Dashboard page
	Then "support" Update function

@QuickSettingsOS
Scenario: VAN3053_Part1_TestStep06_Check the System Update page and automatically trigger on Check for update
	Given Go to My Device Settings page
	Given into Dashboard page
	When click Update button
	Then check Update header title
	Then check completion degree

@QuickSettingsOS
Scenario: VAN3053_Part1_TestStep07_Check the Update button on Quick Settings widget display as active state
	Given Go to My Device Settings page
	Given into Dashboard page
	Given click Update button
	Given turn "on" critical updates
	Given turn "off" recommended updates
	When into Dashboard page
	Then "support" Update function

@QuickSettingsOS
Scenario: VAN3053_Part1_TestStep08_Check the Update button on Quick Settings widget display as active state
	Given Go to My Device Settings page
	Given into Dashboard page
	Given click Update button
	Given turn "on" critical updates
	Given turn "on" recommended updates
	When into Dashboard page
	Then "support" Update function

@QuickSettingsOS
Scenario: VAN3053_Part1_TestStep09_Check the Update button on Quick Settings widget display as active state
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Given Launch Vantage from Toolbar Via 'All Settings' Link
	Given into Dashboard page
	Given click Update button
	Given turn "off" critical updates
	Given turn "off" recommended updates
	When into Dashboard page
	Then "support" Update function

@QuickSettingsOS
Scenario: VAN3053_Part1_TestStep10_Check the System Update page and automatically trigger on Check for update
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Given Launch Vantage from Toolbar Via 'All Settings' Link
	Given into Dashboard page
	Given click Update button
	Then check Update header title
	Then check completion degree

@QuickSettingsOSLess
Scenario: VAN3053_Part1_TestStep11_Check camera displays as greyed out state and should show the tip 
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Launch vantage without OOBE
	Given The select 'yes' button on 'location' permission toast pop up
	Given The microphone permission toast pop up
	Then Take Screen Shot VAN3053_Part1_TestStep11 in 3053 under HSScreenShotResult
	Then Check 'Camera' Function status is correct 'disable' and tips shown or hidden 'shown'
	Given The select 'yes' button on 'microphone' permission toast pop up

@QuickSettingsOSLess
Scenario: VAN3053_Part1_TestStep12_Check camera button is unclickable.
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Launch vantage without OOBE
	Given The select 'yes' button on 'location' permission toast pop up
	Given Click OOBE Without blue bar
	Given The microphone permission toast pop up
	Given The select 'yes' button on 'microphone' permission toast pop up
	Then The 'Camera' button is clickable or unclickable 'unclickable'

@QuickSettingsOS @QuickSettingsOSLe
Scenario: VAN3053_Part1_TestStep13_Check camera button shows correctly and microphone button is greyed out and there display a note
	Given Launch toolbar
	Given Close toolbar
	Given disable microphone total access
	Given enable camera total access
	Given enable camera access
	Given turn on the Allow desktop apps to access your camera
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'shown'
	Then Check 'Camera' Function status is correct 'enable' and tips shown or hidden 'hidden'

@QuickSettingsOS @QuickSettingsOSLe
Scenario: VAN3053_Part1_TestStep14_Check Click microphone access tips and Jump to the microphone privacy page in system settings
	Given disable microphone total access
	Given enable camera total access
	Given enable camera access
	Given turn on the Allow desktop apps to access your camera
	When Click microphone access tips
	Then Jump microphone system access page

@QuickSettingsOS @QuickSettingsOSLe
Scenario: VAN3053_Part1_TestStep15_Check Microphone button shows correctly and Camera button is greyed out and there display a note
	Given enable microphone total access
	Given disable camera total access
	Then Check 'Camera' Function status is correct 'disable' and tips shown or hidden 'shown'
	Then Check 'Microphone' Function status is correct 'enable' and tips shown or hidden 'hidden'

@QuickSettingsOS
Scenario: VAN3053_Part1_TestStep16_Check Click camera access tips and Jump to the camera privacy page in system settings
	Given enable microphone total access
	Given disable camera total access
	When Click camera access tips
	Then Jump camera system access page

@QuickSettingsOS @QuickSettingsOSLe @SmokeQuickSettingsOS
Scenario: VAN3053_Part1_TestStep17_Check both Microphone Camera button is greyed out and there display a note
	Given disable microphone total access
	Given disable camera total access
	Then Check 'Camera' Function status is correct 'disable' and tips shown or hidden 'shown'
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'shown'

@QuickSettingsOS
Scenario: VAN3053_Part1_TestStep18_Check Click camera access tips and Jump to the camera privacy page in system settings
	Given disable microphone total access
	Given disable camera total access
	When Click camera access tips
	Then Jump camera system access page

@QuickSettingsOS @QuickSettingsOSLe
Scenario: VAN3053_Part1_TestStep19_Check Click microphone access tips and Jump to the microphone privacy page in system settings
	Given disable microphone total access
	Given disable camera total access
	When Click microphone access tips
	Then Jump microphone system access page

@QuickSettingsOS @QuickSettingsOSLe
Scenario: VAN3053_Part1_TestStep20_Check the Camera button is enabled in the right status and the message disappear
	Given enable camera total access
	Given turn off the Allow apps to access your camera
	Then Check 'Camera' Function status is correct 'disable' and tips shown or hidden 'shown'
	Given turn on the Allow apps to access your camera
	When wait 30 seconds
	Then Check 'Camera' Function status is correct 'enable' and tips shown or hidden 'hidden'

@QuickSettingsOS @QuickSettingsOSLe
Scenario: VAN3053_Part1_TestStep21_Check microphone button is enabled in the right status and the message disappear
	Given enable microphone total access
	Given turn off the Allow apps to access your microphone
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'shown'
	Given turn on the Allow apps to access your microphone
	When wait 30 seconds
	Then Check 'Microphone' Function status is correct 'enable' and tips shown or hidden 'hidden'

@QuickSettingsOSLess
Scenario: VAN3053_Part1_TestStep22_Check camera button is enabled in the right status and the message disappear
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Launch vantage without OOBE
	Given The select 'yes' button on 'location' permission toast pop up
	Given Click OOBE Without blue bar
	Given The microphone permission toast pop up
	Given The select 'yes' button on 'microphone' permission toast pop up
	Then Check 'Camera' Function status is correct 'disable' and tips shown or hidden 'shown'
	Given Go to display page
	Given The select 'yes' button on 'camera' permission toast pop up
	Given into Dashboard page
	Then Check 'Camera' Function status is correct 'enable' and tips shown or hidden 'hidden'

@QuickSettingsOSLess
Scenario: VAN3053_Part1_TestStep23_Check camera button is disabled in the right status and the message display
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Launch vantage without OOBE
	Given The select 'yes' button on 'location' permission toast pop up
	Given Click OOBE Without blue bar
	Given The microphone permission toast pop up
	Given The select 'yes' button on 'microphone' permission toast pop up
	Then Check 'Camera' Function status is correct 'disable' and tips shown or hidden 'shown'
	Given Go to display page
	Given The select 'no' button on 'camera' permission toast pop up
	Given into Dashboard page
	Then Check 'Camera' Function status is correct 'disable' and tips shown or hidden 'shown'

@QuickSettingsOS @QuickSettingsOSDebug
Scenario: VAN3053_Part1_TestStep24_Check camera button and the message disappear
	Given enable camera total access
	Given enable camera access
	Given Set 'Integrated Camera' drive state to enable or disable 'disable' via HardwareId 'default'
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check 'Camera not exist' Function status is correct 'null' and tips shown or hidden 'null'

@QuickSettingsOS @QuickSettingsOSDebug
Scenario: VAN3053_Part1_TestStep25_Check camera button is disabled in the right status and the message display
	Given disable camera access
	Given Set 'Integrated Camera' drive state to enable or disable 'disable' via HardwareId 'default'
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check 'Camera' Function status is correct 'disable' and tips shown or hidden 'shown'

@QuickSettingsNoCamera
Scenario: VAN3053_Part1_TestStep26_Check camera not display on not camera driver machine
	Given enable camera total access
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Take Screen Shot VAN3053_Part1_TestStep26_01 in 3053 under HSScreenShotResult
	Given Go to display page
	Then Take Screen Shot VAN3053_Part1_TestStep26_02 in 3053 under HSScreenShotResult

@QuickSettingsOS @QuickSettingsOSDebug
Scenario: VAN3053_Part1_TestStep27_Check microphone button and the message disappear
	Given Set 'Integrated Camera' drive state to enable or disable 'enable' via HardwareId 'default'
	Given Set 'Intel® Smart Sound Technology (Intel® SST)' drive state to enable or disable 'disable' via HardwareId 'default'
	Given enable microphone total access
	Given enable microphone access
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check 'Microphone not exist' Function status is correct 'null' and tips shown or hidden 'null'

@QuickSettingsNoMicrophone
Scenario: VAN3053_Part1_TestStep28_Check microphone not display on not microphone driver machine
	Given enable microphone total access
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Take Screen Shot VAN3053_Part1_TestStep29 in 3053 under HSScreenShotResult

@QuickSettingsNoCameraMicrophone
Scenario: VAN3053_Part1_TestStep29_Check quick settings not display on not microphone camera driver machine
	Given enable microphone total access
	Given enable camera total access
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Take Screen Shot VAN3053_Part1_TestStep30 in 3053 under HSScreenShotResult

@QuickSettingsOS @QuickSettingsOSLe @SmokeQuickSettingsOS
Scenario: VAN3053_Part1_TestStep30_Check Restet access
	Given Set 'Integrated Camera' drive state to enable or disable 'enable' via HardwareId 'default'
	Given Set 'Intel® Smart Sound Technology (Intel® SST)' drive state to enable or disable 'enable' via HardwareId 'default'
	When enable camera total access
	When enable microphone total access
	When enable camera access
	When enable microphone access
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Take Screen Shot VAN3053_Reset_Acess in 3053 under HSScreenShotResult
