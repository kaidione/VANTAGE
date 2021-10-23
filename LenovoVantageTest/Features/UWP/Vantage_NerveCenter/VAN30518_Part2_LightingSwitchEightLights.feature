@GetLightingFile
Feature: VAN30518_Part2_LightingSwitchEightLights
	Test Case: https://lnvusjira.lenovonet.lenovo.local/browse/VAN-30518
	Author: Xuwei
	Automated Test Step 25-53

Background:
	Then The Graphics Card vendor value is 1 And the Method is GetGPUVendor
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature

@LightingSwitchEightLights
Scenario: VAN30518_TestStep25_Check the left arrow in the switch lights bar is grey and cannot be clickable, right arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 8."
	Then The Left Arrow In The Switch Lights Bar Is "Grey And Cannot Be Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchEightLights
Scenario: VAN30518_TestStep26_Check the switch lights bar 2/8 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 8."
	Given click right arrow 1 times
	Then The light name should be "2 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep27_Check the right and left arrow in the switch lights bar should be clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 8."
	Given click right arrow 1 times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchEightLights
Scenario: VAN30518_TestStep28_Check the switch lights bar 3/8 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 8."
	Given click right arrow 2 times
	Then The light name should be "3 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep29_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 8."
	Given click right arrow 2 times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchEightLights
Scenario: VAN30518_TestStep30_Check the switch lights bar 4/8 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 8."
	Given click right arrow 3 times
	Then The light name should be "4 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep31_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 8."
	Given click right arrow 3 times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchEightLights
Scenario: VAN30518_TestStep32_Check the switch lights bar 5/8 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 8."
	Given click right arrow 4 times
	Then The light name should be "5 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep33_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 8."
	Given click right arrow 4 times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchEightLights
Scenario: VAN30518_TestStep34_Check the switch lights bar 6/8 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 8."
	Given click right arrow 5 times
	Then The light name should be "6 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep35_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 8."
	Given click right arrow 5 times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchEightLights
Scenario: VAN30518_TestStep36_Check the switch lights bar 7/8 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 8."
	Given click right arrow 6 times
	Then The light name should be "7 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep37_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 8."
	Given click right arrow 6 times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchEightLights
Scenario: VAN30518_TestStep38_Check the switch lights bar 8/8 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 8."
	Given click right arrow 7 times
	Then The light name should be "8 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep39_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 8."
	Given click right arrow 7 times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Grey And Cannot Be Clickable"

@LightingSwitchEightLights
Scenario: VAN30518_TestStep40_Check the switch lights bar 8/8 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "8 / 8."
	Given Click Left Arrow 1 Times
	Then The light name should be "7 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep41_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "8 / 8."
	Given Click Left Arrow 1 Times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchEightLights
Scenario: VAN30518_TestStep42_Check the switch lights bar 6/8 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "8 / 8."
	Given Click Left Arrow 2 Times
	Then The light name should be "6 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep43_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "8 / 8."
	Given Click Left Arrow 2 Times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchEightLights
Scenario: VAN30518_TestStep44_Check the switch lights bar 5/8 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "8 / 8."
	Given Click Left Arrow 3 Times
	Then The light name should be "5 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep45_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "8/ 8."
	Given Click Left Arrow 3 Times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchEightLights
Scenario: VAN30518_TestStep46_Check the switch lights bar 4/8 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "8 / 8."
	Given Click Left Arrow 4 Times
	Then The light name should be "4 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep47_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "8 / 8."
	Given Click Left Arrow 4 Times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchEightLights
Scenario: VAN30518_TestStep48_Check the switch lights bar 3/8 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "8 / 8."
	Given Click Left Arrow 5 Times
	Then The light name should be "3 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep49_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "8 / 8."
	Given Click Left Arrow 5 Times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchEightLights
Scenario: VAN30518_TestStep50_Check the switch lights bar 2/8 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "8 / 8."
	Given Click Left Arrow 6 Times
	Then The light name should be "2 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep51_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "8 / 8."
	Given Click Left Arrow 6 Times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchEightLights
Scenario: VAN30518_TestStep52_Check the switch lights bar 1/8 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "8 / 8."
	Given Click Left Arrow 7 Times
	Then The light name should be "1 / 8."

@LightingSwitchEightLights
Scenario: VAN30518_TestStep53_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "8 / 8."
	Given Click Left Arrow 7 Times
	Then The Left Arrow In The Switch Lights Bar Is "Grey And Cannot Be Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"