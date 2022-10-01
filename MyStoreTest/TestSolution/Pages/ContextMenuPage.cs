using MyStoreTest.Framework.Forms;
using MyStoreTest.Framework.WebElements;
using OpenQA.Selenium;


namespace MyStoreTest.TestSolution.Pages
{
    internal class ContextMenuPage : BaseForm
    {
        private By _contextZoneElement = By.Id("hot-spot"); 

        private const string UniqueElementId = "hot-spot";
        private const string FormName = "Context Menu Page";

        public ContextMenuPage() : base(By.Id(UniqueElementId), FormName) { }

        public void RightClickContextZone()
        {
            new Button(_contextZoneElement, "Context zone").ActionRightButtonClick();
        }
    }
}
