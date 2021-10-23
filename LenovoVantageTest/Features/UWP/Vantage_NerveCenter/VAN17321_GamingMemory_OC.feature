@EnableInternet
Feature: VAN17321_GamingMemory_OC
Test Case： https://jira.tc.lenovo.com/browse/VAN-17321
	Author：Xiang Tian

Background:
	Given Machine is Gaming 

@GamingMemoryOCOfftest @GamingSmokeRAMOCOff
Scenario: VAN17321_TestStep01_RAM Toggle status should be off
	Given Launch Vantage
	Then RAM Toggle status should be off

@GamingMemoryOCOfftest @GamingSmokeRAMOCOff
Scenario: VAN17321_TestStep02_Then RAM value in the tool should not be OC value and the value is less than 3000
	Then RAM Toggle status should be off
	Given Get_MemorySpeed
	Then  RAM value in the tool should not be OC value and the value is less than 3000

@GamingMemoryOCOfftest @GamingSmokeRAMOCOff
Scenario: VAN17321_TestStep03_Reboot popup window should be shown and toggle status should not be changed
	Given RAM toggle status is off
	Given Click the RAM toggle_off
	Then Reboot popup window should be shown and toggle status should not be changed

@GamingMemoryOCOfftest
Scenario: VAN17321_TestStep04_RAM toggle status should be off.
	Given RAM toggle status is off
	Given Click the RAM toggle_off
	Given Click the OK Button
	Then RAM toggle status should be off

@GamingMemoryOCOfftest
Scenario:VAN17321_TestStep05_RAM value in the tool should not be OC value and the value is less than 3000
    Given RAM toggle status is off
	Given Click the RAM toggle_off
	Given Click the OK Button
	Given Get_MemorySpeed
	Then  RAM value in the tool should not be OC value and the value is less than 3000

@GamingMemoryOCOfftest
Scenario: VAN17321_TestStep06_RAM toggle status should be off.
	Given RAM toggle status is off
	Given Click the RAM toggle_off
	Given Click the X Button
	Then RAM toggle status should be off

@GamingMemoryOCOfftest
Scenario:VAN17321_TestStep07_Then  RAM value in the tool should not be OC value and the value is less than 3000
	Given RAM toggle status is off
	Given Click the RAM toggle_off
	Given Click the X Button
	Given Get_MemorySpeed
	Then  RAM value in the tool should not be OC value and the value is less than 3000

@GamingMemoryOCtestRestartNeed
Scenario: VAN17321_TestStep08_Click the OK Button and RAM toggle status should be changed to ON
	Given RAM toggle status is off
	Given Click the RAM toggle_off
	Given Click the OK Button
	When enter hibernate
	Then RAM toggle status should be changed to ON

@GamingMemoryOCtestRestartNeed
Scenario:VAN17321_TestStep09_RAM value in the tool should be OC value and the value is greater than 3000
	Given RAM toggle status is off
	Given Click the RAM toggle_off
	Given Click the OK Button
	When enter hibernate
	Given Get_MemorySpeed
	Then RAM value in the tool should be OC value and the value is greater than 3000

@GamingMemoryOCtestRestartNeed
Scenario: VAN17321_TestStep10_Click the X Button and RAM toggle status should be changed to ON
	Given Launch Vantage
	Given RAM toggle status is off
	Given Click the RAM toggle_off
	Given Click the X Button
	When enter hibernate
	Then RAM toggle status should be changed to ON

@GamingMemoryOCtestRestartNeed
Scenario:VAN17321_TestStep11_RAM value in the tool should be OC value and the value is greater than 3000
	Given RAM toggle status is off
	Given Click the RAM toggle_off
	Given Click the X Button
	When enter hibernate
	Given Get_MemorySpeed
	Then RAM value in the tool should be OC value and the value is greater than 3000

@GamingMemoryOCOntest
Scenario: VAN17321_TestStep12_popup window should be shown and toggle status should not be changed
	Given RAM toggle status is on
	Given Click the RAM toggle on
	Then popup window should be shown and toggle status is On

@GamingMemoryOCOntest @GamingSmokeRAMOCOn
Scenario:VAN17321_TestStep13_RAM value in the tool should be OC value  and the value is greater than 3000
	Given RAM toggle status is on
	Given Click the RAM toggle on
	Then 2RAM value in the tool should be OC value and the value is greater than 3000

@GamingMemoryOCOntest
Scenario: VAN17321_TestStep14_click okbtn and toggle_on status should not be changed
	Given Launch Vantage
	Given RAM toggle status is on
	Given Click the RAM toggle on
	Given Click the OK Button
	Then toggle_on status should not be changed

@GamingMemoryOCOntest
Scenario:VAN17321_TestStep15_RAM value in the tool should be OC value  and the value is greater than 3000
	Given RAM toggle status is on
	Given Click the RAM toggle on
	Given Click the OK Button
	Then RAM value in the tool should be OC value and the value is greater than 3000

@GamingMemoryOCOntest
Scenario: VAN17321_TestStep16_click XBtn and toggle_on status should not be changed
	Given Launch Vantage
	Given RAM toggle status is on
	Given Click the RAM toggle on
	Given Click the X Button
	Then toggle_on status should not be changed

@GamingMemoryOCOntest
Scenario:VAN17321_TestStep17_RAM value in the tool should be OC value and the value is greater than 3000
	Given RAM toggle status is on
	Given Click the RAM toggle on
	Given Click the X Button
    Then RAM value in the tool should be OC value and the value is greater than 3000

@GamingMemoryOCtestRestartNeed
Scenario: VAN17321_TestStep18_click okBtn and RAM toggle status should be changed to OFF
	Given Launch Vantage
	Given RAM toggle status is on
	Given Click the RAM toggle on
	Given Click the OK Button
    When enter hibernate
    Then RAM toggle status should be off

@GamingMemoryOCtestRestartNeed
Scenario:VAN17321_TestStep19_RAM value in the tool should not be OC value and the value is less than 3000
	Given RAM toggle status is on
	Given Click the RAM toggle on
	Given Click the OK Button
	When enter hibernate
    Then RAM value in the tool should not be OC value and the value is less than 3000

@GamingMemoryOCtestRestartNeed
Scenario: VAN17321_TestStep20_click XBtn and RAM toggle status should be changed to OFF
	Given Launch Vantage
	Given RAM toggle status is on
	Given Click the RAM toggle on
	Given Click the X Button
    When enter hibernate
    Then RAM toggle status should be off

@GamingMemoryOCtestRestartNeed
Scenario:VAN17321_TestStep21_RAM value in the tool should not be OC value and the value is less than 3000
	Given RAM toggle status is on
	Given Click the RAM toggle on
	Given Click the X Button
	When enter hibernate
    Then RAM value in the tool should not be OC value and the value is less than 3000

@GamingMemoryOCtestNoWifi
Scenario:VAN17321_TestStep22_all pages settings shoule be consistent with the last change and all functions should be work correctly
	Given record page item
	Given Disable Ethernet
	Given ReLaunch Vantage
	Then all pages settings shoule be consistent with the last change
	 
@GamingMemoryOCOntest
Scenario:VAN17321_TestStep23_all pages settings shoule be consistent with the last change and all functions should be work correctly.
	Given record page item
	Given Open Vantage to the home page
	Given ReLaunch Vantage
	Then all pages settings shoule be consistent with the last change

@GamingMemoryOCOntest
Scenario:VAN17321_TestStep24_all pages settings shoule be consistent with the last change and all functions should be work correctly.
	Given record page item
	Given close lenovo vantage
	Given ReLaunch Vantage
	Then all pages settings shoule be consistent with the last change