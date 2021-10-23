Feature: VAN14772_RemoveExcessLUDPMetricsForCHSProgram
	Test Case：https://jira.tc.lenovo.com/browse/VAN-14772
	Author ：fengya2

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep01_launch plugin and check metrics
	When go to preference page
	Given Turn on Vantage Usage Statistics 
	Given Close Vantage
	Given delete eventlog
	When Relaunch Wifi Plugin
	Given Waiting 30 seconds
	Then Check Wifi IMC and Plugin Toast Metric

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep02_Get Wi-Fi security state metric
	Given Close Vantage
	Given delete eventlog
	Given Launch Vantage
	Given Waiting 60 seconds
	Then Check TaskAction "Get-State" Metric Data

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep03_Click toggle and check metric
	Given Turn on Location for Vantagee
	Given Go to Wifisecurity
	Given delete eventlog
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Waiting 10 seconds
	Then Check Wifi Toggle on Metric
	Given delete eventlog
	When Set the WiFi Security Toggle 'Off' Within Subpage
	Given Waiting 10 seconds
	Then Check Wifi Toggle off Metric

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep04_Click re-enable toast and check Set-state metric
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Clear Notification Center History
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When Check Wifi reenable Toast Pop up
	Given Waiting 10 seconds
	Given delete eventlog
	Then Click re-enable Toast
	Given Waiting 10 seconds
	Then Check Wifi reenable Set-State Toast Metric

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep05_Disable location and Click re-enable toast
	Given Go to Wifisecurity
	Given Clear Notification Center History
	When Set the WiFi Security Toggle 'Off' Within Subpage
	Given Turn off Location Permission for Vantage
	When Check Wifi reenable Toast Pop up
	Given Waiting 10 seconds
	Given delete eventlog
	Then Click re-enable Toast
	Given Waiting 10 seconds
	Then Check TaskAction "Set-State" Metric Data

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep06_Check "Get-WifiHistory" Metric Data
	Given Close Vantage
	Given delete eventlog
	Given Launch Vantage
	Given Waiting 60 seconds
	Then Check TaskAction "Get-WifiHistory" Metric Data

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep07_Check "Get-DeviceConfig" Metric Data
	Given Close Vantage
	Given delete eventlog
	Given Launch Vantage
	Given Waiting 15 seconds
	Then Check TaskAction "Get-DeviceConfig" Metric Data

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep08_Click ok button and check metric
	When The user connect or disconnect WiFi on SmartStorage_5G 
	Given Turn on Location for Vantagee
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When  Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager 
	When Check Wifi green Toast Pop up
	Given Waiting 10 seconds
	Given delete eventlog
	Then Click ok Toast
	Given Waiting 10 seconds
	Then Check Wifi ok Toast Metric

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep09_Click change connection button and check metric
	Given Clear Notification Center History
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Yellow_1
	When Check Wifi yellow Toast Pop up
	Given Waiting 10 seconds
	Given delete eventlog
	Then Click change connection Toast
	Given Waiting 10 seconds
	Then Check TaskAction "Message-Clicked" Metric Data

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep10_Click yellow no-thanks button and check metric
	When The user connect or disconnect WiFi on SmartStorage_5G
	Given Clear Notification Center History
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Yellow_1
	When Check Wifi yellow Toast Pop up
	Given Waiting 10 seconds
	Given delete eventlog
	Then Click yellow ignore Toast
	Given Waiting 10 seconds
	Then Check Wifi yellow ignore Toast Metric

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep11_Click red change connection button and check metric
	When The user connect or disconnect WiFi on SmartStorage_5G
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1
	When Check Wifi red Toast Pop up
	Then Take Screen Shot 11UI in 14772 under LWScreenShotResult
	Given Waiting 10 seconds
	Given delete eventlog
	Then Click Critical change connection button
	Given Waiting 10 seconds
	Then Check TaskAction "Message-Clicked" Metric Data

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep12_Click red change ignore button and check metric
	When The user connect or disconnect WiFi on SmartStorage_5G
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1
	When Check Wifi red Toast Pop up
	Then Take Screen Shot 12UI in 14772 under LWScreenShotResult
	Given Waiting 5 seconds
	Given delete eventlog
	Then Click Critical ignore button
	Given Waiting 10 seconds
	Then Check Wifi red ignore Toast Metric

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep15_Click reenable and check metric
	When The user connect or disconnect WiFi on SmartStorage_5G
	Given Waiting 5 seconds
	Given Go to Wifisecurity
	Given Clear Notification Center History
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Set the WiFi Security Toggle 'Off' Within Subpage
	Given Waiting 10 seconds
	When Check Wifi reenable Toast Pop up
	Given delete eventlog
	Then Click re-enable Toast
	Given Waiting 10 seconds
	Then Check Wifi reenable Toast Metric

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep16_Click no thanks and check metric
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When LWS Text Status is enabled
	When Set the WiFi Security Toggle 'Off' Within Subpage
	Given Waiting 10 seconds
	When Check Wifi reenable Toast Pop up
	Given delete eventlog
	Then Click no thanks Toast
	Given Waiting 10 seconds
	Then Check Wifi no thanks Toast Metric

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep17_Click green ok button and check Receive-MessageAction metric
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When The user connect or disconnect WiFi on SmartStorage_5G
	When  Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager 
	When Check Wifi green Toast Pop up
	Given delete eventlog
	Then Click ok Toast
	Given Waiting 10 seconds
	Then Check Wifi Receive-MessageAction Toast Metric
	Then Check Wifi ok Toast Metric

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep18_Click yellow change connection button and check Receive-MessageAction metric
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Clear Notification Center History
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Yellow_1
	When Check Wifi yellow Toast Pop up
	Given Waiting 10 seconds
	Given delete eventlog
	Then Click change connection Toast
	Given Waiting 10 seconds
	Then Check TaskAction "Receive-MessageAction" Metric Data

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep19_Click yellow ignore button and check Receive-MessageAction metric
	When The user connect or disconnect WiFi on SmartStorage_5G
	Given Clear Notification Center History
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Yellow_1
	When Check Wifi yellow Toast Pop up
	Given Waiting 10 seconds
	Given delete eventlog
	Then Click yellow ignore Toast
	Given Waiting 10 seconds
	Then Check Wifi Receive-MessageAction Toast Metric

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep20_Click red change connection button and check Receive-MessageAction metric
	When The user connect or disconnect WiFi on SmartStorage_5G
	Given Clear Notification Center History
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1
	When Check Wifi red Toast Pop up
	Given Waiting 5 seconds
	Given delete eventlog
	Then Click Critical change connection button
	Given Waiting 10 seconds
	Then Check TaskAction "Receive-MessageAction" Metric Data

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep21_Click red ignore button and check Receive-MessageAction metric
	When The user connect or disconnect WiFi on SmartStorage_5G
	Given Clear Notification Center History
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1
	When Check Wifi red Toast Pop up
	Given Waiting 5 seconds
	Given delete eventlog
	Then Click Critical ignore button
	Given Waiting 10 seconds
	Then Check Wifi Receive-MessageAction Toast Metric

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep22_Click reenbale button and check Receive-MessageAction metric
	When The user connect or disconnect WiFi on SmartStorage_5G
	Given Clear Notification Center History
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When LWS Text Status is enabled
	When Set the WiFi Security Toggle 'Off' Within Subpage
	Given Waiting 10 seconds
	When Check Wifi reenable Toast Pop up
	Given delete eventlog
	Then Click re-enable Toast
	Given Waiting 10 seconds
	Then Check Wifi Receive-MessageAction Toast Metric

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep23_Click reenbale no button and check Receive-MessageAction metric
	When The user connect or disconnect WiFi on SmartStorage_5G
	Given Clear Notification Center History
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When LWS Text Status is enabled
	When Set the WiFi Security Toggle 'Off' Within Subpage
	Given Waiting 10 seconds
	When Check Wifi reenable Toast Pop up
	Given delete eventlog
	Then Click no thanks Toast
	Given Waiting 10 seconds
	Then Check Wifi Receive-MessageAction Toast Metric

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep24_connect wifi and check metrics to collect IMC transmit the system event
	When The user connect or disconnect WiFi on SmartStorage_5G
	Given wait 30 seconds
	When The user connect or disconnect WiFi off SmartStorage_5G
	Given wait 30 seconds
	Given delete eventlog
	When The user connect or disconnect WiFi on SmartStorage_5G
	Given wait 30 seconds
	Then Check Wifi msm-Connected Toast Metric

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep25_disconnect wifi and check metrics to collect IMC transmit the system event
	When The user connect or disconnect WiFi on SmartStorage_5G
	Given wait 10 seconds
	Given delete eventlog
	When The user connect or disconnect WiFi off SmartStorage_5G
	Given wait 10 seconds
	Then Check Wifi msm-Connected Toast Metric
	Then Check Wifi msm-Disconnected Toast Metric
	When The user connect or disconnect WiFi on SmartStorage_5G

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep27_chang network metric
	When The user connect or disconnect WiFi on autolea
	Given delete eventlog
	When The user connect or disconnect WiFi off autolea
	Then Check Wifi msm-Disconnected Toast Metric
	Then Check Wifi msm-Connected Toast Metric
	When The user connect or disconnect WiFi on autolea
	Then Check Wifi msm-Connected Toast Metric

@LUDPMetricsForCHSACDC
Scenario: VAN14772_TestStep28_AC DC metric
	When The user connect or disconnect WiFi on lenovo
	Given Location for Vantage has been Enabled
	When  Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager
	When Check Wifi green Toast Pop up
	Given Clear Notification Center History
	Given delete eventlog
	When User make the machine from AC to DC
	When Wait 65 minutes
	Then Check TaskAction "Get-State" Metric Data
	Given AC Condition(Connect the Adapter)
	When Wait 12 minutes
	Then Check TaskAction "Get-State" Metric Data

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep30_Check Pop up Green toast metric
	When  Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	When Start the IMC service in the task manager
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Waiting 120 seconds
	Given Clear Notification Center History
	Given delete eventlog
	When The user connect or disconnect WiFi on AutoTest
	When Check Wifi green Toast Pop up
	Given wait 10 seconds
	Then Check Wifi green Toast Metric

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep31_Check Pop up Yellow toast metric
	Given Clear Notification Center History
	When The user connect or disconnect WiFi on SmartStorage_5G
	When Check Wifi green Toast Pop up
	Given Clear Notification Center History
	Given delete eventlog
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Yellow_1
	When Check Wifi yellow Toast Pop up
	Given wait 10 seconds
	Then Check Wifi yellow Toast Metric

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep32_Check Pop up red toast metric
	When The user connect or disconnect WiFi on SmartStorage_5G
	Given wait 10 seconds
	Given Clear Notification Center History
	Given delete eventlog
	When The user connect or disconnect WiFi on __Do_Not_Trust_Network_Red_1
	When Check Wifi red Toast Pop up
	Then Click Critical ignore button
	Given wait 10 seconds
	Then Check Wifi red Toast Metric

@LUDPMetricsForCHS
Scenario: VAN14772_TestStep33_Check Pop up reenable toast metric
	When The user connect or disconnect WiFi on SmartStorage_5G
	Given wait 10 seconds
	Given Go to Wifisecurity
	Given Clear Notification Center History
	Given delete eventlog
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When Check Wifi reenable Toast Pop up
	Given wait 10 seconds
	Then Check Wifi reenable Toast Metric