using System;

namespace HliAPtl.AutomationTests.UI.Core.Driver.Factory
{
    public class DriverSelector
    {
        public static IDriverFactory GetDriverFactory(BrowserAgent agent)
        {
            switch (agent)
            {
                case BrowserAgent.Firefox:
                    return new FirefoxDriverFactory();
                case BrowserAgent.Chrome:
                    return new ChromeDriverFactory();
                default:
                    throw new ArgumentOutOfRangeException(nameof(agent), agent, null);
            }
        }
    }
}