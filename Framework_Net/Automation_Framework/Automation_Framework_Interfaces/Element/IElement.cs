using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Framework_Interfaces.Element
{
    public interface IElement<T>
    {
        string Text { get; set; }
        bool Displayed { get; }
        bool IsElementEnabled();
        void Click();
        void SendKeys(string text);
        string GetAttribute(string attribute);
        T GetCurrentElement();
        void WaitUntilElemntIsVisible(TimeSpan? timeout = null);//wait until condition
        void WaitUntilElemntToBeClickable(TimeSpan? timeout = null);
        void WaitUntilElemntIsInVisible(TimeSpan? timeout = null);
        void Clear();
    }
}
