using DAO.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceTest.Helpers;
using ServiceTest.Tests.BaseSteps;
using System;
using TechTalk.SpecFlow;

namespace ServiceTest.Tests
{
    [Binding]
    public class AddUserTestSteps : TestSetup
    {
        [Given(@"""(.*)"" request for ""(.*)"" endpoint with body message")]
        public void GivenRequestForEndpointWithBodyMessage(string method, string endpoint)
        {
            var user = (User)ScenarioContext.Current[_userKey];

            HttpClientHelper httpClient = new HttpClientHelper(method: method);
            httpClient.AttachAddUserMessage(user.NickName, user.FullName);

            ScenarioContext.Current.Add(_httpClientKey, httpClient);
        }

        [Given(@"""(.*)"" request for ""(.*)"" endpoint with wrong body message")]
        public void GivenRequestForEndpointWithWrongBodyMessage(string method, string endpoint)
        {
            HttpClientHelper httpClient = new HttpClientHelper(method: method);
            httpClient.AttachAddUserMessage(_testString, _testString);

            ScenarioContext.Current.Add(_httpClientWrongKey, httpClient);
        }

        [Then(@"Сheck that test user stored in DB")]
        public void ThenСheckThatTestUserStoredInDB()
        {
            var user = (User)ScenarioContext.Current[_userKey];
            var userRepositiry = (User)ScenarioContext.Current[_userRepositoryString];

            Assert.IsTrue(user.NickName == userRepositiry.NickName);
        }

        [Then(@"Check response message")]
        public void ThenCheckResponseMessage()
        {
            var user = (User)ScenarioContext.Current[_userKey];
            var response = (string)ScenarioContext.Current[_response];
            
            Assert.IsTrue(response.Contains(String.Format("User {0} successfully addded.", user.NickName)));
        }

        [Then(@"Сheck that test user not stored in DB")]
        public void ThenСheckThatTestUserNotStoredInDB()
        {
            var user = (User)ScenarioContext.Current[_userKey];
            var userRepositiry = (User)ScenarioContext.Current[_userRepositoryString];

            Assert.IsNull(userRepositiry);
        }

        [Then(@"Check wrong response message")]
        public void ThenCheckWrongResponseMessage()
        {
            var user = (User)ScenarioContext.Current[_userKey];
            var response = (string)ScenarioContext.Current[_response];
            
            Assert.IsTrue(response.Contains("(400) Bad requesr."));
        }
    }
}
