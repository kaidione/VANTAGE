Feature: VAN21720_GamingX50CPUOCOtherItems
	Test Case： https://jira.tc.lenovo.com/browse/VAN-21720
	Author： Yang Liu

Background:
	Given Machine is Gaming 
	Given Machine is Y750 or Y750S or T750
	#Given Change T750 DPI to 125
	When Install 'GPU/CPU' Driver
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep00_Change Gaming Machine DPI
	Given Change Gaming Machine T750 DPI to 100

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep01_check the Core Voltage offset blocker on the slider bar
	Given In the 'Core Voltage offset' item, drag the blocker on the slider bar to the 'far right' level 16
	Then Take Screen Shot VAN21720_TestStep01_CoreVoltageOffsetBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep02_the Core Voltage offset value should be the maximum value
	Given In the 'Core Voltage offset' item, drag the blocker on the slider bar to the 'far right' level 16
	Then the 'Core Voltage offset' value should be the maximum value

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep03_check the '-'and '+'  icons in the value bar
	Given In the 'Core Voltage offset' item, drag the blocker on the slider bar to the 'far right' level 16
	Then '+' icon should be gery and unclickable for 'Core Voltage offset'
	Then '-' icon should not be grey and clickable for 'Core Voltage offset'
	Then Take Screen Shot VAN21720_TestStep03_CoreVoltageOffsetPlusMinusIcon in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep04_The blocker on the slider bar should be at the far left
	Given In the 'Core Voltage offset' item, drag the blocker on the slider bar to the 'far left' level 16
	Then Take Screen Shot VAN21720_TestStep04_CoreVoltageOffsetPlusBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep05_the Core Voltage Offset value should be the minimize value
	Given In the 'Core Voltage offset' item, drag the blocker on the slider bar to the 'far left' level 16
	Then the 'Core Voltage offset' value should be the minimize value

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep06_check the '-'and '+'  icons in the value bar
	Given In the 'Core Voltage offset' item, drag the blocker on the slider bar to the 'far left' level 16
	Then '-' icon should be gery and unclickable for 'Core Voltage offset'
	Then '+' icon should not be grey and clickable for 'Core Voltage offset'
	Then Take Screen Shot VAN21720_TestStep06_CoreVoltageOffsetPlusMinusIcon in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep07_check the blocker on the slider bar and value bar
	Given In the 'Core Voltage offset' item, drag the blocker on the slider bar to the 'right' level 2
	Then Take Screen Shot VAN21720_TestStep07_CoreVoltageOffsetBlocker in 21720 under GamingScreenShotResult
	Then the 'Core Voltage offset' value should be the current value

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep08_check the '-'and '+'  icons in the value bar
	Given In the 'Core Voltage offset' item, drag the blocker on the slider bar to the 'right' level 2
	Then '+' icon should not be grey and clickable for 'Core Voltage offset'
	Then '-' icon should not be grey and clickable for 'Core Voltage offset'

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep09_the Core Voltage offset value should be less than before
	Given In the 'Core Voltage offset' item, drag the blocker on the slider bar to the 'right' level 0
	Given In the 'Core Voltage offset' item, click the '-' icon
	Then the 'Core Voltage offset' value should be less than before

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep10_check the Core Voltage offset blocker on the slider bar
	Given In the 'Core Voltage offset' item, click the '-' icon
	Then Take Screen Shot VAN21720_TestStep10_CoreVoltageOffsetBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep11_the Core Voltage offset value should be larger than before
	Given In the 'Core Voltage offset' item, click the '+' icon
	Then the 'Core Voltage offset' value should be larger than before

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep12_check the the blocker on the slider bar
	Given In the 'Core Voltage offset' item, click the '+' icon
	Then Take Screen Shot VAN21720_TestStep12_CoreVoltageOffsetBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep13_check the Cache Core Voltage offset item value
	Given In the 'Core Voltage offset' item, drag the blocker on the slider bar to the 'right' level 2
	Then check the Cache Core Voltage offset item value should be consistent

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep14_check the Core ICCMAX blocker on the slider bar
	When Scroll the screen in Overclock Advanced Settings subpage
	Given In the 'Core ICCMAX' item, drag the blocker on the slider bar to the 'far right' level 112
	Then Take Screen Shot VAN21720_TestStep14_CoreICCMAXBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep15_the Core ICCMAX value should be the maximum value
	Given In the 'Core ICCMAX' item, drag the blocker on the slider bar to the 'far right' level 112
	Then the 'Core ICCMAX' value should be the maximum value

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep16_check the '-'and '+'  icons in the value bar
	Given In the 'Core ICCMAX' item, drag the blocker on the slider bar to the 'far right' level 112
	Then '+' icon should be gery and unclickable for 'Core ICCMAX'
	Then '-' icon should not be grey and clickable for 'Core ICCMAX'
	Then Take Screen Shot VAN21720_TestStep16_CoreICCMAXPlusMinusIcon in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep17_The blocker on the slider bar should be at the far left
	Given In the 'Core ICCMAX' item, drag the blocker on the slider bar to the 'far left' level 111
	Then Take Screen Shot VAN21720_TestStep17_CoreICCMAXPlusBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep18_the Core ICCMAX value should be the minimize value
	Given In the 'Core ICCMAX' item, drag the blocker on the slider bar to the 'far left' level 111
	Then the 'Core ICCMAX' value should be the minimize value

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep19_check the '-'and '+'  icons in the value bar
	Given In the 'Core ICCMAX' item, click the '-' icon level 223
	Then '-' icon should be gery and unclickable for 'Core ICCMAX'
	Then '+' icon should not be grey and clickable for 'Core ICCMAX'
	Then Take Screen Shot VAN21720_TestStep19_CoreICCMAXPlusMinusIcon in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep20_check the '-'and '+'  icons in the value bar
	Given In the 'Core ICCMAX' item, drag the blocker on the slider bar to the 'far left' level 111
	Then '-' icon should be gery and unclickable for 'Core ICCMAX'
	Then '+' icon should not be grey and clickable for 'Core ICCMAX'
	Then Take Screen Shot VAN21720_TestStep20_CoreICCMAXPlusMinusIcon in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep21_check the blocker on the slider bar and value bar
	Given In the 'Core ICCMAX' item, drag the blocker on the slider bar to the 'right' level 2
	Then Take Screen Shot VAN21720_TestStep21_CoreICCMAXBlocker in 21720 under GamingScreenShotResult
	Then the 'Core ICCMAX' value should be the current value

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep22_check the '-'and '+'  icons in the value bar
	Given In the 'Core ICCMAX' item, drag the blocker on the slider bar to the 'right' level 2
	Then '+' icon should not be grey and clickable for 'Core ICCMAX'
	Then '-' icon should not be grey and clickable for 'Core ICCMAX'

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep23_the Core ICCMAX value should be less than before
	Given In the 'Core ICCMAX' item, drag the blocker on the slider bar to the 'right' level 0
	When Click '1' Times The '-' Icon In The 'Core ICCMAX' Item
	Then The Value Should Be 'less' Than Before

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep24_check the Core ICCMAX blocker on the slider bar
	When Click '1' Times The '-' Icon In The 'Core ICCMAX' Item
	Then Take Screen Shot VAN21720_TestStep24_CoreICCMAXBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep25_the Core ICCMAX value should be larger than before
	Given In the 'Core ICCMAX' item, drag the blocker on the slider bar to the 'right' level 0
	When Click '1' Times The '+' Icon In The 'Core ICCMAX' Item
	Then The Value Should Be 'larger' Than Before

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep26_check the the blocker on the slider bar
	Given In the 'Core ICCMAX' item, drag the blocker on the slider bar to the 'right' level 0
	When Click '1' Times The '+' Icon In The 'Core ICCMAX' Item
	Then Take Screen Shot VAN21720_TestStep26_CoreICCMAXBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep27_check the Cache Core ICCMAX item value
	Given In the 'Core ICCMAX' item, drag the blocker on the slider bar to the 'right' level 2
	Then check the Cache Core ICCMAX item value should be consistent

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep28_check the AVX Ratio offset blocker on the slider bar
	Given In the 'AVX Ratio offset' item, drag the blocker on the slider bar to the 'far right' level 16
	Then Take Screen Shot VAN21720_TestStep28_AVXRatioOffsetBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep29_the AVX Ratio offset value should be the maximum value
	Given In the 'AVX Ratio offset' item, drag the blocker on the slider bar to the 'far right' level 16
	Then the 'AVX Ratio offset' value should be the maximum value

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep30_check the '-'and '+'  icons in the value bar
	Given In the 'AVX Ratio offset' item, drag the blocker on the slider bar to the 'far right' level 16
	Then '+' icon should be gery and unclickable for 'AVX Ratio offset'
	Then '-' icon should not be grey and clickable for 'AVX Ratio offset'
	Then Take Screen Shot VAN21720_TestStep30_AVXRatioOffsetPlusMinusIcon in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep31_The blocker on the slider bar should be at the far left
	Given In the 'AVX Ratio offset' item, drag the blocker on the slider bar to the 'far left' level 16
	Then Take Screen Shot VAN21720_TestStep31_AVXRatioOffsetMinusBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep32_the AVX Ratio Offset value should be the minimize value
	Given In the 'AVX Ratio offset' item, drag the blocker on the slider bar to the 'far left' level 16
	Then the 'AVX Ratio offset' value should be the minimize value

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep33_check the '-'and '+'  icons in the value bar
	Given In the 'AVX Ratio offset' item, drag the blocker on the slider bar to the 'far left' level 16
	Then '-' icon should be gery and unclickable for 'AVX Ratio offset'
	Then '+' icon should not be grey and clickable for 'AVX Ratio offset'
	Then Take Screen Shot VAN21720_TestStep33_AVXRatioOffsetPlusMinusIcon in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep34_check the blocker on the slider bar and value bar
	Given In the 'AVX Ratio offset' item, drag the blocker on the slider bar to the 'right' level 2
	Then Take Screen Shot VAN21720_TestStep34_AVXRatioOffsetBlocker in 21720 under GamingScreenShotResult
	Then the 'AVX Ratio offset' value should be the current value

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep35_check the '-'and '+'  icons in the value bar
	Given In the 'AVX Ratio offset' item, drag the blocker on the slider bar to the 'right' level 2
	Then '+' icon should not be grey and clickable for 'AVX Ratio offset'
	Then '-' icon should not be grey and clickable for 'AVX Ratio offset'

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep36_the AVX Ratio offset value should be less than before
	When Click '1' Times The '-' Icon In The 'AVX Ratio offset' Item
	Then The Value Should Be 'less' Than Before

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep37_check the AVX Ratio offset blocker on the slider bar
	When Click '1' Times The '-' Icon In The 'AVX Ratio offset' Item
	Then Take Screen Shot VAN21720_TestStep37_AVXRatioOffsetBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep38_the AVX Ratio offset value should be larger than before
	When Click '1' Times The '+' Icon In The 'AVX Ratio offset' Item
	Then The Value Should Be 'larger' Than Before

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep39_check the the blocker on the slider bar
	When Click '1' Times The '+' Icon In The 'AVX Ratio offset' Item
	Then Take Screen Shot VAN21720_TestStep39_AVXRatioOffsetBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep40_check the Cache Ratio blocker on the slider bar and value bar
	Given In the 'Cache Ratio' item, drag the blocker on the slider bar to the 'far right' level 12
	Then Take Screen Shot VAN21720_TestStep40_AVXRatioOffsetBlocker in 21720 under GamingScreenShotResult
	Then the 'Cache Ratio' value should be the maximum value

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep41_check the '-' and '+'  icons in the value bar
	Given In the 'Cache Ratio' item, drag the blocker on the slider bar to the 'far right' level 12
	When Scroll the screen in Overclock Advanced Settings subpage
	Then '+' icon should be gery and unclickable for 'Cache Ratio'
	Then '-' icon should not be grey and clickable for 'Cache Ratio'
	Then Take Screen Shot VAN21720_TestStep41_CacheRatioPlusMinusIcon in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep42_The blocker on the slider bar should be at the far left
	Given In the 'Cache Ratio' item, drag the blocker on the slider bar to the 'far left' level 12
	When Scroll the screen in Overclock Advanced Settings subpage
	Then Take Screen Shot VAN21720_TestStep42_CacheRatioMinusBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep43_the Cache Ratio value should be the minimize value
	Given In the 'Cache Ratio' item, drag the blocker on the slider bar to the 'far left' level 12
	Then the 'Cache Ratio' value should be the minimize value

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep44_check the '-'and '+'  icons in the value bar
	Given In the 'Cache Ratio' item, drag the blocker on the slider bar to the 'far left' level 12
	When Scroll the screen in Overclock Advanced Settings subpage
	Then '-' icon should be gery and unclickable for 'Cache Ratio'
	Then '+' icon should not be grey and clickable for 'Cache Ratio'
	Then Take Screen Shot VAN21720_TestStep44_CacheRatioPlusMinusIcon in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep45_check the blocker on the slider bar
	Given In the 'Cache Ratio' item, drag the blocker on the slider bar to the 'right' level 2
	When Scroll the screen in Overclock Advanced Settings subpage
	Then Take Screen Shot VAN21720_TestStep45_CacheRatioBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep46_check the Cache Ratio value bar
	Given In the 'Cache Ratio' item, drag the blocker on the slider bar to the 'right' level 2
	Then the 'Cache Ratio' value should be the current value

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep47_check the '-' and '+'  icons in the value bar
	Given In the 'Cache Ratio' item, drag the blocker on the slider bar to the 'right' level 2
	Then '+' icon should not be grey and clickable for 'Cache Ratio'
	Then '-' icon should not be grey and clickable for 'Cache Ratio'

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep48_the Cache Ratio value should be less than before
	When Click '1' Times The '-' Icon In The 'Cache Ratio' Item
	Then The Value Should Be 'less' Than Before

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep49_check the Cache Ratio blocker on the slider bar
	When Click '1' Times The '-' Icon In The 'Cache Ratio' Item
	When Scroll the screen in Overclock Advanced Settings subpage
	Then Take Screen Shot VAN21720_TestStep49_CacheRatioBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep50_the Cache Ratio value should be larger than before
	When Click '1' Times The '+' Icon In The 'Cache Ratio' Item
	Then The Value Should Be 'larger' Than Before

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep51_check the the blocker on the slider bar
	When Click '1' Times The '+' Icon In The 'Cache Ratio' Item
	When Scroll the screen in Overclock Advanced Settings subpage
	Then Take Screen Shot VAN21720_TestStep51_CacheRatioBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep52_check the Cache Voltage blocker on the slider bar
	When Scroll the screen in Overclock Advanced Settings subpage
	Given In the 'Cache Voltage' item, drag the blocker on the slider bar to the 'far right' level 46
	Then Take Screen Shot VAN21720_TestStep52_CacheVoltageBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep53_the Cache Voltage value should be the maximum value
	When Scroll the screen in Overclock Advanced Settings subpage
	Given In the 'Cache Voltage' item, drag the blocker on the slider bar to the 'far right' level 46
	Then the 'Cache Voltage' value should be the maximum value

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep54_check the '-' and '+'  icons in the value bar
	Given In the 'Cache Voltage' item, drag the blocker on the slider bar to the 'far right' level 46
	When Scroll the screen in Overclock Advanced Settings subpage
	Then '+' icon should be gery and unclickable for 'Cache Voltage'
	Then '-' icon should not be grey and clickable for 'Cache Voltage'
	Then Take Screen Shot VAN21720_TestStep54_CacheVoltagePlusMinusIcon in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep55_The blocker on the slider bar should be at the far left
	Given In the 'Cache Voltage' item, drag the blocker on the slider bar to the 'far left' level 46
	When Scroll the screen in Overclock Advanced Settings subpage
	Then Take Screen Shot VAN21720_TestStep55_CacheVoltageMinusBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep56_the Cache Voltage value should be the minimize value
	When Scroll the screen in Overclock Advanced Settings subpage
	Given In the 'Cache Voltage' item, drag the blocker on the slider bar to the 'far left' level 46
	Then the 'Cache Voltage' value should be the minimize value

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep57_check the '-'and '+'  icons in the value bar
	Given In the 'Cache Voltage' item, drag the blocker on the slider bar to the 'far left' level 46
	When Scroll the screen in Overclock Advanced Settings subpage
	Then '-' icon should be gery and unclickable for 'Cache Voltage'
	Then '+' icon should not be grey and clickable for 'Cache Voltage'
	Then Take Screen Shot VAN21720_TestStep57_CacheVoltagePlusMinusIcon in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep58_check the blocker on the slider bar and value bar
	Given In the 'Cache Voltage' item, drag the blocker on the slider bar to the 'right' level 2
	When Scroll the screen in Overclock Advanced Settings subpage
	Then Take Screen Shot VAN21720_TestStep58_CacheVoltageBlocker in 21720 under GamingScreenShotResult
	Then the 'Cache Voltage' value should be the current value

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep59_check the '-' and '+'  icons in the value bar
	Given In the 'Cache Voltage' item, drag the blocker on the slider bar to the 'right' level 2
	Then '+' icon should not be grey and clickable for 'Cache Voltage'
	Then '-' icon should not be grey and clickable for 'Cache Voltage'

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep60_the Cache Voltage value should be less than before
	When Click '1' Times The '-' Icon In The 'Cache Voltage' Item
	Then The Value Should Be 'less' Than Before

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep61_check the Cache Voltage blocker on the slider bar
	When Click '1' Times The '-' Icon In The 'Cache Voltage' Item
	When Scroll the screen in Overclock Advanced Settings subpage
	Then Take Screen Shot VAN21720_TestStep61_CacheVoltageBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep62_the Cache Voltage value should be larger than before
	When Click '1' Times The '+' Icon In The 'Cache Voltage' Item
	Then The Value Should Be 'larger' Than Before

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep63_check the the blocker on the slider bar
	When Click '1' Times The '+' Icon In The 'Cache Voltage' Item
	When Scroll the screen in Overclock Advanced Settings subpage
	Then Take Screen Shot VAN21720_TestStep63_CacheVoltageBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep64_check the Cache Core Voltage item value
	Given In the 'Cache Voltage' item, drag the blocker on the slider bar to the 'right' level 2
	Then check the Cache Core Voltage item value should be consistent

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep65_check the Cache Voltage offset blocker on the slider bar
	Given In the 'Cache Voltage offset' item, drag the blocker on the slider bar to the 'far right' level 16
	When Scroll the screen in Overclock Advanced Settings subpage
	Then Take Screen Shot VAN21720_TestStep65_CacheVoltageOffsetBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep66_the Cache Voltage offset value should be the maximum value
	Given In the 'Cache Voltage offset' item, drag the blocker on the slider bar to the 'far right' level 16
	Then the 'Cache Voltage offset' value should be the maximum value

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep67_check the '-' and '+'  icons in the value bar
	Given In the 'Cache Voltage offset' item, drag the blocker on the slider bar to the 'far right' level 16
	When Scroll the screen in Overclock Advanced Settings subpage
	Then '+' icon should be gery and unclickable for 'Cache Voltage offset'
	Then '-' icon should not be grey and clickable for 'Cache Voltage offset'
	Then Take Screen Shot VAN21720_TestStep67_CacheVoltageOffsetPlusMinusIcon in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep68_check the blocker on the slider bar and value bar
	Given In the 'Cache Voltage offset' item, drag the blocker on the slider bar to the 'far left' level 16
	When Scroll the screen in Overclock Advanced Settings subpage
	Then Take Screen Shot VAN21720_TestStep68_CacheVoltageOffsetPlusBlocker in 21720 under GamingScreenShotResult
	Then the 'Cache Voltage offset' value should be the minimize value

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep69_check the '-' and '+'  icons in the value bar
	Given In the 'Cache Voltage offset' item, drag the blocker on the slider bar to the 'far left' level 16
	When Scroll the screen in Overclock Advanced Settings subpage
	Then '-' icon should be gery and unclickable for 'Cache Voltage offset'
	Then '+' icon should not be grey and clickable for 'Cache Voltage offset'
	Then Take Screen Shot VAN21720_TestStep69_CacheVoltageOffsetPlusMinusIcon in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep70_check the blocker on the slider bar
	Given In the 'Cache Voltage offset' item, drag the blocker on the slider bar to the 'right' level 2
	When Scroll the screen in Overclock Advanced Settings subpage
	Then Take Screen Shot VAN21720_TestStep70_CacheVoltageOffsetBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep71_check the Cache Voltage offset value bar
	Given In the 'Cache Voltage offset' item, drag the blocker on the slider bar to the 'right' level 2
	Then the 'Cache Voltage offset' value should be the current value

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep72_check the '-' and '+'  icons in the value bar
	Given In the 'Cache Voltage offset' item, drag the blocker on the slider bar to the 'right' level 2
	Then '+' icon should not be grey and clickable for 'Cache Voltage offset'
	Then '-' icon should not be grey and clickable for 'Cache Voltage offset'

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep73_the Cache Voltage offset value should be less than before
	Given In the 'Cache Voltage offset' item, drag the blocker on the slider bar to the 'right' level 0
	When Click '1' Times The '-' Icon In The 'Cache Voltage offset' Item
	Then The Value Should Be 'less' Than Before

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep74_check the Cache Voltage offset blocker on the slider bar
	When Click '1' Times The '-' Icon In The 'Cache Voltage offset' Item
	When Scroll the screen in Overclock Advanced Settings subpage
	Then Take Screen Shot VAN21720_TestStep74_CacheVoltageOffsetBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep75_the Cache Voltage offset value should be larger than before
	When Click '1' Times The '+' Icon In The 'Cache Voltage offset' Item
	Then The Value Should Be 'larger' Than Before

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep76_check the the blocker on the slider bar
	When Click '1' Times The '+' Icon In The 'Cache Voltage offset' Item
	When Scroll the screen in Overclock Advanced Settings subpage
	Then Take Screen Shot VAN21720_TestStep76_CacheVoltageOffsetBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItems
Scenario: VAN21720_TestStep77_check the Cache Core Voltage offset item value
	Given In the 'Cache Voltage offset' item, drag the blocker on the slider bar to the 'right' level 2
	Then check the Cache Core Voltage offset item value should be consistent

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep78_check the Cache ICCMAX blocker on the slider bar
	When Scroll the screen in Overclock Advanced Settings subpage
	Given In the 'Cache ICCMAX' item, drag the blocker on the slider bar to the 'far right' level 112
	Then Take Screen Shot VAN21720_TestStep78_CacheICCMAXBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep79_the Cache ICCMAX value should be the maximum value
	Given In the 'Cache ICCMAX' item, drag the blocker on the slider bar to the 'far right' level 112
	Then the 'Cache ICCMAX' value should be the maximum value

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep80_check the '-'and '+'  icons in the value bar
	Given In the 'Cache ICCMAX' item, drag the blocker on the slider bar to the 'far right' level 112
	When Scroll the screen in Overclock Advanced Settings subpage
	Then '+' icon should be gery and unclickable for 'Cache ICCMAX'
	Then '-' icon should not be grey and clickable for 'Cache ICCMAX'
	Then Take Screen Shot VAN21720_TestStep80_CacheICCMAXPlusMinusIcon in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep81_The blocker on the slider bar should be at the far left
	When Scroll the screen in Overclock Advanced Settings subpage
	Given In the 'Cache ICCMAX' item, drag the blocker on the slider bar to the 'far left' level 111
	Then Take Screen Shot VAN21720_TestStep81_CacheICCMAXMinusBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep82_the Cache ICCMAX value should be the minimize value
	Given In the 'Cache ICCMAX' item, drag the blocker on the slider bar to the 'far left' level 111
	Then the 'Cache ICCMAX' value should be the minimize value

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep83_check the '-'and '+'  icons in the value bar
	Given In the 'Cache ICCMAX' item, drag the blocker on the slider bar to the 'far left' level 111
	When Scroll the screen in Overclock Advanced Settings subpage
	Then '-' icon should be gery and unclickable for 'Cache ICCMAX'
	Then '+' icon should not be grey and clickable for 'Cache ICCMAX'
	Then Take Screen Shot VAN21720_TestStep83_CacheICCMAXPlusMinusIcon in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep84_check the blocker on the slider bar and value bar
	When Scroll the screen in Overclock Advanced Settings subpage
	Given In the 'Cache ICCMAX' item, drag the blocker on the slider bar to the 'right' level 2
	Then Take Screen Shot VAN21720_TestStep84_CacheICCMAXBlocker in 21720 under GamingScreenShotResult
	Then the 'Cache ICCMAX' value should be the current value

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep85_check the '-' and '+'  icons in the value bar
	Given In the 'Cache ICCMAX' item, drag the blocker on the slider bar to the 'right' level 2
	Then '+' icon should not be grey and clickable for 'Cache ICCMAX'
	Then '-' icon should not be grey and clickable for 'Cache ICCMAX'

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep86_the Cache ICCMAX value should be less than before
	Given In the 'Cache ICCMAX' item, drag the blocker on the slider bar to the 'right' level 0
	When Click '1' Times The '-' Icon In The 'Cache ICCMAX' Item
	Then The Value Should Be 'less' Than Before

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep87_check the '-'and '+'  icons in the value bar
	When Click '1' Times The '-' Icon In The 'Cache ICCMAX' Item
	Then '+' icon should not be grey and clickable for 'Cache ICCMAX'
	Then '-' icon should not be grey and clickable for 'Cache ICCMAX'

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep88_the Cache ICCMAX value should be larger than before
	Given In the 'Cache ICCMAX' item, drag the blocker on the slider bar to the 'right' level 0
	When Click '1' Times The '+' Icon In The 'Cache ICCMAX' Item
	Then The Value Should Be 'larger' Than Before

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep89_check the blocker on the slider bar
	When Scroll the screen in Overclock Advanced Settings subpage
	Given In the 'Cache ICCMAX' item, drag the blocker on the slider bar to the 'right' level 0
	When Click '1' Times The '+' Icon In The 'Cache ICCMAX' Item
	Then Take Screen Shot VAN21720_TestStep89_CacheICCMAXBlocker in 21720 under GamingScreenShotResult

@GamingX50CPUOCOtherItemsT750
Scenario: VAN21720_TestStep90_check the Cache Core ICCMAX item value
	Given In the 'Cache ICCMAX' item, drag the blocker on the slider bar to the 'right' level 2
	Then check the Cache Core ICCMAX item value should be consistent