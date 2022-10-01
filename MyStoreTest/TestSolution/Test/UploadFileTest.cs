using MyStoreTest.TestSolution.Pages;
using NUnit.Framework;
using System;
using System.IO;
using static MyStoreTest.Framework.Utils.LoggerUtil;

namespace MyStoreTest.TestSolution.Test
{
    [TestFixture]
    internal class UploadFileTest : BaseTest
    {
        private readonly string FilePath = Path.Combine(Environment.CurrentDirectory,"Resources/testUploadFile.txt");
        private const string FileName = "testUploadFile.txt";

        private MainPage _mainPage;
        private FileUploadPage _fileUploadPage;

        [Test]
        public void TestMethod()
        {
            _mainPage = new MainPage();
            Assert.IsTrue(_mainPage.IsOpen(), "Main page is not open");

            LogInfo("Open file upload page step");
            _mainPage.ClickFileUploadLink();
            _fileUploadPage = new FileUploadPage();
            Assert.IsTrue(_fileUploadPage.IsOpen(), "File Upload page is not open");

            LogInfo("Upload file step");
            _fileUploadPage.UploadFile(FilePath);
            _fileUploadPage.ClickSumbitUploadingButton();
            Assert.IsTrue(_fileUploadPage.IsFileUploaded(), "File is not uploaded");
            Assert.AreEqual(_fileUploadPage.GetUploadedFileName(), FileName, "Uploaded file name is not equal test file name");
        }
    }
}
