Feature: VAN21722_Part8_X50CPUPreCoreOC
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
Scenario: VAN21722_TestStep148_Check 7 Core Ratio Slider on the slider bar should be at the far left
	When user hover specific title in the CPU Overclock area '7 Core Ratio'
	When user drag the '7 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 7_Core_Ratio_Slider_Left_TestStep148  in 21722 under X50CPUPreCoreOC
	Then The '7 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep149_Check 7 Core Ratio Slider MinValue is 46
	When user hover specific title in the CPU Overclock area '7 Core Ratio'
	When user drag the '7 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then The '7 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep150_Check 7 Core Ratio Slider MinValue is 46 and plus icon clickable and minus icon unclickable
	When user hover specific title in the CPU Overclock area '7 Core Ratio'
	When user drag the '7 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then The '7 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'
	Then The '7 Core Ratio' plus icon status 'clickable'or minus icon status 'unclickable' in the CPU Overclock area 

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep151_Check 7 Core Ratio Slider MinValue is 46 and the other Core Ratio items values should not be changed.
	When user hover specific title in the CPU Overclock area '7 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user drag the '7 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | no           |
	| 2 Core Ratio  | no           |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | yes          |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | no           |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep152_Check drag the 7 Core Ratio blocker on the slider bar to the right and 7 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '7 Core Ratio'
	When user drag the '7 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 7_Core_Ratio_Slider_right_before_TestStep152  in 21722 under X50CPUPreCoreOC
	When user drag the '7 Core Ratio' blocker on the slider bar to the specific location '3' in the CPU Overclock
	Then Take Screen Shot 7_Core_Ratio_Slider_right_after_TestStep152  in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'larger'
	Then The '7 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '49'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep153_Check drag the 7 Core Ratio blocker on the slider bar to the right and plus and minus icon clicable
	When user hover specific title in the CPU Overclock area '7 Core Ratio'
	When user drag the '7 Core Ratio' blocker on the slider bar to the specific location 'center' in the CPU Overclock
	Then The '7 Core Ratio' plus icon status 'clickable'or minus icon status 'clickable' in the CPU Overclock area

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep154_Check drag the 7 Core Ratio blocker on the slider bar to the right and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '7 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user drag the '7 Core Ratio' blocker on the slider bar to the specific location '3' in the CPU Overclock
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | no           |
	| 2 Core Ratio  | no           |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | yes          |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | no           |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep155_Check click 7 Core Ratio minus icon and the value should be less than before
	When user hover specific title in the CPU Overclock area '7 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '1' times '7 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then the value should be less or larger than before in the CPU Overclock area 'less'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep156_Check click 7 Core Ratio minus icon and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '7 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '3' times '7 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | no           |
	| 2 Core Ratio  | no           |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | yes          |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | no           |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep157_Check drag the 7 Core Ratio blocker on the slider bar to the left and 7 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '7 Core Ratio'
	When user drag the '7 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then Take Screen Shot 7_Core_Ratio_Slider_left_before_TestStep157  in 21722 under X50CPUPreCoreOC
	When user click '3' times '7 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then Take Screen Shot 7_Core_Ratio_Slider_left_after_TestStep157   in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'less'
	Then The '7 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '49'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep158_Check click 7 Core Ratio plus icon and the value should be larger than before
	When user hover specific title in the CPU Overclock area '7 Core Ratio'
	When user click '1' times '7 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then the value should be less or larger than before in the CPU Overclock area 'larger'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep159_Check click 7 Core Ratio plus icon and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '7 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '2' times '7 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | no           |
	| 2 Core Ratio  | no           |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | yes          |
	| 8 Core Ratio  | no           |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | no           |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep160_Check drag the 7 Core Ratio blocker on the slider bar to the right and 7 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '7 Core Ratio'
	When user drag the '7 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 7_Core_Ratio_Slider_right_before_TestStep160 in 21722 under X50CPUPreCoreOC
	When user click '3' times '7 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then Take Screen Shot 7_Core_Ratio_Slider_right_after_TestStep160 in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'larger'
	Then The '7 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '49'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep161_Check 8 Core Ratio Slider on the slider bar should be at the far right
	When user hover specific title in the CPU Overclock area '8 Core Ratio'
	When user drag the '8 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then Take Screen Shot 8_Core_Ratio_Slider_Right_TestStep161  in 21722 under X50CPUPreCoreOC
	Then The '8 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'
	
@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep162_Check 8 Core Ratio Slider MaxValue is 52
	When user hover specific title in the CPU Overclock area '8 Core Ratio'
	When user drag the '8 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then The '8 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep163_Check 8 Core Ratio Slider MaxValue is 52 and plus icon unclickable and minus icon clickable
	When user hover specific title in the CPU Overclock area '8 Core Ratio'
	When user drag the '8 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then The '8 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'
	Then The '8 Core Ratio' plus icon status 'unclickable'or minus icon status 'clickable' in the CPU Overclock area

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep164_Check 8 Core Ratio Slider on the slider bar should be at the far left
	When user hover specific title in the CPU Overclock area '8 Core Ratio'
	When user drag the '8 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 8_Core_Ratio_Slider_Left_TestStep164  in 21722 under X50CPUPreCoreOC
	Then The '8 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep165_Check 8 Core Ratio Slider MinValue is 46
	When user hover specific title in the CPU Overclock area '8 Core Ratio'
	When user drag the '8 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then The '8 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep166_Check 8 Core Ratio Slider MinValue is 46 and plus icon clickable and minus icon unclickable
	When user hover specific title in the CPU Overclock area '8 Core Ratio'
	When user drag the '8 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then The '8 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'
	Then The '8 Core Ratio' plus icon status 'clickable'or minus icon status 'unclickable' in the CPU Overclock area 

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep167_Check 8 Core Ratio Slider MinValue is 46 and the other Core Ratio items values should not be changed.
	When user hover specific title in the CPU Overclock area '8 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user drag the '8 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then the items values should not be changed or changed
	| item          | changestatus |
	| 1 Core Ratio  | no           |
	| 2 Core Ratio  | no           |
	| 3 Core Ratio  | no           |
	| 4 Core Ratio  | no           |
	| 5 Core Ratio  | no           |
	| 6 Core Ratio  | no           |
	| 7 Core Ratio  | no           |
	| 8 Core Ratio  | yes          |
	| 9 Core Ratio  | no           |
	| 10 Core Ratio | no           |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep168_Check drag the 8 Core Ratio blocker on the slider bar to the right and 8 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '8 Core Ratio'
	When user drag the '8 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 8_Core_Ratio_Slider_right_before_TestStep168  in 21722 under X50CPUPreCoreOC
	When user drag the '8 Core Ratio' blocker on the slider bar to the specific location '3' in the CPU Overclock
	Then Take Screen Shot 8_Core_Ratio_Slider_right_after_TestStep168  in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'larger'
	Then The '8 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '49'