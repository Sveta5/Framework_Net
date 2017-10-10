using System;
using System.Drawing.Imaging;
using System.IO;
using Automation_Framework_Core.Extensions;
using Automation_Framework_Core.Logger;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Automation_Framework_Core.Report;

namespace Automation_Framework_Core.Core
{
    public class BaseTest
    {
        private static readonly object LockObject = new object();

        protected TestContext Context => TestContext.CurrentContext;

        [TearDown]
        public virtual void TestCaseTearDown()
        {
            //var testIds = TestContext.CurrentContext.Test.Properties["TestId"];
            var testInfo = $" {Context.Test.FullName}   Time: {DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss")}";
            var testResult = Context.Result;

            try
            {
                var testIsPassed = testResult.Outcome.Status == TestStatus.Passed;
       
                if (testIsPassed)
                {
                    LoggingHelper.LogInformation("Test is passed");
                    Reporter.PassedTestReport(Context.Test.Name, testInfo);
                }
                else
                {
                    LoggingHelper.LogInformation("Test is failed");

                    string path = MakeScreenshot();
                    Reporter.NotPassedTestReport(testInfo, Context, path);
                }
            }

            finally
            {
                Driver.Close();
            }
        }

        private string MakeScreenshot()
        {
            var screenshot = ((ITakesScreenshot)Driver.Current).GetScreenshot();
            Directory.CreateDirectory("Screenshots");

            var path = Path.Combine(Environment.CurrentDirectory + @"\Screenshots",
                $"{Context.GetTestName()}_{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}.jpg");
            try
            {
                screenshot.SaveAsFile(path, ImageFormat.Png);
            }
            catch (Exception ex)
            {
                LoggingHelper.LogError(ex.ToString());
            }

            return path;
        }
    }
}
