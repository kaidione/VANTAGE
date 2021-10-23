Feature: VAN26254_HSAAudioMicrophone
	Test Case： https://jira.tc.lenovo.com/browse/VAN-26254
	Author： HaiYe Li

@HSAMicrophoneAudio
Scenario: VAN26254_TestStep01 Check Suppressing keyboard noise, Acoustic echo cancellation and Optimize my microphone show
	Given go to Audio section Page
	Given Go to Microphone Panel
	Then  Suppressing keyboard noise, Acoustic echo cancellation and Optimize my microphone for will be shown
	Then  Microphone effects link will be hidden
	
@OldHSAMicrophoneAudio
Scenario: VAN26254_TestStep02 Check Suppressing keyboard noise, Acoustic echo cancellation and Optimize my microphone show
	Given go to Audio section Page
	Given Go to Microphone Panel
	Then  Suppressing keyboard noise, Acoustic echo cancellation and Optimize my microphone for will be shown
	Then  Microphone effects link will be hidden
	
@NewHSAForteMediaMicrophoneAudio @SmokeNewHSAForteMediaMicrophoneAudio
Scenario: VAN26254_TestStep03 Check Microphone effects link will be shown
	Given go to Audio section Page
	Given Go to Microphone Panel 
	Then  Suppressing keyboard noise, Acoustic echo cancellation and Optimize my microphone for will be hidden
	Then  Microphone effects link will be shown

@NewHSAForteMediaMicrophoneAudio
Scenario: VAN26254_TestStep04 Check Suppressing keyboard noise, Acoustic echo cancellation and Optimize my microphone show
	Given install 'ForteMedia' Driver
	Given go to Audio section Page
	Given Go to Microphone Panel
	Then  It will show title text
	Then  It will show description and a quick interface description with Install Driver

@NewHSAForteMediaMicrophoneAudio
Scenario: VAN26254_TestStep05 Check title description and a quick interface description no ForteMedia
	Given uninstall 'ForteMedia' Driver
	Given go to Audio section Page
	Given Go to Microphone Panel 
	Then  It will show title text
	Then  It will show description and a quick interface description with UNInstall Driver

@NewHSAForteMediaMicrophoneAudio
Scenario: VAN26254_TestStep06 Check Click Here Show Microsof Store
	Given uninstall 'ForteMedia' Driver
	Given go to Audio section Page
	Given Go to Microphone Panel 
	Then  Click here for uninstall Driver refresh
	Then wait 30 seconds
	Then  Locate Smart Microphone settings app display Microsoft Store

@NewHSAForteMediaMicrophoneAudio
Scenario: VAN26254_TestStep07 Check Microphone effects link should not be shown, the privacy access link for Microphone
	Given go to Audio section Page
	Given Go to Microphone Panel 
	When  disable microphone total access
	Then  Microphone effects link will be hidden
	Then  Keep the privacy access link for Microphone
	Then  enable microphone total access

@NewHSAForteMediaMicrophoneAudio
Scenario: VAN26254_TestStep08 Check Click Here Show MicrosofStore  audio-microphone-permission-link
	Given install 'ForteMedia' Driver
	Given go to Audio section Page
	Given Go to Microphone Panel 
	When  enable microphone total access
	Then  Microphone effects link will be shown
	Then  The link should be To change to access the application most suitable for your microphone, click here  

@NewHSAForteMediaMicrophoneAudio
Scenario: VAN26254_TestStep09 Check uninstall driver show text To add , click here
	Given install 'ForteMedia' Driver
	Given go to Audio section Page
	Given Go to Microphone Panel 
	Given uninstall 'ForteMedia' Driver
	Given Go to Power Page
	Given go to Audio section Page
	Given Go to Microphone Panel
	Then  The link should be To change to To add the application suitable for your hardware, click here 

@NewHSAForteMediaMicrophoneAudio
Scenario: VAN26254_TestStep10 Check uninstall driver Click Here it will do nothing
	Given install 'ForteMedia' Driver
	Given go to Audio section Page
	Given Go to Microphone Panel 
	Given uninstall 'ForteMedia' Driver
	Then  Click here for install Driver without refresh
	Given wait 1 seconds
	When Take Screen Shot VAN26254_10uninstallStoreForteMedia IN 26254 under HSScreenShotResult for NoForteMedia

@NewHSAForteMediaMicrophoneAudio
Scenario: VAN26254_TestStep11 Check install driver show text To access, click here
	Given uninstall 'ForteMedia' Driver
	Given go to Audio section Page
	Given Go to Microphone Panel
	Given install 'ForteMedia' Driver
	Given Go to Power Page
	Given go to Audio section Page
	Given Go to Microphone Panel
	Then  The link should be To change to access the application most suitable for your microphone, click here 
	
@NewHSAForteMediaMicrophoneAudio
Scenario: VAN26254_TestStep12 Check uninstall driver Click Here it will jump to Microsoft Store 
	Given uninstall 'ForteMedia' Driver
	Given go to Audio section Page
	Given Go to Microphone Panel 
	Then  Click here for uninstall Driver refresh
	Given wait 10 seconds
	Then Locate Smart Microphone settings app display Microsoft Store
	When Take Screen Shot VAN26254_12uninstallStoreForteMedia IN 26254 under HSScreenShotResult for NoForteMedia

@NewHSAForteMediaMicrophoneAudio
Scenario: VAN26254_TestStep13 Check refresh the page the UI of Advanced microphone effects should not change
	Given install 'ForteMedia' Driver
	Given go to Audio section Page
	Given Go to Microphone Panel 
	When  switch pages
	Then  It will show description and a quick interface description with Install Driver

@NewHSAForteMediaMicrophoneAudio
Scenario: VAN26254_TestStep14 Check ReLaunch Vantage the UI of Advanced microphone effects should not change
	Given install 'ForteMedia' Driver
	Given go to Audio section Page
	Given Go to Microphone Panel 
	When  ReLaunch Vantage
	Given go to Audio section Page
	Given Go to Microphone Panel
	Then  It will show description and a quick interface description with Install Driver
	
@NewHSAForteMediaMicrophoneAudio
Scenario: VAN26254_TestStep15 Check resize Vantage the UI of Advanced microphone effects should not change
	Given install 'ForteMedia' Driver
	Given go to Audio section Page
	Given Go to Microphone Panel 
	When  resize Vantage
	Then  It will show description and a quick interface description with Install Driver

@NewHSAForteMediaMicrophoneAudio
Scenario: VAN26254_TestStep16 Check UI of Advanced microphone effects should be shown within 2 seconds
	Given install 'ForteMedia' Driver
	Given go to Audio section Page
	Given Go to Microphone Panel 
	Then  the UI of Advanced microphone effects should be shown within 2 seconds
