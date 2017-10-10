using NUnit.Framework;

namespace Automation_Gmail_Testing.Helpers
{
    public class FileSystemHelper
    {
        public static string GetPathToResourceFile(string path)
        {
            return TestContext.CurrentContext.TestDirectory + "\\" + path;
        }
    }
}
