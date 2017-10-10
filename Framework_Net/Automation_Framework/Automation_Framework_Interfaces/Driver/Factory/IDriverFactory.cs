using Automation_Framework_Interfaces.Driver.Instance;

namespace Automation_Framework_Interfaces.Driver.Factory
{
    public interface IDriverFactory<T>
    {
        IDriver<T> CreateDriver();
    }
}
