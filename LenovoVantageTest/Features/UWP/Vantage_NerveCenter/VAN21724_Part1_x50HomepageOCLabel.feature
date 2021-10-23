Feature: VAN21724_Part1_X50GamingHomepageOCLabel
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-21724
	Author： caopp2

Background:
	Given Machine is Gaming 

@GamingHomepageOCLabel
Scenario: VAN21724_TestStep01_Check the Performance OC in homepage LEGION EDGE
	Given Launch Vantage
	Given  driver is installed
	Given The Thermal Mode Setting popup is displaying
	When  Not Enable OverClocking checkbox status
	Given The thermal mode is Performance Mode  
	Given Click X button in Thermal Mode Setting popup
	Then  Check the Performance OverClock in homepage LEGION EDGE

@GamingHomepageOCLabel
Scenario: VAN21724_TestStep03_Check the Quiet OC in homepage LEGION EDGE
	Given Launch Vantage
	Given  driver is installed
	Given The Thermal Mode Setting popup is displaying
	When  Not Enable OverClocking checkbox status
	Given The thermal mode is Quiet Mode  
	Given Click X button in Thermal Mode Setting popup
	Then  Check the Quiet OverClock in homepage LEGION EDGE

@GamingHomepageOCLabel
Scenario: VAN21724_TestStep05_Check the Balance Quiet OC in homepage LEGION EDGE
	Given Launch Vantage
	Given  driver is installed
	Given The Thermal Mode Setting popup is displaying
	When  Not Enable OverClocking checkbox status
	Given The thermal mode is Balance Mode  
	Given Click X button in Thermal Mode Setting popup
	Then  Check the Balance OverClock in homepage LEGION EDGE

@GamingHomepageOCLabel
Scenario: VAN21724_TestStep07_Check the Performance Enable OC in homepage LEGION EDGE
	Given Launch Vantage
	Given  driver is installed
	Given The Thermal Mode Setting popup is displaying
	When Need Enable OverClocking Checkbox Status
	Given The thermal mode is Performance Mode  
	Given Click X button in Thermal Mode Setting popup
	Then  Check the Performance Enable OverClock in homepage LEGION EDGE

@GamingHomepageOCLabel
Scenario: VAN21724_TestStep09_Check the Quiet Enable OC in homepage LEGION EDGE
	Given Launch Vantage
	Given  driver is installed
	Given The Thermal Mode Setting popup is displaying
	When Need Enable OverClocking Checkbox Status
	Given The thermal mode is Quiet Mode  
	Given Click X button in Thermal Mode Setting popup
	Then  Check the Quiet Enable OverClock in homepage LEGION EDGE

@GamingHomepageOCLabel
Scenario: VAN21724_TestStep11_Check the Balance Enable OC in homepage LEGION EDGE
	Given Launch Vantage
	Given driver is installed
	Given The Thermal Mode Setting popup is displaying
	When Need Enable OverClocking Checkbox Status
	Given The thermal mode is Balance Mode  
	Given Click X button in Thermal Mode Setting popup
	Then  Check the Balance Enable OverClock in homepage LEGION EDGE

