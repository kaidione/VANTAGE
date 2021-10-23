Feature: VAN21722_Part9_X50CPUPreCoreOC
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
Scenario: VAN21722_TestStep169_Check drag the 8 Core Ratio blocker on the slider bar to the right and plus and minus icon clicable
	When user hover specific title in the CPU Overclock area '8 Core Ratio'
	When user drag the '8 Core Ratio' blocker on the slider bar to the specific location 'center' in the CPU Overclock
	Then The '8 Core Ratio' plus icon status 'clickable'or minus icon status 'clickable' in the CPU Overclock area

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep170_Check drag the 8 Core Ratio blocker on the slider bar to the right and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '8 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user drag the '8 Core Ratio' blocker on the slider bar to the specific location '3' in the CPU Overclock
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
Scenario: VAN21722_TestStep171_Check click 8 Core Ratio minus icon and the value should be less than before
	When user hover specific title in the CPU Overclock area '8 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '1' times '8 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then the value should be less or larger than before in the CPU Overclock area 'less'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep172_Check click 8 Core Ratio minus icon and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '8 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '3' times '8 Core Ratio' plus or minus '-' icon in the CPU Overclock area
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
Scenario: VAN21722_TestStep173_Check drag the 8 Core Ratio blocker on the slider bar to the left and 8 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '8 Core Ratio'
	When user drag the '8 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then Take Screen Shot 8_Core_Ratio_Slider_left_before_TestStep173  in 21722 under X50CPUPreCoreOC
	When user click '3' times '8 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then Take Screen Shot 8_Core_Ratio_Slider_left_after_TestStep173   in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'less'
	Then The '8 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '49'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep174_Check click 8 Core Ratio plus icon and the value should be larger than before
	When user hover specific title in the CPU Overclock area '8 Core Ratio'
	When user click '1' times '8 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then the value should be less or larger than before in the CPU Overclock area 'larger'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep175_Check click 8 Core Ratio plus icon and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '8 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '2' times '8 Core Ratio' plus or minus '+' icon in the CPU Overclock area
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
Scenario: VAN21722_TestStep176_Check drag the 8 Core Ratio blocker on the slider bar to the right and 8 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '8 Core Ratio'
	When user drag the '8 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 8_Core_Ratio_Slider_right_before_TestStep176 in 21722 under X50CPUPreCoreOC
	When user click '3' times '8 Core Ratio' plus or minus '+' icon in the CPU Overclock area
	Then Take Screen Shot 8_Core_Ratio_Slider_right_after_TestStep176 in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'larger'
	Then The '8 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '49'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep177_Check 9 Core Ratio Slider on the slider bar should be at the far right
	When user hover specific title in the CPU Overclock area '9 Core Ratio'
	When user drag the '9 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then Take Screen Shot 9_Core_Ratio_Slider_Right_TestStep177  in 21722 under X50CPUPreCoreOC
	Then The '9 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'
	
@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep178_Check 9 Core Ratio Slider MaxValue is 52
	When user hover specific title in the CPU Overclock area '9 Core Ratio'
	When user drag the '9 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then The '9 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep179_Check 9 Core Ratio Slider MaxValue is 52 and plus icon unclickable and minus icon clickable
	When user hover specific title in the CPU Overclock area '9 Core Ratio'
	When user drag the '9 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then The '9 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'
	Then The '9 Core Ratio' plus icon status 'unclickable'or minus icon status 'clickable' in the CPU Overclock area

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep180_Check 9 Core Ratio Slider on the slider bar should be at the far left
	When user hover specific title in the CPU Overclock area '9 Core Ratio'
	When user drag the '9 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 9_Core_Ratio_Slider_Left_TestStep180  in 21722 under X50CPUPreCoreOC
	Then The '9 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep181_Check 9 Core Ratio Slider MinValue is 46
	When user hover specific title in the CPU Overclock area '9 Core Ratio'
	When user drag the '9 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then The '9 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep182_Check 9 Core Ratio Slider MinValue is 46 and plus icon clickable and minus icon unclickable
	When user hover specific title in the CPU Overclock area '9 Core Ratio'
	When user drag the '9 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then The '9 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'
	Then The '9 Core Ratio' plus icon status 'clickable'or minus icon status 'unclickable' in the CPU Overclock area 

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep183_Check 9 Core Ratio Slider MinValue is 46 and the other Core Ratio items values should not be changed.
	When user hover specific title in the CPU Overclock area '9 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user drag the '9 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
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
Scenario: VAN21722_TestStep184_Check drag the 9 Core Ratio blocker on the slider bar to the right and 9 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '9 Core Ratio'
	When user drag the '9 Core Ratio' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot 9_Core_Ratio_Slider_right_before_TestStep184  in 21722 under X50CPUPreCoreOC
	When user drag the '9 Core Ratio' blocker on the slider bar to the specific location '3' in the CPU Overclock
	Then Take Screen Shot 9_Core_Ratio_Slider_right_after_TestStep184  in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'larger'
	Then The '9 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '49'

	@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep185_Check drag the 9 Core Ratio blocker on the slider bar to the right and plus and minus icon clicable
	When user hover specific title in the CPU Overclock area '9 Core Ratio'
	When user drag the '9 Core Ratio' blocker on the slider bar to the specific location 'center' in the CPU Overclock
	Then The '9 Core Ratio' plus icon status 'clickable'or minus icon status 'clickable' in the CPU Overclock area

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep186_Check drag the 9 Core Ratio blocker on the slider bar to the right and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '9 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user drag the '9 Core Ratio' blocker on the slider bar to the specific location '3' in the CPU Overclock
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
Scenario: VAN21722_TestStep187_Check click 9 Core Ratio minus icon and the value should be less than before
	When user hover specific title in the CPU Overclock area '9 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '1' times '9 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then the value should be less or larger than before in the CPU Overclock area 'less'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep188_Check click 9 Core Ratio minus icon and the other Core Ratio items values should not be changed
	When user hover specific title in the CPU Overclock area '9 Core Ratio'
	Given Get slider bar value in the CPU Overclock
	When user click '3' times '9 Core Ratio' plus or minus '-' icon in the CPU Overclock area
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
Scenario: VAN21722_TestStep189_Check drag the 9 Core Ratio blocker on the slider bar to the left and 9 Core Ratio Slider Value is correct
	When user hover specific title in the CPU Overclock area '9 Core Ratio'
	When user drag the '9 Core Ratio' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then Take Screen Shot 9_Core_Ratio_Slider_left_before_TestStep189 in 21722 under X50CPUPreCoreOC
	When user click '3' times '9 Core Ratio' plus or minus '-' icon in the CPU Overclock area
	Then Take Screen Shot 9_Core_Ratio_Slider_left_after_TestStep189 in 21722 under X50CPUPreCoreOC
	Then the value should be less or larger than before in the CPU Overclock area 'less'
	Then The '9 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition '49'