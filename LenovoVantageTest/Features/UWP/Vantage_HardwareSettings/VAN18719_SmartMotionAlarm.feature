Feature: VAN18719_SmartMotionAlarm
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-18719
	Author： Marcus

@SmartMotionAlarm
Scenario: VAN18719_Step00_Enable Camera Status for SmartMotionAlarm
	Given turn on narrator
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	When Launch toolbar
	When turn off Camera Privacy from Toolbar
	When Close toolbar

@SmartMotionAlarm @Marcus
Scenario: VAN18719_Step1_Step45_Step46_default value for SmartMotionAlarm
	Given Close Vantage
	And Uninstall the lenovo vatage
	And Install Vantage
	#And Launch vantage and go through tutorial with default segment
	And Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	And verify intelligent sensing 'exists'
	When click intelligent sensing
	Then verify default status is 'Disabled' for Smart Motion Alarm toggle
	Then verify default time is '10 seconds' for Alarm
	When The 'alarm' drop down list will be hidden or shown 'shown' for SmartMotionAlarm
	#When show 'alarm time' list
	When wait 30 seconds
	Then verify photo or time list Item 
	| Time Options |
	| 10 seconds   |
	| 20 seconds   |
	| 30 seconds   |
	| 1 minute     |
	| Never stop   |
	When The 'alarm' drop down list will be hidden or shown 'hidden' for SmartMotionAlarm
	#When dismiss 'alarm time' list
	Then verify default status is 'Disabled' for Enable Feature
	When 'Enable' Enable Feature
	Then verify default number is '5' for Photo number
	When The 'photo' drop down list will be hidden or shown 'shown' for SmartMotionAlarm
	#When show photo list
	When wait 30 seconds
	Then verify photo or time list Item
	| Photo Options |
	| 5             |
	| 10            |
	| 15            |
	| 20            |
	| 25            |
	| 30            |
	When The 'photo' drop down list will be hidden or shown 'hidden' for SmartMotionAlarm
	#When dismiss photo list

@Marcus @SmartMotionAlarm
Scenario: VAN18719_Step39_ReinstallLISSDriver_DefaultValueReturn
	Given Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	And click intelligent sensing
	And toggle 'On' for Smart Motion Alarm
	When The 'alarm' drop down list will be hidden or shown 'shown' for SmartMotionAlarm
	#And show 'alarm time' list
	When wait 5 seconds
	When select time option '20 seconds'
	And 'Enable' Enable Feature
	When The 'photo' drop down list will be hidden or shown 'shown' for SmartMotionAlarm
	#And show photo list
	When wait 30 seconds
	And select photo number '15'
	And close lenovo vantage
	And uninstall 'Lenovo Intelligent Sensing' from device manager
	And install 'Lenovo Intelligent Sensing'
	And ReLaunch Vantage
	And Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	And click intelligent sensing
	Then verify default status is 'Disabled' for Smart Motion Alarm toggle
	Then verify default time is '10 seconds' for Alarm
	Then verify default status is 'Disabled' for Enable Feature
	When 'Enable' Enable Feature
	When wait 30 seconds
	Then verify default number is '5' for Photo number

@Marcus @NotSupportSmartAlarm @SmokeNoSmartMotionAlarm
Scenario: VAN18719_Step43_NO smart assist link on unsupport machines
	Given Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	And verify intelligent sensing 'NOT exist'

@SmartMotionAlarm @Marcus @SmokeSmartMotionAlarm
Scenario: VAN18719_Step44_compare with GUI spec for defined strings
	Given Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	Given turn on narrator
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on the Allow desktop apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Launch toolbar
	When turn off Camera Privacy from Toolbar
	When Close toolbar
	And Go to Smart Assist page
	When click intelligent sensing
	#Then verify string 'i'm checking smart assist page ,Intelligent sensing' displays on Vantage by using json path '$.device.smartAssist.antiTheft.heading' to retrieve from resource file
	#Then verify string 'Smart motion alarm' displays on Vantage by using json path '$.device.smartAssist.antiTheft.title' to retrieve from resource file
	#Then verify string 'When enabling this feature, the device will start beeping ' displays on Vantage by using json path '$.device.smartAssist.antiTheft.desc1' to retrieve from resource file
	#Then verify string 'Log into Windows and the alarm will be automatically' displays on Vantage by using json path '$.device.smartAssist.antiTheft.desc2' to retrieve from resource file
	#Then verify string '"Valid sign-in options such as a password' displays on Vantage by using json path '$.device.smartAssist.antiTheft.note.description1' to retrieve from resource file
	#Then verify string 'Before leaving your computer, be sure to lock the computer' displays on Vantage by using json path '$.device.smartAssist.antiTheft.note.description2' to retrieve from resource file
	#Then verify string 'THE ALARM WILL LAST FOR' displays on Vantage by using json path '$.device.smartAssist.antiTheft.alarm.title' to retrieve from resource file
	#Then verify string 'TAKING PHOTOS' displays on Vantage by using json path '$.device.smartAssist.antiTheft.allowCamera.title' to retrieve from resource file
	#Then verify string 'When enabling this feature, the camera takes photos automatically ' displays on Vantage by using json path '$.device.smartAssist.antiTheft.allowCamera.describe' to retrieve from resource file
	#Then verify string 'Enable this feature' displays on Vantage by using json path '$.device.smartAssist.antiTheft.allowCamera.checkBoxText' to retrieve from resource file
	Then verify title or describe Item
	| title or describe | des                                                 |
	| title             | $.device.smartAssist.antiTheft.title                |
	| describe1         | $.device.smartAssist.antiTheft.desc1                |
	| describe2         | $.device.smartAssist.antiTheft.desc2                |
	| attention1        | $.device.smartAssist.antiTheft.note.description1    |
	| attention2        | $.device.smartAssist.antiTheft.note.description2    |
	| alarmtimetitle    | $.device.smartAssist.antiTheft.alarm.title          |
	| takephotostitle   | $.device.smartAssist.antiTheft.allowCamera.title    |
	| describe3         | $.device.smartAssist.antiTheft.allowCamera.describe |
	When 'Enable' Enable Feature
	#Then verify string 'THE NUMBER OF PHOTOS TAKEN' displays on Vantage by using json path '$.device.smartAssist.antiTheft.photo.title' to retrieve from resource file
	#Then verify string 'showPhoto' displays on Vantage by using json path '$.device.smartAssist.antiTheft.showPhoto.title' to retrieve from resource file
	#Then verify string 'View photos' displays on Vantage by using json path '$.device.smartAssist.antiTheft.showPhoto.link' to retrieve from resource file
	Then verify title or describe Item
	| title or describe | des                                            |
	| showPhoto         | $.device.smartAssist.antiTheft.showPhoto.title |
	| ViewPhotos        | $.device.smartAssist.antiTheft.showPhoto.link  |

@SmartMotionAlarm @Marcus
Scenario: VAN18719_Step45_default value for SmartMotionAlarm
	When Only Print 'Please check TestStep01'

@SmartMotionAlarm @Marcus
Scenario: VAN18719_Step46_default value for SmartMotionAlarm
	When Only Print 'Please check TestStep01'

@SmartMotionAlarm @Marcus
Scenario: VAN18719_Step47_changed value last to next launch SmartMotionAlarm
	Given Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	And click intelligent sensing
	When The 'alarm' drop down list will be hidden or shown 'shown' for SmartMotionAlarm
	#And show 'alarm time' list
	When wait 30 seconds
	When select time option '20 seconds'
	And 'Enable' Enable Feature
	When The 'photo' drop down list will be hidden or shown 'shown' for SmartMotionAlarm
	#And show photo list
	When wait 30 seconds
	And select photo number '15'
	When wait 5 seconds
	And close lenovo vantage
	And ReLaunch Vantage
	And Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	And click intelligent sensing
	Then verify default time is '20 seconds' for Alarm
	And verify default number is '15' for Photo number

@SmartMotionAlarm @Marcus
Scenario: VAN18719_Step48_Step49_Step50_without access to camera, a hint and link display
	Given turn on the Allow apps to access your camera
	#And Launch vantage and go through tutorial with default segment
	And Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	And turn off the Allow apps to access your camera
	When click intelligent sensing
	Then verify Enable Feature toggle is 'disabled'
	#And verify string 'Lenovo Vantage doesn't have access to Camera' displays on Vantage by using json path '$.device.smartAssist.antiTheft.authorizedAccess.describe' to retrieve from resource file
	#And verify string '"Go to Windows Settings to give access' displays on Vantage by using json path '$.device.smartAssist.antiTheft.authorizedAccess.linkText' to retrieve from resource file
	And verify discribe 'noCameraAccess' is 'display'
	And verify link 'Go to Windows Settings to give access' for Camera is 'enabled'
	When click link 'Go to Windows Settings to give access' for camera access
	Then verify Camera access with Settings is launched
	When turn on the Allow apps to access your camera
	Then verify link 'Go to Windows Settings to give access' for Camera is 'gone'
	And verify 'Lenovo Vantage doesn't have access to Camera. The function of the checkbox won't work' is GONE on Vantage
	And verify Enable Feature toggle is 'enabled'

@SmartMotionAlarm @Marcus
Scenario: VAN18719_Step49_without access to camera, a hint and link display
	When Only Print 'Please check TestStep48'

@SmartMotionAlarm @Marcus
Scenario: VAN18719_Step50_without access to camera, a hint and link display
	When Only Print 'Please check TestStep48'

@SmartMotionAlarm @Marcus
Scenario: VAN18719_Step51_Step52_Step53_WithCameraPrivacyOn_CameraAccess
	Given turn on the Allow apps to access your camera
	#And Launch vantage and go through tutorial with default segment
	And Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to My Device Settings page
	And turn on Camera Privacy from Display and Camera page
	And Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	And click intelligent sensing
	Then verify Enable Feature toggle is 'disabled'
	#And verify string 'Lenovo Vantage Camera privacy mode is on' displays on Vantage by using json path '$.device.smartAssist.antiTheft.cameraPrivacy.describe' to retrieve from resource file
	#And verify string '"Go to Camera privacy mode to turn it off' displays on Vantage by using json path '$.device.smartAssist.antiTheft.cameraPrivacy.linkText' to retrieve from resource file
	And verify discribe 'privacyModeOn' is 'display'
	And verify link 'Go to Camera privacy mode to turn it off' is 'enabled'
	When click link 'Go to Camera privacy mode to turn it off'
	Then verify 'Camera Privacy Mode' toggle shows up
	When turn off Camera Privacy from Display and Camera page
	And Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	And click intelligent sensing
	Then verify Enable Feature toggle is 'enabled'
	#And verify string 'Lenovo Vantage Camera privacy mode is on' NOT display on Vantage by using json path '$.device.smartAssist.antiTheft.cameraPrivacy.describe' to retrieve from resource file
	#And verify string '"Go to Camera privacy mode to turn it off' NOT display on Vantage by using json path '$.device.smartAssist.antiTheft.cameraPrivacy.linkText' to retrieve from resource file
	And verify discribe 'privacyModeOn' is 'Not display'
	And verify link 'Go to Camera privacy mode to turn it off' is 'GONE'

@SmartMotionAlarm @Marcus
Scenario: VAN18719_Step52_WithCameraPrivacyOn_CameraAccess
	When Only Print 'Please check TestStep51'

@SmartMotionAlarm @Marcus
Scenario: VAN18719_Step53_WithCameraPrivacyOn_CameraAccess
	When Only Print 'Please check TestStep51'

@SmartMotionAlarm @Marcus 
Scenario: VAN18719_Step54_Step55_WithCameraPrivacyOn_NoCameraAccess
	Given Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to My Device Settings page
	And wait 10 seconds
	And turn on Camera Privacy from Display and Camera page
	And turn off the Allow apps to access your camera
	And Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	And click intelligent sensing
	Then verify Enable Feature toggle is 'disabled'
	#And verify string 'Lenovo Vantage doesn't have access to Camera' displays on Vantage by using json path '$.device.smartAssist.antiTheft.authorizedAccess.describe' to retrieve from resource file
	#And verify string '"Go to Windows Settings to give access' displays on Vantage by using json path '$.device.smartAssist.antiTheft.authorizedAccess.linkText' to retrieve from resource file
	And verify discribe 'noCameraAccess' is 'display'
	And verify link 'Go to Windows Settings to give access' for Camera is 'enabled'
	When click link 'Go to Windows Settings to give access' for camera access
	When turn on the Allow apps to access your camera
	Then verify Enable Feature toggle is 'disabled'
	#And verify string 'Lenovo Vantage Camera privacy mode is on' displays on Vantage by using json path '$.device.smartAssist.antiTheft.cameraPrivacy.describe' to retrieve from resource file
	#And verify string '"Go to Camera privacy mode to turn it off' displays on Vantage by using json path '$.device.smartAssist.antiTheft.cameraPrivacy.linkText' to retrieve from resource file
	And verify discribe 'privacyModeOn' is 'display'
	And verify link 'Go to Camera privacy mode to turn it off' is 'enabled'
	And click link 'Go to Camera privacy mode to turn it off'
	And turn off Camera Privacy from Display and Camera page

@SmartMotionAlarm @Marcus 
Scenario: VAN18719_Step55_WithCameraPrivacyOn_NoCameraAccess
	When Only Print 'Please check TestStep54'

@SmartMotionAlarm @Marcus 
Scenario: VAN18719_Step56_Step57_Step59_WithFSAccess
	Given Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	And click intelligent sensing
	And turn off the Allow apps to access your file system
	When click photo link
	#Then verify string 'Lenovo Vantage doesn't have access to the file system' displays on Vantage by using json path '$.device.smartAssist.antiTheft.fileAuthorizationTips.content' to retrieve from resource file
	#And verify string '"Go to Windows Settings to give access' displays on Vantage by using json path '$.device.smartAssist.antiTheft.fileAuthorizationTips.link' to retrieve from resource file
	Then verify discribe 'noFileAccess' is 'display'
	And verify link 'Go to Windows Settings to give access' for FileSystem is 'enabled'
	When click link 'Go to Windows Settings to give access' for file system access
	#Then verify string 'Lenovo Vantage doesn't have access to the file system' NOT display on Vantage by using json path '$.device.smartAssist.antiTheft.fileAuthorizationTips.content' to retrieve from resource file	
	Then verify discribe 'noFileAccess' is 'Not display'
	And verify link 'Go to Windows Settings to give access' for FileSystem is 'GONE'
	When turn on the Allow apps to access your file system
	And ensure no 'public\pictures' folder is open
	When click photo link
	Then verify photo folder is open
	And ensure no 'public\pictures' folder is open

@SmartMotionAlarm @Marcus 
Scenario: VAN18719_Step57_WithFSAccess
	When Only Print 'Please check TestStep56'

@SmartMotionAlarm
Scenario: VAN18719_Step58_FSAccess
	Given Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	And click intelligent sensing
	And turn off the Allow apps to access your file system
	And click photo link
	When turn on the Allow apps to access your file system
	And Go to Support page
	And Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	And click intelligent sensing
	#Then verify string 'Lenovo Vantage doesn't have access to the file system' NOT display on Vantage by using json path '$.device.smartAssist.antiTheft.fileAuthorizationTips.content' to retrieve from resource file	
	And verify discribe 'noCameraAccess' is 'Not display'
	And verify link 'Go to Windows Settings to give access' for FileSystem is 'GONE'

@SmartMotionAlarm @Marcus 
Scenario: VAN18719_Step59_WithFSAccess
	When Only Print 'Please check TestStep56'

#@SmartMotionAlarm @Marcus
#Scenario: VAN18719_Step60_Metrics_01_ResetDefault
#	Given Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
#	And Go to Smart Assist page
#	And click intelligent sensing
#	And toggle 'On' for Smart Motion Alarm
#	When The 'alarm' drop down list will be hidden or shown 'shown' for SmartMotionAlarm
#	#And show 'alarm time' list
#	When select time option '10 seconds'
#	And 'Enable' Enable Feature
#	When The 'photo' drop down list will be hidden or shown 'shown' for SmartMotionAlarm
#	#And show photo list
#	And select photo number '5'
#	And toggle 'Off' for Smart Motion Alarm
#    Given Set Metric on
#	And Launch Http Traffic Capturer
#	And Start Capture 

#@SmartMotionAlarm @Marcus
#Scenario: VAN18719_Step60_Metrics_02
#	Given Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
#	And Go to Smart Assist page
#	When click intelligent sensing
#	Then the metric data is as expected with Test VAN18719 and Name IntelligentSensing and Timeout 20
#	When toggle 'On' for Smart Motion Alarm
#	Then the metric data is as expected with Test VAN18719 and Name SmartAlarmToggleOn and Timeout 20
#	When toggle 'Off' for Smart Motion Alarm
#	Then the metric data is as expected with Test VAN18719 and Name SmartAlarmToggleOff and Timeout 20
#	And  toggle 'On' for Smart Motion Alarm
#	When The 'alarm' drop down list will be hidden or shown 'shown' for SmartMotionAlarm
#	#And show 'alarm time' list
#	When select time option '20 seconds'
#	Then the metric data is as expected with Test VAN18719 and Name SmartAlarmTime20S and Timeout 20
#	When The 'alarm' drop down list will be hidden or shown 'shown' for SmartMotionAlarm
#	#And show 'alarm time' list
#	When select time option '10 seconds'
#	Then the metric data is as expected with Test VAN18719 and Name SmartAlarmTime10S and Timeout 20
#	When The 'alarm' drop down list will be hidden or shown 'shown' for SmartMotionAlarm
#	#And show 'alarm time' list
#	When select time option '30 seconds'
#	Then the metric data is as expected with Test VAN18719 and Name SmartAlarmTime30S and Timeout 20
#	When The 'alarm' drop down list will be hidden or shown 'shown' for SmartMotionAlarm
#	#And show 'alarm time' list
#	When select time option '1 minute'
#	Then the metric data is as expected with Test VAN18719 and Name SmartAlarmTime1M and Timeout 20
#	When The 'alarm' drop down list will be hidden or shown 'shown' for SmartMotionAlarm
#	#And show 'alarm time' list
#	When select time option 'Never stop'
#	Then the metric data is as expected with Test VAN18719 and Name SmartAlarmTimeNever and Timeout 20
#	When 'Disable' Enable Feature
#	Then the metric data is as expected with Test VAN18719 and Name SmartAlarmEnablePhotoOff and Timeout 20
#	When 'Enable' Enable Feature
#	Then the metric data is as expected with Test VAN18719 and Name SmartAlarmEnablePhotoOn and Timeout 20
#	When The 'photo' drop down list will be hidden or shown 'shown' for SmartMotionAlarm
#	#And show photo list
#	And select photo number '10'
#	Then the metric data is as expected with Test VAN18719 and Name SmartAlarmPhotoNumber10 and Timeout 20
#	When The 'photo' drop down list will be hidden or shown 'shown' for SmartMotionAlarm
#	#And show photo list
#	And select photo number '5'
#	Then the metric data is as expected with Test VAN18719 and Name SmartAlarmPhotoNumber5 and Timeout 20
#	When The 'photo' drop down list will be hidden or shown 'shown' for SmartMotionAlarm
#	#And show photo list
#	And select photo number '15'
#	Then the metric data is as expected with Test VAN18719 and Name SmartAlarmPhotoNumber15 and Timeout 20
#	When The 'photo' drop down list will be hidden or shown 'shown' for SmartMotionAlarm
#	#And show photo list
#	And select photo number '20'
#	Then the metric data is as expected with Test VAN18719 and Name SmartAlarmPhotoNumber20 and Timeout 20
#	When The 'photo' drop down list will be hidden or shown 'shown' for SmartMotionAlarm
#	#And show photo list
#	And select photo number '25'
#	Then the metric data is as expected with Test VAN18719 and Name SmartAlarmPhotoNumber25 and Timeout 20
#	When The 'photo' drop down list will be hidden or shown 'shown' for SmartMotionAlarm
#	#And show photo list
#	And select photo number '30'
#	Then the metric data is as expected with Test VAN18719 and Name SmartAlarmPhotoNumber30 and Timeout 20
	
#@SmartMotionAlarm @Marcus
#Scenario: VAN18719_Step60_Metrics_03
#	Given Stop Capture