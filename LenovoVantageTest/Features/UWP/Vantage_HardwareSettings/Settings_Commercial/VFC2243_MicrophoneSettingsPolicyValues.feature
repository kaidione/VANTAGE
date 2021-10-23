Feature: VFC2243-MicrophoneSettingsPolicyValues
	Test Case: https://jira.tc.lenovo.com/browse/VFC-2243
	Author: Alejandro Schmechel

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step01 Hide Microphone settings section and jump to settings if AdPolicy is enabled
	Given Microphone Settings AdPolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be not visible

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step02 Show Microphone settings section and jump to settings if AdPolicy is disabled or not configured
	Given Microphone Settings AdPolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be visible
	Given Microphone Settings AdPolicy is set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Microphone Settings and Jump to Settings should be visible

@MicrophoneSettings_NoSupport_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step03 Hide Microphone settings section and jump to settings if machine does not support feature and AdPolicy is enabled
	Given Microphone Settings AdPolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page if available
	Then Microphone Settings and Jump to Settings should be not visible

@MicrophoneSettings_NoSupport_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step04 Hide Microphone settings section and jump to settings if machine does not support feature and AdPolicy is disabled or not configured
	Given Microphone Settings AdPolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page if available
	Then Microphone Settings and Jump to Settings should be not visible
	Given Microphone Settings AdPolicy is set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page if available
	Then Microphone Settings and Jump to Settings should be not visible

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step05 Check Microphone On Toggle value if AdPolicy is disabled or not configured
	Given Microphone Settings AdPolicy is set to disabled
	And go to Audio page
	And Go to Microphone Panel
	When Turn on the Microphone Section's Microphone toggle
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Given Go to Microphone Panel
	Then Microphone settings toggle should be On
	Given Microphone Settings AdPolicy is set to not configured
	And go to Audio page
	And Go to Microphone Panel
	When Turn on the Microphone Section's Microphone toggle
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Given Go to Microphone Panel
	Then Microphone settings toggle should be On

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step06 Check Microphone On Toggle value if AdPolicy is enabled
	Given go to Audio page
	And Go to Microphone Panel
	When Turn on the Microphone Section's Microphone toggle
	And Microphone Settings AdPolicy is set to enabled
	And close lenovo vantage
	Then The disable microphone checkbox on Windows Settings should be unchecked

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step07 Check Microphone Off Toggle value if AdPolicy is disabled or not configured
	Given Microphone Settings AdPolicy is set to disabled
	And go to Audio page
	And Go to Microphone Panel
	When Turn off the Microphone Section's Microphone toggle
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Given Go to Microphone Panel
	Then Microphone settings toggle should be Off
	Given Microphone Settings AdPolicy is set to not configured
	And go to Audio page
	And Go to Microphone Panel
	When Turn off the Microphone Section's Microphone toggle
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Given Go to Microphone Panel
	Then Microphone settings toggle should be Off

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step08 Check Microphone Off Toggle value if AdPolicy is enabled
	Given go to Audio page
	And Go to Microphone Panel
	When Turn off the Microphone Section's Microphone toggle
	And Microphone Settings AdPolicy is set to enabled
	And close lenovo vantage
	Then The disable microphone checkbox on Windows Settings should be unchecked

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step09 Check Microphone Max Volume value if AdPolicy is disabled or not configured
	Given go to Audio page
	And Go to Microphone Panel
	When User sets microphone volume to 100
	And wait 2 seconds
	And Microphone Settings AdPolicy is set to disabled	
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Given Go to Microphone Panel
	Then The microphone volume value should be the same set previously
	Given go to Audio page
	And Go to Microphone Panel
	When User sets microphone volume to 100
	And wait 2 seconds
	And Microphone Settings AdPolicy is set to not configured	
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Given Go to Microphone Panel
	Then The microphone volume value should be the same set previously

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step10 Check Microphone Default Volume value if AdPolicy is enabled
	Given go to Audio page
	And Go to Microphone Panel
	When User sets microphone volume to 100
	And wait 2 seconds
	And Microphone Settings AdPolicy is set to enabled	
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	And close lenovo vantage
	Then The microphone volume value on Windows Settings should be 70

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step11 Check Microphone 70 Volume value if AdPolicy is disabled or not configured
	Given go to Audio page
	And Go to Microphone Panel
	When User sets microphone volume to 70
	And wait 2 seconds
	And Microphone Settings AdPolicy is set to disabled	
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Given Go to Microphone Panel
	Then The microphone volume value should be the same set previously
	Given go to Audio page
	And Go to Microphone Panel
	When User sets microphone volume to 70
	And wait 2 seconds
	And Microphone Settings AdPolicy is set to not configured	
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Given Go to Microphone Panel
	Then The microphone volume value should be the same set previously

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step12 Check Microphone Volume 70 value if AdPolicy is enabled
	Given go to Audio page
	And Go to Microphone Panel
	When User sets microphone volume to 70
	And wait 2 seconds
	And Microphone Settings AdPolicy is set to enabled	
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	And close lenovo vantage
	Then The microphone volume value on Windows Settings should be 70

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step13 Check Suppress Keyboard noise On Toggle value if AdPolicy is disabled or not configured
	Given Microphone Settings AdPolicy is set to disabled
	And go to Audio page
	And Go to Microphone Panel
	When Turn on the Microphone Section's Suppress Keyboard toggle
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Given Go to Microphone Panel
	Then Suppress Keyboard settings toggle should be On
	Given Microphone Settings AdPolicy is set to not configured
	And go to Audio page
	And Go to Microphone Panel
	When Turn on the Microphone Section's Suppress Keyboard toggle
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Given Go to Microphone Panel
	Then Suppress Keyboard settings toggle should be On

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step14 Check Suppress Keyboard noise On Toggle value if AdPolicy is enabled
	Given go to Audio page
	And Go to Microphone Panel
	When Turn on the Microphone Section's Suppress Keyboard toggle
	And Microphone Settings AdPolicy is set to enabled
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then value on Realtek Audio Console for Suppress Keyboard is on

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step15 Check Suppress Keyboard noise Off Toggle value if AdPolicy is disabled or not configured
	Given Microphone Settings AdPolicy is set to disabled
	And go to Audio page
	And Go to Microphone Panel
	When Turn off the Microphone Section's Suppress Keyboard toggle
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Given Go to Microphone Panel
	Then Suppress Keyboard settings toggle should be Off
	Given Microphone Settings AdPolicy is set to not configured
	And go to Audio page
	And Go to Microphone Panel
	When Turn off the Microphone Section's Suppress Keyboard toggle
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Given Go to Microphone Panel
	Then Suppress Keyboard settings toggle should be Off

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step16 Check Suppress Keyboard noise Default Toggle value if AdPolicy is enabled and was changed to off before
	Given go to Audio page
	And Go to Microphone Panel
	When Turn off the Microphone Section's Suppress Keyboard toggle
	And Microphone Settings AdPolicy is set to enabled
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then value on Realtek Audio Console for Suppress Keyboard is on

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step17 Check Acoustic Echo Cancellation On Toggle value if AdPolicy is disabled or not configured
	Given Microphone Settings AdPolicy is set to disabled
	And go to Audio page
	And Go to Microphone Panel
	When Turn on the Microphone Section's Acoustic Echo Cancellation toggle
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Given Go to Microphone Panel
	Then Acoustic Echo Cancellation settings toggle should be On
	Given Microphone Settings AdPolicy is set to not configured
	And go to Audio page
	And Go to Microphone Panel
	When Turn on the Microphone Section's Acoustic Echo Cancellation toggle
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Given Go to Microphone Panel
	Then Acoustic Echo Cancellation settings toggle should be On

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step18 Check Acoustic Echo Cancellation On Toggle value if AdPolicy is enabled
	Given go to Audio page
	And Go to Microphone Panel
	When Turn on the Microphone Section's Acoustic Echo Cancellation toggle
	And Microphone Settings AdPolicy is set to enabled
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	Then value on Realtek Audio Console for Acoustic Echo Cancellation is on

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step19 Check Acoustic Echo Cancellation Off Toggle value if AdPolicy is disabled or not configured
	Given Microphone Settings AdPolicy is set to disabled
	And go to Audio page
	And Go to Microphone Panel
	When Turn off the Microphone Section's Acoustic Echo Cancellation toggle
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Given Go to Microphone Panel
	Then Acoustic Echo Cancellation settings toggle should be Off
	Given Microphone Settings AdPolicy is set to not configured
	And go to Audio page
	And Go to Microphone Panel
	When Turn off the Microphone Section's Acoustic Echo Cancellation toggle
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Given Go to Microphone Panel
	Then Acoustic Echo Cancellation settings toggle should be Off

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step20 Check Acoustic Echo Cancellation On Toggle value if AdPolicy is enabled and was previously set to Off
	Given go to Audio page
	And Go to Microphone Panel
	When Turn off the Microphone Section's Acoustic Echo Cancellation toggle
	And Microphone Settings AdPolicy is set to enabled
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	Then value on Realtek Audio Console for Acoustic Echo Cancellation is on

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step21 Check Optimize Microphone for Only My Voice value if AdPolicy is disabled or not configured
	Given Microphone Settings AdPolicy is set to disabled
	And go to Audio page
	And Go to Microphone Panel
	And Switch "OnlyMyVoice" Microphone button
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Given Go to Microphone Panel
	Then Optimize My Microphone for value is OnlyMyVoice
	Given Microphone Settings AdPolicy is set to not configured
	And go to Audio page
	And Go to Microphone Panel
	And Switch "OnlyMyVoice" Microphone button
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Given Go to Microphone Panel
	Then Optimize My Microphone for value is OnlyMyVoice

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step22 Check Optimize Microphone for Only My Voice value when AdPolicy is enabled
	Given go to Audio page
	And Go to Microphone Panel
	And Switch "OnlyMyVoice" Microphone button
	And Microphone Settings AdPolicy is set to enabled
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	Then Check Realtek "OnlyMyVoice" value

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step23 Check Optimize Microphone for Voice Recognition if AdPolicy is disabled or not configured
	Given Microphone Settings AdPolicy is set to disabled
	And go to Audio page
	And Go to Microphone Panel
	And Switch "VoiceRecognition" Microphone button
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Given Go to Microphone Panel
	Then Optimize My Microphone for value is VoiceRecognition
	Given Microphone Settings AdPolicy is set to not configured
	And go to Audio page
	And Go to Microphone Panel
	And Switch "VoiceRecognition" Microphone button
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Given Go to Microphone Panel
	Then Optimize My Microphone for value is VoiceRecognition

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step24 Check Optimize Microphone for Default value when AdPolicy is enabled
	Given go to Audio page
	And Go to Microphone Panel
	And Switch "VoiceRecognition" Microphone button
	And Microphone Settings AdPolicy is set to enabled
	And close lenovo vantage
	And ReLaunch Lenovo Vantage
	Then Check Realtek "OnlyMyVoice" value

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step25 Hide Quick Settings Widget if microphone and camera are wiuth AdPolicy enabled
	Given Microphone Settings AdPolicy is set to enabled
	And Camera adpolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	Then The Machine not display the Quick Settings Widget

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step26 Hide Audio menu link when AdPolicy for all features on page are enabled
	Given AdPolicy for all features on Audio page are set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Open Menu to check audio link
	Then Audio Link should be not visible

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step27 Hide Audio Tab on My Device Settings page if AdPolicy for all features on page are enabled
	Given AdPolicy for all features on Audio page are set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Device Section to check Tab
	Then Audio Tab should be not visible

@MicrophoneSettings_AdvanceMicrophone_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step28 Hide Advanced Microphone settings section if machine supports the section and AdPolicy is enabled
	Given Microphone Settings AdPolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Advanced Microphone Options should be not visible

@MicrophoneSettings_AdvanceMicrophone_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step29 Hide Advanced Microphone settings section if machine supports the section and AdPolicy is disabled or not configured
	Given Microphone Settings AdPolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Advanced Microphone Options should be visible
	Given Microphone Settings AdPolicy is set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then Advanced Microphone Options should be visible

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step30 Hide Microphone in Quick Settings section if AdPolicy is enabled
	Given Microphone Settings AdPolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	Then The Microphone Section is not shown in Quick Settings Widget

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step31 Show Microphone in Quick Settings section if AdPolicy is disabled
	Given Microphone Settings AdPolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	Then The Microphone Section is shown in Quick Settings Widget

@MicrophoneSettings_PolicyValues
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step32 Hide Privacy Tip on Microphone in Quick Settings if permission is denied and AdPolicy is enabled
	Given disable microphone total access
	And Microphone Settings AdPolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	Then The Microphone tip in quick settings section is hidden

@MicrophoneSettings_PolicyValues @MicrophoneResetPolicies
Scenario: VFC2243-MicrophoneSettingsPolicyValues_Step33 Go to Display and Camera Page if Audio and Power have all features with AdPolicy enabled and user clics on more settings on QSW
	Given AdPolicy for all features on Audio page are set to enabled
	And AdPolicy for all features on PowerSmartSettings page are set to enabled
	And Camera adpolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click My Device Settings Link on dashboard
	Then The Display and Camera page is loaded