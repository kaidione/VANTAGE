@GetLightingFile
Feature: VAN19271_HomepageLighting
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-19271
	Author： Huajie
	Automated Test Step 01-07

Background: 
	Given Machine is Gaming

@HomepageLighting
Scenario:VAN19271_TestStep01 check lighting section UI should follow definition
	Then Lighting section display normally at homepage

@HomepageLighting
Scenario:VAN19271_TestStep02 check lighting image should be real current machine
	Given Scroll the screen
	Then Take Screen Shot 0201UI_check lighting section UI in 19271 under GamingScreenShotResult

@HomepageLighting
Scenario:VAN19271_TestStep03 check four profiles display and default is profile1
	Given click the the customize
	Then four lighting profiles dispaly
	Given select the profile 3 
	When set lighting profile to default
	When Click Y logo
	Given click the the customize
	Then lighting profile 1 is selected
	When Click Y logo
	Then lighting profile 1 is selected at homepage

@HomepageLighting
Scenario:VAN19271_TestStep04 check profile1 is selected and the effect is right
	Given Need Compare File is 'true'
	Given click the the customize
	Given select the profile 3
	Given select the profile 1
	Then lighting profile 1 is selected
	When Set to default effect
	Then Click "2/8 Internal Ambient Lighting" and Select "lightingType: Always On"
	When Click Y logo
	Then lighting profile 1 is selected at homepage

@HomepageLighting
Scenario:VAN19271_TestStep05 check profile2 is selected and the effect is right
	Given Need Compare File is 'true'
	Given click the the customize
	Given select the profile 2
	Then lighting profile 2 is selected
	When Set to default effect
	Then Click "4/8 Legion Rear Fan Lighting" and Select "lightingType: Static"
	When Click Y logo
	Then lighting profile 2 is selected at homepage

@HomepageLighting
Scenario:VAN19271_TestStep06 check profile3 is selected and the effect is right
	Given Need Compare File is 'true'
	Given click the the customize
	Given select the profile 3
	Then lighting profile 3 is selected
	When Set to default effect
	Then Click "1/8 Legion Icon Lighting (Front)" and Select "lightingType: Breath"
	When Click Y logo
	Then lighting profile 3 is selected at homepage

@HomepageLighting
Scenario:VAN19271_TestStep07 check profile off is selected and the effect is right
	Given Need Compare File is 'true'
	Given click the the customize
	Given select the profile off
	Then lighting profile off is selected
	When Click Y logo
	Then lighting profile off is selected at homepage
