// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.4.0.0
//      SpecFlow Generator Version:3.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace LenovoVantageTest.Features.UWP.MultipleClientsTest
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("GamingMultipleClients")]
    public partial class GamingMultipleClientsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "GamingMultipleClients.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/UWP/MultipleClientsTest", "GamingMultipleClients", "\tGaming Bamboo Agent 1 To Multiple Client", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Run Gaming Local Run 1 Client Y760")]
        [NUnit.Framework.CategoryAttribute("GamingMultipleClientsSpecFlow")]
        public virtual void RunGamingLocalRun1ClientY760()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingMultipleClientsSpecFlow"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run Gaming Local Run 1 Client Y760", null, tagsOfScenario, argumentsOfScenario);
#line 6
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 7
 testRunner.Given("Run Clients \'10.119.139.170\' And Run Version \'CommonBrand=Common\' Run Cat \'cat=X6" +
                        "0NBGPUOCOff ||cat=MultiGameDetection ||cat=ThermalModeACModeX60AutoOff ||cat=X60" +
                        "NBGPUOCOffACToDC ||cat=X60NBGPUOCOffDCToAC ||cat=ThermalModeACModeX60\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Run Gaming Local Run 2 Client Y560")]
        [NUnit.Framework.CategoryAttribute("GamingMultipleClientsSpecFlow")]
        public virtual void RunGamingLocalRun2ClientY560()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingMultipleClientsSpecFlow"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run Gaming Local Run 2 Client Y560", null, tagsOfScenario, argumentsOfScenario);
#line 11
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 12
 testRunner.Given("Run Clients \'10.119.134.117\' And Run Version \'CommonBrand=Common\' Run Cat \'cat=X6" +
                        "0NBGPUOCOn||cat=X60NBGPUOCOnACToDC||cat=X60NBGPUOCOnDCToAC ||cat=ThermalModeDCTo" +
                        "ACModeX60AutoOn ||cat=ThermalModeDCModeX60AutoOff ||cat=ThermalModeACToDCModeX60" +
                        "AutoOn\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Run Gaming Local Run 3 Client Agent-48")]
        [NUnit.Framework.CategoryAttribute("GamingMultipleClientsSpecFlow")]
        public virtual void RunGamingLocalRun3ClientAgent_48()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingMultipleClientsSpecFlow"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run Gaming Local Run 3 Client Agent-48", null, tagsOfScenario, argumentsOfScenario);
#line 16
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 17
 testRunner.Given("Run Clients \'10.119.171.47\' And Run Version \'CommonBrand=Common\' Run Cat \'cat=Gam" +
                        "ingNetworkBoostAutoCloseToast\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Run Gaming Local Run 4 Client Agent-172.196")]
        [NUnit.Framework.CategoryAttribute("GamingMultipleClientsSpecFlow")]
        public virtual void RunGamingLocalRun4ClientAgent_172_196()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingMultipleClientsSpecFlow"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run Gaming Local Run 4 Client Agent-172.196", null, tagsOfScenario, argumentsOfScenario);
#line 21
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 22
 testRunner.Given("Run Clients \'10.119.172.196\' And Run Version \'CommonBrand=Common\' Run Cat \'cat=Ga" +
                        "mingGPUOCVRAM ||cat=DPMSearchUnSupport || cat=GamingSearchNetworkBoost || cat=Ga" +
                        "mingSearchAutoClose || cat=GamingSearchThermalMode3 || cat=GamingSearchNoDriverV" +
                        "RAMOC\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Run Gaming Local Run 5 Client Agent-164.190")]
        [NUnit.Framework.CategoryAttribute("GamingMultipleClientsSpecFlow")]
        public virtual void RunGamingLocalRun5ClientAgent_164_190()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingMultipleClientsSpecFlow"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run Gaming Local Run 5 Client Agent-164.190", null, tagsOfScenario, argumentsOfScenario);
#line 26
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 27
 testRunner.Given("Run Clients \'10.119.164.190\' And Run Version \'CommonBrand=Common\' Run Cat \'cat=In" +
                        "tellegentSubMode || cat=PowerPlanPQPlans || cat=GamingEnableNahimic || cat=Gamin" +
                        "gEnableX-rite\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Run Gaming Local Run 6 Client Agent-175.34")]
        [NUnit.Framework.CategoryAttribute("GamingMultipleClientsSpecFlow")]
        public virtual void RunGamingLocalRun6ClientAgent_175_34()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingMultipleClientsSpecFlow"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run Gaming Local Run 6 Client Agent-175.34", null, tagsOfScenario, argumentsOfScenario);
#line 31
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 32
 testRunner.Given("Run Clients \'10.119.175.34\' And Run Version \'CommonBrand=Common\' Run Cat \'cat=Pow" +
                        "erPlanBalanceMode || cat=HWInfoAMD\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Run Gaming Local Run 7 Client Agent-169.187")]
        [NUnit.Framework.CategoryAttribute("GamingMultipleClientsSpecFlow")]
        public virtual void RunGamingLocalRun7ClientAgent_169_187()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingMultipleClientsSpecFlow"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run Gaming Local Run 7 Client Agent-169.187", null, tagsOfScenario, argumentsOfScenario);
#line 36
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 37
 testRunner.Given(@"Run Clients '10.119.169.187' And Run Version 'CommonBrand=Common' Run Cat 'cat=PowerPlanBQPlans  || cat= GamingTagDetection || cat=OverDriveSupported || cat=Thermalmode4.0Supported || cat=LightingNBSupported ||cat=GamingSearchTP ||cat=GamingSearch ||cat=GamingSearchMacroKey ||cat=GamingSearchHybridMode ||cat=GamingSearchOverDrive'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Run Gaming Local Run 8 Client Agent-188.123")]
        [NUnit.Framework.CategoryAttribute("GamingMultipleClientsSpecFlow")]
        public virtual void RunGamingLocalRun8ClientAgent_188_123()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingMultipleClientsSpecFlow"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run Gaming Local Run 8 Client Agent-188.123", null, tagsOfScenario, argumentsOfScenario);
#line 41
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 42
 testRunner.Given("Run Clients \'10.119.188.123\' And Run Version \'CommonBrand=Common\' Run Cat \'cat=Po" +
                        "werPlanPBPlans || cat=HWInfoAMDOCOFF\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Run Gaming Local Run 9 Client Agent-177.64")]
        [NUnit.Framework.CategoryAttribute("GamingMultipleClientsSpecFlow")]
        public virtual void RunGamingLocalRun9ClientAgent_177_64()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingMultipleClientsSpecFlow"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run Gaming Local Run 9 Client Agent-177.64", null, tagsOfScenario, argumentsOfScenario);
#line 46
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 47
 testRunner.Given("Run Clients \'10.119.177.64\' And Run Version \'CommonBrand=Common\' Run Cat \'cat=Pow" +
                        "erPlanPerformanceMode || cat=GamingReskinWiFiSecuritySubpageNoWifi || cat=Gaming" +
                        "PreferenceSettingsSelfSelectOptionsNoWifi \'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Run Gaming Local Run 10 Client Agent-138.239")]
        [NUnit.Framework.CategoryAttribute("GamingMultipleClientsSpecFlow")]
        public virtual void RunGamingLocalRun10ClientAgent_138_239()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingMultipleClientsSpecFlow"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run Gaming Local Run 10 Client Agent-138.239", null, tagsOfScenario, argumentsOfScenario);
#line 51
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 52
 testRunner.Given("Run Clients \'10.119.138.239\' And Run Version \'CommonBrand=Common\' Run Cat \'cat=Po" +
                        "werPlanManualThreePlans || cat=HWInfoAMDOCON || cat=PowerPlanModifyPlanSettings\'" +
                        "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Run Gaming Local Run 11 Client Agent-148.194")]
        [NUnit.Framework.CategoryAttribute("GamingMultipleClientsSpecFlow")]
        public virtual void RunGamingLocalRun11ClientAgent_148_194()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingMultipleClientsSpecFlow"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run Gaming Local Run 11 Client Agent-148.194", null, tagsOfScenario, argumentsOfScenario);
#line 56
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 57
 testRunner.Given("Run Clients \'10.119.148.194\' And Run Version \'CommonBrand=Common\' Run Cat \'cat=Po" +
                        "werPlanNoPlan || cat=PowerPlanModifyPlanCreateSamePlan\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Run Gaming Local Run 12 Client Agent-175.240")]
        [NUnit.Framework.CategoryAttribute("GamingMultipleClientsSpecFlow")]
        public virtual void RunGamingLocalRun12ClientAgent_175_240()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingMultipleClientsSpecFlow"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run Gaming Local Run 12 Client Agent-175.240", null, tagsOfScenario, argumentsOfScenario);
#line 61
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 62
 testRunner.Given("Run Clients \'10.119.175.240\' And Run Version \'CommonBrand=Common\' Run Cat \'cat=Po" +
                        "werPlanQuietPlan\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Run Gaming Local Run 13 Client Agent-144.100")]
        [NUnit.Framework.CategoryAttribute("GamingMultipleClientsSpecFlow")]
        public virtual void RunGamingLocalRun13ClientAgent_144_100()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingMultipleClientsSpecFlow"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run Gaming Local Run 13 Client Agent-144.100", null, tagsOfScenario, argumentsOfScenario);
#line 66
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 67
 testRunner.Given(@"Run Clients '10.119.144.100' And Run Version 'CommonBrand=Common' Run Cat 'cat=GamingReskinWiFiSecuritySubpage || cat=GamingCapacity_C730 || cat=GamingOLdCPUOC || cat=GamingDriverLackNetfilterDriver || cat=GamingDriverLackXTUDriverS4 || cat=GamingDriverLackNetfilterDriverS3 || cat=GamingDriverLackNetfilterDriverS4 || cat=GamingDriverLackLightingDriverS4  || cat=GamingOLdCPUOCNoWifi  || cat=CPUOCSupported  || cat=ThermalmodeUnSupported || cat=LightingTowerSupportedLEDDriver|| cat=GamingMemoryOCtestNoWifi || cat=GamingSearchLighting || cat=GamingSearchRAMOC || cat=GamingSearchOldCPUOC || cat=GamingSearchNoDriverNB || cat=GamingSearchNoDriverLighting || cat=GamingSearchNoDriverOldCPUOC || cat=GamingSearchNoDriverRAMOC || cat=GamingSearchNoThermalMode'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Run Gaming Local Run 14 Client Agent-133.97")]
        [NUnit.Framework.CategoryAttribute("GamingMultipleClientsSpecFlow")]
        public virtual void RunGamingLocalRun14ClientAgent_133_97()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingMultipleClientsSpecFlow"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run Gaming Local Run 14 Client Agent-133.97", null, tagsOfScenario, argumentsOfScenario);
#line 71
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 72
 testRunner.Given(@"Run Clients '10.119.133.97' And Run Version 'CommonBrand=Common' Run Cat 'cat=X60NBCPUGPUOCOn || cat=X60NBCPUGPUOCOnACToDC || cat=X60NBCPUGPUOCOnDCToAC || cat=HWInfoIntelCPUGPUOCOn || cat=ThermalModeDCModeX60 || cat=ThermalModeACToDCModeX60AutoOff || cat=GamingThermalModeX60New || cat= ThermalModeACModeX60AutoOn ||cat=GamingSearchX60GPUOC || cat=GamingSearchVRAMOC || cat=GamingSearchNoDriverX60GPUOC'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Run Gaming Local Run 15 Client Agent-146.59")]
        [NUnit.Framework.CategoryAttribute("GamingMultipleClientsSpecFlow")]
        public virtual void RunGamingLocalRun15ClientAgent_146_59()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingMultipleClientsSpecFlow"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run Gaming Local Run 15 Client Agent-146.59", null, tagsOfScenario, argumentsOfScenario);
#line 76
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 77
 testRunner.Given("Run Clients \'10.119.146.59\' And Run Version \'CommonBrand=Common\' Run Cat \'cat=X60" +
                        "NBCPUOCOn || cat=X60NBCPUOCOnACToDC || cat=X60NBCPUOCOnDCToAC|| cat=HWInfoIntelC" +
                        "PUOCOn || cat= ThermalModeDCModeX60AutoOn || cat=ThermalModeDCToACModeX60AutoOff" +
                        "\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Run Gaming Local Run 16 Client Agent-165.49")]
        [NUnit.Framework.CategoryAttribute("GamingMultipleClientsSpecFlow")]
        public virtual void RunGamingLocalRun16ClientAgent_165_49()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingMultipleClientsSpecFlow"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Run Gaming Local Run 16 Client Agent-165.49", null, tagsOfScenario, argumentsOfScenario);
#line 81
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 82
 testRunner.Given(@"Run Clients '10.119.165.49' And Run Version 'CommonBrand=Common' Run Cat 'cat=GamingMemoryOCOfftest || cat=GamingMacroKey15InchKeyboardLayout || cat=GamingOldThermalModeAC || cat=GamingOldThermalModeDC || cat= AutoClose || cat=RAMOCSupportedDriverinstalled'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
