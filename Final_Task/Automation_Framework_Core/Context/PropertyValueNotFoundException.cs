using System;

namespace Automation_Framework_Core.Context
{
    public class PropertyValueNotFoundException : Exception
    {
        public string PropertyName { get; set; }

        public PropertyValueNotFoundException(string propertyName)
        {
            PropertyName = propertyName;
        }

        public override string Message => $"There is no value for property '{PropertyName}' in test context.";
    }
}
