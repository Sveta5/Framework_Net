
using Automation_Framework_Core.Logger;
using Automation_Gmail_Testing.Pages.Gmail;

namespace Automation_Gmail_Testing.Steps.GoogleAccount
{
    public class LoginSteps
    {
        private readonly LoginPage _loginPage = new LoginPage();

        public void OpenGoogleAccountLoginPage()
        {
            _loginPage.OpenLoginPage();
            LoggingHelper.LogInformation("Google account login page oppened");
        }

        public void LoginToAccount(string email, string password)
        {
            LoggingHelper.LogInformation("Try to login");
            _loginPage.LoginToAccount(email, password);
            LoggingHelper.LogInformation("User logged successfully");
        }
    }
}
