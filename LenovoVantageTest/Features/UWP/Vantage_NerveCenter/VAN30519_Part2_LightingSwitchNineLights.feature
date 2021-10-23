@GetLightingFile
Feature: VAN30519_Part2_LightingSwitchNineLights
	Test Case: https://lnvusjira.lenovonet.lenovo.local/browse/VAN-30519
	Author: Yang Liu
	Automated Test Step 28-60

Background:
	Then The Graphics Card vendor value is 2 And the Method is GetGPUVendor
	Then The Lighting Feature value is 18 And the Method is IsSupportLightingFeature

@LightingSwitchNineLights
Scenario: VAN30519_TestStep28_Check the left arrow in the switch lights bar is grey and cannot be clickable, right arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 9."
	Then The Left Arrow In The Switch Lights Bar Is "Grey And Cannot Be Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchNineLights
Scenario: VAN30519_TestStep29_Check the switch lights bar 2/9 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 9."
	Given click right arrow 1 times
	Then The light name should be "2 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep30_Check the right and left arrow in the switch lights bar should be clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 9."
	Given click right arrow 1 times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchNineLights
Scenario: VAN30519_TestStep31_Check the switch lights bar 3/9 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 9."
	Given click right arrow 2 times
	Then The light name should be "3 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep32_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 9."
	Given click right arrow 2 times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchNineLights
Scenario: VAN30519_TestStep33_Check the switch lights bar 4/9 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 9."
	Given click right arrow 3 times
	Then The light name should be "4 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep34_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 9."
	Given click right arrow 3 times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchNineLights
Scenario: VAN30519_TestStep35_Check the switch lights bar 5/9 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 9."
	Given click right arrow 4 times
	Then The light name should be "5 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep36_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 9."
	Given click right arrow 4 times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchNineLights
Scenario: VAN30519_TestStep37_Check the switch lights bar 6/9 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 9."
	Given click right arrow 5 times
	Then The light name should be "6 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep38_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 9."
	Given click right arrow 5 times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchNineLights
Scenario: VAN30519_TestStep39_Check the switch lights bar 7/9 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 9."
	Given click right arrow 6 times
	Then The light name should be "7 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep40_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 9."
	Given click right arrow 6 times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchNineLights
Scenario: VAN30519_TestStep41_Check the switch lights bar 8/9 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 9."
	Given click right arrow 7 times
	Then The light name should be "8 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep42_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 9."
	Given click right arrow 7 times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchNineLights
Scenario: VAN30519_TestStep43_Check the switch lights bar 9/9 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 9."
	Given click right arrow 8 times
	Then The light name should be "9 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep44_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "1 / 9."
	Given click right arrow 8 times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Grey And Cannot Be Clickable"

@LightingSwitchNineLights
Scenario: VAN30519_TestStep45_Check the switch lights bar 8/9 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "9 / 9."
	Given Click Left Arrow 1 Times
	Then The light name should be "8 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep46_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "9 / 9."
	Given Click Left Arrow 1 Times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchNineLights
Scenario: VAN30519_TestStep47_Check the switch lights bar 7/9 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "9 / 9."
	Given Click Left Arrow 2 Times
	Then The light name should be "7 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep48_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "9 / 9."
	Given Click Left Arrow 2 Times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchNineLights
Scenario: VAN30519_TestStep49_Check the switch lights bar 6/9 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "9 / 9."
	Given Click Left Arrow 3 Times
	Then The light name should be "6 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep50_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "9 / 9."
	Given Click Left Arrow 3 Times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchNineLights
Scenario: VAN30519_TestStep51_Check the switch lights bar 5/9 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "9 / 9."
	Given Click Left Arrow 4 Times
	Then The light name should be "5 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep52_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "9 / 9."
	Given Click Left Arrow 4 Times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchNineLights
Scenario: VAN30519_TestStep53_Check the switch lights bar 4/9 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "9 / 9."
	Given Click Left Arrow 5 Times
	Then The light name should be "4 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep54_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "9 / 9."
	Given Click Left Arrow 5 Times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchNineLights
Scenario: VAN30519_TestStep55_Check the switch lights bar 3/9 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "9 / 9."
	Given Click Left Arrow 6 Times
	Then The light name should be "3 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep56_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "9 / 9."
	Given Click Left Arrow 6 Times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchNineLights
Scenario: VAN30519_TestStep57_Check the switch lights bar 2/9 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "9 / 9."
	Given Click Left Arrow 7 Times
	Then The light name should be "2 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep58_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "9 / 9."
	Given Click Left Arrow 7 Times
	Then The Left Arrow In The Switch Lights Bar Is "Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"

@LightingSwitchNineLights
Scenario: VAN30519_TestStep59_Check the switch lights bar 1/9 should be shown
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "9 / 9."
	Given Click Left Arrow 8 Times
	Then The light name should be "1 / 9."

@LightingSwitchNineLights
Scenario: VAN30519_TestStep60_Check the right arrow and Left arrow in the switch lights bar is clickable
	Given click the the customize
	Given Lighting page is opened
	Given select the profile 1
	When Set to default effect
	Then Click The "9 / 9."
	Given Click Left Arrow 8 Times
	Then The Left Arrow In The Switch Lights Bar Is "Grey And Cannot Be Clickable"
	Then The Right Arrow In The Switch Lights Bar Is "Clickable"