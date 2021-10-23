Feature: VAN249_VFC181_HSBatteryInformationTest
	Test Case： https://jira.tc.lenovo.com/browse/VAN-249
	Author： HaiYe Li  

@CheckBatteryinformation @CheckBatteryinformationLE @SmokeCheckBatteryinformation
Scenario: VAN249_TestStep01_check the battery information UI
	Given Go to Power Page
	Then Check battery Message

@CheckBatteryinformationtextthinkpad @CheckBatteryinformationLE
Scenario: VAN249_TestStep02_check the Battery Gauge panel will display text Thinkpad
	Given Set ThinkPad Machine Battery Level Is Below 90%
	#Given change ThinkPad machine to DC condition
	#Given change ThinkPad machine to AC condition
	When wait 30 seconds
	Given Go to Power Page
	Then the Battery Gauge panel will display text

@CheckBatteryinformationtextthinkpad @CheckBatteryinformationLE
Scenario: VAN249_TestStep03_check the Battery details page Gauge panel will display text Thinkpad
	Given Set ThinkPad Machine Battery Level Is Below 90%
	#Given change ThinkPad machine to DC condition
	#Given change ThinkPad machine to AC condition
	When wait 30 seconds
	Given Go to Power Page
	Then  Click Battery Details Btn
	Then the Battery Gauge panel will display text
	
@CheckBatteryinformation
Scenario: VAN249_TestStep04_check the battery  should follow the UISPEC
	Given Go to Power Page
	Then Take Screen Shot 04CheckBatteryStyleTextLocationEtc. in 249 under HSScreenShotResult

@CheckTwoBatteryinformation 
Scenario: VAN249_TestStep05_check Two battery details page display two details
	Given Go to Power Page
	Then  Click Battery Details Btn
	Then  Take Screen Shot 05checkBatteryDetailsDisplay in 249 under HSScreenShotResult
	
@CheckBatteryinformation
Scenario: VAN249_TestStep06_check the battery details page should  follow the UISPEC
	Given Go to Power Page
	Then  Click Battery Details Btn
	Then Take Screen Shot 06CheckBatteryfollowTheUISPEC in 249 under HSScreenShotResult
	
@CheckBatteryinformation @CheckBatteryinformationLE
Scenario: VAN249_TestStep07_check the battery Details Close Icon Btn
	Given Go to Power Page
	Then  Click Battery Details Btn
	Then  Click Battery Details Close Icon Btn
	
@CheckBatteryinformationideaAC
Scenario: VAN249_TestStep13_check the battery Adapter Icon
	Given AC Condition(Connect the Adapter)
	Given Go to Power Page
	Then  Check Battery Adapter Icon
	Then  Click Battery Details Btn
	Then  Check Battery Adapter Icon
	Then  Click Toolbar
	Then  Check BatteryGauge Toolbar Adapter Icon

@CheckBatteryinformationideaDC
Scenario: VFC249_TestStep14_check the battery level is upon 25%
	Given Go to Power Page
	When the battery is more than 25%
	Then  Take Screen Shot 14CheckBatteryfollowTheUISPEC in 249 under HSScreenShotResult 
	Then  Click Battery Details Btn
	Then  Take Screen Shot 14CheckBatteryfollowTheUISPECS in 249 under HSScreenShotResult
	
@CheckBatteryinformationideaDC
Scenario: VFC249_TestStep15_check the battery level is in 15%24%,such as 20%
	Given Go to Power Page
	When the battery is from 15% to 24%
	Then Take Screen Shot 15CheckBatteryfollowTheUISPEC in 249 under HSScreenShotResult
	Then  Click Battery Details Btn
	Then Take Screen Shot 15CheckBatteryfollowTheUISPECS in 249 under HSScreenShotResult

@CheckBatteryinformationideaDC
Scenario: VFC249_TestStep16_check the battery is below 15%
	Given Go to Power Page
	When the battery is lower than 15%
	Then Take Screen Shot 16CheckBatteryfollowTheUISPEC in 249 under HSScreenShotResult
	Then  Click Battery Details Btn
	Then Take Screen Shot 16CheckBatteryfollowTheUISPECS in 249 under HSScreenShotResult
	Given AC Condition(Connect the Adapter)

@CheckBatteryinformationideaDC
Scenario: VFC249_TestStep17_check remaining time value battery have value
	When User make the machine from AC to DC
	Given Go to Power Page
	Then  Check YES time value
	Then  Click Battery Details Btn
	Then  Check YES time value
	Given AC Condition(Connect the Adapter)

@CheckBatteryinformationideaAC @CheckBatteryinformationLE
Scenario: VAN249_TestStep18_check remaining time value battery no value
	Given AC Condition(Connect the Adapter)
	Given Go to Power Page
	Then  Check NO time value  
	Then  Click Battery Details Btn
	Then  Check NO time value 

@CheckBatteryinformationtextthinkpad @CheckBatteryinformationLE
Scenario: VAN249_TestStep19_check the battery gauge toolbar Thinkpad
	Given change ThinkPad machine to AC condition
	Given Go to Power Page  
	Then Take Screen Shot 19CheckACBatteryDetailsMsg in 249 under HSScreenShotResult
	Then Click Battery Details Btn
	Then Take Screen Shot 19CheckAcToolbarMsg in 249 under HSScreenShotResult  

@CheckBatteryinformationideaDC
Scenario: VFC249_TestStep20_check the battery Details Msg
	When User make the machine from AC to DC
	Given Go to Power Page
	Then  Click Battery Details Btn
	Then Take Screen Shot 20CheckDCBatteryDetailsMsg in 249 under HSScreenShotResult
	Given AC Condition(Connect the Adapter)
	
@CheckBatteryinformationideaAC @CheckBatteryinformationLE
Scenario: VAN249_TestStep21_check the battery Details Msg
	Given AC Condition(Connect the Adapter)
	Given Go to Power Page
	Then  Click Battery Details Btn
	Then Take Screen Shot 21CheckACBatteryDetailsMsg in 249 under HSScreenShotResult

@CheckTwoBatteryinformation 
Scenario: VAN249_TestStep22_check AC Two battery Details Primarybattery
	Given change ThinkPad machine to AC condition
	Given Go to Power Page
	Then Click Battery Details Btn
	Then Take Screen Shot 22CheckTwoBatteryDetailsPage in 249 under HSScreenShotResult
	Then Turn on BatView
	Then Take Screen Shot 22CheckTwoBatteryDetailsPagePrimarybattery in 249 under HSScreenShotResult
	Then BatView will be Launched

@CheckTwoBatteryinformation
Scenario: VAN249_TestStep23_check AC Two battery Details Secondarybattery
	Given change ThinkPad machine to AC condition
	Given Go to Power Page
	Then Click Battery Details Btn
	Then Take Screen Shot 23CheckTwoBatteryDetailsPage in 249 under HSScreenShotResult
	Then Turn on BatView
	Then Take Screen Shot 23CheckTwoBatteryDetailsPageSecondarybattery in 249 under HSScreenShotResult
	Then BatView will be Launched

@CheckTwoBatteryinformation
Scenario: VAN249_TestStep24_check DC Two battery Details Primarybattery
	Given change ThinkPad machine to DC condition
	Given Go to Power Page
	Then Click Battery Details Btn
	Then Take Screen Shot 24CheckTwoBatteryDetailsPage in 249 under HSScreenShotResult
	Then Turn on BatView
	Then Take Screen Shot 24CheckTwoBatteryDetailsPagePrimarybattery in 249 under HSScreenShotResult
	Then BatView will be Launched
	Given change ThinkPad machine to AC condition

@CheckTwoBatteryinformation
Scenario: VAN249_TestStep25_check DC Two battery Details Secondarybattery
	Given change ThinkPad machine to DC condition
	Given Go to Power Page
	Then Click Battery Details Btn
	Then Take Screen Shot 25CheckTwoBatteryDetailsPage in 249 under HSScreenShotResult
	Then Turn on BatView
	Then Take Screen Shot 25CheckTwoBatteryDetailsPageSecondarybattery in 249 under HSScreenShotResult
	Then BatView will be Launched
	Given change ThinkPad machine to AC condition

@CheckBatteryinformation @CheckBatteryinformationLE
Scenario: VAN249_TestStep26_check after 30 seconds or refresh Battery Details page
	Given Go to Power Page
	Then Take Screen Shot 26CheckBatteryMsg in 249 under HSScreenShotResult
	Then Click Battery Details Btn
	Then Take Screen Shot 26CheckBatteryDetailsPageMsg in 249 under HSScreenShotResult
	Then  Click Battery Details Close Icon Btn
	When wait 30 seconds
	Then Take Screen Shot 26Check30SecondsOrRefreshBattery in 249 under HSScreenShotResult
	Then Click Battery Details Btn
	Then Take Screen Shot 26Check30SecondsOrRefreshBatteryDetailsPage in 249 under HSScreenShotResult