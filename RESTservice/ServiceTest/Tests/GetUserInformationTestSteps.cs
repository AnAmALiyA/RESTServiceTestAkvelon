using System;
using DAO.Entities;
using ServiceTest.Helpers;
using TechTalk.SpecFlow;
using NUnit.Framework;
using ServiceTest.Tests.BaseSteps;

namespace ServiceTest.Tests
{
    [Binding]
    public class GetUserInformationTestSteps : TestSetup
    {
        [Given(@"""(.*)"" by ""(.*)""{NickName} request for user info endpoint")]
        public void GivenRequest(string method, string request)
        {
            var user = (User)ScenarioContext.Current[_userKey];
            var endpoint = String.Concat(request, user.NickName);

            HttpClientHelper httpClientHelper = new HttpClientHelper(method: method, endpoint: endpoint);
            ScenarioContext.Current.Add(_httpClientKey, httpClientHelper);
        }

        [Given(@"""(.*)"" by ""(.*)""{NickName} request for non exist user info endpoint")]
        public void GivenRequestForNonExistUserInfoEndpoint(string method, string request)
        {
            var endpoint = String.Concat(request, _testString);

            HttpClientHelper httpClientHelper = new HttpClientHelper(method: method, endpoint: endpoint);
            ScenarioContext.Current.Add(_httpClientWrongKey, httpClientHelper);
        }

        [Then(@"Check response message for get user info endpoint")]
        public void ThenCheckResponseMessageForGetUserInfoEndpoint()
        {
            var user = (User)ScenarioContext.Current[_userKey];
            var response = (string)ScenarioContext.Current[_response];

            Assert.IsTrue(response.Contains(user.NickName));
            Assert.IsTrue(response.Contains(user.FullName));
        }

        [Then(@"Check response message for non existing user")]
        public void ThenCheckResponseMessageForNonExistingUser()
        {            
            var response = (string)ScenarioContext.Current[_response];

            Assert.IsFalse(response.Contains(_testString));
            Assert.IsFalse(response.Contains(_testString));
        }

        }
}
