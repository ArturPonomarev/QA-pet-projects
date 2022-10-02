using NUnit.Framework;

namespace RestAPITest.TestSolution.Tests
{
    [TestFixture]
    public abstract class BaseTest
    {
        [SetUp]
        public virtual void SetUp()
        {
        }

        [TearDown]
        public virtual void TearDown()
        {
        }
    }
}
