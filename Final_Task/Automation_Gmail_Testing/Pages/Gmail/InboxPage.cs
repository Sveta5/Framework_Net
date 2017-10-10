using Automation_Framework_Core;
using Automation_Framework_Core.Elements;
using Automation_Framework_Core.PageObjects;
using Automation_Framework_Core.Timeouts;
using OpenQA.Selenium;
using Automation_Gmail_Testing.Tables;
using System.Linq;

namespace Automation_Gmail_Testing.Pages.Gmail
{
    public class InboxPage : BasePage
    {
        private readonly IPageElement _composeButton = new PageElement(By.CssSelector("div.T-I.J-J5-Ji.T-I-KE.L3"));
        private readonly IPageElement _searchArea = new PageElement(By.XPath("//*[@class ='gbqfif']"));
        private readonly IPageElement _tableHeader = new PageElement(By.XPath("//tr[@role='tablist']"));

        private readonly IPageElement _deleteButton = new PageElement(By.XPath("(//div[contains(@class, 'T-I J-J5-Ji nX T-I-ax7 T-I-Js-Gs')])[2]"));
        private readonly IPageElement _undoLink = new PageElement(By.XPath("//*[@class='ag a8k']"));

        public void OpenMainPage()
        {
            NavigateToUrl(GlobalTestConfiguration.Gmail);
        }

        public void ClickCompose()
        {
            _composeButton.Click();
        }

        public void SearchFor(string searchText)
        {
            _searchArea.Text = searchText;
            _searchArea.SendKeys(Keys.Enter);

            _tableHeader.WaitForElementIsDisappeared();
        }

        public string GetMessageInTable()
        {
            var firstRow = (new InboxTable()).Rows.FirstOrDefault();

            return firstRow.Message;
        }

        public void DeleteMessage()
        {
            var firstRow = (new InboxTable()).Rows.FirstOrDefault();
            var checkBox = firstRow.Checkbox;

            checkBox.Click();

            _deleteButton.WaitForDisplayed();
            _deleteButton.MouseMove();
            _deleteButton.Click();

            _undoLink.WaitForDisplayed();
        }
    }
}
