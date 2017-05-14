using NUnit.Framework;
using NUnitTests.CommonTests.Setup;
using System.ServiceModel;

namespace NUnitTests.CommonTests
{
    [TestFixture]
    public class AddUserTest : TestsSetup
    {
        [Test]
        public void AddUser()
        {
            clientService.AddUser(user.NickName, user.FullName);
            Assert.IsTrue(userRepository.FindBy(user.NickName) == user);
        }

        [Test]
        public void AddWrongUser()
        {
            Assert.Throws<FaultException>(() => clientService.AddUser(null, user.FullName));
        }
    }
}
