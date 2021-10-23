Feature: VFC201_TCLEAutomaticAudioOptimizationForVoIP
	Test Case： https://jira.tc.lenovo.com/browse/VFC-201
	Author: Jinxin Li

@CheckAutomaticAudioOptimizationForVoIP
Scenario: VFC201_TestStep01_Check Automatic Audio Optimization For VoIP Elements
	Given supported Dolby machine
	Given Go to My Device Settings page
	Given go to Audio section
	When Click Audio Smart Settings Link
	Then Check Automatic Audio Optimization For VoIP Elements
	
#@CheckAutomaticAudioOptimizationForVoIP
#Scenario: VFC201_TestStep02_Check The Toggle Is On By Default
#	Given supported Dolby machine
#	Given Uninstall the lenovo vatage
#	Given Install Vantage
#	Given go to Audio section
#	When Click Audio Smart Settings Link
#	Then Check Automatic Audio Optimization For VoIP Toggle is 'On'

@CheckAutomaticAudioOptimizationForVoIP
Scenario: VFC201_TestStep03_Click The Question Mark and Check Tip Text
	Given supported Dolby machine
	Given go to Audio section
	When Click Audio Smart Settings Link
	When Click Automatic Audio Optimization For VoIP QuestionMark
	Then Check Question Mark Tip DisPlay '$.MyDeviceSettings.AudioPage.AutomaticAudioOptimizationForVoIPTipText'

@CheckAutomaticAudioOptimizationForVoIP
Scenario: VFC201_TestStep04_Check Dolby Mode in Automatic Dolby Audio Settings Will Change to Voice Mode
	Given supported Dolby machine
	Given go to Audio section
	When Click Audio Smart Settings Link
	Given Turn On Automatic Audio Optimization For VoIP Toggle
	Given Dolby audio is off
	Given select music mode
	When make a voice connection via Lync or use Voice Recorder
	When wait 3 seconds
	When open Dolby Atmos Speaker System
	Then open Dolby Atmos Speaker System(Dolby audio app), Dolby mode will automatically turn to Voice mode

@CheckAutomaticAudioOptimizationForVoIP
Scenario: VFC201_TestStep05_Check Dolby Mode Will Automatically Turn to Voice Mode
	Given supported Dolby machine
	Given Go to My Device Settings page
	Given go to Audio section
	When Click Audio Smart Settings Link
	When make a voice connection via Lync or use Voice Recorder
	When wait 3 seconds
	When open Dolby Atmos Speaker System
	Then open Dolby Atmos Speaker System(Dolby audio app), Dolby mode will automatically turn to Voice mode

@CheckAutomaticAudioOptimizationForVoIP
Scenario: VFC201_TestStep06_Switch Pages Reopen Vantage Minimize Check UI Should Not Change
	Given supported Dolby machine
	Given go to Audio section
	When Click Audio Smart Settings Link
	When switch pages/reopen Vantage/minimize
	Then the UI should not change and the feature should work normally

@CheckAutomaticAudioOptimizationForVoIP
Scenario: VFC201_TestStep07_Check The Dolby Mode Will Not Automatically Turn to Voice Mode
	Given supported Dolby machine
	Given Go to My Device Settings page
	Given go to Audio section
	And turn off the voip toggle
	And select Dynamic mode
	When make a voice connection via Lync or use Voice Recorder
	When wait 2 seconds
	Then Dolby mode not change
	When open Dolby Atmos Speaker System
	Then open Dolby Atmos Speaker System(Dolby audio app), Dolby mode will not automatically turn to Voice mode

@CheckAutomaticAudioOptimizationForVoIP
Scenario: VFC201_TestStep10_Check Elements Show in 2 Seconds
	Given supported Dolby machine
	Given go to Audio section
	When Click Audio Smart Settings Link
	When wait 2 seconds
	Then Check Automatic Audio Optimization For VoIP Elements