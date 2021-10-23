Feature: VAN277_VFC200_SettingMicrophoneToggle
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-277
	Author： Jinglong Zhao

@MicrophoneToggle @MicrophoneToggleLE @SmokeMicrophoneToggle
Scenario: VAN277_TestStep01_Check the title and toggle
	Given turn on Lenovo Vantage permission for Microphonefrom system settings
	Given Go to audio section
	When check the ui of microphone
	Then the header is microphone, there is toggle on the right

@MicrophoneToggle @MicrophoneToggleLE
Scenario: VAN277_TestStep02_Check the toggle after turn toggle on
	Given Go to audio section
	Given Go to Microphone Panel
	When  turn on the microphone toggle
	Then  the microphonr toggle is on

@MicrophoneToggle @MicrophoneToggleLE
Scenario: VAN277_TestStep03_Check the toggle after turn toggle off
	Given Go to audio section
	Given Go to Microphone Panel
	When  turn off the microphone toggle
	Then  the microphonr toggle is off

@MicrophoneToggle @MicrophoneToggleLE
Scenario: VAN277_TestStep06_Switch/reopen/minimize feature normal
	Given Go to audio section
	When Get microphone toggle status
	When Switch vantage page micophone toggle
	Then The toggle will not change
	When Get microphone toggle status
	When Relaungh vantage micophone toggle
	Given Go to audio section
	Then The toggle will not change
	When Get microphone toggle status
	When Minimize vantage micophone toggle
    Then The toggle will not change

@MicrophoneToggle
Scenario: VAN277_TestStep07_Sleep/Hibernate/Restart/Shutdown toggle will not change
	Given Go to audio section
	When Get microphone toggle status
	When Enter sleep
	Then The toggle will not change
	When Enter hibernate
	Then The toggle will not change

@MicrophoneToggle @MicrophoneToggleLE
Scenario: VAN277_TestStep12_Microphone performance test
	Given enable microphone total access
    Given turn on Lenovo Vantage permission for Microphonefrom system settings
	Given Go to audio section
	When Quickly switch toggle
	Then The toggle button should quickly respond to the turn on/off action

