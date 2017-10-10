using Automation_Framework_Core.Core.DriverHelpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Automation_Framework_Core.Core.DriverFactories
{
    public class ChromeDriverFactory : IDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            var chromeOptions = new ChromeOptions();

            chromeOptions.AddArguments("test-type");
            chromeOptions.AddArguments("start-maximized");
            chromeOptions.AddArguments("--disable-extensions");
            chromeOptions.AddArguments("no-sandbox");
            chromeOptions.AddUserProfilePreference("download.directory_upgrade", true);
            chromeOptions.AddUserProfilePreference("profile.default_content_settings.popups", 0);
            chromeOptions.AddUserProfilePreference("profile.default_content_settings.multiple-automatic-downloads", 1);

            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);

            return new ChromeDriver(chromeOptions);
        }

        public IDriverHelper GetDriverHelper()
        {
            return new ChromeDriverHelper();
        }
    }
}
