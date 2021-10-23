Feature: VAN29851_GamingEffectSynchronousTipsEffecItem
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29851
	Author： Tianyou Hong
	Test steps:1-18 Hongty
	Test steps:19-22 Xuwei

@LightingeffectitemTipsRGB
Scenario: VAN29851_TestStep01_Hover Off The Tips Not Display
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
    Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Off"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_off_after_TestStep1 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is not show in Lighting

@LightingeffectitemTipsRGB
Scenario: VAN29851_TestStep02_Hover Static The Tips Not Display
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
    Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Static"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_Static_after_TestStep2 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is not show in Lighting

@LightingeffectitemTipsRGB
Scenario: VAN29851_TestStep03_Hover Flicker The Tips Not Display
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
    Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Flicker"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_Flicker_after_TestStep3 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is not show in Lighting

@LightingeffectitemTipsRGB
Scenario: VAN29851_TestStep04_Hover Breath The Tips Not Display
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
    Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Breath"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_Breath_after_TestStep4 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is not show in Lighting
	
@LightingeffectitemTipsRGB
Scenario: VAN29851_TestStep05_Hover Wave The Tips Display
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
    Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Wave"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_Wave_after_TestStep5 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is show in Lighting

@LightingeffectitemTipsRGB
Scenario: VAN29851_TestStep06_Hover Spectrum The Tips Not Display
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
    Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Spectrum"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_Spectrum_after_TestStep6 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is not show in Lighting
	
@LightingeffectitemTipsRGB
Scenario: VAN29851_TestStep07_Hover CPU Temperature The Tips Display
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
    Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "CPU Temperature"
	Given Hover The Effect Item
	Then Take screen shot lighting_effect_CPU Temperature_after_TestStep7 in 29851 under EffectSynchronous_EffecItem after 0 seconds 
	Then The "The updated effect will be applied to some other RGB areas." is show in Lighting
	
@LightingeffectitemTipsRGB
Scenario: VAN29851_TestStep08_Hover Rainbow The Tips Not Display
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
    Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Rainbow"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_Rainbow_after_TestStep8 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is not show in Lighting
	
@LightingeffectitemTipsRGB
Scenario: VAN29851_TestStep09_Hover Random The Tips Not Display
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
    Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Random"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_Random_after_TestStep9 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is not show in Lighting
	
@LightingeffectitemTipsSinglecolor
Scenario: VAN29851_TestStep10_Hover Always on The Tips Not Display
	Then The Lighting Feature value is 4 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Select "Always On"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_Always on_after_TestStep10 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is not show in Lighting
	
@LightingeffectitemTipsSinglecolor
Scenario: VAN29851_TestStep11_Hover Fast Blink The Tips Not Display
	Then The Lighting Feature value is 4 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Select "Fast Blink"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_Fast Blink_after_TestStep11 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is not show in Lighting
	
@LightingeffectitemTipsSinglecolor
Scenario: VAN29851_TestStep12_Hover Slow Blink The Tips Not Display
	Then The Lighting Feature value is 4 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Select "Slow Blink"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_Slow Blink_after_TestStep12 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is not show in Lighting
	
@LightingeffectitemTipsSinglecolor
Scenario: VAN29851_TestStep13_Hover Breath The Tips Not Display
	Then The Lighting Feature value is 4 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Select "Breath"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_Breath_after_TestStep13 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is not show in Lighting
	
@LightingeffectitemTipsNB
Scenario: VAN29851_TestStep14_Hover Static The Tips Not Display
	Then The Lighting Feature value is 4 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "" and Select "Static"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_Static_after_TestStep14 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is not show in Lighting
	
@LightingeffectitemTipsNB
Scenario: VAN29851_TestStep15_Hover Breath The Tips Not Display
	Then The Lighting Feature value is 4 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "" and Select "Breath"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_Breath_after_TestStep15 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is not show in Lighting
	
@LightingeffectitemTipsNB
Scenario: VAN29851_TestStep16_Hover Smooth The Tips Not Display
	Then The Lighting Feature value is 4 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "" and Select "Smooth"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_Smooth_after_TestStep16 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is not show in Lighting
	
@LightingeffectitemTipsNB
Scenario: VAN29851_TestStep17_Hover Wave_Left The Tips Not Display
	Then The Lighting Feature value is 4 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "" and Select "Wave_Left"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep17 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is not show in Lighting
	
@LightingeffectitemTipsNB
Scenario: VAN29851_TestStep18_Hover Wave_Right The Tips Not Display
	Then The Lighting Feature value is 4 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "" and Select "Wave_Right"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_Wave_Right_after_TestStep18 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is not show in Lighting

@LightingNeweffectitemTipsRGB
Scenario: VAN29851_TestStep19_Hover Meteor The Tips Not Display
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
    Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Meteor"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_Meteor_after_TestStep19 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is not show in Lighting

@LightingNeweffectitemTipsRGB
Scenario: VAN29851_TestStep20_Hover Meteor_Rainbow The Tips Not Display
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
    Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Meteor_Rainbow"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_Meteor_Rainbow_after_TestStep20 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is not show in Lighting

@LightingNeweffectitemTipsRGB
Scenario: VAN29851_TestStep21_Hover Meteor_Cycle The Tips Not Display
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
    Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Meteor_Cycle"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_Meteor_Cycleafter_TestStep21 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is show in Lighting

@LightingNeweffectitemTipsRGB
Scenario: VAN29851_TestStep22_Hover Meteor_Rainbow_Cycle The Tips Not Display
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
    Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Meteor_Rainbow_Cycle"
	Given Hover The Effect Item
	Then Take Screen Shot lighting_effect_Meteor_Cycleafter_TestStep22 in 29851 under EffectSynchronous_EffecItem
	Then The "The updated effect will be applied to some other RGB areas." is show in Lighting
