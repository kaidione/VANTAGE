Feature: VAN13415_VoipHotkeyFunctionTest
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-13415
	Author： Jiajt3
	Author: Chenpj5
	Update: Haiye Li

@ThinkSupportVoip @SmokeThinkSupportVoip
Scenario: VAN13415_TestStep01_Check The UI Of VoIP
	Given Thinkpad machines
	And Machine support VOIP true
	Given The 'Teams' app will be installed or uninstalled 'installed'
	Given Go to input page
	When Go to Voip Section witin Input page
	Then The VOIP feature display is the same as UI
	| section     | desc                                                                                               |
	| title       | VoIP Hotkey Functions                                                                              |
	| desc        | This feature enables you to answer or reject a VoIP call by pressing the hotkeys on your keyboard: |
	| f10         | F10: answer the call                                                                               |
	| f11         | F11: reject the call															                   |
	| option      | This feature supports the following applications: 		                                           |
	| teamsoption | Microsoft Teams                                                                                    |
	Then Microsoft Teams image shows under the description
	Then The note is hidden
	Then Take Screen Shot TestStep01_VoIPNoteHidden in VAN13415 under HSScreenShotResult

@ThinkSupportVoip
Scenario: VAN13415_TestStep02_Check The UI Of VoIP
	Given Thinkpad machines
	And Machine support VOIP true
	Given The 'Teams' app will be installed or uninstalled 'uninstalled'
	Given Go to input page
	When Go to Voip Section witin Input page
	Then The VOIP feature display is the same as UI
	| section     | desc                                                                                               |
	| title       | VoIP Hotkey Functions                                                                              |
	| desc        | This feature enables you to answer or reject a VoIP call by pressing the hotkeys on your keyboard: |
	| f10         | F10: answer the call                                                                               |
	| f11         | F11: reject the call															                   |
	| option      | This feature supports the following applications: 			                                       |
	| teamsoption | Microsoft Teams                                                                                    |
	| note        | Note: To use the feature, you need to download and install the app first.                          |
	Then Microsoft Teams image shows under the description
	Then A Note under the image
	Then Take Screen Shot TestStep02_VoIPNoteShow in VAN13415 under HSScreenShotResult

@ThinkNotSupportVoip
Scenario: VAN13415_TestStep03_Machine not support Voip there should no feature
	Given Thinkpad machines
	And Machine support VOIP false
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When Waiting 10 seconds
	Then There is no VOIP feature

@ThinkSupportVoip
Scenario: VAN13415_TestStep04_Check The UI Of VoIP change vantege window size
	Given The 'Teams' app will be installed or uninstalled 'installed'
	Given Go to input page
	When Go to Voip Section witin Input page
	Then Minimize vantage
	Then Maximize Vatnage
	Then The UI Should Be Display Cirrectky

@ThinkSupportVoip
Scenario: VAN13415_TestStep06_Team Apps are installed and not running Teams as F10 then will be Launched
	Given Thinkpad machines
	And Machine support VOIP true
	Given The 'Teams' app will be installed or uninstalled 'installed'
	When close lenovo vantage
	Given Launch Vantage
	Given Loading Vantage '20' times for 'Common' Machine
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When Go to Voip Section witin Input page
	When Simulate Press F10 Event
	When Waiting 15 seconds
	Then Teams will be Launched

@ThinkSupportVoip
Scenario: VAN13415_TestStep08_Check Simulate Press F10 Event and F11 Event jump to Input Page
	Given The 'Teams' app will be installed or uninstalled 'uninstalled'
	When Simulate Press F10 Event
	When Waiting 5 seconds
	When Check Open Input page
	Given Go to Power Page
	When Simulate Press F11 Event
	When Waiting 5 seconds
	When Check Open Input page
	When Go to Voip Section witin Input page
	Then Take Screen Shot TestStep08_PressF11JumptoInputPage in VAN13415 under HSScreenShotResult

@ThinkSupportVoip
Scenario: VAN13415_TestStep09_Check install vantage no launch Teams uninstall Simulate Press F11 Event jump to Input Page
	Given Uninstall the lenovo vatage
	Given Install Vantage No Launch
	Given The 'Teams' app will be installed or uninstalled 'uninstalled'
	When Simulate Press F11 Event
	Given Launch Vantage with OOBE
	When Maximize Vatnage
	Then Input Page Show All

@ThinkSupportVoip
Scenario: VAN13415_TestStep10_Check The UI Of VoIP Refresh The Page
	Given The 'Teams' app will be installed or uninstalled 'installed'
	Given Go to input page
	When Go to Voip Section witin Input page
	Given Go to Power Page
	Given Go to input page
	Then The UI Should Be Display Cirrectky

@ThinkSupportVoip
Scenario: VAN13415_TestStep11_Check The UI Of VoIP Reopen Vantage
	Given The 'Teams' app will be installed or uninstalled 'installed'
	Given Go to input page
	When close lenovo vantage
	Given Launch Vantage
	Given Go to input page
	When Go to Voip Section witin Input page
	Then The UI Should Be Display Cirrectky

@ThinkSupportVoip
Scenario: VAN13415_TestStep12_Check The performance
	Given The 'Teams' app will be installed or uninstalled 'installed'
	Given Go to input page
	Then The UI VoIP should be displayed within 3 seconds when first launch
	Given Go to Power Page
	Given Go to input page
	Then The UI VoIP should be displayed within 2 seconds when second launch