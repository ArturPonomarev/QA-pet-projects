using NUnit.Framework;
using RestAPITest.Framework.Utils;
using RestAPITest.Framework.Wrappers;
using RestAPITest.TestSolution.Models;
using RestAPITest.TestSolution.Utils;
using RestSharp;
using System.Net;
using static RestAPITest.Framework.Utils.LoggerUtils;

namespace RestAPITest.TestSolution.Tests
{
    [TestFixture]
    internal class RestAPITest : BaseTest
    {
        private const int CorrectUserId = 2462;
        private const int InCorrectUserId = 999999;
        private const int PostUserId = 0;
        private const int PostUserNameLength = 10;
        private const int PostNewUserNameLength = 11;
        private const int PostUserEmailLength = 15;
        private const string PostUserGender = "male";
        private const string PostUserStatus = "active";
        private const string UserEmailDomain = "@gmail.com";
        private const string NotFountResponceContent = "{\"message\":\"Resource not found\"}";

        private RestResponse _restResponce;

        [Test]
        public void TestMethod()
        {
            RestClientAdvanced.SetApiUrl(DataProvider.TestData.TestApiUrl);
            RestClientAdvanced.SetBearerAuthorizationToken(DataProvider.TestData.AuthorizationToken);

            LogInfo("Get all users step");
            _restResponce = RestUtil.GetRequest(DataProvider.TestData.Params.Users);
            Assert.IsTrue(_restResponce.StatusCode == HttpStatusCode.OK,"Responce status code is not 200");
            Assert.IsTrue(RestUtil.IsResponseJson(_restResponce),"Responce body is not JSON");

            LogInfo("Get correct single user step");
            _restResponce = RestUtil.GetRequest(string.Format(DataProvider.TestData.Params.SingleUser, CorrectUserId));
            Assert.IsTrue(_restResponce.StatusCode == HttpStatusCode.OK, "Responce status code is not 200");
            Assert.IsFalse(_restResponce.Content.Equals(NotFountResponceContent),"Responce body contains not found message");

            LogInfo("Get incorrect single user step");
            _restResponce = RestUtil.GetRequest(string.Format(DataProvider.TestData.Params.SingleUser, InCorrectUserId));
            Assert.IsTrue(_restResponce.StatusCode == HttpStatusCode.NotFound, "Responce status code is not 404");
            LogInfo("CONTENT" + _restResponce.Content);
            Assert.IsTrue(_restResponce.Content.Equals(NotFountResponceContent),"Responce body not contains not found message");

            LogInfo("Post user step");
            ResponceUser userData = new ResponceUser(
                PostUserId,
                StringUtil.GetRandomString(PostUserNameLength),
                StringUtil.GetRandomString(PostUserEmailLength) + UserEmailDomain,
                PostUserGender,
                PostUserStatus);
            LogInfo($"Post user name:{userData.Name}, email:{userData.Email}");
            _restResponce = RestUtil.PostRequest(DataProvider.TestData.Params.Users, JSONUtil.Serialize(userData));
            Assert.IsTrue(_restResponce.StatusCode == HttpStatusCode.Created, "Responce status code is not 201");
            Assert.Multiple(() =>
            {
                Assert.AreEqual(JSONUtil.DeserializeData<ResponceUser>(_restResponce.Content).Name, userData.Name,
                    "responce user name is not equal request username");
                Assert.AreEqual(JSONUtil.DeserializeData<ResponceUser>(_restResponce.Content).Email, userData.Email,
                    "responce user email is not equal request email");
            });

            LogInfo("Edit user step");
            int userId = JSONUtil.DeserializeData<ResponceUser>(_restResponce.Content).Id;
            ResponceUser newUserData = new ResponceUser(
                default,
                StringUtil.GetRandomString(PostNewUserNameLength),
                userData.Email,
                userData.Gender,
                userData.Status
                );
            LogInfo($"New user name:{newUserData.Name}");
            _restResponce = RestUtil.PutRequest(string.Format(DataProvider.TestData.Params.SingleUser, userId),
                                                JSONUtil.Serialize(newUserData));
            Assert.IsTrue(_restResponce.StatusCode == HttpStatusCode.OK, "Responce status code is not 200");
            Assert.AreEqual(JSONUtil.DeserializeData<ResponceUser>(_restResponce.Content).Name, newUserData.Name,
                "responce user name is not equal new user name");

            LogInfo("Delete user step");
            _restResponce = RestUtil.DeleteRequest(string.Format(DataProvider.TestData.Params.SingleUser, userId));
            Assert.IsTrue(_restResponce.StatusCode == HttpStatusCode.NoContent, "Responce status code is not 204");
        }
    }
}
