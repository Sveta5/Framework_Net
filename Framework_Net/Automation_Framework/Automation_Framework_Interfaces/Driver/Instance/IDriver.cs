using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Framework_Interfaces.Driver.Instance
{
    public interface IDriver<T>
    {
        T GetCurrent();
        void Open();
        T FindElement();
        IEnumerable<T> FindElements();
        void Cloose();
        void CleanCookies();
        //wait for condition
    }
}
