using System;
using HliAPtl.AutomationTests.UI.Core.Driver.Factory;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HliAPtl.AutomationTests.UI.Core.Driver
{
    public class WebDriver
    {
        private static IWebDriver _driverInstance;

        private WebDriver()
        {
        }

        public static IWebDriver DriverInstance
        {
            get
            {
                if (_driverInstance != null)
                {
                    return _driverInstance;
                }

                var browserAgentString = GlobalTestConfiguration.AptlConfiguration.TestSettings.BrowserAgent;
                BrowserAgent browserAgent;
                Enum.TryParse(browserAgentString, out browserAgent);

                var driverFactory = DriverSelector.GetDriverFactory(browserAgent);
                _driverInstance = driverFactory.GetDriver();

                _driverInstance.Manage().Cookies.DeleteAllCookies();
                _driverInstance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
                _driverInstance.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(40));
                return _driverInstance;
            }
        }

        public static void Close()
        {
            if (_driverInstance == null)
            {
                return;
            }
            _driverInstance.Quit();
            _driverInstance = null;
        }

        public static void NavigateTo(string url)
        {
            var driver = DriverInstance;
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
        }

        public static ICookieJar GetCookies()
        {
            return DriverInstance.Manage().Cookies;
        }

        public static void RefreshPage()
        {
            DriverInstance.Navigate().Refresh();
        }

        public static IWebElement WaitFor(By selector, TimeSpan? timeout)
        {
            var wait = timeout.HasValue
                ? new WebDriverWait(_driverInstance, timeout.Value)
                : new WebDriverWait(_driverInstance, TimeSpan.FromSeconds(1));

            return wait.Until(ExpectedConditions.ElementIsVisible(selector));
        }

        public static IWebElement WaitForElementToBeClickable(By locator, TimeSpan? timeout)
        {
            var wait = timeout.HasValue
                ? new WebDriverWait(DriverInstance, timeout.Value)
                : new WebDriverWait(DriverInstance, TimeSpan.FromSeconds(10));

            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static IWebElement WaitForElementPresent(By locator, TimeSpan? timeout)
        {
            var wait = timeout.HasValue
                ? new WebDriverWait(DriverInstance, timeout.Value)
                : new WebDriverWait(DriverInstance, TimeSpan.FromSeconds(1));

            return wait.Until(ExpectedConditions.ElementExists(locator));
        }

        public static bool WaitForElementInvisible(By locator, TimeSpan? timeout)
        {
            var wait = timeout.HasValue
                ? new WebDriverWait(DriverInstance, timeout.Value)
                : new WebDriverWait(DriverInstance, TimeSpan.FromSeconds(10));

            return wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }
    }
}