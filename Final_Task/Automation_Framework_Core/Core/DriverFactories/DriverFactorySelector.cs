using System;

namespace Automation_Framework_Core.Core.DriverFactories
{
    public enum BrowserAgents
    {
        Chrome,
    }

    public static class DriverFactorySelector
    {
        public static IDriverFactory GetDriverFactory(string browserAgentAsString)
        {
            var browserAgent = (BrowserAgents)Enum.Parse(typeof(BrowserAgents), browserAgentAsString);

            switch (browserAgent)
            {
                case BrowserAgents.Chrome:
                    return new ChromeDriverFactory();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
