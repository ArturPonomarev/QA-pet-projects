using MyStoreTest.TestSolution.Pages;
using NUnit.Framework;
using static MyStoreTest.Framework.Utils.LoggerUtil;

namespace MyStoreTest.TestSolution.Test
{
    [TestFixture]
    internal class CheckBoxTest : BaseTest
    {
        private MainPage _mainPage;
        private CheckBoxPage _checkboxPage;
        
        [Test]
        public void TestMethod()
        {
            _mainPage = new MainPage();
            Assert.IsTrue(_mainPage.IsOpen(), "Main page is not open");

            LogInfo("Open checkbox page step");
            _mainPage.ClickCheckboxesLink();
            _checkboxPage = new CheckBoxPage();
            Assert.IsTrue(_checkboxPage.IsOpen(), "Checkbox page is not open");
            Assert.Multiple(() =>
            {
                Assert.IsFalse(_checkboxPage.IsFirstCheckboxChecked(),"First checkbox is checked but needs to be unchecked");
                Assert.IsTrue(_checkboxPage.IsSecondCheckboxChecked(),"Second checkbox is uncheked but need to be checked");
            });

            LogInfo("Change checkboxes state");
            _checkboxPage.ClickFirstCheckbox();
            _checkboxPage.ClickSecondCheckbox();
            Assert.Multiple(() =>
            {
                Assert.IsTrue(_checkboxPage.IsFirstCheckboxChecked(), "First checkbox is unchecked but needs to be checked");
                Assert.IsFalse(_checkboxPage.IsSecondCheckboxChecked(), "Second checkbox is cheked but need to be unchecked");
            });
        }
    }
}
