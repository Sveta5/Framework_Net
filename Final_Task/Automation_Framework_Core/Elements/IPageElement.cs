using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Automation_Framework_Core.Elements
{
    public interface IPageElement
    {
        string Text { get; set; }
        bool IsElementEnabled();
        void Clear();
        void Click();
        void DoubleClick();
        void SendKeys(string text);
        void WaitForDisplayed();
        void WaitForDisplayed(TimeSpan ts);
        bool IsElementExists();
        bool IsElementDisplayed();
        IWebElement GetWebElement();
        IList<IWebElement> GetWebElements();
        IList<PageElement> GetAllVisibleElements();
        void WaitForElementIsDisappeared(TimeSpan? timeout = null);
        void WaitForElementIsNotEnabled(TimeSpan? timeout = null);
        void MouseMove();
    }
}
