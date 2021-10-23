Feature: VAN272_AlwaysOnUSBQuickRegressionTest
	Test Case： https://jira.tc.lenovo.com/browse/VAN-272
	Author：Jinxin Li

@CheckIdeaPadNoDisplayAlwaysOnUSB
Scenario: VAN272_TestStep01_Check IdeaPad Machine No Display Elements
	Given Go to My Device Settings page
	Then Check Power Settings No Always On USB Feature

@CheckIdeaPadAlwaysOnUSBNoCheckbox
Scenario: VAN272_TestStep02_Check IdeaPad Machine No Display Checkbox Elements
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Then Check Power Settings No Checkbox Elements
	Then Check Power Settings Always On USB Section Display '$.PowerPage.AlwaysUSBDescriptionText'

@CheckIdeaPadAlwaysOnUSB @SmokeCheckIdeaPadAlwaysOnUSB
Scenario: VAN272_TestStep03_Check IdeaPad Machine Display Elements
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Then Check Power Settings Display Always On USB Elements
	Then Check Power Settings Always On USB Section Display '$.PowerPage.AlwaysUSBDescriptionText'
	Then Check Power Settings Always On USB Section Display '$.PowerPage.AlwaysUSBLabelDescriptionText'

@CheckThinkPadAlwaysOnUSB
Scenario: VAN272_TestStep04_Check ThinkPad Machine Display Elements
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Then Check Power Settings Display Always On USB Elements
	Then Check Power Settings Always On USB Section Display '$.PowerPage.AlwaysUSBDescriptionText'
	Then Check Power Settings Always On USB Section Display '$.PowerPage.AlwaysUSBLabelDescriptionText'

@CheckIdeaPadAlwaysOnUSB
Scenario: VAN272_TestStep17_Check The checkbox is still not show and the UI displays correctly
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Given Turn Off Always On USB toggle
	Then The Checkbox is nogreyout
