using Automation_Framework_Core.Logger;
using Automation_Gmail_Testing.Pages.Gmail;
using Automation_Gmail_Testing.Pages.Gmail.Layouts;
using NUnit.Framework;

namespace Automation_Gmail_Testing.Steps.Gmail
{
    public class GmailSteps
    {
        private readonly InboxPage _inboxPage = new InboxPage();
        private readonly MessageLayout _messageLayout = new MessageLayout();

        public void OpenGmailMainPage()
        {
            _inboxPage.OpenMainPage();
            LoggingHelper.LogInformation("Gmail main page oppened");
        }

        public void SendMessage(string recipientEmail, string subjectLine, string messageText)
        {
            LoggingHelper.LogInformation($"Try to send message to {recipientEmail}");
            _inboxPage.ClickCompose();

            LoggingHelper.LogInformation("Try to set message input");
            _messageLayout.SetResipient(recipientEmail);
            _messageLayout.SetSubjectLine(subjectLine);
            _messageLayout.SetMessage(messageText);
            LoggingHelper.LogInformation("Message content was filled");

            _messageLayout.ClickSendButton();
            LoggingHelper.LogInformation("Send button was cklicked");
        }

        public void SearchFor(string searchText)
        {
            LoggingHelper.LogInformation($"Search for{searchText}");
            _inboxPage.SearchFor(searchText);
        }

        public void VerifyDoesMessagePresentInTable(string subjectLine, string messageBody)
        {
            SearchFor($"{subjectLine} {messageBody}");

            var actualMessageContent = _inboxPage.GetMessageInTable();

            LoggingHelper.LogInformation($"Verify message content");
            StringAssert.Contains(subjectLine, actualMessageContent);
            StringAssert.Contains(messageBody, actualMessageContent);
        }

        public void DeleteMessage(string messegeInfo)
        {
            SearchFor(messegeInfo);

            _inboxPage.DeleteMessage();

            LoggingHelper.LogInformation($"Message was delleted {messegeInfo}");
        }
    }
}
