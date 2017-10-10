using Automation_Framework_Core.Core;
using Automation_Framework_Core.Elements;

namespace Automation_Framework_Core.PageObjects
{
    public abstract class BasePage
    {
        public void CloseDriver() => Driver.Close();

        protected void NavigateToUrl(string url) => Driver.Current.Navigate().GoToUrl(url);

        protected void CleanCookies() => Driver.CleanCookies();

        protected virtual PageElement GetPageRootElement() => null;

        public virtual bool IsDisplayed()
        {
            var root = GetPageRootElement();
            return root != null && root.IsElementDisplayed();
        }

        protected string GetUrl => Driver.Current.Url;

        public void RefreshPage() => Driver.Current.Navigate().Refresh();
    }
}
