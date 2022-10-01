using MyStoreTest.Framework.Driver;
using MyStoreTest.Framework.Forms;
using MyStoreTest.Framework.Utils;
using MyStoreTest.Framework.WebElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

namespace MyStoreTest.TestSolution.Pages
{
    internal class CheckBoxPage : BaseForm
    {
        private By _checkboxes = By.XPath("//*[@type = 'checkbox']");

        private const string CheckedAttributeName = "Checked";

        private const string UniqueElementPath = "//*[contains(text(),'Checkboxes')]";
        private const string FormName = "Checkbox page";

        public CheckBoxPage() : base(By.XPath(UniqueElementPath),FormName) {}

        public void ClickFirstCheckbox()
        {
            new Button(GetCheckboxes()[0], "Checkbox 1").Click();
        }

        public bool IsFirstCheckboxChecked()
        {
            return GetCheckboxes()[0].GetAttribute(CheckedAttributeName) != null;
        }

        public void ClickSecondCheckbox()
        {
            new Button(GetCheckboxes()[1], "Checkbox 2").Click();
        }

        public bool IsSecondCheckboxChecked()
        {
            return GetCheckboxes()[1].GetAttribute(CheckedAttributeName) != null;
        }

        private IWebElement[] GetCheckboxes()
        {
            new WebDriverWait(Browser.Instance.Driver, TimeSpan.FromSeconds(ConfigDataProvider.Config.timeouts.timeoutElement))
                .Until(dr=>dr.FindElements(_checkboxes).Count>0);

            return Browser.Instance.Driver.FindElements(_checkboxes).ToArray();
        }
    }
}
