using OpenQA.Selenium;

namespace Automation_Framework_Core.Core.DriverHelpers
{
    public interface IDriverHelper
    {
        IWebDriver TryToGetDriver();
    }
}
