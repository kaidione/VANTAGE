@GetLightingFile
Feature: VAN19744_LightingBrightnessForDT
	Test Case： https://jira.tc.lenovo.com/browse/VAN-19744
	Author: Xuwei
	Test Steps: 1-19

Background: 
	Given Machine is Gaming
	Then The Lighting Feature value is 18,23 And the Method is IsSupportLightingFeature
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect

@DTLightingOldSingleBrightness
Scenario: VAN19744_TestStep01_Brightness should not be shown when effect is Off 
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType:Off"
	Then The "Brightness" is not show in Lighting

@DTLightingOldSingleBrightness
Scenario: VAN19744_TestStep02_Brightness should be shown when effect is Always On 
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType:Always On "
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@DTLightingOldSingleBrightness
Scenario: VAN19744_TestStep03_Brightness should be shown when effect is Fast Blink 
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType:Fast Blink"
	Then The "Brightness" is not show in Lighting

@DTLightingOldSingleBrightness
Scenario: VAN19744_TestStep04_Brightness should not be shown when effect is Slow Blink 
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType:Slow Blink"
	Then The "Brightness" is not show in Lighting

@DTLightingOldSingleBrightness
Scenario: VAN19744_TestStep05_Brightness should not be shown when effect is Breath 
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType:Breath"
	Then The "Brightness" is not show in Lighting

@DTLightingRGBBrightness
Scenario: VAN19744_TestStep06_Brightness should not be shown when RGB effect is Off 
	Then Click "4/6 Legion Rear Fan Lighting" and Select "lightingType:Off"
	Then The "Brightness" is not show in Lighting

@DTLightingRGBBrightness
Scenario: VAN19744_TestStep07_Brightness should be shown when RGB effect is Static 
	Then Click "4/6 Legion Rear Fan Lighting" and Select "lightingType:Static"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@DTLightingRGBBrightness
Scenario: VAN19744_TestStep08_Brightness should be shown when RGB effect is Flicker 
	Then Click "4/6 Legion Rear Fan Lighting" and Select "lightingType:Flicker"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@DTLightingRGBBrightness
Scenario: VAN19744_TestStep09_Brightness should be shown when RGB effect is Breath 
	Then Click "4/6 Legion Rear Fan Lighting" and Select "lightingType:Breath"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@DTLightingRGBBrightness
Scenario: VAN19744_TestStep10_Brightness should be shown when RGB effect is Random 
	Then Click "4/6 Legion Rear Fan Lighting" and Select "lightingType:Random"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@DTLightingRGBBrightness
Scenario: VAN19744_TestStep11_Brightness should be shown when RGB effect is Wave 
	Then Click "4/6 Legion Rear Fan Lighting" and Select "lightingType:Wave"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@DTLightingRGBBrightness
Scenario: VAN19744_TestStep12_Brightness should be shown when RGB effect is Rainbow 
	Then Click "4/6 Legion Rear Fan Lighting" and Select "lightingType:Rainbow"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@DTLightingRGBBrightness
Scenario: VAN19744_TestStep13_Brightness should be shown when RGB effect is CPU temperature 
	Then Click "4/6 Legion Rear Fan Lighting" and Select "lightingType:CPU Temperature"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@DTLightingRGBBrightness
Scenario: VAN19744_TestStep14_Brightness should be shown when RGB effect is Spectrum
	Then Click "4/6 Legion Rear Fan Lighting" and Select "lightingType:Spectrum"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@DTLightingNewSingleBrightness
Scenario: VAN19744_TestStep15_Brightness should be shown when Single color effect is Flicker 
	Then Click "1/6 Legion Icon Lighting (Front)" and Select "lightingType:Flicker"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@DTLightingNewRGBBrightness
Scenario: VAN19744_TestStep16_Brightness should be shown when RGB effect is Meteor
	Then Click "4/6 Legion Rear Fan Lighting" and Select "lightingType:Meteor"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@DTLightingNewRGBBrightness
Scenario: VAN19744_TestStep17_Brightness should be shown when RGB effect is Meteor_Rainbow
	Then Click "4/6 Legion Rear Fan Lighting" and Select "lightingType:Meteor_Rainbow"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@DTLightingNewRGBBrightness
Scenario: VAN19744_TestStep18_Brightness should be shown when RGB effect is Meteor_Cycle
	Then Click "4/6 Legion Rear Fan Lighting" and Select "lightingType:Meteor_Cycle"
	Then The "Color" is show in Lighting
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@DTLightingNewRGBBrightness
Scenario: VAN19744_TestStep19_Brightness should be shown when RGB effect is Meteor_Rainbow_Cycle
	Then Click "4/6 Legion Rear Fan Lighting" and Select "lightingType:Meteor_Rainbow_Cycle"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'