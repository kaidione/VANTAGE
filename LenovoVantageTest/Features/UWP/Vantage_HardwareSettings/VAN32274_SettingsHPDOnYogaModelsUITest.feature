Feature: VAN32274_SettingsHPDOnYogaModelsUITest
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-32274
	Author： DaQi Fang

@HPDOnYogaModels
Scenario: VAN32274_TestStep01
	Given Go to Smart Assist page
	Then HPD Check the sensing Title

@HPDOnYogaModels
Scenario: VAN32274_TestStep02
	Given Go to Smart Assist page
	Then The ZerotouchVideoPlayback is in Intelligent sensing
	Then The "Zero touch video" is display next to "Zero touch lock"

@HPDOnYogaModels
Scenario: VAN32274_TestStep03
	Given Go to Smart Assist page
	Then The "Global settings" is display next to "Zero touch video"

@HPDOnYogaModels
Scenario: VAN32274_TestStep04
	Given Go to Smart Assist page
	Then The HPD static image at the bottom of intelligent sensing

@HPDOnYogaModels
Scenario: VAN32274_TestStep05
	Given Go to Smart Assist page
	Then Check HPD head Text above image is "Intelligent sensing" and "Buckles up your PC with intelligent sensing technology, protects your privacy, and saves your battery power."

@HPDOnYogaModels
Scenario: VAN32274_TestStep06
	Given Go to Smart Assist page
	Then Scroll to HPDResetButton
	Then Take Screen Shot VAN32274_CheckGlobeSettingsUiSPEC in 32274 under ScreenShotResult
	
@HPDOnYogaModels
Scenario: VAN32274_TestStep07
	Given Go to Smart Assist page
	Then Check HPDGlobalSettingsCaption 

@HPDOnYogaModels
Scenario: VAN32274_TestStep08
	Given Uninstall the lenovo vatage
	Given Install the Lenovo Vantage
	Given Go to Smart Assist page
	Then Check The HPD GlobalSettings checkbox default value
	Then The HPD red tip under four checkbox is "hidden"

@HPDOnYogaModels
Scenario: VAN32274_TestStep09
	Given Go to Smart Assist page
	When "unchecked" the "all" HPD checkbox
	Then The HPD red tip under four checkbox is "show"

@HPDOnYogaModels
Scenario: VAN32274_TestStep10
	Given Go to Smart Assist page
	When "check" the "ClamshellCheckBox" HPD checkbox
	Then The HPD red tip under four checkbox is "hidden"
	When "unchecked" the "ClamshellCheckBox" HPD checkbox
	Then The HPD red tip under four checkbox is "show"
	When "check" the "SandCheckBox" HPD checkbox
	Then The HPD red tip under four checkbox is "hidden"
	When "unchecked" the "SandCheckBox" HPD checkbox
	Then The HPD red tip under four checkbox is "show"
	When "check" the "TentCheckBox" HPD checkbox
	Then The HPD red tip under four checkbox is "hidden"
	When "unchecked" the "TentCheckBox" HPD checkbox
	Then The HPD red tip under four checkbox is "show"
	When "check" the "PadCheckBox" HPD checkbox
	Then The HPD red tip under four checkbox is "hidden"
	When Click HPD Reset Button
	Then Check The HPD GlobalSettings checkbox default value

@HPDOnYogaModels
Scenario: VAN32274_TestStep11
	Given Go to Smart Assist page
	Then Check GlobalSettings "note"

@HPDOnYogaModels
Scenario: VAN32274_TestStep12
	Given Go to Smart Assist page
	Then Check GlobalSettings "attention"

@HPDOnYogaModels
Scenario: VAN32274_TestStep13
	Given Go to Smart Assist page
	When "unchecked" the "all" HPD checkbox
	Then The HPD red tip under four checkbox is "show"
	When Click HPD Reset Button
	Then Check The HPD GlobalSettings checkbox default value
	Then The HPD red tip under four checkbox is "hidden"

@HPDOnYogaModels
Scenario: VAN32274_TestStep14
	Given Go to Smart Assist page
	When "unchecked" the "all" HPD checkbox
	Then The HPD red tip under four checkbox is "show"
	When Click HPD Reset Button
	Then Check The HPD GlobalSettings checkbox default value
	Then Intelligent sensing all value change to defalut

@HPDOnYogaModels
Scenario: VAN32274_TestStep15
	Given Go to Smart Assist page
	Then Scroll to HPDResetButton
	Then Take Screen Shot VAN32274_CheckJumpToIntelligentSensingSection in 32274 under ScreenShotResult

@HPDOnYogaModels
Scenario: VAN32274_TestStep17
	Given Go to Smart Assist page
	When Click HPD Reset Button
	When Machine is under "Clamshell" mode
	Then Check The GlobalSettings regedit value
	| Clamshell | Stand | Tent | PAD |
	| 1         | 2     | 4    | 0   |

@HPDOnYogaModels
Scenario: VAN32274_TestStep18
	Given Go to Smart Assist page
	When Click HPD Reset Button
	When Machine is under "Stand" mode
	Then Check The GlobalSettings regedit value
	| Clamshell | Stand | Tent | PAD |
	| 1         | 2     | 4    | 0   |

@HPDOnYogaModels
Scenario: VAN32274_TestStep19
	When Machine is under "Clamshell" mode
	Given Go to Smart Assist page
	When Click HPD Reset Button
	When Machine is under "Tent" mode
	Then Check The GlobalSettings regedit value
	| Clamshell | Stand | Tent | PAD |
	| 1         | 2     | 4    | 0   |

@HPDOnYogaModels
Scenario: VAN32274_TestStep20
	When Machine is under "Clamshell" mode
	Given Go to Smart Assist page
	When Click HPD Reset Button
	When "check" the "PadCheckBox" HPD checkbox
	When Machine is under "Pad" mode
	Then Check The GlobalSettings regedit value
	| Clamshell | Stand | Tent | PAD |
	| 1         | 2     | 4    | 8   |

#@test32225
#Scenario: VAN32274_TestStep21
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "check" the "ClamshellCheckBox" HPD checkbox
#	When "unchecked" the "PadCheckBox" HPD checkbox
#	When "check" the "SandCheckBox" HPD checkbox
#	When "unchecked" the "TentCheckBox" HPD checkbox
#	When Turn "off" the Video Playback Toggle
#	When Check Zero Touch Lock switch button is off
#	Given Check ZT Login switch button is on
#	When Machine is under "Stand" mode
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 1         | 2     | 0    | 0   |
#
#@test32225
#Scenario: VAN32274_TestStep22
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "check" the "ClamshellCheckBox" HPD checkbox
#	When "unchecked" the "PadCheckBox" HPD checkbox
#	When "check" the "SandCheckBox" HPD checkbox
#	When "unchecked" the "TentCheckBox" HPD checkbox
#	When Turn "on" the Video Playback Toggle
#	Given Check Zero Touch Lock switch button is on
#	Given Check ZT Login switch button is on
#	When Machine is under "Stand" mode
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 1         | 2     | 0    | 0   |
#
#@test32225
#Scenario: VAN32274_TestStep23
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "check" the "ClamshellCheckBox" HPD checkbox
#	When "unchecked" the "PadCheckBox" HPD checkbox
#	When "unchecked" the "SandCheckBox" HPD checkbox
#	When "unchecked" the "TentCheckBox" HPD checkbox
#	When Turn "off" the Video Playback Toggle
#	When Check Zero Touch Lock switch button is off
#	Given Check ZT Login switch button is on
#	When Machine is under "Stand" mode
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 1         | 0     | 0    | 0   |
#
#@test32225
#Scenario: VAN32274_TestStep24
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "check" the "ClamshellCheckBox" HPD checkbox
#	When "unchecked" the "PadCheckBox" HPD checkbox
#	When "unchecked" the "SandCheckBox" HPD checkbox
#	When "check" the "TentCheckBox" HPD checkbox
#	When Turn "off" the Video Playback Toggle
#	Given Check Zero Touch Lock switch button is on
#	Given Check ZT Login switch button is off
#	When Machine is under "Tent" mode
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 1         | 0     | 4    | 0   |
#
#@test32225
#Scenario: VAN32274_TestStep25
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "check" the "ClamshellCheckBox" HPD checkbox
#	When "unchecked" the "PadCheckBox" HPD checkbox
#	When "unchecked" the "SandCheckBox" HPD checkbox
#	When "check" the "TentCheckBox" HPD checkbox
#	When Turn "on" the Video Playback Toggle
#	When Check Zero Touch Lock switch button is off
#	Given Check ZT Login switch button is on
#	When Machine is under "Tent" mode
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 1         | 0     | 4    | 0   |
#
#@test32225
#Scenario: VAN32274_TestStep26
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "check" the "ClamshellCheckBox" HPD checkbox
#	When "check" the "PadCheckBox" HPD checkbox
#	When "unchecked" the "SandCheckBox" HPD checkbox
#	When "unchecked" the "TentCheckBox" HPD checkbox
#	When Turn "on" the Video Playback Toggle
#	When Check Zero Touch Lock switch button is off
#	Given Check ZT Login switch button is off
#	When Machine is under "Pad" mode
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 1         | 0     | 0    | 8   |
#
#@test32225
#Scenario: VAN32274_TestStep27
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "check" the "ClamshellCheckBox" HPD checkbox
#	When "check" the "PadCheckBox" HPD checkbox
#	When "unchecked" the "SandCheckBox" HPD checkbox
#	When "unchecked" the "TentCheckBox" HPD checkbox
#	When Turn "off" the Video Playback Toggle
#	Given Check Zero Touch Lock switch button is on
#	Given Check ZT Login switch button is on
#	When Machine is under "Pad" mode
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 1         | 0     | 0    | 8   |
#
#@test32225
#Scenario: VAN32274_TestStep28
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "check" the "ClamshellCheckBox" HPD checkbox
#	When "check" the "PadCheckBox" HPD checkbox
#	When "check" the "SandCheckBox" HPD checkbox
#	When "check" the "TentCheckBox" HPD checkbox
#	When Turn "on" the Video Playback Toggle
#	Given Check Zero Touch Lock switch button is on
#	Given Check ZT Login switch button is on
#	When Machine is under "Pad" mode
#	Given wait 9 seconds
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 1         | 2     | 4    | 8   |
#
#@test32225
#Scenario: VAN32274_TestStep29
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "unchecked" the "ClamshellCheckBox" HPD checkbox
#	When "check" the "PadCheckBox" HPD checkbox
#	When "check" the "SandCheckBox" HPD checkbox
#	When "check" the "TentCheckBox" HPD checkbox
#	When Turn "off" the Video Playback Toggle
#	Given Check Zero Touch Lock switch button is on
#	Given Check ZT Login switch button is on
#	When Machine is under "Stand" mode
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 2     | 4    | 8   |
#
#@test32225
#Scenario: VAN32274_TestStep30
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "unchecked" the "ClamshellCheckBox" HPD checkbox
#	When "check" the "PadCheckBox" HPD checkbox
#	When "check" the "SandCheckBox" HPD checkbox
#	When "check" the "TentCheckBox" HPD checkbox
#	When Turn "off" the Video Playback Toggle
#	When Check Zero Touch Lock switch button is off
#	Given Check ZT Login switch button is off
#	When Machine is under "Stand" mode
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 2     | 4    | 8   |
#
#@test32225
#Scenario: VAN32274_TestStep31
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "unchecked" the "ClamshellCheckBox" HPD checkbox
#	When "check" the "PadCheckBox" HPD checkbox
#	When "check" the "SandCheckBox" HPD checkbox
#	When "check" the "TentCheckBox" HPD checkbox
#	When Turn "on" the Video Playback Toggle
#	Given Check Zero Touch Lock switch button is on
#	When Machine is under "Stand" mode
#	Given Check ZT Login switch button is off
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 2     | 4    | 8   |
#
#@test32225
#Scenario: VAN32274_TestStep32
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "unchecked" the "ClamshellCheckBox" HPD checkbox
#	When "check" the "PadCheckBox" HPD checkbox
#	When "check" the "SandCheckBox" HPD checkbox
#	When "check" the "TentCheckBox" HPD checkbox
#	When Machine is under "Stand" mode
#	When Turn "on" the Video Playback Toggle
#	Given Check Zero Touch Lock switch button is on
#	Given Check ZT Login switch button is off
#	When Machine is under "Clamshell" mode
#	When Machine is under "Tent" mode
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 2     | 4    | 8   |
#
#@test32225
#Scenario: VAN32274_TestStep33
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "unchecked" the "ClamshellCheckBox" HPD checkbox
#	When "check" the "PadCheckBox" HPD checkbox
#	When "check" the "SandCheckBox" HPD checkbox
#	When "check" the "TentCheckBox" HPD checkbox
#	When Turn "on" the Video Playback Toggle
#	When Check Zero Touch Lock switch button is off
#	Given Check ZT Login switch button is on
#	When Machine is under "Tent" mode
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 2     | 4    | 8   |
#
#@test32225
#Scenario: VAN32274_TestStep34
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "unchecked" the "ClamshellCheckBox" HPD checkbox
#	When "check" the "PadCheckBox" HPD checkbox
#	When "check" the "SandCheckBox" HPD checkbox
#	When "check" the "TentCheckBox" HPD checkbox
#	When Turn "off" the Video Playback Toggle
#	Given Check Zero Touch Lock switch button is on
#	Given Check ZT Login switch button is off
#	When Machine is under "Tent" mode
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 2     | 4    | 8   |
#
#@test32225
#Scenario: VAN32274_TestStep35
#	When Machine is under "Clamshell" mode
#	When Check Zero Touch Lock switch button is off
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "unchecked" the "ClamshellCheckBox" HPD checkbox
#	When "check" the "PadCheckBox" HPD checkbox
#	When "check" the "SandCheckBox" HPD checkbox
#	When "check" the "TentCheckBox" HPD checkbox
#	When Machine is under "Tent" mode
#	When Turn "off" the Video Playback Toggle
#	Given Check Zero Touch Lock switch button is on
#	Given Check ZT Login switch button is off
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 2     | 4    | 8   |
#
#@test32225
#Scenario: VAN32274_TestStep36
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When Check Zero Touch Lock switch button is off
#	When "unchecked" the "ClamshellCheckBox" HPD checkbox
#	When "check" the "PadCheckBox" HPD checkbox
#	When "check" the "SandCheckBox" HPD checkbox
#	When "check" the "TentCheckBox" HPD checkbox
#	When Machine is under "Tent" mode
#	When Turn "off" the Video Playback Toggle
#	Given Check Zero Touch Lock switch button is on
#	Given Check ZT Login switch button is off
#	When "check" the "SandCheckBox" HPD checkbox
#	When Machine is under "Stand" mode
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 2     | 4    | 8   |
#
#
#@test32225
#Scenario: VAN32274_TestStep37
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When Check Zero Touch Lock switch button is off
#	When "unchecked" the "ClamshellCheckBox" HPD checkbox
#	When "check" the "PadCheckBox" HPD checkbox
#	When "check" the "SandCheckBox" HPD checkbox
#	When "check" the "TentCheckBox" HPD checkbox
#	When Turn "on" the Video Playback Toggle
#	Given Check Zero Touch Lock switch button is on
#	Given Check ZT Login switch button is off
#	When Machine is under "Pad" mode
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 2     | 4    | 8   |
#
#@test32225
#Scenario: VAN32274_TestStep38
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When Check Zero Touch Lock switch button is off
#	When "unchecked" the "ClamshellCheckBox" HPD checkbox
#	When "check" the "PadCheckBox" HPD checkbox
#	When "check" the "SandCheckBox" HPD checkbox
#	When "check" the "TentCheckBox" HPD checkbox
#	When Turn "off" the Video Playback Toggle
#	When Check Zero Touch Lock switch button is off
#	Given Check ZT Login switch button is on
#	When Machine is under "Pad" mode
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 2     | 4    | 8   |
#
#@test32225
#Scenario: VAN32274_TestStep39
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When Check Zero Touch Lock switch button is off
#	When "unchecked" the "ClamshellCheckBox" HPD checkbox
#	When "check" the "PadCheckBox" HPD checkbox
#	When "check" the "SandCheckBox" HPD checkbox
#	When "check" the "TentCheckBox" HPD checkbox
#	When Machine is under "Pad" mode
#	When Turn "off" the Video Playback Toggle
#	When Check Zero Touch Lock switch button is off
#	Given Check ZT Login switch button is on
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 2     | 4    | 8   |
#
#@test32225
#Scenario: VAN32274_TestStep40
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "unchecked" the "ClamshellCheckBox" HPD checkbox
#	When "check" the "PadCheckBox" HPD checkbox
#	When "check" the "SandCheckBox" HPD checkbox
#	When "check" the "TentCheckBox" HPD checkbox
#	When Machine is under "Pad" mode
#	When Turn "off" the Video Playback Toggle
#	When Check Zero Touch Lock switch button is off
#	Given Check ZT Login switch button is on
#	When "check" the "SandCheckBox" HPD checkbox
#	When Machine is under "Stand" mode
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 2     | 4    | 8   |
#
#@test32225
#Scenario: VAN32274_TestStep41
#	When Machine is under "Stand" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "check" the "ClamshellCheckBox" HPD checkbox
#	When "check" the "PadCheckBox" HPD checkbox
#	When "check" the "SandCheckBox" HPD checkbox
#	When "check" the "TentCheckBox" HPD checkbox
#	When Turn "on" the Video Playback Toggle
#	Given Check Zero Touch Lock switch button is on
#	Given Check ZT Login switch button is on
#	When Machine is under "Clamshell" mode
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 1         | 2     | 4    | 8   |
#
#@test32225
#Scenario: VAN32274_TestStep42
#	When Machine is under "Stand" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "check" the "ClamshellCheckBox" HPD checkbox
#	When "check" the "PadCheckBox" HPD checkbox
#	When "check" the "SandCheckBox" HPD checkbox
#	When "check" the "TentCheckBox" HPD checkbox
#	When Turn "off" the Video Playback Toggle
#	When Check Zero Touch Lock switch button is off
#	Given Check ZT Login switch button is off
#	When Machine is under "Clamshell" mode
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 1         | 2     | 4    | 8   |
#
#@test32225
#Scenario: VAN32274_TestStep43
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "check" the "ClamshellCheckBox" HPD checkbox
#	When "unchecked" the "PadCheckBox" HPD checkbox
#	When "unchecked" the "SandCheckBox" HPD checkbox
#	When "unchecked" the "TentCheckBox" HPD checkbox
#	When Turn "off" the Video Playback Toggle
#	When Check Zero Touch Lock switch button is off
#	Given Check ZT Login switch button is off
#	When enter sleep
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 1         | 0     | 0    | 0   |
#	When enter hibernate
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 1         | 0     | 0    | 0   |
#
#@test32225
#Scenario: VAN32274_TestStep44
#	When Machine is under "Stand" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "unchecked" the "ClamshellCheckBox" HPD checkbox
#	When "unchecked" the "PadCheckBox" HPD checkbox
#	When "check" the "SandCheckBox" HPD checkbox
#	When "unchecked" the "TentCheckBox" HPD checkbox
#	When Turn "off" the Video Playback Toggle
#	When Check Zero Touch Lock switch button is off
#	Given Check ZT Login switch button is off
#	When enter sleep
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 2     | 0    | 0   |
#	When enter hibernate
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 2     | 0    | 0   |
#
#@test32225
#Scenario: VAN32274_TestStep45
#	When Machine is under "Tent" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "unchecked" the "ClamshellCheckBox" HPD checkbox
#	When "unchecked" the "PadCheckBox" HPD checkbox
#	When "unchecked" the "SandCheckBox" HPD checkbox
#	When "check" the "TentCheckBox" HPD checkbox
#	When Turn "off" the Video Playback Toggle
#	When Check Zero Touch Lock switch button is off
#	Given Check ZT Login switch button is off
#	When enter sleep
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 0     | 4    | 0   |
#	When enter hibernate
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 0     | 4    | 0   |
#
#@test32225
#Scenario: VAN32274_TestStep46
#	When Machine is under "Pad" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "unchecked" the "ClamshellCheckBox" HPD checkbox
#	When "check" the "PadCheckBox" HPD checkbox
#	When "unchecked" the "SandCheckBox" HPD checkbox
#	When "unchecked" the "TentCheckBox" HPD checkbox
#	When Turn "off" the Video Playback Toggle
#	When Check Zero Touch Lock switch button is off
#	Given Check ZT Login switch button is off
#	When enter sleep
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 0     | 0    | 8   |
#	When enter hibernate
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 0     | 0    | 8   |
#
#@test32225
#Scenario: VAN32274_TestStep52
#	When Machine is under "Clamshell" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "unchecked" the "ClamshellCheckBox" HPD checkbox
#	When "unchecked" the "PadCheckBox" HPD checkbox
#	When "unchecked" the "SandCheckBox" HPD checkbox
#	When "unchecked" the "TentCheckBox" HPD checkbox
#	When Turn "on" the Video Playback Toggle
#	Given Check Zero Touch Lock switch button is on
#	Given Check ZT Login switch button is on
#	When "check" the "ClamshellCheckBox" HPD checkbox
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 1         | 0     | 0    | 0   |
#
#@test32225
#Scenario: VAN32274_TestStep53
#	When Machine is under "Stand" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "unchecked" the "ClamshellCheckBox" HPD checkbox
#	When "unchecked" the "PadCheckBox" HPD checkbox
#	When "unchecked" the "SandCheckBox" HPD checkbox
#	When "unchecked" the "TentCheckBox" HPD checkbox
#	When Turn "on" the Video Playback Toggle
#	Given Check Zero Touch Lock switch button is on
#	Given Check ZT Login switch button is on
#	When "check" the "SandCheckBox" HPD checkbox
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 2     | 0    | 0   |
#
#@test32225
#Scenario: VAN32274_TestStep54
#	When Machine is under "Tent" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "unchecked" the "ClamshellCheckBox" HPD checkbox
#	When "unchecked" the "PadCheckBox" HPD checkbox
#	When "unchecked" the "SandCheckBox" HPD checkbox
#	When "unchecked" the "TentCheckBox" HPD checkbox
#	When Turn "on" the Video Playback Toggle
#	Given Check Zero Touch Lock switch button is on
#	Given Check ZT Login switch button is on
#	When "check" the "TentCheckBox" HPD checkbox
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 0     | 4    | 0   |
#
#@test32225
#Scenario: VAN32274_TestStep55
#	When Machine is under "Pad" mode
#	Given Go to Smart Assist page
#	When Click HPD Reset Button
#	When "unchecked" the "ClamshellCheckBox" HPD checkbox
#	When "unchecked" the "PadCheckBox" HPD checkbox
#	When "unchecked" the "SandCheckBox" HPD checkbox
#	When "unchecked" the "TentCheckBox" HPD checkbox
#	When Turn "on" the Video Playback Toggle
#	Given Check Zero Touch Lock switch button is on
#	Given Check ZT Login switch button is on
#	When "check" the "PadCheckBox" HPD checkbox
#	Then Check The GlobalSettings regedit value
#	| Clamshell | Stand | Tent | PAD |
#	| 0         | 0     | 0    | 8   |
	