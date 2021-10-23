Feature: VAN27994_Part2_OSToolbarRegressionTest
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-27994
	Author： Haiye Li
	Conmments: TestStep51-100

Background:
	Given Turn on or off the narrator 'on'

@OSMicrophoneToolbar
Scenario: VAN27994_TestStep51_The microhone display off status
	Given Machine support microphone
	Given Toolbar has been pin to Taskbar
	Given Turn on microphone access
	Given Close Toolbar Background
	Given Go to dashboad page
	Given Turn off microphone from dashboad
	Given Launch Toolbar On NewOS
	Then The microhone display off status

@OSMicrophoneToolbar
Scenario: VAN27994_TestStep52_The Microphone button display on status
	Given Machine support microphone
	Given Toolbar has been pin to Taskbar
	Given Turn on microphone access
	Given Close Toolbar Background
	Given Go to audio section
	Given Go to Microphone Panel
	When  turn on the microphone toggle
	Then  the microphonr toggle is on
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	Then The microhone display on status
	
@OSMicrophoneToolbar
Scenario: VAN27994_TestStep53_The Microphone button display off status
	Given Machine support microphone
	Given Toolbar has been pin to Taskbar
	Given Turn on microphone access
	Given Close Toolbar Background
	Given Go to audio section
	Given Go to Microphone Panel
	When  turn off the microphone toggle
	Then  the microphonr toggle is off
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	Then The microhone display off status

@OSMicrophoneToolbar @OSRequireNoVantage
Scenario: VAN27994_TestStep54_doesn't display the Microphone button on toolbar
	Given Machine support microphone
	Given Toolbar has been pin to Taskbar
	Given Turn on microphone access
	When disable the Microphone driver
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	Then The microhone button doesn't display on toolbar 

@OSMicrophoneToolbar @OSRequireNoVantage
Scenario: VAN27994_TestStep55_The Microphone status displayed according to driver feedback
	Given Machine support microphone
	Given Toolbar has been pin to Taskbar
	Given Turn on microphone access
	When disable the Microphone driver
	When enable the Microphone driver
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	Then The microhone button display on toolbar 

@OSMicrophoneToolbar 
Scenario: VAN27994_TestStep56_Jump to Audio page
	Given Machine support microphone
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	When Turn on microphone from toolbar
	Given Turn off microphone access
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	When Click microphone button on toolbar
	Then My Device settings-Audio page is opened

@OSMicrophoneToolbar 
Scenario: VAN27994_TestStep57_The button status displayed same as Before
	Given Machine support microphone
	Given Toolbar has been pin to Taskbar
	Given Turn on microphone access
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	When Turn on microphone from toolbar
	Given Turn off microphone access
	Given Turn on microphone access
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	Then The microhone button display on toolbar 

@OSECourseToolbar
Scenario: VAN27994_TestStep58_Check Interactive E-course mode button displays same as with Vantage
	Given check the ECourse Feature on the supported system
	#Given turn on narrator
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Waiting 10 seconds
	Then E-course mode button displays same as with Vantage
	#Then turn off narrator
	Given Turn on or off the narrator 'off'

@OSECourseToolbar
Scenario: VAN27994_TestStep59_Check the Interactive E-course tips
	Given check the ECourse Feature on the supported system
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Click batterydetails button on toolbar
	When Hover the mouse on the button ECourse
	Then Take Screen Shot 59CheckTiprECourse in 27994 under HSScreenShotResult

@OSECourseToolbar
Scenario: VAN27994_TestStep60_Check the Interactive E-course display on status
	Given check the ECourse Feature on the supported system
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Waiting 10 seconds
	When Turn on or off the ECourse toggle within toolbar 'on'
	Then the ECourse toggle status is on or off within toolbar 'on'
	Given Turn on or off the narrator 'off'

@OSECourseToolbar
Scenario: VAN27994_TestStep61_Check the Interactive E-course display
	Given check the ECourse Feature on the supported system
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Waiting 10 seconds
	When Turn on or off the ECourse toggle within toolbar 'off'
	When Turn on or off the ECourse toggle within toolbar 'on'
	Then Take screen shot 61CheckTiprECourse_On in 27994 under HSScreenShotResult after 0 seconds
	Given Turn on or off the narrator 'off'

@OSECourseToolbar
Scenario: VAN27994_TestStep62_Check the Interactive E-course display on status
	Given check the ECourse Feature on the supported system
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Waiting 10 seconds
	When Turn on or off the ECourse toggle within toolbar 'on'
	Given Close Toolbar Background
	Given go to Audio page
	Given Jump to audio smart settings section
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	| E-Course    | on            |
	Given Turn on or off the narrator 'off'

@OSECourseToolbar
Scenario: VAN27994_TestStep63_Check the Interactive E-course does not display
	Given check the ECourse Feature on the supported system
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Waiting 10 seconds
	When Turn on or off the ECourse toggle within toolbar 'on'
	When Turn on or off the Dolby Audio button within Dolby Audio app 'off'
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	Then The 'ECourse' function shown or hidden 'hidden' within toolbar
	Given Turn on or off the narrator 'off'

@OSECourseToolbar
Scenario: VAN27994_TestStep64_Check the Interactive E-course status is off
	Given Close Toolbar Background
	Given check the ECourse Feature on the supported system
	When Turn on or off the Dolby Audio button within Dolby Audio app 'on'
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on or off the ECourse toggle within toolbar 'on'
	When Turn on or off the Dolby Audio button within Dolby Audio app 'off'
	When Turn on or off the Dolby Audio button within Dolby Audio app 'on'
	Given Launch Toolbar On NewOS
	Given Waiting 10 seconds
	When Turn on or off the ECourse toggle within toolbar 'off'
	Given Turn on or off the narrator 'off'

@OSECourseToolbar
Scenario: VAN27994_TestStep65_Check the Interactive E-course status is off
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Waiting 10 seconds
	When Turn on or off the ECourse toggle within toolbar 'off'
	Then the ECourse toggle status is on or off within toolbar 'off'
	Given Turn on or off the narrator 'off'

@OSECourseToolbar
Scenario: VAN27994_TestStep66_Check the Interactive E-course display
	Given check the ECourse Feature on the supported system
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Waiting 10 seconds
	When Turn on or off the ECourse toggle within toolbar 'on'
	When Turn on or off the ECourse toggle within toolbar 'off'
	Then Take screen shot 66CheckTiprECourse_Off in 27994 under HSScreenShotResult after 0 seconds
	Given Turn on or off the narrator 'off'

@OSECourseToolbar
Scenario: VAN27994_TestStep67_Check the Interactive E-course display off
	Given check the ECourse Feature on the supported system
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Waiting 10 seconds
	When Turn on or off the ECourse toggle within toolbar 'off'
	Given Close Toolbar Background
	Given go to Audio page
	Given Jump to audio smart settings section
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	| E-Course    | off           |
	Given Turn on or off the narrator 'off'

@OSECourseToolbar
Scenario: VAN27994_TestStep68_Check the Interactive E-course status is off
	Given check the ECourse Feature on the supported system
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Waiting 10 seconds
	When Turn on or off the ECourse toggle within toolbar 'off'
	Given Close Toolbar Background
	Given go to Audio page
	Given Jump to audio smart settings section
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Dolby audio | on            |
	Given Launch Toolbar On NewOS
	Given Waiting 10 seconds
	Then the ECourse toggle status is on or off within toolbar 'off'
	Given Turn on or off the narrator 'off'

@OSECourseToolbar
Scenario: VAN27994_TestStep69_Check the Interactive E-course status is on
	Given check the ECourse Feature on the supported system
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given go to Audio page
	Given Jump to audio smart settings section
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| E-Course    | on            |
	Given Launch Toolbar On NewOS
	Given Waiting 10 seconds
	Then the ECourse toggle status is on or off within toolbar 'on'
	Given Turn on or off the narrator 'off'

@OSECourseToolbar
Scenario: VAN27994_TestStep70_Check the Interactive E-course status is off
	Given check the ECourse Feature on the supported system
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Waiting 10 seconds
	When Turn on or off the ECourse toggle within toolbar 'on'
	Given Close Toolbar Background
	Given go to Audio page
	Given Jump to audio smart settings section
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| E-Course    | off           |
	Given Launch Toolbar On NewOS
	Given Waiting 10 seconds
	Then the ECourse toggle status is on or off within toolbar 'off'
	Given Turn on or off the narrator 'off'
	Given Close Toolbar Background

@OSCameraToolbar 
Scenario: VAN27994_TestStep71_The Camera privacy mode button displays same as with Vantage Settings Page
	Given Toolbar has been pin to Taskbar
	Given turn on the Allow access to the camera toggle on this device
	Given turn off Lenovo Vantage permission for Camera from system settings
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	When turn on Camera Privacy from Toolbar
	Then The Camera privacy mode button on displays same as with Vantage Settings Page

@OSCameraToolbar
Scenario: VAN27994_TestStep72_The hover tips display is "Camera privacy mode"
	Given Toolbar has been pin to Taskbar
	Given turn on the Allow access to the camera toggle on this device
	Given Launch Toolbar On NewOS
	When turn on Camera Privacy from Toolbar
	When Hover the mouse on the button Camera
	When Take Screen Shot TestStep72_Tips_Camera_privacy_mode_on in 27994 under ToolbarScreenShotResult
	When turn off Camera Privacy from Toolbar
	When Hover the mouse on the button Camera
	When Take Screen Shot TestStep72_Tips_Camera_privacy_mode_off in 27994 under ToolbarScreenShotResult

@OSCameraToolbar 
Scenario: VAN27994_TestStep73_The Camera privacy display on status
	Given Toolbar has been pin to Taskbar
	Given turn on the Allow access to the camera toggle on this device
	When turn on Camera Privacy from Toolbar
	Then The camera button display on status from toolbar

@OSCameraToolbar 
Scenario: VAN27994_TestStep74_The text display is "Camera privacy mode on",The text info is displayed in the middle
	Given Toolbar has been pin to Taskbar
	Given turn on the Allow access to the camera toggle on this device
	When turn on Camera Privacy from Toolbar
	When Take screen shot TestStep74_textDisplayCameraCameraPrivacyModeOn in 27994 under ToolbarScreenShotResult after 0 seconds

@OSCameraToolbar 
Scenario: VAN27994_TestStep75_The Camera privacy display off status
	Given Toolbar has been pin to Taskbar
	Given turn on the Allow access to the camera toggle on this device
	When turn off Camera Privacy from Toolbar
	Then The camera button display off status from toolbar

@OSCameraToolbar 
Scenario: VAN27994_TestStep76_The text display is "Camera privacy mode off"
	Given Toolbar has been pin to Taskbar
	Given turn on the Allow access to the camera toggle on this device
	When turn on Camera Privacy from Toolbar
	When turn off Camera Privacy from Toolbar
	When Take screen shot TestStep72_textDisplayCameraCameraPrivacyModeOff in 27994 under ToolbarScreenShotResult after 0 seconds

@OSCameraToolbar 
Scenario: VAN27994_TestStep77_The Camera privacy display on status on vantage display page
	Given Toolbar has been pin to Taskbar
	Given turn on the Allow access to the camera toggle on this device
	When turn on Camera Privacy from Toolbar
	Given Close Toolbar Background
	When Go to display page
	Then The Camera privacy display on status from vantage display page

@OSCameraToolbar 
Scenario: VAN27994_TestStep78_The Camera privacy display on status from toolbar
	Given Toolbar has been pin to Taskbar
	Given turn on the Allow access to the camera toggle on this device
	Given Close Toolbar Background
	When Go to display page
	Given turn off Camera Privacy from Display and Camera page
	Given Launch Toolbar On NewOS
	Then The camera button display off status from toolbar

@OSCameraToolbar 
Scenario: VAN27994_TestStep79_The Camera privacy display on status on dashboard page
	Given Toolbar has been pin to Taskbar
	Given turn on the Allow access to the camera toggle on this device
	Given Launch Toolbar On NewOS
	When turn on Camera Privacy from Toolbar
	Given Close Toolbar Background
	Given Go to dashboad page
	Then The Camera privacy display on status on dashboard page

@OSCameraToolbar 
Scenario: VAN27994_TestStep80_The Camera privacy mode doesn't display
	Given Toolbar has been pin to Taskbar
	Given turn on the Allow access to the camera toggle on this device
	Given disable camera driver
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	Then The camera button doesn't display on toolbar

@OSCameraToolbar 
Scenario: VAN27994_TestStep81_The Camera privacy display on status
	Given Toolbar has been pin to Taskbar
	Given enable camera driver
	Given turn on the Allow access to the camera toggle on this device
	When turn on Camera Privacy from Toolbar
	Given disable camera driver
	Given enable camera driver
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	Then The camera button display on status from toolbar

@OSCameraToolbar 
Scenario: VAN27994_TestStep82_jump to Camera&display page
	Given Toolbar has been pin to Taskbar
	Given turn off the Allow access to the camera toggle on this device
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	When Click camera button on toolbar
	Then My Device settings Display page is opened

@OSTopRowToolbarIdea
Scenario: VAN27994_TestStep83_the Top-row function button status is displayed same as Vantage
	Given Toolbar has been pin to Taskbar
	Given Go to input page
	Given Launch Toolbar On NewOS
	Then the Top-row function button status is displayed same as Vantage for ideapad

@OSTopRowToolbarIdea
Scenario: VAN27994_TestStep84_The button display Special function statue on toolbar
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on Special function from toolbar
	Then The Top-row function button display Special function status on toolbar

@OSTopRowToolbarIdea
Scenario: VAN27994_TestStep85_The text display is "Special function enabled" and the text info is displayed in the middle
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on F1-F12 function from toolbar
	When Turn on Special function from toolbar
	Then Take screen shot TestStep85_textDisplaySpecialFunctionEnabled in 27994 under ToolbarScreenShotResult after 0 seconds

@OSTopRowToolbarIdea
	Scenario: VAN27994_TestStep86_the text display is "Keyboard top-row function"
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Hover the mouse on the button TopRowKey
	Then Take Screen Shot TestStep86_Hovertext_KeyboardTopRowisSpecialFunction in 27994 under ToolbarScreenShotResult

@OSTopRowToolbarIdea
Scenario: VAN27994_TestStep87_The Top-row function button display Special function status on vantage input page
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on Special function from toolbar
	Given Go to input page
	Then The Top-row function button display Special function status on vantage input page for ideapad

@OSTopRowToolbarIdea
Scenario: VAN27994_TestStep88_The button display F1-F12 function statue on toolbar
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on F1-F12 function from toolbar
	Then The Top-row function button display F1-F12 function status on toolbar

@OSTopRowToolbarIdea 
Scenario: VAN27994_TestStep89_The text display is "F1-F12 function enabled" and the text info is displayed in the middle
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on Special function from toolbar
	When Turn on F1-F12 function from toolbar
	Then Take screen shot TestStep89_textDisplayFnFunctionEnabled in 27994 under ToolbarScreenShotResult after 0 seconds

@OSTopRowToolbarIdea 
Scenario: VAN27994_TestStep90_the text display is "Keyboard top-row function"
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Hover the mouse on the button TopRowKey
	Then Take Screen Shot TestStep90_textDisplay_KeyboardTopRowisF1-F12 in 27994 under ToolbarScreenShotResult

@OSTopRowToolbarIdea 
Scenario: VAN27994_TestStep91_The button display F1-F12 function statue on vantage input page
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on F1-F12 function from toolbar
	Given Close toolbar
	Given Go to input page
	Then The Top-row function button display F1-F12 function status on vantage input page for ideapad

@OSTopRowToolbarIdea 
Scenario: VAN27994_TestStep92_The button display Special function statue on vantage input page
	Given Toolbar has been pin to Taskbar
	Given Go to input page
	When Turn on Special function on vantage input page for ideapad
	Given Launch Toolbar On NewOS
	Then The Top-row function button display Special function status on toolbar

@OSTopRowToolbarIdea 
Scenario: VAN27994_TestStep93_The button display F1-F12 function statue on vantage input page
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Go to input page
	When Turn on F1-F12 function on vantage input page for ideapad
	Given Launch Toolbar On NewOS
	Then The Top-row function button display F1-F12 function status on toolbar

@OSTopRowToolbarThinkpad
Scenario: VAN27994_TestStep94_the Top-row function button status is displayed same as Vantage
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is off
	Given turn on Normal method
	When Turn on F1-F12 function on vantage input page 
	Given Launch Toolbar On NewOS
	#Then the Top-row function button status is displayed same as Vantage

@OSTopRowToolbarThinkpad 
Scenario: VAN27994_TestStep95_The button display Special function statue on toolbar
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is off
	Given turn on Normal method
	When Turn on F1-F12 function on vantage input page 
	Given Launch Toolbar On NewOS
	When Turn on Special function from toolbar
	Then The Top-row function button display Special function status on toolbar

@OSTopRowToolbarThinkpad 
Scenario: VAN27994_TestStep96_The text display is "Special function enabled" and the text info is displayed in the middle
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is off
	Given turn on Normal method
	When Turn on F1-F12 function on vantage input page 
	Given Launch Toolbar On NewOS
	When Turn on Special function from toolbar
	Then Take screen shot TestStep96_textDisplaySpecialFunctionEnabled in 27994 under ToolbarScreenShotResult after 0 seconds

@OSTopRowToolbarThinkpad 
Scenario: VAN27994_TestStep97_the text display is "Keyboard top-row function"
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is off
	Given turn on Normal method
	Given Launch Toolbar On NewOS
	When Turn on Special function from toolbar
	When Hover the mouse on the button TopRowKey
	Then Take Screen Shot TestStep97_tipDisplaySpecialFunction in 27994 under ToolbarScreenShotResult
	
@OSTopRowToolbarThinkpad 
Scenario: VAN27994_TestStep98_The button display Special function statue on toolbar
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is off
	Given turn on Normal method
	Given Launch Toolbar On NewOS
	When Turn on Special function from toolbar
	Then The Top-row function button display Special function status on toolbar
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	Then The Top-row function button display Special function status on toolbar

@OSTopRowToolbarThinkpad 
Scenario: VAN27994_TestStep99_The button display Special function statue on vantage input page
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is off
	Given turn on Normal method
	Given Launch Toolbar On NewOS
	When Turn on F1-F12 function from toolbar
	When Turn on Special function from toolbar
	Given Close Toolbar Background
	Given Go to display page
	Given Go to input page
	Then The Top-row function button display Special function status on vantage input page

@OSTopRowToolbarThinkpad 
Scenario: VAN27994_TestStep100_The button display F1-F12 function status on toolbar
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is off
	Given turn on Normal method
	Given Launch Toolbar On NewOS
	When Turn on F1-F12 function from toolbar
	Then The Top-row function button display F1-F12 function status on toolbar
