Feature: VAN7714_ScheduleEyeCareModeAndAccessToLocation
	Test Case： https://jira.tc.lenovo.com/browse/VAN-7714
	Author： Daqi Fang

Background: 
	Given New "Intel" API is supported

@ECMAndLocationIntel
Scenario: VAN7714_TestStep01
	Given turn on the Allow apps to access your Location
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Launch vantage without OOBE
	Given ECM Low OS Click Micro Pop and OOBE
	Given Go to Display & Camera page
	Given The Location PopUp Window is "show"
	Then Sunset and Sunrise time "hidden"
	Then Take Screen Shot VAN7714_Step01 in 7714 under SettingsScreenShotResult

@ECMAndLocationIntel
Scenario: VAN7714_TestStep02
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Launch vantage without OOBE
	Given ECM Low OS Click Micro Pop and OOBE
	Given Go to Display & Camera page
	Given The Location PopUp Window is "show"
	Given Click ECM Location PopUp "Yes" button
	When Cut page
	Then Sunset and Sunrise time "display"

@ECMAndLocationIntel
Scenario: VAN7714_TestStep03
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Launch vantage without OOBE
	Given ECM Low OS Click Micro Pop and OOBE
	Given Go to Display & Camera page
	Given The Location PopUp Window is "show"
	Given Click ECM Location PopUp "No" button
	When Cut page
	Then Sunset and Sunrise time "hidden"

@ECMAndLocationIntel
Scenario: VAN7714_TestStep04
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Launch vantage without OOBE
	Given ECM Low OS Click Micro Pop and OOBE
	Given Go to Display & Camera page
	Given Click ECM Location PopUp "No" button
	When Cut page
	Then Sunset and Sunrise time "hidden"
	Given Disable or Enable Vantage Location Permission 'Enable'
	When Cut page
	Then Sunset and Sunrise time "display"

@ECMAndLocationIntel
Scenario: VAN7714_TestStep05
	Given Go to Display & Camera page
	Given Turn "off" Color temperature
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Then The computer temperature default is "4500"
	Given Set Time to "Sync"

@ECMAndLocationIntel
Scenario: VAN7714_TestStep06
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Launch vantage without OOBE
	Given ECM Low OS Click Micro Pop and OOBE
	Given Go to Display & Camera page
	Given Click ECM Location PopUp "No" button
	When Cut page
	Then Sunset and Sunrise time "hidden"
	Given Disable or Enable Vantage Location Permission 'Enable'
	When Cut page
	Then Sunset and Sunrise time "display"
	Given Go to Display & Camera page
	Given "unchecked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Given "checked" the Eye care Mode checkbox
	Given wait 10 seconds
	Then The computer temperature default is "4500"
	Given Set Time to "Sync"

@ECMAndLocationIntel
Scenario: VAN7714_TestStep07
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Launch vantage without OOBE
	Given ECM Low OS Click Micro Pop and OOBE
	Given Go to Display & Camera page
	Given Click ECM Location PopUp "No" button
	When Cut page
	Then Sunset and Sunrise time "hidden"
	Given Disable or Enable Vantage Location Permission 'Enable'
	When Cut page
	Then Sunset and Sunrise time "display"
	Then Reset Daytime and ECM
	Given Go to Display & Camera page
	Given Turn "off" Color temperature
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Then The ECM toggle will change to on
	Then The "ECMFeature" slider default "Temp_UserSet" Regedit "4500" Ui "4500K"
	Then Computer temperature same with "UserSet" slider
	Given Set Time to "Sync"

@ECMAndLocationIntel
Scenario: VAN7714_TestStep08
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given Launch vantage without OOBE
	Given ECM Low OS Click Micro Pop and OOBE
	Given Go to Display & Camera page
	Given Click ECM Location PopUp "No" button
	When Cut page
	Then Sunset and Sunrise time "hidden"
	Given Disable or Enable Vantage Location Permission 'Enable'
	When Cut page
	Then Sunset and Sunrise time "display"
	Then Reset Daytime and ECM
	Given Go to Display & Camera page
	Given Turn "off" Color temperature
	Given Set Time to "sunset"
	Given "checked" the Eye care Mode checkbox
	Then The ECM toggle will change to on
	Then The "ECMFeature" slider default "Temp_UserSet" Regedit "4500" Ui "4500K"
	Then Computer temperature same with "UserSet" slider
	Given Set Time to "Sync"

@ECMAndLocationIntel
Scenario: VAN7714_TestStep09
	Given Uninstall the lenovo vatage
	When Wait 1 minutes
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given turn off the Allow apps to access your Location
	Given Launch vantage without OOBE
	Given ECM Low OS Click Micro Pop and OOBE
	Given Go to Display & Camera page
	Given The Camera PopUp Window is "show"
	Given wait 120 seconds
	Given The Location PopUp Window is "noshow"

@ECMAndLocationIntel
Scenario: VAN7714_TestStep10
	Given Uninstall the lenovo vatage
	When Wait 1 minutes
	Given Install the Lenovo Vantage Without Launch Vantage	
	Given turn off the Allow apps to access your Location
	Given Launch vantage without OOBE
	Given ECM Low OS Click Micro Pop and OOBE
	Given Go to Display & Camera page
	Given The Camera PopUp Window is "show"
	When Cut page
	Then Sunset and Sunrise time "hidden"

@ECMAndLocationIntel
Scenario: VAN7714_TestStep11
	Given turn off the Allow apps to access your Location
	Given Go to Display & Camera page
	Given turn on the Allow apps to access your Location
	Given Disable or Enable Vantage Location Permission 'Enable'
	When Cut page
	Then Sunset and Sunrise time "display"
	Given ReLaunch Vantage
	Given Go to Display & Camera page
	Then Sunset and Sunrise time "display"

@ECMAndLocationIntel
Scenario: VAN7714_TestStep12
	Given turn off the Allow apps to access your Location
	Given Go to Display & Camera page
	Given turn on the Allow apps to access your Location
	Given Disable or Enable Vantage Location Permission 'Enable'
	When Cut page
	Given Turn "off" Color temperature
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Then The computer temperature default is "4500"
	Given Set Time to "Sync"
	Then Reset Daytime and ECM

@ECMAndLocationIntel
Scenario: VAN7714_TestStep13
	Given turn off the Allow apps to access your Location
	Given Go to Display & Camera page
	Given turn on the Allow apps to access your Location
	Given Disable or Enable Vantage Location Permission 'Enable'
	When Cut page
	Given Turn "off" Color temperature
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Then The ECM toggle will change to on
	Then The "ECMFeature" slider default "Temp_UserSet" Regedit "4500" Ui "4500K"

@ECMAndLocationIntel
Scenario: VAN7714_TestStep14
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given turn on the Allow apps to access your Location
	Given Launch vantage without OOBE
	Given ECM Low OS Click Micro Pop and OOBE
	Given Go to Display & Camera page
	Given The Location PopUp Window is "show"
	Given Click ECM Location PopUp "Yes" button
	When Cut page
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Then The computer temperature default is "4500"
	Given Disable or Enable Vantage Location Permission 'Disable'
	Then Sunset and Sunrise time "display"
	Given Set Time to "Sync"

@ECMAndLocationIntel
Scenario: VAN7714_TestStep15
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given turn on the Allow apps to access your Location
	Given Launch vantage without OOBE
	Given ECM Low OS Click Micro Pop and OOBE
	Given Go to Display & Camera page
	Given The Location PopUp Window is "show"
	Given Click ECM Location PopUp "Yes" button
	When Cut page
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Then The computer temperature default is "4500"
	Given Disable or Enable Vantage Location Permission 'Disable'
	When Cut page
	When Cut page
	Then Sunset and Sunrise time "hidden"
	Given Set Time to "Sync"

@ECMAndLocationIntel
Scenario: VAN7714_TestStep16
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given turn on the Allow apps to access your Location
	Given Launch vantage without OOBE
	Given ECM Low OS Click Micro Pop and OOBE
	Given Go to Display & Camera page
	Given The Location PopUp Window is "show"
	Given Click ECM Location PopUp "Yes" button
	When Cut page
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Given Get computer temperature value
	Then The computer temperature default is "4500"
	Given Disable or Enable Vantage Location Permission 'Disable'
	When Cut page
	Then The computer temperature is not change
	Then Computer temperature same with "UserSet" slider
	Given Set Time to "Sync"

@ECMAndLocationIntel
Scenario: VAN7714_TestStep17
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given turn on the Allow apps to access your Location
	Given Launch vantage without OOBE
	Given ECM Low OS Click Micro Pop and OOBE
	Given Go to Display & Camera page
	Given The Location PopUp Window is "show"
	Given Click ECM Location PopUp "Yes" button
	When Cut page
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Given Get computer temperature value
	Then The computer temperature default is "4500"
	Given Disable or Enable Vantage Location Permission 'Disable'
	When Cut page
	Given Set Time to "sunrise"
	Then Computer temperature same with "ColorSlider" slider
	Given Set Time to "Sync"

@ECMAndLocationIntel
Scenario: VAN7714_TestStep18
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given turn on the Allow apps to access your Location
	Given Launch vantage without OOBE
	Given ECM Low OS Click Micro Pop and OOBE
	Given Go to Display & Camera page
	Given The Location PopUp Window is "show"
	Given Click ECM Location PopUp "Yes" button
	When Cut page
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Given Get computer temperature value
	Then The computer temperature default is "4500"
	Given Disable or Enable Vantage Location Permission 'Disable'
	When Cut page
	Given Set Time to "sunrise"
	Then Computer temperature same with "ColorSlider" slider
	Given Set Time to "sunset"
	Then Computer temperature same with "ColorSlider" slider
	Given Set Time to "Sync"

@ECMAndLocationIntelS3S4
Scenario: VAN7714_TestStep19
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given turn on the Allow apps to access your Location
	Given Launch vantage without OOBE
	Given ECM Low OS Click Micro Pop and OOBE
	Given Go to Display & Camera page
	Given The Location PopUp Window is "show"
	Given Click ECM Location PopUp "Yes" button
	When Cut page
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Given Get computer temperature value
	Then The computer temperature default is "4500"
	Given Disable or Enable Vantage Location Permission 'Disable'
	When Enter hibernate
	Then Sunset and Sunrise time "hidden"
	Given Set Time to "Sync"

@ECMAndLocationIntelS3S4
Scenario: VAN7714_TestStep20
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given turn on the Allow apps to access your Location
	Given Launch vantage without OOBE
	Given ECM Low OS Click Micro Pop and OOBE
	Given Go to Display & Camera page
	Given The Location PopUp Window is "show"
	Given Click ECM Location PopUp "Yes" button
	When Cut page
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Given Get computer temperature value
	Then The computer temperature default is "4500"
	Given Disable or Enable Vantage Location Permission 'Disable'
	When Enter hibernate
	Then Computer temperature same with "ColorSlider" slider
	Given Set Time to "Sync"

@ECMAndLocationIntel
Scenario: VAN7714_TestStep21
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given turn on the Allow apps to access your Location
	Given Launch vantage without OOBE
	Given ECM Low OS Click Micro Pop and OOBE
	Given Go to Display & Camera page
	Given The Location PopUp Window is "show"
	Given Click ECM Location PopUp "Yes" button
	When Cut page
	Given Set Time to "sunrise"
	Given "checked" the Eye care Mode checkbox
	Given Disable or Enable Vantage Location Permission 'Disable'
	Given Set Time to "sunset"
	Then Computer temperature same with "ColorSlider" slider
	Given Set Time to "Sync"

@ECMAndLocationIntel
Scenario: VAN7714_TestStep22
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given turn on the Allow apps to access your Location
	Given Launch vantage without OOBE
	Given ECM Low OS Click Micro Pop and OOBE
	Given Go to Display & Camera page
	Given The Location PopUp Window is "show"
	Given Click ECM Location PopUp "Yes" button
	When Cut page
	Given Set Time to "sunrise"
	Given "checked" the Eye care Mode checkbox
	Given Disable or Enable Vantage Location Permission 'Disable'
	Given Set Time to "sunset"
	Then Computer temperature same with "ColorSlider" slider
	Given Restart IMC service
	Then Computer temperature same with "ColorSlider" slider
	Given Set Time to "Sync"

@ECMAndLocationIntel
Scenario: VAN7714_TestStep23
	Given Reset Vantage
	When Change Vantage Service 'default'
	Given turn on the Allow apps to access your Location
	Given Launch vantage without OOBE
	Given ECM Low OS Click Micro Pop and OOBE
	Given Go to Display & Camera page
	Given The Location PopUp Window is "show"
	Given Click ECM Location PopUp "Yes" button
	When Cut page
	Given "checked" the Eye care Mode checkbox
	Given Set Time to "sunset"
	Given Get computer temperature value
	Then The computer temperature default is "4500"
	Given Disable or Enable Vantage Location Permission 'Disable'
	When Cut page
	Given Set Time to "sunrise"
	Given Set Time to "sunset"
	Then Computer temperature same with "ColorSlider" slider
	Given Disable or Enable Vantage Location Permission 'Enable'
	When Cut page
	Then ECM Display title and link is "hidden"
	Then Computer temperature same with "UserSet" slider