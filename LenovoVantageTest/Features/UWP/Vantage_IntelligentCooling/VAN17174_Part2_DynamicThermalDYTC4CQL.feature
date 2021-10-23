Feature: VAN17174_Part2_DynamicThermalDYTC4CQL
	Help: ITS_FullTestCase_Vantage_ITS1.0_CQL/TIO_Thinkpad_Regression Test_DYTC4.0
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17174
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-1746
	Developer: chenpj

@ThinkDytc4CQL_Unsupported
Scenario: VAN17174_TestStep04_Check Intelligent Cooling feature not show on unsupport machine
	When Click the Power icon
	When Check Open Power page
	Then Check Intelligent Cooling Hide for Perf&CQ
	Then Check Intelligent Cooling Hide for DYTC4CQL