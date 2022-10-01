using OpenQA.Selenium;
using static MyStoreTest.Framework.Utils.LoggerUtil;

namespace MyStoreTest.Framework.WebElements
{
    class TextBox : BaseElement
    {
        public TextBox(By locator, string elementName) : base(locator, elementName)
        {
            LogInfo($"Create textbox with name:{elementName}");
        }

        public TextBox(IWebElement element, string elementName) : base(element, elementName)
        {
        }

        public void SendKeys(string keys, bool pressEnter = false)
        {
            LogInfo($"Enter text \"{keys}\" to textbox:{_elementName}");
            _element.SendKeys(keys);
            if (pressEnter)
            {
                LogInfo($"Press \"Enter\" in textbox:{_elementName}");
                _element.SendKeys(Keys.Enter);
            }  
        }
    }
}
