Feature: VAN32593EnablePinToolBarToastForNewOS
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-32593
	Author： DaQi Fang

Background: 
	When unpin toolbar on Taskbar settings

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep31
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Pin to taskbar"
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "noshow" and "NoClick" in "newos"
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep32
	Given close lenovo vantage
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Learn More"
	Then Take Screen Shot  VAN32593Step32_CheckPOPupWindows_learnMorebutton in 32593 under ScreenShotResult
	Then PinToolBar "toast" should be Close
	Then PinToolBar Pop window show
	Then Click PinToolBar Pop window "close" button

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep33
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Learn More"
	Then Take Screen Shot  VAN32593Step33_CheckPOPupWindows_learnMorebutton in 32593 under ScreenShotResult
	Then PinToolBar "toast" should be Close
	Then PinToolBar Pop window show
	Then Click PinToolBar Pop window "pintoolbar" button
	Then PinToolBar "popup window" should be Close
	Then The toolbar is pin to taskbar
	Given Go to Power Page
	Then The PinToolBar toggle is "on"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep34
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Learn More"
	Then Take Screen Shot  VAN32593Step34_CheckPOPupWindows_learnMorebutton in 32593 under ScreenShotResult
	Then PinToolBar "toast" should be Close
	Then PinToolBar Pop window show
	Then Click PinToolBar Pop window "pintoolbar" button
	Then PinToolBar "popup window" should be Close
	Then The toolbar is pin to taskbar
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "noshow" and "NoClick" in "newos"
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep35
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Learn More"
	Then Take Screen Shot  VAN32593Step35_CheckPOPupWindows_learnMorebutton in 32593 under ScreenShotResult
	Then PinToolBar "toast" should be Close
	Then PinToolBar Pop window show
	Then Click PinToolBar Pop window "notnow" button
	Then PinToolBar "popup window" should be Close
	Given Go to Power Page
	Then The PinToolBar toggle is "off"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep36
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Learn More"
	Then Take Screen Shot  VAN32593Step36_CheckPOPupWindows_learnMorebutton in 32593 under ScreenShotResult
	Then PinToolBar "toast" should be Close
	Then PinToolBar Pop window show
	Then Click PinToolBar Pop window "notnow" button
	Then PinToolBar "popup window" should be Close
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep37
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Go to Power Page
	Given turn on toolbar btn
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "noshow" and "NoClick" in "newos"
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep38
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep39
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Pin to taskbar"
	Given Go to Power Page
	Then The PinToolBar toggle is "on"
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep40
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Pin to taskbar"
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "noshow" and "NoClick" in "newos"
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep41
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Learn More"
	Then Take Screen Shot  VAN32593Step41_CheckPOPupWindows_learnMorebutton in 32593 under ScreenShotResult
	Then PinToolBar "toast" should be Close
	Then PinToolBar Pop window show
	Then Click PinToolBar Pop window "close" button

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep42
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Learn More"
	Then Take Screen Shot  VAN32593Step42_CheckPOPupWindows_learnMorebutton in 32593 under ScreenShotResult
	Then PinToolBar "toast" should be Close
	Then PinToolBar Pop window show
	Then Click PinToolBar Pop window "pintoolbar" button
	Then PinToolBar "popup window" should be Close
	Then The toolbar is pin to taskbar
	Given Go to Power Page
	Then The PinToolBar toggle is "on"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep43
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Learn More"
	Then Take Screen Shot  VAN32593Step43_CheckPOPupWindows_learnMorebutton in 32593 under ScreenShotResult
	Then PinToolBar "toast" should be Close
	Then PinToolBar Pop window show
	Then Click PinToolBar Pop window "pintoolbar" button
	Then PinToolBar "popup window" should be Close
	Then The toolbar is pin to taskbar
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "noshow" and "NoClick" in "newos"
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep44
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Learn More"
	Then Take Screen Shot  VAN32593Step44_CheckPOPupWindows_learnMorebutton in 32593 under ScreenShotResult
	Then PinToolBar "toast" should be Close
	Then PinToolBar Pop window show
	Then Click PinToolBar Pop window "notnow" button
	Then PinToolBar "popup window" should be Close
	Given Go to Power Page
	Then The PinToolBar toggle is "off"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep45
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Learn More"
	Then Take Screen Shot  VAN32593Step45_CheckPOPupWindows_learnMorebutton in 32593 under ScreenShotResult
	Then PinToolBar "toast" should be Close
	Then PinToolBar Pop window show
	Then Click PinToolBar Pop window "notnow" button
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep46
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	Given Uninstall the lenovo vatage
	Given Install the Lenovo Vantage Without Launch Vantage
	Given Launch vantage without OOBE
	Given Unselect the Enable the lenovo vantage toolbar on oobe
	Given Close Vantage
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 1 Days Later
	When Enter hibernate
	When Go to Power Page
	Given "open" pintoolbar toggle in powerpage
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given PinToolBar Toast is "noshow" and "NoClick" in "newos"
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep47
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep48
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Pin to taskbar"
	Then PinToolBar "toast" should be Close
	Then The toolbar is pin to taskbar
	Given Go to Power Page
	Then The PinToolBar toggle is "on"
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep49
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Pin to taskbar"
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given PinToolBar Toast is "noshow" and "NoClick" in "newos"
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep50
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Learn More"
	Then Take Screen Shot  VAN32593Step50_CheckPOPupWindows_learnMorebutton in 32593 under ScreenShotResult
	Then PinToolBar "toast" should be Close
	Then PinToolBar Pop window show
	Then Click PinToolBar Pop window "close" button
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep51
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Learn More"
	Then Take Screen Shot  VAN32593Step51_CheckToolbarFunnelPicture in 32593 under ScreenShotResult
	Then PinToolBar "toast" should be Close
	Then PinToolBar Pop window show
	Then Click PinToolBar Pop window "pintoolbar" button
	Then PinToolBar "popup window" should be Close
	Then The toolbar is pin to taskbar
	Given Go to Power Page
	Then The PinToolBar toggle is "on"
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep52
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Learn More"
	Then Take Screen Shot  VAN32593Step52_CheckToolbarFunnelPicture in 32593 under ScreenShotResult
	Then PinToolBar "toast" should be Close
	Then PinToolBar Pop window show
	Then Click PinToolBar Pop window "pintoolbar" button
	Then PinToolBar "popup window" should be Close
	Then The toolbar is pin to taskbar
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "noshow" and "NoClick" in "newos"
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep53
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Learn More"
	Then Take Screen Shot  VAN32593Step53_CheckToolbarFunnelPicture in 32593 under ScreenShotResult
	Then PinToolBar "toast" should be Close
	Then Click PinToolBar Pop window "notnow" button
	Then PinToolBar "popup window" should be Close
	Given Go to Power Page
	Then The PinToolBar toggle is "off"
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep54
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Learn More"
	Then PinToolBar "toast" should be Close
	Then Click PinToolBar Pop window "notnow" button 
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "noshow" and "NoClick" in "newos"
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep55
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "NoClick" in "newos"
	Given Close the PinToolBarToast
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "noshow" and "NoClick" in "newos"
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
Scenario: VAN32593_TestStep56
	Given Pin toolbar to taskbar
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "noshow" and "NoClick" in "normalos"
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep57
	Given Pin toolbar to taskbar
    When unpin toolbar on Taskbar settings
	Given Adjust The System Time To 8 Days Later
	When Enter hibernate
	Given Launch Winappdriver
	Given PinToolBar Toast is "noshow" and "NoClick" in "normalos"
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep59
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Then Check PinToolBar Toast message
	Then Take Screen Shot  VAN32593Step59CheckToolBarUI in 32593 under ScreenShotResult
	Given Set Time to "Sync"
	
@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep60
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Learn More"
	Then Take Screen Shot  VAN32593Step60_CheckToolbarFunnelPicture in 32593 under ScreenShotResult
	Then PinToolBar "toast" should be Close
	Then PinToolBar Pop window show
	Then Click PinToolBar Pop window "close" button
	Then Take Screen Shot  VAN32593Step60_CheckToolbarGifPicture in 32593 under ScreenShotResult
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep61
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Learn More"
	Then PinToolBar "toast" should be Close
	Then PinToolBar Pop window show
	When Hover on PinToolBar Close button
	Then Take Screen Shot  VAN32593Step61_CheckPopUpWindowRedClosebutton in 32593 under ScreenShotResult
	Then Click PinToolBar Pop window "close" button
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep62
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Learn More"
	Then PinToolBar "toast" should be Close
	Then PinToolBar Pop window show
	Then Click PinToolBar Pop window "close" button
	Then PinToolBar "popup window" should be Close
	Given Set Time to "Sync"

@EnablePinToolBarToastForNewOS
Scenario: VAN32593_TestStep64
	Given Del PinToolBar Toast Regedit
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service 
	When Restart Vantage Service
	Given wait 5 seconds
	When Enter hibernate	
	Given Launch Winappdriver
	Given PinToolBar Toast is "show" and "Click" in "newos"
	Given Click PinToolBar Toast button "Learn More"
	Then PinToolBar Pop window show
	Given Change DPI to 200
	Then Take Screen Shot  VAN32593Step64_CheckChangeDpiPopUpWindow in 32593 under ScreenShotResult
	Given Change DPI to recommend
	Given change resolution 1600 to 900
	Then Take Screen Shot  VAN32593Step64_CheckChangeResolutionPopUpWindow in 32593 under ScreenShotResult
	Given change resolution 1920 to 1080
	Then Click PinToolBar Pop window "close" button
	Then PinToolBar "popup window" should be Close
	Given Set Time to "Sync"