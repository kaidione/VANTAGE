Feature: VAN21036_Part1_HS_QuickSettingsCameraButtonFunctionTest

Auto test case: https://jira.tc.lenovo.com/browse/VAN-21036

For manual testcase: https://jira.tc.lenovo.com/browse/VAN-19816

JIRA task: https://jira.tc.lenovo.com/browse/HAIDIAN-473

Autor：Yingying Li

@QuickSettingsOSGreat @QuickSettingsOSLess @OSLessDebug
Scenario: VAN21036_TestStep01_Check Quick Settings Not display the Camera button when turn off the Allow access to the camera on this device
	Given turn off the Allow access to the camera toggle on this device
	Given Install the Lenovo Vantage
	Given Launch Lenovo Vantage
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check Camera button not show under Quick Settings

@QuickSettingsOSGreat @QuickSettingsOSLess @OSLessDebug
Scenario: VAN21036_TestStep02_Check Quick Settings Not display the Camera button when turn off the Allow apps to access your camera
	Given turn on the Allow access to the camera toggle on this device
	Given turn off the Allow apps to access your camera
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check Camera button not show under Quick Settings

@QuickSettingsOSGreat @QuickSettingsOSLess @OSLessDebug
Scenario: VAN21036_TestStep03_Check Quick Settings Not display the Camera button when turn off the Allow desktop apps to access your camera
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn off the Allow desktop apps to access your camera
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check Camera button not show under Quick Settings

@QuickSettingsOSGreat @QuickSettingsOSLess @OSLessDebug
Scenario: VAN21036_TestStep04_Check Quick Settings display the Camera button when turn on four type of access
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Go to My Device Settings page
	Given into Dashboard page
	Then The Quick Settings display the Camera button

@QuickSettingsOSGreat @QuickSettingsOSLess @OSLessDebug
Scenario: VAN21036_TestStep05_Check the Camera button display gray and Not display on or off text when Lenovo Vantage permission for Camera and Microphone from system settings
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn off Lenovo Vantage permission for Camera from system settings
	Given turn off Lenovo Vantage permission for Microphonefrom system settings
	Given Install Vantage
	Then Take Screen Shot 21036_Part1_Step5CameraButtonDisplayGray in 21036 under HSScreenShotResult	

@QuickSettingsOSLess @OSLessDebug
Scenario: VAN21036_TestStep06_Check Quick Settings Not display the Camera button when Lenovo Vantage permission for Camera and Microphone from system settings
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn off Lenovo Vantage permission for Camera from system settings
	Given turn off Lenovo Vantage permission for Microphonefrom system settings
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check Camera button not show under Quick Settings
	Given Install the Lenovo Vantage
	Given Launch Lenovo Vantage
	Then microphone access confirm window exists

@QuickSettingsOSLess @QuickSettingsOSGreat @OSLessDebug
Scenario: VAN21036_TestStep07_Check Quick Settings Not display the Camera button when turn off Lenovo Vantage permission for Camera from system settings
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn off Lenovo Vantage permission for Camera from system settings	
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check Camera button not show under Quick Settings

@QuickSettingsOSLess @QuickSettingsOSGreat @OSLessDebug
Scenario: VAN21036_TestStep08_Check the Camera status when turn on four type of access
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Go to My Device Settings page
	Given into Dashboard page
	Then The Quick Settings display the Camera as On status

@QuickSettingsOSLess @QuickSettingsOSGreat @OSLessDebug
Scenario: VAN21036_TestStep09_Check Quick Settings Not display the Camera button when turn on Lenovo Vantage permission from system settings
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Go to My Device Settings page
	Given into Dashboard page
	When turn on Camera on Quick settings
	Then The Quick Settings display the Camera as On status

@QuickSettingsOSLess @QuickSettingsOSGreat @OSLessDebug
Scenario: VAN21036_TestStep10_Check Quick Settings display the Camera as Off status when turn off Camera on Quick settings
	Given turn on Lenovo Vantage permission for Microphonefrom system settings
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Go to My Device Settings page
	Given into Dashboard page
	When turn off Camera on Quick settings
	Then The Quick Settings display the Camera as Off status