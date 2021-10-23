Feature: VAN15521_Part2_GamingRemoveGivefeedback
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-15521
	Author： Wei Xu

Background:
	Given Machine is Gaming 

@GamingRemoveGiveFeedback
Scenario: VAN15521_TestStep15_Give Feedback Container Is Shown In Support Page_Minimize
	When Click the Minimize
	When Click the Support in the navigation bar
	Then Give Feedback Container is shown

@GamingRemoveGiveFeedback
Scenario: VAN15521_TestStep16_Give Feedback Container Is Shown In Support Page_Switch Page
	When Click the Auto Close Gear Icon
	When Click the Device link in the navigation bar
	When Click the Support in the navigation bar
	Then Give Feedback Container is shown

@GamingRemoveGiveFeedback
Scenario: VAN15521_TestStep17_Give Feedback Container Is Shown In Support Page_Reopen Vantage
	When Close Vantage
	When ReLaunch Vantage
	When Click the Support in the navigation bar
	Then Give Feedback Container is shown

@GamingRemoveGiveFeedbackS3
Scenario: VAN15521_TestStep19_Give Feedback Container Is Shown In Support Page_S3
	When Enter sleep
	When Click the Support in the navigation bar
	Then Give Feedback Container is shown

@GamingRemoveGiveFeedbackS4
Scenario: VAN15521_TestStep20_Give Feedback Container Is Shown In Support Page_S4
	When Enter hibernate
	When Click the Support in the navigation bar
	Then Give Feedback Container is shown