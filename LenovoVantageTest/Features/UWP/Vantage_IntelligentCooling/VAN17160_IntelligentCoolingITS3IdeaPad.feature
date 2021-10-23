Feature: VAN17160_IntelligentCoolingITS3IdeaPad
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17160
	Author ：Yang Liu

@ITS3UI  @ITSSmokeITS3
Scenario:VAN17160_TestStep01_check the "Performance" and "Cool & quiet" mode will be hide
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Then Check Intelligent Cooling hide for Perf&CQ
	Then Check Intelligent CoolingDesc Text for ITS3

@ITS3UI  @ITSSmokeITS3
Scenario:VAN17160_TestStep02_check the "Performance" and "Cool & quiet" mode will be show
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Check Intelligent Cooling show for Perf&CQ
	Then Check Intelligent CoolingDesc Text for ITS3

@ITS3UI
Scenario:VAN17160_TestStep03_check jump link function
	Given Go to Power Page
	Then Take Screen Shot 0301 in 17160 under ITSScreenShotResult
	Given jump to power smart settings section
	Then Take Screen Shot 0302 in 17160 under ITSScreenShotResult

@ITS3UI_Unsupport
Scenario:VAN17160_TestStep04_unsupport machine check it doesn't show Intelligent Cooling UI in Power Smart Settings
	Given Go to Power Page
	Then Check Intelligent Cooling hide for ITS3

@ITS3UI
Scenario:VAN17160_TestStep05_check the Intelligent Cooling UI should display reasonable
	Given Go to Power Page
	Given jump to power smart settings section
	Given Change DPI to 100
	Given jump to power smart settings section
	Then Take Screen Shot 0501 in 17160 under ITSScreenShotResult
	Given Change DPI to 125
	Given jump to power smart settings section
	Then Take Screen Shot 0502 in 17160 under ITSScreenShotResult
	Given Change DPI to 150
	Given jump to power smart settings section
	Then Take Screen Shot 0503 in 17160 under ITSScreenShotResult
	Given Change DPI to 175
	Given jump to power smart settings section
	Then Take Screen Shot 0504 in 17160 under ITSScreenShotResult
	Given Change DPI to recommend

@ITS3UI
Scenario:VAN17160_TestStep06_check the Intelligent Cooling UI should be hidden
	Given Change DPI to recommend
	Given Stop ITS Service
	Given Go to Power Page
	Then Check Intelligent Cooling hide for ITS3
	Given Start ITS Service

@ITS3UI
Scenario:VAN17160_TestStep08_check the Intelligent Cooling UI should be hidden
	Given Go to Power Page
	When The user delete plugin for intelligent cooling cn
	Given into Dashboard page
	Given Go to Power Page
	Then Check Intelligent Cooling hide for ITS3
	Given recoverplugin

@ITS3UI
Scenario:VAN17160_TestStep10_check the Intelligent Cooling toggle status is on
	Given recoverplugin
	Given Restart ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn On Toggle State

@ITS3UI
Scenario:VAN17160_TestStep11_check the Intelligent Cooling toggle status is on
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Then Turn On Toggle State

@ITS3UI
Scenario:VAN17160_TestStep12_check the Intelligent Cooling toggle status is off
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Turn Off Toggle State Normal

@ITS3UI
Scenario:VAN17160_TestStep13_check Intelligent Cooling Toggle Status within Power SmartSettings Page can be synchronized
	Given turn on narrator
	Given launch toolbar
	Given change ITS mode to Auto via Toolbar
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn On Toggle State

@ITS3UI
Scenario:VAN17160_TestStep14_check Intelligent Cooling Toggle Status within Power SmartSettings Page can be synchronized
	Given launch toolbar
	Given change ITS mode to Perf via Toolbar
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn Off Toggle State Normal
	Given turn off narrator

@ITS3UI
Scenario:VAN17160_TestStep15_check the Intelligent Cooling default mode is Performance when toggle is off
	Given turn off narrator
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Given Turn on Intellgentcooling toggle
	Given Turn off Intellgentcooling toggle
	Then Switch Performance Mode Normal

@ITS3UI
Scenario:VAN17160_TestStep16_check the Intelligent Cooling mode is Performance
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Then Switch Performance Mode Normal

@ITS3UI
Scenario:VAN17160_TestStep17_check the Intelligent Cooling mode is Cool & quiet
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Then Switch CoolQuiet Mode Normal

@ITS3UI
Scenario:VAN17160_TestStep18_check fast switching Intelligent Cooling mode, the ITS work is OK
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Fast Switch IntelligentCooling Mode

@ITS3UI
Scenario:VAN17160_TestStep19_check fast switching Intelligent Cooling mode, the ITS work is OK
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Fast Switch IntelligentCooling toggle

@ITS3UI
Scenario:VAN17160_TestStep24_check the Intelligent Cooling toggle status will be reset to default status and toggle default status is on
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Restart ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn On Toggle State

@ITS3UI
Scenario:VAN17160_TestStep25_check the Intelligent Cooling toggle status will be reset to default status and toggle default status is on
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Given Restart ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn On Toggle State

@ITS3UI
Scenario:VAN17160_TestStep26_check the Intelligent Cooling toggle status will be reset to default status and toggle default status is on
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Given Restart ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn On Toggle State

@ITS3UI
Scenario:VAN17160_TestStep27_check the Intelligent Cooling toggle status will be reset to default status and toggle default status is on
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Given Restart ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn On Toggle State

@ITS3UIS3S4
Scenario:VAN17160_TestStep28_check the Intelligent Cooling mode can't be changed and the Intelligent Cooling toggle status can't be changed
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Given Turn off Intellgentcooling toggle
	When Enter sleep
	When Wait '300' seconds until the machine enters the system 
	Then Turn Off Toggle State Normal
	Then Switch Performance Mode Normal

@ITS3UIS3S4
Scenario:VAN17160_TestStep29_check the Intelligent Cooling mode can't be changed and the Intelligent Cooling toggle status can't be changed
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	When Enter hibernate
	When Wait '300' seconds until the machine enters the system 
	Then Turn On Toggle State

@ITS3UI_DisconnectNetwork
Scenario:VAN17160_TestStep39_check the Intelligent Cooling toggle status is on 31
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Then Turn On Toggle State

@ITS3UI_DisconnectNetwork
Scenario:VAN17160_TestStep40_check the Intelligent Cooling toggle status is off 32
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Turn Off Toggle State Normal

@ITS3UI_DisconnectNetwork
Scenario:VAN17160_TestStep41_check the Intelligent Cooling mode is Performance 33
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Then Switch Performance Mode Normal

@ITS3UI_DisconnectNetwork
Scenario:VAN17160_TestStep42_check the Intelligent Cooling mode is Cool & quiet 34
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Then Switch CoolQuiet Mode Normal
	When The user connect or disconnect WiFi on lenovo

@ITS3UI
Scenario:VAN17160_TestStep35_check the Intelligent Cooling toggle status is on
	When The user connect or disconnect WiFi on lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn On Toggle State

@ITS3UI
Scenario:VAN17160_TestStep36_check the Intelligent Cooling toggle status is off
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn Off Toggle State Normal

@ITS3UI
Scenario:VAN17160_TestStep37_check the Intelligent Cooling mode is Performance
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Given Go to Power Page
	Given jump to power smart settings section
	Then Switch Performance Mode Normal

@ITS3UI
Scenario:VAN17160_TestStep38_check the Intelligent Cooling mode is Cool & quiet
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Given Go to Power Page
	Given jump to power smart settings section
	Then Switch CoolQuiet Mode Normal

@ITS3UI
Scenario:VAN17160_TestStep31_check the Intelligent Cooling toggle status is off 39
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Turn Off Toggle State Normal

@ITS3UI
Scenario:VAN17160_TestStep32_check the Intelligent Cooling toggle status is on 40
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Turn On Toggle State

@ITS3UI
Scenario:VAN17160_TestStep33_check the Intelligent Cooling mode is Performance 41
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Switch Performance Mode Normal

@ITS3UI
Scenario:VAN17160_TestStep34_check the Intelligent Cooling mode is Cool & quiet 42
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Switch CoolQuiet Mode Normal

@ITS3UI_Metrics
Scenario: VAN17160_A_beforetest
    Given Set Metric on
	And Launch Http Traffic Capturer
	And Start Capture 

@ITS3UI_Metrics
Scenario:VAN17160_TestStep44_check the metric data within Fiddler
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Given clear data
	Given Switch coolquiet mode
	Then the metric data is as expected with Test VAN17160 and Name CoolQuietValueOn and Timeout 20

@ITS3UI_Metrics
Scenario: VAN17160_Z_Resandbox
	Given Stop Capture
