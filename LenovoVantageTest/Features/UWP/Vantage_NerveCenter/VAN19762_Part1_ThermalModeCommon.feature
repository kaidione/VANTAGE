Feature: VAN19762_Part1_ThermalModeCommon
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-19762
	Author： Pengjie Chen

Background: 
	Given Machine is Gaming
	Given The Machine is X Series 'X50,X60' 
	Given The Machine support Specific function 'ThermalModeNew'
	When Install 'GPU' Driver

@GamingThermalModeX50 @GamingSmokeThermalMode3 @GamingSmokeThermalMode4
Scenario: VAN19762_TestStep01_Check Thermal Mode is existing in LEGION EDGE
	Then The Thermal Mode is shown in Legion Edge

@GamingThermalModeX50
Scenario: VAN19762_TestStep02_Check Thermal Mode is the first from the top in LEGION EDGE
	Then The LEGION EDGE Section priority is displayed correctly

@GamingThermalModeX50NB 
Scenario: VAN19762_TestStep03_Check Thermal Mode default mode is Balance
	Given The Machine Type is DT or NB 'NB'
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode
	Then The specific mode checked or unchecked or shown or hidden for gaming new thermal mode
		| section | status | ispopwindows |
		| balance | shown  | no           |

@GamingThermalModeX50NB
Scenario: VAN19762_TestStep04_Check Thermal Mode default mode is Balance icon
	Given The Machine Type is DT or NB 'NB'
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode
	Then Take Screen Shot Thermal_Mode_UI_default_balance_icon_TestStep04  in 19762 under ThermalModeCommon

@GamingThermalModeX50DT
Scenario: VAN19762_TestStep05_Check Thermal Mode default mode is Performance
	Given The Machine Type is DT or NB 'DT'
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode
	Then The specific mode checked or unchecked or shown or hidden for gaming new thermal mode
		| section     | status | ispopwindows |
		| performance | shown  | no           |

@GamingThermalModeX50DT
Scenario: VAN19762_TestStep06_Check Thermal Mode default mode is Performance icon
	Given The Machine Type is DT or NB 'DT'
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode
	Then Take Screen Shot Thermal_Mode_UI_default_performance_icon_TestStep06  in 19762 under ThermalModeCommon

@GamingThermalModeX50
Scenario: VAN19762_TestStep07_Check Thermal Mode clickable
	Then The Thermal Mode Setting popup is shown or hidden 'hidden'
	#Given The Thermal Mode Setting popup is displaying
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Given Show Warn Info 'please check the mouse is a hand type for VAN19762_TestStep07'

@GamingThermalModeX50
Scenario: VAN19762_TestStep08_Check Thermal Mode Setting popup will be opened
	#Given The Thermal Mode Setting popup is displaying
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'

@GamingThermalModeX50
Scenario: VAN19762_TestStep09_Check The Thermal Mode Setting popup is consistent with UI spec
	#Given The Thermal Mode Setting popup is displaying
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Then Take Screen Shot Thermal_Mode_Settings_UI_TestStep09  in 19762 under ThermalModeCommon

@GamingThermalModeX50 @GamingSmokeThermalMode3
Scenario: VAN19762_TestStep10_Check The Thermal Mode Setting popup is consistent with UI spec
	#Given The Thermal Mode Setting popup is displaying
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Then Thermal Mode Setting All the descriptions are consistent with the gaming designed descriptions
		| section           | desc                                                                                                                                                                                                       |
		| popupTitle        | Thermal Mode Setting                                                                                                                                                                                       |
		| popupDescCommon   | Choose the mode you want to use.                                                                                                                                                                           |
		| popupDescFNQ      | You can switch mode using shortcut Fn+Q.                                                                                                                                                                   |
		| performanceTitle  | Performance Mode                                                                                                                                                                                           |
		| performanceDescNB | Boost your computer performance with higher fan speed and power consumption. You can choose to turn on the Overclocking function. Performance Mode is applicable only when ac power adaptor is plugged in. |
		| performanceDescDT | Boost your computer performance with higher fan speed and power consumption. You can choose to turn on the Overclocking function.                                                                          |
		| enableOCDesc      | Enable CPU/GPU Overclocking in Performance Mode. ADVANCED                                                                                                                                                  |
		| onlyGPUOCDesc     | Enable GPU Overclocking in Performance Mode. ADVANCED                                                                                                                                                      |
		| balanceTitle      | Balance Mode                                                                                                                                                                                               |
		| balanceDesc       | Automatically adjust the performance and fan speed according to the system requirement.                                                                                                                    |
		| quietTitle        | Quiet Mode                                                                                                                                                                                                 |
		| quietDesc         | Keep quiet by reducing your computer performance and fan speed where possible with low power consumption.                                                                                                  |
		| autoswitchDesc    | Automatically switch to Performance Mode when launching games and switch back after exiting the game.                                                                                                      |

@GamingThermalModeX60New
Scenario: VAN19762_TestStep11_New_Check The Thermal Mode Setting popup is consistent with UI spec
	#Given The Thermal Mode Setting popup is displaying
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Then Take Screen Shot Thermal_Mode_Settings_UI_TestStep11New  in 19762 under ThermalModeCommon

@GamingThermalModeX60New  @GamingSmokeThermalMode4
Scenario: VAN19762_TestStep12_New_Check The Thermal Mode Setting popup is consistent with UI spec
	#Given The Thermal Mode Setting popup is displaying
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Then Thermal Mode Setting All the descriptions are consistent with the gaming designed descriptions
		| section           | desc                                                                                                                                                                                                       |
		| popupTitle        | Thermal Mode Setting                                                                                                                                                                                       |
		| popupDescCommon   | Choose the mode you want to use.                                                                                                                                                                           |
		| popupDescFNQ      | You can switch mode using shortcut Fn+Q.                                                                                                                                                                   |
		| performanceTitle  | Performance Mode                                                                                                                                                                                           |
		| performanceDescNB | Boost your computer performance with higher fan speed and power consumption. Performance Mode is applicable only when ac power adaptor is plugged in.                                                      |                                                                                                                                                 
		| balanceTitle      | Balance Mode                                                                                                                                                                                               |
		| balanceDesc       | Automatically adjust the performance and fan speed according to the system requirement.                                                                                                                    |
		| autoadjustDesc    | Automatically detect the current game and tune CPU/GPU performance. When enabled, the temperature on your computer and fan noise might increase.                                                           |
		| quietTitle        | Quiet Mode                                                                                                                                                                                                 |
		| quietDesc         | Keep quiet by reducing your computer performance and fan speed where possible with low power consumption.                                                                                                  |

@GamingThermalModeX50ThreeMode
Scenario: VAN19762_TestStep11_Check The Thermal Mode Setting popup will show three modes
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Then It Will show some modes in Thermal Mode Setting popup
		| section     | desc             |
		| performance | Performance Mode |
		| balance     | Balance Mode     |
		| quiet       | Quiet Mode       |

@GamingThermalModeX50TwoMode @GamingSmokeThermalMode3TwoMode
Scenario: VAN19762_TestStep12_Check The Thermal Mode Setting popup will show two modes
	Given The Machine support Specific function 'ThermalModeOnlyTwoMode'
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Then It Will show some modes in Thermal Mode Setting popup
		| section     | desc             |
		| performance | Performance Mode |
		| balance     | Balance Mode     |

@GamingThermalModeX50NB
Scenario: VAN19762_TestStep13_Check Thermal Mode default mode is Balance in Thermal Mode Setting popup
	Given The Machine Type is DT or NB 'NB'
	When user click new thermal mode button
	Then The Thermal Mode Setting popup is shown or hidden 'shown'
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode
	Then The specific mode checked or unchecked or shown or hidden for gaming new thermal mode
		| section | status  | ispopwindows |
		| balance | checked | yes          |