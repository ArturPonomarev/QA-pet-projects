using MyStoreTest.Framework.Driver;
using MyStoreTest.Framework.Forms;
using MyStoreTest.Framework.WebElements;
using OpenQA.Selenium;

namespace MyStoreTest.TestSolution.Pages
{
    internal class AddRemoveElementsPage : BaseForm
    {
        private By _addButton = By.XPath("//*[@onclick='addElement()']");
        private By _deleteButton = By.ClassName("added-manually");

        private const string UniqueElementPath = "//*[contains(text(),'Add/Remove Elements')]";
        private const string FormName = "Add/Remove elements page";

        public AddRemoveElementsPage() : base(By.XPath(UniqueElementPath),FormName) { }

        public void ClickAddButton()
        {
            new Button(_addButton, "Add element button").Click();
        }

        public void ClickDeleteButton()
        {
            new Button(_deleteButton, "Delete button").Click();
        }

        public int DeleteButtonsCount()
        {
            return Browser.Instance.Driver.FindElements(_deleteButton).Count;
        }
    }
}
