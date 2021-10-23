Feature: VAN8578_Createdisconnectoptionforlandingpage(normalusersonly)
	Test Case：https://jira.tc.lenovo.com/browse/VAN-8578
	Author ：yangyu

@Createdisconnectoptionforlandingpagenormalusersonly
Scenario: VAN8578_TestStep01_Check there will be a part of disconnect function showing up
	Given Remove Account from Web Console
	Given Remove "trialsecond" Account from Web Console
	Given Install Vantage
	Given User has Joined or Started a CHS "TrialSecond"Group
	Then Check The Part of "SecondUser"
	Then Take Screen Shot 01UI  in 8578 under CHScreenShotResul

@Createdisconnectoptionforlandingpagenormalusersonly
Scenario: VAN8578_TestStep02_Check there will be a part of disconnect function showing up
	When Check CHS Subpage
	When Click CHS "Disconnect" Button
	Then Take Screen Shot 02UI in 8578 under CHScreenShotResul

@Createdisconnectoptionforlandingpagenormalusersonly
Scenario: VAN8578_TestStep03_Check there disconnect prompt
	When Check CHS Subpage
	When Click CHS "Disconnect" Button
	Then Check The Part of "DisconnectPrompt"

@Createdisconnectoptionforlandingpagenormalusersonly
Scenario: VAN8578_TestStep04_Check click discoonect no btn will normal display seconduser
	When Check CHS Subpage
	When Click CHS "Disconnect" Button
	When Click CHS "DisconnectNo" Button
	Then Check The Part of "SecondUser"

@Createdisconnectoptionforlandingpagenormalusersonly
Scenario: VAN8578_TestStep05_Check click discoonect x btn will normal display seconduser
	When Check CHS Subpage
	When Click CHS "Disconnect" Button
	When Click CHS "Disconnect X" Button
	Then Check The Part of "SecondUser"

@Createdisconnectoptionforlandingpagenormalusersonly
Scenario: VAN8578_TestStep06_Check there will be a part of disconnect function showing up
	When Check CHS Subpage
	When Click CHS "Disconnect" Button
	When Click CHS "DisconnectPromptBtn" Button
	Then It Will Directly Go to CHS Marketing Page

@Createdisconnectoptionforlandingpagenormalusersonly
Scenario: VAN8578_TestStep07_Check admin user do not have disconnect button
	Given User has Joined or Started a CHS "Trialadmin"Group
	Then User Can See Admin/Secondary Console Normally
	Then There is No "Disconnect" Button
	Given Remove Account from Web Console

@Createdisconnectoptionforlandingpagenormalusersonly
Scenario: VAN8578_TestStep08_Check offline disconnect prompt
	Given Remove Account from Web Console
	Given User has Joined or Started a CHS "Trialsecond"Group
	Given Waiting 30 seconds
	When The user connect or disconnect WiFi off lenovo
	Then Will Pop up Offline Message
	When Click CHS "offlinedialogCancel" Button
	When Check CHS Subpage
	When Click CHS "offlinedialogCancel" Button
	When Click CHS "Disconnect" Button
	Then Will Pop up Offline Message
	When The user connect or disconnect WiFi on lenovo
	When Click CHS "offlinedialogCancel" Button
	When Click CHS "Disconnect" Button
	When Click CHS "DisconnectPromptBtn" Button
	Then It Will Directly Go to CHS Marketing Page
