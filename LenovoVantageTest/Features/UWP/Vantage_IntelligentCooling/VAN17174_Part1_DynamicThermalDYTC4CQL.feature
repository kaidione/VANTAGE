Feature: VAN17174_Part1_DynamicThermalDYTC4CQL
	Help: ITS_FullTestCase_Vantage_ITS1.0_CQL/TIO_Thinkpad_Regression Test_DYTC4.0
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17174
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-1746
	Developer: chenpj
	Total：
	Automated：1,2,3,4,5,7
	Not automated: 
		6: DPI
		8:uninstall ITS driver need reboot
		10:uninstall PM driver need reboot
		11:toggle default status
	Check ui:

Background:
	Given The Machine support Intelligent Cooling for thinkpad DYTC Four 
	Given The Machine support CQL TIO
	When Start services for intelligent cooling both
	Given Go to Power Page
	Given Jump to power smart settings section

@ThinkDytc4CQL  @ITSSmokeDYTC4CQL
Scenario: VAN17174_TestStep01_Check Intelligent Cooling description and toggle is on
	Given Read Intelligent cooling run mark for all test case
	Given Turn on Intellgentcooling toggle
	Then Check Intelligent Cooling hide for Perf&CQ
	Then Check Intelligent CoolingDesc Text for DYTC4CQL

@ThinkDytc4CQL  @ITSSmokeDYTC4CQL
Scenario: VAN17174_TestStep02_Check Intelligent Cooling description and toggle is off
	Given Read Intelligent cooling run mark for all test case
	Given Turn off Intellgentcooling toggle
	Then Check Intelligent Cooling show for Perf&CQ
	Then Check Intelligent Cooling show for DYTC4CQL

@ThinkDytc4CQL
Scenario: VAN17174_TestStep03_Check Intelligent Cooling Jumplink
	Given Read Intelligent cooling run mark for all test case
	Given Go to Power Page
	Then  There should have Power Smart settings Jump link
	Then Take Screen Shot TestStep03_01 in 17174 under ITSScreenShotResult
	Given Jump to power smart settings section
	Then Take Screen Shot TestStep03_02 in 17174 under ITSScreenShotResult

@ThinkDytc4CQL
Scenario: VAN17174_TestStep05_Check Intelligent Cooling feature not show within Toolbar
	Given Read Intelligent cooling run mark for all test case
	When Launch toolbar
	Then Take Screen Shot TestStep05 in 17174 under ITSScreenShotResult

@ThinkDytc4CQL
Scenario: VAN17174_TestStep06_Check the Intelligent Cooling UI should display reasonable
	Given Read Intelligent cooling run mark for all test case
	Given Change DPI to 100
	Given jump to power smart settings section
	Then Take Screen Shot 0501 in 17174 under ITSScreenShotResult
	Given Change DPI to 125
	Given jump to power smart settings section
	Then Take Screen Shot 0502 in 17174 under ITSScreenShotResult
	Given Change DPI to 150
	Given jump to power smart settings section
	Then Take Screen Shot 0503 in 17174 under ITSScreenShotResult
	Given Change DPI to 175
	Given jump to power smart settings section
	Then Take Screen Shot 0504 in 17174 under ITSScreenShotResult
	Given Change DPI to recommend

@ThinkDytc4CQL
Scenario: VAN17174_TestStep07_Check Stop ITS Services Intelligent Cooling feature not show
	Given Read Intelligent cooling run mark for all test case
	Given Stop ITS service
	Given Go to Power Page
	Then Check Intelligent Cooling Hide for DYTC4CQL

@ThinkDytc4CQL
Scenario: VAN17174_TestStep09_Check Delete plugin Intelligent Cooling feature not show
	Given Read Intelligent cooling run mark for all test case
	Given Go to Power Page
	Given Turn off Intellgentcooling toggle
	Then The Intelligent Cooling feature will show or hide for all intelligent cooling show
	When The user delete plugin for intelligent cooling jp
	Given Go to Power Page
	Then The Intelligent Cooling feature will show or hide for all intelligent cooling hide
	Then Reset plugin for intelligent cooling jp

@ThinkDytc4CQL
Scenario: VAN17174_TestStep12_Check Intelligent Cooling toggle is on
	Then Reset plugin for intelligent cooling jp
	Given Go to dashboad page
	Given Go to Power Page
	Given Jump to power smart settings section
	Given Read Intelligent cooling run mark for all test case
	Given Turn on Intellgentcooling toggle
	Then Turn On Toggle State

@ThinkDytc4CQL
Scenario: VAN17174_TestStep13_Check Intelligent Cooling toggle is off
	Then Reset plugin for intelligent cooling jp
	Given Read Intelligent cooling run mark for all test case
	Given Turn off Intellgentcooling toggle
	Then Turn Off Toggle State Normal

@ThinkDytc4CQL
Scenario: VAN17174_TestStep14_Check Intelligent Cooling default mode is performance
	Given Read Intelligent cooling run mark for all test case
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Given Turn on Intellgentcooling toggle
	Given Turn off Intellgentcooling toggle
	Then Switch Performance Mode Normal

@ThinkDytc4CQL
Scenario: VAN17174_TestStep15_Check Intelligent Cooling mode is performance
	Given Read Intelligent cooling run mark for all test case
	Given Turn on Intellgentcooling toggle
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Then Switch Performance Mode Normal

@ThinkDytc4CQL
Scenario: VAN17174_TestStep16_Check Intelligent Cooling mode is cool quiet
	Given Read Intelligent cooling run mark for all test case
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Then Switch CoolQuiet Mode Normal

@ThinkDytc4CQL
Scenario: VAN17174_TestStep17_Check Fast switch mode and Intelligent Cooling work is ok
	Given Read Intelligent cooling run mark for all test case
	Given Turn off Intellgentcooling toggle
	Then Fast Switch IntelligentCooling Mode

@ThinkDytc4CQL
Scenario: VAN17174_TestStep18_Check Fast switch toggle and Intelligent Cooling work is ok
	Given Read Intelligent cooling run mark for all test case
	Given Turn off Intellgentcooling toggle
	Then Fast Switch IntelligentCooling toggle

@ThinkDytc4CQL
Scenario: VAN17174_TestStep19_Check restart ITS service toggle status is off
	Given Turn off Intellgentcooling toggle
	Given Restart ITS Service
	Then Turn Off Toggle State Normal

@ThinkDytc4CQL
Scenario: VAN17174_TestStep20_Check restart ITS service toggle status is on
	Given Turn on Intellgentcooling toggle
	Given Restart ITS Service
	Then Turn On Toggle State

@ThinkDytc4CQL
Scenario: VAN17174_TestStep21_Check restart ITS service mode is performance mdoe
	Given Turn off Intellgentcooling toggle
	Given Restart ITS Service
	Given Switch performance mode
	Then Switch Performance Mode Normal

@ThinkDytc4CQL
Scenario: VAN17174_TestStep22_Check restart ITS service mode is cool&quiet mdoe
	Given Turn off Intellgentcooling toggle
	Given Restart ITS Service
	Given Switch coolquiet mode
	Then Switch CoolQuiet Mode Normal

@ThinkDytc4CQL
Scenario: VAN17174_TestStep23_Check  reinstall vantage INtelligent Cooling toggle status is off_34
	Given Turn off Intellgentcooling toggle
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Turn Off Toggle State Normal

@ThinkDytc4CQL
Scenario: VAN17174_TestStep24_Check  reinstall vantage INtelligent Cooling toggle status is on_35
	Given Turn on Intellgentcooling toggle
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Turn On Toggle State

@ThinkDytc4CQL
Scenario: VAN17174_TestStep25_Check  reinstall vantage INtelligent Cooling mode is performance_36
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Turn Off Toggle State Normal
	Then Switch Performance Mode Normal

@ThinkDytc4CQL
Scenario: VAN17174_TestStep26_Check  reinstall vantage INtelligent Cooling mode is cool&quiet_37
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Turn Off Toggle State Normal
	Then Switch CoolQuiet Mode Normal	

@ThinkDytc4CQL
Scenario: VAN17174_TestStep27_Check the Intelligent Cooling toggle status is on_23
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Then Turn On Toggle State

@ThinkDytc4CQL
Scenario: VAN17174_TestStep28_Check the Intelligent Cooling toggle status is off_24
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Turn Off Toggle State Normal

@ThinkDytc4CQL
Scenario: VAN17174_TestStep29_Check the Intelligent Cooling toggle status is perfoemance_25
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Then Turn Off Toggle State Normal
	Then Switch Performance Mode Normal

@ThinkDytc4CQL
Scenario: VAN17174_TestStep30_Check the Intelligent Cooling toggle status is cool&quiet_26
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Then Turn Off Toggle State Normal
	Then Switch CoolQuiet Mode Normal

@ThinkDytc4CQL
Scenario: VAN17174_TestStep31_Check refresh power page Intellignet Cooling toggle status is on_27
    When The user connect or disconnect WiFi on lenovo	
	Given Turn on Intellgentcooling toggle
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn On Toggle State

@ThinkDytc4CQL
Scenario: VAN17174_TestStep32_Check refresh power page Intellignet Cooling toggle status is off_28
    When The user connect or disconnect WiFi on lenovo
	Given Turn off Intellgentcooling toggle
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn Off Toggle State Normal

@ThinkDytc4CQL
Scenario: VAN17174_TestStep33_Check refresh power page Intellignet Cooling mode is performance_29
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Given Go to Power Page
	Given jump to power smart settings section
	Then Switch Performance Mode Normal

@ThinkDytc4CQL
Scenario: VAN17174_TestStep34_Check refresh power page Intellignet Cooling mode is cool&quiet_30
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Given Go to Power Page
	Given jump to power smart settings section
	Then Switch CoolQuiet Mode Normal

@ThinkDytc4CQL
Scenario: VAN17174_TestStep35_Check S3 power page Intellignet Cooling toggle status is off_31
	Given Turn off Intellgentcooling toggle
	When Enter sleep
	Then Turn Off Toggle State Normal

@ThinkDytc4CQL
Scenario: VAN17174_TestStep36_Check S4 power page Intellignet Cooling toggle status is on_32
	Given Turn on Intellgentcooling toggle
	When Enter hibernate
	Then Turn On Toggle State
    When The user connect or disconnect WiFi on lenovo

@ThinkDytc4CQL
Scenario: VAN17174_TestStep_connect WiFi
	When The user connect or disconnect WiFi on lenovo