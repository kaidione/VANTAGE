Feature: VAN10414_GamingAppSettingsPreferencePageReskin
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-10414
	Author ：Wenhuan Zhang

Background:
	Given Machine is Gaming 

@GamingAppSettingsPreferencePageReskin
Scenario: VAN10414_TestStep01_Check the Preference settings page is opened
	Given Machine is Gaming
	And The L drop-down list is expanded
	When Click the Preference settings link
	Then The Preference settings page is opened

@GamingAppSettingsPreferencePageReskin
Scenario: VAN10414_TestStep02_Check the Preference settings page UI Is Gaming Style
	Given Machine is Gaming
	And The L drop-down list is expanded
	When Click the Preference settings link
	Then The Preference settings page is opened
	Then Take Screen Shot Check the Preference settings page_TestStep02 in 10414 under GamingScreenShotResult

@GamingAppSettingsPreferencePageReskin
Scenario: VAN10414_TestStep03_Go Back to homepage
	Given Machine is Gaming
	And The L drop-down list is expanded
	When Click the Preference settings link
	Then The Preference settings page is opened
	When Click BACK link
	Then Check the page go back to homepage

@GamingAppSettingsPreferencePageReskin	
Scenario: VAN10414_TestStep04_Go Back to homepage
	Given Machine is Gaming
	And The L drop-down list is expanded
	When Click the Preference settings link
	Then The Preference settings page is opened
	When Click Y link
	Then Check the page go back to homepage

@GamingAppSettingsPreferencePageReskin
Scenario: VAN10414_TestStep05_Go Back to homepage
	Given Machine is Gaming
	And The L drop-down list is expanded
	When Click the Preference settings link
	Then The Preference settings page is opened
	When Click Device link
	Then Check the page go back to homepage