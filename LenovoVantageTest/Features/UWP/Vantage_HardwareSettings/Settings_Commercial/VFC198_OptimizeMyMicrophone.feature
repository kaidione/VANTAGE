Feature: VFC198_OptimizeMyMicrophone
	Test Case： https://jira.tc.lenovo.com/browse/VFC-198
	Author: DaQi Fang

@OptimizeMyMicrophoneLe
Scenario: VFC198_Step01 check title and description
	Given go to Audio page
	Given Type in "{PGDN}"
	Given Type in "{PGDN}"
	Given Waiting 2 seconds
	Given Check OptimizeMyMicrophone "title"
	Given Check OptimizeMyMicrophone "description"

@OptimizeMyMicrophoneLe
Scenario: VFC198_Step02 check four button
	Given go to Audio page
	Given Type in "{PGDN}"
	Given Type in "{PGDN}"
	Given Waiting 2 seconds
	Given Check OptimizeMyMicrophone "VoiceRecognition"
	Given Check OptimizeMyMicrophone "OnlyMyVoice"
	Given Check OptimizeMyMicrophone "Normal"
	Given Check OptimizeMyMicrophone "MultipleVoices"

@OptimizeMyMicrophoneLe
Scenario: VFC198_Step03 check four button value with realtek
	Given go to Audio page
	Given Type in "{PGDN}"
	Given Type in "{PGDN}"
	Given Waiting 2 seconds
	Given Switch "VoiceRecognition" Microphone button
	Then Check Realtek "Voice Recognition" value
	Given Waiting 2 seconds
	Given Switch "OnlyMyVoice" Microphone button
	Then Check Realtek "OnlyMyVoice" value
	Given Waiting 2 seconds
	Given Switch "MultipleVoices" Microphone button
	Then Check Realtek "MultipleVoices" value
	Given Switch "Normal" Microphone button
	Then Check Realtek "Normal" value
	
@OptimizeMyMicrophoneLe
Scenario: VFC198_Step04 resize cutpage relunch the value is same
	Given go to Audio page
	Given Type in "{PGDN}"
	Given Type in "{PGDN}"
	Given Waiting 2 seconds
	Given Get four button value
	Given Go to dashboad page
	Given go to Audio page
	Then The four button value is same
	Given Check OptimizeMyMicrophone "title"
	Given Check OptimizeMyMicrophone "description"
	Given Check OptimizeMyMicrophone "VoiceRecognition"
	Given Check OptimizeMyMicrophone "OnlyMyVoice"
	Given Check OptimizeMyMicrophone "Normal"
	Given Check OptimizeMyMicrophone "MultipleVoices"
	Given ReLaunch Lenovo Vantage
	Given go to Audio page
	Then The four button value is same
	Given Check OptimizeMyMicrophone "title"
	Given Check OptimizeMyMicrophone "description"
	Given Check OptimizeMyMicrophone "VoiceRecognition"
	Given Check OptimizeMyMicrophone "OnlyMyVoice"
	Given Check OptimizeMyMicrophone "Normal"
	Given Check OptimizeMyMicrophone "MultipleVoices"

@OptimizeMyMicrophoneLe
Scenario: VFC198_Step05 checkout voicerecognition the two toggle is gray out
	Given go to Audio page
	Given Type in "{PGDN}"
	Given Type in "{PGDN}"
	Given Waiting 2 seconds
	Given Switch "VoiceRecognition" Microphone button
	Then The "SuppressKeyboardNoise" Audio checkbox is "gray out"
	Then The "AcousticEchoCancellation" Audio checkbox is "gray out"

@OptimizeMyMicrophoneLe
Scenario: VFC198_Step06 checkout other button the two toggle is not gray out
	Given go to Audio page
	Given Type in "{PGDN}"
	Given Type in "{PGDN}"
	Given Waiting 2 seconds
	Given Switch "OnlyMyVoice" Microphone button
	Then The "SuppressKeyboardNoise" Audio checkbox is "no gray out"
	Then The "AcousticEchoCancellation" Audio checkbox is "no gray out"
	Given Switch "Normal" Microphone button
	Then The "SuppressKeyboardNoise" Audio checkbox is "no gray out"
	Then The "AcousticEchoCancellation" Audio checkbox is "no gray out"
	Given Switch "MultipleVoices" Microphone button
	Then The "SuppressKeyboardNoise" Audio checkbox is "no gray out"
	Then The "AcousticEchoCancellation" Audio checkbox is "no gray out"