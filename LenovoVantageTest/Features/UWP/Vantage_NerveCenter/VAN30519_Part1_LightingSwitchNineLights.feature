@GetLightingFile
Feature: VAN30519_Part1_LightingSwitchNineLights
	Test Case: https://lnvusjira.lenovonet.lenovo.local/browse/VAN-30519
	Author: Yang Liu
	Automated Test Step 01-27

Background:
	Then The Graphics Card vendor value is 2 And the Method is GetGPUVendor
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature

@LightingSwitchNineLights
Scenario: VAN30519_TestStep01_Check 1/9 lighting should be shown in the page
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then The light name should be "1 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep02_Check the 1/9 lighting settings the effect should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then The "Effect" is show in Lighting

@LightingSwitchNineLights
Scenario: VAN30519_TestStep03_Check 1/9 lighting area in the machine image should be lighted and the color is same with settings
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "1 / 9."
	Then Take Screen Shot 1_9_Lighting_TestStep03 in 30519 under GamingScreenShotResult

@LightingSwitchNineLights
Scenario: VAN30519_TestStep04_Check 2/9 Lighting should be shown in the page
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "1 / 9."
	Given click right arrow 1 times
	Then The light name should be "2 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep05_Check the 2/9 lighting settings the effect should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "2 / 9."
	Given click right arrow 1 times
	Then The "Effect" is show in Lighting

@LightingSwitchNineLights
Scenario: VAN30519_TestStep06_Check 2/9 lighting area in the machine image should be lighted and the color is same with settings
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "2 / 9."
	Then Take Screen Shot 2_9_Lighting_TestStep06 in 30519 under GamingScreenShotResult

@LightingSwitchNineLights
Scenario: VAN30519_TestStep07_Check 3/9 Lighting should be shown in the page
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "2 / 9."
	Given click right arrow 1 times
	Then The light name should be "3 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep08_Check the 3/9 lighting settings effect dropdown menu,brightness bar,speed bar and color square
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "2 / 9."
	Given click right arrow 1 times
	Then Click "3 / 9." and Select "lightingType:Breath"
	Then The "Effect" is show in Lighting
	Then The "Brightness" is show in Lighting
	Then The "Speed" is show in Lighting
	Then The "Color" is show in Lighting

@LightingSwitchNineLights
Scenario: VAN30519_TestStep09_Check 3/9 lighting area in the machine image should be lighted and the color is same with settings
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "3 / 9."
	Then Take Screen Shot 3_9_Lighting_TestStep09 in 30519 under GamingScreenShotResult

@LightingSwitchNineLights
Scenario: VAN30519_TestStep10_Check 4/9 Lighting should be shown in the page
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "3 / 9."
	Given click right arrow 1 times
	Then The light name should be "4 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep11_Check the 4/9 lighting settings effect dropdown menu,brightness bar,speed bar and color square
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "3 / 9."
	Given click right arrow 1 times
	Then Click "4 / 9." and Select "lightingType:Breath"
	Then The "Effect" is show in Lighting
	Then The "Brightness" is show in Lighting
	Then The "Speed" is show in Lighting
	Then The "Color" is show in Lighting

@LightingSwitchNineLights
Scenario: VAN30519_TestStep12_Check 4/9 lighting area in the machine image should be lighted and the color is same with settings
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "4 / 9."
	Then Take Screen Shot 4_9_Lighting_TestStep12 in 30519 under GamingScreenShotResult

@LightingSwitchNineLights
Scenario: VAN30519_TestStep13_Check 5/9 Lighting should be shown in the page
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "4 / 9."
	Given click right arrow 1 times
	Then The light name should be "5 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep14_Check the 5/9 lighting settings effect dropdown menu,brightness bar,speed bar and color square
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "4 / 9."
	Given click right arrow 1 times
	Then Click "5 / 9." and Select "lightingType:Breath"
	Then The "Effect" is show in Lighting
	Then The "Brightness" is show in Lighting
	Then The "Speed" is show in Lighting
	Then The "Color" is show in Lighting

@LightingSwitchNineLights
Scenario: VAN30519_TestStep15_Check 5/9 lighting area in the machine image should be lighted and the color is same with settings
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "4 / 9."
	Given click right arrow 1 times
	Then Take Screen Shot 5_9_Lighting_TestStep15 in 30519 under GamingScreenShotResult

@LightingSwitchNineLights
Scenario: VAN30519_TestStep16_Check 6/9 Lighting should be shown in the page
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "5 / 9."
	Given click right arrow 1 times
	Then The light name should be "6 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep17_Check the 6/9 lighting settings effect dropdown menu,brightness bar,speed bar and color square
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "5 / 9."
	Given click right arrow 1 times
	Then Click "6 / 9." and Select "lightingType:Breath"
	Then The "Effect" is show in Lighting
	Then The "Brightness" is show in Lighting
	Then The "Speed" is show in Lighting
	Then The "Color" is show in Lighting

@LightingSwitchNineLights
Scenario: VAN30519_TestStep18_Check 6/9 lighting area in the machine image should be lighted and the color is same with settings
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "6 / 9."
	Then Take Screen Shot 6_9_Lighting_TestStep18 in 30519 under GamingScreenShotResult

@LightingSwitchNineLights
Scenario: VAN30519_TestStep19_Check 7/9 Lighting should be shown in the page
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "6 / 9."
	Given click right arrow 1 times
	Then The light name should be "7 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep20_Check the 7/9 lighting settings effect dropdown menu,brightness bar,speed bar and color square
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "6 / 9."
	Given click right arrow 1 times
	Then Click "7 / 9." and Select "lightingType:Flicker"
	Then The "Effect" is show in Lighting
	Then The "Brightness" is show in Lighting
	Then The "Speed" is show in Lighting
	Then The "Color" is show in Lighting

@LightingSwitchNineLights
Scenario: VAN30519_TestStep21_Check 7/9 lighting area in the machine image should be lighted and the color is same with settings
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "7 / 9."
	Then Take Screen Shot 7_9_Lighting_TestStep21 in 30519 under GamingScreenShotResult

@LightingSwitchNineLights
Scenario: VAN30519_TestStep22_Check 8/9 Lighting should be shown in the page
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "7 / 9."
	Given click right arrow 1 times
	Then The light name should be "8 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep23_Check the 8/9 lighting settings effect dropdown menu,brightness bar,speed bar and color square
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "7 / 9."
	Given click right arrow 1 times
	Then Click "8 / 9." and Select "lightingType:Static"
	Then The "Effect" is show in Lighting
	Then The "Brightness" is show in Lighting
	Then The "Color" is show in Lighting

@LightingSwitchNineLights
Scenario: VAN30519_TestStep24_Check 8/9 lighting area in the machine image should be lighted and the color is same with settings
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "8 / 9."
	Then Take Screen Shot 8_9_Lighting_TestStep24 in 30519 under GamingScreenShotResult

@LightingSwitchNineLights
Scenario: VAN30519_TestStep25_Check 9/9 Lighting should be shown in the page
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "8 / 9."
	Given click right arrow 1 times
	Then The light name should be "9 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep26_Check the 9/9 lighting settings effect dropdown menu,brightness bar,speed bar and color square
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "8 / 9."
	Given click right arrow 1 times
	Then Click "9 / 9." and Select "lightingType:Flicker"
	Then The "Effect" is show in Lighting
	Then The "Brightness" is show in Lighting
	Then The "Speed" is show in Lighting
	Then The "Color" is show in Lighting

@LightingSwitchNineLights
Scenario: VAN30519_TestStep27_Check 9/9 lighting area in the machine image should be lighted and the color is same with settings
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "9 / 9."
	Then Take Screen Shot 9_9_Lighting_TestStep27 in 30519 under GamingScreenShotResult