Feature: VAN17970_FlipToBootQuickRegressionTest
	Test Case： https://jira.tc.lenovo.com/browse/VAN-17970
	Author：Jinxin Li

@CheckFlipToStartNotDisplayOnThinkpad
Scenario: VAN17970_TestStep01_Check Unsupported Machine Display Elements
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Then Check Power Settings 'Not Display Flip To Start Elements'

@CheckFlipToStart @SmokeCheckFlipToStart
Scenario: VAN17970_TestStep02_Check Supported Machine Display Elements
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Then Check Power Settings 'Display Flip To Start Elements'

@CheckFlipToStart @SmokeCheckFlipToStart
Scenario: VAN17970_TestStep03_Check Flip To Start Section Title Name Is 'Flip to start'
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Then Check Power Settings Section Display '$.PowerPage.FlipToStartTitleText'

@CheckFlipToStart @SmokeCheckFlipToStart
Scenario: VAN17970_TestStep04_Check Flip To Start Section Display Toggle And a Question Mark
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Then Flip To Start Section Display 'Toggle Button'
	Then Flip To Start Section Display 'Question Mark'

@CheckFlipToStart @SmokeCheckFlipToStart
Scenario: VAN17970_TestStep05_Check Flip To Start Section Display Description
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Then Check Power Settings Section Display '$.PowerPage.FlipToStartDescriptionText'

@CheckFlipToStart @SmokeCheckFlipToStart
Scenario: VAN17970_TestStep06_Check Flip To Start QuestionMark ToolTip Text
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Given Click Flip To Start QuestionMark
	Then Check Power Settings Section Display '$.PowerPage.FlipToStartQuestionMarkToolTipText'

@CheckFlipToStart
Scenario: VAN17970_TestStep07_Check Flip To Start Toggle Status Will Change
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Given Turn On Flip To Start Toggle
	Then The Flip To Start Toggle State Is 'On'

@CheckFlipToStart
Scenario: VAN17970_TestStep08_Check Maxmize Button UI And Toggle Status Change
	Given Go to My Device Settings page
	Given Click Power Settings Link
	When Click Vantage Maxmize Button
	Then Check Power Settings 'Display Flip To Start Elements'
	Then The Flip To Start Toggle State Is 'On'

@CheckFlipToStartS3S4
Scenario: VAN17970_TestStep09_Check Back From Hibernate The Flip To Start Toggle State Is Not Change
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Given Turn On Flip To Start Toggle
	When Get Flip To Start Toggle State
	When Enter hibernate
	Then Back From Hibernate Or Sleep The Flip To Start Toggle State Is 'On'

@CheckFlipToStartS3S4
Scenario: VAN17970_TestStep10_Check Back From Sleep The Flip To Start Toggle State Is Not Change
	Given Go to My Device Settings page
	Given Click Power Settings Link
	When Get Flip To Start Toggle State
	When Enter sleep
	Then Back From Hibernate Or Sleep The Flip To Start Toggle State Is 'On'

@CheckFlipToStart
Scenario: VAN17970_TestStep12_Check The Flip To Start Toggle State Is On
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Given Turn On Flip To Start Toggle
	Then The Flip To Start Toggle State Is 'On'

@CheckFlipToStart
Scenario: VAN17970_TestStep13_Check The Flip To Start Toggle State Is Off
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Given Turn Off Flip To Start Toggle
	Then The Flip To Start Toggle State Is 'Off'

@CheckFlipToStart
Scenario: VAN17970_TestStep19_Check Uninstall Vantage and Re-install Toggle Status Is Still 'On' 
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Given Turn On Flip To Start Toggle
	Then The Flip To Start Toggle State Is 'On'
	Given Uninstall the lenovo vatage
	Given Install Vantage
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Then The Flip To Start Toggle State Is 'On'

@CheckFlipToStart
Scenario: VAN17970_TestStep20_Check Uninstall Vantage and Re-install Toggle Status Is Still 'Off'
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Given Turn Off Flip To Start Toggle
	Then The Flip To Start Toggle State Is 'Off'
	Given Uninstall the lenovo vatage
	Given Install Vantage
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Then The Flip To Start Toggle State Is 'Off'

@CheckFlipToStart
Scenario: VAN17970_TestStep24_Check Resize Vantage The UI Should Be Displayed Normally
	Given Go to My Device Settings page
	Given Click Power Settings Link
	When Click Vantage Maxmize Button
	Then Check Power Settings 'Display Flip To Start Elements'

@CheckFlipToStart
Scenario: VAN17970_TestStep25_Check Change DPI and Resolution The UI Should Be Displayed Normally
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Then Take Screen Shot VAN17970_Step25_01 in 17970 under SettingsScreenShotResult
	Given Change DPI to 200
	Given change resolution 1024 to 768
	Then Take Screen Shot VAN17970_Step25_02 in 17970 under SettingsScreenShotResult
	Given change resolution 2240 to 1400
	Given Change DPI to 100