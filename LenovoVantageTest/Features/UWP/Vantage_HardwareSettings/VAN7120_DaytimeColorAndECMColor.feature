Feature: VAN7120_VFC180_VantageHardwareSettingsDaytimeColorAndECMColorAndScheduleECMQuickRegression
	Test Case： https://jira.tc.lenovo.com/browse/VAN-7120
	Author： DaQi Fan

@DaytimeAndECM @SmokeDaytimeAndECM
Scenario: VAN7120_TestStep01_The Daytime feature Slider default value should be OOBE
	Given Turn on Location for Vantagee
	Given Uninstall the lenovo vatage
	When Wait 2 minutes
	Given Install Vantage
	Given Go to display page
	Then The "DayTimeFeature" slider default "Temp_Display" Regedit "6500" Ui "6500K"
	Then The "ECMFeature" slider default "Temp_UserSet" Regedit "4500" Ui "4500K"
	Then The ECM feature toggle button default value should be off
	Then Schedule CheckBox should be in unchecked 

@DaytimeAndECM-Hibernate
Scenario: VAN7120_TestStepF03_Turn Off Color temperature Drag the Daytime color temperature slider to a new value and hibernate
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	When Enter sleep
	Then The new value will keep in Tn
	When enter hibernate
	Then The new value will keep in Tn
	Then Reset Daytime and ECM

@DaytimeAndECM
Scenario: VAN7120_TestStep05_Turn Off Color temperature Drag the Daytime color temperature slider to a new value and cut page and relaunch
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	When Cut page
	Then The new value will keep in Tn
	When ReLaunch Vantage
	Given Go to display page
	Then The new value will keep in Tn
	Then Reset Daytime and ECM

@DaytimeAndECM
Scenario: VAN7120_TestStep12_Turn on Color temperature Drag the ECM color temperature slider to a new value and and cut page and relaunch
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	When Cut page
	Then The ECM slider bar value will keep on T_en 
	When ReLaunch Vantage
	Given Go to display page
	Then The ECM slider bar value will keep on T_en 
	Then Reset Daytime and ECM

@DaytimeAndECM
Scenario: VAN7120_TestStep16_Turn on Color temperature Drag the Daytime color temperature slider to a new value twice 
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	Given Turn "on" Color temperature
	Given Drug the "Temp_Display" slider bar 200
	Then The new value will keep in Tn
	Then Reset Daytime and ECM

@DaytimeAndECM
Scenario: VAN7120_TestStep18_Turn off Color temperature Drag the Daytime color temperature slider to a new value twice 
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	Given Turn "on" Color temperature
	Given Drug the "Temp_Display" slider bar 200
	Given Turn "off" Color temperature
	Then The new value will keep in Tn
	Then Reset Daytime and ECM

@DaytimeAndECM
Scenario: VAN7120_TestStep19_Turn off Color temperature The slider-bar of ECM will be grey-out and cannot be set
	Given Go to display page
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 200
	Given Drug the "Temp_Display" slider bar 100
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 200
	Then The sliderbar of ECM will be greyout
	Then Drug the Temp_UserSet slider bar 100 but expected failed
	Then Take Screen Shot  VAN7120_TestStep19GreySlider in 7120 under SettingscreenShotResult
	Then The ECM slider bar value will keep on T_en
	Then Reset Daytime and ECM

@DaytimeAndECM
Scenario: VAN7120_TestStep21_Turn off Color temperature click daytimeslider reset button the value is obbe
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	When Click "Daytimeslider" Reset button 
	Then The "DayTimeFeature" slider default "Temp_Display" Regedit "6500" Ui "6500K"
	Then Reset Daytime and ECM

@DaytimeAndECM
Scenario: VAN7120_TestStep23_Turn on Color temperature click daytimeslider reset button the value is obbe
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100
	Given Turn "on" Color temperature
	When Click "Daytimeslider" Reset button 
	Then The "DayTimeFeature" slider default "Temp_Display" Regedit "6500" Ui "6500K"
	Then Reset Daytime and ECM

@DaytimeAndECM
Scenario: VAN7120_TestStep24_Turn off Color temperature drag daytimeslider unstallvantage the color value is obbe
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100
	Given Uninstall the lenovo vatage
	When Wait 2 minutes
	Then The color temperature will change to OOBE value
	
@DaytimeAndECM
Scenario: VAN7120_TestStep26_Turn on Color temperature click the ECM Reset button the value is 4500
	Given Go to display page
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	When Click "ECMslider" Reset button 
	Then The "ECMFeature" slider default "Temp_UserSet" Regedit "4500" Ui "4500K"
	Then Reset Daytime and ECM

@DaytimeAndECM
Scenario: VAN7120_TestStep28_Turn off Color temperature click the ECM Reset button the value is 4500
	Given Go to display page
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	Given Turn "off" Color temperature
	When Click "ECMslider" Reset button 
	Then The "ECMFeature" slider default "Temp_UserSet" Regedit "4500" Ui "4500K"
	Then Reset Daytime and ECM

@DaytimeAndECM
Scenario: VAN7120_TestStep30_Cut time to sunset and check the ECMcheckbox and slider
	Given Go to display page
	Given Turn "off" Color temperature
	Given "unchecked" the Eye care Mode checkbox
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Then The ECM toggle will change to on
	Then ECM slider will change to can be set

@DaytimeAndECM
Scenario: VAN7120_TestStep32_Cut time to sunrise and check the ECMcheckbox and slider
	Given Go to display page
	Given Turn "off" Color temperature
	Given "unchecked" the Eye care Mode checkbox
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunrise"
	Then The ECM feature toggle button default value should be off
	Then The sliderbar of ECM will be greyout
	Given Set System Time Automatically To Sync

@DaytimeAndECM
Scenario: VAN7120_TestStep40_Turn off location and check the Schedule checkbox
	Given Go to display page
	Given Turn "off" Color temperature
	Given Turn on Location for Vantagee
	Given "checked" the Eye care Mode checkbox
	Given Turn off Location Service in Settings Page
	When Cut page
	When Wait 3 minutes
	Then The Check-box of Schedule Eye Care mode is "greyout"
	Then Schedule CheckBox should be in checked 

@DaytimeAndECM
Scenario: VAN7120_TestStep41_Turn on location and check the Schedule checkbox
	Given Go to display page
	Given Turn "off" Color temperature
	Given Turn on Location for Vantagee
	Given "checked" the Eye care Mode checkbox
	Given Turn off Location Service in Settings Page
	Given Turn on Location for Vantagee
	When Cut page
	When Wait 3 minutes
	Then The Check-box of Schedule Eye Care mode is "nogreyout"
	Then Schedule CheckBox should be in checked 

@DaytimeAndECM
Scenario: VAN7120_TestStep42_Turn on Color temperature and drag slider and take screen
	Given Go to display page
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	Then Take Screen Shot  VAN7120_TestStep42ScreenColor in 7120 under ScreenShotResult