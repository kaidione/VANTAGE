﻿// ------------------------------------------------------------------------------
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
namespace LenovoVantageTest.Features.UWP.Vantage_HardwareSettings
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("VAN7220_VFC246_IntelligentScreenQucikTest")]
    [NUnit.Framework.CategoryAttribute("IntelligentScreenOnly")]
    public partial class VAN7220_VFC246_IntelligentScreenQucikTestFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = new string[] {
                "IntelligentScreenOnly"};
        
#line 1 "VAN7220_IntelligentScreenQucikTest.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/UWP/Vantage_HardwareSettings", "VAN7220_VFC246_IntelligentScreenQucikTest", "\tTest Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-7220\r\n\tAuthor: Jin" +
                    "gting Jia\r\n\tAuthor: Haiye Li", ProgrammingLanguage.CSharp, new string[] {
                        "IntelligentScreenOnly"});
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
        [NUnit.Framework.DescriptionAttribute("VAN7220_TestStep01_Check Auto screen off and Keep my display")]
        [NUnit.Framework.CategoryAttribute("IntelligentScreenOnly")]
        [NUnit.Framework.CategoryAttribute("SmokeIntelligentScreenOnly")]
        public virtual void VAN7220_TestStep01_CheckAutoScreenOffAndKeepMyDisplay()
        {
            string[] tagsOfScenario = new string[] {
                    "IntelligentScreenOnly",
                    "SmokeIntelligentScreenOnly"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN7220_TestStep01_Check Auto screen off and Keep my display", null, tagsOfScenario, argumentsOfScenario);
#line 8
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
#line 9
 testRunner.Given("Go to Smart Assist page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 10
 testRunner.Given("Click Intelligent Screen Link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 11
 testRunner.Then("Display Auto screen off and Keep my display", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN7220_TestStep02_Displays a collapse button on the right")]
        [NUnit.Framework.CategoryAttribute("IntelligentScreenOnly")]
        public virtual void VAN7220_TestStep02_DisplaysACollapseButtonOnTheRight()
        {
            string[] tagsOfScenario = new string[] {
                    "IntelligentScreenOnly"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN7220_TestStep02_Displays a collapse button on the right", null, tagsOfScenario, argumentsOfScenario);
#line 14
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
#line 15
 testRunner.Given("Go to Smart Assist page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 16
 testRunner.Given("Click Intelligent Screen Link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 17
 testRunner.Then("Display a collapse button on the right", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN7220_TestStep03_Displays intelligent screen context description")]
        [NUnit.Framework.CategoryAttribute("IntelligentScreenOnly")]
        public virtual void VAN7220_TestStep03_DisplaysIntelligentScreenContextDescription()
        {
            string[] tagsOfScenario = new string[] {
                    "IntelligentScreenOnly"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN7220_TestStep03_Displays intelligent screen context description", null, tagsOfScenario, argumentsOfScenario);
#line 20
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
#line 21
 testRunner.Given("Go to Smart Assist page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 22
 testRunner.Given("Click Intelligent Screen Link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 23
 testRunner.Then("Shows the context description as Interlligent", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN7220_TestStep04_Displays Auto screen off context description")]
        [NUnit.Framework.CategoryAttribute("IntelligentScreenOnly")]
        [NUnit.Framework.CategoryAttribute("SmokeIntelligentScreenOnly")]
        public virtual void VAN7220_TestStep04_DisplaysAutoScreenOffContextDescription()
        {
            string[] tagsOfScenario = new string[] {
                    "IntelligentScreenOnly",
                    "SmokeIntelligentScreenOnly"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN7220_TestStep04_Displays Auto screen off context description", null, tagsOfScenario, argumentsOfScenario);
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
 testRunner.Given("Go to Smart Assist page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 28
 testRunner.Given("Click Intelligent Screen Link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 29
 testRunner.Then("Shows the context description as Autoscreenoff", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN7220_TestStep05_Displays Auto screen off red context")]
        [NUnit.Framework.CategoryAttribute("IntelligentScreenOnly")]
        public virtual void VAN7220_TestStep05_DisplaysAutoScreenOffRedContext()
        {
            string[] tagsOfScenario = new string[] {
                    "IntelligentScreenOnly"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN7220_TestStep05_Displays Auto screen off red context", null, tagsOfScenario, argumentsOfScenario);
#line 32
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
#line 33
 testRunner.Given("Go to Smart Assist page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 34
 testRunner.Given("Click Intelligent Screen Link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 35
 testRunner.Given("Turn On AutoScreenOff btn", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 36
 testRunner.Given("Select DisplayAC to 0 minutes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 37
 testRunner.Then("Shows the context description as Autoscreenoff red context", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 38
 testRunner.When("wait 30 seconds", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 39
 testRunner.Then("Take Screen Shot 05TestStep in 7220 under HSScreenShotResult", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 40
 testRunner.Given("Turn Off AutoScreenOff btn", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 41
 testRunner.Then("Noshows the context description as Autoscreenoff red context", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN7220_TestStep06_Displays Keep my display context")]
        [NUnit.Framework.CategoryAttribute("IntelligentScreenOnly")]
        public virtual void VAN7220_TestStep06_DisplaysKeepMyDisplayContext()
        {
            string[] tagsOfScenario = new string[] {
                    "IntelligentScreenOnly"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN7220_TestStep06_Displays Keep my display context", null, tagsOfScenario, argumentsOfScenario);
#line 44
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
#line 45
 testRunner.Given("Go to Smart Assist page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 46
 testRunner.Given("Click Intelligent Screen Link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 47
 testRunner.Given("Turn On Keepmydisplay btn", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 48
 testRunner.Given("Turn Off Keepmydisplay btn", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 49
 testRunner.Then("Check keep my display Caption", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 50
 testRunner.Then("Check keep my display Slidertitle", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 51
 testRunner.Then("Take Screen Shot 06TestStep in 7220 under HSScreenShotResult", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 52
 testRunner.Then("Check keep my display DisplaySlider", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 53
 testRunner.Then("Check keep my display MinMinutes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 54
 testRunner.Then("Check keep my display MaxMinutes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN7220_TestStep21_Displays a collapse button on the right")]
        [NUnit.Framework.CategoryAttribute("IntelligentScreenOnly")]
        public virtual void VAN7220_TestStep21_DisplaysACollapseButtonOnTheRight()
        {
            string[] tagsOfScenario = new string[] {
                    "IntelligentScreenOnly"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN7220_TestStep21_Displays a collapse button on the right", null, tagsOfScenario, argumentsOfScenario);
#line 57
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
#line 58
 testRunner.Given("Go to Smart Assist page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 59
 testRunner.Given("Click Intelligent Screen Link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 60
 testRunner.Given("Turn On AutoScreenOff btn", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 61
 testRunner.Given("Select DisplayAC to 0 minutes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 62
 testRunner.Then("Shows the context description as Autoscreenoff red context", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 63
 testRunner.Then("Take Screen Shot 21TestStep1 in 7220 under HSScreenShotResult", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 64
 testRunner.Given("Change DPI to 125", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 65
 testRunner.Then("Take Screen Shot 21TestStepDPI1 in 7220 under HSScreenShotResult", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 66
 testRunner.Given("Change DPI to 200", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN7220_TestStep22_Displays a collapse button on the right")]
        [NUnit.Framework.CategoryAttribute("IntelligentScreenOnly")]
        public virtual void VAN7220_TestStep22_DisplaysACollapseButtonOnTheRight()
        {
            string[] tagsOfScenario = new string[] {
                    "IntelligentScreenOnly"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN7220_TestStep22_Displays a collapse button on the right", null, tagsOfScenario, argumentsOfScenario);
#line 69
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
#line 70
 testRunner.Given("Go to Smart Assist page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 71
 testRunner.Given("Click Intelligent Screen Link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 72
 testRunner.Given("Turn On AutoScreenOff btn", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 73
 testRunner.Given("Select DisplayAC to 0 minutes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 74
 testRunner.Then("Shows the context description as Autoscreenoff red context", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 75
 testRunner.Then("Take Screen Shot 22TestStep1 in 7220 under HSScreenShotResult", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 76
 testRunner.Given("change resolution 1028 to 800", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 77
 testRunner.Then("Take Screen Shot 22TestStep2 in 7220 under HSScreenShotResult", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 78
 testRunner.Given("change resolution 2560 to 1440", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN7220_TestStep29_TestStep30_Set Auto Screen off, Battery turn off display never" +
            " and there is no tip")]
        [NUnit.Framework.CategoryAttribute("IntelligentScreenOnly")]
        public virtual void VAN7220_TestStep29_TestStep30_SetAutoScreenOffBatteryTurnOffDisplayNeverAndThereIsNoTip()
        {
            string[] tagsOfScenario = new string[] {
                    "IntelligentScreenOnly"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN7220_TestStep29_TestStep30_Set Auto Screen off, Battery turn off display never" +
                    " and there is no tip", null, tagsOfScenario, argumentsOfScenario);
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
 testRunner.Given("Select DisplayDC to 300 minutes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 83
 testRunner.Given("Hover the mouse on the \'Device\' button using the automationId specified with json" +
                        " path \'$.Navbar.device\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 84
 testRunner.And("Go to Smart Assist page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 85
 testRunner.When("Turn off the Auto Screen Off toggle", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 86
 testRunner.Given("Select DisplayDC to 0 minutes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 87
 testRunner.Given("into Dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 88
 testRunner.Given("Hover the mouse on the \'Device\' button using the automationId specified with json" +
                        " path \'$.Navbar.device\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 89
 testRunner.And("Go to Smart Assist page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 90
 testRunner.Given("Click Intelligent Screen Link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 91
 testRunner.Then("Take Screen Shot 29NoTip in 7220 under HSScreenShotResult", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 93
 testRunner.When("Turn on the Auto Screen Off toggle", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 94
 testRunner.Given("into Dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 95
 testRunner.Given("Hover the mouse on the \'Device\' button using the automationId specified with json" +
                        " path \'$.Navbar.device\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 96
 testRunner.And("Go to Smart Assist page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 97
 testRunner.Then("The AutoScreenOff Toggle is On", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 98
 testRunner.Then("The AutoScreenOff Toggle is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 99
 testRunner.Given("Click Intelligent Screen Link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 100
 testRunner.Then("Take Screen Shot 30NeverTip in 7220 under HSScreenShotResult", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 102
 testRunner.Then("Shows the context description as Autoscreenoff red context", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN7220_TestStep31_Set Auto Screen on, AC turn off display never and there is no " +
            "tip")]
        [NUnit.Framework.CategoryAttribute("IntelligentScreenOnly")]
        public virtual void VAN7220_TestStep31_SetAutoScreenOnACTurnOffDisplayNeverAndThereIsNoTip()
        {
            string[] tagsOfScenario = new string[] {
                    "IntelligentScreenOnly"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN7220_TestStep31_Set Auto Screen on, AC turn off display never and there is no " +
                    "tip", null, tagsOfScenario, argumentsOfScenario);
#line 105
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
#line 106
 testRunner.Given("Select DisplayDC to 300 minutes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 107
 testRunner.Given("Hover the mouse on the \'Device\' button using the automationId specified with json" +
                        " path \'$.Navbar.device\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 108
 testRunner.And("Go to Smart Assist page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 109
 testRunner.When("Turn on the Auto Screen Off toggle", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 110
 testRunner.Given("Select DisplayAC to 0 minutes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 111
 testRunner.Given("into Dashboard page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 112
 testRunner.Given("Hover the mouse on the \'Device\' button using the automationId specified with json" +
                        " path \'$.Navbar.device\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 113
 testRunner.And("Go to Smart Assist page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 114
 testRunner.Given("Click Intelligent Screen Link", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 115
 testRunner.Then("The AutoScreenOff Toggle is Enabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 116
 testRunner.Then("Take Screen Shot 30NoTip in 7220 under HSScreenShotResult", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
