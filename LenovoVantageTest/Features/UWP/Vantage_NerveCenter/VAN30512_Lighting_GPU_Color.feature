Feature: VAN30512_GPULightingColor
	Test Case： https://jira.tc.lenovo.com/browse/VAN-30512
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

@GPULightingColorSquare
Scenario: VAN30512_TestStep01_Color Square should not be shown when effect is Off 
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Off"
	Then The "Color" is not show in Lighting

@GPULightingColorSquare
Scenario: VAN30512_TestStep02_Color Square should be shown when effect is Static 
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Static"
	Then The "Color" is show in Lighting
	Then Color should be RGB "0,211,254"

@GPULightingColorSquare
Scenario: VAN30512_TestStep03_Color Square should be shown when effect is Flicker 
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Flicker"
	Then The "Color" is show in Lighting
	Then Color should be RGB "0,211,254"

@GPULightingColorSquare
Scenario: VAN30512_TestStep04_Color Square should not be shown when effect is Breath 
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Breath"
	Then The "Color" is show in Lighting
	Then Color should be RGB "0,211,254"

@GPULightingColorSquare
Scenario: VAN30512_TestStep05_Color Square should not be shown when effect is Rainbow 
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Rainbow"
	Then The "Color" is not show in Lighting