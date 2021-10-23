Feature: VAN5935_GamingDolbyTest
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-5935
	Author： Wenhuan Zhang

Background: 
    Given Machine is Gaming

@GamingUnSupportDolbyTest @C730 @GamingSmokeNoDolby
Scenario: VAN5935_TestStep01_Check Dolby not display on unsupported machine
	Then Dolby is displayed no

@GamingDolbyTest @Y550 @GamingSmokeDolby
Scenario: VAN5935_TestStep02_Check Dolby display on supported machine and gear icon is before the dobly toggle
	Then Dolby is displayed exist
	Then Dolby gear icon is displayed before the Dobly toggle	

@GamingDolbyTest @Y550 	
Scenario: VAN5935_TestStep03_Check Dolby toggle status is consistent with audio page
	Then Dolby is displayed exist
	Then Dolby toggle status on homepage is consistent with audio page

@GamingDolbyTest @Y550 
Scenario: VAN5935_TestStep04_Dobly toggle status is change on homepage
	Then Dolby is displayed exist
	When Switch Dobly toggle homepage
	Then Dobly toggle status is changed on homepage

@GamingDolbyTest @Y550 
Scenario: VAN5935_TestStep05_Dobly toggle status is not changed after reopening vantage
	Then Dolby is displayed exist
	When Switch Dobly toggle homepage
	Then Dobly toggle status is changed on homepage
	#When Reopen Vantage
	When ReLaunch Vantage
	Then Dobly toggle status is not changed

@GamingDolbyTest @Y550 
Scenario: VAN5935_TestStep06_Dobly toggle status is not changed after return other subpage
	Then Dolby is displayed exist
	When Switch Dobly toggle homepage
	Then Dobly toggle status is changed on homepage
	When Enter to other subpage
	When Click Y link
	Then Dobly toggle status is not changed

@GamingDolbyTest @Y550 
Scenario: VAN5935_TestStep07_Dobly toggle status in audio page is consistent with homepage
	Then Dolby is displayed exist
	When Switch Dobly toggle homepage
	Then Dobly toggle status is changed on homepage
	When Click Dobly gear icon
	Then My Device settings-Audio page is opened
	Then Dobly audio page toggle status is consistent with homepage

@GamingDolbyTest @Y550 
Scenario: VAN5935_TestStep08_Dobly toggle status on audio page is changed
	Then Dolby is displayed exist
	When Click Dobly gear icon
	Then My Device settings-Audio page is opened
	When Switch Dobly toggle audiopage
	Then Dobly toggle status on audio page is changed

@GamingDolbyTest @Y550 
Scenario: VAN5935_TestStep09_Dobly toggle status in homepage is consistent with audio page
	Then Dolby is displayed exist
	When Click Dobly gear icon
	Then My Device settings-Audio page is opened
	When Switch Dobly toggle audiopage
	Then Dobly toggle status on audio page is changed
	When Click Y link
	Then Dobly toggle status is consistent with audio page