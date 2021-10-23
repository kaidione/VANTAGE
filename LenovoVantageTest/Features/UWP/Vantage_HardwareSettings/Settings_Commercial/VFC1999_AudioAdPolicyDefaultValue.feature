Feature: VFC-1999_Audio_Smart_Settings_AdPolicy
	Test Case： https://jira.tc.lenovo.com/browse/VFC-1999
	Author: Luiz Filho

@AudioSmartSettings_AdPolicy
Scenario: VFC1999_TestStep01_AdPolicy Audio Smart Settings
	Given go to Audio section
	And Dolby audio is off
	And Audio Smart Settings adpolicy is enabled
	And close lenovo vantage
	And ReLaunch Vantage
	When Set Audio Smart Settings adpolicy to disabled
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio section
	Then Automatic Dolby Audio settings toggle should be On

@AudioSmartSettings_AdPolicy
Scenario: VFC1999_TestStep03_AdPolicy Audio Smart Settings
	Given go to Audio section
	And Turn OFF Automatic Audio Optimization For VoIP Toggle
	And Audio Smart Settings adpolicy is enabled
	And close lenovo vantage
	And ReLaunch Vantage
	When Set Audio Smart Settings adpolicy to disabled
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio section
	Then Automatic Audio Optimization For VoIP Toggle should be On

@AudioSmartSettings_AdPolicy
Scenario: VFC1999_TestStep04_AdPolicy Audio Smart Settings
	Given go to Audio section
	And Dolby audio is off
	And Audio Smart Settings adpolicy is disabled
	And close lenovo vantage
	And ReLaunch Vantage
	And go to Audio section
	Then Automatic Dolby Audio settings toggle should be Off

@AudioSmartSettings_AdPolicy
Scenario: VFC1999_TestStep05_AdPolicy Audio Smart Settings
	Given go to Audio section
	And Turn Off Automatic Audio Optimization For VoIP Toggle
	And Audio Smart Settings adpolicy is disabled
	And close lenovo vantage
	And ReLaunch Vantage
	And go to Audio section
	Then Automatic Audio Optimization For VoIP Toggle should be Off

@AudioSmartSettings_AdPolicy
Scenario:VFC1999_TestStep06_AdPolicy Audio Smart Settings
	Given Go to audio section
	And Dolby audio is on
	And Turn on Automatic Audio Optimization For VoIP Toggle
	And close lenovo vantage
	When Set Audio Smart Settings adpolicy to enabled
	And ReLaunch Vantage
	And open Dolby Access Atmos Settings
	And start play music
	And wait 3 seconds
	Then dolby Access Atmos Settings changes to Music
	And Stop play music movie game voice app etc
	When make a voice connection via Lync or use Voice Recorder
	And wait 3 seconds
	Then dolby Access Atmos Settings changes to Voice

@AudioSmartSettings_AdPolicy
Scenario: VFC1999_TestStep07_AdPolicy Audio Smart Settings
	Given Go to audio section
	And Dolby audio is on
	And Turn Off Automatic Audio Optimization For VoIP Toggle
	And close lenovo vantage
	When Set Audio Smart Settings adpolicy to enabled
	And ReLaunch Vantage
	And open Dolby Access Atmos Settings
	And start play music
	And wait 3 seconds
	Then dolby Access Atmos Settings changes to Music
	And Stop play music movie game voice app etc
	When make a voice connection via Lync or use Voice Recorder
	And wait 3 seconds
	Then dolby Access Atmos Settings changes to Voice

@AudioSmartSettings_AdPolicy
Scenario: VFC1999_TestStep08_AdPolicy Audio Smart Settings
	Given Go to audio section
	And Dolby audio is off
	And Turn On Automatic Audio Optimization For VoIP Toggle
	And close lenovo vantage
	When Set Audio Smart Settings adpolicy to enabled
	And ReLaunch Vantage
	And open Dolby Access Atmos Settings
	And start play music
	And wait 3 seconds
	Then dolby Access Atmos Settings changes to Music
	And Stop play music movie game voice app etc
	When make a voice connection via Lync or use Voice Recorder
	And wait 3 seconds
	Then dolby Access Atmos Settings changes to Voice

@AudioSmartSettings_AdPolicy
Scenario: VFC1999_TestStep09_AdPolicy Audio Smart Settings
	Given Go to audio section
	And Dolby audio is off
	And Turn Off Automatic Audio Optimization For VoIP Toggle
	And close lenovo vantage
	When Set Audio Smart Settings adpolicy to enabled
	And ReLaunch Vantage
	And open Dolby Access Atmos Settings
	And start play music
	And wait 3 seconds
	Then dolby Access Atmos Settings changes to Music
	And Stop play music movie game voice app etc
	When make a voice connection via Lync or use Voice Recorder
	And wait 3 seconds
	Then dolby Access Atmos Settings changes to Voice