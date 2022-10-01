using MyStoreTest.Framework.Driver;
using MyStoreTest.Framework.Forms;
using MyStoreTest.Framework.Utils;
using MyStoreTest.Framework.WebElements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MyStoreTest.TestSolution.Pages
{
    internal class FileUploadPage : BaseForm
    {
        private By _fileUploadBox = By.Id("file-upload");
        private By _uploadedFileLabel = By.Id("uploaded-files");
        private By _uploadButton = By.Id("file-submit");

        private const string UniqueElementId = "file-upload";
        private const string FormName = "File upload page";

        public FileUploadPage() : base(By.Id(UniqueElementId), FormName) { }

        public void UploadFile(string filePath)
        {
            new TextBox(_fileUploadBox, "File upload box").SendKeys(filePath);
        }

        public void ClickSumbitUploadingButton()
        {
            new Button(_uploadButton,"Sumbit uploading button").Click();
        }

        public bool IsFileUploaded()
        {
            return new WebDriverWait(Browser.Instance.Driver, TimeSpan.FromSeconds(ConfigDataProvider.Config.timeouts.timeoutElement))
                .Until(dr => dr.FindElements(_uploadedFileLabel).Count > 0);
        }

        public string GetUploadedFileName()
        {
            return new Label(_uploadedFileLabel, "Uploaded file text").GetText();
        }
    }
}
