Feature: VAN21721_Part10_GamingX50CPUPackageCoreOC
	Test Case： https://jira.tc.lenovo.com/browse/VAN-21721
	Author： Yang Liu

Background:
	Given Machine is Gaming 

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep158_Check the blocker on the slider bar should be at the far right
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 8 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far right' level 6
	Then Take Screen Shot VAN21721_TestStep158_BlockerFarRight in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep159_Check the value should be the maximum value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 8 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far right' level 6
	Then the 8 Active Core Ratio value should be the maximum value

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep160_check the '-'and '+'  icons in the value bar
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 8 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far right' level 6
	Then '+' icon 8 should be gery and unclickable
	Then '-' icon 8 should not be grey and clickable
	Then Take Screen Shot VAN21721_TestStep160_PlusMinusIcon in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep161_Check the blocker on the slider bar should be at the far left
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 8 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far left' level 6
	Then Take Screen Shot VAN21721_TestStep161_BlockerFarLeft in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep162_Check the value should be the minimize value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 8 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far left' level 6
	Then the 8 Active Core Ratio value should be the minimize value

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep163_check the '-'and '+'  icons in the value bar
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 8 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far left' level 6
	Then '-' icon 8 should be gery and unclickable
	Then '+' icon 8 should not be grey and clickable
	Then Take Screen Shot VAN21721_TestStep163_PlusMinusIcon in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep164_check the other Core Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 8 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'far left' level 6
	Then '0' Core Ratio items values after '8' core ratio should be consistent and is the minimum, the value '1234567' before is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep165_check the blocker on the slider bar and value bar
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 8 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 2
	Then Take Screen Shot VAN21721_TestStep165_Blocker in 21721 under GamingScreenShotResult
	Then the 8 core ratio value should be the currect value

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep166_check the '-'and '+'  icons in the value bar
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 8 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 2
	Then '+' icon 8 should not be grey and clickable
	Then '-' icon 8 should not be grey and clickable

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep167_check the other Core Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 8 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 1
	Then '1234567' Core Ratio items values before '8' core ratio should not be changed, the value '0' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep168_check the other Core Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 8 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 6
	Then '1234567' Core Ratio items values before '8' core ratio should be consistent, the value '0' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep169_check the 8 core ratio value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 8 core ratio / Active Core Ratio item, click the '-' icon
	Then the 8 core ratio value should be less than before

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep170_check the other Active Cores Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 8 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'left' level 0
	Given In the 8 core ratio / Active Core Ratio item, click the '-' icon
	Then '0' Core Ratio items values after '8' core ratio should be consistent, the value '1234567' before is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep171_The other Core Ratio items values should not be changed
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 8 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 2
	Given In the 8 core ratio / Active Core Ratio item, click the '-' icon
	Then '1234567' Core Ratio items values before '8' core ratio should not be changed, the value '0' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep172_the blocker should be to the left of its original position and position should be consistent with the value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 8 core ratio / Active Core Ratio item, click the '-' icon
	Then Take Screen Shot VAN21721_TestStep172_Blocker in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep173_the 8 core ratio value should be larger than before
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 8 core ratio / Active Core Ratio item, click the '+' icon
	Then the 8 core ratio value should be larger than before

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep174_check the other Active Cores Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 8 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 0
	Given In the 8 core ratio / Active Core Ratio item, click the '+' icon
	Then '1234567' Core Ratio items values before '8' core ratio should not be changed, the value '0' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep175_check the other Active Cores Ratio items values
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 8 core ratio / Active Core Ratio item, drag the blocker on the slider bar to the 'right' level 5
	Given In the 8 core ratio / Active Core Ratio item, click the '+' icon
	Then '1234567' Core Ratio items values before '8' core ratio should be consistent, the value '0' after is not change

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep176_the blocker should be to the right of its original position and position should be consistent with the value
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given In the 8 core ratio / Active Core Ratio item, click the '+' icon
	Then Take Screen Shot VAN21721_TestStep176_Blocker in 21721 under GamingScreenShotResult