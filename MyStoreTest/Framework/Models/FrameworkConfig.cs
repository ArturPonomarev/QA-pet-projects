using System.Collections.Generic;

namespace MyStoreTest.Framework.Models
{
    public class BrowserSettings
    {
        public Chrome chrome { get; set; }
    }

    public class Chrome
    {
        public List<string> startArguments { get; set; }
    }

    public class FrameworkConfig
    {
        public string activeBrowser { get; set; }
        public BrowserSettings browserSettings { get; set; }
        public Timeouts timeouts { get; set; }
    }

    public class Timeouts
    {
        public int timeoutImplicit { get; set; }
        public int timeoutElement { get; set; }
        public int timeoutPageLoad { get; set; }
        public int timeoutPollingInterval { get; set; }
    }

}
