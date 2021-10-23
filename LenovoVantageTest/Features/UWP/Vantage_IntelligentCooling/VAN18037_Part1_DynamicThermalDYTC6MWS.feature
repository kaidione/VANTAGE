Feature: VAN18037_Part1_DynamicThermalDYTC6MWS
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-18037
	Author: Pengjie Chen (TestStep: 1,2,3,4,5,6,7,8,9,13,14,15)
	Author: Xiaoxiong Li (TestStep: 10,11,12)

	Author: Pengjie Chen (TestStep: 1,2,3,4,5,6,7,8,9,13,14,15)
	Author: Xiaoxiong Li (TestStep: 10,11,12)

Background: 
	Given The Machine support Intelligent Cooling for Thinkpad DYTC Six
	Given The Machine is CS20 CS21 Machine
	Given Go to Power Page
	Given Jump to power smart settings section

@IntelligentCooling_18037  @ITSSmokeDYTC6MWS
Scenario: VAN18037_TestStep02_Check Intelligent Cooling feature will show
	Given Read Intelligent cooling run mark for all test case
	When The User click Intelligent Cooling more link for Thinkpad DYTC Six CS20 CS21
	Then The Intelligent Cooling feature will show for Thinkpad DYTC Six CS20 CS21

@IntelligentCooling_18037
Scenario: VAN18037_TestStep03_Check jump link text and ui
	Given Read Intelligent cooling run mark for all test case
	Given Go to Power Page
	Then  There should have Power Smart settings Jump link
	Then Take Screen Shot TestStep03_01 in 18037 under ITSScreenShotResult
	Given Jump to power smart settings section
	Then Take Screen Shot TestStep03_02 in 18037 under ITSScreenShotResult

@IntelligentCooling_18037
Scenario: VAN18037_TestStep04_Check Default Collapse button should be display
    Given Read Intelligent cooling run mark for all test case
	Given Go to Power Page
	Then Check default Collapse should be display

@IntelligentCooling_18037
Scenario: VAN18037_TestStep05_Check Intelligent Cooling container card Collapse Intelligent Cooling feature is hidden
	Given Read Intelligent cooling run mark for all test case
	When The User click Intelligent Cooling container to Expand card
	Then The Intelligent Cooling feature will show or hide for container collapse expand hide

@IntelligentCooling_18037
Scenario: VAN18037_TestStep06_Check Intelligent Cooling container card expand Intelligent Cooling feature is show
	Given Read Intelligent cooling run mark for all test case
	When The User click Intelligent Cooling container to Expand card
	When The User click Intelligent Cooling container to Collapse card
	Then The Intelligent Cooling feature will show or hide for container collapse expand show

@IntelligentCooling_18037
Scenario: VAN18037_TestStep07_Check Intelligent Cooling All description show
	Given Read Intelligent cooling run mark for all test case
	When The User click Intelligent Cooling more link for Thinkpad DYTC Six CS20 CS21
	Then The Intelligent Cooling will show all descriptions on Power Smart Settings section

@IntelligentCooling_18037
Scenario: VAN18037_TestStep08_Check Intelligent Cooling All description hide
	Given Read Intelligent cooling run mark for all test case
	When The User click Intelligent Cooling more link for Thinkpad DYTC Six CS20 CS21
	When The User click Intelligent Cooling less link for Thinkpad DYTC Six CS20 CS21
	Then The Intelligent Cooling will hide all descriptions on Power Smart Settings section

@IntelligentCooling_18037
Scenario: VAN18037_TestStep09_Check Intelligent Cooling All description is coreect
	Given Read Intelligent cooling run mark for all test case
	When The User click Intelligent Cooling more link for Thinkpad DYTC Six CS20 CS21
	Then Take Screen Shot TestStep09 in 18037 under ITSScreenShotResult
	Then Check Intelligent CoolingDesc Text for DYTC6MWS

@IntelligentCooling_18037
Scenario: VAN18037_TestStep10_User adjusts vantage app window size check Intelligent Cooling UI
	Given Go to Power Page
	Given click power smart settings
	When The User click Intelligent Cooling more link for Thinkpad DYTC Six CS20 CS21
	Given adjusts window size 
	Then Take Screen Shot 10UI in 18037 under ITSScreenShotResult

@IntelligentCooling_18037
Scenario: VAN18037_TestStep11_User adjust the DPI to 100%125%150%175% check Intelligent Cooling UI
	Given Change DPI to 100
	Then Take Screen Shot 1101UI in 18037 under ITSScreenShotResult
	Given Change DPI to 125
	Then Take Screen Shot 1102UI in 18037 under ITSScreenShotResult
	Given Change DPI to 150
	Then Take Screen Shot 1103UI in 18037 under ITSScreenShotResult
	Given Change DPI to 175
	Then Take Screen Shot 1104UI in 18037 under ITSScreenShotResult
	Given Change DPI to 250

@IntelligentCooling_18037
Scenario: VAN18037_TestStep12_User Adjust the resolution check Intelligent Cooling UI
	Given change resolution 1920 to 1080
	Then Take Screen Shot 1201UI in 18037 under ITSScreenShotResult
	Given change resolution 1600 to 1900
	Then Take Screen Shot 1202UI in 18037 under ITSScreenShotResult
	Given change resolution 1280 to 1024
	Then Take Screen Shot 1203UI in 18037 under ITSScreenShotResult
	Given change resolution 1280 to 720
	Then Take Screen Shot 1204UI in 18037 under ITSScreenShotResult
	Given change resolution 3840 to 2160

@ThinkDytc6CS2021S3S4_18037
Scenario: VAN18037_TestStep13_01_Check Intelligent Cooling feature is exist after user resume machine form S3 S4
	Given Read Intelligent cooling run mark for all test case
	Then The Intelligent Cooling feature will show or hide for container collapse expand show
	When Enter sleep
	Then The Intelligent Cooling feature will show or hide for container collapse expand show
	When Enter hibernate
	Then The Intelligent Cooling feature will show or hide for container collapse expand show

@IntelligentCooling_18037
Scenario: VAN18037_TestStep14_Check Intelligent Cooling feature is normal after user relaunch Vantage
	Given Read Intelligent cooling run mark for all test case
	Then The Intelligent Cooling feature will show or hide for container collapse expand show
	Given Go to Power Page
	Given Jump to power smart settings section
	Then The Intelligent Cooling feature will show or hide for container collapse expand show

@IntelligentCooling_18037
Scenario: VAN18037_TestStep15_Check Intelligent Cooling feature Intelligent Cooling images is exist
	Given Read Intelligent cooling run mark for all test case
	Then The Intelligent Cooling feature images will show for Thinkpad DYTC Six CS20 CS21

@IntelligentCooling_18037_offline
Scenario: VAN18037_TestStep17_Check disconnect wifi Intelligent Cooling feature show
	Given Read Intelligent cooling run mark for all test case
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given Jump to power smart settings section
	Then The Intelligent Cooling feature will show or hide for container collapse expand show
	When The user connect or disconnect WiFi on lenovo

@IntelligentCooling_18037_offline
Scenario: VAN18037_TestStep18_Check connect wifi Intelligent Cooling feature show
	Given Read Intelligent cooling run mark for all test case
	When The user connect or disconnect WiFi on lenovo
	Given Go to Power Page
	Given Jump to power smart settings section
	Then The Intelligent Cooling feature will show or hide for container collapse expand show
