Feature: VAN279_VFC199_MicrophoneVolumeSliderbar
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-279
	Author： Jinglong Zhao

@MicrophoneSliderBar @SmokeMicrophoneSliderBar
Scenario: VAN279_TestStep01_Check the header is microphone volume
	Given enable microphone total access
	Given enable microphone access
	Given Go to audio section
	When Jump to microphone
	When Check the UI of slider-bar
	Then Header is microphone volume,slider bar exists

@MicrophoneSliderBar
Scenario: VAN279_TestStep02_The slider bar can be dragged normally
	Given Go to audio section
	When Jump to microphone
	When Drag the slider bar
	Then The slider bar can be dragged normally

@MicrophoneSliderBar
Scenario: VAN279_TestStep04_Switch/reopen/minimize feature normal
	Given Go to audio section
	When wait 5 seconds
	When Get microphone volume
	When into Dashboard page
	Given Go to audio section
	When Jump to microphone
	When wait 5 seconds
	Then The slider bar should not changae and should work normally
	When Relaungh vantage page microphone slider
	When wait 5 seconds
	Then The slider bar should not changae and should work normally
	When Minimize vantage page microphone slider
	When wait 5 seconds
	Then The slider bar should not changae and should work normally

@MicrophoneSliderBar
Scenario: VAN279_TestStep05_Sleep/Hibernate slider bar not change
	Given Go to audio section
	When Jump to microphone
	When Get microphone volume
	When enter sleep
	Then The slider bar should not changae and should work normally
	When Get microphone volume
	When enter hibernate
	Then The slider bar should not changae and should work normally