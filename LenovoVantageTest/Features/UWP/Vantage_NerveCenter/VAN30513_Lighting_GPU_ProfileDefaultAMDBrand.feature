@GetLightingFile
Feature: VAN30513_Lighting_GPU_ProfileDefaultAMDBrand
	Test Case: https://lnvusjira.lenovonet.lenovo.local/browse/VAN-30513
	Author: Jinxin Li
	Automated Test Step 01-16

Background:
	Then The Graphics Card vendor value is 2 And the Method is GetGPUVendor
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature

@LightingGPUProfileDefaultAMDBrand
Scenario: VAN30513_TestStep01_The light name should be Legion GPU Brand Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "9/9 Legion GPU Brand Lighting"
	Then The light name should be "Legion GPU Brand Lighting"

@LightingGPUProfileDefaultAMDBrand
Scenario: VAN30513_TestStep02_The light name should be Legion GPU Brand Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "9/9 Legion GPU Brand Lighting" and "Rainbow"

@LightingGPUProfileDefaultAMDBrand
Scenario: VAN30513_TestStep03_The light name should be Legion GPU Brand Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "9/9 Legion GPU Brand Lighting"
	Then The "Brightness" is not show in Lighting

@LightingGPUProfileDefaultAMDBrand
Scenario: VAN30513_TestStep04_The light name should be Legion GPU Brand Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "9/9 Legion GPU Brand Lighting"
	Then The "Speed" is not show in Lighting

@LightingGPUProfileDefaultAMDBrand
Scenario: VAN30513_TestStep05_The light name should be Legion GPU Brand Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "9/9 Legion GPU Brand Lighting"
	Then The "Color" is not show in Lighting

@LightingGPUProfileDefaultAMDBrand
Scenario: VAN30513_TestStep06_The light name should be Legion GPU Brand Lighting 
	Given Need Compare File is 'True'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "9/9 Legion GPU Brand Lighting" and Select "lightingType:Rainbow"

@LightingGPUProfileDefaultAMDBrand
Scenario: VAN30513_TestStep07_The light name should be Legion GPU Brand Lighting 
	Given click the the customize
	Given Lighting page is opened
	When Set to default effect
	Given select the profile 2
	When Set to default effect
	Then Click "9/9 Legion GPU Brand Lighting" and "Static"

@LightingGPUProfileDefaultAMDBrand
Scenario: VAN30513_TestStep08_The light name should be Legion GPU Brand Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "8/9 Legion GPU Logo Lighting"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@LightingGPUProfileDefaultAMDBrand
Scenario: VAN30513_TestStep09_The light name should be Legion GPU Brand Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "9/9 Legion GPU Brand Lighting"
	Then The "Speed" is not show in Lighting

@LightingGPUProfileDefaultAMDBrand
Scenario: VAN30513_TestStep10_The light name should be Legion GPU Brand Lighting
	Given Need Compare File is 'false'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "9/9 Legion GPU Brand Lighting"
	Then The "Color" is show in Lighting
	Then Color should be RGB "0,211,254"

@LightingGPUProfileDefaultAMDBrand
Scenario: VAN30513_TestStep11_The light name should be Legion GPU Brand Lighting
	Given Need Compare File is 'True'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "9/9 Legion GPU Brand Lighting"
	Then The "Color" is show in Lighting
	Then Color should be RGB "0,211,254"

@LightingGPUProfileDefaultAMDBrand
Scenario: VAN30513_TestStep12_The light name should be Legion GPU Brand Lighting
	Given Need Compare File is 'True'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click "9/9 Legion GPU Brand Lighting" and "Off"

@LightingGPUProfileDefaultAMDBrand
Scenario: VAN30513_TestStep13_The light name should be Legion GPU Brand Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "9/9 Legion GPU Brand Lighting"
	Then The "Brightness" is not show in Lighting

@LightingGPUProfileDefaultAMDBrand
Scenario: VAN30513_TestStep14_The light name should be Legion GPU Brand Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "9/9 Legion GPU Brand Lighting"
	Then The "Speed" is not show in Lighting

@LightingGPUProfileDefaultAMDBrand
Scenario: VAN30513_TestStep15_The light name should be Legion GPU Brand Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "9/9 Legion GPU Brand Lighting"
	Then The "Color" is not show in Lighting

@LightingGPUProfileDefaultAMDBrand
Scenario: VAN30513_TestStep16_The light name should be Legion GPU Brand Lighting 
	Given Need Compare File is 'True'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click "9/9 Legion GPU Brand Lighting" and Select "lightingType:Off"