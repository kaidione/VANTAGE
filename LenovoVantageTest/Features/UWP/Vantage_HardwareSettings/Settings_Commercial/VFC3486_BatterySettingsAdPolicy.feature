Feature: VFC-3486_BatterySettingsAdPolicy
	Test Case： https://jira.tc.lenovo.com/browse/VFC-3486
	Author: Alejandro Schmechel

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step01 Show Battery settings section if AdPolicy is not configured
	Given Battery Settings AdPolicy is set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	Then Battery Settings and Jump to Settings should be visible

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step02 Show Battery settings section if AdPolicy is disabled
	Given Battery Settings AdPolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	Then Battery Settings and Jump to Settings should be visible

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step03 Hide Battery settings section if AdPolicy is enabled
	Given Battery Settings AdPolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	Then Battery Settings and Jump to Settings should be not visible

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step04 Show Battery settings after first launch if AdPolicy is not configured
	Given Battery Settings AdPolicy is set to not configured
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	Then Battery Settings and Jump to Settings should be visible

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step05 Show Battery settings after first launch if AdPolicy is disabled
	Given Battery Settings AdPolicy is set to disabled
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	Then Battery Settings and Jump to Settings should be visible

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step06 Hide Battery settings after first launch if AdPolicy is enabled
	Given Battery Settings AdPolicy is set to enabled
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	Then Battery Settings and Jump to Settings should be not visible

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step07 Show Battery settings if AdPolicy is not configured and Vantage was reset
	Given Battery Settings AdPolicy is set to not configured
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And Go to Power Page
	Then Battery Settings and Jump to Settings should be visible

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step08 Show Battery settings if AdPolicy is disabled and Vantage was reset
	Given Battery Settings AdPolicy is set to disabled
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And Go to Power Page
	Then Battery Settings and Jump to Settings should be visible

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step09 Hide Battery settings if AdPolicy is enabled and Vantage was reset
	Given Battery Settings AdPolicy is set to enabled
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And Go to Power Page
	Then Battery Settings and Jump to Settings should be not visible

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step10 Hide Battery settings section if AdPolicy is not configured and its changed to enabled
	Given Battery Settings AdPolicy is set to not configured
	When close lenovo vantage
	And Battery Settings AdPolicy is set to enabled
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	Then Battery Settings and Jump to Settings should be not visible

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step11 Hide Battery settings section if AdPolicy is not configured and its changed to disabled
	Given Battery Settings AdPolicy is set to not configured
	When close lenovo vantage
	And Battery Settings AdPolicy is set to disabled
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	Then Battery Settings and Jump to Settings should be visible

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step12 Hide Battery settings section if AdPolicy is disabled and its changed to enabled
	Given Battery Settings AdPolicy is set to disabled
	When close lenovo vantage
	And Battery Settings AdPolicy is set to enabled
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	Then Battery Settings and Jump to Settings should be not visible

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step13 Show Battery settings section if AdPolicy is disabled and its changed to not configured
	Given Battery Settings AdPolicy is set to disabled
	When close lenovo vantage
	And Battery Settings AdPolicy is set to not configured
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	Then Battery Settings and Jump to Settings should be visible

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step14 Show Battery settings section if AdPolicy is enabled and its changed to disabled
	Given Battery Settings AdPolicy is set to enabled
	When close lenovo vantage
	And Battery Settings AdPolicy is set to disabled
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	Then Battery Settings and Jump to Settings should be visible

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step15 Show Battery settings section if AdPolicy is enabled and its changed to not configured
	Given Battery Settings AdPolicy is set to enabled
	When close lenovo vantage
	And Battery Settings AdPolicy is set to not configured
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	Then Battery Settings and Jump to Settings should be visible

@BatterySettings_NoSupport_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step16 Hide Battery settings section if AdPolicy is enabled and machine does not support the feature
	Given Battery Settings AdPolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Battery Settings and Jump to Settings should be not visible

@BatterySettings_NoSupport_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step17 Hide Battery settings section if AdPolicy is not configured and machine does not support the feature
	Given Battery Settings AdPolicy is set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Battery Settings and Jump to Settings should be not visible

@BatterySettings_NoSupport_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step18 Hide Battery settings section if AdPolicy is disabled and machine does not support the feature
	Given Battery Settings AdPolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Battery Settings and Jump to Settings should be not visible

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step19 Hide Power Page Link on menu if AdPolicy for all features on section are enabled
	Given AdPolicy for all features on BatterySettings page are set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Power Section Link on Menu
	Then Power Link element should be not visible

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step20 Show Power Page Link on menu if AdPolicy for all features on section are disabled
	Given AdPolicy for all features on BatterySettings page are set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Power Section Link on Menu
	Then Power Link element should be visible

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step21 Show Power Page Link on menu if AdPolicy for all features on section are not configured
	Given AdPolicy for all features on BatterySettings page are set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Power Section Link on Menu
	Then Power Link element should be visible

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step22 Hide Power Page Tab on My Device Settings if AdPolicy for all features on section are enabled
	Given AdPolicy for all features on BatterySettings page are set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Device Section to check Power Tab
	Then Power Tab element should be not visible

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step23 Show Power Page Tab on My Device Settings if AdPolicy for all features on section are disabled
	Given AdPolicy for all features on BatterySettings page are set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Device Section to check Power Tab
	Then Power Tab element should be visible

@BatterySettings_AdPolicy
Scenario: VFC-3486_BatterySettingsAdPolicy_Step24 Show Power Page Tab on My Device Settings if AdPolicy for all features on section are not configured
	Given AdPolicy for all features on BatterySettings page are set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Device Section to check Power Tab
	Then Power Tab element should be visible