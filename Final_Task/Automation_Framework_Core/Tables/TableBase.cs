using System;
using System.Collections.Generic;
using System.Linq;
using Automation_Framework_Core.Core;
using OpenQA.Selenium;

namespace Automation_Framework_Core.Tables
{
    public abstract class TableBase<T> where T : RowBase
    {
        protected abstract string Row { get; }

        public IEnumerable<T> Rows => Driver.Current.FindElements(By.XPath(Row)).Select(CreateInstance<T>).ToList();

        private TRow CreateInstance<TRow>(IWebElement element) where TRow : RowBase
        {
            return Activator.CreateInstance(typeof(TRow), element) as TRow;
        }
    }
}
