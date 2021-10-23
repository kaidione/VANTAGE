Feature: VAN271_VFC1859_RapidChargeToggleQuickRegressionTest
	Test Case： https://jira.tc.lenovo.com/browse/VAN-271
	Author：Pengjie Chen

@CheckRapidCharge @CheckRapidChargeLE
Scenario: VAN271_TestStep01_Reinstall Check UI Elements and Toggle default Status Is 'Off'
	Given Uninstall the lenovo vatage
	Given Install Vantage
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Check Battery Settings 'Display Rapid Charge Elements'
	Then The Rapid Charge Toggle State Is 'Off'

@CheckIdeaPadNotSupportRapidCharge @CheckRapidChargeLE
Scenario: VAN271_TestStep02_Check IdeaPad Not Support Rapid Charge
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Check Battery Settings 'Not Display Rapid Charge Elements'

@CheckThinkPadNotSupportRapidCharge
Scenario: VAN271_TestStep03_Check ThinkPad Not Support Rapid Charge
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Check Battery Settings 'Not Display Rapid Charge Elements'

@CheckRapidCharge @CheckRapidChargeLE
Scenario: VAN271_TestStep04_Turn On Rapid Charge Toggle and Check Lightning Icon Beside The Toolbar Icon
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Given Turn On Rapid Charge Toggle
	Then The Rapid Charge Toggle State Is 'On'
	Then Take Screen Shot VAN271_Step04 in 271 under SettingsScreenShotResult

@CheckRapidCharge @CheckRapidChargeLE
Scenario: VAN271_TestStep05_Turn Off Rapid Charge Toggle and Check The Lightning Icon Will Disappear
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Given Turn Off Rapid Charge Toggle
	Then The Rapid Charge Toggle State Is 'Off'
	Then Take Screen Shot VAN271_Step05 in 271 under SettingsScreenShotResult

@CheckRapidChargeFullChargeTime @CheckRapidChargeLE
Scenario: VAN271_TestStep06_Turn On Rapid Charge The Full Charge Time Is Shorter Than Normal Charge
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Given Battery Level is below 80%
	Given Turn Off Rapid Charge Toggle
	Then The Rapid Charge Toggle State Is 'Off'
	Then Get Rapid Charge State Is 'Off' Full Charge Time
	Given Battery Level is below 80%
	Given Turn On Rapid Charge Toggle
	Then The Rapid Charge Toggle State Is 'On'
	Then Get Rapid Charge State Is 'On' Full Charge Time
	Then The Full Charge Time Is Shorter Than Normal Charge

@CheckRapidCharge  @CheckRapidChargeLE @SmokeCheckRapidCharge
Scenario: VAN271_TestStep07_Resize Vantage Check The Toggle Status and The UI Not Change
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Given Turn On Rapid Charge Toggle
	Then The Rapid Charge Toggle State Is 'On'
	When Click Vantage Maxmize Button
	Then The Rapid Charge Toggle State Is 'On'
	Then Check Battery Settings 'Display Rapid Charge Elements'

@CheckRapidChargeHibernate @CheckRapidChargeLE
Scenario: VAN271_TestStep08_Turn On Rapid Charge Hibernation The Feature Works Normally
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Given Turn On Rapid Charge Toggle
	Then The Rapid Charge Toggle State Is 'On'
	When Hibernate System And Get Rapid Charge Toggle State
	Then Back From Hibernate Rapid Charge Toggle State Is 'On'

@CheckRapidChargeRemoveAdapterStatus @CheckRapidChargeLE
Scenario: VAN271_TestStep10_Turn On Rapid Charge Remove The Adapter Toggle Status Not Change
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Given Turn On Rapid Charge Toggle
	Then The Rapid Charge Toggle State Is 'On'
	When User make the machine from AC to DC
	Then The Rapid Charge Toggle State Is 'On'
	Given AC Condition(Connect the Adapter)

@CheckRapidCharge @CheckRapidChargeLE
Scenario: VAN271_TestStep11_Rapid Charge Toggle Is 'On',Turn 'On' Conservation Mode Toggle
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Given Turn On Rapid Charge Toggle
	Then The Rapid Charge Toggle State Is 'On'
	Given Turn On Conservation Mode Toggle
	Then The Conservation Mode Toggle State Is 'On'
	Then The Rapid Charge Toggle State Is 'Off'
	Then Take Screen Shot VAN271_Step11 in 271 under SettingsScreenShotResult

@CheckRapidCharge @CheckRapidChargeLE
Scenario: VAN271_TestStep12_Conservation Mode Toggle Is 'On',Turn 'On' Rapid Charge Toggle
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Given Turn On Conservation Mode Toggle
	Then The Conservation Mode Toggle State Is 'On'
	Given Turn On Rapid Charge Toggle
	Then The Rapid Charge Toggle State Is 'On'
	Then The Conservation Mode Toggle State Is 'Off'
	Then Take Screen Shot VAN271_Step12 in 271 under SettingsScreenShotResult

@CheckRapidChargeS950
Scenario: VAN271_TestStep13
	When Enter power page
	Given Turn On Rapid Charge Toggle
	Given Close Vantage
	Given Using ChargeInvoker.exe to Reset EC "Conservation" states 
	Given Launch Winappdriver
	When Launch Vantage
	When Enter power page
	Then Take Screen Shot 13BtteryIcon in 13280 under HSScreenShotResult
	Then The "RapidCharge" toggle is "on"
	Given Turn on or off the narrator 'on'
	Then Launch toolbar
	Then The Rapid charge button display on statue
	When Close toolbar
	Given Turn on or off the narrator 'off'

@CheckRapidChargeS950
Scenario: VAN271_TestStep14
	When Enter power page
	Given Turn Off Rapid Charge Toggle
	Given Close Vantage
	Given Using ChargeInvoker.exe to Reset EC "Conservation" states 
	When Launch Vantage
	When Enter power page
	Then The "RapidCharge" toggle is "off"
	Given Turn on or off the narrator 'on'
	Then Launch toolbar
	Then The Rapid charge button display off statue
	When Close toolbar
	Given Turn on or off the narrator 'off'

@CheckRapidChargeS950
Scenario: VAN271_TestStep15
	Given Uninstall the Lenovo Vantage
	Given Turn on or off the narrator 'on'
	Then Launch toolbar
	When Turn on the Rapid charge
	When Close toolbar
	Given Using ChargeInvoker.exe to Reset EC "Conservation" states 
	Given Launch Winappdriver
	Given Turn on or off the narrator 'on'
	Then Launch toolbar
	Then The Rapid charge button display on statue
	When Close toolbar
	Given Turn on or off the narrator 'off'

@CheckRapidChargeS950
Scenario: VAN271_TestStep16
	Given Uninstall the Lenovo Vantage
	Given Turn on or off the narrator 'on'
	Then Launch toolbar
	When Turn off the Rapid charge
	When Close toolbar
	Given Using ChargeInvoker.exe to Reset EC "All" states 
	Given Launch Winappdriver
	Given Turn on or off the narrator 'on'
	Then Launch toolbar
	Then The Rapid charge button display on statue
	When Close toolbar
	Given Turn on or off the narrator 'off'

@CheckRapidCharge
Scenario: VAN271_TestStep17
	When Enter power page
	Given Turn On Rapid Charge Toggle
	Given Close Vantage
	Given Using ChargeInvoker.exe to Reset EC "All" states 
	When Launch Vantage
	When Enter power page
	Then Take Screen Shot 17BtteryIcon in 13280 under HSScreenShotResult
	Then The "RapidCharge" toggle is "on"
	Given Turn on or off the narrator 'on'
	Then Launch toolbar
	Then The Rapid charge button display on statue
	When Close toolbar
	Given Turn on or off the narrator 'off'

@CheckRapidCharge
Scenario: VAN271_TestStep18
	When Enter power page
	Given Turn off Rapid Charge Toggle
	Given Close Vantage
	Given Using ChargeInvoker.exe to Reset EC "All" states 
	Given Launch Winappdriver
	When Launch Vantage
	When Enter power page
	Then Take Screen Shot 17BtteryIcon in 13280 under HSScreenShotResult
	Then The "RapidCharge" toggle is "off"
	Given Turn on or off the narrator 'on'
	Then Launch toolbar
	Then The Rapid charge button display off statue
	When Close toolbar
	Given Turn on or off the narrator 'off'

@CheckRapidCharge
Scenario: VAN271_TestStep19
	Given Uninstall the Lenovo Vantage
	Given Turn on or off the narrator 'on'
	Then Launch toolbar
	When Turn on the Rapid charge
	When Close toolbar
	Given Using ChargeInvoker.exe to Reset EC "All" states 
	Given Launch Winappdriver
	Given Turn on or off the narrator 'on'
	Then Launch toolbar
	Then The Rapid charge button display off statue
	When Close toolbar
	Given Turn on or off the narrator 'off'

@CheckRapidCharge
Scenario: VAN271_TestStep20
	Given Uninstall the Lenovo Vantage
	Given Turn on or off the narrator 'on'
	Then Launch toolbar
	When Turn off the Rapid charge
	When Close toolbar
	Given Using ChargeInvoker.exe to Reset EC "All" states 
	Given Launch Winappdriver
	Given Turn on or off the narrator 'on'
	Then Launch toolbar
	Then The Rapid charge button display off statue
	When Close toolbar
	Given Turn on or off the narrator 'off'	