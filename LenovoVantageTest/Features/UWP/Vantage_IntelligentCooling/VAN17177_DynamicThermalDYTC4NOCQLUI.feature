Feature: VAN17177_DynamicThermalDYTC4NOCQLUI
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17177
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-1747
	Developer: Huajie

@DYTC4NOCQLUI  @ITSSmokeDYTC4NOCQL
Scenario: VAN17177_TestStep01_Check Power Smart Settings UI 
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling Show for DYTC4NOCQL
	Then Check Intelligent CoolingDesc Text for DYTC4NOCQL

@DYTC4NOCQLUI
Scenario: VAN17177_TestStep02_Check Power Smart Settings jump link
	Given Go to Power Page
	Then Take Screen Shot 0201 in 17177 under ITSScreenShotResult
	Given jump to power smart settings section
	Then Take Screen Shot 0202 in 17177 under ITSScreenShotResult

@DYTC4NOCQLUIUnsupport
Scenario: VAN17177_TestStep03_Check unsupport machine doesn't show DYTC4NOCQLUI
	When Click the Power icon
	When Check Open Power page
	Then Check Intelligent Cooling Hide for DYTC4NOCQL

@DYTC4NOCQLUI
Scenario: VAN17177_TestStep04_Check toolbar doesn't show feature
	Given launch toolbar
	Then Take Screen Shot 0401 in 17177 under ITSScreenShotResult

@DYTC4NOCQLUI
Scenario: VAN17177_TestStep05_Check UI feature with different DPI
	Given Go to Power Page
	Given Change DPI to 100
	Given jump to power smart settings section
	Then Take Screen Shot 1101 in 17177 under ITSScreenShotResult
	Given Change DPI to 125
	Given jump to power smart settings section
	Then Take Screen Shot 1102 in 17177 under ITSScreenShotResult
	Given Change DPI to 150
	Given jump to power smart settings section
	Then Take Screen Shot 1103 in 17177 under ITSScreenShotResult
	Given Change DPI to 175
	Given jump to power smart settings section
	Then Take Screen Shot 1104 in 17177 under ITSScreenShotResult
	Given Change DPI to 150

@DYTC4NOCQLUI
Scenario: VAN17177_TestStep06_Stop service UI don't show
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling Show for DYTC4NOCQL
	Then Check Intelligent CoolingDesc Text for DYTC4NOCQL
	Given Stop ITS service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling hide for DYTC4NOCQL
	Given Start ITS Service

@DYTC4NOCQLUI
Scenario: VAN17177_TestStep08_Delete Plugin UI don't show
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling Show for DYTC4NOCQL
	Then Check Intelligent CoolingDesc Text for DYTC4NOCQL
	Given move thinkpad plugin
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling hide for DYTC4NOCQL
	Given recover thinkpad plugin

@DYTC4NOCQLUI
Scenario: VAN17177_TestStep11_Performance mode is selected
	Given recover thinkpad plugin
	Given Go to Power Page
	Given jump to power smart settings section
	Given Switch performance mode
	Then Switch Performance Mode Normal

@DYTC4NOCQLUI
Scenario: VAN17177_TestStep12_Cool&Quiet mode is selected
	Given Go to Power Page
	Given jump to power smart settings section
	Given Switch coolquiet mode
	Then Switch CoolQuiet Mode Normal

@DYTC4NOCQLUI
Scenario:VAN17177_TestStep13_Fast switching Intelligent Cooling mode Legacy Function work is OK
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Fast Switch IntelligentCooling Mode

@DYTC4NOCQLUI
Scenario:VAN17177_TestStep14_Restart ITS service and check Performance mode is selected
	Given Go to Power Page
	Given jump to power smart settings section
	Given Switch performance mode
	Given Restart ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Switch Performance Mode Normal

@DYTC4NOCQLUI
Scenario:VAN17177_TestStep15_Restart ITS service and check Cool&Quiet mode is selected
	Given Go to Power Page
	Given jump to power smart settings section
	Given Switch coolquiet mode
	Given Restart ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Switch CoolQuiet Mode Normal

@DYTC4NOCQLUI
Scenario:VAN17177_TestStep16_reinstall vantage and check Performance mode23
	Given Go to Power Page
	Given jump to power smart settings section
	Given Switch performance mode
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings section
	Then Switch Performance Mode Normal

@DYTC4NOCQLUI
Scenario:VAN17177_TestStep17_reinstall vantage and check Cool&Quiet mode24
	Given Go to Power Page
	Given jump to power smart settings section
	Given Switch coolquiet mode
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings section
	Then Switch CoolQuiet Mode Normal

@DYTC4NOCQLUI
Scenario:VAN17177_TestStep18_Offline and select Performance mode16
	When The user connect or disconnect WiFi off lenovo	
	Given Go to Power Page
	Given jump to power smart settings section
	Given Switch performance mode
	Then Switch Performance Mode Normal

@DYTC4NOCQLUI
Scenario:VAN17177_TestStep19_Offline and select Cool&Quiet mode17	
	Given Go to Power Page
	Given jump to power smart settings section
	Given Switch coolquiet mode
	Then Switch CoolQuiet Mode Normal
	When The user connect or disconnect WiFi on lenovo	

@DYTC4NOCQLUI
Scenario:VAN17177_TestStep20_Refresh and select Performance mode18
	When The user connect or disconnect WiFi on lenovo	
	Given Go to Power Page
	Given jump to power smart settings section
	Given Switch performance mode
	Then Switch Performance Mode Normal

@DYTC4NOCQLUI
Scenario:VAN17177_TestStep21_Refresh and select Performance mode19
	Given Go to Power Page
	Given jump to power smart settings section
	Given Switch coolquiet mode
	Then Switch CoolQuiet Mode Normal

@DYTC4NOCQLUIS3S4
Scenario:VAN17177_TestStep22_S3 and check feature20
	Given Go to Power Page
	Given jump to power smart settings section
	Given Switch performance mode
	When Enter sleep
	Then Switch Performance Mode Normal

@DYTC4NOCQLUIS3S4
Scenario:VAN17177_TestStep23_S4 and check feature21
	Given Go to Power Page
	Given jump to power smart settings section
	Given Switch coolquiet mode
	When Enter hibernate
	Then Switch CoolQuiet Mode Normal

