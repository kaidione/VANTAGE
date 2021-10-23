Feature: VAN7219_VFC206_BatteryChargeThresholdThinkPadRegressionTest
	Test Case： https://jira.tc.lenovo.com/browse/VAN-7219
	Author： Jinxin Li
	Update: Haiye Li

Background:
	Given Thinkpad machines
	Given Support Battery Charge Threshold

@BatteryChargeThresholdSupportDualBatteries
Scenario: VAN7219_TestStep01_Battery Charge Threshold 01
	Given Click Device settings,enter Power page
	When Go to Battery Charge threshold section
	Then The Battery Settings section displays a header-'$.PowerPage.BatteryHeaderText' with a  toggle button to trigger on/off this feature.
	When Turn off Battery Charge threshold

#@BatteryChargeThresholdSupportDualBatteries
#Scenario: VAN7219_TestStep02_Battery Charge Threshold 02
#	Given Click Device settings,enter Power page
#	When Go to Battery Charge threshold section
#	Then The default state should be disabled; The default status should retrieve from the JS Bridge.

@BatteryChargeThresholdSupportDualBatteries @SmokeBatteryChargeThresholdSupportDualBatteries
Scenario: VAN7219_TestStep03_Battery Charge Threshold 03
	Given Click Device settings,enter Power page
	When Click the question mark beside Battery charge threshold
	Then The context of the question mark '$.PowerPage.QuestionMarkContext'

@BatteryChargeThresholdSupportDualBatteries
Scenario: VAN7219_TestStep04_Battery Charge Threshold 04
	Given Machine support dual batteries
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	Then Show two standalone settings for the primary battery and secondary one

@BatteryChargeThresholdSupportDualBatteries
Scenario: VAN7219_TestStep05_Battery Charge Threshold 05
	Given Machine support dual batteries
	Given Click Device settings,enter Power page
	Given UnCheck the Primary checkbox
	When Turn on Battery Charge threshold
	Then The primary battery Start charging when bellow:40%-95%,Stop charging at:45%-100%
	Then The second battery Start charging when bellow:40%-95%,Stop charging at:45%-100%

@BatteryChargeThresholdSupportDualBatteries
Scenario: VAN7219_TestStep06_Battery Charge Threshold 06
	Given Machine support dual batteries
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	When Set the primary battery or the second battery value higher the Stop charging value
	Then The red text note '$.PowerPage.RedTextNote' appera
	Then Take Screen Shot 06BatteryChargeThresholdRedNote in 7219 under HSScreenShotResult

@BatteryChargeThresholdSupportOneBattery
Scenario: VAN7219_TestStep07_Battery Charge Threshold 07
	Given Machine support one battery
	Given Click Device settings,enter Power page
	Given UnCheck the Primary checkbox
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	Then Start charging when bellow:40%-95%
	Then Stop charging at:45%-100%

@BatteryChargeThresholdSupportOneBattery
Scenario: VAN7219_TestStep08_Battery Charge Threshold 08
	Given Machine support one battery
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	When Set Start charging value:60%,Stop charging:80%
	Then The Start charging value 80% and more than 80% is grey-out
	Then The Stop charging value 60% lower than 60% is grey-out

@BatteryChargeThresholdSupportOneBattery @SmokeBatteryChargeThresholdSupportOneBattery
Scenario: VAN7219_TestStep09_Battery Charge Threshold 09
	Given Machine support one battery
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	When Set Start charging value:60%,Stop charging:80%
	When Check the Primary checkbox
	Then The Start charging value automatically become 75% and greyout

@BatteryChargeThresholdSupportOneBattery
Scenario: VAN7219_TestStep10_Battery Charge Threshold 10
	Given Machine support one battery
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	When Show one standalone settings for the primary battery

@BatteryChargeThresholdSupportDualBatteries
Scenario: VAN7219_TestStep11_Battery Charge Threshold 11
	Given Machine support dual batteries
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	Given UnCheck the Primary checkbox
	When Set the primary battery or the second battery value higher the Stop charging value
	Then The red text note '$.PowerPage.RedTextNote' appera
	Then Take Screen Shot 11BatteryChargeThresholdRedNote in 7219 under HSScreenShotResult

@BatteryChargeThresholdSupportDualBatteries
Scenario: VAN7219_TestStep12_Battery Charge Threshold 12
	Given Machine support dual batteries
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	When Hibernate system
	Then The toggle state of Battery Charge Threshold function should not be changed
	When Sleep system
	Then The toggle state of Battery Charge Threshold function should not be changed

@BatteryChargeThresholdSupportDualBatteries
Scenario: VAN7219_TestStep17_Battery Charge Threshold 17
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	When Set the primary battery or the second battery value higher the Stop charging value
	Then Bellow the Battery health icon the text '$.PowerPage.BatteryHealthText' will appear immediately

@BatteryChargeThresholdSupportDualBatteries
Scenario: VAN7219_TestStep18_Battery Charge Threshold 18
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	When Set Start charging value:60%,Stop charging:80%
	When Turn off Battery Charge threshold
	Then Bellow the Battery health icon the text note will disappear immediately

@BatteryChargeThresholdOneBattery @LEBatteryChargeThresholdOneBattery
Scenario: VFC206_TestStep19_Battery Charge Threshold 19
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	When Set Start charging value:60%,Stop charging:80%
	Then Bellow the Battery health icon the text '$.PowerPage.BatteryHealthText' will appear immediately
	When Hibernate system
	Then The toggle state of Battery Charge Threshold function should not be changed
	Then Bellow the Battery health icon the text '$.PowerPage.BatteryHealthText' will appear immediately
	Then Check Start charging value:60%,Stop charging:80%
	When Sleep system
	Then The toggle state of Battery Charge Threshold function should not be changed
	Then Bellow the Battery health icon the text '$.PowerPage.BatteryHealthText' will appear immediately
	Then Check Start charging value:60%,Stop charging:80%

@BatteryChargeThresholdSupportDualBatteries 
Scenario: VAN7219_VFC206_TestStep21_Battery Charge Threshold 21
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	When Check the Primary checkbox
	Then The Start charging threshold 5 percentage points bellow the Stop charging threshold
	Given UnCheck the Primary checkbox

@BatteryChargeThresholdOneBattery @LEBatteryChargeThresholdOneBattery
Scenario: VFC206_TestStep22_Battery Charge Threshold 22
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	When Set Start charging value:60%,Stop charging:80%
	Then Bellow the Battery health icon the text '$.PowerPage.BatteryHealthText' will appear immediately
	Given Set ThinkPad Machine Battery Level Is Below 59%
	Then The Machine Will Charge Until 80%

@BatteryChargeThresholdOneBattery @LEBatteryChargeThresholdOneBattery
Scenario: VFC206_TestStep23_Battery Charge Threshold 23
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	When Set Start charging value:60%,Stop charging:80%
	Then Bellow the Battery health icon the text '$.PowerPage.BatteryHealthText' will appear immediately
	Given Set ThinkPad Machine Battery Level Is Below 70%
	When the user plug in the power supply
	Then the machine battery will show not charge status
	Then the battery value of the machine will not reduce and battery value keep Origin Value

@BatteryChargeThresholdOneBattery @LEBatteryChargeThresholdOneBattery
Scenario: VFC206_TestStep24_Battery Charge Threshold 24
	Given Click Device settings,enter Power page
	When Turn off Battery Charge threshold
	Given Set ThinkPad Machine Battery Level Is More Than 81%
	When Turn on Battery Charge threshold
	When Set Start charging value:60%,Stop charging:80%
	Then Bellow the Battery health icon the text '$.PowerPage.BatteryHealthText' will appear immediately
	When the user plug in the power supply
	Then the machine battery will show not charge status
	Then the battery value of the machine will not reduce and battery value keep Origin Value

@BatteryChargeThresholdTwoBattery
Scenario: VFC206_TestStep25
	Given Machine support dual batteries
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	When "unchecked" the "primary" check box
	When Set Start charging value:60%,Stop charging:80%
	When "unchecked" the "second" check box
	When Set Second Battery charging value:60%,Stop charging:80%
	When Set the primary battery level "61"
	When Set the second battery level "61"
	When Click Battery level button
	Then Take Screen Shot 7129TwoBatteryStep25_01 in 7129 under HSScreenShotResult
	When Wait 5 minutes
	Then Take Screen Shot 7129TwoBatteryStep25_02 in 7129 under HSScreenShotResult

@BatteryChargeThresholdTwoBattery
Scenario: VFC206_TestStep26
	Given Machine support dual batteries
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	When "unchecked" the "primary" check box
	When Set Start charging value:60%,Stop charging:80%
	When "unchecked" the "second" check box
	When Set Second Battery charging value:60%,Stop charging:80%
	When Set the primary battery level "61"
	When Set the second battery level "61"
	Given DC Condition(Connect the Adapter)
	Given AC Condition(Connect the Adapter)
	When Click Battery level button
	Then Take Screen Shot 7129TwoBatteryStep26_01 in 7129 under HSScreenShotResult
	When Wait 5 minutes
	Then Take Screen Shot 7129TwoBatteryStep26_02 in 7129 under HSScreenShotResult

@BatteryChargeThresholdTwoBattery
Scenario: VFC206_TestStep27
	Given Machine support dual batteries
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	When "unchecked" the "primary" check box
	When Set Start charging value:60%,Stop charging:80%
	When "unchecked" the "second" check box
	When Set Second Battery charging value:60%,Stop charging:80%
	When Set the primary battery level "61"
	When Set the second battery level "61"
	When "checked" the "primary" check box
	When "checked" the "second" check box
	Then The "primary" battery start will change to "75"
	Then The "second" battery start will change to "75"
	When Click Battery level button
	Then Take Screen Shot 7129TwoBatteryStep27_01 in 7129 under HSScreenShotResult
	When Wait "primary" battery level to "80"
	Then Take Screen Shot 7129TwoBatteryStep27_02 in 7129 under HSScreenShotResult
	When Wait "second" battery level to "80"
	When Wait 5 minutes
	Then The Primary Battery level is "80", Second Battery level is "80" 
	Then Take Screen Shot 7129TwoBatteryStep27_03 in 7129 under HSScreenShotResult

@BatteryChargeThresholdTwoBattery
Scenario: VFC206_TestStep28_29
	Given AC Condition(Connect the Adapter)
	Given Machine support dual batteries
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	When "unchecked" the "primary" check box
	When Set Start charging value:60%,Stop charging:80%
	When "unchecked" the "second" check box
	When Set Second Battery charging value:60%,Stop charging:80%
	When Set the primary battery level "81"
	When Set the second battery level "81"
	Given DC Condition(Connect the Adapter)
	When Click Battery level button
	Then Take Screen Shot 7129TwoBatteryStep28_01 in 7129 under HSScreenShotResult
	When Wait 5 minutes
	Then The Primary Battery level is "81", Second Battery level is "81" 
	Then Take Screen Shot 7129TwoBatteryStep28_02 in 7129 under HSScreenShotResult
	Given AC Condition(Connect the Adapter)

@BatteryChargeThresholdTwoBattery
Scenario: VFC206_TestStep29
	When Only Print 'Please check TestStep28'

@BatteryChargeThresholdTwoBattery
Scenario: VFC206_TestStep30
	Given AC Condition(Connect the Adapter)
	Given Machine support dual batteries
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	When "unchecked" the "primary" check box
	When Set Start charging value:60%,Stop charging:80%
	When "unchecked" the "second" check box
	When Set Second Battery charging value:60%,Stop charging:80%
	When Set the primary battery level "81"
	When Set the second battery level "81"
	When "checked" the "primary" check box
	When "checked" the "second" check box
	Then The "primary" battery start will change to "75"
	Then The "second" battery start will change to "75"
	When Click Battery level button
	Then Take Screen Shot 7129TwoBatteryStep30_01 in 7129 under HSScreenShotResult
	When Wait 5 minutes
	Then The Primary Battery level is "81", Second Battery level is "81" 
	Then Take Screen Shot 7129TwoBatteryStep30_02 in 7129 under HSScreenShotResult

@BatteryChargeThresholdTwoBattery
Scenario: VFC206_TestStep31
	Given AC Condition(Connect the Adapter)
	Given Machine support dual batteries
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	When "unchecked" the "primary" check box
	When Set Start charging value:60%,Stop charging:80%
	When "unchecked" the "second" check box
	When Set Second Battery charging value:60%,Stop charging:80%
	When Set the primary battery level "51"
	When Set the second battery level "50"
	When Click Battery level button
	Then Take Screen Shot 7129TwoBatteryStep31_01 in 7129 under HSScreenShotResult
	When Wait "primary" battery level to "80"
	Then Take Screen Shot 7129TwoBatteryStep31_02 in 7129 under HSScreenShotResult
	When Wait "second" battery level to "80"
	When Wait 5 minutes
	Then The Primary Battery level is "80", Second Battery level is "80" 
	Then Take Screen Shot 7129TwoBatteryStep31_03 in 7129 under HSScreenShotResult

@BatteryChargeThresholdTwoBattery
Scenario: VFC206_TestStep32
	Given AC Condition(Connect the Adapter)
	Given Machine support dual batteries
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	When "unchecked" the "primary" check box
	When Set Start charging value:60%,Stop charging:80%
	When "unchecked" the "second" check box
	When Set Second Battery charging value:60%,Stop charging:80%
	When Set the primary battery level "61"
	When Set the second battery level "59"
	When Click Battery level button
	Then Take Screen Shot 7129TwoBatteryStep32_01 in 7129 under HSScreenShotResult
	When Wait "second" battery level to "80"
	When Wait 5 minutes
	Then The Primary Battery level is "61", Second Battery level is "80" 
	Then Take Screen Shot 7129TwoBatteryStep32_02 in 7129 under HSScreenShotResult

@BatteryChargeThresholdTwoBattery
Scenario: VFC206_TestStep33
	Given AC Condition(Connect the Adapter)
	Given Machine support dual batteries
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	When "unchecked" the "primary" check box
	When Set Start charging value:60%,Stop charging:80%
	When "unchecked" the "second" check box
	When Set Second Battery charging value:60%,Stop charging:80%
	When Set the primary battery level "50"
	When Set the second battery level "81"
	When Click Battery level button
	Then Take Screen Shot 7129TwoBatteryStep33_01 in 7129 under HSScreenShotResult
	When Wait "primary" battery level to "80"
	When Wait 5 minutes
	Then The Primary Battery level is "80", Second Battery level is "81" 
	Then Take Screen Shot 7129TwoBatteryStep33_02 in 7129 under HSScreenShotResult

@BatteryChargeThresholdTwoBattery
Scenario: VFC206_TestStep34
	Given AC Condition(Connect the Adapter)
	Given Machine support dual batteries
	Given Click Device settings,enter Power page
	When Turn on Battery Charge threshold
	When "unchecked" the "primary" check box
	When Set Start charging value:95%,Stop charging:100%
	When "unchecked" the "second" check box
	When Set Second Battery charging value:60%,Stop charging:80%
	When Set the primary battery level "97"
	When Set the second battery level "70"
	When Click Battery level button
	Then Take Screen Shot 7129TwoBatteryStep34_01 in 7129 under HSScreenShotResult
	When Wait 5 minutes
	Then The Primary Battery level is "97", Second Battery level is "70" 
	Then Take Screen Shot 7129TwoBatteryStep34_02 in 7129 under HSScreenShotResult

@BatteryChargeThresholdOneBattery @LEBatteryChargeThresholdOneBattery
Scenario: VFC206_TestStep36_Battery Charge Threshold 36
	When The user connect or disconnect WiFi off lenovo
	Given Click Device settings,enter Power page
	Given Click Battery Settings Link
	When wait 2 seconds
	Then Check Battery Charge Threshold Elements
	When The user connect or disconnect WiFi on lenovo

@BatteryChargeThresholdOneBattery @LEBatteryChargeThresholdOneBattery
Scenario: VFC206_TestStep40_Battery Charge Threshold 40
	Given Click Device settings,enter Power page
	Given Click Battery Settings Link
	When Turn off Battery Charge threshold
	When Turn On And Check Battery Charge Threshold PopUp Display On Non Support Battery Temporary Mode system
	When Turn off Battery Charge threshold