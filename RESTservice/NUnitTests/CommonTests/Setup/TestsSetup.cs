using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAO.Entities;
using System.ServiceModel;
using RestService;
using DAO.Repository;
using NUnit.Framework;
using NUnitTests.Helpers;
using RESTserviceConsoleApplication.Common;
using DAO.EF;

namespace NUnitTests.CommonTests.Setup
{
    public class TestsSetup
    {
        public User user;
        public ServiceHost serviceHost;
        public IRestServiceImplementation clientService;
        public UserRepository userRepository;

        [SetUp]
        public void SetUp()
        {
            StringGenerator stringGenerator = new StringGenerator();
            user = new User()
            {
                NickName = stringGenerator.RandomStringGenerator((int)TestSettings.NickNameLength),
                FullName = stringGenerator.RandomStringGenerator((int)TestSettings.FullNameLength)
            };

            serviceHost = new ProviderService().DeployServiceHost();
            clientService = new ConsumerService().ClientService();
            userRepository = new UserRepository(new EFContext());
        }

        [TearDown]
        public void TearDown()
        {
            userRepository.Delete(user.NickName);
        }
    }
}
