Feature: VAN18508_HSAutomaticAudioOptimizationforVoIP
	Test Case: https://lnvusjira.lenovonet.lenovo.local/browse/VAN-18508
	Author: Jinxin Li

Background:
	Given Stop Dolby Driver

@DolbySettings @SmokeDolbySettings
Scenario: VAN18508_TestStep01_VoIPSettings check ui
	Given supported Dolby machine 
	Given Change DPI to 150
	And go to Audio section
	When check the UI of Automatic Audio Optimization
	Then the header is Automatic Audio Optimization for VoIP a toggle and a question mark on the right

@DolbySettings
Scenario: VAN18508_TestStep02_VoIPSettings chek mask
	Given supported Dolby machine 
	And go to Audio section
	When click the voip question mark
	Then it will show a textbox to introduce the feature for voiptooltip
	"""
	This function takes effect when you are on VoIP calls (using Skype, Microsoft Teams, WeChat, and etc.). When enabled, Dolby audio automatically changes to the Voice mode for better voice quality.<br>Note: This option is only available for internal speakers.
	"""

@DolbySettings
Scenario: VAN18508_TestStep03_VoIPSettings Dolby mode
	Given supported Dolby machine 
	And go to Audio section
	And turn on the voip toggle
	And select Dynamic mode
	When make a voice connection via Lync or use Voice Recorder
	When wait 3 seconds
	When open Dolby Atmos Speaker System
	Then open Dolby Atmos Speaker System(Dolby audio app), Dolby mode will automatically turn to Voice mode

@DolbySettings @SmokeDolbySettings
Scenario: VAN18508_TestStep04_VoIPSettings work normally
	Given supported Dolby machine 
	Given go to Audio section
	When switch pages/reopen Vantage/minimize
	Then the UI should not change and the feature should work normally

@DolbySettings
Scenario: VAN18508_TestStep05_VoIPSettings Dolby mode not change
	Given supported Dolby machine 
	And go to Audio section
	And turn off the voip toggle
	And select Dynamic mode
	When make a voice connection via Lync or use Voice Recorder
	When wait 2 seconds
	Then Dolby mode not change
	When open Dolby Atmos Speaker System
	Then open Dolby Atmos Speaker System(Dolby audio app), Dolby mode will not automatically turn to Voice mode

@DolbySettings
Scenario: VAN18508_TestStep06_VoIPSettings mode only change
	Given supported Dolby machine 
	And go to Audio section
	And turn on the voip toggle
	When make a voice connection via Lync or use Voice Recorder
	When wait 3 seconds
	When Play music
	Then the mode only change to Voice

@DolbySettings
Scenario: VAN18508_TestStep07_VoIPSettings mode only change
	Given supported Dolby machine 
	And go to Audio section
	And turn on Automatica Entertainment Audio toggle
	And turn off the voip toggle
	When make a voice connection via Lync or use Voice Recorder	
	When wait 2 seconds
	When Play music
	Then the mode only change to Music

#@DolbySettings
Scenario: VAN18508_TestStep08_VoIPSettings show in 2 seconds
	Given supported Dolby machine 
	And go to Audio section
	And go to Automatic Audio Optimization
	And turn off the voip toggle
	Then The UI should show completely in 2 seconds
	Given supported Dolby machine 
	And go to Audio section
	And go to Automatic Audio Optimization
	And turn on the voip toggle
	Then The UI should show completely in 2 seconds

