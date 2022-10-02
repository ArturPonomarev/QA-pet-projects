using RestSharp;
using RestSharp.Authenticators.OAuth2;
using System;
using static RestAPITest.Framework.Utils.LoggerUtils;

namespace RestAPITest.Framework.Wrappers
{
    class RestClientAdvanced
    {
        private static RestClient _instance;

        private RestClientAdvanced() { }

        public static RestClient Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RestClient();
                return _instance;
            }
        }

        public static void SetApiUrl(string url)
        {
            LogInfo($"Rest client - set url: {url}");
            Instance.Options.BaseUrl = new Uri(url);
        }

        public static void SetBearerAuthorizationToken(string token)
        {
            Instance.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(token, "Bearer");
        }

        public static string GetApiUrl()
        {
            return Instance.Options.BaseUrl.ToString();
        }
    }
}
