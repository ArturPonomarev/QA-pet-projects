using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using MyStoreTest.Framework.Utils;
using static MyStoreTest.Framework.Utils.LoggerUtil;

namespace MyStoreTest.Framework.Driver
{
    class BrowserFactory
    {
        public static IWebDriver GetDriver()
        {
            IWebDriver driver;

            switch (ConfigDataProvider.Config.activeBrowser.ToUpper())
            {
                case "CHROME":
                    LogDebug("Active browser is chrome");
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    ChromeOptions chOptions = new ChromeOptions();
                    chOptions.AddArguments(ConfigDataProvider.Config.browserSettings.chrome.startArguments);
                    driver = new ChromeDriver(chOptions);
                    break;

                default:
                    throw new Exception("Browser name is not correct");                 
            }

            return driver;
        }
    }
}
