Feature: VAN15459_VFC186_Vantage_Settings_TemproraryMode_ThinkPad
	Test Case： https://jira.tc.lenovo.com/browse/VAN-15459
	Author：Jinxin Li

@CheckQuestionMarkMessage
Scenario: VAN15459_TestStep1_ThinkPad and Support Temproray Mode Check Display Question Mark
	Given Machine is ThinkPad and enable Temproray mode
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	Then Check Question Mark Message display using the name specified with json path '$.PowerPage.QuestionMarkMessage'

@CheckQuestionMarkMessage
Scenario: VAN15459_TestStep2_Question Mark Should Be Displayed Directly After Temporary Mode is Enabled
	Given Machine is ThinkPad and enable Temproray mode
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	Then Check Question Mark Message display using the name specified with json path '$.PowerPage.QuestionMarkMessage'

@CheckQuestionMarkMessage
Scenario: VAN15459_TestStep3_Click question mark there should be a tip in question mark
	Given Machine is ThinkPad and enable Temproray mode
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	Then Check Question Mark Message display using the name specified with json path '$.PowerPage.QuestionMarkMessage'
	Then Take Screen Shot VAN15459_TestStep3_CheckTextAndUI in 15459 under SettingsScreenShotResult

@CheckQuestionMarkMessage
Scenario: VAN15459_TestStep4_Click question mark the tip should follow the latest UISPEC
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	Then Check Question Mark Message display using the name specified with json path '$.PowerPage.QuestionMarkMessage'
	Then Take Screen Shot VAN15459_TestStep4_CheckTextAndUI in 15459 under SettingsScreenShotResult

@CheckQuestionMarkMessage
Scenario: VAN15459_TestStep5_Click any area outside the tooltips should disappear
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	Then Check Question Mark Message display using the name specified with json path '$.PowerPage.QuestionMarkMessage'
	Then Take Screen Shot VAN15459_TestStep5_CheckBeforeClick in 15459 under SettingsScreenShotResult
	When Click on the top left of vantage
	Then Take Screen Shot VAN15459_TestStep5_CheckAfterClick in 15459 under SettingsScreenShotResult

@CheckQuestionMarkMessage
Scenario: VAN15459_TestStep8_The Value Should Keep The Same With BatView
	Given Machine is ThinkPad and enable Temproray mode
	Given Go to My Device Settings page
	Given Into Battery Details page
	Then Take Screen Shot VAN15459_TestStep8_01 in 15459 under SettingsScreenShotResult
	Then Turn on BatView
	Then Take Screen Shot VAN15459_TestStep8_02 in 15459 under SettingsScreenShotResult
	Then BatView will be Launched

@CheckQuestionMarkMessage
Scenario: VAN15459_TestStep9_All Item In Battery Details Should Can Be Refresh To Correctly Value Every 30 Seconds
	Given Machine is ThinkPad and enable Temproray mode
	Given Go to My Device Settings page
	Given Into Battery Details page
	Then Take Screen Shot VAN15459_TestStep9_01 in 15459 under SettingsScreenShotResult
	When wait 30 seconds
	Then Take Screen Shot VAN15459_TestStep9_02 in 15459 under SettingsScreenShotResult

@CheckQuestionMarkMessage
Scenario: VAN15459_TestStep10_The Layout of This Page Should Follow UISPEC and Shouldn't Changed by The Question Mark
	Given Machine is ThinkPad and enable Temproray mode
	Given Go to My Device Settings page
	Given Into Battery Details page
	Then Take Screen Shot VAN15459_TestStep10_01 in 15459 under SettingsScreenShotResult
	When Click on the question mark
	Then Check Question Mark Message display using the name specified with json path '$.PowerPage.QuestionMarkMessage'
	Then Take Screen Shot VAN15459_TestStep10_02 in 15459 under SettingsScreenShotResult

@CheckQuestionMarkMessage
Scenario: VAN15459_TestStep18_CheckQuestionMarkMessage
	Given Machine is ThinkPad and enable Temproray mode
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	Then Check Question Mark Message display using the name specified with json path '$.PowerPage.QuestionMarkMessage'

@CheckQuestionMarkMessage
Scenario: VAN15459_TestStep19_Click "here" jump to high density battery
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	When Click on the here for more information
	Then Check Question Mark Click Here Message display using the name specified with json path '$.PowerPage.QuestionMarkClickHereMessageLine1' '$.PowerPage.QuestionMarkClickHereMessageLine2' '$.PowerPage.QuestionMarkClickHereMessageLine3' '$.PowerPage.QuestionMarkClickHereMessageLine4'

@CheckQuestionMarkMessage
Scenario: VAN15459_TestStep20_CheckQuestionMarkClickHereMessage
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	When Click on the here for more information
	Then Check Question Mark Click Here Message display using the name specified with json path '$.PowerPage.QuestionMarkClickHereMessageLine1' '$.PowerPage.QuestionMarkClickHereMessageLine2' '$.PowerPage.QuestionMarkClickHereMessageLine3' '$.PowerPage.QuestionMarkClickHereMessageLine4'

@CheckQuestionMarkMessage
Scenario: VAN15459_TestStep21_CheckTheUIAppearance
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	When Click on the here for more information
	When Click Vantage Maxmize Button
	Then Take Screen Shot VAN15459_TestStep21_CheckUI in 15459 under SettingsScreenShotResult
	
@CheckQuestionMarkMessage
Scenario: VAN15459_TestStep22_Change the DPI and Resolution and check the UI appearance of the web page context
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	When Click on the here for more information
	#Given Change DPI to 200
	Given change resolution 1024 to 768
	Then Take Screen Shot VAN15459_TestStep22_CheckUI in 15459 under SettingsScreenShotResult
	Then Restore Display Settings
	
@CheckQuestionMarkMessage
Scenario: VAN15459_TestStep23_Machine is in AC condition Check the UI appearance of the tooltips
	Given change ThinkPad machine to AC condition
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	Then Take Screen Shot VAN15459_TestStep23_CheckUI in 15459 under SettingsScreenShotResult
	
@CheckQuestionMarkMessage
Scenario: VAN15459_TestStep24_Machine is in DC condition Check the UI appearance of the tooltips
	Given change ThinkPad machine to DC condition
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	Then Take Screen Shot VAN15459_TestStep24_CheckUI in 15459 under SettingsScreenShotResult
	Given change ThinkPad machine to AC condition

@CheckQuestionMarkMessage
Scenario: VAN15459_TestStep25_Machine is in AC condition Check the UI appearance of the web page
	Given change ThinkPad machine to AC condition
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	When Click on the here for more information
	Then Take Screen Shot VAN15459_TestStep25_CheckUI in 15459 under SettingsScreenShotResult
	
@CheckQuestionMarkMessage
Scenario: VAN15459_TestStep26_Machine is in DC condition Check the UI appearance of the web page
	Given change ThinkPad machine to DC condition
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	When Click on the here for more information
	Then Take Screen Shot VAN15459_TestStep26_CheckUI in 15459 under SettingsScreenShotResult
	Given change ThinkPad machine to AC condition

@CheckQuestionMarkMessage
Scenario: VAN15459_TestStep27_Machine not support PI DLS mode and check the battery details panel UI appearance
	Given Change machine support temporary mode but it is disabled
	Given Go to My Device Settings page
	Given Into Battery Details page
	When There should not show question mark and the link
	Then Take Screen Shot VAN15459_TestStep27_CheckUI in 15459 under SettingsScreenShotResult
	Then Restore PI DLS mode Settings
	Then Delete Ini Settings File