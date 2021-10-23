@GetLightingFile
Feature: VAN19747_LightingEffectForDT
	Test Case: https://lnvusjira.lenovonet.lenovo.local/browse/VAN-19747
	Author: Xuwei
	Automated Test Step 01-39

Background:
	Given Machine is Gaming
	Then The Lighting Feature value is 18,23 And the Method is IsSupportLightingFeature

@DTLightingOldSingleColorEffect
Scenario: VAN19747_TestStep01_Check the effect dropdown menu 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1/8 Legion Icon Lighting (Front)"
	Then effect dropdown menu should be expanded and effects should be shown:
		| Effect name |
		| Off         |
		| Always On   |
		| Fast Blink  |
		| Slow Blink  |
        | Breath      |

@DTLightingOldSingleColorEffect
Scenario: VAN19747_TestStep02_Check the lighting effect should be Always On
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType:Always On"
	Then Click "1/8 Legion Icon Lighting (Front)" and "Always On"

@DTLightingOldSingleColorEffect
Scenario: VAN19747_TestStep03_Check the lighting effect should be Off
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType:Off"
	Then Click "1/8 Legion Icon Lighting (Front)" and "Off"

@DTLightingOldSingleColorEffect
Scenario: VAN19747_TestStep04_Check the lighting effect should be Fast Blink
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType:Fast Blink"
	Then Click "1/8 Legion Icon Lighting (Front)" and "Fast Blink"

@DTLightingOldSingleColorEffect
Scenario: VAN19747_TestStep05_Check the lighting effect should be Slow Blink
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType:Slow Blink"
	Then Click "1/8 Legion Icon Lighting (Front)" and "Slow Blink"

@DTLightingOldSingleColorEffect
Scenario: VAN19747_TestStep06_Check the lighting effect should be Breath
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType:Breath"
	Then Click "1/8 Legion Icon Lighting (Front)" and "Breath"

@DTLightingOldRGBEffect
Scenario: VAN19747_TestStep07_Check the lighting effect should be Breath
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "3/8 Legion CPU Fan Lighting"
	Then effect dropdown menu should be expanded and effects should be shown:
		| Effect name     |
		| Off             |
		| Static          |
		| Flicker         |
		| Breath          |
        | Wave            |
		| Spectrum        |
		| CPU Temperature |
		| Rainbow         |
		| Random          |

@DTLightingRGBEffect
Scenario: VAN19747_TestStep08_Check the RGB lighting effect should be Off
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Off"
	Then Click "3/6 Legion CPU Fan Lighting" and "Off"

@DTLightingRGBEffect
Scenario: VAN19747_TestStep09_Check the lighting effect should be Off
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Off"

@DTLightingRGBEffect
Scenario: VAN19747_TestStep10_Check the RGB lighting effect should be Static
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Static"
	Then Click "3/6 Legion CPU Fan Lighting" and "Static"

@DTLightingRGBEffect
Scenario: VAN19747_TestStep11_Check the lighting effect should be Static
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Static"

@DTLightingRGBEffect
Scenario: VAN19747_TestStep12_Check the RGB lighting effect should be Flicker
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Flicker"
	Then Click "3/6 Legion CPU Fan Lighting" and "Flicker"

@DTLightingRGBEffect
Scenario: VAN19747_TestStep13_Check the lighting effect should be Flicker
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Flicker"

@DTLightingRGBEffect
Scenario: VAN19747_TestStep14_Check the RGB lighting effect should be Breath
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Breath"
	Then Click "3/6 Legion CPU Fan Lighting" and "Breath"

@DTLightingRGBEffect
Scenario: VAN19747_TestStep15_Check the lighting effect should be Breath
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Breath"

@DTLightingRGBEffect
Scenario: VAN19747_TestStep16_Check the RGB lighting effect should be Random
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Random"
	Then Click "3/6 Legion CPU Fan Lighting" and "Random"

@DTLightingRGBEffect
Scenario: VAN19747_TestStep17_Check the lighting effect should be Random
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Random"

@DTLightingRGBEffect
Scenario: VAN19747_TestStep18_Check the RGB lighting effect should be Wave
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Wave"
	Then Click "3/6 Legion CPU Fan Lighting" and "Wave"

@DTLightingRGBEffect
Scenario: VAN19747_TestStep19_Check the lighting effect should be Wave
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Wave"

@DTLightingRGBEffect
Scenario: VAN19747_TestStep20_Check the RGB lighting effect should be Rainbow
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Rainbow"
	Then Click "3/6 Legion CPU Fan Lighting" and "Rainbow"

@DTLightingRGBEffect
Scenario: VAN19747_TestStep21_Check the lighting effect should be Rainbow
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Rainbow"

@DTLightingRGBEffect
Scenario: VAN19747_TestStep22_Check the RGB lighting effect should be CPU Temperature
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:CPU Temperature"
	Then Click "3/6 Legion CPU Fan Lighting" and "CPU Temperature"

@DTLightingRGBEffect
Scenario: VAN19747_TestStep23_Check the lighting effect should be CPU Temperature
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:CPU Temperature"

@DTLightingRGBEffect
Scenario: VAN19747_TestStep24_Check the RGB lighting effect should be Spectrum
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Spectrum"
	Then Click "3/6 Legion CPU Fan Lighting" and "Spectrum"

@DTLightingRGBEffect
Scenario: VAN19747_TestStep25_Check the lighting effect should be Spectrum
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Spectrum"

@DTLightingNewSingleColorEffect
Scenario: VAN19747_TestStep26_Check the effect dropdown menu 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1/6 Legion Icon Lighting (Front)"
	Then effect dropdown menu should be expanded and effects should be shown:
		| Effect name |
		| Off         |
		| Static      |
		| Flicker     |
        | Breath      |

@DTLightingNewSingleColorEffect
Scenario: VAN19747_TestStep27_Check the lighting effect should be Off
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "1/6 Legion Icon Lighting (Front)" and Select "lightingType:Off"
	Then Click "1/6 Legion Icon Lighting (Front)" and "Off"

@DTLightingNewSingleColorEffect
Scenario: VAN19747_TestStep28_Check the lighting effect should be Static
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "1/6 Legion Icon Lighting (Front)" and Select "lightingType:Static"
	Then Click "1/6 Legion Icon Lighting (Front)" and "Static"

@DTLightingNewSingleColorEffect
Scenario: VAN19747_TestStep29_Check the lighting effect should be Flicker
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "1/6 Legion Icon Lighting (Front)" and Select "lightingType:Flicker"
	Then Click "1/6 Legion Icon Lighting (Front)" and "Flicker"

@DTLightingNewSingleColorEffect
Scenario: VAN19747_TestStep30_Check the lighting effect should be Breath
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "1/6 Legion Icon Lighting (Front)" and Select "lightingType:Breath"
	Then Click "1/6 Legion Icon Lighting (Front)" and "Breath"

@DTLightingRGBNewEffect
Scenario: VAN19747_TestStep31_Check the New RGB lighting effect 
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "3/6 Legion CPU Fan Lighting"
	Then effect dropdown menu should be expanded and effects should be shown:
		| Effect name     |
		| Off             |
		| Static          |
		| Flicker         |
		| Breath          |
        | Wave            |
		| Spectrum        |
		| CPU Temperature |
		| Rainbow         |
		| Random          |
		| Meteor          |
		| Meteor_Rainbow  |
		| Meteor_Cycle         |
		| Meteor_Rainbow_Cycle |

@DTLightingRGBNewEffect
Scenario: VAN19747_TestStep32_Check the RGB lighting effect should be Meteor
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Meteor"
	Then Click "3/6 Legion CPU Fan Lighting" and "Meteor"

@DTLightingRGBNewEffect
Scenario: VAN19747_TestStep33_Check the lighting effect should be Meteor
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Meteor"

@DTLightingRGBNewEffect
Scenario: VAN19747_TestStep34_Check the RGB lighting effect should be Meteor_Rainbow
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Meteor_Rainbow"
	Then Click "3/6 Legion CPU Fan Lighting" and "Meteor_Rainbow"

@DTLightingRGBNewEffect
Scenario: VAN19747_TestStep35_Check the lighting effect should be Meteor_Rainbow
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Meteor_Rainbow"

@DTLightingRGBNewEffect
Scenario: VAN19747_TestStep36_Check the RGB lighting effect should be Meteor_Cycle
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Meteor_Cycle"
	Then Click "3/6 Legion CPU Fan Lighting" and "Meteor_Cycle"

@DTLightingRGBNewEffect
Scenario: VAN19747_TestStep37_Check the lighting effect should be Meteor_Cycle
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Meteor_Cycle"

@DTLightingRGBNewEffect
Scenario: VAN19747_TestStep38_Check the RGB lighting effect should be Meteor_Rainbow_Cycle
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Meteor_Rainbow_Cycle"
	Then Click "3/6 Legion CPU Fan Lighting" and "Meteor_Rainbow_Cycle"

@DTLightingRGBNewEffect
Scenario: VAN19747_TestStep39_Check the lighting effect should be Meteor_Rainbow_Cycle
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType:Meteor_Rainbow_Cycle"