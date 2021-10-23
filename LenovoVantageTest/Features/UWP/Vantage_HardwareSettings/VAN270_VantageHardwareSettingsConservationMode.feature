Feature: VAN270_VFC1858_VantageHardwareSettingsConservationMode
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-270
	Author： DaQi Fang
	Author： Haiye Li(31-34)
	
@ConservationModeNotSupportTinkPad @SmokeConservationModeNotSupportTinkPad
Scenario: VAN270_TestStep01_Thinkpad machine is not supported the feature
	Given Thinkpad machine
	When Enter power page
	Then The feature is not supported

@ConservationModeNotSupportSomeIdea 
Scenario: VAN270_TestStep02_The BIOS in the blocklist of ideapad machine is not supported the feature
	Given Machine not support the conservation mode
	When Enter power page
	Then The feature is in Battery settings section

@ConservationModeSupportSomeIdea @SmokeConservationModeSupportSomeIdea
Scenario: VAN270_TestStep03_The BIOS not in the blocklist of ideapad machine show the feature
	Given Machine support the conservation mode
	When Enter power page
	Then Feature is shows

@ConservationModeSupportSomeIdea @SmokeConservationModeSupportSomeIdea
Scenario: VAN270_TestStep04_Conservation mode default state is off
	Given Machine support the conservation mode
	Given Install Vantage
	When Enter power page
	Then The toggle default status is off

@ConservationModeCheckConservationIcon
Scenario: VAN270_TestStep05_TestStep adapter insert turn on conservation mode there is a leaf beside vantage toolbar
	Given Pin toolbar to taskbar
	Given AC Condition(Connect the Adapter)
	When Enter power page
	When Turn on conservation mode
	Then Take Screen Shot 05ToolbarConservationModeIcon in 13280 under HSScreenShotResult
	#Then There is a leaf beside vantage toolbar

@ConservationModeCheckConservationIcon
Scenario: VAN270_TestStep06_TestStep adapter insert turn off Conservation mode the leaf beside vantage toolbar will disappear
	Given AC Condition(Connect the Adapter)
	When Enter power page
	When Turn off conservation mode
	Then Take Screen Shot 06ToolbarConservationModeIcon in 13280 under HSScreenShotResult
	#Then The leaf beside vantage toolbar will disappear

@ConservationModeCheckButteryCharged
Scenario: VAN270_TestStep07_22TestStep Turn on conservation mode battery will be charged and the final battery percentage is 60%. battery status is "plugged in,  not charging". 
	Given AC Condition(Connect the Adapter)
	Given Get ConservationMode Type
	Given Battery in ConversionMode is below than 55% or 75%
	When Enter power page
	When Turn on conservation mode
	Then Battery will be charged and the final battery percentage is 60% or 80%".
	Then Take Screen Shot 07_22ToolbarBatteryStatusMessage in 13280 under HSScreenShotResult
	Then Recover conservation mode toggle
	
@ConservationModeCheckButteryCharged
Scenario: VAN270_TestStep08_23TestStep Turn on conservation mode battery level will keep in 55%-60% such as 58% and battery status is "plugged in, not charging" 
	Given AC Condition(Connect the Adapter)
	Given Get ConservationMode Type
	Given Battery level is in 55%60% or 75%80%
	When Enter power page
	When Turn on conservation mode
	Then Battery level will keep in 55%60% or 75%80%
	Then Take Screen Shot 08_23ToolbarBatteryStatusMessage in 13280 under HSScreenShotResult
	Then Recover conservation mode toggle
	
@ConservationModeCheckButteryCharged
Scenario: VAN270_TestStep09_24TestStep Turn on conservation mode  battery level will not change and battery status is "plugged in, not charging"
	Given AC Condition(Connect the Adapter)
	Given Get ConservationMode Type
	Given Battery in ConversionMode is upon than 60% or 80%
	When Enter power page
	When Turn on conservation mode
	Then Battery level will not change and battery status is "plugged in, not charging"
	Then Take Screen Shot 09_24ToolbarBatteryStatusMessage in 13280 under HSScreenShotResult
	When Enter power page
	When Turn off conservation mode
	Given Battery in ConversionMode is upon than 67% or 87%
	When Turn on conservation mode
	Then Battery level will not change and battery status is "plugged in, not charging"
	Then Take Screen Shot 09_01_24ToolbarBatteryStatusMessage in 13280 under HSScreenShotResult

@ConservationModeCheckButteryCharged
Scenario: VAN270_TestStep10_25
	Given AC Condition(Connect the Adapter)
	Given Get ConservationMode Type
	Given Battery in ConversionMode is below than 55% or 75%
	When Enter power page
	When Turn on conservation mode
	When Enter sleep
	Then Battery will be charged and the final battery percentage is 60% or 80%".
	Then Take Screen Shot 10_25ToolbarBatteryStatusMessage in 13280 under HSScreenShotResult
	Then Recover conservation mode toggle

@ConservationModeCheckButteryCharged
Scenario: VAN270_TestStep10_01_25_01
	Given AC Condition(Connect the Adapter)
	Given Get ConservationMode Type
	Given Battery in ConversionMode is below than 55% or 75%
	When Enter power page
	When Turn on conservation mode
	When Enter hibernate	
	Then Battery will be charged and the final battery percentage is 60% or 80%".
	Then Take Screen Shot 10_01_25_01ToolbarBatteryStatusMessage in 13280 under HSScreenShotResult
	Then Recover conservation mode toggle

@ConservationModeCheckButteryCharged
Scenario: VAN270_TestStep12_27
	Given AC Condition(Connect the Adapter)
	Given Get ConservationMode Type
	Given Battery level is in 55%60% or 75%80%
	When Enter power page
	When Turn on conservation mode
	When Enter sleep
	Then Battery level will keep in 55%60% or 75%80%
	Then Take Screen Shot 12_27ToolbarBatteryStatusMessage in 13280 under HSScreenShotResult
	Then Recover conservation mode toggle

@ConservationModeCheckButteryCharged
Scenario: VAN270_TestStep12_01_27_01
	Given AC Condition(Connect the Adapter)
	Given Get ConservationMode Type
	Given Battery level is in 55%60% or 75%80%
	When Enter power page
	When Turn on conservation mode
	When Enter hibernate
	Then Battery level will keep in 55%60% or 75%80%
	Then Take Screen Shot 12_01_27_01ToolbarBatteryStatusMessage in 13280 under HSScreenShotResult
	Then Recover conservation mode toggle

@ConservationModeCheckButteryCharged
Scenario: VAN270_TestStep14_29
	Given AC Condition(Connect the Adapter)
	Given Get ConservationMode Type
	Given Battery in ConversionMode is upon than 60% or 80%
	When Enter power page
	When Turn on conservation mode
	When Enter sleep
	Then Battery level will not change and battery status is "plugged in, not charging"
	Then Take Screen Shot 14ToolbarBatteryStatusMessage in 13280 under HSScreenShotResult
	When Enter power page
	When Turn off conservation mode
	Given Battery in ConversionMode is upon than 67% or 87%
	When Turn on conservation mode
	When Enter sleep
	Then Battery level will not change and battery status is "plugged in, not charging"
	Then Take Screen Shot 14_29ToolbarBatteryStatusMessage in 13280 under HSScreenShotResult

@ConservationModeCheckButteryCharged
Scenario: VAN270_TestStep14_01_29_01
	Given AC Condition(Connect the Adapter)
	Given Get ConservationMode Type
	Given Battery in ConversionMode is upon than 60% or 80%
	When Enter power page
	When Turn on conservation mode
	When Enter hibernate
	Then Battery level will not change and battery status is "plugged in, not charging"
	Then Take Screen Shot 14_01_29_01ToolbarBatteryStatusMessage in 13280 under HSScreenShotResult
	When Enter power page
	When Turn off conservation mode
	Given Battery in ConversionMode is upon than 67% or 87%
	When Turn on conservation mode
	When Enter hibernate
	Then Battery level will not change and battery status is "plugged in, not charging"
	Then Take Screen Shot 14_01_29_011ToolbarBatteryStatusMessage in 13280 under HSScreenShotResult

@ConservationModeCheckButteryCharged
Scenario: VAN270_TestStep16_TestStep Turn on conservation mode  battery level will not change and battery status is "plugged in, not charging"
	Given AC Condition(Connect the Adapter)
	Given Battery Level is below 100%
	When Enter power page
	Given Conservation mode is on
	When Turn off conservation mode
	Then The battery will continue to charge
	Then Take Screen Shot 16ToolbarBatteryStatusMessage in 13280 under HSScreenShotResult

@ConservationModeCutRepidAndConservation
Scenario: VAN270_TestStep17_Turn on rapid the conservation mode toggle is off and the icon beside vantage toolbar is lightning
	Given Machine support the conservation mode
	Given Machine support the rapid charge mode
	When Enter power page
	When Turn on conservation mode
	When Turn on rapid charge toggle
	Then The conservation mode toggle is off and the icon beside vantage toolbar is lightning
	Then Take Screen Shot 017ToolbarRapidModeIcon in 13280 under HSScreenShotResult
	Then Turn off rapid charge toggle

@ConservationModeCutRepidAndConservation
Scenario: VAN270_TestStep18_Turn on the conservation mode the rapid charge toggle is off the icon beside vantage toolbar is leaf
	Given Machine support the conservation mode
	Given Machine support the rapid charge mode
	When Enter power page
	When Turn on rapid charge toggle
	When Turn on conservation mode
	Given Waiting 3 seconds
	Then The conservation mode toggle is on and the icon beside vantage toolbar is leaf
	Then Take Screen Shot 18ToolbarConservationModeIcon in 13280 under HSScreenShotResult
	Then Recover conservation mode toggle

@ConservationModeCutWindwo
Scenario: VAN270_TestStep19_Minimize vantage/refresh pages/re-launch vantage/resize vantage the toggle status should not change
	Given Machine support the conservation mode
	When Enter power page
	When Turn on conservation mode
	When Get conservation mode toggle status
	When Minimize vantage conservation mode
	Then The toggle status should not change
	Given Go to dashboad page
	When Enter power page
	Then The toggle status should not change
	When Relaungh vantage conservation mode
	When Enter power page
	Then The toggle status should not change
	When Resize vantage conservation mode
	Then The toggle status should not change

@ConservationModeCheckButteryCharged
Scenario: VAN270_TestStep21
	Given Get ConservationMode Type
	When Enter power page
	Then Check charging threshold description

@ConservationModeCheckButteryCharged
Scenario: VAN270_TestStep22_TestStep Turn on conservation mode battery will be charged and the final battery percentage is 60%. battery status is "plugged in,  not charging". 
	When Only Print 'Please check TestStep07'

@ConservationModeCheckButteryCharged
Scenario: VAN270_TestStep23_TestStep Turn on conservation mode battery level will keep in 55%-60% such as 58% and battery status is "plugged in, not charging" 
	When Only Print 'Please check TestStep08'

@ConservationModeCheckButteryCharged
Scenario: VAN270_TestStep24_TestStep Turn on conservation mode  battery level will not change and battery status is "plugged in, not charging" 
	When Only Print 'Please check TestStep09'

@ConservationModeBlacklist
Scenario: VAN270_TestStep31_Check the UI appearance of the Conservation mode feature
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Conservation mode toggle display hide

@ConservationModeBlacklist
Scenario: VAN270_TestStep32_Check the UI appearance of the Conservation mode feature
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then There only show the title description note of Conservation mode feature
	Then Take Screen Shot TestStep32CheckUI in 270 under HSScreenShotResult

@ConservationModeBlacklist
Scenario: VAN270_TestStep33_Check the UI appearance of the Conservation mode feature
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then  The description displays text

@ConservationModeBlacklist
Scenario: VAN270_TestStep34_Check the UI appearance of the Conservation mode feature
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then  The Note description displays text

@ConservationMode
Scenario: VAN270_TestStep35
	When Enter power page
	When Turn on conservation mode
	Given Close Vantage
	Given Using ChargeInvoker.exe to Reset EC "All" states 
	When Launch Vantage
	When Enter power page
	Then Take Screen Shot 35BtteryIcon in 13280 under HSScreenShotResult
	Then The "Conservation" toggle is "on"
	Given Turn on or off the narrator 'on'
	Then Launch toolbar
	Then The Conservation mode button display on statue
	When Close toolbar
	Given Turn on or off the narrator 'off'

@ConservationMode
Scenario: VAN270_TestStep36
	When Enter power page
	When Turn off conservation mode
	Given Close Vantage
	Given Using ChargeInvoker.exe to Reset EC "All" states 
	When Launch Vantage
	When Enter power page
	Then Take Screen Shot 36BtteryIcon in 13280 under HSScreenShotResult
	Then The "Conservation" toggle is "off"
	Given Turn on or off the narrator 'on'
	Then Launch toolbar
	Then The Conservation mode button display off statue
	When Close toolbar
	Given Turn on or off the narrator 'off'

@ConservationMode
Scenario: VAN270_TestStep37
	Given Uninstall the Lenovo Vantage
	Given Turn on or off the narrator 'on'
	Then Launch toolbar
	When Turn on the Conservation mode
	When Close toolbar
	Given Turn on or off the narrator 'off'
	Given Using ChargeInvoker.exe to Reset EC "All" states 
	Then Launch toolbar
	Then The Conservation mode button display off statue
	When Close toolbar
	Given Turn on or off the narrator 'off'
	
@ConservationMode
Scenario: VAN270_TestStep38
	Given Uninstall the Lenovo Vantage
	Given Turn on or off the narrator 'off'
	Then Launch toolbar
	When Turn off the Conservation mode
	When Close toolbar
	Given Turn on or off the narrator 'off'
	Given Using ChargeInvoker.exe to Reset EC "All" states 
	Then Launch toolbar
	Then The Conservation mode button display off statue
	When Close toolbar
	Given Turn on or off the narrator 'off'