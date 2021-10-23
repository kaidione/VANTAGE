Feature: VAN28222_VantageSettingsToolbarimageforNewWindowsquickregression
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-28222
	Author： Yangyu

Background: 
	When Current Machine OS is "more" than "21354"

@ToolbarimageforNewWindows
Scenario: VAN28222_TestStep01_Check UI of Lenovo Vantage Toolbar
	Given Open the My Device Settings and into Power page
	Given Click Vantage Toolbar Link by jump to settings on Powerpage
	Then Check Toolbar Word has been updated
	Then Take Screen Shot VAN28222_TestStep01 in 28222 under HSScreenShotResult

@ToolbarimageforNewWindows
Scenario: VAN28222_TestStep02_Check Toolbar Icon after OOBE
	Given Install the Lenovo Vantage
	When select the Enable the Lenovo Vantage toolbar checkbox
	Then the toolbar "should" pin to taskbar in New OS Within "2" Seconds
	Given Open the My Device Settings and into Power page
	Given Click Vantage Toolbar Link by jump to settings on Powerpage
	Then The Toolbar togle is "On"
	Then Take Screen Shot VAN28222_TestStep02 in 28222 under HSScreenShotResult

@ToolbarimageforNewWindows
Scenario: VAN28222_TestStep03_Check Toolbar donesn't pin to task after OOBE
	Given Install the Lenovo Vantage
	Given unselect the Enable the Lenovo Vantage toolbar checkbox
	Then the toolbar "shouldn't" pin to taskbar in New OS Within "2" Seconds
	Given Open the My Device Settings and into Power page
	Given Click Vantage Toolbar Link by jump to settings on Powerpage
	Then The Toolbar togle is "Off"

@ToolbarimageforNewWindows
Scenario: VAN28222_TestStep04_Check Toolbar display after turn toggle
	Given Install the Lenovo Vantage
	Given unselect the Enable the Lenovo Vantage toolbar checkbox
	Given Open the My Device Settings and into Power page
	Given Click Vantage Toolbar Link by jump to settings on Powerpage
	Given Turn On Toolbar Toggle from Vantage
	Then the toolbar "should" pin to taskbar in New OS Within "2" Seconds
	Then Take Screen Shot VAN28222_TestStep04 in 28222 under HSScreenShotResult

@ToolbarimageforNewWindows
Scenario: VAN28222_TestStep05_Check Toolbar doesn't display when turn off toggle
	Given Install the Lenovo Vantage
	When select the Enable the Lenovo Vantage toolbar checkbox
	Then the toolbar "should" pin to taskbar in New OS Within "2" Seconds
	Given Open the My Device Settings and into Power page
	Given Click Vantage Toolbar Link by jump to settings on Powerpage
	Given Turn Off Toolbar Toggle from Vantage
	Then the toolbar "shouldn't" pin to taskbar in New OS Within "2" Seconds

@ToolbarimageforNewWindows
Scenario: VAN28222_TestStep06_After severial times click Only one icon display
	Given Install the Lenovo Vantage
	When select the Enable the Lenovo Vantage toolbar checkbox
	Then the toolbar "should" pin to taskbar in New OS Within "2" Seconds
	Given Open the My Device Settings and into Power page
	Given Click Vantage Toolbar Link by jump to settings on Powerpage
	Given Turn Off Toolbar Toggle from Vantage
	Given Turn On Toolbar Toggle from Vantage
	Given Turn Off Toolbar Toggle from Vantage
	Given Turn On Toolbar Toggle from Vantage
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Given Turn Off Toolbar Toggle from Vantage
	Given Turn On Toolbar Toggle from Vantage
	Then the toolbar should only display 1 icon
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type

@ToolbarimageforNewWindows
Scenario: VAN28222_TestStep07_Check Unpin toolbar from taskbar
	Given Install the Lenovo Vantage
	When select the Enable the Lenovo Vantage toolbar checkbox
	Then the toolbar "should" pin to taskbar in New OS Within "2" Seconds
	Given Open the My Device Settings and into Power page
	Given Click Vantage Toolbar Link by jump to settings on Powerpage
	When Unpin Toolbar By Right_Click Toolbar Icon
	Given Go to Wifisecurity
	Given Open the My Device Settings and into Power page
	Given Click Vantage Toolbar Link by jump to settings on Powerpage
	Then The Toolbar togle is "Off"

@ToolbarimageforNewWindows
Scenario: VAN28222_TestStep08_turn on and off toolbar check UI after refresh 
	Given Open the My Device Settings and into Power page
	Given Click Vantage Toolbar Link by jump to settings on Powerpage
	Given Turn On Toolbar Toggle from Vantage
	Given Go to Wifisecurity
	Given Open the My Device Settings and into Power page
	Given Click Vantage Toolbar Link by jump to settings on Powerpage
	Then The Toolbar togle is "On"
	Given Turn Off Toolbar Toggle from Vantage
	Given Go to Wifisecurity
	Given Open the My Device Settings and into Power page
	Given Click Vantage Toolbar Link by jump to settings on Powerpage
	Then The Toolbar togle is "Off"

@ToolbarimageforNewWindows
Scenario: VAN28222_TestStep09_turn on and off toolbar check UI after reopen vantage
	Given Open the My Device Settings and into Power page
	Given Click Vantage Toolbar Link by jump to settings on Powerpage
	Given Turn On Toolbar Toggle from Vantage
	Given Close Vantage
	Given Launch Vantage
	Given Open the My Device Settings and into Power page
	Given Click Vantage Toolbar Link by jump to settings on Powerpage
	Then The Toolbar togle is "On"
	Given Turn Off Toolbar Toggle from Vantage
	Given Close Vantage
	Given Launch Vantage
	Given Open the My Device Settings and into Power page
	Given Click Vantage Toolbar Link by jump to settings on Powerpage
	Then The Toolbar togle is "Off"

@ToolbarimageforNewWindows
Scenario: VAN28222_TestStep10_Check first launch toolbar perfomance 
	Given Install the Lenovo Vantage
	Given unselect the Enable the Lenovo Vantage toolbar checkbox
	Given Open the My Device Settings and into Power page
	Given Click Vantage Toolbar Link by jump to settings on Powerpage
	Given Turn On Toolbar Toggle from Vantage
	Then the toolbar "should" pin to taskbar in New OS Within "3" Seconds
	Given Turn Off Toolbar Toggle from Vantage
	Given Turn On Toolbar Toggle from Vantage
	Then the toolbar "should" pin to taskbar in New OS Within "2" Seconds

@ToolbarimageforNewWindowsGaming
Scenario: VAN28222_TestStep11_Check UI of Lenovo Vantage Toolbar in gaming 
	Given Open the My Device Settings and into Power page
	Given Click Vantage Toolbar Link by jump to settings on Powerpage
	Then Check Toolbar Word has been updated
	Then Take Screen Shot 11CheckToolbarUIGaming in 28222 under HSScreenShotResult


