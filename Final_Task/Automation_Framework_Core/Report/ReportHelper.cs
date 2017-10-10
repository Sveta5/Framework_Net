
using System.IO;

namespace Automation_Framework_Core.Report
{
    public static class ReportHelper
    {

        static ReportHelper()
        {
            Directory.CreateDirectory(GlobalTestConfiguration.ReportFolderName);
        }
        public static void LogHeader(string message)
        {
            WriteLog(string.Format(ReporterStyles.Header, message.Replace("\n", "<br />")));
        }

        public static void LogPositive(string message)
        {
            WriteLog(string.Format(ReporterStyles.Positive, message.Replace("\n", "<br />")));
        }

        public static void LogNegative(string message)
        {
            WriteLog(string.Format(ReporterStyles.Negative, message.Replace("\n", "<br />")));
        }

        public static void LogElements(string message)
        {
            WriteLog(string.Format(ReporterStyles.Element, message.Replace("\n", "<br />")));
        }

        public static void LogScreenshot(string path)
        {
            WriteLog(string.Format(ReporterStyles.Image, path));
        }

        public static void SetSeparateElement()
        {
            WriteLog("<br/><hr>");
        }

        private static void WriteLog(string logInput)
        {
            File.AppendAllText(GlobalTestConfiguration.ReportFilePath, logInput);
        }
    }
}
