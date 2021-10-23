@GetLightingFile
Feature: VAN22062_X50MemoryLightingBrightness
	Test Case: https://lnvusjira.lenovonet.lenovo.local/browse/VAN-22062
	Author: Yang Liu
	Automated Test Step 01-06

Background:
	Then The Gaming mode value is 1 And the Method is GetMemoryLEDType
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature

@X50MemoryLightingBrightness
Scenario: VAN22062_TestStep01_Check the brightness bar should not be shown 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Off"	
	Then The "Brightness" is not show in Lighting

@X50MemoryLightingBrightness
Scenario: VAN22062_TestStep02_Check the brightness bar should be shown and default value = 3
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Static"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@X50MemoryLightingBrightness
Scenario: VAN22062_TestStep03_Check the brightness bar should be shown and default value = 3 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Flicker"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@X50MemoryLightingBrightness
Scenario: VAN22062_TestStep04_Check the brightness bar should not be shown 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Breath"
	Then The "Brightness" is not show in Lighting

@X50MemoryLightingBrightness
Scenario: VAN22062_TestStep05_Check the brightness bar should be shown and default value = 3 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Bounce"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@X50MemoryLightingBrightness
Scenario: VAN22062_TestStep06_Check the brightness bar should not be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Rainbow"
	Then The "Brightness" is not show in Lighting