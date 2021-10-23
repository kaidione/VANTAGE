@GetLightingFile
Feature: VAN22064_X50MemoryLighting
	Test Case: https://lnvusjira.lenovonet.lenovo.local/browse/VAN-22064
	Author: Yang Liu
	Automated Test Step 01-16

Background:
	Then The Gaming mode value is 1 And the Method is GetMemoryLEDType
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature

@X50MemoryLightingDefault
Scenario: VAN22064_TestStep01_Check the last light name should be Legion Memory Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "7/8 Legion Memory Lighting"
	Then The light name should be "Legion Memory Lighting"

@X50MemoryLightingDefault
Scenario: VAN22064_TestStep02_Check memory lighting default effect should be Rainbow
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and "Rainbow"

@X50MemoryLightingDefault
Scenario: VAN22064_TestStep03_Check Memory Lighting brightness bar should not be shown 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "7/8 Legion Memory Lighting"
	Then The "Brightness" is not show in Lighting

@X50MemoryLightingDefault
Scenario: VAN22064_TestStep04_Check Memory Lighting speed bar should not be shown 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "7/8 Legion Memory Lighting"
	Then The "Speed" is not show in Lighting

@X50MemoryLightingDefault
Scenario: VAN22064_TestStep05_Check Memory Lighting color square should not be shown 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "7/8 Legion Memory Lighting"
	Then The "Color" is not show in Lighting

@X50MemoryLightingDefault
Scenario: VAN22064_TestStep06_Check Memory lighting effect is Rainbow and consistent with BIOS 
	Given Need Compare File is 'True'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Rainbow"

@X50MemoryLightingDefault
Scenario: VAN22064_TestStep07_Check Memory lighting default effect should be Static 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and "Static"

@X50MemoryLightingDefault
Scenario: VAN22064_TestStep08_Check Memory Lighting brightness default value should be 3 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "7/8 Legion Memory Lighting"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@X50MemoryLightingDefault
Scenario: VAN22064_TestStep09_Check Memory Lighting speed bar should not be shown 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "7/8 Legion Memory Lighting"
	Then The "Speed" is not show in Lighting

@X50MemoryLightingDefault
Scenario: VAN22064_TestStep10_Check Memory Lighting color square should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "7/8 Legion Memory Lighting"
	Then The "Color" is show in Lighting

@X50MemoryLightingDefault
Scenario: VAN22064_TestStep11_Check Memory lighting effect is consistent with profile 2 settings and Lighting color should be 158DDD
	Given Need Compare File is 'True'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and "Static"
	Then Color should be RGB "21,141,221"

@X50MemoryLightingDefault
Scenario: VAN22064_TestStep12_Check Memory lighting default effect should be Off
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and "Off"

@X50MemoryLightingDefault
Scenario: VAN22064_TestStep13_Check Memory Lighting brightness bar should not be shown 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "7/8 Legion Memory Lighting"
	Then The "Brightness" is not show in Lighting

@X50MemoryLightingDefault
Scenario: VAN22064_TestStep14_Check Memory Lighting speed bar should not be shown 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "7/8 Legion Memory Lighting"
	Then The "Speed" is not show in Lighting

@X50MemoryLightingDefault
Scenario: VAN22064_TestStep15_Check Memory Lighting color square should not be shown 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "7/8 Legion Memory Lighting"
	Then The "Color" is not show in Lighting

@X50MemoryLightingDefault
Scenario: VAN22064_TestStep16_Check Memory lighting effect is consistent with profile 3 settings 
	Given Need Compare File is 'True'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click "7/8 Legion Memory Lighting" and Select "lightingType:Off"