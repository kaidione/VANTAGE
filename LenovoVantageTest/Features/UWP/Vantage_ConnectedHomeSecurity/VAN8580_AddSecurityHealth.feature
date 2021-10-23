Feature: VAN8580_AddSecurityHealth
	Test Case：https://jira.tc.lenovo.com/browse/VAN-8580
	Author ：Lea

@AddSecurityHealth @AddSecurityHealthonRS6
Scenario: VAN8580_TestStep01_Join Account and Check SH Display
	Given Remove "Subscription" Account from Web Console
	Given Launch Vantage
    Given User has Joined or Started a CHS "SecondJoinCodeB"Group
    Given Turn on Location for Vantagee
	Then Check Join the CHS Group
   	Then Take Screen Shot 01UI in 8580 under CHScreenShotResult

@AddSecurityHealth
Scenario: VAN8580_TestStep02_Check Password Status in SH
	Then PasswordProtection Result Keep the Same result with System

@AddSecurityHealth
Scenario: VAN8580_TestStep03_Check Hard Drive Status in SH
	Then HardDriveEncryption Result Keep the Same result with System

@AddSecurityHealth
Scenario: VAN8580_TestStep04_Check AntiVirus Status in SH
	Then  AntiVirus Result Keep the Same result with System
		
@AddSecurityHealth
Scenario: VAN8580_TestStep05_Check Firewall Status in SH
	Then Firewall Result Keep the Same result with System

@@AddSecurityHealthonRS6
Scenario: VAN8586_TestStep06_Check Sideload Status in SH
	Then AppFromUnknownSource Result Keep the Same result with System

@AddSecurityHealth
Scenario: VAN8580_TestStep07_Check Developer Mode Status in SH
	Then DeveloperMode Result Keep the Same result with System

@AddSecurityHealth
Scenario: VAN8580_TestStep08_Check Windows Activation Status in SH
	Then NotActivatedWindows Result Keep the Same result with System
	
@AddSecurityHealth
Scenario: VAN8580_TestStep09_Change Password in SH
    Given Delete Machine Password
	Given Launch Vantage
	When Check CHS Subpage
	Then Check false in SH
    When Create Password
	Then Check true in SH

@AddSecurityHealth
Scenario: VAN8580_TestStep12_Change Firewall in SH
    When On Firewall
	Then Firewall Result Keep the Same result with System
    When Off Firewall
	Then Firewall Result Keep the Same result with System

@AddSecurityHealthonRS6
Scenario: VAN8580_TestStep13_Change Sideload Mode
	When Enable Windows
	Then AppFromUnknownSource Result Keep the Same result with System
	When Enable Developer

@AddSecurityHealth
Scenario: VAN8580_TestStep14_Change Developer Mode
	Given Disable Developermode
	Then DeveloperMode Result Keep the Same result with System
	Given Enable Developermode
	Then DeveloperMode Result Keep the Same result with System

@AddSecurityHealth
Scenario: VAN8580_TestStep16_Click Here Link
	Given Launch Vantage
	When Check CHS Subpage
    When Click Here Link in CHS Subpage
	Then The Article Pop up
	Then Take Screen Shot 16UI in 8580 under CHScreenShotResult\

@AddSecurityHealth
Scenario: VAN8580_TestStep17_Disconnect Network Check SH
	Given Launch Vantage
	When The user connect or disconnect WiFi off lenovo
	When Check CHS Subpage
	When Click Offline Dialog Close Button 
	Then Take Screen Shot 17UI in 8580 under CHScreenShotResult\
	When The user connect or disconnect WiFi on lenovo
    Then Take Screen Shot 17UI2 in 8580 under CHScreenShotResult\

@AddSecurityHealth @AddSecurityHealthonRS6
Scenario: VAN8580_TestStep18_Check Disconnet Button
	When The user connect or disconnect WiFi on lenovo
	Given Launch Vantage
	When Check CHS Subpage
	When Click CHS "Disconnect" Button
	When Click CHS "DisconnectPromptBtn" Button
	Then It Will Directly Go to CHS Marketing Page
