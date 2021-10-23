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
namespace LenovoVantageTest.Features.UWP.Vantage_NerveCenter
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("VAN19785_GamingUICapabilityCheck")]
    public partial class VAN19785_GamingUICapabilityCheckFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "VAN19785_GamingUICapabilityCheck.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features/UWP/Vantage_NerveCenter", "VAN19785_GamingUICapabilityCheck", "\tTest Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-19785\r\n\tAuthor： X" +
                    "uwei & Chen Pengjie\r\n\tAutomated Test Step 1-12", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void FeatureBackground()
        {
#line 6
#line hidden
#line 7
 testRunner.Given("Machine is Gaming", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN19785_TestStep01_Y Logo Should Be Shown In Legion")]
        [NUnit.Framework.CategoryAttribute("GamingUICapabilityLegion")]
        [NUnit.Framework.CategoryAttribute("GamingSmokeLegionUI")]
        public virtual void VAN19785_TestStep01_YLogoShouldBeShownInLegion()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingUICapabilityLegion",
                    "GamingSmokeLegionUI"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN19785_TestStep01_Y Logo Should Be Shown In Legion", null, tagsOfScenario, argumentsOfScenario);
#line 10
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
#line 6
this.FeatureBackground();
#line hidden
#line 11
 testRunner.Given("The machine support \'Y\' Logo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 12
 testRunner.Then("Gaming Logo Should Be Shown or Hidden \'shown\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 13
 testRunner.Then("Take Screen Shot VAN19785_TestStep01_Y_Logo in 19785 under GamingScreenShotResult" +
                        "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN19785_TestStep02_Legion Edge Header Should Be Shown In Legion")]
        [NUnit.Framework.CategoryAttribute("GamingUICapabilityLegion")]
        [NUnit.Framework.CategoryAttribute("GamingSmokeLegionUI")]
        public virtual void VAN19785_TestStep02_LegionEdgeHeaderShouldBeShownInLegion()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingUICapabilityLegion",
                    "GamingSmokeLegionUI"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN19785_TestStep02_Legion Edge Header Should Be Shown In Legion", null, tagsOfScenario, argumentsOfScenario);
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
#line 6
this.FeatureBackground();
#line hidden
#line 17
 testRunner.Given("The machine support \'Y\' Logo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 18
 testRunner.Then("The \'Legion\' Header Should Be Shown or Hidden \'shown\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN19785_TestStep03_Legion Edge Section Should Be Shown In Legion")]
        [NUnit.Framework.CategoryAttribute("GamingUICapabilityLegion")]
        [NUnit.Framework.CategoryAttribute("GamingSmokeLegionUI")]
        public virtual void VAN19785_TestStep03_LegionEdgeSectionShouldBeShownInLegion()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingUICapabilityLegion",
                    "GamingSmokeLegionUI"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN19785_TestStep03_Legion Edge Section Should Be Shown In Legion", null, tagsOfScenario, argumentsOfScenario);
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
#line 6
this.FeatureBackground();
#line hidden
#line 22
 testRunner.Given("The machine support \'Y\' Logo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 23
 testRunner.Then("The \'Legion\' Should Be Shown or Hidden \'shown\' in the Right Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN19785_TestStep04_Legion Edge Image Should Be Shown In Legion")]
        [NUnit.Framework.CategoryAttribute("GamingUICapabilityLegion")]
        [NUnit.Framework.CategoryAttribute("GamingSmokeLegionUI")]
        public virtual void VAN19785_TestStep04_LegionEdgeImageShouldBeShownInLegion()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingUICapabilityLegion",
                    "GamingSmokeLegionUI"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN19785_TestStep04_Legion Edge Image Should Be Shown In Legion", null, tagsOfScenario, argumentsOfScenario);
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
#line 6
this.FeatureBackground();
#line hidden
#line 27
 testRunner.Given("The machine support \'Y\' Logo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 28
 testRunner.When("Click Help icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 29
 testRunner.Then("The \'Legion\' Should Be Shown or Hidden \'shown\' in Help page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 30
 testRunner.Then("Take Screen Shot VAN19785_TestStep04_Help in 19785 under GamingScreenShotResult", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN19785_TestStep05_L Logo Should Be Shown In Lite Notebook")]
        [NUnit.Framework.CategoryAttribute("GamingUICapabilityIdeapadGAMING")]
        [NUnit.Framework.CategoryAttribute("GamingSmokeLiteNBUI")]
        public virtual void VAN19785_TestStep05_LLogoShouldBeShownInLiteNotebook()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingUICapabilityIdeapadGAMING",
                    "GamingSmokeLiteNBUI"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN19785_TestStep05_L Logo Should Be Shown In Lite Notebook", null, tagsOfScenario, argumentsOfScenario);
#line 33
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
#line 6
this.FeatureBackground();
#line hidden
#line 34
 testRunner.Given("The machine support \'L\' Logo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 35
 testRunner.Then("Gaming Logo Should Be Shown or Hidden \'shown\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 36
 testRunner.Then("Take Screen Shot VAN19785_TestStep05_L_Logo in 19785 under GamingScreenShotResult" +
                        "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN19785_TestStep06_IdeapadGAMING Header Should Be Shown In Lite Notebook")]
        [NUnit.Framework.CategoryAttribute("GamingUICapabilityIdeapadGAMING")]
        [NUnit.Framework.CategoryAttribute("GamingSmokeLiteNBUI")]
        public virtual void VAN19785_TestStep06_IdeapadGAMINGHeaderShouldBeShownInLiteNotebook()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingUICapabilityIdeapadGAMING",
                    "GamingSmokeLiteNBUI"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN19785_TestStep06_IdeapadGAMING Header Should Be Shown In Lite Notebook", null, tagsOfScenario, argumentsOfScenario);
#line 39
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
#line 6
this.FeatureBackground();
#line hidden
#line 40
 testRunner.Given("The machine support \'L\' Logo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 41
 testRunner.Then("The \'IdeapadGAMING\' Header Should Be Shown or Hidden \'shown\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN19785_TestStep07_IdeapadGAMING Section Should Be Shown In Lite Notebook")]
        [NUnit.Framework.CategoryAttribute("GamingUICapabilityIdeapadGAMING")]
        [NUnit.Framework.CategoryAttribute("GamingSmokeLiteNBUI")]
        public virtual void VAN19785_TestStep07_IdeapadGAMINGSectionShouldBeShownInLiteNotebook()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingUICapabilityIdeapadGAMING",
                    "GamingSmokeLiteNBUI"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN19785_TestStep07_IdeapadGAMING Section Should Be Shown In Lite Notebook", null, tagsOfScenario, argumentsOfScenario);
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
#line 6
this.FeatureBackground();
#line hidden
#line 45
 testRunner.Given("The machine support \'L\' Logo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 46
 testRunner.Then("The \'IdeapadGAMING\' Should Be Shown or Hidden \'shown\' in the Right Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN19785_TestStep08_IdeapadGAMING Image Should Be Shown In Lite Notebook")]
        [NUnit.Framework.CategoryAttribute("GamingUICapabilityIdeapadGAMING")]
        [NUnit.Framework.CategoryAttribute("GamingSmokeLiteNBUI")]
        public virtual void VAN19785_TestStep08_IdeapadGAMINGImageShouldBeShownInLiteNotebook()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingUICapabilityIdeapadGAMING",
                    "GamingSmokeLiteNBUI"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN19785_TestStep08_IdeapadGAMING Image Should Be Shown In Lite Notebook", null, tagsOfScenario, argumentsOfScenario);
#line 49
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
#line 6
this.FeatureBackground();
#line hidden
#line 50
 testRunner.Given("The machine support \'L\' Logo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 51
 testRunner.When("Click Help icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 52
 testRunner.Then("The \'IdeapadGAMING\' Should Be Shown or Hidden \'shown\' in Help page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 53
 testRunner.Then("Take Screen Shot VAN19785_TestStep08_Help in 19785 under GamingScreenShotResult", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN19785_TestStep09_L Logo Should Be Shown In Lite Desktop")]
        [NUnit.Framework.CategoryAttribute("GamingUICapabilityIdeaCentreGAMING")]
        [NUnit.Framework.CategoryAttribute("GamingSmokeLiteDTUI")]
        public virtual void VAN19785_TestStep09_LLogoShouldBeShownInLiteDesktop()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingUICapabilityIdeaCentreGAMING",
                    "GamingSmokeLiteDTUI"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN19785_TestStep09_L Logo Should Be Shown In Lite Desktop", null, tagsOfScenario, argumentsOfScenario);
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
#line 6
this.FeatureBackground();
#line hidden
#line 57
 testRunner.Given("The machine support \'L\' Logo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 58
 testRunner.Then("Gaming Logo Should Be Shown or Hidden \'shown\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 59
 testRunner.Then("Take Screen Shot VAN19785_TestStep09_L_Logo in 19785 under GamingScreenShotResult" +
                        "", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN19785_TestStep10_IdeaCentreGAMING Header Should Be Shown In Lite Desktop")]
        [NUnit.Framework.CategoryAttribute("GamingUICapabilityIdeaCentreGAMING")]
        [NUnit.Framework.CategoryAttribute("GamingSmokeLiteDTUI")]
        public virtual void VAN19785_TestStep10_IdeaCentreGAMINGHeaderShouldBeShownInLiteDesktop()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingUICapabilityIdeaCentreGAMING",
                    "GamingSmokeLiteDTUI"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN19785_TestStep10_IdeaCentreGAMING Header Should Be Shown In Lite Desktop", null, tagsOfScenario, argumentsOfScenario);
#line 62
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
#line 6
this.FeatureBackground();
#line hidden
#line 63
 testRunner.Given("The machine support \'L\' Logo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 64
 testRunner.Then("The \'IdeaCentreGAMING\' Header Should Be Shown or Hidden \'shown\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN19785_TestStep11_IdeaCentreGAMING Section Should Be Shown In Lite Desktop")]
        [NUnit.Framework.CategoryAttribute("GamingUICapabilityIdeaCentreGAMING")]
        [NUnit.Framework.CategoryAttribute("GamingSmokeLiteDTUI")]
        public virtual void VAN19785_TestStep11_IdeaCentreGAMINGSectionShouldBeShownInLiteDesktop()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingUICapabilityIdeaCentreGAMING",
                    "GamingSmokeLiteDTUI"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN19785_TestStep11_IdeaCentreGAMING Section Should Be Shown In Lite Desktop", null, tagsOfScenario, argumentsOfScenario);
#line 67
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
#line 6
this.FeatureBackground();
#line hidden
#line 68
 testRunner.Given("The machine support \'L\' Logo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 69
 testRunner.Then("The \'IdeaCentreGAMING\' Should Be Shown or Hidden \'shown\' in the Right Section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("VAN19785_TestStep12_IdeaCentreGAMING Image Should Be Shown In Lite Desktop")]
        [NUnit.Framework.CategoryAttribute("GamingUICapabilityIdeaCentreGAMING")]
        [NUnit.Framework.CategoryAttribute("GamingSmokeLiteDTUI")]
        public virtual void VAN19785_TestStep12_IdeaCentreGAMINGImageShouldBeShownInLiteDesktop()
        {
            string[] tagsOfScenario = new string[] {
                    "GamingUICapabilityIdeaCentreGAMING",
                    "GamingSmokeLiteDTUI"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("VAN19785_TestStep12_IdeaCentreGAMING Image Should Be Shown In Lite Desktop", null, tagsOfScenario, argumentsOfScenario);
#line 72
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
#line 6
this.FeatureBackground();
#line hidden
#line 73
 testRunner.Given("The machine support \'L\' Logo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 74
 testRunner.When("Click Help icon", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 75
 testRunner.Then("The \'IdeapCentreGAMING\' Should Be Shown or Hidden \'shown\' in Help page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 76
 testRunner.Then("Take Screen Shot VAN19785_TestStep12_Help in 19785 under GamingScreenShotResult", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
