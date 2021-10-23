@GetLightingFile
Feature: VAN30516_GPULightingEffect
	Test Case: https://lnvusjira.lenovonet.lenovo.local/browse/VAN-30516
	Author: Jinxin Li
	Automated Test Step 01-16

Background: 
	Given Machine is Gaming
	Then The Graphics Card vendor value is 1 And the Method is GetGPUVendor
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature

@GPULightingEffect
Scenario: VAN30516_TestStep01_GPU Lighting Effect
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "8/8 Legion GPU Iconic Lighting"
	Then effect dropdown menu should be expanded and effects should be shown:
		| Effect name |
		| Off         |
		| Static      |
		| Flicker     |
		| Breath      |
		| Rainbow     |

#Remove AMD 
#@GPULightingEffect
#Scenario: VAN30516_TestStep02_GPU Lighting Effect
#	Given click the the customize
#	Given Lighting page is opened
#	Given select the profile 2
#	When Set to default effect
#	Then Click The "8/9 Legion GPU Logo Lighting"
#	Then effect dropdown menu should be expanded and effects should be shown:
#		| Effect name |
#		| Off         |
#		| Static      |

@GPULightingEffect
Scenario: VAN30516_TestStep03_GPU Lighting Effect
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Off"

@GPULightingEffect
Scenario: VAN30516_TestStep04_GPU Lighting Effect
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Off"

@GPULightingEffect
Scenario: VAN30516_TestStep05_GPU Lighting Effect
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Static"

@GPULightingEffect
Scenario: VAN30516_TestStep06_GPU Lighting Effect
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Static"

@GPULightingEffect
Scenario: VAN30516_TestStep07_GPU Lighting Effect
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Flicker"

@GPULightingEffect
Scenario: VAN30516_TestStep08_GPU Lighting Effect
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Flicker"

@GPULightingEffect
Scenario: VAN30516_TestStep09_GPU Lighting Effect
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Breath"

@GPULightingEffect
Scenario: VAN30516_TestStep10_GPU Lighting Effect
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Breath"

@GPULightingEffect
Scenario: VAN30516_TestStep11_GPU Lighting Effect
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Rainbow"

@GPULightingEffect
Scenario: VAN30516_TestStep12_GPU Lighting Effect
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "lightingType:Rainbow"
