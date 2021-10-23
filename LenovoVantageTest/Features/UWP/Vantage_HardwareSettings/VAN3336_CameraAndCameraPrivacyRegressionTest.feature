Feature: VAN3336_CameraAndCameraPrivacyRegressionTest
	Test Case： https://jira.tc.lenovo.com/browse/VAN-3336
	Author：Daqi Fang

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep00_Reset the camera button and access
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given turn on the Allow desktop apps to access your camera
	Given Go to display page
	Given Click Camera Link
	When Click the Reset button

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep03_Uninstall Vantage Open Windows Camera And check
	Given Go to display page
	Given Click Camera Link
	Given Turn on Camera Privacy
	Given Close Vantage
	Given Open the Windows Camera
	Then Take Screen Shot VAN3336_Step03_01 in 3336 under SettingsScreenShotResult
	Given Uninstall the lenovo vatage
	When Wait 3 minutes
	Then Take Screen Shot VAN3336_Step03_02 in 3336 under SettingsScreenShotResult

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep04_Uninstall Vantage and Install Vantage The Camera Privacy mode is off
	Given Go to display page
	Given Click Camera Link
	Given Turn on Camera Privacy
	Given Uninstall the lenovo vatage
	When Wait 3 minutes
	Given Install Vantage
	Given Go to display page
	Given Click Camera Link
	Then The Camera privacy mode is "off"

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep05_Check camera privacy mode button
	Given Go to display page
	Given Click Camera Link
	Then Take Screen Shot VAN3336_Step05 in 3336 under SettingsScreenShotResult

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep06_Check Ui value shows the description below the "Camera privacy mode" title.
	Given Go to display page
	Given Click Camera Link
	Then There shows the description '$.MyDeviceSettings.DisplayAndCamera.CameraPrivacyModeCaptionText'

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep07_Check the 'Reset' button should position in 'Camera' area
	Given Go to display page
	Given Click Camera Link
	Then Take Screen Shot VAN3336_Step07 in 3336 under SettingsScreenShotResult

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep08_Check question mark and tooltip text
	Given Go to display page
	Given Click Camera Link
	Given Show a Question Mark
	Given Click Question Mark
	Then Check tooltip display '$.MyDeviceSettings.DisplayAndCamera.CameraPrivacyQuestionMarkToolTipText'

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep09_Check Ui value toggle and title
	Given Go to display page
	Given Click Camera Link
	Then All the title and slider will show 
	Given Turn off Auto Exposure
	Then The AutoExposure slider is "show"
	Given Turn on Auto Exposure
	Then The AutoExposure slider is "hidden"
	When Click the Reset button

@CheckCameraAndCameraPrivacygameming
Scenario: VAN3336_TestStep10_Check Ui in gameming computer
	When Click the Media icon
	Given Click Camera Link
	Then Take Screen Shot VAN3336_Step10 in 3336 under SettingsScreenShotResult
	When Click the Reset button

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep11_Check the value with AMcap
	Given Go to display page
	Given Click Camera Link
	Given Turn off Auto Exposure
	Given Get camera current message
	Given Close Vantage
	Then Get All value in AMCap
	Then The Vantage value is same with amcap

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep12_Slider Brightness new value 
	Given Go to display page
	Given Click Camera Link
	Given Turn off Auto Exposure
	Given Set Brightness
	Given Get camera current message
	Given Close Vantage
	Then "brightness" value is same with AMCap

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep13_Slider Contrast  new value 
	Given Go to display page
	Given Click Camera Link
	Given Turn off Auto Exposure
	Given Set Contrast
	Given Get camera current message
	Given Close Vantage
	Then "contrast" value is same with AMCap

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep14_Slider AutoExp  new value 
	Given Go to display page
	Given Click Camera Link
	Given Turn off Auto Exposure
	Given Set Auto Exposure
	Given Get camera current message
	Given Close Vantage
	Then "autoexposure" value is same with AMCap

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep15_Check camera privacy toggle status from Quick settings and toolbar
	Given Pin toolbar to taskbar
	Given Go to display page
	Given Click Camera Link
	When Click the Reset button
	Given Turn on Camera Privacy
	Given Click Dashboard Link
	Then Quick settings camera privacy status is 'Off'
	When Launch toolbar
	Then Take Screen Shot VAN3336_Step015 in 3336 under SettingsScreenShotResult
	When Close toolbar

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep16_Check Windows Camera and Vantage Camera Section Status
	Given Go to display page
	Given Click Camera Link
	Given Turn on Camera Privacy
	Given close lenovo vantage
	Given Open the Windows Camera
	Then Take Screen Shot VAN3336_Step16 in 3336 under SettingsScreenShotResult
	Given ReLaunch Lenovo Vantage
	Given Go to display page
	Given Click Camera Link
	Then Check Camera Is In Use

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep17_Check Windows Camera People Can See Themselves By Camera Normally
	Given Go to display page
	Given Click Camera Link
	Given Turn off Camera Privacy
	Given close lenovo vantage
	Given Open the Windows Camera
	Then Take Screen Shot VAN3336_Step17 in 3336 under SettingsScreenShotResult

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep18_The Camera Feature Should Appear Within 3s
	Given Uninstall the lenovo vatage
	Given Install Vantage
	Given Go to display page
	Given Click Camera Link
	When wait 3 seconds
	Then Check Camera and Camera Privacy UI Elements

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep19_Camera and Camera Privacy Appear Within 2s
	Given Go to display page
	Given Click Camera Link
	Given Click Dashboard Link
	Given Go to display page
	Given Click Camera Link
	When wait 2 seconds
	Then Check Camera and Camera Privacy UI Elements

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep20_Check the camera preview area should show a static image
	Given Go to display page
	Given Click Camera Link
	Given Turn off Camera Privacy
	Given Turn on Camera Privacy
	Then Take Screen Shot VAN3336_Step20 in 3336 under SettingsScreenShotResult

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep21_turn off the camera service and check
	Given Go to display page
	Given Click Camera Link
	Given Turn off Auto Exposure
	Given turn off the Allow apps to access your camera
	Then The Camera Privacy mode will be "hidden"
	Then The slider will be "greyout"
	Then Device Settigs Camera Access Url will be "show"
	Then Take Screen Shot VAN3336_Step21 in 3336 under SettingsScreenShotResult
	Given turn on the Allow apps to access your camera

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep22_turn off Then turn on the camera service and check
	Given Go to display page
	Given Click Camera Link
	Given turn off the Allow apps to access your camera
	Given Click Go To Settings links
	Given turn on the Allow apps to access your camera
	Then The Camera Privacy mode will be "show"
	Then The slider will be "nogreyout"
	Then Device Settigs Camera Access Url will be "hidden"
	Then Take Screen Shot VAN3336_Step22 in 3336 under SettingsScreenShotResult

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep23_turn off the Allow desktop apps to access your camera and check
	Given Go to display page
	Given Click Camera Link
	Given Turn on Camera Privacy
	Given turn off the Allow desktop apps to access your camera
	Given Waiting 30 seconds
	Then The Camera Privacy mode will be "hidden"
	Then The slider will be "greyout"
	Then Device Settigs Camera Access Url will be "show"
	Then Take Screen Shot VAN3336_Step23 in 3336 under SettingsScreenShotResult

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep24_turn on the camera service and Allow desktop apps to access your camera and check
	Given Go to display page
	Given Click Camera Link
	Given turn off the Allow desktop apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given Waiting 40 seconds
	Then The Camera Privacy mode will be "show"
	Then The slider will be "nogreyout"
	Then Device Settigs Camera Access Url will be "hidden"
	Then Take Screen Shot VAN3336_Step24 in 3336 under SettingsScreenShotResult

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep25_turn on the Allow apps to access your camera and check
	Given Go to display page
	Given Click Camera Link
	Given Turn on Camera Privacy
	Given Set Brightness
	Given Set Contrast
	Given Turn off Auto Exposure
	Given Set Auto Exposure
	Given Get camera current message
	Given Close Vantage
	Given turn off the Allow access to the camera toggle on this device
	Given Launch Vantage
	Given Go to display page
	Given Click Camera Link
	Given turn on the Allow access to the camera toggle on this device
	Then Camera privacy mode toggle is on
	Then The value is same than before
	When Click the Reset button

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep26_Check Vantage UI should keep the value that user set before
	Given Go to display page
	Given Click Camera Link
	Given Set Brightness
	Given Set Contrast
	Given Turn off Auto Exposure
	Given Set Auto Exposure
	Given Get camera current message
	Given close lenovo vantage
	Given ReLaunch Lenovo Vantage
	Given Go to display page
	Given Click Camera Link
	Then The value is same than before
	Given Go to dashboad page
	Given Go to display page
	Given Click Camera Link
	Then The value is same than before
	When Click the Reset button

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep27_Minimize vantage and Maximize vantage check ui
	Given Go to display page
	Given Click Camera Link
	Given Turn off Camera Privacy
	Given Turn off Auto Exposure
	When Minimize vantage
	When Wait 6 minutes
	And Maximize Vatnage
	Then The Ui show normally
	Then Take Screen Shot VAN3336_Step27 in 3336 under SettingsScreenShotResult

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep28_hibernate and sleep
	Given Go to display page
	Given Click Camera Link
	Given Set Brightness
	Given Set Contrast
	Given Turn off Auto Exposure
	Given Set Auto Exposure
	Given wait 2 seconds
	Given Get camera current message
	Given Close Vantage
	When enter hibernate
	Given Launch Vantage
	Given Go to display page
	Given Click Camera Link
	Given Turn on or off the narrator 'off'
	Then The value is same than before
	Given Close Vantage
	When enter sleep
	Given Launch Vantage
	Given Go to display page
	Given Click Camera Link
	Given Turn on or off the narrator 'off'
	Then The value is same than before
	When Click the Reset button

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep29_doble click reset
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

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep30_Check Reset Value
	Given Go to display page
	Given Click Camera Link
	Given Turn off Auto Exposure
	Given Set Auto Exposure
	Then Take Screen Shot VAN3336_Step30_01 in 3336 under SettingsScreenShotResult
	When Click the Reset button
	Then Take Screen Shot VAN3336_Step30_02 in 3336 under SettingsScreenShotResult
	Then The Auto Exposure toogle become 'on' and restore to default value
	Given Turn off Auto Exposure
	Given Get camera current message
	Given Close Vantage
	Then "autoexposure" value is same with AMCap

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep31_Turn off Auto Exposure and Check Auto Exposure Slidebar Is Available
	Given Go to display page
	Given Click Camera Link
	Given Turn off Auto Exposure
	Given Set Auto Exposure

@CheckDoNotSupportCameraPrivacy
Scenario: VAN3336_TestStep34_Machine Do Not Support Camera Privacy Elements No Display
	Given Go to display page
	Given Click Camera Link
	Then The Camera section should be hidden

@CheckDoNotSupportCameraPrivacy
Scenario: VAN3336_TestStep35_Turn Off The Allow Apps to Access Your Camera Check Elemens
	Given Go to display page
	Given Click Camera Link
	Given turn off the Allow apps to access your camera
	Then The slider will be "greyout"
	Then Device Settigs Camera Access Url will be "show"
	Then Take Screen Shot VAN3336_Step35 in 3336 under SettingsScreenShotResult
	Given turn on the Allow apps to access your camera

@CheckDoNotSupportCameraPrivacy
Scenario: VAN3336_TestStep36_Turn On The Allow Apps to Access Your Camera Check Elemens
	Given Go to display page
	Given Click Camera Link
	Given turn off the Allow apps to access your camera
	Given turn on the Allow apps to access your camera
	Then The slider will be "nogreyout"
	Then Device Settigs Camera Access Url will be "hidden"
	Then Take Screen Shot VAN3336_Step36 in 3336 under SettingsScreenShotResult
	Given turn on the Allow apps to access your camera

@CheckCameraAndCameraPrivacy @SmokeCheckCameraAnddisplayShow
Scenario: VAN3336_TestStep37_01_Check Disconnect The Internet Camera and Camera Privacy Elements
	When The user connect or disconnect WiFi off lenovo
	Given Go to display page
	Given Click Camera Link
	Then Check Camera and Camera Privacy UI Elements
	When The user connect or disconnect WiFi on lenovo

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep38_3301_Check Disable Device Camera section should be hidden(Step No33,Need Run After Step37)
	When The user connect or disconnect WiFi on lenovo
	Given Disable Device 'Integrated Camera' and 'Integrated IR Camera'
	Given Go to display page
	Then Camera Link should be hidden
	Then The Camera section should not be find
	Given Enable Device 'Integrated Camera' and 'Integrated IR Camera'

@CheckCameraAndCameraPrivacy
Scenario: VAN3336_TestStep38_3302_Enable Device(Step No33,Need Run After Step37)
	Given Enable Device 'Integrated Camera' and 'Integrated IR Camera'