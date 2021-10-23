Feature: VAN21721_Part4_GamingX50CPUPackageCoreOC
	Test Case： https://jira.tc.lenovo.com/browse/VAN-21721
	Author： Yang Liu

Background:
	Given Machine is Gaming 

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep44_Check the blocker on the slider bar should be at the far right
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 2 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far right' level 6
	Then Take Screen Shot VAN21721_TestStep44_BlockerFarRight in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep45_Check the value should be the maximum value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 2 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far right' level 6
	Then the 2 Active Core Ratio value should be the maximum value

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep46_check the '-'and '+'  icons in the value bar
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 2 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far right' level 6
	Then '+' icon 2 should be gery and unclickable
	Then '-' icon 2 should not be grey and clickable
	Then Take Screen Shot VAN21721_TestStep46_PlusMinusIcon in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep47_Check the blocker on the slider bar should be at the far left
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 2 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far left' level 6
	Then Take Screen Shot VAN21721_TestStep47_BlockerFarLeft in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep48_Check the value should be the minimize value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 2 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far left' level 6
	Then the 2 Active Core Ratio value should be the minimize value

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep49_check the '-'and '+'  icons in the value bar
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 2 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far left' level 6
	Then '-' icon 2 should be gery and unclickable
	Then '+' icon 2 should not be grey and clickable
	Then Take Screen Shot VAN21721_TestStep49_PlusMinusIcon in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep50_check the other Core Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 2 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far left' level 6
	Then '345678' Core Ratio items values after '2' core ratio should be consistent and is the minimum, the value '1' before is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep51_check the blocker on the slider bar and value bar
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 2 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 2
	Then Take Screen Shot VAN21721_TestStep51_Blocker in 21721 under GamingScreenShotResult
	Then the 2 core ratio value should be the currect value

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep52_check the '-'and '+'  icons in the value bar
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 2 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 2
	Then '+' icon 2 should not be grey and clickable
	Then '-' icon 2 should not be grey and clickable

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep53_check the other Core Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 2 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 2
	Then '1' Core Ratio items values before '2' core ratio should not be changed, the value '345678' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep54_check the other Core Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 2 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 6
	Then '1' Core Ratio items values before '2' core ratio should be consistent, the value '345678' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep55_check the 2 core ratio value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 2 core ratio / Active Core Ratio item, click the '-' icon
	Then the 2 core ratio value should be less than before

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep56_The other Core Ratio items values should be changed and consistent with 1 Active Core Ratio item
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 2 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'left' level 0
	Given In the 2 core ratio / Active Core Ratio item, click the '-' icon
	Then '345678' Core Ratio items values after '2' core ratio should be consistent, the value '1' before is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep57_The other Core Ratio items values should not be changed
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 2 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 3
	Given In the 2 core ratio / Active Core Ratio item, click the '-' icon
	Then '1' Core Ratio items values before '2' core ratio should not be changed, the value '345678' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep58_the blocker should be to the left of its original position and position should be consistent with the value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 2 core ratio / Active Core Ratio item, click the '-' icon
	Then Take Screen Shot VAN21721_TestStep58_Blocker in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep59_the 2 core ratio value should be larger than before
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 2 core ratio / Active Core Ratio item, click the '+' icon
	Then the 2 core ratio value should be larger than before

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep60_check the other Active Cores Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 2 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 0
	Given In the 2 core ratio / Active Core Ratio item, click the '+' icon
	Then '1' Core Ratio items values before '2' core ratio should not be changed, the value '345678' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep61_check the other Active Cores Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 2 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 5
	Given In the 2 core ratio / Active Core Ratio item, click the '+' icon
	Then '1' Core Ratio items values before '2' core ratio should be consistent, the value '345678' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep62_the blocker should be to the right of its original position and position should be consistent with the value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 2 core ratio / Active Core Ratio item, click the '+' icon
	Then Take Screen Shot VAN21721_TestStep62_Blocker in 21721 under GamingScreenShotResult
