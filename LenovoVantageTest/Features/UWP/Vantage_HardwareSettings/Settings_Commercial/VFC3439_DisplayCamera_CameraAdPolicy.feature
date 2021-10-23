Feature: VFC3439_DisplayCamera_Camera_AdPolicy
	Test Case： https://jira.tc.lenovo.com/browse/VFC-3439
	Author： Alejandro Schmechel

@Camera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Camera_Step01 Show Camera Section if AdPolicy is not configured
	Given Camera adpolicy is set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then camera section and jump to settings should be visible

@Camera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Camera_Step02 Show Camera Section after IT admin change the AdPolicy to disabled
	Given Camera adpolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then camera section and jump to settings should be visible

@Camera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Camera_Step03 Hide Camera Section after IT admin change the AdPolicy to enabled
	Given Camera adpolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then camera section and jump to settings should be not visible

@Camera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Camera_Step04 Show Camera Section after first launch if AdPolicy is not configured
	Given Camera adpolicy is set to not configured
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And Go to Display & Camera page
	Then camera section and jump to settings should be visible

@Camera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Camera_Step05 Show Camera Section after first launch if AdPolicy is disabled
	Given Camera adpolicy is set to disabled
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And Go to Display & Camera page
	Then camera section and jump to settings should be visible

@Camera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Camera_Step06 Hide Camera Section after first launch if AdPolicy is enabled
	Given Camera adpolicy is set to enabled
	And Uninstall the Lenovo Vantage
	When Wait 1 minutes
	Given Install Vantage
	And Go to Display & Camera page
	Then camera section and jump to settings should be not visible

@Camera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Camera_Step07 Show Camera Section if AdPolicy is not configured and Vantage was reseted
	Given Camera adpolicy is set to not configured
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And Go to Display & Camera page
	Then camera section and jump to settings should be visible

@Camera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Camera_Step08 Show Camera Section if AdPolicy is disabled and Vantage was reseted
	Given Camera adpolicy is set to disabled
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And Go to Display & Camera page
	Then camera section and jump to settings should be visible

@Camera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Camera_Step09 Hide Camera Section if AdPolicy is enabled and Vantage was reseted
	Given Camera adpolicy is set to enabled
	When close lenovo vantage
	Given Reset Vantage
	When Change Vantage Service 'default'
	And ReLaunch Lenovo Vantage
	And click OOBE
	And Go to Display & Camera page
	Then camera section and jump to settings should be not visible

@Camera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Camera_Step10 Hide Camera Section if AdPolicy is not configured and its changed to enabled
	Given Camera adpolicy is set to not configured
	When close lenovo vantage
	And Camera adpolicy is set to enabled
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then camera section and jump to settings should be not visible

@Camera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Camera_Step11 Show Camera Section if AdPolicy is not configured and its changed to disabled
	Given Camera adpolicy is set to not configured
	When close lenovo vantage
	And Camera adpolicy is set to disabled
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then camera section and jump to settings should be visible

@Camera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Camera_Step12 Hide Camera Section if AdPolicy is disabled and its changed to enabled
	Given Camera adpolicy is set to disabled
	When close lenovo vantage
	And Camera adpolicy is set to enabled
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then camera section and jump to settings should be not visible

@Camera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Camera_Step13 Show Camera Section if AdPolicy is disabled and its changed to not configured
	Given Camera adpolicy is set to disabled
	When close lenovo vantage
	And Camera adpolicy is set to not configured
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then camera section and jump to settings should be visible

@Camera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Camera_Step14 Show Camera Section if AdPolicy is enabled and its changed to disabled
	Given Camera adpolicy is set to enabled
	When close lenovo vantage
	And Camera adpolicy is set to disabled
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then camera section and jump to settings should be visible

@Camera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Camera_Step15 Show Camera Section if AdPolicy is enabled and its changed to not configured
	Given Camera adpolicy is set to enabled
	When close lenovo vantage
	And Camera adpolicy is set to not configured
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then camera section and jump to settings should be visible

@Camera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Camera_Step16 Hide Camera Section if AdPolicy is enabled and computer does not support camera
	Given disable camera driver
	And Camera adpolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then camera section and jump to settings should be not visible

@Camera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Camera_Step17 Hide Camera Section if AdPolicy is not configured and computer does not support camera
	Given disable camera driver
	And Camera adpolicy is set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then camera section and jump to settings should be not visible

@Camera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Camera_Step18 Hide Camera Section if AdPolicy is disabled and computer does not support camera
	Given disable camera driver
	And Camera adpolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Display & Camera page
	Then camera section and jump to settings should be not visible

@DisplayCamera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Step19 Hide Display & Camera link on menu when all sessions are with ADPolicy enabled
	Given Camera adpolicy is set to enabled
	And Display adpolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Device dropdown menu
	Then the element Display & Camera link should be not visible

@DisplayCamera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Step20 Show Display & Camera link on menu when all sessions are with ADPolicy disabled
	Given Camera adpolicy is set to disabled
	And Display adpolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Device dropdown menu
	Then the element Display & Camera link should be visible

@DisplayCamera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Step21 Show Display & Camera link on menu when all sessions are with ADPolicy not configured
	Given Camera adpolicy is set to not configured
	And Display adpolicy is set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Click Device dropdown menu
	Then the element Display & Camera link should be visible

@DisplayCamera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Step22 Hide Display & Camera Tab from My Device Settings page when all sessions are with ADPolicy enabled
	Given Camera adpolicy is set to enabled
	And Display adpolicy is set to enabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Device Settings page
	Then the element Display & Camera tab should be not visible

@DisplayCamera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Step23 Show Display & Camera Tab from My Device Settings page when all sessions are with ADPolicy disabled
	Given Camera adpolicy is set to disabled
	And Display adpolicy is set to disabled
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Device Settings page
	Then the element Display & Camera tab should be visible

@DisplayCamera_AdPolicy
Scenario: VFC3439_DisplayCameraAdPolicy_Step24 Show Display & Camera Tab from My Device Settings page when all sessions are with ADPolicy not configured
	Given Camera adpolicy is set to not configured
	And Display adpolicy is set to not configured
	When close lenovo vantage
	And ReLaunch Lenovo Vantage
	And Go to Device Settings page
	Then the element Display & Camera tab should be visible