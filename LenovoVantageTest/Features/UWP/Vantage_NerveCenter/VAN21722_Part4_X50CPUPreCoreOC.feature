Feature: VAN21722_Part4_X50CPUPreCoreOC
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
Scenario: VAN21722_TestStep64_Check drag the 1 Core Ratio blocker on the slider bar to the right and 1 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '1 Core Ratio'
	When user drag the '1 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 1_Core_Ratio_Slider_right_before_TestStep64  in 21722 under X50CPUPreCoreOC
	When user click '3' times '1 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then Take Screen Shot 1_Core_Ratio_Slider_right_after_TestStep64   in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'larger'
	Then The '1 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '53'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep65_Check 2 Core Ratio Slider on the slider bar should be at the far right
	When user hover specific title in the CPU Overclock area '2 Core Ratio'
	When user drag the '2 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then Take Screen Shot 2_Core_Ratio_Slider_Right_TestStep65  in 21722 under X50CPUPreCoreOC
	Then The '2 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'
	
@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep66_Check 2 Core Ratio Slider MaxValue is 56
	When user hover specific title in the CPU Overclock area '2 Core Ratio'
	When user drag the '2 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then The '2 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep67_Check 2 Core Ratio Slider MaxValue is 56 and plus icon unclickable and minus icon clickable
	When user hover specific title in the CPU Overclock area '2 Core Ratio'
	When user drag the '2 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then The '2 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'
	Then The '2 Core Ratio' plus icon status 'unclickable'or minus icon status 'clickable' in the CPU Overclock area 

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep68_Check 2 Core Ratio Slider on the slider bar should be at the far left
	When user hover specific title in the CPU Overclock area '2 Core Ratio'
	When user drag the '2 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 2_Core_Ratio_Slider_Left_TestStep68  in 21722 under X50CPUPreCoreOC
	Then The '2 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep69_Check 2 Core Ratio Slider MinValue is 50
	When user hover specific title in the CPU Overclock area '2 Core Ratio'
	When user drag the '2 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then The '2 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep70_Check 2 Core Ratio Slider MinValue is 50 and plus icon clickable and minus icon unclickable
	When user hover specific title in the CPU Overclock area '2 Core Ratio'
	When user drag the '2 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then The '2 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'
	Then The '2 Core Ratio' plus icon status 'clickable'or minus icon status 'unclickable' in the CPU Overclock area 

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep71_Check 2 Core Ratio Slider MinValue is 50 and the other Core Ratio items values should not be changed.
	When user hover specific title in the CPU Overclock area '2 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user drag the '2 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | no           |
	| 2 Core Ratio  | yes          |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | no           |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | no           |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep72_Check drag the 2 Core Ratio blocker on the slider bar to the right and 2 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '1 Core Ratio'
	When user drag the '2 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 2_Core_Ratio_Slider_right_before_TestStep72  in 21722 under X50CPUPreCoreOC
	When user drag the '2 Core Ratio' blocker on the slider bar to the specific location '3' in the CPU Overclock
	Then Take Screen Shot 2_Core_Ratio_Slider_right_after_TestStep72  in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'larger'
	Then The '2 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '53'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep73_Check drag the 2 Core Ratio blocker on the slider bar to the right and plus and minus icon clicable
	When user hover specific title in the CPU Overclock area '2 Core Ratio'
	When user drag the '2 Core Ratio' blocker on the slider bar to the specific location 'center' in the CPU Overclock
	Then The '2 Core Ratio' plus icon status 'clickable'or minus icon status 'clickable' in the CPU Overclock area

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep74_Check drag the 2 Core Ratio blocker on the slider bar to the right and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '2 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user drag the '2 Core Ratio' blocker on the slider bar to the specific location '3' in the CPU Overclock
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | no           |
	| 2 Core Ratio  | yes          |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | no           |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | no           |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep75_Check click 2 Core Ratio minus icon and the value should be less than before
	When user hover specific title in the CPU Overclock area '2 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '1' times '2 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then the value should be less or larger than before in the CPU Overclock area 'less'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep76_Check click 2 Core Ratio minus icon and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '2 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '3' times '2 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | no           |
	| 2 Core Ratio  | yes          |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | no           |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | no           |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep77_Check drag the 2 Core Ratio blocker on the slider bar to the left and 2 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '2 Core Ratio'
	When user drag the '2 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then Take Screen Shot 2_Core_Ratio_Slider_left_before_TestStep77  in 21722 under X50CPUPreCoreOC
	When user click '3' times '2 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then Take Screen Shot 2_Core_Ratio_Slider_left_after_TestStep77   in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'less'
	Then The '2 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '53'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep78_Check click 2 Core Ratio plus icon and the value should be larger than before
	When user hover specific title in the CPU Overclock area '2 Core Ratio'
	When user click '3' times '2 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then the value should be less or larger than before in the CPU Overclock area 'larger'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep79_Check click 2 Core Ratio plus icon and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '2 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '2' times '2 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | no           |
	| 2 Core Ratio  | yes          |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | no           |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | no           |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep80_Check drag the 2 Core Ratio blocker on the slider bar to the right and 2 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '2 Core Ratio'
	When user drag the '2 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 2_Core_Ratio_Slider_right_before_TestStep80  in 21722 under X50CPUPreCoreOC
	When user click '3' times '2 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then Take Screen Shot 2_Core_Ratio_Slider_right_after_TestStep80   in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'larger'
	Then The '2 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '53'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep81_Check 3 Core Ratio Slider on the slider bar should be at the far right
	When user hover specific title in the CPU Overclock area '3 Core Ratio'
	When user drag the '3 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then Take Screen Shot 3_Core_Ratio_Slider_Right_TestStep81  in 21722 under X50CPUPreCoreOC
	Then The '3 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'
	
@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep82_Check 3 Core Ratio Slider MaxValue is 54
	When user hover specific title in the CPU Overclock area '3 Core Ratio'
	When user drag the '3 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then The '3 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep83_Check 3 Core Ratio Slider MaxValue is 56 and plus icon unclickable and minus icon clickable
	When user hover specific title in the CPU Overclock area '3 Core Ratio'
	When user drag the '3 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then The '3 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'
	Then The '3 Core Ratio' plus icon status 'unclickable'or minus icon status 'clickable' in the CPU Overclock area 

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep84_Check 3 Core Ratio Slider on the slider bar should be at the far left
	When user hover specific title in the CPU Overclock area '3 Core Ratio'
	When user drag the '3 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 3_Core_Ratio_Slider_Left_TestStep84  in 21722 under X50CPUPreCoreOC
	Then The '3 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'