Feature: VAN19886_GamingFamiliyName_for_331
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-19886
	Author： Lea Zhang

Background:
	Given Machine is Gaming 

@Y750Famliyname
Scenario: Check Y750 famliy name 
	Given get machine info
	When check if Y750 or not
	When check if this machine in gaming list
	Then check info consistent with vantage

@Y750SFamliyname
Scenario: Check Y750S famliy name 
	Given get machine info
	When check if Y750S or not
	When check if this machine in gaming list
	Then check info consistent with vantage

@Y740SFamliyname
Scenario: Check Y740S famliy name 
	Given get machine info
	When check if Y740S or not
	When check if this machine in gaming list
	Then check info consistent with vantage

@Y550Famliyname
Scenario: Check Y550 famliy name 
	Given get machine info
	When check if Y550 or not
	When check if this machine in gaming list
	Then check info consistent with vantage

@T550Famliyname
Scenario: Check T550 famliy name 
	Given get machine info
	When check if T550 or not
	When check if this machine in gaming list
	Then check info consistent with vantage

@L350Famliyname
Scenario: Check L350 famliy name 
	Given get machine info
	When check if L350 or not
	When check if this machine in gaming list
	Then check info consistent with vantage

@T550GFamliyname
Scenario: Check T550G famliy name 
	Given get machine info
	When check if T550G or not
	When check if this machine in gaming list
	Then check info consistent with vantage 

@T750Famliyname
Scenario: Check T750 famliy name 
	Given get machine info
	When check if T750 or not
	When check if this machine in gaming list
	Then check info consistent with vantage