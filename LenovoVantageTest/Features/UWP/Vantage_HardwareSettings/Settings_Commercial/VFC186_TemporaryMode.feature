Feature: VFC186_TemporaryMode
	Test Case： https://jira.tc.lenovo.com/browse/VFC-186
	Author：Haiye Li

@CheckLETemporaryMode
Scenario: VFC186_TestStep01_ThinkPad and Support Temproray Mode Check Display Question Mark
	Given Machine is ThinkPad and enable Temproray mode
	Given Go to My Device Settings page
	Given Into Battery Details page
	Then Battery Details Page Show Question Mark

@CheckLETemporaryMode
Scenario: VFC186_TestStep02_Question Mark Should Be Displayed Directly After Temporary Mode is Enabled
	Given Machine is ThinkPad and enable Temproray mode
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	Then Check Question Mark Message display using the name specified with json path '$.PowerPage.QuestionMarkMessage'

@CheckLETemporaryMode
Scenario: VFC186_TestStep03_Click question mark there should be a tip in question mark
	Given Machine is ThinkPad and enable Temproray mode
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	Then Check Question Mark Message display using the name specified with json path '$.PowerPage.QuestionMarkMessage'
	Then Take Screen Shot VFC186_TestStep3_CheckTextAndUI in 186 under SettingsScreenShotResult

@CheckLETemporaryMode
Scenario: VFC186_TestStep04_Click any area outside the tooltips should disappear
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	Then Check Question Mark Message display using the name specified with json path '$.PowerPage.QuestionMarkMessage'
	Then Take Screen Shot VFC186_TestStep4_01_CheckBeforeClick in 186 under SettingsScreenShotResult
	When Click on the top left of vantage
	Then Battery Details Page Not Show Tooltip
	Then Take Screen Shot VFC186_TestStep4_02_CheckAfterClick in 186 under SettingsScreenShotResult

@CheckLETemporaryMode
Scenario: VFC186_TestStep05_The Layout of This Page Should Follow UISPEC and Shouldn't Changed by The Question Mark
	Given Machine is ThinkPad and enable Temproray mode
	Given Go to My Device Settings page
	Given Into Battery Details page
	Then Take Screen Shot VFC186_TestStep05_01 in 186 under SettingsScreenShotResult
	When Click on the question mark
	Then Check Question Mark Message display using the name specified with json path '$.PowerPage.QuestionMarkMessage'
	Then Take Screen Shot VFC186_TestStep05_02 in 186 under SettingsScreenShotResult

@CheckLETemporaryMode
Scenario: VFC186_TestStep06_The Layout of This Page Should Follow UISPEC and Shouldn't Changed by The Question Mark
	Given Machine is ThinkPad and enable Temproray mode
	Given Go to My Device Settings page
	Given Into Battery Details page
	Given close lenovo vantage
	Given ReLaunch Lenovo Vantage
	Given Go to My Device Settings page
	Given Into Battery Details page
	Then  The question mark should still be displayed beside FCC
	When Click on the question mark
	
@CheckLETemporaryMode
Scenario: VFC186_TestStep07_Machine not support PI DLS mode and check the battery details panel UI appearance
	Given Change machine support temporary mode but it is disabled
	Given Go to My Device Settings page
	Given Into Battery Details page
	When There should not show question mark and the link
	Then Take Screen Shot VFC186_TestStep07_CheckUI in 186 under SettingsScreenShotResult
	Then Restore PI DLS mode Settings
	Then Delete Ini Settings File

@CheckLETemporaryMode
Scenario: VFC186_TestStep08_CheckTheUIAppearance
	Given Machine is ThinkPad and enable Temproray mode
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click Vantage Maxmize Button
	When Click on the question mark
	Then Take Screen Shot VFC186_TestStep8_CheckUI in 186 under SettingsScreenShotResult
	
@CheckLETemporaryMode
Scenario: VFC186_TestStep09_Change the DPI and Resolution and check the UI appearance of the web page context
	Given Machine is ThinkPad and enable Temproray mode
	Given Go to My Device Settings page
	Given Into Battery Details page
	Given change resolution 1024 to 768
	When  Click on the question mark
	Then Take Screen Shot VFC186_TestStep11_CheckUI in 186 under SettingsScreenShotResult
	Then Restore Display Settings
	Given change resolution 1366 to 768
	When Click on the top left of vantage
	Given Change DPI to 125
	When  Click on the question mark
	Then Take Screen Shot VFC186_TestStep11_CheckUI in 186 under SettingsScreenShotResult
	Given Change DPI to 100

@CheckLETemporaryMode
Scenario: VFC186_TestStep10_CheckQuestionMarkMessage
	Given Machine is ThinkPad and enable Temproray mode
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	Then Check Question Mark Message display using the name specified with json path '$.PowerPage.QuestionMarkMessage'

@CheckLETemporaryMode
Scenario: VFC186_TestStep11_Click "here" jump to high density battery
	Given Machine is ThinkPad and enable Temproray mode
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	When Click on the here for more information
	Then Check Question Mark Click Here Message display using the name specified with json path '$.PowerPage.QuestionMarkClickHereMessageLine1' '$.PowerPage.QuestionMarkClickHereMessageLine2' '$.PowerPage.QuestionMarkClickHereMessageLine3' '$.PowerPage.QuestionMarkClickHereMessageLine4'

@CheckLETemporaryMode
Scenario: VFC186_TestStep12_CheckQuestionMarkClickHereMessage
	When The user connect or disconnect WiFi off lenovo
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	When Click on the here for more information
	Then Check Question Mark Click Here Message display using the name specified with json path '$.PowerPage.QuestionMarkClickHereMessageLine1' '$.PowerPage.QuestionMarkClickHereMessageLine2' '$.PowerPage.QuestionMarkClickHereMessageLine3' '$.PowerPage.QuestionMarkClickHereMessageLine4'
	When The user connect or disconnect WiFi on lenovo

@CheckLETemporaryMode
Scenario: VFC186_TestStep13_CheckTheUIAppearance
	Given Machine is ThinkPad and enable Temproray mode
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	When Click on the here for more information
	When Click Vantage Maxmize Button
	Then Take Screen Shot VFC186_TestStep13_CheckUI in 186 under SettingsScreenShotResult
	
@CheckLETemporaryMode
Scenario: VFC186_TestStep14_Change the DPI and Resolution and check the UI appearance of the web page context
	Given Machine is ThinkPad and enable Temproray mode
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	When Click on the here for more information
	Given Change DPI to 200
	Then Take Screen Shot VFC186_TestStep14_01CheckUI in 186 under SettingsScreenShotResult
	Given change resolution 1024 to 768
	Then Take Screen Shot VFC186_TestStep14_02CheckUI in 186 under SettingsScreenShotResult
	Given Change DPI to 100
	Given change resolution 1633 to 768
	Then Restore Display Settings
	
@CheckLETemporaryMode
Scenario: VFC186_TestStep15_Machine is in AC condition Check the UI appearance of the tooltips
	Given change ThinkPad machine to AC condition
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	Then Waiting 3 seconds
	Then Take Screen Shot VFC186_TestStep15_CheckUI in 186 under SettingsScreenShotResult
	
@CheckLETemporaryMode
Scenario: VFC186_TestStep16_Machine is in DC condition Check the UI appearance of the tooltips
	Given change ThinkPad machine to DC condition
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	Then Waiting 3 seconds
	Then Take Screen Shot VFC186_TestStep16_CheckUI in 186 under SettingsScreenShotResult
	Given change ThinkPad machine to AC condition

@CheckLETemporaryMode
Scenario: VFC186_TestStep17_Machine is in AC condition Check the UI appearance of the web page
	Given change ThinkPad machine to AC condition
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	When Click on the here for more information
	Then Waiting 3 seconds
	Then Take Screen Shot VFC186_TestStep17_CheckUI in 186 under SettingsScreenShotResult
	
@CheckLETemporaryMode
Scenario: VFC186_TestStep18_Machine is in DC condition Check the UI appearance of the web page
	Given change ThinkPad machine to DC condition
	Given Go to My Device Settings page
	Given Into Battery Details page
	When Click on the question mark
	When Click on the here for more information
	Then Waiting 3 seconds
	Then Take Screen Shot VFC186_TestStep18_CheckUI in 186 under SettingsScreenShotResult
	Given change ThinkPad machine to AC condition

@CheckLETemporaryModeNosupport
Scenario: VFC186_TestStep19_Machine not support PI DLS mode and check the battery details panel UI appearance
	Given Go to My Device Settings page
	Given Into Battery Details page
	When There should not show question mark and the link
	Then Take Screen Shot VFC186_TestStep19_CheckUI in 186 under SettingsScreenShotResult
	Then Restore PI DLS mode Settings
	Then Delete Ini Settings File