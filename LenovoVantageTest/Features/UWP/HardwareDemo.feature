Feature: HardwareDemo

@HardWareDemo
Scenario: Backlight Testing
	When Go to My Device Settings page
	And Go to Input and Accessiories
	And Scroll the screen on my device
	When Click Off under keyboard backlight
	Then Verify the backlight status is off
	