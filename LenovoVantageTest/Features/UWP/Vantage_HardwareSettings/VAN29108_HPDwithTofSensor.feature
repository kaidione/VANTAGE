Feature: VAN29108_HPDwithTofSensor
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29108
	Author: Haiye Li

@HPDHardwareSettings
Scenario: VAN29108_TestStep11 Check 'Go to Windows Hello Settings' link
	Given Check computer not have hello face
	Given Go to Smart Assist page
	Then There is "Go to Windows Hello Settings" link
	Given Scoll to HPD "ResectButton"
	When Click HPD Reset Button

@HPDHardwareSettings
Scenario: VAN29108_TestStep29 set value and reinstall and check value
	Given Go to Smart Assist page
	And Check ZT Login switch button is on
	And Click ZT Login ADV ADSA slider bar to "Near"
	Given wait 2 seconds
	Given Close ZT Login switch button
	Given Check Zero Touch Lock switch button is on
	Given Scoll to HPD "ResectButton"
	Given ClicK Zero Touch Lock ADSA SldierBar to "Near"
	And Click Auto Screen Lock Timer "Medium"
	Given "noChecked" the Override checkbox
	Given Scoll to HPD "ZTLockcheckbox"
	Given Close Zero Touch Lock button
	When Get all value of ZT
	Given wait 2 seconds
	Given Uninstall the lenovo vatage
	Given Install Vantage
	Given Go to Smart Assist page
	When Check all value of ZT
	Given Scoll to HPD "ResectButton"
	When Click HPD Reset Button

@HPDHardwareSettings
Scenario: VAN29108_TestStep30 Check Zero Touch Lock text and take screen
	Given Go to Smart Assist page
	Given Check Zero Touch Lock switch button is on
	Given Scoll to HPD "ZTLock"
	Then Check Zero Touch Lock text
	Then Take Screen Shot 30CheckText in VAN29108 under HSScreenShotResult
	Given ClicK Zero Touch Lock ADSA SldierBar to "Near"
	Then Get ZTLock slider Value
	When enter sleep
	Then The ZTLock slider Value not change
	When enter hibernate
	Then The ZTLock slider Value not change
	When Minimize vantage conservation mode
	Then The ZTLock slider Value not change
	When ReLaunch Vantage
	Given Go to Smart Assist page
	Then The ZTLock slider Value not change
	Given into Dashboard page
	Given Go to Smart Assist page
	Then The ZTLock slider Value not change
	Given Scoll to HPD "ZTLock"
	Given ClicK Zero Touch Lock ADSA SldierBar to "Middle"
	Then Get ZTLock slider Value
	When enter sleep
	Then The ZTLock slider Value not change
	When enter hibernate
	Then The ZTLock slider Value not change
	When Minimize vantage conservation mode
	Then The ZTLock slider Value not change
	When ReLaunch Vantage
	Given Go to Smart Assist page
	Then The ZTLock slider Value not change
	Given into Dashboard page
	Given Go to Smart Assist page
	Then The ZTLock slider Value not change
	Given Scoll to HPD "ZTLock"
	Given ClicK Zero Touch Lock ADSA SldierBar to "Far"
	Then Get ZTLock slider Value
	When enter sleep
	Then The ZTLock slider Value not change
	When enter hibernate
	Then The ZTLock slider Value not change
	When Minimize vantage conservation mode
	Then The ZTLock slider Value not change
	When ReLaunch Vantage
	Given Go to Smart Assist page
	Then The ZTLock slider Value not change
	Given into Dashboard page
	Given Go to Smart Assist page
	Then The ZTLock slider Value not change

@HPDHardwareSettings
Scenario: VAN29108_TestStep33 slider ADSA sliderbar and click reset
	Given Go to Smart Assist page
	Given Check Zero Touch Lock switch button is on
	Given Scoll to HPD "ResectButton"
	Given ClicK Zero Touch Lock ADSA SldierBar to "Far"
	When Click HPD Reset Button
	Given wait 2 seconds
	Then The ZTLock slider Value is default
	Given ClicK Zero Touch Lock ADSA SldierBar to "Middle"
	When Click HPD Reset Button
	Given wait 2 seconds
	Then The ZTLock slider Value is default
	Given ClicK Zero Touch Lock ADSA SldierBar to "Near"
	When Click HPD Reset Button
	Given wait 2 seconds
	Then The ZTLock slider Value is default

@HPDHardwareSettingsNoSmart
Scenario: VAN29108_TestStep51 no smart assist link
	Then Smart Assist page not show