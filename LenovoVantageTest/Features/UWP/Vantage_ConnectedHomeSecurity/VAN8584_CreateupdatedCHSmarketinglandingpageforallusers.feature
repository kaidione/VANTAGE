Feature: VAN8584_CreateupdatedCHSmarketinglandingpageforallusers
	Test Case：https://jira.tc.lenovo.com/browse/VAN-8584
	Author ：yangyu

@CreateupdatedCHSmarketinglandingpageforallusers
Scenario: VAN8584_TestStep01_Check there will be a new CHS tab
	Given Set Windows First Language "en-US"
	Given Close Vantage
	Given Launch Vantage
	When Click CHS "Security" Button
	Then There Will be "have" CHS Tab

@CreateupdatedCHSmarketinglandingpageforallusers
Scenario: VAN8584_TestStep02_Check step1 met then click CHS tab go to CHS marketing page
	When Check CHS Subpage
	Given Location for Vantage has been Enabled
	Given OOBE CHS
	Then It Will Directly Go to CHS Marketing Page
	Then Take Screen Shot 09UI in 8584 under CHScreenShotResul
	
@CreateupdatedCHSmarketinglandingpageforallusers
Scenario: VAN8584_TestStep03_Check language is not EN will be no CHS tab
	Given Set Windows First Language "zh-CN"
	Given Close Vantage
	Given Launch Vantage
	When Click CHS "Security" Button
	Then There Will be "no" CHS Tab
	Given Set Windows First Language "en-US"

@CreateupdatedCHSmarketinglandingpageforallusers
Scenario: VAN8584_TestStep04_Check Region is not EN will be no CHS tab
	Given Set Windows First Language "en-US"
	Given Set Windows Region "45"
	Given Close Vantage
	Given Launch Vantage
	When Click CHS "Security" Button
	Then There Will be "no" CHS Tab
	Given Set Windows Region "244"

@CreateupdatedCHSmarketinglandingpageforallusers
Scenario: VAN8584_TestStep05_Check language is not EN Region is not EN will be no CHS tab
	Given Turn off Location Service in Settings Page
	Given Set Windows Region "45"
	Given Set Windows First Language "zh-CN"
	Given Close Vantage
	Given Launch Vantage
	When Click CHS "Security" Button
	Then There Will be "no" CHS Tab
	Given Set Windows Region "244"
	Given Set Windows First Language "en-US"

@CreateupdatedCHSmarketinglandingpageforallusers
Scenario: VAN8584_TestStep06_Check Offline will be normal display CHS tab
	Given Set Windows Region "244"
	Given Set Windows First Language "en-US"
	When The user connect or disconnect WiFi off lenovo
	Given Close Vantage
	Given Launch Vantage
	When Click CHS "Security" Button
	Then There Will be "have" CHS Tab
	When The user connect or disconnect WiFi on lenovo

@CreateupdatedCHSmarketinglandingpageforallusers
Scenario: VAN8584_TestStep07_Check 500*500 size
	When The user connect or disconnect WiFi on lenovo
	When Check CHS Subpage
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 500   | 500    |           |            |
	Then Take Screen Shot 01UI in 8584 under CHScreenShotResult
	Given Slide The Page To "-100"
	Then Take Screen Shot 02UI in 8584 under CHScreenShotResul
	Given Slide The Page To "-100"
	Then Take Screen Shot 03UI in 8584 under CHScreenShotResul
	Given Slide The Page To "-100"
	Then Take Screen Shot 04UI in 8584 under CHScreenShotResul
	Given Slide The Page To "-100"
	Then Take Screen Shot 05UI in 8584 under CHScreenShotResul

@CreateupdatedCHSmarketinglandingpageforallusers
Scenario: VAN8584_TestStep08_Check 1000*1000 size
	Then Kill chrome.exe Process
	Then Kill chromedriver.exe Process
	When Check CHS Subpage
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 1000  | 1000   |           |            |
	Then Take Screen Shot 06UI in 8584 under CHScreenShotResult
	Given Slide The Page To "-100"
	Then Take Screen Shot 07UI in 8584 under CHScreenShotResul
	Given Slide The Page To "-100"
	Then Take Screen Shot 08UI in 8584 under CHScreenShotResul

