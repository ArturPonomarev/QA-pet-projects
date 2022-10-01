using OpenQA.Selenium;
using static MyStoreTest.Framework.Utils.LoggerUtil;

namespace MyStoreTest.Framework.WebElements
{
    class Button : BaseElement
    {
        public Button(By locator, string elementName) : base(locator ,elementName)
        {
            LogInfo($"Create button with name:{elementName}");
        }

        public Button(IWebElement element, string elementName) : base(element, elementName)
        {
        }

        public void Click()
        {
            LogInfo($"Click button:{_elementName}");
            _element.Click();
        }
    }
}
