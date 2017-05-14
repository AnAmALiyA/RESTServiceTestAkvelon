using NUnit.Framework;
using NUnitTests.CommonTests.Setup;
using System.ServiceModel;

namespace NUnitTests.CommonTests
{
    [TestFixture]
    public class GetUserInformationTest : TestsSetup
    {
        [Test]
        public void GetInformationForExistingUser()
        {
            clientService.AddUser(user.NickName, user.FullName);
            var result = userRepository.FindBy(user.NickName);

            Assert.AreEqual(user.NickName, result.NickName);
            Assert.AreEqual(user.FullName, result.FullName);
        }

        [Test]
        public void GetInformationForNotExistingUser()
        {
            Assert.Throws<FaultException>(()=>clientService.GetUserInformation(user.NickName));
        }
    }
}
