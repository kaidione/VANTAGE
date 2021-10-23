Feature: VAN21726_GamingX50AdvancedOCSetToDefault
	Test Case: https://jira.tc.lenovo.com/browse/VAN-21726
	Author: Xiang Tian
	
Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)
	When check if T750 or not

@GamingX50AdvancedOCSetToDefault
Scenario:VAN21726_TestStep01_the set to default link  button should be shown
	Given click the Thermal mode area
	Given Open overclock Advance Setting
	Then the set to default link button should be shown

@GamingX50AdvancedOCSetToDefault
Scenario:VAN21726_TestStep02_the set to default link button should be shown
	Given click the Thermal mode area
	Given all parameters in the Advance OC dialog are changed and saved
	Given Open overclock Advance Setting
	Then the set to default link button should be shown

@GamingX50AdvancedOCSetToDefault
Scenario:VAN21726_TestStep03_click default dialog ok btn,previous changes will be lost,click X Btn,Cancel Btn
	Given click the Thermal mode area
	Given all parameters in the Advance OC dialog are changed and saved
	Given Open overclock Advance Setting
	Then The the set to default dialog should be shown or hidden 'shown' 
	| item  | desc                                           |
	| title | Set to default ?                               |
	| desc  | All current and previous changes will be lost. |

@GamingX50AdvancedOCSetToDefault
Scenario:VAN21726_TestStep04_set to default dialog should be closed and the Advance OC dialog should not be closed
	Given click the Thermal mode area
	Given Open overclock Advance Setting
	Then set to default dialog should be shown and click 'X' Btn
	Then the Advance OC dialog should not be closed

@GamingX50AdvancedOCSetToDefault
Scenario:VAN21726_TestStep05_all parameters should be consistent with before
	Given click the Thermal mode area
	Given Open overclock Advance Setting
	Then set to default dialog should be shown and click 'X' Btn
	Then all parameters should be consistent with before

@GamingX50AdvancedOCSetToDefault
Scenario:VAN21726_TestStep06_set to default dialog should be closed and the Advance OC dialog should not be closed
	Given click the Thermal mode area
	Given Open overclock Advance Setting
	Then set to default dialog should be shown and click 'cancel' Btn
	Then the Advance OC dialog should not be closed

@GamingX50AdvancedOCSetToDefault
Scenario:VAN21726_TestStep07_all parameters should be consistent with before
	Given click the Thermal mode area
	Given Open overclock Advance Setting
	Then set to default dialog should be shown and click 'cancel' Btn
	Then all parameters should be consistent with before

@GamingX50AdvancedOCSetToDefault
Scenario:VAN21726_TestStep08_set to default dialog should be closed and the Advance OC dialog should not be closed
	Given click the Thermal mode area
	Given all parameters in the Advance OC dialog are changed and saved
	Given Open overclock Advance Setting
	Then set to default dialog should be shown and click 'Ok' Btn
	Then The '1 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then The '2 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then The '3 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then The '4 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then The '5 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then The '6 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then The '7 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then The '8 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then The '9 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then The '10 Core Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then The 'Core Voltage offset' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then The 'Cache Voltage offset' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then The 'Core ICCMAX' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then The 'Cache ICCMAX' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then The 'AVX Ratio offset' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then The 'Cache Ratio' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then The 'Core Voltage' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then The 'Cache Voltage' value in the CPU Overclock area should be same and consistent with Spec definition 'Default'
	Then the Advance OC dialog should not be closed

@GamingX50AdvancedOCSetToDefault
Scenario:VAN21726_TestStep09_all parameters should be back to the default value that definited in the Spec requirement
	Given click the Thermal mode area
	Given all parameters in the Advance OC dialog are changed and saved
	Given Open overclock Advance Setting
	Then set to default dialog should be shown and click 'Ok' Btn
	Then all parameters should be back to the default value



