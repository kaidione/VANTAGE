Feature: VFC-3438_Test_Audio_Smart_Settings_For_AD_Policy_Show_Hide
	Test Case： https://jira.tc.lenovo.com/browse/VFC-3438
	Author: Luiz Filho

@AudioSmartSettings_AdPolicy
Scenario: VFC3438_TestStep01_AudioSmartSettingsAdPolicy Check Audio Smart Settings
	Given Audio Smart Settings adpolicy is not configured
	And close lenovo vantage
	When ReLaunch Lenovo Vantage
	And go to Audio page
	Then The Audio Smart Settings section should be visible
	And The Audio Smart Settings jump to settings should be visible

@AudioSmartSettings_AdPolicy
Scenario: VFC3438_TestStep02_AudioSmartSettingsAdPolicy Check Audio Smart Settings
	Given Audio Smart Settings adpolicy is disabled
	And close lenovo vantage
	When ReLaunch Lenovo Vantage
	And go to Audio page
	Then The Audio Smart Settings section should be visible
	And The Audio Smart Settings jump to settings should be visible

@AudioSmartSettings_AdPolicy
Scenario: VFC3438_TestStep03_AudioSmartSettingsAdPolicy Check Audio Smart Settings
	Given Audio Smart Settings adpolicy is enabled
	And close lenovo vantage
	When ReLaunch Lenovo Vantage
	And go to Audio page
	Then The Audio Smart Settings section should not be visible
	And The Audio Smart Settings jump to settings should not be visible

@AudioSmartSettings_AdPolicy
Scenario: VFC3438_TestStep07_AudioSmartSettingsAdPolicy Check Audio Smart Settings
	Given Audio Smart Settings adpolicy is not configured
	And Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And go to Audio page
	Then The Audio Smart Settings section should be visible
	And The Audio Smart Settings jump to settings should be visible

@AudioSmartSettings_AdPolicy
Scenario: VFC3438_TestStep08_AudioSmartSettingsAdPolicy Check Audio Smart Settings
	Given Audio Smart Settings adpolicy is disabled
	And Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And go to Audio page
	Then The Audio Smart Settings section should be visible
	And The Audio Smart Settings jump to settings should be visible

@AudioSmartSettings_AdPolicy
Scenario: VFC3438_TestStep09_AudioSmartSettingsAdPolicy Check Audio Smart Settings
	Given Audio Smart Settings adpolicy is enabled
	And Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And go to Audio page
	Then The Audio Smart Settings section should not be visible
	And The Audio Smart Settings jump to settings should not be visible

@AudioSmartSettings_AdPolicy
Scenario: VFC3438_TestStep10_AudioSmartSettingsAdPolicy Check Audio Smart Settings
	Given Audio Smart Settings adpolicy is not configured
	And close lenovo vantage
	When Set Audio Smart Settings adpolicy to enabled
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then The Audio Smart Settings section should not be visible
	And The Audio Smart Settings jump to settings should not be visible

@AudioSmartSettings_AdPolicy
Scenario: VFC3438_TestStep11_AudioSmartSettingsAdPolicy Check Audio Smart Settings
	Given Audio Smart Settings adpolicy is not configured
	And close lenovo vantage
	When Set Audio Smart Settings adpolicy to disabled
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then The Audio Smart Settings section should be visible
	And The Audio Smart Settings jump to settings should be visible

@AudioSmartSettings_AdPolicy
Scenario: VFC3438_TestStep12_AudioSmartSettingsAdPolicy Check Audio Smart Settings
	Given Audio Smart Settings adpolicy is disabled
	And close lenovo vantage
	When Set Audio Smart Settings adpolicy to enabled
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then The Audio Smart Settings section should not be visible
	And The Audio Smart Settings jump to settings should not be visible

@AudioSmartSettings_AdPolicy
Scenario: VFC3438_TestStep13_AudioSmartSettingsAdPolicy Check Audio Smart Settings
	Given Audio Smart Settings adpolicy is disabled
	And close lenovo vantage
	When Set Audio Smart Settings adpolicy to not configured
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then The Audio Smart Settings section should be visible
	And The Audio Smart Settings jump to settings should be visible

@AudioSmartSettings_AdPolicy
Scenario: VFC3438_TestStep14_AudioSmartSettingsAdPolicy Check Audio Smart Settings
	Given Audio Smart Settings adpolicy is enabled
	And close lenovo vantage
	When Set Audio Smart Settings adpolicy to disabled
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then The Audio Smart Settings section should be visible
	And The Audio Smart Settings jump to settings should be visible

@AudioSmartSettings_AdPolicy
Scenario: VFC3438_TestStep15_AudioSmartSettingsAdPolicy Check Audio Smart Settings
	Given Audio Smart Settings adpolicy is enabled
	And close lenovo vantage
	When Set Audio Smart Settings adpolicy to not configured
	And ReLaunch Lenovo Vantage
	And go to Audio page
	Then The Audio Smart Settings section should be visible
	And The Audio Smart Settings jump to settings should be visible

@AudioSmartSettings_notSupport_AdPolicy
Scenario: VFC3438_TestStep16_AudioSmartSettingsAdPolicy Check Audio Smart Settings
	Given Audio Smart Settings adpolicy is enabled
	And close lenovo vantage
	When ReLaunch Lenovo Vantage
	And go to Audio page
	Then The Audio Smart Settings section should not be visible
	And The Audio Smart Settings jump to settings should not be visible

@AudioSmartSettings_notSupport_AdPolicy
Scenario: VFC3438_TestStep17_AudioSmartSettingsAdPolicy Check Audio Smart Settings
	Given Audio Smart Settings adpolicy is not configured
	And close lenovo vantage
	When ReLaunch Lenovo Vantage
	And go to Audio page
	Then The Audio Smart Settings section should not be visible
	And The Audio Smart Settings jump to settings should not be visible

@AudioSmartSettings_notSupport_AdPolicy
Scenario: VFC3438_TestStep18_AudioSmartSettingsAdPolicy Check Audio Smart Settings
	Given Audio Smart Settings adpolicy is disabled
	And close lenovo vantage
	When ReLaunch Lenovo Vantage
	And go to Audio page
	Then The Audio Smart Settings section should not be visible
	And The Audio Smart Settings jump to settings should not be visible

@Audio_AdPolicy
Scenario: VFC3438_TestStep19_AudioSmartSettingsAdPolicy Check Audio Smart Settings and Microphone
	Given microphone adpolicy is enabled
	And Audio Smart Settings adpolicy is enabled
	And close lenovo vantage
	When ReLaunch Lenovo Vantage
	Then the audio menu link should not be visible

@Audio_AdPolicy
Scenario: VFC3438_TestStep20_AudioSmartSettingsAdPolicy Check Audio Smart Settings and Microphone
	Given microphone adpolicy is disabled
	And Audio Smart Settings adpolicy is disabled
	And close lenovo vantage
	When ReLaunch Lenovo Vantage
	Then the audio menu link should be visible

@Audio_AdPolicy
Scenario: VFC3438_TestStep21_Audio Check Audio Smart Settings and Microphone
	Given microphone adpolicy is not configured
	And Audio Smart Settings adpolicy is not configured
	And close lenovo vantage
	When ReLaunch Lenovo Vantage
	Then the audio menu link should be visible

@Audio_AdPolicy
Scenario: VFC3438_TestStep22_Audio Audio Smart Settings and Microphone
	Given microphone adpolicy is enabled
	And Audio Smart Settings adpolicy is enabled
	And close lenovo vantage
	When ReLaunch Lenovo Vantage
	Then the my device settings audio tab should not be visible

@Audio_AdPolicy
Scenario: VFC3438_TestStep23_Audio Check Audio Smart Settings and Microphone
	Given microphone adpolicy is disabled
	And Audio Smart Settings adpolicy is disabled
	And close lenovo vantage
	When ReLaunch Lenovo Vantage
	Then the my device settings audio tab should be visible

@Audio_AdPolicy
Scenario: VFC3438_TestStep24_Audio Check Audio Smart Settings and Microphone
	Given microphone adpolicy is not configured
	And Audio Smart Settings adpolicy is not configured
	And close lenovo vantage
	When ReLaunch Lenovo Vantage
	Then the my device settings audio tab should be visible