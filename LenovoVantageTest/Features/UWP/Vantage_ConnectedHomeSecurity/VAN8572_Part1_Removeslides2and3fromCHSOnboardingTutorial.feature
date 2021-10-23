Feature: VAN8572_Part1_Removeslides2and3fromCHSOnboardingTutorial
	Test Case：https://jira.tc.lenovo.com/browse/VAN-8572
	Author ：yangyu

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep01_Check first open CHS tutorial will pop up and show slide1
	Given Install Vantage
	Given Waiting 1 seconds
	Given Turn off Location Permission for Vantage	
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1
	Then Take Screen Shot 01UI in 8572 under CHScreenShotResult

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep02_Check tutorial will pop up and slide1 UI currectly 
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep03_Check tutorial will pop up sencondly
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep04_Check tutorial will not pop up 
	When Check CHS Subpage
	Then Tutorial Will Not Pop up Anymore
	Then Start trial Then "NotNow" Button Is Clickable

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep05_Check tutorial will pop up and show slide2
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	When Click CHS "Next" Button
	Then Take Screen Shot 02UI in 19299 under CHScreenShotResult

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep06_Check tutorial will pop up and slide2 UI correctly
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	When Click CHS "Next" Button
	Then The Tutorial Will Pop up And Show Slide2

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep11_Check click "Not now" then tutorial will not pop up 
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	When Click CHS "Next" Button
	When Click CHS "NotNow" Button
	Given Close Vantage
	Given Launch vantage without OOBE
	When Check CHS Subpage
	Then Tutorial Will Not Pop up Anymore
	Then Start trial Then "NotNow" Button Is Clickable

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep12_Check slide1 pop up secondly slide1 will pop up again
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1
	Given Waiting 1 seconds
	Given Close Vantage
	Given Launch vantage without OOBE
	When Check CHS Subpage
	When Click CHS "Next" Button
	Then The Tutorial Will Pop up And Show Slide2

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep14_Check first enable location then tutorial will not pop up
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1
	Given Waiting 1 seconds
	Given Close Vantage
	Given Launch vantage without OOBE
	When Check CHS Subpage
	When Click CHS "Next" Button
	Then The Tutorial Will Pop up And Show Slide2
	When Click CHS "Allow" Button
	Given Set Vantage Location "On" In Setting
	Given Close Vantage
	Given Launch vantage without OOBE
	When Check CHS Subpage
	Then Tutorial Will Not Pop up Anymore
	When Click Start Trial
	Then Check Start Trial Prompt Box

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep15_Check first not enable location then tutorial will not pop up
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1
	Given Waiting 1 seconds
	Given Close Vantage
	Given Launch vantage without OOBE
	When Check CHS Subpage
	When Click CHS "Next" Button
	When Click CHS "Allow" Button
	Given Close Settings Page Without Action
	Then Tutorial Will Not Pop up Anymore

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep17_Check click "Not now"then will return marketing page
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
	Then The Slide Will Be Closed And Return to CHS Marketing Page

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep18_Check second launch enable loction then slide1 will not pop up
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1
	Given Waiting 1 seconds
	Given Close Vantage
	Given Turn on Location for Vantagee
	Given Launch Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide3

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep19_Check seconde launch enable and disable location tutorial will not pop up
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1
	Given Waiting 1 seconds
	Given Close Vantage
	Given Turn on Location for Vantagee
	Given Turn off Location Permission for Vantage
	Given Launch Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep20_Check second launch enable tutorial will not pop up
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1
	Given Waiting 1 seconds
	Given Close Vantage
	Given Launch vantage without OOBE
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1
	Given Waiting 1 seconds
	Given Close Vantage
	Given Turn on Location for Vantagee
	Given Launch vantage without OOBE
	When Check CHS Subpage
	Then Tutorial Will Not Pop up Anymore

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep21_Check slide1 popup secondly enable and disable loctioan tutorial will not pop up
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1
	Given Waiting 1 seconds
	Given Close Vantage
	Given Launch vantage without OOBE
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1
	Given Waiting 1 seconds
	Given Close Vantage
	Given Turn on Location for Vantagee
	Given Turn off Location Permission for Vantage
	Given Launch vantage without OOBE
	When Check CHS Subpage
	Then Tutorial Will Not Pop up Anymore

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep22_Check slide1 popup secondly click "next" tutorial will Show Slide2
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given Turn off Location Permission for Vantage
	Given Launch Lenovo Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1
	Given Waiting 1 seconds
	Given Close Vantage
	Given Launch vantage without OOBE
	When Check CHS Subpage
	When Click CHS "Next" Button
	Then The Tutorial Will Pop up And Show Slide2

@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep23_Check 22met then enable location tutorial will not pop up
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
	Given Set Vantage Location "On" In Setting
	Given Close Vantage
	Given Launch Vantage
	When Check CHS Subpage
	Then Tutorial Will Not Pop up Anymore
	
@Removeslides2and3fromCHSOnboardingTutorial
Scenario:VAN8572_TestStep24_Check 22met then not enable location tutorial will not pop up
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
	Given Close Settings Page Without Action
	Given Close Vantage
	Given Launch Vantage
	When Check CHS Subpage
	Then Tutorial Will Not Pop up Anymore

