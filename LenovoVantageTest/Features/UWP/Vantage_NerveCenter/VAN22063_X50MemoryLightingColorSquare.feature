@GetLightingFile
Feature: VAN22063_X50MemoryLightingColorSquare
	Test Case: https://lnvusjira.lenovonet.lenovo.local/browse/VAN-22063
	Author: Yang Liu
	Automated Test Step 01-06

Background:
	Then The Gaming mode value is 1 And the Method is GetMemoryLEDType
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature

@X50MemoryLightingColorSquare
Scenario: VAN22063_TestStep01_Check the color square should not be shown 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Off"	
	Then The "Color" is not show in Lighting

@X50MemoryLightingColorSquare
Scenario: VAN22063_TestStep02_Check the color square should be shown and default color is 158DDD
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Static"
	Then The "Color" is show in Lighting
	Then Color should be RGB "21,141,221"

@X50MemoryLightingColorSquare
Scenario: VAN22063_TestStep03_Check the color square should be shown and default color is 158DDD 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Flicker"
	Then The "Color" is show in Lighting
	Then Color should be RGB "21,141,221"

@X50MemoryLightingColorSquare
Scenario: VAN22063_TestStep04_Check the color square should be shown and default color is 158DDD
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Breath"
	Then The "Color" is show in Lighting
	Then Color should be RGB "21,141,221"

@X50MemoryLightingColorSquare
Scenario: VAN22063_TestStep05_Check the color square should be shown and default color is 158DDD 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Bounce"
	Then The "Color" is show in Lighting
	Then Color should be RGB "21,141,221"

@X50MemoryLightingColorSquare
Scenario: VAN22063_TestStep06_Check the color square should not be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Rainbow"
	Then The "Color" is not show in Lighting