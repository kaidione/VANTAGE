Feature: VAN25233_GamingEnableNahimic
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-25233

Background: 
	Given Machine is Gaming
	When kill Nahimic3 and wait 0 second
	When kill msedge and wait 1 second
	Given Nahamic App is installed or uninstalled 'uninstalled'

@GamingEnableNahimic
Scenario: VAN25233_TestStep02_Nahamic Not Be Shown When App Is Not Insatlled
	When Click the Auto Close Gear Icon
	When Click the Device link in the navigation bar
	Then Nahimic icon should be 'hidden' in the system tools section 

@GamingEnableNahimic
Scenario: VAN25233_TestStep03_Nahimic icon Should Not Be Shown
	Given Close Vantage
	Given Launch Vantage
	Then Nahimic icon should be 'hidden' in the system tools section 

@GamingEnableNahimic
Scenario: VAN25233_TestStep04_Nahamic Not Be Shown When App Is Not Installed
	Given Nahamic App is installed or uninstalled 'installed'
	Then Nahimic icon should be 'hidden' in the system tools section 

@GamingEnableNahimic
Scenario: VAN25233_TestStep05_Nahamic Not Be Shown When App Is Installed
	Given Nahamic App is installed or uninstalled 'installed'
	When Click the Auto Close Gear Icon
	When Click the Device link in the navigation bar
	Then Nahimic icon should be 'shown' in the system tools section 

@GamingEnableNahimic
Scenario: VAN25233_TestStep06_Nahamic Not Be Shown When App Is Installed
	Given Nahamic App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	Then Nahimic icon should be 'shown' in the system tools section 

@GamingEnableNahimic @GamingSmokeNahamic
Scenario: VAN25233_TestStep07_Nahamic Not Be Shown When App Is Installed
	Given Nahamic App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	Then Nahimic icon should be 'shown' in the system tools section 
	When Click the Nahimic icon
	Then Nahamic app should be opened

@GamingEnableNahimic
Scenario: VAN25233_TestStep08_Nahamic Not Install Window Should Be Shown
	Given Nahamic App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	Given Nahamic App is installed or uninstalled 'uninstalled'
	Then Nahimic icon should be 'shown' in the system tools section 
	When Click the Nahimic icon
	Then Nahamic Install Window Should Be 'shown'

@GamingEnableNahimic
Scenario: VAN25233_TestStep09_Nahamic Not Install Window Should Be Closed
	Given Nahamic App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	Given Nahamic App is installed or uninstalled 'uninstalled'
	When Click the Nahimic icon
	Then Nahamic Install Window Should Be 'shown'
	When Click 'Close' Button In Nahamic Install Window
	Then Nahamic Install Window Should Be 'hidden'
	Then Nahimic Install Web page should Be 'hidden'

@GamingEnableNahimic
Scenario: VAN25233_TestStep10_Nahamic Not Install Window Should Be Closed
	Given Nahamic App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage	
	Given Nahamic App is installed or uninstalled 'uninstalled'
	Then Nahimic icon should be 'shown' in the system tools section 
	When Click the Nahimic icon
	Then Nahamic Install Window Should Be 'shown'
	When Click 'Cancel' Button In Nahamic Install Window
	Then Nahamic Install Window Should Be 'hidden'
	Then Nahimic Install Web page should Be 'hidden'

@GamingEnableNahimic
Scenario: VAN25233_TestStep11_Nahamic Not Install Window Should Be Closed
	Given Nahamic App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	Given Nahamic App is installed or uninstalled 'uninstalled'
	Then Nahimic icon should be 'shown' in the system tools section
	When Click the Nahimic icon
	Then Nahamic Install Window Should Be 'shown'
	When Click 'Install' Button In Nahamic Install Window
	Then Nahimic Install Web page should Be 'shown'
	When kill msedge and wait 1 second
	Then Nahamic Install Window Should Be 'hidden'

@GamingEnableNahimic
Scenario: VAN25233_TestStep12_Nahamic Install Window Should Be Closed
	Given Nahamic App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	Given Nahamic App is installed or uninstalled 'uninstalled'
	Then Nahimic icon should be 'shown' in the system tools section
	Given Nahamic App is installed or uninstalled 'installed'
	When Click the Nahimic icon
	Then Nahamic app should be opened

@GamingEnableNahimic
Scenario: VAN25233_TestStep13_Nahimic icon should not be shown in the system tool section
	Given Nahamic App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	Given Nahamic App is installed or uninstalled 'uninstalled'
	When Click the Auto Close Gear Icon
	When Click the Device link in the navigation bar
	Then Nahimic icon should be 'hidden' in the system tools section

@GamingEnableNahimic
Scenario: VAN25233_TestStep14_Nahimic icon should be shown in the system tool section
	Given Nahamic App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	Given Nahamic App is installed or uninstalled 'uninstalled'
	When Click the Auto Close Gear Icon
	Given Nahamic App is installed or uninstalled 'installed'
	When Click the Device link in the navigation bar
	Then Nahimic icon should be 'shown' in the system tools section

@GamingEnableNahimic
Scenario: VAN25233_TestStep15_Nahimic icon should be shown in the system tool section
	Given Nahamic App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	Given Nahamic App is installed or uninstalled 'uninstalled'
	Given Nahamic App is installed or uninstalled 'installed'
	When Click the Auto Close Gear Icon
	When Click the Device link in the navigation bar
	When Click the Nahimic icon
	Then Nahimic icon should be 'shown' in the system tools section
	Then Nahamic app should be opened

@GamingEnableNahimic
Scenario: VAN25233_TestStep16_Nahimic icon should not be shown in the system tool section
	Given Nahamic App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	Given Nahamic App is installed or uninstalled 'uninstalled'
	Given Close Vantage
	Given Launch Vantage
	Then Nahimic icon should be 'hidden' in the system tools section

@GamingEnableNahimic
Scenario: VAN25233_TestStep17_01_Nahamic Not Be Shown When App Is Not Insatlled 
	Then Nahimic icon should be 'hidden' in the system tools section 

@GamingEnableNahimic
Scenario: VAN25233_TestStep17_Nahimic icon should be shown in the system tool section
	Given Nahamic App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	Given Nahamic App is installed or uninstalled 'uninstalled'
	When Click the Nahimic icon
	Given Nahamic App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	Then Nahimic icon should be 'shown' in the system tools section

@GamingEnableNahimic
Scenario: VAN25233_TestStep18_Nahamic app should be opened
	Given Nahamic App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	Given Nahamic App is installed or uninstalled 'uninstalled'
	When Click the Nahimic icon
	Given Nahamic App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	When Click the Nahimic icon
	Then Nahamic app should be opened
	When kill Nahimic3 and wait 0 second