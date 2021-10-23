Feature: VAN10210_Part2_ToolbarRegressionTest
	Test Case： https://jira.tc.lenovo.com/browse/VAN-10210
	Author： HaiYe Li Jinglong Zhao
	Update: Pengjie Chen
	Comments: TestStep41-80  / HaiYe Li (TestStep65-66)

Background:
	#Given turn on narrator
	Given Turn on or off the narrator 'on'

#@WifiToolbar
Scenario: VAN10210_TestStep041_The text display is wifi security off
	Given Machine support WIFISecurity
	Given Pin toolbar to taskbar
	Given Turn on permission
	When Launch toolbar
	When Turn on wifi security from toolbar
	When Turn off wifi security from toolbar
	Then Take screen shot TestStep42 in 10210 under HSScreenShotResult after 0 seconds

#@WifiToolbar
Scenario: VAN10210_TestStep042_The Wi-Fi Security button display off status
	Given Machine support WIFISecurity
	Given Pin toolbar to taskbar
	Given Turn on permission
	When Launch toolbar
	When Turn off wifi security from toolbar
	When Get wifi security status from toolbar
	Given Go to Wifisecurity
	Then The Wi-fi security button displays same as with Vantage

#@WifiToolbar
Scenario: VAN10210_TestStep043_The wifi security button display off status
	Given Machine support WIFISecurity
	Given Pin toolbar to taskbar
	Given Turn on permission
	Given Go to Wifisecurity
	When Turn on wifi security from vantage
	When Launch toolbar
	Then The wifi security display on status

#@WifiToolbar
Scenario: VAN10210_TestStep044_The wifi security button display on status
	Given Machine support WIFISecurity
	Given Pin toolbar to taskbar
	Given Turn on permission
	Given Go to Wifisecurity
	When Turn off wifi security from vantage
	When Launch toolbar
	Then The wifi security display off status

#@WifiToolbar
Scenario: VAN10210_TestStep045_The wifi security button display off status
	Given Machine support WIFISecurity
	Given Pin toolbar to taskbar
	Given Turn on permission
	Given Turn off permission
	When Launch toolbar
	Then The wifi security display off status

#@WifiToolbar
Scenario: VAN10210_TestStep046_Turn off permission click wifi security jump to wifi security page
	Given Machine support WIFISecurity
	Given Pin toolbar to taskbar
	Given Turn off permission
	When Launch toolbar
	When Click wifi security from toolbar
	When Click close in the security pop-up box
	Then Click wifi security jump to wifi security page

#@WifiToolbar
Scenario: VAN10210_TestStep047_The wifi security display on status
	Given Machine support WIFISecurity
	Given Pin toolbar to taskbar
	Given Turn off permission
	When Launch toolbar
	When Click wifi security from toolbar
	When Turn on wifi security from vantage
	When wait 5 seconds
	When Click Agreee in the security pop-up box
	Given Turn on permission
	When Launch toolbar
	Then The wifi security display on status

#@WifiToolbar
Scenario: VAN10210_TestStep048_Jump to the wifi security page
	Given Machine support WIFISecurity
	Given Pin toolbar to taskbar
	Given Turn on permission
	When Launch toolbar
	When Turn on wifi security from toolbar
	Given Turn off permission
	When Launch toolbar
	When Click wifi security from toolbar
	When Click close in the security pop-up box
	Then Click wifi security jump to wifi security page

#@WifiToolbar
Scenario: VAN10210_TestStep049_The wifi security display on status
	Given Machine support WIFISecurity
	Given Pin toolbar to taskbar
	Given Turn on permission
	When Launch toolbar
	When Turn on wifi security from toolbar
	Given Turn off permission
	Given Turn on permission
	When Launch toolbar
	Then The wifi security display on status

#@WifiToolbar
Scenario: VAN10210_TestStep050_The wifi security display off status
	Given Machine support WIFISecurity
	Given Pin toolbar to taskbar
	Given Turn off permission
	When Launch toolbar
	When Click wifi security from toolbar
	When Click close in the security pop-up box
	When Launch toolbar
	Then The wifi security display off status

@Toolbar
Scenario: VAN10210_TestStep051_Check close toolbar by click x button
	When pin toolbar on Taskbar settings
	When Launch toolbar 
	And Click the battery gauge x button
	Then toolbar close button should hide
	And the toolbar pin to taskbar

#@WifiToolbar
Scenario: VAN10210_TestStep052_The wifi security display on status
	Given Machine support WIFISecurity
	Given Pin toolbar to taskbar
	Given Turn on permission
	Given Clean toast history
	Given Go to Wifisecurity
	When Turn on wifi security from vantage
	When Turn off wifi security from vantage
	When Click the toast and turn on wifi security
	When Launch toolbar
	Then The wifi security display on status
	Then Close toolbar

#@WifiToolbar
Scenario: VAN10210_TestStep053_Jump to store page
	Given Machine support WIFISecurity
	Given Pin toolbar to taskbar
	Given Uninstall the lenovo vatage
	When Launch toolbar
	When Click wifi security from toolbar
	Then Take Screen Shot TestStep53 in 10210 under HSScreenShotResult
	Given Install Vantage

@MicrophoneToolbar
Scenario: VAN10210_TestStep054_The microphone button displays same as with Vantage
	Given Machine support microphone
	Given Pin toolbar to taskbar
	Given Turn on microphone access
	When Launch toolbar
	When Get microphone status from toolbar
	Given go to Audio section
	When Jump to microphone
	Then The microphone button displays same as with Vantage

@MicrophoneToolbar
Scenario: VAN10210_TestStep055_The hover tips display is "Microphone"
	Given Machine support microphone
	Given Pin toolbar to taskbar
	Given Turn on microphone access
	When Launch toolbar
	When Turn off microphone from toolbar
	When Turn on microphone from toolbar
	When Close toolbar
	When Launch toolbar
	When Hover the mouse on the button microphone
	Then Take Screen Shot TestStep55on in 10210 under HSScreenShotResult
	When Launch toolbar
	When Turn off microphone from toolbar
	When Close toolbar
	When Launch toolbar
	When Hover the mouse on the button microphone
	Then Take Screen Shot TestStep55off in 10210 under HSScreenShotResult

@MicrophoneToolbar
Scenario:  VAN10210_TestStep056_The text display is "Microphone on",The text info is displayed in the middle
	Given Machine support microphone
	Given Pin toolbar to taskbar
	Given Turn on microphone access
	When Launch toolbar
	When Turn off microphone from toolbar
	When Turn on microphone from toolbar
	Then Take screen shot TestStep56 in 10210 under HSScreenShotResult after 0 seconds

@MicrophoneToolbar
Scenario:  VAN10210_TestStep057_The microphone button displays same as with Vantage
	Given Machine support microphone
	Given Pin toolbar to taskbar
	Given Turn on microphone access
	When Launch toolbar
	When Turn on microphone from toolbar
	When Get microphone status from toolbar
	Given go to Audio section
	Then The microphone button displays same as with Vantage

@MicrophoneToolbar
Scenario: VAN10210_TestStep058_The microphone button displays same as with vantage dashboard
	Given Machine support microphone
	Given Pin toolbar to taskbar
	Given Turn on microphone access
	When Launch toolbar
	When Turn on microphone from toolbar
	When Get microphone status from toolbar
	Given Go to dashboad page
	Then The microphone button displays same as with Vantage dashboard

@MicrophoneToolbar
Scenario: VAN10210_TestStep059_The microphone display off status
	Given Machine support microphone
	Given Pin toolbar to taskbar
	Given Turn on microphone access
	When Launch toolbar
	When Turn off microphone from toolbar
	Then The microhone display off status

@MicrophoneToolbar
Scenario: VAN10210_TestStep060_The text display is "Microphone off",The text info is displayed in the middle
	Given Machine support microphone
	Given Pin toolbar to taskbar
	Given Turn on microphone access
	When Launch toolbar
	When Turn on microphone from toolbar
	When Turn off microphone from toolbar
	Then Take screen shot TestStep61 in 10210 under HSScreenShotResult after 0 seconds

@MicrophoneToolbar
Scenario: VAN10210_TestStep061_The microphone display off status
	Given Machine support microphone
	Given Pin toolbar to taskbar
	Given Turn on microphone access
	When Launch toolbar
	When Turn off microphone from toolbar
	When Get microphone status from toolbar
	Given Go to audio section
	Then The microphone button displays same as with Vantage

@MicrophoneToolbar
Scenario: VAN10210_TestStep062_The microphone button displays same as with vantage dashboard
	Given Machine support microphone
	Given Pin toolbar to taskbar
	Given Turn on microphone access
	When Launch toolbar
	When Turn off microphone from toolbar
	When Get microphone status from toolbar
	Given Go to dashboad page
	Then The microphone button off displays same as with Vantage dashboard

@MicrophoneToolbar
Scenario: VAN10210_TestStep063_The microphone display on status
	Given Machine support microphone
	Given Pin toolbar to taskbar
	Given Turn on microphone access
	Given Go to dashboad page
	Given Turn on microphone from dashboad
	Then Click Toolbar
	Then The microhone display on status

@MicrophoneToolbar
Scenario: VAN10210_TestStep064_The microhone display off status
	Given Machine support microphone
	Given Pin toolbar to taskbar
	Given Turn on microphone access
	Given Go to dashboad page
	Given Turn off microphone from dashboad
	Then Click Toolbar
	Then The microhone display off status

@MicrophoneToolbar
Scenario: VAN10210_TestStep065_The Microphone button display on status
	Given Machine support microphone
	Given Pin toolbar to taskbar
	Given Turn on microphone access
	Given Go to audio section
	Given Go to Microphone Panel
	When  turn on the microphone toggle
	Then  the microphonr toggle is on
	
@MicrophoneToolbar
Scenario: VAN10210_TestStep066_The Microphone button display off status
	Given Machine support microphone
	Given Pin toolbar to taskbar
	Given Turn on microphone access
	Given Go to audio section
	Given Go to Microphone Panel
	When  turn off the microphone toggle
	Then  the microphonr toggle is off

@MicrophoneToolbar @RequireNoVantage
Scenario: VAN10210_TestStep067_doesn't display the Microphone button on toolbar
	Given Machine support microphone
	Given Pin toolbar to taskbar
	Given Turn on microphone access
	When Launch toolbar
	When disable the Microphone driver
	And Launch toolbar
	Then The microhone button doesn't display on toolbar 

@MicrophoneToolbar @RequireNoVantage
Scenario: VAN10210_TestStep068_The Microphone status displayed according to driver feedback
	Given Machine support microphone
	Given Pin toolbar to taskbar
	Given Turn on microphone access
	When disable the Microphone driver
	When Launch toolbar
	Then The microhone button doesn't display on toolbar 
	When enable the Microphone driver
	When Launch toolbar
	Then The microhone button display on toolbar 

@MicrophoneToolbar 
Scenario: VAN10210_TestStep069_Jump to Audio page
	Given Machine support microphone
	Given Pin toolbar to taskbar
	Given Launch toolbar
	When Turn off microphone from toolbar
	Given Turn off microphone access
	When Launch toolbar
	When Click microphone button on toolbar
	Then My Device settings-Audio page is opened

@MicrophoneToolbar 
Scenario: VAN10210_TestStep070_01_The button status displayed same as Before
	Given Machine support microphone
	Given Pin toolbar to taskbar
	Given Turn on microphone access
	When Launch toolbar
	When Record microphone status get from toolbar
	Given Uninstall the lenovo vatage
	When Launch toolbar
	Then The microphone button status displayed same as Before

@MicrophoneToolbar 
Scenario: VAN10210_TestStep070_02_Resandbox
	Given Install Vantage

@ECourseToolbar
Scenario: VAN10210_TestStep071_Check Interactive E-course mode button displays same as with Vantage
	Given check the ECourse Feature on the supported system
	#Given turn on narrator
	Given Pin toolbar to taskbar
	Given launch toolbar
	Given Waiting 10 seconds
	Then E-course mode button displays same as with Vantage
	#Then turn off narrator
	Given Turn on or off the narrator 'off'

@ECourseToolbar
Scenario: VAN10210_TestStep072_Check the Interactive E-course tips
	Given check the ECourse Feature on the supported system
	Given Pin toolbar to taskbar
	Given launch toolbar
	When Hover the mouse on the button ECourse
	Then Take Screen Shot VAN10210_TestStep072 in 10210 under HSScreenShotResult

@ECourseToolbar
Scenario: VAN10210_TestStep073_Check the Interactive E-course display on status
	Given check the ECourse Feature on the supported system
	Given Pin toolbar to taskbar
	Given launch toolbar
	Given Waiting 10 seconds
	When Turn on or off the ECourse toggle within toolbar 'on'
	Then the ECourse toggle status is on or off within toolbar 'on'
	Given Turn on or off the narrator 'off'

@ECourseToolbar
Scenario: VAN10210_TestStep074_Check the Interactive E-course display
	Given check the ECourse Feature on the supported system
	Given Pin toolbar to taskbar
	Given launch toolbar
	Given Waiting 10 seconds
	When Turn on or off the ECourse toggle within toolbar 'off'
	When Turn on or off the ECourse toggle within toolbar 'on'
	Then Take screen shot VAN10210_TestStep074 in 10210 under HSScreenShotResult after 0 seconds
	Given Turn on or off the narrator 'off'

@ECourseToolbar
Scenario: VAN10210_TestStep075_Check the Interactive E-course display on status
	Given check the ECourse Feature on the supported system
	Given Pin toolbar to taskbar
	Given launch toolbar
	Given Waiting 10 seconds
	When Turn on or off the ECourse toggle within toolbar 'on'
	Given go to Audio page
	Given Jump to audio smart settings section
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	| E-Course    | on            |
	Given Turn on or off the narrator 'off'

@ECourseToolbar
Scenario: VAN10210_TestStep076_Check the Interactive E-course does not display
	Given check the ECourse Feature on the supported system
	Given Pin toolbar to taskbar
	Given launch toolbar
	Given Waiting 10 seconds
	When Turn on or off the ECourse toggle within toolbar 'on'
	When Turn on or off the Dolby Audio button within Dolby Audio app 'off'
	Given launch toolbar
	Then The 'ECourse' function shown or hidden 'hidden' within toolbar
	Given Turn on or off the narrator 'off'

@ECourseToolbar
Scenario: VAN10210_TestStep077_Check the Interactive E-course status is off
	Given check the ECourse Feature on the supported system
	When Turn on or off the Dolby Audio button within Dolby Audio app 'on'
	Given Pin toolbar to taskbar
	Given launch toolbar
	When Turn on or off the ECourse toggle within toolbar 'on'
	When Turn on or off the Dolby Audio button within Dolby Audio app 'off'
	When Turn on or off the Dolby Audio button within Dolby Audio app 'on'
	Given launch toolbar
	Given Waiting 10 seconds
	When Turn on or off the ECourse toggle within toolbar 'off'
	Given Turn on or off the narrator 'off'

@ECourseToolbar
Scenario: VAN10210_TestStep078_Check the Interactive E-course status is off
	Given Pin toolbar to taskbar
	Given launch toolbar
	Given Waiting 10 seconds
	When Turn on or off the ECourse toggle within toolbar 'off'
	Then the ECourse toggle status is on or off within toolbar 'off'
	Given Turn on or off the narrator 'off'

@ECourseToolbar
Scenario: VAN10210_TestStep079_Check the Interactive E-course display
	Given check the ECourse Feature on the supported system
	Given Pin toolbar to taskbar
	Given launch toolbar
	Given Waiting 10 seconds
	When Turn on or off the ECourse toggle within toolbar 'on'
	When Turn on or off the ECourse toggle within toolbar 'off'
	Then Take screen shot VAN10210_TestStep079 in 10210 under HSScreenShotResult after 0 seconds
	Given Turn on or off the narrator 'off'

@ECourseToolbar
Scenario: VAN10210_TestStep080_Check the Interactive E-course display off
	Given check the ECourse Feature on the supported system
	Given Pin toolbar to taskbar
	Given launch toolbar
	Given Waiting 10 seconds
	When Turn on or off the ECourse toggle within toolbar 'off'
	Given go to Audio page
	Given Jump to audio smart settings section
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	| E-Course    | off           |
	Given Turn on or off the narrator 'off'

@ECourseToolbar
Scenario: VAN10210_TestStep081_Check the Interactive E-course status is off
	Given check the ECourse Feature on the supported system
	Given Pin toolbar to taskbar
	Given launch toolbar
	Given Waiting 10 seconds
	When Turn on or off the ECourse toggle within toolbar 'off'
	Given go to Audio page
	Given Jump to audio smart settings section
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Dolby audio | on            |
	Given launch toolbar
	Given Waiting 10 seconds
	Then the ECourse toggle status is on or off within toolbar 'off'
	Given Turn on or off the narrator 'off'

@ECourseToolbar
Scenario: VAN10210_TestStep082_Check the Interactive E-course status is on
	Given check the ECourse Feature on the supported system
	Given Pin toolbar to taskbar
	Given go to Audio page
	Given Jump to audio smart settings section
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| E-Course    | on            |
	Given launch toolbar
	Given Waiting 10 seconds
	Then the ECourse toggle status is on or off within toolbar 'on'
	Given Turn on or off the narrator 'off'

@ECourseToolbar
Scenario: VAN10210_TestStep083_Check the Interactive E-course status is off
	Given check the ECourse Feature on the supported system
	Given Pin toolbar to taskbar
	Given launch toolbar
	Given Waiting 10 seconds
	When Turn on or off the ECourse toggle within toolbar 'on'
	Given go to Audio page
	Given Jump to audio smart settings section
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| E-Course    | off           |
	Given launch toolbar
	Given Waiting 10 seconds
	Then the ECourse toggle status is on or off within toolbar 'off'
	Given Turn on or off the narrator 'off'