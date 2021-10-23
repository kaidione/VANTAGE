Feature: VFC1676_QuickSettings
	Test Case： https://jira.tc.lenovo.com/browse/VFC-1676
	Author: DaQi Fang

@QuickSettingsLe
Scenario: VFC1676_Step01 Check QuickSettings text
	When into Dashboard page
	Then The Quick Settings title name show 'Quick settings'
	Then The Text Display 'MORE SETTINGS' on Dashboard
	Then Take Screen Shot 01QuickSettingsLe in VFC1676 under HSScreenShotResult
	Given disable microphone total access
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'shown'
	Given enable microphone total access

@QuickSettingsLe
Scenario: VFC1676_Step02 Check QuickSettings Icon
	When into Dashboard page
	Then Take Screen Shot 02QuickSettingsLeIcon in VFC1676 under HSScreenShotResult

@QuickSettingsLe
Scenario: VFC1676_Step03 Check the background display under the toggle on/off/disabled state.
	When into Dashboard page
	Given enable microphone total access
	Given enable camera total access
	Given Set 'Camera' function status is on or off 'on'
	Given Set 'Microphone' function status is on or off 'off'
	Then Take Screen Shot 03MicoffCamOn in VFC1676 under HSScreenShotResult
	Given disable microphone total access
	Then Take Screen Shot 03DisMic in VFC1676 under HSScreenShotResult
	Given enable microphone total access

@QuickSettingsLe
Scenario: VFC1676_Step04 Change Dpi and check element
	When into Dashboard page
	Given Send "^{+}" Keys "6" times
	When Scrool 1 times screen 100
	Given wait 2 seconds
	Then Take Screen Shot 04ScrollBig in VFC1676 under HSScreenShotResult
	Given Send "^{_}" Keys "12" times
	Given wait 2 seconds
	Then Take Screen Shot 04ScrollSmall in VFC1676 under HSScreenShotResult
	Given Send "^{+}" Keys "6" times
	Given Change DPI to 100
	Then Take Screen Shot 04Dpi100 in VFC1676 under HSScreenShotResult
	Given Change DPI to 200
	
@QuickSettingsLe
Scenario: VFC1676_Step05 Hover on
	Given enable microphone total access
	Given enable camera total access
	When into Dashboard page
	When Hover the mouse on "$.Dashboard.QuickSettingsCameraToggle"
	Then Take Screen Shot 05HoverCamHand in VFC1676 under HSScreenShotResult
	When Hover the mouse on "$.Dashboard.QuickSettingsMicrphoneToggle"
	Then Take Screen Shot 05HoverMicHand in VFC1676 under HSScreenShotResult
	When Hover the mouse on "$.Dashboard.QuickSettings"
	Then Take Screen Shot 05HoverNothing in VFC1676 under HSScreenShotResult

@QuickSettingsLe
Scenario: VFC1676_Step07 Doesn't show the "Update" feature.
	When into Dashboard page
	Then "nosupport" Update function

@QuickSettingsLe
Scenario: VFC1676_Step08 Stay in oobe
	Given Uninstall the lenovo vatage
	Given Install the Lenovo Vantage Without Launch Vantage
	Given Launch Vantage
	Given wait 180 seconds
	Then Take Screen Shot 08QuickSettingsLe in VFC1676 under HSScreenShotResult
	Given Uninstall the lenovo vatage

@QuickSettingsLeLowVersion
Scenario: VFC1676_Step09 Os version lower than 18363 check alert
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Launch Vantage
	Given wait 120 seconds
	Then Find the Mic access button "NotNull"

@QuickSettingsLeLowVersion
Scenario: VFC1676_Step10 Os version lower than 18363 check alert null
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Launch Vantage
	Then Click Mic access button
	Then Find the Mic access button "Null"

@QuickSettingsLe
Scenario: VFC1676_Step11 Os version lower than 18363 check alert
	Given Install Vantage
	Given disable microphone total access
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'shown'
	Given enable microphone total access

@QuickSettingsLe
Scenario: VFC1676_Step12 uninstall and disable mic and check link and tip
	Given Uninstall the lenovo vatage
	Given Install the Lenovo Vantage Without Launch Vantage
	Given disable microphone total access
	Given Launch Vantage
	Given Click OOBE Without blue bar
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'shown'
	Given enable microphone total access

@QuickSettingsLe
Scenario: VFC1676_Step13 jump to system access page
	Given Uninstall the lenovo vatage
	Given Install the Lenovo Vantage Without Launch Vantage
	Given disable microphone total access
	Given Launch Vantage
	Given Click OOBE Without blue bar
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'shown'
	When Click microphone access tips
	Then Jump microphone system access page
	Given enable microphone total access
	Given Uninstall the lenovo vatage
	Given Install Vantage

@QuickSettingsLeLowVersion
Scenario: VFC1676_Step14_31 Os version lower than 18363 check alert null
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Launch Vantage
	Then wait 120 seconds
	Then Take Screen Shot 14QuickSettingsLe in VFC1676 under HSScreenShotResult

@QuickSettingsLeLowVersion
Scenario: VFC1676_Step15 Os version lower than 18363 check alert null
	Given Uninstall the lenovo vatage
	Given Install Vantage
	Then Check 'Microphone' Function status is correct 'enable' and tips shown or hidden 'hidden'

@QuickSettingsLeLowVersion
Scenario: VFC1676_Step16 Os version lower than 18363 check alert null
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Launch Vantage
	Then wait 120 seconds
	Then Click Mic access no button
	Then Take Screen Shot 16QuickSettingsLe in VFC1676 under HSScreenShotResult
	Given Uninstall the lenovo vatage
	Given Install Vantage
	
@QuickSettingsLe
Scenario: VFC1676_Step17 check mir toggle on
	Given enable microphone total access
	Given Set 'Microphone' function status is on or off 'on'
	Then Check 'Microphone' function status is right 'on'

@QuickSettingsLe
Scenario: VFC1676_Step18 check mir toggle on and check link and tip
	Given enable microphone total access 
	Given Set 'Microphone' function status is on or off 'on'
	Then Check 'Microphone' function status is right 'on'
	Given disable microphone total access
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'shown'

@QuickSettingsLe
Scenario: VFC1676_Step19 check mir toggle off
	Given enable microphone total access
	Given Set 'Microphone' function status is on or off 'off'
	Then Check 'Microphone' function status is right 'off'

@QuickSettingsLe
Scenario: VFC1676_Step20 close mic in dashboard and check audio
	Given enable microphone total access
	Given Set 'Microphone' function status is on or off 'off'
	Given go to Audio page
	Then Check 'Microphone' function status is right within Audio page 'off'
	When into Dashboard page
	Given Set 'Microphone' function status is on or off 'on'
	Given go to Audio page
	Then Check 'Microphone' function status is right within Audio page 'on'

@QuickSettingsLe
Scenario: VFC1676_Step21 close mic in audio and check dashboard
	Given enable microphone total access
	Given go to Audio page
	When Set microphone 'on' in Audio page
	When into Dashboard page
	Then Check 'Microphone' function status is right 'on'
	Given go to Audio page
	When Set microphone 'off' in Audio page
	When into Dashboard page
	Then Check 'Microphone' function status is right 'off'

@QuickSettingsLe
Scenario: VFC1676_Step23 disable mic access and check
	When disable microphone access
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'shown'
	When enable microphone access

@QuickSettingsLe
Scenario: VFC1676_Step26 disable mic access and check
	Given "Disable" Microphone driver
	Given ReLaunch Lenovo Vantage
	Then Quicksettings Mic is "hidden"
	Given "Enable" Microphone driver
	Given ReLaunch Lenovo Vantage
	Then Quicksettings Mic is "show"

@QuickSettingsLe
Scenario: VFC1676_Step28 disable camera access and check quicksettings
	Given disable camera total access
	Then Check 'Camera' Function status is correct 'disable' and tips shown or hidden 'shown'
	Given enable camera total access

@QuickSettingsLe
Scenario: VFC1676_Step29 disable camera access and check quicksettings
	Given enable camera total access
	Then Check 'Camera' Function status is correct 'enable' and tips shown or hidden 'hidden'
	Given disable camera total access
	Given go to Audio page
	When into Dashboard page
	Then Check 'Camera' Function status is correct 'disable' and tips shown or hidden 'show'
	Given enable camera total access

@QuickSettingsLe
Scenario: VFC1676_Step30 first lunch vantage stayoobe check camera
	Given Uninstall the lenovo vatage
	Given Install the Lenovo Vantage Without Launch Vantage
	Given enable camera total access
	Given turn off Lenovo Vantage permission for Camera from system settings
	Given Launch Vantage
	Given wait 100 seconds
	Then Take Screen Shot 30Stayinoobe in VFC1676 under HSScreenShotResult
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Uninstall the lenovo vatage
	Given Install Vantage

@QuickSettingsLe
Scenario: VFC1676_Step32 enable camera access turn on camera disable access and check camera
	Given enable camera total access
	Given Set 'Camera' function status is on or off 'on'
	Given disable camera total access
	Then Check 'Camera' Function status is correct 'disable' and tips shown or hidden 'show'
	Given enable camera total access

@QuickSettingsLe
Scenario: VFC1676_Step33 turn on camera and check
	Given enable camera total access
	Given Set 'Camera' function status is on or off 'on'
	Then Check 'Camera' function status is right 'on'

@QuickSettingsLe
Scenario: VFC1676_Step34 turn off camera and check
	Given enable camera total access
	Given Set 'Camera' function status is on or off 'off'
	Then Check 'Camera' function status is right 'off'

@QuickSettingsLe
Scenario: VFC1676_Step35 check state quicksettinmgs with displaypage
	Given enable camera total access
	Given Set 'Camera' function status is on or off 'off'
	Given Go to display page
	Given Click Camera Link
	Then The camera value in display page is "on"
	When into Dashboard page
	Given Set 'Camera' function status is on or off 'on'
	Given Go to display page
	Given Click Camera Link
	Then The camera value in display page is "off"

@QuickSettingsLe
Scenario: VFC1676_Step36 check state displaypage with quicksettings
	Given enable camera total access
	Given Go to display page
	Given Click Camera Link
	Given Turn on Camera Privacy
	When into Dashboard page
	Then Check 'Camera' function status is right 'off'
	Given Go to display page
	Given Click Camera Link
	Given Turn off Camera Privacy
	When into Dashboard page
	Then Check 'Camera' function status is right 'on'

@QuickSettingsLe
Scenario: VFC1676_Step37 disable camera access and check mode
	Given disable camera total access
	Then Check 'Camera' Function status is correct 'disable' and tips shown or hidden 'show'
	Given enable camera total access

@QuickSettingsLe
Scenario: VFC1676_Step38 disable camera access and check mode
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given turn on the Allow desktop apps to access your camera
	Then Check 'Camera' Function status is correct 'enable' and tips shown or hidden 'hidden'
	Then Get quicksettings camera state
	Given Go to display page
	Given Click Camera Link
	Then Check camera in quick and display

@QuickSettingsLe
Scenario: VFC1676_Step41 disable camera access and mic access 
	Given turn off the Allow desktop apps to access your camera
	Given turn off Lenovo Vantage permission for Camera from system settings
	Given turn off the Allow apps to access your camera
	Given turn off the Allow access to the camera toggle on this device
	Given turn off the Allow desktop apps to access your microphone
	Given turn off Lenovo Vantage permission for Microphonefrom system settings
	Given turn off the Allow apps to access your microphone
	Given turn off the Allow access to the microphone toggle on this device
	Then Check 'Camera' Function status is correct 'disable' and tips shown or hidden 'show'
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'shown'
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given turn on the Allow desktop apps to access your camera
	Given turn on the Allow access to the microphone toggle on this device
	Given turn on the Allow apps to access your microphone
	Given turn on Lenovo Vantage permission for Microphonefrom system settings
	Given turn on the Allow desktop apps to access your microphone
	
@QuickSettingsLe
Scenario: VFC1676_Step42 
	Given turn off the Allow desktop apps to access your camera
	Given turn off Lenovo Vantage permission for Camera from system settings
	Given turn off the Allow apps to access your camera
	Given turn off the Allow access to the camera toggle on this device
	Given turn off the Allow desktop apps to access your microphone
	Given turn off Lenovo Vantage permission for Microphonefrom system settings
	Given turn off the Allow apps to access your microphone
	Given turn off the Allow access to the microphone toggle on this device
	Then Check 'Camera' Function status is correct 'disable' and tips shown or hidden 'show'
	Then Check 'Microphone' Function status is correct 'disable' and tips shown or hidden 'shown'
	When Click microphone access tips
	Then Jump microphone system access page
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given turn on the Allow desktop apps to access your camera
	Given turn on the Allow access to the microphone toggle on this device
	Given turn on the Allow apps to access your microphone
	Given turn on Lenovo Vantage permission for Microphonefrom system settings
	Given turn on the Allow desktop apps to access your microphone

@QuickSettingsLe
Scenario: VFC1676_Step44 
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given turn on the Allow desktop apps to access your camera
	Given turn on the Allow access to the microphone toggle on this device
	Given turn on the Allow apps to access your microphone
	Given turn on Lenovo Vantage permission for Microphonefrom system settings
	Given turn on the Allow desktop apps to access your microphone
	When Click My Device Settings Link on dashboard
	Then jump to the My Device Settings page