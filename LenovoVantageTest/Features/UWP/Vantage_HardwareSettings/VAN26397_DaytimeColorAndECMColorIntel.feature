Feature: VAN26397_DaytimeColorAndECMColorIntel
	Test Case： https://jira.tc.lenovo.com/browse/VAN-26397
	Author： DaQi Fang

Background: 
	Given New "Intel" API is supported

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep00_Open Location
	Given Turn on Location for Vantagee

@IntelDaytimeAndECM 
Scenario: VAN26397_TestStep01_The Daytime feature Slider default value should be OOBE
	Given Install Vantage
	Given Go to display page
	Then The "DayTimeFeature" slider default "Temp_Display" Regedit "6500" Ui "6500K"
	Then The "ECMFeature" slider default "Temp_UserSet" Regedit "4500" Ui "4500K"
	Then The ECM feature toggle button default value should be off
	Then Schedule CheckBox should be in unchecked 

@IntelDaytimeAndECM @SmokeIntelDaytimeAndECM
Scenario: VAN26397_TestStep02_Drag Temp_Display the computer temperature will change to Tn
	Given Go to display page
	Given Drug the "Temp_Display" slider bar 200 
	Given The Temp_Display is not same with Temp_UserSet "Temp_Display"
	Then The computer temperature will change to Tn
	Then Reset Daytime and ECM

@IntelDaytimeAndECM-Hibernate
Scenario: VAN26397_TestStep03_Turn Off Color temperature Drag the Daytime color temperature slider to a new value and hibernate
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	Given The Temp_Display is not same with Temp_UserSet "Temp_Display"
	Given wait 1 seconds
	Given Close Vantage
	When enter hibernate
	When Wait 5 minutes
	Then The LenovoVisionProtectionPlugin is live
	Given Launch Vantage
	Given Go to display page
	Then The new value will keep in Tn
	Then The computer temperature will change to Tn
	Given Close Vantage
	When Enter sleep
	When Wait 5 minutes
	Then The LenovoVisionProtectionPlugin is live
	Given Launch Vantage
	Given Go to display page
	Then The new value will keep in Tn
	Then The computer temperature will change to Tn
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep05_Turn Off Color temperature Drag the Daytime color temperature slider to a new value and cut page and relaunch
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	When Cut page
	Then The new value will keep in Tn
	When ReLaunch Vantage
	Given Go to display page
	Then The new value will keep in Tn
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep07 Change Dpi
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	Given The Temp_Display is not same with Temp_UserSet "Temp_Display"
	Given wait 1 seconds
	Given Change DPI to max 
	Then The computer temperature will change to Tn
	Then The new value will keep in Tn
	Given Change DPI to recommend
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep08 set tempdisplay slider and turn on color temperature
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	Given The Temp_Display is not same with Temp_UserSet "Temp_Display"
	Given Turn "on" Color temperature
	When wait 3 seconds
	Then Computer temperature same with "UserSet" slider
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep09 
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 200 
	Given The Temp_Display is not same with Temp_UserSet "Temp_UserSet"
	Then The computer temperature will change to Tn
	Then Computer temperature same with "UserSet" slider
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep10 hibernate and check value
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100 
	Given The Temp_Display is not same with Temp_UserSet "Temp_UserSet"
	Given wait 1 seconds
	Given Close Vantage
	When enter hibernate
	When Wait 5 minutes
	Then The LenovoVisionProtectionPlugin is live
	Given Launch Vantage
	Given Go to display page
	Then The ECM slider bar value will keep on T_en 
	Then Computer temperature same with "UserSet" slider
	Given wait 1 seconds
	When Enter sleep
	When Wait 5 minutes
	Then The LenovoVisionProtectionPlugin is live
	Given Launch Vantage
	Given Go to display page
	Then The ECM slider bar value will keep on T_en 
	Then Computer temperature same with "UserSet" slider
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep12_Turn on Color temperature Drag the ECM color temperature slider to a new value and and cut page and relaunch
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

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep14 Temp_Display new value Temp_UserSet new value and change dpi
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 200
	Given The Temp_Display is not same with Temp_UserSet "Temp_UserSet"
	Given wait 1 seconds
	Given Change DPI to max
	Then The ECM slider bar value will keep on T_en 
	Then Computer temperature same with "UserSet" slider
	Given Change DPI to recommend
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep16_Turn on Color temperature Drag the Daytime color temperature slider to a new value twice 
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	Given Turn "on" Color temperature
	Given Drug the "Temp_Display" slider bar 200
	Given The Temp_Display is not same with Temp_UserSet "Temp_UserSet"
	Then The new value will keep in Tn
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep17 doble change Temp_Display and check Computer temperature value
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	Given Turn "on" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	Given The Temp_Display is not same with Temp_UserSet "Temp_Display"
	Then Computer temperature same with "UserSet" slider
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep18_Turn off Color temperature Drag the Daytime color temperature slider to a new value twice 
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	Given Turn "on" Color temperature
	Given Drug the "Temp_Display" slider bar 200
	Given The Temp_Display is not same with Temp_UserSet "Temp_Display"
	Given Turn "off" Color temperature
	Then The new value will keep in Tn
	Then Computer temperature same with "ColorSlider" slider
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep19_Turn off Color temperature The slider-bar of ECM will be grey-out and cannot be set
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	Given Turn "on" Color temperature
	Given Drug the "Temp_Display" slider bar 200
	Given Turn "off" Color temperature
	Then The sliderbar of ECM will be greyout
	Then Take Screen Shot  VAN26397_TestStep19GreySlider in 7120 under SettingscreenShotResult
	Given Drug the "Temp_UserSet" slider bar 100
	Then The ECM slider bar value will keep on T_en
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep20 computer temperature day default
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	When Click "Daytimeslider" Reset button 
	When wait 3 seconds
	Then The computer temperature default is "6500"
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep21_Turn off Color temperature click daytimeslider reset button the value is obbe
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	When Click "Daytimeslider" Reset button 
	Then The "DayTimeFeature" slider default "Temp_Display" Regedit "6500" Ui "6500K"
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep22 computer temperature not change click reset
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100 
	Given Turn "on" Color temperature
	When wait 3 seconds
	Given Get computer temperature value
	When Click "Daytimeslider" Reset button 
	Then The computer temperature is not change
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep23_Turn on Color temperature click daytimeslider reset button the value is obbe
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100
	Given Turn "on" Color temperature
	When Click "Daytimeslider" Reset button 
	Then The "DayTimeFeature" slider default "Temp_Display" Regedit "6500" Ui "6500K"
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep24_Turn off Color temperature drag daytimeslider unstallvantage the color value is obbe
	Given Go to display page
	Given Turn "off" Color temperature
	Given Drug the "Temp_Display" slider bar 100
	Given Uninstall the lenovo vatage
	Then The color temperature will change to OOBE value
	Then The computer temperature default is "6500"

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep25 Temp_UserSet defalut value
	Given Go to display page
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	When Click "ECMslider" Reset button 
	Then The computer temperature default is "4500"
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep26_Turn on Color temperature click the ECM Reset button the value is 4500
	Given Go to display page
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	When Click "ECMslider" Reset button 
	Then The "ECMFeature" slider default "Temp_UserSet" Regedit "4500" Ui "4500K"
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep27 close toggle and click reset the value not change
	Given Go to display page
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	Given Turn "off" Color temperature
	Given Get computer temperature value
	When Click "ECMslider" Reset button 
	Then The computer temperature is not change
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep28_Turn off Color temperature click the ECM Reset button the value is 4500
	Given Go to display page
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	Given Turn "off" Color temperature
	When Click "ECMslider" Reset button 
	Then The "ECMFeature" slider default "Temp_UserSet" Regedit "4500" Ui "4500K"
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep29
	Given Go to display page
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	Given The Temp_Display is not same with Temp_UserSet "Temp_UserSet"
	Given Turn "off" Color temperature
	Given "unchecked" the Eye care Mode checkbox
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Then The ECM toggle will change to on
	Then ECM slider will change to can be set
	Then Computer temperature same with "UserSet" slider
	Given Set Time to "Sync"
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep30_Cut time to sunset and check the ECMcheckbox and slider
	Given Go to display page
	Given Turn "off" Color temperature
	Given "unchecked" the Eye care Mode checkbox
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Then The ECM toggle will change to on
	Then ECM slider will change to can be set

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep31
	Given Go to display page
	Given Turn "on" Color temperature
	Given wait 1 seconds
	Given Drug the "Temp_UserSet" slider bar 100
	Given The Temp_Display is not same with Temp_UserSet "Temp_UserSet"
	Given Turn "off" Color temperature
	Given "unchecked" the Eye care Mode checkbox
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunrise"
	Then The ECM feature toggle button default value should be off
	Then The sliderbar of ECM will be greyout
	Then Computer temperature same with "ColorSlider" slider
	Given Set Time to "Sync"
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep32_Cut time to sunrise and check the ECMcheckbox and slider
	Given Go to display page
	Given Turn "off" Color temperature
	Given "unchecked" the Eye care Mode checkbox
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunrise"
	Then The ECM feature toggle button default value should be off
	Then The sliderbar of ECM will be greyout
	Given Set Time to "Sync"

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep33
	Given Go to display page
	Given Turn "on" Color temperature
	Given wait 1 seconds
	Given Drug the "Temp_UserSet" slider bar 100
	Given The Temp_Display is not same with Temp_UserSet "Temp_UserSet"
	Given Turn "off" Color temperature
	Given "unchecked" the Eye care Mode checkbox
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Then The ECM toggle will change to on
	Then ECM slider will change to can be set
	Given Turn "off" Color temperature
	Then The sliderbar of ECM will be greyout
	Then Computer temperature same with "ColorSlider" slider
	When Wait 5 minutes
	Then The ECM feature toggle button default value should be off
	Then The sliderbar of ECM will be greyout
	Then Computer temperature same with "ColorSlider" slider
	Given Set Time to "sunset"
	Then The ECM toggle will change to on
	Then ECM slider will change to can be set
	Then Computer temperature same with "UserSet" slider
	Given Set Time to "Sync"
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep34
	Given Go to display page
	Given Turn "on" Color temperature
	Given wait 1 seconds
	Given Drug the "Temp_UserSet" slider bar 100
	Given The Temp_Display is not same with Temp_UserSet "Temp_UserSet"
	Given "unchecked" the Eye care Mode checkbox
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunrise"
	Then The ECM toggle will change to on
	Then ECM slider will change to can be set
	When Wait 1 minutes
	Then Computer temperature same with "UserSet" slider
	Given Set Time to "Sync"
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep35
	Given Go to display page
	Given "checked" the Eye care Mode checkbox
	Given Turn "on" Color temperature
	Then The Eye care Mode checkbox is "checked"
	Given Turn "off" Color temperature
	Then The Eye care Mode checkbox is "checked"
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep39
	Given Go to display page
	Given "checked" the Eye care Mode checkbox
	Given Turn "off" Color temperature
	Given Set Time to "sunset"
	Given Uninstall the lenovo vatage
	Given wait 2 seconds
	Then The computer temperature default is "6500"
	Given Install Vantage
	Given Go to display page
	Then The Eye care Mode checkbox is "unchecked"
	Given Set Time to "Sync"

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep40_Turn off location and check the Schedule checkbox
	Given Go to display page
	Given Turn "off" Color temperature
	Given Turn on Location for Vantagee
	Given "checked" the Eye care Mode checkbox
	Given Turn off Location Service in Settings Page
	When Cut page
	When Wait 1 minutes
	Then The Check-box of Schedule Eye Care mode is "greyout"
	Then Schedule CheckBox should be in checked 

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep41_Turn on location and check the Schedule checkbox
	Given Go to display page
	Given Turn "off" Color temperature
	Given Turn on Location for Vantagee
	Given "checked" the Eye care Mode checkbox
	Given Turn off Location Service in Settings Page
	Given Turn on Location for Vantagee
	When Cut page
	When Wait 1 minutes
	Then The Check-box of Schedule Eye Care mode is "nogreyout"
	Then Schedule CheckBox should be in checked 

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep42_Turn on Color temperature and drag slider and take screen
	Given Go to display page
	Given Turn "on" Color temperature
	Given Drug the "Temp_UserSet" slider bar 100
	Then Take Screen Shot  VAN26397_TestStep42ScreenColor in 26397 under ScreenShotResult
	Then Reset Daytime and ECM

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep45_46
	Given Go to display page
	Given Drug the "Temp_Display" slider bar 100
	Given Set 'Intel(R) UHD Graphics' drive state to enable or disable 'disable' via HardwareId 'default'
	Given wait 30 seconds
	Given Click DisplayLink
	Then Take Screen Shot  VAN26397_TestStep45ScreenColor in 26397 under ScreenShotResult
	Given Launch Vantage
	Given Go to display page
	Given Click DisplayLink
	Then Take Screen Shot  VAN26397_TestStep45_01RelaunchScreenColor in 26397 under ScreenShotResult
	When into Dashboard page
	Given Go to display page
	Given Click DisplayLink
	Then Take Screen Shot  VAN26397_TestStep45_02SwitchpageScreenColor in 26397 under ScreenShotResult
	Given Set 'Intel(R) UHD Graphics' drive state to enable or disable 'enable' via HardwareId 'default'

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep47
	Given Go to display page
	Given Drug the "Temp_Display" slider bar 100
	Given The Temp_Display is not same with Temp_UserSet "Temp_Display"
	Given Set 'Intel(R) UHD Graphics' drive state to enable or disable 'disable' via HardwareId 'default'
	Given wait 10 seconds
	Given Set 'Intel(R) UHD Graphics' drive state to enable or disable 'enable' via HardwareId 'default'
	Given wait 30 seconds
	Then The ECM ui should be clickable 
	Then The new value will keep in Tn
	Then The computer temperature will change to Tn
	Given Launch Vantage
	Given Go to display page
	Then The ECM ui should be clickable 
	Then The new value will keep in Tn
	Then The computer temperature will change to Tn
	When into Dashboard page
	Given Go to display page
	Then The ECM ui should be clickable 
	Then The new value will keep in Tn
	Then The computer temperature will change to Tn

@IntelDaytimeAndECM
Scenario: VAN26397_TestStep51
	Given Turn on Location for Vantagee
	Given Go to display page
	Then Sunset and Sunrise time "display"
	Given Turn off Location Service in Settings Page
	Given into Dashboard page
	Given Go to display page
	Then Sunset and Sunrise time "hidden"
	Given Turn on Location for Vantagee