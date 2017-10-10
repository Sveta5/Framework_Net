using System;
using System.Threading;
using Automation_Framework_Core.Extensions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Automation_Framework_Core.Core.DriverHelpers
{
    internal abstract class DriverHelperBase : IDriverHelper
    {
        public virtual IWebDriver TryToGetDriver()
        {
            IWebDriver driver;

            if (TestContext.CurrentContext.TryGetObjectProperty("driver_" + Thread.CurrentThread.ManagedThreadId, out driver) && driver.WindowHandles != null)
                return driver;

            return null;
        }

        protected void WaitForCondition(Func<bool> expectedCondition, TimeSpan timeout, IWebDriver current)
        {
            var waitWithCustomTimeout = new WebDriverWait(current, timeout);

            Func<IWebDriver, bool> action = driver => expectedCondition();
            waitWithCustomTimeout.Until(action);
        }
    }
}
