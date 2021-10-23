﻿using AventStack.ExtentReports.Model;

namespace AventStack.ExtentReports
{
    public interface ITestListener
    {
        void OnTestStarted(Test test);
        void OnNodeStarted(Test node);
        void OnLogAdded(Test test, Log log);
        void OnCategoryAssigned(Test test, Category category);
        void OnAuthorAssigned(Test test, Author author);
        void OnScreenCaptureAdded(Test test, ScreenCapture screenCapture);
    }
}
