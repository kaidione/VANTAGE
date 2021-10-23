Feature: VAN21725_X50_OC_check
	Test Case: https://jira.tc.lenovo.com/browse/VAN-21725
	Author: Xiang Tian
	
Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)

@X50OCcheck
Scenario:VAN21725_TestStep01_the parameters values in the tool shoud be not OC values
	Given click set to default OC values
	Given click the Thermal mode area
	Given The Enable Overclocking Checkbox is unchecked
	Given all parameters in the Advance OC dialog are not changed
	Given Open the XTU and GPU OC tool
	When Check the OC values in the tools
	Then It will display not OC values

@X50OCcheck
Scenario:VAN21725_TestStep02_Two values should not be consistents
	Given click set to default OC values
	Given click the Thermal mode area
	Given The Enable Overclocking Checkbox is unchecked
	Given all parameters in the Advance OC dialog are not changed
	Given Open the XTU and GPU OC tool
	Then Two values should be not consistent

@X50OCcheck
Scenario:VAN21725_TestStep03_the parameters values in the tool shoud be not OC values
	Given click set to default OC values
	Given click the Thermal mode area
	Given The Enable Overclocking Checkbox is unchecked
	Given all parameters in the Advance OC dialog are changed and saved
	Given Open the XTU and GPU OC tool
	When Check the OC values in the tools
	Then It will display not OC values
	Given click set to default OC values

@X50OCcheck
Scenario:VAN21725_TestStep04_Two values should not be consistent
	Given click set to default OC values
	Given click the Thermal mode area
	Given The Enable Overclocking Checkbox is unchecked
	Given all parameters in the Advance OC dialog are changed and saved
	Given Open the XTU and GPU OC tool
	Given Open overclock Advance Setting
	Then Two values should be not consistent
	Given set to default OC values

@X50OCcheck
Scenario:VAN21725_TestStep05_the parameters values in the tool shoud be default OC values
	Given click set to default OC values
	Given click the Thermal mode area
	Given The Enable Overclocking Checkbox is checked
	Given The thermal mode is Performance Mode
    Given all parameters in the Advance OC dialog are not changed
	Given Open the XTU and GPU OC tool
	When Check the OC values in the tools
	Then Two values should be default consistent

@X50OCcheck
Scenario:VAN21725_TestStep06_Two values should be consistent
	Given click set to default OC values
	Given click the Thermal mode area
	Given The Enable Overclocking Checkbox is checked
	Given The thermal mode is Performance Mode
    Given all parameters in the Advance OC dialog are not changed
	Given Open the XTU and GPU OC tool
	Then Two values should be yes consistent

@X50OCcheck
Scenario:VAN21725_TestStep07_the parameters values in the tool shoud be modified OC values
	Given click set to default OC values
	Given click the Thermal mode area
	Given The Enable Overclocking Checkbox is checked
	Given The thermal mode is Performance Mode
    Given all parameters in the Advance OC dialog are changed and saved
	Given Open the XTU and GPU OC tool
	Given Open overclock Advance Setting
	Then Two values should be yes consistent
	Given set to default OC values

@X50OCcheck
Scenario:VAN21725_TestStep08_Two values should be consistent
	Given click set to default OC values
	Given click the Thermal mode area
	Given The Enable Overclocking Checkbox is checked
	Given The thermal mode is Performance Mode
    Given all parameters in the Advance OC dialog are changed and saved
	Given Open overclock Advance Setting
	Given Open the XTU and GPU OC tool
	Then Two values should be yes consistent
	Given set to default OC values

@X50OCcheck
Scenario:VAN21725_TestStep09_the parameters values in the tool shoud be OC values and consistent with last modified values
	Given click set to default OC values
	Given click the Thermal mode area
	Given The Enable Overclocking Checkbox is checked
	Given The thermal mode is Performance Mode
    Given all parameters in the Advance OC dialog are changed and not saved
	Given Open the XTU and GPU OC tool
	Then Two values should be not consistent
	Then Two values should be default consistent
	Given set to default OC values

@X50OCcheck
Scenario:VAN21725_TestStep10_Two values should not be consistent
	Given click set to default OC values
	Given click the Thermal mode area
	Given The Enable Overclocking Checkbox is checked
	Given The thermal mode is Performance Mode
    Given all parameters in the Advance OC dialog are changed and not saved
	Given Open the XTU and GPU OC tool
	Then Two values should be not consistent
	Given set to default OC values

@X50OCcheck
Scenario:VAN21725_TestStep11_the parameters values in the tool shoud be OC values and consistent with saved value
	Given click set to default OC values
	Given click the Thermal mode area
	Given The Enable Overclocking Checkbox is checked
	Given The thermal mode is Performance Mode
    Given all parameters in the Advance OC dialog are changed and saved
	Given Open overclock Advance Setting
	Given Open the XTU and GPU OC tool
	Then Two values should be yes consistent
	Given set to default OC values

@X50OCcheck
Scenario:VAN21725_TestStep12_Two values should be consistent
	Given click set to default OC values
	Given click the Thermal mode area
	Given The Enable Overclocking Checkbox is checked
	Given The thermal mode is Performance Mode
    Given all parameters in the Advance OC dialog are changed and saved
	Given Open overclock Advance Setting
	Given Open the XTU and GPU OC tool
	Then Two values should be yes consistent
	Given set to default OC values

@X50OCcheck
Scenario:VAN21725_TestStep13_the parameters values in the tool shoud be default OC values
	Given click set to default OC values
	Given click the Thermal mode area
	Given The Enable Overclocking Checkbox is checked
	Given The thermal mode is Performance Mode
	Given click set to default OC values
	Given Open overclock Advance Setting
	Given Open the XTU and GPU OC tool
	Then Two values should be default consistent

@X50OCcheck
Scenario:VAN21725_TestStep14_Two values should be consistent
	Given click set to default OC values
	Given click the Thermal mode area
	Given The Enable Overclocking Checkbox is checked
	Given The thermal mode is Performance Mode
	Given click set to default OC values
	Given Open overclock Advance Setting
	Given Open the XTU and GPU OC tool
	Then Two values should be yes consistent

@X50OCcheck
Scenario:VAN21725_TestStep15_the parameters values in the tool shoud be OC values
	Given click set to default OC values
	Given click the Thermal mode area
	Given The Enable Overclocking Checkbox is checked
	Given The thermal mode is Performance Mode
	Given all parameters in the Advance OC dialog are changed and saved
	Given click set to default OC values
	Given Open overclock Advance Setting
	Given Open the XTU and GPU OC tool
	Then Two values should be yes consistent
	Then Two values should be default consistent

@X50OCcheck
Scenario:VAN21725_TestStep16_Two values should be consistent
	Given click set to default OC values
	Given click the Thermal mode area
	Given The Enable Overclocking Checkbox is checked
	Given The thermal mode is Performance Mode
	Given all parameters in the Advance OC dialog are changed and saved
	Given click set to default OC values
	Given Open overclock Advance Setting
	Given Open the XTU and GPU OC tool
	Then Two values should be yes consistent

@X50OCcheck
Scenario:VAN21725_TestStep17_mouse hover status should be a hand
	Given click set to default OC values
	Given click the Thermal mode area
	Given The Enable Overclocking Checkbox is checked
	Given The thermal mode is Performance Mode
	Given Open overclock Advance Setting
	Given mouse hover the all clickable areas and elements
	Then Take Screen Shot GamingX50_OC_check_TestStep17 in 21725 under GamingScreenShotResult

@X50OCcheck
Scenario:VAN21725_TestStep18_the buttons should be highlighted
	Given click set to default OC values
	Given click the Thermal mode area
	Given The Enable Overclocking Checkbox is checked
	Given The thermal mode is Performance Mode
	Given Open overclock Advance Setting
	Given mouse hover the all clickable areas and elements
	Then Take Screen Shot GamingX50_OC_check_TestStep17 in 21725 under GamingScreenShotResult
