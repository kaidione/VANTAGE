Feature: VAN17771_HardwareSettingsVideoPlayback
	Test Case： https://jira.tc.lenovo.com/browse/VAN-17771
	JIRA Task: https://jira.tc.lenovo.com/browse/VAN-26353
	Author： Jiajt

@HardwareSettingsVideoPlayback
Scenario: VAN17771_TestStep164 Check Video Playback Title and description and no QuestionMark
	Given Go to Smart Assist page
	When Smart Assist page shows Video Playback Toggle
	When Jump to Intelligent Media section
	Then The video playback UI is following UISPEC
	| section     | desc                                                                                                        |
	| title       | Zero touch video playback                                                                                   |
	| description | This feature will pause the video when you are leaving the computer and resume the video when you are back. |
	Then Take Screen Shot TestStep164VideoPlaybackUI in 17771 under HSScreenShotResult

@HardwareSettingsVideoPlayback
Scenario: VAN17771_TestStep165 Check Video Playback SupportList
	Given Go to Smart Assist page
	When Smart Assist page shows Video Playback Toggle
	When Jump to Intelligent Media section
	Then The video playback UI is following UISPEC
	| section | desc                                                                                                         |
	| list    | The supported players are listed as follows: • Movies & TV • 5K Player • GOM Player • VLC Player • PotPlayer |
	| note    | Note: The Web video players are not supported.                                                               |

#@HardwareSettingsVideoPlayback
Scenario: VAN17771_TestStep166 Check Video Playback toggle default state
	Given Go to Smart Assist page
	When Smart Assist page shows Video Playback Toggle
	When Jump to Intelligent Media section
	When Turn "off" the Video Playback Toggle
	When Stop the IMC service in the task manager
	When close lenovo vantage
	Given uninstall 'Lenovo Intelligent Sensing' from device manager
	And Delect the related HPD Regedit Value
	And install 'Lenovo Intelligent Sensing'
	When Start the IMC service in the task manager
	And ReLaunch Vantage
	And Go to Smart Assist page
	When Smart Assist page shows Video Playback Toggle
	Then The Video Playback Toggle default value is "on"