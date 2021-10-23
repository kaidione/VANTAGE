Feature: VFC3442_StandbySettingsAdPolicy
	Test Case： https://jira.tc.lenovo.com/browse/VFC-3442
	Author: Alejandro Schmechel

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step01 Show Standby settings section if AdPolicy is not configured
	Given Standby Settings AdPolicy is set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Standby Settings and Jump to Settings should be visible

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step02 Show Standby settings section if AdPolicy is disabled
	Given Standby Settings AdPolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Standby Settings and Jump to Settings should be visible

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step03 Hide Standby settings section if AdPolicy is enabled
	Given Standby Settings AdPolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Standby Settings and Jump to Settings should be not visible

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step04 Show Standby settings after first launch if AdPolicy is not configured
	Given Standby Settings AdPolicy is set to not configured
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Standby Settings and Jump to Settings should be visible

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step05 Show Standby settings after first launch if AdPolicy is disabled
	Given Standby Settings AdPolicy is set to disabled
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Standby Settings and Jump to Settings should be visible

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step06 Hide Standby settings after first launch if AdPolicy is enabled
	Given Standby Settings AdPolicy is set to enabled
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Standby Settings and Jump to Settings should be not visible

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step07 Show Standby settings if AdPolicy is not configured and Vantage was reset
	Given Standby Settings AdPolicy is set to not configured
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And Click Power Link on Menu
	Then Standby Settings and Jump to Settings should be visible

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step08 Show Standby settings if AdPolicy is disabled and Vantage was reset
	Given Standby Settings AdPolicy is set to disabled
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And Click Power Link on Menu
	Then Standby Settings and Jump to Settings should be visible

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step09 Hide Standby settings if AdPolicy is enabled and Vantage was reset
	Given Standby Settings AdPolicy is set to enabled
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And Click Power Link on Menu
	Then Standby Settings and Jump to Settings should be not visible

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step10 Hide Standby settings section if AdPolicy is not configured and its changed to enabled
	Given Standby Settings AdPolicy is set to not configured
	When close lenovo vantage
	And Standby Settings AdPolicy is set to enabled
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Standby Settings and Jump to Settings should be not visible

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step11 Show Standby settings section if AdPolicy is not configured and its changed to disabled
	Given Standby Settings AdPolicy is set to not configured
	When close lenovo vantage
	And Standby Settings AdPolicy is set to disabled
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Standby Settings and Jump to Settings should be visible

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step12 Hide Standby settings section if AdPolicy is disabled and its changed to enabled
	Given Standby Settings AdPolicy is set to disabled
	When close lenovo vantage
	And Standby Settings AdPolicy is set to enabled
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Standby Settings and Jump to Settings should be not visible

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step13 Show Standby settings section if AdPolicy is disabled and its changed to not configured
	Given Standby Settings AdPolicy is set to disabled
	When close lenovo vantage
	And Standby Settings AdPolicy is set to not configured
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Standby Settings and Jump to Settings should be visible

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step14 Show Standby settings section if AdPolicy is enabled and its changed to disabled
	Given Standby Settings AdPolicy is set to enabled
	When close lenovo vantage
	And Standby Settings AdPolicy is set to disabled
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Standby Settings and Jump to Settings should be visible

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step15 Show Standby settings section if AdPolicy is enabled and its changed to not configured
	Given Standby Settings AdPolicy is set to enabled
	When close lenovo vantage
	And Standby Settings AdPolicy is set to not configured
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Standby Settings and Jump to Settings should be visible

@StandBySettings_NoSupport_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step16 Hide Standby settings section if AdPolicy is enabled and machine does not support the feature
	Given Standby Settings AdPolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Standby Settings and Jump to Settings should be not visible

@StandBySettings_NoSupport_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step17 Hide Standby settings section if AdPolicy is not configured and machine does not support the feature
	Given Standby Settings AdPolicy is set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Standby Settings and Jump to Settings should be not visible

@StandBySettings_NoSupport_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step18 Hide Standby settings section if AdPolicy is disabled and machine does not support the feature
	Given Standby Settings AdPolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Standby Settings and Jump to Settings should be not visible

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step19 Hide Power Page Link on menu if AdPolicy for all features on section are enabled
	Given AdPolicy for all features on StandbySettings page are set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Open Menu to check power link
	Then Power Link should be not visible

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step20 Show Power Page Link on menu if AdPolicy for all features on section are disabled
	Given AdPolicy for all features on StandbySettings page are set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Open Menu to check power link
	Then Power Link should be visible

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step21 Show Power Page Link on menu if AdPolicy for all features on section are not configured
	Given AdPolicy for all features on StandbySettings page are set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Open Menu to check power link
	Then Power Link should be visible

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step22 Hide Power Page Tab on My Device Settings if AdPolicy for all features on section are enabled
	Given AdPolicy for all features on StandbySettings page are set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Device Section to check Tab
	Then Power Tab should be not visible

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step23 Show Power Page Tab on My Device Settings if AdPolicy for all features on section are disabled
	Given AdPolicy for all features on StandbySettings page are set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Device Section to check Tab
	Then Power Tab should be visible

@StandBySettings_AdPolicy
Scenario: VFC3442_StandBySettingsAdPolicy_Step24 Show Power Page Tab on My Device Settings if AdPolicy for all features on section are not configured
	Given AdPolicy for all features on StandbySettings page are set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Device Section to check Tab
	Then Power Tab should be visible