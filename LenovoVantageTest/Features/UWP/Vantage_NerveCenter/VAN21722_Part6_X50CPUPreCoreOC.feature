Feature: VAN21722_Part6_X50CPUPreCoreOC
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
Scenario: VAN21722_TestStep106_Check drag the 4 Core Ratio blocker on the slider bar to the right and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '4 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user drag the '4 Core Ratio' blocker on the slider bar to the specific location '3' in the CPU Overclock
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | no           |
	| 2 Core Ratio  | no           |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | yes          |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | no           |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | no           |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep107_Check click 4 Core Ratio minus icon and the value should be less than before
	When user hover specific title in the CPU Overclock area '4 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '1' times '4 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then the value should be less or larger than before in the CPU Overclock area 'less'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep108_Check click 4 Core Ratio minus icon and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '4 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '3' times '4 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | no           |
	| 2 Core Ratio  | no           |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | yes          |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | no           |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | no           |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep109_Check drag the 4 Core Ratio blocker on the slider bar to the left and 4 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '4 Core Ratio'
	When user drag the '4 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then Take Screen Shot 4_Core_Ratio_Slider_left_before_TestStep109  in 21722 under X50CPUPreCoreOC
	When user click '3' times '4 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then Take Screen Shot 4_Core_Ratio_Slider_left_after_TestStep109   in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'less'
	Then The '4 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '50'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep110_Check click 4 Core Ratio plus icon and the value should be larger than before
	When user hover specific title in the CPU Overclock area '4 Core Ratio'
	When user click '1' times '4 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then the value should be less or larger than before in the CPU Overclock area 'larger'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep111_Check click 4 Core Ratio plus icon and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '4 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '2' times '4 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | no           |
	| 2 Core Ratio  | no           |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | yes          |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | no           |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | no           |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep112_Check drag the 4 Core Ratio blocker on the slider bar to the right and 4 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '4 Core Ratio'
	When user drag the '4 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 4_Core_Ratio_Slider_right_before_TestStep112  in 21722 under X50CPUPreCoreOC
	When user click '3' times '4 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then Take Screen Shot 4_Core_Ratio_Slider_right_after_TestStep112   in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'larger'
	Then The '4 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '50'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep113_Check 5 Core Ratio Slider on the slider bar should be at the far right
	When user hover specific title in the CPU Overclock area '5 Core Ratio'
	When user drag the '5 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then Take Screen Shot 5_Core_Ratio_Slider_Right_TestStep113  in 21722 under X50CPUPreCoreOC
	Then The '5 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'
	
@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep114_Check 5 Core Ratio Slider MaxValue is 53
	When user hover specific title in the CPU Overclock area '5 Core Ratio'
	When user drag the '5 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then The '5 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep115_Check 5 Core Ratio Slider MaxValue is 53 and plus icon unclickable and minus icon clickable
	When user hover specific title in the CPU Overclock area '5 Core Ratio'
	When user drag the '5 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then The '5 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'
	Then The '5 Core Ratio' plus icon status 'unclickable'or minus icon status 'clickable' in the CPU Overclock area 

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep116_Check 5 Core Ratio Slider on the slider bar should be at the far left
	When user hover specific title in the CPU Overclock area '5 Core Ratio'
	When user drag the '5 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 5_Core_Ratio_Slider_Left_TestStep116  in 21722 under X50CPUPreCoreOC
	Then The '5 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep117_Check 5 Core Ratio Slider MinValue is 47
	When user hover specific title in the CPU Overclock area '5 Core Ratio'
	When user drag the '5 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then The '5 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep118_Check 5 Core Ratio Slider MinValue is 47 and plus icon clickable and minus icon unclickable
	When user hover specific title in the CPU Overclock area '5 Core Ratio'
	When user drag the '5 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then The '5 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'
	Then The '5 Core Ratio' plus icon status 'clickable'or minus icon status 'unclickable' in the CPU Overclock area 

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep119_Check 5 Core Ratio Slider MinValue is 47 and the other Core Ratio items values should not be changed.
	When user hover specific title in the CPU Overclock area '5 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user drag the '5 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | no           |
	| 2 Core Ratio  | no           |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | yes          |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | no           |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | no           |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep120_Check drag the 5 Core Ratio blocker on the slider bar to the right and 5 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '5 Core Ratio'
	When user drag the '5 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 5_Core_Ratio_Slider_right_before_TestStep120  in 21722 under X50CPUPreCoreOC
	When user drag the '5 Core Ratio' blocker on the slider bar to the specific location '3' in the CPU Overclock
	Then Take Screen Shot 5_Core_Ratio_Slider_right_after_TestStep120  in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'larger'
	Then The '5 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '50'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep121_Check drag the 5 Core Ratio blocker on the slider bar to the right and plus and minus icon clicable
	When user hover specific title in the CPU Overclock area '5 Core Ratio'
	When user drag the '5 Core Ratio' blocker on the slider bar to the specific location 'center' in the CPU Overclock
	Then The '5 Core Ratio' plus icon status 'clickable'or minus icon status 'clickable' in the CPU Overclock area

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep122_Check drag the 5 Core Ratio blocker on the slider bar to the right and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '5 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user drag the '5 Core Ratio' blocker on the slider bar to the specific location '3' in the CPU Overclock
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | no           |
	| 2 Core Ratio  | no           |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | yes          |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | no           |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | no           |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep123_Check click 5 Core Ratio minus icon and the value should be less than before
	When user hover specific title in the CPU Overclock area '5 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '1' times '5 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then the value should be less or larger than before in the CPU Overclock area 'less'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep124_Check click 5 Core Ratio minus icon and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '5 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '3' times '5 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | no           |
	| 2 Core Ratio  | no           |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | yes          |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | no           |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | no           |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep125_Check drag the 5 Core Ratio blocker on the slider bar to the left and 5 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '5 Core Ratio'
	When user drag the '5 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then Take Screen Shot 5_Core_Ratio_Slider_left_before_TestStep125  in 21722 under X50CPUPreCoreOC
	When user click '3' times '5 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then Take Screen Shot 5_Core_Ratio_Slider_left_after_TestStep125   in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'less'
	Then The '5 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '50'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep126_Check click 5 Core Ratio plus icon and the value should be larger than before
	When user hover specific title in the CPU Overclock area '5 Core Ratio'
	When user click '1' times '5 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then the value should be less or larger than before in the CPU Overclock area 'larger'
