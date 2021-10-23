Feature: VAN25234_GamingEnableX-rite
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-25234

Background: 
	Given Machine is Gaming
	When kill XRiteColorAssistantSetup and wait 0 second
	When kill XRiteColorAssistant and wait 0 second
	When Kill XRiteColorAssistantSetup.tmp by processName
	When kill unins000 and wait 0 second
	When kill msedge and wait 1 second
	Given X-rite App is installed or uninstalled 'uninstalled'

@GamingEnableX-rite
Scenario: VAN25234_TestStep02_X-rite Not Be Shown When App Is Not Insatlled
	When Click the Auto Close Gear Icon
	When Click the Device link in the navigation bar
	Then X-rite icon should be 'hidden' in the system tools section

@GamingEnableX-rite
Scenario: VAN25234_TestStep03_X-rite icon Should Not Be Shown Is Not Insatlled
	Given Close Vantage
	Given Launch Vantage
	Then X-rite icon should be 'hidden' in the system tools section

@GamingEnableX-rite
Scenario: VAN25234_TestStep04_X-rite Not Be Shown When App Is Not Installed
	Given X-rite App is installed or uninstalled 'installed'
	Then X-rite icon should be 'hidden' in the system tools section

@GamingEnableX-rite
Scenario: VAN25234_TestStep05_X-rite Not Be Shown When App Is Installed
	Given X-rite App is installed or uninstalled 'installed'
	When Click the Auto Close Gear Icon
	When Click the Device link in the navigation bar
	Then X-rite icon should be 'shown' in the system tools section

@GamingEnableX-rite
Scenario: VAN25234_TestStep06_X-rite Not Be Shown When App Is Installed
	Given X-rite App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	Then X-rite icon should be 'shown' in the system tools section

@GamingEnableX-rite @GamingSmokeXrite
Scenario: VAN25234_TestStep07_X-rite Not Be Shown When App Is Installed
	Given X-rite App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	Then X-rite icon should be 'shown' in the system tools section
	When Click the X-rite icon
	Then X-rite app should be opened

@GamingEnableX-rite
Scenario: VAN25234_TestStep08_X-rite Not Install Window Should Be Shown
	Given X-rite App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	Given X-rite App is installed or uninstalled 'uninstalled'
	When Click the X-rite icon
	Then X-rite Install Window Should Be 'shown'

@GamingEnableX-rite
Scenario: VAN25234_TestStep09_X-rite Not Install Window Should Be Closed
	Given X-rite App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	Given X-rite App is installed or uninstalled 'uninstalled'
	When Click the X-rite icon
	Then X-rite Install Window Should Be 'shown'
	When Click 'Close' Button In X-rite Install Window
	Then X-rite Install Window Should Be 'hidden'
	Then X-rite Install Web page Should Be 'hidden'

@GamingEnableX-rite
Scenario: VAN25234_TestStep10_X-rite Not Install Window Should Be Closed
	Given X-rite App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage	
	Given X-rite App is installed or uninstalled 'uninstalled'
	Then X-rite icon should be 'shown' in the system tools section
	When Click the X-rite icon
	Then X-rite Install Window Should Be 'shown'
	When Click 'Cancel' Button In X-rite Install Window
	Then X-rite Install Window Should Be 'hidden'
	Then X-rite Install Web page Should Be 'hidden'

@GamingEnableX-rite
Scenario: VAN25234_TestStep11_X-rite Not Install Window Should Be Closed And Web Page Should Be Opened
	Given X-rite App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage	
	Given X-rite App is installed or uninstalled 'uninstalled'
	Then X-rite icon should be 'shown' in the system tools section
	When Click the X-rite icon
	Then X-rite Install Window Should Be 'shown'
	When Click 'Install' Button In X-rite Install Window
	Then X-rite Install Web page Should Be 'shown'
	When kill msedge and wait 1 second
	Then X-rite Install Window Should Be 'hidden'

@GamingEnableX-rite
Scenario: VAN25234_TestStep12_X-rite app should be opened
	Given X-rite App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage	
	Given X-rite App is installed or uninstalled 'uninstalled'
	Given X-rite App is installed or uninstalled 'installed'
	When Click the X-rite icon
	Then X-rite app should be opened

@GamingEnableX-rite
Scenario: VAN25234_TestStep13_X-rite app not should  in the system tools section
	Given X-rite App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage	
	Given X-rite App is installed or uninstalled 'uninstalled'
	When Click the Auto Close Gear Icon
	When Click the Device link in the navigation bar
	Then X-rite icon should be 'hidden' in the system tools section

@GamingEnableX-rite
Scenario: VAN25234_TestStep14_X-rite app should be shown in the system tool section
	Given X-rite App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage	
	Given X-rite App is installed or uninstalled 'uninstalled'
	When Click the Auto Close Gear Icon
	Given X-rite App is installed or uninstalled 'installed'
	When Click the Device link in the navigation bar
	Then X-rite icon should be 'shown' in the system tools section

@GamingEnableX-rite
Scenario: VAN25234_TestStep15_X-rite app should be opened
	Given X-rite App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage	
	Given X-rite App is installed or uninstalled 'uninstalled'
	Given X-rite App is installed or uninstalled 'installed'
	When Click the Auto Close Gear Icon
	When Click the Device link in the navigation bar
	When Click the X-rite icon
	Then X-rite app should be opened

@GamingEnableX-rite
Scenario: VAN25234_TestStep16_X-rite app should not be shown in the system tool section
	Given X-rite App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage	
	Given X-rite App is installed or uninstalled 'uninstalled'
	Given Close Vantage
	Given Launch Vantage	
	Then X-rite icon should be 'hidden' in the system tools section

@GamingEnableX-rite
Scenario: VAN25234_TestStep17_01_X-rite app should not be shown in the system tool section
	Then X-rite icon should be 'hidden' in the system tools section
	
@GamingEnableX-rite
Scenario: VAN25234_TestStep17_X-rite icon should be shown in the system tool section
	Given X-rite App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	Given X-rite App is installed or uninstalled 'uninstalled'
	Given X-rite App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	Then X-rite icon should be 'shown' in the system tools section

@GamingEnableX-rite
Scenario: VAN25234_TestStep18_X-rite app should be opened
	Given X-rite App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	Given X-rite App is installed or uninstalled 'uninstalled'
	When Click the X-rite icon
	Given X-rite App is installed or uninstalled 'installed'
	Given Close Vantage
	Given Launch Vantage
	When Click the X-rite icon
	Then X-rite app should be opened
	When kill XRiteColorAssistantSetup and wait 0 second
	When kill XRiteColorAssistant and wait 1 second
	When Kill XRiteColorAssistantSetup.tmp by processName