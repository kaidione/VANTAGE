Feature: VAN4331_Daytime Color Temperature
	Test Case： https://jira.tc.lenovo.com/browse/VAN-4331
	Author： Daqi Fang

Background: 
	Given New "Intel" API is supported

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep01
	Given Go to Display & Camera page
	Given Click DisplayLink
	When Take Screen Shot VAN4331_Step01 in 4331 under HSScreenShotResult

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep02
	Given Go to Display & Camera page
	Given Click DisplayLink
	Then There will show "DayTimeColorSliderBar"

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep03
	Given Go to Display & Camera page
	Given Click DisplayLink
	Then There will show "DayTimeColorReset"

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep04
	Given Go to Display & Camera page
	Given Click DisplayLink
	Then There will show "DayTimeColorQuickMark"

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep05
	Given Go to Display & Camera page
	Then Check the title is "Daytime Color Temperature"
	Given Click DisplayLink
	Then There will show "DayTimeColorTempNote"

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep06
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Drug the "Temp_Display" slider bar 100
	Given Uninstall the lenovo vatage
	When Wait 1 minutes
	Given Install Vantage
	Given Go to Display & Camera page
	Given Click DisplayLink
	Then The computer temperature default is "6500"
	Then The "DayTimeFeature" slider default "Temp_Display" Regedit "6500" Ui "6500K"

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep07
	Given Go to Display & Camera page
	Given Click DisplayLink
	Then Check The "DayTimeColorQuickMark" description

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep08
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100
	Then The computer temperature will change to Tn
	When Click "Daytimeslider" Reset button 

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep09
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 200
	Then The computer temperature will change to Tn
	When Click "Daytimeslider" Reset button 

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep10
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100
	Given Get computer temperature value
	When Cut page
	Then The computer temperature is not change 
	Then The new value will keep in Tn
	When Close Vantage
	When Launch Vantage
	Given Go to Display & Camera page
	Given Click DisplayLink
	Then The computer temperature is not change 
	Then The new value will keep in Tn
	When Click "Daytimeslider" Reset button 

@DaytimeColorTemperatureIntelS3S4
#没有写restar shutdown
Scenario: VAN4331_TestStep11
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 200
	Given Get computer temperature value
	When Enter sleep
	Then The computer temperature is not change 
	When Enter hibernate
	Then The computer temperature is not change 
	When Click "Daytimeslider" Reset button 

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep12
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100
	Given Get computer temperature value
	Given Minimize Vantage 
	When Wait 5 minutes
	Then The computer temperature is not change 
	When Close Vantage
	When Wait 5 minutes
	Then The computer temperature is not change 

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep14
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 200
	Given Get computer temperature value
	Given Change DPI to max
	Then The computer temperature is not change 
	Given Change DPI to recommend
	When Click "Daytimeslider" Reset button 

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep15
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100
	Given Get computer temperature value
	When Stop the IMC service in the task manager
	When Start the IMC service in the task manager
	Then The computer temperature is not change 
	When Click "Daytimeslider" Reset button

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep16
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100
	Given Turn "on" Color temperature
	Given wait 1 seconds
	Then Computer temperature same with "UserSet" slider
	When Click "Daytimeslider" Reset button

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep17
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100
	Given Turn "on" Color temperature
	Given Turn "off" Color temperature
	Given wait 2 seconds
	Then Computer temperature same with "ColorSlider" slider
	When Click "Daytimeslider" Reset button

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep19
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100
	Given Turn "on" Color temperature
	Given Drug the "Temp_Display" slider bar 200
	Then The new value will keep in Tn
	When Click "Daytimeslider" Reset button

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep20
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100
	Given Turn "on" Color temperature
	Given Drug the "Temp_Display" slider bar 200
	Then Computer temperature same with "UserSet" slider
	When Click "Daytimeslider" Reset button

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep21
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100
	Given Turn "on" Color temperature
	Given Drug the "Temp_Display" slider bar 200
	Given Turn "off" Color temperature
	Given wait 2 seconds
	Then Computer temperature same with "ColorSlider" slider
	When Click "Daytimeslider" Reset button

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep22
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100
	When Click "Daytimeslider" Reset button
	Given wait 2 seconds
	Then The computer temperature default is "6500"

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep23
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100
	When Click "Daytimeslider" Reset button
	Then The "DayTimeFeature" slider default "Temp_Display" Regedit "6500" Ui "6500K"

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep24
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100
	Given Turn "on" Color temperature
	Given wait 2 seconds
	Given Get computer temperature value
	When Click "Daytimeslider" Reset button
	Then The computer temperature is not change 

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep25
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100
	Given Turn "on" Color temperature
	When Click "Daytimeslider" Reset button
	Then The "DayTimeFeature" slider default "Temp_Display" Regedit "6500" Ui "6500K"

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep26
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100
	Given Uninstall the lenovo vatage
	When Wait 1 minutes
	Then The computer temperature default is "6500"

@DaytimeColorTemperatureIntel
Scenario: VAN4331_TestStep30
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100
	When Take Screen Shot VAN4331_Step030 in 4331 under HSScreenShotResult