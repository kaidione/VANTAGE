Feature: VFC2273_HSAAudioMicrophone
	Test Case： https://jira.tc.lenovo.com/browse/VFC-2273
	Author： HaiYe Li

@HSAAudioMicrophone
Scenario: VFC2273_TestStep01 Check Suppressing keyboard noise, Acoustic echo cancellation and Optimize my microphone show
	Given go to Audio section
	Given Go to Microphone Panel
	Then  Suppressing keyboard noise, Acoustic echo cancellation and Optimize my microphone for will be shown
	
@OldHSAAudioMicrophone
Scenario: VFC2273_TestStep02 Check Suppressing keyboard noise, Acoustic echo cancellation and Optimize my microphone show
	Given go to Audio section
	Given Go to Microphone Panel
	Then  Suppressing keyboard noise, Acoustic echo cancellation and Optimize my microphone for will be shown
	
@newHSAAudioMicrophone
Scenario: VFC2273_TestStep03 Check Microphone effects link will be shown
	Given go to Audio section
	Given Scroll the Advanced microphone effects 
	Then  Suppressing keyboard noise, Acoustic echo cancellation and Optimize my microphone for will be hidden
	Then  Microphone effects link will be shown
	
@newHSAAudioDolbyMicrophone
Scenario: VFC2273_TestStep04 Check the UI of Advanced microphone effects description and a quick interface description 
	Given install 'DolbyAccess' Driver
	Given go to Audio section Page
	Given Go to Microphone Panel 
	Then  It will show title text
	Then  It will show description and a quick interface description with Install Driver

@newHSAAudioDolbyMicrophone
Scenario: VFC2273_TestStep05 Check Click Here Show DolbyAccess
	Given install 'DolbyAccess' Driver
	Given go to Audio section Page
	Given Go to Microphone Panel
	Then  Click Here DolbyAccess
	Given wait 1 seconds
	When Take Screen Shot VFC2273_05DolbyAccess IN 2273 under HSScreenShotResult for DolbyAccess
	
@newHSAAudioForteMediaMicrophone
Scenario: VFC2273_TestStep06 Check Suppressing keyboard noise, Acoustic echo cancellation and Optimize my microphone show
	Given install 'ForteMedia' Driver
	Given go to Audio section
	Given Scroll the Advanced microphone effects 
	Then  It will show title text
	Then  It will show description and a quick interface description with Install Driver
	
@newHSAAudioForteMediaMicrophone
Scenario: VFC2273_TestStep07 Check Suppressing keyboard noise, Acoustic echo cancellation and Optimize my microphone show
	Given install 'ForteMedia' Driver
	Given go to Audio section
	Given Scroll the Advanced microphone effects 
	Then  Click Here DolbyAccess
	Given wait 1 seconds
	When Take Screen Shot VFC2273_07ForteMedia IN 2273 under HSScreenShotResult for ForteMedia

@newHSAAudioDolbyMicrophone
Scenario: VFC2273_TestStep08 Check title description and a quick interface description no DolbyAccess
	Given install 'DolbyAccess' Driver
	Given go to Audio section Page
	Given Go to Microphone Panel
	Then  It will show title text
	Then  It will show description and a quick interface description with Install Driver

@newHSAAudioDolbyMicrophone
Scenario: VFC2273_TestStep09 Check Click Here Show MicrosofStore
	Given install 'DolbyAccess' Driver
	Given go to Audio section Page
	Given Go to Microphone Panel 
	Then  Click Here NoDolbyAccess
	Given wait 1 seconds
	When Take Screen Shot VFC2273_09MicrosoftStoreDolbyAccess IN 2273 under HSScreenShotResult for NoDolbyAccess

@newHSAAudioForteMediaMicrophone
Scenario: VFC2273_TestStep10 Check title description and a quick interface description no ForteMedia
	Given uninstall 'ForteMedia' Driver
	Given go to Audio section
	Given Scroll the Advanced microphone effects 
	Then  It will show title text
	Then  It will show description and a quick interface description with UnInstall Driver

@newHSAAudioForteMediaMicrophone
Scenario: VFC2273_TestStep11 Check Click Here Show MicrosofStore
	Given uninstall 'ForteMedia' Driver
	Given go to Audio section
	Given Scroll the Advanced microphone effects 
	Then  Click Here NoDolbyAccess
	Given wait 1 seconds
	When Take Screen Shot VFC2273_11MicrosoftStoreForteMedia IN 2273 under HSScreenShotResult for NoForteMedia

@newHSAAudioForteMediaMicrophone
Scenario: VFC2273_TestStep12 Check Advanced microphone effects should not be shown
	Given disable microphone total access
	Given go to Audio section
	Given Go to Microphone Panel 
	Then  Advanced microphone effects should noshown
	Then  Keep the privacy access link for Microphone 
	Then enable microphone total access

@newHSAAudioForteMediaMicrophone
Scenario: VFC2273_TestStep13 Check Advanced microphone effects should  be shown
	Given enable microphone total access
	Given go to Audio section
	Given Scroll the Advanced microphone effects 
	Then  Advanced microphone effects should shown

@newHSAAudioDolbyMicrophone
Scenario: VFC2273_TestStep14 Check uninstall driver show text To add , click here
	Given install 'DolbyAccess' Driver
	Given go to Audio section Page
	Given Go to Microphone Panel 
	Given uninstall 'DolbyAccess' Driver
	Given Go to Power Page
	Given go to Audio section Page
	Given Go to Microphone Panel
	Then  The link should be To change to To add the application suitable for your hardware, click here 

@newHSAAudioDolbyMicrophone
Scenario: VFC2273_TestStep15 Check it will pop up a toast: Look for an app in the Microsoft Store, click OK
	Given install 'DolbyAccess' Driver
	Given go to Audio section Page
	Given Go to Microphone Panel
	Given uninstall 'DolbyAccess' Driver
	Then  Click Here NoDolbyAccess
	Then Click Look for an app in the Microsoft Store
	Then Click ok jump to Microphone Store

@newHSAAudioForteMediaMicrophone
Scenario: VFC2273_TestStep16 Check uninstall driver Click Here it will do nothing
	Given install 'ForteMedia' Driver
	Given go to Audio section
	Given Scroll the Advanced microphone effects 
	Given uninstall 'ForteMedia' Driver
	Then  Click Here DolbyAccess
	Given wait 1 seconds
	When Take Screen Shot VFC2273_18uninstallStoreForteMedia IN 2273 under HSScreenShotResult for NoForteMedia

@newHSAAudioDolbyMicrophone
Scenario: VFC2273_TestStep17 Check install driver show text To access , click here
	Given uninstall 'DolbyAccess' Driver
	Given go to Audio section Page
	Given Go to Microphone Panel
	Given install 'DolbyAccess' Driver
	Given Go to Power Page
	Given go to Audio section Page
	Given Go to Microphone Panel
	Then  The link should be To change to access the application most suitable for your microphone, click here 
	
@newHSAAudioDolbyMicrophone
Scenario: VFC2273_TestStep18 Check install driver show text To access , click here
	Given uninstall 'DolbyAccess' Driver
	Given go to Audio section Page
	Given Go to Microphone Panel
	Given install 'DolbyAccess' Driver
	Then  Click Here DolbyAccess
	When Take Screen Shot VFC2273_18MicrosoftStoreDolbyAccess IN 2273 under HSScreenShotResult for DolbyAccess
	
@newHSAAudioForteMediaMicrophone
Scenario: VFC2273_TestStep19 Check uninstall driver Click Here it will jump to Microphone Store
	Given uninstall 'ForteMedia' Driver
	Given go to Audio section
	Given Scroll the Advanced microphone effects 
	Then  Click Here NoDolbyAccess
	Given wait 1 seconds
	When Take Screen Shot VFC2273_19uninstallnorefreshStoreForteMedia IN 2273 under HSScreenShotResult for NoForteMedia

@newHSAAudioForteMediaMicrophone
Scenario: VFC2273_TestStep20 Check refresh the page the UI of Advanced microphone effects should not change
	Given install 'ForteMedia' Driver
	Given go to Audio section
	Given Scroll the Advanced microphone effects 
	When  switch pages
	Then  the UI of Advanced microphone effects should not change
	
@newHSAAudioForteMediaMicrophone
Scenario: VFC2273_TestStep21 Check ReLaunch Vantage the UI of Advanced microphone effects should not change
	Given install 'ForteMedia' Driver
	Given go to Audio section
	Given Scroll the Advanced microphone effects 
	When  ReLaunch Vantage
	Given go to Audio section
	Given Scroll the Advanced microphone effects
	Then  the UI of Advanced microphone effects should not change
	
@newHSAAudioForteMediaMicrophone
Scenario: VFC2273_TestStep22 Check resize Vantage the UI of Advanced microphone effects should not change
	Given install 'ForteMedia' Driver
	Given go to Audio section
	Given Scroll the Advanced microphone effects 
	When  resize Vantage
	Then  the UI of Advanced microphone effects should not change	

@newHSAAudioForteMediaMicrophone
Scenario: VFC2273_TestStep25 Check UI of Advanced microphone effects should be shown within 2 seconds
	Given install 'ForteMedia' Driver
	Given go to Audio section
	Given Scroll the Advanced microphone effects 
	Then  the UI of Advanced microphone effects should be shown within 2 seconds
	
@newHSAAudioForteMediaMicrophone
Scenario: VFC2273_TestStep26 Check  the UI of Advanced microphone effects should be shown within 2 seconds
	Given install 'ForteMedia' Driver
	Given go to Audio section
	Given Scroll the Advanced microphone effects 
	Given Change DPI to 100
	Then  the UI of Advanced microphone effects should not change
	Given Change DPI to 150