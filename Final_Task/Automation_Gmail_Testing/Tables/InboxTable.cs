using Automation_Framework_Core.Tables;

namespace Automation_Gmail_Testing.Tables
{
    public class InboxTable : TableBase<InboxRow>
    {
        protected override string Row => "//div[@role='main']//div[@class='Cp']//tr";
    }
}
