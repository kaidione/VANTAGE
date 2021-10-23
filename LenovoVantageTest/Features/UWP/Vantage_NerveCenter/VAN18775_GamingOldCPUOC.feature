@EnableInternet
Feature: VAN18775_GamingOldCPUOC
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-18775
	Author： Wei Xu

Background:
	Given Machine is Gaming
    Given driver is installed
	When kill Wow and wait 3 second

@GamingOLdCPUOC @GamingSmokeOldCPUOC
Scenario: VAN18775_TestStep01_Old CPU OverClocking Toggle Default Status Is Off
	Given The Machine support Specific function 'CPUOverclockOld'
	Then CPU OC Off should be shown in the CPU OverClocking area

@GamingOLdCPUOC @GamingSmokeOldCPUOC
Scenario: VAN18775_TestStep03_CPU OverClocking Dropdown Menu Is Displayed
	Given The Machine support Specific function 'CPUOverclockOld'
	When Install 'CPU' Driver
	Given Close Vantage
	Given Launch Vantage
	When Click CPU OverClocking area
	Then CPU OverClocking Dropdown Menu should be shown
	Then Take Screen Shot CPU OverClocking Dropdown Menu in 18775 under GamingScreenShotResult

@GamingOLdCPUOC
Scenario: VAN18775_TestStep04_CPU OverClocking Three Items Are Displayed In Dropdown Menu
	Given The Machine support Specific function 'CPUOverclockOld'
	When Click CPU OverClocking area
	Then CPU OverClocking Three Items Are Displayed In Dropdown Menu

@GamingOLdCPUOC
Scenario: VAN18775_TestStep06_CPU OverClocking Dropdown Menu Is Closed
	Given The Machine support Specific function 'CPUOverclockOld'
	When Click CPU OverClocking area
	When Click the Minimize
	When ReLaunch Vantage
	Then CPU OverClocking Dropdown Menu should be shown

@GamingOLdCPUOC
Scenario: VAN18775_TestStep07_CPU OverClocking Dropdown Menu Is Closed
	Given The Machine support Specific function 'CPUOverclockOld'
	When Click CPU OverClocking area
	When Click the OC On item in the CPU OverClocking dropdown menu
	Then CPU OverClocking Dropdown Menu Is Closed

@GamingOLdCPUOC
Scenario: VAN18775_TestStep08_CPU OverClocking On Is Displayed In Dropdown Menu
	Given The Machine support Specific function 'CPUOverclockOld'
	When Click CPU OverClocking area
	When Click the OC On item in the CPU OverClocking dropdown menu
	Then CPU OC On should be shown in the CPU OverClocking area

@GamingOLdCPUOC
Scenario: VAN18775_TestStep09_OC Value Should Be Shown In The XTU Tool When OC Is On
	Given The Machine support Specific function 'CPUOverclockOld'
	When Click CPU OverClocking area
	When Click the OC On item in the CPU OverClocking dropdown menu
	Given Open the XTU and GPU OC tool
	Given Support Xtu
	When Check the OC values in the tools
	When wait 20 seconds
	Then It will display yes OC values

@GamingOLdCPUOC
Scenario: VAN18775_TestStep10_OC Value Should Be Shown In The XTU Tool When OC Is On With Running Game
	Given The Machine support Specific function 'CPUOverclockOld'
	When Click CPU OverClocking area
	When Click the OC On item in the CPU OverClocking dropdown menu
	When Launch the specifie game GameWorldOfWarcraft
	Given Open the XTU and GPU OC tool
	Given Support Xtu
	When Check the OC values in the tools
	When wait 20 seconds
	Then It will display yes OC values

@GamingOLdCPUOC
Scenario: VAN18775_TestStep11_OC Value Should Be Shown In The XTU Tool When OC Is On Without Running Game
	Given The Machine support Specific function 'CPUOverclockOld'
	When Click CPU OverClocking area
	When Click the OC On item in the CPU OverClocking dropdown menu
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 3 second
	Given Open the XTU and GPU OC tool
	Given Support Xtu
	When Check the OC values in the tools
	When wait 20 seconds
	Then It will display yes OC values

@GamingOLdCPUOC
Scenario: VAN18775_TestStep12_CPU OverClocking Dropdown Menu Is Closed
	Given The Machine support Specific function 'CPUOverclockOld'
	When Click CPU OverClocking area
	When Click the When Gaming item in the CPU OverClocking dropdown menu
	Then CPU OverClocking Dropdown Menu Is Closed

@GamingOLdCPUOC
Scenario: VAN18775_TestStep13_CPU OverClocking When Gaming Is Displayed In Dropdown Menu
	Given The Machine support Specific function 'CPUOverclockOld'
	When Click CPU OverClocking area
	When Click the When Gaming item in the CPU OverClocking dropdown menu
	Then CPU OC When Gaming should be shown in the CPU OverClocking area

@GamingOLdCPUOC
Scenario: VAN18775_TestStep14_OC Value Should Not Be Shown In The XTU Tool When OC Is When Gaming Without Running Game
	Given The Machine support Specific function 'CPUOverclockOld'
	When Click CPU OverClocking area
	When Click the When Gaming item in the CPU OverClocking dropdown menu
	Given Open the XTU and GPU OC tool
	Given Support Xtu
	When wait 20 seconds
	Then It will display not OC values

@GamingOLdCPUOC
Scenario: VAN18775_TestStep15_OC Value Should Be Shown In The XTU Tool When OC Is When Gaming With Running Game
	Given The Machine support Specific function 'CPUOverclockOld'
	When Click CPU OverClocking area
	When Click the When Gaming item in the CPU OverClocking dropdown menu
	When Launch the specifie game GameWorldOfWarcraft
	Given Open the XTU and GPU OC tool
	Given Support Xtu
	When wait 20 seconds
	Then It will display yes OC values

@GamingOLdCPUOC
Scenario: VAN18775_TestStep16_OC Value Should Not Be Shown In The XTU Tool When OC Is When Gaming Without Running Game
	Given The Machine support Specific function 'CPUOverclockOld'
	When Click CPU OverClocking area
	When Click the When Gaming item in the CPU OverClocking dropdown menu
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 3 second
	Given Open the XTU and GPU OC tool
	Given Support Xtu
	When wait 20 seconds
	Then It will display not OC values

@GamingOLdCPUOC
Scenario: VAN18775_TestStep17_CPU OverClocking Dropdown Menu Is Closed
	Given The Machine support Specific function 'CPUOverclockOld'
	When Click CPU OverClocking area
	When Click the Off item in the CPU OverClocking dropdown menu
	Then CPU OverClocking Dropdown Menu Is Closed

@GamingOLdCPUOC
Scenario: VAN18775_TestStep18_CPU OverClocking Off Is Displayed In Dropdown Menu
	Given The Machine support Specific function 'CPUOverclockOld'
	When Click CPU OverClocking area
	When Click the Off item in the CPU OverClocking dropdown menu
	Then CPU OC Off should be shown in the CPU OverClocking area

@GamingOLdCPUOC
Scenario: VAN18775_TestStep19_OC Value Should Not Be Shown In The XTU Tool When OC Is Off
	Given The Machine support Specific function 'CPUOverclockOld'
	When Click CPU OverClocking area
	When Click the Off item in the CPU OverClocking dropdown menu
	Given Open the XTU and GPU OC tool
	Given Support Xtu
	When wait 20 seconds
	Then It will display not OC values

@GamingOLdCPUOC
Scenario: VAN18775_TestStep20_OC Value Should Not Be Shown In The XTU Tool When OC Is Off With Running Game
	Given The Machine support Specific function 'CPUOverclockOld'
	When Click CPU OverClocking area
	When Click the Off item in the CPU OverClocking dropdown menu
	When Launch the specifie game GameWorldOfWarcraft
	Given Open the XTU and GPU OC tool
	Given Support Xtu
	When wait 20 seconds
	Then It will display not OC values

@GamingOLdCPUOC
Scenario: VAN18775_TestStep21_OC Value Should Not Be Shown In The XTU Tool When OC Is Off Without Running Game
	Given The Machine support Specific function 'CPUOverclockOld'
	When Click CPU OverClocking area
	When Click the Off item in the CPU OverClocking dropdown menu
	When Launch the specifie game GameWorldOfWarcraft
	When kill Wow and wait 3 second
	Given Open the XTU and GPU OC tool
	Given Support Xtu
	When wait 20 seconds
	Then It will display not OC values

@GamingOLdCPUOCNoWifi
Scenario: VAN18775_TestStep22_Disable Ethernet 
	Given The Machine support Specific function 'CPUOverclockOld'
	Given Record the Overclocking Status
	Given Disable Ethernet
	Given ReLaunch Vantage
	Then Overclocking Status shoule be consistent with the last change
	When Connect Internet

@GamingOLdCPUOC
Scenario: VAN18775_TestStep23_Enter to Other Page
	Given The Machine support Specific function 'CPUOverclockOld'
	Given Record the Overclocking Status
	When Enter Auto Close page
	When Back to the homepage
	Then Overclocking Status shoule be consistent with the last change

@GamingOLdCPUOC
Scenario: VAN18775_TestStep24_Reopen Vantage
	Given The Machine support Specific function 'CPUOverclockOld'
	Given Record the Overclocking Status
	When Close Vantage
	When ReLaunch Vantage
	Then Overclocking Status shoule be consistent with the last change