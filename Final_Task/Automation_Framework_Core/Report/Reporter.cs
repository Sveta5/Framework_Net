
using NUnit.Framework;

namespace Automation_Framework_Core.Report
{
    public static class Reporter
    {
        public static void PassedTestReport(string testName,string testInfo)
        {
            ReportHelper.LogPositive($"{testInfo}\n");
            ReportHelper.LogPositive($"{testName}:  Test was passed ");
            ReportHelper.SetSeparateElement();
        }

        public static void NotPassedTestReport(string testName, TestContext testResult, string screenshotPath)
        {
            ReportHelper.LogHeader($"{testName}\n  {testResult.Test.Name}: Test was failed");
            ReportHelper.LogNegative(testResult.Result.Message);
            ReportHelper.LogScreenshot(screenshotPath);
            ReportHelper.LogElements($"Stack trace \n {testResult.Result.StackTrace}");
            ReportHelper.SetSeparateElement();
        }
    }
}
