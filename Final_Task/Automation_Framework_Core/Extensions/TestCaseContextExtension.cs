using System;
using Automation_Framework_Core.Context;
using NUnit.Framework;

namespace Automation_Framework_Core.Extensions
{
    public static class TestCaseContextExtension
    {
        public static void SaveProperty(this TestContext testContext, string propertyName, object value)
        {
            TestContext.CurrentContext.Test.Properties[propertyName].Add(value);
        }

        public static bool TryGetObjectProperty<T>(this TestContext testContext, string propertyName, out T value)
        {
            value = default(T);

            var properties = TestContext.CurrentContext.Test.Properties;

            if (!properties.Keys.Contains(propertyName)) return false;
            value = (T)(properties[propertyName][0]);

            return true;
        }

        public static string GetTestName(this TestContext testContext)
        {
            var testName = testContext.Test != null ? testContext.Test.Name : string.Empty;

            int bracketStartPosition;
            if ((bracketStartPosition = testName.IndexOf("(", StringComparison.Ordinal)) > 0)
            {
                testName = testName.Substring(0, bracketStartPosition);
            }

            return testName;
        }
    }
}
