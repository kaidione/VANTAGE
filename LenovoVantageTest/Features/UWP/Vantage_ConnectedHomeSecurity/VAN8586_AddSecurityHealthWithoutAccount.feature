Feature: VAN8586_AddSecurityHealthWithoutAccount
	Test Case：https://jira.tc.lenovo.com/browse/VAN-8586
	Author ：Lea

@AddSecurityHealthWithoutAccount
Scenario: VAN8586_TestStep01_Check SH Display
	Given Launch Vantage
	Given Turn on Location for Vantagee
	When Check CHS Subpage
   	Then Take Screen Shot 01UI in 8580 under CHScreenShotResult

@AddSecurityHealthWithoutAccount
Scenario: VAN8586_TestStep02_Check Password Status in SH
	Then PasswordProtection Result Keep the Same result with System

@AddSecurityHealthWithoutAccount
Scenario: VAN8586_TestStep03_Check Hard Drive Status in SH
	Then HardDriveEncryption Result Keep the Same result with System

@AddSecurityHealthWithoutAccount
Scenario: VAN8586_TestStep04_Check AntiVirus Status in SH
	Then  AntiVirus Result Keep the Same result with System
		
@AddSecurityHealthWithoutAccount
Scenario: VAN8586_TestStep05_Check Firewall Status in SH
	Then Firewall Result Keep the Same result with System

@AddSecurityHealthWithoutAccountonRS6
Scenario: VAN8586_TestStep06_Check Sideload Status in SH
	Then AppFromUnknownSource Result Keep the Same result with System

@AddSecurityHealthWithoutAccount
Scenario: VAN8586_TestStep07_Check Developer Mode Status in SH
	Then DeveloperMode Result Keep the Same result with System

@AddSecurityHealthWithoutAccount
Scenario: VAN8586_TestStep08_Check Windows Activation Status in SH
	Then NotActivatedWindows Result Keep the Same result with System
	
@AddSecurityHealthWithoutAccount
Scenario: VAN8586_TestStep09_Change Password in SH
    Given Delete Machine Password
	Given Launch Vantage
	When Check CHS Subpage
	Then Check false in SH
    When Create Password
	Then Check true in SH

@AddSecurityHealthWithoutAccount
Scenario: VAN8586_TestStep12_Change Firewall in SH
    When On Firewall
	Then Firewall Result Keep the Same result with System
    When Off Firewall
	Then Firewall Result Keep the Same result with System

@AddSecurityHealthWithoutAccount
Scenario: VAN8586_TestStep14_Change Developer Mode
	Given Disable Developermode
	Then DeveloperMode Result Keep the Same result with System
	Given Enable Developermode
	Then DeveloperMode Result Keep the Same result with System

@AddSecurityHealthWithoutAccountonRS6
Scenario: VAN8586_TestStep15_Change Sideload Status in SH
	When Enable Windows
	Then AppFromUnknownSource Result Keep the Same result with System
	When Enable Developer

@AddSecurityHealthWithoutAccount
Scenario: VAN8586_TestStep16_Click Here Link
	Given Launch Vantage
	When Check CHS Subpage
    When Click Here Link in CHS Subpage
	Then The Article Pop up
	Then Take Screen Shot 16UI in 8580 under CHScreenShotResult\

@AddSecurityHealthWithoutAccount
Scenario: VAN8586_TestStep17_Disconnect Network Check SH
	Given Launch Vantage
	When The user connect or disconnect WiFi off lenovo
	When Check CHS Subpage
	When Click Offline Dialog Close Button 
	Then Take Screen Shot 17UI in 8580 under CHScreenShotResult\
	When The user connect or disconnect WiFi on lenovo
    Then Take Screen Shot 17UI2 in 8580 under CHScreenShotResult\



