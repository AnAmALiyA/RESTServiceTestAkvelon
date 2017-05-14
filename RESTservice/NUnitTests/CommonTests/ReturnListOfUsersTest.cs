using NUnit.Framework;
using NUnitTests.CommonTests.Setup;
using System.ServiceModel;

namespace NUnitTests.CommonTests
{
    [TestFixture]
    public class ReturnListOfUsersTest : TestsSetup
    {
        public void DeleteAllUser()
        {
            var listUser = clientService.ReturnListOfUsers();
            listUser.ForEach(u => clientService.DeleteUser(u.NickName));
        }

        [Test]
        public void GetAllUsers()
        {
            DeleteAllUser();

            clientService.AddUser(user.NickName, user.FullName);
            var result = clientService.ReturnListOfUsers();

            Assert.IsNotNull(result);
            result.ForEach(u =>
            {
                Assert.IsNotEmpty(u.NickName);
                Assert.IsNotEmpty(u.FullName);
            }
            );
        }

        [Test]
        public void GetAllUsersWhenDBIsEmpty()
        {
            DeleteAllUser();

            Assert.Throws<FaultException>(() => clientService.ReturnListOfUsers());
        }
    }
}
