using OpenQA.Selenium;

namespace HliAPtl.AutomationTests.UI.Core.Driver.Factory
{
    public interface IDriverFactory
    {
        IWebDriver GetDriver();
    }
}