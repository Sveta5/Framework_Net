using Automation_Framework_Core.Core.DriverHelpers;
using OpenQA.Selenium;

namespace Automation_Framework_Core.Core.DriverFactories
{
    public interface IDriverFactory
    {
        IWebDriver CreateDriver();
        IDriverHelper GetDriverHelper();
    }
}
