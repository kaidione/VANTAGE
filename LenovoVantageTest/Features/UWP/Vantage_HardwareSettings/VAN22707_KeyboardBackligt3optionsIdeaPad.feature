Feature: VAN22707_KeyboardBackligt3optionsIdeaPad
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-22707
	Author： Jinxin Li

@keyboardbacklight3OptionsonIdeapad
Scenario: VAN22707_TestStep01_CheckTitleOptionIconAndDescription 
	Given Go to input page
	When check the title, option, icon and description of UI
	Then Title Option Icon and Description should be correct On Idea
	Given Get the KBBL value in EM driver
	Then The Backlight option same to EM driver

@keyboardbacklight3OptionsonIdeapad
Scenario: VAN22707_TestStep03_CheckTitleOptionIconAndDescription First 3s
	Given Install Vantage
	Given Go to input page
	Then Backlight Feature Could be Opened within 3 s

@keyboardbacklight3OptionsonIdeapad
Scenario: VAN22707_TestStep04_CheckTitleOptionIconAndDescription Performance testing 2s
	Given Go to input page
	Then Backlight Feature Could be Opened within 2 s

@keyboardbacklight3OptionsonIdeapad
Scenario: VAN22707_TestStep05_CheckTitlePerformanceTesting Performance testing
	Given Go to input page
	And click backlight option 'High'
	Then Backlight option 'High' within 2 s
	And click backlight option 'Low'
	Then Backlight option 'Low' within 2 s

@keyboardbacklight3OptionsonIdeapad
Scenario: VAN22707_TestStep06_CheckTitleOptionIconAndDescription Low
	Given Go to input page
	And click backlight option 'Low'
	And Go to input page
	Then verify backlight option 'Low' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is Low

@keyboardbacklight3OptionsonIdeapad
Scenario: VAN22707_TestStep07_CheckTitleOptionIconAndDescription High
	Given Go to input page
	And click backlight option 'High'
	And Go to input page
	Then verify backlight option 'High' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is High

@keyboardbacklight3OptionsonIdeapad
Scenario: VAN22707_TestStep10_CheckTitleOptionIconAndDescription Off
	Given Go to input page
	And click backlight option 'Off'
	And Go to input page
	Then verify backlight option 'Off' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is Off

@keyboardbacklight3OptionsonIdeapad
Scenario: VAN22707_TestStep11_CheckTitleOptionIconAndDescription Keep Off
	Given Go to input page
	And click backlight option 'Low'
	Given Go to Power Page
	And Go to input page
	Then verify backlight option 'Low' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is Low

@keyboardbacklight3OptionsonIdeapad
Scenario: VAN22707_TestStep12_CheckTitleOptionIconAndDescription Relaunch Keep Off
	Given Go to input page
	And click backlight option 'High'
	When Close Vantage
	When Launch Vantage
	And Go to input page
	Then verify backlight option 'High' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is High

@keyboardbacklight3OptionsonIdeapad @Smokekeyboardbacklight3OptionsonIdeapad
Scenario: VAN22707_TestStep13_Hot Key
	Given Go to input page
	And Set the KBBL value in EM driver to High
	And Go to input page
	Then verify backlight option 'High' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is High
	Given Go to input page
	And Set the KBBL value in EM driver to Low
	And Go to input page
	Then verify backlight option 'Low' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is Low
	Given Go to input page
	And Set the KBBL value in EM driver to Off
	And Go to input page
	Then verify backlight option 'Off' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is Off

@keyboardbacklight3OptionsonIdeapad
Scenario: VAN22707_TestStep14_Hot Key Set High
	Given Go to input page
	And click backlight option 'Off'
	Given Minimize Vantage
	And wait 300 seconds
	And Set the KBBL value in EM driver to High
	And Maximize Vatnage
	And Go to input page
	Then verify backlight option 'High' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is High

@keyboardbacklight3OptionsonIdeapad
Scenario: VAN22707_TestStep18_Hot Key Set High
	Given Click toolbar
	Given Launch Vantage from Toolbar Via 'All Settings' Link
	Given Go to input page
	When check the title, option, icon and description of UI
	Then Title Option Icon and Description should be correct On Idea
	Given Get the KBBL value in EM driver
	Then The Backlight option same to EM driver

@keyboardbacklight3OptionsonIdeapad
Scenario: VAN22707_TestStep19_LaunchVantagefromtoolbar
	Given Click toolbar
	Given Launch Vantage from Toolbar
	Given Go to input page
	And click backlight option 'High'
	Then verify backlight option 'High' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is High
	Given Go to input page
	And click backlight option 'Low'
	Then verify backlight option 'Low' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is Low
	Given Go to input page
	And click backlight option 'Off'
	Then verify backlight option 'Off' toggled
	And Get the KBBL value in EM driver

@keyboardbacklight3OptionsonIdeapad
Scenario: VAN22707_TestStep20_LaunchVantagefromtoolbar
	When Launch toolbar
	When Change the Status of the 'Power Saver'
	And Maximize Vatnage
	And Go to input page
	When check the title, option, icon and description of UI
	Then Title Option Icon and Description should be correct On Idea
	Given Get the KBBL value in EM driver
	Then The Backlight option same to EM driver

@keyboardbacklight3OptionsonIdeapad
Scenario: VAN22707_TestStep21_LaunchVantagefromtoolbar
	When Change the Status of the 'Power Saver' 
	And Maximize Vatnage
	Given Go to input page
	And click backlight option 'High'
	Then verify backlight option 'High' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is High
	Given Go to input page
	And click backlight option 'Low'
	Then verify backlight option 'Low' toggled
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is Low
	Given Go to input page
	And click backlight option 'Off'
	Then verify backlight option 'Off' toggled
	And Get the KBBL value in EM driver

@keyboardbacklight3OptionsonIdeapad
Scenario: VAN22707_TestStep25_Uninstall Vantage Default Value
	Given Go to input page
	And click backlight option 'Low'
	Then verify backlight option 'Low' toggled
	And close lenovo vantage
	Given Uninstall the lenovo vatage
	And Waiting 300 seconds
	And Get the KBBL value in EM driver
	And The KBBL value in EM driver is off

@keyboardbacklight3OptionsonIdeapad
Scenario: VAN22707_TestStep26_Uninstall Vantage Set Low
	Given Go to input page
	And click backlight option 'Low'
	Then verify backlight option 'Low' toggled
	And close lenovo vantage
	Given Uninstall the lenovo vatage
	And Waiting 300 seconds
	And Get the KBBL value in EM driver
	Given Install Vantage
	Given Go to input page
	And verify backlight option 'Off' toggled

@keyboardbacklight3OptionsonIdeapad
Scenario: VAN22707_TestStep27_Uninstall Vantage Set Low
	Given Go to input page
	And click backlight option 'High'
	Then verify backlight option 'High' toggled
	And close lenovo vantage
	Given Uninstall the lenovo vatage
	And Waiting 300 seconds
	And Set the KBBL value in EM driver to Low
	And Get the KBBL value in EM driver
	Given Install Vantage
	Given Go to input page
	And verify backlight option 'Low' toggled

@keyboardbacklightNot3OptionsonIdeapad
Scenario: VAN22707_TestStep28_Uninstall Vantage Set Low
	Given Go to input page
	And Get the KBBL value in EM driver Not 3 Options
	Then Get the KBBL value in EM driver is 4 Options
	Then title, option,icon and description should be correct
	When click backlight option 'Auto'
	Then verify backlight option 'Auto' toggled

@keyboardbacklight3OptionsonIdeapad
Scenario: VAN22707_TestStep29_Change Vantage Size
	Given Go to input page
	Given Set Vantage Size Width '500' Height '500'
	And click backlight option 'High'
	Then Take Screen Shot 227072901 in 22707 under HSScreenShotResult
	Given Set Vantage Size Width '600' Height '800'
	And click backlight option 'High'
	Then Take Screen Shot 227072902 in 22707 under HSScreenShotResult
	Given Set Vantage Size Width '1920' Height '1080'
	And click backlight option 'High'
	Then Take Screen Shot 227072903 in 22707 under HSScreenShotResult