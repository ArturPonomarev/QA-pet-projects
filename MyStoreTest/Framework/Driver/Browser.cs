using MyStoreTest.Framework.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static MyStoreTest.Framework.Utils.LoggerUtil;

namespace MyStoreTest.Framework.Driver
{ 
    class Browser
    {
        private static IWebDriver _driver;
        private static Browser _instance;
        private Browser()
        {}

        public static Browser Instance
        {
            get
            {
                if (_instance == null)
                {
                    LogInfo("Open browser");
                    _driver = BrowserFactory.GetDriver();
                    _instance = new Browser();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
                return _instance;
            }      
        }

        public void Quit()
        {
            if (_instance != null)
            {
                LogInfo("Close browser");
                _driver.Quit();
                _driver = null;
                _instance = null;
            }           
        }

        public IWebDriver Driver 
        {   
            get
            {
                return _driver;
            }
        }

        public void Navigate(string url)
        {
            LogInfo($"Navigate to URL:{url}");
            _driver.Navigate().GoToUrl(url);
        }

        public void Refresh()
        {
            LogInfo("Refreshing page");
            _driver.Navigate().Refresh();
        }

        public void AcceptActiveAlert()
        {
            GetActiveAlert().Accept();
        }

        public bool IsAlertActive()
        {
            try
            {
                GetActiveAlert();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetAlertText()
        {
            return GetActiveAlert().Text;
        }

        private IAlert GetActiveAlert()
        {
            LogDebug("Receiving active alert");
            return new WebDriverWait(Driver,TimeSpan.FromSeconds(ConfigDataProvider.Config.timeouts.timeoutElement))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }
    }
}
