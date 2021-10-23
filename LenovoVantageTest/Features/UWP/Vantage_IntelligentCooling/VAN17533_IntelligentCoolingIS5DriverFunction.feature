Feature: VAN17533_IntelligentCoolingIS5DriverFunction
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17533
	Author: Xiaoxiong Li

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep01_check ICM Mode by DPTF
	Given Restart ITS Service
	Then current mode is STD

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep02_check ITSMode by DPTF
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	Given DC Condition(Connect the Adapter)
	Given lever less than 30
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn off auto-transition
	Then current mode not is IBSM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep03_check ITSMode by DPTF
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn off auto-transition
	Given DC Condition(Connect the Adapter)
	Given lever less than 30
	Given Go to Power Page
	Given Turn on auto-transition
	Given Waiting 3 seconds
	Then current mode is IBSM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep04_check ITSMode by DPTF
	Given AC Condition(Connect the Adapter)
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	Given Battery Percentage more than 30
	Given DC Condition(Connect the Adapter)
	Then current mode not is IBSM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep05_check ITSMode by DPTF
	Given AC Condition(Connect the Adapter)
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	Given Battery Percentage more than 30
	Given DC Condition(Connect the Adapter)
	Given lever less than 30
	Then current mode is IBSM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep06_check ITSMode by DPTF
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	When change ITS mode to EPM via Vantage
	Given lever less than 30
	Given AC Condition(Connect the Adapter)
	When change ITS mode to ICM via Vantage
	Given Waiting 3 seconds
	Then current mode not is IBSM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep07_check ITSMode by DPTF
	Given DC Condition(Connect the Adapter)
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	When change ITS mode to EPM via Vantage
	Given lever less than 30
	Given AC Condition(Connect the Adapter)
	When change ITS mode to ICM via Vantage
	Given DC Condition(Connect the Adapter)
	Given Waiting 3 seconds
	Then current mode is IBSM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep09_check ITSMode by DPTF
	Given AC Condition(Connect the Adapter)
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn off auto-transition
	Given DC Condition(Connect the Adapter)
	Given lever less than 30
	Given Go to Power Page
	Given Turn on auto-transition
	Given Waiting 3 seconds
	Then current mode is IBSM
	Given AC Condition(Connect the Adapter)
	Then current mode not is IBSM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep10_check ITSMode by DPTF
	Given AC Condition(Connect the Adapter)
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn off auto-transition
	Given DC Condition(Connect the Adapter)
	Given lever less than 30
	Given Go to Power Page
	Given Turn on auto-transition
	Given Waiting 3 seconds
	Then current mode is IBSM
	Given Turn off auto-transition
	Given Waiting 3 seconds
	Then current mode not is IBSM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep11_set EPM BSM from toolbar ITS mode will in EPM BSM
	Given AC Condition(Connect the Adapter)
	Given launch toolbar
	Given change ITS mode to EPM via Toolbar
	Then current mode is EPM
	Given change ITS mode to BSM via Toolbar
	Then current mode is BSM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep12_set the auto-transition unchecked  ITS not change to IEPM mode
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn off auto-transition
	When change machine to NB mode
	Given run csgo
	Given Waiting 60 seconds
	Then current mode not is IEPM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep13_set the auto-transition checked  ITS change to IEPM mode
	When kill csgo and wait 60 second 
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn off auto-transition
	When change machine to NB mode
	Given run csgo
	Given Waiting 60 seconds
	Given Turn on auto-transition
	Given Waiting 3 seconds
	Then current mode is IEPM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep14_DC NB Mode ITS IEPM Off
	When kill csgo and wait 60 second 
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	Given DC Condition(Connect the Adapter)
	When change machine to NB mode
	Given run csgo
	Given Waiting 60 seconds
	Then current mode not is IEPM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep15_AC check IEPM On
	Given AC Condition(Connect the Adapter)
	Given Waiting 3 seconds
	Then current mode is IEPM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep16_Make the machine in TANT PAD stateITS mode not change to IEPM
	When kill csgo and wait 60 second 
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	When change machine to TENT mode
	Given run csgo
	Given Waiting 60 seconds
	Then current mode not is IEPM
	When kill csgo and wait 60 second 
	When change machine to PAD mode
	Given run csgo
	Given Waiting 60 seconds
	Then current mode not is IEPM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep17_Make machine in NB state check ITS mode to IEPM
	When kill csgo and wait 60 second 
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	When change machine to TENT mode
	Given run csgo
	Given Waiting 60 seconds
	When change machine to NB mode
	Then current mode is IEPM
	When kill csgo and wait 60 second 
	When change machine to PAD mode
	Given run csgo
	Given Waiting 60 seconds
	When change machine to NB mode
	Given Waiting 3 seconds
	Then current mode is IEPM
	When kill csgo and wait 60 second 

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep18_Make machine in NB state check ITS mode not to IEPM
	When kill csgo and wait 60 second 
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	When change machine to NB mode
	When open farmgame and keep 30s
	Then current mode not is IEPM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep19_check ITS mode to IEPM
	When kill farmheroessaga and wait 60 second 
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	When change machine to NB mode
	When open farmgame and keep 30s
	Given run csgo
	Given Waiting 60 seconds
	Then current mode is IEPM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep20_check ITS mode to IEPM
	When kill csgo and wait 60 second 
	When kill farmheroessaga and wait 60 second 
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	When change machine to NB mode
	Given run csgo
	Given Waiting 60 seconds
	Then current mode is IEPM

@ITS5DriverFunction_17533S3S4
Scenario: VAN17533_TestStep22_check ITS mode to IEPM
	When kill csgo and wait 60 second 
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	When change machine to NB mode
	Given run csgo
	Given Waiting 60 seconds
	Then current mode is IEPM
	When Enter sleep
	Then current mode is IEPM
	When Enter hibernate
	Then current mode is IEPM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep23_Close all the Gaming IEPM Off
	When kill csgo and wait 60 second 
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	Given run csgo
	Given Waiting 60 seconds
	Then current mode is IEPM
	When kill csgo and wait 60 second 
	Given Waiting 2 seconds
	Then current mode not is IEPM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep24_DC IEPM Off
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	Given run csgo
	Given Waiting 60 seconds
	Then current mode is IEPM
	Given DC Condition(Connect the Adapter)
	Given Waiting 3 seconds
	Then current mode not is IEPM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep25_IEPM Off
	Given AC Condition(Connect the Adapter)
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	Given run csgo
	Given Waiting 60 seconds
	Then current mode is IEPM
	When change machine to TENT mode
	Given Waiting 3 seconds
	Then current mode not is IEPM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep26_make the app not at the front end IEPM On
	Given AC Condition(Connect the Adapter)
	When kill csgo and wait 60 second 
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given Turn on auto-transition
	Given run csgo
	Given Waiting 60 seconds
	Given Go to Power Page
	Then current mode is IEPM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep27_Set ITS mode to BSM mode Dolby Off
	When kill csgo and wait 60 second 
	Given go to Audio page
	Given turn on Dolby toggle
	Given Go to Power Page
	When change ITS mode to BSM via Vantage
	Given go to Audio page
	Then Dolby toggle is off

@ITS5DriverFunction_17533S3S4
Scenario: VAN17533_TestStep28_S3 S4 check BSM On
	Given go to Audio page
	Given turn on Dolby toggle
	Given Go to Power Page
	When change ITS mode to BSM via Vantage
	When Enter sleep
	Then current mode is BSM
	When Enter hibernate
	Then current mode is BSM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep29_check The Brightness slider will be changed if the nit is higher than 60 before we switch mode
	Given go to Audio page
	Given turn on Dolby toggle
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	When change ITS mode to BSM via Vantage
	Then Before Brightness less than After Brightness

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep30_The Dolby feature will be turned on after ITS exit BSM
	Given go to Audio page
	Given turn on Dolby toggle
	Given Go to Power Page
	When change ITS mode to BSM via Vantage
	Given go to Audio page
	Given turn on Dolby toggle
	Given turn off Dolby toggle
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	Given go to Audio page
	Then Dolby toggle is on
	
@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep31_turn off the Dolby panel Set ITS mode to BSM Dolby Off
	Given go to Audio page
	Given turn off Dolby toggle
	Given Go to Power Page
	When change ITS mode to BSM via Vantage
	Given go to Audio page
	Then Dolby toggle is off

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep32_turn on the Dolby panel Set ITS mode to other mode Dolby On
	Given go to Audio page
	Given turn off Dolby toggle
	Given Go to Power Page
	When change ITS mode to BSM via Vantage
	Given go to Audio page
	Given turn on Dolby toggle
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	Given go to Audio page
	Then Dolby toggle is on

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep33_Check ITS mode will change to APM
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given run dnf
	Given Waiting 30 seconds
	Then current mode is APM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep34_close game will exit APM
	When kill Client and wait 60 second 
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given run dnf
	Given Waiting 30 seconds
	When kill Client and wait 60 second 
	Given Waiting 3 seconds
	Then current mode not is APM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep35_Minimize application APM Off
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given run photoshop
	Given Waiting 10 seconds
	Given Minimize photoshop
	Then current mode not is APM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep36_Close the app check APM Off
	When kill photoshop and wait 60 second 
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given run photoshop
	Given Waiting 10 seconds
	When kill photoshop and wait 60 second 
	Then current mode not is APM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep37_Running the app in the Creator apps list APM On
	Given run photoshop
	Given Waiting 30 seconds
	Then current mode is APM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep38_Make the app not at the forefront of the system APM On
	When kill photoshop and wait 60 second 
	Given run photoshop
	Given Waiting 30 seconds
	Given Go to Power Page
	Given Waiting 10 seconds
	Then current mode is APM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep39_Make the app not at the forefront of the system APM Off
	When kill photoshop and wait 60 second 
	Given run photoshop
	Given Waiting 30 seconds
	Given Go to Power Page
	Given Waiting 30 seconds
	Then current mode not is APM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep40_S3 check APM On
	When kill photoshop and wait 60 second 
	Given run photoshop
	Given Waiting 30 seconds
	When Enter sleep
	Then current mode is APM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep42_S3 S4 check APM Off
	When kill photoshop and wait 60 second 
	Given run photoshop
	Given Waiting 40 seconds
	Then current mode is APM
	Given launch Start menu
	When Enter sleep
	Then current mode not is APM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep44_Run the AIDA64 app APM On
	When kill photoshop and wait 60 second 
	Given run aida
	Given Waiting 60 seconds
	Then current mode is APM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep45_close the AIDA64 app APM Off
	When kill Aida64 and wait 60 second 
	Given run aida
	Given Waiting 30 seconds
	When kill Aida64 and wait 60 second 
	Then current mode not is APM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep46_Minimize application APM On
	Given run aida
	Given Waiting 30 seconds
	Given Minimize AIDA64
	Then current mode is APM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep47_Use the FireFox AQM On
	When kill Aida64 and wait 60 second 
	Given run firefox
	Given Waiting 60 seconds
	Then current mode is AQM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep48_Use the bilibili AQM On
	When kill firefox and wait 60 second 
	Given run bilibili
	Given Waiting 60 seconds
	Then current mode is AQM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep49_Use the Wechat AQM On
	When kill BilibiliUwpApp and wait 60 second 
	Given run wechat
	Given Waiting 60 seconds
	Then current mode is AQM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep50_Use the QQLive AQM On
	When kill WeChat and wait 60 second 
	Given run qqlive
	Given Waiting 60 seconds
	Then current mode is AQM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep51_run a app make ITS AQM On S3 AQM still On
	When kill QQLive and wait 60 second 
	Given run firefox
	Given Waiting 60 seconds
	Then current mode is AQM
	When Enter sleep
	Then current mode is AQM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep53_S3 check AQM Off
	When kill firefox and wait 60 second 
	Given run firefox
	Given Waiting 60 seconds
	Then current mode is AQM
	Given launch Start menu
	When Enter sleep
	Then current mode not is APM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep55_select EPM on toolbar EPM On
	When kill firefox and wait 60 second 
	Given launch toolbar
	Given change ITS mode to EPM via Toolbar
	Then current mode is EPM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep56_select EPM on toolbar S3 S4 EPM On
	Given launch toolbar
	Given change ITS mode to EPM via Toolbar
	When Enter sleep
	Then current mode is EPM
	When Enter hibernate
	Then current mode is EPM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep57_Make the machine state to TANT ITS mode will change to MYHTENT 
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	When change machine to TENT mode
	Then current mode is TENT

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep59_Make the machine state to PAD  The ITS mode will change to MYHTPAD
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	When change machine to PAD mode
	Given Waiting 3 seconds
	Then current mode is PAD

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep61_Restart serivce ITS mode will reset to ICM mode
	Given launch toolbar
	Given change ITS mode to EPM via Toolbar
	Given Restart ITS Service
	Given Waiting 3 seconds
	Then current mode is STD

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep63_check AQM mode is still enabled in DPTF but the activity mode is APM
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given close lenovo vantage
	Given run ie
	Given Waiting 60 seconds
	Then current mode is AQM
	Given run dnf
	Given Waiting 30 seconds
	Then current mode is APM
	When kill iexplore and wait 60 second 
	Given run ie
	Then current mode is APM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep64_The APM mode is still enabled in DPTF but the activity mode is MYHTENT
	When kill iexplore and wait 60 second 
	When kill Client and wait 60 second 
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given close lenovo vantage
	Given run ie
	Given Waiting 60 seconds
	Then current mode is AQM
	Given run dnf
	Given Waiting 30 seconds
	Then current mode is APM
	When change machine to TENT mode
	Given Waiting 3 seconds
	Then current mode is TENT

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep65_check MYHPAD On
	When kill iexplore and wait 60 second 
	When kill Client and wait 60 second 
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given close lenovo vantage
	Given run ie
	Given Waiting 60 seconds
	Then current mode is AQM
	Given run dnf
	Given Waiting 60 seconds
	Then current mode is APM
	When change machine to TENT mode
	Given Waiting 3 seconds
	When change machine to PAD mode
	Given Waiting 3 seconds
	Then current mode is PAD

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep66_check The ITS mode will change to IBSM mode from MYHPAD but MYHPAD is enabled in DPTF
	When kill iexplore and wait 60 second 
	When kill Client and wait 60 second 
	When change machine to NB mode
	Given close lenovo vantage
	Given run ie
	Given Waiting 60 seconds
	Then current mode is AQM
	Given run dnf
	Given Waiting 60 seconds
	Then current mode is APM
	When change machine to TENT mode
	Given Waiting 3 seconds
	When change machine to PAD mode
	Given Waiting 3 seconds
	Then current mode is PAD
	Given DC Condition(Connect the Adapter)
	Given lever less than 30
	Then current mode is IBSM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep67_check BSM On
	Given Go to Power Page
	When change ITS mode to BSM via Vantage
	Then current mode is BSM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep68_check IEPM On
	When kill iexplore and wait 60 second 
	When kill Client and wait 60 second 
	Given AC Condition(Connect the Adapter)
	When change machine to NB mode
	Given Go to Power Page
	When change ITS mode to ICM via Vantage
	Given run dnf
	Given Waiting 30 seconds
	Then current mode is APM
	Given run csgo
	Given Waiting 60 seconds
	Then current mode is IEPM

@ITS5DriverFunction_17533
Scenario: VAN17533_TestStep69_check EPM On
	Given Go to Power Page
	When change ITS mode to EPM via Vantage
	Then current mode is EPM








