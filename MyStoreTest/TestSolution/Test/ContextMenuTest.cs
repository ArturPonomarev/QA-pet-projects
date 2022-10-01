using MyStoreTest.TestSolution.Pages;
using NUnit.Framework;
using static MyStoreTest.Framework.Utils.LoggerUtil;

namespace MyStoreTest.TestSolution.Test
{
    [TestFixture]
    internal class ContextMenuTest : BaseTest
    {
        const string ExpectedAlertText = "You selected a context menu";

        private MainPage _mainPage;
        private ContextMenuPage _contextMenuPage;

        [Test]
        public void TestMethod()
        {
            _mainPage = new MainPage();
            Assert.IsTrue(_mainPage.IsOpen(), "Main page is not open");

            LogInfo("Open Context Menu page step");
            _mainPage.ClickContextMenuLink();
            _contextMenuPage = new ContextMenuPage();
            Assert.IsTrue(_contextMenuPage.IsOpen(), "Context menu page is not open");

            LogInfo("Right click to context zone step");
            _contextMenuPage.RightClickContextZone();
            Assert.IsTrue(_browser.IsAlertActive(), "Alert did not appear");
            Assert.AreEqual(_browser.GetAlertText(), ExpectedAlertText, $"Alert text is not {ExpectedAlertText}");

            LogInfo("Close alert step");
            _browser.AcceptActiveAlert();
            Assert.IsFalse(_browser.IsAlertActive(), "Alert is not accepted");
        }
    }
}
