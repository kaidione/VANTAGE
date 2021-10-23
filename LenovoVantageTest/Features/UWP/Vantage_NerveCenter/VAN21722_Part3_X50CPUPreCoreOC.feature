Feature: VAN21722_Part3_X50CPUPreCoreOC
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
Scenario: VAN21722_TestStep43_Check drag the Core Voltage blocker on the slider bar to the right and plus and minus icon clicable
	When user hover specific title in the CPU Overclock area 'Core Voltage'
	When user drag the 'Core Voltage' blocker on the slider bar to the specific location 'center' in the CPU Overclock
	Then The 'Core Voltage' plus icon status 'clickable'or minus icon status 'clickable' in the CPU Overclock area

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep44_Check click Core Voltage minus icon and the value should be less than before
	When user hover specific title in the CPU Overclock area 'Core Voltage'
	When user drag the 'Core Voltage' blocker on the slider bar to the specific location 'center' in the CPU Overclock
	When user click '1' times 'Core Voltage' plus or minus '-' icon in the CPU Overclock area
	Then the value should be less or larger than before in the CPU Overclock area 'less'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep45_Check the Core Voltage blocker should be to the left of its original position and position should be consistent with the value
	When user hover specific title in the CPU Overclock area 'Core Voltage'
	When user drag the 'Core Voltage' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then Take Screen Shot Core_Voltage_Slider_left_before_TestStep45  in 21722 under X50CPUPreCoreOC
	When user click '3' times 'Core Voltage' plus or minus '-' icon in the CPU Overclock area
	Then Take Screen Shot Core_Voltage_Slider_left_after_TestStep45  in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'less'
	Then The 'Core Voltage' value in the CPU Overclock area should be same and consistent with Spec definition '1.69'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep46_Check click Core Voltage minus icon and the value should be less than before
	When user hover specific title in the CPU Overclock area 'Core Voltage'
	When user drag the 'Core Voltage' blocker on the slider bar to the specific location 'center' in the CPU Overclock
	When user click '1' times 'Core Voltage' plus or minus '+' icon in the CPU Overclock area
	Then the value should be less or larger than before in the CPU Overclock area 'larger'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep47_Check the Core Voltage blocker should be to the right of its original position and position should be consistent with the value
	When user hover specific title in the CPU Overclock area 'Core Voltage'
	When user drag the 'Core Voltage' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot Core_Voltage_Slider_right_before_TestStep47  in 21722 under X50CPUPreCoreOC
	When user click '3' times 'Core Voltage' plus or minus '+' icon in the CPU Overclock area
	Then Take Screen Shot Core_Voltage_Slider_right_after_TestStep47  in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'larger'
	Then The 'Core Voltage' value in the CPU Overclock area should be same and consistent with Spec definition '0.83'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep48_Check Core Voltage and Cache Voltage two items value silder bar should be consistent
	When user hover specific title in the CPU Overclock area 'Core Voltage'
	When user drag the 'Core Voltage' blocker on the slider bar to the specific location 'center' in the CPU Overclock
	When user click '2' times 'Core Voltage' plus or minus '+' icon in the CPU Overclock area
	Then the current silder bar value should be consistent 'Cache Voltage'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep49_Check 1 Core Ratio Slider on the slider bar should be at the far right
	When user hover specific title in the CPU Overclock area '1 Core Ratio'
	When user drag the '1 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then Take Screen Shot 1_Core_Ratio_Slider_Right_TestStep49  in 21722 under X50CPUPreCoreOC
	Then The '1 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'
	
@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep50_Check 1 Core Ratio Slider MaxValue is 56
	When user hover specific title in the CPU Overclock area '1 Core Ratio'
	When user drag the '1 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then The '1 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep51_Check 1 Core Ratio Slider MaxValue is 56 and plus icon unclickable and minus icon clickable
	When user hover specific title in the CPU Overclock area '1 Core Ratio'
	When user drag the '1 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then The '1 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'
	Then The '1 Core Ratio' plus icon status 'unclickable'or minus icon status 'clickable' in the CPU Overclock area 

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep52_Check 1 Core Ratio Slider on the slider bar should be at the far left
	When user hover specific title in the CPU Overclock area '1 Core Ratio'
	When user drag the '1 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 1_Core_Ratio_Slider_Left_TestStep52  in 21722 under X50CPUPreCoreOC
	Then The '1 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep53_Check 1 Core Ratio Slider MinValue is 50
	When user hover specific title in the CPU Overclock area '1 Core Ratio'
	When user drag the '1 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then The '1 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep54_Check 1 Core Ratio Slider MinValue is 50 and plus icon clickable and minus icon unclickable
	When user hover specific title in the CPU Overclock area '1 Core Ratio'
	When user drag the '1 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then The '1 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'
	Then The '1 Core Ratio' plus icon status 'clickable'or minus icon status 'unclickable' in the CPU Overclock area 

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep55_Check 1 Core Ratio Slider MinValue is 50 and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '1 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user drag the '1 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | yes          |
	| 2 Core Ratio  | no           |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | no           |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | no           |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep56_Check drag the 1 Core Ratio blocker on the slider bar to the right and 1 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '1 Core Ratio'
	When user drag the '1 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 1_Core_Ratio_Slider_right_before_TestStep56  in 21722 under X50CPUPreCoreOC
	When user drag the '1 Core Ratio' blocker on the slider bar to the specific location '3' in the CPU Overclock
	Then Take Screen Shot 1_Core_Ratio_Slider_right_after_TestStep56  in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'larger'
	Then The '1 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '53'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep57_Check drag the 1 Core Ratio blocker on the slider bar to the right and plus and minus icon clicable
	When user hover specific title in the CPU Overclock area '1 Core Ratio'
	When user drag the '1 Core Ratio' blocker on the slider bar to the specific location 'center' in the CPU Overclock
	Then The '1 Core Ratio' plus icon status 'clickable'or minus icon status 'clickable' in the CPU Overclock area 

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep58_Check drag the 1 Core Ratio blocker on the slider bar to the right and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '1 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user drag the '1 Core Ratio' blocker on the slider bar to the specific location '3' in the CPU Overclock
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | yes          |
	| 2 Core Ratio  | no           |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | no           |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | no           |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep59_Check click 1 Core Ratio minus icon and the value should be less than before
	When user hover specific title in the CPU Overclock area '1 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '1' times '1 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then the value should be less or larger than before in the CPU Overclock area 'less'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep60_Check click 1 Core Ratio minus icon and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '1 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '3' times '1 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | yes          |
	| 2 Core Ratio  | no           |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | no           |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | no           |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep61_Check drag the 1 Core Ratio blocker on the slider bar to the left and 1 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '1 Core Ratio'
	When user drag the '1 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then Take Screen Shot 1_Core_Ratio_Slider_left_before_TestStep61  in 21722 under X50CPUPreCoreOC
	When user click '3' times '1 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then Take Screen Shot 1_Core_Ratio_Slider_left_after_TestStep61   in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'less'
	Then The '1 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '53'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep62_Check click 1 Core Ratio plus icon and the value should be larger than before
	When user hover specific title in the CPU Overclock area '1 Core Ratio'
	When user click '3' times '1 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then the value should be less or larger than before in the CPU Overclock area 'larger'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep63_Check click 1 Core Ratio plus icon and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '1 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '2' times '1 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | yes          |
	| 2 Core Ratio  | no           |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | no           |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | no           |