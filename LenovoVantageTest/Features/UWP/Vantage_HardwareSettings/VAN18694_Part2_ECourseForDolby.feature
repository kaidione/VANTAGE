Feature: VAN18694_Part2_ECourseForDolby
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-18694
	Author： Helen / Pengjie Chen

Background: 
	Given check the ECourse Feature on the supported system
	Then Stop play music movie game voice app etc
	Given go to Audio page
	Given Jump to audio smart settings section

@ECourse
Scenario: VAN18694_TestStep16_Check E-Course is on and Only my voice Suppress Keyboard Noise Acoustic Echo Cancellation status show incorrect
	When Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| E-Course    | off            |
	When Lunch Smart microphone settings
	When Select "Environmental Mode" on Smart microphone settings
	When Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| E-Course    | on            |
	Then Smart microphone settings "Private Mode" is select
	Then Close Smart Microphone settings 

@ECourse
Scenario: VAN18694_TestStep17_Check E-Course is on and Only my voice Suppress Keyboard Noise Acoustic Echo Cancellation status show incorrect
	When Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| E-Course    | off           |
	When Lunch Smart microphone settings
	Then Smart microphone settings "Environmental Mode" is select
	Then Close Smart Microphone settings 

@ECourse
Scenario: VAN18694_TestStep18_Check E-Course is off and Dolby audio is off and Dolby Audio app UI is greyed out and Dolby cannot take effect
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Dolby audio | off           |
	| E-Course    | off           |
	When Play music top
	Then The Dolby Audio app ui is enable or disable 'disable'
	Then Stop play music movie game voice app etc
	When Play movie top
	Then The Dolby Audio app ui is enable or disable 'disable'
	Then Stop play music movie game voice app etc

@ECourse
Scenario: VAN18694_TestStep19_Check E-Course is off and Dolby audio is off and Dolby mode cannot change automatically
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name             | Toggle status |
	| Dolby audio             | on            |
	| E-Course                | off           |
	| Automatic Voip          | off           |
	| Automatic Entertainment | off           |
	#| Dynamic                 | on            |
	| Game                    | on            |
	When Play movie top
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	#| Dynamic     | on            |
	| Movie       | off           |
	| Music       | off           |
	| Game        | on            |
	| Voice       | off           |
	Then Stop play music movie game voice app etc

@ECourse
Scenario: VAN18694_TestStep20_Check Dolby mode will change to Movie or Music or Game automatically
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Dolby audio | on            |
	| E-Course    | off           |
	#| Dynamic     | on            |
	| Game        | on            |
	When Turn on or off the master toggle within Audio smart settings
	| Toggle name             | Toggle status |
	| Automatic Entertainment | on            |
	When Play movie top
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	#| Dynamic     | off           |
	| Movie       | on            |
	| Music       | off           |
	| Game        | off           |
	| Voice       | off           |
	Then Stop play music movie game voice app etc
	When Play music top
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	#| Dynamic     | off           |
	| Movie       | off            |
	| Music       | on           |
	| Game        | off           |
	| Voice       | off           |
	Then Stop play music movie game voice app etc

@ECourse
Scenario: VAN18694_TestStep21_Check Dolby mode will change to voice automatically
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Dolby audio | on            |
	| E-Course    | off           |
	#| Dynamic     | on            |
	| Game        | on            |
	When The user make a voip call via voice recorder app
	When Turn on or off the master toggle within Audio smart settings
	| Toggle name    | Toggle status |
	| Automatic Voip | on            |
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	#| Dynamic     | off           |
	| Movie       | off           |
	| Music       | off           |
	| Game        | off           |
	| Voice       | on            |
	Then Stop play music movie game voice app etc

@ECourse
Scenario: VAN18694_TestStep22_Check Dolby mode can select any mode manually
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Dolby audio | on            |
	| E-Course    | off           |
	When Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Music       | on            |
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	#| Dynamic     | enable        |
	| Movie       | enable        |
	| Music       | enable        |
	| Music       | on            |
	| Game        | enable        |
	| Voice       | enable        |
	When Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Movie       | on            |
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	#| Dynamic     | enable        |
	| Movie       | enable        |
	| Movie       | on        |
	| Music       | enable            |
	| Game        | enable        |
	| Voice       | enable        |
	When Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Game       | on            |
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	#| Dynamic     | enable        |
	| Movie       | enable        |
	| Game       | on        |
	| Music       | enable            |
	| Game        | enable        |
	| Voice       | enable        |
	When Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Voice       | on            |
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	#| Dynamic     | enable        |
	| Movie       | enable        |
	| Voice       | on        |
	| Music       | enable            |
	| Game        | enable        |
	| Voice       | enable        |


@ECourse
Scenario: VAN18694_TestStep23_Check Dolby mode will change to voice automatically
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name    | Toggle status |
	| Dolby audio    | on            |
	| E-Course       | off           |
	| Automatic Voip | on            |
	When The user make a voip call via voice recorder app
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	#| Dynamic     | off           |
	| Movie       | off           |
	| Music       | off           |
	| Game        | off           |
	| Voice       | on            |
	Then Stop play music movie game voice app etc

@ECourse
Scenario: VAN18694_TestStep24_Check Dolby mode will change to Movie or Music or Game automatically
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name             | Toggle status |
	| Dolby audio             | on            |
	| E-Course                | off           |
	| Automatic Entertainment | on            |
	#| Dynamic                 | on            |
	| Game                    | on            |
	When Play music top
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	#| Dynamic     | off           |
	| Movie       | off           |
	| Music       | on            |
	| Game        | off           |
	| Voice       | off           |
	Then Stop play music movie game voice app etc
	When Play movie top
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	#| Dynamic     | off           |
	| Movie       | on           |
	| Music       | off            |
	| Game        | off           |
	| Voice       | off           |
	Then Stop play music movie game voice app etc

@ECourse
Scenario: VAN18694_TestStep25_Check Automatic Entertainment checked and voip call and Dolby mode not change
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name             | Toggle status |
	| Dolby audio             | on            |
	| E-Course                | off           |
	| Automatic Entertainment | on            |
	#| Dynamic                 | on            |
	| Automatic Voip          | off           |
	| Game                    | on            |
	When The user make a voip call via voice recorder app
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	#| Dynamic     | on            |
	| Movie       | off           |
	| Music       | off           |
	| Game        | on            |
	| Voice       | off           |
	Then Stop play music movie game voice app etc

@ECourse
Scenario: VAN18694_TestStep26_Check play music and voip call and Dolby mode only change to Voice mode
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name             | Toggle status |
	| Dolby audio             | on            |
	| E-Course                | off           |
	| Automatic Entertainment | on            |
	| Automatic Voip          | on            |
	#| Dynamic                 | on            |
	| Game                    | on            |
	When Play music top
	When The user make a voip call via voice recorder app
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	#| Dynamic     | off           |
	| Movie       | off           |
	| Music       | off           |
	| Game        | off           |
	| Voice       | on            |
	Then Stop play music movie game voice app etc

@ECourse
Scenario: VAN18694_TestStep27_Check voip call and uncheck Automatic Voip and Voice mode back to Game mode
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name             | Toggle status |
	| Dolby audio             | on            |
	| E-Course                | off           |
	| Automatic Voip          | on            |
	#| Dynamic                 | on            |
	| Game                    | on            |
	When The user make a voip call via voice recorder app
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	#| Dynamic     | off           |
	| Movie       | off           |
	| Music       | off           |
	| Game        | off           |
	| Voice       | on            |
	When Turn on or off the master toggle within Audio smart settings
	| Toggle name    | Toggle status |
	| Automatic Voip | off           |
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	#| Dynamic     | on            |
	| Movie       | off           |
	| Music       | off           |
	| Game        | on            |
	| Voice       | off           |
	Then Stop play music movie game voice app etc

@ECourse
Scenario: VAN18694_TestStep28_Check uncheck Automatic Voip and Automatic Entertainment and Dynamic mode change to Voice mode
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name             | Toggle status |
	| Dolby audio             | on            |
	| E-Course                | off           |
	#| Dynamic                 | on            |
	| Automatic Entertainment | off           |
	| Automatic Voip          | off           |
	| Game                    | on            |
	When Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| E-Course    | on            |
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	#| Dynamic     | off           |
	| Movie       | off           |
	| Music       | off           |
	| Game        | off           |
	| Voice       | on            |
	Then Stop play music movie game voice app etc

@ECourse
Scenario: VAN18694_TestStep29_Check uncheck Automatic Voip and Automatic Entertainment and  Voice mode back to Game mode
	When Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| E-Course    | off           |
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	#| Dynamic     | on            |
	| Movie       | off           |
	| Music       | off           |
	| Game        | on            |
	| Voice       | off           | 
	Then Stop play music movie game voice app etc

@ECourse
Scenario: VAN18694_TestStep30_Check uncheck Automatic Voip and Automatic Entertainment and  Voice mode back to Game mode
	Given Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| Dolby audio | on            |
	| E-Course    | off           |
	#| Dynamic     | on            |
	| Game        | on            |
	| E-Course    | on            |
	When Select one mode within Dolby Audio app 'Music'
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	#| Dynamic     | off           |
	| Movie       | off           |
	| Music       | on            |
	| Game        | off           |
	| Voice       | off           |
	When Turn on or off the master toggle within Audio smart settings
	| Toggle name | Toggle status |
	| E-Course    | off           |
	Then the master toggle is on or off or enable or disable within Audio smart settings
	| Toggle name | Toggle status |
	#| Dynamic     | on            |
	| Movie       | off           |
	| Music       | off           |
	| Game        | on            |
	| Voice       | off           |
	Then Stop play music movie game voice app etc