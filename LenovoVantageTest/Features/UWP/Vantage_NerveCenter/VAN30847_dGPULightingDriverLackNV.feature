@GetLightingFile
Feature: VAN30847_dGPULightingDriverLackNV
	Test Case: https://lnvusjira.lenovonet.lenovo.local/browse/VAN-30847
	Author: Yang Liu
	Automated Test Step 01-06

Background:
	Then The Graphics Card vendor value is 1 And the Method is GetGPUVendor
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature

@GPULightingDriverLackNV
Scenario: VAN30847_TestStep01_Check the dGPU lighting area
	Given 'GPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given click the the customize
	Given select the profile 1
	Then Click The "8 / 8."
	Then The light name should be "Legion GPU Iconic Lighting"
	Then The "set to default" is show in Lighting
	Then Take Screen Shot 8_8_Lighting_TestStep01 in 30847 under GamingScreenShotResult
	Then The "Effect" is not show in Lighting
	Then The "Brightness" is not show in Lighting
	Then The "Speed" is not show in Lighting
	Then The "Color" is not show in Lighting
	Then The "Please install GPU driver before configuring GPU lighting." is show in Lighting
	Then The "INSTALL" is show in Lighting

@GPULightingDriverLackNV
Scenario: VAN30847_TestStep02_Check the dGPU lighting area
	Given 'GPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given click the the customize
	Given select the profile 1
	Then Click The "8 / 8."
	Then Click The Install Button
	Then check Update header title

@GPULightingDriverLackNV
Scenario: VAN30847_TestStep03_Check the dGPU lighting area
	Given 'GPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given click the the customize
	Given select the profile 1
	Then Click The "8 / 8."
	When Install 'GPU' Driver
	Then The light name should be "Legion GPU Iconic Lighting"
	Then The "set to default" is show in Lighting
	Then Take Screen Shot 8_8_Lighting_TestStep03 in 30847 under GamingScreenShotResult
	Then The "Effect" is not show in Lighting
	Then The "Brightness" is not show in Lighting
	Then The "Speed" is not show in Lighting
	Then The "Color" is not show in Lighting
	Then The "Please install GPU driver before configuring GPU lighting." is show in Lighting
	Then The "INSTALL" is show in Lighting

@GPULightingDriverLackNV
Scenario: VAN30847_TestStep04_Check the dGPU lighting area
	Given 'GPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given click the the customize
	Given select the profile 1
	Then Click The "8 / 8."
	When Install 'GPU' Driver
	Given Close Vantage
	Given Launch Vantage
	Given click the the customize
	Given select the profile 1
	Then Click "8 / 8." and Select "lightingType:Flicker"
	Then The light name should be "Legion GPU Iconic Lighting"
	Then The "set to default" is show in Lighting
	Then Take Screen Shot 8_8_Lighting_TestStep04 in 30847 under GamingScreenShotResult
	Then The "Effect" is show in Lighting
	Then The "Brightness" is show in Lighting
	Then The "Speed" is show in Lighting
	Then The "Color" is show in Lighting
	Then The "Please install GPU driver before configuring GPU lighting." is not show in Lighting
	Then The "INSTALL" is not show in Lighting

@GPULightingDriverLackNV
Scenario: VAN30847_TestStep05_Check the dGPU lighting area
	When Install 'GPU' Driver
	Given Close Vantage
	Given Launch Vantage
	Given click the the customize
	Given select the profile 1
	Then Click "8 / 8." and Select "lightingType:Flicker"
	Given 'GPU' Driver don't exist
	Then The light name should be "Legion GPU Iconic Lighting"
	Then The "set to default" is show in Lighting
	Then Take Screen Shot 8_8_Lighting_TestStep05 in 30847 under GamingScreenShotResult
	Then The "Effect" is show in Lighting
	Then The "Brightness" is show in Lighting
	Then The "Speed" is show in Lighting
	Then The "Color" is show in Lighting
	Then The "Please install GPU driver before configuring GPU lighting." is not show in Lighting
	Then The "INSTALL" is not show in Lighting

@GPULightingDriverLackNV
Scenario: VAN30847_TestStep06_Check the dGPU lighting area
	When Install 'GPU' Driver
	Given Close Vantage
	Given Launch Vantage
	Given click the the customize
	Given select the profile 1
	Then Click The "8 / 8."
	Given 'GPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given click the the customize
	Given select the profile 1
	Then Click The "8 / 8."
	Then The light name should be "Legion GPU Iconic Lighting"
	Then The "set to default" is show in Lighting
	Then Take Screen Shot 8_8_Lighting_TestStep06 in 30847 under GamingScreenShotResult
	Then The "Effect" is not show in Lighting
	Then The "Brightness" is not show in Lighting
	Then The "Speed" is not show in Lighting
	Then The "Color" is not show in Lighting
	Then The "Please install GPU driver before configuring GPU lighting." is show in Lighting
	Then The "INSTALL" is show in Lighting