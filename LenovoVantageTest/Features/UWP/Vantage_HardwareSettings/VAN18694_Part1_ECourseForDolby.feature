Feature: VAN18694_Part1_ECourseForDolby
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-18694
	Author： Helen / Pengjie Chen

Background: 
	Given check the ECourse Feature on the supported system
	Given go to Audio page
	Given Jump to audio smart settings section

@ECourse @SmokeECourse
Scenario: VAN18694_TestStep01_Check E-Course can show on the supported system
	Then ECourse can show or hide 'show'

@ECourse
Scenario: VAN18694_TestStep02_Check the UI of Dolby Audio and eCourse mode for first time launch Vantage
     Given Install Vantage
	 Given go to Audio page
	 Given Jump to audio smart settings section
	 Then The UI of Dolby Audio and eCourse mode for first time launch Vantage

@ECourse
Scenario: VAN18694_TestStep03_Check the ui display position of eCourse mode follow UI spec
	Then The UI display position of eCourse mode
	Then Take Screen Shot TestStep03 in 18694 under HSScreenShotResult

@ECourse
Scenario: VAN18694_TestStep04_Check the description of E-Course
	Then The Audio Smart settings description should be correct
	| section  | desc                                                                                                                                                                                                                                                                                                                          |
	| E-Course | This function is useful for on-line courses when there are voice interactions between teachers and students. When enabled, Dolby audio automatically changes to Voice mode. Meanwhile, features such as beamforming, acoustic echo cancellation, and keyboard noise suppression will be turned on to improve the voice input. |

@ECourse
Scenario: VAN18694_TestStep05_Check minimize refresh pages reopen Vantage and E-Course can show
	Then ECourse can show or hide 'show'
	Given go to Audio page
	Given Jump to audio smart settings section
	Then ECourse can show or hide 'show'
	Then The Audio Smart settings description should be correct
	| section  | desc                                                                                                                                                                                                                                                                                                                          |
	| E-Course | This function is useful for on-line courses when there are voice interactions between teachers and students. When enabled, Dolby audio automatically changes to Voice mode. Meanwhile, features such as beamforming, acoustic echo cancellation, and keyboard noise suppression will be turned on to improve the voice input. |
	When Get audio smart settings section toggle states
	Given Go to Power Page
	Given go to Audio page
	Given Jump to audio smart settings section
	Then audio smart settings section toggle states not change
	Then ECourse can show or hide 'show'
	Then The Audio Smart settings description should be correct
	| section  | desc                                                                                                                                                                                                                                                                                                                          |
	| E-Course | This function is useful for on-line courses when there are voice interactions between teachers and students. When enabled, Dolby audio automatically changes to Voice mode. Meanwhile, features such as beamforming, acoustic echo cancellation, and keyboard noise suppression will be turned on to improve the voice input. |
	When Minimize vantage conservation mode
	Then audio smart settings section toggle states not change
	Then ECourse can show or hide 'show'
	Then The Audio Smart settings description should be correct
	| section  | desc                                                                                                                                                                                                                                                                                                                          |
	| E-Course | This function is useful for on-line courses when there are voice interactions between teachers and students. When enabled, Dolby audio automatically changes to Voice mode. Meanwhile, features such as beamforming, acoustic echo cancellation, and keyboard noise suppression will be turned on to improve the voice input. |
	When Relaungh vantage conservation mode
	Given go to Audio page
	Given Jump to audio smart settings section
	Then audio smart settings section toggle states not change
	Then ECourse can show or hide 'show'
	Then The Audio Smart settings description should be correct
	| section  | desc                                                                                                                                                                                                                                                                                                                          |
	| E-Course | This function is useful for on-line courses when there are voice interactions between teachers and students. When enabled, Dolby audio automatically changes to Voice mode. Meanwhile, features such as beamforming, acoustic echo cancellation, and keyboard noise suppression will be turned on to improve the voice input. |

@ECourse
Scenario: VAN18694_TestStep06_Check resize Vantage and E-Course can show
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 500   | 500    |           |            |
	Given Jump to audio smart settings section
	Given Type in "{PGDN}"
	Then Take Screen Shot TestStep06 in 18694 under HSScreenShotResult
	Then ECourse can show or hide 'show'

@ECourse
Scenario: VAN18694_TestStep08_Check Dolby Audio description and E-Course can keep and Dolby Audio other elements hide
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Dolby audio | on            |
	| E-Course    | on            |
	When Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Dolby audio | off           |
	| E-Course    | off           |
	Then only keep the description of Dolby Audio other elements of Dolby Audio will hide or show 'hide'
	Then ECourse can show or hide 'show'
	Then The Audio Smart settings description should be correct
	| section     | desc                                                                                                                                                                                                                                                                                                                          |
	| E-Course    | This function is useful for on-line courses when there are voice interactions between teachers and students. When enabled, Dolby audio automatically changes to Voice mode. Meanwhile, features such as beamforming, acoustic echo cancellation, and keyboard noise suppression will be turned on to improve the voice input. |
	| Dolby audio | Select the mode as you desired from the following. You also can check the "Automatically optimize audio for ..." checkbox. When selected, Dolby audio automatically picks up the best audio effect for you according to the modes you are in.                                                                                 |

@ECourse
Scenario: VAN18694_TestStep09_Check Dolby Audio description and E-Course can keep and Dolby Audio other elements show
	Given "Get" Dolby audio two checkbox states
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Dolby audio | off           |
	| E-Course    | off           |
	When Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Dolby audio | on            |
	Given "Check" Dolby audio two checkbox states
	Then only keep the description of Dolby Audio other elements of Dolby Audio will hide or show 'show'
	Then ECourse can show or hide 'show'
	Then The Audio Smart settings description should be correct
	| section     | desc                                                                                                                                                                                                                                                                                                                          |
	| E-Course    | This function is useful for on-line courses when there are voice interactions between teachers and students. When enabled, Dolby audio automatically changes to Voice mode. Meanwhile, features such as beamforming, acoustic echo cancellation, and keyboard noise suppression will be turned on to improve the voice input. |
	| Dolby audio | Select the mode as you desired from the following. You also can check the "Automatically optimize audio for ..." checkbox. When selected, Dolby audio automatically picks up the best audio effect for you according to the modes you are in.                                                                                 |

@ECourse
Scenario: VAN18694_TestStep10_Check E-Course is off and Dolby audio is on and Audio smart settings elements status show incorrect
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Dolby audio | off           |
	| E-Course    | off           |
	When Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| E-Course    | on            |
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name             | Toggle status |
	| Dolby audio             | on            |
	#| Dynamic                 | disable       |
	| Movie                   | disable       |
	| Music                   | disable       |
	| Game                    | disable       |
	| Voice                   | disable       |
	| Voice                   | on            |
	| Automatic Voip          | disable       |
	| Automatic Entertainment | disable       |
	| E-Course                | on            |
	Then only keep the description of Dolby Audio other elements of Dolby Audio will hide or show 'show'
	Given Turn on or off the narrator 'on'
	#Given turn on narrator
	Given Pin toolbar to taskbar
	Given launch toolbar
	Given Waiting 10 seconds
	Then the ECourse toggle status is on or off within toolbar 'on'
	#Then turn off narrator
	Given Turn on or off the narrator 'off'


@ECourse
Scenario: VAN18694_TestStep11_Check E-Course is on and Dolby audio is on and Audio smart settings elements status show incorrect
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Dolby audio | on            |
	| E-Course    | off           |
	When Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| E-Course    | on            |
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name             | Toggle status |
	| Dolby audio             | on            |
	#| Dynamic                 | disable       |
	| Movie                   | disable       |
	| Music                   | disable       |
	| Game                    | disable       |
	| Voice                   | disable       |
	| Voice                   | on            |
	| Automatic Voip          | disable       |
	| Automatic Entertainment | disable       |
	| E-Course                | on            |
	Given Turn on or off the narrator 'on'
	#Given turn on narrator
	Given Pin toolbar to taskbar
	Given launch toolbar
	Given Waiting 10 seconds
	Then the ECourse toggle status is on or off within toolbar 'on'
	#Then turn off narrator
	Given Turn on or off the narrator 'off'

@ECourse
Scenario: VAN18694_TestStep12_Check E-Course is off and Dolby audio is on and movie is select and Audio smart settings elements status show incorrect
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Dolby audio | on            |
	| E-Course    | off           |
	| Movie       | on            |
	| E-Course    | on            |
	When Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| E-Course    | off           |
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name             | Toggle status |
	| Dolby audio             | on            |
	#| Dynamic                 | enable        |
	| Movie                   | enable        |
	| Music                   | enable        |
	| Game                    | enable        |
	| Voice                   | enable        |
	| Movie                   | on            |
	| Voice                   | off           |
	| Automatic Voip          | enable        |
	| Automatic Entertainment | enable        |
	| E-Course                | off           |
	Given Turn on or off the narrator 'on'
	#Given turn on narrator
	Given Pin toolbar to taskbar
	Given launch toolbar
	Given Waiting 10 seconds
	Then the ECourse toggle status is on or off within toolbar 'off'
	#Then turn off narrator
	Given Turn on or off the narrator 'off'

@ECourse
Scenario: VAN18694_TestStep13_Check E-Course is off and Dolby audio is off and Audio smart settings elements status show incorrect
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Dolby audio | on            |
	| E-Course    | on            |
	When Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Dolby audio | off           |
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	| Dolby audio | off           |
	| E-Course    | off           |
	Then only keep the description of Dolby Audio other elements of Dolby Audio will hide or show 'hide'
	Then ECourse can show or hide 'show'
	Then The Audio Smart settings description should be correct
	| section     | desc                                                                                                                                                                                                                                                                                                                          |
	| E-Course    | This function is useful for on-line courses when there are voice interactions between teachers and students. When enabled, Dolby audio automatically changes to Voice mode. Meanwhile, features such as beamforming, acoustic echo cancellation, and keyboard noise suppression will be turned on to improve the voice input. |
	| Dolby audio | Select the mode as you desired from the following. You also can check the "Automatically optimize audio for ..." checkbox. When selected, Dolby audio automatically picks up the best audio effect for you according to the modes you are in.                                                                                 |
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	| E-Course    | off           |
	
@ECourse
Scenario: VAN18694_TestStep14_Check E-Course is off and Dolby audio is off and Audio smart settings elements status show incorrect
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Dolby audio | on            |
	| E-Course    | on            |
	When Turn on or off the Dolby Audio button within Dolby Audio app 'off'
	Then only keep the description of Dolby Audio other elements of Dolby Audio will hide or show 'hide'
	Then ECourse can show or hide 'show'
	Then The Audio Smart settings description should be correct
	| section     | desc                                                                                                                                                                                                                                                                                                                          |
	| E-Course    | This function is useful for on-line courses when there are voice interactions between teachers and students. When enabled, Dolby audio automatically changes to Voice mode. Meanwhile, features such as beamforming, acoustic echo cancellation, and keyboard noise suppression will be turned on to improve the voice input. |
	| Dolby audio | Select the mode as you desired from the following. You also can check the "Automatically optimize audio for ..." checkbox. When selected, Dolby audio automatically picks up the best audio effect for you according to the modes you are in.                                                                                 |
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	| E-Course    | off           |
	
@ECourse
Scenario: VAN18694_TestStep15_Check E-Course is off and Dolby audio is off and Audio smart settings elements status show incorrect
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Dolby audio | on            |
	| E-Course    | on            |
	When Get audio smart settings section toggle states
	Given Install Vantage
	Given go to Audio page
	Given Jump to audio smart settings section
	Then audio smart settings section toggle states not change
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name             | Toggle status |
	#| Dynamic                 | enable        |
	| Movie                   | enable        |
	| Music                   | enable        |
	| Game                    | enable        |
	| Voice                   | enable        |
	| Automatic Voip          | enable        |
	| Automatic Entertainment | enable        |
	| Automatic Entertainment | off           |
	| Dolby audio             | on            |
	| E-Course                | off           |
