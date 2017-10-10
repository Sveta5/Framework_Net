using System.Linq;
using Automation_Framework_Core.Elements;
using OpenQA.Selenium;
namespace Automation_Framework_Core.Tables
{
    public class RowBase
    {
        private readonly IWebElement _element;

        protected RowBase(IWebElement element)
        {
            _element = element;
        }

        protected IWebElement GetTdElement(int cellIndex)
        {
            var elements = _element.FindElements(By.XPath(".//td"));
            if (!elements.Any()) return null;
            var element = elements.ElementAt(cellIndex);

            return element;
        }

        protected string GetTdText(int cellIndex)
        {
            var elements = _element.FindElements(By.XPath(".//td"));
            if (!elements.Any()) return null;
            var element = elements.ElementAt(cellIndex);

            return element.Text;
        }
    }
}
