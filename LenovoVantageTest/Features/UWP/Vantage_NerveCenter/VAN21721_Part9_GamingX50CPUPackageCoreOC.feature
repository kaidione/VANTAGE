Feature: VAN21721_Part9_GamingX50CPUPackageCoreOC
	Test Case： https://jira.tc.lenovo.com/browse/VAN-21721
	Author： Yang Liu

Background:
	Given Machine is Gaming 

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep139_Check the blocker on the slider bar should be at the far right
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 7 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far right' level 6
	Then Take Screen Shot VAN21721_TestStep139_BlockerFarRight in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep140_Check the value should be the maximum value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 7 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far right' level 6
	Then the 7 Active Core Ratio value should be the maximum value

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep141_check the '-'and '+'  icons in the value bar
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 7 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far right' level 6
	Then '+' icon 7 should be gery and unclickable
	Then '-' icon 7 should not be grey and clickable
	Then Take Screen Shot VAN21721_TestStep141_PlusMinusIcon in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep142_Check the blocker on the slider bar should be at the far left
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 7 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far left' level 6
	Then Take Screen Shot VAN21721_TestStep142_BlockerFarLeft in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep143_Check the value should be the minimize value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 7 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far left' level 6
	Then the 7 Active Core Ratio value should be the minimize value

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep144_check the '-'and '+'  icons in the value bar
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 7 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far left' level 6
	Then '-' icon 7 should be gery and unclickable
	Then '+' icon 7 should not be grey and clickable
	Then Take Screen Shot VAN21721_TestStep144_PlusMinusIcon in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep145_check the other Core Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 7 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far left' level 6
	Then '8' Core Ratio items values after '7' core ratio should be consistent and is the minimum, the value '123456' before is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep146_check the blocker on the slider bar and value bar
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 7 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 2
	Then Take Screen Shot VAN21721_TestStep146_Blocker in 21721 under GamingScreenShotResult
	Then the 7 core ratio value should be the currect value

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep147_check the '-'and '+'  icons in the value bar
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 7 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 2
	Then '+' icon 7 should not be grey and clickable
	Then '-' icon 7 should not be grey and clickable

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep148_check the other Core Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 7 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 1
	Then '123456' Core Ratio items values before '7' core ratio should not be changed, the value '8' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep149_check the other Core Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 7 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 6
	Then '123456' Core Ratio items values before '7' core ratio should be consistent, the value '8' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep150_check the 7 core ratio value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 7 core ratio / Active Core Ratio item, click the '-' icon
	Then the 7 core ratio value should be less than before

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep151_check the other Active Cores Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 7 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'left' level 0
	Given In the 7 core ratio / Active Core Ratio item, click the '-' icon
	Then '8' Core Ratio items values after '7' core ratio should be consistent, the value '123456' before is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep152_The other Core Ratio items values should not be changed
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 7 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 2
	Given In the 7 core ratio / Active Core Ratio item, click the '-' icon
	Then '123456' Core Ratio items values before '7' core ratio should not be changed, the value '8' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep153_the blocker should be to the left of its original position and position should be consistent with the value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 7 core ratio / Active Core Ratio item, click the '-' icon
	Then Take Screen Shot VAN21721_TestStep153_Blocker in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep154_the 7 core ratio value should be larger than before
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 7 core ratio / Active Core Ratio item, click the '+' icon
	Then the 7 core ratio value should be larger than before

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep155_check the other Active Cores Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 7 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 0
	Given In the 7 core ratio / Active Core Ratio item, click the '+' icon
	Then '123456' Core Ratio items values before '7' core ratio should not be changed, the value '8' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep156_check the other Active Cores Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 7 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 5
	Given In the 7 core ratio / Active Core Ratio item, click the '+' icon
	Then '123456' Core Ratio items values before '7' core ratio should be consistent, the value '8' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep157_the blocker should be to the right of its original position and position should be consistent with the value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 7 core ratio / Active Core Ratio item, click the '+' icon
	Then Take Screen Shot VAN21721_TestStep157_Blocker in 21721 under GamingScreenShotResult
