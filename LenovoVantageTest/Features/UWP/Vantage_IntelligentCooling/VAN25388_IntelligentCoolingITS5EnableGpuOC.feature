Feature: VAN25388_IntelligentCoolingITS5EnableGpuOC
	Test Case: https://jira.tc.lenovo.com/browse/VAN-25388
	Author: Huajie

@ITS5_GPUOC
Scenario:VAN25388_TestStep01_check BIOS value and gpu oc show normally
	Given machine is not gaming
	Given ITS machine support GPUOC
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Then Check EPM GPU OC check box exist
	Then Check Intelligent CoolingDesc Text for ITS5EPM_GPU

@ITS5_GPUOC
Scenario:VAN25388_TestStep05_stop ITS service and UI should not show gpu oc feature
	Given Stop ITS Service
	Given Install Vantage 
	Given Go to Power Page
	Then Check Intelligent Cooling hide for ITS4
	Then ITS GPU OC will be set to 0 values
	Given Start ITS Service

@ITS5_GPUOC
Scenario:VAN25388_TestStep08_check gpu oc ui
	Given Start ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Then Check Intelligent Cooling show for ITS5
	Then Check Intelligent CoolingDesc Text for ITS4EPM
	Then Check EPM GPU OC check box exist
	Then Check Intelligent CoolingDesc Text for ITS5EPM_GPU

@ITS5_GPUOC
Scenario:VAN25388_TestStep09_check it will not show ADVANCED SETTINGS hyperlink
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Then Take Screen Shot 1101 in 25388 under ITSScreenShotResult

@ITS5_GPUOC
Scenario:VAN25388_TestStep10_check the default value of checkbox is unchecked
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Select ITS GPU OC checkbox checked
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings section
	Then The value of GPU OC checkbox is unchecked

@ITS5_GPUOC
Scenario:VAN25388_TestStep11_check the default value of Gpu Oc is 0
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Select ITS GPU OC checkbox checked
	Given Install Vantage
	Then ITS GPU OC will be set to 0 values

@ITS5_GPUOC
Scenario:VAN25388_TestStep12_check the value of checkbox is checked
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Select ITS GPU OC checkbox checked
	Then The value of GPU OC checkbox is checked

@ITS5_GPUOC
Scenario:VAN25388_TestStep13_check the value of Gpu Oc is 140Mhz
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Select ITS GPU OC checkbox checked
	Then ITS GPU OC will be set to 140000 values

@ITS5_GPUOC
Scenario:VAN25388_TestStep14_refresh page or reopen Vantage and check the value of checkbox is checked
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Select ITS GPU OC checkbox checked
	Given into Dashboard page
	Given Go to Power Page
	Given jump to power smart settings section
	Then The value of GPU OC checkbox is checked
	When Launch Vantage
	Given Go to Power Page
	Given jump to power smart settings section
	Then The value of GPU OC checkbox is checked

@ITS5_GPUOC
Scenario:VAN25388_TestStep15_make checkbox unselected and check its status
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Select ITS GPU OC checkbox unchecked
	Then The value of GPU OC checkbox is unchecked

@ITS5_GPUOC
Scenario:VAN25388_TestStep16_check the value of Gpu Oc is 0
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Select ITS GPU OC checkbox unchecked
	Then ITS GPU OC will be set to 0 values

@ITS5_GPUOC
Scenario:VAN25388_TestStep17_enter S3 and check checkbox is still selected
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Select ITS GPU OC checkbox checked
	When Enter sleep
	When Launch Vantage
	Given Go to Power Page
	Given jump to power smart settings section
	Then The value of GPU OC checkbox is checked

@ITS5_GPUOC
Scenario:VAN25388_TestStep18_enter S4 and check checkbox is still selected
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Select ITS GPU OC checkbox checked
	When Enter hibernate
	When Launch Vantage
	Given Go to Power Page
	Given jump to power smart settings section
	Then The value of GPU OC checkbox is checked

@ITS5_GPUOC
Scenario:VAN25388_TestStep20_switch to ICM and check offset is 0
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Select ITS GPU OC checkbox checked
	When change ITS mode to ISTD via Vantage
	Then ITS GPU OC will be set to 0 values

@ITS5_GPUOC
Scenario:VAN25388_TestStep21_switch back EPM and checkbox is selected
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Then The value of GPU OC checkbox is checked

@ITS5_GPUOC
Scenario:VAN25388_TestStep22_switch back EPM and check offset is 140
	Then ITS GPU OC will be set to 140000 values

@ITS5_GPUOC
Scenario:VAN25388_TestStep23_switch to BSM and check offset is 0
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Select ITS GPU OC checkbox checked
	When change ITS mode to BSM via Vantage
	Then ITS GPU OC will be set to 0 values

@ITS5_GPUOC
Scenario:VAN25388_TestStep24_switch back EPM and checkbox is selected
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Then The value of GPU OC checkbox is checked

@ITS5_GPUOC
Scenario:VAN25388_TestStep25_switch back EPM and check offset is 140
	Then ITS GPU OC will be set to 140000 values

@ITS5_GPUOC
Scenario:VAN25388_TestStep26_switch to ICM and check offset is 0
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Select ITS GPU OC checkbox unchecked
	When change ITS mode to ISTD via Vantage
	Then ITS GPU OC will be set to 0 values

@ITS5_GPUOC
Scenario:VAN25388_TestStep27_switch back EPM and checkbox is unselected and offset is 0
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Then The value of GPU OC checkbox is unchecked
	Then ITS GPU OC will be set to 0 values

@ITS5_GPUOC
Scenario:VAN25388_TestStep28_switch to BSM and check offset is 0
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Select ITS GPU OC checkbox unchecked
	When change ITS mode to BSM via Vantage
	Then ITS GPU OC will be set to 0 values

@ITS5_GPUOC
Scenario:VAN25388_TestStep29_switch back EPM and checkbox is unselected and offset is 0
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Then The value of GPU OC checkbox is unchecked
	Then ITS GPU OC will be set to 0 values

@ITS5_GPUOC
Scenario:VAN25388_TestStep30_select checkbox and uninstall Vantage and check offset is 0
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Select ITS GPU OC checkbox checked
	Given Uninstall the lenovo vatage
	Then ITS GPU OC will be set to 0 values

@ITS5_GPUOC
Scenario:VAN25388_TestStep31_reinstall Vantage and checkbox is unselected
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings section
	Then The value of GPU OC checkbox is unchecked

@ITS5_GPUOC
Scenario:VAN25388_TestStep32_disconnect network and check checkbox can be selected
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Select ITS GPU OC checkbox checked
	Then The value of GPU OC checkbox is checked
	Then ITS GPU OC will be set to 140000 values

@ITS5_GPUOC
Scenario:VAN25388_TestStep33_disconnect network and check checkbox can be unselected
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Select ITS GPU OC checkbox unchecked
	Then The value of GPU OC checkbox is unchecked
	Then ITS GPU OC will be set to 0 values
	When The user connect or disconnect WiFi on lenovo

@ITS5_GPUOC
Scenario:VAN25388_TestStep34_resume network and check checkbox can be selected
	When The user connect or disconnect WiFi on lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Select ITS GPU OC checkbox checked
	Then The value of GPU OC checkbox is checked
	Then ITS GPU OC will be set to 140000 values

@ITS5_GPUOC
Scenario:VAN25388_TestStep35_resume network and check checkbox can be unselected
	When The user connect or disconnect WiFi on lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Select ITS GPU OC checkbox unchecked
	Then The value of GPU OC checkbox is unchecked
	Then ITS GPU OC will be set to 0 values

@ITS5_GPUOC
Scenario:VAN25388_TestStep36_check responsive UI
	When The user connect or disconnect WiFi on lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Change DPI to 100
	Given jump to power smart settings section
	Then Take Screen Shot 3601 in 17160 under ITSScreenShotResult
	Given Change DPI to 125
	Given jump to power smart settings section
	Then Take Screen Shot 3602 in 17160 under ITSScreenShotResult
	Given Change DPI to 150
	Given jump to power smart settings section
	Then Take Screen Shot 3603 in 17160 under ITSScreenShotResult
	Given Change DPI to 175
	Given jump to power smart settings section
	Then Take Screen Shot 3604 in 17160 under ITSScreenShotResult
	Given Change DPI to recommend

@ITS5_GPUOC 
Scenario:VAN25388_TestStep37_check offset is 0 when checkbox is selected and enter IEPM 
	When The user connect or disconnect WiFi on lenovo
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	Given Select ITS GPU OC checkbox checked
	When change ITS mode to ISTD via Vantage
	Given Turn on auto-transition
	Given run csgo
	Given Waiting 90 seconds
	Then IEPM is On
	Then ITS GPU OC will be set to 0 values

@ITS5_GPUOC 
Scenario:VAN25388_TestStep38_check offset is 0 when checkbox is unselected and enter IEPM 
	When The user connect or disconnect WiFi on lenovo
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	Given Select ITS GPU OC checkbox unchecked
	When change ITS mode to ISTD via Vantage
	Given Turn on auto-transition
	Given run csgo
	Given Waiting 90 seconds
	Then IEPM is On
	Then ITS GPU OC will be set to 0 values
	When kill csgo and wait 0 second

@ITS5_GPUOC 
Scenario:VAN25388_TestStep39_select checkbox and stop ITS service and offset should be 0
	When The user connect or disconnect WiFi on lenovo
	When kill csgo and wait 0 second
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Select ITS GPU OC checkbox checked
	Given Stop ITS Service
	Then ITS GPU OC will be set to 0 values

@ITS5_GPUOC 
Scenario:VAN25388_TestStep40_select checkbox and start ITS service and offset should be 140
	Given Start ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Then The value of GPU OC checkbox is checked
	Then ITS GPU OC will be set to 140000 values
