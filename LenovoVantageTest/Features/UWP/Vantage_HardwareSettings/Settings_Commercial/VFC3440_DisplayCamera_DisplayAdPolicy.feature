Feature: VFC3440_DisplayCamera_Display_AdPolicy
	Test Case： https://jira.tc.lenovo.com/browse/VFC-3440
	Author： Alejandro Schmechel

@Display_AdPolicy
Scenario: VFC3440_DisplayCameraAdPolicy_Display_Step01 Show Display Section if AdPolicy is not configured
	Given Display adpolicy is set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then display section and jump to settings should be visible

@Display_AdPolicy
Scenario: VFC3440_DisplayCameraAdPolicy_Display_Step02 Show Display Section after IT admin change the AdPolicy to disabled
	Given Display adpolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then display section and jump to settings should be visible

@Display_AdPolicy
Scenario: VFC3440_DisplayCameraAdPolicy_Display_Step03 Hide Display Section after IT admin change the AdPolicy to enabled
	Given Display adpolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then display section and jump to settings should be not visible

@Display_AdPolicy
Scenario: VFC3440_DisplayCameraAdPolicy_Display_Step04 Show Display Section after first launch if AdPolicy is not configured
	Given Display adpolicy is set to not configured
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And Go to Display & Camera page
	Then display section and jump to settings should be visible

@Display_AdPolicy
Scenario: VFC3440_DisplayCameraAdPolicy_Display_Step05 Show Display Section after first launch if AdPolicy is disabled
	Given Display adpolicy is set to disabled
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And Go to Display & Camera page
	Then display section and jump to settings should be visible

@Display_AdPolicy
Scenario: VFC3440_DisplayCameraAdPolicy_Display_Step06 Hide Display Section after first launch if AdPolicy is enabled
	Given Display adpolicy is set to enabled
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And Go to Display & Camera page
	Then display section and jump to settings should be not visible

@Display_AdPolicy
Scenario: VFC3440_DisplayCameraAdPolicy_Display_Step07 Show Display Section if AdPolicy is not configured and Vantage was reseted
	Given Display adpolicy is set to not configured
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And Go to Display & Camera page
	Then display section and jump to settings should be visible

@Display_AdPolicy
Scenario: VFC3440_DisplayCameraAdPolicy_Display_Step08 Show Display Section if AdPolicy is disabled and Vantage was reseted
	Given Display adpolicy is set to disabled
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And Go to Display & Camera page
	Then display section and jump to settings should be visible

@Display_AdPolicy
Scenario: VFC3440_DisplayCameraAdPolicy_Display_Step09 Hide Display Section if AdPolicy is enabled and Vantage was reseted
	Given Display adpolicy is set to enabled
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And Go to Display & Camera page
	Then display section and jump to settings should be not visible

@Display_AdPolicy
Scenario: VFC3440_DisplayCameraAdPolicy_Display_Step10 Hide Display Section if AdPolicy is not configured and its changed to enabled
	Given Display adpolicy is set to not configured
	When close lenovo vantage
	And Display adpolicy is set to enabled
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then display section and jump to settings should be not visible

@Display_AdPolicy
Scenario: VFC3440_DisplayCameraAdPolicy_Display_Step11 Show Display Section if AdPolicy is not configured and its changed to disabled
	Given Display adpolicy is set to not configured
	When close lenovo vantage
	And Display adpolicy is set to disabled
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then display section and jump to settings should be visible

@Display_AdPolicy
Scenario: VFC3440_DisplayCameraAdPolicy_Display_Step12 Hide Display Section if AdPolicy is disabled and its changed to enabled
	Given Display adpolicy is set to disabled
	When close lenovo vantage
	And Display adpolicy is set to enabled
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then display section and jump to settings should be not visible

@Display_AdPolicy
Scenario: VFC3440_DisplayCameraAdPolicy_Display_Step13 Show Display Section if AdPolicy is disabled and its changed to not configured
	Given Display adpolicy is set to disabled
	When close lenovo vantage
	And Display adpolicy is set to not configured
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then display section and jump to settings should be visible

@Display_AdPolicy
Scenario: VFC3440_DisplayCameraAdPolicy_Display_Step14 Show Display Section if AdPolicy is enabled and its changed to disabled
	Given Display adpolicy is set to enabled
	When close lenovo vantage
	And Display adpolicy is set to disabled
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then display section and jump to settings should be visible

@Display_AdPolicy
Scenario: VFC3440_DisplayCameraAdPolicy_Display_Step15 Show Display Section if AdPolicy is enabled and its changed to not configured
	Given Display adpolicy is set to enabled
	When close lenovo vantage
	And Display adpolicy is set to not configured
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then display section and jump to settings should be visible