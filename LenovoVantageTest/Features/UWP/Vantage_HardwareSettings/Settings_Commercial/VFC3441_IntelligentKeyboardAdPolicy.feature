Feature: VFC3441_IntelligentKeyboardAdPolicy
	Test Case: https://jira.tc.lenovo.com/browse/VFC-3441
	Author: Alejandro Schmechel

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step01 Show Intelligent Keyboard section if AdPolicy is not configured
	Given Intelligent Keyboard AdPolicy is set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Navigate to Input Page
	Then Intelligent Keyboard and Jump to Settings should be visible

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step02 Show Intelligent Keyboard section after IT admin change the AdPolicy to disabled
	Given Intelligent Keyboard AdPolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Navigate to Input Page
	Then Intelligent Keyboard and Jump to Settings should be visible

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step03 Hide Intelligent Keyboard section after IT admin change the AdPolicy to enabled
	Given Intelligent Keyboard AdPolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Navigate to Input Page
	Then Intelligent Keyboard and Jump to Settings should be not visible

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step04 Show Intelligent Keyboard after first launch if AdPolicy is not configured
	Given Intelligent Keyboard AdPolicy is set to not configured
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And ReLaunch Lenovo Vantage
	And Navigate to Input Page
	Then Intelligent Keyboard and Jump to Settings should be visible

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step05 Show Intelligent Keyboard after first launch if AdPolicy is disabled
	Given Intelligent Keyboard AdPolicy is set to disabled
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And ReLaunch Lenovo Vantage
	And Navigate to Input Page
	Then Intelligent Keyboard and Jump to Settings should be visible

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step06 Hide Intelligent Keyboard after first launch if AdPolicy is enabled
	Given Intelligent Keyboard AdPolicy is set to enabled
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And ReLaunch Lenovo Vantage
	And Navigate to Input Page
	Then Intelligent Keyboard and Jump to Settings should be not visible

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step07 Show Intelligent Keyboard if AdPolicy is not configured and Vantage was reseted
	Given Intelligent Keyboard AdPolicy is set to not configured
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And Navigate to Input Page
	Then Intelligent Keyboard and Jump to Settings should be visible

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step08 Show Intelligent Keyboard if AdPolicy is disabled and Vantage was reseted
	Given Intelligent Keyboard AdPolicy is set to disabled
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And Navigate to Input Page
	Then Intelligent Keyboard and Jump to Settings should be visible

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step09 Hide Intelligent Keyboard if AdPolicy is enabled and Vantage was reseted
	Given Intelligent Keyboard AdPolicy is set to enabled
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And Navigate to Input Page
	Then Intelligent Keyboard and Jump to Settings should be not visible

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step10 Hide Intelligent Keyboard section if AdPolicy is not configured and its changed to enabled
	Given Intelligent Keyboard AdPolicy is set to not configured
	When close lenovo vantage
	And Intelligent Keyboard AdPolicy is set to enabled
	And ReLaunch Lenovo Vantage
	And Navigate to Input Page
	Then Intelligent Keyboard and Jump to Settings should be not visible

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step11 Show Intelligent Keyboard section if AdPolicy is not configured and its changed to disabled
	Given Intelligent Keyboard AdPolicy is set to not configured
	When close lenovo vantage
	And Intelligent Keyboard AdPolicy is set to disabled
	And ReLaunch Lenovo Vantage
	And Navigate to Input Page
	Then Intelligent Keyboard and Jump to Settings should be visible

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step12 Hide Intelligent Keyboard section if AdPolicy is disabled and its changed to enabled
	Given Intelligent Keyboard AdPolicy is set to disabled
	When close lenovo vantage
	And Intelligent Keyboard AdPolicy is set to enabled
	And ReLaunch Lenovo Vantage
	And Navigate to Input Page
	Then Intelligent Keyboard and Jump to Settings should be not visible

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step13 Show Intelligent Keyboard section if AdPolicy is disabled and its changed to not configured
	Given Intelligent Keyboard AdPolicy is set to disabled
	When close lenovo vantage
	And Intelligent Keyboard AdPolicy is set to not configured
	And ReLaunch Lenovo Vantage
	And Navigate to Input Page
	Then Intelligent Keyboard and Jump to Settings should be visible

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step14 Show Intelligent Keyboard section if AdPolicy is enabled and its changed to disabled
	Given Intelligent Keyboard AdPolicy is set to enabled
	When close lenovo vantage
	And Intelligent Keyboard AdPolicy is set to disabled
	And ReLaunch Lenovo Vantage
	And Navigate to Input Page
	Then Intelligent Keyboard and Jump to Settings should be visible

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step15 Show Intelligent Keyboard section if AdPolicy is enabled and its changed to not configured
	Given Intelligent Keyboard AdPolicy is set to enabled
	When close lenovo vantage
	And Intelligent Keyboard AdPolicy is set to not configured
	And ReLaunch Lenovo Vantage
	And Navigate to Input Page
	Then Intelligent Keyboard and Jump to Settings should be visible

@IntelligentKeyboard_NoSupport_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step16 Hide Intelligent Keyboard section if AdPolicy is enabled and machine does not support the feature
	Given Intelligent Keyboard AdPolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Open Device dropdown menu to check Input Link
	Then Input & Accessories Link should be not visible
	And Navigate to Input Page
	Then Input & Accessories Tab should be not visible

@IntelligentKeyboard_NoSupport_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step17 Hide Intelligent Keyboard section if AdPolicy is not configured and machine does not support the feature
	Given Intelligent Keyboard AdPolicy is set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Open Device dropdown menu to check Input Link
	Then Input & Accessories Link should be not visible
	And Navigate to Input Page
	Then Input & Accessories Tab should be not visible

@IntelligentKeyboard_NoSupport_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step18 Hide Intelligent Keyboard section if AdPolicy is disabled and machine does not support the feature
	Given Intelligent Keyboard AdPolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Open Device dropdown menu to check Input Link
	Then Input & Accessories Link should be not visible
	And Navigate to Input Page
	Then Input & Accessories Tab should be not visible

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step19 Hide Input & Accessories link on menu when all sessions are with ADPolicy enabled
	Given Intelligent Keyboard AdPolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Open Device dropdown menu to check Input Link
	Then Input & Accessories Link should be not visible

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step20 Hide Input & Accessories link on menu when all sessions are with ADPolicy is not configured
	Given Intelligent Keyboard AdPolicy is set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Open Device dropdown menu to check Input Link
	Then Input & Accessories Link should be visible

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step21 Hide Input & Accessories link on menu when all sessions are with ADPolicy disabled
	Given Intelligent Keyboard AdPolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Open Device dropdown menu to check Input Link
	Then Input & Accessories Link should be visible

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step22 Hide Input & Accessories Tab from My Device Settings when all sessions are with ADPolicy enabled
	Given Intelligent Keyboard AdPolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Navigate to Input Page
	Then Input & Accessories Tab should be not visible

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step23 Show Input & Accessories Tab from My Device Settings when all sessions are with ADPolicy disabled
	Given Intelligent Keyboard AdPolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Navigate to Input Page
	Then Input & Accessories Tab should be visible

@IntelligentKeyboard_AdPolicy
Scenario: VFC3441_InteligentKeyboardAdPolicy_Step24 Show Input & Accessories Tab from My Device Settings when all sessions are with ADPolicy not configured
	Given Intelligent Keyboard AdPolicy is set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Navigate to Input Page
	Then Input & Accessories Tab should be visible