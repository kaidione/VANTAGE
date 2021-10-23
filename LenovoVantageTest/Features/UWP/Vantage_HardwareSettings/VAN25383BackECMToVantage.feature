Feature: VAN25383BackECMToVantage
	Test Case： https://jira.tc.lenovo.com/browse/VAN-25383
	Author： Daqi Fang

Background: 
	Given New "Intel" API is supported

@BackECM
Scenario: VAN25383_TestStep24
	Given Set 'Intel(R) UHD Graphics' drive state to enable or disable 'disable' via HardwareId 'default'
	Given Go to Display & Camera page
	Given Click DisplayLink
	Then The ECM ui should be Unclickable
	Given Set 'Intel(R) UHD Graphics' drive state to enable or disable 'enable' via HardwareId 'default'

@BackECM
Scenario: VAN25383_TestStep25
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	Given Set 'Intel(R) Iris(R) Xe Graphics' drive state to enable or disable 'disable' via HardwareId 'default'
	Given wait 10 seconds
	Given Set 'Intel(R) Iris(R) Xe Graphics' drive state to enable or disable 'enable' via HardwareId 'default'
	Then Computer temperature same with "ColorSlider" slider

@BackECM
Scenario: VAN25383_TestStep26
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_Display" slider bar 100
	Given Drug the "Temp_UserSet" slider bar 100
	Given Get computer temperature value
	Given Set 'Intel(R) Iris(R) Xe Graphics' drive state to enable or disable 'disable' via HardwareId 'default'
	Given wait 10 seconds
	Given Set 'Intel(R) Iris(R) Xe Graphics' drive state to enable or disable 'enable' via HardwareId 'default'
	When Cut page
	Then The ECM ui should be clickable 
	Then The new value will keep in Tn
	Then The ECM slider bar value will keep on T_en
	Then The computer temperature is not change