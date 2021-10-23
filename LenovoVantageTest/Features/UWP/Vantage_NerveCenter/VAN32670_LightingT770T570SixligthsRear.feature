@GetLightingFile
Feature: VAN32670_T7770T570SixligthsRear
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-32670
	Author： Xuwei
	Test steps : 1-20

@LightingDTX70SixLightsRear
Scenario:VAN32670_TestStep01 check the page
	Then The Lighting Feature value is 23 And the Method is IsSupportLightingFeature
	Given click the the customize
	Given Lighting page is opened
	
@LightingDTX70SixLightsRear
Scenario:VAN32670_TestStep02 check the Six lights name
	When set lighting profile to default
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1/6 Legion Icon Lighting (Front)"
	Then The light name should be "Legion Icon Lighting (Front)"
	Then Click The "2/6 Internal Ambient Lighting"
	Then The light name should be "Internal Ambient Lighting"
	Then Click The "3/6 Legion CPU Fan Lighting"
	Then The light name should be "Legion CPU Fan Lighting"
	Then Click The "4/6 Legion Rear Fan Lighting"
	Then The light name should be "Legion Rear Fan Lighting"
	Then Click The "5/6 Legion Front Fan Lighting"
	Then The light name should be "Legion Front Fan Lighting"
	Then Click The "6/6 Legion Top Fan Lighting"
	Then The light name should be "Legion Top Fan Lighting"
	
@LightingDTX70SixLightsRear
Scenario:VAN32670_TestStep03 check four lights name should be display
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType: Breath"
	Then Take Screen Shot 0301UI_check lighting subpage UI in 32670 under GamingScreenShotResult
	Then Lighting subpage profile 3 CPU default page is consisent with UI
	
@LightingDTX70SixLightsRear
Scenario:VAN32670_TestStep04 check the page
	Given click the the customize
	Given Lighting page is opened
	Given select the profile off
	Given wait 1 seconds
	Then profile tips shows normally
	"""
	Lighting is currently off. Select the profile tab above to turn it on and customize it.
	"""
	
@LightingDTX70SixLightsRear
Scenario:VAN32670_TestStep05 check the default profile
	When set lighting profile to default
	Given click the the customize
	Given Lighting page is opened
	Then lighting profile 1 is selected
	
@LightingDTX70SixLightsRear
Scenario:VAN32670_TestStep06 check the profile 1 Six lights default effect
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then lighting profile 1 is selected
	When Set to default effect
	Then Click "1/6 Legion Icon Lighting (Front)" and Select "lightingType: Static"
	Then Click "2/6 Internal Ambient Lighting" and Select "lightingType: Static"
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType: Rainbow"
	Then Click "4/6 Legion Rear Fan Lighting" and Select "lightingType: Rainbow"
	Then Click "5/6 Legion Front Fan Lighting" and Select "lightingType: Rainbow"
	Then Click "6/6 Legion Top Fan Lighting" and Select "lightingType: Rainbow"
	
@LightingDTX70SixLightsRear
Scenario:VAN32670_TestStep07 check the profile 1 Six lights default brightness value
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1/6 Legion Icon Lighting (Front)"
	Then Brightness bar should be shown and the value should be '3'
	Then Click The "2/6 Internal Ambient Lighting"
	Then Brightness bar should be shown and the value should be '3'
	Then Click The "3/6 Legion CPU Fan Lighting"
	Then Brightness bar should be shown and the value should be '3'
	Then Click The "4/6 Legion Rear Fan Lighting"
	Then Brightness bar should be shown and the value should be '3'
	Then Click The "5/6 Legion Front Fan Lighting"
	Then Brightness bar should be shown and the value should be '3'
	Then Click The "6/6 Legion Top Fan Lighting"
	Then Brightness bar should be shown and the value should be '3'
	
@LightingDTX70SixLightsRear
Scenario:VAN32670_TestStep08 check the profile 1 Six lights default speed value
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1/6 Legion Icon Lighting (Front)"
	Then The "Speed" is not show in Lighting
	Then Click The "2/6 Internal Ambient Lighting"
	Then The "Speed" is not show in Lighting
	Then Click The "3/6 Legion CPU Fan Lighting"
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'
	Then Click The "4/6 Legion Rear Fan Lighting"
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'
	Then Click The "5/6 Legion Front Fan Lighting"
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'
	Then Click The "6/6 Legion Top Fan Lighting"
	Then The "Speed" is show in Lighting
	Then Speed bar should be shown and the value should be '2'
	
@LightingDTX70SixLightsRear
Scenario:VAN32670_TestStep09 check the profile 1 color square
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1/6 Legion Icon Lighting (Front)"
	Then The "Color" is not show in Lighting
	Then Click The "2/6 Internal Ambient Lighting"
	Then The "Color" is not show in Lighting
	Then Click The "3/6 Legion CPU Fan Lighting"
	Then The "Color" is not show in Lighting
	Then Click The "4/6 Legion Rear Fan Lighting"
	Then The "Color" is not show in Lighting
	Then Click The "5/6 Legion Front Fan Lighting"
	Then The "Color" is not show in Lighting
	Then Click The "6/6 Legion Top Fan Lighting"
	Then The "Color" is not show in Lighting
	
@LightingDTX70SixLightsRear
Scenario:VAN32670_TestStep10 check the profile 1 Six lights effect and color
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	Then lighting profile 1 is selected
	When Set to default effect
	Then Click "1/6 Legion Icon Lighting (Front)" and Select "lightingType: Static"
	Then Click "2/6 Internal Ambient Lighting" and Select "lightingType: Static"
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType: Rainbow"
	Then Click "4/6 Legion Rear Fan Lighting" and Select "lightingType: Rainbow"
	Then Click "5/6 Legion Front Fan Lighting" and Select "lightingType: Rainbow"
	Then Click "6/6 Legion Top Fan Lighting" and Select "lightingType: Rainbow"
	
@LightingDTX70SixLightsRear
Scenario:VAN32670_TestStep11 check the profile 2 Six lights default effect
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	Then lighting profile 2 is selected
	When Set to default effect
	Then Click "1/6 Legion Icon Lighting (Front)" and Select "lightingType: Breath"
	Then Click "2/6 Internal Ambient Lighting" and Select "lightingType: Breath"
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType: Static"
	Then Click "4/6 Legion Rear Fan Lighting" and Select "lightingType: Static"
	Then Click "5/6 Legion Front Fan Lighting" and Select "lightingType: Static"
	Then Click "6/6 Legion Top Fan Lighting" and Select "lightingType: Static"
	
@LightingDTX70SixLightsRear
Scenario:VAN32670_TestStep12 check the profile 2 Six lights default brightness value
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "1/6 Legion Icon Lighting (Front)"
	Then The "Brightness" is not show in Lighting
	Then Click The "2/6 Internal Ambient Lighting"
	Then The "Brightness" is not show in Lighting
	Then Click The "3/6 Legion CPU Fan Lighting"
	Then Brightness bar should be shown and the value should be '3'
	Then Click The "4/6 Legion Rear Fan Lighting"
	Then Brightness bar should be shown and the value should be '3'
	Then Click The "5/6 Legion Front Fan Lighting"
	Then Brightness bar should be shown and the value should be '3'
	Then Click The "6/6 Legion Top Fan Lighting"
	Then Brightness bar should be shown and the value should be '3'
	
@LightingDTX70SixLightsRear
Scenario:VAN32670_TestStep13 check the profile 2 Six lights default speed value
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "1/6 Legion Icon Lighting (Front)"
	Then The "Speed" is not show in Lighting
	Then Click The "2/6 Internal Ambient Lighting"
	Then The "Speed" is not show in Lighting
	Then Click The "3/6 Legion CPU Fan Lighting"
	Then The "Speed" is not show in Lighting
	Then Click The "4/6 Legion Rear Fan Lighting"
	Then The "Speed" is not show in Lighting
	Then Click The "5/6 Legion Front Fan Lighting"
	Then The "Speed" is not show in Lighting
	Then Click The "6/6 Legion Top Fan Lighting"
	Then The "Speed" is not show in Lighting
	
@LightingDTX70SixLightsRear
Scenario:VAN32670_TestStep14 check the profile 2 color square
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click The "1/6 Legion Icon Lighting (Front)"
	Then The "Color" is not show in Lighting
	Then Click The "2/6 Internal Ambient Lighting"
	Then The "Color" is not show in Lighting
	Then Click The "3/6 Legion CPU Fan Lighting"
	Then The "Color" is show in Lighting
	Then Click The "4/6 Legion Rear Fan Lighting"
	Then The "Color" is show in Lighting
	Then Click The "5/6 Legion Front Fan Lighting"
	Then The "Color" is show in Lighting
	Then Click The "6/6 Legion Top Fan Lighting"
	Then The "Color" is show in Lighting
	
@LightingDTX70SixLightsRear
Scenario:VAN32670_TestStep15 check the profile 2 Six lights effect and color
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 2
	When Set to default effect
	Then Click "1/6 Legion Icon Lighting (Front)" and Select "lightingType: Breath"
	Then Click "2/6 Internal Ambient Lighting" and Select "lightingType: Breath"
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType: Static"
	Then Color should be RGB "0,211,254"
	Then Click "4/6 Legion Rear Fan Lighting" and Select "lightingType: Static"
	Then Color should be RGB "0,211,254"
	Then Click "5/6 Legion Front Fan Lighting" and Select "lightingType: Static"
	Then Color should be RGB "0,211,254"
	Then Click "6/6 Legion Top Fan Lighting" and Select "lightingType: Static"
	Then Color should be RGB "0,211,254"

@LightingDTX70SixLightsRear
Scenario:VAN32670_TestStep16 check the profile 3 Six lights default effect
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	Then lighting profile 3 is selected
	When Set to default effect
	Then Click "1/6 Legion Icon Lighting (Front)" and Select "lightingType: Static"
	Then Click "2/6 Internal Ambient Lighting" and Select "lightingType: Off"
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType: Off"
	Then Click "4/6 Legion Rear Fan Lighting" and Select "lightingType: Off"
	Then Click "5/6 Legion Front Fan Lighting" and Select "lightingType: Off"
	Then Click "6/6 Legion Top Fan Lighting" and Select "lightingType: Off"
	
@LightingDTX70SixLightsRear
Scenario:VAN32670_TestStep17 check the profile 3 Six lights default brightness value
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "1/6 Legion Icon Lighting (Front)"
	Then Brightness bar should be shown and the value should be '3'
	Then Click The "2/6 Internal Ambient Lighting"
	Then The "Brightness" is not show in Lighting
	Then Click The "3/6 Legion CPU Fan Lighting"
	Then The "Brightness" is not show in Lighting
	Then Click The "4/6 Legion Rear Fan Lighting"
	Then The "Brightness" is not show in Lighting
	Then Click The "5/6 Legion Front Fan Lighting"
	Then The "Brightness" is not show in Lighting
	Then Click The "6/6 Legion Top Fan Lighting"
	Then The "Brightness" is not show in Lighting
	
@LightingDTX70SixLightsRear
Scenario:VAN32670_TestStep18 check the profile 3 Six lights default speed value
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "1/6 Legion Icon Lighting (Front)"
	Then The "Speed" is not show in Lighting
	Then Click The "2/6 Internal Ambient Lighting"
	Then The "Speed" is not show in Lighting
	Then Click The "3/6 Legion CPU Fan Lighting"
	Then The "Speed" is not show in Lighting
	Then Click The "4/6 Legion Rear Fan Lighting"
	Then The "Speed" is not show in Lighting
	Then Click The "5/6 Legion Front Fan Lighting"
	Then The "Speed" is not show in Lighting
	Then Click The "6/6 Legion Top Fan Lighting"
	Then The "Speed" is not show in Lighting
	
@LightingDTX70SixLightsRear
Scenario:VAN32670_TestStep19 check the profile 3 color square
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	When Set to default effect
	Then Click The "1/6 Legion Icon Lighting (Front)"
	Then The "Color" is not show in Lighting
	Then Click The "2/6 Internal Ambient Lighting"
	Then The "Color" is not show in Lighting
	Then Click The "3/6 Legion CPU Fan Lighting"
	Then The "Color" is not show in Lighting
	Then Click The "4/6 Legion Rear Fan Lighting"
	Then The "Color" is not show in Lighting
	Then Click The "5/6 Legion Front Fan Lighting"
	Then The "Color" is not show in Lighting
	Then Click The "6/6 Legion Top Fan Lighting"
	Then The "Color" is not show in Lighting
	
@LightingDTX70SixLightsRear
Scenario:VAN32670_TestStep20 check the profile 3 Six lights effect and color
	Given Need Compare File is 'true'
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 3
	Then lighting profile 3 is selected
	When Set to default effect
	Then Click "1/6 Legion Icon Lighting (Front)" and Select "lightingType: Static"
	Then Click "2/6 Internal Ambient Lighting" and Select "lightingType: Off"
	Then Click "3/6 Legion CPU Fan Lighting" and Select "lightingType: Off"
	Then Click "4/6 Legion Rear Fan Lighting" and Select "lightingType: Off"
	Then Click "5/6 Legion Front Fan Lighting" and Select "lightingType: Off"
	Then Click "6/6 Legion Top Fan Lighting" and Select "lightingType: Off"