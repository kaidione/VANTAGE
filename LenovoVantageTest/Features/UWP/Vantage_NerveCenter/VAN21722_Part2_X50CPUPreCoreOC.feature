Feature: VAN21722_Part2_X50CPUPreCoreOC
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
Scenario: VAN21722_TestStep22_Check 4 Core Ratio tip decription should be shown in the Core clock area
	When user hover specific title in the CPU Overclock area '4 Core Ratio'
	Then Take Screen Shot 4_Core_Ratio_Tip_TestStep22  in 21722 under X50CPUPreCoreOC

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep23_Check 5 Core Ratio tip decription should be shown in the Core clock area
	When user hover specific title in the CPU Overclock area '5 Core Ratio'
	Then Take Screen Shot 5_Core_Ratio_Tip_TestStep23  in 21722 under X50CPUPreCoreOC

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep24_Check 6 Core Ratio tip decription should be shown in the Core clock area
	When user hover specific title in the CPU Overclock area '6 Core Ratio'
	Then Take Screen Shot 6_Core_Ratio_Tip_TestStep24  in 21722 under X50CPUPreCoreOC

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep25_Check 7 Core Ratio tip decription should be shown in the Core clock area
	When user hover specific title in the CPU Overclock area '7 Core Ratio'
	Then Take Screen Shot 7_Core_Ratio_Tip_TestStep25  in 21722 under X50CPUPreCoreOC

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep26_Check 8 Core Ratio tip decription should be shown in the Core clock area
	When user hover specific title in the CPU Overclock area '8 Core Ratio'
	Then Take Screen Shot 8_Core_Ratio_Tip_TestStep26  in 21722 under X50CPUPreCoreOC

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep27_Check 9 Core Ratio tip decription should be shown in the Core clock area
	When user hover specific title in the CPU Overclock area '9 Core Ratio'
	Then Take Screen Shot 9_Core_Ratio_Tip_TestStep27 in 21722 under X50CPUPreCoreOC

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep28_Check 10 Core Ratio tip decription should be shown in the Core clock area
	When user hover specific title in the CPU Overclock area '10 Core Ratio'
	Then Take Screen Shot 10_Core_Ratio_Tip_TestStep28  in 21722 under X50CPUPreCoreOC

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep29_Check Core Voltage offset tip decription should be shown in the Core clock area
	When user hover specific title in the CPU Overclock area 'Core Voltage offset'
	Then Take Screen Shot Core_Voltage_offset_Tip_TestStep29  in 21722 under X50CPUPreCoreOC

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep30_Check Core ICCMAX tip decription should be shown in the Core clock area
	When user hover specific title in the CPU Overclock area 'Core ICCMAX'
	Then Take Screen Shot Core_ICCMAX_Tip_TestStep30  in 21722 under X50CPUPreCoreOC

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep31_Check AVX Ratio offset tip decription should be shown in the Core clock area
	When user hover specific title in the CPU Overclock area 'AVX Ratio offset'
	Then Take Screen Shot AVX_Ratio_offset_Tip_TestStep31  in 21722 under X50CPUPreCoreOC

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep32_Check Cache Ratio tip decription should be shown in the Core clock area
	When user hover specific title in the CPU Overclock area 'Cache Ratio'
	Then Take Screen Shot Cache_Ratio_Tip_TestStep32  in 21722 under X50CPUPreCoreOC

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep33_Check Cache Voltage tip decription should be shown in the Core clock area
	When user hover specific title in the CPU Overclock area 'Cache Voltage'
	Then Take Screen Shot Cache_Voltage_Tip_TestStep33  in 21722 under X50CPUPreCoreOC

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep34_Check Cache Voltage offset tip decription should be shown in the Core clock area
	When user hover specific title in the CPU Overclock area 'Cache Voltage offset'
	Then Take Screen Shot Cache_Voltage_offset_Tip_TestStep34  in 21722 under X50CPUPreCoreOC

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep35_Check Cache ICCMAX tip decription should be shown in the Core clock area
	When user hover specific title in the CPU Overclock area 'Cache ICCMAX'
	Then Take Screen Shot Cache_ICCMAX_Tip_TestStep35  in 21722 under X50CPUPreCoreOC

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep36_Check Core Voltage Slider on the slider bar should be at the far right
	When user hover specific title in the CPU Overclock area 'Core Voltage'
	When user drag the 'Core Voltage' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then Take Screen Shot Core_Voltage_Slider_Right_TestStep36  in 21722 under X50CPUPreCoreOC
	Then The 'Core Voltage' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'
	
@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep37_Check Core Voltage Slider MaxValue is 1.72
	When user hover specific title in the CPU Overclock area 'Core Voltage'
	When user drag the 'Core Voltage' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then The 'Core Voltage' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep38_Check Core Voltage Slider MaxValue is 1.72 and plus icon unclickable and minus icon clickable
	When user hover specific title in the CPU Overclock area 'Core Voltage'
	When user drag the 'Core Voltage' blocker on the slider bar to the specific location 'right' in the CPU Overclock
	Then The 'Core Voltage' value in the CPU Overclock area should be same and consistent with Spec definition 'MaxValue'
	Then The 'Core Voltage' plus icon status 'unclickable'or minus icon status 'clickable' in the CPU Overclock area 

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep39_Check Core Voltage Slider on the slider bar should be at the far left
	When user hover specific title in the CPU Overclock area 'Core Voltage'
	When user drag the 'Core Voltage' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then Take Screen Shot Core_Voltage_Slider_Left_TestStep39  in 21722 under X50CPUPreCoreOC
	Then The 'Core Voltage' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'
	
@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep40_Check Core Voltage Slider MinValue is 0.8
	When user hover specific title in the CPU Overclock area 'Core Voltage'
	When user drag the 'Core Voltage' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then The 'Core Voltage' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep41_Check Core Voltage Slider MinValue is 0.8 and plus icon clickable and minus icon unclickable
	When user hover specific title in the CPU Overclock area 'Core Voltage'
	When user drag the 'Core Voltage' blocker on the slider bar to the specific location 'left' in the CPU Overclock
	Then The 'Core Voltage' value in the CPU Overclock area should be same and consistent with Spec definition 'MinValue'
	Then The 'Core Voltage' plus icon status 'clickable'or minus icon status 'unclickable' in the CPU Overclock area 

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep42_Check drag Core Voltage the blocker on the slider bar to the right and Core Voltage Slider Value is correct
	When user hover specific title in the CPU Overclock area 'Core Voltage'
	When user drag the 'Core Voltage' blocker on the slider bar to the specific location '4' in the CPU Overclock
	Then Take Screen Shot Core_Voltage_Slider_Level4_TestStep42  in 21722 under X50CPUPreCoreOC
	Then The 'Core Voltage' value in the CPU Overclock area should be same and consistent with Spec definition '0.84'