@GetLightingFile
Feature: VAN30518_Part1_LightingSwitchEightLights
	Test Case: https://lnvusjira.lenovonet.lenovo.local/browse/VAN-30518
	Author: Xuwei
	Automated Test Step 01-24

Background:
	Then The Graphics Card vendor value is 1 And the Method is GetGPUVendor
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature

@LightingSwitchEightLights
Scenario: VAN30518_TestStep01_Check 1/8 lighting should be shown in the page
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then The light name should be "1 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep02_Check the 1/8 lighting settings the effect should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then The "Effect" is show in Lighting

@LightingSwitchEightLights
Scenario: VAN30518_TestStep03_Check 1/8 lighting area in the machine image should be lighted and the color is same with settings
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "1 / 8."
	Then Take Screen Shot 1_8_LightingMachineImageandColor_TestStep03 in 30518 under GamingScreenShotResult

@LightingSwitchEightLights
Scenario: VAN30518_TestStep04_Check 2/8 Lighting should be shown in the page
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "1 / 8."
	Given click right arrow 1 times
	Then The light name should be "2 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep05_Check the 2/8 lighting settings the effect should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "2 / 8."
	Given click right arrow 1 times
	Then The "Effect" is show in Lighting

@LightingSwitchEightLights
Scenario: VAN30518_TestStep06_Check 2/8 lighting area in the machine image should be lighted and the color is same with settings
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "2 / 8."
	Then Take Screen Shot 2_8_LightingMachineImageandColor_TestStep06 in 30518 under GamingScreenShotResult

@LightingSwitchEightLights
Scenario: VAN30518_TestStep07_Check 3/8 Lighting should be shown in the page
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "2 / 8."
	Given click right arrow 1 times
	Then The light name should be "3 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep08_Check the 3/8 lighting settings effect dropdown menu,brightness bar,speed bar and color square
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect 
	Then Click The "2 / 8."
	Given click right arrow 1 times
	Then Click "3 / 8." and Select "lightingType:Breath"
	Then The "Effect" is show in Lighting
	Then The "Brightness" is show in Lighting
	Then The "Speed" is show in Lighting
	Then The "Color" is show in Lighting

@LightingSwitchEightLights
Scenario: VAN30518_TestStep09_Check 3/8 lighting area in the machine image should be lighted and the color is same with settings
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "3 / 8."
	Then Take Screen Shot 3_8_LightingMachineImageandColor_TestStep09 in 30518 under GamingScreenShotResult

@LightingSwitchEightLights
Scenario: VAN30518_TestStep10_Check 4/8 Lighting should be shown in the page
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "3 / 8."
	Given click right arrow 1 times
	Then The light name should be "4 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep11_Check the 4/8 lighting settings effect dropdown menu,brightness bar,speed bar and color square
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "3 / 8."
	Given click right arrow 1 times
	Then Click "4 / 8." and Select "lightingType:Breath"
	Then The "Effect" is show in Lighting
	Then The "Brightness" is show in Lighting
	Then The "Speed" is show in Lighting
	Then The "Color" is show in Lighting

@LightingSwitchEightLights
Scenario: VAN30518_TestStep12_Check 4/8 lighting area in the machine image should be lighted and the color is same with settings
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "4 / 8."
	Then Take Screen Shot 4_8_LightingMachineImageandColor_TestStep12 in 30518 under GamingScreenShotResult

@LightingSwitchEightLights
Scenario: VAN30518_TestStep13_Check 5/8 Lighting should be shown in the page
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "4 / 8."
	Given click right arrow 1 times
	Then The light name should be "5 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep14_Check the 5/8 lighting settings effect dropdown menu,brightness bar,speed bar and color square
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "4 / 8."
	Given click right arrow 1 times
	Then Click "5 / 8." and Select "lightingType:Breath"
	Then The "Effect" is show in Lighting
	Then The "Brightness" is show in Lighting
	Then The "Speed" is show in Lighting
	Then The "Color" is show in Lighting

@LightingSwitchEightLights
Scenario: VAN30518_TestStep15_Check 5/8 lighting area in the machine image should be lighted and the color is same with settings
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "4 / 8."
	Given click right arrow 1 times
	Then Take Screen Shot 5_8_LightingMachineImageandColor_TestStep15 in 30518 under GamingScreenShotResult

@LightingSwitchEightLights
Scenario: VAN30518_TestStep16_Check 6/8 Lighting should be shown in the page
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "5 / 8."
	Given click right arrow 1 times
	Then The light name should be "6 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep17_Check the 6/8 lighting settings effect dropdown menu,brightness bar,speed bar and color square
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "5 / 8."
	Given click right arrow 1 times
	Then Click "6 / 8." and Select "lightingType:Breath"
	Then The "Effect" is show in Lighting
	Then The "Brightness" is show in Lighting
	Then The "Speed" is show in Lighting
	Then The "Color" is show in Lighting

@LightingSwitchEightLights
Scenario: VAN30518_TestStep18_Check 6/8 lighting area in the machine image should be lighted and the color is same with settings
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "6 / 8."
	Then Take Screen Shot 6_8_LightingMachineImageandColor_TestStep18 in 30518 under GamingScreenShotResult

@LightingSwitchEightLights
Scenario: VAN30518_TestStep19_Check 7/8 Lighting should be shown in the page
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "6 / 8."
	Given click right arrow 1 times
	Then The light name should be "7 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep20_Check the 7/8 lighting settings effect dropdown menu,brightness bar,speed bar and color square
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "6 / 8."
	Given click right arrow 1 times
	Then Click "7 / 8." and Select "lightingType:Bounce"
	Then The "Effect" is show in Lighting
	Then The "Brightness" is show in Lighting
	Then The "Speed" is show in Lighting
	Then The "Color" is show in Lighting

@LightingSwitchEightLights
Scenario: VAN30518_TestStep21_Check 7/8 lighting area in the machine image should be lighted and the color is same with settings
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "7 / 8."
	Then Take Screen Shot 7_8_LightingMachineImageandColor_TestStep21 in 30518 under GamingScreenShotResult

@LightingSwitchEightLights
Scenario: VAN30518_TestStep22_Check 8/8 Lighting should be shown in the page
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "7 / 8."
	Given click right arrow 1 times
	Then The light name should be "8 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep23_Check the 8/8 lighting settings effect dropdown menu,brightness bar,speed bar and color square
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "7 / 8."
	Given click right arrow 1 times
	Then Click "8 / 8." and Select "lightingType:Flicker"
	Then The "Effect" is show in Lighting
	Then The "Brightness" is show in Lighting
	Then The "Color" is show in Lighting

@LightingSwitchEightLights
Scenario: VAN30518_TestStep24_Check 8/8 lighting area in the machine image should be lighted and the color is same with settings
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "8 / 8."
	Then Take Screen Shot 8_8_LightingMachineImageandColor_TestStep24 in 30518 under GamingScreenShotResult