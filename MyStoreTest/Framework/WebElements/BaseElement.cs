using MyStoreTest.Framework.Driver;
using MyStoreTest.Framework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace MyStoreTest.Framework.WebElements
{
    public abstract class BaseElement
    {
        protected IWebElement _element;
        protected string _elementName;
        public BaseElement(By locator, string elementName)
        {
            _element = new WebDriverWait(Browser.Instance.Driver, TimeSpan.FromSeconds(ConfigDataProvider.Config.timeouts.timeoutElement))
                .Until(d => d.FindElement(locator));        
            _elementName = elementName;
        }

        public BaseElement(IWebElement element, string elementName)
        {
            _element = element;
            _elementName = elementName;
        }

        public void ActionRightButtonClick()
        {
            new Actions(Browser.Instance.Driver)
                .ContextClick(_element)
                .Perform();
        }
    }
}
