using NUnit.Framework;
using NUnitTests.CommonTests.Setup;

namespace NUnitTests.CommonTests
{
    [TestFixture]
    public class UpdateUserTest : TestsSetup
    {
        private readonly string _testString = "Test";

        [Test]
        public void UpdateExistingUser()
        {
            clientService.AddUser(user.NickName, user.FullName);
            clientService.UpdateUser(user.NickName, _testString);

            var result = clientService.GetUserInformation(user.NickName);
            Assert.IsTrue(result.FullName == _testString);
        }

        [Test]
        public void UpdateNonExistingUser()
        {
            Assert.IsTrue(clientService.UpdateUser(_testString, _testString).Contains("user not found."));
        }
    }
}
