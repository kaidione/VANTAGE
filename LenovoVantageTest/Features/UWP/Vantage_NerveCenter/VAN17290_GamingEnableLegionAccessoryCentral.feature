Feature: VAN17290_GamingEnableLegionAccessoryCentral
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17290
	Author：Wei Xu

Background:
	Given Machine is Gaming 

@GamingEnableLegionAccessoryCentral
Scenario: VAN17290_TestStep01_Legion Accessory Central Should Not Be Shown When App Is Not Installed
	When kill legion_hid and wait 0 second 
	Given Legion Accessory Central App Install or Uninstall 'uninstall'
	Given Close Vantage
	Given Launch Vantage
	Then Legion Accessory Central Should Not Be Shown

@GamingEnableLegionAccessoryCentral
Scenario: VAN17290_TestStep02_Legion Accessory Central Should Not Be Shown When App Is Not Installed
	When Enter Auto Close page
	When Back to the homepage
	Then Legion Accessory Central Should Not Be Shown

@GamingEnableLegionAccessoryCentral
Scenario: VAN17290_TestStep03_Legion Accessory Central Should Not Be Shown When App Is Not Installed
	Given Close Vantage
	Given Launch Vantage
	Then Legion Accessory Central Should Not Be Shown

@GamingEnableLegionAccessoryCentral
Scenario: VAN17290_TestStep04_Legion Accessory Central Should Not Be Shown When App Is Not Installed
	Given Legion Accessory Central App Install or Uninstall 'install'
	Then Legion Accessory Central Should Not Be Shown

@GamingEnableLegionAccessoryCentral
Scenario: VAN17290_TestStep05_Legion Accessory Central Should Be Shown When App Is Installed
	When kill legion_hid and wait 0 second 
	Given Legion Accessory Central App Install or Uninstall 'uninstall'
	Given Legion Accessory Central App Install or Uninstall 'install'
	Given Close Vantage
	Given Launch Vantage
	When Enter Auto Close page
	When Back to the homepage
	Then Legion Accessory Central Should Be Shown

@GamingEnableLegionAccessoryCentral
Scenario: VAN17290_TestStep06_Legion Accessory Central Should Be Shown When App Is Installed
	When kill legion_hid and wait 0 second 
	Given Legion Accessory Central App Install or Uninstall 'uninstall'
	Given Legion Accessory Central App Install or Uninstall 'install'
	Given Close Vantage
	Given Launch Vantage
	Then Legion Accessory Central Should Be Shown

@GamingEnableLegionAccessoryCentral @GamingSmokeLAC
Scenario: VAN17290_TestStep07_Legion Accessory Central App Should Be Opened
	Given Legion Accessory Central App Install or Uninstall 'install'
	When kill legion_hid and wait 0 second 
	Given Click the Legion Accessory Central Icon
	Then Legion Accessory Central App Should Be Opened

@GamingEnableLegionAccessoryCentral
Scenario: VAN17290_TestStep08_Legion Accessory Central Install Popup Should Be Opened
	Given Legion Accessory Central App Install or Uninstall 'install'
	Given Close Vantage
	Given Launch Vantage
	When kill legion_hid and wait 0 second 
	Given Legion Accessory Central App Install or Uninstall 'uninstall'
	Given Click the Legion Accessory Central Icon
	Then Legion Accessory Central Install Popup Should Be Opened
	Then Take Screen Shot Legion Accessory Central Install Popup in 17290 under GamingScreenShotResult

@GamingEnableLegionAccessoryCentral
Scenario: VAN17290_TestStep09_Legion Accessory Central Install Popup Should Be Closed 
	Given Legion Accessory Central App Install or Uninstall 'install'
	Given Close Vantage
	Given Launch Vantage
	When kill legion_hid and wait 0 second 
	Given Legion Accessory Central App Install or Uninstall 'uninstall'
	Given Click the Legion Accessory Central Icon
	Given Click the Close button in the install popup
	Then Install popup should be closed

@GamingEnableLegionAccessoryCentral
Scenario: VAN17290_TestStep10_Legion Accessory Central Install Popup Should Be Closed 
	Given Legion Accessory Central App Install or Uninstall 'install'
	Given Close Vantage
	Given Launch Vantage
	When kill legion_hid and wait 0 second 
	Given Legion Accessory Central App Install or Uninstall 'uninstall'
	Given Click the Legion Accessory Central Icon
	Given Click the Cancel button in the install popup
	Then Install popup should be closed

@GamingEnableLegionAccessoryCentral
Scenario: VAN17290_TestStep11_Legion Accessory Central Install Web Should Be Opened 
	Given Legion Accessory Central App Install or Uninstall 'install'
	Given Close Vantage
	Given Launch Vantage
	When kill legion_hid and wait 0 second 
	Given Legion Accessory Central App Install or Uninstall 'uninstall'
	Given Click the Legion Accessory Central Icon
	Given Click the Install button in the install popup
	Then Install popup should be closed
	Then Install Web page should be opened

@GamingEnableLegionAccessoryCentral
Scenario: VAN17290_TestStep12_Legion Accessory Central Install Popup Should Be Closed 
	When kill legion_hid and wait 0 second 
	Given Legion Accessory Central App Install or Uninstall 'uninstall'
	Given Legion Accessory Central App Install or Uninstall 'install'
	Given Close Vantage
	Given Launch Vantage
	Given Click the Legion Accessory Central Icon
	Then Legion Accessory Central App Should Be Opened

@GamingEnableLegionAccessoryCentral
Scenario: VAN17290_TestStep13_Legion Accessory Central Should Not Be Shown
	Given Legion Accessory Central App Install or Uninstall 'install'
	Given Close Vantage
	Given Launch Vantage
	When kill legion_hid and wait 0 second 
	Given Legion Accessory Central App Install or Uninstall 'uninstall'
	When Enter Auto Close page
	When Back to the homepage
	Then Legion Accessory Central Should Not Be Shown

@GamingEnableLegionAccessoryCentral
Scenario: VAN17290_TestStep14_Legion Accessory Central Should Be Shown
	Given Legion Accessory Central App Install or Uninstall 'install'
	When kill legion_hid and wait 0 second 
	Given Legion Accessory Central App Install or Uninstall 'uninstall'
	Given Legion Accessory Central App Install or Uninstall 'install'
	When Enter Auto Close page
	When Back to the homepage
	Then Legion Accessory Central Should Be Shown

@GamingEnableLegionAccessoryCentral
Scenario: VAN17290_TestStep15_Legion Accessory Central Should Be Shown
	Given Legion Accessory Central App Install or Uninstall 'install'
	When kill legion_hid and wait 0 second 
	Given Legion Accessory Central App Install or Uninstall 'uninstall'
	Given Legion Accessory Central App Install or Uninstall 'install'
	When Enter Auto Close page
	When Back to the homepage
	Given Click the Legion Accessory Central Icon
	Then Legion Accessory Central App Should Be Opened

@GamingEnableLegionAccessoryCentral
Scenario: VAN17290_TestStep16_Legion Accessory Central Should Not Be Shown
	Given Legion Accessory Central App Install or Uninstall 'install'
	When kill legion_hid and wait 0 second 
	Given Legion Accessory Central App Install or Uninstall 'uninstall'
	Given Close Vantage
	Given Launch Vantage
	Then Legion Accessory Central Should Not Be Shown

@GamingEnableLegionAccessoryCentral
Scenario: VAN17290_TestStep17_Legion Accessory Central Should Be Shown
	Given Legion Accessory Central App Install or Uninstall 'install'
	When kill legion_hid and wait 0 second 
	Given Legion Accessory Central App Install or Uninstall 'uninstall'
	Given Legion Accessory Central App Install or Uninstall 'install'
	Given Close Vantage
	Given Launch Vantage
	Then Legion Accessory Central Should Be Shown

@GamingEnableLegionAccessoryCentral
Scenario: VAN17290_TestStep18_Legion Accessory Central Should Be Opened
	Given Legion Accessory Central App Install or Uninstall 'install'
	When kill legion_hid and wait 0 second 
	Given Legion Accessory Central App Install or Uninstall 'uninstall'
	Given Legion Accessory Central App Install or Uninstall 'install'
	Given Close Vantage
	Given Launch Vantage
	Given Click the Legion Accessory Central Icon
	Then Legion Accessory Central App Should Be Opened
	When kill legion_hid and wait 0 second 

	