using RestAPITest.Framework.Utils;
using RestAPITest.TestSolution.Models;

namespace RestAPITest.TestSolution.Utils
{
    public static class DataProvider
    {
        private const string TestDataPath = "Resources/testData.json";

        public static TestData TestData = JSONUtil.DeserializeFile<TestData>(TestDataPath);
    }
}
