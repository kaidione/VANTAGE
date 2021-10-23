@GetLightingFile
Feature: VAN19751_LightingSpeedForDT
	Test Case： https://jira.tc.lenovo.com/browse/VAN-19751
	Author: Xuwei
	Test Steps: 1-19

Background: 
	Given Machine is Gaming
	Then The Lighting Feature value is 18,23 And the Method is IsSupportLightingFeature
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect

@DTLightingOldSingleSpeed
Scenario: VAN19751_TestStep01_Speed should not be shown when effect is Off 
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType:Off"
	Then The "Speed" is not show in Lighting

@DTLightingOldSingleSpeed
Scenario: VAN19751_TestStep02_Speed should be shown when effect is Always On 
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType:Always On "
	Then The "Speed" is not show in Lighting

@DTLightingOldSingleSpeed
Scenario: VAN19751_TestStep03_Speed should be shown when effect is Fast Blink 
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType:Fast Blink"
	Then The "Speed" is not show in Lighting

@DTLightingOldSingleSpeed
Scenario: VAN19751_TestStep04_Speed should not be shown when effect is Slow Blink 
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType:Slow Blink"
	Then The "Speed" is not show in Lighting

@DTLightingOldSingleSpeed
Scenario: VAN19751_TestStep05_Speed should not be shown when effect is Breath 
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType:Breath"
	Then The "Speed" is not show in Lighting

@DTLightingRGBSpeed
Scenario: VAN19751_TestStep06_Speed should not be shown when RGB effect is Off 
	Then Click "5/6 Legion Front Fan Lighting" and Select "lightingType:Off"
	Then The "Speed" is not show in Lighting

@DTLightingRGBSpeed
Scenario: VAN19751_TestStep07_Speed should be shown when RGB effect is Static 
	Then Click "5/6 Legion Front Fan Lighting" and Select "lightingType:Static"
	Then The "Speed" is not show in Lighting

@DTLightingRGBSpeed
Scenario: VAN19751_TestStep08_Speed should be shown when RGB effect is Flicker 
	Then Click "5/6 Legion Front Fan Lighting" and Select "lightingType:Flicker"
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'

@DTLightingRGBSpeed
Scenario: VAN19751_TestStep09_Speed should be shown when RGB effect is Breath 
	Then Click "5/6 Legion Front Fan Lighting" and Select "lightingType:Breath"
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'

@DTLightingRGBSpeed
Scenario: VAN19751_TestStep10_Speed should be shown when RGB effect is Random 
	Then Click "5/6 Legion Front Fan Lighting" and Select "lightingType:Random"
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'

@DTLightingRGBSpeed
Scenario: VAN19751_TestStep11_Speed should be shown when RGB effect is Wave 
	Then Click "5/6 Legion Front Fan Lighting" and Select "lightingType:Wave"
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'

@DTLightingRGBSpeed
Scenario: VAN19751_TestStep12_Speed should be shown when RGB effect is Rainbow 
	Then Click "5/6 Legion Front Fan Lighting" and Select "lightingType:Rainbow"
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'

@DTLightingRGBSpeed
Scenario: VAN19751_TestStep13_Speed should be shown when RGB effect is CPU temperature 
	Then Click "5/6 Legion Front Fan Lighting" and Select "lightingType:CPU Temperature"
	Then The "Speed" is not show in Lighting

@DTLightingRGBSpeed
Scenario: VAN19751_TestStep14_Speed should be shown when RGB effect is Spectrum
	Then Click "5/6 Legion Front Fan Lighting" and Select "lightingType:Spectrum"
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'

@DTLightingNewSingleSpeed
Scenario: VAN19751_TestStep15_Speed should be shown when Single color effect is Flicker 
	Then Click "1/6 Legion Icon Lighting (Front)" and Select "lightingType:Flicker"
	Then The "Speed" is not show in Lighting

@DTLightingNewRGBSpeed
Scenario: VAN19751_TestStep16_Speed should be shown when RGB effect is Meteor
	Then Click "5/6 Legion Front Fan Lighting" and Select "lightingType:Meteor"
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'

@DTLightingNewRGBSpeed
Scenario: VAN19751_TestStep17_Speed should be shown when RGB effect is Meteor_Rainbow
	Then Click "5/6 Legion Front Fan Lighting" and Select "lightingType:Meteor_Rainbow"
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'

@DTLightingNewRGBSpeed
Scenario: VAN19751_TestStep18_Speed should be shown when RGB effect is Meteor_Cycle
	Then Click "5/6 Legion Front Fan Lighting" and Select "lightingType:Meteor_Cycle"
	Then The "Color" is show in Lighting
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'

@DTLightingNewRGBSpeed
Scenario: VAN19751_TestStep19_Speed should be shown when RGB effect is Meteor_Rainbow_Cycle
	Then Click "5/6 Legion Front Fan Lighting" and Select "lightingType:Meteor_Rainbow_Cycle"
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'