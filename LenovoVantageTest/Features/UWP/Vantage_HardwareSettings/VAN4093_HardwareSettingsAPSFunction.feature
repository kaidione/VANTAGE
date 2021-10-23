Feature: VAN4093_VFC178_HardwareSettingsAPSFunction
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-4093
	Author： Chenpj5

@APS 
Scenario: VAN4093_TestStep01_Check APS View in Control Panel
	Given The machine support or not support APS 'support'
	Given Go to Smart Assist page
	Given Go to APS section via jump link
	Given The 'APS' function is enable or disable 'enable'
	Given The 'ManualSuspension' function is enable or disable 'enable'
	When Select APS suspend time '30 seconds'
	Given View Control Panel via 'small' type
	Then The APS can 'show' in Control panal and the name is 'Lenovo - Airbag Protection'
	Then Take Screen Shot VAN4093_TestStep01 in 4093 under HSScreenShotResult

@APS
Scenario: VAN4093_TestStep03_04_Check APS features should be greyed out and the ADVANCED SETTINGS link should disappear
	Given The machine support or not support APS 'support'
	Given Go to Smart Assist page
	Given Go to APS section via jump link
	Given The 'APS' function is enable or disable 'enable'
	Given The 'ManualSuspension' function is enable or disable 'enable'
	Given The 'APS' function is enable or disable 'disable'
	Then The APS features should be greyed out and the ADVANCED SETTINGS link should disappear

@APS
Scenario: VAN4093_TestStep04_Check APS features should be greyed out and the ADVANCED SETTINGS link should disappear
	When Only Print 'Please check TestStep03'

@APS
Scenario: VAN4093_TestStep05_Check Keep the computer stand still then the APS status should be RUNNING
	Given The machine support or not support APS 'support'
	Given Go to Smart Assist page
	Given Go to APS section via jump link
	Given The 'APS' function is enable or disable 'enable'
	Given Launch APS App
	Given Waiting 30 seconds
	Then The APS Real-time status is correct 'No shock detected; Hard drive running'
	Then Take Screen Shot VAN4093_TestStep05 in 4093 under HSScreenShotResult

@APS
Scenario: VAN4093_TestStep13_Check APS features set suspend time 30 seconds and the The Real-time status is SNOOZE
	Given The machine support or not support APS 'support'
	Given Go to Smart Assist page
	Given Go to APS section via jump link
	Given The 'APS' function is enable or disable 'enable'
	Given The 'ManualSuspension' function is enable or disable 'enable'
	When Select APS suspend time '30 seconds'
	When Click APS suspend button
	Given Launch APS App
	Given Waiting 2 seconds
	Then The APS Real-time status is correct 'Manually suspended [0.5 min]; Hard drive running'
	Then Take Screen Shot VAN4093_TestStep13 in 4093 under HSScreenShotResult

@APS
Scenario: VAN4093_TestStep16_Check APS features set suspend time 30 seconds and wait 35 seconds then The Real-time status is RUNNING
	Given The machine support or not support APS 'support'
	Given Go to Smart Assist page
	Given Go to APS section via jump link
	Given The 'APS' function is enable or disable 'enable'
	Given The 'ManualSuspension' function is enable or disable 'enable'
	When Select APS suspend time '30 seconds'
	When Click APS suspend button
	Given Launch APS App
	Given Waiting 32 seconds
	Then The APS Real-time status is correct 'No shock detected; Hard drive running'
	Then Take Screen Shot VAN4093_TestStep16 in 4093 under HSScreenShotResult

@APS @SmokeAPS
Scenario: VAN4093_TestStep17_Check APS features set suspend time 1 min and check Real-time status
	Given The machine support or not support APS 'support'
	Given Go to Smart Assist page
	Given Go to APS section via jump link
	Given The 'APS' function is enable or disable 'enable'
	Given The 'ManualSuspension' function is enable or disable 'enable'
	When Select APS suspend time '1 minute'
	When Click APS suspend button
	Given Launch APS App
	Given Waiting 30 seconds
	Then The APS Real-time status is correct 'Manually suspended [1 min]; Hard drive running'
	Then Take Screen Shot VAN4093_TestStep17Before in 4093 under HSScreenShotResult
	Given Waiting 32 seconds
	Then The APS Real-time status is correct 'No shock detected; Hard drive running'
	Then Take Screen Shot VAN4093_TestStep17After in 4093 under HSScreenShotResult

@APS
Scenario: VAN4093_TestStep18_Check APS features set suspend time 2 mins and check Real-time status
	Given The machine support or not support APS 'support'
	Given Go to Smart Assist page
	Given Go to APS section via jump link
	Given The 'APS' function is enable or disable 'enable'
	Given The 'ManualSuspension' function is enable or disable 'enable'
	When Select APS suspend time '2 minutes'
	When Click APS suspend button
	Given Launch APS App
	Given Waiting 60 seconds
	Then The APS Real-time status is correct 'Manually suspended [2 mins]; Hard drive running'
	Then Take Screen Shot VAN4093_TestStep18Before in 4093 under HSScreenShotResult
	Given Waiting 62 seconds
	Then The APS Real-time status is correct 'No shock detected; Hard drive running'
	Then Take Screen Shot VAN4093_TestStep18After in 4093 under HSScreenShotResult

@APS
Scenario: VAN4093_TestStep19_Check APS features set suspend time 3 mins and check Real-time status
	Given The machine support or not support APS 'support'
	Given Go to Smart Assist page
	Given Go to APS section via jump link
	Given The 'APS' function is enable or disable 'enable'
	Given The 'ManualSuspension' function is enable or disable 'enable'
	When Select APS suspend time '3 minutes'
	When Click APS suspend button
	Given Launch APS App
	Given Waiting 90 seconds
	Then The APS Real-time status is correct 'Manually suspended [3 mins]; Hard drive running'
	Then Take Screen Shot VAN4093_TestStep19Before in 4093 under HSScreenShotResult
	Given Waiting 92 seconds
	Then The APS Real-time status is correct 'No shock detected; Hard drive running'
	Then Take Screen Shot VAN4093_TestStep19After in 4093 under HSScreenShotResult

@APS
Scenario: VAN4093_TestStep21_Check APS features disable manual suspension function and Manual Suspension function will be hidden
	Given The machine support or not support APS 'support'
	Given Go to Smart Assist page
	Given Go to APS section via jump link
	Given The 'APS' function is enable or disable 'enable'
	Given The 'ManualSuspension' function is enable or disable 'disable'
	Then The APS Manual Suspension function will be hidden or shown 'hidden'

@ThinkAPS
Scenario: VAN4093_TestStep24_Check the lenovo Airbag Protection icon will be displayed for think machine
	Given The machine support or not support APS 'support'
	Given Go to Smart Assist page
	Given Go to APS section via jump link
	Given View Control Panel via 'small' type
	Then The APS can 'show' in Control panal and the name is 'Lenovo - Airbag Protection'
	Then Take Screen Shot VAN4093_TestStep24 in 4093 under HSScreenShotResult

@IdeaAPS
Scenario: VAN4093_TestStep25_Check the lenovo Airbag Protection icon will not be displayed for idea machine
	Given The machine support or not support APS 'support'
	Given Go to Smart Assist page
	Given Go to APS section via jump link
	Given View Control Panel via 'small' type
	Then The APS can 'hide' in Control panal and the name is 'Lenovo - Airbag Protection'
	Then Take Screen Shot VAN4093_TestStep25 in 4093 under HSScreenShotResult