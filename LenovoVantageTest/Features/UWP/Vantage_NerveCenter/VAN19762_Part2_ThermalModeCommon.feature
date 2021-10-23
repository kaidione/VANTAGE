Feature: VAN19762_Part2_ThermalModeCommon
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-19762
	Author： Pengjie Chen

Background: 
	Given Machine is Gaming
	Given The Machine is X Series 'X50,X60'
	Given The Machine support Specific function 'ThermalModeNew'
	When Install 'GPU' Driver

@GamingThermalModeX50DT
Scenario: VAN19762_TestStep14_Check Thermal Mode default mode is Performance in Thermal Mode Setting popup
	Given The Machine Type is DT or NB 'DT'
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode
	Then The specific mode checked or unchecked or shown or hidden for gaming new thermal mode
		| section     | status  | ispopwindows |
		| performance | checked | yes          |

@GamingThermalModeX50
Scenario: VAN19762_TestStep15_Check Thermal Mode Setting popup still show when click other plance
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	When user click Thermal Mode Setting popup other place
	Then The Thermal Mode Setting popup is shown or hidden 'shown'

@GamingThermalModeX50CPUGPUOC @GamingSmokeThermalMode3CPUGPUOC
Scenario: VAN19762_TestStep16_Check Enable OverClocking checkbox should be displayed and the description strings should be consistent with design
	Given The Machine support Specific function 'CPUGPUOverclockNew'
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Then Thermal Mode Setting All the descriptions are consistent with the gaming designed descriptions
		| section       | desc                                                      |
		| enableOCDesc  | Enable CPU/GPU Overclocking in Performance Mode. ADVANCED |
		| onlyGPUOCDesc | Enable GPU Overclocking in Performance Mode. ADVANCED     |

@GamingThermalModeX50GPUOC @GamingSmokeThermalMode3GPUOC
Scenario: VAN19762_TestStep17_Check Enable OverClocking checkbox should be displayed and the description strings should be consistent with design
	Given The Machine support Specific function 'GPUOverclockNew'
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Then Thermal Mode Setting All the descriptions are consistent with the gaming designed descriptions
		| section          | desc                                                   |
		| enableOCDesc  | Enable CPU/GPU Overclocking in Performance Mode. ADVANCED |
		| onlyGPUOCDesc | Enable GPU Overclocking in Performance Mode. ADVANCED     |  

@GamingThermalModeX50NOOC 
Scenario: VAN19762_TestStep18_Check Enable OverClocking checkbox and description should not be displayed
	Given The Machine support Specific function 'NotSupportOverclock'
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Then Thermal Mode Setting All the descriptions are consistent with the gaming designed descriptions
		| section       | desc                                                      |
		| enableOCDesc  | Enable CPU/GPU Overclocking in Performance Mode. ADVANCED |
		| onlyGPUOCDesc | Enable GPU Overclocking in Performance Mode. ADVANCED     |  
	Then The Enable OverClocking checked or unchecked or shown or hidden for gaming new thermal mode 'hidden'

@GamingThermalModeX50OC @GamingSmokeThermalMode3OCCheckbox
Scenario: VAN19762_TestStep19_Check Enable OverClocking checkbox is unchecked
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Then The Enable OverClocking checked or unchecked or shown or hidden for gaming new thermal mode 'unchecked'

@GamingThermalModeX50OC
Scenario: VAN19762_TestStep20_Check The ADVANCED link button is at the right of Enable OverClocking description in Performance Mode
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Then The ADVANCED link button is at the right of Enable OverClocking description

@GamingThermalModeX50NOOC @GamingSmokeThermalMode3NOOC
Scenario: VAN19762_TestStep21_Check The ADVANCED link button should not displayed in Performance Mode
	Given The Machine support Specific function 'NotSupportOverclock'
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Then The ADVANCED link button should shown or hidden in Performance Mode 'hidden'

 @GamingThermalModeX60New @GamingSmokeThermalMode4AutoAdjust
Scenario: VAN19762_TestStep21_New_Check default status of Auto switch toggle should be OFF
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Then The status of Auto Adjust Checkbox is ON or OFF 'OFF'
	 
 @GamingThermalModeX60New @GamingSmokeThermalMode4AutoAdjust
Scenario: VAN19762_TestStep22_New_Check Auto Adjust Checkbox and description 
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Then Thermal Mode Setting All the descriptions are consistent with the gaming designed descriptions
		| section        | desc                                                                                                  |
		| autoadjustDesc | Automatically detect the current game and tune CPU/GPU performance. When enabled, the temperature on your computer and fan noise might increase.|

@GamingThermalModeX50 @GamingSmokeThermalMode3AutoSwitch
Scenario: VAN19762_TestStep23_Check default status of Auto switch toggle should be OFF
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Then The status of Auto switch toggle is ON or OFF 'OFF'

@GamingThermalModeX50 @GamingSmokeThermalMode3AutoSwitch
Scenario: VAN19762_TestStep24_Check Auto Switch Toggle and description 
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Then Thermal Mode Setting All the descriptions are consistent with the gaming designed descriptions
		| section        | desc                                                                                                  |
		| autoswitchDesc | Automatically switch to Performance Mode when launching games and switch back after exiting the game. |

@GamingThermalModeX50
Scenario: VAN19762_TestStep26_Check Thermal Mode Setting popup is closed
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Given Click X button in Thermal Mode Setting popup
	Then The Thermal Mode Setting popup is shown or hidden 'hidden'