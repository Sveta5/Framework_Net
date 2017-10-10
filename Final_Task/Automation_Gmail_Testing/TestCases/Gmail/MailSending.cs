using Automation_Gmail_Testing.Steps.GoogleAccount;
using Automation_Gmail_Testing.TestData;
using Automation_Framework_Core.Core;
using Automation_Framework_Core.Logger;
using Automation_Gmail_Testing.Models;
using NUnit.Framework;
using TestContext = NUnit.Framework.TestContext;
using Automation_Gmail_Testing.Helpers;
using Automation_Gmail_Testing.Steps.Gmail;
using System;

namespace Automation_Gmail_Testing.TestCases.Gmail
{
    [Category("Gmail")]
    [TestFixture]
    public class MailSending : BaseTest
    {
        private readonly LoginSteps _loginSteps = new LoginSteps();
        private readonly GmailSteps _gmailSteps = new GmailSteps();
        private readonly UserModel _user = DataSourceHelper.GetUser(UsersData.SvetaRiezvykhMail);

        [Test]
        public void SendEmailToItself()
        {
            LoggingHelper.LogInformation($"Test {TestContext.CurrentContext.Test.Name} is started.");
            var message = MessageTemplate.ValidMessageBody + DateTime.Now;

            _loginSteps.OpenGoogleAccountLoginPage();
            _loginSteps.LoginToAccount(_user.Email, _user.Password);

            _gmailSteps.OpenGmailMainPage();
            _gmailSteps.SendMessage(_user.Email, MessageTemplate.ValidMessageSubject, message);

            _gmailSteps.VerifyDoesMessagePresentInTable(MessageTemplate.ValidMessageSubject, message);

            _gmailSteps.DeleteMessage($"{MessageTemplate.ValidMessageSubject} { message}");
        }

        [Test]
        public void InvalidTest()
        {
            LoggingHelper.LogInformation($"Test {TestContext.CurrentContext.Test.Name} is started.");

            _loginSteps.OpenGoogleAccountLoginPage();
            _loginSteps.LoginToAccount(_user.Email, "");

            _gmailSteps.OpenGmailMainPage();
            _gmailSteps.SendMessage(_user.Email, MessageTemplate.ValidMessageSubject, MessageTemplate.ValidMessageBody);
        }
    }
}