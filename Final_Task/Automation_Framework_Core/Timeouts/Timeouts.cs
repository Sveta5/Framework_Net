using System;

namespace Automation_Framework_Core.Timeouts
{
    public static class Timeouts
    {
        public static readonly TimeSpan Default = TimeSpan.FromSeconds(30);
        public static readonly TimeSpan JsTimeout = TimeSpan.FromSeconds(10);
        public static readonly TimeSpan SmallTimeout = TimeSpan.FromSeconds(5);
        public static readonly TimeSpan TinyTimeout = TimeSpan.FromSeconds(2);
        public static readonly TimeSpan OneSecondTimeout = TimeSpan.FromSeconds(1);
    }
}
