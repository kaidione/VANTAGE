@GetLightingFile
Feature: VAN30514_Lighting_GPU_ProfileDefaultAMDLogo
	Test Case: https://lnvusjira.lenovonet.lenovo.local/browse/VAN-30514
	Author: Xuwei
	Automated： 1-16

Background:
	Then The Graphics Card vendor value is 2 And the Method is GetGPUVendor
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature

@LightingGPUProfileDefaultAMDLogo
Scenario: VAN30514_TestStep01_The light name should be Legion GPU Logo Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "8/9 Legion GPU Logo Lighting"
	Then The light name should be "Legion GPU Logo Lighting"

@LightingGPUProfileDefaultAMDLogo
Scenario: VAN30514_TestStep02_The light name should be Legion GPU Logo Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click "8/9 Legion GPU Logo Lighting" and "Static"

@LightingGPUProfileDefaultAMDLogo
Scenario: VAN30514_TestStep03_The light name should be Legion GPU Logo Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "8/9 Legion GPU Logo Lighting"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@LightingGPUProfileDefaultAMDLogo
Scenario: VAN30514_TestStep04_The light name should be Legion GPU Logo Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "8/9 Legion GPU Logo Lighting"
	Then The "Speed" is not show in Lighting

@LightingGPUProfileDefaultAMDLogo
Scenario: VAN30514_TestStep05_The light name should be Legion GPU Logo Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "8/9 Legion GPU Logo Lighting"
	Then The "Color" is show in Lighting

@LightingGPUProfileDefaultAMDLogo
Scenario: VAN30514_TestStep06_The light name should be Legion GPU Logo Lighting 
	Given Need Compare File is 'True'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click "8/9 Legion GPU Logo Lighting" and Select "lightingType:Static"

@LightingGPUProfileDefaultAMDLogo
Scenario: VAN30514_TestStep07_The light name should be Legion GPU Logo Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click "8/9 Legion GPU Logo Lighting" and "Static"

@LightingGPUProfileDefaultAMDLogo
Scenario: VAN30514_TestStep08_The light name should be Legion GPU Logo Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "8/9 Legion GPU Logo Lighting"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@LightingGPUProfileDefaultAMDLogo
Scenario: VAN30514_TestStep09_The light name should be Legion GPU Logo Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "8/9 Legion GPU Logo Lighting"
	Then The "Speed" is not show in Lighting

@LightingGPUProfileDefaultAMDLogo
Scenario: VAN30514_TestStep10_The light name should be Legion GPU Logo Lighting 
	Given Need Compare File is 'false'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "8/9 Legion GPU Logo Lighting"
	Then The "Color" is show in Lighting
	Then Color should be RGB "255,0,0"

@LightingGPUProfileDefaultAMDLogo
Scenario: VAN30514_TestStep11_The light name should be Legion GPU Logo Lighting 
	Given Need Compare File is 'True'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click "8/9 Legion GPU Logo Lighting" and Select "lightingType:Static"

@LightingGPUProfileDefaultAMDLogo
Scenario: VAN30514_TestStep12_The light name should be Legion GPU Logo Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click "8/9 Legion GPU Logo Lighting" and "Off"

@LightingGPUProfileDefaultAMDLogo
Scenario: VAN30514_TestStep13_The light name should be Legion GPU Logo Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "8/9 Legion GPU Logo Lighting"
	Then The "Brightness" is not show in Lighting

@LightingGPUProfileDefaultAMDLogo
Scenario: VAN30514_TestStep14_The light name should be Legion GPU Logo Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "8/9 Legion GPU Logo Lighting"
	Then The "Speed" is not show in Lighting

@LightingGPUProfileDefaultAMDLogo
Scenario: VAN30514_TestStep15_The light name should be Legion GPU Logo Lighting 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "8/9 Legion GPU Logo Lighting"
	Then The "Color" is not show in Lighting

@LightingGPUProfileDefaultAMDLogo
Scenario: VAN30514_TestStep16_The light name should be Legion GPU Logo Lighting 
	Given Need Compare File is 'True'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click "8/9 Legion GPU Logo Lighting" and Select "lightingType:Off"