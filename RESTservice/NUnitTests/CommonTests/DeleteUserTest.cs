using NUnit.Framework;
using NUnitTests.CommonTests.Setup;
using System.ServiceModel;

namespace NUnitTests.CommonTests
{
    [TestFixture]
    public class DeleteUserTest : TestsSetup
    {
        [Test]
        public void DeleteExistingUser()
        {
            clientService.AddUser(user.NickName, user.FullName);
            clientService.DeleteUser(user.NickName);

            Assert.Throws<FaultException>(()=>clientService.GetUserInformation(user.NickName));
        }

        [Test]
        public void DeleteNonExistingUser()
        {
            Assert.Throws<FaultException>(()=>clientService.DeleteUser(user.NickName));
        }
    }
}
