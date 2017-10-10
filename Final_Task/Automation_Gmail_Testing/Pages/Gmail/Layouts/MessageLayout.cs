using Automation_Framework_Core.Elements;
using Automation_Framework_Core.PageObjects;
using OpenQA.Selenium;

namespace Automation_Gmail_Testing.Pages.Gmail.Layouts
{
    public class MessageLayout : BasePage
    {
        private readonly IPageElement _toArea = new PageElement(By.XPath("//textarea[@name='to']"));

        private readonly IPageElement _subjectLine = new PageElement(By.XPath("//input[@name='subjectbox']"));
        private readonly IPageElement _messageBody = new PageElement(By.CssSelector("div.Am.Al.editable.LW-avf"));

        private readonly IPageElement _sendButton = new PageElement(By.XPath("//div[contains(@class, 'aoO T-I-atl L3')]"));

        public void SetResipient(string email)
        {
            _toArea.Text = email;
            _toArea.SendKeys(Keys.Enter);
        }

        public void SetSubjectLine(string subject)
        {
            _subjectLine.Text = subject;
        }

        public void SetMessage(string text)
        {
            _messageBody.Text = text;
        }

        public void ClickSendButton()
        {
            _sendButton.Click();
            _sendButton.WaitForElementIsDisappeared();
        }
    }
}
