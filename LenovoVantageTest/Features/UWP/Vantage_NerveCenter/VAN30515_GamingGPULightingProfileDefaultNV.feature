@GetLightingFile
Feature: VAN30515_GamingGPULightingProfileDefaultNV
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-30515
	Author： Yang Liu
	Automated Test Step 01-16

Background: 
	Then The Graphics Card vendor value is 1 And the Method is GetGPUVendor
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Lighting" is "desktop-memory"
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	When Install 'GPU' Driver

@GamingGPULightingProfileDefaultNV
Scenario:VAN30515_TestStep01_Check The last light name should be Legion GPU Iconic Lighting
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "8/8 Legion GPU Iconic Lighting"
	Then The light name should be "Legion GPU Iconic Lighting"

@GamingGPULightingProfileDefaultNV
Scenario:VAN30515_TestStep02_Check the Legion GPU Iconic Lighting default effect should be Rainbow
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "8/8 Legion GPU Iconic Lighting" and "Rainbow"

@GamingGPULightingProfileDefaultNV
Scenario:VAN30515_TestStep03_Check the Legion GPU Iconic Lighting Brightness bar should not be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "8/8 Legion GPU Iconic Lighting"
	Then The "Brightness" is not show in Lighting

@GamingGPULightingProfileDefaultNV
Scenario:VAN30515_TestStep04_Check the Legion GPU Iconic Lighting Speed bar should not be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "8/8 Legion GPU Iconic Lighting"
	Then The "Speed" is not show in Lighting

@GamingGPULightingProfileDefaultNV
Scenario:VAN30515_TestStep05_Check the Legion GPU Iconic Lighting Color square should not be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "8/8 Legion GPU Iconic Lighting"
	Then The "Color" is not show in Lighting

@GamingGPULightingProfileDefaultNV
Scenario:VAN30515_TestStep06_Check the Legion GPU Iconic Lighting Color square should not be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "Rainbow"

@GamingGPULightingProfileDefaultNV
Scenario:VAN30515_TestStep07_Check the Legion GPU Iconic Lighting default effect should be Static
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click "8/8 Legion GPU Iconic Lighting" and "Static"

@GamingGPULightingProfileDefaultNV
Scenario:VAN30515_TestStep08_Check the Legion GPU Iconic Lighting Brightness bar default value
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "8/8 Legion GPU Iconic Lighting"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@GamingGPULightingProfileDefaultNV
Scenario:VAN30515_TestStep09_Check the Legion GPU Iconic Lighting Speed bar should not be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "8/8 Legion GPU Iconic Lighting"
	Then The "Speed" is not show in Lighting

@GamingGPULightingProfileDefaultNV
Scenario:VAN30515_TestStep10_Check the Legion GPU Iconic Lighting Color square default value
	Given Need Compare File is 'false'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "8/8 Legion GPU Iconic Lighting"
	Then The "Color" is show in Lighting
	Then Color should be RGB "0,211,254"

@GamingGPULightingProfileDefaultNV
Scenario:VAN30515_TestStep11_Check the Legion GPU Iconic Lighting effect and color in the device
	Given Need Compare File is 'True'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "8/8 Legion GPU Iconic Lighting"
	Then The "Color" is show in Lighting
	Then Color should be RGB "0,211,254"

@GamingGPULightingProfileDefaultNV
Scenario:VAN30515_TestStep12_Check the Legion GPU Iconic Lighting default effect should be Off
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click "8/8 Legion GPU Iconic Lighting" and "Off"

@GamingGPULightingProfileDefaultNV
Scenario:VAN30515_TestStep13_Check the Legion GPU Iconic Lighting Brightness bar should NOT be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "8/8 Legion GPU Iconic Lighting"
	Then The "Brightness" is not show in Lighting

@GamingGPULightingProfileDefaultNV
Scenario:VAN30515_TestStep14_Check the Legion GPU Iconic Lighting Speed bar should NOT be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "8/8 Legion GPU Iconic Lighting"
	Then The "Speed" is not show in Lighting

@GamingGPULightingProfileDefaultNV
Scenario:VAN30515_TestStep15_Check the Legion GPU Iconic Lighting Color square should NOT be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "8/8 Legion GPU Iconic Lighting"
	Then The "Color" is not show in Lighting

@GamingGPULightingProfileDefaultNV
Scenario:VAN30515_TestStep16_Check the Legion GPU Iconic Lighting effect and color in the device
	Given Need Compare File is 'True'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click "8/8 Legion GPU Iconic Lighting" and Select "Off"
