Feature: ITSSmokeClients
	ITS Bamboo Agent 1 To Multiple Client

# http://10.119.149.105/common/index.html
@ITSSmokeClientsSpecFlow
Scenario: Run ITS Local Run 1 Client DYTC4CQL
	Given Run Clients '10.119.149.105' And Run Version 'CommonBrand=Common' Run Cat 'cat=ITSSmokeDYTC4CQL'

# http://10.119.154.73/common/index.html
@ITSSmokeClientsSpecFlow
Scenario: Run ITS Local Run 2 Client DYTC4TIO
	Given Run Clients '10.119.154.73' And Run Version 'CommonBrand=Common' Run Cat 'cat=ITSSmokeDYTC4TIO'

# http://10.119.137.124/common/index.html
@ITSSmokeClientsSpecFlow
Scenario: Run ITS Local Run 3 Client ITS2
	Given Run Clients '10.119.137.124' And Run Version 'CommonBrand=Common' Run Cat 'cat=ITSSmokeITS2'

# http://10.119.159.53/common/index.html
@ITSSmokeClientsSpecFlow
Scenario: Run ITS Local Run 4 Client DYTC6AMT
	Given Run Clients '10.119.159.53' And Run Version 'CommonBrand=Common' Run Cat 'cat=ITSSmokeDYTC6AMT'

# http://10.119.181.181/common/index.html
@ITSSmokeClientsSpecFlow
Scenario: Run ITS Local Run 5 Client DYTC3CQL
	Given Run Clients '10.119.181.181' And Run Version 'CommonBrand=Common' Run Cat 'cat=ITSSmokeDYTC3CQL'

# http://10.119.171.228/common/index.html
@ITSSmokeClientsSpecFlow
Scenario: Run ITS Local Run 6 Client DYTC3TIO
	Given Run Clients '10.119.171.228' And Run Version 'CommonBrand=Common' Run Cat 'cat=ITSSmokeDYTC3TIO'

# http://10.119.146.20/common/index.html
@ITSSmokeClientsSpecFlow
Scenario: Run ITS Local Run 9 Client ITS5GPUOC
	Given Run Clients '10.119.146.20' And Run Version 'CommonBrand=Common' Run Cat 'cat=ITSSmokeITS5'

# http://10.119.170.185/common/index.html
@ITSSmokeClientsSpecFlow
Scenario: Run ITS Local Run 10 Client ITS4SMB
	Given Run Clients '10.119.170.185' And Run Version 'CommonBrand=Common' Run Cat 'cat=ITSSmokeITS4SMB'

# http://10.119.154.173/common/index.html
@ITSSmokeClientsSpecFlow
Scenario: Run ITS Local Run 11 Client ITS agent-41
	Given Run Clients '10.119.154.173' And Run Version 'CommonBrand=Common' Run Cat 'cat=ITSSmokeDYTC6MWS'

# http://10.119.164.69/common/index.html
@ITSSmokeClientsSpecFlow
Scenario: Run ITS Local Run 10 Client ITS4
	Given Run Clients '10.119.164.69' And Run Version 'CommonBrand=Common' Run Cat 'cat=ITSSmokeITS4'