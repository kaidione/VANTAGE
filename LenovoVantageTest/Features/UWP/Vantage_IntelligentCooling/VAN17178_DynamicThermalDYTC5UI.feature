Feature: VAN17178_DynamicThermalDYTC5UI
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17178
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-1745
	Author: Xiaoxiong Li

@DYTC5UI  @ITSSmokeDYTC5
Scenario: VAN17178_TestStep01_check show some description and read more link follow UIspec
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for DYTC5

@DYTC5UI
Scenario: VAN17178_TestStep02_It will show all descriptions
	Given Go to Power Page
	Given jump to power smart settings section
	Given click read more
	Then Check Intelligent CoolingDesc Text for DYTC5

@DYTC5UI
Scenario: VAN17178_TestStep03_check It will pop-up a window to show how to go to Windows Performance power slider follow UIspec
	Given Go to Power Page
	Given jump to power smart settings section
	Given click more info
	Then Check Intelligent Cooling show for DYTC5Popup
	Then Take Screen Shot 03UI in 17178 under ITSScreenShotResult

@DYTC5UI
Scenario: VAN17178_TestStep04_check It will close the pop-up window
	Given Go to Power Page
	Given jump to power smart settings section
	Given click more info
	Given close popwindow
	Then Check Intelligent Cooling hide for DYTC5Popup

@DYTC5UI
Scenario: VAN17178_TestStep05_check It will close the pop-up window
	Given Go to Power Page
	Given jump to power smart settings section
	Given click more info
	Given close x icon
	Then Check Intelligent Cooling hide for DYTC5Popup

@DYTC5UI
Scenario: VAN17178_TestStep06_check It will jump to Power Smart settings section
	Given Go to Power Page
	Then Take Screen Shot 0601 in 17178 under ITSScreenShotResult
	Given jump to power smart settings section
	Then Take Screen Shot 0602 in 17178 under ITSScreenShotResult

@DYTC5UI
Scenario: VAN17178_TestStep07_check It doesn't show Intelligent Cooling UI
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for DYTC5

@DYTC5UI
Scenario: VAN17178_TestStep08_check The Intelligent Cooling UI should display
	When  The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for DYTC5
	Given click read more
	Then Check Intelligent CoolingDesc Text for DYTC5
	Given click more info
	Then Check Intelligent Cooling show for DYTC5Popup
	When  The user connect or disconnect WiFi on lenovo

@DYTC5UI
Scenario: VAN17178_TestStep09_check The Intelligent Cooling UI should display
	When  The user connect or disconnect WiFi on lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for DYTC5
	Given click read more
	Then Check Intelligent CoolingDesc Text for DYTC5
	Given click more info
	Then Check Intelligent Cooling show for DYTC5Popup

@DYTC5UI
Scenario: VAN17178_TestStep10_check The Intelligent Cooling UI should display
	When  The user connect or disconnect WiFi on lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for DYTC5
	Given click read more
	Then Check Intelligent CoolingDesc Text for DYTC5
	Given click more info
	Then Check Intelligent Cooling show for DYTC5Popup

@DYTC5UI
Scenario: VAN17178_TestStep11_change DPI Check Intelligent Cooling UI 
	Given Go to Power Page
	Given jump to power smart settings section
	Given Change DPI to 100
	Given jump to power smart settings section
	Then Take Screen Shot 1101 in 17178 under ITSScreenShotResult
	Given Change DPI to 125
	Given jump to power smart settings section
	Then Take Screen Shot 1102 in 17178 under ITSScreenShotResult
	Given Change DPI to 150
	Given jump to power smart settings section
	Then Take Screen Shot 1103 in 17178 under ITSScreenShotResult
	Given Change DPI to 175
	Given jump to power smart settings section
	Then Take Screen Shot 1104 in 17178 under ITSScreenShotResult
	Given Change DPI to 150

@DYTC5UI
Scenario: VAN17178_TestStep12_check The Intelligent Cooling UI should be hidden
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for DYTC5
	Given Stop ITS service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling hide for DYTC5

@DYTC5UI
Scenario: VAN17178_TestStep14_check The Intelligent Cooling UI should be hidden
	Given Start ITS Service
	Given Go to Power Page
	Then Check Intelligent Cooling show for DYTC5
	Given move thinkpad plugin
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling hide for DYTC5

@DYTC5UI
Scenario: VAN17178_TestStep15_recover plugin
	Given recover thinkpad plugin