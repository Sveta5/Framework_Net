using System.Collections.Generic;
using OpenQA.Selenium;

namespace Automation_Framework_Core.Elements
{
    public class TableGridElement : PageElement
    {
        public TableGridElement(By locator) : base(locator) { }

        public TableGridElement(string id) : base(id) { }

        public PageElement GetRow(int rowNumber) => new PageElement(By.XPath($".//tr[{rowNumber}]"));

        public IList<PageElement> GetColumn(int columnNumber)
        {
            IList<PageElement> columnElements = new PageElement(By.XPath($".//td[{columnNumber}]")).GetAllVisibleElements();
            return columnElements;
        }

        public IList<PageElement> GetRowsFrom(int row) => new PageElement(By.XPath($".//tr[position()>{row}]")).GetAllVisibleElements();
    }
}
