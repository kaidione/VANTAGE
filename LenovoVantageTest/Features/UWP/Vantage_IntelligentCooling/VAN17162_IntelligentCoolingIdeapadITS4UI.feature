Feature: VAN17162_IntelligentCoolingIdeapadITS4UI
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17162
	Developer: Huajie

@ITS4UI  @ITSSmokeITS4
Scenario: VAN17162_TestStep01_Check the total description 
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for ITS4
	Then Check Intelligent CoolingDesc Text for ITS4

@ITS4UI  @ITSSmokeITS4
Scenario: VAN17162_TestStep02_Check Intelligent Cooling description 
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to ISTD via Vantage
	Then Check Intelligent CoolingDesc Text for ITS4ICM

@ITS4UI  @ITSSmokeITS4
Scenario: VAN17162_TestStep03_Check Battery Saving description 
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to BSM via Vantage
	Then Check Intelligent CoolingDesc Text for ITS4BSM

@ITS4UI  @ITSSmokeITS4
Scenario: VAN17162_TestStep04_Check Extreme Performance description 
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Then Check Intelligent CoolingDesc Text for ITS4EPM

@ITS4UI
Scenario: VAN17162_TestStep05_Check the jump link function
	Given Go to Power Page
	Then Take Screen Shot 0501 in 17162 under ITSScreenShotResult
	Given jump to power smart settings section
	Then Take Screen Shot 0502 in 17162 under ITSScreenShotResult

@ITS4UI_Unsupported
Scenario: VAN17162_TestStep06_Check ITS feature hide with unsupported machine
	When Click the Power icon
	When Check Open Power page
	Then Check Intelligent Cooling hide for ITS4

@ITS4UI
Scenario: VAN17162_TestStep07_Check ITS4 UI with different DPI
	Given Go to Power Page
	Given jump to power smart settings section
	Given Change DPI to 100
	Then Take Screen Shot 0701 in 17162 under ITSScreenShotResult
	Given Change DPI to 125
	Given jump to power smart settings section
	Then Take Screen Shot 0702 in 17162 under ITSScreenShotResult
	Given Change DPI to 150
	Given jump to power smart settings section
	Then Take Screen Shot 0703 in 17162 under ITSScreenShotResult
	Given Change DPI to 175
	Given jump to power smart settings section
	Then Take Screen Shot 0704 in 17162 under ITSScreenShotResult
	Given SetWindowSize
	Given jump to power smart settings section
	Then Take Screen Shot 0705 in 17162 under ITSScreenShotResult
	Given Change DPI to recommend

@ITS4UI
Scenario: VAN17162_TestStep08_Stop ITS service and check UI hide
	Given Go to Power Page
	Then Check Intelligent Cooling show for ITS4
	Given Stop ITS service
	Given Go to Power Page
	Then Check Intelligent Cooling hide for ITS4
	Given Start ITS Service

@ITS4UI
Scenario: VAN17162_TestStep10_Delete ITS plugin and check UI hide
	Given Go to Power Page
	Then Check Intelligent Cooling show for ITS4
	Given moveplugin
	Given Go to Power Page
	Then Check Intelligent Cooling hide for ITS4
	Given recoverplugin

@ITS4UI
Scenario: VAN17162_TestStep12_Check ITS4 default mode is ICM
	Given recoverplugin
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Restart ITS Service
	Given Go to Power Page
	Then Vantage ITS ICM On

@ITS4UI
Scenario: VAN17162_TestStep13_Check EPM is selected
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Go to Power Page
	Then Vantage ITS EPM On

@ITS4UI
Scenario: VAN17162_TestStep14_Check ICM is selected
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to ISTD via Vantage
	Given Go to Power Page
	Then Vantage ITS ICM On

@ITS4UI
Scenario: VAN17162_TestStep15_Check BSM is selected
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to BSM via Vantage
	Given Go to Power Page
	Then Vantage ITS BSM On

@ITS4UI
Scenario: VAN17162_TestStep16_Select EPM via Toolbar and check sync
	Given turn on narrator 
	Given launch toolbar
	Given change ITS mode to EPM via Toolbar
	Given Go to Power Page
	Given jump to power smart settings section
	Given Go to Power Page
	Then Vantage ITS EPM On

@ITS4UI
Scenario: VAN17162_TestStep17_Select ICM via Toolbar and check sync
	Given launch toolbar
	Given change ITS mode to ICM via Toolbar
	Given Go to Power Page
	Given jump to power smart settings section
	Given Go to Power Page
	Then Vantage ITS ICM On

@ITS4UI
Scenario: VAN17162_TestStep18_Select BSM via Toolbar and check sync
	Given launch toolbar
	Given change ITS mode to BSM via Toolbar
	Given Go to Power Page
	Given jump to power smart settings section
	Given Go to Power Page
	Then Vantage ITS BSM On
	Given turn off narrator 

@ITS4UI
Scenario: VAN17162_TestStep19_Restart ITS service and set to ICM
	Given turn off narrator 
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Restart ITS Service
	Given Go to Power Page
	Then Vantage ITS ICM On

@ITS4UI
Scenario: VAN17162_TestStep20_Restart ITS service and set to ICM
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to ISTD via Vantage
	Given Restart ITS Service
	Given Go to Power Page
	Then Vantage ITS ICM On

@ITS4UI
Scenario: VAN17162_TestStep21_Restart ITS service and set to ICM
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to BSM via Vantage
	Given Restart ITS Service
	Given Go to Power Page
	Then Vantage ITS ICM On

@ITS4UI
Scenario: VAN17162_TestStep23_Turn off network and check UI
	When  The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to ISTD via Vantage
	Given Go to Power Page
	Then Vantage ITS ICM On

@ITS4UI
Scenario: VAN17162_TestStep24_Turn off network and check UI
	When  The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given Go to Power Page
	Then Vantage ITS EPM On

@ITS4UI
Scenario: VAN17162_TestStep25_Turn off network and check UI
	When  The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	When change ITS mode to BSM via Vantage
	Given Go to Power Page
	Then Vantage ITS BSM On

@ITS4UI
Scenario: VAN17162_TestStep26_Turn on network and check EPM is selected
	When  The user connect or disconnect WiFi on lenovo
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	Given Go to Power Page
	Then Vantage ITS EPM On

@ITS4UI
Scenario: VAN17162_TestStep27_Turn on network and check ICM is selected
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	Given Go to Power Page
	Then Vantage ITS ICM On

@ITS4UI
Scenario: VAN17162_TestStep28_Turn on network and check BSM is selected
	Given Go to Power Page
	When change ITS mode to BSM via Vantage
	Given Go to Power Page
	Then Vantage ITS BSM On

@ITS4UI
Scenario: VAN17162_TestStep29_Reinstall Vantage and check EPM is keeped
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	Given Install Vantage
	Given Go to Power Page
	Then Vantage ITS EPM On

@ITS4UI
Scenario: VAN17162_TestStep30_Reinstall Vantage and check ICM is keeped
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	Given Install Vantage
	Given Go to Power Page
	Then Vantage ITS ICM On

@ITS4UI
Scenario: VAN17162_TestStep31_Reinstall Vantage and check BSM is keeped
	Given Go to Power Page
	When change ITS mode to BSM via Vantage
	Given Install Vantage
	Given Go to Power Page
	Then Vantage ITS BSM On

@ITS4UIS3S4
Scenario: VAN17162_TestStep36_S3 and check mode is keeped
	Given Go to Power Page
	When change ITS mode to BSM via Vantage
	When Enter sleep
	Given Go to Power Page
	Then Vantage ITS BSM On
	When The user connect or disconnect WiFi on lenovo

@ITS4UIS3S4
Scenario: VAN17162_TestStep37_S4 and check mode is keeped
	When The user connect or disconnect WiFi on lenovo
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	When Enter hibernate
	Given Go to Power Page
	Then Vantage ITS ICM On
