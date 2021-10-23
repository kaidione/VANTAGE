Feature: VAN284_ScheduleEyeCareMode
	Test Case： https://jira.tc.lenovo.com/browse/VAN-284
	Author： Daqi Fang

Background: 
	Given New "Intel" API is supported

@EyeCareModeIntel
Scenario: VAN284_TestStep01
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given "checked" the Eye care Mode checkbox
	Given Uninstall the lenovo vatage
	When Wait 1 minutes
	Given Install Vantage
	Then The computer temperature default is "6500"
	Given Go to Display & Camera page
	Given Click DisplayLink
	Then The Eye care Mode checkbox is "unchecked"
	Then Reset Daytime and ECM

@EyeCareModeIntel
Scenario: VAN284_TestStep02
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Then The Check-box of Schedule Eye Care mode is "nogreyout"
	When Click ECM Schedule CheckBox And Check can be set
	Then Reset Daytime and ECM

@EyeCareModeIntel
Scenario: VAN284_TestStep03
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given "unchecked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	When Wait 2 minutes 
	Then The computer temperature default is "6500"
	Given Set Time to "sunrise"
	When Wait 2 minutes
	Then The computer temperature default is "6500"

@EyeCareModeIntel
Scenario: VAN284_TestStep04
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given "unchecked" the Eye care Mode checkbox
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Given wait 30 seconds
	Then The ECM toggle will change to on
	Then The computer temperature default is "4500"
	Then Reset Daytime and ECM

@EyeCareModeIntel
Scenario: VAN284_TestStep05
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given "unchecked" the Eye care Mode checkbox
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Then The ECM toggle will change to on

@EyeCareModeIntel
Scenario: VAN284_TestStep06
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given "unchecked" the Eye care Mode checkbox
	Given "checked" the Eye care Mode checkbox
	Given wait 30 seconds
	Then The ECM toggle will change to on
	Given Set Time to "sunrise"
	Then The ECM feature toggle button default value should be off
	Then Reset Daytime and ECM

@EyeCareModeIntel
Scenario: VAN284_TestStep07
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given The Temp_Display is not same with Temp_UserSet "Temp_UserSet"
	Given Turn "off" Color temperature
	Given "unchecked" the Eye care Mode checkbox
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Given Turn "off" Color temperature
	When Wait 2 minutes
	Then The ECM feature toggle button default value should be off
	Then Computer temperature same with "ColorSlider" slider

@EyeCareModeIntel
Scenario: VAN284_TestStep08
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given The Temp_Display is not same with Temp_UserSet "Temp_UserSet"
	Given Turn "off" Color temperature
	Given "unchecked" the Eye care Mode checkbox
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Given Turn "off" Color temperature
	When Wait 2 minutes
	Then The ECM feature toggle button default value should be off
	Then Computer temperature same with "ColorSlider" slider
	Given Set Time to "sunset"
	Then Computer temperature same with "UserSet" slider

@EyeCareModeIntel
Scenario: VAN284_TestStep09
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Then Computer temperature same with "UserSet" slider
	Given Set Time to "sunrise"
	Then Computer temperature same with "ColorSlider" slider
	Then Reset Daytime and ECM

@EyeCareModeIntel
Scenario: VAN284_TestStep10
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	Given Get computer temperature value
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Then The computer temperature is not change 
	Given Set Time to "sunrise"
	Then The computer temperature is not change 
	Then Reset Daytime and ECM

@EyeCareModeIntel
Scenario: VAN284_TestStep11
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	Given Get computer temperature value
	Given Turn "off" Color temperature
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	When Wait 5 minutes
	Then The computer temperature is not change 
	Then Reset Daytime and ECM

@EyeCareModeIntel
Scenario: VAN284_TestStep12
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	Given Turn "off" Color temperature
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Then Computer temperature same with "UserSet" slider
	Given Set Time to "sunrise"
	Then Computer temperature same with "ColorSlider" slider
	Then Reset Daytime and ECM

@EyeCareModeIntel
Scenario: VAN284_TestStep13
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given "checked" the Eye care Mode checkbox
	Given Turn "on" Color temperature
	Then The Eye care Mode checkbox is "checked"
	Given Turn "off" Color temperature
	Then The Eye care Mode checkbox is "checked"

@EyeCareModeIntel
Scenario: VAN284_TestStep14
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given "unchecked" the Eye care Mode checkbox
	Given Turn "on" Color temperature
	Then The Eye care Mode checkbox is "unchecked"
	Given Turn "off" Color temperature
	Then The Eye care Mode checkbox is "unchecked"

@EyeCareModeIntel
Scenario: VAN284_TestStep15
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given "unchecked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Given "checked" the Eye care Mode checkbox
	When Cut page
	Then The ECM toggle is "on"
	Then ECM slider will change to can be set
	Then Computer temperature same with "UserSet" slider
	Then Reset Daytime and ECM

@EyeCareModeIntel
Scenario: VAN284_TestStep16
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Given "unchecked" the Eye care Mode checkbox
	When Cut page
	Then The ECM toggle is "off"
	Then ECM slider will change to can't be set
	Then Computer temperature same with "ColorSlider" slider   
	Then Reset Daytime and ECM

@EyeCareModeIntelS3S4
Scenario: VAN284_TestStep17
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	When Enter sleep
	Then The ECM toggle is "on"
	Then ECM slider will change to can be set
	Then Computer temperature same with "UserSet" slider
	Then The Eye care Mode checkbox is "checked"
	When Enter hibernate
	Then The ECM toggle is "on"
	Then ECM slider will change to can be set
	Then Computer temperature same with "UserSet" slider
	Then The Eye care Mode checkbox is "checked"
	Then Reset Daytime and ECM

@EyeCareModeIntelS3S4
Scenario: VAN284_TestStep18
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunrise"
	Given Get computer temperature value
	When Enter sleep
	Then The Eye care Mode checkbox is "checked"
	Then The computer temperature is not change 
	When Enter hibernate
	Then The Eye care Mode checkbox is "checked"
	Then The computer temperature is not change 
	Then Reset Daytime and ECM

@EyeCareModeIntelS3S4
Scenario: VAN284_TestStep19
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "nearsunset"
	When Enter sleep
	Given wait 30 seconds
	Then The ECM toggle is "on"
	Then The Eye care Mode checkbox is "checked"
	Then Computer temperature same with "UserSet" slider
	Given Set Time to "nearsunset"
	When Enter hibernate
	Given wait 30 seconds
	Then The ECM toggle is "on"
	Then The Eye care Mode checkbox is "checked"
	Then Computer temperature same with "UserSet" slider
	Then Reset Daytime and ECM

@EyeCareModeIntelS3S4
Scenario: VAN284_TestStep20
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given "checked" the Eye care Mode checkbox
	Given Turn "off" Color temperature
	Given Set Time to "nearsunriset"
	When Wait 1 minutes
	When Enter sleep
	Given wait 30 seconds
	Then The Eye care Mode checkbox is "checked"
	Then Computer temperature same with "ColorSlider" slider
	Given Set Time to "nearsunriset"
	When Wait 1 minutes
	When Enter hibernate
	Given wait 30 seconds
	Then The Eye care Mode checkbox is "checked"
	Then Computer temperature same with "ColorSlider" slider
	Then Reset Daytime and ECM

@EyeCareModeIntel
Scenario: VAN284_TestStep21
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	Given "checked" the Eye care Mode checkbox
	When Click "ECMslider" Reset button
	Then The Eye care Mode checkbox is "checked"

@EyeCareModeIntel
Scenario: VAN284_TestStep22
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 200
	Given Turn "off" Color temperature
	Given "checked" the Eye care Mode checkbox
	When Click "ECMslider" Reset button
	Then The Eye care Mode checkbox is "checked"
	Given Set Time to "sunset"
	Then The computer temperature default is "4500"
	Then Computer temperature same with "UserSet" slider
	Then Reset Daytime and ECM

@EyeCareModeIntel
Scenario: VAN284_TestStep23
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Click the ECM checkbox more times

@EyeCareModeIntel
Scenario: VAN284_TestStep24
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given "checked" the Eye care Mode checkbox
	When Cut page
	Then The Eye care Mode checkbox is "checked"
	Given "unchecked" the Eye care Mode checkbox
	When Cut page
	Then The Eye care Mode checkbox is "unchecked"
	When Click ECM Schedule CheckBox And Check can be set

@EyeCareModeIntel
Scenario: VAN284_TestStep25
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given "checked" the Eye care Mode checkbox
	Given Minimize Vantage
	Given Maxmize Vantage
	Then The Eye care Mode checkbox is "checked"
	Given "unchecked" the Eye care Mode checkbox
	Given Minimize Vantage
	Given Maxmize Vantage
	Then The Eye care Mode checkbox is "unchecked"
	When Click ECM Schedule CheckBox And Check can be set
	Given "checked" the Eye care Mode checkbox
	Given Go to Display & Camera page
	Given Click DisplayLink
	Then The Eye care Mode checkbox is "checked"
	Given "unchecked" the Eye care Mode checkbox
	Given Go to Display & Camera page
	Given Click DisplayLink
	Then The Eye care Mode checkbox is "unchecked"
	When Click ECM Schedule CheckBox And Check can be set

@EyeCareModeIntel
Scenario: VAN284_TestStep26
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn "off" Color temperature
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Given Uninstall the lenovo vatage
	Then The color temperature will change to OOBE value 
	Given Install Vantage
	Given Go to Display & Camera page
	Given Click DisplayLink
	Then The Eye care Mode checkbox is "unchecked"

@EyeCareModeIntel
Scenario: VAN284_TestStep27
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Turn off Location Service in Settings Page
	Given wait 10 seconds
	Then The Check-box of Schedule Eye Care mode is "greyout"
	Then ECM Display title and link is "show"

@EyeCareModeIntel
Scenario: VAN284_TestStep28
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Location for Vantage has been Enabled
	When Cut page
	Given "checked" the Eye care Mode checkbox
	Given Turn off Location Service in Settings Page
	Given wait 10 seconds
	Then The Check-box of Schedule Eye Care mode is "greyout"
	Then Schedule CheckBox should be in checked 
	Then ECM Display title and link is "show"
	
@EyeCareModeIntel
Scenario: VAN284_TestStep29
	Given Go to Display & Camera page
	Given Click DisplayLink
	Given Location for Vantage has been Enabled
	Given "checked" the Eye care Mode checkbox
	Given Turn off Location Service in Settings Page
	Given Location for Vantage has been Enabled
	When wait 10 seconds
	Then The Check-box of Schedule Eye Care mode is "nogreyout"
	Then Schedule CheckBox should be in checked 
	Then ECM Display title and link is "hidden"
	Given Set Time to "Sync"