Feature: VAN21721_Part7_GamingX50CPUPackageCoreOC
	Test Case： https://jira.tc.lenovo.com/browse/VAN-21721
	Author： Yang Liu

Background:
	Given Machine is Gaming 

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep101_Check the blocker on the slider bar should be at the far right
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 5 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far right' level 6
	Then Take Screen Shot VAN21721_TestStep101_BlockerFarRight in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep102_Check the value should be the maximum value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 5 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far right' level 6
	Then the 5 Active Core Ratio value should be the maximum value

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep103_check the '-'and '+'  icons in the value bar
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 5 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far right' level 6
	Then '+' icon 5 should be gery and unclickable
	Then '-' icon 5 should not be grey and clickable
	Then Take Screen Shot VAN21721_TestStep103_PlusMinusIcon in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep104_Check the blocker on the slider bar should be at the far left
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 5 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far left' level 6
	Then Take Screen Shot VAN21721_TestStep104_BlockerFarLeft in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep105_Check the value should be the minimize value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 5 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far left' level 6
	Then the 5 Active Core Ratio value should be the minimize value

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep106_check the '-'and '+'  icons in the value bar
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 5 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far left' level 6
	Then '-' icon 5 should be gery and unclickable
	Then '+' icon 5 should not be grey and clickable
	Then Take Screen Shot VAN21721_TestStep106_PlusMinusIcon in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep107_check the other Core Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 5 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far left' level 6
	Then '678' Core Ratio items values after '5' core ratio should be consistent and is the minimum, the value '1234' before is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep108_check the blocker on the slider bar and value bar
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 5 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 2
	Then Take Screen Shot VAN21721_TestStep108_Blocker in 21721 under GamingScreenShotResult
	Then the 5 core ratio value should be the currect value

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep109_check the '-'and '+'  icons in the value bar
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 5 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 2
	Then '+' icon 5 should not be grey and clickable
	Then '-' icon 5 should not be grey and clickable

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep110_check the other Core Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 5 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 1
	Then '1234' Core Ratio items values before '5' core ratio should not be changed, the value '678' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep111_check the other Core Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 5 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 6
	Then '1234' Core Ratio items values before '5' core ratio should be consistent, the value '678' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep112_check the 5 core ratio value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 5 core ratio / Active Core Ratio item, click the '-' icon
	Then the 5 core ratio value should be less than before

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep113_check the other Active Cores Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 5 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'left' level 0
	Given In the 5 core ratio / Active Core Ratio item, click the '-' icon
	Then '678' Core Ratio items values after '5' core ratio should be consistent, the value '1234' before is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep114_The other Core Ratio items values should not be changed
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 5 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 2
	Given In the 5 core ratio / Active Core Ratio item, click the '-' icon
	Then '1234' Core Ratio items values before '5' core ratio should not be changed, the value '678' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep115_the blocker should be to the left of its original position and position should be consistent with the value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 5 core ratio / Active Core Ratio item, click the '-' icon
	Then Take Screen Shot VAN21721_TestStep115_Blocker in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep116_the 5 core ratio value should be larger than before
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 5 core ratio / Active Core Ratio item, click the '+' icon
	Then the 5 core ratio value should be larger than before

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep117_check the other Active Cores Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 5 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 0
	Given In the 5 core ratio / Active Core Ratio item, click the '+' icon
	Then '1234' Core Ratio items values before '5' core ratio should not be changed, the value '678' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep118_check the other Active Cores Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 5 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 5
	Given In the 5 core ratio / Active Core Ratio item, click the '+' icon
	Then '1234' Core Ratio items values before '5' core ratio should be consistent, the value '678' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep119_the blocker should be to the right of its original position and position should be consistent with the value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 5 core ratio / Active Core Ratio item, click the '+' icon
	Then Take Screen Shot VAN21721_TestStep119_Blocker in 21721 under GamingScreenShotResult
