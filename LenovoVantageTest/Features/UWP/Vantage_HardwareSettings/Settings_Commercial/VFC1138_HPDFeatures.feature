Feature: VFC1138_HPDFeatures
	Test Case： https://jira.tc.lenovo.com/browse/VFC-1138
	Author： Haiye Li

@HPDThinkSensorError
Scenario: VFC1138_TestStep01_Check title toggle is greyed
	Given Go to Smart Assist page
	Then  The toggle of Human Presence Sensing is greyed out and user can not change the toggle's state

@HPDThinkSensorError
Scenario: VFC1138_TestStep02_Check the context is Sensor has an issue. This feature is unavailable
	Given Go to Smart Assist page
	Then the context is Sensor has an issue. This feature is unavailable and the style follow the UI SPEC

@HPDThinkSensorError
Scenario: VFC1138_TestStep03_Check The whole HPD feature can not show except the total toggle Human Presence Sensing
	Given Go to Smart Assist page
	Then The whole HPD feature can not show except the total toggle Human Presence Sensing
	Then Take Screen Shot 1138HPDFeatures in 1138 under HSScreenShotResult  