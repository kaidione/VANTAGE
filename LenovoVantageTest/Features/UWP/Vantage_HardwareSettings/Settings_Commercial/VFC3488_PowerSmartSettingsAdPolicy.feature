Feature: VFC3488_PowerSmartSettingsAdPolicy
	Test Case： https://jira.tc.lenovo.com/browse/VFC-3488
	Author: Alejandro Schmechel

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step01 Show Power Smart settings section if AdPolicy is not configured
	Given Power Smart Settings AdPolicy is set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Power Smart Settings and Jump to Settings should be visible

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step02 Show Power Smart settings section if AdPolicy is disabled
	Given Power Smart Settings AdPolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Power Smart Settings and Jump to Settings should be visible

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step03 Hide Power Smart settings section if AdPolicy is enabled
	Given Power Smart Settings AdPolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Power Smart Settings and Jump to Settings should be not visible

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step04 Show Power Smart settings after first launch if AdPolicy is not configured
	Given Power Smart Settings AdPolicy is set to not configured
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Power Smart Settings and Jump to Settings should be visible

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step05 Show Power Smart settings after first launch if AdPolicy is disabled
	Given Power Smart Settings AdPolicy is set to disabled
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Power Smart Settings and Jump to Settings should be visible

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step06 Hide Power Smart settings after first launch if AdPolicy is enabled
	Given Power Smart Settings AdPolicy is set to enabled
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Power Smart Settings and Jump to Settings should be not visible

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step07 Show Power Smart settings if AdPolicy is not configured and Vantage was reset
	Given Power Smart Settings AdPolicy is set to not configured
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And Click Power Link on Menu
	Then Power Smart Settings and Jump to Settings should be visible

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step08 Show Power Smart settings if AdPolicy is disabled and Vantage was reset
	Given Power Smart Settings AdPolicy is set to disabled
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And Click Power Link on Menu
	Then Power Smart Settings and Jump to Settings should be visible

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step09 Hide Power Smart settings if AdPolicy is enabled and Vantage was reset
	Given Power Smart Settings AdPolicy is set to enabled
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And Click Power Link on Menu
	Then Power Smart Settings and Jump to Settings should be not visible

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step10 Hide Power Smart settings section if AdPolicy is not configured and its changed to enabled
	Given Power Smart Settings AdPolicy is set to not configured
	When close lenovo vantage
	And Power Smart Settings AdPolicy is set to enabled
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Power Smart Settings and Jump to Settings should be not visible

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step11 Show Power Smart settings section if AdPolicy is not configured and its changed to disabled
	Given Power Smart Settings AdPolicy is set to not configured
	When close lenovo vantage
	And Power Smart Settings AdPolicy is set to disabled
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Power Smart Settings and Jump to Settings should be visible

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step12 Hide Power Smart settings section if AdPolicy is disabled and its changed to enabled
	Given Power Smart Settings AdPolicy is set to disabled
	When close lenovo vantage
	And Power Smart Settings AdPolicy is set to enabled
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Power Smart Settings and Jump to Settings should be not visible

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step13 Show Power Smart settings section if AdPolicy is disabled and its changed to not configured
	Given Power Smart Settings AdPolicy is set to disabled
	When close lenovo vantage
	And Power Smart Settings AdPolicy is set to not configured
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Power Smart Settings and Jump to Settings should be visible

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step14 Show Power Smart settings section if AdPolicy is enabled and its changed to disabled
	Given Power Smart Settings AdPolicy is set to enabled
	When close lenovo vantage
	And Power Smart Settings AdPolicy is set to disabled
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Power Smart Settings and Jump to Settings should be visible

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step15 Show Power Smart settings section if AdPolicy is enabled and its changed to not configured
	Given Power Smart Settings AdPolicy is set to enabled
	When close lenovo vantage
	And Power Smart Settings AdPolicy is set to not configured
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Power Smart Settings and Jump to Settings should be visible

@PowerSmartSettings_NoSupport_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step16 Hide Power Smart settings section if AdPolicy is enabled and machine does not support the feature
	Given Power Smart Settings AdPolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Power Smart Settings and Jump to Settings should be not visible

@PowerSmartSettings_NoSupport_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step17 Hide Power Smart settings section if AdPolicy is not configured and machine does not support the feature
	Given Power Smart Settings AdPolicy is set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Power Smart Settings and Jump to Settings should be not visible

@PowerSmartSettings_NoSupport_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step18 Hide Power Smart settings section if AdPolicy is disabled and machine does not support the feature
	Given Power Smart Settings AdPolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Power Link on Menu
	Then Power Smart Settings and Jump to Settings should be not visible

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step19 Hide Power Page Link on menu if AdPolicy for all features on section are enabled
	Given AdPolicy for all features on PowerSmartSettings page are set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Open Menu to check power link
	Then Power Link should be not visible

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step20 Show Power Page Link on menu if AdPolicy for all features on section are disabled
	Given AdPolicy for all features on PowerSmartSettings page are set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Open Menu to check power link
	Then Power Link should be visible

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step21 Show Power Page Link on menu if AdPolicy for all features on section are not configured
	Given AdPolicy for all features on PowerSmartSettings page are set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Open Menu to check power link
	Then Power Link should be visible

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step22 Hide Power Page Tab on My Device Settings if AdPolicy for all features on section are enabled
	Given AdPolicy for all features on PowerSmartSettings page are set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Device Section to check Tab
	Then Power Tab should be not visible

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step23 Show Power Page Tab on My Device Settings if AdPolicy for all features on section are disabled
	Given AdPolicy for all features on PowerSmartSettings page are set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Device Section to check Tab
	Then Power Tab should be visible

@PowerSmartSettings_AdPolicy
Scenario: VFC3488_PowerSmartSettingsAdPolicy_Step24 Show Power Page Tab on My Device Settings if AdPolicy for all features on section are not configured
	Given AdPolicy for all features on PowerSmartSettings page are set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Device Section to check Tab
	Then Power Tab should be visible