using MyStoreTest.Framework.Driver;
using NUnit.Framework;
using static MyStoreTest.Framework.Utils.LoggerUtil;

namespace MyStoreTest.TestSolution.Test
{
    [TestFixture]
    abstract class BaseTest
    {
        protected Browser _browser = Browser.Instance;

        [SetUp]
        public virtual void SetUp()
        {
            LogInfo("Open main page");
            _browser.Navigate("http://the-internet.herokuapp.com/");
        }

        [TearDown]
        public virtual void TearDown()
        {
            Browser.Instance.Quit();
        }
    }
}
