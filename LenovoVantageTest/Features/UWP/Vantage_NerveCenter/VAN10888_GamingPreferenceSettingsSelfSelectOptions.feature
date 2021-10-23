Feature: VAN10888_GamingPreferenceSettingsSelfSelectOptions
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-10888
	Author ：Wenhuan Zhang

Background:
	Given Machine is Gaming 

@GamingPreferenceSettingsSelfSelectOptions 
Scenario: VAN10888_TestStep01_L drop down menu list expand
	When Hover or Click L drop down menu
	Then The L drop down menu list is expanded

@GamingPreferenceSettingsSelfSelectOptions 
Scenario: VAN10888_TestStep02_Preference Settings page opened and Interest find
	When Hover or Click L drop down menu
	Then The L drop down menu list is expanded
	When Click the Preference settings link
	Then The Preference settings page is opened

@GamingPreferenceSettingsSelfSelectOptions 
Scenario: VAN10888_TestStep03_Interest find
	When Hover or Click L drop down menu
	Then The L drop down menu list is expanded
	When Click the Preference settings link
	Then The Preference settings page is opened
	Then How will you be using your device and Please tell us about your interests should be found

@GamingPreferenceSettingsSelfSelectOptions	
Scenario: VAN10888_TestStep04_L drop down menu list expand and Preference Settings page opened and Interest find
	When Enter to other subpage
	When Hover or Click L drop down menu
	Then The L drop down menu list is expanded
	When Click the Preference settings link
	Then The Preference settings page is opened
	Then How will you be using your device and Please tell us about your interests should be found