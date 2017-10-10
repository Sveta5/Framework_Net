using System;
using System.Collections.Generic;
using HliAPtl.AutomationTests.UI.Core.Driver;
using OpenQA.Selenium;

namespace HliAPtl.AutomationTests.UI.Core.CustomElement
{
    public class CustomElement : ICustomElement
    {
        public readonly By Locator;

        public CustomElement(By locator)
        {
            Locator = locator;
        }

        public virtual string Text
        {
            get { return VisibleElement(Locator).Text; }
            set
            {
                var element = VisibleElement(Locator);
                element.Click();
                element.Clear();
                element.SendKeys(value);
            }
        }

        public bool IsElementEnabled()
        {
            return VisibleElement(Locator).Enabled;
        }

        public void Click()
        {
            VisibleElement(Locator).Click();
        }

        public void SendKeys(string text)
        {
            Text = text;
        }

        protected IWebElement FindElement(By selector, TimeSpan? timeout = null)
            => WebDriver.WaitForElementPresent(selector, timeout);

        protected IList<IWebElement> FindElements(By selector, TimeSpan? timeout = null)
            => WebDriver.DriverInstance.FindElements(selector);

        protected IWebElement VisibleElement(By selector, TimeSpan? timeout = null)
            => WebDriver.WaitFor(selector, timeout);

        public bool Displayed => GetCurrentElement.Displayed;

        public string GetAttribute(string attribute)
        {
            return FindElement(Locator).GetAttribute(attribute);
        }

        public IWebElement GetCurrentElement => VisibleElement(Locator);

        public void WaitUntilElemntIsVisible(TimeSpan? timeout = null)
        {
            VisibleElement(Locator, timeout);
        }

        public void Clear()
        {
            var element = VisibleElement(Locator);
            element.Click();
            element.SendKeys(string.Empty);
            element.Clear();
        }

        public void WaitUntilElemntIsInVisible(TimeSpan? timeout = null)
        {
            WebDriver.WaitForElementInvisible(Locator, timeout);
        }

        public void WaitUntilElemntToBeClickable(TimeSpan? timeout = null)
        {
            WebDriver.WaitForElementToBeClickable(Locator, timeout);
        }
    }
}