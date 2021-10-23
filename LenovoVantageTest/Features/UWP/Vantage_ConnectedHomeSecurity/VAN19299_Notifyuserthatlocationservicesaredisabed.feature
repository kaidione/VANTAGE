Feature: VAN19299_NotifyUserThatLocationServiceAreDisabed
	Test Case：https://jira.tc.lenovo.com/browse/VAN-19299
	Author ：yangyu

@NotifyUserThatLocationServiceAreDisabed 
Scenario: VAN19299_TestStep01_Check CHS subpage admin/secondary console
	Given User has Joined or Started a CHS "Trialadmin"Group
	Given Location for Vantage has been Enabled
	When Check CHS Subpage
	Then User Can See Admin/Secondary Console Normally
	Then Take Screen Shot 01UI in 19299 under CHScreenShotResult

@NotifyUserThatLocationServiceAreDisabed
Scenario: VAN19299_TestStep02_Check disable location banner show up and user can't see admin/secondary console
	Given Keep CHS Subpage Open
	Given Turn off Location Permission for Vantage
	When Check CHS Subpage
	Then Take Screen Shot 02UI in 19299 under CHScreenShotResult
	Then Disable Location Banner Show up and User Can't See Admin/Secondary Console
	
@NotifyUserThatLocationServiceAreDisabed
Scenario: VAN19299_TestStep03_Check disable location banner show up and user can't see admin/secondary console
	Given Turn off Location Service in Settings Page
	When Check CHS Subpage
	Then Disable Location Banner Show up and User Can't See Admin/Secondary Console
	
@NotifyUserThatLocationServiceAreDisabed
Scenario: VAN19299_TestStep04_Check disable location banner disappear automatically
	Given Disable Location Banner Show up
	Given Turn on Location for Vantagee
	When Check CHS Subpage
	Then User Can See Admin/Secondary Console Normally
	
@NotifyUserThatLocationServiceAreDisabed
Scenario: VAN19299_TestStep05_Check disable location banner still exist
	Given Disable Location Banner Show up
	Given Click Button Go to Location Settings
	Given Close Settings Page Without Action
	When Check CHS Subpage
	Then Disable Location Banner Still Exist     

@NotifyUserThatLocationServiceAreDisabed
Scenario: VAN19299_TestStep06_Check disable location banner still exist
	Given Disable Location Banner Show up
	Given Click "go to location settings" and Just Turn on Location Service(Don't turn on vantage location permission),Close Settings Page
	When Check CHS Subpage
	Then Disable Location Banner Still Exist 

@NotifyUserThatLocationServiceAreDisabed
Scenario: VAN19299_TestStep07_Check disabled location banner will disappear and we can see admin/secondary user console normally
	Given Disable Location Banner Show up
	Given Click "go to location settings" and Turn on Location Service&Vantage Location Permission
	When Check CHS Subpage
	Then The Disabled Location Banner Will Disappear and We Can See Admin/Secondary User Console Normally
	
@NotifyUserThatLocationServiceAreDisabed
Scenario: VAN19299_TestStep08_Check location banner will pop up again
	Given Disable Location Banner Show up
	Given Click "go to location settings" and Turn on Location Service&Vantage Location Permission
	Given Turn off Location Permission for Vantage
	When Check CHS Subpage
	Then Disable Location Banner Still Exist   

@NotifyUserThatLocationServiceAreDisabed
Scenario: VAN19299_TestStep09_Check disabled location banner still exist and can't see admin/secondary user console
	Given Disable Location Banner Show up
	Given Close Vantage
	Given Launch Vantage
	When Check CHS Subpage
	Then Disable Location Banner Show up and User Can't See Admin/Secondary Console

@NotifyUserThatLocationServiceAreDisabed
Scenario: VAN19299_TestStep10_Check disabled location banner still exist and can't see admin/secondary user console
	Given Disable Location Banner Show up
	Given Switch Pages and Return to CHS Subpage
	When Check CHS Subpage
	Then Disable Location Banner Show up and User Can't See Admin/Secondary Console

@NotifyUserThatLocationServiceAreDisabed
Scenario: VAN19299_TestStep11_Check disabled location banner still exist and can't see admin/secondary user console
	Given Disable Location Banner Show up
	Given Remove Account from Web Console
	When Check CHS Subpage
	Then Disable Location Banner Show up and User Can't See Admin/Secondary Console

@NotifyUserThatLocationServiceAreDisabed
Scenario: VAN19299_TestStep12_Check directly go to CHS marketing page
	Given User has Joined or Started a CHS "Trialadmin"Group
	Given Disable Location Banner Show up
	Given Remove Account from Web Console
	Given Turn on Location for Vantagee
	When Check CHS Subpage
	Then It Will Directly Go to CHS Marketing Page

@NotifyUserThatLocationServiceAreDisabed
Scenario: VAN19299_TestStep13_Check disable location banner show up
	Given User has Joined or Started a CHS "Trialadmin"Group
	Given Turn off Location Permission for Vantage
	Given Open LWS Subpage and Click "Visit"
	Then Disable Location Banner Show up and User Can't See Admin/Secondary Console

@NotifyUserThatLocationServiceAreDisabed
Scenario: VAN19299_TestStep14_Check disable location banner show up
	Given Close Vantage
	Given Turn off Location Permission for Vantage
	Given Launch Vantage
	When Check CHS Subpage
	Then Disable Location Banner Show up and User Can't See Admin/Secondary Console

@NotifyUserThatLocationServiceAreDisabed
Scenario: VAN19299_TestStep15_Check numbers in the group will change accordingly
	Given Add "Trial" Family Number 
	Given Turn off Location Permission for Vantage
	Given Change Component From Web Consle
	Given Location for Vantage has been Enabled
	When Check CHS Subpage
	Then The Numbers In the Group Will Display "1"

@NotifyUserThatLocationServiceAreDisabed
Scenario: VAN19299_TestStep16_Check "SH" location status and disabled location banner status are consistent
	Given Turn off Location Permission for Vantage	
	Then "SH" location Status and Disabled Location Banner Status are Consistent

@NotifyUserThatLocationServiceAreDisabed
Scenario: VAN19299_TestStep17_Check directly open settings page
	Given Turn off Location Permission for Vantage
	When Check CHS Subpage
	When Click "enable location" in SH
	Then It Will Directly Open Settings Page

@NotifyUserThatLocationServiceAreDisabed
Scenario: VAN19299_TestStep18_Check disabled location banner will disappear and we can see admin/secondary user console normally
	Given Turn off Location Permission for Vantage		
	Given Click "enable location" and Turn on Location Service&Vantage Location Permission
	When Check CHS Subpage
	Then The Disabled Location Banner Will Disappear and We Can See Admin/Secondary User Console Normally

@NotifyUserThatLocationServiceAreDisabed
Scenario: VAN19299_TestStep19_Check UI show normally
	Given Disable Location Banner Show up		
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 500   | 500    |           |            |
	Then Take Screen Shot 05UI in 19299 under CHScreenShotResult
	Given Slide The Page To "-200"
	Then Take Screen Shot 06UI in 19299 under CHScreenShotResult
	Given Slide The Page To "-500"
	Then Take Screen Shot 07UI in 19299 under CHScreenShotResult

@NotifyUserThatLocationServiceAreDisabed 
Scenario: VAN19299_TestStep20_Check disable location banner won't show up
	Given Location for Vantage has been Enabled
	Given Remove Account from Web Console		
	When Check CHS Subpage
	When wait 4 seconds for loading
	Given Turn off Location Permission for Vantage
	Then Disable Location Banner Won't Show up

@NotifyUserThatLocationServiceAreDisabed 
Scenario: VAN19299_TestStep21_Check UI show normally
	Given User has Joined or Started a CHS "Trialadmin"Group
	Then Check The Part of "Successfully login message"
	Given Disable Location Banner Show up
	Given Change DPI And Resolution "1366"x"768" 100%
	When Check CHS Subpage
	Then Take Screen Shot 03UI in 19299 under CHScreenShotResult
	Given Slide The Page To "-500"
	Then Take Screen Shot 04UI in 19299 under CHScreenShotResult
	Given Change DPI And Resolution "1920"x"1080" 100%
	Given Remove Account from Web Console

	