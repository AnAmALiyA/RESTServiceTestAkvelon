using DAO.EF;
using DAO.Repository;
using TechTalk.SpecFlow;
using NUnitTests.Helpers;
using DAO.Entities;

namespace ServiceTest.Tests.BaseSteps
{
    public class TestSetup
    {
        protected readonly UserRepository _userRepository;
        protected readonly string _userKey = "user";
        protected readonly string _httpClientKey = "httpClient";
        protected readonly string _testString = "test";
        protected readonly string _httpClientWrongKey = "httpClientWrong";
        protected readonly string _response = "response";
        protected readonly string _userRepositoryString = "userRepository";

        public TestSetup()
        {
            _userRepository = new UserRepository(new EFContext());
        }

        [BeforeScenario]
        public void BeforeScenarioSetUp()
        {
            var user = GetUser();
            ScenarioContext.Current.Add(_userKey, user);
        }

        private User GetUser()
        {
            StringGenerator stringGenerator = new StringGenerator();
            User user = new User()
            {
                NickName = stringGenerator.RandomStringGenerator((int)TestSettings.NickNameLength),
                FullName = stringGenerator.RandomStringGenerator((int)TestSettings.FullNameLength)
            };
            return user;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var user = (User)ScenarioContext.Current[_userKey];
            _userRepository.Delete(user.NickName);
        }
    }
}
