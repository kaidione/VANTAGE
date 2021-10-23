Feature: VAN8572_Part2_Removeslides2and3fromCHSOnboardingTutorial
	Test Case：https://jira.tc.lenovo.com/browse/VAN-8572
	Author ：yangyu

@CaseNeedTestBlueBar
Scenario: VAN8572_TestStep07_Check CHS bluebar will pop up
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	When Click CHS "Next" Button
	When Click CHS "Allow" Button
	Then The Tutorial Will Pop up And Show SlideBlueBar

@CaseNeedTestBlueBar
Scenario: VAN8572_TestStep08_Check click bluebar yes and enable location tutorial not pop up
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	When Click CHS "Next" Button
	When Click CHS "Allow" Button
	Then The Tutorial Will Pop up And Show SlideBlueBar
	When Click CHS "Yes" Button
	Given Switch Pages and Return to CHS Subpage
	Then Tutorial Will Not Pop up Anymore

@CaseNeedTestBlueBar
Scenario: VAN8572_TestStep09_Check click bluebar yes and disable location tutorial not pop up
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	When Click CHS "Next" Button
	When Click CHS "Allow" Button
	Then The Tutorial Will Pop up And Show SlideBlueBar
	When Click CHS "Yes" Button
    Given Turn off Location Service in Settings Page
	Then Tutorial Will Not Pop up Anymore
	Then Start trial Then "NotNow" Button Is Clickable

@CaseNeedTestBlueBar
Scenario: VAN8572_TestStep10_Check click bluebar no then tutorial not pop up
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	When Click CHS "Next" Button
	When Click CHS "Allow" Button
	Then The Tutorial Will Pop up And Show SlideBlueBar
	When Click CHS "No" Button
	Then Tutorial Will Not Pop up Anymore
	Then Start trial Then "NotNow" Button Is Clickable

@CaseNeedTestBlueBar
Scenario:VAN8572_TestStep13_Check slide1 pop up secondly click slide2 "allow" will pop up blue bar
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1
	Given Waiting 1 seconds
	Given Close Vantage
	Given Launch Vantage
	When Check CHS Subpage
	When Click CHS "Next" Button
	When Click CHS "Allow" Button
	Then The Tutorial Will Pop up And Show SlideBlueBar

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep25_Check 22met click "Not Now" tutorial will not pop up
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1
	Given Waiting 1 seconds
	Given Close Vantage
	Given Launch Vantage
	When Check CHS Subpage
	When Click CHS "Next" Button
	When Click CHS "NotNow" Button
	Given Close Vantage
	Given Launch Vantage
	When Check CHS Subpage
	Then Tutorial Will Not Pop up Anymore

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep26_Check offline first open CHS
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When The user connect or disconnect WiFi off lenovo
	Given Close Vantage
	Given Launch Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1
	When The user connect or disconnect WiFi on lenovo

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep27_Check UI with 1200*1000 size
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 1200  | 1000   |           |            |
	Then Take Screen Shot 03UI in 8572 under CHScreenShotResult
	When Click CHS "Next" Button
	Then Take Screen Shot 04UI in 8572 under CHScreenShotResult
	
@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep28_Check UI with 992*1000 size
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 992   | 1000   |           |            |
	Then Take Screen Shot 05UI in 8572 under CHScreenShotResult
	When Click CHS "Next" Button
	Then Take Screen Shot 06UI in 8572 under CHScreenShotResult

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep29_Check UI with 768*1000 size
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 768   | 1000   |           |            |
	Then Take Screen Shot 07UI in 8572 under CHScreenShotResult
	When Click CHS "Next" Button
	Then Take Screen Shot 08UI in 8572 under CHScreenShotResult

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep30_Check UI with 576*1000 size
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 576   | 1000   |           |            |
	Then Take Screen Shot 09UI in 8572 under CHScreenShotResult
	When Click CHS "Next" Button
	Then Take Screen Shot 10UI in 8572 under CHScreenShotResult

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep31_Check tutorial"done" popup correctly
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide3