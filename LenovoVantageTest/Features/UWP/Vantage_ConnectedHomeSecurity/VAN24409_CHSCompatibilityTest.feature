Feature: VAN24409_CHSCompatibilityTest
	Test Case：https://jira.tc.lenovo.com/browse/VAN-24409
	Author ：yangyu

@CHSCompatibilityTest
Scenario: VAN24409_TestStep05_Check OOBE Done Then show CHS marketing page
	Given Install Vantage
	Given Turn on Location for Vantagee
	When Check CHS Subpage
	When Click CHS "Done" Button
	Then It Will Directly Go to CHS Marketing Page
	Then Take Screen Shot 05UI in 24409 under CHScreenShotResult

@CHSCompatibilityTest
Scenario: VAN24409_TestStep06_Check OOBE page will pop up
	Given Install Vantage
	Given Waiting 1 seconds
	Given Turn off Location Permission for Vantage
	Given Launch Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1
	Then Take Screen Shot 06UI in 24409 under CHScreenShotResult
		
@CHSCompatibilityTest
Scenario: VAN24409_TestStep07_Check OOBE Next will be finished and show CHS marketing page
	Given Install Vantage
	Given Turn off Location Permission for Vantage
	When Check CHS Subpage
	Then The Tutorial Will Pop up And Show Slide1
	When Click CHS "Next" Button
	When Click CHS "Allow" Button
	Given Set Vantage Location "On" In Setting
	Then It Will Directly Go to CHS Marketing Page

@CHSCompatibilityTest
Scenario: VAN24409_TestStep08_Check start trial location dialog pop up
	Given Turn off Location Permission for Vantage
	When Check CHS Subpage
	Then Start trial Then "NotNow" Button Is Clickable

@CHSCompatibilityTest
Scenario: VAN24409_TestStep09_Check start trial prompt pop up
	When Check CHS Subpage
	When Click Start Trial
	When Click CHS "Allow" Button
	Given Set Vantage Location "On" In Setting
	When Click Start Trial
	Then Check Start Trial Prompt Box
	Then Take Screen Shot 09UI in 24409 under CHScreenShotResult

@CHSCompatibilityTest
Scenario: VAN24409_TestStep10_Check CHS web page display
	When Check CHS Subpage
	Then Kill chrome.exe Process
	When Click Start Trial
	Then Check Start Trial Prompt Box
	Given Waiting 15 seconds
	Then CHS Webpage Open In Chrome
	Then Take Screen Shot 10UI in 24409 under CHScreenShotResult

@CHSCompatibilityTest
Scenario: VAN24409_TestStep11_Check join then location dialog pop up
	When Check CHS Subpage
	Given Turn off Location Permission for Vantage
	When Click CHS "Join" Button
	Then The Tutorial Will Pop up And Show Slide2
	Then Take Screen Shot 11UI in 24409 under CHScreenShotResult

@CHSCompatibilityTest
Scenario: VAN24409_TestStep12_Check input code prompt pop up
	When Check CHS Subpage
	Given Turn off Location Permission for Vantage
	When Click CHS "Join" Button
	When Click CHS "Allow" Button
	Given Set Vantage Location "On" In Setting
	When Click CHS "Join" Button
	Then Check The Part of "InputCode"
	Then Take Screen Shot 12UI in 24409 under CHScreenShotResult

@CHSCompatibilityTest
Scenario: VAN24409_TestStep13_Check error input code
    When Check CHS Subpage
	When Click CHS "Join" Button
	Then Check The Part of "ErrorInputCode"
	Given Waiting 15 seconds
	Then Check The Part of "InputCode"
	Then Take Screen Shot 13UI in 24409 under CHScreenShotResult

@CHSCompatibilityTest
Scenario: VAN24409_TestStep14_Check admin/secondary page
	Given User has Joined or Started a CHS "Trialadmin"Group
	Then Check The Part of "Successfully login message"
	Then User Can See Admin/Secondary Console Normally
	Then Take Screen Shot 14UI in 24409 under CHScreenShotResult
	Given Remove Account from Web Console

@CHSCompatibilityTest
Scenario: VAN24409_TestStep15_Check check enable location by SH enable
	Given Remove Account from Web Console
	Given Turn off Location Permission for Vantage
	Given Click "Enable" and Turn on Location Service&Vantage Location Permission
	Then It Will Directly Go to CHS Marketing Page

@CHSCompatibilityTest
Scenario: VAN24409_TestStep16_Check click SH enable without action marketing page display normally 
	Given Turn off Location Permission for Vantage
	When Check CHS Subpage
	When Click CHS "SHEnable" Button
	Given Close Settings Page Without Action
	Then Setting Page Will Be Closed Return to CHS Marketing Page

@CHSCompatibilityTest
Scenario:VAN24409_TestStep17_In start trial and check UI
	Given User has Joined or Started a CHS "trialadmin"Group
	When Check CHS Subpage
	Then There is No "BuyNow" Button
	Then Take Screen Shot 17UI in 24409 under CHScreenShotResult

@CHSCompatibilityTest
Scenario:VAN24409_TestStep18_In start trial and click go to dashboard
	When Check CHS Subpage
	When Click CHS "go to dashboard" Button
	Then Waiting 15 seconds
	Then Take Screen Shot 18UI in 24409 under CHScreenShotResult

@CHSCompatibilityTest
Scenario:VAN24409_TestStep19_In start trial and change number
	When  Check CHS Subpage
	Given Add "Trial" Family Number
	Given "Add" "Trial" Places Number
	Given "Add" "Trial" NetWork Number
	Given "Add" "Trial" Home Devices
	Then Waiting 15 seconds
	Then Check CHS Group Offline has 2-2-1-1 number
	Given Remove "third" Faimily Number From "Trial1"Account	
	Given "Remove" "Trial" Places Number
	Given "Remove" "Trial" NetWork Number

@CHSCompatibilityTest
Scenario:VAN24409_TestStep20_Trial expired
	Given connected to CHS account and trial expired
	When  Check CHS Subpage
	When Click CHS "go to dashboard" Button
	Then Waiting 15 seconds
	Then Take Screen Shot 2001UI in 24409 under CHScreenShotResult
	When  Check CHS Subpage
	When Click CHS "disconnect" Button
	When Click CHS "disconnectpromptbtn" Button
	Then Check the part of Start Trial
	Then Take Screen Shot 2002UI in 24409 under CHScreenShotResult
	Given Initialization Chs Data For "In Trial"

@CHSCompatibilityTest
Scenario:VAN24409_TestStep21_In subscription and check UI
	Given User has Joined or Started a CHS "Subscriptionadmin"Group
	Then Waiting 10 seconds
	When Check CHS Subpage
	Then Take Screen Shot 21UI in 24409 under CHScreenShotResult

@CHSCompatibilityTest
Scenario:VAN24409_TestStep22_In subscription and click go to dashboard
	When Check CHS Subpage
	When Click CHS "go to dashboard" Button
	Then Waiting 15 seconds
	Then Take Screen Shot 22UI in 24409 under CHScreenShotResult

@CHSCompatibilityTest
Scenario:VAN24409_TestStep23_In subscription and change number
	Given Change CHS Component From Web Consle Subscription Account AddFamilyNumber
	Given Change CHS Component From Web Consle Subscription Account AddPlacesNumber
	Given Change CHS Component From Web Consle Subscription Account AddWifiNetworkNumber
	Given Change CHS Component From Web Consle Subscription Account AddHomeDeviceNumber
	When Check CHS Subpage
	Then Waiting 10 seconds
	Then Check CHS Group Offline has 2-2-1-3 number
	Given Change CHS Component From Web Consle Subscription Account RemoveFamilyNumber
	Given Change CHS Component From Web Consle Subscription Account RemoveWifiNetworkNumber
	Given Change CHS Component From Web Consle Subscription Account RemovePlacesNumber
	Given Change CHS Component From Web Consle Subscription Account RemoveSubscribtionAccount

@CHSCompatibilityTest
Scenario:VAN24409_TestStep24_join in as secondary user
	Given Change CHS Component From Web Consle Subscription Account RemoveSubscribtionAccount
	Then Waiting 10 seconds
	Given User has Joined or Started a CHS "trialsecond"Group
	Then Check The Part of "Successfully login message"
	Then Take Screen Shot 24UI in 24409 under CHScreenShotResult

@CHSCompatibilityTest
Scenario:VAN24409_TestStep25_secondary user check and change number
	When Check CHS Subpage
	Given Add "Trial2" Family Number
	Given "Add" "Trial2" Places Number
	Given "Add" "Trial2" NetWork Number
	Given "Add" "Trial2" Home Devices
	Then Waiting 15 seconds
	Then Check CHS Group Offline has 3-2-1-1 number

@CHSCompatibilityTest
Scenario:VAN24409_TestStep26_secondary user disconnect user
	When  Check CHS Subpage
	When Click CHS "disconnect" Button
	When Click CHS "disconnectpromptbtn" Button
	Then Check the part of Start Trial
	Then Take Screen Shot 2601UI in 24409 under CHScreenShotResult
	Given Remove "Third" Faimily Number From "Trial2"Account	
	Given "Remove" "Trial2" Places Number
	Given "Remove" "Trial2" NetWork Number

@CHSCompatibilityTest
Scenario: VAN24409_TestStep27_Check disable location banner show up
	Given Remove "trialsecond" Account from Web Console
	Given User has Joined or Started a CHS "Trialadmin"Group
	Given Turn off Location Permission for Vantage
	When Check CHS Subpage
	Then Disable Location Banner Show up and User Can't See Admin/Secondary Console
	Then Take Screen Shot 27UI in 24409 under CHScreenShotResult

@CHSCompatibilityTest
Scenario: VAN24409_TestStep28_Check relaunch vantage disable location banner show up
	Given Turn off Location Permission for Vantage
	Given ReLaunch Vantage
	When Check CHS Subpage
	Then Disable Location Banner Show up and User Can't See Admin/Secondary Console

@CHSCompatibilityTest
Scenario: VAN24409_TestStep29_Check relaunch vantage disable location banner show up
	Given Disable Location Banner Show up
	Given Turn on Location for Vantagee
	When Check CHS Subpage
	Then User Can See Admin/Secondary Console Normally

@CHSCompatibilityTest
Scenario: VAN24409_TestStep30_Check relaunch vantage disable location banner show up
	Given Disable Location Banner Show up
	Given Click "Enable" and Turn on Location Service&Vantage Location Permission
	When Check CHS Subpage
	Then User Can See Admin/Secondary Console Normally

@CHSCompatibilityTest
Scenario: VAN24409_TestStep31_Check click go to setting not enable location
	Given Disable Location Banner Show up
	Given Click Button Go to Location Settings
	Given Close Settings Page Without Action
	When Check CHS Subpage
	Then Disable Location Banner Show up and User Can't See Admin/Secondary Console
	
@CHSCompatibilityTest
Scenario: VAN24409_TestStep32_Check click go to setting turn on location
	Given Disable Location Banner Show up
	Given Click "go to location settings" and Turn on Location Service&Vantage Location Permission
	When Check CHS Subpage
	Then User Can See Admin/Secondary Console Normally
	Given Remove Account from Web Console

@CHSCompatibilityTest
Scenario: VAN24409_TestStep33_Check LWS subpage
	Given Remove Account from Web Console
	Given Go to Wifisecurity
	Then Take Screen Shot 33UI in 24409 under CHScreenShotResult

@CHSCompatibilityTest
Scenario: VAN24409_TestStep34_click visit button
	Given Open LWS Subpage and Click "Visit"
	When wait 5 seconds
	Then Check the part of Start Trial
	Then Take Screen Shot 34UI in 24409 under CHScreenShotResult
	
@CHSCompatibilityTest
Scenario: VAN24409_TestStep35_offline and check CHS 
	When Check CHS Subpage
	When The user connect or disconnect WiFi off lenovo
	Then Waiting 5 seconds
	Then Will Pop up Offline Message
	When Click Offline Dialog Close Button
	When The user connect or disconnect WiFi on lenovo

@CHSCompatibilityTest
Scenario: VAN24409_TestStep36_offline and click start trial
	When The user connect or disconnect WiFi on lenovo
	When Check CHS Subpage
	When The user connect or disconnect WiFi off lenovo
	Then Waiting 5 seconds
	Then Will Pop up Offline Message
	When Click Offline Dialog Close Button
	When Click Start Trial
	Then Will Pop up Offline Message
	When Click Offline Dialog Close Button
	When Click CHS "join" Button
	Then Will Pop up Offline Message
	When Click Offline Dialog Close Button
	When The user connect or disconnect WiFi on lenovo

@CHSCompatibilityTest
Scenario: VAN24409_TestStep37_secondary user and offline
	When The user connect or disconnect WiFi on lenovo
	When Check CHS Subpage
	Given User has Joined or Started a CHS "trialsecond"Group
	Then Check The Part of "Successfully login message"
	When The user connect or disconnect WiFi off lenovo
	Then Waiting 5 seconds
	Then Will Pop up Offline Message
	When Click Offline Dialog Close Button
	
@CHSCompatibilityTest
Scenario: VAN24409_TestStep38_secondary user and offline disconnect 
	When The user connect or disconnect WiFi off lenovo
	When Check CHS Subpage
	Then Will Pop up Offline Message
	When Click Offline Dialog Close Button
	When Click CHS "disconnect" Button
	Then Will Pop up Offline Message
	When Click Offline Dialog Close Button
	When The user connect or disconnect WiFi on lenovo
	When Check CHS Subpage
	When Click CHS "disconnect" Button
	When Click CHS "DisconnectPromptBtn" Button
	Then It Will Directly Go to CHS Marketing Page

@CHSCompatibilityTest
Scenario: VAN24409_TestStep39_admin user and offline 
	When The user connect or disconnect WiFi on lenovo
	Given User has Joined or Started a CHS "Subscriptionadmin"Group
	Then Waiting 10 seconds
	When The user connect or disconnect WiFi off lenovo
	Then Will Pop up Offline Message
	When Click Offline Dialog Close Button
	When The user connect or disconnect WiFi on lenovo
	Given Change CHS Component From Web Consle Subscription Account RemoveSubscribtionAccount	

@CHSCompatibilityTest
Scenario: VAN24409_TestStep40_change other region
	When The user connect or disconnect WiFi on lenovo
	Given Set Windows Region "45"
	Given Close Vantage
	Given Launch Vantage
	When Click CHS "Security" Button
	Then There Will be "no" CHS Tab
	Given Set Windows Region "244"

@CHSCompatibilityTest
Scenario: VAN24409_TestStep41_change other language
	Given Set Windows First Language "zh-CN"
	Given Close Vantage
	Given Launch Vantage
	When Click CHS "Security" Button
	Then There Will be "no" CHS Tab
	Given Set Windows First Language "en-US"