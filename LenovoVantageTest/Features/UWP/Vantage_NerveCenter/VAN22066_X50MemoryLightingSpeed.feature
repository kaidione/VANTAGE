@GetLightingFile
Feature: VAN22066_X50MemoryLightingSpeed
	Test Case: https://lnvusjira.lenovonet.lenovo.local/browse/VAN-22066
	Author: Yang Liu
	Automated Test Step 01-06

Background:
	Then The Gaming mode value is 1 And the Method is GetMemoryLEDType
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature

@X50MemoryLightingSpeed
Scenario: VAN22066_TestStep01_Check the speed bar should not be shown 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Off"	
	Then The "Speed" is not show in Lighting

@X50MemoryLightingSpeed
Scenario: VAN22066_TestStep02_Check the speed bar should not be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Static"
	Then The "Speed" is not show in Lighting

@X50MemoryLightingSpeed
Scenario: VAN22066_TestStep03_Check the speed bar should be shown and default value = 2 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Flicker"
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'

@X50MemoryLightingSpeed
Scenario: VAN22066_TestStep04_Check the speed bar should be shown and default value = 2 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Breath"
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'

@X50MemoryLightingSpeed
Scenario: VAN22066_TestStep05_Check the speed bar should be shown and default value = 2 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Bounce"
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'

@X50MemoryLightingSpeed
Scenario: VAN22066_TestStep06_Check the speed bar should not be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Rainbow"
	Then The "Speed" is not show in Lighting
