using Automation_Framework_Core.Tables;
using OpenQA.Selenium;

namespace Automation_Gmail_Testing.Tables
{
    public class InboxRow : RowBase
    {
        public InboxRow(IWebElement element) : base(element)
        {
        }

        public IWebElement Checkbox => GetTdElement(1);
        public string Recipient => GetTdText(3);
        public string Message => GetTdText(5);
    }
}
