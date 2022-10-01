using MyStoreTest.Framework.Forms;
using MyStoreTest.Framework.WebElements;
using OpenQA.Selenium;

namespace MyStoreTest.TestSolution.Pages
{
    internal class MainPage : BaseForm
    {
        private By _addRemoveElementsLink = By.XPath("//*[contains(text(),'Add/Remove Elements')]");
        private By _checkboxesLink = By.XPath("//*[contains(text(),'Checkboxes')]");
        private By _contextMenuLink = By.XPath("//*[contains(text(),'Context Menu')]");
        private By _fileUploadLink = By.XPath("//*[contains(text(),'File Upload')]");

        private const string UniqueElementPath = "//*[contains(text(),'the-internet')]";
        private const string FormName = "Main page";

        public MainPage() : base(By.XPath(UniqueElementPath),FormName) { }

        public void ClickAddRemoveElementsLink()
        {
            new Link(_addRemoveElementsLink, "Add/Remove elements link").Click();
        }

        public void ClickCheckboxesLink()
        {
            new Link(_checkboxesLink, "Checkboxes link").Click();
        }

        public void ClickContextMenuLink()
        {
            new Link(_contextMenuLink, "Context Menu link").Click();
        }

        public void ClickFileUploadLink()
        {
            new Link(_fileUploadLink, "File upload Link").Click();
        }
    }
}
