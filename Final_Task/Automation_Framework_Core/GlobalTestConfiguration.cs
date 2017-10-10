using System.Configuration;

namespace Automation_Framework_Core
{
    public static class GlobalTestConfiguration
    {
        public static string Gmail = ConfigurationManager.AppSettings["Gmail"];

        public static string GoogleAccount = ConfigurationManager.AppSettings["GoogleAccount"];

        public static string ClientDataPath = ConfigurationManager.AppSettings["DataSourcePath"];

        public static string ReportFolderName = ConfigurationManager.AppSettings["ReportFolderName"];

        public static string ReportFilePath = ReportFolderName + @"\" + ConfigurationManager.AppSettings["ReportFileName"];
    }
}
