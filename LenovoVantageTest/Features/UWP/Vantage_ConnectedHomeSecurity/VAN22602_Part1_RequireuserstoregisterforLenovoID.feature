Feature: VAN22602_RequireuserstoregisterforLenovoID
	Test Case：https://jira.tc.lenovo.com/browse/VAN-22602
	Author ：yangyu

@RequireuserstoregisterforLenovoID
Scenario: VAN22602_TestStep01_Check No new prompt popping up
	Given User Has Signed in LID "NotOn" The Prompt
	Given Close Vantage
	Given Launch Vantage
	Given go to wifisecurity
	Then There Will No New Prompt Popping up
		
@RequireuserstoregisterforLenovoID
Scenario: VAN22602_TestStep02_Check No new prompt popping up
	Given go to wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Waiting 1 seconds
	When Set the WiFi Security Toggle 'Off' Within Subpage
	Given Waiting 1 seconds
	Given Close Vantage
	Given Launch Vantage
	Given go to wifisecurity
	Then There Will No New Prompt Popping up

@RequireuserstoregisterforLenovoID
Scenario: VAN22602_TestStep03_Check No new prompt popping up
	Given go to wifisecurity
	Given Close Vantage
	Given Turn off Location Permission for Vantage
	Given Launch Vantage
	Given go to wifisecurity
	Then There Will No New Prompt Popping up

@RequireuserstoregisterforLenovoID
Scenario: VAN22602_TestStep04_Check No new prompt popping up
	Given go to wifisecurity
	Given Location for Vantage has been Enabled
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Waiting 1 seconds
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Change WifiSecurity StartTime To "-6" 
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given Waiting 2 seconds
	Given go to wifisecurity
	Then There Will No New Prompt Popping up

@RequireuserstoregisterforLenovoID
Scenario: VAN22602_TestStep05_Check new prompt will popping up
	Given go to wifisecurity
	Given Log out LID
	Given Waiting 1 seconds
	Then The Prompt Will Popping up

@RequireuserstoregisterforLenovoID
Scenario: VAN22602_TestStep06_Check new prompt will popping up
	Given User Has Signed in LID "NotOn" The Prompt
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Change WifiSecurity StartTime To "-30" 
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given Log out LID
	Given go to wifisecurity
	Then The Prompt Will Popping up And Prompt Can not Skipped

@RequireuserstoregisterforLenovoID
Scenario: VAN22602_TestStep07_Check No new prompt popping up
	Given User Has Signed in LID "NotOn" The Prompt
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin"
	Given Copy "68" Plugin to Install
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given Waiting 3 seconds
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin"
	Given Copy "79" Plugin to Install
	When Start the IMC service in the task manager
	Given Set Vantage Service as Plan Config
	Given Launch Vantage
	Given go to wifisecurity
	Then There Will No New Prompt Popping up

@RequireuserstoregisterforLenovoID
Scenario: VAN22602_TestStep08_Check No new prompt popping up
	Given Log out LID
	Given Waiting 1 seconds
	Given Reset Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	Given Delete LWS Registry
	When Start the IMC service in the task manager
	Given Set Vantage Service as Plan Config
	Given Launch Vantage
	Given click OOBE
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Change WifiSecurity StartTime To "-5" 
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given go to wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	Then There Will No New Prompt Popping up
	
@RequireuserstoregisterforLenovoID
Scenario: VAN22602_TestStep09_Check No new prompt popping up
	Given User Has Signed in LID "NotOn" The Prompt
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Change WifiSecurity StartTime To "-6" 
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given go to wifisecurity
	Then There Will No New Prompt Popping up

@RequireuserstoregisterforLenovoID
Scenario: VAN22602_TestStep10_Check No new prompt popping up
	Given Reset Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager
	Given Set Vantage Service as Plan Config
	Given Launch Vantage
	Given click OOBE
	Given Log out LID
	Given Waiting 1 seconds
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Change WifiSecurity StartTime To "-6" 
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given go to wifisecurity
	Then The Prompt Will Popping up
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Change WifiSecurity StartTime To "-7" 
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given go to wifisecurity
	Then The Prompt Will Popping up
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Change WifiSecurity StartTime To "-7" 
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given go to wifisecurity
	Then The Prompt Will Popping up
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Change WifiSecurity StartTime To "-7" 
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given go to wifisecurity
	Then The Prompt Will Popping up

@RequireuserstoregisterforLenovoID
Scenario: VAN22602_TestStep11_Check the prompt dialog will not pop up again untill next activation day
	Given Reset Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager
	Given Set Vantage Service as Plan Config
	Given Launch Vantage
	Given click OOBE
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Change WifiSecurity StartTime To "-6" 
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given go to wifisecurity
	Then The Prompt Will Popping up
	Given Close Vantage
	Given Launch Vantage
	Given go to wifisecurity
	Then There Will No New Prompt Popping up
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Change WifiSecurity StartTime To "-7" 
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given go to wifisecurity
	Then The Prompt Will Popping up
	Given Close Vantage
	Given Launch Vantage
	Given go to wifisecurity
	Then There Will No New Prompt Popping up
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Change WifiSecurity StartTime To "-7" 
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given go to wifisecurity
	Then The Prompt Will Popping up
	Given Close Vantage
	Given Launch Vantage
	Given go to wifisecurity
	Then There Will No New Prompt Popping up
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Change WifiSecurity StartTime To "-7" 
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given go to wifisecurity
	Then The Prompt Will Popping up
	Given Close Vantage
	Given Launch Vantage
	Given go to wifisecurity
	Then There Will No New Prompt Popping up

@RequireuserstoregisterforLenovoID
Scenario: VAN22602_TestStep12_Check the overlay can be closed
	Given Reset Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager
	Given Set Vantage Service as Plan Config
	Given Launch Vantage
	Given click OOBE
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Change WifiSecurity StartTime To "-6" 
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given go to wifisecurity
	Then The Prompt Can Be Closed
	Given Launch Vantage
	Then There Will No New Prompt Popping up
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Change WifiSecurity StartTime To "-7" 
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given go to wifisecurity
	Then The Prompt Can Be Closed
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Change WifiSecurity StartTime To "-7" 
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given go to wifisecurity
	Then The Prompt Can Be Closed
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Change WifiSecurity StartTime To "-7" 
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given go to wifisecurity
	Then The Prompt Can Be Closed

@RequireuserstoregisterforLenovoID
Scenario: VAN22602_TestStep13_Check pop up sign in LID dialog
	Given Reset Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager
	Given Set Vantage Service as Plan Config
	Given Launch Vantage
	Given click OOBE
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Change WifiSecurity StartTime To "-6" 
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given go to wifisecurity
	Given Click "Signin" On Log LID Prompt
	Then User Has Signed in LID "On" The Prompt

@RequireuserstoregisterforLenovoID
Scenario: VAN22602_TestStep14_Check No new prompt popping up
	Given go to wifisecurity
	Then There Will No New Prompt Popping up

@RequireuserstoregisterforLenovoID
Scenario: VAN22602_TestStep15_Check The Prompt Will Popping up
	Given Log out LID
	Given Waiting 1 seconds
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Change WifiSecurity StartTime To "-7" 
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given go to wifisecurity
	Then The Prompt Will Popping up
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Change WifiSecurity StartTime To "-7" 
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given go to wifisecurity
	Then The Prompt Will Popping up
	Given Close Vantage
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Change WifiSecurity StartTime To "-7" 
	When Start the IMC service in the task manager
	Given Launch Vantage
	Given go to wifisecurity
	Then The Prompt Will Popping up

