Feature: VAN17771_HardwareSettingsHPD
	Test Case： https://jira.tc.lenovo.com/browse/VAN-17771
	JIRA Task: https://jira.tc.lenovo.com/browse/HAIDIAN-1186
	Author： DuanXuWen
	Updater: Jiajt

@HardwareSettingsHPD
Scenario: VAN17771_TestStep17 Check HPD Reset Button
    Given Check HPD Reset Button Whether it exists
	And Check ZT Login switch button is on
	And Check ZT Login ADV ADSA switch button is off
	And Check ZT Login switch button is off
	When wait 2 seconds
	When Click HPD Reset Button
	When wait 5 seconds
	Then Check ZT Login switch button and ADSA switch button is on

@HardwareSettingsHPD
Scenario: VAN17771_TestStep28 Check HPD Reset Button
    Given Check HPD Reset Button Whether it exists
	And Check ZT Login switch button is on
	And Check ZT Login ADV ADSA switch button is off
	And Click ZT Login ADV ADSA slider bar to "Near"
	When wait 2 seconds
	When Click HPD Reset Button
	When wait 5 seconds
	Then Check ZT Login ADV ADSA slider bar Is it consistent with the driving state
	Given Check HPD Reset Button Whether it exists
	And Check ZT Login switch button is on
	And Check ZT Login ADV ADSA switch button is off
	And Click ZT Login ADV ADSA slider bar to "Far"
	When wait 2 seconds
	When Click HPD Reset Button
	When wait 5 seconds
	Then Check ZT Login ADV ADSA slider bar Is it consistent with the driving state

@HardwareSettingsHPD
Scenario: VAN17771_TestStep74 Check HPD Reset Button
    Given Check HPD Reset Button Whether it exists
	And Check Zero Touch Lock switch button is on
	And Click Zero Touch Lock ADV Settings Link
	And Click Auto Screen Lock Timer "Fast"
	And Click Zero Touch Lock Facial Recogoition Checkbox
	And Click Zero Touch Lock ADSA switch button is "off"
	And ClicK Zero Touch Lock ADSA SldierBar to "Near"
	When wait 2 seconds
	When Click HPD Reset Button
	When wait 5 seconds
	Then Check Zero Touch Lock Facial Recogoition Checkbox is not select and Auto Screen Lock UI SldierBar Is it consistent with the driving state
	Given Check HPD Reset Button Whether it exists
	And Check Zero Touch Lock switch button is on
	And Click Zero Touch Lock ADV Settings Link
	And Click Auto Screen Lock Timer "Medium"
	And Click Zero Touch Lock Facial Recogoition Checkbox
	And Click Zero Touch Lock ADSA switch button is "off"
	And ClicK Zero Touch Lock ADSA SldierBar to "Middle"
	When wait 2 seconds
	When Click HPD Reset Button
	When wait 5 seconds
	Then Check Zero Touch Lock Facial Recogoition Checkbox is not select and Auto Screen Lock UI SldierBar Is it consistent with the driving state
	Given Check HPD Reset Button Whether it exists
	And Check Zero Touch Lock switch button is on
	And Click Zero Touch Lock ADV Settings Link
	And Click Auto Screen Lock Timer "Slow"
	And Click Zero Touch Lock Facial Recogoition Checkbox
	And Click Zero Touch Lock ADSA switch button is "off"
	And ClicK Zero Touch Lock ADSA SldierBar to "Far"
	When wait 2 seconds
	When Click HPD Reset Button
	When wait 5 seconds
	Then Check Zero Touch Lock Facial Recogoition Checkbox is not select and Auto Screen Lock UI SldierBar Is it consistent with the driving state

@HardwareSettingsHPD
Scenario: VAN17771_TestStep129 Check HPD head Image and Text above image
    Given Go to Smart Assist page
	When Check HPD head Does the image exist
	Then The image is under on the reset button
	Then Check HPD head Text above image is "Intelligent sensing" and "Buckles up your PC with intelligent sensing technology, protects your privacy, and saves your battery power."

@HardwareSettingsHPD
Scenario: VAN17771_TestStep130 Check Zero Touch Login section icon and header and toggle and description 
    Given Go to Smart Assist page
	When Check Zero Touch Login section icon and header text "Zero touch login" and toggle
	Then Check Zero Touch Login section description Text "This feature enables you to improve the work efficiency by automatically waking up or logging in your computer. To use the feature, you need to register your face in Windows Hello."
	Then Take Screen Shot 130ld in 17771 under HardwareSettingsHPD

@HardwareSettingsHPD
Scenario: VAN17771_TestStep131  Click on the HPD Zero Touch Login question mark.check tip text
    Given Go to Smart Assist page
	And Click HPD Zero Touch Login question mark icon
	Then Check HPD Zero Touch Login question mark text is "When you are in front of your computer or approaching it (within 1.2 or 1.5 meters), this feature enables you to automatically log in to the system after your face is recognized. If you are in outdoor rather than the office, you need to be closer to your computer and the wakeup will take longer. <br>Depending on the sensor capability, the maximum detecting distance varies. Refer to the User Guide that comes with your computer for details."

@HardwareSettingsHPD
Scenario: VAN17771_TestStep133 off the Zero Touch Login toggle section should gray out
    Given Go to Smart Assist page
	And Check ZT Login switch button is off
	When Click HPD Zero Touch Login ADV Settings Link "ADVANCED SETTINGS"
	Then Check ZT Login ADV Settings ADSA is gray out

@HardwareSettingsHPD
Scenario: VAN17771_TestStep134 Click Zero Touch Login ADVANCED SETTINGS link show ADSA section
    Given Go to Smart Assist page
	When Click HPD Zero Touch Login ADV Settings Link "ADVANCED SETTINGS"
	Then Check Zero Touch Login ADV Settings ADSA section is show

@HardwareSettingsHPD
Scenario: VAN17771_TestStep135 Click Zero Touch Login ADVANCED SETTINGS link text change to HIDE ADVANCED SETTINGS 
    Given Go to Smart Assist page
	When Click HPD Zero Touch Login ADV Settings Link "ADVANCED SETTINGS"
	Then Check Zero Touch Login ADV Settings link text is "HIDE ADVANCED SETTINGS"

@HardwareSettingsHPD
Scenario: VAN17771_TestStep136 Click Zero Touch Login HIDE ADVANCED SETTINGS link fold ADSA section 
    Given Go to Smart Assist page
	When Click HPD Zero Touch Login ADV Settings Link "ADVANCED SETTINGS"
	When Click HPD Zero Touch Login ADV Settings Link "HIDE ADVANCED SETTINGS"
	Then Check Zero Touch Login ADV Settings ADSA section is fold

@HardwareSettingsHPD
Scenario: VAN17771_TestStep137 Switch to other pages and return Zero Touch Login ADSA section extend/collapsed state should keep
    Given Go to Smart Assist page
	When Click HPD Zero Touch Login ADV Settings Link "ADVANCED SETTINGS"
	Given Go to My Device Settings page
	And Go to Smart Assist page
	Then Check Zero Touch Login ADV Settings ADSA section is show
    Given Go to Smart Assist page
	When Click HPD Zero Touch Login ADV Settings Link "HIDE ADVANCED SETTINGS"
	Given Go to My Device Settings page
	And Go to Smart Assist page
	Then Check Zero Touch Login ADV Settings ADSA section is fold

@HardwareSettingsHPD
Scenario: VAN17771_TestStep138 Relaunch vantage back to Smart Assist page  ZT Login ADV ADSA In folded state
    Given Go to Smart Assist page
	When Click HPD Zero Touch Login ADV Settings Link "ADVANCED SETTINGS"
	Given close lenovo vantage
	Given ReLaunch Lenovo Vantage
	Given Go to Smart Assist page
	Then Check Zero Touch Login ADV Settings ADSA section is fold

@HardwareSettingsHPD
Scenario: VAN17771_TestStep139 Check The Zero Touch Login ADV Settings ADSA UI
    Given Go to Smart Assist page
	And Check ZT Login switch button is on
	When Click HPD Zero Touch Login ADV Settings Link "ADVANCED SETTINGS"
	And Check Zero Touch Login ADV Settings ADSA Title is "AUTO DISTANCE SENSITIVITY ADJUSTING"
	Then Check Zero Touch Login ADV Settings ADSA On  Description is "Enable this feature to automatically adjust the detecting distance of movements to wake up the system. Turn it off to manually adjust the detecting sensitivity based on your preference."

@HardwareSettingsHPD
Scenario: VAN17771_TestStep142 Check The Zero Touch Login ADV Settings ADSA UI
    Given Go to Smart Assist page
	And Check ZT Login switch button is on
	When Click HPD Zero Touch Login ADV Settings Link "ADVANCED SETTINGS"
	And Check Zero Touch Login ADV Settings ADSA Title is "AUTO DISTANCE SENSITIVITY ADJUSTING"
	Then Check Zero Touch Login ADV Settings (new sensor) ADSA Off Description is "When this feature is disabled, you need to manually adjust the sensitivity bar to adjust the detecting distance. If you want the distance to be adjusted automatically, turn it on." and "There are three options. In each range, when human movements are detected, your screen will be waked up accordingly." and "• Near: 0.2-0.55 meter" and "• Middle: 0.2-1.0 meter" and "• Far: 0.2-1.5 meter"
	Then Check Zero Touch Login ADV Settings (old sensor) ADSA Off Description is "When this feature is disabled, you need to manually adjust the sensitivity bar to adjust the detecting distance. If you want the distance to be adjusted automatically, turn it on." and "There are three options. In each range, when human movements are detected, your screen will be waked up accordingly." and "• Near: 0.2-0.4 meter" and "• Middle: 0.2-0.6 meter" and "• Far: 0.2-1.2 meter"

@HardwareSettingsHPD
Scenario: VAN17771_TestStep145 User didn't set Windows Hello in Sign-in options Check The Zero Touch Login ADV Settings ADSA UI Text
    Given Go to Smart Assist page
	When Click HPD Zero Touch Login ADV Settings Link "ADVANCED SETTINGS"
	Then Check The Zero Touch Login ADV Settings ADSA Windows Hello Text "This feature relies on Windows Hello. Make sure face recognition is turned on in windows settings" and "Go to Windows Hello Settings"

@HardwareSettingsHPD
Scenario: VAN17771_TestStep146 User didn't set Windows Hello in Sign-in options Click the link Go to Windows Hello Settings Show Windows Hello setup page
    Given Go to Smart Assist page
	And Check ZT Login switch button is on
	When Click HPD Zero Touch Login ADV Settings Link "ADVANCED SETTINGS"
	Then Click the link Go to Windows Hello Settings
	Then Take Screen Shot 146ld in 17771 under HardwareSettingsHPD

@HardwareSettingsHPD
Scenario: VAN17771_TestStep147 Check Zero Touch Lock section icon and header and toggle and description 
    Given Go to Smart Assist page
	When Check Zero Touch Lock section icon and header text "Zero touch lock" and toggle
	Then Check Zero Touch Lock section description Text "This feature will dim the display and lock the computer when the user presence is not detected. It can reduce the chances of unauthorized access to the computer when you leave with the computer unattended and unlocked. It also reduces the power consumption by putting the system into Modern Standby when your presence is not detected."
	Then Take Screen Shot 147ld in 17771 under HardwareSettingsHPD

@HardwareSettingsHPD
Scenario: VAN17771_TestStep149 Off the toggle of Zero Touch Lock The whole feature will grey out 
    Given Go to Smart Assist page
	And Check Zero Touch Lock switch button is on
	And Click Zero Touch Lock ADV Settings Link
	And Click Zero Touch Lock ADSA switch button is "off"
	When Check Zero Touch Lock switch button is off
	Then Check Zero Touch Lock section The whole feature will grey out

@HardwareSettingsHPD
Scenario: VAN17771_TestStep150 Click on the ADVANCED SETTINGS link Show include FACIAL RECOGNITION AUTO SCREEN LOCK TIMER and AUTO DISTANCE SENSITIVITY ADJUSTING 
    Given Go to Smart Assist page
	And Check Zero Touch Lock switch button is on
	And Click Zero Touch Lock ADV Settings Link
	Then Check Show include FACIAL RECOGNITION AUTO SCREEN LOCK TIMER and AUTO DISTANCE SENSITIVITY ADJUSTING

@HardwareSettingsHPD
Scenario: VAN17771_TestStep151 Click on the "ADVANCED SETTINGS" link  change to "HIDE ADVANCED SETTINGS" link 
    Given Go to Smart Assist page
	And Click Zero Touch Lock ADV Settings Link
	Then Check Zero Touch Lock ADV Settings Link Text is "HIDE ADVANCED SETTINGS"

@HardwareSettingsHPD
Scenario: VAN17771_TestStep152 Switch to other pages and return Zero Touch Lock ADSA section extend/collapsed state should keep
    Given Go to Smart Assist page
	When Click HPD Zero Touch Lock ADV Settings Link "ADVANCED SETTINGS"
	Given Go to My Device Settings page
	And Go to Smart Assist page
	Then Check Zero Touch Lock ADV Settings ADSA section is show
	Given Go to Smart Assist page
	When Click HPD Zero Touch Lock ADV Settings Link "HIDE ADVANCED SETTINGS"
	Given Go to My Device Settings page
	And Go to Smart Assist page
	Then Check Zero Touch Lock ADV Settings ADSA section is fold

@HardwareSettingsHPD
Scenario: VAN17771_TestStep153 Relaunch vantage back to Smart Assist page  ZT Lock ADV ADSA In folded state
    Given Go to Smart Assist page
	When Click HPD Zero Touch Lock ADV Settings Link "ADVANCED SETTINGS"
	Given close lenovo vantage
	Given ReLaunch Lenovo Vantage
	Given Go to Smart Assist page
	Then Check Zero Touch Lock ADV Settings ADSA section is fold

@HardwareSettingsHPD
Scenario: VAN17771_TestStep154 Click HPD Zero Touch Lock ADV Settings Link Check the UI
    Given Go to Smart Assist page
	When Click HPD Zero Touch Lock ADV Settings Link "ADVANCED SETTINGS"
	Then Check the UI header text "FACIAL RECOGNITION" and  description text "This feature helps to improve the recognition performance and avoid unexpected screen lock especially when you lean back in your chair. This feature is processed locally on your device. Lenovo does not access or use it." and checkbox text is "Turn on the camera and enable this feature"

@HardwareSettingsHPD
Scenario: VAN17771_TestStep156 Click Display&Camera Page Camera Privacy Mode switch button is on and Camera permission is off HPD Zero Touch Lock Facial Recogoition Checkbox is grey
	Given Go to My Device Settings page
	When Click Display&Camera Page Camera Privacy Mode switch button is "on"
	Given Go to System Camera Settings page
	And Check System Settings page Vantage Camera Global Toggle Switch is "on"
	And Check System Settings page Vantage camera permission is "off"
	Given Go to Smart Assist page
	When Click HPD Zero Touch Lock ADV Settings Link "ADVANCED SETTINGS"
	Then Check The checkbox of HPD is grey out and can not be changed
	Given Go to System Camera Settings page
	And Check System Settings page Vantage Camera Global Toggle Switch is "on"
	And Check System Settings page Vantage camera permission is "on"
	Given Go to My Device Settings page
	When Click Display&Camera Page Camera Privacy Mode switch button is "off"

@HardwareSettingsHPD @SmokeHardwareSettingsHPD
Scenario: VAN17771_TestStep157 Click Display&Camera Page Camera Privacy Mode switch button is on and Camera permission is off Check HPD Zero Touch Lock Tip Access note text and link text
	Given Go to My Device Settings page
	When Click Display&Camera Page Camera Privacy Mode switch button is "on"
	Given Go to System Camera Settings page
	And Check System Settings page Vantage Camera Global Toggle Switch is "on"
	And Check System Settings page Vantage camera permission is "off"
	Given Go to Smart Assist page
	When Click HPD Zero Touch Lock ADV Settings Link "ADVANCED SETTINGS"
	When Click HPD Zero Touch Lock Tip Access note text is "Lenovo Vantage doesn't have access to Camera. The function of the checkbox won't work." and link text is "Go to Windows Settings to give access"
	Given Go to System Camera Settings page
	And Check System Settings page Vantage Camera Global Toggle Switch is "on"
	And Check System Settings page Vantage camera permission is "on"
    Given Go to My Device Settings page
	When Click Display&Camera Page Camera Privacy Mode switch button is "off"

@HardwareSettingsHPD
Scenario: VAN17771_TestStep158 Click Display&Camera Page Camera Privacy Mode switch button is on  Check HPD Zero Touch Lock Tip Privacy note text and link text
	Given Go to My Device Settings page
    When Click Display&Camera Page Camera Privacy Mode switch button is "on"
    Given Go to System Camera Settings page
	And Check System Settings page Vantage Camera Global Toggle Switch is "on"
    And Check System Settings page Vantage camera permission is "off"
    Given Go to Smart Assist page
    When Click HPD Zero Touch Lock ADV Settings Link "ADVANCED SETTINGS"
    And Click Go to Camera Access link
	And Check System Settings page Vantage Camera Global Toggle Switch is "on"
    And Check System Settings page Vantage camera permission is "on"
    Given Go to Smart Assist page
    When Click HPD Zero Touch Lock ADV Settings Link "ADVANCED SETTINGS"
    When Click HPD Zero Touch Lock Tip Privacy note text is "Lenovo Vantage Camera privacy mode is on. The function of the checkbox won't work." and link text is "Go to Camera privacy mode to turn it off"
    Given Go to My Device Settings page
    When Click Display&Camera Page Camera Privacy Mode switch button is "off"

@HardwareSettingsHPD
Scenario: VAN17771_TestStep159  Click on the HPD  AUTO SCREEN LOCK TIMER question mark.check tip text
    Given Go to Smart Assist page
	When Click HPD Zero Touch Lock ADV Settings Link "ADVANCED SETTINGS"
	And Click Auto Screen Lock Timer question mark icon
	Then Check HPD Auto Screen Lock Timer question mark text is "Select your desired option to lock your screen at a Fast/Medium/Slow speed when your presence is not detected. However, the time when the screen will be locked is also impacted by the actual user scenario, the sensor capability, and the Windows screen timeout settings. So, we strongly suggest you instantly lock your system before you leave."

@HardwareSettingsHPD
Scenario: VAN17771_TestStep161  Click on the AUTO DISTANCE SENSITIVITY ADJUSTING switch button.Check description text
    Given Go to Smart Assist page
	And Check Zero Touch Lock switch button is on
	When Click HPD Zero Touch Lock ADV Settings Link "ADVANCED SETTINGS"
	And Click Zero Touch Lock ADSA switch button is "on"
	Then Check The ADSA switch button on context of the description should be "The accuracy varies by body size, posture, and frequency of movement. If your computer is locked unexpectedly, you can manually adjust the detecting sensitivity based on your preference."

@HardwareSettingsHPD
Scenario: VAN17771_TestStep162  Click off the AUTO DISTANCE SENSITIVITY ADJUSTING switch button.Check description text
    Given Go to Smart Assist page
	And Check Zero Touch Lock switch button is on
	When Click HPD Zero Touch Lock ADV Settings Link "ADVANCED SETTINGS"
	And Click Zero Touch Lock ADSA switch button is "off"
	Then Check The ADSA switch button off context of the description should be "The accuracy varies by body size, posture, and frequency of movement. When this feature is disabled, you need to manually adjust the sensitivity bar to adjust the detecting distance. If you want the distance to be adjusted automatically, turn it on." and "• Near: 0.9 meter" and "• Middle: 1.2 meter" and "• Far: 1.5 meter"

