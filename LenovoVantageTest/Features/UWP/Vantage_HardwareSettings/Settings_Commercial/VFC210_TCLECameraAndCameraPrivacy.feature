Feature: VFC210_TCLECameraAndCameraPrivacy
	Test Case： https://jira.tc.lenovo.com/browse/VFC-210
	Author： Daqi Fang

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep03_Uninstall Vantage Open Windows Camera And check
	Given Go to display page
	Given Click Camera Link
	When Click the Reset button
	Given turn on narrator
	Given turn on the Allow apps to access your camera
	Given Go to display page
	Given Click Camera Link
	Given Turn on Camera Privacy
	Given Close Vantage
	Given Uninstall the lenovo vatage
	When Wait 3 minutes
	Given Open the Windows Camera
	Then Take Screen Shot VFC210_Step03 in 210 under SettingsScreenShotResult

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep04_Uninstall Vantage and Install Vantage The Camera Privacy mode is off
	Given Go to display page
	Given Click Camera Link
	Given Turn on Camera Privacy
	Given Uninstall the lenovo vatage
	When Wait 3 minutes
	Given Install Vantage
	Given Go to display page
	Given Click Camera Link
	Then The Camera privacy mode is "off"

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep05_Check Camera Privacy Mode Button
	Given Go to display page
	Given Click Camera Link
	Then Take Screen Shot VFC210_Step05 in 210 under SettingsScreenShotResult

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep06_Check Ui value shows the description below the "Camera privacy mode" title.
	Given Go to display page
	Given Click Camera Link
	Then There shows the description '$.MyDeviceSettings.DisplayAndCamera.CameraPrivacyModeCaptionText'

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep07_Check the 'Reset' button should position in 'Camera' area
	Given Go to display page
	Given Click Camera Link
	Then Take Screen Shot VFC210_Step07 in 210 under SettingsScreenShotResult

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep08_Check question mark and tooltip text
	Given Go to display page
	Given Click Camera Link
	Given Show a Question Mark
	Given Click Question Mark
	Then Check tooltip display '$.MyDeviceSettings.DisplayAndCamera.CameraPrivacyQuestionMarkToolTipText'

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep09_Check Ui value toggle and title
	Given Go to display page
	Given Click Camera Link
	Then All the title and slider will show 
	Given Turn off Auto Exposure
	Then The AutoExposure slider is show
	When Click the Reset button

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep10_Check the value with AMcap
	Given Go to display page
	Given Click Camera Link
	Given Turn off Auto Exposure
	Given Get camera current message
	Given Close Vantage
	Then Get All value in AMCap
	Then The Vantage value is same with amcap

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep11_Slider Brightness new value 
	Given Go to display page
	Given Click Camera Link
	Given Set Brightness
	Given Get camera current message
	Given Close Vantage
	Then "brightness" value is same with AMCap

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep12_Slider Contrast new value 
	Given Go to display page
	Given Click Camera Link
	Given Set Contrast
	Given Get camera current message
	Given Close Vantage
	Then "contrast" value is same with AMCap

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep13_Slider AutoExp new value 
	Given Go to display page
	Given Click Camera Link
	Given Turn off Auto Exposure
	Given Set Auto Exposure
	Given Get camera current message
	Given Close Vantage
	Then "autoexposure" value is same with AMCap

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep14_Check camera privacy toggle status from Quick settings and toolbar
	#Given Pin toolbar to taskbar
	Given Go to display page
	Given Click Camera Link
	When Click the Reset button
	Given Turn on Camera Privacy
	Given Click Dashboard Link
	Then Quick settings camera privacy status is 'Off'
	
@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep15_Check Windows Camera and Vantage Camera Section Status
	Given Go to display page
	Given Click Camera Link
	Given Turn on Camera Privacy
	Given close lenovo vantage
	Given Open the Windows Camera
	Then Take Screen Shot VFC210_Step15 in 210 under SettingsScreenShotResult
	Given ReLaunch Lenovo Vantage
	Given Go to display page
	Given Click Camera Link
	Then Check Camera Is In Use

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep16_Check Windows Camera People Can See Themselves By Camera Normally
	Given Go to display page
	Given Click Camera Link
	Given Turn off Camera Privacy
	Given close lenovo vantage
	Given Open the Windows Camera
	Then Take Screen Shot VFC210_Step16 in 210 under SettingsScreenShotResult

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep17_The Camera Feature Should Appear Within 3s
	Given Uninstall the lenovo vatage
	Given Install Vantage
	Given Go to display page
	Given Click Camera Link
	When wait 3 seconds
	Then Check Camera and Camera Privacy UI Elements

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep18_Camera and Camera Privacy Appear Within 2s
	Given Go to display page
	Given Click Camera Link
	Given Click Dashboard Link
	Given Go to display page
	Given Click Camera Link
	When wait 2 seconds
	Then Check Camera and Camera Privacy UI Elements

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep19_Check the camera preview area should show a static image
	Given Go to display page
	Given Click Camera Link
	Given Turn off Camera Privacy
	Given Turn on Camera Privacy
	Then Take Screen Shot VFC210_Step19 in 210 under SettingsScreenShotResult

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep20_turn off the camera service and check
	Given Go to display page
	Given Click Camera Link
	Given Turn off Auto Exposure
	Given turn on narrator
	Given turn off the Allow apps to access your camera
	Then The Camera Privacy mode will be "hidden"
	Then The slider will be "greyout"
	Then Device Settigs Camera Access Url will be "show"
	Then Take Screen Shot VFC210_Step20 in 210 under SettingsScreenShotResult
	Given turn on the Allow apps to access your camera

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep21_turn off Then turn on the camera service and check
	Given Go to display page
	Given Click Camera Link
	Given turn on narrator
	Given turn off the Allow apps to access your camera
	Given turn on the Allow apps to access your camera
	Then The Camera Privacy mode will be "show"
	Then The slider will be "nogreyout"
	Then Device Settigs Camera Access Url will be "hidden"
	Then Take Screen Shot VFC210_Step21 in 210 under SettingsScreenShotResult

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep22_turn off the Allow desktop apps to access your camera and check
	Given Go to display page
	Given Click Camera Link
	Given Turn on Camera Privacy
	Given turn on narrator
	Given turn off the Allow desktop apps to access your camera
	Given Waiting 30 seconds
	Then The Camera Privacy mode will be "hidden"
	Then The slider will be "greyout"
	Then Device Settigs Camera Access Url will be "show"
	Then Take Screen Shot VFC210_Step22 in 210 under SettingsScreenShotResult

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep23_turn on the camera service and Allow desktop apps to access your camera and check
	Given Go to display page
	Given Click Camera Link
	Given turn on narrator
	Given turn on the Allow desktop apps to access your camera
	Given Waiting 40 seconds
	Then The Camera Privacy mode will be "show"
	Then The slider will be "nogreyout"
	Then Device Settigs Camera Access Url will be "hidden"
	Then Take Screen Shot VFC210_Step23 in 210 under SettingsScreenShotResult

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep24_turn on the Allow apps to access your camera and check
	Given Go to display page
	Given Click Camera Link
	Given Turn on Camera Privacy
	Given Set Brightness
	Given Set Contrast
	Given Turn off Auto Exposure
	Given Set Auto Exposure
	Given Get camera current message
	Given Close Vantage
	Given turn on narrator
	Given turn off the Allow apps to access your camera
	Given Launch Vantage
	Given Go to display page
	Given Click Camera Link
	Given turn on narrator
	Given turn on the Allow apps to access your camera
	Then Camera privacy mode toggle is on
	Then The value is same than before
	When Click the Reset button

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep25_Check Vantage UI should keep the value that user set before
	Given Go to display page
	Given Click Camera Link
	Then Take Screen Shot VFC210_Step25_01 in 210 under SettingsScreenShotResult
	Given Set Brightness
	Given Set Contrast
	Given Turn off Auto Exposure
	Given Set Auto Exposure
	Then Take Screen Shot VFC210_Step25_02 in 210 under SettingsScreenShotResult
	Given close lenovo vantage
	Given ReLaunch Lenovo Vantage
	Given Go to display page
	Given Click Camera Link
	Then Take Screen Shot VFC210_Step25_03 in 210 under SettingsScreenShotResult
	When Click the Reset button

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep26_Minimize vantage and Maximize vantage check ui
	Given Go to display page
	Given Click Camera Link
	Given Turn off Camera Privacy
	Given Turn off Auto Exposure
	When Minimize vantage
	When Wait 6 minutes
	And Maximize Vatnage
	Then The Ui show normally
	Then Take Screen Shot VFC210_Step26 in 210 under SettingsScreenShotResult

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep27_hibernate and sleep
	Given Go to display page
	Given Click Camera Link
	Given Set Brightness
	Given Set Contrast
	Given Turn off Auto Exposure
	Given Set Auto Exposure
	Given Get camera current message
	When enter hibernate
	Then The value is same than before
	When enter sleep
	Then The value is same than before
	When Click the Reset button

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep28_doble click reset
	Given Go to display page
	Given Click Camera Link
	Given Set Brightness
	Given Set Contrast
	Given Turn off Auto Exposure
	Given Set Auto Exposure
	When Click the Reset button
	Given Turn off Auto Exposure
	Given Get camera current message
	Given Set Brightness
	Given Set Contrast
	Given Set Auto Exposure
	When Click the Reset button
	Given Turn off Auto Exposure
	Then The value is same than before
	When Click the Reset button

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep29_Check Reset Value
	Given Go to display page
	Given Click Camera Link
	Given Turn off Auto Exposure
	Then Take Screen Shot VFC210_Step29_01 in 210 under SettingsScreenShotResult
	When Click the Reset button
	Then Take Screen Shot VFC210_Step29_02 in 210 under SettingsScreenShotResult
	Then The Auto Exposure toogle become 'on' and restore to default value

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep30_Turn off Auto Exposure and Check Auto Exposure Slidebar Is Available
	Given Go to display page
	Given Click Camera Link
	Given Turn off Auto Exposure
	Given Set Auto Exposure

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep31_Check Disable Device Camera section should be hidden
	Given Disable Device 'Integrated Camera' and 'Integrated IR Camera'
	Given Go to display page
	Then Camera Link should be hidden
	Then The Camera section should be hidden
	Given Enable Device 'Integrated Camera' and 'Integrated IR Camera'

@CheckLEDoNotSupportCameraPrivacy
Scenario: VFC210_TestStep32_Machine Do Not Support Camera Privacy Elements No Display
	Given Go to display page
	Given Click Camera Link
	Then The Camera section should be hidden

@CheckLEDoNotSupportCameraPrivacy
Scenario: VFC210_TestStep33_Turn Off The Allow Apps to Access Your Camera Check Elemens
	Given Go to display page
	Given Click Camera Link
	Given turn on narrator
	Given turn off the Allow apps to access your camera
	Then The slider will be "greyout"
	Then Device Settigs Camera Access Url will be "show"
	Then Take Screen Shot VFC210_Step33 in 210 under SettingsScreenShotResult
	Given turn on the Allow apps to access your camera

@CheckLEDoNotSupportCameraPrivacy
Scenario: VFC210_TestStep34_Turn On The Allow Apps to Access Your Camera Check Elemens
	Given Go to display page
	Given Click Camera Link
	Given turn on narrator
	Given turn off the Allow apps to access your camera
	Given turn on the Allow apps to access your camera
	Then The slider will be "nogreyout"
	Then Device Settigs Camera Access Url will be "hidden"
	Then Take Screen Shot VFC210_Step34 in 210 under SettingsScreenShotResult
	Given turn on the Allow apps to access your camera

@CheckLECameraAndCameraPrivacy
Scenario: VFC210_TestStep35_Check Disconnect The Internet Camera and Camera Privacy Elements
	When The user connect or disconnect WiFi off lenovo
	Given Go to display page
	Given Click Camera Link
	Then Check Camera and Camera Privacy UI Elements
	When The user connect or disconnect WiFi on lenovo

@CheckLECameraAndCameraPrivacyX1
Scenario: VFC210_TestStep39_Check Camera privacy should show correctly Camera preview should be hidden.
	Given Go to display page
	When  ReLaunch Vantage 
	Given Go to display page
	Then The Camera Privacy mode will be "show"
	Then The Camera Preview should be hidden

@CheckLECameraAndCameraPrivacyX1
Scenario: VFC210_TestStep40_Check Camera privacy Camera and camera preview should be hidden
	Given turn on narrator
	Given Set 'Integrated Camera' drive state to enable or disable 'disable' via HardwareId 'default'
	Given Go to display page
	Then Camera Link should be hidden
	Then The Camera Privacy mode will be "hidden"
	Then The Camera Preview should be hidden
	Given Set 'Integrated Camera' drive state to enable or disable 'enable' via HardwareId 'default'
