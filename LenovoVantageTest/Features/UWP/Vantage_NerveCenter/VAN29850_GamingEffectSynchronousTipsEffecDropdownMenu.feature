@GamingLightingTips
Feature: VAN29850_GamingEffectSynchronousTipsEffecDropdownMenu
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29850
	Author： Wenyang/Xuwei
	Test steps: 1-20 Wenyang
	Test steps: 21-38 Xuwei

@LightingeffectDMTipsRGB
Scenario:VAN29850_TestStep01 hover 'off' the tips NOT displayed
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Off"
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep01 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsRGB
Scenario:VAN29850_TestStep02 hover 'Static' the tips NOT displayed
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Static"
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep02 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsRGB
Scenario:VAN29850_TestStep03 hover 'Flicker' the tips NOT displayed
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Flicker"
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep03 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsRGB
Scenario:VAN29850_TestStep04 hover 'Breath' the tips NOT displayed
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Breath"
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep04 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsRGB
Scenario:VAN29850_TestStep05 hover 'Wave' the tips should displayed
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Wave"
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep05 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsRGB
Scenario:VAN29850_TestStep06 hover 'Spectrum' the tips NOT displayed
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Spectrum"
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep06 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsRGB
Scenario:VAN29850_TestStep07 hover 'CPU' the tips should displayed
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "CPU Temperature"
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep07 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsRGB
Scenario:VAN29850_TestStep08 hover 'Rainbow' the tips NOT displayed
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Rainbow"
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep08 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsRGB
Scenario:VAN29850_TestStep09 hover 'Random' the tips NOT displayed
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Random"
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep09 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsRGB
Scenario:VAN29850_TestStep10 select 'Wave' and hover 'Wave' the tips NOT displayed
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Wave"
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Wave"
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep10 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsRGB
Scenario:VAN29850_TestStep11 select 'CPU' and hover 'CPU' the tips NOT displayed
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "CPU Temperature"
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "CPU Temperature"
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep11 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsSinglecolor
Scenario:VAN29850_TestStep12 hover 'Always on' the tips NOT displayed
	Then The Lighting Feature value is 4 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Hover "Always On"
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep12 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsSinglecolor
Scenario:VAN29850_TestStep13 hover 'Fast Blink' the tips NOT displayed
	Then The Lighting Feature value is 4 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Hover "Fast Blink"
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep13 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsSinglecolor
Scenario:VAN29850_TestStep14 hover 'Slow blink' the tips NOT displayed
	Then The Lighting Feature value is 4 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Hover "Slow Blink"
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep14 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsSinglecolor
Scenario:VAN29850_TestStep15 hover 'Breath' the tips NOT displayed
	Then The Lighting Feature value is 4 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Hover "Breath"
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep15 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsNB
Scenario:VAN29850_TestStep16 hover 'Static' the tips NOT displayed
	Then The Lighting Feature value is 4 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "" and Hover "Static"
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep16 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsNB
Scenario:VAN29850_TestStep17 hover 'Breath' the tips NOT displayed
	Then The Lighting Feature value is 4 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "" and Hover "Breath"
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep17 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsNB
Scenario:VAN29850_TestStep18 hover 'Smooth' the tips NOT displayed
	Then The Lighting Feature value is 4 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "" and Hover "Smooth"
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep18 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsNB
Scenario:VAN29850_TestStep19 hover 'Wave_Left' the tips NOT displayed
	Then The Lighting Feature value is 4 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "" and Hover "Wave_Left"
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep19 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsNB
Scenario:VAN29850_TestStep20 hover 'Wave_Right' the tips NOT displayed
	Then The Lighting Feature value is 4 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "" and Hover "Wave_Right"
	Then Take Screen Shot lighting_effect_Wave_Left_after_TestStep20 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsRGB
Scenario:VAN29850_TestStep21 hover 'CPU Temperature' the tips NOT displayed
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Wave"
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "CPU Temperature"
	Then Take Screen Shot lighting_effect_Tips_TestStep21 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingNeweffectDMTipsRGB
Scenario:VAN29850_TestStep22 hover 'Meteor_Cycle' the tips NOT displayed
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Wave"
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Meteor_Cycle"
	Then Take Screen Shot lighting_effect_Tips_TestStep22 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingNeweffectDMTipsRGB
Scenario:VAN29850_TestStep23 hover 'Meteor_Rainbow_Cycle' the tips NOT displayed
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Wave"
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Meteor_Rainbow_Cycle"
	Then Take Screen Shot lighting_effect_Tips_TestStep23 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingeffectDMTipsRGB
Scenario:VAN29850_TestStep24 hover 'Wave' the tips NOT displayed
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "CPU Temperature"
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Wave"
	Then Take Screen Shot lighting_effect_Tips_TestStep24 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingNeweffectDMTipsRGB
Scenario:VAN29850_TestStep25 hover 'Meteor_Cycle' the tips NOT displayed
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "CPU Temperature"
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Meteor_Cycle"
	Then Take Screen Shot lighting_effect_Tips_TestStep25 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingNeweffectDMTipsRGB
Scenario:VAN29850_TestStep26 hover 'Meteor_Rainbow_Cycle' the tips NOT displayed
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "CPU Temperature"
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Meteor_Rainbow_Cycle"
	Then Take Screen Shot lighting_effect_Tips_TestStep26 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingNeweffectDMTipsRGB
Scenario:VAN29850_TestStep27 hover 'Wave' the tips NOT displayed
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Meteor_Cycle"
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Wave"
	Then Take Screen Shot lighting_effect_Tips_TestStep27 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingNeweffectDMTipsRGB
Scenario:VAN29850_TestStep28 hover 'CPU Temperature' the tips NOT displayed
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Meteor_Cycle"
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "CPU Temperature"
	Then Take Screen Shot lighting_effect_Tips_TestStep28 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingNeweffectDMTipsRGB
Scenario:VAN29850_TestStep29 hover 'Meteor_Cycle' the tips NOT displayed
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Meteor_Cycle"
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Meteor_Cycle"
	Then Take Screen Shot lighting_effect_Tips_TestStep29 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingNeweffectDMTipsRGB
Scenario:VAN29850_TestStep30 hover 'Meteor_Rainbow_Cycle' the tips NOT displayed
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Meteor_Cycle"
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Meteor_Rainbow_Cycle"
	Then Take Screen Shot lighting_effect_Tips_TestStep30 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingNeweffectDMTipsRGB
Scenario:VAN29850_TestStep31 hover 'Wave' the tips NOT displayed
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Meteor_Rainbow_Cycle"
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Wave"
	Then Take Screen Shot lighting_effect_Tips_TestStep31 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingNeweffectDMTipsRGB
Scenario:VAN29850_TestStep32 hover 'CPU Temperature' the tips NOT displayed
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Meteor_Rainbow_Cycle"
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "CPU Temperature"
	Then Take Screen Shot lighting_effect_Tips_TestStep32 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingNeweffectDMTipsRGB
Scenario:VAN29850_TestStep33 hover 'Meteor_Cycle' the tips NOT displayed
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Meteor_Rainbow_Cycle"
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Meteor_Cycle"
	Then Take Screen Shot lighting_effect_Tips_TestStep33 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingNeweffectDMTipsRGB
Scenario:VAN29850_TestStep34 hover 'Meteor_Rainbow_Cycle' the tips NOT displayed
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Select "Meteor_Rainbow_Cycle"
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Meteor_Rainbow_Cycle"
	Then Take Screen Shot lighting_effect_Tips_TestStep34 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingNeweffectDMTipsRGB
Scenario:VAN29850_TestStep35 hover 'Meteor' the tips NOT displayed
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Meteor"
	Then Take Screen Shot lighting_effect_Tips_TestStep35 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingNeweffectDMTipsRGB
Scenario:VAN29850_TestStep36 hover 'Meteor_Rainbow' the tips NOT displayed
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Meteor_Rainbow"
	Then Take Screen Shot lighting_effect_Tips_TestStep36 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingNeweffectDMTipsRGB
Scenario:VAN29850_TestStep37 hover 'Meteor_Cycle' the tips displayed
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Meteor_Cycle"
	Then Take Screen Shot lighting_effect_Tips_TestStep37 in 29850 under EffectSynchronous_EffecItemDropdownmenu

@LightingNeweffectDMTipsRGB
Scenario:VAN29850_TestStep38 hover 'Meteor_Rainbow_Cycle' the tips displayed
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Given click right arrow 2 times
	Then Click "3/8 Legion CPU Fan Lighting" and Hover "Meteor_Rainbow_Cycle"
	Then Take Screen Shot lighting_effect_Tips_TestStep38 in 29850 under EffectSynchronous_EffecItemDropdownmenu