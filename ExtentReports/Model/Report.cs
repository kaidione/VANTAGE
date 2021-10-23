﻿using AventStack.ExtentReports.Utils;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace AventStack.ExtentReports.Model
{
    public abstract class Report
    {
        protected bool _useManaulConfiguration = false;
        protected AnalysisStrategy _strategy = AnalysisStrategy.Test;

        private DateTime _startTime;
        private Status _status = Status.Pass;
        private List<IExtentReporter> _reporterCollection;
        private List<string> _testRunnerLogCollection;
        private List<Test> _testCollection;
        private TestAttributeTestContextProvider<Category> _testAttrCategoryContext;
        private TestAttributeTestContextProvider<Author> _testAttrAuthorContext;
        private SessionStatusStats _sessionStatusStats;
        private SystemAttributeContext _systemAttributeContext;
        private ExceptionTestContextProvider _exceptionTestContextProvider;

        protected Report()
        {
            _startTime = DateTime.Now;

            _testAttrCategoryContext = new TestAttributeTestContextProvider<Category>();
            _testAttrAuthorContext = new TestAttributeTestContextProvider<Author>();
            _sessionStatusStats = new SessionStatusStats(_strategy);
            _systemAttributeContext = new SystemAttributeContext();
            _exceptionTestContextProvider = new ExceptionTestContextProvider();
        }

        protected void Attach(IExtentReporter reporter)
        {
            if (_reporterCollection == null)
                _reporterCollection = new List<IExtentReporter>();

            _reporterCollection.Add(reporter);
            reporter.Start();
        }

        protected void Detach(IExtentReporter reporter)
        {
            reporter.Stop();
            _reporterCollection.Remove(reporter);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        protected void CreateTest(Test test)
        {
            if (_reporterCollection.IsNullOrEmpty())
                throw new InvalidOperationException("No reporters were started. Atleast 1 reporter must be started to create tests.");

            if (_testCollection == null)
                _testCollection = new List<Test>();

            _testCollection.Add(test);

            _reporterCollection.ForEach(x => x.OnTestStarted(test));
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        protected void RemoveTest(Test test)
        {
            foreach (var t in _testCollection)
            {
                if (t.TestId == test.TestId)
                {
                    _testCollection.Remove(t);
                    return;
                }

                if (t.HasChildren())
                {
                    foreach (var n in t.NodeContext().GetAllItems())
                    {
                        if (n.TestId == test.TestId)
                        {
                            t.NodeContext().Remove(n);
                            return;
                        }
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        internal void AddNode(Test node)
        {
            _reporterCollection.ForEach(x => x.OnNodeStarted(node));
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        internal void AddLog(Test test, Log log)
        {
            CollectRunInfo();
            _reporterCollection.ForEach(x => x.OnLogAdded(test, log));
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void CollectRunInfo()
        {
            if (!HasTests())
                return;

            _testCollection.ForEach(test => EndTest(test));

            _sessionStatusStats.Refresh(_testCollection);

            _testCollection.ForEach(test =>
            {
                test.CategoryContext().GetAllItems().ForEach(c => _testAttrCategoryContext.AddAttributeContext((Category)c, test));
                test.AuthorContext().GetAllItems().ForEach(a => _testAttrAuthorContext.AddAttributeContext((Author)a, test));

                if (test.HasException())
                {
                    _exceptionTestContextProvider.AddExceptionInfoContext(test.ExceptionInfo, test);
                }

                if (test.HasChildren())
                {
                    test.NodeContext().GetAllItems().ForEach(node =>
                    {
                        AddNodeAttributes(node);
                        AddNodeExceptionInfo(node);
                    });
                }
            });
        }

        private void AddNodeAttributes(Test node)
        {
            if (node.HasCategory())
            {
                node.CategoryContext().GetAllItems().ForEach(c => _testAttrCategoryContext.AddAttributeContext((Category)c, node));
            }

            if (node.HasAuthor())
            {
                node.AuthorContext().GetAllItems().ForEach(a => _testAttrAuthorContext.AddAttributeContext((Author)a, node));
            }

            if (node.HasChildren())
            {
                node.NodeContext().GetAllItems().ForEach(n => AddNodeAttributes(n));
            }
        }

        private void AddNodeExceptionInfo(Test node)
        {
            if (node.HasException())
            {
                _exceptionTestContextProvider.AddExceptionInfoContext(node.ExceptionInfo, node);
            }
        }

        private void EndTest(Test test)
        {
            test.End();
            UpdateReportStatus(test.Status);
        }

        private void UpdateReportStatus(Status status)
        {
            int statusIndex = StatusHierarchy.GetStatusHierarchy().IndexOf(status);
            int reportStatusIndex = StatusHierarchy.GetStatusHierarchy().IndexOf(_status);

            _status = statusIndex < reportStatusIndex ? status : _status;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        internal void AssignCategory(Test test, Category category)
        {
            _reporterCollection.ForEach(x => x.CategoryContext = _testAttrCategoryContext);
            _reporterCollection.ForEach(x => x.OnCategoryAssigned(test, category));
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        internal void AssignAuthor(Test test, Author author)
        {
            _reporterCollection.ForEach(x => x.OnAuthorAssigned(test, author));
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        internal void AddScreenCapture(Test test, ScreenCapture sc)
        {
            _reporterCollection.ForEach(x => x.OnScreenCaptureAdded(test, sc));
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        protected void Flush()
        {
            if (!HasTests())
                return;

            CollectRunInfo();
            NotifyReporters();
        }

        private bool HasTests()
        {
            if (_testCollection.IsNullOrEmpty())
                return false;

            return true;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private void NotifyReporters()
        {
            _reporterCollection.ForEach(x =>
            {
                x.TestList = _testCollection;
                x.CategoryContext = _testAttrCategoryContext;
                x.ExceptionContext = _exceptionTestContextProvider;
                x.SystemAttributeContext = _systemAttributeContext;
                x.TestRunnerLogs = _testRunnerLogCollection;
                x.SessionStatusStats = _sessionStatusStats;
                x.StartTime = _startTime;
            });

            _reporterCollection.ForEach(x => x.Flush());
        }

        protected void End()
        {
            Flush();

            _reporterCollection.ForEach(x => x.Stop());
            _reporterCollection.Clear();
        }

        protected void AddSystemAttribute(SystemAttribute sa)
        {
            _systemAttributeContext.Add(sa);
        }

        protected void AddTestRunnerLog(string log)
        {
            if (_testRunnerLogCollection == null)
                _testRunnerLogCollection = new List<string>();

            _testRunnerLogCollection.Add(log);
        }

        protected void SetAnalysisStrategy(AnalysisStrategy strategy)
        {
            _strategy = strategy;
            _sessionStatusStats = new SessionStatusStats(strategy);
        }
    }
}
