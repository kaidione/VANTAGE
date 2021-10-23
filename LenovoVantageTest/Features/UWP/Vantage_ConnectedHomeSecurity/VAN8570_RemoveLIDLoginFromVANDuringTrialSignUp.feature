Feature: VAN8570_RemoveLIDLoginFromVANDuringTrialSignUp
	Test Case：https://jira.tc.lenovo.com/browse/VAN-8570
	Author ：fengya2

@RemoveLIDLoginFromVANDuringTrialSignUp
Scenario: VAN8570_TestStep01_Check description about "start trial"
	When Check CHS Subpage
	Given OOBE CHS
	Then Check the part of Start Trial

@CaseNeedTestBlueBar
Scenario: VAN8570_TestStep02_cick start trial and bluebar will pop up
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	When Click CHS "Next" Button
	When Click CHS "notnow" Button
	When Click Start Trial
	Then The Tutorial Will Pop up And Show Slide BlueBar

@CaseNeedTestBlueBar
Scenario: VAN8570_TestStep03_start trial blue bar yes
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	When Click CHS "Next" Button
	When Click CHS "notnow" Button
	When Click Start Trial
	Then The Tutorial Will Pop up And Show Slide BlueBar
	When Click CHS "Yes" Button
	Then  Check Start Trial Prompt Box

@CaseNeedTestBlueBar
Scenario: VAN8570_TestStep04_start trial blue bar no
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	When Click CHS "Next" Button
	When Click CHS "notnow" Button
	When Click Start Trial
	Then The Tutorial Will Pop up And Show SlideBlueBar
	When Click CHS "No" Button
	Then Blue Bar Not Pop up Anymore
	Then Check the part of Start Trial

@RemoveLIDLoginFromVANDuringTrialSignUp
Scenario: VAN8570_TestStep05_click start trial check location dialog
	Given Turn off Location Permission for Vantage
	When Check CHS Subpage
	When Click Start Trial
	Then Check Location Dialog exist

@RemoveLIDLoginFromVANDuringTrialSignUp	
Scenario: VAN8570_TestStep06_click allow in chs page and go to settings page
	Given Turn off Location Permission for Vantage
	When  Check CHS Subpage
	When  Click Start Trial
	Then  Click Allow Button
	Then  Check Location Settings Page

@RemoveLIDLoginFromVANDuringTrialSignUp
Scenario: VAN8570_TestStep07_check prompt box after enable location
	Given Turn off Location Permission for Vantage
	When  Check CHS Subpage
	When  Click Start Trial
	Then  Click Allow Button
	Given Turn on Location for Vantagee
	When  Check CHS Subpage
	When  Click Start Trial
	Then  Check Start Trial Prompt Box

@RemoveLIDLoginFromVANDuringTrialSignUp
Scenario: VAN8570_TestStep08_location dialog pop up again
	Given Turn off Location Permission for Vantage
	When  Check CHS Subpage
	When  Click Start Trial
	Then  Click Allow Button
	When  Check CHS Subpage
	When  Click Start Trial
	Then  Check Location Dialog exist

@RemoveLIDLoginFromVANDuringTrialSignUp
Scenario: VAN8570_TestStep09_click not now and go to CHS page
	Given Turn off Location Permission for Vantage
	When  Check CHS Subpage
	When  Click Start Trial
	When  Click CHS "notnow" Button
	Then  Check Location Dialog not exist

@RemoveLIDLoginFromVANDuringTrialSignUp
Scenario: VAN8570_TestStep10_enable location and click start trial
	Given Turn on Location for Vantagee
	When Check CHS Subpage
	When Click Start Trial
	Then Check Start Trial Prompt Box

@RemoveLIDLoginFromVANDuringTrialSignUp
Scenario: VAN8570_TestStep11_check prompt box UI
	Given Turn on Location for Vantagee
	When Check CHS Subpage
	When Click Start Trial
	Then Check Start Trial Prompt Box
	Then Take Screen Shot 11UI in 8570 under CHScreenShotResult	

@RemoveLIDLoginFromVANDuringTrialSignUp
Scenario: VAN8570_TestStep12_wait 3s and go to webpage
	Given Turn on Location for Vantagee
	When Check CHS Subpage
	When Click Start Trial
	Then Waiting 10 seconds
	Then Take Screen Shot 12UI in 8570 under CHScreenShotResult

@RemoveLIDLoginFromVANDuringTrialSignUp
Scenario: VAN8570_TestStep13_click go now and go to webpage
	Given Turn on Location for Vantagee
	When Check CHS Subpage
	When Click Start Trial
	When Click CHS "go now" Button
	Then Waiting 10 seconds
	Then Take Screen Shot 13UI in 8570 under CHScreenShotResult

@RemoveLIDLoginFromVANDuringTrialSignUp
Scenario: VAN8570_TestStep14_click start trial cancel 
	Given Turn on Location for Vantagee
	When Check CHS Subpage
	When Click Start Trial
	When Click CHS "start trial cancel" Button
	Then Take Screen Shot 14UI in 8570 under CHScreenShotResult

@RemoveLIDLoginFromVANDuringTrialSignUp
Scenario: VAN8570_TestStep18_login old LID and check CHS subpage
	Given Turn on Location for Vantagee
	When Check CHS Subpage
	When Click Start Trial
	Then Waiting 10  seconds
	Given Sign in LID  and not Join CHS Account
	Then Take Screen Shot 1801UI  in 8570 under CHScreenShotResult
	When Check CHS Subpage
	Then Take Screen Shot 1802UI  in 8570 under CHScreenShotResult	
	Then Kill chrome.exe Process
