Feature: VAN19816_QuickSettingsCameraButtonFunctionTest
	Test Case： https://jira.tc.lenovo.com/browse/VAN-19816
	Author：Jinxin Li

@QuickSettingsCameraButton
Scenario: VAN19816_TestStep01_Check Quick Settings Camera  Is "Off" Display Tip and Link
	Given turn off the Allow access to the camera toggle on this device
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check camera disable
	Then Check Camera button not show under Quick Settings
	Then Check Camera Access Tip Text '$.Dashboard.CameraAccessTip'
	Then camera access tip exists
	Given turn on the Allow access to the camera toggle on this device

@QuickSettingsCameraButton
Scenario: VAN19816_TestStep02_Click Camera Access Link Change Button to "On" Check Status
	Given turn off the Allow access to the camera toggle on this device
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check camera disable
	Then Check Camera button not show under Quick Settings
	Then Check Camera Access Tip Text '$.Dashboard.CameraAccessTip'
	Then camera access tip exists
	When Click camera access tips
	Given turn on the Allow access to the camera toggle on this device
	Given Close System Settings
	Given The button display normal

@QuickSettingsCameraButton
Scenario: VAN19816_TestStep03_Check Quick Settings Camera  Is "Off" Display Tip and Link
	Given turn on the Allow access to the camera toggle on this device
	Given turn off the Allow apps to access your camera
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check camera disable
	Then Check Camera button not show under Quick Settings
	Then Check Camera Access Tip Text '$.Dashboard.CameraAccessTip'
	Then camera access tip exists
	Given turn on the Allow apps to access your camera

@QuickSettingsCameraButton
Scenario: VAN19816_TestStep04_Click Camera Access Link Change Button to "On" Check Status
	Given turn on the Allow access to the camera toggle on this device
	Given turn off the Allow apps to access your camera
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check camera disable
	Then Check Camera button not show under Quick Settings
	Then Check Camera Access Tip Text '$.Dashboard.CameraAccessTip'
	Then camera access tip exists
	When Click camera access tips
	Given turn on the Allow apps to access your camera
	Given Close System Settings
	Given The button display normal

@QuickSettingsCameraButton
Scenario: VAN19816_TestStep05_turn "off" permission3 Check Button Status
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn off Lenovo Vantage permission for Camera from system settings
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check camera disable
	Then Check Camera button not show under Quick Settings
	Then Check Camera Access Tip Text '$.Dashboard.CameraAccessTip'
	Then camera access tip exists
	Given turn on Lenovo Vantage permission for Camera from system settings

@QuickSettingsCameraButton
Scenario: VAN19816_TestStep06_turn "on" permission3 Check Button Status
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn off Lenovo Vantage permission for Camera from system settings
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check camera disable
	Then Check Camera button not show under Quick Settings
	Then Check Camera Access Tip Text '$.Dashboard.CameraAccessTip'
	Then camera access tip exists
	When Click camera access tips
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Close System Settings
	Given The button display normal

@QuickSettingsCameraButton
Scenario: VAN19816_TestStep07_turn "off" permission4 Check Button Status
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn off the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check camera disable
	Then Check Camera button not show under Quick Settings
	Then Check Camera Access Tip Text '$.Dashboard.CameraAccessTip'
	Then camera access tip exists
	
@QuickSettingsCameraButton
Scenario: VAN19816_TestStep08_turn "on" permission4 Check Button Status
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn off the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check camera disable
	Then Check Camera button not show under Quick Settings
	Then Check Camera Access Tip Text '$.Dashboard.CameraAccessTip'
	Then camera access tip exists
	When Click camera access tips
	Given turn on the Allow desktop apps to access your camera
	Given Close System Settings
	Given Go to My Device Settings page
	Given into Dashboard page
	Given The button display normal

@QuickSettingsCameraButton
Scenario: VAN19816_TestStep09_turn "off" permission3 and permission4 Check Button Status
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn off the Allow desktop apps to access your camera
	Given turn off Lenovo Vantage permission for Camera from system settings
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check camera disable
	Then Check Camera button not show under Quick Settings
	Then Check Camera Access Tip Text '$.Dashboard.CameraAccessTip'
	Then camera access tip exists
	
@QuickSettingsCameraButton
Scenario: VAN19816_TestStep10_turn "on" permission3 and permission4 Check Button Status
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn off the Allow desktop apps to access your camera
	Given turn off Lenovo Vantage permission for Camera from system settings
	Given Go to My Device Settings page
	Given into Dashboard page
	Then Check camera disable
	Then Check Camera button not show under Quick Settings
	Then Check Camera Access Tip Text '$.Dashboard.CameraAccessTip'
	Then camera access tip exists
	When Click camera access tips
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Close System Settings
	Given The button display normal

@QuickSettingsCameraButton
Scenario: VAN19816_TestStep11_Stay OOBE Check Quick Settings button 
	Given Uninstall the lenovo vatage
	Given Install the Lenovo Vantage Without Launch Vantage
	Given Launch Vantage
	Then wait 60 seconds
	Then Take Screen Shot VAN19816_Step11 in 19816 under SettingsScreenShotResult
	Given Click OOBE Without blue bar

@QuickSettingsCameraButtonOSLess
Scenario: VAN19816_TestStep12_Check OSLess Quick Settings display
	Given Uninstall the lenovo vatage
	Given Install the Lenovo Vantage Without Launch Vantage
	Given Launch Vantage
	Given Click OOBE Without blue bar
	Then Take Screen Shot VAN19816_Step12 in 19816 under SettingsScreenShotResult

@QuickSettingsCameraButton
Scenario: VAN19816_TestStep13_Check Quick Settings display the Camera as On status
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Go to My Device Settings page
	Given into Dashboard page
	When turn on Camera on Quick settings
	Then The Quick Settings display the Camera as On status

@QuickSettingsCameraButton
Scenario: VAN19816_TestStep14_Check Quick Settings display the Camera as On status when turn on Camera button
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Go to My Device Settings page
	Given into Dashboard page
	When turn on Camera on Quick settings
	Then The Quick Settings display the Camera as On status

@QuickSettingsCameraButton
Scenario: VAN19816_TestStep15_Check Quick Settings display the Camera as Off status when turn off Camera button
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Go to My Device Settings page
	Given into Dashboard page
	When turn off Camera on Quick settings
	Then The Quick Settings display the Camera as Off status

@QuickSettingsCameraButtonNarrator
Scenario: VAN19816_TestStep16_Check Quick Settings display the Camera as On status when turn off Camera Privacy from Display and Camera page
	Given turn on narrator
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Pin toolbar to taskbar
	Given Turn on permission
	When Launch toolbar
	When turn off Camera Privacy from Toolbar
	Given Go to My Device Settings page
	Given into Dashboard page
	Then The Quick Settings display the Camera as On status

@QuickSettingsCameraButtonNarrator
Scenario: VAN19816_TestStep17_Check Quick Settings display the Camera as Off status when turn on Camera Privacy from Toolbar
	Given turn on narrator
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Pin toolbar to taskbar
	Given Turn on permission
	When Launch toolbar
	When turn on Camera Privacy from Toolbar
	Given Go to My Device Settings page
	Given into Dashboard page
	Then The Quick Settings display the Camera as Off status

@QuickSettingsCameraButton
Scenario: VAN19816_TestStep18_Check Quick Settings display the Camera as On status when turn off Camera Privacy from Display and Camera page
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Go to My Device Settings page
	When turn off Camera Privacy from Display and Camera page
	Given into Dashboard page
	Then The Quick Settings display the Camera as On status

@QuickSettingsCameraButton
Scenario: VAN19816_TestStep19_Check Quick Settings display the Camera as Off status when turn on Camera Privacy from Toolbar
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Go to My Device Settings page
	When turn on Camera Privacy from Display and Camera page
	Given into Dashboard page
	Then The Quick Settings display the Camera as Off status

@QuickSettingsCameraButton
Scenario: VAN19816_TestStep20_Press Win and D to Switch Page The button display normal
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given turn on Camera on Quick settings
	When Press Win and D to Switch Page
	Given The button display normal

@QuickSettingsCameraButtonS3orS4
Scenario: VAN19816_TestStep21_Check Button Normal Back From Sleep 
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given turn on Camera on Quick settings
	When Set System To 'sleep'
	Given The button display normal
	Then The Quick Settings display the Camera as On status

@QuickSettingsCameraButtonS3orS4
Scenario: VAN19816_TestStep22_Check Button Status Back From Sleep
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given turn off Camera on Quick settings
	When Set System To 'sleep'
	Given The button display normal
	Then The Quick Settings display the Camera as Off status
	Given turn on Camera on Quick settings
	Then The Quick Settings display the Camera as On status

@QuickSettingsCameraButtonS3orS4
Scenario: VAN19816_TestStep23_Check Button Status Back From Hibernate
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given turn off Camera on Quick settings
	When Set System To 'hibernate'
	Given The button display normal
	Then The Quick Settings display the Camera as Off status
	Given turn on Camera on Quick settings
	Then The Quick Settings display the Camera as On status

@QuickSettingsCameraButton
Scenario: VAN19816_TestStep99_RecoverDefaultDPI
	Given Change DPI to 150