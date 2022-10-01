using OpenQA.Selenium;
using MyStoreTest.Framework.Utils;
using static MyStoreTest.Framework.Utils.LoggerUtil;
using MyStoreTest.Framework.Driver;
using OpenQA.Selenium.Support.UI;
using System;

namespace MyStoreTest.Framework.Forms
{
    abstract class BaseForm
    {
        private IWebElement _uniqueElement;
        private string _formName;

        public BaseForm(By uniqueElementLocator, string formName)
        {
            LogInfo($"Create form:{formName}");
            _uniqueElement = new WebDriverWait(Browser.Instance.Driver, TimeSpan.FromSeconds(ConfigDataProvider.Config.timeouts.timeoutPageLoad))
                .Until(d => d.FindElement(uniqueElementLocator));
            _formName = formName;
        }

        public virtual bool IsOpen()
        {
            return _uniqueElement != null;
        }
    }
}
