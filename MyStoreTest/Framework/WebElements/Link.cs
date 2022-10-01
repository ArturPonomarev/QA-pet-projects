using OpenQA.Selenium;
using static MyStoreTest.Framework.Utils.LoggerUtil;

namespace MyStoreTest.Framework.WebElements
{
    class Link : BaseElement
    {
        public Link(By locator, string elementName) : base(locator, elementName)
        {
            LogInfo($"Create link with name:{elementName}");
        }

        public Link(IWebElement element, string elementName) : base(element, elementName)
        {
        }

        public void Click()
        {
            LogInfo($"Click link:{_elementName}");
            _element.Click();
        }
        public string GetLink()
        {
            LogInfo($"Receiving link text:{_elementName}");
            return _element.GetAttribute("href");
        }
    }
}
