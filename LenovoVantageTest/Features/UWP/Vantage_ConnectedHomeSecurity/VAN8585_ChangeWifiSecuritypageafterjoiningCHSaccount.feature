Feature: VAN8585_ChangeWifiSecuritypageafterjoiningCHSaccount
	Change Wifi Security page after joining CHS account
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-8585
	Author ：Xiaoxiong Li

@ConnectedHomeSecurity
Scenario: VAN8585_TestStep01_Check the LWS subpage status
	When The user connect or disconnect WiFi on lenovo
	Given Remove Account from Web Console
	Given Remove "Subscription" Account from Web Console
	Given Install Vantage
	Given Go to Wifisecurity
	Then Take Screen Shot VAN8585_TestStep01 in 8585 under CHSScreenShotResult

@ConnectedHomeSecurity
Scenario: VAN8585_TestStep02_check the detail of the part of the CHS
	Given go to wifisecurity
	Then check the detail of the part of the CHS
	Given Slide The Page To "-300"
	Then Take Screen Shot VAN8585_TestStep02 in 8585 under CHSScreenShotResult

@ConnectedHomeSecurity
Scenario: VAN8585_TestStep03_check click visit go to CHSpage
	Given go to wifisecurity
	When click the button Visit
	Given Location for Vantage has been Enabled
	Given OOBE CHS
	Then It Will Directly Go to CHS Marketing Page

@ConnectedHomeSecurity
Scenario: VAN8585_TestStep04_start tirval check  the detail of the part of the CHS
	Given User has Joined or Started a CHS "Trialadmin"Group
	Then red badge will change to green badge protect

@ConnectedHomeSecurity
Scenario: VAN8585_TestStep05_CHS account and trial expired check red badge 
	Given Initialization Chs Data For "Out Trial"
	Then it will show as red badge
	Given Initialization Chs Data For "In Trial"
	Given Remove Account from Web Console

@ConnectedHomeSecurity
Scenario: VAN8585_TestStep06_CHS account and in subscription check green badge 
	Given User has Joined or Started a CHS "Subscriptionadmin"Group
	Given go to wifisecurity
	Then red badge will change to green badge protect
	Given Remove "Subscription" Account from Web Console

@ConnectedHomeSecurity
Scenario: VAN8585_TestStep08_Check the whole CHS feature will be hidden
	Given Set Windows Region "45"
	Given Close Vantage
	Given Launch Vantage
	Given go to wifisecurity
	Then Check LWS "Not US" Status
	Given Set Windows Region "244"
	Then Take Screen Shot VAN8585_TestStep08 in 8585 under CHSScreenShotResult

@ConnectedHomeSecurity
Scenario: VAN8585_TestStep09_Check the whole CHS feature will be hidden
	Given Set Windows First Language "zh-CN"
	Given Close Vantage
	Given Launch Vantage
	Given go to wifisecurity
	Then Check LWS "Not US" Status
	Given Set Windows First Language "en-US"
	Then Take Screen Shot VAN8585_TestStep09 in 8585 under CHSScreenShotResult

@ConnectedHomeSecurity
Scenario: VAN8585_TestStep10_Check the whole CHS feature will be hidden
	Then Kill chrome.exe Process
	Then Kill chromedriver.exe Process
	Given Set Windows Region "45"
	Given Set Windows First Language "zh-CN"
	Given Close Vantage
	Given Launch Vantage
	Given go to wifisecurity
	Then Check LWS "Not US" Status
	Given Set Windows Region "244"
	Given Set Windows First Language "en-US"
	Then Take Screen Shot VAN8585_TestStep10 in 8585 under CHSScreenShotResult
