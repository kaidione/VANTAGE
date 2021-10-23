Feature: VAN18037_Part2_DynamicThermalDYTC6MWS
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-18037
	Author: Pengjie Chen (TestStep: 1,2,3,4,5,6,7,8,9,13,14,15)
	Author: Xiaoxiong Li (TestStep: 10,11,12)

@NotSupportCS2021
Scenario: VAN18037_TestStep01_Check Intelligent Cooling feature will not show on unsupport machine
	When Click the Power icon
	When Check Open Power page
	Then The Intelligent Cooling feature will not show for Thinkpad DYTC Six CS20 CS21