Feature: VAN17172_IntelligentCoolingIdeapadITS5Function
	Help: Vantage Settings ITS5.0 IdeaPad Function Test
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17172
	Developer: chenpj, Lixx

@ideaITS5Function_17172
Scenario: VAN17172_TestStep01_Check intelligent cooling mode should keep the same with ITS drive
	Given Change DPI to recommend
	Given Go to Power Page
	Given Jump to power smart settings section
	Then The intelligent cooling mode should keep the same with ITS drive for ideapad ITS Five

@ideaITS5Function_17172
Scenario: VAN17172_TestStep02_Check default value of auto-transition check-box is unchecked state
	Given Go to Power Page
	Given Jump to power smart settings section
    When The user select ICM mode for ideapad ITS Five
	When The user select on auto transition checkbox for ideapad ITS Five
	Then The auto transition checkbox status is on for ideapad ITS Five
	Given Install Vantage
	Given Launch Vantage
	Given Go to Power Page
	Then The auto transition checkbox status is off for ideapad ITS Five

@ideaITS5Function_17172
Scenario: VAN17172_TestStep03_Check ITS mode will still in ICM after user relaunch Vantage
	Given Go to Power Page
	Given Jump to power smart settings section
	When The user select ICM mode for ideapad ITS Five
	Given ReLaunch Vantage
	Given Go to Power Page
	Given Jump to power smart settings section
	Then Vantage ITS ICM On

@ideaITS5Function_17172S3S4
Scenario: VAN17172_TestStep04_Check ITS mode will still in ICM after user resume machine form S3 S4
	Given Go to Power Page
	Given Jump to power smart settings section
	When The user select ICM mode for ideapad ITS Five
	When Enter sleep
	Then Vantage ITS ICM On
	When Enter hibernate
	Then Vantage ITS ICM On

@ideaITS5Function_17172
Scenario: VAN17172_TestStep05_Check auto transition checkbox state is still in checked state after user refresh page
	Given Go to Power Page
	Given Jump to power smart settings section
	When The user select on auto transition checkbox for ideapad ITS Five
	Given Go to Power Page
	Given Jump to power smart settings section
	Then The auto transition checkbox status is on for ideapad ITS Five
	Given into Dashboard page
	Given Go to Power Page
	Given Jump to power smart settings section
	Then The auto transition checkbox status is on for ideapad ITS Five
	When change ITS mode to EPM via Vantage
	When change ITS mode to ISTD via Vantage
	Then The auto transition checkbox status is on for ideapad ITS Five

@ideaITS5Function_17172S3S4
Scenario: VAN17172_TestStep06_Check auto transition checkbox state is still in checked state after user resume machine form S3 S4
	Given Go to Power Page
	Given Jump to power smart settings section
	When The user select on auto transition checkbox for ideapad ITS Five
	When Enter sleep
	Then The auto transition checkbox status is on for ideapad ITS Five
	When Enter hibernate
	Then The auto transition checkbox status is on for ideapad ITS Five

@ideaITS5Function_17172IEPM
Scenario: VAN17172_TestStep07_GPU more than 75% check IEPM On
	Given Go to Power Page
	Given Jump to power smart settings section
	When change ITS mode to ISTD via Vantage
	Given Turn on auto-transition
	Given run csgo
	Given Waiting 90 seconds
	Then IEPM is On
	Then IEPM toast message popped-up

@ideaITS5Function_17172IEPM
Scenario: VAN17172_TestStep08_GPU more than 75% click learn more check UI
	When kill csgo and wait 0 second
	Given Close Vantage
	Given go to Action Center
	Given click learn more
	Then Vantage power page be launched

@ideaITS5Function_17172IEPM
Scenario: VAN17172_TestStep09_GPU more than 75% ignore message will be set to Action center
	Given clear pop up count for ITS5	
	Given Go to Power Page
	Given Jump to power smart settings section
	When change ITS mode to ISTD via Vantage
	Given Turn on auto-transition
	Given run csgo
	Given Waiting 90 seconds
	Given go to Action Center
	Then IEPM toast message popped-up
	Then Take Screen Shot 09UI in 17172 under ITSScreenShotResult

@ideaITS5Function_17172IEPM
Scenario: VAN17172_TestStep10_GPU more than 75% click learn  more check UI
	Given go to Action Center
	Given click learn more
	Then Vantage power page be launched

@ideaITS5Function_17172IEPM
Scenario: VAN17172_TestStep11_Uncheck and check the check-box again check IEPM On
	Given Go to Power Page
	Given Jump to power smart settings section
	When change ITS mode to ISTD via Vantage
	Given Turn off auto-transition
	Then IEPM is Off
	Given Turn on auto-transition
	Then IEPM is On
	Then IEPM toast message popped-up
	When kill csgo and wait 0 second

@ideaITS5Function_17172IEPM
Scenario: VAN17172_TestStep12_check IEPM toast message popped-up third time 
	Given run csgo
	Given Waiting 90 seconds
	When kill csgo and wait 0 second
	Given go to Action Center
	Then IEPM toast message popped-up

@ideaITS5Function_17172IEPM
Scenario: VAN17172_TestStep13_check IEPM toast message won't pop up 
	Given Go to Power Page
	Given Jump to power smart settings section
	When change ITS mode to ISTD via Vantage
	Given Turn on auto-transition
	Given run csgo
	Given Waiting 90 seconds
	When kill csgo and wait 0 second
	Given go to Action Center
	Then IEPM toast donnot message popped-up

@ideaITS5Function_17172IBSM
Scenario: VAN17172_TestStep14_check ITS mode to IBSM
	Given DC Condition(Connect the Adapter)
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	Given Turn on auto-transition
	Given Battery Level is below 30%
	Then IBSM On
	Given AC Condition(Connect the Adapter)

@ideaITS5Function_17172IEPM
Scenario: VAN17172_TestStep15_check Make the check-box state in unchecked state exit IEPM 
	Given AC Condition(Connect the Adapter)
	Given clear pop up count for ITS5
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	Given Turn on auto-transition
	Given run csgo
	Given Waiting 90 seconds
	Then IEPM is On
	Given Go to Power Page
	Given Jump to power smart settings section
	Given Turn off auto-transition
	Then IEPM is Off
	When kill csgo and wait 0 second

@ideaITS5Function_17172IBSM
Scenario: VAN17172_TestStep16_check ITS mode exit IBSM
	When kill csgo and wait 0 second
	Given DC Condition(Connect the Adapter)
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	Given Turn on auto-transition
	Given Battery Level is below 30%
	Then IBSM On
	Given Go to Power Page
	Given Turn off auto-transition
	Then IBSM off
	Given AC Condition(Connect the Adapter)

@ideaITS5Function_17172IEPM
Scenario: VAN17172_TestStep17_set the auto-transition check-box state in checked state IEPM On
	Given AC Condition(Connect the Adapter)
	When kill csgo and wait 0 second
	Given run csgo
	Given Waiting 90 seconds
	Then IEPM is Off
	Given Go to Power Page
	Given Turn on auto-transition
	Given Waiting 10 seconds
	Then IEPM is On
	When kill csgo and wait 0 second

@ideaITS5Function_17172IBSM
Scenario: VAN17172_TestStep18_check ITS mode to IBSM
	Given DC Condition(Connect the Adapter)
	When kill csgo and wait 0 second
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	Given Turn on auto-transition
	Then IBSM On
	Given AC Condition(Connect the Adapter)

@ideaITS5Function_17172
Scenario: VAN17172_TestStep19_relaunch vantage check EPM On
	Given AC Condition(Connect the Adapter)
	When kill csgo and wait 0 second
	Given Go to Power Page
	Given Jump to power smart settings section
	When change ITS mode to EPM via Vantage
	Given close lenovo vantage
	Given ReLaunch Lenovo Vantage
	Given Go to Power Page
	Given Jump to power smart settings section
	Then Vantage ITS EPM On

@ideaITS5Function_17172S3S4
Scenario: VAN17172_TestStep20_S3 S4 check EPM On
	Given Go to Power Page
	Given Jump to power smart settings section
	When change ITS mode to EPM via Vantage
	When Enter sleep
	Then Vantage ITS EPM On
	When Enter hibernate
	Then Vantage ITS EPM On

@ideaITS5Function_17172
Scenario: VAN17172_TestStep21_relaunch vantage check BSM On
	Given Go to Power Page
	Given Jump to power smart settings section
	When change ITS mode to BSM via Vantage
	Given close lenovo vantage
	Given ReLaunch Lenovo Vantage
	Given Go to Power Page
	Then Vantage ITS BSM On 

@ideaITS5Function_17172S3S4
Scenario: VAN17172_TestStep22_S3 S4 and check BSM On
	Given Go to Power Page
	Given Jump to power smart settings section
	When change ITS mode to BSM via Vantage
	When Enter sleep
	Then Vantage ITS BSM On 
	When Enter hibernate
	Then Vantage ITS BSM On 

@ideaITS5Function_17172
Scenario: VAN17172_TestStep23_set the ITS mode to Battery saving Dolby toggle in Vantage will be turned off
	Given go to Audio page
	Given Dolby audio is on
	Given Go to Power Page
	Given Jump to power smart settings section
	When change ITS mode to ICM via Vantage
	When change ITS mode to BSM via Vantage
	Given go to Audio page
	Then Dolby toggle is off

@ideaITS5Function_17172
Scenario: VAN17172_TestStep24_check Dolby toggle is on when switch to BSM and to other mode
	Given go to Audio page
	Given Dolby audio is on
	Given Go to Power Page
	Given Jump to power smart settings section
	When change ITS mode to BSM via Vantage
	Given go to Audio page
	Then Dolby toggle is off
	Given Go to Power Page
	Given Jump to power smart settings section
	When change ITS mode to ICM via Vantage
	Given go to Audio page
	Then Dolby toggle is on

@ideaITS5Function_17172
Scenario: VAN17172_TestStep25_check Dolby is off when it is off and select BSM
	Given go to Audio page
	Given turn off Dolby toggle
	Given Go to Power Page
	Given Jump to power smart settings section
	When change ITS mode to BSM via Vantage
	Given go to Audio page
	Then Dolby toggle is off

@ideaITS5Function_17172
Scenario: VAN17172_TestStep26_check ITS mode in Vantage toolbar keep the same with Vantage UI 
	Given turn on narrator
	Given Go to Power Page
	Given Jump to power smart settings section
	When change ITS mode to ISTD via Vantage
	Given launch toolbar
	Then ITS ICM is selected in Toolbar
	When change ITS mode to EPM via Vantage
	Given launch toolbar
	Then ITS EPM is selected in Toolbar
	When change ITS mode to BSM via Vantage
	Given launch toolbar
	Then ITS BSM is selected in Toolbar

@ideaITS5Function_17172
Scenario: VAN17172_TestStep27_check ITS mode in Vantage UI keep the same with  Vantage toolbar within 30s
	Given turn on narrator
	Given Go to Power Page
	Given Jump to power smart settings section
	Given Launch toolbar
	Given change ITS mode to ICM via Toolbar
	When wait 30 seconds
	Then Vantage ITS ICM On
	Given launch toolbar
	Given change ITS mode to EPM via Toolbar
	When wait 30 seconds
	Then Vantage ITS EPM On
	Given launch toolbar
	Given change ITS mode to BSM via Toolbar
	When wait 30 seconds
	Then Vantage ITS BSM On

@ideaITS5Function_17172
Scenario: VAN17172_TestStep28_check ITS mode in Vantage UI keep the same with  Vantage toolbar
	Given turn on narrator
	Given Go to Power Page
	Given Jump to power smart settings section
	Given Launch toolbar
	Given change ITS mode to ICM via Toolbar
	When into Dashboard page
	Given Go to Power Page
	Then Vantage ITS ICM On
	Given launch toolbar
	Given change ITS mode to EPM via Toolbar
	When into Dashboard page
	Given Go to Power Page
	Then Vantage ITS EPM On
	Given launch toolbar
	Given change ITS mode to BSM via Toolbar
	When into Dashboard page
	Given Go to Power Page
	Then Vantage ITS BSM On
	Given turn off narrator

@ideaITS5Function_17172IEPM
Scenario: VAN17172_TestStep29_uninstall Vantage ITS mode won't change to IEPM mode
	Given turn off narrator
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	Given Turn on auto-transition
	Given Uninstall the lenovo vatage
	Given run csgo
	Given Waiting 90 seconds
	Then IEPM is Off
	When kill csgo and wait 0 second

@ideaITS5Function_17172
Scenario: VAN17172_TestStep30_install Vantage The check-box state is in unchecked state
	When kill csgo and wait 0 second
	Given Install Vantage
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	Then ITS check-box off

@ideaITS5Function_17172
Scenario: VAN17172_TestStep31_reinstall Vantage trigger IEPM toast message will be popped-up
	Given Go to Power Page
	When change ITS mode to ISTD via Vantage
	Given Turn on auto-transition
	Given run csgo
	Given Waiting 90 seconds
	Then IEPM is On
	When kill csgo and wait 0 second
	Given go to Action Center
	Given Waiting 5 seconds
	Then IEPM toast message popped-up

@ideaITS5Function_17172
Scenario: VAN17172_TestStep32_ITS Mode in Vantage should keep on previous value before uninstall Vantage
	Given Go to Power Page
	Given Jump to power smart settings section
	When change ITS mode to ISTD via Vantage
	When change ITS mode to EPM via Vantage
	Given Install Vantage
	When ReLaunch Lenovo Vantage
	Given Go to Power Page
	Given Jump to power smart settings section
	Then Vantage ITS EPM On
	When change ITS mode to BSM via Vantage
	Given Install Vantage
	When ReLaunch Lenovo Vantage
	Given Go to Power Page
	Given Jump to power smart settings section
	Then Vantage ITS BSM On

@ideaITS5Function_17172
Scenario: VAN17172_TestStep37_deleteplugin check ITS mode hide
	When pin toolbar on Taskbar settings
	When unpin toolbar on Taskbar settings
	Given moveplugin
	Given Go to Power Page
	Then vantage ITS mode hide
	Given recoverplugin
	When pin toolbar on Taskbar settings

@ideaITS5Function_17172
Scenario: VAN17172_TestStep38_installplugin check ITS mode
	When pin toolbar on Taskbar settings
	When unpin toolbar on Taskbar settings
	Given moveplugin
	Given recoverplugin
	Given Go to Power Page
	Given Waiting 5 seconds
	Then The ITS feature and Jump link should display on Power page
	When pin toolbar on Taskbar settings

@ideaITS5Function_17172
Scenario: VAN17172_TestStep41_check ITS mode normal in 3s
	When pin toolbar on Taskbar settings
	Given Go to Power Page
	Given Jump to power smart settings section
	Then Take Screen Shot TestStep41 in 17172 under ITSScreenShotResult
