Feature: VAN30517_GPULightingSpeed
	Test Case： https://jira.tc.lenovo.com/browse/VAN-30517
	Author: Xuwei
	Test Steps: 1-5

Background: 
	Given Machine is Gaming
	Then The Graphics Card vendor value is 1 And the Method is GetGPUVendor
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect

@GPULightingSpeed
Scenario: VAN30517_TestStep01_Speed bar should not be shown when effect is Off 
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Off"
	Then The "Speed" is not show in Lighting

@GPULightingSpeed
Scenario: VAN30517_TestStep02_Speed bar should be shown when effect is Static 
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Static"
	Then The "Speed" is not show in Lighting

@GPULightingSpeed
Scenario: VAN30517_TestStep03_Speed bar should be shown when effect is Flicker 
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Flicker"
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'

@GPULightingSpeed
Scenario: VAN30517_TestStep04_Speed bar should not be shown when effect is Breath 
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Breath"
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'

@GPULightingSpeed
Scenario: VAN30517_TestStep05_Speed bar should not be shown when effect is Rainbow 
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Rainbow"
	Then The "Speed" is not show in Lighting