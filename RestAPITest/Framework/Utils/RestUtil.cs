using RestAPITest.Framework.Wrappers;
using RestSharp;
using static RestAPITest.Framework.Utils.LoggerUtils;

namespace RestAPITest.Framework.Utils
{
    public static class RestUtil
    {
        private const string JsonTitle = "application/json";

        public static RestResponse GetRequest(string requestParam)
        {
            LogInfo($"GET request:{RestClientAdvanced.GetApiUrl()}{requestParam}");
            RestRequest request = new RestRequest(requestParam,Method.Get);
            return RestClientAdvanced.Instance.Get(request);
        }

        public static RestResponse PostRequest(string requestParam, string jsonBody)
        {
            LogInfo($"POST request:{RestClientAdvanced.GetApiUrl()}{requestParam}");
            RestRequest request = new RestRequest(requestParam,Method.Post);
            request.AddJsonBody(jsonBody);
            return RestClientAdvanced.Instance.Post(request);
        }

        public static RestResponse PutRequest(string requestParam, string jsonBody)
        {
            LogInfo($"PUT request:{RestClientAdvanced.GetApiUrl()}{requestParam}");
            RestRequest request = new RestRequest(requestParam, Method.Put);
            request.AddJsonBody(jsonBody);
            return RestClientAdvanced.Instance.Put(request);
        }

        public static RestResponse DeleteRequest(string requestParam)
        {
            LogInfo($"DELETE request:{RestClientAdvanced.GetApiUrl()}{requestParam}");
            RestRequest request = new RestRequest(requestParam, Method.Delete);
            return RestClientAdvanced.Instance.Delete(request);
        }

        public static T ConverResponseTo<T>(RestResponse response)
        {
            return JSONUtil.DeserializeData<T>(response.Content);
        }

        public static bool IsResponseJson(RestResponse response)
        {
            return response.ContentType.Contains(JsonTitle);
        }
    }
}
