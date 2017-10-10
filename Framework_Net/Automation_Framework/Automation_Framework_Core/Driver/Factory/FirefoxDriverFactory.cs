using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace HliAPtl.AutomationTests.UI.Core.Driver.Factory
{
    public class FirefoxDriverFactory : IDriverFactory
    {
        public IWebDriver GetDriver()
        {
            var profile = new FirefoxProfile
            {
                AcceptUntrustedCertificates = true,
                EnableNativeEvents = true,
                DeleteAfterUse = true
            };

            return new FirefoxDriver(profile);
        }
    }
}