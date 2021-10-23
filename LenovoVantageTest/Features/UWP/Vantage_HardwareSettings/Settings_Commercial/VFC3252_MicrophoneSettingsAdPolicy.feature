Feature: VFC3252_MicrophoneSettingsAdPolicy
	Test Case： https://jira.tc.lenovo.com/browse/VFC-3252
	Author: Alejandro Schmechel

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step01 Show Microphone settings section if AdPolicy is not configured
	Given Microphone Settings AdPolicy is set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be visible

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step02 Show Microphone settings section if AdPolicy is disabled
	Given Microphone Settings AdPolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be visible

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step03 Hide Microphone settings section if AdPolicy is enabled
	Given Microphone Settings AdPolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be not visible

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step04 Show Microphone settings after first launch if AdPolicy is not configured
	Given Microphone Settings AdPolicy is set to not configured
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be visible

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step05 Show Microphone settings after first launch if AdPolicy is disabled
	Given Microphone Settings AdPolicy is set to disabled
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be visible

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step06 Hide Microphone settings after first launch if AdPolicy is enabled
	Given Microphone Settings AdPolicy is set to enabled
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be not visible

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step07 Show Microphone settings if AdPolicy is not configured and Vantage was reset
	Given Microphone Settings AdPolicy is set to not configured
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be visible

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step08 Show Microphone settings if AdPolicy is disabled and Vantage was reset
	Given Microphone Settings AdPolicy is set to disabled
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be visible

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step09 Hide Microphone settings if AdPolicy is enabled and Vantage was reset
	Given Microphone Settings AdPolicy is set to enabled
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be not visible

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step10 Hide Microphone settings section if AdPolicy is not configured and its changed to enabled
	Given Microphone Settings AdPolicy is set to not configured
	When close lenovo vantage
	And Microphone Settings AdPolicy is set to enabled
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be not visible

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step11 Show Microphone settings section if AdPolicy is not configured and its changed to disabled
	Given Microphone Settings AdPolicy is set to not configured
	When close lenovo vantage
	And Microphone Settings AdPolicy is set to disabled
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be visible

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step12 Hide Microphone settings section if AdPolicy is disabled and its changed to enabled
	Given Microphone Settings AdPolicy is set to disabled
	When close lenovo vantage
	And Microphone Settings AdPolicy is set to enabled
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be not visible

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step13 Show Microphone settings section if AdPolicy is disabled and its changed to not configured
	Given Microphone Settings AdPolicy is set to disabled
	When close lenovo vantage
	And Microphone Settings AdPolicy is set to not configured
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be visible

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step14 Show Microphone settings section if AdPolicy is enabled and its changed to disabled
	Given Microphone Settings AdPolicy is set to enabled
	When close lenovo vantage
	And Microphone Settings AdPolicy is set to disabled
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be visible

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step15 Show Microphone settings section if AdPolicy is enabled and its changed to not configured
	Given Microphone Settings AdPolicy is set to enabled
	When close lenovo vantage
	And Microphone Settings AdPolicy is set to not configured
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be visible

@MicrophoneSettings_NoSupport_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step16 Hide Microphone settings section if AdPolicy is enabled and machine does not support the feature
	Given Microphone Settings AdPolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be not visible

@MicrophoneSettings_NoSupport_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step17 Hide Microphone settings section if AdPolicy is not configured and machine does not support the feature
	Given Microphone Settings AdPolicy is set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be not visible

@MicrophoneSettings_NoSupport_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step18 Hide Microphone settings section if AdPolicy is disabled and machine does not support the feature
	Given Microphone Settings AdPolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be not visible

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step19 Hide Audio Page Link on menu if AdPolicy for all features on section are enabled
	Given AdPolicy for all features on Audio page are set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Open Menu to check audio link
	Then Audio Link should be not visible

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step20 Show Audio Page Link on menu if AdPolicy for all features on section are disabled
	Given AdPolicy for all features on Audio page are set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Open Menu to check audio link
	Then Audio Link should be visible

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step21 Show Audio Page Link on menu if AdPolicy for all features on section are not configured
	Given AdPolicy for all features on Audio page are set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Open Menu to check audio link
	Then Audio Link should be visible

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step22 Hide Power Page Tab on My Device Settings if AdPolicy for all features on section are enabled
	Given AdPolicy for all features on Audio page are set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Device Section to check Tab
	Then Audio Tab should be not visible

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step23 Show Power Page Tab on My Device Settings if AdPolicy for all features on section are disabled
	Given AdPolicy for all features on Audio page are set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Device Section to check Tab
	Then Audio Tab should be visible

@MicrophoneSettings_AdPolicy
Scenario: VFC3252_MicrophoneSettingsAdPolicy_Step24 Show Power Page Tab on My Device Settings if AdPolicy for all features on section are not configured
	Given AdPolicy for all features on Audio page are set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Device Section to check Tab
	Then Audio Tab should be visible