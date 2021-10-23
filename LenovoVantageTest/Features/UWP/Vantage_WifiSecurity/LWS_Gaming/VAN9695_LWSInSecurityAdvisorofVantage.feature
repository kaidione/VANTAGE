Feature: VAN9695_LWStoggleandtileinthehomepageforgamingtheme
	Test Case：https://jira.tc.lenovo.com/browse/VAN-9695
	Author ：yangyu

@LWStoggleandtileinthehomepageforgamingtheme @lwssmoke9695
Scenario: VAN9695_TestStep01_the UI of the tille is consistant with UI spec
	Given Location for Vantage has been Enabled
	When The user connect or disconnect WiFi on lenovo
	When Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin Data"
	Given Delete LWS Registry
	When Start the IMC service in the task manager
	Given Close Vantage
	Given Launch Vantage
	Given Go to Wifisecurity
	Then The WiFi Security toggle status within subpage 'off'
	Given Install Vantage
	Then Take Screen Shot 01UI in 9695 under LWScreenShotResult

@LWStoggleandtileinthehomepageforgamingtheme @lwssmoke9695
Scenario: VAN9695_TestStep02_check turn to the LWS subapge
	When Click seticon in LWS Page
	When LWS Text Status is disabled
	Then There is no Threat locator in Wifi Page
	When Set the WiFi Security Toggle 'On' Within Subpage
	Then There is expandstatus in LWS Page
	Then Take Screen Shot 02UI in 9695 under LWScreenShotResult

@CaseNeedTestBlueBarGaming
Scenario: VAN969_TestStep03_check LWS homepage bluebar
	Given Install Vantage
	Given Turn off Location Permission for Vantage
	When Click homepagetoggleoff in LWS Page
	Then The Tutorial Will Pop up And Show SlideBlueBar
	Then Take Screen Shot 03UI in 9695 under LWScreenShotResult

@CaseNeedTestBlueBarGaming
Scenario: VAN969_TestStep04_check Click LWS homepage bluebar yes button
	Given Install Vantage
	Given Turn off Location Permission for Vantage
	When Click homepagetoggleoff in LWS Page
	Then The Tutorial Will Pop up And Show SlideBlueBar
	Then Take Screen Shot 04UI in 9695 under LWScreenShotResult
	When Click CHS "Yes" Button
	Then The HomeWifiToggle is "On"

@CaseNeedTestBlueBarGaming
Scenario: VAN969_TestStep05_check Click LWS subpage status
	Given Go to Wifisecurity
	Then The WiFi Security toggle status within subpage 'on'

@CaseNeedTestBlueBarGaming
Scenario: VAN969_TestStep06_check Click LWS homepage bluebar no button
	Given Install Vantage
	Given Turn off Location Permission for Vantage
	When Click homepagetoggleoff in LWS Page
	Then The Tutorial Will Pop up And Show SlideBlueBar
	When Click CHS "No" Button
	Then The HomeWifiToggle is "Off"

@CaseNeedTestBlueBarGaming
Scenario: VAN969_TestStep07_check Click LWS subpage status
	Given Go to Wifisecurity
	Then The WiFi Security toggle status within subpage 'off'

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep08_check back homepage toggle is "on"
	Given Turn off Location Service in Settings Page
	Given Install Vantage
	Given Go to Wifisecurity
	When Click location dialog agree button in LWS Page
	Given Set Vantage Location "On" In Setting
	When Click gamingdevice in LWS Page
	Then The HomeWifiToggle is "On"
	Then Take Screen Shot 08UI in 9695 under LWScreenShotResult

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep09_check back homepage toggle is "off"
	Given Turn off Location Service in Settings Page
	Given Install Vantage
	Given Go to Wifisecurity
	Then Take Screen Shot 09UI01 in 9695 under LWScreenShotResult
	When Click location dialog close button in LWS Page
	When Click gamingdevice in LWS Page
	Then The HomeWifiToggle is "Off"

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep10_check homepage location dialog
	When Click homepagetoggleoff in LWS Page
	Then There is location dialog in LWS Page
	Then Take Screen Shot 10UI in 9695 under LWScreenShotResult

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep11_check homepage location on 
	When Click homepagetoggleoff in LWS Page
	Then There is location dialog in LWS Page
	When Click location dialog agree button in LWS Page
	Given Set Vantage Location "On" In Setting
	Then The HomeWifiToggle is "On"

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep12_check homepage toggle on then subpage toggle on
	Given Turn off Location Service in Settings Page
	When Click location dialog agree button in LWS Page
	Given Set Vantage Location "On" In Setting
	Given Go to Wifisecurity
	Then Waiting 2 seconds
	Then The WiFi Security toggle status within subpage 'on'
	Then Take Screen Shot 12UI in 9695 under LWScreenShotResult

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep13_check homepage close setting without action
	Given Turn off Location Service in Settings Page
	When Click location dialog agree button in LWS Page
	Given Close Settings Page Without Action
	Then The HomeWifiToggle is "Off"
	Given Go to Wifisecurity
	When Click location dialog close button in LWS Page
	Then Waiting 2 seconds
	Then The WiFi Security toggle status within subpage 'off'

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep14_check click twice location dialog then homepage toggle is off
	When Click homepagetoggleoff in LWS Page
	When Click location dialog close button in LWS Page
	When Click homepagetoggleoff in LWS Page
	When Click location dialog close button in LWS Page
	Then The HomeWifiToggle is "Off"

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep15_check 14 is met then subpage wifi toggle also off
	Given Go to Wifisecurity
	Then The WiFi Security toggle status within subpage 'off'

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep16_check turn off location in subpage when go to homepage dialog will pop up 
	Given Turn on Location for Vantagee
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	Given Turn off Location Permission for Vantage
	Given Close Vantage
	Given Launch Vantage
	Then There is location dialog in LWS Page
	Then Take Screen Shot 16UI in 9695 under LWScreenShotResult

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep17_check homepage location permisisson
	Given Turn on Location for Vantagee
	When Set the WiFi Security Toggle 'On' Within Homepage
	Given Turn off Location Service in Settings Page
	Then There is location dialog in LWS Page
	Then Take Screen Shot 17UI in 9695 under LWScreenShotResult

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep18_check location turn on then turn off homepage toggle
	Given Turn on Location for Vantagee
	When Set the WiFi Security Toggle 'Off' Within Homepage
	Then The HomeWifiToggle is "Off"

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep19_check 18 is met then subpage wifi toggle also off
	When Set the WiFi Security Toggle 'On' Within Homepage
	When Set the WiFi Security Toggle 'Off' Within Homepage
	Then The HomeWifiToggle is "Off"
	Given Go to Wifisecurity
	Then Waiting 2 seconds
	Then The WiFi Security toggle status within subpage 'off'

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep20_disable LWS in subpage then homepage also off
	Given Turn on Location for Vantagee
	When Set the WiFi Security Toggle 'On' Within Homepage
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When Click gamingdevice in LWS Page
	Then The HomeWifiToggle is "Off"

@LWStoggleandtileinthehomepageforgamingtheme @lwssmoke9695
Scenario: VAN9695_TestStep21_check homepage toggle can be trun on 
	When Set the WiFi Security Toggle 'On' Within Homepage
	Then The HomeWifiToggle is "On"

@LWStoggleandtileinthehomepageforgamingtheme @lwssmoke9695
Scenario: VAN9695_TestStep22_check 21 is met then subpage wifi toggle also on
	When Set the WiFi Security Toggle 'Off' Within Homepage
	Given Go to Wifisecurity
	Then Waiting 2 seconds
	Then The WiFi Security toggle status within subpage 'off'
	When Click gamingdevice in LWS Page
	When Set the WiFi Security Toggle 'On' Within Homepage
	Given Go to Wifisecurity    
	Then Waiting 2 seconds
	Then The WiFi Security toggle status within subpage 'on'

@LWStoggleandtileinthehomepageforgamingtheme @lwssmoke9695
Scenario: VAN9695_TestStep23_check turn on toggle in subpage then home page also on
	When Set the WiFi Security Toggle 'Off' Within Homepage
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Click gamingdevice in LWS Page
	Then The HomeWifiToggle is "On"

@LWStoggleandtileinthehomepageforgamingtheme @lwssmoke9695
Scenario: VAN9695_TestStep24_check turn off location in subpage and click yes 
	When Set the WiFi Security Toggle 'Off' Within Homepage
	Given Turn off Location Permission for Vantage
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Click location dialog agree button in LWS Page
	Given Close Settings Page Without Action
	When Click gamingdevice in LWS Page
	Then The HomeWifiToggle is "Off"

@LWStoggleandtileinthehomepageforgamingtheme @lwssmoke9695
Scenario: VAN9695_TestStep25_check click yes enable location then homepage toggle is on
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Click location dialog agree button in LWS Page
	Given Set Vantage Location "On" In Setting
	When Click gamingdevice in LWS Page
	Then The HomeWifiToggle is "On"

@LWStoggleandtileinthehomepageforgamingtheme @lwssmoke9695
Scenario: VAN9695_TestStep26_check click reenable now then subpage and homepage toggle is on
	Given Turn on Location for Vantagee
	Given Clear Notification Center History
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Set the WiFi Security Toggle 'Off' Within Subpage
	Then Check Wifi reenable Toast Pop up	
	Then Click re-enable Toast
	Then Waiting 2 seconds
	Then The WiFi Security toggle status within subpage 'on'
	When Click gamingdevice in LWS Page
	Then The HomeWifiToggle is "On"

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep27_check click reenalbe now when keep homepage open then toggle is on
	Given Clear Notification Center History
	Given Slide The Page To "-100"
	When Set the WiFi Security Toggle 'On' Within Homepage
	When Set the WiFi Security Toggle 'Off' Within Homepage
	Then Check Wifi reenable Toast Pop up	
	Then Click re-enable Toast
	Then The HomeWifiToggle is "On"
	Given Go to Wifisecurity
	Then Waiting 2 seconds
	Then The WiFi Security toggle status within subpage 'on'

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep28_check close vantage then click reenable now it do work well
	Given Clear Notification Center History
	Given Go to Wifisecurity
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Set the WiFi Security Toggle 'Off' Within Subpage
	Given Close Vantage
	Then Check Wifi reenable Toast Pop up	
	Then Click re-enable Toast	
	Given Launch Vantage
	Then The HomeWifiToggle is "On"

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep29_check 28 is met subpage toggle aslo on status
	Given Go to Wifisecurity
	Then Waiting 2 seconds
	Then The WiFi Security toggle status within subpage 'on'

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep30_check close vantage on homepage then click reenable now
	Given Clear Notification Center History
	When Set the WiFi Security Toggle 'On' Within Homepage
	When Set the WiFi Security Toggle 'Off' Within Homepage
	Given Close Vantage
	Then Check Wifi reenable Toast Pop up	
	Then Click re-enable Toast	
	Given Launch Vantage
	Then The HomeWifiToggle is "On"

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep31_check close vantage on homepage then click no thanks
	Given Clear Notification Center History
	When Set the WiFi Security Toggle 'On' Within Homepage
	When Set the WiFi Security Toggle 'Off' Within Homepage
	Given Close Vantage
	Then Check Wifi reenable Toast Pop up	
	Then Click no thanks Toast	
	Given Launch Vantage
	Then The HomeWifiToggle is "Off"

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep32_check close vantage on homepage and turn off location permission then click reenable now
	Given Turn on Location for Vantagee
	Given Clear Notification Center History
	When Set the WiFi Security Toggle 'On' Within Homepage
	Given Close Vantage
	Given Turn off Location Permission for Vantage
	Then Check Wifi reenable Toast Pop up	
	Then Click re-enable Toast	
	Then There is location dialog in LWS Page
	When Click location dialog close button in LWS Page
	Then Waiting 2 seconds
	Then The WiFi Security toggle status within subpage 'off'

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep33_check close vantage on homepage and turn off location service then click reenable now
	Given Turn on Location for Vantagee
	When Set the WiFi Security Toggle 'On' Within Homepage
	Given Close Vantage
	Given Clear Notification Center History
	Given Turn off Location Service in Settings Page
	Then Check Wifi reenable Toast Pop up	
	Then Click re-enable Toast	
	Then There is location dialog in LWS Page
	When Click location dialog close button in LWS Page
	Then Waiting 2 seconds
	Then The WiFi Security toggle status within subpage 'off'

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep34_check after S3 the LWS function is normal
	Given Turn on Location for Vantagee
	When The user connect or disconnect WiFi on lenovo
	When Enter sleep
	When Set the WiFi Security Toggle 'On' Within Homepage
	Given Go to Wifisecurity
	Then Waiting 2 seconds
	Then The WiFi Security toggle status within subpage 'on'
	When Set the WiFi Security Toggle 'Off' Within Subpage
	When Click gamingdevice in LWS Page
	Then The HomeWifiToggle is "Off"

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep35_check after S4 the LWS function is normal
	Given Turn on Location for Vantagee
	When The user connect or disconnect WiFi on lenovo
	When Enter hibernate
	Then Waiting 10 seconds
	When Set the WiFi Security Toggle 'Off' Within Homepage
	Given Go to Wifisecurity
	Then Waiting 2 seconds
	Then The WiFi Security toggle status within subpage 'off'
	When Set the WiFi Security Toggle 'On' Within Subpage
	When Click gamingdevice in LWS Page
	Then The HomeWifiToggle is "On"

@LWStoggleandtileinthehomepageforgamingtheme
Scenario: VAN9695_TestStep36_check install old plugin and the LWS function is normal
	Given Clear Notification Center History
	When  Stop the IMC service in the task manager
	Given Waiting 1 seconds
	Given Delete LWS "Plugin"
	Given Copy "68" Plugin to Install
	When Start the IMC service in the task manager
	Given Close Vantage
	Given Launch Lenovo Vantage
	When Set the WiFi Security Toggle 'On' Within Homepage
	When Set the WiFi Security Toggle 'Off' Within Homepage
	Then Check Wifi reenable Toast Pop up
	Then Click re-enable Toast
	Given Slide The Page To "-100"
	Given Go to Wifisecurity
	Then Waiting 2 seconds
	Then The WiFi Security toggle status within subpage 'on'

