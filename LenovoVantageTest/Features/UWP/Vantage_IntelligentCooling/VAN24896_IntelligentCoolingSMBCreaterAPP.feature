Feature: VAN24896_IntelligentCoolingSMBCreaterAPP
	Test Case:https://jira.tc.lenovo.com/browse/VAN-24896
	Developer:wenyang

@ITS4SMBUI_Unsupport  
Scenario: VAN24896_TestStep01_Check the ITS feature is normally dispaly
	When Click the Power icon
	When Check Open Power page
	Then Check Intelligent Cooling show for ITS3

@ITS4SMBUI  @ITSSmokeITS4SMB
Scenario: VAN24896_TestStep02_Check the ITS feature in Power page hide
	Given Go to Power Page
	Then Check Intelligent Cooling hide for ITS4

@ITS4SMBUI  @ITSSmokeITS4SMB
Scenario: VAN24896_TestStep03_Check the ITS title 
	Given Go to Productivity Creator settings Page
	Then Check Intelligent Performance Title
	
@ITS4SMBUI  @ITSSmokeITS4SMB
Scenario: VAN24896_TestStep04_Check the description 
	Given Go to Productivity Creator settings Page
	Then Check Intelligent CoolingDesc Text for ITS4

@ITS4SMBUI
Scenario: VAN24896_TestStep05_Check Intelligent Cooling description 
	Given Go to Productivity Creator settings Page
	Given Waiting 2 seconds
	When change ITS mode to ISTD via Vantage
	Then Check Intelligent CoolingDesc Text for ITS4ICM

@ITS4SMBUI
Scenario: VAN24896_TestStep06_Check Extreme Performance description
	Given Go to Productivity Creator settings Page
	Given Waiting 2 seconds
	When change ITS mode to EPM via Vantage
	Then Check Intelligent CoolingDesc Text for ITS4EPM

@ITS4SMBUI
Scenario: VAN24896_TestStep07_Check Battery Saving description
	Given Go to Productivity Creator settings Page
	Given Waiting 2 seconds
	When change ITS mode to BSM via Vantage
	Then Check Intelligent CoolingDesc Text for ITS4BSM

@ITS4SMBUI
Scenario: VAN24896_TestStep08_Check EPM is selected via toolbar
    Given turn on narrator
	Given launch toolbar
	Given change ITS mode to EPM via Toolbar
	Given into Dashboard page
	Given Waiting 2 seconds
	Given Go to Productivity Creator settings Page
	Then Vantage ITS EPM On

@ITS4SMBUI
Scenario: VAN24896_TestStep09_Check ICM is selected via toolbar
    Given launch toolbar
	Given change ITS mode to ICM via Toolbar
	Given into Dashboard page
	Given Waiting 2 seconds
	Given Go to Productivity Creator settings Page
	Then Vantage ITS ICM On

@ITS4SMBUI
Scenario: VAN24896_TestStep10_Check BSM is selected via toolbar
    Given launch toolbar
	Given change ITS mode to BSM via Toolbar
	Given into Dashboard page
	Given Waiting 2 seconds
	Given Go to Productivity Creator settings Page
	Then Vantage ITS BSM On

@ITS4SMBUI
Scenario: VAN24896_TestStep11_Select EPM via Toolbar and check sync
	Given Go to Productivity Creator settings Page
	Given launch toolbar
	Given change ITS mode to EPM via Toolbar
	Given wait 30 seconds
	Then Vantage ITS EPM On

@ITS4SMBUI
Scenario: VAN24896_TestStep12_Select ICM via Toolbar and check sync
	Given Go to Productivity Creator settings Page
	Given launch toolbar
	Given change ITS mode to ICM via Toolbar
	Given wait 30 seconds
	Then Vantage ITS ICM On

@ITS4SMBUI
Scenario: VAN24896_TestStep13_Select BSM via Toolbar and check sync
	Given Go to Productivity Creator settings Page
	Given launch toolbar
	Given change ITS mode to BSM via Toolbar
	Given wait 30 seconds
	Then Vantage ITS BSM On
	Given turn off narrator

@ITS4SMBUI
Scenario: VAN24896_TestStep17_Stop ITS service and Intelligent Cooling UI will hide
	Given turn off narrator
	Given Go to Productivity Creator settings Page
	Then Check Intelligent Cooling show for ITS4SMB
	Given Stop ITS service
	Given Go to Productivity Creator settings Page
	Then Check Intelligent Cooling hide for ITS4SMB
	Given Start ITS Service

@ITS4SMBUI
Scenario: VAN24896_TestStep18_Restart ITS service and reset to ICM
	Given Start ITS Service
	Given Go to Productivity Creator settings Page
	Given Waiting 2 seconds
	When change ITS mode to EPM via Vantage
	Given Restart ITS Service
	Given Waiting 2 seconds
	Given Go to Productivity Creator settings Page
	Then Vantage ITS ICM On

@ITS4SMBUI
Scenario: VAN24896_TestStep19_Restart ITS service and reset to ICM
	Given Go to Productivity Creator settings Page
	Given Waiting 2 seconds
	When change ITS mode to ICM via Vantage
	Given Restart ITS Service
	Given Waiting 2 seconds
	Given Go to Productivity Creator settings Page
	Then Vantage ITS ICM On

@ITS4SMBUI
Scenario: VAN24896_TestStep20_Restart ITS service and reset to ICM
	Given Go to Productivity Creator settings Page
	Given Waiting 2 seconds
	When change ITS mode to BSM via Vantage
	Given Restart ITS Service
	Given Waiting 2 seconds
	Given Go to Productivity Creator settings Page
	Then Vantage ITS ICM On

@ITS4SMBUI
Scenario: VAN24896_TestStep22_Delete ITS plugin and check UI hide
	Given Go to Productivity Creator settings Page
	Then Check Intelligent Cooling show for ITS4SMB
	Given moveplugin
	Given Go to Productivity Creator settings Page
	Then Check Intelligent Cooling hide for ITS4SMB
	Given recoverplugin

@ITS4SMBUI
Scenario: VAN24896_TestStep24_Check Intelligent Cooling UI with different DPI
	Given Go to Productivity Creator settings Page
	Given Change DPI to 100
	Then Take Screen Shot 2201 in 24896 under ITSScreenShotResult
	Given Change DPI to 125
	Then Take Screen Shot 2202 in 24896 under ITSScreenShotResult
	Given Change DPI to 150
	Then Take Screen Shot 2203 in 24896 under ITSScreenShotResult
	Given Change DPI to 175
	Then Take Screen Shot 2204 in 24896 under ITSScreenShotResult
	Given SetWindowSize to 928 2000
	Then Take Screen Shot 2205 in 24896 under ITSScreenShotResult
	Given Change DPI to recommend

@ITS4SMBUI
Scenario: VAN24896_TestStep25_Fast switching ITS mode the ITS work is OK
	Given Go to Productivity Creator settings Page
	Then Fast Switch ITS Mode

@ITS4SMBUI
Scenario: VAN24896_TestStep26_Turn off network and check ICM is selected
	When  The user connect or disconnect WiFi off lenovo
	Given Waiting 2 seconds
	Given Go to Productivity Creator settings Page
	When change ITS mode to ICM via Vantage
	Given Waiting 2 seconds
	Given Go to Productivity Creator settings Page
	Then Vantage ITS ICM On

@ITS4SMBUI
Scenario: VAN24896_TestStep27_Turn off network and check EPM is selected
	When  The user connect or disconnect WiFi off lenovo
	Given Waiting 2 seconds
	Given Go to Productivity Creator settings Page
	When change ITS mode to EPM via Vantage
	Given Waiting 2 seconds
	Given Go to Productivity Creator settings Page
	Then Vantage ITS EPM On

@ITS4SMBUI
Scenario: VAN24896_TestStep28_Turn off network and check BSM is selected
	When  The user connect or disconnect WiFi off lenovo
	Given Waiting 2 seconds
	Given Go to Productivity Creator settings Page
	When change ITS mode to BSM via Vantage
	Given Waiting 2 seconds
	Given Go to Productivity Creator settings Page
	Then Vantage ITS BSM On

@ITS4SMBUI
Scenario: VAN24896_TestStep29_Turn on network and check ICM is selected
	When  The user connect or disconnect WiFi on lenovo
	Given Waiting 2 seconds
	Given Go to Productivity Creator settings Page
	When change ITS mode to ICM via Vantage
	Given Waiting 2 seconds
	Given Go to Productivity Creator settings Page
	Then Vantage ITS ICM On

@ITS4SMBUI
Scenario: VAN24896_TestStep30_Turn on network and check EPM is selected
	Given Go to Productivity Creator settings Page
	When change ITS mode to EPM via Vantage
	Given Waiting 2 seconds
	Given Go to Productivity Creator settings Page
	Then Vantage ITS EPM On

@ITS4SMBUI
Scenario: VAN24896_TestStep31_Turn on network and check BSM is selected
	Given Go to Productivity Creator settings Page
	When change ITS mode to BSM via Vantage
	Given Waiting 2 seconds
	Given Go to Productivity Creator settings Page
	Then Vantage ITS BSM On

@ITS4SMBUI
Scenario: VAN24896_TestStep32_Reinstall Vantage and check EPM is keeped
	Given Go to Productivity Creator settings Page
	When change ITS mode to EPM via Vantage
	Given Install Vantage
	Given Waiting 2 seconds
	Given Go to Productivity Creator settings Page
	Then Vantage ITS EPM On

@ITS4SMBUI
Scenario: VAN24896_TestStep33_Reinstall Vantage and check ICM is keeped
	Given Go to Productivity Creator settings Page
	When change ITS mode to ICM via Vantage
	Given Install Vantage
	Given Waiting 2 seconds
	Given Go to Productivity Creator settings Page
	Then Vantage ITS ICM On

@ITS4SMBUI
Scenario: VAN24896_TestStep34_Reinstall Vantage and check BSM is keeped
	Given Go to Productivity Creator settings Page
	When change ITS mode to BSM via Vantage
	Given Install Vantage
	Given Waiting 2 seconds
	Given Go to Productivity Creator settings Page
	Then Vantage ITS BSM On

@ITS4SMBUI
Scenario: VAN24896_TestStep35_S3 and check mode is keeped
	Given Go to Productivity Creator settings Page
	When change ITS mode to ICM via Vantage
	When Enter sleep
	Given Go to Productivity Creator settings Page
	Then Vantage ITS ICM On

@ITS4SMBUI
Scenario: VAN24896_TestStep36_S4 and check mode is keeped
	Given Go to Productivity Creator settings Page
	When change ITS mode to BSM via Vantage
	When Enter hibernate
	Given Go to Productivity Creator settings Page
	Then Vantage ITS BSM On