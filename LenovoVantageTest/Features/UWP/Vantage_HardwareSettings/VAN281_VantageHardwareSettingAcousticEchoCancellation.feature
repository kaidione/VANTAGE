Feature: VAN281_VFC197_AcousticEchoCancellation
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-281
	Author：Jinxin Li

@CheckLEMicrophoneAECNotSupportAEC
Scenario: VFC197_TestStep01_Check Machines Not Support AEC
	Given Go to audio section
	Given voice recognition is unselect
	When Jump to microphone
	Then Machines Not Support AEC And Elements Not Show

@MicrophoneAEC @CheckLEMicrophoneAEC @SmokeMicrophoneAEC
Scenario: VAN281_VFC197_TestStep02_Check acoustic echo cancellation ui
	Given Go to audio section
	Given voice recognition is unselect
	When Jump to microphone
	Then the header is Acoustic Echo Cancellation.there is a toggle,there is a question mark

@MicrophoneAEC @CheckLEMicrophoneAEC
Scenario: VAN281_VFC197_TestStep03_Check acoustic echo introduce
	Given Go to audio section
	Given voice recognition is unselect
	When Jump to microphone
	When Click acoustic echo question mask
	Then It will show a textbox to introduce the feature

@MicrophoneAEC @CheckLEMicrophoneAEC
Scenario: VAN281_VFC197_TestStep04_Click toggle it can change normally
	Given Go to audio section
	Given voice recognition is unselect
	When Jump to microphone
	When Get aec toggle state
	When Get audio driver name
	When Open audio and screenshot
	When Click aec toggle
	When Open audio and screenshot
	Then Click toggle change normally

@CheckLEMicrophoneAECRealtekHDAudioManager
Scenario: VFC197_TestStep07_Check Turn 'On' AEC Toggle , Realtek HD Audio Manager is also selected
	Given Go to audio section
	Given voice recognition is unselect
	When Jump to microphone
	Given Turn 'On' AEC Toggle
	Then AEC Toggle Status is 'On'
	When Get audio driver name
	When Open audio and screenshot 'RealtekHDAudioManager_AEC_On'
	Given close lenovo vantage
	Given ReLaunch Lenovo Vantage
	Given Go to audio section
	Given voice recognition is unselect
	When Jump to microphone
	Then Take Screen Shot VFC197_TestStep07_CheckUI in 197 under SettingsScreenShotResult

@CheckLEMicrophoneAECRealtekAudioConsole
Scenario: VFC197_TestStep08_Check Turn 'On' AEC Toggle , Realtek Audio Console is also selected
	Given Go to audio section
	Given voice recognition is unselect
	When Jump to microphone
	Given Turn 'On' AEC Toggle
	Then AEC Toggle Status is 'On'
	When Get audio driver name
	When Open audio and screenshot 'RealtekAudioConsole_AEC_On'
	Given close lenovo vantage
	Given ReLaunch Lenovo Vantage
	Given Go to audio section
	Given voice recognition is unselect
	When Jump to microphone
	Then Take Screen Shot VFC197_TestStep08_CheckUI in 197 under SettingsScreenShotResult

@CheckLEMicrophoneAECRealtekHDAudioManager
Scenario: VFC197_TestStep11_Check Turn 'Off' AEC Toggle , Realtek HD Audio Manager is also selected
	Given Go to audio section
	Given voice recognition is unselect
	When Jump to microphone
	Given Turn 'Off' AEC Toggle
	Then AEC Toggle Status is 'Off'
	When Get audio driver name
	When Open audio and screenshot 'RealtekHDAudioManager_AEC_Off'
	Given close lenovo vantage
	Given ReLaunch Lenovo Vantage
	Given Go to audio section
	Given voice recognition is unselect
	When Jump to microphone
	Then Take Screen Shot VFC197_TestStep11_CheckUI in 197 under SettingsScreenShotResult

@CheckLEMicrophoneAECRealtekAudioConsole
Scenario: VFC197_TestStep12_Check Turn 'Off' AEC Toggle , Realtek Audio Console is also selected
	Given Go to audio section
	Given voice recognition is unselect
	When Jump to microphone
	Given Turn 'Off' AEC Toggle
	Then AEC Toggle Status is 'Off'
	When Get audio driver name
	When Open audio and screenshot 'RealtekAudioConsole_AEC_Off'
	Given close lenovo vantage
	Given ReLaunch Lenovo Vantage
	Given Go to audio section
	Given voice recognition is unselect
	When Jump to microphone
	Then Take Screen Shot VFC197_TestStep12_CheckUI in 197 under SettingsScreenShotResult

@MicrophoneAEC
Scenario: VAN281_TestStep07_01_Click toggle check performance
	Given Go to audio section
	Given voice recognition is unselect
	When Jump to microphone
	When Quickly switch aec toggle
	Then The toggle should be quick switch

@CheckLEMicrophoneAEC
Scenario: VFC197_TestStep13_Check Turn 'Off' AEC Toggle
	Given Go to audio section
	Given voice recognition is unselect
	When Jump to microphone
	Given Turn 'On' AEC Toggle
	When Click Vantage Maxmize Button
	Then AEC Toggle Status is 'On'
	Then the header is Acoustic Echo Cancellation.there is a toggle,there is a question mark
	Then Take Screen Shot VFC197_TestStep13_CheckUI in 197 under SettingsScreenShotResult

@CheckLEMicrophoneAEC
Scenario: VFC197_TestStep14_The UI should show in 2 seconds
	Given Go to audio section
	Given voice recognition is unselect
	When Jump to microphone
	When wait 2 seconds
	Then the header is Acoustic Echo Cancellation.there is a toggle,there is a question mark