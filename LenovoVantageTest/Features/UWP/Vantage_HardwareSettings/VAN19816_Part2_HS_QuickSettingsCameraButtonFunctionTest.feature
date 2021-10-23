Feature: VAN21036_Part2_HS_QuickSettingsCameraButtonFunctionTest

Auto test case: https://jira.tc.lenovo.com/browse/VAN-21036

For manual testcase: https://jira.tc.lenovo.com/browse/VAN-19816

JIRA task: https://jira.tc.lenovo.com/browse/HAIDIAN-473

Autor：Yingying Li

@QuickSettingsOSLess @QuickSettingsOSGreat @OSLessDebug
Scenario: VAN21036_TestStep11_Check Quick Settings display the Camera as On status when turn off Camera Privacy from Toolbar
	Given Change DPI to 125
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Turn on or off the narrator 'on'
	Given Pin toolbar to taskbar
	Given Turn on permission
	When Launch toolbar
	When turn off Camera Privacy from Toolbar
	Given Go to My Device Settings page
	Given into Dashboard page
	Then The Quick Settings display the Camera as On status
	Given Turn on or off the narrator 'off'

@QuickSettingsOSLess @QuickSettingsOSGreat @OSLessDebug
Scenario: VAN21036_TestStep12_Check Quick Settings display the Camera as Off status when turn on Camera Privacy from Toolbar
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Turn on or off the narrator 'on'
	Given turn on Camera on Quick settings
	Given Pin toolbar to taskbar
	Given Turn on permission
	When Launch toolbar
	When turn on Camera Privacy from Toolbar
	Given Go to My Device Settings page
	Given into Dashboard page
	Then The Quick Settings display the Camera as Off status
	Given Turn on or off the narrator 'off'

@QuickSettingsOSLess @QuickSettingsOSGreat @OSLessDebug
Scenario: VAN21036_TestStep13_Check Quick Settings display the Camera as On status when turn off Camera Privacy from Display and Camera page
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Turn on or off the narrator 'on'
	Given Pin toolbar to taskbar
	Given Turn on permission
	When Launch toolbar
	When turn off Camera Privacy from Toolbar
	Given Go to My Device Settings page
	When turn off Camera Privacy from Display and Camera page
	Given into Dashboard page
	Then The Quick Settings display the Camera as On status
	Given Turn on or off the narrator 'off'

@QuickSettingsOSLess @QuickSettingsOSGreat @OSLessDebug
Scenario: VAN21036_TestStep14_Check Quick Settings display the Camera as Off status when turn on Camera Privacy from Display and Camera page
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Go to My Device Settings page
	When turn on Camera Privacy from Display and Camera page
	Given into Dashboard page
	Then The Quick Settings display the Camera as Off status

@QuickSettingsOSLess @QuickSettingsOSGreat @OSLessDebug
Scenario: VAN21036_TestStep15_Check Quick Settings display the Camera as Off status when turn on Camera Privacy from Display and Camera page
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given turn on Camera on Quick settings
	When Press Win and D to Switch Page
	Given The button display normal

@QuickSettingsOSLess @QuickSettingsOSGreat @OSLessDebug
Scenario: VAN21036_TestStep99_RecoverDefaultDPI
	Given Change DPI to 100
	Then Take Screen Shot VAN21036STEP99DPI100 in 21036 under HSScreenShotResult
	Given Change DPI to 200
