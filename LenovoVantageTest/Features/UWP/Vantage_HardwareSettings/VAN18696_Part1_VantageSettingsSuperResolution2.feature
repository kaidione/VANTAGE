Feature: VAN18696_Part1_VantageSettingsSuperResolution2
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-18696
	Author： Pengjie Chen

Background: 
	Given Go to My Device
	Given Go to Smart Assist page
	Given Jump to Intelligent Media section

@SR2 @SuperResolution2 @SmokeSR2
Scenario:  VAN18696_TestStep01_Check video resolution upscaling is below Zero touch video playback
	Then the video resolution upscaling is below Zero touch video playback

@SR2 @SuperResolution2 @SmokeSR2
Scenario:  VAN18696_TestStep02_Check video resolution upscaling title and a toggle and a question mark on the right
	Then the video resolution upscaling text is correct
	| section | desc             |
	| title   | Super resolution |
	Then Take Screen Shot TestStep02 in 18696 under HSScreenShotResult

@SR2 @SuperResolution2 @SmokeSR2
Scenario:  VAN18696_TestStep03_Check video resolution upscaling desc text
	Then the video resolution upscaling text is correct
	| section | desc                                                                                                                                                |
	| desc1   | This feature enhances the experience of video playback by improving the video resolution. It works especially when the video is in poor resolution. |

@SR2 @SuperResolution2 @SmokeSR2
Scenario:  VAN18696_TestStep04_Check video resolution upscaling desc text
	Then the video resolution upscaling text is correct
	| section | desc                                                                                                                                                                                                           |
	| desc2   | This function might impact the battery life, skin temperature, and fan noises. Please do not use it in DC mode (battery mode). Otherwise, it will speed up the power consumption and shorten the battery life. |

@SR2 @SuperResolution2 @SmokeSR2
Scenario:  VAN18696_TestStep05_Check video resolution upscaling note text
	Then the video resolution upscaling text is correct
	| section   | desc                                                                                                      |
	| notedesc  | This feature does not work when:                                                                          |
	| notedesc1 | The CPU temperature is too high.                                                                          |
	| notedesc2 | The device is set to Battery saving mode in "Intelligent cooling".                                        |
	| notedesc3 | Two or more players are running at the same time.                                                         |
	| notedesc4 | On a video call with VoIP apps (such as Microsoft Teams or Zoom) and a video is playing at the same time. |

@SR2 @SuperResolution2
Scenario:  VAN18696_TestStep06_Check video resolution upscaling tooltips text
	When user click question mark within video resolution upscaling
	Then the video resolution upscaling text is correct
	| section     | desc                                                                                                                                                                                                                                                                                                                                                                                 |
	#| tooltips1   | This feature only works for below video players: Windows Media Player Chrome-based player PotPlayer                                                                                                                                                                                                                                                                                  |
	#| tooltips2   | For instructions on how to enable this function on PotPlayer, refer to the User Guide that comes with your computer.                                                                                                                                                                                                                                                                 |
	| tooltipsnew | This feature only works for below video players:<br>Windows Media Player<br>Chrome-based player<br>PotPlayer<br>Opera (built-in Google Chromium engine)<br>Microsoft Edge (built-in Google Chromium engine)<br><p class='srTooltip' id='sr-tip' role='text'>For instructions on how to enable this function on PotPlayer, refer to the User Guide that comes with your computer.</p> |
	Then Take Screen Shot TestStep06 in 18696 under HSScreenShotResult

@SR2 @SuperResolution2
Scenario:  VAN18696_TestStep07_Check video resolution upscaling toggle status is on
	When Turn on or off video resolution upscaling toggle 'on'
	Then The video resolution upscaling toggle status is on or off 'on'
	
@SR2 @SuperResolution2
Scenario:  VAN18696_TestStep08_Check video resolution upscaling toggle status is off
	When Turn on or off video resolution upscaling toggle 'off'
	Then The video resolution upscaling toggle status is on or off 'off'

@SR2 @SuperResolution2
Scenario:  VAN18696_TestStep09_Check refresh page and video resolution upscaling ui shows normally 
	When Turn on or off video resolution upscaling toggle 'on'
	Given Go to Power Page
	Given Go to My Device
	Given Go to Smart Assist page
	Given Jump to Intelligent Media section
	Given Type in "{PGDN}"
	Then Take Screen Shot TestStep09-1 in 18696 under HSScreenShotResult
	Then The video resolution upscaling toggle status is on or off 'on'
	When Minimize vantage HSHPD page
	Then Take Screen Shot TestStep09-2 in 18696 under HSScreenShotResult
	Then The video resolution upscaling toggle status is on or off 'on'
	Given ReLaunch Vantage
	Given Go to Smart Assist page
	Given Jump to Intelligent Media section
	Then Take Screen Shot TestStep09-3 in 18696 under HSScreenShotResult
	Then The video resolution upscaling toggle status is on or off 'on'

@SR2 @SuperResolution2
Scenario:  VAN18696_TestStep10_Check refresh page and video resolution upscaling ui shows normally 
	Given Type in "{PGDN}"
	Given Change DPI to 100
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 500   | 500    |           |            |
	Then Take Screen Shot TestStep10-1 in 18696 under HSScreenShotResult
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 800   | 600    |           |            |
	Then Take Screen Shot TestStep10-2 in 18696 under HSScreenShotResult

@SR2 @SuperResolution2
Scenario:  VAN18696_TestStep12_Check resolution upscaling toggle is off by default
	When Turn on or off video resolution upscaling toggle 'on'
	Then The video resolution upscaling toggle status is on or off 'on'
	Given Uninstall the Lenovo Vantage
	Given Uninstall Lenovo Vantage Service
	When Wait 1 minutes
	Given Install Vantage
	Given Go to My Device
	Given Go to Smart Assist page
	Given Jump to Intelligent Media section
	Then The video resolution upscaling toggle status is on or off 'off'

@SR2 @SuperResolution2
Scenario:  VAN18696_TestStep27_Check resolution upscaling toggle will be changed to off 
	When Turn on or off video resolution upscaling toggle 'on'
	Then The video resolution upscaling toggle status is on or off 'on'
	Given Uninstall the Lenovo Vantage
	Given Uninstall Lenovo Vantage Service
	Given Install Vantage
	Given Go to My Device
	Given Go to Smart Assist page
	Given Jump to Intelligent Media section
	Then The video resolution upscaling toggle status is on or off 'off'
	Given Open the test video and task manager
	Then Take Screen Shot TestStep27 in 18696 under HSScreenShotResult
	Given close task manager
	Given close the test video

@SR2 @SuperResolution2
Scenario:  VAN18696_TestStep28_Check resolution upscaling toggle keep off
	When Turn on or off video resolution upscaling toggle 'off'
	Then The video resolution upscaling toggle status is on or off 'off'
	Given Uninstall the Lenovo Vantage
	Given Uninstall Lenovo Vantage Service
	Given Install Vantage
	Given Go to My Device
	Given Go to Smart Assist page
	Given Jump to Intelligent Media section
	Then The video resolution upscaling toggle status is on or off 'off'
	Given Open the test video and task manager
	Then Take Screen Shot TestStep28 in 18696 under HSScreenShotResult
	Given close task manager
	Given close the test video

