@GetLightingFile
Feature: VAN19746_LightingColorSquareForDT
	Test Case： https://jira.tc.lenovo.com/browse/VAN-19746
	Author: Xuwei
	Test Steps: 1-19

Background: 
	Given Machine is Gaming
	Then The Lighting Feature value is 18,23 And the Method is IsSupportLightingFeature
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect

@DTLightingOldSingleColorSquare
Scenario: VAN19746_TestStep01_Color Square should not be shown when effect is Off 
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType:Off"
	Then The "Color" is not show in Lighting

@DTLightingOldSingleColorSquare
Scenario: VAN19746_TestStep02_Color Square should be shown when effect is Always On 
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType:Always On "
	Then The "Color" is not show in Lighting

@DTLightingOldSingleColorSquare
Scenario: VAN19746_TestStep03_Color Square should be shown when effect is Fast Blink 
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType:Fast Blink"
	Then The "Color" is not show in Lighting

@DTLightingOldSingleColorSquare
Scenario: VAN19746_TestStep04_Color Square should not be shown when effect is Slow Blink 
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType:Slow Blink"
	Then The "Color" is not show in Lighting

@DTLightingOldSingleColorSquare
Scenario: VAN19746_TestStep05_Color Square should not be shown when effect is Breath 
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType:Breath"
	Then The "Color" is not show in Lighting

@DTLightingRGBColorSquare
Scenario: VAN19746_TestStep06_Color Square should not be shown when RGB effect is Off 
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Off"
	Then The "Color" is not show in Lighting

@DTLightingRGBColorSquare
Scenario: VAN19746_TestStep07_Color Square should be shown when RGB effect is Static 
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Static"
	Then The "Color" is show in Lighting
	Then Color should be RGB "0,211,254"

@DTLightingRGBColorSquare
Scenario: VAN19746_TestStep08_Color Square should be shown when RGB effect is Flicker 
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Flicker"
	Then The "Color" is show in Lighting
	Then Color should be RGB "0,211,254"

@DTLightingRGBColorSquare
Scenario: VAN19746_TestStep09_Color Square should be shown when RGB effect is Breath 
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Breath"
	Then The "Color" is show in Lighting
	Then Color should be RGB "0,211,254"

@DTLightingRGBColorSquare
Scenario: VAN19746_TestStep10_Color Square should be shown when RGB effect is Random 
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Random"
	Then The "Color" is not show in Lighting

@DTLightingRGBColorSquare
Scenario: VAN19746_TestStep11_Color Square should be shown when RGB effect is Wave 
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Wave"
	Then The "Color" is not show in Lighting

@DTLightingRGBColorSquare
Scenario: VAN19746_TestStep12_Color Square should be shown when RGB effect is Rainbow 
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Rainbow"
	Then The "Color" is not show in Lighting

@DTLightingRGBColorSquare
Scenario: VAN19746_TestStep13_Color Square should be shown when RGB effect is CPU temperature 
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:CPU Temperature"
	Then The "Color" is not show in Lighting

@DTLightingRGBColorSquare
Scenario: VAN19746_TestStep14_Color Square should be shown when RGB effect is Spectrum
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Spectrum"
	Then The "Color" is show in Lighting
	Then Color should be RGB "0,211,254"

@DTLightingNewSingleColorSquare
Scenario: VAN19746_TestStep15_Color Square should be shown when Single color effect is Flicker 
	Then Click "1/6 Legion Icon Lighting (Front)" and Select "lightingType:Flicker"
	Then The "Color" is not show in Lighting

@DTLightingNewRGBColorSquare
Scenario: VAN19746_TestStep16_Color Square should be shown when RGB effect is Meteor
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Meteor"
	Then The "Color" is show in Lighting
	Then Color should be RGB "0,211,254"

@DTLightingNewRGBColorSquare
Scenario: VAN19746_TestStep17_Color Square should be shown when RGB effect is Meteor_Rainbow
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Meteor_Rainbow"
	Then The "Color" is not show in Lighting

@DTLightingNewRGBColorSquare
Scenario: VAN19746_TestStep18_Color Square should be shown when RGB effect is Meteor_Cycle
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Meteor_Cycle"
	Then The "Color" is show in Lighting
	Then Color should be RGB "0,211,254"

@DTLightingNewRGBColorSquare
Scenario: VAN19746_TestStep19_Color Square should be shown when RGB effect is Meteor_Rainbow_Cycle
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Meteor_Rainbow_Cycle"
	Then The "Color" is not show in Lighting