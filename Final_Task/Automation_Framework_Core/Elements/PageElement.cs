using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Automation_Framework_Core.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Automation_Framework_Core.Elements
{
    public class PageElement : IPageElement
    {
        public readonly By Locator;

        protected virtual TimeSpan DefaultWaitTimeout => Timeouts.Timeouts.Default;



        public PageElement(By locator)
        {
            Locator = locator;
        }

        public PageElement(string id)
            : this(By.Id(id))
        {
        }

        public virtual string Text
        {
            get
            {
                return VisibleWebElement.Text;
            }
            set
            {
                var element = VisibleWebElement;
                element.Click();
                element.Clear();
                element.SendKeys(value);
            }
        }

        public bool IsElementEnabled()
        {
            return VisibleWebElement.Enabled;
        }

        public void Clear()
        {
            VisibleWebElement.Click();
            VisibleWebElement.SendKeys(string.Empty);
            VisibleWebElement.Clear();
        }

        public void Click() => VisibleWebElement.Click();

        public void DoubleClick()
        {
            var action = new Actions(Driver.Current);
            action.MoveToElement(VisibleWebElement).DoubleClick();
            action.Perform();
        }

        public void SendKeys(string text) => VisibleWebElement.SendKeys(text);

        public void WaitForDisplayed() => Driver.WaitFor(Locator, DefaultWaitTimeout);

        public void WaitForDisplayed(TimeSpan ts) => Driver.WaitFor(Locator, ts);

        public bool IsElementExists()
        {
            IList<IWebElement> elements = Driver.Current.FindElements(Locator);

            return elements.Count > 0;
        }

        public bool IsElementDisplayed()
        {
            if (IsElementExists())
            {
                return GetWebElement().GetCssValue("display").ToLowerInvariant() != "none" && GetWebElement().Displayed;
            }

            return false;
        }

        public virtual IWebElement GetWebElement() => Driver.WaitForElementPresent(Locator);

        public virtual IList<IWebElement> GetWebElements() => Driver.Current.FindElements(Locator);

        protected virtual IWebElement VisibleWebElement => Driver.WaitFor(Locator);

        protected IList<T> GetListOfVisibleElements<T>(Func<By, T> createNew) where T : IPageElement
        {
            IList<IWebElement> elements = GetWebElements();
            return
                elements.Select(
                    (el, index) =>
                        createNew(By.XPath(
                            $"(//{el.TagName}[contains(@class,'{el.GetAttribute("class")}')])[{index + 1}]")))
                    .Where(el => el.IsElementDisplayed())
                    .ToList();
        }

        public IList<PageElement> GetAllVisibleElements() => GetListOfVisibleElements(l => new PageElement(l));

        public void WaitForElementIsDisappeared(TimeSpan? timeout = null) => Driver.WaitForElementIsHidden(Locator, timeout);
        public void WaitForElementIsNotEnabled(TimeSpan? timeout = null) => Driver.WaitForElementIsNotEnabled(Locator, timeout);

        public void MouseMove()
        {
            var action = new Actions(Driver.Current);
            action.MoveToElement(VisibleWebElement);
            action.Perform();
        }
    }
}
