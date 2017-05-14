using DAO.Entities;
using NUnit.Framework;
using ServiceTest.Helpers;
using ServiceTest.Tests.BaseSteps;
using System;
using TechTalk.SpecFlow;

namespace ServiceTest.Tests
{
    [Binding]
    public class DeleteUserTestSteps : TestSetup
    {
        [Given(@"""(.*)"" by ""(.*)""{NickName} request")]
        public void GivenRequest(string method, string request)
        {
            var user = (User)ScenarioContext.Current[_userKey];
            var endpoint = String.Concat(request, user.NickName);

            HttpClientHelper httpClientHelper = new HttpClientHelper(method: method, endpoint: endpoint);
            ScenarioContext.Current.Add(_httpClientKey, httpClientHelper);
        }

        [Given(@"""(.*)"" by ""(.*)""{NickName} request for non exsiting user")]
        public void GivenRequestForNonExistingUser(string method, string request)
        {
            var endpoint = String.Concat(request, _testString);

            HttpClientHelper httpClientHelper = new HttpClientHelper(method: method, endpoint: endpoint);
            ScenarioContext.Current.Add(_httpClientWrongKey, httpClientHelper);
        }

        [Then(@"Check response message when user deleted")]
        public void ThenCheckResponseMessageWhenUserDeleted()
        {
            var user = (User)ScenarioContext.Current[_userKey];
            var response = (string)ScenarioContext.Current[_response];
            
            Assert.IsTrue(response.Contains(String.Format("User {0} was deleted.", user.NickName)));
        }

        [Then(@"Check response message when non existing user deleted")]
        public void ThenCheckResponseMessageWhenNonExistingUserDeleted()
        {
            Assert.IsTrue(string.IsNullOrWhiteSpace((string)ScenarioContext.Current[_response]));
        }
    }
}
