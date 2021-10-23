Feature: VAN8574AllowuserstojoinexistingCHSaccountfromVantage
	Test Case：https://jira.tc.lenovo.com/browse/VAN-8574
	Author ：yangyu

@CaseNeedTestBlueBar
Scenario: VAN8574_TestStep01_Check jion CHS blue bar will pop up 
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	When Click CHS "Next" Button
	When Click CHS "NotNow" Button
	When Click CHS "Join" Button
	Then The Tutorial Will Pop up And Show SlideBlueBar

@CaseNeedTestBlueBar
Scenario: VAN8574_TestStep02_Check pop up input code prompt immediately
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	When Click CHS "Next" Button
	When Click CHS "NotNow" Button
	When Click CHS "Join" Button
	When Click CHS "Yes" Button
	Then Check The Part of "InputCode"
	Then Take Screen Shot 01UI in 8574 under CHScreenShotResult

@CaseNeedTestBlueBar
Scenario: VAN8574_TestStep03_Check come back to CHS marketing page
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	When Click CHS "Next" Button
	When Click CHS "NotNow" Button
	When Click CHS "Join" Button
	When Click CHS "No" Button
	Then The Slide Will Be Closed And Return to CHS Marketing Page

@AllowuserstojoinexistingCHSaccountfromVantage
Scenario: VAN8574_TestStep04_Check location dialog will pop up
	Given Remove Account from Web Console
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	When Click CHS "Next" Button
	When Click CHS "NotNow" Button
	When Click CHS "Join" Button
	Then Check Location Dialog exist
	Then Take Screen Shot 05UI in 8574 under CHScreenShotResult

@AllowuserstojoinexistingCHSaccountfromVantage
Scenario: VAN8574_TestStep05_Check will open location settings page
	When Check CHS Subpage
	When Click CHS "Join" Button
	When Click CHS "Allow" Button
	Then It Will Directly Open Settings Page
	Then Take Screen Shot 02UI in 8574 under CHScreenShotResult

@AllowuserstojoinexistingCHSaccountfromVantage
Scenario: VAN8574_TestStep06_Check will pop up location dialog again
	When Check CHS Subpage
	When Click CHS "Join" Button
	When Click CHS "Allow" Button
	Given Close Settings Page Without Action
	When Click CHS "Join" Button
	Then Check Location Dialog exist

@AllowuserstojoinexistingCHSaccountfromVantage
Scenario: VAN8574_TestStep07_Check will pop up input code prompt immediatedly
	When Check CHS Subpage
	When Click CHS "Join" Button
	When Click CHS "Allow" Button
	Given Set Vantage Location "On" In Setting
	When Click CHS "Join" Button
	Then Check The Part of "InputCode"

@AllowuserstojoinexistingCHSaccountfromVantage
Scenario: VAN8574_TestStep08_Check will turn back to CHS marketing subpage
	Given Turn off Location Permission for Vantage
	When Check CHS Subpage
	When Click CHS "Join" Button
	When Click CHS "NotNow" Button
	Then The Slide Will Be Closed And Return to CHS Marketing Page

@AllowuserstojoinexistingCHSaccountfromVantage
Scenario: VAN8574_TestStep09_Check input code prompt pop up
	Given Location for Vantage has been Enabled
	When Check CHS Subpage
	When Click CHS "Join" Button
	Then Check The Part of "InputCode"
	Then Take Screen Shot 03UI in 8574 under CHScreenShotResult

@AllowuserstojoinexistingCHSaccountfromVantage
Scenario: VAN8574_TestStep10_Check text "Incorrect code entered!" appears
	When Check CHS Subpage
	When Click CHS "Join" Button
	Then Check The Part of "ErrorInputCode"
	Then Take Screen Shot 04UI in 8574 under CHScreenShotResult

@AllowuserstojoinexistingCHSaccountfromVantage
Scenario: VAN8574_TestStep11_Check Code input box will disappear.
	When Check CHS Subpage
	When Click CHS "Join" Button
	Then Check The Part of "ErrorInputCode"
	When Click CHS "Cancel" Button
	Then It Will Directly Go to CHS Marketing Page
	Then Take Screen Shot 06UI in 8574 under CHScreenShotResult

@AllowuserstojoinexistingCHSaccountfromVantage
Scenario: VAN8574_TestStep12_Check will pop up successfully login message
	Given User has Joined or Started a CHS "Trialadmin"Group
	Then Check The Part of "Successfully login message"
	Then User Can See Admin/Secondary Console Normally
	Given Remove Account from Web Console

@AllowuserstojoinexistingCHSaccountfromVantage
Scenario: VAN8574_TestStep13_Check will pop up offine dialog
	Given Remove Account from Web Console
	Given Remove "Subscription" Account from Web Console
	When Check CHS Subpage
	When Click CHS "Join" Button
	When The user connect or disconnect WiFi off lenovo
	Given Close Vantage
	Given Launch Vantage
	When Check CHS Subpage
	Then Will Pop up Offline Message
	When The user connect or disconnect WiFi on lenovo
	



