@GetLightingFile
Feature: VAN19758_GamingLightingT550Cooling
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-19758
	Author： Huajie
	Automated Test Step 1-20

@T550IntelLightingCooling
Scenario:VAN19758_TestStep01 check lighting page can be open by click customize button
	Given click the the customize
	Given Lighting page is opened

@T550IntelLightingCooling
Scenario:VAN19758_TestStep02 check four lights name should be display
	Given Need Compare File is 'true'
	Given click the the customize
	Given select the profile 1
	When Set to default effect
	Then Click "1/4 Legion Icon Lighting (Front)" and Select "lightingType: Always On"
	Then Click "2/4 Internal Ambient Lighting" and Select "lightingType: Always On"
	Then Click "3/4 Legion Liquid Cooling Pump Lighting" and Select "lightingType: Rainbow"
	Then Click "4/4 Legion Liquid Cooling Fan Lighting" and Select "lightingType: Rainbow"

@T550IntelLightingCooling
Scenario:VAN19758_TestStep03 check four lights name should be display
	Given click the the customize
	Given select the profile 3
	When Set to default effect
	Then Click "3/4 Legion Liquid Cooling Pump Lighting" and Select "lightingType: Breath"
	Then Take Screen Shot 0301UI_check lighting subpage UI in 19758 under GamingScreenShotResult
	Then Lighting subpage profile3 CPU default page is consisent with UI

@T550IntelLightingCooling
Scenario:VAN19758_TestStep04 check four lights name should be display
	Given click the the customize
	Given select the profile off
	Then profile tips shows normally
	"""
	Lighting is currently off. Select the profile tab above to turn it on and customize it.
	"""

@T550IntelLightingCooling
Scenario:VAN19758_TestStep05 check default value is profile1 
	Given click the the customize
	Then four lighting profiles dispaly
	Given select the profile 3 
	When set lighting profile to default
	When Click Y logo
	Given click the the customize
	Then lighting profile 1 is selected

@T550IntelLightingCooling
Scenario:VAN19758_TestStep06 check default lighting types of profile1 
	Given Need Compare File is 'true'
	Given click the the customize
	Given select the profile 3
	Given select the profile 1
	Then lighting profile 1 is selected
	When Set to default effect
	Then Click "1/4 Legion Icon Lighting (Front)" and Select "lightingType: Always On"
	Then Click "2/4 Internal Ambient Lighting" and Select "lightingType: Always On"
	Then Click "3/4 Legion Liquid Cooling Pump Lighting" and Select "lightingType: Rainbow"
	Then Click "4/4 Legion Liquid Cooling Fan Lighting" and Select "lightingType: Rainbow"

@T550IntelLightingCooling
Scenario:VAN19758_TestStep07 check profile1 brightness is 3
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1/4 Legion Icon Lighting (Front)"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'
	Then Click The "2/4 Internal Ambient Lighting"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'
	Then Click The "3/4 Legion Liquid Cooling Pump Lighting"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'
	Then Click The "4/4 Legion Liquid Cooling Fan Lighting"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@T550IntelLightingCooling
Scenario:VAN19758_TestStep08 check profile1 default speed
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1/4 Legion Icon Lighting (Front)"
	Then The "Speed" is not show in Lighting
	Then Click The "2/4 Internal Ambient Lighting"
	Then The "Speed" is not show in Lighting
	Then Click The "3/4 Legion Liquid Cooling Pump Lighting"
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'
	Then Click The "4/4 Legion Liquid Cooling Fan Lighting"
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'

@T550IntelLightingCooling
Scenario:VAN19758_TestStep09 check profile1 default color square should not show
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1/4 Legion Icon Lighting (Front)"
	Then The "Color" is not show in Lighting
	Then Click The "2/4 Internal Ambient Lighting"
	Then The "Color" is not show in Lighting
	Then Click The "3/4 Legion Liquid Cooling Pump Lighting"
	Then The "Color" is not show in Lighting
	Then Click The "4/4 Legion Liquid Cooling Fan Lighting"
	Then The "Color" is not show in Lighting

@T550IntelLightingCooling
Scenario:VAN19758_TestStep10 check profile1 four lights effect and color
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	Given select the profile 1
	When Set to default effect
	Then Click "1/4 Legion Icon Lighting (Front)" and Select "lightingType: Always On"
	Then Click "2/4 Internal Ambient Lighting" and Select "lightingType: Always On"
	Then Click "3/4 Legion Liquid Cooling Pump Lighting" and Select "lightingType: Rainbow"
	Then Click "4/4 Legion Liquid Cooling Fan Lighting" and Select "lightingType: Rainbow"

@T550IntelLightingCooling
Scenario:VAN19758_TestStep11 check profile2 default effect
	Given Need Compare File is 'true'
	Given click the the customize
	Given select the profile 2
	Then lighting profile 2 is selected
	When Set to default effect
	Then Click "1/4 Legion Icon Lighting (Front)" and Select "lightingType: Fast Blink"
	Then Click "2/4 Internal Ambient Lighting" and Select "lightingType: Fast Blink"
	Then Click "3/4 Legion Liquid Cooling Pump Lighting" and Select "lightingType: Static"
	Then Click "4/4 Legion Liquid Cooling Fan Lighting" and Select "lightingType: Static"

@T550IntelLightingCooling
Scenario:VAN19758_TestStep12 check profile2 default brightness
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "1/4 Legion Icon Lighting (Front)"
	Then The "Brightness" is not show in Lighting
	Then Click The "2/4 Internal Ambient Lighting"
	Then The "Brightness" is not show in Lighting
	Then Click The "3/4 Legion Liquid Cooling Pump Lighting"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'
	Then Click The "4/4 Legion Liquid Cooling Fan Lighting"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@T550IntelLightingCooling
Scenario:VAN19758_TestStep13 check profile2 default speed
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "1/4 Legion Icon Lighting (Front)"
	Then The "Speed" is not show in Lighting
	Then Click The "2/4 Internal Ambient Lighting"
	Then The "Speed" is not show in Lighting
	Then Click The "3/4 Legion Liquid Cooling Pump Lighting"
	Then The "Speed" is not show in Lighting
	Then Click The "4/4 Legion Liquid Cooling Fan Lighting"
	Then The "Speed" is not show in Lighting

@T550IntelLightingCooling
Scenario:VAN19758_TestStep14 check profile2 default color square should not show
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "1/4 Legion Icon Lighting (Front)"
	Then The "Color" is not show in Lighting
	Then Click The "2/4 Internal Ambient Lighting"
	Then The "Color" is not show in Lighting
	Then Click The "3/4 Legion Liquid Cooling Pump Lighting"
	Then The "Color" is show in Lighting
	Then Click The "4/4 Legion Liquid Cooling Fan Lighting"
	Then The "Color" is show in Lighting

@T550IntelLightingCooling
Scenario:VAN19758_TestStep15 check profile2 four lights effect and color
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click "1/4 Legion Icon Lighting (Front)" and Select "lightingType: Fast Blink"
	Then Click "2/4 Internal Ambient Lighting" and Select "lightingType: Fast Blink"
	Then Click "3/4 Legion Liquid Cooling Pump Lighting" and Select "lightingType: Static"
	Then The "Color" is show in Lighting
	Then Color should be RGB "21,141,221"
	Then Click "4/4 Legion Liquid Cooling Fan Lighting" and Select "lightingType: Static"
	Then The "Color" is show in Lighting
	Then Color should be RGB "21,141,221"

@T550IntelLightingCooling
Scenario:VAN19758_TestStep16 check profile3 default effect
	Given Need Compare File is 'true'
	Given click the the customize
	Given select the profile 3
	Then lighting profile 3 is selected
	When Set to default effect
	Then Click "1/4 Legion Icon Lighting (Front)" and Select "lightingType: Breath"
	Then Click "2/4 Internal Ambient Lighting" and Select "lightingType: Breath"
	Then Click "3/4 Legion Liquid Cooling Pump Lighting" and Select "lightingType: Breath"
	Then Click "4/4 Legion Liquid Cooling Fan Lighting" and Select "lightingType: Breath"

@T550IntelLightingCooling
Scenario:VAN19758_TestStep17 check profile3 default brightness
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "1/4 Legion Icon Lighting (Front)"
	Then The "Brightness" is not show in Lighting
	Then Click The "2/4 Internal Ambient Lighting"
	Then The "Brightness" is not show in Lighting
	Then Click The "3/4 Legion Liquid Cooling Pump Lighting"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'
	Then Click The "4/4 Legion Liquid Cooling Fan Lighting"
	Then The "Brightness" is show in Lighting
	Then Brightness bar should be shown and the value should be '3'

@T550IntelLightingCooling
Scenario:VAN19758_TestStep18 check profile3 default speed
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "1/4 Legion Icon Lighting (Front)"
	Then The "Speed" is not show in Lighting
	Then Click The "2/4 Internal Ambient Lighting"
	Then The "Speed" is not show in Lighting
	Then Click The "3/4 Legion Liquid Cooling Pump Lighting"
	Then Speed bar should be shown and the value should be '2'
	Then Click The "4/4 Legion Liquid Cooling Fan Lighting"
	Then Speed bar should be shown and the value should be '2'

@T550IntelLightingCooling
Scenario:VAN19758_TestStep19 check if profile3 default color square shows
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "1/4 Legion Icon Lighting (Front)"
	Then The "Color" is not show in Lighting
	Then Click The "2/4 Internal Ambient Lighting"
	Then The "Color" is not show in Lighting
	Then Click The "3/4 Legion Liquid Cooling Pump Lighting"
	Then The "Color" is show in Lighting
	Then Click The "4/4 Legion Liquid Cooling Fan Lighting"
	Then The "Color" is show in Lighting

@T550IntelLightingCooling
Scenario:VAN19758_TestStep20 check profile3 four lights effect and color
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click "1/4 Legion Icon Lighting (Front)" and Select "lightingType: Breath"
	Then Click "2/4 Internal Ambient Lighting" and Select "lightingType: Breath"
	Then Click "3/4 Legion Liquid Cooling Pump Lighting" and Select "lightingType: Breath"
	Then The "Color" is show in Lighting
	Then Color should be RGB "21,141,221"
	Then Click "4/4 Legion Liquid Cooling Fan Lighting" and Select "lightingType: Breath"
	Then The "Color" is show in Lighting
	Then Color should be RGB "21,141,221"