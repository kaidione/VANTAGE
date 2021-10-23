Feature: VAN19946_GamingDriverLackforX50
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-19946
	Author： Jinxin Li

Background: 
	Given Machine is Gaming

@DriverLackforX50
Scenario: VAN19946_TestStep01_CPU GPU Donot exist
	Given 'CPU/GPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	When Only Print 'Check Enable OC Checkbox Area'
	Then The Enable OC Checkbox Should 'Disappear'
	Then The 'Install CPU/GPU drivers to use the Overclocking function.' Description 'Displaying'

@DriverLackforX50
Scenario: VAN19946_TestStep02_CPU GPU Donot exist
	Given 'CPU/GPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	When Only Print 'Check Advanced OC Link Area'
	Then Advanced OC Link Should be 'Disappear'
	Then The GO INSTALL Link Shloud be Shown

@DriverLackforX50
Scenario: VAN19946_TestStep03_CPU GPU Donot exist
	Given 'CPU/GPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	Given Hover GO INSTALLL Link
	When Only Print 'Check the Mouse Type'
	Then Take Screen Shot 03TestStep in 19946 under SettingsScreenShotResult

@DriverLackforX50
Scenario: VAN19946_TestStep04_CPU GPU Donot exist
	Given 'CPU/GPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	Given Click Go Install Link
	When Only Print 'Check the Subpage'
	Then check Update header title

@DriverLackforX50
Scenario: VAN19946_TestStep05_CPU GPU Donot exist
	Given 'CPU/GPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	When Only Print 'Check the 'Install missing CPU/GPU drivers to use overclocking function' description'
	Then The 'Install CPU/GPU drivers to use the Overclocking function.' Description 'Displaying'

@DriverLackforX50S4
Scenario: VAN19946_TestStep06_CPU GPU Donot exist
	When Install 'GPU/CPU' Driver
	When Enter hibernate
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	Then The 'Install CPU/GPU drivers to use the Overclocking function.' Description 'Disappear'
	Then The Enable CPU/GPU Overclocking Checkbox Should be 'Shown'

@DriverLackforX50
Scenario: VAN19946_TestStep07_CPU GPU is exist
	When Install 'CPU/GPU' Driver
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	Given 'CPU/GPU' Driver don't exist
	When Only Print 'Check the 'Enable CPU/GPU Overclocking in Performance Mode' description again'
	Then The 'Enable CPU/GPU Overclocking in Performance Mode.' Description 'Displaying'
	Then The Enable CPU/GPU Overclocking Checkbox Should be 'Shown'

@DriverLackforX50S4
Scenario: VAN19946_TestStep08_CPU GPU is exist need S4
	Given 'CPU/GPU' Driver don't exist
	When Enter hibernate
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	When Only Print 'Check the 'Enable CPU/GPU Overclocking in Performance Mode' description again'
	Then The Enable CPU/GPU Overclocking Checkbox Should be 'Disappear'
	Then The 'Install CPU/GPU drivers to use the Overclocking function.' Description 'Displaying'

@DriverLackforX50S4
Scenario: VAN19946_TestStep09_CPU GPU is exist need S4
	Given 'CPU/GPU' Driver don't exist
	When Enter hibernate
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	When Only Print 'Check Advanced OC link area'
	Then Advanced OC Link Should be 'Disappear'
	Then The GO INSTALL Link Shloud be Shown

@DriverLackforX50 
Scenario: VAN19946_TestStep10_CPU GPU is exist need restart machine
	When Install 'CPU' Driver
	Given 'GPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	When Only Print 'Check the 'Enable CPU/GPU Overclocking in Performance Mode' description again'
	Given Hover GO INSTALLL Link
	When Only Print 'Check the Mouse Type'
	Then Take Screen Shot 10TestStep in 19946 under SettingsScreenShotResult

@DriverLackforX50 
Scenario: VAN19946_TestStep11_CPU Driver exist, GPU Driver not exist
	When Install 'CPU' Driver
	Given 'GPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	Given Click Go Install Link
	When Only Print 'Check the subpage'
	Then check Update header title

@DriverLackforX50 
Scenario: VAN19946_TestStep12_CPU Driver exist, GPU Driver not exist
	When Install 'CPU' Driver
	Given 'GPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	When Install 'GPU' Driver
	When Only Print 'Check the 'Install missing GPU drivers to use overclocking function' description'
	Then The 'Install GPU driver to use the Overclocking function.' Description 'Displaying'

@DriverLackforX50S4
Scenario: VAN19946_TestStep13_CPU Driver exist, GPU Driver not exist S4
	When Install 'CPU' Driver
	Given 'GPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	When Install 'GPU' Driver
	When Enter hibernate
	Given Close Vantage
	Given Launch Vantage
	Then The 'Install GPU driver to use the Overclocking function.' Description 'Disappear'
	Then The Enable CPU/GPU Overclocking Checkbox Should be 'Displaying'

@DriverLackforX50 
Scenario: VAN19946_TestStep14_CPU Driver exist, GPU Driver not exist S4
	When Install 'CPU' Driver
	When Install 'GPU' Driver
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	Given 'GPU' Driver don't exist
	Then The 'Enable CPU/GPU Overclocking in Performance Mode.' Description 'Displaying'

@DriverLackforX50S4
Scenario: VAN19946_TestStep15_CPU Driver exist, GPU Driver not exist S4
	When Install 'CPU' Driver
	When Install 'GPU' Driver
	Given 'GPU' Driver don't exist
	When Enter hibernate
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	Then The 'Enable CPU/GPU Overclocking in Performance Mode.' Description 'Disappear'
	Then The 'Install GPU driver to use the Overclocking function.' Description 'Displaying'

@DriverLackforX50 
Scenario: VAN19946_TestStep16_CPU Driver Not exist, GPU Driver exist
	When Install 'CPU' Driver
	When Install 'GPU' Driver
	Given 'CPU' Driver don't exist
	When Only Print 'Check Enable OC checkbox area'
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	Then The 'Install CPU driver to use the Overclocking function.' Description 'Displaying'

@DriverLackforX50 
Scenario: VAN19946_TestStep17_CPU Driver Not exist, GPU Driver exist
	When Install 'CPU' Driver
	When Install 'GPU' Driver
	Given 'CPU' Driver don't exist
	When Only Print 'Check Advanced OC link area'
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	Then The GO INSTALL Link Shloud be Shown

@DriverLackforX50 
Scenario: VAN19946_TestStep18_CPU Driver Not exist, GPU Driver exist
	When Install 'CPU' Driver
	When Install 'GPU' Driver
	Given 'CPU' Driver don't exist
	When Only Print 'Check Advanced OC link area'
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	Given Click Go Install Link
	When Only Print 'Check the subpage'
	Then check Update header title

@DriverLackforX50 
Scenario: VAN19946_TestStep19_CPU Driver Not exist, GPU Driver exist
	When Install 'GPU' Driver
	Given 'CPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	When Install 'CPU' Driver
	Then The 'Install CPU driver to use the Overclocking function.' Description 'Displaying'

@DriverLackforX50S4
Scenario: VAN19946_TestStep20_CPU Driver Not exist, GPU Driver exist
	When Install 'GPU' Driver
	Given 'CPU' Driver don't exist
	When Install 'CPU' Driver
	When Enter hibernate
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	Then The 'Install CPU drivers to use overclocking function.' Description 'Disappeared'
	Then The 'Enable CPU/GPU Overclocking in Performance Mode.' Description 'Displaying'

@DriverLackforX50
Scenario: VAN19946_TestStep21_CPU Driver Not exist, GPU Driver exist 
	When Install 'GPU' Driver
	Given 'CPU' Driver don't exist
	Given The Thermal Mode Setting popup is displaying
	When Install 'CPU' Driver
	Given Click Go Install Link
	When Only Print 'Check the subpage'
	Then check Update header title

@DriverLackforX50Agent33
Scenario: VAN19946_TestStep22_CPU Driver Not exist, GPU Driver exist
	Given 'GPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	When Only Print 'Check Enable OC checkbox area'
	Then The Enable OC Checkbox Should 'Disappear'
	Then The 'Install GPU driver to use the Overclocking function.' Description 'Displaying'

@DriverLackforX50Agent33
Scenario: VAN19946_TestStep23_CPU Driver Not exist, GPU Driver exist
	Given 'GPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	When Only Print 'Check Advanced OC link area'
	Then The GO INSTALL Link Shloud be Shown

@DriverLackforX50Agent33
Scenario: VAN19946_TestStep24_CPU Driver Not exist, GPU Driver exist
	Given 'GPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	When Only Print 'Check Advanced OC link area'
	Given Click Go Install Link
	When Only Print 'Check the subpage'
	Then check Update header title

@DriverLackforX50Agent33
Scenario: VAN19946_TestStep25_CPU Driver Not exist, GPU Driver exist
	Given 'GPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	When Install 'GPU' Driver
	Then The 'Install GPU driver to use the Overclocking function.' Description 'Displaying'

@DriverLackforX50Agent33S4
Scenario: VAN19946_TestStep26_CPU Driver Not exist, GPU Driver exist
	When Install 'GPU' Driver
	When Enter hibernate
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	Then The 'Install GPU drivers to use overclocking function.' Description 'Disappeared'
	Then The 'Enable GPU Overclocking in Performance Mode.' Description 'Displaying'

@DriverLackforX50Agent33
Scenario: VAN19946_TestStep27_CPU Driver Not exist, GPU Driver exist
	When Install 'GPU' Driver
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	Given 'GPU' Driver don't exist
	When Install 'GPU' Driver
	Then The 'Enable GPU Overclocking in Performance Mode' Description 'Displaying'

@DriverLackforX50Agent33S4
Scenario: VAN19946_TestStep28_CPU Driver Not exist, GPU Driver exist
	Given 'GPU' Driver don't exist
	When Enter hibernate
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	Then The 'Enable GPU Overclocking in Performance Mode' Description 'Disappeared'
	Then The 'Install GPU driver to use the Overclocking function.' Description 'Displaying'
	When Install 'GPU' Driver