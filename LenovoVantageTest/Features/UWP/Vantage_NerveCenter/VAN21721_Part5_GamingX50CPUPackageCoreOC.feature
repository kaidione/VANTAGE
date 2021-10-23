Feature: VAN21721_Part5_GamingX50CPUPackageCoreOC
	Test Case： https://jira.tc.lenovo.com/browse/VAN-21721
	Author： Yang Liu

Background:
	Given Machine is Gaming 

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep63_Check the blocker on the slider bar should be at the far right
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 3 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far right' level 6
	Then Take Screen Shot VAN21721_TestStep63_BlockerFarRight in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep64_Check the value should be the maximum value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 3 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far right' level 6
	Then the 3 Active Core Ratio value should be the maximum value

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep65_check the '-'and '+'  icons in the value bar
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 3 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far right' level 6
	Then '+' icon 3 should be gery and unclickable
	Then '-' icon 3 should not be grey and clickable
	Then Take Screen Shot VAN21721_TestStep65_PlusMinusIcon in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep66_Check the blocker on the slider bar should be at the far left
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 3 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far left' level 6
	Then Take Screen Shot VAN21721_TestStep66_BlockerFarLeft in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep67_Check the value should be the minimize value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 3 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far left' level 6
	Then the 3 Active Core Ratio value should be the minimize value

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep68_check the '-'and '+'  icons in the value bar
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 3 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far left' level 6
	Then '-' icon 3 should be gery and unclickable
	Then '+' icon 3 should not be grey and clickable
	Then Take Screen Shot VAN21721_TestStep68_PlusMinusIcon in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep69_check the other Core Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 3 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far left' level 6
	Then '45678' Core Ratio items values after '3' core ratio should be consistent and is the minimum, the value '12' before is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep70_check the blocker on the slider bar and value bar
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 3 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 2
	Then Take Screen Shot VAN21721_TestStep70_Blocker in 21721 under GamingScreenShotResult
	Then the 3 core ratio value should be the currect value

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep71_check the '-'and '+'  icons in the value bar
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 3 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 2
	Then '+' icon 3 should not be grey and clickable
	Then '-' icon 3 should not be grey and clickable

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep72_check the other Core Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 3 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 2
	Then '12' Core Ratio items values before '3' core ratio should not be changed, the value '45678' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep73_check the other Core Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 3 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 6
	Then '12' Core Ratio items values before '3' core ratio should be consistent, the value '45678' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep74_check the 3 core ratio value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 3 core ratio / Active Core Ratio item, click the '-' icon
	Then the 3 core ratio value should be less than before

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep75_check the other Active Cores Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 3 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'left' level 0
	Given In the 3 core ratio / Active Core Ratio item, click the '-' icon
	Then '45678' Core Ratio items values after '3' core ratio should be consistent, the value '12' before is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep76_The other Core Ratio items values should not be changed
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 3 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 3
	Given In the 3 core ratio / Active Core Ratio item, click the '-' icon
	Then '12' Core Ratio items values before '3' core ratio should not be changed, the value '45678' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep77_the blocker should be to the left of its original position and position should be consistent with the value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 3 core ratio / Active Core Ratio item, click the '-' icon
	Then Take Screen Shot VAN21721_TestStep77_Blocker in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep78_the 3 core ratio value should be larger than before
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 3 core ratio / Active Core Ratio item, click the '+' icon
	Then the 3 core ratio value should be larger than before

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep79_check the other Active Cores Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 3 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 0
	Given In the 3 core ratio / Active Core Ratio item, click the '+' icon
	Then '12' Core Ratio items values before '3' core ratio should not be changed, the value '45678' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep80_check the other Active Cores Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 3 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 5
	Given In the 3 core ratio / Active Core Ratio item, click the '+' icon
	Then '12' Core Ratio items values before '3' core ratio should be consistent, the value '45678' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep81_the blocker should be to the right of its original position and position should be consistent with the value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 3 core ratio / Active Core Ratio item, click the '+' icon
	Then Take Screen Shot VAN21721_TestStep81_Blocker in 21721 under GamingScreenShotResult