using System.Collections.Generic;
using DAO.Entities;
using ServiceTest.Helpers;
using TechTalk.SpecFlow;
using ServiceTest.Tests.BaseSteps;
using Newtonsoft.Json;
using NUnit.Framework;

namespace ServiceTest.Tests
{
    [Binding]
    public class ReturnListOfUsersTestSteps : TestSetup
    {
        [Given(@"""(.*)"" request for ""(.*)"" endpoint")]
        public void GivenRestRequestForEndpoint(string method, string endpoint)
        {
            HttpClientHelper httpClient = new HttpClientHelper();
            ScenarioContext.Current.Add(_httpClientKey, httpClient);
        }

        [Given(@"Add test user to DB")]
        public void AddTestUserToDB()
        {
            var user = (User)ScenarioContext.Current[_userKey];
            _userRepository.Add(user);
        }

        [When(@"Request is executed")]
        public void WhenRequestIsExecured()
        {
            var httpClient = (HttpClientHelper)ScenarioContext.Current[_httpClientKey];
            ScenarioContext.Current.Add(_response, httpClient.SendRequest());
        }

        [Then(@"Return list of users response is validated")]
        public void ThenResponseIsValidated()
        {
            var response = (string)ScenarioContext.Current[_response];
            var users = JsonConvert.DeserializeObject<List<User>>(response);
        }

        [Given(@"Delete All users from DB")]
        public void DeleteAllUsersFromDB()
        {
            var listUser = _userRepository.GetAll();
            listUser.ForEach(u => _userRepository.Delete(u.NickName));
        }

        [Then(@"Response message validated")]
        public void ResponseMessageValidated()
        {
            Assert.IsTrue(string.IsNullOrWhiteSpace((string)ScenarioContext.Current[_response]));
        }

        [Then(@"Delete test user")]
        public void DeletetestUser()
        {
            var user = (User)ScenarioContext.Current[_userKey];
            _userRepository.Delete(user.NickName);
        }
    }
}
