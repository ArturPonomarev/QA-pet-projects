namespace RestAPITest.TestSolution.Models
{
    public class Params
    {
        public string Users { set; get; }
        public string SingleUser { set; get; }
    }

    public class TestData
    {
        public string TestApiUrl { set; get; }

        public Params Params { set; get; }

        public string AuthorizationToken { set; get; }
    }
}
