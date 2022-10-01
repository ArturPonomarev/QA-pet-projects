using NUnit.Framework;
using MyStoreTest.TestSolution.Pages;
using static MyStoreTest.Framework.Utils.LoggerUtil;
using MyStoreTest.TestSolution.Utils;

namespace MyStoreTest.TestSolution.Test
{
    [TestFixture]
    internal class AddRemoveTest : BaseTest
    {
        const int MinAddElements = 2;
        const int MaxAddElements = 7;

        private MainPage _mainPage;
        private AddRemoveElementsPage _addRemoveElementsPage;

        [Test]
        public void TestMethod()
        {
            _mainPage = new MainPage();
            Assert.IsTrue(_mainPage.IsOpen(), "Main page is not open");

            LogInfo("Open Add/Remove elements page step");
            _mainPage.ClickAddRemoveElementsLink();
            _addRemoveElementsPage = new AddRemoveElementsPage();
            Assert.IsTrue(_addRemoveElementsPage.IsOpen(), "Add/Remove elements page is not open");

            LogInfo("Add elements step");
            int addElementsCount = NumberUtils.CreateRandomNumber(MinAddElements, MaxAddElements);
            for (int i = 0; i < addElementsCount; ++i)
                _addRemoveElementsPage.ClickAddButton();
            Assert.AreEqual(_addRemoveElementsPage.DeleteButtonsCount(), addElementsCount,"Elements count are not equal expected elements count");

            LogInfo("Delete elements step");
            for (int i = 0; i < addElementsCount; ++i)
                _addRemoveElementsPage.ClickDeleteButton();
            Assert.IsTrue(_addRemoveElementsPage.DeleteButtonsCount() == 0, "not all elements have been deleted");
        }
    }
}
