using AFD.Services.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AFD.Model;

namespace Test.AFD.Services
{
    [TestClass()]
    public class ServicesTests
    {
        private readonly UserService _userService = new UserService();

        [TestInitialize]
        public void Initialize()
        {
            
        }

        [TestMethod]
        public void CreateUserTest()
        {
            var newUser = new User
            {
                Id = 0,
                Address = "AddrTest",
                Name = "Paul",
                PhoneNumber = "654654654"
            };

            Assert.AreEqual("Paul", _userService.CreateUser(newUser).Name);
        }

        [TestMethod]
        public void FindUserTest()
        {
            var newUser = new User
            {
                Id = 0,
                Address = "AddrTest",
                Name = "Paul",
                PhoneNumber = "654654654"
            };
            var foundUser = _userService.FindUser(_userService.CreateUser(newUser).Id);
            Assert.IsNotNull(foundUser);
        }

        [TestMethod]
        public void UpdateUserTest()
        {
            var newUser = new User
            {
                Id = 0,
                Address = "AddrTest",
                Name = "Paul",
                PhoneNumber = "654654654"
            };

            var createdUser = _userService.CreateUser(newUser);
            var foundUser = _userService.FindUser(createdUser.Id);

            foundUser.Name = "Ringo";

            _userService.UpdateUser(foundUser);
            _userService.FindUser(foundUser.Id);

            Assert.AreEqual("Ringo", _userService.FindUser(foundUser.Id).Name);
        }

        [TestMethod]
        public void DeleteUserTest()
        {
            var newUser = new User
            {
                Id = 0,
                Address = "AddrTest",
                Name = "Paul",
                PhoneNumber = "654654654"
            };
            var createdUser = _userService.CreateUser(newUser);

            _userService.DeleteUser(createdUser.Id);

            Assert.IsNull(_userService.FindUser(createdUser.Id));
        }
    }
}
