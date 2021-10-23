@GetLightingFile
Feature: VAN19760_GamingLighting_X50_SingleColor
	Test Case： https://jira.tc.lenovo.com/browse/VAN-19760
	Author： wenyang

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep01 check the default profile
	Then The Lighting section is display or not display in homepage 'display'
	When set lighting profile to default
	Given click the the customize
	Given Lighting page is opened
	Then lighting profile 1 is selected

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep02 check the SingleColor effect
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Take Screen Shot TestStep02 in 19760 under GamingLighting_X50_SingleColor
	Then effect dropdown menu should be expanded and effects should be shown:
		| Effect name |
		| Always On   |
		| Fast Blink  |
		| Slow Blink  |
		| Breath      |

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor @SingleColor
Scenario:VAN19760_TestStep03 check the off tips
	Then The Lighting section is display or not display in homepage 'display'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile off
	Then profile tips shows normally
	"""
	Lighting is currently off. Select the profile tab above to turn it on and customize it.
	"""

@T550_YlogoSingleColor @T550_BigYSingleColor
Scenario:VAN19760_TestStep0401 check the profile 1 default effect(T550_Ylogo)
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then The "Legion Icon (Front)" is show in Lighting
	Then Click "" and Select "lightingType:Always On"

@T550_BigYSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep0402 check the profile 1 default effect(T550G)
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then The "Ambient Lighting" is show in Lighting
	Then Click "" and Select "lightingType:Always On"

@T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep05 check the profile 1 default effect
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then The "" is show in Lighting
	Then Click "" and Select "lightingType:Breath"

@T550_YlogoSingleColor @T550_BigYSingleColor
Scenario:VAN19760_TestStep06 check the profile 1 default brightness
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Brightness bar should be shown and the value should be '3'

@T550GSingleColor @T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep07 check the profile 1 brightness will be hide
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then The "Brightness" is not show in Lighting

@T550_YlogoSingleColor @T550_BigYSingleColor
Scenario:VAN19760_TestStep08 check the profile 1 speed will be hide
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then The "Speed" is not show in Lighting

@T550_YlogoSingleColor
Scenario:VAN19760_TestStep0901 check the profile 1 lighting effect is Always On color should be blue(T550_Ylogo)
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then The "Legion Icon (Front)" is show in Lighting
	Then Click "" and Select "lightingType:Always On"

@T550GSingleColor
Scenario:VAN19760_TestStep0902 check the profile 1 lighting effect is Always On color should be blue(T550G)
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then The "Ambient Lighting" is show in Lighting
	Then Click "" and Select "lightingType:Always On"

@T550_BigYSingleColor
Scenario:VAN19760_TestStep10 check the profile 1 lighting effect is Always On color should be red
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then The "" is show in Lighting
	Then Click "" and Select "lightingType:Always On"

@T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep11 check the profile 1 lighting effect is Breath color should be blue
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then The "" is show in Lighting
	Then Click "" and Select "lightingType:Breath"

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep1201 check the profile 2 default effect(T550_Ylogo)
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then The "Legion Icon (Front)" is show in Lighting
	Then Click "" and Select "lightingType:Fast Blink"

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep1202 check the profile 2 default effect(T550G)
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then The "Ambient Lighting" is show in Lighting
	Then Click "" and Select "lightingType:Fast Blink"

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep13 check the profile 2 brightness will be hide
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	Then The "Brightness" is not show in Lighting

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep14 check the profile 2 speed will be hide
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	Then The "Speed" is not show in Lighting

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep1501 check the profile 2 lighting effect is Fast Blink color is blue frequency is 2s(T550_Ylogo)
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then The "Legion Icon (Front)" is show in Lighting
	Then Click "" and Select "lightingType:Fast Blink"

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep1502 check the profile 2 lighting effect is Fast Blink color is blue frequency is 2s(T550G)
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then The "Ambient Lighting" is show in Lighting
	Then Click "" and Select "lightingType:Fast Blink"

@T550_BigYSingleColor
Scenario:VAN19760_TestStep16 check the profile 2 lighting effect is Fast Blink color is red frequency is 2s
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then The "" is show in Lighting
	Then Click "" and Select "lightingType:Fast Blink"

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep1701 check the profile 3 default effect(T550_Ylogo)
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then The "Legion Icon (Front)" is show in Lighting
	Then Click "" and Select "lightingType:Breath"

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep1702 check the profile 3 default effect(T550G)
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then The "Ambient Lighting" is show in Lighting
	Then Click "" and Select "lightingType:Breath"

@T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep18 check the profile 3 default effect
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then The "" is show in Lighting
	Then Click "" and Select "lightingType:Always On"

@T550_YlogoSingleColor @T550_BigYSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep19 check the profile 3 brightness will be hide
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	Then The "Brightness" is not show in Lighting

@T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep20 check the profile 3 default brightness
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Brightness bar should be shown and the value should be '3'

@T550_YlogoSingleColor
Scenario:VAN19760_TestStep2101 check the profile 3 lighting effect is Breath color should be blue(T550_Ylogo)
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then The "Legion Icon (Front)" is show in Lighting
	Then Click "" and Select "lightingType:Breath"

@T550GSingleColor
Scenario:VAN19760_TestStep2102 check the profile 3 lighting effect is Breath color should be blue(T550G)
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then The "Ambient Lighting" is show in Lighting
	Then Click "" and Select "lightingType:Breath"

@T550_BigYSingleColor
Scenario:VAN19760_TestStep22 check the profile 3 lighting effect is Breath color should be red
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then The "" is show in Lighting
	Then Click "" and Select "lightingType:Breath"

@T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep23 check the profile 3 lighting effect is Always On color should be blue
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then The "" is show in Lighting
	Then Click "" and Select "lightingType:Always On"

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep2501 check the S3S4 the effect will be keeped(T550_Ylogo)
	Given Need Compare File is 'true'
	When set lighting profile to default
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Enter sleep
	When Set to default effect
	Then The "Legion Icon (Front)" is show in Lighting
	Then Click "" and Select "lightingType:Fast Blink"

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep2502 check the S3S4 the effect will be keeped(T550G)
	Given Need Compare File is 'true'
	When set lighting profile to default
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Enter sleep
	When Set to default effect
	Then The "Ambient Lighting" is show in Lighting
	Then Click "" and Select "lightingType:Fast Blink"

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep2601 check the S3S4 the effect will be keeped(T550_Ylogo)
	Given Need Compare File is 'true'
	When set lighting profile to default
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Enter hibernate
	When Set to default effect
	Then The "Legion Icon (Front)" is show in Lighting
	Then Click "" and Select "lightingType:Fast Blink"

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep2602 check the S3S4 the effect will be keeped(T550G)
	Given Need Compare File is 'true'
	When set lighting profile to default
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Enter hibernate
	When Set to default effect
	Then The "Ambient Lighting" is show in Lighting
	Then Click "" and Select "lightingType:Fast Blink"

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep27 check the lighting effect selected off
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Given select the profile off
	Then lighting profile off is selected

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep2801 check the Always On selected(T550_Ylogo)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Legion Icon (Front)" and Select "Always On"
	Then Click "Legion Icon (Front)" and Select "lightingType:Always On"

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep2802 check the Always On selected(T550G)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Select "Always On"
	Then Click "Ambient Lighting" and Select "lightingType:Always On"

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep2901 check the Fast Blink selected(T550_Ylogo)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	Then Click "Legion Icon (Front)" and Select "Fast Blink"
	Then Click "Legion Icon (Front)" and Select "lightingType:Fast Blink"

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep2902 check the Fast Blink selected(T550G)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	Then Click "Ambient Lighting" and Select "Fast Blink"
	Then Click "Ambient Lighting" and Select "lightingType:Fast Blink"

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep3001 check the Slow Blink selected(T550_Ylogo)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	Then Click "Legion Icon (Front)" and Select "Slow Blink"
	Then Click "Legion Icon (Front)" and Select "lightingType:Slow Blink"

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep3002 check the Slow Blink selected(T550G)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	Then Click "Ambient Lighting" and Select "Slow Blink"
	Then Click "Ambient Lighting" and Select "lightingType:Slow Blink"

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep3101 check the Breath selected(T550_Ylogo)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	Then Click "Legion Icon (Front)" and Select "Breath"
	Then Click "Legion Icon (Front)" and Select "lightingType:Breath"

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep3102 check the Breath selected(T550G)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	Then Click "Ambient Lighting" and Select "Breath"
	Then Click "Ambient Lighting" and Select "lightingType:Breath"

@T550_YlogSingleColoro @T550_BigYSingleColor @T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep32 check brightness bar show for Always On and value is 3
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Legion Icon (Front)" and Select "Always On"
	When Set to default effect
	Then Brightness bar should be shown and the value should be '3'

@T550GSingleColor
Scenario:VAN19760_TestStep33 check brightness bar not show for Always On
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Select "Always On"
	When Set to default effect
	Then The "Brightness" is not show in Lighting

@T550_YlogSingleColoro @T550_BigYSingleColor @T550AMD_YlogoSingleColor 
Scenario:VAN19760_TestStep3401 check brightness bar not show for Fast Blink(T550_Ylogo)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Legion Icon (Front)" and Select "Fast Blink"
	Then The "Brightness" is not show in Lighting

 @T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep3402 check brightness bar not show for Fast Blink(T550G)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Select "Fast Blink"
	Then The "Brightness" is not show in Lighting

@T550_YlogSingleColoro @T550_BigYSingleColor @T550AMD_YlogoSingleColor 
Scenario:VAN19760_TestStep3501 check brightness bar not show for Slow Blink(T550_Ylogo)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Legion Icon (Front)" and Select "Slow Blink"
	Then The "Brightness" is not show in Lighting

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep3502 check brightness bar not show for Slow Blink(T550G)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Select "Slow Blink"
	Then The "Brightness" is not show in Lighting

@T550_YlogSingleColoro @T550_BigYSingleColor @T550AMD_YlogoSingleColor 
Scenario:VAN19760_TestStep3601 check brightness bar not show for Breath(T550_Ylogo)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Legion Icon (Front)" and Select "Breath"
	Then The "Brightness" is not show in Lighting

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep3602 check brightness bar not show for Breath(T550G)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Select "Breath"
	Then The "Brightness" is not show in Lighting

@T550_YlogSingleColoro @T550_BigYSingleColor @T550AMD_YlogoSingleColor 
Scenario:VAN19760_TestStep3701 check Speed bar not show for Always On(T550_Ylogo)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Legion Icon (Front)" and Select "Always On"
	Then The "Speed" is not show in Lighting

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep3702 check Speed bar not show for Always On(T550G)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Select "Always On"
	Then The "Speed" is not show in Lighting

@T550_YlogSingleColoro @T550_BigYSingleColor @T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep3801 check Speed bar not show for Fast Blink(T550_Ylogo)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Legion Icon (Front)" and Select "Fast Blink"
	Then The "Speed" is not show in Lighting

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep3802 check Speed bar not show for Fast Blink(T550G)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Select "Fast Blink"
	Then The "Speed" is not show in Lighting

@T550_YlogSingleColoro @T550_BigYSingleColor @T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep3901 check Speed bar not show for Slow Blink(T550_Ylogo)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Legion Icon (Front)" and Select "Slow Blink"
	Then The "Speed" is not show in Lighting

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep3902 check Speed bar not show for Slow Blink(T550G)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Select "Slow Blink"
	Then The "Speed" is not show in Lighting

@T550_YlogSingleColoro @T550_BigYSingleColor @T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep4001 check Speed bar not show for Breath(T550_Ylogo)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Legion Icon (Front)" and Select "Breath"
	Then The "Speed" is not show in Lighting

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep4002 check Speed bar not show for Breath(T550G)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Select "Breath"
	Then The "Speed" is not show in Lighting

@T550_YlogoSingleColor @T550_BigYSingleColor
Scenario:VAN19760_TestStep41 check color square not show for Always On
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Legion Icon (Front)" and Select "Always On"
	Then The "Color" is not show in Lighting

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep4201 check color square not show for Fast Blink(T550_Ylogo)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Legion Icon (Front)" and Select "Fast Blink"
	Then The "Color" is not show in Lighting

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep4202 check color square not show for Fast Blink(T550G)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Select "Fast Blink"
	Then The "Color" is not show in Lighting

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep4301 check color square not show for Slow Blink(T550_Ylogo)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Legion Icon (Front)" and Select "Slow Blink"
	Then The "Color" is not show in Lighting

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep4302 check color square not show for Slow Blink(T550G)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Select "Slow Blink"
	Then The "Color" is not show in Lighting

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor
Scenario:VAN19760_TestStep4401 check color square not show for Breath(T550_Ylogo)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Legion Icon (Front)" and Select "Breath"
	Then The "Color" is not show in Lighting

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep4402 check color square not show for Breath(T550G)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Select "Breath"
	Then The "Color" is not show in Lighting

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep45 check Set to default button not show for profile off
	Given click the the customize
	Given Lighting page is opened
	Given select the profile off
	Then The "set to default" is not show in Lighting

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor 
Scenario:VAN19760_TestStep4601 check the proflie 1 settings(T550_Ylogo)
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "" and Select "Breath"
	When Set to default effect
	Then lighting profile 1 is selected
	Then The "Legion Icon (Front)" is show in Lighting
	Then Click "" and Select "lightingType:Always On"

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep4602 check the proflie 1 settings(T550G)
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "" and Select "Breath"
	When Set to default effect
	Then lighting profile 1 is selected
	Then The "Ambient Lighting" is show in Lighting
	Then Click "" and Select "lightingType:Always On"

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor 
Scenario:VAN19760_TestStep4801 check the set to default button show for proflie 1(T550_Ylogo)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Legion Icon (Front)" and Select "Slow Blink"
	When Set to default effect
	Then The "set to default" is show in Lighting

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep4802 check the set to default button show for proflie 1(T550G)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Select "Slow Blink"
	When Set to default effect
	Then The "set to default" is show in Lighting

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor 
Scenario:VAN19760_TestStep4901 check the proflie 2 settings(T550_Ylogo)
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	Then Click "" and Select "Breath"
	When Set to default effect
	Then lighting profile 2 is selected
	Then The "Legion Icon (Front)" is show in Lighting
	Then Click "" and Select "lightingType:Fast Blink"

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep4902 check the proflie 2 settings(T550G)
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	Then Click "" and Select "Breath"
	When Set to default effect
	Then lighting profile 2 is selected
	Then The "Ambient Lighting" is show in Lighting
	Then Click "" and Select "lightingType:Fast Blink"

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor 
Scenario:VAN19760_TestStep5101 check the set to default button show for proflie 2(T550_Ylogo)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Legion Icon (Front)" and Select "Slow Blink"
	When Set to default effect
	Then The "set to default" is show in Lighting

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep5102 check the set to default button show for proflie 2(T550G)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Select "Slow Blink"
	When Set to default effect
	Then The "set to default" is show in Lighting

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor 
Scenario:VAN19760_TestStep5201 check the proflie 3 settings(T550_Ylogo)
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	Then Click "" and Select "Always On"
	When Set to default effect
	Then lighting profile 3 is selected
	Then The "Legion Icon (Front)" is show in Lighting
	Then Click "" and Select "lightingType:Breath"

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep5202 check the proflie 3 settings(T550G)
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	Then Click "" and Select "Always On"
	When Set to default effect
	Then lighting profile 3 is selected
	Then The "Ambient Lighting" is show in Lighting
	Then Click "" and Select "lightingType:Breath"

@T550_YlogoSingleColor @T550_BigYSingleColor @T550AMD_YlogoSingleColor 
Scenario:VAN19760_TestStep5401 check the set to default button show for proflie 3(T550_Ylogo)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Legion Icon (Front)" and Select "Slow Blink"
	When Set to default effect
	Then The "set to default" is show in Lighting

@T550_BigYSingleColor @T550AMD_YlogoSingleColor @T550GSingleColor
Scenario:VAN19760_TestStep5402 check the set to default button show for proflie 3(T550G)
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then Click "Ambient Lighting" and Select "Slow Blink"
	When Set to default effect
	Then The "set to default" is show in Lighting