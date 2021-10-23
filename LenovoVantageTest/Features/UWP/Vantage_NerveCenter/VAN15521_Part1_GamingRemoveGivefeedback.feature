Feature: VAN15521_Part1_GamingRemoveGivefeedback
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-15521
	Author： Wei Xu

Background:
	Given Machine is Gaming 

@GamingRemoveGiveFeedback
Scenario: VAN15521_TestStep01_Give Feedback Container Is Not Shown In The Homepage
	Then Give Feedback Container is not shown

@GamingRemoveGiveFeedback
Scenario: VAN15521_TestStep02_Give Feedback Container Is Shown In The Support Page
	When Click the Support in the navigation bar
	Then Give Feedback Container is shown

@GamingRemoveGiveFeedback
Scenario: VAN15521_TestStep03_Give Feedback Container Link Is Shown In The LID Dtropdown Menu
	When Click the Lenovo ID Icon in the navigation bar
	Then Give Feedback link is shown

@GamingRemoveGiveFeedback
Scenario: VAN15521_TestStep05_Give Feedback Container is Gaming style
	When Click the Support in the navigation bar
	Then Take Screen Shot TestStep05 in 15521 under GamingScreenShotResult

@GamingRemoveGiveFeedback
Scenario: VAN15521_TestStep06_Give Feedback Container Is Not Shown In The Homepage_Minimize
	When Click the Minimize
	Then Give Feedback Container is not shown

@GamingRemoveGiveFeedback
Scenario: VAN15521_TestStep07_Give Feedback Container Is Not Shown In The Homepage_Switch Page
	When Click the Auto Close Gear Icon
	When Click the Device link in the navigation bar
	Then Give Feedback Container is not shown

@GamingRemoveGiveFeedback
Scenario: VAN15521_TestStep08_Give Feedback Container Is Not Shown In The Homepage_Reopen Vantage
	When Close Vantage
	When ReLaunch Vantage
	Then Give Feedback Container is not shown

@GamingRemoveGiveFeedbackS3
Scenario: VAN15521_TestStep10_Give Feedback Container Is Not Shown In The Homepage_S3
	When Enter sleep
	Then Give Feedback Container is not shown

@GamingRemoveGiveFeedbackS4
Scenario: VAN15521_TestStep11_Give Feedback Container Is Not Shown In The Homepage_S4
	When Enter hibernate
	Then Give Feedback Container is not shown


