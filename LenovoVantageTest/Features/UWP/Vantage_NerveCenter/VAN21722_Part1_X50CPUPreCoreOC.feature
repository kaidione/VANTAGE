Feature: VAN21722_Part1_X50CPUPreCoreOC
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
Scenario: VAN21722_TestStep00_default CPU or GPU value in the Advance OC page
	When click set to default link in the Overclock Advanced Settings page
	Given Change Gaming Machine VAN21722 DPI to 100

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep01_check the CPU area in the Advance OC page
	Then The CPU area items should be shown in the Advance OC page
	| id | item                 |
	| 1  | Core Voltage         |
	| 2  | 1-10 Core Ratio      |
	| 3  | Core Voltage offset  |
	| 4  | Core ICCMAX          |
	| 5  | AVX Ratio offset     |
	| 6  | Cache Ratio          |
	| 7  | Cache Voltage        |
	| 8  | Cache Voltage offset |
	| 9  | Cache ICCMAX         |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep02_check the CPU area in the Advance OC page
	Then The CPU area items should be shown in the Advance OC page
	| id | item                                                   |
	| 10 | 1-10 Core Ratio,the slider bar ' - ' icon and '+' icon |

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep03_check Core Voltage and Cache Voltage default value should be same in the Advance OC page
	Then The 'Core Voltage' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then The 'Cache Voltage' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep04_Check 1 Core Ratio default value in the Advance OC page
	Then The '1 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep05_Check 2 Core Ratio default value in the Advance OC page
	Then The '2 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep06_Check 3 Core Ratio default value in the Advance OC page
	Then The '3 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep07_Check 4 Core Ratio default value in the Advance OC page
	Then The '4 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep08_Check 5 Core Ratio default value in the Advance OC page
	Then The '5 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep09_Check 6 Core Ratio default value in the Advance OC page
	Then The '6 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep10_Check 7 Core Ratio default value in the Advance OC page
	Then The '7 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep11_Check 8 Core Ratio default value in the Advance OC page
	Then The '8 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep12_Check 9 Core Ratio default value in the Advance OC page
	Then The '9 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep13_Check 10 Core Ratio default value in the Advance OC page
	Then The '10 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep14_Check Core Voltage Offset and Cache Voltage Offset default value should be same in the Advance OC page
	Then The 'Core Voltage offset' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then The 'Cache Voltage offset' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep15_Check Core ICCMAX and Cache ICCMAX default value should be same in the Advance OC page
	Then The 'Core ICCMAX' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then The 'Cache ICCMAX' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep16_Check AVX Ration Offset default value should be same in the Advance OC page
	Then The 'AVX Ratio offset' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep17_Check Cache Ratio default value should be same in the Advance OC page
	Then The 'Cache Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep18_Check Core Voltage tip decription should be shown in the Core clock area
	When user hover specific title in the CPU Overclock area 'Core Voltage'
	Then Take Screen Shot Core_Voltage_Tip_TestStep18  in 21722 under X50CPUPreCoreOC

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep19_Check 1 Core Ratio tip decription should be shown in the Core clock area
	When user hover specific title in the CPU Overclock area '1 Core Ratio'
	Then Take Screen Shot 1_Core_Ratio_Tip_TestStep19  in 21722 under X50CPUPreCoreOC

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep20_Check 2 Core Ratio tip decription should be shown in the Core clock area
	When user hover specific title in the CPU Overclock area '2 Core Ratio'
	Then Take Screen Shot 2_Core_Ratio_Tip_TestStep20  in 21722 under X50CPUPreCoreOC

@GamingX50CPUPreCoreOC
Scenario: VAN21722_TestStep21_Check 3 Core Ratio tip decription should be shown in the Core clock area
	When user hover specific title in the CPU Overclock area '3 Core Ratio'
	Then Take Screen Shot 3_Core_Ratio_Tip_TestStep21  in 21722 under X50CPUPreCoreOC