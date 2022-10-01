using OpenQA.Selenium;
using static MyStoreTest.Framework.Utils.LoggerUtil;

namespace MyStoreTest.Framework.WebElements
{
    class Label : BaseElement
    {
        public Label(By locator, string elementName) : base(locator, elementName)
        {
            LogInfo($"Create label with name:{elementName}");
        }

        public Label(IWebElement element, string elementName) : base(element, elementName)
        {
        }

        public string GetText()
        {
            LogInfo($"Receiving text from label:{_elementName}");
            return _element.Text;
        }
    }
}
