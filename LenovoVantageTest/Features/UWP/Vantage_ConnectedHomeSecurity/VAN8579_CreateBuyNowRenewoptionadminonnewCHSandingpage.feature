Feature: VAN8579_CreateBuyNowRenewoptionadminonnewCHSandingpage
	Test Case：https://jira.tc.lenovo.com/browse/VAN-8579
	Author ：yangyu

@CreateBuyNowRenewoptionadminonnewCHSandingpage
Scenario: VAN8579_TestStep01_Check the Part of admin CHSAccount
	When The user connect or disconnect WiFi on lenovo
	Given Initialization Chs Data For "In Trial"
	Given Remove "trialsecond" Account from Web Console
	Given Remove Account from Web Console
	Given Remove "Subscription" Account from Web Console
	Given Install the Lenovo Vantage Without Launch Vantage
	Given Launch Lenovo Vantage
	Given User has Joined or Started a CHS "Trialadmin"Group
	Given Waiting 50 seconds
	Then Check The Part of "Account"

@CreateBuyNowRenewoptionadminonnewCHSandingpage
Scenario: VAN8579_TestStep02_Check the Part of admin CHSAccount
	When Check CHS Subpage
	Then Check The Part of "Account"
	Then Take Screen Shot 01UI in 8579 under CHScreenShotResult

@CreateBuyNowRenewoptionadminonnewCHSandingpage
Scenario: VAN8579_TestStep03_Check the trial purchase page 
	When Check CHS Subpage
	Then There is No "BuyNow" Button
	Then Take Screen Shot 02UI in 8579 under CHScreenShotResult

@CreateBuyNowRenewoptionadminonnewCHSandingpage
Scenario: VAN8579_TestStep04_Check the Part of outtrial CHSAccount
	Given Initialization Chs Data For "Out Trial"
    When Check CHS Subpage
	Then Check The Part of "OutTrial"	

@CreateBuyNowRenewoptionadminonnewCHSandingpage
Scenario: VAN8579_TestStep05_Check the Part of outtrial purchase
	Given Initialization Chs Data For "In Trial"
    When Check CHS Subpage
	Then There is No "OutTrialText" Button
	Then Take Screen Shot 03UI in 8579 under CHScreenShotResult
	Given Remove Account from Web Console

@CreateBuyNowRenewoptionadminonnewCHSandingpage
Scenario: VAN8579_TestStep07_Check the Part of Subscriptionadmin over30day CHSAccount
	Given Initialization Chs Data For "In Sub Over 30Days"
	Given User has Joined or Started a CHS "Subscriptionadmin"Group
	Then Check The Part of "Over30Days"
	Then Take Screen Shot 04UI in 8579 under CHScreenShotResult

@CreateBuyNowRenewoptionadminonnewCHSandingpage
Scenario: VAN8579_TestStep08_Check the Part of Subscriptionadmin purchase page
	When Check CHS Subpage 
	Then There is No "Over30DayText" Button
	Then Take Screen Shot 05UI in 8579 under CHScreenShotResult

@CreateBuyNowRenewoptionadminonnewCHSandingpage
Scenario: VAN8579_TestStep09_Check the Part of Subscriptionadmin less30day CHSAccount
	Given Initialization Chs Data For "In Sub Less 30Days"
	When Check CHS Subpage 
	Then Check The Part of "Less30Days"
	Then Take Screen Shot 06UI in 8579 under CHScreenShotResult

@CreateBuyNowRenewoptionadminonnewCHSandingpage
Scenario: VAN8579_TestStep10_Check the Part of Subscriptionadmin purchase page
	When Check CHS Subpage 
	Then There is No "Over30DayText" Button
	Then Take Screen Shot 07UI in 8579 under CHScreenShotResult

@CreateBuyNowRenewoptionadminonnewCHSandingpage
Scenario: VAN8579_TestStep13_Check the Offline Message
	When The user connect or disconnect WiFi off lenovo
	Given Close Vantage
	Given Launch Vantage
	When Check CHS Subpage 
	Then Will Pop up Offline Message
	When The user connect or disconnect WiFi on lenovo

@CreateBuyNowRenewoptionadminonnewCHSandingpage
Scenario: VAN8579_TestStep14_Check S3 for a while
	When The user connect or disconnect WiFi on lenovo
	Given Close Vantage
	When Enter sleep	
	When The user connect or disconnect WiFi on lenovo
	Given Launch Lenovo Vantage
	When Check CHS Subpage 	
	Then Check The Part of "Less30Days"

@CreateBuyNowRenewoptionadminonnewCHSandingpage
Scenario: VAN8579_TestStep15_Check S4 for a while
	When The user connect or disconnect WiFi on lenovo
	Given Close Vantage
	When Enter hibernate
	When The user connect or disconnect WiFi on lenovo
	Given Launch Lenovo Vantage
	When Check CHS Subpage 
	Then Check The Part of "Less30Days"
	Given Remove "Subscription" Account from Web Console


