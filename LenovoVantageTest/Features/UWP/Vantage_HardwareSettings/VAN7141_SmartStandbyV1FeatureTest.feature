Feature: VAN7141_VFC183_SmartStandbyV1FeatureTest
	Test Case: https://jira.tc.lenovo.com/browse/VAN-7141
	Author：Jia Jingting
	Updater: Fangdq

@SmartStandbyV1
Scenario: VAN7141_TestStep01_The value about the Smart Standby toggle should be the same with regedit value
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	Then Check the Smart Standby toggle state

@SmartStandbyV1
Scenario: VAN7141_TestStep02_The value about the Smart Standby Start Time should be the same with regedit value
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	Then Check the Smart Standby Start Time

@SmartStandbyV1
Scenario: VAN7141_TestStep03_The value about the Smart Standby End Time should be the same with regedit value
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	Then Check the Smart Standby End Time

@SmartStandbyV1
Scenario: VAN7141_TestStep04_The value about the Smart Standby Schedule Days should be the same with regedit value
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	Then Check the Smart Standby Schedule Days

@SmartStandbyV1
Scenario: VAN7141_TestStep05_The Start End Drop-down list part should follow the UISPEC
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	Then Check the DropDown List

@SmartStandbyV1
Scenario: VAN7141_TestStep06_The Start End Hours should from 1 to 12
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	Then Check the DropDown Hours Value range

@SmartStandbyV1
Scenario: VAN7141_TestStep07_The Start End Minutes should from 00 to 45
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	Then Check the DropDown Minutes Value range

@SmartStandbyV1
Scenario: VAN7141_TestStep08_The Start End AMPM value is AM and PM
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	Then Check the DropDown AMPM Value range

@SmartStandbyV1
Scenario: VAN7141_TestStep09_The Start set new value and cutpage and relaugh
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Set a new Smart Standby Schedule "1.0" and "save"
	When Get current message
	When Turn off Smart Standby Version Two toggle
	Then The SmartStandby value in regedit new value
	Given Go to dashboad page
	Given Go to Power Page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	Then The SmartStandby value is new value
	Then Check the Smart Standby Start Time
	Then Check the Smart Standby End Time
	Then Check the Smart Standby Schedule Days
	When ReLaunch Vantage
	Given Go to Power Page
	When Go to Smart Standby section
	Then The SmartStandby value is new value
	Then Check the Smart Standby Start Time
	Then Check the Smart Standby End Time
	Then Check the Smart Standby Schedule Days

@SmartStandbyV1
Scenario: VAN7141_TestStep10_The Start set new value and not save cutpage and relaugh
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Get current message
	When Set a new Smart Standby Schedule "1.0" and "notsave"
	Given Go to dashboad page
	Given Go to Power Page
	When Go to Smart Standby section
	Then The SmartStandby value is new value
	Then Check the Smart Standby Start Time
	Then Check the Smart Standby End Time
	Then Check the Smart Standby Schedule Days
	When ReLaunch Vantage
	Given Go to Power Page
	When Go to Smart Standby section
	Then The SmartStandby value is new value
	Then Check the Smart Standby Start Time
	Then Check the Smart Standby End Time
	Then Check the Smart Standby Schedule Days

@SmartStandbyV1
Scenario: VAN7141_TestStep11_Check Set More Then 20 Hours tip
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Set a More Than 20 Hours Time
	Then There is a more than 20 Hours tip

@SmartStandbyV1
Scenario: VAN7141_TestStep12_Click menu and check pop window
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Click dropdown menu pop a window

@SmartStandbyV1
Scenario: VAN7141_TestStep13_Smart Standby schedule Queue
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Click ScheduledayDropdownist
	Then The Order of Date follow the UISPEC
	Then Take Screen Shot 13 in 7141 under HSScreenShotResult

@SmartStandbyV1
Scenario: VAN7141_TestStep14_Checked Monday to saturday and the display is weekdays,sat
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Uncheck any day
	When Checked Weeks and "save"
	|sunday  | monday | tuesday | wednesday | thursday | friday | saturday |
	|no      | monday | tuesday | wednesday | thursday | friday | saturday |
	Then Ui display "Weekdays, Sat" The Regedit is "2"

@SmartStandbyV1
Scenario: VAN7141_TestStep15_Checked Sunday to Saturday and the display is weekends
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Uncheck any day
	When Checked Weeks and "save"
	|sunday  | monday | tuesday | wednesday | thursday | friday | saturday |
	|sunday  | no     | no      | no        | no       | no     | saturday |
	Then Ui display "Weekends" The Regedit is "124"

@SmartStandbyV1
Scenario: VAN7141_TestStep16_Checked Monday Tuesday Saturday and the display is Mon, Tue,Sat
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Uncheck any day
	When Checked Weeks and "save"
	|sunday  | monday | tuesday | wednesday | thursday | friday | saturday |
	|no      | monday | tuesday | no        | no       | no     | saturday |
	Then Ui display "Mon, Tue, Sat" The Regedit is "114"

@SmartStandbyV1
Scenario: VAN7141_TestStep17_Checked Everyday and the display is Everyday
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Uncheck any day
	When Checked Weeks and "save"
	|sunday  | monday | tuesday | wednesday | thursday | friday | saturday |
	|sunday  | monday | tuesday | wednesday | thursday | friday | saturday |
	Then Ui display "Everyday" The Regedit is "0"

@SmartStandbyV1
Scenario: VAN7141_TestStep18_Checked but not save the value is previous value
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Get current message
	When Uncheck any day
	When Checked Weeks and "nosave"
	|sunday  | monday | tuesday | wednesday | thursday | friday | saturday |
	|sunday  | no     | tuesday | no        | thursday | friday | no       |
	Then The day menu will display previous value

@SmartStandbyV1
Scenario: VAN7141_TestStep19_Smart Standby User uncheck any day there is not find v button
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Uncheck any day
	Then There is not find v botton

@SmartStandbyV1
Scenario: VAN7141_TestStep20_Smart Standby User uncheck any day there is a any day tip
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Uncheck any day
	Then There is a any day tip

@SmartStandbyV1
Scenario: VAN7141_TestStep21_Turn off the Smart Standby toggle all the element is hidden
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn off Smart Standby Version Two toggle
	Then All the element will hidden

@SmartStandbyV1
Scenario: VAN7141_TestStep22_Turn on the Smart Standby toggle all the value will same
	Given Machine Support Smart Standby 1.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Get current message
	When Turn off Smart Standby Version Two toggle
	When Turn on Smart Standby Version Two toggle
	Then The SmartStandby value is new value
	Then Check the Smart Standby Start Time
	Then Check the Smart Standby End Time
	Then Check the Smart Standby Schedule Days