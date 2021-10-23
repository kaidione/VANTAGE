Feature: VAN30511_GPULightingBrightness
	Test Case： https://jira.tc.lenovo.com/browse/VAN-30511
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

@GPULightingBrightness
Scenario: VAN30511_TestStep01_Brightness bar should not be shown when effect is Off 
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Off"
	Then The "Brightness" is not show in Lighting

@GPULightingBrightness
Scenario: VAN30511_TestStep02_Brightness bar should be shown when effect is Static 
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Static"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@GPULightingBrightness
Scenario: VAN30511_TestStep03_Brightness bar should be shown when effect is Flicker 
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Flicker"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@GPULightingBrightness
Scenario: VAN30511_TestStep04_Brightness bar should not be shown when effect is Breath 
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Breath"
	Then The "Brightness" is not show in Lighting

@GPULightingBrightness
Scenario: VAN30511_TestStep05_Brightness bar should not be shown when effect is Rainbow 
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Rainbow"
	Then The "Brightness" is not show in Lighting