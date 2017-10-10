using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HliAPtl.AutomationTests.UI.Core.Driver.Factory
{
    public class ChromeDriverFactory : IDriverFactory
    {
        public IWebDriver GetDriver()
        {
            var chromeOptions = new ChromeOptions();

            chromeOptions.AddArguments("test-type");
            chromeOptions.AddArguments("start-maximized");
            chromeOptions.AddArguments("--disable-extensions");
            chromeOptions.AddArguments("no-sandbox");
            chromeOptions.AddUserProfilePreference("profile.default_content_settings.popups", 0);


            return new ChromeDriver(chromeOptions);
        }
    }
}
