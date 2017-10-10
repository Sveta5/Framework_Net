using Automation_Framework_Core;
using Automation_Framework_Core.Elements;
using Automation_Framework_Core.PageObjects;
using Automation_Framework_Core.Timeouts;
using OpenQA.Selenium;

namespace Automation_Gmail_Testing.Pages.Gmail
{
    public class LoginPage : BasePage
    {
        private readonly IPageElement _loginField = new PageElement("Email");
        private readonly IPageElement _nextButton = new PageElement("next");

        private readonly IPageElement _passwordField = new PageElement(By.XPath("//*[@id='Passwd']"));
        private readonly IPageElement _signInButton = new PageElement(By.XPath("//*[@id='signIn']"));

        public void OpenLoginPage()
        {
            NavigateToUrl(GlobalTestConfiguration.GoogleAccount);
        }

        public void LoginToAccount(string login, string password)
        {
            _loginField.Text = login;
            _nextButton.Click();

            _passwordField.Text = password;
            _signInButton.Click();
        }
    }
}
