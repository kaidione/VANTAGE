Feature: VAN26184_SMBAudioMicrophone
	Test Case： https://jira.tc.lenovo.com/browse/VAN-26184
	Author： HaiYe Li

@NOSMBMicrophoneAudio
Scenario: VAN26184_TestStep01 Check Microphone should show on Audio page but there is no Meeting manager page
	Given go to Audio section Page
	Given Go to Microphone Panel
	Then  the header is microphone, there is toggle on the right
	Then  Meeting manager page will be hidden
	
@SMBMicrophoneForteMediaAudio
Scenario: VAN26184_TestStep02 Check including Microphone toggle, Microphone Valume, Advanced microphone effects show
	Given install 'ForteMedia' Driver
	Given go to Audio section Page
	Then  including Microphone toggle, Microphone Valume, Advanced microphone effects will be shown
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link 
	Then  SMB Microphone effects link will be shown
	When Take Screen Shot VAN26184_02Microphone IN 26184 under HSScreenShotResult for MSBMicrophone

@SMBMicrophoneForteMediaAudio
Scenario: VAN26184_TestStep03 Check title description and a quick interface description
	Given install 'ForteMedia' Driver
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link 
	Then  It will show title text for SMB
	Then  Microphone for meetings title text for SMB
	Then  It will show description and a quick interface description with Install Driver for SMB

@SMBMicrophoneForteMediaAudio
Scenario: VAN26184_TestStep04 Check Click Here it will launch Smart microphone settings app
	Given install 'ForteMedia' Driver
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link 
	Then  SMB Click here for install Driver without refresh
	Given wait 1 seconds
	Then It will launch Smart microphone settings app
	When Take Screen Shot VAN26184_10uninstallStoreForteMedia IN 26184 under HSScreenShotResult for MSBMicrophone

@SMBMicrophoneForteMediaAudio
Scenario: VAN26184_TestStep05 Check title description and a quick interface description no ForteMedia
	Given uninstall 'ForteMedia' Driver
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link 
	Then  It will show title text for SMB
	Then  Microphone for meetings title text for SMB
	Then  It will show description and a quick interface description with UNInstall Driver for SMB

@SMBMicrophoneForteMediaAudio
Scenario: VAN26184_TestStep06 Check Click Here Show Microsof Store
	Given uninstall 'ForteMedia' Driver
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link 
	Then  SMB Click here for uninstall Driver refresh
	Then wait 10 seconds
	Then  Locate Smart Microphone settings app display Microsoft Store

@SMBMicrophoneForteMediaAudio
Scenario: VAN26184_TestStep07 Check change to To add the application suitable for your hardware, click here
	Given install 'ForteMedia' Driver
	Given Go to Meeting manager page 
	Given uninstall 'ForteMedia' Driver
	Given go to Audio section Page
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link 
	Then  The link should be To change to To add the application suitable for your hardware, click here for SMB 

@SMBMicrophoneForteMediaAudio
Scenario: VAN26184_TestStep08 uninstall driver Click Here it will do nothing
	Given install 'ForteMedia' Driver
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link 
	Given uninstall 'ForteMedia' Driver
	Then  SMB Click here for install Driver without refresh
	Given wait 1 seconds
	Then  The link should be To change to access the application most suitable for your microphone, click here for SMB
	
@SMBMicrophoneForteMediaAudio
Scenario: VAN26184_TestStep09 Check change to access the application most suitable for your microphone, click here 
	Given uninstall 'ForteMedia' Driver
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link 
	Given install 'ForteMedia' Driver
	Given go to Audio section Page
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link 
	Then  The link should be To change to access the application most suitable for your microphone, click here for SMB
	
@SMBMicrophoneForteMediaAudio
Scenario: VAN26184_TestStep10 Check Suppressing keyboard noise, Acoustic echo cancellation and Optimize my microphone show
	Given uninstall 'ForteMedia' Driver
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link 
	Given install 'ForteMedia' Driver
	Then  SMB Click here for uninstall Driver without refresh
	Then  Locate Smart Microphone settings app display Microsoft Store

@SMBMicrophoneSnapticsAudio
Scenario: VAN26184_TestStep11 Check the UI of Microphone section microhone driver is Snaptics
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link
	Then  Optimize my microphone for on Meeting manager page should show
	Given go to Audio section Page
	Given Go to Microphone Panel 
	Then  Microphone toggle, microphone valume, optimize my microphone for should show 

@SMBMicrophoneSnapticsAudio
Scenario: VAN26184_TestStep12 Check choose a mode and launch Smart Audio 3 app microhone driver is Snaptics
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link
	When  Choose a mode and launch Smart Audio 3 app
	Given wait 2 seconds
	Given Check OptimizeMyMicrophone "MultipleVoices"
	When  Take Screen Shot VAN26184Multipvoices IN 26184 under HSScreenShotResult for MSBMicrophone

@SMBMicrophoneElevocAudio
Scenario: VAN26184_TestStep13 Check the UI of Microphone section microhone driver is Elevoc
	Given go to Audio section Page
	Given Go to Microphone Panel
	Then  Microphone toggle microphone valume will be show
	Given Go to Meeting manager page 
	Then  Microphone for meetings link will be hidden
	Then  Microphone effects link will be hidden

@SMBMicrophoneForteMediaAudio
Scenario: VAN26184_TestStep14 Check Microphone effects link will be hidden the privacy access link for Microphone
	Given install 'ForteMedia' Driver
	When  disable microphone total access
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link 
	Then  SMB Microphone effects link will be hidden
	Then  Keep the privacy access link for Microphone for SMB
	Then  enable microphone total access

@SMBMicrophoneForteMediaAudio
Scenario: VAN26184_TestStep15 Check Microphone effects link will be shown
	Given install 'ForteMedia' Driver
	When  enable microphone total access
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link 
	Then  SMB Microphone effects link will be shown

@SMBMicrophoneForteMediaAudio
Scenario: VAN26184_TestStep16 Check refresh the page the UI of Advanced microphone effects should not change
	Given install 'ForteMedia' Driver
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link 
	When  switch pages
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link 
	Then  It will show description and a quick interface description with Install Driver for SMB

@SMBMicrophoneForteMediaAudio
Scenario: VAN26184_TestStep17 Check ReLaunch Vantage the UI of Advanced microphone effects should not change
	Given install 'ForteMedia' Driver
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link   
	When  ReLaunch Vantage
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link 
	Then  It will show description and a quick interface description with Install Driver for SMB
	
@SMBMicrophoneForteMediaAudio
Scenario: VAN26184_TestStep18 Check resize Vantage the UI of Advanced microphone effects should not change
	Given install 'ForteMedia' Driver
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link 
	When  resize Vantage
	Then  It will show description and a quick interface description with Install Driver for SMB

@SMBMicrophoneForteMediaAudio
Scenario: VAN26184_TestStep19 Check UI of Advanced microphone effects should be shown within 2 seconds
	Given install 'ForteMedia' Driver
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link  
	Then  the UI of Advanced microphone effects should be shown within 2 seconds for SMB

@SMBMicrophoneSnapticsAudio
Scenario: VAN26184_TestStep20 Check Microphone effects link will be shown microhone driver is Snaptics
	When  enable microphone total access
	Given Go to Meeting manager page 
	When  Click Microphone for meetings link
	Given Check OptimizeMyMicrophone "title"
	Given Check OptimizeMyMicrophone "description"
	Given Check OptimizeMyMicrophone "OnlyMyVoice"
	Given Check OptimizeMyMicrophone "MultipleVoices"