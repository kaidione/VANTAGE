﻿Feature: VAN29914_ColorTemperatureInEyeCareMode
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29914
	Author： Daqi Fang

Background: 
	Given New "AMD" API is supported

@ColorTemperatureAMD
Scenario: VAN29914_TestStep01
	Given Go to Display & Camera page
	Given Click DisplayLink
	When Take Screen Shot VAN29914_Step01CheckColorTemperature in 29914 under HSScreenShotResult

@ColorTemperatureAMD
Scenario: VAN29914_TestStep02
	Given Go to Display & Camera page
	Given Click DisplayLink
	Then There will show "ColorTemperatureInEyeCareMode"

@ColorTemperatureAMD
Scenario: VAN29914_TestStep03
	Given Go to Display & Camera page
	Given Click DisplayLink
	Then There will show "ColorTemperatureReset"

@ColorTemperatureAMD
Scenario: VAN29914_TestStep04
	Given Go to Display & Camera page
	Given Click DisplayLink
	Then There will show "ColorTemperatureQuickMark"

@ColorTemperatureAMD
Scenario: VAN29914_TestStep05
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 200
	Given Uninstall the lenovo vatage
	When Wait 1 minutes
	Given Install Vantage
	Given Go to Display & Camera page
	Given Click DisplayLink
	Then The computer temperature default is "6500"
	Then The ECM toggle is "off"
	Then The "ECMFeature" slider default "Temp_UserSet" Regedit "4500" Ui "4500K"

@ColorTemperatureAMD
Scenario: VAN29914_TestStep06
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given wait 2 seconds
	Then The computer temperature default is "4500"

@ColorTemperatureAMD
Scenario: VAN29914_TestStep07
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Get computer temperature value
	Given Drug the "Temp_UserSet" slider bar 100
	Then Color temperature in Eye Care Mode can be adjusted
	When Click "ECMslider" Reset button 

@ColorTemperatureAMD
Scenario: VAN29914_TestStep08
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Get computer temperature value
	Given Drug the "Temp_UserSet" slider bar 100
	Then The computer temperature is change
	When Click "ECMslider" Reset button 

@ColorTemperatureAMD
Scenario: VAN29914_TestStep09
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	Then Computer temperature same with "UserSet" slider
	When Click "ECMslider" Reset button 

@ColorTemperatureAMD
Scenario: VAN29914_TestStep10
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	Given wait 2 seconds
	Then The computer temperature will change to Tn
	When Click "ECMslider" Reset button 

@ColorTemperatureAMD
Scenario: VAN29914_TestStep11
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 200
	When Cut page
	Then The ECM slider bar value will keep on T_en 
	When ReLaunch Vantage
	Given Go to display page
	Then The ECM slider bar value will keep on T_en 
	When Click "ECMslider" Reset button 

@ColorTemperatureAMDS3S4
Scenario: VAN29914_TestStep12
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	Given Get computer temperature value
	When Enter sleep
	Then The computer temperature is not change 
	When Enter hibernate
	Then The computer temperature is not change 
	When Click "ECMslider" Reset button

@ColorTemperatureAMD
Scenario: VAN29914_TestStep13
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 200
	Given Get computer temperature value
	Given Minimize Vantage
	When Wait 5 minutes
	Then The computer temperature is not change 
	When Close Vantage
	When Wait 5 minutes
	Then The computer temperature is not change 

@ColorTemperatureAMD
Scenario: VAN29914_TestStep15
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 400
	Given Get computer temperature value
	Given Change DPI to max
	Then The computer temperature is not change 
	Given Change DPI to recommend
	When Click "ECMslider" Reset button  

@ColorTemperatureAMD
Scenario: VAN29914_TestStep16
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar -300
	Given Get computer temperature value
	When Stop the IMC service in the task manager
	When Start the IMC service in the task manager
	Then The computer temperature is not change 
	When Click "ECMslider" Reset button 

@ColorTemperatureAMD
Scenario: VAN29914_TestStep17
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 200
	Given Turn "off" Color temperature
	Then Computer temperature same with "ColorSlider" slider
	When Click "ECMslider" Reset button

@ColorTemperatureAMD
Scenario: VAN29914_TestStep18
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 200
	Given Turn "off" Color temperature
	Given Turn "on" Color temperature
	Then Computer temperature same with "UserSet" slider
	When Click "ECMslider" Reset button

@ColorTemperatureAMD
Scenario: VAN29914_TestStep19
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	Given Turn "off" Color temperature
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 200
	Then The computer temperature will change to Tn
	When Click "ECMslider" Reset button

@ColorTemperatureAMD
Scenario: VAN29914_TestStep20
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	Given Turn "off" Color temperature
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 200
	Then Color temperature in Eye Care Mode can be adjusted 
	Then The ECM slider bar value will keep on T_en
	When Click "ECMslider" Reset button

@ColorTemperatureAMD
Scenario: VAN29914_TestStep21
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	Given Turn "off" Color temperature
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 200
	Then Computer temperature same with "UserSet" slider
	When Click "ECMslider" Reset button

@ColorTemperatureAMD
Scenario: VAN29914_TestStep22
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	Given Turn "off" Color temperature
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 200
	Given Turn "off" Color temperature
	Then Computer temperature same with "ColorSlider" slider
	When Click "ECMslider" Reset button

@ColorTemperatureAMD
Scenario: VAN29914_TestStep23
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	When Click "ECMslider" Reset button
	Given wait 2 seconds
	Then The computer temperature default is "4500"

@ColorTemperatureAMD
Scenario: VAN29914_TestStep24
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	When Click "ECMslider" Reset button
	Then The "ECMFeature" slider default "Temp_UserSet" Regedit "4500" Ui "4500K"

@ColorTemperatureAMD
Scenario: VAN29914_TestStep25
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	Given Turn "off" Color temperature
	Given wait 2 seconds
	Given Get computer temperature value
	When Click "ECMslider" Reset button
	Then The computer temperature is not change 

@ColorTemperatureAMD
Scenario: VAN29914_TestStep26
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	Given Turn "off" Color temperature
	When Click "ECMslider" Reset button
	Then The "ECMFeature" slider default "Temp_UserSet" Regedit "4500" Ui "4500K"

@ColorTemperatureAMD
Scenario: VAN29914_TestStep27
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Then The sliderbar of ECM will be greyout

@ColorTemperatureAMD
Scenario: VAN29914_TestStep28
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	Given Uninstall the lenovo vatage
	When Wait 1 minutes
	Then The color temperature will change to OOBE value

@ColorTemperatureAMD
Scenario: VAN29914_TestStep35
	Given Go to Display & Camera page
	Given Click DisplayLink
	When Take Screen Shot VAN29914_Step35CheckColorTemperature in 29914 under HSScreenShotResult