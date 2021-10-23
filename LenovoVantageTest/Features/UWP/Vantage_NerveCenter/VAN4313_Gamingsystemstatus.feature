Feature: VAN4313_Gamingsystemstatus
Test Case： https://jira.tc.lenovo.com/browse/VAN-4313
	Author：Xiang Tian

Background:
	Given Machine is Gaming 

@Gamingsystemstatus
Scenario: VAN4313_TestStep01_Vantage status consist with system
	Then Take Screen Shot Gamingsystemstatus_TestStep01 in 4313 under GamingScreenShotResult
	
@Gamingsystemstatus
Scenario: VAN4313_TestStep02_it will be switch hardware interface 
	When the user clicking the info on system status
	Then it will be switch hardware interface

@Gamingsystemstatus
Scenario: VAN4313_TestStep03_it will be display module name
	Given Hover the GPU CPU VRAM or HardDisk area 'CPU'
	Then Take Screen Shot Gamingsystemstatus_TestStep03 in 4313 under GamingScreenShotResult

@Gamingsystemstatus
Scenario: VAN4313_TestStep04_it will be display module name
	Given Hover the GPU CPU VRAM or HardDisk area 'GPU'
	Then Take Screen Shot Gamingsystemstatus_TestStep04 in 4313 under GamingScreenShotResult

@Gamingsystemstatus
Scenario: VAN4313_TestStep05_it will be display module name
	Given Hover the GPU CPU VRAM or HardDisk area 'RAM'
	Then Take Screen Shot Gamingsystemstatus_TestStep05 in 4313 under GamingScreenShotResult

@GamingsystemstatusHDD
Scenario: VAN4313_TestStep06_it will be display module name
	Given Hover the GPU CPU VRAM or HardDisk area 'HDD'
	Then Take Screen Shot Gamingsystemstatus_TestStep06 in 4313 under GamingScreenShotResult

@GamingsystemstatusSSD
Scenario: VAN4313_TestStep07_it will be display module name
	Given Hover the GPU CPU VRAM or HardDisk area 'SDD'
	Then Take Screen Shot Gamingsystemstatus_TestStep07 in 4313 under GamingScreenShotResult
	
@Gamingsystemstatus
Scenario: VAN4313_TestStep08_CPU will have the same module name , usage, frequency as the task manager 
	Given Hover the GPU CPU VRAM or HardDisk area 'CPU'
	Then Take Screen Shot Gamingsystemstatus_TestStep08_1st in 4313 under GamingScreenShotResult
	Given Get cpu name and capacity
	Then cpu will have the same module as the task manager
	Given open task manager
	Then Take Screen Shot Gamingsystemstatus_TestStep08_2nd in 4313 under GamingScreenShotResult

@Gamingsystemstatus
Scenario: VAN4313_TestStep09_GPU will have the same module name , usage, frequency as the task manager 
	Given Hover the GPU CPU VRAM or HardDisk area 'GPU'
	Then Take Screen Shot Gamingsystemstatus_TestStep09_1st in 4313 under GamingScreenShotResult
	Given Get GPU name and capacity
	Then GPU will have the same module as the task manager
	Given open task manager
	Then Take Screen Shot Gamingsystemstatus_TestStep09_2nd in 4313 under GamingScreenShotResult
	Given click task manager
	Then Take Screen Shot Gamingsystemstatus_TestStep09_3rd in 4313 under GamingScreenShotResult

@Gamingsystemstatus
Scenario: VAN4313_TestStep10_RAM will have the same module name , usage, frequency as the task manager 
	Given Hover the GPU CPU VRAM or HardDisk area 'RAM'
	Then Take Screen Shot Gamingsystemstatus_TestStep10 in 4313 under GamingScreenShotResult
	Given Get RAM Info
	Then RAM will have the same module as the task manager

@GamingsystemstatusSSD
Scenario: VAN4313_TestStep11_SSD will have the same module name , usage, frequency as the task manager
	Given Get SSD Info
	Given Hover the GPU CPU VRAM or HardDisk area 'SDD'
	Then Take Screen Shot Gamingsystemstatus_TestStep11 in 4313 under GamingScreenShotResult
	Then write Info

@GamingsystemstatusHDD
Scenario: VAN4313_TestStep12_HDD will have the same module name , usage, frequency as the task manager
	Given Get HDD Info
	Given Launch Vantage
	Then Take Screen Shot Gamingsystemstatus_TestStep12 in 4313 under GamingScreenShotResult
	Then write Info	

@Gamingsystemstatus
Scenario: VAN4313_TestStep13_it will be same UI spec layout as
	When the user click system tools
	Then Take Screen Shot Gamingsystemstatus_TestStep13_1st in 4313 under GamingScreenShotResult
	Given the user click homepage btn
	Then Take Screen Shot Gamingsystemstatus_TestStep13_2st in 4313 under GamingScreenShotResult

@Gamingsystemstatus
Scenario: VAN4313_TestStep14_after click Minisize btn and it will be same UI spec layout as
	When Click the Minimize
	Then Take Screen Shot Gamingsystemstatus_TestStep14 in 4313 under GamingScreenShotResult

@Gamingsystemstatus
Scenario: VAN4313_TestStep15_after click Minisize btn and it will be same
	When Click the Minimize
	Then Take Screen Shot Gamingsystemstatus_TStep15_1st in 4313 under GamingScreenShotResult
	When Close Vantage
	Given Launch Vantage
	Then Take Screen Shot Gamingsystemstatus_TStep15_2st in 4313 under GamingScreenShotResult

@Gamingsystemstatus
Scenario: VAN4313_TestStep16_after any operation and it will be same
	When Click the Minimize
	Then Take Screen Shot Gamingsystemstatus_TStep16_1st in 4313 under GamingScreenShotResult
	When the user click MaxSize btn
	Then Take Screen Shot Gamingsystemstatus_TStep16_2st in 4313 under GamingScreenShotResult
	When the user click MaxSize btn
	Then Take Screen Shot Gamingsystemstatus_TStep16_3st in 4313 under GamingScreenShotResult