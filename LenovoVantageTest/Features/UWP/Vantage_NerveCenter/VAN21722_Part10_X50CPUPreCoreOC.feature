Feature: VAN21722_Part10_X50CPUPreCoreOC
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-19762
	Author： Pengjie Chen

Background: 
	Given Machine is Gaming
	Given The Machine is X Series 'X50'
	Given The Machine Type is DT or NB 'DT'
	Given The Machine support Specific function 'CPUGPUOverclockNew'
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep190_Check click 9 Core Ratio plus icon and the value should be larger than before
	When user hover specific title in the CPU Overclock area '9 Core Ratio'
	When user click '1' times '9 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then the value should be less or larger than before in the CPU Overclock area 'larger'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep191_Check click 9 Core Ratio plus icon and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '9 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '2' times '9 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | no           |
	| 2 Core Ratio  | no           |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | no           |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | yes          |
	| 10 Core Ratio | no           |  

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep192_Check drag the 9 Core Ratio blocker on the slider bar to the right and 9 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '9 Core Ratio'
	When user drag the '9 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 9_Core_Ratio_Slider_right_before_TestStep192 in 21722 under X50CPUPreCoreOC
	When user click '3' times '9 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then Take Screen Shot 9_Core_Ratio_Slider_right_after_TestStep192 in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'larger'
	Then The '9 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '49'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep193_Check 10 Core Ratio Slider on the slider bar should be at the far right
	When user hover specific title in the CPU Overclock area '10 Core Ratio'
	When user drag the '10 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then Take Screen Shot 10_Core_Ratio_Slider_Right_TestStep193  in 21722 under X50CPUPreCoreOC
	Then The '10 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'
	
@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep194_Check 10 Core Ratio Slider MaxValue is 52
	When user hover specific title in the CPU Overclock area '10 Core Ratio'
	When user drag the '10 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then The '10 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep195_Check 10 Core Ratio Slider MaxValue is 52 and plus icon unclickable and minus icon clickable
	When user hover specific title in the CPU Overclock area '10 Core Ratio'
	When user drag the '10 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then The '10 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'
	Then The '10 Core Ratio' plus icon status 'unclickable'or minus icon status 'clickable' in the CPU Overclock area

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep196_Check 10 Core Ratio Slider on the slider bar should be at the far left
	When user hover specific title in the CPU Overclock area '10 Core Ratio'
	When user drag the '10 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 10_Core_Ratio_Slider_Left_TestStep196  in 21722 under X50CPUPreCoreOC
	Then The '10 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep197_Check 10 Core Ratio Slider MinValue is 46
	When user hover specific title in the CPU Overclock area '10 Core Ratio'
	When user drag the '10 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then The '10 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep198_Check 10 Core Ratio Slider MinValue is 46 and plus icon clickable and minus icon unclickable
	When user hover specific title in the CPU Overclock area '10 Core Ratio'
	When user drag the '10 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then The '10 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'
	Then The '10 Core Ratio' plus icon status 'clickable'or minus icon status 'unclickable' in the CPU Overclock area 

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep199_Check 10 Core Ratio Slider MinValue is 46 and the other Core Ratio items values should not be changed.
	When user hover specific title in the CPU Overclock area '10 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user drag the '10 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | no           |
	| 2 Core Ratio  | no           |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | no           |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | yes          |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep200_Check drag the 10 Core Ratio blocker on the slider bar to the right and 10 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '10 Core Ratio'
	When user drag the '10 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 10_Core_Ratio_Slider_right_before_TestStep200 in 21722 under X50CPUPreCoreOC
	When user drag the '10 Core Ratio' blocker on the slider bar to the specific location '3' in the CPU Overclock
	Then Take Screen Shot 10_Core_Ratio_Slider_right_after_TestStep200 in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'larger'
	Then The '10 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '49'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep201_Check drag the 10 Core Ratio blocker on the slider bar to the right and plus and minus icon clicable
	When user hover specific title in the CPU Overclock area '10 Core Ratio'
	When user drag the '10 Core Ratio' blocker on the slider bar to the specific location 'center' in the CPU Overclock
	Then The '10 Core Ratio' plus icon status 'clickable'or minus icon status 'clickable' in the CPU Overclock area

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep202_Check drag the 10 Core Ratio blocker on the slider bar to the right and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '10 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user drag the '10 Core Ratio' blocker on the slider bar to the specific location '3' in the CPU Overclock
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | no           |
	| 2 Core Ratio  | no           |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | no           |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | yes          |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep203_Check click 10 Core Ratio minus icon and the value should be less than before
	When user hover specific title in the CPU Overclock area '10 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '1' times '10 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then the value should be less or larger than before in the CPU Overclock area 'less'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep204_Check click 10 Core Ratio minus icon and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '10 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '3' times '10 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | no           |
	| 2 Core Ratio  | no           |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | no           |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | yes          |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep205_Check drag the 10 Core Ratio blocker on the slider bar to the left and 10 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '10 Core Ratio'
	When user drag the '10 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then Take Screen Shot 10_Core_Ratio_Slider_left_before_TestStep205 in 21722 under X50CPUPreCoreOC
	When user click '3' times '10 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then Take Screen Shot 10_Core_Ratio_Slider_left_after_TestStep205 in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'less'
	Then The '10 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '49'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep206_Check click 10 Core Ratio plus icon and the value should be larger than before
	When user hover specific title in the CPU Overclock area '10 Core Ratio'
	When user click '1' times '10 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then the value should be less or larger than before in the CPU Overclock area 'larger'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep207_Check click 10 Core Ratio plus icon and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '10 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '2' times '10 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | no           |
	| 2 Core Ratio  | no           |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | no           |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | yes          |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep208_Check drag the 10 Core Ratio blocker on the slider bar to the right and 10 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '10 Core Ratio'
	When user drag the '10 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 10_Core_Ratio_Slider_right_before_TestStep208 in 21722 under X50CPUPreCoreOC
	When user click '3' times '10 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then Take Screen Shot 10_Core_Ratio_Slider_right_after_TestStep208 in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'larger'
	Then The '10 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '49'