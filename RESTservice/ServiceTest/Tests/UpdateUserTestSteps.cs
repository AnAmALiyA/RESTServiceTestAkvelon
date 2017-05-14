using DAO.Entities;
using NUnit.Framework;
using ServiceTest.Helpers;
using ServiceTest.Tests.BaseSteps;
using System;
using TechTalk.SpecFlow;

namespace ServiceTest.Tests
{
    [Binding]
    public class UpdateUserTestSteps : TestSetup
    {
        [Given(@"""(.*)"" by ""(.*)"" request for upadating user")]
        public void GivenRequestForUpadatingUser(string method, string request)
        {
            var user = (User)ScenarioContext.Current[_userKey];
            var endpoint = String.Concat(request, user.NickName);

            HttpClientHelper httpClientHelper = new HttpClientHelper(method: method, endpoint: endpoint);
            httpClientHelper.AttachAddUserMessage(user.NickName, _testString);

            ScenarioContext.Current.Add(_httpClientKey, httpClientHelper);
        }


        [Given(@"""(.*)"" by ""(.*)"" request for upadating non existing user")]
        public void GivenRequestForUpadatingNonExistingUser(string method, string request)
        {
            var user = (User)ScenarioContext.Current[_userKey];
            var endpoint = String.Concat(request, _testString);

            HttpClientHelper httpClientHelper = new HttpClientHelper(method: method, endpoint: endpoint);
            httpClientHelper.AttachAddUserMessage(user.NickName, _testString);

            ScenarioContext.Current.Add(_httpClientWrongKey, httpClientHelper);
        }

        [Then(@"Check response message when user updated")]
        public void ThenCheckResponseMessageWhenUserUpdated()
        {
            var user = (User)ScenarioContext.Current[_userKey];
            var response = (string)ScenarioContext.Current[_response];

            Assert.IsTrue(response.Contains(String.Format("User {0} successfully updated.", user.NickName)));
        }

        [Then(@"Check that user updated in DB")]
        public void ThenCheckThatUserUpdatedInDB()
        {
            var user = (User)ScenarioContext.Current[_userKey];            
            var userRepository = _userRepository.FindBy(user.NickName);

            Assert.IsTrue(user.FullName == userRepository.FullName);
        }

        [Then(@"Check response message when non existing user updated")]
        public void ThenCheckResponseMessageWhenNonExistingUserUpdated()
        {
            var user = (User)ScenarioContext.Current[_userKey];
            var response = (string)ScenarioContext.Current[_response];

            Assert.IsTrue(response.Contains("user not found."));
        }
    }
}
