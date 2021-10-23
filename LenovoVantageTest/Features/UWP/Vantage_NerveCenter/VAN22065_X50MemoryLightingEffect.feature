@GetLightingFile
Feature: VAN22065_X50MemoryLightingEffect
	Test Case: https://lnvusjira.lenovonet.lenovo.local/browse/VAN-22065
	Author: Yang Liu
	Automated Test Step 01-13

Background:
	Then The Gaming mode value is 1 And the Method is GetMemoryLEDType
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature

@X50MemoryLightingEffect
Scenario: VAN22065_TestStep01_Check the effect dropdown menu 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "7/8 Legion Memory Lighting"
	Then effect dropdown menu should be expanded and effects should be shown:
		| Effect name |
		| Off         |
		| Static      |
		| Flicker     |
		| Breath      |
		| Rainbow     |
		| Bounce     |

@X50MemoryLightingEffect
Scenario: VAN22065_TestStep02_Check the lighting effect should be Off
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Off"
	Then Click "7/8 Legion Memory Lighting" and "Off"

@X50MemoryLightingEffect
Scenario: VAN22065_TestStep03_check Other lights effect 
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Off"

@X50MemoryLightingEffect
Scenario: VAN22065_TestStep04_Check the lighting effect should be On 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Static"
	Then The "Effect" is show in Lighting

@X50MemoryLightingEffect
Scenario: VAN22065_TestStep05_Check Other lights effect 
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Static"

@X50MemoryLightingEffect
Scenario: VAN22065_TestStep06_Check the lighting effect should be flicker effect
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Flicker"
	Then Click "7/8 Legion Memory Lighting" and "Flicker"

@X50MemoryLightingEffect
Scenario: VAN22065_TestStep07_Check the lighting effect should be flicker effect
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Flicker"

@X50MemoryLightingEffect
Scenario: VAN22065_TestStep08_Check the lighting effect should be Breath effect
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Breath"
	Then Click "7/8 Legion Memory Lighting" and "Breath"

@X50MemoryLightingEffect
Scenario: VAN22065_TestStep09_Check Other lights effect
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Breath"

@X50MemoryLightingEffect
Scenario: VAN22065_TestStep10_Check the lighting effect should be Bounce effect
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Bounce"
	Then Click "7/8 Legion Memory Lighting" and "Bounce"

@X50MemoryLightingEffect
Scenario: VAN22065_TestStep11_Check Other lights effect
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Bounce"

@X50MemoryLightingEffect
Scenario: VAN22065_TestStep12_Check the lighting effect should be Rainbow effect
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Rainbow"
	Then Click "7/8 Legion Memory Lighting" and "Rainbow"

@X50MemoryLightingEffect
Scenario: VAN22065_TestStep13_Check Other lights effect
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Bounce"