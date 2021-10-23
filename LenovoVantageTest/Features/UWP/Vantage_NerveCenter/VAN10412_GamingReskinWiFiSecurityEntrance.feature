Feature: VAN10412_GamingReskinWiFiSecurityEntrance
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-10412
	Author ：Xiao Yunyan

Background:
	Given Machine is Gaming
	Given WiFi Security plugin exist
	Given System notifications is disabled
	Given Disable or Enable Vantage Location Permission 'Enable'
	Given WiFi Security Display in homepage
	When Set the WiFi Security 'off' toggle within homepage

@GamingReskinWiFiSecurityEntranceNoDolby
Scenario: VAN10412_TestStep01_Position When Dolby Not Suppported
	Given Dobly not supported
	Then WiFi Security is at the bottom in Quick Settings section

@GamingReskinWiFiSecurityEntrance
Scenario: VAN10412_TestStep02_Position When Dolby Suppported
	Given Dobly supported
	Then WiFi Security is above of Dolby

@GamingReskinWiFiSecurityEntrance @GamingSmokeWifiSecurity
Scenario: VAN10412_TestStep03_Gear Icon Position
	Then The WiFi Security gear icon is displayed before the toggle

@GamingReskinWiFiSecurityEntrance @GamingSmokeWifiSecurity
Scenario: VAN10412_TestStep04_Check WiFi Security Theme
	When Click the WiFi Security Gear Icon
	Then WiFi Security subpage is opened
	Then Take Screen Shot Check_WiFi_Security_Theme_TestStep04 in 10412 under GamingScreenShotResult

@GamingReskinWiFiSecurityEntrance
Scenario: VAN10412_TestStep05_Check WiFi Security Subpage Open
	Then The WiFi Security toggle status within homepage 'off'
	When Click the WiFi Security Gear Icon
	Then WiFi Security subpage is opened

@GamingReskinWiFiSecurityEntrance
Scenario: VAN10412_TestStep06_Check WiFi Security Toggle OFF When Reopen Vantage
	Then The WiFi Security toggle status within homepage 'off'
	When Close Vantage
	When ReLaunch Vantage
	Then The WiFi Security toggle status within homepage 'off'

@GamingReskinWiFiSecurityEntrance
Scenario: VAN10412_TestStep07_Check Subpage WiFi Security Toggle OFF
	Then The WiFi Security toggle status within homepage 'off'
	When Click the WiFi Security Gear Icon
	Then WiFi Security subpage is opened
	Then The WiFi Security toggle status within subpage 'off'

@GamingReskinWiFiSecurityEntrance
Scenario: VAN10412_TestStep08_Check Homepage WiFi Security Toggle OFF After Click Back Button
	Then The WiFi Security toggle status within homepage 'off'
	When Click the WiFi Security Gear Icon
	Then WiFi Security subpage is opened
	When The user click WiFi Security back button
	Then The WiFi Security toggle status within homepage 'off'

@GamingReskinWiFiSecurityEntrance
Scenario: VAN10412_TestStep09_Check WiFi Security Toggle OFF When Enter Other Page
	Then The WiFi Security toggle status within homepage 'off'
	When Click the Auto Close Gear Icon
	When The user click auto close back button
	Then The WiFi Security toggle status within homepage 'off'

@GamingReskinWiFiSecurityEntrance
Scenario: VAN10412_TestStep10_Check WiFi Security Toggle On 
	Then The WiFi Security toggle status within homepage 'off'
	When Set the WiFi Security 'on' toggle within homepage
	Then The WiFi Security toggle status within homepage 'on'
	
@GamingReskinWiFiSecurityEntrance
Scenario: VAN10412_TestStep11_Check Subpage WiFi Security Toggle On
	When Set the WiFi Security 'off' toggle within homepage
	When Click the WiFi Security Gear Icon
	Then WiFi Security subpage is opened
	When Click the WiFi Security 'off' toggle within subpage
	Then The WiFi Security toggle status within subpage 'on'

@GamingReskinWiFiSecurityEntrance
Scenario: VAN10412_TestStep12_Check Homepage WiFi Security Toggle On After Click Y Logo
	Then The WiFi Security toggle status within homepage 'off'
	When Set the WiFi Security 'On' toggle within homepage
	When Click the WiFi Security Gear Icon
	Then The WiFi Security toggle status within subpage 'on'
	When Click Y logo
	Then The WiFi Security toggle status within homepage 'on'

@GamingReskinWiFiSecurityEntrance
Scenario: VAN10412_TestStep13_Check WiFi Security Toggle On After Reopen Vantage
	Then The WiFi Security toggle status within homepage 'off'
	When Set the WiFi Security 'On' toggle within homepage
	When Close Vantage
	When ReLaunch Vantage
	Then The WiFi Security toggle status within homepage 'on'

@GamingReskinWiFiSecurityEntrance
Scenario: VAN10412_TestStep14_Check WiFi Security Toggle On 
	When Set the WiFi Security 'on' toggle within homepage
	When Set the WiFi Security 'off' toggle within homepage
	Then The WiFi Security toggle status within homepage 'off'

@GamingReskinWiFiSecurityEntrance
Scenario: VAN10412_TestStep15_Check WiFi Security Subpage Toggle Off
	When Set the WiFi Security 'On' toggle within homepage
	When Click the WiFi Security Gear Icon
	Then WiFi Security subpage is opened
	Then The WiFi Security toggle status within subpage 'on'
	When Click the WiFi Security 'on' toggle within subpage
	Then The WiFi Security toggle status within subpage 'off'

@GamingReskinWiFiSecurityEntrance
Scenario: VAN10412_TestStep16_Check WiFi Security Homepage Toggle Off After Click Device Link
	Then The WiFi Security toggle status within homepage 'off'
	When Click the WiFi Security Gear Icon
	Then WiFi Security subpage is opened
	When Click the Device link in the navigation bar
	Then The WiFi Security toggle status within homepage 'off'

@GamingReskinWiFiSecurityEntranceS3
Scenario: VAN10412_TestStep17_Check WiFi Security Toggle OFF When Enter Sleep
	Then The WiFi Security toggle status within homepage 'off'
	When Enter sleep
	Then The WiFi Security toggle status within homepage 'off'

@GamingReskinWiFiSecurityEntranceS4
Scenario: VAN10412_TestStep18_Check WiFi Security Toggle OFF When Enter Hibernate
	Then The WiFi Security toggle status within homepage 'off'
	When Enter hibernate
	Then The WiFi Security toggle status within homepage 'off'
	Given System notifications is enabled