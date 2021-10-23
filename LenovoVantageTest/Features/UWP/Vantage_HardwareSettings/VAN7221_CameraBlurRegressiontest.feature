Feature: VAN7221_CameraBlurRegressiontest
	Test Case: https://lnvusjira.lenovonet.lenovo.local/browse/VAN-7221
	Author:Li XiaoXiong
	Modify:Jiajt3

@HSCameraBlur
Scenario: VAN7221_TestStep00_Check Camera Environment
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Go to My Device Settings page
	When turn off Camera Privacy from Display and Camera page

@HSCameraBlur @SmokeHSCameraBlur
Scenario: VAN7221_TestStep02_Check This feature is under Camera section and it shows a toggle and a description
	Given Go to DisplayCamera page
	Given Go to Camera Blur Panel	
	Then check Camereblur Featrue

@HSCameraBlur
Scenario: VAN7221_TestStep03_Check Display a toggle button with 3 options
	Given Go to DisplayCamera page
	Given Go to Camera Blur Panel
	Given Scroll the camera screen
	Given Scroll the screen on prefrence setting page
	Given Turn On Camera Blur Toggle
	Then check the three blur

@HSCameraBlur
Scenario: VAN7221_TestStep04_Check The Camera blur take effect
	Given Go to DisplayCamera page
	Given Go to Camera Blur Panel
	Given Scroll the camera screen
	Given Turn On Camera Blur Toggle
	Given close lenovo vantage
	Given Display Desktop
	Given openwincamera
	Then  Take Screen Shot 04 in 7221 under SettingsScreenShotResult
	Given closewincamera

@HSCameraBlur
Scenario: VAN7221_TestStep06_Check Display a blur/comic/stekch image to show the effect beside the selected mode and take effect
	Given Go to DisplayCamera page
	Given Go to Camera Blur Panel
	Given Scroll the camera screen
	Given Turn On Camera Blur Toggle
	When  choose sketch mode
	When  choose blur mode
	Then  Take Screen Shot 0601 in 7221 under SettingsScreenShotResult
	When  choose comic mode
	Then  Take Screen Shot 0602 in 7221 under SettingsScreenShotResult
	When  choose sketch mode
	Then  Take Screen Shot 0603 in 7221 under SettingsScreenShotResult


	