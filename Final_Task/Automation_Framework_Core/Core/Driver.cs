using System;
using System.Configuration;
using System.Linq;
using System.Threading;
using Automation_Framework_Core.Core.DriverFactories;
using Automation_Framework_Core.Core.DriverHelpers;
using Automation_Framework_Core.Extensions;
using Automation_Framework_Core.Logger;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation_Framework_Core.Core
{
    internal static class Driver
    {
        private static readonly object SyncRoot = new object();
        private static readonly IDriverFactory DriverFactory;
        private static readonly IDriverHelper DriverHelper;

        static Driver()
        {
            var browserAgentString = ConfigurationManager.AppSettings["BrowserAgent"];

            DriverFactory = DriverFactorySelector.GetDriverFactory(browserAgentString);
            DriverHelper = DriverFactory.GetDriverHelper();
        }

        public static IWebDriver Current
        {
            get
            {
                var driver = DriverHelper.TryToGetDriver();
                if (driver != null)
                {
                    return driver;
                }

                lock (SyncRoot)
                {
                    driver = DriverFactory.CreateDriver();
                    driver.Manage().Window.Maximize();

                    TestContext.CurrentContext.SaveProperty("driver_" + Thread.CurrentThread.ManagedThreadId, driver);

                    LoggingHelper.LogInformation("Driver is created");
                }

                return driver;
            }
        }

        public static void Close()
        {
            try
            {
                LoggingHelper.LogInformation("Try to close driver");

                Current.Quit();
            }
            catch (Exception ex)
            {
                LoggingHelper.LogError(ex.StackTrace);
            }
            finally
            {
                LoggingHelper.LogInformation("Driver should be closed");
            }
        }

        public static void CleanCookies()
        {
            try
            {
                LoggingHelper.LogInformation("Clean Cookies");

                Current.Manage().Cookies.DeleteAllCookies();
            }
            catch (Exception ex)
            {
                LoggingHelper.LogError("Error has occured in Clean Cookies " + ex);
            }
        }

        public static IWebElement WaitFor(By locator, TimeSpan? timeout = null)
        {
            var wait = timeout.HasValue ? new WebDriverWait(Current, timeout.Value) :
                new WebDriverWait(Current, Timeouts.Timeouts.Default);

            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitForElementIsHidden(By locator, TimeSpan? timeout = null)
        {
            var wait = timeout.HasValue ? new WebDriverWait(Current, timeout.Value) :
                new WebDriverWait(Current, Timeouts.Timeouts.Default);

            wait.Until(driver =>
            {
                var elements = driver.FindElements(locator);

                try
                {
                    return elements.Count == 0 || elements.All(x => !x.Displayed);
                }
                // Once element is deleted from DOM webdriver throws StaleElementReferenceException
                catch (StaleElementReferenceException)
                {
                    return driver.FindElements(locator).Any();
                }
            });
        }
        public static void WaitForElementIsNotEnabled(By locator, TimeSpan? timeout = null)
        {
            var wait = timeout.HasValue ? new WebDriverWait(Current, timeout.Value) :
                new WebDriverWait(Current, Timeouts.Timeouts.Default);

            wait.Until(driver => !driver.FindElement(locator).Enabled);
        }
        public static IWebElement WaitForElementPresent(By locator, TimeSpan? timeout = null)
        {
            var wait = timeout.HasValue ? new WebDriverWait(Current, timeout.Value) :
                new WebDriverWait(Current, Timeouts.Timeouts.Default);

            return wait.Until(ExpectedConditions.ElementExists(locator));
        }
    }
}
