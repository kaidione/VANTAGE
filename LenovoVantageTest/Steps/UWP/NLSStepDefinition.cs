using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP
{
    /*Author: Marcus*/
    [Binding]
    public class NLSStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        InformationalWebDriver webDriver;
        public NLSStepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;

        }

        [StepDefinition(@"verify string '(.*)' from resource file displays on Vantage by using json path '(.*)' and is used by GUI element with specific automationId (.*)")]
        void VerifyNLSTextByAutoId(string _autoIdOfTheElementToBeChecked, string _jsonPath_inAssetsFile, string _automationId)
        {

            string autooId_ElementToBeChecked = VantageAutomationIDCollector.Instance.GetVantageAutomationID(_autoIdOfTheElementToBeChecked).ToString();
            string testingNLS = Language.instance.GetPrefered1stLanguage_2letters().ToString();
            string expectNLSText = VantageAssetsHelper.SingleTon.GetSpecificGUIContentByLanguage(_jsonPath_inAssetsFile, Language.instance.GetPrefered1stLanguage_2letters()).ToString();

            if (VantageUI.instance.VantageElementExistUsingAutomationId(autooId_ElementToBeChecked))
            {
                WindowsElement elementToBeChecked = webDriver.Session.FindElementByAccessibilityId(autooId_ElementToBeChecked);
                string actualNameText = elementToBeChecked.GetAttribute("Name");
                if (!actualNameText.Equals(expectNLSText)) //e.g.      Expected: "de", But was:  "13.3 GB de 15.8 GB"
                {
                    if (actualNameText.Contains(expectNLSText))
                    {
                        Assert.IsTrue(true, $"Verify element(automationId='{autooId_ElementToBeChecked}') actual NLS Text({actualNameText}) contains expect NLS({testingNLS}) Text({expectNLSText})");
                        Console.WriteLine($"Pass, showing NLS({testingNLS}) text on element(automationId='{autooId_ElementToBeChecked}') contains expected(Name='{expectNLSText}')");
                    }
                    else
                    {
                        Assert.IsTrue(false, $"Verify element(automationId='{autooId_ElementToBeChecked}') actual NLS Text({actualNameText}) contains expect NLS({testingNLS}) Text({expectNLSText})");
                    }
                }
                else
                {
                    Assert.AreEqual(expectNLSText, actualNameText, $"Verify element(automationId='{autooId_ElementToBeChecked}') actual NLS Text({actualNameText}) = expect NLS({testingNLS}) Text({expectNLSText})");
                    Console.WriteLine($"Pass, showing NLS({testingNLS}) text on element(automationId='{autooId_ElementToBeChecked}') as expected(Name='{expectNLSText}')");
                }

            }
            else
            {
                Assert.AreEqual(expectNLSText, "", $"Unable to find element(automationId='{autooId_ElementToBeChecked}')! unable to verify with expected NLS({testingNLS}) text(Name='{expectNLSText}')");
            }
        }

        [StepDefinition(@"verify string '(.*)' (displays|NOT display) on Vantage by using json path '(.*)' to retrieve from resource file")]
        public void VerifyStringBySearching_Default(string _comment_neverUse, string _displayOrNot, string _jPathInResourceFile)
        {
            VerifyStringBySearching(_comment_neverUse, _displayOrNot, 10, _jPathInResourceFile);

        }
        [StepDefinition(@"verify string '(.*)' (displays|NOT display) in '(.*)' seconds on Vantage by using json path '(.*)' to retrieve from resource file")]
        public void VerifyStringBySearching(string _comment_neverUse, string _displayOrNot, int _timeoutInSeconds, string _jPathInResourceFile)
        {

            string expected = VantageAssetsHelper.SingleTon.GetSpecificGUIContentByLanguage(_jPathInResourceFile, Language.instance.GetPrefered1stLanguage_2letters()).ToString();
            expected = expected.Trim();
            if (_displayOrNot.Trim().ToLower().Equals("displays"))
            {
                DateTime past = DateTime.Now;
                bool found = VantageElementExistUsingLonName(expected, true, _timeoutInSeconds);
                double diffMillisecond = (DateTime.Now - past).TotalMilliseconds;
                if (diffMillisecond <= _timeoutInSeconds * 1000 && found)
                {
                    LogHelper.Logger.Instance.WriteLog($"Sucess: expected string found on Vantage. JsonPath in resource file is {_jPathInResourceFile}");
                    Assert.IsTrue(true, $"NOT found the expected string with json path {_jPathInResourceFile}");
                    return;
                }
                if (diffMillisecond > _timeoutInSeconds * 1000 && found)
                {
                    Assert.IsTrue(false, $"loading performance is beyond design {diffMillisecond} milliseconds, although found the expected string with json path {_jPathInResourceFile}");
                    return;
                }
                Assert.IsTrue(false, $"NOT found the expected string with json path {_jPathInResourceFile}");
                return;
            }
            else
            {
                Assert.IsTrue(VantageElementExistUsingLonName(expected, false, _timeoutInSeconds), $"Found the unexpected string with json path {_jPathInResourceFile}");
            }

        }

        [StepDefinition(@"verify strings '(.*)' (displays|NOT display) in '(.*)' seconds on Vantage by using json path '(.*)' to retrieve from resource file")]
        public void VerifyMultiStringBySearching(string _comment_neverUse, string _displayOrNot, int _timeoutInSeconds, string _jPathsInResourceFile)
        {
            List<string> jpaths = _jPathsInResourceFile.Split(',').ToList();
            List<string> liExpected = new List<string>();
            for (int i = 0; i < jpaths.Count; i++)
            {
                string expected = VantageAssetsHelper.SingleTon.GetSpecificGUIContentByLanguage(jpaths[i], Language.instance.GetPrefered1stLanguage_2letters()).ToString();
                liExpected.Add(expected);
            }

            if (_displayOrNot.Trim().ToLower().Equals("displays"))
            {
                DateTime past = DateTime.Now;
                for (int i = 0; i < jpaths.Count; i++)
                {
                    bool found = VantageElementExistUsingLonName(liExpected[i], true, _timeoutInSeconds);
                    if (!found)
                    {
                        Assert.IsTrue(false, $"NOT found the expected string with json path {jpaths[i]}");
                        return;
                    }
                }
                double diffMillisecond = (DateTime.Now - past).TotalMilliseconds;
                if (diffMillisecond <= _timeoutInSeconds * 1000)
                {
                    LogHelper.Logger.Instance.WriteLog($"Sucess: expected strings found on Vantage. Total consumed time is {diffMillisecond} milliseconds ");
                    Assert.IsTrue(true);
                    return;
                }
                if (diffMillisecond > _timeoutInSeconds * 1000)
                {
                    Assert.IsTrue(false, $"loading performance is beyond design, {diffMillisecond} milliseconds, although found the expected strings");
                    return;
                }

            }
            else
            {
                for (int i = 0; i < jpaths.Count; i++)
                {
                    bool found = VantageElementExistUsingLonName(liExpected[i], true, _timeoutInSeconds);
                    if (found)
                    {
                        Assert.IsTrue(false, $"found the unexpected string with json path {jpaths[i]}");
                        return;
                    }
                }
                Assert.IsTrue(true);
            }

        }
        public bool VantageElementExistUsingLonName(string _expectedName, bool _expectedExistence, int _timeoutInSeconds = 10)
        {
            DateTime past = DateTime.Now;
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"ExternalUIAHelper\console_UIADebug.exe");
            process.StartInfo.Arguments = $"00 \"{Constants.VantageTitle}\" \"{_expectedName.Replace("\"", "\\\"")}\"";
            process.StartInfo.CreateNoWindow = false;
            while (past.AddSeconds(_timeoutInSeconds) > DateTime.Now)
            {
                process.Start();
                process.WaitForExit();
                if (_expectedExistence)
                {
                    if (process.ExitCode == 0)
                    {
                        return true;
                    }
                }
                else
                {
                    if (process.ExitCode == 1)
                    {
                        return true;
                    }
                }
                System.Threading.Thread.Sleep(500);

            }
            return false;

        }

        public bool toolbarElementExistUsingLonName(string _expectedName, bool _expectedExistence, int _timeoutInSeconds = 10)
        {
            string toolbar = "Lenovo Vantage Toolbar. ";
            DateTime past = DateTime.Now;
            Process process = new Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\console_UIADebug.exe");
            process.StartInfo.Arguments = $"00 \"{toolbar}\" \"{_expectedName}\"";

            while (past.AddSeconds(_timeoutInSeconds) > DateTime.Now)
            {
                process.Start();
                process.WaitForExit();
                if (_expectedExistence)
                {
                    if (process.ExitCode == 0)
                    {
                        return true;
                    }
                }
                else
                {
                    if (process.ExitCode == 1)
                    {
                        return true;
                    }
                }
                System.Threading.Thread.Sleep(500);

            }
            return false;

        }


        [StepDefinition(@"end time evaluation")]
        public void EndTimeEvaluation()
        {
            ScenarioContext.Current.Add("endTimer", DateTime.Now);
        }

        [StepDefinition(@"above steps are DONE in '(.*)' millinseconds")]
        public void judgeTime(int _timeout)
        {
            double milliseconds = ((DateTime)ScenarioContext.Current["endTimer"] - (DateTime)ScenarioContext.Current["startTimer"]).TotalMilliseconds;
            LogHelper.Logger.Instance.WriteLog($"Total consumed time= {milliseconds} milliseconds");
            Assert.IsTrue(milliseconds < _timeout, $"execution time {milliseconds}>expected {_timeout}");

        }

    }
}
