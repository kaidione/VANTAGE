Feature: VAN282_MicrophoneOptimizationMode
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-282
	Author： Jinglong Zhao

@MicrophoneOptimizationMode @SmokeMicrophoneOptimizationMode
Scenario: VAN282_TestStep02_Check microphone optimization mode
	Given Go to audio section
	When Jump to microphone
	Then The Microphone Optimization mode includes: voice recognition, only my voice, Normal, Multiple voices
	Then The Optimization MicroPhone Caption Corrcet

@MicrophoneOptimizationMode
Scenario: VAN282_TestStep03_Select microphone optimization any mode
	Given Go to audio section
	When Jump to microphone
	Then Any of the modes can be selected

@MicrophoneOptimizationMode
Scenario: VAN282_TestStep04_Switch page/reopen vantage/
	Given Go to audio section
	When Jump to microphone
	When Get microphone optimization state
	When Switch vantage microphone optimization mode
	Then The mode should not change and should work normally
	When Relaungh vantage microphone optimization mode
	Then The mode should not change and should work normally

@MicrophoneOptimizationMode
Scenario: VAN282_TestStep05_Sleep/Hibernate mode not change
	Given Go to audio section
	When Jump to microphone
	When Get microphone optimization state
	When enter sleep
	Then The mode should not change and should work normally
	When enter hibernate
	Then The mode should not change and should work normally
