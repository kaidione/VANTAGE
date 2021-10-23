Feature: VAN7221_HSCameraBlurRegression
	Test Case: https://lnvusjira.lenovonet.lenovo.local/browse/VAN-7221
	Author:caopp2
	Modify: Jiajt3

@HSCameraBlur
Scenario: VAN7221_TestStep00_Check Camera Environment
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Go to My Device Settings page
	When turn off Camera Privacy from Display and Camera page

@HSCameraBlur
Scenario: VAN7221_TestStep01_Check Camera blur status
	Given Launch Vantage
	Given Go to DisplayCamera page
	Given Go to Camera Blur Panel
	Given Turn On Camera Blur Toggle
	Given Uninstall the lenovo vatage
	Then  wait 120 seconds
	Given Install Vantage
	Then  wait 30 seconds
	Given Launch Vantage
	Given Go to DisplayCamera page
	Given Go to Camera Blur Panel
	Then  The toggle's value of Camera blur should be Off
	
@HSCameraBlur
Scenario: VAN7221_TestStep05_Check three blur button status
	Given Launch Vantage
	Given Go to DisplayCamera page
	Given Go to Camera Blur Panel
	Given Turn Off Camera Blur Toggle
	Then  three blur buttons hide

@HSCameraBlur
Scenario: VAN7221_TestStep07_1_Use the Windows Camera to check the Blur Mode
	Given Launch Vantage
	Given Go to DisplayCamera page
	Given Go to Camera Blur Panel
	Given Scroll the camera screen
	Given Turn On Camera Blur Toggle
	When  choose blur mode
	When Display Desktop
	Given Launch windows camera
	When wait 5 seconds
	Then  Take Screen Shot VAN7221_TestStep07_BlurModeWindowCamera in 7221 under HSScreenShotResult
	Then  close windows camera

@HSCameraBlur
Scenario: VAN7221_TestStep07_2_Use the Windows Camera to check the Comic Mode 
	Given Launch Vantage
	Given Go to DisplayCamera page
	Given Go to Camera Blur Panel
	Given Scroll the camera screen
	Given Turn On Camera Blur Toggle
	When  choose comic mode
	When Display Desktop
	Given Launch windows camera
	When wait 5 seconds
	Then  Take Screen Shot VAN7221_TestStep07_ComicModeWindowCamera in 7221 under HSScreenShotResult	
	Then  close windows camera

@HSCameraBlur
Scenario: VAN7221_TestStep07_3_Use the Windows Camera to check the Sketch Mode 
	Given Launch Vantage
	Given Go to DisplayCamera page
	Given Go to Camera Blur Panel
	Given Scroll the camera screen
	Given Turn On Camera Blur Toggle
	When  choose sketch mode
	When Display Desktop
	Given Launch windows camera
	When wait 5 seconds
	Then  Take Screen Shot VAN7221_TestStep07_SketchModeWindowCamera in 7221 under HSScreenShotResult
	Then  close windows camera

@HSCameraBlur
Scenario: VAN7221_TestStep09_Check Camera Blur feature after disconnect the network
	Given Launch Vantage
	Given Go to DisplayCamera page
	Given Go to Camera Blur Panel
	When  Disconnect Internet
	Given Scroll the camera screen
	Given Turn On Camera Blur Toggle
	Then  three blur buttons show
	When  Minimize vantage camera blur toggle
	Given Launch windows camera
	Then  wait 30 seconds
	Then  Take Screen Shot VAN7221_TestStep10_DisconnectInternetWindowCamera in 7221 under HSScreenShotResult
	Then  close windows camera
	When  Connect Internet

@HSCameraBlur
Scenario: VAN7221_TestStep10_Check The feature can be shown within 2 seconds and take effect
	When  Connect Internet
	Then  wait 30 seconds
	Given Go to DisplayCamera page
	Given Go to Camera Blur Panel
	Given Turn On Camera Blur Toggle
	Then  Take Screen Shot 10 in 7221 under SettingsScreenShotResult

@HSCameraBlur
Scenario: VAN7221_TestStep11_Check Camera Blur UI after disable camera related drivers
	When  Connect Internet
	Given disable camera driver
	Given Launch Vantage
	Given Go to DisplayCamera page
	Then  camera section hide
	Then  wait 30 seconds
	Given enable camera driver
	