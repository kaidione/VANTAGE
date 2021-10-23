Feature: VAN21719_GamingX50AdvancedOc
	Test Case：https://jira.tc.lenovo.com/browse/VAN-21719
	Author ：xiang tian

Background:
	Given Machine is Gaming 
	
@GamingX50AdvancedOCEntrance
Scenario: AVAN21719_TestStep01_Advanced OC button and enable oc checkbox should be shown in the Advanced OC settings dialog
	When check if Y750S or not
	Given driver is installed
	Given click the Thermal mode area
	Then Advanced OC button and enable oc checkbox should be shown in the Advanced OC settings dialog

@GamingNotSupportX50AdvancedOCEntrance
Scenario: AVAN21719_TestStep02_Advanced OC button and enable oc checkbox should not be shown in the Advanced OC settings dialog	
    When check if L350 or not
	Given click the Thermal mode area
	Then  Advanced OC button and enable oc checkbox should not be shown in the Advanced OC settings dialog

@GamingX50AdvancedOCEntrance
Scenario: AVAN21719_TestStep03_Thermal mode settings page should be closed and the Warning dialog should be shown	
	When check if Y750S or not
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC btn in the Thermal mode settings page
	Then Thermal mode settings page should be closed and the Warning dialog should be shown

@GamingX50AdvancedOCEntrance
Scenario: AVAN21719_TestStep04_check other area and Warning dialog should not be closed
	When check if Y750S or not
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC btn in the Thermal mode settings page
	When  check other area
	Then  Warning dialog should not be closed

@GamingX50AdvancedOCEntrance
Scenario: AVAN21719_TestStep05_check Proceed-btn cancel-link-btn X-btn and warning sentence should be shown	
	When check if Y750S or not
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC btn in the Thermal mode settings page
	Given Warning dialog is displaying
	Then  Proceed-btn cancel-link-btn X-btn and warning sentence should be shown

@GamingX50AdvancedOCEntrance
Scenario: AVAN21719_TestStep06_Warning dialog should be closed and homepage should be shown	
	When check if Y750S or not
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC btn in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the X_Btn link in the Warning dialog
    Then  Warning dialog should be closed and homepage should be shown

@GamingX50AdvancedOCEntrance
Scenario: AVAN21719_TestStep07_Warning dialog should be closed and homepage should be shown	
	When check if Y750S or not
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC btn in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the cancel_Btn link in the Warning dialog
    Then  Warning dialog should be closed and homepage should be shown

@GamingX50AdvancedOCEntrance
Scenario: AVAN21719_TestStep08_ Warning dialog should be closed and Advance OC page should be shown	
	When check if Y750S or not
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC btn in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed_Btn link in the Warning dialog
    Then  Warning dialog should be closed and Advance OC page should be shown